//$motd is the message of the day that is displayed on each clients connection.
$motd = "<f1><jc>Welcome to OldTribes";


$DeathTimeout = 10; 	// Seconds you must wait before respawning if you kill yourself
$PskinOpt = "true";	// Allow personal skins

// Anti TK options
$BasekillLimit = 5;	// Number of items from your own team you can destroy before a message is sent
$TeamKillWarns = 5;	// Number of teamkills you can make before being announced as a teamkiller
$TeamKillProximity = 50;	// Proximity to other players where a teamkill will count as accidental


//=========================================================================================================================================
// Advanced Scoring System (taken from shifter, slightly modified)
//=========================================================================================================================================
$ScoreOn = "True";		    	//== If True will show client their score on change in a bottom print message for 3 seconds.

$Score::10Meters = 5;     		//== Less Than 10 Meters To Flag
$Score::25Meters = 3;     		//== From 10 to 25 Meters
$Score::50Meters = 2;    		//== From 25 to 50 Meters

$Score::Driver = 2;            //== Killing the driver of an APC

$Score::FlagCapture = 15;		//== Points For A Successful Flag Capture 
$Score::FlagKill = 7;  		//== Bonus For Killing Flag Runner
$Score::FlagDef  = 3;   		//== Bonus Points For Defending The Runner
$Score::FlagReturn = 3;   		//== Points For Returning Dropped

$Score::CaptureObj = 2;   		//== Points For Capturing An Objective
$Score::HoldingObj = 5;   		//== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = 2;   		//== Points For Getting The Objective First

$Score::ObjDestroy = 15;      	//== Objective Destroyed
 
//=========================================================================================================================================
// Note about the following section... These points are awarded for destroying the enemy stations, generators, etc. 
// These points are also used in a calculation to give points for repairing things on your own team and to deduct points for
// repairing things on the enemy's team.
//
// The Lower option, Score::RepairObject is a base repair score. You can make this zero if you do not want players to get the 
// base 1 point for repairing... 
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

$Score::RepairObject = "1";     //== Repair Bonus. Base Points For Repair...

$Score::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========================================================================================================================================


