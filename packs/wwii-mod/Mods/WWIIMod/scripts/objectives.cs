exec("game.cs");								
$flagReturnTime = 45;


function WWII::MatchEndSound()
{
if($WWII::TeamPoints[Axis] > $WWII::TeamPoints[Allied]) %winner = 1;
else if($WWII::TeamPoints[Axis] < $WWII::TeamPoints[Allied]) %winner = 0;
else %winner = -1;

for(%cl = client::getfirst(); %cl != -1; %cl = client::getnext(%cl))
	{
	if(gamebase::getteam(%cl) == %winner) client::sendmessage(%cl, 3, "~wMissionWon.wav");
	else if(%winner == -1) client::sendmessage(%cl, 3, "~wMissionTie.wav");
	else client::sendmessage(%cl, 3, "~wMissionFailed.wav");
	}
}

function ObjectiveMission::missionComplete()
{
   $missionComplete = true;
	WWII::MatchEndSound();
	%group = nameToID("MissionCleanup/ObjectivesSet");
   
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
   $missionComplete = false;

   // back out of all the functions...
   schedule("Server::nextMission();", 0);
}

function ObjectiveMission::setObjectiveHeading()
{
if($missionComplete)
   	{
     	eval($Game::missiontype @ "::MissionComplete();");
   	}
   else 
	{
        eval($game::MissionType @ "::SetObjectives();");
	}
}

function objective::displayBitmap(%team, %line)
{
	if($TestMissionType == "CTF") {
		%bitmap1 = "capturetheflag1.bmp";
		%bitmap2 = "capturetheflag2.bmp";
	}
	else if($TestMissionType == "C&H") {
		%bitmap1 = "captureandhold1.bmp";
		%bitmap2 = "captureandhold2.bmp";
	}
	else if($TestMissionType == "D&D") {
		%bitmap1 = "defendanddest1.bmp";
		%bitmap2 = "defendanddest2.bmp";
	}	   
	else if($TestMissionType == "F&R") {
		%bitmap1 = "findandret1.bmp";
		%bitmap2 = "findandret2.bmp";
	}
	if(%bitmap1 == "" || %bitmap2 == "")
 		Team::setObjective(%team, %line, " ");
	else
 		Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap1 @ "><B0,0:" @ %bitmap2 @ ">");
}

function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;
   //ObjectiveMission::setObjectiveHeading();

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }

   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: timelimit");
      $timeLimitReached = true;
      //echo("checking for objective time limit status...");
      %set = nameToID("MissionCleanup/ObjectiveSet");
      for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
         GameBase::virtual(%obj, "timeLimitReached", %clientId);
      ObjectiveMission::missionComplete();
   }
   else
   {
      if(%curTimeLeft >= 20)
         schedule("Game::checkTimeLimit();", 20);
      else
         schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Vote::changeMission()
{
   $missionComplete = true;
	WWII::MatchEndSound();
   ObjectiveMission::refreshTeamScores();
   %group = nameToID("MissionCleanup/ObjectivesSet");
	%lineNum = "";
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	   Team::setObjective(%i, $firstObjectiveLine-1, "<f5>Mission Summary:");
	}
	ObjectiveMission::setObjectiveHeading();
	eval($game::missiontype @ "::SetObjectives();");
	eval($game::missiontype @ "::MissionComplete();");
   $missionComplete = false;
	deletevariables("pak*");
	deletevariables("howitzer*");
}

function ObjectiveMission::checkScoreLimit()
{
   %done = false;
   ObjectiveMission::refreshTeamScores();

   
   for(%x = 0; %x < getnumteams(); %x++)
      if($Game::MissionType == "Conquest" && $WWII::TeamPoints[getteamname(%x)] == 0) { Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }
}

function ObjectiveMission::checkPoints()
{
   
   schedule("ObjectiveMission::checkPoints();", 5);
   ObjectiveMission::checkScoreLimit();
}

function ObjectiveMission::initCheck(%object)
{
	

   %object.trainingObjectiveComplete = "";
   %object.objectiveLine = "";
   if(GameBase::virtual(%object, objectiveInit))
      addToSet("MissionCleanup/ObjectivesSet", %object);
}

function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -1) // observers go last.
      %team = 9;
   // objective mission sorts by team first.
   Client::setScore(%clientId, GetSpawnClassCode(%clientId.spawnclass, player::isdead(%clientId)) @ " %n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
//   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score, %clientId.score);
}

function ObjectiveMission::refreshTeamScores()
{

for(%x = 0; %x < getnumteams(); %x++)
Team::SetScore(%x, "%t\t " @ $WWII::TeamPoints[getteamname(%x)], %x);  
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
{ 
if(%cl.hasTST == 1 && !%clientId.justConnected && client::getguimode(%cl) == $GuiModePlay) { remoteeval(%cl, updateTST, $WWII::TeamPoints[Allied], $WWII::TeamPoints[Axis], $country[0], $country[1], getmaterial()); }
else IssueTargCommand(%cl, %cl, 1, "["@$country[1] @ "(Axis):" @ $WWII::TeamPoints[Axis] @ " || " @ $Country[0] @ "(Allied):" @ $WWII::TeamPoints[Allied]@"]", 2);

}
}



function Mission::init()
{
   setClientScoreHeading("SC   Player Name\t\x7FTeam\t\xA6Score\t\xCFPing");
//   setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");
   setTeamScoreHeading("Team Name\t\xD6Points");

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
  
   $numObjectives = 0;
   
   
   

	ObjectiveMission::setObjectiveHeading();
  
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }
   
$Loop = true;
if($Game::Missiontype == "Conquest" || $Game::Missiontype == "Objective") Conquest::StartLoop();
	
}

function Game::pickRandomSpawn(%team)
{
   %spawnSet = nameToID("MissionCleanup/TeamDrops" @ %team);
   %spawnCount = Group::objectCount(%spawnSet);
   if(!%spawnCount)
      return -1;
  	%spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
  	%value = %spawnCount;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%spawnSet, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %spawnCount - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

//handles all scoring based on distance to Towers
function Client::leaveGame(%clientId)
{
   echo("GAME: clientdrop " @ %clientId);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
}

function Game::clientKilled(%playerId, %killerId)
{
%cl = Player::GetClient(%playerId);
%cl.choosingclass = true;
if($Game::MissionType == "Conquest" || $Game::MissionType == "Objective")
{

$WWII::TeamPoints[getteamname(GameBase::getteam(%playerId))]--;
Conquest::CheckOutposts();
}
}

function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = 0;
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}

function Player::leaveMissionArea(%this)
{
	%this.outArea=1;
	Client::sendMessage(Player::getClient(%this),1,"WARNING!! You are leaving the battle, Deserters will be shot! ~wLeftMissionArea.wav");
	schedule("beep(" @ %this @ ");", 1);
}

function beep(%pl)
{
if(player::isDead(%pl) || %pl.outarea == 0) return;
if(Player::isAiControlled(%pl)) return;
Client::sendMessage(Player::getClient(%pl),1,"~wLeftMissionArea.wav");
%pl.outarea++;
if(%pl.outarea > 10) player::onDamage(%pl, 0, 0.1, 0, 0, 0, 0, 0);
schedule("beep(" @ %pl @ ");", 1);
}
 

function checkObjectives(%this)
{
   //echo("checking for objective player leave mission area...");
}

// objective init must return true
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
   // tower switches can't take damage
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




