
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Targeting Laser (TargetingLaser)
//  By Dynamix
//
//  Alliance version by Mjolnir, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;
$AutoUse[TargetingLaser] = False;

// Targeting Laser is not in the cycle chain, so
// it's not added, but it could be if you want.
//addWeapon(TargetingLaser);

TargetLaserData targetLaser 
{
  laserBitmapName = "paintPulse.bmp";
  damageConversion = 0.0;
  baseDamageType = 0;
  lightRange = 2.0;
  lightColor = { 0.25, 1.0, 0.25 };
  detachFromShooter = false;
};

ItemImageData TargetingLaserImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = targetLaser;
  accuFire = true;
  minEnergy = 5;
  maxEnergy = 15;
  reloadTime = 1.0;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser 
{
  description = "Targeting Laser";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = "bMisc. Weapons";
  shadowDetailMask = 4;
  imageType = TargetingLaserImage;
  price = 50;
  showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Targeting Laser");
}
