//frag gren turr.

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


BulletData FGBolt
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   explosionRadius    = 5.0;
   damageClass        = 1;
   damageValue        = 0.4;
   baseDamageType     = $ExplosionDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.5;
   liveTime           = 1.5;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

//   rotationPeriod = 1;
};
 //-=-=-=-

ItemImageData ElecTurretPackImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData ElecTurretPack
{
  description = "Frag Gren Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = ElecTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 350;
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
  if (Turret::deployShape(%player, "Frag Gren Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableElecTurret, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableElecTurret
{
  className = "Turret";
  shapeFile = "chainturret";
  projectileType = FGBolt;
  maxDamage = 0.65;
  maxEnergy = 120;
  minGunEnergy = 4;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.25;
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
  explosionId = flashExpMedium;
  description = "Frag Gren Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableElecTurret::onAdd(%this)
{
  schedule("DeployableElecTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Electron Turret");
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
}

function DeployableElecTurret::onEnabled(%this)
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

