// Omega Assault v1.6 -- entry script of the Modern Tribes (1.50) port.
// The client runs this file first for  -mod Omega . The mod itself is the 76 scripts in
// scripts\ (the release was one scripts.vol and nothing else).
//
// Everything below is a function the mod CALLS but never shipped. Its scripts were put together
// from other mods (an admin script that logs through a "Logger" script, weapon files that
// register themselves with addWeapon / addAmmo, deployables that report to NukeList) and those
// helper scripts were not in the release. A call to a function that does not exist prints a
// console error and gives "False" back, so they are defined here: empty where the result is
// not used, the plain player name where it is shown to players.
echo(">> Omega Assault v1.6");

// admin.cs, 72 calls: the log line of the missing Logger script. Nothing was ever written.
function Logger::logMessage(%client, %tag, %message)
{
}

// admin.cs, 11 calls: shown in "Server switched to Tournament Mode by ..." and in the
// "*HACK*" console lines.
function Logger::getClientStr(%client)
{
   if(%client == -1 || %client == "")
      return "vote";
   return Client::getName(%client);
}

// admin.cs "Aliases for <player>": the alias list lived in the missing Logger script.
function Logger::showAlias(%client, %admin)
{
   Client::sendMessage(%admin, 0, "No alias list is kept on this server.");
}

// Weapon*.cs, at load: registration calls of another mod. This mod fills its weapon tables
// ($WeaponAmmo, $NextWeapon, $InvList ...) by hand in the same files and in item.cs.
function addWeapon(%weapon)
{
}

function addAmmo(%weapon, %ammo, %count)
{
}

// deploy*.cs, after every deploy: the list behind the two admin options "Delete all
// deployables" / "Delete deploys of <player>". delAllDeploys and delDeploys were not in the
// release either and are NOT defined here: those two options still do nothing (see PORT-REPORT).
function NukeList(%object)
{
}

// WeaponFissionSniper.cs / WeaponGammaCannon.cs, when a shot locks on: the warning the target
// was meant to get.
function RocketLockWarning(%client, %target, %type)
{
}

// WeaponIonCannon.cs, on fire.
function CheckIcannon(%client, %player)
{
}

// item.cs still sells the stock Pulse Sensor and Sensor Jammer packs and their onDeploy calls
// Item::deployShape, but the mod's item.cs lost that function, so the two packs deployed
// nothing. This is the stock function, unchanged.
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
						addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
