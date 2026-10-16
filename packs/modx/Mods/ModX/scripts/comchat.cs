// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.cjb.net/
//
//----------------------------------------------------------------------------
$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

$HelpMsg[0]  = "ModX has a website, visit it @ http://modx.cjb.net/";
$HelpMsg[1]  = "ModX Elevators can go anywhere, just move the Path Marker and weld the elevator!";
$HelpMsg[2]  = "You can re-name your slots, goto Account Management and then Account Settings.";
$HelpMsg[3]  = "You can save your builds with ModX! Goto Account Management and then Save Objects";
$HelpMsg[4]  = "The welder is a very useful tool, it can keep objects in place and activate things on certain objects.";
$HelpMsg[5]  = "You can change your keyboard layout, goto Account Management and then Keyboard Settings.";
$HelpMsg[6]  = "The ModX Door, and any variants, can be locked with the welder.";
$HelpMsg[7]  = "You can save up to 400 objects with ModX Client Side script!";
$HelpMsg[8]  = "Comments, suggestions, or bug reports? Send Vage an email: jbgohlke@yahoo.com";
$HelpMsg[9]  = "You can modify how your object deploy with the !pos and !rot chat codes.";
$HelpMsg[10] = "To contact Vage outside of TRIBES, say '!credits' to get some contact info.";
$HelpMsg[11] = "The Channel System can be used with !chan X where X is the name of the channel (Public is main).";
$HelpMsg[12] = "There is a Zero-Tolerance for Stacking, please refrain from deploying useless, or random, objects.";
$HelpMsg[13] = "Laser Tag mode is a fun way to play in an arena you built! You can vote for it from the Voting menu.";
$HelpMsg[14] = "ModX was created by Vage, with Uber-Help from MiD. Have fun!";
$HelpMsg[15] = "Vage is trying to keep ModX as stable as possible, please bear with him if something goes wrong.";
$HelpMsg[16] = "To disable help messages say !togglehelp, to enable them again, say it again";
$HelpMsg[17] = "ModX now has a community forum! Goto http://modx.cjb.net/ and click on fourm!";
$HelpMsg[18] = "Use the Movement Path Designer to modify your elevator's speed, movement, and other things!";
$HelpMsg[19] = "The Movement Path Designer allows you to customize your elevator, try it out!";
$HelpMsg[20] = "ModX is now PUBLIC, download it from http://modx.cjb.net/!";
$HelpMsg[21] = "Use the new copy function to copy other's objects, or your own!";
$HelpMsg[22] = "Go get the ModX Client-Side Addon from http://modx.cjb.net/!";
$HelpMsg[23] = "You can adjust the radius of various tools with the '!radius <meters>' chatcode.";
$HelpMsg[24] = "You can use lights to give your builds some atmosphere!";
$HelpMsg[25] = "With the client-side script add-on you can now login automagically!";
$HelpMsg[26] = "With builder groups you can now edit each other's objects, and save them too!";
$HelpMsg[27] = "Builder groups are used with '!joingroup <GROUP>', '!leavegroup', and '!savegroups'";

$numHelpMsgs = 28;

function randomHelpMsg()
{
    if($ModXHelpDelay == -1)
    {
        schedule("randomHelpMsg();", 10);
        return;
    }

    %rand = Math::randomInt($numHelpMsgs); //floor(getRandom() * ($numHelpMsgs - 0.01));
    %msg = $HelpMsg[%rand];
    sendHelpMessages($MsgTypeTeamChat, %msg);
    schedule("randomHelpMsg();", $ModXHelpDelay);
}

function GagClient(%clientId, %gag)
{
   %clientId.isGagged = %gag;
}

function LlamaClient(%clientId, %llm)
{
   %clientId.isLlama = %llm;
}

function remoteSay(%clientId, %team, %message)
{
    %message = String::getSubStr(%message, 0, 240); // PORT: the length cap of the patched stock comchat.cs, missing in this fork
    if(%clientId.IsAFucker == true) //Ah the joys of colourful language! -Vage
        return;

    // 'hexploit' protection, Thanks TooCrooked!
    %threshHold = 0;
    if(String::findSubStr(%message, "\t") != -1)
        %threshHold += threshHold(%message);
    if(String::findSubStr(%message, "\n") != -1)
        %threshHold += threshHold(%message);
    if(String::findSubStr(escapestring(%message), "\\x") != -1)
        %threshHold += threshHold(%message);

    if(%threshhold > 80)
    {
        if(!%clientId.floodMute)
        {
            schedule("Net::kick("@%clientId@", \"Harmful Message Detected! [AUTO-KICKED]\");", 0.1);
            %clientId.IsAFucker = true;
            schedule(%clientId@".IsAFucker = false;", 0.2);
        }
        %message = "";
    }

    if (%clientId.EnteringPassword == true)
    {
        if(%message == "")
        {
            centerprint(%clientId, "<JC><F1>Blank Passwords are not allowed");
            return;
        }
        %name = Client::getName(%clientId);
        if(Account::isValidPassword(%clientId.AcctNo, %message))
            Account::LogOn(%clientId);
        else
            Account::LogOff(%clientId);
        return;
    }

    if(%clientId.EnteringNewAcct == true)
    {
       if(%message == "")
       {
           centerprint(%clientId, "<JC><F1>Blank Passwords are not allowed, please choose a new password");
           return;
       }
       %name = Client::getName(%clientId);
       Account::Add(%clientId, %message);
       %clientId.pass = %message;
       Account::LogOn(%clientId);
       return;
    }

    if(%clientId.ChangeAcctPass == true)
    {
       if(%message == "")
       {
           centerprint(%clientId, "<JC><F1>Blank Passwords are not allowed, please choose a new password");
           return;
       }
       %name = Client::getName(%clientId);
       $ModXAcctPass::[%clientId.AcctNo] = %message;
       %export = "$ModXAcctPass::*";
       export(%export, $AccountFile2, false);
       %clientId.ChangeAcctPass = false;
       CenterPrint(%clientId, "<JC><F1>Your new password is <F2>" @ %message @ "<F1>.", 4);
       return;
    }

    if(%clientId.ReNamingSlot != -1)
    {
        %name = Client::getName(%clientId);
        if(String::Len(%message) >= 10)
            return;
        if(%message == "" || %message == " " || %message == "  " || %message == "   " || %message == "    " || %message == "     " || %message == "      " || %message == "       " || %message == "        " || %message == "         " || %message == "          ")
            %message = "[BLANK]";
        Account::NameSlot(%clientId, %clientId.ReNamingSlot, %message);
        %clientId.ReNamingSlot = -1;
        return;
    }
if(!$LaserTagMode)
{
    if (String::MakeCaps(%message) == "!TRANS")
    {
        Client::sendMessage(%clientId, 0, GameBase::getMuzzleTransform(%clientId));
        return;
    }
    if (String::MakeCaps(%message) == "!HELP")
    {
        //centerprint(%clientId, "<F1><JC>Help Menu:<JL>\n\t<f2>!wdid<f1> = What Do I Do?\n\t<f2>!hcngobj<f1> = How To Change Objects To Be Deployed\n\t<f2>!modver<f1> = Displays Mod's Version\n\t<f2>!modctr<f1> = Displays Mod Creator|Co-Creator\n\t<f2>!rules<f1> = Server Rules\n\n<f1><JL>!nextpage", 30);
        centerprint(%clientId, "<F2><JL> Help Menu\n<F1>\n\t!what\t\t\t\t\tWhat Do I Do?\n\t!cfg\t\t\t\t\t\tHow do I configure things?\n\t!rules\t\t\t\t\tDisplays the general rules.\n\t!commands\t\t\tDisplays help on the chat code commands.\n\n<F0><JC>!help to return here, !quit to quit, or !more to turn the page.\n ", 30);
        %clientId.isInHelp = true;
        return;
    }
    if (%clientId.isInHelp == true)
    {
        if (%clientId.IsThereMore == true)
        {
            if (String::MakeCaps(%message) == "!MORE" && %clientId.commands == 1)
            {
                centerprint(%clientId, "<F2><JL> Command Help<F1>\n\n\t!modver\t\tSyntax:\t!modver\n\t\t\t\t\tExample:\t!modver = Displays the current mod version\n\n\t!credits\t\tSyntax:\t!credits\n\t\t\t\t\tExample:\t!credits = Displays some Credits\n<F2>\n More>", 30);
                %clientId.commands++;
                return;
            }
            if (String::MakeCaps(%message) == "!MORE" && %clientId.commands == 2)
            {
                centerprint(%clientId, "<F2><JL> Command Help<F1>\n\n\t!chan\t\tSyntax:\t!chan [CHANNEL] or !chan quit\n\t\t\t\t\t!chan MX = talks in the MX Channel\n\n\t\t\t\t\n\t\t\t\t\t\t\n<F2>\n End", 30);
                //centerprint(%clientId, "<F2><JL> Command Help<F1>\n\n\n\nxample:\t!give Vage = Gives all your items to Vage\n\n\t!talk\t\t\tSyntax:\t!chan [CHANNEL] or !talk quit\n\t\t\t\t\tExample:\t!talk MX = talks in the MX Channel\n<F2>\n End", 30);
                %clientId.commands++;
                return;
            }
            %clientId.commands = 0;
            %clientId.IsThereMore = false;
        }
        if (String::MakeCaps(%message) == "!COMMANDS")
        {
            centerprint(%clientId, "<F2><JL> Command Help<F1>\n\n\t!rot\t\tSyntax:\t!rot [X Y Z] [Degree]\n\t\t\t\tExample:\t!rot X 45 = 45 degree tilt on the X Axis for deployables\n\n\t!pos\t\tSyntax:\t!pos [X Y Z] [Meters]\n\t\t\t\tExample:\t!pos Z 5 = 5 Meter offset on the Z Axis for deployables\n<F2>\n More>", 30);
            %clientId.commands = 1;
            %clientId.IsThereMore = true;
            return;
        }
        if (String::MakeCaps(%message) == "!WHAT")
        {
            centerprint(%clientId, "<F2><JL> What Do I Do<F1>\n\n\t- Build any structure/house/whatever.\n\t- Use your dexterity skills to the max.\n\t- Have Fun!\n\n\n<JC><F0>Although, there are some rules, please read them: <F2>!rules\n ", 30);
            return;
        }
        if (String::MakeCaps(%message) == "!CTRL")
        {
            centerprint(%clientId, "<F2><JL> Controls<F1>\n\n\t- 4-9 Keys = Switch Weapons\n\t- 1/2 Keys = Cycle Options\n\t- 3 = Undo\n\t- G = Boost\n\t- M = Brake\n\n\n\n ", 30);
            return;
        }
        if (String::MakeCaps(%message) == "!RULES")
        {
            centerprint(%clientId, "<F2><JL> Rules<F1>\n\n\t- No Stacking\n\t- No Deploying Useless or Random Objects\n\t- No disturbing other's builds\n\t- No being bothersome, annoying, or stupid\n\n<JC><F0>If you do not observe these rules you will be kicked, banned, or punished in some way.\n ", 30);
            return;
        }
        if (String::MakeCaps(%message) == "!CFG")
        {
            centerprint(%clientId, "<F2><JL> Config Help<F1>\n\n\t- You can change what object to deploy using the TAB menu or 1/6 keys\n\t- To offset an object use the chatcodes\n\t- To delete your own Interior objects, use the TAB menu\n\n\n<JC><F0>Please read !ctrl for Keyboard Controls\n ", 30);
            return;
        }
        if (String::MakeCaps(%message) == "!QUIT")
        {
            centerprint(%clientId, "<F2><JC>!help <F1>was brought to you by the ModX Team!", $DefStayTime - 2);
            %clientId.isInHelp = false;
            return;
        }
        Client::sendMessage(%clientId, 1, "Invalid Help Command");
        centerprint(%clientId, "<F2><JL> Help Menu\n<F1>\n\t!what\t\t\t\t\tWhat Do I Do?\n\t!cfg\t\t\t\t\t\tHow do I configure things?\n\t!rules\t\t\t\t\tDisplays the general rules.\n\t!commands\t\t\tDisplays help on the chat code commands.\n\n<F0><JC>!help to return here, !quit to quit, or !more to turn the page.\n ", 30);
        %clientId.isInHelp = true;
        return;
    }

   if(String::MakeCaps(%message) == "!SLOW")
   {
      if (Player::getArmor(%clientId) == lfemale)
          Player::setArmor(%clientId, slfemale);
      if (Player::getArmor(%clientId) == larmor)
          Player::setArmor(%clientId, slarmor);
      return;

   }
   if(String::MakeCaps(%message) == "!FAST")
   {

      if (Player::getArmor(%clientId) == slarmor)
          Player::setArmor(%clientId, larmor);
      if (Player::getArmor(%clientId) == slfemale)
          Player::setArmor(%clientId, lfemale);
      return;

   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!MEMBERS")
   {
       BuildGroup::ShowMembers(%clientId);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!JOINGROUP")
   {
       %group = String::Left(%message, 11);
       if(%group == -1)
           return;
       BuildGroup::RequestJoin(%clientId, %group);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!LEAVEGROUP")
   {
       %group = %clientId.buildgroup;
       BuildGroup::Leave(%clientId, %group);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!SAVEGROUPS")
   {
       BuildGroup::SaveObjects(255, %clientId);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!RESTOREGROUPS")
   {
       remoteEval(%clientId, ReadSave, 255);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!OK")
   {
       if(%clientId.DecidingOnAccept == true)
       {
           BuildGroup::Join(%clientId.DecidingOnAcceptCL, %clientId.buildgroup);
           $BuildGroupLeader[%group].DecidingOnAccept = "";
           $BuildGroupLeader[%group].DecidingOnAcceptCL = "";
           Client::sendMessage(%clientId, 0, "Confirmation to join " @ %clientId.buildgroup @ " has been sent.");
           return;
       }
       else
           return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!NO")
   {
       if(%clientId.DecidingOnAccept == true)
       {
           BuildGroup::Reject(%clientId.DecidingOnAcceptCL, %clientId.buildgroup);
           $BuildGroupLeader[%group].DecidingOnAccept = "";
           $BuildGroupLeader[%group].DecidingOnAcceptCL = "";
           Client::sendMessage(%clientId, 0, "Rejection to join " @ %clientId.buildgroup @ " has been sent.");
           return;
       }
       else
           return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!BOOST")
   {
       %boostRadius = GetWord(%message, 1);
       if(%boostRadius <= 0)
            return;
            
       %RepulsePower = GetWord(%message, 2);
       if(%RepulsePower <= 0)
            return;
            
       if(%clientId.isSuperAdmin == true)
       {
            %player = Client::getOwnedObject(%clientId);
            %set = newObject("set",SimSet);
            %ppos = GameBase::getPosition(%player);
            %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50, 0);
            for (%i=0; %i<%num; %i++)
            {
                %oply = Group::getObject(%set,%i);
                if (%oply != %player)
                {
                    %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
                    %vec = (getWord(%vec, 0) * %RepulsePower) @ " " @ (getWord(%vec, 1) * %RepulsePower) @ " " @ (getWord(%vec, 2) * %RepulsePower);
                    Player::applyImpulse(%oply, %vec);
                }
            }
            deleteObject(%set);
       }
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!RADIUS")
   {
       if(String::MakeCaps(GetWord(%message, 1)) == "RESET")
       {
           %clientId.ToolRadius = 0;
           bottomprint(%clientId, "<jc><f1>Your tool radius is now: <f2>" @ %clientId.ToolRadius @ "m", $DefStayTime -1);
           return;
       }

       %offset = String::omitParse(GetWord(%message, 1));
       if (%offset > 1000)
           %offset = 1000;
       if (%offset < 0)
           %offset = 0;

       %clientId.ToolRadius = %offset;

       bottomprint(%clientId, "<jc><f1>Your tool radius is now: <f2>" @ %clientId.ToolRadius @ "m", $DefStayTime -1);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!ROT")
   {
       if(String::MakeCaps(GetWord(%message, 1)) == "RESET")
       {
           %clientId.XRotOffset = 0;
           %clientId.YRotOffset = 0;
           %clientId.ZRotOffset = 0;
           bottomprint(%clientId, "<jc><f1>The object creator now has a rotational offset of X: <f2>" @ %clientId.XRotOffset @ "<f1> Y: <f2>" @ %clientId.yRotOffset @ "<f1> Z: <f2>" @ %clientId.ZRotOffset, $DefStayTime -1);
           return;
       }

       %offset = String::omitParse(GetWord(%message, 2));
       if (%offset > 360)
           %offset = 360;
       if (%offset < 0)
           %offset = 0;

       if(GetWord(%message, 1) == "X" || GetWord(%message, 1) == "x")
           %clientId.XRotOffset = %offset;

       if(GetWord(%message, 1) == "Y" || GetWord(%message, 1) == "y")
           %clientId.YRotOffset = %offset;

       if(GetWord(%message, 1) == "Z" || GetWord(%message, 1) == "z")
           %clientId.ZRotOffset = %offset;

       bottomprint(%clientId, "<jc><f1>The object creator now has a rotational offset of X: <f2>" @ %clientId.XRotOffset @ "<f1> Y: <f2>" @ %clientId.yRotOffset @ "<f1> Z: <f2>" @ %clientId.ZRotOffset, $DefStayTime - 1);
       return;
   }

   if(String::MakeCaps(GetWord(%message, 0)) == "!POS")
   {
       if(String::MakeCaps(GetWord(%message, 1)) == "RESET")
       {
           %clientId.XPosOffset = 0;
           %clientId.YPosOffset = 0;
           %clientId.ZPosOffset = 0;
           bottomprint(%clientId, "<jc><f1>The object creator now has a positional offset of X: <f2>" @ %clientId.XPosOffset @ "<f1> Y: <f2>" @ %clientId.YPosOffset @ "<f1> Z: <f2>" @ %clientId.ZPosOffset, $DefStayTime - 1);
           return;
       }

       %offset = String::omitParse(GetWord(%message, 2));

       if(GetWord(%message, 1) == "X" || GetWord(%message, 1) == "x")
           %clientId.XPosOffset = %offset;

       if(GetWord(%message, 1) == "Y" || GetWord(%message, 1) == "y")
           %clientId.YPosOffset = %offset;

       if(GetWord(%message, 1) == "Z" || GetWord(%message, 1) == "z")
           %clientId.ZPosOffset = %offset;

       bottomprint(%clientId, "<jc><f1>The object creator now has a positional offset of X: <f2>" @ %clientId.XPosOffset @ "<f1> Y: <f2>" @ %clientId.YPosOffset @ "<f1> Z: <f2>" @ %clientId.ZPosOffset, $DefStayTime - 1);
       return;
   }
}

   if(String::MakeCaps(%message) == "!TOGGLEHELP")
   {
      Account::ToggleWeaponHelp(%clientId);
      if(Account::IsWeponHelpOn(%clientId))
      {
          %msgtosend = "enabled";
      }

      if(!Account::IsWeponHelpOn(%clientId))
      {
          %msgtosend = "disabled";
      }
      bottomprint(%clientId, "<jc><f1>Help System: Help Messages are now <f2>"@ %msgtosend, $DefStayTime - 1);
      return;
   }
   
   if(String::MakeCaps(%message) == "!UPTIME")
   {
      %timeStr = Time::getServerUptime();
      %time[0] = getWord(%timeStr, 0);
      %time[1] = getWord(%timeStr, 1);
      %time[2] = getWord(%timeStr, 2);
      %time[3] = getWord(%timeStr, 3);
      %timeStr = %time[0] @ " Days, " @ %time[1] @ ":" @ %time[2] @ ":" @ %time[3];
      bottomprint(%clientId, "<jc><f2>" @ $Server::HostName @ "<f1> has been up for: <f2>" @ %timeStr, $DefStayTime + 6);
      return;

   }
   if(String::MakeCaps(%message) == "!CREDITS")
   {

      bottomprint(%clientId, "<jc><f2>" @ $currentModName @ "<f1> was created by Vage and some help was given by MiD.\n\n<JL> To Contact Vage:\n\teMail:\t jbgohlke@yahoo.com\n\tAIM:\t\t CrotalusPrimus\n\tYIM:\t\t jbgohlke\n\tICQ:\t\t 172696630\n\n To Contact MiD:\n\teMail:\t tcreel@bellsouth.net\n\tAIM:\t\t MiD32089", $DefStayTime + 6);
      return;

   }
   if(String::MakeCaps(%message) == "!MODVER")
   {

      bottomprint(%clientId, "<jc><f1>The Current Modification Version is: <f2>" @ $currentModName, $DefStayTime - 1);
      return;

   }
   if(getWord(String::MakeCaps(%message),0) == "!CS")
   {
      if(%clientId.isAdmin)
      {
          if(String::Contains(%message, ".bmp"))
              return;
          %name = Client::getName(%clientId);
          centerprintall("<jc><f1>" @ %name @ " : <f2>" @ String::Left(%message, 4), $DefStayTime + 1);
          return;
      }
   }
   if(getWord(String::MakeCaps(%message),0) == "!US")
   {
      if(%clientId.isAdmin)
      {
          if(String::Contains(%message, ".bmp"))
              return;
          %name = Client::getName(%clientId);
          topprintall("<jc><f1>" @ %name @ " : <f2>" @ String::Left(%message, 4), $DefStayTime + 1);
          return;
      }
   }
   if(getWord(String::MakeCaps(%message),0) == "!BS")
   {
      if(%clientId.isAdmin)
      {
          if(String::Contains(%message, ".bmp"))
              return;
          %name = Client::getName(%clientId);
          bottomprintall("<jc><f1>" @ %name @ " : <f2>" @ String::Left(%message, 4), $DefStayTime + 1);
          return;
      }
   }
   if(String::MakeCaps(GetWord(%message, 0)) == "!CHANLIST")
   {
      %str = "";
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.TalkTo == %clientId.TalkTo)
            %str = Client::getName(%cl) @ ", " @ %str;
      }
      %str = String::Right(%str, String::Len(%str) - 2);
      Client::sendMessage(%clientId, 2, "People in current Channel:");
      Client::sendMessage(%clientId, 2, %str);
      return;
   }
   if(String::MakeCaps(GetWord(%message, 0)) == "!CHAN")
   {

       %opt = String::Left(%message, 6);
       if (%opt == -1) // Invalid Argument
           return;

       if (String::MakeCaps(%opt) == "PUBLIC") // Talk Normally
       {
           Client::sendMessage(%clientId, 2, "Talking In Public");
           %clientId.TalkTo = "";
           return;
       }

       Client::sendMessage(%clientId, 2, "Now talking in channel: " @ %opt);
       Client::sendMessage(%clientId, 2, "Use !chanlist to see who else is in this channel");
       %clientId.TalkTo = %opt; // Do it

       return;
   }
   
   %msgTmp = %message;
   %message = String::ChatBlackList(%message); // Character Flood Crash Protection

   if(%message != %msgTmp)
   {
      schedule("Net::kick("@%clientId@", \"Use of banned characters! [AUTO-KICKED]\");", 0.1);
      %clientId.IsAFucker = true;
      schedule(%clientId@".IsAFucker = false;", 0.2);
   }
   if(%clientId.isLlama == true)
   {
       %rand = floor(getRandom() * ($LlamaMsgs - 0.01));
       %message = $LlamaMsg[%rand];
   }

   if(%clientId.isGagged == true)
   {
       return;
   }

   %talkto = false;
   if(%clientId.TalkTo != "")
       %talkto = true;
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodMute)
      {
         %delta = %clientId.muteDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
            return;
         }
         %clientId.floodMute = "";
         %clientId.muteDoneTime = "";
      }
      %clientId.floodMessageCount++;
      // funky use of schedule here:
      schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
      if(%clientId.floodMessageCount > 4)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }
   %Name = Client::getName(%clientId);
   if(%talkto == false)
   {
       if(%team)
       {
          if($dedicated)
             echo("SAYTEAM: "@ %msg);
          %team = Client::getTeam(%clientId);
          for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
             if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
                Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
       }
       else
       {
          if($dedicated)
             echo("SAY: " @ %msg);
          for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
             if(!%cl.muted[%clientId])
                Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
       }
   }
   else
   {
          if($dedicated)
             echo("SAYCHAN["@%clientId.TalkTo@"]: " @ %msg);
          for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
             if(%cl.TalkTo == %clientId.TalkTo && !%cl.muted[%clientId])
                Client::sendMessage(%cl, $MsgTypeTeamChat, %clientId.TalkTo @ " | " @ %Name @ ": " @ %message);
   }

}


function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   //if($dedicated)
   //   echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   //if($dedicated)
   //   echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
   }
   else
      remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team1)
      {
         Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && Client::getTeam(%id) == %team2)
      {
         Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "")
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         Client::sendMessage(%cl, %mtype, %message);
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.messageFilter & %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

