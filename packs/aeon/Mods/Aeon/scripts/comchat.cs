$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	if(String::containsCrash(%clientId,%message,"remoteSay"))
		return;
	%msg = %clientId@" \""@escapeString(%message)@"\"";
	%id = Aeon::getAeonID(%clientId);
	if(getSimTime() - %clientId.lastMsgTime < 0.5)
		return;
	%clientId.lastMsgTime = getSimTime();
	if(message == "" || %msg == -1 || AeonStr::len(%message) < 1)
		return;
	if(%clientId.nextMsg != -1 && %clientId.nextMsg != "") {
		%msg = %clientId.nextMsg;
		%func = getWord(%msg,0);
		%wrd2 = getWord(%msg,1);
		//if(String::containBadChars(%message)) {
		//	bottomPrint2(%clientId,"<jc><f3>Fucking lamer!",3,"c_buysell.wav");
		//	return;
		//}
		if(%wrd2 != -1 && %wrd2 != "") {
			%pWd2 = String::indexOf(%msg,%wrd2);
			%rest = String::getSubStr(%msg,%pWd2,40);
			Eval("SayFunc::"@%func@"("@%clientId@",\""@escapeString(%message)@"\",\""@escapeString(%rest)@"\");"); // PORT: both were raw
		}
		else
			Eval("SayFunc::"@%func@"("@%clientId@",\""@escapeString(%message)@"\",5);"); // PORT: was raw
		%clientId.nextMsg = "";
		return;
	}
	if($Aeon::ClientInfo[%id,mute] == true) {
		bottomPrint2(%clientId,"<jc><f3>Until you follow instructions, your chat will remain disabled! Press 'O' and Read!",3,"c_buysell.wav");
		return;
	}
	if(String::findSubStr(%message,"#") == 0) {
		if(String::containBadChars(%message) || String::findSubStr(%message,"(") != -1 || String::findSubStr(%message,")") != -1 || String::findSubStr(%message,";") != -1)
			return;
		%typ = String::getSubStr(%message,1,AeonStr::len(getWord(%message,0))-1);
		if(AeonStr::getWordCount(%message) < 2)
			%message = %message@" true";
		if($sayCommand[%typ] == "true")
			Eval("SayCMD::"@%typ@"("@%clientId@",\""@escapeString(String::getSubStr(%message,String::indexOf(%message,getWord(%message,1)),50))@"\");"); // PORT: was raw
		return;
	}
	if(AeonStr::len(%message) > 80 || String::containBadChars(%message)) {
		bottomPrint2(%clientId,"<jc><f3>Fucking lamer!",3,"c_buysell.wav");
		return;
	}
	if(%clientId.adminMuted)
		return muted;
	if(%clientId.prisonCell) {
		%pos = GameBase::getPosition(%clientId);
		%name = Prison::getName(%clientId);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%dist = Vector::getDistance(%pos,GameBase::getPosition(%cl));
			if(!%cl.muted[%clientId] && %dist < 25)
				Client::sendMessage(%cl,0,%name@": "@%message);
		}
		return;
	}
	if((%message == %clientId.lastMsg && !%clientId.isSuperAdmin)) {
		%clientId.spam++;
		if(%clientId.spam > 2) {
			bottomPrint2(%clientId,"<jc><f1>You have spammed too much!",3,"losttower.wav");
			//$Aeon::ClientInfo[%id,krma] += Karma::getChange(spam);
			%player = Client::getOwnedObject(%clientId);
			if(!Player::isDead(%player) && %player > 0)
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player)+0.1);
		}
		else if(%clientId.spam > 1) {
			bottomPrint2(%clientId,"<jc><f3>Don't spam!",3,"c_buysell.wav");
			%player = Client::getOwnedObject(%clientId);
			if(!Player::isDead(%player) && %player > 0)
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player)+0.1);
		}
		else
			bottomPrint2(%clientId,"<jc><f3>Don't spam!",3,"c_buysell.wav");
	}
	else
		%clientId.spam = 0;
	if($Server::FloodProtectionEnabled) {
		%time = getIntegerTime(true) >> 5;
		if(%clientId.floodMute) {
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0) {
				Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;
		schedule(%clientId@".floodMessageCount--;", 5, %clientId);
		if(%clientId.floodMessageCount > 2 && !%clientId.isSuperAdmin) {
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}
	if(%team && %clientId.spam < 2) {
		if($dedicated)
			echo("SAYCUSTOM: " @ %msg);
		%sel = %clientId.privChat;
		if(%sel != "") {
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
				if(%cl.isAdmin || %cl.isSuperAdmin || %cl ==  %clientId || %cl == %sel) {
					%pm = "";
					if(%cl ==  %clientId || %cl == %sel)
						%pm = "*(Private)* ";
					Client::sendMessage(%cl,0,Client::getName(%clientId)@": "@%pm@%message);
				}
			}
		}
		else {
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
				if(!%cl.muted[%clientId])
					Client::sendMessage(%cl,$Aeon::ClientInfo[%id,pref,txtClr], $Aeon::ClientInfo[%id,cNam]@": "@%message);
			}
		}
	}
	else if(%clientId.spam < 2) {
		if($dedicated)
			echo("SAY: "@%msg);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if(!%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
		}
	}
	%clientId.lastMsg = %message;
}

function Prison::getName(%clientId)
{
	%name = $PrisonName[%clientId];
	if($PrisonName[%clientId] == "") {
		for(%i = 0; %i < 6; %i++) {
			%name = %name@floor(getRandom()*10);
		}
	}
	$PrisonName[%clientId] = %name;
	return "Inmate #"@%name;
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if(String::containsCrash(%commander,%command,"remoteIssueCommand"))
		return;
	%id = Aeon::getAeonID(%commander);
	if($dedicated)
		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	for(%i = 1; %dest[%i] != ""; %i = %i + 1) {
		if(!%dest[%i].muted[%commander]) {
			issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
			$Aeon::ClientInfo[%id,WayP] = %wayX@" "@%wayY;
		}
	}
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if(String::containsCrash(%commander,%command,"remoteIssueTargCommand"))
		return;
	if($dedicated)
		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
	for(%i = 1; %dest[%i] != ""; %i++) {
		if(!%dest[%i].muted[%commander])
			issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
	}
}

function remoteCStatus(%clientId,%status,%message)
{
	if(String::containsCrash(%clientId,%message,"remoteCStatus"))
		return;
	if(setCommandStatus(%clientId, %status, %message)) {
		if($dedicated)
			echo("COMMANDSTATUS: "@%clientId@" \""@escapeString(%message)@"\"");
	}
	else
		remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++) {
		%id = getClientByIndex(%i);
		if(Client::getTeam(%id) == %team1)
			Client::sendMessage(%id,%mtype,%message1);
		else if(%message2 != "" && Client::getTeam(%id) == %team2)
			Client::sendMessage(%id,%mtype,%message2);
		else if(%message3 != "")
			Client::sendMessage(%id,%mtype,%message3);
	}
}

function messageAll(%mtype, %message, %filter)
{
	if(%filter == "")
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Client::sendMessage(%cl, %mtype, %message);
	else {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
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