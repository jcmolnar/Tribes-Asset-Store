//ORIGINAL cREATION
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Particle Blast Turret
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//  Depends on:
//    Turret.cs
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$TeamItemMax[ElecTurretPack] = 4;
$InvList[ElecTurretPack] = 1;
$RemoteInvList[ElecTurretPack] = 1;

$CanAlwaysTeamDestroy[DeployableElecTurret] = 1;

 //-=-=-=-

function deployElecTurret::Initialize()
{
  $TeamItemCount[0 @ ElecTurretPack] = 0;
  $TeamItemCount[1 @ ElecTurretPack] = 0;
  $TeamItemCount[2 @ ElecTurretPack] = 0;
  $TeamItemCount[3 @ ElecTurretPack] = 0;
  $TeamItemCount[4 @ ElecTurretPack] = 0;
  $TeamItemCount[5 @ ElecTurretPack] = 0;
  $TeamItemCount[6 @ ElecTurretPack] = 0;
  $TeamItemCount[7 @ ElecTurretPack] = 0;
}


BulletData PartBlast 
{
 bulletShapeName = "paint.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.12;
  damageType = $BlasterDamageType;
  explosionRadius = 4.0;
  kickBackStrength = 15.0;
  muzzleVelocity = 872.0;
  totalTime = 10;
  liveTime = 10;
  lightRange = 5.0;
  lightColor = 
  {
    0.4, 0.4, 1.0 }
  ;
  inheritedVelocityScale = 0.5;
}
;

 //-=-=-=-

ItemImageData ElecTurretPackImage
{
  shapeFile = "indoorgun";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData ElecTurretPack
{
  description = "Particle Blast Turr.";
  shapeFile = "indoorgun";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = ElecTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 335;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function ElecTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function ElecTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Particle Blast Turr. (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableElecTurret, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}

function ElecTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The particle blast turret fires charged bolts of deadly energy at supersonic speed.");
}
function ElecTurretPack::onActivate(%player,%item)
{
	centerprintAll("***WARNING: BIO-CANNON FIRED***", 10);
}
 //-=-=-=-

TurretData DeployableElecTurret
{
  className = "Turret";
  shapeFile = "indoorgun";
  projectileType = PartBlast;
  maxDamage = 0.75;
  maxEnergy = 100;
  minGunEnergy = 5;
  maxGunEnergy = 2;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.2;
  speed = 4.0;
  speedModifier = 1.5;
  range = 70;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFirePlasma;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = LargeShockwave;
  description = "Particle Blast Turr.";
  damageSkinData = "objectDamageSkins";
};

function DeployableElecTurret::onAdd(%this)
{
  schedule("DeployableElecTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.01;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Particle Blast");
}

function DeployableElecTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableElecTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableElecTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "ElecTurretPack"]--;
}

function DeployableElecTurret::onPower(%this,%power,%generator) 
{
//Turret::onPower(%this,%power,%generator)
}

function DeployableElecTurret::onEnabled(%this)
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}


