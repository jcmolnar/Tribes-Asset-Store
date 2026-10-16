
function Nappy::timeTest()
{


//TimeFormat(h,n,s,m,d,yy):  


//%time = timestamp(h,n,s,m,d,yy);

%time = timestamp(yy,DD,M,d,h,n,s);
echo(%time);

//messageall(1,%time);

}

$Nappy::autoKickTesting = 1;

$Nappy::TagKick::KickTime = 60;
//$Nappy::TagKick::MessageTime = 60;

$Nappy::FloodProtection = 1;

$Nappy::FloodProtection::LogChecking = 1;
$Nappy::FloodProtection::LogIgnore = 1;
$Nappy::FloodProtection::LogKick = 1;


$Nappy::Flood::AutoKick = 1;

//	All non placed types
$Nappy::FloodCount::ignore[1] = 10;
$Nappy::FloodCount::kick[1] = 15;
$Nappy::FloodCount::Rate[1] = 1;

//	Password
$Nappy::FloodCount::ignore[2] = 3;
$Nappy::FloodCount::kick[2] = 3;
$Nappy::FloodCount::Rate[2] = 3;

//	Message
$Nappy::FloodCount::ignore[3] = 3;
$Nappy::FloodCount::kick[3] = 6;
$Nappy::FloodCount::Rate[3] = 5;

//	Drop/Throw Scripts
$Nappy::FloodCount::ignore[4] = 15;
$Nappy::FloodCount::kick[4] = 25;
$Nappy::FloodCount::Rate[4] = 1;


$Nappy::Flood::KickMessage[1] = "You were kicked to prevent flood.";
$Nappy::Flood::KickMessage[2] = "You were kicked for password flood.";

//	nappy_admin.cs
//AdminPass
//PersonalAdminPass
//Vote
//MenuRequest
//SelClient

//	nappy_comChat.cs
//CStatus
//IssueCommand
//IssueTargCommand
//ToggleInventoryMode
//InventoryMode
//CommandMode

//	nappy_item.cs
//BuyFavorites
//BuyItem
//NextWeapon
//PrevWeapon
//UseItem
//ThrowItem
//SellItem
//DropItem
//DeployItem

//	nappy_player.cs
//Kill
//CmdrMountObject

//	nappy_server.cs
//SetCLInfo



//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	//all modes not yet completed...
$BaseArmors = 0;		//turn base armors on and off
$BuilderMode = 0;		//turn builder mode on and off(working good)
$BaseMode = 0;   		// if = 1 then you spawn with base armor spawn(NOT FINISHED)
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

$Nappy::AutoAdmin::Hoster = 1;

	//if you host dedicated then keep it set to true
//$dedicated = "true"; // PORT: a settings file must not turn a listen host into a dedicated server

	//if you want others to join your server then keep this true
//$Server::HostPublicGame = "true"; // PORT: the host decides (LAN / public), not the mod

	//name of the server favorites set
$Nappy::ItemFavorites = "Nappy_Test";

	//obvious
$Nappy::PersonalSkins = 1;


//__________________________________________________________________________________________
	//this sets the max length of messages(max is 255)
$Nappy::Message::MaxLength = 80;

	//this is how many non keybord characters can be typed (to prevent crashes)
$Nappy::Message::OtherCharacters = 5;

	//if set to 1 it will show messages in the console
$Nappy::Message::showInConsole = 1;

	//this is how high the count has to go before it stops the message spam flood
$Nappy::Message::floodCount = 3;

	//this is how many seconds it takes for the count to go down 1
$Nappy::Message::floodRate = 5;

	//this is how long it will mute the message spammer
$Nappy::Message::floodMuteTime = 10;

	//this is how many seconds are added when someone sends a message while still muted
$Nappy::Message::floodMuteTimeBonus = 5;

	//this is how high the count has to get for the spammer to get auto kicked
$Nappy::Message::kickCount = 6;

	//this is how long the players ip will be kicked for(set in seconds)
$Nappy::Message::kickTime = 60;




//__________________________________________________________________________________________
	//if set to 1 the server will add the time to the logs
$Nappy::Time = 1;

$Nappy::LogTime::FullNames = 1;


	//files will be deleted in this many days if not set to 0
$Nappy::Logs::daysTillDelete = 8;

	//if set to 1 the server will log info to a log file in Tribes\Temp
$Nappy::LogIP = 1;
$Nappy::LogMessages = 1;
$Nappy::LogBadMessages = 1;
$Nappy::LogAdmin = 1;
$Nappy::LogAutoKick = 1;
$Nappy::LogDuelOptions = 1;
$Nappy::LogRemote = 0;
$Nappy::LogRemoteIgnore = 1;

//-------------if set to 1 the server will make log files for each day
	//Message Log
$Nappy::MakeNewLogFileEachDay[1] = 1;

	//Bad Message Log
$Nappy::MakeNewLogFileEachDay[2] = 1;

	//IP Log
$Nappy::MakeNewLogFileEachDay[3] = 1;

	//Admin Log
$Nappy::MakeNewLogFileEachDay[4] = 1;

	//Auto Kick Log
$Nappy::MakeNewLogFileEachDay[5] = 0;

	//Duel Options Log
$Nappy::MakeNewLogFileEachDay[6] = 0;

	//Remote Log
$Nappy::MakeNewLogFileEachDay[7] = 1;

	//Remote Ignore Log
$Nappy::MakeNewLogFileEachDay[8] = 1;


//||||||||||||||||||||||||||   LOG SEPARATORS   ||||||||||||||||||||||
	//Message Log
$Nappy::LogSeparator::hour[1] = 1;
$Nappy::LogSeparator::day[1] = 1;
$Nappy::LogSeparator::MapChange[1] = 1;
$Nappy::LogSeparator::restart[1] = 1;

	//Bad Message Log
$Nappy::LogSeparator::hour[2] = 1;
$Nappy::LogSeparator::day[2] = 1;
$Nappy::LogSeparator::MapChange[2] = 1;
$Nappy::LogSeparator::restart[2] = 1;

	//IP Log
$Nappy::LogSeparator::hour[3] = 1;
$Nappy::LogSeparator::day[3] = 1;
$Nappy::LogSeparator::MapChange[3] = 1;
$Nappy::LogSeparator::restart[3] = 1;

	//Admin Log
$Nappy::LogSeparator::hour[4] = 1;
$Nappy::LogSeparator::day[4] = 1;
$Nappy::LogSeparator::MapChange[4] = 1;
$Nappy::LogSeparator::restart[4] = 1;

	//Auto Kick Log
$Nappy::LogSeparator::hour[5] = 0;
$Nappy::LogSeparator::day[5] = 1;
$Nappy::LogSeparator::MapChange[5] = 0;
$Nappy::LogSeparator::restart[5] = 0;

	//Duel Options Log
$Nappy::LogSeparator::hour[6] = 0;
$Nappy::LogSeparator::day[6] = 1;
$Nappy::LogSeparator::MapChange[6] = 0;
$Nappy::LogSeparator::restart[6] = 0;

	//Remote Log
$Nappy::LogSeparator::hour[7] = 1;
$Nappy::LogSeparator::day[7] = 1;
$Nappy::LogSeparator::MapChange[7] = 1;
$Nappy::LogSeparator::restart[7] = 1;

	//Remote Ignore Log
$Nappy::LogSeparator::hour[8] = 1;
$Nappy::LogSeparator::day[8] = 1;
$Nappy::LogSeparator::MapChange[8] = 1;
$Nappy::LogSeparator::restart[8] = 1;

//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

//____________________________________________________



	//validates shapes and materials
$Base::validate = false; 
			 
	//validates shapes and materials
$Nappy::validate = false;

	//0=white 1=red 2=yellow 3=green
$Nappy::AdminObserverOtherTeamChatColor = 0;

	//time it takes for items to respawn
$Nappy::ItemRespawnTime = 30;

	//spawn shield time
$Nappy::respawnInvulnerableTime = 2;

	//set this to 1 if you want the flag to be able to be taken out of the mission area
$Nappy::Flag::OutOfBounds = 1;

	//if set to 0 the mission will stay with all the objects when noone is on the server
$Nappy::RefreshOnEmpty = 1; 

	//if set to 1 the mission will not change when the time is turned off
$Nappy::UnlimitedMapTime = 0; 

	//if $Nappy::UnlimitedMapTime is set to 0 the mission will change in this amount of time
$Nappy::MapChangeTime = 2500; //18000 = 5 hours







	//this is how many seconds till the station ejects the player
$Nappy::Station::EjectTime = 30;

	//these set the deployable stations energy
$Nappy::RemoteInvEnergy = 9000;
$Nappy::RemoteInvPrice = 800;
$Nappy::RemoteAmmoEnergy = 2000;
$Nappy::RemoteAmmoPrice = 600;

	//sets deployable station energy the same as base inventory stations
$Nappy::BigStationEnergyDeployableStation = 1;

	//makes it so you can buy armors from deployable inventory station
$Nappy::BuyArmorDeployableStation = 1;

	//turn the deployable station to run off of the big station item list
	//if set to 1 then $Nappy::BuyArmorDeployableStation can be set to 0
$Nappy::FullInventoryListDeploaybleStation = 0;



	//makes it so you can deploy anything on any kind of object
$Nappy::DeployOnAnything = 1;

	//makes it so you can deploy as close to an object as you want
$Nappy::NoObjectInTheWay = 1;

	//makes it so you can deploy as many of the same object next to each other
$Nappy::NoObjectInterference = 1;

	//deploy distance scale to adjust all deployable deploy distance
$Nappy::DeployableDistanceMultiplyer = 1;

if($BuilderMode){//if $BuilderMode = 1
	//this makes it so you can do long distance deploying in builder mode
	$Nappy::DeployableDistanceMultiplyer = 9999;
}

	//these set how far you can deploy objects
	//objects..(teleports/trees/spring pads/ect..)
$Nappy::ObjectDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//bases
$Nappy::BaseDeployDistance = 15 * $Nappy::DeployableDistanceMultiplyer;
	//stations
$Nappy::StationDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//big turrets
$Nappy::TurretDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//small turrets
$Nappy::SmallTurretDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//sensors
$Nappy::SensorDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//deployable beacons
$Nappy::BeaconDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//walls
$Nappy::WallDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
	//platforms
$Nappy::PlatformDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;



	//this is how long you have to wait to use a turret after getting out of it
$Nappy::Turret::controllReactivationTime = 3;
	//sets deployer as the owner of the turret and give points
$Nappy::SetOwnerToTurrets = 0;

	//these set how close an enemy has to be from a turret before it will shoot
	//if turret range is set to 0 then the turret must be manually controlled
$Nappy::Base::PlasmaTurretRange = 150;
$Nappy::Base::ElfTurretRange = 40;
$Nappy::Base::RocketTurretRange = 270;
$Nappy::Base::RocketTurretGunRange = 300;
$Nappy::Base::MortarTurretRange = 0;
$Nappy::Base::IndoorTurretRange = 25;
$Nappy::Base::DeployableTurretRange = 30;//base ion turret...  not used in nappy





	//used to scale the strength of deployable objects
$Nappy::StaticShapeStrength = 1.0;
	//use to scale the strength of turrets
$Nappy::TurretStrength = 1.0;
	//used to scale the strength of the armors
$Nappy::ArmorStrength = 1.0;

if($BuilderMode){
	//this makes objects weaker for builder mode
	$Nappy::StaticShapeStrength = 0.25;
}


	//time it takes to shoot the gun again
$Nappy::Gun[RepairGun, reloadTime] = 3;
	//this is how much energy you have and turns off the gun
$Nappy::Gun[RepairGun, minEnergy] = 3; 
	//this is how much energy it will take if you have it 
$Nappy::Gun[RepairGun, maxEnergy] = 10;

	//repair rate for non-player objects
$Nappy::Projectile[RepairBolt, ObjectRepairRate] = 10.0;

	//repair rate when repairing others
$Nappy::Projectile[RepairBolt, OtherPlayerRepairRate] = 0.75;

	//repair rates for repairing yourself
$Nappy::Projectile[RepairBolt, autoRepairRate, Scout] = 0.14;
$Nappy::Projectile[RepairBolt, autoRepairRate, Spy] = 0.14;
$Nappy::Projectile[RepairBolt, autoRepairRate, Sniper] = 0.1;
$Nappy::Projectile[RepairBolt, autoRepairRate, Mercenary] = 0.1;
$Nappy::Projectile[RepairBolt, autoRepairRate, Engineer] = 0.20;
$Nappy::Projectile[RepairBolt, autoRepairRate, FlagMover] = 0.15;
$Nappy::Projectile[RepairBolt, autoRepairRate, Burster] = 0.15;
$Nappy::Projectile[RepairBolt, autoRepairRate, Cyborg] = 0.15;

	//energy drain rate when repairing non-player objects
$Nappy::Projectile[RepairBolt, ObjectEnergyDrain] = 0.5;

	//energy drain rate when repairing others
$Nappy::Projectile[RepairBolt, OtherPlayerEnergyDrain] = 0.75;

	//energy drain rates for repairing yourself
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Scout] = 0.7;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Spy] = 0.7;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Sniper] = 1.5;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Mercenary] = 1.25;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Engineer] = 2.3;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, FlagMover] = 2.8;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Burster] = 2;
$Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Cyborg] = 4;

	//used to scale the damage of projectiles
$Nappy::ProjectileDamage = 1.0;
	//used to scale the damage of lasers
$Nappy::LaserDamageConversion = 1.0;
	//used to scale the damage of mines
$Nappy::MineDamage = 1.0;
	//used to scale the damage of grenades
$Nappy::GrenadeDamage = 1.0;
	//used to scale the damage of bombs
$Nappy::BombDamage = 1.0;





$Nappy::TeleportReenableTime = 5;//time it takes to use teleport again
$Nappy::TeleportTime = 2.25;//time it takes to teleport


$Nappy::PackTime = 5;//time it takes to repack an item
if($BuilderMode)
	$Nappy::PackTime = 2;
$Nappy::VehiclePackTime = 5;//time it takes to pack a vehicle




$Nappy::SpeedBoostRadius = 8.0;
$Nappy::SpeedBoostStrength = 300;





//_____________________DEPLOY DISTANCE_______
$Nappy::VehicleCheckDistance::BoxLength = 30;
$Nappy::VehicleCheckDistance::BoxWidth = 30;
$Nappy::VehicleCheckDistance::BoxHeight = 30;

//___________________FLYING CHECK DISTANCE_________
$Nappy::VehicleServerCrashDistance::BoxLength = 30;
$Nappy::VehicleServerCrashDistance::BoxWidth = 30;
$Nappy::VehicleServerCrashDistance::BoxHeight = 30;





//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
//			ELEVATOR STUFF
//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

//____________________MOVING CHECK DISTANCE________
$Nappy::ElevatorServerCrashDistance::BoxLength = 7;
$Nappy::ElevatorServerCrashDistance::BoxWidth = 7;
$Nappy::ElevatorServerCrashDistance::BoxHeight = 7;


//::::THIS IS IN NAPPY.CS TEMPORARILY::::(belongs in all maps with elevators)
//______________BEFORE MOVING CHECK DISTANCE______
$Nappy::ElevatorClearStartDistance::BoxLength = 7;
$Nappy::ElevatorClearStartDistance::BoxWidth = 7;
$Nappy::ElevatorClearStartDistance::BoxHeight = 16;
$Nappy::ElevatorClearStartDistance::BoxHeightOffset = 8;

$Nappy::Elevator::Stoppable = 0;
$Nappy::Elevator::ArmorCrushDamage = 0.01;
$Nappy::Elevator::ObjectCrushDamage = 999;

//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
//			ELEVATOR STUFF
//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


//____________________________TREE AREA CHECK___________  not used yet....
//	$Nappy::TreeServerCrashDistance::BoxLength = 50;
//	$Nappy::TreeServerCrashDistance::BoxWidth = 50;
//	$Nappy::TreeServerCrashDistance::BoxHeight = 50;
//======================================================




////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////Admin Variables/////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////

//if set to 1 the public can use observer
$Nappy::Public::Observer = 0;

//if set to 1 the public can use duel team
$Nappy::PublicDuelTeam = 1;

//This is the time that a player will be banned for in seconds.
$Nappy::BanTime = "1800";

//This is the time that a player will be kicked for in seconds.
$Nappy::KickTime = "600";

//If set to 1 this enables a TK kick-vote option to the public
$Nappy::tkClientLvl = "0";

//This is the number of Tk's needed to activate the server TK protection if it is enabled.
$Nappy::tkLimit = "3";

//If $Nappy::tkServerLvl = 2 this is the number of TK's needed to autokick rather than autovote.
$Nappy::tkMultiple = "3";

//This sets the TK protection for the server.
//0=Log only.  1=Auto vote.  2=Auto vote until kicked.  3=Auto kick.
$Nappy::tkServerLvl = "1";

//If true the public will be able to vote players to be admin.
$Nappy::AdminVote = "false";

//If true the public will be able to vote to kick players.
$Nappy::KickVote = "true";

//If true the public will be able to vote to change the mission.
$Nappy::MissionVote = "true";

//If true the public will be able to vote to change to Tournament or FreeForAll mode.
$Nappy::TourneyVote = "false";

//If true the public will be able to vote to disable or enable team damage.
$Nappy::TeamDamageVote = "true";

//If true the following 5 variables enable the corresponding manipulations to SuperAdmins.
//Note that these override $Nappy::PAManip for that manipulation if false.
$Nappy::Execute = "true";
$Nappy::Strip = "true";
$Nappy::Freeze = "true";
$Nappy::Refill = "false";//changed
$Nappy::Launch = "true";

//If true a SuperAdmin may reset the server defaults.
//Note that this overrides $Nappy::PAResetDefaults if false.
$Nappy::ResetDefaults = "true";

//If true a SuperAdmin may change mod options.
//Note that this overrides $Nappy::PAModOptions if false.
$Nappy::ModOptions = "false";//changed


//Note that all PA variable apply to regular Admins not SuperAdmins.

//If true an Admin may change mod options.
$Nappy::PAModOptions = "false";

//If true an Admin may reset the server defaults.
$Nappy::PAResetDefaults = "false";

//If true an Admin may change a players team.
$Nappy::PATeamChange = "true";

//If true an Admin may enable or disable team damage.
$Nappy::PATeamDamage = "true";

//If true an Admin may change team info like name and skins.
$Nappy::PATeamInfo = "false";//changed

//If true an Admin may change the time limit.
$Nappy::PATimelimit = "true";

//If true an Admin may change the server to Tournament or FreeForAll mode.
$Nappy::PATourneyMode = "false";

//If true an Admin may ban players.
$Nappy::PABan = "false";

//If true an Admin may kick players.
$Nappy::PAKick = "true";

//If true an Admin may speak privately to other players.
$Nappy::PASpeak = "true";

//If true an Admin may change the mission.
$Nappy::PAMission = "true";

//If true an Admin may gag players.
$Nappy::PAGag = "true";

//If true an Admin may perform all enabled manipulations.
$Nappy::PAManip = "true";

//____________________ADDED BY SPOON__
//If true an Admin can cancel votes.
$Nappy::CancelVote = "true";
//____________________________________

//____________________ADDED BY SPOON_______________________________
//If true an Admin can restart the server. (Restart Infinite Spawn)
$Nappy::Restart = "true";
//_________________________________________________________________




//DUEL SETTINGS NO LONGER NEEDED SINCE YOU CAN CHANGE THEM IN GAME NOW...

$Nappy::DuelDamageScale = 0.333;//sets duel team damage scale(this is adjustable after start)








//------------------NOTHING TO CHANGE DOWN HERE-------------------


function Nappy::Kick(%client)
{
//made to kick players from console
	%client.kickMe = 1;
}

function remoteTrue(%clientId)
{
//cheap fix for console error message
	$blah = $Nappy::LogFile::DateStamp @ "remote true : " @ Nappy::getName(%clientId);
	// PORT: no file write per call (any client could call this without limit and grow Temp\\Nappy_modInfo.cs)
}


function leaveMissionAreaDamage(%info, %info)
{

}



function remotefetchData(%var1)//lag fix from a client script
{
//echo(1, "Var 1 = " @ %var1);
}

$Nappy::Stop::TheForts = 0;//had to make this for the server when the map would mess with the 
			   //server and we couldn't get the map off...

