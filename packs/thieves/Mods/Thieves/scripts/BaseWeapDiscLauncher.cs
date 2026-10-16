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
weaponType = 3; 
ammoType = DiscAmmo;
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
heading = "fWeapons";
shadowDetailMask = 4;
imageType = DiscLauncherImage;
price = 150;
showWeaponBar = true;
};
