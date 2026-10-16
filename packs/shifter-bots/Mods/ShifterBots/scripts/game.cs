exec("comchat.cs");
exec("fairteams.cs");

//================================================== Globals
$fa_armor = "";
$fa_pack = "";

$Shifter::BotVersion = True;

$pskin = $Shifter::PersonalSkin;
$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$modmgtModName = "SHAntiTK";
$modmgtModVers = "1.30";
$SHBanListMarker = "true";
//================================================== End Globals




exec("shban.cs"); //=== SHBan Modified For Shifter

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
$TeamEnergyCheat = 1;

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
$ItemRespawnTime = 30;

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
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 10;    //Define Max Height of the area

$TurretBoxMinLength = 10;	 //Define Min Length from another turret
$TurretBoxMinWidth =  10;	 //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType   = 1 << 1;
$SimInteriorObjectType  = 1 << 2;
$SimPlayerObjectType    = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	= 1 << 29;  
$StaticObjectType		= 1 << 23;	   
$ItemObjectType			= 1 << 21;	  

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
$deathMsg[$LandingDamageType, 0]     = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]     = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]     = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]     = "%2 fall down go boom.";

$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 gets mowed down by %1.";
$deathMsg[$ImpactDamageType, 3]      = "%1 inflicts a crushing blow on %2";

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

$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a death throw from %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with flying death.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's shot caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's death blow.";

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

$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1.";
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

$deathMsg[$MineDamageType, 0]	     = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	     = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	     = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	     = "%2 never saw it coming from %1.";

$deathMsg[$GravDamageType, 0]	     = "%1 rips %2 to pieces.";
$deathMsg[$GravDamageType, 1]	     = "%2 gets schooled in physics by %1.";
$deathMsg[$GravDamageType, 2]	     = "%1 gives %2 a fatal concussion.";
$deathMsg[$GravDamageType, 3]	     = "%2 never saw it coming from %1.";

$deathMsg[$BoomDamageType, 0]		 = "%2 was turned into swiss cheese by %1.";
$deathMsg[$BoomDamageType, 1]		 = "%2 gets sawed in half by %1.";
$deathMsg[$BoomDamageType, 2]		 = "%2 catches a few slugs from %1.";
$deathMsg[$BoomDamageType, 3]		 = "%2 gets a real blast from %1.";

$deathMsg[$FlashDamageType, 0]		 = "%2 was EMPed to death by %1.";
$deathMsg[$FlashDamageType, 1]		 = "%2 gets drained by %1.";
$deathMsg[$FlashDamageType, 2]		 = "%2 get an electric blast from %1.";
$deathMsg[$FlashDamageType, 3]		 = "%2 gets sucked dry by %1.";

$deathMsg[$NukeDamageType, 0]		 = "%2 was incinerated by %1's nuclear blast..";
$deathMsg[$NukeDamageType, 1]		 = "%2 was turned to ashes by %1.";
$deathMsg[$NukeDamageType, 2]		 = "%2 was caught by %1's wall of fire.";
$deathMsg[$NukeDamageType, 3]		 = "%2 was sent to meet %4 maker by %1.";


// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//===============================================================================================================
// Randomize Spawn Buy List
//===============================================================================================================

	$spawnBuyList[0] = MediumArmor;
	$spawnBuyList[1] = HyperB;
	$spawnBuyList[2] = Chaingun;
	$spawnBuyList[3] = Disclauncher;
	$spawnBuyList[4] = RepairKit; 
	$spawnBuyList[5] = GrenadeLauncher; 
	$spawnBuyList[6] = Grenade; 
	$spawnBuyList[7] = Grenade; 
	$spawnBuyList[8] = Grenade;
	$spawnBuyList[9] = Beacon;
	$spawnBuyList[10] = Beacon;
	$spawnBuyList[11] = Beacon;
	$spawnBuyList[12] = Beacon;
	$spawnBuyList[13] = TargetingLaser;
	$spawnBuyList[14] = RepairPack;
	$spawnBuyList[15] = "";
	$fa_armor = "Mercenary";
	$fa_pack = "RepairPack";
	
function randomSpawnList()
{
	if ($Shifter::SpawnRandom)
	{
		%rnd = floor(getRandom() * 50);	
		echo("Setting Up Gear For Random Spawn" @ %rnd @ " - ");
		if (%rnd <= 20) //=========================== Most of the time 
		{
		echo("Spawn - Standard");
			$spawnBuyList[0] = MediumArmor;
			$spawnBuyList[1] = HyperB;
			$spawnBuyList[2] = Chaingun;
			$spawnBuyList[3] = Disclauncher;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = GrenadeLauncher; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = RepairPack;
			$spawnBuyList[15] = "";
			$fa_armor = "Mercenary";
			$fa_pack = "RepairPack";

		}
	
		if ((%rnd >= 21) && (%rnd <= 35))
		{
		echo("Spawn - Drednaught");
			$spawnBuyList[0] = DragArmor;
			$spawnBuyList[1] = Mortar;
			$spawnBuyList[2] = Vulcan;
			$spawnBuyList[3] = Disclauncher;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = GrenadeLauncher; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = EnergyPack;
			$spawnBuyList[15] = "";
			$fa_pack = "EnergyPack";
			$fa_armor = "Dreadnaught";
		}
	
		if ((%rnd >= 36) && (%rnd <= 40))
		{
		echo("Spawn - Goliath");
			$spawnBuyList[0] = BursterArmor;
			$spawnBuyList[1] = Mortar;
			$spawnBuyList[2] = RocketLauncher;
			$spawnBuyList[3] = Flamer;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = GrenadeLauncher; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = EnergyPack;
			$spawnBuyList[15] = "";
			$fa_pack = "EnergyPack";
			$fa_armor = "Goliath";
		}
	
		if ((%rnd >= 41) && (%rnd <= 45))
		{
		echo("Spawn - Arbitor");
			$spawnBuyList[0] = AlArmor;
			$spawnBuyList[1] = HyperB;
			$spawnBuyList[2] = Omega;
			$spawnBuyList[3] = IonGun;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = ConCun; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = EnergyPack;
			$spawnBuyList[15] = "";
			$fa_pack = "EnergyPack";
			$fa_armor = "Arbitor";
		}
	
		if ((%rnd >= 46) && (%rnd <= 48))
		{
		echo("Spawn - Engineer 1");
			$spawnBuyList[0] = EngArmor;
			$spawnBuyList[1] = RailGun;
			$spawnBuyList[2] = FixIt;
			$spawnBuyList[3] = DiscLauncher;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = RocketLauncher; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = RepairPack;
			$spawnBuyList[15] = "";
			$fa_pack = "RepairPack";
			$fa_armor = "Engineer1";
		}
	
		if ((%rnd == 49) || (%rnd == 50))
		{
		echo("Spawn - Engineer 2");
			$spawnBuyList[0] = EngArmor;
			$spawnBuyList[1] = RailGun;
			$spawnBuyList[2] = DiscLauncher;
			$spawnBuyList[3] = RocketLauncher;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = Grenade; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = DeployableInvPack;
			$spawnBuyList[15] = "";
			$fa_pack = "Invo. Station";
			$fa_armor = "Engineer2";
		}
	}
	else
	{
	echo("Spawn - Standard - No Random");
		$spawnBuyList[0] = MediumArmor;
		$spawnBuyList[1] = HyperB;
		$spawnBuyList[2] = Chaingun;
		$spawnBuyList[3] = Disclauncher;
		$spawnBuyList[4] = RepairKit; 
		$spawnBuyList[5] = GrenadeLauncher; 
		$spawnBuyList[6] = Grenade; 
		$spawnBuyList[7] = Grenade; 
		$spawnBuyList[8] = Grenade;
		$spawnBuyList[9] = Beacon;
		$spawnBuyList[10] = Beacon;
		$spawnBuyList[11] = Beacon;
		$spawnBuyList[12] = Beacon;
		$spawnBuyList[13] = TargetingLaser;
		$spawnBuyList[14] = RepairPack;
		$spawnBuyList[15] = "";
		$fa_pack = "RepairPack";
		$fa_armor = "Mercenary";
	}
}

//===============================================================================================Game CS Functions
	
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
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1)
		{
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

function Game::startMatch()																						// game.cs
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
   Game::resetScores();	
	
   if ($Shifter::AreThereBots)
   {
	if ($SpoonBot::AutoSpawn)
	   AI::ProcessAutoSpawn(); //================================= Spawn all the bots defined in SPOONBOT.CS (Werewolf)
   }

   //TS
   echo("\"M\"" @ $missionName @ "\"" @ ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");

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

   if(!%respawn) //================================================================================== Server Welcome Message On First Spawn
   {
		if ($Shifter::WelcomeDelay > 0) bottomprint(%clientId, $Shifter::WelcomeMsg, $Shifter::WelcomeDelay);
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
	else
	{
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

randomSpawnList();

$Shifter::JustSpawned[%clientId] = "True";
schedule ("$Shifter::JustSpawned[" @ %clientId @ "] = False;",$Shifter::SpawnSafe);


%clientId.spawn= 1;
%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
   }
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);	
   		%clientId.spawnWeapon="";
	}
	bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10); //== Added By Ascain
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

			if ($Shifter::PersonalSkin)
			{
			  	Client::buildMenu(%clientId, "Pick a team:", "usecustom");
	    	  	Client::addMenuItem(%clientId, "0 Use Personal Skin", 0);
	    	  	Client::addMenuItem(%clientId, "1 Use Team Default", 1);
			}
			
		    bottomprint(%clientId, $Server::JoinMOTD, 0);	      
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
   if(%team != -2)
   {
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
}


function processMenuPickTeam(%clientId, %team, %adminClient)													// admin.cs
{
   if (%adminClient==2048) $AdminName = "the Administrator";
   else $AdminName = Client::getName(%adminClient);

   	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   {
      if(Observer::enterObserverMode(%clientId))
      {
       //TS
       echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");
       
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ $AdminName @ ".");
			Game::resetScores(%clientId);
		   Game::refreshClientScore(%clientId);
		}
      return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ $AdminName @ ".");

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   
   //TS
   echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");

   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
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
//======================================================================================================== Reset Client Scores Back To Zero
function Game::resetScores(%client)
{
echo("*** Resetting Client Scores");
	if(%client == "")
	{
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
			echo ("*** Begin Scores For " @ %cl);
	
	   		%cl.scoreKills = 0;
   	   		%cl.scoreDeaths = 0;
			%cl.ratio = 0;
      		%cl.score = 0;
			%cl.FlagCaps = 0;
			%cl.TKCount = 0;
		}
	}
	else
	{
		echo ("*** Resetting Scores For " @ %client);
		if (%client.TKCount > 0)
			%client.TKCount = %cl.TKCount;
		else
			%client.TKCount = 0;

        %client.scoreKills = 0;
  	    %client.scoreDeaths = 0;
		%client.FlagCaps = 0;		
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

//========================================================================================================== SetUp Players Stats On Connect
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.TKCount = 0;
	%playerId.FlagCaps = 0;
	%playerId.justConnected = true;
	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);

	//============================= Personal Weapon Settings

		%playerId.Mortar = "0";
		%playerId.Plasma = "0";	
		%playerId.Plastic = "15";
		%playerId.EngMine = "0";

	echo ("Setting up " @ %PlayerId);
}


function Game::assignClientTeam(%playerId)																		// game.cs
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
            //TS echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
			echo("\"A\"" @ %playerId @ "\"" @ $teamPreset[%name] @ "\"");
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
      //TS echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
	  echo("\"A\"" @ %playerID @ "\"" @ %leastTeam @ "\"");
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}
//========================================================================================================== Outside Mission Area Damage
//  Keep players inside the map area in CTF originally by Shane Hyde
//  If $Shifter::NoOutside = "true";	Then turn on Outside of mission area damage

function Player::enterMissionArea(%player)
{
%player.outArea="";
echo("player entering map again");
%cl = Player::getClient(%player);
Client::sendMessage(%cl,1,"You have returned to the mission area");
}

function Player::leaveMissionArea(%player)
{  
  if($Shifter::NoOutside)
  {
		if($Game::missionType == "CTF")
		{
		    echo("Player " @ %player @ " has left the mission area. 10 Sec to Death");

		   	%cl = Player::getClient(%player);
			Client::sendMessage(%cl,1,"You have left the mission area. In 10 secs, you start to die!");
			%player.outArea=1;
			alertPlayer(%player, 5);
		}
		else
  		    echo("Player " @ %player @ " has left the mission area.");
  }
}

function alertPlayer(%player, %count)
{
	if(%player.outArea == 1)
	{
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count == 4)
		{
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  		GameBase::virtual(%obj, "playerLeaveMissionArea", %player);		
			schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		}	
		else if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		else
		   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
	if(!Player::isDead(%player))
	{
	  	Player::setDamageFlash(%client,0.1);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
   		schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
	}
	else 
		playNextAnim(%client);	
	}
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

//========================================================================================================================================
//========================================================================================================================================
//                                   ...Player Kills Or Dies - Anti-TK Stuff - Kill Scoring Etc...
//========================================================================================================================================
//========================================================================================================================================

function Player::onKilled(%this)
{
	echo("*** Player Killed ***");

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
		
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
		
	Player::setDamageFlash(%this,0.75);
	
	for (%i = 0; %i < 8; %i = %i + 1) 
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
	
	%kdpos = GameBase::getPosition(%this);
	%this.shit = 1;
	%this.TKDeathPos = %kdpos;

	$lastkillpos = %kdpos;
	$killedarmor = Player::getArmor(%this);

      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}


function Client::onKilled(%playerId, %killerId, %damageType)													// game.cs
{
   //TS echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
   if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && (%killerId != playerId))
       echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
   else
       echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");   
   %killedflag = $killedflagcarry;	
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
     if ($ScoreOn) bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);	
}
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;

      if (%killedflag)
	  {
		  %playerId.score = (%playerId.score - $Score::FlagDef);
		  if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);  
	  }
	  else
	  {
	      %playerId.score--;
	  	  if ($ScoreOn) bottomprint(%playerId,"Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);
	  }

	  echo("*** Suicide Death");

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
     		 
		 if ($Shifter::TeamKillOn == "True")
		 {
		       echo ("*** Checking For A Team Kill");   
               CheckTeamKiller(%killerId,%playerId,%damagetype);
		 }
       }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);

//==================================================================================================================== Advanced Scoring
//== See also in the objectives.cs file for the print out of stats... Currently Stats are printed for all players... 
//==================================================================================================================== Advanced Scoring

		%score = 0;												//== Reset Scoring
   		%killerteam = Client::getTeam(%killerId);				//== Killers Team
   		%diedteam = Client::getTeam(%playerId);					//== Died Team
   	    %killedpos = $lastkillpos;								//== Killed Pos
		%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
		%killerarmor = Player::getArmor(%killerId);				//== Killers Armor
		%diedarmor = $killedarmor;								//== Died Armor
   		%flagpos = ($teamFlag[%killerteam]).originalPosition;	//== Flags Home Pos
       	%flagdist = Vector::getDistance(%killedpos,%flagpos);	//== Distance from Killed Player To Enemy Flag
       	%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

	   	$killedflagcarry = "False";

		$lastkillpos = -1; //== Reset
		$killedarmor = -1; //== Reset		   		


//============================================================================================================== Flag Runner Killed Bonus

	if (%killedflag)
	{
		echo ("Flag Runner Killed");
		%score = (%score + $Score::FlagKill);
	}

//============================= This data block is used to determin the amount of bonus kill points that a player
//============================= with a certain armor type will get for killing a player of with another armor type.
//============================= The calculation will take the difference of the two - player and killer armor types
//============================= and award the killer with that number as a score bonus.
//============================= If a player in SpyArmor Kills a player in Jarmor the difference is 5 points...

	if (%killerarmor == "larmor") 		  %kval = 1; //== Assassin Armor
	else if (%killerarmor == "lfemale")	  %kval = 1; //== Assassin Armor 
	else if (%killerarmor == "marmor")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "mfemale")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "earmor") 	  %kval = 3; //== Engineer 
	else if (%killerarmor == "efemale")	  %kval = 3; //== Engineer 
	else if (%killerarmor == "spyarmor")  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "spyfemale") %kval = 1; //== Chemeleon 
	else if (%killerarmor == "sarmor")	  %kval = 1; //== Scout 
	else if (%killerarmor == "sfemale")	  %kval = 1; //== Scout 
	else if (%killerarmor == "barmor") 	  %kval = 4; //== Goliath 
	else if (%killerarmor == "bfemale")	  %kval = 4; //== Goliath 
	else if (%killerarmor == "darmor") 	  %kval = 5; //== Dreadnaught 
	else if (%killerarmor == "harmor")	  %kval = 4; //== Heavy 
	else if (%killerarmor == "aarmor")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "afemale")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "dmarmor")	  %kval = 2; //== Death Match
	else if (%killerarmor == "dmfemale")  %kval = 2; //== Death Match
	else if (%killerarmor == "parmor")    %kval = 1; //== Penis Curse Armor
	else if (%killerarmor == "jarmor")	  %kval = 6; //== Juggernaught

	if (%diedarmor == "larmor") 		 %dval = 1; //== Assassin Armor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== Assassin Armor 
	else if (%diedarmor == "marmor")     %dval = 2; //== Medium 
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium 
	else if (%diedarmor == "earmor") 	 %dval = 3; //== Engineer 
	else if (%diedarmor == "efemale")	 %dval = 3; //== Engineer 
	else if (%diedarmor == "spyarmor")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "spyfemale")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "sarmor")	 %dval = 1; //== Scout 
	else if (%diedarmor == "sfemale")	 %dval = 1; //== Scout 
	else if (%diedarmor == "barmor") 	 %dval = 4; //== Goliath 
	else if (%diedarmor == "bfemale")	 %dval = 4; //== Goliath 
	else if (%diedarmor == "darmor") 	 %dval = 5; //== Dreadnaught 
	else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy 
	else if (%diedarmor == "aarmor")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "afemale")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	else if (%diedarmor == "parmor")  	 %dval = 1; //== Penis Curse Armor
	else if (%diedarmor == "jarmor")	 %dval = 6; //== Juggernaught

   		//echo ("*** Advanced Scoring Options ***");
   		//echo ("    Location Of Flag  = " @ %flagpos);
   		//echo ("    Distance To Flag  = " @ %flagdist);
		//echo ("    Distance Of Kill  = " @ %killdist);
   		//echo ("    Killers Team      = " @ %killerteam);
   		//echo ("    Died Pl Team      = " @ %diedteam);
   		//echo ("    Died Pl Pos.      = " @ %killedpos);
		//echo ("	 Kill Damage Type  = " @ %damageType);
   		//echo ("    Player Location   = " @ %killedpos @ " in " @ %diedarmor @ " Armor." );
   		//echo ("    Killer Loaction   = " @ GameBase::getPosition(%killerId) @ " in " @ %killerarmor @ " Armor." );

   		   
   		//=============================================================== Base-Flag Defence Scoring
   		
   			if (%flagdist <= 25)
			{
				%score = (%score + $Score::25Meters);
			}
			else if ((%flagdist > 25) && (%flagdist <= 75))
			{
				%score = (%score + $Score::75Meters);
			}
			else if ((%flagdist > 75) && (%flagdist <= 150))
			{
				%score = (%score + $Score::150Meters);
			}
			else if ((%flagdist > 150) && (%flagdist <= 250))
			{
				%score = (%score + $Score::250Meters);
			}
			else
			{
				%score = (%score + 1);
			}

   		//=============================================================== Armor Kill Armor Bonuses
		
			if (%kval < %dval) 
			{
				%armordiff = (%dval - %kval);
				//echo ("    Kill Armor Diff   = " @ %armordiff);
				%score = (%score + %armordiff);
			}

   		//=============================================================== Kill Range Bonus

		if (%damageType != $MortarDamageType && %damageType != $MineDamageType && %daamageType != $NukeDamageType)
		{			


				if (%killdist >= 251)
				{
					%score = (%score + $Score::Kill250Plus);
					//echo ("*** Plus " @ $Score::Kill250Plus);
					//echo ("*** Range Bonus Points");				
				}				
				else if (%killdist > 100 && %killdist <= 250)
				{
					%score = (%score + $Score::Kill250Meters);
					//echo ("*** Plus " @ $Score::Kill250Meters);
					//echo ("*** Range Bonus Points");				
				}
				else if (%killdist > 50 && %killdist <= 100)
				{
					%score = (%score + $Score::Kill100Meters);
					//echo ("*** Plus " @ $Score::Kill100Meters);
					//echo ("*** Range Bonus Points");				
				}				
				else if (%killdist > 15 && %killdist <= 50)
				{
					%score = (%score + $Score::Kill50Meters);
					//echo ("*** Plus " @ $Score::Kill50Meters);
					//echo ("*** Range Bonus Points");				
				}
				else if (%killdist <= 15)
				{
					%score = (%score + $Score::Kill15Meters);
					//echo ("*** Plus " @ $Score::Kill15Meters);
					//echo ("*** Range Bonus Points");				
				}	
	



				
		}	   
   		
   		//=============================================================== Base Defence Scoring   		

   		//echo ("*** End Of Adv Scoring Vars");
   
   		//=============================================================== Basic Scoring

			if ($Shifter::JustSpawned[%playerId])
			{
				%score = floor (%score / 2);
				//echo ("*** Player Just Spawned - Points Are Halved");
			}
			
            %killerId.scoreKills++;									//=== Killer Number Of Kills
            %playerId.scoreDeaths++;  								//=== Killed Player Deaths
            %killerId.score = (%killerId.score + %score);			//=== Killer Score
			
			if (%killedflag)
			{
				if ($ScoreOn) bottomprint(%killerId, "Flag Runner Killed! Score +" @ %score @ " = " @ %killerId.score @ " Total Score");
              	messageAll(0, Client::getName(%killerId) @ " gets a bonus for killing the flag runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, "Score +" @ %score @ " = " @ %killerId.score @ " Total Score");
   			}
   		//====================================== Refresh Scores		 
         
		 Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}


function CheckTeamKiller(%killerId,%playerId,%damagetype)
{
	echo("***Processing Team Kill On - " @ %killerId @ " For Killing - " @ %playerId);
	
    if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType)
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
		
      		      	 echo("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId));
					 echo("***" @ %dist @ " " @ $SHAntiTeamKillProximity);
	
			         if(%dist < $SHAntiTeamKillProximity)
      			     {
        	    	     echo("***Player "@ Client::getName(%playerId) @" was close, kill is accidental.");
			             return;
      			     }
				}
			}
        }
	
        messageAll(0, "***" @ Client::getName(%killerId) @ " TeamKilled***");

//================================================================================================================= Start Team Kill Scoring

	%score = 0;												//== Reset Scoring
 	%killerteam = Client::getTeam(%killerId);				//== Killers Team
  	%diedteam = Client::getTeam(%playerId);					//== Died Team
   	%killedpos = $lastkillpos;								//== Killed Pos
	%killerarmor = Player::getArmor(%killerId);				//== Killers Armor
	%diedarmor = $killedarmor;								//== Died Armor
   	%flagpos = ($teamFlag[%killerteam]).originalPosition;	//== Flags Home Pos
    %flagdist = Vector::getDistance(%killedpos,%flagpos);	//== Distance from Killed Player To Enemy Flag

    %killedflag = $killedflagcarry;														//== Was flag runner killed

   	$killedflagcarry = "False";	 //== Reset
	$lastkillpos = -1;			 //== Reset
	$killedarmor = -1;			 //== Reset		   		
	   		

//============================= Deduct Points For Friendly Team Kill

	if (%killedflag)
	{
		echo ("Flag Runner Killed");
		%score = (%score + ($Score::FlagKill * 2));
	}


//============================= This data block is used to determin the amount of bonus kill points that a player
//============================= with a certain armor type will get for killing a player of with another armor type.
//============================= The calculation will take the difference of the two - player and killer armor types
//============================= and award the killer with that number as a score bonus.
//============================= If a player in SpyArmor Kills a player in Jarmor the difference is 5 points...

	if (%killerarmor == "larmor") 		  %kval = 1; //== Assassin Armor
	else if (%killerarmor == "lfemale")	  %kval = 1; //== Assassin Armor 
	else if (%killerarmor == "marmor")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "mfemale")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "earmor") 	  %kval = 3; //== Engineer 
	else if (%killerarmor == "efemale")	  %kval = 3; //== Engineer 
	else if (%killerarmor == "spyarmor")  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "spyfemale") %kval = 1; //== Chemeleon 
	else if (%killerarmor == "sarmor")	  %kval = 1; //== Scout 
	else if (%killerarmor == "sfemale")	  %kval = 1; //== Scout 
	else if (%killerarmor == "barmor") 	  %kval = 4; //== Goliath 
	else if (%killerarmor == "bfemale")	  %kval = 4; //== Goliath 
	else if (%killerarmor == "darmor") 	  %kval = 5; //== Dreadnaught 
	else if (%killerarmor == "harmor")	  %kval = 4; //== Heavy 
	else if (%killerarmor == "aarmor")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "afemale")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "dmarmor")	  %kval = 2; //== Death Match
	else if (%killerarmor == "dmfemale")  %kval = 2; //== Death Match
	else if (%killerarmor == "parmor")    %kval = 1; //== Penis Curse Armor
	else if (%killerarmor == "jarmor")	  %kval = 6; //== Juggernaught

	if (%diedarmor == "larmor") 		 %dval = 1; //== Assassin Armor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== Assassin Armor 
	else if (%diedarmor == "marmor")     %dval = 2; //== Medium 
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium 
	else if (%diedarmor == "earmor") 	 %dval = 3; //== Engineer 
	else if (%diedarmor == "efemale")	 %dval = 3; //== Engineer 
	else if (%diedarmor == "spyarmor")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "spyfemale")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "sarmor")	 %dval = 1; //== Scout 
	else if (%diedarmor == "sfemale")	 %dval = 1; //== Scout 
	else if (%diedarmor == "barmor") 	 %dval = 4; //== Goliath 
	else if (%diedarmor == "bfemale")	 %dval = 4; //== Goliath 
	else if (%diedarmor == "darmor") 	 %dval = 5; //== Dreadnaught 
	else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy 
	else if (%diedarmor == "aarmor")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "afemale")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	else if (%diedarmor == "parmor")  	 %dval = 1; //== Penis Curse Armor
	else if (%diedarmor == "jarmor")	 %dval = 6; //== Juggernaught

   		if ($Shifter::Debug) echo ("*** Team Kill Scoring ***");
   		if ($Shifter::Debug) echo ("    Location Of Flag  = " @ %flagpos);
   		if ($Shifter::Debug) echo ("    Distance To Flag  = " @ %flagdist);
   		if ($Shifter::Debug) echo ("    Killers Team      = " @ %killerteam);
   		if ($Shifter::Debug) echo ("    Died Pl Team      = " @ %diedteam);
   		if ($Shifter::Debug) echo ("    Died Pl Pos.      = " @ %killedpos);
   		if ($Shifter::Debug) echo ("    Player Location   = " @ %killedpos @ " in " @ %diedarmor @ " Armor." );
   		if ($Shifter::Debug) echo ("    Killer Loaction   = " @ GameBase::getPosition(%killerId) @ " in " @ %killerarmor @ " Armor." );

   		   
   		//=============================================================== Base-Flag Defence Scoring
   		
   			if (%flagdist <= 25)
			{
				%score = (%score + $Score::25Meters);
				if ($Shifter::Debug) echo ("*** Plus " @ $Score::25Meters);
			}
			else if ((%flagdist > 25) && (%flagdist <= 75))
			{
				%score = (%score + $Score::75Meters);
				if ($Shifter::Debug) echo ("*** Plus " @ $Score::75Meters);
			}
			else if ((%flagdist > 75) && (%flagdist <= 150))
			{
				%score = (%score + $Score::150Meters);
				if ($Shifter::Debug) echo ("*** Plus " @ $Score::150Meters);
			}
			else if ((%flagdist > 150) && (%flagdist <= 250))
			{
				%score = (%score + $Score::250Meters);
				if ($Shifter::Debug) echo ("*** Plus " @ $Score::250Meters);
			}
			else
			{
				if ($Shifter::Debug) echo ("*** Basic Kill Score");				
				if ($Shifter::Debug) echo ("*** Plus 1");
				%score = (%score + 1);
			}

   		//=============================================================== Armor Kill Armor Bonuses
		
			if (%kval < %dval) 
			{
				%armordiff = (%dval - %kval);
				if ($Shifter::Debug) echo ("    Kill Armor Diff   = " @ %armordiff);
				%score = (%score + %armordiff);
			}

   		//=============================================================== Damage Based Points
   
   
   
   
   		
   		//=============================================================== Base Defence Scoring
   		
   	
   
   		//=============================================================== Basic Scoring

			if ($Shifter::JustSpawned[%playerId] == "false")
			{
           		%killerId.scoreDeaths++;									//=== Killer Number Of Kills
            	%killerId.score = (%killerId.score - %score);				//=== Killer Score
		   		if ($Shifter::Debug) echo ("*** Player Team Killed - Deducting Points");
			}
			else
			{
				%score = floor(%score / 2);
           		%killerId.scoreDeaths++;									//=== Killer Number Of Kills
            	%killerId.score = (%killerId.score - %score);				//=== Killer Score
		   		if ($Shifter::Debug) echo ("*** Team Kill - But Killed Player Just Spawned - Possible Accident - Points Deducted Halved");
			}
   		if ($Shifter::Debug) echo ("*** End Of Adv Scoring Vars");
   
   		//====================================== Refresh Scores		 
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);


			if (%killedflag)
			{
				if ($ScoreOn) centerprint(%killerId, "You Team Killed The Flag Runner! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
              	messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, " You Team Killed! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
   			}

//============================================================================================================== Finished Team Kill Scoring

		$Shifter::LastTker = (Client::getName(%killerId));
		$Shifter::LastTKed = (Client::getName(%playerId));
		$Shifter::LastTKno = (%killerid.TKCount + 1);
		
        if(%killerid.TKCount == "")
        {
                %killerid.TKCount = 1;
        }
        else
        {
            %killerid.TKCount = %killerid.TKCount + 1;
			
			//=============================================================================================== Server Terminates Team Killer

			if (%killerid.TKCount > $Shifter::KillTerm)
			{
				echo ("***Terminating Player "@ Client::getName(%killerId) @" For Team Killing");
				if ($Shifter::KillTerm > "1")
				{
					//messageAll(0, "***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than " @ $Shifter::KillTerm @ " Times."); 
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than " @ $Shifter::KillTerm @ " Times.",5);
					ADMIN::Terminate(%killerId);
				}
				else
				{
					//messageAll(0, "***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than 1 Time."); 
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than 1 Time.", 5); 
					ADMIN::Terminate(%killerId);
				}
			}
			
			
            if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
            {
				bottomprintall("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling", 5); 
				echo("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling"); 

                    %ip = Client::getTransportAddress(%killerId);
                    BanList::add(%ip, $SHAntiTeamKillBanTime);      //=== Add Player To BanList
				    shban(%ip);
                    %killer = Client::getOwnedObject(%killerId);
//                  messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
                    Net::kick(%killerId,"***" @ $Shifter::TeamKillMsg @ "***");
            }
            else
			{
            	if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
	            {
	                centerprint(%killerId, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kicked and banned.", 10);
	            }
			}
        }		
    }
	else
		echo ("***Processing Complete - Damage Type Incorrect");
}