
function normalm(){

$InvList[HeatSink] = 0;
$RemoteInvList[HeatSink] = 0;

$InvList[Flagger] = 1;
$RemoteInvList[Flagger] = 1;

$InvList[Hider] = 1;
$RemoteInvList[Hider] = 1;

$InvList[Smoker] = 0;
$RemoteInvList[Smoker] = 0;

$InvList[torch] = 1;
$RemoteInvList[torch] = 1;

$InvList[thrower] = 1;
$RemoteInvList[thrower] = 1;

$InvList[plangun] = 1;
$RemoteInvList[plangun] = 1;

$InvList[encan] = 1;
$RemoteInvList[encan] = 1;

$InvList[rockatAmmo] = 1;
$RemoteInvList[rockatAmmo] = 1;

$InvList[napalmfire] = 1;
$RemoteInvList[napalmfire] = 1;

$InvList[fireammo] = 1;
$RemoteInvList[fireammo] = 1;

$InvList[signammo] = 1;
$RemoteInvList[signammo] = 1;

$InvList[sector] = 1;
$RemoteInvList[sector] = 1;

$InvList[lavamos] = 1;
$RemoteInvList[lavamos] = 1;

$InvList[chainammo] = 1;
$RemoteInvList[chainammo] = 1;

$InvList[repLauncher] = 1;
$RemoteInvList[repLauncher] = 1;

$InvList[repAmmo] = 1;
$RemoteInvList[repAmmo] = 1;

$InvList[moondustlauncher] = 1;
$RemoteInvList[moondustlauncher] = 1;

$InvList[poly] = 1;
$RemoteInvList[poly] = 1;

$InvList[bio] = 1;
$RemoteInvList[bio] = 1;

$InvList[bioammo] = 1;
$RemoteInvList[bioammo] = 1;

$InvList[twig] = 1;
$RemoteInvList[twig] = 1;

$InvList[Tpack] = 1;
$RemoteInvList[tPack] = 1;

$InvList[Tbeac] = 1;
$RemoteInvList[tBeac] = 1;
 
$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;

$InvList[TTurretPack] = 0;
$RemoteInvList[TTurretPack] = 0;

$InvList[vaporammo] = 1;
$RemoteInvList[vaporammo] = 1;

$InvList[Ba] = 1;
$RemoteInvList[BA] = 1;

$InvList[girl] = 1;
$RemoteInvList[Girl] = 1;

$RemoteInvList[TractorBeam] = 1;
$InvList[Blaster] = 1;
$InvList[Chaingun] = 1;
$InvList[Disclauncher] = 1;
$InvList[RocketLauncher] = 0;
$InvList[EMPGrenadeLauncher] = 1;
 $InvList[Boost] = 1;
 $InvList[Mortar] = 1;
 $InvList[PlasmaGun] = 1;
 $InvList[plasflam] = 1;
 $InvList[LaserRifle] = 1;
 $InvList[MineAmmo] = 1;
 $InvList[sniperAmmo] = 1;
 $InvList[throwerAmmo] = 1;
 $InvList[rocketAmmo] = 0;
 $InvList[Grenade] = 1;
 $InvList[Beacon] = 1;
 $InvList[BulletAmmo] = 1;
$InvList[Shotgun] = 1;
$InvList[SniperRifle] = 1;
$InvList[tase] = 1; 
$InvList[PlasmaAmmo] = 1;
$InvList[DiscAmmo] = 1;
 $InvList[EnergyPack] = 1;
 $InvList[RepairPack] = 1;
 $InvList[ShieldPack] = 1;
 $InvList[SensorJammerPack] = 1;
 $InvList[MotionSensorPack] = 1;
 $InvList[PulseSensorPack] = 1;
 $InvList[DeployableSensorJammerPack] = 1;
 $InvList[CameraPack] = 1;
 $InvList[AmmoPack] = 1;
 $InvList[RepairKit] = 1;
 $InvList[DeployableInvPack] = 1;
 $InvList[DeployableAmmoPack] = 1;
 $InvList[WaveGun] = 1;
 $InvList[Railgun] = 0;
 $InvList[Flamer] = 1;
 $InvList[TranqGun] = 0;
 $InvList[Fixit] = 0;
 $InvList[RailAmmo] = 1;
 $InvList[TranqAmmo] = 1;
 $InvList[DeployableComPack] = 1;
 $InvList[Laptop] = 0;
 $InvList[TargetPack] = 0;
 $InvList[SuicidePack] = 0;
 $InvList[DetPack] = 0;
$InvList[ShotgunShells] = 1; 
 $InvList[TeleportPack] = 0;
 $InvList[TripwirePack] = 0;
 $InvList[RegenerationPack] = 0;
 $InvList[WatchdogPack] = 1;
 $InvList[LightningPack] = 0;
 $InvList[SpringPack] = 0;
 $InvList[ShockPack] = 0;
  $InvList[PlasmaPack] = 1;
 $InvList[OpticPack] = 0;
 $InvList[SMRPack] = 0;
if(!$HaVoC::TurretsDisabled) {
 $RemoteInvList[ShockPack] = 0;
 $RemoteInvList[TurretPack] = 0;
$RemoteInvList[PlasmaPack] = 1;
$InvList[PlasmaPack] = 1;
 $InvList[ShockPack] = 0;
 $InvList[TurretPack] = 0;
} else {
 $RemoteInvList[ShockPack] = 0;
 $RemoteInvList[TurretPack] = 0;
 $InvList[TurretPack] = 0;
$RemoteInvList[WatchdogPack] = 1;
$RemoteInvList[PlasmaPack] = 1;
$RemoteInvList[ElfPack] = 1; 
$InvList[ElfPack] = 1;
$InvList[PlasmaPack] = 1;
 $InvList[ShockPack] = 0;
}
 
$RemoteInvList[TractorBeam] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[Blaster] = 1;
$RemoteInvList[ShotgunShells] = 1;
$RemoteInvList[plasflam] = 1; 
$RemoteInvList[Chaingun] = 1;
 $RemoteInvList[Disclauncher] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[tase] = 1;
$RemoteInvList[LaserRifle] = 1;
 $RemoteInvList[MineAmmo] = 1;
 $RemoteInvList[Grenade] = 1;
 $RemoteInvList[Beacon] = 1;
 $RemoteInvList[Boost] = 1;
 $RemoteInvList[BulletAmmo] = 1;
$RemoteInvList[PlasmaAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;
 $RemoteInvList[EnergyPack] = 1;
 $RemoteInvList[RepairPack] = 1;
 $RemoteInvList[ShieldPack] = 1;
 $RemoteInvList[SensorJammerPack] = 1;
 $RemoteInvList[MotionSensorPack] = 1;
 $RemoteInvList[PulseSensorPack] = 1;
 $RemoteInvList[DeployableSensorJammerPack] = 1;
 $RemoteInvList[CameraPack] = 1;
 

 $RemoteInvList[AmmoPack] = 1;
 $RemoteInvList[RepairKit] = 1;
 $RemoteInvList[RocketLauncher] = 0;
 $RemoteInvList[SniperRifle] = 1;
 $RemoteInvList[WaveGun] = 1;
 $RemoteInvList[Railgun] = 0;
 $RemoteInvList[Flamer] = 1;
 $RemoteInvList[TranqGun] = 0;
 $RemoteInvList[Fixit] = 0;
 $RemoteInvList[RocketAmmo] = 0;
 $RemoteInvList[SniperAmmo] = 0;
 $RemoteInvList[RailAmmo] = 1;
 $RemoteInvList[SilencerAmmo] = 1;
 $RemoteInvList[TranqAmmo] = 1;
 $RemoteInvList[DeployableComPack] = 0;
 $RemoteInvList[ForceFieldPack] = 0;
 $RemoteInvList[LargeForceFieldPack] = 0;
 $RemoteInvList[CloakingDevice] = 1;
 $RemoteInvList[Laptop] = 0;
 $RemoteInvList[TargetPack] = 0;
 $RemoteInvList[SuicidePack] = 1;
 $RemoteInvList[DetPack] = 0;
 $RemoteInvList[TeleportPack] = 1;
 $RemoteInvList[FgcPack] = 0;
 $RemoteInvList[MechPack] = 1;
 $RemoteInvList[HoloPack] = 1;
 $RemoteInvList[RegenerationPack] = 0;
 $RemoteInvList[SpringPack] = 0;
 $RemoteInvList[OpticPack] = 0;
 $RemoteInvList[SMRPack] = 0;
 }
  
 $VehicleInvList[ScoutVehicle] = 1;
 $VehicleInvList[ChaneVehicle] = 1;
 $VehicleInvList[LAPCVehicle] = 1;
 $VehicleInvList[HAPCVehicle] = 1;
 $DataBlockName[ScoutVehicle] = Scout;
 $DataBlockName[ChaneVehicle] = Chane;
 $DataBlockName[LAPCVehicle] = LAPC;
 $DataBlockName[HAPCVehicle] = HAPC;
 $VehicleToItem[Scout] = ScoutVehicle;
 $VehicleToItem[Chane] = ChaneVehicle;
 $VehicleToItem[LAPC] = LAPCVehicle;
 $VehicleToItem[HAPC] = HAPCVehicle;

normalm(); 
function Station::onActivate(%this) { 
	%obj = Station::getTarget(%this); 
	if (%obj != -1) { 
		GameBase::playSequence(%this,1,"activate"); 
		%this.lastPlayer = %obj; 
		%obj.inStation = %this; 
		if(Player::getItemCount(%obj, SMRPack) > 0 || Player::getItemCount(%obj, OpticPack) > 0)
			Player::trigger(%obj,$BackpackSlot,false);
		GameBase::setSequenceDirection(%this,1,1); 

		if($HaVoC::StationTime) { 
			if($HaVoC::StationTime < 10) $HaVoC::StationTime = 10; 
				else if($HaVoC::StationTime > 60) 
					$HaVoC::StationTime = 60; 
			%dName = GameBase::getdataName(%this); 
			if(%dName == InventoryStation) {
            if(!$Server::TourneyMode)
   				ixCheckStationEject(%obj,%this,($HaVoC::StationTime / 5)); 
            else
   				ixCheckStationEject(%obj,%this,4); 
         }
		} 
	} else GameBase::setActive(%this,false); 
} 

function Station::onDeactivate(%this) { GameBase::stopSequence(%this,2); GameBase::setSequenceDirection(%this,1,0); %obj = %this.lastPlayer; if(%this == %obj.inStation) %obj.inStation = false; } 

function ixCheckStationEject(%player, %station, %count) { 
	if($HaVoC::StationTime) { 
		if((%player.inStation) && (%player.inStation == %station) && (%player == Station::getTarget(%player.inStation))) { if(%count) { if(%count == 1) Client::sendMessage(GameBase::getOwnerClient(%player),1,"You will be ejected from the station in 5 seconds.~waccess_denied.wav"); schedule("ixCheckStationEject(" @ %player @ "," @ %station @ "," @ %count - 1 @ ");",5,%player); } else { Client::sendMessage(GameBase::getOwnerClient(%player),1,"You have been ejected so others may have access.~waccess_denied.wav"); ixStationEjectPlayer(%station, %player); } 
		} else {
			%count = 0;
		}
	} 
} 

function ixStationEjectPlayer(%station, %player) { %rot = GameBase::getRotation(%station); %rad = getWord(%rot, 2); %x = (-1) * (ixSin(%rad)); %y = ixCos(%rad); %dir = %x @ " " @ %y @ " 0"; %force = ixDotProd(Vector::neg(%dir),10); %x = getWord(%force, 0); %y = getWord(%force, 1); %vel = %x @ " " @ %y @ " " @ 15; Item::setVelocity(%player,%vel); } 

function Station::onEndSequence(%this,%thread)
{
	
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
		// PORT (same guard as the 1.50 base station.cs): lastPlayer is a bare object id; touching a
		// field on a reused id faults the engine.
		if(getObjectType(%player) != "Player") {
			%this.lastPlayer = "";
			return;
		}
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
					if (GameBase::isPowered(%this) || %this.freeP || GameBase::getDataName(%this) == "DeployableComStation") { 
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
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Not Authorized as team member ~waccess_denied.wav");
				}
			}
		}
	}
}

function Station::itemsToResupply(%player) { %cnt = 0; %cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1); 

%cnt = %cnt + AmmoStation::resupply(%player,IXRocketLauncher,RocketAmmo,2);

%cnt = %cnt + AmmoStation::resupply(%player,Shotgun,ShotgunShells,5); 

%cnt = %cnt + AmmoStation::resupply(%player,EMPGrenadeLauncher,EMPGrenadeAmmo,2);

%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2); 

%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1); 

if($Game::missionType != "Arena")
	%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,1); 
%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,1); 

%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20); %cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5); %cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2); 
%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2); 
%cnt = %cnt + AmmoStation::resupply(%player,HDiscLauncher,HDiscAmmo,2);
%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2); %cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,1); %cnt = %cnt + AmmoStation::resupply(%player,SMRPack,RocketAmmo,1); %cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5); %cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,2); %cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5); %cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5); return %cnt; } 

function DeployableStation::onActivate(%this)
{
	
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

$vm[NapM] = NapProj;

function DeployableStation::onDeactivate(%this)
{
	
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

function DeployableStation::onCollision(%this, %object) { 
	%obj = getObjectType(%object); 
	if (%obj == "Player") { 
		%client = Player::getClient(%object); 
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) { 
			if (GameBase::getDamageState(%this) == "Enabled") { 
				%data = GameBase::getDataName(%this);

				if (%data.description == "Missile Control Station") {
					if(GameBase::getDamageState(%this.comstation) == "Enabled") {
						schedule("CoolStationCheck(" @ %this @ ", " @ %object @ ");",0.5,%this); 
						return; 
					} else {
						Client::sendMessage(%client,0,"Turret is damaged.~waccess_denied.wav");
					}
					return;
				}

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

StaticShapeData AmmoStation { description = "Ammo Supply Unit"; shapeFile = "ammounit"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateAmmoStation }; sequenceSound[1] = { "power", SoundAmmoStationPower }; sequenceSound[2] = { "use", SoundUseAmmoStation }; maxDamage = 2.5; debrisId = flashDebrisLarge; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpLarge; }; 

function AmmoStation::onEndSequence(%this,%thread)
{
	
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
			Client::sendMessage(%client,0,"Resupply Complete");
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
		else if(getObjectType(%this.lastPlayer) == "Player") {
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
			GameBase::repairDamage(%player,0.07);
		 	return %delta;
		}
		else if (%item == MineAmmo || %item == Grenade || %item == RepairKit || %item == Beacon) {
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

StaticShapeData DeployableAmmoStation { description = "Remote Ammo Unit"; shapeFile = "ammounit_remote"; className = "DeployableStation"; maxDamage = 0.25; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; sequenceSound[1] = { "use", SoundUseAmmoStation }; sequenceSound[2] = { "power", SoundAmmoStationPower }; visibleToSensor = true; shadowDetailMask = 4; castLOS = true; supression = false; supressable = false; mapFilter = 4; mapIcon = "M_station"; debrisId = flashDebrisSmall; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; }; 

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

StaticShapeData DeployableInvStation { description = "Remote Inv Unit"; shapeFile = "invent_remote"; className = "DeployableStation"; maxDamage = 0.5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; sequenceSound[1] = { "use", SoundUseAmmoStation }; sequenceSound[2] = { "power", SoundInventoryStationPower }; visibleToSensor = true; shadowDetailMask = 4; castLOS = true; supression = false; supressable = false; mapFilter = 4; mapIcon = "M_station"; debrisId = flashDebrisMedium; damageSkinData = "objectDamageSkins"; explosionId = flashExpSmall; }; 

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
		
 		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}

StaticShapeData InventoryStation { description = "Station Supply Unit"; shapeFile = "inventory_sta"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateInventoryStation }; sequenceSound[1] = { "power", SoundInventoryStationPower }; sequenceSound[2] = { "use", SoundUseInventoryStation }; maxDamage = 1.45; debrisId = flashDebrisLarge; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; triggerRadius = 1.5; explosionId = flashExpLarge; }; 

function InventoryStation::onEndSequence(%this,%thread)
{
	
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
			if(%client.poisonTime > 0) %client.poisonTime = -10;
			if (%this.target != %client) {
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
            if(!%client.noEnterInventory)
   				Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
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

function setupShoppingList(%client,%station,%ListType)
{
	%max = getNumItems();
	if(%ListType == "InvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				if($Game::missionType != "DMTEAM" && $Game::missionType != "DM" && $Game::missionType != "Hunter" && $Game::missionType != "Rabbit")
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
				%extraAmmo = $AmmoPackMax[%armor, %item];
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))	{
				if(%energy >= %item.price ) {
					if(%item.className == Weapon) {
						if(Player::getItemCount(%client,"OpticPack")) %w = 1; else %w = 0;
						if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor] - %w)					
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
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i) && %client.poisonTime == 0) {
			if($Game::missionType != "DMTEAM" && $Game::missionType != "DM" && $Game::missionType != "Hunter" && $Game::missionType != "Rabbit") 
				Client::setItemBuying(%client, %item);
		} else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
			Client::setItemBuying(%client, %item);
	}
}


StaticShapeData CommandStation { description = "Command Station"; shapeFile = "cmdpnl"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateCommandStation }; sequenceSound[1] = { "power", SoundCommandStationPower }; sequenceSound[2] = { "use", SoundUseCommandStation }; maxDamage = 1.0; debrisId = flashDebrisMedium; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; triggerRadius = 1.5; explosionId = flashExpLarge; }; 

function CommandStation::onEndSequence(%this,%thread)
{
	
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
				%client.atcom = true;
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
		%pl = Client::getOwnedObject(%this.target);
		(%this.target).atcom = false;
		schedule((%pl)@".CommandTag = \"\";", 5);
		%pl.noCom = true;
		schedule((%pl)@".noCom = \"\";", 7);
		checkControlUnmount(%this.target);
	}
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
}

StaticShapeData DeployableComStation { description = "Remote Command Station"; shapeFile = "cmdpnl"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateCommandStation }; sequenceSound[1] = { "power", SoundCommandStationPower }; sequenceSound[2] = { "use", SoundUseCommandStation }; maxDamage = 1.0; debrisId = flashDebrisMedium; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; triggerRadius = 1.5; explosionId = flashExpLarge; }; 

function DeployableComStation::onAdd(%this) { schedule("DeployableStation::deploy(" @ %this @ ");",1,%this); if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "R-Com Station"); %this.Energy = 3000; } 

function DeployableComStation::onEndSequence(%this,%thread)
{
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
	if (Station::onEndSequence(%this,%thread)) 
		DeployableComStation::onResupply(%this);
}

function DeployableComStation::onResupply(%this) { 
	if (GameBase::isActive(%this)) { 
		%player = Station::getTarget(%this); 
		if (%player != -1) { 
			%client = Player::getClient(%player); 
			if (%this.target != %client) { 
				%this.target = %client; 
				%player.CommandTag = 1; 
				%client.atcom = true; 
				Client::setGuiMode(%client,2); 
				Client::sendMessage(%client,0,"Command Access On"); 
				%player.station = %this;
			} 
			schedule("DeployableComStation::onResupply(" @ %this @ ");",0.5,%this); 
			return; 
		} 
		GameBase::setActive(%this,false); 
	} 
	if (%this.target) { 
		Client::sendMessage(%this.target,0,"Command Access Off");
		%pl = Client::getOwnedObject(%this.target);
		(%this.target).atcom = false;
		schedule((%pl)@".CommandTag = \"\";", 5);
		%pl.noCom = true;
		schedule((%pl)@".noCom = \"\";", 7);
		checkControlUnmount(%this.target);
	} 
	(Client::getOwnedObject(%this.target)).Station = ""; 
	%this.target = ""; 
} 



StaticShapeData DeployableCoolStation { description = "Missile Control Station"; shapeFile = "cmdpnl"; className = "DeployableStation"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateCommandStation }; sequenceSound[1] = { "power", SoundCommandStationPower }; sequenceSound[2] = { "use", SoundUseCommandStation }; maxDamage = 2.0; debrisId = flashDebrisMedium; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; castLOS = true; supression = false; supressable = false; explosionId = flashExpLarge; collisionRadius=2;}; 

function DeployableCoolStation::onAdd(%this) { schedule("DeployableStation::deploy(" @ %this @ ");",1,%this); if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Missile Control Station"); %this.Energy = 3000; 			
} 

function DeployableCoolStation::onDestroyed(%this) {
%turret = %this.comstation;
%data = GameBase::getDataName(%turret);
GameBase::setDamageLevel(%turret, %data.maxDamage);
$TeamItemCount[GameBase::getTeam(%player) @ "CoolLauncher"]--;
}

function DeployableCoolStation::OnActivate(%this) { 
}

StaticShapeData Dep1oyableCoolStation { description = "Missile Control Station"; shapeFile = "cmdpnl"; className = "DeployableStation"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateCommandStation }; sequenceSound[1] = { "power", SoundCommandStationPower }; sequenceSound[2] = { "use", SoundUseCommandStation }; maxDamage = 3.0; debrisId = flashDebrisMedium; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; castLOS = true; supression = false; supressable = false; explosionId = flashExpLarge; }; 

function Dep1oyableCoolStation::onAdd(%this) { schedule("DeployableStation::deploy(" @ %this @ ");",1,%this); if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Missile Control Station"); %this.Energy = 3000; 			
} 

function Dep1oyableCoolStation::onDestroyed(%this) {
%turret = %this.comstation;
%data = GameBase::getDataName(%turret);
GameBase::setDamageLevel(%turret, %data.maxDamage);
}

function Dep1oyableCoolStation::OnActivate(%this) { 
}

function CoolStationCheck(%this, %player) {
	%client = Player::getClient(%player);
	%c = Player::getMountedItem(%player, $BackpackSlot);
	if ((%this.comstation).load == "") {
		if (%c.heading == "uGuided Missile System" && %c != CoolLauncher) {
			%vm = $vm[%c];
			(%this.comstation).load = %vm;
			Player::setItemCount(%player, %c, 0);
			Client::sendMessage(%client,0,"Turret has been loaded with a "@%vm.description@".");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
		} else {
			if(Client::getControlObject(%client) == %player) {
				Client::sendMessage(%client,0,"Turret is not loaded.~waccess_denied.wav");
			}
		}
	} else {
		bottomprint(%client, "<jc>Press jump to fire.", 2);
		%pl = Client::getOwnedObject(%client);
		%pl.CommandTag = 1;
		Client::takeControl(%client, %this.comstation); 	
	}
}


StaticShapeData VehicleStation { description = "Station Vehicle Unit"; shapeFile = "vehi_pur_pnl"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateInventoryStation }; sequenceSound[1] = { "power", SoundInventoryStationPower }; sequenceSound[2] = { "use", SoundUseInventoryStation }; maxDamage = 1.0; maxEnergy = 100; debrisId = flashDebrisLarge; mapFilter = 4; mapIcon = "M_station"; damageSkinData = "objectDamageSkins"; shieldShapeName = "shield"; shadowDetailMask = 16; triggerRadius = 1.5; explosionId = flashExpLarge; }; 

function VehicleStation::onAdd(%this) {
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
}

function VehiclePad::onDisabled(%this) {
	GameBase::setRechargeRate(%this,0);
}

function VehiclePad::onEnabled(%this) {
	GameBase::setRechargeRate(%this,5);
}

function VehicleStation::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function VehicleStation::onEndSequence(%this,%thread)
{
	
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
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}

StaticShapeData VehiclePad { description = "Vehicle Pad"; shapeFile = "vehi_pur_poles"; className = "Station"; visibleToSensor = true; sequenceSound[0] = { "activate", SoundActivateInventoryStation }; sequenceSound[1] = { "power", SoundInventoryStationPower }; sequenceSound[2] = { "use", SoundUseInventoryStation }; maxDamage = 1.2; debrisId = flashDebrisLarge; maxEnergy = 150; mapFilter = 4; mapIcon = "M_station"; explosionId = flashExpLarge; damageSkinData = "objectDamageSkins"; shieldShapeName = "shield_medium"; }; 

function VehiclePad::onActivate(%this)
{
	GameBase::playSequence(%this,1,"use");
}

function VehiclePad::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function VehiclePad::onEnabled(%this) {
	GameBase::setRechargeRate(%this,5);
}

function VehiclePad::onDisabled(%this) {
	GameBase::setRechargeRate(%this,0);
}

function VehiclePad::onAdd(%this) {
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0175;
}

function VehiclePad::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
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

