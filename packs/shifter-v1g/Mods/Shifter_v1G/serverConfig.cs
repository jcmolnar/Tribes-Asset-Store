//=================================================================================
// Server Config.CS
//=================================================================================
// PORT NOTE (2026-09-12): seed-only. This file is exec'd by the admin menu's
// "Reset Server To Defaults", and by any launcher that does +exec serverConfig.cs.
// Assigning unconditionally would drag the host to this name/port/map whatever the
// Host Game menu actually asked for. Set the value if you want it; leave it and the
// host menu wins.
if($Server::HostName == "")
	$Server::HostName = "Shifter HC Server";		// The name of your
$Server::MaxPlayers = "16"; 				// Max Players On Your Server
$Server::timeLimit = "45";			// Mission Time Limit In Minutes
$Server::Password = "";				// Server Password - for passworded matches
$Server::TeamDamageScale = "1";			// Team Damage On/Off
$noOTurrets = True;
$stronglaser = True;
$redlaser = false;

//============================================================================
//                          Public Notices
//============================================================================
$Shifter::PublicNotice = "";				// This Message will be dispalyed every so ofter as players spawn, leave it null to disable
$Server::Info 		= "Admin: you ICQ#5555555\nEmail: your@address.com\n2 TeamKill KickBan in effect.\nIf you LAG, leave... Don't whine about it.";
$Server::JoinMOTD = "<jc><f1>Welcome to TRIBES Shifter!\nMODs: Shifter - Personal Skins\nIf you LAG, leave... Don't whine about it.\n2 TeamKill kick-ban active.";
$Server::MODInfo 	= "MODS: Shifter . Personal Skins\nGrab our custom skins from http://members.home.com/fubarascain\nEmail Admin for private scrimmage details\nIf you LAG, leave... Don't whine about it.";
$Shifter::WelcomeMsg = "<jc><f2>Welcome to Dopplegangers Inc. Tribes\nMOD: Shifter V1.0 Beta 6-19-99\nServer site:www.dopplegangers.com/tribes\nMission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>2 TeamKill KickBan in effect.\nIf you LAG, leave...  Don't whine. We dont want to hear it!";
$Shifter::WelcomeDelay = "20";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.


//============================================================================
//                         Networking Options
//============================================================================
$Server::FloodProtectionEnabled = "true";	// Check for chat flooding players
$Server::HostPublicGame = "true";		// List your server with the master list.
if($Server::Port == "")
	$Server::Port = "28001";		// Port To Run Server On   (seed-only, see note at top)
$pref::noIpx = "true";				// Disallow IPX/SPX binding
$Server::respawnTime = "2";			// Time after death to respawn.
// PORT NOTE (2026-09-12): disabled. $TelnetPort is live in this engine
// (simTelnetPlugin.cpp) and opens a listening remote console the moment it is set.
// Upstream shipped it on the well-known telnet port with the password "password".
// Engine default is 0 = off. If you genuinely want a remote console, pick a high
// port and a real password before uncommenting it and the password line below.
//$TelnetPort = "23";					// Telnet port number
//$TelnetPassword = "YOUSHOULDCHANGETHIS";			// Telnet password (see note above)
$Console::LogMode = "0"; 	   			// save the console to a logfile, 1 for TRUE
$Shifter::LocalNetMask = "IP:208.188.5";	//== Local IP's (Assuming you have a LAN connection to the server and are not worried about band width from connecting Lan players, You can increase the limit when a player from this IP Mask connects.
$Server::PacketRate = "10";     		// recommended rate for a cable modem
$Server::PacketSize = "200";    		// recommended rate for a cable modem


//============================================================================
//                     Team Names and Default Skins
//============================================================================
$Server::teamName0 = "Emos Executioners";		$Server::teamSkin0 = "cphoenix";
$Server::teamName1 = "Ascains Anhilators";		$Server::teamSkin1 = "swolf";	
$Server::teamName2 = "Dastardlys Devistators";		$Server::teamSkin2 = "beagle";
$Server::teamName3 = "Methods Mutilators";		$Server::teamSkin3 = "dsword";
$Server::teamName4 = "Karayas Kastrators";		$Server::teamSkin4 = "base";


//============================================================================
//                         Mission Settings
//============================================================================
if($pref::LastMission == "")
	$pref::LastMission = "RainDance";	//== Starting Mission if Random Start is off  (seed-only, see note at top)
$Shifter::RandomMissions = True;	//== Random Missions on/off
$Shifter::TeamJuggle = 3;			//== Juggles the teams every X missions
$Server::warmupTime = "10";			// Mission Start Time (Delay before missions starts)
$Shifter::RandomStart = False;		//-- Start server with a Random mission
$Shifter::Refresh = False;		//-- Refresh the server after last player drops 

//============================================================================
//                       Voting Varriables
//============================================================================
$Server::MinVotes = "1";			// Minimum Votes to count
$Server::MinVotesPct = "0.69999";  // Percentage of votes needed to pass a vote
$Server::MinVoteTime = "45";			// Time a vote lasts
$Server::VoteFailTime = "30";			// Length Of Votes if people are NOT voting.
$Server::VoteWinMargin = "0.699999";		// Ratio of Yeh to Neh to win vote.
$Server::VotingTime = "20";			// Length Of Votes if people are voting.


//=========================================================================
//                      Advanced Flag Options
//=========================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";


//=========================================================================
//                     Fair Teams Variables
//=========================================================================
$Shifter::KeepBalanced = True;				//== Keep Balanced
$Shifter::FairTeams = True;  //== Is Fair Teams Is On
$Shifter::FairCheck = "30";  //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "120"; //== Number in seconds that Shifter will move the last connected player to the un even team.


//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================
$Shifter::TeamKillOn 		= "True";	//== Is Anti TK On/Off
$Shifter::KillTerm 		= "1";		//== Number Of Time A Player Can Team Kill Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "1";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "600";	//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "2";		//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "50";        	//== Proximity Distance For Accidental Damage.
$Shifter::TeamKillMsg = "You have been kick and banned for team killing, i hope you enjoyed it. Email:" @ $Shifter::emailAddress @ " for reinstatement.";
$Shifter::emailAddress = "emo1313@dopplegangers.com";	//== Email address to show banned users for reinstatement


//===============================================================
//                Score Kick Options
//===============================================================
$Shifter::ScoreTracker = True;		//== Score Tracker = Warns then Kicks players for having bad scores.
$Shifter::CheckScores = 30;		//== How often to check.
$Shifter::WarnScore1 = "-10";		//== 1st Warning
$Shifter::WarnScore2 = "-20";		//== 2nd Warning
$Shifter::WarnScore3 = "-30";		//== 3rd Warning
$Shifter::WarnScoreFinal = "-40";	//== Kick Player For Crappy Score


//===============================================================
//                Automatic Admin Options
//===============================================================
function AddSad(%name, %pass, %super, %ip)
{
	$Server::Admin["autoa", %name] = 1;
	$Server::Admin["noban", %name] = 1;
	// MODERN-PORT: a blank %ip became "IP:", which prefix-matches EVERY address, so
	// "can be left blank" meant password-free auto admin for anyone using the name.
	if(%ip != "")
		$Server::Admin["ipadr", %name] = "IP:" @ %ip;
	$Server::Admin["sadpw", %name] = %pass;
	$Server::Admin["admin", %name] = 1;
	$Server::Admin["super", %name] = %super;
}

// MODERN-PORT: these shipped LIVE -- the author's name with the password "CHANGETHIS"
// was super admin on every v1G server, and password-free from any 63.202.x.x address.
// Uncomment one with your own name, password and IP prefix.
//addsad("=H|C=Grey Flcn", "CHANGETHIS", 1, "63.202");
//       Name             password   super  IP(can be left blank)
//addsad("=H|C=Grey Flcn", "CHANGETHIS", 1, "63.202");
//addsad("=H|C=Grey Flcn", "CHANGETHIS", 1, "63.202");
//addsad("=H|C=Grey Flcn", "CHANGETHIS", 1, "63.202");


//=============================================================================

//=============================================================================

//=============================================================================

//=============================================================================

//Don't need to mess with this any further

//=============================================================================

//=============================================================================

//=============================================================================

//=============================================================================


// Shifter variables people expect to be this way
$Shifter::PowerCheck = True;			//== If True - Spawns players in Standard armor if power is down
$Shifter::AmmoBoom = True;			//== Players ammo can blow up when killed 
$Shifter::Weapons = True;               //== Advanced Weapon Options On
$Shifter::LockOn = True;				//== Stinger Missle Locks Available
$Shifter::SpawnRandom = True;				//== Turn on Random Spawn Setup?
$Shifter::NoOutside = True;				//== Turn on Outside of mission area damage
$Shifter::TurretKill = True;               //== Turret Kills Count For Player
$Shifter::PersonalSkin = True;				//== Personal Skins On or Off
$Server::AutoAssignTeams = "true";		// Places players on teams automatically
$Shifter::TwoMinute = "True";	// == Two Minute Warning Notice On/Off (Default = True)
$Shifter::LooseScore = 1.00;	// == This is the score ratio for the loosing team. 0.5 for instance would cut a loosing players score by half.
$Shifter::Guided = True;		//== Allow Guided Missile Stations in game?
$Shifter::SpawnType = "Random"; 	//== Must be 'Standard' or 'Random'
$Shifter::SaveOn = True;		//== Allow players to save thier profiles.
$Shifter::SpawnFavs = True;		//== Allow spawn faves
$Shifter::EngHealAll = True;		//== Engineers touch heals objects.
$Shifter::HelpOn = True;		//== Shifter Help On <Tab> menu
$Shifter::SwitchPerm = True;		//== Admin Team Changing Players Is Perminant
$Shifter::NoSwearing="false"; 	// == True means disallow swearing on your server? (update the SHBadwordlist.cs file)
$Shifter::BadWordsMax=3; 	// == If no swearing, This value is the limit at which the client starts being killed for swearing
$Shifter::BadWordskick=4; 	// == If no swearing, This value is the limit at which the client is kicked for swearing
$Shifter::VoteDTD = True;		//== Allow Team Damage Disable Vote
$Shifter::VoteKick = True;		//== Allow Vote to kick
$Shifter::VoteAdmin = False;		//== Can players initiate vote to admin
$Shifter::Reactions = True;		//-- Damage knocks player back
$Shifter::HackedTime = 90;	// -- Time hacked items will remain hacked. 0 = Must be hacked back... - Defults To 90
$Shifter::HackTime = 5;		// -- Length Of Time To Complete Hacking - Defaults To 5
$Shifter::HackLock = 90;	// -- Legth of time a hacked item will be disabled for after being hacked. - Defaults To 0
$Shifter::LaserMineLive = 5;	// -- Live Time For Laser Mines - Defaults To 5 Seconds
$Shifter::ItemLimit = True;	// -- Makes it so that ONLY the armors that can buy a given item can see it in the invo list.
$Shifter::DetPackLimit = 15;	// -- Limit of DetPacks per match
$Shifter::NukeLimit = 15;	// -- Limit of Nukes per match
$ScoreOn = True;		    	//== If True will show client thier score on change in a bottom print message for 3 seconds.
$Shifter::HeadShot = 5;			//== Bonus for Head Shots
$Shifter::KillTime = 120;		//== Starting timer for kill -vs- live time bonuses, the longer a player lives the higher the bonus. Bonus counting does not start UNTIL this many seconds after player spawns.
$Score::25Meters = "5";     		//== Less Than 25 Meters To Flag
$Score::75Meters = "3";     		//== From 25 to 75 Meters
$Score::150Meters = "2";    		//== From 75 to 150 Meters
$Score::250Meters = "1";    		//== From 150 to 250 Meters
$Score::FlagCapture = "15";		//== Points For A Successful Flag Capture 
$Score::FlagKill = "7";  		//== Bonus For Killing Flag Runner
$Score::FlagDef  = "3";   		//== Bonus Points For Defending The Runner
$Score::FlagReturn = "3";   		//== Points For Returning Dropped
$Score::CaptureOdj = "2";   		//== Points For Capturing An Objective
$Score::HoldingObj = "5";   		//== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = "2";   		//== Points For Getting The Objective First
$Score::ObjDestroy = "15";      	//== Objective Destroyed
$Score::ObjStationS = "7";      //== Destroy Supply Station 
$Score::ObjStationA = "5";      //== Destroy Ammo Station or Command
$Score::ObjStationR = "3";      //== Destroy Remote Station
$Score::ObjFlier = "3";         //== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "10";   //== Destroy Large Generator
$Score::ObjGeneratorS = "5";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors
$Score::ObjTurretL = "3";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets
$Score::Kill15Meters = "0";	//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";	//== Kill From 15 to 50m
$Score::Kill100Meters = "1";	//== Kill From 50 to 100m
$Score::Kill250Meters = "2";	//== Kill From 100 to 250m
$Score::Kill250Plus = "3";	//== Kill 250m Or More
$Score::RepairObject = "1";     //== Repair Bonus. Base Points For Repair...
$Shifter::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========== Master Server Listing (Dont frell with this).
$Server::CurrentMaster = "0";
$Server::numMasters = "3";
$Server::Master1 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::Master2 = "IP:BROADCAST:28001";

// PORT NOTE (2026-09-12): the whole master-server block is commented out. Every host
// here is a Dynamix machine that has been dead for two decades, or a raw 1999 IP that
// belongs to someone else now, and assigning them replaces the master list the Modern
// Client resolves at boot -- which is how a Shifter server stops appearing in anyone's
// browser. Both lists are still read on this client (FearCSDelegate.cpp). Leave them.
//$Server::XLMaster1 = "IP:198.74.38.23:28000";
//$Server::XLMaster2 = "IP:Broadcast:28001";
//$Server::XLMasterN0 = "IP:209.67.28.148:28000";
//$Server::XLMasterN1 = "IP:209.1.233.139:28000";
//$Server::XLMasterN2 = "IP:198.74.40.68:28000";

//$Server::MasterAddress0 = "IP:tribes.dynamix.com:28000";
//$Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
//$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
//$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
//$Server::MasterName0 = "Tribes Master";
//$Server::MasterName1 = "UK Tribes Master";
//$Server::MasterName2 = "Australian Tribes Master";
//==========================================================
//=== These are for Debug - Do not change these lines
//$Shifter::ObjScore = "";				// Allow Objects Being Destroyed To Award Bonus Points
//$Shifter::PlrScore = "";				// Allow Player Bonus Points To Be Awarded
//$Debug = "False";
