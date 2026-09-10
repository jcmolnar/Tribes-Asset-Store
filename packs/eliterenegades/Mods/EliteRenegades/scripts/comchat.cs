$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message) 
{
	// ELITE RENEGADES PORT (R4): base clamps inbound chat to 240 chars here
	// (see base scripts comchat.cs line 10). This 1999 fork predates that guard,
	// and every path below -- public, team and private -- flows through this function.
	%message = string::getSubStr(%message, 0, 240);
	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
	if(%clientId.isbeingkicked) 
	{
		Client::sendMessage(%clientId, 1, "There is NO TALKING while you are being kicked out of here~waccess_denied.wav");
		return;
	}
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)) 
	{
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
		schedule(%clientId @ ".floodMessageCount--; ", 5, %clientId);
		if(%clientId.shut) 
		{
			Client::sendMessage(%clientId, 1, "You can't talk without a tongue you moron.~waccess_denied.wav");
			return;
		}
		if(%clientId.floodMessageCount > 4 && !%clientId.isSuperAdmin) 
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}
	if(%clientId.pmess > 0) 
	{
		if(%clientId != %clientId.pmess)
			Client::sendMessage(%clientId, 1, "(Message to " @ Client::getName(%clientId.pmess) @ ") " @ %message);
			Client::sendMessage(%clientId.pmess, 1, "(Message from " @ Client::getName(%clientId) @ ") " @ %message);
			echo("SAY: private from " @ Client::getName(%clientId) @ " to " @ Client::getName(%clientId.pmess) @ " " @ %message);
			%clientId.pmess = -1;
			return;
	}
	if(%team) 
	{
		if($dedicated) 
		{
			if($ConOutput != 1)
				echo("SAYTEAM: " @ Client::getName(%clientId) @ " >> " @ %msg);
			else
				echo("SAYTEAM: " @ %msg);
		}
		%team = Client::getTeam(%clientId);
		for(%cl = Client::getFirst();
		%cl != -1;
		%cl = Client::getNext(%cl))
		if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
			Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
	}
	else 
	{
		if($dedicated) 
		{
			if($ConOutput != 1)
				echo("SAY:     " @ Client::getName(%clientId) @ " >> " @ %msg);
			else
				echo("SAY: " @ %msg);
		}
		for(%cl = Client::getFirst();
		%cl != -1;
		%cl = Client::getNext(%cl))
		if(!%cl.muted[%clientId])
		Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14) 
{
	if($dedicated) 
	{
		if($ConOutput != 3)
			echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	}
	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	if(!%dest[%i].muted[%commander])
		issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14) 
{
	if($dedicated) 
	{
		if($ConOutput != 3)
			echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	}
	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	if(!%dest[%i].muted[%commander])
		issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message) 
{
	if(setCommandStatus(%clientId, %status, %message)) 
	{
		if($dedicated) 
		{
			if($ConOutput != 3)
				echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
		}
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
		for(%cl = Client::getFirst();
		%cl != -1;
		%cl = Client::getNext(%cl))
		Client::sendMessage(%cl, %mtype, %message);
	else 
	{
		for(%cl = Client::getFirst();
			%cl != -1;
			%cl = Client::getNext(%cl)) 
		{
		if(%cl.messageFilter & %filter)
			Client::sendMessage(%cl, %mtype, %message);
		}
	}
}

function messageAllExcept(%except, %mtype, %message) 
{
	for(%cl = Client::getFirst();
	%cl != -1;
	%cl = Client::getNext(%cl))
	if(%cl != %except)
		Client::sendMessage(%cl, %mtype, %message);
}
 