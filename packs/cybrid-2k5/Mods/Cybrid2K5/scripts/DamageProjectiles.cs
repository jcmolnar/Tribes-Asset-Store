//====================================------------------
// Energy Damage FX
//====================================------------------
GrenadeData EnergyFX1
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = EnergyFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};
//====================================------------------
// Fusion Damage FX
//====================================------------------
GrenadeData FusionFX1
{
   bulletShapeName    = "Plasmabolt.dts";
   explosionTag       = FusionFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData FusionFX2
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = FusionFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};
//====================================------------------
// Pulse Damage FX
//====================================------------------
GrenadeData PulseFX1
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = PulseFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};

GrenadeData PulseFX2
{
   bulletShapeName    = "paint.dts";
   explosionTag       = PulseFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};
//====================================------------------
// Radiation Damage FX
//====================================------------------
GrenadeData RadiationFX1
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = RadiationFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData RadiationFX2
{
   bulletShapeName    = "paint.dts";
   explosionTag       = RadiationFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};
//====================================------------------
// AntiMatter Damage FX
//====================================------------------
GrenadeData AntiMatterFX1
{
   bulletShapeName    = "shield.dts";
   explosionTag       = AntiMatterFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData AntiMatterFX2
{
   bulletShapeName    = "hflame.dts";
   explosionTag       = AntiMatterFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};
//====================================------------------
// ION Damage FX
//====================================------------------
GrenadeData IONFX1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = IONFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData IONFX2
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = IONFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};
//====================================------------------
// Bullet Damage FX
//====================================------------------
GrenadeData BulletFX1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BulletFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};
//====================================------------------
// Fire Damage FX
//====================================------------------
GrenadeData FireFX1
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = FireFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData FireFX2
{
   bulletShapeName    = "plastrail.dts";
   explosionTag       = FireFX2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
//====================================------------------
// EMP Damage FX
//====================================------------------
GrenadeData EMPFX1
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = EMPFX1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;  
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionex.dts";
};