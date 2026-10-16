//
//
//    *--------------------*
//    |  Tribes Racer 2.6  |
//    *--------------------*
// 
//
//  Created by:
//		Nathan Sweet aka [HvC]NaTeDoGG
//                   author of HaVoC:  http://PlanetTribes.com/Havoc
//
//		Tribes Racer originally by Josef Jahn,
//                   author of SPOONBOT:  http://www.playspoon.com
//
//  (c) 2000 All rights reserved.
//
//
//
// ---------------------------------------------------

exec(dm);
exec("RacerRecords.cs");

function Game::playerSpawned(%pl, %clientId, %armor) {	  
   // use this client's skin preference
   Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   //spawn with only health kit
   Player::setArmor(%clientId,$ArmorType[Client::getGender(%clientId), LightArmor]);
   Player::setItemCount(%clientId,RepairKit,1);
   Player::setItemCount(%clientId,MineAmmo,3);
   Player::setItemCount(%clientId,TargetingLaser,1);
   Player::setItemCount(%clientId,Grenade,3);
   Player::setItemCount(%clientId,Beacon,100);
   Player::setItemCount(%clientId,RepairPack,1);
   Player::mountItem(%clientId,RepairPack,$BackpackSlot); 
   %pl.turned = false;
}

function Door::onDisabled(%this)
{
}

function Door::onDestroyed(%this)
{
}	

function StartUp() {
	//grab the checkpoint locations regardless of order
	%group = nameToId("MissionGroup\\Checkpoints");
	$numCheckPoints = Group::objectCount(%group);
	for(%i = 0; %i < $numCheckPoints; %i++) {
		%obj = Group::getObject(%group, %i);
		for(%ii = 0; %ii < $numCheckPoints; %ii++) {
			if(%obj.num == "Checkpoint" @ %ii) {
				$checkpoints[%ii] = GameBase::getPosition(%obj);
				break;
			}
		}
	}
	//vehicle inventory
	$VehicleInvList["JetVehicle"] = "";
	$VehicleInvList["WraithVehicle"] = "";
	$VehicleInvList["ScoutVehicle"] = "";
	$VehicleInvList["LAPCVehicle"] = "";
	$VehicleInvList["HAPCVehicle"] = "";	
	$VehicleInvList["SpitfireVehicle"] = 1;
	$TeamItemMax["SpitfireVehicle"] = 999;
	$VehicleInvList["HurricaneVehicle"] = 1;
	$TeamItemMax["HurricaneVehicle"] = 999;
	$VehicleInvList["TomahawkVehicle"] = 1;
	$TeamItemMax["TomahawkVehicle"] = 999;
	$VehicleInvList["HellfireVehicle"] = 1;
	$TeamItemMax["HellfireVehicle"] = 999;
	$VehicleInvList["ThunderboltVehicle"] = 1;
	$TeamItemMax["ThunderboltVehicle"] = 999;
	$teamplay = false;
}

function remoteforceUse(%client, %item) {
	%ok = false; %max = getNumItems(); // PORT: %item is client text and goes into a script string, so it must be an item name
	for(%i = 0; %i < %max; %i++) { if(String::ICompare(getItemData(%i), %item) == 0) { %ok = true; break; } }
	if(!%ok) return;
	if(Player::getItemCount(%client, %item)) 
		schedule(%item @ "::onUse(" @ Client::getOwnedObject(%client) @ ", " @ %item @ ");", 0); 
}

function remotemirrorLook(%client) {
	%player = Client::getOwnedObject(%client);
	%co = Client::getControlObject(%client);
	if(%player.turned && %player.vehicle) {
		%player.turned = false;
		remoteEval(%client, SetControls, true);
		Player::setMountObject(%player, %player.vehicle, 1);
		Client::setControlObject(%client, %player.vehicle);
		return;
	}
	if(getObjectType(%co) != "Flier") {
		%player.turned = false;
		return;
	}
	%player.turned = true;
	remoteEval(%client, SetControls);
	%rot = GameBase::getRotation(%player);
	%rot = getword(%rot, 0) @ " " @ getword(%rot, 1) @ " " @ (getword(%rot, 0) + 3.14);
	GameBase::setRotation(%player, %rot);
	Client::setControlObject(%client, %player);
}

function Game::initialMissionDrop(%clientId) {
   Client::setGuiMode(%clientId, $GuiModePlay);

	if($missionName == "XLR-8") $missionName = "XLR8";
	
	remoteEval(%clientId, setRacer);

   $CompletedRounds[%clientId] = 0;
   $TotalRounds[%clientId] = 0;
   Game::refreshClientScore(%clientId);
   $currentLeg[%clientId] = 1;

	$teamplay = false;

   if(!%clientId.justConnected)
	BeginRace(%clientId);

	
   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else {
      if(Observer::isObserver(%clientId)) {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      GameBase::setTeam(%clientId, 0);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1) {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting)) {
         %clientId.observerMode = "observerFly";
         return;
      } else if($Server::TourneyMode) {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, 1 @ getTeamName(0), 0);
      %clientId.justConnected = "";
   } else {
	  Client::setSkin(%clientId, $Client::info[%clientId, 0]);
      if(%clientId.justConnected) {
		 centerprint(%clientId, "<jc><f2>Tribes Racer v2.5 for HaVoC " @ $HV @ "\nby [HvC]NaTeDoGG<f1>\n\n" @ $Server::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      } else if(%clientId.observerMode == "justJoined") {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      } else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function Game::clientKilled(%playerId, %killerId) {
	remoteEval(%playerId, SetControls);
	DM::checkMissionObjectives(%killerId);
    $CompletedRounds[%playerId]--;
	if($CompletedRounds[%playerId] < 0) $CompletedRounds[%playerId] = 0;
	Game::refreshClientScore(%playerId);
	updateTopScore();
}

function finishedLap(%clientId) {
	%laptime = getSimTime() - %clientId.finishtime;
	if(%laptime < 0)
		%laptime = -%laptime;
	if(%laptime < $bestlap[%clientId])
		$bestlap[%clientId] = %laptime;
	if($BestLapTime[$missionName] == "") $BestLapTime[$missionName] = 9999;
	if(%laptime < $BestLapTime[$missionName]) {
		$BestLapTime[$missionName] = %laptime;
		$BestLapTimeName[$missionName] = Client::getName(%clientId);
		export("$BestLapTime*", "config\\RacerRecords.cs", False);
		messageall(0, Client::getName(%clientId) @ " set a new fastest lap record!~wCapturedTower.wav");
	}
	%clientId.finishtime = getSimTime();
	$CompletedRounds[%clientId]++;
	$TotalRounds[%clientId]++;
	Game::refreshClientScore(%clientId);
	$currentLeg[%clientId] = 1;
	DM::missionObjectives();
	DM::checkMissionObjectives(%clientId);
	%prevtop = $lastLeader;
	updateTopScore();
	if($lastLeader == %clientId) 
		%end = "! (" @ formattedbest(%laptime) @ ")~wshell_click.wav";
	else 
		%end = ". (" @ formattedbest(%laptime) @ ")~wshell_click.wav";
	if(%prevtop != %clientId && $lastLeader == %clientId) {
		%prevname = Client::getName(%prevtop);
		if(%prevname != "")
			%msg = " takes the lead from " @ %prevname @ " with ";
		else
			%msg = " takes the lead with ";
	} else
		%msg = " has completed ";
	if($CompletedRounds[%clientId] == 1)
		%msg = Client::getName(%clientId) @ %msg @ "1 lap" @ %end;
	else
		%msg = Client::getName(%clientId) @ %msg @ $CompletedRounds[%clientId] @ " laps" @ %end;		
	messageAll(0, %msg);
	Client::sendMessage(%clientId, 0, "~wflagreturn.wav");
}

function Door::onMove(%this, %forceClose) {
	if(%this.status == "open") {
		if((GameBase::getDataName(%this)).side == "left")
			Moveable::moveToWaypoint(%this,(Moveable::getWaypointCount(%this)-1));				
		else
			Moveable::moveToWaypoint(%this,0);				
 	} else
		Moveable::moveToWaypoint(%this,%this.center);				
}

function Server::nextMission(%replay)
{
if(%replay || $Server::TourneyMode){
	%nextMission = $missionName;
} else {
	if(getNumClients() < 2 || $HaVoC::RandomMissionTypes["Tribes Racer"]) {
		doNextRand();
		return;
	}
	echo("Selecting a mission...");
	%l = 0; %goodmtype = 0;
	while(%goodmtype != "Tribes Racer" && %l < 5000) {
		%rnd = floor(getRandom() * $TotalMissions);
		if ($MissionName != $TotalMissionList[%rnd] && string::getsubstr($TotalMissionList[%rnd], 0, 4) != "Boon" ) {
			%nextMission = $TotalMissionList[%rnd];
			$pref::LastMission = $TotalMissionList[%rnd];
		}			  
		%goodmtype = $HaVoC::MType[%nextMission];
		%l = %l + 1;
	}
	if(%l < 5000) {
		echo("A random Racer mission has been selected.");
		messageall(0, "A random Racer mission is being selected...");
		messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
	} else {
		echo("No other Racer missions found!");
		echo("Using default next mission.");
		%nextMission = $nextMission[$missionName];
	}
}

   echo("Changing to mission ", %nextMission, ".");
   
   Server::loadMission(%nextMission);
}

function Server::onClientDisconnect(%clientId) {
	$CompletedRounds[%clientId] = 0;
	$TotalRounds[%clientId] = 0;
	updateTopScore();
	%player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}
	doneposs(%clientId);
	if(%clientId.hasDeployed) $hasDropped = true;
	%clientId.adminNum = "";
   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) 
      Server::refreshData();
}

function Door::onTrigger(%this,%object,%trigger) {
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Flier") {
		if(%this.status != "open") {
			%this.status = "open";
			Door::onMove(%this);
		}
	}
}

function updateTopScore() {
	%numClients = getNumClients();
	for(%k = 0 ; %k < %numClients; %k++) 
		%clientList[%k] = getClientByIndex(%k);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";								
		for(%k= 0 ; %k < %numClients; %k++)
		{
			if($CompletedRounds[%clientList[%k]] < $CompletedRounds[%clientList[%k+1]])
			{
				%hold = %clientList[%k];
				%clientList[%k] = %clientList[%k+1];
				%clientList[%k+1] = %hold;
				%doIt=1;
			}
		}
	}
	%topScore = $CompletedRounds[%clientList[0]];
	if($CompletedRounds[%clientList[1]] == $CompletedRounds[%clientList[0]]) {
		if(%topScore == 0) return;
		if($CompletedRounds[%clientList[1]] == $CompletedRounds[%clientList[2]]) {
			if($CompletedRounds[%clientList[2]] == $CompletedRounds[%clientList[3]]) {
				%msg = "It is <f1>tied<f0> at ";
			} else {
				%msg = "<f1>" @ Client::getName(%clientList[0]) @ "<f0>, <f1>" @ Client::getName(%clientList[1]) @ "<f0>, and <f1>" @ Client::getName(%clientList[2]) @ "<f0> are tied for first place with ";
			}
		} else {
			%msg = "<f1>" @ Client::getName(%clientList[0]) @ "<f0> and <f1>" @ Client::getName(%clientList[1]) @ "<f0> are tied for first place with ";
		}
		%tied = true;
	} else
		%msg = "<f0>The current leader is <f1>" @ Client::getName(%clientList[0]) @ "<f0> with ";
	if(%topScore == 1)
		%msg = %msg @ "<f1>1<f0> lap";
	else
		%msg = %msg @ "<f1>" @ %topScore @ "<f0> laps";
	if(%tied)
		%msg = %msg @ "!";
	else
		%msg = %msg @ ".";
	if(%topScore == 0)
		%msg = "<f2>No one is winning!";
	bottomprintall("<jc>" @ %msg, 0);
	if(%tied || %topScore == 0)
		$lastLeader = 0;
	else
		$lastLeader = %clientList[0];
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   	Player::setMountObject(%pl, -1, 0);
   		Client::setControlObject(%cl, %pl);
		remoteEval(%cl, SetControls);
		%pl.turned = false;
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	GameBase::setTeam(%this, 0);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.9, 
		0.2, 250, 110); 
}

function vehicle::setWayPoint(%clientId, %way) {
	dbecho(2,"setting up waypoints...");
	%x = getWord($checkpoints[%way], 0);
	%y = getWord($checkpoints[%way], 1);
	if(%way == 0)
		issueCommand(%clientId, %clientId, 0, "Waypoint set to the Finish Line", %x, %y);
	else
		issueCommand(%clientId, %clientId, 0, "Waypoint set to Checkpoint " @ %way, %x, %y);
}       

function Player::leaveMissionArea(%player)
{
Client::sendMessage(Player::getClient(%player),0,"You have left the mission area.");
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this.bought) return;
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	if (%this.shieldStrength) {
		if(%this.lastsound < getSimTime()) {
			playSound(SoundShldOn, GameBase::getPosition(%this));
			%this.lastsound = getSimTime() + 0.4;
		}
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		%absorb = %energy * %strength;
		if (%value < %absorb) {
			GameBase::setEnergy(%this,%energy - (%value / %strength));
		} else {
			GameBase::setEnergy(%this,0);
			%this.shieldStrength = 0;
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	} else {
		if(%type == $ForceoutDamageType)
			if(GameBase::getControlClient(%this))
				Vehicle::dismount(%this, "0 0 100");
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function Door::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
}

function Player::checkLMATimeout(%player, %seqCount)
{
}

function Player::enterMissionArea(%player)
{
   Client::sendMessage(Player::getClient(%player),0,"You have entered the mission area.");
}
  
function GroupTrigger::onEnter(%this, %object) {
	%type = getObjectType(%object);
	if(%type == "Flier" || %type == "Player") {
		if(%this.num == "Multidoor") {
			//this trigger operates multiple doors
			%group = getGroup(%this) @ "\\Door";  
			for (%ii = 0; %ii < 4; %ii++) {
				%door = Group::getObject(%group @ %ii, 1);
				%door.status = "open";
				Door::onMove(%door);
			}
		} else {
			%cl = GameBase::getControlClient(%object);
			//if this is the checkpoint needed
			if(%this.num == ("Checkpoint" @ $currentLeg[%cl])) {
				if($currentLeg[%cl] == 0)
					finishedLap(%cl);
				else {
					Client::sendMessage(%cl, 0, "~wmine_act.wav");
					$currentLeg[%cl]++;
					//set to finish line
					if($currentLeg[%cl] == $numCheckPoints) $currentLeg[%cl] = 0;
				}
				Vehicle::setWayPoint(%cl, $currentLeg[%cl]);
				%flaggy = true;
			}
			if(%type == "Flier")
				for(%i = 0 ; %i < 4 ; %i++)
					if(%object.Seat[%i] != "")
						GroupTrigger::onEnter(%this, Client::getOwnedObject(%object.Seat[%i]));
			if(%flaggy) return;
			//normal
			%group = getGroup(%this);  
			%count = Group::objectCount(%group);
			for (%i = 0; %i < %count; %i++)
				GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
		}
	}
}	

function VehicleStation::checkBuying(%client,%item) {
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled") {
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);
		%station = %player.Station;
		%count = 0;
		for(%i = 0; %i < %objInWay; %i++) {
			%o = Group::getObject(%set, %i);
			if(getObjectType(%o) == "Item") {
				deleteobject(%o);
				%count++;
			}
		}
		%objInWay -= %count;
		if(%objInWay == 1) {
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) {
				if(GameBase::getControlClient(%object) == -1) {
					if(%station.fadeOut == "") {
						if(%item != $VehicleToItem[%sname]) {
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else
							return 2;
					}
					else {
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else { 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			}
		}
		if(!%objInWay) {
			if (checkResources(%player,%item,1)) {
	    		%vehicle = newObject("",flier,$DataBlockName[%item],true);
           		%vehicle.clLastMount = %client;
				%vehicle.bought = %client;
				schedule(%vehicle @ ".bought = \"\";", 6, %vehicle);
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				if(%client.vskin) 
					GameBase::setTeam(%vehicle, %client.vskin);
				else
					GameBase::setTeam(%vehicle, GameBase::getTeam(%client));
				if(%object.fading) { 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else {
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}

$skin = "swolf";

function GroupTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Flier") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		if(%this.num == "Multidoor") {
			//this trigger operates multiple doors
			%group = %group @ "\\Door";
			for (%ii = 0; %ii < 4; %ii++) {
				%door = Group::getObject(%group @ %ii, 1);
				%door.status = "close";
				%door.triggerTrigger = 1;
				Door::onMove(%door);
			}
		} else {
			//normal
			for (%i = 0; %i < %count; %i++) 
				GameBase::virtual(Group::getObject(%group,%i),"onTrigLeave",%object,%this);
		}
	}
}

function formattedbest(%secs) {
	if(%secs == 9999)
		return escapestring("00:00");
	%mins = floor(%secs / 60);
	if(%mins < 0)
		%mins = -%mins;
	%secs = floor(%secs - (%mins * 60));
	if(%secs < 0)
		%secs = -%secs;
	if(%mins < 10)
		%str = "0" @ %mins @ ":";
	else
		%str = %mins @ ":";
	if(%secs < 10)
		%str = %str @ "0" @ %secs;
	else
		%str = %str @ %secs;
	return escapestring(%str);
}

function Observer::triggerUp(%client) {
   if(%client.observerMode == "dead") {
      if(%client.dieTime + $Server::respawnTime < getSimTime()) {
         if(Game::playerSpawn(%client, true)) {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      }
   } else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly") {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   } else if(%client.observerMode == "justJoined") {
      %client.observerMode = "";
	  BeginRace(%client);
      Game::playerSpawn(%client, false);
   } else if(%client.observerMode == "pregame" && $Server::TourneyMode) {
      if($CountdownStarted)
         return;

      if(%client.notready) {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
         if(%client.notreadyCount < 3)
            bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
         else 
            bottomprint(%client, "<f1><jc>Waiting for match start.", 0);
      } else {
         %client.notreadyCount++;
         if(%client.notreadyCount < 4) {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
         }
         return;
      }
      Game::CheckTourneyMatchStart();
   }
}

function Beacon::onUse(%player,%item) {
	%client = Player::getClient(%player);
	%co = Client::getControlObject(%client);
	if(getObjectType(%co) != "Flier") return;
	if(GameBase::getEnergy(%co) <= 0) {
		Client::sendMessage(%client, 0, "Force shields exhuasted");
		return;
	}
	if(%co.active) {
		Client::sendMessage(%client, 0, "Force shields already activated");
		return;
	}
	%co.shieldStrength = 0.007;
	GameBase::setRechargeRate(%co, -2);
	%co.active = true;
	Client::sendMessage(%client, 0, "Force shields activated~wForceOpen.wav");
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "sarmor" || %armor == "spyarmor" || %armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	} else if(%armor == "marmor" || %armor == "barmor" || %armor == "earmor" || %armor == "iarmor" || %armor == "mfemale" || %armor == "bfemale" || %armor == "efemale" || %armor == "ifarmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	} else if(%armor == "harmor" || %armor == "darmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setItemCount(%passenger, AAGun, 0);
		if(Player::getMountedItem(%passenger, $WeaponSlot) == AAGun)
			Player::unMountItem(%passenger, $WeaponSlot);
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function MineAmmo::onUse(%player,%item) {
	%client = Player::getClient(%player);
	%co = Client::getControlObject(%client);
	if(getObjectType(%co) != "Flier" && !%player.turned) return;
	if(%player.turned && !%player.vehicle) {
		%player.turned = false;
		return;
	}
	if(%player.throwTime < getSimTime() ) {
		Player::decItemCount(%player,%item);
		%obj = newObject("","Mine","VehicleMine");
	 	addToSet("MissionCleanup", %obj);
		if(%player.turned)
			GameBase::throw(%obj, %player.vehicle, -9 * %client.throwStrength, false);
		else
			GameBase::throw(%obj, %co, -9 * %client.throwStrength, false);
		%obj.oed = %client;
		GameBase::setRotation(%obj, GameBase::getRotation(%co));
		%player.throwTime = getSimTime() + 0.5;
	}
}

function Grenade::onUse(%player,%item) {
	%client = Player::getClient(%player);
	%co = Client::getControlObject(%client);
	if(getObjectType(%co) != "Flier") return;
	if(%player.throwTime < getSimTime() ) {
		Player::decItemCount(%player,%item);
		%rot = GameBase::getRotation(%co);
		playsound(SoundFireFlierRocket, GameBase::getPosition(%co));
		%t = GameBase::getMuzzleTransform(%co); 	
		%vel = Item::getVelocity(%co); 
		%name = GameBase::getDataName(%co);
		if(%name == Thunderbolt || %name == Hellfire) {
			for(%i = 0; %i < 9 ; %i++)
				%trans = %trans @ getword(%t, %i) @ " ";
			%pos = getword(%t, 9) @ " " @ getword(%t, 10) @ " " @ getword(%t, 11);
			%vec = Vector::getFromRot(%rot, 20);
			%pos = Vector::add(%vec, %pos);
			%trans = %trans @ %pos;
		} else
			%trans = %t;
		if(GameBase::getLOSInfo(%co, 500)) { 
			%object = $los::object;
			if(getObjectType(%object) == "Flier") { 
				%targetId = GameBase::getControlClient(%object); 
				%targetName = Client::getName(%targetId); 
				%client = GameBase::getControlClient(%co); 
				%name = Client::getName(%client);
				if(%targetName == "") {
					Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ "~wmine_act.wav");
				} else {
					Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ " piloted by " @ %targetName @ "~wmine_act.wav");
					Client::sendMessage(%targetId, 0, "WARNING - " @ %name @ " has a Force Missile lock!~waccess_denied.wav"); 
					schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5); 
					schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0);
				}
				Projectile::spawnProjectile("ForceMissile", %trans, %co, %vel, %object); 
			} else {
				Projectile::spawnProjectile("ForceNonMissile", %trans,%co,%vel);
			}
		} else {
			Projectile::spawnProjectile("ForceNonMissile",%trans,%co,%vel); 
		}
		%player.throwTime = getSimTime() + 1.5;
	}
}

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate(%this, 0);
	GameBase::setMapName(%this, GameBase::getDataName(%this).description);
}

function Game::refreshClientScore(%clientId) {
	%clientId.ratio = getEfficiencyRatio(%clientId);
    Client::setScore(%clientId, "%n\t  " @ $CompletedRounds[%clientId] @ "\t  " @ $TotalRounds[%clientId] @ "\t   " @ %clientId.scoreDeaths @ "\t%p\t %l", $CompletedRounds[%clientId]);
	DM::missionObjectives();
}

function Mission::init()
{
   $numTeams = getNumTeams();
	$teamplay = false;
   for(%i = 0; %i < $numTeams; %i++)
      $teamScore[%i] = 0;

   setTeamScoreHeading("");
   setClientScoreHeading("Player Name\t\x60Laps\t\x84Total\t\xB0Deaths\t\xE4Ping\t\xFFPL");

   $dieSeqCount = 0;
   
	AI::setupAI();
	DM::missionObjectives();

	$SensorNetworkEnabled = true;

	if($missionName == "XLR-8") $missionName = "XLR8";
}

function Vehicle::onCollision(%this, %object) {

	%data = GameBase::getDataName(%this);
	if(%data.shapefile == "remoteturret") return;
	if(%data.shapefile == "rocket" || (%data.shapefile == "discb" && getObjectType(%object) == "Player")) { 
		GameBase::setDamageLevel(%this, 99); 
		return; 
	}

	if(%object.driver != "") return;

	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
           	if(Player::isAiControlled(%object)) return;
	      	if(%object.inStation) {
	      		Client::sendMessage(Player::getClient(%object),0,"You can not mount a vehicle while in a station.~wError_Message.wav");
	      	     	return;
	      	}
			%armor = Player::getArmor(%object);
	      	%client = Player::getClient(%object);
			if ((whatArm(%armor) == 1 || ((%armor == "earmor" || %armor == "efemale") && %data == HAPC)) && Vehicle::canMount(%this, %object)) {
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				if(%data == Wraith) {
					if(Player::getMountedItem(%object,$FlagSlot) != "flag")
						GameBase::startFadeout(%this);						
				}
				Player::setMountObject(%object, %this, 1);
		        doneposs(%client);
				%client.safet = false;
				remoteEval(%client, SetControls, true);
				Client::setControlObject(%client, %this);
				playSound (%data.mountSound, GameBase::getPosition(%this));
				%object.driver = 1;
            	%object.vehicle = %this;
				%this.clLastMount = %client;
			} else if(%data != Scout && %data != Wraith && %data != Jet && %data != Dr && %data != Drs && %data != Spitfire && %data != Hurricane && %data != Tomahawk)  {
			 	%mountSlot = Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					Player::setItemCount(%object, AAGun, 1);
					playSound (%data.mountSound, GameBase::getPosition(%this));
				}
			} else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),1,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function BeginRace(%clientId) {
	schedule("bottomprint(" @ %clientId @ ", \"<f2><jc>Tribes Racer v2.5\\n<f1>Go get a vehicle and complete the most Laps!\\nIf you are killed you lose a Lap!\\n\\n<f2>Let the race begin!\", 10);", 10);
	schedule("vehicle::setWayPoint(" @ %clientId @ ", 1);", 10);
	$bestlap[%clientId] = 9999;
	%clientId.finishtime = getSimTime();
	$teamplay = false;
}

function DM::checkMissionObjectives(%playerId) {
    if(DM::missionObjectives(%playerId)) 
		nextMission();
	if($DMScoreLimit > 0)
		if($CompletedRounds[%playerId] >= $DMScoreLimit) {
	       $timeLimitReached = true;
	   	   $timeReached = 1;
			DM::missionObjectives();
			Server::nextMission();
		}
}

function VehiclePad::onCollision(%this, %object) {
	if(getObjectType(%object) != "Player") return;
	%object.lastTouchy++;
	if(%object.lastTouchy > 2) {
		%forceDir = Vector::getFromRot(GameBase::getRotation(%object), 15, 30 * %object.lastTouchy);
		Player::applyImpulse(%object, %forceDir);
		if(%object.lastTouchy > 12)
			schedule(%object@ ".lastTouchy -= 4;", 600, %object);
		else if(%object.lastTouchy > 6)
			schedule(%object@ ".lastTouchy -= 4;", 10, %object);
		else
			schedule(%object@ ".lastTouchy -= 4;", 6, %object);
		%object.lastTouchy += 3;
	} else
		schedule(%object@ ".lastTouchy--;", 3, %object);
}

function DM::missionObjectives() {
	%numClients = getNumClients();
	for(%k = 0; %k < %numClients; %k++) 
		%clientList[%k] = getClientByIndex(%k);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";								
		for(%k= 0 ; %k < %numClients; %k++)
		{
			if($CompletedRounds[%clientList[%k]] < $CompletedRounds[%clientList[%k+1]])
			{
				%hold = %clientList[%k];
				%clientList[%k] = %clientList[%k+1];
				%clientList[%k+1] = %hold;
				%doIt=1;
			}
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
	for(%l = -1; %l < 1 ; %l++) {		
		%lineNum = 0;
		if($timeReached == "") {
	 	  	Team::setObjective(%l, %lineNum, " ");
	  		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
			Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
	      	Team::setObjective(%l, %lineNum++, %str);
	      	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Complete as many Laps as possible!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Stay Alive! If you die you lose a Lap!");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>Follow your waypoint and race around the track going through each checkpoint along the way.\n\nVisit http://www.PlanetTribes.com/Havoc for Racer client side scripts and vehicle skins.");
	 	  	Team::setObjective(%l, %lineNum++, " ");
			if($BestLapTime[$missionName])
				Team::setObjective(%l, %lineNum++, "<F1>Record fastest lap for this misison: <F5>" @ $BestLapTimeName[$missionName] @ " (" @ formattedbest($BestLapTime[$missionName]) @ ")");
	 	  	Team::setObjective(%l, %lineNum++, " ");
		  	Team::setObjective(%l, %lineNum++, "<f5>TOP PLAYERS ARE: " );
	    } else {
			Team::setObjective(%l, %lineNum++, "<f5>Mission Summary:");
	 	  	Team::setObjective(%l, %lineNum++, " " );
			if($CompletedRounds[%clientList[0]] == $CompletedRounds[%clientList[1]])
				Team::setObjective(%l, %lineNum++, "<L14><f5>It ended in a tie!" );
			else {
				Team::setObjective(%l, %lineNum++, "<L14><f1>The winner is: " );
				if($CompletedRounds[%clientList[0]] == 1)
					Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ "<f5> with 1 Completed Lap!");
				else
					Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ "<f5> with " @ $CompletedRounds[%clientList[0]] @ " Completed Laps!");

			}
			if($BestLapTime[$missionName])
				Team::setObjective(%l, %lineNum++, "<F1>Record fastest lap for this misison: <F5>" @ $BestLapTimeName[$missionName] @ " (" @ formattedbest($BestLapTime[$missionName]) @ ")");
	        Team::setObjective(%l, %lineNum++, " ");
		}

        Team::setObjective(%l, %lineNum++, " " );
	 	Team::setObjective(%l, %lineNum++, "<L29>Completed Laps\t\tTotal Laps\t\tDeaths\t\tBest Lap");
        %i=0;
         while(%i < %numClients){
            %plyr = %clientList[%i];
			%best = formattedbest($bestlap[%plyr]);
			Team::setObjective(%l, %lineNum++, "<f2>"@(%i + 1) @ ". " @ Client::getName(%plyr) @ "<L29><f0>\t\t\t" @ $CompletedRounds[%plyr] @ "\t\t\t\t\t\t\t" @ $TotalRounds[%plyr] @ "\t\t\t\t\t" @ %plyr.ScoreDeaths @ "\t\t\t  " @ %best);
            %i++;
         }

		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}
	$timeReached="";
}

function Door::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if(%type == "Flier" || %type == "Player")
		if((%this.triggerOpen == "" || %this.triggerTrigger)) 
			Door::trigger(%this);
}

function Server::loadMission(%missionName, %immed)
{

	if($HaVoC::FairSpawn > 10 || $HaVoC::FairSpawn < 0) {
		$HaVoC::FairSpawn = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::FairSpawn is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::BaseKillLimit < 2 && $HaVoC::BaseKillLimit != 0) {
		$HaVoC::BaseKillLimit = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::BaseKillLimit is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::tkLimit <= 0) {
		$HaVoC::tkLimit = 5;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::tkLimit is invalid, option has been set to 5");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningFrequency != 0 && $HaVoC::LightningFrequency < 90) {
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength != "normal" && $HaVoC::LightningStrength != "random" && $HaVoC::LightningStrength != "weak" && $HaVoC::LightningStrength != "zero") {
		$HaVoC::LightningStrength = "normal";
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningStrength is invalid, option has been set to normal");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength == "normal" && $HaVoC::LightningFrequency < 200) {
		$HaVoC::LightningStrength = "weak";
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  Lightning Strength cannot be set to normal if Lightning Frequency is less than 200.");
		echo("$HaVoC::LightningStrength is invalid, option has been set to weak");
		echo("$HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");

	}

	if($HaVoC::AutoAssignLength == 0) {
		$HaVoC::AutoAssignLength = 4;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::AutoAssignLength is invalid, option has been set to 4");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}
	
	if($HaVoC::LightningHandicap < 3 && $HaVoC::LightningHandicap != 0) {
		$HaVoC::LightningHandicap = 0;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningHandicap is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

   if($loadingMission)
      return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	$warning[%cl] = 0;
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
	  %cl.empTime = 0;
	  %cl.poisonTime = 0;
	  %cl.blindTime = 0;
	  %cl.basekills = 0;
	  remoteEval(%cl, SetControls);
   }

	if($HaVoC::startTime)
		$Server::timeLimit = $HaVoC::startTime;
	else
		$HaVoC::startTime = $Server::timeLimit;

	if($HaVoC::MType[%missionName] == "Deathmatch" || $HaVoC::MType[%missionName] == "Team Deathmatch" || $HaVoC::MType[%missionName] == "Flag Hunter" || $HaVoC::MType[%missionName] == "Kill the Rabbit") { 
		%newfav = $MasterKey @ "DM";
		dmm();
	} else {
		%newfav = $MasterKey;
		normalm();
	}
	
	if ($ItemFavoritesKey != %newfav) {
		if($ItemFavoritesKey != $MasterKey @ "Arena") {
			if(%newfav == $MasterKey @ "DM") {
				echo("Switching favorites to HaVoC Deathmatch settings.");
				messageall(0, "Switching favorites to HaVoC Deathmatch settings.");
			} else {
				echo("Switching favorites to normal HaVoC settings.");
				messageall(0, "Switching favorites to normal HaVoC settings.");		
			}
		}
		$ItemFavoritesKey = %newfav;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
		   remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	   }
	}

   bottomprintall("", 0);
   $lastLeader = 0;
   exec(server);
   exec(observer);
   exec(admin);
   exec(resetracer);

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); 

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();      
}

StartUp();

echo("*****************************************");
echo("Tribes Racer version 2.6 for HaVoC v" @ $HV @ " by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("  " @ $numCheckPoints @ " Checkpoints detected.");
echo("*****************************************");