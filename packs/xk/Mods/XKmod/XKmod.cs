// {|XK|} Mod Beta 1.4.5 (Xtreme Knights; Neo{|XK|} and King Shit{|XK|}, November 2000; built on
// Renegades Alliance) -- Modern Tribes (1.50) entry script AND the mod's settings file.
//
// Original install (XK Readme.txt): "Make a new folder in your main Tribes directory called
// XKmod ... C:\Dynamix\Tribes\Tribes.exe *tribes -mod XKmod". Launch now:
//     -mod XKmod
// The original XKmod.cs sat next to Scripts.vol and held the settings below; the mod's server.cs
// and game.cs exec it again at every mission load ("exec(XKmod)"), so a setting changed from the
// Tab menu lasts until the next map. A copy of this file in config\ wins over this one and
// survives a reinstall of the pack.
//
// Changed for this port (everything else is the original file, comments included):
//   * $TelnetPort = 28001 with an EMPTY $TelnetPassword was shipped switched on: removed.
//   * $AdminPassword = "t" was shipped (one letter = super admin for anyone who typed it): the
//     line is commented out. An empty password is never accepted.
//   * $StatTrack, $ConOutput, $ConnectLog, $ExportAKicks, $ExportCKicks, $ExportAdmin,
//     $ExportAdminPun, $BanByName::IsOn, $XKmod::OutOfAreaDamage, $XKmod::PADetongue,
//     $XKmod::PABlowUp, $XKmod::PAStripVoteRights and $XKmod::PAareaDamage are read by no script of
//     this version (they come from a later Insomniax settings template). They are kept so an old
//     settings file can be pasted over this one.

$XKmod::BanKickTime = "600";
$XKmod::fairTeams = "true";
$XKmod::PABan = "false";
$XKmod::PAKick = "true";
$XKmod::PAMission = "true";

$XKmod::PADetongue = "true";        //Allows PublicAdmins to have the ability to detongue someone
$XKmod::PABlowUp = "true";           //Allows PublicAdmins to have the ability to blowup someone
$XKmod::PAStripVoteRights = "true"; //Allows PublicAdmins to have the ability to strip someones ability to vote
$XKmod::PAModOptions = "false";
$XKmod::PAResetDefaults = "true";
$XKmod::PATeamChange = "true";
$XKmod::PATeamDamage = "true";
$XKmod::PATeamInfo = "false";
$XKmod::PATimelimit = "false";
$XKmod::PATourneyMode = "false";
$XKmod::PAVote = "false";
$XKmod::PAareaDamage = "false"; //must turn on PAModOptions also; allows PubAdmins to toggle Out of Area Damage
$XKmod::tkClientLvl = "1";
$XKmod::tkLimit = "3";
$XKmod::tkMultiple = "3";
$XKmod::tkServerLvl = "3";

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$XKmod::OutOfAreaDamage = false;

//Set to 1 if you want to enable the ban/kick by name, on player connect.  Make sure to set
//up your list in the config\\BBNList.cs
$BanByName::IsOn = 0;

//This will change the console output.  If set to 1, will set the console back to the original
//output in version 2.0 so that older versions of Tricon will work.  If set to 2, it will use
//the same echoing as it does in 3.0.  Setting 3 is a minimum setting that will only echo chat,
//kill messages, who starts a vote, and general server echos.
$ConOutput = 2;

//logs the name and IP of everyone who connects, to config\\Connect.log
$ConnectLog = false;

//log people who are kicked by admins, to config\\KickList.log
$ExportAKicks = false;

//log people who are kicked by the computer, to config\\KickList.log
$ExportCKicks = false;

//log everyone who is auto-admined to config\\AdminLog.log
$ExportAdmin = 0;

//log all admins punishments applied to players to config\\AdminPunish.log
$ExportAdminPun = 1;

//What you want it to say when an admin kicks a client, this is a centerprint message
//The "\n" will seperate lines of text on the screen... Example....
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the dumbass.";

//If you want to see your personal skins.  The skins must be installed in your(clientside)
//tribes\base\skins directory, and set this option to true.
$XKmod::PersonalSkin = "true";

//When set to true, no one can blow you out of ANY stations
//I wouldn't set this unless you have the station kick on also.
//Without the station kick, they can tie up a station for the rest of the game
//if they want, and nothing will blow them out!!
//If the person gets blocked in so that the station kick function can't
//kick them out, THEN you can shoot them out of the station, but not before.
$StationLockTD = "true";  // no knock from station with teamdamage off
$StationLockNTD = "true";  // no knock from station with teamdamage on

//How long the server will wait before ejecting someone out of a inventory station.  This
//only works when there are more then 3 people in the game
$XKmod::StationTime = "30";  //range is 10-60

$PA::noKick = "True";  //if set to true, public admins cant be kicked by a vote

//Special message for the owner when you gain super admin
//status with the SAD code and reports this name in the server info menu
$Owner::Name = "";

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

$OwnerPassword = "";
// $AdminPassword = "";   // the original line read "t". Left to the host's own server settings so
                          // that this file (re-run at every mission load) does not wipe it.
$PublicPassword = "";

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops,
//objective captures, destroyed objects.....etc.
$StatTrack = true;
