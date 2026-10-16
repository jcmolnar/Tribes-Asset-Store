// Pantheon MOD 1.02 by the Pantheon MOD team (scripts.vol dated 2000-03-21; built on the
// Insomniax admin code) -- Modern Tribes (1.50) entry script. Not part of the original release.
// The original was one scripts.vol in tribes\Pantheon plus a settings file tribes\config\Pantheon.cs,
// started with  tribes -mod Pantheon . The old game ran the file named after the mod word at
// start-up, which is how that settings file was loaded: no script execs it.
// Launch here:  -mod Pantheon
echo(">> Pantheon MOD 1.02");

$MODInfo = "Pantheon MOD 1.02";

// ---- the release's config\Pantheon.cs, lines 1-116 (the mod's own settings), unchanged ----
// NOT carried over from that file: $AdminPassword = "insertpasswordhere", $RegularAdminPassword =
// "adminme", $TelnetPort = 28100 / $TelnetPassword = "insertpasswordhere" (every server started
// from the pack would have shared those), the packet-rate prefs and the auto-kick name list
// (its code lived in the mod's server.cs, which is not shipped). Set your own passwords in your
// server config; $RegularAdminPassword is the mod's second, plain-admin password.
//Ban time in seconds
$Pantheon::BanKickTime = "5000";

//Auto assign new players to teams to make it fair
$Pantheon::fairTeams = "true";

//Number of seconds the player is allow to be outside of the mission area
$Pantheon::LeaveAreaTime = "20";

// Item limits

$Pantheon::AmmoStationLimit	= 7;
$Pantheon::InvStationLimit	= 7;
$Pantheon::CommandStationLimit	= 0;

$Pantheon::CameraLimit 		= 15;
$Pantheon::ProximityAlarmLimit  = 0; //DISABLED IN 1.02 DUE TO BUG. Usually 5.
$Pantheon::SensorJammerLimit 	= 5;
$Pantheon::PulseSensorLimit	= 10;
$Pantheon::MotionSensorLimit	= 10;

$Pantheon::BeaconLimit		= 40;
$Pantheon::MineLimit		= 35;

$Pantheon::ForceFieldLimit	= 5;
$Pantheon::LargeForceFieldLimit = 3;
$Pantheon::ForceFieldDoorLimit	= 4;

$Pantheon::IndoorTurretLimit 	= 5;
$Pantheon::LaserTurretLimit	= 5;
$Pantheon::DissectionLimit	= 2;
$Pantheon::MortarTurretLimit	= 3;
$Pantheon::VulcanTurretLimit	= 2;
$Pantheon::PlasmaTurretLimit	= 3;
$Pantheon::MissileTurretLimit	= 3;
$Pantheon::RocketBatteryLimit	= 2;
$Pantheon::PlasmaTurretDecoy	= 0;
$Pantheon::ELFTurretLimit	= 4;

$Pantheon::BlastwallLimit	= 12;
$Pantheon::TeleportDecoyLimit	= 5;
$Pantheon::SolarPanelLimit	= 2;
$Pantheon::SniperPadLimit	= 4;
$Pantheon::OutpostLimit		= 2;
$Pantheon::SpringboardLimit	= 5;
$Pantheon::PlatformLimit	= 12;
$Pantheon::SeedPackLimit	= 25;
$Pantheon::InterceptorPackLimit	= 3;
$Pantheon::FGCPackLimit		= 2;

$Pantheon::ScoutVehicleLimit	= 3;
$Pantheon::MarauderVehicleLimit = 2;
$Pantheon::HAPCVehicleLimit	= 3;
$Pantheon::LAPCVehicleLimit	= 3;
$Pantheon::GunshipVehicleLimit	= 4;
$Pantheon::InterceptorLimit	= 3;


//Number of Nukes a team can use per map
$Pantheon::NumberOfNukes = "1";

//Time in seconds before nuclear detonation
$Pantheon::NukeDetTime = "20";

//Players are allowed to change teams
$Pantheon::ChangeTeams = "true";

//Number of seconds a player can be in an inventory station before being ejected
$Pantheon::StationKickTime = "20";

//Points for killing vulcan turrets
$Pantheon::KillFriendlyVulcanPoints = "true";
$Pantheon::KillEnemyVulcanPoints = "true";

//Points for killing laser turrets
$Pantheon::KillFriendlyLaserPoints = "true";
$Pantheon::KillEnemyLaserPoints = "true";

//Public Admin options
$Pantheon::PABan = "false";
$Pantheon::PAKick = "true";
$Pantheon::PAGag = "true";
$Pantheon::PAMission = "false";
$Pantheon::PAModOptions = "false";
$Pantheon::PAResetDefaults = "false";
$Pantheon::PATeamChange = "false";
$Pantheon::PATeamDamage = "false";
$Pantheon::PATeamInfo = "false";
$Pantheon::PATimelimit = "false";
$Pantheon::PATourneyMode = "false";
//Is public admin votable
$Pantheon::PAVote = "false";

//Are players permitted to use personal skins
$Pantheon::PersonalSkins = "true";

//Public voting options
$Pantheon::PVKick = "true";
$Pantheon::PVMission = "false";
$Pantheon::PVTeamDamage = "false";
$Pantheon::PVTourneyMode = "false";

//What the client can do to TK'ers (0=vote, 1=kick)
$Pantheon::tkClientLvl = "0";

//Number of TK's a player can recieve before being punished
$Pantheon::tkLimit = "3";

//Number of TK's after tkLimit to retry tkServerLvl action
$Pantheon::tkMultiple = "3";

//What the server does to TK'ers (0=log, 1=vote, 2=vote until kicked, 3=auto-kick)
$Pantheon::tkServerLvl = "3";

//Team energy
$DefaultTeamEnergy = "Infinite";
// ---- end of config\Pantheon.cs ----

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit (game.cs).
function Game::syncClientClock(%cl)
{
   if(!$matchStarted || !$Server::timeLimit)
      return;
   remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

// PORT: three helpers the mod kept in its server.cs (station.cs:224, turret.cs:8 call them).
// That server.cs is otherwise an old stock copy and is not shipped. Unchanged.
function ixCos(%theta)
{
  return (1 - (pow (%theta, 2) / 2) + (pow (%theta, 4) / 24) - (pow (%theta, 6) / 720) + (pow (%theta, 8) / 40320) - (pow (%theta, 10) / 3628800));
}

function ixSin(%theta)
{
  return (%theta - (pow (%theta, 3) / 6) + (pow (%theta, 5) / 120) - (pow (%theta, 7) / 5040) + (pow (%theta, 9) / 362880) - (pow (%theta, 11) / 39916800));
}

function ixDotProd(%vec, %scalar)
{
%return = Vector::dot(%vec, %scalar @ " 0 0") @ " " @ Vector::dot(%vec, "0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec, "0 0 " @ %scalar);
  return %return;
}

// PORT (bug in the release): the mod's item.cs still places a beacon through Beacon::deployShape
// (item.cs:5861, every armor that does not throw it as a booster / bomb) but no longer contains
// that function. This is the stock one, unchanged.
function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}
