// Paintball Mod v2.6 (patched 2004-05-20) -- Modern Tribes (1.50) entry script.
// By |K0RN| with [RR]MisterPibb; reworked for 2.6 by KingTomato.
//
// Original launch line (README.TXT):
//    InfiniteSpawn.exe *tribes -mod Paintball +exec ServerPrefs.cs -dedicated
// ServerPrefs.cs is the server's own config\ServerPrefs.cs; the client loads it by itself.
// Nothing else was exec'd from the command line: scripts\server.cs loads the mod when a server is
// created (admin.cs first, which reads the settings file KT_Paintball.cs).
//
// Server owners:
//   KT_Paintball.cs next to this file holds every setting. A copy in config\ wins over this one
//   (the original setup.bat made that copy; do it by hand if you want your settings to survive a
//   reinstall of the pack).
//   Admin accounts go in config\ServerPrefs.cs, as the README says:
//      $PB::Admin::Pass[Super, "password"] = "username";      (or Public)
//   Client spending (accounts and money) is ON by default; it writes config\Money.cs and
//   temp\Money_User<n>.cs.  Close a dedicated server with  shutdown();  so accounts are saved.
//   The clone scanner and join log write config\ClonesList.cs and config\ServerLog.cs.
echo(">> Paintball Mod v2.6 (|K0RN|, [RR]MisterPibb, KingTomato; 2004-05-20 patch)");
