//dark shockwave, toss, M-H
$InvList[DShock] = 1;
$RemoteInvList[DShock] = 1;
$VehicleInvList[DShock] = 1;
$VehicleInvList[DShockAmmo] = 1;
$AutoUse[DShock] = False;
$WeaponAmmo[DShock] = DShockAmmo;
$SellAmmo[DShockAmmo] = 15;
$InvList[DShockAmmo] = 1;
$RemoteInvList[DShockAmmo] = 1;

addWeapon(DShock);
addAmmo(DShock, DShockAmmo, 2);

RocketData DShockBolt
{
  bulletShapeName = "shield_large.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.95;
  damageType = $ExplosionDamageType;
  explosionRadius = 20.5;
  kickBackStrength = -700.0;
  muzzleVelocity = 130.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 5.20, 6.7, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "shotgunex.dts";
  smokeDist = 2;
};

ItemData DShockAmmo 
{
  description = "DarkShock Charges";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData DShockImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
        mountRotation = 
        {
        0.0, 3.14, 0.0 }//{+up -down, rolling, +left -right}
        ;
  ammoType = DShockAmmo;
  projectileType = DShockBolt;
  accuFire = false;
  reloadTime = 1.5;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 0, 0, 3.0 };
  sfxFire = bigExplosion3;
  sfxActivate = SoundPickUpWeapon;
  sfxReady = SoundMortarIdle;
};

ItemData DShock
{
  description = "Dark Shockwave";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = DShockImage;
  price = 850;
  showWeaponBar = true;
};

function DShock::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Dark Shockwave: <f2>This weapon utilizes negative matter to pull victims into the blast with intense force.");
}
