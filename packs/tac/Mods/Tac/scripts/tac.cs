$TAC::version = "v 1.41";
$TAC::tribesVersion = "v1.11";
$bwadmin:supportversion = "5.0";

// ===================Default Settings===================

$TAC::league = "League";
$TAC::defaultTribeSkin[0] = "beagle";
$TAC::defaultTribeSkin[1] = "dsword";
$TAC::defaultTribeSkin[2] = "cphoenix";
$TAC::defaultTribeSkin[3] = "swolf";

exec("tac_settings.cs");

// ===================Legacy Reporting Functions==========

function tac()
{
	echo("Team Aerial Combat (TAC) Mod " @ $TAC::version @ " for Tribes " @ $TAC::tribesVersion);
}

function TAC::reportScores()
{
	if($TAC::reportScores)
	{
	  for(%i = 0; %i < getNumTeams() ; %i++)
	   TeamMessages(0, -1, "Team " @ %i @ ": " @ getTeamName(%i) @ "   Score: " @ $teamScore[%i]);
	  TeamMessages(0, -1, "Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.");
	}
}

function remoteTAC::getMatchInfo(%client)
{
	%time = floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60);
	for(%i = 0; %i < getNumTeams() ; %i++)
	   remoteEval(%client, "TAC::setMatchInfo", %time, %i, getTeamName(%i), TAC::numTeamPlayers(%i), $teamScore[%i]);
}



// =================== Script Support Evals ==============

	//Client side script can check for bwadmin support and returns
	//the support version in format "5.0"
function remotebwadmin::isCompatible(%client, %clientId)
{
	echo("Server Echo",%client,"  ", %clientid,"  ",$bwadmin:supportversion);
	remoteEval(%client, bwadmin::Compatible, $bwadmin:supportversion);
}

	//This function allows the clientside script to enable eval support for
	//differing things.   eg.  ping times, objective info, etc
function remotebwadmin::EnableSupport(%client,%clientId,%type)
{
	if(%type == "StationType")
	{
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
	}
	else if(%type == "ObjectiveInfo")
	{
		%client.reg = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
	}
	else if(%type == "PilotingInfo")
	{
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
	}
	else if(%type == "KillInfo")
	{
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
	}
	else if(%type == "WeaponChangeInfo")
	{
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
	}
	else
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
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
      remoteEval(%client, bwadmin::setTeamScoreList, %i, %num, getTeamName(%i), TAC::numTeamPlayers(%i), $teamScore[%i], $teamScoreLimit);
}




// ===================Admin Functions===================

function remotebwadmin::getPlayerList(%client)
{
	if(!%client.AdminServerSettings)
		return;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%ip = Client::getTransportAddress(%cl);
		remoteEval(%client, bwadmin::setPlayerList, %cl, %ip, $Client::info[%cl, 1], $Client::info[%cl, 2], $Client::info[%cl, 3], $Client::info[%cl, 4], $Client::info[%cl, 5]);
	}
}

function remotebwadmin::teamSwap(%client, %swap)
{
   if(%client.AdminServerSettings)
   {
      if(%swap && $TAC::teamSwap)
         return;
      if(%swap && !$TAC::teamSwap)
      {
         $TAC::teamSwap = true;
         messageAll(0, Client::getName(%client) @ " set Team Swap to ON.");
         return;
      }
      if($TAC::teamSwap)
      {
         $TAC::teamSwap = "";
         messageAll(0, Client::getName(%client) @ " set Team Swap to OFF.");
      }
   }
}

// ===================Utility Functions===================

function TAC::numTeamPlayers(%team)
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

function TAC::getLowTeam()
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

// ===================Long Walk Functions===================


function TAC::walk::energysuck(%carrier)
{
	if(%carrier.carryFlag)
	{
		GameBase::setEnergy(%carrier,0);
		schedule("TAC::walk::energysuck(" @ %carrier @ ");", 0.5);
		return;
	}
}

function TAC::walk::checkForBuddy(%this)
{
	%client = Player::getClient(%this);
	%clientTeam = Client::getTeam(%client);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%clTeam = Client::getTeam(%cl);
		if(%client != %cl && %clientTeam == %clTeam)
		{
			%player = Client::getOwnedObject(%cl);
   			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   			{

   				%carrierPos = GameBase::getPosition(%this);
         			%buddyPos = GameBase::getPosition(%player);
   				%dist = Vector::getDistance(%carrierPos, %buddyPos);
				if(%dist <= 40)
  				   return true;
			}

		}
	}
	return false;
}


// ===================Observer Functions===================

function TAC::checkObserved(%flag, %player)
{
   for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
   {
      if((%client.observerTarget == %flag || %client.observerTarget == %player) && %client.observerMode == "observerObjectiveOrbit")
      {
         %target = %flag.carrier;
         if(%target == "-1")
            Observer::setTargetClient(%client, %flag);
         else
            Observer::setTargetClient(%client, %player);
      }
   }
}

function TAC::obsObj(%client, %target)
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

function TAC::nextObsObj(%client)
{
   if(%client.PilotView != "")
   		return;

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
   if(%zoom > 30)
      %zoom = 30;
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

function TAC::setObserved(%client)
{
   if(!%client.reg)
      return;
   %target = %client.observerTarget;

   if(%client.observerMode == "observerObjectiveOrbit")
   {
      if(getObjectType(%target) != "Player")
      {
         %team = GameBase::getTeam(%target);
         %teamName = getTeamName(%team);
         if(%teamName == "unnamed")
            bottomprint(%client, "<jc>Observing " @ %target.objectiveName, 5);
         else if(getObjectType(%target) != "Item")
            bottomprint(%client, "<jc>Observing " @ %target.objectiveName @ " (" @ %teamName @ ")", 5);
         else
            bottomprint(%client, "<jc>Observing " @ %teamName @ " " @ gamebase::getdataname(%target), 5);
      }
      else
      {
         %flag = %target.carryFlag;
         %team = GameBase::getTeam(%flag);
         %teamName = getTeamName(%team);
         %cl = Player::getClient(%target);
         %name = Client::getName(%cl);
         if(%teamName == "unnamed")
            bottomprint(%client, "<jc>Observing " @ %flag.objectiveName @ " (" @ %name @ ")", 5);
         else
            bottomprint(%client, "<jc>Observing " @ %teamName @ " " @ gamebase::getdataname(%flag) @ " (" @ %name @ ")", 5);
      }
   }
   else
      %observedName = Client::getName(%target);
   remoteEval(%client, bwadmin::observed, %observedName, %client.zoom);
}

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
      TAC::obsObj(%client);
      return;
   }
   for(%i = 0; %i < %num; %i++)
   {
      %obj = Group::getObject(%group, %i);
      %team = GameBase::getTeam(%obj);
      %teamName = getTeamName(%team);

      if((%targetName == %obj.objectiveName || %targetName == %teamName @ " flag") && %obj != %client.observerTarget)
      {
         TAC::obsObj(%client, %obj);
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
         TAC::setObserved(%client);
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


// ==============Remote Info Functions===================

function remoteBWAdmin::reg(%client)
{
   if(%client.reg)
   {
      Client::sendMessage(%client,1,"You are already registered for TAC server info.");
      return;
   }
   Client::sendMessage(%client,1,"TAC server info registration accepted!");
   %client.reg = true;
   BWAdmin::ObjList(%client);
   remoteBWAdmin::teamScoreList(%client);
   BWAdmin::playerScoreList(%client);
}

function BWAdmin::ObjList(%client)
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
         remoteEval(%client, TAC::setObjList, %i, %num, %objName, %type, %status);
      }
}

function BWAdmin::playerScoreList(%client)
{
   %num = getNumClients();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %team = Client::getTeam(%cl);
      remoteEval(%client, TAC::setPlayerScoreList, %num, %team, %cl, %cl.score);
   }
}

function remoteBWAdmin::teamScoreList(%client)
{
   %num = getNumTeams();
   for(%i = 0; %i < %num ; %i++)
      remoteEval(%client, BWAdmin::setTeamScoreList, %i, %num, getTeamName(%i), TAC::numTeamPlayers(%i), $teamScore[%i]);
}

//---------- Map Rotation Mod Functions ------------------
// Map Rotation by Mental Trousers

$MR::numOfRatings=5;
$mapRating::["verypopular"]=1;
$mapRating::["popular"]=2;
$mapRating::["average"]=3;
$mapRating::["unpopular"]=4;
$mapRating::["neverplay"]=5;
$MR::noRepeatForNMaps=5;  //don't play the same map for at least this number of maps
$MR::exportMapList=false;
$MR::numOfChoices=4;

function TAC::MRsetRating(%map, %rating)
{
	$MR::rating[%map]=$mapRating::[%rating];
}

function MR::nextMission()
{
	if ((%rating=getWord($TAC::MRratioString, $MR::currentPos))==-1)
		{
			%rating=getWord ($TAC::MRratioString, 0);
			$MR::currentPos=0;
		}
	else
		$MR::currentPos++;

	%map=$MR::current[%rating];
	$MR::current[%rating]=$MR::missionList[$MR::current[%rating]];
	return %map;
}

function MR::getMapRating (%map)
{
	return $MR::rating[%map];
}

function MR::setLastMap()
{
	for (%i=1;%i<$MR::numOfRatings; %i++)
		{
		$MR::missionList[$MR::current[%i]]=$MR::firstMap[%i];
		}
}

function MR::missionList()
{
	%index=1;
	while ((%map=$MLIST::EName[%index])!="")
		{
		if ($MLIST::EType [%index]=="TAC")
			{
			if ((%rating=MR::getMapRating(%map))=="")
				%rating=3;

			if ($MR::firstMap[%rating]=="")
				$MR::firstMap[%rating]=%map;

			$MR::missionList[$MR::current[%rating]]=%map;
			$MR::current[%rating]=%map;
			echo ("$MR::current["@%rating@"]="@$MR::current[%rating]);
			}
		%index++;
		}
	MR::setLastMap();
}

function TAC::MRtest(%noofmaps)
{
	if(%noofmaps == "")
		%noofmaps = 100;
	for (%i=1;%i<=%noofmaps;%i++)
		echo(MR::nextMission ());
}

function MR::initialiseMapRotation()
{
	if ($MLIST::Count<1)
		return false;

	%first=file::findFirst("missions\\*.dsc");
	if (%first!="")
		MR::missionList();
	else
		echo ("Invalid missions - unable to assemble missionList");

	if ($MR::exportMapList)
		export("$MR::missionList*", "config\\MRmaps.cs", false);
}

exec("tac_mapratings.cs");
$MR::currentPos=0;

MR::initialiseMapRotation();

//-------------------------------------------------------------------------
// TAC CLIENT PACK SUPPORT
//

function remoteIsTAC(%client,%clientId,%passengerhud,%pilothud)
{
	if(%passengerhud)
		%clientId.passengerHUD = true;
	if(%pilothud)
		%clientId.pilotHUD = true;
	remoteEval(%clientId, RunTACClient);
}

function remotePilotView(%clientId)
{
	if (%clientId=="")
		return;
	%playerId = Client::getOwnedObject(%clientId);
	if(%playerId.driver == 1)
	{
		Client::setControlObject(%clientId, %playerId.vehicle);
		%clientId.lastControlObject = "";
		%clientId.observerMode = "";
		%clientId.observerTarget = "";
		%clientId.PilotView = "";
		%newRot="0 0 0";
		GameBase::setRotation (%clientId, %newRot);
	}
}

function remoteRearPilotView(%clientId)
{
	if (%clientId=="")
		return;
	%playerId = Client::getOwnedObject(%clientId);
	%rotation = GameBase::getRotation(%clientId);
	%diffrotx = (getWord(%rotation, 0) * -1);
	%diffroty = (getWord(%rotation, 1) * -1);
	if((%playerId.driver == 1) && (Client::getControlObject(%clientId) == %playerId.vehicle))
	{
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, -3, -3, -3);
		GameBase::setRotation (%clientId, %diffrotx @ " " @ %diffroty @ " 3.14");
		%clientId.lastControlObject = Client::getControlObject(%clientId);
		%clientId.observerMode = "observerOrbit";
		%clientId.PilotView = "rear";
		%clientId.observerTarget=%clientId;
	}
}

function remoteLeftPilotView(%clientId)
{
	if (%clientId=="")
		return;
	%playerId = Client::getOwnedObject(%clientId);
	%rotation = GameBase::getRotation (%clientId);
	%diffrotx = (getWord(%rotation, 0) * -1);
	%diffroty = (getWord(%rotation, 1) * -1);
	if((%playerId.driver == 1) && (Client::getControlObject(%clientId) == %playerId.vehicle))
	{
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, -3, -3, -3);
		GameBase::setRotation (%clientId, %diffrotx @ " " @ %diffroty @ " 1.57");
		%clientId.lastControlObject = Client::getControlObject(%clientId);
		%clientId.observerMode = "observerOrbit";
		%clientId.PilotView = "left";
		%clientId.observerTarget=%clientId;
	}
}

function remoteRightPilotView(%clientId)
{
	if (%clientId=="")
		return;
	%playerId = Client::getOwnedObject(%clientId);
	%rotation = GameBase::getRotation (%clientId);
	%diffrotx = (getWord(%rotation, 0) * -1);
	%diffroty = (getWord(%rotation, 1) * -1);
	if((%playerId.driver == 1) && (Client::getControlObject(%clientId) == %playerId.vehicle))
	{
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, -3, -3, -3);
		GameBase::setRotation (%clientId, %diffrotx @ " " @ %diffroty @ " -1.57");
		%clientId.lastControlObject = Client::getControlObject(%clientId);
		%clientId.observerMode = "observerOrbit";
		%clientId.PilotView = "right";
		%clientId.observerTarget=%clientId;
	}
}


function UpdateHUDPlayerData(%playerId,%vehicleId,%opt)
{
	%position = getWord(%opt,0);
	%action = getWord(%opt,1);
	%clientId = Player::getClient(%playerId);

	//update other clients data who are on apc
	if(%vehicleId != 0)
	{
		if(GameBase::getDataName(%vehicleId) == HAPC)
			%numSlots = 4;
		else
			%numSlots = 2;
		%tempclientid = %vehicleId.clLastMount;
		if((%tempclientid != -1) && (%vehicleId.hasPilot))
			%PilotName = Client::getName(%tempclientid);
		else
			%PilotName = "";
		for(%i=0;%i<%numSlots;%i++)
		{
			%tempclient[%i] = Player::getClient(%vehicleId.Seat[%i]);
			if(%vehicleId.Seat[%i] != "")
			{
				if(%tempclient[%i] != -1)
				{
					%PassName[%i] = Client::getName(%tempclient[%i]);
				}
				else
					%PassName[%i] = "";
			}
		}

		//update existing player displays on APC
		if(%vehicleId.hasPilot)
		{
			if(%tempclientid.pilotHUD)
				remoteEval(%tempclientid, UpdateHUDData, %PilotName, %PassName[0], %PassName[1], %PassName[2], %PassName[3]);
		}
		for(%i=0;%i<%numSlots;%i++)
		{
			if((%tempclient[%i] != -1) && (%tempclient[%i].passengerHUD))
			{
					remoteEval(%tempclient[%i], UpdateHUDData, %PilotName, %PassName[0], %PassName[1], %PassName[2], %PassName[3]);
			}
		}
	}

	//alter players hud on apc

	if((%action == "dismount") && ((%clientId.pilotHUD) || (%clientId.passengerHUD)))
		remoteEval(%clientId, StandardHUD);
	else if((%position == "pilot") && (%clientId.pilotHUD))
	{
		APCHUDDamage(%vehicleId);
		remoteEval(%clientId, PilotHUD, %vehicleId);
	}
	else if((%position == "passenger") && (%clientId.passengerHUD))
	{
		APCHUDDamage(%vehicleId);
		remoteEval(%clientId, PassengerHUD, %vehicleId);
	}
}


function APCHUDDamage(%vehicleId)
{
	%vehicledamage = 1 - (GameBase::getDamageLevel(%vehicleId)/(GameBase::getDataName(%vehicleId)).maxDamage);
	if(%vehicledamage == 1)
		APCHUDRepair(%vehicleId, false);
	%vehicledamage = floor(%vehicledamage * 100);

	//update clients
	if(GameBase::getDataName(%vehicleId) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	for(%i=0;%i<%numSlots;%i++)
	{
		%tempclient[%i] = Player::getClient(%vehicleId.Seat[%i]);
		if((%vehicleId.Seat[%i] != "") && (%tempclient[%i].passengerHUD))
		{
			if((%tempclient[%i].passengerHUD) && (%vehicledamage != 0))
				remoteEval(%tempclient[%i], DamageHUD, %vehicledamage);
		}
	}
}

function APCHUDRepair(%vehicleId, %enabled)
{
	if(%enabled != "")
		$RepairEnabled[%vehicleId] = %enabled;
	if($RepairEnabled[%vehicleId])
	{
		APCHUDDamage(%vehicleId);
		schedule("APCHUDRepair(" @ %vehicleId @ ");",0.5);
	}
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
//===========================================================

function TAC::TeamHurtDisplay(%shooterClient,%damagedClient,%type)
{
	if($TAC::AdminDisable[hurtdisp] != "false")
		return;

	if(($TAC::LastTeamHurtDamaged == %damagedClient) && ($TAC::LastTeamHurtShooter == %shooterClient))
		return;

	$TAC::LastTeamHurtDamaged = %damagedClient;
	$TAC::LastTeamHurtShooter = %shooterClient;
	schedule("$TAC::LastTeamHurtDamaged = 0",1);
	schedule("$TAC::LastTeamHurtShooter = 0",1);

	%shootername = Client::getName(%shooterClient);
	%damagename = Client::getName(%damagedClient);

	if(%shootername == "" || %damagename == "")
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.TeamHurtDisplay)
			Client::sendMessage(%cl,3, "*** TEAMHURT: " @ %shootername @ " hurt " @ %damagename);
	}
}

