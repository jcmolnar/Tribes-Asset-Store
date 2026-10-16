//- Place Holder file, eventually will house knowledge structures
$Aeon::bookReExec = 120;

function Book::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	%id = Aeon::getAeonID(%clientId);
	$Aeon::ClientInfo[%id,time] += (getSimTime() - $JoinTime[%clientId]);
	$JoinTime[%clientId] = getSimTime();
	%krma = $Aeon::ClientInfo[%id,krma];
	%obtn = $Aeon::ClientInfo[%id,book,lastTime];
	%last = $Aeon::ClientInfo[%id,book,lastBook];
	%book = $Aeon::ClientInfo[%id,book];
	%name = $Aeon::Books[%book,title];
	%time = $Aeon::Books[%book,rntTm];
	%body = $Aeon::Books[%book,cnTnt];
	%kReq = $Aeon::Books[%book,krmRq];
	if(%kReq == "")
		%kReq = 0;
	%diff = $Aeon::ClientInfo[%id,time] - %last;
	%gameDiff = Aeon::gameTime(%diff,true);
	%time = $Aeon::Books[%last,rntTm];
	if(!%time)
		%time = 3600; //-3600 default time (1 in-game hour)
	if(String::findSubStr(%book,"*LOST") == 0)
		%book = AeonStr::Trim(String::getSubStr(%book,5,50));
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);
	if(((%book != %last && %gameDiff < %time) || %book == %last) && %clientId.isReading != true) {
		if((%kReq <= 0 && %krma <= %kReq) || (%kReq >= 0 && %krma >= %kReq) || %kReq == 0) {
			%clientId.isReading = true;
			%scrSp = $Aeon::ClientInfo[%id,pref,scrSpd]+2;
			%line = 0;
			%page = 0;
			%str = "";
			%str[0] = "";
			%str[1] = "";
			%str[2] = "";
			%str[3] = "";
			%header = "<jc><f1>";
			for(%i = 0; getWord(%body,%i) != -1; %i++) {
				%word = getWord(%body,%i);
				%len = AeonStr::len(%str[%line]);
				if(%len+AeonStr::len(%word) < 60)
					%str[%line] = %str[%line]@%word@" ";
				else if(%line < 3) {
					%line++;
					%str[%line] = %str[%line]@%word@" ";
					%str = %str@%str[%line-1];
				}
				else {
					%str = %header@%str@%str[%line];
					schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*%page,%clientId);
					schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+1/4),%clientId);
					schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+1/2),%clientId);
					schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+3/4),%clientId);
					%page++;
					%line = 0;
					%str = "";
					%str[0] = "";
					%str[1] = "";
					%str[2] = "";
					%str[3] = "";
					%str[%line] = %str[%line]@%word@" ";
				}
			}
			%str = %header@%str@%str[%line];
			schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*%page,%clientId);
			schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+1/4),%clientId);
			schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+1/2),%clientId);
			schedule("centerPrint("@%clientId@",\""@%str@"\","@%scrSp@");",%scrSp*(%page+3/4),%clientId);
			schedule("Books::onFinish("@%clientId@","@%book@");",%scrSp*(%page+1),%clientId);
		}
		else if(%clientId.isReading != true)
			bottomPrint(%clientId,"<jc><f3>You need <f1>"@%kReq@"<f3> Karma to read this Book!",5);
	}
	else if(%clientId.isReading != true)
		bottomPrint(%clientId,"<jc><f3>You cannot read a different Book for another <f1>"@String::time(%time-%gameDiff)@"<f3>!",5);
}

function Books::onFinish(%clientId,%book)
{
	%clientId.isReading = "";
	%hasKnow = $Aeon::Books[%book,knwlg];
	if(%hasKnow != "" && %hasKnow != false) {
		%skill = getWord(%hasKnow,0);
		%value = getWord(%hasKnow,1);
		if($Aeon::ClientInfo[Aeon::getAeonID(%clientId),know,%skill] < %value) {
			%desc = Skill::getDesc(%skill);
			Knowledge::setKnow(%clientId,%skill,%value);
			bottomPrint2(%clientId,"<jc><f3>You gained knowledge of <f1>"@%desc@"<f3>!",5,"FlagReturn.wav");
		}
	}
	if(%book == "zzzIntro") {
		$Aeon::ClientInfo[Aeon::getAeonId(%clientId),mute] = "";
		bottomPrint2(%clientId,"<jc><f3>Your Chat has been Enabled!",5,"FlagReturn.wav");
		
	}
}

function Term_CheckOut::onAdd(%this)
{
	$Aeon::InteractFunc[%this] = "Term_CheckOut";
	Terminal::onAdd(%this);
}

function Term_CheckOut::onInteract(%this,%player)
{
	Terminal::onCollision(%this,%player,true);
}

function Books::countBooks()
{
	%fileBase = "AeonBook[*";
	%file = File::findFirst(%fileBase);
	%count = 0;
	while(%file != "") {
		%count++;
		%file = File::findNext(%fileBase);
	}
	return %count;
}

function Books::buildLibrary(%update)
{
	if($Aeon::lastBookCount < Books::countBooks() || %update == true || getSimTime() > $Aeon::lastBookTime+$Aeon::bookReExec) {
		%fileBase = "AeonBook[*";
		%file = File::findFirst(%fileBase);
		%num = 0;
		while(%file != "") {
			exec(%file);
			%book = String::getSubStr(%file,9,String::indexOf(%file,"]")-9);
			if($Aeon::Books[%book,"noShw"] != true)
				$Aeon::Book[%num++] = %book;
			%file = File::findNext(%fileBase);
		}
		$Aeon::Book[%num+1] = "";
		$Aeon::lastBookCount = %num+1;
		$Aeon::lastBookTime = getSimTime();
	}
}

function Books::rentBook(%clientId,%book,%found)
{
	%id = Aeon::getAeonID(%clientId);
	%name = $Aeon::Books[%book,title];
	%time = $Aeon::Books[%book,rntTm];
	if(getWord(%found,0) != -1 && getWord(%found,0) != false) {
		if(String::findSubStr(%book,"*LOST") == 0)
			%book = AeonStr::Trim(String::getSubStr(%book,5,50));
		%name = $Aeon::Books[%book,title];
		if(getWord(%found,1) != -1) {
			//echo("Reclaiming: "@%book@", Client Book: "@$Aeon::ClientInfo[%id,book]);
			if($Aeon::ClientInfo[%id,book] != "") {
				$Aeon::ClientInfo[%id,book] = %book;
				%foundWord = "reclaimed";
			}
			else {
				$Aeon::ClientInfo[%id,book] = "*LOST"@%book;
				%foundWord = "found";
			}
		}
		else {
			$Aeon::ClientInfo[%id,book] = "*LOST"@%book;
			%foundWord = "found";
		}
		bottomPrint(%clientId,"<jc><f3>You "@%foundWord@" \"<f1>"@%name@"<f3>\"!");
	}
	else {
		$Aeon::ClientInfo[%id,book] = %book;
		$Aeon::ClientInfo[%id,book,lastBook] = %book;
		$Aeon::ClientInfo[%id,book,lastTime] = $Aeon::ClientInfo[%id,time];
		bottomPrint(%clientId,"<jc><f3>Thank you for checking out <f1>"@%name@"<f3>, be sure to bring it back within <f1>"@String::time(%time)@"<f3>!",5);
	}
	Player::setItemCount(%clientId,"Book",1);
	Aeon::ExportInfo(%clientId);
}

function Books::checkInLost(%clientId,%book)
{
	%id = Aeon::getAeonID(%clientId);
	$Aeon::ClientInfo[%id,cash] += floor($Aeon::Books[%book,feeRp]*0.2);
}

function Term_CheckOut::onItemCatch(%this,%object)
{
	%data = GameBase::getDataName(%object);
	if(%data == Book) {
		%player = %object.tosser;
		%clientId = Player::getClient(%player);
		%id = Aeon::getAeonID(%clientId);
		//%book = $Aeon::ClientInfo[%id,book];
		%book = $BookType[%object];
		$BookType[%object] = "";
		deleteObject(%object);
		%name = $Aeon::Books[%book,title];
		%lastBook = $Aeon::ClientInfo[%id,book,lastBook];
		%time = $Aeon::Books[%lastBook,rntTm];
		$Aeon::ClientInfo[%id,time] += (getSimTime() - $JoinTime[%clientId]);
		$JoinTime[%clientId] = getSimTime();
		%diff = $Aeon::ClientInfo[%id,time] - $Aeon::ClientInfo[%id,book,lastTime];
		%gameDiff = Aeon::gameTime(%diff,true);
		if(!%time)
			%time = 3600; //-3600 default time (1 in-game hour)
		if(String::findSubStr(%book,"*LOST") == 0) {
			%book = AeonStr::Trim(String::getSubStr(%book,5,50));
			%name = $Aeon::Books[%book,title];
			bottomPrint(%clientId,"<jc><f3>Thank you for returning our lost Book <f1>"@%name@"<f3>!",5);
			Books::checkInLost(%clientId,%book);
		}
		else if(%gameDiff < %time) {
			bottomPrint(%clientId,"<jc><f3>Thank you for returning <f1>"@%name@"<f3>!",5);
		}
		else if($Aeon::ClientInfo[%id,book] != "") {
			%cash = $Aeon::ClientInfo[%id,cash];
			%late = %gameDiff-%time;
			%fee = floor($Aeon::Books[%book,feeLt]*(%late/1800));
			if(%fee > $Aeon::Books[%book,feeRp])
				%fee = $Aeon::Books[%book,feeRp];
			if(%cash >= %fee) {
				$Aeon::ClientInfo[%id,cash] -= Calc::abs(%fee);
				bottomPrint2(%clientId,"<jc><f3>Sorry, but you have returned <f1>"@%name@" "@String::time(%late)@"<f3> late, and must pay a late fee of <f1>$"@String::cashComma(%fee)@"<f3>!",5,"BuySellSound.wav");
			}
			else {
				%dif = Calc::abs(%cash-%fee);
				$Aeon::ClientInfo[%id,cash] = 0;
				%debt = $Aeon::ClientInfo[%id,book,bookDebt] += %dif;
				bottomPrint2(%clientId,"<jc><f3>Sorry, but you have returned <f1>"@%name@" "@String::time(%late)@"<f3> late, and now have a Library Debt of <f1>$"@String::cashComma(%debt)@"<f3>!",5,"BuySellSound.wav");
			}
		}
		else {
			bottomPrint(%clientId,"<jc><f3>Thank you for returning our lost Book <f1>"@%name@"<f3>!",5);
			Books::checkInLost(%clientId,%book);
		}
		$Aeon::ClientInfo[%id,book] = "";
		Aeon::ExportInfo(%clientId);
	}
}

function Term_CheckOut::initMenu(%clientId,%start,%this)
{
	Books::buildLibrary();
	%clientId.termMenu = true;
	%id = Aeon::getAeonID(%clientId);
	if(!%start)
		%start = 0;
	Client::buildMenu(%clientId,"Books: ","Books",true);
	for(%i = 1; $Aeon::Book[%start+1] != "" && %i < 8; %i++) {
		%book = $Aeon::Book[%start+1];
		%name = $Aeon::Books[%book,title];
		%cost = $Aeon::Books[%book,feeRn];
		%name = %name@": $"@String::cashComma(%cost);
		if(%i < 7)
			Client::addMenuItem(%clientId,%i@%name,%this@" checkOut "@%start++);
		else {
			%start++;
			if($Aeon::Book[%i+1] != "")
				Client::addMenuItem(%clientId,%i@"Next...",%this@" next "@%start-1);
			else
				Client::addMenuItem(%clientId,%i@%name,%this@" checkOut "@%start);
		}
	}
	Client::addMenuItem(%clientId,%i@"Cancel",%this@" exit");
	%cash = $Aeon::ClientInfo[%id,cash];
	%debt = $Aeon::ClientInfo[%id,book,bookDebt];
	if(%debt > 0 && %cash > 0) {
		if(%cash > %debt) {
			$Aeon::ClientInfo[%id,cash] -= %debt;
			$Aeon::ClientInfo[%id,book,bookDebt] = "";
			bottomPrint2(%clientId,"<jc><f1>Welcome Back to the Central Library! <f3> All of your <f1>$"@%debt@"<f3> Debt has been repayed, Thank you!",5,"BuySellSound.wav");
		}
		else {
			$Aeon::ClientInfo[%id,cash] = 0;
			$Aeon::ClientInfo[%id,book,bookDebt] -= %cash;
			bottomPrint2(%clientId,"<jc><f1>Welcome Back to the Central Library! $"@%cash@"<f3> of your <f1>$"@%debt@"<f3> Debt has been repayed, Thank you!",5,"BuySellSound.wav");		
		}
		Aeon::ExportInfo(%clientId);
	}
	else
		bottomPrint(%clientId,"<jc><f1>Welcome to the Central Library! Be sure to check out the Introductory Books!",5);
}

function processMenuBooks(%clientId,%opt)
{
	%id = Aeon::getAeonId(%clientId);
	%shelf = getWord(%opt,0);
	%op1 = getWord(%opt,1);
	%op2 = getWord(%opt,2);
	%clientId.termMenu = "";
	%clientId.lastTermMenu = getSimTime();
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
		return;
	}
	else if(%op1 == "next") {
		Term_CheckOut::initMenu(%clientId,%op2,%shelf);
	}
	else if(%op1 == "checkOut") {
		%lastBook = $Aeon::ClientInfo[%id,book,lastBook];
		%book = $Aeon::Book[%op2];
		if(Vector::getDistance(GameBase::getPosition(%shelf),GameBase::getPosition(%clientId)) < 3.0) {
			%name = $Aeon::Books[%book,title];
			%rent = $Aeon::Books[%book,feeRn];
			%cost = $Aeon::Books[%book,feeRp];
			%kReq = $Aeon::Books[%book,krmRq];
			%cash = $Aeon::ClientInfo[%id,cash];
			%krma = $Aeon::ClientInfo[%id,krma];
			if(%kReq == "")
				%kReq = 0;
			%debt = $Aeon::ClientInfo[%id,book,bookDebt];
			if(%debt > 0) {
				bottomPrint(%clientId,"<jc><f3>You can't check out Books with a Library Debt!",5);
				processMenuBooks(%clientId,%shelf@" exit");
				return;
			}
			$Aeon::ClientInfo[%id,time] += (getSimTime() - $JoinTime[%clientId]);
			$JoinTime[%clientId] = getSimTime();
			if($Aeon::ClientInfo[%id,book,lastTime] > $Aeon::ClientInfo[%id,time])
				$Aeon::ClientInfo[%id,book,lastTime] = $Aeon::ClientInfo[%id,time];
			%diff = $Aeon::ClientInfo[%id,time] - $Aeon::ClientInfo[%id,book,lastTime];
			%gameDiff = Aeon::gameTime(%diff,true);
			%time = $Aeon::Books[%lastBook,rntTm];
			if(!%time)
				%time = 3600; //-3600 default time (1 in-game hour)
			if(%gameDiff < %time) {
				%timeLeft = String::time(%time-%gameDiff);
				bottomPrint(%clientId,"<jc><f3>You can't check out another Book for another <f1>"@%timeLeft@"<f3>!",5);
				processMenuBooks(%clientId,%shelf@" exit");
				return;
			}
			else if($Aeon::ClientInfo[%id,book] != "") {
				if(Player::getItemCount(%clientId,"book") > 0)
					bottomPrint(%clientId,"<jc><f3>You have a late Book already checked out!",5);
				else {
					if(%cash > %cost) {
						$Aeon::ClientInfo[%id,cash] -= %cost;
						bottomPrint2(%clientId,"<jc><f3>Sorry, but you have lost <f1>"@%name@"<f3>, and have payed the replacement fee of <f1>$"@String::cashComma(%cost)@"<f3>!",5,"BuySellSound.wav");
					}
					else {
						%dif = Calc::abs(%cash-%cost);
						$Aeon::ClientInfo[%id,cash] = 0;
						%debt = $Aeon::ClientInfo[%id,book,bookDebt] += %dif;
						bottomPrint2(%clientId,"<jc><f3>Sorry, but you have lost <f1>"@%name@"<f3>, and now have a Library Debt of <f1>$"@String::cashComma(%debt)@"<f3>!",5,"BuySellSound.wav");
					}
					$Aeon::ClientInfo[%id,book] = "";
					Aeon::ExportInfo(%clientId);
				}
				processMenuBooks(%clientId,%shelf@" exit");
				return;
			}
			else if((%kReq <= 0 && %krma <= %kReq) || (%kReq >= 0 && %krma >= %kReq) || %kReq == 0) {
				if(%cash >= %rent) {
					Books::rentBook(%clientId,%book);
					processMenuBooks(%clientId,%shelf@" exit");
				}
				else {
					bottomPrint(%clientId,"<jc><f3>You don't have the Cash to Rent <f1>"@%name@"<f3>!",5);
					processMenuBooks(%clientId,%shelf@" exit");
				}
			}
			else {
				bottomPrint(%clientId,"<jc><f3>You don't have enough Karma to Rent <f1>"@%name@"<f3>!",5);
				processMenuBooks(%clientId,%shelf@" exit");
			}
		}
		else {
			bottomPrint(%clientId,"<jc><f3>You have wandered away from the Library Terminal!",5);
			processMenuBooks(%clientId,%shelf@" exit");
		}
	}
	else {
		
	}
}

function Term_CheckOut::showStats(%clientId)
{
	%id = Aeon::getAeonId(%clientId);
	%line = 0;
	%head = "----------------------Book Stats----------------------";
	remoteEval(%clientId,"setInfoLine",%line++,%head);
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");	
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	return;
}
