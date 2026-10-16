// TiZ 1.9 -- "The Infinite Zero Mod" by Michael Cheung (Timer[TiZ]), May 2000.
// Modern Tribes (1.50) entry script. Not part of the original release.
//
// The original was started with (Readme TiZ.txt):
//     C:\Dynamix\tribes\Tribes.exe -mod TiZ
// with everything from the zip in a folder called TiZ. Nothing else was exec'd: the game's own
// console.cs loads server.cs from this mod, server.cs loads serverLink.cs, and that loads the
// item files named in serverRenegades.cs. Launch here is the same:  -mod TiZ
//
// TiZ is built on an early build of Alazane's Alliance engine (by way of the Warhammer 40K mod),
// and the mod was called RavenStorm until it was renamed.
echo(">> ");
echo(">> TiZ 1.9 (The Infinite Zero Mod) ");
echo(">> ");

// The engine's game.cs is built on the Tribes 1.0 game.cs, but its admin.cs and server.cs (and
// the stock observer.cs) come from a later Tribes and call two functions 1.0 did not have yet.
// In the original each call printed "Unknown command": a tournament match could not be started
// by an admin or by everyone pressing fire. Both functions below are the stock ones.
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

// server.cs picks the next map with this when $RandomMissions is set. It came from the mod's
// copy of missionlist.cs, which is otherwise the stock file and is not shipped.
function MissionList::nextRandom()
{
   %i = floor(getRandom() * $MLIST::Count);
   return $MLIST::EName[%i];
}

// armorScout.cs calls Steal() every time a Kraken (Scout) armor touches another player. The
// Alliance engine defines it in armordata.cs (the Scout's pickpocket); TiZ took the function out
// and left the call, which printed "Unknown command" on every contact. Empty on purpose: this is
// what the release did.
function Steal(%targetPlayer, %sourcePlayer)
{
}
