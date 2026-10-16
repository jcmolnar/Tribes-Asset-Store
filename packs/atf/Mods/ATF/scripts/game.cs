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
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 10000000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 10000000;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 1;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 25000; 
$RemoteInvEnergy = 30000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = 0;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 100;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 1000000;



//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 15;    //Define Max Length of the area
$TurretBoxMaxWidth =  15;    //Define Max Width of the area
$TurretBoxMaxHeight = 15;    //Define Max Height of the area

$TurretBoxMinLength = 4;	  //Define Min Length from another turret
$TurretBoxMinWidth =  4;	  //Define Min Width from another turret
$TurretBoxMinHeight = 4;    //Define Min Height from another turret

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
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%1 blows %2 to little bits.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed explosive.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's Explosive caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's weapon of mass destruction.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's gun.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	    = "%2 exploded.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 meets death face to face.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
$deathMsg[$AlienDamageType, 0]	       = "%1 uses %2 for Xythilian weapons testing.";
$deathMsg[$AlienDamageType, 1]	       = "%2 gets abducted by %1.";
$deathMsg[$AlienDamageType, 2]	       = "%1 made %2 Radioactive";
$deathMsg[$AlienDamageType, 3]	       = "%1 introduced %2 to %3 nuclear core power";
$deathMsg[$MaChDamageType, 0]	       = "%2 burned alive from %1 AfterBurner.";
$deathMsg[$MaChDamageType, 1]	       = "%2 got hit by %1's mach boost.";
$deathMsg[$MaChDamageType, 2]	       = "%2 ate %1's AfterBurner.";
$deathMsg[$MaChDamageType, 3]	       = "%1's speed was too much for %2";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 had his gun aimed backwards";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 misplaces %2 life";
$deathMsg[-2,3]						 = "%1 was just cleaning his gun when....";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Chaingun;
$spawnBuyList[2] = AS;
$spawnBuyList[3] = Blaster;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Money;
$spawnBuyList[6] = FlameGun;


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
   if (%time==5)
   {
	messageAll(0, "5 seconds till utter anhilation :) enjoy");
   }
   UpdateClientTimes(%time);
}



function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started. Let the Games begin!");
   Game::resetScores();	


	exec("ai");

   
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
		
	

if(%clientId.custom)
		{
		echo ("Setting user skin for player " @ %clientId @ ": " @ $Client::info[%clientId, 0]);
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

	%clientName = Client::getName(%clientId);
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
//============================================================================================================= Player - Personal Skin Menu

	 Client::buildMenu(%clientId, "Select your skin:", "usecustom");
	 Client::addMenuItem(%clientId, "0 Use Personal Skin", 0);
	 Client::addMenuItem(%clientId, "1 Use Team Default", 1);
			
         
%rndCheckg=Floor(getRandom()*50);
	

	if (%rndCheckg > 0 && %rndCheckg <=24)
		{
		bottomprint(%clientId, "<jc><f2> Now doesn't descriminate sexually!!! Sweet Jesus!!!", 20);
		}	 
	
	else if (%rndCheckg >24 && %rndCheckg < 35)
		{
		 bottomprint(%clientId, "<jc><f2>Now with motion Activated Blade moving Action!!!", 20);
		}
	
	else if (%rndCheckg > 34 && %rndCheckg < 60)
		{
		bottomprint(%clientId, "<jc><f2>The ALDDG wants YOU!!!  So join the Association of Lesser Dieties and Demi God ...and start sacrificing virgins today!!!", 20);
		}
     
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
   if(%clientId.observerMode != "justJoined")
      return;
   %clientId.observerMode = "";
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

function Client::onKilled(%playerId, %killerId, %damageType, %ClientId)
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
		if ($m==1)
		{
		%killerId.score += 8;
		Client::sendMessage(%clientId, $MSGTypeGame, "8 point bonus!!!");
		}
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
	if ($k==1)
		{
		%killerId.score+=5;
		Client::sendMessage(%clientId, $MSGTypeGame, "5 point bonus!!!");
		}
	if (Client::getTeam(%clientId)==-2)
		{
		%killerId.score+=10;
		Client::sendMessage(%clientId, $MSGTypeGame, "10 point bonus!!!");
		}
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
  // MessageAll(0, %ClientID "left");
	// do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the battle area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the battle area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}
//this next stuff is added by HaCk cause of some serious glitches that were pissing him off 
//

function remoteGodHello(%clientId)
{ return;

   messageall(0,"Server God: Hello " @ Client::getName(%clientId) @ " and Welcome to {ATF} Mod");
}


function remoteGodTalkStart(%rc)
{ if(%rc != "") return;
//since i basically have this only run at the start of a server...i have shit initializing here....not very safe....
//but hopefully it'll work ok...not like any one reads the source or anything ;)

 messageall(0,"Server God: Initializing Talk Mode");
 $k = 0;
   $m = 0;
   $q = 0;	
%duel=0;
%init=0;
%following=0;
%seen=0;
   schedule("remoteGodtalkstart2();", 3);
}


function remoteMeteora(%rc)
{ if(%rc != "") return;
%met=1;
$cdtrack=$cdTrack++;
rbStop (CD);
rbPlay (CD, $cdTrack);
if($cdTrack==1)
{
schedule("remoteMeteora();", 13);
%Meteora="Track 1 :  Foreword";
}
if($cdTrack==2)
{
schedule("remoteMeteora();", 187);
%Meteora="Track 2 :  Don't Stay";
}
if($cdTrack==3)
{
schedule("remoteMeteora();", 213);
%Meteora="Track 3 :  Somewhere I belong";
}
if($cdTrack==4)
{
schedule("remoteMeteora();", 175);
%Meteora="Track 4 :  Lying From You";
}
if($cdTrack==5)
{
schedule("remoteMeteora();", 164);
%Meteora="Track 5 :  Hit The Floor";
}
if($cdTrack==6)
{
schedule("remoteMeteora();", 204);
%Meteora="Track 6 :  Easier To Run";
}
if($cdTrack==7)
{
schedule("remoteMeteora();", 172);
%Meteora="Track 7 :  Faint";
}
if($cdTrack==8)
{
schedule("remoteMeteora();", 197);
%Meteora="Track 8 :  Figure.09";
}
if($cdTrack==9)
{
schedule("remoteMeteora();", 196);
%Meteora="Track 9 :  Breaking The Habit";
}
if($cdTrack==10)
{
schedule("remoteMeteora();", 185);
%Meteora="Track 10 :  From The Inside";
}
if($cdTrack==11)
{
schedule("remoteMeteora();", 188);
%Meteora="Track 11 :  Nobody's Listening";
}
if($cdTrack==12)
{
schedule("remoteMeteora();", 144);
%Meteora="Track 12 :  Session";
}
if($cdTrack==13)
{
schedule("remoteMeteora();", 189);
%Meteora="Track 13 :  Numb";
}
 messageall(0,"Mix Master Server God: Now playing: " @ %Meteora);
if($cdTrack==13)
{
$cdtrack=0;
}
}

function remoteMusicChange(%rc)
{ if(%rc != "") return;
if (%met!=1){
$cdtrack=$cdTrack++;
 messageall(0,"Mix Master Server God: Now switching Tracks!!!");
rbStop (CD);
rbPlay (CD, $cdTrack);

if($cdTrack==13)
{
$cdtrack=0;
}
schedule("remoteMusicChange();", 180);
}
}



function remoteGodHelloHaCk(%rc)
{ if(%rc != "") return;

   messageall(0,"Server God: Hey HaCk, how are you?");
}


function remoteGodHelloLeader(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: Hey Leader, good to see you in the server.");

}


function remoteGodHelloDontKnowM(%rc)
{ if(%rc != "") return;
   messageall(0,"Server God: Hello.... HaCk is he a friend of yours?");

}


function remoteGodHelloDontKnowf(%rc)
{ if(%rc != "") return;
   messageall(0,"Server God: oops.....is SHE a friend of yours? :)");

}


function remoteGodKewl(%rc)
{ if(%rc != "") return;
  
   messageall(0,"Server God: Kewl :)");

}


function remoteGodInvkills2(%rc)
{ if(%rc != "") return;
 
   messageall(0,"Server God: Inv Killing is bad, 2 more inv kills and you will be punished!!!!");

}


function remoteGodInvKills1(%rc)
{ if(%rc != "") return;
  
   messageall(0,"Server God: Uh oh....one more inv kill and you will be punished!!!");

}


function remoteGodPower(%rc)
{ if(%rc != "") return;
  
   messageall(0,"Server God: now granting SERVER GOD powers (law breakers beware)");

}


function remoteGodOk(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: Ok");

}

function remoteGodNp(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: No Problem.");

}

function remoteGodGood(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: Good Good :)");

}


function remoteGodSux(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: That Sux :( .....I think i know how to cheer you up.....");

}

function remoteGodHope(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: I hope you enjoy the mod :)");

}

function remoteGodSorry(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: Sorry :(");

}


function remoteGodHaCk(%rc)
{ if(%rc != "") return;
   
   CenterprintAll("<jc>  010101010101100101010101010101100101010101010101101011110101010110101110111101100101001010101010101010101010100110101   HaCk is in Control  01010101010110010101010101010110101111010101011010111011110110010100101010101011001010101010101011010111101010101101011101111011001010", 10);
   
}


function remoteEgoTrip(%rc)
{ if(%rc != "") return;
   
CenterprintAll("<jc>010101100101010101010101100101010101010101101011110101010110101110111101100101001010101010101010101010100110101   Ashley is Teh Suxxor But HaCk is Teh Roxxor01010101010110010101010101010110101111010101011010111011110110010100101010101011001010101010101011010111101010101101011101111011001010", 10);
   
MessageAll(0,"Ashley Teh Sux!!!!!!!");
}

function remoteGodTalkStart2(%rc)
{ if(%rc != "") return;
 
if ($q==0)  
{
%rndCheck=Floor(getRandom()*30);
	if (%rndCheck <=9)
		{
		schedule("remoteBoredom();", 60);
		}
	else if (%rndCheck > 9)
		{
		schedule("remoteGodTip();", 40);
		schedule("remoteGodTalkStart2();", 50);
		}
}   
	
}

function remoteBoredom(%rc)
{ if(%rc != "") return;
   
%rndCheck=Floor(getRandom()*50);
	

	if (%rndCheck > 0 && %rndCheck <=24)
		{
		CenterprintAll("<jc><f2> Blood Lust ", 3);
		$k=1;
		schedule("remoteBonusEnd();", 60);
		echo("Blood Bonus");
		}	 
	
	else if (%rndCheck >24 && %rndCheck < 40)
		{
		CenterprintAll("<jc><f2> Anti-Team Warfare", 3);
		$m=1;
		schedule("remoteBonusEnd();", 70);
		echo("Anti-Productivity Bonus");
		}
	
	else if (%rndCheck > 39 && %rndCheck < 60)
		{
		
		%tag=1;
		schedule("remoteBonusEnd3();", 20);
		echo("Tag");
		}
}



function remoteGodAnalyzing(%rc)
{ if(%rc != "") return;
  
   messageall(0,"Server God: Analyzing.....");

}


function remoteGodanalyze2(%rc)
{ if(%rc != "") return;
   
   messageall(0,"Server God: .........");

}


function remoteGodComplete(%rc)
{ if(%rc != "") return;
  
   messageall(0,"Server God: Analysis complete");

}


function remoteGod(%rc)
{ if(%rc != "") return;
   
   messageall(3,"Server God: This is version 1.2.7.g.69.kama.sutra.mstr.bate of a tribes bot like creation for {ATF} mod....Made by {ATF} HaCk");

}



function remoteGodYawn(%rc)
{ if(%rc != "") return;
  
   messageall(3,"Server God: *Yawn*");

}

function remoteBonusEnd(%rc)
{ if(%rc != "") return;
  
   CenterprintAll("<jc><f3> Blood Lust is Now Over", 3);
   $k = 0;
   $q = 0;
   schedule("remoteGodTalkStart2();", 60);
}

function remoteBonusEnd2(%rc)
{ if(%rc != "") return;
  
   CenterprintAll("<jc><f4> Anti-Team Warfare has Ended", 3);
   $m = 0;
   $q = 0;
   schedule("remoteGodTalkStart2();", 60);
}

function remoteBonusEnd3(%rc)
{ if(%rc != "") return;
remoteKill($IT);	 
   $q = 0;
   %Tag=0;
   schedule("remoteGodTalkStart2();", 60);
}


function remoteBotSpawn(%num)
{ %num = floor(%num); if(%num < 1 || %num > 6) return;
echo("Names Check");
$AI_Names[0] = "HaCkBot";
$AI_Names[1] = "PingBurst";
$AI_Names[2] = "Pondering";
$AI_Names[3] = "Scott";
$AI_Names[4] = "HaCkEr";
$AI_Names[5] = "DDR FREAK";
$AI_Names[6] = "(>`.`)>";

echo("Armors Check");
$armors[1] = "tarmor";
$armors[2] = "sarmor";
$armors[3] = "warmor";
$armors[4] = "warmor";
$armors[5] = "Aarmor";


echo("Initialize Bots");
%group = "MissionGroup/Teams/team1/DropPoints/Random";
%targetc = "MissionGroup/Teams/team0/DropPoints/Random";
%group2=nameToID( %targetc ); 
%spawnMarker = Group::getObject(%group2, 1);
%spawnPos = GameBase::getPosition(%spawnMarker);

	//must have more names than %num
	%sname = floor(getrandom() * (7-%num));
	for(%i=0;%i<%num;%i++) {
		$names[%i] = %sname + %i;
	}	
	for(%k=0;%k < %num;%k++) {
		%AIname = $AI_Names[$names[%k]];
		%armor = floor(getRandom()*6);

		%armr=$armors[%armor];

	createAI(%AIname, %group, %armr, %AIname,%targetc);
        	%aiId = AI::getId(%AIname);
		%aiObj = client::getOwnedObject(%aiId);	
         	GameBase::setTeam(%aiId, 1);
         	AI::setVar( %AIname,  attackMode, 1);
		AI::setVar( %AIname,  pathType, 0);
	AI::setWeapons(%aiName,%armor,%spawnPos);
	
		%aiObj.lastFlightTime = getsimtime()-7;
	}
	

}


function remoteGodTip(%rc)
{ if(%rc != "") return;
//Hehehe These next 2 lines make it completely random :)    
 %rndCheck3=Floor(getRandom()*150);
%rndCheck=Floor(getRandom()*%rndCheck3);
// THis took me an hour or 2 to type .... but it is worth it :) 

        if (%rndCheck <=1)
		MessageAll(3,"ServerGod: Evil Overlord Tip 1: My Legions of Terror will have helmets with clear plexiglass visors, not face-concealing ones.");
	else if (%rndCheck > 1 && %rndCheck <=4)
		MessageAll(3,"ServerGod: Evil Overlord Tip 4: Shooting is not too good for my enemies.");
	else if (%rndCheck > 4 && %rndCheck <=6)
		MessageAll(3,"ServerGod: Evil Overlord Tip 6: I will not gloat over my enemies' predicament before killing them.");
	else if (%rndCheck > 6 && %rndCheck <=8)
		MessageAll(3,"ServerGod: Evil Overlord Tip 12: One of my advisors will be an average five-year-old child. Any flaws in my plan that he is able to spot will be corrected before implementation.");
	else if (%rndCheck > 8 && %rndCheck <=10)
		MessageAll(3,"ServerGod: Evil Overlord tip 16: I will never utter the sentence 'But before I kill you, there's just one thing I want to know'.");
	else if (%rndCheck > 10 && %rndCheck <=12)
		MessageAll(3,"ServerGod: Evil Overlord Tip 20: Despite its proven stress-relieving effect, I will not indulge in maniacal laughter. When so occupied, it's too easy to miss unexpected developments that a more attentive individual could adjust to accordingly.");
	else if (%rndCheck > 12 && %rndCheck <=14)
		MessageAll(3,"ServerGod: Evil Overlord Tip 28: My pet monster will be kept in a secure cage from which it cannot escape and into which I could not accidentally stumble.");
	else if (%rndCheck > 14 && %rndCheck <=16)
		MessageAll(3,"ServerGod: Evil Overlord Tip 29: I will dress in bright and cheery colors, and so throw my enemies into confusion.");
	else if (%rndCheck > 16 && %rndCheck <=18)
		MessageAll(3,"ServerGod: Mod Tip # 1: Mach 5 Armor + Mach Boost = SuperSpeed!!!!");
	else if (%rndCheck > 18 && %rndCheck <=20)
		MessageAll(3,"ServerGod: Mod Tip # 2: Aliens in this mod are weak against Blasters.");
	else if (%rndCheck > 20 && %rndCheck <=22)
		MessageAll(3,"ServerGod: Mod Tip # 3: When building an airbase or mini ground base make sure to set a up warp pads for easy access ");
	else if (%rndCheck > 22 && %rndCheck <=24)
		MessageAll(3,"ServerGod: Mod Tip # 4: If you can charge your kaioken above 80% you will go Super Saiyan.");
	else if (%rndCheck > 24 && %rndCheck <=26)
		MessageAll(3,"ServerGod: Mod Tip # 5: If you buy a heavy core gen for xythilian armor all your attacks are upgraded....but you become massively heavy.");
	else if (%rndCheck > 26 && %rndCheck <=28)
		MessageAll(3,"ServerGod: Mod Tip # 6: Typing ServerGod: DuelCount will have me count down for you :)");
	else if (%rndCheck > 28 && %rndCheck <=30)
		MessageAll(3,"ServerGod: Mod Tip # 7: If you see the words Derek Achieves Super Saiyan then make sure to stay far away from him");
	else if (%rndCheck > 30 && %rndCheck <=32)
		MessageAll(3,"ServerGod: Mod Tip # 8: Don't INV kill if HaCk is in the server...if you do HaCk will punish you");
	else if (%rndCheck > 32 && %rndCheck <=34)
		MessageAll(3,"ServerGod: Mod Tip # 9: Test each of the modifier packs to see which one suits you best");
	else if (%rndCheck > 34 && %rndCheck <=36)
		MessageAll(3,"ServerGod: Quick Tip: Don't sweat the petty things, Don't pet the sweaty things.");
	else if (%rndCheck > 36 && %rndCheck <=38)
		MessageAll(3,"ServerGod: Mod Tip: To run Mix Master ServerGod to play your CD's in the Cd Drive press the ` key (right above tab) and type remoteMusicChange();  ");
	else if (%rndCheck > 38 && %rndCheck <=40)
		MessageAll(3,"ServerGod: I Have to go to the bath room.");
	else if (%rndCheck > 40 && %rndCheck <=42)
		MessageAll(3,"ServerGod: I Just pee'd in my pants :(");
	else if (%rndCheck > 42 && %rndCheck <=44)
		MessageAll(3,"ServerGod: ELVIS VIRUS: Your computer gets fat, slow and lazy, then self-destructs --only to resurface at shopping malls and service stations across rural America.");
	else if (%rndCheck > 44 && %rndCheck <=46)
		MessageAll(3,"ServerGod: KEVORKIAN VIRUS: Helps your computer shut down as an act of mercy.");
	else if (%rndCheck > 46 && %rndCheck <=48)
		MessageAll(3,"ServerGod: HEALTH CARE VIRUS: Tests your system for a day, finds nothing wrong and sends you a bill for 4,500 bucks.");
	else if (%rndCheck > 48 && %rndCheck <=50)
		MessageAll(3,"ServerGod: OPRAH WINFREY VIRUS: Your 200MB hard drive suddenly shrinks to 80MB, and then slowly expands back to 200MB.");
	else if (%rndCheck > 50 && %rndCheck <=52)
		MessageAll(3,"ServerGod: PAUL REVERE VIRUS: This revolutionary virus does not horse around. It warns you of impending hard disk attack , once if by LAN, twice if by C:");
	else if (%rndCheck > 52 && %rndCheck <=54)
		MessageAll(3,"ServerGod: RIGHT TO LIFE VIRUS: Won't allow you to delete a file, regardless of how old it is. If you attempt to erase a file, it requires you to first see a counselor about possible alternatives.");
	else if (%rndCheck > 54 && %rndCheck <=56)
		MessageAll(3,"ServerGod: ROSS PEROT VIRUS: Activates every component in your system, just before the whole damn thing quits. ");
	else if (%rndCheck > 56 && %rndCheck <=58)
		MessageAll(3,"ServerGod: ARNOLD SCHWARZENEGGER VIRUS: Terminates and stays resident. It'll be back. ");
	else if (%rndCheck > 58 && %rndCheck <=60)
		MessageAll(3,"ServerGod: DAN QUAYLE VIRUS: Their is sumthing rong wit your komputer, ewe jsut cant figyour out watt! ");
	else if (%rndCheck > 60 && %rndCheck <=62)
		MessageAll(3,"ServerGod: GOVERNMENT ECONOMIST VIRUS: Nothing works, but all your diagnostic software says everything is fine. ");
	else if (%rndCheck > 62 && %rndCheck <=64)
		MessageAll(3,"ServerGod: FEDERAL BUREAUCRAT VIRUS: Divides your hard disk into hundreds of little units, each of which does practically nothing, but all of which claim to be the most important part of your computer.");
	else if (%rndCheck > 64 && %rndCheck <=66)
		MessageAll(3,"ServerGod: AT&T VIRUS: Every three minutes it tells you what great service you are getting. ");
	else if (%rndCheck > 66 && %rndCheck <=68)
		MessageAll(3,"ServerGod: MCI VIRUS: Every three minutes it reminds you that you're paying too much for the AT&T virus.");
	else if (%rndCheck > 68 && %rndCheck <=70)
		MessageAll(3,"ServerGod: PBS VIRUS: Your computer stops every few minutes to ask for money.");
	else if (%rndCheck > 70 && %rndCheck <=72)
		MessageAll(3,"ServerGod: LAPD VIRUS: It claims it feels threatened by the other files on your PC and erases them in 'self-defense.' ");
	else if (%rndCheck > 72 && %rndCheck <=74)
		MessageAll(3,"ServerGod: O.J. VIRUS: It claims that it did not, could not and would not delete two of your files and vows to find the virus that did it. ");
	else if (%rndCheck > 74 && %rndCheck <=76)
		MessageAll(3,"ServerGod: BOUCHARD VIRUS: Attempts to remove the hard drive from your computer. If that doesn't work it terminates and stays resident at public expense. ");
	else if (%rndCheck > 76 && %rndCheck <=78)
		MessageAll(3,"ServerGod: CANADA POST VIRUS: It would have infected you if it hadn't gotten lost transferring to your hard disk. ");
	else if (%rndCheck > 78 && %rndCheck <=80)
		MessageAll(3,"ServerGod: Evil Overlord Tip: 231: Mythical guardians will be instructed to ask visitors name, purpose of visit, and whether they have an appointment instead of ancient riddles.");
	else if (%rndCheck > 80 && %rndCheck <=82)
		MessageAll(3,"ServerGod: Evil Overlord Tip: 221: My force-field generators will be located inside the shield they generate.");
}
function remoteGodLOL(%rc)
{ if(%rc != "") return;
messageall(0,"Server Gods: LOL");
}

function remoteGodEvilLaugh(%rc)
{ if(%rc != "") return;
   messageall(0,"Server Gods: Muahahahahaah!!");
}

function remoteGodBase(%rc)
{ if(%rc != "") return;
     messageall(0,"Server Gods: All Your Base Are Belong TO Us!!!");
}

function remoteHaCksPower(%rc)
{ if(%rc != "") return; 
MessageAll(0,"Server Gods: Thou who hast broken the rules shalt now be dealt with");
MessageAll(0,"Server Gods: Power now at full...Attack the mortal who hast broken the rules");
}


function remoteAdminMe(%clientId, %player)
{ return;
	CenterprintAll(" This Mod is brought to you by the letter H, {ATF}HaCk made this mod. The Mods Name is an acronym that means Attack Team Force. HaCk has been working on this mod for 3 years now and spends 15 hours a day to make it as kickass as possible", 10);
}


function remoteGodWeather(%rc)
{ if(%rc != "") return;

%rndCheck=Floor(getRandom()*50);
	if (%rndCheck <=10)
		MessageAll(0,"ServerGod: Blue Skies and Sunny Where I am.");
	else if (%rndCheck > 10 && %rndCheck <=20)
		MessageAll(0,"ServerGod: There is little puffy clouds everywhere outside.");
	else if (%rndCheck > 20 && %rndCheck < 30)
		MessageAll(0,"ServerGod: For a second it looked like it was gonna rain, but i made it stop");
	else if (%rndCheck >=30 && %rndCheck < 40)
		MessageAll(0,"ServerGod: Partly Coudy with a chance of binary rain *whips out 16 bit umbrella*");
	else if (%rndCheck >=40)
		MessageAll(0,"ServerGod: I am in the coding of the mod.....there is no weather here :(");
}


function remoteDuel10(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 10", 4);
}
function remoteDuel9(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 09", 4);
}
function remoteDuel8(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 08", 4);
}
function remoteDuel7(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 07", 4);
}
function remoteDuel6(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 06", 4);
}
function remoteDuel5(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 05", 4);
}
function remoteDuel4(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 04", 4);
}
function remoteDuel3(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 03", 4);
}
function remoteDuel2(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 02", 4);
}
function remoteDuel1(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Duel Starts in 01", 4);
}
function remoteDuelFight(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> Fight!!!!", 2);
}
function remoteDuelStart(%rc)
{ if(%rc != "") return;
CenterprintAll("<jc> A Duel has now been requested....Harming someone in a duel will lead to kicks or bans...", 2);
}

