$InvList[Silencer] = 1;
$InvList[SilencerAmmo] = 1;
$RemoteInvList[Silencer] = 1;
$RemoteInvList[SilencerAmmo] = 1;
$AutoUse[Silencer] = True;
$SellAmmo[SilencerAmmo] = 25;
$WeaponAmmo[Silencer] = SilencerAmmo;

addWeapon(Silencer);
addAmmo(Silencer, SilencerAmmo, 5);

BulletData SilencerBullet 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp0;
  expRandCycle = 3;
  mass = 0.05;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.26;
  damageType = $LaserDamageType;
  aimDeflection = 0.003;
  muzzleVelocity = 625.0;
  totalTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  tracerPercentage = 100.0;
  tracerLength = 30;
};

ItemData SilencerAmmo 
{
  description = "Magnum Bullets";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SilencerImage 
{
  shapeFile = "energygun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SilencerAmmo;
  projectileType = SilencerBullet;
  accuFire = true;
  reloadTime = 0.0;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 0, 0, 0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Silencer 
{
  description = "Magnum";
  className = "Weapon";
  shapeFile = "energygun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = SilencerImage;
  price = 375;
  showWeaponBar = true;
};

function Silencer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Magnum");
}
