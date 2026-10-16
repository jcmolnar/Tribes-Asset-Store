// Renegades 2K ("Renegades 2000", www.tribe-aoa.com/ren2k; files to 1999-10-29) -- Modern
// Tribes (1.50) entry script.
//
// The release was three zips: 2K.zip (alliance.cs + scripts.vol = an October 1999 build of
// Alazane's Alliance engine), Renegades.zip (al_renegades.cs, serverLink.cs, serverRenegades.cs,
// serverRenegades_ItemUsage.cs = the Renegades rule set for that engine) and config.zip. It
// shipped no readme and no batch file; by its file names it ran as two mod folders,
//     -mod alliance -mod al_renegades      (not verified: there is no launch line in the archive)
// Engine and rule set are folded into scripts\ here. Launch:
//     -mod Ren2K
// Settings: Ren2KSettings.cs next to this file (the release's own config file renegades.cs,
// same bytes under a name no other mod uses; loaded at every mission load) and ixUserList.cs
// (admin user list, off). A copy of either in config\ wins over the one here.
echo(">> ");
echo(">> ALLIANCE ENGINE ");
echo(">> ");
echo(">> ");
echo(">> RENEGADES");
echo(">> ");

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
