$MsgTypeSystem = 0;	//-White
$MsgTypeGame = 1;	//-Red
$MsgTypeChat = 2;	//-Yellow/Tan
$MsgTypeTeamChat = 3;	//-Green
$MsgTypeCommand = 4;	//-Yellow/Tan

function remoteSay(%clientId, %team, %message)
{
	%IP = Client::getTransportAddress(%clientId);
	%player = Client::getOwnedObject(%clientId);
	%Teamname = $Server::teamAbrv[Gamebase::getTeam(%clientId)];
	if(%clientId.observerMode == "dead")
		%Teamname = $Server::teamAbrv[-1];
	//%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
	%name = Client::getName(%clientId);
	if($A = 1)
		echo(%name@": "@%IP);
	%msg =  "C:" @ %clientId @ " N:" @ %teamname @ "- " @ %name @ " \"" @ escapeString(%message) @ "\"";
	// check for flooding if it's a broadcast OR if it's team in FFA
	if(%clientId.isAdmin && %message == $Server::SIName@": unflood me" && %team) { // PORT: admins only
		%clientId.floodMute = "";
		return;
	}
	if(%player.drunk > 0 || $ServerKegger) {
		if(getword(%message,0) == $Server::SIName@":" && TypoCheck(getword(%message,1)) == "kegger")
			%message = "Server: kegger parties are great and all but we're too wasted for this...";
		else
			%message = DrunkSpeech(%message,%clientId);
	}
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)) {
		// we use getIntTime here because getSimTime gets reset.
		// time is measured in 32 ms chunks... so approx 32 to the sec
		%time = getIntegerTime(true) >> 5;
		if(%clientId.floodMute) {
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0) {
				Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				%clientId.serverAffection += $SIAffection::Spamer;
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;
		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
		if(%clientId.floodMessageCount > 4) {
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			%clientId.serverAffection += $SIAffection::Spamer;
			return;
		}
	}
	if(%team) {
		if($dedicated)
			echo("SAYTEAM: " @ %msg);
		%team = Client::getTeam(%clientId);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
			//Client::sendMessage(%cl, $MsgTypeTeamChat, "["@%teamname@"]"@ "- " @%name@": "@%message);//, %clientId);
			Client::sendMessage(%cl, $MsgTypeTeamChat, "[" @%teamname@ "]: " @%message, %clientId);
			//Client::sendMessage(%cl, $MsgTypeTeamChat, %teamname@ ": " @%message, %clientId);
	}
	else {
		if($dedicated)
			echo("SAY: " @ %msg);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(!%cl.muted[%clientId])
			//Client::sendMessage(%cl, $MsgTypeChat, "["@%teamname@"]"@ "- " @%name@": "@%message);//, %clientId);
			Client::sendMessage(%cl, $MsgTypeChat, "[" @%teamname@ "]: " @%message, %clientId);
			//Client::sendMessage(%cl, $MsgTypeChat, %teamname@ ": " @%message, %clientId);
	}
	SIScanText(%clientId,%message,%team);
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
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
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
	for(%i = 0; %i < %numPlayers; %i = %i + 1) {
		%id = getClientByIndex(%i);
		if(Client::getTeam(%id) == %team1)
			Client::sendMessage(%id, %mtype, %message1);
		else if(%message2 != "" && Client::getTeam(%id) == %team2)
			Client::sendMessage(%id, %mtype, %message2);
		else if(%message3 != "")
			Client::sendMessage(%id, %mtype, %message3);
	}
}

function messageAll(%mtype, %message, %filter)
{
	if(%filter == "")
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Client::sendMessage(%cl, %mtype, %message);
	else {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
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

function messageTeam(%client,%mtype, %message, %filter)
{
	if(%filter == "")
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(getTeam(%client,%cl) == Same)
				Client::sendMessage(%cl, %mtype, %message);
	else {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if(%cl.messageFilter & %filter && getTeam(%except,%cl) == Same)
				Client::sendMessage(%cl, %mtype, %message);
		}
	}
}

function messageTeamExcept(%except, %mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(getTeam(%except,%cl) == Same && %cl != %except)
			Client::sendMessage(%cl, %mtype, %message);
}
