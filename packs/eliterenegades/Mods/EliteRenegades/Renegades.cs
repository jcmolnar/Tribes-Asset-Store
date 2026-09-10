$Reneg::BanKickTime = "600";
$Reneg::fairTeams = "true";
$Reneg::PABan = "false";
$Reneg::PAKick = "true";
$Reneg::PAMission = "true";

$Reneg::PADetongue = "true";        //Allows PublicAdmins to have the ability to detongue someone
$Reneg::PABlowUp = "true";           //Allows PublicAdmins to have the ability to blowup someone
$Reneg::PAStripVoteRights = "true"; //Allows PublicAdmins to have the ability to strip someones ability to vote

$Reneg::PAModOptions = "false";
$Reneg::PAResetDefaults = "true";
$Reneg::PATeamChange = "true";
$Reneg::PATeamDamage = "true";
$Reneg::PATeamInfo = "false";
$Reneg::PATimelimit = "false";
$Reneg::PATourneyMode = "false";
$Reneg::PAVote = "false";

$Reneg::PAareaDamage = "false"; //must turn on PAModOptions also; allows PubAdmins to toggle Out of Area Damage

$Reneg::tkClientLvl = "1";
$Reneg::tkLimit = "3";
$Reneg::tkMultiple = "3";
$Reneg::tkServerLvl = "3";

// When a player mount a weapon or tool, a message will pop up telling the player 
// what weapon\tool is now mounted. Set to "true" if you want to use this feature.
// This feature is automatically disabled when server is in Tournament mode even if set to true here.
$Reneg::HMessage = "false";

// Random mission loading option. Instead of loading missions in the same order all the time, they can 
// now be loaded randomly.
// Just set this option to "true" for it to take effect.
// ELITE RENEGADES PORT (R3): defaulted to "false". Upstream shipped "true", and
// MissionList::nextRandom() does not filter the eight "#_" training maps, so an
// out-of-box server rotates into them -- the situation this mod's own README warns
// about. Set it back to "true" once your mission list excludes the training maps.
$RandomMissions = "false";

//Set this to true, to enable Weapons Factory
$Reneg::SpawnClass = false;

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$Reneg::OutOfAreaDamage = false;

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

//Set to 1 if you want to enable logging everyone who is auto-admined 
//to config\\AdminLog.log
$ExportAdmin = 0;

//Set to 1 if you want to enable logginng all admins punishments applied 
//to players to config\\AdminPunish.log
$ExportAdminPun = 1;

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

//How long the server will wait before ejecting someone out of a inventory station.  
//This only works when there are more then 3 people in the game range is 10-60
$Reneg::StationTime = "30";

//if set to true, public admins cant be kicked by a vote
$PA::noKick = "True";  

//Special message for the owner when you gain super admin status 
//with the SAD code and reports this name in the server info menu
$Owner::Name = ""; 

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

$OwnerPassword = "changeME!"; 
$AdminPassword = "changeMe2";
$PublicPassword = "changeMe3";

//Enables stat tracking in console.  Usage will echo flag caps,  
//returns, drops, objective captures, destroyed objects.....etc.
$StatTrack = true;