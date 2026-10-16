exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;



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


$WaitThrowTime = 1.5;


$TeamEnergyCheat = 0;


$MaxTeamEnergy = 700000;


$incTeamEnergy = 700;


$secTeamEnergy = 30;


$ItemRespawnTime = 30;


$RemoteAmmoEnergy = 3200; 
$RemoteInvEnergy = 3600;


$TeammateSpending = -4000;  
$WarnEnergyLow = 4000;	    


$InitialPlayerEnergy = 5000;


$MaxNumTurretsInBox = 2;     
$TurretBoxMaxLength = 35;    
$TurretBoxMaxWidth =  35;    
$TurretBoxMaxHeight = 17;    

$TurretBoxMinLength = 7;	  
$TurretBoxMinWidth =  7;	  
$TurretBoxMinHeight = 7;    


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


 $deathMsg[$LandingDamageType, 0] = "%1 falls to %2 death.";
 $deathMsg[$LandingDamageType, 1] = "%1 splatters into the ground.";
 $deathMsg[$LandingDamageType, 2] = "%1 adds a nice red color to the ground.";
 $deathMsg[$LandingDamageType, 3] = "%1 fell down and capped his Ass.";

 $deathMsg[$ImpactDamageType, 0] = "%1 makes quite an impact on %2.";
 $deathMsg[$ImpactDamageType, 1] = "%2 becomes the victim of a fly-by from %1.";
 $deathMsg[$ImpactDamageType, 2] = "%2 leaves a nasty dent in %1's fender.";
 $deathMsg[$ImpactDamageType, 3] = "%1 says, 'Hey %2, you scratched my paint job!'";

 $deathMsg[$BulletDamageType, 0] = "%2 got regulated by %1.";
 $deathMsg[$BulletDamageType, 1] = "%1 gives %2 an overdose of lead.";
 $deathMsg[$BulletDamageType, 2] = "%1 gave %2 a hole in %4 head that wasn't there before.";
 $deathMsg[$BulletDamageType, 3] = "%1 guns down %2.";

 $deathMsg[$EnergyDamageType, 0] = "%2 dies of poison.";
 $deathMsg[$EnergyDamageType, 1] = "%2 gets a lethal injection.";
 $deathMsg[$EnergyDamageType, 2] = "%2 falls victim to a deadly virus.";
 $deathMsg[$EnergyDamageType, 3] = "%2 could not find the vaccine in time.";

 $deathMsg[$SuperEnergyDamageType, 0] = "%2 dies of poison.";
 $deathMsg[$SuperEnergyDamageType, 1] = "%2 gets a lethal injection.";
 $deathMsg[$SuperEnergyDamageType, 2] = "%2 falls victim to a deadly virus.";
 $deathMsg[$SuperEnergyDamageType, 3] = "%2 could not find the vaccine in time.";

$deathMsg[$ShotgunDamageType, 0] = "%2 caught a chest full of %1's shotgun blast.";
$deathMsg[$ShotgunDamageType, 1] = "%1 filled %2 full of shotgun pellets.";
$deathMsg[$ShotgunDamageType, 2] = "%2 went down after %1's vicious shotgun assault.";
$deathMsg[$ShotgunDamageType, 3] = "%2 lets freedom ring with a shotgun blast from %1.";

$deathMsg[$MExplosionDamageType, 0] = "%2 got blown to bits from %1's rocket turret.";
$deathMsg[$MExplosionDamageType, 1] = "%1's rocket turret blew the hell out of %2.";
$deathMsg[$MExplosionDamageType, 2] = "%2 swallows a rocket from %1's turret.";
$deathMsg[$MExplosionDamageType, 3] = "%2 gets friendly with a rocket from %1's turret.";

$deathMsg[$AAExplosionDamageType, 0] = "%2 got blown to bits from %1's Disk turret.";
$deathMsg[$AAExplosionDamageType, 1] = "%1's Disk turret blew the hell out of %2.";
$deathMsg[$AAExplosionDamageType, 2] = "%1's Disk turret explodes %2 into oblivion.";
$deathMsg[$AAExplosionDamageType, 3] = "%2 explodes courtesy of %1's Disk turret.";

$deathMsg[$TeleFragDamageType, 0] = "%2 was reduced to %4 component atoms."; 
$deathMsg[$TeleFragDamageType, 1] = "%2 gets vaporized by a teleporter."; 
$deathMsg[$TeleFragDamageType, 2] = "%2 falls victim to a teleporter malfunction."; 
$deathMsg[$TeleFragDamageType, 3] = "%2 gets telefragged."; 

$deathMsg[38, 0] = "%2 gets struck by lightning."; 
$deathMsg[38, 1] = "%2 gets charred by a lightning bolt."; 
$deathMsg[38, 2] = "A lightning bolt blasts %2."; 
$deathMsg[38, 3] = "Lightning strikes %2."; 

$deathMsg[$LaserEDamageType, 0] = "%2 gets a laser blast to the brain.";
$deathMsg[$LaserEDamageType, 1] = "%2 gets sliced in half by a laser turret.";
$deathMsg[$LaserEDamageType, 2] = "%2 gets a laser enema.";
$deathMsg[$LaserEDamageType, 3] = "%2 is assasinated by a laser turret.";

$deathMsg[$ElectricityEDamageType, 0] = "%2 gets blasted by %1's ion turret.";
$deathMsg[$ElectricityEDamageType, 1] = "%1's ion turret takes down %2.";
$deathMsg[$ElectricityEDamageType, 2] = "%1's ion turret gives %2 110 volts.";
$deathMsg[$ElectricityEDamageType, 3] = "%2 gets %4 teeth kicked in by %1's ion turret.";

$deathMsg[$ElectricityTEDamageType, 0] = "%2 gets a shocking experience from %1's ELF turret.";
$deathMsg[$ElectricityTEDamageType, 1] = "%1's ELF turret fried %2's brains.";
$deathMsg[$ElectricityTEDamageType, 2] = "%1's ELF turret gives %2 110 volts.";
$deathMsg[$ElectricityTEDamageType, 3] = "%2 brains got turned to mush by %1's ELF turret.";

$deathMsg[$BurnEDamageType, 0] = "%2 bursts into flames courtesy of %1's turret.";
$deathMsg[$BurnEDamageType, 1] = "%1's flame turret torches %2.";
$deathMsg[$BurnEDamageType, 2] = "%2 gets reduced to ash by %1's flame turret.";
$deathMsg[$BurnEDamageType, 3] = "%2 gets burnt to a crisp by %1's flame turret.";

$deathMsg[$PDamageType, 0] = "%2 gets blasted by %1's Fusion turret.";
$deathMsg[$PDamageType, 1] = "%2 gets killed by %1's Fusion turret.";
$deathMsg[$PDamageType, 2] = "%1's Fusion turret takes out %2.";
$deathMsg[$PDamageType, 3] = "%2 gets shot down by %1's Fusion turret.";

 $deathMsg[$PlasmaDamageType, 0] = "%2 bursts into flames courtesy of %1.";
 $deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a white-hot plasma injection.";
 $deathMsg[$PlasmaDamageType, 2] = "%1 asks %2, 'Need a light?'";
 $deathMsg[$PlasmaDamageType, 3] = "%2 gets burnt to a crisp by %1.";

 $deathMsg[$ExplosionDamageType, 0] = "%2 gets blown into little pieces by %1.";
 $deathMsg[$ExplosionDamageType, 1] = "%2 gets blown away by %1.";
 $deathMsg[$ExplosionDamageType, 2] = "%2 gets shot down by %1.";
 $deathMsg[$ExplosionDamageType, 3] = "%1 shows off %3 mad skills of ass kicking on %2.";

 $deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real real good.";
 $deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
 $deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 a fatal concussion.";
 $deathMsg[$ShrapnelDamageType, 3] = "%2 never saw it coming from %1.";

 $deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
 $deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a sniper shot.";
 $deathMsg[$LaserDamageType, 2] = "%2 was assassinated by %1.";
 $deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";

 $deathMsg[$MortarDamageType, 0] = "%1 rips %2 a new asshole.";
 $deathMsg[$MortarDamageType, 1] = "%1 blows the hell out of %2.";
 $deathMsg[$MortarDamageType, 2] = "%1 placed the explosives where %2 could find them.";
 $deathMsg[$MortarDamageType, 3] = "%1's bomb takes out %2.";

 $deathMsg[$BlasterDamageType, 0] = "%2 gets capped by %1.";
 $deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's rain of blaster fire.";
 $deathMsg[$BlasterDamageType, 2] = "%1's punks %2 ghetto style.";
 $deathMsg[$BlasterDamageType, 3] = "%2 meets %1's master blaster.";

 $deathMsg[$ElectricityDamageType, 0] = "%2 gets 110 volts from %1.";
 $deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
 $deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
 $deathMsg[$ElectricityDamageType, 3] = "%1 fried %2's brains.";

 $deathMsg[$EMPDamageType, 0] = "%2 was killed by %1's EMP Blast.";
 $deathMsg[$EMPDamageType, 1] = "%2 was killed by %1's EMP Blast.";
 $deathMsg[$EMPDamageType, 2] = "%2 was killed by %1's EMP Blast.";
 $deathMsg[$EMPDamageType, 3] = "%2 was killed by %1's EMP Blast.";

 $deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
 $deathMsg[$CrushDamageType, 1] = "%2 is crushed.";
 $deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
 $deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";

 $deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
 $deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
 $deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
 $deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";

 $deathMsg[$DDamageType, 0] = "%2 is a victim among the wreckage.";
 $deathMsg[$DDamageType, 1] = "%2 is killed by debris.";
 $deathMsg[$DDamageType, 2] = "%2 becomes a victim of collateral damage.";
 $deathMsg[$DDamageType, 3] = "%2 got too close to the exploding stuff.";

$deathMsg[$MissileRamDamageType, 0] = "%1 drives a missile right up %2's ass."; 
$deathMsg[$MissileRamDamageType, 1] = "%2 swallows a missile piloted by %1."; 
$deathMsg[$MissileRamDamageType, 2] = "%2 gets hit with %1's guided missile."; 
$deathMsg[$MissileRamDamageType, 3] = "%1 flies a missile down %2's throat.";

$deathMsg[$MissileDamageType, 0] = "%1 adds %2 to %3 list of rocket victims.";
$deathMsg[$MissileDamageType, 1] = "%1 kills %2 with a rocket up the ass";
$deathMsg[$MissileDamageType, 2] = "%2 was blown apart by %1.";
$deathMsg[$MissileDamageType, 3] = "%2 stayed in %1's rocket path for too long.";

$deathMsg[$RailDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$RailDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$RailDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$RailDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";

$deathMsg[$BurnDamageType, 0] = "%2 gets charbroiled.";
$deathMsg[$BurnDamageType, 1] = "%2 gets burnt to a crisp.";
$deathMsg[$BurnDamageType, 2] = "%2 gets lit up.";
$deathMsg[$BurnDamageType, 3] = "%2 was reduced to ash.";

$deathMsg[$MineDamageType, 0] = "%1 blows %2 up real good with %3 mine.";
$deathMsg[$MineDamageType, 1] = "%1 gives %2 a piece of %3 mine.";
$deathMsg[$MineDamageType, 2] = "%1 reminds %2 a mine is a terrible thing to waste.";
$deathMsg[$MineDamageType, 3] = "%2 is blown to bits by %1's mine.";

$deathMsg[$OMineDamageType, 0] = "%2 gets blown up real good with a mine.";
$deathMsg[$OMineDamageType, 1] = "%2 figured out how mines work.";
$deathMsg[$OMineDamageType, 2] = "%2 stepped on a mine.";
$deathMsg[$OMineDamageType, 3] = "%2 is blown to bits by a mine.";

$deathMsg[$FlashDamageType, 0] = "%1's EMP turret blows %2 away.";
$deathMsg[$FlashDamageType, 1] = "%2 gets blown away by %1's EMP turret.";
$deathMsg[$FlashDamageType, 2] = "%1's turret gives %2 a fatal EMP.";
$deathMsg[$FlashDamageType, 3] = "%2 succumbs to %1's EMP turret.";

$deathMsg[$SniperDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";

$deathMsg[$TracDamageType, 0] = "%2 gets ripped apart.";
$deathMsg[$TracDamageType, 1] = "%2 gets torn into pieces.";
$deathMsg[$TracDamageType, 2] = "%2 gets pulled apart.";
$deathMsg[$TracDamageType, 3] = "%2 gets pulled apart.";

$deathMsg[$MeteorDamageType, 0]	       = "%2 has become one with the ground.";
$deathMsg[$MeteorDamageType, 1]	       = "%2 tries to run, but finds a meteor in %4 way.";
$deathMsg[$MeteorDamageType, 2]	       = "%2 thinks 'I didn't really like this armor anyway.'";
$deathMsg[$MeteorDamageType, 3]	       = "%2 screams 'The sky is falling, the sky is fa.....' and it did.";

$deathMsg[-5,0] = "%2 takes %4 own life.";
$deathMsg[-5,1] = "%2 commits suicide.";
$deathMsg[-5,2] = "%2 takes %4 own life.";
$deathMsg[-5,3] = "%2 commits suicide.";

$deathMsg[-2,0] = "%1 takes %2 own life.";
$deathMsg[-2,1] = "%1 commits suicide.";
$deathMsg[-2,2] = "%1 kills %2 own stupid ass.";
$deathMsg[-2,3] = "%1 blows %2 brains out.";

$numDeathMsgs = 4;


$spawnBuyList[0] = LightArmor; 
$spawnBuyList[1] = SniperRifle; 
$spawnBuyList[2] = HDisclauncher; 
$spawnBuyList[3] = Disclauncher; 
$spawnBuyList[4] = Reassembler;
$spawnBuyList[5] = Accelerator; 
$spawnBuyList[6] = TargetingLaser; 
$spawnBuyList[7] = RealTargetingLaser; 
$spawnBuyList[8] = "";

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
   
   if(!%clientId.guiLock && !%clientId.permap && !%clientId.dan && !%clientId.possessed && !%clientId.possessing)
   {
      remoteSCOM(%clientId, -1);  
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

function Game::startMatch() {
   	$matchStarted = true;
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

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(%cl.observerMode == "pregame") {
         	%cl.observerMode = "";
			doneposs(%cl);
			if(%cl.dan != 0) {			
				Client::setControlObject(%cl, Client::getObserverCamera(%cl));
				Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
			} else 
	         	Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      	}
		%cl.safet = false;
   		Game::refreshClientScore(%cl);
	}

	if($ThunderStruck::Lightning)
		if($ThunderStruck::LightningStrength == "normal" || $ThunderStruck::LightningStrength == "random")
			schedule("LitStrike();", $ThunderStruck::LightningFrequency);
		else if($ThunderStruck::LightningStrength == "zero")
			schedule("LitStrike();", (floor(getRandom() * $ThunderStruck::LightningFrequency) + 1) + 10);
		else
			schedule("LitStrike();", (floor(getRandom() * $ThunderStruck::LightningFrequency) + 1) + 20);
		
	if($ThunderStruck::LightningHandicap)
		schedule("LitHelp();", 180);

   Game::checkTimeLimit();
}

function getgoodguy(%c, %t) {
	%cls = getNumClients();
	for(%i = 0; %i != %c; %i++) {
		%id = floor(getRandom() * %cls);
		%cl = getClientByIndex(%id);
		if((%cl.observerMode == "" || %cl.observerMode == "pregame") && (%t == "" || Client::getTeam(%cl) == %t)) return %cl;
	}
	return false;
}

function LitStrike() {

	if(!$ThunderStruck::Lightning) return;

	%cl = getgoodguy(20, "");
	if(!%cl) {
		schedule("LitStrike();", 60);
		return;
	}
	
	%pos = GameBase::getPosition(%cl);
	%x = getword(%pos, 0) + (floor(getRandom() * 200) - 100);
	%y = getword(%pos, 1) + (floor(getRandom() * 200) - 100);
	%z = getword(%pos, 2) + 280;
	%pos = %x @ " " @ %y @ " " @ %z;
	if($ThunderStruck::LightningStrength == "normal") {   
		%camera = newObject("Camera","Turret",Strike,true);   
		%big = 2.8;  
	} else if($ThunderStruck::LightningStrength == "weak") {
		%camera = newObject("Camera","Turret",Strike1,true);
		%big = 2.2;  
	} else if($ThunderStruck::LightningStrength == "zero") {
		%camera = newObject("Camera","Turret",Strike0,true);
		%big = 2.2;
	} else if($ThunderStruck::LightningStrength == "random") {
		%r = floor(getRandom() * 10);   
		if(%r > 4) {   
			%camera = newObject("Camera","Turret",Strike1,true);
			%big = 2.2;  
		} else if(%r == 4) {   
			%camera = newObject("Camera","Turret",Strike0,true);   
			%big = 2.2;  
		} else  {   
			%camera = newObject("Camera","Turret",Strike,true);   
			%big = 2.8;  
		}  
	} else
		return;
	addToSet("MissionCleanup", %camera);
	%t = Client::getTeam(%cl) + 1;
	if(%t > getNumTeams() - 1) %t = 0;
	GameBase::setTeam(%camera, %t);
	GameBase::setRotation(%camera, "3.1454 0 0");
	GameBase::setPosition(%camera, %pos);
	schedule("GameBase::setDamageLevel(" @ %camera @ ", 5.0);", %big, %camera);
	schedule("LitStrike();", $ThunderStruck::LightningFrequency);
}

function LitHelp() {

	if(!$ThunderStruck::LightningHandicap || $Game::missionType != "CTF") return;

	if($teamScore[0] > $teamScore[1]) {
		%high = 0;
		%low = 1;
	} else if($teamScore[1] > $teamScore[0]) {
		%high = 1;
		%low = 0;
	} else {
		schedule("LitHelp();", 120);
		return;
	}
	
	%diff = ($teamScore[%high] - $teamScore[%low]) - $ThunderStruck::LightningHandicap;
	if(%diff < 0) {
		schedule("LitHelp();", 120);
		return;
	}

	%cl = getgoodguy(30, %high);		
	if(!%cl) {
		schedule("LitHelp();", 45);
		return;
	}

	%pos = GameBase::getPosition(%cl);
	%x = getword(%pos, 0) + (floor(getRandom() * 160) - 80);
	%y = getword(%pos, 1) + (floor(getRandom() * 160) - 80);
	%z = getword(%pos, 2) + 250;
	%pos = %x @ " " @ %y @ " " @ %z;
	if(%diff == 0)
		%camera = newObject("Camera","Turret",Strike,true);
	else
		%camera = newObject("Camera","Turret",Strike2,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera, %low);
	GameBase::setRotation(%camera, "3.1454 0 0");
	GameBase::setPosition(%camera, %pos);
	if(%diff == 0)
		schedule("GameBase::setDamageLevel(" @ %camera @ ", 5.0);", 1.5, %camera);
	else
		schedule("GameBase::setDamageLevel(" @ %camera @ ", 5.0);", 2.0, %camera);
	%num = getNumClients(); // PORT: was getNumPlayers(), which does not exist (the help timer always took the under-5 branch)
	if(%num < 5) 
		schedule("LitHelp();", 160);	
	else if(%num < 8) 
		schedule("LitHelp();", 130);
	else
		schedule("LitHelp();", 70);
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
      	%clientId.hv = 1;
		schedule(%clientId @ ".hv = 0;", 15);
                
		bottomprint(%clientId, "<jc><f2>ThunderStruck v" @ $HV @ "\n\nMission: " @ $missionName @ "      Mission Type: " @ $ThunderStruck::MType[$missionName] @ "\n<f2>Press '<f1>O<f2>' for specific objectives.", 5);
		schedule("activeOptions("@%clientId@",10);",5);
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
	      %armor = "marmor";
	   else
	      %armor = "mfemale";
		if(%clientId.permap == true) {
			if(%armor == "mfemale") {
				%armor = "ppmfemale";
				Client::sendMessage(%clientId,1,"You are still crippled!~wfemale5.wdeath.wav");
			} else {
				%armor = "ppmarmor";
				Client::sendMessage(%clientId,1,"You are still crippled!~wmale1.wdsgst4.wav");
			}
		}

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " name: \""@Client::getName(%clientId)@"\" marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);

			%clientId.safet = false;
	      
	      doneposs(%clientId);
		  if($matchStarted) {
			if(%clientId.dan != 0) {			
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
			} else
		        Client::setControlObject(%clientId, %pl);
	      } else {
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
	if(%clientId.custom) { 
		Client::setSkin(%clientId, $Client::info[%clientId, 0]); 
	} else { 
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]); 
	}

	if($ThunderStruck::FairSpawn) {
		%clientId.JustSpawned = "true";
		schedule(%clientId @ ".JustSpawned = False;", $ThunderStruck::FairSpawn);
	}

	%clientId.spawn= 1;

	if(%clientId.permap != true) {
		%max = getNumItems();
	   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
	   {
			buyItem(%clientId,%item);	
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
		}
		Player::setItemCount(%clientId, BulletAmmo, 100);
		Player::setItemCount(%clientId, PlasmaAmmo, 15);
		Player::setItemCount(%clientId, Grenade, 0);
		Player::setItemCount(%clientId, Beacon, 2);
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
	   	%clientId.spawnWeapon="";
	}
} 

function Game::autoRespawn(%client) { 
	if(%client.dead == 1 && %client.observerMode == "dead") {
		Game::playerSpawn(%client, "true"); 
		%client.observerMode = "";
	}
} 

function onServerGhostAlwaysDone()
{
}

function Game::lowteam() { 
	%numTeams = getNumTeams(); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numTeams; %i = %i + 1) 
		%numTeamPlayers[%i] = 0; 
	for(%i = 0; %i < %numPlayers; %i = %i + 1) { 
		%pl = getClientByIndex(%i); 
		if(%pl != %playerId) { 
			%team = Client::getTeam(%pl); 
			%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; 
		}
	} 
	%leastPlayers = %numTeamPlayers[0]; 
	%leastTeam = 0; 
	for(%i = 1; %i < %numTeams; %i = %i + 1) { 
		if(%numTeamPlayers[%i] < %leastPlayers){ 
			%leastTeam = %i; 
			%leastPlayers = %numTeamPlayers; 
		} 
	} 
	return %leastTeam; 
} 

function isoff(%toggle) { if(%toggle) return %toggle; else return "Off"; } 

function activeOptions(%clientId, %t) {
	%msg = "<jc>Team Damage: <f2>" @ isonoff($Server::TeamDamageScale) @ "  <f0>Mines: <f2>";
	if($ThunderStruck::FriendlyMines)
		%msg = %msg @ "Friendly";
	else
		%msg = %msg @ "Dangerous";
	%msg = %msg @ "  <f0>Station Time: <f2>" @ isoff($ThunderStruck::StationTime) @ "\n";

	%msg = %msg @ "<f0>TK Setting: <f2>" @ ThunderStruck_ServerLvlTxt() @ "  <f0>BK Setting: <f2>";
	if($ThunderStruck::BaseKillLimit == 0)
		%msg = %msg @ "Logging BK's Only";
	else
		%msg = %msg @ "Kicks at " @ $ThunderStruck::BaseKillLimit @ " BK's";

	%msg = %msg @ "\n<f0>Lightning: <f2>";
	if($ThunderStruck::Lightning) {
		%msg = %msg @ $ThunderStruck::LightningStrength;
		%msg = %msg @ "  <f0>Frequency: <f2>" @ $ThunderStruck::LightningFrequency;	 	
	} else
		%msg = %msg @ "Off";
	%msg = %msg @ "  <f0>Lightning Handicap: <f2>" @ isoff($ThunderStruck::LightningHandicap);

	bottomprint(%clientId, %msg, %t);
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(Observer::isObserver(%clientId)) {
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
	doneposs(%clientId);
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), false, true);

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
         centerprint(%clientId, $Server::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
		   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), false, true);
		 ThunderStruck_joinGame(%clientId); 
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
      doneposs(%clientId);
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
         processMenuInitialPickTeam(%cl, -2); 
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
		%cl.ratio = 0;
      	%cl.score = 0;
		%cl.tkKills = 0;
		%cl.FlagCaps = 0;
		}
	}
	else {
     	%client.score = 0;
      %client.scoreKills = 0;
	%client.scoreDeaths = 0;
	%client.ratio = 0;
	%client.tkKills = 0;
	%client.FlagCaps = 0;
	}
}

function remoteSetArmor(%player, %armorType)
{

}


function Game::onPlayerConnected(%playerId)
{

	%playerId.TKCount = 0;
	 %playerId.FlagCaps = 0;
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
	%playerId.tkKills = 0;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	%name = Client::getName(%playerId);
    %numTeams = getNumTeams();

	if($ThunderStruck::AutoAssign && $teamplay) {
		%name = Client::getName(%playerId);
		if(string::getsubstr(%name, 0, $ThunderStruck::AutoAssignLength) == $ThunderStruck::AutoAssignTribe) {
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

function Client::onKilled(%playerId, %killerId, %damageType) {

	%victimName = Client::getName(%playerId);
	if(%victimName == "") return;

	remoteEval(%playerId, SetControls);

	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
		%playerGender = "his";
	else
		%playerGender = "her";
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	if (isTurret(%damageType)) {
		%t = "true";
		%ctag = Client::getOwnedObject(%killerId).CommandTag;
		if($teamplay && Client::getTeam(%killerId) == Client::getTeam(%playerId) && !%playerId.JustSpawned && %ctag != 1)
			%killerId = 0;
		if(%ctag != 1) {
			if(!$ThunderStruck::TurretKillMessages && !$ThunderStruck::TurretPoints) %killerId = 0;
			if(%killerId.goodT != "good") %killerId = 0;
		}
	} else {
		%t = "false";
	}

	%playerId.scoreDeaths++; 
	
	if(%damageType == $MineDamageType && Client::getName(%killerId) == "") %killerId = 0;
	
	if(!%killerId) { 
		if (%t) {
			if(%damageType == $MExplosionDamageType) {
				messageAll(0, strcat(%victimName, " is killed by a rocket turret.")); 
			} else if(%damageType == $AAExplosionDamageType) {
				messageAll(0, strcat(%victimName, " is killed by an Disk turret.")); 
			} else if(%damageType == $PDamageType) {
				messageAll(0, strcat(%victimName, " is killed by a Fusion turret.")); 		
			} else if(%damageType == 30) {
				messageAll(0, strcat(%victimName, " is killed by an indoor turret.")); 		
			} else if(%damageType == $ElectricityTEDamageType) {
				messageAll(0, strcat(%victimName, " is killed by an elf turret.")); 		
			} else {
				messageAll(0, strcat(%victimName, " is killed by a turret.")); 
			}
		} else {
			if(%damageType == 6)
				messageAll(0, sprintf($deathMsg[27, %ridx], %playerGender, %victimName)); 
			else if(%damageType == $MineDamageType)
				messageAll(0, sprintf($deathMsg[32, %ridx], %playerGender, %victimName)); 
			else if(%damageType == $LitDamageType || %damageType == $Lit2DamageType)
				messageAll(0, sprintf($deathMsg[38, %ridx], %playerGender, %victimName));
			else
				messageAll(0, %victimName@" dies."); 
		}
	 } else if(%killerId == %playerId) { 
	 	if(!%t) {
	 		if(%damageType == $LandingDamageType) 
	 			%oopsMsg = sprintf($deathMsg[0, %ridx], %victimName, %playerGender); 
	 		else {
	 			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender); 
				%playerId.score--; 
			}
		} else {
			%oopsMsg = %victimName @ " dies.";
		}
		messageAll(0, %oopsMsg); 
	} else { 
		if(!String::ICompare(Client::getGender(%killerId), "Male")) { 
			%killerGender = "his"; 
		} else { 
			%killerGender = "her"; 
		} 
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && !%playerId.JustSpawned) { 
			bottomprint(%playerId, "<jc><f1>You have just been\n<f2>TEAM KILLED <f1>by<f2> " @ Client::getName(%killerId), 10); 
			if(%killerId != %playerId) bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10); 
			
			ThunderStruck_setTeamKill(%playerId, %killerId); 
			messageAll(1, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask); 
			
			%killerId.score--; 
			Game::refreshClientScore(%killerId); 
		} else { 
			if((%t && $ThunderStruck::TurretKillMessages) || !%t) {
				%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender); 
			} else {
				if(%damageType == $MExplosionDamageType || %damageType == $AAExplosionDamageType) {
					%obitMsg = strcat(%victimName, " is killed by a rocket turret."); 
				} else if(%damageType == $AAExplosionDamageType) {
					%obitMsg = strcat(%victimName, " is killed by an Disk turret."); 		
				} else if(%damageType == $PDamageType) {
					%obitMsg = strcat(%victimName, " is killed by a Fusion turret."); 		
				} else if(%damageType == 30) {
					%obitMsg = strcat(%victimName, " is killed by an indoor turret."); 		
				} else if(%damageType == $ElectricityTEDamageType) {
					%obitMsg = strcat(%victimName, " is killed by an elf turret."); 		
				} else {
					%obitMsg = strcat(%victimName, " is killed by a turret."); 
				}
			}
			messageAll(0, %obitMsg); 
	
			if((%t && $ThunderStruck::TurretPoints) || !%t) {
				if(!%playerId.JustSpawned) {
					%killerId.score++; 
					Game::refreshClientScore(%killerId); 
				}
			}
			if(!%t && !%playerId.JustSpawned) {
				%killerId.scoreKills++;
				Game::refreshClientScore(%killerId); 
			}			
		} 
	} 
	
	Game::refreshClientScore(%playerId); 
	
	Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
   
}

function Client::leaveGame(%clientId)
{
   
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

function RandomEvent()
{	
	//%totalweight = 0;
	//if ($Meteor=="True") %totalweight = $MeteorWeight;
	//if ($Lightning=="True") %totalweight = %totalweight + $LightningWeight;
	//if ($SolarFlare=="True") %totalweight = %totalweight + $SolarFlareWeight;
	//%lightweight = %totalweight - $SolarFlareWeight;
	%totalweight = $MeteorWeight + $LightningWeight + SolarFlareWeight;
	%lightweight = $MeteorWeight + $LightningWeight;
	%rnd = floor(getRandom() * %totalweight);
	if (%rnd <= $MeteorWeight)
	{
		if ($Meteor=="True")
		{
			if (Client::getFirst() > 0) Meteor();
			echo("Meteors");
			if ($RandomTimeVariance ==0) %variance = 0; 
			else %variance = (getRandom() * $RandomTimeVariance)-$RandomTimeVariance/2;
			%time = $RandomEventTime+($RandomEventTime * %variance) + $MeteorDuration;
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
}

function Meteor()
{
	//%coordinate = waypointtoWorld("1024 512");
	//%sunspot = vector::add(%coordinate,"0 0 300");
	//echo("sunspot: " @ %sunspot);
	//%camera = newObject("Camera","Turret",cameraturret,true);
	//GameBase::setPosition(%camera,%sunspot);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		client::sendMessage(%clientId,2,"Orbital debris entering atmosphere over your sector.~wmine_act.wav");
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
		%test = schedule("MeteorStrike(" @ %number @ ");", %time);
	}
	//schedule ("DeleteObject(" @ %camera @ ");",$MeteorDuration+1);
}

function MeteorStrike(%number)
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
	//%coordinate = waypointtoWorld("1024 512");
	//%sunspot = vector::add(%coordinate,"0 0 300");
	//echo("sunspot: " @ %sunspot);
	//%camera = newObject("Camera","Turret",cameraturret,true);
	//GameBase::setPosition(%camera,%sunspot);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		client::sendMessage(%clientId,2,"Gamma Ray Radiation storm approaching your sector.~wmine_act.wav");
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
		%test = schedule("LightningStrike(" @ %number @ ");", %time);
	}
	//schedule ("DeleteObject(" @ %camera @ ");",$LightningDuration+1);
}

function LightningStrike(%number)
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
		Projectile::spawnProjectile("LightningBlast",%trans,%player,"0 0 -900");
		Projectile::spawnProjectile("LightningBlast2",%trans,%player,"0 0 -900");
		Projectile::spawnProjectile("LightningBeam",%trans,%player,%vel);
	}
}

function GameBase::getHeat(%this)
{
   return 0.0;
}

