ItemData MinionAmmo
{
description = "Minion Missile";
className = "Ammo";
shapeFile = "rocket";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 20;
};
ExplosionData MinionExp
{
shapeName = "shockwave.dts";
soundId = explosion3;
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
kickBackStrength = 0;
shiftPosition = True;
};
RocketData MinionBolt
{
bulletShapeName = "rocket.dts";
explosionTag = MinionExp;
damageClass = 1;
damageValue = 2.0; 
damageType = $ExplosionDamageType;
terminalVelocity = 25;
explosionRadius = 20;
kickBackStrength = 500;
acceleration = 1;
muzzleVelocity = 25;
totalTime = 25; 
liveTime = 26;
lightRange = 4.0;
lightColor = { 1.0, 0.25, 0.25 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};
ItemImageData MinionImage
{
shapeFile = "mortargun";
mountPoint = 0;
weaponType = 0; 
reloadTime = 3;
fireTime = 1;
minEnergy = 40;
maxEnergy = 60;
projectileType = MinionBolt;
ammoType = MinionAmmo;
accuFire = true;
sfxFire = SoundFireFlierRocket;
sfxActivate = SoundPickUpWeapon;
};
ItemData Minion
{
heading = "fWeapons";
description = "Minion";
className = "Weapon";
shapeFile = "mortargun";
hudIcon = "mortar";
shadowDetailMask = 4;
imageType = MinionImage;
price = 1400;
showWeaponBar = true;
};
