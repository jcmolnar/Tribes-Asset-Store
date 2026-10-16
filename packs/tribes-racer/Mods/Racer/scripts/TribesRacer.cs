// Tribes Racer - Retribution
// (c) 1999 Josef Jahn (author of SPOONBOT for Tribes)
// http://www.playspoon.com
// ---------------------------------------------------

SoundData SoundFireScoutChaingun
{
   wavFileName = "machinegun.wav";
   profile = Profile3dNear;
};



RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 6.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 200.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 12;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};



GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.01;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 150;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};



//----------------------------------------------------------
GrenadeData AtomicBomb         //added by Werewolf
//GrenadeData MortarShell
{
//   bulletShapeName    = "mortar.dts";
   bulletShapeName    = "liqcyl.dts";
   explosionTag       = Shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
//   smokeName              = "mortartrail.dts";
   smokeName              = "rsmoke.dts";
};




FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
      shapeFile = "flyer";
      shieldShapeName = "shield_medium";
      mass = 9.0;
      drag = 1.0;
      density = 1.2;
      maxBank = 0.9;
      maxPitch = 0.9;
      maxSpeed = 100;
      minSpeed = -20;
	lift = 0.75;
	maxAlt = 55;
	maxVertical = 50;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.9;

	groundDamageScale = 1.0;

	repairRate = 0;
	projectileType = ChaingunBullet;
	reloadDelay = 0.005;
	fireSound = SoundFireScoutChaingun;

	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};


FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 60;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";

	projectileType = FlierRocket;
	reloadDelay = 0.15;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;

	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
};


FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 40;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	projectileType = AtomicBomb;
	reloadDelay = 1.0;
	fireSound = SoundFireGrenade;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};



function Game::initialMissionDrop(%clientId)
{
	$CompletedRounds[%clientId]=0;
	$currentLeg[%clientId]=0;
	GameBase::setTeam(%clientId, 0);
	Client::setGuiMode(%clientId, $GuiModePlay);
	Game::playerSpawn(%clientId, false);
	schedule("vehicle::leg1(" @ %clientId @ ");", 15);
	schedule("vehicle::setWayPoint(" @ %clientId @ ");", 15);

	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Go get into a Scout and complete the most rounds!\", 5);", 0);
	schedule("Client::sendMessage(" @ %clientId @ ", 0, \"~wshell_click.wav\");", 0);
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>If you kill someone, you gain a round.\", 5);", 5);
	schedule("Client::sendMessage(" @ %clientId @ ", 0, \"~wshell_click.wav\");", 5);
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>If you get killed, you loose a round.\", 5);", 10);
	schedule("Client::sendMessage(" @ %clientId @ ", 0, \"~wshell_click.wav\");", 10);
	//limit vehicle inventory
	$VehicleInvList["ScoutVehicle"] = 50;
	$VehicleInvList["LAPCVehicle"] = 50;
	$VehicleInvList["HAPCVehicle"] = 50;
	$TeamItemMax[ScoutVehicle] = 64;
	$TeamItemMax[HAPCVehicle] = 64;
	$TeamItemMax[LAPCVehicle] = 64;

}


function Game::clientKilled(%playerId, %killerId)
{

   if (%playerId==%killerId)
   {
	$CompletedRounds[%killerId]--;
	if ($CompletedRounds[%killerId]<=0) $CompletedRounds[%killerId]=0; // PORT: same floor as the killed-by-someone branch
   }
   else
   {
	$CompletedRounds[%killerId]++;
	$CompletedRounds[%playerId]--;
	if ($CompletedRounds[%playerId]<=0)
		$CompletedRounds[%playerId]=0;
   }

   if($teamplay)
   {
      if(%killerId == -1 || %playerId == -1)
      {
         return;
      }
      %kteam = Client::getTeam(%killerId);
      %pteam = Client::getTeam(%playerId);
      
      if(%kteam == %pteam)
         $teamScore[%kteam] = $teamScore[%kteam] - 1;
      else
         $teamScore[%kteam] = $teamScore[%kteam] - 1;
      
      DMTEAM::checkMissionObjectives();
   }
   else
      DM::checkMissionObjectives(%killerId);


   $currentLeg[%playerId]=0;
   schedule("vehicle::leg1(" @ %playerId @ ");", 1);
   schedule("vehicle::setWayPoint(" @ %playerId @ ");", 1);


	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);

	%TopScore=0;
	%numClients = getNumClients();
	for(%i = 0; %i < %numClients ; %i++)
	{
		%cl = %clientList[%i];
		dbecho(1, %cl);
		if (%TopScore <= $CompletedRounds[%cl])
			{
				%TopScore=$CompletedRounds[%cl];
				%leader=%cl;
			}
	}

	if (%leader != 0)
	{
		if($CompletedRounds[%leader] >= $DMScoreLimit)
		{
			schedule("messageAll(0, \"THE WINNER IS " @ escapeString(Client::getName(%leader)) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);
		}
		else
		{
			schedule("messageAll(0, \"LEADER: " @ escapeString(Client::getName(%leader)) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);
		}
	}

   
}




//---------------------------
//vehicle::leg1()
//---------------------------
function vehicle::leg1(%clientId)
{

	schedule("messageAll(0, \"~wshell_click.wav\");", 0);
	DM::missionObjectives();
	DM::checkMissionObjectives(%clientId);

     if ($CompletedRounds[%clientId] >= 1)
     {
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>New Round!\", 1);", 0);
	schedule("messageAll(0, \"" @ escapeString(Client::getName(%clientId)) @ " has finished " @ $CompletedRounds[%clientId] @ " Rounds\");", 0);
	%TopScore=0;

	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);

	for(%i = 0; %i < %numClients ; %i++)
	{
		%cl = %clientList[%i];
		dbecho(1, %cl);
		if (%TopScore <= $CompletedRounds[%cl])
			{
				%TopScore=$CompletedRounds[%cl];
				%leader=%cl;
			}
	}

	if (%leader != 0)
	{
		if($CompletedRounds[%leader] >= $DMScoreLimit)
		{
			schedule("messageAll(0, \"THE WINNER IS " @ escapeString(Client::getName(%leader)) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);
		}
		else
		{
			schedule("messageAll(0, \"LEADER: " @ escapeString(Client::getName(%leader)) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);
		}
	}

     }
     else
     {
	schedule("bottomprint(" @ %clientId @ ", \"<f2><jc>Let the race begin!\", 3);", 0);
     }

}

//-----------------------------
//vehicle::leg2()
//-----------------------------
function vehicle::leg2(%clientId)
{
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Lap 1\", 1);", 0);
	schedule("messageAll(0, \"~wshell_click.wav\");", 0);
}

//--------------------------------
//vehicle::leg3()
//--------------------------------
function vehicle::leg3(%clientId)
{
  schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Lap 2\", 1);", 0);
  schedule("messageAll(0, \"~wshell_click.wav\");", 0);
}

//-------------------------------------
//vehicle::setWayPoint()
//-------------------------------------
function vehicle::setWayPoint(%clientid)
{
	dbecho(2,"setting up waypoints...");
	%group = nameToId("MissionGroup\\destinations");

	//flow controlled by triggers
	if($currentLeg[%clientId] == 0)
	{
		%obj = Group::getObject(%group, 0);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 1)
	{
		%obj = Group::getObject(%group, 1);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 2)
	{
		%obj = Group::getObject(%group, 2);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 3)
	{
		%obj = Group::getObject(%group, 0);
		$currentLeg[%clientId]=1;
	}
	

	//find the position of the next station
	%position = GameBase::getPosition(%obj);
	%x = getWord(%position, 0);
	%y = getWord(%position, 1);
	//setway point
	issueCommand(%clientId, %clientId, 0, "Waypoint set to next Lap station", %x, %y);
}       

//-----------------------------------------
//GroupTrigger::onEnter()
//-----------------------------------------
function GroupTrigger::onEnter(%this, %object)
{

		%cl = GameBase::getControlClient(%object);

		if(%this.num == "Trigger1" && $currentLeg[%cl] == 1)
		{
			Vehicle::setWayPoint(%cl);
			vehicle::leg2(%cl);
		}
		else if(%this.num == "Trigger2" && $currentLeg[%cl] == 2)
		{
			Vehicle::setWayPoint(%cl);
			vehicle::leg3(%cl);
		}
		else if(%this.num == "Trigger3" && $currentLeg[%cl] == 3)
		{  
			%cl.scoreKills++;
			$CompletedRounds[%cl]++;
			Vehicle::setWayPoint(%cl);
			vehicle::leg1(%cl);

		}
}	



function DM::checkMissionObjectives(%playerId) 
{
   if(DM::missionObjectives(%playerId)) 
      schedule("nextMission();", 0);
	if($DMScoreLimit > 0)
		if($CompletedRounds[%playerId] >= $DMScoreLimit) {
	      $timeLimitReached = true;
   	   $timeReached = 1;
			DM::missionObjectives();
			Server::nextMission();
		}
}

function ObjectiveMission::refreshTeamScores()
{
DM::missionObjectives();
}

function ObjectiveMission::setObjectiveHeading()
{
DM::missionObjectives();
}

function DM::missionObjectives()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1) {
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++) {
			if((%clientList[%i]).ratio < (%clientList[%i+1]).ratio) {
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1]	= %hold;
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
	 	  	Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
	  		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
			Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
	      Team::setObjective(%l, %lineNum++, %str);
	      Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f5>TRIBES RACER- Retribution:");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Fly 10 rounds with the Scout!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Kill other players to gain a round!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -If you get killed, you loose a round!");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>You can fly everywhere, but you have to pass the Lap Stations in sequence to finish a round. Just follow the waypoint markers and you cannot go wrong.");
	 	  	Team::setObjective(%l, %lineNum++, " When you pass a lap point, fly through between the antennas (i.e. very low).");
	 	  	Team::setObjective(%l, %lineNum++, " Or take control of a missile turret and blast the other racers ;-)");
		  	Team::setObjective(%l, %lineNum++, "<f5>TOP PLAYERS ARE: " );
	 	  	Team::setObjective(%l, %lineNum++, " ");
	   }
	   else {
			Team::setObjective(%l, %lineNum++, "<f5>Mission Summary:");
	 	  	Team::setObjective(%l, %lineNum++, " " );
	 	  	Team::setObjective(%l, %lineNum++, "<f1>     - The Best Player(s): " );
		}

			%i=0;
			%TopRatio="";
			for(%i = 0 ; %i < %numClients ; %i++) 
			{
	 	  		Team::setObjective(%l, %lineNum++, "<f1><Bskull_big.bmp>\n" @ Client::getName(%clientList[%i]) @ " finished " @ $CompletedRounds[%clientList[%i]] @ " Rounds.");
			}

		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}
	$timeReached="";
}

function TowerSwitch::onCollision(%this, %object)
{
	

	return; // PORT: unfinished in the original. %group is never set and no LargeForceField datablock exists,
	// so every touch of a tower switch ran newObject on an unknown datablock and played two sounds at the map origin.
	if(GameBase::getMapName(%this) == "Switch1")
	{
		%obj = Group::getObject(%group, 0);
	}
	if(GameBase::getMapName(%this) == "Switch2")
	{
		%obj = Group::getObject(%group, 1);
	}
	if(GameBase::getMapName(%this) == "Switch3")
	{
		%obj = Group::getObject(%group, 2);
	}

	%position = GameBase::getPosition(%obj);
	%rot = GameBase::getRotation(%object);
	%fField = newObject("","StaticShape",LargeForceField,true);
	addToSet("MissionCleanup", %fField);
	GameBase::setTeam(%fField,2);
	GameBase::setPosition(%fField,%position);
	GameBase::setRotation(%fField,%rot);
	Gamebase::setMapName(%fField,"Force Field");
	GameBase::startFadeIn(%fField);
	playSound(SoundPickupBackpack,%position);
	playSound(ForceFieldOpen,%position);

}
