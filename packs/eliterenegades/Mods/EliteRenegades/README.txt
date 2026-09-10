			****** Elite Renegades ******
			        version 1.1b

		     Developed by FTA (Fire Team Alpha)
		     The original creators of Renegades
		  http://www.planetstarsiege.com/renegades

		  brought to you by the Temples of Syrinx
		    http://www.tribes-universe.com/tos


Note: If you have any other mods installed on your server it is strongly suggested that
you remove them before installing this one.  The reason for this is that there may be
some incompatability issues between the mods if some of the files are the same. Also, if
you choose to enable $RandomMissions in the Renegades.cs file, please remove all training
maps from the server, as they will be considered by the mod as valid and it will load them.
These missions are easy to locate, they all begin with "#_" there are 8 of them total.
Another way around this is to download MissionLists.zip from http://www.tribes-universe.com/tos 
and install it according to your preferences.

*** 1.1b ADDITIONS:

 1. Fixed the admin through console exploit.


*** INSTALLATION:

 1. Double click the the Eliterenegades EXE file, make sure the path it will extract to is your Tribes folder.
 2. Edit the files named "Renegades.cs" and "AdminUserList.cs" to suit your needs.
 3. Create a shortcut on your desktop to InfiniteSpawn.exe
 4. Right click the shortcut and choose "Properties" from the menu:

Where it says "Target:"
Type in the box "C:\Dynamix\Tribes\InfiniteSpawn.exe *Tribes -mod EliteRenegades +exec serverConfig -dedicated" without quotes.

Where its says "Start in:" Type the path to your Tribes folder, i.e. "C:\Dynamix\Tribes" and click on the "apply" button.

Now click on the "OK" button. Double click the shortcut to start your server.

NOTE: If your Tribes is not installed in the default location on your hard drive you must adjust accordingly all paths.
Included is a batch file you could should to your desktop that will do exactly what the shortcut does.
It is setup for the default Tribes installation. If you do not wish to use it, please delete it, do not 
leave it in your config folder!


*** RUNNING THE MOD ON YOUR SERVER:

 1. Use the following command to start the server in dedicated mode:

 InfiniteSpawn *tribes -mod EliteRenegades +exec serverConfig -dedicated

 2. Use the following command to start the server in non dedicated mode:

 Tribes.exe -mod EliteRenegades +exec serverConfig


*** CREDITS:

Dynamix a Sierra company
URL: http://www.dynamix.com

Fire Team Alpha
Members: Snypress, EzTarget, Mephisto, Dweller, Sgt.WQlf and Quetzalcoatl
URL: http://www.planetstarsiege.com/renegades

Kevin Savage *IX*Savage1
URL: http://www.insomniax.net/mods

LabRat
URL: http://labrat1.simplenet.com/sstribes

Alazane & Mjolnir
URL: http://alazane.surf-va.com/tribes/alliance.html

Albedo Zero , Ðoug, POWER, Shayne Hyde and Team Fortress
Visit http://www.planetstarsiege.com/renegades for more detail on their envolvment.

sal9000
URL: http://thespaceodyssey.tripod.com
Scripter who coded the item limit option, merged BWAdmin code into Elite Renegades
and helped trouble shoot code errors.

Poker & Wizard[TPG]
http://www.barrysworld.com/
Makers of the BWadmin server MOD of which some observer code was used.

[HvC] NateDogg
URL: http://www.planetstarsiege.com/havoc
From the HaVoC MOD which code was taken to increase
the amount of mission types available in the tab menu.

The Renegades community
Without whom Renegades wouldn't be as popular as it is today.
Thank you for your comments and suggestions.

If you feel you were left off this list, please contact ZOD and
he will add you to it assuming you deserve it :)
Just drop an E-Mail: zodder@hotmail.com

*** ABOUT BWADMIN ADDITIONS:

*NOTE*	this is NOT a full BWadmin port. this is merly an observer-suport addition to Elite Renegades.
	for purposes mainly dealing with match 'shout-casting' and observation.
	as many of the bwadmin functions would in fact conflict with many renegades code lines.

Files added:
	bwadmin.cs (the core BWadmin file minus the uneeded functions)
	           (by uneeded i mean the funtions which arnt supported)
	           (cant be 'registered' by the client any more)

Files modified are:
	observer.cs (additional observer mode/controls)
	objective.cs (hooks on all dealings with flag update locations)
	game.cs (additional observer mode)
	server.cs (ping calculator jump start)

No code has actualy been modified, as there was no need to. it has simply been inserted in to the Elite Renegades mod
in the correct places, for it to function properly.
-sal
icq:12347353


*** DISCLAIMER:

Anything releated to Starsiege Tribes is property of and copyrighted Sierra Inc. 
http://www.sierra.com

We are not responcible for damages to your computer hardware as a result
of installing this server modification. Use at your own risk!
If your computer explodes because you  use this modification, it is
purely your responsibility.

We are also not responsable for any software problems 
that may arise in TRIBES, your computer, or life in general.  
If you would like to host this mod.. feel free.
