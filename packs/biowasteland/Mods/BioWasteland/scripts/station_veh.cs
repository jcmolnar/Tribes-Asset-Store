//========================================================================================= Vehicle Stations
StaticShapeData VehicleStation
{
   	description = "Station Vehicle Unit";
	shapeFile = "vehi_pur_pnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
};

function VehicleStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) 
		VehicleStation::onBuyingVechicle(%this);
}

function VehicleStation::onBuyingVechicle(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%client.ListType = "VehicleInvList";
				setupShoppingList(%client,%this,"VehicleInvList");
				updateBuyingList(%client);
				
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				Client::setGuiMode(%client,4);
				Client::sendMessage(%client,0,"Station Access On");

				%player.Station = %this;
			 	%numItems = Group::objectCount(GetGroup(%this));
				
				%maxlook = 9999;
				for(%i = 0 ; %i<%numItems ; %i++)
				{ 
					%obj = Group::getObject(GetGroup(%this), %i);
					%name = GameBase::getDataName(%obj); 

					if(%name == "VehiclePad")
					{
					
						%st = GameBase::getPosition(%this);
						%vp = GameBase::getPosition(%obj);
						%dist = Vector::getDistance(%st, %vp);

						echo ("Station Dist " @ %dist);
						
						if (%dist < %maxlook)
						{
							%temp = %obj;
							%maxlook = %dist;
						}
					}
				}			
				%this.vehiclePad = %temp;
				GameBase::setActive(%this.vehiclePad,true);
				%i = %numItems;
				%shooterClient = %this.tc;
				if (%shooterClient) //==== is sabotaged
				{
					Client::sendMessage(%client,1,"Do you think this station might be sabotaged?");
					%shooter = Client::getOwnedObject(%shooterClient);
					%type = "DeployablePlasma";
					%padd = "0 0 1.5";
					%pos = Vector::add(%vp, %padd);
					%Set = newObject("KillSet",SimSet);
					%Mask = $StaticObjectType;
					containerBoxFillSet(%Set, %Mask, %pos, 1, 1, 1, 0);
					%num = Group::objectCount(%Set);
					for(%i = 0; %i < %num; %i++)
					{
						%object = group::getobject(%Set, %i);
						if(getObjectType(%object) == "Turret")
						{
							schedule("Grenade::Plastic_Detonate( " @ %object @ " );", 1);
							%type = "RailTurret";
						}
					}
					deleteobject(%Set);
					%turret = newObject("Sabotaged","Turret",%type,true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%shooter));
					GameBase::setRotation(%turret,"0 0 0");
					GameBase::setPosition(%turret,%pos);
					playSound(bigExplosion1,%vp);
					Client::setOwnedObject(%shooterClient, %turret); 
					Client::setOwnedObject(%shooterClient, %shooter);
					MessageAllExcept(%client, 0, Client::getName(%client) @ " is a victim of " @ Client::getName(%shooterClient) @ "'s sabotage!");
					%shooterClient.score = %shooterClient.score +5;
  					Bottomprint(%shooterClient, "<jc>Sabotage Success! Score +5 = " @ %shooterClient.score ,3);
					%forceDir = Vector::getFromRot(GameBase::getRotation(%this),-1000,50); 
					Player::applyImpulse(%player,%forceDir);
				}					

			}
			schedule("VehicleStation::onBuyingVechicle(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{	   
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
	}
}

function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled")
	{
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("vehicleset",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);
		%station = %player.Station;
		
		if(%objInWay == 1) 
		{
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) 
			{
				if(GameBase::getControlClient(%object) == -1) 
				{
					if(%station.fadeOut == "") 
					{
						if(%item != $VehicleToItem[%sname]) 
						{
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else
							return 2;
					}
					else {
						systemMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else { 
					systemMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay) 
		{
			if (checkResources(%player,%item,1))
			{
	    			%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
            			%vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));

				%padd = "0 0 1";
				%pos = Vector::add(%markerPos, %padd);

				if(%object.fading)
				{ 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %pos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else
				{
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%pos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		systemMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}


StaticShapeData VehiclePad
{
   	description = "Vehicle Pad";
	shapeFile = "vehi_pur_poles";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
  	explosionId = flashExpLarge;
	damageSkinData = "objectDamageSkins";
};



function VehiclePad::onActivate(%this)
{
	GameBase::playSequence(%this,1,"use");
}

function VehiclePad::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function VehiclePad::onEnabled(%this)
{
}

function VehiclePad::onAdd(%this)
{
}

function VehiclePad::onCollision(%this, %object)
{
}

function VehiclePad::onPower(%this,%power,%generator)
{
	if(!%power)
		GameBase::setActive(%this,false);
}

function VehiclePad::checkSeq(%this, %station)
{
	if(%station.target == "")
		GameBase::setActive(%this,false);
}