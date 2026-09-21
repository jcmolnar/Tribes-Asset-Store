deleteVariables("$Score::*");

//i need to
//Player Joins-> Check for drop/rejoin/score restore
//If no restore, reset to 0's
//Load saved stats onto server object if they don't exist
$ImpactDamageType      = -1;
$LandingDamageType	   =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;//disc
$ShrapnelDamageType    =  5;//grenade
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;//handgrenade
$MissileDamageType     = 12;
$MineDamageType        = 13;
$HandGrenadeDamageType = 14;

$Score::KILLER_NAME::KILLED::KILLEE_NAME++;

$DamageScale[Scout, $HandGrenadeDamageType] = 1.0;
$DamageScale[LAPC, $HandGrenadeDamageType] = 1.0;
$DamageScale[HAPC, $HandGrenadeDamageType] = 1.0;
$DamageScale[TowerDOne, $HandGrenadeDamageType] = 1.2;
$DamageScale[larmor, $HandGrenadeDamageType] = 1.2;
$DamageScale[marmor, $HandGrenadeDamageType] = 1.0;
$DamageScale[harmor, $HandGrenadeDamageType] = 0.8;
$DamageScale[lfemale, $HandGrenadeDamageType] = 1.2;
$DamageScale[mfemale, $HandGrenadeDamageType] = 1.0;
$DamageScale[Aarmor, $HandGrenadeDamageType] = 1.2;
$DamageScale[Barmor, $HandGrenadeDamageType] = 1.2;
$DamageScale[LestatArmor, $HandGrenadeDamageType] = 1.2;
$DamageScale[LestatArmor, $HandGrenadeDamageType] = 1.2;
$DamageScale[PeachMachine, $HandGrenadeDamageType] = 1.2;
$DoorScale[$ShrapnelDamageType] = 1.0;

$deathMsg[$HandGrenadeDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$HandGrenadeDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$HandGrenadeDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$HandGrenadeDamageType, 3]    = "%2 never saw it coming from %1.";

//$DiscLauncherDamageType = 4;
$PlasmaGunDamageType = 3;
$GrenadeLauncherDamageType =5;
$HandGrenadeDamageType = 14;
$MortarDamageType = 7;

//$Score::MidAirTracking[$DiscLauncherDamageType] = true;
$Score::MidAirTracking[$PlasmaGunDamageType] = true;
$Score::MidAirTracking[$GrenadeLauncherDamageType] = true;
$Score::MidAirTracking[$HandGrenadeDamageType] = true;
$Score::MidAirTracking[$MortarDamageType] = true;

//$Score::MaxDamage[$DiscLauncherDamageType] = 0.433332;
$Score::MaxDamage[$PlasmaGunDamageType] = 0.337497;
$Score::MaxDamage[$GrenadeLauncherDamageType] = 0.373331;
$Score::MaxDamage[$HandGrenadeDamageType] = 0.449998;
$Score::MaxDamage[$MortarDamageType] = 0.949998;

//$disc = 0.433332; $plas = 0.337498; $nade = 0.373331; $mortar = 0.949998; $handnade = 0.449998;
function remoteOB(%cl)
{
	%pl = client::getownedobject(%cl);
	//%distance = 4;

	//both(Player::ObstructionsBelow(%pl, %distance));
	both(Player::getLastContactCount(%pl));
}
function OBLoop(%cl)
{
	if($ob)
	{
		remoteOB(%cl);
		schedule("OBLoop("@%cl@");", 0.1);
	}
}
function Player::ObstructionsBelow(%pl, %distance)
{
	%armor = Player::getArmor(%pl);
	%pos = GameBase::getPosition(%pl);
	%height = "0 0 " @ -%armor.boxNormalHeight;
	while(%distance > 0)
	{
		%pos = Vector::Add(%pos, %height);
		if(!GameBase::testPosition(%pl, %pos))
			return(true);
		%distance -= %armor.boxNormalHeight;
	}
	return (false);
}
function remoteCBFS(%cl)
{
	%cl = 2049; %pl = client::getownedobject(%cl);
	%pos = gamebase::getposition(%pl);
	%set = newObject("set",SimSet);
	both(containerBoxFillSet(%set,$SimTerrainObjectType|$SimInteriorObjectType,%pos,1,1,2,1));
	both("OBJ "@Group::getObject(%set, 0)@" POS: "@%pos);
	schedule("deleteobject("@%set@");",5);
}

function a()	{	resetClientM(2049);	}
function b()	{	Score::Save(2049);	}
function c()	{	resetClient(2049);	}
function d()	{	Score::Load(2049);	}
function e()	{	Score::UpdateFile(2049);	}

ParseTimestamp();
$MapStartCode = $TimeStamp::Month @ $TimeStamp::Day @ $TimeStamp::Year @ $TimeStamp::Hour @ $TimeStamp::Minute @ $TimeStamp::Second;
$MapName[$MapStartCode] = $missionName;

function Score::GetTopScore(%stat, %playType, %weapon)
{
	//echo("Score::GetTopNonWeaponScore stat: "@%stat@" ("@%playType@")");
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++)
	{
		%clientList[%i] = getClientByIndex(%i);
	}
	if(%numClients > 1)
	{
		%doIt = true;
		while(%doIt)
		{
			%doIt = "";
			for(%i= 0 ; %i < %numClients+1; %i++)
			{
				if(%playType != "")
				{
					if(%weapon != "")
					{
						if(%clientList[%i] != "" && %clientList[%i].score[%playType, %stat, %weapon] < %clientList[%i+1].score[%playType, %stat, %weapon] && Client::getName((%clientList[%i])) != "")
						{
							%hold = %clientList[%i];
							%clientList[%i] = %clientList[%i+1];
							%clientList[%i+1] = %hold;
							%doIt=true;
						}
					}
					else
					{
						if(%clientList[%i] != "" && %clientList[%i].score[%playType, %stat] < %clientList[%i+1].score[%playType, %stat] && Client::getName((%clientList[%i])) != "")
						{
							%hold = %clientList[%i];
							%clientList[%i] = %clientList[%i+1];
							%clientList[%i+1] = %hold;
							%doIt=true;
						}
					}
				}
				else
				{
					if(%clientList[%i] != "" && %clientList[%i].score[%stat] < %clientList[%i+1].score[%stat] && Client::getName((%clientList[%i])) != "")
					{
						%hold = %clientList[%i];
						%clientList[%i] = %clientList[%i+1];
						%clientList[%i+1] = %hold;
						%doIt=true;
					}
				}
			}
		}

		%tieList = %clientList[0];
		for(%i = 1 ; %i < %numClients ; %i++)
		{
			if(%playType != "")
			{
				if(%weapon != "")
				{
					if(%clientList[%i].score[%playType, %stat, %weapon] == %clientList[0].score[%playType, %stat, %weapon])
					{
						%tie = true;
						%tieList = %tieList@" "@%clientList[%i];
					}
				}
				else
				{
					if(%clientList[%i].score[%playType, %stat] == %clientList[0].score[%playType, %stat])
					{
						%tie = true;
						%tieList = %tieList@" "@%clientList[%i];
					}
				}
			}
			else
			{
				if(%clientList[%i].score[%stat] == %clientList[0].score[%stat])
				{
					%tie = true;
					%tieList = %tieList@" "@%clientList[%i];
				}
			}
		}

		if(%tie)
			return %tieList;
		else
			return %clientList[0];
	}
	else return "None";
}

function Score::GetClientWeaponScoreTotal(%client, %stat, %playType)
{
	%total = 0;
	for(%x = 1 ; %x < 15 ; %x++)
	{
		if($ScoreWeapon[%x] != "")
		{
			%total += %client.score[%playType, %stat, %x];
		}
	}
	return %total;
}

//both(Score::GetClientWeaponScoreTotal(2049, "HitsDone", "DM"));
//both(Score::GetTopScore("DistanceTravelled", "DM"), 0);
//both(Score::GetTopScore("BestKillStreak", "DM"), 0);
//both(Score::GetTopNonWeaponScore(, "DM"));



function Score::IncreaseStat(%client, %stat, %amount, %playType, %weapon)
{
	//echo("Increasing stat,"@%client@","@ %stat@","@ %amount@","@ %playType@","@ %weapon);
	if(%playType != "")
	{
		if(%weapon != "")
		{
			%client.score[%playType, %stat, %weapon] += %amount;
			%value = %client.score[%playType, %stat, %weapon];
		}
		else
		{
			%client.score[%playType, %stat] += %amount;
			%value = %client.score[%playType, %stat];
			%weapon = "NULL";
		}
	}
	else
	{
		%client.score[%stat] += %amount;
		%value = %client.score[%stat];
		%playType = "NULL";
		%weapon = "NULL";
	}
	if(%client.prefs["ViewScoreDebug"])
		Client::sendMessage(%client, $Green, "IncreaseStat "@%stat@": "@%value@" (+"@%amount@"), Play Type: "@%playType@" Weapon: "@$ScoreWeapon[%weapon], 20);
}

function Score::SetStat(%client, %stat, %amount, %playType, %weapon)
{
	//echo("Setting stat,"@%client@","@ %stat@","@ %amount@","@ %playType@","@ %weapon);
	if(%playType != "")
	{
		if(%weapon != "")
		{
			%client.score[%playType, %stat, %weapon] = %amount;
		}
		else
		{
			%client.score[%playType, %stat] = %amount;
			%weapon = "NULL";
		}
	}
	else
	{
		%client.score[%stat] = %amount;
		%playType = "NULL";
		%weapon = "NULL";
	}
	if(%client.prefs["ViewScoreDebug"])
		Client::sendMessage(%client, $Green, "Setting stat: "@%stat@" to: "@%amount@", Play Type: "@%playType@" Weapon: "@$ScoreWeapon[%weapon], 20);
}
function Score::GetStat(%client, %stat, %playType, %weapon)
{
	if(%playType != "")
	{
		if(%weapon != "")
		{
			%value = %client.score[%playType, %stat, %weapon];
		}
		else
		{
			%value = %client.score[%playType, %stat];
		}
	}
	else
	{
		%value = %client.score[%stat];
	}
	return %value;
}
function Score::CompareStat(%client, %stat, %amount, %playType, %weapon)
{
	if(%playType != "")
	{
		if(%weapon != "")
		{
			if(%amount > %client.score[%playType, %stat, %weapon])
			{
				%client.score[%playType, %stat, %weapon] = %amount;
				%Improvement = true;
			}
		}
		else
		{
			if(%amount > %client.score[%playType, %stat])
			{
				%client.score[%playType, %stat] = %amount;
				%weapon = "NULL";
				%Improvement = true;
			}
		}
	}
	else
	{
		if(%amount > %client.score[%stat])
		{
			%client.score[%stat] = %amount;
			%playType = "NULL";
			%weapon = "NULL";
			%Improvement = true;

		}
	}
	if(%Improvement)
	{
		//bottomprint(%client, "New personal best! "@%stat@": "@%amount@", Play Type: "@%playType@" Weapon: "@$ScoreWeapon[%weapon], 20);
		if(%client.prefs["ViewScoreDebug"])
		{
			client::sendmessage(%client, $Green, "New personal best! "@%stat@": "@%amount@", Play Type: "@%playType@" Weapon: "@$ScoreWeapon[%weapon], 20);
		}
	}
}

// 1.50 PORT: was Attachment::AddBefore("Team::setObjective", "BeforeTeam::setObjective").
// Attachment.dll is a 2011 binary plugin that patched the 1.x exe's dispatcher; it cannot
// load here. The engine implements the same thing natively -- `function X(...) before Y`
// (eval.cpp RegisterConsoleHook / dispatchCall). The hook is bound to the target's args
// the same way, may rewrite them, and `halt` short-circuits the target, so the behaviour
// the plugin provided is preserved. Registration is idempotent.
function BeforeTeam::setObjective(%team, %lineNum, %string) before Team::setObjective
{
	if(%team == -1)
	{
		//echo("Logging Objective Menu");
		//echo(%lineNum@" "@%string);
		$Objective::BackUp[$MapStartCode, %lineNum] = %string;
	}
	//$Objective::BackUp[$BackUpCount] =  ;
}

//These will be 'no-type' prefs
//%client.prefs["TeamDuelTime"]
%x = -1;
$Score::statPrefs[%x++] = "VoteGraphic";//done
$Score::statPrefs[%x++] = "DuelModeOff";//done
$Score::statPrefs[%x++] = "allowabuse";//done
$Score::statPrefs[%x++] = "autoWaypoint";//done
$Score::statPrefs[%x++] = "obsmode";//done
$Score::statPrefs[%x++] = "obsTDonly";//done
$Score::statPrefs[%x++] = "SuperCam";//done
$Score::statPrefs[%x++] = "flash";//done
$Score::statPrefs[%x++] = "ViewScoreDebug";//done


$Score::Defaultprefs["VoteGraphic"] = false;
$Score::Defaultprefs["DuelModeOff"] = false;
$Score::Defaultprefs["allowabuse"] = true;
$Score::Defaultprefs["autoWaypoint"] = false;
$Score::Defaultprefs["obsmode"] = "1stPerson";
$Score::Defaultprefs["obsTDonly"] = true;
$Score::Defaultprefs["SuperCam"] = false;
$Score::Defaultprefs["flash"] = 1;
$Score::Defaultprefs["ViewScoreDebug"] = false;

//These will be 'no-type' stats same as global
//%client.score["TeamDuelTime"]
%x = -1;
$Score::statTime[%x++] = "TeamDuelTime";
$Score::statTime[%x++] = "TeamDuelAliveTime";
$Score::statTime[%x++] = "TeamDuelCriticalTime";
$Score::statTime[%x++] = "DuelTime";//done
$Score::statTime[%x++] = "DeathMatchTime";
$Score::statTime[%x++] = "ObverserverTime";
$Score::statTime[%x++] = "ConnectedTime";
$Score::statTime[%x++] = "IdleTime";
$Score::statTime[%x++] = "AFKinTD";
$Score::statTime[%x++] = "IdleTime";
$Score::statTime[%x++] = "IdleTime";
$Score::statTime[%x++] = "IdleTime";

%x = -1;
$Score::Globalstat[%x++] = "KingKills";
$Score::Globalstat[%x++] = "LongestAirTime";
$Score::Globalstat[%x++] = "TimesConnectedToServer";
$Score::Globalstat[%x++] = "LongestSession";
$Score::Globalstat[%x++] = "IdleTime";
$Score::Globalstat[%x++] = "NRTracker";
$Score::Globalstat[%x++] = "CheapShotAttempt";
$Score::Globalstat[%x++] = "SighCounter";
$Score::Globalstat[%x++] = "LinesSentGlobalChat";
$Score::Globalstat[%x++] = "LinesSentTeamChat";
$Score::Globalstat[%x++] = "VChatMessages";
$Score::Globalstat[%x++] = "TreesKilled";
$Score::Globalstat[%x++] = "TDRoundsPlayed";
$Score::Globalstat[%x++] = "TDMatchesWon";
$Score::Globalstat[%x++] = "TDMatchesLost";
$Score::Globalstat[%x++] = "TDMatchesPlayed";
$Score::Globalstat[%x++] = "MatchesBailed";
$Score::Globalstat[%x++] = "RoundsSurvived";
//$Score::Globalstat[%x++] = "MostKillsPerRound"; killstreak derp
$Score::Globalstat[%x++] = "MostHitsPerRound";
$Score::Globalstat[%x++] = "MostMAsPerRound";
$Score::Globalstat[%x++] = "MostDMGPerRound";
$Score::Globalstat[%x++] = "MostDMGTakenPerRound";
$Score::Globalstat[%x++] = "MostHitsTakenPerRound";



//$Score::Globalstat[%x++] = "ConnectedToServer";//File Specefic

//These will all use the type TD DM DL
//%client["TD", "HandNadeHits"]
%x = -1;
$Score::stat[%x++] = "Assists";//done
$Score::stat[%x++] = "TKAssists";//done
$Score::stat[%x++] = "TKs";//done
$Score::stat[%x++] = "TKed";//done
$Score::stat[%x++] = "HandGrenadeBlock";
$Score::stat[%x++] = "GroundShots";//done
$Score::stat[%x++] = "TotalGroundShotDistance";//done
$Score::stat[%x++] = "FurthestGroundShot";//done
$Score::stat[%x++] = "AverageGroundShot";//done
$Score::stat[%x++] = "InventoryVisits";
$Score::stat[%x++] = "KitsDropped";
//$Score::stat[%x++] = "KitsStolen";
$Score::stat[%x++] = "KitsGivenToAlly";
$Score::stat[%x++] = "KitsGivenToEnemy";
$Score::stat[%x++] = "KitsReceivedFromAlly";
$Score::stat[%x++] = "KitsReceivedFromEnemy";
$Score::stat[%x++] = "BodyBlocks";
$Score::stat[%x++] = "GreatestHeightReached";
$Score::stat[%x++] = "AllyRepaired";
$Score::stat[%x++] = "SelfRepaired";
$Score::stat[%x++] = "StationsRepaired";
$Score::stat[%x++] = "StationVisits";
$Score::stat[%x++] = "HandNadeHits";
$Score::stat[%x++] = "BeaconUsed";
$Score::stat[%x++] = "BeaconStop";
$Score::stat[%x++] = "BeaconJump";
$Score::stat[%x++] = "BeaconJumpFastest";
$Score::stat[%x++] = "DoubleMA";
$Score::stat[%x++] = "TripleMA";
$Score::stat[%x++] = "FriendlyCorpseLooted";
$Score::stat[%x++] = "EnemyCorpseLooted";
$Score::stat[%x++] = "CorpseLooted";//done
$Score::stat[%x++] = "CorpseTouched";//done
$Score::stat[%x++] = "CorpseHumper";//done
$Score::stat[%x++] = "CorpseHumped";//done
$Score::stat[%x++] = "MACorpseHumper";//done
$Score::stat[%x++] = "MACorpseHumped";//done
$Score::stat[%x++] = "CorpseMa";//done
$Score::stat[%x++] = "CorpseMaTaken";//done
$Score::stat[%x++] = "KitsConsumed";
$Score::stat[%x++] = "KitsPickedUp";
$Score::stat[%x++] = "BestKillStreak";//done
$Score::stat[%x++] = "scoreSuicide";//done
$Score::stat[%x++] = "scoreKillsTotal";//done
$Score::stat[%x++] = "scoreDeathsTotal";//done
$Score::stat[%x++] = "EnergyDrained";//done
$Score::stat[%x++] = "DistanceTravelled";//done
$Score::stat[%x++] = "FurthestDistanceJumped";//done
$Score::stat[%x++] = "HandNadesCaught";//done
$Score::stat[%x++] = "FastestSkiSpeed";//done
$Score::stat[%x++] = "BackStab";//doneFlightTime
$Score::stat[%x++] = "BackStabbed";//doneFlightTime
$Score::stat[%x++] = "LongestFlightTime";//doneFlightTime
$Score::stat[%x++] = "FlightTime";//done
$Score::stat[%x++] = "KillStreak";//done

//%client.score["TD", "scoreKills", "Damage/WeaponType"];
%x=-1;
$Score::statWeapons[%x++] = "HeadShots";//done
$Score::statWeapons[%x++] = "DirectShots";
$Score::statWeapons[%x++] = "CorpseMa";//done
$Score::statWeapons[%x++] = "CorpseMaTaken";//done
$Score::statWeapons[%x++] = "scoreKills";//done
$Score::statWeapons[%x++] = "scoreDeaths";//done
$Score::statWeapons[%x++] = "shotsFired";//done
$Score::statWeapons[%x++] = "HitsDone";//done
$Score::statWeapons[%x++] = "HitsReceived";//done
$Score::statWeapons[%x++] = "dmgDone";//done
$Score::statWeapons[%x++] = "dmgReceived";//done
$Score::statWeapons[%x++] = "FurthestMidAir";//done
$Score::statWeapons[%x++] = "MidAirs";//done
$Score::statWeapons[%x++] = "MidAirsCaught";//3=plas,4=disc,5=nade,7=hn//done
$Score::statWeapons[%x++] = "dmgDoneSpothead";//done
$Score::statWeapons[%x++] = "dmgDoneSpotlegs";//done
$Score::statWeapons[%x++] = "dmgDoneSpottorso";//done
$Score::statWeapons[%x++] = "dmgReceivedSpothead";//done
$Score::statWeapons[%x++] = "dmgReceivedSpotlegs";//done
$Score::statWeapons[%x++] = "dmgReceivedSpottorso";//done
$Score::statWeapons[%x++] = "SelfShieldDamageAbsorbed";//done
$Score::statWeapons[%x++] = "SelfShieldHitsAbsorbed";//done
$Score::statWeapons[%x++] = "DamageToEnemyShields";//done
$Score::statWeapons[%x++] = "HitsToEnemyShields";//done
$Score::statWeapons[%x++] = "OverKilled";//done
$Score::statWeapons[%x++] = "OverKill";//done
$Score::statWeapons[%x++] = "SelfdmgReceived";//done
$Score::statWeapons[%x++] = "SelfHitsReceived";//done

//$Score::statWeapons[%x++] = "dmg_head_right_middle";
//$Score::statWeapons[%x++] = "dmg_head_right_front";
//$Score::statWeapons[%x++] = "dmg_head_right_back";
//$Score::statWeapons[%x++] = "dmg_head_left_middle";
//$Score::statWeapons[%x++] = "dmg_head_left_front";
//$Score::statWeapons[%x++] = "dmg_head_left_back";
//$Score::statWeapons[%x++] = "dmg_head_middle_middle";
//$Score::statWeapons[%x++] = "dmg_head_middle_front";
//$Score::statWeapons[%x++] = "dmg_head_middle_back";
//$Score::statWeapons[%x++] = "dmg_torso_back_right";
//$Score::statWeapons[%x++] = "dmg_torso_back_left";
//$Score::statWeapons[%x++] = "dmg_torso_front_right";
//$Score::statWeapons[%x++] = "dmg_torso_front_left";
//$Score::statWeapons[%x++] = "dmg_legs_front_right";
//$Score::statWeapons[%x++] = "dmg_legs_back_left";
//$Score::statWeapons[%x++] = "dmg_legs_front_left";
//$Score::statWeapons[%x++] = "dmg_legs_back_right";

//$Score::statWeapons[%x++] = "hits_head_right_middle";
//$Score::statWeapons[%x++] = "hits_head_right_front";
//$Score::statWeapons[%x++] = "hits_head_right_back";
//$Score::statWeapons[%x++] = "hits_head_left_middle";
//$Score::statWeapons[%x++] = "hits_head_left_front";
//$Score::statWeapons[%x++] = "hits_head_left_back";
//$Score::statWeapons[%x++] = "hits_head_middle_middle";
//$Score::statWeapons[%x++] = "hits_head_middle_front";
//$Score::statWeapons[%x++] = "hits_head_middle_back";
//$Score::statWeapons[%x++] = "hits_torso_back_right";
//$Score::statWeapons[%x++] = "hits_torso_back_left";
//$Score::statWeapons[%x++] = "hits_torso_front_right";
//$Score::statWeapons[%x++] = "hits_torso_front_left";
//$Score::statWeapons[%x++] = "hits_legs_front_right";
//$Score::statWeapons[%x++] = "hits_legs_back_left";
//$Score::statWeapons[%x++] = "hits_legs_front_left";
//$Score::statWeapons[%x++] = "hits_legs_back_right";


function Score::InitialLoad(%client)
{
	%ScoreObject = newObject("Static",StaticShape,CargoBarrel,true);
	addToSet("MissionCleanup", %ScoreObject);
	GameBase::setPosition(%ScoreTree, 0+getrandom()*200@" "@0+getrandom()*200@" -1000");
	Gamebase::setMapName(%ScoreTree, client::getname(%client)@"Spirit Barrel");
	%ScoreObject.Client = %client;
	%client.MainScoreBackup = %ScoreObject;
	Score::Load(%client);
}


//Load their save file, merge current scores with log, save it all
function Score::UpdateFile(%client)
{
	deleteVariables("$Score::Save*");
	deleteVariables("$Score::Saving*");
	%filename = HoldIPTrim(Client::getTransportAddress(%client)) @ ".cs";


	if(isFile("temp\\" @ %filename))
	{
		echo("ISFILE!!");

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;

		for(%retry = 1; %retry <= 10; %retry++)		//This might not be necessary, but it's to ensure that the
		{								//exec doesn't get flakey when there's lag.
			exec(%filename);
			if($Score::SavezSuccess)
					break;
		}
		if($Score::SavezSuccess)
		{
			//Smurfs First
			%name = nameRepair(%client);
			File::UpdateSmurfs(%client, %name);
			File::UpdateScores(%client);

			%type[0] = "DL";
			%type[1] = "TD";
			%type[2] = "DM";
			for(%x = 0; $Score::Saving[%x] != -1 && $Score::Saving[%x] != ""; %x++)//weapon types
			{
				$Score::Save[%x] = $Score::Saving[%x];
			}
			for(%a = 0; %a < 3; %a++)
			{
				for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
				{
					$Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]] =
					$Score::SavingWeapon[%type[%a], $Score::statWeapons[%x]];
				}
			}
			$Score::SaveTimers = $Score::SavingTimers;
			$Score::SaveGlobals = $Score::SavingGlobals;
			$Score::SavePrefs = $Score::SavingPrefs;
			for(%x = 0; $Score::SavingSmurfs[%x] != ""; %x++)
			{
				$Score::SaveSmurfs[%x] = $Score::SavingSmurfs[%x];
			}
			$Score::SavezSuccess = true;

			File::delete("temp\\" @ %filename);
			export("$Score::Save*", "temp\\" @ %filename, false);
			echo("Saving file: "@%filename@" for: "@client::getname(%client));
			deleteVariables("$Score::Save*");
			deleteVariables("$Score::Saving*");
		}
		else
		{
			export("$Score::Save*", "temp\\CORRUPT_" @ %filename, false);
			echo("SAVE FILE CORRUPTION");
			File::delete("temp\\" @ %filename);
			Score::UpdateFile(%client);
		}
	}
	else
	{
		echo("No File found, lettuce make one");
		Score::Save(%client);
		$Score::SaveSmurfs[0] = nameRepair(%client);
		$Score::SavezSuccess = true;
		File::delete("temp\\" @ %filename);
		export("$Score::Save*", "temp\\" @ %filename, false);
		echo("Saving file: "@%filename@" for: "@client::getname(%client));
		deleteVariables("$Score::Save*");
		deleteVariables("$Score::Saving*");
	}
}

function File::UpdateSmurfs(%client, %name)
{
	%newsmurf = true;
	%set = 0;
	for(%x = 0; %x < 16; %x++)//%client.smurfs[%set]
	{
		for(%y = 1; %y < 4; %y++)//%client.smurfs[%set]
		{
			if(gw($Score::SaveSmurfs[%set], %x) == %name || gw($Score::SaveSmurfs[%set], %x)@"."@%y == %name ||
			" "@gw($Score::SaveSmurfs[%set], %x) == %name || " "@gw($Score::SaveSmurfs[%set], %x)@"."@%y == %name)
			{
				echo("Found his name, no need to update (set: "@%set@", word: "@%x@")");
				%newsmurf = false;
				break;
			}
		}
		if(%x == 15 && %newsmurf)
		{
			echo("Dude has max smurfs... not found yet... next set!");
			echo($Score::SaveSmurfs[%set+1]);
			%set++;
			%x = 0;
		}
		if(gw($Score::SaveSmurfs[%set], %x) == -1)
		{
			echo("no smurfs in set "@%set@" "@%x);
			break;
		}
	}
	if(%newsmurf)
	{
		%space = " ";	if($Score::SaveSmurfs[%set] == "")	{	%space = "";	}
		$Score::SaveSmurfs[%set] = $Score::SaveSmurfs[%set]@%space@%name;
		echo("Adding "@%name@" to set: "@%set@" FULL: "@$Score::SaveSmurfs[%set]);
	}
	//for(%x = 0; $Score::SaveSmurfs[%x] != ""; %x++)
	//{
	//	$Score::SavingSmurfs[%x] = $Score::SaveSmurfs[%x];
	//}
}

function File::UpdateScores(%client)
{
	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";
	%Batch = -1;

	//for for for every weapon damage type/mode
	for(%a = 0; %a < 3; %a++)
	{
		%word = -1;
		%counter = -1;
		%Batch++;
		//echo("updating scores "@%type[%a]@" $Score::stat");
		for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//General
		{
			%space = " ";	if(%counter == -1)	{	%space = "";	}
			$Score::Saving[%Batch] = $Score::Saving[%Batch]@ %space @(%client.score[%type[%a], $Score::stat[%x]]+gw($Score::Save[%Batch], %word++));
			%counter++;
			//echo("Client: "@%client.score[%type[%a], $Score::stat[%x]]@" GW: "@gw($Score::Save[%Batch], %word));
			//echo("Saving Var... "@$Score::Saving[%Batch]);

			if(%word == 14)
			{
				//echo("Batch incremented... last stat = "@$Score::stat[%x]);
				%Batch++;
				%counter = -1;
				%word = -1;
			}
		}
		//echo("updating scores "@%type[%a]@" $Score::statWeapons");
		for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
		{
			%word = -1;
			for(%y = -1; %y < 15; %y++)
			{
				%space = " ";	if(%y == -1)	{	%space = "";	}
				if($Score::statWeapons[%x] == "shotsFired")
				{
					//echo(%client.score[%type[%a], $Score::statWeapons[%x], %y]);
				}
				$Score::SavingWeapon[%type[%a], $Score::statWeapons[%x]] =
				$Score::SavingWeapon[%type[%a], $Score::statWeapons[%x]]
				@ %space @
				(%client.score[%type[%a], $Score::statWeapons[%x], %y] + gw($Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]], %word++)) ;
				//echo($Score::SavingWeapon[%type[%a], $Score::statWeapons[%x]]);
			}
		}
	}
	//Save the client's Timers
	%word = -1;
	//echo("updating scores $Score::statTime");
	for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SavingTimers = $Score::SavingTimers@ %space @(%client.score[$Score::statTime[%x]] + gw($Score::SaveTimers, %word++));
	}
	//Save the client's Globals... might save prefs in here too
	%word = -1;
	//echo("updating scores $Score::GlobalStat");
	for(%x = 0; $Score::GlobalStat[%x] != -1 && $Score::GlobalStat[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SavingGlobals = $Score::SavingGlobals@ %space @(%client.score[$Score::GlobalStat[%x]] + gw($Score::SaveGlobals, %word++));
	}
	//prefs derp
	%word = -1;
	//echo("updating scores $Score::statPrefs");
	for(%x = 0; $Score::statPrefs[%x] != -1 && $Score::statPrefs[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SavingPrefs = $Score::SavingPrefs@ %space @%client.prefs[$Score::statPrefs[%x]];
		//echo($Score::statPrefs[%x]@" "@%client.prefs[$Score::statPrefs[%x]]);
	}
}



function Score::TempSave(%client)
{
	%filename = HoldIPTrim(Client::getTransportAddress(%client)) @ ".cs";
	%name = nameRepair(%client);


	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";

	%Batch = 0;

	%clientBackup = %client.TempScoreBackup;

	//for for for every weapon damage type/mode
	for(%a = 0; %a < 3; %a++)
	{
		%counter = -1;
		for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//General
		{
			%space = " ";	if(%counter == -1)	{	%space = "";	}
			%clientBackup.score[%Batch] = %clientBackup.score[%Batch]@ %space @%client.score[%type[%a], $Score::stat[%x]];
			%counter++;
			if(%counter == 14)
			{
				%Batch++;
				%counter = -1;
			}
		}
		for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
		{
			for(%y = -1; %y < 15; %y++)
			{
				%space = " ";	if(%y == -1)	{	%space = "";	}
				%clientBackup.score[%type[%a], $Score::statWeapons[%x]] =
				%clientBackup.score[%type[%a], $Score::statWeapons[%x]] @ %space @
				%client.score[%type[%a], $Score::statWeapons[%x], %y] ;
				eval("$Temp::SaveWeapon::" @ %filename @"[" @ %Batch @ "] = "@%save@";");
			}
		}
	}
	//Save the client's Timers
	for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Temp::SaveTimers = $Temp::SaveTimers@ %space @%client.score[$Score::statTime[%x]];
	}
	//Save the client's Globals... might save prefs in here too
	for(%x = 0; $Score::GlobalStat[%x] != -1 && $Score::GlobalStat[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Temp::SaveGlobals = $Temp::SaveGlobals@ %space @%client.score[$Score::GlobalStat[%x]];
	}
	for(%x = 0; $Score::statPrefs[%x] != -1 && $Score::statPrefs[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Temp::SavePrefs = $Temp::SavePrefs@ %space @%client.prefs[$Score::statPrefs[%x]];
		//echo($Score::statPrefs[%x]@" "@%client.prefs[$Score::statPrefs[%x]]);
	}
}

function Score::Load(%client)
{
	deleteVariables("$Score::Save*");
	deleteVariables("$Score::Saving*");
	%filename = HoldIPTrim(Client::getTransportAddress(%client)) @ ".cs";
	%client = %client.MainScoreBackup;

	if(isFile("temp\\" @ %filename))
	{
		echo("IsFile");

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;

		for(%retry = 1; %retry <= 10; %retry++)		//This might not be necessary, but it's to ensure that the
		{								//exec doesn't get flakey when there's lag.
			exec(%filename);
			if($Score::SavezSuccess)
					break;
		}
		if($Score::SavezSuccess)
		{

			//deleteVariables("$Score::Save*");
			%type[0] = "DL";
			%type[1] = "TD";
			%type[2] = "DM";
			%Batch = -1;


			for(%a = 0; %a < 3; %a++)
			{
				%counter = -1;
				%word = -1;
				%Batch++;
				//echo("updating scores "@%type[%a]@" $Score::stat");
				for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//General
				{
					%client.score[%type[%a], $Score::stat[%x]] = gw($Score::Save[%Batch], %word++);
					%counter++;
					//echo(%client@".score["@%type[2]@", "@$Score::stat[%x]@"]: "@%client.score[%type[2], $Score::stat[%x]]);
					//echo(%counter@" "@%word);
					if(%counter == "14")//keep variable length limited
					{
						%Batch++;
						%word = -1;
						%counter = -1;
					}
				}
				//echo("updating scores "@%type[%a]@" $Score::statWeapons");
				for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
				{
					%word = -1;
					for(%y = -1; %y < 15; %y++)
					{
						%client.score[%type[%a], $Score::statWeapons[%x], %y] = gw($Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]], %word++);
						//echo($Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]]);
					}
				}
			}
			%word = -1;
			//Load the client's Timers
			//echo("updating scores $Score::statTime");
			for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
			{
				%client.score[$Score::statTime[%x]] = gw($Score::SaveTimers, %word++);
			}
			%word = -1;
			//echo("updating scores $Score::GlobalStat");
			//Load the client's Globals... might save prefs in here too
			for(%x = 0; $Score::GlobalStat[%x] != -1 && $Score::GlobalStat[%x] != ""; %x++)//single simple types
			{
				%client.score[$Score::GlobalStat[%x]] = gw($Score::SaveGlobals, %word++);
			}
			%word = -1;
			//echo("updating scores $Score::statPrefs");
			//nm made it it's own thing
			for(%x = 0; $Score::statPrefs[%x] != -1 && $Score::statPrefs[%x] != ""; %x++)//single simple types... again for prefs
			{
				%client.prefs[$Score::statPrefs[%x]] = gw($Score::SavePrefs, %word++);
			}
		}
		else
		{
			echo("No SAVEZZ found!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		}
	}
	else
	{
		echo("No File found!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
	}
}
function Score::Save(%client)
{
	deleteVariables("$Score::Save*");
	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";
	%Batch = -1;

	//for for for every weapon damage type/mode
	for(%a = 0; %a < 3; %a++)
	{
		%counter = -1;
		%Batch++;
		for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//General
		{
			%space = " ";	if(%counter == -1)	{	%space = "";	}
			$Score::Save[%Batch] = $Score::Save[%Batch]@ %space @%client.score[%type[%a], $Score::stat[%x]];

			%counter++;
			if(%counter == 14)
			{
				echo("Batch incremented... last stat = "@$Score::stat[%x]);
				%Batch++;
				%counter = -1;
			}
		}
		for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
		{
			for(%y = -1; %y < 15; %y++)
			{
				%space = " ";	if(%y == -1)	{	%space = "";	}
				$Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]] =
				$Score::SaveWeapon[%type[%a], $Score::statWeapons[%x]] @%space@
				%client.score[%type[%a], $Score::statWeapons[%x], %y] ;
			}
		}
	}
	//Save the client's Timers
	for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SaveTimers = $Score::SaveTimers@%space@%client.score[$Score::statTime[%x]];
	}
	//Save the client's Globals... might save prefs in here too
	for(%x = 0; $Score::GlobalStat[%x] != -1 && $Score::GlobalStat[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SaveGlobals = $Score::SaveGlobals@%space@%client.score[$Score::GlobalStat[%x]];
	}
	for(%x = 0; $Score::statPrefs[%x] != -1 && $Score::statPrefs[%x] != ""; %x++)//single simple types
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		$Score::SavePrefs = $Score::SavePrefs@%space@%client.prefs[$Score::statPrefs[%x]];
		//echo($Score::statPrefs[%x]@" "@%client.prefs[$Score::statPrefs[%x]]);
	}
}

function resetClient(%client)
{
	%counter = 0;
	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";

	echo(running);
	for(%a = 0; %a < 3; %a++)
	{
		for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//weapon types
		{
			//echo("setting "@%type[%a]@" "@$Score::stat[%x]@" to "@%counter+1);
			%client.score[%type[%a], $Score::stat[%x]] = 0;
		}
		for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
		{
			for(%y = -1; %y < 15; %y++)
			{
				//echo("setting "@%type[%a]@" "@$Score::statWeapons[%x]@": weapon: "@%y@" to "@%counter+1);
				%client.score[%type[%a], $Score::statWeapons[%x], %y] = 0;
			}
		}
	}
	for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
	{
		%client.score[$Score::statTime[%x]] = 0;
	}
	for(%x = 0; ($Score::Globalstat[%x] != -1 && $Score::Globalstat[%x] != ""); %x++)
	{
		%client.score[$Score::Globalstat[%x]] = 0;
	}
	Client::PrefDefaults(%client);
}



function Client::PrefDefaults(%client)
{
	for(%x = 0; $Score::statPrefs[%x] != -1 && $Score::statPrefs[%x] != ""; %x++)
	{
		//echo("setting "@$Score::statPrefs[%x]@" to "@$Score::Defaultprefs[$Score::statPrefs[%x]]);
		%client.prefs[$Score::statPrefs[%x]] = $Score::Defaultprefs[$Score::statPrefs[%x]];
	}
}
function resetClientM(%client)
{
	%counter = 0;
	%type[0] = "DL";
	%type[1] = "TD";
	%type[2] = "DM";

	echo(running);
	for(%a = 0; %a < 3; %a++)
	{
		for(%x = 0; $Score::stat[%x] != -1 && $Score::stat[%x] != ""; %x++)//weapon types
		{
			//echo("setting "@%type[%a]@" "@$Score::stat[%x]@" to "@%counter+1);
			%client.score[%type[%a], $Score::stat[%x]] = %counter++;
		}
		for(%x = 0; $Score::statWeapons[%x] != -1 && $Score::statWeapons[%x] != ""; %x++)//weapon types
		{
			for(%y = -1; %y < 15; %y++)
			{
				if(%type[%a] == "TD")
				{
					//echo("setting "@%type[%a]@" "@$Score::statWeapons[%x]@": weapon: "@%y@" to "@%counter+1);
				}
				%client.score[%type[%a], $Score::statWeapons[%x], %y] = %counter++;
			}
		}
	}
	for(%x = 0; ($Score::statTime[%x] != -1 && $Score::statTime[%x] != ""); %x++)
	{
		%client.score[$Score::statTime[%x]] = %counter++;
	}
	for(%x = 0; ($Score::Globalstat[%x] != -1 && $Score::Globalstat[%x] != ""); %x++)
	{
		%client.score[$Score::Globalstat[%x]] = %counter++;
	}

	Client::PrefDefaults(%client);
}

function CleanupTimers(%cl)
{
	for(%a = 0; $Score::statTime[%a] != ""; %a++)
	{
		Stop::TimeTracker(%cl, $Score::statTime[%a]);
	}
}
function Start::TimeTracker(%cl, %stat)
{
	echo("Start time tracker... "@%stat@" Current time: "@getSimTime());
	%cl.score[%stat, "Start"] = getSimTime();
}
function Stop::TimeTracker(%cl, %stat)
{
	echo("Stop time tracker... "@%stat);
	if(%cl.score[%stat, "Start"] != "")
	{
		echo("Stop time tracker...finalizing..Current time: "@getSimTime());
		%cl.score[%stat] += (getSimTime() - %cl.score[%stat, "Start"]);
		%cl.score[%stat, "Start"] = "";
	}
}

function Score::Update::OnDamageStats(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %weaponType, %Rawvalue, %Realvalue, %vertPos, %spillOver, %absorbed)
{
	//both("damagedClient "@%damagedClient@" attacker "@%shooterClient@" damageType "@%type@" Rawvalue "@%Rawvalue @" new Realvalue "@%Realvalue@" vertpos "@%vertpos@" spillover "@%spillOver@" absorbed"@ %absorbed);
	//if(%Realvalue < 0.001 && %Rawvalue != "0")
	//	%Realvalue = 0.001;

	//if(%Rawvalue == "0")
	//	%Realvalue = 0;
	//if(%vertpos == "head" && %damagedClient != %shooterClient)
	//{
	//	Score::IncreaseStat(%shooterClient, "HeadShots", 1, %playType, %weaponType);
	//}

	%playType = GetPlayType(%damagedClient);

	if(%absorbed > 0)
	{
		Score::IncreaseStat(%damagedClient, "SelfShieldHitsAbsorbed", 1, %playType, %weaponType);
		Score::IncreaseStat(%damagedClient, "SelfShieldDamageAbsorbed", %absorbed, %playType, %weaponType);
		if(%damagedClient != %shooterClient)
		{
			Score::IncreaseStat(%shooterClient, "DamageToEnemyShields", %absorbed, %playType, %weaponType);
			Score::IncreaseStat(%shooterClient, "HitsToEnemyShields", 1, %playType, %weaponType);
		}
	}
	if(%spillOver > 0)
	{
		if(%damagedClient != %shooterClient)
		{
			Score::IncreaseStat(%shooterClient, "OverKill", %spillOver, %playType, %weaponType);
		}
		Score::IncreaseStat(%damagedClient, "OverKilled", %spillOver, %playType, %weaponType);
	}
	if(%damagedClient == %shooterClient && %RealValue > 0)
	{
		Score::IncreaseStat(%damagedClient, "SelfdmgReceived", %Realvalue, %playType, %weaponType);
		Score::IncreaseStat(%damagedClient, "SelfHitsReceived", 1, %playType, %weaponType);
	}
	if(%damagedClient != %shooterClient)
	{
		Score::IncreaseStat(%shooterClient, "dmgDone", %Realvalue, %playType, %weaponType);
		Score::IncreaseStat(%shooterClient, "dmgDoneSpot"@%vertpos, %Realvalue, %playType, %weaponType);
		Score::IncreaseStat(%shooterClient, "HitsDone", 1, %playType, %weaponType);
		Score::IncreaseStat(%shooterClient, "HitsDoneSpot"@%vertpos, 1, %playType, %weaponType);

		%shooterClient.ThisRoundTotalDamageDone += %Realvalue;
		%shooterClient.ThisRoundTotalHitsDone++;

		%shooterClient.ThisRoundDamageDone[%weaponType] += %Realvalue;
		%shooterClient.ThisRoundHitsDone[%weaponType]++;
		%damagedClient.ThisRoundDamageTaken[%weaponType] += %Realvalue;
		%damagedClient.ThisRoundHitsTaken[%weaponType]++;

		%damagedClient.ThisRoundTotalDamageTaken += %Realvalue;
		%damagedClient.ThisRoundTotalHitsTaken++;
		Score::CompareStat(%damagedClient, "MostHitsTakenPerRound", %shooterClient.ThisRoundTotalHitsDone, %playType);

		Score::CompareStat(%shooterClient, "MostDMGPerRound", %shooterClient.ThisRoundTotalDamageDone, %playType);
		Score::CompareStat(%shooterClient, "MostHitsPerRound", %shooterClient.ThisRoundTotalHitsDone, %playType);

		%shooterClient.ThisRoundDamagedDoneID[%damagedClient] += %Realvalue;
		%shooterClient.ThisRoundHitsDoneID[%damagedClient]++;

		if(%Realvalue > 0)
		{
			Score::IncreaseStat(%damagedClient, "dmgReceived", %Realvalue, %playType, %weaponType);
			Score::IncreaseStat(%damagedClient, "dmgReceivedSpot"@%vertpos, %Realvalue, %playType, %weaponType);
			Score::IncreaseStat(%damagedClient, "HitsReceived", 1, %playType, %weaponType);
			Score::IncreaseStat(%damagedClient, "HitsReceivedSpot"@%vertpos, 1, %playType, %weaponType);
		}
	}

	Score::CompareStat(%damagedClient, "MostDMGTakenPerRound", %shooterClient.ThisRoundTotalDamageDone, %playType);

	%distance = floor(Vector::getDistance(GameBase::getPosition(%damagedClient.owns), GameBase::getPosition(%shooterClient.owns)) + 0.5) ;

	if(%shooterClient != %damagedClient && %weaponType > 0)
		UpDateObservers(%shooterClient, %Realvalue, %distance);
}