_hvMechBot_Readme.txt

Ported WITH PERMISSION from House Vagaroth and the Spoonbot Dev team.


QUICK START INSTRUCTIONS:
==================

1)	*** READ "QUICK NOTES" BELOW ***
2)	Unzip the archive to your DYNAMIX\TRIBES folder WITH PATHNAMES.
3)	Go to DOS and the tribes directory and type

	hvMechBot
	-OR-
	hvMechLite
(depending on the power of your CPU - hvMechLite for less powerful CPU's...)

4)	Host a game.
5)	You will find new mission types.  They are optimized for use with bots!!!

- OR -

1)	*** READ "QUICK NOTES" BELOW ***
2)	Unzip the archive to your DYNAMIX\TRIBES folder WITH PATHNAMES.
3)	For a dedicated server go to DOS and the tribes directory and type

	hvMechBot_dedicated
	-OR-
	hvMechLite_dedicated
(depending on the power of your CPU - hvMechLite for less powerful CPU's...)

4)	Start tribes normally & join your server.
5)	You will find new mission types.  They are optimized for use with bots!!!

(Dedicated servers tend to run better.  Start the dedicated server, then fire tribes & connect to your own machine...)

QUICK NOTES:
=========

-There is a LOT of good stuff in this readme.  READ IT BEFORE you complain.
-This is still beta schtuff - some stuff won't work perfectly!
-10-20 seconds of LAG at EACH map start is NORMAL - this is the bots firing up.
-Run a dedicated server if you can - it performs better.
-The bots intelligence is set very high in Dynamix\Tribes\config\hvMechBot*.cs - if they are too 
	accurate for you, find the $Spoonbot::IQ line, and lower the number it is set to!
-CTF bots TRY to get the flag - they DO get stuck.  Play Raindance or Snowblind, & they might cap!!!
-You'll see new maps in your map menu - use them - theyre modified for MAXIMUM compatibility with bots...
-Do yourself a favor, & download the [CoD] maps:  http://hox.dhs.org/tribes/SpoonMaps.zip

Below you'll find lots of info, modified from the original Spoonbot & hvMechWarrior-V1 mod readme's, modified for 
hvMechBot.  Some of the text is pilfered/plagarized/stolen from the original mods, but I had permission & I hate 
writing readme's!!!
			-Mr. X


----------------------------------------------------------------
Name: hvMechBot Mod
Version: 0.096
Date: 23-April-2000
Author:Mr. X (Special thanks & most of the credit to hvPalantirion, hvHelplessTarget, [CoD]HoMiCiDe, and Josef Jahn!!!)
Email: mr.x@rcn.com
URL : Available at http://www.tribalwar.com/goat/
Purpose: hvMechWarrior using enhanced bot AI with "hunt and kill" capability and extended armor/weapon handling.
Requirements: TRIBES v1.7 or higher


Notes:   This Mod was ported with permission of the makers of BOTH hvMechWarrior and Spoonbot!
---------------------------------------------------------------


 Who writes hvMechBot?
----------------------

Hello, My name is Mr. X!  I did all of the integration between hvMechWarrior and Spoonbot.  My intentions were to
remain as true to the original hvMechWarrior Mod as possible, while making extensive changes (improvements?)
to the spoonbot code...

As for the original mods:

From the original Spoonbot:
-------------------------

Werewolf (werewolf@playspoon.com) is the one to blame for bugs and stuff. He, I mean, I created this bot.
Wicked69 (Wicked69@playspoon.com) wrote the whole tree code (that's the path navigation) thus he coded about 50% of the bot!!
Sam Wilson (Sam@screamingmouse.com) optimized the tree calculation routine so it takes minutes instead of hours!!! Thanks!!
EMO1313 (emo1313@dopplegangers.dynip.com) made the BotGear code, many bug reports, and the SHIFTER mod.
Savage (savage@technopop.com) shared the code of his bot, especially the mortar code. Thanks Savage!


Many thanks go to Weirdo, Nollykin, [CYA]WoLf, XXX_Quitch, Mr. X, Balkatori, Cyberdachshund, Storm, Kerusso, Stephen East and all the
countless people on the Spoonbot Development Board, who were loyal Spoonbot-testers and contributors for almost a year now.

Special Thanks to [CoD]h0micide (http://www.codx.com) for his CTF code improvements and his gorgeous spoonbot map pack!!!

From the original hvMechWarrior-V1:
----------------------------------

 hvPALANTIRION and hvHelplessTarget (authors)

With credits to:

- IX_Savage: Whose scripting brilliance allowed me to learn the OnFire 
function as well as the peculiarities of designing guided missiles. His 
code also helped me with the SpawnProjectile function.

- hvHelplessTarget: Whose efforts in co-designing this mod allowed me to 
learn time delay and loop structures in Tribes. You can see examples of 
these in the Auto Cannon and LRM weapons, among others. He is also 
responsible for a great deal of miscelaneous feedback that has 
dramatically increased the hvMechwarrior's playability.

- [hvC]NaTeDoGG: It was his Client::TakeControl function that has allowed 
the use of both Command Stations and the C3 Computer. He taught me the 
technique of weapon addition, that allowed me to add differentiating 
items to the Mechs. He is also solely responsible for the ArrowIV's 
"player-pilot" guidance, a truely ingenious piece of coding that everyone 
should take a look at in his HaVoC-v1.5 mod. Speaking of which, there are 
some other items in the HaVoC mod that are truely astounding, but you'll 
have to wait until it's release to see them :)  (Follow the link above to 
view his great site) He has also helped me with the upcoming multiple 
grenade and multiple mine selection functions.

- The makers of the original Battletech comic book and model series, who 
inspired this whole "mechanized warfare" genra.

- The makers of the Macross, the Movie and Robotech, the television show, 
who brought the concept of Japanese animation to America.

- FASA Corporation: Who developed the Battletech RPG, based on the 
forementioned comic book and TV series.

- Activision: Who managed to turn a great RPG into a great series of video 
games with Mechwarrior, Mechwarrior2, and Mechwarrior2, Mercenaries.

- MicroProse: Who is responsible for keeping the flame alive with 
Mechwarrior3.

- All those guys who helped me beta-test hvMechWarrior. Thanks a bunch :)


 Installing hvMechBot
---------------------

Client Install: None needed. 

Server Install: 
	Unzip the archive to your DYNAMIX\TRIBES folder with pathnames.


When installed The Files Should be here: 
 Tribes\_hvMechBot_Readme.txt				(This file!)
 Tribes\hvMechBot.bat					(For starting hvMechBot server, non-dedicated)
 Tribes\hvMechBot_dedicated.bat				(For starting hvMechBot server, dedicated)
 Tribes\hvMechLite.bat					(For starting hvMechLite server, non-dedicated)
 Tribes\hvMechLite_dedicated.bat				(For starting hvMechLite server, dedicated)
 Tribes\config\hvMechBot.cs					(For High-Powered CPU's)
 Tribes\config\hvMechBot_orig.cs				(For when you frig up the original)
 Tribes\config\hvMechLite.cs					(For Not-So-High-Powered CPU's)
 Tribes\config\hvMechLite_orig.cs				(For when you frig up the original)
 Tribes\config\BT_DangerousCrossing_bots.cs			(Treefile - See notes if interested)
 Tribes\config\BT_DoD_One_Inventory_bots.cs			(Treefile - See notes if interested)
 Tribes\config\BT_IceRidge_bots.cs				(Treefile - See notes if interested)
 Tribes\config\BT_Raindance_Bots.cs				(Treefile - See notes if interested)
 Tribes\config\BT_Rollercoaster_bots.cs				(Treefile - See notes if interested)
 Tribes\config\BT_SnowBlind_bots.cs				(Treefile - See notes if interested)
 Tribes\config\BT_Stonehenge_Bots.cs				(Treefile - See notes if interested)
 Tribes\hvMechBot\scripts.vol					(Main MOD Scripts)
 Tribes\hvMechBot\staticshape.cs				(Kept outside volume due to Tribes bug...)
 Tribes\Base\Missions\DangerousCrossing_Bots.dsc		(Map Description file)
 Tribes\Base\Missions\DangerousCrossing_Bots.mis		(Map Mission file)
 Tribes\Base\Missions\DoD_One_Inventory_bots.dsc		(Map Description file)
 Tribes\Base\Missions\DoD_One_Inventory_bots.mis		(Map Mission file)
 Tribes\Base\Missions\IceRidge_bots.dsc				(Map Description file)
 Tribes\Base\Missions\IceRidge_bots.mis			(Map Mission file)
 Tribes\Base\Missions\Raindance_Bots.dsc			(Map Description file)
 Tribes\Base\Missions\Raindance_Bots.mis			(Map Mission file)
 Tribes\Base\Missions\Rollercoaster_bots.dsc			(Map Description file)
 Tribes\Base\Missions\Rollercoaster_bots.mis			(Map Mission file)
 Tribes\Base\Missions\SnowBlind_bots.dsc			(Map Description file)
 Tribes\Base\Missions\SnowBlind_bots.mis			(Map Mission file)
 Tribes\Base\Missions\Stonehenge_Bots.dsc			(Map Description file)
 Tribes\Base\Missions\Stonehenge_Bots.mis			(Map Mission file)



To start the server with this mod go to DOS and the tribes directory and type

hvMechBot

-OR-

hvMechLite

depending on the power of your CPU.

if you wish to start the server yourself, type

 tribes -mod hvMechBot +exec hvMechBot.cs

-OR-

 tribes -mod hvMechBot +exec hvMechBot.cs

depending on the power of your CPU...

For a dedicated server type

hvMechBot_dedicated

-OR-

hvMechLite_dedicated

depending on the power of your CPU.

if you wish to start the server yourself, type

 tribes -mod hvMechBot +exec hvMechBot.cs -dedicated

-OR-

 tribes -mod hvMechBot +exec hvMechBot.cs -dedicated

depending on the power of your CPU...


NOTE:  Make sure you have the tribes 1.7 version installed first!
       Just download it at www.tribesplayers.com and get instructions there.


 Overview
----------

hvMechBot is a "bot" mod for the TRIBES hvMechWarrior-V1 mod. A bot is meant to be a replacement for human opponents.
So if you have a bad internet connection, you can spawn a few bots and play with/against them.


 hvMechBot Features
--------------------------------------

- Bots can be spawned into ALL MAPS! You no longer need to manually modify maps. Just play the standard maps with bots!

*** Note - I strongly suggest you download & use the [Cod} maps! - Available at:  http://hox.dhs.org/tribes/SpoonMaps.zip

********************************************************************************************
*** IN-GAME BOT-SPAWN MENU NOT FUNTIONAL IN THIS VERSION OF hvMechBot!!! ***
********************************************************************************************
To spawn a bot, press TAB and select "Spawn bot", then select a bot class, gender and if it should be roaming or a normal bot.
The first "Atlas" bot will be called "T0N1_Atlas", the second "T0N2_Atlas" etc... for the second team it would be "T1N1_Atlas" respectively.
You can have a maximum of 3 bots of the same team/gender/category. This means you can only have 3 Female Snipers in team 1, however 
you can have 3 more MALE snipers in the same team.
For 6 different bot classes and 2 genders this would mean 3x6x2 which equals to a maximum of 36 bots per team.
********************************************************************************************
*** IN-GAME BOT-SPAWN MENU NOT FUNTIONAL IN THIS VERSION OF hvMechBot!!! ***
********************************************************************************************

- Bots will choose the adequate weapons depending on range and player status.

- Sniper bots will hog a place and snipe enemies.

- Bots can now deploy Sensors and Stations.
To have a bot deploy something, first make sure he's at the point where you want the turret/etc. to deploy. Then go to the commander screen,
 select the Bot, select "Deploy" and the Item you want the bot to deploy. If you click somewhere in the map, the bot will first deploy the item, THEN
 go to the point you clicked.
Example: Bot is at location A. You want a Sensor at location B. Command the bot to "attack" location B. When he's there, order the bot to deploy 
a Sensor, and as target location select your homebase. The bot will set up the Sensor at location B, and then head home to your home base.
All clear?

- Different armor/weapon configuration for bots:
Multiple armor/weapon configurations are available. For example, if you want to test the heavy bot, have his name contain the word "Atlas"
A bot called "Atlas", "MyAtlas" or even "WhateverNameYouWant_Atlas" will automatically spawn as heavy equipped with ArrowIV, AC20, PPC, and LRM20.

- Bots play CAPTURE THE FLAG
Bots have (rather limited) ability to capture the enemy's flag and return it to your home base. 
If an enemy captures your flag, ALL your bots will go after him and attempt to kill him. 
If the enemy flagrunner gets killed and drops your flag, your bots will automatically try to return your flag.
In short: Virtually ALL aspects of CTF gameplay are implemented into the bot's AI.
The only drawback: My insufficient wayfinding code often prevents that a bot succesfully captures a flag.

- Some Bots retreat if severly damaged
Controllable via config file hvMechBot.cs (Or hvMechLite.cs), you can set a damage threshold for bots. 
If the preset damage level is exceeded, the bot tries to retreat to the safety of your home base. 
If you don't want bots to retreat, you can disable this feature.


 WHAT ABOUT VEHICLES?
------------------------------------------

When you get into a LPC or HPC vehicle as a pilot, nearby Roaming bots will come and hop on as passengers.They will hop off the moment YOU leave the 
vehicle.  Bots cannot pilot vehicles. I'm sorry, I'd love to code this, but there is simply no way.

Note - bots tend to shoot "through" your LPC/HPC - this can hurt...  :-)


 COMMANDABLE BOT
-----------------------------------

Someone requested to have commandable bots again, so I re-enabled them. They contain the word "CMD" in their name, and do NOT move on their own 
unless attacked.  To send them somewhere, just issue commands via the commander console (key "c") They can also deploy items via that method. Other 
than that, they do NOTHING.


 ROAMING ISSUES, or how to choose the right map
------------------------------------------------

The tree navigation code is still a bit unreliable, thus not every map is recommended for use with hvMechBot.

Bots fight best on open-spaced maps like Raindance, DangerousCrossings, Desert_Of_Death and so forth.
If you want to see them SUCK, try maps with big bases, like Tale_of_two_bases, Scarabrae.

hvMechBot uses a pre-stored set of paths. You have to download or create these Paths (called "Treefiles") if you want the bot to play inside Bases. 
For instructions on how to create treefiles, please check http://www.playspoon.com


 TREEFILES, an Introduction
----------------------------

"Treefiles" contain the path-navigation the bot needs to roam inside buildings.
Treefiles have to be created for every map, and are stored inside the config/ directory. "BT_Raindance.cs" would be the treefile for Raindance. 
To create a treefile, just set $Spoonbot::BotTree_Design = True and run SPOONBOT on the map you want to create the treefile for.

hvMechBot creates the Treepoints automatically. This means all you have to do is run around the map and visit all important places, for example 
Generators and Stations. Run around large buildings and jump on every tower to create the neccessary path information for the bot. Treepoints will 
be added automatically as you wander around the map. You have to produce as few treepoints as possible, while still visiting all important areas like 
Turrets, Generators, Stations, the Flag, and don't forget to place routes away from the spawn points (or else there will be stuck bots again!)

Don't forget to switch teams when you're halfway done, to map the other team's base.

When you're done, press TAB and select "2.CALCULATE TREE ROUTES" and get some coffee because this takes a few minutes
Don't worry, your computer doesn't hang. It just won't respond until completed.

The more Treepoints you have, the longer it takes. A usual map like Raindance shouldn't need more than 70 points, and calculation time is approx 40 
seconds on a 400MHz CPU.  Bigger files with 160 and more points can take up to 5 minutes. Of course, if your PC is slower, it will take longer.

Be patient. For comparison: In the original SpoonBot v0.5c a 160 points treefile took up to 6 hours!!


If you don't want to wait for the calculations to complete, you can press CTRL-ALT-DELETE anytime. All calculation progree will be lost, however the 
treepoint locations are saved and calculation may be done at a later time.


Don't forget to set $Spoonbot::BotTree_Design = False before playing the thing!
Large Treefiles (>1Meg) WILL CRASH TRIBES. You treefiles should NOT exceed 700kB.



********************************************************************************************
*** IN-GAME BOT-SPAWN MENU NOT FUNTIONAL IN THIS VERSION OF hvMechBot!!! ***
********************************************************************************************

 How do I spawn bots manually, or: The ingame BOT-SPAWN MENU 
-------------------------------------------------------------

You can spawn bots into the game and also remove bots from the game. This is done by pressing TAB, whereafter the game menu appears.
It should look like this:



***********************
Options:

1. Change Teams/Observe
2. Spoonbot controls
3. Kick
4. Ban
5. etc..
***********************



Now if you press [2], the following menu appears:



***********************
Select Bot action:

1. Spawn bot
2. Remove bot
***********************



If you press [2], a list of the bots currently in the game will be displayed. Just choose a bot to remove and press the appropriate number, and he'll be gone.

If you press [1], you can spawn a bot into the game:



***********************
Select bot type:

1. Atlas
2. BattleMaster
3. Archer
4. Sniper
5. Medic
6. Panther
7. Mortar
***********************



Select a bot class (see description later in this file) and you'll be directed to the last menu:



***********************
Bot gender and type:

1. Male Roaming
2. Female Roaming
3. Male CMD
4. Female CMD
3. Male CTF
4. Female CTF
3. Male Flag Guard
4. Female Flag Guard
***********************



Press [1] or [2] for a standard, self-conscious bot ;-) i.e. the bot will act autonomously, thus NOT responding to your commands, but running around like 
real human players.  Press [3] or [4] for a COMMANDABLE BOT, which will be solely dependend on commands YOU give him via the command console (key "c")


After you've made your way through these menus, your handcrafted bot will spawn and report for duty.

********************************************************************************************
*** IN-GAME BOT-SPAWN MENU NOT FUNTIONAL IN THIS VERSION OF hvMechBot!!! ***
********************************************************************************************


 Spawning bots automatically, or: The hvMechBot.cs (Or hvMechLite.cs) configuration file
---------------------------------------------------------------------

New to SPOONBOT is the possibility to pre-configure SPOONBOT for your server. You can pre-define bot teams, lock the bot-menu for your players and set 
the respawn delay. All this is done via the hvMechBot.cs (Or hvMechLite.cs) file which should reside in the Tribes\config folder.
This is especially cool for server operators, since now they can run a server which spawns their favourite setup of bots into every map the server runs.  
- No need to manually spawn bots anymore!

Here's an example hvMechBot.cs (Or hvMechLite.cs) file, just like the one included with the SPOONBOT distribution archive:


//********* CUT HERE **********

//********************************************************************************
//*******	hvMechBot  Config file:  Comments are INLINE - READ THEM!!!  ****
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
//======== *** NOTE *** The User Menu DOES NOT WORK in this version of hvMechBot!!! *** NOTE *** ======
//====================================================================
$Spoonbot::UserMenu = False;			//== Users may add/remove bots via menu When True.  When false, server uses presets only.
//====================================================================
//======== *** NOTE *** The User Menu DOES NOT WORK in this version of hvMechBot!!! *** NOTE *** ======
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

$Spoonbot::MovementInterval = 0.7;		//== *** NOTE *** This is NOT used in hvMechBot as of yet!!! *** NOTE ***
					//== Interval in sec between calls of the Movement code.
					//== This should be generally lower than ThinkingInterval
					//== NOTE: Again, the slower your CPU, the higher this should be.
					//== If you experience "lag", set these values even higher.
					//== *** NOTE *** This is NOT used in hvMechBot as of yet!!! *** NOTE ***

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
// bots in hvMechBot/Shifter/Spoon Bots work... Please make very sure of what you are doing before you alter any of these settings!!!
//==========================================================================================================================================


//================================= The following weapons are for what the bot will use when the enemy is...
//================================= The Pack is the pack that the bot will have mounted.
//================================= All items listed here **MUST** be listed in the particular bots inventory below...

//====================================================================
//======== *** NOTE *** The Mortar bot is DISABLED in this version of hvMechBot!!! *** NOTE *** =========
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
//======== *** NOTE *** The Mortar bot is DISABLED in this version of hvMechBot!!! *** NOTE *** =========
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

//********* CUT HERE **********


Quite easy, isn't it?
That way, you can make sure the game doesn't get dull and boring if there are only 1 or 2 human players!
And if players mess around with the bots and start to spawn huge armies, just set $Spoonbot::UserMenu = False and they cannot spawn or remove 
bots anymore.   I have to admit that the Bot Retreat code is quite useless in heavy battle, however it should save someone's butt from time to time.


 Other changes to hvMechWarrior:
------------------------------

All weapon, item and vehicle definitions were left untouched, which means you play standard hvMechWarrior unless you use a weapon mod togehter 
with hvMechBot.


 Changes since last release:
------------------------------

V.096:
------

-Work on Medic bot - Works great, but stops attacking after fixing something, until next spawn - I'm working on it...
-Better fix for Weapon Switch function.
-Changed $SpoonBot::BattleMasterObject and $SpoonBot::AtlasObject to $Spoonbot::DemoObject - now any bot can use the Demo weapon!...
-Changed Demo code, so that any bot can now be a demo bot! (with the exception of a medic)
-Much work on Demo code - Demo bots are lethal - they get LOS, and spank your stuff - theyre also commandable!
-MUCH Work on standard roaming code.
-Work on command code - All bots will accept attack/waypoint commands, unless they are currently destroying an installation.
	Use commands to tell your Demo bot to go to the top of a hill where he/she has LOS on its current target, etc...
-Added switches in hvMechBot*.cs to turn off Spoonbot Help requests, and Attack/Defend chat.
-Bots team chat now green, like it should be...  (That one alays bugged me :-))
-Functionalized BotThink code for better CPU usage.
-Optimized code, and detected/Removed several nasty loops.
-Worked on BotHUD - Not perfect yet, but better!!!
-Some minor work on CTF/FG code.
-Changed directive structures, updated BotThink, BotFuncs, and AI code.
-Added AI::JetToPos functio for both CTF and FG bots! - They'll jet to the flagstands now!!! - Yay!

V.095:
------

-Work on Medic bot.
-Fix some static shape strength problems.
-Fix Weapon Switch function.
-Added $SpoonBot::BattleMasterObject and $SpoonBot::AtlasObject - Weapons used to destroy objectives...
-Work on standard roaming code.
-Work on CMD code.
-New "Demo" code.

V.090:
------

-Alpha release;  Baseline.
-Added CTF, FG Bot types...


 Known Bugs
------------------------------

- CTF code works again. But that doesn't help much if the flag is inside the base.

- Big treefiles still hang hvMechBot.

- The bot's jumping often isn't precise enough to climb obstacles.

- Treecode still not fully operational -> they still get stuck inside buildings.

- There's no sensor/station deploy limit for bots. This can lead to serious slowdowns if mis-used.

- Medic stops attacking after fixing an object, untill he re-spawns.  Medic will however continue to fix more objects!



 ToDo:
------------------------------

DONE: Bots roaming, faking "human" players !! (we all want this!)
DONE: Use jumpjets for climbing towers, ski-jumping and evading
DONE: Avoid obstacles (Needs further work)
DONE: Evade enemy fire
DONE: Bots attacking enemy flagrunners as top-priority
DONE: Spawning bots in NON-AI maps!!!!!!
DONE: Bot armor/weapon configurations
DONE: Spawn bots as heavy/medium/light just by having its name contain some control word
DONE: Long-range mortaring of painted targets.
DONE: Bots riding vehicles.
DONE: Bots following the player, like some sort of strike team.
DONE: Bots deploying stations, sensors and turrets.
DONE: Bot mortaring needs improvement
DONE: Retreat if neccessary
DONE: Enlarging the Line-Of-Sight distance for Sniper-bots
DONE: Painter bot paints enemy turrets and stations
DONE: Bots should capture the flag
DONE: Bots should go after primary objectives like generators, the flag, etc.

PARTLY DONE: Bots should correctly navigate inside buildings (VERY difficult)

- Ger rid of bot "classes", and let bots choose their profession on their own
- Use ammos stations for outfitting bots
- Returning to a reload station after ammo is depleted
- Bots checking target locations to see if they can actually get there
- Bots should build defenses (Mines and Turrets) on their own
- Bots should work as a team (OH MY GOD!!)


 Bot Classes:
------------------------------

Bots are organized in classes. To have a bot spawn in "Medic" configuration, simply have his name contain the word "Medic". This applies to all classes, 
so a bot named "BillClinton_Demo" will spawn as Demolition-bot.


**************************************************
*** MORTAR BOT DISABLED IN THIS RELEASE ***
**************************************************

  Mortar
  ------------
Armor: Heavy
Weapons: Mortar, Disc Launcher, Plasma Gun
Backpacks: Ammo Pack

This is a heavy bot, designed to take out turrets and other installations from long-distance. Just "paint" a target with the targeting laser and he'll mortar away 
at it!! That way, you can have bots destroy turrets etc. from safe distance. He also works together with a painter bot. However, if several painter laser are being 
fired, he'll mortar at the FIRST.

**************************************************
*** MORTAR BOT DISABLED IN THIS RELEASE ***
**************************************************


  Atlas
  ------------
Armor: Atlas
Weapons: ArrowIV, PPC, AC20m LRM20
Backpacks: Fire-Control Computer (NEEDED FOR ARROWIV!!!)

Big 'ol nasty Atlas - Takes a lickin' & keeps on Kickin'.



  BattleMaster
  ------------
Armor: BattleMaster
Weapons: GaussRifle, Ultra20, LRM10, PPC
Backpacks: Double Heat Sink

Great candidate for a Demo bot - Takes a beating like an atlas, but is quicker...



  Archer
  ------------
Armor: Archer
Weapons: STR6, LRM10, LRM20
Backpacks: Ferro-Fibrious Armor

Basic Archer...  Nasty at range...




  Panther
  ------------
Armor: Panther
Weapons: PPC, LRM5, Ultra5
Backpacks: Ferro-Fibrious Armor

Basic Panther - Great CTF bot...



  Sniper
  ------------
Armor: Commando
Weapons: Sniper Rifle, AC5
Backpacks: Ferro-Fibrious Armor

Set up this one at a nice spot and he'll make toast of your enemies. However, close combat is NOT one of his strenghts.



  Medic
  ------------
Armor: HellBringer
Weapons: Flamer, GaussRifle, Ultra10
Backpacks: Repair Pack

The Medic automatically repairs destroyed structures like Turrets and Stations. If needed, he rushes to the front line to heal comrades,  and Gauss the enemy.





ALL BOTS CONTAINED IN A MAP WHICH DO NOT CONTAIN ANY OF THESE WORDS WILL SPAWN AS STANDARD BOT.
The AI changes like chasing enemies will still be in effect, however the standard weapon/armor configuration is used.

--------------------------------------------------------------------------------



 I NEED YOUR HELP!!
--------------------


If you're interested in helping with hvMechBot OR SPOONBOT development, I'm willing to share my knowledge.
Go to http://www.playspoon.com/spoonbot_development.shtml for the latest news about SPOONBOT's development, or check out the
SPOONBOT DEVELOPMENT FORUM at http://www.playspoon.com/forums/SpoonbotDevelopment

-Or send me a mail at mr.x@rcn.com...



 Want SPOONBOT for your mod?
----------------------------

Josef Jahn, maker of the original SPOONBOT mod says:

I invite all MOD-makers to incorporate SPOONBOT into their mod. However, please tell me first, and insert some credits into your readme.

Josefs address:

Please send any questions or comments or ideas to me at werewolf@playspoon.com

Also, if you would have a server and would like to host this mod, feel free! Just please let me know where your server is at so I can come play sometime! 



----------------------------------------------------------------
Disclaimer: I am not responsible for any damage this game modification may cause you or anything having to do 
	    with you. I also am not responsible for any hardware failures or software problems that may arise
	    in TRIBES, your computer, or life in general.
	    If your computer dies, it's not my fault.
	    If your dog dies, it's not my fault.

	    If you would like to host this mod.. feel free.
	    if you like, or hate this mod, or have any ideas, please drop me a line.

	    Thank you!
----------------------------------------------------------------
