//Car15
$InvList[Chaingun] = 1;
$RemoteInvList[Chaingun] = 1;
$AutoUse[Chaingun] = False;
$WeaponAmmo[Chaingun] = BulletAmmo;
$SellAmmo[BulletAmmo] = 25;
$InvList[BulletAmmo] = 1;
$RemoteInvList[BulletAmmo] = 1;
$VehicleInvList[Chaingun] = 1;
$VehicleInvList[BulletAmmo] = 1;

addWeapon(Chaingun);
addAmmo(ChainGun,ArcliteShellsAmmo,60);

BulletData ChaingunBullet 
{
  bulletShapeName = "tracer.dts";
  explosionTag = bulletexp0;
  mass = 0.15;
  damageClass = 1;
  explosionRadius = 4.0;
  damageValue = 0.23;
  damageType = $BulletDamageType;
  aimDeflection = 0;
  muzzleVelocity = 150.0;
  totalTime = 1.5;
  liveTime = 1.5;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  lightRange         = 3.0;
  lightColor         = { 1, 1, 0 };
};

ItemData BulletAmmo 
{
  description = "FMJ M4 Clips";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihDSe];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData ChaingunImage 
{
  shapeFile = "Car15";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.18;
  fireTime = 0.18;
  ammoType = BulletAmmo;
  projectileType = ChaingunBullet;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = {0.6, 1, 1};
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Chaingun 
{
  description = "M4 Carbine";
  className = "Weapon";
  shapeFile = "Car15";
  hudIcon = "chain";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = ChaingunImage;
  price = 225;
  showWeaponBar = true;
};

function Chaingun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "M4 Carbine: <f2>One of the most common weapons for field use.");
}
