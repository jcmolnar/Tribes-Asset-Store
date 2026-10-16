


function Nappy::Chat::CTFMessageAll(%mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.game == "CTF"){
			Client::sendMessage(%cl,%mtype, %message);
		}
	}
}




function Nappy::Chat::PitTeamMessageAllExcept(%clientId, %messageType)
{
	%name = Nappy::getName(%clientId);

	%gender = Client::getGender(%clientId); 
	if(%gender == "Male")
		%genderTag = "him";
	else
		%genderTag = "her";
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.NappyDuel == "duel" && %cl != %clientId){
			if(%cl.DuelTeam == %clientId.DuelTeam && %cl.pit == %clientId.pit){
				if(%messageType == "suicide")
					Client::sendMessage(%cl,0,%name @ " killed " @ %genderTag @ "self.~waccess_denied.wav");
			}
		}
	}
}



function Nappy::Chat::CommandCheck(%clientId,%message)
{

	%commandChar = string::getSubStr(%message, 0, 1);

	%testing = 0;
	if(%commandChar == "#") 
		if(%testing)
			if(Nappy::Test::CheckForCommand(%clientId,%message))
				return 1;

	if(%commandChar == "#") 
		if(%clientId.NappyDuel == "duel")
			if(Nappy::Duel::CheckForCommand(%clientId,%message))
				return 1;

	if(%commandChar == "!") 
		if(%clientId.NappyDuel == "duel")
			if(Nappy::Duel::CheckForHelpCommand(%clientId,%message))
				return 1;

	if(%commandChar == "*") 
		if($BuilderMode)
			if(Nappy::Builder::CheckForCommand(%clientId,%message))
				return 1;

	%Nappy::Chat::RemoteCommand = GetWord(%message,0);
	if(%Nappy::Chat::RemoteCommand == "#nextSatchel"){
		//Nappy::satchelCycle(%clientId);
		return 1;
	}
	else if(%Nappy::Chat::RemoteCommand == "#password"){
		%password = GetWord(%message,1);
		%i = 1;
		if($Nappy::Personal::Passwords) // PORT: the switch was not tested on the chat path
			Nappy::PasswordCheck(%clientId, %password, %i);
		return 1;
	}

	if(%clientId.isUltraAdmin){
		if(%Nappy::Chat::RemoteCommand == "#setTime"){
			Nappy::Time::Set(%clientId, %message);
			return 1;
		}
		else if(%Nappy::Chat::RemoteCommand == "#nameFX" && %clientId.isUltraAdmin){
			%id = GetWord(%message,1);
			%clientId.FXid = %id;
			%clientId.FX = 1;
			if(!%clientId.nameFX){
				%clientId.nameFX = 1;
				Nappy::NameFX(%clientId);
			}
			else{
				%clientId.nameFX = 0;
				%clientId.FX = 0;
				schedule(%clientId @ ".FX = 1;", 1.2);
				//schedule(%clientId @ ".FX++;", 1.2);
				schedule(%clientId @ ".nameFX++;", 1.5);
				schedule("Nappy::NameFX(" @ %clientId @ ");", 2);
			}
			return 1;
		}
		else if(%Nappy::Chat::RemoteCommand == "#randomNameFX" && %clientId.isUltraAdmin){
			%clientId.nameFX = 1;
			Nappy::NameFX::Random(%clientId);
			return 1;
		}
		else if(%Nappy::Chat::RemoteCommand == "#stopNameFX" && %clientId.isUltraAdmin){
			%clientId.nameFX = 0;
			return 1;
		}
		else if(%Nappy::Chat::RemoteCommand == "#nameTag1" && %clientId.isUltraAdmin){
			%clientId.NameTagBefore = GetWord(%message,1);
			Game::refreshClientScore(%clientId);
			return 1;
		}
		else if(%Nappy::Chat::RemoteCommand == "#nameTag2" && %clientId.isUltraAdmin){
			%clientId.NameTagAfter = GetWord(%message,1);
			Game::refreshClientScore(%clientId);
			return 1;
		}
	}

}




function Nappy::MessageCheck(%clientId, %message, %type)
{
	%friend = %clientId.isFriend;
	%newMessage = "";
	%newMessageSound = "";
	%i = 0;
	%building = "message";
	%badChar = 0;
	%bad = 0;
	for(%i; string::getSubStr(%message, %i, 1) != ""; %i++){
		%char = string::getSubStr(%message, %i, 1);
		%result = String::iCompare(%char, " ");	
		if(%result == 60){
			%next = %i + 1;
			%nextChar = string::getSubStr(%message, %next, 1);
			if(%nextChar == "n" || %nextChar == "t"){
				%badChar++;
			}
		}
		else if(%result < 0 || %result > 94){ // PORT: "(%result > 64 && %result < 91) ||" removed: with the 1.50 runtime String::ICompare("h", " ") is 72, so every LETTER counted as a non-keyboard character
			%badChar++;
		}
		else if(%result == 94){
			%next = %i + 1;
			%nextChar = string::getSubStr(%message, %next, 1);
			if(%nextChar == "w"){
				%building = "wave";
			}
		}
		if(%building == "message"){
			if(%i == 0)
				%newMessage = %char;
			else
				%newMessage = %newMessage @ %char;
		}
		else if(%building == "wave"){
			if(%result == 94)
				%newMessageSound = %char;
			else
				%newMessageSound = %newMessageSound @ %char;
		}
		if(%badChar > $Nappy::Message::OtherCharacters || (%i > ($Nappy::Message::MaxLength - 1) && !%friend)){
			%bad = 1;
			break;
		}
	}
	if(%type == "bad")
		return %bad;
	else if(%type == "sound")
		return %newMessageSound;
}


function remoteSay(%clientId, %team, %message)
{
	if(%clientId.kickMe)
		return;

	if($Nappy::Flood::ClientKicked[%clientId])
		return;

	%ignore = 0;
	%commandChar = string::getSubStr(%message, 0, 1);
	if(%commandChar == "#" || %commandChar == "!" || %commandChar == "*")
		if(Nappy::Chat::CommandCheck(%clientId,%message))
			%ignore = 1;

	if(!%ignore){
		%bad = Nappy::MessageCheck(%clientId, %message, "bad");
		if(%bad){
			%BadMessageLog = Nappy::getName(%clientId) @ ": " @ %message;  
			Nappy::Log(BadMessage,%BadMessageLog);
		}
		else{

			if(Nappy::MessageCheck(%clientId, %message, "sound") != ""){
				%type = " [SOUND] ";
				%name = "";
				%ClId = %clientId;
			}
			else{
				%type = " [TYPED] ";
				%name = Nappy::getName(%clientId);
				%ClId = "";
			}


			if($Nappy::LogMessages){
				if(%team && %clientId.speakto == "")
						%MessageLog = %type @ %clientId.game @ " TEAM: " @ Nappy::getName(%clientId) @ ": " @ %message;
				else if(%clientId.speakto != "")
					%MessageLog = %type @ "PRIVATE: " @ Nappy::getName(%clientId) @ " to (" @ Nappy::getName(%clientId.speakto) @ "): " @ %message;  
				else
					%MessageLog = %type @ %clientId.game @ " GLOBAL: " @ Nappy::getName(%clientId) @ ": " @ %message;  
				Nappy::Log(Message,%MessageLog);
			}
			if(%clientId.possessed){
				Client::sendMessage(%clientId, 1, "You cannot speak while possessed.~waccess_denied.wav");
				return;
			}
			if(%clientId.gag) {
				Client::sendMessage(%clientId, 1, "You can't talk without a tongue you moron!~waccess_denied.wav");
				return;
			}
			if(%clientId.speakto != "") {
				if(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PASpeak)) {
					Client::sendMessage(%clientId.speakto, 1, "(private): " @ %message, %ClId);
					Client::sendMessage(%clientId, 1, " (to " @ Nappy::getName(%clientId.speakto) @ "): "@ %message, %ClId);
					return;
				} 
			}
			if($Nappy::Message::showInConsole)
				%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
			if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)){
				%time = getIntegerTime(true) >> 5;
				if($Nappy::FloodCount[%clientId,floodMessage] >= $Nappy::FloodCount::kick[3]){
					%message = Nappy::getName(%clientId) @ " was kicked for message spamming.";
					Nappy::Log("AutoKick", %message);
					%clientId.kickMe = 1;
					schedule("Nappy::UnKick(" @ %clientId @ ");",15);
					return;
				}
				Nappy::FloodCount(%clientId ,"floodMessage",3);
				if(%clientId.floodMute){
					%clientId.muteDoneTime = %clientId.muteDoneTime + $Nappy::Message::floodMuteTimeBonus;
					%delta = %clientId.muteDoneTime - %time;
					if(%delta > 0){
						Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
						return;
					}
					%clientId.floodMute = "";
					%clientId.muteDoneTime = "";
				}
				if($Nappy::FloodCount[%clientId,floodMessage] > $Nappy::FloodCount::ignore[3]){
					%clientId.floodMute = true;
					%clientId.muteDoneTime = %time + $Nappy::Message::floodMuteTime;
					Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ $Nappy::Message::floodMuteTime @ " seconds.");
					return;
				}
			}

			if(%name != "")
				%message = %name @ ": " @ %message;

			if(%team){
				if($dedicated && $Nappy::Message::showInConsole){
					echo(" ");
					echo("SAYTEAM: " @ %name @ ": " @ %msg);
					echo(" ");
				}
				%team = Client::getTeam(%clientId);
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
					if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId]){
						if((%clientId.NappyDuel == "duel" && %cl.NappyDuel == "duel") && %clientId.pit == %cl.pit)
							Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %ClId);
						else if(%clientId.NappyDuel != "duel" && %cl.NappyDuel != "duel")
							Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %ClId);
					}
					else if(%cl.isSuperAdmin && Client::getTeam(%cl) == -1)
						Client::sendMessage(%cl, $Nappy::AdminObserverOtherTeamChatColor, %message, %ClId);
				}
			}
			else{
				if($dedicated && $Nappy::Message::showInConsole){
					echo(" ");
					echo("SAY: " @ %name @ ": " @ %msg);
					echo(" ");
				}
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					if(!%cl.muted[%clientId])
						Client::sendMessage(%cl, $MsgTypeChat, %message, %ClId);
			}
		}
	}
}






function remoteCStatus(%clientId, %status, %message)
{
	if(Nappy::remoteCheck(%clientId, "CStatus", 1, %message))
		return;
	// setCommandStatus returns false if no status was changed.
	// in this case these should just be team says.
	if(setCommandStatus(%clientId, %status, %message)){
		//if($dedicated)
			//echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
	}
	else
		remoteSay(%clientId, true, %message);
}




function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1){
		%id = getClientByIndex(%i);
		if(Client::getTeam(%id) == %team1){
			Client::sendMessage(%id, %mtype, %message1);
		}
		else if(%message2 != "" && Client::getTeam(%id) == %team2){
			Client::sendMessage(%id, %mtype, %message2);
		}
		else if(%message3 != ""){
			Client::sendMessage(%id, %mtype, %message3);
		}
	}
}




function messageAll(%mtype, %message, %filter)
{
	if(%filter == "")
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Client::sendMessage(%cl, %mtype, %message);
	else{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
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




function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if(Nappy::remoteCheck(%commander, "IssueCommand", 1, %command))
		return;
   // PORT: a bare "if($dedicated)" stood here; its echo line is commented out, so it governed the loop below
      //echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if(Nappy::remoteCheck(%commander, "IssueTargCommand", 1, %command))
		return;
   // PORT: same bare "if($dedicated)" removed
      //echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}



//    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//    X X XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX X X
//    X XX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XX X
//    X XXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXX X
//    X XXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXX X
//    X XXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXXXXXX  XXXX X
//    X XXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXX X
//    X XX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XXXX XX X
//    X X XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX XX XXXXXX X X
//    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//    ________________________________________________________________

function Nappy::NameFX(%clientId, %return)
{
	if(%return != ""){
		if(%clientId.nameFXdirection != "reverse")
			%return++;
		else
			%return--;
		%clientId.FX = %return;
	}
	if($NameFX[%clientId.FXid, %clientId.FX] == "")
		%clientId.FX = 1;
	if($NameFX[%clientId.FXid, %clientId.FX] == "loop")
		%clientId.FX = 1;

	if($NameFX[%clientId.FXid, %clientId.FX] == "forward"){
		%clientId.nameFXdirection = "forward";
		%clientId.FX++;
	}
	else if($NameFX[%clientId.FXid, %clientId.FX] == "reverse"){
		%clientId.nameFXdirection = "reverse";
		%clientId.FX --;
	}

	Game::refreshClientScore(%clientId);
	if(%clientId.nameFX){
		schedule("Nappy::NameFX(" @ %clientId @ ", " @ %clientId.FX @ ");", 0.25);
	}
}


function Nappy::NameFX::Random(%clientId)
{
	if(%clientId.nameFX){
		%clientId.nameFX = 0;
		schedule("Nappy::NameFX::ActivateRandom(" @ %clientId @ ");", 0.5);
	}
}

function Nappy::NameFX::ActivateRandom(%clientId)
{

	%random = getRandom() * $FXmax;
	for(%i = 0;%i <= %random;%i++){}
	%clientId.FXid = $FX[%i];

	%clientId.FX = 1;

	%clientId.nameFX = 1;
	Nappy::NameFX(%clientId);

	schedule("Nappy::NameFX::Random(" @ %clientId @ ");", 5);

}



$FX[1] = "pingpong";
$FX[2] = "fade";
$FX[3] = "shiver";
$FX[4] = "bounce";
$FX[5] = "Scroll";
$FX[6] = "spacebounce";
$FX[7] = "spaceScroll";
$FX[8] = "tagScroll";
$FX[9] = "tagnamesqueze";
$FX[10] = "tagnameScroll";
$FX[11] = "tagnameScroll2";
$FX[12] = "tagnamesqueze2";
$FX[13] = "time";
$FX[14] = "flash";
$FX[15] = "tagbounce";

$FXmax = 15;


$NameFX[tagbounce, 1] = "forward";
$NameFX[tagbounce, 2] = "[NHOP]Smokey";
$NameFX[tagbounce, 3] = "S[NHOP]mokey";
$NameFX[tagbounce, 4] = "Sm[NHOP]okey";
$NameFX[tagbounce, 5] = "Smo[NHOP]key";
$NameFX[tagbounce, 6] = "Smok[NHOP]ey";
$NameFX[tagbounce, 7] = "Smoke[NHOP]y";
$NameFX[tagbounce, 8] = "Smokey[NHOP]";
$NameFX[tagbounce, 9] = "reverse";



$NameFX[time, 1] = "forward";
$NameFX[time, 2] = $Nappy::Time::Stamp;
$NameFX[time, 3] = "loop";

$NameFX[flash, 1] = "forward";
$NameFX[flash, 2] = "[NHOP]Smokey";
$NameFX[flash, 3] = "";
$NameFX[flash, 4] = "loop";



$NameFX[tagnamesqueze2, 1] = "forward";
$NameFX[tagnamesqueze2, 2] = "[NHOP]Smokey";
$NameFX[tagnamesqueze2, 3] = " NHOP]Smoke";
$NameFX[tagnamesqueze2, 4] = "  HOP]Smok";
$NameFX[tagnamesqueze2, 5] = "   OP]Smo";
$NameFX[tagnamesqueze2, 6] = "    P]Sm";
$NameFX[tagnamesqueze2, 7] = "     ]S";
$NameFX[tagnamesqueze2, 8] = "";
$NameFX[tagnamesqueze2, 9] = "reverse";


$NameFX[tagnameScroll2, 1] = "forward";
$NameFX[tagnameScroll2, 2] = "[NHOP]Smokey";
$NameFX[tagnameScroll2, 3] = " [NHOPmokey";
$NameFX[tagnameScroll2, 4] = "  [NHOokey";
$NameFX[tagnameScroll2, 5] = "   [NHkey";
$NameFX[tagnameScroll2, 6] = "    [Ney";
$NameFX[tagnameScroll2, 7] = "     [y";
$NameFX[tagnameScroll2, 8] = " ";
$NameFX[tagnameScroll2, 9] = "]          S";
$NameFX[tagnameScroll2, 10] = "P]        Sm";
$NameFX[tagnameScroll2, 11] = "OP]      Smo";
$NameFX[tagnameScroll2, 12] = "HOP]    Smok";
$NameFX[tagnameScroll2, 13] = "NHOP]  Smoke";
$NameFX[tagnameScroll2, 14] = "[NHOP]Smokey";
$NameFX[tagnameScroll2, 15] = "loop";


$NameFX[tagnameScroll, 1] = "forward";
$NameFX[tagnameScroll, 2] = "[NHOP]Smokey";
$NameFX[tagnameScroll, 3] = " [NHOPSmokey";
$NameFX[tagnameScroll, 4] = " [NHOPmokey";
$NameFX[tagnameScroll, 5] = "  [NHOmokey";
$NameFX[tagnameScroll, 6] = "  [NHOokey";
$NameFX[tagnameScroll, 7] = "   [NHokey";
$NameFX[tagnameScroll, 8] = "   [NHkey";
$NameFX[tagnameScroll, 9] = "    [Nkey";
$NameFX[tagnameScroll, 10] = "    [Ney";
$NameFX[tagnameScroll, 11] = "     [ey";
$NameFX[tagnameScroll, 12] = "     [y";
$NameFX[tagnameScroll, 13] = "      y";
$NameFX[tagnameScroll, 14] = "]";
$NameFX[tagnameScroll, 15] = "]          S";
$NameFX[tagnameScroll, 16] = "P]         S";
$NameFX[tagnameScroll, 17] = "P]        Sm";
$NameFX[tagnameScroll, 18] = "OP]       Sm";
$NameFX[tagnameScroll, 19] = "OP]      Smo";
$NameFX[tagnameScroll, 20] = "HOP]     Smo";
$NameFX[tagnameScroll, 21] = "HOP]    Smok";
$NameFX[tagnameScroll, 22] = "NHOP]   Smok";
$NameFX[tagnameScroll, 23] = "NHOP]  Smoke";
$NameFX[tagnameScroll, 24] = "[NHOP] Smoke";
$NameFX[tagnameScroll, 25] = "[NHOP]Smokey";
$NameFX[tagnameScroll, 26] = "loop";


$NameFX[tagnamesqueze, 1] = "forward";
$NameFX[tagnamesqueze, 2] = "[NHOP]Smokey";
$NameFX[tagnamesqueze, 3] = "[NHOP]Smoke";
$NameFX[tagnamesqueze, 4] = " NHOP]Smoke";
$NameFX[tagnamesqueze, 5] = " NHOP]Smok";
$NameFX[tagnamesqueze, 6] = "  HOP]Smok";
$NameFX[tagnamesqueze, 7] = "  HOP]Smo";
$NameFX[tagnamesqueze, 8] = "   OP]Smo";
$NameFX[tagnamesqueze, 9] = "   OP]Sm";
$NameFX[tagnamesqueze, 10] = "    P]Sm";
$NameFX[tagnamesqueze, 11] = "    P]S";
$NameFX[tagnamesqueze, 12] = "     ]S";
$NameFX[tagnamesqueze, 13] = "     ]";
$NameFX[tagnamesqueze, 14] = "";
$NameFX[tagnamesqueze, 15] = "reverse";


$NameFX[tagScroll, 1] = "forward";
$NameFX[tagScroll, 2] = "[NHOP]Smokey";
$NameFX[tagScroll, 3] = "S[NHOP]mokey";
$NameFX[tagScroll, 4] = "Sm[NHOP]okey";
$NameFX[tagScroll, 5] = "Smo[NHOP]key";
$NameFX[tagScroll, 6] = "Smok[NHOP]ey";
$NameFX[tagScroll, 7] = "Smoke[NHOP]y";
$NameFX[tagScroll, 8] = "Smokey[NHOP]";
$NameFX[tagScroll, 9] = "loop";


$NameFX[spaceScroll, 1] = "forward";
$NameFX[spaceScroll, 2] = "[NHOP]Smokey";
$NameFX[spaceScroll, 3] = "[NHOP]Smoke y";
$NameFX[spaceScroll, 4] = "[NHOP]Smok ey";
$NameFX[spaceScroll, 5] = "[NHOP]Smo key";
$NameFX[spaceScroll, 6] = "[NHOP]Sm okey";
$NameFX[spaceScroll, 7] = "[NHOP]S mokey";
$NameFX[spaceScroll, 8] = "[NHOP] Smokey";
$NameFX[spaceScroll, 9] = "[NHOP ]Smokey";
$NameFX[spaceScroll, 10] = "[NHO P]Smokey";
$NameFX[spaceScroll, 11] = "[NH OP]Smokey";
$NameFX[spaceScroll, 12] = "[N HOP]Smokey";
$NameFX[spaceScroll, 13] = "[ NHOP]Smokey";
$NameFX[spaceScroll, 14] = " [NHOP]Smokey";
$NameFX[spaceScroll, 15] = "loop";

$NameFX[spacebounce, 1] = "forward";
$NameFX[spacebounce, 2] = "[NHOP]Smokey";
$NameFX[spacebounce, 3] = "[NHOP]Smoke y";
$NameFX[spacebounce, 4] = "[NHOP]Smok ey";
$NameFX[spacebounce, 5] = "[NHOP]Smo key";
$NameFX[spacebounce, 6] = "[NHOP]Sm okey";
$NameFX[spacebounce, 7] = "[NHOP]S mokey";
$NameFX[spacebounce, 8] = "[NHOP] Smokey";
$NameFX[spacebounce, 9] = "[NHOP ]Smokey";
$NameFX[spacebounce, 10] = "[NHO P]Smokey";
$NameFX[spacebounce, 11] = "[NH OP]Smokey";
$NameFX[spacebounce, 12] = "[N HOP]Smokey";
$NameFX[spacebounce, 13] = "[ NHOP]Smokey";
$NameFX[spacebounce, 14] = " [NHOP]Smokey";
$NameFX[spacebounce, 15] = "reverse";


$NameFX[pingpong, 1] = "forward";
$NameFX[pingpong, 2] = "{NHOP]Smokey";
$NameFX[pingpong, 3] = "[nHOP]Smokey";
$NameFX[pingpong, 4] = "[NhOP]Smokey";
$NameFX[pingpong, 5] = "[NHoP]Smokey";
$NameFX[pingpong, 6] = "[NHOp]Smokey";
$NameFX[pingpong, 7] = "[NHOP}Smokey";
$NameFX[pingpong, 8] = "[NHOP]smokey";
$NameFX[pingpong, 9] = "[NHOP]SMokey";
$NameFX[pingpong, 10] = "[NHOP]SmOkey";
$NameFX[pingpong, 11] = "[NHOP]SmoKey";
$NameFX[pingpong, 12] = "[NHOP]SmokEy";
$NameFX[pingpong, 13] = "[NHOP]SmokeY";
$NameFX[pingpong, 14] = "reverse";


$NameFX[Scroll, 1] = "forward";
$NameFX[Scroll, 2] = "[NHOP]Smokey";
$NameFX[Scroll, 3] = " [NHOP]Smoke";
$NameFX[Scroll, 4] = "  [NHOP]Smok";
$NameFX[Scroll, 5] = "   [NHOP]Smo";
$NameFX[Scroll, 6] = "    [NHOP]Sm";
$NameFX[Scroll, 7] = "     [NHOP]S";
$NameFX[Scroll, 8] = "      [NHOP]";
$NameFX[Scroll, 9] = "       [NHOP";
$NameFX[Scroll, 10] = "        [NHO";
$NameFX[Scroll, 11] = "         [NH";
$NameFX[Scroll, 12] = "          [N";
$NameFX[Scroll, 13] = "           [";
$NameFX[Scroll, 14] = "y";
$NameFX[Scroll, 15] = "ey";
$NameFX[Scroll, 16] = "key";
$NameFX[Scroll, 17] = "okey";
$NameFX[Scroll, 18] = "mokey";
$NameFX[Scroll, 19] = "Smokey";
$NameFX[Scroll, 20] = "]Smokey";
$NameFX[Scroll, 21] = "P]Smokey";
$NameFX[Scroll, 22] = "OP]Smokey";
$NameFX[Scroll, 23] = "HOP]Smokey";
$NameFX[Scroll, 24] = "NHOP]Smokey";
$NameFX[Scroll, 25] = "loop";

$NameFX[bounce, 1] = "forward";
$NameFX[bounce, 2] = "[NHOP]Smokey";
$NameFX[bounce, 3] = " [NHOP]Smokey";
$NameFX[bounce, 4] = "  [NHOP]Smokey";
$NameFX[bounce, 5] = "   [NHOP]Smokey";
$NameFX[bounce, 6] = "    [NHOP]Smokey";
$NameFX[bounce, 7] = "reverse";

$NameFX[shiver, 1] = "forward";
$NameFX[shiver, 2] = "[NHOP]Smokey";
$NameFX[shiver, 3] = " [NHOP]Smokey";
$NameFX[shiver, 4] = "reverse";


$NameFX[fade, 1] = "forward";
$NameFX[fade, 2] = "############";
$NameFX[fade, 3] = "############";
$NameFX[fade, 4] = "############";
$NameFX[fade, 5] = "#######m####";
$NameFX[fade, 6] = "#######m##e#";
$NameFX[fade, 7] = "#####]#m##e#";
$NameFX[fade, 8] = "##H##]#m##e#";
$NameFX[fade, 9] = "##H##]#mo#e#";
$NameFX[fade, 10] = "##HO#]#mo#e#";
$NameFX[fade, 11] = "[#HO#]#mo#e#";
$NameFX[fade, 12] = "[#HO#]#moke#";
$NameFX[fade, 13] = "[#HOP]#moke#";
$NameFX[fade, 14] = "[#HOP]#mokey";
$NameFX[fade, 15] = "[NHOP]#mokey";
$NameFX[fade, 16] = "[NHOP]Smokey";
$NameFX[fade, 17] = "[NHOP]Smokey";
$NameFX[fade, 18] = "[NHOP]Smokey";
$NameFX[fade, 19] = "reverse";














//=======================================================================================
//=======================================================================================
//=======================================================================================
//======================================      TESTING  STUFF    =========================
//=======================================================================================
//=======================================================================================
//=======================================================================================



function Nappy::Test::CheckForCommand(%clientId,%message)
{
	%Nappy::ChatRemote::Command = GetWord(%message,0);

	if(%Nappy::ChatRemote::Command == "#move"){
		Nappy::Move(%clientId);
		return 1;
	}
	if(%Nappy::ChatRemote::Command == "#MaxDamage"){
		Nappy::TestDamage(%clientId);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#setPos1"){
messageall(1,"setting position");
		Nappy::Pos::Set(%clientId);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#goToPos1"){
messageall(1,"moving to " @ %clientId.testPos);
		Nappy::Pos::Go(%clientId);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#position"){
		Nappy::PositionCheck(%clientId);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#tele"){
		Nappy::Teleport::Test(%clientId, %message);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#supply"){
		%item = GetWord(%message,1);
		%num = GetWord(%message,2);
		if(%clientId.NappyDuel == "duel")
			Nappy::Supply(%clientId, %item, %num);
		return 1;
	}
	else
		return 0;
}



//==============================================================================================







function Nappy::TestDamage(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	%armor = Player::getArmor(%player);

	%MaxDamage = %armor.maxDamage - 0.01;

	GameBase::setDamageLevel(%player,%MaxDamage);
}






function Nappy::PositionCheck(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	%position = GameBase::getPosition(%player);
	Client::sendMessage(%clientId,3,%position);
	%rotation = GameBase::getRotation(%player);
	Client::sendMessage(%clientId,3,%rotation);
}




function Nappy::Teleport::Test(%clientId, %message)
{
	%direction1 = GetWord(%message,1);
	%distance1 = GetWord(%message,2);
	%direction2 = GetWord(%message,3);
	%distance2 = GetWord(%message,4);
	%direction3 = GetWord(%message,5);
	%distance3 = GetWord(%message,6);

	if(%direction1 == "north"){
		%vecOffset1 = %distance1;
	}
	else if(%direction1 == "south"){
		%vecOffset1 = "-" @ %distance1;
	}

	if(%direction2 == "east"){
		%vecOffset2 = %distance2;
	}
	else if(%direction2 == "west"){
		%vecOffset2 = "-" @ %distance2;
	}

	if(%direction3 == "up"){
		%vecOffset3 = %distance3;
	}
	else if(%direction3 == "down"){
		%vecOffset3 = "-" @ %distance3;
	}
	%newVec = %vecOffset2 @ " " @ %vecOffset1 @ " " @ %vecOffset3;
	%player = Client::getOwnedObject(%clientId);
	%playerPos = GameBase::getPosition(%player);
	%pos = Vector::add(%newVec,%playerPos);
	GameBase::setPosition(%player,%pos);
}



function Nappy::Supply(%clientId, %item, %num)
{
	Player::setItemCount(%clientId,%item,%num);
}


function Nappy::Move(%clientId, %player)
{

}




function Nappy::Pos::Set(%clientId)
{
	%player = Client::getOwnedObject(%clientId); 
	%clientId.testPos = GameBase::getPosition(%player);
}


function Nappy::Pos::Go(%clientId)
{
	%player = Client::getOwnedObject(%clientId); 
	%sPos = GameBase::getPosition(%player);
	%fPos = %clientId.testPos;
	Nappy::MoveToPos::Set(%player, %sPos, %fPos);
}

function Nappy::MoveToPos::Set(%player, %start, %finish)
{
	%distance = Vector::getDistance(%start,%finish);
	%difference = Vector::sub(%finish,%start);

	%differenceX = GetWord(%difference,0);
	%differenceY = GetWord(%difference,1);
	%differenceZ = GetWord(%difference,2);

	%offsetX = %differenceX / %distance;
	%offsetY = %differenceY / %distance;
	%offsetZ = %differenceZ / %distance;

	%offset = %differenceX @ " " @ %differenceY @ " " @ %differenceZ;
	//Nappy::MoveToPos::Go(%distance, %start, %offsetX, %offsetY, %offsetZ)
	Nappy::MoveToPos::Go(%player, %distance, %start, %offset);
}


function Nappy::MoveToPos::Go(%player, %distance, %position, %offset)
{
messageall(3,%player @ ", " @ %distance @ ", " @ %position @ ", " @ %offset);
	if(%distance > 1){
		%distance--;
messageall(0,%distance);
		%position = Vector::add(%position,%offset);
		GameBase::setPosition(%player,%position);
		schedule("Nappy::MoveToPos::Go(" @ %player @ ", " @ %distance @ ", " @ %position @ ", " @ %offset @ ");",0.5);
	}
}





