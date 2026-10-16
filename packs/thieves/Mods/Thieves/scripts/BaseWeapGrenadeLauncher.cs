ItemData GrenadeAmmo
{
description = "Grenade Ammo";
className = "Ammo";
shapeFile = "grenammo";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 2;
};
ItemImageData GrenadeLauncherImage
{
shapeFile = "grenadeL";
mountPoint = 0;
weaponType = 0; 
ammoType = GrenadeAmmo;
projectileType = GrenadeShell;
accuFire = false;
reloadTime = 0.5;
fireTime = 0.5;
lightType = 3; 
lightRadius = 3;
lightTime = 1;
lightColor = { 0.6, 1, 1.0 };
sfxFire = SoundFireGrenade;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundDryFire;
};
ItemData GrenadeLauncher
{
description = "Grenade Launcher";
className = "Weapon";
shapeFile = "grenadeL";
hudIcon = "grenade";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = GrenadeLauncherImage;
price = 150;
showWeaponBar = true;
};
