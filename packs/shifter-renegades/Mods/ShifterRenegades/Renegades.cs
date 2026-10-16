////////////////////////////////////////////////////
// Voting options for any client:
////////////////////////////////////////////////////

$Reneg::VoteKick = "true";          // Allows voting for kicking a player
$Reneg::VoteTD = "true";            // Allows voting for team Damage
$Reneg::VoteTourney = "true";       // Allows voting for tournement mode
$Reneg::VoteMission = "true";       // Allows voting for mission change
$Reneg::VoteOoADamage = "true";     // Allows voting for Out-of-Area damage
$Reneg::VoteTimeLimit = "true";     // Allows voting for time limit
$Reneg::VotePA = "false";           // Allows voting for public Admins
////////////////////////////////////////////////////

////////////////////////////////////////////////////
// Public Admin abilities:
////////////////////////////////////////////////////

$Reneg::PAMission = "true";         // Allows PublicAdmins to change the mission
$Reneg::PABan = "false";            // Allows PublicAdmins to ban a player
$Reneg::PAKick = "true";            // Allows PublicAdmins to kick a player
$Reneg::PADetongue = "true";        // Allows PublicAdmins to detongue someone
$Reneg::PABlowUp = "true";          // Allows PublicAdmins to blowup someone
$Reneg::PAStripVoteRights = "true"; // Allows PublicAdmins to strip someones ability to vote
$Reneg::PAOoADamage = "true";       // Allows PublicAdmins to change out-of-area damage
$Reneg::PAModOptions = "false";     // Allows PublicAdmins access to the server options menu
$Reneg::PAResetDefaults = "true";   // Allows PublicAdmins to reset the server to default settings
$Reneg::PATeamChange = "true";      // Allows PublicAdmins to change a players team
$Reneg::PATeamDamage = "true";      // Allows PublicAdmins to enable/disable team damage
$Reneg::PATeamInfo = "false";       // Allows PublicAdmins to change the team name and default skin
$Reneg::PATimelimit = "false";      // Allows PublicAdmins to change the time limit
$Reneg::PATourneyMode = "false";    // Allows PublicAdmins to enable/disable tournement mode

////////////////////////////////////////////////////


////////////////////////////////////////////////////
// General game play and server settings
////////////////////////////////////////////////////


$Reneg::tkClientLvl = "1";
$Reneg::tkLimit = "3";
$Reneg::tkMultiple = "3";
$Reneg::tkServerLvl = "3";

$Reneg::BanKickTime = "600";
$Reneg::fairTeams = "true";

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$Reneg::OutOfAreaDamage = false;


// settings are 0, 1, or 2   
// Setting 0 will load the map specified in your serverprefs.cs after a server crash(normal)
// Setting 1 will load the same map you were playing after a server crash
// Setting 2 will load the next map you would play after a server crash
// You must add the following line to your autoexec.cs file when using 
// settings 1 and 2:    exec("startmission.cs"); and of course make sure the
// startmission.cs file is in your config directory.
// Make sure you delete that entry in your autoexec.cs when the setting is 0
$Reneg::crashMission = 0;

//Set this to true, to enable Weapons Factory
$Reneg::SpawnClass = false;


////////////////////////////////////////////////////
//Logging Options
////////////////////////////////////////////////////

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

////////////////////////////////////////////////////


//What you want it to say when an admin kicks a client, this is a centerprint message
//The "\n" will seperate lines of text on the screen... Example....
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the dumbass.";

//If you want to see your personal skins.  The skins must be installed in your(clientside)
//tribes\base\skins directory, and set this option to true.
$Reneg::PersonalSkin = "true"; 

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
$Reneg::StationTime = "30";  //range is 10-60

$PA::noKick = "True";  //if set to true, public admins cant be kicked by a vote

//Special message for the owner when you gain super admin
//status with the SAD code and reports this name in the server info menu
$Owner::Name = ""; 

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

$OwnerPassword = ""; 
$AdminPassword = "";
$PublicPassword = "";

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops, 
//objective captures, destroyed objects.....etc.
$StatTrack = true;



////////////////////////////////////////////////////
// PORT (Shifter Renegades): names this older Renegades fork reads and the file above does not set
////////////////////////////////////////////////////
$Reneg::PAVote = "false";        // players may start a vote to admin someone
$Reneg::PAareaDamage = "true";    // public admins may switch out-of-area damage
$ExportSAD = 0;                  // 1 = log every admin password ATTEMPT, in clear text, to config\SAD.log
