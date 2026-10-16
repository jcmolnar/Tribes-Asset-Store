// Proud Man Down 5.0 -- Modern Tribes (1.50) entry script.
//
// Original launch line (readme.txt):  Tribes.exe -mod ProudManDown   (add -dedicated for a server)
// The client's own console.cs loads server.cs, game.cs and sae.cs from this mod's scripts folder,
// and server.cs loads the item list (RipServer.cs), so there is nothing else to chain here.
//
// The 2004 release carried a file with this name inside scripts.vol. It was a settings file left
// over from another mod: none of its $ProudManDown:: values is read by any script, but it set the
// host name, port 28001, the first map and a published admin password. It is not shipped. This
// file takes its place, because the 1.50 loader runs <mod>.cs on every start.
//
// Server owners: there is no settings file. Host name, port, player limit and time limit come from
// your own server settings. To log in as admin from the game, set $AdminPassword yourself (for
// example in config\autoexec.cs); it ships empty, which leaves the password login switched off.
echo(">> Proud Man Down 5.0");
