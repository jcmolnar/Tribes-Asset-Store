// Alliance Engine (Alazane, with Mjolnir, Mephisto and Kevin "Savage1" Savage; files to
// 2000-01-09) -- Modern Tribes (1.50) entry script.
//
// The original was two mod folders: the engine ("Create a alliance subdirectory ... Install one
// of the Alliance mods", Readme.txt) and ONE rule set on top of it:
//     -mod alliance -mod al_base        Base Tribes on the Alliance engine
//     -mod alliance -mod al_pure        Pure Alliance
//     -mod alliance -mod al_renegades   Renegades Alliance
// A rule set is four small files (a serverLink.cs that names it, a load list and an item table)
// and cannot run without the engine, so this pack carries the engine and all three. Launch:
//     -mod Alliance
// and pick the rule set in AllianceSettings.cs ($Alliance::RuleSet = "pure", "base" or
// "renegades"; "pure" when unset). A copy of AllianceSettings.cs in config\ wins over the one
// next to this file and survives a reinstall of the pack.
echo(">> ");
echo(">> ALLIANCE ENGINE ");
echo(">> ");

// What the engine's own serverdefaults.cs told joining clients (that file is otherwise the 1999
// stock one with a dead master-server list and is not shipped).
$MODInfo = "<jc><f2>Alliance\n<f0>Homepage: <f1>http://alazane.surf-va.com/tribes/alliance.html\n";

// The engine's game.cs is built on the Tribes 1.0 game.cs, but its admin.cs, server.cs and
// objectives.cs (and the stock observer.cs) come from a later Tribes and use three things that
// 1.0 game.cs did not have yet. In the original each call printed "Unknown command": a
// tournament match could not be started by an admin or by everyone pressing fire, and a neutral
// flag never timed out. The two functions below are the stock ones; the timer is the stock value.
$flagToStandTime = 180;

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

// The engine's server.cs picks the next map with this when $RandomMissions is set. It came from
// the engine's copy of missionlist.cs, which is otherwise the stock file and is not shipped.
function MissionList::nextRandom()
{
   %i = floor(getRandom() * $MLIST::Count);
   return $MLIST::EName[%i];
}
