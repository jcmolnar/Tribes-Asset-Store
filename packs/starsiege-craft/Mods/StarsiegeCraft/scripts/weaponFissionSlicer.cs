//Plasma Rifle, terran, M
$InvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;
$VehicleInvList[Plasmagun] = 1;
$AutoUse[PlasmaGun] = False;
$WeaponAmmo[PlasmaGun] = "";

addWeapon(PlasmaGun);

BulletData PlasmaBolt 
{
  bulletShapeName = "enbolt.dts";
  explosionTag = energyexp;
  damageClass = 1;
  damageValue = 0.05;
  damageType = $DeathDamageType;
  explosionRadius = 6.0;
  muzzleVelocity = 800.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 1.0;
  isVisible = True;
  soundId = SoundJetLight;
};

ItemImageData PlasmaGunImage
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 1;
  minEnergy = 8;
  maxEnergy = 2;
        mountRotation = 
        {
        0.0, 3.14, 0.0 }//{+up -down, rolling, +left -right}
        ;
  projectileType = PlasmaBolt;
  accuFire = true;
  spinUpTime = 0.4;
  spinDownTime = 0.5;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 1, 0.2 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData PlasmaGun
{
  description = "Plasma Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PlasmaGunImage;
  price = 350;
  showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plasma Rifle: <f2>Rapid firing small bolts of pure plasma energy, this weapons sports top quality Terran innovation.");
}

