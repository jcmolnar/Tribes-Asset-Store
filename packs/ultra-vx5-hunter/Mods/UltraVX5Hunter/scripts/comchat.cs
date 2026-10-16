$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function String::len(%string) 
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}

//function String::replace(%string, %search, %replace)	
//{
//	%loc = String::findSubStr(%string, %search);
//	for(%loc; %loc != -1; %i++)		
//	{   
//		%lenstr = String::len(%string);
//		%lenser = String::len(%search);
//		%part1 = String::getSubStr(%string, 0, %loc - 1);
//		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
//		%string = %part1 @ " " @ %replace @ %part2;
//		%loc = String::findSubStr(%string, %search);	
//	}		
//	return %string;	
//}

function remoteSay(%clientId, %team, %message)
{
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

%n = String::len(%message);
%nt = String::len(%message);

//echo(%n);
//echo(%nt);

if(%n >80)
return false;

if(%nt >80)
return false;

if(%clientId.silenced)
{
	Client::sendMessage(%clientId, 1, "Ohhhh No! You Done Fucked Up... Now you been Stripped of your Freedom of Speach.~waccess_denied.wav");
	return;
}

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)) // PORT: stock name; was ...Disabled, which nothing sets
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodMute)
      {
         %delta = %clientId.muteDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "DAAMN! You Talk To Damn Much.. Wait: " @ %delta @ " seconds.");
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
         Client::sendMessage(%clientId, $MSGTypeGame, "DAAMN! You Talk To Damn Much.. Wait: 10 seconds.");
         return;
      }
   }
   if(%clientId.pmess > 0) 
   {
   if(%clientId != %clientId.pmess)
   Client::sendMessage(%clientId, 3, "[Message To " @ Client::getName(%clientId.pmess) @ "]: " @ %message);
   Client::sendMessage(%clientId.pmess, 3, "[Message From " @ Client::getName(%clientId) @ "]: " @ %message);
   echo("SAY: PM from " @ Client::getName(%clientId) @ " to " @ Client::getName(%clientId.pmess) @ " " @ %message);
   %clientId.pmess = -1;
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

//PORT-OFF: tion messageAll(%mtype, %message, %filter)
//PORT-OFF: {
//PORT-OFF:    if(%filter == "")
//PORT-OFF:       for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
//PORT-OFF:          Client::sendMessage(%cl, %mtype, %message);
//PORT-OFF:    else
//PORT-OFF:    {
//PORT-OFF:       for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
//PORT-OFF:       {
//PORT-OFF:          if(%cl.messageFilter & %filter)
//PORT-OFF:             Client::sendMessage(%cl, %mtype, %message);
//PORT-OFF:       }
//PORT-OFF:    }
//PORT-OFF: }

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

