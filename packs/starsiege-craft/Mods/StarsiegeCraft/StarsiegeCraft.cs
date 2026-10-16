// Starsiege Craft "Rogues and Renegades" (version SSCR, Matthias, August 2001) -- Modern Tribes
// (1.50) entry script.
//
// The original was started with:   Tribes.exe -mod SSCR   (readmeSC.txt; the older SSC3 release
// shipped SSC3.bat = "tribes -mod SSC3").  Nothing else was exec'd: the game's own console.cs loads
// server.cs and game.cs from this mod's scripts folder, server.cs execs serverLink.cs, and that
// execs serverStarCraft.cs (armours, weapons, packs, deployables, vehicles) from the mod root.
//
// This file runs after the mod's server.cs / game.cs have loaded. It only adds functions the mod
// calls but never had (each one printed "Unknown command" on the 2001 server).
echo(">> Starsiege Craft: Rogues and Renegades (SSCR)");

// PORT FIX: the mod's game.cs is older than its admin.cs / server.cs and lacks the two tournament
// functions they call. Server::onClientDisconnect calls CheckTourneyMatchStart on every
// disconnect, and so does the game's own observer.cs when a player presses FIRE to ready up.
// This is the stock function.
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

// PORT FIX: Admin::startMatch (Tab > Admin Functions > "Start the match", and the "start the
// match" vote) announced "Match start countdown forced by ..." and then called this function,
// which the mod does not have, so nothing started. Admin::startMatch only calls it when no
// countdown is running and the match has not started. Unlike the stock function this one does not
// push players who are still on the "Pick a team" menu into observer through
// processMenuInitialPickTeam: this mod's copy of that handler starts a countdown of its own, and
// the match start would then run twice. They keep the menu and can still pick a team.
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

// PORT FIX: game.cs was borrowed from the Insomniax mod and still calls two of its hooks (on
// every join of an auto-assigned player, and on every team kill); armorScout.cs still calls the
// Warhammer 40k "Steal" hook each time anything touches a Scout. None of the three exists in any
// Starsiege Craft release. Empty functions: same behaviour as 2001, without the log line per call.
function Insomniax_joinGame(%clientId)
{
}

function Insomniax_setTeamKill(%playerId, %killerId)
{
}

function Steal(%targetPlayer, %sourcePlayer)
{
}
