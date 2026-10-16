//FGren Launcher
$TeamItemMax[AAPack] = 3;
$InvList[AAPack] = 1;
$RemoteInvList[AAPack] = 1;

$CanControl[DeployableAAGun] = 0;
$EmbedController[DeployableAAGun] = 0;
$CanAlwaysTeamDestroy[DeployableAAGun] = 1;

function deployAAGun::Initialize()
{
  $TeamItemCount[0 @ AAPack] = 0;
  $TeamItemCount[1 @ AAPack] = 0;
  $TeamItemCount[2 @ AAPack] = 0;
  $TeamItemCount[3 @ AAPack] = 0;
  $TeamItemCount[4 @ AAPack] = 0;
  $TeamItemCount[5 @ AAPack] = 0;
  $TeamItemCount[6 @ AAPack] = 0;
  $TeamItemCount[7 @ AAPack] = 0;
}

GrenadeData mortFgren
{
  bulletShapeName = "Mortar.dts";
  explosionTag = grenadeExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.2;
  damageClass = 1;
  damageValue = 0.8;
  baseDamageType = $ShrapnelDamageType;
  explosionRadius = 15;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 3.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "shotgunex.dts";
  smokeDist = 1.0;
};

ItemImageData AAPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 3.0;
  firstPerson = false;
};

ItemData AAPack 
{
  description = "FGren Launcher";
  shapeFile = "missileturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = AAPackImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 1450;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function AAPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function AAPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "FGren Launcher (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableAAGun, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableAAGun 
{
  className = "Turret";
  shapeFile = "mortar_turret";
  projectileType = mortFgren;
  maxDamage = 2.65;
  maxEnergy = 200;
  minGunEnergy = 15;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 100;
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
  description = "FGren Launcher";
  damageSkinData = "objectDamageSkins";
};

//function DeployableAAGun::verifyTarget(%this,%target) 
//{
  //if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) return "True";
  //else return "False";
//}

function DeployableAAGun::onAdd(%this) 
{
  schedule("DeployableAAGun::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.015;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Anti-Air Gun");
}

function DeployableAAGun::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableAAGun::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableAAGun::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
//  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "AAPack"]--;
}

function DeployableAAGun::onPower(%this,%power,%generator) 
{
}

function DeployableAAGun::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,10);
  GameBase::setActive(%this,true);
}

