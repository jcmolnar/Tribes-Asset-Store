//--------------------------------------------------| - Begin Rocket Data
RocketData FireScreen
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = FireScreenExp;
   collisionRadius  = 0;
   mass             = 2;
   damageClass      = 1;     
   damageValue      = 3;
   damageType       = $ShrapnelDamageType;
   explosionRadius  = 20;
   kickBackStrength = 15;
   muzzleVelocity   = 80;
   terminalVelocity = 160;
   acceleration     = 1;
   totalTime        = 3;
   liveTime         = 1;
   inheritedVelocityScale = 0.5;
   trailType              = 2;  
   trailString            = "plasmabolt.dts";
   smokeDist              = 1;
   soundId                = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;       
   damageValue      = 2;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;
   trailType              = 2;     
   trailString            = "rsmoke.dts";
   smokeDist              = 1.8;
   soundId                = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData FlameLarge
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $FlameDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 10.0;
   muzzleVelocity   = 45.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 4.0;
   liveTime         = 5.0;
   lightRange         = 15.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.25;

   // rocket specific
   trailType   = 2;
   trailString = "plasmabolt.dts";
   smokeDist   = 1.0;
   soundId = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData Watch
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $MissileDamageType;
   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;                
   trailString = "rsmoke.dts";
   smokeDist   = 10;
   soundId = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData NukeTurret
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;       
   damageValue      = 0.25;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 90.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType              = 2;              
   trailString            = "rsmoke.dts";
   smokeDist              = 1.8;
   soundId                = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData StingerRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.55;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 200;
	terminalVelocity = 250;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};
//--------------------------------------------------|

RocketData RPG
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 6.0;// 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 9;// 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 250;// 100.0;
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
//--------------------------------------------------|

RocketData DiscShell2
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0; 
   damageValue      = 5;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 7.5;
   kickBackStrength = 5;
   muzzleVelocity   = 500;
   terminalVelocity = 700;
   acceleration     = 1;
   totalTime        = 2.5;
   liveTime         = 1;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;
   soundId = SoundDiscSpin;
};
//--------------------------------------------------|

RocketData NDiscShell {
   bulletShapeName  = "discb.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 0;       
   damageValue      = 5;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 10;
   kickBackStrength = 5;
   muzzleVelocity   = 300;
   terminalVelocity = 400;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 1;
   inheritedVelocityScale = 0.5;
   trailType              = 1;
   trailLength            = 15;
   trailWidth             = 0.5;
   soundId                = SoundDiscSpin;
};

RocketData JailDart {
	bulletShapeName  = "bullet.dts";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 0.2;
	damageClass      = 0;
	damageValue      = 0.25;
	damageType       = $JailDamageType;
	explosionRadius  = 0.1;
	bulletHoleIndex  = 0;
	kickBackStrength = 600.0;
	muzzleVelocity   = 9000;
	terminalVelocity = 9000;
	acceleration     = 500.0;
	totalTime        = 10.0;
	liveTime         = 11.0;
	lightRange       = 10.0;
	lightColor       = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.0;
	soundId = SoundJetHeavy;
};

RocketData AtomShell {
   bulletShapeName = "mortar.dts";
   explosionTag    = rocketExp;
   collisionRadius = 1.0;
   mass            = 2.0;
   damageClass     = 1;       
   damageValue     = 10;
   damageType      = $ExplosionDamageType;
   explosionRadius = 3;
   kickBackStrength = 2;
   muzzleVelocity  = 80;
   terminalVelocity = 80;
   acceleration    = 1;
   totalTime       = 2;
   liveTime        = 1;
   trailType       = 1;
   trailLength     = 25;
   trailWidth      = 1.5;
   soundId         = SoundDiscSpin;
   inheritedVelocityScale = 0.5;
};

SeekingMissileData MiniFlakproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniFlakExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       
   damageValue      = 0.5;
   damageType       = $LiLRocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   muzzleVelocity    = 100.0;
   totalTime         = 3;
   liveTime          = 3;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   inheritedVelocityScale = 0.5;
};
//--------------------------------------------------|

SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniSAMExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       
   damageValue      = 1;
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
   inheritedVelocityScale = 0.76;
};
//--------------------------------------------------|

SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       
   damageValue      = 0.95;
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
   inheritedVelocityScale = 0.5;
};
function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}
//--------------------------------------------------|

SeekingMissileData StingerMissile
{	
	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 15.55;// 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 450;// 50.0;
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
//--------------------------------------------------|

SeekingMissileData TankMissile
{	
	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 8;
	damageType = $LiLRocketDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 150.0;
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
//--------------------------------------------------|

SeekingMissileData AdminTankMissile
{	
	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 20000;
	damageType = $LiLRocketDamageType;
	explosionRadius = 5.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 5.0;
	liveTime = 6.0;
	lightRange = 10.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};
//--------------------------------------------------|

SeekingMissileData PlasmaMissile // This proj is unused, problems with proj killing shooter...
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 0.2;
	damageClass = 0;
	damageValue = 55;
	damageType = $PlasmaDamageType;
	explosionRadius = 4;
	kickBackStrength = 5;
	muzzleVelocity = 600.0;
	terminalVelocity = 570.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 12.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 10;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 5.9;
};
//--------------------------------------------------| - End Seeking Missle Data