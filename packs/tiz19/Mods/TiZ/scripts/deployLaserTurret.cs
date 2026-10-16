//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Las Turret
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[LaserTurretPack] = 40;
$InvList[LaserTurretPack] = 1;
$RemoteInvList[LaserTurretPack] = 1;

$CanAlwaysTeamDestroy[DeployableLaserTurret] = 1;

function deployLaserTurret::Initialize()
{
  $TeamItemCount[0 @ LaserTurretPack] = 0;
  $TeamItemCount[1 @ LaserTurretPack] = 0;
  $TeamItemCount[2 @ LaserTurretPack] = 0;
  $TeamItemCount[3 @ LaserTurretPack] = 0;
  $TeamItemCount[4 @ LaserTurretPack] = 0;
  $TeamItemCount[5 @ LaserTurretPack] = 0;
  $TeamItemCount[6 @ LaserTurretPack] = 0;
  $TeamItemCount[7 @ LaserTurretPack] = 0;
}

LaserData SnipeLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.017;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
ItemImageData LaserTurretPackImage 
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData LaserTurretPack 
{
  description = "Laser Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = LaserTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function LaserTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Laser Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableLaserTurret, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);

}

function LaserTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Laser Turret is a psycho defensive turret, it has limited range, but kicks ass for surprise defense.");
}


TurretData DeployableLaserTurret 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = SnipeLaser;
  maxDamage = 0.65;
  maxEnergy = 100;
  minGunEnergy = 10;
  maxGunEnergy = 40;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2;
  speed = 4.0;
  speedModifier = 1.5;
  range = 90;
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
  description = "Las Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableLaserTurret::onAdd(%this) 
{
  schedule("DeployableLaserTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Las Turret");
}

function DeployableLaserTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaserTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableLaserTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

function DeployableLaserTurret::onPower(%this,%power,%generator) 
{
}

function DeployableLaserTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,10);
  GameBase::setActive(%this,true);
}

