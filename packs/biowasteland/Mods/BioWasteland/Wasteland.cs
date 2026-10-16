//=====================================================================
//=======================BioWasteland Configuration File
//=======================Mod by Bïohazard
//=======================www.exploratoriums.com
//=======================biohazard@exploratoriums.com
//=====================================================================

//PORT-OFF: $Server::HostName = "ServerNameHere";
//PORT-OFF: $Server::MaxPlayers = "12";
//PORT-OFF: $Server::HostPublicGame = "true";
//PORT-OFF: $Console::LogMode = "0";//1=keep a log
//$Server::Password = "PassWordHere";
//PORT-OFF: $TelnetPort = "28310";
//PORT-OFF: $TelnetPassword = "PassWordHere";
$pref::noIpx = "true";

//=====================================================================
//======================= Server Information
//=====================================================================

$Server::Info = "<jc><f0>B <f2>i<f0> o <f2>W<f0> a <f2>s<f0> t <f2>e<f0> l <f2>a<f0> n <f2>d <f0>v7.1\n<f2>www<f0>.<f2>exploratoriums<f0>.<f2>com\nEmail: you@yourdomain.com";

$Server::JoinMOTD 	= "<jc><f2>Welcome to <f1>BïoWasteland <f2>Mission: <f1>" @ $missionName @ " (" @ $Game::missionType @ ")\n\n<f2>Get over 100 skins and my New Sound-Pack: www.exploratoriums.com";

$Server::MODInfo 	= "<jc><f0>B <f2>i<f0> o <f2>W<f0> a <f2>s<f0> t <f2>e<f0> l <f2>a<f0> n <f2>d<f0> v7.1";

$Wasteland::WelcomeMsg = "<jc><f2>Be sure to check the [tab] menu for weapon options.";
$Wasteland::WelcomeDelay = "5";  		//== Seconds to display welcome. "0" = none

//======================= Show When Client Spawns
$Wasteland::PublicNotice = "<jc><f1>Help Menu: <f1>type into the chat interface <f2>#help";

//======================= AutoAdmin Options
$Wasteland::WeaponAdmin = "false";		//== Enable Admins to set weapon options
//PORT-OFF: $Server::Admin["autoa", "PlayersName"] = 1;
//PORT-OFF: $Server::Admin["ipadr", "PlayersName"] = "IP:000.000.000.000";
//PORT-OFF: $Server::Admin["sadpw", "PlayersName"] = "PlayersPassword";
//PORT-OFF: $Server::Admin["noban", "PlayersName"] = 1;
//PORT-OFF: $Server::Admin["admin", "PlayersName"] = 1; 
//PORT-OFF: $Server::Admin["super", "PlayersName"] = 1;


//======================= Members of a private server
//PORT-OFF: $Server::Admin["ipadr", "PlayersName"] = "IP:000.000.000.000";
//PORT-OFF: $Server::Admin["sadpw", "PlayersName"] = "PlayersPassword";


//=====================================================================
//======================= Server Options
//=====================================================================

$BioPrivate = ""; 				// 1 is warn 2 is kick non-members
$ClanPriority = "Clan";				// Clan to get priority when server is full
$Wasteland::NoPestering = "True"; 		// True means don't pester for reg and clan
$Wasteland::Tag0 = "TAG";			// Clan Tag for Clan Teaming
$Server::AutoAssignTeams = "true";		// Places players on teams automatically
$Server::FloodProtectionEnabled = "true";	// Check for chat flooding players
//PORT-OFF: $Server::HostPublicGame = "true";		// List your server with the master list.
//PORT-OFF: $Server::Port = "28300";			// Port To Run Server On
$Server::respawnTime = "2";			// Time after death to respawn.
$Server::TeamDamageScale = "1";		// Team Damage On/Off
$Server::TourneyMode = "False";		// Set Tourney Mod Initially.
$Server::warmupTime = "5";			// Mission Start Time (Delay before missions starts)
//PORT-OFF: $Server::PacketRate = "20";     		// recommended rate for a cable modem
//PORT-OFF: $Server::PacketSize = "300";    		// recommended rate for a cable modem

//== Email address to show banned users for reinstatement
$Wasteland::emailAddress = "YourEmailHere";

//== Server's WebPage URL
$Wasteland::url = "www.<f1> url <f2>.com ";

//== Local IP (Assuming you have a LAN. Players from this IP don't count against player max)
$Wasteland::LocalNetMask = "IP:000.000.";

//======================= Mission Options

$Wasteland::RandomStart = False;		//== Start server with a Random mission
//PORT-OFF: $pref::LastMission = "Raindance"; 		//== Sets the Start Mission if Random is false
$Wasteland::RandomMissions = True;		//== Random Missions on/off
$Wasteland::TwoMinute = "True";		//== Two Minute Warning On
//== Mission Time Limit is in ItemFuncs.cs now

//======================= Team Names and Skins

$Server::teamName0 = "Poisonous";		$Server::teamSkin0 = "dsword";
$Server::teamName1 = "Infectious";		$Server::teamSkin1 = "swolf";	
$Server::teamName2 = "Noxious";		$Server::teamSkin2 = "beagle";
$Server::teamName3 = "Caustic";		$Server::teamSkin3 = "cphoenix";
$Server::teamName4 = "Hazardous";		$Server::teamSkin4 = "base";
$Server::teamName5 = "Carcinogenic";	$Server::teamSkin5 = "base";
$Server::teamName6 = "Challenger";		$Server::teamSkin6 = "base";	
$Server::teamName7 = "Defender";		$Server::teamSkin7 = "base";

//======================= Team Related Options

$Wasteland::FairTeams = "True";		//== Is Fair Teams Is On
$Wasteland::TeamKillOn = "True";		//== Is TK On/Off
$Wasteland::KillTerm = "2";			//== Kills player after X TK's
$SHAntiTeamKillWarnKills = "1";         	//== Number Of TK's Before Player Gets Warning.
$SHAntiTeamKillBanTime = "999";		//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills = "4";		//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity = "50";		//== Proximity Distance For Accidental Damage.
$Wasteland::TeamJuggle = 6;			//== Juggles the teams every X missions
$Wasteland::KeepBalanced = True;		//== Keep Teams Balanced
//== Frequency Wasteland will monitor team evenness is in itemfunctions now.

//======================= Voting Variables

$Server::MinVotes = "1";			// Minimum Votes to count
$Server::MinVotesPct = "0.66";		// Percentage of votes needed to pass a vote
$Server::MinVoteTime = "45";			// Time a vote lasts
$Server::VoteFailTime = "30";			// Length Of Votes if people are NOT voting.
$Server::VoteWinMargin = "0.51";		// Ratio of Yeh to Neh to win vote.
$Server::VotingTime = "20";			// Length Of Votes if people are voting.
$Wasteland::VoteKick = True;			//== Allow vote to kick
$Wasteland::VoteAdmin = False;		//== Allow vote to admin
$Wasteland::VoteDTD = False;			//== Allow vote to disable Team Damage

//======================= Spawn Options

$Wasteland::SpawnType = "Random"; 		//== Must be 'Standard' or 'Random'
$Wasteland::SpawnRandom = True;		//== Turn on Random Spawn Custom Setup
$Wasteland::SpawnFavs = True;			//== Allow Spawn Faves
$Wasteland::SpawnSafe = "5";			//== Period of invulnerability

//======================= Mod Options
$Wasteland::NoSwearing="True"; 		//== True means disallow swearing on your server
$Wasteland::NoSniping=""; 			//== True means disallow sniping on your server
$Wasteland::BadWordsMax=3; 			//== Limit at which client is killed for swearing
$Wasteland::BadWordskick=6; 			//== Limit at which client is kicked for swearing
$Wasteland::Guided = True;			//== Allow Guided Missile Stations in game
$Wasteland::SaveOn = True;			//== Allow players to save thier profiles
$Wasteland::EngHealAll = True;		//== Engineer's touch heals objects
$Wasteland::SwitchPerm = True;		//== Admin Team Changing Players Is Perminant
$Wasteland::ScoreTracker = True;		//== Kicks players for having bad scores
$Wasteland::CheckScores = 30;			//== How often to check
$Wasteland::WarnScore1 = "-1";		//== 1st Warning
$Wasteland::WarnScore2 = "-5";		//== 2nd Warning
$Wasteland::WarnScore3 = "-10";		//== 3rd Warning
$Wasteland::WarnScoreFinal = "-15";		//== Kick Player For Crappy Score
$Wasteland::Reactions = True;			//== Damage knocks player back
$Wasteland::Refresh = True;			//== Refresh the server after last player drops
$Wasteland::HackedTime = 180;			//== Time items remain hacked. 0 = infinite
$Wasteland::HackTime = 5;			//== Length Of Time To Complete Hacking
$Wasteland::HackLock = 0;			//== Legth of time a hacked item will be disabled
$Wasteland::LaserMineLive = 10;		//== Time delay before a laser mine becomes active
$Wasteland::DetPackLimit = 120;		//== Time Nuke Gen to make new Nuke Ammos
$Wasteland::NukeLimit = -5;			//== Max Nukes stored in Gen (a negative muber)
$Wasteland::AmmoBoom = True;			//== Players ammo can blow up when killed
$Wasteland::Weapons = True;			//== Advanced Weapon Options On
$Wasteland::LockOn = True;			//== Stinger Missle Locks Available
$Wasteland::NoOutside = True;			//== Turn on Outside of mission area damage
$Wasteland::TurretKill = True;		//== Turret Kills Count For Player
$Wasteland::FlagNoReturn = "True";		//== Replace lost flags to their stand?
$Wasteland::FlagReturnTime = "200";		//== Time flag is lost before replaced to stand

//== True - ONLY the armors that can buy it can see it in the invo list.
$Wasteland::ItemLimit = True;

//== True - Spawns players in Standard armor if power is down 
$Wasteland::PowerCheck = False;	

// True - All players can chat global in Tourney Mode
// False - Only players marked as Lead, or Admin can chat.
$Wasteland::GlobalTChat = True;	

//=====================================================================
//============= Advanced Scoring System
//=====================================================================
$Score::RepairObject = "1";		//== Base Points For Repair

$Wasteland::HeadShot = 5;		//== Bonus for Head Shots
$Wasteland::KillTime = 120;		//== Starting timer for kill -vs- live time bonuses, the longer a player lives the higher the bonus. Bonus counting does not start UNTIL this many seconds after player spawns.

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
$Score::ObjStationS = "7";		//== Destroy Supply Station 
$Score::ObjStationA = "5";		//== Destroy Ammo Station or Command
$Score::ObjStationR = "3";		//== Destroy Remote Station
$Score::ObjFlier = "3";			//== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "10";		//== Destroy Large Generator
$Score::ObjGeneratorS = "5";		//== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";		//== Destroy Large Sensors
$Score::ObjSensorS = "2";		//== Destroy Deployable Sensors
$Score::ObjTurretL = "3";		//== Large Turrets
$Score::ObjTurretS = "1";		//== Deployable Turrets

$Score::Kill15Meters = "0";		//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";		//== Kill From 15 to 50m
$Score::Kill100Meters = "1";		//== Kill From 50 to 100m
$Score::Kill250Meters = "2";		//== Kill From 100 to 250m
$Score::Kill250Plus = "3";		//== Kill 250m Or More

//=====================================================================
//======================= Master Server Listing (Dont frell with this).
//=====================================================================
//PORT-OFF: $Server::CurrentMaster = "0";
//PORT-OFF: $Server::numMasters = "3";
//PORT-OFF: $Server::Master1 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
//PORT-OFF: $Server::Master2 = "IP:BROADCAST:28001";
//PORT-OFF: $Server::XLMaster1 = "IP:198.74.38.23:28000";
//PORT-OFF: $Server::XLMaster2 = "IP:Broadcast:28001";
//PORT-OFF: $Server::XLMasterN0 = "IP:209.67.28.148:28000";
//PORT-OFF: $Server::XLMasterN1 = "IP:209.1.233.139:28000";
//PORT-OFF: $Server::XLMasterN2 = "IP:198.74.40.68:28000";
//PORT-OFF: $Server::MasterAddress0 = "IP:tribes.dynamix.com:28000";
//PORT-OFF: $Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
//PORT-OFF: $Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
//PORT-OFF: $Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
//PORT-OFF: $Server::MasterName0 = "Tribes Master";
//PORT-OFF: $Server::MasterName1 = "UK Tribes Master";
//PORT-OFF: $Server::MasterName2 = "Australian Tribes Master";
$Wasteland::TeamKillMsg = "You have been kick and banned for team killing. Email:" @ $Wasteland::emailAddress @ " for reinstatement.";


