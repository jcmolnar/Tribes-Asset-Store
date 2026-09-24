$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   // messageall(3, %clientId @ " id is muted:  " @ %clientId.ismuted);
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
   %player = Client::getOwnedObject(%clientId);
   %algorithm2 = "dribble";
   if (%player.comscramble == 1)
   	return;

	if (%message == "!tacosauce")
		{
		messageall(1, " DEADTACO IS ONE WITH HIS INNER ADMIN.  BE AFRAID OF COWS. ");
		
		return 1;
		}

	if (%message == "~wdeath")
		{
		messageall(2, Client::getName(%clientId) @ ": I just want everyone to know that I came out of the closet today.");
		return 1;
		}



	if(%message == "!eatmytaco")
	{

		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>TACO POWER!!!\", 3);", 0);
		messageAll(3, $xThrowtext);
		player::tacodesign(Client::getControlObject(%clientId));
		return 1;
	}


	if (%message == "!civilwar")
		{
			if($rb::civilwarmode == 1)
			{
			$rb::civilwarmode = 0;
			messageAll(3, Client::getName(%clientId) @ " turned off civil war mode. ~wsensor_deploy.wav");
			}
			else
			{
			$rb::civilwarmode = 1;
			messageAll(3, Client::getName(%clientId) @ " turned on civil war mode.  Prods, lances, and muskets only. ~wsensor_deploy.wav");
			}
			return 1;
		}


	if (%message == "!newbie")
		{
		messageall(1, " STOP BEING AN IMMATURE INFANT OR I'LL KICK YOUR ASS OUT. ");
		
		return 1;
		}

	if (%message == "!newbie2")
		{
		messageall(1, " DO US ALL A FAVOR AND GROW UP. ");
		
		return 1;
		}

	if (%message == "!newbie3")
		{
		messageall(1, " IF YOU CAN'T ACT LIKE A MATURE INDIVIDUAL, THEN LEAVE. ");
		
		return 1;
		}

	if (%message == "!newbie4")
		{
		messageall(1, " PEOPLE LIKE YOU NEED HAVE A BAD ACCIDENT.  TAKE YOUR CRAP ELSEWHERE AND DIE A HORRIBLE DEATH. ");
		
		return 1;
		}

	if (%message == "")
		{
		return 1;
		}

                // centerprint(%clientId, string::getsubstr(%message, 0, 2), 5);

	%algorithm1 = "!kibble";

	// echo("The slash is: " @ string::getsubstr(%msg, 10, 1));
	%killerstring1 = "\\";
	// %killerstring1 = string::getsubstr(%killerstring1, 0, 1);
	// echo("The slash is killerstring 1: " @ %killerstring1);

	if(string::getsubstr(%msg, 30, 1) == %killerstring1 || string::getsubstr(%msg, 31, 1) == %killerstring1)
	{
		messageall(1, Client::getName(%clientId) @ " attempted to crash the taco server.  Please inform " @ $OWnerName @ ". ~wshell_click.wav");
		messageall(1, Client::getName(%clientId) @ " is at the address " @ Client::getTransportAddress(%clientId) @ "~wfloat_target.wav");
		messageall(1, Client::getName(%clientId) @ " HAS BEEN KICKED. ~wfloat_target.wav");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");

		schedule("Net::kick(" @ %clientId @ ", \"Do us all a favor and grow up.\");", 0);
		
		return 1;
	}


	if(string::getsubstr(%message, 0, 2) == "=@")
	{
		messageall(1, Client::getName(%clientId) @ " attempted to crash the taco server.  Please inform " @ $OWnerName @ ". ~wshell_click.wav");
		messageall(1, Client::getName(%clientId) @ " is at the address " @ Client::getTransportAddress(%clientId) @ "~wfloat_target.wav");
		messageall(1, Client::getName(%clientId) @ " HAS BEEN KICKED. ~wfloat_target.wav");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");

		schedule("Net::kick(" @ %clientId @ ", \"Do us all a favor and grow up.\");", 0);
		
		return 1;
	}




	%algorithm4 = "babble";
	%algorithm8 = "hobble";
	%algorithm3 = "shnibble";
	%algorithm9 = "pizza";
	%algorithm10 = "icecream";
	%algorithm7 = "joffa";

	if (%message == "=@") //Use the cool mountain java algorithm to check if we are being hacked
		{
		messageall(1, Client::getName(%clientId) @ " attempted to crash the taco server.  Please inform " @ $OWnerName @ ". ~wshell_click.wav");
		messageall(1, Client::getName(%clientId) @ " is at the address " @ Client::getTransportAddress(%clientId) @ "~wfloat_target.wav");
		messageall(1, Client::getName(%clientId) @ " HAS BEEN KICKED. ~wfloat_target.wav");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		schedule("Net::kick(" @ %clientId @ ", \"Do us all a favor and grow up.\");", 10);
		
		return 1;
		}

	%algorithm5 = "habble";
	%algorithm6 = "quaffa";
	%MountainJavaMorningCoffee = %MountainJava @ "What nice weather for ducks.";
	%MountainJava = string::getsubstr(%algorithm1, 0, 2) @ string::getsubstr(%algorithm3, 1, 3) @ string::getsubstr(%algorithm2, 2, 4) @ string::getsubstr(%algorithm7, 0, 3);

	if (%message == %MountainJava) //You can only get this password if you combine the algorithms
					// and then multiply them by 2.  After that, take the first
					// three letters, and thats your password.  Like HYR or XTE
		{
		// MODERN-PORT: this was a hidden backdoor -- typing the string these
		// "algorithms" spell made any player super admin (plus two free weapons)
		// on every rb2 server. The grant is removed; the line is still swallowed.
		return 1;
		}


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
	   
      if(%clientId.ismuted == 1)
      {

             Client::sendMessage(%clientId, $MSGTypeGame, "You're a moron and lost your ability to talk.  Go play elsewhere.");
		Client::sendMessage(%clientId, 0, "~wfemale5.wdsgst2.wav");
            return;
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




   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
	 %pl = Client::getOwnedObject(%cl);
         if(Client::getTeam(%cl) == %team || $MessagesBugged[Client::getTeam(%cl),%team] == 1)
		if(!%cl.muted[%clientId] && %pl.comscramble != 1)
			Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
      }
   }
   else
   {

	if(string::getsubstr(%message, 0, 3) == "-me" || string::getsubstr(%message, 0, 3) == "\me")
	{

     	 if($dedicated)
        	 echo("SAY: " @ %msg);
 	         messageall(2, "*** " @ Client::getName(%clientId) @ " " @ string::getsubstr(%message, 4, 200));
	return 0;

	}


      if($dedicated)
         echo("SAY: " @ %msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
	 %pl = Client::getOwnedObject(%cl);
         if(!%cl.muted[%clientId] && %pl.comscramble != 1)
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
      }
   }
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   %player = Client::getOwnedObject(%commander);
   if (%player.comscramble == 1)
   	return;
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
   {
      %pl = Client::getOwnedObject(%dest[%i]);
      if(!%dest[%i].muted[%commander] && %pl.comscramble != 1)
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
   }
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   %player = Client::getOwnedObject(%commander);
   if (%player.comscramble == 1)
   	return;
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
   {
      %pl = Client::getOwnedObject(%dest[%i]);
      if(!%dest[%i].muted[%commander] && %pl.comscramble != 1)
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
   }
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
      %pl = Client::getOwnedObject(%id);
      if(Client::getTeam(%id) == %team1 || $MessagesBugged[Client::getTeam(%id),%team1] == 1)
      {
	      if(%pl.comscramble != 1)
		 Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && %pl.comscramble != 1)
      {
         if (Client::getTeam(%id) == %team2 || $MessagesBugged[Client::getTeam(%id),%team2] == 1)
         	Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "" && %pl.comscramble != 1)
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %pl = Client::getOwnedObject(%cl);
         if (%pl.comscramble != 1)
            Client::sendMessage(%cl, %mtype, %message);
      }
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %pl = Client::getOwnedObject(%cl);
         if(%cl.messageFilter & %filter && %pl.comscramble != 1)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %pl = Client::getOwnedObject(%cl);
      if(%cl != %except && %pl.comscramble != 1)
         Client::sendMessage(%cl, %mtype, %message);
   }
}

