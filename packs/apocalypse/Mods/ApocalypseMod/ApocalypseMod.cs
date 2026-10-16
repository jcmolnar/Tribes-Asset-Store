//-----------------------------------------------------------
// Apocalypse Mod v1.6 by ProtoManX (2002-2003), built on Foundation Mod by Nicodemus (2000)
// -- entry script for the Modern Client (1.50)
//
// Credits from the author's readme: Ice (Devastor Mod), Creeperman (homing and tractor
// code), Nicodemus (Foundation mod).
//
// Seven armours (Quicksilver, Light, Centurion, Medium, Guardian, Heavy, Apocalypse), each
// with its own beacon / grenade / mine / contact action, about thirty weapons with fire
// modes, twelve packs, nine deployable turrets, bomber and striker vehicles, and an admin
// menu (Server Options, Manage, Fun With, Modules on/off, Melee-only on/off).
//
// Host:  -mod ApocalypseMod.  The mod's own server.cs replaces base's and execs
// scripts\ApocalypseServer.cs, the list of item files.  Clients need nothing installed.
//
// The folder is ApocalypseMod, not Apocalypse: config\apocalypse.cs already exists in the
// client's config folder (searched first) and would be run in place of this file.
//
// The archive shipped apocConfig.cs, which no script loaded (it was meant to be exec'd by
// hand).  It is exec'd here.  Its $Apocalypse:: switches and $StrikeLimit are live; its
// $Server::, $pref:: and $Telnet lines are switched off (//PORT-OFF:) because the host's own
// preferences own those.  Admin passwords: fill in $Apocalypse::Super[n] /
// $Apocalypse::Public[n] in scripts\apocConfig.cs (all blank as shipped = no password admin).
//-----------------------------------------------------------

exec("apocConfig.cs");
echo("Apocalypse Mod v1.6 (ProtoManX) -- 1.50 port entry");
