//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Hvy Las Turret, modded from Rail Turret
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
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

ItemData RailTurretPack 
{
  description = "Heavy Las Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = RailTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 2050;
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
  Bottomprint(%client, "The Heavy Las Turret has no automatic sensors. A teammate must control it manually.");
}

 //-=-=-=-

TurretData DeployableRailTurret 
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = LasCannonCharge;
  maxDamage = 3.0;
  maxEnergy = 200;
  minGunEnergy = 99;
  maxGunEnergy = 100;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 12.0;
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
  description = "Heavy Las Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableRailTurret::onAdd(%this) 
{
  schedule("DeployableRailTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,7);
  %this.shieldStrength = 0.010;
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
  GameBase::setRechargeRate(%this,15);
  GameBase::setActive(%this,true);
}
