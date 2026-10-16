# Damage Types
#
$ImpactDamageType	= -1;
$LandingDamageType	=  0;
$BulletDamageType	=  1;
$EnergyDamageType	=  2;
$PlasmaDamageType	=  3;
$ExplosionDamageType	=  4;
$ShrapnelDamageType	=  5;
$LaserDamageType	=  6;
$MortarDamageType	=  7;
$BlasterDamageType	=  8;
$ElectricityDamageType	=  9;
$CrushDamageType	= 10;
$DebrisDamageType	= 11;
$MissileDamageType	= 12;
$MineDamageType		= 13;
$NeutralDamageType	= 14;
$EMPDamageType		= 15;
$NukeGrenadeDamageType	= 16;
$SniperDamageType	= 17;
$SniperHeadShot		= 18; //Sniper rifle head shot damage type. For messages only
$AAMissileDamageType	= 19;
$ShellDamageType	= 20;

$DamageDesc[-2] = "Suicide Damage";
$DamageDesc[-1] = "Impact Damage";
$DamageDesc[0] = "Landing Damage";
$DamageDesc[1] = "Bullet Damage";
$DamageDesc[2] = "Energy Damage";
$DamageDesc[3] = "Plasma Damage";
$DamageDesc[4] = "Explosion Damage";
$DamageDesc[5] = "Shrapnel Damage";
$DamageDesc[6] = "Laser Damage";
$DamageDesc[7] = "Mortar Damage";
$DamageDesc[8] = "Blaster Damage";
$DamageDesc[9] = "Electricity Damage";
$DamageDesc[10] = "Crush Damage";
$DamageDesc[11] = "Debris Damage";
$DamageDesc[12] = "Missile Damage";
$DamageDesc[13] = "Mine Damage";
$DamageDesc[14] = "Neutral Damage";
$DamageDesc[15] = "EMP Damage";
$DamageDesc[16] = "Nuke Damage";
$DamageDesc[17] = "Sniper Damage";
$DamageDesc[18] = "Sniper Headshot Damage";
$DamageDesc[19] = "Anti-air Missile Damage";
$DamageDesc[20] = "Shotgun Damage";

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData StrafeBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.09;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 450.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 20;
};

//--------------------------------------

RocketData SniperBullet
{
   bulletShapeName = "breath.dts";
   explosionTag = sniperbulletExp;
   mass = 2.0;
   collisionRadius = 0.0;

   damageClass = 0;
   damageValue = 0.45;
   damageType = $SniperDamageType;

   explosionRadius = 0.001;
   kickBackStrength = 100.0;
   muzzleVelocity = 2250.0;
   terminalVelocity = 2750.0;
   acceleration = 10.0;
   totalTime = 10.0;
   liveTime = 11.0;
   lightRange = 5.0;
   lightColor = { 1, 0.25, 0.5 };
   inheritedVelocityScale = 1.0;
   soundId = SoundJetHeavy;
};

//--------------------------------------

BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.035;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 1500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 60;
};

//--------------------------------------
BulletData ShotgunBlast 
{
   bulletShapeName 	= "tracer.dts";
   explosionTag 	= ShotExp;
   mass 		= 0.05;
   bulletHoleIndex 	= 0;
   kickBackStrength 	= 300.0;

   damageClass 		= 0;
   damageValue 		= 0.03;
   damageType 		= $ShellDamageType;

   aimDeflection 	= 0.029;
   muzzleVelocity 	= 400.0;
   acceleration 	= 5.0;
   totalTime 		= 0.5;
   inheritedVelocityScale = 1.0;
   isVisible 		= False;

   tracerPercentage 	= 1.0;
   tracerLength 	= 30;
};

//--------------------------------------

BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.125;
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
   damageValue        = 0.07;
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
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.025;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.335;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.75;

   muzzleVelocity     = 65.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   lightRange         = 6.0;
   lightColor         = { 0, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------

BulletData FlamerBolt
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $PlasmaDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 30.0;
  totalTime = 0.75;
  liveTime = 0.75;
  lightRange = 3.0;
  lightColor =
  {
    1, 1, 0
  };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

//--------------------------------------

RocketData IonBolt
{
  bulletShapeName = "enbolt.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.20;
  damageType = $ElectricityDamageType;
  explosionRadius = 2.5;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 11.0;
  lightRange = 5.0;
  lightColor =
  {
    0.5, 1.5, 0.7
  };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 50;
  trailWidth = 0.3;
  soundId = SoundJetHeavy;
};



//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 4.5;
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

//--------------------------------------

GrenadeData EMPGrenadeShell
{
  bulletShapeName = "mortar.dts";
  explosionTag = EMPPulseExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 1.0;
  elasticity = 0.45;
  damageClass = 1;
  damageValue = 0.01;
  damageType = $EMPDamageType;
  explosionRadius = 40;
  kickBackStrength = -50.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 0.25;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "fusionbolt.dts";
  soundId = SoundELFFire;
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
   damageValue        = 0.8;
   damageType         = $MortarDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
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

   explosionRadius    = 20.0;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------//
//--------------------------------------//
//--------------------------------------//
//---------Aircraft Projectiles---------//
//--------------------------------------//
//--------------------------------------//
//--------------------------------------//

BulletData JetBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData JetBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 60;
};

//--------------------------------------
RocketData JetFusionBolt
{
   bulletShapeName  = "enbolt.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.20;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 165.0;
   terminalVelocity = 180.0;
   acceleration     = 8.0;
   totalTime        = 20.0;
   liveTime         = 21.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ScoutRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.175;
   damageType       = $MissileDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 165.0;
   terminalVelocity = 180.0;
   acceleration     = 8.0;
   totalTime        = 20.0;
   liveTime         = 21.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.375;
   damageType       = $MissileDamageType;

   explosionRadius  = 7.125;
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
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

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
   damageType       = $AAMissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 9.0;
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

//--------------------------------------


GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.01;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.75;
   damageType         = $MortarDamageType;

   explosionRadius    = 4;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 150;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ " , 5);",1.0,%this);
}

function DeployBomblets(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomblet1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,false);
		
		%obj = newObject("","Mine","Bomblet2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10,false);
		%obj = newObject("","Mine","Bomblet3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
		%count -= 1;
		schedule("DeployBomblets(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}


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
   damageValue        = 1.7;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.9;
    smokeName              = "plasmatrail.dts";
//=-=-=-=-=-=

 
  
};

function FgcShell::onAdd(%this)
{
	schedule("DeployNukes(" @ %this @ " , 5);",2.0,%this);
}

function DeployNukes(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Nuke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		
		%obj = newObject("","Mine","Nuke2");
	 		
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%obj = newObject("","Mine","Nuke3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployNukes(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

//--------------------------------------

RocketData Nuke
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mineexp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $MissileDamageType;

   explosionRadius  = 6.5;
   kickBackStrength = 425.0;
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
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

RocketData RailRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $SniperDamageType;

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
   isVisible        = true;
   smokeName   = "mortartrail.dts";
   smokeDist   = 200;
   soundId = SoundJetHeavy;

};




//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData DissectionLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.151;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0075;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData DeathLaserBeam
{
  laserBitmapName = "laserPulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.0075;
  baseDamageType = $LaserDamageType;
  beamTime = 0.4;
//  lightRange = 4.0;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = true;
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
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.10;
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

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
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
		%player.repairRate   = 0.175;
		if((Player::getArmor(%player) == "marmor")) %player.repairRate = 0.35;
		
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
	%client = Player::getClient(%player);


	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
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

					if (%objname == "Large Pulse Sensor")		%bonus = 1;
					else if (%objname == "Medium Pulse Sensor")	%bonus = 1;
					else if (%objname == "Generator")		%bonus = 2;
					else if (%objname == "Solar Panel")		%bonus = 1;
					else if (%objname == "Portable Generator")	%bonus = 1;		
					else if (%objname == "Station Supply Unit")	%bonus = 1;
					else if (%objname == "Vehicle Pad")		%bonus = 1;					
					else %bonus = 0;
//					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
//					%score = ($Score::RepairObject + %bonus);
					%score = %bonus;
					%lastdamage = $lastdamageobj[%object];
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "") 
						%objname = (GameBase::getDataName(%object)).description;					

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								bottomprint(%client, "No points awarded, you were the last damager.");						
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								%client.repairs = (%client.repairs - %score);
								bottomprint(%client, "You repaired the enemy's stuff. -" @ %score @ " points");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{

								if (getObjectType(%object.LastDamageObject) == "Net::PacketStream")
								{
									%client.score = (%client.score + %score);
									%client.repairs = (%client.repairs + %score);
									bottomprint(%client, "Repairing Damage Score: +" @ %score @ " points.");
								}
								else 
								{
									bottomprint(%client, "No points awarded, last damaged by debris.");
								}

							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							%client.repairs = (%client.repairs - %score);
							bottomprint(%client, "You repaired the enemy's stuff. -" @ %score @ " points");
						}
						else
						{
							if (getObjectType(%object.LastDamageObject) == "Net::PacketStream")
							{
								%client.score = (%client.score + %score);
								%client.repairs = (%client.repairs + %score);
								bottomprint(%client, "Repairing Damage Score: +" @ %score @ " points.");
							}
							else bottomprint(%client, "No points awarded, last damaged by debris.");
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
