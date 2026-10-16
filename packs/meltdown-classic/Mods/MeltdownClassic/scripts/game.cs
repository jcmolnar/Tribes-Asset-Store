exec("comchat.cs");
//PORT-OFF: exec("client.cs");  the mod's 1999 client.cs is not shipped; base's 1.50 client.cs must not be re-run by a server
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//  Global Variables by INH*DynaBlade
//  Commands that I might actually use someday

$MeltdownV = "v1.10"; // Again, this mod was made by me, only balanced.
$MeltdownLogo = "Have a good night ''Big Guy''!";
$MeltdownUltraAdmin = "INH*DynaBlade";
$MeltdownMainLicensed = "INH*DynaBlade";
$MeltdownMadeFor = "Other than INH";
$Meltdown::AntiTK = true;
$Meltdown::AutoAdmin = true;
$Meltdown::AutoBan = true;
$Meltdown::UseEcstacyEngine = true;

# Seeking Missile Triggers
$Ecstacy::onFireNoPack = true; // does Ecstacy Cannon work (y/n)
#$RPGUseMTPack = false; // same as above
#$RPMUseMTPack = false; // same as above
#$RPEMPUseMTPack = false; // same as above
$DiskerUseMTPack = false; // same as above

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;  //<------------Evil Autorespawn!!

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 15200; 
$RemoteInvEnergy = 15200;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 5;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 5;    //Define Max Length of the area
$TurretBoxMaxWidth =  5;    //Define Max Width of the area
$TurretBoxMaxHeight = 2;    //Define Max Height of the area

$TurretBoxMinLength = 1;	  //Define Min Length from another turret
$TurretBoxMinWidth =  1;	  //Define Min Width from another turret
$TurretBoxMinHeight = 1;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

exec(damagetypes);

//---------------------------------------------------------------------------------

function randomSpawnList(%client)
{
	%rnd = floor(getRandom() * 25);	
	echo("Setting Up Gear For Random Spawn" @ %rnd @ " - ");
	if ((%rnd >= 0) && (%rnd <= 10))
	{
		$spawnBuyList[0] = LightArmor;
		$spawnBuyList[1] = RPGLauncher;
		$spawnBuyList[2] = Shotgun;
		$spawnBuyList[3] = PlasmaGun;
		$spawnBuyList[4] = RepairKit;
		$spawnBuyList[5] = Reassembler;
		$spawnBuyList[6] = EnergyRifle;
		$spawnBuyList[7] = grenade;
		$spawnBuyList[8] = grenade;
		$spawnBuyList[9] = grenade;
		$spawnBuyList[10] = grenade;
		$spawnBuyList[11] = grenade;
		$spawnBuyList[12] = beacon;
		$spawnBuyList[13] = beacon;
		$spawnBuyList[14] = beacon;
		$spawnBuyList[15] = mineammo;
		$spawnBuyList[16] = mineammo;
		$spawnBuyList[17] = mineammo;	
		$spawnBuyList[18] = energypack;
		$spawnBuyList[19] = BeaconAmmo;
		$spawnBuyList[20] = BeaconAmmo;
		$spawnBuyList[21] = BeaconAmmo;
		$spawnBuyList[22] = BeaconAmmo;
		$spawnBuyList[23] = BeaconAmmo;
		$spawnBuyList[24] = ElectricityRifle;
	}
	if ((%rnd >= 11) && (%rnd <= 20))
	{
		$spawnBuyList[0, %client] = MediumArmor;
		$spawnBuyList[1, %client] = MBCannon;

		$spawnBuyList[2, %client] = HyperB;
		$spawnBuyList[3, %client] = PTCannon;
		$spawnBuyList[4, %client] = RepairKit; 
		$spawnBuyList[5, %client] = HDiscLauncher; 
		$spawnBuyList[6, %client] = Grenade; 
		$spawnBuyList[7, %client] = Grenade; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = Beacon;
		$spawnBuyList[11, %client] = Beacon;
		$spawnBuyList[12, %client] = reassembler;
		$spawnBuyList[13, %client] = beaconAmmo;
		$spawnBuyList[14, %client] = AmmoGeneratorPack;
		$spawnBuyList[15, %client] = Mineammo;
		$spawnBuyList[16, %client] = ElectricityRifle;
	}
	if ((%rnd >= 21) && (%rnd <= 25))
	{
		$spawnBuyList[0, %client] = HeavyArmor;
		$spawnBuyList[1, %client] = MECHRocketLauncher;
		$spawnBuyList[2, %client] = RPEMPLauncher;
		$spawnBuyList[3, %client] = HDiscLauncher;
		$spawnBuyList[4, %client] = RepairKit; 
		$spawnBuyList[5, %client] = RPMLauncher; 
		$spawnBuyList[6, %client] = Grenade; 
		$spawnBuyList[7, %client] = Grenade; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = Beacon;
		$spawnBuyList[11, %client] = Beacon;
		$spawnBuyList[12, %client] = MineAmmo;
		$spawnBuyList[13, %client] = reassembler;
		$spawnBuyList[14, %client] = AODCombo1Pack;
		$spawnBuyList[15, %client] = beaconammo;
		$spawnBuyList[16, %client] = ElectricityRifle;
	}
	else
	{
		$spawnBuyList[0] = LightArmor;
		$spawnBuyList[1] = RPGLauncher;
		$spawnBuyList[2] = Shotgun;
		$spawnBuyList[3] = PlasmaGun;
		$spawnBuyList[4] = RepairKit;
		$spawnBuyList[5] = Reassembler;
		$spawnBuyList[6] = EnergyRifle;
		$spawnBuyList[7] = grenade;
		$spawnBuyList[8] = grenade;
		$spawnBuyList[9] = grenade;
		$spawnBuyList[10] = grenade;
		$spawnBuyList[11] = grenade;
		$spawnBuyList[12] = beacon;
		$spawnBuyList[13] = beacon;
		$spawnBuyList[14] = beacon;
		$spawnBuyList[15] = mineammo;
		$spawnBuyList[16] = mineammo;
		$spawnBuyList[17] = mineammo;	
		$spawnBuyList[18] = energypack;
		$spawnBuyList[19] = BeaconAmmo;
		$spawnBuyList[20] = BeaconAmmo;
		$spawnBuyList[21] = BeaconAmmo;
		$spawnBuyList[22] = BeaconAmmo;
		$spawnBuyList[23] = BeaconAmmo;
		$spawnBuyList[24] = ElectricityRifle;
	}
}

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
   if(!%clientId.guiLock && !Observer::isObserver(%clientId))
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}

function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}

function remoteScoresOn(%clientId)
{
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
   Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);

   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Entering mission area in " @ %time @ " seconds!");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Entered mission area; Engaging battle mode");
	Game::resetScores();	
   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{

	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn){}
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
     	Client::setSkin(%clientId, $Client::info[%clientId, 0]);

	%clientId.spawntime = getsimtime();
	randomSpawnList(%clientId);
						  

%clientId.spawn= 1;

	%max = getNumItems();

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon) 
		%clientId.spawnWeapon = %item;
		if ($Debug) echo ("Buying = " @ %item);
	}

	for (%i = 0; %i < 6; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"BeaconAmmo");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}


	%clientId.spawn= "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);	
		%clientId.spawnWeapon="";
	}
 
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      #Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
		%name = Client::getName(%clientId);
		centerprint(%clientId, "<jc><f2>Welcome " @ %name @ " to the " @ $Server::HostName @ "\n\n" @ $Meltdown::JoinMOTD, 0);

         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {

        bottomprint(%clientId, "<f1><jc>FIRE when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}


function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: Timelimit reached.");
      $timeLimitReached = true;
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Game::resetScores(%client)
{
	if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;
		}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
}

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
	   Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
	   Player::setArmor(%player, %armorType);
	}
}


function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	%name = Client::getName(%playerId);
    %numTeams = getNumTeams();

	if($Meltdown::AutoAssign && $teamplay) {
		%name = Client::getName(%playerId);
		if(string::getsubstr(%name, 0, $Meltdown::AutoAssignLength) == $Meltdown::AutoAssignTribe) {
			GameBase::setTeam(%playerId, 0);
			Client::sendMessage(%playerId, 0, "You have been auto assigned to your tribe's team.");
		} else
			GameBase::setTeam(%playerId, 1);
		return;
	}

   if($teamplay)
   {
      if($teamPreset[%name] != "")
      {
         if($teamPreset[%name] < %numTeams)
         {
            GameBase::setTeam(%playerId, $teamPreset[%name]);
            echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
            return;
         }            
      }
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         if(%pl != %playerId)
         {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         }
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if( (%numTeamPlayers[%i] < %leastPlayers) || 
            ( (%numTeamPlayers[%i] == %leastPlayers) && 
            ($teamScore[%i] < $teamScore[%leastTeam] ) ))
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}

function TeamKillerCheck(%player)
{	%name=Client::getName(%player);

	if(%player.teamkills>=$Meltdown::TKLimit)
	{	
		CenterPrint(%player,"<jc>Team Killers will <f1>NOT<f0> be tolerated on this server!!!\nYou are being <f2>AUTO Kicked<f0> for Team Killing!!",5);
		MessageAllExcept(%player, 0, %name@ " has been AUTO Kicked for Team Killing!~wAAODSFX62.wav");
		%player.tkick++;
		if(%player.tkick>=$Meltdown::TKBanXs) %player.banned=true;
		schedule("Net::Kick("@%player@");",6);
	}
	else	// Issue Warning
	{
		CenterPrint(%player,"<jc>Team Killers will <f1>NOT<f0> be tolerated on this server!!!\nIf you continue to Team Kill you will be <f2>Kicked!!",5);
		Client::sendMessage(%player,0,"~wAAODSFX14.wav");
	}
}

function Assist(%PlayerId,%KillerId,%msg)
{	if(%playerId.LastDamBy[2]	!= false)	// More than 1 Player has damaged this Player Recently
	{	
		if(%playerId==%killerId || !%killerId)
			%msg=%msg@" assisted by "@Client::getName(%PlayerId.LastDamBy[1])@" & "@Client::getName(%PlayerId.LastDamBy[2]);
		else
			%msg=%msg@" assisted by "@Client::getName(%PlayerId.LastDamBy[1]);
	}
	return(%msg);
}


function Client::onKilled(%playerId, %killerId, %damageType)
{
   echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
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
	%victimName = Client::getName(%playerId);


   if(!%killerId)
   {
      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      %playerId.scoreDeaths++;
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
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
      if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
	bottomprint(%playerId, "<jc><f1>You have just been\n<f2>TEAM KILLED <f1>by<f2> " @ Client::getName(%killerId), 10);
	bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10);
	%killerId.scoreDeaths++;
	%killerId.score--;
	%killerId.teamkills++;
	Game::refreshClientScore(%killerId);
	if(%killerId.teamkills>$TeamKillMin)
	TeamKillerCheck(%killerId);

      messageAll(0, strcat(Client::getName(%killerId), " has fun tking ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
	   %killerId.scoreDeaths++;
         %playerId.score--;
         Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%player.outArea=1;
	alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

//called if player leaves mission area
function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}
  
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) {
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
	   	schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else { 
			playNextAnim(%client);	
			Client::onKilled(%client, %client);
		}
	}
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

