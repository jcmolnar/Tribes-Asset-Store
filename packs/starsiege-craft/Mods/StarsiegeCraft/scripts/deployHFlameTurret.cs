//flame turret
$TeamItemMax[HFlameTurretPack] = 2;
$InvList[HFlameTurretPack] = 1;
$RemoteInvList[HFlameTurretPack] = 1;

$CanControl[DeployableHFlameTurret] = 1;
$EmbedController[DeployableHFlameTurret] = 1;
$CanAlwaysTeamDestroy[DeployableHFlameTurret] = 1;

function deployHFlameTurret::Initialize()
{
  $TeamItemCount[0 @ HFlameTurretPack] = 0;
  $TeamItemCount[1 @ HFlameTurretPack] = 0;
  $TeamItemCount[2 @ HFlameTurretPack] = 0;
  $TeamItemCount[3 @ HFlameTurretPack] = 0;
  $TeamItemCount[4 @ HFlameTurretPack] = 0;
  $TeamItemCount[5 @ HFlameTurretPack] = 0;
  $TeamItemCount[6 @ HFlameTurretPack] = 0;
  $TeamItemCount[7 @ HFlameTurretPack] = 0;
}


RocketData TurretNapalm
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.5;
  baseDamageType = $PlasmaDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 40.0;
  terminalVelocity = 40.0;
  totalTime = 1.0;
  liveTime = 1.0;
  lightRange = 7.0;
  lightColor = { 2, 2, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundFirePlasma;
  trailType = 2;
  trailString = "plasmatrail.dts";
  smokeDist = 0.2;
};

ItemImageData HFlameTurretPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData HFlameTurretPack 
{
  description = "Flame Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = HFlameTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 650;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function HFlameTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function HFlameTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Flame Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableHFlameTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableHFlameTurret
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = TurretNapalm;
  maxDamage = 3.5;
  maxEnergy = 200;
  minGunEnergy = 10;
  maxGunEnergy = 6;
  sequenceSound[0] = {"deploy", SoundActivateMotionSensor };
  reloadDelay = 0.35;
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
  fireSound = SoundFirePlasma;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Flame Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableHFlameTurret::onAdd(%this) 
{
  schedule("DeployableHFlameTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.010;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Heavy Flame Turret");
}

function DeployableHFlameTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableHFlameTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableHFlameTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "HFlameTurretPack"]--;
}

function DeployableHFlameTurret::onPower(%this,%power,%generator) 
{
}

function DeployableHFlameTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

