//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Scatter Las Turret, modded from Shock Turret
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[ShockTurretPack] = 1;
$InvList[ShockTurretPack] = 1;
$RemoteInvList[ShockTurretPack] = 1;

$CanAlwaysTeamDestroy[DeployableShockTurret] = 1;

function deployShockTurret::Initialize()
{
  $TeamItemCount[0 @ ShockTurretPack] = 0;
  $TeamItemCount[1 @ ShockTurretPack] = 0;
  $TeamItemCount[2 @ ShockTurretPack] = 0;
  $TeamItemCount[3 @ ShockTurretPack] = 0;
  $TeamItemCount[4 @ ShockTurretPack] = 0;
  $TeamItemCount[5 @ ShockTurretPack] = 0;
  $TeamItemCount[6 @ ShockTurretPack] = 0;
  $TeamItemCount[7 @ ShockTurretPack] = 0;
}

LaserData SniperLaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.015;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
 //-=-=-=-

ItemImageData ShockTurretPackImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 5.5;
  firstPerson = false;
};

ItemData ShockTurretPack
{
  description = "Scatter Las Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = ShockTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 2650;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function ShockTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function ShockTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Scatter Las Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableShockTurret, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}

function ShockTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Scatter Las Turret is a display of the superior technology the eldar possess..");
}
 //-=-=-=-

TurretData DeployableShockTurret
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = SniperLaser;
  maxDamage = 1.65;
  maxEnergy = 260;
  minGunEnergy = 5;
  maxGunEnergy = 10;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.05;
  speed = 4.0;
  speedModifier = 1.5;
  range = 105;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundRemoteTurretFire;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Scatter Las Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableShockTurret::onAdd(%this)
{
  schedule("DeployableShockTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Scatter Las Turret");
}

function DeployableShockTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableShockTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableShockTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "ShockTurretPack"]--;
}

function DeployableShockTurret::onPower(%this,%power,%generator) 
{
}

function DeployableShockTurret::onEnabled(%this)
{
  GameBase::setRechargeRate(%this,25);
  GameBase::setActive(%this,true);
}

