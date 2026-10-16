// Want MiniMod to tell you when there's a problem with a file?
$MiniMod::MonitorErrors = True;

// Would You like to reduce the amount of time that newbie's hog at the Inv.Stations?
$AutoBuy::Loadouts::Engineer 		= True;
$AutoBuy::Loadouts::Changeling 	= True;
$AutoBuy::Loadouts::Specialist 	= True;
$AutoBuy::Loadouts::SCV 		= True;
$AutoBuy::Loadouts::Transformer 	= True;
$AutoBuy::Loadouts::Heavy 		= True;
$AutoBuy::Loadouts::DreadNaught 	= True;
// Automatic Inventory checking.
$Engineer		= True;
$Changeling		= True;
$Specialist		= True;
$Juggernaught	= True;
$SCV			= True;
$Transformer	= True;
$Heavy		= True;
$DreadNaught	= True;

// Advanced Weapons options. (Options for the TAB menu.)
$WeaponOptions = true;

// Server Options.
$VoteAdmin			= true; // Users can vote to Admin.
$VoteKick			= true; // Users can vote to kick.
$VoteDisableTeamDmg	= true; // Users can vote to disable team damage.
$VoteFreeForAll		= true; // Users can vote to enable "Free For All" mode.
$UserBots			= true; // Users can spawn bots.

// Diagnostic option for when admins request Me to stop by an help fix their setup. :)
$Give::Dewy::Diagnostic::access = false; // PORT: was true (the hook it switched is commented out in MiniMod-v1.cs)

//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

//==== Wild card IP's must just be left blank. Do NOT use the * in place of an octet. Note below for an example.

//PORT-OFF: $Server::AutoAdmin0 = "Dewy";				// Enter the PlayerName to be given Admin here
//PORT-OFF: $Server::AutoAdmin1 = "Emo1313";
//PORT-OFF: $Server::AutoAdmin2 = "Emo1313";
//PORT-OFF: $Server::AutoAdmin3 = "Karaya";
//PORT-OFF: $Server::AutoAdmin4 = "Karaya";
//PORT-OFF: $Server::AutoAdmin5 = "Emo1313";
//PORT-OFF: $Server::AutoAdmin6 = "Thai";

//PORT-OFF: $Server::AutoAdminAddr1 = "IP:209.186";       //== Enter The Players Address Here
//PORT-OFF: $Server::AutoAdminAddr1 = "IP:192.168.0";
//PORT-OFF: $Server::AutoAdminAddr2 = "IP:207.13.31.10";
//PORT-OFF: $Server::AutoAdminAddr3 = "IP::209.196";
//PORT-OFF: $Server::AutoAdminAddr4 = "IPX";
//PORT-OFF: $Server::AutoAdminAddr5 = "IPX";
//PORT-OFF: $Server::AutoAdminAddr6 = "IP:208";
							
//=========================================================================================================================================
// Server Options
//=========================================================================================================================================

$Shifter::Weapons = True;                               //== Advanced Weapon Options On 
$Shifter::emailAddress = "emo1313@dopplegangers.com";	//== Email address to show banned users for reinstatement
$Shifter::VoteAdmin =  True;							//== Can players initiate vote to admin
$Shifter::VoteKick = True;								//== Can players initiate vote to kick
$Shifter::VoteFFA = False;								//== Clients can Vote For FFA or Tournement Mode
$Shifter::RandomMissions = True;						//== Random Missions on/off

$Shifter::KeepBalanced = True;							//== Keep Balanced
$Shifter::SpawnRandom = True;							//== Turn on Random Spawn Setup?
$Shifter::NoOutside = True;								//== Turn on Outside of mission area damage
$Shifter::TurretKill = False;                           //== Turret Kills Count For Player
$Shifter::PersonalSkin = True;				//== Personal Skins On or Off

//=========================================================================================================================================
// Advanced Flag Options
//=========================================================================================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";

//=========================================================================================================================================
// Advanced Scoring System
//=========================================================================================================================================
$ScoreOn = True;		    		//== If True will show client thier score on change in a bottom print message for 3 seconds.

$Score::25Meters = "5";     		//== Less Than 25 Meters To Flag
$Score::75Meters = "3";     		//== From 25 to 75 Meters
$Score::150Meters = "2";    		//== From 75 to 150 Meters
$Score::250Meters = "1";    		//== From 150 to 250 Meters

$Score::FlagCapture = "15";			//== Points For A Successful Flag Capture 
$Score::FlagKill = "7";  			//== Bonus For Killing Flag Runner
$Score::FlagDef  = "3";   			//== Bonus Points For Defending The Runner
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
$Score::ObjGeneratorB = "10";   //== Destroy Large Generator
$Score::ObjGeneratorS = "5";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors

$Score::ObjTurretL = "3";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets

$Score::Kill15Meters = "0";		//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";		//== Kill From 15 to 50m
$Score::Kill100Meters = "1";	//== Kill From 50 to 100m
$Score::Kill250Meters = "2";	//== Kill From 100 to 250m
$Score::Kill250Plus = "3";		//== Kill 250m Or More

$Score::RepairObject = "1";     //== Repair Bonus. Base Points For Repair...

$Shifter::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========================================================================================================================================
// Fair Teams Variables
//=========================================================================================================================================

$Shifter::FairTeams = True;  //== Is Fair Teams Is On
$Shifter::FairCheck = "30";  //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "120"; //== Number in seconds that Shifter will move the last connected player to the un even team.

//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================

$Shifter::TeamKillOn 	= "False";			//== Is Anti TK On/Off
$Shifter::KillTerm 		= "1";				//== Number Of Time A Player Can Team Kill
											//== Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "1";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "600";		//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "2";			//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "50";        	//== Proximity Distance For Accidental Damage.
	
//=========================================================================================================================================
// Varrious Server Messages To The Client
//=========================================================================================================================================

//================================================================= Message To Banned Team Killer
$Shifter::TeamKillMsg = "You have been kick and banned for team killing, i hope you enjoyed it. Email:" @ $Shifter::emailAddress @ " for reinstatement.";

//=========================================================================================================================================
// Set Default Anti-TK Functions
//=========================================================================================================================================

if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 600;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 2;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;

//--------------------
//SpoonBot controls
//--------------------
$Spoonbot::SPOONBOTCSLOADED = True;   // DO NOT CHANGE THIS LINE!!!

// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.

$Spoonbot::DebugMode = False;
$Spoonbot::AutoSpawn = False;			//== Automatic bot-spawning on
$Spoonbot::BotTree_Design = False;		//== Enables Bot tree design mode
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.
 
$Spoonbot::UserMenu = True;			//== Users may add/remove bots via menu
$Spoonbot::BotChat = True;			//== If the bot's chat messages annoy you, you can turn them off here.

$BotTree::DebugMode = False;
    

$Spoonbot::RespawnDelay = 10;		//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 100;				//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.
$Spoonbot::ThinkingInterval = 1;	//== Interval in sec between which bots will "reconsider" their situation
								 //== NOTE: RespawnDelay MUST be higher than ThinkingInterval


$Spoonbot::RetreatDamageLevel = 1.0;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.
						//== To disable retreating, set to 1.0

$BotHUD::ToggleKey = "b";			//== CTRL + this key will open the BotHUD.
						//== The BotHUD displays what your bots are doing at the moment.


$Spoonbot::DefaultTeamEnergy = Infinite;		//== The default energy each team starts with. Set to "Infinite" for standard TRIBES rules,
						//== or set to 1000 or similar for having to worry about cash ;-)



						//== Now, the auto-spawned bots are being set up
						//== NOTE: $Spoonbot::AutoSpawn must be "True" for this to work!!




$Spoonbot::Bot1Name = "Scotty_Guard_Roam_Male";
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Uhura_Sniper_Roam_Female";
$Spoonbot::Bot2Team = 0;

$Spoonbot::Bot3Name = "Chapel_Painter_Roam_Female";
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "Spock_Demo_Roam_Male";
$Spoonbot::Bot4Team = 0;

$Spoonbot::Bot5Name = "Checkov_Mortar_Roam_Male";
$Spoonbot::Bot5Team = 0;

$Spoonbot::Bot6Name = "Sulu_Miner_Roam_Male";
$Spoonbot::Bot6Team = 0;


$Spoonbot::Bot7Name = "Shag_Guard_Roam_Male";
$Spoonbot::Bot7Team = 1;

$Spoonbot::Bot8Name = "Colleen_Sniper_Roam_Female";
$Spoonbot::Bot8Team = 1;

$Spoonbot::Bot9Name = "Exile_Painter_Roam_Male";
$Spoonbot::Bot9Team = 1;

$Spoonbot::Bot10Name = "Hunter_Demo_Roam_Male";
$Spoonbot::Bot10Team = 1;

$Spoonbot::Bot11Name = "Balto_Mortar_Roam_Male";
$Spoonbot::Bot11Team = 1;

$Spoonbot::Bot12Name = "Jenna_Miner_Roam_Female";
$Spoonbot::Bot12Team = 1;



//==========================================================================================================================================
// The following bot configurations should be used ONLY by admins who know what they are doing... This can seriously mess up the way the
// bots in Shifter/Spoon Bots work... Please make very sure of what you are doing before you alter any of these settings!!!
//==========================================================================================================================================


//================================= The following weapons are for what the bot will use when the enemy is...
//================================= The Pack is the pack that the bot will have mounted.
//================================= All items listed here **MUST** be listed in the particular bots inventory below...

//=========================== Mortar Gear
$Spoonbot::MortarMArmor  = "harmor";
$Spoonbot::MortarFArmor  = "harmor";
$Spoonbot::MortarGear[0] = "mortar";		$Spoonbot::MortarAmmo[0] = "1";
$Spoonbot::MortarGear[1] = "mortarammo";		$Spoonbot::MortarAmmo[1] = "500";
$Spoonbot::MortarGear[2] = "chaingun";		$Spoonbot::MortarAmmo[2] = "1";
$Spoonbot::MortarGear[3] = "bulletammo";		$Spoonbot::MortarAmmo[3] = "50000";
$SpoonBot::MortarGear[4] = "PlasmaGun";		$Spoonbot::MortarAmmo[4] = "1";
$SpoonBot::MortarGear[5] = "plasmaammo";		$Spoonbot::MortarAmmo[5] = "500";
$Spoonbot::MortarGear[6] = "energypack";		$Spoonbot::MortarAmmo[6] = "1";
$Spoonbot::MortarGear[7] = "";

$Spoonbot::MortarClose = "PlasmaGun"; 
$Spoonbot::MortarLong  = "mortar";
$SpoonBot::MortarJet   = "chaingun";
$Spoonbot::MortarPack  = "energypack";

//=========================== Guard Gear
$Spoonbot::GuardMArmor  = "harmor";
$Spoonbot::GuardFArmor  = "harmor";
$Spoonbot::GuardGear[0] = "mortar";		$Spoonbot::GuardAmmo[0] = "1";
$Spoonbot::GuardGear[1] = "mortarammo";		$Spoonbot::GuardAmmo[1] = "500";
$Spoonbot::GuardGear[2] = "chaingun";		$Spoonbot::GuardAmmo[2] = "1";
$Spoonbot::GuardGear[3] = "bulletammo";		$Spoonbot::GuardAmmo[3] = "50000";
$SpoonBot::GuardGear[4] = "PlasmaGun";		$Spoonbot::GuardAmmo[4] = "1";
$SpoonBot::GuardGear[5] = "plasmaammo";		$Spoonbot::GuardAmmo[5] = "500";
$Spoonbot::GuardGear[6] = "energypack";		$Spoonbot::GuardAmmo[6] = "1";
$Spoonbot::GuardGear[7] = "";

$Spoonbot::GuardClose = "PlasmaGun"; 
$Spoonbot::GuardLong  = "mortar";
$SpoonBot::GuardJet   = "chaingun";
$Spoonbot::GuardPack  = "energypack";

//=========================== Demo Gear
$SpoonBot::DemoMArmor  = "marmor";
$SpoonBot::DemoFArmor  = "mfemale";
$SpoonBot::DemoGear[0] = "PlasmaGun";		$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::DemoGear[1] = "plasmaammo";		$Spoonbot::DemoAmmo[1] = "500";
$SpoonBot::DemoGear[2] = "disclauncher";	$Spoonbot::DemoAmmo[2] = "1";
$SpoonBot::DemoGear[3] = "discammo";		$Spoonbot::DemoAmmo[3] = "500";
$SpoonBot::DemoGear[4] = "chaingun";		$Spoonbot::DemoAmmo[4] = "1";
$SpoonBot::DemoGear[5] = "bulletammo";		$Spoonbot::DemoAmmo[5] = "50000";
$SpoonBot::DemoGear[6] = "";

$Spoonbot::DemoClose = "Plasmagun";
$Spoonbot::DemoLong  = "disclauncher";
$SpoonBot::DemoJet   = "chaingun";
$Spoonbot::DemoPack  = "energypack";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "marmor";
$SpoonBot::MedicFArmor  = "mfemale";
$SpoonBot::MedicGear[0] = "blaster";		$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "PlasmaGun";		$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "plasmaammo";		$Spoonbot::MedicAmmo[2] = "500";
$SpoonBot::MedicGear[3] = "disclauncher";	$Spoonbot::MedicAmmo[3] = "1";
$SpoonBot::MedicGear[4] = "discammo";		$Spoonbot::MedicAmmo[4] = "500";
$SpoonBot::MedicGear[5] = "repairkit";		$Spoonbot::MedicAmmo[5] = "1";
$SpoonBot::MedicGear[6] = "repairpack";		$Spoonbot::MedicAmmo[6] = "1";
$SpoonBot::MedicGear[7] = "";

$Spoonbot::MedicClose = "PlasmaGun";
$Spoonbot::MedicLong  = "disclauncher";
$SpoonBot::MedicJet   = "blaster";
$Spoonbot::MedicPack  = "repairpack";

//=========================== Miner Gear
$SpoonBot::MinerMArmor  = "larmor";
$SpoonBot::MinerFArmor  = "lfemale";
$SpoonBot::MinerGear[0] = "chaingun";		$Spoonbot::MinerAmmo[0] = "1";
$SpoonBot::MinerGear[1] = "PlasmaGun";		$Spoonbot::MinerAmmo[1] = "1";
$SpoonBot::MinerGear[2] = "plasmaammo";		$Spoonbot::MinerAmmo[2] = "500";
$SpoonBot::MinerGear[3] = "energypack";		$Spoonbot::MinerAmmo[3] = "1";
$SpoonBot::MinerGear[4] = "repairkit";		$Spoonbot::MinerAmmo[4] = "1";
$SpoonBot::MinerGear[5] = "bulletammo";		$Spoonbot::MinerAmmo[5] = "50000";
$SpoonBot::MinerGear[6] = "grenadelauncher";	$Spoonbot::MinerAmmo[6] = "1";
$SpoonBot::MinerGear[7] = "grenadeammo";	$Spoonbot::MinerAmmo[7] = "5000";
$SpoonBot::MinerGear[9] = "";

$Spoonbot::MinerClose = "PlasmaGun";
$Spoonbot::MinerLong  = "grenadelauncher";
$SpoonBot::MinerJet   = "chaingun";
$Spoonbot::MinerPack  = "energypack";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "larmor";
$SpoonBot::SniperFArmor  = "lfemale";
$SpoonBot::SniperGear[0] = "PlasmaGun";		$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "plasmaammo";	$Spoonbot::SniperAmmo[1] = "500";
$SpoonBot::SniperGear[2] = "LaserRifle";	$Spoonbot::SniperAmmo[2] = "1";
$SpoonBot::SniperGear[3] = "energypack";	$Spoonbot::SniperAmmo[3] = "1";
$SpoonBot::SniperGear[4] = "";

$Spoonbot::SniperClose = "PlasmaGun";
$Spoonbot::SniperLong  = "LaserRifle";
$SpoonBot::SniperJet   = "LaserRifle";
$Spoonbot::SniperPack  = "energypack";

//=========================== Painter Gear
$SpoonBot::PainterMArmor  = "larmor";
$SpoonBot::PainterFArmor  = "lfemale";
$SpoonBot::PainterGear[0] = "TargetingLaser";	$Spoonbot::PainterAmmo[0] = "1";
$SpoonBot::PainterGear[1] = "PlasmaGun";	$Spoonbot::PainterAmmo[1] = "1";
$SpoonBot::PainterGear[2] = "plasmaammo";	$Spoonbot::PainterAmmo[2] = "500";
$SpoonBot::PainterGear[3] = "disclauncher"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::PainterGear[4] = "discammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::PainterGear[5] = "";

$Spoonbot::PainterClose = "PlasmaGun";
$Spoonbot::PainterLong  = "TargetingLaser";
$SpoonBot::PainterJet   = "DiscLauncher";
$Spoonbot::PainterPack  = "energypack";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "marmor";
$SpoonBot::StandardFArmor  = "mfemale";
$SpoonBot::StandardGear[0] = "energypack";		$Spoonbot::StandardAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "PlasmaGun";		$Spoonbot::StandardAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "plasmaammo";		$Spoonbot::StandardAmmo[2] = "500";
$SpoonBot::StandardGear[3] = "disclauncher";		$Spoonbot::StandardAmmo[3] = "1";
$SpoonBot::StandardGear[4] = "discammo";		$Spoonbot::StandardAmmo[4] = "500";
$SpoonBot::StandardGear[5] = "chaingun";		$Spoonbot::StandardAmmo[5] = "1";
$SpoonBot::StandardGear[6] = "bulletammo";		$Spoonbot::StandardAmmo[6] = "5000";
$SpoonBot::StandardGear[7] = "";

$Spoonbot::StandardClose = "PlasmaGun";
$Spoonbot::StandardLong  = "disclauncher";
$SpoonBot::StandardJet   = "chaingun";
$Spoonbot::StandardPack  = "energypack";


