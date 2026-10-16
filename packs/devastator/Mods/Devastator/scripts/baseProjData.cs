# Damage Types
#
$ImpactDamageType        = -1;
$LandingDamageType       =  0;
$BulletDamageType        =  1;
$EnergyDamageType        =  2;
$PlasmaDamageType        =  3;
$ExplosionDamageType     =  4;
$ShrapnelDamageType      =  5;
$LaserDamageType         =  6;
$MortarDamageType        =  7;
$BlasterDamageType       =  8;
$ElectricityDamageType   =  9;
$CrushDamageType         = 10;
$DebrisDamageType        = 11;
$MissileDamageType       = 12;
$MineDamageType          = 13;
$SBulletDamageType       = 14;
$PBulletDamageType       = 15;
$FreezeDamageType        = 16;
$SniperDamageType        = 17;
$MiniDamageType          = 18;
$FlashDamageType         = 19;
$FunkDamageType          = 20;
$ConfettiDamageType      = 21;
$TargetDamageType        = 22;
$ProtonDamageType        = 23;
$MesonDamageType         = 24;
$SmokeDamageType         = 25;
$AssaultDamageType       = 26;
$BeamDamageType          = 27;
$BulletTDamageType       = 28;
$FlagDamageType          = 29;
$NukeDamageType	         = 30;
$BeamDamageType          = 31;
$ViralDamageType         = 32;
$FlameDamageType         = 33;
$PsychoDamageType        = 34;
$SwordDamageType         = 35;
$MultiDamageType         = 36;
$LPDamageType            = 37;
$RicochetDamageType      = 38;
$ShockDamageType         = 39;
$GuardDamageType         = 40;
$PlasCDamageType         = 41;
$BoomDamageType          = 42;
$HGDamageType            = 43;
$PCDamageType            = 44;
$GodBootDamageType       = 45;
$RocketDamageType        = 46;
$TazerDamageType         = 47;
$B52GunnerDamageType     = 48;
$BomberDamageType        = 49;
$BigBomberDamageType     = 50;
$Plasma2DamageType       = 51;
$AcidDamageType          = 52;
$EvilPongDamageType      = 53;
$BeerDamageType          = 54;
$CarWreck                = 55;
$GODDamageType           = 56;
$BulletVDamageType       = 57;
$SynDamageType           = 58;
$AAMineDamageType        = 59;
$ServerDamageType        = 60;
$MGBurnDamageType        = 61;
$BoomDamageType          = 62;
$MineSweeperDamageType   = 63;
$PushDamageType          = 64;
$PullDamageType          = 65;
$FragDamageType          = 66;
$KamiRocketDamageType    = 67;
$KamikazeDamageType      = 68;
$KamiDiveDamageType      = 69;
$FalconMissileDamageType = 70;
$FalconShockDamageType   = 71;
$FalconRocketDamageType  = 72;
$FalconGrenadeDamageType = 73;
$SigFlareDamageType      = 74;
$MinePodDamageType       = 75;
$FlareDamageType         = 76;
$StingerADamageType      = 77;
$StingerBDamageType      = 78;
$ParaBombDamageType      = 79;
$KamikazeSDamageType     = 80;
$KamiKazeKDamageType     = 81;
$KamiDetDamageType       = 82;
$CrazySpikeDamageType    = 83;
$RemoteDetDamageType     = 84;
//$NewDamageType      = 85;
//$NewDamageType      = 86;
//$NewDamageType      = 87;
//$NewDamageType      = 88;
//$NewDamageType      = 89;
//$NewDamageType      = 90;

$ProjectileType[ShieldBlast] = Special;
$ProjectileType[ShellCasing] = Special;
$ProjectileType[MGSmoke]     = Special;
$ProjectileType[WorkSmoke]   = Special;
$ProjectileType[Ricochet]    = Special;
$ProjectileType[Pong]        = Special;
$ProjectileType[EvilPong]    = Special;
$ProjectileType[FragFlech]            = Bullet;
$ProjectileType[Shotgun1bullet]       = Bullet;
$ProjectileType[ChaingunBullet2]      = Bullet;
$ProjectileType[PistolBullet]         = Bullet;
$ProjectileType[AssaultBullet]        = Bullet;
$ProjectileType[AssaultBullet2]       = Bullet;
$ProjectileType[AssaultTurretBullet]  = Bullet;
$ProjectileType[AssaultVehicleBullet] = Bullet;
$ProjectileType[CrazySpike]           = Bullet;
$ProjectileType[SniperRocket]         = Bullet;
$ProjectileType[SniperBullet]         = Bullet;
$ProjectileType[AdvDiscShot] = Disc;
$ProjectileType[DiscShell]   = Disc;
$ProjectileType[DiscShell2]  = Disc;
$ProjectileType[DiscShell3]  = Disc;
$ProjectileType[MiniFusionBolt] = Energy;
$ProjectileType[MShot1]         = Energy;
$ProjectileType[MShot2]         = Energy;
$ProjectileType[MShot3]         = Energy;
$ProjectileType[BlasterBolt]    = Energy;
$ProjectileType[BlasterBolt2]   = Energy;
$ProjectileType[BlasterBolt3]   = Energy;
$ProjectileType[confetti]       = Energy;
$ProjectileType[confetti2]      = Energy;
$ProjectileType[confetti3]      = Energy;
$ProjectileType[FusionBolt]     = Energy;
$ProjectileType[liquidnitrogen] = Matter;
$ProjectileType[acid]           = Matter;
$ProjectileType[Flames]         = Matter;
$ProjectileType[decoyLaser]   = Laser;
$ProjectileType[TurretLaser]  = Laser;
$ProjectileType[TurretLaser2] = Laser;
$ProjectileType[pistolLaser]  = Laser;
$ProjectileType[FlashBeam]    = Laser;
$ProjectileType[FlashBeam2]   = Laser;
$ProjectileType[LaserPointer] = Laser;
$ProjectileType[targetLaser]  = Laser;
$ProjectileType[Laser1]       = Laser;
$ProjectileType[BeamLaser]    = Laser;

$LaserDmg[decoyLaser]   = 0.0;
$LaserDmg[TurretLaser]  = 0.1;
$LaserDmg[TurretLaser2] = 0.3;
$LaserDmg[pistolLaser]  = 0.1;
$LaserDmg[FlashBeam]    = 0.0;
$LaserDmg[FlashBeam2]   = 0.0;
$LaserDmg[LaserPointer] = 0.0;
$LaserDmg[targetLaser]  = 0.0;
$LaserDmg[Laser1]       = 0.0;
$LaserDmg[BeamLaser]    = 0.5;

//--------------------------------//
// Projectile's Object Types: //    
//--------------------------------//
//-Bullet	= "Bullet"
//-Rocket	= "RocketDumb"
//-Grenade	= "Grenade"
//-SeekerRocket	= "SeekingRocket"
//-NormalLaser	= "LaserProjectile"
//-TargetLaser	= "TargetLaser"
//-Lightning	= "Lightning"
//-RepairBolt	= "RepairEffect"
//--------------------------------------

GrenadeData ShieldBlast
{
   bulletShapeName    = "Shield.dts";
   explosionTag       = ShieldExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = -0.5;
   smokeName              = "Shield.dts";
};

//--------------------------------------
GrenadeData ShellCasing
{
   bulletShapeName    = "force.dts";
   explosionTag       = CasingExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 5.0;
   totalTime          = 0.75;
   liveTime           = 0.75;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "breath.dts";
};

//--------------------------------------
GrenadeData MGSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = BreathExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = -0.5;
   smokeName              = "breath.dts";
};

//--------------------------------------
GrenadeData WorkSmoke
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = -0.5;
   smokeName              = "rsmoke.dts";
};

//--------------------------------------

BulletData Ricochet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $RicochetDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------

BulletData FragFlech
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $FragDamageType;

   aimDeflection      = 1.0;
   muzzleVelocity     = 400.0;
   totalTime          = 5.5;
   inheritedVelocityScale = 2.5;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

//--------------------------------------

BulletData EvilPong
{
	bulletShapeName    = "discb.dts";
	explosionTag       = breathexp;
	mass               = 0.09;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0;
	damageType         = $EvilPongDamageType;
	aimDeflection      = 0.002;
	muzzleVelocity     = 10.0;
	totalTime          = 30.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
};

BulletData Pong
{
	bulletShapeName    = "discb.dts";
	explosionTag       = breathexp;
	mass               = 0.09;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0;
	damageType         = $RicochetDamageType;
	aimDeflection      = 0.002;
	muzzleVelocity     = 10.0;
	totalTime          = 30.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
};

function Pong::onAdd(%this)
{
	%type = getObjectType(%this);
	echo(%this@" added, "@%type@", GOD PONG!");
}

function Pong::onRemove(%this)
{
	%target = %this.target;
	Bottomprint(Player::getClient(%target),"<jc><f4>YOU MISSED!");
}
//==========================

BulletData Shotgun1bullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; 
	damageValue = 0.09;
	damageType = $SBulletDamageType;
	aimDeflection = 0.01;
	muzzleVelocity = 425.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData ChaingunBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $MiniDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData PistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $PBulletDamageType;

   aimDeflection      = 0.0005;
   muzzleVelocity     = 425.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
RocketData FunkBlast
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = FunkBoom;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $FunkDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 2;

   rotationPeriod = 50;
   soundId = SoundDiscSpin;
};

//--------------------------------------
BulletData AssaultBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $AssaultDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData AssaultBullet2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisEXPsmall;
   mass               = 0.01;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $AssaultDamageType;

   explosionRadius    = 3;
   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 2.5;
   inheritedVelocityScale = 1.2;
   isVisible          = True;
};

//--------------------------------------
BulletData AssaultTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.10;
   damageType         = $BulletTDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 425.0;
   totalTime          = 2.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------

RocketData FusionBolt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $PCDamageType;

   explosionRadius  = 4.5;
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
   trailString = "fusionbolt.dts";
   smokeDist   = 20.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = energyexp;

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

//--------------------------------------

BulletData MShot1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterexp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.12;
   damageType         = $MesonDamageType;

   aimDeflection      = 0.009;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

};

//--------------------------------------
BulletData MShot2
{
   bulletShapeName    = "paint.dts";
   explosionTag       = mortartrailExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.12;
   damageType         = $MesonDamageType;

   aimDeflection      = 0.009;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

};

//--------------------------------------
BulletData MShot3
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyexp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.12;
   damageType         = $MesonDamageType;

   aimDeflection      = 0.009;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

};

//--------------------------------------
BulletData BlasterBolt
{
	bulletShapeName    = "shotgunbolt.dts";
	explosionTag       = blasterExp;
	mass               = 1.0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.2;
	damageType         = $BlasterDamageType;
	muzzleVelocity     = 200.0;
	liveTime           = 1.125;
	totalTime          = 2.0;
	lightRange         = 3.0;
	lightColor         = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible          = True;
	rotationPeriod = 1;
};

//--------------------------------------
RocketData BlasterBolt2
{
   bulletShapeName  = "ShotgunBolt.dts";
   explosionTag     = PlasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $BlasterDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 200.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 11.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "laserhit.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData BlasterBolt3
{
   bulletShapeName  = "ShotgunBolt.dts";
   explosionTag     = flashExpLarge;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.38;
   damageType       = $BlasterDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 9.0;
   totalTime        = 2.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "shotgunex.dts";
   smokeDist   = 0.2;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData PlasmaBolt
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 0.01;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 0.5;
   liveTime         = 1.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

      // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 0.2;

   soundId = SoundDiscSpin;
};

//----------------------

BulletData liquidnitrogen
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = turretExp;

   damageClass        = 1;
   damageValue        = 0.0;
   damageType         = $FreezeDamageType;
   explosionRadius    = 3.0;

   muzzleVelocity     = 55.0;
   totalTime          = 0.5;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = freezeExplosion;
};

//----------------------

BulletData acid
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = debrisExpsmall;

   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $AcidDamageType;
   explosionRadius    = 4.0;

   aimDeflection      = 0.005;
   muzzleVelocity     = 55.0;
   totalTime          = 1.0;
   liveTime           = 3.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = freezeExplosion;
};

//--------------------------------------
RocketData MiniPlasmaBolt
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = debrisexpsmall;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $Plasma2DamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "plasmatrail.dts";
   smokeDist   = 0.3;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData AdvDiscShot
{
   bulletShapeName = "discb.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 9.0;
   kickBackStrength = 180.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 280.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

      // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.2;

   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = debrisExpLarge;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
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

//--------------------------------------
RocketData DiscShell2
{
   bulletShapeName = "discb.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 280.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

      // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.2;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData DiscShell3
{
   bulletShapeName    = "discb.dts";
   explosionTag       = DebrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.55;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

//--------------------------------------

GrenadeData confetti
{
   bulletShapeName    = "enex.dts";
   explosionTag       = energyExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ConfettiDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 10;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";
};

//--------------------------------------
GrenadeData confetti2
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = blasterExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ConfettiDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 12.5;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";
};

//--------------------------------------

GrenadeData confetti3
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ConfettiDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 15;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "paint.dts";
};

//--------------------------------------

GrenadeData BoosterBlast
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = energyExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $RocketDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};

//--------------------------------------

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "paint.dts";
};

//--------------------------------------

GrenadeData AdvGrenShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = DebrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 17;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";
};

//======================================================

GrenadeData PushShell
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = DCExplosion;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       
   damageValue        = 0.0;
   damageType         = $PushDamageType;

   explosionRadius    = 55.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 290;
   totalTime          = 40.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Shockwave.dts";
};

//--------------------------------------
GrenadeData SpecialShell
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = MineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PullDamageType;

   explosionRadius    = 90.0;
   kickBackStrength   = -1000.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortarex.dts";
};

//--------------------------------------------//
//-Next Project, make flares into REAL flares-//
//--------------------------------------------//
GrenadeData FlareShell
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $SigFlareDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Laserhit.dts";
};

function FlareShell::onAdd(%this)
{
	Flare::Fizzle(%this,"FlareFizzleSmall");
}

GrenadeData FlareShellMed
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $SigFlareDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

function FlareShellMed::onAdd(%this)
{
	Flare::Fizzle(%this,"FlareFizzleMed");
}

GrenadeData FlareShellLarge
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $SigFlareDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

function FlareShellLarge::onAdd(%this)
{
	Flare::Fizzle(%this,"FlareFizzleLarge");
}
//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "grenade.dts";
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
   smokeName              = "rsmoke.dts";
};

//--------------------------------------//
//VEHICLE WEAPONS SECTION, DO NOT MODIFY//
//--------------------------------------//
RocketData Missile
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = KamiExplosion;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $FalconMissileDamageType;

   explosionRadius  = 20;
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
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = DebrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $FalconRocketDamageType;

   explosionRadius  = 15;
   kickBackStrength = 200.0;
   muzzleVelocity   = 70.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 1.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData SideWind
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = DebrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $SideWinderDamageType;

   explosionRadius  = 15;
   kickBackStrength = 200.0;
   muzzleVelocity   = 0.0;
   terminalVelocity = 0.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 1.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ShockRocket
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = turretExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $FalconShockDamageType;

   explosionRadius  = 12;
   kickBackStrength = 100.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 0.1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData AssaultVehicleBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletVDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 600.0;
   totalTime          = 1.2;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 40;
};

//--------------------------------------
BulletData CrazySpike
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $CrazySpikeDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 400.0;
   totalTime          = 1.2;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 40;
};

//--------------------------------------
GrenadeData KamikazeBlast
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       
   damageValue        = 0.7;
   damageType         = $KamiRocketDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 250;
   totalTime          = 5.0;
   liveTime           = 0.6;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmaex.dts";
};

//--------------------------------------
GrenadeData KamikazeDetonate
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       
   damageValue        = 2.0;
   damageType         = $KamiDetDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionex.dts";
};

//--------------------------------------
GrenadeData RemoteDetonate
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       
   damageValue        = 1.0;
   damageType         = $RemoteDetDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmaex.dts";
};

//--------------------------------------
GrenadeData FalconGrenade
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $FalconGrenadeDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
};

//--------------------------------------
GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.2;
   damageType         = $BomberDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 0;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData DevShell
{
   bulletShapeName    = "liqcyl.dts";
   explosionTag       = KamiExplosion;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.8;
   damageType         = $BigBomberDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "plasmatrail.dts";
};

//--------------------------------------
GrenadeData MinePod
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = breathExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $MinePodDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 0;
   totalTime          = 30.0;
   liveTime           = 30.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "rsmoke.dts";
};

function MinePod::onAdd(%this)
{
	GroundCheck(%this,30);
}

//--------------------------------------
GrenadeData FlareDrop
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = KamiExplosion;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $FlareDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.1;
   smokeName              = "shotgunex.dts";
};

GrenadeData FlareFizzleSmall
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = blasterExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $FlareDamageType;

   explosionRadius    = 1.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData FlareFizzleMed
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = blasterExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $FlareDamageType;

   explosionRadius    = 1.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData FlareFizzleLarge
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = blasterExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $FlareDamageType;

   explosionRadius    = 1.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 0.1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

function FlareDrop::onAdd(%this)
{
	Flare::Fizzle(%this,"FlareFizzleLarge");
}

function Flare::Fizzle(%this,%type)
{
	%pos = GameBase::getPosition(%this);
	%rot  = GameBase::getRotation(%this);
	%vel  = Item::getVelocity(%this);
	for(%i = -3.141592654; %i <= 3.141592654; %i += 1.570796327) {
		%NewRot = Vector::Add(%rot,"0 0 "@%i);
		%NewVec = Vector::getFromRot(%NewRot,10);
		%trans = %rot@" "@%NewVec@" "@%rot@" "@%pos;
		Projectile::spawnProjectile(%type,%trans,2048,%vel);
	}
	schedule("Flare::Fizzle("@%this@","@%type@");",0.5,%this);
}

//--------------------------------------
SeekingMissileData StingerRocketA
{
	bulletShapeName  = "rocket.dts";
	explosionTag     = FRExp;
	collisionRadius  = 0.0;
	mass             = 9.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.0;
	damageType       = $StingerADamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 250.0;
	muzzleVelocity   = 65.0;
	terminalVelocity = 85.0;
	acceleration     = 10.0;
	totalTime        = 7.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius    = 1.5;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 0.1;
	lightRange       = 5.0;
	lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.01;
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData StingerRocketB
{
	bulletShapeName  = "rocket.dts";
	explosionTag     = FRExp;
	collisionRadius  = 0.0;
	mass             = 9.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.9;
	damageType       = $StingerBDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 250.0;
	muzzleVelocity   = 65.0;
	terminalVelocity = 85.0;
	acceleration     = 10.0;
	totalTime        = 7.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius    = 1.5;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 2.5;
	smokeDist               = 0.1;
	lightRange       = 5.0;
	lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.01;
	smokeName              = "paint.dts";
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData ParaBomb
{
	bulletShapeName  = "rocket.dts";
	explosionTag     = FRExp;
	collisionRadius  = 0.0;
	mass             = 9.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.9;
	damageType       = $ParaBombDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 250.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 10.0;
	acceleration     = 0.0;
	totalTime        = 7.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius    = 1.5;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 0.01;
	lightRange       = 20.0;
	lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.1;
	smokeName              = "shield.dts";
	soundId = SoundJetHeavy;
};

//---------------------------//
//VEHICLE WEAPONS SECTION END//
//---------------------------//

RocketData MortarRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType       = $MissileDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 25.0;
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
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "discb.dts";
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
   smokeName              = "plasmaex.dts";
};

//--------------------------------------
RocketData FireRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = FRExp;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $RocketDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData RocketLauncherSeeker
{
	bulletShapeName  = "rocket.dts";
	explosionTag     = FRExp;
	collisionRadius  = 0.0;
	mass             = 9.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.9;
	damageType       = $RocketDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 250.0;
	muzzleVelocity   = 85.0;
	terminalVelocity = 100.0;
	acceleration     = 10.0;
	totalTime        = 7.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius    = 1.5;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 1;
	lightRange       = 5.0;
	lightColor       = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.01;
	soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = grenadeExp;
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
   smokeDist         = 20;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	//-Ice's Seeker Counter-Measures Code
	if(%target.counterMeasures)
		%target = %target.counterMeasures;
	//-End Ice's Seeker Counter-Measures Code
	return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData decoyLaser
{
   laserBitmapName   = "LaserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData TurretLaser2
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.03;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData TurretLaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData pistolLaser
{
   laserBitmapName   = "wes05.bmp";
   hitName           = "fusionbolt.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LPDamageType;

   beamTime          = 1.5;

   lightRange        = 2.0;
   lightColor        = { 0.0, 0.0, 1.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData FlashBeam2
{
   laserBitmapName   = "smoke01.bmp";
   damageConversion  = 0;
   baseDamageType    = $FlashDamageType;

//   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1, 1, 1 };

   detachFromShooter = false;
};

LaserData FlashBeam
{
	laserBitmapName   = "smoke01.bmp";
	damageConversion  = 0.0;
	baseDamageType    = $FlashDamageType;
	beamTime          = 0.5;
	lightRange        = 4.0;
	lightColor        = { 0, 0, 0 };

	detachFromShooter = false;
};

TargetLaserData LaserPointer
{
   laserBitmapName   = "laserpulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "lightningTemp.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 200.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 900.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.225;//.075;

   updateTime   = 120;
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

//=======================
RepairEffectData RepairBolt
{
   bitmapName       = "eflsh5.bmp";
   boltLength       = 5.0;
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
			%player.repairRate = 0.05;
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
		%player.repairRate   = 0.1;
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
	if(Player::isTriggered(%player,$WeaponSlot) && 
		Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if(%object == %player) {
			if(GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if(GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//=======================
RepairEffectData ToolBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 4.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function ToolBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairTarget = %target;
	if(getObjectType(%target) == "Player")
		return false;
	if(getObjectType(%player.repairTarget) != "Player") {
		%player.repairRate = 0.40;
		%name = GameBase::getMapName(%target);
		if(%name == "")
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		echo(GameBase::getDamageLevel(%player.repairTarget));
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) {
			echo("?");
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return false;
		}
	}
	Client::sendMessage(%client,0,"Fixing "@%name);
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function ToolBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	%name = GameBase::getMapName(%object);
	if(getObjectType(%object) == "Player")
		return false;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(getObjectType(%object) != "Player") {
			if(GameBase::getDamageLevel(%object) == 0)
				Client::sendMessage(%client,0,"Fixing "@%name@" Completed");
			else
				Client::sendMessage(%client,0,"Fixing "@%name@" Aborted");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function ToolBolt::checkDone(%this,%player)
{
	if(getObjectType(%player.repairTarget) == "Player")
		return false;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == TB && %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if(getObjectType(%object) != "Player" && GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
	}
}