// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

$ImpactDamageType      = -1;
$LandingDamageType     =  0;
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
$BeamOfPainDamageType  = 19;
$FlashDamageType       = 20;
$WebDamageType         = 21;
// ==================================================================

BulletData PTDeb
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $DebrisDamageType;
   explosionRadius    = 5.0;
   aimDeflection      = 3.0;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};
//-----------------------------
BulletData ELECDeb
{
   bulletShapeName    = "enex.dts";
   explosionTag       = ELECDExp;
   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $DebrisDamageType;
   explosionRadius    = 5.0;
   aimDeflection      = 3.0;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData MiscDeb
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = MiscDebExp;
   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $DebrisDamageType;
   explosionRadius    = 5.0;
   aimDeflection      = 3.0;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData RTDeb 
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   aimDeflection      = 3.0;
   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

GrenadeData ClusterShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;       
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;   
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

// =================================================================
//  P S I O N I C S  Recoded By: Armageddon  
// =================================================================

RocketData solarBurst1
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = grenadeExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  baseDamageType = $ShrapnelDamageType;
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
  baseDamageType = $ShrapnelDamageType;
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
  damageType = $ShrapnelDamageType;
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

// ==============================
// New LairWaster By: Armageddon
// ==============================
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
   inheritedVelocityScale = 0.5;
soundId = SoundELFFire;
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
soundId = SoundELFFire;
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
soundId = SoundELFFire;
   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

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


BulletData SpellAbilityProj1
{
   bulletShapeName    = "lfemale.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 100;
   damageType         = $BulletDamageType;
   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   isVisible          = true;
};

BulletData SpellAbilityProj2
{
   bulletShapeName    = "larmor.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 100;
   damageType         = $BulletDamageType;
   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   isVisible          = true;
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

BulletData ChainGunBullet
{
   bulletShapeName    = "shotgunbolt.dts";
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
   isVisible          = false;
   tracerPercentage   = 100;
   tracerLength       = 30;
};

BulletData LiLPOOmkiBullet
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
   damageValue        = 2;
   damageType         = $BulletDamageType;
   muzzleVelocity     = 20000;
   acceleration     = 5.0;
   totalTime          = 1;
   isVisible          = true;
   inheritedVelocityScale = 1;
};

BulletData LiLPOOmkiiBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;      
   damageValue        = 2;
   damageType         = $LiLPOOmkiiDamageType;
   muzzleVelocity     = 20000;
   acceleration     = 5.0;
   totalTime          = 1;
   inheritedVelocityScale = 1;
   isVisible          = true;
};

BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   damageClass        = 0;      
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;
   muzzleVelocity     = 500.0;
   totalTime          = 2;
   liveTime           = 1;
   isVisible          = True;
   rotationPeriod = 1.5;
};

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;
   muzzleVelocity     = 600.0;
   totalTime          = 2;
   liveTime           = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod = 1;
};

RocketData BlasterBolt
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = blasterExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 0;      
   damageValue      = 1;
   damageType       = $BlasterDamageType;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   inheritedVelocityScale = 0.5;
   rotationPeriod = 1;
};

BulletData GrBlasterBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = GrBlasterExp;
   damageClass        = 0;
   damageValue        = 1;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 850;
   totalTime          = 2;
   liveTime           = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod = 1;
};

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
   inheritedVelocityScale = 0;
   isVisible          = True;
   soundId = SoundJetLight;
};

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;     
   damageValue      = 2;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 8;
   kickBackStrength = 5;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 1;
   inheritedVelocityScale = 0.5;
   soundId = SoundDiscSpin;
};

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;      
   damageValue        = 1;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 9.0;    
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
   damageValue        = 1.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.8;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData FFBShell1 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = FFBExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 149;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 0.1;
        projSpecialTime = 0.8;
        inheritedVelocityScale = 0.5;
        smokeName = "rsmoke.dts";
        soundId = SoundELFFire;
};

GrenadeData FFBShell2 
{ 
        bulletShapeName = "breath.dts";
        explosionTag = FFBExp2;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 1;
        damageType = $ShrapnelDamageType;
        explosionRadius = 15;
        kickBackStrength = 300;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 0.1;
        projSpecialTime = 0.8;
        inheritedVelocityScale = 0.5;
        smokeName = "plasmatrail.dts";
        soundId = SoundELFFire;
};

GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
   damageValue        = 1.32;
   damageType         = $MortarDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 9.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

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
   trailType   = 2;                
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

SeekingMissileData LiLRocketRPG
{ 
   bulletShapeName = "grenade.dts";
   explosionTag = grenadeExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.3;
   damageType = $LiLRocketDamageType;
   explosionRadius = 8;
   kickBackStrength = 0;
   muzzleVelocity = 100.0;
   terminalVelocity = 140.0;
   acceleration = 5.0;
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   trailType = 2; 
   trailString = "breath.dts";
   inheritedVelocityScale = 0.76;
}; 
 
SeekingMissileData LiLRocket
{ 
   bulletShapeName = "grenade.dts";
   explosionTag = grenadeExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   muzzleVelocity = 90.0;
   terminalVelocity = 140.0;
   acceleration = 4;
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   trailType = 2; 
   trailString = "breath.dts";
   inheritedVelocityScale = 0.76;
}; 

SeekingMissileData LiLRocketSubmission
{ 
   bulletShapeName = "grenade.dts";
   explosionTag = grenadeExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   muzzleVelocity = 80.0;
   terminalVelocity = 140.0;
   acceleration = 3;
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   trailType = 2; 
   trailString = "breath.dts";
   inheritedVelocityScale = 0.76;
};

RocketData LiLRocketalt
{
   bulletShapeName  = "grenade.dts";
   explosionTag     = grenadeExp;
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
   trailType   = 2;                
   trailString = "breath.dts";
   smokeDist   = 1.8;
};

SeekingMissileData LiLEMPRocketONE
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;
   muzzleVelocity = 100.0;
   terminalVelocity = 200.0;
   acceleration = 5.0;
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   inheritedVelocityScale = 0.76;
}; 

SeekingMissileData LiLEMPRocketTWO
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.5;
   damageType = $EMPDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;
   muzzleVelocity = 75.0;
   terminalVelocity = 200.0;
   acceleration = 4;
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   inheritedVelocityScale = 0.76;
}; 

RocketData LiLEMPRocketalt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LiLRocketEMPExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;      
   damageValue      = 0.5;
   damageType       = $EMPDamageType;
   explosionRadius  = 3;
   kickBackStrength = 0;//250.0;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 2;
   inheritedVelocityScale = 0.5;
};

SeekingMissileData MiniFlakproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniFlakExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;      
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
   inheritedVelocityScale = 0.5;
};

SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniSAMExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;      
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
   inheritedVelocityScale = 0.76;
};

SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;   
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
   inheritedVelocityScale = 0.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

// VX6 Switchable Vehc Weapons.
//++++++++++++++++++Vehicle Project Data+++++++++++++++++++++
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
	trailType = 2;
	trailString = "shotgunex.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};

GrenadeData BrawlerMortar 
{ 
        bulletShapeName = "mortar.dts";
        explosionTag = debrisExpMedium;
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
   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 150;
   trailWidth  = 0.15;
   soundId = SoundDiscSpin;
};

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
   inheritedVelocityScale = 0;
   isVisible          = True;
   soundId = SoundJetLight;
};

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
   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 150;
   trailWidth  = 0.5;
   soundId = SoundDiscSpin;
};

BulletData StarFury
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
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

GrenadeData StarBomb
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
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
   inheritedVelocityScale = 0;
   isVisible          = True;
   soundId = SoundJetLight;
};

GrenadeData HeavyGrenade
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;      
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

GrenadeData HeavyBazooka
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
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

RocketData HeavyRocket
{	bulletShapeName = "mortar.dts";
	explosionTag = debrisExpLarge;
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
	trailType = 2;
	trailString = "plastrail.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};

LaserData sniperLaser
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "shotgunex.dts";
   damageConversion  = 1.5;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.05;
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData TaserRfLaser
{
   laserBitmapName   = "paintglow.bmp";
   hitName           = "paint.dts";
   damageConversion  = 3;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.08;
   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
};

LaserData TaserTrtBLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 2;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

LaserData TaserTrtCLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.0001;
        baseDamageType = $LaserDamageType;
        beamTime = 0.3;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
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
   bitmapName       = "laserpulse.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500.0;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.125;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};


LightningData cloakingCharge
{
   bitmapName       = "fuex06.bmp";

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
        schedule("GameBase::startFadeIn(" @ %target @ ");", 30);
}


//--------------------------------------
LightningData BeamOfPainProj
{
   bitmapName       = "trailadd2.bmp";
   damageType       = $BeamOfPainDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.2;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;
   soundId = SoundELFFire;
};

LightningData MiniSmokeTurretproj
{
   bitmapName       = "trailadd2.bmp";
   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 0.5;
   energyDrainPerSec = 0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 2;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;
   soundId = SoundELFFire;
};

LightningData MiniELFTurretproj
{
   bitmapName       = "laserpulse.bmp";
   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1000;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.25;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;
   soundId = SoundELFFire;
};

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


function MiniELFturretproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
   GameBase::applyDamage(%target, $MiniELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);
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