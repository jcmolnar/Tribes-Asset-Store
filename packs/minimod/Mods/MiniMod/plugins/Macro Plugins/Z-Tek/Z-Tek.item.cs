// This is a MiniMod plugin.
// This is the PhaseLok+SheildGens Pack from the Z-Tek mod. Ported/Modified by Dewy.


$TeamItemMax[DShield] = 2;
$TeamItemMax[PhaseLokAmmo]=5;

StaticShapeData DShield
{
className = "DShield";
damageSkinData = "objectDamageSkins";
shapeFile = "generator_p"; 
maxDamage = 1.4;
maxEnergy = 500;
sfxAmbient = SoundGeneratorPower;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
mass=2.5;
};
ItemImageData DShieldPackImage
{
shapeFile = "generator_p"; 
mountPoint = 2;
mountOffset = { 0, -0.5, -1 }; 
mountRotation = { 0.2, 0, 0 }; 
firstPerson = false;
};
ItemData DShieldPack
{
description = "Shield Generator";
shapeFile = "generator_p"; 
className = "Backpack";
heading = "dDeployables"; 
imageType = "DShieldPackImage";
sequenceSound[0] = { "power", SoundSensorPower };
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 3200;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

SeekingMissileData DeployablePhaseLokMissile
{
bulletShapeName = "fusionbolt.dts";
explosionTag = rocketExp;
collisionRadius = 0;
mass = 2.0;
damageClass = 1; 
damageValue = 0.5; 
damageType = $MissileDamageType;
explosionRadius = 4.5;
kickBackStrength = 15;
muzzleVelocity = 10; 
totalTime = 35; 
liveTime = 35; 
seekingTurningRadius = 1;
nonSeekingTurningRadius = 1.1;
proximityDist = 1.5;
smokeDist = 1.5;
lightRange = 5.0;
lightColor = { 0, 0, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
ItemImageData PhaseLokPackImage
{
shapeFile = "remoteTurret";
mountPoint = 2;
mountOffset = { 0, -0.12, -0.1 };
mountRotation = { 0, 0, 0 };
mass = 2.5;
firstPerson = false;
};
ItemData PhaseLokPack
{
description = "PhaseLok";
shapeFile = "remoteTurret";
className = "Backpack";
heading = "dDeployables";
imageType = PhaseLokPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 1500;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = false;
};
