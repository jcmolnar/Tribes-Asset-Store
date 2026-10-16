$Aeon::tradeDistance = 5.0;

function Trade::checkTrade(%player)
{
	if($matchStarted) {
		%client = Player::getClient(%player);
		if(GameBase::getLOSInfo(%player,5)) {
			%obj = $los::object;
			$los::object = "";
			if(!%client.rqTrade && !%client.isTrade && !%obj.isTrade && getObjectType(%obj) == "Player" && getSimTime() > %client.lastRQtime && Vector::speed(%obj) < 0.5) {
				%ClObj = Player::getClient(%obj);
				bottomPrint(%client,"<jc><f3>Requesting Trade with <f2>"@Client::getName(%ClObj)@"<f3>.",1.5);
				bottomPrint(%ClObj,"<jc><f2>"@Client::getName(%client)@"<f3> is requesting trade with you.",1.5);
				%client.rqTrade = %ClObj;
				Client::buildMenu(%ClObj,"Trade with "@Client::getName(%client)@"?","tradeRequest",false);
				Client::addMenuItem(%ClObj,"1Yes","yes "@%client);
				Client::addMenuItem(%ClObj,"2No","no "@%client);
				return;
			}
		}
		if((%obj = %client.isTrade) && getSimTime() > %client.lastRQtime) {
			Trade::end(%client,%client.isTrade);
		}
	}
}

function processMenuTradeRequest(%clientId,%opt)
{
	%op1 = getWord(%opt,0);
	%op2 = getWord(%opt,1);
	if(%op1 == "yes") {
		Trade::initTrade(%clientId,%op2);
		%op2.lastRQtime = getSimTime()+5;
	}
	else {
		bottomPrint(%op2,"<jc><f2>"@Client::getName(%clientId)@"<f3> declined to trade.",1.5);
		%clientId.rqTrade = "";
		%op2.rqTrade = "";
		%op2.lastRQtime = getSimTime()+10;
	}
}

function Trade::initTrade(%client1,%client2)
{
	echo("Trade initiated: "@%client1@", "@%client2);
	bottomPrint(%client1,"<jc><f3>Initiated Trade with <f2>"@Client::getName(%client2)@"<f3>.",1.5);
	bottomPrint(%client2,"<jc><f3>Initiated Trade with <f2>"@Client::getName(%client1)@"<f3>.",1.5);
	%client1.rqTrade = "";
	%client2.rqTrade = "";
	%client1.isTrade = %client2;
	%client2.isTrade = %client1;
	%client1.tempTrade1 = "";
	%client1.tempTrade2 = "";
	%client1.tempTradeC = 0;
	%client2.tempTrade1 = "";
	%client2.tempTrade2 = "";
	%client2.tempTradeC = 0;
	processMenuTradeList(%client1,%client2);
	processMenuTradeList(%client2,%client1);
	Trade::loopCheck(%client1,%client2);
}

function processMenuTradeList(%client1,%opt)
{
	%client2 = getWord(%opt,0);
	Trade::showInfo(%client1,%client2);
	%id2 = Aeon::getAeonID(%client2);
	%opt1 = getWord(%opt,1);
	%opt2 = getWord(%opt,2);
	%opt3 = getWord(%opt,3);
	%opt4 = getWord(%opt,4);
	%opt5 = getWord(%opt,5);
	%opt6 = getWord(%opt,6);
	if(%opt1 == "tradeCnt") {
		if(%opt4 != -1) {
			%amt = 0;
			if(%opt4 == "request") {
				if(%opt6 == "yes") {
					
					bottomPrint(%client1,"<jc><f3>You accepted the trade with <f2>"@Client::getName(%client2)@"<f3>.",2);
					bottomPrint(%client2,"<jc><f2>"@Client::getName(%client1)@"<f3> accepted the trade with you.",2);
				}
				else if(%opt6 == "no") {
					
					bottomPrint(%client1,"<jc><f3>You declined the trade with <f2>"@Client::getName(%client2)@"<f3>.",2);
					bottomPrint(%client2,"<jc><f2>"@Client::getName(%client1)@"<f3> declined the trade with you.",2);
				}
				%client1.tempTrade1 = "$"@%opt5 * Item::getValue(%opt2,true) + %client1.tempTradeC;
				%client1.tempTrade2 = %opt5@" "@String::Plural($CatalogName[%opt2],%opt5);
				Trade::showInfo(%client1,%client2);
				if(%client1.tempTrade1 && %client2.tempTrade1) {
					Client::buildMenu(%client1,"Trade?","tradeList", true);
					%curItem = -1;
					Client::addMenuItem(%client1,%curItem++@"Yes",%client2@" tradeCnt "@%opt2@" "@%opt3@" request "@%opt5@" yes");
					Client::addMenuItem(%client1,%curItem++@"No",%client2@" tradeCnt "@%opt2@" "@%opt3@" request "@%opt5@" no");
					return;
				}
				else {
					
				}
			}
			else if(%opt4 == "neg1")
				%amt = -1;
			else if(%opt4 == "neg5")
				%amt = -5;
			else
				%amt = %opt4;
			%client1.tempAmt += %amt;
		}
		else
			%client1.tempAmt = 1;
		Client::buildMenu(%client1,"Quantity: "@%client1.tempAmt@" / "@%opt3,"tradeList", true);
		%curItem = -1;
		if(%client1.tempAmt+5 < %opt3)
			Client::addMenuItem(%client1,%curItem++@"+5",%client2@" tradeCnt "@%opt2@" "@%opt3@" 5");
		if(%client1.tempAmt < %opt3)
			Client::addMenuItem(%client1,%curItem++@"+1",%client2@" tradeCnt "@%opt2@" "@%opt3@" 1");
		if(%client1.tempAmt >= 1)
			Client::addMenuItem(%client1,%curItem++@"-1",%client2@" tradeCnt "@%opt2@" "@%opt3@" neg1");
		if(%client1.tempAmt >= 5)
			Client::addMenuItem(%client1,%curItem++@"-5",%client2@" tradeCnt "@%opt2@" "@%opt3@" neg5");
		Client::addMenuItem(%client1,%curItem++@"Back...",%client2);
		Client::addMenuItem(%client1,%curItem++@"Request...",%client2@" tradeCnt "@%opt2@" "@%opt3@" request "@%client1.tempAmt);
		return;
	}
	else if(%opt1 == "addCash") {
		if(%opt2 > 0)
			%client1.tempTradeC = %opt2;
		else {
			processMenuSetCashAmount(%client1);
			return;
		}
	}
	%max = $Aeon::ClientInfo[%id2,"Inv","num"];
	%catNum = 0;
	%start = 1;
	if(%opt1 == "next")
		%start = getWord(%opt,2);
	Client::buildMenu(%client1,Client::getName(%client2)@"'s Stuff:","tradeList",true);
	if(%start == 1)
		Client::addMenuItem(%client1,%catNum++@"Add Cash",%client2@" addCash");
	for(%i = %start; %i <= %max; %i++) {
		%info = $Aeon::ClientInfo["[\""@%id2@"\",\"Inv\",\""@%i@"\"]"];
		%item = getWord(%info,0);
		if(%item.className != "ARMOR" && %item.className != "HandAmmo" && $CatalogName[%item] != "") {
			%count = getWord(%info,1);
			if(%catNum > 4) {
				Client::addMenuItem(%client1,%catNum++@"Next Page...",%client2@" next "@%i);
				break;
			}
			Client::addMenuItem(%client1,%catNum++@$CatalogName[%item]@" [ "@%count@" ]",%client2@" tradeCnt "@%info);
		}
		if(%i == %max)
			Client::addMenuItem(%client1,%catNum++@"Back...",%client2);
	}
	return;
}

function Trade::showInfo(%client1,%client2)
{
	if(%client1.isTrade != %client2 || %client2.isTrade != %client1)
		return false;
	%curLine = 0;
	%for = "-----------------For----------------";
	//%c1ch = "$"@%client1.tempTradeC;
	%c1t1 = %client1.tempTrade1;
	%c1t2 = %client1.tempTrade2;
	//%c2ch = "$"@%client2.tempTradeC;
	%c2t1 = %client2.tempTrade1;
	%c2t2 = %client2.tempTrade2;
	remoteEval(%client1,"setInfoLine",%curLine++,"Trade with "@Client::getName(%client2)@":");
	//remoteEval(%client1,"setInfoLine",%curLine++,%c1ch);
	remoteEval(%client1,"setInfoLine",%curLine++,%c1t1);
	remoteEval(%client1,"setInfoLine",%curLine++,%c1t2);
	remoteEval(%client1,"setInfoLine",%curLine++,%for);
	//remoteEval(%client1,"setInfoLine",%curLine++,%c2ch);
	remoteEval(%client1,"setInfoLine",%curLine++,%c2t1);
	remoteEval(%client1,"setInfoLine",%curLine++,%c2t2);
	
	remoteEval(%client2,"setInfoLine",%curLine++,"Trade with "@Client::getName(%client1)@":");
	remoteEval(%client2,"setInfoLine",%curLine++,%c2t1);
	remoteEval(%client2,"setInfoLine",%curLine++,%c2t2);
	remoteEval(%client2,"setInfoLine",%curLine++,%for);
	remoteEval(%client2,"setInfoLine",%curLine++,%c1t1);
	remoteEval(%client2,"setInfoLine",%curLine++,%c1t2);
	return;
}

function Trade::loopCheck(%client1,%client2)
{
	%pos1 = GameBase::getPosition(%client1);
	%pos2 = GameBase::getPosition(%client2);
	%dist = Vector::getDistance(%pos1,%pos2);
	if(%dist < $Aeon::tradeDist && %client1.isTrade == %client2) {
		schedule("Trade::loopCheck("@%client1@", "@%client2@");",1.0);
	}
	else {
		Trade::end(%client1,%client2);
		return;
	}
}

function Trade::end(%client1,%client2)
{
	echo("Trade Ended: "@%client1@", "@%client2);
	%client1.isTrade = "";
	%client2.isTrade = "";
	Client::cancelMenu(%client1);
	Client::cancelMenu(%client2);
	bottomPrint(%client1,"<jc><f3>Ended Trade with <f2>"@Client::getName(%client2)@"<f3>.",2);
	bottomPrint(%client2,"<jc><f3>Ended Trade with <f2>"@Client::getName(%client1)@"<f3>.",2);
	Trade::calcResult(%client1,%client2);
}

function Trade::calcResult(%client1,%client2)
{
	
}

function Cash::exchange(%client1,%client2,%amt)
{
	%id1 = Aeon::getAeonID(%client1);
	%id2 = Aeon::getAeonID(%client2);
	%client1.setCashMax = "";
	%client1.giveTarget = "";
	%client1.tempAmt = "";
	if((%id2 == "" || %id2 == "@") && %client2 != -1) {
		%data = GameBase::getDataName(%client2);
		if(%data == "Term_Bank") {
			if(%client1.withdraw)
				processMenuBank(%client1,%client2@" withdraw cash "@%amt);
			else
				processMenuBank(%client1,%client2@" deposit cash "@%amt);
		}
		return;
	}
	if(%amt <= 0 || %amt > $Aeon::ClientInfo[%id1,cash]) return; // PORT (2026-10-12): a gift is a positive amount the giver has
	$Aeon::ClientInfo[%id1,cash] -= %amt;
	$Aeon::ClientInfo[%id2,cash] += %amt;
	Game::refreshClientScore(%client1);
	Game::refreshClientScore(%client2);
	bottomPrint2(%client1,"<jc><f3>You just gave "@Client::getName(%client2)@" <f1>$"@String::cashComma(%amt)@"<f3>!",5,"BuySellSound.wav");
	bottomPrint2(%client2,"<jc><f3>"@Client::getName(%client1)@" just gave you <f1>$"@String::cashComma(%amt)@"<f3>!",5,"BuySellSound.wav");
	%client2.given[%client1] = getSimTime();
}

function processMenuSetCashAmount(%clientId,%opt,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	%input = getWord(%opt,0);
	if(%input == -1 || %input == "")
		%clientId.tempAmt = "";
	else if(%input == "cancel") {
		remoteScoresOff(%clientId);
		return;
	}
	else if(%input == "done") {
		if(%clientId.giveTarget) {
			Cash::exchange(%clientId,%clientId.giveTarget,%clientId.tempAmt);
			%clientId.giveTarget = "";
		}
		else if(%clientId.isTrade) {
			processMenuTradeList(%clientId,%clientId.isTrade@" addCash "@%clientId.tempAmt);
			return;
		}
		%clientId.tempAmt = "";
		return;
	}
	else {
		%length = AeonStr::Len(%clientId.tempAmt);
		%max = %clientId.setCashMax;
		if(%max <= 0 || %max == "")
			%max = $Aeon::ClientInfo[%id,cash];
		if(%input == "del") {
			if(%length > 0)
				%clientId.tempAmt = String::getSubStr(%clientId.tempAmt,0,%length-1);
		}
		else if(%length < 20) {
			if(%clientId.tempAmt@%input > %max) {
				bottomPrint2(%clientId,"<jc><f3>You don't have that much money!",1,"C_BuySell.wav");
			}
			else
				%clientId.tempAmt = %clientId.tempAmt@%input;
		}
		else
			bottomPrint2(%clientId,"<jc><f3>Your quantity can't be more than 20 digits long!",1,"C_BuySell.wav");
	}
	if(%clientId.tempAmt == "") {
		if(%msg == "" || %msg < 0)
			%msg = "<jc><f2>Please type in your desired quantity.";
		bottomPrint(%clientId,%msg,5);
	}
	Client::buildMenu(%clientId,"How Much?: $"@String::cashComma(%clientId.tempAmt),"setCashAmount",true);
	Client::addMenuItem(%clientId,"." @">         Done         <","done");
	Client::addMenuItem(%clientId,"\\"@">        Cancel        <","cancel");
	Client::addMenuItem(%clientId,"-" @"    << BackSpace <<","del");
	for(%i = 0; %i <= 9; %i++)
		Client::addMenuItem(%clientId,%i@%i,%i);
	return;
}

function Aeon::cheatCheck(%client1,%client2)
{
	%id1 = Aeon::getAeonID(%client1);
	%id2 = Aeon::getAeonID(%client2);
	%ip1 = Client::getTransportAddress(%client1);
	%ip1 = String::getSubStr(%ip1,0,String::indexOf(%ip1,":",3));
	%ip2 = Client::getTransportAddress(%client2);
	%ip2 = String::getSubStr(%ip2,0,String::indexOf(%ip2,":",3));
	if(String::ICompare(%ip1,%ip2) == 0) {
		$Aeon::ClientInfo[%id1,cash] = 0;
		$Aeon::ClientInfo[%id2,cash] = 0;
		$Aeon::ClientInfo[%id1,krma] -= 10;
		$Aeon::ClientInfo[%id2,krma] -= 10;
		remoteKill(%client1,true);
		remoteKill(%client2,true);
	}
}