exec("comchat.cs");
exec("XKmod.cs");
exec("serverXKmod.cs");
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
$RemoteAmmoEnergy = 6500;
$RemoteInvEnergy = 10000;
$RemoteComEnergy = 8000;
$TeammateSpending = -4000;
$WarnEnergyLow = 4000;
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
$TestCheats = 0;
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$numDeathMsgs = 5;

$deathMsg[$FusionDamageType, 0] = "%1 lights up %2 with %3 Fusion.";
$deathMsg[$FusionDamageType, 1] = "%2 cought %1's fusion bolt.";
$deathMsg[$FusionDamageType, 2] = "%1 leave's %2 fried & crispy.";
$deathMsg[$FusionDamageType, 3] = "%1 takes %2 out with a bolt of fusion.";
$deathMsg[$IonDamageType, 0] = "%1 gives %2 an Ion Rash.";
$deathMsg[$IonDamageType, 1] = "%1 lets %2 suck on %3 Ion.";
$deathMsg[$IonDamageType, 2] = "%1 made %2 do a little dance.";
$deathMsg[$IonDamageType, 3] = "%1 takes %2 out with a burst of Ion.";
$deathMsg[$KamikazeDamageType, 0] = "%2 learns to hate Kamikazes. %1 teaches a harsh lesson.";
$deathMsg[$KamikazeDamageType, 1] = "%1 died for his cause and took %2 with %3self.";
$deathMsg[$KamikazeDamageType, 2] = "%1 defines \"Kamikaze\" for %2.";
$deathMsg[$KamikazeDamageType, 3] = "%1 takes %2 to the afterlife with %3self.";
$deathMsg[$LandingDamageType, 0] = "%2 cripples %3 Landing Gear.";
$deathMsg[$LandingDamageType, 1] = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2] = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3] = "%2 landed face first into concrete.";
$deathMsg[$LandingDamageType, 4] = "%2 dove into the ground.";
$deathMsg[$ImpactDamageType, 0] = "%1 grinds %2 into the gravel.";
$deathMsg[$ImpactDamageType, 1] = "%1 say's 'Hey %2 watch out im flying here!'.";
$deathMsg[$ImpactDamageType, 2] = "%2 left an inprint on %1's fender.";
$deathMsg[$ImpactDamageType, 3] = "%1 made a hit & run on %2";
$deathMsg[$ImpactDamageType, 4] = "%2 becomes nothing more than a new smear on %1's windshield.";
$deathMsg[$BulletDamageType, 0] = "%1 gives %2 a few new holes in %4 head.";
$deathMsg[$BulletDamageType, 1] = "%1 puts a huge hole in %2.";
$deathMsg[$BulletDamageType, 2] = "%2 got in the way of %1's gun fire.";
$deathMsg[$BulletDamageType, 3] = "%1 guns down %2.";
$deathMsg[$BulletDamageType, 4] = "%1 blows %2 away.";
$deathMsg[$EnergyDamageType, 0] = "%2 gets ZAPPED by %1.";     
$deathMsg[$EnergyDamageType, 1] = "%1 gives %2 a massive headache!";
$deathMsg[$EnergyDamageType, 2] = "%2 meets Ben Franklin.";
$deathMsg[$EnergyDamageType, 3] = "%1 thought he was a Scientist & tried an experiment out on %2.";
$deathMsg[$EnergyDamageType, 4] = "%1 gives %2 a little to much energy!";
$deathMsg[$PlasmaDamageType, 0] = "%2 bursts into flames.";
$deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2] = "%1 asks %2, 'Are you trying to get invited to my next BBQ?'";
$deathMsg[$PlasmaDamageType, 3] = "%1 say's %2 'OOoooooo TOASTY!'";
$deathMsg[$PlasmaDamageType, 4] = "%1 mistakes %2 as a piece of fire wood!";
$deathMsg[$ExplosionDamageType, 0] = "%2 gets %3 head removed by %1.";
$deathMsg[$ExplosionDamageType, 1] = "%2 loses %4 self thanks too %1.";
$deathMsg[$ExplosionDamageType, 2] = "%2 didnt see that one coming.";
$deathMsg[$ExplosionDamageType, 3] = "%1 shows %2 what bombs can do.";
$deathMsg[$ExplosionDamageType, 4] = "%2 spontainiously combust's";
$deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 an explosive surpirse!";
$deathMsg[$ShrapnelDamageType, 3] = "%2 got shredded by %1.";
$deathMsg[$ShrapnelDamageType, 4] = "%1 ingraves %3 name into %2 with %3 Shrapnel.";
$deathMsg[$ShotgunDamageType, 0] = "%1 makes swiss cheese out of %2, with %3 shot gun!";
$deathMsg[$ShotgunDamageType, 1] = "%1 tested %3 new Shot Gun out on %2.";
$deathMsg[$ShotgunDamageType, 2] = "%2 didnt believe %1's gun was loaded.";
$deathMsg[$ShotgunDamageType, 3] = "%1 thought it would be funny to watch %2 dodge %3 buck shot!";
$deathMsg[$ShotgunDamageType, 4] = "%2 says to %1 'THAT GUN CANT BE LEAGAL!'";
$deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$LaserDamageType, 4] = "%2 gets a hole burned in %3 head.";
$deathMsg[$MortarDamageType, 0] = "%1 wanted to play catch the grenade with %2.";
$deathMsg[$MortarDamageType, 1] = "%2 found %1's silly putty.";
$deathMsg[$MortarDamageType, 2] = "%1 placed the explosives where %2 could find them.";
$deathMsg[$MortarDamageType, 3] = "%1's bomb takes out %2.";
$deathMsg[$MortarDamageType, 4] = "%2 thought it would be fun to play with a live grenade.";
$deathMsg[$BlasterDamageType, 0] = "%2 takes it up the backdoor by %1.";
$deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2] = "%1 kills %2 with his puny pea shooter.";
$deathMsg[$BlasterDamageType, 3] = "%2 meets %1's pea shooter.";
$deathMsg[$BlasterDamageType, 4] = "%1 puts %2 down for the count.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets a lightning bolt up the ass thanks too %1.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 is inlightend by %1's Experience.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, 4] = "%2 is turned to a crispy critter by %1.";
$deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1] = "%2 gets compacted.";
$deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";
$deathMsg[$CrushDamageType, 4] = "%2 gets ground in the gears.";
$deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";
$deathMsg[$DebrisDamageType, 4] = "%2 feels the rain of debris.";
$deathMsg[$MissileDamageType, 0] = "%2 gets blown apart by %1's rocket.";
$deathMsg[$MissileDamageType, 1] = "%2 was impacted by %1's rocket.";
$deathMsg[$MissileDamageType, 2] = "%2 gets real friendly with %1's rocket.";
$deathMsg[$MissileDamageType, 3] = "%2 feels the burn from %1's warhead.";
$deathMsg[$MissileDamageType, 4] = "%2 rides %1's rocket.";
$deathMsg[$MineDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$MineDamageType, 4] = "%2 stepped in %1's cow pie.";
$deathMsg[$FlashDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$FlashDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$FlashDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$FlashDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$FlashDamageType, 4] = "%2 gets flashed by %1.";
$deathMsg[$SniperDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$SniperDamageType, 4] = "%2 gets picked off from afar by %1.";
$deathMsg[$NukeDamageType, 0] = "%1 was blown up by %2's Nuke.";
$deathMsg[$NukeDamageType, 1] = "%2 was Nuked by %1.";
$deathMsg[$NukeDamageType, 2] = "%2 was blown into pieces by %1's Nuke.";
$deathMsg[$NukeDamageType, 3] = "%2 gets blown into smitherines!";
$deathMsg[$NukeDamageType, 4] = "%2 was decentigrated!";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0] = "%1 kicks %2 own ass!";
$deathMsg[-2,1] = "%1 wanted to see the after life.";
$deathMsg[-2,2] = "%1 you know suicide is 'never' the way out!";
$deathMsg[-2,3] = "%1 through the pin & kept the Grenade!";
$deathMsg[-2,4] = "%1 executes %2 self.";

// END

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
      bottomprint(%clientId, "<jc><f2>XKmod v 1.4.5\nCreated by King Shit -&- Neo\n\nMission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 10);


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
   // PSKIN:BEGIN
  if (%clientId.custom)
    Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   // PSKIN:END

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
    if($XKmod::fairTeams )
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
       // PSKIN:BEGIN
      Client::buildMenu(%clientId, "Pick a team:", "usecustom");
      Client::addMenuItem(%clientId, "0Use Personal Skin", 0);
      Client::addMenuItem(%clientId, "1Use Team Default", 1);
      bottomprint(%clientId, $Server::JoinMOTD, 0);    
      //centerprint(%clientId, $Server::JoinMOTD, 0);
       // PSKIN:END
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

 // PSKIN:BEGIN
function processMenuuseCustom(%clientId, %skin)
{
   if(%skin == 0)
      %clientId.custom = True;
   if(%skin == 1)
    %clientId.custom = False;
   if(%team != -2)
   {
      if($TeamEnergy[%team] != "Infinite")
        $TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
}
 // PSKIN:END

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
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Entered the mission area.");
}

function Player::leaveMissionArea(%player) 
{
  // Useless waste of CPU
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Left the mission area.");
}

function GameBase::getHeatFactor(%this) 
{
  return 0.0;
}
