// Renegadez 1.1 by [[DD]] Nemesis -- Modern Tribes (1.50) entry script.
// This is the author's config\Renegadez.cs. The owner / admin / public password lines and the
// owner name are switched off (//PORT-OFF:): set your own admin password in the game's host
// settings. config\AdminUserList.cs (auto-admin by name and IP mask) is not shipped.
// Launch here:  -mod Renegadez
echo(">> Renegadez 1.1");

////////////////////////////////////////////////////
//  Weather Control Stuff
////////////////////////////////////////////////////
$RandomEvents = "True";			//"True" Turns on random events, "False" Turns off random events
	$RandomEventTime=30;		//Seconds between random events
	$RandomTimeVariance = 0; 	//0 = no variance, 0.5 = 50% time variance, 1.0 = 100% time variance
	
	//Occasional Meteor Storms
	$Meteor="False";
		$MeteorDensity=1;  	//1 = normal, 0.5 = half as many meteors.
		$MeteorDuration = 120; 	//Seconds that the meteor storm lasts
		$MeteorAreaVariance = 0;//0 = Meteor count does not vary with land area for each map. 1= directly proportional to map area
		$MeteorWeight = 5;	//Used to determine the frequency of meteor storms relative to the other effects
		
	//Occasional radiation flares
	$SolarFlare="False";
		$SolarFlareDuration = 30;	//Time in seconds that the solar flare lasts.
		$SolarFlareWeight = 10;		//Used to determine the frequency of solar flares relative to the other effects
	
	//Occasional Lightning
	$Lightning="True";
		$LightningDensity=1;  	//1 = normal, 0.5 = half as many strikes.
		$LightningDuration = 60; 	//Seconds that the lightning storm lasts
		$LightningAreaVariance = 0;	//0 = Lightning strike count does not vary with land area for each map. 1= directly proportional to map area
		$LightningWeight = 10;   	//Used to determine the frequency of lightning storms relative to the other effects
	


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
$Reneg::VoteWeather = "true";	    // Allows voting for Weather Control
$Reneg::BaseAddons = "true";	    // Allows voting for Base Addons
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
$Reneg::PAWeather = "true";	    // Allows PublicAdmins to enable/disable weather controls

///////////////////////////////////////////////////////////////////////////////////////////////
//Anti-BaseRape Function if its set to "True" then theres rape if "False" then theres no Rape /
///////////////////////////////////////////////////////////////////////////////////////////////
$BaseRapeDamage = "true";   // Added by Zed
///////////////////////////////////////////////////////////////////////////////////////////////
//Just like it says Spawn Match this disables and enables the invetorys u can still use ammo stations
                        // set to False means no spawn match true means u have a spawnmatch
$SpawnMatch = "false"; // Added by Zed
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//this is the welcome message when u join the mod make sure u dont change the <f0> <f1> or <f2> as there the color that stuff displays
//>>>>>NOT USED ANYMORE<<<<<
//$Reneg::JoinMOTD = "<f0>Welcome to <f2>Renegadez <f0> If u have questions. Then email me <f2>Nemesis@planetdd.com<f1>\n\nMash your fire button to play";
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// this is the server name dont change the <f0> Server line or it will not show up on the welcome message
$Reneg::HostName = "[[DD]]<f0> Server";
//
///////////////////////////////////////////////////////////////////////////////////////////////////
// This is where u set your spawn boosters up at set at 1, 2 , or 3
$Reneg::Beacon = 3;
////////////////////////////////////////////////////
// General game play and server settings
////////////////////////////////////////////////////


$Reneg::tkClientLvl = "1";
$Reneg::tkLimit = "3";
$Reneg::tkMultiple = "3";
$Reneg::tkServerLvl = "3";
$BaseAddons = "True";

$Reneg::BanKickTime = "600";
$Reneg::fairTeams = "true";

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$Reneg::OutOfAreaDamage = false;
/////////////////////////////////////////////////////////////////////////////////////////////////////
//Renegades Server rules this is a new feature try it out let me know how u like it **|SKB| Steve M requested something like this
// if u see him tell him thanks it is a great idea
// Rules list
        // U cant put anything in the last rules line it mush look like this ("";)
        // if u want it to center your print on the screen add <jc> tag to the front of the line
        // added by Zed
$Reneg::rules[0] = "<JC>Server rules for this server\\n\\n";
$Reneg::rules[1] = "RULE #1. Dont be a DICK!\\nReason: We are here for fun, Dont be the one that ruins that.";
$Reneg::rules[2] = "RULE #2. Respect everyone in the server... Treat others like u want to be treated.";
$Reneg::rules[3] = "RULE #3. Base Rape is part of the game if u dont like it GET D UP FAST!!!\.";
$Reneg::rules[4] = "These nexts ones are suggestions on behavior, they are not rules ";
$Reneg::rules[5] = "Guideline #1 - Keep the Spawn sniping  to a minimun.\\n also Spawn Mining ";
$Reneg::rules[6] = "Guideline #2 - Do not BASE RAPE if there is very few players .";
$Reneg::rules[7] = "Guideline #3 - Don't spam the your taunts if we see it once we know u have it thats good enuf ";
$Reneg::rules[8] = "Guideline #4 - Newbies are part of the game Help them out u were there at one time also.";
$Reneg::rules[9] = "<jc> www.planetdd.com";
$Reneg::rules[10] ="";

//////////////////////////////////////////////////////////////////////////////////////////////
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
$Reneg::SpawnClass = true;


////////////////////////////////////////////////////
//Logging Options
////////////////////////////////////////////////////

//Set to 1 if you want to enable the ban/kick by name, on player connect.  Make sure to set
//up your list in the config\\BBNList.cs
$BanByName::IsOn = 1;

//This will change the console output.  If set to 1, will set the console back to the original
//output in version 2.0 so that older versions of Tricon will work.  If set to 2, it will use 
//the same echoing as it does in 3.0.  Setting 3 is a minimum setting that will only echo chat,
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
$Reneg::StationTime = "15";  //range is 10-60
////////////////////////////// station time is now also on the fly
$PA::noKick = "True";  //if set to true, public admins cant be kicked by a vote

//Special message for the owner when you gain super admin
//status with the SAD code and reports this name in the server info menu
//PORT-OFF: $Owner::Name (value not shipped)

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

//PORT-OFF: $OwnerPassword (value not shipped)
//PORT-OFF: $AdminPassword (value not shipped)
//PORT-OFF: $PublicPassword (value not shipped)

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops, 
//objective captures, destroyed objects.....etc.
$StatTrack = true;


