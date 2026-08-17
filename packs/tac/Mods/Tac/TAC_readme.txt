----------------------------------------------------------------
Name: Team Aerial Combat (TAC)
Version: 1.41
Date: 4-2-2001

URL: http://www.tribes-universe.com/tac/

Purpose: To create a mod in which teamwork is REQUIRED to be successful.


TAC 1.4 Development Team:

	Original Concept 
	  [TPG]SaNTa[DTM]

	Mod Code
	  Lead Code - Wizard_TPG
	  Code - Mental Trousers

	Mapping
	  Lead Mapper - [TPG]SaNTa[DTM]
	  Additional Maps - [EL]Orange[TPG] & [DH]RogueQD[TPG] & Potato

	Skins
	  [TPG]SMedly[DTM]

	Sounds
	  [TPG]SaNTa[DTM]
	  
	Propaganda
	  Iron Chef Frappe


Contact:  tac@tribes-universe.com


Thanks: The development team would like to thank Poker for the use 
	of bwadmin as our admin base.  
	
	Also many thanks to all the people who helped beta
	test this mod and found all the little bugs that we missed. 
	This new version has been a LONG time in coming but we 
	think you will all be very happy with the results



What has changed in version 1.41?
	- Just one thing.  Bug fix for shield pack ground walkers.

What has changed in version 1.4?
	- Major Bug in Ground Kill Code Fixed (CPU Hog Bug)
	- Menu bug where non admins had menu score and time options
	- Menu Gag operation for admins
	- Bwadmin client support v 5 added to support ObserverHUD
	- Admin Team Hurt Info Display
	- Anti-Voice Pack Spam Code Added
	- Code that scores kills (and TK's) for knocking players onto ground
	- tacbot.cs added to test server cpu usage
	- 3 points added for a flag carrier's apc pilot on cap
	- 1 point added for apc kills scored by gunners from apc given to pilot
	- apc energy decreased - easier to elf disable.
	- shield pack will shield from ground for a short period
	- BUG - could observe other players whilst using pilot views - fixed
	- Added menu options to remove vote abilities.
	- Added 4 new maps by [TPG]SaNTa[DTM]
	- Changed spawn weapon to blaster to prevent accidental respawn discing


What has changed in version 1.31?
	- Only one thing.  Elf ground kill bug fixed.


What has changed in version 1.30?
	- BWadmin v 4.4 admin code including observer views. (Thanks Poker)
	- Revised Ground Kill Code - MUCH less cpu usage and more accurate
	- Add explosion when player dies from Ground Kill
	- Map Rotation Code (Thanks MT)
	- Smurf Hunter - alias recognition code
	- Reduced range of Gren Launcher to 1.5 seconds
	- APC only chat menu support
	- APC Passenger Display and Damage Indicator HUD Support
	- Pilot rear and side views
	- Smoke Trail for FLPC
	- Auto waypoint pilots when flag carrier enters apc
	- Apc may now be disabled by sapping its energy with an elf
	- Players now spawn with repair pack
	- Fixed multiple scoring and message bugs
	- Fixed crazy looking animations upon player collision
	- New Scoring System for F&R Maps
	- 5 New Maps (24 maps in total)


---------------------------------------------------------------
------------  INSTALLING & UNINSTALLING TAC -------------------
---------------------------------------------------------------
Client Install: NONE. 


Upgrade Server Install:
	1. Rename Tribes\config\TACUserList.cs to Tribes\config\TACUserList2.cs 
	   so you do not lose your old TAC userlist.
	
	2. Delete the entire Tribes\TAC directory

	3. Make a new Tribes\TAC directory and move TACUserlist2.cs from tribes/config into it 
	
	4. Delete Tribes\config\TAC.cs

	5. Follow the steps for a new server install listed below.
	
	6. Add your old users from TACUserlist2.cs into TACUserlist.cs and then delete TACUserlist2.cs


New Server Install: 
	1. Unzip into default Tribes Dir.
	   (where tribes.exe resides - UNZIP WITH PATH INFORMATION)
	This means:

	When installed The Files Should be here: 
		Tribes\TAC\scripts.vol
		Tribes\TAC\TACManual.zip
		Tribes\TAC\TAC_Readme.txt
		Tribes\TAC\TACUserlist.cs
		Tribes\TAC\TAC_MapRatings.cs
		Tribes\TAC\TAC_Settings.cs
		Tribes\TAC\missions\*.dsc
		Tribes\TAC\missions\*.mis

	NOTE: If these files are not in these folders...put them there.

	      
	
	2. Command line to run the mod.
	   (A command line is what you use to start the game.
	    for windows its called a shortcut. It's what you 
	    double click on to run the game.)

	   Just add "-mod TAC" to your current Server Command Line.
	   For Example:
		Running Normally. 
			tribes.exe
		Running this Mod.
			tribes.exe -mod TAC

	   If you have a custom Server Config then add the +exec Parameter
	   BEFORE The -mod parameter. 	
	   For Example:
		Running Normally. 
			tribes.exe +exec MyConfig.cs
		Running this Mod.
			tribes.exe +exec MyConfig.cs -mod TAC

	   If your runing dedicated and have a special server config. 
	   I suggest you use infinitespawn. (get it at tribesplayers.com)
	   For Example:
		Running Normally. 
			infinitespawn *tribes +exec MyConfig -dedicated
		Running this Mod.
			infinitespawn *tribes +exec MyConfig -mod TAC -dedicated


Uninstalling:

	Delete the Tribes\TAC Directory and everything in it. 
	Delete SmurfLog28001.cs from your config directory if you have 
	been using Smurf Hunter. All files are listed above. 
	THIS MOD DOES NOT CHANGE ANYTHING IN TRIBES\BASE.


----------------------------------------------------------------
-----------------------  DISCLAIMER  ---------------------------
----------------------------------------------------------------
    We are not responsible for any damage this game 
    modification may cause you or anything having to do 
    with you. If you lose your job because you play this
    game nite and day, it is purely your responsibility.
    I also am not responsible for any hardware failures 
    or software problems that may arise in TRIBES. For 
    problems of that nature contact the game manufacturer.
    If you believe this modification has problems please 
    report them to me so that I may look into it. 
    I am not responsible for any bugs or problems caused
    from copying this code into another mod. I do not claim
    to support any other mod using my code. If they have
    problems, bother them, not me. 
		- TAC Development Team
----------------------------------------------------------------