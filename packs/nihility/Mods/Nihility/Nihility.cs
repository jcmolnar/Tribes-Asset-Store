// NIHILITY 1.4.3 (AUTO, November 2002) -- Modern Tribes (1.50) entry script.
//
// The release is a single scripts.vol; it was dropped into a mod folder and started with
// -mod <folder>. The game's own console.cs loads server.cs and game.cs from this mod's scripts
// folder, server.cs execs every weapon / pack / turret / deployable script, and game.cs line 4
// execs "nihility.cs", the mod's settings file.
//
// This file IS that settings file: the mod folder is named Nihility, so the loader's
// "<folder name>.cs" and game.cs's exec("nihility.cs") are the same name, and the copy at the
// mod root is the one both of them find. The 17 lines between the two markers are the original
// scripts\nihility.cs, byte for byte. It is exec'd at start-up and again at every mission load,
// exactly as the original was. Below them: a note for hosts, and seven small functions the mod
// calls but never had.
echo(">> NIHILITY 1.4.3");

// ---- original scripts\nihility.cs ----
$Insomniax::BanKickTime = "600";
$Insomniax::fairTeams = "true";
$Insomniax::PABan = "true";
$Insomniax::PAKick = "true";
$Insomniax::PAMission = "true";
$Insomniax::PAModOptions = "true";
$Insomniax::PAResetDefaults = "true";
$Insomniax::PATeamChange = "false";
$Insomniax::PATeamDamage = "true";
$Insomniax::PATeamInfo = "false";
$Insomniax::PATimelimit = "true";
$Insomniax::PATourneyMode = "true";
$Insomniax::PAVote = "true";
$Insomniax::tkClientLvl = "0";
$Insomniax::tkLimit = "5";
$Insomniax::tkMultiple = "3";
$Insomniax::tkServerLvl = "1";
// ---- end of the original settings file ----
//
// Note for hosts. The 17 settings above are read by nothing: the mod's admin.cs is HaVoC 1.55's,
// which reads the names below instead, and no NIHILITY release sets them. Unset means: a public
// (voted-in or password) admin has no rights, the "Voting..." page is empty for players, a kick
// carries no temporary ban, and the anti team-kill levels are off. Remove the // to turn one on.
// The values shown are HaVoC 1.55's own defaults, except where NIHILITY's file above gives one.
//
// $HaVoC::PVMission = TRUE;        // players may vote to change the mission
// $HaVoC::PVKick = TRUE;           // players may vote to kick
// $HaVoC::PVTeamDamage = TRUE;     // players may vote team damage on / off
// $HaVoC::PVFairTeams = TRUE;      // players may vote fair teams on / off
// $HaVoC::PVBalanceTeams = TRUE;   // players may vote to balance the teams at the next map
// $HaVoC::PVAdmin = FALSE;         // players may vote someone admin
// $HaVoC::PVTourneyMode = FALSE;
// $HaVoC::PVStartMatch = FALSE;
// $HaVoC::PVTime = 11;             // minutes added by a passed "Increase Time" vote
// $HaVoC::PAKick = TRUE;           // what a public admin may do
// $HaVoC::PABan = TRUE;
// $HaVoC::PAMission = TRUE;
// $HaVoC::PATeamDamage = TRUE;
// $HaVoC::PATimelimit = TRUE;
// $HaVoC::PATourneyMode = TRUE;
// $HaVoC::PATeamChange = FALSE;
// $HaVoC::BanKickTime = 600;       // seconds a kicked player stays out
// $HaVoC::fairTeams = TRUE;
// $HaVoC::PAPassword[1] = "";      // public admin password ("" = none)
// $HaVoC::SADPassword[1] = "";     // super admin password ("" = none)
//
// The HaVoC anti team-kill levels ($HaVoC::tkLimit / tkMultiple / tkServerLvl / tkClientLvl) are
// not listed: this mod's game.cs never calls the HaVoC team-kill counter, so they do nothing.

// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Not part of NIHILITY 1.4.3.
// Functions the mod calls but has in no release (each call printed "Unknown command" in 2002).
// ---------------------------------------------------------------------------------------------

// The mod's game.cs is older than its admin.cs / server.cs and lacks the two tournament functions
// they call. Server::onClientDisconnect calls CheckTourneyMatchStart on every disconnect, and so
// does the game's own observer.cs when a player presses FIRE to ready up. Stock function.
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

// Admin::startMatch ("Start the match" in the admin menu, and the "start the match" vote)
// announced "Match start countdown forced by ..." and then called this function, which the mod
// does not have, so nothing started. Admin::startMatch only calls it when no countdown is running
// and the match has not started. Unlike the stock function this one does not push players who
// are still on the "Pick a team" menu into observer through processMenuInitialPickTeam: this
// mod's copy of that handler starts a countdown of its own, and the match start would then run
// twice. They keep the menu and can still pick a team.
function Game::ForceTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.notready = "";
      %cl.notreadyCount = "";
      bottomprint(%cl, "", 0);
   }
   Server::Countdown(30);
}

// game.cs was borrowed from the Insomniax mod and still calls two of its hooks (on every join of
// an auto-assigned player, and on every team kill). Empty functions: same behaviour as 2002,
// without the log line per call.
function Insomniax_joinGame(%clientId)
{
}

function Insomniax_setTeamKill(%playerId, %killerId)
{
}

// admin.cs is HaVoC 1.55's and calls HaVoC helpers that live in HaVoC's own server.cs and
// player.cs, which NIHILITY replaced. The two message functions are HaVoC 1.55's, unchanged: they
// are the only announcement of "X has given Admin Status to Y", of a removed admin and of a
// forced vote, and they write that line to the host log.
function hvcAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isSuperAdmin) { Client::sendMessage(%pl, 0, %msg); } } }

function ixAdminMsg(%msg) { echo("SERVER: " @ %msg); %numPlayers = getNumClients(); for(%i = 0; %i < %numPlayers; %i++) { %pl = getClientByIndex(%i); if(%pl.isAdmin) { Client::sendMessage(%pl, 0, "SERVER: " @ %msg); } } }

// doneposs ("stop possessing / stop watching") is called on every team change. HaVoC's version
// undoes its Watch and Possess cameras; here only the possession half can be active (Watch is
// switched off in admin.cs, see fixes.json), and "Stop Possession" restores both players itself.
// Empty: same behaviour as 2002, without the log line per team change.
function doneposs(%clientId)
{
}
