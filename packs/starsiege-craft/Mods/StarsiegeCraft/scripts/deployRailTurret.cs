//heavy beam turret
$TeamItemMax[RailTurretPack] = 2;
$InvList[RailTurretPack] = 1;
$RemoteInvList[RailTurretPack] = 1;

$CanControl[DeployableRailTurret] = 1;
$EmbedController[DeployableRailTurret] = 1;
$CanAlwaysTeamDestroy[DeployRailTurret] = 1;

function deployRailTurret::Initialize()
{
  $TeamItemCount[0 @ RailTurretPack] = 0;
  $TeamItemCount[1 @ RailTurretPack] = 0;
  $TeamItemCount[2 @ RailTurretPack] = 0;
  $TeamItemCount[3 @ RailTurretPack] = 0;
  $TeamItemCount[4 @ RailTurretPack] = 0;
  $TeamItemCount[5 @ RailTurretPack] = 0;
  $TeamItemCount[6 @ RailTurretPack] = 0;
  $TeamItemCount[7 @ RailTurretPack] = 0;
}

ItemImageData RailTurretPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

LaserData SnipeHLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.03;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemData RailTurretPack 
{
  description = "Heavy Burst Laser";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = RailTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3050;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function RailTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function RailTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Heavy Laser <f6>must be controlled from a command station to fire.");
}

function RailTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Heavy Burst Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableRailTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableRailTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = SnipeHLaser;
  maxDamage = 2.0;
  maxEnergy = 50;
  minGunEnergy = 49;
  maxGunEnergy = 50;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 6.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 0;
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
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Heavy Burst Laser";
  damageSkinData = "objectDamageSkins";
};

function DeployableRailTurret::onAdd(%this) 
{
  schedule("DeployableRailTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,7);
  %this.shieldStrength = 0.001;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Las Turret");
}

function DeployableRailTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableRailTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableRailTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "RailTurretPack"]--;
}

function DeployableRailTurret::onPower(%this,%power,%generator) 
{
}

function DeployableRailTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,7);
  GameBase::setActive(%this,true);
}
