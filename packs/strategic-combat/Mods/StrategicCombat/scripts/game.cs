// - BW Admin Mod -
exec("comchat.cs");

$MODName = "STRATEGIC COMBAT";
$MODVersion = "version 1.63";
$MODExtra = "<jc><f0>BWAdmin 5.0 anti-TK code is enabled.\n<f1>This is WAR. Prepare to die.\n";
$MODInfo = "<jc><f6>"@$MODName@"\n <f2>"@$MODVersion@"\n\n"@$MODExtra;

$MODMotd = "<jc><f0>A MOD based on tactical gameplay. Think before you fight.\n<f2>Custom config file is recommended to fully enjoy this MOD.\n";

if($Combat::DamageMode != "normal") $MODMotd = "<jc><f0>This MOD is running a custom server damage setting. This may be unbalanced. Please vote for normal damage settings.\n";

$MODStartText = "<jc><f1>STRATEGIC COMBAT\n<f0>By Dasher[TOP]\n<f0>A variant of TRIBAL COMBAT\n<f0>by Despised\n\n<f2>A Tribes expansion for advanced players.\n"@$MODMotd@"www.geocities.com/garadon42\n<f1>Press fire.";

$ServerMod = $MODName;

$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//*******************
// Force Server Modes
//*******************
$Server::TeamDamageScale = 1;
$Server::TourneyMode = "false";

//-----------------------------------------------
// Energy each team is given at beginning of game

// - BW Admin Mod -
if($bwadmin::DefaultTeamEnergy != "")
  $DefaultTeamEnergy = $bwadmin::DefaultTeamEnergy;
else
// - BW Admin Mod - End
  $DefaultTeamEnergy = "Infinite";

//----------------------
// Team Energy variables
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
$WaitThrowTime = 2;

//------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
$TeamEnergyCheat = 0;

//---------------------------------
// MAX amount team energy can reach
$MaxTeamEnergy = 700000;

//------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
$flagToStandTime = 180;	  

//---------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
$incTeamEnergy = 250;

//--------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
$secTeamEnergy = 5;

//------------------------------
// (Rate is sec's) Items respwan
$ItemRespawnTime = 30;

//-----------------------------------------------
//Amount of Energy remote stations start out with
$RemoteAmmoEnergy = 3000;
$RemoteInvEnergy = 3200;

//---------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
$InitialPlayerEnergy = 0;

//--------------
// REMOTE TURRET
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

$MaxNumLasersInBox = 2;
$LaserBoxMaxLength = 75;
$LaserBoxMaxWidth = 75;
$LaserBoxMaxHeight = 25;

$LaserBoxMinLength = 35;
$LaserBoxMinWidth = 35;
$LaserBoxMinHeight = 10;

//--------------
//	Object Types	
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	= 1 << 29;  
$StaticObjectType		= 1 << 23;	   
$ItemObjectType			= 1 << 21;	  

//-------
// CHEATS
$ServerCheats = 0;
$TestCheats = 0;

//-------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
$AutoRespawn = 0;

//---------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
// %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust.";
$deathMsg[$LandingDamageType, 3]      = "%2 is shattered into nonexistance.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of %1's furious assault.";
$deathMsg[$ImpactDamageType, 2]      = "%2 is splattered by %1.";
$deathMsg[$ImpactDamageType, 3]      = "%1 pulverizes %2.";
$deathMsg[$BulletDamageType, 0]      = "%1 puts %2 down to eternal sleep.";
$deathMsg[$BulletDamageType, 1]      = "%2 forgot to dodge %1's bullet";
$deathMsg[$BulletDamageType, 2]      = "%1 puts a round through %2's head.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2";
$deathMsg[$EnergyDamageType, 0]      = "%1 gives %2 an overdose of energy.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by %1.";
$deathMsg[$EnergyDamageType, 2]      = "%2 wanders into a stream of %1's fire.";
$deathMsg[$EnergyDamageType, 3]      = "%1 reduces %2 to a pile of steaming gore.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches an explosive round fired by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 obliterates %2.";
$deathMsg[$ExplosionDamageType, 2]   = "%1 shows off %3 skills to %2.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's awesome powers.";
$deathMsg[$ShrapnelDamageType, 0]    = "%2 is shredded in %1's blast";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 should have seen it coming from %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 shows %2 a world of pain.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a well placed shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser beam.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 explodes %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%1's explosion turns %2 in to a fine mist.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal explosive wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's explosion takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's blaster shows %2 a new world of pain.";
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
$deathMsg[$MissileDamageType, 0]	    = "%1 sends a missile up the keister of %2.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down by %1's rocket";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with %1's rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%1's rocket blows the hell out of %2.";
$deathMsg[$MineDamageType, 0]	       = "%2 uncovered %1's booby trap.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 hears a click, and curses %1.";
$deathMsg[$DrainDamageType, 0]         = "%1 grows stronger upon the death of %2";
$deathMsg[$DrainDamageType, 1]         = "%1 wastes %2 away to nothing.";
$deathMsg[$DrainDamageType, 2]         = "%2 sacrifices %4 life, so that %1 could live.";
$deathMsg[$DrainDamageType, 3]         = "%1 saps the life right out of %2";

//Turret messages
$deathMsg[$BulletDamageType,4]      = " is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType,4]      = " is vaporized by a turret.";
$deathMsg[$ExplosionDamageType,4]   = " is torn apart by an auto cannon.";
$deathMsg[$LaserDamageType,4]       = " is cut down by a laser turret.";
$deathMsg[$ElectricityDamageType,4] = " is burned to a crisp by an ELF turret.";
$deathMsg[$MissileDamageType,4]     = " gets destroyed by a rocket turret.";


// "you just killed yourself" messages %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 commits suicide.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4; //DO NOT INCLUDE NON-PLAYER OR TURRET MESSAGE IN THIS COUNT!
//-----------------------------
$spawnBuyList[0] = CombatArmor;
$spawnBuyList[1] = EnergyRifle;
$spawnBuyList[2] = AssaultRifle;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = PlasmaGun;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = EnergyPack;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = MineAmmo;
$spawnBuyList[9] = Beacon;
//$spawnBuyList[10] = Special;
$spawnBuyList[10] = "";

//****************
function Combat::SetDamageMode()
{
   if(!$Combat::allowDamageModes) $Combat::DamageMode = "normal";

   if($Combat::DamageMode != "low" && $Combat::DamageMode != "normal" && 
      $Combat::DamageMode != "high" && $Combat::DamageMode != "custom") $Combat::DamageMode = "normal";

   if(!$Combat::LowDamageScale) $Combat::LowDamageScale = 0.6;
   else if($Combat::LowDamageScale > 1.0) $Combat::LowDamageScale = 1.0;
   else if($Combat::LowDamageScale < 0.3) $Combat::LowDamageScale = 0.3;

   if(!$Combat::HighDamageScale) $Combat::HighDamageScale = 1.3;
   else if($Combat::HighDamageScale > 2.0) $Combat::HighDamageScale = 2.0;
   else if($Combat::HighDamageScale < 1.0) $Combat::HighDamageScale = 1.0;

   if(!$Combat::ImpactDamage) $Combat::ImpactDamage = 1.0;
   else if($Combat::ImpactDamage < 0.3) $Combat::ImpactDamage = 0.3;
   else if($Combat::ImpactDamage > 2.0) $Combat::ImpactDamage = 2.0;

   if(!$Combat::LandingDamage) $Combat::LandingDamage = 1.0;
   else if($Combat::LandingDamage < 0.3) $Combat::LandingDamage = 0.3;
   else if($Combat::LandingDamage > 2.0) $Combat::LandingDamage = 2.0;

   if(!$Combat::BulletDamage) $Combat::BulletDamage = 1.0;
   else if($Combat::BulletDamage < 0.3) $Combat::BulletDamage = 0.3;
   else if($Combat::BulletDamage > 2.0) $Combat::BulletDamage = 2.0;

   if(!$Combat::EnergyDamage) $Combat::EnergyDamage = 1.0;
   else if($Combat::EnergyDamage < 0.3) $Combat::EnergyDamage = 0.3;
   else if($Combat::EnergyDamage > 2.0) $Combat::EnergyDamage = 2.0;

   if(!$Combat::PlasmaDamage) $Combat::PlasmaDamage = 1.0;
   else if($Combat::PlasmaDamage < 0.3) $Combat::PlasmaDamage = 0.3;
   else if($Combat::PlasmaDamage > 2.0) $Combat::PlasmaDamage = 2.0;

   if(!$Combat::ExplosionDamage) $Combat::ExplosionDamage = 1.0;
   else if($Combat::ExplosionDamage < 0.3) $Combat::ExplosionDamage = 0.3;
   else if($Combat::ExplosionDamage > 2.0) $Combat::ExplosionDamage = 2.0;

   if(!$Combat::ShrapnelDamage) $Combat::ShrapnelDamage = 1.0;
   else if($Combat::ShrapnelDamage < 0.3) $Combat::ShrapnelDamage = 0.3;
   else if($Combat::ShrapnelDamage > 2.0) $Combat::ShrapnelDamage = 2.0;

   if(!$Combat::LaserDamage) $Combat::LaserDamage = 1.0;
   else if($Combat::LaserDamage < 0.3) $Combat::LaserDamage = 0.3;
   else if($Combat::LaserDamage > 2.0) $Combat::LaserDamage = 2.0;

   if(!$Combat::MortarDamage) $Combat::MortarDamage = 1.0;
   else if($Combat::MortarDamage < 0.3) $Combat::MortarDamage = 0.3;
   else if($Combat::MortarDamage > 2.0) $Combat::MortarDamage = 2.0;

   if(!$Combat::BlasterDamage) $Combat::BlasterDamage = 1.0;
   else if($Combat::BlasterDamage < 0.3) $Combat::BlasterDamage = 0.3;
   else if($Combat::BlasterDamage > 2.0) $Combat::BlasterDamage = 2.0;

   if(!$Combat::ElectricityDamage) $Combat::ElectricityDamage = 1.0;
   else if($Combat::ElectricityDamage < 0.3) $Combat::ElectricityDamage = 0.3;
   else if($Combat::ElectricityDamage > 2.0) $Combat::ElectricityDamage = 2.0;
   
   if(!$Combat::CrushDamage) $Combat::CrushDamage = 1.0;
   else if($Combat::CrushDamage < 0.3) $Combat::CrushDamage = 0.3;
   else if($Combat::CrushDamage > 2.0) $Combat::CrushDamage = 2.0;

   if(!$Combat::DebrisDamage) $Combat::DebrisDamage = 1.0;
   else if($Combat::DebrisDamage < 0.3) $Combat::DebrisDamage = 0.3;
   else if($Combat::DebrisDamage > 2.0) $Combat::DebrisDamage = 2.0;

   if(!$Combat::MissileDamage) $Combat::MissileDamage = 1.0;
   else if($Combat::MissileDamage < 0.3) $Combat::MissileDamage = 0.3;
   else if($Combat::MissileDamage > 2.0) $Combat::MissileDamage = 2.0;

   if(!$Combat::MineDamage) $Combat::MineDamage = 1.0;
   else if($Combat::MineDamage < 0.3) $Combat::MineDamage = 0.3;
   else if($Combat::MineDamage > 2.0) $Combat::MineDamage = 2.0;

   if($Combat::DamageMode == "low") $Combat::DamageScale = $Combat::LowDamageScale;
   else if($Combat::DamageMode == "normal") $Combat::DamageScale = 1.0;
   else if($Combat::DamageMode == "high") $Combat::DamageScale = $Combat::HighDamageScale;

   if($Combat::DamageMode == "custom")
   {
    echo("Damage Mode: custom");
    echo("Impact "@$Combat::ImpactDamage);
    echo("Landing "@$Combat::LandingDamage);
    echo("Bullet "@$Combat::BulletDamage);
    echo("Energy "@$Combat::EnergyDamage);
    echo("Plasma "@$Combat::PlasmaDamage);
    echo("Explosion "@$Combat::ExplosionDamage);
    echo("Shrapnel "@$Combat::ShrapnelDamage);
    echo("Laser "@$Combat::LaserDamage);
    echo("Mortar "@$Combat::MortarDamage);
    echo("Blaster "@$Combat::BlasterDamage);
    echo("Electricity "@$Combat::ElectricityDamage);
    echo("Crush "@$Combat::CrushDamage);
    echo("Debris "@$Combat::DebrisDamage);
    echo("Missile "@$Combat::MissileDamage);
    echo("Mine "@$Combat::MineDamage);
   }

   else echo("Damage Mode: "@ $Combat::DamageMode@" Low: "@$Combat::LowDamageScale@" High: "@$Combat::HighDamageScale@" Current: "@$Combat::DamageScale);
}

//****************
function Combat::setRespawnGear(%client)
{
 //prevents sniper gear in base mode
 if(!$matchStarted) $Combat::RespawnGear[%client] = "attack";

 if($Combat::RespawnGear[%client] != "attack" && $Combat::RespawnGear[%client] != "defense" &&
    $Combat::RespawnGear[%client] != "repair" && $Combat::RespawnGear[%client] != "sniper")
	$Combat::RespawnGear[%client] = "attack";

 if($Combat::NoSniperGear && $Combat::RespawnGear[%client] == "sniper") $Combat::RespawnGear[%client] = "attack";

 if($Combat::RespawnGear[%client] == "attack")
 {
  $spawnBuyList[0] = CombatArmor;
  $spawnBuyList[1] = EnergyRifle;
  $spawnBuyList[2] = AssaultRifle;
  $spawnBuyList[3] = Disclauncher;
  $spawnBuyList[4] = PlasmaGun;
  $spawnBuyList[5] = RepairKit;
  $spawnBuyList[6] = EnergyPack;
  $spawnBuyList[7] = Grenade;
  $spawnBuyList[8] = MineAmmo;
  $spawnBuyList[9] = Beacon;
  //$spawnBuyList[10] = Special;
  $spawnBuyList[10] = "";
 }
 else if($Combat::RespawnGear[%client] == "defense")
 {
  $spawnBuyList[1] = GrenadeLauncher;
  $spawnBuyList[6] = ShieldPack;
 }
 else if($Combat::RespawnGear[%client] == "repair")
 {
  $spawnBuyList[1] = EnergyRifle;
  $spawnBuyList[6] = RepairPack;
 }
 else if($Combat::RespawnGear[%client] == "sniper")
 {
  $spawnBuyList[1] = SniperRifle;
  $spawnBuyList[6] = EnergyPack;
 }
}

//****************
function Combat::WarnTruce(%client)
{
 if($Combat::AlreadyWarned[%client])
  {
   $Combat::AlreadyWarned[%client] = false;
   return;
  }
 else $Combat::AlreadyWarned[%client] = true;

 if(($Game::missionType == "CTF" || $Game::missionType == "CTFb") && $Server::InitialTruce > 0 && $Server::Truce)
 {
  %time = $Server::InitialTruce - floor(getSimTime() / 60);
  if(%time > 0)
  {
   Client::sendMessage(%client,0,"A truce has been declared for "@%time@" minute(s).");
   Client::sendMessage(%client,0,"You may NOT touch the enemy flag during a truce!~wLeftMissionArea.wav");
  }
 }
}

//****************
function Combat::DisableItem(%name)
{
 $InvList[%name] = 0;
 $RemoteInvList[%name] = 0;
echo("Disabled: "@%name);
}

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
	if(Client::getGuiMode(%clientId) != $GuiModeCommand) remoteCommandMode(%clientId);
	else remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeInventory) remoteInventoryMode(%clientId);
	else remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeObjectives) remoteObjectivesMode(%clientId);
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
   %group = nameToID("MissionGroup/Teams/team"@%team@"/DropPoints/Random");
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
   %group = nameToID("MissionGroup\\Teams\\team"@%team@"\\DropPoints\\Start");
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
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	remoteEval(%cl, "setTime", -%time);
	BWAdmin_CheckPenaltyStatus(%cl);
   }
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

   //set up intial globals
   if(!$Server::MaxTeamKills) $Server::MaxTeamKills = 3;
   else if($Server::MaxTeamKills < 3) $Server::MaxTeamKills = 3;
echo("Team kill limit: "@$Server::MaxTeamKills);

   if(!$numValidTeams || $numValidTeams < 1) $numValidTeams = getNumTeams();

   //INV boot time
   if($Combat::autoINVBoot)
   {
    if(!$Combat::INVBootTime || $Combat::INVBootTime < 10) $Combat::INVBootTime = 10;
   }

   //DAMAGE MODE
   Combat::SetDamageMode();

   //SPECIALS
   if($Combat::JumpThruster != "low" && $Combat::JumpThruster != "normal" && $Combat::JumpThruster != "off") $Combat::JumpThruster = "normal"; 

   if($Combat::JumpThruster == "low")
   {
	$Combat::ForwardThrust = 300;
	$Combat::UpThrust = 350;
   }
   else
   {
	$Combat::ForwardThrust = 500;
	$Combat::UpThrust = 600;
   }
echo("Jump thruster "@$Combat::JumpThruster);

   //TRUCE CODE
   if($Server::ResetTruce)
   {
echo("Reset Truce "@$Server::NewTruce);
    $Server::Truce = true;
    $Server::InitialTruce = $Server::NewTruce;
	$Server::ResetTruce = false;
   }
   if($Server::Truce)
   {
    if(!$Server::InitialTruce) $Server::InitialTruce = 3;
	if($Server::InitialTruce > 10) $Server::InitialTruce = 10;
   }

   //Set the INV lists
   ResetInvLists();

   //Reset Special
   if($Combat::NoSpecial) $Combat::DisableSpecial = true;
   else $Combat::DisableSpecial = "";

   //base mode cleanup
   $Combat::NoSniperGear = "";
   $Combat::DisableWeaponMode = "";
   $TeamItemMax[TurretPack] = 6;
   $RemoteAmmoEnergy = 4000;
   $RemoteInvEnergy = 5000; 

	if($Combat::NoVehicles)
	{
     $VehicleInvList[ScoutVehicle] = 0;
     $VehicleInvList[SpeederVehicle] = 0;
     $VehicleInvList[HTVehicle] = 0;
     $VehicleInvList[LAPCVehicle] = 0;
     $VehicleInvList[HAPCVehicle] = 0;
     $VehicleInvList[BomberVehicle] = 0;
     Combat::DisableItem(VehicleBasePad);
     Combat::DisableItem(VehicleBaseControl);
	}
    if($Combat::NoTurrets)
    {
     Combat::DisableItem(LaserTurretPack);
     Combat::DisableItem(ChaingunTurret);
     Combat::DisableItem(SniperNest);
     Combat::DisableItem(RemoteAutoCannon);
     Combat::DisableItem(RemoteAACannon);
     Combat::DisableItem(RemotePlasmaTurret);
     Combat::DisableItem(MissileTurret);
     Combat::DisableItem(MRL);
     Combat::DisableItem(LongTom);
     Combat::DisableItem(RemoteELF);
    }
    if($Combat::NoEmplacements)
	{
     Combat::DisableItem(RemoteAutoCannon);
     Combat::DisableItem(RemoteAACannon);
     Combat::DisableItem(RemotePlasmaTurret);
     Combat::DisableItem(MissileTurret);
     Combat::DisableItem(MRL);
     Combat::DisableItem(LongTom);
	}
    if($Combat::NoStructures)
	{
     Combat::DisableItem(VehicleBasePad);
     Combat::DisableItem(VehicleBaseControl);
     Combat::DisableItem(FloatingPad);
     Combat::DisableItem(ShieldBeaconPack);
     Combat::DisableItem(EMPBeaconPack);
     Combat::DisableItem(EmplacementPack);
	}
    if($Combat::NoTeleports)
	{
     Combat::DisableItem(TeleportField);
     Combat::DisableItem(TeleportPad);
     Combat::DisableItem(RelocatePack);
	}
	if($Combat::NoTraps)
	{
     Combat::DisableItem(StealthMine);
     Combat::DisableItem(AntiArmorMine);
	}
	if($Combat::NoDrones)
	{
     Combat::DisableItem(DronePack);
     Combat::DisableItem(GuidedBombPack);
     Combat::DisableItem(SurveyDronePack);
     Combat::DisableItem(AttackDronePack);
	}

   messageAll(0, "Match started.");
   Game::resetScores();	

   %numTeams = $numValidTeams; //getNumTeams();
   for(%i = 0; %i < %numTeams; %i++) 
   {
	if($TeamEnergy[%i] != "Infinite") schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
   }

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	//REINIT RESPAWN GEAR
	$Combat::RespawnGear[%cl] = "attack"; // PORT: was the undefined %client

	//Reset weapon modes
	resetWeaponModes(%cl);

// - BW Admin Mod - Advanced console logging for stats tracking programs
      if($dedicated && $bwadmin::controlledTourneyMode && $Server::TourneyMode && $bwadmin::messageLog)
      {
         %name = Client::getName(%cl);
         %teamName = getTeamName(Client::getTeam(%cl));
         echo("BWADMINMSG (0): " @ %name @ " joined " @ %teamName);
      }
// - BW Admin Mod - End

	if(%cl.observerMode == "pregame") {
		%cl.observerMode = "";
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		Combat::WarnTruce(%cl);
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
   if(!$ghosting) return false;
   Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop

// - BW Admin Mod -
		if($bwadmin::noRape)
			%baserape = "ENABLED";
		else
			%baserape = "DISABLED";
		if($bwadmin::GlobalReverseDamageMode == "true")
			%globalrd = "ENABLED";
		else
			%globalrd = "DISABLED";
		if($bwadmin::AutoAntiTK == "true")
			%autotk = "ENABLED";
		else
			%autotk = "DISABLED";

  bottomprint(%clientId, "<jc><f0>This server is running: <f1>Strategic Combat 1.63 with BWAdmin " @ $bwadmin::version @ "\n\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @
  "\n<f0>No Base Rape Mode: <f1>" @ %baserape @ "    <f0>Global Reverse Damage Mode: <f1>" @ %globalrd @
  "\n<f0>Press <f1>'O'<f0> for specific objectives." @ 
  "\nSee <f1>www.geocities.com/garadon42/<f0> for more details.", 10);
// - BW Admin Mod - End

   if(!$Server::ResetTruce) Combat::WarnTruce(%clientId);

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

	if(!String::ICompare(Client::getGender(%clientId), "Male")) %armor = "carmor"; //"larmor";
	else %armor = "fcarmor";//"lfemale";

	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	if(%pl != -1)
	{
	 GameBase::setTeam(%pl, Client::getTeam(%clientId));
	 Client::setOwnedObject(%clientId, %pl);
	 Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
         if($Server::respawnInvulnerableTime && %respawn)
         {
            %damage = %armor.maxDamage - 0.001;
            GameBase::setEnergy(%pl, 0);
            GameBase::setDamageLevel(%pl, %damage);
            GameBase::setAutoRepairRate(%pl, %damage / $Server::respawnInvulnerableTime);
            %pl.invulnerable = true;
            
            schedule("incInvulnerable(" @ %pl @ ", 0);", 0, %pl);
		      %weapon = Player::getMountedItem(%pl,$WeaponSlot);
		      if(%weapon != -1) {
			      %pl.lastWeapon = %weapon;
			      Player::unMountItem(%pl,$WeaponSlot);
		      }
         }

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

function incInvulnerable(%player, %time)
{
   if(%time > $Server::respawnInvulnerableTime)
   {
      %player.invulnerable = "";
      GameBase::setAutoRepairRate(%player, 0);
	   if(%player.lastWeapon != "") {
		   Player::useItem(%player,%player.lastWeapon);
		   %player.lastWeapon = "";
      }
   }
   else
   {
      %t2 = %time * 2;
      if(%t2 & 2)
      {
         if((%t2) & 1)
            %vec = "0 -1 0";
         else
            %vec = "0 1 0";
      }
      else
      {
         if((%t2) & 1)
            %vec = "1 0 0";
         else
            %vec = "-1 0 0";
      }
      GameBase::activateShield(%player,%vec, 0);
      schedule("incInvulnerable(" @ %player @ ", "@ %time + 0.5 @ ");", 0.5, %player);
   }
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
	if(%clientId.customSkin)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	else
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

   %clientId.spawn= 1;
   %max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
    {
	    //Reset station autoboot
		%pl.stationBoot = "";
	    //SET RESPAWN GEAR
		Combat::setRespawnGear(%clientId);

		buyItem(%clientId,%item);	
		if(%item.className == Weapon) %clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") 
	{
echo("Spawn weapon: "@%clientId.spawnWeapon@" "@%clientId);
	if(Player::getMountedItem(%clientId,$WeaponSlot) == -1) Player::MountItem(%pl,%clientId.spawnWeapon,$WeaponSlot);
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

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   	if($Server::TourneyMode)
      	GameBase::setTeam(%clientId, -1);
   	else
   	{
// - BW Admin Mod - New Observer Mode
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit" )
// - BW Admin Mod - End
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
			// - BW Admin Mod -
         	if($bwadmin::controlledTourneyMode)
            	bottomprint(%clientId, "<jc><f0>This server is running Strategic Combat with BWAdmin " @ $bwadmin::version @ " by Poker.\n\n<f1>" @ $bwadmin::league @ " Match in progress, press TAB for options.", 8);
         	else
            	bottomprint(%clientId, "<jc><f0>This server is running Strategic Combat with BWAdmin " @ $bwadmin::version @ " by Poker.\n\n<f1>Match in progress, press TAB for options.", 8);
         	%clientId.observerMode = "observerFly";
         	%clientId.justConnected = "";
         	return;
      	}
      	else if($Server::TourneyMode)
      	{
			if($bwadmin::controlledTourneyMode)
			{
				for(%i = 0; %i < getNumTeams(); %i = %i + 1)
				{
			   		if($Client::info[%clientId, 3] == "[press]")
					{
						processMenuInitialPickTeam(%clientId, -2);
						bottomprint(%clientId, "<jc><f0>This server is running BarrysWorld Admin Mod " @ $bwadmin::version @ " by Poker.\n\n<f1>Welcome to the " @ $bwadmin::league @ ".\nLeague Match Mode engaged - You were auto-assigned to observer!", 5);
						%clientId.justConnected = "";
						return;
					}
					if($Client::info[%clientId, 3] == getTeamName(%i))
					{
						processMenuInitialPickTeam(%clientId, %i);
						bottomprint(%clientId, "<jc><f0>This server is running BarrysWorld Admin Mod " @ $bwadmin::version @ " by Poker.\n\n<f1>Welcome to the " @ $bwadmin::league @ ".\nLeague Match Mode engaged - You were auto-assigned to the " @ getTeamName(%i) @ " team!", 5);
						%clientId.justConnected = "";
						return;
					}
				}
			bottomprint(%clientId, "<jc><f0>This server is running BarrysWorld Admin Mod " @ $bwadmin::version @ " by Poker.\n\n<f1>Welcome to the " @ $bwadmin::league @ ".\nLeague Match Mode engaged - Choose your tribe!", 0);
			}
			else
			   bottomprint(%clientId, "<jc><f0>This server is running BarrysWorld Admin Mod " @ $bwadmin::version @ " by Poker.\n\n<f1>Competition Mode engaged - Choose your tribe!", 0);
			// - BW Admin Mod - End
      	}
      	Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      	Client::addMenuItem(%clientId, "0Observe", -2);
      	if(!$Server::TourneyMode)
      	{
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			 	Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      	}
      	else
      	{
        	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
          		Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
      	}
		// - BW Admin Mod - End
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
   	bwadmin::checkRape();
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
      bottomprint(%clientId, "", 0);
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
   if($Server::TourneyMode && !$CountdownStarted && !$bwadmin::controlledTourneyMode)
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
   bwadmin::checkRape();
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
// - BW Admin Mod - Don't check if in controlled mode
   if($CountdownStarted || $matchStarted || $bwadmin::controlledTourneyMode)
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
	if(%client == "") 
	{
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	   {
	    %cl.scoreKills = 0;
   	    %cl.scoreDeaths = 0;
	    %cl.ratio = 0;
	    %cl.score = 0;
	    // - BWAdmin Mod -
	    %cl.tk = 0;
	    %cl.bk = 0;
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
	else if($TestCheats) Player::setArmor(%player, %armorType);
}


function Game::onPlayerConnected(%playerId)
{
// - BWAdmin Mod
        %playerId.tk = 0;
        %playerId.bk = 0;

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
            bwadmin::checkRape();
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

// Heh, randomiser for Cowboy
      for(%i = 0; %i < %numTeams; %i = %i + 1)
      {
         %score = %score + $teamScore[%i];
         if(%numTeamPlayers[%i] != %numTeamPlayers[0])
            %oddPlayers=true;
      }
      if($bwadmin::randomTeams && %score == 0 && !%oddPlayers)
      {
         %leastTeam = floor(getRandom() * %numTeams);
         GameBase::setTeam(%playerId, %leastTeam);
         echo(Client::getName(%playerId), " was randomly assigned to team ", %leastTeam);
         bwadmin::checkRape();
         return;
      }
// end randomiser

      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
   bwadmin::checkRape();
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
    echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);

    if ($bwadmin::killinfosent[%playerid] == "")
	$bwadmin::killinfosent[%playerid] = false;
    if (!$bwadmin::killinfosent[%playerid]) {
	for (%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	    if (%cl != -1) {
		bwadmin::isKillInfoActive(%cl, %killerid, %playerid,
					  %damageType);
	    }
	}
	$bwadmin::killinfosent[%playerid] = true;
	schedule("$bwadmin::killinfosent[" @ %playerid @ "] = false;", 1);
    }

    %playerId.guiLock = true;
    Client::setGuiMode(%playerId, $GuiModePlay);

    if (!String::ICompare(Client::getGender(%playerId), "Male"))
	%playerGender = "his";
    else
	%playerGender = "her";

    %ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
    %victimName = Client::getName(%playerId);

	// Experimental fix for damage messages by Dasher
    if (%victimName == "" && %killerId) {
	%victimName = Client::getName(%killerId);
    }

    if (!%killerId) {
	if (%damageType == $BulletDamageType || %damageType == $EnergyDamageType
	    || %damageType == $ExplosionDamageType
	    || %damageType == $LaserDamageType
	    || %damageType == $ElectricityDamageType
	    || %damageType == $MissileDamageType) %message =
		$deathMsg[%damageType, 4];
	else
	    %message = " dies.";
	messageAll(0, strcat(%victimName, %message), $DeathMessageMask);
	%playerId.scoreDeaths++;
    }
    else if (%killerId == %playerId) {
// - BWAdmin bug fix - props to NateDogg of HaVoC

      if(%damageType == $LandingDamageType)
         %oopsMsg = sprintf($deathMsg[0, %ridx], "", %victimName, %playerGender);
      else
         %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
// - BWAdmin - end bugfix

	messageAll(0, %oopsMsg, $DeathMessageMask);
	%playerId.scoreDeaths++;
	%playerId.score--;
	Game::refreshClientScore(%playerId);
    }
    else {
	if (!String::ICompare(Client::getGender(%killerId), "Male"))
	    %killerGender = "his";
	else
	    %killerGender = "her";

	if ($teamplay
	    && (Client::getTeam(%killerId) == Client::getTeam(%playerId))) {
	    if (%damageType != $MineDamageType) {
		messageAll(0,
			   strcat(Client::getName(%killerId), " mows down ",
				  %killerGender, " teammate, ", %victimName),
			   $DeathMessageMask);
	    centerprint(%playerId, "<jc>You have been TEAM KILLED by " @ Client::getName(%killerId), 3);
	    centerprint(%killerId, "<jc>You have just TEAM KILLED " @ Client::getName(%playerId), 3);

	    %killerId.scoreDeaths++;
	    %killerId.score--;
	    %killerId.tk++;

	    } else {
		messageAll(0,
			   strcat(Client::getName(%killerId), " killed ",
				  %killerGender, " teammate, ", %victimName,
				  " with a mine."), $DeathMessageMask);
	    }

// - BWAdmin Mod - anti-TK Code
	    if ($bwadmin::AutoAntiTK && %damageType != $MineDamageType
		&& !$Server::TourneyMode)
		BWAdmin_setTeamKill(%playerId, %killerId);

	    Game::refreshClientScore(%killerId);
	}
	else {
	    %obitMsg =
		sprintf($deathMsg[%damageType, %ridx],
			Client::getName(%killerId), %victimName, %killerGender,
			%playerGender);
	    messageAll(0, %obitMsg, $DeathMessageMask);
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
   // do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the flag arena.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the flag arena.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

