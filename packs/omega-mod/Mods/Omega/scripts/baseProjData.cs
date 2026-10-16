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
$VDamageType        = 14;
$PlasLaserDamageType = 15;
$CSDamageType = 16;
$SRDamageType = 17;
$RGDamageType = 18;
$IonDamageType = 19;
$FlakDamageType = 20;
$AnniCDamageType = 21;
$MethaneDamageType = 22;
$MRDamageType = 23;
$IceDamageType = 24;
$EarthDamageType = 25;
$StarDamageType = 26;
$FoehnDamageType = 27;
$DivineDamageType = 28;
$RazorDamageType = 29;
$GammaDamageType = 30;
$StrikeDamageType = 31;
$OhmDamageType = 32;
$FissionDamageType = 33;
$SpikeDamageType = 34;

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.20;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
BulletData ACShell
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = debrisExpSmall;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.20;
   damageType         = $AnniCDamageType;

   explosionRadius  = 3;
   aimDeflection      = 0.005;
   muzzleVelocity     = 800.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = BulletExp2;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $VDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
//--------------------------------------
BulletData FalconBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = BulletExp2;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;   //muahahahah
   damageType         = $VDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//--------------------------------------
BulletData RailgunBolt
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = debrisExpSmall;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $RGDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 1000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = false;


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
//--
//--------------------------------------
BulletData TinyTurretBolt
{
   bulletShapeName    = "shield.dts";
   explosionTag       = turretexp;

   damageClass        = 0;
   damageValue        = 0.6;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 800.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0, 0, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};
//------
//---To make the blaster actually "cyclone"
RocketData BlasterBolt1
{
   bulletShapeName = "shotgunex.dts";
   explosionTag   = blasterExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $BlasterDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0;

   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 250.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 1.0, 0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData BlasterBolt2
{
   bulletShapeName = "mortartrail.dts";
   explosionTag   = BlasterSmokeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $BlasterDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = -100;

   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 250.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

$BulletToWeapon[BlasterBolt1] = Blaster;
$BulletToWeapon[BlasterBolt2] = Blaster;

//-----Case this off in its own little jail :} 
//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discammo.dts";
   explosionTag   = DiscExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 150.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;


     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mflame.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData DevBlast
{
   bulletShapeName = "enbolt.dts";
   explosionTag   = DevExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 0;

   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 250.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "laserhit.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

//----Plasma Rockets for the dominion.....trying to fix other bullshit that makes it aim fucky
RocketData PlasmaRocket
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag   = dustplasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 150.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "laserhit.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData PlasmaRocket2
{
   bulletShapeName = "shotgunex.dts";
   explosionTag   = bioPlasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 150.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};

$BulletToWeapon[PlasmaRocket] = PlasmaGun;
$BulletToWeapon[PlasmaRocket2] = PlasmaGun;

//-----Case this off in its own little jail :} 
RocketData MethaneBolt
{
   bulletShapeName = "shotgunex.dts";
   explosionTag   = methaneExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MethaneDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 0;

   muzzleVelocity   = 60.0;
   terminalVelocity = 60.0;
   acceleration     = 30.0;

   totalTime        = 1.0;
   liveTime         = 1.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

     // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 6.0;

   soundId = SoundDiscSpin;
};
//----
GrenadeData HealingMortar 
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = HealthExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100.5;
   damageType         = $MortarDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 600;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "dustplume.dts";
};
//----
//----
GrenadeData HealingTurretsHell
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = HealthExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -1.5;
   damageType         = $MortarDamageType;

   explosionRadius    = 6;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0; //so it wont be projected at the enemy
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";
};
//----
//----
GrenadeData BomberShell
{
   bulletShapeName    = "magcargo.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $StrikeDamageType;

   explosionRadius    = 40;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 6;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmaex.dts";
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
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 600;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "shield_large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 700.0;
   maxLevelFlightDist = 750;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
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
   maxLevelFlightDist = 4000;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};
//---Napalmish Stuff
GrenadeData PrettySplit
{
   bulletShapeName    = "liqcyl.dts";//grenade.dts
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};


GrenadeData GooeyNapalm
{
   bulletShapeName    = "liqcyl.dts";
   explosionTag       = HawkExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 600;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0; // grenade time live after contact
   projSpecialTime    = 0.05;

soundId = SoundDiscSpin;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};


GrenadeData SmearShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = SmearyNapalmExp;
   expRandCycle       = 3;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 30;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 15;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundBeaconActive;
   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//----C4 Stuff

GrenadeData PlastickBomb
{
   bulletShapeName    = "grenammo.dts";
   explosionTag       = C4Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 20.0;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 35;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 15;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 30.0; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundShieldOn;
   inheritedVelocityScale = 0.5;

   smokeName              = "breath.dts";
};

GrenadeData PlastickBombBlast
{
   bulletShapeName    = "breath.dts";
   explosionTag       = C4BlastExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 60;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

GrenadeData PlastickPrettySplit
{
   bulletShapeName    = "paint.dts";//grenade.dts
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";
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
   muzzleVelocity   = 650.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//Hyper Laser
//--------------------------------------
RocketData HyperLaser
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = HLaserExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $IonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 1.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;
   trailLength = 15000;
   trailWidth  = 0.3;

   soundId = SoundJetHeavy;
};
//--------------------------------------
RocketData IonBlast
{
   bulletShapeName  = "paint.dts";
   explosionTag     = IonExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $IonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "hflame.dts";
   smokeDist   = 3.0;
};

//--------------------------------------
RocketData FlakShell
{
   bulletShapeName  = "grenade.dts";
   explosionTag     = FlakExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $FLakDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "chainspk.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData FlakShell2
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = FlakExp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $FlakDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   rotationPeriod = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//--------------------------------------
RocketData MR
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = MRExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MRDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData MR2
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = MRExp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MRDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   rotationPeriod = 0.1;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 40.0; //slow and XTREAMLY deadly
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 0.0000000000000000000000000000000000000000000000001;
   nonSeekingTurningRadius = 0.0000000000000000000000000000000000000000000000001;
   proximityDist     = 0;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

 // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}
//--------
//--------------------------------------
SeekingMissileData HunterMissile
{
   bulletShapeName = "chainspk.dts";
   explosionTag    = hunterexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = -175.0;

   muzzleVelocity    = 10.0; //slow and XTREAMLY deadly
   totalTime         = 1000;
   liveTime          = 1000;
   seekingTurningRadius    = 0.0000000000000000000000000000000000000000000000001;
   nonSeekingTurningRadius = 0.0000000000000000000000000000000000000000000000001;
   proximityDist     = 0;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}
//--------
//############################################

//--------------------------------------
RocketData ObeliskMissile
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = MRExp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 300.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//--------------------------------------
RocketData HawkTorpedo
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = HawkExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};
//--------------------------------------
RocketData HawkTorpedo2
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = HawkExp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "hflame.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "shex11.bmp";
   hitName           = "fusionbolt.dts";

   damageConversion  = 1.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = explosion3;
};

//-----Falcon LAser Pointer-----//
LaserData FalconLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   beamTime          = 10.0;

   lightRange        = 2.0;
   lightColor        = { 0, 1.0, 0 };

   detachFromShooter = false;
};


LaserData DemLaser
{
   laserBitmapName   = "plasmabolt.bmp";//wow lmao
   hitName           = "plasmabolt.dts";

   damageConversion  = 0.1;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 1, 0.2, 0 };

   detachFromShooter = true;
   hitSoundId        = SoundFlagFlap;
};

LaserData Mlasr
{
   laserBitmapName   = "las03.bmp";//las03.bmp
   hitName           = "plasmabolt.dts";

   damageConversion  = 50.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 10;

   lightRange        = 2.0;
   lightColor        = { 1, 0, 0 };

   detachFromShooter = true;
   hitSoundId        = energyExplosion;
};

//----
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
   bitmapName       = "warp.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 70.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.2;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;

   TractorPower = 30;
};

LightningData turretCharge
{
   bitmapName       = "flare.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
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

RepairEffectData RepairBolt
{
   bitmapName       = "shkwv2.bmp";
   boltLength       = 750.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 45;
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
			%player.repairRate = 0.5;
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
		%player.repairRate   = 0.5;
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
