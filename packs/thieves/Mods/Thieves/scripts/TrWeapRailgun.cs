ItemData RailAmmo 
{ 
description = "Railgun Bolt"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo1"; 
shadowDetailMask = 4; 
price = 5; 
}; 
ExplosionData RailgunExp
{
shapeName = "chainspk.dts";
explosionTag = bulletExp2;
soundId = ricochet1;
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
RocketData RailgunBolt
{
bulletShapeName = "bullet.dts";
explosionTag = RailgunExp;
damageClass = 0;
damageValue = 0.235; 
damageType = $RailgunDamageType;
terminalVelocity = 1000;
explosionRadius = 0.05;
kickBackStrength = 0;
acceleration = 500;
muzzleVelocity = 1000;
totalTime = 3; 
liveTime = 4.05;
lightRange = 2.0;
lightColor = { 1.0, 0.0, 0.0 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};
ItemImageData RailgunImage 
{ 
shapeFile = "sniper"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = RailAmmo; 
projectileType = RailgunBolt; 
accuFire = true; 
reloadTime = 2; 
fireTime = 0.5; 
lightType = 3; 
lightRadius = 2; 
lightTime = 1; 
lightColor = { 1.0, 0, 0 }; 
sfxFire = SoundMissileTurretFire; 
sfxActivate = SoundPickUpWeapon; 
sfxSpinUp = SoundSpinUp; 
sfxSpinDown = SoundSpinDown; 
}; 
ItemData Railgun 
{ 
description = "Railgun"; 
className = "Weapon"; 
shapeFile = "sniper"; 
hudIcon = "targetlaser"; 
heading = "fWeapons"; 
shadowDetailMask = 4; 
imageType = RailgunImage; 
price = 375; 
showWeaponBar = true; 
};