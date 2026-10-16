// Ultra_Renegades2 by Thrash, with Killjoy (June 1999) -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UR2). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...). The 1999 command line
// was "tribes -mod ultra_renegades2 [-dedicated]"; the readme had the host copy
// ultra_renegades2.cs and "ultra_renegades~1.cs" (the same file twice) into config\, and
// game.cs execs the second name at every mission load. In this port that file is
// Mods\UR2\UR2Settings.cs: the admin lockouts and anti team-kill settings are there.
//
// Remote admin logon is OFF until the host sets a password of their own, for example in
// config\autoexec.cs:   $AdminPassword = "something only you know";
// No password ships with this pack. The host's own (listen-server) client is super admin.

// PORT: this build's server.cs (client disconnect) and admin.cs ("Start the match"), and the
// observer.cs it shares with base (FIRE when ready in Tournament mode), call the two functions
// below, but its game.cs is an older generation that never defined them: every call was an
// "Unknown command" line and a Tournament-mode match could not be started from the ready
// check or by an admin. These are the stock Tribes definitions (base\scripts\game.cs).
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
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
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

echo("Ultra_Renegades2 (UR2): settings are in Mods\\UR2\\UR2Settings.cs");
