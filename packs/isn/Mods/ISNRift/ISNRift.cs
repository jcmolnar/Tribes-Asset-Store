// ISN Rift 4.0a 'beta' (25-10-2000) -- Internet Starsiege Network Modifications
// (TF)Ryath, (TF)SlayerMonk; built on the Dynamix "Plus" mod 1.1.
// Entry script for the Modern Tribes client (1.50).
//
// Original launch line (readme.txt):   tribes.exe -mod ISNRift
// The 2000 release had no settings file of its own. Its scripts.vol carried a copy of the
// stock serverDefaults.cs with two additions; that copy is not shipped (its master-server
// list is dead and it would replace the 1.50 defaults), and the two additions live here.
echo("ISN Rift 4.0a beta -- 1.50 port entry");

// serverDefaults.cs of the mod: 6 second invulnerable period after a respawn
$Server::respawnInvulnerableTime = 6;

// serverDefaults.cs of the mod: text shown on the joining client's loading screen
$MODInfo = "<f2>ISN Rift Mod v4.a Beta \nI N T E R N E T  S T A R S I E G E  N E T W O R K\nM O D I F I C A T I O N S\n<f1>Modified by (TF)Ryath and (TF)Slayer Monk\n<f2>http://www.tribes-universe.com/isn";
