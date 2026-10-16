//=========================================================================================================================================
// Server Config.CS
//=========================================================================================================================================

//PORT-OFF: $Server::HostName = "{TKO}Practice Server III";	// The name of your
//PORT-OFF: $Server::MaxPlayers = "16"; 				// Max Players On Your Server
//PORT-OFF: $Server::HostPublicGame = "true";			// Server will be publically listed
//PORT-OFF: $Console::LogMode = "1"; 	   			// save the console to a logfile
//PORT-OFF: $Server::Password = "";					// Server Password - for passworded matches
//PORT-OFF: $TelnetPort = "23";					// Telnet port number
//PORT-OFF: $TelnetPassword = "millie";				// Telnet password

$Shifter::PublicNotice = "";				// This Message will be dispalyed every so ofter as players spawn, leave it null to disable

//========================================= Server Information That Players Can See.
//PORT-OFF: $Server::Info 		= "Shifter 928andmore Skins\nAdmin: TKOJERKOFF\nEmail: TKOJERKOFF@HOTMAIL.COM\n2 EMAIL FOR A SCRIMMAGE WITH YOUR CLAN\nWe also have other servers to play on as well\n{TKO}Practice Server II\n{TKO}Iconx Station 1510 running on a T-3 Line\nCheck out our Website www.tko.s5.com.";
//PORT-OFF: $Server::JoinMOTD 	= "<jc><f1>Welcome to {TKO}'s turf!!!!\nMODs: Shifter - Personal Skins.\n2 TeamKill kick-ban active.";
//PORT-OFF: $Server::MODInfo 	= "MODS:Shifter928Modified\nOur Website www.tko.s5.com\nWe also have other servers to play on as well\n{TKO}Practice Server II\n{TKO}Iconx Station 1510 running on a T-3 Line\nCheck out our Website www.tko.s5.com.";
$Server::MODInfo 	= "Shifter SG1 (Shifter 09-28-2000 with the {TKO} clan SG1 armors and weapons)";	// PORT

$Server::AutoAssignTeams = "true";		// Places players on teams automatically
$Server::FloodProtectionEnabled = "true";	// Check for chat flooding players
//PORT-OFF: $Server::HostPublicGame = "true";		// List your server with the master list.
//PORT-OFF: $pref::noIpx = "true";				// Disallow IPX/SPX binding

//PORT-OFF: $Server::Port = "28001";			// Port To Run Server On
$Server::respawnTime = "2";			// Time after death to respawn.
$Server::TeamDamageScale = "1";			// Team Damage On/Off

//========================================= Team Names and Default Skins and Time Limits
//PORT-OFF: $Server::teamName0 = "{TKO}";		$Server::teamSkin0 = "cphoenix";
//PORT-OFF: $Server::teamName1 = "Losers";		$Server::teamSkin1 = "swolf";	
//PORT-OFF: $Server::teamName2 = "Phoenix ";		$Server::teamSkin2 = "beagle";
//PORT-OFF: $Server::teamName3 = "Blue Rhinos";		$Server::teamSkin3 = "dsword";
//PORT-OFF: $Server::teamName4 = "Pink Elephants";		$Server::teamSkin4 = "base";

$Server::timeLimit = "70";			// Mission Time Limit In Minutes

//========================================= Voting Varriables

$Server::MinVotes = "1";			// Minimum Votes to count
$Server::MinVotesPct = "0.85";			// Percentage of votes needed to pass a vote
$Server::MinVoteTime = "45";			// Time a vote lasts
$Server::VoteFailTime = "30";			// Length Of Votes if people are NOT voting.
$Server::VoteWinMargin = "0.699999";		// Ratio of Yeh to Neh to win vote.
$Server::VotingTime = "20";			// Length Of Votes if people are voting.

//=========================================================================================================================================
// Shifter_v1.cs - The Following Options Pretain Strictly To The Functionality Of Shifter.
//=========================================================================================================================================


//=========================================================================================================================================
// Client Options
//=========================================================================================================================================
$Debug = "False";		// == Turns on Debug - If you have problems you can turn Debug on here.


$Shifter::TwoMinute = "True";	// == Two Minute Warning Notice On/Off (Default = True)

$Shifter::NoSwearing="False"; 	// == True means disallow swearing on your server? (update the SHBadwordlist.cs file)
$Shifter::BadWordsMax=3; 	// == If no swearing, This value is the limit at which the client starts being killed for swearing
$Shifter::BadWordskick=4; 	// == If no swearing, This value is the limit at which the client is kicked for swearing

$Shifter::LooseScore = 0.75;	// == This is the score ratio for the loosing team. 0.5 for instance would cut a loosing players score by half.

$Shifter::Guided = True;		//== Allow Guided Missile Stations in game?
$Shifter::SpawnType = "Random"; 	//== Must be 'Standard' or 'Random'
$Shifter::SaveOn = True;		//== Allow players to save thier profiles.
$Shifter::SpawnFavs = True;		//== Allow spawn faves
$Shifter::EngHealAll = True;		//== Engineers touch heals objects.

$Shifter::VoteDTD = True;		//== Allow Team Damage Disable Vote
$Shifter::VoteKick = True;		//== Allow Vote to kick
$Shifter::VoteAdmin = False;		//== Can players initiate vote to admin

$Shifter::HelpOn = True;		//== Shifter Help On <Tab> menu
$Shifter::SwitchPerm = True;		//== Admin Team Changing Players Is Perminant

$Shifter::ScoreTracker = True;		//== Score Tracker = Warns then Kicks players for having bad scores.
$Shifter::CheckScores = 30;		//== How often to check.
$Shifter::WarnScore1 = "-10";		//== 1st Warning
$Shifter::WarnScore2 = "-20";		//== 2nd Warning
$Shifter::WarnScore3 = "-30";		//== 3rd Warning
$Shifter::WarnScoreFinal = "-40";	//== Kick Player For Crappy Score


//========================================================= Mission Settings
//PORT-OFF: $pref::LastMission = "Broadside";	//== Sets the Starting Mission if Random Start Missions are off.
$Shifter::RandomStart = False;		//-- Start server with a Random mission
$Shifter::Reactions = True;		//-- Damage knocks player back
$Shifter::Refresh = False;		//-- Refresh the server after last player drops 
$Shifter::RandomMissions = True;	//== Random Missions on/off
$Shifter::RandomStart = False;		//== Random Missions on/off

//========================================================= Time and Item Limits
$Shifter::HackedTime = 90;	// -- Time hacked items will remain hacked. 0 = Must be hacked back... - Defults To 90
$Shifter::HackTime = 5;		// -- Length Of Time To Complete Hacking - Defaults To 5
$Shifter::HackLock = 90;	// -- Legth of time a hacked item will be disabled for after being hacked. - Defaults To 0
$Shifter::LaserMineLive = 2;	// -- Live Time For Laser Mines - Defaults To 5 Seconds
$Shifter::ItemLimit = False;	// -- Makes it so that ONLY the armors that can buy a given item can see it in the invo list.
$Shifter::DetPackLimit = 10;	// -- Limit of DetPacks per match
$Shifter::NukeLimit = 999;	// -- Limit of Nukes per match

//========================================================= Misc Options
//PORT-OFF: $Shifter::LocalNetMask = "IP:208.188.5";	//== Local IP's (Assuming you have a LAN connection to the server and are not worried about band width from connecting Lan players, You can increase the limit when a player from this IP Mask connects.
$Shifter::PowerCheck = False;			//== If True - Spawns players in Standard armor if power is down
$Shifter::TeamJuggle = 3;			//== Juggles the teams every X missions
$Shifter::AmmoBoom = True;			//== Players ammo can blow up when killed 


$Server::TourneyMode = "False";			// Set Tourney Mod Initially.
$Server::warmupTime = "10";			// Mission Start Time (Delay before missions starts)
//PORT-OFF: $Server::PacketRate = "10";     		// recommended rate for a cable modem
//PORT-OFF: $Server::PacketSize = "200";    		// recommended rate for a cable modem
$Shifter::GlobalTChat = True;			// True - All players can chat global in Tourney Mode
						// False - Only players marked as Lead or Admin or SuperAdmin can chat.
						// Admins and Super Admins have Lead setting options.
//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

//==== Wild card IP's must just be left blank. Do NOT use the * in place of an octet. Note below for an example.
//==== NEW AutoAdmin - SAD Password Assignments

//==== NOTE : ALL OF THESE LINES MUST BE PRESENT FOR AUTO/SAD ADMIN TO WORK - PER PLAYER!!!

//PORT-OFF: $Server::Admin["autoa", "{TKO}Jerk Off"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $Server::Admin["noban", "{TKO}Jerk Off"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $Server::Admin["ipadr", "{TKO}Jerk Off"] = "IP:24.10.244.30";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $Server::Admin["sadpw", "{TKO}Jerk Off"] = "tyco";		//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $Server::Admin["admin", "{TKO}Jerk Off"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin 
//PORT-OFF: $Server::Admin["super", "{TKO}Jerk Off"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//PORT-OFF: $Server::Admin["autoa", "{TKO}Arkangel"] = 1;	
//PORT-OFF: $Server::Admin["noban", "{TKO}Arkangel"] = 1;	
//PORT-OFF: $Server::Admin["ipadr", "{TKO}Arkangel"] = "IP:128.0.0";
//PORT-OFF: $Server::Admin["sadpw", "{TKO}Arkangel"] = "tyco";	
//PORT-OFF: $Server::Admin["admin", "{TKO}Arkangel"] = 1;		
//PORT-OFF: $Server::Admin["super", "{TKO}Arkangel"] = 1;	

//PORT-OFF: $Server::Admin["autoa", "{TKO}SHOOTER"] = 1;	
//PORT-OFF: $Server::Admin["noban", "{TKO}SHOOTER"] = 1;	
//PORT-OFF: $Server::Admin["ipadr", "{TKO}SHOOTER"] = "IP:24.10.57.244";
//PORT-OFF: $Server::Admin["sadpw", "{TKO}SHOOTER"] = "tyco";	
//PORT-OFF: $Server::Admin["admin", "{TKO}SHOOTER"] = 1;		
//PORT-OFF: $Server::Admin["super", "{TKO}SHOOTER"] = 1;	

//PORT-OFF: $Server::Admin["autoa", "{TKO}DARTHSKULL"] = 1;	
//PORT-OFF: $Server::Admin["noban", "{TKO}DARTHSKULL"] = 1;	
//PORT-OFF: $Server::Admin["ipadr", "{TKO}DARTHSKULL"] = "IP:216.196.130.205";
//PORT-OFF: $Server::Admin["sadpw", "{TKO}DARTHSKULL"] = "tyco";	
//PORT-OFF: $Server::Admin["admin", "{TKO}DARTHSKULL"] = 1;		
//PORT-OFF: $Server::Admin["super", "{TKO}DARTHSKULL"] = 1;	


//=========================================================================================================================================
// Server Options
//=========================================================================================================================================
$Shifter::Weapons = True;                               //== Advanced Weapon Options On

$Shifter::LockOn = True;				//== Stinger Missle Locks Available

//PORT-OFF: $Shifter::emailAddress = "{TKO}Jerk Off@Hotmail.Com";	//== Email address to show banned users for reinstatement

$Shifter::KeepBalanced = True;				//== Keep Balanced
$Shifter::SpawnRandom = False;				//== Turn on Random Spawn Setup?
$Shifter::NoOutside = False;				//== Turn on Outside of mission area damage
$Shifter::TurretKill = True;                           //== Turret Kills Count For Player
$Shifter::PersonalSkin = True;				//== Personal Skins On or Off

//=========================================================================================================================================
// Advanced Flag Options
//=========================================================================================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";

//=========================================================================================================================================
// Advanced Scoring System
//=========================================================================================================================================
$ScoreOn = True;		    	//== If True will show client thier score on change in a bottom print message for 3 seconds.

$Shifter::HeadShot = 10;			//== Bonus for Head Shots
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
 
//=========================================================================================================================================
// Note about the following section... These points are awarded for destroying the enemy stations, generators, etc. 
// These points are also used in a calculation to give points for repairing things on your own team and to deduct points for
// repairing things on the enemy's team.
//
// The Lower option, Score::RepairObject is a base repair score. You can make this zero if you do not want players to get the 
// base 1 point ofr repairing... 
//
// You do NOT just get points for walking up and shooting something with a repair gun for a couple seconds. There is a detailed
// calculation that gets the total points for a repair job. The (ammount the item was damaged X the point value below) + the 
// Score::RepairObject... This ammount is given for repairing the players own teams equipment. It will also deduct this amount
// if the player repairs enemy equipment. 
//
// You will only gain points for repairing an object COMPLETELY... Points are calculated from the time you start the repair to the 
// time you finish, if you want full points you had better not stop...
//
// What stops a player from just shooting and repairing his own stuff to horde points?! If the player is the last person to have
// damaged the object he will recieve NO points.
//=========================================================================================================================================

$Score::ObjStationS = "7";      //== Destroy Supply Station 
$Score::ObjStationA = "5";      //== Destroy Ammo Station or Command
$Score::ObjStationR = "3";      //== Destroy Remote Station
$Score::ObjFlier = "3";         //== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "15";   //== Destroy Large Generator
$Score::ObjGeneratorS = "5";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors

$Score::ObjTurretL = "5";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets

$Score::Kill15Meters = "3";	//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "3";	//== Kill From 15 to 50m
$Score::Kill100Meters = "5";	//== Kill From 50 to 100m
$Score::Kill250Meters = "6";	//== Kill From 100 to 250m
$Score::Kill250Plus = "8";	//== Kill 250m Or More

$Score::RepairObject = "3";     //== Repair Bonus. Base Points For Repair...

$Shifter::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========================================================================================================================================
// Fair Teams Variables
//=========================================================================================================================================

$Shifter::FairTeams = True;  //== Is Fair Teams Is On
$Shifter::FairCheck = "30";  //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "90"; //== Number in seconds that Shifter will move the last connected player to the un even team.

//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================

$Shifter::TeamKillOn 		= "True";	//== Is Anti TK On/Off
$Shifter::KillTerm 		= "1";		//== Number Of Time A Player Can Team Kill
						//== Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "1";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "600";	//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "4";		//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "15";        	//== Proximity Distance For Accidental Damage.
	
//=========================================================================================================================================
// Varrious Server Messages To The Client
//=========================================================================================================================================

//================================================================= Message To Banned Team Killer
//PORT-OFF: $Shifter::TeamKillMsg = "You have been kick and banned for team killing, NOW stay the FUCK Out LOSER!!!!! Email:" TKOJERKOFF@HOTMAIL.COM $Shifter::TKOJERKOFF@HOTMAIL.COM" for reinstatement.";
$Shifter::TeamKillMsg = "You have been kicked and banned for team killing.";	// PORT: plain text

//================================================================= Show When Client Spawns For The First Time

//PORT-OFF: $Shifter::WelcomeMsg = "<jc><f2>Welcome to {TKO}'S Turf!!!\nMOD: Shifter V1.0 \nServer site:www.tko.s5.com\nMission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>2 TeamKill KickBan in effect.\nIf you LAG, leave...  Don't whine. We dont want to hear it!";
$Shifter::WelcomeMsg = "<jc><f2>Welcome to Shifter SG1";	// PORT
$Shifter::WelcomeDelay = "20";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.

//=========== Master Server Listing (Dont frell with this).
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
//==========================================================
//=== These are for Debug - Do not change these lines
//$Shifter::ObjScore = "";				// Allow Objects Being Destroyed To Award Bonus Points
//$Shifter::PlrScore = "";				// Allow Player Bonus Points To Be Awarded

