//Anti Zerg, Protoss, all
$InvList[AntiZergLauncher] = 1;
$InvList[AntiZergAmmo] = 1;
$RemoteInvList[AntiZergLauncher] = 1;
$RemoteInvList[AntiZergAmmo] = 1;
$VehicleInvList[AntiZergLauncher] = 1;
$VehicleInvList[AntiZergAmmo] = 1;
$AutoUse[AntiZergLauncher] = False;
$SellAmmo[AntiZergAmmo] = 3;
$WeaponAmmo[AntiZergLauncher] = AntiZergAmmo;

addWeapon(AntiZergLauncher);
addAmmo(AntiZergLauncher, AntiZergAmmo, 1);

GrenadeData ZergBomb
{
  bulletShapeName = "Mortar.dts";
  explosionTag = turretExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.25;
  damageType = $DDamageType;
  explosionRadius = 10;
  kickBackStrength = 300.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
};

ItemData AntiZergAmmo 
{
  description = "Protoss Spore Bombs";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 25;
};

ItemImageData AntiZergImage 
{
  shapeFile = "plasma";
  mountPoint = 0;
  weaponType = 0;
  ammoType = AntiZergAmmo;
  projectileType = ZergBomb;
  accuFire = true;
  reloadTime = 2.0;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData AntiZergLauncher 
{
  description = "Spore Demetabolizer";
  className = "Weapon";
  shapeFile = "plasma";
  hudIcon = "plasma";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = AntiZergImage;
  price = 650;
  showWeaponBar = true;
};

function AntiZergLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Spore Demetabolizer: <f2>The outcome of a Terran-Protoss alliance versus the Zerg, this weapon will instantly end a Zerg's life.");
}
