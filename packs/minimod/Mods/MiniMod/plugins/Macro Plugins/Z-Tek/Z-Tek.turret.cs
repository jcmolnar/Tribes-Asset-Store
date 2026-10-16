// This is a MiniMod plugin.
// This is the PhaseLok+SheildGens Pack from the Z-Tek mod. Ported by Dewy.

TurretData DeployablePhaseLok
{
className = "Turret";
shapeFile = "camera";
projectileType = DeployablePhaseLokMissile;
maxDamage = 0.7;
maxEnergy = 100;
gunRange = 100;
minGunEnergy = 30;
maxGunEnergy = 20;
sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
reloadDelay = 4;
speed = 10;
speedModifier = 1.5;
range = 50;
visibleToSensor = true;
shadowDetailMask = 4;
dopplerVelocity = 0;
castLOS = true;
supression = false;
mapFilter = 2;
mapIcon = "M_camera";
debrisId = flashDebrisMedium;
shieldShapeName = "shield";
fireSound = SoundMissileTurretFire;
activationSound = SoundMissileTurretOn;
deactivateSound = SoundMissileTurretOff;
targetableFovRatio = 0.5;
explosionId = debrisExpMedium;
description = "PhaseLok";
damageSkinData = "objectDamageSkins";
};
