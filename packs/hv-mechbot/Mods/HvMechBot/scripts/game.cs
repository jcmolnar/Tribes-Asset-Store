exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;


//  Global Variables

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = $Spoonbot::DefaultTeamEnergy;

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
$deathMsg[$ACDamageType, 0]      = "%2 got ventilated by %1's Auto-Cannon.";
$deathMsg[$ACDamageType, 1]      = "%1 makes swiss cheese out of %2 with his Auto-Cannon.";
$deathMsg[$ACDamageType, 2]      = "%1's Auto-Cannon fills %2 full of holes.";
$deathMsg[$ACDamageType, 3]      = "%1 guns down %2 with his Auto-Cannon";
$deathMsg[$PPCDamageType, 0]      = "%2 dies from a plasma overload.";
$deathMsg[$PPCDamageType, 1]      = "%1's gives %2 a supersonic particle injection.";
$deathMsg[$PPCDamageType, 2]      = "%1's PPC toasts %2 real good.";
$deathMsg[$PPCDamageType, 3]      = "%1 fries %2 with his PPC.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches an explosive package thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%2 couldn't escape %1's blast radius.";
$deathMsg[$ExplosionDamageType, 2]   = "%1 caught %2 by surprise with %3 explosion.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's bomb.";
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
$deathMsg[$GaussDamageType, 3]      = "%1's Gauss Rifle takes out %2.";
$deathMsg[$SniperDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2]       = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$SniperDamageType, 4]       = "%2 couldn't dodge that last bullet from %1 <hvPALANTIRION snickers>.";
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
$deathMsg[$MineDamageType, 0]	       = "%1 makes %2 go KaBOOOOM.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
$deathMsg[$MineDamageType, 4]	       = "%1 blows up %2 <hvPALANTIRION chuckles>.";
$deathMsg[$MineDamageType, 5]	       = "%2 didn't see that mine from %1 <hvHelplessTarget laughs>.";

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
//$spawnBuyList[10] = VibroMine;
//$spawnBuyList[11] = NukeGrenade;
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

function Game::PopupSpoonbotMessage(%text)
{
	if (!isObject(Notice))
		newObject(Notice, FearGui::FearGuiBox, %width - 250,%height - 157, 200,112);
	if (!isObject(NoticeText))
		newObject(NoticeText, FearGuiFormattedText, 1,0,190,400);
	AddToSet(Notice, NoticeText);
	AddToSet(MainMenuGui, Notice);
	Control::SetValue(NoticeText, %text);
}

function Game::RemoveSpoonbotMessage()
{
	%text = " ";
	Control::SetValue(NoticeText, %text);

	deleteObject(NoticeText);
	deleteObject(Notice);

}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

	exec("ai");

    BotTree::Init_Tree();		//Initialise Tree Matrix - Wicked69
	BotFuncs::ScanObjectTree(); //Initialise Bot Targets

   AI::ProcessAutoSpawn();                               //Spawn all the bots defined in SPOONBOT.CS (Werewolf)

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
      // initial drop
	//Check if HvMechBot.CS is inside the right directory. By Werewolf.

	// PORT FIX: the settings file is no longer config\HvMechBot.cs (a pack may not install into
	// config\); it is this mod's entry script, Mods\HvMechBot\HvMechBot.cs. isFile() only sees a real
	// file at that one path, so every player was shown the 20 second "HvMechBot WILL NOT WORK"
	// error. Test the flag the settings file sets instead (BotCheck.cs tested both).
	if ($Spoonbot::SPOONBOTCSLOADED)
	{
	      centerprint(%clientId, "<jc><f0>HvMechBot <f1>V" @ $SPOONBOT::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>O<f0> for specific objectives.", 10);
	}
	else
	{
	      centerprint(%clientId, "<jc><f0>HvMechBot <f1>V" @ $SPOONBOT::Version @ "\n<f0>ERROR!!<f1>\nThe file HvMechBot.cs was not found at <f2>Tribes\\config\\HvMechBot.cs<f1>\nHvMechBot WILL NOT WORK!", 20);
	}


//bottomprint(%clientId, "<jc><f1>You are playing the <f4>HvMechBot V" @ $SPOONBOT::Version @ " <f1>mod.\n<f3>Authors: <f2>hvPalantirion <f1>and <f2>hvHelplessTarget\n<f1>You can locate House Vagoroth at <f2>www.geocities.com/TimesSquare/Fortress/5514 \n<f3>Use the <f1>'r' (next weapon)<f3> key to play.", 60);

bottomprint(%clientId, "<jc><f0><f4>HvMechBot V" @ $SPOONBOT::Version @ " <f1>mod.\n<f3>Authors: <f2>hvPalantirion<f1>, <f2>hvHelplessTarget<f1>, <f2>The SpoonBot Crew<f1>, and <f2>Mr. X\n<f1>See <f2>www.geocities.com/TimesSquare/Fortress/5514 \n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ " ", 15);
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
//+++		Player::useItem(%pl,%clientId.spawnWeapon);	
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
if (isObject($BotHUD[0]))
	deleteObject($BotHUD[0]);
if (isObject($BotHUD[1]))
	deleteObject($BotHUD[1]);
if (isObject(BotHUD_Frame))
	deleteObject(BotHUD_Frame);
if (isObject(BotHUD_Main))
	deleteObject(BotHUD_Main);

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
      if((%clientId.justConnected) && (!$Spoonbot::BotTree_Design))
      {
         centerprint(%clientId, $Server::JoinMOTD, 0);
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

function Game::PopupSpoonbotMessage(%text)
{
	if (!isObject(Notice))
		newObject(Notice, FearGui::FearGuiBox, %width - 250,%height - 157, 200,112);
	if (!isObject(NoticeText))
		newObject(NoticeText, FearGuiFormattedText, 1,0,190,400);
	AddToSet(Notice, NoticeText);
	AddToSet(MainMenuGui, Notice);
	Control::SetValue(NoticeText, %text);
}

function Game::RemoveSpoonbotMessage()
{
	%text = " ";
	Control::SetValue(NoticeText, %text);

	deleteObject(NoticeText);
	deleteObject(Notice);

}
