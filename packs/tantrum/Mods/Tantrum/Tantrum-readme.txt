   ///////////////////////////////////////////////////////
  //                   Tribes Tantrum                  //
 //              created by the maLadroit             //
///////////////////////////////////////////////////////

Completed July 11, 2005
(Beta Period)

Glitch-Free update July 15, 2005

Updated once again on July 18, 2005

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      [|Credits|] :

	First of all a big thanks to previous coders for their code that I used:

		- [HvC]NaTeDoGG for writing a lot of really usefull code for any modifications that you can still find in the Havoc mod.
			- Author of HaVoC Mod: http://havoc.sirris.com

		- Plasmatic, creator of many mods including Vengeance and Annihilation. Without his help I would have never been able to do some of the things that I did. Anyone who is involved in a serious tribes modding project should take a look at his code (Vengeance mod is open source and has some really useful and unique stuff) and/or consult him on the Annihiliation Forums.
			- www.annihilation.info

		- Floater Eater, for his BotGun code, which made Artificial Intelligence a possibility for my mod. Although i manipulated it into something different and more fitting for my mod, his script was the building platform.
			- Find him on the Anni forums, ScreenName: Floater Eater


	Secondly, Thank You to all of the various coders on the Annihilation, I never knew there were so many knowledgable tribes coders out there and it seems that they all gather on the Anni "Coder's Hangout"
		- http://www.annihilation.info/forum/viewforum.php?f=2

	Thanks to Abraxas for hosting and testing the mod for multiplayer glitches
		- Find him on the Annihilation Coders Hangout Forums

	Special thanks to robindegen for hosting me, anyone who is looking for a 3d game engine should check his site out
		- http://www.dgm3dengine.com
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

_____| Code Use |______

 After much personal debate with myself, I have come to the conclusion that me making a closed source mod would be hypocritical, as much of my knowledge did come from looking at other's code.
This does not, however, give anyone the right to just blatantly take code from this mod. If you like something, feel free to use it but please give credit and do something unique with it.
I wish to encourage those involved in modding projects, but I also feel it is important to learn from others code, not just utilize it. I'm not worried about weapons or items being taken,
I am simply worried about the gameplay being cloned, too much of one mod in another just makes it a copy of that mod. If you create a mod, please make it unique and feel free to use anything
in this mod. Anyways, my code is so messy from rewriting it over the course of it's creation that I consider anyone who can use it properly justified to do so.
 Thank you


_____| Installation Help |_____

1.   If you have not already done so, extract all files from tantrum.zip
  into your dynamix/tribes folder (so it will be in the same directory
  as the folders for base, config, etc...)

2.   To run the mod as a dedicated server:
	- Open Command Prompt (This can be done by going to Start/Run and then typing cmd.exe)
	- Get into your Tribes directory, this can be done by typing "cd dynamix/tribes" (without the quotes)
		- If you get an error after this, it means you were not starting in the "C:/" directory.
			- Entering "cd ../../.." would take you back to the "C:/" directory if you were in a directory 3 folders after C:/ (C:/onefolder/anotherfolder/lastfolder)
	- Once inside the Tribes directory (usually C:/dynamix/tribes) type "tribes.exe -mod tantrum -dedicated"

****See "Command Prompt Help" for more information****

     To run the mod as a temporary tribes client:
	- Open Command Prompt (This can be done by going to Start/Run and then typing cmd.exe)
	- Get into your Tribes directory, this can be done by typing "cd dynamix/tribes"
		- If you get an error after this, it means you were not starting in the "C:/" directory.
			- Entering "cd ../../.." would take you back to the "C:/" directory if you were in a directory 3 folders after C:/ (C:/onefolder/anotherfolder/lastfolder)
	- Once inside the Tribes directory (usually C:/dynamix/tribes) type "tribes.exe -mod tantrum"


_____| Command Prompt Help |_____

 - Before you can run tribes.exe (and therefore the mod that uses it) you must be in the right directory.
	- This is usually "C:/dynamix/tribes" but it may be different for you
 - To get to this directory you must first be in the one(s) preceeding it, for example "C:/dynamix" or more likely, "C:/"
 - If you are not in one of these directories you can get there by simply typing:
	"cd ../" if you are in a folder inside of "C:/" such as "C:/Program Files"
	"cd ../.." if you are in a folder that is two folders deep in "C:/" path, ex: "C:/mydocs/newfolder"
	This same pattern applies no matter how deep you are, theoretically if you are in a folder that is 56 folders after "C:/" you would type "cd " and then 56 of these "../"
 - Once you are in the "C:/" directory you may now go into the tribes folder
	- Do this by entering the command "cd dynamix/tribes" or a different location if it isnt in that directory


_____| Gameplay Strategy / Tips |_____

	- First and foremost important in this mod is the way you use your character
		- Each character has it's strengths and weaknesses
		- Main Character Strategies:
			- Medic: This character is one of the best suited for capturing the flag, but if you choose to use it for defense/all-around you should deploy Life Trees and then repair your teamates and your teams Deployed Items such as Turrets, Holograms, Portals.
				-Also, make good use of your Flag Decoy to confuse the enemy defense into chasing you.
			- Energy Gyp: Keep fair distance and hit your opponent with an EMP Shockwave and then go in for the kill when they have no energy
				- Your taser is a perfect tool to use against anyone who comes to close, and you energy draining weapons make you perfect for Flag Defense
			- Pyro: With this character it is important to beware the fact that your weapons rely on energy for the mostpart, so it is important that you move quickly on the ground if it is drained
				- Use you Flamethrower at close distances, and your rockets/grenades if you are going on a destructive offensive campaign
			- Assassin: One very fun thing to do with this character is to turn on your Cloak (Backpack) and simply sneak up on people and then kill them instantly with the Zapper
				- Using your railgun to often will result in loss of energy, and can give away your position, to stay under the radar, use your Rifle.
			- Engineer: Deploy everything that you can, and use your Teleport pack wisely.
				- Portal location is very important, on each map put your two portals in the most advantageous places you can find so that you team makes good use of them, especially on the larger maps
				- You only have 4 droids per map, so I suggest you deploy them wisely, you can control them by selecting clients via the 'TAB' menu and issuing a "Follow" or "Attack" command (it is one of the options after you click on a name)
			- Trooper: Take advantage of you EnergyPack's power as well as your weapons, you are proabably the most versatile Character
				- You are suited to do anything from causing havoc for the enemy's defense to defending the perimeter of your base, and you also are well suited to capture the enemy flag
			- Juggernaut: Two important things to remember:
				- Shotgun = Short Range (perfect for incoming cappers if your on the flag)
				- Argon = Long range Base Bombing (good for causing trouble in the enemy territory).


--------------------- http://themaladroit.dgm3dengine.com -------------------------------

	Thank you for being a part of my mod and supporting it by downloading it.
	If you are hosting a server and have questions (and even if your not hosting a server) feel free to ask me.
	AIM: imthemaladroit
	e-mail: zhuber@mail.csuchico.edu
	
	-the maLadroiT
