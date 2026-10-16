// __________________________________________________________________________
// Tribes Arena v3.0 for Starsiege Tribes                          2002-06-15
// by Lizard (irc.dynamix.com on #lizrena, or belgarion@tribes2universe.com)
// __________________________________________________________________________
// Modified "comchat.cs"
// __________________________________________________________________________
//

$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;
function verifyClientMuteStatus(%clientId, %supposedlyMutedClient)
{
if (%clientId.muted[%supposedlyMutedClient])
{
if ((%clientId.mutedName[%supposedlyMutedClient] != Client::getName(%supposedlyMutedClient)) && (%clientId.mutedName[%supposedlyMutedClient] != ""))
{
%clientId.muted[%supposedlyMutedClient] = "";
%clientId.mutedName[%supposedlyMutedClient] = "";
}
}
if (%supposedlyMutedClient.mutedGlobal)
{
if ((%supposedlyMutedClient.mutedGlobalName != Client::getName(%supposedlyMutedClient)) && (%supposedlyMutedClient.mutedGlobalName != ""))
{
%supposedlyMutedClient.mutedGlobal = "";
%supposedlyMutedClient.mutedGlobalWarned = "";
%supposedlyMutedClient.mutedGlobalName = "";
}
}
}
function remoteSay(%clientId, %team, %message)
{
%message = String::getSubStr(%message, 0, 240); // PORT: stock chat length cap
%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
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
if(%team)
{
if($dedicated) {
if ($DisplayPlayerNameInSayLogMessages == 1)
echo("SAYTEAM: " @ Client::getName(%clientId) @ ": " @ %msg);
else
echo("SAYTEAM: " @ %msg);
}
%team = Client::getTeam(%clientId);
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%cl.muted[%clientId]) || (%clientId.mutedGlobal))
{
verifyClientMuteStatus(%cl, %clientId);
}
if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
{
if (!%clientId.mutedGlobal)
{
Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
}
else
{
if (!%clientId.mutedGlobalWarned)
{
Client::sendMessage(%clientId,2,"You have been muted and can not talk for now.");
}
%clientId.mutedGlobalWarned = true;
}
}
}
}
else
{
if($dedicated) {
if ($DisplayPlayerNameInSayLogMessages == 1)
echo("SAY: " @ Client::getName(%clientId) @ ": " @ %msg);
else
echo("SAY: " @ %msg);
}
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%cl.muted[%clientId]) || (%clientId.mutedGlobal))
{
verifyClientMuteStatus(%cl, %clientId);
}
if (!%cl.muted[%clientId])
{
if (!%clientId.mutedGlobal)
{
Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
}
else
{
if (!%clientId.mutedGlobalWarned)
{
Client::sendMessage(%clientId,2,"You have been muted and can not talk for now.");
}
%clientId.mutedGlobalWarned = true;
}
}
}
}
}
function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
%dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
if($dedicated)
echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
for(%i = 1; %dest[%i] != ""; %i = %i + 1)
{
if ((%dest[%i].muted[%commander]) || (%commander.mutedGlobal))
{
verifyClientMuteStatus(%dest[%i], %commander);
}
if (!%dest[%i].muted[%commander])
{
if (!%commander.mutedGlobal)
{
issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}
else
{
if (!%commander.mutedGlobalWarned)
{
Client::sendMessage(%commander,2,"You have been muted and can not issue commands for now.");
}
%commander.mutedGlobalWarned = true;
}
}
}
}
function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx,
%dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
if($dedicated)
echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
for(%i = 1; %dest[%i] != ""; %i = %i + 1)
{
if ((%dest[%i].muted[%commander]) || (%commander.mutedGlobal))
{
verifyClientMuteStatus(%dest[%i], %commander);
}
if (!%dest[%i].muted[%commander])
{
if (!%commander.mutedGlobal)
{
issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}
else
{
if (!%commander.mutedGlobalWarned)
{
Client::sendMessage(%commander,2,"You have been muted and can not issue commands for now.");
}
%commander.mutedGlobalWarned = true;
}
}
}
}
function remoteCStatus(%clientId, %status, %message)
{
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
$arenacomchat_cs_version = "$Revision: 2 $ on $Date: 7/12/02 3:35p $";
echo("VERSION: ArenaComchat.cs v" @ $Arena::Version @ ", internal version " @ $arenacomchat_cs_version);
