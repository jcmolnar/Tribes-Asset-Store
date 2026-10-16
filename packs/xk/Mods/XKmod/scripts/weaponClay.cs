$InvList[Clay] = 1;
$InvList[ClayAmmo] = 1;
$RemoteInvList[Clay] = 1;
$RemoteInvList[ClayAmmo] = 1;
$AutoUse[Clay] = True;
$SellAmmo[ClayAmmo] = 3;
$WeaponAmmo[Clay] = ClayAmmo;

addWeapon(Clay);
addAmmo(Clay, ClayAmmo, 1);

GrenadeData ClayShell 
{
  bulletShapeName = "Discb.dts";
  explosionTag = flashExpLarge;
  soundId = shockExplosion;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.5;
  mass = 2.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 5.0;
  damageType = $MortarDamageType;
  explosionRadius = 50.0;
  kickBackStrength = 450.0;
  maxLevelFlightDist = 200;
  totalTime = 8.5;
  liveTime = 30.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  trailString = "plastrail.dts";
};

ItemData ClayAmmo 
{
  description = "Clay Shell";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "Discb";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData ClayImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = ClayAmmo;
  projectileType = ClayShell;
  accuFire = true;
  reloadTime = 0.5;
  fireTime = 4.0;
  lightType = 3;
  lightRadius = 80;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Clay 
{
  description = "Clay Mortar";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = ClayImage;
  price = 600;
  showWeaponBar = true;
};

function Clay::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Clay Mortar");
}
