----------------------------------------------------------------
Name: Phobiax Expansion Mod.
Version: 1.09 (For TRIBES Version 1.7 and above)
Date: 10-29-2000
Author: Ben Ross (Dreadnaught)
Email: phobiax@thisplacehere.com
URL: http://phobiax.thisplacehere.com/
Purpose: To expand upon an already great mod. 

Notes:  Phobiax, being an expansion, require the Insomniax mod
        to be properly installed.  For all intensive purposes,
        Phobiax should be treated simply as an update to IX.
        It has everything in the 0.9c version of the IX mod as
        well as a few new items and new features for old items.

        In order to use Phobiax, follow the same instructions
        given for the installation of Insomniax below.  Anything
        specific to Phobiax, I've put a box of asterisks (*)
        around so that it is easier to tell apart.

        Included with the Phobiax mod, is everything needed to
        install the most current version of Insomniax (v0.9c).
        Below is the remainder of the ReadMe normally included
        with Insomniax.

****************************************************************

----------------------------------------------------------------
Name: Insomniax.net TRIBES Mod.
Version: 0.9c (For TRIBES Version 1.7 and above)
Date: 01-23-2000
Author: Kevin Savage (*IX*Savage1)
Email: Savage1@insomniax.net
URL: http://www.insomniax.net/mods
Purpose: To Maintain Game Balance and Increase Complexity. 
         Also Increasing Intensity of Gameplay, with Teamwork. 

Notes:  This Mod Does NOT make changes to ANYTHING in Tribes\base. 
        This can be installed without harm to standard Tribes\base 
        games or any other mods. This Mod is NOT meant to be run 
        with IX-Admin. IX-Admin is Built into the Insomniax Mod.
        IX-Admin is a by product of this mod.  Combining them is
        pointless, and could generate problems with the mod. 

Thanks: To the Tribes Dev Team, and All those at Dynamix/Sierra that
        make this game possible. I'd also like to thank them, and 
        specificly Tim Gift, for answering my emails with questions
        about this or that, and taking bug reports. They seem to 
        truely care about what goes into the game. I admire them for
        that.
                   Thanks.

        I'd also like to thank *IX*LongBow and others that took the time
        to test this or that whenever I asked "Hey, got a minute?". 
        Without that, I wouldn't have gotten nearly as much done. 
                Thanks guys.

---------------------------------------------------------------

Client Install: NONE. 
        Notes for Client Playing the mod. Weapons can be accessed
        by Selecting "Next Weapon" or "Previous Weapon". There are
        no Numbers assigned to the new weapons. (Default key is 'Q')
        In order to bind the weapons and items you need to use(ItemName)
        The Item Names for each item is listed with the items below.

Server Install: 
        1. Unzip IXTribes09b.zip into default Tribes Dir.
           (where tribes.exe resides - UNZIP WITH PATH INFORMATION)
        This means:

        When installed The Files Should be here: 
                Tribes\config\pxUserList.cs
                Tribes\config\phobiax.cs
                Tribes\phobiax\scripts.vol
                Tribes\phobiax\staticshape.cs
                Tribes\phobiax\ReadMe_Phobiax.txt
                Tribes\phobiax\Phobiax_ItemList.txt

        NOTE: If these files are not in these folders ..put them there.
              IF THIS IS NOT THE FIRST TIME INSTALLING and you have the 
              phobiax.cs file already you don't need to unzip this
              one. You can choose to add the new variables, or not.
              The server will choose default values. Settings can be
              changed during the game and are saved when the server
              exits normally. If you want to save the config while
              the game is active just execute the pxSave(); command
              at the console.
        
        2. COMMAND LINE to run the mod.
                Note: A command line is what you use to start 
                the game. for windows it's called a shortcut. 
                It's what you double click on to run the game.
                If you have a Tribes Icon on your desktop, 
                right click it and select Properties.  "Target"
                is the command line. Don't email me asking what
                it is, because I just told you. Thanks. 


           **************************************************************
           *                                                            *
           *    In order to run Phobiax instead of Insomniax, simply    *
           *    replace put "phobiax" in the command line instead       *
           *    of "insomniax".                                         *
           *                                                            *
           *    As in the above example, you would run:                 *
           *            tribes.exe -mod phobiax                         *
           *                                                            *
           *    This same principle applies to the rest of the          *
           *    examples below as well.                                 *
           *                                                            *
           **************************************************************


         - Just add "-mod phobiax" to your current Server Command Line.
           For Example:
                Running Normally. 
                        tribes.exe
                Running this Mod.
                        tribes.exe -mod phobiax

         - If you have a custom Server Config then add the +exec Parameter
           BEFORE The -mod parameter.         
           For Example:
                Running Normally. 
                        tribes.exe +exec MyConfig.cs
                Running this Mod.
                        tribes.exe +exec MyConfig.cs -mod phobiax

         - If your runing dedicated and have a special server config. 
           I suggest you use infinitespawn. (get it at tribesplayers.com)
           For Example:
                Running Normally. 
                        infinitespawn *tribes +exec MyConfig -dedicated
                Running this Mod.
                        infinitespawn *tribes +exec MyConfig -mod phobiax -dedicated

         - If For Some Reason phobiax.cs is not executing when the mod loads. 
           (It should be automatic) Then just add it to the command line.
           For Example:
                Running Normally. 
                        infinitespawn *tribes +exec MyConfig -dedicated
                Running this Mod and Executing the Mod Config.
                        infinitespawn *tribes +exec MyConfig +exec phobiax -mod phobiax -dedicated

---------------------------------------------------------------

NOTE: If you dont know what im talking about then please learn
      how to run a server before yelling at me because you don't
      know how. Im assuming you already have a server running, or
      at least read the instructions on how to do so.  

Here are a few URLs in case you don't.

        http://www.tribesplayers.com/tribesplayers/server-basic-config.html
 
        http://www.tribesplayers.com/tribesplayers/server-advanced-admin.html
 
        http://www.tribesplayers.com/tribesplayers/server-mods.html
 
        http://www.tribesplayers.com/tribesplayers/faq.html#sec1 

Full Information for the Mod can be found at the Mod Site:

        http://phobiax.thisplacehere.com/

All Questions will be answered on the Mod message board. 
The link to the board can be found on the mod site. 
Please post any and all feedback you have there. 

---------------------------------------------------------------

Uninstalling:

        Delete the Tribes\phobiax Directory and everything in it. 
        Delete phobiax.cs and pxUserList.cs from within the 
        Tribes\config Directoy. All files are listed above. 
        THIS MOD DOES NOT CHANGE ANYTHING IN TRIBES\BASE OR
        ANYWHERE ELSE. IF THE FILE IS NOT LISTED ABOVE IN THE SERVER
        INSTALL INSTRUCTIONS , IT HAS NOTHING TO DO WITH THIS MOD.

----------------------------------------------------------------
Disclaimer:
            I am not responsible for any damage this game 
            modification may cause you or anything having to do 
            with you. If you lose your job because you play this
            game nite and day, it is purely your responsibility.
            I also am not responsible for any hardware failures 
            or software problems that may arise in TRIBES. For 
            problems of that nature contact the game manufacturer.
            If you believe this modification has problems please 
            report them to me so that I may look into it. 
                This mod is by far the most copied mod for TRIBES.  
            I am not responsible for any bugs or problems caused
            from copying this code into another mod. I do not claim
            to support any other mod using my code. If they have
            problems, bother them, not me.   - *IX*Savage1

        **************************************************************
        *                                                            *
        *   In addition to the above statements, note that Phobiax   *
        *   does NOT change any of the Insomniax code.  It simply    *
        *   adds to it.  I am not responsible for anything already   *
        *   mentioned above.  However, if you encounter any bugs,    *
        *   contact me, not *IX*Savage1.   - Dreadnaught             *
        *                                                            *
        **************************************************************

----------------------------------------------------------------

All code changes are copyright. 
© 1999, 2000 - Insomniax.net
