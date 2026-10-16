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
    for(%i = 0; %i < getNumTeams(); %i++)
    {
        Team::setObjective(%i, $firstObjectiveLine-4, " ");
        Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
        Team::setObjective(%i, $firstObjectiveLine-2, " ");
	}
    ObjectiveMission::setObjectiveHeading();
    ObjectiveMission::refreshTeamScores();
    %lineNum = "";
    $missionComplete = false;
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
            if($teamScore[%i] == $teamScore[%curLeader])
            {
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
        if(%tieGame)
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
        for(%i = -1; %i < getNumTeams(); %i++)
        {
            objective::displayBitmap(%i,0);
            if(!%tieGame)
            {
                if(%i == %curLeader)
                {
                    if($teamScore[%curLeader] == 1)
                        Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
                    else
                        Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
                }
                else
                {
                    if($teamScore[%curLeader] == 1)
                        Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
                    else
                        Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
                }
            }
            else
            {
                if(getNumTeams() > 2)
                {
                    Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
                }
                else
                    Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
            }
            Team::setObjective(%i, 2, " ");
        }
    }
    else
    {
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
    for(%i = -1; %i < getNumTeams(); %i++)
    {
        Team::setObjective(%i, 3, " ");
        Team::setObjective(%i, 4, "<f5>Mission Information:");
        Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName);
        Team::setObjective(%i, 6, %str);
    }
}
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
    if(%bitmap1 == "" || %bitmap2 == "")
        Team::setObjective(%team, %line, " ");
    else
        Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap1 @ "><B0,0:" @ %bitmap2 @ ">");
}
function Game::checkTimeLimit()
{
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
        %set
        = nameToID("MissionCleanup/ObjectiveSet");
        for(%i = 0; (%obj = Group::getObject(%set
                                             , %i)) != -1; %i++) GameBase::virtual(%obj, "timeLimitReached", %clientId);
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
        if(%name == Flag)
        {
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
function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -2) // observers go last.
      %team = 9;
   if(%clientId.observerMode)
      %teamName = "OBS";
   if (%clientId.isUntouchable)// Menu admin by: Zed
       %admin = "U";
   else if (%clientId.isGod)
       %admin = "G";
   else if (%clientId.isSuperAdmin)
		%admin = "S";
	else if (%clientId.isAdmin)
		%admin = "A";
	else
		%admin = " ";

   // objective mission sorts by team first.
  // Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l\t" @ %clientId.cash, %clientId.score + (9 - %team) * 10000);
   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l\t"@ %admin @ "\t" @ %clientId.cash,%clientId.score + (9 - %team) * 10000);
}
function ObjectiveMission::refreshTeamScores()
{
        $teamplayers0 =0;
        $teamplayers1 =0;
        $teamplayers2 =0;
	%teamping0 =0;
	%teamping1 =0;
    %teamping2 =0;
	for (%cl = Client::getfirst(); %cl != -1; %cl = Client::getnext(%cl))
		{
		%x =client::getteam(%cl);
                if (%x==-1)
			{
                        $teamplayers0++;
                        %teamping0 += %cl.ping;
			}
		if (%x==0)
			{
                        $teamplayers1++;
                        %teamping1 += %cl.ping;
			}
		if (%x==1)
			{
                        $teamplayers2++;
                        %teamping2 += %cl.ping;
			}
		  	
		}

	if ($teamplayers0 !=0)
		%teamping0 = %teamping0 / $teamplayers0;
	else
		%teamping0 =0;
	if ($teamplayers1 !=0)
		%teamping1 = %teamping1 / $teamplayers1;
	else
		%teamping1 =0;
	if ($teamplayers1 !=0)
                %teamping2 = %teamping2 / $teamplayers2;
	else
                %teamping2 =0;
	%nt = getNumTeams();
	Team::setScore(-1, "%t\t\t  0", 0);

	if ($fstat::trueping)
		{
                for (%i =-1; %i < %nt; %i++)
			{

                        Team::setScore(%i, "%t\t" @ "   " @ $teamplayers[%i+1] @ "\t " @ %teamping[%i] @ "\t  " @ $teamScore[%i], $teamScore[%i]);
			setTeamScoreHeading("Team Name\t\x6fPlayers\t\xafPing\t\xD6Score");

			for (%j = 0; %j < %nt; %j++)
				Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j]);
			}
		}


	else
		{
		for (%i = -1; %i < %nt; %i++)
			{
                        Team::setScore(%i, "%t\t" @ "   " @ $teamplayers[%i+1] @ "\t " @ $teamScore[%i], $teamScore[%i]);
			setTeamScoreHeading("Team Name\t\x6fPlayers\t\xD6Score");

			for (%j = 0; %j < %nt; %j++)
				Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j]);
			}

		}
	
}
function ObjectiveMission::objectiveChanged(%this)
{
    if(%this.objectiveLine)
        for(%i = -1; %i < getNumTeams(); %i++)
            Team::setObjective(%i,%this.objectiveLine, "<f1> " @ GameBase::virtual(%this, getObjectiveString, %i));
}
function Mission::init()
{
	//setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL\t\xFFCash");
    setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL\t\xFFStatus");
	setTeamScoreHeading("Team Name\t\x6fPlayers\t\xD6Score");//added player count to menu Zed
    $firstTeamLine = 7;
    $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
    for(%i = -1; %i < getNumTeams(); %i++)
    {
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
    for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
    {
        %obj.objectiveLine = %i + $firstObjectiveLine;
        ObjectiveMission::objectiveChanged(%obj);
    }
    ObjectiveMission::refreshTeamScores();
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    {
        %cl.score = 0;
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

function Game::pickRandomSpawn(%team)
{
    %spawnSet = nameToID("MissionCleanup/TeamDrops" @ %team);
    %spawnCount = Group::objectCount(%spawnSet);
    if(!%spawnCount)
        return -1;
    %spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
    %value = %spawnCount;
    for(%i = %spawnIdx; %i < %value; %i++)
    {
        %set
        = newObject("set",SimSet);
        %obj = Group::getObject(%spawnSet, %i);
        if(containerBoxFillSet(%set
                               ,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
        {
            deleteObject(%set
                        );
            return %obj;
        }
        if(%i == %spawnCount - 1)
        {
            %i = -1;
            %value = %spawnIdx;
        }
        deleteObject(%set
                    );
    }
    return false;
}
function Client::leaveGame(%clientId)
{
    echo("GAME: clientdrop " @ %clientId);
    %set
    = nameToID("MissionCleanup/ObjectivesSet");
    for(%i = 0; (%obj = Group::getObject(%set
                                         , %i)) != -1; %i++) GameBase::virtual(%obj, "clientDropped", %clientId);
}
function Game::clientKilled(%playerId, %killerId)
{
    %set
    = nameToID("MissionCleanup/ObjectivesSet");
    for(%i = 0; (%obj = Group::getObject(%set
                                         , %i)) != -1; %i++) GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}
function Player::enterMissionArea(%this)
{
    %set
    = nameToID("MissionCleanup/ObjectivesSet");
    %this.outArea = "";
    for(%i = 0; (%obj = Group::getObject(%set
                                         , %i)) != -1; %i++) GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}
function Player::leaveMissionArea(%this)
{
    %this.outArea=1;
    Client::sendMessage(Player::getClient(%this),1,"You have left the mission area.");
    %location = GameBase::getPosition(Player::getClient(%this));
    alertPlayer(%this, 3, %location);
}
function alertPlayer(%player, %count, %location)
{
    if(%player.outArea == 1)
    {
        if(%count > 0)
        {
            Client::sendMessage(Player::getClient(%player),0,"~wLeftMissionArea.wav");
            schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ", \"" @ %location @ "\");",1.5,%player);
        }
        else
        {
            %set
            = nameToID("MissionCleanup/ObjectivesSet");
            for(%i = 0; (%obj = Group::getObject(%set
                                                 , %i)) != -1; %i++) GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
            if (!$Server::TourneyMode && $Reneg::OutOfAreaDamage)
                schedule("OutOfArea(" @ %player @ ", " @ 12 @ ", \"" @ %location @ "\");",1.5,%player);
        }
    }
}
function OutOfArea(%player, %time, %location)
{
    if(%player.outArea == true)
    {
        if (!Player::isDead(%player))
        {
            Player::setDamageFlash(%player, 0.75);
            %amr = Player::getArmor(Player::getClient(%player));
            if(%amr == "darmor" || %amr == "harmor")
            {
                if(%player.shieldStrength > 0)
                    %amount = 0.6;
                else
                    %amount = 0.3;
                GameBase::applyDamage(%player,$FlashDamageType,%amount,GameBase::getPosition(%player),"0 0 0","0 0 0",Player::getClient(%player));
            }
            else
            {
                if(%player.shieldStrength > 0)
                    %amount = 0.55;
                else
                    %amount = 0.08;
                GameBase::applyDamage(%player,$FlashDamageType,%amount,GameBase::getPosition(%player),"0 0 0","0 0 0",Player::getClient(%player));
            }
            if(%time > 0)
                schedule("OutOfArea(" @ %player @ ", " @ %time -1 @ ", \"" @ %location @ "\");",3,%player);
            else
            {
                %client = Player::getClient(%player);
                if(Player::getMountObject(%client) != -1 || Client::getControlObject(%client) != Client::getOwnedObject(%client))
                {
                    if(Player::getMountObject(%client) != -1)
                    {
                        Player::setMountObject(Client::getOwnedObject(%client), -1, 0);
                        Client::setControlObject(%client, Client::getOwnedObject(%client));
                    }
                    else
                        checkControlUnmount(%client);
                }
                Client::sendMessage(%client,1,"You are being transported back to the mission area~waccess_denied.wav");
                GameBase::setPosition(%client, %location);
                alertPlayer(%player, 3, %location);
            }
        }
    }
}
function checkObjectives(%this)
{ }
function TowerSwitch::objectiveInit(%this)
{
    return %this.scoreValue || %this.deltaTeamScore;
}
function TowerSwitch::onAdd(%this)
{
    %this.numSwitchTeams = 0;
}
function TowerSwitch::onDamage()
{ }
function TowerSwitch::getObjectiveString(%this, %forTeam)
{
    %thisTeam = GameBase::getTeam(%this);
    if($missionComplete)
    {
        if(%thisTeam == -1)
            return "<Btowers_neutral.bmp>\nNo team claimed " @ %this.objectiveName @ ".";
        else if(%thisTeam == %forTeam)
            return "<Btower_teamcontrol.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
        else
        {
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
        else
        {
            if(%thisTeam == -1)
                return "<Btowers_neutral.bmp>\n" @ %this.objectiveName @ " has not been claimed.";
            else
                return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team is in control of the " @ %this.objectiveName @ ".";
        }
    }
}
function TowerSwitch::onCollision(%this, %object)
{
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
    %touchClientName = Client::getName(%playerClient);
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
function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{
    if(%this.numSwitchTeams == %numChange)
    {
        %client.score+=5;
        Game::refreshClientScore(%client);
        if($StatTrack)
            echo ("GAME: ", %client, " heldtower");
        Client::sendMessage(%client, 0, "You receive 5 points for holding your captured tower!");
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
        if(%dist <= 80)
        {
            if(GameBase::getTeam(%this) == Client::getTeam(%killerId) && getObjectType(%killerId) == "Player")
            {
                %killerId.score++;
                Game::refreshClientScore(%killerId);
                messageAll(0, strcat(Client::getName(%killerId), " receives a bonus for defending " @ %this.objectiveName @ "."));
            }
        }
    }
}
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
    if($missionComplete)
    {
        if(%thisTeam == -1)
        {
            if(%this.holdingTeam == %forTeam && %forTeam != -1)
                return "<Bflag_atbase.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
            else if(%this.holdingTeam == -1)
                return "<Bflag_neutral.bmp>\nNo team finished the mission in control of " @ %this.objectiveName @ ".";
            else
            {
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
            if(%forTeam != -1)
            {
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
            else
            {
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
                if(%forTeam != -1)
                {
                    if(%this.atHome)
                        return "<Bflag_enemycaptured.bmp>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
                    else if(%this.carrier == -1)
                        return "<Bflag_notatbase.bmp>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
                    else if(GameBase::getTeam(%this.carrier) == %forTeam)
                        return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " to base.";
                    else
                        return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " and steal his flag.";
                }
                else
                {
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
function Flag::onDrop(%player, %type)
{
    %playerTeam = GameBase::getTeam(%player);
    %flag = %player.carryFlag;
    %flagTeam = GameBase::getTeam(%flag);
    %playerClient = Player::getClient(%player);
    %dropClientName = Client::getName(%playerClient);
    if(%flagTeam == -1)
    {
        MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
        Client::sendMessage(%playerClient, 1, "You dropped " @ %flag.objectiveName @ "!");
    }
    else
    {
        MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
        Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
        if($StatTrack)
            echo ("GAME: ", %playerClient, " flagdrop");
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
function Flag::checkReturn(%flag, %sequenceNum)
{
    if(%flag.pickupSequence == %sequenceNum)
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
            %flagTeam = GameBase::getTeam(%flag);
            if(%flagTeam == -1)
            {
                if(%flag.flagStand == "" || %flag.flagStand.flag != "")
                {
                    MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
                    GameBase::setPosition(%flag, %flag.originalPosition);
                    Item::setVelocity(%flag, "0 0 0");
                    %flag.flagStand = "";
                }
                else
                {
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
function Flag::onCollision(%this, %object)
{
    if(getObjectType(%object) != "Player")
        return;
    if(%this.carrier != -1)
        return;
    if(Player::isAIControlled(%object))
        return;
    %name = Item::getItemData(%this);
    %playerTeam = GameBase::getTeam(%object);
    %flagTeam = GameBase::getTeam(%this);
    %playerClient = Player::getClient(%object);
    %touchClientName = Client::getName(%playerClient);
    if(%flagTeam == %playerTeam)
    {
        if(!%this.atHome)
        {
            GameBase::startFadeOut(%this);
            GameBase::setPosition(%this, %this.originalPosition);
            Item::setVelocity(%this, "0 0 0");
            GameBase::startFadeIn(%this);
            %this.atHome = true;
            MessageAllExcept(%playerClient, 0, %touchClientName @ " Was awarded 2 points for Returning the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
            Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag and were awarded 2 points!~wflagreturn.wav");
            %playerClient.score += 2;
            Game::refreshClientScore(%playerClient);
            if($StatTrack)
                echo ("GAME: ", %playerClient, " flagreturn");
            teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
            %this.pickupSequence++;
            ObjectiveMission::ObjectiveChanged(%this);
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
                    TeamMessages(1, %playerTeam, "Your team captured the flag.", %flagTeam, "Your team's flag was captured.");
                    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
						if(%cl != %playerClient)
							bottomprint(%cl, "        <B0,4:flag_enemycaptured.bmp>\n<jc>" @ %touchClientName @ " has captured the " @ getTeamName(%enemyTeam) @ " flag!",5);
					bottomprint(%playerClient, "        <B0,4:flag_atbase.bmp>\n <jc>You have captured the " @ getTeamName(%enemyTeam) @ " flag!",5);
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
					//Cash Economy Stuff
					if($Reneg::Cash == "true")
						%playerClient.cash += 50;
                    $teamScore[%playerTeam] += %flag.scoreValue;
                    ObjectiveMission::checkScoreLimit();
                    %playerClient.score += 5;
                    Game::refreshClientScore(%playerClient);
					schedule("ScorePlayer(5,"@%playerClient@",1);",5);
                    if($StatTrack)
                        echo ("GAME: ", %playerClient, " flagcapture");
                    messageAll(0, Client::getName(%playerClient) @ " receives 5 point capture bonus.");
                }
            }
        }
    }
    else
    {
        if(%object.driver)
            return;
        if(%playerClient.isSpy)
            return;
        if(getNumClients() < 3 && !%playerClient.isSuperAdmin)
        {
            if(getNumClients() < 2)
            {
                centerprintall("<jc><f2>You can't capture an undefended flag\n\nHave you noticed that you're all alone?", 2);
                return;
            }
            else
            {
                %pl = Client::getFirst();
                %plb = Client::getNext(%pl);
                if(%pl.observerMode != "" || %plb.observerMode != "" || GameBase::getTeam(%pl) == GameBase::getTeam(%plb))
                {
                    centerprintall("<jc><f2>A player on each team\nis required to capture the flag", 3);
                    return;
                }
            }
        }
        if(%object.carryFlag == "")
        {
            if(%object.outArea == "")
            {
                if(%this.holdingTeam == %playerTeam)
                    return;
                Player::setItemCount(%object, Flag, 1);
                Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
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
                    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					{
						if(gamebase::getTeam(%cl) == %flagteam)
							bottomprint(%cl, "        <B0,4:flag_enemycaptured.bmp>\n<jc> Your teams flag has been taken!",5);
						else
							bottomprint(%cl, "        <B0,4:flag_atbase.bmp>\n <jc> Your teams has the enemy flag!",5);
					}
					if($StatTrack)
                        echo ("GAME: ", %playerClient, " flaggrab");
                    TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
                }
                else
                {
                    %hteam = %this.holdingTeam;
                    if(%hteam != -1)
                    {
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
            else
                Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
        }
    }
}
function ScorePlayer(%score,%playerClient,%reason)
{
	if(%reason == 1)
		bottomprint(%playerClient, "<jc><f1> You recieve <f2>" @ %score @"<f1> points for <f2>Capturing the Enemy Flag. \n <f1>Your total score = " @ %playerClient.score,5);
	else if(%reason == 2)
		bottomprint(%playerClient, "<jc><f1> You recieve <f2>" @ %score @"<f1> points for <f2>Defending the Flag. \n <f1>Your total score = " @ %playerClient.score,5);
	else if(%reason == 3)
		bottomprint(%playerClient, "<jc><f1> You recieve <f2>" @ %score @"<f1> points for <f2>Defending the Flag Carrier. \n <f1>Your total score = " @ %playerClient.score,5);
}
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
            if(%s.flag == "")
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
function FlagStand::onCollision(%this, %object)
{
    %standTeam = GameBase::getTeam(%this);
    %playerTeam = GameBase::getTeam(%object);
    if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == "" || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
        return;
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
            messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag!");
			if($Reneg::Cash == "true")
					%killerId.cash += 20;
			schedule("ScorePlayer(1," @ %killerId @ ",2);",5);
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
               messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
			   if($Reneg::Cash == "true")
					%killerId.cash += 20;
				schedule("ScorePlayer(1," @ %killerId @ ",3);",5);
            }               
         }
      }
   }
}
function Flag::clientDropped(%this, %clientId)
{
    %type = Player::getMountedItem(%clientId, $FlagSlot);
    if(%type != -1)
        Player::dropItem(%clientId, %type);
}
function Flag::playerLeaveMissionArea(%this, %playerId)
{
    if(%this.carrier == %playerId)
    {
        GameBase::startFadeOut(%this);
        Player::setItemCount(%playerId, "Flag", 0);
        %playerClient = Player::getClient(%playerId);
        %clientName = Client::getName(%playerClient);
        %flagTeam = GameBase::getTeam(%this);
        if(%flagTeam == -1 && (%this.flagStand == "" || (%this.flagStand).flag != "") )
        {
            MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
            Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
            GameBase::setPosition(%this, %this.originalPosition);
            Item::setVelocity(%this, "0 0 0");
            %this.flagStand = "";
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
            %holdTeam = GameBase::getTeam(%this.flagStand);
            $teamScore[%holdTeam] += %this.scoreValue;
            $deltaTeamScore[%holdTeam] += %this.deltaTeamScore;
            %this.holder = %this.flagStand;
            %this.flagStand.flag = %this;
            %this.holdingTeam = %holdTeam;
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
function StaticShape::timeLimitReached(%this)
{
    if(%this.scoreValue && !%this.destroyerTeam)
    {
        $teamScore[GameBase::getTeam(%this)] += %this.scoreValue;
    }
}
function StaticShape::objectiveDestroyed(%this)
{
    if($StatTrack)
    {
        %playerClient = GameBase::getControlClient(%this.lastDamageObject);
        %name= GameBase::getDataName(%this);
        echo("GAME: ",%playerclient," Destroyed ", %name.className);
    }
    if(%this.destroyed == "")
    {
        if(!%this.objectiveLine)
            return;
        %destroyerTeam = %this.lastDamageTeam;
        %thisTeam = GameBase::getTeam(%this);
        %playerClient = GameBase::getControlClient(%this.lastDamageObject);
        if(%playerClient != -1)
            %clientName = Client::getName(%playerClient);
        if(%thisTeam == %destroyerTeam)
        {
            for(%i = 0; %i < getNumTeams(); %i++)
            {
                if(%i == %thisTeam)
                    continue;
                $teamScore[%i] += %this.scoreValue;
            }
            if(%playerClient != -1)
            {
                MessageAllExcept(%playerClient, 0, %clientName @ " destroyed a friendly objective.");
                Client::sendMessage(%playerClient, 0, "You destroyed a friendly objective!");
            }
            MessageAll(1, getTeamName(%destroyerTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
        }
        else
        {
            $teamScore[%destroyerTeam] += %this.scoreValue;
            if(%playerClient != -1)
            {
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
function StaticShape::objectiveDisabled(%this)
{ }
