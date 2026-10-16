//************************
//TRIBAL COMBAT STRUCTURES
//************************
function DeployOnTerrain(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   %obj = getObjectType($los::object);
   if(%obj == "SimTerrain")
   {
    %set = newObject("set",SimSet);
    %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
    %num = CountObjects(%set,%shape,%num);
    deleteObject(%set);
  
    if(Vector::dot($los::normal,"0 0 1") > 0.7)
    {
    %rot = GameBase::getRotation(%player);
    %obj = newObject(%name,%data,%shape,true);
    addToSet("MissionCleanup", %obj);
    GameBase::setTeam(%obj,GameBase::getTeam(%player));
    GameBase::setPosition(%obj,$los::position);
    GameBase::setRotation(%obj,%rot);
    %obj.deployer = %client;
    Gamebase::setMapName(%obj,%name);
    Client::sendMessage(%client,0,%name@" Deployed");
    GameBase::startFadeIn(%obj);
    playSound(SoundPickupBackpack,$los::position);
    if(%sound != "") playSound(%sound,$los::position);
    $TeamItemCount[GameBase::getTeam(%player) @ %name]++;

	if(Player::getArmor(%client) == scvarmor) {
		if(!Player::isDead(%player)) {
			Player::decItemCount(%client,Beacon,1);
		}
		GameBase::setDamageLevel(%obj, 0.6 * %shape.maxDamage);
	}

    return true;
    }
    else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
   else Client::sendMessage(%client,0,"Can only deploy on terrain");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//******************************
$ItemMax[larmor,VehicleBaseControl] = 0;
$ItemMax[carmor,VehicleBaseControl] = 0;
$ItemMax[marmor,VehicleBaseControl] = 1;
$ItemMax[harmor,VehicleBaseControl] = 0;
$ItemMax[darmor,VehicleBaseControl] = 0;
$ItemMax[lfemale,VehicleBaseControl] = 0;
$ItemMax[fcarmor,VehicleBaseControl] = 0;
$ItemMax[mfemale,VehicleBaseControl] = 1;
$ItemMax[scvarmor,VehicleBaseControl] = 1;

//**********************************
ItemImageData VehicleBaseControlImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData VehicleBaseControl
{
	description = "Vehicle Base Control";
	shapeFile = "invent_remote";
	className = "Backpack";
    heading = "tStructures";
	shadowDetailMask = 4	;
	imageType = VehicleBaseControlImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 3500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function VehicleBaseControl::onUse(%player,%item)
{
 if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
 else Player::deployItem(%player,%item);
}

function VehicleBaseControl::onDeploy(%player,%item,%pos)
{
 if(horzDeployShape(%player,%item,ssVehicleBaseControl,StaticShape,VehicleBaseControl)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}	

//***************************
$ItemMax[larmor,VehicleBasePad] = 0;
$ItemMax[carmor,VehicleBasePad] = 0;
$ItemMax[marmor,VehicleBasePad] = 1;
$ItemMax[harmor,VehicleBasePad] = 0;
$ItemMax[darmor,VehicleBasePad] = 0;
$ItemMax[lfemale,VehicleBasePad] = 0;
$ItemMax[fcarmor,VehicleBasePad] = 0;
$ItemMax[mfemale,VehicleBasePad] = 1;
$ItemMax[scvarmor,VehicleBasePad] = 1;

//**********************************
ItemImageData VehicleBasePadImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData VehicleBasePad
{
	description = "Vehicle Base Pad";
	shapeFile = "invent_remote";
	className = "Backpack";
    heading = "tStructures";
	shadowDetailMask = 4	;
	imageType = VehicleBasePadImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 7500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function VehicleBasePad::onUse(%player,%item)
{
 if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
 else Player::deployItem(%player,%item);
}

function VehicleBasePad::onDeploy(%player,%item,%pos)
{
 if(DeployOnTerrain(%player,%item,ssVehicleBasePad,StaticShape,VehicleBasePad)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}	

//********************************
StaticShapeData ssVehicleBaseControl
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

function ssVehicleBaseControl::onEndSequence(%this,%thread)
{
 if(Station::onEndSequence(%this,%thread)) ssVehicleBaseControl::onBuyingVechicle(%this);
}

function ssVehicleBaseControl::onPower(%this,%power,%generator)
{
 GameBase::setActive(%this,true);
}

function ssVehicleBaseControl::onAdd(%this)
{
 GameBase::setActive(%this,true);
}

function ssVehicleBaseControl::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
   if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
   else %value *= $Combat::DamageScale;

   %damageLevel = GameBase::getDamageLevel(%this);
   %dValue = %damageLevel + %value;
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
}

function ssVehicleBaseControl::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "VehicleBaseControl"]--;
StaticShape::onDestroyed(%this);
}

function ssVehicleBaseControl::onCollision(%this, %object)
{
 if(%this.target == "")
 {
  dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
  %obj = getObjectType(%object);
  if(%obj == "Player" && isPlayerBusy(%object) == 0) 
  {
   %client = Player::getClient(%object);
   if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) 
   {
	if(GameBase::getDamageState(%this) == "Enabled") 
	{
	 if(%this.enterTime == "") %this.enterTime = getSimTime();
	 GameBase::setActive(%this,true);
  	}
	else Client::sendMessage(%client,0,"Unit is disabled");
   }
   else if(Station::getTarget(%this) == %object)
   {
    %curTime = getSimTime();
    if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") 
    {
     Client::clearItemShopping(%client);
     Station::onDeactivate(%this);
     Station::onEndSequence(%this,1);
     if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client,1);
     %object.stationDeniedStamp = %curTime;
     Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
    }
   }
  }
 }
}

function ssVehicleBaseControl::onBuyingVechicle(%this)
{
 if(GameBase::isActive(%this)) 
 {
  %player = Station::getTarget(%this);
  if(%player != -1 && %this.lastPlayer == %player) 
  {
   %client = Player::getClient(%player);
   if(%this.target != %client) 
   {
    setupShoppingList(%client,%this,"VehicleInvList");
	updateBuyingList(%client);
	%this.target = %client;
	%this.clTeamEnergy = %client.TeamEnergy;
	Client::setGuiMode(%client,4);
	Client::sendMessage(%client,0,"Station Access On");
	%player.Station = %this;
	%numItems = Group::objectCount(GetGroup(%this));
	for(%i = 0 ; %i<%numItems ; %i++) 
	{ 
	 %obj = Group::getObject(GetGroup(%this), %i);
	 %name = GameBase::getDataName(%obj); 
	 if(%name == ssVehicleBasePad && GameBase::getTeam(%obj) == GameBase::getTeam(%player)) 
	 { 
      %this.vehiclePad = %obj;
	  GameBase::setActive(%this.vehiclePad,true);
	  %i = %numItems;
	 }
	}
   }
   schedule("ssVehicleBaseControl::onBuyingVechicle(" @ %this @ ");",0.5,%this);
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

function ssVehicleBaseControl::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::getDamageState(%obj) == "Enabled") 
	{
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("set",SimSet);
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
						else return 2;
					}
					else 
					{
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else 
				{ 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay) 
		{
			if (checkResources(%player,%item,1)) 
			{
	    		%vehicle = newObject("",flier,$DataBlockName[%item],true);
				%vehicle.deployer = %client;
				Gamebase::setMapName(%vehicle,%item.description);
                %vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));
				if(%object.fading) 
				{ 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; ssVehicleBasePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else 
				{
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	schedule(%vehicle @ ".fading = \"\"; ssVehicleBasePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");
	return 0;
}

//****************************
StaticShapeData ssVehicleBasePad
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



function ssVehicleBasePad::onActivate(%this)
{
	GameBase::playSequence(%this,1,"use");
}

function ssVehicleBasePad::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function ssVehicleBasePad::onEnabled(%this)
{
}

function ssVehicleBasePad::onAdd(%this)
{
 GameBase::setActive(%this,true);
}

function ssVehicleBasePad::onCollision(%this, %object)
{
}

function ssVehicleBasePad::onPower(%this,%power,%generator)
{
 GameBase::setActive(%this,true);
}

function ssVehicleBasePad::checkSeq(%this, %station)
{
 if(%station.target == "") GameBase::setActive(%this,false);
}

function ssVehicleBasePad::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
   if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
   else %value *= $Combat::DamageScale;

   %damageLevel = GameBase::getDamageLevel(%this);
   %dValue = %damageLevel + %value;
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this,%dValue);
}

function ssVehicleBasePad::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "VehicleBasePad"]--;
StaticShape::onDestroyed(%this);
}

//**************************
$TeamItemMax[FloatingPad] = 6;

$ItemMax[larmor, FloatingPad] = 0;
$ItemMax[carmor, FloatingPad] = 0;
$ItemMax[marmor, FloatingPad] = 1;
$ItemMax[harmor, FloatingPad] = 0;
$ItemMax[darmor, FloatingPad] = 1;
$ItemMax[lfemale, FloatingPad] = 0;
$ItemMax[fcarmor, FloatingPad] = 0;
$ItemMax[mfemale, FloatingPad] = 1;
$ItemMax[scvarmor, FloatingPad] = 1;

ItemImageData FloatingPadImage
{
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0};
mass = 2.0;
firstPerson = false;
};

ItemData FloatingPad
{
description = "FloatingPad";
shapeFile = "flagstand";
className = "Backpack";
heading = "tStructures";
imageType = FloatingPadImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 2000;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function FloatingPad::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

//special deploy
function FloatingPad::onDeploy(%player,%item,%pos)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  %position = GameBase::getPosition(%player);
  if(getWord(%position,2) < 300)
  {
   %rot = GameBase::getRotation(%player);
   %obj = newObject("FloatingPad",StaticShape,ssFloatingPad,true);
   addToSet("MissionCleanup", %obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,GameBase::getPosition(%player));
   GameBase::setRotation(%obj,%rot);
   %obj.deployer = %client;
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,"FloatingPad Deployed");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
   $TeamItemCount[GameBase::getTeam(%player) @ "FloatingPad"]++;

	if(Player::getArmor(%client) == scvarmor) {
		if(!Player::isDead(%player)) {
			Player::decItemCount(%client,Beacon,1);
		}
		GameBase::setDamageLevel(%obj, 0.6 * ssFloatingPad.maxDamage);
	}

   return true;
  }
  else Client::sendMessage(%client,0,"The Floating Pad can't maintain this height.");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}


//============================================================================================== Defense Emplacement


function checkDeployLargeArea(%client,%pos)
{
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,20,20,20,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0);
		%objname = GameBase::getDataName(%obj);
		if (!Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
		else {
			deleteObject(%set);
			return 1;
		}
	}
	else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}


$TeamItemMax[EmplacementPack] = 1;
$InvList[EmplacementPack] = 1;
$RemoteInvList[EmplacementPack] = 0;
$CanAlwaysTeamDestroy[EmplacementPack] = 1;

ItemImageData EmplacementPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.3, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData EmplacementPack
{
        description = "Supply Station";
        shapeFile = "magcargo";
        className = "Backpack";
	heading = "tStructures";
        shadowDetailMask = 4;
        imageType = EmplacementPackImage;
        mass = 2.0;
        elasticity = 0.2;
        price = 8000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function EmplacementPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        } else {
                Player::deployItem(%player,%item);
        }
}

function EmplacementPack::rotVector(%vec,%rot)
{
	// this function rotates a vector about the z axis

	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);

	// new vector with z axis removed
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	
	// change vector to distance and rotation
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );

	// modify rotation and change back to vector (put z axis offset back)
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}


function EmplacementPack::onDeploy(%player,%item,%pos)
{
	if (EmplacementPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function EmplacementPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,6)) {
			%obj = getObjectType($los::object);

			if (!checkDeployLargeArea(%client, $los::position)) {
				Client::sendMessage(%client,1,"Objects in the way, can not deploy.");
				return;
			}
                        
			if (%obj == "SimTerrain") {

				if (Vector::dot($los::normal,"0 0 1") > 0.8) {
					%number = $TeamItemCount[GameBase::getTeam(%player) @ "EmplacementPack"];

					%cname = "Emplacement" @ Client::getName(%client) @ "" @ %number;
					%name1 = "Emplacement1" @ Client::getName(%client) @ "" @ %number;
					%name2 = "StationGenerator" @ Client::getName(%client) @ "" @ %number;
					%name3 = "InventoryStation" @ Client::getName(%client) @ "" @ %number;

					instant SimGroup %cname {
						instant StaticShape %name1 {
							dataBlock = "LargeAirBasePlatform";
							name = %plat1;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 2 0.4", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							VehiclePad = %name5;
							team = GameBase::getTeam(%player);
						};

						instant StaticShape %name2 {
							dataBlock = "PortGenerator";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 6.15 0.7", GameBase::getRotation(%player) ) );
							rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							team = GameBase::getTeam(%player);
						};
						
						instant StaticShape %name3 {
							dataBlock = "InventoryStation";
							name = %name3;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 3.75 0.9", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							team = GameBase::getTeam(%player);
						};
					};


					addToSet("MissionCleanup",%cname@"/"@%name1);
					addToSet("MissionCleanup",%cname@"/"@%name2);
					addToSet("MissionCleanup",%cname@"/"@%name3);
				
					%n1 = (nametoId("MissionCleanup/" @ %name1));
					%n2 = (nametoId("MissionCleanup/" @ %name2));
					%n3 = (nametoId("MissionCleanup/" @ %name3));

					gamebase::setteam(%n1, gamebase::getteam(%client));
					gamebase::setteam(%n2, gamebase::getteam(%client));
					gamebase::setteam(%n3, gamebase::getteam(%client));

					$TeamItemCount[GameBase::getTeam(%player) @ "EmplacementPack"]++;
					%playerpos = GameBase::getPosition(%player);
					%newplayerpos = Vector::add(%playerpos, "0 0 0.2");
					GameBase::setPosition(%player,%newplayerpos);

					return true;
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can only deploy on terrain.");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	}

	return false;
}


