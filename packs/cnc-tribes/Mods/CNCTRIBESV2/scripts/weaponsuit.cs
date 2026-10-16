
$InvList[suit] = 1;
$RemoteInvList[suit] = 1;
$AutoUse[suit] = False;
$WeaponAmmo[suit] = suitAmmo;
$SellAmmo[suitAmmo] = 25;
$InvList[suitAmmo] = 1;
$RemoteInvList[suitAmmo] = 1;
$VehicleInvList[suit] = 1;
$VehicleInvList[suitAmmo] = 1;

addWeapon(suit);
addAmmo(suit,suitAmmo,60);

BulletData suitBullet 
{
  bulletShapeName = "tracer.dts";
  explosionTag = debrisexpsmall;
  mass = 0.15;
  damageClass = 1;
  explosionRadius = 4.0;
  damageValue = 0.18;
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

ItemData suitAmmo 
{
  description = "30mm Boxed Ammo";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData suitImage 
{
  shapeFile = "AK47";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.32;
  fireTime = 0.32;
  ammoType = suitAmmo;
  projectileType = suitBullet;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = {0.6, 1, 1};
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData suit 
{
  description = "AK47";
  className = "Weapon";
  shapeFile = "AK47";
  hudIcon = "chain";
  heading = $InvHead[ihScv];
  shadowDetailMask = 4;
  imageType = suitImage;
  price = 225;
  showWeaponBar = true;
};

function Chaingun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "AK47: <f2>One of the most widely used weapons in terrorist groups and Eastern Armies, the AK47 is very useful in close quarters.");
}
