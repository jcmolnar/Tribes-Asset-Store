_____________________________________________________________________________
TRIBES ARENA VERSION 3.0               									2002-06-15
Versions 2.4 and above by Lizard (belgarion@tribes2universe.com)
Original version by Rasia (up to version 2.3)
_____________________________________________________________________________

________________
ARCHIVE CONTENTS
================

This release of arena should come in a zip file which contains the following
files. It is important, and required, to respect the directory structure below:

	Arena_Versions.txt					Arena Version history
	Arena_Readme.txt						Arena Read me
	lizStats.txt							lizStats Read me
	base\arena.cs							Arena Game Type
	base\arenaAdmin.cs         		Updated admin.cs 
	base\arenaComchat.cs					Updated arenaComchat.cs
	base\arenaGui.cs					   Updated arenaGui.cs
	base\arenafatality.wav				Arena sound (clients must install this to hear sounds)
	base\arenafinishhim.wav				Arena sound (clients must install this to hear sounds)
	base\arenaflawless.wav				Arena sound (clients must install this to hear sounds)
	base\arenaoutstanding.wav			Arena sound (clients must install this to hear sounds)
	config\autoexec-example.cs			Example of the server's autoexec file
	config\ServerConfig-example.cs	Example of the server's configuration
	config\lizStats.cs					LizStatistics


_____________
UPGRADE NOTES
=============

IMPORTANT! Read this if you have already installed a previous version of arena (version 2.4
through 2.9 inclusively).
Some files have new names, and you will be required to properly do the following steps BEFORE
installing Tribes Arena v3.0+
   1. Close your server
   2. Go to the Tribes/Base directory
   3. Delete "Admin.cs" file
   4. Delete "Comchat.cs" file
   5. Delete "GUI.cs" file
   6. Replaced Arena's custom Scripts.Vol file (about 1000 KB) by Tribes' ORIGINAL Scripts.Vol
      file (943kB for Tribes v1.11). You can find this file on your Tribes CD.
   7. Proceed with Tribes Arena installation (see "Installing Tribes Arena" below)
These steps are crucial. If you do not follow them, you WILL end up with problems, especially
on gametypes other than Arena. Thanks to Sparky for notifying me of the problem.


_______________________
INSTALLING TRIBES ARENA
=======================

If you unzip the entire archive directly into your Tribes directory using paths,
and this should put all the right files in the correct folders. If you wish to 
extract manually, please refer to the previous "Archive Contents" section to see
which files goes in which directory.

Tribes Arena now fixes a couple issues in Dynamix's original script files, including
a few bugs and exploit (see Arena_Versions.txt for complete description of changes
and additions).  For this reason, several original tribes scripts must be updated,
namely admin.cs, comchat.cs, and gui.cs.  These files are originally packaged in the
scripts.vol tribes archive.  Because in some cases the updated files will not load
(probably due to modified timestamps), I've also re-packaged these files into the
updated scripts.vol file.  You are at liberty to install the updated scripts.vol file
or not, but should be aware of this issue.  

If you wish to check your installation, start your server and in the server console,
enter the following command "Arena::DisplayVersion();" followed by the <Enter> key.
This should display a similar output:
   Tribes Arena v3.0 
   File arena.cs version $Revision: 50 $ on $Date: 7/02/02 6:41p $
   File arenaAdmin.cs version $Revision: 1 $ on $Date: 7/12/02 2:56p $
   File arenaComchat.cs version $Revision: 1 $ on $Date: 7/12/02 2:56p $
   File arenagui.cs version $Revision: 1 $ on $Date: 7/12/02 2:56p $
   File lizstats.cs version $Revision: 47 $ on $Date: 7/11/02 6:36p $
The Versions, Revisions and Dates may change according to the actualy Arena release.
If nothing is displayed, or some files are displayed as ".. is not the updated file"
or ".. not loaded", then something went wrong with the installation and you should
re-read this section and make sure everything was done correctly.


_____________________
INSTALLING ARENA MAPS
=====================

You should also download all the Arena maps you wish your server to have.
I have compiled a few Tribes Arena maps at:
	http://www.tribes2universe.com/
Other maps may be available at other places.
All maps (files ending in .DSC and .MIS) should be placed in your tribes\base\missions
directory.  You then have to add these maps to your server's map rotation list using,
for example, the ServerConfig.cs file (see Configuration section).


_____________
CONFIGURATION
=============

Tribes Arena now has many options. For a feature list, please refer to the 
Arena_Versions.txt files.
Almost all options can be configured through the use of a ServerConfig.cs file (that is
executed from the Autoexec.cs file) located in your <Tribes>\Config folder.
You should read that file entirely and set all preferences according to the setup you wish
to run.
The <Tribes>\base\arena.cs file also contains a few options some server owners may want to
modify, specifically the maximum settable winning score limit. Arena supports winning score
of 2 through 10. Look for the line (in the first 10 lines of arena.cs) that reads:
	$Arena::ScorelimitMax = 10;										
This setting represents the maximum number for the winning score that can be set by an admin.
Due to the increasing number of abusive admins who set the winning score to 10 because they
personally like a specific map without caring about what the connected players think, it may
be a good idea to limit the maximum possible winning score limit to 5 or 6. Players can 
easily be turned away from Arena if they keep playing the same map over and over all the time.
The following table gives a rough estimate of minimum and maximum number of games played per
match, versus the set winning score. Each match is won when one of the teams reaches the
winning score, and there are 3 matches per map. Each game can last as long as 4 minutes. The
owner should pay attention to the "Maximum number of games played per match/map column" when
choosing the maximum settable winning score limit. Please note the winning score for official
matches is 5, and therefore the maximum winning score can not be set below that value.

                   | Minimum number     | Maximum number
         Winning   | of games played    | of games played
         Score     | per match/map      | per match/map
        -----------+--------------------+------------------
          2        | 2 games/match      | 3 games/match
                   | 6 games/map        | 9 games/map
                   |                    | 36 minutes/map
        -----------+--------------------+------------------
          3        | 3 games/match      | 5 games/match
                   | 9 games/map        | 15 games/map
                   |                    | 60 minutes/map
        -----------+--------------------+------------------
          4        | 4 games/match      | 7 games/match
                   | 12 games/map       | 21 games/map
                   |                    | 84 minutes/map
        -----------+--------------------+------------------
          5        | 5 games/match      | 9 games/match
                   | 15 games/map       | 27 games/map
                   |                    | 108 minutes/map
        -----------+--------------------+------------------
          6        | 6 games/match      | 11 games/match
                   | 18 games/map       | 33 games/map
                   |                    | 132 minutes/map
        -----------+--------------------+------------------
          7        | 7 games/match      | 13 games/match
                   | 21 games/map       | 39 games/map
                   |                    | 156 minutes/map
        -----------+--------------------+------------------
          8        | 8 games/match      | 15 games/match
                   | 24 games/map       | 45 games/map
                   |                    | 180 minutes/map
        -----------+--------------------+------------------
          9        | 9 games/match      | 16 games/match
                   | 27 games/map       | 48 games/map
                   |                    | 192 minutes/map
        -----------+--------------------+------------------
          10       | 10 games/match     | 17 games/match
                   | 30 games/map       | 51 games/map
                   |                    | 204 minutes/map
        -----------+--------------------+------------------

It is important to note that the winning score is now fixed and constant to arena.
I have personnally used a default setting of 4 games per map in Pub Mode (it is still
at 5 in Match Mode). You can change these by modifying the Arena.cs file (look for 
$Arena::Scorelimit and $Arena::ScorelimitPubMode and set these to what you like - but
do NOT touch the $Arena::ScorelimitMatchMode as it is a standard ladder number and
people would not be able to play official matches on your server).

An example of the autoexec.cs and ServerConfig.cs files are provided with Arena,
and you can find these files in your <Tribes>\config\ folder as "Autoexec-example.cs"
and "ServerConfig-example.cs" files. If your starting a new server, you can rename
these files to "Autoexec.cs" and "ServerConfig.cs" automatically. Otherwise, you can
modify your existing ServerConfig using the example given out.

   
__________________________
GETTING THE LATEST VERSION
==========================

You can find the updated Tribes Arena v2.5 and later as they become available at:
	http://www.tribes2universe.com/

You can find the original Tribes Arena v2.3, by Rasia, at:
	http://www.planetstarsiege.com/TheDen


________________________
SUGGESTIONS AND COMMENTS
========================

Send all your suggestions and comments to Lizard, by email at belgarion@tribes2universe.com
or on irc.dynamix.com on #lizrena.


_________________________
ORIGINAL READ ME BY RASIA
=========================

Hi, and thanks for taking a look at this.  It is a work in progress, but I 
think its suitable for the public now.

I got the idea from Clan Arena from Q1, and that a bunch of my tribe-mates 
were doing something similar to this in a normal CTF game one time.  I decided 
that I should just spend to the time and do it up right.

TERMS:
Game:        When the countdown is done, a game starts.  When one team no 
             longer has living members, the game is over.
ScoreLimit:  How many games you must win to win the match.
Match:       One set of games.  When one team has hit the scorelimit, the 
             match is over.

THE GAME:
You choose which team you want to join for the match, and when all the 
spawned players are ready, the countdown begins.  You grab EQ, and frag the 
hell out of your enemies!  When one team no longer has any players living (you 
don't respawn when you die), the winning team gets a point, and the teams go 
out at again.  When one team has the amount of points dictated by the server 
to win a match (default is 3), then they win, and the match resets itself.

NOTE:
Turrets and Mines are NOT in the game. Team Damage is hard coded on. The * 
beside peoples name means they are alive

Bugs, Suggestions, Flames, etc all sent to Rasia@planetstarsiege.com

NOTE: 
If you want to run this on a pub server, PLEASE do so.  I would love to know 
where it is also.

Thanks

Check out our website planetstarsiege.com/TheDen for client-side stuff (some 
custom sounds, some artwork, maps, etc.)

Rasia
TheGriffin
ThePanther
Ninja
Gon
Nobula

