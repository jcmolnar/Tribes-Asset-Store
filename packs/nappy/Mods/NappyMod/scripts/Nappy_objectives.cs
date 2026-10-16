
//if(%flag.atflagstand == 0)




function Flag::checkReturn(%flag, %sequenceNum)
{
if(%flag.atflagstand == 0){
	//echo("checking for flag return: ", %flag, ", ", %sequenceNum);
	if(%flag.pickupSequence == %sequenceNum && %flag.timerOn == ""){
		if(%flag.dropFade) { 
			GameBase::startFadeOut(%flag);
			%flag.dropFade= "";
			%flag.fadeOut= 1;
			schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
		}
		else {
			%flagTeam = GameBase::getTeam(%flag);
			if(%flagTeam == -1){
				if(%flag.flagStand == "" || %flag.flagStand.flag != ""){
					MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");
					%flag.flagStand = "";
				}
				else{
					%holdTeam = GameBase::getTeam(%flag.flagStand);
					TeamMessages(0, %holdTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(GameBase::getTeam(%flag.flagStand)) @ " flag was returned to base.~wflagreturn.wav");
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
					%flag.flagStand.flag = %flag;
					%flag.holdingTeam = %holdTeam;
					%flag.carrier = -1;
					$teamScore[%holdTeam] += %flag.scoreValue;
					$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
					%flag.holder = %flag.flagStand;
					TeamMessages(0,%holdTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
					ObjectiveMission::checkScoreLimit();
				}
			}
			else{
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
}



//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

function Flag::onCollision(%this, %object)
{
	//echo("Flag collision ", %object);
	if(getObjectType(%object) != "Player")
		return;
	// ****
	//echo("object.enterTime = " @ %object.enterTime);
	if(%object.enterTime > getSimTime() - 3)
		return;  
	// ****  
	if(%this.carrier != -1)
		return; // spurious collision
	if(Player::isAIControlled(%object))
		return;   
	// ****

	if(%object.outArea && !$Nappy::Flag::OutOfBounds)
		return;
	%armor = Player::getArmor(%object); 	
	// ****			    
	%name = Item::getItemData(%this);
	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);
	%playerClient = Player::getClient(%object);
	%touchClientName = Nappy::getName(%playerClient);
	if(%flagTeam == %playerTeam){
		// player is touching his own flag...
		// ****
		//echo("in flagteam = playerteam, %armor = " @ %armor);
		if(%armor == flagarmor || %armor == flagfemale){
			if(%object.carryFlag != ""){
				Client::sendMessage(%playerClient, 0, "You cannot score in this armor");
				return;
			}
			playSound(SoundPickupBackpack, GameBase::getPosition(%this));
			MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%flagteam) @ " flag is being moved");
			Client::sendMessage(%playerClient, 0, "You grabbed your flag");
			Player::setItemCount(%object, Flag, 1);
			Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
			Item::hide(%this, true);
			$flagAtHome[1] = false;
			%this.atHome = false; 
			%this.carrier = %object;
			%this.pickupSequence++;
			%object.carryFlag = %this;
			%fstand = %this.flagStand;
			%this.atflagstand = 0;//[][][][]][][][][[][[][][][][][][][][[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]][
			//echo("%fstand " @ %fstand);
			//echo("%fstand.flag " @ %fstand.flag);
			%fstand.carryflag = "";
			%this.flagStand = ""; 
			%object.enterTime = getSimTime(); 
			return;
		}
		// ****
		if(!%this.atHome && %this.flagstand == ""){ // ****
			// the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
			%this.atHome = true;
			// ****
			%playerpos = gamebase::getPosition(%object);	
			if(Vector::getDistance(%this.originalPosition,%playerpos) > 100){
				%playerClient.score += 5; 
				Game::refreshClientScore(%playerClient);
				messageAll(0, Nappy::getName(%playerClient) @ " receives 5 points for returning his flag.");
			}
			// ****
			MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
			Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
			teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
			%this.pickupSequence++;
			ObjectiveMission::ObjectiveChanged(%this);
		}
		else{
			// it's at home - see if we have an enemy flag!
			if(%object.carryFlag != ""){
				// can't cap the neutral flags, duh
				%enemyTeam = GameBase::getTeam(%object.carryFlag);
				if(%enemyTeam != -1){
					MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
					Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
					TeamMessages(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");
					//echo("ADMINMSG: **** " @ %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
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
					$teamScore[%playerTeam] += %flag.scoreValue;
					ObjectiveMission::checkScoreLimit();
					//flag carrier gets 10 points for caputure
					%playerClient.score += 10; // ****
					Game::refreshClientScore(%playerClient);
					messageAll(0, Nappy::getName(%playerClient) @ " receives 10 point capture bonus."); // ****
					Player::incItemCount(%object,flagcaps,1); // ****
				}
			}
		}
	}
	else{
		// it's an enemy's flag! woohoo!
		if(%object.carryFlag == ""){
			if(%this.holdingTeam == %playerTeam)
				return;
			// ****
			%object.enterTime = getSimTime(); 
			%this.atflagstand = 0;//[][][][]][][][][[][[][][][][][][][][[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]][
			%fstand = %this.flagStand;//[][][][][][][[][][][[[
			%fstand.carryflag = "";//][[]][][][][][][][][][][][]
			%this.flagstand = "";
			// ****
			Player::setItemCount(%object, Flag, 1);
			Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
			Item::hide(%this, true);
			$flagAtHome[1] = false;
			%this.atHome = false;
			%this.carrier = %object;
			%this.pickupSequence++;
			%object.carryFlag = %this;
			Flag::setWaypoint(%playerClient, %this);
			if(%this.fadeOut) {
				GameBase::startFadeIn(%this);
				%this.fadeOut= "";
			}
			if((%this.lastTeam == "" || %this.lastTeam != %playerTeam) && %flagTeam == -1) {
				%this.currentFlagStand="";
				%this.changeTeamCount++;
				%this.lastTeam = %playerTeam;
				%this.timerOn = 1;
				if($flagToStandTime >= 30) {
					%timeToStand = $flagToStandTime - 30;
					%timeLeft = 30;
					if($flagToStandTime > 30)
						Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
				}
				else {	
					if($flagToStandTime >= 10)
						%remain = $flagToStandTime % 10;
					else 
						%remain = $flagToStandTime % 5;
					if(%remain > 0 && %remain != $flagToStandTime) {
						%timeToStand = %remain;
						%timeLeft = $flagToStandTime - %remain;
						Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
					}
					else {
						%timeToStand = 0;
						%timeLeft = $flagToStandTime;
					}
				}
				schedule("Flag::checkFlagsTime(" @ %this @"," @ %timeLeft @ "," @ %this.changeTeamCount @ ");",%timeToStand);
			}
			if(%flagTeam != -1){
				MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
				Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
				TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
				//echo("ADMINMSG: **** " @ %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag!");
			}
        		else{
				%hteam = %this.holdingTeam;
				if(%hteam != -1){
					$teamScore[%hteam] -= %this.scoreValue;
					$deltaTeamScore[%hteam] -= %this.deltaTeamScore;
					MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
					Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
					TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
					%this.holdingTeam = -1;
					%this.holder.flag = "";
				}
				else{
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




function Flag::playerLeaveMissionArea(%this, %playerId)
{
//messageall(1,"Leaving so soon?" @ %playerId);
	if(!$Nappy::Flag::OutOfBounds){
		%type = Player::getMountedItem(%playerId, $FlagSlot);
		%clientId = Player::getClient(%playerId);
		if(%type != -1)
			Player::dropItem(%clientId, %type);
	}
}

//		for the flag contact function
			//if(%object.outArea){
				//Nappy::Flag::returnToMissionArea();
			//}







//handles all scoring based on distance to Towers

function Client::leaveGame(%clientId)
{
   //echo("GAME: clientdrop " @ %clientId);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
}




function Game::clientKilled(%playerId, %killerId)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}





function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}





function Player::leaveMissionArea(%this)
{
	%this.outArea=1;
	//Client::sendMessage(Player::getClient(%this),1,"You have left the mission area.");
	alertPlayer(%this, 0);
}
 



  
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		if(%count > 0) {
		  	Client::sendMessage(Player::getClient(%player),0,"~wLeftMissionArea.wav");
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%player);
		}
		else { 
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  			GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
		}
	}
}








//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
function Mission::init()
{
//	setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");

//	setClientScoreHeading("Player Name\t\x55Team\t\x80Game\t\xA6Score\t\xCFPing\t\xEFPL");
	setClientScoreHeading("Player Name\t\x75Team\t\xA0Score\t\xC8Ping\t\xE8PL\t\xFFPit / Team");

//	setTeamScoreHeading("Team Name\t\x70CTF\t\x90Duelers\t\xD6Score");
	setTeamScoreHeading("Team Name\t\x70Players\t\xC0Score");

	$firstTeamLine = 7;
	$firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;

	for(%i = -1; %i < getNumTeams(); %i++){
		$teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
		Team::setObjective(%i, $firstTeamLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
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
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++){
		%obj.objectiveLine = %i + $firstObjectiveLine;
		ObjectiveMission::objectiveChanged(%obj);
	}
	ObjectiveMission::refreshTeamScores();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		%cl.score = 0;
		Game::refreshClientScore(%cl);
	}
	schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
	AI::setupAI();
}


//0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
function Game::refreshClientScore(%clientId)
{
	%game = %clientId.game;
	%pit = %clientId.pit;
	%pitTeam = Client::getTeam(%clientId);
	%team = Client::getTeam(%clientId);
	%name = Nappy::getName(%clientId);
	if(%clientId.game == "Duel"){
		%team = 10;
		%teamName = "Duel";
		Client::setScore(%clientId, %name @ "\t" @ %teamName @ "\t " @ %clientId.score  @ "\t%p\t%l" @ " \t " @ %pit @ "     " @ %pitTeam, %clientId.score + (9 - %team) * 10000);
	}
	else if(%team == -1){ // observers go last.
		%team = 9;
		%teamName = "Observer";
		if(%clientId.nameFX){
			if(%clientId.FXid == "time")
				%name = $Nappy::Time::Stamp;
			else
				%name = $NameFX[%clientId.FXid, %clientId.FX];
			Client::setScore(%clientId, %name @ "\t" @ %teamName @ "\t " @ %clientId.score  @ "\t%p\t%l" @ " \t" @ %pit, %clientId.score + (9 - %team) * 10000);
		}
		else
			Client::setScore(%clientId, %name @ "\t" @ %teamName @ "\t " @ %clientId.score  @ "\t%p\t%l" @ " \t " @ %pit, %clientId.score + (9 - %team) * 10000);
	}
	else{
		Client::setScore(%clientId, %name @ "\t%t\t " @ %clientId.score  @ "\t%p\t%l" @ " \t" @ %pit, %clientId.score + (9 - %team) * 10000);
	}

	// objective mission sorts by team first.

	//Client::setScore(%clientId, "%n\t %t\t " @ %game @ " \t" @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);

	//Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score, %clientId.score);
}




function ObjectiveMission::refreshTeamScores()
{
	if(!$Nappy::CountingPlayers)
		Nappy::PlayerCount();

	%nt = getNumTeams();
	//Team::setScore(-1, "%t\t  0 \t  0 \t  0", 0);
	for(%i = -1; %i < %nt; %i++){
		Team::setScore(%i, "%t\t " @ $team::CTF::Count[%i] @ " \t " @ $teamScore[%i], $teamScore[%i]); 
		for(%j = 0; %j < %nt; %j++) 
			Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j]);
	}
}





function Nappy::PlayerCount()
{
	$Nappy::CountingPlayers = 1;

	%team::CTF::Count[0] = 0;
	%team::Duel::Count[0] = 0;
	%team::CTF::Count[1] = 0;
	%team::Duel::Count[1] = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(Client::getTeam(%cl) == -1){
			if(%cl.game == "Duel"){
				%team::Duel::Count[-1]++;
			}
			else 
				%team::Obs::Count++;
		}
		else if(Client::getTeam(%cl) == 0){
			if(%cl.game == "Duel"){
				%team::Duel::Count[0]++;
			}
			else 
				%team::CTF::Count[0]++;
		}
		else if(Client::getTeam(%cl) == 1){
			if(%cl.game == "Duel"){
				%team::Duel::Count[1]++;
			}
			else
				%team::CTF::Count[1]++;
		}
	}

	$team::CTF::Count[0] = %team::CTF::Count[0];
//	$team::Duel::Count[0] = %team::Duel::Count[0];
	$team::CTF::Count[1] = %team::CTF::Count[1];
//	$team::Duel::Count[1] = %team::Duel::Count[1];

	$team::Duel::Count = %team::Duel::Count[-1] + %team::Duel::Count[0] + %team::Duel::Count[1];
	$team::Observer::Count = %team::Obs::Count;

	schedule("Nappy::PlayerCount();",0.5);
}



function TowerSwitch::onCollision(%this, %object)
{
   //echo("switch collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

   %playerTeam = GameBase::getTeam(%object);
   %oldTeam = GameBase::getTeam(%this);
   if(%oldTeam == %playerTeam)
      return;

   %this.trainingObjectiveComplete = true;
   
   %playerClient = Player::getClient(%object);
   %touchClientName = Nappy::getName(%playerClient);
   %group = GetGroup(%this);
   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);

   %dropPoints = nameToID(%group @ "/DropPoints");
   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);

   $deltaTeamScore[%oldTeam] -= %this.deltaTeamScore;
   $deltaTeamScore[%playerTeam] += %this.deltaTeamScore;
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

   if(%oldTeam == -1)
   {
      MessageAllExcept(%playerClient, 0, %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
      Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
 	}
   else
   {
      if(%this.objectiveLine)
      {
         MessageAllExcept(%playerClient, 0, %touchClientName @ " captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
         Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
			%this.numSwitchTeams++;	
			schedule("TowerSwitch::timeLimitCheckPoints(" @ %this @ "," @ %playerClient @ "," @ %this.numSwitchTeams @ ");",60);
      }
   }
   if(%this.objectiveLine)
   {
      TeamMessages(1, %playerTeam, "Your team has taken an objective.~wCapturedTower.wav");
		TeamMessages(0, %playerTeam, "The " @ getTeamName(%playerTeam) @ " has taken an objective.");
		if(%oldTeam != -1)
	      TeamMessages(1, %oldTeam, "The " @ getTeamName(%playerTeam) @ " team has taken your objective.~wLostTower.wav");
      ObjectiveMission::ObjectiveChanged(%this);
   }
   ObjectiveMission::checkScoreLimit();
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
      //echo(%dist);
      if(%dist <= 80)
      {
         //echo("distance to objective" @ %this @ " : " @ %dist);
         if(GameBase::getTeam(%this) == Client::getTeam(%killerId) && getObjectType(%killerId) == "Player")
         {
            %killerId.score++;
            Game::refreshClientScore(%killerId);
            messageAll(0, strcat(Nappy::getName(%killerId), " receives a bonus for defending " @ %this.objectiveName @ "."));
         }
      }
   }
}



function Flag::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   //echo("Flag objectiveString");
   
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
         	      return "<Bflag_atbase.bmp>\nConvey " @ %this.objectiveName @ " to an empty flag stand. (carried by " @ Nappy::getName(Player::getClient(%this.carrier)) @ ")";
         	   else
         	      return "<Bflag_enemycaptured.bmp>\nWaylay " @ Nappy::getName(Player::getClient(%this.carrier)) @ " and convey " @ %this.objectiveName @ " to your base.";
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
        	      return "<Bflag_atbase.bmp>\n" @ Nappy::getName(Player::getClient(%this.carrier)) @ " has " @ %this.objectiveName @ ".";
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
               return "<Bflag_enemycaptured.bmp>\nReturn your flag to base. (carried by " @ Nappy::getName(Player::getClient(%this.carrier)) @ ")";
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
            	   return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Nappy::getName(Player::getClient(%this.carrier)) @ " to base.";
            	else
            	   return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Nappy::getName(Player::getClient(%this.carrier)) @ " and steal his flag.";
         	}
				else {
            	if(%this.atHome)
            	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field.";
            	else 
            	   return "<Bflag_atbase.bmp>\n" @ Nappy::getName(Player::getClient(%this.carrier)) @ " has the " @ getTeamName(%thisTeam) @ " flag.";
				}
			}         
      }
   }
}




function Flag::onDrop(%player, %type)
{
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Nappy::getName(%playerClient);

   if(%flagTeam == -1)
   {
      MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
      Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
   }
   else
   {
      MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
      Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
      TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
   }
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);

   schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
   ObjectiveMission::ObjectiveChanged(%flag);
}



function Flag::checkFlagsTime(%flag,%timeleft,%changeCount)
{
	if(%flag.changeTeamCount == %changeCount)
	{
		%client = Player::getClient(%flag.carrier);
		if(%timeleft <= 0 && %flag.currentFlagStand == "") { 
			GameBase::startFadeOut(%flag);
      	Player::setItemCount(%flag.carrier, "Flag", 0);
	 		%clientName = Nappy::getName(%client);
   		%flagTeam = GameBase::getTeam(%flag);
  	   	if(%flagTeam == -1 && (%flag.flagStand == "" || (%flag.flagStand).flag != "") ) 
   		{
      		if(%client != -1) {
      			MessageAllExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!  It was returned to its initial position.");
      			Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!  It was returned to its initial position.");
				}
				else
      			MessageAll(0, %flag.objectiveName @ " was not put in a flag stand in time!  It was returned to its initial position.");
				GameBase::setPosition(%flag, %flag.originalPosition);
      	   Item::setVelocity(%flag, "0 0 0");
				%flag.flagStand = "";
   		}
   		else
   		{
				if(%flagTeam != -1) {
					%team = %flagTeam;
					GameBase::setPosition(%flag, %flag.originalPosition);
      	      Item::setVelocity(%flag, "0 0 0");
				}
				else {
					%team = GameBase::getTeam(%flag.flagStand);
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
      	      Item::setVelocity(%flag, "0 0 0");
				}
				if(%client != -1) {
      			MessageAllExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!");
      			Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!");
      		}
      		else
      			MessageAll(0, %flag.objectiveName @ " was not put in a flag stand in time!");
      		TeamMessages(1, %team, %flag.objectiveName @ " was returned to your base.~wflagreturn.wav", -2, "", %flag.objectiveName @ " was returned to the " @ getTeamName(%team) @ " base.");
	   	   %holdTeam = GameBase::getTeam(%flag.flagStand);
	   		$teamScore[%holdTeam] += %flag.scoreValue;
	   		$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
				%flag.holder = %flag.flagStand;
   			%flag.flagStand.flag = %flag;
				%flag.holdingTeam = %holdTeam;
			}
			GameBase::startFadeIn(%flag);
			Item::hide(%flag, false);

			(%flag.carrier).carryFlag = "";
      	%flag.carrier = -1;
        	Flag::clearWaypoint(%client, false);
      	ObjectiveMission::ObjectiveChanged(%flag);
			ObjectiveMission::checkScoreLimit();





			%flag.lastTeam = "";
		}
		else if(%flag.currentFlagStand == "") {
			Client::sendMessage(%client, 0, "You have " @ %timeleft @ " sec to put the flag in a stand.");
			if(%timeleft <= 5) {
				%timeleft--;
				%nextTime = 1;
			}
			else if(%timeleft == 10) { 
				%timeleft -= 5;
				%nextTime = 5;
			}
			else {
				%timeleft -= 10;
				%nextTime = 10;
			}
	      schedule("Flag::checkFlagsTime(" @ %flag @","@ %timeleft @"," @ %changeCount @ ");",%nextTime);
		}
	}
}







function FlagStand::onCollision(%this, %object)
{
   //echo("FlagStand collision ", %object);
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);

   if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == ""
         || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
      return;

   // if we're here, we're carrying a flag, we've hit 
   // our flag stand, it doesn't have a flag, and we're not carrying
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
	%flag.currentFlagStand = %this;

   MessageAllExcept(%playerClient, 0, Nappy::getName(%playerClient) @ " conveyed " @ %flag.objectiveName @ " to base.");
   Client::sendMessage(%playerClient, 0, "You conveyed " @ %flag.objectiveName @ " to base.");
   TeamMessages(1, %playerTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");

   %flag.trainingObjectiveComplete = true;
   ObjectiveMission::ObjectiveChanged(%flag);
   ObjectiveMission::checkScoreLimit();
}

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
      return;

   // killer's the only guy who gets a bonus.
   if(%killerTeam == %flagTeam)
   {
      // check for defending the flag
      // only if the flag is not being carried
      if(%this.carrier == -1)
      {
         %flagPos = GameBase::getPosition(%this);
         %playerPos = GameBase::getPosition(%player);

         if(Vector::getDistance(%flagPos, %playerPos) < 80)
         {
            %killerId.score++;
            Game::refreshClientScore(%killerId);
            messageAll(0, Nappy::getName(%killerId) @ " gets a bonus for defending the flag!");
         }
      }
   }
   else
   {
      if(%this.carrier != -1)
      {
         %carrierTeam = GameBase::getTeam(%this.carrier);
         // check for defending the carrier bonus
         if(%carrierTeam == %killerTeam)
         {
            if(Vector::getDistance(GameBase::getPosition(%this.carrier),
               GameBase::getPosition(%killer)) < 80)
            {
               %killerId.score++;
               Game::refreshClientScore(%killerId);
               messageAll(0, Nappy::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
            }               
         }
      }
   }
}





function StaticShape::objectiveDestroyed(%this)
{
	if($testMissionType == "CTF") {
		if(%this.destroyed == "") { 
			if(getObjectType(%this) == "Turret"){
				%destroyerTeam = GameBase::getTeam(%this.lastDamageObject);
				%thisTeam = GameBase::getTeam(%this);
				%playerClient = GameBase::getControlClient(%this.lastDamageObject);
				if(%thisTeam == %destroyerTeam){
					Client::sendMessage(%playerClient, 0, "You destroyed one of your team's turrets!");
				}
				else{
					%playerClient.score+=1;
					Game::refreshClientScore(%playerClient);
					Client::sendMessage(%playerClient, 0, "You get 1 point for destroying an enemy turret!");
				}
			}
		}
	}
	if (GameBase::getDataName(%this) == Generator){
		%destroyerTeam = GameBase::getTeam(%this.lastDamageObject);
		%thisTeam = GameBase::getTeam(%this);
		%playerClient = GameBase::getControlClient(%this.lastDamageObject);
		if(%thisTeam == %destroyerTeam){
			Client::sendMessage(%playerClient, 0, "You destroyed one of your team's generators!");
			%playerClient.score-=2;
			Game::refreshClientScore(%playerClient);
			Client::sendMessage(%playerClient, 0, "You lose 2 points for destroying your generator!");
		}
		else{
			%playerClient.score+=2;
			Game::refreshClientScore(%playerClient);
			Client::sendMessage(%playerClient, 0, "You get 2 points for destroying an enemy generator!");
		}

	}
	else{
		if(%this.destroyed == "") {
			// test if it's really an objective
			if(!%this.objectiveLine)
				return;
			%destroyerTeam = %this.lastDamageTeam;
			%thisTeam = GameBase::getTeam(%this);
			%playerClient = GameBase::getControlClient(%this.lastDamageObject);
			if(%playerClient != -1)
				%clientName = Nappy::getName(%playerClient);
			if(%thisTeam == %destroyerTeam){
				// uh-oh... we killed our own stuff.
				// award the points to everyone else
				for(%i = 0; %i < getNumTeams(); %i++){
					if(%i == %thisTeam)
						continue;
					$teamScore[%i] += %this.scoreValue;
				}
				if(%playerClient != -1){
					MessageAllExcept(%playerClient, 0, %clientName @ " destroyed a friendly objective.");
					Client::sendMessage(%playerClient, 0, "You destroyed a friendly objective!");
				}
				MessageAll(1, getTeamName(%destroyerTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
			}
			else{
				$teamScore[%destroyerTeam] += %this.scoreValue;
				if(%playerClient != -1){
					%playerClient.score+=5;
					Game::refreshClientScore(%playerClient);
					MessageAllExcept(%playerClient, 0, %clientName @ " destroyed an objective!");
					Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
				}
				MessageAll(1, getTeamName(%thisTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
			}
			%this.destroyerTeam = %destroyerTeam;
			ObjectiveMission::ObjectiveChanged(%this);
			ObjectiveMission::checkScoreLimit();
			%this.destroyed = 1;
		}
	}
}








