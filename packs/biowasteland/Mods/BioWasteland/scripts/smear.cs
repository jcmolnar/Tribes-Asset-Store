exec("objectives.cs");
function ObjectiveMission::missionComplete()
{
	TribeStat_ShowScores();
	$missionComplete = "True";

	//=================== Get it together for missions summary
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

	//================= Back out of all the functions...

    	schedule("Server::nextMission();", 0);
}

function ObjectiveMission::setObjectiveHeading()
{
	if($missionComplete == "True") //========= When The Mission Is Over
	{
		%numClients = getNumClients();
		if (%numClients > 1)
		{
			for(%i = 0 ; %i < %numClients ; %i++) %clientList[%i] = getClientByIndex(%i);
			%doIt = 1;
			while(%doIt == 1)
			{
				%doIt = "";
				for(%i= 0 ; %i < %numClients; %i++)
				{
					if((%clientList[%i]).score < (%clientList[%i+1]).score)
					{
						%hold = %clientList[%i];
						%clientList[%i] = %clientList[%i+1];
						%clientList[%i+1]= %hold;
						%doIt=1;
					}
				}
			}      
		}
		else
		{
			%clientList[0] = getClientByIndex(0);
		}                   
		for (%x = -1; %x < 2; %x++)
		{
			%lineNum = 0;
			Team::setObjective(%x, %lineNum++, "<jc><f5>Final Smear Statistics");
			Team::setObjective(%x, %lineNum++, "");
			Team::setObjective(%x, %lineNum++, "");
			%curLeader = %clientList[0];
			if (%curLeader.score == 0) Team::setObjective(%x, %lineNum++, "<jc><f4>Leader:  <f1>None");
			else Team::setObjective(%x, %lineNum++, "<jc><f4>Leader:  <f1>" @ Client::GetName(%curLeader));
			Team::setObjective(%x, %lineNum++, "");    
			Team::setObjective(%x, %lineNum++, "<f2>Score     Player");
			for (%i = 0; %i < %numClients; %i++)
			{
				if (%clientList[%i].score == 0) Team::setObjective(%x, %lineNum++, "<f1>0          " @ Client::GetName(%clientList[%i]));
				else                                       
				{                            
					if (%clientList[%i].score < 10) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "          " @ Client::GetName(%clientList[%i]));
	   				else if (%clientList[%i].score < 100) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "         " @ Client::GetName(%clientList[%i]));
					else if (%clientList[%i].score < 1000) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "        " @ Client::GetName(%clientList[%i]));
					else Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "       " @ Client::GetName(%clientList[%i]));
				}
			}       
			for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%x, %s, " ");
		}
		if ($Wasteland::SaveOn)
		{
			echo ("*** Saving Players");
			saveall();
		}
	}                                          
}

//================== Display Team Bit Maps
function objective::displayBitmap(%team, %line)
{
	%bitmap1 = "deathmatch1.bmp";
	%bitmap2 = "deathmatch2.bmp";
}

function Flag::getObjectiveString(%this, %forTeam)
{
	%thisTeam = GameBase::getTeam(%this);
	if (%this.carrier == -1) return "<Bflag_enemycaptured.bmp>\nNobody has the Scoring Flag!";
	else if(%thisTeam == %forTeam)
		return "<Bflag_atbase.bmp>\nYou have the Scoring Flag!";
	else return "<Bflag_enemycaptured.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has the Scoring Flag!";
}
//===================
//	 Flag Releated Calls
//=========================

function Flag::onDrop(%player, %type)
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);

	$FlagCarry[%flagTeam] = "";

	echo("\"P\"" @ %playerClient @ "\"0\"");
	echo("ADMINMSG: **** " @ %dropClientName @ " dropped the Scoring Flag!");

	%homepos = ($teamFlag[%playerTeam]).originalPosition; 
	%droppos = GameBase::getPosition(%player);
	%disthome = (Vector::getDistance(%homepos,%droppos));

	GameBase::throw(%flag, %player, 10, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped the Scoring Flag!");
	Client::sendMessage(%playerClient, 1, "You dropped the Scoring Flag!");
	$Spoonbot::HuntFlagrunner = 0;

	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
	GameBase::setTeam(%player,0);
}

function Objective::AutoReturn (%player)
{
	if(!%player.carryFlag)
		return;
	%flag = %player.carryFlag;
	%client = Player::getClient(%player);
	%score = %flag.scoreValue;
 	%client.score = %client.score + %score;
	Game::refreshClientScore(%client);
	schedule("Objective::AutoReturn(" @ %player @ ");", 12);
}
//===================== Touching The Flag
function Flag::onCollision(%this, %object)
{
	if(getObjectType(%object) != "Player")
		return;
	if(%this.carrier != -1)
		return; //============= Spurious collision
	%name = Item::getItemData(%this);
	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);
	%playerClient = Player::getClient(%object);
	if(%playerClient.curse) return;
	%touchClientName = Client::getName(%playerClient);
	%carriedflag = %object.carryFlag;
	%carriedflagteam = GameBase::getTeam(%carriedFlag);
	%carrierflag = Player::getMountedItem(%object, $FlagSlot);


	if (%carrierflag == "Bone")
	{
		bottomprint(%playerClient, "<jc>You must drop the bone you have before you can pick up a flag." ,3);
		return;
	}
	else if (%carrierflag == "flag")
	{
		bottomprint(%playerClient, "You must return the flag you have before you can pick up another." ,3);
		return;
	}
	Player::setItemCount(%object, Flag, 1);
	Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
	Item::hide(%this, true);
	$flagAtHome[1] = false;
	%this.atHome = false;
	%this.carrier = %object;
	%this.pickupSequence++;
	%object.carryFlag = %this;
	if(%this.fadeOut)
	{
		GameBase::startFadeIn(%this);
		%this.fadeOut= "";
	}
	MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the Scoring Flag!~wFlag1.wav");
	Client::sendMessage(%playerClient, 0, "You captured the Scoring Flag!~wflagreturn.wav");
	bottomprint(%playerClient, "<jc>Flag Possession Score = " @ %this.scoreValue*5 @ " points/minute.",3);
	ObjectiveMission::ObjectiveChanged(%this);
	Objective::AutoReturn (%object);
	GameBase::setTeam(%object,1);
}

//=========================== Flag Defence For Advanced Scoring
function Flag::clientKilled(%this, %playerId, %killerId) {}

//=================== Flag Player Leaves Mission Area

function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)
{
	%score = 0;
	%playerId.lascharge = "";
	%playerId.charging = "";
	%killerteam = Client::getTeam(%killerId);
	%killerName = Client::getName(%killerId);
	%playerteam = Client::getTeam(%playerId);
	%victimName = Client::getName(%playerId);

	echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");

	echo ("*** Player " @ %playerId);
	echo ("*** Killer " @ %killerId);

	%killedflag = $killedflagcarry;
	%playerId.guiLock = true;

	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}

	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));

	if(!%killerId || %killerId == "-1") //=== No Killer Listed
	{
		messageAll(0, strcat(%victimName, " bites the dust."), $DeathMessageMask);
		echo ("ADMINMSG: " @ %victimName @ " bites the dust.");
		%playerId.scoreDeaths++;
		bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		echo ("ADMINMSG: " @ %victimName @ " kills self.");
		%playerId.scoreDeaths++;

		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			bottomprint(%playerId,"You had the Flag. Your score reduced by " @ $Score::FlagDef @ " due to suicide.",3);
		}
		else
		{
			%playerId.score--;
			bottomprint(%playerId,"<jc>Your score reduced to " @ %playerId.score @ " due to suicide.",3);
		}

		Game::refreshClientScore(%playerId);
		return;
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
		%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killerName,%victimName, %killerGender, %playerGender);
		%killedpos = %playerId.lastkillpos;			//== Killed Pos
		%killerpos = GameBase::getPosition(%killerId);	//== Killers Pos
		%killdist = Vector::getDistance(%killedpos,%killerpos);

		if (%damagetype == $SniperDamageType || %damagetype == $LaserDamageType)
		{
			if (%vertPos == "head")
			{
				%msg = "HEAD SHOT <f2>("@floor(%killdist)@"m)";
				%obitMsg = sprintf($deathMsg[18, %ridx], %killerName,%victimName, %killerGender, %playerGender);
			}
			else %msg = " <f2>("@floor(%killdist)@"m)";
		}

		messageAll(0, %obitMsg, $DeathMessageMask);
		echo ("ADMINMSG: " @ %obitMsg @ "");

		%killerId.scoreKills++;  //=== Killer Number Of Kills
           	%playerId.scoreDeaths++;  //=== Killed Player Deaths

		if (%killedflag)
		{
			bottomprint(%killerId, "<jc>Flag Runner Killed!" @ %msg,3);
           		messageAll(0, %killerName @ " killed the flag runner!");
		}
		//========== Refresh Scores

		Game::refreshClientScore(%killerId);
     		Game::refreshClientScore(%playerId);
	}
}
function Game::playerSpawned(%pl, %clientId, %armor)
{
	GameBase::setTeam(%pl,0);
	$Wasteland::JustSpawned[%clientId] = "True";
	schedule ("$Wasteland::JustSpawned[" @ %clientId @ "] = False;",$Wasteland::SpawnSafe);

	if ($Client::info[%clientId, 0] == ""){}
	else Client::setSkin(%clientId, $Client::info[%clientId, 0]);

	%clientId.spawntime = getsimtime();
	%power = IsPowerDown(gamebase::getteam(%clientId));

	//========================================= Custom Spawn Settings
	//== Spawn Notifications Added By Ascain.

	if ($Wasteland::PowerCheck != "False" && !%power)
	{
		echo ("=============SPAWN - Power down - standard");
		standardSpawnList(%clientId);
		schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>You have spawned in standard armor, YOUR POWER IS DOWN!!!\", 10);" ,3);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "standard")
	{
		echo ("=============SPAWN - Normal Standard");
		standardSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "random")
	{
		echo ("=============SPAWN - Random");
		randomSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "favs")
	{
		echo ("=============SPAWN - Favs");
		if (%clientId.favsettings) { bottomprint(%clientId, "<jc><f2>You have spawned with your last bought favorites.", 10);}
		else { bottomprint(%clientId, "<jc><f2>You must select your favorites first before you can be spawned with them.", 10);}

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if ($Wasteland::SaveOn && %clientId.SavedInfo && %clientId.spawntype == "saved")
	{
		echo ("=============SPAWN - Player Saved");
		savedSpawnList(%clientId);
		%clientId.spawntype = %clientId.spawntypetwo;

		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	echo ("=============SPAWN - Ooops No Spawn!?!");
}

schedule("$Wasteland::FairCheck = \"2340\";", 10);
schedule("$Wasteland::FairEvens = \"2340\";", 10);
schedule("$TestMissionType = \"SMR\";", 10);

echo ("*** Biohazard's Rabbit Objective Initiated");