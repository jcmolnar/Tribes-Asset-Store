$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;


function remoteSay(%clientId, %team, %message)
{
  %msg = %clientId @ " : " @ Client::getName(%clientId) @ " \"" @ escapeString(%message) @ "\"";
  if(%clientId.restrained)
  {
    if(%clientId.restrainTime > 0)
    {
      pxRestrainClient(%clientId);
      return;
    }
    else
    {
      %clientId.restrainTime = $Phobiax::RestrainChatTime;
      pxRestrainClient(%clientId);
    }
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
    schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
    if(%clientId.floodMessageCount > 4)
    {
      %clientId.floodMute = true;
      %clientId.muteDoneTime = %time + 10;
      Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
      return;
    }
  }
  if(%clientId.gagged)
  {
    %end = String::findSubStr(%message,"~w");
    if(%end != "-1") %message = String::getSubStr(%message, 0, %end);
  }
  if(%team)
  {
    if($dedicated) echo("SAYTEAM: " @ %msg);
    %team = Client::getTeam(%clientId);
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId]) Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
  }
  else
  {
    if($dedicated) echo("SAY: " @ %msg);
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) if(!%cl.muted[%clientId]) Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
  }
}


function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
  if($dedicated) echo("COMMANDISSUE: " @ %commander @ " : " @ Client::getName(%commander) @ " \"" @ escapeString(%command) @ "\"");
  for(%i = 1; %dest[%i] != ""; %i = %i + 1) if(!%dest[%i].muted[%commander]) issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}


function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
  if($dedicated) echo("COMMANDISSUE: " @ %commander @ " : " @ Client::getName(%commander) @ " \"" @ escapeString(%command) @ "\"");
  for(%i = 1; %dest[%i] != ""; %i = %i + 1) if(!%dest[%i].muted[%commander]) issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}


function remoteCStatus(%clientId, %status, %message)
{
  if(setCommandStatus(%clientId, %status, %message))
  {
    if($dedicated) echo("COMMANDSTATUS: " @ %clientId @ " : " @ Client::getName(%clientId) @ " \"" @ escapeString(%message) @ "\"");
  }
  else remoteSay(%clientId, true, %message);
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
  if(%filter == "") for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) Client::sendMessage(%cl, %mtype, %message);
  else
  {
    for(%cl = Client::getFirst();
    %cl != -1;
    %cl = Client::getNext(%cl))
    {
      if(%cl.messageFilter & %filter) Client::sendMessage(%cl, %mtype, %message);
    }
  }
}


function messageAllExcept(%except, %mtype, %message)
{
  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) if(%cl != %except) Client::sendMessage(%cl, %mtype, %message);
}
