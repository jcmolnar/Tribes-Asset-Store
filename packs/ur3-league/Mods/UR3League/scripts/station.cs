//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

// List of all items available to buy from inventory station
$InvList[Blaster] = 1;
$InvList[Chaingun] = 1;
$InvList[Disclauncher] = 1;
$InvList[GrenadeLauncher] = 1;
$InvList[Mortar] = 1;
$InvList[PlasmaGun] = 1;
$InvList[LaserRifle] = 1;
$InvList[EnergyRifle] = 1;
$InvList[AssaultRifle] = 1;
$InvList[Railgun] = 1;
$InvList[FFBLauncher] = 1;
$InvList[RocketLauncher] = 1;
$InvList[TargetingLaser] = 1;
$InvList[MineAmmo] = 1;
$InvList[Grenade] = 1;
$InvList[Beacon] = 1;
$InvList[ForceFieldPack] = 1;
$InvList[LargeFieldPack] = 1;
$InvList[CloakGun] = 1;
$InvList[HellPack] = 1;
$invlist[ResupplyPack] = 1;


$InvList[BulletAmmo] = 1;
$InvList[PlasmaAmmo] = 1;
$InvList[DiscAmmo] = 1;
$InvList[MayhemAmmo] = 1;
$InvList[RailAmmo] = 1;
$InvList[GrenadeAmmo] = 1;
$InvList[MortarAmmo] = 1;
$InvList[FFBAmmo] = 1;
$InvList[RocketAmmo] = 1;
  
$InvList[EnergyPack] = 1;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 1;
$InvList[SensorJammerPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[CameraPack] = 1;
$InvList[SpySatellitePack] = 1;
$InvList[TurretPack] = 1;
$InvList[RocketPack] = 1;
$InvList[AmmoPack] = 1;
$InvList[RepairKit] = 1;
$InvList[DeployableInvPack] = 1;
$InvList[DeployableAmmoPack] = 1;
$InvList[FakeFlagPack] = 1;
$InvList[StealthShieldPack] = 1;




//----------------------------------------------------------------------------

// List of all items available to buy from Remote Station
$RemoteInvList[Blaster] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[Disclauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[LaserRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;
$RemoteInvList[AssaultRifle] = 1;
$RemoteInvList[Railgun] = 1;
$RemoteInvList[FFBLauncher] = 1;
$RemoteInvList[RocketLauncher] = 1; 
$RemoteInvList[TargetingLaser] = 1;
$RemoteInvList[MineAmmo] = 1;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[Beacon] = 1;
$RemoteInvList[DeployableAmmoPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
$RemoteInvList[LargeFieldPack] = 1;
$RemoteInvList[StealthShieldPack] = 1;
$RemoteInvList[FakeFlagPack] = 1;
$RemoteInvList[HellPack] = 1;
$remoteinvlist[ResupplyPack] = 1;


$RemoteInvList[BulletAmmo] = 1;
$RemoteInvList[PlasmaAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;
$RemoteInvList[MayhemAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;
$RemoteInvList[FFBAmmo] = 1;
$RemoteInvList[RocketAmmo] = 1; 
  
$RemoteInvList[EnergyPack] = 1;
$RemoteInvList[RepairPack] = 1;
$RemoteInvList[ShieldPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[CameraPack] = 1;
$RemoteInvList[SpySatellitePack] = 1;
$RemoteInvList[TurretPack] = 1;
$RemoteInvList[RocketPack] = 1;
$RemoteInvList[AmmoPack] = 1;
$RemoteInvList[RepairKit] = 1;
$RemoteInvList[CloakGun] = 1;
//----------------------------------------------------------------------------

// List of all items available to buy from Vehicle station
$VehicleInvList[ScoutVehicle] = 1;
$VehicleInvList[LAPCVehicle] = 1;
$VehicleInvList[HAPCVehicle] = 1;

//----------------------------------------------------------------------------

$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;

$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;


//----------------------------------------------------------------------------
// Default station animations - Added Station Eject - *IX*Savage1

function Station::onActivate(%this)
{
	//echo("Activate " @ %this);
	%obj = Station::getTarget(%this);
	if (%obj != -1) 
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
		%this.lastPlayer = %obj;
		%obj.inStation = %this;
		if($ultra_renegades::StationTime) 
		{
			if($ultra_renegades::StationTime < 10) 
				$ultra_renegades::StationTime = 10;
			else if($ultra_renegades::StationTime > 60)
				$ultra_renegades::StationTime = 60;
			%obj.stationAccess++;
			%dName = GameBase::getdataName(%this);
			if(%dName == InventoryStation)
				ixCheckStationEject(%obj,%this,%obj.stationAccess,($ultra_renegades::StationTime / 5));
		}
	}
	else 
		GameBase::setActive(%this,false);
}

function Station::onDeactivate(%this)
{
	%obj = %this.lastPlayer;
	if(%this == %obj.inStation)
		%obj.inStation = false;
	//echo("Dectivate " @ %this);
	GameBase::stopSequence(%this,2);
	GameBase::setSequenceDirection(%this,1,0);
}

function ixCheckStationEject(%player, %station, %stat, %count)
{
	if($ultra_renegades::StationTime)
	{
		if((%player.inStation) && (%player.inStation == %station) && (%stat == %player.stationAccess))
		{
			if(%count)
			{
				if(%count == 1)
					Client::sendMessage(GameBase::getOwnerClient(%player),1,"You will be Ejected from the station in 5 Seconds.~waccess_denied.wav");
				schedule("ixCheckStationEject(" @ %player @ "," @ %station @ "," @ %stat @ "," @ %count - 1 @ ");",5,%player);
			}
			else
			{
				Client::sendMessage(GameBase::getOwnerClient(%player),1,"You have been Ejected from the Station to give others access to it.~waccess_denied.wav");
				ixStationEjectPlayer(%station, %player);
			}
		}
	}
}

function ixStationEjectPlayer(%station, %player)
{
	%rot = GameBase::getRotation(%station);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),10);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%vel = %x @ " " @ %y @ " " @ 15;
	Item::setVelocity(%player,%vel);
}

function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}	

function ixSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
function Station::onEndSequence(%this,%thread)
{
	//echo("End sequence " @ %this);
 	if (%thread == 1 && GameBase::isActive(%this)) {
		GameBase::playSequence(%this,2,"use");
		return true;
	}
	%client = %this.target;
	if(%client == "") {
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}
	if(%client != "") {
		if(Client::getGuiMode(%client) != 1)
			Client::setGuiMode(%client,1);
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite") {
			if(%this.clTeamEnergy != %client.TeamEnergy) {
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat) {
				TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}
	if(%this.target != "") {
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	%this.clTeamEnergy = "";
	return false;
}

function Station::onPower(%this,%power,%generator)
{
	if (%power) {
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
	else {
		GameBase::stopSequence(%this,0);
		GameBase::pauseSequence(%this,1);
		GameBase::pauseSequence(%this,2);
		Station::checkTarget(%this);
	}
}

function Station::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {		
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
}

function Station::checkTarget(%this)
{
	if(%this.target) {
		Client::setGuiMode(%this.target,1);
		GameBase::setActive(%this,false);
	}
}

function Station::onDisabled(%this)
{
	Station::weaponCheck(%this);
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::pauseSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
}

function Station::onDestroyed(%this)
{
	Station::weaponCheck(%this);
	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 
}

function Station::weaponCheck(%this)
{
	if(%this.lastPlayer != "") {
		%player = %this.lastPlayer;
		%player.Station = "";
		if(Player::getMountedItem(%player,$WeaponSlot) == -1){
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
	  		}
		}											
	 	%this.lastPlayer = "";
  	}
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14")) {
	  	// GetLOSInfo sets the following globals:
	  	// 	los::position
	  	// 	los::normal
	  	// 	los::object
	  	%obj = getObjectType($los::object);
		dbecho(3, "STATION: LOS got " @ %obj);
	  	if (%obj == "Player") {
         if( Player::isAiControlled( $los::object ) != "True" ) {
			   return $los::object;
         }
		}
	}
	dbecho(3, "STATION: LOS Got None");
	return -1;
}	

function Station::onCollision(%this, %object)
{
	if(%this.target == ""){
		dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
		%obj = getObjectType(%object);
		if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  		 	%client = Player::getClient(%object);
 			if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) {
				if (GameBase::getDamageState(%this) == "Enabled") {
					if (GameBase::isPowered(%this)) { 
						if(%this.enterTime == "")
							%this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
					}
					else 
						Client::sendMessage(%client,0,"Unit is not powered");
				}
				else 
					Client::sendMessage(%client,0,"Unit is disabled");
			}
			else if(Station::getTarget(%this) == %object)
   	   {
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
					Client::clearItemShopping(%client);
					Station::onDeactivate(%this);
					Station::onEndSequence(%this,1);
					if(Client::getGuiMode(%client) != 1)
						Client::setGuiMode(%client,1);
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
		}
	}
}

function Station::itemsToResupply(%player)
{
			%cnt = 0;
			%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
			%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,5);
			%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,10);
			%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
			%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,200);
			%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,100);
			%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,30);
                  %cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,RifleAmmo,500);
                  %cnt = %cnt + AmmoStation::resupply(%player,AssaultRifle,MayhemAmmo,500);  
			%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,200);
			%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,20);
                  %cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,500);
                  %cnt = %cnt + AmmoStation::resupply(%player,FFBLauncher,FFBAmmo,10);
                  %cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,10); 
			%cnt = %cnt + AmmoStation::resupply(%player,LiLPOOmkii,LiLPOOmkiiAmmo,500); 
			%cnt = %cnt + AmmoStation::resupply(%player,m16,m16Ammo,500); 
	return %cnt;
}

//----------------------------------------------------------------------------
// Deployable stations

function DeployableStation::onActivate(%this)
{
	//echo("Activate " @ %this);
	%obj = Station::getTarget(%this);
	if (%obj != -1) {
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else 
		GameBase::setActive(%this,false);
}


function DeployableStation::onEndSequence(%this,%thread)
{
   if(!%thread) {
		%this.deployed = 1;
		GameBase::playSequence(%this,2,"power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this,0,"deploy");
}

function DeployableStation::onDeactivate(%this)
{
	//echo("Dectivate " @ %this);
	GameBase::stopSequence(%this,1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this,2,"power");
}

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);

	if(%stationName == DeployableInvStation) 
    	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	else if( %stationName == DeployableAmmoStation) 
	  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 
		0.1, 200, 100); 
	Station::weaponCheck(%this);
}

function DeployableStation::onCollision(%this, %object)
{
	//echo("Collision (" @ %this @ ",	" @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  	 	%client = Player::getClient(%object);
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) {
			if (GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
      else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

StaticShapeData AmmoStation
{
   description = "Ammo Supply Unit";
	shapeFile = "ammounit";
   validateShape = true;
   validateMaterials = false;
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundAmmoStationPower };
	sequenceSound[2] = { "use", SoundUseAmmoStation };
	maxDamage = 2.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
   explosionId = flashExpLarge;
};

function AmmoStation::onEndSequence(%this,%thread)
{
	//echo("End Seq ",%thread);
	%player = Station::getTarget(%this);
	if(%this.clTeamEnergy == "")
		%this.clTeamEnergy = (Player::getClient(%player)).TeamEnergy;
	if (Station::onEndSequence(%this,%thread)) {    
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
		if(%weapon != -1) {
			%player.lastWeapon = %weapon;
			Player::unMountItem(%player,$WeaponSlot);
		}
		AmmoStation::onResupply(%this);
	}
}									
											
function AmmoStation::onResupply(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
			if (%cnt != 0) {
				%player.waitThrowTime = getSimTime();
				schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
				return;
			}
			%player.Station = "";
			%client = Player::getClient(%player);
			%this.target = "";
			Client::sendMessage(%client,0,"Resupply Complete - Now go kill something!");
		Player::setItemCount(%client,Beacon,15);
		Player::setItemCount(%client,Grenade,15);
			Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%client)]);

			if(Player::getMountedItem(%player,$WeaponSlot) == -1){
				if(%player.lastWeapon != "") {
					Player::useItem(%player,%player.lastWeapon);		 	
					%player.lastWeapon = "";
	  			}
			}			
		}
		else if(%this.target != "") {
			%player = Client::getOwnedObject(%this.target);
			%player.Station = "";
			if(Player::getMountedItem(%player,$WeaponSlot) == -1){
				if(%player.lastWeapon != "") {
					Player::useItem(%player,%player.lastWeapon);		 	
					%player.lastWeapon = "";
	  			}
			}		
			%this.target = "";
		}
		else {
			%this.lastPlayer.Station = "";
			if(Player::getMountedItem(%this.lastPlayer,$WeaponSlot) == -1){
				if(%this.lastPlayer.lastWeapon != "") {
					Player::useItem(%this.lastPlayer,%this.lastPlayer.lastWeapon);		 	
					%this.lastPlayer.lastWeapon = "";
	  			}
			}
			%this.target = "";
		}
		GameBase::setActive(%this,false);
		%this.enterTime="";
	}
}
		 											
function AmmoStation::resupply(%player,%weapon,%item,%delta)
{
	%delta = checkResources(%player,%item,%delta,1);		
	if(%delta > 0) {						
		if(%item == RepairPatch) {
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			GameBase::repairDamage(%player,0.06);
		 	return %delta;
		}
		else if (%item == MineAmmo || %item == Grenade || %item == RepairKit) {
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
		else if (Player::getItemCount(%player,%weapon)) {
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
   validateShape = true;
   validateMaterials = true;
	className = "DeployableStation";
	maxDamage = 2.0;
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
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
		%this.lastPlayer = Station::getTarget(%this);
		%player = %this.lastPlayer; 
		%player.Station = %this;
		%this.target = Player::getClient(Station::getTarget(%this));
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
		if(%weapon != -1) {
			%player.lastWeapon = %weapon;
			Player::unMountItem(%player,$WeaponSlot);
		}
	}
	else 
		GameBase::setActive(%this,false);	
}


//----------------------------------------------------------------------------

StaticShapeData DeployableInvStation
{
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
   validateShape = true;
   validateMaterials = true;
	className = "DeployableStation";
	maxDamage = 2.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundInventoryStationPower };			
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
   explosionId = flashExpSmall;
//	triggerRadius = 1.5;
};


function DeployableInvStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
 		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}


//----------------------------------------------------------------------------

StaticShapeData InventoryStation
{
   description = "Station Supply Unit";
	shapeFile = "inventory_sta";
   validateShape = true;
   validateMaterials = false;
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 3.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread)
{
	//echo("End Seq ",%thread);
	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"InvList");
}

function InventoryStation::onResupply(%this,%InvShopList)
{
	dbecho(3, "STATION::Resupply");
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			%client = Player::getClient(%player);
			if (%this.target != %client) {
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
            if(!%client.noEnterInventory)
   				Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				Player::setItemCount(%client,Beacon,15);
				Player::setItemCount(%client,Grenade,15);
				%player.ResupplyFlag = 1;
				%weapon = Player::getMountedItem(%player,$WeaponSlot);
				if(%weapon != -1) {
					%player.lastWeapon = %weapon;
					Player::unMountItem(%player,$WeaponSlot);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			if(%player.ResupplyFlag) 
			   %player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target != "") {	   
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Player::setItemCount(%client,Beacon,12);
		Player::setItemCount(%client,Grenade,24);
		Station::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation) {
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
			%player.Station = "";
  			%this.target = "";
		}
		if(Player::getMountedItem(%player,$WeaponSlot) == -1){
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
	  		}
		}
	}
	%this.enterTime="";
}


function resupply(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1) {
			// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
			%client = Player::getClient(%player);
			if (%cnt != 0) {
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client,0,"Resupply Complete");
			return 0;
		}
	}
	return 0;
}


//----------------------------------------------------------------------------
function setupShoppingList(%client,%station,%ListType)
{
	%max = getNumItems();
	if(%ListType == "InvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				Client::setItemShopping(%client, %item);
		}
	}
	else if(%ListType == "RemoteInvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
	   }
	}
	else {
		for (%i = 0; %i < %max; %i = %i + 1) {						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
}

function updateBuyingList(%client)
{
   Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%energy = %station.Energy;
   	Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: " @ %energy );
	}
   else {
		%energy = $TeamEnergy[Client::getTeam(%client)];
		Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);
	}
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++) {
		%item = getItemData(%i);
      if(!%item.showInventory)
         continue;
		if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client,%i)) {
			%extraAmmo = 0;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
				%extraAmmo = $AmmoPackMax[%item];
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))	{
				if(%energy >= %item.price ) {
					if(%item.className == Weapon) {
						if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor])					
							Client::setItemBuying(%client, %item);
					}
					else { 
						if($TeamItemMax[%item] != "") {						
							if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
								Client::setItemBuying(%client, %item);
						}
						else
							Client::setItemBuying(%client, %item);
					}
				}
		   }
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i)) 
			Client::setItemBuying(%client, %item);
		else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
			Client::setItemBuying(%client, %item);
	}
}

//----------------------------------------------------------------------------
StaticShapeData CommandStation
{
   description = "Command Station";
	shapeFile = "cmdpnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 2.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

function CommandStation::onEndSequence(%this,%thread)
{
	//echo("End Seq ",%thread);
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
	if (Station::onEndSequence(%this,%thread)) 
		CommandStation::onResupply(%this);
}

function CommandStation::onResupply(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			%client = Player::getClient(%player);
			if (%this.target != %client) {
				%this.target = %client;
				%player.CommandTag = 1;
				Client::setGuiMode(%client,2);
				Client::sendMessage(%client,0,"Command Access On");
				%player.station = %this;
			}
			schedule("CommandStation::onResupply(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target) {
		Client::sendMessage(%this.target,0,"Command Access Off");
		(Client::getOwnedObject(%this.target)).CommandTag = "";
		checkControlUnmount(%this.target);
	}
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
}


//----------------------------------------------------------------------------
StaticShapeData VehicleStation
{
   description = "Station Vehicle Unit";
	shapeFile = "vehi_pur_pnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
//   explosionId = DebrisExp;
	maxDamage = 2.0;
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
	//echo("End Seq ",%thread);
	if (Station::onEndSequence(%this,%thread)) 
		VehicleStation::onBuyingVechicle(%this);
}

function VehicleStation::onBuyingVechicle(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			%client = Player::getClient(%player);
			if (%this.target != %client) {
				setupShoppingList(%client,%this,"VehicleInvList");
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				Client::setGuiMode(%client,4);
				Client::sendMessage(%client,0,"Station Access On");
				%player.Station = %this;
			 	%numItems = Group::objectCount(GetGroup(%this));
				for(%i = 0 ; %i<%numItems ; %i++) { 
					%obj = Group::getObject(GetGroup(%this), %i);
					%name = GameBase::getDataName(%obj); 
					if(%name == VehiclePad) { 
						%this.vehiclePad = %obj;
						GameBase::setActive(%this.vehiclePad,true);
						%i = %numItems;
					}
				}
			}
			schedule("VehicleStation::onBuyingVechicle(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target) {	   
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
	}
}


function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled") {
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);
		%station = %player.Station;
		if(%objInWay == 1) {
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) {
				if(GameBase::getControlClient(%object) == -1) {
					if(%station.fadeOut == "") {
						if(%item != $VehicleToItem[%sname]) {
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
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else { 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay) {
			if (checkResources(%player,%item,1)) {
	    		%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
            %vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));
				if(%object.fading) { 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else {
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
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
		{

			// gwKickXandMagikOffVehiclePad by {187}George W.
			// Boots player off of vehicle pad if they're in the way
			%object = Group::getObject(%set, 0);
			if(getObjectType(%object)=="Player")
			{
				item::setvelocity(%object, vector::getfromrot(gamebase::getrotation(%this), 10, 25));
				client::sendmessage(player::getclient(%object), 1, "Get off the pad, dork!~wmale3.woutway.wav");
			}
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		}
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

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
	maxDamage = 3.0;
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
