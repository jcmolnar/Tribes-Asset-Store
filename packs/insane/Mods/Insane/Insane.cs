// INSANE mod 1.0a by [PLA]KeViN (readme dated 3-10-99; built on Renegades, with the Insomniax
// admin menus) -- Modern Tribes (1.50) entry script. Not part of the original release.
// The original was a complete scripts folder in tribes\INSANE plus a settings file
// tribes\config\INSANE.cs, started with (Readme.txt):
//     tribes.exe -mod INSANE
// The old game ran the file named after the mod word at start-up, which is how that settings
// file was loaded: no script execs it. Its 17 lines are below, unchanged.
// Launch here:  -mod Insane
echo(">> INSANE mod 1.0a");

$MODInfo = "INSANE mod 1.0a by [PLA]KeViN";

// ---- the release's config\INSANE.cs ----
// What a plain (voted / password) admin may do, the team-kill protection levels and how long a
// kick keeps a player out. A super admin can change the PA* switches and the TK levels for the
// current server run under Tab > Server Options. The 1.50 port enforces the PA* switches on
// the server; the 1999 scripts only hid the menu entries.
$Insomniax::BanKickTime = "600";
$Insomniax::fairTeams = "true";
$Insomniax::PABan = "true";
$Insomniax::PAKick = "true";
$Insomniax::PAMission = "true";
$Insomniax::PAModOptions = "true";
$Insomniax::PAResetDefaults = "true";
$Insomniax::PATeamChange = "false";
$Insomniax::PATeamDamage = "false";
$Insomniax::PATeamInfo = "false";
$Insomniax::PATimelimit = "false";
$Insomniax::PATourneyMode = "false";
$Insomniax::PAVote = "true";
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "10";
$Insomniax::tkMultiple = "3";
$Insomniax::tkServerLvl = "1";
// ---- end of config\INSANE.cs ----

// PORT: the mod's game.cs and objectives.cs are edited copies of an early stock build. The 1.50
// admin / observer / server scripts call three functions that build did not have yet. The two
// tourney ones are the stock ones; the clock one uses the same arithmetic as the mod's own
// Game::checkTimeLimit (game.cs).
function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      %cl.notready = "";
      %cl.notreadyCount = "";
      bottomprint(%cl, "", 0);
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;

   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1])
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}

function Game::syncClientClock(%cl)
{
   if(!$matchStarted || !$Server::timeLimit)
      return;
   remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

// PORT (bug in the release): the mod's item.cs still deploys the Pulse Sensor and the Sensor
// Jammer through Item::deployShape (item.cs:3001, :3047) but no longer contains that function,
// so neither pack could be placed. This is the stock function, unchanged.
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
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
