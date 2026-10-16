
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Blaster (Blaster)
//  By Dynamix
//
//  Alliance version by Mjolnir and Alazane, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;
$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "";

addWeapon(Blaster);

BulletData BlasterBolt 
{
  bulletShapeName = "bullet.dts";
  explosionTag = blasterExp;
  damageClass = 0;
  damageValue = 0.175;
  damageType = $BlasterDamageType;
  muzzleVelocity = 200.0;
  totalTime = 2.0;
  liveTime = 1.125;
  lightRange = 3.0;
  lightColor = { 1.0, 0.25, 0.25 };
  inheritedVelocityScale = 0.5;
  isVisible = True;
  rotationPeriod = 1;
};

ItemImageData BlasterImage 
{
  shapeFile = "energygun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.3;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = BlasterBolt;
  accuFire = true;
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster 
{
  heading = $InvHead[ihWea];
  description = "Pea Shooter";
  className = "Weapon";
  shapeFile = "energygun";
  hudIcon = "blaster";
  shadowDetailMask = 4;
  imageType = BlasterImage;
  price = 85;
  showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Pea Shooter");
}

