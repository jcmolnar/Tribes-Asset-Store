//irradiation turret
$TeamItemMax[VulcanTurretPack] = 2;
$InvList[VulcanTurretPack] = 1;
$RemoteInvList[VulcanTurretPack] = 1;

$CanControl[VulcanTurret] = 1;
$EmbedController[VulcanTurret] = 1;
$CanAlwaysTeamDestroy[VulcanTurret] = 1;

 //-=-=-=-

function deployVulcanTurret::Initialize()
{
  $TeamItemCount[0 @ VulcanTurretPack] = 0;
  $TeamItemCount[1 @ VulcanTurretPack] = 0;
  $TeamItemCount[2 @ VulcanTurretPack] = 0;
  $TeamItemCount[3 @ VulcanTurretPack] = 0;
  $TeamItemCount[4 @ VulcanTurretPack] = 0;
  $TeamItemCount[5 @ VulcanTurretPack] = 0;
  $TeamItemCount[6 @ VulcanTurretPack] = 0;
  $TeamItemCount[7 @ VulcanTurretPack] = 0;
}

 //-=-=-=-

ItemImageData VulcanTurretPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData VulcanTurretPack
{
  description = "Irradiation Cannon";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = VulcanTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3050;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function VulcanTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function VulcanTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Irradiation Turret (" @ Client::getName(Player::getClient(%player)) @ ")", VulcanTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

BulletData ShotgunTurrBlast
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = debrisExpSmall;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 5.0;
   damageValue        = 0.2;
   baseDamageType     = $SniperDamageType;
   aimDeflection      = 0.0004;
   muzzleVelocity     = 180.0;
   totalTime          = 2;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
   
};

TurretData VulcanTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = ShotgunTurrBlast;
  accuFire = true;
  maxDamage = 1.0;
  maxEnergy = 200;
  minGunEnergy = 1;
  maxGunEnergy = 1;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.05;
  aimDeflection = 0.0004;
  speed = 4.0;
  speedModifier = 1.5;
  range = 125;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFireMortar;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Irradiation Cannon";
  damageSkinData = "objectDamageSkins";
};

function VulcanTurret::onAdd(%this) 
{
  schedule("VulcanTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,10);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Bolter Turret");
}

function VulcanTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function VulcanTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function VulcanTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
//  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurret"]--;
}

function VulcanTurret::onPower(%this,%power,%generator) 
{
}

function VulcanTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,10);
  GameBase::setActive(%this,true);
}
