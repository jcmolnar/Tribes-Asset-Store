// C&C Tribes V2 -- server settings (added by the Modern Tribes port).
//
// The mod's game.cs loads a file called renegades.cs on every start, but the 2000 release
// never shipped one. This is that file, holding only the settings the mod's scripts read.
// Everything is off / empty by default.

// Admin password. While this is empty nobody can log in as admin with a password
// (the host's own client is always admin). Set it to turn password login on.
$AdminPassword = "";

// true = pick each next map at random instead of following the map rotation.
$RandomMissions = false;
