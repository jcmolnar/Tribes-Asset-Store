exec("comchat.cs");
//exec("ChivalryPrefs.cs");
//exec("ServerPlayerList.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$LastType = 0;

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
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 15;	  //Define Min Length from another turret
$TurretBoxMinWidth =  15;	  //Define Min Width from another turret
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
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
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
$deathMsg[$MortarDamageType, 0]      = "%1 blows %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that artillery from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 makes a crater out of %2.";
$deathMsg[$MortarDamageType, 3]      = "%1 makes %2 go 'Poof!'.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1's electric personality.";
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
$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%2 becomes a statistic.";
$deathMsg[$MineDamageType, 1]	       = "%2 stepped on a toe-popper.";
$deathMsg[$MineDamageType, 2]	       = "%2 no longer needs to worry about buying shoes.";
$deathMsg[$MineDamageType, 3]	       = "%2 had better find a good prosthetic.";
$deathMsg[$ReincarnateDamageType, 0]	= "%2 is reincarnated.";
$deathMsg[$ReincarnateDamageType, 1]	= "%1 sends %2 to see a higher power.";
$deathMsg[$ReincarnateDamageType, 2]	= "%1 shows %2 the light at the end of the tunnel.";
$deathMsg[$ReincarnateDamageType, 3]	= "%2 has been sent to the netherworld.";
$deathMsg[$FingerDamageType, 0]		= "%2 felt the Fingers of Death.";
$deathMsg[$FingerDamageType, 1]		= "%1 gave %2 a tastes of his magic.";
$deathMsg[$FingerDamageType, 2]		= "%2 felt the tickle of %1's touch of death.";
$deathMsg[$FingerDamageType, 3]		= "%1 gave %2 a hair-raising experience.";
$deathMsg[$PredatorDamageType, 0]	= "%1 made %2's day with his Predator.";
$deathMsg[$PredatorDamageType, 1]	= "%1 = Predator <-> %2 = Prey.";
$deathMsg[$PredatorDamageType, 2]	= "%1 asks %2, 'Hey, is this loaded?'";
$deathMsg[$PredatorDamageType, 3]	= "%1 gives %2 an acute case of lead poisioning.";
$deathMsg[$ShredderDamageType, 0]	= "%1 shreds %2.";
$deathMsg[$ShredderDamageType, 1]	= "%1 turns %2 into so much confetti.";
$deathMsg[$ShredderDamageType, 2]	= "%2 is mowed down.";
$deathMsg[$ShredderDamageType, 3]	= "%1 cuts %2 down to size.";
$deathMsg[$StubberDamageType, 0]	= "%1 says,'Dance, %2, Dance!'";
$deathMsg[$StubberDamageType, 1]	= "%2 stubbs %4 toe.";
$deathMsg[$StubberDamageType, 2]	= "%2 gets waxed by %1's Stubber.";
$deathMsg[$StubberDamageType, 3]	= "%2 learns never to walk into supression fire.";
$deathMsg[$LaserTDamageType, 0]		= "%1 is vivisected.";
$deathMsg[$LaserTDamageType, 1]		= "%1 gets a burning sensation in a strange place.";
$deathMsg[$LaserTDamageType, 2]		= "%1 learns that lasers aren't just for surgery anymore.";
$deathMsg[$LaserTDamageType, 3]		= "%1 says,'What was...*erk!*'";
$deathMsg[$VulcanDamageType, 0]		= "%2 is vulcanized.";
$deathMsg[$VulcanDamageType, 1]		= "%2 is cut off at the knees.";
$deathMsg[$VulcanDamageType, 2]		= "%2 is chewed up and spat out by a Vulcan turret.";
$deathMsg[$VulcanDamageType, 3]		= "%2 gets perforated by a Vulcan turret.";
$deathMsg[$GunshipDamageType, 0]	= "%2 becomes a red mist and a memory.";
$deathMsg[$GunshipDamageType, 1]	= "%2 is straffed by %1.";
$deathMsg[$GunshipDamageType, 2]	= "%1 rains death upon %2.";
$deathMsg[$GunshipDamageType, 3]	= "%2 realizes that wasn't a big bird.";
$deathMsg[$AnnDamageType, 0]	= "%2 is Annihilated.";
$deathMsg[$AnnDamageType, 1]	= "%2 evaporates from an Annihilator Turret.";
$deathMsg[$AnnDamageType, 2]	= "%2 is blasted into debris.";
$deathMsg[$AnnDamageType, 3]	= "%2's mind is blown.";
$deathMsg[$OutBoundsDamageType, 0] = "%1 is slain for fleeing the battlefield.";
$deathMsg[$OutBoundsDamageType, 1] = "%1 dies Out Of Bounds.";
$deathMsg[$OutBoundsDamageType, 2] = "%1 died running away from the fight.";
$deathMsg[$OutBoundsDamageType, 3] = "%1 tried to run and died tired.";
$deathMsg[$StormDamageType, 0] = "%2 succumbs to the Storm.";
$deathMsg[$StormDamageType, 1] = "%2 lost count of the flying Rockets.";
$deathMsg[$StormDamageType, 2] = "%1 unleashes the Storm upon %2.";
$deathMsg[$StormDamageType, 3] = "%1's Storm Launcher makes a big mess out of %2.";
$deathMsg[$PhoenixDamageType, 0] = "%2 is seared by %1's Phoenix.";
$deathMsg[$PhoenixDamageType, 1] = "%1 subjects %2 to the Phoenixs' Flame.";
$deathMsg[$PhoenixDamageType, 2] = "%2 succumbs to the Phoenixs' rain of fire.";
$deathMsg[$PhoenixDamageType, 3] = "%1's Phoenix reduces %2 to ashes.";
$deathMsg[$InfernoDamageType, 0] = "%1 unleashes an Inferno upon %2.";
$deathMsg[$InfernoDamageType, 1] = "%2 melts from %1's magical fire.";
$deathMsg[$InfernoDamageType, 2] = "%1 uses %3 arcane fire to singe %2.";
$deathMsg[$InfernoDamageType, 3] = "%2 screams, 'I'm melting! ...melting...'";
$deathMsg[$ViperDamageType, 0] = "%2 is bitten by %1's Viper.";
$deathMsg[$ViperDamageType, 1] = "%2 learns never to play with snakes.";
$deathMsg[$ViperDamageType, 2] = "%2 gets a Viper bite in %4 keester.";
$deathMsg[$ViperDamageType, 3] = "%2 feels the poison of %1's Viper.";
$deathMsg[$ScatterDamageType, 0] = "%2 gets a face full of Scattergun from %1.";
$deathMsg[$ScatterDamageType, 1] = "%2 gets swatted by %1's Scattergun.";
$deathMsg[$ScatterDamageType, 2] = "%1 gives %2 a bad case of ringing ears.";
$deathMsg[$ScatterDamageType, 3] = "%2 is peppered by %1.";
$deathMsg[$TurnDamageType, 0] = "%2's soul is released by %1.";
$deathMsg[$TurnDamageType, 1] = "%2 was Turned by %1.";
$deathMsg[$TurnDamageType, 2] = "%2 has rejoined the land of the Living.";
$deathMsg[$TurnDamageType, 3] = "%1 has freed %2 from %4 evil toil.";
$deathMsg[$HealDamageType, 0] = "%1 has slain %2 with the powers of Life.";
$deathMsg[$HealDamageType, 1] = "%2 feels the love from %1.";
$deathMsg[$HealDamageType, 2] = "%2 realizes that sometimes love hurts.";
$deathMsg[$HealDamageType, 3] = "%1 shows off %3 First Aid skills to %2.";
$deathMsg[$StutterDamageType, 0] = "%2 is stitched by a Stutter Turret.";
$deathMsg[$StutterDamageType, 1] = "%2 learns how painful a Stutter can be.";
$deathMsg[$StutterDamageType, 2] = "A Stutter Turret makes %2 look like a Van Gogh.";
$deathMsg[$StutterDamageType, 3] = "%2 gets an unhealthy dose of lead.";
$deathMsg[$SuicideDamageType, 0] = "%1 takes the cowards way out.";
$deathMsg[$SuicideDamageType, 1] = "%1 shows his true color - Yellow.";
$deathMsg[$SuicideDamageType, 2] = "%1 commits Seppuku.";
$deathMsg[$SuicideDamageType, 3] = "%1 decides to dishonorably commit suicide.";
$deathMsg[$HolyDamageType, 0] = "%2 is struck by Lightning.";
$deathMsg[$HolyDamageType, 1] = "%2 is on his way to see the Pearly Gates.";
$deathMsg[$HolyDamageType, 2] = "%2 is Blessed to death.";
$deathMsg[$HolyDamageType, 3] = "%2 has been sent to the Hereafter.";
$deathMsg[$TridentDamageType, 0] = "%1 impales %2 with his Trident.";
$deathMsg[$TridentDamageType, 1] = "%2 learns that bad things also come in threes.";
$deathMsg[$TridentDamageType, 2] = "%2 has a threesome with %1's Trident.";
$deathMsg[$TridentDamageType, 3] = "%1 pitchforks %2 with %3 Trident.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------
if($Chivalry::Ceremony)
{
	$spawnBuyList[0] = WarriorArmor;
	$spawnBuyList[1] = "";
}
else
{
$spawnBuyList[0] = WarriorArmor;
$spawnBuyList[1] = Predator;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = RepairPack;
$spawnBuyList[6] = "";
}

$undeadBuyList[0] = Predator;  //<--Spawn Equipment for Undead Players
$undeadBuyList[1] = Chaingun;
$undeadBuyList[2] = Disclauncher;
$undeadBuyList[3] = RepairKit;
$undeadBuyList[4] = "";

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
	if(%clientId.Undead)
	{
	%max = getNumTeams();
	%rndtm = floor(getRandom() * (%max - 0.01));
	   return Game::pickTeamSpawn(%rndtm, %respawn);
	}
else
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(%clientId.isGhost || %clientId.scoreCtrlK > 5)
	%clientId.isGhost = true;
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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
	      %armor = "worarmor";
	   else
	      %armor = "worfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ Client::getName(%clientId) @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
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
	if(%clientId.Undead)
	{
		%skin = $Chivalry::UndeadSkin;
		%pl = Client::getOwnedObject(%clientId);
		GameBase::setTeam(%clientId,-1);
		GameBase::setAutoRepairRate(%pl,0.015);
		Client::setSkin(%clientId, %skin);
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
		Player::setArmor(%clientId,marmor);
		else
		Player::setArmor(%clientId,mfemale);
		for(%i = 0; (%item = $undeadBuyList[%i]) != ""; %i++)
   		{
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
		}
	}	
	else
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	if(%clientId.isTk || %clientId.totTk >= $Chivalry::MaxTk && !%clientId.Undead)
	{
	%skin = $Chivalry::TkSkin;
	Client::setSkin(%clientId, %skin);
	%clientId.isTk = true;
	}
	%clientId.spawn= "";
	DonCrown(%clientId, %pl);
		if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}
	if($Chivalry::Grace)
	GiveGrace(%clientId);
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
	if(%clientId.isGhost || %clientId.scoreCtrlK > 5)
	%clientId.isGhost = true;
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
         centerprint(%clientId, $Server::JoinMOTD, 5);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
	schedule("GetStats("@ %clientId @");",5);
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
	if(%curTimeLeft <= 60 && $matchStarted )
	{
	//messageall(0,"One minute remains");
	StatsMessage();
	}
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
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {			%cl.ratio = 0;
      	%cl.score = 0;
	%cl.scoreFlags = 0;
	//%cl.scoreTk = 0;
	%cl.hasFlag = false;
				}
	}
	else {
	%client.ratio = 0;
     	%client.score = 0;
	//%client.scoreTk = 0;
	%client.hasFlag = false;
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
   	%playerId.score = 0;
	%playerId.hasFlag = false;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	if($Chivalry::Ceremony)
	{
		GameBase::setTeam(%playerId,0);
		return;
	}

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
   echo("GAME: kill " @ Client::getName(%killerId) @ " kills " @ Client::getName(%playerId) @ " " @ %damageType);
   %playerId.guiLock = true;
	if(%playerId.charged)
	{
	%playerId.charged = false;
	//messageall(0,"Client Charge reset");
	}
		if(%playerId.isGhost || %playerId.scoreCtrlK > 5)
		{
		%playerId.isGhost = true;
		}
	if(!%killerId)
		%playerId.hasFlag = false;
	else if(%killerId == %playerId)
		%playerId.hasFlag = false;

	else if(%playerId.hasFlag && Client::getTeam(%playerId) != Client::getTeam(%killerId))
		{
		%playername = Client::getName(%killerId);
		%teamname = Client::getTeam(%playerId);
		messageallexcept(%killerId,0, %playername@" has slain the "@ getTeamName(%teamname) @ " Flag Carrier!");
		Client::sendMessage(%killerId,0,"You receive a bonus for slaying the "@ getTeamName(%teamname) @ " Flag Carrier!");
		%playerId.hasFlag = false;
		%killerId.score++;
		}
	else if(%playerId.hasFlag && Client::getTeam(%playerId) == Client::getTeam(%killerId))
		{
		%playername = Client::getName(%killerId);
		messageallexcept(%killerId,0,%playername @ " has dishonorably slain his own Flag Carrier!");
		Client::sendMessage(%killerId,1,"You have shamed yourself by slaying your own Flag Carrier!");
		%killerId.score--;
		%playerId.scoreDeaths--;
		//%playerId.score++;
		}		
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
		if(%damageType == $EnergyDamageType || %damageType == $MissileDamageType || %damageType == $VulcanDamageType || %damageType == $AnnDamageType || %damageType == $StutterDamageType || %damageType == $HolyDamageType || %damagetype == $MineDamageType)
		{
		%msg = sprintf($deathMsg[%damageType, %ridx], %playerGender, %victimName);
      messageAll(0, %msg, $DeathMessageMask);
		}
		else if(%damageType == $LaserDamageType)
		{
		%msg = sprintf($deathMsg[$LaserTDamageType, %ridx], %victimName);
      messageAll(0, %msg, $DeathMessageMask);
		}
		if(!%playerId.Undead)
		{
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
		}
  }
   else if(%killerId == %playerId)
   {
		if(%damageType == $OutBoundsDamageType || %damageType == $SuicideDamageType)
		{
		$LastType = %damageType;
		%oobMsg = sprintf($deathMsg[%damageType, %ridx], %victimName, %playerGender);
	 messageAll(0, %oobMsg, $DeathMessageMask);
		schedule("$LastType = 0;",0.5);
		}
		else if($LastType != $OutBoundsDamageType)
		{
		  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
		}

	if(!%playerId.Undead)
		{
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
		}
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
		if(%playerId.isTk || %playerId.Litch)
		{
			if(%playerId.isTk)
			{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       	%victimName, %killerGender, %playerGender);
         		messageAll(0, %obitMsg, $DeathMessageMask);
			%killerId.score += 3;
			%killerId.scoreKills++;
			%playerId.scoreDeaths++;
			%playerId.score--;
			Game::refreshClientScore(%killerId);
			}
			else if(%playerId.Litch)
			{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       	%victimName, %killerGender, %playerGender);
         		messageAll(0, %obitMsg, $DeathMessageMask);
			%killerId.score += 2;
			%killerId.scoreKills++;
			%playerId.score--;
			%playerId.scoreDeaths++;
			Game::refreshClientScore(%playerId);
			Game::refreshClientScore(%killerId);
			}
		}
		else if(%damageType != $MineDamageType && %damageType != $ReincarnateDamageType && %damageType != $EvilDamageType && !%playerId.Undead && !%killerId.Undead) {
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		%killerId.scoreTk++;
		%killerId.totTk++;
		echo("PLAYER:  "@Client::getName(%killerId)@" Team Killed "@Client::getName(%playerId));
		logClientTk(%killerId);	
			if(%killerId.totTk >= $Chivalry::MaxTk && !%killerId.isTk && !%killerId.Undead && $Chivalry::Logging)
			{
			%skin = $Chivalry::TkSkin;
			Client::setSkin(%killerId, %skin);
			%killerId.isTk = true;
			if(%killerId)
			messageallexcept(%killerId,1, Client::getName(%killerId)@" has become a Team Killer!");
			}
	
		}
		else if(%damageType == $ReincarnateDamageType && !%playerId.Undead) 
		{
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " respawns ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		Game::assignClientTeam(%playerId);
		%playerId.score--;
		%killerId.scoreTk++;
		%killerId.totTk++;
		echo("PLAYER:  "@Client::getName(%killerId)@" Team Killed "@Client::getName(%playerId));
		logClientTk(%killerId);
			if(%killerId.totTk >= $Chivalry::MaxTk && !%killerId.isTk && !%killerId.Undead && $Chivalry::Logging)
			{
			%skin = $Chivalry::TkSkin;
			Client::setSkin(%killerId, %skin);
			%killerId.isTk = true;
			messageallexcept(%killerId,1, Client::getName(%killerId) @ " has become a Team Killer!");
			}
		Game::refreshClientScore(%playerId);
		}
		else if(%damageType == $EvilDamageType && !%killerId.Undead && %playerId.Undead)
		{
		%name = Client::getName(%playerId);
		messageallexcept(%playerId,0,%name@" has been slain and turned Undead!");
		%killerId.score += 5;
		Game::refreshClientScore(%killerId);
		}
		else
	         messageAll(0, strcat( %victimName ," dies."), $DeathMessageMask);
		if(!%killerId.Undead)
		{
		 %killerId.scoreDeaths++;
       %killerId.score--;
       Game::refreshClientScore(%killerId);
		}
	
      }
      else
      {
		if(%damageType == $ReincarnateDamageType && !%playerId.Undead)
		Game::assignClientTeam(%playerId);
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
		if(%damageType == $EvilDamageType && !%killerId.Undead && %playerId.Undead)
		{
		//%name = Client::getName(%playerId);		// <--This way no one will know the Litch King is present.
		//messageallexcept(%playerId,0,%name@" has been slain and turned Undead!"); // <--Until Undead start appearing everywhere!
		%killerId.score += 4;
		Game::refreshClientScore(%killerId); // PORT: was Client::refreshClientScore (no such function)
		}
		if(!%killerId.Undead)
		{
         %killerId.scoreKills++;
		%killerId.score++;
			if(%playerId.isTk && !%killerId.isTk)
			%killerId.score++;
		Game::refreshClientScore(%killerId);
		}
		if(!%playerId.Undead && !%killerId.Undead)
		{
        	%playerId.scoreDeaths++;  // test play mode
     		%playerId.score--;
            Game::refreshClientScore(%playerId);
		}
      }
	if(%playerId.Undead && (Client::getName(%killerId) == $Chivalry::Paladin || Client::getName(%killerId) == $Chivalry::Warlord || Player::getArmor(%killerId) == palarmor || %damageType == $ReincarnateDamageType || (Player::getArmor(%killerId) == clrarmor || Player::getArmor(%killerId) == clrfemale && %damageType == $TurnDamageType)))
		{
			//if(%damageType == $ReincarnateDamageType)
			//%playerId.score--;
		%playerId.Undead = false;
		echo("PLAYER:  "@Client::getName(%playerId)@" is no longer Undead");
		Client::sendMessage(%playerId,0,"You have been released from your Undead state!");
		Client::sendMessage(%killerId,0,"You have slain an Undead Warrior and freed his soul!");
		Game::assignClientTeam(%playerId);
		}
	if(%playerId.Litch && (Client::getName(%killerId) == $Chivalry::Paladin || Client::getName(%killerId) == $Chivalry::Warlord || (Player::getArmor(%killerId) == clrarmor || Player::getArmor(%killerId) == clrfemale && %damageType == $TurnDamageType)))
		{
		if(Client::getName(%killerId) == $Chivalry::Paladin)
		%title = "Paladin";
		else if(Client::getName(%killerId) == $Chivalry::Warlord)
		%title = "Warlord";
		else %title = "Cleric";
		%playerId.isFree = true;
		$Evil::Litch = "";
		%playerId.Litch = false;
		%name = Client::getName(%killerId);
		echo("PLAYER:  "@Client::getName(%killerId)@" has slain the Litch King");
		Messageallexcept(%playerId,0,%title @" "@%name@" has slain the Litch King!!");
		Client::sendMessage(%playerId,0,"Paladin "@%name@" has slain you, releasing your spirit and providing you with a second chance at life!");
		Player::setItemCount(%playerId,UndeadSpell,0);
		}
   }
   Game::clientKilled(%playerId, %killerId);
	
}

function Game::clientKilled(%playerId, %killerId)
{
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ Client::getName(%player) @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ Client::getName(%player) @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

function Game::reincarnateKillPoints(%clientId, %killerId)
{
	if(!%clientId.Undead)
	%clientId.score++;
	%clientId.scoreDeaths--;
	%killerId.score--;
	Game::refreshClientScore(%clientId);
	Game::refreshClientScore(%killerId);
}

function Game::reincarnateAutoRespawn(%clientId)
{
  ///do nothing
}

function Game::lowteam(%playerId) 
{ 	
	%numTeams = getNumTeams();
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
		if(%numTeamPlayers[%i] < %leastPlayers)
		{ 		
			%leastTeam = %i;
 			%leastPlayers = %numTeamPlayers;
 		} 	
	} 	
return %leastTeam; 
} 

function FairTeam(%here, %dest)
 { %numTeams = getNumTeams();
 %numPlayers = getNumClients();
 for(%i = 0; %i < %numTeams; %i++) 
%numTeamPlayers[%i] = 0;
 for(%i = 0; %i < %numPlayers; %i++) {
 %pl = getClientByIndex(%i);
 %team = Client::getTeam(%pl);
 %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; }
 %least = 0;
 %most = 0;
 for(%i = 0; %i < %numTeams; %i++) { if(%numTeamPlayers[%i] > %numTeamPlayers[%most])
 %most = %i;
 if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i; }
 if(%here == -1) %here = %most;
 if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true;
 else return false;
}

function GiveGrace(%clientId)
{
%time = $Chivalry::GraceTime;
if(%time > 10)
%time = 10;
if(%time < 2)
%time = 2;
%cl = Client::getOwnedObject(%clientId);
//messageall(0,"Grace Period called");
%cl.shieldStrength = 1.0;
schedule(%cl @ ".shieldStrength = 0;",%time,%clientId);
}
