// Ultra Renegades VX6 Infinite by Armageddon and WorstAim (2005) -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVX6). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...). The archive documents no
// launch line; its settings file was Config\VX6Config.cs, which admin.cs execs every time the
// server starts. A clean copy is next to this file (Mods\UltraVX6\VX6Config.cs): the ADMIN
// PASSWORDS go there. The archive's copy was one real server's file (host name, MOTD, team
// names, a telnet line with a syntax error); none of that is stamped by this pack.
//
// Admins log on from chat:   !sad <password>     (the admin password box only answers with a hint)
// Other chat commands: docs\Commands.txt.

// Name used for the exploit log (config\<name>_Exploits.log). The original never set it.
if($ModName == "") $ModName = "VX6";

echo("Ultra Renegades VX6 Infinite (UltraVX6): settings are in Mods\\UltraVX6\\VX6Config.cs");
