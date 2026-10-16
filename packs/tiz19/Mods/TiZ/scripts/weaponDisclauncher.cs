
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Shuriken Catapult (disc launcher)
//  By <[DC]>Paladin
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

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
  damageValue = 0.65;
  damageType = $ShurikenDamageType;
  explosionRadius = 8;
  kickBackStrength = 150.0;
  muzzleVelocity = 285.0;
  terminalVelocity = 285.0;
  acceleration = 100.0;
  totalTime = 2.5;
  liveTime = 2.5;
  lightRange = 7.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 1.0;
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
  accuFire = false;
  reloadTime = 0.75;
  fireTime = 0.35;
  spinUpTime = 0.35;
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

function DiscLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Disc Launcher: The most common weapon. The disc launcher fires explosive Discs, capable of knocking out a heavy from miles away.");
}
