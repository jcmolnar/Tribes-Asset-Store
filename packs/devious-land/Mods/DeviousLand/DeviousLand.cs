// DeviousLand v1.46 by Mojica (misterdevious, Brian Waibel), March 1999 -- Modern Tribes (1.50)
// entry script.
//
// Original launch line (readme.txt): "Tribes.exe -mod deviousland", the mod being one scripts.vol.
// Here it is  -mod DeviousLand  and the scripts are loose under scripts\. Nothing has to be
// exec'd: scripts\server.cs loads the mod when a server is created.
//
// The mod has four teams with their own armors, weapons and vehicles. What a team may buy is
// decided by the NAME of the team ("TeamTags"), so the names below must be spelled exactly:
//    Vandals   Empire   Arbiters   Insatiable
// The release set them in its own serverDefaults.cs, which is not shipped (under 1.50 it would
// replace the host's defaults). DeviousLand::seedTeams() does the same job; scripts\server.cs
// calls it when a server is created.
//
// Server owners: to choose which team plays as team 0 / team 1, set the names yourself, e.g.
//    $Server::teamName[0] = "Arbiters";  $Server::teamName[1] = "Insatiable";
// (console, autoexec.cs or your server prefs). When team 0 or team 1 already carries one of the
// four names, nothing is changed here. Skins follow the names at every match start
// (Vandals green, Empire orange, Arbiters purple, Insatiable beagle).
echo(">> DeviousLand v1.46 (Mojica, 1999) -- 1.50 port entry");

function DeviousLand::isTeamName(%n)
{
   return %n == "Vandals" || %n == "Empire" || %n == "Arbiters" || %n == "Insatiable";
}

function DeviousLand::seedTeams()
{
   if(DeviousLand::isTeamName($Server::teamName[0]) || DeviousLand::isTeamName($Server::teamName[1]))
      return;
   // the eight entries of the release's serverDefaults.cs, unchanged
   $Server::teamName[0] = "Vandals";
   $Server::teamSkin[0] = "green";
   $Server::teamName[1] = "Empire";
   $Server::teamSkin[1] = "orange";
   $Server::teamName[2] = "Arbiters";
   $Server::teamSkin[2] = "purple";
   $Server::teamName[3] = "Insatiable";
   $Server::teamSkin[3] = "beagle";
   $Server::teamName[4] = "Arbiters";
   $Server::teamSkin[4] = "purple";
   $Server::teamName[5] = "Empire";
   $Server::teamSkin[5] = "orange";
   $Server::teamName[6] = "Insatiable";
   $Server::teamSkin[6] = "beagle";
   $Server::teamName[7] = "Vandals";
   $Server::teamSkin[7] = "green";
   echo("DeviousLand: team names set to Vandals / Empire / Arbiters / Insatiable");
}
