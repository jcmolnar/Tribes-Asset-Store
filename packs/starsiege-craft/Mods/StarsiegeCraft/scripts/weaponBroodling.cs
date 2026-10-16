//Broodling gun
$InvList[BroodGun] = 1;
$RemoteInvList[BroodGun] = 1;
$VehicleInvList[BroodGun] = 1;
$VehicleInvList[BroodGunAmmo] = 1;
$AutoUse[BroodGun] = False;
$WeaponAmmo[BroodGun] = BroodGunAmmo;
$SellAmmo[BroodGunAmmo] = 15;
$InvList[BroodGunAmmo] = 1;
$RemoteInvList[BroodGunAmmo] = 1;

addWeapon(BroodGun);
addAmmo(BroodGun, BroodGunAmmo, 4);

BulletData BroodGunBolt
{
  bulletShapeName = "mortartrail.dts";
  explosionTag = clawExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  damageValue = 0.0;
  damageType = $BroodDamageType;
  kickBackStrength = 200.0;
  muzzleVelocity = 2000.0;
  terminalVelocity = 2000.0;
  acceleration = 5.0;
  totalTime = 1.0;
  liveTime = 1.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.0;
  isVisible = true;
};

ItemData BroodGunAmmo 
{
  description = "Broodling larvae";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 50;
};

ItemImageData BroodGunImage 
{
  shapeFile = "mortartrail";
  mountPoint = 0;
  weaponType = 0;
  ammoType = BroodGunAmmo;
  projectileType = BroodGunBolt;
  accuFire = true;
  reloadTime = 0.5;
  fireTime = 5.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = 
  {
    1.0, 0, 0 }
  ;
  sfxReload = SoundMortarReload;
  sfxFire = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData BroodGun 
{
  description = "Broodling Spawn";
  className = "Weapon";
  shapeFile = "mortartrail";
  hudIcon = "targetlaser";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = BroodGunImage;
  price = 400;
  showWeaponBar = true;
};

function BroodGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Broodling Spawn: <f2>Works at close to medium range, will kill an enemy and spawn broodlings, that wait and destroy anyone who comes near.");
}
