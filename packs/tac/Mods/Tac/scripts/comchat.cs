// - BW Admin Mod -
$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   %time = getIntegerTime(true) >> 5;

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
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

// - BW Admin Mod - anti-TK code - anti-social behaviour
         %clientId.bk++;
         schedule(%clientId @ ".bk--;", 180, %clientId);

         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }


//====================================================
// Anti voice pack spam code

	if($TAC::VoiceSpamLimit >= 1 && !$Server::TourneyMode)
	{
		if(%clientId.VoicePackSpamTime == "")
			%clientId.VoicePackSpamTime = 0;
		if(%clientId.VoicePackSpamTime != 0)
		{
			%delta2 = %clientId.VoicePackSpamTime - %time;
			if(%delta2 <= 0)
				%clientId.VoicePackSpamTime = 0;
		}
		else
			%delta2 = 0;
		if(%clientId.TACVoiceSpamCount < 0)
			%clientId.TACVoiceSpamCount = 0;

		if((String::findSubStr(%msg,"~w") != -1) && !%team)
		{
			if(%delta2 > 0)
			{
				Client::sendMessage(%clientId, 1, "You cannot use global spam messages for "@%delta2@" seconds.");
				return;
			}
			%clientId.TACVoiceSpamCount++;
			schedule(%clientId@".TACVoiceSpamCount--;",20,%clientId);
			if(%clientId.TACVoiceSpamCount >= $TAC::VoiceSpamLimit)
			{
				%clientID.TACSpamOffence++;
				%clientId.VoicePackSpamTime = %time + (20 * %clientID.TACSpamOffence);
				messageAll(1, Client::getName(%clientId) @ " was voice pack muted for " @ 20 * %clientID.TACSpamOffence @ " seconds due to excessive voice pack spam.");
				%clientId.TACVoiceSpamCount = 0;
				return;
			}
		}
		else if(%team)
		{

		}
		else
			%clientId.TACVoiceSpamCount = 0;
	}
	else
		%clientId.VoicePackSpamTime = 0;

//=====================================================

   if(%clientId.AdminServerSettings && (getWord(%message, 0) == ".cp"))
   {
	for(%w = 1; %w < 40; %w++)
	{
	   %word = getWord(%message, %w);
	   if(%word == -1)
	      break;
	   else
	      %cpmsg = %cpmsg @ " " @ %word;
	}
	if(%cpmsg != "")
	   centerprintall("<jc><f0>" @ Client::getName(%clientId) @ ":<f1>" @ %cpmsg, 8);
	if($dedicated)
           echo("TAC CENTERPRINT: " @ %cpmsg);
	return;
   }

   if(%clientId.AdminReferee && (getWord(%message, 0) == "!") && (%clientId.selClient != 0))
   {
		for(%w = 1; %w < 40; %w++)
		{
	   		%word = getWord(%message, %w);
	   		if(%word == -1)
	      		break;
	   		else
	      		%cpmsg = %cpmsg @ " " @ %word;
		}
		if(%cpmsg != "")
		{
			Client::sendMessage(%clientId, 1, "(" @ Client::getName(%clientId) @ "-" @ Client::getName(%clientId.selClient) @ ") " @ %cpmsg);
			Client::sendMessage(%clientId.selClient, 1, "(" @ Client::getName(%clientId.selClient) @ "-" @ Client::getName(%clientId) @ ") " @ %cpmsg);
		}
		if($dedicated)
           	echo("TACSAY (" @ %clientId @ "-" @ %clientId.selClient @"): " @ %cpmsg);
		return;
   }


   if((%team == 1) || (%team == "APC none"))
   {
		if(%clientId.gagged != true)
		{
			  if($dedicated)
				 echo("SAYTEAM: " @ %msg);
			  %team = Client::getTeam(%clientId);
			  for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				 if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
					Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
		}
		else
	   		Client::sendMessage(%clientId, 1, "You are gagged and may not talk.");
   }
   else if(getWord(%team,0) == "APC")
   	{
		%VehicleId = getWord(%team,1);
		if(%clientId.gagged != true)
		{
			if($dedicated)
				echo("SAYAPC: " @ %msg);

			if(GameBase::getDataName(%vehicleId) == HAPC)
				%numSlots = 4;
			else
				%numSlots = 2;
			%tempclientid = %vehicleId.clLastMount;
			for(%i=0;%i<%numSlots;%i++)
			{
				%tempclient[%i] = Player::getClient(%vehicleId.Seat[%i]);
				if(%vehicleId.Seat[%i] != "")
				{
					if(!%tempclient[%i].muted[%clientId])
						Client::sendMessage(%tempclient[%i], $MsgTypeTeamChat, %message, %clientId);
				}
			}
			if(%vehicleId.hasPilot)
			{
				if(!%cl.muted[%clientId])
					Client::sendMessage(%tempclientid, $MsgTypeTeamChat, %message, %clientId);
			}
		}
		else
	   		Client::sendMessage(%clientId, 1, "You are gagged and may not talk.");
	}
   else
   {
		//-----Disallow global talking whilst in purgatory mode------Wizard_TPG
		if((%clientId.purgatory != true) && (%clientId.gagged != true))
		{
	    	if($dedicated)
		 		echo("SAY: " @ %msg);
      		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         		if(!%cl.muted[%clientId])
            		Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
    	}
    	else if(%clientId.purgatory == true)
		    Client::sendMessage(%clientId, 1, "You may only use TeamTalk in Purgatory Mode.");
		else
            Client::sendMessage(%clientId, 1, "You are gagged and may not talk.");
        //---------------------------------------------------------------------
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

// - BW Admin Mod - Advanced console logging for stats tracking programs
   if(%message3 != "" && $dedicated && $matchStarted && $TAC::controlledTourneyMode && $Server::TourneyMode && $TAC::messageLog)
      {
         %time = floor(getSimTime() - $missionStartTime);
         echo("TACMSG (" @ %time @ "): " @ %message3);
      }
// - BW Admin Mod - End

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
// - BW Admin Mod - Advanced console logging for stats tracking programs
   if($dedicated && $matchStarted && $TAC::controlledTourneyMode && $Server::TourneyMode && $TAC::messageLog)
      {
         %time = floor(getSimTime() - $missionStartTime);
         echo("TACMSG (" @ %time @ "): " @ %message);
      }
// - BW Admin Mod - End
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
// - BW Admin Mod - Advanced console logging for stats tracking programs
   if($dedicated && $matchStarted && $TAC::controlledTourneyMode && $Server::TourneyMode && $TAC::messageLog)
      {
         %time = floor(getSimTime() - $missionStartTime);
         echo("TACMSG (" @ %time @ "): " @ %message);
      }
// - BW Admin Mod - End
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

