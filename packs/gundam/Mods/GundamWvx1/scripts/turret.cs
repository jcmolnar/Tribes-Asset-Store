//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 25;    //Define Max Length of the area
$TurretBoxMaxWidth =  25;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 9;	  //Define Min Length from another turret
$TurretBoxMinWidth =  9;	  //Define Min Width from another turret
$TurretBoxMinHeight = 5;    //Define Min Height from another turret

RocketData TurretCycMissile
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = rocketexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   totalTime        = 4.0;
   liveTime         = 4.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "HFlame.dts";
   smokeDist   = 0.5;

};

RocketData GBTurCharge
{
   bulletShapeName   = "fusionbolt.dts";
   explosionTag      = turretExp;
   damageType        = 1;
   damageValue       = 0.6;
   explosionRadius   = 5.0;
   baseDamageType    = $MortarDamageType;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0, 0.75 };
   muzzleVelocity    = 250.0;
   terminalVelocity  = 250.0;
   inheritedVelocityScale = 1.0;
   detachFromShooter = false;
   trailType         = 2;
   trailString       = "shield.dts";
   smokeDist         = 30;
};

TurretData PlasmaTurret
{
  maxDamage = 1.0;
  maxEnergy = 200;
  minGunEnergy = 5;
  maxGunEnergy = 6;
  reloadDelay = 0.8;
  fireSound = SoundPlasmaTurretFire;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  range = 150;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = defaultDebrisMedium;
  className = "Turret";
  shapeFile = "hellfiregun";
  shieldShapeName = "shield_medium";
  speed = 2.0;
  speedModifier = 2.0;
  projectileType = GBTurCharge;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = PlasmaExp;
  description = "Fusion Turret";
};

LightningData Elfturrcharge
{
   bitmapName       = "red_blink1.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 45.0;
   damagePerSec      = 0.6;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.3;//10;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

TurretData ELFTurret
{
  maxDamage = 1.0;
  maxEnergy = 150;
  minGunEnergy = 50;
  maxGunEnergy = 5;
  range = 60;
  visibleToSensor = true;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = defaultDebrisMedium;
  className = "ELF Turret";
  shapeFile = "chainturret";
  shieldShapeName = "shield";
  speed = 5.0;
  speedModifier = 1.5;
  projectileType = Elfturrcharge;
  reloadDelay = 0.3;
  explosionId = LargeShockwave;
  description = "Electron Turret";
  fireSound = SoundGeneratorPower;
  activationSound = SoundChainTurretOn;
  deactivateSound = SoundChainTurretOff;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  isSustained = true;
  firingTimeMS = 750;
  energyRate = 30.0;
};

SeekingMissileData CycTurrMis
{
   bulletShapeName = "mortar.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 20.0;
   kickBackStrength = 200.0;

   muzzleVelocity    = 130.0;
   terminalVelocity  = 130.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 20;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

};

TurretData RocketTurret 
{
  maxDamage = 0.75;
  maxEnergy = 100;
  minGunEnergy = 20;
  maxGunEnergy = 20;
  range = 150;
  gunRange = 350;
  visibleToSensor = true;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = defaultDebrisLarge;
  className = "Turret";
  shapeFile = "missileturret";
  shieldShapeName = "shield_medium";
  speed = 2.0;
  speedModifier = 2.0;
  projectileType = CycTurrMis;
  fireSound = SoundMissileTurretFire;
  activationSound = SoundMissileTurretOn;
  deactivateSound = SoundMissileTurretOff;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  targetableFovRatio = 0.5;
  explosionId = LargeShockwave;
  description = "Irradiation Turret";
};

function RocketTurret::onPower(%this,%power,%generator) 
{
  if (%power) 
  {
    %this.shieldStrength = 0.03;
    GameBase::setRechargeRate(%this,14);
  }
  else 
  {
    %this.shieldStrength = 0;
    GameBase::setRechargeRate(%this,0);
    Turret::disengageOperator(%this);
  }
  GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target) 
{
  if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
  else return "False";
}

GrenadeData MortTurrCyc
{
  bulletShapeName = "liqcyl.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 2.0;
  damageType = $MortarDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokename = "LFlame.dts";
  smokeDist = 2.0;
};

TurretData MortarTurret 
{
  maxDamage = 1.0;
  maxEnergy = 45;
  minGunEnergy = 45;
  maxGunEnergy = 100;
  reloadDelay = 2.0;
  fireSound = SoundMortarTurretFire;
  activationSound = SoundMortarTurretOn;
  deactivateSound = SoundMortarTurretOff;
  whirSound = SoundMortarTurretTurn;
  range = 0;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = defaultDebrisMedium;
  className = "Turret";
  shapeFile = "mortar_turret";
  shieldShapeName = "shield_medium";
  speed = 2.0;
  speedModifier = 2.0;
  projectileType = MortTurrCyc;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "Fusion Grenade Turret";
};

BulletData indoorProtoss
{
   bulletShapeName   = "paint.dts";
   explosionTag      = energyexp;
   damageType        = 0;
   damageValue       = 0.8;
   aimDeflection     = 0.0004;
   baseDamageType    = $BlasterDamageType;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.5, 1 };
   muzzleVelocity    = 100.0;
   terminalVelocity  = 100.0;
   inheritedVelocityScale = 1.0;
   detachFromShooter = false;
   trailType         = 1;
   trailLength       = 300;
   trailWidth        = 1.0;
};

TurretData IndoorTurret 
{
  className = "Turret";
  shapeFile = "indoorgun";
  projectileType = indoorProtoss;
  maxDamage = 2.5;
  maxEnergy = 100;
  minGunEnergy = 1;
  maxGunEnergy = 2;
  reloadDelay = 0.2;
  speed = 5.0;
  speedModifier = 1.0;
  range = 50;
  visibleToSensor = true;
  dopplerVelocity = 2;
  castLOS = true;
  supression = false;
  supressable = false;
  pinger = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = defaultDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundEnergyTurretFire;
  activationSound = SoundEnergyTurretOn;
  deactivateSound = SoundEnergyTurretOff;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = debrisExpMedium;
  description = "Beam Turret";
};

 //-=-=-=-

$TurretStatusIdle = 0;
$TurretStatusRecalibrating = 1;
$TurretStatusAlert = 2;

function Turret::onAdd(%this) 
{
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Turret");
}

function Turret::onActivate(%this) 
{

  GameBase::playSequence(%this,0,power);
  %this.Status = $TurretStatusIdle;
}

function Turret::onDeactivate(%this) 
{
  GameBase::stopSequence(%this,0);
  Turret::disengageOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam) 
{
   // If team change was not controlled by the turret logic 
   // then assume objective was taken an force OrgTeam over.
  if (!%this.ControlledTeamChange)
    %this.OrgTeam = GameBase::getTeam(%this);
  else
    %this.ControlledTeamChange = False;

   // If the turret's team and the controllers team do not match
   // then spit the controller out.
  if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
    Turret::disengageOperator(%this);
}

function Turret::disengageOperator(%this) 
{
   // Basically spit any controllers out of the turret
  %cl = GameBase::getControlClient(%this); // get client from turret
  if (%cl != -1) 
  {
    %player = Client::getOwnedObject(%cl); // get player from client
    if (%player.ManualCommandTag)
    {
      %player.ManualCommandTag = False;
      %player.CommandTag = "";
    }
    Player::setMountObject(%player, -1,0); // Unmount the player (obj=-1)
    Client::setControlObject(%cl, %player); // Specify that the client is controlling the player body
  }
//  Client::setGuiMode(%cl,2); -- Go to the command screen
}

function Turret::onPower(%this,%power,%generator) 
{
  if (%power) 
  {
    %this.shieldStrength = 0.03;
    GameBase::setRechargeRate(%this,10);
  }
  else 
  {
    %this.shieldStrength = 0;
    GameBase::setRechargeRate(%this,0);
    Turret::disengageOperator(%this);
  }
  GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this) 
{
  if (GameBase::isPowered(%this)) 
  {
    %this.shieldStrength = 0.03;
    GameBase::setRechargeRate(%this,10);
    GameBase::setActive(%this,true);
  }
}

function Turret::onDisabled(%this) 
{
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100);
}

function Turret::objectiveDestroyed(%this)
{
  //
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if(%this.objectiveLine) %this.lastDamageTeam = GameBase::getTeam(%object);
  %TDS= 1;
  if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
  {
    %name = GameBase::getDataName(%this);
    if (!$CanAlwaysTeamDestroy[%name])
      %TDS = $Server::TeamDamageScale;
  }
  StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onManualControl(%this, %player) 
{
   // When a player jumps in
  %client = Player::getClient(%player);

  %player.ManualCommandTag = True;
  %player.CommandTag = 1;
  Client::takeControl(%client, %this);

   // Move the player onto the turret if appropriate
  %name = GameBase::getDataName(%this);
  if ($EmbedController[%name])
    GameBase::SetPosition(%player, GameBase::GetPosition(%this));
}

function Turret::onDismount (%this, %object) 
{
   // When a player ceases to control the turret (either jump or stop control)
  %client = %object;
  Turret::disengageOperator(%this);
  %this.Status = $TurretStatusRecalibrating;
  schedule("Turret::onInternalDiagnostics(" @ %this @ ", " @ %object @ ");", 10, %this);
}

function Turret::Jump(%this, %mom) 
{
  %cl = GameBase::getControlClient(%this);
  Turret::onDismount(%this, %cl);
}

function Turret::onInternalDiagnostics(%this, %object)
{
   // Verify that we're on our original team
  if (GameBase::getTeam(%this) != %this.OrgTeam)
  {
    %this.Status = $TurretStatusAlert;
    GameBase::setTeam(%this, %this.OrgTeam);  
     // Spend additional time in alert if we had to correct our team
    schedule("Turret::onReturnToIdle(" @ %this @ ");", 10, %this);
  }
  else 
    Turret::onReturnToIdle(%this);
}

function Turret::onReturnToIdle(%this)
{
  %this.Status = $TurretStatusIdle;
}

function Turret::onCollision (%this, %object)
{
  %client = Player::getClient(%object);
  if (%this.CommandTag) return;

  %name = GameBase::getDataName(%this);
  if (getObjectType(%object) != "Player" || !$CanControl[%name]) return;

   // Still standing in the turret?
  if (GameBase::GetPosition(%this) == GameBase::GetPosition(%object)) return;

   // Verify the status of the turret
  if (Player::getMountedItem(%object,$BackpackSlot) == Laptop)
  {
    if (%this.Status == $TurretStatusRecalibrating)
    {
       Laptop::Error(%client, "Turret is recalibrating.");
       return;
    }
    else if (%this.Status == $TurretStatusAlert)
    {
       Laptop::Error(%client, "Turret is on alert.");
       return;
    }
  }
  else
  {
    if (%this.Status != $TurretStatusIdle)
    {
       Client::sendMessage(%client,0,"Turret is recharging.");
       return;
    }
  }

  if (GameBase::getTeam(%object) != GameBase::getTeam(%this))
  {
     // If the player has a laptop, then they can control anything
    if (Player::getMountedItem(%object,$BackpackSlot) != Laptop)
    {
      Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team.~waccess_denied.wav");
      return;
    }

     // Team change the turret (internal diagnostics will change it back once dismounted)
    %this.OrgTeam = GameBase::getTeam(%this);
    %this.ControlledTeamchange = True;
    GameBase::setTeam(%this, GameBase::getTeam(%client));

    Turret::onManualControl(%this, %object);
    Laptop::Output(%client, "Successful patch into enemy turret.");
  }
  else // Normal non-laptop connection to team turret
  {
    Turret::onManualControl(%this, %object);
    Client::sendMessage(%client, 0, "Manually controlling turret");
  }
}

function Turret::onAttemptControl(%this, %client)
{
   // If you're controlling via a Command station, this is the first entry into
   // Turret.  If you're running through collision, this is called above.
  %player = Client::getOwnedObject(%client);
  %name = GameBase::getDataName(%this);

   // Run some final checks
  if (!%player.CommandTag && !$CanAlwaysControl[%name])
  {
    if (Player::getMountedItem(%player, $BackpackSlot) != Laptop) 
    { 
      Client::SendMessage(%client, 0, "Need laptop or Command Station.");
      return;
    }
  }

   // Actually control the turret
  Client::setControlObject(%client, %this);
  Client::setGuiMode(%client, $GuiModePlay);
}

$TurretLocGroundOnly = 0;
$TurretLocAnywhere = 1;

function CountTurrets(%set,%num) 
{
  %count = 0;
  for(%i=0; %i < %num; %i++)
  {
    %obj=GameBase::getDataName(Group::getObject(%set,%i));
    if (%obj.ClassName == Turret && %obj.Range > 0) %count++;
  }
  return %count;
}

function Turret::deployShape(%player, %name, %shape, %item, %validloc)
{
  %client = Player::getClient(%player);

  if ($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
  { Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return; }

  if (!GameBase::getLOSInfo(%player, 3))
  { Client::sendMessage(%client,0,"Deploy position out of range"); return; }

  %obj = getObjectType($los::object);
  if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj == "DeployablePlatform")   
  { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return; }

  if (!GameBase::testPosition(%player, vector::add($los::position, "0 0 1")) && %validloc == $TurretLocGroundOnly)
  { Client::sendMessage(%client,0,"Turret does not fit there"); return; }

   // Check long range count (not applicable to manual turrets)
  if (%shape.Range > 0)
  {
    %set = newObject("set",SimSet);
    %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
    %num = CountTurrets(%set, %num);
    deleteObject(%set);
    if (%num > $MaxNumTurretsInBox) 
    { Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); return; }
  }

   // Check short range count
  %set = newObject("set",SimSet);
  %num = containerBoxFillSet(%set, $StaticObjectType, $los::position, $TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
  %num = CountObjects(%set, %shape, %num);
  deleteObject(%set);
  if (%num) 
  { Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); return; }

   // Check slope of the floor
  if (%validloc == $TurretLocGroundOnly)
  {
    if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
    { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return; }
    %rot = GameBase::getRotation(%player);
  }
  else if (%validloc == $TurretLocAnywhere)
  {
    %prot = GameBase::getRotation(%player);
    %zRot = getWord(%prot,2);
    if (Vector::dot($los::normal,"0 0 1") > 0.6) 
      %rot = "0 0 " @ %zRot;
    else 
    {
      if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
        %rot = "3.14159 0 " @ %zRot;
      else 
        %rot = Vector::getRotation($los::normal);
    }
  }
  else
    return;

   // Make sure this isn't colliding with other objects
  if (!checkDeployArea(%client,$los::position)) 
  { return; }

   // Passed validations, deploy
  %obj = newObject("hellfiregun", "Turret", %shape, true);
  addToSet("MissionCleanup", %obj);
  GameBase::setTeam(%obj, GameBase::getTeam(%player));
  GameBase::setPosition(%obj, $los::position);
  GameBase::setRotation(%obj, %rot);
  Gamebase::setMapName(%obj, %name);
  Client::sendMessage(%client, 0, %item.description @ " deployed");
  playSound(SoundPickupBackpack,$los::position);
  $TeamItemCount[GameBase::getTeam(%player) @ %item]++;
  reportDeploy(%obj, %client);
  return true;
}
