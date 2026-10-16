// NAPPY 6 ("NappyMod", by [NHOP]Smokey, nappybase.com; scripts.vol dated 2003-08-09, NAPPY.cs
// 2004-04-01) -- Modern Tribes (1.50) entry script.
//
// Original launch line (the release's "NAPPY 6 Non-Dedicated Server" shortcut):
//     Tribes.exe -mod NappyMod +exec ServerConfig
// ServerConfig.cs was a sample HOST config (server name, port, admin and telnet passwords); it
// is not part of the mod and is not shipped. Here the launch is
//     -mod NappyMod
// The mod's own settings are loaded by its server.cs when the server is created, exactly as in
// the original:
//     NAPPY.cs            every $Nappy::* switch (builder mode, logs, flood limits, admin rights)
//     Nappy_Passwords.cs  admin passwords (all blank = switched off)
// Both sit next to this file; a copy in config\ wins over them.
echo(">> ");
echo(">> NAPPY 6 (NappyMod) ");
echo(">> ");
