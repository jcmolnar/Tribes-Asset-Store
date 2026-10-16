// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData DiscAmmo
{
description = "Disc";
className = "Ammo";
shapeFile = "discammo";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 2;
};

ItemImageData DiscLauncherImage
{
shapeFile = "disc";
mountPoint = 0;

weaponType = 3; // DiscLauncher
//ammoType = DiscAmmo;
projectileType = DiscShell;
accuFire = true;
reloadTime = 0.25;
fireTime = 1.25;
spinUpTime = 0.25;

sfxFire = SoundFireDisc;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundDiscReload;
sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
description = "Disc Launcher";
className = "Weapon";
shapeFile = "disc";
hudIcon = "disk";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = DiscLauncherImage;
price = 150;
showWeaponBar = true;
};

AddToRP(DiscLauncher);
AddWeapon(DiscLauncher);
