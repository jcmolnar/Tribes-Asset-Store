// GundamWvx1 (Gundam Wing mod "vx1" by LoD|ZechsMerqise, March 2001) -- Modern Tribes (1.50)
// entry script.
//
// The original was started with:   Tribes.exe -mod GundamWvx1 [-dedicated]
// (the two shortcuts in the archive; ReadMe.txt: "Unzip the GundamWvx1 folder in your
// c:\dynamix/tribes folder"). Nothing else was exec'd: the game's own console.cs loads server.cs
// and game.cs from this mod's scripts folder, server.cs execs serverLink.cs, and that execs
// serverStarCraft.cs (armours, weapons, packs, deployables, vehicles). The mod is built on
// Starsiege Craft 1.19 and keeps its file names.
//
// This file runs after the mod's server.cs / game.cs have loaded. It only adds functions the mod
// calls but does not have (each one printed "Unknown command" on the 2001 server).
echo(">> GundamWvx1 by LoD|ZechsMerqise");

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

// PORT FIX: Admin::startMatch (Tab > "Start the match", and the "start the match" vote) announced
// "Match start countdown forced by ..." and then called this function, which the mod does not
// have, so nothing started. Unlike the stock function this one does not push players who are
// still on the "Pick a team" menu into observer through processMenuInitialPickTeam: this mod's
// copy of that handler starts a countdown of its own. They keep the menu and can still pick.
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

// PORT FIX: game.cs was borrowed from the Insomniax mod and still calls two of its hooks (every
// join of an auto-assigned player, every team kill); armorScout.cs still calls the Warhammer 40k
// "Steal" hook each time anything touches that armour. None of the three exists in this mod or in
// any Starsiege Craft release. Empty functions: same behaviour as 2001, without the log lines.
function Insomniax_joinGame(%clientId)
{
}

function Insomniax_setTeamKill(%playerId, %killerId)
{
}

function Steal(%targetPlayer, %sourcePlayer)
{
}

// PORT FIX: the Gundam author removed Starsiege Craft's command-laptop pack (packCommand.cs) and
// satchel charge (deploySatchelCharge.cs) but deployTeleporter.cs, turret.cs and armorSpy.cs
// still call into them. A call to a function that does not exist returns "False", which is what
// these return or do: nobody has a laptop (the item no longer exists), the two message helpers
// are Starsiege Craft's own, and the Spy beacon key does nothing, as on the 2001 server.
function Laptop::IsAvailable(%player)
{
   return false;
}

function Laptop::Error(%client, %msg)
{
   Client::sendMessage(%client, 0, "Laptop Err: " @ %msg @ "~waccess_denied.wav");
}

function Laptop::Output(%client, %msg)
{
   Client::sendMessage(%client, 0, "Laptop: " @ %msg);
}

function DeploySatchel(%client, %player, %item)
{
}

// The mod's missionlist.cs was the stock 1.11 file plus this one function; the stock copy is not
// shipped (the game's own loads), so the function lives here. server.cs calls it only when the
// host sets $RandomMissions (nothing in the mod does).
function MissionList::nextRandom()
{
   %i = floor(getRandom() * $MList::Count);
   return $MList::EName[%i];
}
