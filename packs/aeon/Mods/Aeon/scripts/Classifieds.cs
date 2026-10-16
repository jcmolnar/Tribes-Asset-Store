$Aeon::maxPost = 5;

function Classifieds::strStack()
{
	%str = "";
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++)
		%str = %str@$Aeon::classified[%i,title]@", ";
	return %str;
}

function Classifieds::getNum(%title)
{
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++) {
		if($Aeon::classified[%i,title] == %title)
			return %i;
	}
	return %i;
}

function Classifieds::addToStack(%title,%cntxt,%id)
{
	if(%cntxt == "")
		%cntxt = "";
	if(%id == "")
		%id = "";
	%num = Classifieds::getNum(%title);
	$Aeon::classified["[\""@%num@"\",\"title\"]"] = $Aeon::classified[%num,title] = %title;
	$Aeon::classified["[\""@%num@"\",\"cntxt\"]"] = $Aeon::classified[%num,cntxt] = %cntxt;
	$Aeon::classified["[\""@%num@"\",\"authr\"]"] = $Aeon::classified[%num,authr] = %id;
	return %num;
}

function Classifieds::removeFromStack(%title)
{
	%found = false;
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++) {
		if($Aeon::classified[%i,title] == %title)
			%found = true;
		if(%found == true) {
			$Aeon::classified["[\""@%i@"\",\"title\"]"] = $Aeon::classified[%i,title] = $Aeon::classified[%i+1,title];
			$Aeon::classified["[\""@%i@"\",\"cntxt\"]"] = $Aeon::classified[%i,cntxt] = $Aeon::classified[%i+1,cntxt];
			$Aeon::classified["[\""@%i@"\",\"authr\"]"] = $Aeon::classified[%i,authr] = $Aeon::classified[%i+1,authr];
		}
	}
	$Aeon::classified["[\""@%i@"\",\"title\"]"] = $Aeon::classified[%i,title] = "";
	$Aeon::classified["[\""@%i@"\",\"cntxt\"]"] = $Aeon::classified[%i,cntxt] = "";
	$Aeon::classified["[\""@%i@"\",\"authr\"]"] = $Aeon::classified[%i,authr] = "";
	Aeon::ExportClassifieds();
}

function Classifieds::getPostCount(%id)
{
	%count = 0;
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++) {
		if($Aeon::classified[%i,authr] == %id)
			%count++;
	}
	return %count;
	
}

function Classifieds::getCount()
{
	%count = 0;
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++)
		%count++;
	return %count;
}

function Classifieds::checkTitle(%title)
{
	for(%i = 1; $Aeon::classified[%i,title] != ""; %i++) {
		if($Aeon::classified[%i,title] == %title)
			return false;
	}
	return true;
}

function Aeon::readAd(%clientId,%num)
{
	%id = Aeon::getAeonID(%clientId);
	%inc = 150;
	%ad = $Aeon::classified[%num,cntxt];
	%authorId = $Aeon::classified[%num,authr];
	Aeon::clientInfo(%authorId);
	%authName = $Aeon::ClientInfo[%authorId,name];
	%close = $Aeon::ClientInfo[%id,pref,scrSpd];
	%len = AeonStr::Len(%ad);
	if(%len > %inc) {
		%i = 0;
		while(String::getSubStr(%ad,%i,%inc) != "") {
			%piece = String::getSubStr(%ad,%i,%inc);
			%scrSp = $Aeon::ClientInfo[%id,pref,scrSpd];
			if(%scrSp < 1)
				%scrSp = $Aeon::ClientInfo[%id,pref,scrSpd] = 9;
			schedule("bottomPrint2("@%clientId@",\"<jc><f3>"@escapeString(%piece)@"\","@floor(%scrSp)@",\"shell_click.wav\");",%scrSp*(%i/%inc),%clientId);
			%i+=%inc;
		}
		%close = %scrSp *(%i/%inc);
	}
	else
		bottomPrint2(%clientId,"<jc><f3>"@%ad,$Aeon::ClientInfo[%id,pref,scrSpd],"shell_click.wav");
	%scrSp = $Aeon::ClientInfo[%id,pref,scrSpd];
	%info = "Author: <f2>"@%authName;
	schedule("bottomPrint2("@%clientId@",\"<jc><f3>"@escapeString(%info)@"\","@floor(%scrSp)@",\"shell_click.wav\");",%close,%clientId);
}

function SayFunc::writePost(%clientId,%msg,%num)
{
	%msg = AeonStr::replace(%msg,"<","");
	%msg = AeonStr::replace(%msg,">","");
	%space = "";
	if(getWord($Aeon::classified[%num,"cntxt"],0) != -1)
		%space = " ";
	%title = $Aeon::classified[%num,title];
	%cntxt = AeonStr::trim($Aeon::classified[%num,"cntxt"])@%space@%msg;
	Classifieds::addToStack(%title,%cntxt,"");
	Client::buildMenu(%clientId,"Done typing post?","postMore",false);
	Client::addMenuItem(%clientId,"1Add More?","more "@%num);
	Client::addMenuItem(%clientId,"2Done","done "@%num);
	return;
}

function processMenuPostMore(%clientId,%opt)
{
	%num = getWord(%opt,1);
	%portA = $Aeon::classified[%num,authr]; // PORT (2026-10-12): only a post still being written, or the caller's own
	if(!(%portA == "" || %portA == Aeon::getAeonID(%clientId))) return;
	if(getWord(%opt,0) == "more") {
		bottomPrint(%clientId,"<jc><f2>Type the rest of your post on the global chat now.",2);
		if(%num != -1)
			%clientId.nextMsg = "writePost "@%num;
	}
	else if(getWord(%opt,0) == "done") {
		%title = $Aeon::classified[%num,title];
		bottomPrint(%clientId,"<jc><f2>Your post is now on the Classifieds.",2);
		Classifieds::addToStack(%title,$Aeon::classified[%num,cntxt],Aeon::getAeonID(%clientId));
		Aeon::ExportClassifieds();
	}
}
