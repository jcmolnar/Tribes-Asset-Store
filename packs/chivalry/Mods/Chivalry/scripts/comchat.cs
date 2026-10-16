$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	%message = String::getSubStr(%message, 0, 240); // PORT: the stock 1.11 length cap
	%bug = %message;
	%clientId.isJammed = false;
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
	if(%clientId.shutup)
	{
		Client::sendMessage(%clientId,1,"You are not allowed to speak!");
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
         echo("SAYTEAM: " @ Client::getName(%clientId) @ " " @ %msg);
      %team = Client::getTeam(%clientId);
	NearBug(%clientId, %bug);
	NearComJam(%clientId);
	if(%clientId.isJammed)
		{
		Client::sendMessage(%clientId,1,"Your Transmissions are being jammed!");
		return;
		}
	if(%clientId.Undead || %clientId.isGhost)
		{
		UndeadMsg(%clientId,%message);
		return;
		}
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
         echo("SAY: " @ Client::getName(%clientId) @ " " @ %msg);
	NearComJam(%clientId);
	if(%clientId.isJammed)
	{
	Client::sendMessage(%clientId,1,"Your Transmissions are being jammed!");
	return;
	}
	if(%clientId.Undead || %clientId.isGhost)
	{
	UndeadMsg(%clientId,%message);
	return;
	}
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   }
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ Client::GetName(%commander) @ " \"" @ escapeString(%command) @ "\"");
	NearComJam(%commander);
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander] && !%commander.isJammed)
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ Client::getName(%commander) @ " \"" @ escapeString(%command) @ "\"");
	NearComJam(%commander);
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander] && !%commander.isJammed)
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ Client::GetName(%clientId) @ " \"" @ escapeString(%message) @ "\"");
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
	%clientId = Player::getClient(%id);
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
%num = containerBoxFillSet(%set,%mask,%pos,150,150,150,0);
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
		if(%name == "DeployableBug" && GameBase::getDamageState(%index) == "Enabled")
		{
		if(%team != %player)
				{
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl,1,"Enemy Trans:: "@ %message);
		%index = -1;
				}
			}
		}
	}
	}
deleteObject(%set);
}

function NearComJam(%clientId)
{
%clientId.isJammed = false;
%player = Client::getTeam(%clientId);
%pos = GameBase::getPosition(%clientId);
%set = newObject("set",SimSet);
%mask = $StaticObjectType;
%num = containerBoxFillSet(%set,%mask,%pos,150,150,150,0);
%num = CountObjects(%set,"DeployableComJam",%num);

	if(%num > 0)
	{
	for(%count = 0; %index != -1; %count++)
	{
		%index = Group::getObject(%set, %count);
		if(%index != -1)
		 {
		%name = GameBase::getDataName(%index);
		%team = GameBase::getTeam(%index);
		if(%name == "DeployableComJam" && GameBase::getDamageState(%index) == "Enabled")
		{
		if(%team != %player)
				{
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) != %team && !%cl.muted[%clientId])
           // Client::sendMessage(%cl,1,"Your Transmissions are being jammed!");
		%clientId.isJammed = true;
				}
			}

			}
			
		     }
		
	}
 deleteObject(%set);
}
			
function UndeadMsg(%clientId,%message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Undead || %cl.Litch && !%cl.isAdmin && !%cl.isSuperAdmin)
		{
		Client::sendMessage(%cl,1,%message);
		}
	else if(%cl.Undead && %cl.isAdmin || %cl.isSuperAdmin)
		{
		%name = Client::getName(%clientId);
		if(%clientId.Undead)
		Client::sendMessage(%cl,1, "Undead "@%name@": "@%message);
		else Client::sendMessage(%cl,1,"Ghost "@%name@": "@%message);
		}
	}
}