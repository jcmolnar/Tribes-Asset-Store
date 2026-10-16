// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt


BulletData PaintSplat
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = RedPaintSplatExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.5;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;

   aimDeflection      = 3.003;
   muzzleVelocity     = 40.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData PaintSplat2
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = BluePaintSplatExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.5;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;

   aimDeflection      = 3.003;
   muzzleVelocity     = 40.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData PaintSplat3
{
   bulletShapeName    = "paint.dts";
   explosionTag       = GreenPaintSplatExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.5;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;

   aimDeflection      = 3.003;
   muzzleVelocity     = 40.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData PaintSplat4
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = OrangePaintSplatExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.5;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;

   aimDeflection      = 3.003;
   muzzleVelocity     = 40.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};



//----------------------------------
////////////////
//BOOM

MineData GKExplosion
{
	className = "Mine";
    shapeFile = "breath";
    shadowDetailMask = 1;
    explosionId = mineExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = 0;
	drag = 100.0;
};

ExplosionData GKmineExp
{
   shapeName = "bluex.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;
   timeScale = 1.5;
   timeZero = 0.0;
   timeOne  = 0.250;
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

GrenadeData GKEffect
{
	explosionTag       = GKmineExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $MineDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = 0.0;
};

//---------------------------------------

MineData ShockExplosion1
{
	className = "Mine";
    shapeFile = "breath";
    shadowDetailMask = 1;
    explosionId = mineExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = 0;
	drag = 20.0;
};

ExplosionData ShockmineExp
{
   shapeName = "shockwave_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

GrenadeData ShockEffect
{
	explosionTag       = ShockmineExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $MineDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = 0.0;
};