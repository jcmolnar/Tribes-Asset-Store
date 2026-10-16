// HvMechBot V.096 by Mr. X (2000-04): hvMechWarrior by hvPalantirion and hvHelplessTarget
// (House Vagoroth) with Spoonbot 0.96 bots by Werewolf, Wicked69 and the Spoonbot team.
// Modern Tribes (1.50) entry script AND the mod's settings file.
//
// Original launch (the four .bat files):
//     Tribes.exe -mod hvMechBot +exec hvMechBot.cs  [-dedicated]     hvMechBot, 14 bots
//     Tribes.exe -mod hvMechBot +exec hvMechLite.cs [-dedicated]     hvMechLite, 8 bots
// with hvMechBot.cs, hvMechLite.cs and seven BT_<map>.cs tree files installed into Tribes\config\.
//
// Here: launch with  -mod HvMechBot  (add -dedicated for a server). The client execs
// <mod word>.cs from the mod folder by itself, so this file loads without +exec. Everything
// below the dashed line is the original config\hvMechBot.cs, byte for byte.
//
// hvMechLite is the SAME mod with the other settings file (8 bots instead of 14, slower
// thinking, lower IQ, for a slower machine). It is in this folder as hvMechLite.cs and is
// picked the original way:
//     -mod HvMechBot +exec hvMechLite.cs
// or, on a listen host, by typing  exec("hvMechLite.cs");  in the console before hosting.
// It runs after this file and sets all twenty bot slots back to "0" first, so its roster
// replaces this one.
//
// Nothing is installed into config\ any more. The tree files sit in this folder and
// scripts\BotTree.cs finds them on the search path. config\ is still searched first, so a
// settings file or a tree file of the same name that the host puts there wins. The tree
// design mode still saves to config\BT_<map>.cs.
//
// Built-in (1.50) bots: off under this mod, see botbrain.cfg. The mod's own Spoonbot bots
// spawn by themselves at the start of every match from the roster below.
//
// Server-side mod: players join without installing anything.
echo(">> HvMechBot V.096 (hvMechWarrior + Spoonbot)");
// ---------------------------------------------------------------------------------------
//********************************************************************************
//*******	HvMechBot  Config file:  Comments are INLINE - READ THEM!!!  ****
//********************************************************************************

//-------------------------------------------------------------------
$Spoonbot::SPOONBOTCSLOADED = True;  // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot1Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot2Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot3Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot4Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot5Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot6Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot7Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot8Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot9Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot10Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot11Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot12Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot13Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot14Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot15Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot16Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot17Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot18Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot19Name = "0";		   // DO NOT CHANGE THESE LINES!!!
$Spoonbot::Bot20Name = "0";		   // DO NOT CHANGE THESE LINES!!!
//-------------------------------------------------------------------

// This file will set up a fixed set of bots which are spawned automatically
// so you can have a dedicated server running without users having to spawn bots.

$Spoonbot::DebugMode = False;		//== Leave False unless u like lots of console messages :-)
$Spoonbot::AutoSpawn = True;		//== Automatic bot-spawning on when true - if false, Bots will not re-spawn.
$Spoonbot::BotTree_Design = False;		//== Enables Bot tree design mode when true.  False is for normal gaming.
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.  For use with above when true.
//====================================================================
//======== *** NOTE *** The User Menu DOES NOT WORK in this version of HvMechBot!!! *** NOTE *** ======
//====================================================================
$Spoonbot::UserMenu = False;			//== Users may add/remove bots via menu When True.  When false, server uses presets only.
//====================================================================
//======== *** NOTE *** The User Menu DOES NOT WORK in this version of HvMechBot!!! *** NOTE *** ======
//====================================================================
$Spoonbot::BotChat = False;			//== If the bot's chat messages annoy you, you can turn them off here - False=off (Funny for a while when true...)
$Spoonbot::HelpBotChat = False;		//== If the bot's "Need Help" & "Coming" chat messages annoy you, you can turn them off here - False=off (Funny for a while when true...)
$Spoonbot::AnnounceBotChat = True;		//== If the bot's Objective ("Attacking enemy foo", etc.) chat messages annoy you, you can turn them off here - False=off (Funny for a while when true...)
$BotTree::DebugMode = False;			//== Enable Debug mode - for development only.
$Spoonbot::RespawnDelay = 10;		//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 100;			//== The IQ controls the bot's overall skill, like targeting precision, speed, etc. 1=Dumb/Slow, 100="Smart", Fast

$Spoonbot::ThinkingInterval = 1;		//== Interval in sec between which bots will "reconsider" their situation
					//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
					//== ANOTHER NOTE: The slower your CPU, the higher this should be.

$Spoonbot::MovementInterval = 0.7;		//== *** NOTE *** This is NOT used in HvMechBot as of yet!!! *** NOTE ***
					//== Interval in sec between calls of the Movement code.
					//== This should be generally lower than ThinkingInterval
					//== NOTE: Again, the slower your CPU, the higher this should be.
					//== If you experience "lag", set these values even higher.
					//== *** NOTE *** This is NOT used in HvMechBot as of yet!!! *** NOTE ***

$Spoonbot::RetreatDamageLevel = 1.0;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.
					//== To disable retreating, set to 1.0.  To have bots retreat when they are 75% dead, set to 0.25

$BotHUD::ToggleKey = "b";			//== CTRL + this key will open the BotHUD.
					//== The BotHUD displays what your bots are doing at the moment.
					//== Note - BotHUD does NOT work in dedicated mode!

$Spoonbot::DefaultTeamEnergy = Infinite;	//== The default energy each team starts with. Set to "Infinite" for standard TRIBES rules,
					//== or set to 1000 or similar for having to worry about cash ;-)



					//== Now, the auto-spawned bots are being set up
					//== NOTE: $Spoonbot::AutoSpawn (Above!) must be "True" for this to work!!

					//== *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE ***
					//== *** Second, Third, and Fourth parts of name MEAN something!!!
					//== *** For Instance:  Boa_Medic_Roam_Male means:
					//== *** 		Bots name is Boa
					//== *** 		Bot is a Medic type Bot (armor)
					//== *** 		Bot is a Roaming Type Bot (role)
					//== *** 		Bot is Female (skin)
					//== *** ALL OF THESE EXCEPT NAME ARE KEYWORDS!!!
					//== *** 
					//== *** Keyword summary:
					//== *** 
					//== *** Bot ArmorTypes:
					//== *** 		Sniper (Commando)
					//== *** 		Panther
					//== *** 		Medic (Hellbringer that repairs stuff!!!)
					//== *** 		Archer
					//== *** 		BattleMaster
					//== *** 		Atlas
					//== *** 
					//== *** Bot Role Types:
					//== *** 		Roam (They determine their own objectives as follows:)
					//== *** 			Sniper attacks/defends & snipes
					//== *** 			Panther attacks/defends
					//== *** 			Medic Repairs or attacks/defends
					//== *** 			Archer attacks/defends
					//== *** 			BattleMaster attacks specific objectives - Turrets, sensors, gens, etc.
					//== *** 			Atlas attacks specific objectives - Turrets, sensors, gens, etc.
					//== *** 		
					//== *** 		CMD (They do nothing but defend themselves until you assign them waypoints to ATTACK)
					//== *** 		
					//== *** 		CTF (They go straight for enemy flag - not smartly, but guaranteed to see action!)
					//== *** 		
					//== *** 		FG (Flag Guard - They will defend flag, & chase flag carriers.)
					//== *** 
					//== *** Bot skin types:
					//== *** 		Male
					//== *** 		Female
					//== *** 
					//== *** So, for instance, Rattler_BattleMaster_Roam_Male will attack specific objectives,
					//== *** While SideWinder_Sniper_FG_Female will defend flag, & chase flag carriers,
					//== *** And Cobra_Atlas_CMD_Male will stand around like an idiot waiting for orders...
					//== *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE *** NOTE ***

$Spoonbot::Bot1Name = "Boa_Medic_Roam_Male";			//== Team 0 Medic, Roaming type (Roams & fixes stuff)
$Spoonbot::Bot1Team = 0;

$Spoonbot::Bot2Name = "Cuda_Medic_Roam_Male";			//== Team 1 Medic, Roaming type (Roams & fixes stuff)
$Spoonbot::Bot2Team = 1;

$Spoonbot::Bot3Name = "Anaconda_Atlas_Demo_Female";		//== Team 0 Atlas, Demo type (Attacks Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot3Team = 0;

$Spoonbot::Bot4Name = "FireBird_Atlas_Demo_Female";		//== Team 1 Atlas, Demo type (Attacks Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot4Team = 1;

$Spoonbot::Bot5Name = "SideWinder_Sniper_FG_Female";		//== Team 0 Sniper, FG type (Good Flag guard!)
$Spoonbot::Bot5Team = 0;

$Spoonbot::Bot6Name = "RoadRunner_Sniper_FG_Female";		//== Team 1 Sniper, FG type (Good Flag guard!)
$Spoonbot::Bot6Team = 1;

$Spoonbot::Bot7Name = "Rattler_BattleMaster_Demo_Male";		//== Team 0 Battlemaster, Demo type (Attacks Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot7Team = 0;

$Spoonbot::Bot8Name = "Charger_BattleMaster_Demo_Male";		//== Team 1 Battlemaster, Demo type (Attacks Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot8Team = 1;

$Spoonbot::Bot9Name = "DiamondBack_Archer_Roam_Male";		//== Team 0 Archer, Roam type (Pesky LRM spammer!)
$Spoonbot::Bot9Team = 0;

$Spoonbot::Bot10Name = "Challenger_Archer_Roam_Male";		//== Team 1 Archer, Roam type (Pesky LRM spammer!)
$Spoonbot::Bot10Team = 1;

$Spoonbot::Bot11Name = "CopperHead_Panther_CTF_Female";	//== Team 0 Panther, CTF type (Occasionaly ACTUALLY gets flag!)
$Spoonbot::Bot11Team = 0;

$Spoonbot::Bot12Name = "Mustang_Panther_CTF_Female";		//== Team 1 Panther, CTF type (Occasionaly ACTUALLY gets flag!)
$Spoonbot::Bot12Team = 1;

$Spoonbot::Bot13Name = "Cobra_BattleMaster_Roam_Male";		//== Team 0 BattleMaster, Roam type (Attacks & Defends Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot13Team = 0;

$Spoonbot::Bot14Name = "GTX_BattleMaster_Roam_Male";		//== Team 1 BattleMaster, Roam type (Attacks & Defends Objectives - Turrets, Sensors, etc.)
$Spoonbot::Bot14Team = 1;


//==========================================================================================================================================
// The following bot configurations should be used ONLY by admins who know what they are doing... This can seriously mess up the way the
// bots in HvMechBot/Shifter/Spoon Bots work... Please make very sure of what you are doing before you alter any of these settings!!!
//==========================================================================================================================================


//================================= The following weapons are for what the bot will use when the enemy is...
//================================= The Pack is the pack that the bot will have mounted.
//================================= All items listed here **MUST** be listed in the particular bots inventory below...

//====================================================================
//======== *** NOTE *** The Mortar bot is DISABLED in this version of HvMechBot!!! *** NOTE *** =========
//====================================================================

//=========================== Mortar Gear
$Spoonbot::MortarMArmor  = "harmor";
$Spoonbot::MortarFArmor  = "harmor";
$Spoonbot::MortarGear[0] = "GaussRifle";			$Spoonbot::MortarAmmo[0] = "1";
$Spoonbot::MortarGear[1] = "GaussGunAmmo";		$Spoonbot::MortarAmmo[1] = "500";
$Spoonbot::MortarGear[2] = "Ultra20";			$Spoonbot::MortarAmmo[2] = "1";
$Spoonbot::MortarGear[3] = "Ultra20ammo";		$Spoonbot::MortarAmmo[3] = "50000";
$SpoonBot::MortarGear[4] = "LRM20";			$Spoonbot::MortarAmmo[4] = "1";
$SpoonBot::MortarGear[5] = "LRMammo";			$Spoonbot::MortarAmmo[5] = "5000";
$Spoonbot::MortarGear[6] = "PPC";			$Spoonbot::MortarAmmo[6] = "1";
$Spoonbot::MortarGear[7] = "FerroFibrousArmor";		$Spoonbot::MortarAmmo[7] = "1";
$Spoonbot::MortarGear[8] = "";

$Spoonbot::MortarClose = "Ultra20"; 
$Spoonbot::MortarLong  = "GaussRifle";
$SpoonBot::MortarJet   = "LRM20";
$SpoonBot::MortarObject   = "PPC";
$Spoonbot::MortarPack  = "FerroFibrousArmor";

//====================================================================
//======== *** NOTE *** The Mortar bot is DISABLED in this version of HvMechBot!!! *** NOTE *** =========
//====================================================================

//=========================== Atlas Gear
$Spoonbot::AtlasMArmor  = "harmor";
$Spoonbot::AtlasFArmor  = "harmor";
$Spoonbot::AtlasGear[0] = "LRM20";			$Spoonbot::AtlasAmmo[0] = "1";
$Spoonbot::AtlasGear[1] = "LRMammo";			$Spoonbot::AtlasAmmo[1] = "50000";
$SpoonBot::AtlasGear[2] = "AC20";			$Spoonbot::AtlasAmmo[2] = "1";
$SpoonBot::AtlasGear[3] = "AC20Ammo";		$Spoonbot::AtlasAmmo[3] = "50000";
$Spoonbot::AtlasGear[4] = "FCCPod";			$Spoonbot::AtlasAmmo[4] = "1";
$SpoonBot::AtlasGear[5] = "ArrowIV";			$Spoonbot::AtlasAmmo[5] = "1";
$SpoonBot::AtlasGear[6] = "ArrowIVAmmo";		$Spoonbot::AtlasAmmo[6] = "500";
$SpoonBot::AtlasGear[7] = "PPC";			$Spoonbot::AtlasAmmo[7] = "1";
$SpoonBot::AtlasGear[8] = "";

$Spoonbot::AtlasClose = "AC20"; 
$Spoonbot::AtlasLong  = "ArrowIV";
$SpoonBot::AtlasJet   = "LRM20";
$SpoonBot::AtlasObject   = "PPC";			//	$SpoonBot::AtlasObject is the weapon used to destroy objectives.
$Spoonbot::AtlasPack  = "FCCPod";

//=========================== BattleMaster Gear
$SpoonBot::BattleMasterMArmor  = "barmor";
$SpoonBot::BattleMasterFArmor  = "barmor";
$SpoonBot::BattleMasterGear[0] = "Ultra20";		$Spoonbot::BattleMasterAmmo[0] = "1";
$SpoonBot::BattleMasterGear[1] = "Ultra20ammo";		$Spoonbot::BattleMasterAmmo[1] = "50000";
$SpoonBot::BattleMasterGear[2] = "PPC";			$Spoonbot::BattleMasterAmmo[2] = "1";
$SpoonBot::BattleMasterGear[3] = "DoubleHeatSink";		$Spoonbot::BattleMasterAmmo[3] = "1";
$SpoonBot::BattleMasterGear[4] = "LRM10";		$Spoonbot::BattleMasterAmmo[4] = "1";
$SpoonBot::BattleMasterGear[5] = "LRMammo";		$Spoonbot::BattleMasterAmmo[5] = "50000";
$SpoonBot::BattleMasterGear[6] = "RepairKit";		$Spoonbot::BattleMasterAmmo[6] = "1";
$SpoonBot::BattleMasterGear[7] = "GaussRifle";		$Spoonbot::BattleMasterAmmo[7] = "1";
$SpoonBot::BattleMasterGear[8] = "GaussGunAmmo";	$Spoonbot::BattleMasterAmmo[8] = "5000";
$SpoonBot::BattleMasterGear[9] = "";

$Spoonbot::BattleMasterClose = "Ultra20";
$Spoonbot::BattleMasterLong  = "GaussRifle";
$SpoonBot::BattleMasterJet   = "LRM10";
$SpoonBot::BattleMasterObject   = "PPC";			//	$SpoonBot::BattleMasterObject is the weapon used to destroy objectives.
$Spoonbot::BattleMasterPack  = "DoubleHeatSink";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "hbarmor";
$SpoonBot::MedicFArmor  = "hbarmor";
$SpoonBot::MedicGear[0] = "Flamer";			$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "Ultra10";			$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "Ultra10ammo";		$Spoonbot::MedicAmmo[2] = "50000";
$SpoonBot::MedicGear[3] = "GaussRifle";			$Spoonbot::MedicAmmo[3] = "1";
$SpoonBot::MedicGear[4] = "GaussGunammo";		$Spoonbot::MedicAmmo[4] = "5000";
$SpoonBot::MedicGear[5] = "RepairPack";			$Spoonbot::MedicAmmo[5] = "1";
$SpoonBot::MedicGear[6] = "RepairKit";			$Spoonbot::MedicAmmo[6] = "1";
$SpoonBot::MedicGear[7] = "PPC";			$Spoonbot::MedicAmmo[7] = "1";
$SpoonBot::MedicGear[8] = "";

$Spoonbot::MedicClose = "Flamer";
$Spoonbot::MedicLong  = "GaussRifle";
$SpoonBot::MedicJet   = "Ultra10";
$SpoonBot::MedicObject   = "PPC";
$Spoonbot::MedicPack  = "RepairPack";

//=========================== Archer Gear
$SpoonBot::ArcherMArmor  = "aarmor";
$SpoonBot::ArcherFArmor  = "aarmor";
$SpoonBot::ArcherGear[0] = "LRM10";			$Spoonbot::ArcherAmmo[0] = "1";
$SpoonBot::ArcherGear[1] = "LRM20";			$Spoonbot::ArcherAmmo[1] = "1";
$SpoonBot::ArcherGear[2] = "LRMammo";		$Spoonbot::ArcherAmmo[2] = "5000";
$SpoonBot::ArcherGear[3] = "FerroFibrousArmor";		$Spoonbot::ArcherAmmo[3] = "1";
$SpoonBot::ArcherGear[4] = "repairkit";			$Spoonbot::ArcherAmmo[4] = "1";
$SpoonBot::ArcherGear[5] = "STRammo";			$Spoonbot::ArcherAmmo[5] = "5000";
$SpoonBot::ArcherGear[6] = "STR6";			$Spoonbot::ArcherAmmo[6] = "1";
$SpoonBot::ArcherGear[7] = "";

$Spoonbot::ArcherClose = "STR6";
$Spoonbot::ArcherLong  = "LRM20";
$SpoonBot::ArcherJet   = "LRM10";
$SpoonBot::ArcherObject   = "LRM10";
$Spoonbot::ArcherPack  = "FerroFibrousArmor";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "larmor";
$SpoonBot::SniperFArmor  = "larmor";
$SpoonBot::SniperGear[0] = "AC5";			$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "AC5ammo";			$Spoonbot::SniperAmmo[1] = "50000";
$SpoonBot::SniperGear[2] = "SniperCannon";		$Spoonbot::SniperAmmo[2] = "1";
$SpoonBot::SniperGear[3] = "SniperGunAmmo";		$Spoonbot::SniperAmmo[3] = "5000";
$SpoonBot::SniperGear[4] = "FerroFibrousArmor";		$Spoonbot::SniperAmmo[4] = "1";
$SpoonBot::SniperGear[5] = "";

$Spoonbot::SniperClose = "AC5";
$Spoonbot::SniperLong  = "SniperCannon";
$SpoonBot::SniperJet   = "AC5";
$Spoonbot::SniperObject  = "SniperCannon";
$Spoonbot::SniperPack  = "FerroFibrousArmor";

//=========================== Panther Gear
$SpoonBot::PantherMArmor  = "parmor";
$SpoonBot::PantherFArmor  = "parmor";
$SpoonBot::PantherGear[0] = "LRM5";			$Spoonbot::PantherAmmo[0] = "1";
$SpoonBot::PantherGear[1] = "LRMammo";		$Spoonbot::PantherAmmo[1] = "5000";
$SpoonBot::PantherGear[2] = "Ultra5";			$Spoonbot::PantherAmmo[2] = "1";
$SpoonBot::PantherGear[3] = "AC5"; 			$Spoonbot::PantherAmmo[3] = "1";
$SpoonBot::PantherGear[4] = "Ultra5Ammo";		$Spoonbot::PantherAmmo[4] = "50000";
$SpoonBot::PantherGear[5] = "FerroFibrousArmor";		$Spoonbot::PantherAmmo[5] = "1";
$SpoonBot::PantherGear[6] = "AC5ammo";		$Spoonbot::PantherAmmo[6] = "50000";
$SpoonBot::PantherGear[7] = "PPC";			$Spoonbot::PantherAmmo[7] = "1";
$SpoonBot::PantherGear[8] = "";

$Spoonbot::PantherClose = "AC5";
$Spoonbot::PantherLong  = "LRM5";
$SpoonBot::PantherJet   = "Ultra5";
$SpoonBot::PantherObject   = "PPC";
$Spoonbot::PantherPack  = "FerroFibrousArmor";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "parmor";
$SpoonBot::StandardFArmor  = "parmor";
$SpoonBot::StandardGear[0] = "DoubleHeatSink";		$Spoonbot::StandardAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "LRM5";			$Spoonbot::StandardAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "LRMammo";		$Spoonbot::StandardAmmo[2] = "50000";
$SpoonBot::StandardGear[3] = "PPC";			$Spoonbot::StandardAmmo[3] = "1";
$SpoonBot::StandardGear[4] = "STR6";			$Spoonbot::StandardAmmo[4] = "1";
$SpoonBot::StandardGear[5] = "STRammo";		$Spoonbot::StandardAmmo[5] = "50000";
$SpoonBot::StandardGear[6] = "";

$Spoonbot::StandardClose = "PPC";
$Spoonbot::StandardLong  = "LRM5";
$SpoonBot::StandardJet   = "STR6";
$SpoonBot::StandardObject   = "PPC";
$Spoonbot::StandardPack  = "DoubleHeatSink";
//--------------------------------------------------------------------------------------------
