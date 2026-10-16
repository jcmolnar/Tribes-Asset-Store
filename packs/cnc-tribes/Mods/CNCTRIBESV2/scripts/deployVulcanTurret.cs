//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Bolter Cannon, modded from vulcan
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[VulcanTurretPack] = 2;
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

RocketData RailRound 
{
  bulletShapeName = "rocket.dts";
  explosionTag = debrisExpSmall;
  expRandCycle = 1;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.21;
  damageType = $MissileDamageType;
  explosionRadius = 3.5;
  kickBackStrength = 0.0;
  muzzleVelocity = 165.0;
  terminalVelocity = 2000.0;
  aimDeflection = 0.003;
  acceleration = 100.0;
  totalTime = 3.5;
  liveTime = 3.5;
  lightRange = 5.0;
  lightColor = { 0.0, 0.0, 0.0 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "rsmoke.dts";
  smokeDist = 0.0;
  soundId = SoundJetHeavy;
};

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
  description = "Bolter Cannon";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = VulcanTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 2050;
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
  Bottomprint(%client, "The Bolter Cannon is not an automatic turret. It requires manual control to fire.");
}

 //-=-=-=-

TurretData VulcanTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = RailRound;
  accuFire = false;
  maxDamage = 1.0;
  maxEnergy = 200;
  minGunEnergy = 1;
  maxGunEnergy = 3;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.001;
  aimDeflection = 0.05;
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
  description = "Bolter Turret";
  damageSkinData = "objectDamageSkins";
};

function VulcanTurret::onAdd(%this) 
{
  schedule("VulcanTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,10);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Bolter Turret");
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
