
//============================================================================== Ammo Station Functions
StaticShapeData AmmoStation
{
   description = "Ammo Supply Unit";
	shapeFile = "ammounit";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundAmmoStationPower };
	sequenceSound[2] = { "use", SoundUseAmmoStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
   	explosionId = flashExpLarge;
};

function AmmoStation::onEndSequence(%this,%thread)
{
	if(%this.clTeamEnergy == "")
		%this.clTeamEnergy = (Player::getClient(Station::getTarget(%this))).TeamEnergy;
	if (Station::onEndSequence(%this,%thread)) 
		AmmoStation::onResupply(%this);
}									
											
function AmmoStation::onResupply(%this)
{	
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		%player.Station = %this;
		if (isPlayerBusy(%player) == 0) //== See if player is firing
		{
			if (%player != -1)
			{
				%cnt = Station::itemsToResupply(%player);
				if(getSimTime() - %this.enterTime > 11)
					%cnt = 0;

				if (%cnt != 0)
				{
					schedule("AmmoStation::onResupply(" @ %this @ ");",0.1,%this);
					return;
				}
				%client = Player::getClient(%player);
				%shooterClient = %this.tc;
				if (%shooterClient) //==== is sabotaged
				{
					%forceDir = Vector::getFromRot(GameBase::getRotation(%player),0,200); 
					Player::applyImpulse(%player,%forceDir);
					butter(%player,%shooterClient);
					MessageAllExcept(%client, 0, Client::getName(%client) @ " is a victim of " @ Client::getName(%shooterClient) @ "'s sabotage!");
					Client::sendMessage(%client,1,"Do you think that station might have been sabotaged?~wBXplo4.wav");
					%shooterClient.score = %shooterClient.score +5;
  					Bottomprint(%shooterClient, "<jc>Sabotage Success! Score +5 = " @ %shooterClient.score ,3);
				}
				if (%player.swim) 
				{
					%swim = %player.swim - 2;
					if (%swim < 1) %swim  = 1;
					%player.swim = %swim;
					if (Client::getGender(%client) == "Female") systemMessage(%client,0,"~wfemale4.wcolor3.wav");
					else systemMessage(%client,0,"~wmale2.wcolor3.wav");
					schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
					return;
				}
				Client::sendMessage(%client,0,"Resupply Complete~wshieldhit.wav");
				Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%client)]);
			}
			GameBase::setActive(%this,false);
			%player.Station = "";
			%this.enterTime="";
		}
		else
		{
			GameBase::setActive(%this,false);
			%client = Player::getClient(%player);
			Client::sendMessage(%client,0,"Resupply Stopped - Firing");
			%player.Station = "";
			return 0;
		}
	}
}
		 											
function AmmoStation::resupply(%player,%weapon,%item,%delta)
{
	%delta = checkResources(%player,%item,%delta,1);		
	if(%delta > 0) 
	{
		if(%item == RepairPatch) 
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			%station = %player.Station;
			%stationName = GameBase::getDataName(%station);
			if(%stationName == AmmoStation)
			{
				if (GameBase::getDamageLevel(%player) >0.2) GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) - 0.2);
				else GameBase::setDamageLevel(%player, 0);
			}
			else GameBase::repairDamage(%player,0.06);
			return %delta;
		}
		else if (%item == MineAmmo || %item == Grenade || %item == RepairKit || %item == Beacon) 
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			return %delta;
		}
		else if (Player::getItemCount(%player,%weapon)) 
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			return %delta;
		}
	}
	return 0;
}

//----------------------------------------------------------------------------
StaticShapeData DeployableAmmoStation
{
	description = "Remote Ammo Unit";
	shapeFile = "ammounit_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundAmmoStationPower };

	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisSmall;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
	validateShape = true;
	validateMaterials = true;
};

function DeployableAmmoStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Ammo Station");
	%this.Energy = $RemoteAmmoEnergy;
}

function DeployableAmmoStation::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this,1,"use");
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
	}
	else 
		GameBase::setActive(%this,false);
}
