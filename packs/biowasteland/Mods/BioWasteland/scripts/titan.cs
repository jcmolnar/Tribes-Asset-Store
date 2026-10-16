exec("objectives.cs");
schedule("$Game::missionType=\"Titan\";", 10);
schedule("$TestMissionType=\"Titan\";", 10);

function ObjectiveMission::setObjectiveHeading()
{
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
		%tieTeams[%tie] = %curLeader;

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
				%tieTeams[%tie] = %curLeader;
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

		//======================================================= Team Scores
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			if(!%tieGame)
			{

				//===penalize loosing team player's score
				for(%k= 0 ; %k < %numClients; %k++)
				{
					%clientList[%k] = getClientByIndex(%k);
					%team = GameBase::getTeam(%clientList[%k]);
					if (GameBase::getTeam(%clientList[%k]) != %curLeader) %clientList[%k].score = floor(%clientList[%k].score - 300);
				}
				//======done with penalty

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
	//=== Players Ratio & Scores

	%numClients = getNumClients();
	%numCl = ((2049 + %numClients) + 20);

	for(%k= 0 ; %k < %numClients; %k++)
	{
		%clientList[%k] = getClientByIndex(%k);
		if (%i == (GameBase::getTeam(%clientList[%k])))
			%totalteamscore[GameBase::getTeam(%clientList[%k])] = %totalteamscore[GameBase::getTeam(%clientList[%k])] + (%clientList[%k]).score;
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
		%lineNum = $firstObjectiveLine;

		if(!$missionComplete)
		{
			Team::setObjective(%i, %lineNum, " ");
			Team::setObjective(%i, %lineNum++, "<f5>Objectives:");
			Team::setObjective(%i, %lineNum++, "<f1> <BRD_Check_DF.bmp> March your Titan to the Enemy's Titan Switch.");
			Team::setObjective(%i, %lineNum++, "<f1> <Btower_teamcontrol.bmp> Prevent your Enemy's Titan from reaching your Switch.");
	 		Team::setObjective(%i, %lineNum++, " ");
		}
		// header
	 	Team::setObjective(%i, %lineNum -1, " ");
		Team::setObjective(%i, %lineNum, "<f5>Players:<f0><L57>Score<L66>Kills<L73>Deaths<L84>Ratio<L92>TKs<L99>Caps");
		//========== Print Client Scores for every team's objective screen
		%index = 0;
		%c = 0;
		while(%index < %numClients)
		{
			%client = getClientByIndex(%count);
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
			Team::setObjective(%i, %lineNum++, "<L4>#" @ (%c + 1) @ "<L12>" @ Client::getName(%clientList[%c]) @ "<L57>" @ %FontScore @ (%clientList[%c]).score @ "<L66>" @ %FontScoreKills @ (%clientList[%c]).ScoreKills @ "<L73>" @  %FontScoreDeaths @ (%clientList[%c]).ScoreDeaths @ "<L84>" @  %FontRatio @ (%clientList[%c]).ratio @ "<L92>" @  %FontTKCount @ (%clientList[%c]).TKCount @ "<L99>" @ %FontFlagCaps @ (%clientList[%c]).FlagCaps);

			%lastRatio = (%clientList[%index]).score;
			%index++;
			%c++;
		}
		for(%s = %lineNum+1; %s < 30 ;%s++) Team::setObjective(%i, %s, " ");
	}
}

//================== Display Team Bit Maps
function objective::displayBitmap(%team, %line)
{
	Team::setObjective(%team, %line, "<f9><jc><BRD_Check_DF.bmp>           TITAN      CHALLENGE");
}

function ObjectiveMission::initCheck(%object)
{
	$TestMissionType = "TIT";
	%object.trainingObjectiveComplete = "";
	%object.objectiveLine = "";
	if(GameBase::virtual(%object, objectiveInit))
		addToSet("MissionCleanup/ObjectivesSet", %object);
}

function Game::playerSetSpawned(%pl, %clientId, %armor)
{
	//============= Buy Actual Items

	%clientId.spawn = 1;
	%max = getNumItems();

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon)
			%clientId.spawnWeapon = %item;
	}
	for (%i = 0; %i < 6; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}
	buyItem(%clientId,"TargetingLaser");
	buyItem(%clientId,"RepairKit");
	%clientId.spawn = "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);
		%armor = Player::getArmor(%clientId);

		if (%armor == "jarmor") //============== Check Juggernaught
		{
			Player::mountItem(%clientId, Mortar, $WeaponSlot);
		}
		%clientId.spawnWeapon="";
	}

	if ($Wasteland::PublicNotice != "")
	{
		%clientId.spawnnum++;
		if (%clientId.spawnnum > 1)
		{
			bottomprint (%clientId, "<jc>" @ $Wasteland::PublicNotice @ "",4);
			%clientId.spawnnum = 0;
		}
	}
	%playerTeam = Client::getTeam(%clientId);
	if ($TeamTitan[%playerTeam] == "")
	{
		$TeamTitan[%playerTeam] = %pl;
		systemMessage(%clientId,3,"You become your team's Titan!~wflyer_mount.wav");
		playSound(SoundFlagReturned,gamebase::getposition(%pl));
		centerprint(%clientId, "                   <Btower_enemycontrol.bmp> Attack the Enemy's Titan Switch! <Btower_enemycontrol.bmp>");
		Player::setArmor(%clientId, tarmor);
		%item = Player::getMountedItem(%pl,$BackpackSlot);
		Player::dropItem(%clientId,%item);
		Player::mountItem(%clientId, TitanPack, $BackpackSlot);
		TeamMessages(3, %playerTeam, Client::getName(%clientId) @ " has become your team's Titan!");
	}
      return true;
}

function Player::onKilled(%this)
{
	echo("*** Player Killed ***");
	%this.Station = "";

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	%cl.heatlock = "0";
	%cl.plasmacharge = "0";
	%cl.charging = "0";
	%cl.lascharge = "0";
	%cl.boosted = 0;
	$StimTime[%cl] = "0";
	%cl.ovd = 0;

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);

	if(%this.outArea==1)
		leaveMissionAreaDamage(%cl);

	Player::setDamageFlash(%this,0.75);

	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.6")
				Player::dropItem(%this,%type);
		}
	}

   	if(%cl != -1)
   	{
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 		Client::setControlObject(Player::getClient(%this), %this);
        	 		Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}

		%kdpos = GameBase::getPosition(%this);
		%this.TKDeathPos = %kdpos;

		%cl.lastkillpos = %kdpos;
		$killedarmor = Player::getArmor(%this);
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
  	}
	%armor = Player::getArmor(%this);
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","CloakBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%this), %padd);
		GameBase::setPosition(%obj, %pos);
	}
	%playerTeam = GameBase::getTeam(%this);
	if ($TeamTitan[%playerTeam] == %this) $TeamTitan[%playerTeam] = "";
}


function TowerSwitch::getObjectiveString(%this, %forTeam)
{}

//=========================================== Player Touches A Tower Switch

function TowerSwitch::onCollision(%this, %object)
{
   if(getObjectType(%object) != "Player") return;
   if(Player::isDead(%object)) return;

   %playerClient = Player::getClient(%object);
   if(%playerClient.curse) return;
   %touchClientName = Client::getName(%playerClient);
	%armor = Player::getArmor(%object);

   %playerTeam = GameBase::getTeam(%object);
   %oldTeam = GameBase::getTeam(%this); %oldname = getTeamName(%oldteam);
   if(%oldTeam == %playerTeam)
   {
	if($TeamTitan[%playerTeam] == "")
	{
		$TeamTitan[%playerTeam] = %object;
		systemMessage(%playerClient,3,"You become your team's Titan!~wflyer_mount.wav");
		playSound(SoundFlagReturned,gamebase::getposition(%this));
		centerprint(%playerClient, "                   <Btower_enemycontrol.bmp> Attack the Enemy's Titan Switch! <Btower_enemycontrol.bmp>");
		Player::setArmor(%playerClient, tarmor);
		%item = Player::getMountedItem(%this,$BackpackSlot);
		Player::dropItem(%client,%item);
		Player::mountItem(%playerClient, TitanPack, $BackpackSlot);
		Player::unMountItem(%this,4);
		Player::unMountItem(%this,5);
		return;
	}
	else if ($TeamTitan[%playerTeam] == %object)
	{
		systemMessage(%playerClient, 3, "You are your team's Titan! Attack the enemy's Titan Switch.~wfemale2.wattobj.wav");
		playSound(SoundPDAButtonHard,gamebase::getposition(%this));
		return;
	}
	else
	{
		playSound(SoundPDAButtonHard,gamebase::getposition(%this));
		systemMessage(%playerClient, 3, "Protect, repair, and resupply your Titan to ensure he reaches the enemy's Switch.~wfemale2.wescfr.wav");
		%opos = GameBase::getPosition($TeamTitan[%playerTeam]);
		%posX = getWord(%opos,0);
		%posY = getWord(%opos,1);
		issueCommand(%playerClient, %playerClient, 0,"Escort Titan at waypoint", %posX, %posY);
		return;
	}
   }
   else
   {
	if (%this.lockout == True)
	{
		TeamMessages(1, %playerTeam, "The " @ %oldname @ " have locked this switch against capture!~wAccess_Denied.wav", -2, "null",%touchClientName @ " attempted to gain control of a locked switch!~wfemale1.wbasundr.wav");
		return;
	}
	else if ($TeamTitan[%playerTeam] != %object)
	{
		playSound(SoundPDAButtonHard,gamebase::getposition(%this));
		systemMessage(%playerClient, 3, "Protect, repair, and resupply your Titan to ensure he reaches THIS Switch.~wfemale2.wescfr.wav");
		%opos = GameBase::getPosition($TeamTitan[%playerTeam]);
		%posX = getWord(%opos,0);
		%posY = getWord(%opos,1);
		issueCommand(%playerClient, %playerClient, 0,"Escort Titan at waypoint", %posX, %posY);
		return;
	}
	%this.trainingObjectiveComplete = true;

	TeamMessages(3, %playerTeam, "Your team's Titan has reached the objective.~wCapturedTower.wav");
	TeamMessages(1, %oldTeam, "The " @ getTeamName(%playerTeam) @ " team's Titan "@%touchClientName@" has reached your objective!~wLostTower.wav");
	bottomprintall("               <RD_Check_DF.bmp> "@%touchClientName@" has reached the "@ getTeamName(%oldTeam) @"'s Titan Switch! <RD_Check_DF.bmp>");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if (Client::getTeam(%cl) != %playerTeam)
		{
			playNextAnim(%cl);
			Player::kill(%cl);
			Client::onKilled(%cl,%playerClient, $NukeDamageType, "torso", "front_left");
		}
		else
		{
			%cl.score = %cl.score +20;
			bottomprint(%cl,"               <RD_Check_DF.bmp> "@%touchClientName@" has reached the "@ getTeamName(%oldTeam) @"'s Titan Switch! <RD_Check_DF.bmp>\n<jc>Your score +20 ="@ %cl.score);
			if (%cl != %playerClient)
			{
				%newGuy = Client::getOwnedObject(%cl);
				Game::refreshClientScore(%cl);
			}
		}
	}
	%playerClient.score = %playerClient.score +20;
	bottomprint(%playerClient,"               <RD_Check_DF.bmp> You reached the "@ getTeamName(%oldTeam) @"'s Titan Switch! <RD_Check_DF.bmp>\n<jc>Your score +40 ="@ %playerClient.score);
	playNextAnim(%playerClient);
	%playerClient.FlagCaps++;
	Player::kill(%playerClient);
	$teamScore[%playerTeam]++;
	ObjectiveMission::refreshTeamScores();
	ObjectiveMission::checkScoreLimit();
	Game::refreshClientScore(%playerClient);

	$TeamTitan[%playerTeam] = %newGuy;
	%newCl = Player::getClient(%newGuy);
	systemMessage(%newCl,3,"You become your team's Titan!~wflyer_mount.wav");
	playSound(SoundFlagReturned,gamebase::getposition(%newGuy));
	centerprint(%newCl, "                   <Btower_enemycontrol.bmp> Attack the Enemy's Titan Switch! <Btower_enemycontrol.bmp>");
	Player::setArmor(%newCl, tarmor);
	%item = Player::getMountedItem(%newGuy,$BackpackSlot);
	Player::dropItem(%newCl,%item);
	Player::mountItem(%newCl, TitanPack, $BackpackSlot);
	TeamMessages(3, %playerTeam, Client::getName(%newCl) @ " has become your team's Titan!");
    }
}

