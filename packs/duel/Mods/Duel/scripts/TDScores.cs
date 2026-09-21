function testes()
{
	%client = 2049;
	%filename = HoldIPTrim(Client::getTransportAddress(%client));
	%name = nameRepair(%client);
	//$Temp::Save:: $+ %filename $+ [%Batch] = "god";
	//eval("$Temp::Save::" @ %filename @"::" @ %tag @ "::"@ %map @"++;");
	%save = 1;

	%x = 5;
	%a=0;
	%type[0]="TD";
	eval("$Temp::SaveWeapon::"@%filename@"["@ %type[%a] @", "@$Score::statWeapons[%x]@"] = "@%save@";");
	echo($Temp::SaveWeapon[%type[%a], $Score::statWeapons[%x]]);

}

function TeamsReset()
{
	$Teamduel::TotalTeams = "";
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamsReset);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team != "")
		{
			ForceOneObs(%cl);
		}
		%cl.Team = "";
		%cl.Naming = "";
		%cl.TeamJoining = "";
		%cl.Arena = "";
		%cl.notready = "";
		%cl.Owns = "";
		%cl.IsAlive = "";
		%cl.TD = "";
		Game::refreshClientScore(%cl);
	}
	deleteVariables("$TeamDuel*");

}

function FixQuadrant(%quadtrant)
{
	%newstr = "";
	for(%x = 0; String::getSubStr(%quadtrant, %x, 1) != ""; %x++)
	{
		%char = String::getSubStr(%quadtrant, %x, 1);

		if(%char == "_")
		{
			%char = " ";
		}
		%newstr = %newstr @ %char;
		echo(%x@": "@%newstr);

	}
	return %newstr;
}



$verts0 = "legs";
$verts1 = "torso";
$verts2 = "head";
//$StoredStats[1]//IP address
//$StoredStats[2]//Name
//$StoredStats[3]//Password
//$StoredStats[4]//ScoreString
//$StoredStats[5]//Test String

function processMenuAdvScore(%client, %option)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction("ScoreMenu "@%option);
	}
	%time = Time::getMinutes((floor(getSimTime()) - %client.LastAction));
	if(%option != "checkinvites")
	{
		if(%time > 0.9)
		{
			%client.LastAction = floor(getSimTime());
			Game::refreshClientScore(%client);
		}
		else
		{
			%client.LastAction = floor(getSimTime());
		}
	}
	%o = getWord(%option, 0);
	%extra = getWord(%option, 1);
	%extra2 = getWord(%option, 2);
	%extra3 = getWord(%option, 3);
	%extra4 = getWord(%option, 4);
	%extra5 = getWord(%option, 5);
	%extra6 = getWord(%option, 6);
	%extra7 = getWord(%option, 7);

	%i = 0;
	if(%o == "viewadvscore")
	{
		Score::Display(%extra, %client);
		return;
		Client::buildMenu(%client, client::getname(%extra)@" - Stats", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ "Accuracy: "@Stats::Accuracy(%extra)@"%", "Accuracy "@%extra);
		Client::addMenuItem(%client, %i++ @ "Hits: "@Stats::Hits(%extra), "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ "Hits Taken: "@Stats::HitsTaken(%extra), "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ "Head Shots: "@%extra.dmgDoneSpot[head], "HitPoint "@%extra);//"@Stats::StrongPoint(%extra), "HitPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Gets Hit Most: "@Stats::WeakPoint(%extra), "WeakPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Team Kills: "@%extra.TK, "TKerStats "@%extra);
		return;
	}
	if(%o == "Accuracy")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Accuracy", "AdvScore", true);
		//Stats::Accuracy(%client, %weapon)
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[4]@": "@Stats::Accuracy(%extra, 4)@"%", "WeapStats 4 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[3]@": "@Stats::Accuracy(%extra, 3)@"%", "WeapStats 3 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[5]@": "@Stats::Accuracy(%extra, 5)@"%", "WeapStats 5 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[6]@": "@Stats::Accuracy(%extra, 6)@"%", "WeapStats 6 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[1]@": "@Stats::Accuracy(%extra, 1)@"%", "WeapStats 1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[2]@": "@Stats::Accuracy(%extra, 2)@"%", "WeapStats 2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[7]@": "@Stats::Accuracy(%extra, 7)@"%", "WeapStats 7 "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
	if(%o == "WeapStats")
	{
		if(%extra < 6)
		{
			%var = 1;
		}
		else {
			%var = -5;
		}
		Client::buildMenu(%client, client::getname(%extra2)@" - "@$ScoreWeapon[%extra]@"", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ "Shots Fired: "@%extra2.shotsFired[%extra], "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "Shots Hit: "@%extra2.HitsDone[%extra], "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "Shots Missed: "@(%extra2.shotsFired[%extra]-%client.HitsDone[%extra]), "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "Damage Done: "@%extra2.dmgDone[%extra], "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "Hits Taken: "@%extra2.HitsReceived[%extra], "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "Damage Taken: "@%extra2.dmgReceived[%extra], "WeapStats "@%extra+%var@" "@%extra2);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "Accuracy "@%extra2);
		return;
	}
	if(%o == "Hits1")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Hits", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[4]@" Hits: "@%extra.HitsDone[4], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[3]@" Hits: "@%extra.HitsDone[3], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[5]@" Hits: "@%extra.HitsDone[5], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[6]@" Hits: "@%extra.HitsDone[6], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[1]@" Hits: "@%extra.HitsDone[1], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[2]@" Hits: "@%extra.HitsDone[2], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[7]@" Hits: "@%extra.HitsDone[7], "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ "Total Hits: "@Stats::Hits(%extra), "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
	if(%o == "Hits2")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Hits Taken", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[4]@" Hits Taken: "@%extra.HitsReceived[4], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[3]@" Hits Taken: "@%extra.HitsReceived[3], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[5]@" Hits Taken: "@%extra.HitsReceived[5], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[6]@" Hits Taken: "@%extra.HitsReceived[6], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[1]@" Hits Taken: "@%extra.HitsReceived[1], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[2]@" Hits Taken: "@%extra.HitsReceived[2], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ $ScoreWeapon[7]@" Hits Taken: "@%extra.HitsReceived[7], "Hits1 "@%extra);
		Client::addMenuItem(%client, %i++ @ "Total Hits Taken: "@Stats::HitsTaken(%extra), "Hits2 "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
	if(%o == "TKerStats")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Team Damage", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ "Team Kills: "@%extra.TK, "TKerStats "@%extra);
		Client::addMenuItem(%client, %i++ @ "TD Hits: "@%extra.TDHitsDone, "TKerStats "@%extra);
		Client::addMenuItem(%client, %i++ @ "TD Hits Taken: "@%extra.TDHitsDone, "TKerStats "@%extra);
		Client::addMenuItem(%client, %i++ @ "TD Damage Done: "@%extra.TDmgDone, "TKerStats "@%extra);
		Client::addMenuItem(%client, %i++ @ "TD Damage Taken: "@%extra.TDHitsDone, "TKerStats "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
	if(%o == "HitPoint")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Attacks", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ "Head Shots Hit: "@%extra.dmgDoneSpot[head], "WeakPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Body Shots Hit: "@%extra.dmgDoneSpot[torso], "WeakPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Leg Shots Hit: "@%extra.dmgDoneSpot[legs], "WeakPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
	if(%o == "WeakPoint")
	{
		Client::buildMenu(%client, client::getname(%extra)@" - Hits Taken", "AdvScore", true);
		Client::addMenuItem(%client, %i++ @ "Head Shots Taken: "@%extra.dmgReceivedSpot[head], "HitPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Body Shots Taken: "@%extra.dmgReceivedSpot[torso], "HitPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "Leg Shots Taken: "@%extra.dmgReceivedSpot[legs], "HitPoint "@%extra);
		Client::addMenuItem(%client, %i++ @ "<-- Back", "viewadvscore "@%extra);
		return;
	}
}
function remoteDA()
{
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	both($Server::timeLimit - time::getminutes(%curTimeLeft));
}
function HoldHisScore(%client)
{
	%ip = Client::getTransportAddress(%client);
	%ip = HoldIPTrim(%ip);
	if(%client.Loaded)
	{
		$SavedStatesN[%ip] = "";
		$SavedStates[%ip] = "";
		return;
	}
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	%curTimeLeft = ($Server::timeLimit - time::getminutes(%curTimeLeft)) - 1;
	if(Kills(%client)+Midairs(%client) != "0" && %curTimeLeft > 1)
	{
		$SavedStatesN[%ip] = Client::getName(%client);
		$SavedStates[%ip] = HoldScoreString(%client);
	}
}
function Score::ResetRoundStats(%client)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%client.ThisRoundDamagedDoneID[%cl] = 0;
		%client.ThisRoundHitsDoneID[%cl] = 0;
		%client.ThisRoundMidAirsDoneID[%cl] = 0;
	}


	for(%x = 0; %x < 14; %x++)
	{
		%client.ThisRoundDamageDone[%x] = "0";
		%client.ThisRoundHitsDone[%x] = "0";


		%client.ThisRoundDamageTaken[%x] = 0;
		%client.ThisRoundHitsTaken[%x] = 0;
		//%client.ThisRoundDamagedIDDone[%x] = "0";
		//%client.ThisRoundDamagedAmountsDone[%x] = "0";
		//%client.ThisRoundHitsTaken[%x] = "0";
		//%client.ThisRoundDamagedIDTaken[%x] = "0";
		//%client.ThisRoundDamagedAmountsTaken[%x] = "0";
		%client.ThisRoundMidAirs[%x] = "0";
	}
	%client.ThisRoundTotalHitsDone = 0;
	%client.ThisRoundTotalShotsFired = 0;
	%client.ThisRoundTotalDamageDone = 0;
	%client.ThisRoundTotalMidAirs = 0;
	%client.ThisRoundTotalDamageTaken = 0;
	%client.ThisRoundTotalHitsTaken = 0;
	%client.haswpTarget = false;
	IssueCommand(%cl, %cl, 0, "");
	setCommandStatus(%cl, 0, "");
}
function Teamduel::ClientRoundReset(%client)
{

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%client.ThisRoundDamagedDoneID[%cl] = 0;
		%client.ThisRoundHitsDoneID[%cl] = 0;
	}
	for(%x = 0; %x < 14; %x++)
	{
		%client.ThisRoundDamageDone[%x] = "0";
		%client.ThisRoundHitsDone[%x] = "0";


		//%client.ThisRoundDamagedIDDone[%x] = "0";
		//%client.ThisRoundDamagedAmountsDone[%x] = "0";
		//%client.ThisRoundHitsTaken[%x] = "0";
		//%client.ThisRoundDamagedIDTaken[%x] = "0";
		//%client.ThisRoundDamagedAmountsTaken[%x] = "0";
		%client.ThisRoundMidAirs[%x] = "0";
	}
	%client.ThisRoundTotalHitsDone = 0;
	%client.ThisRoundTotalShotsFired = 0;
	%client.ThisRoundTotalDamageDone = 0;
	%client.ThisRoundTotalMidAirs = 0;
	%client.ThisRoundTotalKills = 0;
	%client.haswpTarget = false;
	IssueCommand(%cl, %cl, 0, "");
	setCommandStatus(%cl, 0, "");
}









function HoldScoreString(%client)
{
	if(%client.score == "" || %client.score == "False")	{		%client.score = 0;	}
	if(%client.ScoreDeaths == "" || %client.ScoreDeaths == "False")	{		%client.ScoreDeaths = 0;	}
	if(%client.ratio == "" || %client.ratio == "False")	{		%client.ratio = 0;	}
	//if($DuelMidAir[%client] == "" || $DuelMidAir[%client] == "False")	{		$DuelMidAir[%client] = 0;	}
	//if($DuelMaDist[%client] == "" || $DuelMaDist[%client] == "False")	{		$DuelMaDist[%client] = 0;	}
	if($DuelStreak[%client] == "" || $DuelStreak[%client] == "False")	{		$DuelStreak[%client] = 0;	}
	if($DuelBestDisplay[%client] == "" || $DuelBestDisplay[%client] == "False")	{		$DuelBestDisplay[%client] = 9999;	}

	for(%x = 1; %x < 8; %x++)
	{
		if(%client.HitsDone[%x] > %client.shotsFired[%x]) {		%client.shotsFired[%x] = %client.HitsDone[%x] ; }//temp fix
		if(%client.shotsFired[%x] == "" || %client.shotsFired[%x] == "False") {		%client.shotsFired[%x] = "0";	}
		if(%client.dmgDone[%x] == "" || %client.dmgDone[%x] == "False") {		%client.dmgDone[%x] = "0";	}
		if(%client.dmgReceived[%x] == "" || %client.dmgReceived[%x] == "False") {		%client.dmgReceived[%x] = "0";	}
		if(%client.HitsDone[%x] == "" || %client.HitsDone[%x] == "False") {	%client.HitsDone[%x] = "0";	}
		if(%client.HitsReceived[%x] == "" || %client.HitsReceived[%x] == "False") {	%client.HitsReceived[%x] = "0";	}
	}
	if(%client.TDmgDone == "" || %client.TDmgDone == "False") {		%client.TDmgDone = "0";	}
	if(%client.TDmgReceived == "" || %client.TDmgReceived == "False") {		%client.TDmgReceived = "0";	}
	if(%client.TDHitsDone == "" || %client.TDHitsDone == "False") {		%client.TDHitsDone = "0";	}
	if(%client.TDHitsReceived == "" || %client.TDHitsReceived == "False") {		%client.TDHitsReceived = "0";	}
	if(%client.dmgDoneSpot[head] == "" || %client.dmgDoneSpot[head] == "False") {		%client.dmgDoneSpot[head] = "0";	}
	if(%client.dmgDoneSpot[legs] == "" || %client.dmgDoneSpot[legs] == "False") {		%client.dmgDoneSpot[legs] = "0";	}
	if(%client.dmgDoneSpot[torso] == "" || %client.dmgDoneSpot[torso] == "False") {		%client.dmgDoneSpot[torso] = "0";	}
	if(%client.dmgReceivedSpot[head] == "" || %client.dmgReceivedSpot[head] == "False") {		%client.dmgReceivedSpot[head] = "0";	}
	if(%client.dmgReceivedSpot[legs] == "" || %client.dmgReceivedSpot[legs] == "False") {		%client.dmgReceivedSpot[legs] = "0";	}
	if(%client.dmgReceivedSpot[torso] == "" || %client.dmgReceivedSpot[torso] == "False") {		%client.dmgReceivedSpot[torso] = "0";	}
	if(%client.TK == "" || %client.TK == "False") { %client.TK = "0"; }

	for(%x = 1; %x < 8; %x++)
	{
		if(%x == "1")
		{
			%string = %client.shotsFired[%x] ;
		}
		else {
			%string = %string@" "@%client.shotsFired[%x] ;
		}
	}
	for(%x = 1; %x < 8; %x++)
	{
		%string = %string@" "@%client.dmgDone[%x] ;
	}
	for(%x = 1; %x < 8; %x++)
	{
		%string = %string@" "@%client.dmgReceived[%x] ;
	}
	for(%x = 1; %x < 8; %x++)
	{
		%string = %string@" "@%client.HitsDone[%x] ;
	}
	for(%x = 1; %x < 8; %x++)
	{
		%string = %string@" "@%client.HitsReceived[%x] ;
	}
	%string = %string@" "@%client.TDmgDone ;
	%string = %string@" "@%client.TDmgReceived ;
	%string = %string@" "@%client.TDHitsDone ;
	%string = %string@" "@%client.TDHitsReceived ;
	%string = %string@" "@%client.dmgDoneSpot[head] ;
	%string = %string@" "@%client.dmgDoneSpot[legs] ;
	%string = %string@" "@%client.dmgDoneSpot[torso] ;
	%string = %string@" "@%client.dmgReceivedSpot[head] ;
	%string = %string@" "@%client.dmgReceivedSpot[legs] ;
	%string = %string@" "@%client.dmgReceivedSpot[torso] ;
	%string = %string@" "@%client.TK ;
	%string = %string@" "@%client.DMscoreKills@" "@%client.TDscoreKills@" "@%client.DLscoreKills@" "@%client.DLscoreDeaths@" "@%client.TDscoreDeaths@" "@%client.DMscoreDeaths ;
	%string = %string@" "@%client.DLmad@" "@%client.DLmah@" "@%client.TDmad@" "@%client.TDmah@" "@%client.DMmad@" "@%client.DMmah ;

	%string = %client.score@" "@%client.ScoreDeaths@" "@%client.ratio@" "@$DuelStreak[%client]@" "@$DuelBestDisplay[%client]@" "@%string ;


	//old
	//%string = %client.score@" "@%client.ScoreDeaths@" "@%client.ratio@" "@$DuelMidAir[%client]@" "@$DuelMaDist[%client]@" "@$DuelStreak[%client]@" "@$DuelBestDisplay[%client]@" "@%string ;
	//echo(%string);
	return %string;
}
function GetTotalAccuracy(%client)
{
	for(%x = 1; %x < 8; %x++)
	{
		%shots = %shots+%client.shotsFired[%x] ;
		%hits = %hits+%client.HitsDone[%x] ;
	}
	//%ratio = floor(%hits/%shots) ;
	%ratio = floor((%shots/(%shots + %hits))*100);
	return %ratio;
}
function Stats::Accuracy(%client, %weapon)
{
	if(%weapon == "")
	{
		for(%x = 1; %x < 8; %x++)
		{
			%totalShots = %totalShots+%client.shotsFired[%x] ;
			%totalHits = %totalHits+%client.HitsDone[%x] ;
		}
		%accuracy = floor((%totalHits/%totalShots*100));
	}
	else {
		%accuracy = floor((%client.HitsDone[%weapon]/%client.shotsFired[%weapon]*100)) ;
	}
	if(%accuracy < 0 || %accuracy == "+INF" || %accuracy == "")
	{
		%accuracy = 0;
	}
	return %accuracy;
}
function Stats::Hits(%client, %weapon)
{
	if(%weapon == "")
	{
		for(%x = 1; %x < 8; %x++)
		{
			%hits = %hits+%client.HitsDone[%x] ;
		}
	}
	else {
		%hits = %client.HitsDone[%weapon] ;
	}
	if(%hits < 0 || %hits == "+INF" || %hits == "")
	{
		%hits = 0;
	}
	return %hits;
}
function Stats::HitsTaken(%client, %weapon)
{
	if(%weapon == "")
	{
		for(%x = 1; %x < 8; %x++)
		{
			%hits = %hits+%client.HitsReceived[%x] ;
		}
	}
	else {
		%hits = %client.HitsReceived[%weapon] ;
	}
	if(%hits < 0 || %hits == "+INF" || %hits == "")
	{
		%hits = 0;
	}
	return %hits;
}
function Stats::DamageDone(%client, %weapon)
{
	if(%weapon == "")
	{
		for(%x = 1; %x < 8; %x++)
		{
			%hits = %hits+%client.dmgDone[%x] ;
		}
	}
	else {
		%hits = %client.dmgDone[%weapon] ;
	}
	if(%hits < 0 || %hits == "+INF" || %hits == "")
	{
		%hits = 0;
	}
	return %hits;
}
function Stats::WeakPoint(%client)
{
	if(%client.dmgReceivedSpot[head] > %client.dmgReceivedSpot[legs] && %client.dmgReceivedSpot[head] > %client.dmgReceivedSpot[torso])
	{
		return "head";
	}
	else if(%client.dmgReceivedSpot[legs] > %client.dmgReceivedSpot[head] && %client.dmgReceivedSpot[legs] > %client.dmgReceivedSpot[torso])
	{
		return "legs";
	}
	else if(%client.dmgReceivedSpot[torso] > %client.dmgReceivedSpot[legs] && %client.dmgReceivedSpot[torso] > %client.dmgReceivedSpot[head])
	{
		return "torso";
	}
	else {
		return "None";
	}
}
function Stats::StrongPoint(%client)
{
	if(%client.dmgDoneSpot[head] > %client.dmgDoneSpot[legs] && %client.dmgDoneSpot[head] > %client.dmgDoneSpot[torso])
	{
		return "head";
	}
	else if(%client.dmgDoneSpot[legs] > %client.dmgDoneSpot[head] && %client.dmgDoneSpot[legs] > %client.dmgDoneSpot[torso])
	{
		return "legs";
	}
	else if(%client.dmgDoneSpot[torso] > %client.dmgDoneSpot[legs] && %client.dmgDoneSpot[torso] > %client.dmgDoneSpot[head])
	{
		return "torso";
	}
	else {
		return "None";
	}
}
//Replacing old MyRound function... last one didn't like numbers > 10000 and didn't always play nice with the objective screen
//This one will only return a decimal if it is given one then automatically trim to tens if a decimal place isn't specified.
function MyRound(%number, %places)
{
	%wholeNumber = floor(%number);
	%decimalNumber = %number - %wholeNumber;

	if(%places == "" || %places == -1)
	{
		%places = 1;
	}

	//echo("WN "@%wholeNumber);

	if(%decimalNumber > 0.0)
	{
		%decimalNumber = String::GetSubStr(%decimalNumber, 02, %places);

		return %wholeNumber@"."@%decimalNumber;
	}
	else
	{
		return %wholeNumber;
	}
}
%number = "123456.876";
echo("Pre: "@%number);
echo(myround(%number,3));

function Stats::Reboot(%client)
{
	resetClient(%client);
	$Dueling[%client] = "";
	$DuelLineup[%client] = "";
	$DuelLastEnemy[%client] = "";
	$HighStreak[%client] = 0;
	$DuelStreak[%client] = 0;
	$DuelBest[%client] = 9999;
	$DuelBestDisplay[%client] = "00:00";
	$DuelMidAir[%client] = 0;
	$Roaming[%client] = false;
	$DuelMaDist[%client] = 0;
	$SpeedDuel[%client] = "False";
	$DuelarmorType[%client] = "larmor";
	%client.Assists = "0";
	%client.score["KingKills"] = "0";
	%client.MovementType = "Free Move";
	%client.prefs["obsmode"] = "1stPerson";
	%client.guiLock = false;
	%client.Team = "";
	%client.canjump = true;
	%client.cantrigger = true;
	%client.debug = "";
	%client.score = "0";



	//DIE
	%client.TK = "0";
	%client.TKed = "0";

	//%client.password = "";


	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";

	//%client.scoreSuicide = "0";//new


	%client.fagzilla = 0;
	%client.DMJoins = 0;

	setHigh(%client);
	Game::refreshClientScore(%client);



}
function Rebooter()
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Reboot(%cl);
	}
}
function Reboot(%client)
{
%xc = 1;
	$Dueling[%client] = "";
	$DuelLineup[%client] = "";
	$DuelLastEnemy[%client] = "";
	$HighStreak[%client] = %xc++;
	$DuelStreak[%client] = %xc++;
	$DuelBest[%client] = 9999;
	$DuelBestDisplay[%client] = "00:00";
	$DuelMidAir[%client] = %xc++;
	$Roaming[%client] = false;
	$DuelMaDist[%client] = %xc++;
	$SpeedDuel[%client] = "False";
	$DuelarmorType[%client] = "larmor";
	%client.Assists = %xc++;
	%client.score["KingKills"] = %xc++;
	%client.MovementType = "Free Move";
	%client.prefs["obsmode"] = "1stPerson";
	%client.guiLock = false;
	%client.Team = "";
	%client.canjump = true;
	%client.cantrigger = true;
	%client.debug = "";
	%client.score = %xc++;
	%client.DMscoreKills = %xc++;
	%client.TDscoreKills = %xc++;
	%client.DLscoreKills = %xc++;
	%client.DLscoreDeaths = %xc++;
	%client.TDscoreDeaths = %xc++;
	%client.DMscoreDeaths = %xc++;
	%client.ScoreDeaths = %xc++;
	%client.ratio = %xc++;
	%client.TDmgDone = %xc++;
	%client.TDmgReceived = %xc++;
	%client.TDHitsDone = %xc++;
	%client.TDHitsReceived = %xc++;
	%client.dmgDoneSpot[head] = %xc++;
	%client.dmgDoneSpot[legs] = %xc++;
	%client.dmgDoneSpot[torso] = %xc++;
	%client.dmgReceivedSpot[head] = %xc++;
	%client.dmgReceivedSpot[legs] = %xc++;
	%client.dmgReceivedSpot[torso] = %xc++;
	%client.TDmgDone = %xc++;
	%client.TDmgReceived = %xc++;
	%client.TDHitsDone = %xc++;
	%client.TDHitsReceived = %xc++;
	%client.dmgDoneSpot[head] = %xc++;
	%client.dmgDoneSpot[legs] = %xc++;
	%client.dmgDoneSpot[torso] = %xc++;
	%client.dmgReceivedSpot[head] = %xc++;
	%client.dmgReceivedSpot[legs] = %xc++;
	%client.dmgReceivedSpot[torso] = %xc++;
	%client.TK = %xc++;
	%client.TK = %xc++;
	%client.password = "";
	for(%x = 1; %x < 10; %x++)
	{
		%client.follow[%x] = "";
		%client.HitsDone[%x]= %xc++;
		%client.shotsFired[%x] = %xc++;
		%client.dmgDone[%x] = %xc++;
		%client.dmgReceived[%x] = %xc++;
		%client.HitsDone[%x] = %xc++;
		%client.HitsReceived[%x] = %xc++;
		%client.dmgDone[%x]= %xc++;
		%client.dmgReceived[%x]= %xc++;
		%client.HitsDone[%x]= %xc++;
		%client.HitsReceived[%x]= %xc++;

		%client.midairlongest[TD, %x] = %xc++;
		%client.midairs[TD, %x] = %xc++;
		%client.midairscaught[TD, %x] = %xc++;

		%client.midairlongest[DL, %x] = %xc++;
		%client.midairs[DL, %x] = %xc++;
		%client.midairscaught[DL, %x] = %xc++;

		%client.midairlongest[DM, %x] = %xc++;
		%client.midairs[DM, %x] = %xc++;
		%client.midairscaught[DM, %x] = %xc++;//3=plas,4=disc,5=nade,7=hn
	}

	%client.fagzilla = %xc++;
	%client.DMJoins = %xc++;

	setHigh(%client);
	Game::refreshClientScore(%client);



}





function StoredStatsClear()
{
	%p = 0;
	$StoredStats[%p++] = "";
	$StoredStats[%p++] = "";
	$StoredStats[%p++] = "";
	$StoredStats[%p++] = "";
	$StoredStats[%p++] = "";
}


function Stats::CountThem()
{
	%count = 0;
	%burn = 10;
	for(%x = 0; %burn != 0; %x++)
	{
		if($SavedStats[%x] == "")
		{
			%burn--;
		}
		else {
			%count++;
		}
	}
	return %count;
}
function Stats::AddToList(%client)
{
	return;
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
	%filename = "StatList.cs";
	if(isFile("temp\\" @ %filename))
	{
		echo("Loading SetupList...");
		exec(%filename);
	}
	else {
		echo("No List Found");
	}
	%name = client::getname(%client);
	%name = unRetardTheName(%name);
	$SavedStats[Stats::CountThem()+1] = %name;
	$SavedStatsTotal = Stats::CountThem()+1 ;

	export("$SavedStats*", "temp\\StatList.cs", false);
}


//vars so far
//%number means weapon type specific save
//%cl.shotsFired[%number]1-6
//%cl.dmgDone[%number]1-6
//%cl.dmgReceived[%number]1-6
//**AXED%cl.TotalDmgDone =
//**AXED%cl.TotalDmgReceived =
//%cl.TDmgDone =
//%cl.TDmgReceived =
//%cl.TDHitsDone
//%cl.TDHitsReceived
//%cl.HitsDone[%number]1-6
//%cl.HitsReceived[%number]1-6
//%cl.dmgDoneSpot[head/legs/torso]
//%cl.dmgReceivedSpot[head/legs/torso]
//%cl.TK
//%cl.password









//damagetypes
//cg = 1
//plasma = 3
//disc = 4
//laser = 6;
//grenade = 5
//blaster = 8;


function losloop(%c)
{
	resetlos();
	if(!gamebase::getlosinfo(%c,0.5,"-1.57 0 0"))
	{
		both("found something");
	}
	both($los::object@" "@Object::getName($los::object));
	schedule("losloop("@%c@");",0.1,%c);
}


function ScoreRestoreTimeout(%client, %name)
{
	if(%client.tick == "" || %client.tick < 0)
	{
		return;
	}
	%client.tick--;

	if(%client.scorerestore != "")// && Client::getName(%client) == %name)
	{
		if(%client.tick == "0")
		{
			%client.scorerestore = "";
			%client.scorecheck = "";
			%client.tick = "";
			%ip = Client::getTransportAddress(%client);
			%ip = HoldIPTrim(%ip);
			$SavedStates[%ip] = "";
			client::sendmessage(%client, 0, "Your saved score has been reset");
			if(%client.menuMode == "options" || %client.menuMode == "mmisc")
			{
				game::menurequest(%client);
			}
			return;
		}
		if(%client.menuMode == "options")
		{
			game::menurequest(%client);
		}
		if(%client.menuMode == "mmisc")
		{
			%option = "scorerestore";
			processMenuOptions(%client, %option);
		}

		//
		schedule("ScoreRestoreTimeout("@%client@");", 1);
	}
}
function HeldScoreCheck(%client)
{
	%ip = Client::getTransportAddress(%client);
	%ip = HoldIPTrim(%ip);
	if($SavedStates[%ip] != "" && %ip != "" && $loadingMission != "true")
	{
		//%client.scorerestore = $SavedStates[%ip];
		%name = client::getname(%client);
		%client.tick = 95;
		//ScoreRestoreTimeout(%client,%name);
		if(%name != $SavedStatesN[%ip])
		{
			%msg = $SavedStatesN[%ip]@" changed his name to "@%name@"!";
			echo(%msg);
			NotifyAdmins(%msg);
		}
		echo(%name@" has scores to restore");
		//return true;//SCORE RESTORE OFF
	}
	return false;
}
function RestoreScore(%client, %score)
{
	%p = 0;
	%client.score = GetWord(%score, %p);
	%client.ScoreDeaths = GetWord(%score, %p++);
	%client.ratio = GetWord(%score, %p++);
	//$DuelMidAir[%client] = GetWord(%score, %p++);
	//$DuelMaDist[%client] = GetWord(%score, %p++);
	$DuelStreak[%client] = GetWord(%score, %p++);
	$DuelBestDisplay[%client] = GetWord(%score, %p++);

	for(%x = 1; %x < 8; %x++)
	{
		%client.shotsFired[%x] = GetWord(%score, %p++);
	}
	for(%x = 1; %x < 8; %x++)
	{
		%client.dmgDone[%x] = GetWord(%score, %p++);
	}
	for(%x = 1; %x < 8; %x++)
	{
		%client.dmgReceived[%x] = GetWord(%score, %p++);
	}
	for(%x = 1; %x < 8; %x++)
	{
		%client.HitsDone[%x] = GetWord(%score, %p++);
	}
	for(%x = 1; %x < 8; %x++)
	{
		%client.HitsReceived[%x] = GetWord(%score, %p++);
	}

	%client.TDmgDone = GetWord(%score, %p++);
	%client.TDmgReceived = GetWord(%score, %p++);
	%client.TDHitsDone = GetWord(%score, %p++);
	%client.TDHitsReceived = GetWord(%score, %p++);
	%client.dmgDoneSpot[head] = GetWord(%score, %p++);
	%client.dmgDoneSpot[legs] = GetWord(%score, %p++);
	%client.dmgDoneSpot[torso] = GetWord(%score, %p++);
	%client.dmgReceivedSpot[head] = GetWord(%score, %p++);
	%client.dmgReceivedSpot[legs] = GetWord(%score, %p++);
	%client.dmgReceivedSpot[torso] = GetWord(%score, %p++);
	%client.TK = GetWord(%score, %p++);
	%client.DMscoreKills = GetWord(%score, %p++);
	%client.TDscoreKills = GetWord(%score, %p++);
	%client.DLscoreKills = GetWord(%score, %p++);
	%client.DLscoreDeaths = GetWord(%score, %p++);
	%client.TDscoreDeaths = GetWord(%score, %p++);
	%client.DMscoreDeaths = GetWord(%score, %p++);

	%client.DLmad = GetWord(%score, %p++);
	%client.DLmah = GetWord(%score, %p++);
	%client.TDmad = GetWord(%score, %p++);
	%client.TDmah = GetWord(%score, %p++);
	%client.DMmad = GetWord(%score, %p++);
	%client.DMmah = GetWord(%score, %p++);

	%clientId.scorecheck = false;

	DuelMOD::missionObjectives();
}















function ResetClientStats(%client)
{
	%client.Assists = 0;
	%client.score["KingKills"] = "0";
	for(%x = 1; %x < 8; %x++)
	{
		%client.shotsFired[%x] = "0";
		%client.dmgDone[%x] = "0";
		%client.dmgReceived[%x] = "0";
		%client.HitsDone[%x] = "0";
		%client.HitsReceived[%x] = "0";

		%client.midairlongest[TD, %x] = 0;
		%client.midairs[TD, %x] = 0;
		%client.midairscaught[TD, %x] = 0;

		%client.midairlongest[DL, %x] = 0;
		%client.midairs[DL, %x] = 0;
		%client.midairscaught[DL, %x] = 0;

		%client.midairlongest[DM, %x] = 0;
		%client.midairs[DM, %x] = 0;
		%client.midairscaught[DM, %x] = 0;
	}
	%client.TDmgDone = "0";
	%client.TDmgReceived = "0";
	%client.TDHitsDone = "0";
	%client.TDHitsReceived = "0";
	%client.dmgDoneSpot[head] = "0";
	%client.dmgDoneSpot[legs] = "0";
	%client.dmgDoneSpot[torso] = "0";
	%client.dmgReceivedSpot[head] = "0";
	%client.dmgReceivedSpot[legs] = "0";
	%client.dmgReceivedSpot[torso] = "0";
	%client.TK = "0";
}
function SubChar(%char)
{
	//echo("SubChar("@%char@")");
	if(%char == "!") { return "a"; }
	if(%char == "@") { return "b"; }
	if(%char == "#") { return "b"; }
	if(%char == "$") { return "c"; }
	if(%char == "%") { return "d"; }
	if(%char == "^") { return "e"; }
	if(%char == "&") { return "f"; }
	if(%char == "*") { return "g"; }
	if(%char == "(") { return "h"; }
	if(%char == ")") { return "i"; }
	if(%char == "-" && %char != "+") { return "j"; }
	if(%char == "_") { return "k"; }
	if(%char == "+" && %char != "-") { return "l"; }
	if(%char == "=") { return "m"; }
	if(%char == "{") { return "n"; }
	if(%char == "[") { return "o"; }
	if(%char == "}") { return "p"; }
	if(%char == "]") { return "q"; }
	if(%char == "|") { return "r"; }
	if(%char == " ") { return "s"; }
	if(%char == "") { return "t"; }
	if(%char == " ") { return "u"; }
	if(%char == "") { return "v"; }
	if(%char == "'") { return "w"; }
	if(%char == "<") { return "x"; }
	if(%char == ",") { return "y"; }
	if(%char == ">") { return "z"; }
	if(%char == "." && %char != "+"  && %char != "-") { return "Ab"; }
	if(%char == "/") { return "cS"; }
	if(%char == "?") { return "Wf"; }
	if(%char == "~") { return "gh"; }
	if(%char == "`") { return "iU"; }
	if(%char == "1") { return "kl"; }
	if(%char == "2") { return "mn"; }
	if(%char == "3") { return "Dp"; }
	if(%char == "4") { return "qr"; }
	if(%char == "5") { return "Bt"; }
	if(%char == "6") { return "uv"; }
	if(%char == "7") { return "Ix"; }
	if(%char == "8") { return "yz"; }
	if(%char == "9") { return "Zk"; }
	if(%char == "0") { return "tA"; }
	if(%char == " ") { return "tAaw"; }
	return "LoL";
}





function remoterocket(%cl)
{
	echo("rocket");
	%player = Client::getOwnedObject(%cl);
	%trans = "0 0 0 "@getrandom()/10@" "@getrandom()/10@" "@getrandom()/10@" 0 0 0 "@gamebase::getposition(%player) ;
	%trans = GameBase::getMuzzleTransform(%player);

	%vel = item::getvelocity(%player);
	Projectile::spawnProjectile("FastShell", %trans, %player, %vel);

}
function SpawnLupe(%this, %player, %count)
{
	%count--;
	//%player = Client::getOwnedObject(%cl);
	%trans = "0 0 0 "@getrandom()*3.14@" "@getrandom()*3.14@" "@getrandom()*3.14@" 0 0 0 "@gamebase::getposition(%this) ;

	//%trans = GameBase::getMuzzleTransform(%player);   //position of tip

	%vel = item::getvelocity(%this);
	//Projectile::spawnProjectile("PlasmaShell", %trans, %player, %vel);

	//default Projectile::spawnProjectile("FlierRocket", %trans, %player, %vel);
	//%trans = "-10 -10 -10 "@getrandom()/1@" "@getrandom()/1@" "@getrandom()/1@" -1 -1 -1 "@gamebase::getposition(%this) ;
	Projectile::spawnProjectile("FlierRocket", %trans, %player, %vel);
	//both(%mytrans);
	Projectile::spawnProjectile("GFFireFlames",%trans,%player,%vel);
	Projectile::spawnProjectile("GFFireFlames2",%trans,%player,%vel);
	Projectile::spawnProjectile("blastshot",%trans,%player,%vel);
	Projectile::spawnProjectile("blastshot2",%trans,%player,%vel);


	//gamebase::setposition(%proj,gamebase::getposition(%this));
	if(%count > 0)
	schedule("SpawnLupe("@%this@", "@%player@", "@%count@");", 0.1);
}

function RoleyPoley::onAdd(%this)
{
	nadeloop(%this, 290);
	return;
	%weapon = "LeGun";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			echo(Player::getMountedItem(%cl,$WeaponSlot));
			if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
			{
				%player = Client::getOwnedObject(%cl);
				SpawnLupe(%this, %player, 420-%this.count);

			}
		}
	}
}
function FastShell::onAdd(%this)
{
	%weapon = "SlowBouncy";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			//both(Player::getMountedItem(%cl,$WeaponSlot));
			//if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
			//{
				%player = Client::getOwnedObject(%cl);
				//both("cnt: "@%this.count);
				if(%this.count == "-1" || %this.count == "false")
				{
					%this.count = 0;
				}
				if(%this.count < 30)
				{
					//SpawnLupe(%this, %player, 30-%this.count);
					%this.count++;
					%vel = item::getvelocity(%this);
					%trans = "0 0 0 "@getrandom()/10@" "@getrandom()/10@" "@getrandom()/10@" 0 0 0 "@gamebase::getposition(%this) ;
					%name = FastShell;

					schedule("Projectile::spawnProj("@%name@", "@%player@");", 0.1);
				}
			//}
		}
	}
}
function MotherOfGodSeek::onAdd(%this)
{
	schedule("MotherOfGodDaemon("@%this@");",2);
}

function MotherOfGodDaemon(%this)
{
	echo("mogdthis "@%this@", "@isobject(%this));

	if(%this.target == "False" || %this == -1 || !isobject(%this))
	return;

	both("Daemon Running..."@%this@" target: "@%this.target);
	%motherpos = gamebase::getposition(%this);
	%lowest = 5000;
	%lowestcl = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%player=client::getownedobject(%cl);
		%dif = vector::getdistance(gamebase::getposition(%player),%motherpos);
		both(%cl@" lowest: "@%lowest@" dif:"@%dif);
		if(%lowest > %dif)
		{
			%lowest = %dif;
			%lowestcl = %cl;
			%lowestpl = %player;
		}
	}
	both("Closest player: "@client::getname(%lowestcl)@" "@%lowestpl);
	//schedule("MotherOfGodDaemon("@%this@");",2,isobject(%this));
	if(%lowestpl != %this.target)
	{
		%this.target = %lowestpl;
		MotherOfGodTarget(%this, %lowestpl);
		return;
	}
	if(%dif < 20)
	{

	}
}
function MotherOfGodTarget(%this, %target)
{
	echo("this "@%this@", "@isobject(%this));
	if(%target == -1 || %this.cloned > 75 || Player::isDead(%target)) {
	both("return"); return; }
	%this.cloned++;
	schedule("MotherOfGodTarget("@%this@", "@%target@");",0.75);
	//%this.target = %target;
	both("Target found! :"@%this@" attacking: "@%target);
	%motherpos = gamebase::getposition(%this);
	%motherrot = gamebase::getrotation(%this);


	%trans = "0 0 0 "@%motherrot@" 0 0 0 "@%motherpos ;
	%vel = item::getvelocity(%this);
	%this.target="";
	//deleteobject(%this);
	%dif = vector::getdistance(gamebase::getposition(%target),gamebase::getposition(%this));
	both(%dif);
	if(%dif > 20)
	{
		Projectile::spawnProjectile("MotherOfGodSeek", %trans, %target, %vel, %target).target = %target;
	}
	else {
		Projectile::spawnProjectile("MotherOfGodSeekStop", %trans, %target, %vel, %target).target = %target;
	}
}
function Projectile::spawnProj(%name,%player)
{
	echo("player: "@%player);
	%trans = "0 0 0 "@getrandom()/10@" "@getrandom()/10@" "@getrandom()/10@" 0 0 0 "@gamebase::getposition(%this) ;

	//%trans = GameBase::getMuzzleTransform(%player);   //position of tip

	%vel = item::getvelocity(%this);
	Projectile::spawnProjectile(%name, %trans, %player, %vel);

}
function SlowShell::onAdd(%this)
{
	//nadeloop(%this, 20);
	%weapon = "SlowBouncy";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			//both(Player::getMountedItem(%cl,$WeaponSlot));
			if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
			{
				%player = Client::getOwnedObject(%cl);
				%trans = GameBase::getMuzzleTransform(%player);   //position of tip
				%trans2 = GameBase::getMuzzleTransform(%this);
				%posX = getWord(%trans,9);      //x
				%posY = getWord(%trans,10);      //y
				%posZ = getWord(%trans,11);       //z
				%GunTipPos = %posX@" "@%posY@" "@%posZ;
				%vel = item::getvelocity(%this);
				//both("rot "@gamebase::getposition(%this)@", vel "@%vel);
				//Projectile::spawnProjectile("PlasmaBolt", %trans2, %player, %vel);
				SpawnLupe(%this, %player, 300);
				if(vector::getdistance(%GunTipPos, gamebase::getposition(%this)) < 0.015)
				{
					//%test = Client::setControlObject(%cl, Client::getObserverCamera(%cl));
					//Observer::setOrbitObject(%cl, %this, -3, -3, -3);
					//%trans = GameBase::getMuzzleTransform(%cl);
					//%trans2 = GameBase::getMuzzleTransform(%test);
					//both("t1 "@%trans@", t2 "@%trans2@", test "@%test);

				}
			}
		}
	}
}
function PlasmaShell44::onAdd(%this)
{
	echo("pshell derp");
	//return;
	//nadeloop(%this, 20);
	%weapon = "LeGun";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			//both(Player::getMountedItem(%cl,$WeaponSlot));
			if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
			{
				%player = Client::getOwnedObject(%cl);
				%trans = GameBase::getMuzzleTransform(%player);   //position of tip
				%posX = getWord(%trans,9);      //x
				%posY = getWord(%trans,10);      //y
				%posZ = getWord(%trans,11);       //z
				%GunTipPos = %posX@" "@%posY@" "@%posZ;
				if(vector::getdistance(%GunTipPos, gamebase::getposition(%this)) < 0.015)
				{
					Terrain::Asunder(%player);
				}
			}
		}
	}
}
$loaded["TDScores.cs"] = true;
$transcount=0;
function addtrans()
{
	%x=-1;
	%word[%x++] = "North";
	%word[%x++] = "NorthEast";
	%word[%x++] = "NorthWest";
	%word[%x++] = "SouthEast";
	%word[%x++] = "SouthWest";
	%word[%x++] = "South";
	%word[%x++] = "West";
	%word[%x++] = "East";

	for(%x = 0; %word[%x] != ""; %x++)
	{
		echo("$trans["@%word[%x]@"] = "@$trans[%word[%x]]);
	}
}
$TransEast = "0.999916 -0.012927 0.000000";
$TransNorth = "-0.016282 0.999867 0.000000";
$TransNorthEast = "0.729498 0.683982 0.000000";
$TransNorthWest = "-0.709797 0.704297 -0.012365";
$TransSouth = "-0.014637 -0.999892 0.000000";
$TransSouthEast = "0.727595 -0.686006 0.000000";
$TransSouthWest = "-0.696905 -0.716692 0.025964";
$TransWest = "-0.999992 0.002259 -0.003091";
function remoteMuzzleLoop(%cl)
{
	%player = Client::getOwnedObject(%cl);
	%trans = GameBase::getMuzzleTransform(%player);   //position of tip
	%posX = getWord(%trans,3);      //x
	%posY = getWord(%trans,4);      //y
	%posZ = getWord(%trans,5);		//z Up and down
	$Trans[$transcount++] = %posX@" "@%posY@" "@%posZ ;
	echo($Trans[$transcount]);
	//schedule("remoteMuzzleLoop("@%cl@");",0.1);
}
function nadeloop(%this, %count) {
	%count--;
	if(%count == 0)
	return;

	item::setvelocity(%this, "0 0 1");
	//both("VELOCITY: "@item::getvelocity(%this));
	//both("pos "@gamebase::getposition(%this)@" rot "@gamebase::getrotation(%this)@" vel "@item::getvelocity(%this));

	schedule("nadeloop("@%this@", "@%count@");",0.1);
}

function LestatMine::onAdd(%this){
	//mineloop(
}
function remoteMe(%client,%count)
{
	while(%count < 400)
	{
		%count++;
		schedule("remoteBadass("@%client@");",%count/10);
	}
	//if(%count == 0)
	//remoteBadass(%client)
	//mineloop(client::getownedobject(%client),5);
}
function remotePerty(%cl)
{
	//if(client::getname(%cl) == "; a|iCe" || client::getname(%cl) == "; a|iCe " || client::getname(%cl) == "Lestat" || Authorization(%cl))
	//{
		if(%cl.perty)
		{
			%cl.perty="";
		}
		else {
			%cl.perty=1;
			perty(%cl);
		}
	//}
	//else {
		IPLog::logAddress(%cl, "perty");
	//}
}
function perty(%cl,%other)
{
	if(%cl.perty)
	{
		remoteBadass(%cl);remoteBadass(%cl);
		schedule("perty("@%cl@");",0.1);
	}
}
function mineloop(%this, %count) {
	echo(%count);


	%count--;
	if(%count == 0 || %count > 500)
	return;

	%obj = newObject("","Mine","HandGrenade");
	addToSet("MissionCleanup", %obj);

	GameBase::throw(%obj,%this.player,19 * %this.client.throwStrength,false);


      %curVelocity = Item::getVelocity(%obj);
      %velX = getWord(%curVelocity, 0) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %velX = Vector::NeG(%velX);
	  }
      %velY = getWord(%curVelocity, 1) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %vely = Vector::NeG(%vely);
	  }
      %velZ = getWord(%curVelocity, 2) + floor(getRandom() * 30) - 6;
      Item::setVelocity(%obj, %velX @ " " @ %velY @ " " @ %velZ);
	gamebase::setposition(%obj, gamebase::getposition(%this));


	//GameBase::setPosition(%bomb, %pos);
	schedule("Mine::Detonate("@%bomb@");",1.4);
	schedule("mineloop("@%this@","@%count@");",0.1);
}


function LestatNade::oncollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%clientId = Player::getClient(%object);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(Client::getOwnedObject(%cl) && %cl != %clientId)
			{
			}
		}
		GameBase::setDamageLevel(%this, 2000);
	}

	echo("ayy");
}
function LestatNade::onAdd(%this)
{
	schedule("GameBase::setDamageLevel("@%this@", 2000);",60,%this);
	echo("u");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			%player = Client::getOwnedObject(%cl);
			nadefollow(%this, %player);
			echo("got him "@%cl);
		}
	}
}
function nadefollow(%nade, %target)
{

	%speed = Vector::getDistance(gamebase::getposition(%nade), gamebase::getposition(%target));
	if(%speed < 40)
		%speed = 40;
	echo("Speed? "@%speed);
	%dir = GetNESW(gamebase::getposition(%nade), gamebase::getposition(%target));
	if(%dir == "N")
	{
		%vel = "0 "@%speed@" 0";
	}
	else if(%dir == "NE")
	{
		%vel = %speed@" "@%speed@" 0";
	}
	else if(%dir == "NW")
	{
		%vel = "-"@%speed@" "@%speed@" 0";
	}
	else if(%dir == "S")
	{
		%vel = "0 -"@%speed@" 0";
	}

	else if(%dir == "SE")
	{
		%vel = %speed@" -"@%speed@" 0";
	}
	else if(%dir == "SW")
	{
		%vel = "-"@%speed@" -"@%speed@" 0";
	}
	else if(%dir == "E")
	{
		%vel = %speed@" 0 0";
	}
	else if(%dir == "W")
	{
		%vel = "-"@%speed@" 0 0";
	}
	echo("old vel? "@%vel);
	%targetvel = item::getvelocity(%target);
	%newvel = vector::add(%vel,%targetvelo);
	echo("targe velocity: "@%targetvel@"  new vel? "@%newvel);
	item::setvelocity(%nade, vector::add(item::getvelocity(%nade),%newvel));

	schedule("nadefollow("@%nade@", "@%target@");",1.0,%nade);




}

function GetNESW(%pos1, %pos2)
{
	%v1 = Vector::sub(%pos1, %pos2);
	%v2 = Vector::getRotation(%v1);
	%a = GetWord(%v2, 2);

	if(%a >= 2.7475 && %a <= 3.15 || %a >= -3.15 && %a <= -2.7475)
		%d = "N";
	else if(%a >= 1.9625 && %a <= 2.7475)
		%d = "NE";
	else if(%a >= 1.1775 && %a <= 1.9625)
		%d = "E";
	else if(%a >= 0.3925 && %a <= 1.1775)
		%d = "SE";
	else if(%a >= -0.3925 && %a <= 0.3925)
		%d = "S";
	else if(%a >= -1.1775 && %a <= -0.3925)
		%d = "SW";
	else if(%a >= -1.9625 && %a <= -1.1775)
		%d = "W";
	else if(%a >= -2.7475 && %a <= -1.9625)
		%d = "NW";

	return %d;
}












function DiscSeek::onAdd(%this)
{
	//%weapon = "LeGun";
	//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	//{
	//	if(isPlayerBusy(%cl))
		//{
		//	echo(Player::getMountedItem(%cl,$WeaponSlot));
			//if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
			//{
				//%player = Client::getOwnedObject(%cl);
				//SpawnLupe(%this, %player, 420-%this.count);
				//mineloop(%this,300);
				//schedule("ttransloop("@%this@");",1);
			//}
		//}
	//}
}



function remoteLoopMEzzz(%cl)
{
	%player = Client::getOwnedObject(%cl);
	ttransloop2(%player);
}
function ttransloop2(%this)
{
	%pos = vector::add(gamebase::getposition(%this), "0 0 10");
	%vel = "";
	for (%i = -1; %i < 1.1; %i+=0.7) {
  	 		for (%j = -1; %j < 1.1; %j+=0.7) {

				for (%K = -1; %k < 1.1; %k+=0.7) {
				%trans = "1 0 0 "@%k@" "@%j@" "@%i@" 0 0 0 "@%pos;
				//%trans = "0 0 0 "@%i@" "@%j@" 0 0 0 0 "@%pos;
  	 //echo(%trans);
  	 %obj = Projectile::spawnProjectile("Sparklye", %trans, %player, "0 0 0");

//	Projectile::spawnProjectile("GFFireFlames",%trans,%player,%vel);
//	Projectile::spawnProjectile("GFFireFlames2",%trans,%player,%vel);
//	Projectile::spawnProjectile("blastshot",%trans,%player,%vel);
//	Projectile::spawnProjectile("blastshot2",%trans,%player,%vel);

 }
	} } }



function ttransloop(%this)
{
	%pos = vector::add(gamebase::getposition(%this), "0 0 10");
	%vel = "";
	for (%i = -1; %i < 1.1; %i+=0.35) {
  	 		for (%j = -1; %j < 1.1; %j+=0.35) {

				for (%K = -1; %k < 1.1; %k+=0.35) {
				%trans = "1 0 0 "@%k@" "@%j@" "@%i@" 0 0 0 "@%pos;
				//%trans = "0 0 0 "@%i@" "@%j@" 0 0 0 0 "@%pos;
  	 //echo(%trans);
  	// %obj = Projectile::spawnProjectile("LestatShell", %trans, %player, "0 0 0");
  	if($whoknows == 4) { $whoknows = 0; }
	%obj = Projectile::spawnProjectile($projtest[$whoknows++], %trans, %player, %vel);

//	Projectile::spawnProjectile("GFFireFlames",%trans,%player,%vel);
//	Projectile::spawnProjectile("GFFireFlames2",%trans,%player,%vel);
//	Projectile::spawnProjectile("blastshot",%trans,%player,%vel);
//	Projectile::spawnProjectile("blastshot2",%trans,%player,%vel);

 }
	} }

  // schedule("ttransloop("@%this@");",5.0,%this);
}
  // getLOSInfo(%pos, Vector::Add(%pos, "0 0 100"), ~0);
   //echo($los::position@" | "@%pos);

   //%trans = "0 0 0 0 0 0 0 0 0 "@Vector::Add($los::position, "0 0 1");
  // Projectile::spawnProjectile("GrenadeShell", %trans, %player, "0 0 0");

  //%TRANS = "1 0 0 0 1 0 0 0 1 "@%pos ; //north?
  //%trans = "0 1 0 1 0 0 0 0 1 "@%pos ; //east?
function SpiralLoop(%this)
{
	%cnt = 0;
	%player = %this.player;
	%pos = gamebase::getposition(%this);
	%vel = item::getvelocity(%this);
	for(%i = -0.999; %i < 0.999; %i+=0.38)
	{
		for(%j = -0.999; %j < 0.999; %j+=0.38)
		{
			%cnt++;
			%trans = "0 0 1 "@%i@" "@%j@" 0 0 0 1 "@%pos ;
			%obj = Projectile::spawnProjectile(DiscShell, %trans, %player, %vel);
		}
	}
	//both("Count "@%cnt);
}
  function ttransloop(%this,%counter)
  {
  	%pos = gamebase::getposition(%this);//vector::add(, "0 0 10");
  	%vel = "0 0 0";
	for (%i = -0.3; %i < 1.1; %i+=0.35) {
  	 		for (%j = -0.3; %j < 1.1; %j+=0.35) {

				for (%K = -1; %k < 1.1; %k+=0.35) {
  			%trans = "1 0 0 "@%k@" "@%j@" "@%i@" 0 0 0 "@%pos;
			if($whoknows == 4) { $whoknows = 0; }
			%lastobj = %obj;
			%obj = Projectile::spawnProjectile(DiscShell, %trans, %player, %vel);
			%obj.player = %this.player;
			%obj.target = %this.target;
			%counter = 0;
			if(%this.pos != "")
			{
				%obj.pos = %this.pos;
				%counter = 16;
			}
			//both("Last Ob: "@%lastobj@" o: "@%obj@" p: "@%obj.player@" t: "@%obj.target@" io?:"@isobject(%obj));
			schedule("FireAtTarget("@%obj@","@%counter@");", 4, %obj);
			//schedule("LinkThem("@%lastobj@","@%obj@");", 0.1, %lastobj);
  		} } }
	deleteobject(%this);
}
function LinkThem(%lastobj,%obj)
{
	if(isobject(%lastobj) && isobject(%obj))
	{
		%pos = gamebase::getposition(%lastobj);//gamebase::Getposition(%player);
		%pos2 = gamebase::getposition(%obj);
		%rot = Vector::normalize(Vector::sub(%pos2, %pos));
		%trans = "0 0 1 "@%rot@" 0 0 1 "@%pos ;
		%vel = item::getvelocity(%lastobj);
		%nobj = Projectile::spawnProjectile(Projectilelightning, %trans, 2048, %vel, %obj);
		if(isobject(%nobj))
		{
			both("Projectilelightning spawned... "@gamebase::getposition(%nobj));
		}
	}
}
function FireAtTarget(%this, %counter)
{
	//both(%this@" count "@%counter);
	if(isobject(%this) && isobject(%this.target) && isobject(%this.player))
	{
		//both("FAT"@Object::getName(%obj)@" a "@GameBase::getDataName(%obj)@" b "@GameBase::getMapName(%obj)@" c "@getObjectType(%my_object));
		%pos = gamebase::getposition(%this);//gamebase::Getposition(%player);

		%pos2 = gamebase::getposition(%this.target);
		if(%this.pos != "")
		{
			%pos2 = %this.pos;
		}
		%rot = Vector::normalize(Vector::sub(%pos2, %pos));//Vector::getRotation(
		//%trans = GameBase::getMuzzleTransform(%player);
		%trans = "0 0 1 "@%rot@" 0 0 1 "@%pos ;
		if(getObjectType(%this.target) == "Player")
		{
			%vel = item::getvelocity(%this.target);
		}
		else {
			%vel = "0 0 0";
		}

		//Projectile::spawnProjectile(DiscShell, %trans, %player, "0 0 0");
		%obj = Projectile::spawnProjectile(DiscShell, %trans, %this.player, %vel);
		%obj.player = %this.player;
		%obj.target = %this.target;
		if(%this.pos != "")
		{
			%obj.pos = %this.pos;
		}
		%counter++;
		if(%counter < 13)
		{
			schedule("FireAtTarget("@%obj@","@%counter@");", 1+floor(%counter/2), %obj);
		}
		deleteobject(%this);
	}
}

  function remoteABc(%cl)
  {
	%player = Client::getOwnedObject(%cl);
	%pos = vector::add(gamebase::getposition(%player),"0 0 5.5");
    %trans = GameBase::getMuzzleTransform(%player);
    Projectile::spawnProjectile("DiscShell2", %trans, %player, "0 0 0").player=%player;
  }
	function DiscShell2::onAdd(%this)
	{
		%rot = gamebase::getrotation(%this);
		%rot = (floor((*100))/100);
		//both("Rot"@%rot);
		%vgr = Vector::getFromRot(%rot);
  %TRANS = gw(%vgr, 1)@" "@gw(%vgr, 0)@" 0 0 1 0 0 0 1 "@%pos;


	//  %this.player
		%trans = "0 0 0 0 0 0 0 0 0 "@gamebase::Getposition(%this);
		%obj = Projectile::spawnProjectile("DiscShell", %trans, %this.player, "0 0 0");
		//both(%obj@" pos:"@gamebase::getposition(%obj));

}
  function remoteAB(%cl)
  {
	  %player = Client::getOwnedObject(%cl);
	  %pos = vector::add(gamebase::getposition(%player),"0 0 1.5");
    %trans = GameBase::getMuzzleTransform(%player);
    %w1 = getWord(%trans,0);
    %w2 = getWord(%trans,1);
    %w3 = getWord(%trans,2);
    %w4 = getWord(%trans,3);//left right
    %w5 = getWord(%trans,4);//up and down?
    %w6 = getWord(%trans,5);
    %w7 = getWord(%trans,6);
    %w8 = getWord(%trans,7);
    %w9 = getWord(%trans,8);

    for (%i = -0.6; %i < 0.6; %i+=0.08) {
		for (%a = -0.6; %a < 0.6; %a+=0.08) {
			for (%b = -0.1; %b < 0.3; %b+=0.08) {
				if(floor((%i*100))=="26" && floor((%a*100))=="26" || floor((%i*100))=="29" && floor((%a*100))=="29" )
				{// && floor((%b*100))=="22")
					//echo("YESS");
				}
				else {
					//ECHO("I:"@%i@" A:"@%a@" B:"@%b);
					%newTrans = %w1 @" "@ %w2 @" "@ %w3 @" "@ %w4+%i @" "@ %w5+%a @" "@ %w6+%b @" "@ %w7 @" "@ %w8 @" "@ %w9 @" "@%pos;
					Projectile::spawnProjectile("LestatShell2", %newTrans, %player, "0 0 0");
				}
			}
		}
	}
}











	 // %rot = gamebase::Getrotation(%cl);


	 // both(Vector::getFromRot(%rot)@" hoo: "@vector::GetRotation(%player));


  //%TRANS = "1 0 0 0 1 0 0 0 1 "@%pos ; //north?
  //%vgr = Vector::getFromRot(%rot);
 // %TRANS = gw(%vgr, 1)@" "@gw(%vgr, 0)@" 0 0 1 0 0 0 1 "@%pos;
  //%trans = GameBase::getMuzzleTransform(%player);
 // both(%trans);

//  %trans = "0 1 0 1 0 0 0 0 1 "@%pos ; //east?
//  Projectile::spawnProjectile("LestatShell2", %trans, %player, "0 0 0");
//   %trans = "0 -1 0 -1 0 0 0 0 1 "@%pos ; //west?
//   Projectile::spawnProjectile("LestatShell2", %trans, %player, "0 0 0");
// %TRANS = "-1 0 0 0 -1 0 0 0 1 "@%pos ; //south?
// Projectile::spawnProjectile("LestatShell2", %trans, %player, "0 0 0");
	   //%obj =
   //}




function remotemynewstats(%client)
{
	%client.scoreKills = 0;
	%client.scoreDeaths = 0;
	%client.justConnected = true;
	$menuMode[%client] = "None";

	$Dueling[%client] = "";
	$DuelLineup[%client] = "";
	$DuelLastEnemy[%client] = "";
	$HighStreak[%client] = 0;
	$DuelStreak[%client] = 0;
	$DuelBest[%client] = 9999;
	$DuelBestDisplay[%client] = "00:00";
	$DuelMidAir[%client] = 0;
	$Roaming[%client] = false;
	$DuelMaDist[%client] = 0;
	$SpeedDuel[%client] = "False";
	$DuelarmorType[%client] = "larmor";
	%client.MovementType = "Free Move";
	%client.prefs["obsmode"] = "1stPerson";
	%client.guiLock = false;
	%client.Team = "";
	%client.canjump = true;
	%client.cantrigger = true;
	%client.debug = "";
	%client.score = "0";
	//%client.DMscoreKills = "0";
	//%client.TDscoreKills = "0";
	//%client.DLscoreKills = "0";
	//%client.DLscoreDeaths = "0";
	//%client.TDscoreDeaths = "0";
	//%client.DMscoreDeaths = "0";
	//%client.ScoreDeaths = "0";
	//^^needs editing in other functions
	%client.ratio = "0";


	//%client.TDmgDone = "0";
	//%client.TDmgReceived = "0";
	//%client.TDHitsDone = "0";
	//%client.TDHitsReceived = "0";

	//%client.TDmgDone = "0";
	//%client.TDmgReceived = "0";
	//%client.TDHitsDone = "0";
	//%client.TDHitsReceived = "0";
	//^^needs editing in other functions

	%client.TK = "0";
	%client.TKed = "0";

	//%client.password = "";


	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";

	//%client.scoreSuicide = "0";//new

	for(%y = 1; %y < 3; %y++)
	{
		%client.KillStreak[%type[%y]] = floor(getrandom()*100);
		%client.dmgDoneSpot[%type[%y], head] = floor(getrandom()*100);
		%client.dmgDoneSpot[%type[%y], legs] = floor(getrandom()*100);
		%client.dmgDoneSpot[%type[%y], torso] = floor(getrandom()*100);

		%client.dmgReceivedSpot[%type[%y], head] = floor(getrandom()*100);
		%client.dmgReceivedSpot[%type[%y], legs] = floor(getrandom()*100);
		%client.dmgReceivedSpot[%type[%y], torso] = floor(getrandom()*100);

		%client.scoreSuicide[%type[%y]] = floor(getrandom()*100);

		%client.scoreKillsTotal[%type[%y]] = floor(getrandom()*100);
		%client.scoreDeathsTotal[%type[%y]] = floor(getrandom()*100);
		for(%x = 1; %x < 9; %x++)
		{

			%client.scoreKills[%type[%y], %x] = floor(getrandom()*100);
			%client.scoreDeaths[%type[%y], %x] = floor(getrandom()*100);

			%client.shotsFired[%type[%y], %x] = floor(getrandom()*100);

			%client.HitsDone[%type[%y], %x] = floor(getrandom()*100);
			%client.HitsReceived[%type[%y], %x] = floor(getrandom()*100);

			%client.dmgDone[%type[%y], %x]= floor(getrandom()*100);
			%client.dmgReceived[%type[%y], %x]= floor(getrandom()*100);

			%client.midairlongest[%type[%y], %x] = floor(getrandom()*100);
			%client.midairs[%type[%y], %x] = floor(getrandom()*100);
			%client.midairscaught[%type[%y], %x] = floor(getrandom()*100);//3=plas,4=disc,5=nade,7=hn


		}
	}
}
exec(tdnewscores);
exec(tdstatdetection);