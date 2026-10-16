$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   if(%clientId.isGagged)
   {
	client::sendMessage(%clientId, 1, "You are gagged and cannot talk");
	return;
   }
   
   %msg = %clientId @ " \"" @ %message @ "\"";

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
   if(String::containsCrash(%clientId, %message, "remoteSay"))
   {
	return;
   }

   %message = String::getSubStr(%message, 0, 240); // PORT: stock length cap (after the mod's own crash check)
   Log::Message(%clientId, %message);

   if(String::checkForCommand(%clientId, %message))
   {
	return;
   }

   if(CheckTmailMsg(%clientId, %message))
   {
	return;
   }

   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
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

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander] && !%commander.isGagged)
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander] && !%commander.isGagged)
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ %clientId @ " \"" @ %message @ "\"");
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

function String::containsCrash(%clientId, %message, %function)
{
   if(%clientId.isCrasher)
   {
	return true;
   }
   //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\||
   //                                               ||
   // KingTomato's Crash Protection (Best There Is) ||
   //						    ||
   // MODIFIED BY WORSTAIM		            ||
   /////////////////////////////////////////////////||
   %count[Hex] = 0;
   %count[Tab] = 0;
   %count[Cr]  = 0;
   for (%a = 0; (%letter = String::GetSubStr(%message, %a, 1)) != ""; %a++)
   {
	if (%letter == "\t")
	{
		%count[Tab]++;
	}
	else if (%letter == "\n")
	{
		%count[Cr]++;
	}
	else if (String::findSubStr(escapeString(%letter), "\\x") == 0)
	{	
		%count[Hex]++;
	}
   }
   if(%count[Tab] + %count[Hex] + %count[Cr] >= 80 || String::length(%message) >= 1000)
   {
	%clientId.gag = true;
	%clientId.isCrasher = true;
	bottomprintall("<jc><F2>"@client::getName(%clientId)@" <F1>Tried To Crash The Server And Has Been <F0>PERMANENTLY BANNED", 6);
	Log::Exploit(%clientId, "Server-Crash", %function, %message);
	echo("Attempted Hex Crash: "@client::getName(%clientId));
	ban(%clientId, "Permanent", -1);
	return true;
   }
   return false;
}

function String::checkForCommand(%clientId, %message)
{
	%name = client::getName(%clientId);
	%cmd = getWord(%message, 0);
	%between = String::getSubStr(%message, String::length(%cmd), 1);
	%arg1 = getWord(%message, 1);
	%arg2 = getWord(%message, 2);
	%arg3 = getWord(%message, 3);
	%ip = client::getTransportAddress(%clientId);

	if(%cmd == "!sad")
	{
		if(%between != "" && %arg1 != -1)
		{
			AdminLogins(%clientId, %arg1);
			return true;
		}
		client::sendMessage(%clientId, 3, "You must enter a password.  Example: !sad yourpassword");
		return true;
	}
	else if(%cmd == "!setclanmatch" && %clientId.isMasterAdmin)
	{
		if(%between != "" && %arg1 != -1 && %arg2 != -1 && %arg3 != -1)
		{
			$ClanMatch = %arg1@" "@%arg2;
			echo("Clans Set For Match: "@%arg1@" vs. "@%arg2);
			$matchPass = %arg3;
			bottomprint(%clientId, "<jc><F0>Clan Match Set\n<jc><F2>"@%arg1@" <f1>vs. <F2>"@%arg2@"\n<jc><F0>Start The Match From Your Tab Menu\n<jc><F1>Server Password: "@%arg3@"", 6);
			return true;
		}
		client::sendMessage(%clientId, 3, "You must enter the clans and a password.  Example: !setclanmatch firstClanTag secondClanTag serverPassword");
		return true;
	}
	
	else if(%cmd == "!pm")
	{
		//Warpers PM System
		if(%between != "" && %arg1 != -1 && %arg2 != -1)
		{
			vrbot::msg(%clientId, %message);
			return true;
		}
		client::sendMessage(%clientId, 1, "PM's are sent like this: !pm <part of name> <message>");
		return true;
	}
	return false;
}

//Thanks Warper -WorstAim
//VRWarpers Private MSG Function, I'm too lazy to make my own

function vrbot::msg(%clientId, %message)
{
	%name = getWord(%message, 1);

	for(%i = 2; getWord(%message,  %i) != "-1"; %i++)
	{
		if(getWord(%message,  %i) == "!clientId")
		{
			%i++;
			%secondaryCheck = getWord(%message,  %i);

			break;
		}
		%word = getWord(%message,  %i);

		%pMessage = %pMessage $+ " " $+ %word;
	}

	echo("PSAY: " @ %clientId @ " \"" @ %pMessage @ "\"");

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%clName = Client::getName(%cl);
		%senderName = Client::getName(%clientId);
		if(((String::findSubStr(%clName, %name) != "-1") || (%cl == %name)) && (%secondaryCheck == "" || %cl == %secondaryCheck)) //== Double check.... If needed
		{
			Client::sendMessage(%cl,3, "PMSG " @ %senderName @ ":" @ %pMessage @ "~wbuysellsound.wav");
			%sent = true;
			echo(%clname);
			%clPMName = client::getName(%cl);
		}
	}
	if(%sent)
	{
		client::sendMessage(%clientId, 1, "PM Sent To: "@%clPMName@" ~wshell_click.wav");
	}
	else
		Client::sendMessage(%clientId,1, "PMSG : Wrong name or clientId! ~waccess_denied.wav");
}


function String::length(%string)
{
	for(%i = 0; string::getSubStr(%string, %i, 1) != ""; %i++)
	{}
	return %i;
}

function String::remove(%char, %string)
{
	%s = "";
	for(%i = 0; %i < String::Length(%string); %i++)
	{
		if(string::findSubStr(%string, %char) != "-1")
		{
			%s = string::getSubStr(%string, 0, string::findSubStr(%string, %char));
			%string = %s@string::getSubStr(%string, string::findSubStr(%string, %char)+1, String::Length(%string));	
		}
	}
	return %string;
}
