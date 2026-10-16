// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$AutoUse[TargetingLaser] = False;

$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
shapeFile = "paintgun";
mountPoint = 0;

weaponType = 2;
projectileType = targetLaser;
accuFire = true;
minEnergy = 0;
maxEnergy = 0;
reloadTime = 1.0;

lightType   = 3;  // Weapon Fire
lightRadius = 0.6;
lightTime   = 1;
lightColor  = { 0.25, 1, 0.25 };

sfxFire     = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
description   = "Targeting Laser";
className     = "Tool";
shapeFile     = "paintgun";
hudIcon       = "targetlaser";
heading = "bTools";
shadowDetailMask = 4;
imageType     = TargetingLaserImage;
price         = 50;
showWeaponBar = false;
};

AddWeapon(TargetingLaser);
AddToInv(TargetingLaser);
