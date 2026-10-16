//Nuclear Bigass Bomb
$TeamItemMax[NukeTurretPack] = 1;
$InvList[NukeTurretPack] = 1;
$RemoteInvList[NukeTurretPack] = 1;

$CanControl[DeployableNukeTurret] = 1;
$EmbedController[DeployableNukeTurret] = 1;
$CanAlwaysTeamDestroy[DeployableNukeTurret] = 1;

function deployNukeTurret::Initialize()
{
  $TeamItemCount[0 @ NukeTurretPack] = 0;
  $TeamItemCount[1 @ NukeTurretPack] = 0;
  $TeamItemCount[2 @ NukeTurretPack] = 0;
  $TeamItemCount[3 @ NukeTurretPack] = 0;
  $TeamItemCount[4 @ NukeTurretPack] = 0;
  $TeamItemCount[5 @ NukeTurretPack] = 0;
  $TeamItemCount[6 @ NukeTurretPack] = 0;
  $TeamItemCount[7 @ NukeTurretPack] = 0;
}

GrenadeData GhostNuke
{
  bulletShapeName = "liqcyl.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.01;
  damageClass = 1;
  damageValue = 4.0;
  damageType = $MortarDamageType;
  explosionRadius = 40;
  kickBackStrength = 800.0;
  maxLevelFlightDist = 0;
  totalTime = 100.0;
  liveTime = 1.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.0;
  smokeName = "plasmabolt.dts";
  smokeDist = 2.0;
};

ItemImageData NukeTurretPackImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData NukeTurretPack 
{
  description = "Nuclear Missile";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = NukeTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3000;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function NukeTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function NukeTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Nuke Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableNukeTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

 //-=-=-=-

TurretData DeployableNukeTurret
{
  className = "Turret";
  shapeFile = "hellfiregun";
  projectileType = Undefined;
  maxDamage = 0.5;
  maxEnergy = 50;
  minGunEnergy = 20;
  maxGunEnergy = 6;
  sequenceSound[0] = {"deploy", SoundActivateMotionSensor };
  reloadDelay = 1.0;
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
//  fireSound = SoundPlasmaTurretFire;
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = flashExpMedium;
  description = "Nuclear Bomb Signaler";
  damageSkinData = "objectDamageSkins";
};

function DeployableNukeTurret::onAdd(%this) 
{
  schedule("DeployableNukeTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.010;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Nuke Turret");
}

function DeployableNukeTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableNukeTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableNukeTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
//  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "NukeTurretPack"]--;
}

function DeployableNukeTurret::onPower(%this,%power,%generator) 
{
}

function DeployableNukeTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}


function DeployableNukeTurret::onFire(%this, %player) 
{
  if(GameBase::getLOSInfo(%this,300))
  {
    bottomPrintAll("NUCLEAR LAUNCH DETECTED...", 5);
//    schedule("DeployableNukeTurret::Nuke,10,%this);
    %targetloc = GameBase::getPosition(GameBase::getLOSInfo(%this,300))
    %targetloc = Vector::add(%loc, "0 0 200");

    %nuke = newObject("GhostNuke","Grenade","GhostNuke"); 
    addToSet("MissionCleanup", %nuke); 
    GameBase::setPosition(%nuke, %targetloc);
  }
  else
  {
    Bottomprint(%player, "No object in direct sight to direct nuclear launch toward");
  }
}

function DeployableNukeTurret::Nuke(%this) 
{
  bottomPrintAll("NUCLEAR BOMB SIGHTED...", 5);
  schedule("DeployableNukeTurret::MakeBomb,10,%this);
}

function DeployableNukeTurret::MakeBomb(%this) 
{
  GameBase::getLOSInfo(%this,3000)
  
  
}