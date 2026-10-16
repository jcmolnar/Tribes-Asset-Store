LightningData GravGunCharge
{
bitmapName = "repairadd.bmp";
damageType = $GravityBoltDamageType;
boltLength = 50.0;
coneAngle = 45.0;
damagePerSec = 0;
energyDrainPerSec = 0.0;
segmentDivisions = 4;
numSegments = 5;
beamWidth = 0.100;
updateTime = 50;
skipPercent = 0.5;
displaceBias = 0.15;
lightRange = 3.0;
lightColor = { 0.25, 0.25, 0.85 };
};
ItemImageData GravGunImage
{
shapeFile = "shotgun";
mountPoint = 0;
weaponType = 2; 
projectileType = GravGunCharge;
minEnergy = 3;
maxEnergy = 11; 
reloadTime = 0.2;
lightType = 3; 
lightRadius = 2;
lightTime = 1;
lightColor = { 0.25, 0.25, 0.85 };
sfxActivate = SoundPickUpWeapon;
sfxFire = SoundElevatorBlocked;
};
ItemData GravGun
{
description = "GravGun";
shapeFile = "shotgun";
hudIcon = "energyrifle";
className = "Weapon";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = GravGunImage;
showWeaponBar = true;
price = 125;
};
