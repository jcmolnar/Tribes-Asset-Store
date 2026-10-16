//LurkerBloodLust
$InvList[BloodLust] = 1;
$InvList[BloodLustAmmo] = 1;
$RemoteInvList[BloodLust] = 1;
$RemoteInvList[BloodLustAmmo] = 1;
$VehicleInvList[BloodLust] = 1;
$VehicleInvList[BloodLustAmmo] = 1;
$AutoUse[BloodLust] = False;
$SellAmmo[BloodLustAmmo] = 100;
$WeaponAmmo[BloodLust] = BloodLustAmmo;

addWeapon(BloodLust);
addAmmo(BloodLust, BloodLustAmmo, 50);

BulletData BLust
{
  bulletShapeName = "bullet.dts";
  explosionTag = clawExp;
  damageClass = 0;
  damageValue = 0.18;
  damageType = $ReaperDamageType;
  muzzleVelocity = 55.0;
  totalTime = 0.2;
  aimDeflection = 0.05;
  liveTime = 0.2;
  inheritedVelocityScale = 1.0;
  isVisible = false;
};

ItemData BloodLustAmmo 
{
  description = "Zerg BloodLust Hormones";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData BloodLustImage 
{
  shapeFile = "enbolt";
  mountPoint = 0;
  weaponType = 0;
  ammoType = BloodLustAmmo;
  projectileType = BLust;
  accuFire = false;
  reloadTime = 0.02;
  fireTime = 0.03;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData BloodLust 
{
  description = "Blood Lust";
  className = "Weapon";
  shapeFile = "enbolt";
  hudIcon = "targetlaser";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = BloodLustImage;
  price = 300;
  showWeaponBar = true;
};

function BloodLust::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Blood Lust: <f2>A Lurker Hormone that supercharges it's metabolism and strength. Does heavy damage at close range.");
}
