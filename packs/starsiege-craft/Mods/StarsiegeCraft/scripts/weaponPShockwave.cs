//psionic shockwave, toss, M
$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;
$VehicleInvList[MassDriver] = 1;
$VehicleInvList[MassAmmo] = 1;
$AutoUse[MassDriver] = False;
$WeaponAmmo[MassDriver] = MassAmmo;
$SellAmmo[MassAmmo] = 15;
$InvList[MassAmmo] = 1;
$RemoteInvList[MassAmmo] = 1;

addWeapon(MassDriver);
addAmmo(MassDriver, MassAmmo, 2);

RocketData Mass
{
  bulletShapeName = "shield_large.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.85;
  damageType = $ExplosionDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 600.0;
  muzzleVelocity = 130.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 5.20, 6.7, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "fusionbolt.dts";
  smokeDist = 2;
};

ItemData MassAmmo 
{
  description = "Psi Batteries";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MassDriverImage 
{
  shapeFile = "shotgun";
  mountPoint = 0;
  weaponType = 0;
        mountRotation = 
        {
        0.0, 3.14, 0.0 }//{+up -down, rolling, +left -right}
        ;
  ammoType = MassAmmo;
  projectileType = Mass;
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

ItemData MassDriver
{
  description = "Psionic Shockwave";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = MassDriverImage;
  price = 700;
  showWeaponBar = true;
};

function MassDriver::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psionic Shockwave: <f2>This weapon has a large blast radius that pushes victims away with intense force.");
}
