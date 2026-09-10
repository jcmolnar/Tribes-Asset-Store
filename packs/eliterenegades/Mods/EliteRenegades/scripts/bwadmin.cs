// - Ren BW Admin -
$bwadmin::version = "v5.01";
$bwadmin:supportversion = "5.0";
$bwadmin::tribesVersion = "v1.11";

$bwadmin::rentypeV = "0.5 (s)";

// =================== Script Support Evals ==============


	//Client side script can check for bwadmin support and returns
	//the support version in format "5.0"
function remotebwadmin::isCompatible(%client, %clientId)
{
	remoteEval(%client, bwadmin::Compatible, $bwadmin:supportversion);
}


	//This function allows the clientside script to enable eval support for
	//differing things.   eg.  ping times, objective info, etc
function remotebwadmin::EnableSupport(%client,%clientId,%type)
{
	if(%type == "ObjectiveInfo") {
		%client.reg = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else remoteEval(%client, bwadmin::SupportVerify, %type, false);
}



	//Returns true when player becomes pilot and false when he stops being a pilot
	//for whatever reason  ie. death, dismount, etc.
function bwadmin::isPilotInfoActive(%client, %active)
{
	if(%client.PilotInfoActive)
	{
		remoteEval(%client, bwadmin::PilotingInfo, %active);
	}
}


	//Returns the killer, the victim and the weapon used.  If player killed himslef weapon
	//will be returned as "Suicide".
function bwadmin::isKillInfoActive(%client, %killerid, %victimid, %weapontype)
{
	if(%client.KillInfoActive)
	{
		if(%weapontype == $LandingDamageType)
			%weapon = "Landing";
		else if(%weapontype == $ImpactDamageType)
			%weapon = "Impact"; //collisiion with vehicle
		else if(%weapontype == $BulletDamageType)
			%weapon = "Chaingun";
		else if(%weapontype == $EnergyDamageType)
			%weapon = "Turret";
		else if(%weapontype == $PlasmaDamageType)
			%weapon = "Plasma";
		else if(%weapontype == $ExplosionDamageType)
			%weapon = "Disc"; //Disc Launcher
		else if(%weapontype == $ShrapnelDamageType)
			%weapon = "Grenade";  //Grenade Launcher
		else if(%weapontype == $LaserDamageType)
			%weapon = "Laser";
		else if(%weapontype == $MortarDamageType)
			%weapon = "Mortar";
		else if(%weapontype == $BlasterDamageType)
			%weapon = "Blaster";
		else if(%weapontype == $ElectricityDamageType)
			%weapon = "ELF";  //Elf gun and elf turret
		else if(%weapontype == $CrushDamageType)
			%weapon = "Crush";  //Elevators, etc
		else if(%weapontype == $DebrisDamageType)
			%weapon = "Debris"; //Exploding vehicles, invs, etc
		else if(%weapontype == $MissileDamageType)
			%weapon = "Missle";  //Flyer and turret missles
		else if(%weapontype == $MineDamageType)
			%weapon = "Mine";  //Mines and Grenades
		remoteEval(%client, bwadmin::KillInfo, %killerid, %victimid, %weapon);
	}
}


	//Informs the client what weapon has been changed too OR when there is
	//no weapon mounted...ie inv   this is for use with reticle swapping
	//Will return "none" if no wepaon mounted
function bwadmin::isWeaponChangeInfoActive(%client, %weapon)
{
	if(%client.WeaponChangeInfoActive)
	{
		remoteEval(%client, bwadmin::WeaponChangeInfo, %weapon);
	}
}


	// Function tells client that has compatible script pack whether
	// they are at a normal or deployable station and, if deployable,
	// number of health kits that are needed to be bought to be full health
function bwadmin::isDeployableStationType(%client, %type)
{
	if(%client.StationTypeActive)
	{
		%playerId = Client::getOwnedObject(%client);
		%dlevel = GameBase::getDamageLevel(%playerId);
		if(Player::getItemClassCount(%client, "RepairKit") == 0)
			%repkits = 1;
		else
			%repkits = 0;
		if(%dlevel == 0)
			%noofkits = floor(%dlevel/0.2)+%repkits;
		else
			%noofkits = floor(%dlevel/0.2)+1+%repkits;
		remoteEval(%client, bwadmin::StationInfo, %type, %noofkits);
	}
}

	//Function returns status of objectives
function bwadmin::ObjList(%client)
{
   if(!%client.reg)
      return;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   %num = Group::objectCount(%group);
   for(%i = 0; %i < %num; %i++)
      {
         %obj = Group::getObject(%group, %i);
         %team = GameBase::getTeam(%obj);
         %teamName = getTeamName(%team);
         if(%obj.objectiveName != "")
            %objName = %obj.objectiveName;
         else
            %objName = %teamName @ " flag";

         if(%obj.holdingTeam != -1)
            %status = getTeamName(%obj.holdingTeam);
         else if(%obj.carrier != -1)
            %status = Client::getName(Player::getClient(%obj.carrier));
         else if(%obj.atHome)
            %status = "home";
         else
            %status = "dropped";
         if(getObjectType(%obj) != "Item")
            %status = %teamName;
         %type = gamebase::getdataname(%obj);
         remoteEval(%client, bwadmin::setObjList, %i, %num, %objName, %type, %status);
      }
}

	//Function returns players scores
function bwadmin::playerScoreList(%client)
{
   %num = getNumClients();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %team = Client::getTeam(%cl);
      remoteEval(%client, bwadmin::setPlayerScoreList, %num, %team, %cl, %cl.score);
   }
}



//============== Client Requestable Evals ====================================

	//returns the ave ping in last 10 seconds for clientId to client
function remotebwadmin::getPlayerPing(%client,%clientId)
{
	remoteEval(%client, bwadmin::PlayerPing, %clientId, $AvePing[%clientId]);
}

	//Returns the ave ping for team number %team in last 10 seconds....
	//A value of 999 means No Ping calculated or no players on team
function remotebwadmin::getTeamPing(%client,%team)
{
	remoteEval(%client, bwadmin::TeamPing, %team, $TeamPing[%team]);
}


	//Returns ave server ping in last 10 seconds
function remotebwadmin::getServerPing(%client)
{
	remoteEval(%client, bwadmin::ServerPing, $ServerAvPing);
}

function remotebwadmin::teamScoreList(%client)
{
   %num = getNumTeams();
   for(%i = 0; %i < %num ; %i++)
      remoteEval(%client, bwadmin::setTeamScoreList, %i, %num, getTeamName(%i), bwadmin::numTeamPlayers(%i), $teamScore[%i], $teamScoreLimit);
}



// ===================Legacy Reporting Functions==========

function remotebwadmin::reg(%client)
{
   if(%client.reg)
   {
      Client::sendMessage(%client,1,"You are already registered for BWAdmin server info.");
      return;
   }
   Client::sendMessage(%client,1,"BWAdmin server info registration accepted!");
   %client.reg = true;
   bwadmin::ObjList(%client);
   remotebwadmin::teamScoreList(%client);
   bwadmin::playerScoreList(%client);
}

function bwadmin()
{
	echo("BarrysWorld Admin Mod " @ $bwadmin::version @ " for Tribes " @ $bwadmin::tribesVersion @ " by Poker");
}

function bwadmin::reportScores()
{
	if($bwadmin::reportScores)
	{
	  for(%i = 0; %i < getNumTeams() ; %i++)
	   TeamMessages(0, -1, "Team " @ %i @ ": " @ getTeamName(%i) @ "   Score: " @ $teamScore[%i]);
	  TeamMessages(0, -1, "Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.");
	}
}

function remotebwadmin::getMatchInfo(%client)
{
	%time = floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60);
	for(%i = 0; %i < getNumTeams() ; %i++)
	   remoteEval(%client, "bwadmin::setMatchInfo", %time, %i, getTeamName(%i), bwadmin::numTeamPlayers(%i), $teamScore[%i]);
}

// =================Ping Time Functions====================================

function remotePingTime(%client, %start)
{
	if(%start > 0)
	{
		if($PingNo[%client] < 10)
		{
			$PingNo[%client]++;
			$PingTime[%client,$PingNo[%client]] = floor((getSimTime() - %start)*1000);
		}
		else
		{
			$StartPingCalc[%client] = true;
			$PingNo[%client] = 1;
			$PingTime[%client,$PingNo[%client]] = floor((getSimTime() - %start)*1000);
		}
		if($StartPingCalc[%client])
		{
			for(%i=1;%i<11;%i++)
			{
				%clientpingtotal = %clientpingtotal + $PingTime[%client,%i];
			}
			$AvePing[%client] = %clientpingtotal / 10;
		}
		else
		{
			for(%i=1;%i<=$PingNo[%client];%i++)
			{
				%clientpingtotal = %clientpingtotal + $PingTime[%client,%i];
			}
			$AvePing[%client] = %clientpingtotal / $PingNo[%client];
		}
	}
}


function CalculatePings()
{
	//Get Client Pings every second
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%start=getSimTime();
		remoteEval (%cl, eval, PingTime, %start);
	}
	//calculate team ping average
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl != -1)
		{
			%team = GameBase::getTeam(%cl);
			%TeamPingTotal[%team] = %TeamPingTotal[%team] + $AvePing[%cl];
			%TeamClients[%team]++;
			%ServerPingTotal = %ServerPingTotal + $PingTime[%cl];
			%ServerClients++;

			if($bwadmin::PingAbove > 0)
			{
				if($AvePing[%cl] < $bwadmin::PingAbove)
				{
					%cl.pingabovecheck++;
					if(%cl.pingabovecheck >= 16)
					{
						Admin::kick(-3, %cl);
					}
				}
				else
					%cl.pingabovecheck = 0;
			}
		}
	}
	for(%i = 0; %i < getNumTeams(); %i++)
	{
		if(%TeamClients[%i] > 0)
			$TeamPing[%i] = floor(%TeamPingTotal[%i] / %TeamClients[%i]);
		else
			$TeamPing[%i] = 999;
	}

	//Calc Server Ave Pings
	$ServerAvPing = floor(%ServerPingTotal / %ServerClients);
	schedule("CalculatePings();",1);
}


// ===================Admin Functions===================

function remotebwadmin::getPlayerList(%client)
{
	if(!%client.isSuperAdmin)
		return;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%ip = Client::getTransportAddress(%cl);
		remoteEval(%client, bwadmin::setPlayerList, %cl, %ip, $Client::info[%cl, 1], $Client::info[%cl, 2], $Client::info[%cl, 3], $Client::info[%cl, 4], $Client::info[%cl, 5]);
	}
}

// ===================Utility Functions===================

function bwadmin::numTeamPlayers(%team)
{
    %numPlayers = getNumClients();
    %numTeamPlayers[%team] = 0;
    for(%i = 0; %i < %numPlayers; %i = %i + 1)
    {
       %pl = getClientByIndex(%i);
       %team2 = Client::getTeam(%pl);
       %numTeamPlayers[%team2] = %numTeamPlayers[%team2] + 1;
    }
    return %numTeamPlayers[%team];
}

function bwadmin::getLowTeam()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         %team = Client::getTeam(%pl);
         %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if(%numTeamPlayers[%i] < %leastPlayers)
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      return %leastTeam;
}

//======================  NICK SERVER ==============================

function bwadmin::nickServ(%clientId)
{
   %name = Client::getName(%clientId);

   for(%i=1;%i < $UserList::MaxUsers+1;%i++)
   {
      if(%name == $UserList::UserName[%i] && $UserList::NickServ[%i] == true)
      {
         centerprint(%clientId, "Your player name is reserved on this server.  You MUST log in within 60 seconds.", 5);
         schedule("bwadmin::nickWarn(" @ %clientId @ ");", 30, %clientId);
         schedule("bwadmin::nickKick(" @ %clientId @ ");", 60, %clientId);
      }
   }
}

function bwadmin::nickWarn(%clientId)
{
   	if(!%clientId.AdminVerified)
   	{
      	centerprint(%clientId, "Your player name is reserved on this server.  You MUST log in within 30 seconds.", 5);
	}
}

function bwadmin::nickKick(%clientId)
{
   if(!%clientId.AdminVerified)
      Net::kick(%clientId, "BWAdmin:: That player name is reserved on this server, please choose another.");
}

// ===================Observer Functions===================

function bwadmin::checkObserved(%flag, %player)
{
	echo("|||||||||||||| bwadmin::checkObserved("@%flag@", "@%player@")");
   for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
   {
      if((%client.observerTarget == %flag || %client.observerTarget == %player) && %client.observerMode == "observerObjectiveOrbit")
      {
         %target = %flag.carrier;
         if(%target == "-1" || %player == "-1")
            Observer::setTargetClient(%client, %flag);
         else
            Observer::setTargetClient(%client, %player);
      }
	else Observer::setTargetClient(%client, %flag);
   }
}

function bwadmin::obsObj(%client, %target)
{
   %group = nameToID("MissionCleanup/ObjectivesSet");
   if(%target == "")
      %target = getNextObject(%group, 0);
   %num = Group::objectCount(%group);

   for(%i = 0; %i < %num; %i++)
   {
      if(%target == Group::getObject(%group, %i))
      {
         %carrier = %target.carrier;
         if(%carrier != "" && %carrier != "-1")
            %target = %carrier;
         %client.observerMode = "observerObjectiveOrbit";
         Observer::setTargetClient(%client, %target);
      }
   }
}

function bwadmin::nextObsObj(%client)
{
   if(%client.observerMode == "observerObjectiveOrbit" && getObjectType(%client.observerTarget) == "Player")
   {
      %target = %client.observerTarget;
      %lastObserved = %target.carryFlag;
   }
   else
      %lastObserved = %client.observerTarget;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   %nextObserved = getNextObject(%group, %lastObserved);
   if(!%nextObserved)
      %nextObserved = Group::getObject(%group, 0);
   %client.observerMode = "observerObjectiveOrbit";
   %carrier = %nextObserved.carrier;
   if(%carrier != "-1" && %carrier != "")
      %nextObserved = %carrier;
   Observer::setTargetClient(%client, %nextObserved);
}


// ==============Remote Observer Functions===================


function remotebwadmin::zoom(%client, %zoom)
{
   if(Client::getTeam(%client) != -1 || %zoom == "")
      return;
   if(%client.observerMode == "observerObjectiveOrbit" && %zoom < 5)
      %zoom = 5;
   if(%zoom > 50)
      %zoom = 50;
   %client.zoom = %zoom;
   if(%client.observerTarget != "" && (%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit"))
      Observer::setTargetClient(%client, %client.observerTarget);
}

function remotebwadmin::observePlayer(%client, %target)
{
   if(Client::getTeam(%client) != -1)
      return;
   if(%target == "")
   {
      if(%client.observerMode == "observerFly")
      {
         Observer::jump(%client);
         return;
      }
      if(%client.observerMode == "observerObjectiveOrbit")
      {
         %client.observerTarget = %client;
         %client.observerMode = "observerOrbit";
         Observer::nextObservable(%client);
         return;
      }
      return false;
   }
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1)
      return false;
   %client.observerMode = "observerOrbit";
   Observer::setTargetClient(%client, %target);
}

function bwadmin::setObserved(%client, %menu)
{
   if(!%client.reg && !%menu)
      return;
   %target = %client.observerTarget;

   if(%client.observerMode == "observerObjectiveOrbit")
   {
      if(getObjectType(%target) != "Player")
      {
         %team = GameBase::getTeam(%target);
         %teamName = getTeamName(%team);
         if(%teamName == "unnamed")
            %observedName = %target.objectiveName;
         else if(getObjectType(%target) != "Item")
            %observedName = %target.objectiveName @ " (" @ %teamName @ ")";
         else
            %observedName = %teamName @ " " @ gamebase::getdataname(%target);
      }
      else
      {
         %flag = %target.carryFlag;
         %team = GameBase::getTeam(%flag);
         %teamName = getTeamName(%team);
         %cl = Player::getClient(%target);
         %name = Client::getName(%cl);
         if(%teamName == "unnamed")
            %observedName = %flag.objectiveName @ " (" @ %name @ ")";
         else
            %observedName = %teamName @ " " @ gamebase::getdataname(%flag) @ " (" @ %name @ ")";
      }
   }
   else
      %observedName = Client::getName(%target);
   if(%client.reg)
      remoteEval(%client, bwadmin::observed, %observedName, %client.zoom);
   if(%observedName != "")
      bottomprint(%client, "<jc>Observing " @ %observedName, 5);
}

// legacy support
function remotebwadmin::observeFlag(%client, %team)
{
   if(Client::getTeam(%client) != -1 || %team == "")
      return;
   %teamName = getTeamName(%team);
   %targetName = %teamName @ " flag";
   remotebwadmin::observeObjective(%client, %targetName);
}


function remotebwadmin::observeObjective(%client, %targetName)
{
   if(Client::getTeam(%client) != -1)
      return;

   %group = nameToID("MissionCleanup/ObjectivesSet");
   %num = Group::objectCount(%group);

   if(%targetName == "")
   {
      bwadmin::obsObj(%client);
      return;
   }
   for(%i = 0; %i < %num; %i++)
   {
      %obj = Group::getObject(%group, %i);
      %team = GameBase::getTeam(%obj);
      %teamName = getTeamName(%team);

      if((%targetName == %obj.objectiveName || %targetName == %teamName @ " flag") && %obj != %client.observerTarget)
      {
         bwadmin::obsObj(%client, %obj);
         return;
      }
   }
}

function remotebwadmin::observerFreeFly(%client)
{
   if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit")
   {
      %client.observerTarget = "";
      %client.observerMode = "observerFly";
      %cam = Client::getObserverCamera(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%cam), GameBase::getRotation(%cam), true, true);
      if(%client.reg)
         bwadmin::setObserved(%client);
   }
}

function bwadmin::getNearestPlayer(%clientId)
{

		%cam = Client::getObserverCamera(%clientId);
		%pos = GameBase::getPosition(%cam);
		%leastDist = 5000;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl != %clientId.observerTarget)
			{
				%player = Client::getOwnedObject(%cl);
	   			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %player != %clientId.observerTarget)
	   			{
					%playerPos = GameBase::getPosition(%player);
					%dist = Vector::getDistance(%pos, %playerPos);
					if(%dist < %leastDist)
					{
						%leastDist = %dist;
						%nearest = %cl;
					}
				}
			}
		}
		echo("DEBUG::" @ %nearest);
		return %nearest;

}

function remotebwadmin::observeNearestPlayer(%client)
{
	if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit" || %client.observerMode == "observerFly")
	{
		%client.observerMode = "observerOrbit";
		%player = bwadmin::getNearestPlayer(%client);
		Observer::setTargetClient(%client, %player);
	}
}

