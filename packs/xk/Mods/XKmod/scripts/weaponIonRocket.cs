$InvList[IonRocket] = 1;
$RemoteInvList[IonRocket] = 1;
$AutoUse[IonRocket] = True;
$WeaponAmmo[IonRocket] = "";

addWeapon(IonRocket);

RocketData IonShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Flare2Exp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2000;
   damageType       = $IonDamageType;
   explosionRadius  = 5.5;
   kickBackStrength = 50.0;
   muzzleVelocity    = 72.0;
   terminalVelocity = 80.0;
   acceleration = 5.0;
   totalTime = 6.5;
   liveTime = 8.0;
   lightRange = 5.0;
   inheritedVelocityScale = 0.5;
   seekingTurningRadius    = 5.0;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.2;
   soundId = SoundDiscSpin;
};

SeekingMissileData HomingIonShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Flare2Exp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2000;
   damageType       = $EnergyDamageType;
   explosionRadius  = 5.5;
   kickBackStrength = 50.0;
   muzzleVelocity    = 72.0;
   terminalVelocity = 80.0;
   acceleration = 5.0;
   totalTime = 6.5;
   liveTime = 8.0;
   lightRange = 5.0;
   inheritedVelocityScale = 0.5;
   seekingTurningRadius    = 5.0;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.2;
   soundId = SoundDiscSpin;
};
function HomingIonShell::updateTargetPercentage(%target) 
{
  return GameBase::virtual(%target, "getHeatFactor");
}

ItemImageData IonRocketImage
{
  shapeFile = "grenadeL";
  mountRotation = { 0.0, 80.0, 0.0 };
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1;
  fireTime = 0.5;
  minEnergy = 19;
  maxEnergy = 20;
  projectileType = IonShell;
  accuFire = True;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundShieldOn;
};

ItemData IonRocket
{
  heading = $InvHead[ihWea];
  description = "Ion Rocket";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = IonRocketImage;
  price = 250;
  showWeaponBar = true; 
};
     
function IonRocket::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Ion Rocket");
}


