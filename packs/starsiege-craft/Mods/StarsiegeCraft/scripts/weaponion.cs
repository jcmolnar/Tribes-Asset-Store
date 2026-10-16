//singularity charge, toss L
$InvList[IonGun] = 1;
$RemoteInvList[IonGun] = 1;
$VehicleInvList[Iongun] = 1;
$AutoUse[IonGun] = False;
$WeaponAmmo[IonGun] = "";

addWeapon(IonGun);

RocketData psipsia
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = TurretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.35;
  damageType = $DeathDamageType;
  explosionRadius = 6;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 2.5;
  liveTime = 2.5;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 50;
  trailWidth = 0.3;
};

ItemImageData IonGunImage
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.35;
  fireTime = 0.4;
  minEnergy = 19;
  maxEnergy = 20;
  projectileType = psipsia;
  accuFire = false;
  sfxFire = SoundCharge;
  sfxActivate = SoundPickUpWeapon;
};

ItemData IonGun 
{
  heading = $InvHead[ihWet];
  description = "Singularity Charge";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = IonGunImage;
  price = 250;
  showWeaponBar = true;
};

function IonGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Singularity Charge: <f2>psionically charged hydrogen nuclei are shot forward to explode on contact.");
}
