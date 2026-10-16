//- This is your skill stack, make good friends with it:
//	This is how the skill stack works, the first number is your
//	skills directory, notice all these skills fall under the
//	category of thievery, and not-so-nice illegal-type things,
//	so I pair them all together under "2" which is defined as
//	"Thievery" .. please take note of the differences in each of
//	the different variables below...

//-Do not modify skill stack 0
$SkillStack[1] = "Attributes:";
$SkillStack[1,1] = mStr;
$SkillStack[1,1,desc] = "Strength";
$SkillStack[1,1,lvls] = 5;
$SkillStack[1,2] = mStm;
$SkillStack[1,2,desc] = "Stamina";
$SkillStack[1,2,lvls] = 5;
$SkillStack[1,3] = mAgl;
$SkillStack[1,3,desc] = "Agility";
$SkillStack[1,3,lvls] = 5;
$SkillStack[1,4] = mPer;
$SkillStack[1,4,desc] = "Perception";
$SkillStack[1,4,lvls] = 5;
$SkillStack[1,5] = mInt;
$SkillStack[1,5,desc] = "Intelligence";
$SkillStack[1,5,lvls] = 5;

$SkillStack[2] = "Thievery:";
$SkillStack[2,1] = htWr;
$SkillStack[2,1,desc] = "Hot Wiring";
$SkillStack[2,1,lvls] = 3;
$SkillStack[2,2] = stel;
$SkillStack[2,2,desc] = "Stealing";
$SkillStack[2,2,lvls] = 3;
$SkillStack[2,3] = loot;
$SkillStack[2,3,desc] = "Looting";
$SkillStack[2,3,lvls] = 3;

$SkillStack[3] = "Cultivation:";
$SkillStack[3,1] = aggr;
$SkillStack[3,1,desc] = "Aggriculture";
$SkillStack[3,1,lvls] = 3;
$SkillStack[3,2] = geol;
$SkillStack[3,2,desc] = "Geology";
$SkillStack[3,2,lvls] = 3;
$SkillStack[3,3] = metl;
$SkillStack[3,3,desc] = "Metallurgy";
$SkillStack[3,3,lvls] = 3;

$SkillStack[4] = "Trade-skill:";
$SkillStack[4,1] = herb;
$SkillStack[4,1,desc] = "Herbology";
$SkillStack[4,1,lvls] = 1;
$SkillStack[4,2] = meng;
$SkillStack[4,2,desc] = "Mechanical Engineering";
$SkillStack[4,2,lvls] = 1;
$SkillStack[4,3] = eeng;
$SkillStack[4,3,desc] = "Electrical Engineering";
$SkillStack[4,3,lvls] = 1;
$SkillStack[4,4] = arch;
$SkillStack[4,4,desc] = "Architecture";
$SkillStack[4,4,lvls] = 1;
$SkillStack[4,5] = avia;
$SkillStack[4,5,desc] = "Aviation";
$SkillStack[4,5,lvls] = 1;

$SkillStack[5] = "Special:";
$SkillStack[5,1] = Life;
$SkillStack[5,1,desc] = "Life";
$SkillStack[5,1,lvls] = 1;

//-Does this skill have a usable function?
%num = -1;
$SkillFunc[%num++] = htWr;
$SkillFunc[%num,desc] = "Hot Wire";
$SkillFunc[%num++] = stel;
$SkillFunc[%num,desc] = "Steal";
$SkillFunc[%num++] = loot;
$SkillFunc[%num,desc] = "Loot";
$SkillFunc[%num++] = aggr;
$SkillFunc[%num,desc] = "Aggriculture";
$SkillFunc[%num++] = geol;
$SkillFunc[%num,desc] = "Geology";
$SkillFunc[%num++] = metl;
$SkillFunc[%num,desc] = "Metallurgy";
$SkillFunc[%num++] = herb;
$SkillFunc[%num,desc] = "Herbology";
$SkillFunc[%num++] = meng;
$SkillFunc[%num,desc] = "Mech Eng";
$SkillFunc[%num++] = eeng;
$SkillFunc[%num,desc] = "Elec Eng";

//-Does this skill have an onTrain callback function?
$SkillCall[mStr] = true;
$SkillCall[mStm] = true;
$SkillCall[mAgl] = true;
$SkillCall[mPer] = true;

function Skill::toggleMenu(%clientId)
{
	//%id = Aeon::getAeonID(%clientId);
	Skill::initMenu(%clientId,"",true);
	return;
}

function Skill::initMenu(%clientId,%start)
{
	if(!%start)
		%start = 0;
	%id = Aeon::getAeonID(%clientId);
	%max = Skill::stackCount();
	Client::buildMenu(%clientId,"Skills Points: "@Skill::getPoints(%clientId),"skillMenu",true);
	%count = 0;
	for(%i = 1; $SkillStack[%start+1] != "" && %count < 6 && %i <= %max; %i++) {
		%stats = Skill::getStats(%clientId,%i);
		if(%count < 5) {
			if(Knowledge::getStackKnow(%id,%start++) > 0) {
				Client::addMenuItem(%clientId,%count++@$SkillStack[%start],"Skill "@%start);
				schedule("Skill::showInfo("@%clientId@","@%count@",\""@%stats@"\");",0.1,%clientId);
			}
		}
		else {
			if($SkillStack[%count+1] != "")
				Client::addMenuItem(%clientId,%count++@"Next...","next "@%start);
			else {
				if(Knowledge::getStackKnow(%id,%start++) > 0) {
					Client::addMenuItem(%clientId,%count++@$SkillStack[%start],"Skill "@%start);
					schedule("Skill::showInfo("@%clientId@","@%count@",\""@%stats@"\");",0.1,%clientId);
				}
			}
		}
	}
	if(%count < 6)
		Client::addMenuItem(%clientId,%count++@"*Reset Points","reset");
	Client::addMenuItem(%clientId,%count++@"Exit","exit");
}

function processMenuSkillMenu(%clientId,%opt)
{
	%op1 = getWord(%opt,0);
	%op2 = getWord(%opt,1);
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
	}
	else if(%op1 == "next") {
		Skill::initMenu(%clientId,%op2);
	}
	else if(%op1 == "Skill") {
		Skill::menuSkills(%clientId,%op2);
	}
	else if(%op1 == "reset") {
		Skill::resetSkills(%clientId,"all");
	}
	else {

	}
}

function Skill::menuSkills(%clientId,%skill,%start)
{
	if(!%start)
		%start = 0;
	%id = Aeon::getAeonID(%clientId);
	Client::buildMenu(%clientId,$SkillStack[%skill]@"->Skills Points: "@Skill::getPoints(%clientId),"skillMenuChild",true);
	%oldStart = %start;
	%count = 0;
	for(%i = 1; $SkillStack[%skill,%start+1] != "" && %count < 6; %i++) {
		if(%count < 5) {
			%skll = $SkillStack[%skill,%start++];
			if($Aeon::ClientInfo[%id,know,%skll] >= 1 || $SkillStack[%skill] == "Attributes:") {
				Client::addMenuItem(%clientId,%count++@$SkillStack[%skill,%start,desc],"skill "@%skill@" "@%start@" "@%oldStart);
				Skill::showInfo(%clientId,%count,Skill::getStats(%clientId,%skill,%start));
			}
		}
		else {
			if($SkillStack[%skill,%count+1] != "")
				Client::addMenuItem(%clientId,%count++@"Next...","next "@%start);
			else {
				%skll = $SkillStack[%skill,%start++];
				if($Aeon::ClientInfo[%id,know,%skll] >= 1 || $SkillStack[%skill] == "Attributes:") {
					Client::addMenuItem(%clientId,%count++@$SkillStack[%skill,%start,desc],"skill "@%skill@" "@%start@" "@%oldStart);
					Skill::showInfo(%clientId,%count,Skill::getStats(%clientId,%skill,%start));
				}
			}
		}
	}
	Client::addMenuItem(%clientId,%count++@"Back","back");
}

function processMenuSkillMenuChild(%clientId,%opt)
{
	%op1 = getWord(%opt,0);
	%op2 = getWord(%opt,1);
	%op3 = getWord(%opt,2);
	%op4 = getWord(%opt,3);
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
	}
	else if(%op1 == "back") {
		Skill::initMenu(%clientId);
	}
	else if(%op1 == "next") {
		Skill::menuSkills(%clientId,%op2);
	}
	else if(%op1 == "skill") {
		%id = Aeon::getAeonId(%clientId);
		%pnts = Skill::getPoints(%clientId);
		%skill = $SkillStack[%op2,%op3];
		%lvls = $SkillStack[%op2,%op3,lvls];
		%cur = $Aeon::ClientInfo[%id,skll,%skill];
		if($Aeon::ClientInfo[%id,know,%skill] > %cur || $SkillStack[%op2] == "Attributes:") {
			if(%pnts > 0 && %lvls > %cur) {
				%spnt = $Aeon::ClientInfo[%id,skll,%skill]++;
				$Aeon::ClientInfo[%id,pnts]--;
				if($SkillCall[%skill] == true)
					Eval(%skill@"::onTrain("@%clientId@","@%spnt@");");
				Skill::storePoint(%id,%skill);
				Aeon::ExportInfo(%clientId);
			}
			if(%cur == %lvls)
				bottomPrint(%clientId,"<jc><f3>You have <f2>Mastered<f3> the skill of <f1>"@$SkillStack[%op2,%op3,desc]@"<f3>!",5);
		}
		else if(%cur < %lvls)
			bottomPrint(%clientId,"<jc><f3>You lack the <f2>Knowledge<f3> to learn <f1>"@$SkillStack[%op2,%op3,desc]@"<f3> level <f1>"@%cur+1@"<f3>.",5);
		Skill::menuSkills(%clientId,%op2,%op4);
	}
	else {
		
	}
}

function Knowledge::getStackKnow(%id,%stack)
{
	%know = 0;
	for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
		%skill = $SkillStack[%stack,%i];
		if($Aeon::ClientInfo[%id,know,%skill] >= 1 || $SkillStack[%stack] == "Attributes:")
			%know++;
	}
	return %know;
}

function Knowledge::setKnow(%clientId,%skill,%value)
{
	if(!%value)
		%value = 1;
	%id = Aeon::getAeonId(%clientId);
	$Aeon::ClientInfo[%id,know,%skill] = %value;
	Aeon::ExportInfo(%clientId);
}

function Knowledge::memLoss(%clientId,%stack)
{
	%id = Aeon::getAeonId(%clientId);
	$Aeon::ClientInfo[%id,skll,spentStr] = "";
	if(!%stack || %stack < 0 || %stack == "all") {
		for(%i = 1; $SkillStack[%i] != ""; %i++)
			Knowledge::memLoss(%clientId,%i);
		if(Skill::getPoints(%clientId) != Calc::abs($Aeon::ClientInfo[%id,krma]))
			$Aeon::ClientInfo[%id,pnts] = Calc::abs($Aeon::ClientInfo[%id,krma]);
		return;
	}
	else {
		%points = 0;
		for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
			%skill = $SkillStack[%stack,%i];
			%points += $Aeon::ClientInfo[%id,skll,%skill];
			$Aeon::ClientInfo[%id,know,%skill] = 0;
			$Aeon::ClientInfo[%id,skll,%skill] = 0;
			if($SkillCall[%skill] == true)
				Eval(%skill@"::onTrain("@%clientId@",\"0\");");
		}
		$Aeon::ClientInfo[%id,pnts] += %points;
		bottomPrint(%clientId,"<jc><f1>Your Memory has been Erased!.",5);
	}
	Aeon::ExportInfo(%clientId);
}

function Knowledge::giveAll(%clientId,%stack)
{
	%id = Aeon::getAeonId(%clientId);
	$Aeon::ClientInfo[%id,skll,spentStr] = "";
	if(!%stack || %stack < 0 || %stack == "all") {
		for(%i = 1; $SkillStack[%i] != ""; %i++)
			Knowledge::giveAll(%clientId,%i);
		return;
	}
	else {
		for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
			%skill = $SkillStack[%stack,%i];
			$Aeon::ClientInfo[%id,know,%skill] = $SkillStack[%stack,%i,lvls];
		}
		bottomPrint(%clientId,"<jc><f1>Your Memory has been Overloaded!.",5);
	}
	Aeon::ExportInfo(%clientId);
}

function Skill::resetSkills(%clientId,%stack)
{
	%id = Aeon::getAeonId(%clientId);
	$Aeon::ClientInfo[%id,skll,spentStr] = "";
	if(!%stack || %stack < 0 || %stack == "all") {
		for(%i = 1; $SkillStack[%i] != ""; %i++)
			Skill::resetSkills(%clientId,%i);
		if(Skill::getPoints(%clientId) != Calc::abs($Aeon::ClientInfo[%id,krma]))
			$Aeon::ClientInfo[%id,pnts] = Calc::abs($Aeon::ClientInfo[%id,krma]);
		return;
	}
	else {
		%points = 0;
		for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
			%skill = $SkillStack[%stack,%i];
			%points += $Aeon::ClientInfo[%id,skll,%skill];
			$Aeon::ClientInfo[%id,skll,%skill] = 0;
			if($SkillCall[%skill] == true)
				Eval(%skill@"::onTrain("@%clientId@",\"0\");");
		}
		$Aeon::ClientInfo[%id,pnts] += %points;
		bottomPrint(%clientId,"<jc><f1>Skill points have been reset.",5);
	}
	Aeon::ExportInfo(%clientId);
}

function Skill::storePoint(%id,%lastSkill)
{
	%list = $Aeon::ClientInfo[%id,skll,spentStr];
	if(%list == " ")
		%list = "";
	$Aeon::ClientInfo[%id,skll,spentStr] = %list@%lastSkill@" ";
}

function Skill::loseSkill(%id,%skill)
{
	%list = AeonStr::trim($Aeon::ClientInfo[%id,skll,spentStr]);
	if(String::findSubStr(%list,%skill) != -1 && $Aeon::ClientInfo[%id,skll,%skill] > 0) {
		%x = String::indexOf(%list,%skill);
		%part1 = String::getSubStr(%list,0,%x-1);
		%part2 = AeonStr::trim(String::getSubStr(%list,%x+5,AeonStr::len(%list)));
		$Aeon::ClientInfo[%id,skll,spentStr] = %part1@%part2;
		$Aeon::ClientInfo[%id,skll,%skill]--;
		$Aeon::ClientInfo[%id,pnts]++;
		Aeon::ExportInfo(%clientId);
	}
}

function Skill::losePoint(%id)
{
	%list = AeonStr::trim($Aeon::ClientInfo[%id,skll,spentStr]);
	%len = AeonStr::len(%list);
	if(%len > 1) {
		%new = String::getSubStr(%list,0,%len-5)@" ";
		if(%new == " ")
			%new = "";
		$Aeon::ClientInfo[%id,skll,spentStr] = %new;
	}
	else
		return false;	
}

function Skill::lastPoint(%id)
{
	%list = $Aeon::ClientInfo[%id,skll,spentStr];
	if(%list == " " || %list == "") {
		$Aeon::ClientInfo[%id,skll,spentStr] = "";
		return false;
	}
	%count = AeonStr::getWordCount(%list);
	if(%count > 0)
		return getWord(%list,%count-1);
	else
		return false;
}

function Skill::getStats(%clientId,%stack,%skill)
{
	%id = Aeon::getAeonId(%clientId);
	if(%skill) {
		%desc = $SkillStack[%stack,%skill,desc];
		%lvls = $SkillStack[%stack,%skill,lvls];
		%spnt = $Aeon::ClientInfo[%id,skll,$SkillStack[%stack,%skill]];
		if(!%spnt)
			%spnt = $Aeon::ClientInfo[%id,skll,$SkillStack[%stack,%num]] = 0;
	}
	else {
		%desc = $SkillStack[%stack];
		%spnt = Skill::stackSpent(%clientId,%stack);
		%lvls = Skill::stackLevels(%stack,%id);
	}
	%info = %desc@": ("@%spnt@"/"@%lvls@")";
	return %info;
}

function Skill::getSkillRatio(%clientId,%skillName)
{
	%id = Aeon::getAeonId(%clientId);
	%stack = getWord(Skill::getSkillStack(%skillName),0);
	%skill = getWord(Skill::getSkillStack(%skillName),1);
	%lvls = $SkillStack[%stack,%skill,lvls];
	%pnts = $Aeon::ClientInfo[%id,skll,%skillName];
	if(!%pnts || %pnts < 1) {
		%ratio = $Aeon::ClientInfo[%id,skll,%skillName] = 0;
	}
	else
		%ratio = %pnts/%lvls;
	return %ratio;
}

function Skill::getSkillStack(%skillName)
{
	for(%i = 1; $SkillStack[%i] != ""; %i++) {
		%num = Skill::inStack(%skillName,%i);
		if(%num != false)
			return %i@" "@%num;
	}
	return false;
}

function Skill::inStack(%skillName,%stack)
{
	for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
		//echo(%skillName@" : "@$SkillStack[%stack,%i]);
		if($SkillStack[%stack,%i] == %skillName)
			return %i;
	}
	return false;
}

function Skill::getStackByName(%stackName)
{
	for(%i = 1; $SkillStack[%i] != ""; %i++) {
		if($SkillStack[%i] == %stackName)
			return %i;
	}
}

function Skill::hasFunc(%skill)
{
	for(%i = 1; $SkillFunc[%i] != ""; %i++) {
		if($SkillFunc[%i] == %skill)
			return true;
	}
	return false;
}

function Skill::showInfo(%clientId,%line,%info)
{
	%head = "-------------------------Skills-------------------------";
	remoteEval(%clientId,"setInfoLine",1,%head);
	remoteEval(%clientId,"setInfoLine",%line++,%info);
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	remoteEval(%clientId,"setInfoLine",%line++,"");
	return;
}

function Skill::getPoints(%clientId)
{
	%id = Aeon::getAeonId(%clientId);
	%karma = $Aeon::ClientInfo[%id,pnts];
	if(%karma > Calc::abs($Aeon::ClientInfo[%id,krma]))
		%karma = $Aeon::ClientInfo[%id,pnts] = Calc::abs($Aeon::ClientInfo[%id,krma]);
	return floor(%karma);
}

function Skill::stackCount()
{
	%count = 0;
	for(%i = 1; $SkillStack[%i] != ""; %i++)
		%count++;
	return %count;
}

function Skill::skillCount()
{
	%count = 0;
	for(%i = 1; $SkillStack[%i] != ""; %i++) {
		%x = 1;
		while($SkillStack[%i,%x] != "") {
			%count++;
			%x++;
		}
	}
	return %count;
}

function Skill::stackSpent(%clientId,%stack)
{
	%id = Aeon::getAeonId(%clientId);	
	%count = 0;
	for(%i = 1; $SkillStack[%stack,%i] != ""; %i++)
		%count += $Aeon::ClientInfo[%id,skll,$SkillStack[%stack,%i]];
	return %count;
}

function Skill::stackLevels(%stack,%id)
{
	%count = 0;
	if(%id == "" || %id < 0 || %id == false) {
		for(%i = 1; $SkillStack[%stack,%i] != ""; %i++)
			%count += $SkillStack[%stack,%i,lvls];
	}
	else {
		for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
			%skill = $SkillStack[%stack,%i];
			if($Aeon::ClientInfo[%id,know,%skill] >= 1 || $SkillStack[%stack] == "Attributes:")
				%count += $SkillStack[%stack,%i,lvls];
		}
	}
	return %count;
}

function Skill::getSkillNum(%stack,%skill)
{
	for(%i = 1; $SkillStack[%stack,%i] != ""; %i++) {
		if(%skill == $SkillStack[%stack,%i])
			return %i;
	}
	return false;
}

function Skill::getDesc(%skill)
{
	%word = Skill::getSkillStack(%skill);
	%stack = getWord(%word,0);
	%num = getWord(%word,1);
	return $SkillStack[%stack,%num,desc];
}

function Skill::getFuncDesc(%skill)
{
	for(%i = 1; $SkillFunc[%i] != ""; %i++) {
		if($SkillFunc[%i] == %skill)
			return $SkillFunc[%i,desc];
	}
	return false;
}

function Skill::setAttr(%clientId)
{
	if(%clientId == -1)
		return;
	%id = Aeon::getAeonID(%clientId);
	for(%i = 1; $SkillStack[1,%i] != ""; %i++) {
		%skill = $SkillStack[1,%i];
		if($SkillCall[%skill] == true) {
			%value = $Aeon::ClientInfo[%id,skll,%skill];
			Eval(%skill@"::onTrain("@%clientId@",\""@%value@"\");");
		}
	}
}

//----------------------------------------------------------------------------

function Attributes::updateArmor(%clientId)
{
	%id = Aeon::getAeonId(%clientId);
	%player = Client::getOwnedObject(%clientId);
	%add = "0";
	%str = $Aeon::ClientInfo[%id,skll,mStr];
	%stm = $Aeon::ClientInfo[%id,skll,mStm];
	%agl = $Aeon::ClientInfo[%id,skll,mAgl];
	if(%str >= 5 && %stm >= 5 && %agl >= 5) {
		%add = "3";		
	}
	else if(%str >= 3 && %stm >= 3 && %agl >= 3) {
		%add = "2";
	}
	else if(%str >= 1 && %stm >= 1 && %agl >= 1) {
		%add = "1";
	}
	else
		%add = "0";
	Aeon::setArmor(%player,"Armor"@%add);
}

function mStr::onTrain(%clientId,%num)
{
	Attributes::updateArmor(%clientId);
}

function mStm::onTrain(%clientId,%num)
{
	Attributes::updateArmor(%clientId);
}

function mAgl::onTrain(%clientId,%num)
{
	%player = Client::getOwnedObject(%clientId);
	Player::setItemCount(%player,"Mass_Less_1",0);
	Player::setItemCount(%player,"Mass_Less_2",0);
	Player::setItemCount(%player,"Mass_Less_3",0);
	Player::setItemCount(%player,"Mass_Less_4",0);
	Player::setItemCount(%player,"Mass_Less_5",0);
	if(%num > 0 && %num <= 5)
		Player::mountItem(%player,"Mass_Less_"@%num,3);
	Attributes::updateArmor(%clientId);
}

function mPer::onTrain(%clientId,%num)
{
	%player = Client::getOwnedObject(%clientId);
	Player::setItemCount(%player,"Light_1",0);
	Player::setItemCount(%player,"Light_2",0);
	Player::setItemCount(%player,"Light_3",0);
	Player::setItemCount(%player,"Light_4",0);
	Player::setItemCount(%player,"Light_5",0);
	if(%num > 0 && %num <= 5)
		Player::mountItem(%player,"Light_"@%num,6);
}

//----------------------------------------------------------------------------

function SkillFunc::htWr(%clientId,%msg)
{
	%player = Client::getOwnedObject(%clientId);
	if(getSimTime() > %clientId.lastHWtime + 1 && GameBase::getLOSinfo(%player,5)) {
		%obj = $los::object;
		if(getObjectType(%obj) == "Flier") {
			%title = $CatalogName[$VehicleToItem[GameBase::getDataName(%obj)]];
			if(%obj.owner == %clientId) {
				%clientId.hasKey[%obj] = true;
				bottomPrint2(%clientId,"<jc><f3>This is your "@%title@"...",1,"C_BuySell.wav");
				return false;
			}
			%rqSk = 0;
			%tPos = GameBase::getPosition(%obj);
			%tRot = GameBase::getRotation(%obj);
			%skll = Skill::getSkillRatio(%clientId,"htWr");
			if((%prop = Aeon::inProperty(%tPos))) {
				if(Property::getOwner(%prop) == Aeon::getAeonID(%obj.owner)) {
					%rqSk++;
					if($Aeon::property[%prop,prprt] != "PD")
						%rqSk++;
					if($Aeon::property[%prop,prprt] == "PP")
						%rqSk++;
				}
				else if(Property::getOwner(%prop) == Aeon::getAeonID(%clientId))
					%rqSk++;
			}
			else
				%rqSk++;
			%skll *= 3;
			if(%skll >= %rqSk) {
				if(Vehicle::canMount(%obj,%player)) {
					%dif = %skll - %rqSk;
					%clientId.isHWing = 1;
					%obj.hotWiring = %player;
					bottomPrint(%clientId,"<jc><f3>Hotwiring...",7);
					schedule("Vehicle::hotWire("@%clientId@","@%obj@");",7-%dif,%obj);
					return true;
				}
				else {
					bottomPrint2(%clientId,"<jc><f3>You can't hotwire a "@%title@" with some one in it...",1,"C_BuySell.wav");
					return false;
				}
			}
			else {
				bottomPrint2(%clientId,"<jc><f3>You aren't skilled enough to hotwire the "@%title@".",1,"C_BuySell.wav");
				return false;
			}
		}
		%clientId.lastHWtime = getSimTime();
	}
}

function Vehicle::hotWire(%clientId,%veh)
{
	%id = Aeon::getAeonID(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(Vehicle::canMount(%veh,%player) && %clientId.hasKey[%veh] != true && %clientId.isHWing) {
		%data = GameBase::getDataName(%veh);
		$Aeon::ClientInfo[%id,krma] += Karma::getChange(take,%data);
		%clientId.hasKey[%veh] = true;
		%title = $CatalogName[$VehicleToItem[%data]];
		bottomPrint2(%clientId,"<jc><f3>You hotwired the <f1>"@%title@"<f3>.",3,"failpack.wav");
		schedule(%clientId@".hasKey["@%veh@"] = \"\";",2.0,%clientId);
	}
	schedule(%veh@".hotWiring = \"\";",1.0,%veh);
	%clientId.isHWing = "";
}

function SkillFunc::stel(%clientId,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(getSimTime() > %clientId.lastSTtime + 1 && GameBase::getLOSinfo(%player,5)) {
		%obj = $los::object;
		if(getObjectType(%obj) == "Player" && !Player::isDead(%obj)) {
			%tPos = GameBase::getPosition(%obj);
			%tRot = GameBase::getRotation(%obj);
			if((%skll = $Aeon::ClientInfo[%id,skll,stel]) > %rqSk) {
				
			}
			else {
				bottomPrint2(%clientId,"<jc><f3>You aren't skilled enough to steal from "@Client::getName(Player::getClient(%obj))@".",1,"C_BuySell.wav");
				return false;
			}
		}
		%clientId.lastSTtime = getSimTime();
	}
}

function SkillFunc::loot(%clientId,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	if(getSimTime() > %clientId.lastLTtime + 1) {
		%player = Client::getOwnedObject(%clientId);
		%pos = GameBase::getPosition(%player);
		%set = newObject("set",SimSet);
		if(containerBoxFillSet(%set,$SimPlayerType|$CorpseObjectType,%pos,5,5,6,-3)) {
			if(Group::objectCount(%set) > 0) {
				for(%i = 0; %i < Group::objectCount(%set); %i++) {
					%object = Group::getObject(%set,%i);
					if(%object != %player && Player::isDead(%obj))
						break;
				}
				if(Player::isDead(%object)) {
					%looted = 0;
					%tPos = GameBase::getPosition(%object);
					%tRot = GameBase::getRotation(%object);
					%mountedWeap = Player::getMountedItem(%object,$WeaponSlot);
					%mountedPack = Player::getMountedItem(%object,$BackPackSlot);
					%skll = $Aeon::ClientInfo[%id,skll,loot];
					if(%skll >= 6) {
						for(%i = 0; %i < getNumItems(); %i++) {
							%item = getItemData(%i);
							if((%count = Player::getItemCount(%object,%item)) > 0) {
								if(%item.className != HandAmmo && %item.className != Armor) {
									%give = %count*(%skll-6)/3;
									if(%give < 1)
										%give = 1;
									%looted+=%give;
									Item::giveItem(%player,%item,%give,"",%tPos);
									Player::decItemCount(%object,%item,%count);
								}
							}
						}
					}
					else if(%skll >= 3) {
						Item::giveItem(%player,%mountedWeap,1,"",%tPos);
						Item::giveItem(%player,%mountedPack,1,"",%tPos);
						Player::decItemCount(%object,%mountedWeap);
						Player::decItemCount(%object,%mountedPack);
						%looted+=2;
					}
					else if(%skll > 0 && %mountedWeap != -1) {
						Item::giveItem(%player,%mountedWeap,1,"",%tPos);
						Player::decItemCount(%object,%mountedWeap);
						%looted++;
					}
					else
						bottomPrint2(%clientId,"<jc><f3>You aren't skilled enough to loot here.",3,"C_BuySell.wav");
					bottomPrint(%clientId,"<jc><f3>You got <f2>"@%looted@"<f3> Items.",5);
				}
				else
					bottomPrint2(%clientId,"<jc><f3>They have to be dead first... Hmm...",2,"C_BuySell.wav");
			}
		}
		deleteObject(%set);
		%clientId.lastLTtime = getSimTime();
	}
}

function SkillFunc::aggr(%clientId,%msg)
{
	if(%clientId.isReading)
		return;
	%id = Aeon::getAeonID(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(GameBase::getLOSInfo(%player,5)) {
		%obj = $los::object;
		%lPs = $los::position;
		$los::object = "";
		$los::position = "";
		%data = GameBase::getDataName(%obj);
		if(%data.className == "Harvest") {
			%type = $Aeon::SeedType[%data,%obj.type];
			if(String::findSubStr(%type,"Vege") == 0) {
				if(!%obj.treated) {
					%rate = %obj.rate;
					%ratio = Skill::getSkillRatio(%clientId,aggr);
					%obj.rate = %rate+(%rate*%ratio);
					%obj.treated = true;
					bottomPrint(%clientId,"<jc><f3>Fertilizing <f1>"@%type.description@"<f3>...",3);
					Karma::result(%id,"skill aggr");
				}
				else {
					bottomPrint(%clientId,Harvest::getStats(%obj),3);
				}
				return;
			}
		}
	}
	bottomPrint(%clientId,"<jc><f3>No Vegetation found.",1);
}

function SkillFunc::geol(%clientId,%msg)
{
	if(%clientId.isReading)
		return;
	%id = Aeon::getAeonID(%clientId);
	%posP = GameBase::getPosition(%clientId);
	%found = 0;
	for(%i = 0; $Aeon::Seismic[%i] != ""; %i++) {
		%seis = $Aeon::Seismic[%i];
		%posS = getWord(%seis,0)@" "@getWord(%seis,1)@" "@getWord(%seis,2);
		%radS = getWord(%seis,3);
		%rati = Skill::getSkillRatio(%clientId,geol);
		%rad = %radS*((2*%rati)+1);
		%dist = Vector::getDistance(%posP,%posS);
		if(!%closest)
			%closest = %posS;
		if(%dist < %rad) {
			%found++;
			if(%dist < Vector::getDistance(%posP,%closest))
				%closest = %posS;
			bottomPrint(%clientId,"<jc><f2>Seismic Activity!",1);
		}
	}
	if(%found < 1) {
		bottomPrint(%clientId,"<jc><f3>No Seismic Activity Found...",1);
	}
	else {
		String::dispRot(%clientId,%closest,5);
	}
}

function SkillFunc::metl(%clientId,%msg)
{
	if(%clientId.isReading)
		return;
	%id = Aeon::getAeonID(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(GameBase::getLOSInfo(%player,5)) {
		%obj = $los::object;
		%lPs = $los::position;
		$los::object = "";
		$los::position = "";
		%data = GameBase::getDataName(%obj);
		if(%data.className == "Harvest") {
			%type = $Aeon::SeedType[%data,%obj.type];
			if(String::findSubStr(%type,"Ore") == 0 || String::findSubStr(%type,"Mineral") == 0 ) {
				if(!%obj.checked) {
					Karma::result(%id,"skill metl");
					%obj.checked = true;
				}
				bottomPrint(%clientId,Harvest::getStats(%obj),3);
				return;
			}
		}
	}
	bottomPrint(%clientId,"<jc><f3>No Metallic Ore found.",1);
}

function SkillFunc::herb(%clientId,%msg)
{
	//-
}

function SkillFunc::meng(%clientId,%msg)
{
	//-
}

function SkillFunc::eeng(%clientId,%msg)
{
	//-
}
