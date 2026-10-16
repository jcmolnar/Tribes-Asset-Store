BulletData ATCBullet
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp0;
expRandCycle = 2;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0; 
damageValue = 0.2; 
damageType = $BulletDamageType;
aimDeflection = 0.00825; 
muzzleVelocity = 500.0;
totalTime = 1.5;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 60; 
};
ItemData ATCAmmo
{
description = "ATC Round";
className = "Ammo";
shapeFile = "ammo1";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 1;
};
ItemImageData ATCImage
{
shapeFile = "chaingun";
mountPoint = 0;
weaponType = 1; 
reloadTime = 0.3;
spinUpTime = 0.7;
spinDownTime = 5;
fireTime = 0.2;
ammoType = ATCAmmo;
projectileType = ATCBullet;
accuFire = false;
lightType = 3; 
lightRadius = 3;
lightTime = 1;
lightColor = { 0.6, 1, 1 };
sfxFire = SoundFireChaingun;
sfxActivate = SoundPickUpWeapon;
sfxSpinUp = SoundSpinUp;
sfxSpinDown = SoundSpinDown;
};
ItemData ATC
{
description = "AutoCannon";
className = "Weapon";
shapeFile = "chaingun";
hudIcon = "chain";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = ATCImage;
price = 425;
showWeaponBar = true;
};
