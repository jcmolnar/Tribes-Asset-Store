This file dated 7-25-99
----------------------

DISCLAIMER
----------
-First and foremost, I would like to point out that the hvTactical-v1 
mod started out as the PALrenegades mod; a heavily modified version 
of the Renegade v1.3 mod. It is now a mod that plays quite differently 
than the Renegades series and, thusly, I have changed the title to 
hvTactical. This is not to disavow any credit to the makers of 
Renegades, but to differentiate the philosophical ideals of the two 
mod series. I would like to acknowledge the skill of everyone involved 
with the Renegades, Insomniax, and Retro mods. My mod would not have 
been possible without their pioneering efforts in the field of scripting. 

-I have no qualms about using other peoples ideas or them using mine, 
but ONE SHOULD ALWAYS STATE THE SOURCE OF ANY CODE OR IDEA that is not 
one's own. There is a fine line between borrowing and stealing when it 
comes to scripting and that line is defined by DISCLOSURE OF SOURCES.

-so what did I do on this mod? 
 -I made MANY new deployables, weapons, and equipment
  -The full list of changes is below . . .
 -I changed a bunch of settings to make the mod more balanced and
  team oriented, rather than the killing field that Renegades has become
 -I imported some ideas and weapons from Insomiax and Retro mods
 -Also, I incorporated Labrat's Pskin mod game.cs file into the package.
  -This allows you to show custom skins in all game types.

Link to Mephisto, Labrat, and Insomniax from my site, 
"House Vagoroth" at . . .
www.geocities.com/TimesSquare/Fortress/5514

----------------------------------------------------------------------
To host with hvTactical-v1
--------------------------
1)create a new directory in Tribes/ called /hvTactical-v1
	a)should read "Tribes/hvTactical-v1" in explorer

2)unzip the scripts.vol file in this directory

3)go to your Tribes shortcut 
	a)select properties
	b)on the line "target" add " -mod hvTactical-v1"
	c)should read "Tribes.exe -mod hvTactical-v1"

4)to run a dedicated server
	a)add " -dedicated" after the mod 
	b)should read "Tribes.exe -mod hvTactical-v1 -dedicated"

5)run the game from this shortcut

6)to switch back to normal Tribes, remove the -mod line from the 
shortcut (step 3)

----------------------------------------------------------------------
Scripter's Note:
 - if you look at the code in hvTactical-v1 mod, you will notice
that I have remarked in many of the .cs files as to the functions of
lines, etc. My new lines and sections can be seen easily by the string
of +++++++ next to them.

-----------------------------------------------------------------------
-below is the list of added and modified equipment for hvTactical-v1
-----------------------------------------------------------------------
-please note: This list presumes that you are already familiar with the
Renegades mod series, for more details, consult the hvTactical field 
manual
----------------
Weapons and Ammo
----------------
-all armor types can carry all ammo types to reload others in the field
 -idea courtesy of "hvHelplessTarget"

-no longer need the energy pack for the Shockwave Cannon
 -Shockwave energy consumption increased to compensate

-remade the Railgun into the "Light railgun", new performance, sounds, 
etc.

-detuned the Sniper Rifle a little, was too powerful, made the laser
rifle irrelevant

-added fire sound to the Sniper Rifle

-upped the power a little on the Laser Rifle, a CLEAN head shot will
kill a light armor now

-no longer need the Energy Pack to use the Laser Rifle

-slightly increased the rate of fire of the Chaingun

-added the "Mine Launcher", beware, these mines are not team-friendly
 -idea courtesy of "hvHelplessTarget"

-made the Assault Rifle
 -code modified from the Retro mod

-imported and modified the MAG gun and EMP launcher from the Insomiax mod
 -reduced the MAG gun's range to 18 meters, and reduced the cone angle
 -modified EMP effect to include blinding and incremental damage
  -ideas courtesy of "HelplessTarget" and myself

-fixed Assault Rifle ammo station resupply bug 
 -idea courtesy of "hvRainman" and "hvLobo"

-sped up the fire rate of the Vulcan (but not the damage per bullet)

-made the "Particle Accelerator", high rate of fire, cluster bomb 
effect, that uses up energy VERY quickly
 -idea courtesy of "hvHelplessTarget" and myself
 -code help from "Emp" and "IX_Savage1", thanks a lot guys :)

-added and modified the "Shotgun" from Insomniax

-reduced the blast radius of the Stinger to 20.0 meters

------------------------------------------------------------------------
Deployables and Packs
---------------------
-increased targeting range on "Plasma Turrets" to 200 meters

-fixed "ELF Turret" respawn problem

-deployable Cameras now have shields
 -idea courtesy of "hvHelplessTarget"

-changed deploy limits on some of the deployables

-made the "Demolition Pack"
 -code modified from the Retro mod

-made the "Vulcan Turret", shreds armor but quickly overheats

-renamed "Deployable Turret" to "Sentry" and added shields

-reduced deployable "ELF" and "MAG" Turret ranges to 30 meters

-made the "Watchdog" deployable spotter turret
 -idea courtesy of "hvHelplessTarget"

-made the "Flak Gun" deployable anti-aircraft turret

-made Rocket Turrets fire faster, with slightly less damage

-made the "Guard Dog" deployable shockwave turret

-made the "Breath of RA" flamethower turret

-made the "Claymore" high-explosive mine
 -idea courtesy of "M O S E"

-increased repair pack range to 10 meters

-increased both the rate of repair and rate of energy consumption or the
Repair Pack
 -idea courtesy of "hvHelplessTarget"

-ammo packs now supply an additional two repair kits

------------------------------------------------------------------------
Misc. stuff
-----------
-all armors can now carry two repair kits
 -idea courtesy of "hvHelplessTarget"

-reduced damage of shield doors so they can be blown up (with a LOT of
effort)

-fixed inventory favorites quantity limit - item limit now 50 (vs. 19)

-made the Percheron, an LPC which fires a Shockwave/EMP round

-made the Mastadon, an HPC that fires mortar rounds

-made the Eagle, a Scout who's rocket has a reduced blast radius from the
one in Renegades

-made the Hornet, an Interceptor that fires low/yield, high speed plasma rounds

-increased deployable Inventory Station energy to 5400

-players respawn in Mongoose armor with Blaster, Chaingun, Disc
Launcher, and Assault Rifle; Energy Pack; Beacons (boosters), EMP
Mines, Napalm Grenades, and Targeting Laser

-increased damage to weapon knock-away

-new Wolverine armor type, made to close distance quickly and kill in 
close quarters

-changed the colors of the grenades and mines so that they corresponded
to the type of damage they inflict . . . see chart below . . .

 armor      mine                  grenade             color
 -----      ----                  -------             -----
Peregrin   deployable tree mine  larmor clone mine    Lt.Yellow/none
Nighthawk  standard mine         Demolition Grenade   none/Red
Kestrel	   standard mine         EMP grenade          none/Purple
Mongoose   EMP mine              napalm grenade       Purple/Red
Badger     stinger mine          concussion grenade   Yellow/Yellow
Wolverine  standard mine         napalm grenade       none/Red
Owl        claymore mine         stinger grenade      Red/Yellow
Grizzly	   shockwave mine        shockwave grenade    Lt.Blue/Lt.Blue
Kodiak	   mortar mine	         mortar grenade       Green/Green

    -another way to look at it is . . .
	- Red = explosion, Green = mortar, Blue = shockwave, Purple = 
	EMP damage, Yellow = concussion

-changed item pricing to relative values

-changed the DM default armor type to the Kestrel
 -thanks Bradley and Labrat for finding the code for me

----------------------------------------------------------------------
IN THE FUTURE FOR hvTactical-v1
-------------------------------
-make the "Mine Launcher" mines team friendly 

-a "sensorjammer/pulse sensor/motion sensor" pack for the scout

-add a deployable generator to backup main generators
 -idea courtesy of "hvHelplessTarget"

-"Sidewinder" guided missile launcher 

-change mines on the Nighthawk and Kestrel to "sensor jammer mine" and "pulse
sensor mine", respectively

-make Owl healing ability apply to items as well as teamates
 -idea courtesy of "hvHelplessTarget", "hvLobo", and "hvRainman"

-give large deployable shields "door" ability
 -idea courtesy of "hvHelplessTarget"

-create a lightsaber (for all you who want swords)

-make EMP damage apply to vehicles, causing them to crash or land

-create a deployable EMP field generator
 -idea courtesy of "hvHelplessTarget"

-create a short range "Impact Cannon" similar to Ra's palm device in 
Stargate

-create a "Heavy Railgun" to compliment the "Light Railgun"

-create the "Swarm Rocket", a rapid-fire, Robotech-style missile launcher

-create the "Wasp" vehicle, armed with a Particle Accelerator
 -idea courtesy of "hvMaestro"

-anything else? just email me your suggestions (see below)
 -I will credit anyone who gives me an idea that I use (see watchdog
  claymore, minelauncher, etc.)

-----------------------------------------------------------------------
comments/feedback/suggestions
-----------------------------
email . . . palantirion@geocities.com

URL: House Vagoroth . . . www.geocities.com/TimesSquare/Fortress/5514

"The time has come to speak of many things...
The ups and downs of flying clowns, 
and cannons wearing wings"--Author Unknown