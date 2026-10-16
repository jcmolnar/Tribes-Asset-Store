exec("game.cs");								
$flagReturnTime = 45;

function ObjectiveMission::missionComplete()
{
   $missionComplete = true;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	}
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
      %curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
		   echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
      {
		   if($teamScore[%i] == $teamScore[%curLeader]) { 
            %tieGame = true;
         	%tieTeams[%tie++] = %i;
			}
			else if($teamScore[%i] > $teamScore[%curLeader])
         {
            %curLeader = %i;	   
            %tieGame = false;
				%tie = 0;
				%tieTeams[%tie] = %curLeader; 
         }
      }
		if(%tieGame) {
			for(%g = 0; %g <= %tie; %g++) { 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
			 	%names = %names @ " all"; 
		}
		for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
			if(!%tieGame) {
	         if(%i == %curLeader) { 
					if($teamScore[%curLeader] == 1)
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else {
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
  					else
	          		Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}	
			else {
				if(getNumTeams() > 2) {
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
  	         }
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
		}
   }
   else {
      for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
		  	Team::setObjective(%i,1, "<f5>Mission Completion:");
		   Team::setObjective(%i, 2,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
		}
	}
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
   for(%i = -1; %i < getNumTeams(); %i++) {
	  	Team::setObjective(%i, 3, " ");
  		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
      Team::setObjective(%i, 6, %str);
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
   ObjectiveMission::setObjectiveHeading();

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
	if($TestMissionType == "") {
		%name = gamebase::getdataname(%object); 
	   if(%name == Flag) { 
			if(gamebase::getteam(%object) != -1)
				$TestMissionType = "CTF";
			else
				$TestMissionType = "F&R";
		}
		else if(%object.objectiveName != "" && %object.scoreValue)
			$TestMissionType = "D&D";
		else if(%name == TowerSwitch)
			$NumTowerSwitchs++;
	}

   %object.trainingObjectiveComplete = "";
   %object.objectiveLine = "";
   if(GameBase::virtual(%object, objectiveInit))
      addToSet("MissionCleanup/ObjectivesSet", %object);
}




//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000


function ObjectiveMission::objectiveChanged(%this)
{
	if(%this.objectiveLine)
      for(%i = -1; %i < getNumTeams(); %i++)
         Team::setObjective(%i,%this.objectiveLine, 
            "<f1> " @ GameBase::virtual(%this, getObjectiveString, %i));
}

//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""

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

//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}
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
		if(%forTeam != -1) {
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


//______________________________________________________________________________________




function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{
   //give player 5 points for capturing tower!
	if(%this.numSwitchTeams == %numChange) {
	   %client.score+=5;
		Game::refreshClientScore(%client);
	   Client::sendMessage(%client, 0, "You receive 5 points for holding your captured tower!");
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
	%this.changeTeamCount = 0;

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





//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
exec(Nappy_objectives);
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||



function Flag::clearWaypoint(%client, %success)
{
   if(%success)
      setCommandStatus(%client, 0, "Objective completed.~wobjcomp");
   else
      setCommandStatus(%client, 0, "Objective failed.");
}

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
			if(%s.flag == "") {
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
		%pos = ($teamFlag[%team]).originalPosition;
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
  	   issueCommand(%client, %client, 0,"Take the " @ getTeamName(%flagTeam) @ " flag to our flag.~wcapobj", %posX, %posY);
		return;
	}
}

function FlagStand::objectiveInit(%this)
{
   %this.flag = "";
   %team = GameBase::getTeam(%this);

   %this.nextFlagStand = $teamFlagStand[%team];
   $teamFlagStand[%team] = %this;
	
   return false;
}


function Flag::clientDropped(%this, %clientId)
{
   //echo(%this @ " " @ %clientId);
   %type = Player::getMountedItem(%clientId, $FlagSlot);
   if(%type != -1)
      Player::dropItem(%clientId, %type);
}




//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



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
         if(%forTeam != -1) {
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
         if(%forTeam != -1) {
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

function StaticShape::timeLimitReached(%this)
{
   if(%this.scoreValue && !%this.destroyerTeam)
   {
      // give the defense some props!
      $teamScore[GameBase::getTeam(%this)] += %this.scoreValue;
   }
}


function StaticShape::objectiveDisabled(%this)
{
}


