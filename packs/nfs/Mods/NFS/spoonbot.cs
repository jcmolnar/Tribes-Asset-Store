// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.


$Spoonbot::AutoSpawn = false;			//== Automatic bot-spawning on
$Spoonbot::UserMenu = True;			//== Users may add/remove bots via menu
$Spoonbot::AtomicBomb = True;			//== To disable the Atomic Bomb for HPC vehicles, change this to "False"
$Spoonbot::BotJetting = false;			//== The bot "jetting" is very "jumpy" right now, so you can switch that off if it annoys you
$Spoonbot::BotChat = false;			//== If the bot's chat messages annoy you, you can turn them off here.

$Spoonbot::RespawnDelay = 30;			//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 90;				//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.
$Spoonbot::ThinkingInterval = 5;		//== Interval in sec between which bots will "reconsider" their situation
						//== NOTE: RespawnDelay MUST be higher than ThinkingInterval


$Spoonbot::BotsRetreat = True;			//== Bots will retreat if severely damaged
$Spoonbot::RetreatDamageLevel = 0.8;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.



						//== Now, the auto-spawned bots are being set up
						//== NOTE: $Spoonbot::AutoSpawn must be "True" for this to work!!



$Spoonbot::Bot1Name = "Uhura_Demo_Female_Roam"; //== Set up bots for first team
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Kirk_Guard_Male_Roam";
$Spoonbot::Bot2Team = 0;

$Spoonbot::Bot3Name = "Spock_Sniper_Male_Roam";
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "McCoy_Medic_Male_Roam";
$Spoonbot::Bot4Team = 0;



$Spoonbot::Bot5Name = "Mom_Demo_Female_Roam";  //== Set up bots for second team
$Spoonbot::Bot5Team = 1;

$Spoonbot::Bot6Name = "Dad_Guard_Male_Roam";
$Spoonbot::Bot6Team = 1;

$Spoonbot::Bot7Name = "Dexter_Sniper_Male_Roam";
$Spoonbot::Bot7Team = 1;

$Spoonbot::Bot8Name = "DeeDee_Medic_Female_Roam";
$Spoonbot::Bot8Team = 1;

