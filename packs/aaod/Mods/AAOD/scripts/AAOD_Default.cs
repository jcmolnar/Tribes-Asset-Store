// ------------------------------------------------------------
//						AAOD Config File
//-------------------------------------------------------------
//	This file Contains the global variables used by the 
//	AAOD MOd to control things like EXP Gains & losses
//	As well as User Tracking Error Tracing etc...
//-------------------------------------------------------------

//*************************************************************
//					Trace Routines.....
//*************************************************************
//	console functions for Tracing....
//	assumes you are running a dedicated server or are in the cosonle screen on the host...
//	typing:  Logon();	will turn all tracing on and output all that data to the console.log file
//	typing:  Logoff();	will turn all tracing off and stop saving the console to the console.log file.
//	If the mod is not causing you problems etc.. I strongly recomend that 
//	you keep the tracing turned off. (Set all Trace vars to false.)
//	This keeps a load off the server....
//	You can even request a Version of the Mod from Valya[AAOD] without the trace routines..
//	email = darkserpent@home.com 
//-------------------------------------------------------------

$Server::FloodProtectionEnabled = true;	// Prevents Spamming


// PORT: was  $Console::LogMode = 0;  (0 was the 1998 game's own default, so the line changed nothing then).
// 1.50 logs by default and this line switched the server's console.log off at start-up.
// To turn logging off on purpose, set it in config\AAOD_cfg.cs or type LogOff(); in the console.
						//	Can set it to 2 if you will never need to access the lof file while the
						//	server is running. This save a little cpu hp since it will not close the file 
						//	between writes.

$traceExp	= false;		// Trace Exp functions
$tracedam	= false;	// Trace Damage Functions
$traceveh	= false;	// Trace all vehicle functions
$tracePwr	= false;	// Trace all Power Functions
$traceTE	= false;	// Trace Team Energy Functions
$traceObj	= false;	// Trace Object Creation etc.
$trace		= false;	// All other Traces
$testStuff	= false;	// Allows your own stuff to be killed
$traceMsgs	= true;		//	Shows all Messages in your Log...
$traceAll	= false;	// Show All Crap That May Be affected by this Mod



//***********************************************************
//	MISC. Game Variables.......
//***********************************************************

$boostStr		= 0.03;		//	Shield Node Shield Strength
$DeployPadTime	= 360;		// Number of seconds you have to deploy Teleport pads (5 Min)


$CheckExpTime	= 120;		// Number of seconds between checks to disperse Team Exp;
$ExpContainer	= false;	// Is there an EXP container to HOLD Team Exp. 
							// If 'true' this container controls dispersement of exp otherwise
							// it time controlled. Currently No Containers exist so this does not make any diff 

$StasisEnergyDrain		= 0.20;		// Percentage of Energy stasis Gun hit will Use Up

$DefaultTeamEnergy		= "20000";	//	The Default amount of Energy a Team Starts with. Set to "Infinite" to disable...
$MaxTeamEnergy			= 800000;	//	The Maximum Energy a Team can Aquire

$secTeamEnergy			= 30;		//	The Number of seconds between Team energy Gains (Dont Reduce this too much as it might cause lagg)
$RemoteAmmoEnergy		= 3500;		//	Amount of Team Energy in remote deployable Ammo stations
$RemoteInvEnergy		= 4000;		//	Amount Of Team Energy in Remote Deployable Inventory Stations
$InitialPlayerEnergy	= 8000;		//	How Much Team Energy a Player brings with him when He joins the game
$DefTeamEnergyInc		= 600;		//	Amount of Energy produced each cycle by default....
$ClassAIncrease			= 900;		//	Amount of Energy a Deployable Fabrication Generator Produces per cycle
$ClassBIncrease			= 1600;		//	Amount of Energy a Deployable Solar Fabrication Generator Produces per cycle

$TeammateSpending		= 0;		//	Set = to 0 if don't want the warning message
$WarnEnergyLow			= 5000;		//	Set = to 0 if don't want the warning message
$WarnTeamEnergy			= 0;		//	When the Energy Gained each cycle drops below this It Warns the team 
									//	to Deploy more Team Energy Generators. Set to a large negative number to stop
//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;
//---------------------------------------------------------------------------------
//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;
//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  
//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox	= 2;     //Number of remote turrets allowed in the area

$TurretBoxMaxLength	= 35;    //Define Max Length of the area
$TurretBoxMaxWidth	= 35;    //Define Max Width of the area
$TurretBoxMaxHeight = 8;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth	= 10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 5;    //Define Min Height from another turret

$MaxNumFieldsInBox	= 2;

$FFBxMnLength		= 1;
$FFBxMnWidth		= 3;
$FFBxMnHeight		= 3;

$FFBxMxLength		= 2;
$FFBxMxWidth		= 4;
$FFBxMxHeight		= 5;
$CBMarkerDuration	= 8;	// How Log a counter Battery Marker Stays with an attacker

//-------------------------------------------------------------
//	Experience Tracking Variables....
//*************************************************************

$TrackTime	= 480;		// Number of seconds between Dumps of exp
$MinExp		= 5;		// Minimum Number of Exp Pts in order for the server to 'keep' player on file

$TrackExp	= 0;		//	Wether or Not The Server will Track Exp
						//	0 = No Tracking Every Time Users Join They start at 0
						//	1 = Exp Is Tracked for Users in the AAODPlayers File but Users 
						//	    are not automatically tracked.
						//	2 = New Users Are Added to the DataBase Automatically and tracked.
							
$TrackMaxUsers = 300;	// The Maximum Number of Users The Server Will Track Exp For
						// This is Set just to limit the amount of time The Server
						// Will spend searching through the Data file for EXP
						// If you expereince Lag when new players Join your game you 
						// Should Trim you AAODPLayers File and Set this number to a lower 
						// Num.

//	************** DO NOT CHANGE ANY OF THESE *************
//	They Just Need to Be Initialized Before some of the 
//				Variables in this script.....
// ********************************************************

$Spd = 1;	//	1> Speed					( Faster Movement x1.25)
$Dur = 2;	//	2> Durability				( Tougher all damage reduced by % )
$Flt = 3;	//	3> Flight					( Jet pack uses 1/3 the Energy and produces 2x thrust)	
$Sth = 4;	//	4> Stealth					( Not Visible to sensors)
$Acc = 5;	//	5> Accuracy					( Does Extra Damage on Targets)
$Rgn = 6;	//	6> Regeneration				( Recovers Health at a minor Rate)
$Rch = 7;	//	7> Super Energy Recovery	( Recovers Energy Faster)
//********************************************************
//	End of the Data You should not Modify
//********************************************************


//--------------------------------------------
//		AAOD Experience & Skills  Block
//--------------------------------------------
//					The Number of Exp Pts required to reach Each Level
//			
$Level[0]	= 0;
$Level[1]	= 25;		// Exp Req = 25
$Level[2]	= 75;		// Exp Req = 50
$Level[3]	= 150;		// Exp Req = 75
$Level[4]	= 250;		// Exp Req = 100
$Level[5]	= 450;		// Exp Req = 200
$Level[6]	= 750;		// Exp Req = 300
$Level[7]	= 1200;		// Exp Req = 450
$Level[8]	= 1700;		// Exp Req = 500
$Level[9]	= 2400;		// Exp Req = 700
$Level[10]	= 3300;		// Exp Req = 900
$Level[11]	= 4500;		// Exp Req = 1200
$Level[12]	= 6000;		// Exp Req = 1500

$MaxExpLvl	= 12;			// The Max Experience Levels You Can Get = Total Number of Skills
$MaxExpPts	= 6200;			// the Maximum Pts You Can aquire

$ExpDeathLoss		= 3;	// # of Pts U loose Every Time U Die...
$ExpObjective		= 2;	// #
$ExpEnemyObjective	= 3;	// #
$ExpHeldObjective	= 6;	// #
$ExpObjectiveTime	= 90;	//	How long a Team must hold an objective before They wont Lose points for losing it.

$ExpFlagCap					= 6;	// # of Base Pts for a Flag Capture (Touched to Your Flag)
$ExpFlagGrab				= 2;	// # of Base Pts for grabbinbg the Enemy Flag
$ExpFlagReturn				= 3;	// # of Base Pts for grabbinbg the Enemy Flag
$ExpSuicide					= 2;	// Factor to Use when determining Suicide Penalty
$ExpValidTime				= 90;	// # of Seconds during which a player can die & You can still get exp

$ExpKill[Player]			= 1.5;	// # of Base Pts per level of the Player U get for killing Him.	
$ExpKill[Turret]			= 2;	// # of Pts for Destroying a Turret
$ExpKill["Elf Turret"]		= 2;	// # of Pts for Destroying a Turret
$ExpKill[Station]			= 2;	// # of Pts for Destroying an object
$ExpKill[DeployableStation]	= 1;

$ExpKill[Generator]			= 5;	// # of Pts for Destroying Generator
$ExpKill[pGen]				= 3;	

$ExpKill[ForceField]		= 0.5;
$ExpKill[AAODDep]			= 1;	// # of Pts for Destroying other objects
$ExpKill[Vehicles]			= 1;	
$ExpKill[ShieldGen]			= 8;	
$ExpKill[ShieldNode]		= 3;
$ExpKill[SensorNet]			= 4;
$ExpKill[TeamEGen]			= 6;
$ExpKill[Elevator]			= 1;
$ExpKill[Door]				= 1;

$RepairItemExp		= 1;	// # of Pts for Repairing an Item
$ItemKillExp		= 1;	// # of Pts U get for an Item u deployed Killing someone.
$ItemLossExp		= 2;	// # of Pts U lose when one of your deployables gets blown up..	
$TKExpPenalty		= 6;	// # of pts a player loses for Team Killing (Does not Include Death by Turret)
$TKObjPenalty		= 4;	// # of pts a player loses for blowing up his own stuff.

$TeamKillMax		= 3;	//	Number of Times you can kill one of your teammates in a mission before being kicked
$TKillObjMax		= 4;	//	Number of stations Etc you can kill before being kicked
$TeamKillMin		= 1;	//	Number of Team kills before you get warned
$TKillObjMin		= 2;	//	Number of Team Objects you can destory before Being warned
$TKRetries			= 2;	//	Number of times you can get kicked for team killing before you are banned

//***************************************
// Special Abilities
//***************************************
//	Speed & Flight & Stealth are Built into the Mod
//	Those Skills Must be changed inside the mod code..
//	Durabilty, Accuracy, Regeneration, Energy Recharge Can all 
//	be modified here

$MaxL[$Dur]=8;	
$MaxL[$Acc]=8;
$MaxL[$Rgn]=8;
$MaxL[$Rch]=5;

//***************************************
//	Level Values
//***************************************

$Durability[0]	= 1.0;
$Durability[1]	= 0.75;
$Durability[2]	= 0.65;
$Durability[3]	= 0.55;
$Durability[4]	= 0.45;
$Durability[5]	= 0.35;
$Durability[6]	= 0.25;
$Durability[7]	= 0.20;
$Durability[8]	= 0.15;

$Accuracy[0]	= 1.0;
$Accuracy[1]	= 1.25;
$Accuracy[2]	= 1.35;
$Accuracy[3]	= 1.50;
$Accuracy[4]	= 1.70;
$Accuracy[5]	= 2.0;
$Accuracy[6]	= 2.4;
$Accuracy[7]	= 2.75;
$Accuracy[8]	= 3.0;

$Regen[0]		= 0;
$Regen[1]		= 0.025;
$Regen[2]		= 0.035;
$Regen[3]		= 0.050;
$Regen[4]		= 0.070;
$Regen[5]		= 0.095;
$Regen[6]		= 0.125;
$Regen[7]		= 0.160;
$Regen[8]		= 0.2;

$Recharge[0]	= 8;
$Recharge[1]	= 8.5;
$Recharge[2]	= 9.25;
$Recharge[3]	= 10.25;
$Recharge[4]	= 11.5;
$Recharge[5]	= 13;
$Recharge[6]	= 14.75;
$Recharge[7]	= 16.75;
$Recharge[8]	= 19;
$Recharge[9]	= 21.5;
$Recharge[10]	= 24.25;
