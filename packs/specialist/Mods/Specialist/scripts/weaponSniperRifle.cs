$InvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;
$AutoUse[SniperRifle] = True;

$WeaponAmmo[SniperRifle] = SniperRifleAmmo;
$SellAmmo[SniperRifleAmmo] = 15;
$InvList[SniperRifleAmmo] = 1;
$RemoteInvList[SniperRifleAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, SniperRifle] = 1;
$ItemMax[reconfemalearmor, SniperRifle] = 1;
$ItemMax[espionagearmor, SniperRifle] = 0;
$ItemMax[espionagefemalearmor, SniperRifle] = 0;
$ItemMax[engineerarmor, SniperRifle] = 0;
$ItemMax[engineerfemalearmor, SniperRifle] = 0;
$ItemMax[infantryarmor, SniperRifle] = 0;
$ItemMax[infantryfemalearmor, SniperRifle] = 0;
$ItemMax[falloutarmor, SniperRifle] = 0;
$ItemMax[falloutfemalearmor, SniperRifle] = 0;
$ItemMax[demolitionsarmor, SniperRifle] = 0;
$ItemMax[assaultarmor, SniperRifle] = 0;
$ItemMax[artilleryarmor, SniperRifle] = 0;
$ItemMax[commanderarmor, SniperRifle] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, SniperRifleAmmo] = 15;
$ItemMax[reconfemalearmor, SniperRifleAmmo] = 15;
$ItemMax[espionagearmor, SniperRifleAmmo] = 0;
$ItemMax[espionagefemalearmor, SniperRifleAmmo] = 0;
$ItemMax[engineerarmor, SniperRifleAmmo] = 0;
$ItemMax[engineerfemalearmor, SniperRifleAmmo] = 0;
$ItemMax[infantryarmor, SniperRifleAmmo] = 0;
$ItemMax[infantryfemalearmor, SniperRifleAmmo] = 0;
$ItemMax[falloutarmor, SniperRifleAmmo] = 0;
$ItemMax[falloutfemalearmor, SniperRifleAmmo] = 0;
$ItemMax[demolitionsarmor, SniperRifleAmmo] = 0;
$ItemMax[assaultarmor, SniperRifleAmmo] = 0;
$ItemMax[artilleryarmor, SniperRifleAmmo] = 0;
$ItemMax[commanderarmor, SniperRifleAmmo] = 0;

SoundData SoundFireSniperRifle
{
   wavFileName = "BXplo1.wav";
   profile = Profile3dLudicrouslyFar;
};


BulletData SniperProj 
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExp1;
  mass = 0.05;
  collisionRadius = 0.0;
  bulletHoleIndex = 0;
  damageClass = 0;
  damageValue = 0.3;

  damageType = $SniperRifleDamageType;
  aimDeflection = 0.0;
  muzzleVelocity = 1999.0;
  totalTime = 1;
  inheritedVelocityScale = 0.0;
  isVisible = false;
  tracerPercentage = 100.0;
  tracerLength = 25;
};

ItemData SniperRifleAmmo
{
  description = "Sniper Bullet";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 8;
};

ItemImageData SniperRifleImage 
{
	mountOffset = { 0, 0.2, 0 };
	mountRotation = { 0, 0, 0 };

  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SniperRifleAmmo;
  projectileType = SniperProj;
  accuFire = true;
  reloadTime = 2.0;
  fireTime = 0;
  lightType = 3;
  lightRadius = 4;
  lightTime = 1;
  lightColor = { 0.0, 0.0, 1.0 };
  sfxFire = SoundFireSniperRifle;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
  description = "Sniper Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "bWeapons";
  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 375;
  showWeaponBar = true;
};
