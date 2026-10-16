// STRATEGIC COMBAT version 1.63 by Dasher[TOP] (February 2001), a variant of
// TRIBAL COMBAT by Despised, with the BarrysWorld admin mod 5.01 by Poker built in.
// Entry script for the Modern Tribes client (1.50).
//
// Original launch line (Docs\Readme.txt):
//     tribes.exe +exec combatServerCfg -mod StrategicCombat
// where config\combatServerCfg.cs held the mod's server settings. Under 1.50 the launch is
//     -mod StrategicCombat
// and the loader runs this file. Everything below the PORT lines is that settings file, byte
// for byte.
//
// PORT notes
//  * The release's serverDefaults.cs is not shipped (dead 2001 master-server list; it forced
//    a public 32 player server). The one value of it that the mod's scripts read and base
//    does not define, the 6 second respawn shield, is set below. Team damage is forced ON
//    by the mod's own game.cs at every mission load. Its 60 minute time limit and 8 second
//    warm-up are left to the host's own server settings. The "TRAITOR" name / skin it gave
//    team 4 is unused in 1.63 (setTraitor is switched off in combatAdmin.cs).
//  * combatConfig.cs (next to this file) is the mod's optional CLIENT key file: B = armor
//    special, F = next weapon mode. A player who wants those keys types
//        exec("combatConfig.cs");
//    in the console once while this mod is loaded. Weapon modes are also in the Tab menu.
echo("STRATEGIC COMBAT 1.63 -- 1.50 port entry");
$Server::respawnInvulnerableTime = 6; // PORT: from the release's serverDefaults.cs (game.cs reads it)

//**********************
//Remove $Console::LogMode if you use this setting
//in another server config file
//**********************

$Console::LogMode = "1";

//**********************
//Sets the amount of team kills before the Anti-Tk code is used.
//If a combat map is used, the TK will be set to TRAITOR team,
//else will be kicked. Minimum setting is 3.
//**********************

$Server::MaxTeamKills = "5";

//**********************
//This enables an initial truce on CTF maps. Players who touch
//the enemy flag during this time are killed.
//The InitialTruce setting is expressed in minutes, and has
//a maximum setting of 10 minutes.
//**********************

$Server::Truce = "true";
$Server::InitialTruce = "2";

//**********************
// Allows a server to use the JoinMOTD
// Set to true for Server::JoinMOTD or false for Combat messages
//**********************

$Combat::ServerMOTD = "true";

//**********************
//Enables or disables the auto repair of POWERED turrets.
//**********************

$Combat::NoAutoRepair = "true";

//**********************
//This sets the item mode to simluated base. It removes all
//of the combat items, but it is still 'tweaked' gameplay.
//Simulated base mode is more challenging then base Tribes.
//**********************

$Combat::BaseItems = "false";

//**********************
//These settings enable or disable certain item groups.
//**********************

$Combat::NoVehicles = "false";
$Combat::NoTurrets = "false";
$Combat::NoEmplacements = "false";
$Combat::NoStructures = "false";
$Combat::NoTeleports = "false";
$Combat::NoTraps = "false";
$Combat::NoDrones = "false";

//**********************
//This enables or disables the armor special features.
//It is RECOMMENDED TO LEAVE THIS ON FALSE. Combat was 
//balanced around these special features, and disabling
//these will unbalance the gameplay.
//**********************

$Combat::NoSpecial = "false";

//**********************
//This sets the Jump Thruster mode. The settings are
//normal, low, and off. Normal is default, and is the best
//setting to use, as it makes light armor actually useful.
//**********************

$Combat::JumpThruster = "normal";

//**********************
//These settings effect the damage ratings of various projectiles.
//Read the docs for more info. It is advised to leave these settings
//on default. Any other setting will unbalance the gameplay.
//Players can always vote the game back to normal combat damage settings,
//and they will be advised to do so if these values are changed.
//**********************

$Combat::allowDamageModes = "false";
$Combat::DamageMode = "normal";
$Combat::LowDamageScale = "0.5";
$Combat::HighDamageScale = "1.5";

$Combat::CustomDamage = "false";
$Combat::ImpactDamage = 1.0;
$Combat::LandingDamage = 1.0;
$Combat::BulletDamage = 1.0;
$Combat::EnergyDamage = 1.0;
$Combat::PlasmaDamage = 1.0;
$Combat::ExplosionDamage = 1.0;
$Combat::ShrapnelDamage = 1.0;
$Combat::LaserDamage = 1.0;
$Combat::MortarDamage = 1.0;
$Combat::BlasterDamage = 1.0;
$Combat::ElectricityDamage = 1.0;
$Combat::CrushDamage = 1.0;
$Combat::DebrisDamage = 1.0;
$Combat::MissileDamage = 1.0;
$Combat::MineDamage = 1.0;

//***********************
//This enables or disables the use of menu respawn gear selection.
//I once again advise to leave this setting on default, as it helps
//balance the game play.
//***********************

$Combat::AllowRespawnGear = "true";

//***********************
//This setting can disable the use of litter bug scripts. Items then 
//can not be dropped from inventory stations.
//***********************
$Combat::NoLitterBug = "false";

//***********************
//Disables/enables a player being voted to admin status. It is
//recommended to leave this set on true, as it helps prevent
//hostile take overs of a public server.
//***********************

$Combat::NoVoteAdmin = "true";

//***********************
//Disables the vote kicking of players. If set to true, it allows the
//anti-TK code to perform its job. However, players could still act as
//base killers, so I recommend leaving this set to false.
//***********************

$Combat::NoVoteKick = "false";

//***********************
//Disables a player switching to observer mode after the game has started.
//***********************
 
$Combat::noObserver = "false";

//***********************
//Disables players from choosing their own team. Set this to false for matches.
//***********************

$Combat::evenTeams = "false";

//***********************
//Auto kicks a player from an INV station after a certainperiod of time.
//The minimum setting is 10 seconds.
//***********************

$Combat::autoINVBoot = "false";
$Combat::INVBootTime = "20";

//***********************
//Allows players to use their custom skin setting. Players will not be able
//to use the skin set that your server uses for an enemy team.
//***********************

$Combat::customSkin = "true";

//***********************

//***********************
//Seconds of delay time for light jump boost
//***********************

$Combat::LightJumpDelay = 3;
