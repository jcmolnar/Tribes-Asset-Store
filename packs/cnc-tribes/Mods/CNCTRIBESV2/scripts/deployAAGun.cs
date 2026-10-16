//Gun Battery: Original creation <[DC]>Paladin
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

RocketData AAGunBolt
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.75;
  damageType = $DeathDamageType;
  explosionRadius = 15.0;
  kickBackStrength = 50.0;
  muzzleVelocity = 265.0;
  terminalVelocity = 265.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 2.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plastrail.dts";
  smokeDist = 0.0;
  soundId = SoundJetHeavy;
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
  description = "Gun Battery";
  shapeFile = "missileturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = AAPackImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 850;
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
  if (Turret::deployShape(%player, "Gun Battery (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableAAGun, %item, $TurretLocAnywhere))
    Player::decItemCount(%player,%item);
}
function AAPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Gun Battery: Firing powerful fusion rounds, this turret is an awesome blend of power and versatility.");
}

 //-=-=-=-

TurretData DeployableAAGun 
{
  className = "Turret";
  shapeFile = "missileturret";
  projectileType = AAGunBolt;
  maxDamage = 2.65;
  maxEnergy = 150;
  minGunEnergy = 45;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 1.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 65;
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
  description = "Gun Battery";
  damageSkinData = "objectDamageSkins";
};

function DeployableAAGun::onAdd(%this) 
{
  schedule("DeployableAAGun::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.013;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Gun Battery");
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
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "AAPack"]--;
}

function DeployableAAGun::onPower(%this,%power,%generator) 
{
}

function DeployableAAGun::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,20);
  GameBase::setActive(%this,true);
}

