//arclite shock gun, terran, L
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
  bulletShapeName = "enbolt.dts";
  explosionTag = debrisexpsmall;
  mass = 0.05;
  damageClass = 1;
  explosionRadius = 4.0;
  damageValue = 0.125;
  damageType = $BulletDamageType;
  aimDeflection = 0.004;
  muzzleVelocity = 150.0;
  totalTime = 1.5;
  liveTime = 2.0;
  inheritedVelocityScale = 1.0;
  isVisible = True;
  lightRange         = 3.0;
  lightColor         = { 1, 1, 0 };
};

ItemData BulletAmmo 
{
  description = "Arclite Shells";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData ChaingunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.1;
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
  description = "Arclite Shock Gun";
  className = "Weapon";
  shapeFile = "sniper";
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
  Bottomprint(%client, "Arclite Shock Gun: <f2>Essentially a mini-version of the arclite Shock cannon");
}
