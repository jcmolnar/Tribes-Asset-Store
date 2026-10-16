//Dedicated Football Server Prefs file by Spike <admin@clanmime.com>
//join the fun: {KOI} Football server [IP:209.1.109.231:28003:00]
//Football FTP archive: http://amishrabbit.com/tribes/football
//Updated 21 June 2001

//PORT-OFF: $Server::HostName = "Football"; //name that shows up in server list
//PORT-OFF: $Server::MaxPlayers = "8"; //MAX should be 8 for cable/DSL, 16 for T1, 32 for T3 or higher.
//PORT-OFF: $Server::HostPublicGame = "True";
//PORT-OFF: $Server::Info = "SERVERNAME\nAdmin: NAME (EMAIL)\nMod info: mods.tribalwar.com/football"; 

//displays as the player connects to the server
$MODInfo = "<f0>It's Football--Tribes style!\n\n<f1>'' If all the year were playing holidays, To sport would be as tedious as to work. ''  --Shakespeare";

//displays after they connect but before they join a team.
//MAXIMUM 71 CHARS PER MOTD STRING
//PORT-OFF: $Server::JoinMOTD = "<f1><jc>Welcome to Tribes Football\n<f2>Hang up your spinfusor at the door.\nYou won't need it here.";

$TCTimer = 10; //cannot change teams for this long (seconds) after any team change
$VoteAdminAllowed = false; //vote admin function on or off
$halftimeDelay = 10; //delay (seconds) before game resumes at half time, if under 5 - no halftime
$HPM = false; //toggles hot patato mode
$HPTime = 15; //time a person has to pass before punishment
$SmurfTracker = true;
$gunFumbleChance = 30;
$RanAssign = 3;
$InfJet = false;
$TATD = false; //toggles if tackle after TD is on or off (false is off)
$SecondConnectingMessage = "<f1>\nHave Fun!";
$CycleOnEmpty = false; //cycles mission when last player leaves server
$maxSADTries = 5; //Maximum number of tries a player can enter a sad password without being banned
$NoVoteGF = false; //turns gun fumble voting OFF
$NoMajorityRules = false; //turns majority ruling for votes OFF
$ConnectsPerIP = 2; //allows only the specified number of people with the same IP in the server at one time (0 is unlimited)

//PORT-OFF: $Server::Port = "28001";
//PORT-OFF: $Server::Password = "";
//PORT-OFF: $Server::TimeLimit = "15"; //this is for each half
//PORT-OFF: $Server::AutoAssignTeams = "True";
//PORT-OFF: $Server::TourneyMode = "False";
//PORT-OFF: $Server::TeamDamageScale = "0";
//PORT-OFF: $Server::HostPublicGame = "True";
//PORT-OFF: $SuperAdminPassword = "CHANGEMEFIRST";
//PORT-OFF: $AdminPassword = "CHANGEME";
//PORT-OFF: $Server::warmupTime = 20;
//PORT-OFF: $Server::respawnTime = 1;
//PORT-OFF: $Server::VotingTime = 15;
//PORT-OFF: $Server::VoteWinMargin = 0.80;
//PORT-OFF: $telnetport = "11111"; //change to something else
//PORT-OFF: $telnetpassword = "CHANGEMETOO";
//PORT-OFF: $pref::PacketRate = "15"; //lower to 10 for modem players
//PORT-OFF: $pref::PacketSize = "300"; //lower to 200 for modem players

//Team names and skins
//PORT-OFF: $Server::teamSkin0 = "beagle";
//PORT-OFF: $Server::teamName0 = "TEAM 1";
//PORT-OFF: $Server::teamSkin1 = "NFLPATRIOTS"; //use dsword if you don't have the football skins
//PORT-OFF: $Server::teamName1 = "TEAM 2";

//Additional Code
//PORT-OFF: $console::logmode=1; //set to 0 if you want NO LOG

//football missions only
//PORT-OFF: exec(missionlist);
//PORT-OFF: MissionList::clear();
//PORT-OFF: Missionlist::initNextMission();
//PORT-OFF: $pref::lastmission = "Highschool"; //first mission to launch when you startup

//Missionlist: order in reverse alphabetical here to make them alpha in the menu
//PORT-OFF: MissionList::addMission("TunnelBall");
//PORT-OFF: MissionList::addMission("TK-421_Extended_Stadium");
//PORT-OFF: MissionList::addMission("TK-421_Stadium");
//PORT-OFF: MissionList::addMission("TheRuins");
//PORT-OFF: MissionList::addMission("Tech_Ball");
//PORT-OFF: MissionList::addMission("SpaceStation_Stadium");
//PORT-OFF: MissionList::addMission("SpaceBall");
//PORT-OFF: MissionList::addMission("SnowField");
//PORT-OFF: MissionList::addMission("Snowball_Express2");
//PORT-OFF: MissionList::addMission("Snowball_Express");
//PORT-OFF: MissionList::addMission("SlamDunk_Stadium");
//PORT-OFF: MissionList::addMission("Shooters_Stadium");
//PORT-OFF: MissionList::addMission("RomanFootBall");
//PORT-OFF: MissionList::addMission("Redshirt_Memorial_Stadium");
//PORT-OFF: MissionList::addMission("RamppedTouchdown");
//PORT-OFF: MissionList::addMission("PrisonCampRedux");
//PORT-OFF: MissionList::addMission("PrisonCamp");
//PORT-OFF: MissionList::addMission("PikaDropStadium");
//PORT-OFF: MissionList::addMission("Official_Stadium9");
//PORT-OFF: MissionList::addMission("Official_Stadium8");
//PORT-OFF: MissionList::addMission("Official_Stadium7");
//PORT-OFF: MissionList::addMission("Official_Stadium6");
//PORT-OFF: MissionList::addMission("Official_Stadium5");
//PORT-OFF: MissionList::addMission("Official_Stadium4");
//PORT-OFF: MissionList::addMission("Official_Stadium3");
//PORT-OFF: MissionList::addMission("Official_Stadium2");
//PORT-OFF: MissionList::addMission("Official_Stadium1");
//PORT-OFF: MissionList::addMission("NoFear_Stadium");
//PORT-OFF: MissionList::addMission("MudBowlMX");
//PORT-OFF: MissionList::addMission("MudBowl");
//PORT-OFF: MissionList::addMission("MoonJump_Stadium");
//PORT-OFF: MissionList::addMission("MontyCrisco_Stadium");
//PORT-OFF: MissionList::addMission("Midnight_Run");
//PORT-OFF: MissionList::addMission("Longest_Yard");
//PORT-OFF: MissionList::addMission("LN2_Stadium");
//PORT-OFF: MissionList::addMission("LaputaStadium");
//PORT-OFF: MissionList::addMission("Kings_Stadium");
//PORT-OFF: MissionList::addMission("InDoorsArena");
//PORT-OFF: MissionList::addMission("IndoorFootballStyle");
//PORT-OFF: MissionList::addMission("IceBall");
//PORT-OFF: MissionList::addMission("HoopsMX");
//PORT-OFF: MissionList::addMission("Hoops");
//PORT-OFF: MissionList::addMission("HolyMoly_Stadium");
//PORT-OFF: MissionList::addMission("HighSchool");
//PORT-OFF: MissionList::addMission("Highjump_Stadium");
//PORT-OFF: MissionList::addMission("HighEndzone");
//PORT-OFF: MissionList::addMission("HeiligeScheisseStadium");
//PORT-OFF: MissionList::addMission("HalfpipeMX_Stadium");
//PORT-OFF: MissionList::addMission("Halfpipe_Stadium");
//PORT-OFF: MissionList::addMission("Ghostrider_Stadium");
//PORT-OFF: MissionList::addMission("Frisbee_ConversionA");
//PORT-OFF: MissionList::addMission("Fortress_Stadium");
//PORT-OFF: MissionList::addMission("football");
//PORT-OFF: MissionList::addMission("FlyingNights_Stadium");
//PORT-OFF: MissionList::addMission("FlyingKnightsMX_Stadium");
//PORT-OFF: MissionList::addMission("FlyBall");
//PORT-OFF: MissionList::addMission("Extreme_Stadium");
//PORT-OFF: MissionList::addMission("EEPROM_Stadium");
//PORT-OFF: MissionList::addMission("DesertHigh_StadiumMX");
//PORT-OFF: MissionList::addMission("DesertHigh_Stadium");
//PORT-OFF: MissionList::addMission("DesertBowl");
//PORT-OFF: MissionList::addMission("Cyclone_Stadium");
//PORT-OFF: MissionList::addMission("Cavern_Stadium");
//PORT-OFF: MissionList::addMission("BlueBalls_Stadium");

//Rotation paradigm: $nextMission["CURRENT"] = "NEXT";
//PORT-OFF: $nextMission["football"] = "RamppedTouchdown";
//PORT-OFF: $nextMission["RamppedTouchdown"] = "Official_Stadium1";
//PORT-OFF: $nextMission["Official_Stadium1"] = "Official_Stadium2";
//PORT-OFF: $nextMission["Official_Stadium2"] = "Official_Stadium3";
//PORT-OFF: $nextMission["Official_Stadium3"] = "Official_Stadium4";
//PORT-OFF: $nextMission["Official_Stadium4"] = "Official_Stadium5";
//PORT-OFF: $nextMission["Official_Stadium5"] = "Official_Stadium6";
//PORT-OFF: $nextMission["Official_Stadium6"] = "Official_Stadium7";
//PORT-OFF: $nextMission["Official_Stadium7"] = "Official_Stadium8";
//PORT-OFF: $nextMission["Official_Stadium8"] = "Official_Stadium9";
//PORT-OFF: $nextMission["Official_Stadium9"] = "Snowball_Express2";
//PORT-OFF: $nextMission["Snowball_Express2"] = "DesertHigh_Stadium";
//PORT-OFF: $nextMission["DesertHigh_Stadium"] = "EEPROM_Stadium";
//PORT-OFF: $nextMission["EEPROM_Stadium"] = "DesertHigh_StadiumMX";
//PORT-OFF: $nextMission["DesertHigh_StadiumMX"] = "Halfpipe_Stadium";
//PORT-OFF: $nextMission["Halfpipe_Stadium"] = "Hoops";
//PORT-OFF: $nextMission["Hoops"] = "BlueBalls_Stadium";
//PORT-OFF: $nextMission["BlueBalls_Stadium"] = "RomanFootBall";
//PORT-OFF: $nextMission["RomanFootBall"] = "TunnelBall";
//PORT-OFF: $nextMission["TunnelBall"] = "Tech_Ball";
//PORT-OFF: $nextMission["Tech_Ball"] = "FlyingNights_Stadium";
//PORT-OFF: $nextMission["FlyingNights_Stadium"] = "Cyclone_Stadium";
//PORT-OFF: $nextMission["Cyclone_Stadium"] = "MontyCrisco_Stadium";
//PORT-OFF: $nextMission["MontyCrisco_Stadium"] = "Kings_Stadium";
//PORT-OFF: $nextMission["Kings_Stadium"] = "SlamDunk_Stadium";
//PORT-OFF: $nextMission["SlamDunk_Stadium"] = "NoFear_Stadium";
//PORT-OFF: $nextMission["NoFear_Stadium"] = "Ghostrider_Stadium";
//PORT-OFF: $nextMission["Ghostrider_Stadium"] = "Geometric_Stadium";
//PORT-OFF: $nextMission["Geometric_Stadium"] = "FlyingKnightsMX_Stadium";
//PORT-OFF: $nextMission["FlyingKnightsMX_Stadium"] = "Extreme_Stadium";
//PORT-OFF: $nextMission["Extreme_Stadium"] = "HalfpipeMX_Stadium";
//PORT-OFF: $nextMission["HalfpipeMX_Stadium"] = "HoopsMX";
//PORT-OFF: $nextMission["HoopsMX"] = "Shooters_Stadium";
//PORT-OFF: $nextMission["Shooters_Stadium"] = "Longest_Yard";
//PORT-OFF: $nextMission["Longest_Yard"] = "Midnight_Run";
//PORT-OFF: $nextMission["Midnight_Run"] = "MudBowl";
//PORT-OFF: $nextMission["MudBowl"] = "LN2_Stadium";
//PORT-OFF: $nextMission["LN2_Stadium"] = "MoonJump_Stadium";
//PORT-OFF: $nextMission["MoonJump_Stadium"] = "Frisbee_ConversionA";
//PORT-OFF: $nextMission["Frisbee_ConversionA"] = "HolyMoly_Stadium";
//PORT-OFF: $nextMission["HolyMoly_Stadium"] = "MudBowlMX";
//PORT-OFF: $nextMission["MudBowlMX"] = "SpaceStation_Stadium";
//PORT-OFF: $nextMission["SpaceStation_Stadium"] = "Highjump_Stadium";
//PORT-OFF: $nextMission["Highjump_Stadium"] = "DesertBowl";
//PORT-OFF: $nextMission["DesertBowl"] = "FlyBall";
//PORT-OFF: $nextMission["FlyBall"] = "Fortress_Stadium";
//PORT-OFF: $nextMission["Fortress_Stadium"] = "HighEndzone";
//$nextMission["HighEndzone"] = "HighSchool";
//$nextMission["HighSchool"] = "IceBall";
//PORT-OFF: $nextMission["HighEndzone"] = "IceBall";
//PORT-OFF: $nextMission["IceBall"] = "InDoorsArena";
//PORT-OFF: $nextMission["InDoorsArena"] = "PrisonCamp";
//PORT-OFF: $nextMission["PrisonCamp"] = "HeiligeScheisseStadium";
//PORT-OFF: $nextMission["HeiligeScheisseStadium"] = "LaputaStadium";
//PORT-OFF: $nextMission["LaputaStadium"] = "TK-421_Extended_Stadium";
//PORT-OFF: $nextMission["TK-421_Extended_Stadium"] = "football";
//last rotation map should always point back to the first.
