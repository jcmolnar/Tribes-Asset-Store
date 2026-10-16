//-----------------------------------------------------------
// Foundation Mod II by ProtoManX (2005-2006), built on Foundation Mod by Nicodemus (2000)
// -- entry script for the Modern Client (1.50)
//
// Foundation II is stock Tribes taken apart for mod makers: every armour, weapon, pack,
// deployable, station, turret, sensor and vehicle lives in its own file under scripts\<kind>\,
// and scripts\scripts\simplifierFunctions.cs holds the helper functions the readme lists
// (setDamageScale, setArmorItemMax, addAmmo, addToInv, dataReinit, Item::universalDeploy).
// It plays like base Tribes with an admin menu on top (Server Options, Manage, Fun With,
// spawn sets under Personal Settings).
//
// Host:  -mod FoundationII.  The mod's own server.cs replaces base's and execs
// scripts\FoundationIIServer.cs, the list of item files -- add your own items there.
// Clients need nothing installed.
//
// The archive shipped FoundationConfig.cs, which no script loaded (it was meant to be exec'd
// by hand).  It is exec'd here.  Its $FoundationII:: switches are live; its $Server::, $pref::
// and $Telnet lines are switched off (//PORT-OFF:) because the host's own preferences own
// those.  Admin passwords: fill in $FoundationII::Super[n] / $FoundationII::Public[n] in
// scripts\FoundationConfig.cs (all blank as shipped = no password admin).
//-----------------------------------------------------------

exec("FoundationConfig.cs");
echo("Foundation Mod II (ProtoManX) -- 1.50 port entry");
