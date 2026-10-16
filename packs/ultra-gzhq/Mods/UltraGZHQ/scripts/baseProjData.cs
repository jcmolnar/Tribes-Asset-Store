# Damage Types
#
$ImpactDamageType = -1;
$LandingDamageType = 0;
$BulletDamageType = 1;
$EnergyDamageType = 2;
$PlasmaDamageType = 3;
$ExplosionDamageType = 4;
$ShrapnelDamageType = 5;
$LaserDamageType = 6;	//anything using laser will report back as this type, regardless what its called.. 
$MortarDamageType = 7;
$BlasterDamageType = 8;
$ElectricityDamageType = 9;
$CrushDamageType = 10;
$DebrisDamageType = 11;
$MissileDamageType = 12;
$MineDamageType = 13;
$SniperDamageType = 14;
$ShockDamageType = 15;
$ShotgunDamageType = 16;
$AssassinDamageType = 17;
$DisarmDamageType = 18;
$StasisDamageType = 19;
//$TurretLaserDamageType = 20;	
$TurretVortexDamageType = 21;
$PoisonDamageType = 22;
$JailDamageType = 23;
$Kickback = 24;				
$SoulDamageType = 25;			
$OSMissileDamageType = 26;		
$RocketDamageType = 27;		
$BurnDamageType = 28;		
$DartDamageType = 29;		
$AcidDamageType = 30;		
$BeamOfPainDamageType = 31;
$IX2002DamageType = 32;
$IX2000DamageType = 33;
$SniperMkiDamageType = 34;

//------------
RocketData SalvoRocket 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = SalvoRocketExp; 
   collisionRadius = 0; 
   mass = 2; 
   damageClass = 1; 
   damageValue = 5; 
   damageType = $RocketDamageType; 
   explosionRadius = 15; 
   kickBackStrength = 250; 
   muzzleVelocity = 150; 
   terminalVelocity = 225; 
   acceleration = 25; 
   totalTime = 8; 
   liveTime = 1; 
   lightRange = 1; 
   lightColor = { 1, 1, 1 }; 
   inheritedVelocityScale = 0.25; 
   trailType = 2; 
   trailString = "rsmoke.dts"; 
   smokeDist = 1; 
   soundId = SoundJetHeavy; 
};

BulletData VermBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = VermExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.25;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 40;
};


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
//New ZX Data Coded By: Armagedon
//--------------------------------------
BulletData IX2002Bullet
 {
   bulletShapeName    = "plastrail.dts";
   validateShape      = true;
   explosionTag       = bulletExp2;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $IX2002DamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
//--------------------------------------
//New ZX Data Coded By: Armagedon
//--------------------------------------
BulletData IX2000Bullet
 {
   bulletShapeName    = "smoke.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $IX2000DamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
//--------------------------------------
//New ZX Data Coded By: Armagedon
//--------------------------------------
BulletData SniperBulletMkii
 {
   bulletShapeName    = "rsmoke.dts";
   validateShape      = true;
   explosionTag       = MkiiExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $SniperMkiiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
//--------------------------------------
//Stuff
//-------------------------------------- 
BulletData SniperBulletMki
 {
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $SniperMkiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

BulletData FEBBullet
 {
   bulletShapeName    = "breath.dts";
   validateShape      = true;
   explosionTag       = FEBbulletExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $DartDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
//--------------------------------------
BulletData ChaingunBullet
{
	bulletShapeName = "bullet.dts";
	validateShape = true;
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
	aimDeflection = 0.002;
	muzzleVelocity = 500.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 2.0;
	tracerLength = 30;
};
BulletData VulcanBullet 
{
	bulletShapeName = "bullet.dts";
	validateShape = true;
	explosionTag = VulcanExp;	//Vulcan2Exp;	//Vulcan3Exp;
	collisionRadius = 0.0;
	expRandCycle = 3;
	mass = 0.10;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $BulletDamageType;
	explosionRadius = 2.0;
	//kickBackStrength = 100.0;
	aimDeflection = 0.0001;
	muzzleVelocity = 275.0;
	totalTime = 1.0;
	//liveTime = 18.0;
	inheritedVelocityScale = 1.0;
	isVisible = true;
	tracerPercentage = 3.0;
	tracerLength = 20;
};

BulletData FusionBolt
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	mass = 0.05;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $EnergyDamageType;
	muzzleVelocity = 50.0;
	totalTime = 6.0;
	liveTime = 4.0;
	isVisible = True;
	rotationPeriod = 1.5;
};

BulletData MiniFusionBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $PoisonDamageType;
	muzzleVelocity = 80.0;
	totalTime = 4.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

//--------------------------------------
// New Bolt By: Armagedon
//--------------------------------------
BulletData BlasterBolt
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

BulletData TurretPlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
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

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
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


BulletData OldPlasmaBolt
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	damageClass = 1;
	damageValue = 0.45;
	damageType = $PlasmaDamageType;
	explosionRadius = 4.0;
	muzzleVelocity = 55.0;
	totalTime = 3.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

BulletData GatlingBlasterBolt
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag = blasterExp;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $BlasterDamageType;
	muzzleVelocity = 700.0;
	explosionRadius = 2.5;
	totalTime = 10.0;
	liveTime = 8.255;
	aimDeflection = 0.0075;
	lightRange = 3.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

BulletData ShotgunBullet 
{
	bulletShapeName = "tracer.dts";
	explosionTag = ShotExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.07;
	damageType = $ShotgunDamageType;
	kickBackStrength = 200.0;
	aimDeflection = 0.02;
	muzzleVelocity = 400.0;
	acceleration = 5.0;
	totalTime = 0.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};


BulletData Flames
{
	bulletShapeName = "tumult_large.dts";
	explosionTag = flameExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.01;
	muzzleVelocity = 96.0;
	totalTime = 1;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};

BulletData HeavensfuryBolt 
{	bulletShapeName = "enex.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.03;
	damageType = $ElectricityDamageType;
	aimDeflection = 0.015;
	muzzleVelocity = 100.0;
	totalTime = 1.3;
	liveTime = 1.3;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

BulletData HeavensfuryBolt2 
{	bulletShapeName = "plasmaex.dts";
	explosionTag = HeavensfuryExp;
	damageClass = 0;
	damageValue = 0.04;
	damageType = $ElectricityDamageType;
	aimDeflection = 0.015;
	muzzleVelocity = 100.0;
	totalTime = 1.3;
	liveTime = 1.3;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

BulletData MiniMissile
{	bulletShapeName = "rocket.dts";
	explosionTag = BlastExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.255;
	damageType = $MissileDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.005;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData PulseBolt
{	bulletShapeName = "enex.dts";
	explosionTag = turretExp;
	mass = 0.05;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $EnergyDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 375.0;
	totalTime = 10.0;
	liveTime = 9.9;
	isVisible = True;
	rotationPeriod = 15;
};

BulletData ShredderBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = ShredderBulletExp;
	expRandCycle = 0;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.55;
	damageType = $BulletDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData BlastCannonShot
{	bulletShapeName = "rocket.dts";
	explosionTag = BlastExp0;
	expRandCycle = 0;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.255;
	damageType = $MissileDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.025;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData StasisBolt
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = energyExp;
	damageClass = 1; //Radius
	damageValue = 0.01;
	damageType = $StasisDamageType;
	explosionRadius = 3;
	muzzleVelocity = 100.0;
	totalTime = 1;
	liveTime = 1;
	lightRange = 3.0;
	lightColor = { 0.25, 1, 0.25 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

BulletData DisruptorBolt
{	bulletShapeName = "paint.dts";
	explosionTag = disexp;
	damageClass = 1;
	damageValue = 0.35;
	damageType = $DisruptorDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 150.0;
	totalTime = 10.0;
	liveTime = 7;
	lightRange = 3.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

BulletData IrradiationBlast
{	bulletShapeName = "dustplume.dts";
	explosionTag = debrisExpSmall;
	mass = 0.07;
	damageClass = 1; // 0 impact, 1, radius
	explosionRadius = 5.0;
	damageValue = 0.1;
	baseDamageType = $BulletDamageType;
	aimDeflection = 0.0004;
	muzzleVelocity = 180.0;
	totalTime = 2;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};

//--------------------------------------
RocketData BasicRocket
{	
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.5;
	damageType = $ExplosionDamageType;
	explosionRadius = 20;
	kickBackStrength = 250.0;
	muzzleVelocity = 500.0;		//75
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.5;
	liveTime = 18.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};


RocketData HeavenRevengeRocket
{	
	bulletShapeName = "enex.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.3;
	damageType = $ExplosionDamageType;
	explosionRadius = 10.5;
	kickBackStrength = -250.0;
	muzzleVelocity = 125.0;		//75
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.5;
	liveTime = 18.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "hflame.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

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
   trailLength = 5;
   trailWidth  = 1;

   soundId = SoundDiscSpin;
};

RocketData HyperDiscShell
{	
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 400.0;
   terminalVelocity = 650.0;
   acceleration     = 6.0;

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

RocketData ParticleBeamShell
{
	bulletShapeName = "bullet.dts";
	explosionTag = ParticleBeamShellExp;	//bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 1.0;
	damageType = $SniperDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

//---------new
RocketData Shock 
{
bulletShapeName = "shield_medium.dts";
explosionTag = LargeShockwave;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.20;
damageType = $ShockDamageType;
explosionRadius = 20.0;
kickBackStrength = 350.0;
muzzleVelocity = 150.0;
terminalVelocity = 180.0;
acceleration = 5.0;
totalTime = 6.0;
liveTime = 4.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "shield.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

RocketData RailRound
{	
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.80;	//0.75
	damageType = $SniperDamageType;		//adjusted this some when I fixed head shot damage 
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.4;
	soundId = SoundJetHeavy;
};

RocketData PhaseDisrupterBolt
{	
	bulletShapeName = "enex.dts";
	explosionTag = PhaseDisrupterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 1.25;
	DamageType = $MissileDamageType;
	explosionRadius = 25.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 80.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 10.0;
	lightColor = { 1.0, 6.7, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData PhaseDisrupterBoltNull
{	
	bulletShapeName = "shield.dts";
	explosionTag = PhaseDisrupterNullExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0;
	DamageType = $MissileDamageType;
	explosionRadius = 25.0;
	kickBackStrength = -450.0;
	muzzleVelocity = 80.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 10.0;
	lightColor = { 1.0, 6.7, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "shield.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData IonBolt 
{	
	bulletShapeName = "enbolt.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $ElectricityDamageType;
	explosionRadius = 4;
	kickBackStrength = 0.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailLength = 50;
	trailWidth = 0.3;
	soundId = SoundJetHeavy;
};

RocketData VortexBolt 
{	
	bulletShapeName = "mortartrail.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $TurretVortexDamageType;
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

RocketData RPG
{	
	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

RocketData DisarmBolt
{	
	bulletShapeName = "shield.dts";
	explosionTag = ShockwaveArm;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $DisarmDamageType;
	explosionRadius = 20;
	kickBackStrength = 100.0;
	muzzleVelocity = 70.0;
	terminalVelocity = 80.0;
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

RocketData FlierRocket
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 250.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData FlameStrikeBig
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 30.0;
	DamageType = $PlasmaDamageType;
	explosionRadius = 45.0;
	kickBackStrength = 500.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 2.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 9.0;
	lightColor = { 0.4, 0.4, 5.0 };
	inheritedVelocityScale = 0.5;
	TrailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 1.0;
};

RocketData FlameStrikeSmall
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = PlasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.6;
	DamageType = $PlasmaDamageType;
	explosionRadius = 3.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 9.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 9.0;
	lightColor = { 0.4, 0.4, 5.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "laserhit.dts";
	smokeDist = 0.6;
};

RocketData ScoutMissile 
{	
	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $ShrapnelDamageType;
	explosionRadius = 20.5;
	kickBackStrength = 450.0;
	muzzleVelocity = 80.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData BorgBolt
{	
	bulletShapeName = "plasmatrail.dts";
	explosionTag = BlasterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $BlasterDamageType;
	explosionRadius = 2.5;
	kickBackStrength = 0.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	liveTime = 1.0;
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 1.0;
	//rotationPeriod = 1;
};

RocketData PlasmaCharge
{	
	bulletShapeName = "Mortar.dts";
	explosionTag = FireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.30;
	damageType = $PlasmaDamageType;
	explosionRadius = 3.5;
	kickBackStrength = 0.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	liveTime = 1.0;
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 3.0;
};

RocketData FusionCharge
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	damageType = 1;
	damageValue = 0.45;
	explosionRadius = 5.0;
	DamageType = $EnergyDamageType;
	liveTime = 4.5;
	totalTime = 4.5;
	lightRange = 1.0;
	lightColor = { 1.0, 0, 0.75 };
	muzzleVelocity = 90.0;
	terminalVelocity = 90.0;
	inheritedVelocityScale = 1.0;
	detachFromShooter = false;
	trailType = 2;
	trailString = "shield.dts";
	smokeDist = 10;
};

RocketData NukeShell
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 60;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 500.0;
	muzzleVelocity = 90.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData FlameShell
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = fireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 3.0;
	kickBackStrength = 10.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 3.0;
	liveTime = 4.0;
	lightRange = 10.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "plasmabolt.dts";
	smokeDist = 1.0;
	soundId = SoundJetHeavy;
};

RocketData StingerRocket
{	
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 125.0;
	terminalVelocity = 150.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};


SeekingMissileData AvengerMissile 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.65;
damageType = $MissileDamageType;
explosionRadius = 8.5;
kickBackStrength = 175.0;
muzzleVelocity = 175.0;
terminalVelocity = 180.0;
acceleration = 5.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = {1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = {0.4, 0.4, 1.0 };
trailType = 2;
trailString = "smoke.dts";
smokeDist = 1.5;
inheritedVelocityScale = 1.0;
soundId = SoundJetHeavy;
};

RocketData HellfireRocket
{	
	bulletShapeName = "Rocket.dts";
	explosionTag = rocketexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.7;
	damageType = $MissileDamageType;
	explosionRadius = 10;
	kickBackStrength = 30.0;
	aimDeflection = 0.006;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	totalTime = 6.0;
	liveTime = 6.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "HFlame.dts";
	smokeDist = 1.8;
};

RocketData TankRocket
{	
	bulletShapeName = "rocket.dts";
	explosionTag = TankRocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};

RocketData BeaconRocket
{	
	bulletShapeName = "sensor_small.dts";
	explosionTag = Shockwave;
	//collideWithOwner = true;
	//ownerGraceMS = 750;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 1;
	damageValue = 0.10;
	damageType = $ShrapnelDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 75.0;
	muzzleVelocity = 25.0;
	terminalVelocity = 25.0;
	acceleration = 1.0;
	totalTime = 22.0;
	liveTime = 23.0;
	lightRange = 5.0;
	lightColor = { 0.2, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.5;
	soundId = SoundJetHeavy;
};

//--------------------------------------

GrenadeData PlasmaBurn
{
// admin
   bulletShapeName = "plasmabolt.dts";
   explosionTag       = BurnExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};

GrenadeData ZXBurn
{

   bulletShapeName = "plasmabolt.dts";
   explosionTag       = BurnExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 0.2; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};

GrenadeData RatPoison
{
// admin
   bulletShapeName = "plasmabolt.dts";
   explosionTag       = RatPoisonExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};

GrenadeData suicideShell
{
// admin
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};


GrenadeData DropShell
{
// admin
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};

//to fix os launcher 
GrenadeData RocketKilla
{
   bulletShapeName    = "rocket.dts";		//mortar.dts";
   explosionTag       = WickedBadExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       		// 0 impact, 1, radius
   damageValue        = 0.75;			//1.5;//3.0;//5.0
   damageType         = $OSMissileDamageType;	//$ImpactDamageType,$PlasmaDamageType

   explosionRadius    = 25.0;//25
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; 			// grenade time live after contact
   projSpecialTime    = 0.01;  			//smoke interval

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";//mortartrail
};

GrenadeData BombShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 50.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 50;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";
};

GrenadeData GrenadeShell
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.45;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150;
	totalTime = 30.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData GrenadeShell2
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.45;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 140;
	totalTime = 30.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData GrenadeShell3
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.45;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 130;
	totalTime = 30.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData GrenadeShell4
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.45;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 120;
	totalTime = 30.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData FFBShell 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = FFBExp;
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
        liveTime = 1;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "smoke.dts";
        soundId = SoundELFFire;
};

GrenadeData MortarShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 275;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

GrenadeData MortarShellEMP
{
	bulletShapeName = "mortar.dts";
	explosionTag = PhaseDisrupterExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.2;
	damageType = $shockDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 275;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "fusionbolt.dts";
};

GrenadeData OSBomblet
{
	bulletShapeName = "plastrail.dts";
	explosionTag = DebrisExpMedium;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.4;
	damageType = $MortarDamageType;
	explosionRadius = 10.0;
	kickBackStrength = 50.0;
	maxLevelFlightDist = 1;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "plastrail.dts";
};


GrenadeData TankMortarShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = TankMortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.6;
	damageType = $MortarDamageType;
	explosionRadius = 12.0;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 75;
	totalTime = 10.0;
	liveTime = 1.5;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "Shotgunex.dts";
};

GrenadeData MortarTurretShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.32;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 400;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

GrenadeData FlameSmoke
{	bulletShapeName = "rsmoke.dts";
	explosionTag = SmokeFade;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.002;
	mass = -1;
	elasticity = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0;
	damageType = $NullDamageType;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 0;
	totalTime = 1.0; // special meaning for grenades...
	liveTime = 0.75;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "rsmoke.dts";
};

GrenadeData AngelFireGren
{	bulletShapeName = "fusionex.dts";
	explosionTag = rocketExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.20;
	damageType = $PlasmaDamageType;
	explosionRadius = 5;
	kickBackStrength = 0;
	maxLevelFlightDist = 200;
	totalTime = 5;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmatrail.dts";
	smokeDist = 1.5;
};

GrenadeData FlameThrowerGren
{	bulletShapeName = "PlasmaBolt.dts";
	explosionTag = PlasmaExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.2;
	damageType = $PlasmaDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 5.0;
	liveTime = 0.001;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "Plasmatrail.dts";
	smokeDist = 1.5;
};

GrenadeData AcidSpray
{	bulletShapeName = "dustplume.dts";
	explosionTag = AcidExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.2;
	damageType = $AcidDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 650;
	totalTime = 5.0;
	liveTime = 0.001;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "dustplume.dts";
	smokeDist = 1.5;
};

RocketData FlamerBoltA 
{
bulletShapeName = "plasmabolt.dts";
explosionTag = Fire2Exp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.2;
damageType = $PlasmaDamageType;
explosionRadius = 4.5;
kickBackStrength = 0;
muzzleVelocity = 75.0;
terminalVelocity = 80.0;
acceleration = 5.0;
totalTime = 0.6;
liveTime = 0.6;
lightRange = 5.0;
lightColor = { 1.0, 0.95, 1.0 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "plastrail.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

GrenadeData BabyNukeBomb
{	bulletShapeName = "Shockwave_Large.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 50.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmabolt.dts";
};

GrenadeData RubberMortarShell
{	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.70;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 275;
	totalTime = 25.0;
	liveTime = 5.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

GrenadeData MineShell //Mine Launcher
{	bulletShapeName = "mortar.dts";
	explosionTag = debrisExpSmall;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $MineDamageType;
	explosionRadius = 10;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 150;	//150
	totalTime = 20.0; // 40.0
	liveTime = 3.0;	//1.0
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};
GrenadeData MinerShell
{
//
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ShrapnelDamageType; //$MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 20.0;
   liveTime           = 20.0; // grenade time live after contact
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData MineFloaters
{
//
   bulletShapeName    = "mine.dts";//mortar
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	//5.0
   elasticity         = 0.45;	//0.1

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; //$MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; // grenade time live after contact
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";//breath.dts";//mortartrail,plastrail
};

GrenadeData PrettySplit
{
//
   bulletShapeName    = "shotgunbolt.dts";//grenade.dts
   explosionTag       = AgedonSplitExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;//$PlasmaDamageType;//

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";//smoke.dts
};


GrenadeData SpellFlameThrowerGren
{	bulletShapeName = "PlasmaBolt.dts";
	explosionTag = plasmaExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 5.0;
	liveTime = 0.001;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "Plasmatrail.dts";
	smokeDist = 1.5;
};

GrenadeData SuicideGren
{	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1;
	damageValue = 1.9;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0;
	maxLevelFlightDist = 1;
	totalTime = 0.1;
	liveTime = 0.1;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.1;
	smokeName = "mortartrail.dts";
};

GrenadeData ShockShell 
{	bulletShapeName = "mortar.dts";
	explosionTag = Shockwave;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 995.0;
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.10;
	damageType = $ShockDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 30.0;
	liveTime = 0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.01;
	smokeName = "mortartrail.dts";
};

GrenadeData TankShockShell 
{	bulletShapeName = "mortar.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.10;
	damageType = $ShockDamageType;
	explosionRadius = 60.0;		//30
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 0.1;
	liveTime = 0.1;
	projSpecialTime = 0.1;
	inheritedVelocityScale = 1.0;	//0.01
//	smokeName = "mortartrail.dts";
};


//=====================//

ExplosionData smExp
{
   shapeName = "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData JetSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = smExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};


GrenadeData AcidJetSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = acidsmExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

//========================//
ExplosionData smExpLight
{
   shapeName = "smoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData BoosterDebris
{	bulletShapeName = "bullet.dts";	//chainspk.dts"; bullet.dts";Shockwave_Large.dts"; bullet
	explosionTag = mineExp;	//burnExp;		//SmokeFade;	//ShotExp; LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 25;
	collisionRadius = 0.3;
	mass = 0.01;
	elasticity = 0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.015;
	damageType = $ShrapnelDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 300;
	totalTime = 1.0;
	liveTime = 0.01;
	projSpecialTime = 1;	//0.01;
	inheritedVelocityScale = 1.0;	//0.5
	smokeName = "chainspk.dts";	//paint.dts";
};

GrenadeData JetSmokeLight
{
   bulletShapeName    = "breath.dts";
   explosionTag       = smExpLight;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//========================//
ExplosionData smokeBoosterEx
{
   shapeName = "plasmaex.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 2;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData smokeBooster
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = smokeBoosterEx;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $NullDamageType;

   explosionRadius    = 5;
   kickBackStrength   = 15.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmaex.dts";
};
//===============================================



ExplosionData AnnihilationFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData AnnihilationFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = AnnihilationFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//=========================================

//===============================================


GrenadeData AcidBathBolt
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = AcidExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";
};
//=========================================


//=====================//

ExplosionData ShockedDamageExp
{
   shapeName = "fusionex.dts";	//enex.dts";
   //soundId = shockExplosion;	//soundId = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.00;
   timeOne  = 0.100;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData ShockedDamage
{
   bulletShapeName    = "breath.dts";
   explosionTag       = ShockedDamageExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};


ExplosionData ShockJetExp
{
   //shapeName = "plasmatrail.dts";
   shapeName = "fusionex.dts";	//enex.dts";
   soundId = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;
   timeScale = 10;
   timeZero = 0.100;	//0.450;
   timeOne  = 0.150;	//0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData ShockJet
{
   bulletShapeName    = "force.dts";
   explosionTag       = debrisExpSmall;
   //explosionTag       = ShockJetExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//===========================================
ExplosionData nullExp
{
   shapeName = "breath.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData srFlyFlame
{
   bulletShapeName    = "tumult_medium.dts";
   explosionTag       = nullExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $nullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "tumult_medium.dts";
};






MineData Firegrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "force";	//discb";
   shadowDetailMask = 4;
   explosionId = BurnExp;//FlakExp
	explosionRadius = 1.0;
	damageValue = 0.01;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

GrenadeData GrenadeLauncherGren
{	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 350;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.35;
	damageClass = 1;
	damageValue = 0.40;	//0.25
	damageType = $ShrapnelDamageType;
	explosionRadius = 20;	//15
	kickBackStrength = 10.0;
	maxLevelFlightDist = 130;
	totalTime = 12.0;
	liveTime = 1.0;
	projSpecialTime = 0.2;
	inheritedVelocityScale = 0.25;
	smokeName = "plasmatrail.dts";
};


GrenadeData GrenadeLauncherGren1
{	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 400;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.25;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 150;
	totalTime = 15.0;
	liveTime = 1.0;
	projSpecialTime = 0.3;
	inheritedVelocityScale = 0.35;
	smokeName = "plasmatrail.dts";
};

GrenadeData GrenadeLauncherGren2
{	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 350;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.35;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 130;
	totalTime = 12.0;
	liveTime = 1.0;
	projSpecialTime = 0.2;
	inheritedVelocityScale = 0.25;
	smokeName = "plasmatrail.dts";
};

GrenadeData GrenadeLauncherGren3
{	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 300;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.45;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 110;
	totalTime = 9.0;
	liveTime = 1.0;
	projSpecialTime = 0.1;
	inheritedVelocityScale = 0.15;
	smokeName = "plasmatrail.dts";
};

//--------------------------------------
SeekingMissileData TurretMissile
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.65;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 72.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 7.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

SeekingMissileData HellfireMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2; // smoke trail
	trailString = "HFlame.dts";
	smokeDist = 1.8;
};

SeekingMissileData StingerMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

SeekingMissileData TankMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = TankRocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
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
LaserData SniperLaser
{
	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.007;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData AssassinLaser
{
	laserBitmapName = "shex00.bmp";
	hitName = "shotgunex.dts";
	damageConversion = 40;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.4;
	lightRange = 2.0;
	lightColor = { 50.0, 0.0, 0.0 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData oldSeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";

   damageConversion  = 0.22; //0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;//0.70;

   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   //hitSoundId        = SoundLaserHit;
};

LaserData SeekerLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 20.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

LaserData ParticleBeam
{	laserBitmapName = "warp.bmp";
	hitName = "shockwave_large.dts";
	damageConversion = 4;	//0.064;	
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};

LaserData ParticleBeamFire
{	laserBitmapName = "plasmabolt.bmp";
	hitName = "plasmatrail.dts";
	damageConversion = 4;	//0.064;	
	DamageType = $PlasmaDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.8;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};

LaserData ParticleBeamShock
{	laserBitmapName = "forcefield5.bmp";
	hitName = "enex.dts";
	damageConversion = 4;	//0.064;	
	DamageType = $shockDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.8;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};

//
LaserData PhrailterLaser
{
   laserBitmapName   = "laserpulse.bmp";		//"pulse.bmp";
   hitName           = "shockwave_large.dts";	//"laserhit.dts";

   damageConversion  = 0.00;		//0.007
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;	//0.7;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
	hitSoundId = SoundFlierCrash;
//   hitSoundId        = SoundParticleBeamExplosion;	//SoundLaserHit;
};

LaserData DeathRayLaser
{	laserBitmapName = "forcefield5.bmp";
	hitName = "enex.dts";
	damageConversion = 2;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 1.3;
	lightRange = 1.0;
	lightColor = { 0.0, 0.0, 5.0 };
	detachFromShooter = true;
	hitSoundId = SoundLaserHit;
};

LaserData TurretLaser 
{	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.0065;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

TargetLaserData targetLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 20.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

LightningData SoulBolt
 {
	bitmapName       = "zap05.bmp";	
   	boltLength       = 50.0;
   	coneAngle        = 35.0;
   	damagePerSec = 20;
   	energyDrainPerSec = 250;
   	segmentDivisions = 2;	//0;
   	numSegments = 2;		//1;
   	beamWidth = 5.0;	//0.25;
   	updateTime   = 4;
   	skipPercent  = 0.6;
   	displaceBias = 0.15;
   	isVisible = true;
};
LightningData lightningCharge
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.06;
	energyDrainPerSec = 60.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

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

LightningData ShockingGraspBolt
{	bitmapName = "plasmabolt.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 45.0;
	damagePerSec = 0.35;
	energyDrainPerSec = 100.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.3;  //10
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundElfFire;
};
LightningData turretCharge
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.06;
	energyDrainPerSec = 60.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};


LightningData JailBolt
{	bitmapName = "lightningNew.bmp";
	damageType = $JailDamageType;
	boltLength = 10.0;
	coneAngle = 1.0;
	damagePerSec = 0.01;
	energyDrainPerSec = 60.0;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};



//
function jailbolt::damageTarget(%targetPl, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterPl)
{

	%shooterTeam = GameBase::getTeam(%shooterPl);
	%targetTeam = GameBase::getTeam(%targetPl);
	
	%shooterClient = Player::getClient(%shooterPl);
	%targetClient = Player::getClient(%targetPl);
	if(%targetPL.invulnerable == true || $jailed[%targetPL] == true) {
		//Client::sendMessage(%shooterClient,0,"Quit that.~wError_Message.wav");
		return;
		}		
	if(getObjectType(%targetPl) != "Player")
		return;
	if(%shooterTeam == %targetTeam)
		return;

	if($JailPosition[%shooterTeam] != "0 0 0")
	{
		%shooterName = Client::getName(%shooterClient);
		%targetname = Client::getName(%targetClient);
		ToJail(%targetClient, %shooterTeam);	
		
		bottomprint(%targetClient,"Your Punk Ass Has Been Placed Under Arrest By " @ Client::getName(%shooterClient) @ ", Your sentence will last for 30 seconds", 30);
		Messageall(0,Client::getName(%targetClient)@" Was judged GUILTY by "@Client::getName(%shooterClient));
//		echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");

		return true;
	}
	else
	{
		Client::sendMessage(%shooterClient,0,"No Jail Tower Deployed~wError_Message.wav");
		return false;
	}
}



function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	%enVal = %timeSlice * %enDrainPerSec;

	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if(%energy < 0) 
		%energy = 0;
	GameBase::setEnergy(%target, %energy);
}

RepairEffectData RepairBolt
{
	bitmapName = "repairadd.bmp";
   boltLength       = 50.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

//
function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.fixingDisabled = false;
	
	if(%target == %player) 
	{
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) 
		{
			%armor = Player::getArmor(%player);
			%armortype = $ArmorName[%armor];			
			
		//	if(%armortype == iarmorSpy) %player.repairRate = 0.025;
		//	else	
				%player.repairRate = 100.0;
			
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
		%player.repairRate = 50.0;
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else if(fixable(%player,%target))
		{
			%target.LastRepairCl =  %client;
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			if(GameBase::getTeam(%player)!= GameBase::getTeam(%target))
				%name = "enemy "@%name;			
		}
		else {%player.fixingDisabled = true;Player::trigger(%player,$WeaponSlot,false);return;}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(getObjectType(%player.repairTarget) == "Player") 
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
	if(%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) 
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else 
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if(GameBase::getDamageLevel(%player) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

RepairEffectData SuperRepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 7.5;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

//
function SuperRepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.fixingDisabled = false;
	if(%target == %player) 
	{
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) 
		{
			%player.repairRate = 100;	//0.25
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
		%player.repairRate = 100;
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else if(fixable(%player,%target))
		{
			%target.LastRepairCl =  %client; 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			if(GameBase::getTeam(%player)!= GameBase::getTeam(%target))
				%name = "enemy "@%name;
		}
	else {%player.fixingDisabled = true;Player::trigger(%player,$WeaponSlot,false);return;}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{			
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SuperRepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) 
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else 
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SuperRepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if(GameBase::getDamageLevel(%player) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

RocketData SuperRocket
{	
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 1.5;
	damageType = $ExplosionDamageType;
	explosionRadius = 30.5;
	kickBackStrength = 450.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.5;
	liveTime = 18.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};


LaserData CuttingLaserBeam
{
	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 15.0;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};


// shotgunbolt.dts tracer.dts bullet.dts
GrenadeData Blood
{	bulletShapeName = "laserhit.dts";
	explosionTag = bloodExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.5;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 8.0;
	liveTime = 0.1;	//after collision
	projSpecialTime = 0.05;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName = "laserhit.dts";	//rsmoke
	smokeDist = 20;
};

GrenadeData FieryBlood
{	bulletShapeName = "shotgunex.dts";
	explosionTag = bloodExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.5;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 8.0;
	liveTime = 0.1;	//after collision
	projSpecialTime = 0.05;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName              = "shotgunex.dts";	
	smokeDist = 1.5;
};



//============================================
// Simple kick back

function ArmSin(%theta) {
return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}
function ArmCos(%theta) {
return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
function ArmDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}
function ArmApplyKickback(%player, %strength, %lift) {
if((!%lift) && (%lift != 0)) %lift = 0;
%rot = GameBase::getRotation(%player);
%rad = getWord(%rot, 2);
%x = (-1) * (ArmSin(%rad));
%y = ArmCos(%rad);
%dir = %x @ " " @ %y @ " 0";
%force = ArmDotProd(Vector::neg(%dir),%strength);
%x = getWord(%force, 0);
%y = getWord(%force, 1);
%dir = %x @ " " @ %y @ " " @ %lift;
Player::applyImpulse(%player,%force);
}