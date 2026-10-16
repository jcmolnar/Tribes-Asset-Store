exec("comchat.cs");
exec("TiZSettings.cs"); // PORT: was renegades.cs, which the release never shipped
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
$MaxTeamEnergy = 7000000;
$incTeamEnergy = 700;
$secTeamEnergy = 10;
$ItemRespawnTime = 30;
$RemoteAmmoEnergy = 600000;
$RemoteInvEnergy = 600000;
$RemoteComEnergy = 5000;
$TeammateSpending = -4000;
$WarnEnergyLow = 400;
$InitialPlayerEnergy = 5000;

$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;
$MineObjectType = 1 << 26;
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;
$StaticObjectType = 1 << 23;
$ItemObjectType = 1 << 21;
$ServerCheats = 0;
$TestCheats = 1;
$AutoRespawn = 0;

 // Death messages
$numDeathMsgs = 5;
$deathMsg[$LandingDamageType, 0] = "%2 falls from a thousand foot building.";
$deathMsg[$LandingDamageType, 1] = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2] = "%2 feels his bones turn to putty.";
$deathMsg[$LandingDamageType, 3] = "%2 has fallen...and %3 can't get up.";
$deathMsg[$LandingDamageType, 4] = "%2 jumped off a plane without a parachute.";
$deathMsg[$ImpactDamageType, 0] = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1] = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2] = "%2 leaves his chest cavity on %1's fender.";
$deathMsg[$ImpactDamageType, 3] = "%1 demonstrates to %2, the fine art of piloting'";
$deathMsg[$ImpactDamageType, 4] = "%1 crunches %2.";
$deathMsg[$BulletDamageType, 0] = "%2 got decimated by %1.";
$deathMsg[$BulletDamageType, 1] = "%1 gives %2 an taste of lead.";
$deathMsg[$BulletDamageType, 2] = "%1 blasted %2 a hole in %3 chest.";
$deathMsg[$BulletDamageType, 3] = "%1 ventilates %2.";
$deathMsg[$BulletDamageType, 4] = "%1 opens up a can of whup-ass on %2.";
$deathMsg[$EnergyDamageType, 0] = "%2 dies of illness.";
$deathMsg[$EnergyDamageType, 1] = "%2 gets a lethal injection from %1.";
$deathMsg[$EnergyDamageType, 2] = "%2 falls victim to a deadly virus.";
$deathMsg[$EnergyDamageType, 3] = "%2 could not find the vaccine in time.";
$deathMsg[$EnergyDamageType, 4] = "%2 gasps %3 last breath.";
$deathMsg[$PlasmaDamageType, 0] = "%2 bursts into flames.";
$deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a lethal sunburn.";
$deathMsg[$PlasmaDamageType, 2] = "%1 asks %2, 'Need a light?'";
$deathMsg[$PlasmaDamageType, 3] = "%1 lights %2 on fire.";
$deathMsg[$PlasmaDamageType, 4] = "%2 feels a %3 flesh burnning.";
$deathMsg[$ExplosionDamageType, 0] = "%2 gets blown apart by %1.";
$deathMsg[$ExplosionDamageType, 1] = "%2 explodes all over the place.";
$deathMsg[$ExplosionDamageType, 2] = "%2 gets shot down by %1.";
$deathMsg[$ExplosionDamageType, 3] = "%1 shows off %3 mad skills of body dismemberment on %2.";
$deathMsg[$ExplosionDamageType, 4] = "%2 goes Kablooie!";
$deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's brutal nature.";
$deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$ShrapnelDamageType, 4] = "%1 shreds %2.";
$deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of hapless victims.";
$deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a beam of pain.";
$deathMsg[$LaserDamageType, 2] = "%2 was executed by %1.";
$deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's way, for way, way WAAAAAYYYYY too long.";
$deathMsg[$LaserDamageType, 4] = "%2 gets a hole burned in %3 head.";
$deathMsg[$MortarDamageType, 0] = "%1 explodes %2 into oblivion.";
$deathMsg[$MortarDamageType, 1] = "%2 found %1's bomb.";
$deathMsg[$MortarDamageType, 2] = "%1 placed the explosives where %2 could find them.";
$deathMsg[$MortarDamageType, 3] = "%1's bomb takes out %2.";
$deathMsg[$MortarDamageType, 4] = "%2 's ass just got blown off,thanks to a mortar from %1.";
$deathMsg[$BlasterDamageType, 0] = "%2 gets capped by %1.";
$deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's relentless attack.";
$deathMsg[$BlasterDamageType, 2] = "%1 gives %2 a taste o' death.";
$deathMsg[$BlasterDamageType, 3] = "%2 meets %1's trusty sidearm.";
$deathMsg[$BlasterDamageType, 4] = "%1 opens up a can of whup-ass on %2.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, 4] = "%2 is turned to a crispy critter.";
$deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1] = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";
$deathMsg[$CrushDamageType, 4] = "%2 is stupid enough to get caught under an elevator.";
$deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";
$deathMsg[$DebrisDamageType, 4] = "%2 feels the rain of debris.";
$deathMsg[$MissileDamageType, 0] = "%2 gets blown apart.";
$deathMsg[$MissileDamageType, 1] = "%2 flies to the moon.";
$deathMsg[$MissileDamageType, 2] = "%2 played dodgeball with a rocket... And lost.";
$deathMsg[$MissileDamageType, 3] = "%2 feels the burn from a warhead.";
$deathMsg[$MissileDamageType, 4] = "%2 rides the rocket.";
$deathMsg[$MineDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$MineDamageType, 4] = "%2 didn't know what those black triangles were.";
$deathMsg[$FlashDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$FlashDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$FlashDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$FlashDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$FlashDamageType, 4] = "%2 gets flashed by %1.";
$deathMsg[$SniperDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1] = "%1 stood still again.";
$deathMsg[$SniperDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3] = "%2 stood in %1 's way, for tooooo long.";
$deathMsg[$SniperDamageType, 4] = "%2 gets picked off from afar by %1.";
$deathMsg[$ShellDamageType, 0] = "%2 feels the spread from %1's shotgun.";
$deathMsg[$ShellDamageType, 1] = "%2 gets obliterated by %1's shells.";
$deathMsg[$ShellDamageType, 2] = "%2 fell victim to a shotgun blast from %1.";
$deathMsg[$ShellDamageType, 3] = "%2 was slaughtered by %1.";
$deathMsg[$ShellDamageType, 4] = "%2 coughs up shotgun shells fed by %1.";
$deathMsg[$ReaperDamageType, 0] = "%1 reaped the hell out of %2.";
$deathMsg[$ReaperDamageType, 1] = "%2 was blasted by %1.";
$deathMsg[$ReaperDamageType, 2] = "%2 feels the skin on %3 body melt.";
$deathMsg[$ReaperDamageType, 3] = "%2 has a fatal siezure.";
$deathMsg[$ReaperDamageType, 4] = "%2 got hit hard by %1.";
$deathMsg[$MeltaDamageType, 0] = "%2 got microwaved by %1.";
$deathMsg[$MeltaDamageType, 1] = "%2 was cooked by %1.";
$deathMsg[$MeltaDamageType, 2] = "%2 was taught about home cookin, by %1.";
$deathMsg[$MeltaDamageType, 3] = "%2 was bubbled and melted by %1.";
$deathMsg[$MeltaDamageType, 4] = "%2 got pressure cooked by %1.";
$deathMsg[$DDamageType, 0] = "%2 was sucked into %1's vortex.";
$deathMsg[$DDamageType, 1] = "%1 introduced physics to %2.";
$deathMsg[$DDamageType, 2] = "%1 gave %2 a taste of Chaos.";
$deathMsg[$DDamageType, 3] = "%1 displayed his Eldar mastery upon %2.";
$deathMsg[$DDamageType, 4] = "%2 was destroyed by %1.";
$deathMsg[$FlamerDamageType, 0] = "%2 is cooked medium rare by %1.";
$deathMsg[$FlamerDamageType, 1] = "%1 bakes %2 at 3000 degrees centigrade.";
$deathMsg[$FlamerDamageType, 2] = "%2 feels a little hot under the hood.";
$deathMsg[$FlamerDamageType, 3] = "%2 fries extra crispy from %1's flamer.";
$deathMsg[$FlamerDamageType, 4] = "%1 ignites %2.";
$deathMsg[$ShurikenDamageType, 0] = "%2 cathes an explosive shuriken from %1.";
$deathMsg[$ShurikenDamageType, 1] = "%2 is quite good at catching frisbees.";
$deathMsg[$ShurikenDamageType, 2] = "%1 shows his abilities off to %2.";
$deathMsg[$ShurikenDamageType, 3] = "%2 finds out %1's aim is better than was first thought.";
$deathMsg[$ShurikenDamageType, 4] = "%2 breathes no more.";
$deathMsg[$DeathDamageType, 0] = "%2 enjoys a shower of fusion-charged death.";
$deathMsg[$DeathDamageType, 1] = "%1's fusion found %2's head.";
$deathMsg[$DeathDamageType, 2] = "%2 learns to die with grace.";
$deathMsg[$DeathDamageType, 3] = "%1 nails %2 in the danglies with a boot made of fusion.";
$deathMsg[$DeathDamageType, 4] = "%2 falls victim to charged particles from %1.";
$deathMsg[-2,0] = "%1 went to see Dr. Kevorkian.";
$deathMsg[-2,1] = "%1 wanted to make sure %2 gun was loaded.";
$deathMsg[-2,2] = "%1 kills %2 own dumb self.";
$deathMsg[-2,3] = "%1 didn't like Heaven that much anyways.";
$deathMsg[-2,4] = "%1 made a sacrifice to TiZ.";

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
    if(%clientId.observerMode != "pregame") checkControlUnmount(%clientId);
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
  if(!%clientId.menuMode) Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId) 
{
  Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId) 
{
  if (Client::getGuiMode(%clientId) != $GuiModeCommand) remoteCommandMode(%clientId);
  else remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId) 
{
  if (Client::getGuiMode(%clientId) != $GuiModeInventory) remoteInventoryMode(%clientId);
  else remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId) 
{
  if (Client::getGuiMode(%clientId) != $GuiModeObjectives) remoteObjectivesMode(%clientId);
  else remotePlayMode(%clientId);
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
  if(!%count) return -1;
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
  if(!%count) return -1;
  %spawnIdx = $lastTeamSpawn[%team] + 1;
  if(%spawnIdx >= %count) %spawnIdx = 0;
  $lastTeamSpawn[%team] = %spawnIdx;
  return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn) 
{
  if(%respawn) return Game::pickRandomSpawn(%team);
  else 
  {
    %spawn = Game::pickStartSpawn(%team);
    if(%spawn == -1) return Game::pickRandomSpawn(%team);
    return %spawn;
  }
}

function Game::pickObserverSpawn(%client) 
{
  %group = nameToID("MissionGroup\\ObserverDropPoints");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
  %count = Group::objectCount(%group);
  if(%group == -1 || !%count) return -1;
  %spawnIdx = %client.lastObserverSpawn + 1;
  if(%spawnIdx >= %count) %spawnIdx = 0;
  %client.lastObserverSpawn = %spawnIdx;
  return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time) 
{
  for(%cl = Client::getFirst();
  %cl != -1;
  %cl = Client::getNext(%cl)) remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time) 
{
  messageAll(0, "Combat begins in " @ %time @ " seconds.");
  UpdateClientTimes(%time);
}

function Game::startMatch() 
{
  $matchStarted = true;
  $missionStartTime = getSimTime();
  messageAll(0, "Go, go, go!");
  Game::resetScores();
  %numTeams = getNumTeams();
  for(%i = 0; %i < %numTeams; %i = %i + 1) 
  {
    if($TeamEnergy[%i] != "Infinite") schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
  }
  for(%cl = Client::getFirst();
  %cl != -1;
  %cl = Client::getNext(%cl)) 
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
  if (!$ghosting) return false;
  Client::clearItemShopping(%clientId);
  %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
  if (!%respawn) 
    bottomprint(%clientId, 
       $Welcome @ 
       "<f0>Connection#: <f1>" @ %clientId.num @ "   <f0>Server Resets: <f1>" @ $Stats::ResetCount @ "\n" @
       "<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n" @
       "<f0>Press <f1>'O'<f0> for specific objectives.", 10);

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

    %armor = $DefaultArmor[Client::getGender(%clientId)];

    %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
    reportSpawn(%clientId, %spawnMarker, %armor);
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
    if(%item.className == Weapon) %clientId.spawnWeapon = %item;
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
  if(%client.dead == 1) Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone() 
{
}

function Game::lowteam() 
{
  %numTeams = getNumTeams();
  %numPlayers = getNumClients();
  for(%i = 0;
  %i < %numTeams;
  %i = %i + 1) %numTeamPlayers[%i] = 0;
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
  for(%i = 1;
  %i < %numTeams;
  %i = %i + 1) 
  {
    if(%numTeamPlayers[%i] < %leastPlayers)
    {
      %leastTeam = %i;
      %leastPlayers = %numTeamPlayers;
    }
  }
  return %leastTeam;
}

function Game::initialMissionDrop(%clientId) 
{
  Client::setGuiMode(%clientId, $GuiModePlay);
  if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit") 
  {
    %clientId.observerMode = "observerOrbit";
    %clientId.guiLock = "";
    Observer::jump(%clientId);
    return;
  }
  %numTeams = getNumTeams();
  %curTeam = Client::getTeam(%clientId);
  if(!$Server::TourneyMode && (%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams))) ) Game::assignClientTeam(%clientId);
  else if($Server::TourneyMode) GameBase::setTeam(%clientId, -1);
  Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
  %camSpawn = Game::pickObserverSpawn(%clientId);
  Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
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
    if($Insomniax::fairTeams )
    {
      %i = Game::lowteam();
      Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
    }
    else 
    {
      for(%i = 0;
      %i < getNumTeams();
      %i = %i + 1) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
    }
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
      Insomniax_joinGame(%clientId);
    }
    else if(%clientId.observerMode == "justJoined") 
    {
      centerprint(%clientId, "");
      %clientId.observerMode = "";
      Game::playerSpawn(%clientId, false);
    }
    else Game::playerSpawn(%clientId, false);
  }
  if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite") $TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
  %clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team) 
{
  if($Server::TourneyMode && $matchStarted) %team = -2;
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
    if($TeamEnergy[%team] != "Infinite") $TeamEnergy[%team] += $InitialPlayerEnergy;
    %clientId.teamEnergy = 0;
    Client::setControlObject(%clientId, -1);
    Game::playerSpawn(%clientId, false);
  }
  if($Server::TourneyMode && !$CountdownStarted) 
  {
    bottomprint(%clientId, "", 0);
    %playerCount = 0;
    for(%cl = Client::getFirst();
    %cl != -1;
    %cl = Client::getNext(%cl)) 
    {
      if(%cl.observerMode == "pickingTeam") return;
      if(%cl.observerMode == "pregame") %playerCount++;
    }
    if(%playerCount != 0) Server::Countdown(30);
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
    reportGame("Timelimit reached.");
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
    for(%cl = Client::getFirst();
    %cl != -1;
    %cl = Client::getNext(%cl)) 
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
  else if($TestCheats && %player.isAdmin) // PORT: %player is the calling CLIENT here 
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
        reportTeam(%playerId, "Preset to team " @ $teamPreset[%name]);
        return;
      }
    }
    %numPlayers = getNumClients();
    for(%i = 0;
    %i < %numTeams;
    %i = %i + 1) %numTeamPlayers[%i] = 0;
    for(%i = 0;
    %i < %numPlayers;
    %i = %i + 1) 
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
    reportTeam(%playerId, "Automatically assigned to team " @ %leastTeam);
  }
  else 
    GameBase::setTeam(%playerId, 0);
}

function Client::onKilled(%playerId, %killerId, %damageType) 
{
  %victimName = Client::getName(%playerId);
  reportKill(%killerId, %playerId, %damageType);
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
  if(!%killerId) 
  {
    messageAll(0, strcat(%victimName, " dies."));
    %playerId.scoreDeaths++;
  }
  else if(%killerId == %playerId) 
  {
    %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
    messageAll(0, %oopsMsg);
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
      if(%killerId != %playerId) bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10);
      Insomniax_setTeamKill(%playerId, %killerId);
      messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
      %killerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%killerId);
    }
    else 
    {
      %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);
      messageAll(0, %obitMsg);
      %killerId.scoreKills++;
      %playerId.scoreDeaths++;
      %killerId.score++;
      Game::refreshClientScore(%killerId);
      Game::refreshClientScore(%playerId);
    }
  }
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
  // Useless waste of CPU
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Entered specified mission area.");
}

function Player::leaveMissionArea(%player) 
{
  // Useless waste of CPU
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Left the specified mission area.");
}

function GameBase::getHeatFactor(%this) 
{
  return 0.0;
}
