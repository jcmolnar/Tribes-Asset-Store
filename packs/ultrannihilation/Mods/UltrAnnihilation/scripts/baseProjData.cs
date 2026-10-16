# Damage Types
#
$ImpactDamageType = -1;
$LandingDamageType =  0;
$BulletDamageType =  1;
$EnergyDamageType =  2;
$PlasmaDamageType =  3;
$ExplosionDamageType =  4;
$ShrapnelDamageType =  5;
$LaserDamageType =  6;
$MortarDamageType =  7;
$BlasterDamageType =  8;
$ElectricityDamageType =  9;
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
$TurretLaserDamageType = 20;
$TurretVortexDamageType = 21;
$PoisonDamageType = 22;

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
	damageValue = 0.11;
	damageType = $BulletDamageType;
	aimDeflection = 0.005;
	muzzleVelocity = 425.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
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

BulletData BlasterBolt
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag = blasterExp;
	damageClass = 0;
	damageValue = 0.125;
	damageType = $BlasterDamageType;
	muzzleVelocity = 200.0;
	totalTime = 2.0;
	liveTime = 1.125;
	lightRange = 3.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

BulletData PlasmaBolt
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
{	bulletShapeName = "shotgunbolt.dts";
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
{	bulletShapeName = "tracer.dts";
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

BulletData VulcanBullet 
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.13;
	damageType = $ExplosionDamageType;
	explosionRadius = 2.0;
	kickBackStrength = 100.0;
	aimDeflection = 0.005;
	muzzleVelocity = 700.0;
	totalTime = 8.5;
	liveTime = 18.0;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 2.0;
	tracerLength = 60;
};

BulletData Flames
{	bulletShapeName = "tumult_large.dts";
	explosionTag = flameExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;  // 0 impact, 1, radius
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
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.07;
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
	damageClass = 1;  // 0 impact, 1, radius
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
	damageClass = 1;  // 0 impact, 1, radius
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
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.055;
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
	expRandCycle = 3;
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
{	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 1;  //Radius
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
	damageClass = 1;  // 0 impact, 1, radius
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
RocketData DiscShell
{
	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $ExplosionDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 150.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.5;
	liveTime = 8.0;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 1;
	trailLength = 15;
	trailWidth = 0.3;
	soundId = SoundDiscSpin;
};

RocketData HyperDiscShell
{	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.37;
	damageType = $ExplosionDamageType;
	explosionRadius = 6;
	kickBackStrength = 110.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 90.0;
	acceleration = 5.0;
	totalTime = 6.5;
	liveTime = 8.0;
	lightRange = 5.0;
	lightColor = { 0, 1.0, 0 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailLength = 28;
	trailWidth = 0.3;
	soundId = SoundDiscSpin;
};

RocketData BasicRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.5;
	damageType = $ExplosionDamageType;
	explosionRadius = 20.5;
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

RocketData SniperBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.69;
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

RocketData Shock 
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.35;
	damageType = $MissileDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

RocketData RailRound
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.85;
	damageType = $SniperDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};

RocketData PhaseDisrupterBolt
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = PhaseDisrupterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 1.25;
	DamageType = $MissileDamageType;
	explosionRadius = 25.0;
	kickBackStrength = 450.0;
	muzzleVelocity = 80.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 10.0;
	lightColor = { 1.0, 6.7, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "fusionex.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData IonBolt 
{	bulletShapeName = "enbolt.dts";
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
{	bulletShapeName = "mortartrail.dts";
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
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
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
	trailType = 2;  // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

RocketData DisarmBolt
{	bulletShapeName = "mortartrail.dts";
	explosionTag = mortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	elasticity = 0.9;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $DisarmDamageType;
	explosionRadius = 20;
	kickBackStrength = 100.0;
	muzzleVelocity = 170.0;
	terminalVelocity = 180.0;
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
{	bulletShapeName = "plasmabolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
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
{	bulletShapeName = "plasmabolt.dts";
	explosionTag = PlasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.6;
	DamageType = $PlasmaDamageType;
	explosionRadius = 3.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 2.0;
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
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.70;
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
{	bulletShapeName = "plasmatrail.dts";
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
{	bulletShapeName = "Mortar.dts";
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
{	bulletShapeName = "fusionbolt.dts";
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
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
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
	trailType = 2;  // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData FlameShell
{	bulletShapeName = "plasmabolt.dts";
	explosionTag = fireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
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
	trailType = 2;  // smoke trail
	trailString = "plasmabolt.dts";
	smokeDist = 1.0;
	soundId = SoundJetHeavy;
};

RocketData StingerRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
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

RocketData HellfireRocket
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
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
	trailType = 2;  // smoke trail
	trailString = "HFlame.dts";
	smokeDist = 1.8;
};

RocketData TankRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
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
{	bulletShapeName = "sensor_small.dts";
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
	soundId	 = SoundJetHeavy;
};

//--------------------------------------
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
	damageValue = 0.4;
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
	totalTime = 1000.0;
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
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0;
	damageType = $NullDamageType;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 0;
	totalTime = 1.0;  // special meaning for grenades...
	liveTime = 0.75;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "rsmoke.dts";
};

GrenadeData AngelFireGren
{	bulletShapeName = "Paint.dts";
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
	smokeName = "enex.dts";
	smokeDist = 1.5;
};

GrenadeData FlameThrowerGren
{	bulletShapeName = "PlasmaBolt.dts";
	explosionTag = plasmaExp;
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

GrenadeData BabyNukeBomb
{	bulletShapeName = "Shockwave_Large.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.4;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 1;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 50.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "paint.dts";
};

GrenadeData RubberMortarShell
{	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.65;
	damageClass = 1;  // 0 impact, 1, radius
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

GrenadeData MineShell  //Mine Launcher
{	bulletShapeName = "mortar.dts";
	explosionTag = debrisExpSmall;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $MineDamageType;
	explosionRadius = 10;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 150;
	totalTime = 60.0;  // special meaning for grenades... 40
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
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
	damageValue = 0.5;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 72.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
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
	damageClass = 1;  // 0 impact, 1, radius
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
	trailType = 2;  // smoke trail
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
	explosionTag = rocketExp;
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
	baseDamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData ParticleBeam
{	laserBitmapName = "warp.bmp"; 
	hitName = "shockwave_large.dts";
	damageConversion = 0.064;
	DamageType = $BulletDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};

LaserData DeathRayLaser
{	laserBitmapName = "warp.bmp";
	hitName = "paint.dts";
	damageConversion = 0.015;
	DamageType = $EnergyDamageType;
	beamTime = 0.5;
	lightRange = 1.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData TurretLaser 
{	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.007;
	DamageType = $TurretLaserDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 } ;
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData RailLaser 
{	laserBitmapName = "paintPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.008;
	DamageType = $SniperDamageType;
	beamTime = 1.5;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = true;
	hitSoundId = SoundLaserHit;
};

TargetLaserData targetLaser
{
	laserBitmapName = "paintPulse.bmp";

	damageConversion = 0.0;
	baseDamageType = 0;

	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 };

	detachFromShooter = false;
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
	damageType = $ElectricityDamageType;
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

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target.jaildamage)
		return;
	else
		%target.jaildamage = true;
	%team = GameBase::getTeam(%shooterId);
	%aclient = Player::getClient(%target);
	if(getObjectType(%target) != "Player")
		return;
	if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
		return;
	%teleset = nameToID("MissionCleanup/JailPorts" @ %team);
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
			bottomprint(%client,"Your Punk Ass Has Been Placed Under Arrest By " @ %sname @ ", Your sentence will last for 30 seconds", 30);
			//Client::SendMessage(%client,0,"Your jail sentence will last 30 seconds.");
			echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
			//schedule("JailDoor::JailSesame("@%target@", " @ %team @ ");",45);
			schedule("JailBreak(" @ %target @ ", " @ %team @ ");",30);
			return;
		}
	}
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	%enVal = %timeSlice * %enDrainPerSec;

	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if (%energy < 0) 
		%energy = 0;
	GameBase::setEnergy(%target, %energy);
}

RepairEffectData RepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 997.5;
	segmentDivisions = 4;
	beamWidth = 0.125;

	updateTime = 450;
	skipPercent = 0.6;
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
			%player.repairRate = 0.075;
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
		%player.repairRate = 0.250;
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else {
			 
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
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if (%object == %player) 
		{
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

RepairEffectData SuperRepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 999.5;
	segmentDivisions = 4;
	beamWidth = 0.125;

	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;

	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

function SuperRepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) 
	{
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
		{
			%player.repairRate = 0.25;
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
		%player.repairRate = 0.50;
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else {
			 
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

function SuperRepairBolt::onRelease(%this, %player)
{
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

function SuperRepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if (%object == %player) 
		{
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}


function BabyNukeBomb::onAdd(%this)
{	schedule("BombSpread(" @ %this @ ");",5.1,%this);
}

function BombSpread(%this)
{	%obj = newObject("","Mine","bomba");
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

