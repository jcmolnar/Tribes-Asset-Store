http://www.primenet.com/~desrtfox
desrtfox@primenet.com

Credits
-------

Special thanks to the creators of the Minimod and the Orion Mod.  The Professional
Mod is based on the Orion Mod, and Minimod allowed me to start playing around with
the script files without messing with the entire .vol file.  I highly suggest
downloading the Minimod for those interested in creating their own mods.

Code for professional contains parts and Minimod plugins from many other mods, including:

HaVoC
Renegades
Ultra Renegades
Z-Tek
hvTactical
Ideal
Redneck Slag Pack
Bitchin

If any Mod developer feels that code from their mod has been used in Tribes Professional, and that
they haven't been properly credited, please contact Desrtfox@primenet.com immediately.


Installation
------------

Please extract the archive into your Tribes directory, usually:

C:\Dynamix\Tribes\

A new folder called Professional will be created there.  To run Tribes using the mod,
create a shortcut to Tribes and add to the Target textbox:

-mod Professional

Your Target should look something like this:

C:\Dynamix\Tribes\Tribes.exe -mod Professional

To run the server in dedicated mode, simply make a shortcut to InfiniteSpawn
and add the following to the Target textbox:

-mod Professional

Your target should look something like this:

c:\Dynamix\Tribes\InfiniteSpawn -mod Professional

Please send any bug reports or exploits as well as suggestions to desrtfox@primenet.com.





Usage
-----

Please visit http://www.primenet.com/~desrtfox for detailed descriptions of all the equipment
available in Tribes Professional.

To use the Teleport Pack, a waypoint must first be set.  To do this, go to the command screen and select
your name in the list.  Then, select either attack or defend from the command menu and click a point
on the map.  Once your waypoint is set, simply activate the pack to teleport.  More than one armor
can be teleported at a time, but the danger of failure increases with the total mass tranported.
The Heavy armor and the Engineer armor may not be teleported.  


Match Rules
-----------

The Match Rules are a set of optional rules designed to give Tribes Professional a feel that is similar
to a sporting event like we see broadcast on national television.  Individual Skins are not allowed,
instead, each team has a base skin that is applied to all players of that team.  Team points are added
not only for flag captures and switch captures, but also for player kills.  This livens up the team 
scoring and makes for closer games.  In addition, tha game is usually set to a specific time limit, 
rather than a score limit.  New ways to score (the Prevention) have been added, and penalties for certain 
behaviors (Suicide) have been added.  The $lockedServer setting has been added to allow for certain 
planned events to be held at Dfox's Server. This variable has not been fully implemented, and should not
be used yet.  Watch for more on this later.


External Files
--------------

There is one external script files which can be modified by the operator of the server.  
It is professional.cs.  What follows is a description of how to use all the switches in
the file.  Please note, all the Team Kill scripting and variables are originally from ModMgmt.  They
Have simply been integrated into the mod to improve flexibility and to reduce the number of files.

$motd - Simply change the message to whatever short message of the day that you
	would like to have displayed to every client that connects to your server.  Please,
	only change the actual message, altering the other syntax could cause problems with your 
	server.

$SHAntiTeamKillWarnKills - This is the number of Team Kills before a player is warned not to teamkill.

$SHAntiTeamKillBanTime - This is the duration of banning after the $SHAntiTeamKills is reached.

$SHAntiTeamKillMaxKills - This is the number of Team Kills before banning.

$SHAntiTeamKillProximity - This is the maximum distance that a Team Kill is registered (to avoid
	banning for accidental team kills).

$TurretScore - Set this to "True" if you wish Turret kills to count as points for the player who
	deployed the turret.  "False" means turret kills score no points.

$ActiveVotes - Set this to "True" to ignore all abstinations when a vote is called.  Set this to "False"
	to count votes normally.

$match - Set this to "True" to enable match rules, set this to "False" to use regular rules.

$SuicideSpawnPenaltyTime - (Match rules) This is the number of seconds that a player will have to wait after a
	keyboard suicide (cntrl - k) before respawning.  This prevents players from simply
	committing suicide when it might take a while to travel back to the base. 

$FlagValue - (Match rules) This is the number of points that a flag cap will score under match rules.

$PreventionValue - (Match Rules) This value is the number of points that a pleayer scores when he or she scores a 
	'Prevention'.  A prevention occurs when a flag carrier is killed, and the flag is touched by a member of the
	flag's team, sending the flag back to it's spawn point.

$KillValue - (Match rules) This is the number of points scored for a team when a player kill is scored.

$SwitchValue - (Match rules) This is the number of points scored for a team when a tower switch is
	changed to that teams colors.

$MaximumScore - (Match rules) This is the maximum points needed to win the mission.  Set this to 0
	to cause the game to last the full time limit regardless of score.  Setting this to 0
	also enables the halftime report.

$LockedServer - (Match Rules) Use this variable plus a players.cs file to allow only certain players to
	join the server and to specify what team each of those players join.

$RandomEvents - make this 'True' to allow random events, change it to 'False' to disallow any
	random events.

$RandomEventTime - This number is the time in seconds between random events.

$RandomTimeVariance -  This number represents the tolerance band of the random event time.  In 
	other words, set this to zero if you want exactly $RandomEventTime number of seconds
	between random events.  Set this to 0.5 if you want the time interval to vary by
	plus or minus 25%.

$Meteor -  If this variable is 'True' meteor showers are enabled, if this variable is 'False'
	then meteor showers are disabled.

$MeteorDensity - Set this to govern the overall number of meteors.  Higher numbers indicate
	more meteors.

$MeteorDuration - This is the time in seconds that the meteor storm lasts.

$MeteorAreaVariance - This variable is used to govern the amount at which the meteor density
	accounts for map surface area.  A 0 indicates no compensation, and a 1 indicates a
	total compensation which makes the actual density of meteor strikes consistent on any
	map.  This variable can quickly cause lag on slower servers because some maps have very
	large surface areas.

$MeteorWeight - This variable biases the random number generater in favor of or against meteor 
	showers.  In other words, if this number is high relative to the other weight variables
	than there will be more meteor showers than other random events.  If this number is low,
	than there will be fewer meteor showers relative to the other events.

$Lightning -  If this variable is 'True' lightning storms are enabled, if this variable is 'False'
	then lightning storms are disabled.

$LightningDensity - Set this to govern the overall number of lightning strikes.  Higher numbers
	indicate more lightning strikes.

$LightningDuration - This is the time in seconds that the lightning storm lasts.

$LightningAreaVariance - This variable is used to govern the amount at which the lightning density
	accounts for map surface area.  A 0 indicates no compensation, and a 1 indicates a
	total compensation which makes the actual density of lightning strikes consistent on any
	map.  This variable can quickly cause lag on slower servers because some maps have very
	large surface areas.

$LightningWeight - This variable biases the random number generater in favor of or against lightning 
	storms.  In other words, if this number is high relative to the other weight variables
	than there will be more lightning storms than other random events.  If this number is low,
	than there will be fewer lightning storms relative to the other events.

$SolarFlare -  If this variable is 'True' solar flares are enabled, if this variable is 'False'
	then solar flares are disabled.

$SolarFlareDuration - This is the time in seconds that the solar flare lasts.

$SolarFlareWeight - This variable biases the random number generater in favor of or against solar 
	flares.  In other words, if this number is high relative to the other weight variables
	than there will be more solar flares than other random events.  If this number is low,
	than there will be fewer solar flares relative to the other events.

$HaVoC::RandomMissions - Set this to true to have random missions generated on mission completion.
	Set this to False to use normal mission sequencing.

$HaVoC::RandomMissionTypes["xxxxxx"] - These variables define the types of missions that are allowed
	in the random mission search.  Set each variable to true for those mission types that should
	be allowed, set them to false for mission types that should be omitted.

$RestrictedMissions - Set this to "True" if you wish to allow only specific missions to be allowed in the
	random mission search.  Set this to "False" to use the normal $Havoc:: mission type variables
	to determine which missions will be allowed.

$AllowedMission[xxxxx] - Use these variables to define which specific missions will be allowed when 
	$RestrictedMissions is set to True.  Any mission not on this list, and not set to "True"
	will be rejected when a new random mission is selected.

$sin[x] - These values create a fade-in and fade-out effect for the intensity of some of the
	random events.





Revision History
----------------

V1.5

Changes:
	Permanent Highscores for Kills have been added. (Look for this to be expanded)
	EMP Hand Grenades have been added.
	Turret Kill Scores has now been made an option, and all turrets either score kills or do not.
	A halftime report has been added when playing under match rules.
	The Suicide Time penalty under match rules has been expanded to include all types of suicide
	  except the Kamikaze pack.
	A new score has been added under the match rules.  This score is called a 'Prevention'
	  see match rules section for details.
	The graphic for the deployable ELF turret has been changed to match that of the base ELF turret.
	To improve gameplay the Blastwalls and forcefields have had their strengths reduced dramatically.
	Several of the Higher powered weapons (Shotgun, Fusion Blaster, Plasma Cannon, Demolition Pack)
	  have also had their damage reduced.
	The Shield Generator is not able to be deployed on an enemy base.
	The Hologram will now hunt aggressors down rather than just stand there and be shot.
	Missions now are random on an automatic mission change. (Thanks Nathan Sweet)
	Abstinations may be set to be counted or ignored when voting.
	The Ammo pack now works properly with all types of ammo and also includes a small energy boost
	  similar to  but much weaker than the Energizer Pack.
	An option to limit the random missions that are allowed has been added.


Fixes:
	Grenades can now be picked up and used properly when found in the field.
	Field Door and Blast Wall base sensing code is now more robust.  This fixed a possible exploit
	  that could, under some circumstances, lead to these items still being placed in enemy
	  bases.
	The pack image for the Field Doors no longer floats in the air above a players body when being
	  carried.
	Scoring no longer counts debris kills.
	The Shield Generator should work 100% correctly now.
	A small error in the Base Alarm code has been fixed.  They will no longer sense distant targets.
	


V1.4

Changes:
	Plastique grenade type has been added (Thanks PeterT).
	The Blaster code has been refined slightly.
	The energy usage of the Cloaking Device has been reduced.
	Blastwalls and Forcefields may no longer be placed in enemy or neutral buildings.
	The Suicide DetPack is now called the Demolition Pack to avoid confusion with the
	  Kamikaze pack.
	Match rules have been implemented (more to come).
	The Repair Rifle autorepair function now works less efficiently.
	Antitk.cs has been integrated into professional.cs.
	Base Alarm code has been improved greatly. (Thanks Nathan Sweet)
	The Seedpack has been removed.


Bug Fixes:
	The Tab menu dissappearing bug has been fixed.
	Problems with Shield Gens and energy states have been fixed.  (still one more problem
	  to fix here I think)
	Incorrect death recording from environmental effects have been fixed.
	Team kills from Teleport Pack Malfunctions have been fixed.
	The Solar Flare code has been revised to produce less lag.



V1.31

Changes:
	The Blaster has been changed to tag firing mode.  The first shot that is locked on to a
	   target, marks the target.  All subsequent shots home in on the tagged target.
	   Locking on to a new target, tags the new target.
	Players now spawn with the chaingun in addition to the disk launcher.
	The chaingun spread pattern has been ightened somewhat.
	The range on the scout's weapons has been reduced slightly.


Bug Fixes:
	The Shield Generator now sets players energy levels correctly under all death situations.
	Teleport malfunctions now longer count as team kills for autokicking purposes.
	The Random events now spawn events correcly.  The Solar Flare was not being spawned
	   properly.	



V1.3

Changes:
	Random Events have been added as a weather effect to the game.  Please see the usage section
	   for instrunctions.
	The Teleport Pack now has it's full functionality.  Please see the usage section for
	   instructions.
	All Deployable Sensor pcaks, sensor jammer packs, and motion sensor packs now deploy multiple
	   units.  Ammo for these packs is determined by the armor worn.
	The Hyperlight armor now auto-repairs slowly over time.
	The Cloaking pack now also provides sensor jamming for it's wearer but uses much more energy.
	The image for the deployable Missile Turret has been changed to match the image of the base
	   missile turret. (PeterT's suggestion)
	The Particle Accelerator has had the 'Low Energy' warning message removed. 
	   (Tatexi's suggestion)
	Fieldoors may not be placed over items any longer.  This prevents an exploit that allowed
	   permanate incapacitation of bases.
	The Shield Generator has been completely recoded in an effort to reduce lag.
	The damage value of the Kamikaze Pack has been reduced.
	

Bug Fixes:
	The Ammo stations now reload ammo from any and all weapons.
	Death messages appearing from incorrect damage types have been fixed.
	Failure of the Teleport Pads to Re-Init properly after a mission change *should* be fixed.
	


V1.2

Changes:
	The Marlin Rifle's reload time has been decreased from approximately 8 seconds to 3 seconds.
	The Fusion Blaster has been modified to fire fewer projectiles, but more damaging ones.
	   This should help reduce lag somewhat.
	The Teleport pack has been changed to Teleport it's user to an observer spawn point,
	   rather than a team spawn point.
	The Mini-ELF turret has been removed.  I was redundant with the Heavy-ELF turret.
	The Kamikaze pack is now wearable by the medium armour and auto-detonates when it's
	   wearer is killed.
	Turret control has been added to the Flak Turret, The Guard Dog, and the Pulse Laser Turrets.
	The Death of Bots Turret has been renamed the Pulse Laser Turret.
	The Beacon has been temporarily removed from play because it is undergoing major changes.

Bug Fixes:
	A bug that prevented the Engineer Armour from being able to buy Marlin Ammo has been fixed.
	  (Thanks KwisatzHaderach)
	A bug that caused Female Armours to not have access to some items that the equivalent male
	  armours had access too has been fixed.
	The shield generator's code has been streamlined in an effort to reduce lag.  This will be
	  a continuing project with the shield generator.
	

V1.1 - Initial Public Release