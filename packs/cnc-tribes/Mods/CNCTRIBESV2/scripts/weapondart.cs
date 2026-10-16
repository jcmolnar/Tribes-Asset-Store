//Walther WA2000
$InvList[TranqGun] = 1;
$InvList[TranqAmmo] = 1;
$RemoteInvList[TranqGun] = 1;
$RemoteInvList[TranqAmmo] = 1;
$AutoUse[TranqGun] = False;
$SellAmmo[TranqAmmo] = 2;
$WeaponAmmo[TranqGun] = TranqAmmo;
$VehicleInvList[TranqGun] = 1;
$VehicleInvList[TranqAmmo] = 1;

addWeapon(TranqGun);
addAmmo(TranqGun, TranqAmmo, 5);

RocketData PDbolt
{
  bulletShapeName = "tracer.dts";
  explosionTag = TurretExp;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  baseDamageType = $SniperDamageType;
  damageClass = 0;
  damageValue = 2.6;
  explosionRadius = 5.0;
  mass = 0.5;
  collisionRadius = 0.0;
  acceleration = 9.0;
  totalTime = 5.0;
  liveTime = 4.0;
  isVisible = true;
};

ItemData TranqAmmo 
{
  description = ".300 Winchester Clips";
  className = "Ammo";
  heading = $InvHead[ihDSe];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData TranqGunImage 
{
  shapeFile = "gun51";
  mountPoint = 0;
  weaponType = 0;
  ammoType = TranqAmmo;
  projectileType = PDbolt;
  accuFire = true;
  reloadTime = 2.8;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundFireDisc;
  sfxReload = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TranqGun 
{
  description = "Walther WA2000";
  className = "Weapon";
  shapeFile = "gun51";
  hudIcon = "blaster";
  heading = $InvHead[ihScv];
  shadowDetailMask = 4;
  imageType = TranqGunImage;
  price = 675;
  showWeaponBar = true;
};

function TranqGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Walther WA2000: <f2>The smallest sniper rifle in use by armies arround the world; and the weapon of choice for Commandos");
}