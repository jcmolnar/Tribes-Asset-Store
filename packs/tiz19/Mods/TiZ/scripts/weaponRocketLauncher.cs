$InvList[RocketLauncher] = 1;
$InvList[RocketAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[RocketAmmo] = 1;
$AutoUse[RocketLauncher] = False;
$SellAmmo[RocketAmmo] = 3;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 1);

RocketData StingerMissile 
{
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.5;
  damageType = $MissileDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 300.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 2000.0;
  acceleration = 500.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "rsmoke.dts";
  smokeDist = 1.8;
  soundId = SoundJetHeavy;
};

ItemData RocketAmmo 
{
  description = "Missiles";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData RocketImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = RocketAmmo;
  projectileType = StingerMissile;
  accuFire = true;
  reloadTime = 0.95;
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

ItemData RocketLauncher 
{
  description = "Rocket Launcher";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = RocketImage;
  price = 375;
  showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Rocket Launcher: One of the most deadly weapons, I think you'd know what this baby does.");
}
