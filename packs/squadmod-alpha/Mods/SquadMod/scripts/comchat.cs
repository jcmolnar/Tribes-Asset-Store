$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	// Added by KB
	if($Server::TourneyMode && !$matchStarted)
	{
		if(getWord(%message, 0) == "ready")
		{
			%clientId.isReady = True;
			messageAll(0, Client::getName(%clientId) @ " is now ready.");
			return;
		}
		else if((getWord(%message, 0) == "not" && getWord(%message, 1) == "ready") || getWord(%message, 0) == "notready")
		{
			%clientId.isReady = False;
			messageAll(0, Client::getName(%clientId) @ " is no longer ready.");
			return;
		}
	}

	%message = KBParse(%clientId, %message);
	// End Add by KB

   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
      }
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

function messageAll(%mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      Client::sendMessage(%cl, %mtype, %message);
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

//
// KB Added Stuff
//
function SquadMod_len(%string) 
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++; // Yeah I could do it with just %i, but I like this so shaddup

	return %length;
}

function SquadMod_replace(%string, %search, %replace)	
{
	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)		
	{   
		%lenstr = SquadMod_len(%string);
		%lenser = SquadMod_len(%search);
    	%part1 = String::getSubStr(%string, 0, %loc - 1);
    	%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
    	%string = %part1 @ " " @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);	
	}		
	return %string;	
}

function KBParse(%clientId, %msg)
{
	if($SquadModPref::ParseLocations == "True")
		%msg = ParseLocation(%clientId, %msg);
	if($SquadModPref::ProfanityFilter == "True")
		%msg = ProfanityFilter(%msg);

	return %msg;
}

function ParseLocation(%clientId, %msg)
{
	%loc = String::findSubStr(%msg, "%l");
	if(%loc == -1)
		return %msg;
	echo("*** Parsing Location String");

	%pos = GameBase::getPosition(%clientId);
  	%set=newObject("set",SimSet);

	%size = 60;

	%num=containerBoxFillSet(%set, $StaticObjectType, %pos, %size, %size, 10, 1);

	if(!%num) {
		deleteObject(%set);

		%locationstring = " somewhere in the field";

		if(%ClientId.LastDamageTime != 0 && (%ClientId.LastDamageTime + $SquadModPref::DisorentationTime) > getSimTime())
			%locationstring = "dodging weapons fire";

		%msg = SquadMod_replace(%msg, "%l", %locationstring);

		return %msg;
	}

	for(%i = 0; %i < %num; %i++)
  	{
        %object = Group::getObject(%set, %i);

		%name = GameBase::getMapName(%object);
		if(%name == "") 
			%name = (GameBase::getDataName(%object)).description;

		%distance = Vector::getDistance(GameBase::getPosition(%clientId), GameBase::getPosition(%object));
		if(%nearObjDistance == 0 || %nearObjDistance > %distance)
		{
			%nearObjName = %name;
			%nearObjDistance = %distance;
			%nearObjId= %object;
		}

  	}
	deleteObject(%set);

	if(GameBase::getTeam(%nearObjId) == GameBase::getTeam(%clientId))
		%whos = "our";
	else
		%whos = "the enemy";

	%rnd = floor((getRandom() * 10) / 2);
	if(floor(getRandom() * 10) > 5)
		%rnd = %rnd * -1;

	%distance = floor(%nearObjDistance) + %rnd;
	%locationstring = "about " @ %distance @ "m from " @ %whos @ " " @ %nearObjName;
	
	if(%ClientId.LastDamageTime != 0 && (%ClientId.LastDamageTime + $SquadModPref::DisorentationTime) > getSimTime())
		%locationstring = "dodging weapons fire";

	%msg = SquadMod_replace(%msg, "%l", %locationstring);
	
	return %msg;
}

function ProfanityFilter(%msg)
{
	%msg = SquadMod_replace(%msg, "shit", "****");
	%msg = SquadMod_replace(%msg, "fuck", "****");
	%msg = SquadMod_replace(%msg, "bitch", "*****");

	return %msg;
}

function remotePlayerWaypoint(%clientId, %destinationId, %message)
{
	%pos = GameBase::getPosition(%destinationId);
	%posX = getWord(%pos, 0);
	%posY = getWord(%pos, 1);
	
   	issueCommand(%clientId, %clientId, 0, %message , %posX, %posY);
}
