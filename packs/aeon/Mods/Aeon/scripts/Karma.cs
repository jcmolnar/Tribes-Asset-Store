$KarmaRate[Def] = 0.0;
$KarmaRate[spamDef] = 0.0;
$KarmaRate[killDef] = 0.0;
$KarmaRate[killPlayer] = 0.0;
$KarmaRate[killGenerator] = 0.0;
$KarmaRate[killVehicle] = 0.0;
$KarmaRate[killScout] = 0.0;
$KarmaRate[killRazor] = 0.0;
$KarmaRate[takeVehicle] = 0.0;
$KarmaRate[takeScout] = 0.0;
$KarmaRate[takeRazor] = 0.0;
$KarmaRate[giveDef] = 0.0;
$KarmaRate[giveCash] = 0.0;
$KarmaRate[giveArmor] = 0.0;
$KarmaRate[giveAmmo] = 0.0;
$KarmaRate[giveWeapon] = 0.0;
$KarmaRate[giveTool] = 0.0;
$KarmaRate[giveBackPack] = 0.0;
$KarmaRate[giveRepair] = 0.0;
$KarmaRate[giveHandAmmo] = 0.0;
$KarmaRate[giveVehicle] = 0.0;
$KarmaRate[giveScout] = 0.0;
$KarmaRate[giveRazor] = 0.0;
$KarmaRate[takeMeteor] = -0.005;
$KarmaRate[farmMeteor] = 0.005;
$KarmaRate[skillhtWr] = -0.5;
$KarmaRate[skillstel] = -0.5;
$KarmaRate[skillloot] = -0.5;
$KarmaRate[skillaggr] = 0.005;
$KarmaRate[skillgeol] = 0.005;
$KarmaRate[skillmetl] = 0.005;
$KarmaRate[skillherb] = 0.005;
$KarmaRate[skillmeng] = 0.005;
$KarmaRate[skilleeng] = 0.005;
$KarmaAffect[high] = 0.05;
$KarmaAffect[high,dur] = 60;

function Karma::result(%id,%act)
{
	%karma = $Aeon::ClientInfo[%id,krma];
	%ratio = 1/(Calc::abs(floor(%karma))+1);
	%amount = Karma::getChange(getWord(%act,0),getWord(%act,1));
	%high = Aeon::getHigh(%id);
	%high = $KarmaAffect[high]*%high;
	if(%high > 0)
		%ratio *= (%high+1);
	if(Calc::abs(%amount) > 0)
		return Karma::level(%id,%ratio*%amount);
	return false;
}

function Karma::getChange(%pre,%item)
{
	if(%pre != "kill" && %pre != "take" && %pre != "farm" && %pre != "give" && %pre != "skill" && $KarmaRate[%pre] == "")
		return $KarmaRate[Def];
	%karma = $KarmaRate[%pre@%item];
	if(%karma == "")
		%karma = $KarmaRate[%pre@%item.className];
	if(%karma == "")
		%karma = $KarmaRate[%pre@"Def"];
	if(%pre == "kill" || %pre == "take" || %pre == "spam")
		%karma *= -1;
	return %karma;
}

function Karma::level(%id,%add)
{
	%clientId = Aeon::getClient(%id,true);
	%sched = 0.1;
	while(Calc::abs(%add) >= 1) {
		%dir = 1;
		if(%add < 0)
			%dir = -1;
		%old = floor($Aeon::ClientInfo[%id,krma]);
		%karma = $Aeon::ClientInfo[%id,krma]+=%dir;
		if((Calc::abs(%karma) > Calc::abs(%old))) {
			%points = $Aeon::ClientInfo[%id,pnts]++;
			%msg = "<jc><f1>You gained 1 Skill Point!";
			schedule("bottomPrint("@%clientId@",\"\",1);",%sched-0.1);
			schedule("bottomPrint("@%clientId@",\""@%msg@"\",1);",%sched);
		}
		else {
			schedule("bottomPrint("@%clientId@",\"\",1);",%sched-0.1);
			schedule("Karma::degrade(\""@%id@"\","@%old@");",%sched);
		}
		if(%dir > 0)
			%add--;
		else if(%dir < 0)
			%add++;
		else
			echo("wtf?!");
		%sched+=0.5;
	}
	if(Calc::abs(%add) >= 0) {
		%old = floor($Aeon::ClientInfo[%id,krma]);
		%karma = $Aeon::ClientInfo[%id,krma]+=%add;
		%diff = Calc::abs(floor(%karma)-%old);
		if(%diff >= 1 && (Calc::abs(%karma) > Calc::abs(%old))) {
			%points = $Aeon::ClientInfo[%id,pnts] += %diff;
			bottomPrint(%clientId,"<jc><f1>You gained a Skill Point!",1);
		}
		else if(Calc::abs(%karma) < Calc::abs(%old))
			Karma::degrade(%id,%old,%diff);
	}
	echo("Karma: "@%id@" : "@$Aeon::ClientInfo[%id,krma]);
	Aeon::ExportInfo(%clientId);
	Game::refreshClientScore(%clientId);
	return true;
}

function Karma::degrade(%id,%krma)
{
	%clientId = Aeon::getClient(%id,true);
	%pnts = $Aeon::ClientInfo[%id,pnts];
	if(%pnts > 0) {
		if(%pnts >= %diff) {
			$Aeon::ClientInfo[%id,pnts]--;
			bottomPrint(%clientId ,"<jc><f1>You lost 1 Skill Point!",1);
		}
	}
	else if(Calc::abs(%krma) >= 1) {
		%lastSkill = Skill::lastPoint(%id);
		%desc = Skill::getDesc(%lastSkill);
		%value = $Aeon::ClientInfo[%id,skll,%lastSkill]--;
		bottomPrint(%clientId,"<jc><f1>You lost 1 Skill Point in "@%desc@"!",1);
		if($SkillCall[%skill] == true)
			Eval(%skill@"::onTrain("@%clientId@",\""@%value@"\");");
		Skill::losePoint(%id);
	}
}
