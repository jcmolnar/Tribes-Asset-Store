############################################################################################################################
# M-D TotalWar 2001 build 122
# Built' by Defender
# Useing code in meltdown created by INH*DynaBlade                                                                             #
#                                                                                                                          #
# Original Base Programming by INH*DynaBlade                                                                                        #
# This version' by Defender                                                                                                 #
# Additional programming by: Z_Dog and Valya[AAOD]                                                                         #
# Other people who contributed: Chivalry DEV team (proud member), Shayne Hyde, Emo1313, [HvC]NateDoGG, and <SSA> 		   #
# Email: res07c9h@gte,net                                                                                        #
############################################################################################################################

######################################
# Server startup variables           #
# Color Tags:                        #
# White Text = <f2>                  #
# Light Text = <f1>                  #
# Normal Text = <f0>                 # 
# \n = New Line                      #
# Leaving the messages without color #
# tags will result in the usage of   #
# the last used color                #
# In this case, White.               #
# You can also use these commands    #
# for setting up your server         #
# information (serverprefs.cs)       #
######################################

$Meltdown::JoinMOTD = "<f1>W E L C O M E\n<f0>Server running Meltdown Total War + Spoonbot 1.1\nGo ahead and play! It's fun!";

#############################################
# Server Switches (set to false to disable) #
#############################################

$Meltdown::PublicAdminVote =  False; //False; // Can vote to admin
$Meltdown::ChangeMissionVote = True; 		// Can vote to change missions
$Meltdown::ChangeTeams = True; 			// Must be true for Fair teams to work
$Meltdown::KickVote = True; 				// Can vote to Kick
$Meltdown::TeamDamageSwitch = True; 		// Can vote to Enable/disable team damage
$Meltdown::FlagReturnTime = 30; 			// Time in seconds before flag will return to it's flagstand
$Meltdown::StationTime = False; 				// Cannot be less than 10 or higher than 60 or else it will use default. Set to false to disable
$Meltdown::VoteIncTime = 15; 				// # of mins to vote to increase time
$Meltdown::KickMessage = "Go away you idiot!";  // The message that displays when you kick/ban someone  
$Meltdown::RespawnEffectTime = 15;			// How long the cool respawn effect lasts (seconds)
$mallcomment = "Try not to get killed!";	      // What displays in the bottom mission window when they respawn
$Meltdown::TeleCountdownTime = 300;			// Time in seconds it takes the teleporter to blow up if not deployed
$trace = false;						// Extra in-game messages exported to console
$Xi::LeechFieldSize = 45; 				// How big the Leech field is for each player.

###########################
# Server Anti-TK settings #
###########################

$TeamKillMin = 2;             			// Before he can qualify for being kicked for TKs
$Meltdown::TKLimit = 3; 				// How many TKs before he is kicked 

##########################
# Default game variables #
# for more advanced      #
# servers ONLY!          #
# -INH*DynaBlade         #
##########################

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. Only for F&R Missions
//---------------------------------------------------------------------------------
$flagToStandTime = 180;

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;


//---------------------------------------------------------------------------------
// SpoonBot settings
//---------------------------------------------------------------------------------



// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.

$Spoonbot::DebugMode = False;
$BotTree::DebugMode = False;

$Spoonbot::AutoSpawn = False;			//== Automatic bot-spawning on
$Spoonbot::BotTree_Design = False;		//== Enables Bot tree design mode
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.

$BotTree::AutoTree=True;			//== Change this to False for totally manual treepoint placement
						//== WARNING: Can lead to broken routes if you don't place enough treepoints!!

$Spoonbot::UserMenu = True;			//== Users may add/remove bots via menu
$Spoonbot::BotChat = True;			//== If the bot's chat messages annoy you, you can turn them off here.



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




$Spoonbot::Bot1Name = "Uhura_Sniper_Roam_Female";
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Chapel_Medic_Roam_Female";
$Spoonbot::Bot2Team = 0;

$Spoonbot::Bot3Name = "Spock_Demo_Roam_Male";
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "Checkov_Guard_Roam_Male";
$Spoonbot::Bot4Team = 0;

$Spoonbot::Bot5Name = "Sulu_Miner_Roam_Male";
$Spoonbot::Bot5Team = 0;



$Spoonbot::Bot6Name = "Colleen_Sniper_Roam_Female";
$Spoonbot::Bot6Team = 1;

$Spoonbot::Bot7Name = "Exile_Medic_Roam_Male";
$Spoonbot::Bot7Team = 1;

$Spoonbot::Bot8Name = "Hunter_Demo_Roam_Male";
$Spoonbot::Bot8Team = 1;

$Spoonbot::Bot9Name = "Balto_Guard_Roam_Male";
$Spoonbot::Bot9Team = 1;

$Spoonbot::Bot10Name = "Jenna_Miner_Roam_Female";
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
$Spoonbot::MortarGear[0] = "mortar";		$Spoonbot::MortarAmmo[0] = "1";
$Spoonbot::MortarGear[1] = "mortarammo";		$Spoonbot::MortarAmmo[1] = "500";
$Spoonbot::MortarGear[2] = "chaingun";		$Spoonbot::MortarAmmo[2] = "1";
$Spoonbot::MortarGear[3] = "bulletammo";		$Spoonbot::MortarAmmo[3] = "50000";
$SpoonBot::MortarGear[4] = "PlasmaGun";		$Spoonbot::MortarAmmo[4] = "1";
$SpoonBot::MortarGear[5] = "plasmaammo";		$Spoonbot::MortarAmmo[5] = "500";
$Spoonbot::MortarGear[6] = "energypack";		$Spoonbot::MortarAmmo[6] = "1";
$Spoonbot::MortarGear[7] = "repairkit";		$Spoonbot::MortarAmmo[7] = "1";
$Spoonbot::MortarGear[8] = "";

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
$Spoonbot::GuardGear[8] = "repairkit";		$Spoonbot::GuardAmmo[7] = "1";
$Spoonbot::GuardGear[8] = "";

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
$SpoonBot::DemoGear[6] = "repairkit";		$Spoonbot::DemoAmmo[6] = "1";
$SpoonBot::DemoGear[7] = "";

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
$SpoonBot::SniperGear[4] = "repairkit";		$Spoonbot::SniperAmmo[4] = "1";
$SpoonBot::SniperGear[5] = "";

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
$SpoonBot::PainterGear[5] = "repairkit";	$Spoonbot::PainterAmmo[5] = "1";
$SpoonBot::PainterGear[6] = "";

$Spoonbot::PainterClose = "PlasmaGun";
$Spoonbot::PainterLong  = "TargetingLaser";
$SpoonBot::PainterJet   = "DiscLauncher";
$Spoonbot::PainterPack  = "";

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
$SpoonBot::StandardGear[7] = "repairkit";		$Spoonbot::StandardAmmo[7] = "1";
$SpoonBot::StandardGear[8] = "";

$Spoonbot::StandardClose = "PlasmaGun";
$Spoonbot::StandardLong  = "disclauncher";
$SpoonBot::StandardJet   = "chaingun";
$Spoonbot::StandardPack  = "energypack";

















