//G36K "railgun
$InvList[Railgun] = 1;
$InvList[RailAmmo] = 1;
$RemoteInvList[Railgun] = 1;
$RemoteInvList[RailAmmo] = 1;
$VehicleInvList[Railgun] = 1;
$VehicleInvList[RailAmmo] = 1;
$AutoUse[Railgun] = False;
$SellAmmo[RailAmmo] = 25;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

BulletData RailRound 
{
  bulletShapeName = "tracer.dts";
  explosionTag = debrisExpMedium;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.50;
  explosionRadius = 10.0;
  damageType = $RocketDamageType;
  aimDeflection = 0;
  kickBackStrength = 15.0;
  muzzleVelocity = 120.0;
  terminalVelocity = 120.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.5;
};

ItemData RailAmmo 
{
  description = "5.56mm Ammo";
  className = "Ammo";
  heading = $InvHead[ihDSe];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData RailgunImage 
{
  shapeFile = "gun29";
  mountPoint = 0;
  weaponType = 0;
  ammoType = RailAmmo;
  projectileType = RailRound;
  accuFire = false;
  reloadTime = 0.65;
  fireTime = 0.6;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 2.0, 5.0 };
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
  description = "G36K-Railgun";
  className = "Weapon";
  shapeFile = "gun29";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = RailgunImage;
  price = 675;
  showWeaponBar = true;
};

function Railgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "G36K-Railgun: <f2>A compact highpowered rifle. Used mostly in close quarters.");
}
