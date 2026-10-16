// STAR mod settings -- the release's `STAR shifter.cs` (the entry script StarMod.cs runs it).
// PORT: 13 lines are switched off with //PORT-OFF: (auto-admin by player name / address mask,
// the author's e-mail) and the three bot switches are OFF: this release has no bot scripts.

//=========================================================================================================================================
// Client Options
//=========================================================================================================================================

$Shifter::Factory = "False";
$Shifter::SpawnType = "Random"; //== Must be 'Standard' or 'Random'
$Shifter::Racer = True;
$Shifter::SaveOn = True;
$Debug =0;
$Shifter::SpawnFavs = True;
$Shifter::EngHealAll = True;
$Shifter::Guided = True;

//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

//==== Wild card IP's must just be left blank. Do NOT use the * in place of an octet. Note below for an example.

//PORT-OFF: $Server::AutoAdmin0 = "STARpatrioT";				// Enter the PlayerName to be given Admin here
//PORT-OFF: $Server::AutoAdmin1 = "STARpatrioT";
//PORT-OFF: $Server::AutoAdmin0 = "STARcom";
//PORT-OFF: $Server::AutoAdmin1 = "STARcom";
//PORT-OFF: $Server::AutoAdmin2 = "Emo1313";
//PORT-OFF: $Server::AutoAdmin2 = "Thai";

//PORT-OFF: $Server::AutoAdminAddr0 = "IPX";       				//== Enter The Players Address Here
//PORT-OFF: $Server::AutoAdminAddr1 = "IPX ";
//PORT-OFF: $Server::AutoAdminAddr0 = "IPX";
//PORT-OFF: $Server::AutoAdminAddr1 = "IPX";
//PORT-OFF: $Server::AutoAdminAddr2 = "IPX";
//PORT-OFF: $Server::AutoAdminAddr2 = "IP:208";
							
//=========================================================================================================================================
// Server Options
//=========================================================================================================================================

$Shifter::Weapons = True;                               //== Advanced Weapon Options On

$Shifter::LockOn = True;				//== Missle locks

//PORT-OFF: $Shifter::emailAddress = "Dhead120@aol.com";	//== Email address to show banned users for reinstatement
$Shifter::VoteAdmin =  True;				//== Can players initiate vote to admin
$Shifter::VoteKick = True;				//== Can players initiate vote to kick
$Shifter::VoteFFA = False;				//== Clients can Vote For FFA or Tournement Mode
$Shifter::RandomMissions = True;			//== Random Missions on/off

$Shifter::KeepBalanced = True;				//== Keep Balanced
$Shifter::SpawnRandom = True;				//== Turn on Random Spawn Setup?
$Shifter::NoOutside = True;				//== Turn on Outside of mission area damage
$Shifter::TurretKill = True;                           //== Turret Kills Count For Player
$Shifter::PersonalSkin = True;				//== Personal Skins On or Off

//=========================================================================================================================================
// Advanced Flag Options
//=========================================================================================================================================
$Shifter::FlagNoReturn = "False";
$Shifter::FlagReturnTime = "400";

//=========================================================================================================================================
// Advanced Scoring System
//=========================================================================================================================================
$ScoreOn = True;		    	//== If True will show client thier score on change in a bottom print message for 3 seconds.

$Score::25Meters = "1";     		//== Less Than 25 Meters To Flag
$Score::75Meters = "3";     		//== From 25 to 75 Meters
$Score::150Meters = "5";    		//== From 75 to 150 Meters
$Score::250Meters = "10";    		//== From 150 to 250 Meters

$Score::FlagCapture = "30";		//== Points For A Successful Flag Capture 
$Score::FlagKill = "15";  		//== Bonus For Killing Flag Runner
$Score::FlagDef  = "5";   		//== Bonus Points For Defending The Runner
$Score::FlagReturn = "10";   		//== Points For Returning Dropped

$Score::CaptureOdj = "5";   		//== Points For Capturing An Objective
$Score::HoldingObj = "5";   		//== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = "10";   		//== Points For Getting The Objective First

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
$Score::ObjGeneratorB = "20";   //== Destroy Large Generator
$Score::ObjGeneratorS = "10";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors

$Score::ObjTurretL = "5";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets

$Score::Kill15Meters = "0";	//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";	//== Kill From 15 to 50m
$Score::Kill100Meters = "1";	//== Kill From 50 to 100m
$Score::Kill250Meters = "2";	//== Kill From 100 to 250m
$Score::Kill250Plus = "3";	//== Kill 250m Or More

$Score::RepairObject = "5";     //== Repair Bonus. Base Points For Repair...

$Shifter::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========================================================================================================================================
// Fair Teams Variables
//=========================================================================================================================================

$Shifter::FairTeams = True;  //== Is Fair Teams Is On
$Shifter::FairCheck = "30";  //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "60"; //== Number in seconds that Shifter will move the last connected player to the un even team.

//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================

$Shifter::TeamKillOn 	= "false";		//== Is Anti TK On/Off
$Shifter::KillTerm 		= "1";		//== Number Of Time A Player Can Team Kill
						//== Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "1";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "0";	//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "30";		//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "300";        	//== Proximity Distance For Accidental Damage.
	
//=========================================================================================================================================
// Varrious Server Messages To The Client
//=========================================================================================================================================

//================================================================= Message To Banned Team Killer
$Shifter::TeamKillMsg = "You have been kicked from a STAR server for TK'ing ! " @ $Shifter::emailAddress @ " for reinstatement.";

//================================================================= Show When Client Spawns For The First Time

$Shifter::WelcomeMsg = "<jc><f2>Welcome to the STAR server ! Hosted by STARpatrioT <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>2 TeamKill KickBan in effect.\nIf you LAG, leave...  Don't whine. We dont want to hear it!";

$Shifter::WelcomeDelay = "20";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.

//=========================================================================================================================================
// Set Default Anti-TK Functions
//=========================================================================================================================================

if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 0;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 20;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;

//=========================================================================================================================================
// Bot Options
//=========================================================================================================================================

$Shifter::BotsGoCrazy = "True";		//== Do Bots have a chance of ShortCircuiting and Spawning as not on a team.

$Shifter::AntiTKBots = True;			//== Will Bots Attack Own Team From Team Damage

$Shifter::NoBotsAtAll = True;	//PORT: was $Shifter::NoBotsAtAll = False;			//== Can Bots be Turned On With Out Making This False - TRUE Means No User Spawned Bots In Game
										//== Note = This does not stop automatically spawning bots from spawning...
$Shifter::AreThereBots = False;	//PORT: was $Shifter::AreThereBots = True;			//== Are there bots? Allow Or DisAllow Bots Spawned By Players
$Spoonbot::AutoSpawn = False;	//PORT: was $Spoonbot::AutoSpawn = True;			//== Automatic bot-spawning True = Spawns Bots Below up to 20 Bots can be Spawned Automatically

$Shifter::BotsAttackBots = True;		//== Do Bots Automatically Attack Bots When Game Starts. This will make the bots attack right off.
						//== This can lead to a sluggish server...
										
$Spoonbot::DebugMode = "False";           	//== This Debug Mod is for developemnt =ONLY= This version of Shifter Contains SpoonBots 4.0d!

$Spoonbot::RespawnDelay = 30;			//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 90;						//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.
$Spoonbot::ThinkingInterval = 5;		//== Interval in sec between which bots will "reconsider" their situation
										//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
$Spoonbot::BotsRetreat = False;			//== Bots will retreat if severely damaged
$Spoonbot::RetreatDamageLevel = 1.0;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.
$Spoonbot::BotJetting = False;			//== The bot "jetting" is very "jumpy" right now, so you can switch that off if it annoys you
$Spoonbot::BotChat = True;			//== If the bot's chat messages annoy you, you can turn them off here.

//=================================================== Now, the auto-spawned bots are being set up... 
//=================================================== Each Name Per Team MUST Be Unique!!!
//== The name must contain one for the following so that they will spawn as special bot classes.
//== 
//== Guard  = Dreadnaught
//== Sniper = Sniper Bot
//== Demo   = Standard Burster w/ varrious weapons
//== Miner  = Standard Light, doesnt mine yet.
//== Medic  = Engineer Bot

$Spoonbot::NumBots = 3;									//== Total Number of bots

$Spoonbot::Bot1Name = "T0_Guard_Female_Roam";
$Spoonbot::Bot1Team = 0;
$Spoonbot::Bot2Name = "T0_Demo_Male_Roam";
$Spoonbot::Bot2Team = 0;
$Spoonbot::Bot3Name = "T0_Guard_Male_Roam";
$Spoonbot::Bot3Team = 0;
//$Spoonbot::Bot4Name = "T0_Sniper_Male_Roam";
//$Spoonbot::Bot4Team = 0;
//$Spoonbot::Bot5Name = "T0_Medic_Male_Roam";
//$Spoonbot::Bot5Team = 0;

$Spoonbot::Bot4Name = "T1_Demo_Male_Roam";
$Spoonbot::Bot4Team = 1;
$Spoonbot::Bot5Name = "T1_Guard_Male_Roam";
$Spoonbot::Bot5Team = 1;
$Spoonbot::Bot6Name = "T1_Sniper_Male_Roam";
$Spoonbot::Bot6Team = 1;
//$Spoonbot::Bot9Name = "T1_Medic_Female_Roam";
//$Spoonbot::Bot9Team = 1;
//$Spoonbot::Bot10Name = "T1_Demo_Male_Roam";
//$Spoonbot::Bot10Team = 1;

//==========================================================================================================================================
// The following bot configurations should be used ONLY by admins who know what they are doing... This can seriously mess up the way the
// bots in Shifter/Spoon Bots work... Please make very sure of what you are doing before you alter any of these settings!!!
//==========================================================================================================================================


//================================= The following weapons are for what the bot will use when the enemy is...
//================================= The Pack is the pack that the bot will have mounted.
//================================= All items listed here **MUST** be listed in the particular bots inventory below...

//=========================== Guard Gear
$Spoonbot::GuardMArmor  = "darmor";
$Spoonbot::GuardFArmor  = "darmor";
$Spoonbot::GuardGear[0] = "mortar";		$Spoonbot::GuardAmmo[0] = "1";
$Spoonbot::GuardGear[1] = "mortarammo";		$Spoonbot::GuardAmmo[1] = "500";
$Spoonbot::GuardGear[2] = "chaingun";		$Spoonbot::GuardAmmo[2] = "1";
$Spoonbot::GuardGear[3] = "bulletammo";		$Spoonbot::GuardAmmo[3] = "50000";
$Spoonbot::GuardGear[4] = "PlasmaGun";		$Spoonbot::GuardAmmo[4] = "1";
$Spoonbot::GuardGear[5] = "PlasmaAmmo";		$Spoonbot::GuardAmmo[5] = "5000";
$Spoonbot::GuardGear[6] = "Grenade";        	$Spoonbot::GuardAmmo[6] = "100";
$Spoonbot::GuardGear[7] = "";

$Spoonbot::GuardClose = "PlasmaGun"; 
$Spoonbot::GuardLong  = "mortar";
$SpoonBot::GuardJet   = "chaingun";
$Spoonbot::GuardPack  = "Shieldpack";

//=========================== Demo Gear
$SpoonBot::DemoMArmor  = "barmor";
$SpoonBot::DemoFArmor  = "bfemale";
$SpoonBot::DemoGear[0] = "PlasmaGun";		$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::DemoGear[1] = "plasmaammo";		$Spoonbot::DemoAmmo[1] = "500";
$SpoonBot::DemoGear[2] = "disclauncher";	$Spoonbot::DemoAmmo[2] = "1";
$SpoonBot::DemoGear[3] = "discammo";		$Spoonbot::DemoAmmo[3] = "500";
$SpoonBot::DemoGear[4] = "GrenadeLauncher";	$Spoonbot::DemoAmmo[4] = "1";
$SpoonBot::DemoGear[5] = "GrenadeAmmo";		$Spoonbot::DemoAmmo[5] = "500";
$SpoonBot::DemoGear[6] = "flamer";		$Spoonbot::DemoAmmo[6] = "1";
$SpoonBot::DemoGear[7] = "Grenade";		$Spoonbot::DemoAmmo[7] = "100";
$SpoonBot::DemoGear[8] = "";

$Spoonbot::DemoClose = "PlasmaGun";
$Spoonbot::DemoLong  = "disclauncher";
$SpoonBot::DemoJet   = "flamer";
$Spoonbot::DemoPack  = "";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "earmor";
$SpoonBot::MedicFArmor  = "efemale";
$SpoonBot::MedicGear[0] = "blaster";		$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "disclauncher";	$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "discammo";		$Spoonbot::MedicAmmo[2] = "500";
$SpoonBot::MedicGear[3] = "repairkit";		$Spoonbot::MedicAmmo[3] = "15";
$SpoonBot::MedicGear[4] = "repairpack";		$Spoonbot::MedicAmmo[4] = "1";
$SpoonBot::MedicGear[5] = "";

$Spoonbot::MedicClose = "PlasmaGun";
$Spoonbot::MedicLong  = "disclauncher";
$SpoonBot::MedicJet   = "blaster";
$Spoonbot::MedicPack  = "repairpack";

//=========================== Miner Gear
$SpoonBot::MinerMArmor  = "marmor";
$SpoonBot::MinerFArmor  = "mfemale";
$SpoonBot::MinerGear[0] = "blaster";		$Spoonbot::MinerAmmo[0] = "1";
$SpoonBot::MinerGear[1] = "disclauncher";	$Spoonbot::MinerAmmo[1] = "1";
$SpoonBot::MinerGear[2] = "discammo";		$Spoonbot::MinerAmmo[2] = "500";
$SpoonBot::MinerGear[3] = "repairpack";		$Spoonbot::MinerAmmo[3] = "1";
$SpoonBot::MinerGear[4] = "repairkit";		$Spoonbot::MinerAmmo[4] = "10";
$SpoonBot::MinerGear[5] = "MineAmmo";		$Spoonbot::MinerAmmo[5] = "100";
$SpoonBot::MinerGear[6] = "";

$Spoonbot::MinerClose = "disclauncher";
$Spoonbot::MinerLong  = "disclauncher";
$SpoonBot::MinerJet   = "blaster";
$Spoonbot::MinerPack  = "AmmoPack";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "spyarmor";
$SpoonBot::SniperFArmor  = "spyfemale";
$SpoonBot::SniperGear[0] = "PlasmaGun";		$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "plasmaammo";	$Spoonbot::SniperAmmo[1] = "500";
$SpoonBot::SniperGear[2] = "LaserRifle";	$Spoonbot::SniperAmmo[2] = "1";
$SpoonBot::SniperGear[3] = "energypack";	$Spoonbot::SniperAmmo[3] = "1";
$SpoonBot::SniperGear[5] = "BoomStick"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::SniperGear[6] = "Boomammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::SniperGear[4] = "CloakingDevice";

$Spoonbot::SniperClose = "boomStick";
$Spoonbot::SniperLong  = "laserRifle";
$SpoonBot::SniperJet   = "plasmaGun";
$Spoonbot::SniperPack  = "energypack";

//=========================== Painter Gear
$SpoonBot::PainterMArmor  = "larmor";
$SpoonBot::PainterFArmor  = "lfemale";
$SpoonBot::PainterGear[0] = "TargetingLaser";	$Spoonbot::PainterAmmo[0] = "1";
$SpoonBot::PainterGear[1] = "PlasmaGun";	$Spoonbot::PainterAmmo[1] = "1";
$SpoonBot::PainterGear[2] = "plasmaammo";	$Spoonbot::PainterAmmo[2] = "500";
$SpoonBot::PainterGear[3] = "disclauncher"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::PainterGear[4] = "discammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::PainterGear[5] = "BoomStick"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::PainterGear[6] = "Boomammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::PainterGear[7] = "";

$Spoonbot::PainterClose = "PlasmaGun";
$Spoonbot::PainterLong  = "TargetingLaser";
$SpoonBot::PainterJet   = "BoomStick";
$Spoonbot::PainterPack  = "";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "marmor";
$SpoonBot::StandardFArmor  = "mfemale";
$SpoonBot::StandardGear[0] = "energypack";		$Spoonbot::StandardAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "plasmaGun";		$Spoonbot::StandardAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "plasmaammo";		$Spoonbot::StandardAmmo[2] = "500";
$SpoonBot::StandardGear[3] = "dislauncher";		$Spoonbot::StandardAmmo[3] = "1";
$SpoonBot::StandardGear[4] = "discammo";		$Spoonbot::StandardAmmo[4] = "500";
$SpoonBot::StandardGear[5] = "";

$Spoonbot::StandardClose = "PlasmaGun";
$Spoonbot::StandardLong  = "disclauncher";
$SpoonBot::StandardJet   = "disclauncher";
$Spoonbot::StandardPack  = "energypack";
