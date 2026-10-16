//Comchat modified for the Tribes Football mod - GSL ladder version 1.2
//Available from the Tribes Football files archive; http://amishrabbit.com/tribes/files/
//Increased chat flood amount to 5
//Football specific commands parseable in chat: 
//#where | #revert | #kill <playername> | #setteam <playername> <team> | #deletefootball
//modified 30 May 2002 by Spike
$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

$MsgWhite = 0;
$MsgRed = 1;
$MsgBeige = 2;
$MsgGreen = 3;

function remoteSay(%clientId, %team, %message)
{

	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

	// check for flooding if it's a broadcast OR if it's team in FFA
	if(!$GlobalMute[%clientId] && $Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
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
		if(%clientId.floodMessageCount > 5)
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}

	if(String::getSubStr(%message, 0, 1) == "#")
	{
		%w1 = GetWord(%message, 0);

		%cropped = String::getSubStr(%message, (String::len(%w1)+1), String::len(%message)-(String::len(%w1)+1));

		if(%w1 == "#where")
		{
			WhereIsFootball(%clientId);
		}
		if(%w1 == "#revert")
		{
			if(%clientId.isSuperAdmin)
			{
				Client::setControlObject(%clientId.possessId, %clientId.possessId);
				Client::setControlObject(%clientId, %clientId);
			}
		}
		if(%w1 == "#kill")
		{
			if(%clientId.isSuperAdmin)
			{
				if(%cropped != -1)
				{
					%id = NEWgetClientByName(%cropped);
	
					if(%id != -1)
					{
						playNextAnim(%id);
						Player::Kill(%id);
						Client::sendMessage(%clientId, 0, %cropped @ " (" @ %id @ ") was executed.");
					}
					else
						Client::sendMessage(%clientId, 0, "Invalid player name.");
				}
				else
					Client::sendMessage(%clientId, 0, "Please specify player name.");
			}
		}
		if(%w1 == "#setteam")
		{
			if(%clientId.isAdmin)
			{
				%c1 = GetWord(%cropped, 0);
				%c2 = GetWord(%cropped, 1);

				if(%c1 != -1 && %c2 != -1)
				{
					%id = NEWgetClientByName(%c1);

					if(%id != -1)
					{
						GameBase::setTeam(%id, %c2);
						Game::refreshClientScore(%id);
						Client::sendMessage(%clientId, 0, "Setting " @ %c1 @ " (" @ %id @ ") team to " @ GameBase::getTeam(%id) @ ".");
					}
					else
						Client::sendMessage(%clientId, 0, "Invalid player name.");
				}
				else
					Client::sendMessage(%clientId, 0, "Please specify player name & data.");
			}
		}
		if(%w1 == "#deletefootball")
		{
			if(%clientId.isAdmin)
			{
				if($CurrentFootball != "")
				{
					%team = GameBase::getTeam($CurrentFootball.owner);
					deleteObject($CurrentFootball);
					$CurrentFootball = "";
				}
				else
				{
					for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					{
						if(Player::getItemCount(%cl, Football))
						{
							LoseFootball(%cl);
							%team = GameBase::getTeam(%cl);
						}
					}
				}
				$footballExists = "";
				Client::sendMessage(%clientId, 0, "Football deleted.");
				DoSpawnFootball(%team);
				SendPlayersToStart();
			}
		}
	}
	else
	{
	 if(!$GlobalMute[%clientId]) {
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
	else
	Client::sendMessage(%clientId, 1, "You are currently silenced");
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

