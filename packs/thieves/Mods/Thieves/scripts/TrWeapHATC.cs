BulletData HeavyATCBullet
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp1;
expRandCycle = 2;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0; 
damageValue = 0.3; 
damageType = $BulletDamageType;
aimDeflection = 0.01; 
muzzleVelocity = 500.0;
totalTime = 1.5;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 60; 
};
ItemData HeavyATCAmmo
{
description = "Heavy ATC Round";
className = "Ammo";
shapeFile = "ammo1";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 1;
};
ItemImageData HeavyATCImage
{
shapeFile = "chaingun";
mountPoint = 0;
weaponType = 1; 
reloadTime = 0.4;
spinUpTime = 1;
spinDownTime = 5;
fireTime = 0.2;
ammoType = HeavyATCAmmo;
projectileType = HeavyATCBullet;
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
ItemData HeavyATC
{
description = "Heavy AutoCannon";
className = "Weapon";
shapeFile = "chaingun";
hudIcon = "chain";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = HeavyATCImage;
price = 425;
showWeaponBar = true;
};
