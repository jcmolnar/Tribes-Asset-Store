$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;
$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);

GrenadeData GrenadeShell 
{
  bulletShapeName = "grenade.dts";
  explosionTag = grenadeExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.45;
  damageClass = 1;
  damageValue = 0.4;
  damageType = $ShrapnelDamageType;
  explosionRadius = 15;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 150;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "smoke.dts";
};

ItemData GrenadeAmmo 
{ 
  description = "Grenade Ammo"; 
  className = "Ammo"; 
  shapeFile = "grenammo"; 
  heading = $InvHead[ihAmm]; 
  shadowDetailMask = 4; 
  price = 2;
}; 

ItemImageData GrenadeLauncherImage 
{
  shapeFile = "grenadeL";
  mountPoint = 0;
  weaponType = 0;
  ammoType = GrenadeAmmo;
  projectileType = GrenadeShell;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireGrenade;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher 
{
  description = "Grenade Launcher";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "grenade";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = GrenadeLauncherImage;
  price = 150;
  showWeaponBar = true;
};
