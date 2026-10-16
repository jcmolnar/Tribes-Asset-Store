//deployable plas turret
$TeamItemMax[PlasmaTurretPack] = 1;
$InvList[PlasmaTurretPack] = 1;
$RemoteInvList[PlasmaTurretPack] = 1;

$CanControl[DeployablePlasmaTurret] = 1;
$EmbedController[DeployablePlasmaTurret] = 1;
$CanAlwaysTeamDestroy[DeployablePlasmaTurret] = 1;

function deployPlasmaTurret::Initialize()
{
  $TeamItemCount[0 @ PlasmaTurretPack] = 0;
  $TeamItemCount[1 @ PlasmaTurretPack] = 0;
  $TeamItemCount[2 @ PlasmaTurretPack] = 0;
  $TeamItemCount[3 @ PlasmaTurretPack] = 0;
  $TeamItemCount[4 @ PlasmaTurretPack] = 0;
  $TeamItemCount[5 @ PlasmaTurretPack] = 0;
  $TeamItemCount[6 @ PlasmaTurretPack] = 0;
  $TeamItemCount[7 @ PlasmaTurretPack] = 0;
}

RocketData DepPlasCharge
{
   bulletShapeName   = "shield.dts";
   explosionTag      = DebrisExpMedium;
   damageType        = 1;
   damageValue       = 0.8;
   explosionRadius   = 5.0;
   baseDamageType    = $TurretDamageType;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0, 0.75 };
   muzzleVelocity    = 180.0;
   terminalVelocity  = 180.0;
   inheritedVelocityScale = 1.0;
   detachFromShooter = false;
   trailType         = 2;
   trailString       = "shotgunex.dts";
   smokeDist         = 0.6;
};


ItemImageData PlasmaTurretPackImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData PlasmaTurretPack 
{
  description = "Plasma Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = PlasmaTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function PlasmaTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Plasma Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployablePlasmaTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployablePlasmaTurret
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = DepPlasCharge;
  maxDamage = 0.5;
  maxEnergy = 50;
  minGunEnergy = 1;
  maxGunEnergy = 6;
  sequenceSound[0] = {"deploy", SoundActivateMotionSensor };
  reloadDelay = 0.8;
  speed = 4.0;
  speedModifier = 1.5;
  range = 1;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundPlasmaTurretFire;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Plasma Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployablePlasmaTurret::onAdd(%this) 
{
  schedule("DeployablePlasmaTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.010;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Plasma Turret");
}

function DeployablePlasmaTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasmaTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployablePlasmaTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
//  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

function DeployablePlasmaTurret::onPower(%this,%power,%generator) 
{
}

function DeployablePlasmaTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}
