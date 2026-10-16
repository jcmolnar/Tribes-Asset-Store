$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
//*****************************************************************
// SF Addition: Tuesday, March 28, 2000 - 4:55 PM EST
//
// Notes: this is the parsing code JI wrote so we can 'talk' to the server
// and tell it how fast the player wants to go....

	if(String::getSubStr(%message, 0, 1) == "#")
	{
		%w1 = GetWord(%message, 0);

		%cropped = String::getSubStr(%message, (String::len(%w1)+1), String::len(%message)-(String::len(%w1)+1));

		if(%w1 == "#train")
		{
			//get train Id
			%t = IsOnTrain(%clientId);

			if(%t != -1)
			{
				//if the previous driver jumped off, tell the train it has no driver
				if(IsOnTrain($Train::Driver[%t]) == -1)
					$Train::Driver[%t] = "";

				//if the train has no driver, make this player the driver
				if($Train::Driver[%t] == "")
					$Train::Driver[%t] = %clientId;

				if($Train::Driver[%t] == %clientId)
				{
					%spd = $Train::Speed[%t];

					%lastchar = String::getSubStr(%cropped, String::len(%cropped)-1, 1);
					if(%lastchar == "%")
					{
						if(%spd == "0")
						{
					            Client::sendMessage(%clientId, $MSGTypeSystem, "Train must be moving to do this.");
						}
						else
						{
							%perc = String::getSubStr(%cropped, 0, String::len(%cropped)-1);
							%amount = floor($faketrains * (%perc / 100));
							%final = %amount - %spd;
							$Train::SpeedBuffer[%t] = %final;

					            Client::sendMessage(%clientId, $MSGTypeSystem, "Train's speed was set to " @ %cropped);
						}
					}

					if(%cropped == "slower" && %spd > 0)
					{
						%spd--;
						SetSpeed(%t, %spd);
				            Client::sendMessage(%clientId, $MSGTypeSystem, "Train is decreasing in speed...");
					}

					if(%cropped == "faster" && %spd < $faketrains)
					{
						%spd++;
						SetSpeed(%t, %spd);
				            Client::sendMessage(%clientId, $MSGTypeSystem, "Train is increasing in speed...");
					}
					else if(%cropped == "faster" && %spd >= $faketrains)
				            Client::sendMessage(%clientId, $MSGTypeSystem, "The train has reached its maximum speed.");
				}
				else
			            Client::sendMessage(%clientId, $MSGTypeSystem, "You are not driving this train.");
			}
			else
		            Client::sendMessage(%clientId, $MSGTypeSystem, "You are not on a train.");
		}
		return;
	}

//************************************************************************************
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

