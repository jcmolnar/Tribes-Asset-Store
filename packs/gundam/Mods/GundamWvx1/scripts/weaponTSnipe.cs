//fusion rifle
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
  bulletShapeName = "enbolt.dts";
  explosionTag = TurretExp;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  baseDamageType = $PlasmaDamageType;
  damageClass = 0;
  damageValue = 1.8;
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
  description = "Fusion Bullets";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData TranqGunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  mountRotation = 
  {
   0, 2.0, 0 }
  ;

  weaponType = 0;
  ammoType = TranqAmmo;
  projectileType = PDbolt;
  accuFire = true;
  reloadTime = 1.0;
  fireTime = 3.0;
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
  description = "Fusion Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "blaster";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = TranqGunImage;
  price = 475;
  showWeaponBar = true;
};

function TranqGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fusion Rifle: <f2>A useful sniper rifle, it doesn't affect Wing Zero and Epyon, but severely hurts other Gundams.");
}