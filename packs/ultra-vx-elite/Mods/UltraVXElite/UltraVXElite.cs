// Ultra Renegades VX-Elite by Armageddon and WorstAim (August 2005) -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXElite). The mod itself is the
// flat script set in scripts\ (its own server.cs, admin.cs, item.cs ...). The original launch
// line was "InfiniteSpawn.exe *tribes -mod URVX-E -dedicated"; its settings file was
// config\VXEliteConfig.cs, which admin.cs execs every time the server starts. A clean copy is
// next to this file (Mods\UltraVXElite\VXEliteConfig.cs): the ADMIN PASSWORDS go there.
// The archive's copy opened a telnet console (port 6666, password "changeme") and carried
// four default admin passwords; none of that is stamped by this pack.
//
// Admins log on from chat:   !sad <password>
// Other chat commands:       !help   (and docs\Commands.txt)

echo("Ultra Renegades VX-Elite (UltraVXElite): settings are in Mods\\UltraVXElite\\VXEliteConfig.cs");
