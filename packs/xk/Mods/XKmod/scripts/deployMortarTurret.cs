$ItemMax[armormSniper, MortarTurretPack] = 0;
$ItemMax[armorfSniper, MortarTurretPack] = 0;
$ItemMax[armormScout, MortarTurretPack] = 0;
$ItemMax[armormMercenary, MortarTurretPack] = 0;
$ItemMax[armorfMercenary, MortarTurretPack] = 0;
$ItemMax[armormBurster, MortarTurretPack] = 0;
$ItemMax[armorCyborg, MortarTurretPack] = 0;
$ItemMax[armorfScout, MortarTurretPack] = 0;
$ItemMax[armorfBurster, MortarTurretPack] = 0;
$ItemMax[armormSpy, MortarTurretPack] = 0;
$ItemMax[armorfSpy, MortarTurretPack] = 0;
$ItemMax[armormEngineer, MortarTurretPack] = 0;
$ItemMax[armorfEngineer, MortarTurretPack] = 0;
$ItemMax[armormAlien, MortarTurretPack] = 0;
$ItemMax[armorfAlien, MortarTurretPack] = 0;
$ItemMax[dmarmor, MortarTurretPack] = 0;
$ItemMax[dmfemale, MortarTurretPack] = 0;
$ItemMax[armormLoader, MortarTurretPack] = 1;
$ItemMax[armorfLoader, MortarTurretPack] = 1;
$ItemMax[armormSprint, MortarTurretPack] = 0;
$ItemMax[armorfSprint, MortarTurretPack] = 0;

$TeamItemMax[MortarTurretPack] = 2;
$InvList[MortarTurretPack] = 1;
$RemoteInvList[MortarTurretPack] = 1;

$CanControl[DeployableMortar] = 0;
$CanAlwaysTeamDestroy[DeployableMortar] = 1;

function deployMortarTurret::Initialize()
{
  $TeamItemCount[0 @ MortarTurretPack] = 0;
  $TeamItemCount[1 @ MortarTurretPack] = 0;
  $TeamItemCount[2 @ MortarTurretPack] = 0;
  $TeamItemCount[3 @ MortarTurretPack] = 0;
  $TeamItemCount[4 @ MortarTurretPack] = 0;
  $TeamItemCount[5 @ MortarTurretPack] = 0;
  $TeamItemCount[6 @ MortarTurretPack] = 0;
  $TeamItemCount[7 @ MortarTurretPack] = 0;
}

ItemImageData MortarTurretPackImage 
{
  shapeFile = "ammounit_remote";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData MortarTurretPack 
{
  description = "Mortar Turret";
  shapeFile = "mortar_turret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = MortarTurretPackImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 800;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function MortarTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function MortarTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Mortar Turret has no auto-sensor and must be controlled manually to fire.");
}

function MortarTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Mortar Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableMortar, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableMortar 
{
  className = "Turret";
  shapeFile = "mortar_turret";
  projectileType = MortarTurretShell;
  maxDamage = 1.0;
  maxEnergy = 45;
  minGunEnergy = 45;
  maxGunEnergy = 100;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2.0;
  speed = 2.0;
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
  fireSound = SoundMortarTurretFire;
  activationSound = SoundMortarTurretOn;
  deactivateSound = SoundMortarTurretOff;
  whirSound = SoundMortarTurretTurn;
  explosionId = LargeShockwave;
  description = "Remote Mortar Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this) 
{
  schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,7);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Mortar Turret");
}

function DeployableMortar::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "MortarTurretPack"]--;
}

function DeployableMortar::onPower(%this,%power,%generator) 
{
}

function DeployableMortar::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,7);
  GameBase::setActive(%this,true);
}

