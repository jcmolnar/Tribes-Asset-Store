// This is a MiniMod plugin
// This is the Shotgun From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

$ShotgunDamageType = 25; 

// $HeatIncrease[$ShotgunDamageType] = 0; 

BulletData ShotgunBullet
{
bulletShapeName = "tracer.dts";
explosionTag = bulletExp0;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.06;
damageType = $ShotgunDamageType;
aimDeflection = 0.02;
muzzleVelocity = 2000.0;
totalTime = 0.5;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 30;
}; 
