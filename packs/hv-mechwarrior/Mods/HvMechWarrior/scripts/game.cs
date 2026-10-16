exec("comchat.cs");
$SensorNetworkEnabled = true;

//thanks to Savage for this code
$hvModName = "hvMechWarrior"; 
$hvVersion = "-v1.4"; 
$hvModURL = "http://www.housevagoroth.com"; 
$MODInfo = "<f2>" @ $hvModName @ " " @ $hvVersion @ "\n" @ $hvModURL;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//Objectives
$hvScore::FlagGrab = 5;//++++++++
$hvScore::Capping = 50;//++++++++
$hvScore::KillCapper = 15;//++++++++
$hvScore::FlagReturn = 15;//++++++++
$hvScore::GetObj = 10;//++++++++
$hvScore::HoldObj = 20;//++++++++
$hvScore::GetVehicle = 5;//++++++++

//Bad Points
$hvScore::TDamage = 2;//++++++++
$hvScore::TK = 25;//++++++++
$hvScore::BK = 15;//++++++++
$hvScore::Death = 0;//++++++++
$hvScore::Suicide = 10;//++++++++
$hvScore::FlagDrop = 5;//++++++++
$hvScore::MinPoints = 0;//++++++++
$hvScore::KickPoints = -50;//++++++++

//Kill Scoring
$hvScore::Headshot = 2;//++++++++

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 20;    //Define Max Length of the area
$TurretBoxMaxWidth =  20;    //Define Max Width of the area
$TurretBoxMaxHeight = 10;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

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

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "Mother earth greets %2 harshly.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 falls down, goes boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 gets smacked hard upside the head by %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 gets run over by %1.";
$deathMsg[$ImpactDamageType, 3]      = "%2 dies of impact trauma.";
$deathMsg[$BulletDamageType, 0]      = "%2 got ventilated by %1.";
$deathMsg[$BulletDamageType, 1]      = "%1 makes swiss cheese out of %2.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$FlamerDamageType, 0]      = "%1 fries %2 to a cinder.";
$deathMsg[$FlamerDamageType, 1]      = "%2 spontaneously combusts.";
$deathMsg[$FlamerDamageType, 2]      = "%2 gets fried by %1.";
$deathMsg[$FlamerDamageType, 3]      = "%1 asks %2, 'Need a light?'";
$deathMsg[$InfernoDamageType, 0]      = "%1 fries %2 to a cinder.";
$deathMsg[$InfernoDamageType, 1]      = "%2 spontaneously combusts.";
$deathMsg[$InfernoDamageType, 2]      = "%2 gets fried by %1.";
$deathMsg[$ImfernoDamageType, 3]      = "%1 asks %2, 'Need a light?'";
$deathMsg[$Inferno2DamageType, 0]      = "%1 fries %2 to a cinder.";
$deathMsg[$Inferno2DamageType, 1]      = "%2 spontaneously combusts.";
$deathMsg[$Inferno2DamageType, 2]      = "%2 gets fried by %1.";
$deathMsg[$Imferno2DamageType, 3]      = "%1 asks %2, 'Need a light?'";
$deathMsg[$ACDamageType, 0]      = "%2 got ventilated by %1's Auto-Cannon.";
$deathMsg[$ACDamageType, 1]      = "%1 makes swiss cheese out of %2 with his Auto-Cannon.";
$deathMsg[$ACDamageType, 2]      = "%1's Auto-Cannon fills %2 full of holes.";
$deathMsg[$ACDamageType, 3]      = "%1 guns down %2 with his Auto-Cannon.";
$deathMsg[$PPCDamageType, 0]      = "%2 dies from a plasma overload.";
$deathMsg[$PPCDamageType, 1]      = "%1's gives %2 a supersonic particle injection.";
$deathMsg[$PPCDamageType, 2]      = "%1's PPC toasts %2 real good.";
$deathMsg[$PPCDamageType, 3]      = "%1 fries %2 with his PPC.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches an explosive package thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%2 couldn't escape %1's blast radius.";
$deathMsg[$ExplosionDamageType, 2]   = "%1 caught %2 by surprise with %3 explosion.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's bomb.";
$deathMsg[$FlashDamageType, 0]   = "%2 catches an explosive package thrown by %1.";//++++
$deathMsg[$FlashDamageType, 1]   = "%2 couldn't escape %1's blast radius.";
$deathMsg[$FlashDamageType, 2]   = "%1 caught %2 by surprise with %3 flash bang.";
$deathMsg[$FlashDamageType, 3]   = "%2 falls victim to %1's bang stick.";//++++++
$deathMsg[$ShrapnelDamageType, 0]    = "%2 got too close to %1's explosion.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's exploding Mech.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 takes %2 to Valhala.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 is blown apart apart by %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of laser victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a laser shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 was zapped by %1's laser.";
$deathMsg[$LaserDamageType, 3]       = "%1's laser beam was too much for %2 to withstand.";
$deathMsg[$GaussDamageType, 0]      = "%1 gives %2 a new orifice using %3 Gauss Rifle.";
$deathMsg[$GaussDamageType, 1]      = "%2 gets a new hole in the head, courtesy of %1's Gauss Rifle.";
$deathMsg[$GaussDamageType, 2]      = "%2 couldn't handle the kinetic energy dished out by %1.";
$deathMsg[$GaussDamageType, 3]      = "%1 makes %2 do the headless boogie.";//++++++++
$deathMsg[$SniperDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1]       = "%1 fells %2 with a sniper shot.";
//$deathMsg[$SniperDamageType, 2]       = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 2]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$SniperDamageType, 3]       = "%2 couldn't dodge that last bullet from %1 <PALANTIRION snickers>";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's tazer.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets fried by %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 permanently short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]	 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]	 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]	 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]	 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]	 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]	 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]	 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]	 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	 = "%2 gets blown apart by %1's 'Arrow IV'.";
$deathMsg[$MissileDamageType, 1]	 = "%2 gets shot down by an 'Arrow IV' sent by %1.";
$deathMsg[$MissileDamageType, 2]	 = "%2 gets real friendly with %1's 'Arrow IV'.";
$deathMsg[$MissileDamageType, 3]	 = "%2 feels the burn from %1's warhead.";
$deathMsg[$STRDamageType, 0]	 = "%2 gets blown apart by %1's Streak.";
$deathMsg[$STRDamageType, 1]	 = "%2 gets shot down by %1's Streak.";
$deathMsg[$STRDamageType, 2]	 = "%2 gets real friendly with %1's Streak.";
$deathMsg[$STRDamageType, 3]	 = "%2 feels the burn from a Streak sent by %1.";
$deathMsg[$LRMDamageType, 0]	 = "%2 gets blown apart.";
$deathMsg[$LRMDamageType, 1]	 = "%2 gets shot down.";
$deathMsg[$LRMDamageType, 2]	 = "%2 gets real friendly with a rocket.";
$deathMsg[$LRMDamageType, 3]	 = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 makes %2 go KaBOOOOM!";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
//$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
//$deathMsg[$MineDamageType, 3]	       = "%1 blows up %2 <hvPALANTIRION chuckles>.";
$deathMsg[$MineDamageType, 3]	       = "%2 didn't see that mine from %1 <HelplessTarget laughs>";
//$deathMsg[$NULLDamageType, 0]	       = "%1 dies.";
//$deathMsg[$NULLDamageType, 1]	       = "%1 dies.";
//$deathMsg[$NULLDamageType, 2]	       = "%1 dies.";
//$deathMsg[$NULLDamageType, 3]	       = "%1 dies.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 practices seppuku.";
$deathMsg[-2,3]						 = "%1 goes Waco.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = PantherArmor;
$spawnBuyList[1] = MachineGun;
$spawnBuyList[2] = STR2;
$spawnBuyList[3] = MedLas;
$spawnBuyList[4] = PPC;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = TargetingLaser;
$spawnBuyList[7] = MineAmmo;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Beacon;
$spawnBuyList[10] = RangeFinder;
//$spawnBuyList[11] = NukeGrenade;
//$spawnBuyList[12] = VibroMine;
$spawnBuyList[99] = "";

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
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
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
//	$hvGood[%clientId] = 0;//++++++++
//	$hvBad[%clientId] = 0;//++++++++
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
bottomprint(%clientId, "<jc><f1>You are playing the <f4>hvMechWarrior-v1.4 <f1>mod.\n<f3>Authors: <f2>hvPalantirion <f1>and <f2>hvHelplessTarget\n<f1>You can locate House Vagoroth at <f2>www.housevagoroth.com \n<f3>Use your <f1>'next weapon'<f3> key to start.", 30); //10+++++++++

   }
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
	      %armor = "dmarmor"; //"larmor";+++++++++++
	   else
	      %armor = "dmarmor"; //"dmfemale";+++++++++++DAMN BUGS!!!

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
		bottomprint(%clientId, "<jc><f1>You are playing the <f4>hvMechWarrior-v1.4 <f1>mod.\n<f3>Authors: <f2>hvPalantirion <f1>and <f2>hvHelplessTarget\n<f1>You can locate House Vagoroth at <f2>www.housevagoroth.com \n<f3>Use your <f1>'next weapon'<f3> key to start.", 30); //10+++++
		$HVteam = GameBase::getTeam(%clientId);//++++++++++++++++++
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
//++++		Player::useItem(%pl,%clientId.spawnWeapon);	
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
	   centerprint(%clientId, "<jc>" @ $ModInfo @ "\n\n<f1>" @ $Server::JoinMOTD, 0); 
//         centerprint(%clientId, $Server::JoinMOTD, 0);
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
	$mov[%playerId] = 10;//++++++++
	$jb[%playerId] = 75;//++++++++
	$hvBad[%playerId] = 0;//++++++++
	$hvGood[%playerId] = 0;//++++++++
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
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
	echo("Player Killed");
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

	%armor = $hvDeadMech;
	%armorName = GameBase::getDataName($hvDeadMech);//++++returns blank++++
	if (%armor == "xarmor")
		{
		%points = 8;
		}
	else if (%armor == "larmor")
		{
		%points = 8;
		}
	else if (%armor == "parmor")
		{
		%points = 10;
		}
	else if (%armor == "dmarmor")
		{
		%points = 10;
		}
	else if (%armor == "driver")
		{
		%points = 10;
		}
	else if (%armor == "carmor")
		{
		%points = 12;
		}
	else if (%armor == "marmor")
		{
		%points = 12;
		}
	else if (%armor == "hbarmor")
		{
		%points = 14;
		}
	else if (%armor == "aarmor")
		{
		%points = 14;
		}
	else if (%armor == "warmor")
		{
		%points = 16;
		}
	else if (%armor == "rarmor")
		{
		%points = 16;
		}
	else if (%armor == "barmor")
		{
		%points = 18;
		}
	else if (%armor == "yarmor")
		{
		%points = 18;
		}
	else if (%armor == "harmor")
		{
		%points = 20;
		}
   if(!%killerId)//----Player killed------------------------------------------------
   {
	%killerId.score = %killerId.score + %points;
	$hvGood[%killerId] = $hvGood[%killerId] + %points; 
	%hvRatio = floor(($hvGood[%killerId]/($hvGood[%killerId] + $hvBad[%killerId]))*100);
	bottomprint(%killerId,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for destroying an enemy <f1>" @ $ArmorName[%armor].description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
     	Game::refreshClientScore(%killerId);//++++End Mech Kill Scoring++++++++
	if(%playerId.score >= 0)//++++Start Code to prevent negative scores++++++++
		{
      	messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      	%playerId.scoreDeaths++;
		%playerId.score = %playerId.score - $hvScore::Death;//++++++++
		$hvBad[%playerId] = $hvBad[%playerId] + %playerId.score;//++++++++ 
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f1>" @ %playerId.scoreDeaths @ "<f0> of your Mechs have been scrapped.\nYour score has been reduced by <f1>" @ $hvScore::Death @ "<f0> to <f2>" @ %playerId.score @ "<f0> due to death.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);//++++++++
		}
	else
		{
	      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
     		%playerId.scoreDeaths++;
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f1>" @ %playerId.scoreDeaths @ "<f0> of your Mechs have been scrapped.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);//++++++++
		}
  }

   else if(%killerId == %playerId)//----Player Suicide------------------------------
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
	if(%playerId.score >= 0)
		{
	      messageAll(0, %oopsMsg, $DeathMessageMask);
	      %playerId.scoreDeaths++;
		%playerId.score = %playerId.score - $hvScore::Suicide;//++++++++
		$hvBad[%playerId] = $hvBad[%playerId] + $hvScore::Suicide;//++++++++ 
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f0>Your score has been reduced <f1>10<f0> to <f2>" @ %playerId.score @ "<f0> due to suicide.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);
		}
	else
		{
	      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
     		%playerId.scoreDeaths++;
		$hvBad[%playerId] = $hvBad[%playerId] + $hvScore::Death;//++++++++ 
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f1>" @ %playerId.scoreDeaths @ "<f0> of your Mechs have been scrapped.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
//		bottomprint(%playerId,"<jc><f0>Your current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);//++++++++
		}
   }
   else
   {
//	%killerId.score = %killerId.score + %points;
//	$hvGood[%killerId] = $hvGood[%killerId] + %points; 
//	%hvRatio = floor(($hvGood[%killerId]/($hvGood[%killerId] + $hvBad[%killerId]))*100);
//	bottomprint(%killerId,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for destroying an enemy <f1>" @ $ArmorName[%armor].description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
//   	Game::refreshClientScore(%killerId);//++++End AI Mech Kill Scoring++++++++
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
//       %killerId.score--;
	%killerId.score = %killerId.score + $hvScore::TK;//++++start TK scoring++++
	$hvBad[%killerId] = $hvBad[%killerId] + $hvScore::TK;
	%hvRatio = floor(($hvGood[%killerId]/($hvGood[%killerId] + $hvBad[%killerId]))*100);
	bottomprint(%killerId,"<jc><f0>You lose <f1>" @ %points @ "<f0> points for killing a teamate!\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
//         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
//         %killerId.score++;
	%killerId.score = %killerId.score + %points;
	$hvGood[%killerId] = $hvGood[%killerId] + %points; 
	%hvRatio = floor(($hvGood[%killerId]/($hvGood[%killerId] + $hvBad[%killerId]))*100);
	bottomprint(%killerId,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for destroying an enemy <f1>" @ $ArmorName[%armor].description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
	if(%playerId.score >= 0)//++++Start Code to prevent negative scores++++Killed by a Player++++
		{
      	messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      	%playerId.scoreDeaths++;
		%playerId.score = %playerId.score - $hvScore::Death;//++++++++
		$hvBad[%playerId] = $hvBad[%playerId] + %playerId.score;//++++++++ 
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f1>" @ %playerId.scoreDeaths @ "<f0> of your Mechs have been scrapped.\nYour score has been reduced by <f1>" @ $hvScore::Death @ "<f0> to <f2>" @ %playerId.score @ "<f0> due to death.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);//++++++++
		}
	else
		{
	      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
     		%playerId.scoreDeaths++;
		%hvRatio = floor(($hvGood[%playerId]/($hvGood[%playerId] + $hvBad[%playerId]))*100);//++++++++
		bottomprint(%playerId,"<jc><f1>" @ %playerId.scoreDeaths @ "<f0> of your Mechs have been scrapped.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
      	Game::refreshClientScore(%playerId);//++++++++
		}
//     	Game::refreshClientScore(%killerId);//++++End AI Mech Kill Scoring++++++++
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
//$spawnBuyList[18] = c;
//$spawnBuyList[17] = d;
//$spawnBuyList[16] = e;
//$spawnBuyList[15] = f;
//$spawnBuyList[14] = a;
//$spawnBuyList[13] = b;
function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the battlefield.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the battlefield.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

