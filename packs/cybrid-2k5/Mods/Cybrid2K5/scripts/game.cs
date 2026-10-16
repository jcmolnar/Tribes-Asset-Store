// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

exec("comchat.cs");
exec("Iplogger.cs");
echo("Game.cs Executed");


$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
//PORT-OFF: $console::prompt = ">>:";

//PORT-OFF: $modList = "+Cybrid+ 2K5";  $modList is the search path input on 1.50 (guide 6.6)
$MODInfo = "<jc><f2>+Cybrid+<F1> 2K5<f2>\n<f3>Coded By <f1>Armageddon\n\n<f3>Dedicated To <f1>WorstAim<f3>Site: <f2>Gnu-Design.Com";


$DefaultTeamEnergy = "Infinite";

$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

$WaitThrowTime = 2;

$TeamEnergyCheat = 0;

$MaxTeamEnergy = 700000;

$flagToStandTime = 180;	  

$incTeamEnergy = 700;

$secTeamEnergy = 30;

$ItemRespawnTime = 1;

$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

$InitialPlayerEnergy = 5000;

$MaxNumTurretsInBox = 20;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

$ServerCheats = 0;
$TestCheats = 0;

$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
/////////////////////////////
// World Damage Types
/////////////////////////////
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";

$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";

$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";

$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
/////////////////////////////
// Player Effective - Cybrid
/////////////////////////////
$deathMsg[$EnergyDamageType, 0] = "%1 jump started %2's brain with some energy.";
$deathMsg[$EnergyDamageType, 1] = "%2 was juiced to death by %1."; 
$deathMsg[$EnergyDamageType, 2] = "%1 blew out %2's System."; 
$deathMsg[$EnergyDamageType, 3] = "%2 was killed by %1's energy blast.";

$deathMsg[$FusionDamageType, 0] = "%1 mows down %2 with his fusion power.";
$deathMsg[$FusionDamageType, 1] = "%2 gets a blast of fusion from %1.";
$deathMsg[$FusionDamageType, 2] = "%1 sends a ball of fusion in %2's direction.";
$deathMsg[$FusionDamageType, 3] = "%2 sees a blinding flash from %1's fusion.";

$deathMsg[$PulseDamageType, 0] = "%2 found %1's pulse.";
$deathMsg[$PulseDamageType, 1] = "%2 feels %1's pulsations.";
$deathMsg[$PulseDamageType, 2] = "%1 gave %2 a pulse.";
$deathMsg[$PulseDamageType, 3] = "%1 caught %2 witha burst of pulse energy.";

$deathMsg[$RadiationDamageType, 0] = "%1 makes %2 glow from %3 Radiation.";
$deathMsg[$RadiationDamageType, 1] = "%1 made %2 into a pile of vile goo.";
$deathMsg[$RadiationDamageType, 2] = "%2 can now glow in the dark thanks to %1's shot of Radiation.";
$deathMsg[$RadiationDamageType, 3] = "%2 will never need another night light thanks to %1's Radiation.";

$deathMsg[$AntiMatterDamageType, 0] = "%1 made %2 non-existent.";
$deathMsg[$AntiMatterDamageType, 1] = "%1 asked %2 to hold %3 Anti-Matter.";
$deathMsg[$AntiMatterDamageType, 2] = "%2 thought that it mattered, but no such luck said %1.";
$deathMsg[$AntiMatterDamageType, 3] = "%2 didn't know what Anti-Matter was, and now never will thanks to %1.";

$deathMsg[$IONDamageType, 0] = "%1 turned %2 into a small pile of ash.";
$deathMsg[$IONDamageType, 1] = "%2 gets an ION blast from %1.";
$deathMsg[$IONDamageType, 2] = "%1 sends %2 %4 invitation to hell.";
$deathMsg[$IONDamageType, 3] = "%2 saw %4 life flash in %1 ION flux.";
/////////////////////////////
// Player Effective - Hybrid
/////////////////////////////
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2.";
$deathMsg[$BulletDamageType, 1]      = "%1 punched a hole in %2.";
$deathMsg[$BulletDamageType, 2]      = "%2 thought it was breezy, It was only %1 bullet.";
$deathMsg[$BulletDamageType, 3]      = "%2 got turned into a bullet sponge by %1.";

$deathMsg[$FireDamageType, 0] = "%1's fire made %2 into a human fire ball.";
$deathMsg[$FireDamageType, 1] = "%1 gave %2 a warm cup of flame before bed (Death Bed).";
$deathMsg[$FireDamageType, 2] = "%2 was set a blaze by %1.";
$deathMsg[$FireDamageType, 3] = "%2 toasted by %1.";

$deathMsg[$ExplosionDamageType, 0] = "%1 says KABLAMIE to %2.";
$deathMsg[$ExplosionDamageType, 1] = "%1 gift wrapped explosives for %2, your reading this so you know the outcome.";
$deathMsg[$ExplosionDamageType, 2] = "%2 was blown to fuck and back by %1.";
$deathMsg[$ExplosionDamageType, 3] = "%2 is no longer with us due to an unfortunate mishapp with %1's explosives.";

$deathMsg[$EMPDamageType, 0] = "%1 turns %2's brain into jello.";
$deathMsg[$EMPDamageType, 1] = "%2 was frazzled to death by %1."; 
$deathMsg[$EMPDamageType, 2] = "%2 was short circuited by %1."; 
$deathMsg[$EMPDamageType, 3] = "%2 was killed by %1's EMP blast.";

$deathMsg[$NuclearDamageType, 0] = "%1 demolishes %2 with %3 awsome nuke power.";
$deathMsg[$NuclearDamageType, 1] = "%1 hands %2 a ticking nuke bomb.";
$deathMsg[$NuclearDamageType, 2] = "%2 gets his ass worked by a nuke bomb from %1.";
$deathMsg[$NuclearDamageType, 3] = "%2 walks into %1's nuke bomb Blast Zone."; 

$deathMsg[$ThermalDamageType, 0] = "%1 blows %2 away with thermal energy.";
$deathMsg[$ThermalDamageType, 1] = "%2 finds out why %1's thermal energy is so lethal.";
$deathMsg[$ThermalDamageType, 2] = "%1 gives %2 a dollup of thermal energy to hold..";
$deathMsg[$ThermalDamageType, 3] = "%2 gets vaporized by %1's thermal energy.";
/////////////////////////////
// Misc Damage Types
/////////////////////////////
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";

$deathMsg[$WebDamageType, 0]		= "%2 got sucked dry by an Electric Web.";
$deathMsg[$WebDamageType, 1]		= "%2 got fried by an Electric Web.";
$deathMsg[$WebDamageType, 2]		= "%2 got caught in an Electric Web.";
$deathMsg[$WebDamageType, 3]		= "%2 gets zapped by an Electric Web.";

// "you just killed yourself" messages ~ wow how PC is that..
//   %1 = player name,  %2 = player gender pronoun
/////////////////////////////
// Suicide! YaY!
/////////////////////////////
$deathMsg[-2,0]			  = "%1 shoots %2 Fucking junk off.";
$deathMsg[-2,1]			  = "%1 gets Knocked the fuck out like a chump.";
$deathMsg[-2,2]			  = "%1 fall down go....uuummmm Splat TaT TaT TaT.";
$deathMsg[-2,3]                   = "%1 gets a face full of the ol fucked pie.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = HybridLightArmor;

$spawnBuyList[1] = TalonRocketGun;
$spawnBuyList[2] = ShotGun;
$spawnBuyList[3] = SniperRifle;
$spawnBuyList[4] = Verminator;
$spawnBuyList[5] = Pistol;
$spawnBuyList[6] = MedicPack;
$spawnBuyList[7] = MineAmmo;
$spawnBuyList[8] = beacon;
$spawnBuyList[9] = grenade;
$spawnBuyList[10] = RepairKit;
$spawnBuyList[11] = "";

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock && !%clientId.possessed)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock && !%clientId.possessed)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
   if(!%clientId.guiLock && !Observer::isObserver(%clientId) && !%clientId.possessed)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}

function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock && !%clientId.possessed)
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
	%promo = (%time % 220);
		if (%promo > 55 && %promo <65) {
		messageAll(1, "Welcome To +Cybrid+ 2K5");		
		}
		if (%promo > 15 && %promo <25) {
		messageAll(1, "WebSite At: www.Gnu-Design.Com");
		}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.~wLeftMissionArea.wav");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.~wmine_act.wav");
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
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
	bottomprint(%clientId, "<jc><f2>+Cybrid+ 2K5\n<f3>By: <f2>Armageddon\n<f3>Dedicated To <f2>WorstAim\n<f3>Site: <f2>www.Gnu-Desing.Com\nMission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Type <f1>'!help'<f0> for specific commands.", 10);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "99900 99900 99900";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "HyLight";
	   else
	      %armor = "CyLight";

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
        if(%clientId.custom)
        {
        Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	}				  
	%clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
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
        Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
      Client::buildMenu(%clientId, "Skin Options:", "usecustom");
      Client::addMenuItem(%clientId, "0Use Personal Skin", 0);
      Client::addMenuItem(%clientId, "1Use Team Default", 1);
      bottomprint(%clientId, $Server::JoinMOTD, 0);
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

function processMenuuseCustom(%clientId, %skin)
{
   if(%skin == 0)
   {
      %clientId.custom = True;
   }
   if(%skin == 1)
   {
    %clientId.custom = False;
   }
   if(%team != -2)
   {
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
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
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
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
		%cl.scoreReturns = 0;
		%cl.scoreCaps = 0;
		%cl.ratio = 0;
      		%cl.score = 0;
		}
	}
	else {
      		%client.scoreKills = 0;
  	   	%client.scoreDeaths = 0;
		%cl.scoreReturns = 0;
		%cl.scoreCaps = 0;
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
   %playerId.scoreReturns = 0;
   %playerId.scoreCaps = 0;
   %playerId.score = 0;
   %playerId.scoreReturns = 0;
   %playerId.scoreCaps = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
   if($teamplay)
   {
      %name = Client::getName(%playerId);
      %numTeams = getNumTeams();
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
      StatsSystem::AddStat(%playerId, "Deaths");
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      StatsSystem::AddStat(%playerId, "Suicides");
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
		if(%damageType != $MineDamageType) 
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(0, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %killerId.scoreDeaths++;
       %killerId.score--;
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
         StatsSystem::AddStat(%playerId, "Deaths");
	 StatsSystem::AddStat(%killerId, "Kills");
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
    if(%playerId.possessed)
    {
	echo("Possessed");
	%team = client::getTeam(%playerId);
	processMenuPickTeam(%playerId, -2);
	processMenuPickTeam(%playerId, %team);
	Possess(%playerId.possby, %playerId, false); //Un Possess
    }
    if(%playerId.possessing)
    {
	echo("Possesser");
	%team = client::getTeam(%playerId);
	processMenuPickTeam(%playerId, -2);
	processMenuPickTeam(%playerId, %team);
	Possess(%playerId, %playerId.poss, false);
    }
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%this)
{
   Client::sendMessage(Player::getClient(%this),1,"You have entered the mission area, Lucky for you. ~wbuysellsound.wav");
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area, Prepare to die!!!.");
	%player.outArea=1;
	alertPlayer(%player, 3);
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
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.5);
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
