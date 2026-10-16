// Ultra Renegades VXO Release 1.0 by Nimec (2002, "VXO Release 1 for OZ") -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXO). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs ...). The archive held only
// VXO\scripts.vol: no readme, no launch line and no settings file, so every switch of the
// mod's "God Controls" menu started unset (= locked). The public votes are switched ON below
// (the values the successor mod, VX Extreme, shipped in its ServerConfig.cs); each line only
// sets a value the host has not set. A super admin can change them in the Tab menu
// ("VXO Admin: God Ctrls"); the mod does not save them, so put your own values in
// config\autoexec.cs to keep them.

// Public votes (Tab menu, "Voting Options" and "Vote to kick"). false = that vote is locked.
if($ultra_renegades::PVMission == "")     $ultra_renegades::PVMission = "true";      // change mission
if($ultra_renegades::PVTeamDamage == "")  $ultra_renegades::PVTeamDamage = "true";   // team damage
if($ultra_renegades::PVFairTeams == "")   $ultra_renegades::PVFairTeams = "true";    // fair teams
if($ultra_renegades::PVTourneyMode == "") $ultra_renegades::PVTourneyMode = "true";  // tourney / FFA mode
if($ultra_renegades::PVKick == "")        $ultra_renegades::PVKick = "true";         // kick a player

// Admin log-on (the SAD password box) is OFF until the host sets a password of their own, for
// example in config\autoexec.cs:
//     $AdminPassword      = "something only you know";   // super admin ("VXO Admin")
//     $MatchAdminPassword = "another one";               // match admin
// No password ships with this pack. The host's own (listen-server) client is super admin.

echo("Ultra Renegades VXO R1.0 (UltraVXO) settings loaded.");
