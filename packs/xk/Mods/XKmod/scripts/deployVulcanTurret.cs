$ItemMax[armormSniper, VulcanTurretPack] = 0;
$ItemMax[armorfSniper, VulcanTurretPack] = 0;
$ItemMax[armormScout, VulcanTurretPack] = 0;
$ItemMax[armormMercenary, VulcanTurretPack] = 0;
$ItemMax[armorfMercenary, VulcanTurretPack] = 0;
$ItemMax[armormBurster, VulcanTurretPack] = 0;
$ItemMax[armorCyborg, VulcanTurretPack] = 0;
$ItemMax[armorfScout, VulcanTurretPack] = 0;
$ItemMax[armorfBurster, VulcanTurretPack] = 0;
$ItemMax[armormSpy, VulcanTurretPack] = 0;
$ItemMax[armorfSpy, VulcanTurretPack] = 0;
$ItemMax[armormEngineer, VulcanTurretPack] = 0;
$ItemMax[armorfEngineer, VulcanTurretPack] = 0;
$ItemMax[armormAlien, VulcanTurretPack] = 0;
$ItemMax[armorfAlien, VulcanTurretPack] = 0;
$ItemMax[dmarmor, VulcanTurretPack] = 0;
$ItemMax[armormLoader, VulcanTurretPack] = 1;
$ItemMax[armorfLoader, VulcanTurretPack] = 1;
$ItemMax[dmfemale, VulcanTurretPack] = 0;
$ItemMax[armormSprint, VulcanTurretPack] = 0;
$ItemMax[armorfSprint, VulcanTurretPack] = 0;


$TeamItemMax[VulcanTurretPack] = 3;
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
  description = "Vulcan Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = VulcanTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 750;
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
  if (Turret::deployShape(%player, "Vulcan Turret (" @ Client::getName(Player::getClient(%player)) @ ")", VulcanTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

function VulcanTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Vulcan Turret has no auto-sensor and must be controlled manually to fire.");
}

 //-=-=-=-

TurretData VulcanTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = TurretBullet;
  accuFire = false;
  maxDamage = 1.0;
  maxEnergy = 200;
  minGunEnergy = 4;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.001;
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
  fireSound = SoundFireMortar;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Vulcan Turret";
  damageSkinData = "objectDamageSkins";
};

function VulcanTurret::onAdd(%this) 
{
  schedule("VulcanTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,10);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Vulcan Turret");
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
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
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
