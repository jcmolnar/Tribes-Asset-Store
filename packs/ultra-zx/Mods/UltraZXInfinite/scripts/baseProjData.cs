# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$LiLRocketDamageType   = 14;
$EMPDamageType         = 15;
$LiLPOOmkiiDamageType  = 16;
$SmokeDamageType       = 17;
$MiniELFDamageType     = 18;
$BeamOfPainDamageType     = 19;
$FlashDamageType     = 20;
//----new dams
$IX2002DamageType     = 21;
$FEBDamageType     = 22;
$ShotgunDamageType     = 23;
$NukeDamageType     = 24;
$WebDamageType     = 25;
$MaliceDamageType     = 26;
//++++++++++++++++++Vehicle Project Data+++++++++++++++++++++
BulletData swordHit
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = sparkleExp;

   damageClass        = 0;
   damageValue        = 0.9;
   damageType         = $ElectricityDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = true;

   rotationPeriod = 1;
};
//-----------------------------------------------------------
BulletData BrawlerShot
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 2;
   damageType         = $shrapnelDamageType;
   explosionRadius    = 4;

   aimDeflection      = 0.005;
   muzzleVelocity     = 1000;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};
//-----------------------------------------------------------
RocketData BrawlerRocket
{	bulletShapeName = "mortar.dts";
	explosionTag = debrisExpMedium;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 5;
	kickBackStrength = 175.0;
   muzzleVelocity   = 1000.0;
   terminalVelocity = 1000.0;
   acceleration     = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "shotgunex.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//-----------------------------------------------------------
GrenadeData BrawlerMortar 
{ 
        bulletShapeName = "mortar.dts";
        explosionTag = HeavyMortarEXP;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 150;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 0.1;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "shotgunex.dts";
        soundId = SoundELFFire;
};
//-----------------------------------------------------------
BulletData MercChaingun
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletexp0;

   damageClass        = 1;
   damageValue        = 2;
   damageType         = $shrapnelDamageType;
   explosionRadius    = 4;

   aimDeflection      = 0.002;
   muzzleVelocity     = 1000;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};
//-----------------------------------------------------------
GrenadeData MercGrenadeLauncher 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = grenadeEXP;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 15;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 0.3;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "rsmoke.dts";
        soundId = SoundELFFire;
};
//-----------------------------------------------------------
RocketData MercDiscLauncher
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5;
   kickBackStrength = 5;

   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 150;
   trailWidth  = 0.15;

   soundId = SoundDiscSpin;
};
//-----------------------------------------------------------
BulletData MercFlameThrower
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};
//-----------------------------------------------------------
RocketData StarAssault
{
   bulletShapeName = "enex.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5;
   kickBackStrength = 5;

   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 150;
   trailWidth  = 0.5;

   soundId = SoundDiscSpin;
};
//-----------------------------------------------------------
BulletData StarFury
{
   bulletShapeName    = "fusionex.dts";
   //validateShape      = true;
   explosionTag       = turretExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 5;
   damageType         = $ElectricityDamageType;
   explosionRadius    = 4.0;
   
   aimDeflection      = 0.04;
   muzzleVelocity     = 300.0;
   totalTime          = 3.5;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//-----------------------------------------------------------
GrenadeData StarBomb
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 10;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};
//-----------------------------------------------------------
GrenadeData StarMortar
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 4.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionex.dts";
};
//-----------------------------------------------------------
BulletData HeavyChaingun
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = bulletexp0;

   damageClass        = 1;
   damageValue        = 2;
   damageType         = $shrapnelDamageType;
   explosionRadius    = 4;

   aimDeflection      = 0.005;
   muzzleVelocity     = 1000;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};
//-----------------------------------------------------------
GrenadeData HeavyGrenade
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 4.0;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};
//-----------------------------------------------------------
GrenadeData HeavyBazooka
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 4.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 999.0;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};
//-----------------------------------------------------------
RocketData HeavyRocket
{	bulletShapeName = "mortar.dts";
	explosionTag = debrisExpMedium;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 5.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 5;
	kickBackStrength = 175.0;
   muzzleVelocity   = 1000.0;
   terminalVelocity = 1000.0;
   acceleration     = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "plastrail.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

//======================================
// Atomizer Data
//======================================
GrenadeData AgedonGrenadeShell
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.3;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0;     // grenade time live after contact
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "laserhit.dts";

};

GrenadeData PrettySplit
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

RocketData AgedonShell
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ShrapnelDamageType;//$ExplosionDamageType

   explosionRadius  = 15;
   kickBackStrength = 80.0;

   muzzleVelocity   = 180.0;
   terminalVelocity = 180.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
	trailType = 2;
	trailString = "plasmabolt.dts";
	smokeDist = 4.5;
      soundId = SoundDiscSpin;
};

//--------------------------------------
// Nukes
//--------------------------------------
GrenadeData Nuke1
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmabolt.dts";
   smokeDist          = 0.01;
};

GrenadeData Nuke2
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData Nuke3
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 150;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmabolt.dts";
   smokeDist          = 0.01;
};

GrenadeData Nuke4
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmabolt.dts";
   smokeDist          = 0.01;
};

GrenadeData Nuke5
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmabolt.dts";
   smokeDist          = 0.01;
};

GrenadeData Nuke6
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmabolt.dts";
   smokeDist          = 0.01;
};
//--------------------------------------
// Malice/Chain By: *SlipKnot*
//--------------------------------------
BulletData MaliceBolt
{	bulletShapeName = "dustplume.dts";
	explosionTag = debrisExpSmall;
	mass = 0.07;
	damageClass = 1; // 0 impact, 1, radius
	explosionRadius = 2.0;
	damageValue = 0.5;
	baseDamageType = $MaliceDamageType;
	aimDeflection = 0.0004;
	muzzleVelocity = 180.0;
	totalTime = 2;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};
//--------------------------------------
// GripBolt By: *SlipKnot*
//--------------------------------------
RocketData IonEEBolt 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = WebExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $FlashDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//--------------------------------------
// Shotgun Taken from my other mod
// Hybrid! *DK*SlipKnot*
//======================================
BulletData ShotgunPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = ShotExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 300.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
// New LairWaster By: *SlipKnot*
//--------------------------------------
GrenadeData NapSplit
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = ExSmScreenExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;     
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

GrenadeData NapShell
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = ExSmScreenExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;      
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; 
   projSpecialTime    = 0.01; 

   inheritedVelocityScale = 0.5;
   smokeName     = "plasmatrail.dts";
};

GrenadeData NapFire
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = ExSmScreenExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	
   elasticity         = 0.45;	

   damageClass        = 1;       
   damageValue        = 0.22;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 45.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; 
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//-----------------------------------------------
// Tri-Grenade By: *SlipKnot*
//-----------------------------------------------
GrenadeData Gren1
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.49;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 250;
   totalTime          = 9.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//--------------------------------------
GrenadeData Gren2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.49;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 300;
   totalTime          = 9.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//--------------------------------------
GrenadeData Gren3
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 350;
   totalTime          = 9.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
//-----------------------------------------------
// New And Very Improved Abilities By: *SlipKnot*
//-----------------------------------------------
RocketData solarBurst1
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = grenadeExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  baseDamageType = $ExplosionDamageType;
  explosionRadius = 35.0;
  kickBackStrength = 0.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 50.0;
  acceleration = 5.0;
  totalTime = 2.1;
  liveTime = 2.1;
  lightRange = 0.0;
  lightColor = { 1.0, 1.0, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "fiery.dts";
  smokeDist = 1.9;
  soundId = soundjetheavy;
};

RocketData solarBurst2
{
  bulletShapeName = "plasmatrail.dts";
  explosionTag = plasmaExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.7;
  baseDamageType = $ExplosionDamageType;
  explosionRadius = 25.0;
  kickBackStrength = 0.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 50.0;
  acceleration = 5.0;
  totalTime = 2.1;
  liveTime = 2.1;
  lightRange = 0.0;
  lightColor = { 1.0, 1.0, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plasmaEx.dts";
  smokeDist = 2.8;
  soundId = "";
};

GrenadeData SolarTrail
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 15.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $ExplosionDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 8.0;
  maxLevelFlightDist = 250;
  totalTime = 0.2;
  liveTime = 0.2;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "breath.dts";
};

function solarBurst1::onAdd(%this)
{
schedule("trailLoop(" @ %this @ ",SolarTrail,36,0,0.15);",0.7,%this);
}
//--------------------------------------
// New Fire Wall By: *SlipKnot*
//--------------------------------------
GrenadeData firebomb
{
  bulletShapeName = "plasmaex.dts";
  explosionTag = plasmaExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 1.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.0;
  damageType = $PlasmaDamageType;
  explosionRadius = 25.0;
  kickBackStrength = 100.0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.5;
  projSpecialTime = 0.12;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmatrail.dts";
};

MineData FW1
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "plasmatrail";
  shadowDetailMask = 4;
  explosionId = grenadeexp;
  explosionRadius = 6.5;
  damageValue = 50.0;
  damageType = $PlasmaDamagetype;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData FW2
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "plasmatrail";
  shadowDetailMask = 4;
  explosionId = grenadeexp;
  explosionRadius = 6.5;
  damageValue = 50.0;
  damageType = $PlasmaDamagetype;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData FW3
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "plasmatrail";
  shadowDetailMask = 4;
  explosionId = grenadeexp;
  explosionRadius = 6.5;
  damageValue = 50.0;
  damageType = $PlasmaDamagetype;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function FW1::onAdd(%this)
{
	schedule("FW2(" @ %this @ ");",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this);
}

function FW2::onAdd(%this)
{
	schedule("FW3(" @ %this @ ");",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function FW3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

function FW1(%this) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","FW1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","FW1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function FW2(%this) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","FW2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","FW2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function FW3(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","FW3");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","FW3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function firebomb::onAdd(%this)
{
  schedule("FW1(" @ %this @ ");",0.6,%this);
}
//--------------------------------------
//New Verminator Coded By:*SlipKnot*
//--------------------------------------
BulletData VerminatorBullet
{
   bulletShapeName    = "shotgunbolt.dts";
//   validateShape      = true;
   explosionTag       = vermExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = false;

   tracerPercentage   = 100;
   tracerLength       = 30;
};
//--------------------------------------
//New ZX Data Coded By:*SlipKnot*
//--------------------------------------
BulletData IX2002ZXBullet
{
   bulletShapeName    = "plastrail.dts";
//   validateShape      = true;
   explosionTag       = bulletExp1;
   expRandCycle       = 0;
   mass               = 0.02;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $IX2002DamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
//--------------------------------------
//New FEB Data Coded By:*SlipKnot*
//--------------------------------------
BulletData FEBBullet
{
 bulletShapeName = "breath.dts";//
 explosionTag    = FEBExp;
 expRandCycle       = 0;
   mass               = 0.02;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $FEBDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   tracerPercentage   = 0;
   tracerLength       = 0;
};
//--------------------------------------
// LocK-JaW Coded By: *SlipKnot*
//--------------------------------------
SeekingMissileData StingerMissile2
{	bulletShapeName = "rocket.dts";
	explosionTag = lockjawLExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 2.0;
	damageType = $LiLRocketDamageType;
	explosionRadius = 5.5;
	kickBackStrength = 125.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 360;
	nonSeekingTurningRadius = 360.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
      // rocket specific
	trailType = 2;
	trailString = "rsmoke";
	smokeDist = 1;
};
//--------------------------------------
RocketData StingerRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = LockjawULExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 2.0;
	damageType = $LiLRocketDamageType;
	explosionRadius = 5.5;
	kickBackStrength = 175.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//--------------------------------------
BulletData Fireball
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = fireballExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;

   muzzleVelocity     = 600;
   totalTime          = 6;
   liveTime           = 1;
   //lightRange         = 1;
   //lightColor         = { 0, 0, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   //soundId = SoundJetLight;
};

//--------------------------------------
GrenadeData SmScreen
{ 
        bulletShapeName = "smoke.dts";
        explosionTag = SmScreenExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0;
        mass = 9;
        elasticity = 0.01;
        damageClass = 1;
        damageValue = 0.2;
        damageType = $SmokeDamageType;
        explosionRadius = 5;
        kickBackStrength = 0;
        maxLevelFlightDist = 250;
        totalTime = 1;
        liveTime = 32;
        projSpecialTime = 0.08;
        inheritedVelocityScale = 0.5;
        smokeName = "flash_small.dts";
        soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData ExSmScreen
{ 
        bulletShapeName = "fusionex.dts";
        explosionTag = ExSmScreenExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0;
        mass = 9;
        elasticity = 0.01;
        damageClass = 1;
        damageValue = 280;
        damageType = $ShrapnelDamageType;
        explosionRadius = 5;
        kickBackStrength = 0;
        maxLevelFlightDist = 250;
        totalTime = 10;
        liveTime = 6;
        projSpecialTime = 0.01;
        inheritedVelocityScale = 0.5;
        smokeName = "plasmatrail.dts";
        soundId = SoundELFFire;
};


//--------------------------------------
RocketData FireScreen
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = FireScreenExp;
   collisionRadius  = 0;
   mass             = 2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20;
   kickBackStrength = 15;
   muzzleVelocity   = 80;
   terminalVelocity = 160;
   acceleration     = 1;
   totalTime        = 3;
   liveTime         = 1;
   //lightRange       = 5;
   //lightColor       = { 1, 1, 1 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData SpellAbilityProj
{
   bulletShapeName    = "lfemale.dts";
//   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 100;
   //tracerLength       = 30;
};

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = ZXChainExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = false;

   tracerPercentage   = 100;
   tracerLength       = 30;
};

//--------------------------------------
// IX MayHem Gun Re-Coded By: *SlipKnot*
//--------------------------------------
BulletData LiLPOOmkiBullet
{
   bulletShapeName    = "smoke.dts";
//   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.02;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $BulletDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

//--------------------------------------
// Rail Gun Re-Coded By: *SlipKnot*
//--------------------------------------
BulletData LiLPOOmkiiBullet
{
   bulletShapeName    = "chainspk.dts";
//   validateShape      = true;
   explosionTag       = bulletExp2;
   expRandCycle       = 0;
   mass               = 0.02;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $LiLPOOmkiiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 3000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   tracerPercentage   = 0;
   tracerLength       = 0;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 500.0;
   totalTime          = 2;
   liveTime           = 1;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = BlasterExp;

   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 600.0;
   totalTime          = 2;
   liveTime           = 1;

   //lightRange         = 3.0;
   //lightColor         = { 0.25, 0.25, 1.0 };
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
   damageValue        = 1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;

   //lightRange         = 3.0;
   //lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
// New Bolt By: *SlipKnot*
//--------------------------------------
BulletData GrBlasterBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = GrblasterExp;

   damageClass        = 0;
   damageValue        = 1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;

   //lightRange         = 3.0;
   //lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};


//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5;
   kickBackStrength = 5;

   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.1;

   soundId = SoundDiscSpin;
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
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 9.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
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
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//---------------------------------------
GrenadeData LiLFFBShell 
{ 
        bulletShapeName = "mortar.dts";
        explosionTag = HeavyMortarEXP;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 150;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 0.1;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "plastrail.dts";
        soundId = SoundELFFire;
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
   totalTime          = 9.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//--LiLRocket 4 projectiles-listening to Orbital The End Of NoWhere 112600
//--------------------------------------
SeekingMissileData LiLRocketEMP
{ 
   bulletShapeName = "fusionex.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.3;
   damageType = $EMPDamageType;
   explosionRadius = 8;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 60.0;
   
   terminalVelocity = 100.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData LiLRocket
{ 
   bulletShapeName = "fusionex.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 50.0;
   
   terminalVelocity = 100.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData LiLRocketSubmission
{ 
   bulletShapeName = "fusionex.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 40.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData LiLRocketalt
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "rsmoke.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
//--LiLEMPRocket 3 projectiles-
//--------------------------------------
//--------------------------------------
//--------------------------------------

SeekingMissileData LiLEMPRocketONE
{ 
   bulletShapeName = "fusionex.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 200.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

SeekingMissileData LiLEMPRocketTWO
{ 
   bulletShapeName = "fusionex.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 200.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "fusionbolt.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

RocketData LiLEMPRocketalt
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = LiLRocketEMPExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EMPDamageType;

   explosionRadius  = 3;
   kickBackStrength = 0;//250.0;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 2;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "fusionbolt.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData MiniFlakproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniFlakExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $LiLRocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 100.0;
   totalTime         = 3;
   liveTime          = 3;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   //smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniSAMExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $LiLRocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 30.0;
   terminalvelocity  = 100;
   acceleration      = 2;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.76;

   //soundId = SoundJetHeavy;
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

   muzzleVelocity    = 300.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}


//=============================
// BIGGER NUKE
//=============================
//============ New Nuke & Bomblet Codes ===================
//============ By: *SlipKnot* | Notes From HaVoCz =========
//=========================================================
GrenadeData NBase
{
explosionTag       = grenadeExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 100;
damageType         = $NukeDamageType;

explosionRadius    = 100;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};

GrenadeData NRing
{
explosionTag       = LargeShockwave;
explosionId        = LargeShockwave;

collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 100.0;
damageType         = $NukeDamageType;

explosionRadius    = 100;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 1.1;
liveTime           = 0.1;
projSpecialTime    = 1.9;

inheritedVelocityScale = 0.0;
};

MineData NRing1
{
mass = 1.3;
drag = 1.0;
density = 2.0;
elasticity = 0;
friction = 10.0;
className = "Handgrenade";
description = "Handgrenade";
shapeFile = "grenade";
shadowDetailMask = 4;
explosionId = LargeShockwave;
explosionRadius = 0.0;
damageValue = 0.0;
damageType = $NukeDamageType;
kickBackStrength = 0;
triggerRadius = 0.5;
maxDamage = 0;
};

function NRing1::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}


GrenadeData NBlast
{
explosionTag       = grenadeExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 100;
damageType         = $NukeDamageType;

explosionRadius    = 100;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};

GrenadeData NCloud
{
explosionTag       = mortarExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 100;
damageType         = $NukeDamageType;

explosionRadius    = 100;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "shotgunex.dts";

   damageConversion  = 0.7;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.05;

   //lightRange        = 2.0;
   //lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------
LaserData TaserRfLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 3;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.08;

   //lightRange        = 2;
   //lightColor        = { 0.4, 0, 0.6 };

   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
};

//--------------------------------------
LaserData TaserTrtBLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 2;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData TaserTrtCLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.0001;
        baseDamageType = $LaserDamageType;
        beamTime = 0.3;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------

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
   bitmapName       = "laserpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500.0;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
LightningData BeamOfPainProj
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $BeamOfPainDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
//minismoke is beam of pain turret

LightningData MiniSmokeTurretproj
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 0.5;
   energyDrainPerSec = 0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
LightningData MiniELFTurretproj
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;//0.8;
   energyDrainPerSec = 1000;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};
//--------------------------------------
LightningData jailbolt
	{
  	bitmapName       = "paint3.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 0.05;
   segmentDivisions = 5;
   numSegments      = 6;
   beamWidth        = 0.075;          //075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
	};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
	{
	%aclient = Player::getClient(%target);
	if(getObjectType(%target) != "Player")
      {
      return;
      }
	if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
      {
      return;
      }
      %teleset = nameToID("MissionCleanup/jailports");
      %playerTeam = GameBase::getTeam(%target);
      for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
      {
      %oteam=GameBase::getTeam(%o);
      if(%oteam != %playerTeam)
      {
	%sclient = Player::getClient(%shooterId);
      %sname = Client::getName(%sclient);
      %client = Player::getClient(%target);
      %vname = Client::getName(%client);
      GameBase::SetPosition(%target,GameBase::GetPosition(%o));
      Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
      Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
      echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
      schedule("jLargeForceField::jailSesame("@%target@");",20);
      }
      }
	}

//--------------------------------------
LightningData cloakingCharge
{
   bitmapName       = "en08.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 0.05;
   segmentDivisions = 5;
   numSegments      = 6;
   beamWidth        = 0.075;          //075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function cloakingCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
        GameBase::startFadeOut(%target);
        schedule("GameBase::startFadeIn(" @ %target @ ");", 30000);
}
//--=-===--- *SlipKnot*'s New tractor(No bugs!)
LightningData TractorBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 3;
   beamWidth        = 1.0;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};

$TractorPower = 50;

function TractorBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %obj1 = %target;
  %obj2 = %shooterId;

   // Get object's mass  
  if (getObjectType(%obj1) == "Player") 
    %obj1mass = Player::getArmor(%obj1).mass;
  else
    %obj1mass = 10000;

  %obj2mass = Player::getArmor(%obj2).mass;

   // 
  %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));

  if (getObjectType(%obj1) == "Player")
  {
    %mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
    %nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
    //Player::applyImpulse(%obj1, %nvec);
    Item::setVelocity(%obj1, %nvec);
  }

   // obj2 is always a player
  %mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
  %nvec = (getWord(%vec, 0) * %mul) @ " " @
          (getWord(%vec, 1) * %mul) @ " " @
          (getWord(%vec, 2) * %mul);
  //Player::applyImpulse(%obj2, %nvec);
  Item::setVelocity(%obj2, %nvec);
}
//--------------------------------------
LightningData turretCharge
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0;
   energyDrainPerSec = 500;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};


function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
      %friendFire = $Server::TeamDamageScale;
      %targetId = GameBase::getControlClient(%target);
      %team = Client::getTeam(%targetId);
	%playerId = %shooterId;
	//if (%playerId.GravBolt == "0")
	//{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -80;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		if(Client::getTeam(%shooterId) == %team)
            {
		   %damVal = 0;
               %enVal  = 0; 
            }
            else
            {
               Player::applyImpulse(%target, %shooterDir);
               %enVal  = %timeSlice * %enDrainPerSec;
               %damVal = %timeSlice * %damPerSec;
            }
		GameBase::applyDamage(%target, $BeamOfPainDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);

}

//////////////////////////////////////////////////
//function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
//{
//   %damVal = %timeSlice * %damPerSec;
//   %enVal  = %timeSlice * %enDrainPerSec;
//	 //%targetId = GameBase::getControlClient(%target);
//	 //%targetName = Client::getName(%targetId);
//   GameBase::applyDamage(%target, $BeamOfPainDamageType, %damVal, %pos, %vec, %mom, %shooterId);
//         //Client::sendMessage(%targetid,0,"DOH,you have dropped somethings!");
//   %energy = GameBase::getEnergy(%target);
//   %energy = %energy - %enVal;
//   if (%energy < 0) {
//      %energy = 0;
//   }
//   GameBase::setEnergy(%target, %energy);
//}
/////////////////////////////////////////////////

function MiniELFturretproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
	 //%targetId = GameBase::getControlClient(%target);
	 //%targetName = Client::getName(%targetId);
   GameBase::applyDamage(%target, $MiniELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);
         //Client::sendMessage(%targetid,0,"DOH,you have dropped somethings!");
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
	//%targetId = GameBase::getControlClient(%target);
	//%targetName = Client::getName(%targetId);
   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
        //Client::sendMessage(%targetid,3,"DOH!");
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

RepairEffectData RepairBolt
{
   bitmapName       = "trailadd2.bmp";
   boltLength       = 50.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 2;
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
		%player.repairRate   = 2;
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
			Client::sendMessage(%client,0,%name @ " is not damaged");
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

function RepairBolt::onRelease(%this, %player)
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

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
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
