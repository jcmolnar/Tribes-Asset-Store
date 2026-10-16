$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;
$AutoUse[Mortar] = True;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = Mortar;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 2);

GrenadeData MortarShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.0;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "mortartrail.dts";
};

ItemData MortarAmmo 
{
  description = "Mortar Ammo";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MortarImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = MortarAmmo;
  projectileType = MortarShell;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Mortar 
{
  description = "Mortar";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = MortarImage;
  price = 375;
  showWeaponBar = true;
};
