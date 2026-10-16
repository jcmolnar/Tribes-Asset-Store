# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$FlamerDamageType      =  2;
$PPCDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$GaussDamageType      =  7;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$ACDamageType        = 14;
$STRDamageType        = 15;
$LRMDamageType        = 16;
$SniperDamageType        = 17;
$InfernoDamageType = 18;
$FlashDamageType = 19;
$Inferno2DamageType = 20;
$NULLDamageType = 21;

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData GJBullet
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag    = gjExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;
   damageValue      = 0.2;
   explosionRadius  = 5.0;
   kickBackStrength = 50.0;
   damageType       = $ExplosionDamageType;

   muzzleVelocity   = 425.0; //325.0;++++
   terminalVelocity = 425.0;
//   acceleration     = 100.0;
   aimDeflection      = 0.006;
   totalTime        = 1.0;
   liveTime         = 1.0;

   lightRange       = 4.0;
   lightColor = { 1, 1, 1 };

   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 500;
   trailWidth  = 0.5; //0.3;
};
BulletData GJBullet2
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag    = InfernoExp2;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;
   damageValue      = 0.1;
   explosionRadius  = 5.0;
   kickBackStrength = 50.0;
   damageType       = $InfernoDamageType;

   muzzleVelocity   = 425.0; //325.0;++++
   terminalVelocity = 425.0;
   aimDeflection      = 0.006;
   totalTime        = 1.0;
   liveTime         = 1.0;

   lightRange       = 4.0;
   lightColor = { 1, 1, 1 };

   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 500;
   trailWidth  = 0.5; //0.3;
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData FlakShell
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 100.0;
   muzzleVelocity   = 400; //200.0;++++
   terminalVelocity = 400; //200.0;++++
   acceleration     = 1.0;
   totalTime        = 2.5; //1.5;
   liveTime         = 2.5; //1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++
GrenadeData LMechMortarShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.55; //0.45;++++
   damageType         = $ExplosionDamageType; //$FlashDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};
GrenadeData LMechMortarShell2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = infernoExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1375;//0.1125;++++
   damageType         = $Inferno2DamageType; //$FlashDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//++++++++++++++++++++++
GrenadeData HMechMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.95; //0.8;++++
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
GrenadeData HMechMortarShell2
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
GrenadeData HMechMortarShell3
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = infernoExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2375; //0.2;++++
   damageType         = $Inferno2DamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//++++++++++++++++++++++
RocketData GaussGunShell
{
   bulletShapeName = "paint.dts"; //"Mortar.dts";
   explosionTag    = gaussExp;

   collisionRadius = 0.0;
   mass            = 150.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $GaussDamageType;

   muzzleVelocity   = 800.0;
   terminalVelocity = 800.0;
   acceleration     = 0.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
	lightColor = { 0.85, 0.25, 0.25 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts"; //"rsmoke.dts";++++
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};

BulletData GaussGunShell2 //Explosive Inferno++++
{
   bulletShapeName = "paint.dts"; //"Mortar.dts";
   explosionTag    = InfernoExp;

   collisionRadius = 0.0;
   mass            = 150.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $Inferno2DamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 30.0;

   muzzleVelocity   = 800.0;
   terminalVelocity = 800.0;
   acceleration     = 0.0;
   aimDeflection      = 0;

   totalTime        = 6.5;
   liveTime         = 8.0;
   isVisible          = True;

   lightRange       = 5.0;
	lightColor = { 0.85, 0.25, 0.25 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts"; //"rsmoke.dts";++++
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};

BulletData GaussGunShell3 //explosive shrapnel++++
{
   bulletShapeName = "paint.dts"; //"Mortar.dts";
   explosionTag    = gaussExp2;

   collisionRadius = 0.0;
   mass            = 150.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5; //0.525;
   damageType       = $GaussDamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 30.0;

   muzzleVelocity   = 800.0;
   terminalVelocity = 800.0;
   acceleration     = 0.0;
   aimDeflection      = 0;

   totalTime        = 6.5;
   liveTime         = 8.0;
   isVisible          = True;

   lightRange       = 5.0;
	lightColor = { 0.85, 0.25, 0.25 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts"; //"rsmoke.dts";++++
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData SniperGunShell
{
   bulletShapeName = "paint.dts";
   explosionTag    = debrisExpSmall;
   isVisible          = True;//+++++++

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;
   damageValue      = 0.4;
   damageType       = $SniperDamageType;

   muzzleVelocity   = 2000.0; //4000.0;++++
   terminalVelocity = 2000.0; //4000.0;++++
   acceleration     = 0.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 4.0;
   lightColor = { 1, 0, 0 };

   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 500;
   trailWidth  = 0.3;
};
BulletData SniperGunShell2
{
   bulletShapeName = "paint.dts";
   explosionTag    = debrisExpSmall;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;
   damageValue      = 0.3;
   damageType       = $SniperDamageType;

   muzzleVelocity   = 2000.0; //4000.0;+++++++
   terminalVelocity = 2000.0; //4000.0;+++++++
   acceleration     = 0.0;
   aimDeflection      = 0.001;
   isVisible          = True;//+++++++

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 4.0;
   lightColor = { 1, 0, 0 };

   inheritedVelocityScale = 0.5;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.013; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.004; //0.003; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.54; //0.42;++++++++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};
//++++++++++++++++++++++
BulletData Ultra5Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.013; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.54; //0.42;+++++++++++++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra5Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.013;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.54; //0.42;+++++++
   liveTime         = 0.54; //0.42;+++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 35;
   trailWidth  = 0.3;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.023; //0.011;
   damageType         = $ACDamageType;

   aimDeflection      = 0.006; //0.005; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.372; //0.31;++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};
BulletData Ultra10Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.023; //0.007;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.372; //0.31;++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 100; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra10Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.023;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.372; //0.31;++++++++++
   liveTime         = 0.372; //0.31;++++++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 45;
   trailWidth  = 0.5;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData Ultra20Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.044; //0.0262;
   damageType         = $ACDamageType;

   aimDeflection      = 0.008; //0.007; 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.25;//++++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};
BulletData Ultra20Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.044;
   damageType         = $ACDamageType;

   aimDeflection      = 0.020; // 0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.25;//++++++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData Ultra20Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.044; //0.0262;
   damageType       = $ACDamageType;

   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.25;//++++++++
   liveTime         = 0.25;//++++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 55;
   trailWidth  = 0.7;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.025;
   damageType         = $ACDamageType;

   aimDeflection      = 0.002; //0.001; 0.005; (Base Chaingun Deflection), larger number = more deflection
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.605; //0.52;+++++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};
BulletData AC5Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.025;
   damageType         = $ACDamageType;

   aimDeflection      = 0.012; //0.020;++++
   muzzleVelocity     = 425.0; //(Base Chaingun)
   totalTime          = 0.605; //0.52;+++++++++++
   inheritedVelocityScale = 1.0;//(Base Chaingun)
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30; //(Base Chaingun)
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC5Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.025;
   damageType       = $ACDamageType;

   aimDeflection      = 0.001; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.605; //0.52;++++++++++
   liveTime         = 0.605; //0.52;++++++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 35;
   trailWidth  = 0.3;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ACDamageType;

   aimDeflection      = 0.003; //0.002; 0.003; (Ultra10 value)
   muzzleVelocity     = 425.0;
   totalTime          = 0.435; //0.41;+++++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};
BulletData AC10Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 0.75;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ACDamageType;

   aimDeflection      = 0.012; //0.020;++++
   muzzleVelocity     = 425.0;
   totalTime          = 0.435; //0.41;+++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0; //1.0;
   tracerLength       = 100;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC10Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $ACDamageType;

   aimDeflection      = 0.002; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.435; //0.41;+++++++++
   liveTime         = 0.435; //0.41;+++++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 45;
   trailWidth  = 0.5;
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData AC20Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ACDamageType;

   aimDeflection      = 0.004; //0.005; (Base Chaingun Deflection)
   muzzleVelocity     = 425.0;
   totalTime          = 0.337; //0.31;+++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};
BulletData AC20Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1; //ACExpSmall;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ACDamageType;

   aimDeflection      = 0.012; //0.020;++++
   muzzleVelocity     = 425.0;
   totalTime          = 0.337; //0.31;++++++++++++++
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0; //1.0;
   tracerLength       = 30;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData AC20Tracer
{
   bulletShapeName = "bullet.dts";
   explosionTag    = ACExpSmall;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ACDamageType;

   aimDeflection      = 0.004; //0.005; (Base Chaingun Deflection)
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;

   totalTime        = 0.337; //0.2;+++++++++
   liveTime         = 0.337; //0.2;+++++++++

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

   // rocket specific
   trailType   = 1;
   trailLength = 55;
   trailWidth  = 0.7;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData HVAC10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $ACDamageType;

   aimDeflection      = 0.0008;
   muzzleVelocity     = 800.0;
   totalTime          = 0.4;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 3000;
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData HVAC10Bullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp1;
   expRandCycle       = 3;
   mass               = 1.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;
   damageValue        = 0.0725;
   damageType         = $ACDamageType;

   aimDeflection      = 0.0008;
   muzzleVelocity     = 800.0;
   totalTime          = 0.4;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 3000;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData MachineGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 0.01;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.01; //0.009
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002; //0.0011;
   muzzleVelocity     = 425.0;
   totalTime          = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = True; //False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MachineGunBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 0.01;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.01; //0.009
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005; //0.01;++++++++++++++++
   muzzleVelocity     = 425.0;
   totalTime          = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = True; //False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//+++++++++++++++++++++++++++++++++++++++++++
RocketData PPCBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $PPCDamageType;
   explosionRadius  = 5.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;//+++++++
   liveTime         = 8.0;//8.0;++++++++

   lightRange       = 7.0;
   lightColor       = { 0.25, 0.25, 1.0 };//++++++

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.6;

   soundId = SoundJetHeavy;
   rotationPeriod = 0.1;
};
BulletData PPCBolt2
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp; //energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $PPCDamageType;
   explosionRadius  = 5.0;
   kickBackStrength = 60.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.02; //0.015;
   isVisible          = True;//+++++++++++

   totalTime        = 4.0; //6.5;
   liveTime         = 5.0; //8.0;

   lightRange       = 7.0;
   lightColor       = { 0.25, 0.25, 1.0 };//++++++

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.35;

   soundId = SoundJetHeavy;
   rotationPeriod = 0.1;
};
BulletData PPCBolt3
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp; //energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PPCDamageType;
   explosionRadius  = 5.0;
   kickBackStrength = 60.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.007; //0.015;
   isVisible          = True;//+++++++++++

   totalTime        = 4.0; //6.5;
   liveTime         = 5.0; //8.0;

   lightRange       = 7.0;
   lightColor       = { 0.25, 0.25, 1.0 };//++++++

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.35;

   soundId = SoundJetHeavy;
   rotationPeriod = 0.1;
};
//++++++++++++++++++++++++++++++++++
GrenadeData FlamerShell
{
//   bulletShapeName    = "grenade.dts";
   explosionTag       = FlameBurstExp;
   collideWithOwner   = True;
   ownerGraceMS       = 100;
   collisionRadius    = 10.0;
   mass               = 0.5;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01; //0.005;++++++++++++
   damageType         = $FlamerDamageType;
   explosionRadius    = 8.0;
   kickBackStrength   = 1.0;

   maxLevelFlightDist = 150;
   totalTime          = 0.6;    // special meaning for grenades...
   liveTime           = 0.6;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;

	lightRange = 6.0;
	lightColor = { 0.55, 0.40, 0.1 };

   smokeName              = "plastrail.dts";

	soundId = SoundFlyerActive;
};
RocketData FlamerShell2
{

   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = FlamerExp;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass        = 1;
   damageValue        = 0.175; //0.125;+++++++++++++++
   damageType         = $InfernoDamageType; //$FlamerDamageType;++++
   explosionRadius    = 12.0;

   muzzleVelocity   = 55.0;
   terminalVelocity = 55.0;
   acceleration     = 0.0;

   totalTime        = 1.5;
   liveTime         = 1.5;

   lightRange       = 2.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

	lightRange = 8.0;
	lightColor = { 0.55, 0.40, 0.1 };

   // rocket specific
   trailType   = 2;
   trailString = "plastrail.dts";
   smokeDist   = 30;

	soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
GrenadeData MortarTurretShell    //LongTom
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 800; //400
   collisionRadius    = 1.0;
   mass               = 0.0000001;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 1.1; //1.1;+++++++++++++++++++
   damageType         = $ExplosionDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 5000;
   totalTime          = 5.0;
   liveTime           = 0.001; //0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts"; //"rsmoke.dts";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData LRM5Missile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    
   damageValue      = 0.065; 
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 15.0;

   muzzleVelocity    = 100; //80.0;+++++++
   terminalVelocity = 200; //130.0;+++++++
   acceleration     = 20.0; //10.0;++++++++++++
   aimDeflection      = 0.1;

   totalTime         = 5; //7;+++++++
   liveTime          = 5; //7;+++++++
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 25; //40.0;++++++++
   nonSeekingTurningRadius = 25; //40.0;++++++++
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData LRM5Missile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    
   damageValue      = 0.065; 
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 15.0;

   muzzleVelocity    = 100; //80.0;+++++++
   terminalVelocity = 200; //130.0;+++++++
   acceleration     = 20.0; //10.0;++++++++++++
   aimDeflection      = 0.1;

   totalTime         = 5; //7;+++++++++
   liveTime          = 5; //7;+++++++++
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10; //20.0;++++
   nonSeekingTurningRadius = 10; //20.0;++++
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
//++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData LRM5Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       
   damageValue      = 0.065;
   damageType       = $LRMDamageType;
   explosionRadius  = 7.0;
   kickBackStrength = 35.0;

   muzzleVelocity    = 100; //80.0;+++++++
   terminalVelocity = 200; //130.0;+++++++
   acceleration     = 20.0; //10.0;++++++++++++
   aimDeflection      = 0.008; //0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 5; //7;+++++++
   liveTime          = 5; //7;+++++++
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;              
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData ThunderLRMRocket
{

   bulletShapeName    = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;
   damageValue        = 0.3; //0.125;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 3.5;
   liveTime         = 3.5;

   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;              
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
function ThunderLRMRocket::onAdd(%this)
{
	schedule("DeployMines(" @ %this @ " , 1);",1,%this);
}
function DeployMines(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","LRMMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,false);
		%obj = newObject("","Mine","LRMMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.0,false);
		%obj = newObject("","Mine","LRMMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6.0,false);
		%obj = newObject("","Mine","LRMMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-6.0,false);
		%count -= 1;
		schedule("DeployMines(" @ %this @ " , " @ %count @ ");",1,%this);
	}
}
RocketData ThunderLRMRocket2
{

   bulletShapeName    = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass        = 1;
   damageValue        = 0.3; //0.125;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 3.5;
   liveTime         = 3.5;

   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;              
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
function ThunderLRMRocket2::onAdd(%this)
{
	schedule("DeployCluster(" @ %this @ " , 1);",1,%this);
}
function DeployCluster(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","LRMCluster");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.4,false);
		%obj = newObject("","Mine","LRMCluster");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1.0,false);
		%obj = newObject("","Mine","LRMCluster");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.4,false);
		%obj = newObject("","Mine","LRMCluster");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1.0,false);
		%count -= 1;
		schedule("DeployCluster(" @ %this @ " , " @ %count @ ");",1,%this);
	}
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData STR2Missile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.13;
   damageType       = $STRDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 25.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
//   aimDeflection      = 0.1;

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 10.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts"; 
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
SeekingMissileData STR2Missile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.065;
   damageType       = $InfernoDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 25.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
//   aimDeflection      = 0.1;

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 10.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
BulletData STR2Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.13;
   damageType       = $STRDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;++++++++++++++++++++

   soundId = SoundJetHeavy;
};
BulletData STR2Rocket2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.065;
   damageType       = $InfernoDamageType;
   explosionRadius  = 6.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;++++++++++++++

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData ArrowIVMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 60.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++++

   soundId = SoundJetHeavy;
};
SeekingMissileData ArrowIVMissile2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 60.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++

   soundId = SoundJetHeavy;
};
SeekingMissileData ArrowIVTMissile //++++ArrowIV for turret++++
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 10.0;
   nonSeekingTurningRadius = 10.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;++++++++++++++

   soundId = SoundJetHeavy;
};
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData F1aker 
{ 
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExpHV; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 0.01; 
	liveTime = 0.01; 
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5; 
}; 
function F1aker::onAdd(%this) 
{
	%t = $F1aky;//+++++++++
	%markerPos = $F1aky2;
	$F1aky = ""; 
	$F1aky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);		
	%vehicle = newObject("",flier,ShortCoolProj,true);
	Gamebase::setMapName(%vehicle,"ArrowIV");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	doneposs(%client);
	Client::setControlObject(%client, %vehicle); 
}
RocketData F1aker2 
{ 
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExpHV; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 0.01; 
	liveTime = 0.01; 
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5; 
}; 
function F1aker2::onAdd(%this) 
{
	%t = $F1aky;
	%markerPos = $F1aky2;
	$F1aky = ""; 
	$F1aky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);		
	%vehicle = newObject("",flier,ShortCoolProj2,true);
	Gamebase::setMapName(%vehicle,"ArrowIV");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	doneposs(%client);
	Client::setControlObject(%client, %vehicle); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData F1ScoutDrone 
{ 
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExpHV; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 10.0; 
	terminalVelocity = 10.0; 
	acceleration = 0; 
	totalTime = 0.01; 
	liveTime = 0.01; 
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5; 
}; 
function F1ScoutDrone::onAdd(%this) 
{
	%t = $F1aky;
	%markerPos = $F1aky2;
	$F1aky = ""; 
	$F1aky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);		
	%vehicle = newObject("",flier,ScoutDroneProj,true);
	Gamebase::setMapName(%vehicle,"Scout Drone");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	doneposs(%client);
	Client::setControlObject(%client, %vehicle); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData ArrowIVRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 60.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
RocketData ArrowIVRocket2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 17.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 60.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData ThunderboltMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp2;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 14.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++++

   soundId = SoundJetHeavy;
};
SeekingMissileData ThunderboltMissile2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 14.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++

   soundId = SoundJetHeavy;
};
//++++++++++++++++++++
RocketData ThunderboltRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp2;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 14.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
RocketData ThunderboltRocket2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 14.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
SeekingMissileData Thunderbolt5Missile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp2;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.275;
   damageType       = $MissileDamageType;
   explosionRadius  = 12.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++++

   soundId = SoundJetHeavy;
};
SeekingMissileData Thunderbolt5Missile2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.137;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 12.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 15.0;
   nonSeekingTurningRadius = 15.0;
   proximityDist     = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 30; //1.8;+++++++++++++++++++

   soundId = SoundJetHeavy;
};
//++++++++++++++++++++
RocketData Thunderbolt5Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp2;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.275;
   damageType       = $MissileDamageType;
   explosionRadius  = 12.0;
   kickBackStrength = 175.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
RocketData Thunderbolt5Rocket2
{
   bulletShapeName = "rocket.dts";
//   explosionTag    = LargeShockwave;
   explosionTag    = infernoExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.137;
//   damageType       = $MissileDamageType;
//   explosionRadius  = 25.0;
//   kickBackStrength = 250.0;
   damageType       = $Inferno2DamageType;
   explosionRadius  = 12.0;
   kickBackStrength = 50.0;

   muzzleVelocity    = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   isVisible          = True;//+++++++++++

   totalTime         = 10;
   liveTime          = 10;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData MedLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.3; //0.5;+++++++++++++

   lightRange        = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData MedLaserShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = laserExp1;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $LaserDamageType;

   muzzleVelocity   = 10000.0;
   terminalVelocity = 10000.0;
   acceleration     = 0.0;

   totalTime        = 0.8; //0.033;
   liveTime         = 0.8; //0.033;

   lightRange       = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   inheritedVelocityScale = 0.0;//0.5;+++++++++++

};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData MedLaserTurretShell
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.025;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData LrgLaserTurretShell
{
   laserBitmapName   = "forcefield1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.04;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5; //0.8;++++++++++++++++++

   lightRange        = 6.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
LaserData LrgLaser
{
   laserBitmapName   = "forcefield1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5; //0.8;++++++++++++++++++

   lightRange        = 6.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RocketData LrgLaserShell
{
   bulletShapeName = "bullet.dts";
   explosionTag    = laserExp0;

   collisionRadius = 0.0;
   mass            = 0.0;

   damageClass      = 0;    
   damageValue      = 0.3;
   damageType       = $LaserDamageType;

   muzzleVelocity   = 10000.0;
   terminalVelocity = 10000.0;
   acceleration     = 0.0;

   totalTime        = 0.8; //0.1;
   liveTime         = 0.8; //0.1;

   lightRange       = 6.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   inheritedVelocityScale = 0.0;

};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
laserData MediumPulseLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.003; //0.0025;+++++++++
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.3;

   lightRange        = 2.0;
	lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
laserData LargePulseLaser
{
   laserBitmapName   = "forcefield1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.004;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
GrenadeData SmokeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.01;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "snowplume.dts"; //"smoke.dts";
};

function SmokeShell::onAdd(%this)
{
	schedule("DeploySmoke(" @ %this @ " , 1);",1.8,%this);
}

function DeploySmoke(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.65,false);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.65,false);
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.35,false);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.35,false);
		%count -= 1;
		schedule("DeploySmoke(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//++++++++++++++++++++
GrenadeData SmokeShell2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = BangExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.07;
   damageType         = $DebrisDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "snowplume.dts"; //"smoke.dts";
};

function SmokeShell2::onAdd(%this)
{
	schedule("DeploySmoke3(" @ %this @ " , 1);",1.8,%this); //2+++++
}

function DeploySmoke3(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.35,false);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.35,false);
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.65,false);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.65,false);
		%count -= 1;
		schedule("DeploySmoke3(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
LightningData missileNARC
{
  bitmapName   = "laserPulse.bmp";//++++
  boltLength = 400.0;
  coneAngle = 2.0; //35
  damagePerSec = 0.002;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.300; //0.1
  updateTime = 2000;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
//  lightColor = { 0.25, 0.25, 0.85 };
//  soundId = SoundELFFire;
};
function missileNARC::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
MessageAll(%shooterId, 1,"shooterId:"@%shooterId@" target:"@%target@" damPerSec:"@%damPerSec@"");
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++
LightningData missileTAG
{
  bitmapName   = "laserPulse.bmp";//++++
  boltLength = 400.0;
  coneAngle = 2.0; //35
  damagePerSec = 0.0;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.300; //0.1
  updateTime = 2000;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
//  lightColor = { 0.25, 0.25, 0.85 };
//  soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
 { 
messageAll(%shooterId, 1,"shooterId:"@%shooterId@" target:"@%target@" damPerSec:"@%damPerSec@"");
if(%damPerSec == 0.0) 
	{
//	ixLockLaser(%target, %shooterId); 
	artyStrike(%target, %shooterId); 
	return; 
	} 
if(%damPerSec == 0.002) 
	{
	NARCStrike(%target, %shooterId);
	MessageAll(%shooterId, 1,"shooterId:"@%shooterId@" target:"@%target@" damPerSec:"@%damPerSec@"");
	return; 
	} 
if(%shooterId) 
	{ 
//	if(%damPerSec > 0.01) 
//	%damageType = $TADamageType; 
//	else
	%damageType = $ElectricityDamageType; 
	} 
else 
%damageType = $LaserDamageType; 
%damVal = %timeSlice * %damPerSec; 
%enVal = %timeSlice * %enDrainPerSec; 
GameBase::applyDamage(%target, %damageType, %damVal, %pos, %vec, %mom, %shooterId); 
%energy = GameBase::getEnergy(%target); %energy = %energy - %enVal; 
if (%energy < 0) 
{ 
%energy = 0; 
} 
GameBase::setEnergy(%target, %energy); 
} 

function NARCStrike(%target,%shooterId)
{
//if($NARCtime[%shooterId] > $)
//	{
   GameBase::setIsTarget(%target,true);
//	%player = Client::getOwnedObject(%shooterId);
//	%object = getObjectType(%target); 
//	%trans = GameBase::getMuzzleTransform(%player);
//	%vel = Item::getVelocity(%player);
//	playSound(SoundFireLaser,GameBase::getPosition(%player));
//	Projectile::spawnProjectile("ArrowIVRocket",%trans,%player,%vel);
//	Client::sendMessage(%shooterId,0,"-NARC Lock Aquired- " @ %target @ "~wmine_act.wav");
		Client::sendMessage(%shooterId, 1,"shooterId:"@%shooterId@" target:"@%target@" object:"@%object@" trans:"@%trans@" $NARCtime:"@%NARCtime@"");
//	$NARCtime[%shooterId] = 10;
//	}
//else
//	{
//	Client::sendMessage(%shooterId, 0,"-NARC Scanning-");
//	return;
//	$NARCtime[%shooterId] = $NARCtime[%shooterId] - 1;
//	}
}

function ixLockLaser(%target, %client) 
{
	%player = Client::getOwnedObject(%client); 
	%object = getObjectType(%target); 
	if(%target == $ixLockedTarget[%client]) 
		{
		if(((Player::getMountedItem(%player,$WeaponSlot) == STR2) || (Player::getMountedItem(%player,$WeaponSlot) == STR6)) && ($ixLockTime[%client] > 40)) //working delay :) +++++++
			{
			 schedule("STRImage::ShootSmart(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.2;
			if(%object == "Player" || %object == "Flier") 
				{ 
				%tgtClient = GameBase::getOwnerClient($ixLockedTarget[%client]); 
		  		Client::sendMessage(%tgtClient,1,"-WARNING- Streak missile lock detected~wAccess_Denied.wav");
			  	Client::sendMessage(%player,0,"-Lock Aquired- " @ %target @ "~wmine_act.wav"); //not working+++++
				} 
			}
		else
		$ixLockTime[%client] += 1.0; 
		}
	else 
	{ 
	$ixLockTime[%client] = 0; 
	$ixLockedTarget[%client] = %target; 
	if(%object == "Player") 
		{ 
		%tgtClient = GameBase::getOwnerClient($ixLockedTarget[%client]); 
		%name = Client::getName(%tgtClient); 
		} 
	else 
	{ 
	%name = GameBase::getMapName(%target); 
	if(%name == "") 
		{ 
			%name = (GameBase::getDataName(%target)).description; 
		} 
	}
	$ixLockedName[%client] = %name; 
	}
//	else
//	{
//	 schedule("STR2Image::OnShootDumb(" @ %player @ ");", %timedelay);
//	} 
}

function ixFloodRockets(%client, %player, %object, %count, %warhead)
{ 
if($ixFloodRockets[%client]) 
	{ 
	%AmmoCount = Player::getItemCount(%player, "STR2Ammo"); 
	if(%AmmoCount) 
		{ 
		if((%warhead) && (%count >= %warhead) && (!Player::isDead(%player)) && (Player::getMountedItem(%player,$WeaponSlot) == STR2)) 
			{ 
			if($ixVWarhead[%client, %warhead] != "Pause") 
				{ 
				if($ixVAmmo[$ixVWarhead[%client, %warhead]] <= %AmmoCount) 
					{ 
					%pause = 1; 
					ixApplyKickback(%player, 150, 30); 
					%trans = GameBase::getMuzzleTransform(%player); 
					%vel = Item::getVelocity(%player); 
					playSound(SoundMissileTurretFire,GameBase::getPosition(%player)); 
					Projectile::spawnProjectile($ixVWarhead[%client, %warhead] @ "YieldWarhead",%trans,%player,%vel,%object); 
					Player::decItemCount(%player,"VengeanceAmmo",$ixVAmmo[$ixVWarhead[%client, %warhead]]);
					} 
				else 
				{ 
				playSound(SoundLoadWarhead,GameBase::getPosition(%player)); 
				Client::sendMessage(%client,0,"*** Vengeance: No Ammo to Fire #" @ %warhead @ " - " @ $ixVWarhead[%client, %warhead] @ "~wC_BuySell.wav"); 
				} 
			} 
			else 
			{ 
			playSound(SoundLoadWarhead,GameBase::getPosition(%player)); 
			%pause = 1.5; 
			} 
		%warhead += 1; 
		schedule("ixFloodRockets(" @ %client @ "," @ %player @ "," @ %object @ "," @ %count @ "," @ %warhead @ ");",($ixFloodSpeed * %pause)); 
			} 
		else 
		ixFloodShutdown(%client, %player, "Normal"); 
		} 
	else 
	ixFloodShutdown(%client, %player, "Ammo"); 
	} 
} 

function artyStrike(%target, %client)//++++++++%timeslice
 {
	%player = Client::getOwnedObject(%client); 
	%object = getObjectType(%target);
	if(!$HVtimer[%client]) 
		{ 
		if(%target == $HVLockedTarget[%client]) 
			{
			if((Player::getMountedItem(%player,$WeaponSlot) == TAG) && ($HVLockTime[%client] > 0))//timedelay++++
				{
				%pos = GameBase::getPosition(%target);
				%rot = GameBase::getRotation(%target);
				%forwarddist = 0;
				%zdist = 25;
				%offset = Vector::getFromRot(%rot, %forwarddist,%zdist);
				%poss = Vector::add(%pos, %offset);
//				%inv = newObject("","Turret","ArtyTurret");
				Client::sendMessage(%client,1,"-TAG Lock Aquired: " @ $HVLockedName[%client] @ ", Artillery strike in 25 seconds-"); 
				Client::sendMessage(%client,1,"-Artillery strike imminent-~wmine_act.wav"); 
				%inv = newObject("","Mine","ArtyShell");
				GameBase::setPosition(%inv,%poss);
				$HVtimer[%client] = true;
				schedule("HVtimer(" @ %client @ ");",1);
				}
			else
			$HVLockTime[%client] += 1.0; 
			}
		else 
		{ 
		$HVLockTime[%client] = 0; 
		$HVLockedTarget[%client] = %target; 
		if(%object == "Player") 
			{ 
			%tgtClient = GameBase::getOwnerClient($HVLockedTarget[%client]); 
			%name = Client::getName(%tgtClient); 
			} 
		else 
		{ 
		%name = GameBase::getMapName(%target); 
		if(%name == "") 
			{ 
				%name = (GameBase::getDataName(%target)).description; 
			} 
		}
		$HVLockedName[%client] = %name; 
		}
	}//++++++
	else
	{
	Client::sendMessage(%client,1,"-Artillery officers still reloading-~wmine_act.wav"); 
	schedule("HVtimer(" @ %client @ ", 1);",1);
	}
}
// PORT FIX: artyStrike() above sets $HVtimer[client] and schedules HVtimer(), but the author left
// HVtimer commented out (the block below; its "%count ++ 1" does not parse). So the TAG artillery
// strike worked ONCE per player for the life of the server, and every later laser tick logged
// "HVtimer: Unknown command." This is the reload timer the messages describe: the first call
// (one argument, right after a strike) stamps the time; the "still reloading" calls (two
// arguments) release the gun once 11 seconds have passed -- the author's own count of ten
// one-second ticks. No schedule() is held across a map change, so it cannot stick.
function HVtimer(%client, %again)
{
	if(%again == "")
	{
		$HVtimerAt[%client] = getSimTime();
		return;
	}
	%at = $HVtimerAt[%client];
	if(%at == "" || getSimTime() < %at || getSimTime() - %at >= 11)
		$HVtimer[%client] = false;
}
//function HVtimer(%client)
//{
	//Client::sendMessage(%client,1,"-Artillery still reloading-~wmine_act.wav"); 
//if($HVtimer[%client])
//	{
//	if(%count > 10)
//		{
//		$HVtimer[%client] = false;
//		%count = 0;
//		return;
//		}
//	else
//		{
//		%count ++ 1;
//		Client::sendMessage(%client,1,"-Artillery still reloading-~wmine_act.wav"); 
	//		schedule("HVtimer(" @ %this @ " , " @ %count @ ");",1,%this);
//		schedule("HVtimer(" @ %client @ ");",1);
//		}
//	}
//else
//	{
//	$HVtimer[%client] = false;
//	%count = 0;
//	return;
//	}
//} 

//-----------------------------------------------------------------------
TargetLaserData targetLaser2
{
   laserBitmapName   = "laserPulse.bmp";
   damageConversion  = 10.0;
   baseDamageType    = $LaserDamageType; 
   lightRange        = 1.0;
	lightColor  = { 1.0, 0.25, 0.25 };
   detachFromShooter = false;
};

//---------------------------------------------------------------------
RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 8.0;
   segmentDivisions = 8;
   beamWidth        = 0.125;
   updateTime   = 50;
   skipPercent  = 0.5;
   displaceBias = 0.1;
   lightRange = 6.0;
   lightColor = { 0.85, 0.25, 0.25 };
   soundId = SoundELFFire;
};
function RepairBolt::onAcquire(%this, %player, %target)
{
%client = Player::getClient(%player);
if (%target == %player) 
	{
	      %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
			{
			%armor = Player::getArmor(%player);//++++added fair repair script++++
			if (%armor == "larmor")
				{
				%player.repairRate = 0.04;
				}
			if (%armor == "dmarmor" || %armor == "parmor" || %armor == "xarmor")//++++
				{
				%player.repairRate = 0.035;
				}
			else
				{
				%player.repairRate = 0.05;
				}
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "Welding Torch auto-repair ON");//++++
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else 
	{
      	%player.repairTarget = %target;
		%player.repairRate   = 0.1;

		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else 
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"Welding Torch auto-repair OFF");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
%client = Player::getClient(%player);
if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
	%object = %player.repairTarget;
	if (%object == %player) 
		{
		if (GameBase::getDamageLevel(%player) == 0) 
			{
			Player::trigger(%player,$WeaponSlot,false);
			return;
			}
		}
	else 
		{
		if (GameBase::getDamageLevel(%object) == 0)
		{
				%hvObject = (GameBase::getDataName(%object)).description;
				%objectTeam = GameBase::getTeam(%object);
				%playerTeam = GameBase::getTeam(%player);
				%lastdamage = GameBase::getControlClient(%object.lastDamageObject);
%hvObject = (GameBase::getDataName(%object)).description;
//%hvRepairedMech = Player::getArmor(%object); //++++returns data name++++
%hvRepairedMech = GameBase::getDataName(%object); //++++returns data name++++
//%RepArmorName = (GameBase::getDataName(%object)).description; //++++returns blank++++
//%RepArmorName = $ArmorName[%hvRepairedMech].description; //++++returns blank unless in message format++++
//%RepArmorName = %hvRepairedMech.description; //++++returns blank++++

//   messageAll(0, "message test. Object:" @ %object @ " hvObject:" @ %hvObject @ " objectTeam:" @ %objectTeam @ " playerTeam:" @ %playerTeam @ " hvRepairedMech:" @ %hvRepairedMech @ " RepArmorName:" @ $ArmorName[%hvRepairedMech].description @ "");//++++

if (%hvObject == "Generator")
	{
	%points = 5;
	}
else if (%hvObject == "Solar Panel")
	{
	%points = 3;
	}
else if (%hvObject == "Portable Generator")
	{
	%points = 4;
	}
//++++Sensors++++++++
else if (%hvObject == "Large Radar Array")
	{
	%points = 4;
	}
else if (%hvObject == "Radar Array")
	{
	%points = 3;
	}
else if (%hvObject == "Beagle Active Probe")
	{
	%points = 2;
	}
else if (%hvObject == "Portable Radar Dish")
	{
	%points = 2;
	}
else if (%hvObject == "Portable ECM Pod")
	{
	%points = 2;
	}
//++++Stations++++++++
else if (%hvObject == "Mech Bay")
	{
	%points = 4;
	}
else if (%hvObject == "Munitions Bay")
	{
	%points = 3;
	}
else if (%hvObject == "C-3 Station")
	{
	%points = 1;
	}
else if (%hvObject == "Aerotech Hangar")
	{
	%points = 2;
	}
else if (%hvObject == "Aerotech Station")
	{
	%points = 2;
	}
else if (%hvObject == "Remote Mech Bay")
	{
	%points = 3;
	}
else if (%hvObject == "Remote Munitions Bay")
	{
	%points = 2;
	}
//++++Turrets++++++++
else if (%hvObject == "PPC Turret")
	{
	%points = 4;
	}
else if (%hvObject == "ArrowIV Turret")
	{
	%points = 3;
	}
else if (%hvObject == "Flamer Turret")
	{
	%points = 2;
	}
else if (%hvObject == "Ultra-AC20 Turret")
	{
	%points = 3;
	}
else if (%hvObject == "Long Tom")
	{
	%points = 4;
	}
else if (%hvObject == "Medium Laser Turret")
	{
	%points = 2;
	}
//++++Vehicles++++++++
else if (%hvObject == "Stingray")
	{
	%points = 4;
	}
else if (%hvObject == "Corsair")
	{
	%points = 4;
	}
else if (%hvObject == "Riever")
	{
	%points = 5;
	}
else if (%hvObject == "Leopard Class")
	{
	%points = 6;
	}
else if (%hvObject == "Union Class")
	{
	%points = 8;
	}
//++++Mechs++++++++
else if (%hvRepairedMech == "xarmor")
	{
	%points = 4;
	}
else if (%hvRepairedMech == "larmor")
	{
	%points = 4;
	}
else if (%hvRepairedMech == "parmor")
	{
	%points = 5;
	}
else if (%hvRepairedMech == "dmarmor")
	{
	%points = 5;
	}
else if (%hvRepairedMech == "driver")
	{
	%points = 5;
	}
else if (%hvRepairedMech == "carmor")
	{
	%points = 6;
	}
else if (%hvRepairedMech == "marmor")
	{
	%points = 6;
	}
else if (%hvRepairedMech == "hbarmor")
	{
	%points = 7;
	}
else if (%hvRepairedMech == "aarmor")
	{
	%points = 7;
	}
else if (%hvRepairedMech == "warmor")
	{
	%points = 8;
	}
else if (%hvRepairedMech == "rarmor")
	{
	%points = 8;
	}
else if (%hvRepairedMech == "bmarmor")
	{
	%points = 9;
	}
else if (%hvRepairedMech == "yarmor")
	{
	%points = 9;
	}
else if (%hvRepairedMech == "harmor")
	{
	%points = 10;
	}
else
	{
	return;
	}
				%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
				%objname = GameBase::getMapName(%object);
//   messageAll(0, "message test. ObjName:" @ %objname @ " lastDamage:" @ %lastdamage @ " lastdpl:" @ %lastdpl @ " client:" @ %client @ " Player:" @ %player @ "");//++++
				if(%objname == "") 
					%objname = (GameBase::getDataName(%object)).description;					
				if (%lastdpl == %client)
					{
					if ((%objectTeam == %playerTeam || %objectTeam == "-1") && (%object.lastDamageTeam == %playerTeam))
						{
						if(%hvObject == "Shape")
							{ 
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing the <f1>" @ $ArmorName[%hvRepairedMech].description @ "<f0>, because you damaged it last.",5);
							}
						else
							{
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing the <f1>" @ %hvObject @ "<f0>, because you damaged it last.",5);
							}
						}
					else if (%objectTeam != %playerTeam)
						{
						if(%hvObject == "Shape") 
							{
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing an enemy <f1>" @ $ArmorName[%hvRepairedMech].description @ "",5);
							}
						else
							{
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing an enemy <f1>" @ %hvObject @ "",5);
							}
						}
					else if (%this.lastDamageTeam != %playerTeam)
						{
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						if(%hvObject == "Shape")
							{
							bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for repairing a friendly <f1>" @ $ArmorName[%hvRepairedMech].description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
							}
						else
							{
							bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for repairing a friendly <f1>" @ %hvObject @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
							}
						}
					}
				else
					{
					if (%objectTeam != %playerTeam)
						{
						if(%hvObject == "Shape") 
							{
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing an enemy <f1>" @ $ArmorName[%hvRepairedMech].description @ "",5);
							}
						else
							{
							bottomprint(%client,"<jc><f0>You gain <f1>NO<f0> points for repairing an enemy <f1>" @ %hvObject @ "",5);
							}
						}
					else
						{
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						if(%hvObject == "Shape") 
							{
							bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for repairing a friendly <f1>" @ $ArmorName[%hvRepairedMech].description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
							}
						else
							{
							bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for repairing a friendly <f1>" @ %hvObject @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
							}
						}
					}
					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
function RepairBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damPerSec = 1.0;//+++++
   %damVal = %timeSlice * %damPerSec;
   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
}