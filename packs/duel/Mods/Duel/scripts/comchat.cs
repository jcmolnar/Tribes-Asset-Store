$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function String::len(%string)
{
	%chunk = 10;
	%length = 0;

	for(%i = 0; String::getSubStr(%string, %i, 1) != ""; %i += %chunk)
		%length += %chunk;
	%length -= %chunk;

	%checkstr = String::getSubStr(%string, %length, 99999);
	for(%k = 0; String::getSubStr(%checkstr, %k, 1) != ""; %k++)
		%length++;

	if(%length == -%chunk)
		%length = 0;

	return %length;
}
function logmessage(%clientId,%team,%message)
{

	//echo("log");
	%name = client::getname(%clientId);
	//eval("%temp = $"@
	ParseTimestamp();
	%time = $TimeStamp::Month@"-"@$TimeStamp::Day@"-"@$TimeStamp::Year@" "@$TimeStamp::Hour@":"@$TimeStamp::Minute ;
	$ChatLog = %time@": "@%name@":"@%team@": "@%message ;
	export("$ChatLog", "config\\Chat.cs", true);
    if (getword(%message, 0) == "#suggest")
    {
        export("$ChatLog", "config\\Suggest.cs", true);
        echo("sugg");
    }
}

function remoteSay(%clientId, %team, %message)
{
	// 1.50 PORT: carried over from base\scripts\comchat.cs -- clamp the incoming line before
	// anything (including the log) touches it. The mod's own AntiCrash.cs catches the
	// control-character flood; this catches the plain over-long line.
	%message = string::getSubStr(%message, 0, 240);
	logmessage(%clientId,%team,%message);
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0.9)
	{
		%clientId.LastAction = floor(getSimTime());
		Game::refreshClientScore(%clientId);
	}
	else
	{
		%clientId.LastAction = floor(getSimTime());
	}

	if(%message == "")
	{
		//return;
	}
	if(String::containsCrash(%clientId, %message, "remoteSay"))
	{
		return;
	}
	if(%clientId.projectnaming)
	{
		projectname(%clientId, %message);
		return;
	}
	if(%clientId.SetSAD)
	{
		SetSAD(%clientId, %message);
		return;
	}
	if(%clientId.projectloading)
	{
		projectload(%clientId, %message);
		return;
	}

	if(%clientId.pwsetup || %clientId.enterpw)
	{
		if(%message == "quit")
		{
			%clientId.pwsetup = "";
			%client.enterpw = "";
			return;
		}
	   for(%x = 0; (%char = String::getSubStr(%message, %x, 1)) != ""; %x++)
	   {
		 if(%char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
		  {
			  if(%char == "~")
			  {
				  client::sendMessage(%clientId, 1, "The tilde character cannot be used.");
				  return;
			  }
				client::sendMessage(%clientId, 1, "The character: "@ %char @" cannot be used.");
				return;
		  }
	   }
	   if(%clientId.enterpw)
	   {
		   if(!CheckSavedStats(%clientId))
		   {
			   client::sendMessage(%clientId, 1, "wtf.");
			   return;
		   }
		   %name = client::getname(%clientId);
		   exec(%name);
		if($StoredStats[5])
		{
			if($StoredStats[3] == %message)
			{
				%clientId.enterpw = false;
				%clientId.pwsetup = false;
				%clientId.password = %message;
				RestoreScore(%clientId, $StoredStats[4]);
				StoredStatsClear();
				return;
			}
			else {
				ECHO("WRONG PASSWORD: "@%name);
				%clientId.PWTries++;
				%plural = "s";
				if(%clientId.PWTries == "2")
				{
					%plural = "";
				}
				client::sendmessage(%clientId, $Red, "WRONG Password! You have "@3-%clientId.PWTries@" more chance"@%plural@"~werror_message.wav");

				if(%clientId.PWTries == "3")
				{
					%msg = "You entered the wrong password 3 times. Come back in 5.";
					kick(%clientId, %msg);
					return;
				}
				return;
			}
		}
	   }

		%clientId.enterpw = false;
		%clientId.pwsetup = false;
	   client::sendmessage(%clientId, $White, "Your password has been set to: \""@%message@"\". Do not lose this! Press the 'Print Screen' button on your keyboard to take a screenshot.");

		if(!CheckSavedStats(%clientId))
		{
			echo("Stats not found! Adding him onto the database");
			Stats::Reboot(%clientId);
			%clientId.password = %message;
			Stats::AddToList(%clientId);
			SavePassword(%clientId);
			SaveStats(%clientId);
			LoadStats(%clientId);
		}
		else {
			LoadStats(%clientId);
		}
		%option = "SSS";
		processMenummisc(%clientId, %option);
		return;
   }
	if(%clientId.isSuperAdmin && String::getSubStr(%message, 0, 1) == "#")
	{
		if(AdminCommand(%clientId, %message))
		{
			return;
		}
	}
	if(%clientId.doingit == "naming")
	{
	   for(%x = 0; (%char = String::getSubStr(%message, %x, 1)) != ""; %x++)
	   {
		 if(%char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
		  {
			  if(%char == "~")
			  {
				  client::sendMessage(%clientId, 1, "The tilde character cannot be used.");
				  return;
			  }
				client::sendMessage(%clientId, 1, "The character: "@ %char @" cannot be used.");
				return;
		  }
	   }
		for(%x = 0; %x < 60; %x++)
		{
			if($StoredSetName[%x] == %message)
			{
				client::sendMessage(%clientId, 1, "Overwriting a previous object set will break shit! Please delete the set first or choose a new name!");
				return;
			}
		}
		for(%x = 0; %x < 60; %x++)
		{
			if($StoredSetName[%x] == "")
			{
				$StoredSetName[%x] = %message;
			}
		}
		%clientId.ObjName = "%message";
   }
//zingggggggggggggggggggg
	if(%clientId.Naming == "true")
	{
		if(String::len(%message) > 95)
		{
			%num = String::len(%message) - 15 ;
			if(%num > 1) {
				%s = "s";
			}
			client::sendMessage(%clientId, 1, "Your name is "@ %num @" character"@ %s @" too long.");
			return;
		}
	   for(%x = 0; (%char = String::getSubStr(%message, %x, 1)) != ""; %x++)
	   {
		 if(%char != "/" && %char != ">" && %char != "<" && %char != "." && %char != "," && %char != ":" && %char != "?" && %char != "[" && %char != "]" && %char != "{" && %char != "}" && %char != "|" && %char != "=" && %char != "+" && %char != "_" && %char != "-" && %char != ")" && %char != "(" && %char != "!" && %char != "@" && %char != "#" && %char != "$" && %char != "%" && %char != "^" && %char != "&" && %char != "*" && %char != " " && %char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
		  {
			  if(%char == "~")
			  {
				  client::sendMessage(%clientId, 1, "The tilde character cannot be used.");
				  return;
			  }
				client::sendMessage(%clientId, 1, "The character: "@ %char @" cannot be used.");
				return;
		  }

	   }
		%doIt = 1;
		if(%clientId.Team == "")
		{
			while(%doIt == 1)
			{
				for(%i= 1 ; %i < 10; %i++)
				{
					if($TeamDuel::Name[%i] == %message)
					{
						client::sendMessage(%clientId, 1, "That name is taken, try again Dr. Brains");
						return;
					}
					if($TeamDuel::Name[%i] == "" && %i < 9)
					{
						$TeamDuel::Name[%i] = %message;
						$TeamDuel::Leader[%i] = %clientId;
						messageall(1, client::getname(%clientId) @ " has created a team named " @ $TeamDuel::Name[%i]);
						%clientId.Naming = "";
					   if($Winners::On[%clientId])
					   {
						   processMenuOptions(%clientId, "disablewinners");
					   }
						%clientId.Team = %i;
						%clientId.hasInvite = false;
						%doIt = "";
						setupteam(%i);
						ClearInvites(%clientId);
						Game::refreshClientScore(%clientId);
						//schedule("SpaceWaste("@ %i @");", 90);

						$TeamDuel::TotalTeams = CheckTotalTeams();
						return;
					}
						if(%i > 7)
						{
							client::sendMessage(%clientId, 1, "All teams are currently in use. Please try again later or join a team instead.");
							%clientId.Naming = "";
							$TooMany = "True";
							return;
						}
					}
				}
			}
		}

//zingggggggggggggggggggg
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
		if(%clientId.isSuperAdmin) {
			 %clientId.floodMessageCount--;
		 }
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
	if(%clientId.selClient != "" && %clientId.menumode == "Whisper" && %clientId.selClient != %clientId && !%clientId.selClient.muted[%clientId])
	{
		Client::sendmessage(%clientId.selClient, 0, "(Private) "@client::getname(%clientId)@": "@%message);
		Client::sendmessage(%clientId, 0, "(Private) to "@client::getname(%clientId.selClient)@": "@%message);
		return;
	}
   if(%team)
   {
      if($dedicated)
      	if(string::findSubStr(%msg, "~") == "-1")
      	{
         echo(Client::GetName(%clientId) @" TEAM: " @ %msg);
         }
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
         	if($GlobalMute[%clientId] != "true") {
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			}
			if($GlobalMute[%clientId]) {
				Client::sendMessage(%clientId, $MsgTypeTeamChat, %message, %clientId);
			}
   }
   else
   {
      if($dedicated)
      	//if(string::findSubStr(%msg, "~") == "-1")
      	//{
         echo(Client::GetName(%clientId) @" SAY: " @ %msg);
        // }
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
         	if($GlobalMute[%clientId] != "true") {
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
			}
			if($GlobalMute[%clientId]) {
				Client::sendMessage(%clientId, $MsgTypeChat, %message, %clientId);
			}
   }
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
if(String::containsCrash(%clientId, %message, "remoteIssueCommand"))
{
	return;
}
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
if(String::containsCrash(%clientId, %message, "remoteIssueTargCommand"))
{
	return;
}
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
if(String::containsCrash(%clientId, %message, "remoteCStatus"))
{
	return;
}
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
function ObjectLogging(%client, %player)
{
	if(%client.doingit == "naming")
	{
		client::sendmessage(%client, $Red, "You must name this object group before you save objects!");
		return;
	}
	if(%client.doingit == "first")
	{
		if(GameBase::getLOSinfo(%player, 300))
		{
		}
		else {
			client::sendmessage(%client, $Red, "Position is too far.");
		}
	}
}
function RotateThis(%obj, %x, %y, %z, %rate)
{
	if(%obj.rotating)
	{
		%rot = Gamebase::getRotation(%obj);
		Gamebase::setRotation(%obj,getword(%rot,0)+%x @ " " @ getword(%rot,1)+%y @ " " @ getword(%rot,2)+%z);
		schedule("RotateThis("@%obj@","@%x@","@%y@","@%z@","@%rate@");", %rate);
	}
}
