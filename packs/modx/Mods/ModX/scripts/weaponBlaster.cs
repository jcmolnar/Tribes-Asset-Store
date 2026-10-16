// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
shapeFile  = "energygun";
mountPoint = 0;

weaponType = 0; // Single Shot
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
heading = "bWeapons";
description = "Blaster";
className = "Weapon";
shapeFile  = "energygun";
hudIcon = "blaster";
shadowDetailMask = 4;
imageType = BlasterImage;
price = 85;
showWeaponBar = true;
};

AddToRP(Blaster);
AddWeapon(Blaster);
