// ----------------------------------------------------------------------------
// Paintball Mod
//
// Mod gutted by KingTomato
// Original coding by |K0RN|, with help from [RR]MisterPibb
// ----------------------------------------------------------------------------
// File Information
// --
// File:	comchat.cs
// Purpose:	Handles client messages in the game, as wel as on screen
//		displays.
// ----------------------------------------------------------------------------

// My own events library -KT
exec("KT_ComChat.cs");

// ----------------------------------------------------------------------------
// Events

// ############################################################################
// Filtering
// ############################################################################

// Hexing, Tabbing, etc
Ontext::Attach("onText_Protect");
function onText_Protect(%client, %msg, %team)
{
	%count[Hex] = 0;
	%count[Tab] = 0;
	%count[Cr]  = 0;

	for (%a = 0; (%letter = String::GetSubStr(%msg, %a, 1)) != ""; %a++)
	{
		if (%letter == "\t")
			%count[Tab]++;
		else if (%letter == "\n")
			%count[Cr]++;
		else if (String::findSubStr(escapeString(%letter), "\\x") == 0)
			%count[Hex]++;
	}

	%adminMsg = "";
	if ((%count[Tab] >= $PB::Msg::Sensativity) && ($PB::Msg::NoTabCrash))
		%adminMsg = "tab";
	else if ((%count[Hex] >= $PB::Msg::Sensativity) && ($PB::Msg::NoHexCrash))
		%adminMsg = "hex";
	else if ((%count[Cr] >= $PB::Msg::Sensativity) && ($PB::Msg::NoCrCrash))
		%adminMsg = "carrage return";

	if (%adminMsg != "")
	{
		%name = Client::GetName(%client);
		%client.crashCount++;

		Client::SendMessage(%client, 1, "Sorry, " @ %adminMsg @ " crashes are not allowed here.");
		%client.isGagged = true;
		schedule(%client @ ".isGagged = false;", 5.0);

		if ($PB::Msg::NotifyCrash)
		{
			for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
				if (%cl.isSuperAdmin)
				{
					Client::SendMessage(%cl, 1, %name @ " just attempted a " @ %adminMsg @ " crash.~waccess_denied.wav");
					bottomPrint(%cl, "<jc><f2>Attention!\n<f1>" @ %name @ " <f0>has just attemped a<f1> " @ %adminMsg @ " <f0>crash.", 10);
				}
		}

		if ((%client.crashCount >= $PB::Msg::KickLimit) && ($PB::Msg::AutoKick))
		{
			BanList::Add(Client::GetTransportAddress(%client), $PB::Msg::KickTime);
			Net::Kick(%client, "You have been kicked for attempting a server crash.");
			messageAll(0, %name @ " has been kicked for attempting a server crash.");
		}

		return true; // Do not output text
	}

	return false; // allow text
}

// Flooding
Ontext::Attach("onText_Flood");
function onText_Flood(%client, %msg, %team) {
	// check for flooding if it's a broadcast OR if it's team in FFA
	if ($Server::FloodProtectionEnabled)
	{
		// we use getIntTime here because getSimTime gets reset.
		// time is measured in 32 ms chunks... so approx 32 to the sec
		%time = getIntegerTime(true) >> 5;

		if (%client.floodMute)
		{
			%delta = %client.muteDoneTime - %time;
			if (%delta > 0)
			{
				Client::sendMessage(%client, $MSGType::Game, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return true; // Do not output text
			}
			%client.floodMute = "";
			%client.muteDoneTime = "";
		}
		%client.floodMessageCount++;

		// funky use of schedule here:
		schedule(%client @ ".floodMessageCount--;", 5, %client);

		if (%client.floodMessageCount > 4)
		{
			%client.floodMute = true;
			%client.muteDoneTime = %time + 10;
			Client::sendMessage(%client, $MSGType::Game, "FLOOD! You cannot talk for 10 seconds.");
			return true; // Do not output text
		}
	}

	return false; // allow text
}

// ############################################################################
// Restrictions
// ############################################################################

OnText::Attach("onText_Restrictions");
function onText_Restrictions(%client, %msg, %team)
{
	if (%client.isGagged)
		Client::SendMessage(%client, 1, "You have been gagged, and may not speak.");
	else if ((String::FindSubStr(%msg, "~") != -1) && (%client.noVoice))
		Client::SendMessage(%client, 1, "You have been restricted from using your voice pack.");
	else if ((!%team) && (%client.teamChat))
		Client::SendMessage(%client, 1, "You have been restricted from talking globally.");
	else
		return false;
	return true;
}

// ############################################################################
// Features
// ############################################################################

// In chat functions
OnText::Attach("onText_ChatFunctions");
function onText_ChatFunctions(%client, %msg, %team) {

	// Check for admin
	if (%client.isSuperAdmin)
	{
		%cName = Client::GetName(%client);

		// Bottom print
		if (String::findSubStr(%msg, ".bp ") == 0) 
		{
			%message = String::GetSubStr(%msg, 4, 999);
			echo(sprintf("bottomPrint from %1 (%2) \\\"%3\\\"", %client, %cName, escapestring(%message)));
			bottomPrintAll("<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
			return true; // Do not output text
		}

		// Center Print
		else if (String::findSubStr(%msg, ".cp ") == 0) 
		{
			%message = String::GetSubStr(%msg, 4, 999);
			echo(sprintf("centerPrint from %1 (%2) \\\"%3\\\"", %client, %cName, escapestring(%message)));
			centerPrintAll("<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
			return true; // Do not output text
		}

		// Top Print
		else if (String::findSubStr(%msg, ".tp ") == 0) 
		{
			%message = String::GetSubStr(%msg, 4, 999);
			echo(sprintf("topPrint from %1 (%2) \\\"%3\\\"", %client, %cName, escapestring(%message)));
			topPrintAll("<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
			return true; // Do not output text
		}

		// lock
		else if (String::findSubStr(%msg, ".lock ") == 0)
		{
			// list of characters a password can be made of
			%ascii	= "ABCDEFGHIJKLMNOPQRSTUVWXY"
				@ "Zabcdefghijklmnopqrstuvwx"
				@ "yz0123456789";

			%password = String::getSubStr(%msg, 6, 999);
			if (%password == "")
				Client::SendMessage(%client, 1, "Please specify a password after the command (Ex: .lock keepout)~waccess_denied.wav");
			else
			{
				%invalid = false;
				for (%l = 0; (%letter = String::GetSubStr(%password, %l, 1)) != ""; %l++)
					if (String::findSubStr(%ascii, %letter) == -1)
						%invalid = true;

				if (%invalid)
					Client::SendMessage(%client, 1, "Password is invalid. Please use letters and numbers only.~waccess_denied.wav");
				else
				{
					$Server::Password = %password;
					messageAll(0, "Server password has been set by " @ Client::GetName(%client) @ ".");
					messageAll(0, "Server password is: " @ %password);
				}
			}

			return true; // do not output text
		}

		// unlock server
		else if (%msg == ".unlock")
		{
			$Server::Password = "";
			messageAll(0, "Server password has been removed by " @ Client::GetName(%client) @ ".");
			messageAll(0, "The server is now open to the public.");

			return true; // do not output text
		}

		// spoofing
		else if (String::findSubStr(%msg, ".spoof ") == 0)
		{
			%message = String::getSubStr(%msg, 7, 999);
			%spoof = %client.spoofing;
			%spName = Client::getName(%spoof);
			if (%spName != "")
			{
				echo(sprintf("spoof (%1 (%2) -> %3 (%4) \\\"%5\\\"", %client, %cName, %spoof, %spName, escapestring(%message)));
				for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					if(!%cl.muted[%spoof])
					{
						if (%cl.isSuperAdmin)
							Client::sendMessage(%cl, $MsgType::Chat, "(Spoof): " @ %message, %spoof);
						else
							Client::sendMessage(%cl, $MsgType::Chat, %message, %spoof);
					}
			}
			return true;
		}
		else if (String::findSUbStr(%msg, ".pmtp ") == 0)
		{
			%message = String::getSubStr(%msg, 6, 999);
			%cName = Client::GetName(%client);
			%cl = %client.speakTo;
			%clName = Client::GetName(%cl);
			if ((%cl != "") && (%clName != ""))
			{
				echo(sprintf("topPrint from %1 (%2) to %3 (%4) \\\"%3\\\"", %client, %cName, %cl, %clName, escapestring(%message)));
				topPrint(%cl, "<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
				Client::sendMessage(%client, 5, %cName @ " (to " @ %clName @ "): " @ %message);
				return true; // Do not output text
			}
			else
			{
				Client::SendMessage(%client, 0, "Please select a user to speak with before using that command.");
			}
			return true;
		}
		else if (String::findSUbStr(%msg, ".pmcp ") == 0)
		{
			%message = String::getSubStr(%msg, 6, 999);
			%cName = Client::GetName(%client);
			%cl = %client.speakTo;
			%clName = Client::GetName(%cl);
			if ((%cl != "") && (%clName != ""))
			{
				echo(sprintf("centerPrint from %1 (%2) to %3 (%4) \\\"%3\\\"", %client, %cName, %cl, %clName, escapestring(%message)));
				centerPrint(%cl, "<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
				Client::sendMessage(%client, 5, %cName @ " (to " @ %clName @ "): " @ %message);
				return true; // Do not output text
			}
			else
			{
				Client::SendMessage(%client, 0, "Please select a user to speak with before using that command.");
			}
			return true;
		}
		else if (String::findSUbStr(%msg, ".pmbp ") == 0)
		{
			%message = String::getSubStr(%msg, 6, 999);
			%cName = Client::GetName(%client);
			%cl = %client.speakTo;
			%clName = Client::GetName(%cl);
			if ((%cl != "") && (%clName != ""))
			{
				echo(sprintf("bottomPrint from %1 (%2) to %3 (%4) \\\"%3\\\"", %client, %cName, %cl, %clName, escapestring(%message)));
				bottomPrint(%cl, "<jc><f2>Super-Admin Message\n<F0>" @ %cName @ ": <f1>" @ %message, 10);
				Client::sendMessage(%client, 5, %cName @ " (to " @ %clName @ "): " @ %message);
				return true; // Do not output text
			}
			else
			{
				Client::SendMessage(%client, 0, "Please select a user to speak with before using that command.");
			}
			return true;
		}
	}

	// admin
	if (%client.isAdmin)
	{
	}

	// no admin
	if (%msg == ".help")
	{
	}
	else if (%msg == ".lock?")
	{
		if ($Server::JoinPassword == "")
			Client::SendMessage(%client, 0, "There is no password on the server.");
		else
			Client::SendMessage(%client, 0, "The current server password is: " @ $Server::JoinPassword);

		return true;
	}
	else if (String::findSUbStr(%msg, ".pm ") == 0)
	{
		%cl = %client.speakTo;
		if ((%cl != "") && (Client::GetName(%cl) != ""))
		{
			%message = String::getSubStr(%msg, 4, 999);
			%name = Client::GetName(%cl);
			%clName = Client::GetName(%client);
			echo(sprintf("SAYPRIV: %1 %2 \\\"%3\\\"", %client, %cl, escapestring(%msg)));

			for (%cli = Client::GetFirst(); %cli != -1; %cli = Client::getNext(%cli))
				if (%cli == %client)
					Client::sendMessage(%cli, 5, %clName @ " (to " @ %name @ "): " @ %message);
				else if (%cli == %cl)
					Client::sendMessage(%cli, 5, %clName @ " (private): " @ %message);
				else if ((!%cl.isAdmin) && (!%client.isAdmin) && (%cli.isSuperAdmin))
					Client::sendMessage(%cli, 5, %clName @ " (to " @ %name @ "): " @ %message);
		}
		else
		{
			Client::SendMessage(%client, 0, "Please select a user to speak with before using that command.");
		}
		return true;
	}

	return false; // allow text

}

// ################################################################################################
// Money Code
// ################################################################################################

OnText::Attach("OnText_Money");
function onText_Money(%client, %msg, %team) {
	if ($Money::Enabled)
	{
		if (%msg == ".spending")
		{
			Money::HelpMessage(%client);

			return true; // do not output text
		}

		else if (String::findSubStr(%msg, ".create") == 0)
		{
			%password = String::GetSubStr(%msg, 8, 255);
			if (%password != "")
				Money::createUser(%client, %password);
			else
				Client::SendMessage(%client, 0, "Please provide a password to use when logging in.");

			return true; // do not output text
		}
		else if (String::findSubStr(%msg, ".login") == 0)
		{
			%password = String::GetSubStr(%msg, 7, 255);
			if (%password != "")
				Money::Login(%client, %password);
			else
				Client::SendMessage(%client, 0, "Please provide a login password.");

			return true; // do not output text
		}
		else if (String::findSubStr(%msg, ".logout") == 0)
		{
			Client::SendMessage(%client, 0, "There is no need to logout! Your information is already saved.");

			return true; // do not output text
		}
		else if (String::findSubStr(%msg, ".pass ") == 0)
		{
			%password = String::GetSubStr(%msg, 6, 255);
			if (%password != "")
				Money::ChangePassword(%client, %password);
			else
				Client::SendMessage(%client, 0, "Please specify a new password.");

			return true; // do not output text
		}
	}

	// for idiots who can't seem to read that spending isn't enabled
	else
	{
		if ((String::findSubStr(%msg, ".login") == 0) || (String::findSubStr(%msg, ".create") == 0) ||
		    (String::findSubStr(%msg, ".spending") == 0) || (String::findSubStr(%msg, ".pass") == 0))
		{
			Client::SendMessage(%client, 0, "Client spending is not enabled.");
			return true; // do not output text
		}
	}

	return false; // output text
}

// ################################################################################################
// Routines
// ################################################################################################

// ----------------------------------------------------------------------------
// Blah, ugly code. If I have to press another tab button today, im gonna freak
// I might do this later, but for now--i ain't gonna touch it, so what the hell
// do i care if it's legible? >:P

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

// ################################################################################################
// Library/Misc Functions
// ################################################################################################

function iif(%condition, %true, %false) {
	if (%condition)
		return %true;
	return %false;
}

////////////////////////////////////////////////////////////////////////// Zear Is A God >:P //////
/////////////////////////////////////////////////////////////////////////  So is Presto :D  ///////

function String::doubleSlashes(%string)    
{
    %newstring = "";
    for(%i = 0; %i < String::len(%string); %i++)
    {
        %char = String::getSubStr(%string, %i, 1);
        if(%char == "\\")
            %newstring = %newstring@"\\\\";
        else
            %newstring = %newstring@%char;
    }
    return %newstring; 
}

function PBString::replace(%string, %search, %replace) // PORT: renamed, String::replace is an engine function on 1.50    
{
    if(%search == %replace || String::findSubStr(%replace, %search) != -1) // prevent infinite loops
        return %string;
        
    while((%idx = String::findSubStr(%string, %search)) != -1)             
    {   
        %len = String::len(%string);
        %front = String::getSubStr(%string, 0, %idx);
        %idx += String::len(%search);
        %back = String::getSubStr(%string, %idx, %len - %idx);
        %string = %front @ %replace @ %back;
    }
    return %string; 
}

function String::str(%chars, %num)
{
    for(%i = 0; %i < %num; %i++)
        %string = %string @ %chars;
        
    return %string;
}

function PBString::Length(%string) // PORT: renamed (engine function on 1.50)
{
    for(%length=0; String::getSubStr(%string, %length, 1) != ""; %length++)
    {} // it's all done above!
    return %length;
}
           
function PBString::getWordCount(%string) // PORT: renamed (engine function on 1.50)
{
    for(%num = 0; getWord(%string, %num) != -1; %num++)
    {} // it's all done above!
    return %num;
}