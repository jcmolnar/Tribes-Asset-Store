$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   %bug = %message;
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

	if(%clientId.gag) 
	{
		Client::sendMessage(%clientId, 1, "You are gagged.~waccess_denied.wav");
		return;
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
      	if(!%dest[%i].muted[%commander])
      	{
      		issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
        	//echo("Dest: " @ %dest[%i]);
      		%waypoint= %WayX @ " " @ %WayY;   
        	//Client::sendMessage(%dest[%i],1,"Dest: " @ %dest[%i] @ " " @ %i);
        	%commandee = %dest[%i];
        	$point[%commandee] = %waypoint;
        	//Client::sendMessage(%dest[%i],1,"Waypoint: " @ $point[%commandee]);
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

function NearBug(%clientId, %message)
{
	%player = Client::getTeam(%clientId);
	%pos = GameBase::getPosition(%clientId);
	%set = newObject("set",SimSet);
	%mask = $StaticObjectType;
	%num = containerBoxFillSet(%set,%mask,%pos,200,200,200,0);
	%num = CountObjects(%set,"DeployableBug",%num);

		if(%num > 0)
		{
			for(%count = 0; %index != -1; %count++)
		{
			%index = Group::getObject(%set, %count);
			if(%index != -1)
		 	{
				%name = GameBase::getDataName(%index);
				%team = GameBase::getTeam(%index);
				if(%name == "DeployableBug")
				{
					if(%team != %player)
					{
						for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					      if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
				            Client::sendMessage(%cl,1,"Enemy Trans: "@ %message);
					}
				}
			}
		}
	}
	deleteObject(%set);
}
