// Chivalry v2.0 options -- the values of the release's config\ChivalryPrefs.cs, with two
// changes for this port (marked PORT). The server execs this file by name when it is created;
// a copy in the game's config\ folder is found first, and the mod itself writes one there the
// first time a Warlord or Paladin is crowned. The Chivalry Admin Manual explains every option.
$Chivalry::AllowAdmin = "false";
$Chivalry::AllowTourney = "false";
$Chivalry::FairTeams = "true";
$Chivalry::FriendMines = "true";
$Chivalry::Logging = "true";
$Chivalry::OutOfBounds = "true";
$Chivalry::Pskins = "false";
$Chivalry::RandomTeams = "true";
// SAD1-3: player names that become super admin when they join. PORT: the name must have a
// character password on file from an earlier visit and must give it (Player Setup, last box);
// the release gave the rank for the name alone. "false" = not used.
$Chivalry::SAD1 = "false";
$Chivalry::SAD2 = "false";
$Chivalry::SAD3 = "false";
$Chivalry::Station = "45";
$Chivalry::TkLimit = "3";
$Chivalry::UndeadSkin = "alford";
$Chivalry::TkSkin = "sojdev";
$Chivalry::Grace = "true";
$Chivalry::GraceTime = "4";
$Chivalry::DonCrown = "true";
// PORT: the release named its two authors here ("[CLU]Robear" and "[CLU]Clu"), so that anyone
// using those names had the Paladin's / Warlord's powers on every server. The value below is a
// name nobody can type (it starts with a TAB): there is no Paladin and no Warlord until a super
// admin crowns a player (Tab, Chivalry Options, Enable Ceremony Mode, next mission, select the
// player, Crown). Not left empty: the scripts compare it with the name of whatever made a kill,
// and a turret or a fall has an empty name.
$Chivalry::Paladin = "	nobody";
$Chivalry::Warlord = "	nobody";
$Chivalry::MaxTk = "5";
$MaxVolcMines = "50";
