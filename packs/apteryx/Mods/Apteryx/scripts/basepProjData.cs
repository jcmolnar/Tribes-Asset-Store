# Damage Types
#
$ImpactDamageType = -1;
$LandingDamageType = 0;
$BulletDamageType = 1;
$EnergyDamageType = 2;
$PlasmaDamageType = 3;
$ExplosionDamageType = 4;
$ShrapnelDamageType = 5;
$LaserDamageType = 6;	//anything using laser will report back as this type, regardless what its called.. -plasmatic
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
$MeleeDamageType = 20;
$TurretVortexDamageType = 21;
$PoisonDamageType = 22;
$JailDamageType = 23;
$Kickback = 24;
$SoulDamageType = 25;
$AntiTurretDamageType = 26;
$TrollPlasmaDamageType = 27;

//-------------------------

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
	damageType = $EnergyDamageType;
	muzzleVelocity = 80.0;
	totalTime = 4.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

BulletData MagneticLance
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.7;
	damageType = $ShockDamageType;
	explosionradius = 0.1;
	kickBackStrength = -400.0;
	muzzleVelocity = 155.0;
	totalTime = 0.115;
	liveTime = 0.4;
	lightRange = 7.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
	isvisible = true;
};

BulletData AcidCloudShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	damageClass = 1;
	damageValue = 0.35;
	damageType = $ExplosionDamageType;
	explosionRadius = 10.0;
	muzzleVelocity = 64.0;
	totalTime = 3.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
};

BulletData NanoInfection
{
	bulletShapeName = "smoke.dts";
	explosionTag = RatPoisonExp;
	damageClass = 1;
	damageValue = 0.05;
	damageType = $PoisonDamageType;
	muzzleVelocity = 100.0;
	explosionRadius = 3;
	totalTime = 0.175;
	liveTime = 1;
	lightRange = 3.0;
	lightColor = { -0.25, -0.25, -0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
};

BulletData NanoDamage 
{
	bulletShapeName = "tracer.dts";
	explosionTag = ShotExp;
	damageClass = 0;
	damageValue = 0.175;
	damageType = $MeleeDamageType;
	muzzleVelocity = 100.0;
	acceleration = 5.0;
	totalTime = 0.15;
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

BulletData HydraBullet
{	bulletShapeName = "laserhit.dts";
	explosionTag = blasterExp;
	mass = 0.05;
	damageClass = 0;
	damageValue = 0.115;
	damageType = $BulletDamageType;
	kickBackStrength = 20.0;
	aimDeflection = 0.006;
	muzzleVelocity = 170.0;
	totalTime = 17.5;
	inheritedVelocityScale = 0.25;
	isVisible = True;
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

BulletData MFAC
{	
	bulletShapeName = "paint.dts";
	explosionTag = flashExpMedium;
	collisionRadius = 0.0;
	mass = 0.001;
	damageClass = 0;
	damageValue = 1.3;
	damageType = $ShotgunDamageType;
	muzzleVelocity = 52.25;
	totalTime = 4.7;
	livetime = 2.0;
	inheritedVelocityScale = 0.25;
	isVisible = true;
	lightRange = 7.5;
	lightColor = { 0.0, 1.0, 0.0 };
	aimdeflection = 0.004;
};

BulletData MirrorReflection
{	
	bulletShapeName = "shield.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 0.01;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.16;
	damageType = $TrollPlasmaDamageType;
	explosionRadius = 6.5;
	kickBackStrength = 14.0;
	muzzleVelocity = 125.0;
	terminalVelocity = 125.0;
	acceleration = -20.0;
	totalTime = 2.0;
	liveTime = 2.0;
	lightRange = 5.0;
	lightColor = { 0.0, 0.5, 1.0 };
	inheritedVelocityScale = 0.8;
	isVisible = True;
	aimDeflection = 0.010;
};

BulletData EnergyRiftSpin
{	
	bulletShapeName = "Shield_Large.dts";
	explosionTag = flashExpMedium;
	mass = 0.001;
	damageClass = 1;
	damageValue = 1.3;
	explosionradius = 2;
	damageType = $EnergyDamageType;
	muzzleVelocity = 0.001;
	totalTime = 3.5;
	livetime = 2.75;
	inheritedVelocityScale = 0;
	isVisible = true;
	lightRange = 5.5;
	lightColor = { 0.0, 0.0, 1.0 };
	rotationPeriod = 0.1;
};

BulletData IonGatling
{	
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	damageClass = 0;
	damageValue = 0.20;
	damageType = $EnergyDamageType;
	kickBackStrength = 50.0;
	muzzleVelocity = 325.0;
	totalTime = 2.0;
	liveTime = 3.0;
	lightRange = 13.0;
	lightColor = { 1.0, 0.0, 1.0 };
	inheritedVelocityScale = 0.0;
	aimDeflection = 0.006;
	isVisible = true;
};

BulletData DroneBullet
{
	bulletShapeName = "Bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.1;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.13;
	damageType = $BulletDamageType;
	aimDeflection = 0.015;
	muzzleVelocity = 125.0;
	totalTime = 0.8;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 3.0;
	tracerLength = 30;
};

BulletData DroneAirBullet
{
	bulletShapeName = "Bullet.dts";
	explosionTag = vulcanexp;
	mass = 0.1;
	bulletHoleIndex = 0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.06;
	explosionRadius = 5;
	damageType = $BulletDamageType;
	aimDeflection = 0.015;
	muzzleVelocity = 140.0;
	totalTime = 1.8;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 90.0;
	tracerLength = 40;
};

BulletData SSBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = vulcanexp;
	mass = 5.0;
	damageClass = 1;
	damageValue = 0.05;
	damageType = $BulletDamageType;
	explosionRadius = 3.5;
	kickBackStrength = 40.0;
	aimDeflection = 0.04;
	muzzleVelocity = 120.0;
	totalTime = 5.0;
	inheritedVelocityScale = 0.45;
	isVisible = false;
	tracerPercentage = 90.0;
	tracerLength = 80;
};

//--------------------------------------

RocketData ParticleShot
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.625;
	damageType = $ShrapnelDamageType;
	explosionRadius = 7.0;
	kickBackStrength = 87.5;
	muzzleVelocity = 92.5;		//75
	terminalVelocity = 92.5;
	acceleration = 0.0;
	totalTime = 2.75;
	liveTime = 18.0;
	lightRange = 8.0;
	lightColor = { 0.0, 1.0, 0.65 };
	inheritedVelocityScale = 0.1;
	trailType = 1;
	trailLength = 15;
	trailWidth = 1.6;
};

RocketData EMP 
{	
	bulletShapeName = "fusionEx.dts";
	explosionTag = Shockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;	//0.35
	damageType = $ShockDamageType;
	explosionRadius = 11.5;
	kickBackStrength = 0.0;	//350
	muzzleVelocity = 65.0;		//50
	terminalVelocity = 65.0;	//80
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 1.0 };
	inheritedVelocityScale = 0.5;
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
	damageType = $EnergyDamageType;
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

RocketData BeaconShieldFire
{	
	bulletShapeName = "shield.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.185;
	damageType = $TrollPlasmaDamageType;
	explosionRadius = 5;
	kickBackStrength = 12.5;
	muzzleVelocity = 125.0;
	terminalVelocity = 125.0;
	acceleration = -20.0;
	totalTime = 2.0;
	liveTime = 2.0;
	lightRange = 5.0;
	lightColor = { 0.0, 0.5, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
	trailType = 1;
	trailLength = 0.01;
	trailWidth = 0.01;
};

RocketData WyvernShot 
{	
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.20;
	damageType = $EnergyDamageType;
	kickBackStrength = 50.0;
	muzzleVelocity = 400.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 2.0;
	liveTime = 3.0;
	lightRange = 10.0;
	lightColor = { 0.5, 0.0, 1.0 };
	inheritedVelocityScale = 0.4;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 1.2;
	soundId = SoundJetHeavy;
};

RocketData TerraShot
{	
	bulletShapeName = "shotgunex.dts";
	explosionTag = flashExpMedium;
	collisionRadius = 0.0;
	mass = 2.5;
	damageClass = 0;
	damageValue = 0.20;
	damageType = $BulletDamageType;
	kickBackStrength = 80.5;
	muzzleVelocity = 55.0;
	terminalVelocity = 60.0;
	acceleration = 0.0;
	totalTime = 1.25;
	liveTime = 2.5;
	lightRange = 4.5;
	lightColor = { 1.0, 0.4, 1.0 };
	inheritedVelocityScale = 0.3;
	trailType = 1;
	trailLength = 14;
	trailWidth = 1.6;
};

RocketData LasherBolt 
{	
	bulletShapeName = "fusionex.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $EnergyDamageType;
	explosionRadius = 5.0;
	kickBackStrength = -1.0;
	muzzleVelocity = 70.0;
	terminalVelocity = 300.0;
	acceleration = 0.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { -0.1, 0.5, 1.0 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailLength = 80;
	trailWidth = 0.5;
	soundId = SoundJetHeavy;
};

RocketData DroneGuardianShot 
{	
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.13;
	damageType = $EnergyDamageType;
	kickBackStrength = 50.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 1.0;
	liveTime = 2.0;
	lightRange = 10.0;
	lightColor = { 0.1, 0.0, 1.0 };
	inheritedVelocityScale = 0.4;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 1.2;
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

RocketData ArtilleryEffect
{	

	bulletShapeName = "shield.dts";
	explosionTag = TurretExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $PlasmaDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 30.0;
	muzzleVelocity = 50.0;
	totalTime = 0.02;
	livetime = 0.02;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	collisionRadius = 0.0;
	terminalVelocity = 70.0;
	acceleration = 0.0;
	lightRange = 1.0;
	lightColor = { 1.0, 0.25, 0.25 };
	trailType = 2;
	trailString = "shield.dts";
	smokeDist = 1.0;
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

RocketData ArtilleryShell
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = PhaseDisrupterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 20;
	damageType = $MissileDamageType;
	explosionRadius = 17.5;
	kickBackStrength = 400.0;
	muzzleVelocity = 48.0;
	terminalVelocity = 100.0;
	acceleration = 40.0;
	totalTime = 15.0;
	liveTime = 11.0;
	lightRange = 25.0;
	lightColor = { 0.80, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "fusionex.dts";
	smokeDist = 1.4;
	soundId = SoundFireMortar;
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

RocketData MagneticLanceEffect1
{
	mass = 1.0;
	bulletShapeName = "discb.dts";
	explosionTag = energyExp;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $ShockDamageType;
	explosionradius = 1.2;
	kickBackStrength = 0.0;
	muzzleVelocity = 140.0;
	terminalVelocity = 200.0;
	acceleration = 0.0;
	totalTime = 0.135;
	liveTime = 0.4;
	inheritedVelocityScale = 0.0;
	trailType = 1;
	trailLength = 100;
	trailWidth = 2.0;
};

RocketData MagneticLanceEffect2
{
	mass = 1.0;
	bulletShapeName = "discb.dts";
	explosionTag = energyExp;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $ShockDamageType;
	explosionradius = 0.1;
	kickBackStrength = 0.0;
	muzzleVelocity = 60.0;
	terminalVelocity = 60.5;
	acceleration = 0.0;
	totalTime = 0.33;
	liveTime = 0.4;
	inheritedVelocityScale = 0.0;
	isvisible = true;
	trailType = 1;
	trailLength = 50;
	trailWidth = 1.0;
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

RocketData ClusterMom
{	
	bulletShapeName = "Rocket.dts";
	explosionTag = rocketexp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $MissileDamageType;
	explosionRadius = 20;
	kickBackStrength = 60.0;
	muzzleVelocity = 30.0;
	terminalVelocity = 35.0;
	totalTime = 6.5;
	liveTime = 6.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.1;
	trailType = 2; // smoke trail
	trailString = "smoke.dts";
	smokeDist = 1.8;
};

RocketData DroneTurretEliminator
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	damageType = 0;
	damageValue = 6.0;
	DamageType = $AntiTurretDamageType;
	liveTime = 6.0;
	totalTime = 6.0;
	lightRange = 20.0;
	lightColor = { 1.0, 0, 0.0 };
	muzzleVelocity = 10.0;
	terminalVelocity = 10.0;
	inheritedVelocityScale = 1.0;
	detachFromShooter = false;
	trailType = 2;
	trailString = "shield.dts";
	smokeDist = 1;
};

//----------------

GrenadeData PlasmaBurn
{
//Plasmatic's admin
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

GrenadeData RatPoison
{
//Plasmatic's admin
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
//Plasmatic's admin
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
//Plasmatic's admin
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

GrenadeData BombShell
{
	bulletShapeName = "enex.dts";
	explosionTag = mortarExp;
	collideWithOwner = False;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 50.0;
	elasticity = 1.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $PlasmaDamageType;
	explosionRadius = 18.0;
	kickBackStrength = 200.0;
	maxLevelFlightDist = 20;
	totalTime = 4.00;
	liveTime = 0.45;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "fusionex.dts";
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
	damageValue = 0.4;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 1500;
	totalTime = 30.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData DroneGrenade
{
	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.2;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.57;
	damageType = $ExplosionDamageType;
	explosionRadius = 15;
	kickBackStrength = 85.0;
	maxLevelFlightDist = 700;
	totalTime = 3.0; // special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmatrail.dts";
};

GrenadeData PlasmaBlast
{
	bulletShapeName = "shield.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 0.05;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.68;
	damageType = $PlasmaDamageType;
	explosionRadius = 13.0;
	kickBackStrength = 95.0;
	maxLevelFlightDist = 165;
	totalTime = 2.0;
	liveTime = 0.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmaex.dts";
};

GrenadeData AntiMatterShell
{
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.075;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.75;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 220.0;
	maxLevelFlightDist = 325;
	totalTime = 10.0;
	liveTime = 1.65;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

GrenadeData MaulSwing
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = flashExpmedium;
	collideWithOwner = false;
	ownerGraceMS = 400;
	collisionRadius = 6.0;
	mass = 1.0;
	elasticity = 0.4;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 1.75;
	damageType = $MeleeDamageType;
	explosionRadius = 3.5;
	kickBackStrength = 450.0;
	maxLevelFlightDist = 5;
	totalTime = 1.15;
	liveTime = 0.33;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 2.0;
	smokeName = "enex.dts";
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
	damageValue = 0.75;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 200.0;
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

GrenadeData StarFlareDetonate
{	bulletShapeName = "Paint.dts";
	explosionTag = PhaseDisrupterExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 2.5;
	damageType = $ShrapnelDamageType;
	explosionRadius = 25;
	kickBackStrength = 350;
	maxLevelFlightDist = 100;
	totalTime = 0.05;
	liveTime = 0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "enex.dts"; //doesn't matter
	smokeDist = 1.5;
};

GrenadeData PlasmaPlume
{	bulletShapeName = "PlasmaBolt.dts";
	explosionTag = plasmaExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 1.0;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $PlasmaDamageType;
	explosionRadius = 6;
	kickBackStrength = 0;
	maxLevelFlightDist = 200;
	totalTime = 0.31;
	liveTime = 0.001;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "plasmatrail.dts";
	smokeDist = 1.5;
};

GrenadeData SilverWorm
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = blasterexp;
   collideWithOwner   = False;
   ownerGraceMS       = 10;
   collisionRadius    = 2.3;
   mass               = 1000.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $MeleeDamageType;

   explosionRadius    = 1.4;
   kickBackStrength   = 35.0;
   maxLevelFlightDist = 3.5;
   totalTime          = 0.7;    // special meaning for grenades...
   liveTime           = 0.175;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;
   smokeName              = "chainspk.dts";
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
//plasmatic
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
   kickBackStrength   = 75.0;
   maxLevelFlightDist = 200;
   totalTime          = 20.0;
   liveTime           = 20.0; // grenade time live after contact
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
};

GrenadeData MineFloaters
{
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
   smokeName              = "smoke.dts";
};

GrenadeData PrettySplit
{
//plasmatic
   bulletShapeName    = "shotgunbolt.dts";//grenade.dts
   explosionTag       = AgedonSplitExp;
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
   totalTime          = 0.01; 
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";//smoke.dts
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

GrenadeData EMPackBlast 
{	bulletShapeName = "fusionex.dts";
	explosionTag = Shockwave;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 995.0;
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.005;
	damageType = $ShockDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 1.0;
	smokeName = "fusionex.dts";
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

//--------------------------------------
SeekingMissileData TurretMissile
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 50.0;
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

SeekingMissileData ClusterFast
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.25;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 50.0;
	muzzleVelocity = 75.0;
	totalTime = 3;
	liveTime = 6;
	seekingTurningRadius = 8.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

SeekingMissileData ClusterMedium
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.25;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 50.0;
	muzzleVelocity = 62.0;
	totalTime = 3.5;
	liveTime = 6;
	seekingTurningRadius = 8.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

SeekingMissileData ClusterSlow
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.26;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 50.0;
	muzzleVelocity = 50.0;
	totalTime = 4;
	liveTime = 6;
	seekingTurningRadius = 8.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

SeekingMissileData DroneHunter
{
	bulletShapeName = "sensor_small.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 70.0;
	muzzleVelocity = 16.0;
	totalTime = 4;
	liveTime = 8;
	seekingTurningRadius = 0.001;
	nonSeekingTurningRadius = 5.0;
	proximityDist = 1.5;
	smokeDist = 2.75;
	lightRange = 5.0;
	lightColor = { 1.0, 0.3, 0.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

SeekingMissileData RailCurve
{
	bulletShapeName = "discb.dts";
	explosionTag = debrisExpMedium;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.62;
	damageType = $BulletDamageType;
	explosionRadius = 2.5;
	kickBackStrength = 70.0;
	muzzleVelocity = 105.0;
	totalTime = 1.2;
	liveTime = 3;
	seekingTurningRadius = 7.00;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 7.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
	smokename = "enex.dts";
	smokedist = 1.7;
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
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
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

LaserData PhrailterLaser
{
   laserBitmapName   = "blue_blink4.bmp";		//"pulse.bmp";
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

LaserData LightLaser
{	laserBitmapName = "laserPulse.bmp";
	hitName = "shotgunex.dts";
	damageConversion = 0.020;
	DamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 1.0;
	lightColor = { 1.0, 0.02, 0.02 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData HealingLaser
{	laserBitmapName = "blue_blink4.bmp";
	hitName = "enex.dts";
	damageConversion = -0.001;
	DamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 15.0;
	lightColor = { -0.8, -0.8, 1.0 };
	detachFromShooter = true;
	hitSoundId = SoundLaserHit;
};

LaserData SpottingLaser
{	laserBitmapName = "lightningnew.bmp";
	hitName = "enex.dts";
	damageConversion = -0.001;
	DamageType = $LaserDamageType;
	beamTime = 1.5;
	lightRange = 20.0;
	lightColor = { -1.0, -1.0, 1.0 };
	detachFromShooter = true;
	hitSoundId = SoundLaserHit;
};

LaserData TurretLaser 
{	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.0065;
	DamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 1.0, 1.0 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

LaserData TrackingLaser 
{	laserBitmapName = "paintPulse.bmp";
	hitName = "paint.dts";
	damageConversion = 0.0;
	DamageType = $LaserDamageType;
	beamTime = 1.0;
	lightRange = 10.0;
	lightColor = { -1.0, 1.0, -1.0 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

TargetLaserData targetLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 15.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

LightningData SoulBolt
 {
	bitmapName       = "zap03.bmp";	//lightningNew.bmp
   	boltLength       = 50.0;
   	coneAngle        = 50.0;
   	damagePerSec = 10;
   	energyDrainPerSec = 250;
   	segmentDivisions = 6;	//0;
   	numSegments = 8;		//1;
   	beamWidth = 0.4;	//0.25;
   	updateTime   = 30;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   lightRange = 15.0;
   lightColor = { 0.25, 0.25, 0.85 };
//   	lightRange = 3.0;
//   	lightColor = { 0.5, 0.5, 0.5 };
   	isVisible = false;//false
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

LightningData RailgunLockon
{
	bitmapName = "paintpulse.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 700.0;
	coneAngle = 13.5;
	damagePerSec = 0.001;
	energyDrainPerSec = 0.05;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.001;
	updateTime = 240;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 8.0;
	lightColor = { 0.0, 0.0, 0.0 };
	soundId = SoundELFFire;
};

LightningData Railgun2Lockon
{
	bitmapName = "paintpulse.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 700.0;
	coneAngle = 13.5;
	damagePerSec = 0.001;
	energyDrainPerSec = 0.05;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.001;
	updateTime = 240;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 8.0;
	lightColor = { 0.0, 0.0, 0.0 };
	soundId = SoundELFFire;
};

LightningData HunterDroneLockon
{
	bitmapName = "paintpulse.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 500.0;
	coneAngle = 17.5;
	damagePerSec = 0.001;
	energyDrainPerSec = 0.05;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.001;
	updateTime = 240;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 8.0;
	lightColor = { 0.0, 0.0, 0.0 };
	soundId = SoundELFFire;
};

LightningData ClusterMissileLockon
{
	bitmapName = "lightningnew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 120.0;
	coneAngle = 5;
	damagePerSec = 0.001;
	energyDrainPerSec = 0.05;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.001;
	updateTime = 240;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 15.0;
	lightColor = { -1.0, -1.0, 1.0 };
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
	boltLength = 7.5;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

//modified by Plasmatic to work with admin
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
			
				%player.repairRate = 0.025;
			
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

//modified by Plasmatic to work with admin
function SuperRepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.fixingDisabled = false;
	if(%target == %player) 
	{
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) 
		{
			%player.repairRate = 0.125;	//0.25
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
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};


// shotgunbolt.dts tracer.dts bullet.dts
GrenadeData Blood
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
	smokeName = "breath.dts";	//rsmoke
	smokeDist = 1.5;
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
	smokeName              = "plastrail.dts";	//shotgunex.dts";	//";
	//smokeName = "breath.dts";	//rsmoke
	smokeDist = 1.5;
};