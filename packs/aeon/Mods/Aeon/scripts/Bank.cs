//- Place Holder file, eventually will house bank structures

function Bank::update(%id)
{
	if($Aeon::Bank[%id] == "")
		return;
	%max = getNumItems();
	$Aeon::Bank["[\""@%id@"\"]"] = $Aeon::Bank[%id];
	$Aeon::Bank["[\""@%id@"\",\"cash\"]"] = $Aeon::Bank[%id,cash];
	for(%i = 0; %i < %max; %i++) {
		%data = getItemData(%i);
		if($Aeon::Bank[%id,inv,%data] <= 0)
			$Aeon::Bank[%id,inv,%data] = "";
		$Aeon::Bank["[\""@%id@"\",\"inv\",\""@%data@"\"]"] = $Aeon::Bank[%id,inv,%data];
	}
}

function Bank::hasAccount(%id)
{
	if($Aeon::Bank[%id] != "")
		return true;
	%file = "AeonBank["@%id@"].cs";
	if(isFile("temp\\"@%file)) {
		exec(%file);
		return true;
	}
	return false;
}

function Bank::invCount(%id)
{
	%count = 0;
	%max = getNumItems();
	for(%i = 0; %i < %max; %i++) {
		%data = getItemData(%i);
		if($Aeon::Bank[%id,inv,%data] > 0)
			%count += $Aeon::Bank[%id,inv,%data];
	}
	return %count;
}

function Term_Bank::onAdd(%this)
{
	$Aeon::InteractFunc[%this] = "Term_Bank";
	Terminal::onAdd(%this);
}

function Term_Bank::onInteract(%this,%player)
{
	Terminal::onCollision(%this,%player,true);
}

function Term_Bank::onItemCatch(%this,%object)
{
	%player = %object.tosser;
	%clientId = Player::getClient(%player);
	%id = Aeon::getAeonID(%clientId);
	if(Bank::hasAccount(%id)) {
		//if(!%clientId.deposit)
		//	return;
		%data = GameBase::getDataName(%object);
		deleteObject(%object);
		if($Aeon::Bank[%id,inv,%data] < 1)
			$Aeon::Bank[%id,inv,%data] = 0;
		$Aeon::Bank[%id,inv,%data]++;
		Aeon::ExportBank(%clientId);
	}
}

function Term_Bank::initMenu(%clientId,%start,%this)
{
	if(%clientId.giveTarget == %this)
		return;
	%clientId.termMenu = true;
	%id = Aeon::getAeonID(%clientId);
	if(%start < 0 || %start == "") {
		%num = 0;
		Client::buildMenu(%clientId,"Savings Account: ","Bank",true);
		if(Bank::hasAccount(%id)) {
			Client::addMenuItem(%clientId,%num++@"Deposit Cash",%this@" deposit cash");
			//Client::addMenuItem(%clientId,%num++@"Deposit Item",%this@" deposit item");
			if($Aeon::Bank[%id,cash] > 0)
				Client::addMenuItem(%clientId,%num++@"Withdraw Cash",%this@" withdraw cash");
			if(Bank::invCount(%id) > 0)
				Client::addMenuItem(%clientId,%num++@"Withdraw Item",%this@" withdraw item");
		}
		else {
			Client::addMenuItem(%clientId,%num++@"Create Account",%this@" new");
		}
		Client::addMenuItem(%clientId,%num++@"Exit",%this@" exit");
		bottomPrint(%clientId,"<jc><f1>Welcome to the Central Bank!",5);
	}
	else {
		Client::buildMenu(%clientId,"Bank Storage: ","Bank",true);
		%num = 0;
		%check = %start;
		%start--;
		%max = getNumItems();
		for(%i = 0; %i < %max && %num < 8; %i++) {
			%data = getItemData(%start++);
			if(%num < 7) {
				%count = $Aeon::Bank[%id,inv,%data];
				if(%count > 0) {
					%name = %data.description@" x "@%count;
					Client::addMenuItem(%clientId,%num++@%name,%this@" withdraw item "@%start@" "@%check);
				}
			}
			else
				Client::addMenuItem(%clientId,%num++@"Next...",%this@" next "@%start);
		}
		Client::addMenuItem(%clientId,%num++@"Cancel",%this@" exit");
	}
}

function processMenuBank(%clientId,%opt)
{
	%id = Aeon::getAeonId(%clientId);
	%term = getWord(%opt,0);
	%op1 = getWord(%opt,1);
	%op2 = getWord(%opt,2);
	%clientId.termMenu = "";
	%clientId.lastTermMenu = getSimTime();
	%clientId.withdraw = "";
	%clientId.deposit = "";
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
		return;
	}
	else if(%op1 == "next") {
		Term_Bank::initMenu(%clientId,%op2,%term);
		return;
	}
	else if(%op1 == "new") {
		$Aeon::Bank[%id] = true;
		Term_Bank::showStats(%clientId);
		Aeon::ExportBank(%clientId);
		bottomPrint(%clientId,"<jc><f3>Thank you, your <f1>Savings Account<f3> has been created!",5);
		remoteScoresOff(%clientId);
		return;
	}
	else if(%op1 == "deposit") {
		%extra = getWord(%opt,3);
		if(%op2 == "cash") {
			%cash = $Aeon::ClientInfo[%id,cash];
			if(%extra >= 0) {
				if(%cash >= %extra) {
					$Aeon::ClientInfo[%id,cash] -= %extra;
					$Aeon::Bank[%id,cash]+=%extra;
					Term_Bank::showStats(%clientId);
					Aeon::ExportInfo(%clientId);
					Aeon::ExportBank(%clientId);
					bottomPrint(%clientId,"<jc><f1>Thank you, your <f2>$"@String::cashComma(%extra)@"<f1> has been Deposited!",5);
					remoteScoresOff(%clientId);
					return;
				}
			}
			else {
				%clientId.setCashMax = $Aeon::ClientInfo[%id,cash];
				%clientId.deposit = true;
				%clientId.giveTarget = %term;
				processMenuSetCashAmount(%clientId,"","<jc><f1>Please type in your desired quantity, you have <f2>$"@String::cashComma(%cash)@"<f1>.");
				return;
			}
		}
		else if(%op2 == "item") {
			bottomPrint(%clientId,"<jc><f1>Please Deposit your desired Items now.",5);
			//Term_Bank::initMenu(%clientId,0,%term);
			return;
		}
	}
	else if(%op1 == "withdraw") {
		%extra = getWord(%opt,3);
		if(%op2 == "cash") {
			%cash = $Aeon::Bank[%id,cash];
			if(%extra >= 0) {
				if(%cash >= %extra) {
					$Aeon::ClientInfo[%id,cash] += %extra;
					$Aeon::Bank[%id,cash]-=%extra;
					Term_Bank::showStats(%clientId);
					Aeon::ExportInfo(%clientId);
					Aeon::ExportBank(%clientId);
					bottomPrint(%clientId,"<jc><f1>Thank you, your <f2>$"@String::cashComma(%extra)@"<f1> has been Withdrawn!",5);
					remoteScoresOff(%clientId);
					return;
				}
			}
			else {
				%clientId.setCashMax = $Aeon::Bank[%id,cash];
				%clientId.withdraw = true;
				%clientId.giveTarget = %term;
				processMenuSetCashAmount(%clientId,"","<jc><f1>Please type in your desired quantity, your Account has <f2>$"@String::cashComma(%cash)@"<f1>.");
				return;
			}
		}
		else if(%op2 == "item") {
			%i = getWord(%opt,3);
			if(%i == -1) {
				Term_Bank::initMenu(%clientId,0,%term);
				return;
			}
			%data = getItemData(%i);
			%count = $Aeon::Bank[%id,inv,%data];
			if(%count > 0) {
				if(Item::giveItem(%clientId,%data,1)) {
					$Aeon::Bank[%id,inv,%data]--;
					Term_Bank::showStats(%clientId);
					Aeon::ExportBank(%clientId);
					Term_Bank::initMenu(%clientId,getWord(%opt,4),%term);
					return;
				}
			}
			return;
		}
	}
}

function Term_Bank::showStats(%clientId)
{
	%id = Aeon::getAeonId(%clientId);
	%line = 0;
	%head = "-----------------Savings Account-----------------";
	remoteEval(%clientId,"setInfoLine",%line++,%head);
	remoteEval(%clientId,"setInfoLine",%line++,"Cash Savings: $"@String::cashComma($Aeon::Bank[%id,cash]));
	remoteEval(%clientId,"setInfoLine",%line++,"Item Storage: "@Bank::invCount(%id));
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	return;
}
