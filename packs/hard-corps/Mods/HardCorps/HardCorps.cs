// HARD CORPS V1.5 FINAL by Warpath (warpath@strategyplanet.com), April 2000
// Entry script for the Modern Tribes client (1.50).
//
// The 2000 release was started with
//     tribes.exe -mod hardcorps +exec hardcorps.cs          (Hard Corps.bat, Hard Corps.txt)
// where config\hardcorps.cs held every server setting of the mod. Under 1.50 the launch is
//     -mod HardCorps
// and the loader runs this file (Mods\HardCorps\HardCorps.cs) before the server is created.
// Everything below the PORT lines is that settings file, byte for byte. It has to run before
// the server starts: station.cs copies $HC::AllowableEquipment[] into the inventory lists when
// it is loaded, so without these values nothing can be bought.
//
// PORT notes on the Remote Admin List at the end of this file:
//  * Number your entries from 1, as the examples do.
//  * An entry with a blank password can not be used with the chat command  PASS: <password>
//    (the name, real name and e-mail of that test are all set by the client).
//  * Automatic access (name + real name + e-mail + address mask) is tested when a client's
//    player info arrives; in the 2000 release that test never matched anyone.
echo("HARD CORPS V1.5 FINAL (Warpath) -- 1.50 port entry");

// ####################################################################################
//                         HARD CORPS TRIBES MODIFICATION
// ####################################################################################

// MISCELLANEOUS
$SpawnImmunityTime = 3;					// Number of seconds player is immune to damage after spawning.
$LeaveMissionAreaDamage = "true";			// Whether or not leaving the mission area causes damage.


// PLAYER CONNECTION DEFAULTS
$DefaultCustomSkin = "true";				// If true, players use custom skins as default.
$DefaultShowDescriptions = "true";			// If true, shows equipment descriptions as default.
$DefaultShowWeaponNames = "true";			// If true, shows weapon names as default.
$DefaultShowWeaponStats = "true";			// If true, shows weapon statistics as default.
$DefaultEquipmentSlotA = Blaster;			// Default Spawn Equipment Slot A
$DefaultEquipmentSlotB = Chaingun;			// Default Spawn Equipment Slot B
$DefaultEquipmentSlotC = Disclauncher;		// Default Spawn Equipment Slot C

// TEAM-KILLING
$UseTKEffect = "true";
$TKwarnlimit = 10;					// Number of team-kills before Team-Killer declared.
$TKKicklimit = 5;						// Number of times declared Team-Killer before being kicked.
$TKTimeOut = 12;						// Time for points of team-kill to fade.


// SUDDEN DEATH CAPTURE-THE-FLAG TIE-BREAKING
$Standoffs = "false";					// Will standoffs be allowed.
$StandoffsTimeLimit = 300;				// Time from when a standoff is detected to when Sudden Death is declared.
$StandoffsCountdownActive = "false";
$DeathByFlagLimit = 5;					// Number of times can be killed in Sudden Death before cannot touch flag.
$SuddenDeathActive = "false";
$SuddenDeathTimeLimit = 120;				// Time till Flag becomes deadly.
$SuddenDeathNotification[0] = "false";
$SuddenDeathNotification[1] = "false";


// ADJUSTED DAMAGE SCALE
$AdjustedDamageScale = 1.0;				// Weapon damage multiplier.  Set to zero for weapons to cause no damage.
$AllowLaserHeadKills = "true";			// Allow single-shot-kill head-shots with Laser Rifles.
$UseAdjustedDamageScale = "true";			// If true, uses the HARD CORPS Adjusted Damage Scale.



// ADJUSTED SCORING SYSTEM
$UseAdjustedScoring = "true";				// If true, uses the HARD CORPS Adjusted Scoring System.
$ShowScoreBonuses = "true";				// If true, displays points earned for all actions.


// STATION EJECTION
$UseStationEject = "true";				// If true, Inventory Stations eject players who take too long.
$StationEjectTime = 60;					// Time till player is ejected.
$StationOutTime = 10;					// Time player is banned from using Stations after ejection.


// SERVER ALLOWANCES
$AllowCustomSkins = "true";				// Allow custom skins on the server.
$UseSensorJammerWithFlag = "false";			// Allow Sensor Jammer to work while player has the flag.


// ALLOWABLE EQUIPMENT
// Sets what equipment is, as default, available for use. Either "true" or "false".

// WEAPONS
$HC::AllowableEquipment[Blaster] = 1;
$HC::AllowableEquipment[PlasmaGun] = 1;
$HC::AllowableEquipment[Chaingun] = 1;
$HC::AllowableEquipment[Disclauncher] = 1;
$HC::AllowableEquipment[GrenadeLauncher] = 1;
$HC::AllowableEquipment[LaserRifle] = 1;
$HC::AllowableEquipment[EnergyRifle] = 1;
$HC::AllowableEquipment[Mortar] = 1;
$HC::AllowableEquipment[Clustergun] = 1;
$HC::AllowableEquipment[EMPulsegun] = 1;

// MISCELLANEOUS ITEMS
$HC::AllowableEquipment[MineAmmo] = 1;
$HC::AllowableEquipment[Grenade] = 1;
$HC::AllowableEquipment[Beacon] = 1;
$HC::AllowableEquipment[RepairKit] = 1;
$HC::AllowableEquipment[TargetingLaser] = 1;

// BACKPACKS
$HC::AllowableEquipment[AmmoPack] = 1;
$HC::AllowableEquipment[DecoyFlagPack] = 1;
$HC::AllowableEquipment[EnergyPack] = 1;
$HC::AllowableEquipment[ForceFieldPack] = 1;
$HC::AllowableEquipment[PowerPack] = 1;
$HC::AllowableEquipment[RepairPack] = 1;
$HC::AllowableEquipment[SensorJammerPack] = 1;
$HC::AllowableEquipment[ShieldPack] = 1;

// DEPLOYABLES
$HC::AllowableEquipment[AATurretPack] = 1;
$HC::AllowableEquipment[DeployableAmmoPack] = 1;
$HC::AllowableEquipment[DeployableInvPack] = 1;
$HC::AllowableEquipment[GravityPadPack] = 1;
$HC::AllowableEquipment[HeavyTurretPack] = 1;
$HC::AllowableEquipment[ImpulseTurretPack] = 1;
$HC::AllowableEquipment[MotionSensorPack] = 1;
$HC::AllowableEquipment[PointDefencePack] = 1;
$HC::AllowableEquipment[ProximityAlarmPack] = 1;
$HC::AllowableEquipment[PulseSensorPack] = 1;
$HC::AllowableEquipment[TurretPack] = 1;
$HC::AllowableEquipment[CameraPack] = 1;
$HC::AllowableEquipment[WeaponLockOutPack] = 1;

// VEHICLES
$HC::AllowableEquipment[ScoutVehicle] = 1;
$HC::AllowableEquipment[LAPCVehicle] = 1;
$HC::AllowableEquipment[HAPCVehicle] = 1;

// VEHICLE WEAPONS
$HC::AllowableEquipment[NapalmLauncher] = 1;
$HC::AllowableEquipment[RotaryChaingun] = 1;
$HC::AllowableEquipment[VehicleBomb] = 1;
$HC::AllowableEquipment[VehicleClusterCannon] = 1;
$HC::AllowableEquipment[VehicleEMPLauncher] = 1;
$HC::AllowableEquipment[VehicleRocket] = 1;

// VEHICLE MODULES
$HC::AllowableEquipment[AmmoModule] = 1;
$HC::AllowableEquipment[RepairModule] = 1;
$HC::AllowableEquipment[ShieldModule] = 1;
$HC::AllowableEquipment[SpeedModule] = 1;
$HC::AllowableEquipment[StealthModule] = 1;


// REMOTE ADMIN LISTS
$UseRemoteAdminList = "true";				// If true, uses remote admin functions.

// Remote Admin Lists allow you to dictate who automatically receives certain access levels.
//
// Remote Admin List format:
// $RemoteAdminList::User[1] = "User Name X Real Name X Email Address X Password X Access Level X IP Address X";
//
// User Name:  The user's logon name.  For example, [SHIT]Warpath.
// Real Name:  The user's Real Name as typed in on the player profile.  For example, Robert Tockley.
// Email Address:  The user's Email Address as typed in on the player profile.  For example, warpath@strategyplanet.com.
// Password:  The user's password.  If $UseRemoteAdminList is false this is used to gain appropriate access.
// Access Level:  The access level to give.  Either, SuperAdmin, Admin or RegularUser.
// IP Address:  The user's IP address.  Use * for wildcards.  For example, 203.147.162.*
//
// Example Entries
// $RemoteAdminList::User[1] = "[DORK] Boy X Knobby X knobby@geek.com X Werglebergle X RegularUser X 203.147.183.50 X";
// $RemoteAdminList::User[1] = "[DORK] Gal X Ima Weenie X i.weenie@geek.com X My pony stalker X Admin X 203.147.193.72 X";
