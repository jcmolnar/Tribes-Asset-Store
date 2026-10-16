ExplosionData HyperBlasterExp
{
shapeName = "shotgunex.dts";
soundId = energyExplosion;
faceCamera = true;
randomSpin = true;
hasLight = true;
lightRange = 3.0;
timeZero = 0.450;
timeOne = 0.750;
colors[0] = { 1.0, 1.0, 1.0 };
colors[1] = { 1.0, 1.0, 1.0 };
colors[2] = { 1.0, 1.0, 1.0 };
radFactors = { 1.0, 1.0, 1.0 };
shiftPosition = True;
};
BulletData HyperBlasterBolt
{
bulletShapeName = "shotgunbolt.dts";
explosionTag = BlasterExp;
damageClass = 0;
damageValue = 0.1; 
damageType = $BlasterDamageType;
muzzleVelocity = 150.0;
totalTime = 1.875; 
liveTime = 1.125;
lightRange = 3.0;
lightColor = { 1.0, 1.0, 1.0 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};
ItemImageData HyperBlasterImage
{
shapeFile = "energygun";
mountPoint = 0;
weaponType = 0; 
reloadTime = 0.05;
fireTime = 0.15;
minEnergy = 3;
maxEnergy = 4;
projectileType = HyperBlasterBolt;
accuFire = true;
sfxFire = SoundFireBlaster;
sfxActivate = SoundPickUpWeapon;
};
ItemData HyperBlaster
{
heading = "fWeapons";
description = "Hyper Blaster";
className = "Weapon";
shapeFile = "energygun";
hudIcon = "Blaster";
shadowDetailMask = 4;
imageType = HyperBlasterImage;
price = 115;
showWeaponBar = true;
};
