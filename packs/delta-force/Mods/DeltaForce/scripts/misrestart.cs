// Reset all the custom variables specific to a map

$HuntedQueue = 0;
$Hunted = 0;
$Server::TourneyMode = "false";
$VIPText = "The VIP has escaped!";

for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
{
	for(%x = 0; %x < 3; %x++)
	{
		$Hostages[%i, %x] = 0;
	}
	$TakenHostages[%i] = 0;
}

$spawnBuyList[0] = InfantryArmor;
$spawnBuyList[1] = SOCOM;
$spawnBuyList[2] = OICW;
$spawnBuyList[3] = RepairKit;
$spawnBuyList[4] = "";

// List of all items available to buy from inventory station
$InvList[Blaster] = 0;
$InvList[Chaingun] = 0;
$InvList[Disclauncher] = 0;
$InvList[GrenadeLauncher] = 0;
$InvList[Mortar] = 0;
$InvList[PlasmaGun] = 0;
$InvList[LaserRifle] = 0;
$InvList[EnergyRifle] = 0;
$InvList[TargetingLaser] = 1;
$InvList[MineAmmo] = 1;
$InvList[Grenade] = 1;
$InvList[Beacon] = 1;
// DELTA FORCE
$InvList[SOCOM] = 1;
$InvList[OICW] = 1;
$InvList[SAW] = 1;
$InvList[MP5] = 1;
$InvList[PSG1] = 1;
$InvList[FiftyCal] = 1;
$InvList[LAW] = 1;
$InvList[Howitzer] = 0;
$InvList[Airstrike] = 0;
$InvList[GrappleHook] = 0;
$InvList[Minigun] = 0;
$InvList[AbramsGun] = 0;
$InvList[AutoShotgun] = 1;
$InvList[Stinger] = 1;
$InvList[Flamethrower] = 1;
// END DELTA FORCE

$InvList[BulletAmmo] = 0;
$InvList[PlasmaAmmo] = 0;
$InvList[DiscAmmo] = 0;
$InvList[GrenadeAmmo] = 0;
$InvList[MortarAmmo] = 0;
// DELTA FORCE
$InvList[SOCOMAmmo] = 1;
$InvList[OICWAmmo] = 1;
$InvList[SAWAmmo] = 1;
$InvList[MP5Ammo] = 1;
$InvList[PSG1Ammo] = 1;
$InvList[FiftyCalAmmo] = 1;
$InvList[LAWAmmo] = 1;
$InvList[HowitzerAmmo] = 0;
$InvList[AutoShotgunAmmo] = 1;
$InvList[StingerAmmo] = 1;
$InvList[FlameAmmo] = 1;
// END DELTA FORCE
  
$InvList[EnergyPack] = 0;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 0;
$InvList[SensorJammerPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[CameraPack] = 1;
$InvList[TurretPack] = 1;
$InvList[RepairKit] = 1;
$InvList[DeployableInvPack] = 1;
$InvList[DeployableAmmoPack] = 1;
$InvList[DeployableHealthPack] = 1;
// DELTA FORCE
$InvList[SAMPack] = 1;
$InvList[HowitzerPack] = 1;
$InvList[TwentyPack] = 1;
$InvList[Charge] = 1;
$InvList[AirstrikePack] = 1;
$InvList[ReloaderPack] = 1;
$InvList[GrapplePack] = 1;
$InvList[Parachute] = 1;
$InvList[FuelPack] = 1;
$InvList[PortGenPack] = 1;
$InvList[AAPack] = 1;
$InvList[AmmoPackSmall] = 1;
$InvList[AmmoPackHeavy] = 1;
$InvList[AmmoPackExp] = 1;
$InvList[MedicPack] = 1;
// END DELTA FORCE

//----------------------------------------------------------------------------

// List of all items available to buy from Remote Station
$RemoteInvList[Blaster] = 0;
$RemoteInvList[Chaingun] = 0;
$RemoteInvList[Disclauncher] = 0;
$RemoteInvList[GrenadeLauncher] = 0;
$RemoteInvList[Mortar] = 0;
$RemoteInvList[PlasmaGun] = 0;
$RemoteInvList[LaserRifle] = 0;
$RemoteInvList[EnergyRifle] = 0;
$RemoteInvList[TargetingLaser] = 1;
$RemoteInvList[MineAmmo] = 1;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[Beacon] = 1;
// DELTA FORCE
$RemoteInvList[SOCOM] = 1;
$RemoteInvList[OICW] = 1;
$RemoteInvList[SAW] = 1;
$RemoteInvList[MP5] = 1;
$RemoteInvList[PSG1] = 1;
$RemoteInvList[FiftyCal] = 1;
$RemoteInvList[LAW] = 1;
$RemoteInvList[Howitzer] = 0;
$RemoteInvList[Airstrike] = 0;
$RemoteInvList[GrappleHook] = 0;
$RemoteInvList[Minigun] = 0;
$RemoteInvList[AbramsGun] = 0;
$RemoteInvList[AutoShotgun] = 1;
$RemoteInvList[Stinger] = 1;
$RemoteInvList[Flamethrower] = 1;
// END DELTA FORCE

$RemoteInvList[BulletAmmo] = 0;
$RemoteInvList[PlasmaAmmo] = 0;
$RemoteInvList[DiscAmmo] = 0;
$RemoteInvList[GrenadeAmmo] = 0;
$RemoteInvList[MortarAmmo] = 0;
// DELTA FORCE
$RemoteInvList[SOCOMAmmo] = 1;
$RemoteInvList[OICWAmmo] = 1;
$RemoteInvList[SAWAmmo] = 1;
$RemoteInvList[MP5Ammo] = 1;
$RemoteInvList[PSG1Ammo] = 1;
$RemoteInvList[FiftyCalAmmo] = 1;
$RemoteInvList[LAWAmmo] = 1;
$RemoteInvList[HowitzerAmmo] = 0;
$RemoteInvList[AutoShotgunAmmo] = 1;
$RemoteInvList[StingerAmmo] = 1;
$RemoteInvList[FlameAmmo] = 1;
// END DELTA FORCE
  
$RemoteInvList[EnergyPack] = 0;
$RemoteInvList[RepairPack] = 1;
$RemoteInvList[ShieldPack] = 0;
$RemoteInvList[SensorJammerPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[CameraPack] = 1;
$RemoteInvList[TurretPack] = 1;
$RemoteInvList[RepairKit] = 1;
// DELTA FORCE
$RemoteInvList[DeployableHealthPack] = 0;
$RemoteInvList[SAMPack] = 0;
$RemoteInvList[HowitzerPack] = 0;
$RemoteInvList[TwentyPack] = 0;
$RemoteInvList[Charge] = 1;
$RemoteInvList[AirstrikePack] = 0;
$RemoteInvList[ReloaderPack] = 1;
$RemoteInvList[GrapplePack] = 0;
$RemoteInvList[Parachute] = 0;
$RemoteInvList[FuelPack] = 1;
$RemoteInvList[PortGenPack] = 1;
$RemoteInvList[AAPack] = 0;
$RemoteInvList[AmmoPackSmall] = 1;
$RemoteInvList[AmmoPackHeavy] = 1;
$RemoteInvList[AmmoPackExp] = 1;
$RemoteInvList[MedicPack] = 1;
// END DELTA FORCE

//----------------------------------------------------------------------------

// List of all items available to buy from Vehicle station
// DELTA FORCE
$VehicleInvList[ApacheVehicle] = 1;
$VehicleInvList[WarthogVehicle] = 1;
$VehicleInvList[BlackhawkVehicle] = 1;
$VehicleInvList[HumveeVehicle] = 1;
$VehicleInvList[AbramsVehicle] = 1;
$VehicleInvList[BradleyVehicle] = 1;
// END DELTA FORCE

//----------------------------------------------------------------------------

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;
// DELTA FORCE
$TeamItemMax[DeployableHealthPack] = 5;
$TeamItemMax[ReloaderPack] = 5;
$TeamItemMax[PortGenPack] = 3;
$TeamItemMax[AirstrikePack] = 4;
$TeamItemMax[GrapplePack] = 5;
$TeamItemMax[SAMPack] = 4;
$TeamItemMax[HowitzerPack] = 3;
$TeamItemMax[AAPack] = 2;
$TeamItemMax[TwentyPack] = 3;
$TeamItemMax[ApacheVehicle] = 3;
$TeamItemMax[WarthogVehicle] = 2;
$TeamItemMax[BlackhawkVehicle] = 2;
$TeamItemMax[HumveeVehicle] = 3;
$TeamItemMax[AbramsVehicle] = 3;
$TeamItemMax[BradleyVehicle] = 3;
$TeamItemMax[Charge] = 3;
// END DELTA FORCE

function Flag::onDrop(%player, %type)
{
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);

   if(%flagTeam == -1)
   {
      MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
      Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
   }
   else
   {
      MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
      Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
      TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
   }
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);

   schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
   ObjectiveMission::ObjectiveChanged(%flag);
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
	   // DELTAFORCE
	   if($Game::missionType == "Assassination") {
		   if($Hunted == %clientId) {
			   if (%i == 2) %i++;
		   }
	   }
	   // END DELTAFORCE
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}
}

function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		if(%count > 0) {
		  	Client::sendMessage(Player::getClient(%player),0,"~wLeftMissionArea.wav");
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%player);
		}
		else { 
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  			GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
		}
	}
}

SensorData MediumPulseSensor
{
   description = "Medium Radar Tower";
   shapeFile = "sensor_pulse_med";
//   explosionId = DebrisExp;
   maxDamage = 1.0;
   range = 250;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = SAWBullet;
	maxDamage = 1.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMortarTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Machine Gun";

};

function AI::setWeapons(%aiName)
{
	%aiId = AI::getId(%aiName);
	
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      //Player::setItemCount(%aiId, SOCOM, 1);
   }
   // DELTAFORCE
   else if(Game::missionType == "Hostage") {
	dbecho(2, "Hostages are unarmed.");
   }
   // END DELTAFORCE
   else
   {
      //dbecho(2, "giving normal weapon select...");
      //Player::setItemCount(%aiId, SOCOM, 1);
	  // Player::setItemCount(%aiId, OICW, 1);
	  // Player::setItemCount(%aiId, OICWAmmo, 200);
   }

   // Player::mountItem(%aiId, SOCOM, 0);
   AI::SetVar(%aiName, triggerPct, 0.03 );
   AI::setVar(%aiName, iq, 70 );
   AI::setVar(%aiName, attackMode, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

