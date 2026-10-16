// _RaMpAgE_ 2.0 by Armagedon (.:(A):. Anarchy clan), February 2003. "Based off Nappy 4.0".
// Entry script for the Modern Tribes client (1.50).
//
// The mod was started with
//     Tribes.exe -mod _RaMpAgE_ [-dedicated]            (_RaMpAgE_ Must Read.ini, version 1.7)
// and its server.cs loads a settings file from inside createServer:  exec(rampage);
// The 2.0 release is a bare scripts.vol and has no such file; the one below is the settings
// file of the 1.7 release (Rampage.cs, 18 May 2002), whose admin script is the same as 2.0's.
// Under 1.50 the launch is  -mod Rampage  and the loader runs this file
// (Mods\Rampage\Rampage.cs) first; createServer then finds it again by name.
//
// PORT changes to the 1.7 settings:
//  * $TelnetPort = 28001;  and  $TelnetPassword = "";  are commented out (a mod must not open
//    or re-point the remote console of the host).
//  * $AdminPassword = "";  is commented out: it would blank the password a host has set in his
//    own prefs every time a server starts.
//  * $OwnerPassword (the "God admin" password, typed like the admin password) is not set by any
//    shipped file any more: the release hid a default one in admin.cs. Set your own here.
// Game::LowTeam() at the end is a port addition: admin.cs calls it for the Fair Teams menu and
// no Rampage file defines it.
echo("_RaMpAgE_ 2.0 (Armagedon) -- 1.50 port entry");
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// _RaMpAgE_v1.7 By: Armagedon
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//===============================
// Admin settups
//===============================
$XKmod::BanKickTime = "9999";
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
//PORT-OFF: $TelnetPort = 28001;

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$XKmod::OutOfAreaDamage = false;

//Set to 1 if you want to enable the ban/kick by name, on player connect.  Make sure to set
//up your list in the config\\BBNList.cs
$BanByName::IsOn = 1;

//This will change the console output.  If set to 1, will set the console back to the original
//output so that older versions of Tricon will work.  If set to 2, it will use 
//the same echoing as usual.  Setting 3 is a minimum setting that will only echo chat,
//kill messages, who starts a vote, and general server echos.
$ConOutput = 1;

//logs the name and IP of everyone who connects, to config\\Connect.log
$ConnectLog = true; 

//log people who are kicked by admins, to config\\KickList.log
$ExportAKicks = true; 

//log people who are kicked by the computer, to config\\KickList.log
$ExportCKicks = true; 

//log everyone who is auto-admined to config\\AdminLog.log
$ExportAdmin = 1;

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

 

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

//PORT-OFF: $TelnetPassword = "";
//PORT-OFF: $AdminPassword = "";
$PublicPassword = "";

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops, 
//objective captures, destroyed objects.....etc.
$StatTrack = true;

// ---------------------------------------------------------------------------------------------
// PORT (Modern Tribes 1.50). Not part of the original settings file.
// admin.cs ("Change Teams/Observe" with $XKmod::fairTeams on) offers the team Game::LowTeam()
// returns; no Rampage 2.0 / 1.7 script defines it, so the menu offered a team called "False".
// This returns the number of the team with the fewest players.
function Game::LowTeam()
{
   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i++)
      %count[%i] = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %t = Client::getTeam(%cl);
      if(%t >= 0 && %t < %numTeams)
         %count[%t]++;
   }
   %low = 0;
   for(%i = 1; %i < %numTeams; %i++)
      if(%count[%i] < %count[%low])
         %low = %i;
   return %low;
}
