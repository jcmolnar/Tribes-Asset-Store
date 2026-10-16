$ItemMax[armormSniper, RailTurretPack] = 0;
$ItemMax[armorfSniper, RailTurretPack] = 0;
$ItemMax[armormScout, RailTurretPack] = 0;
$ItemMax[armormMercenary, RailTurretPack] = 0;
$ItemMax[armorfMercenary, RailTurretPack] = 0;
$ItemMax[armormBurster, RailTurretPack] = 0;
$ItemMax[armorCyborg, RailTurretPack] = 0;
$ItemMax[armorfScout, RailTurretPack] = 0;
$ItemMax[armorfBurster, RailTurretPack] = 0;
$ItemMax[armormSpy, RailTurretPack] = 0;
$ItemMax[armorfSpy, RailTurretPack] = 0;
$ItemMax[armormEngineer, RailTurretPack] = 0;
$ItemMax[armorfEngineer, RailTurretPack] = 0;
$ItemMax[armormAlien, RailTurretPack] = 0;
$ItemMax[armorfAlien, RailTurretPack] = 0;
$ItemMax[dmarmor, RailTurretPack] = 0;
$ItemMax[dmfemale, RailTurretPack] = 0;
$ItemMax[armormLoader, RailTurretPack] = 1;
$ItemMax[armorfLoader, RailTurretPack] = 1;
$ItemMax[armormSprint, RailTurretPack] = 0;
$ItemMax[armorfSprint, RailTurretPack] = 0;


$TeamItemMax[RailTurretPack] = 3;
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

ItemData RailTurretPack 
{
  description = "Railgun Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = RailTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 850;
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

function RailTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Rail Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableRailTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

function RailTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Rail Turret has no auto-sensor and must be controlled manually to fire.");
}

 //-=-=-=-

TurretData DeployableRailTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = railLaser;
  maxDamage = 1.0;
  maxEnergy = 155;
  minGunEnergy = 100;
  maxGunEnergy = 150;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 8.0;
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
  description = "Rail Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableRailTurret::onAdd(%this) 
{
  schedule("DeployableRailTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,20);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Rail Turret");
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
  GameBase::setRechargeRate(%this,20);
  GameBase::setActive(%this,true);
}
