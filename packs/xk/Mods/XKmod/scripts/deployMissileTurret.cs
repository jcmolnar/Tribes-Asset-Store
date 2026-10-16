$ItemMax[armormSniper, RocketPack] = 0;
$ItemMax[armorfSniper, RocketPack] = 0;
$ItemMax[armormScout, RocketPack] = 0;
$ItemMax[armormMercenary, RocketPack] = 0;
$ItemMax[armorfMercenary, RocketPack] = 0;
$ItemMax[armormBurster, RocketPack] = 0;
$ItemMax[armorCyborg, RocketPack] = 0;
$ItemMax[armorfScout, RocketPack] = 0;
$ItemMax[armorfBurster, RocketPack] = 0;
$ItemMax[armormSpy, RocketPack] = 0;
$ItemMax[armorfSpy, RocketPack] = 0;
$ItemMax[armormEngineer, RocketPack] = 0;
$ItemMax[armorfEngineer, RocketPack] = 0;
$ItemMax[armormAlien, RocketPack] = 0;
$ItemMax[armorfAlien, RocketPack] = 0;
$ItemMax[dmarmor, RocketPack] = 0;
$ItemMax[dmfemale, RocketPack] = 0;
$ItemMax[armormLoader, RocketPack] = 1;
$ItemMax[armorfLoader, RocketPack] = 1;
$ItemMax[armormSprint, RocketPack] = 0;
$ItemMax[armorfSprint, RocketPack] = 0;

$TeamItemMax[RocketPack] = 15;
$InvList[RocketPack] = 1;
$RemoteInvList[RocketPack] = 1;

$CanControl[DeployableRocket] = 0;
$EmbedController[DeployableRocket] = 0;
$CanAlwaysTeamDestroy[DeployableRocket] = 1;

function deployMissileTurret::Initialize()
{
  $TeamItemCount[0 @ RocketPack] = 0;
  $TeamItemCount[1 @ RocketPack] = 0;
  $TeamItemCount[2 @ RocketPack] = 0;
  $TeamItemCount[3 @ RocketPack] = 0;
  $TeamItemCount[4 @ RocketPack] = 0;
  $TeamItemCount[5 @ RocketPack] = 0;
  $TeamItemCount[6 @ RocketPack] = 0;
  $TeamItemCount[7 @ RocketPack] = 0;
}

ItemImageData RocketPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 3.0;
  firstPerson = false;
};

ItemData RocketPack 
{
  description = "Missile Turret";
  shapeFile = "missileturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = RocketPackImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 950;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function RocketPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Missile Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableRocket, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableRocket 
{
  className = "Turret";
  shapeFile = "missileturret";
  projectileType = TurretMissile;
  maxDamage = 0.65;
  maxEnergy = 90;
  minGunEnergy = 50;
  maxGunEnergy = 50;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2.5;
  speed = 4.0;
  speedModifier = 1.5;
  range = 125;
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
  description = "Missile Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      	return "True";
   else
      	return "False";
}

function DeployableRocket::onAdd(%this) 
{
  schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.015;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Remote Rocket");
}

function DeployableRocket::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator) 
{
}

function DeployableRocket::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

