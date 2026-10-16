$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function HCCheckPassword(%playerId,%message)
{
	%message = %message @ " X";
	%enteredpassword = "";
	%firstword = "true";
	for(%al = 1; getWord(%message,%al) != "X"; %al++)
		{
			if (%firstword == "true") 
				%enteredpassword = getWord(%message,%al); 
					else %enteredpassword = %enteredpassword @ " " @ getWord(%message,%al);
			%firstword = "false";
		}
	for(%cl = ($RemoteAdminList::User[0] == ""); $RemoteAdminList::User[%cl] != ""; %cl++) // PORT: the documented list starts at [1]
		{
			$adminentry = 0;
			%logonname = GetNextEntry($RemoteAdminList::User[%cl]);
			%realname = GetNextEntry($RemoteAdminList::User[%cl]);
			%emailaddress = GetNextEntry($RemoteAdminList::User[%cl]);
			%password = GetNextEntry($RemoteAdminList::User[%cl]);
			%accesslevel = GetNextEntry($RemoteAdminList::User[%cl]);
			%ipaddress = GetNextEntry($RemoteAdminList::User[%cl]);

			if(!String::NCompare(Client::getTransportAddress(%playerId), "LOOPBACK", 8)) 
				{
					%em = $PCFG::EMail;
					%rn = $PCFG::RealName;
				} else
				{
					%em = $Client::info[%playerId,2];
					%rn = $Client::info[%playerId,1];
				}
			if (Client::getName(%playerId) == %logonname && %rn == %realname && %em == %emailaddress && %password != "" && String::Compare(%enteredpassword, %password) == 0) // PORT: exact, and never a blank password
				{
					if (%accesslevel == "SuperAdmin" && !%playerId.isSuperAdmin)
						{
							Client::sendMessage(%playerId,0,"You have been granted Super Admin access.");
							ixAdminMsg("" @ %logonname @ " has been auto-set to Super Admin access.");
							%playerId.isSuperAdmin = true;
							%playerId.isAdmin = true;
							%playerId.regularuser = true;
						}
					if (%accesslevel == "Admin" && !%playerId.isAdmin)
						{
							Client::sendMessage(%playerId,0,"You have been granted Admin access.");
							ixAdminMsg("" @ %logonname @ " has been auto-set to Admin access.");
							%playerId.isAdmin = true;
							%playerId.regularuser = true;
						}
					if (%accesslevel == "RegularUser" && !%playerId.regularuser)
						{
							Client::sendMessage(%playerId,0,"You have been granted Regular User access.");
							ixAdminMsg("" @ %logonname @ " has been auto-set to Regular User access.");
							%playerId.regularuser = true;
						}
				} else 
				{
					Client::sendMessage(%playerId,0,"--INCORRECT USER/PASSWORD COMBINATION-- ~waccess_denied.wav");
				}
		}
}

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

   if(%team)
   {
	if(getWord(%message,0) != "PASS:")
		{
		      if($dedicated) echo("SAYTEAM: " @ %msg);
		      %team = Client::getTeam(%clientId);
		      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            		Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
		} else HCCheckPassword(%clientId,%message);
   }
   else
   {
	if(getWord(%message,0) != "PASS:")
		{
		      if($dedicated) echo("SAY: " @ %msg);
		      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		         if(!%cl.muted[%clientId])
            		Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
		} else HCCheckPassword(%clientId,%message);
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
   if(getWord(%message,0) != "False")
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
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

