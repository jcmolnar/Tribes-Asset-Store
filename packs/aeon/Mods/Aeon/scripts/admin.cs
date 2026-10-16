function remoteScoresOn(%clientId)
{
	if(!%clientId.menuMode && !%clientId.termMenu && !%clientId.teleMenu)
		Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId,%hold)
{
	%player = Client::getOwnedObject(%clientId);
	%data = GameBase::getDataName(%player.Terminal);
	if($Terminal::menuType[%data] == true || $Terminal::shopType[%data] == true) {
		%player.Terminal.userCount--;
		%player.Terminal = "";
	}
	if(%clientId.giveTarget < 0 || %clientId.giveTarget > 3000)
		%clientId.giveTarget = "";
	%clientId.deposit = "";
	%clientId.withdraw = "";
	%clientId.termMenu = "";
	%clientId.teleMenu = "";
	%clientId.setCashMax = "";
	%clientId.lastTeleMenu = getSimTime();
	Client::cancelMenu(%clientId);
	if($Terminal::exportExit[%data] != false && !%hold)
		Aeon::ExportInfo(%clientId);
}

function remoteVoteYes(%clientId)
{
	//
}

function remoteVoteNo(%clientId)
{
	//
}

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
   {
      if(%ban && !%admin.isSuperAdmin)
         return;
         
      if(%ban)
      {
         %word = "banned";
         %cmd = "BAN: ";
      }
      else
      {
         %word = "kicked";
         %cmd = "KICK: ";
      }
      if(%client.isSuperAdmin)
      {
         if(%admin == -1)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
      }
   }
}

function remoteSelectClient(%clientId, %selId)
{
	%clientId.tries++;
	if(%clientId.tries > 10) {
		if(%clientId.gone)
			return;
		%name = client::getName(%clientId);
		Log::Exploit(%clientId, "Server-Crash", "remoteSelectClient");
		banlist::add(client::getTransportAddress(%clientId), 999);
		kick(%clientId, "You Were Kicked For Spamming remoteSelectClient");
		%clientId.gone = true;
		return;
	}
	schedule(%clientId@".tries = 0;", 0.5);
	%id = Aeon::getAeonID(%selId);
	if(%clientId.selClient != %selId && !%clientId.isTrade) {
		%clientId.selClient = %selId;
		%cShown = $Aeon::ClientInfo[%id,"pref","cShown"];
		if(%cShown == -1 || %cShown == "")
			%cShown = $Aeon::ClientInfo[%id,pref,cShown] = 1;
		if(%cShown != 400)
			%cShown *= $Aeon::ClientInfo[%id,cash];
		if(%clientId.isAdmin || %clientId == %selId)
			%cShown = $Aeon::ClientInfo[%id,cash];
		if(%cShown > 100000)
			%cash = Aeon::cashStr(%cShown);
		else
			%cash = "$"@String::cashComma(%cShown);
		%karma = floor($Aeon::ClientInfo[%id,krma]);
		if(%karma > 0)
			%karma = "+"@%karma;
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);
		%curLine = 0;
		remoteEval(%clientId,"setInfoLine",%curLine++,"Player Stats for "@Client::getName(%selId) @ ":");
		remoteEval(%clientId,"setInfoLine",%curLine++,"Real Name: "@$Client::info[%selId,1]);
		remoteEval(%clientId,"setInfoLine",%curLine++,"Email Addr: "@$Client::info[%selId,2]);
		remoteEval(%clientId,"setInfoLine",%curLine++,"Alias: "@$Aeon::ClientInfo[%id,cNam]);
		remoteEval(%clientId,"setInfoLine",%curLine++,"Cash: "@%cash);
		if(%clientId.isAdmin || %clientId.isSuperAdmin)
			remoteEval(%clientId,"setInfoLine",%curLine++,Client::getTransportAddress(%selId));
		else
			remoteEval(%clientId,"setInfoLine",%curLine++,"Karma: "@%karma);			
	}
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
	      return;
	if(%clientId.observerMode == "justJoined") {
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}
	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) {
		if(Observer::enterObserverMode(%clientId)) {
			%clientId.notready = "";
			if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			else
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
			Game::refreshClientScore(%clientId);
			%clientId.observerMode = "observe";
		}
		return;
	}
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	%clientId.observerMode = "";
	GameBase::setTeam(%clientId,0);
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId,-1);
	Game::playerSpawn(%clientId,true);
}

function SayFunc::clientName(%clientId,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	%msg = AeonStr::trim(AeonStr::replace(%msg,"~",""));
	if(String::containBadChars(%message)) {
		bottomPrint2(%clientId,"<jc><f1>That name will not work, try again.",2,"C_BuySell.wav");
		return false;
	}
	else if(AeonStr::Len(%msg) > 20) {
		bottomPrint2(%clientId,"<jc><f1>That name exceeds the 20 charector maximum, try again.",2,"C_BuySell.wav");
		%clientId.nextMsg = "clientName";
	}
	else {
		if(Aeon::customChatNameCheck(%clientId,%msg) == "false") {
			if(String::empty(%msg) != true) {	
				$Aeon::ClientInfo[%id,cNam] = %msg;
				bottomPrint(%clientId,"<jc><f1>Your new custom-chat name is <f3>"@$Aeon::ClientInfo[%id,cNam]@"<f1>.",2);
				Aeon::ExportInfo(%clientId);
				Game::refreshClientScore(%clientId);
			}
			else
				bottomPrint2(%clientId,"<jc><f1>Please enter a valid name.",2,"C_BuySell.wav");			
		}
		else
			bottomPrint2(%clientId,"<jc><f1>That name is already in use, please choose another.",2,"C_BuySell.wav");
	}
}

function Aeon::customChatNameCheck(%clientId,%name,%join)
{
	%id = Aeon::getAeonID(%cl);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(%cl == %clientId) {
			//-Nothing
		}
		else if(%join) {
			if(String::ICompare($Aeon::ClientInfo[%id,cNam],%name) == 0)
				return true;
		}
		else {
			if(String::ICompare(Client::getName(%cl),%name) == 0)
				return true;
		}
	}
	return false;
}

function Game::menuRequest(%clientId)
{
	%clientId.gtries++;
	if(%clientId.gtries > 10) {
		if(%clientId.gone)
			return;
		%name = Client::getName(%clientId);
		Log::Exploit(%clientId, "Server-Crash", "remoteScoresOn");
		banlist::add(client::getTransportAddress(%clientId), 999);
		kick(%clientId, "You Were Kicked For Spamming remoteScoresOn");
		%clientId.gone = true;
		return;
	}

	schedule(%clientId@".gtries = 0;", 0.5);
	if(%clientId.menuLock)
		return;

	if(%clientId.isTrade) {
		processMenuTradeList(%clientId,%clientId.isTrade);
		return;
	}

	%clientId.lastMenuBuildTime = getSimTime();
	%curItem = -1;
	%clientId.inMenu = true;
	Client::buildMenu(%clientId, "Options", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Catalog*", "catalog");
	if(%clientId.allowObs || %clientId.isAdmin || %clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "Join/Observe", "changeteams");
	if(%clientId.selClient) {
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		if(%clientId.isAdmin)
			Client::addMenuItem(%clientId,%curItem++@"Administrate on "@%name,"admMenu "@%sel);
		if(%clientId != %sel) {
			Client::addMenuItem(%clientId,%curItem++@"Options for "@%name,"selOpts "@%sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId,%curItem++@"Observe "@%name,"observe "@%sel);
		}
	}
	Client::addMenuItem(%clientId,%curItem++@"Profile Options","profileOpts");
	Client::addMenuItem(%clientId,%curItem++@"Manually Save Stats","saveStats");
	//if(%clientId.isAdmin)
	//	Client::addMenuItem(%clientId,%curItem++@"Admin Options","teleway");
}

function processMenuOptions(%clientId, %option)
{
	if(getSimTime() - %clientId.lastMenuProcTime < 0.3)
		return;
	%clientId.lastMenuProcTime = getSimTime();
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%id = Aeon::getAeonID(%clientId);
	%idSel = Aeon::getAeonID(%cl);
	%name = Client::getName(%cl);
	if(%opt == "catalog") {
		if(!$matchStarted || !$Server::TourneyMode) {
			%curItem = -1;
			Client::buildMenu(%clientId,"Catalog Sections:", "catOpts", true);
			Client::addMenuItem(%clientId,%curItem++@"Post Order","PO");
			Client::addMenuItem(%clientId,%curItem++@"Real Estate","RE");
			Client::addMenuItem(%clientId,%curItem++@"Read Classified","RC");
			if(Classifieds::getPostCount(%id) < $Aeon::maxPost)
				Client::addMenuItem(%clientId,%curItem++@"Post Classified","PC");
			if(Classifieds::getPostCount(%id) > 0)
				Client::addMenuItem(%clientId,%curItem++@"Delete Classified","DC");
			return;
		}
	}
	else if(%opt == "changeteams") {
		if(!%clientId.allowObs && !%clientId.isAdmin && !%clientId.isSuperAdmin)
			return;
		if(Vector::speed(Client::getOwnedObject(%clientId)) == 0) {
			if(getSimTime() > %clientId.lastSwitch+10) {
				Client::buildMenu(%clientId, "Join/Observe:", "PickTeam", true);
				if(GameBase::getTeam(%clientId) == 0)
					Client::addMenuItem(%clientId,"0Observe", -2);
				else
					Client::addMenuItem(%clientId,"0Join", -1);
				%clientId.lastSwitch = getSimTime();
				return;
			}
			else
				bottomPrint(%clientId,"<jc><f2>You must wait "@floor(10-(getSimTime()-%clientId.lastSwitch))@" seconds before you can switch again.",5);
		}
		else
			bottomPrint(%clientId,"<jc><f2>You cannot Join/Observe while moving.",5);
	}
	else if(%opt == "saveStats") {
		%player = Client::getOwnedObject(%clientId);
		if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %player.outArea || (getSimTime() - %clientId.lastSaveTime < 1.0))
			bottomPrint2(%clientId,"<jc><f1>Sorry, you could not save your stats, try again later.",2,"C_BuySell.wav");
		else {
			Aeon::exportInfo(%clientId,true);
			%msg = "<jc><f2>Your Stats Have Been Saved.";
			bottomPrint2(%clientId,%msg,1,"","rLight00.bmp jc 15");
			schedule("bottomPrint2("@%clientId@",\""@%msg@"\",1,\"\",\"rLight01.bmp jc 15\");",0.1,%clientId);
			schedule("bottomPrint2("@%clientId@",\""@%msg@"\",1,\"\",\"rLight02.bmp jc 15\");",0.2,%clientId);
			schedule("bottomPrint2("@%clientId@",\""@%msg@"\",1,\"\",\"rLight03.bmp jc 15\");",0.3,%clientId);
			schedule("bottomPrint2("@%clientId@",\""@%msg@"\",1,\"mine_act.wav\",\"rLight04.bmp jc 15\");",0.4,%clientId);
			%clientId.lastSaveTime = getSimTime();
		}
		if(%cl == rem)
			return;
	}
	else if(%opt == "profileOpts") {
		%curItem = 0;
		Client::buildMenu(%clientId, "Profile Options", "options", true);
		Client::addMenuItem(%clientId,%curItem++@"Change Name","name");
		Client::addMenuItem(%clientId,%curItem++@"Change Text Color","textColor");
		Client::addMenuItem(%clientId,%curItem++@"Change Wealth Shown","wealthShown");
		Client::addMenuItem(%clientId,%curItem++@"Change Read Scroll Speed","scrSpeed");
		Client::addMenuItem(%clientId,%curItem++@"Set Spawn Preference","spwnPref");
		Client::addMenuItem(%clientId,%curItem++@"Login Information","loginOpts");
		return;
	}
	else if(%opt == "name") {
		bottomPrint(%clientId,"<jc><f2>Please type in your desired name on the global chat now.",2);
		%clientId.nextMsg = "clientName";
		return;
	}
	else if(%opt == "textColor") {
		if(%cl != -1) {
			$Aeon::ClientInfo[%id,pref,txtClr] = floor(%cl); // PORT: was any word the client sent
			Aeon::ExportInfo(%clientId);
			Game::menuRequest(%clientId);
			return;
		}
		%clr = $Aeon::ClientInfo[%id,pref,txtClr];
		%color = "Green";
		if(%clr == 0)
			%color = "White";
		else if(%clr == 1)
			%color = "Red";
		else if(%clr == 2)
			%color = "Yellow";
		else if(%clr == 3)
			%color = "Green";
		Client::buildMenu(%clientId, "Custom-Chat Color: "@%color,"options", true);
		Client::addMenuItem(%clientId,"0White","textColor 0");
		Client::addMenuItem(%clientId,"1Red","textColor 1");
		Client::addMenuItem(%clientId,"2Yellow","textColor 2");
		Client::addMenuItem(%clientId,"3Green","textColor 3");
		return;
	}
	else if(%opt == "wealthShown") {
		if(%cl != -1) {
			$Aeon::ClientInfo[%id,"pref","cShown"] = %cl;
			Aeon::ExportInfo(%clientId);
			Game::menuRequest(%clientId);
			return;
		}
		%cShown = $Aeon::ClientInfo[%id,pref,cShown];
		if($Aeon::ClientInfo[%id,pref,cShown] == "")
			$Aeon::ClientInfo[%id,pref,cShown] = 1;
		%prcnt = "";
		%mult = 1;
		if(%cShown >= 0 && %cShown <= 1) {
			%prcnt = "%";
			%mult = 100;
		}
		Client::buildMenu(%clientId, "Wealth Shown: "@%prcnt@%mult*%cShown,"options", true);
		Client::addMenuItem(%clientId,"0%100 (Default)","wealthShown 1");
		Client::addMenuItem(%clientId,"1%75","wealthShown 0.75");
		Client::addMenuItem(%clientId,"2%50","wealthShown 0.50");
		Client::addMenuItem(%clientId,"3%25","wealthShown 0.25");
		Client::addMenuItem(%clientId,"4%0-Hide Money-","wealthShown 0");
		Client::addMenuItem(%clientId,"5Always 400","wealthShown 400");
		return;
	}
	else if(%opt == "scrSpeed") {
		if(%cl != -1) {
			$Aeon::ClientInfo[%id,pref,scrSpd] = floor(%cl); // PORT: was any word the client sent
			Aeon::ExportInfo(%clientId);
			Game::menuRequest(%clientId);
			return;
		}
		Client::buildMenu(%clientId, "Reading Scroll Speed: "@$Aeon::ClientInfo[%id,pref,scrSpd],"options", true);
		Client::addMenuItem(%clientId,"11 second","scrSpeed 1");
		Client::addMenuItem(%clientId,"22 seconds","scrSpeed 2");
		Client::addMenuItem(%clientId,"33 seconds","scrSpeed 3");
		Client::addMenuItem(%clientId,"55 seconds","scrSpeed 5");
		Client::addMenuItem(%clientId,"77 seconds","scrSpeed 7");
		Client::addMenuItem(%clientId,"99 seconds","scrSpeed 9");
		return;
	}
	else if(%opt == "spwnPref") {
		if(%cl != -1) {
			if(%cl != "random" && %cl != "myProp") {
				if(Aeon::spawnPref(%clientId,%cl) != false)
					return;
			}
			else
				$Aeon::ClientInfo[%id,pref,SpwnTp] = %cl;
			Aeon::ExportInfo(%clientId);
			Game::menuRequest(%clientId);
			return;
		}
		%curItem = 0;
		Client::buildMenu(%clientId, "Spawn Location Pref: "@$SpwnTDesc[$Aeon::ClientInfo[%id,pref,SpwnTp]],"options", true);
		Client::addMenuItem(%clientId,%curItem++@$SpwnTDesc[lstLoc],"spwnPref lstLoc");
		Client::addMenuItem(%clientId,%curItem++@$SpwnTDesc[lastMS],"spwnPref lastMS");
		if($Aeon::ClientInfo[%id,ownP] > 0)
			Client::addMenuItem(%clientId,%curItem++@$SpwnTDesc[myProp],"spwnPref myProp");
		Client::addMenuItem(%clientId,%curItem++@$SpwnTDesc[hereMk],"spwnPref hereMk");
		Client::addMenuItem(%clientId,%curItem++@$SpwnTDesc[random]@" (default)","spwnPref random");
		return;
	}
	else if(%opt == "loginOpts") {
		if(%cl == "newPW") {
			bottomPrint(%clientId,"<jc><f1>Please input your desired profile password, <f2>NOTE:<f1> remember or write this password down, you will need to enter it each time you connect.",10);
			%clientId.nextMsg = "getPW new";
			return;
		}
		%curItem = 0;
		Client::buildMenu(%clientId, "Login Information:", "options", true);
		Client::addMenuItem(%clientId,%curItem++@"Change Login Password","loginOpts newPW");
		return;
	}
	else if(%opt == "admMenu" && %clientId.isAdmin) {
		%curItem = 0;
		Client::buildMenu(%clientId, "Administrative Options:", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Kick "@%name,"kick "@%cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Slap "@%name,"slap "@%cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Teleport","tele "@%cl);
		if(%clientId.isSuperAdmin) {
			Client::addMenuItem(%clientId, %curItem++ @ "Change "@%name@" Stats", "admStatMenu "@%cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban "@%cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin "@%cl);
		}
		return;
	}
	else if(%opt == "admStatMenu" && %clientId.isSuperAdmin) {
		%curItem = 0;
		Client::buildMenu(%clientId, %name@"'s Stat's Options:", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Give "@%name@" Cash", "giveMoney "@%cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Give "@%name@" Karma", "giveKarma "@%cl);
		if(%cl.noSuicide)
			Client::addMenuItem(%clientId, %curItem++ @ "Allow "@%name@" suicides", "admSuic "@%cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Don't allow "@%name@" suicides", "admNoSuic "@%cl);
		if(%cl.allowObs)
			Client::addMenuItem(%clientId, %curItem++ @ "Don't allow "@%name@" observer", "admNoObsv "@%cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Allow "@%name@" observer", "admObsv "@%cl);
		if(%cl.adminMuted)
			Client::addMenuItem(%clientId, %curItem++ @ "Admin Unmute "@%name, "admUnMute "@%cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Admin Mute "@%name, "admMute "@%cl);
		return;
	}
	else if(%opt == "giveMoney" && %clientId.isSuperAdmin) {
		%amt = getWord(%option,2);
		if(%amt == "Done")
			return;
		else {
			if(%amt == -1)
				%amt = 0;
			%cash = $Aeon::ClientInfo[%idSel,cash] += %amt;
			$Aeon::ClientInfo[%id,cGiv] += %amt;
			if(%amt > 0)
				Client::sendMessage(%cl,0,Client::getName(%clientId)@" gave you $"@%amt@"!~wflagcapture.wav");
			else if(%amt < 0)
				Client::sendMessage(%cl,0,Client::getName(%clientId)@" gave you $"@%amt@"!~wflagreturn.wav");
			Aeon::exportInfo(%cl);
			%cShown = $Aeon::ClientInfo[%idSel,pref,cShown];
			if(%cShown == -1 || %cShown == "")
				%cShown = $Aeon::ClientInfo[%idSel,pref,cShown] = 1;
			if(%cShown != 400)
				%cShown *= $Aeon::ClientInfo[%idSel,cash];
			if(%clientId.isAdmin)
				%cShown = $Aeon::ClientInfo[%idSel,cash];
			%cash = Aeon::cashStr(%cShown);
			remoteEval(%clientId,"setInfoLine",5,"Cash: "@%cash);
		}
		Client::buildMenu(%clientId, "Give "@%name@":", "options", true);
		Client::addMenuItem(%clientId, "0$5000","giveMoney "@%cl@" 5000");
		Client::addMenuItem(%clientId, "1$1000","giveMoney "@%cl@" 1000");
		Client::addMenuItem(%clientId, "2$500","giveMoney "@%cl@" 500");
		Client::addMenuItem(%clientId, "3$100","giveMoney "@%cl@" 100");
		Client::addMenuItem(%clientId, "4$50","giveMoney "@%cl@" 50");
		Client::addMenuItem(%clientId, "5-$50","giveMoney "@%cl@" -50");
		Client::addMenuItem(%clientId, "6Done","giveMoney "@%cl@" Done");
		return;		
	}
	else if(%opt == "giveKarma" && %clientId.isSuperAdmin) {
		%amt = getWord(%option,2);
		if(%amt == "Done")
			return;
		else if(%amt != -1) {
			if(%amt == "neg1")
				%amt = -1;
			else if(%amt == "neg5")
				%amt = -5;
			Karma::level(%idSel,%amt);
			//$Aeon::ClientInfo[%idSel,krma] += %amt;
			$Aeon::ClientInfo[%id,kGiv] += %amt;
			Client::sendMessage(%cl,0,Client::getName(%clientId)@" gave you "@%amt@" Karma!");
			Aeon::exportInfo(%cl);
			if(!%clientId.isAdmin && !%clientId.isSuperAdmin)
				remoteEval(%clientId,"setInfoLine",6,"Karma: "@floor($Aeon::ClientInfo[%idSel,krma]));
			Game::refreshClientScore(%cl);
			Game::refreshClientScore(%clientId);
		}
		Client::buildMenu(%clientId, "Give "@%name@":", "options", true);
		Client::addMenuItem(%clientId, "0+5 Karma","giveKarma "@%cl@" 5");
		Client::addMenuItem(%clientId, "1+1 Karma","giveKarma "@%cl@" 1");
		Client::addMenuItem(%clientId, "2-1 Karma","giveKarma "@%cl@" neg1");
		Client::addMenuItem(%clientId, "3-5 Karma","giveKarma "@%cl@" neg5");
		Client::addMenuItem(%clientId, "4Done","giveKarma "@%cl@" Done");
		return;
	}
	else if(%opt == "slap" && %clientId.isAdmin) {
		bottomPrint(%cl,"<jc>SLAP!");
		playSound(bigExplosion1,GameBase::getPosition(%cl));
		Player::Slap(%cl,%clientId,500*getRandom(),Player::getLookRot(Client::getOwnedObject(%clientId),""));
	}
	else if(%opt == "admSuic" && %clientId.isSuperAdmin) {
		%cl.noSuicide = "";
		bottomPrint(%clientId,"<jc><f2>"@Client::getName(%cl)@" can now suicide.",5);
	}
	else if(%opt == "admNoSuic" && %clientId.isSuperAdmin) {
		%cl.noSuicide = "true";
		bottomPrint(%clientId,"<jc><f2>"@Client::getName(%cl)@" can no longer suicide.",5);
	}
	else if(%opt == "admObsv" && %clientId.isSuperAdmin) {
		%cl.allowObs = "true";
		bottomPrint(%clientId,"<jc><f2>"@Client::getName(%cl)@" can now be an Observer.",5);
	}
	else if(%opt == "admNoObsv" && %clientId.isSuperAdmin) {
		%cl.allowObs = "";
		bottomPrint(%clientId,"<jc><f2>"@Client::getName(%cl)@" can no longer be an Observer.",5);
	}
	else if(%opt == "admMute" && %clientId.isSuperAdmin) {
		%cl.adminMuted = true;
		messageAll(0,Client::getName(%cl)@" has been muted by Admin.");
	}
	else if(%opt == "admUnMute" && %clientId.isSuperAdmin) {
		%cl.adminMuted = "";
		messageAll(0,Client::getName(%cl)@" has been unmuted by Admin.");
	}
	else if(%opt == "selOpts") {
		%sel = getWord(%option,2);
		%selId = Aeon::getAeonId(%sel);
		if(%cl == "privChatStart") {
			%clientId.privChat = %sel;
			%sel.privChat = %clientId;
			bottomPrint(%clientId,"<jc><f3>Private Chat with "@Client::getName(%sel)@" initiated (Use Team/Custom-Chat).",5);
			bottomPrint(%sel,"<jc><f3>"@Client::getName(%clientId)@" initiated Private Chat with you (Use Team/Custom-Chat).",5);
			return;
		}
		else if(%cl == "privChatEnd") {
			%clientId.privChat = "";
			%sel.privChat = "";
			bottomPrint(%clientId,"<jc><f3>Private Chat with "@Client::getName(%sel)@" ended.",5);
			bottomPrint(%sel,"<jc><f3>Private Chat with "@Client::getName(%clientId)@" ended.",5);
		}
		else if(%cl == "prms") {
			%prms = $Aeon::ClientInfo[%selId,prms,%id];
			%name = Client::getName(%sel);
			%amt = getWord(%option,3);
			if(%amt != -1) {
				if(String::findSubStr(%amt,"neg") == 0)
					%amt = String::getSubStr(%amt,3,2)*-1;
				if(%amt > 2) %amt = 2; // PORT (2026-10-12): the menu offers -2..+2; the reply is not limited to that
				if(%amt < -2) %amt = -2;
				%prms = $Aeon::ClientInfo[%selId,prms,%id] = $Aeon::ClientInfo["[\""@%selId@"\",\"prms\",\""@%id@"\"]"] += %amt;
				Aeon::ExportInfo(%sel);
				bottomPrint(%sel,"<jc><f3>"@Client::getName(%clientId)@" allowed you Permission Level "@%prms@".",5);
			}
			%curItem = 0;
			Client::buildMenu(%clientId,%name@"'s Permission: "@%prms,"options",true);
			if(%prms < 8)
				Client::addMenuItem(%clientId, %curItem++@"+2 Levels","selOpts prms "@%sel@" 2");
			if(%prms < 9)
				Client::addMenuItem(%clientId, %curItem++@"+1 Level","selOpts prms "@%sel@" 1");
			if(%prms >= 1)
				Client::addMenuItem(%clientId, %curItem++@"-1 Level","selOpts prms "@%sel@" neg1");
			if(%prms >= 2)
				Client::addMenuItem(%clientId, %curItem++@"-2 Levels","selOpts prms "@%sel@" neg2");
			Client::addMenuItem(%clientId, %curItem++@"Done","selOpts done");
			Permission::showInfo(%clientId,%prms,%selId);
			return;
		}
		else if(%cl == "mute") {
			%clientId.muted[%sel] = true;
		}
		else if(%cl == "unmute") {
			%clientId.muted[%sel] = "";
		}
		else if(%cl == "done")
			return;
		else
			%sel = %cl;
		%name = Client::getName(%sel);
		%curItem = 0;
		Client::buildMenu(%clientId,"Options for: "@Client::getName(%sel),"options",true);
		if(%clientId.privChat)
			Client::addMenuItem(%clientId,%curItem++@"End Chat with "@Client::getName(%clientId.privChat),"selOpts privChatEnd "@%sel);
		else
			Client::addMenuItem(%clientId,%curItem++@"Private Chat with "@%name,"selOpts privChatStart "@%sel);
		if($Aeon::ClientInfo[%id,ownP] != "")
			Client::addMenuItem(%clientId,%curItem++@%name@"'s permission","selOpts prms "@%sel);
		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId,%curItem++@"Unmute "@%name,"selOpts unmute "@%sel);
		else
			Client::addMenuItem(%clientId,%curItem++@"Mute "@%name,"selOpts mute "@%sel);
		Client::addMenuItem(%clientId,%curItem++@"Done","selOpts done");
		return;
	}
	else if(%opt == "kick" && %clientId.isAdmin) {
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick "@%name, "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick "@%name, "no " @ %cl);
		return;
	}
	else if(%opt == "tele" && %clientId.isAdmin) {
		%curItem = 0;
		Client::buildMenu(%clientId, "Teleport:", "topt", true);
		Client::addMenuItem(%clientId, %curItem++@"To "@%name, "1 "@%cl);
		Client::addMenuItem(%clientId, %curItem++@%name@" to you", "2 "@%cl);
		if($Aeon::ClientInfo[%id,WayP] != "")
			Client::addMenuItem(%clientId, %curItem++@"To current waypoint", "3 "@%cl);
		return;
	}
	else if(%opt == "admin" && %clientId.isSuperAdmin) {
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin "@%name, "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin "@%name, "no " @ %cl);
		return;
	}
	else if(%opt == "ban" && %clientId.isSuperAdmin) {
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban "@%name, "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban "@%name, "no " @ %cl);
		return;
	}
	else if(%opt == "reset" && %clientId.isSuperAdmin) {
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}
	else if(%opt == "observe" && (%clientId.allowObs || %clientId.isAdmin || %clientId.isSuperAdmin)) {
		Observer::setTargetClient(%clientId, %cl);
		return;
	}
	Game::menuRequest(%clientId);
}

function Permission::showInfo(%clientId,%prms,%id2)
{
	if(%prms > 9) %prms = 9; // PORT (2026-10-12): there are nine permission levels; bounds the loop below
	%line = 0;
	%head = "-----------------------Permission-----------------------";
	remoteEval(%clientId,"setInfoLine",%line++,%head);
	remoteEval(%clientId,"setInfoLine",%line++,"Permission Level \""@%prms@"\" allows for:");
	%str = "";

	for(%i = %prms; %i >= 1; %i--) {

		if(AeonStr::len(%str) < 35)
			%str = %str@$Aeon::PermDesc[%i];
		else {
			remoteEval(%clientId,"setInfoLine",%line++,%str);
			%str = $Aeon::PermDesc[%i];
		}
	}
	if(AeonStr::len(%str) > 0)
		remoteEval(%clientId,"setInfoLine",%line++,%str);	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	//Aeon::exportInfo(%cl);
	return;
}

function processMenuKAffirm(%clientId, %opt)
{
	%id = Aeon::getAeonID(%clientId);
	if(getWord(%opt, 0) == "yes") {
		$Aeon::ClientInfo[%id,kCnt]++;
		Admin::kick(%clientId,getWord(%opt,1));
	}
	Game::menuRequest(%clientId);
}

function processMenuTOpt(%clientId, %opt)
{
	%id = Aeon::getAeonID(%clientId);
	%targ = getWord(%opt,1);
	%tPos = GameBase::getPosition(%targ);
	%pPos = GameBase::getPosition(%clientId);
	if(getWord(%opt,0) == "1")
		GameBase::setPosition(%clientId,Vector::add(%tPos,"0 0 5"));
	else if(getWord(%opt,0) == "2")
		GameBase::setPosition(%targ,Vector::add(%pPos,"0 0 5"));
	else if(getWord(%opt,0) == "3") {
		%wp = wayPointToWorld($Aeon::ClientInfo[%id,WayP]);
		%wp = getWord(%wp,0)@" "@getWord(%wp,1)@" "@Property::terrainHeight(%wp);
		GameBase::setPosition(%targ,%wp);
	}
}

function processMenuBAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::kick(%clientId, getWord(%opt, 1), true);
	Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes") {
		if(%clientId.isSuperAdmin) {
			%cl = getWord(%opt, 1);
			%cl.isAdmin = true;
			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
	if(%opt == "yes" && %clientId.isAdmin) {
		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}

function bottomPrint2(%clientId,%msg,%dur,%wav,%image1,%image2)
{
	if(%wav != "" && %wav != -1 && %wav != false) {
		if(AeonStr::ends(%wav,".wav") != "true")
			%wav = AeonStr::trim(%wav)@".wav";
		Client::sendMessage(%clientId,0,"~w"@%wav);
	}
	if(%image1 != "" && %image1 != -1 && %image1 != false) {
		%bmp = getWord(%image1,0);
		if(AeonStr::ends(%bmp,".bmp") != "true")
			%bmp = AeonStr::trim(%bmp)@".bmp";
		%js = "<jl>";
		%xPs = getWord(%image1,1);
		if(%xPs == "jc") {
			%xPs = 0;
			%js = "<jc>";
		}
		%yPs = getWord(%image1,2);
		%msg = %msg@%js@"<B"@%xPs@","@%yPs@":"@%bmp@">";
	}
	if(%image2 != "" && %image2 != -1 && %image2 != false) {
		%bmp = getWord(%image2,0);
		if(AeonStr::ends(%bmp,".bmp") != "true")
			%bmp = AeonStr::trim(%bmp)@".bmp";
		%js = "<jl>";
		%xPs = getWord(%image2,1);
		if(%xPs == "jc") {
			%xPs = 0;
			%js = "<jc>";
		}
		%yPs = getWord(%image2,2);
		%msg = %msg@%js@"<B"@%xPs@","@%yPs@":"@%bmp@">";
	}
	bottomPrint(%clientId,%msg,%dur);
}