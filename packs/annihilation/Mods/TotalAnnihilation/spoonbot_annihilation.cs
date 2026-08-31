//-------------------------------------------------------------------
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

$Console::logMode=1;


// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.

$Spoonbot::DebugMode = False;
$BotTree::DebugMode = False;
$Pilot::DebugMode = False;

$Pilot::WaypointEditor = False;	 		//== To create vehicle paths for new maps, enable this 
						//== and press F5 in game to drop waypoints

$Spoonbot::AutoSpawn = False;			//== Automatic bot-spawning on
$Spoonbot::BotTree_Design = False;		//== Enables Bot tree design mode
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.

$BotTree::AutoTree=False;			//== Change this to False for totally manual treepoint placement
						//== WARNING: Can lead to broken routes if you don't place enough treepoints!! Leave it enabled!!
 
$Spoonbot::UserMenu = True;			//== Users may add/remove bots via menu
$Spoonbot::BotChat = True;			//== If the bot's chat messages annoy you, you can turn them off here.

    

$Spoonbot::RespawnDelay = 25.0;		//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 240;				//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.


$Spoonbot::ThinkingInterval = 5; //4 6 5	//== Interval in sec between which bots will "reconsider" their situation
					//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
					//== ANOTHER NOTE: The slower your CPU, the higher this should be.


$Spoonbot::MovementInterval = 1.5; // 2 3 1.5 //== Interval in sec between calls of the Movement code.
					//== This should be generally lower than ThinkingInterval
					//== NOTE: Again, the slower your CPU, the higher this should be.
					//== If you experience "lag", set these values even higher.

$BotHUD::ToggleKey = "b";			//== CTRL + this key will open the BotHUD.
						//== The BotHUD displays what your bots are doing at the moment.


$Spoonbot::DefaultTeamEnergy = Infinite;		//== The default energy each team starts with. Set to "Infinite" for standard TRIBES rules,
						//== or set to 1000 or similar for having to worry about cash ;-)



						//== Now, the auto-spawned bots are being set up
						//== NOTE: $Spoonbot::AutoSpawn must be "True" for this to work!!

$Spoonbot::Bot1Name = "Optimus_Prime";
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Android18";
$Spoonbot::Bot2Team = 1;

$Spoonbot::Bot3Name = "Bumblebee";
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "Commander_Data";
$Spoonbot::Bot4Team = 1;

$Spoonbot::Bot5Name = "Megatron";
$Spoonbot::Bot5Team = 0;

$Spoonbot::Bot6Name = "T_800";
$Spoonbot::Bot6Team = 1;

$Spoonbot::Bot7Name = "Jetfire";
$Spoonbot::Bot7Team = 0;

$Spoonbot::Bot8Name = "R2_D2";
$Spoonbot::Bot8Team = 1;

$Spoonbot::Bot9Name = "Starscream";
$Spoonbot::Bot9Team = 0;

$Spoonbot::Bot10Name = "Asimo";
$Spoonbot::Bot10Team = 1;

$Spoonbot::Bot11Name = "Dinobot";
$Spoonbot::Bot11Team = 0;

$Spoonbot::Bot12Name = "Hal_9000";
$Spoonbot::Bot12Team = 1;

$Spoonbot::Bot13Name = "Sentinel_Prime";
$Spoonbot::Bot13Team = 0;

$Spoonbot::Bot14Name = "Spot";
$Spoonbot::Bot14Team = 1;