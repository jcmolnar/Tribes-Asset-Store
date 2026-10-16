BulletData BlastCannonBullet
{
bulletShapeName = "bullet.dts";
explosionTag = bulletExp2;
expRandCycle = 2;
mass = 0.2;
bulletHoleIndex = 0;
damageClass = 1; 
damageValue = 0.2; 
damageType = $ExplosionDamageType;
explosionRadius = 1.5;
kickBackStrength = 50;
aimDeflection = 0.01; 
muzzleVelocity = 250.0;
totalTime = 4;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 60; 
};
ItemData BlastCannonAmmo
{
description = "BC Round";
className = "Ammo";
shapeFile = "ammo1";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 1;
};
ItemImageData BlastCannonImage
{
shapeFile = "chaingun";
mountPoint = 0;
weaponType = 1; 
reloadTime = 0.4;
spinUpTime = 1;
spinDownTime = 5;
fireTime = 0.2;
ammoType = BlastCannonAmmo;
projectileType = BlastCannonBullet;
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
ItemData BlastCannon
{
description = "Blast Cannon";
className = "Weapon";
shapeFile = "chaingun";
hudIcon = "chain";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = BlastCannonImage;
price = 725;
showWeaponBar = true;
};
