$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	%name = Client::getName(%clientId);
	%clientTeam = Client::getTeam(%clientId);
	%player = Client::getOwnedObject(%clientId);

	if (String::findSubStr(%message, "/n") >= 0 || String::findSubStr(%message, "\n") >= 0)
	{
		%ip = Client::getTransportAddress(%clientId);
		BanList::add(%ip, 1800);
   		BanList::export("config\\banlist.cs");
		KickPlayer(%clientId, "Server went down.");
		MessageAll(1,%name @ " was banned for attempting to hack the server.");
		return;
	}
	if ($Wasteland::NoPestering)
	{
		if (String::findSubStr(%message, "reg") >= 0 && ($Client::info[%clientId, 5] != $Server::Admin["sadpw", %name] || $Client::info[%clientId, 5] == ""))
		{
			if (%team) Client::sendMessage(%clientId, $MsgTypeTeamChat, %message, %clientId);
			else Client::sendMessage(%clientId, $MsgTypeChat, %message, %clientId);
			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>Be a gracious guest, and don't pester about getting registered.  Thank you.\", 10);", 0);
			if($dedicated)
			{
				%wspmsg = "PESTER-" @ %msg;
				echo("SAY: " @ %wspmsg);
			}
			return;
		}
		if (String::findSubStr(%message, "join") >= 0 && String::findSubStr(%message,$ClanPriority) >= 0 && ($Client::info[%clientId, 5] != $Server::Admin["sadpw", %name] || $Client::info[%clientId, 5] == ""))
		{
			if (%team) Client::sendMessage(%clientId, $MsgTypeTeamChat, %message, %clientId);
			else Client::sendMessage(%clientId, $MsgTypeChat, %message, %clientId);
			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>Joining "@$ClanPriority@" is by invitation only.\", 5);", 0);
			if($dedicated)
			{
				%wspmsg = "PESTER-" @ %msg;
				echo("SAY: " @ %wspmsg);
			}
			return;
		}
		if (String::findSubStr(%message, "sponsor") >= 0 && ($Client::info[%clientId, 5] != $Server::Admin["sadpw", %name] || $Client::info[%clientId, 5] == ""))
		{
			if (%team) Client::sendMessage(%clientId, $MsgTypeTeamChat, %message, %clientId);
			else Client::sendMessage(%clientId, $MsgTypeChat, %message, %clientId);
			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>Joining Unity is by invitation only.\", 5);", 0);
			if($dedicated)
			{
				%wspmsg = "PESTER-" @ %msg;
				echo("SAY: " @ %wspmsg);
			}
			return;
		}
	}
	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

    	if($Wasteland::NoSwearing)
    	{
    		CheckBadWords(%clientId,%message);
	}
	if (%clientId.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0);
		return;
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
	%target = getWord(%message, 0);
//===Help Script
	if(String::findSubStr(%target, "#") == 0)
	{
		%cmd = String::getSubStr(%target,1,3);
		if(%cmd=="hel") HelpRequest(%clientId);
		else if(%cmd=="eli") ElimHelp(%clientId);
		else if(%cmd=="arm" || %cmd=="min" || %cmd=="gre") ItemHelp(%clientId, "armor");
		else if(%cmd=="ene") ItemHelp(%clientId, "nmeflag");
		else if(%cmd=="fla") ItemHelp(%clientId, "flag");
		else if(%cmd=="pac") PackHelp(%clientId);
		else if(%cmd=="obj") ObjHelp(%clientId);
		else if(%cmd=="rul") RuleHelp(%clientId);
		else if(%cmd=="tit") TitanHelp(%clientId);
		else if(%cmd=="cen")
		{
			issueCommand(%clientId, %clientId, 0,"Waypoint set to center.", 0, 0);
			%distance = Vector::getDistance("0 0 0", GameBase::getPosition(%clientId));
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The center is " @ %distance @ "m away.\", 3);", 0);
		}
		else if(%cmd=="sco")
		{
			%j = "";
			for(%k= 0 ; %k < getNumClients(); %k++)
			{
				%cl = getClientByIndex(%k);
				if (Client::getTeam(%cl) == 6 || Client::getTeam(%cl) == 7)
					Client::sendMessage(%clientId, 0, Client::getName(%cl) @ " has died " @ (%cl.scoreDeaths) @ " times.");
				%j = 1;
			}
			if (!%j) Client::sendMessage(%clientId, 0, "No player's are in the Unity Duel Arena.");
		}
		else if(%cmd=="spa")
		{
			Game::MenuRequest(%clientId);
			StartArmorSetup(%clientId);
		}
		else if(%cmd=="wea")
		{
			%item = Player::getMountedItem(%player,$WeaponSlot);
			Player::useItem(%player,%item);
		}
		else Client::sendMessage(%clientId, $MsgTypeGame, "Unrecognized Command: " @ getWord(%message,0));
		return;
	}

//===Whisper script
	if(String::findSubStr(%target, "@") == 0)
	{
		%whisper = "";
		%toGod = "";
		if($dedicated) echo("SAYTEAM: " @ %msg);
		%newmsg="";
		for(%i = 1; (%word = getWord(%message, %i)) != -1; %i++)
		{
			%newmsg= %newmsg @ " " @ %word;
		}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%armor = Player::getArmor(%cl);
			%bkpkcl = Player::getMountedItem(%cl, $BackpackSlot);
			%clName = Client::getName(%cl);
			%dude = String::getSubStr(%target,1,9);
			%teamcl = Client::getTeam(%cl);
     			if(String::findSubStr(%clName,%dude) >= 0)
			{
				if (%cl != %clientId)
				{
					if (%team && %clientTeam !=Client::getTeam(%cl)){}
					else
					{
						Client::sendMessage(%cl, $MsgTypeTeamChat, "{"@ %name @"}" @ %newmsg);
						Client::sendMessage(%clientId, $MsgTypeTeamChat, "{to "@ %clName @"}" @ %newmsg);
						%whisper = 1;
						if (%cl.isGod == true) %toGod = 1;
					}
				}
			}
			else if(%bkpkcl == Laptop && (%armor == "spyarmor" || %armor == "spyfemale" ) )
			{
				Client::sendMessage(%cl, $MsgTypeGame, "LapTop: " @ %message, %clientId);
				if (%cl.isGod == true) %toGod = 1;
			}
			else if(%teamcl.anten == True && %clientTeam.scramb != True) Client::sendMessage(%cl, $MsgTypeGame, "Antenna: " @%name@" is whispering.");
			if (%cl.isGod == true && %toGod !=1 && %cl != %clientId)
			{
				Client::sendMessage(%cl, $MsgTypeSystem, "{"@ %name @"} " @ %message);
			}
		}
     		if(String::findSubStr(%name,%dude) >= 0 && %whisper !=1)
		{
			Client::sendMessage(%clientId, $MsgTypeTeamChat, "{to self}" @ %newmsg);
			%whisper = 1;
		}
		if (%whisper != 1) Client::sendMessage(%clientId, $MsgTypeGame, "No whisper recipient match in " @ %dude@".");
		return;
	}

	if(%team)
	{
		if($dedicated) echo("SAYTEAM: " @ %msg);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%armor = Player::getArmor(%cl);
			%teamcl = Client::getTeam(%cl);
			%bkpkcl = Player::getMountedItem(%cl, $BackpackSlot);
			if(%teamcl == %clientTeam && !%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			else if (%clientId.isGod != true && %clientTeam != -1)
			{
				if(%teamcl.anten == True && %clientTeam.scramb != True) Client::sendMessage(%cl, $MsgTypeGame, "Antenna: " @%message, %clientId);
				else if(%bkpkcl == Laptop && (%armor == "spyarmor" || %armor == "spyfemale" ) ) Client::sendMessage(%cl, $MsgTypeGame, "LapTop: " @ %message, %clientId);
				else if (%cl.isGod == true)
				{
					if(%teamcl.anten == True && %clientTeam.scramb == True) Client::sendMessage(%cl, $MsgTypeGame, "***encrypted***: " @ %message, %clientId);
					else Client::sendMessage(%cl, $MsgTypeSystem, "Team: " @ %message, %clientId);
				}
				else if(%teamcl.anten == True && %clientTeam.scramb == True) Client::sendMessage(%cl, $MsgTypeGame, "Antenna: ***encrypted***", %clientId);
			}
			else if (%cl.isGod == true && %team == -1) Client::sendMessage(%cl, $MsgTypeSystem, "Observer: " @ %message, %clientId);

		}
	}
	else
	{
		if($Server::TourneyMode && $Wasteland::GlobalTChat != "True" && !%clientId.isadmin && !%clientId.islead)
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Only Leaders & Admins Can Speak Globally In Tourney Mode...\", 3);", 0);
			return;
		}

		if($dedicated)
			echo("SAY: " @ %msg);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(!%cl.muted[%clientId])
			{
				if (%clientId.isOld)
				{
					if(String::findSubStr(%message,"~w") >= 0) Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
					else Client::sendMessage(%cl, $MsgTypeChat, %name @":: " @ %message);
				}
				else Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
			}
		}
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0);
		return;
	}
	if ($Wasteland::ComChat && !isnetworkdown(gamebase::getteam(%clientId)) && !ispowerdown(gamebase::getteam(%clientId)))
	{
		schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>Your sensor array and power are down, TEAM ONLY Com's Do Not Function!!!\", 10);" ,0.2);
		return 0;
	}
	if($dedicated)
	{
		echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}
	echo("Command Issued " @ %command);

	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area issueCommand takes float mission coords.

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
		if(!%dest[%i].muted[%commander])
		issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
		echo ("Dest " @ %dest[%i]);
	}
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0);
		return;
	}

	if($dedicated)
	{
	echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
		if(!%dest[%i].muted[%commander])
		issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
		echo ("Dest " @ %dest[%i]);
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

function messageAdmin(%mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl.isAdmin)
			Client::sendMessage(%cl, %mtype, "{to Admin} " @ %message);
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

function systemMessage(%client, %mtype, %message)
{
	Client::sendMessage(%client, %mtype, %message);
	if(String::getSubStr(%message,1,1)!="w") %message = "OBS: " @ %message;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{ 
		if (%cl.observerTarget == %client)
		{
			Client::sendMessage(%cl, %mtype, %message);
		}
	}
}
function checkBadWords(%client,%msg)
{
	%newmsg="";
	%saidbadword=false;

	for(%i = 0; (%word = getWord(%msg, %i)) != -1; %i++)
	{
		for(%j=0;$Wasteland::badwordlist[%j] != "";%j++)
		{
			if(String::findSubStr(%word,$Wasteland::badwordlist[%j]) == 0)
			{
				%newmsg= %newmsg @ " **** ";
				%saidbadword=true;
			}
			else
			{
				%newmsg= %newmsg @ " " @ %word;
			}
		}
	}
	if(%saidbadword)
	{

		%client.BadWordsSpoken++;
		%time = getIntegerTime(true) >> 5;
		%client.floodMute = true;
		%client.muteDoneTime = %time + 10;
		%client.ismuted=True;
		schedule(%client @ ".ismuted=false;",10);
		if(%client.BadWordsSpoken<$Wasteland::BadWordsMax)
			Client::sendMessage(%client, $MsgTypeGame, "Cussing is not allowed.  You have been muted for 10 seconds.");
		if(%client.BadWordsSpoken>=$Wasteland::BadWordsMax)
		{
			Client::sendMessage(%client, $MsgTypeGame, "Warning: You will be kicked if you continue to use that language!");
			schedule("centerprint(" @ %client @ ", \"<jc><f0>You have been terminated for your foul language\", 5);", 5);
			schedule ("Player::Kill(" @ %client @ ");", 2.0);
			schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %client @ "));",2.0);
		}
		if(%client.BadWordsSpoken>=$Wasteland::BadWordsKick)
			KickPlayer(%client ,"You have been kicked for foul language");
	}
}


