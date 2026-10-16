exec("comchat.cs");
//exec("renegadez.cs");
if($RandomEvents = "False")
	$Reneg::WCdisable = 1;
$BaseAddons = "true";
$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$DefaultTeamEnergy = "Infinite";
$TeamEnergy[-1] = $DefaultTeamEnergy;
$TeamEnergy[0] = $DefaultTeamEnergy;
$TeamEnergy[1] = $DefaultTeamEnergy;
$TeamEnergy[2] = $DefaultTeamEnergy;
$TeamEnergy[3] = $DefaultTeamEnergy;
$TeamEnergy[4] = $DefaultTeamEnergy;
$TeamEnergy[5] = $DefaultTeamEnergy;
$TeamEnergy[6] = $DefaultTeamEnergy;
$TeamEnergy[7] = $DefaultTeamEnergy;
$TeamEnergyCheat = 0;
$MaxTeamEnergy = 700000;
$incTeamEnergy = 700;
$secTeamEnergy = 30;
$ItemRespawnTime = 30;
$RemoteAmmoEnergy = 3500;
$RemoteInvEnergy = 5000;
$TeammateSpending = -4000;
$WarnEnergyLow = 4000;
$InitialPlayerEnergy = 5000;
$MaxNumTurretsInBox = 2;
$TurretBoxMaxLength = 50;
$TurretBoxMaxWidth = 50;
$TurretBoxMaxHeight = 10;
$TurretBoxMinLength = 10;
$TurretBoxMinWidth = 10;
$TurretBoxMinHeight = 10;
$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;
$MineObjectType = 1 << 26;
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;
$StaticObjectType = 1 << 23;
$ItemObjectType = 1 << 21;
$ServerCheats = 0;
$TestCheats = 0;
$AutoRespawn = 0;
$deathMsg[$LandingDamageType, 0] = "%2 falls to %4 death.";
$deathMsg[$LandingDamageType, 1] = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2] = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3] = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0] = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1] = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2] = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3] = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0] = "%1 gave %2 a hole in %4 head that wasn't there before.";
$deathMsg[$BulletDamageType, 1] = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2] = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3] = "%1 guns down %2.";
$deathMsg[$EnergyDamageType, 0] = "%2 dies of poison.";
$deathMsg[$EnergyDamageType, 1] = "%2 gets a lethal injection.";
$deathMsg[$EnergyDamageType, 2] = "%2 falls victim to a deadly virus.";
$deathMsg[$EnergyDamageType, 3] = "%2 could not find the vaccine in time.";
$deathMsg[$PlasmaDamageType, 0] = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2] = "%1 reduces %2, into a warm camp fire'";
$deathMsg[$PlasmaDamageType, 3] = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0] = "%1 sends %2 home in a small cardboard box";
$deathMsg[$ExplosionDamageType, 1] = "%1 shows %2 the nature of an out of body experience";
$deathMsg[$ExplosionDamageType, 2] = "%1 shows off %3 mad skills of body dismemberment on %2.";
$deathMsg[$ExplosionDamageType, 3] = "%2 gets reduced into small pieces by %1.";
$deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2] = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0] = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1] = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2] = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3] = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0] = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2] = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3] = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1] = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0] = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1] = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2] = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3] = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0] = "%2 found some explosives that %1 left behind";
$deathMsg[$MineDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$FlashDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$FlashDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$FlashDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$FlashDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$SniperDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[-2,0] = "%1 has an attack of the dumbass";
$deathMsg[-2,1] = "%1 takes %2 own life.";
$deathMsg[-2,2] = "%1 kills %2 own dumb self.";
$deathMsg[-2,3] = "%1 decides to see what the afterlife is like.";
//Weather Death Messages
$deathMsg[$MeteorDamageType, 0]	       = "%2 has become one with the ground.";
$deathMsg[$MeteorDamageType, 1]	       = "%2 tries to run, but finds a meteor in %4 way.";
$deathMsg[$MeteorDamageType, 2]	       = "%2 thinks 'I didn't really like this armor anyway.'";
$deathMsg[$MeteorDamageType, 3]	       = "%2 screams 'The sky is falling, the sky is fa.....' and it did.";
$deathMsg[$SolarFlareDamageType, 0]	       = "%2 forgot to wear %4 sunblock.";
$deathMsg[$SolarFlareDamageType, 1]	       = "%2 stares at the bright light.";
$deathMsg[$SolarFlareDamageType, 2]	       = "%2 thinks 'Now I know why eveyone says not to look directly at the sun.'";
$deathMsg[$SolarFlareDamageType, 3]	       = "%2 falls asleep in the sun.";
$deathMsg[$LightningDamageType, 0]	       = "Just call %2 sparky.";
$deathMsg[$LightningDamageType, 1]	       = "%2 was struck down dead.";
$deathMsg[$LightningDamageType, 2]	       = "%2 didn't survive the lightning.";
$deathMsg[$LightningDamageType, 3]	       = "%2 picked the wrong tree to hide under.";
$numDeathMsgs = 4;
$spawnBuyList[0] = MediumArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Grenade;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = MineAmmo;
$spawnBuyList[9] = EnergyPack;
$spawnBuyList[10] = "";
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
    if(!%clientId.guiLock)
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
    if (Client::getGuiMode(%clientId) != $GuiModeInventory && $matchStarted)
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
        %set
        = newObject("set",SimSet);
        %obj = Group::getObject(%group, %i);
        if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
        {
            deleteObject(%set
                        );
            return %obj;
        }
        if(%i == %count - 1)
        {
            %i = -1;
            %value = %spawnIdx;
        }
        deleteObject(%set
                    );
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
    //Randomevent stuff
   //$RandomEvents="True";
   //$RandomEventTime=30;
   //if ($RandomEvents=="True")
  // {
       	echo("Initializing random events every ", $RandomEventTime, " seconds.");
       	schedule("RandomEvent();", $RandomEventTime);
		schedule("auto(3);", 30);
  // }
    %numTeams = getNumTeams();
    for(%i = 0; %i < %numTeams; %i = %i + 1)
    {
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
function Game::playerSpawn(%clientId, %respawn) {
if(Client::getTeam(%clientId) == -1) {
  centerprint(%clientId, "<f1><jc>Quit Trying to Cheat You Idiot!", 20);
  return false;
}

    if(!$ghosting)
        return false;
    %player = Client::getOwnedObject(%clientId);
    Player::setSensorSupression(%player,0);
    %player.driver = "";
    %player.shieldStrength = 0;
    $shieldTime[%clientId] = 0;
    $cloakTime[%clientId] = 0;
    $StimTime[%clientId] = 0;
    %clientId.isbeingkicked = false;
    %clientId.isSpy = false;
    %clientId.freeze = "";
    Client::clearItemShopping(%clientId);
    %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
    {
        LoadCharacter(%clientId);
        bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 10);
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
            %armor = "marmor";
        else
            %armor = "mfemale";
        %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
        if($ConOutput == 1)
            echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
        if(%pl != -1)
        {
            %clientId.observerMode = "";
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
    %spawnBuyList[ScoutArmor, 0] = LaserRifle;
    %spawnBuyList[ScoutArmor, 1] = Disclauncher;
    %spawnBuyList[ScoutArmor, 2] = GrenadeLauncher;
    %spawnBuyList[ScoutArmor, 3] = EnergyPack;
    %spawnBuyList[ScoutArmor, 4] = "";
    %spawnBuyList[SpArmor, 0] = PlasmaGun;
    %spawnBuyList[SpArmor, 1] = Silencer;
    %spawnBuyList[SpArmor, 2] = Disclauncher;
    %spawnBuyList[SpArmor, 3] = TargetingLaser;
    %spawnBuyList[SpArmor, 4] = Ammopack;
    %spawnBuyList[SpArmor, 5] = "";
	%spawnBuyList[SpArmor1, 0] = PlasmaGun;
    %spawnBuyList[SpArmor1, 1] = Silencer;
    %spawnBuyList[SpArmor1, 2] = Disclauncher;
    %spawnBuyList[SpArmor1, 3] = TargetingLaser;
    %spawnBuyList[SpArmor1, 4] = Ammopack;
    %spawnBuyList[SpArmor1, 5] = "";
    %spawnBuyList[LightArmor, 0] = PlasmaGun;
    %spawnBuyList[LightArmor, 1] = Disclauncher;
    %spawnBuyList[LightArmor, 2] = SniperRifle;
    %spawnBuyList[LightArmor, 3] = MineAmmo;
    %spawnBuyList[LightArmor, 4] = EnergyPack;
    %spawnBuyList[LightArmor, 5] = "";
	%spawnBuyList[LightArmor1, 0] = PlasmaGun;
    %spawnBuyList[LightArmor1, 1] = Disclauncher;
    %spawnBuyList[LightArmor1, 2] = SniperRifle;
    %spawnBuyList[LightArmor1, 3] = MineAmmo;
    %spawnBuyList[LightArmor1, 4] = EnergyPack;
    %spawnBuyList[LightArmor1, 5] = "";
    %spawnBuyList[MediumArmor, 0] = Blaster;
    %spawnBuyList[MediumArmor, 1] = Chaingun;
    %spawnBuyList[MediumArmor, 2] = Disclauncher;
    %spawnBuyList[MediumArmor, 3] = TargetingLaser;
    %spawnBuyList[MediumArmor, 4] = MineAmmo;
    %spawnBuyList[MediumArmor, 5] = EnergyPack;
    %spawnBuyList[MediumArmor, 6] = "";
    %spawnBuyList[BursterArmor, 0] = GrenadeLauncher;
    %spawnBuyList[BursterArmor, 1] = Mortar;
    %spawnBuyList[BursterArmor, 2] = RocketLauncher;
    %spawnBuyList[BursterArmor, 3] = PlasmaGun;
    %spawnBuyList[BursterArmor, 4] = TargetingLaser;
    %spawnBuyList[BursterArmor, 5] = AmmoPack;
    %spawnBuyList[BursterArmor, 6] = "";
    %spawnBuyList[BusterArmor, 0] = GrenadeLauncher;
    %spawnBuyList[BusterArmor, 1] = Mortar;
    %spawnBuyList[BusterArmor, 2] = RocketLauncher;
    %spawnBuyList[BusterArmor, 3] = PlasmaGun;
    %spawnBuyList[BusterArmor, 4] = TargetingLaser;
    %spawnBuyList[BusterArmor, 5] = AmmoPack;
    %spawnBuyList[BusterArmor, 6] = "";
    %spawnBuyList[EngArmor, 0] = Railgun;
    %spawnBuyList[EngArmor, 1] = Fixit;
    %spawnBuyList[EngArmor, 2] = PlasmaGun;
    %spawnBuyList[EngArmor, 3] = Disclauncher;
    %spawnBuyList[EngArmor, 4] = TargetingLaser;
    %spawnBuyList[EngArmor, 5] = AmmoPack;
    %spawnBuyList[EngArmor, 6] = "";
    %spawnBuyList[AlArmor, 0] = HyperB;
    %spawnBuyList[AlArmor, 1] = IonGun;
    %spawnBuyList[AlArmor, 2] = Omega;
    %spawnBuyList[AlArmor, 3] = TargetingLaser;
    %spawnBuyList[AlArmor, 4] = EnergyPack;
    %spawnBuyList[AlArmor, 5] = "";
    %spawnBuyList[DragArmor, 0] = GrenadeLauncher;
    %spawnBuyList[DragArmor, 1] = Mortar;
    %spawnBuyList[DragArmor, 2] = PlasmaGun;
    %spawnBuyList[DragArmor, 3] = Vulcan;
    %spawnBuyList[DragArmor, 4] = RocketLauncher;
    %spawnBuyList[DragArmor, 5] = MineAmmo;
    %spawnBuyList[DragArmor, 6] = EnergyPack;
    %spawnBuyList[DragArmor, 7] = "";
    %spawnBuyList[HeavyArmor, 0] = PlasmaGun;
    %spawnBuyList[HeavyArmor, 1] = Mortar;
    %spawnBuyList[HeavyArmor, 2] = Disclauncher;
    %spawnBuyList[HeavyArmor, 3] = Vulcan;
    %spawnBuyList[HeavyArmor, 4] = Silencer;
    %spawnBuyList[HeavyArmor, 5] = RocketLauncher;
    %spawnBuyList[HeavyArmor, 6] = MineAmmo;
    %spawnBuyList[HeavyArmor, 7] = RepairPack;
    %spawnBuyList[HeavyArmor, 8] = "";
	%spawnBuyList[HeavyArmor1, 0] = PlasmaGun;
    %spawnBuyList[HeavyArmor1, 1] = Mortar;
    %spawnBuyList[HeavyArmor1, 2] = Disclauncher;
    %spawnBuyList[HeavyArmor1, 3] = Vulcan;
    %spawnBuyList[HeavyArmor1, 4] = Silencer;
    %spawnBuyList[HeavyArmor1, 5] = RocketLauncher;
    %spawnBuyList[HeavyArmor1, 6] = MineAmmo;
    %spawnBuyList[HeavyArmor1, 7] = RepairPack;
    %spawnBuyList[HeavyArmor1, 8] = "";
    if(%clientId.custom)
    {
        Client::setSkin(%clientId, $Client::info[%clientId, 0]);
    }
    else
    {
        Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
    }
    %clientId.spawn= 1;
    %max = getNumItems();
    if(%clientId.spawnarmor == "" || !$Reneg::SpawnClass)
        %clientId.spawnarmor = MediumArmor;
    buyItem(%clientID, %clientId.spawnarmor);
    for(%i = 0; (%item = %spawnBuyList[%clientId.spawnarmor, %i]) != ""; %i++)
    {
        buyItem(%clientId,%item);
        if(%item.className == Weapon)
            %clientId.spawnWeapon = %item;
    }
    buyItem(%clientID, RepairKit);
    buyItem(%clientID, Grenade);
    buyItem(%clientID, Beacon);
    if(%clientId.spawnarmor == "MediumArmor")
        Player::setItemCount(%clientId, Beacon,$Reneg::Beacon);
    %clientId.spawn = "";
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
{ }
function Game::lowteam()
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
function lowestTeam()
{
    %numTeams = getNumTeams();
    %numPlayers = getNumClients();
    for (%i = 0; %i < %numTeams; %i = %i + 1)
        %numTeamPlayers[%i] = 0;
    for (%i = 0; %i < %numPlayers; %i = %i + 1)
    {
        %pl = getClientByIndex(%i);
        if (%pl != %playerId)
        {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
        }
    }
    %leastPlayers = %numTeamPlayers[0];
    %leastTeam = 0;
    for (%i = 1; %i < %numTeams; %i = %i + 1)
    {
        if (%numTeamPlayers[%i] < %leastPlayers)
        {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
        }
    }
    if(%numTeams == 2 && %numPlayers > 1 && %numTeamPlayers[0] == %numTeamPlayers[1])
        return -1;
    else
        return %leastTeam;
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
    Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
    if ($Reneg::SpawnClass && %clientID.spawnArmor == "")
    {
        %clientId.observerMode = "pickingClass";
        Client::buildMenu(%clientId, "Pick a class:", "InitialPickClass");
        Client::addMenuItem(%clientId, "0Scout", 0);
        if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "1Infiltrator", 1);
		else
			Client::addMenuItem(%clientId, "1Spy", 1);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "2Assassin", 2);
		else
			Client::addMenuItem(%clientId, "2Sniper", 2);
        Client::addMenuItem(%clientId, "3Mercenary", 3);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "4Buster", 4);
		else
			Client::addMenuItem(%clientId, "4Burster", 4);
        Client::addMenuItem(%clientId, "5Engineer", 5);
        Client::addMenuItem(%clientId, "6Alien", 6);
        Client::addMenuItem(%clientId, "7more", "more");
        return;
    }
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
        if($Reneg::fairTeams )
        {
            %i = Game::lowteam();
            Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
        }
        else
        {
            for(%i = 0; %i < getNumTeams(); %i = %i + 1)
                Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
        }
        %clientId.justConnected = "";
    }
    else
    {
        Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
        if(%clientId.justConnected)
      {
	%clientId.justConnected = "";
	%clientId.observerMode = "justJoined";
	$chrCount[%clientId] = 0;
	$textPos[%clientId] = 80 - $scrollWidth;
	Game::ScrollMOTD(%clientId, "right");
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
	//sal - ANTI LLAMA
	if(!$Server::TournyMode)
	{
		%theLLama = Client::getName(%clientID);
		if(%theLLama == $llamaName)
		{
			schedule("KickinLLama(" @ %clientID @ ");", 10);
		}
	}
	//sal - END LLAMA
}
function processMenuInitialPickClass(%clientId, %opt)
{
    if (%opt == "more")
    {
        Client::buildMenu(%clientId, "Pick a Armor:", "InitialPickArmor");
        Client::addMenuItem(%clientId, "0Cyborg", 7);
		if($BaseAddons == "True")
			Client::addMenuItem(%clientId, "1Guardian", 8);
		else
			Client::addMenuItem(%clientId, "1Defender", 8);
        return;
    }
    processMenuInitialPickArmor(%clientId, %opt);
    return;
}
function processMenuInitialPickArmor(%clientId, %opt)
{
    if(!$BaseAddons)
	{
	if (%opt == 0)
        %clientID.spawnArmor = ScoutArmor;
    else if (%opt == 1)
        %clientID.spawnArmor = SpArmor1;
    else if (%opt == 2)
        %clientID.spawnArmor = LightArmor1;
    else if (%opt == 3)
        %clientID.spawnArmor = MediumArmor;
    else if (%opt == 4)
        %clientID.spawnArmor = BursterArmor;
    else if (%opt == 5)
        %clientID.spawnArmor = EngArmor;
    else if (%opt == 6)
        %clientID.spawnArmor = AlArmor;
    else if (%opt == 7)
        %clientID.spawnArmor = DragArmor;
    else if (%opt == 8)
        %clientID.spawnArmor = HeavyArmor1;
    else
        %clientID.spawnArmor = ScoutArmor;
	}
	if($BaseAddons)
	{
		if (%opt == 0)
        %clientID.spawnArmor = ScoutArmor;
    else if (%opt == 1)
        %clientID.spawnArmor = SpArmor;
    else if (%opt == 2)
        %clientID.spawnArmor = LightArmor;
    else if (%opt == 3)
        %clientID.spawnArmor = MediumArmor;
    else if (%opt == 4)
        %clientID.spawnArmor = BusterArmor;
    else if (%opt == 5)
        %clientID.spawnArmor = EngArmor;
    else if (%opt == 6)
        %clientID.spawnArmor = AlArmor;
    else if (%opt == 7)
        %clientID.spawnArmor = DragArmor;
    else if (%opt == 8)
        %clientID.spawnArmor = HeavyArmor;
    else
        %clientID.spawnArmor = ScoutArmor;
	}
    Game::initialMissionDrop(%clientId);
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
            %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
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
    if(%client == "")
    {
        for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
        {
            %cl.scoreKills = 0;
            %cl.scoreDeaths = 0;
            %cl.ratio = 0;
            %cl.score = 0;
        }
    }
    else
    {
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
            if( (%numTeamPlayers[%i] < %leastPlayers) || ( (%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam] ) ))
            {
                %leastTeam = %i;
                %leastPlayers = %numTeamPlayers;
            }
        }
        GameBase::setTeam(%playerId, %leastTeam);
        if($ConOutput == 1)
            echo(Client::getName(%playerId) @ " was automatically assigned to team " @ %leastTeam);
    }
    else
    {
        GameBase::setTeam(%playerId, 0);
    }
}
function Game::setRandomTeam()
{
	centerprintall ("<jc>Randomly Assigning Teams - Occurs Every " @ $Reneg::TeamSwap @ " Missions.",13);
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	echo ("*********************** BEGINING TEAM ASSIGNMENT");
	
	if (!%numPlayers)
	{
		if ($debug) echo ("ADMINMSG **** No Players In Game Not Assigning Teams");
		return;
	}

	echo ("**** Numbers Of Players " @ %numPlayers);
	
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		%player[%i] = %pl;
		gamebase::setteam(%pl, -1);
		echo ("**** Clearing Player Teams " @ %pl);
	}

	%assigned = 0;
	
	for(%k = 0; AllOnTeam() || (%assigned < %numplayers); %k++)
	{
		if (%k > 2000)
		{	
			echo ("**** Could Not Assign All Players In Given Time - Breaking Loop.");	
			break;
		}
		
		%rnd = floor(getRandom() * (%numPlayers) );
		%playerId = %player[%rnd];
		
		if (gamebase::getteam(%playerId) == -1 && (%playerId.observerMode != "observerOrbit" && %playerId.observerMode != "observerFly"))
		{
			Game::assignClientTeam(%playerId);
			%name = Client::getName(%playerId);
			echo ("**** Player <" @ %playerId @ "> " @ %name @ "  Assigned To Team " @ gamebase::getteam(%playerId));
			echo ("**** Observermode " @ %playerId.observermode);
			%assigned++;
		}
	}
	echo ("***********************");
	echo ("**** Players Assigned To Teams = " @ %assigned @ " out of " @ %numplayers);
	echo ("*********************** DONE WITH TEAM ASSIGNMENT");
}
function AllOnTeam()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if (gamebase::getteam(%pl) == "-1"){return true;}
	}
	echo ("**** All Players Have Been Assigned");
	return false;
}
function Client::onKilled(%playerId, %killerId, %damageType)
{
    if($ConOutput != 1)
        echo(Client::getName(%killerId) @ " " @ %killerId @ " *Killed* " @ Client::getName(%playerId) @ " " @ %playerId @ " " @ %damageType);
    else
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
        else
			messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);

        %playerId.scoreDeaths++;
    }
    else if(%killerId == %playerId)
    {
        %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
        messageAll(0, %oopsMsg, $DeathMessageMask);
        %playerId.scoreDeaths++;
        %playerId.score--;
        if($Reneg::Cash == "true")
			%playerId.cash -= 5;
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
                messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
            else
                messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
            %killerId.scoreDeaths++;
            %killerId.score--;
           if($Reneg::Cash == "true")
		%killerId.cash -= 10;
            Game::refreshClientScore(%killerId);
            if ($tkOverride != 1)
                Insomniax_setTeamKill(%playerId, %killerId);
        }
        else
        {
            %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);
            messageAll(0, %obitMsg, $DeathMessageMask);
            %killerId.scoreKills++;
            %playerId.scoreDeaths++;
            %killerId.score++;
            %playerarmor = Player::getArmor(%killerId);
			%armor = $ArmorName[%playerarmor];
			if ($Debug) echo ("Armor = " @ %armor @ "");
			if($Reneg::Cash == "true")
			{
				if (%armor == "ScoutArmor" ||%armor == "SpArmor" ||%armor == "LightArmor" ||%armor == "MediumArmor" ||%armor == "BursterArmor" ||%armor == "EngArmor" ||%armor == "AlArmor" ||%armor == "DragArmor" ||%armor == "HeavyArmor")
				{
					if (%armor == "ScoutArmor")
						%killerId.cash += 25;
			
					if (%armor == "SpArmor")
						%killerId.cash += 21;

					if (%armor == "LightArmor")
						%killerId.cash += 18;
	
					if (%armor == "MediumArmor")
						%killerId.cash += 15;

					if (%armor == "BursterArmor")
						%killerId.cash += 13;
	
					if (%armor == "EngArmor")
						%killerId.cash += 14;

					if (%armor == "AlArmor")
						%killerId.cash += 13;

					if (%armor == "DragArmor")
						%killerId.cash += 10;

					if (%armor == "HeavyArmor")
						%killerId.cash += 4;
				}
			}
		//	%killerId.cash += 10;
            Game::refreshClientScore(%killerId);
            Game::refreshClientScore(%playerId);
        }
    }
    Game::clientKilled(%playerId, %killerId);
}
function Game::clientKilled(%playerId, %killerId)
{ }
function Client::leaveGame(%clientId)
{ }
function Player::enterMissionArea(%player)
{
    echo("Player " @ %player @ " entered the mission area.");
}
function Player::leaveMissionArea(%player)
{
    echo("Player " @ %player @ " left the mission area.");
}
function Game::ScrollMOTD(%clientId, %dir) {
	if (%clientId.observerMode != "justJoined") {
		centerprint(%clientId, "", 0);
		return;
	}

	%STitle = $Server::JoinTitle;
	%first = String::getSubStr(%STitle, 0, $chrCount[%clientId]);
	%hilite = String::getSubStr(%STitle, $chrCount[%clientId], 1);
	%last = String::getSubStr(%STitle, $chrCount[%clientId]+1, $Server::JoinTitleLength);
	%title = "<jc><f2>" @ %first @ "<f1>" @ %hilite @ "<f2>" @ %last;
	if(%dir == "right") {
		$chrCount[%clientId]++;
		if($chrCount[%clientId] == $Server::JoinTitleLength) {
			%dir = "left";
		}
	}
	else if(%dir == "left") {
		$chrCount[%clientId]--;
		if($chrCount[%clientId] == 0) {
			%dir = "right";
		}
	}

	$textPos[%clientId]++;

	if($textPos[%clientId] - 80 > $scrollLength) {
		$textPos[%clientId] = 80 - $scrollWidth;
	}

	for(%i = 0; %i <= $scrollWidth; %i++) {
		if($textPos[%clientId] + %i - 80 > $scrollLength || $textPos[%clientId] + %i - 80 < 0) {
			%msg = %msg @ " ";
		}
		else {
			%msg = %msg @ String::getSubStr($Server::MOTDsc, $textPos[%clientId] + %i - 80, 1);
		}
	}

	schedule("Game::ScrollMOTD(" @ %clientId @ "," @ %dir @");", 0.1);

	%msg = %title @ "\n\n<jc>" @ %msg;
	%msg = %msg @ "\n\n<jc><f2>Fire to Enter Renegadez";
	centerprint(%clientId, %msg, 0);
}
function GameBase::getHeatFactor(%this)
{
    return 0.0;
}
function auto(%autosel)
{
	%numplayers = 0;
	//if(%autosel == "1" || %autosel == "3")
	//{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			savecharacter(%cl);
			%numplayers ++;
		}
	//	if(%autosel != "3")
	//		return;
	//}
	//if(%autosel == "2" || %autosel == "3")
	//{
		if(%numplayers >= 4 && !$BaseRapeDamage)
		{
			$AutoBaseRape = 0;
			$BaseRapeDamage = 1;
		}
		else if (%numplayers < 4 && $BaseRapeDamage)
		{
			$AutoBaseRape = 1;
			$BaseRapeDamage = "";
		}
	//	if($autosel != "3")
	//		return;
	//}
	if(%autosel = "3")
		schedule("auto(3);",60); 
}
//Weather Stuff
function RandomEvent()
{	
	if($RandomEvents == "False")
	{
		schedule("RandomEvent();", 10.0);
		return;
	}
	
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
	//for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	//{
	//	%msg = "client::sendMessage(%clientId,2,"The Orbital Debri has began to reflect off the atmosphere.");";	
	//	schedule(%msg,$MeteorDuration+1);
	//}
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
	//for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	//		{
	//			%msg = "client::sendMessage(%clientId,2,"The electrical storm has began to dissipate.");";
	//			schedule(%msg,$LightningDuration+1);
	//		}
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
//	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
//			{
//				%msg = "client::sendMessage(%clientId,2,"The solar flare has began to dissipate.");";
//				schedule(%msg,$SolarFlareDuration+1);
//			}
	schedule ("DeleteObject(" @ %camera @ ");",$SolarFlareDuration+1);
}

function SolarFlareBurst(%obj)
{
	%pos = GameBase::getPosition(%obj);
	GameBase::ApplyRadiusDamage(26,%pos,3000,0.00201,0.001,%obj);
}