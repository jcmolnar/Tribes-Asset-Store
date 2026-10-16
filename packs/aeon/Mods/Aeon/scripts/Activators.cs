$Aeon::invStyle[Mine] = "held";
$Aeon::invStyle[Beacon] = "held";
$Aeon::invStyle[Grenade] = "held";
$Aeon::invStyle[Activator1] = "held";
$Aeon::invStyle[Activator2] = "held";
$Aeon::invStyle[Activator3] = "held";
$Aeon::invStyle[Activator4] = "held";
$Aeon::invStyle[Activator5] = "held";
$Aeon::invStyle[Activator6] = "held";
$Aeon::invStyle[Activator7] = "held";
$Aeon::invStyle[Activator8] = "held";
$Aeon::invStyle[Activator9] = "held";

function Activators::setCount(%clientId)
{
	Player::setItemCount(%clientId,"mine",1);
	Player::setItemCount(%clientId,"beacon",1);
	Player::setItemCount(%clientId,"grenade",1);
	Player::setItemCount(%clientId,"Activator1",1);
	Player::setItemCount(%clientId,"Activator2",1);
	Player::setItemCount(%clientId,"Activator3",1);
	Player::setItemCount(%clientId,"Activator4",1);
	Player::setItemCount(%clientId,"Activator5",1);
	Player::setItemCount(%clientId,"Activator6",1);
	Player::setItemCount(%clientId,"Activator7",1);
	Player::setItemCount(%clientId,"Activator8",1);
	Player::setItemCount(%clientId,"Activator9",1);
	Player::setItemCount(%clientId,"Unarmed",1);
}

//----------------------------------------------------------------------------
$ActivatorFunc[Mine]	   = "cnTool next";
$ActivatorFunc[Beacon]     = "setup";
$ActivatorFunc[Grenade]    = "interact";
$ActivatorFunc[Activator1] = "skill menu";
$ActivatorFunc[Activator2] = "trade";
$ActivatorFunc[Activator3] = "sayCmd grab";
$ActivatorFunc[Activator4] = "sayCmd smoke weed";
$ActivatorFunc[Activator5] = "sayCmd goHome";
$ActivatorFunc[Activator6] = "setup self";
$ActivatorFunc[Activator7] = "setup self";
$ActivatorFunc[Activator8] = "setup self";
$ActivatorFunc[Activator9] = "setup self";

$ActivatorName[1] = "Grenade";
$ActivatorName[1,desc] = "Grenade";
$ActivatorName[2] = "Activator1";
$ActivatorName[2,desc] = "Number 1";
$ActivatorName[3] = "Activator2";
$ActivatorName[3,desc] = "Number 2";
$ActivatorName[4] = "Activator3";
$ActivatorName[4,desc] = "Number 3";
$ActivatorName[5] = "Activator4";
$ActivatorName[5,desc] = "Number 4";
$ActivatorName[6] = "Activator5";
$ActivatorName[6,desc] = "Number 5";
$ActivatorName[7] = "Activator6";
$ActivatorName[7,desc] = "Number 6";
$ActivatorName[8] = "Activator7";
$ActivatorName[8,desc] = "Number 7";
$ActivatorName[9] = "Activator8";
$ActivatorName[9,desc] = "Number 8";
$ActivatorName[10] = "Activator9";
$ActivatorName[10,desc] = "Number 9";


function Activator::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(getSimTime() - %clientId.lastActTime < 1.0 || %clientId.isReading == true)
		return;
	%clientId.lastActTime = getSimTime();
	%id = Aeon::getAeonID(%clientId);
	%func = $Aeon::ClientInfo[%id,fKey,%item];
	if(%func == "")
		%func = $Aeon::ClientInfo[%id,fKey,%item] = $ActivatorFunc[%item];
	%word[0] = getWord(%func,0);
	%word[1] = getWord(%func,1);
	%word[2] = getWord(%func,2);
	if(%word[0] == "sayCmd" && $sayCommand[%word[1]] == "true") { // PORT: only a listed chat command (same test as comchat.cs)
		Eval("SayCMD::"@%word[1]@"("@%clientId@",\""@escapeString(String::getSubStr(%func,String::indexOf(%func,getWord(%func,2)),5))@"\");");
	}
	else if(%word[0] == "cnTool") {
		%clientId.lastActTime-=0.8;
		if(%word[1] == "next" && Player::getMountedItem(%player,$WeaponSlot) == "CnTool")
			CnTool::cycleModes(%clientId,1);
		else if(%word[1] == "prev" && Player::getMountedItem(%player,$WeaponSlot) == "CnTool")
			CnTool::cycleModes(%clientId,-1);
		else
			CnTool::setMode(%clientId,%word[1]);
	}
	else if(%word[0] == "skill") {
		if(%word[1] == "menu") {
			Skill::toggleMenu(%clientId);
		}
		else if(%word[1] != -1 ) {
			if(Skill::hasFunc(%word[1]) == true) {
				if($Aeon::ClientInfo[%id,skll,%word[1]] > 0)
					Eval("SkillFunc::"@%word[1]@"("@%clientId@",\""@escapeString(String::getSubStr(%func,String::indexOf(%func,getWord(%func,2)),5))@"\");");
				else {
					
				}
			}
		}
		else
			Skill::toggleMenu(%clientId);
	}
	else if(%word[0] == "trade") {
		Trade::checkTrade(%player);
	}
	else if(%word[0] == "interact") {
		Interact::onUse(%player);
	}
	else if(%word[0] == "setup") {
		if(%word[1] == "self") {
			processMenuActKeyMenu(%clientId,"key "@Activator::getNum(%item));
		}
		else {
			Activator::initMenu(%clientId);
		}
	}
	else if(%word[0] == "test") {
		TestKey::onUse(%player,%item);
	}
	else {
		echo("Activators: "@%word[0]);
	}
}

function Activator::initMenu(%clientId,%start)
{
	Client::buildMenu(%clientId,"Key Bindings: ","ActKeyMenu",true);
	if(!%start) {
		%init = true;
		%start = 0;
	}
	for(%i = 0; $ActivatorName[%start+1] != "" && %i < 7 && %nextCalled != true; %i++) {
		if(%i < 6) {
			Client::addMenuItem(%clientId,%i@$ActivatorName[%start++,desc],"key "@%start);
		}
		else {
			if($ActivatorName[%i+1] != "") {
				Client::addMenuItem(%clientId,%i@"Next...","next "@%start);
				%nextCalled = true;
			}
			else
				Client::addMenuItem(%clientId,%i@$ActivatorName[%start++,desc],"key "@%start);
		}
	}
	if(%i < 6) {
		Client::addMenuItem(%clientId,%i@"*Presets:","preset");
		%i++;
	}
	if(%i < 6) {
		Client::addMenuItem(%clientId,%i@"Back","back");
		%i++;			
	}
	Client::addMenuItem(%clientId,%i@"Exit","exit");
}

function processMenuActKeyMenu(%clientId,%opt)
{
	%id = Aeon::getAeonId(%clientId);
	%op1 = getWord(%opt,0);
	%op2 = getWord(%opt,1);
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
	}
	else if(%op1 == "back") {
		Activator::initMenu(%clientId);
	}
	else if(%op1 == "next") {
		Activator::initMenu(%clientId,%op2);
	}
	else if(%op1 == "key") {
		%krma = Calc::abs(floor($Aeon::ClientInfo[%id,krma]));
		%i = -1;
		Client::buildMenu(%clientId,"Binding Options: "@$ActivatorName[%op2,desc],"ActFuncMenu",true);
		Client::addMenuItem(%clientId,%i++@"Chat Commands:",$ActivatorName[%op2]@" func sayCmd");
		Client::addMenuItem(%clientId,%i++@"Cn Tool Modes:",$ActivatorName[%op2]@" func cnTool");
		if(%krma == $Aeon::ClientInfo[%id,pnts] || %krma == 0)
			Client::addMenuItem(%clientId,%i++@"Skills Menu:",$ActivatorName[%op2]@" func skill menu");
		else
			Client::addMenuItem(%clientId,%i++@"Skill Funcs:",$ActivatorName[%op2]@" func skill");
		Client::addMenuItem(%clientId,%i++@"Interact Key",$ActivatorName[%op2]@" func inter");
		Client::addMenuItem(%clientId,%i++@"Trade",$ActivatorName[%op2]@" func trade");
		Client::addMenuItem(%clientId,%i++@"None",$ActivatorName[%op2]@" func none");
		Client::addMenuItem(%clientId,%i++@"Back",$ActivatorName[%op2]@" back");
	}
	else if(%op1 == "preset") {
		if(%op2 != -1) {
			Activator::setPreset(%clientId,%op2);
		}
		else {
			%i = -1;
			Client::buildMenu(%clientId,"Binding Presets: ","ActKeyMenu",false);
			Client::addMenuItem(%clientId,%i++@"Construction Preset","preset const");
			Client::addMenuItem(%clientId,%i++@"Defaults Preset","preset default");
		}
	}
	else {

	}
}

function processMenuActFuncMenu(%clientId,%opt)
{
	%key = getWord(%opt,0);
	%op1 = getWord(%opt,1);
	%op2 = getWord(%opt,2);
	%op3 = getWord(%opt,3);
	%op4 = getWord(%opt,4);
	if(%op1 == "back") {
		Activator::initMenu(%clientId);
	}
	else if(%op1 == "next") {
		Activator::initMenu(%clientId,%op2);
	}
	else if(%op1 == "func") {
		%id = Aeon::getAeonID(%clientId);
		%num = Activator::getNum(%key);
		%i = -1;
		if(%op2 == "sayCmd") {
			if(%op3 != -1) {
				$Aeon::ClientInfo[%id,fKey,%key] = "sayCmd "@%op3;
				Activator::dispBind(%clientId,%num,"Chat Command: #"@%op3);
			}
			else {
				bottomPrint(%clientId,"<jc><f2>Please type in the Chat Command in the global chat now.",2);
				%clientId.nextMsg = "activatorSayCmd";
				%clientId.tempAct = %key;
				return;
			}
		}
		else if(%op2 == "cnTool") {
			if(%op3 == "back") {
				processMenuActKeyMenu(%clientId,"key "@%num);
			}
			else if(%op3 == "next") {
				Activator::funcCnTool(%clientId,%op4,%key);
			}
			else if(%op3 == "sel") {
				$Aeon::ClientInfo[%id,fKey,%key] = "cnTool "@%op4;
				Activator::dispBind(%clientId,%num,"Cn Tool Mode: "@$CnModName[%op4]);
			}
			else
				Activator::funcCnTool(%clientId,"",%key);
		}
		else if(%op2 == "skill") {
			if(%op3 == "next") {
				Activator::funcSkill(%clientId,%op4,%key);
			}
			else if(%op3 == "sel") {
				echo("Sel: "@$SkillFunc[%op4]);
				$Aeon::ClientInfo[%id,fKey,%key] = "skill "@$SkillFunc[%op4];
				Activator::dispBind(%clientId,%num,"Skill Func: "@$SkillFunc[%op4,desc]);
			}
			else if(%op3 == "menu") {
				$Aeon::ClientInfo[%id,fKey,%key] = "skill menu";
				Activator::dispBind(%clientId,%num,"Skills Menu");
			}
			else
				Activator::funcSkill(%clientId,"",%key);
		}
		else if(%op2 == "inter") {
			$Aeon::ClientInfo[%id,fKey,%key] = "interact";
			Activator::dispBind(%clientId,%num,"Interact");
		}
		else if(%op2 == "trade") {
			$Aeon::ClientInfo[%id,fKey,%key] = "trade";
			Activator::dispBind(%clientId,%num,"Trade");
		}
		else if(%op2 == "none") {
			$Aeon::ClientInfo[%id,fKey,%key] = "setup self";
			Activator::dispBind(%clientId,%num,"None");
		}
	}
	else {

	}
}

function Activator::funcCnTool(%clientId,%start,%name)
{
	Client::buildMenu(%clientId,"Cn Tool Modes: ","ActFuncMenu",false);
	if(!%start)
		%start = 0;
	for(%i = 0; $CnModName[%start+1] != "" && %i < 7; %i++) {
		if(%i < 6)
			Client::addMenuItem(%clientId,%i@$CnModName[%start++],%name@" func cnTool sel "@%start);
		else {
			if($CnModName[%i+1] != "")
				Client::addMenuItem(%clientId,%i@"Next...",%name@" func cnTool next "@%start);
			else
				Client::addMenuItem(%clientId,%i@$CnModName[%start++],%name@" func cnTool sel "@%start);
		}
	}
	Client::addMenuItem(%clientId,%i@"Back",%name@" func cnTool back");
}

function Activator::funcSkill(%clientId,%start,%name)
{
	%id = Aeon::getAeonID(%clientId);
	if(Calc::abs(floor($Aeon::ClientInfo[%id,krma])) == $Aeon::ClientInfo[%id,pnts]) {
		processMenuActFuncMenu(%clientId,%name@" func cnTool back");
		return;
	}
	if(!%start)
		%start = -1;
	Client::buildMenu(%clientId,"Skill Funcs: ","ActFuncMenu",false);
	for(%i = 0; $SkillFunc[%start+1] != "" && %i < 7; %i++) {
		%skill = $SkillFunc[%start++];
		if($Aeon::ClientInfo[%id,skll,%skill] > 0) {
			%desc = $SkillFunc[%start,desc];
			if(%i < 6)
				Client::addMenuItem(%clientId,%i@%desc,%name@" func skill sel "@%start);
			else {
				if($SkillFunc[%i+1] != "")
					Client::addMenuItem(%clientId,%i@"Next...",%name@" func skill next "@%start);
				else
					Client::addMenuItem(%clientId,%i@%desc,%name@" func skill sel "@%start);
			}
		}
		else
			%i--;
	}
	if(%i < 6) {
		Client::addMenuItem(%clientId,%i@"Skill Menu:",%name@" func skill menu");
		%i++;
	}
	Client::addMenuItem(%clientId,%i@"Back",%name@" func cnTool back");
}


function SayFunc::activatorSayCmd(%clientId,%msg)
{
	if(String::findSubStr(%msg,"#") == 0)
		%msg = String::getSubStr(%msg,1,AeonStr::len(getWord(%msg,0))-1);
	processMenuActFuncMenu(%clientId,%clientId.tempAct@" func sayCmd "@%msg);
	%clientId.tempAct = "";
}

function Activator::setPreset(%clientId,%set)
{
	%id = Aeon::getAeonID(%clientId);
	if(%set == "const") {
		$Aeon::ClientInfo[%id,fKey,Grenade]    = "interact";
		$Aeon::ClientInfo[%id,fKey,Activator1] = "cnTool 1";
		$Aeon::ClientInfo[%id,fKey,Activator2] = "cnTool 2";
		$Aeon::ClientInfo[%id,fKey,Activator3] = "cnTool 3";
		$Aeon::ClientInfo[%id,fKey,Activator4] = "cnTool 4";
		$Aeon::ClientInfo[%id,fKey,Activator5] = "cnTool 5";
		$Aeon::ClientInfo[%id,fKey,Activator6] = "cnTool 6";
		$Aeon::ClientInfo[%id,fKey,Activator7] = "cnTool 7";
		$Aeon::ClientInfo[%id,fKey,Activator8] = "cnTool 8";
		$Aeon::ClientInfo[%id,fKey,Activator9] = "cnTool 9";
	}
	else if(%set == "default") {
		$Aeon::ClientInfo[%id,fKey,Grenade]    = $ActivatorFunc[Grenade];
		$Aeon::ClientInfo[%id,fKey,Activator1] = $ActivatorFunc[Activator1];
		$Aeon::ClientInfo[%id,fKey,Activator2] = $ActivatorFunc[Activator2];
		$Aeon::ClientInfo[%id,fKey,Activator3] = $ActivatorFunc[Activator3];
		$Aeon::ClientInfo[%id,fKey,Activator4] = $ActivatorFunc[Activator4];
		$Aeon::ClientInfo[%id,fKey,Activator5] = $ActivatorFunc[Activator5];
		$Aeon::ClientInfo[%id,fKey,Activator6] = $ActivatorFunc[Activator6];
		$Aeon::ClientInfo[%id,fKey,Activator7] = $ActivatorFunc[Activator7];
		$Aeon::ClientInfo[%id,fKey,Activator8] = $ActivatorFunc[Activator8];
		$Aeon::ClientInfo[%id,fKey,Activator9] = $ActivatorFunc[Activator9];
	}
}

function Activator::dispBind(%clientId,%key,%func)
{
	%id = Aeon::getAeonID(%clientId);
	%desc = $ActivatorName[%key,desc];
	//%funcDesc = $Aeon::ClientInfo[%id,fKey,%key];
	bottomPrint(%clientId,"<jc><f3>"@%desc@"<f1> is now bound to <f3>"@%func@"<f1>.",2);
	Aeon::ExportInfo(%clientId);
}

function Activator::getNum(%name)
{
	for(%i = 1; $ActivatorName[%i] != ""; %i++) {
		if($ActivatorName[%i] == %name)
			return %i;
	}
	return false;
}

//----------------------------------------------------------------------------
$MiscAllowed = "Off";
$BeaconFunc = "beam";

function TestKey::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(getSimTime() - %clientId.lastBeaconTime < 2.0)
		return;
	%clientId.lastBeaconTime = getSimTime();
	%id = Aeon::getAeonID(%clientId);
	if(%clientId.isAdmin) {
		if($BeaconFunc == "Rain")
			DynWeather::call("Rain");
		else if($BeaconFunc == "Snow")
			DynWeather::call("Snow");
		else if(getWord($BeaconFunc,0) == "Seed") {
			if(GameBase::getLOSInfo(%player,3)) {
				%opt = getWord($BeaconFunc,2);
				if(%opt != "" && %opt >= 0)
					Aeon::vegetate($los::position,getWord($BeaconFunc,1),%opt);
				else
					Aeon::vegetate($los::position,getWord($BeaconFunc,1));
			}
		}
		else if($BeaconFunc == "Meteor") {
			Aeon::rockMan(%player);
		}
		else if($BeaconFunc == "LOSTest") {
			//GameBase::getLOSinfo(%player,3);
			%pos = Vector::add(GameBase::getPosition(%player),"0 0 3");
			%rot = Player::getLookRot(%player,1);
			%pVec = Vector::getFromRot(%rot,5);
			%aPos = Vector::add(%pos,%pVec);
			getLOSInfo(%pos,%aPos,1);
			echo(getObjectType($los::object));
		}
		else if(getWord($BeaconFunc,0) == "PropGive") {
			if(getWord($BeaconFunc,2))
				Property::setOwner(getWord($BeaconFunc,1),Aeon::getAeonID(getWord($BeaconFunc,2)));
			else
				Property::setOwner(getWord($BeaconFunc,1),%id);
		}
		else if(getWord($BeaconFunc,0) == "propDims") {
			Property::updateDims(getWord($BeaconFunc,1));
		}
		else if(getWord($BeaconFunc,0) == "giveKnow") {
			Knowledge::giveAll(getWord($BeaconFunc,1));
		}
		else if($BeaconFunc == "Skill") {
			Skill::toggleMenu(%clientId);
		}
		else if($BeaconFunc == "lightTest") {
			Aeon::inLight(%player);
		}
		else if($BeaconFunc == "central") {
			Central::initialize();
		}
		else if($BeaconFunc == "ai") {
			AI::test(%clientId);
		}
		else if($BeaconFunc == "dispRot") {
			String::dispRot(%clientId,"0 0 0",5.0);
		}
		else if($BeaconFunc == "joinMsg") {
			Aeon::joinMessage(%clientId);
		}
		else if($BeaconFunc == "beam") {
			%player.firing = 1;
			SuperLaser(%player);
			if(!$SuperLasTime[%clientId])
				$SuperLasTime[%clientId] = $SuperLasTimeDef;
			schedule(%player@".firing = 0;",$SuperLasTime[%clientId],%player);
		}
		else
			Skill::toggleMenu(%clientId);
	}
	else
		Skill::toggleMenu(%clientId);
}

function Mine::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Beacon::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Grenade::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator1::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator2::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator3::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator4::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator5::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator6::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator7::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator8::onUse(%player,%item)
{Activator::onUse(%player,%item);}

function Activator9::onUse(%player,%item)
{Activator::onUse(%player,%item);}