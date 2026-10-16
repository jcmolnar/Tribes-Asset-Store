//implosion cannon
$TeamItemMax[MortarTurretPack] = 1;
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

RocketData DCannonShot 
{
  bulletShapeName = "mortar.dts";
  explosionTag = DCannonBoom;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.4;
  baseDamageType = $ExplosionDamageType;
  explosionRadius = 160.0;
  kickBackStrength = -400.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  acceleration = 5.0;
  totalTime = 15.0;
  liveTime = 15.0;
  trailtype = 2;
  trailString = "enex.dts";
  smokeDist = 0.4;
  lightRange = 10.0;
  lightColor = { 1.0, 6.7, 9.5 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};

ItemImageData MortarTurretPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData MortarTurretPack 
{
  description = "Implosion Cannon";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = MortarTurretPackImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 2000;
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
  Bottomprint(%client, "The Implosion Cannon <f6>must be controlled from a command station to fire.");
}

function MortarTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Implosion Cannon (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableMortar, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableMortar 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = DCannonShot;
  maxDamage = 2.5;
  maxEnergy = 200;
  minGunEnergy = 1;
  maxGunEnergy = 2;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.5;
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
  fireSound = SoundMortarTurretFire;
  activationSound = SoundMortarTurretOn;
  deactivateSound = SoundMortarTurretOff;
  whirSound = SoundMortarTurretTurn;
  explosionId = LargeShockwave;
  description = "Implosion Cannon";
  damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this) 
{
  schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,7);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "D-Cannon");
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

function DeployableMortar::onFire(%player,%item)
{
//	Weapon::onUse(%player,%item);
//	bottomPrintAll("***WARNING: D-CANNON FIRED***", 10);
}

