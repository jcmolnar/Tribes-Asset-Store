$ModVersion = "2.00";
$betaBuildNumber = "";

exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

// Global Variables

$MODInfo = $Server::MODInfo;
//$boostStr = 0.03;

$ClassAGen[0] = "";
$ClassAGen[1] = "";

$ClassBGen[0] = "";
$ClassBGen[1] = "";

$GenSet[0] = "";
$GenSet[1] = "";

//$Alarm[0] = false;
//$Alarm[1] = false;

// Energy each team is given at beginning of game
//------------------------
$DefaultTeamEnergy = 5000;

// Team Energy variables
//-------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy;
$TeamEnergy[0] = $DefaultTeamEnergy;
$TeamEnergy[1] = $DefaultTeamEnergy;
$TeamEnergy[2] = $DefaultTeamEnergy;
$TeamEnergy[3] = $DefaultTeamEnergy;
$TeamEnergy[4] = $DefaultTeamEnergy;
$TeamEnergy[5] = $DefaultTeamEnergy;
$TeamEnergy[6] = $DefaultTeamEnergy;
$TeamEnergy[7] = $DefaultTeamEnergy;

//---------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------
$WaitThrowTime = 2;

//---------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------
// MAX amount team energy can reach
//---------------------------------------
$MaxTeamEnergy = 20000;

//---------------------------------------
// Time player has to put flag in flagstand before it gets returned to its last
// location. 
//---------------------------------------
$flagToStandTime = 180;

//---------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------
$incTeamEnergy = 30;

//---------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//--------------------------------------------
$secTeamEnergy = 10;

//---------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------
$RemoteAmmoEnergy = 3000;
$RemoteInvEnergy = 3000;

//---------------------------------------
// TEAM ENERGY - Warn team when teammate has spent x amount - Warn team that
//	energy level is low when it reaches x amount 
//---------------------------------------
$TeammateSpending = -4000; //Set = to 0 if you don't want the warning message
$WarnEnergyLow = 3500; //Set = to 0 if you don't want the warning message

//---------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------
$InitialPlayerEnergy = 2500;

//---------------------------------------
// REMOTE TURRET
//---------------------------------------
$MaxNumTurretsInBox = 4; //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 35; //Define Max Length of the area
$TurretBoxMaxWidth = 35; //Define Max Width of the area
$TurretBoxMaxHeight = 25; //Define Max Height of the area

$TurretBoxMinLength = 5; //Define Min Length from another turret
$TurretBoxMinWidth = 5; //Define Min Width from another turret
$TurretBoxMinHeight = 5; //Define Min Height from another turret

//---------------------------------------
//	Object Types	
//---------------------------------------
$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;

$MineObjectType = 1 << 26;
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;
$StaticObjectType = 1 << 23;
$ItemObjectType = 1 << 21;

//---------------------------------------------------
// CHEATS
//---------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------
//Respawn automatically after X sec's - If 0..no respawn
//---------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//		 %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------
$deathMsg[$LandingDamageType, 0] = "%1 falls to %2 death.";
$deathMsg[$LandingDamageType, 1] = "%1 forgot to tie %2 bungie cord.";
$deathMsg[$LandingDamageType, 2] = "%1 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3] = "%1 thought the ground looked softer.";
$deathMsg[$LandingDamageType, 4] = "%1 leaves a big ugly crater.";
$deathMsg[$ImpactDamageType, 0] = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1] = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2] = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3] = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$ImpactDamageType, 4] = "%2 didn't get out of %1's way.";
$deathMsg[$BulletDamageType, 0] = "%2 got regulated by %1.";
$deathMsg[$BulletDamageType, 1] = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2] = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3] = "%1 guns down %2.";
$deathMsg[$BulletDamageType, 4] = "%1 gave %2 a hole in %3 head that wasn't there before.";
$deathMsg[$EnergyDamageType, 0] = "%2 found %1's stray electrons.";
$deathMsg[$EnergyDamageType, 1] = "%1 taught %2 about high energy weapons.";
$deathMsg[$EnergyDamageType, 2] = "%1 gives %2 a dose of electricity.";
$deathMsg[$EnergyDamageType, 3] = "%2 gets electricuted by %1.";
$deathMsg[$EnergyDamageType, 4] = "%2 is now more energetic thanks to %1.";
$deathMsg[$PlasmaDamageType, 0] = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1] = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2] = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3] = "%1 gives %2 a burning itch.";
$deathMsg[$PlasmaDamageType, 4] = "%2 feels a burning sensation.";
//Trollplasma = projected shield
$deathMsg[$TrollPlasmaDamageType, 0] = "%2 was terminated by the shield of %1.";
$deathMsg[$TrollPlasmaDamageType, 1] = "%1 gives %2 an overdose of shield.";
$deathMsg[$TrollPlasmaDamageType, 2] = "%2 foolishly accepted a shield donation from %1";
$deathMsg[$TrollPlasmaDamageType, 3] = "%1 fries %2 whith his projected shield.";
$deathMsg[$TrollPlasmaDamageType, 4] = "%2 found %1's projected shield to be shocking.";
//explosion = acidcloud
$deathMsg[$ExplosionDamageType, 0] = "%2 inhales too many fumes from %1.";
$deathMsg[$ExplosionDamageType, 1] = "%1 leaves a burning residue on %2.";
$deathMsg[$ExplosionDamageType, 2] = "%1's acid corroded %2 away.";
$deathMsg[$ExplosionDamageType, 3] = "%2 falls victim to %1's acidcloud gun.";
$deathMsg[$ExplosionDamageType, 4] = "%1 teaches %2 all about acids.";
$deathMsg[$ShrapnelDamageType, 0] = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1] = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2] = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3] = "%2 never saw it coming from %1.";
$deathMsg[$ShrapnelDamageType, 4] = "%2 saw the bad side of %1.";
$deathMsg[$LaserDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1] = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$LaserDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$LaserDamageType, 4] = "%2 gets another hole in %3 head.";
$deathMsg[$MortarDamageType, 0] = "%1 explodes %2 into oblivion.";
$deathMsg[$MortarDamageType, 1] = "%2 found %1's explosives.";
$deathMsg[$MortarDamageType, 2] = "%1 placed the explosives where %2 could find them.";
$deathMsg[$MortarDamageType, 3] = "%1's bomb takes out %2.";
$deathMsg[$MortarDamageType, 4] = "%2 did not come back in one piece.";
$deathMsg[$BlasterDamageType, 0] = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1] = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2] = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3] = "%2 meets %1's master blaster.";
$deathMsg[$BlasterDamageType, 4] = "%1's punks %2 ghetto style.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped by %1.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$ElectricityDamageType, 4] = "%2 is turned to a crispy critter.";
$deathMsg[$SoulDamageType, 0] = "%2 Gets %4 soul pulled out by %1.";
$deathMsg[$SoulDamageType, 1] = "%1 pulled a rabbit out of %2's head.";
$deathMsg[$SoulDamageType, 2] = "%1 sent %2's soul to Odin.";
$deathMsg[$SoulDamageType, 3] = "%2 dies for %1's sins.";
$deathMsg[$SoulDamageType, 4] = "%1 fried up %2's soul cajun style.";
$deathMsg[$CrushDamageType, 0] = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1] = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2] = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3] = "%2 gets caught in the machinery.";
$deathMsg[$CrushDamageType, 4] = "%2 is sat on by %1's mom.";
$deathMsg[$DebrisDamageType, 0] = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1] = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2] = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3] = "%2 got too close to the exploding stuff.";
$deathMsg[$DebrisDamageType, 4] = "%2 feels the rain of debris.";
//artillery is also missile
$deathMsg[$MissileDamageType, 0] = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1] = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2] = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3] = "%2 feels the burn from a warhead.";
$deathMsg[$MissileDamageType, 4] = "%2 rides the rocket.";
$deathMsg[$AntiTurretDamageType, 0] = "%2 Walks right into the anti turret shot from %1.";
$deathMsg[$AntiTurretDamageType, 1] = "%1 tells %2 to get out of his line of fire.";
$deathMsg[$AntiTurretDamageType, 2] = "%2 wondered what the energy bolt form %1 was.";
$deathMsg[$AntiTurretDamageType, 3] = "%2 got fried by %1's anti turret drone.";
$deathMsg[$AntiTurretDamageType, 4] = "%2 forgot to dodge %1's shot.";
$deathMsg[$MineDamageType, 0] = "%2 blunders onto a mine.";
$deathMsg[$MineDamageType, 1] = "%2 tried to return %1's mine to him.";
$deathMsg[$MineDamageType, 2] = "%1 left a mine where %2 would find it.";
$deathMsg[$MineDamageType, 3] = "%2 walked right into a present from %1.";
$deathMsg[$MineDamageType, 4] = "%2 stepped in %1's cow pie.";
$deathMsg[$SniperDamageType, 0] = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1] = "%1 fells %2 with a shot between the eyes.";
$deathMsg[$SniperDamageType, 2] = "%2 was assassinated by %1.";
$deathMsg[$SniperDamageType, 3] = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$SniperDamageType, 4] = "%2 gets picked off from afar by %1.";
$deathMsg[$ShockDamageType, 0] = "%1 emps %2 until he sticks to the ground.";
$deathMsg[$ShockDamageType, 1] = "%2 gets a taste of %1's electricity.";
$deathMsg[$ShockDamageType, 2] = "%1 gives %2 an overdose of electromagnetic radiation.";
$deathMsg[$ShockDamageType, 3] = "%2 jets a nasty jolt from %1.";
$deathMsg[$ShockDamageType, 4] = "%2 gets emped by %1.";
//shotgun = mfac
$deathMsg[$ShotgunDamageType, 0] = "%2 felt the burn from %1's MFAC.";
$deathMsg[$ShotgunDamageType, 1] = "%1 fried %2 with %3 MFAC.";
$deathMsg[$ShotgunDamageType, 2] = "%1 showed off his hot fusion invention on %2.";
$deathMsg[$ShotgunDamageType, 3] = "%1's MFAC showed %2 the true meaning of pain.";
$deathMsg[$ShotgunDamageType, 4] = "%2 is fried by %1's MFAC.";
$deathMsg[$AssassinDamageType, 0] = "%2 is assassinated by %1.";
$deathMsg[$AssassinDamageType, 1] = "%2 gets %3 throat cut by %1.";
$deathMsg[$AssassinDamageType, 2] = "%2 gets stabbed in the back by %1.";
$deathMsg[$AssassinDamageType, 3] = "%2 didn't see it coming from %1.";
$deathMsg[$AssassinDamageType, 4] = "%1 slices %2's throat.";
$deathMsg[$DisarmDamageType, 0] = "%1 removes %2's weapon for the last time.";
$deathMsg[$DisarmDamageType, 1] = "%2 is embarrased by %1.";
$deathMsg[$DisarmDamageType, 2] = "%2 finds %4self without a gun.";
$deathMsg[$DisarmDamageType, 3] = "%2 finds %4self without a weapon.";
$deathMsg[$DisarmDamageType, 4] = "%2 is embarrased by %1.";
$deathMsg[$StasisDamageType, 0] = "%1 inflicts a mortal blow on %2.";
$deathMsg[$StasisDamageType, 1] = "%1 blasts %2 at point blank range.";
$deathMsg[$StasisDamageType, 2] = "%2 is brutally shafted by %1.";
$deathMsg[$StasisDamageType, 3] = "%2 can now count how many pieces %4 is in.";
$deathMsg[$StasisDamageType, 4] = "%1 shows off his melee skills on %2.";
$deathMsg[$MeleeDamageType, 0] = "%1 inflicts a mortal blow on %2.";
$deathMsg[$MeleeDamageType, 1] = "%1 blasts %2 at point blank range.";
$deathMsg[$MeleeDamageType, 2] = "%2 is brutally shafted by %1.";
$deathMsg[$MeleeDamageType, 3] = "%2 is now counting how many pieces %4 is in.";
$deathMsg[$MeleeDamageType, 4] = "%1 shows off his melee skills on %2.";
$deathMsg[$TurretVortexDamageType, 0] = "%2 gets sucked in by %1's turret.";
$deathMsg[$TurretVortexDamageType, 1] = "%2 is vortexed to another dimension by %1.";
$deathMsg[$TurretVortexDamageType, 2] = "%2 finds a better place.";
$deathMsg[$TurretVortexDamageType, 3] = "%1 sends %2 to a better place.";
$deathMsg[$TurretVortexDamageType, 4] = "%1 shows %2 a wormhole.";
//poison = nanites
$deathMsg[$PoisonDamageType, 0] = "%2 is killed by nanites.";
$deathMsg[$PoisonDamageType, 1] = "%2 is chewed to pieces hundreds of nanites.";
$deathMsg[$PoisonDamageType, 2] = "%2 was very generous to the hungry nanites.";
$deathMsg[$PoisonDamageType, 3] = "%2 is now a nanite breeding pit.";
$deathMsg[$PoisonDamageType, 4] = "%2 discovered that nanites aren't all fun.";
$deathMsg[$JailDamageType, 0] = "%2 is incarcerated by %1.";
$deathMsg[$JailDamageType, 1] = "%2 is incarcerated by %1.";
$deathMsg[$JailDamageType, 2] = "%2 is incarcerated by %1.";
$deathMsg[$JailDamageType, 3] = "%2 is incarcerated by %1.";
$deathMsg[$JailDamageType, 4] = "%2 is incarcerated by %1.";

// %1 = player name, %2 = player gender pronoun

$deathMsg[-2,0] = "%1 checked into the flatline hotel.";
$deathMsg[-2,1] = "%1 takes a dirt nap.";
$deathMsg[-2,2] = "%1 kills %2 own dumb self.";
$deathMsg[-2,3] = "%1 decides to see what the afterlife is like.";
$deathMsg[-2,4] = "%1 goes for the quick and dirty respawn.";

$numDeathMsgs = 5;
//------------------------------------
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
//plasmatic
	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
	
	// can't switch to command mode while a server menu is up
	if(%clientId.droid)
		return;
	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1); // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
			checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
	}
}

function remoteInventoryMode(%clientId)
{
//plasmatic
	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
		
	if((!%clientId.guiLock && !Observer::isObserver(%clientId)) && %clientId.AdminobserverMode != "AdminObserve")
	{
		remoteSCOM(%clientId, -1);
		Client::clearItemShopping(%clientId);
		Client::setGuiMode(%clientId, $GuiModeInventory);
		if(($build || $Annihilation::QuickInv || %ClientId.InvConnect) && !Player::getItemCount(%player, GhostArmor))
		{
			QuickInv(%clientId);
			if($build || $Annihilation::QuickInv)	
				bottomprintall("<jc><f2>Global Inventories enabled. Toggle Inventory screen to access!!");
		}	
	}

}

function remoteObjectivesMode(%clientId)
{
//plasmatic
	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
		
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
	if(%clientId.AdminobserverMode == "AdminObserve")  Observer::jump(%clientId);

	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
		
	if(Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
//plasmatic
	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
		
	if(Client::getGuiMode(%clientId) != $GuiModeInventory)
		{
			remoteInventoryMode(%clientId);
		}
	else	{
			remotePlayMode(%clientId);
			//if(%clientId.InvConnect)
			//	QuickInvOff(%clientId);
		}

}

function remoteToggleObjectivesMode(%clientId)
{
//plasmatic

	if(%clientId.AdminobserverMode == "AdminObserve")  Observer::jump(%clientId);

	%player = Client::getOwnedObject(%clientId);
	if(%player.frozen) return;
		
	if(Client::getGuiMode(%clientId) != $GuiModeObjectives)
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

function Game::startMatch()
{
	$matchStarted = true;
//	$modList = "Apteryx"; $ModInfo = "Apteryx";
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();
//plasmatic
	if($Annihilation::BaseHeal) AutoRepair(0.003);
	
	%numTeams = getNumTeams()-1;
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

function ModSettingsInfo(%clientId, %weaponHelp)
{
	if($betaBuildNumber)
		%modvers = "<f1> build "@ $betaBuildNumber;
	if($Annihilation::SafeBase)
		%modinfostring = " Base supply is undestroyable";
	else %modinfostring = " Base supply is destroyable";
	if($Annihilation::BaseHeal && !$Annihilation::SafeBase)
		%modinfostring = %modinfostring @ ", self regenerating.";
	else %modinfostring = %modinfostring @ ". ";
	if($NoPlayerDamage)
		%modinfostring = %modinfostring @ " Player damage: OFF.";
	if($Build)
		%modinfostring = %modinfostring @ " Builder mode: ON.";		
	
	%clientId.weaponHelp = false;
	bottomprint(%clientId, "<jc><f2>Apteryx v2.00\nApteryx - the land of flightless armors and armed fliers.\n<f0>Mission: <f1>" @ $missionName @ "	<f0>Mission Type: <f1>" @ $Game::missionType @ " <f0>Press 'O' for specific objectives.",25);	
	if(%weaponHelp)schedule(%clientId @ ".weaponHelp = true;" , 10, %clientId);
}

$DefaultArmor[Male] = armormAngel;
$DefaultArmor[Female] = armorfAngel;

function Game::playerSpawn(%clientId, %respawn)
{
	if(!$ghosting)
		return false;
	%clientId.AdminobserverMode = "";
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);

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
		echo("SPAWN: "@ Client::getName(%clientID)@ " cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		%pl.cloakable = true;	//for base cloaker -plasmatic
		%clientId.AdminobserverMode = "";
		%clientId.observerMode = "";
		
		%clientId.ConnectBeam = "";	//for zappy invs -plasmatic
		%clientId.InvTargetable = "";	//zap!
		%ClientId.InvConnect = "";	//Zap!
		
		if(%pl != -1)
		{
			//Client::clearItemShopping(%clientId);
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
			%pl.cloakable = true;
			$jailed[%pl] = "";
			$released[%pl] = "";
			if($matchStarted)
			{
				Client::setControlObject(%clientId, %pl);
				%clientId.droid=false;
			}
			else
			{
				%clientId.observerMode = "pregame";
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
			}
//==================  respawn Invulnerable -plasmatic
	$respawnInvulnerableTime = 10;
	   if(%respawn)	
	   	{
	   	$respawnInvulnerableTime = 5;
		if($siegeFlag)	Siege::waypointClient(%clientId);
		}
            %damage = %armor.maxDamage - 0.001;
            GameBase::setEnergy(%pl, %armor.maxEnergy/2);
            GameBase::setAutoRepairRate(%pl, %damage / $respawnInvulnerableTime);
            %pl.invulnerable = true;
            %pl.cloakable = true;	//fer base cloaker -plasmatic
            $jailed[%pl] = "";	//just to be certain for jail..
            $released[%pl] = "";
            NukeBaselist(%pl);
            incInvulnerable(%pl, 0);
		      %weapon = Player::getMountedItem(%pl,$WeaponSlot);
		      if(%weapon != -1) {
			      %pl.lastWeapon = %weapon;
			      Player::unMountItem(%pl,$WeaponSlot);
		      }
       	if(!%respawn)
	{
		// initial drop
		if($siegeFlag)
			{
			schedule("Client::sendMessage("@%clientId@", 0, \"Welcome to Siege! Capture or hold the switch to complete the mission.\");",5);
			schedule("Siege::InitialwaypointClient("@%clientId@");",5);
			}
		ModSettingsInfo(%clientId, true);
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
function incInvulnerable(%player, %time)
{
   if(%time > $respawnInvulnerableTime)
   {
      %player.invulnerable = "";
      GameBase::setAutoRepairRate(%player, 0);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	   if(%player.lastWeapon != "" && %weapon == -1) {
		   Player::useItem(%player,%player.lastWeapon);
		   %player.lastWeapon = "";
	    }
   }
   else
   { 
      schedule("incInvulnerable(" @ %player @ ", "@ %time + 0.5 @ ");", 0.5, %player);
   }
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
	// hard coded here -plasmatic
	
	schedule("Client::clearItemShopping("@%clientId@");",1);
	
	if($Annihilation::UsePersonalSkin)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	else Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
	
	Player::setItemCount(%clientId, iarmorAngel, 1);	
	Player::setItemCount(%clientId, DeathRay, 1);
	Player::setItemCount(%clientId, TargetingLaser, 1);   
  
	Player::setItemCount(%clientId, RepairKit, 1);
	Player::setItemCount(%clientId, Beacon, 2);
	Player::setItemCount(%clientId, Grenade, 3);	   
	Player::setItemCount(%clientId, MineAmmo, 3);
	   	   
	Player::setItemCount(%clientId, RepairPack, 1);
	Player::useItem(%pl, RepairPack);	   
	Player::useItem(%pl, DeathRay);
}

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

//removed use personal skin, up to server now
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
		%numTeams = getNumTeams()-1;
		%curTeam = Client::getTeam(%clientId);

		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
			Game::assignClientTeam(%clientId);
	}	 
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
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		%clientId.justConnected = "";
	}
	else 
	{
		//plasmatic
	if($Annihilation::UsePersonalSkin)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	else Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);	
		
//		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		if(%clientId.justConnected)
		{
			if(%clientId.isadmin)schedule("client::sendmessage("@%clientId@",0,\"~wfemale3.whello.wav\");",1);
			centerprint(%clientId, $Server::JoinMOTD, 0);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			%clientId.AdminobserverMode = "";
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
	
	// loop through all the clients and see if any are still not ready
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
	if($ServerCheats)
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
	%playerId.bk = 0;
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
	%playerId.names = "";
}

function Game::assignClientTeam(%playerId,%return)
{
	if($teamplay)
	{
		%name = Client::getName(%playerId);
		%numTeams = getNumTeams()-1;
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

		
		if($debug)
			echo("Game::assignClientTeam, num teams, "@%numTeams@" numplayers, "@%numPlayers);
		
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
		if(!%return){
			GameBase::setTeam(%playerId, %leastTeam);
			echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
		}
		else return %leastTeam;
	}
	else
	{
		if(!%return)GameBase::setTeam(%playerId, 0);
		else return %leastTeam;
	}
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
	//%playerId = clientid -plasmatic
	
	%name = Client::getName(%playerId);
	%kname = Client::getName(%killerId);	
	if($debug)
		echo("killed by ai "@%playerId.AIkiller@" ai# "@AI::getId(%playerId.AIkiller));
		
	if(%damageType == 12 && %killerId.oprocketowner) //Plasmatic
	{
 		%killerId = %killerId.oprocketowner;
 		%killerId.oprocketowner = "";
 	}
	if(!%killerId && %playerId.AIkiller)
		%killerId = AI::getId(%playerId.AIkiller);
		
	echo("GAME: " @ %kname @" "@%killerId @ " Killed " @ %name @" "@ %playerId @ " " @ %damageType);
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


	if(!%killerId && %playerId.AIkiller != "" && %playerId.AIkiller != "False")
	{
		messageAll(0, %playerId.AIkiller @" demonstrated AI for "@%victimName, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.AIkiller = "";
		
	}
	else if(!%killerId && (!%playerId.AIkiller || %playerId.AIkiller != "False"))
	{
		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;
		
	}	
	else if(%killerId == %playerId)
	{
		//fixed here for landing damage.. -plasmatic
		if(%damageType == $LandingDamageType)
		{		
			%oopsMsg = sprintf($deathMsg[%damageType, %ridx], %victimName, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
			%playerId.scoreDeaths++;
			%playerId.score--;
			Game::refreshClientScore(%playerId);				
		}
		else
		{
			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
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
			if(%damageType != $MineDamageType) 
				messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
				messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
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
			%playerId.scoreDeaths++; // test play mode
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

//function Client::leaveGame(%clientId)
//{
//}

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
