$ImpactDamageType      = -1;
$LandingDamageType     =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;	//=== Poison Effect
$PlasmaDamageType      =  3;	//=== On Fire Damage
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
$SniperDamageType      = 14;	//=== Drop Weapon-Flag Damage
$FlashDamageType       = 15;	//=== EMP Damage
$PlasmaWallDam         = 16;	//=== EMP Damage + drop items
$PaintType			= 17;	
$HeadShot			=18;
//$Damage19			=19;
$GravDamageType	       = 20;
$PunchType		= 21;
$CloakDamageType       = 22;
$NukeDamageType        = 23;
$TrapDam1       = 24;		//=== portal
$GrounderType    = 25;
//$Damage26			=26;
$EqualizerDamageType   = 27;
$TrapDam3			= 28;	//=== scary trap
$TrapDam4			= 29;	//=== sand trap
$TargetingDamageType	= 30;
$BoomStickDamageType	= 31;
$DetBugDamageType = 33;

//Globals
$hacking[%client] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";

if ($Wasteland::HackTime == "")
	$Wasteland::HackTime = "5";

if ($Wasteland::HackedTime == "")
	$Wasteland::HackedTime = "90";

if ($Wasteland::HackLock == "")
	$Wasteland::HackedLock = "0";

if ($Wasteland::AllowHacking == "")
	$Wasteland::AllowHacking = True;

if (!$Wasteland::LaserMineLive || $Wasteland::LaserMineLive == "")
	$Wasteland::LaserMineLive = 2;

//=================================================
//			    Bullet Class Ammos
//=================================================

//====================== ChainGun
BulletData ChaingunBullet
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.3;
	damageType         = $EqualizerDamageType;

	explosionRadius    = 2.5;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 150;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 1.5;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.003;
	muzzleVelocity     = 200.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 45;
};

//======================================================================== Silencer - Magnum
BulletData SilencerBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;
	damageValue        = 0.3;
	damageType         = $BulletDamageType;
	muzzleVelocity     = 625.0;
	aimDeflection      = 0.002;
	totalTime          = 0.30;
	inheritedVelocityScale = 1.0;
	isVisible          = True;

	tracerPercentage   = 100.0;
	tracerLength       = 30;
};

//======================================================================== Tranq Dart
BulletData TranqDart
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.3;
	damageType         = $EnergyDamageType;
	muzzleVelocity     = 625.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
	tracerPercentage   = 100.0;
	tracerLength       = 30;
};
//===================================Hot Tip Sniper
BulletData HotRound
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.3;
	damageType         = $PlasmaDamageType;
	muzzleVelocity     = 625.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
	tracerPercentage   = 100.0;
	tracerLength       = 30;
	soundId = SoundJetHeavy;
};

//======================================EMP Sniper
BulletData EMPRound
{
	bulletShapeName    = "enex.dts";
	explosionTag       = energyExp;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.3;
	damageType         = $FlashDamageType;
	muzzleVelocity     = 625.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
	tracerPercentage   = 100.0;
	tracerLength       = 30;
	soundId = SoundELFFire;
};

//======================================================================== Vulcan Bullet
BulletData VulcanBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.06;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.2;
	damageType         = $BulletDamageType;
	aimDeflection      = 0.007;
	muzzleVelocity     = 900.0;
	totalTime          = 2;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 60;
};

//======================================================================== BoomStickBlast
BulletData BoomStickBlast
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.08;
	damageType         = $BoomStickDamageType;
	aimDeflection      = 0.029;
	muzzleVelocity     = 200.0;
	totalTime          = 1;
	inheritedVelocityScale = 0.3;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 30;
	soundId = SoundJetLight;
};

//======================================================================== Fusion Bolt
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//======================================================================== MiniFusionBolt
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Blaster Bolt
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.200;
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

//======================================================================== Hyper Bolt
BulletData HyperBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = hblasterExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.0;
   liveTime           = 0.13;

   lightRange         = 3.0;
   lightColor         = { 0.3, 1.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData PlasmaBolt
{
	bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.65;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 6.0;
	kickBackStrength = 0;
	muzzleVelocity   = 65.0;
	terminalVelocity = 65.0;
	acceleration     = 65.0;
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

//========================= Plasma Bolt Multi
BulletData PlasmaBoltMulti
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 0;
	damageValue        = 0.33;
	damageType         = $PlasmaDamageType;

	muzzleVelocity     = 225.0;
	totalTime          = 1.25;
	liveTime           = 0.175;
	lightRange         = 2.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;

};

//================================= Booster Fire
RocketData Booster
{
	bulletShapeName  = "plasmaex.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	collideWithOwner   = False;

	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 0.0;
	kickBackStrength = 0;

	muzzleVelocity   = 5.0;
	terminalVelocity = 5.0;
	acceleration     = 5.0;
	totalTime        = 0.55;
	liveTime         = 0.55;
	lightRange       = 3.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//================================ Flamer Bolt
RocketData FlamerBolt
{
	bulletShapeName  = "plasmaex.dts";
   	explosionTag       = onFireExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.20;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;

	muzzleVelocity   = 30.0;
	terminalVelocity = 30.0;
	acceleration     = 30.0;
	totalTime        = 0.75;
	liveTime         = 0.85;
	lightRange       = 3.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//================================== HellFire Bullets
BulletData HellFireBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.10;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 5.0;

	aimDeflection      = 0.007;
	muzzleVelocity     = 155.0;
	totalTime          = 2.0;
	liveTime           = 2.0;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	rotationPeriod = 1;

	soundId = SoundJetLight;
};

//============================== Vulcan Bullet
BulletData VulcanTurretBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExpS;
	mass               = 0.06;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $BulletDamageType;
	aimDeflection      = 0.007;
	muzzleVelocity     = 900.0;
	totalTime          = 2;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 60;
};

//=====================================================
//		  Missile Class Ammos
//=====================================================

//=============================Flak Shell

RocketData FlakShell
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 1.0;
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

RocketData LasCannonBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = ShockwaveFour;
	collisionRadius = 0.0;
	mass = 0.0;
	damageClass = 0;
    	damageValue = 0.8;
	damageType = $LaserDamageType;
	explosionRadius = 2;
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
	trailWidth = 2.0;
	soundId = SoundJetHeavy;
};

RocketData LasCannonBolt2
{
	bulletShapeName = "discammo.dts";
	explosionTag = vehiclesmokeExp;
	collisionRadius = 0.0;
	mass = 0.0;
	damageClass = 0;
    	damageValue = 0.5;
	baseDamageType = $BulletDamageType;
	explosionRadius = 2;
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
	trailWidth = 1.0;
	soundId = SoundFireTargetingLaser;
};

RocketData LasCannonShock
{
	bulletShapeName  = "shield.dts";
	explosionTag     = ShockwaveFour;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 1.0;
	damageType       = $LaserDamageType;
	explosionRadius  = 5.0;
	kickBackStrength = 0;
	muzzleVelocity   = 250.0;
	terminalVelocity = 4000.0;
	acceleration     = 500.0;
	totalTime        = 14.0;
	liveTime         = 14.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.1, 1.5 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "shield.dts";
	smokeDist   = 20.0;
	soundId = SoundJetHeavy;
};

//======================================================================== Sniper Round
RocketData SniperRound2
{
	bulletShapeName  = "bullet.dts";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 0;
	damageValue      = 0.69;
	damageType       = $SniperDamageType;
	explosionRadius  = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity   = 3500.0;
	terminalVelocity = 3500.0;
	acceleration     = 500.0;
	totalTime        = 10.0;
	liveTime         = 11.0;
	lightRange       = 10.0;
	lightColor       = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
	validateShape = true;
};

//======================================================================== Disc Shell
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
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

//======================================================================== Flier Rocket
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
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//===================================
//	ScoutMissile
//===================================

SeekingMissileData ScoutMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $MissileDamageType;
   explosionRadius  = 5;
   kickBackStrength = 20.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 4;
   nonSeekingTurningRadius = 9.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//======================================================================== Turret Missile
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
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
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


//======================================================================== Shock Blast
RocketData Shock
{
   bulletShapeName  = "shield.dts";
   explosionTag     = ShockwaveFour;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;
   trailString = "shield.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

//====================================== Rail Round

RocketData RailRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;
   damageValue      = 0.75;
   damageType       = $BulletDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
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


//================================= Grounding Missle
SeekingMissileData MiniMissileTracker
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.5;
	damageType = $GrounderType;
	explosionRadius = 10.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 1000.0;
	acceleration = 200.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 3.6;
	nonSeekingTurningRadius = 3.6;
	proximityDist = 0.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	smokeDist = 4.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function MiniMissileTracker::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//======================== GodHammer Missile
RocketData GodHammer
{
	bulletShapeName = "rocket.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
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

//=============================== GodHammer Wire Guided Missle
GrenadeData GodHammerMortar
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 650;
   collisionRadius    = 2.5;
   mass               = 200.0;
   elasticity         = 0.55;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 75;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 2.0;
   inheritedVelocityScale = 0.1;
};

function GodHammerMortar::OnAdd(%this) { schedule("GodHammerMortar::Release(" @ %this @ ");", 0.5); }
function GodHammerMortar::Release(%this)
{
	%client = %this.deployer;
	%player = Client::GetOwnedObject(%client);
	%rot = gamebase::getrotation(%player);
	%dir = (Vector::getfromrot(%player));
	%vel = item::getvelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%t0 = getword (%trans, 0); %t1 = getword (%trans, 1); %t2 = getword (%trans, 2); %t3 = getword (%trans, 3); %t4 = getword (%trans, 4); %t5 = getword (%trans, 5); %t6 = getword (%trans, 6); %t7 = getword (%trans, 7); %t8 = getword (%trans, 8);
	%trans = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ gamebase::getposition(%this);
	playSound(SoundMissileTurretFire,GameBase::getPosition(%this));
	%fired = Projectile::spawnProjectile(GodHammer, %trans ,%player,%vel);
	%fired.deployer = %client;
	%fired.spawn = %this.spawn + 1;
	%fired.pos = gamebase::getposition(%fired);
	%this.distance = Vector::getDistance(%this.pos, %fired.pos);

	if (%fired.spawn < 50 && %this.distance > 8)
	{
		schedule("GodHammerMortar::Release(" @ %fired @ ");", 0.25);
	}
	deleteobject(%this);
}


//========================================================================  Ion Bolt
RocketData IonBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	 mass = 2.0;
	damageClass = 1;
    	damageValue = 0.25;
	damageType = $ElectricityDamageType;
	explosionRadius = 4;
	kickBackStrength = 0.0;
	muzzleVelocity = 250.0;
	terminalVelocity = 2000.0;
	acceleration = 500.0;
	totalTime = 0.5;
	liveTime = 0.3;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.2;
	trailType = 1;
	trailLength = 250;
	trailWidth = 0.9;
	soundId = SoundJetHeavy;
};

//==============================================
//			  Grenade Class Ammos
//==============================================

//======================= Grenade Shell
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
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//======================= EMP Grenade Shell
GrenadeData EMPgrenshl
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = ShockwaveThree;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $FlashDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
	smokeName              = "enex.dts";
};

//======================= Peace Shell
GrenadeData Peacegren
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1;
   elasticity         = 0.1;
   friction = 99.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PlasmaWallDam;

   explosionRadius    = 20;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
	smokeName              = "rsmoke.dts";
};

//======================= Tranq Grenade Shell
GrenadeData Tranqgren
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $EnergyDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
	smokeName              = "laserhit.dts";
};

//======================= Concuss Grenade Shell
GrenadeData Concusgren
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = ShockwaveFour;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 600;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
	smokeName              = "breath.dts";
};

//========================= Mortar Shell
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
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//============================= Mortar Turret Shell
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

   explosionRadius    = 35.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 600;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//==========================MDM Delay Mortar Shell
GrenadeData DelayMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = ShockwaveThree;
   collideWithOwner   = True;
   ownerGraceMS       = 650;
   collisionRadius    = 2.5;
   mass               = 200.0;
   elasticity         = 0.55;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;
   explosionRadius    = 25.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 475;
   totalTime          = 30.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.09;

   inheritedVelocityScale = 0.1;
   smokeName              = "mortartrail.dts";
};

//=========================================== EMP Mortar Shell
GrenadeData EMPMortar
{
	bulletShapeName    = "rocket.dts";
	explosionTag       = LargeShockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 400.0;
	elasticity         = 0.01;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.4;
	damageType         = $FlashDamageType;
	explosionRadius    = 35.0;
	kickBackStrength   = -10.0;
	maxLevelFlightDist = 275;
	totalTime          = 30.0;
	liveTime           = 2.0;
	projSpecialTime    = 0.01;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	smokeName        = "enex.dts";

};

//========================================= EMP Shell
GrenadeData EMPShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 995.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $FlashDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.01;
   smokeName              = "smoke.dts";
};

//============================= Bomber Shell
GrenadeData BomberShell
{
	bulletShapeName    = "mortar.dts";
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 0.01;
	elasticity         = 0.45;
	damageClass        = 1;
	damageValue        = 0.4;
	damageType         = $ShrapnelDamageType;
	explosionRadius    = 2;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 150;
	totalTime          = 5.0;
	liveTime           = 5.0;
	projSpecialTime    = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName              = "tumult_small.dts";
};

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ " , 5);",1.0,%this);
}

//======================================================================== Volter Burst
GrenadeData FlameBurst
{
    	explosionTag = plasmaExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 };
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
 };


//======================================================================== Tactical Nuke Shell

GrenadeData FgcShell
{
	bulletShapeName    = "mortar.dts";
	explosionTag       = LargeShockwave;
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
	totalTime          = 5.0;
	liveTime           = 5.0;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.5;
	smokeName              = "plasmatrail.dts";
};

function FgcShell::onAdd(%this)
{
	FgcShell::Deploy(%this);
}

function FgcShell::Deploy(%this)
{
	if (GameBase::isAtRest(%this))
	{
		schedule("NuclearExplosion(" @ %this @ ");",3.0,%this);
	}
	else
	{
		schedule("FgcShell::Deploy(" @ %this @ ");",3.0,%this);
	}
}

//===================================================
//		    Laser Class Ammos
//===================================================
//=============================Laser Turret Round
LaserData BigPulseLaser
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.5;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.0;

   lightRange        = 10.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//========================== LasCannon
LaserData GatlingLaser
{
	laserBitmapName   = "lightningNew.bmp";
	hitName           = "shield.dts";
	damageConversion  = 0.10;
	baseDamageType    = $LaserDamageType;
	beamTime          = 2.5;
	lightRange        = 5.0;
	lightColor        = { 0.01, 0.01, 1.25 };
	detachFromShooter = true;
	hitSoundId        = SoundLaserHit;
};

//======================================================================== Sniper Rifle Laser
LaserData sniperLaser
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== Target Turret Laser
LaserData targetturrLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = $TargetingDamageType;
   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};


//======================================================================== Targeting Laser
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = $TargetingDamageType;
   lightRange        = 20.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};

//=============================================================
//			  Lightining Class Ammos
//=================================================================

//============================== Hyper-Grav Turret

LightningData HGravCharge
{
   bitmapName       = "repairAdd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function HGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
	%Zvalue = -15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}


//======================================================================== Anti-Grav Turret

LightningData snareCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $GravDamageType;
   boltLength       = 150.0;
   coneAngle        = 40.0; //40
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.05;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function snareCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
	%Zvalue = 15;
	%velocity = 0.0;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

//========================================================================  Lightning Charge1
LightningData lightningCharge1
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $FlashDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.10;
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

//========================================================================

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

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//============================================= Grav Charge
LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1.0;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.5;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{

	%playerId = %shooterId;
	if (%playerId.GravBolt == "0")
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
		%Zvalue = %Rotation;
		%velocity = -25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
	else
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
		%Zvalue = %Rotation;
		%velocity = 25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);


		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);

		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
}

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

//=======================================================
//			   Repair Class Ammos
//=======================================================

//=======================
RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
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

	if (%target == %player)
	{
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			systemMessage(%client, 0, "AutoRepair On");
		}
		else if (%player.swim)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			systemMessage(%client, 0, "AutoOxygenate On");
		}
		else
		{
			systemMessage(%client,0,"Nothing in range");
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
		if (%target.swim) {}
		else if (GameBase::getDamageLevel(%player.repairTarget) == 0)
		{
			systemMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}

		if (getObjectType(%player.repairTarget) == "Player")
		{
			if (%target.swim) systemMessage(%rclient,0,Client::getName(%client) @ " is giving you more oxygen.");
			else systemMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		if (%target.swim) systemMessage(%client,0,"Oxygenating " @ %name);
		else systemMessage(%client,0,"Repairing " @ %name);

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
			systemMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				systemMessage(%client,0,"Repair Done");
			}
			else
			{
				systemMessage(%client,0,"Repair Stopped");
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
	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
	{
		%object = %player.repairTarget;
		if (getObjectType(%object) == "Player" && %object.swim)//== needs oxygen
		{
			%rclient = Player::getClient(%player.repairTarget);
			%swim = %object.swim - 1;
			if (%swim < 1) %swim  = 1;
			%object.swim = %swim;
			if (Client::getGender(%rclient) == "Female") systemMessage(%rclient,0,"~wfemale4.wcolor3.wav");
			else systemMessage(%rclient,0,"~wmale2.wcolor3.wav");
			return;
		}
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
					%objectTeam = GameBase::getTeam(%object);				
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")		%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
					else if (%objname == "Solar Panel")				%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Portable Generator")			%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
					else if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Command Station")			%pntval = $Score::ObjStationR;
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
								bottomprint(%client, "<jc>No points awarded, you were the last to damage.",3);
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								bottomprint(%client, "<jc>You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score,3);
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								bottomprint(%client, "<jc>Repairing Damage Score +" @ %score @ " = " @ %client.score,3);
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							bottomprint(%client, "<jc>You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score,3);
						}
						else
						{
							%client.score = (%client.score + %score);
							bottomprint(%client, "<jc>Repairing Damage Score +" @ %score @ " = " @ %client.score,3);
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
// Hack Gun Beam
//-------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	$hacking[%client] = "false";
	schedule ("Player::mountItem( " @ %client @ ", DisIt,0);",0.1);
}

function HackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if($Wasteland::AllowHacking)
	{
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player);
			%pName = Client::getName(%client);
			%tName = getTeamName(%team);

			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}

			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

			if(%team == %pTeam)
			{
				//echo ("Infecting");

				if (%target.infected == "true")
				{
					systemMessage(%client,0," Your team's " @ %name @ " is already protected from hacking.");
					return;
				}
				else if(checkHackable(%name, %shape) == 0 || getObjectType(%player.repairTarget) != "Player")
				{
					$hacking[%client] = "true";
					//echo ("Orgin Team = " @ $origTeam[%target]);
					if($origTeam[%target] == "")
					{
						//echo ("No original team set. Marking.");
						$origTeam[%target] = %team;
					}

					systemMessage(%client,0,"Infecting " @ %name @ ". Please wait...");

					hackingItem(%target, %pTeam, %pName, %tName, %team, $Wasteland::HackTime, %client);
					return;
				}
				return;
			}

			if(checkHackable(%name, %shape) == 1 || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					systemMessage(%client,0,"You can not hack another player.");
				}
				else
				{
					systemMessage(%client,0,"It is not possible to hack in to a " @ %name @ ".");
					if(%shape == "Generator" || %shape == "generator_p" || %shape == "solar" || %shape == "solar_med")
					{
						systemMessage(%client,0,"Hacking a generator is a newbie mistake anyway.");
					}
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					systemMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					systemMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking[%client] = "true";

				if($origTeam[%target] == "")
				{
					if ($debug) echo ("No original team set. Marking.");
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %team, $Wasteland::HackTime, %client);
			}
		}
	}
	else
	{
		systemMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

//===  Drain Bolt

LightningData DrainBolt
{
   bitmapName       = "paintPulse.bmp";
   boltLength       = 200.0;
   coneAngle        = 2.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 1.95, 0.25 };
};

function DrainBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%player = Client::getOwnedObject(%shooterId);
	%damagedclient = Player::getClient(%target);
	%objType = getObjectType(%target);
//================= Get Name of Target
	if(%objType == "Player" && !Player::isDead(%player))
	{
		%name = Client::getName(%damagedclient);
	}
	else
	{
		%name = GameBase::getMapName(%target);
		if(%name == "")
		{
			%name = (GameBase::getDataName(%target)).description;
			if(%name == "") %name = "Object";
		}
	}
//=======Targeting Team
	if (gamebase::getteam(%shooterId) == gamebase::getteam(%target) || gamebase::getteam(%target) == "-1")
	{
		if(%objType == "Player" && !Player::isDead(%player))
		{
			if (%target.shieldStrength > 0.009)
			{
				if (%target.shieldStrength > 0.01)
				{
					bottomprint(%shooterId, "<jc><f2>" @ %name @ "'s Shield is Max",3);
					bottomprint(%damagedclient, "<jc><f2>" @ Client::getName(%shooterclient) @ " upgraded your shield to Max",3);	
					%target.shieldStrength = 0.01;
				}
			}
			else
			{
				%target.shieldStrength = %target.shieldStrength + 0.0001;
				bottomprint(%shooterId, "<jc><f2>Shielding " @ %name @ " to " @ %target.shieldStrength * 10,3);
				bottomprint(%damagedclient, "<jc><f2>" @ Client::getName(%shooterclient) @ " is upgrading your shield to " @ %target.shieldStrength * 10,3);
				%damage = (GameBase::getDataName(%player)).maxDamage / 200;
				GameBase::applyDamage(%player,$CrushDamageType, %damage,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
			}
		}
		else if(%objType == "Flier" || %objType == "Turret")
		{
			if (%target.shieldStrength > 0.019)
			{
				if (%target.shieldStrength > 0.02)
				{
					bottomprint(%shooterId, "<jc><f2>" @ %name @ "'s Shield is Max",3);
					%target.shieldStrength = 0.02;
				}
			}
			else
			{
				%target.shieldStrength = %target.shieldStrength + 0.0001;
				bottomprint(%shooterId, "<jc><f2>Shielding " @ %name @ " to " @ %target.shieldStrength * 10,3);
				GameBase::applyDamage(%player,$CrushDamageType, %damage,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
			}
		}
		else
		{
			bottomprint(%shooterId, "<jc><f2>Cannot Leech-Shield " @ %name,3);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else
	{
		%shape = (GameBase::getDataName(%target)).shapeFile;
		if(checkHackable(%tname, %shape) == 1 && %objType != "Player")
		{
			bottomprint(%shooterId, "<jc><f2>Cannot Leech a " @ %name,3);
			systemMessage(%shooterId,1,"Cannot Leech a " @ %name @ "~wError_Message.wav");
		}
		if (GameBase::getDamageLevel(%target) >= (GameBase::getDataName(%target)).maxDamage) Player::trigger(%player,$WeaponSlot,false);
		else
		{
			%damage = (GameBase::getDataName(%target)).maxDamage / 350;
			if (GameBase::getDamageLevel(%player) > 0 )
			{
				bottomprint(%shooterId, "<jc><f2>Leeching health from " @ %name,3);
				GameBase::repairDamage(%player,(%damage*3));
				GameBase::applyDamage(%target,$FlashDamageType, %damage*3,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
			}
			else
				GameBase::applyDamage(%target,$FlashDamageType, %damage,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
		}
	}
}

//=========== Disassembler - Engineer 2-in-1 Gun.

RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added

		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

		if(getObjectType(%player.repairTarget) == "Player")
		{
			systemMessage(%client,0,"You can not disassemble a player.");
		}
		else
		{
			systemMessage(%client,0,"Disassembling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %shape, %disatime);
			if ($Debug) echo ("Done.");
		}
	}
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
	%client = Player::getClient(%player);
	schedule ("Player::mountItem( " @ %client @ ", Hackit,0);",0.1);
}

function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	bottomprint(%Client, "<jc>Score - " @ $Score::FlagDef @ " = " @ %client.score @ " for removing flag defense." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %shape, %disatime)
{
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);
	%name = GameBase::getMapName(%this);

	if(%name == "")
	{
		%name = (GameBase::getDataName(%player.repairTarget)).description;
	}

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassemble the " @ %name @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	if (String::findSubStr(%name, "Anti-AirCraft") >= 0)
	{
		%item = "BarragePack";
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Concussion Turret") >= 0)
	{
		%item = "ConPack";
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Dart Turret") >= 0)
	{
		%item = "CameraPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Deployable Elf Turret") >= 0)
	{
		%item = "DeployableElf";
		objectTearup (%this, %item, %client, %player, 1, 20, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";
		objectTearup (%this, %item, %client, %player, 1, 10, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Flak Turret") >= 0)
	{
		%item = "FlakPack";
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Flame Turret") >= 0)
	{
		%item = "FlameTurretPack";
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "RMT Mortar Turret") >= 0)
	{
		%item = "TargetPack";
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Rail Turret") >= 0)
	{
		%item = "RailTurretPack";
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "RMT Rocket Turret") >= 0)
	{
		%item = "RocketPack";
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Vulcan Turret") >= 0)
	{
		%item = "DeployableVulcan";
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Blast Floor") >= 0)
	{
		%item = "BlastFloorPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Large Force Field") >= 0)
	{
		%item = "LargeForceFieldPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Small Force Field") >= 0)
	{
		%item = "ForceFieldPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Large Shock Force Field") >= 0)
	{
		%item = "LargeShockForceFieldPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Shock Floor") >= 0)
	{
		%item = "ShockFloorPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Teleport Pad") >= 0)
	{
		%item = "TeleportPack";
		deleteObject(%this.beam1);
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "DepGenerator") >= 0)
	{
		%item = "PowerGeneratorPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Portal") >= 0)
	{
		%item = "HolePack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Zepplin Pad") >= 0)
	{
		%item = "ZepplinPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Sentry") >= 0)
	{
		%item = "Sentry";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Accel Pad") >= 0)
	{
		%item = "AccelPPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Elevator Pad") >= 0)
	{
		%item = "Elevator";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Launchboard") >= 0)
	{
		%item = "LaunchPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Remote Command Station") >= 0)
	{
		%item = "DeployableComPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Invo Station") >= 0)
	{
		%item = "DeployableInvPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Remote Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Motion Sensor") >= 0)
	{
		%item = "MotionSensorPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "ArbitorBeacon") >= 0)
	{
		%item = "ArbitorBeaconPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "EMPBeacon") >= 0)
	{
		%item = "EMPBeaconPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "JammerBeacon") >= 0)
	{
		%item = "JammerBeaconPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Shield Device") >= 0)
	{
		%item = "ShieldBeaconPack";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Emergency Invo") >= 0 && GameBase::getTeam(%this) == GameBase::getTeam(%player))
	{
		%item = "EmergencyInvPack";
		deleteObject(%this.beam);
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		return 1;
	}
	else if (String::findSubStr(%name, "Air Fuser Ground Unit") >= 0 && GameBase::getTeam(%this) == GameBase::getTeam(%player))
	{
		%item = "AirAmmoPad";
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %name);
		$TeamItemCount[%team @ %item]++;
		$TeamItemCount[%team @ "AirFuserPad"]--;
		return 1;
	}
	else if (GameBase::getDataName(%this).shapeFile == "mine")
	{
		Player::incItemCount(%client,MineAmmo);
		bottomprint(%client, "<jl><f1> Disassembled Mine.", 3);
		playSound(SoundFlyerDismount,GameBase::getPosition(%player));
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	systemMessage(%client,1,"Disassembling " @ %name @ " failed...~wError_Message.wav");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

// objectTearup (%this, %item, %client, %player, 1, 1, %flagdist, %description);

function objectTearup (%this, %item, %client, %player, %turret, %flag, %flagdist, %description)
{
	$TeamItemCount[GameBase::getTeam(%this) @ %item]--;

	if (%turret) $totalNumTurrets = $totalNumTurrets - 1;

	Player::setItemcount (%client, %item, 1);
	Player::mountItem(%client,%item,$BackpackSlot);
	bottomprint( %client, "<jl><f1> Disassembled " @ %description @ ".", 3);
	playSound(SoundFlyerDismount,GameBase::getPosition(%player));
	if (%flag > 0 && %flagdist < %flag) removeflagdefpoints(%player);
	deleteObject(%this);
	$disassymble[%player] = false;
}

//===================================
//		 Grounder
//===================================


LightningData LockJaw
{
	bitmapName       = "paintPulse.bmp";

	damageType       = $GravDamageType;
	boltLength       = 700.0;
	coneAngle        = 10.0;
	damagePerSec      = 0.00001;
	energyDrainPerSec = 0;

	boltLength       = 700.0;
	segmentDivisions = 2;
	beamWidth        = 0.05;
	updateTime   = 150;
	skipPercent  = 1.0;
	displaceBias = 0.25;

	lightRange = 3.0;
	lightColor = { 0.15, 0.15, 0.95 };
};

function LockJaw::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %player)
{
	%client = Player::getClient(%player);

	if (!%client.target || %client.target == "-1" || %client.target == %player)
		%client.target = %target;
  	%type = getObjectType(%target);

	echo ("Type " @ %type);

	if (%type == "Player" || %type == "Flier")
	{}
	else
	{
		bottomprint(%client, "<jc><f1>Lock Failed, No Targetable Object!", 3);
		systemMessage(%client,0,"~waccess_denied.wav");
		%client.target = -1;
		return;
	}

	if (!%client.target || %client.target == "-1" || %client.target == %player)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>No Lock, Attempting To Acquire!\", 3);", 0);
		bottomprint(%client, "<jc><f1>No Lock, Attempting To Acquire!", 3);
		systemMessage(%client,0,"~waccess_denied.wav");
		%client.target = -1;
		Player::trigger(%player,$WeaponSlot,false);
		return;
	}
	if (%client.target != "-1")
	{
		if (gamebase::getteam(%client.target) == gamebase::getteam(%player))
		{
			bottomprint(%client, "<jc><f1>Lock Failed, Can Not Target Friendlies!", 3);
			systemMessage(%client,0,"~waccess_denied.wav");
			%client.target = -1;
			return;
		}
		schedule("systemMessage(" @ %client @ ",0,\"~wmine_act.wav\");",0);
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>LockJaw Aquired - Active For Next 15 Seconds! - Fire Now To Launch!\", 3);", 0);
		schedule("systemMessage(" @ %client @ ",0,\"~wmine_act.wav\");",15);
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>LockJaw Lost Lock!\", 3);", 15);
		schedule("" @ %client @ ".target = \"-1\";", 15);
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %player @ "));",0);
		Player::trigger(%player,$WeaponSlot,false);
		LockJaw(%client,%target);
	}
}
function LockJaw::onAcquire(%this, %player, %target){}
function LockJaw(%clientId, %targetId)
{
	if(%targetId)
	{
		%client = Player::getClient(%targetId);
		%name = Client::getName(%client);
		 systemMessage(%client,1,"** WARNING ** - " @ %name @ ", You're going down!~waccess_denied.wav");
		 schedule("systemMessage(" @ %client @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("systemMessage(" @ %client @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("systemMessage(" @ %client @ ",0,\"~waccess_denied.wav\");",1.5);
	}
}
function LockJawFire(%player, %target)
{
	if ($debug) echo ("Firing Locker");

	%client = Player::getClient(%player);

	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = item::getVelocity(%player);

	$targetingmissile = %client.target;
	Projectile::spawnProjectile("MiniMissileTracker",%trans,%player,%vel,%client.target);
	schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0);
}

function LockJaw::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	%object = %player.target;

	if ($debug) echo ("Object Target " @ %player.target);
	if ($debug) echo ("Shootr Client " @ %client);
}

//=============================
//		Special Functions
//=============================
function NuclearExplosion(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";

	if (!%player)
		return;

	%pos = gamebase::getposition(%this);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType;

	%Set = newObject("nukeset",SimSet);
	containerBoxFillSet(%Set, %Mask, %Pos, 30, 30, 30, 0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(%obj!=%this) GameBase::applyDamage(%obj, $NukeDamageType, 1.5, GameBase::getPosition(%obj), "0 0 0", "0 0 0", %cl);
	}
	deleteObject(%set);

	%Set = newObject("nukeset",SimSet);
	containerBoxFillSet(%Set, %Mask, %Pos, 15, 15, 15, 0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		if(%obj!=%this && %data.maxDamage < 100) GameBase::setDamageLevel(%obj, %data.maxDamage);
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

//Additions


LightningData jailbolt
{
	bitmapName       = "zap01.bmp";
	damageType       = $ElectricityDamageType;
	boltLength       = 10.0;
	coneAngle        = 4.0;
	damagePerSec      = 0.01;
	energyDrainPerSec = 60.0;
	segmentDivisions = 1;
	numSegments      = 1;
	beamWidth        = 0.5;
	updateTime   = 120;
	skipPercent  = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooter)
{
	//Player::mountItem(%shooter, JailGunLicks, 7);
	//schedule ("Player::unmountItem( " @ %shooter @ ", 7);",0.2);
	%playerTeam = GameBase::getTeam(%target);
	if(getObjectType(%target) != "Player")
	{
		return;
	}
	if(%playerTeam == GameBase::getTeam(%shooter))
	{
		return;
	}
	%teleset = nameToID("MissionCleanup/jailports");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam=GameBase::getTeam(%o);
		if(%oteam != %playerTeam)
		{
			%sclient = Player::getClient(%shooter);
			%sname = Client::getName(%sclient);
			%client = Player::getClient(%target);
			%vname = Client::getName(%client);
			%FlagDrop = (Player::getMountedItem(%target, $FlagSlot));
			Player::dropItem(%target, %FlagDrop);
			GameBase::SetPosition(%target,GameBase::GetPosition(%o));
			if (%target.jail != "True")
			{
				%target.jail = "True";
				%client.jail = "True";
				MessageAllExcept(%client, 0, %vname @ " is arrested by " @ %sname);
				Client::sendMessage(%client,1,"You Have Been Placed Under Arrest By " @ %sname);
				%sclient.score = %sclient.score +1;
  				Bottomprint(%sclient, "<jc>Security Success! Score +1 = " @ %sclient.score,3);
				echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
				systemMessage(%client,1,"~wCapturedTower.wav");
				systemMessage(%sclient,0,"~wshieldhit.wav");
				schedule("jLargeForceField::jailSesame("@%target@");",20);
			}

		}
	}
}
BulletData IrradiationBlast
{	bulletShapeName = "dustplume.dts";
	explosionTag = debrisExpSmall;
	mass = 0.07;
	damageClass = 1;  // 0 impact, 1, radius
	explosionRadius = 5.0;
	damageValue = 0.5;
	baseDamageType = $BulletDamageType;
	aimDeflection = 0.0004;
	muzzleVelocity = 180.0;
	totalTime = 2;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};

//------------------------------------------------
// Saboteur Gun Beam
//------------------------------------------------
RepairEffectData SabBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function SabBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	$hacking[%client] = "false";
}

function SabBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player);
			%pName = Client::getName(%client);
			%tName = getTeamName(%team);

			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}

			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

			if(%target.tc != "")
			{
				systemMessage(%client,1,"This " @ %name @ " is already cross-wired.~waccess_denied.wav");
				return;
			}

			if(%team == %pTeam)
			{
				systemMessage(%client,1,"This " @ %name @ " belongs to your team.~waccess_denied.wav");
				return;
			}

			if(checkSabable(%name, %shape) == 1 || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player") systemMessage(%client,1,"You can not sabotage another player.~waccess_denied.wav");

				else systemMessage(%client,0,"It is not possible to sabotage a " @ %name @ ".~waccess_denied.wav");
			}
			else
			{
				systemMessage(%client,0,"Sabotaging " @ %name @ ". Please wait...");
				$hacking[%client] = "true";

				sabingItem(%target, %pTeam, %pName, %tName, %name, %team, $Wasteland::HackTime, %client);
			}
		}
}

RocketData PlasmaCannonBolt
{
	bulletShapeName = "plasmaex.dts";
	explosionTag = plasmaExp2;
	collisionRadius = 0.0;
	mass = 0.0;
	damageClass = 1;
    	damageValue = 0.8;
	damageType = $PlasmaDamageType;
	explosionRadius = 15;
	kickBackStrength = 0.0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 45.0;
	totalTime = 5.0;
	liveTime = 5.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.0, 0.05 };
	inheritedVelocityScale = 0.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonBolt2
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 0.0;
	damageClass = 1;
    	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	explosionRadius = 10;
	kickBackStrength = 0.0;
	muzzleVelocity = 35.0;
	terminalVelocity = 45.0;
	acceleration = 35;
	totalTime = 5.0;
	liveTime = 5.0;
	lightRange = 5.0;
	lightColor = { 2.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;
	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 180.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock
{
	bulletShapeName  = "plasmabolt.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 140.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock2
{
	bulletShapeName  = "plasmaex.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 65.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 160.0;
	soundId = SoundJetHeavy;
};

//===  RepairPostBolt

LightningData RepPostBolt
{
   bitmapName       = "repairAdd.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 30.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.01;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.125;
   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };
   soundId = SoundRepairItem;
};

function RepPostBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damage = 0.01;
	if (gamebase::getteam(%shooterId) == gamebase::getteam(%target))
 	{
		bottomprint(Player::getClient(%target), "<jc><f2>Being Repaired By Repair Prism");
		GameBase::repairDamage(%target,%damage);
	}
}

//===  Prism Bolt

LightningData PrismBolt
{
   bitmapName       = "paintPulse.bmp";
   damageType       = $FlashDamageType;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   boltLength       = 400.0;
   coneAngle        = 30.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 1.95, 0.25 };
   soundId = SoundElevatorBlocked;
};

//====================================== Punch
BulletData Punch
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = landpunch;
	mass               = 1;
   damageClass        = 0;
   damageValue        = 0.4;
   damageType         = $PunchType;

   muzzleVelocity     = 8.0;
   totalTime          = 0.3;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 1;
	isVisible          = False;

};

//====================================== SortieBolt
RepairEffectData SortieBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 270.0;
   segmentDivisions = 0;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

};

function SortieBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	$AirStrike[%client] = "false";
	systemMessage(%client,0,"Cancelling assault request.");
	$TeamItemCount[%team @ "SortieGun"]--;
	if ($TeamItemCount[%team @ "SortieGun"] < 0) $TeamItemCount[%team @ "SortieGun"] = 0;
	if (!%client.tc) %client.tc = %client;
	else %client.tc="";
}

function SortieBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%pTeam = GameBase::getTeam(%player);
	if($TeamItemMax["SortieGun"] <= $TeamItemCount[%pteam @ "SortieGun"])
	{
		bottomprint(%client,"<jc><f2>AirStrike Targeting Laser already in use.", 3);
		systemMessage(%client,0,"~wAccess_Denied.wav");
		$TeamItemCount[%pteam @ "SortieGun"]++;
		return;
	}
	$TeamItemCount[%pteam @ "SortieGun"]++;
	if ($TeamItemCount[%pteam @ "SortieGun"] > 1) $TeamItemCount[%pteam @ "SortieGun"] = 1;
	%team = GameBase::getTeam(%target);
	if(%team == %pTeam)
	{
		systemMessage(%client,0,"Friendly target.");
		return;
	}
	if (%client.tc)
	{
		systemMessage(%client,3,"RazorOne: " @ Client::getName(%client) @ ", this is RazorOne with AirStrike Command.~wflyer_idle.wav");
		systemMessage(%client,3,"We've got your signal... stand by.~wmale1.wtgtobj.wav");
		$AirStrike[%client] = "true";
		AirStrike(%target, %pTeam, %pName, %team, 25, %client);
	}
	else
	{
		systemMessage(%client,3,"BDog: " @ Client::getName(%client) @ ", this is Bdog with BigGuns Field Artillery.~wflyer_idle.wav");
		systemMessage(%client,3,"We've got your signal... stand by.~wmale1.wtgtobj.wav");
		$AirStrike[%client] = "true";
		ArtStrike(%target, %pTeam, %pName, %team, 8, %client);
	}
}

function ArtStrike(%target, %pTeam, %pName, %team, %time, %client)
{
	%player = Client::GetOwnedObject(%client);
	if(%time > 0)
	{
		if($AirStrike[%client])
		{
			if (%time == 6)
			{
				systemMessage(%client,3,"BDog: BigGuns locked and loaded, sit tight...~wflyer_idle.wav");
				systemMessage(%client,0,"~wmale1.wtgtacq.wav");
			}
			if (%time == 3)
			{
				%inv = NewObject("", "Item", "AirStrike", 1, false);
				addToSet("MissionCleanup", %inv);
				%padd = "0 0 80";
				%inv.tc = %target;
				%inv.DetBugOwner = %player;
				%pos = Vector::add(GameBase::getPosition(%target),%padd);
				GameBase::setPosition(%inv,%pos);
				schedule("deleteObject(" @ %inv @ ");",5, %inv);
			}
			if (%time == 1)
			{
				TeamMessages(1, GameBase::getTeam(%target), "INCOMING ARTILLERY! HIT THE DIRT!~wfemale5.whitdeck.wav");
				TeamMessages(3, GameBase::getTeam(%player), "BDog: INCOMING ARTILLERY!~wflyer_idle.wav");
				TeamMessages(0, GameBase::getTeam(%player), "~wmale1.whitdeck.wav");
			}
			schedule("ArtStrike('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
		}
		else
		{ 
			systemMessage(%client,3,"Bdog: Target not exposed for artillery, BigGuns quiet. Bdog out.~wflyer_idle.wav");
			systemMessage(%client,0,"~wmale1.wordcan.wav");
		}
	}
	else if ($AirStrike[%client] == "true")
	{
		%set = newObject("set",SimSet);
		%pos = GameBase::getPosition(%target);
		%tnum = containerBoxFillSet(%set, $StaticObjectType,%pos,40,40,40,0);
		if (%tnum>0)
		{
			for (%i=0;%i<%tnum;%i++)
			{
				%tgt=Group::getObject(%set,%i);
				%tgtTeam=GameBase::getTeam(%tgt);
				%name = GameBase::getDataName(%tgt);
				if(%pteam != %tgtTeam && %name == "JammerBeacon")
				{
					deleteObject(%set);
					systemMessage(%client,3,"BDog: Enemy missle defense beacon interference!~wflyer_idle.wav");
					systemMessage(%client,0,"~wmale1.wobjxcmp.wav");
					systemMessage(%client,0,"~wAccess_Denied.wav");
					schedule("systemMessage(" @ %client @ ",3,\"BDog: BigGuns quiet.~wflyer_idle.wav\");",5);
					schedule("systemMessage(" @ %client @ ",0,\"~wmale1.wordcan.wav\");",5);
					return;
				}
			}
		}
		deleteObject(%set);
		StartArtie(%pos);
		$painter = %client;
		schedule("ArtStrike('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %team @ "','" @ %time @ "','" @ %client @ "');", 3);
	}
}

function StartArtie(%pos){
	%bomb = "MortarBomb";
	%newpos = Vector::add(%pos, "0 0 40");
	%shooterClient = $painter;
	%player = Client::getOwnedObject(%shooterClient);
	%relayer = $relayer[GameBase::getTeam(%shooterClient)];
	%object = newObject("","Mine",%bomb);
	addToSet("MissionCleanup", %object);
	%randnumber = floor(getRandom() * 16);
	if(%randnumber <8) GameBase::throw(%object,%player,1,false);
	else GameBase::throw(%object,%relayer,1,false);
	GameBase::SetPosition(%object, %newpos);
}

function AirStrike(%target, %pTeam, %pName, %team, %time, %client)
{
	%player = Client::GetOwnedObject(%client);
	if(%time > 0)
	{
		if($AirStrike[%client] == "true")
		{
			schedule("AirStrike('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			if (%time == 20)
			{
				systemMessage(%client,3,"RazorOne: Bomber airborne & inbound, sit tight...~wflyer_idle.wav");
				systemMessage(%client,0,"~wmale1.wtgtout.wav");
			}
			if (%time == 15)
			{
				%inv = NewObject("", "Item", "AirStrike", 1, false);
				addToSet("MissionCleanup", %inv);
				%padd = "0 0 80";
				%inv.tc = %target;
				%inv.DetBugOwner = %player;
				%pos = Vector::add(GameBase::getPosition(%target),%padd);
				GameBase::setPosition(%inv,%pos);
				schedule("deleteObject(" @ %inv @ ");",5, %inv);
			}
			if (%time == 10)
			{

				if (%player.tc == %target)
				{
					systemMessage(%client,3,"RazorOne: Bomber has visual. ETA to drop... 10 secs.~wflyer_idle.wav");
					systemMessage(%client,0,"~wmale1.wtgtacq.wav");
				}
				else
				{
					systemMessage(%client,3,"RazorOne: Bomber unable to visualize the target from above, mission is a scrub.~wflyer_idle.wav");
					systemMessage(%client,3,"~wmale1.wobjxcmp.wav");
					systemMessage(%client,0,"~wAccess_Denied.wav");
					Player::trigger(%player,0,false);
				}
			}
			if (%time == 5)
			{
				systemMessage(%client,3,"RazorOne: Bomber approaching drop zone, keep that target hot!~wflyer_idle.wav");
				systemMessage(%client,0,"~wmale1.wneedtgt.wav");
			}
			return;
		}
		else
		{ 
			systemMessage(%client,3,"RazorOne: Bogey dropped off radar, AirStrike being recalled. RazorOne out.~wflyer_idle.wav");
			systemMessage(%client,0,"~wmale1.wordcan.wav");
		}
	}
	else if ($AirStrike[%client] == "true")
	{
		%set = newObject("set",SimSet);
		%pos = GameBase::getPosition(%target);
		%tnum = containerBoxFillSet(%set, $StaticObjectType,%pos,40,40,40,0);
		if (%tnum>0)
		{
			for (%i=0;%i<%tnum;%i++)
			{
				%tgt=Group::getObject(%set,%i);
				%tgtTeam=GameBase::getTeam(%tgt);
				%name = GameBase::getDataName(%tgt);
				if(%pteam != %tgtTeam && %name == "JammerBeacon")
				{
					deleteObject(%set);
					systemMessage(%client,3,"RazorOne: Enemy missle defense beacon interference!~wflyer_idle.wav");
					systemMessage(%client,3,"~wmale1.wobjxcmp.wav");
					systemMessage(%client,0,"~wAccess_Denied.wav");
					schedule("systemMessage(" @ %client @ ",3,\"RazorOne: AirStrike Team being recalled.~wflyer_idle.wav\");",5);
					schedule("systemMessage(" @ %client @ ",3,\"~wmale1.wordcan.wav\");",5);
					return;
				}
			}
		}
		deleteObject(%set);

		TeamMessages(1, GameBase::getTeam(%target), "INCOMING AIRSTRIKE! TAKE COVER!~wfemale5.wtakcovr.wav");
		TeamMessages(3, GameBase::getTeam(%player), "RazorOne: AirStrike Payload is a go!~wflyer_idle.wav");
		TeamMessages(0, GameBase::getTeam(%player), "~wmale1.wtakcovr.wav");
		StartSortie(%pos);
		$painter = %client;
		schedule("systemMessage(" @ %client @ ",3,\"RazorOne: AirStrike Team returning to base, mission complete.  RazorOne out.~wflyer_idle.wav\");",5);
		schedule("systemMessage(" @ %client @ ",0,\"~wmale1.wobjcomp.wav\");",5);
	}
}

function Sortie(%grenadetype, %pos) {
	%randnumber = floor(getRandom() * 16);
	if(%randnumber == 1) {
		%grenadeposition = "-10 -10 40";
	} else if(%randnumber == 2) {
		%grenadeposition = "-5 10 50";
	} else if(%randnumber == 3) {
		%grenadeposition = "0 -10 80";
	} else if(%randnumber == 4) {
		%grenadeposition = "5 15 40";
	} else if(%randnumber == 5) {
		%grenadeposition = "10 -10 50";
	} else if(%randnumber == 6) {
		%grenadeposition = "-10 -5 30";
	} else if(%randnumber == 7) {
		%grenadeposition = "-5 10 40";
	} else if(%randnumber == 8) {
		%grenadeposition = "0 -5 50";
	} else if(%randnumber == 9) {
		%grenadeposition = "15 -5 30";
	} else if(%randnumber == 10) {
		%grenadeposition = "10 10 40";
	} else if(%randnumber == 11) {
		%grenadeposition = "-10 0 50";
	} else if(%randnumber == 12) {
		%grenadeposition = "-5 0 80";
	} else if(%randnumber == 13) {
		%grenadeposition = "0 5 40";
	} else if(%randnumber == 14) {
		%grenadeposition = "5 0 50";
	} else if(%randnumber == 15) {
		%grenadeposition = "10 15 30";
	} else if(%randnumber == 16) {
		%grenadeposition = "5 5 40";
	} else {
		%grenadeposition = "10 10 50";
	}
	%newpos = Vector::add(%grenadeposition, %pos);
	%shooterClient = $painter;
	%player = Client::getOwnedObject(%shooterClient);
	%object = newObject("","Mine",%grenadetype);
	addToSet("MissionCleanup", %object);
	GameBase::throw(%object,%player,1,false);
	GameBase::SetPosition(%object, %newpos);
}

function StartSortie(%pos){
	%bomb1 = "Concussion";
	%bomb2 = "Firebomb";
	%bomb3 = "Handgrenade";
	%bomb4 = "EMPgrenade";
	%bomb5 = "MortarBomb";
	%bomb6 = "Suicidebomb";
	%npos = Vector::add(%pos, "0 0 -30");

	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 6);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 7);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 8);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 8.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 9);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 9.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 10);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 10.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 11);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 11.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 12);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 12.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 13);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 13.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 14.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 15);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 15.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 17);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 18);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 18.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 19);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 19.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 20);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 20.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 21);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 21.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 22);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 22.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 23);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 23.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 24.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 25);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 25.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 26);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 6);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 7);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 8);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 8.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 9);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 9.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 10);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 10.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 11);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 11.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 12);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 12.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 13);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 13.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 14.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 15);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 15.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 17);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 18);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 18.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 19);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 19.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 20);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 20.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 21);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 21.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 22);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 22.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 23);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 23.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 24.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 25);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 25.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 26);
	schedule("Sortie('" @ %bomb6 @ "','" @ %npos @ "');", 23);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 7);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 8);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 8.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 9);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 9.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 10);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 10.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 11);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 11.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 12);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 12.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 13);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 13.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 14.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 15);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 15.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 16);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 17);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 18);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 18.5);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 19);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 19.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 20);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 20.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 21);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 21.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 22);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 22.5);
	schedule("Sortie('" @ %bomb4 @ "','" @ %pos @ "');", 23);
	schedule("Sortie('" @ %bomb1 @ "','" @ %pos @ "');", 23.5);
	schedule("Sortie('" @ %bomb2 @ "','" @ %pos @ "');", 24.5);
	schedule("Sortie('" @ %bomb3 @ "','" @ %pos @ "');", 25);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 25.5);
	schedule("Sortie('" @ %bomb5 @ "','" @ %pos @ "');", 26);
}

SeekingMissileData HoverMine
{
  	bulletShapeName = "mortar.dts";//sensor_small.dts
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.6;
	damageType = $MineDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 20.0;
	muzzleVelocity = 20.0;
	terminalVelocity = 515.0;
	acceleration = 100.0;
	totalTime = 84.0;
	liveTime = 220.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 1.0;
	nonSeekingTurningRadius = 1.1;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };

	trailType   = 1;
	trailLength = 10;
	trailWidth  = 0.10;

	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

//==========================Translocator
GrenadeData TransShell
{
   bulletShapeName    = "dirArrows.dts";
   explosionTag       = vehiclesmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 650;
   collisionRadius    = 2.5;
   mass               = 1.0;
   elasticity         = 0.15;
   damageClass        = 1;
   damageValue        = 0.01;
   damageType         = $MortarDamageType;
   explosionRadius    = 1.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 260;
   totalTime          = 60.0;
   liveTime           = 4.0;
   projSpecialTime    = 0.1;
   inheritedVelocityScale = 0.5;
   smokeName		= "chainspk.dts";
	soundId = SoundFireTargetingLaser;
};

RocketData AirFuserRiser
{
	bulletShapeName = "mortar_turret.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 15;
	kickBackStrength = 80;
	muzzleVelocity   = 10.0;
	terminalVelocity = 15.0;
	acceleration     = 5.0;
	totalTime        = 7;
	liveTime         = 7;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 35;
	trailWidth  = 0.40;
	soundId = SoundJetHeavy;
	rotationPeriod = 1.5;
};

RocketData AirBaseRiser
{
	bulletShapeName = "dsply_v1.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 15;
	kickBackStrength = 80;
	muzzleVelocity   = 10.0;
	terminalVelocity = 15.0;
	acceleration     = 5.0;
	totalTime        = 7;
	liveTime         = 7;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 35;
	trailWidth  = 0.40;
	soundId = SoundJetHeavy;
	rotationPeriod = 1.5;
};

RocketData JailRiser
{
	bulletShapeName = "dsply_s1.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 15;
	kickBackStrength = 80;
	muzzleVelocity   = 10.0;
	terminalVelocity = 15.0;
	acceleration     = 5.0;
	totalTime        = 7;
	liveTime         = 7;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 35;
	trailWidth  = 0.40;
	soundId = SoundJetHeavy;
	rotationPeriod = 1.5;
};

//====================================== Pigment

MineData Pigment
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Pigment";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = bulletExpS;
	explosionRadius = 1.0;
	damageValue = 0;
	//damageType = $MortarDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.1;
	maxDamage = 3.0;
};
function Pigment::onCollision(%this,%obj)
{
    	if(getObjectType(%obj) == "Player")
	{
	    	if(!Player::isDead(%obj))
		{
			%cl = Player::getClient(%obj);
			%client = this.deployer;
			if (GameBase::getTeam(%obj)!=GameBase::getTeam(%this)) GameBase::applyDamage(%obj, $PaintType, 0.1, "0 0 0", "0 0 0", "0 0 0", %client);
			else GameBase::applyDamage(%obj, $PaintType, 0.1, "0 0 0", "0 0 0", "0 0 0",%cl);
			systemMessage(%cl, 0, "~wButton4.wav");
		}
	}
}
function Pigment::onAdd(%this) {}
function Pigment::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Pigment"]--;
}