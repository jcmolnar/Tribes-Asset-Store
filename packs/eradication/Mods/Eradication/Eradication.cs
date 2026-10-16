// Eradication 1.4 by Dissident (August 2000, for Tribes 1.11). Entry script for the Modern
// Tribes client (1.50).
//
// The 2000 release was started with
//     Tribes.exe -mod eradication [-dedicated]                        (eradication.doc)
// and the loader of that time ran this file, eradication\eradication.cs, the server settings
// ("eradicationServerCfg.cs" in its own header). Under 1.50 the launch is  -mod Eradication
// and the loader runs Mods\Eradication\Eradication.cs before the server is created.
// Everything below this header is the release's file, byte for byte. A value left blank takes
// the default that scripts\globalvalues.cs sets when the server starts.
//
// PORT note: the release also had a client script (config\Dissident\eradicationCFG.cs) that
// bound G to "use sensor" and E to "throw mine". It is not part of this pack; mines, grenades
// and sensors are in their own inventory slots and can be used from the inventory screen.
echo("Eradication 1.4 (Dissident) -- 1.50 port entry");
//-------------------------------------------------------------------------------
//  eradicationServerCfg.cs
//  


//-------------------------------------------------------------------------------
//  the SpawnWith Globals define the initial load-out of each player after they
//  are spawned. Leave these blank to use the default values. Make sure the last
//  entry has a blank value.
 
$Eradication::SpawnWith[0] = "";
$Eradication::SpawnWith[1] = "";
$Eradication::SpawnWith[2] = "";
$Eradication::SpawnWith[3] = "";
$Eradication::SpawnWith[4] = "";
$Eradication::SpawnWith[5] = "";
$Eradication::SpawnWith[6] = "";

//-------------------------------------------------------------------------------
//  leaveMissionAreaResult can have two values: "Catapult" and "Kill". Catapult will
//  send the player flying back towards their base, Kill will blow the player up.
//  Catapult is the default value. Set this value to false to disable the default value.
//
//  leaveMissionAreaTime is an integer value of 2 second intervals that the player
//  is allowed outside the Mission Area before the leaveMissionAreaResult happens.

$Eradication::leaveMissionAreaResult = "";
$Eradication::leaveMissionAreaTime = "";

//-------------------------------------------------------------------------------
//  repairGunAutoRemount defines whether the players last weapon should be 
//  autoremounted after using the repair gun. can be somewhat obnoxious.

$Eradication::repairGunAutoRemount = false;

//-------------------------------------------------------------------------------
//  noAmmoNextWeapon defines whether to mount the next available weapon when the 
//  player runs out of ammo. there is a non-fatal bug with this when a player dies 
//  or drops while they are running out of ammo.

$Eradication::noAmmoNextWeapon = false;

//-------------------------------------------------------------------------------
// showDeathMessages toggles the system broadcast of death messages after each
// kill. set to false to disable the death messages.

$Eradication::showDeathMessages = true;

//-------------------------------------------------------------------------------
// showBroadcastScore toggles the system broadcast of scores and killDeath ratios
// after each kill. set to false to disable score messages.

$Eradication::showBroadcastScore = true;

//-------------------------------------------------------------------------------
// showDestructionMessages toggles the system broadcast of item destruction messages
// after items have been destroyed. set to false to disable the desctuction messages.

$Eradication::showDestructionMessages = true;

//-------------------------------------------------------------------------------
// stationKick toggles whether the system will kick players from inventory stations.
// stationKickTime is the amount of time in seconds before the player gets the 5 
// second kick warning. default value is 10 seconds.

$Eradication::stationKick = false;
$Eradication::stationKickTime = "";

//-------------------------------------------------------------------------------
// tkBan toggles whether the server should ban players for TK'ing.
// tkWarningLimit is the number of TK's before the player is warned about TK banning.
// tkBanLimit is the number of TK's before the player is banned from the game.

$Eradication::tkBan = true;
$Eradication::tkWarningLimit = "";
$Eradication::tkBanLimit = "";

//-------------------------------------------------------------------------------
// deflagDisarm toggles whether player Deflagging or Disarming should occur during
// enemy player collisions.

$Eradication::deflagDisarm = true;

//-------------------------------------------------------------------------------
// eradicationTurrets toggles whether the extra turrets are available in the game.
// disabling eradicationTurrets leaves only the AutoPlasma turrets available (8 per
// team), just like in base.

$Eradication::eradicationTurrets = true;

// time in seconds before the flag returns to the stand after being dropped
$Eradication::flagToStandTime = "";	  
// time in seconds for items to respawn
$Eradication::ItemRespawnTime = "";
// amount of energy in deployable ammo stations when they are bought
$Eradication::RemoteAmmoEnergy = ""; 
// amount of energy in deployable inventory stations when they are bought
$Eradication::RemoteInvEnergy = "";
// whether players will automatically respawn after death
$Eradication::AutoRespawn = "";
// amount of team energy each team starts with by default. default value is infinite 
$Eradication::DefaultTeamEnergy = "";
// max amount of team energy allowed per team
$Eradication::MaxTeamEnergy = "";

//---------------------------------------------------------------------------------
// Item Max Global Variables
// these variables define the maximum number of each item type that is allowed per
// team. Leave values blank for default settings
//---------------------------------------------------------------------------------

$Eradication::TeamItemMax[DeployableInvPack] = "";
$Eradication::TeamItemMax[DeployableAmmoPack] = "";
$Eradication::TeamItemMax[BarrierPack] = "";
$Eradication::TeamItemMax[StackableCratePack] = "";
$Eradication::TeamItemMax[SuspendedPlatformPack] = "";
$Eradication::TeamItemMax[LargeDecoyTurretPack] = "";
$Eradication::TeamItemMax[MediumDecoyTurretPack] = "";
$Eradication::TeamItemMax[SmallDecoyTurretPack] = "";
$Eradication::TeamItemMax[AutoPlasmaTurretPack] = "";
$Eradication::TeamItemMax[BlasterTurretPack] = "";
$Eradication::TeamItemMax[ChaingunTurretPack] = "";
$Eradication::TeamItemMax[DiscTurretPack] = "";
$Eradication::TeamItemMax[FusionTurretPack] = "";
$Eradication::TeamItemMax[GrenadeTurretPack] = "";
$Eradication::TeamItemMax[LaserTurretPack] = "";
$Eradication::TeamItemMax[EnergyVortexPack] = "";
$Eradication::TeamItemMax[EnergyFieldGeneratorPack] = "";
$Eradication::TeamItemMax[CameraPack] = "";
$Eradication::TeamItemMax[DeployableSensorJammerPack] = "";
$Eradication::TeamItemMax[MotionSensorPack] = "";
$Eradication::TeamItemMax[PulseSensorPack] = "";
$Eradication::TeamItemMax[Beacon] = "";
$Eradication::TeamItemMax[MineAmmo] = "";
$Eradication::TeamItemMax[LightArmor] = "";
$Eradication::TeamItemMax[MediumArmor] = "";
$Eradication::TeamItemMax[HeavyArmor] = "";
$Eradication::TeamItemMax[CommandArmor] = "";
$Eradication::TeamItemMax[SupportArmor] = "";
$Eradication::TeamItemMax[ScoutVehicle] = "";
$Eradication::TeamItemMax[HAPCVehicle] = "";
$Eradication::TeamItemMax[LAPCVehicle] = "";

//---------------------------------------------------------------------------------
// Item Enabled Global Variables
// these variables define whether each item type is enabled at the inventory station.
// these values must be set to false for the items to be disabled. 
//---------------------------------------------------------------------------------

$Eradication::ItemEnabled[Blaster] = true;
$Eradication::ItemEnabled[SniperRifle] = true;
$Eradication::ItemEnabled[LaserRifle] = true;
$Eradication::ItemEnabled[PlasmaGun] = true;
$Eradication::ItemEnabled[PlasmaShotgun] = true;
$Eradication::ItemEnabled[Lamprey] = true;
$Eradication::ItemEnabled[AutoBlaster] = true;
$Eradication::ItemEnabled[EnergyRifle] = true;
$Eradication::ItemEnabled[Shotgun] = true;
$Eradication::ItemEnabled[DiscLauncher] = true;
$Eradication::ItemEnabled[SballLauncher] = true;
$Eradication::ItemEnabled[GrenadeLauncher] = true;
$Eradication::ItemEnabled[Chaingun] = true;
$Eradication::ItemEnabled[Mortar] = true;
$Eradication::ItemEnabled[MultiGrenadeLauncher] = true;
$Eradication::ItemEnabled[Howitzer] = true;
$Eradication::ItemEnabled[RepulsorGun] = true;
$Eradication::ItemEnabled[TargetingLaser] = true;
$Eradication::ItemEnabled[RepairPack] = true;
$Eradication::ItemEnabled[AssaultPack] = true;
$Eradication::ItemEnabled[DefenderPack] = true;
$Eradication::ItemEnabled[ScoutPack] = true;
$Eradication::ItemEnabled[SniperPack] = true;
$Eradication::ItemEnabled[StealthPack] = true;
$Eradication::ItemEnabled[MinelayerPack] = true;
$Eradication::ItemEnabled[RepulsorPack] = true;
$Eradication::ItemEnabled[CommanderPack] = true;
$Eradication::ItemEnabled[RepairKit] = true;
$Eradication::ItemEnabled[CameraPack] = true;
$Eradication::ItemEnabled[DeployableSensorJammerPack] = true;
$Eradication::ItemEnabled[MotionSensorPack] = true;
$Eradication::ItemEnabled[PulseSensorPack] = true;
$Eradication::ItemEnabled[Beacon] = true;
$Eradication::ItemEnabled[MineAmmo] = true;
$Eradication::ItemEnabled[Grenade] = true;
$Eradication::ItemEnabled[FlashGrenade] = true;
$Eradication::ItemEnabled[VortexGrenade] = true;
$Eradication::ItemEnabled[StickyBomb] = true;
$Eradication::ItemEnabled[DeployableInvPack] = true;
$Eradication::ItemEnabled[DeployableAmmoPack] = true;
$Eradication::ItemEnabled[BarrierPack] = true;
$Eradication::ItemEnabled[StackableCratePack] = true;
$Eradication::ItemEnabled[SuspendedPlatformPack] = true;
$Eradication::ItemEnabled[LargeDecoyTurretPack] = true;
$Eradication::ItemEnabled[MediumDecoyTurretPack] = true;
$Eradication::ItemEnabled[SmallDecoyTurretPack] = true;
$Eradication::ItemEnabled[AutoPlasmaTurretPack] = true;
$Eradication::ItemEnabled[BlasterTurretPack] = true;
$Eradication::ItemEnabled[ChaingunTurretPack] = true;
$Eradication::ItemEnabled[DiscTurretPack] = true;
$Eradication::ItemEnabled[FusionTurretPack] = true;
$Eradication::ItemEnabled[GrenadeTurretPack] = true;
$Eradication::ItemEnabled[LaserTurretPack] = true;
$Eradication::ItemEnabled[EnergyVortexPack] = true;
$Eradication::ItemEnabled[EnergyFieldGeneratorPack] = true;

//---------------------------------------------------------------------------------
// Armor Global Variables
// these variables define the maximum number of weapons that can be carried
// by each armor type. leave blank for default values.
//---------------------------------------------------------------------------------

$Eradication::MaxWeapons[larmor] = "";
$Eradication::MaxWeapons[lfemale] = "";
$Eradication::MaxWeapons[marmor] = "";
$Eradication::MaxWeapons[mfemale] = "";
$Eradication::MaxWeapons[harmor] = "";
$Eradication::MaxWeapons[carmor] = "";
$Eradication::MaxWeapons[sarmor] = "";


