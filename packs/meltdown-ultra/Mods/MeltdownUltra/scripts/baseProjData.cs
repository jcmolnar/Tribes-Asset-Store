// Speed Definitions
$PlasmaTurretSpeed = 50;
$DeployableTurretSpeed = 80;
$BulletSpeed = 1023.9;

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   //explosionTag       = bulletExp0;
   explosionTag       = SmokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 999.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData ChaingunBu11et
{
   bulletShapeName    = "bullet.dts";
   //explosionTag       = bulletExp0;
   explosionTag       = SmokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0015;
   muzzleVelocity     = 999.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

// ShotgunBullet
BulletData ShotgunBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = SmokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.0157;
   muzzleVelocity     = 512.0;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//-------------- RifleRound -----------------------

RocketData RifleBullet
{
   bulletShapeName  = "bullet.dts";
   explosionTag = sniperbulletExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;
   damageValue      = 0.75;
   damageType       = $SniperDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 5000.0;
   terminalVelocity = 5000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

   trailType   = 1;
   trailLength = 3000;
   trailWidth  = 0.6;

   soundId = SoundJetHeavy;

};

BulletData MassBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = boltexp1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.01;
   damageType       = $MassDamageType;

   explosionRadius  = 5;
   kickBackStrength = 150.0;

   muzzleVelocity     = 999.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData PoisonDart
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $MethaneDamageType;

   muzzleVelocity     = 999.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData ProtronBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.19;  // was 0.075
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 255.0;
   totalTime          = 1.5;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.69;  // was 0.127
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt2
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.22;  // was 0.127
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData BlasterCBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = ShockwaveFour;
	collisionRadius = 0.0;
	mass = 0.0;

    damageClass      = 1;       // 0 impact, 1, radius
    damageValue      = 1;
    damageType       = $BlasterDamageType;
	explosionRadius = 7;

    kickBackStrength = 0.0;
	muzzleVelocity = 250.0;
	terminalVelocity = 3000.0;
	acceleration = 500;
	totalTime = 14.0;
	liveTime = 14.0;
	lightRange = 5.0;
	lightColor = { 0.0, 0.0, 1.5 };
	inheritedVelocityScale = 0.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.50;
	soundId = SoundJetHeavy;
};


//======================================================================== Plasma Bolt
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.60; // was 45
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 95.0; // was 55
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData PlasmaBolt2
{
	bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 0.65;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;

	muzzleVelocity   = 105.0; // was 65
	terminalVelocity = 105.0; // was 65
	acceleration     = 105.0; // was 65
	totalTime        = 2.0;
	liveTime         = 2.0;
	lightRange       = 1.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//======================================================================== Plasma Bolt Multi
BulletData PlasmaBoltMulti
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.180;  // was 156
   damageType         = $PlasmaDamageType;
   explosionRadius    = 1.5;

   muzzleVelocity     = 225.0;
   totalTime          = 1.25;
   liveTime           = 0.175;
   lightRange         = 2.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid
BulletData PlasmaBoltRapid
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.40; // was 25
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 180.0;
   totalTime          = 2.0;
   liveTime           = 0.1;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid2
BulletData PlasmaBoltRapid2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.25;  // was 15
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 120.0;
   totalTime          = 2.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//===============================================HeatPlasmaDamageType

BulletData PlasmaHeatBolt
{
    bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.1;
	damageType       = $HeatPlasmaDamageType;
	explosionRadius  = 6.0;
	kickBackStrength = 0;

	muzzleVelocity   = 65.0; // was 65
	terminalVelocity = 65.0; // was 65
	acceleration     = 65.0; // was 65
	totalTime        = 3.0;
	liveTime         = 2.0;
	lightRange       = 1.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   //trailString = "paint.dts";
   trailString = "plastrail.dts";
   //trailString = "rsmoke.dts";
   smokeDist   = 4;

   soundId = SoundJetHeavy;
};

RocketData PlasmaHeatBolt2
{
	bulletShapeName  = "plasmatrail.dts";
   	explosionTag       = fireballExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.00001;
	damageType       = $HeatPlasmaDamageType;
	explosionRadius  = 6.0;
	kickBackStrength = 0;

	muzzleVelocity   = 65.0; // was 65
	terminalVelocity = 65.0; // was 65
	acceleration     = 65.0; // was 65
	totalTime        = 3.0;
	liveTime         = 2.0;
	lightRange       = 1.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   //trailString = "paint.dts";
   trailString = "plastrail.dts";
   smokeDist   = 4;

   soundId = SoundJetHeavy;
};


//========================================================================
//------------------   Disc Shell
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.50; // was 5
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//------------------ Power Disc Shell

RocketData PowerDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = PowerDiscExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 25.0;
   terminalVelocity = 35.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.9;
   //trailWidth  = 0.3;

   soundId = SoundJetHeavy;
   //soundId = SoundDiscSpin;
};

RocketData PowerDiscShell2
{
   bulletShapeName = "discb.dts";
   explosionTag    = PowerDiscExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 15.0;
   terminalVelocity = 25.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.9;
   //trailWidth  = 0.3;

   soundId = SoundJetHeavy;
   //soundId = SoundDiscSpin;
};

//========================================================================
//------------------   Disc Shell Multi
RocketData DiscShellMulti
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.18; // was 5
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------------------------------------------------------------------------
// RailGun
//--------------------------------------------------------------------------------------------------------

//-------------- RailRound EMP-----------------------
BulletData RailRound2
{
        bulletShapeName = "smoke.dts";
        explosionTag        = PowerDiscExp;
        mass                        = 2.0;
        collisionRadius = 0.0;
        ExplosionRadius = 7.5;
        damageClass                = 1;
        damageValue                = 0.002;
        damageType         = $EMPDamageType;
        muzzleVelocity        = 999;
        totalTime                = 9;
        liveTime                = 9;
        inheritedVelocityScale = 0.5;
        isVisible                = true;
        soundId                        = soundjetHeavy;
        rotationPeriod        = 0;
        lightRange                = 1.0;
        lightColor                = {1.0, 0.25,0.25};
};

//-------------- RailRound -----------------------

RocketData RailRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag = sniperbulletExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;
   damageValue      = 0.75;
   damageType       = $RailgunDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 5000.0;
   terminalVelocity = 5000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

   trailType   = 1;
   trailLength = 3000;
   trailWidth  = 0.6;

   soundId = SoundJetHeavy;

};

//-------------projectile-------------------------

RocketData RunGunRPG
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $GrenadeDamageType;

   explosionRadius  = 13;
   kickBackStrength = 75.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $GrenadeDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

GrenadeData SmokeBomb
{
   bulletShapeName    = "plasammo.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 1;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 15;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortarex.dts";
};

//--------------------------------------

RocketData RPG
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

//=========================== GodHammer Missile
RocketData GodHammer
{
	bulletShapeName = "rocket.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.95; // was 45
	damageType       = $MissileDamageType;
	explosionRadius  = 15;
	kickBackStrength = 80;
	muzzleVelocity   = 50.0;
	terminalVelocity = 1000.0;
	acceleration     = 150.0;
	totalTime        = 8.5;
	liveTime         = 18.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 35;
	trailWidth  = 0.40;
	soundId = SoundJetHeavy;
	rotationPeriod = 1.5;
};

//========================================================================

SeekingMissileData SeekingRPG
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.50;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
GrenadeData BettyShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.6;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
GrenadeData AntiBShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $EnergyDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData ImpactMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.50;
   damageType         = $MortarDamageType;

   explosionRadius    = 13.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};
///////////////  SmokeBomb
GrenadeData SmokeBombMortar
{
   bulletShapeName    = "plasammo.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $MortarDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 1;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 15;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortarex.dts";
};

GrenadeData EMPGrenadeShell
{
   bulletShapeName    = "mflame.dts";
   explosionTag       = PulseExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $EMPDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.25;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionbolt.dts";
   soundId = SoundELFFire;
};

RocketData RPM
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 20;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

SeekingMissileData SeekingRPM
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 20;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
};

RocketData RPEMP
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = PulseExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $EMPDamageType;

   explosionRadius  = 10;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6;

   soundId = SoundJetHeavy;
};

SeekingMissileData SeekingRPEMP
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = PulseExp;
   collisionRadius  = 0.0;

  mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $EMPDamageType;

   explosionRadius  = 10;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 15;

   soundId = SoundJetHeavy;
};

RocketData VertigoRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $EnergyDamageType;

   explosionRadius  = 13;
   kickBackStrength = 0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 200.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.14;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData VertigoMissile
{
   bulletShapeName = "mortar.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.17;
   damageType       = $EnergyDamageType;
   explosionRadius  = 13;
   kickBackStrength = 175.0;

   muzzleVelocity    = 100.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

RocketData SuperBlaster
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = boltexp1;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $BlasterDamageType;

   explosionRadius  = 3;
   kickBackStrength = 50.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 15.7;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

SeekingMissileData TurretMissile2
{
   bulletShapeName = "rocket.dts";
   explosionTag    = AODStingerExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $MissileDamageType;
   explosionRadius  = 17.5;
   kickBackStrength = 225.0;

   muzzleVelocity    = 140.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 100;
   nonSeekingTurningRadius = 100;
   proximityDist     = 10;
   smokeDist         = 3.14;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//--------------------------------------
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------

LaserData sniperlaser
{
   laserBitmapName   = "laserpulse.bmp"; //warp
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData Turretlaser
{
   laserBitmapName   = "laserpulse.bmp"; //warp
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $TurretLaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData DesignatorX
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.0;
   baseDamageType    = $NullDamageType;

   beamTime          = 5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = explosion3;
};

LaserData ParticleBeam
{
   laserBitmapName   = "warp.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.016;
   baseDamageType    = $PBWDamageType;

   beamTime          = 1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundFlierCrash;
};

LaserData TurretParticleBeam
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.016;
   baseDamageType    = $TPBeamDamageType;

   beamTime          = 1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundFlierCrash;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 50.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData destructiveCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 50.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.05;
   energyDrainPerSec = 25.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 80;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 100;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

           GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

//=======================================================================================================================
//						    Repair Class Ammos
//=======================================================================================================================

//========================================================================
RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 375;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
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

		$PlayerRepairing[%player] = "True";												//=== Player Is Repairing
		$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.repairTarget));   //=== Amount Of Damage Starting

		//echo ("***  Repair Progress Started " @ $PlayerRepairing[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
	}

	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerRepairing[%player] = "False";
	//echo ("***  Repair Progress Stopped " @ $PlayerRepairing[%player]);
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
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
	//if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
    if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == Reassembler) && %target != -1)
    {
		%object = %player.repairTarget;

		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
				$PlayerRepairing[%player] = "False";
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				if ($PlayerRepairing[%player] = True)
				{
						%objname = (GameBase::getDataName(%object)).description;

					%objectTeam = GameBase::getTeam(%object);								//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
                    // added by - Defender
                     // Meltdown Ultra
                    else if (%objname == "EMP Blast Turret")			%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Tractor Turret")		%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Disc Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "ELF Turret")				%pntval = $Score::ObjTurretS;

                    else if (%objname == "Missile Turret")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Velcro Turret")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Fusion Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Chaingun Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Laser Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Plasma Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Mitzi Blast Turret")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "AA Battery")				%pntval = $Score::ObjTurretS;
                     // Meltdown Ultra
                    else if (%objname == "Rocket Turret")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "SHB Turret")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "PBW Turret")				%pntval = $Score::ObjTurretS;
                    // added my walls and things, same as turrets repairs...
                    else if (%objname == "Mobile Teleporter Pad")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Backup TelePads")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Mobile Inventory Stn")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "5x5 Forcefield")				%pntval = $Score::ObjTurretS;
                    else if (%objname == "4x8 Forcefield")				%pntval = $Score::ObjTurretS;
                    else if (%objname == "Blast Door")				%pntval = $Score::ObjTurretS;
                    else if (%objname == "Blast Floor")				%pntval = $Score::ObjTurretS;
                    else if (%objname == "Mobile Bunker")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Shield Generator")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Enhancement Beacon")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Remote Shield Node")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Remote Cloaking Node")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Defender Designator")				%pntval = $Score::ObjTurretS;
                    // Meltdown Ultra
                    else if (%objname == "Defense Grid Node")				%pntval = $Score::ObjTurretS;
                    ////////////////
                    //END
                    else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
                    // Meltdown Ultra
                    else if (%objname == "Portable Generator")				%pntval = $Score::ObjGeneratorB;
                    //
                    else if (%objname == "Solar Panel")				%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Inventory Station")           %pntval = $Score::ObjStationA;
					else if (%objname == "Ammo Station")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
                     // Meltdown Ultra
                    else if (%objname == "Mobile Ammo Stn")			%pntval = $Score::ObjStationR;
                     // END
                    else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
                     // Meltdown Ultra
                    else if (%objname == "Mobile Command Stn")			%pntval = $Score::ObjStationR;
                     // END
                    else if (%objname == "Station Vehicle Unit")			%pntval = $Score::ObjFlier;
					else if (%objname == "Vehicle Pad")				%pntval = $Score::ObjFlier;

					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
					%score = ($Score::RepairObject + %bonus);
					%lastdamage = $lastdamageobj[%object];
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "")
						%objname = (GameBase::getDataName(%object)).description;

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								if ($ScoreOn) bottomprint(%client, "No points awarded, you were the last damager.");
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
						}
						else
						{
							%client.score = (%client.score + %score);
							if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
						}
					}

					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);
				}
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//--------------------------------------
BulletData GaussBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp3;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $GaussDamageType;

   explosionRadius    = 5.5;
   aimDeflection      = 0.005;
   muzzleVelocity     = 999.0;
   totalTime          = 10.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData GatlingBlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 999.0;
   explosionRadius    = 2.5;
   totalTime          = 10.0;
   liveTime           = 8.255;
   aimDeflection      = 0.0075;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData antiMatter
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = RocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $PulseDamageType;

   explosionRadius  = 25;
   kickBackStrength = 1024;
   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 20.0;

   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

BulletData EcstacyShot
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = Exp0;

   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.255;
   damageType         = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;


  aimDeflection      = 0.025;
   muzzleVelocity     = 255.0;


   totalTime          = 17.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

function SuperRBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);


if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.8;
                        %player.repairTarget = %player;
                        Client::sendMessage(%client, 0, "AutoRepair On");
                }
                else {
                        Client::sendMessage(%client,0,"Nothing in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
        }
        else {
      %player.repairTarget = %target;
                %player.repairRate   = 0.8;
                if (getObjectType(%player.repairTarget) == "Player") {
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
                        %name = GameBase::getMapName(%target);
                        if(%name == "") {
                                %name = (GameBase::getDataName(%player.repairTarget)).description;
                        }
                }
                if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
                        Player::trigger(%player,$WeaponSlot,false);
                        %player.repairTarget = -1;
                        return;
                }
                if (getObjectType(%player.repairTarget) == "Player") {
                        Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
                }
                Client::sendMessage(%client,0,"Repairing " @ %name);
        }
        %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
        GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SuperRBolt::onRelease(%this, %player)
{
        %object = %player.repairTarget;
        if (%object != -1) {
                %client = Player::getClient(%player);
                if (%object == %player) {
                        Client::sendMessage(%client,0,"AutoRepair Off");
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

function SuperRBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun &&
                 %player.repairTarget != -1) {
                %object = %player.repairTarget;
                if (%object == %player) {
                        if (GameBase::getDamageLevel(%player) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
                else {
                        if (GameBase::getDamageLevel(%object) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
        }
}

//====================================================================Gunboy (originally)

GrenadeData Deploybox
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = BExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 128;
   totalTime          = 4.2;    // special meaning for grenades...
   liveTime           = 4.19;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

        smokeName              = "smoke.dts";
};

function Deploybox::onAdd(%this)
{
        schedule("DeployMines(" @ %this @ ");",4.0,%this);
}

function DeployMines(%this, %player, %item, %team)
{
                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "5 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "-5 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);


               GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","AntipersonelMine");

                addToSet("MissionCleanup", %obj);
                %padd = "0 -5 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

GrenadeData ClusterBomb
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 500;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shield.dts";
};

function ClusterBomb::onAdd(%this)
{
	schedule("BombSpread(" @ %this @ ");",5.0,%this);
}

function bombspread(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

RocketData TurretDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 100;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData ChargedFusionBolt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.85;
   damageType       = $FusionDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 150.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 5.0;

   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "hflame.dts";
   smokeDist   = 3.141592654;

   soundId = SoundJetHeavy;
};

BulletData sniperXBullet
{        bulletShapeName = "smoke.dts";
        explosionTag        = SniperXExp;
        mass                        = 2.0;
        collisionRadius = 0.0;
        ExplosionRadius = 4.5;
        damageClass                = 1;
        damageValue                = 1.2;
        damageType                = $SniperXDamageType;
        muzzleVelocity        = 999;
        totalTime                = 9;
        liveTime                = 9;
        inheritedVelocityScale = 0.5;
        isVisible                = true;
        soundId                        = soundjetHeavy;
        rotationPeriod        = 0;
        lightRange                = 1.0;
        lightColor                = {1.0, 0.25,0.25};
};

GrenadeData ImplosionShell
{
   bulletShapeName    = "armorkit.dts";

  explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.1;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 450;
   totalTime          = 37.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function ImplosionShell::onAdd(%this)
{
	ImplosionShell::onDeployISHandgrenadeses(%this);
}

function ImplosionShell::onDeployISHandgrenadeses(%this)
{
	if (GameBase::isAtRest(%this))
		schedule("DeployISHandgrenadeses(" @ %this @ " , 5);",1.0,%this);
	else
		schedule("ImplosionShell::onDeployISHandgrenadeses(" @ %this @ ");",1.0,%this);
}

function DeployISHandgrenadeses(%this, %count)
{
                %obj = newObject("","Mine","MDHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MDHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MDHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MDHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MEHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
                %obj = newObject("","Mine","MEHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MEHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MEHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MEHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MEHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
                %obj = newObject("","Mine","MHandgrenade1");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-5,true);
                %obj = newObject("","Mine","MHandgrenade2");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-7.5,false);
                %obj = newObject("","Mine","MHandgrenade3");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,5,false);
                %obj = newObject("","Mine","MHandgrenade4");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,7.5,true);
                %obj = newObject("","Mine","MHandgrenade5");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%this,-1,false);
}

RepairEffectData reassemblerBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 37.5;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function reassemblerBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;

                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.2;
                        %player.repairTarget = %player;
                        Client::sendMessage(%client, 0, "AutoRepair On");
                }
                else {
                        Client::sendMessage(%client,0,"Nothing in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
        }
        else {
      %player.repairTarget = %target;
                %player.repairRate   = 0.15;
                if (getObjectType(%player.repairTarget) == "Player") {
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
                        %name = GameBase::getMapName(%target);
                        if(%name == "") {
                                %name = (GameBase::getDataName(%player.repairTarget)).description;
                        }
                }
                if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
                        Player::trigger(%player,$WeaponSlot,false);
                        %player.repairTarget = -1;
                        return;
                }
                if (getObjectType(%player.repairTarget) == "Player") {
                        Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
                }
                Client::sendMessage(%client,0,"Repairing " @ %name);
        }
        %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
        GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function reassemblerBolt::onRelease(%this, %player)
{
        %object = %player.repairTarget;
        if (%object != -1) {
                %client = Player::getClient(%player);
                if (%object == %player) {
                        Client::sendMessage(%client,0,"AutoRepair Off");
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

function reassemblerBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == reassembler &&
                 %player.repairTarget != -1) {
                %object = %player.repairTarget;
                if (%object == %player) {
                        if (GameBase::getDamageLevel(%player) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
                else {
                        if (GameBase::getDamageLevel(%object) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
        }
}

function SuperRBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.6;
                        %player.repairTarget = %player;
                        Client::sendMessage(%client, 0, "AutoRepair On");
                }
                else {
                        Client::sendMessage(%client,0,"Nothing in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
        }
        else {
      %player.repairTarget = %target;
                %player.repairRate   = 0.4;
                if (getObjectType(%player.repairTarget) == "Player") {
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
                        %name = GameBase::getMapName(%target);
                        if(%name == "") {
                                %name = (GameBase::getDataName(%player.repairTarget)).description;
                        }

               }
                if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
                        Player::trigger(%player,$WeaponSlot,false);
                        %player.repairTarget = -1;
                        return;
                }
                if (getObjectType(%player.repairTarget) == "Player") {
                        Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
                }
                Client::sendMessage(%client,0,"Repairing " @ %name);
        }
        %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
        GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SuperRBolt::onRelease(%this, %player)
{
        %object = %player.repairTarget;
        if (%object != -1) {
                %client = Player::getClient(%player);
                if (%object == %player) {
                        Client::sendMessage(%client,0,"AutoRepair Off");
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

function SuperRBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun &&
                 %player.repairTarget != -1) {
                %object = %player.repairTarget;
                if (%object == %player) {
                        if (GameBase::getDamageLevel(%player) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
                else {
                        if (GameBase::getDamageLevel(%object) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
        }
}

GrenadeData TeleportShock
{
        bulletShapeName = "breath.dts";
         explosionTag = TeleportExp;
         collideWithOwner = false;
         ownerGraceMS = 500;
         collisionRadius = 0.0;
         mass = 0.0;
         elasticity = 0.1;
         damageClass = 0;
         damageValue = 0.01;
         damageType = $NullDamageType;
         explosionRadius = 10;
         kickBackStrength = 0.0;
         maxLevelFlightDist = 1;
         totalTime = 0.05;
         liveTime = 0.05;
         projSpecialTime = 0.05;
         inheritedVelocityScale = 1.0;
         smokeName = "breath.dts";
 };

GrenadeData Electricity
{
        bulletShapeName = "breath.dts";
        explosionTag = TurretExp2;
        collideWithOwner = false;
        ownerGraceMS = 500;
        collisionRadius = 0.0;
        mass = 0.0;
        elasticity = 0.1;
        damageClass = 0;
        damageValue = 0;
        damageType = $ElectricityDamageType;
        explosionRadius = 1;
        kickBackStrength = 0.0;
        maxLevelFlightDist = 1;
        totalTime = 0.05;
        liveTime = 0.05;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 1.0;
        smokeName = "breath.dts";
};

RepairEffectData PowerCharge
{
        bitmapName = "lightningNew.bmp";
        boltLength = 20.0;
        segmentDivisions = 2;
        beamWidth = 0.27;
        updateTime = 100;
        skipPercent = 0.5;
        displaceBias = 0.03;
        lightRange = 6.0;
        lightColor = { 0.25, 0.25, 1.0 };
};

function PowerCharge::onAcquire(%this, %player, %target) 
{
        %client = Player::getClient(%player);
        %player.powerTarget = "";
        %objType = getObjectType(%target);
        if(%objType == "Player") {
                if(%target == %player) {
                        Client::sendMessage(%client,0,"Nothing to power in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
                %tc = Player::getClient(%target);
                if(%tc.isPowered) {
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
                Client::sendMessage(%client,0, "Enhancing energy systems of " @ Client::getName(%tc));
                Client::sendMessage(%tc,0, "Energy systems being enhanced by " @ Client::getName(%client));
                %tc.isPowered = true;
                %player.powerTarget = %target;
                GameBase::setRechargeRate(%target, 24);
                return;
        } 
        %obj = GameBase::getDataName(%target);
        if (GameBase::getDamageState(%target) != "Enabled") 
	  {
                Client::sendMessage(%client,0, %obj.description @ " is damaged");
                Player::trigger(%player, $WeaponSlot, false);
                return;
        }
        if(GameBase::isPowered(%target)) 
	  {
                Client::sendMessage(%client,0, %obj.description @ " is already powered");
                Player::trigger(%player, $WeaponSlot, false);
                return;
        }
        if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation" || %obj == "MobileInvent" || %obj == "PortaC" || %obj == "ArtilleryTurret" || %obj == "VehicleStation" || %obj == "VehiclePad" || %obj == "Teleporter" || %obj == "Shieldgen") {
                %player.powerTarget = %target;
                Client::sendMessage(%client,0, "Powering " @ %obj.description);
                GameBase::playSequence(%target,0,"power");
                GameBase::playSequence(%target,1);
                GameBase::setActive(%target, true);
                %target.freeP = true;
        } else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
                %player.powerTarget = %target;
                Client::sendMessage(%client,0, "Powering " @ %obj.description);
                %target.shieldStrength = 0.1;
                GameBase::setRechargeRate(%target,10);
                GameBase::setActive(%target, true);
                GameBase::playSequence(%target,0,"power");
        } else {


               Client::sendMessage(%client,0,"Nothing to power in range");
                Player::trigger(%player, $WeaponSlot, false);
        }
}

function PowerCharge::onRelease(%this, %player) 
{
        if (%player.powerTarget != "") 
	  {
                %objType = getObjectType(%player.powerTarget);
		    if(%objType == "Player") {
                        Player::getClient(%player.powerTarget).isPowered = false;
                        GameBase::setRechargeRate(%player.powerTarget, 8);
                        %player.powerTarget = "";
                        return;
                }
                if(!GameBase::isPowered(%player.powerTarget)) 
		    {
                        %obj = GameBase::getDataName(%player.powerTarget);
                        if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation" || %obj == "MobileInvent" || %obj == "PortaC" || %obj == "ArtilleryTurret" || %obj == "VehicleStation" || %obj == "VehiclePad" || %obj == "Teleporter" || %obj == "Shieldgen") {
                                (%player.powerTarget).freeP = false;
                                Station::weaponCheck(%player.powerTarget);
                                GameBase::stopSequence(%player.powerTarget,0);
                                GameBase::setSequenceDirection(%player.powerTarget,1,0);
                                GameBase::pauseSequence(%player.powerTarget,1);
                                GameBase::stopSequence(%player.powerTarget,2);
                                Station::checkTarget(%player.powerTarget);
                                %obj = (%player.powerTarget).lastPlayer;
                                GameBase::setActive(%player.powerTarget, false);
                                if(%player.powerTarget == %obj.inStation) %obj.inStation = false;
                        } else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
                                GameBase::setActive(%player.powerTarget, false);
                                (%player.powerTarget).shieldStrength = 0;
                                GameBase::setRechargeRate(%player.powerTarget,0);
                                GameBase::pauseSequence(%player.powerTarget,0);
                                Turret::checkOperator(%player.powerTarget);
                        }
                }
                %player.powerTarget = "";
        }
}

SoundData SoundWindDgust
{
   wavFileName = "wind1.wav";
   profile = Profile3dNearLoop;
};

ExplosionData SockExp
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 23.0;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.3, 0.3, 1.0 };
   colors[1]  = { 0.5, 0.5,  1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.5, 1.0, 0.8 };
};

RocketData F1aker { bulletShapeName = "breath.dts"; explosionTag = fakeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0; damageType = $ExplosionDamageType; explosionRadius = 0; kickBackStrength = 0.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 0.1; liveTime = 0.1; lightRange = 0.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; };

$DamageScale[ShortCoolProj, $ImpactDamageType] = 1.0;
$DamageScale[ShortCoolProj, $MissileDamageType] = 1.0;

function F1aker::onAdd(%this) {
        %t = $F1aky;
        %markerPos = $F1aky2;
        $F1aky = "";
        $F1aky2 = "";
        %trans = GameBase::getTransform(%this);
        %rot = getWord(%trans, 3) @ " 0 " @ getWord(%trans, 5);
        %f = Vector::getFromRot(%rot, 3.5, 2);
        %vehicle = newObject("",flier,ShortCoolProj,true);
        Gamebase::setMapName(%vehicle,"Missile");
        addToSet("MissionCleanup", %vehicle);
        %client = GameBase::getControlClient(%t);
        GameBase::setTeam(%vehicle,Client::getTeam(%client));
        GameBase::startFadeIn(%vehicle);
        %vehicle.clLastMount = %client;
        GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
        GameBase::setRotation(%vehicle,%rot);
        %client.safet = true;
        GameBase::playSound(%vehicle,bigExplosion1,0);
        doneposs(%client);
        remoteEval(%client, SetControls, true);
        Client::setControlObject(%client, %vehicle);
}

FlierData ShortCoolProj {
        description = "Phoenix Missile";
        explosionId = SockExp;
        className = "Vehicle";
        shapeFile = "rocket";
        shieldShapeName = "shield_medium";
        mass = 9.0; drag = 1.5;
        density = 1.2;
        maxBank = 10;
        maxPitch = 5000;
        maxSpeed = 52;
        minSpeed = 30;
        lift = 0;
        maxAlt = 10000;
        maxVertical = 10;
        destroyDamage = 0.1;
        maxDamage = 0.1;
        damageLevel = {0.1, 0.1};
        maxEnergy = 10;
        accel = 10.0;
        groundDamageScale = 1000.0;
        repairRate = 0;
        damageSound = SoundFlierCrash;
        ramDamage = 0.2;
        ramDamageType = $MissileDamageType;
        visibleToSensor = true;
        shadowDetailMask = 2;
        idleSound = SoundWindDgust;
        moveSound = SoundWindDgust;
        visibleDriver = true;
        driverPose = 22;
};

RocketData PimpinMissile 
{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = nappyExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.4; 
	damageType = $MissileDamageType; 
	explosionRadius = 20; 
	kickBackStrength = 200.0; 
	muzzleVelocity = 60.0; 
	terminalVelocity = 85.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.0, 0.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "plasmatrail.dts"; 
	smokeDist = 1.8; 
	soundId = SoundJetHeavy; 
};

RocketData FastPimpinMissile 
{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = nappyExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.4; 
	damageType = $MissileDamageType; 
	explosionRadius = 20; 
	kickBackStrength = 200.0; 
	muzzleVelocity = 190.0; 
	terminalVelocity = 255.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.0, 0.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "plasmatrail.dts"; 
	smokeDist = 1.8; 
	soundId = SoundJetHeavy; 
};

LightningData tractorCharge
{
   bitmapName = "lightningNewSub.bmp";

   boltLength = 75.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 5;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.00, 0.25, 0.25 };
};

function tractorCharge::pull(%client, %target)
{ 
	%myPos = GameBase::getPosition(%client);
	%yourPos = GameBase::getPosition(%target);
	%myRot = GameBase::getRotation(%client); 

	%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
	//make dir face opposite direction, thus pulls toward 

	%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
	%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0"; 
	%dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
	//so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference

	%force = 20; //not too hard and fast

	%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values 

	%diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force)); 

	if(%client.tractorMode == 1)
		%diffVector = Item::getVelocity(%target);

	Item::setVelocity(%client, %diffVector); //the actual movement function
} 

function tractorCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	tractorCharge::pull(%shooterID,%target);
} 

LightningData OmegaBolt
{
   bitmapName       = "shotgunbolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 27.5;
   coneAngle        = 350.0;
   damagePerSec      = 0.03;
   energyDrainPerSec = 10.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.155;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function OmegaBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %dectructiveValue = %DestructiveRotation;
   %DestructiveRotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
   %velocity = -20;
   %destructiveShooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%destuctiveValue);
   Player::applyImpulse(%target, %destructiveShooterDir);
   
   %player = client::getOwnedObject(%shooterId);
   %armor = Player::getArmor(%shooterId);
   %targetDestruction = GameBase::getDamageState(%targetDestuction);

   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if(%energy < 0) %energy = 0;
   GameBase::setEnergy(%target, %energy);

   if(%targetDestruction != "Destroyed")
   {
   %destructorHealth = GameBase::getDamageLevel(%player);
   if(%destructorHealth != 0) 
   GameBase::setDamageLevel(%player,%destructorHealth - (%enVal * 0.0054));
   }
}

RepairEffectData RepairItemBolt { bitmapName = "blue_blink0.bmp"; boltLength = 5.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 450; skipPercent = 0.6; displaceBias = 0.15; lightRange = 15.0; lightColor = { 1, 0.25, 0.25 }; }; 

function RepairItemBolt::onAcquire(%this, %player, %target) { 
	%client = Player::getClient(%player); 

	if (GameBase::getDamageLevel(%target) == 0) { 
		GameBase::repairDamage(%player,0.20); 
		if(%client.poisonTime > 0) {
			%client.poisonTime = -10; 
		}
		if(%client.empTime > 2) %client.empTime = 2;
		Player::decItemCount(%player,"RepairKit");
		return; 
	} 

	%name = GameBase::getMapName(%target); 
	if(%name == "") { 
		%name = (GameBase::getDataName(%target)).description; 
	} 

	Player::decItemCount(%player,"RepairKit");
	
	Client::sendMessage(%client,0,"Repair Kit used on " @ %name); 

	GameBase::repairDamage(%target,0.27); 
	return; 
} 

RocketData IonBolt 
{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.255; 
	damageType = $BlasterDamageType;
	explosionRadius = 6; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 200.0; 
	terminalVelocity = 200.0; 
	acceleration = 5.0; 
	totalTime = 5.1; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 50; 
	trailWidth = 0.3; 
	soundId = SoundJetHeavy; 
};

TargetLaserData railLaser
{
   laserBitmapName   = "laserPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;
   detachFromShooter = false;
};

LightningData FlierCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 21.0;
   coneAngle        = 55.0;
   damagePerSec      = 0.2;
   energyDrainPerSec = 0.0;
   segmentDivisions = 6;
   numSegments      = 8;
   beamWidth        = 0.125;

   updateTime   = 100;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
// These are kinda oddball dat's
// these really don't fit into
// the typical projectile catagories...
//--------------------------------------

LaserData ParticleMaser
{
   laserBitmapName   = "forcefield5.bmp";
   hitName           = "plasmaex.dts";

   damageConversion  = 0.030;
   baseDamageType  = $MaserDamageType;

   beamTime          = 0.7;

   lightRange        = 4.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;

};

//==============================================#
//============== Special projectiles not in use #
//==============================================#

//--------------------------------------
BulletData Flamesz
{
   bulletShapeName    = "tumult_large.dts";
   explosionTag       = flameEXP;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.128;
   damageType         = $FlameDamageType;

   explosionRadius  = 30;
   kickBackStrength = 0;

   aimDeflection      = 0.01;
   muzzleVelocity     = 96.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};

//============================================================================

//==========Tactical Nuke Shell

//======================================================================== Tactical Nuke Shell

GrenadeData FgcShell
{
	bulletShapeName    = "mortar.dts";
	//explosionTag       = LargeShockwave;
    //explosionTag       = ShockwaveTwo;
     explosionTag     = ShockwaveFour;   // Nice blue effect
    collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.1;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 2.5;
	damageType         = $ShrapnelDamageType;

	explosionRadius    = 75.0;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
    totalTime          = 30.0;    // special meaning for grenades...
    liveTime           = 15;
    projSpecialTime    = 0.05;

	inheritedVelocityScale = 0.5;
	smokeName              = "plasmatrail.dts";
};

function FgcShell::onAdd(%this)
{
	FgcShell::Deploy(%this);
}

function FgcShell::Deploy(%this)
{
	if (GameBase::isAtRest(%this))                 // was 3.0
	{
		schedule("NuclearExplosion(" @ %this @ ");",3.0,%this);
	}
	else
	{
		schedule("FgcShell::Deploy(" @ %this @ ");",3.0,%this);
	}
}

//===============================================================================================================
//			Tactical Nuke Shell	-Special Functions
//===============================================================================================================
function NuclearExplosion(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";

	if (!%player)
		return;

	%pos = gamebase::getposition(%this);
	%Set = newObject("nukeset",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 15, 15, 25, 0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		GameBase::applyDamage(%obj, $NukeDamageType, 1.5, GameBase::getPosition(%obj), "0 0 0", "0 0 0", %player);
	}
	deleteObject(%set);

	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);

	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBaseLight, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0);

	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBase, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%obj = newObject("","Mine","NRing1");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);

	%padd = "0 0 3.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",1.1);

	%padd = "0 0 4.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

	%padd = "0 0 8.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

	%padd = "0 0 10.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

	%obj = newObject("","Mine","NRing1");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);

	%padd = "0 0 25.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 35.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%obj = newObject("","Mine","NRing1");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);

	%padd = "0 0 45.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "-15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 15.0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 -15.0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 75.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 65";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

	deleteObject(%this);
}

function DeployBomblets(%this, %count)
{
        %clientId = %this.deployer;
        %player = Client::GetOwnedObject(%clientId);

	GameBase::setTeam(%this,GameBase::getTeam(%player));

	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomblet1");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,-20,false);
 		addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%obj = newObject("","Mine","Bomblet2");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,60,true);
	 	addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%obj = newObject("","Mine","Bomblet3");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,50,true);
		addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%count -= 1;
		schedule("DeployBomblets(" @ %this @ ", " @ %count @ ");",0.5,%this);
	}
}


