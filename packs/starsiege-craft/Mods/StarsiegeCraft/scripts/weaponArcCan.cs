//arclite shock cannon, terran, m-H
$AutoUse[Autogun] = False;
$SellAmmo[PlasmaAmmo] = 100;
$WeaponAmmo[Autogun] = PlasmaAmmo;
$InvList[Autogun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[Autogun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;
$VehicleInvList[Autogun] = 1;
$VehicleInvList[PlasmaAmmo] = 1;

addWeapon(Autogun);
addAmmo(AutoGun, PlasmaAmmo, 10);

GrenadeData AutogunBullet
{
  bulletShapeName = "liqcyl.dts";
  explosionTag = MortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.8;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 1.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokename = "plasmatrail.dts";
  smokeDist = 2.0;
};

ItemData PlasmaAmmo
{
  description = "Arclite bomb";
  heading = $InvHead[ihAmm];
  className = "Ammo";
  shapeFile = "mortarpack";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData AutogunImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.0;
  fireTime = 1.5;
  ammoType = PlasmaAmmo;
  projectileType = autogunbullet;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
};

ItemData Autogun 
{
  description = "ArcliteShockCannon";
  className = "Weapon";
  //          "Cannon";\/
  shapeFile = "mortargun";
  hudIcon = "blaster";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = AutogunImage;
  price = 750;
  showWeaponBar = true;
};

function Autogun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Arclite Shock Cannon: <f2>Firing a devastating long range shock compound inside a canister, this weapon will introduce to your foes your friend- pain.");
}
