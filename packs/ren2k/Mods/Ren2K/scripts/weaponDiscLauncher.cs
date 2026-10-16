$InvList[Disclauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Disclauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;
$SellAmmo[DiscAmmo] = 5;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

addWeapon(DiscLauncher);
addAmmo(DiscLauncher, DiscAmmo, 2);

RocketData DiscShell 
{
  bulletShapeName = "discb.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $ExplosionDamageType;
  explosionRadius = 7.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 80.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 8.0;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 15;
  trailWidth = 0.3;
  soundId = SoundDiscSpin;
};

ItemData DiscAmmo 
{
  description = "Disc";
  className = "Ammo";
  shapeFile = "discammo";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData DiscLauncherImage 
{
  shapeFile = "disc";
  mountPoint = 0;
  weaponType = 3;
  ammoType = DiscAmmo;
  projectileType = DiscShell;
  accuFire = true;
  reloadTime = 0.25;
  fireTime = 1.25;
  spinUpTime = 0.25;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher 
{
  description = "Disc Launcher";
  className = "Weapon";
  shapeFile = "disc";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = DiscLauncherImage;
  price = 150;
  showWeaponBar = true;
};
