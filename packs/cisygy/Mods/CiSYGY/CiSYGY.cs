// CiSYGY Server Mod PR1 (Sundiata of CiSYGY, February 1999) -- entry script of the Modern
// Tribes (1.50) port.
//
// The release was a scripts.vol, one map and a readme that says: name the mod directory
// "CiSYGY", i.e.
//    tribes -mod CiSYGY
// Nothing else was exec'd. The volume was a full copy of the Tribes scripts of early 1999; the
// ten that carry the mod are in scripts\ (ArmorData, baseExpData, baseProjData, game, item,
// moveable, nsound, station, turret, vehicle). The other 61 were the stock scripts of that
// Tribes version and are not shipped: the 1.50 server, admin, chat and objectives scripts are used.

echo(">> CiSYGY Server Mod PR1");

// The readme asks every server that runs the mod to show this credit in its message of the day;
// it is put on the joining client's loading screen instead, so a host cannot lose it.
$MODInfo = "<jc><f2>Running CiSYGY Server Mod (PR1) by Sundiata (cisygy.frags.com)\n";

// PORT: the mod's scripts are older than the 1.50 scripts they now sit beside. Four things the
// 1.50 scripts expect from the newer stock game.cs / item.cs are given here, with the stock text.

// 1.50 objectives.cs: seconds a flag carrier has to reach a flag stand (stock value).
$flagToStandTime = 180;

// 1.50 server.cs sends this to every joining client; it keeps the mod's shopping favourites
// apart from the stock list (the mod adds items). scripts\item.cs does not set it.
$ItemFavoritesKey = "CiSYGY";

// 1.50 admin.cs ("Start the match" in tournament mode).
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

// 1.50 observer.cs / server.cs (a tournament player pressed fire, or left). The mod's game.cs
// starts the countdown itself as soon as nobody is still picking a team, so this only has to
// cover the case where that has not happened yet.
function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;

   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
         return;
      if(%cl.observerMode == "pregame")
         %playerCount++;
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
