
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Hyper Blaster (HyperB)
//  By Renegades
//  2000.01.08 : Alazane : Added onMount documentation
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[HyperB] = 1;
$RemoteInvList[HyperB] = 1;
$AutoUse[HyperB] = True;
$WeaponAmmo[HyperB] = "";

addWeapon(HyperB);

BulletData HyperBolt 
{
  bulletShapeName = "shotgunbolt.dts";
  explosionTag = blasterExp;
  damageClass = 0;
  damageValue = 0.04;
  damageType = $BlasterDamageType;
  muzzleVelocity = 200.0;
  totalTime = 1.0;
  liveTime = 0.13;
  lightRange = 3.0;
  lightColor = { 1.0, 0.25, 0.25 };
  inheritedVelocityScale = 0.5;
  isVisible = True;
  rotationPeriod = 1;
};

ItemImageData HyperBImage 
{
  shapeFile = "plasma";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.1;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = HyperBolt;
  accuFire = true;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB 
{
  heading = $InvHead[ihWea];
  description = "Hyper Blaster";
  className = "Weapon";
  shapeFile = "plasma";
  hudIcon = "blaster";
  shadowDetailMask = 4;
  imageType = HyperBImage;
  price = 285;
  showWeaponBar = true;
};

function HyperB::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Hyper Blaster.  High speed blast with small punch.");
}
