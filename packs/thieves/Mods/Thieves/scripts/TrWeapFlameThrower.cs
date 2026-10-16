ExplosionData IncineratorExp
{
shapeName = "plasmaex.dts";
soundId = explosion4;
faceCamera = true;
randomSpin = true;
hasLight = true;
lightRange = 4.0;
timeZero = 0.200;
timeOne = 0.950;
colors[0] = { 1.0, 1.0, 0.0 };
colors[1] = { 1.0, 1.0, 0.75 };
colors[2] = { 1.0, 1.0, 0.75 };
radFactors = { 0.375, 1.0, 0.9 };
};
BulletData IncineratorBolt
{
bulletShapeName = "plasmabolt.dts";
explosionTag = IncineratorExp;
damageClass = 1;
damageValue = 0.1;
damageType = $plasmaDamageType;
explosionRadius = 2.0;
muzzleVelocity = 10.0;
totalTime = 1.0;
liveTime = 0.8;
lightRange = 3.0;
lightColor = { 1, 1, 0 };
inheritedVelocityScale = 0.3;
isVisible = True;
soundId = SoundJetLight;
};
ItemImageData IncineratorImage
{
shapeFile = "plasma";
mountPoint = 0;
weaponType = 0; 
projectileType = IncineratorBolt;
accuFire = true;
reloadTime = 0.05;
fireTime = 0.05;
minEnergy = 3;
maxEnergy = 4;
lightType = 3; 
lightRadius = 3;
lightTime = 1;
lightColor = { 1, 1, 0.2 };
sfxFire = SoundFireplasma;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundDryFire;
};
ItemData Incinerator
{
description = "Incinerator";
className = "Weapon";
shapeFile = "plasma";
hudIcon = "plasma";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = IncineratorImage;
price = 475;
showWeaponBar = true;
};
