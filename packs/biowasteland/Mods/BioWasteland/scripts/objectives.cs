exec("game.cs");

//=================================================================
// Defaults
//=================================================================
$flagReturnTime = 45;if (!$Score::25Meters) $Score::25Meters = "5"; if (!$Score::75Meters) $Score::75Meters = "3"; if (!$Score::150Meters) $Score::150Meters = "2"; if (!$Score::250Meters) $Score::250Meters = "1"; if (!$Score::FlagCapture) $Score::FlagCapture = "15"; if (!$Score::FlagKill) $Score::FlagKill = "7"; if (!$Score::FlagDef) $Score::FlagDef  = "3"; if (!$Score::FlagReturn) $Score::FlagReturn = "3"; if (!$Score::CaptureOdj) $Score::CaptureOdj = "2"; if (!$Score::HoldingObj) $Score::HoldingObj = "5"; if (!$Score::InitialObj) $Score::InitialObj = "2"; if (!$Score::ObjStationS) $Score::ObjStationS = "7"; if (!$Score::ObjStationA) $Score::ObjStationA = "5"; if (!$Score::ObjStationR) $Score::ObjStationR = "3"; if (!$Score::ObjFlier) $Score::ObjFlier = "3"; if (!$Score::ObjGeneratorB) $Score::ObjGeneratorB = "10"; if (!$Score::ObjGeneratorS) $Score::ObjGeneratorS = "5"; if (!$Score::ObjSensorL) $Score::ObjSensorL = "5"; if (!$Score::ObjSensorS) $Score::ObjSensorS = "2"; if (!$Score::ObjTurretL) $Score::ObjTurretL = "3"; if (!$Score::ObjTurretS) $Score::ObjTurretS = "1"; if (!$Score::Kill15Meters) $Score::Kill15Meters = "0"; if (!$Score::Kill50Meters) $Score::Kill50Meters = "1"; if (!$Score::Kill100Meters) $Score::Kill100Meters = "1"; if (!$Score::Kill250Meters) $Score::Kill250Meters = "2"; if (!$Score::Kill500Meters) $Score::Kill500Meters = "5"; if (!$Score::Kill800Meters) $Score::Kill800Meters = "8"; if (!$Score::Kill800Plus) $Score::Kill800Plus = "10"; if (!$Score::RepairObject) $Score::RepairObject = "1"; if (!$Wasteland::SpawnSafe) $Wasteland::SpawnSafe = "5"; if (!$Wasteland::HeadShot) $Wasteland::HeadShot = "3"; if (!$Wasteland::KillTime) $Wasteland::KillTime = 120;

function ObjectiveMission::missionComplete()
{
	TribeStat_ShowScores();
	$missionComplete = "True";
	ObjectiveMission::setObjectiveHeading();
	$missionComplete = false;
    	schedule("Server::nextMission();", 0);
}

function ObjectiveMission::setObjectiveHeading()
{
	%numClients = getNumClients();
	for(%k = 0 ; %k < %numClients; %k++)
		%clientList[%k] = getClientByIndex(%k);
	if(!$Server::timeLimit)
		%str = "<f1>   - No time limit on the game.";
	else if($timeLimitReached)
		%str = "<f1>   - Time limit reached.";
	else if($missionComplete)
	{
		%time = getSimTime() - $missionStartTime;
		%minutes = Time::getMinutes(%time);
		%seconds = Time::getSeconds(%time);

		if(%minutes < 10)
			%minutes = "0" @ %minutes;
		if(%seconds < 10)
			%seconds = "0" @ %seconds;

		%str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
	}
	else
		%str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";

	for(%i = -1; %i < getNumTeams(); %i++)
	{
		objective::displayBitmap(%i, 0);
		Team::setObjective(%i, 1, " ");
		Team::setObjective(%i, 2, " ");
		Team::setObjective(%i, 3, " ");
		Team::setObjective(%i, 4, "<f5>Mission: " @ $missionName);
		Team::setObjective(%i, 5, " ");
		Team::setObjective(%i, 6, %str);
	}

	if($missionComplete == "True") //========= When The Mission Is Over
	{
		//========= Save all players stats at mission end...
		if ($Wasteland::SaveOn)
		{
			echo ("*** Saving Players");
			saveall();
		}

		%curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[0] = 0;

		for(%i = 1; %i < getNumTeams() ; %i++)
		{
			echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
			if($teamScore[%i] == $teamScore[%curLeader])
			{
				%tieGame = true;
				%tieTeams[%tie++] = %i;
			}
			else
			if($teamScore[%i] > $teamScore[%curLeader])
			{
				%curLeader = %i;
				%tieGame = false;
				%tie = 0;
				%tieTeams[0] = %i;
			}
		}

		if(%tieGame) //============ If The Game Is Tied
		{
			for(%g = 0; %g <= %tie; %g++)
			{
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and ";
				else if(%g != %tie)
					%names = %names @ ", ";
			}
			if(%tie > 1)
			 	%names = %names @ " all";
		}
		else
		{
			//===penalize loosing-team players' scores
			for(%k= 0 ; %k < %numClients; %k++)
			{
				%team = GameBase::getTeam(%clientList[%k]);
				if (GameBase::getTeam(%clientList[%k]) != %curLeader) %clientList[%k].score = 0;
			}
			//======done with penalty
		}
		//======================================================= Team Scores
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			if(!%tieGame)
			{
	         		if(%i == %curLeader)
			 	{
					if($teamScore[%curLeader] == 1)
					   	Team::setObjective(%i, 4, "<F5>Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
					   	Team::setObjective(%i, 4, "<F5>Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else
				{
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 4, "<F0>Your team lost to the " @ getTeamName(%curLeader) @ " team, who won with " @ $teamScore[%curLeader] @ " point!");
  					else
	          			Team::setObjective(%i, 4, "<F0>Your team lost to the " @ getTeamName(%curLeader) @ " team, who won with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}
			else
			{
				if(getNumTeams() < 3)
					Team::setObjective(%i, 4, "<F5>The " @ %names @ " tied with  " @ $teamScore[%curLeader] @ " points.");

				else
					Team::setObjective(%i, 4, "<F5>Many teams tied with " @ $teamScore[%curLeader] @ " points.");
			}
		}
	}
	else
	{
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			Team::setObjective(%i, 5,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
		}
	}

	//============ Sort Client List By Score Highest To Lowest
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%k= 0 ; %k < %numClients; %k++)
		{
			if((%clientList[%k]).score < (%clientList[%k+1]).score)
			{
				%hold = %clientList[%k];
				%clientList[%k] = %clientList[%k+1];
				%clientList[%k+1]	= %hold;
				%doIt=1;
			}
		}
	}
	//================= Find Outstanding Client By Category
	// high score
	%highScore = 0;
	%highScoreKills = 0;
	%highScoreDeaths = 0;
	%highRatio = 0;
	%highTKCount = 0;
	%highFlagCaps = 0;
	for(%k= 0 ; %k < %numClients; %k++)
	{
		// calc efficiency
		(%clientList[%k]).ratio = getEfficiencyRatio(%clientList[%k]);
		// Score
		if((%clientList[%k]).score > %highScore) { %highScore = (%clientList[%k]).score; }
		// ScoreKills
		if((%clientList[%k]).ScoreKills > %highScoreKills) { %highScoreKills = (%clientList[%k]).scoreKills; }
		// ScoreDeaths
		if((%clientList[%k]).ScoreDeaths > %highScoreDeaths) { %highScoreDeaths = (%clientList[%k]).scoreDeaths; }
		// Ratio
		if((%clientList[%k]).ratio > %highRatio) { %highRatio = (%clientList[%k]).ratio; }
		// TKCount
		if((%clientList[%k]).TKCount > %highTKCount) { %highTKCount = (%clientList[%k]).TKCount; }
		// FlagCaps
		if((%clientList[%k]).FlagCaps > %highFlagCaps) { %highFlagCaps = (%clientList[%k]).FlagCaps; }
	}
	%group = nameToID("MissionCleanup/ObjectivesSet");
	//===== Print up player scores
	for(%i = -1; %i < getNumTeams(); %i++)
	{
		%lineNum = $firstObjectiveLine+1;
		if($missionComplete) %lineNum = $firstObjectiveLine-2;
		else
		{
			Team::setObjective(%i, %lineNum-4, " ");
			Team::setObjective(%i, %lineNum-3, "<f5>Objectives:");
		}

		for(%k = 0; (%obj = Group::getObject(%group, %k)) != -1; %k++)
		{
			if(!$missionComplete)
			{
				%lineNum++;
				ObjectiveMission::objectiveChanged(%obj);
			}
			else 
			{
				%obj.objectiveLine = %k + %lineNum + %numClients +3;
				ObjectiveMission::objectiveChanged(%obj);
			}
		}
		if(!$missionComplete)
		{
			if($TestMissionType == "CTB")
			{
	 			Team::setObjective(%i, %lineNum++, "<f1> <Bskull_big.bmp> Collect bones from the enemy.");
			}
			else if($TestMissionType == "VeC")
			{
 				Team::setObjective(%i, %lineNum++, "<f1>  <BM_Vehicle_Green.bmp>  Park the objective Vehicle in your team's hanger.");
			}
			else if($Game::MissionType == "DM")
			{
 				Team::setObjective(%i, %lineNum++, "<f1> <BCUR_Centering.bmp> Kill or be killed.");
			}
			else if($Game::MissionType == "ELIM")
			{
 				Team::setObjective(%i, %lineNum++, "<f1> <Bskull_big.bmp> Kill or be eliminated.");
			}
			else if($TestMissionType == "CTE")
			{
 				Team::setObjective(%i, %lineNum++, "<f1>  <BI_energyrifle_on.bmp>  Capture the enemy's energy.");
			}
			else if($TestMissionType == "RACE")
			{
 				Team::setObjective(%i, %lineNum++, "<f1>  <Bcur_rotate.bmp>  Be the first to cross the finish line.");
			}
			else if($TestMissionType == "SMR")
			{
 				Team::setObjective(%i, %lineNum++, "<f1> <Bflag_neutral.bmp> Hold the Scoring Flag for points.");
			}
			else if($TestMissionType == "DUEL")
			{
 				Team::setObjective(%i, %lineNum++, "<f1> <Bskull_big.bmp> First to 10 deaths looses the duel.");
			}
			else if($TestMissionType == "NONE")
			{
	 			Team::setObjective(%i, %lineNum++, "<f1> <Bflag_notatbase.bmp> Objective type not recognized, so just get busy!");
			}
	 		Team::setObjective(%i, %lineNum++, " ");
	 		Team::setObjective(%i, %lineNum++, " ");
		}
		// header
	 	Team::setObjective(%i, %lineNum -1, " ");
		Team::setObjective(%i, %lineNum, "<f5>Players:<f0><L57>Score<L66>Kills<L73>Deaths<L84>Ratio<L92>TKs<L99>Caps");
		//========== Print Client Scores for every team's objective screen
		%c = 0;
		while(%c < %numClients)
		{
			// defaults
			%FontScore = "<F0>";
			%FontScoreKills = "<F0>";
			%FontScoreDeaths = "<F0>";
			%FontRatio = "<F0>";
			%FontTKCount = "<F0>";
			%FontFlagCaps = "<F0>";
			// Score
			if((%clientList[%c]).score == %highScore && %highScore > 0)
			{
				%FontScore = "<F1>";
			}
			// ScoreKills
			if((%clientList[%c]).scoreKills == %highScoreKills && %highScoreKills > 0)
			{
				%FontScoreKills = "<F1>";
			}
			// ScoreDeaths
			if((%clientList[%c]).scoreDeaths == %highScoreDeaths && %highScoreDeaths > 0)
			{
				%FontScoreDeaths = "<F4>";
			}
			// Ratio
			if((%clientList[%c]).ratio == %highRatio && %highRatio > 0)
			{
				%FontRatio = "<F1>";
			}
			// TKCount
			if((%clientList[%c]).TKCount == %highTKCount && %highTKCount > 0)
			{
				%FontTKCount = "<F4>";
			}
			// FlagCaps
			if((%clientList[%c]).FlagCaps == %highFlagCaps && %highFlagCaps > 0)
			{
				%FontFlagCaps = "<F1>";
			}
			// scores
	         	if(GameBase::getTeam(%clientList[%c]) == %curLeader || %tieGame || !$missionComplete)
			{
				Team::setObjective(%i, %lineNum++, "<L4>#" @ (%c + 1) @ "<L12>" @ Client::getName(%clientList[%c]) @ "<L57>" @ %FontScore @ (%clientList[%c]).score @ "<L66>" @ %FontScoreKills @ (%clientList[%c]).ScoreKills @ "<L73>" @  %FontScoreDeaths @ (%clientList[%c]).ScoreDeaths @ "<L84>" @  %FontRatio @ (%clientList[%c]).ratio @ "<L92>" @  %FontTKCount @ (%clientList[%c]).TKCount @ "<L99>" @ %FontFlagCaps @ (%clientList[%c]).FlagCaps);
			}
			else
			{
				Team::setObjective(%i, %lineNum++, "<L4>#" @ (%c + 1) @ "<L12>" @ Client::getName(%clientList[%c]) @ "<L57><F0>Lost<L66>" @ %FontScoreKills @ (%clientList[%c]).ScoreKills @ "<L73>" @  %FontScoreDeaths @ (%clientList[%c]).ScoreDeaths @ "<L84>" @  %FontRatio @ (%clientList[%c]).ratio @ "<L92>" @  %FontTKCount @ (%clientList[%c]).TKCount @ "<L99>" @ %FontFlagCaps @ (%clientList[%c]).FlagCaps);
			}

			%lastRatio = (%clientList[%c]).score;
			%c++;
		}
		if($missionComplete)
		{
			Team::setObjective(%i, %lineNum++, " ");
			Team::setObjective(%i, %lineNum++, "<f5>Objectives:");
			if($TestMissionType == "CTB" || $TestMissionType == "VeC" || $Game::MissionType == "DM" || $Game::MissionType == "ELIM" || $TestMissionType == "CTE" || $TestMissionType == "RACE" || $TestMissionType == "SMR" || $TestMissionType == "DUEL" || $TestMissionType == "NONE") Team::setObjective(%i, %lineNum++, "<f1> Mission Complete.");
		}
		for(%s = %lineNum+1; %s < 30 ;%s++) Team::setObjective(%i, %s, " ");
	}
}

//================== Display Team Bit Maps
function objective::displayBitmap(%team, %line)
{
	if($TestMissionType == "CTF")
	{
		%bitmap1 = "capturetheflag1.bmp";
		%bitmap2 = "capturetheflag2.bmp";
	}
	else if($TestMissionType == "C&H")
	{
		%bitmap1 = "captureandhold1.bmp";
		%bitmap2 = "captureandhold2.bmp";
	}
	else if($TestMissionType == "D&D")
	{
		%bitmap1 = "defendanddest1.bmp";
		%bitmap2 = "defendanddest2.bmp";
	}
	else if($TestMissionType == "F&R")
	{
		%bitmap1 = "findandret1.bmp";
		%bitmap2 = "findandret2.bmp";
	}
	else if($TestMissionType == "DM")
	{
		%bitmap1 = "deathmatch1.bmp";
		%bitmap2 = "deathmatch2.bmp";
	}
	if(%bitmap1 == "" || %bitmap2 == "")
	{
		if($TestMissionType == "CTB")
		{
 			Team::setObjective(%team, %line, "<f9><jc>BONE COLLECTOR");
		}
		else if($TestMissionType == "VeC")
		{
 			Team::setObjective(%team, %line, "<f9><jc>VEHICLE CAPTURE");
		}
		else if($Game::missionType == "ELIM")
		{
 			Team::setObjective(%team, %line, "<f9><jc>ELIMINATOR");
		}
		else if($TestMissionType == "CTE")
		{
 			Team::setObjective(%team, %line, "<f9><jc><BI_energyrifle_on.bmp>     ENERGY     CAPTURE");
		}
		else if($TestMissionType == "RACE")
		{
 			Team::setObjective(%team, %line, "<f9><jc>RACING");
		}
		else if($TestMissionType == "SMR")
		{
 			Team::setObjective(%team, %line, "<f9><jc>SMEAR THE FLAG");
		}
 		else Team::setObjective(%team, %line, "<f9><jc>MISSION SUMMERY");
	}
	else Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap1 @ "><B0,0:" @ %bitmap2 @ ">");
}

//=============== Get Player Ratios
function getEfficiencyRatio(%clientId)
{
	%ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100);
	if (%ratio > 0)
		return %ratio;
	else
		return "0";
}

function Vote::changeMission()
{
	$missionComplete = true;
	ObjectiveMission::refreshTeamScores();
	%group = nameToID("MissionCleanup/ObjectivesSet");
	%lineNum = "";
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		ObjectiveMission::objectiveChanged(%obj);
	}
	for(%i = 0; %i < getNumTeams(); %i++)
	{
		Team::setObjective(%i, $firstObjectiveLine-2, " ");
		Team::setObjective(%i, $firstObjectiveLine-1, "<f5>Mission Summary:");
	}
	ObjectiveMission::setObjectiveHeading();
	$missionComplete = false;
}

function ObjectiveMission::checkScoreLimit()
{
   %done = false;
   ObjectiveMission::refreshTeamScores();

   for(%i = 0; %i < getNumTeams(); %i++)
      if($teamScore[%i] >= $teamScoreLimit)
         %done = true;

   if(%done)
      ObjectiveMission::missionComplete();
}

function ObjectiveMission::checkPoints()									
{
	for(%i = 0; %i < getNumTeams(); %i++)
		$teamScore[%i] += $deltaTeamScore[%i] / 12;
	schedule("ObjectiveMission::checkPoints();", 5);
	ObjectiveMission::checkScoreLimit();
}

function ObjectiveMission::initCheck(%object)
{
	if($TestMissionType == "")
	{
		%name = gamebase::getdataname(%object);
		if(%name == EnergyTrigger)
		{
			$TestMissionType = "CTE";
		}
		else if(%name == RaceTrigger)
		{
			$TestMissionType = "RACE";
		}
		else if($Bone)
		{
			$TestMissionType = "CTB";
		}
		else if(%name == Flag)
		{
			if(gamebase::getteam(%object) != -1)
				$TestMissionType = "CTF";
			else
				$TestMissionType = "F&R";
		}
		else if(%object.objectiveName != "" && %object.scoreValue)
			$TestMissionType = "D&D";
		else if(%name == TowerSwitch) $NumTowerSwitchs++;

		else if ($Game::missionType == "DM") $TestMissionType = "DM";//freeforall
		else if ($Game::missionType == "ELIM") $TestMissionType = "ELIM";//elimination

		else if(%object.num == "Main2") $TestMissionType = "VeC";//vehicle capture
		//==== SMR = Smear mission, set by smear.cs
	}

	%object.trainingObjectiveComplete = "";
	%object.objectiveLine = "";
	if(GameBase::virtual(%object, objectiveInit))
		addToSet("MissionCleanup/ObjectivesSet", %object);
}

function Game::refreshClientScore(%clientId)
{
	%team = Client::getTeam(%clientId);
	if(%team == -1) %team = 9;
	Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l\t" @ %clientId.TotalScore @ "\t", %clientId.score + (9 - %team) * 10000);
	if($Wasteland::ScoreTracker) ScoreTracker(%clientId);
}

function Mission::init()
{
	setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL\t\xFFTotalScore");
	setTeamScoreHeading("Team Name\t\xD6Score");
	$firstTeamLine = 7;
	$firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
	for(%i = -1; %i < getNumTeams(); %i++)
	{
		$teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
		Team::setObjective(%i, $firstTeamLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine, " ");
		//Team::setObjective(%i, $firstObjectiveLine, "<f5>Objectives: missioninit");
		$firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
		$teamScore[%i] = 0;
		newObject("TeamDrops" @ %i, SimSet);
		addToSet(MissionCleanup, "TeamDrops" @ %i);
		%dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
		for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
		addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
	}

	$numObjectives = 0;
	newObject(ObjectivesSet, SimSet);
	addToSet(MissionCleanup, ObjectivesSet);

	Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
	%group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();

	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		%obj.objectiveLine = %i + $firstObjectiveLine;
		ObjectiveMission::objectiveChanged(%obj);
	}

	ObjectiveMission::refreshTeamScores();

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%cl.score = 0;
		%cl.elim = "";
		%cl.race = "";
		%cl.laps = "";
		%cl.leg = "";
		Game::refreshClientScore(%cl);
	}
	schedule("ObjectiveMission::checkPoints();", 5);
	if($TestMissionType == "")
	{
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
	AI::setupAI();
}

function ObjectiveMission::refreshTeamScores()
{
	%nt = getNumTeams();
	Team::setScore(-1, "%t\t  0", 0);
	for(%i = -1; %i < %nt; %i++)
	{
		Team::setScore(%i, "%t\t  " @ $teamScore[%i], $teamScore[%i]);
		for(%j = 0; %j < %nt; %j++)
			Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j]);
	}
}

function ObjectiveMission::objectiveChanged(%this)
{
	if(%this.objectiveLine)
		for(%i = -1; %i < getNumTeams(); %i++)
			Team::setObjective(%i,%this.objectiveLine, "<f1> " @ GameBase::virtual(%this, getObjectiveString, %i));
}

//============= Handles all scoring based on distance to Towers
function Client::leaveGame(%clientId)
{
   echo("GAME: clientdrop " @ %clientId);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
}

function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}

function checkObjectives(%this)
{
   if($debug) echo("checking for objective player leave mission area...");
}

function TowerSwitch::objectiveInit(%this)
{
   return %this.scoreValue || %this.deltaTeamScore;
}

function TowerSwitch::onAdd(%this)
{
	%this.numSwitchTeams = 0;
}

function TowerSwitch::onDamage()
{
}

function TowerSwitch::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);

   if($missionComplete)
   {
      if(%thisTeam == -1)
         return "<Btowers_neutral.bmp>\nNo team claimed " @ %this.objectiveName @ ".";
      else if(%thisTeam == %forTeam)
         return "<Btower_teamcontrol.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
      else {
       	if(%forTeam != -1)
		   	return "<Btower_enemycontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
   		else
		   	return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
		}
	}
   else
   {
		if(%forTeam != -1)
		{
     		if(%this.deltaTeamScore)
     		{
				if(%thisTeam == -1)
 			   	return "<Btowers_neutral.bmp>\nClaim " @ %this.objectiveName @ " to gain " @ %this.deltaTeamScore @ " points per minute.";
 			   else if(%thisTeam == %forTeam)
 			      return "<Btower_teamcontrol.bmp>\nDefend " @ %this.objectiveName @ " to retain " @ %this.deltaTeamScore @ " points per minute.";
 			   else
 			      return "<Btower_enemycontrol.bmp>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points per minute.";
			}
     		else if(%this.scoreValue)
     		{
     			if(%thisTeam == -1)
     		      return "<Btowers_neutral.bmp>\nClaim and defend " @ %this.objectiveName @ " to gain " @ %this.scoreValue @ " points.";
     		   else if(%thisTeam == %forTeam)
     		      return "<Btower_teamcontrol.bmp>\nDefend " @ %this.objectiveName @ " to retain " @ %this.scoreValue @ " points.";
     		   else
     		      return "<Btower_enemycontrol.bmp>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points.";
     		 }
		}
		else {
 			if(%thisTeam == -1)
 			  	return "<Btowers_neutral.bmp>\n" @ %this.objectiveName @ " has not been claimed.";
 			else
 			   return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team is in control of the " @ %this.objectiveName @ ".";
	  	}
   }
}
//=========================================== Player Touches A Tower Switch

function TowerSwitch::onCollision(%this, %object)
{
   if($debug) echo("switch collision ", %object);
   if(getObjectType(%object) != "Player") return;
   if(Player::isDead(%object)) return;

   %playerTeam = GameBase::getTeam(%object);
   %oldTeam = GameBase::getTeam(%this); %oldname = getTeamName(%oldteam);
   if(%oldTeam == %playerTeam) return;
   %playerClient = Player::getClient(%object);
   if(%playerClient.curse) return;
   %touchClientName = Client::getName(%playerClient);
   if (%oldTeam != %playerTeam && %this.lockout == True)
	{
		TeamMessages(1, %playerTeam, "The " @ %oldname @ " have locked this switch against capture!~wAccess_Denied.wav", -2, "null",%touchClientName @ " attempted to gain control of a locked switch!~wfemale1.wbasundr.wav");
		return;
	}
   %this.trainingObjectiveComplete = true;
   %group = GetGroup(%this);
   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);

   %dropPoints = nameToID(%group @ "/DropPoints");
   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);

   $deltaTeamScore[%oldTeam] -= %this.deltaTeamScore;
   $deltaTeamScore[%playerTeam] += %this.deltaTeamScore;
   //TS
   echo("\"B\"" @ %oldTeam @ "\"-" @ %this.scoreValue @ "\"");
   echo("\"B\"" @ %playerTeam @ "\"" @ %this.scoreValue @ "\"");
   $teamScore[%oldTeam] -= %this.scoreValue;
   $teamScore[%playerTeam] += %this.scoreValue;

   if(%dropPoints != -1)
   {
      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      {
         if(%oldDropSet != -1)
            removeFromSet(%oldDropSet, %dropPoint);
         addToSet(%newDropSet, %dropPoint);
      }
   }
   //TS
   echo("\"O\"" @ %playerClient @ "\"0\"");
   //================== Points For Getting Objectives
   if(%oldTeam == -1)
   {
	MessageAllExcept(%playerClient, 0, %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
	Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");

	//============================== Score For Initial Capture
	%playerClient.score = (%playerClient.score + $Score::InitialObj);
	if ($ScoresOn) bottomprint(%playerClient, "<jc>Score +" @ $Score::InitialObj @ " = " @ %playerClient.score ,3);
   }
   else
   {
	if(%this.objectiveLine)
	{
		MessageAllExcept(%playerClient, 0, %touchClientName @ " captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
		Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
		%this.numSwitchTeams++;

		 //====================== Score For Capture From
		%playerClient.score = (%playerClient.score + $Score::CaptureObj);
		if ($ScoresOn) bottomprint(%playerClient, "<jc>Score +" @ $Score::CaptureObj @ " = " @ %playerClient.score ,3);

			schedule("TowerSwitch::timeLimitCheckPoints(" @ %this @ "," @ %playerClient @ "," @ %this.numSwitchTeams @ ");",60);
	}
   }

   if(%this.objectiveLine)
   {
	TeamMessages(1, %playerTeam, "Your team has taken an objective.~wCapturedTower.wav");
	if(%oldTeam != -1)
	TeamMessages(1, %oldTeam, "The " @ getTeamName(%playerTeam) @ " team has taken your objective.~wLostTower.wav");
	ObjectiveMission::ObjectiveChanged(%this);
   }
   ObjectiveMission::checkScoreLimit();
}


function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{
   //give player 5 points for capturing tower!
	if(%this.numSwitchTeams == %numChange) {
	   %client.score+=5;
		Game::refreshClientScore(%client);
		//TS
        echo("\"H\"" @ %client @ "\"5\"");
	   systemMessage(%client, 0, "You receive 5 points for holding your captured tower!");
	}
}

function TowerSwitch::clientKilled(%this, %playerId, %killerId)
{
	if(!%this.objectiveLine)
		return;

	%killerTeam = Client::getTeam(%killerId);
	%playerTeam = Client::getTeam(%playerId);
	%killerPos = GameBase::getPosition(%killerId);

	if(%killerId && (%playerTeam != %killerTeam))
	{
		%dist = Vector::getDistance(%killerPos, GameBase::getPosition(%this));
		if($debug) echo(%dist);

		if(%dist <= 80)
		{
			if($debug) echo("distance to objective" @ %this @ " : " @ %dist);
			if(GameBase::getTeam(%this) == Client::getTeam(%killerId) && getObjectType(%killerId) == "Player")
			{//TS
				echo("\"J\"" @ %killerID @ "\"1\"");
				%killerId.score++;
				Game::refreshClientScore(%killerId);
				messageAll(0, strcat(Client::getName(%killerId), " receives a bonus for defending " @ %this.objectiveName @ "."));
			}
		}
	}
}

// objective init must return true
function Flag::objectiveInit(%this)
{
	%this.originalPosition = GameBase::getPosition(%this);
	%this.atHome = true;
	%this.pickupSequence = 0;
	%this.carrier = -1;
	%this.holdingTeam = -1;
	%this.holder = "";

	%this.enemyCaps = 0;
	%this.caps[0] = 0;
	%this.caps[1] = 0;
	%this.caps[2] = 0;
	%this.caps[3] = 0;
	%this.caps[4] = 0;
	%this.caps[5] = 0;
	%this.caps[6] = 0;
	%this.caps[7] = 0;

	$teamFlag[GameBase::getTeam(%this)] = %this;

	return true;
}

function Flag::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   if($debug) echo("Flag objectiveString");

   if($missionComplete)
   {
      if(%thisTeam == -1)
      {
         if(%this.holdingTeam == %forTeam && %forTeam != -1)
            return "<Bflag_atbase.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
         else if(%this.holdingTeam == -1)
            return "<Bflag_neutral.bmp>\nNo team finished the mission in control of " @ %this.objectiveName @ ".";
         else {
				if(%forTeam != -1)
					return "<Bflag_enemycaptured.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
      		else
					return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
			}
		}
      else if(%forTeam != -1)
      {
         if(%thisTeam == %forTeam)
            return "<Bflag_atbase.bmp>\nYour flag was captured " @ %this.enemyCaps @ " times.";
         else
            return "<Bflag_enemycaptured.bmp>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times.";
      }
  		else
      	return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ "'s flag was captured " @ %this.enemyCaps @ " times.";
   }
   else
   {
      if(%thisTeam == -1)
      {
			if(%forTeam != -1) {
         	if(%this.holdingTeam == %forTeam)
         	   return "<Bflag_atbase.bmp>\nDefend " @ %this.objectiveName @ ".";
         	else if(%this.holdingTeam != -1)
         	   return "<Bflag_enemycaptured.bmp>\nGrab " @ %this.objectiveName @ " from the " @ getTeamName(%this.holdingTeam) @ " team.";
         	else if(%this.carrier != -1)
         	{
         	   if(GameBase::getTeam(%this.carrier) == %forTeam)
         	      return "<Bflag_atbase.bmp>\nConvey " @ %this.objectiveName @ " to an empty flag stand. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
         	   else
         	      return "<Bflag_enemycaptured.bmp>\nWaylay " @ Client::getName(Player::getClient(%this.carrier)) @ " and convey " @ %this.objectiveName @ " to your base.";
         	}
         	else if(%this.atHome)
         	   return "<Bflag_neutral.bmp>\nGrab " @ %this.objectiveName @ " and convey it to an empty flag stand.";
         	else
         	   return "<Bflag_notatbase.bmp>\nFind " @ %this.objectiveName @ " and convey it to an empty flag stand.";
      	}
			else {
         	if(%this.holdingTeam != -1)
         	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team has " @ %this.objectiveName @ ".";
         	else if(%this.carrier != -1)
        	      return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has " @ %this.objectiveName @ ".";
         	else if(%this.atHome)
         	   return "<Bflag_neutral.bmp>\n" @ %this.objectiveName @ " has not been found.";
				else
	        	   return "<Bflag_notatbase.bmp>\n" @ %this.objectiveName @ " has been dropped in the field.";
			}
		}
      else
      {
         if(%thisTeam == %forTeam)
         {
            if(%this.atHome)
               return "<Bflag_atbase.bmp>\nDefend your flag to prevent enemy captures.";
            else if(%this.carrier != -1)
               return "<Bflag_enemycaptured.bmp>\nReturn your flag to base. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
            else
               return "<Bflag_notatbase.bmp>\nReturn your flag to base. (dropped in the field)";
         }
         else
         {
				if(%forTeam != -1) {
            	if(%this.atHome)
            	   return "<Bflag_enemycaptured.bmp>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(GameBase::getTeam(%this.carrier) == %forTeam)
            	   return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " to base.";
            	else
            	   return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " and steal his flag.";
         	}
				else {
            	if(%this.atHome)
            	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field.";
            	else
            	   return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has the " @ getTeamName(%thisTeam) @ " flag.";
				}
			}
      }
   }
}
//===================
//	 Flag Releated Calls
//=========================

function Flag::onDrop(%player, %type)
{
	if($debug) echo ("*** Flag Dropped");

	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);

	$FlagCarry[%flagTeam] = "";

	echo("\"P\"" @ %playerClient @ "\"0\"");
	echo("ADMINMSG: **** " @ %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");

	%homepos = ($teamFlag[%playerTeam]).originalPosition; //========= Get Base location for live player.
	%droppos = GameBase::getPosition(%player);
	%disthome = (Vector::getDistance(%homepos,%droppos));

	GameBase::throw(%flag, %player, 10, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	if(%flagTeam == -1)
	{
		MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
		Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
		$Spoonbot::HuntFlagrunner = 0;
	}
	else //============== Mesage Players If Flag Was Dropped In The Field.
	{	//============= Messaging for the flag dropping needs to go here.

		if (%flagTeam == %playerTeam && %disthome <= 10)
		{
			if($debug) echo ("************** RETURNED FLAG TO BASE **");


				//=============== Returns Flag From Player To Stand
				GameBase::startFadeOut(%flag);
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%flag);
				%flag.atHome = true;
				$flagAtHome[1] = true;
				%flag = %object.carryFlag;
				%flag.atHome = true;
				%flag.carrier = -1;
				Item::hide(%flag, false);

				//================ Removes Flag From Player
				Player::setItemCount(%object, Flag, 0);
				%object.carryFlag = "";
				%flag.carrier = -1;
				Flag::clearWaypoint(%playerClient, true);

				//================ Applies Manual Return Score
				if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + ($Score::FlagReturn * 3));
				bottomprint(%playerClient, "<jc>You Safely Returned Your Flag Score + " @ ($Score::FlagReturn * 3) @ " = " @ %playerClient.score ,3);
					Game::refreshClientScore(%playerClient);

				//================= Message Players And Team About Flag Return

	        	MessageAllExcept(%playerClient, 0, %playerName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
	        	Client::sendMessage(%playerClient, 0, "You returned your flag!~wflagreturn.wav");
	        	teamMessages(1, %playerTeam, "Your flag was returned to base by " @ %playerName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
			$Spoonbot::HuntFlagrunner = 0;
			return;
		}
		else
		{
		    	MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
		    	Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
		    	TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
			$Spoonbot::HuntFlagrunner = 0;
		}
   }


	if ($Wasteland::FlagNoReturn)
	{
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $Wasteland::FlagReturnTime);
        	TeamMessages(1, %flagTeam, "You MUST Return Your Flag!!!", -2, "", "Get the " @ getTeamName(%flagTeam) @ " flag!!!");

		echo ("Flag      =" @ %flag);
		echo ("Flag Team =" @ getTeamName(%flagTeam));

		Gamebase::setMapName(%flag, "The " @ getTeamName(%flagTeam) @ " Flag");
	}
	else
	{
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}

	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

//========== Flag Check Return
function Flag::checkReturn(%flag, %sequenceNum)																	// objectives.cs
{
	if(%flag.pickupSequence == %sequenceNum && !%flag.timerOn)
	{
		if(%flag.dropFade)
		{
			GameBase::startFadeOut(%flag);
			%flag.dropFade= "";
			%flag.fadeOut= 1;
			schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
		}
		else
		{
			$FlagCarry[%flagTeam] = "";

   	   		%flagTeam = GameBase::getTeam(%flag);
   	   		if(%flagTeam == -1)
   	    		{
				if(!%flag.flagStand || %flag.flagStand.flag != "")
				{
					MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");
					%flag.flagStand = "";
					$Spoonbot::HuntFlagrunner = 0;
   				}
   				else
   				{
					%holdTeam = GameBase::getTeam(%flag.flagStand);
					TeamMessages(0, %holdTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(GameBase::getTeam(%flag.flagStand)) @ " flag was returned to base.~wflagreturn.wav");
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
					%flag.flagStand.flag = %flag;
					%flag.holdingTeam = %holdTeam;
					%flag.carrier = -1;

					echo("\"B\"" @ %holdTeam @ "\"" @ %flag.scoreValue @ "\"");

					$teamScore[%holdTeam] += %flag.scoreValue;
					$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
					%flag.holder = %flag.flagStand;
					TeamMessages(0,%holdTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
					ObjectiveMission::checkScoreLimit();
					$Spoonbot::HuntFlagrunner = 0;
				}
			}
			else
			{
				TeamMessages(0, %flagTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was returned to base.~wflagreturn.wav");
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%flag, "0 0 0");
			}
			%flag.atHome = true;
			GameBase::startFadeIn(%flag);
			%flag.fadeOut= "";
			ObjectiveMission::ObjectiveChanged(%flag);
		}
	}
}

//===================== Touching The Flag
function Flag::onCollision(%this, %object)
{
	if($debug) echo("Flag collision ", %object);

	if(getObjectType(%object) != "Player")
		return;

	%name = Item::getItemData(%this);
	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);
	%playerClient = Player::getClient(%object);
	if(%playerClient.curse) return;
	%touchClientName = Client::getName(%playerClient);
	%carriedflag = %object.carryFlag;
	%carriedflagteam = GameBase::getTeam(%carriedFlag);
	%carrierflag = Player::getMountedItem(%object, $FlagSlot);

	if(%this.carrier != -1)
		return; //============= Spurious collision
	if (%carrierflag == "Bone")
	{
		bottomprint(%playerClient, "<jc>You must drop the bone you have before you can pick up a flag." ,3);
		return;
	}
	else if (%carrierflag == "flag")
	{
		if (%this.atHome == "True" && %this != %carriedflag && %carriedflagteam != "-1")
		{
		}
		else
		{
			bottomprint(%playerClient, "You must return the flag you have before you can pick up another." ,3);
			return;
		}
	}

	if(%flagTeam == %playerTeam)      //====== player is touching his own flag...
	{
		if(!%this.atHome)             //======= The flag isn't home! so return it.
		{
			if ($Wasteland::FlagNoReturn != "True") //=================================== If No Flag Return Is Not True Flag Returns Normally
			{
				echo ("*** Flag Returned On Contact By " @ %touchClientName @ " - " @ %playerClient);

				GameBase::startFadeOut(%this);
				GameBase::setPosition(%this, %this.originalPosition);
				Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%this);
				%this.atHome = true;

				echo("\"R\"" @ %playerClient @ "\"0\"");
				MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
				Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
				teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");

				//================================= Player Returns Flag To Base

				if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + $Score::FlagReturn);
				bottomprint(%playerClient, "<jc>Score + " @ $Score::FlagReturn @ " = " @ %playerClient.score ,3);
				Game::refreshClientScore(%playerClient);

				%this.pickupSequence++;
				ObjectiveMission::ObjectiveChanged(%this);
				return;
			}
			else //============= If Flag No Return Is True Player Will Have To Return Flag Manually
			{
				Player::setItemCount(%object, Flag, 1);
				Player::mountItem(%object, Flag, $FlagSlot, %playerTeam);
				Item::hide(%this, true);
				$flagAtHome[1] = false;
				%this.atHome = false;
				%this.carrier = %object;
				%this.pickupSequence++;
				%object.carryFlag = %this;
				Flag::setWaypoint(%playerClient, %this);

				schedule("Objective::AutoReturn(" @ %this @ ");", 120); //== Returns Flag If Player Still Holds It.
				return;
			}
		}
		else
		{
			if(%object.carryFlag != "")
			{
				%enemyTeam = GameBase::getTeam(%object.carryFlag);

				if(%enemyTeam != -1)
				{
					MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
					Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
					TeamMessages(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");
					echo("ADMINMSG: **** " @ %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
					%flag = %object.carryFlag;
					%flag.atHome = true;
					%flag.carrier = -1;
					%flag.caps[%playerTeam]++;
					%flag.enemyCaps++;

					Item::hide(%flag, false);
					$flagAtHome[1] = true;
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");

					%flag.trainingObjectiveComplete = true;
					ObjectiveMission::ObjectiveChanged(%flag);

					Player::setItemCount(%object, Flag, 0);
					%object.carryFlag = "";
					Flag::clearWaypoint(%playerClient, true);
					//TS
					echo("\"B\"" @ %playerTeam @ "\"" @ %flag.scoreValue @ "\"");
					$teamScore[%playerTeam] += %flag.scoreValue;
					ObjectiveMission::checkScoreLimit();
					//TS
					echo("\"F\"" @ %playerClient @ "\"5\"");
					//======================================== Flag carrier gets bonus points

					%playerClient.score = (%playerClient.score + $Score::FlagCapture);

					bottomprint(%playerClient, "<jc>Score + " @ $Score::FlagCapture @ " = " @ %playerClient.score ,3);
						%playerClient.FlagCaps = (%playerClient.FlagCaps + 1);

					messageAll(0, Client::getName(%playerClient) @ " receives " @ $Score::FlagCapture @ " point capture bonus.");
					Game::refreshClientScore(%playerClient);
				}
			}
		}
	}
	else //======== Player Grab Enemy Flag
	{
		if(!%object.carryFlag)
		{
			if(!%object.outArea)
			{
				if(%this.holdingTeam == %playerTeam)
					return;

				echo("\"G\"" @ %playerClient @ "\"0\"");
				Player::setItemCount(%object, Flag, 1);
				Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);

				$FlagCarry[%flagTeam] = %playerClient;

				Item::hide(%this, true);
				$flagAtHome[1] = false;
				%this.atHome = false;
				%this.carrier = %object;
				%this.pickupSequence++;
				%object.carryFlag = %this;
				Flag::setWaypoint(%playerClient, %this);

				if(%this.fadeOut)
				{
					GameBase::startFadeIn(%this);
					%this.fadeOut= "";
				}

				if(%flagTeam != -1)
				{
					MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
					Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
					TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
					echo("ADMINMSG: **** " @ %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag!");
				}
				else
				{
					%hteam = %this.holdingTeam;
					if(%hteam != -1)
					{
						echo("\"B\"" @ %hteam @ "\"-" @ %this.scoreValue @ "\"");
						$teamScore[%hteam] -= %this.scoreValue;
						$deltaTeamScore[%hteam] -= %this.deltaTeamScore;

						MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
						Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
						TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
						%this.holdingTeam = -1;
						%this.holder.flag = "";
					}
					else
					{
						MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ ".~wflag1.wav");
						Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ ".~wflag1.wav");
						TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
					}
				}
				%this.trainingObjectiveComplete = true;
				ObjectiveMission::ObjectiveChanged(%this);
			}
		}
	}
}

//=============== Return Flag If Held By Same Team
function Objective::AutoReturn (%this)
{
	%flag = %this;
	%object = %this.carrier;
	%name = Item::getItemData(%this);

	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);

	%playerClient = Player::getClient(%object);

	if (%playerTeam == %flagTeam)
	{
		DoTheFlagDrop(%object);

		MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
		GameBase::setPosition(%flag, %flag.originalPosition);
		Item::setVelocity(%flag, "0 0 0");
		%flag.flagStand = "";
		$Spoonbot::HuntFlagrunner = 0;
	}
}

//====================== Clear Flag Runners Way Point
function Flag::clearWaypoint(%client, %success)
{
   if(%success)
      setCommandStatus(%client, 0, "Objective completed.~wobjcomp");
   else
      setCommandStatus(%client, 0, "Objective failed.");
}


//========================== Set Waypoint For Flag Carrier
function Flag::setWaypoint(%client, %flag)
{
	if(!%client.autoWaypoint)
		return;
	%flagTeam = GameBase::getTeam(%flag);
	%team = Client::getTeam(%client);

	if(%flagTeam == -1)
	{
		for(%s = $teamFlagStand[%team]; %s != ""; %s = %s.nextFlagStand)
		{
			if(!%s.flag)
			{
				%pos = GameBase::getPosition(%s);
				%posX = getWord(%pos,0);
				%posY = getWord(%pos,1);
				issueCommand(%client, %client, 0,"Take " @ %flag.objectiveName @ " to empty flag stand.~wcapobj", %posX, %posY);
				return;
			}
		}
	}
	else
	{
		%pos = ($teamFlag[%team]).originalPosition; //========= Get Base location for live player.

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		issueCommand(%client, %client, 0,"Take the " @ getTeamName(%flagTeam) @ " flag to our stand.~wcapobj", %posX, %posY);
		return;
	}
}

//==================================== Flag Stand Init
function FlagStand::objectiveInit(%this)
{
   %this.flag = "";
   %team = GameBase::getTeam(%this);

   %this.nextFlagStand = $teamFlagStand[%team];
   $teamFlagStand[%team] = %this;

   return false;
}

//======================================= Flag Stand Collition

function FlagStand::onCollision(%this, %object)
{
	//if($debug) echo("************** FlagStand collision ", %object);

	%standTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%object);
	%carryflagTeam = GameBase::getTeam(%object.carryFlag);
	%playerClient = Player::getClient(%object);
	%playerName = Client::getName(%playerClient);

	if (%object.carryFlag != "" && %standTeam == %playerTeam && getObjectType(%object) == "Player" && (%carryflagTeam == %standTeam && %carryflagTeam == %playerTeam))
	{
		if($debug) echo ("************** RETURNED FLAG TO BASE **");

		%flag = %object.carryFlag;

		//========================================================= Returns Flag From Player To Stand
		GameBase::startFadeOut(%flag);
		GameBase::setPosition(%flag, %flag.originalPosition);
		Item::setVelocity(%this, "0 0 0");
		GameBase::startFadeIn(%flag);
		%flag.atHome = true;
		$flagAtHome[1] = true;
		%flag = %object.carryFlag;
		%flag.atHome = true;
		%flag.carrier = -1;
		Item::hide(%flag, false);

		//========================================================= Removes Flag From Player
		Player::setItemCount(%object, Flag, 0);
		%object.carryFlag = "";
		%flag.carrier = -1;
		Flag::clearWaypoint(%playerClient, true);
		echo("\"B\"" @ %playerTeam @ "\"" @ %flag.scoreValue @ "\"");
		//======================= Applies Manual Return Score
		if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + ($Score::FlagReturn * 3));
		bottomprint(%playerClient, "<jc>You Safely Returned Your Flag Score + " @ ($Score::FlagReturn * 3) @ " = " @ %playerClient.score ,3);

		//======================= Message Players And Team About Flag Return

		MessageAllExcept(%playerClient, 0, %playerName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
		Client::sendMessage(%playerClient, 0, "You returned your flag!~wflagreturn.wav");
		teamMessages(1, %playerTeam, "Your flag was returned to base by " @ %playerName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
	}

	//==== Everything After This Is For Find And Retrieve

	if(%standTeam == -1 || getObjectType(%object) != "Player" || !%object.carryFlag || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
	return;

	// If we're here, we're carrying a flag, we've hit our flag stand, it doesn't have a flag, and we're not carrying
	// a team coded flag.

	%flag = %object.carryFlag;
	%flag.carrier = -1;
	Item::hide(%flag, false);
	GameBase::setPosition(%flag, GameBase::getPosition(%this));
	%flag.flagStand = %this;
	Player::setItemCount(%object, Flag, 0);
	%object.carryFlag = "";
	%playerClient = Player::getClient(%object);
	Flag::clearWaypoint(%playerClient, true);

	$teamScore[%playerTeam] += %flag.scoreValue;
	$deltaTeamScore[%playerTeam] += %flag.deltaTeamScore;
	%flag.holder = %this;
	%flag.holdingTeam = %playerTeam;
	%this.flag = %flag;


	MessageAllExcept(%playerClient, 0, Client::getName(%playerClient) @ " conveyed " @ %flag.objectiveName @ " to base.");
	Client::sendMessage(%playerClient, 0, "You conveyed " @ %flag.objectiveName @ " to base.");
	TeamMessages(1, %playerTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");

	%flag.trainingObjectiveComplete = true;
	ObjectiveMission::ObjectiveChanged(%flag);
	ObjectiveMission::checkScoreLimit();
}


//=========================== Flag Defence For Advanced Scoring
function Flag::clientKilled(%this, %playerId, %killerId)
{
	%player = Client::getOwnedObject(%playerId);
	%killer = Client::getOwnedObject(%killerId);

	if(%player == -1 || %killer == -1)
		return;

	%flagTeam = GameBase::getTeam(%this);

	if(%flagTeam == -1)
		return;

	%playerTeam = GameBase::getTeam(%player);
	%killerTeam = GameBase::getTeam(%killer);

	if(%playerTeam == %killerTeam)
	{
		%killerId.score = (%killerId.score - ($Score::FlagDef * 2));
		if ($ScoresOn) centerprint(%killerId, "<jc>You just TKed your own Flag Runner. Score - " @ $Score::FlagDef @ " = " @ %killerId.score @ ", You dumb-dumb.", 3);
		Game::refreshClientScore(%killerId);
		messageAll(0, Client::getName(%killerId) @ " just killed his own team's Flag Runner!");
	}

//==================== Killer's the only guy who gets a bonus.
	if(%killerTeam == %flagTeam)
	{
		if(%this.carrier == -1)
		{
			%flagPos = GameBase::getPosition(%this);
			%playerPos = GameBase::getPosition(%player);
			if(Vector::getDistance(%flagPos, %playerPos) < 80)
			{
				echo("\"E\"" @ %killerID @ "\"1\"");
				%killerId.score = (%killerId.score + $Score::FlagDef);
				if ($ScoresOn) bottomprint(%killerId, "<jc>Score +" @ $Score::FlagDef @ " = " @ %killerId.score ,3);
				Game::refreshClientScore(%killerId);
				messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag!");
			}
		}
	}
	else
	{
		if(%this.carrier != -1)
		{
			%carrierTeam = GameBase::getTeam(%this.carrier);
			if(%carrierTeam == %killerTeam)
			{
				if(Vector::getDistance(GameBase::getPosition(%this.carrier), GameBase::getPosition(%killer)) < 80)
				{
					Game::refreshClientScore(%killerId);
					echo("\"I\"" @ %killerID @ "\"1\"");
					%killerId.score = (%killerId.score + $Score::FlagKill);
					if ($ScoresOn) bottomprint(%killerId, "<jc>Score +" @ $Score::FlagKill @ " = " @ %killerId.score ,3);
					messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
				}
			}
		}
	}
}
//================================ Player Drops From Game
function Flag::clientDropped(%this, %clientId)
{
   if($debug) echo(%this @ " " @ %clientId);
   %type = Player::getMountedItem(%clientId, $FlagSlot);
   if(%type != -1)
      Player::dropItem(%clientId, %type);
}

//=================== Flag Player Leaves Mission Area

function Flag::playerLeaveMissionArea(%this, %playerId)
{
   	// if a guy leaves the area, warp the flag back to its base
   	if(%this.carrier == %playerId)
   	{
		GameBase::startFadeOut(%this);
		Player::setItemCount(%playerId, "Flag", 0);
		%playerClient = Player::getClient(%playerId);
		%clientName = Client::getName(%playerClient);
	   	%flagTeam = GameBase::getTeam(%this);

		if(%flagTeam == -1 && (!%this.flagStand || (%this.flagStand).flag != "") )
	   	{
			MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			%this.flagStand = "";
			$Spoonbot::HuntFlagrunner = 0;
	   	}
	   	else
	   	{
			if(%flagTeam != -1)
			{
				%team = %flagTeam;
				GameBase::setPosition(%this, %this.originalPosition);
            			Item::setVelocity(%this, "0 0 0");
			}
			else
			{
				%team = GameBase::getTeam(%this.flagStand);
				GameBase::setPosition(%this, GameBase::getPosition(%this.flagStand));
            			Item::setVelocity(%this, "0 0 0");
			}

			MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
	      		Client::sendMessage(%playerClient, 0, "You left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
	      		TeamMessages(1, %team, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%team) @ " flag was returned to base.");

                	echo("\"B\"" @ %holdTeam @ "\"" @ %this.scoreValue @ "\"");
                	%holdTeam = GameBase::getTeam(%this.flagStand);
		   	$teamScore[%holdTeam] += %this.scoreValue;
		   	$deltaTeamScore[%holdTeam] += %this.deltaTeamScore;
			%this.holder = %this.flagStand;
	   		%this.flagStand.flag = %this;
			%this.holdingTeam = %holdTeam;
			$Spoonbot::HuntFlagrunner = 0;
		}
		GameBase::startFadeIn(%this);
		%this.carrier = -1;
		Item::hide(%this, false);

		%playerId.carryFlag = "";
      		Flag::clearWaypoint(%playerClient, false);
      		ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
   	}
}

function Sensor::objectiveInit(%this)
{
   	return StaticShape::objectiveInit(%this);
}

function Turret::objectiveInit(%this)
{
   	return StaticShape::objectiveInit(%this);
}

function StaticShape::objectiveInit(%this)
{
   	%this.destroyerTeam = "";
   	return %this.scoreValue != "";
}

function Sensor::getObjectiveString(%this, %forTeam)
{
   	return StaticShape::getObjectiveString(%this, %forTeam);
}

function Turret::getObjectiveString(%this, %forTeam)
{
   	return StaticShape::getObjectiveString(%this, %forTeam);
}

function StaticShape::getObjectiveString(%this, %forTeam)
{
	%thisTeam = GameBase::getTeam(%this);
	if(%this.destroyerTeam != "")
	{
		if(%forTeam == %this.destroyerTeam && %thisTeam != %forTeam)
			return "<Bitem_ok.bmp>\nYour team successfully destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
		else if(%forTeam == %thisTeam)
			return "<Bitem_damaged.bmp>\nYour team failed to defend " @ %this.objectiveName;
		else
			return "<Bitem_ok.bmp>\n" @ getTeamName(%this.destroyerTeam) @ " team destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
	}
	else
	{
		if($missionComplete)
		{
			if(%forTeam != -1)
			{
				if(%forTeam == %thisTeam)
					return "<Bitem_ok.bmp>\nYour team successfully defended " @ %this.objectiveName @ ".";
				else
					return "<Bitem_damaged.bmp>\nYour team failed to destroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ ".";
			}
			else
				return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " failed to destroy the " @ %this.objectiveName @ " objective.";
		}
		else
		{
			if(%forTeam != -1)
			{
				if(%forTeam == %thisTeam)
					return "<Bitem_ok.bmp>\nDefend " @ %this.objectiveName @ ".";
				else
					return "<Bitem_damaged.bmp>\nDestroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ "(" @ %this.scoreValue @ " points).";
			}
			else
				return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " must defend the " @ %this.objectiveName @ " objective.";
		}
	}
}

function StaticShape::timeLimitReached(%this)																	// objectives.cs
{
	if(%this.scoreValue && !%this.destroyerTeam)
	{
		// give the defense some props!
		echo("\"B\"" @ GameBase::getTeam(%this) @ "\"" @ %this.scoreValue @ "\"");
		$teamScore[GameBase::getTeam(%this)] += %this.scoreValue;
	}
}

//======================= Testing For Destroyed Objects
function StaticShape::objectiveDestroyed(%this)
{
	%pntval = 0;

	if(%this.destroyed == "" && !%this.objectiveLine)
	{
		//=================== Set Variables For Scoring and Assigning Points
		%destroyerTeam = %this.lastDamageTeam;
		%thisTeam = GameBase::getTeam(%this);
		if (%this.lastDamageObject < 4000){%playerClient = %this.lastDamageObject;}
		else if (%this.lastDamageObject > 4000){%playerClient = GameBase::getOwnerClient(%this.lastDamageObject);}

		%player = Client::getOwnedObject(%playerClient);

		$lastdamageobj[%this] = GameBase::getControlClient(%this.lastDamageObject);

		if(getObjectType(%player) != "Player")
			return;

		if(%playerClient != -1 || !%playerClient)
		{
			%clientName = Client::getName(%playerClient);
		}
		else return;

		%objtype = getObjectType(%this);
		%objname = (GameBase::getDataName(%this)).description;

		%pntval = Scoring::Object(%this);

		if (%pntval > 0)
		{
			if (%thisTeam == %destroyerTeam) //=== Goof ball destroyed his own stuff.
			{
				echo ("*** " @ %clientName @ " Destoyed His Own " @ %objname @ ".");

				%item = Player::getMountedItem(%playerClient,$WeaponSlot);
				if ((%item == "Mortar") || (%item == "Mfgl"))
					%pntval = floor(%pntval / 2);

				%playerClient.score = (%playerClient.score - %pntval);
				bottomprint(%playerClient, "<jc>Destroyed Friendly " @ %objname @ ". Score - " @ %pntval @ " = " @ %playerClient.score ,3);
			}
			else if (%thisTeam != %destroyerTeam) //======= Good job taking out enemy stuff.
			{
				echo ("*** " @ %clientName @ " Took out the enemys " @ %objname @ ", YEAH!");

				%item = Player::getMountedItem(%playerClient,$WeaponSlot);
				if ((%item == "Mortar") || (%item == "Mfgl"))
					%pntval = floor(%pntval / 2);

				%playerClient.score = (%playerClient.score + %pntval);

				bottomprint(%playerClient, "<jc>Destroyed Enemy " @ %objname @ ". Score + " @ %pntval @ " = " @ %playerClient.score ,3);
			}
		}
		Game::refreshClientScore(%playerClient);
		return;
	}
	else if(%this.destroyed == "" && %this.objectiveLine)
	{
	   	%destroyerTeam = %this.lastDamageTeam;
		%thisTeam = GameBase::getTeam(%this);
	     	%playerClient = GameBase::getControlClient(%this.lastDamageObject);
		if(%playerClient != -1) %clientName = Client::getName(%playerClient);

		if(%thisTeam == %destroyerTeam)
	   	{
			for(%i = 0; %i < getNumTeams(); %i++)
	        	{
	  			if(%i == %thisTeam) continue;
	  	           	$teamScore[%i] += %this.scoreValue;
	   	   	}
	       		if(%playerClient != -1)
	           		{
	     	          		MessageAllExcept(%playerClient, 0, %clientName @ " destroyed a friendly objective.");
	     	          		Client::sendMessage(%playerClient, 0, "You destroyed a friendly objective!");
           				echo("\"Z\"" @ %playerClient @ "\"5\"");
			}
			MessageAll(1, getTeamName(%destroyerTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
		}
	    	else
	    	{
	    	   	$teamScore[%destroyerTeam] += %this.scoreValue;

         		echo("\"B\"" @ %destroyerTeam @ "\"" @ %this.scoreValue @ "\"");

	           	if(%playerClient != -1)
	           	{
				//============ Bonus For Obj Destory
	               	%playerClient.score = (%playerClient.score + $Score::ObjDestroy);

		   		bottomprint(%playerClient, "<jc>Score + " @ $Score::ObjDestroy @ " = " @ %playerClient.score ,3);

				Game::refreshClientScore(%playerClient);

	      	      MessageAllExcept(%playerClient, 0, %clientName @ " destroyed an objective!");
	        	    	Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
           			echo("\"Z\"" @ %playerClient @ "\"5\"");
	     		}
	     		MessageAll(1, getTeamName(%thisTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
	     	}
	   	%this.destroyerTeam = %destroyerTeam;
		ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
		%this.destroyed = 1;
	}
}

function StaticShape::objectiveDisabled(%this)
{
}
