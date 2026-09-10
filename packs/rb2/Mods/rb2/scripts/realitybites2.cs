/////////////////////////////ADMINISTRATION\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////////////////
// This is Reality Bites' server administration area.  Read each       //
// section note for help.  You may need it. 			       ||		
// Go to www.cfareno.com/reality for more information  	    	       \\
////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////////////////

//             Basic settings

$JoinMessage = "<jc><f1>--REALITY BITES 2.0-- \n <f0>Server Unnamed. \n \n VISIT REALITY BITES ON THE WEB! \n<f3>www.cfareno.com/reality \n\n <f0>---------------.";
$telnetport = 2000;
$telnetpassword = "password";


// List your admins here.  Separate them with a \n to add a new line for each one.
$AdminList = "<jc><f1>YOUR SUPER ADMINS<f2>\nAdmin1\nAdmin2\nYou could be here\nOr here";

$CapPoints = 10; //Points you get for capping flags
$RecordScores = True; //Will server save scores to a file?
$AutoBaseRepair = True; // Will the base slowly repair itself?
$rb::BaseAlarmsEnemiesOnly = true;	// Alarms should only detect enemies?
$rb::VoteToChangeGameMode = true; //allow vote to change to FFA mode?
$rb::ChangeTeamsFreely = true;  //allow people to change teams?

//How much kickback should bullets knock you around for?  Pounds per bullet velocity/1000.
$rb::kickpower = 40;

//Throw the player back into the game if they are out of bounds?
$rb::rebound = true;

//How many seconds of spawn protection do you want? Set to 0 for none.
$rb::spawnprotection = 3;

$rb::energyrechargerate = 8;

////////////////////////////////PASSWORDS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////////
// Change anything you want here, and use ' %player ' to add the name
// of the person using the SAD password into the text.
// You can also add sound to your login message with the ~w wave file command.
// For example, adding ~wshell_click.wav to the end of your text would
// add a beep when the person logs in that everyone can hear.
// There are special SAD passwords that are used for other things besides
// logins.  There are some that do funny things, and some that change
// server settings on the fly, like turning off the sensor networks.
////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////////

//Admins Passwords -------------

// If the person is trying to guess a password, have it say this...

$GuessText = "%person is failing miserably at guessing the admin password.  Dork. ~wmine_act.wav";

// Put    $GuessText = "";    if you don't want it to say anything when
// the wrong password is used.

// Person running the server
$OwnerName = "Owner";
$OwnerPassWord = "ownerpassword";
$OwnerText = "%person, the server owner, has logged in. ~wshell_click.wav";

// Global SUPER Admin password.  Be careful who you share this with
$MasterPassWord = "masterpassword";
$MasterText = "%person has been blessed with " @ $OwnerName @ "'s gift. ~wshell_click.wav";

// Your clan password.  Gives limited admin abilities to your clan members.
$ClanPassword = "clanpassword";
$Clantext = " %person has logged in with clan power! ~wshell_click.wav";

// Your QUASI admin password.  Same as clan admin power but for non-clan members.
$QuasiPassword = "quasi";
$QuasiText = "%person has logged in with QUASI power! ~wshell_click.wav";

// Your Elite player password.  Give this to people that you feel are really good at
// this mod.  It does NOT give them any admin password.  It just gives them bragging rights.
$ElitePassword = "quasipassword";
$EliteText = "%person has logged in with RB MOD elite player status! ~wshell_click.wav";

// Your newbie password.  Give this to people that ask for admin but don't deserve it.
// It's a good trick to play on newbies who ask for admin.  It also removes any admin
// That someone may have, so they can call votes.
$NewbiePassword = "newbie";
$NewbieText = "%person has logged in as a dumb newbie. ~wshell_click.wav";

/////////////////////////////////////////////////////////////////////////////
// Fun Passwords -- You can add up to 100 of these.  They don't do anything//
// except add a message for everyone to see.  Basically just for having    //
// fun with the SAD passwords.  You can NOT put a gap between numbers, like//
// jumping from $Funpassword[10] to [12] and skipping 11.                  //
/////////////////////////////////////////////////////////////////////////////
$FunPassword[0] = "cheese";
$FunText[0] = "%person is in need of a good beating ~wshell_click.wav";

$FunPassword[1] = "beer";
$FunText[1] = "%person wants beer!  GIVE HIM BEER! ~wshell_click.wav";

$FunPassword[2] = "funpassword2";
$FunText[2] = "%person used fun password 2 ~wshell_click.wav";

$FunPassword[3] = "funpassword3";
$FunText[3] = "%person used fun password 3 ~wshell_click.wav";

$FunPassword[4] = "funpassword4";
$FunText[4] = "%person used fun password 4 ~wshell_click.wav";

$FunPassword[5] = "funpassword5";
$FunText[5] = "%person used fun password 5 ~wshell_click.wav";

$FunPassword[6] = "funpassword6";
$FunText[6] = "%person used fun password 6 ~wshell_click.wav";

$FunPassword[7] = "funpassword7";
$FunText[7] = "%person used fun password 7 ~wshell_click.wav";

$FunPassword[8] = "funpassword8";
$FunText[8] = "%person used fun password 8 ~wshell_click.wav";

/////////////////////////////////////////////////////////////////////////////
// Deadly Passwords -- These passwords are like fun passwords, except they //
// nuke whoever uses them.  These are good to give to newbies who want the //
// admin password.  You can have up to 100 of these passwords.  Remember   //
// that you cannot add gaps between numbers or they won't work!            //
/////////////////////////////////////////////////////////////////////////////

$DeadlyPassword[0] = "deadly";
$DeadlyText[0] = "%person thinks he can figure out the sad password. ~wfloat_target.wav";

$DeadlyPassword[1] = "superdeadly";
$DeadlyText[1] = "%person doesn't know the password. ~wfloat_target.wav";

$DeadlyPassword[2] = "boobies";
$DeadlyText[2] = "%person is a pervert ~wfloat_target.wav";

$DeadlyPassword[3] = "deadlypassword3";
$DeadlyText[3] = "%person used deadly password 3 ~wfloat_target.wav";

$DeadlyPassword[4] = "deadlypassword4";
$DeadlyText[4] = "%person used deadly password 4 ~wfloat_target.wav";

$DeadlyPassword[5] = "deadlypassword5";
$DeadlyText[5] = "%person used deadly password 5 ~wfloat_target.wav";

$DeadlyPassword[6] = "deadlypassword6";
$DeadlyText[6] = "%person used deadly password 6 ~wfloat_target.wav";

$DeadlyPassword[7] = "deadlypassword7";
$DeadlyText[7] = "%person used deadly password 7 ~wfloat_target.wav";

$DeadlyPassword[8] = "deadlypassword8";
$DeadlyText[8] = "%person used deadly password 8 ~wfloat_target.wav";

//////////////////////////////////////////////////////////////////////////////
// Entertaining passwords -- These do miscellaneous things like launch      //	
// players into orbit, make them dance, etc.				    //	
//////////////////////////////////////////////////////////////////////////////

$DancePassword = "dance";  // Makes the person dance
$DanceText = "%person is doing the jig ~wfloat_target.wav";

$LaunchPassword = "launch";  //Launches the person 1500 feet into the air
$LaunchText = "%person wanted to see how the clouds taste today. ~wfloat_target.wav";

$ThrowPassword = "throw";
$ThrowText = "%person's rocket booster went haywire. ~wfloat_target.wav"; // Throws the person 1500 feet eastward

//////////////////////////////////////////////////////////////////////////////
// Game settings passwords.  Use these to change aspects of the game.       //	
// Further updates of Reality Bites will include more of these		    //	
//////////////////////////////////////////////////////////////////////////////

$SensorPassword = "senseless"; // Turn on/off sensor network

// If you change the mod scripts in ANY WAY you MUST change the mod name to
// something other than reality bites.  By changing the mod,
// you are no longer a part of the reality bites team.

//this may not work anymore in reality bites 2.0.  It is
//still being debated.

$rbmodlist = "\nReality Bites 1.4.2";  





