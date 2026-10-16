//multi laser turret
$TeamItemMax[ShockTurretPack] = 2;
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

LaserData MburstLaser
{
   laserBitmapName   = "fx_lensflare_0.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.04;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData ShockTurretPackImage 
{
  shapeFile = "indoorgun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData ShockTurretPack 
{
  description = "Multi Laser Turret";
  shapeFile = "indoorgun";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = ShockTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3500;
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
  if (Turret::deployShape(%player, "MBurst Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableShockTurret, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableShockTurret 
{
  className = "Turret";
  shapeFile = "indoorgun";
  projectileType = MburstLaser;
  maxDamage = 0.60;
  maxEnergy = 200;
  minGunEnergy = 5;
  maxGunEnergy = 20;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.5;
  speed = 4.0;
  speedModifier = 1.5;
  range = 50;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFireLaser;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Multi Laser Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableShockTurret::onAdd(%this) 
{
  schedule("DeployableShockTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,6);
  %this.shieldStrength = 0.010;
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
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

