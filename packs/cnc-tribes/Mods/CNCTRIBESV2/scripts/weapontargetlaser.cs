//targeting system
$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;
$VehicleInvList[TargetingLaser] = 1;
$AutoUse[TargetingLaser] = False;

addWeapon(TargetingLaser);

TargetLaserData targetLaser 
{
  laserBitmapName = "stafflag.bmp";
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
  description = "Laser Target Designator Gun";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = TargetingLaserImage;
  price = 50;
  showWeaponBar = false;
};
function TargetingLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Target Designator Gun: <f2>Uses an infrared laser to paint targets for those with artillery weapons.");
}
