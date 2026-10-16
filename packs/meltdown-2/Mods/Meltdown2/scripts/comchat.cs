$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
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

	if(string::getsubstr(%message, 0, 1) == "=" && string::getsubstr(%message, 2, 1) != "") {
		%message = string::getsubstr(%message, 1, 999);
		if(string::getsubstr(%message, 0, 1) == "!" && %clientId.isSuperAdmin) {
			%message = string::getsubstr(%message, 1, 999);
			centerprintall("<jc><f2>"@%message, 7);
			return;
		}
		if(%clientId.speakto != "") {
			if(%clientId.isSuperAdmin) {
				if(string::getsubstr(%message, 0, 1) == "=" && %clientId.isSuperAdmin) {
					%message = string::getsubstr(%message, 1, 999);
					centerprint(%clientId.speakto, "<jc><f0>"@Client::getName(%clientID)@" (private):\n<f1>"@%message, 8);
				}
				Client::sendMessage(%clientId.speakto, $MsgTypeChat, Client::getName(%clientID)@" (private): "@%message);
				Client::sendMessage(%clientId, $MsgTypeChat, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
			} else if((Client::getTeam(%clientId) != -1 || $Game::missionType == "Duel") && !(%clientId.speakto).muted[%clientId]) {
				if(!(%clientId.speakto).isSuperAdmin && Client::getTeam(%clientId) != Client::getTeam(%clientId.speakto))
					cheatAdminMsg(Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
				if(!(%clientId.speakto).isSuperAdmin && $listen[%clientId] != "")
					Client::sendMessage($listen[%clientId], 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
				Client::sendMessage(%clientId.speakto, $MsgTypeChat, Client::getName(%clientID)@" (private): "@%message);
				Client::sendMessage(%clientId, $MsgTypeChat, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message);
			}
			%message = escapeString(%message);
			echo("SAY: " @ %clientId @ " \""@Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message@"\"");
			return;
		}
	}
   if(%team)
   {
		%player = Client::getOwnedObject(%clientId);

		if(string::getsubstr(%message, 1, 3) == "AFK" || string::getsubstr(%message, 1, 3) == "afk") 
		{
			if(!$isAFK)
			{
				$isAFK = true;
				%name = Client::getName(%clientId);
				messageAll(0, "Player "@%name@" is AFK.");
				Client::sendMessage(%clientId,2,"To return from AFK, type in #return in teamchat mode.");
				doAFK(%player,%name);
				return;
			}
			else
			{
				Client::sendMessage(%clientId,0,"You're already AFK...");
				return;
			}
		}
		else if(string::getsubstr(%message, 1, 6) == "return" || string::getsubstr(%message, 1, 6) == "RETURN") 
		{
			if($isAFK)
			{
				$isAFK = false;
				%name = Client::getName(%clientId);
				messageAll(0, "Player "@%name@" is back in the game.");
				returnAFK(%player,%name);
				return;
			}
			else
			{
				Client::sendMessage(%clientId,0,"You're not AFK...");
				break;
			}
		}
		//PORT-OFF: return;  stray line left by the AFK code: every team chat message stopped here and was never sent

      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
	NearBug(%clientId, %bug);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
    		   Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
	   else if(Player::getMountedItem(%cl, $BackpackSlot) == BugPack){ Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId);}
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
      	echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   	// issueCommand takes float mission coords.
   	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
      	if(!%dest[%i].muted[%commander])
      	{
      		issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
      	  	$waypoint = %wayX@" "@%wayY;
      	}
	}
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
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

function doAFK(%player,%name)
{
	%player.respawning = true;
	%player.isAFK = true;
	%client = Player::getClient(%player);
	%camera = Client::getObserverCamera(%client);
	%flag = Player::getMountedItem(%player,$FlagSlot);

	Client::setControlObject(%client, %camera);
	Observer::setOrbitObject(%client, %client, 3, 3, 3);

	if(%flag)
		Player::DropItem(%player,%flag);
}

function returnAFK(%player,%name)
{
	%client = Player::getClient(%player);
	%player.respawning = false;
	%player.isAFK = false;

	Client::setControlObject(%client, %player);
}

