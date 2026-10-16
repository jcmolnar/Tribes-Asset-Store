
$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;
$VehicleInvList[GrenadeLauncher] = 1;
$VehicleInvList[GrenadeAmmo] = 1;
$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 3);

GrenadeData GrenadeShell 
{
  bulletShapeName = "discb.dts";
  explosionTag = grenadeExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.55;
  damageType = $ShrapnelDamageType;
  explosionRadius = 15;
  kickBackStrength = 150.0;
  maxLevelFlightDist = 150;
  totalTime = 20.0;
  liveTime = 0.3;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "enex.dts";
  smokeDist = 2.0;
};

ItemData GrenadeAmmo 
{ 
  description = "Disc Ammo"; 
  className = "Ammo"; 
  shapeFile = "grenammo"; 
  heading = $InvHead[ihDSe]; 
  shadowDetailMask = 4; 
  price = 2;
}; 

ItemImageData GrenadeLauncherImage 
{
  shapeFile = "grenade2L";
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
  description = "Discus Thrower";
  className = "Weapon";
  shapeFile = "grenade2L";
  hudIcon = "disc";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = GrenadeLauncherImage;
  price = 450;
  showWeaponBar = true;
};

function GrenadeLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Discus Thrower: <f2>Hurls explosive discus that explode on impact.");
}
