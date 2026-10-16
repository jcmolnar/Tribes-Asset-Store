//Riper
$InvList[Railgun] = 1;
$InvList[RailAmmo] = 1;
$RemoteInvList[Railgun] = 1;
$RemoteInvList[RailAmmo] = 1;
$VehicleInvList[Railgun] = 1;
$VehicleInvList[RailAmmo] = 1;
$AutoUse[Railgun] = False;
$SellAmmo[RailAmmo] = 150;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 50);

BulletData RailRound 
{
  bulletShapeName = "rocket.dts";
  explosionTag = debrisExpMedium;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.075;
  explosionRadius = 10.0;
  damageType = $MissileDamageType;
  aimDeflection = 0.0009;
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
  description = "Riper Missiles";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData RailgunImage 
{
  shapeFile = "chaingun";
  mountPoint = 0;
  mountRotation = 
  {
   0, -1.0, 0 }
  ;

  weaponType = 0;
  ammoType = RailAmmo;
  projectileType = RailRound;
  accuFire = false;
  reloadTime = 0;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 2.0, 5.0 };
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
  description = "Riper";
  className = "Weapon";
  shapeFile = "chaingun";
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
  Bottomprint(%client, "Riper: <f2>A rapid fire missile launcher.");
}
