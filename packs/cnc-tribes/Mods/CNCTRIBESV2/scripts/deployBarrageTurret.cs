$TeamItemMax[BarragePack] = 3;
$InvList[BarragePack] = 1;
$RemoteInvList[BarragePack] = 1;

$CanControl[DeployableBarrage] = 0;
$EmbedController[DeployableBarrage] = 0;
$CanAlwaysTeamDestroy[DeployableBarrage] = 1;

function deployBarrageTurret::Initialize()
{
  $TeamItemCount[0 @ BarragePack] = 0;
  $TeamItemCount[1 @ BarragePack] = 0;
  $TeamItemCount[2 @ BarragePack] = 0;
  $TeamItemCount[3 @ BarragePack] = 0;
  $TeamItemCount[4 @ BarragePack] = 0;
  $TeamItemCount[5 @ BarragePack] = 0;
  $TeamItemCount[6 @ BarragePack] = 0;
  $TeamItemCount[7 @ BarragePack] = 0;
}

SeekingMissileData MegaMissile 
{
  bulletShapeName = "rocket.dts";
  explosionTag = bulletExp0;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.3;
  damageType = $MissileDamageType;
  explosionRadius = 3.0;
  kickBackStrength = 75.0;
  muzzleVelocity = 72.0;
  totalTime = 6;
  liveTime = 6;
  seekingTurningRadius = 15;
  nonSeekingTurningRadius = 75.0;
  proximityDist = 1.5;
  smokeDist = 0.0;
  lightRange = 1.0;
  lightColor = 
  {
    0.4, 0.4, 1.0 }
  ;
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
}
;
function SeekingMissile::updateTargetPercentage(%target) 
{
  return GameBase::virtual(%target, "getHeatFactor");
}
ItemImageData BarragePackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 3.0;
  firstPerson = false;
};

ItemData BarragePack 
{
  description = "Barrage Launcher";
  shapeFile = "missileturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = BarragePackImage;
  shadowDetailMask = 4;
  mass = 6.0;
  elasticity = 0.2;
  price = 1050;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function BarragePack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function BarragePack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Barrage Launcher (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableBarrage, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}
function BarragePack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Barrage Turret is guaranteed to keep the enemy at bay, with its rapid firing krak missiles.");
}
 //-=-=-=-

TurretData DeployableBarrage 
{
  className = "Turret";
  shapeFile = "missileturret";
  projectileType = MegaMissile;
  maxDamage = 0.65;
  maxEnergy = 100;
  minGunEnergy = 5;
  maxGunEnergy = 10;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.55;
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
  fireSound = SoundMissileTurretFire;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Barrage Launcher";
  damageSkinData = "objectDamageSkins";
};

function DeployableBarrage::verifyTarget(%this,%target) 
{
  if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
  else return "False";
}

function DeployableBarrage::onAdd(%this) 
{
  schedule("DeployableBarrage::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.015;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Barrage Launcher");
}

function DeployableBarrage::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableBarrage::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableBarrage::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "BarragePack"]--;
}

function DeployableBarrage::onPower(%this,%power,%generator) 
{
}

function DeployableBarrage::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,15);
  GameBase::setActive(%this,true);
}

