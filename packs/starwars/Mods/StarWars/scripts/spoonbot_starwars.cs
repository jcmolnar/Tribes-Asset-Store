//-------------------------------------------------------------------
// Modern Tribes: this is the TC's original config\spoonbot_starwars.cs, shipped inside the
// mod and exec'd from objectives.cs (the pack had dropped it). $Console::logMode removed.
$Spoonbot::StarWarsLoaded = 1;
$Spoonbot::SPOONBOTCSLOADED = True;	// DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot1Name = "0";
$Spoonbot::Bot2Name = "0";
$Spoonbot::Bot3Name = "0";
$Spoonbot::Bot4Name = "0";
$Spoonbot::Bot5Name = "0";
$Spoonbot::Bot6Name = "0";
$Spoonbot::Bot7Name = "0";
$Spoonbot::Bot8Name = "0";
$Spoonbot::Bot9Name = "0";
$Spoonbot::Bot10Name = "0";
$Spoonbot::Bot11Name = "0";
$Spoonbot::Bot12Name = "0";
$Spoonbot::Bot13Name = "0";
$Spoonbot::Bot14Name = "0";
$Spoonbot::Bot15Name = "0";
$Spoonbot::Bot16Name = "0";
$Spoonbot::Bot17Name = "0";
$Spoonbot::Bot18Name = "0";
$Spoonbot::Bot19Name = "0";
$Spoonbot::Bot20Name = "0";
//-------------------------------------------------------------------


//YOU MAY CHANGE EVERYTHING BELOW AS NEEDED



// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.

$Spoonbot::DebugMode = False;
$BotTree::DebugMode = False;
$Pilot::DebugMode = False;

$Pilot::WaypointEditor = False;	 		//== To create vehicle paths for new maps, enable this 
						//== and press F5 in game to drop waypoints

$Spoonbot::AutoSpawn = True;			//== Automatic bot-spawning on
$Spoonbot::BotTree_Design = False;		//== Enables Bot tree design mode
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.

$BotTree::AutoTree=False;			//== Change this to False for totally manual treepoint placement
						//== WARNING: Can lead to broken routes if you don't place enough treepoints!! Leave it enabled!!
 
$Spoonbot::UserMenu = True;			//== Users may add/remove bots via menu
$Spoonbot::BotChat = False;			//== If the bot's chat messages annoy you, you can turn them off here.

    

$Spoonbot::RespawnDelay = 10;		//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 240;				//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.


$Spoonbot::ThinkingInterval = 5;	//== Interval in sec between which bots will "reconsider" their situation
					//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
					//== ANOTHER NOTE: The slower your CPU, the higher this should be.


$Spoonbot::MovementInterval = 1.5;	//== Interval in sec between calls of the Movement code.
					//== This should be generally lower than ThinkingInterval
					//== NOTE: Again, the slower your CPU, the higher this should be.
					//== If you experience "lag", set these values even higher.


$Spoonbot::RetreatDamageLevel = 1.0;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.
						//== To disable retreating, set to 1.0

$BotHUD::ToggleKey = "b";			//== CTRL + this key will open the BotHUD.
						//== The BotHUD displays what your bots are doing at the moment.


$Spoonbot::DefaultTeamEnergy = Infinite;		//== The default energy each team starts with. Set to "Infinite" for standard TRIBES rules,
						//== or set to 1000 or similar for having to worry about cash ;-)



						//== Now, the auto-spawned bots are being set up
						//== NOTE: $Spoonbot::AutoSpawn must be "True" for this to work!!




$Spoonbot::Bot1Name = "Trooper_Sniper_Roam_Male";
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Robot_Demo_Roam_Female";
$Spoonbot::Bot2Team = 0;

$Spoonbot::Bot3Name = "DarthMaul_Miner_Roam_Female";
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "Sandhog_Sniper_Roam_Male";
$Spoonbot::Bot4Team = 0;

$Spoonbot::Bot5Name = "Trooper_Miner_Roam_Male";
$Spoonbot::Bot5Team = 0;


$Spoonbot::Bot6Name = "DarthKale_Sniper_Roam_Male";
$Spoonbot::Bot6Team = 1;

$Spoonbot::Bot7Name = "Trooper1_Demo_Roam_Male";
$Spoonbot::Bot7Team = 1;

$Spoonbot::Bot8Name = "Sandhog1_Miner_Roam_Female";
$Spoonbot::Bot8Team = 1;

$Spoonbot::Bot9Name = "DarthMaul1_Sniper_Roam_Male";
$Spoonbot::Bot9Team = 1;

$Spoonbot::Bot10Name = "Robot1_Miner_Roam_Male";
$Spoonbot::Bot10Team = 1;




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
$Spoonbot::MortarGear[0] = "TBlaster";		$Spoonbot::MortarAmmo[0] = "1";
$Spoonbot::MortarGear[1] = "RSaber";		$Spoonbot::MortarAmmo[1] = "1";
$Spoonbot::MortarGear[2] = "BlasterAmmo";	$Spoonbot::MortarAmmo[2] = "500";
$Spoonbot::MortarGear[3] = "";

$Spoonbot::MortarClose = "RSaber"; 
$Spoonbot::MortarLong  = "TBlaster";
$SpoonBot::MortarJet   = "TBlaster";
$Spoonbot::MortarPack  = "";

//=========================== Guard Gear
$Spoonbot::GuardMArmor  = "harmor";
$Spoonbot::GuardFArmor  = "harmor";
$Spoonbot::GuardGear[0] = "TBlaster";		$Spoonbot::GuardAmmo[0] = "1";
$Spoonbot::GuardGear[1] = "RSaber";		$Spoonbot::GuardAmmo[1] = "1";
$Spoonbot::GuardGear[2] = "BlasterAmmo";	$Spoonbot::GuardAmmo[2] = "500";
$Spoonbot::GuardGear[3] = "";

$Spoonbot::GuardClose = "RSaber"; 
$Spoonbot::GuardLong  = "TBlaster";
$SpoonBot::GuardJet   = "TBlaster";
$Spoonbot::GuardPack  = "";

//=========================== Demo Gear
$SpoonBot::DemoMArmor  = "larmor";
$SpoonBot::DemoFArmor  = "larmor";
$SpoonBot::DemoGear[0] = "GSaber";		$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::DemoGear[1] = "HBlaster";		$Spoonbot::DemoAmmo[1] = "1";
$SpoonBot::DemoGear[2] = "BlasterAmmo";		$Spoonbot::DemoAmmo[2] = "500";
$SpoonBot::DemoGear[3] = "";

$Spoonbot::DemoClose = "GSaber";
$Spoonbot::DemoLong  = "HBlaster";
$SpoonBot::DemoJet   = "HBlaster";
$Spoonbot::DemoPack  = "";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "larmor";
$SpoonBot::MedicFArmor  = "larmor";
$SpoonBot::MedicGear[0] = "MSaber";		$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "NBlaster";		$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "BlasterAmmo";	$Spoonbot::MedicAmmo[2] = "500";
$SpoonBot::MedicGear[3] = "";

$Spoonbot::MedicClose = "MSaber";
$Spoonbot::MedicLong  = "NBlaster";
$SpoonBot::MedicJet   = "NBlaster";
$Spoonbot::MedicPack  = "";

//=========================== Miner Gear
$SpoonBot::MinerMArmor  = "darmor";
$SpoonBot::MinerFArmor  = "darmor";
$SpoonBot::MinerGear[0] = "RSaber";		$Spoonbot::MinerAmmo[0] = "1";
$SpoonBot::MinerGear[1] = "NBlaster";		$Spoonbot::MinerAmmo[1] = "1";
$SpoonBot::MinerGear[2] = "BlasterAmmo";		$Spoonbot::MinerAmmo[2] = "500";
$SpoonBot::MinerGear[3] = "";

$Spoonbot::MinerClose = "RSaber";
$Spoonbot::MinerLong  = "NBlaster";
$SpoonBot::MinerJet   = "NBlaster";
$Spoonbot::MinerPack  = "";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "rebeltroop";
$SpoonBot::SniperFArmor  = "rebeltroop";
$SpoonBot::SniperGear[0] = "ScoutGun";		$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "BBlaster";		$Spoonbot::SniperAmmo[1] = "1";
$SpoonBot::SniperGear[2] = "BlasterAmmo";	$Spoonbot::SniperAmmo[2] = "500";
$SpoonBot::SniperGear[3] = "";

$Spoonbot::SniperClose = "BBlaster";
$Spoonbot::SniperLong  = "BBlaster";
$SpoonBot::SniperJet   = "ScoutGun";
$Spoonbot::SniperPack  = "";

//=========================== Painter Gear
$SpoonBot::PainterMArmor  = "darmor";
$SpoonBot::PainterFArmor  = "darmor";
$SpoonBot::PainterGear[0] = "BSaber";		$Spoonbot::PainterAmmo[0] = "1";
$SpoonBot::PainterGear[1] = "BBlaster";		$Spoonbot::PainterAmmo[1] = "1";
$SpoonBot::PainterGear[2] = "BlasterAmmo"; 	$Spoonbot::PainterAmmo[2] = "500";
$SpoonBot::PainterGear[3] = "";

$Spoonbot::PainterClose = "BSaber";
$Spoonbot::PainterLong  = "BBlaster";
$SpoonBot::PainterJet   = "BBlaster";
$Spoonbot::PainterPack  = "";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "larmor";
$SpoonBot::StandardFArmor  = "larmor";
$SpoonBot::StandardGear[0] = "GSaber";		$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "HBlaster";		$Spoonbot::DemoAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "BlasterAmmo";		$Spoonbot::DemoAmmo[2] = "500";
$SpoonBot::StandardGear[3] = "";

$Spoonbot::StandardClose = "GSaber";
$Spoonbot::StandardLong  = "HBlaster";
$SpoonBot::StandardJet   = "HBlaster";
$Spoonbot::StandardPack  = "";
