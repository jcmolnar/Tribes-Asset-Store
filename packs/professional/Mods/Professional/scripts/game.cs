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
$MaxTeamEnergy = 700000;

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
$ItemRespawnTime = 15;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 5000;

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
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 20;	  //Define Min Length from another turret
$TurretBoxMinWidth =  20;	  //Define Min Width from another turret
$TurretBoxMinHeight = 15;    //Define Min Height from another turret

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
$deathMsg[$EnergyDamageType, 0]      = "%1's turret takes away one of %2's nine lives.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by %1's turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of %1's turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of %1's turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";
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
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
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
$deathMsg[$MissileDamageType, 0]	 = "%2 takes a missile up the keister from %1.";
$deathMsg[$MissileDamageType, 1]	 = "%2 gets shot down by %1.";
$deathMsg[$MissileDamageType, 2]	 = "%2 gets real friendly with a rocket fired by %1.";
$deathMsg[$MissileDamageType, 3]	 = "%2 feels the burn of %1's warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
$deathMsg[$FighterGunDamageType, 0]	       = "%2 is shredded by %1.";
$deathMsg[$FighterGunDamageType, 1]	       = "%2 gets a taste of %1's piercing personality.";
$deathMsg[$FighterGunDamageType, 2]	       = "%1 mows %2 down like a weed.";
$deathMsg[$FighterGunDamageType, 3]	       = "%2 couldn't run from %1's rain of fire.";
$deathMsg[$KamikazeDamageType, 0]	="%2 didn't notice %1 was a bomb!";
$deathMsg[$KamikazeDamageType, 1]	="%1 died for his cause and %2 went along for the ride.";
$deathMsg[$KamikazeDamageType, 2]	="%1 defines \"Kamikaze\" for %2.";
$deathMsg[$KamikazeDamageType, 3]	="%1 shows %2 the way to Hades.";
$deathMsg[$ElectricDamageType, 0] = "%2 gets zapped by %1's ELF turret.";
$deathMsg[$ElectricDamageType, 1] = "%1's ELF turret gives %2 a nasty jolt.";
$deathMsg[$ElectricDamageType, 2] = "%2 gets a real shock from %1's ELF turret.";
$deathMsg[$ElectricDamageType, 3] = "%1's ELF turret short-circuits %2's systems.";
$deathMsg[$RocketDamageType, 0]	    = "%2 sucks down a rocket from %1's turret.";
$deathMsg[$RocketDamageType, 1]	    = "%2 gets trashed by %1's rocket turret.";
$deathMsg[$RocketDamageType, 2]	    = "%2 accepts a rocket from %1's turret.";
$deathMsg[$RocketDamageType, 3]	    = "%2 feels the sting of %1's rocket turret.";

$deathMsg[$MarlinDamageType, 0]	       = "%1 took %2 out with a well placed bullet to the head.";
$deathMsg[$MarlinDamageType, 1]	       = "%2 tries to find %1, but get's sniped instead, aww.";
$deathMsg[$MarlinDamageType, 2]	       = "%1 sings 'I can see for miles and miles... And I can peg %2 from that far too!'";
$deathMsg[$MarlinDamageType, 3]	       = "%1 says simply, better luck next time %2.";
$deathMsg[$ShotgunDamageType, 0]	       = "%1 says WHAT. %2 looked like %3 armor needed some vents.";
$deathMsg[$ShotgunDamageType, 1]	       = "R.I.P. Here lies %2. %1's Shotgun took 'Izzass' out.";
$deathMsg[$ShotgunDamageType, 2]	       = "%1 pulled out a deuce and capped %2 REAL good.";
$deathMsg[$ShotgunDamageType, 3]	       = "%1 pointed a Sawed-off at %2 while singing, 'Another one bites the dust.'";
$deathMsg[$PlasmaCannonDamageType, 0]	       = "%1 liberates a few electrons in %2's general direction.";
$deathMsg[$PlasmaCannonDamageType, 1]	       = "%2 came, and saw, but %1 did the ass-kicken.";
$deathMsg[$PlasmaCannonDamageType, 2]	       = "%1 says 'I love the smell of melted armor in the morning', thanks %2.";
$deathMsg[$PlasmaCannonDamageType, 3]	       = "%2 tests out %4 new plasma-proof armor. %1 says 'It's still got a few bugs.'";
$deathMsg[$FlameDamageType, 0]	       = "%1's turret crispifies %2.";
$deathMsg[$FlameDamageType, 1]	       = "%2 stopped, dropped and rolled, but %1's turret found it's mark anyway.";
$deathMsg[$FlameDamageType, 2]	       = "%2 proves spontaneous human combustion can happen...with a little help from %1.";
$deathMsg[$FlameDamageType, 3]	       = "%1 wonders what it feels like to be a McNugget.  Perhaps %2 knows.'";
$deathMsg[$CTurretDamageType, 0]	       = "A Chaingun turret hoses %2 down.";
$deathMsg[$CTurretDamageType, 1]	       = "%2's ears ring with the not so pleasant jingle of bullets caressing %4 armor.";
$deathMsg[$CTurretDamageType, 2]	       = "%2 must be pretty dense for getting killed by something that doesn't even move.";
$deathMsg[$CTurretDamageType, 3]	       = "%2 thought that Chaingun turret was just a pretty decoration.";
$deathMsg[$MeteorDamageType, 0]	       = "%2 has become one with the ground.";
$deathMsg[$MeteorDamageType, 1]	       = "%2 tries to run, but finds a meteor in %4 way.";
$deathMsg[$MeteorDamageType, 2]	       = "%2 thinks 'I didn't really like this armor anyway.'";
$deathMsg[$MeteorDamageType, 3]	       = "%2 screams 'The sky is falling, the sky is fa.....' and it did.";
$deathMsg[$SolarFlareDamageType, 0]	       = "%2 forgot to wear %4 sunblock.";
$deathMsg[$SolarFlareDamageType, 1]	       = "%2 stares at the bright light.";
$deathMsg[$SolarFlareDamageType, 2]	       = "%2 thinks 'Now I know why eveyone says not to look directly at the sun.'";
$deathMsg[$SolarFlareDamageType, 3]	       = "%2 falls asleep in the sun.";
$deathMsg[$RailDamageType, 0]	       = "%2 got the drilling of %4 lifetime.";
$deathMsg[$RailDamageType, 1]	       = "%2 was railed.";
$deathMsg[$RailDamageType, 2]	       = "%2 couldn't move fast enough to avoid that Rail Turret.";
$deathMsg[$RailDamageType, 3]	       = "Rail Turret 1, %2 0";
$deathMsg[$LightningDamageType, 0]	       = "Just call %2 sparky.";
$deathMsg[$LightningDamageType, 1]	       = "%2 was struck down dead.";
$deathMsg[$LightningDamageType, 2]	       = "%2 didn't survive the lightning.";
$deathMsg[$LightningDamageType, 3]	       = "%2 picked the wrong tree to hide under.";



// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = RepairKit;
$spawnBuyList[2] = Disclauncher;
$spawnBuyList[3] = Chaingun;
$spawnBuyList[4] = "";
$spawnBuyList[5] = "";

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
   $Halfway=0;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	
   
   
   //Randomevent stuff
   //$RandomEvents="True";
   //$RandomEventTime=30;
   if ($RandomEvents=="True")
   {
       	echo("Initializing random events every ", $RandomEventTime, " seconds.");
       	schedule("RandomEvent();", $RandomEventTime);
   }
   
   
   
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
      		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
   	}
	if(%spawnMarker) 
	{   
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

		$TeleSpot[Client::getTeam(%clientId)] = %spawnPos;

		if(!String::ICompare(Client::getGender(%clientId), "Male")) %armor = "larmor";
	   	else %armor = "lfemale";
	   	if (%respawn && $Match == "True") 
	   	{
	   		//if ($Suicided[%clientId] == 1) schedule ("Client::sendMessage(" @ %clientId @ ",0,\"Suicide Penalty has expired\");",$SuicideSpawnPenaltyTime);
		}
		else $PenaltyTime[%clientId] = getSimTime() - 1;
		$Suicided[%clientId] = 0;
		if (getSimTime() > $PenaltyTime[%clientId])
		{
	   		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   		$TeleUsed[%pl] = false;
	   		if(%pl != -1)
	   		{
	      			GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      			Client::setOwnedObject(%clientId, %pl);
	      			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      	
	      			if($matchStarted) Client::setControlObject(%clientId, %pl);
	      			else
	      			{
	        	 		%clientId.observerMode = "pregame";
	        	 		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	        	 		Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      			}
	   		}
      	   		return true;
      	   	}
      	   	else
      	   	{
      	   		Client::sendMessage(%clientId,0,"Sorry Suicide Penalty has not yet expired");
      			return false;
      	   	}
	}
	else 
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      		return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{	if(%clientId.custom){
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
   	if($Server::TourneyMode) GameBase::setTeam(%clientId, -1);
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
      		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) ) Game::assignClientTeam(%clientId);
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
         		if($Server::TeamDamageScale) %td = "ENABLED";
         		else %td = "DISABLED";
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
      			%name = Client::getName(%clientId);
      			if ($match != "True")
      			{
      				Client::buildMenu(%clientId, "Pick a team:", "usecustom");
      				Client::addMenuItem(%clientId, "0Use Personal Skin", 0);
      				Client::addMenuItem(%clientId, "1Use Team Default", 1);
      				Client::addMenuItem(%clientId, "2Become Observer",2);
      				bottomprint(%clientId, $motd @ "\n\n<f1><jc>Welcome " @ %name @ ", This server is running Professional Mod v1.5\nFor more info visit http://www.primenet.com/~desrtfox", 0);
      				//topprint(%clientId, $motd, 0);
      				%clientId.justConnected = "";
      			}
      			else if($LockedServer == "True")
      			{
      				echo(" Number of Players: " @ $Players::Allowed);
      				%FoundPlayer = 0;
      				//%max = $Players::Allowed;
      				for(%i = 0; %i < $Players::Allowed; %i++)
      				{
      					//echo(" Playername: " @ $Players::Player[%i]);
      					//echo(" Playerteam: " @ $Players::Team[%i]);
      					if(%name == $Players::Player[%i])
      					{
      						%StartTeam = $Players::Team[%i];
      						%FoundPlayer =  1;
      						echo(" Playername: " @ $Players::Player[%i]);
      						echo(" Playerteam: " @ $Players::Team[%i]);
      					}
      				}
      				if (!%FoundPlayer) Net::kick(%clientId, "You do not have permission to play on this server.");
      				//echo("Found Player and Spawning");
      				GameBase::setTeam(%clientId, %StartTeam);
      				Game::playerSpawn(%clientId, false);
      				if (GameBase::getTeam(%clientId) != -1) 
      				{
      					bottomprint(%clientId, $motd @ "\n\n<f1><jc>Welcome to the match contender " @ %name, 10);
      					//Client::SendMessage(%clientId,0, "~wrumble.wav");
      					//Client::SendMessage(%clientId,0, "~wfight.wav");
      					Client::SendMessage(%clientId,0, "~wflagcapture.wav");
      				}
      				else 
      				{
      					%clientId.custom = False;
					%cl = -2;
					%admin = "";
					%team = -2;
					Observer::setTargetClient(%clientId, %cl);
					//bottomprint(%clientId, "<f1><jc>Professional Mod v1.5", 0);
   					processMenuPickTeam(%clientId, %cl, %admin);
      					bottomprint(%clientId, $motd @ "\n\n<f1><jc>Welcome " @ %name @ ", Please enjoy today's sporting event", 10);
      				}
      				%clientId.justConnected = "";
      			}
      			else 
      			{
      				Game::playerSpawn(%clientId, false);
      				bottomprint(%clientId, $motd @ "\n\n<f1><jc>Welcome " @ %name @ ", This server is running Professional Mod v1.5\nFor more info visit http://www.primenet.com/~desrtfox", 5);
      			}
      		}
      		else if(%clientId.observerMode == "justJoined")
      		{
        	 	centerprint(%clientId, "");
        	 	%clientId.observerMode = "";
        	 	Game::playerSpawn(%clientId, false);
      		}
      		else Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
	$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuuseCustom(%clientId, %skin)
{
   if(%skin == 0)
   {
      if ($match != "True") %clientId.custom = True;
      else %clientId.custom = False;
   }
   if(%skin == 1)
   {
    %clientId.custom = False;
   }
   if(%skin == 2)
   {
   	%clientId.custom = False;
   	%cl = -2;
   	%admin = "";
   	%team = -2;
   	Observer::setTargetClient(%clientId, %cl);
   	bottomprint(%clientId, "<f1><jc>Professional Mod v1.5", 0);
   	processMenuPickTeam(%clientId, %cl, %admin);
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
      %replay=false;
      Server::nextMission(%replay);
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
	if ($ServerCheats) 
	{
		checkMax(Player::getClient(%player),%armorType);
	   	Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) 
	{
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
   	$Suicided[%playerId] = 0;
   	%this=%playerId;
   	%player = Client::getOwnedObject(%playerId);
   	%killer = Client::getOwnedObject(%killerId);
   	$cloaked[%player] = 0;
   	Cloaker(%player);
   	$Enhanced[%playerId]=0;
   	%team = GameBase::getTeam(%this);
   	for (%i = 1; %i < $ShieldGen+1; %i++)
   	{
   		%object = $ShieldGenObject[%i];
   		%matrix = %this @ %object;
   		$oldShieldGen[%matrix] = 0;
   		//echo("$oldshieldgen[" @ %matrix @ "] = 0");
   	}
   	//%pos = Gamebase::GetPosition(%playerId);
	//%offset = "0 0 500";
   	//%pos = vector::add(%pos,%offset);
   	//if ($match == "True") GameBase::setPosition(%playerId, %pos);
   	//if ($match == "True") GameBase::setPosition(%player, %pos);
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
   	if(!%killerId || %damageType == $DebrisDamageType)
   	{
      		if (%damageType == $MeteorDamageType || %damagetype == $LightningDamageType  || %damageType == $DebrisDamageType)
      		{
      			%blank ="Nobody";
      			%killergender = "its";
      			//echo("Death by Meteors");
      			%obitMsg = sprintf($deathMsg[%damageType, %ridx], %blank,%victimName, %killerGender, %playerGender);
      			messageAll(0, %obitMsg, $DeathMessageMask);
      		}
      		else messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      		%playerId.scoreDeaths++;
  	}
   	else if(%killerId == %playerId)
   	{
		if (%damagetype != $KamikazeDamageType)
		{
			$PenaltyTime[%playerId] = getSimTime() + $SuicideSpawnPenaltyTime;
			$Suicided[%playerId] = 1;
			if ($match == "True") schedule ("Client::sendMessage(" @ %clientId @ ",0,\"Suicide Penalty has expired\");",$SuicideSpawnPenaltyTime);
   			if ($match == "True") bottomprint(%playerId, "<jc>Suicide Penalty of " @ $SuicideSpawnPenaltyTime @ " seconds initiated.", $SuicideSpawnPenaltyTime);
      		}
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
			if(!$aiTrue[%playerId])
			{
				if(%damageType != $CTurretDamageType && %damageType != $RailDamageType)
				{
					if(%damageType != $MineDamageType) 
	         			messageAll(0, strcat(Client::getName(%killerId), 
   	         			" mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
					else 
	         			messageAll(0, strcat(Client::getName(%killerId), 
   	         			" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
         				%playerId.score--;
         				CheckTeamKiller(%killerId,%playerId,%damagetype);
         			}
         			else messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
         			%killerId.scoreDeaths++;
         			Game::refreshClientScore(%killerId);
         		}
      		}
      		else
      		{
	 	%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	 	%victimName, %killerGender, %playerGender);
         	messageAll(0, %obitMsg, $DeathMessageMask);
         	if($aiTrue[%playerId] || $aiTrue[%killerId])
         	{
         	}
         	else
         	{
         		%killerId.scoreKills++;
         		%playerId.scoreDeaths++;  // test play mode
         		%killerId.score++;
         		%killerTeam = GameBase::getTeam(%killerId);
         		if ($match == "True")
         		{
         			$teamScore[%killerTeam] += $KillValue;
         			for(%i = 0; %i < getNumTeams() ; %i++)
	 			{
	 				%teamname = getTeamName(%i);
	 				%score = $teamScore[%i];
	 				if ($teamScore[%i] > %leaderscore) 
	 				{
	 					%leader = %i;
	 					%leaderscore = $teamScore[%i];
	 				}
	 			}
	 			if (%leader != $LeadTeam) Announcescores();
	 		}
         		Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
         	}
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


$modmgtModName = "SHAntiTK";
$modmgtModVers = "1.30";



if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 600;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 3;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;

function CheckTeamKiller(%killerId,%playerId,%damagetype)
{
    if(%damagetype != $MineDamageType && %damagetype != $MortarDamageType)
    {
	%ppos = %playerid.TKDeathPos;
        for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
        {
		if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
		{
			if(%cl != %playerId && %cl != %killerId)
			{
	      	      %pppos = GameBase::getPosition(%cl);

      	      	%dist = Vector::getDistance(%ppos,%pppos);
	
      	      	echo(CLient::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId));
				echo(%dist @ " " @ $SHAntiTeamKillProximity);

		            if(%dist < $SHAntiTeamKillProximity)
      		      {
            		    echo("Another player was close, kill is ok");
		                return;
      		      }
			}
		}
        }
	
        messageAll(0, "***" @ Client::getName(%killerId) @ " TeamKilled***");
        if(%killerid.TKCount == "")
        {
                %killerid.TKCount = 1;
        }
        else
        {
            %killerid.TKCount = %killerid.TKCount + 1;
            if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
            {
                    %ip = Client::getTransportAddress(%killerId);
//                    BanList::add(%ip, $SHAntiTeamKillBanTime);
                    %killer = Client::getOwnedObject(%killerId);
                    messageAll(0, Client::getName(%killerId) @ " was kickbanned for teamkilling");
                    Net::kick(%killerId,"You have been kickbanned for team killing, i hope you enjoyed it.");
            }
            else
            if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
            {
                Client::sendMessage(%killerId, 1, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kickbanned.");
            }
        }
    }
}


function RandomEvent()
{	
	//%totalweight = 0;
	//if ($Meteor=="True") %totalweight = $MeteorWeight;
	//if ($Lightning=="True") %totalweight = %totalweight + $LightningWeight;
	//if ($SolarFlare=="True") %totalweight = %totalweight + $SolarFlareWeight;
	//%lightweight = %totalweight - $SolarFlareWeight;
	%totalweight = $MeteorWeight + $LightningWeight + $SolarFlareWeight;
	%lightweight = $MeteorWeight + $LightningWeight;
	%rnd = floor(getRandom() * %totalweight);
	if (%rnd <= $MeteorWeight)
	{
		if ($Meteor=="True")
		{
			if (Client::getFirst() > 0) Meteor();
			//echo("Meteors");
			if ($RandomTimeVariance ==0) %variance = 0; 
			else %variance = (getRandom() * $RandomTimeVariance)-$RandomTimeVariance/2;
			%time = $RandomEventTime+($RandomEventTime * %variance) + $MeteorDuration;
			echo ("Meteors " @ %variance @ " " @ %time);
			schedule("RandomEvent();", %time);
		}
		else schedule("RandomEvent();", 0.2);
	}
	else if (%rnd <= %lightweight)
	{
		if ($Lightning=="True")
		{
			if (Client::getFirst() > 0) Lightning();
			echo("Lightning");
			if ($RandomTimeVariance ==0) %variance = 0; 
			else %variance = (getRandom() * $RandomTimeVariance)-$RandomTimeVariance/2;
			%time = $RandomEventTime+($RandomEventTime * %variance) + $LightningDuration;
			schedule("RandomEvent();", %time);
		}
		else schedule("RandomEvent();", 0.2);
	}
	else if (%rnd <= (%totalweight + 1))
	{
		if ($SolarFlare=="True")
		{
			if (Client::getFirst() > 0) SolarFlare();
			echo("SolarFlare");
			if ($RandomTimeVariance ==0) %variance = 0; 
			else %variance = (getRandom() * $RandomTimeVariance)-$RandomTimeVariance/2;
			%time = $RandomEventTime+($RandomEventTime * %variance) + $SolarFlareDuration;
			schedule("RandomEvent();", %time);
		}
		else schedule("RandomEvent();", 0.2);
	
	}
}

function Meteor()
{
	%coordinate = waypointtoWorld("1024 512");
	%sunspot = vector::add(%coordinate,"0 0 300");
	echo("sunspot: " @ %sunspot);
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,%sunspot);
	GameBase::setTeam(%camera,-1);
	addToSet("MissionCleanup", %camera);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		client::sendMessage(%clientId,2,"Orbital debris entering atmosphere over your sector.");
		Client::sendMessage(%clientId,0,"~wC_BuySell.wav");
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",0.5);
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",1.0);
	}
	%coordinate = waypointtoWorld("1024 0");
	%coordinate2 = waypointtoWorld("0 0");
	%coordinate=getword(%coordinate,0);
	%coordinate2=getword(%coordinate2,0);
	%density = %coordinate - %coordinate2;
	%density=%density/850;
	%density=pow(%density,2)-1;
	for(%i = 0; %i < 180; %i= %i++)
	{
		%time = %i * $MeteorDuration/180;
		%number=$sin[%i];
		%number=floor(%number*$MeteorDensity+(%density*$MeteorAreaVariance))+1;
		%test = schedule("MeteorStrike(" @ %number @ " ," @ %camera @ ");", %time);
	}
	schedule ("DeleteObject(" @ %camera @ ");",$MeteorDuration+1);
}

function MeteorStrike(%number,%camera)
{
	for(%it = 0; %it < %number; %it++)
	{
		%clientId = Client::getFirst();
		%x = floor(getRandom() * 1024);
		%y = floor(getRandom() * 1024);
		%loc = %x @ " " @ %y;
		%loc = WaypointToWorld(%loc);
		%player = Client::getOwnedObject(%clientId);
		%player = "2048";
		%vel = "0 0 0";
		%vertical = "0 0 200";
		%loc = vector::add(%loc,%vertical);
		%trans = "1.000000 0.000000 0.000000 0.000000 0.000345 -0.999999 0.000000 0.999999 0.000345";
		//%trans = "0.707 0 0.707 0 1 0 -0.707 0 0.707";
		%trans = %trans @ " " @ %loc;
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("Meteor",%trans,%camera,%vel);
	}
}

function Lightning()
{
	%coordinate = waypointtoWorld("0 0");
	%sunspot = vector::add(%coordinate,"0 0 300");
	echo("sunspot: " @ %sunspot);
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,%sunspot);
	GameBase::setTeam(%camera,-1);
	addToSet("MissionCleanup", %camera);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		client::sendMessage(%clientId,2,"Electrical storm approaching sector.");
		Client::sendMessage(%clientId,0,"~wC_BuySell.wav");
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",0.5);
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",1.0);
	}
	%coordinate = waypointtoWorld("1024 0");
	%coordinate2 = waypointtoWorld("0 0");
	%coordinate=getword(%coordinate,0);
	%coordinate2=getword(%coordinate2,0);
	%density = %coordinate - %coordinate2;
	%density=%density/850;
	%density=pow(%density,2)-1;
	for(%i = 0; %i < 180; %i= %i++)
	{
		%time = %i * $LightningDuration/180;
		%number=$sin[%i];
		%number=floor(%number*$LightningDensity+(%density*$LightingAreaVariance))+1;
		%test = schedule("LightningStrike(" @ %number @ " ," @ %camera @ ");", %time);
	}
	schedule ("DeleteObject(" @ %camera @ ");",$LightningDuration+1);
}

function LightningStrike(%number,%camera)
{
	for(%it = 0; %it < %number; %it++)
	{
		%clientId = Client::getFirst();
		%x = floor(getRandom() * 1024);
		%y = floor(getRandom() * 1024);
		%loc = %x @ " " @ %y;
		%loc = WaypointToWorld(%loc);
		%player = Client::getOwnedObject(%clientId);
		%player = "2048";
		%vel = "0 0 0";
		%vertical = "0 0 200";
		%loc = vector::add(%loc,%vertical);
		%trans = "1.000000 0.000000 0.000000 0.000000 0.000345 -0.999999 0.000000 0.999999 0.000345";
		//%trans = "0.707 0 0.707 0 1 0 -0.707 0 0.707";
		%trans = %trans @ " " @ %loc;
		//%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("LightningBlast",%trans,%camera,"0 0 -900");
		Projectile::spawnProjectile("LightningBlast2",%trans,%camera,"0 0 -900");
		Projectile::spawnProjectile("LightningBeam",%trans,%camera,%vel);
	}
}

function SolarFlare()
{
	%coordinate = waypointtoWorld("1024 512");
	echo("coordinate: " @ %coordinate);
	%sunspot = vector::add(%coordinate,"0 0 300");
	echo("sunspot: " @ %sunspot);
	%camera = newObject("Camera","Turret",cameraturret,true);
	addToSet("MissionCleanup", %camera);
	//%damagetype = 1;
	//%damageradius = 3000;
	//%damagevalue = 1.0;
	//%force = 0.0;
	GameBase::setPosition(%camera,%sunspot);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		client::sendMessage(%clientId,2,"Solar radiation burst detected.");
		Client::sendMessage(%clientId,0,"~wC_BuySell.wav");
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",0.5);
		schedule ("Client::sendMessage(" @ %clientId @ ",0,\"~wC_BuySell.wav\");",1.0);
	}
	for(%i = 0; %i < 60; %i= %i++)
	{
		%time = %i * $SolarFlareDuration/60;
		%test = schedule("SolarFlareBurst(" @ %camera @ ");", %time);
	}
	schedule ("DeleteObject(" @ %camera @ ");",$SolarFlareDuration+1);
}

function SolarFlareBurst(%obj)
{
	%pos = GameBase::getPosition(%obj);
	GameBase::ApplyRadiusDamage(26,%pos,3000,0.00201,0.001,%obj);
}