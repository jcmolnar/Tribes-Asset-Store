**********************************************************************				
						AAOD MOD Server Pack
					**** The AAOD Mod Stuff ****
**********************************************************************
----------------------------------------------------------------------
this pack contains all the Files required to run and use the 
AAOD Mod to its full portential. 
As a Dedicated SERVER or as a Tribes Host.
----------------------------------------------------------------------
A List of Files Included 
(Check the End of this README for more details)
----------------------------------------------------------------------
AAODPlayers.CS 		- A Sample Players File
AAOD_CFG.CS			- An External AAOD Mod Configuration File	
AAODC.CS			- The AAOD Client side Script
AAODVerify.CS		- The AAOD Remote Password Submission Script
AAODConfig.CS		- A Sample Configuration file 
Scripts.vol			- The AAOD Mod
AAOD_Changes.txt	- The Current List of Patches & Changes etc.
						(Read This before Submitting Bug Reports)
-----------------------------------------------------------------------
		**************************************************
		For Bug Reports Send email to darkserpent@home.com
		**************************************************
-----------------------------------------------------------------------
				**** To Install the AAOD Mod ****
_______________________________________________________________________
***																	***
*** Note: The Mod is COnstantly Changing and Fairly quickly.		***
***			To Keep up to date Read the Changes.txt File &			***
***			Check the Website: www.bdtech.net/aaod frequently.		***
***																	***
#######################################################################
						The SIMPLE INSTALL
								for 
					 Either Dedicated or Host
#######################################################################
1>	Create a Subdirectory called AAOD in your Tribes Directory
2>	Place the Scripts.vol in the AAOD Sub Directory
3>	Right click on your tribes shortcut.
	select Properties.
	Change the target line to read
	tribes.exe -mod AAOD
*** Done !!! ***
4>	To Setup your system so it can run as a Dedicated server via a different shortcut
	Right click your tribes shortcut.
	select COPY.
	Right Click on your desktop
	select PASTE
	Right click your New tribes shortcut.
	select Rename & Change its name to something like AAOD Dedicated
	Right click on your AAOD Dedicated shortcut.
	select Properties.
	Change the target line to read
	tribes.exe -mod AAOD -Dedicated
***	Done!! *** 
	You can now host an AAOD Game or Run a Dedicated Server using the AAOD MOD for Tribes.
	This will allow you to host an AAOD game using your computer. This MOD has some extensive changes to the the BASE
	tribes and does require a bit more horsepower to handle some of the specifics. The extra load should not 
	be signifigant to your system but it will increase with every additional player.

***** Notes !!!! *****
	The above setup will run your server using the AAOD Defaults.
	This means that Experience is NOT Stored
	Every time people join your server they will start at level 0. (It's better this way.)
	(See ADVANCED AAOD Installation for more on some of the other features)

_______________________________________________________________________
#######################################################################
						Using & Maintaining
					ADVANCED FEATURES FOR AAOD
								for 
					 Either Dedicated or Host
#######################################################################

**************************
Using the AAOD_CFG.CS File
**************************

	The AAOD_CFG.CS is an external configuration file for the AAOD Mod.
	If you open it in notepad or any other word processor you will see that
	it is fairly self explanatory. I would strongly suggest that you leave most
	of the EXP stuff alone as it can severely UNBALANCE Gameplay if modified 
	incorrectly. Changes & suggestions will be posted on the AAOD Website 
	to apprise Admins of some problems and potential solutions. To Install the 
	external configuration file simply place it in your \CONFIG Subdirectory. The mod 
	automatically will detect it there and uses its configuration instead of the default.


** If you want to track Exp On your Server ! **
-----------------------------------------------
	Ensure the File AAOD_CFG.CS is in your tribes\config directory
	Open it in notepad or any other text editor and examine the
	$TrackExp variable. 

****> To Track experience of certain players only set the $TrackExp to 1
	this will load the AAODPlayers.cs file when the game starts. Any Player
	in the AAODPlayers File will have his Exp tracked by the server.
	(*** See The AAODPlayers Section later in this file for more info ***)

****> To Track experience of any player joining set the $TrackExp to 2
	this will load the AAODPlayers.cs file when the game starts. It will
	also add to the AAODPLayers.CS file any 'NEW' players and begin tracking exp
	for them. If Using this Option Set the $TrackMaxUsers to allow for you and 
	your friends It will Stop Tracking any Players that join after the MAX Number 
	has been reached.
	(*** Note: When refering to Tacking of EXP we are talking about the server 'storing'
		Experience and Kills Etc for players between sessions. Not the Exp that they gain 
		after they have connected to the server but Between the times they connect.)

(** Extra NOTE: We dont know what Kind of a drain tracking EXP this will add to the server,
	from what we have seen our dedicated PIII-450 does not seem to notice when saving the
	playerlist to the file. Our Player-Count has reached 200 without noticable LAG during
	the saves & Player connects.)


***************************
* The AAODPlayers.CS File *
***************************
	There is a sample AAODPlayers.CS file in this Pack.
	You have 2 Options...If You are using Option 1 in your $TrackExp variable you need to either create 
	your AAODPlayers file Manually or Set your config to use option 2 and let the Server create one for 
	you then just edit it.

	An Explanation of the AAODPlayers File
	--------------------------------------
	The Players File Format is Very Simple.
	The first Line is the Total Number of Players Contained in the File.
	This is followed by a List of PlayerNames, which is followed by a List of PlayerStats.
	The Stats are in the following Format:

	Admin SuperAdmin Password HelpOn TrackExp ExpGained ExpLost #ofKills #ofDeaths #ofVisits #ofFlagCaps

	- Admin			default = false.	Set to true to grant AUTO Admin Rights.	(** See Password)
	- SuperAdmin	default = false.	Set to true to grant AUTO SuperAdmin.	(** See Password)
	- Password		default = none.		Set to UserPassword.						(** See AAODVerify.CS)
	- HelpOn		default = true.		This simply stores the player preference for Help Notes.
	- TrackExp		default = true.		When Set to false the server "knows" the player but will Not Track EXP for that player.
	- ExpGained		Shows the total Number of Exp Points the player has earned.
	- ExpLost		Shows the total Number of Exp Lost by the Player.
	- #ofKills		The Total # of kills attaind by the player.
	- #ofDeaths		The Number of times a Player has Died.
	- #ofVisits		The number of Times a Player has Visited the Server.
	- #ofFlagCaps	The number of times the Player Has captured the Flag.
		 
***************************
* The AAODC Client Script *
***************************
	(** BIG NOTE: The AAODC Script is under Development and will be changing substaincially
		Keep checking the website for updates!! Also it has Numerous Bugs Etc which Hopefully 
		will be addressed over a short period of Time. 
		Email Bugs Concerns or desires to darkserpent@home.com)

	The file AAODC.CS Contains the AAOD Client Side script. This Script contains a number of useful things which will be added
	to as we get further along with our plans for global domination. (Ooops! didn't mean to let THAT slip.)
	- First and foremost it allows you to access the AAOD Voice packs. These pack contain a variety of sounds
	that we found either amusing or suited the game. The sound packs are VERY easy to install and allows you to hear what 
	we are really thinking. (Goto website www.bdtech.net/aaod for SoundPacks)
	* Note: While some of the Sound effects packs etc have universal sounds (Sounds useable by both sexs) a lot of the 
	sound packs have a male & female content. Depending on what sex you are you will get different menus.
	- This pack also Adds to the generic commands to include many of the AAOD deployables so you can tell a 
	teammate to deploy a mort turret at waypoint...!! (Not that anyone EVER Listens!)

	*** To Install the AAODC ***
	Put the AAODC.CS file in your tribes\config directory.
	Load tribes. UNder your player setup down at the bottom on the left there is a line that says
	custom scripts. Simply type AAODC there and you are done!.

	*** Any AAOD-ADDONx.cs Script ***
	In future we will be releasing ADD-On scripts with things like EXP huds Team Energy Huds Etc.
	These will be in an AAOD-ADDONx.cs file. To install any of these simply place in your tribes\config
	directory they will be detected by you AAODC script and loaded.

**************************
* The AAODVerify.CS File *
**************************
	
	> If you want to AUTO ADMIN you will need the AAODVerify Script loaded on the client side.
	
	*** To Install the AAODVerify ***
	> Installing the AAODVerify Client Side script can be done 2 ways.
	#1> If you are using the AAODC client script simply put the AAODVerify.cs in your config directory
		the AAODC script will detect it and load it automatically.
	#2	If you are not using the AAODC client script.
		Put the AAODVerify.CS file in your tribes\config directory.
		Load tribes. under your player setup down at the bottom on the left there is a line that says
		custom scripts. Simply type AAODVerify there and you are done!.

	- If you have been assigned a Password from the Admin of your AAOD Server you need to edit the
		AAODVerify.cs with a text editor and change the %Pwd="MyPassword"; line so that it contains your
		password. Thats is all you need to do. Next time you connect to the server you will be granted admin
		rights. If it does not recognize your password you may get kicked for being an imposter.

**************************
* The AAODConfig.CS File *
**************************
	
	- Just in case you dont have a configuration file for your server I have included a sample configuration file
	Place this file in your config subdirectory. Open it with a text editor of any kind and make changes where they seem appropriate.
	To ensure this file is loaded you need to modify your tribes shortcut.
	1> Right Click on the shortcut you wish to modify. 
	2> select Properties.
	3> Change the target line to read either:
		tribes.exe -mod AAOD +exec AAODConfig.cs
		or
		tribes.exe -mod AAOD +exec AAODConfig.cs -dedicated




Good Luck & Good Gaming!!!

Valya[AAOD]

	
	
		
		



