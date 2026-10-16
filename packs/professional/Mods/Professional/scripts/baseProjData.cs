# Damage Types
#
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
$FighterGunDamageType  = 14;
$KamikazeDamageType    = 15;
$ElectricDamageType    = 16;
$RocketDamageType      = 17;
$EMPDamageType         = 19;
$FlameDamageType       = 19;
$ShotgunDamageType     = 20;
$MarlinDamageType      = 21;
$PlasmaCannonDamageType= 22;
$CTurretDamageType     = 23;
$MeteorDamageType      = 24;
$EMPLightningDamageType= 25;
$SolarFlareDamageType  = 26;
$RailDamageType        = 27;
$LightningDamageType   = 28;
$NullDamageType        = 29;


//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0015;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

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
   damageValue        = 0.2;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 60.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $EnergyDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 100.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 325.0;
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
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
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
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 160.0;
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
   damageValue        = 1.25;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
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
   damageType       = $RocketDamageType;
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

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
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


function targetLaser::onAdd(%this)  //added by Werewolf. This baby will make all friendly mortar-bots mortar your painted target...
{                                   //...or at least that's what I plan to do ;-)

//        schedule("NuclearExplosion(" @ %this @ ");",4.9,%this);
//    echo("Targeting Laser detected");
}




LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.12;
   energyDrainPerSec = 90.0;
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

LightningData turretShock
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.12;
   energyDrainPerSec = 200.0;
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

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
		{
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

//--------------------------------------
// Fighter Round
//--------------------------------------
BulletData FighterBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FighterExp;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $FighterGunDamageType;
   explosionRadius  = 1.75;

   muzzleVelocity     = 500.0;
   totalTime          = 0.545;
   liveTime         = 0.545;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//======================================================================== Locking Missle 

SeekingMissileData StingerMissileTracker 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.75;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 250.0;
muzzleVelocity = 72.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

//======================================================================== Stinger Missile

RocketData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 200.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 1000.0;
   acceleration     = 100.0;

   totalTime        = 10.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//Minimod plugins

// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    ChainTurret.ArmorData.cs
//    ChainTurret.baseProjData.cs
//    ChainTurret.item.cs
//    ChainTurret.reinitData.cs
//    ChainTurret.station.cs
//    ChainTurret.turret.cs
//
// to your MiniMod/plugins directory.

BulletData ChaingunTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $CTurretDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

// This is a MiniMod Plugin.
// This plugin is the Death of Bots.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy then modified further by PeterT.

LaserData DoBLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.151;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.

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

// This is a MiniMod Plugin.
// This plugin is the Flame Turret from the Ideal mod.
// Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Flame Turret.ArmorData.cs
//    Flame Turret.baseExpData.cs
//    Flame Turret.baseProjData.cs
//    Flame Turret.item.cs
//    Flame Turret.Nsound.cs
//    Flame Turret.reinitData.cs
//    Flame Turret.staticshape.cs
//    Flame Turret.station.cs
//    Flame Turret.turret.cs
//
// to your MiniMod/plugins directory.



RocketData FlameLarge
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $FlameDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 10.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};

// MiniMod plugin
// Fusion Blaster created/ported By, Dewy.

BulletData FusionGunBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = FusionGunExp;
   collisionRadius    = 2.0;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $EnergyDamageType;

   explosionRadius    = 3.0;
   muzzleVelocity     = 5.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime          = 15.0;
   liveTime           = 15.0;
   lightRange         = 5.0;
   lightColor         = { 0.15, 0.15, 1 };
   inheritedVelocityScale = 1.5;
   isVisible          = True;

   rotationPeriod = 0.05;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundJetHeavy;
};

RocketData FusionShell
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = FusionGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 10.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor         = { 0.15, 0.15, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    GuardDogTurret.ArmorData.cs
//    GuardDogTurret.baseProjData.cs
//    GuardDogTurret.item.cs
//    GuardDogTurret.reinitData.cs
//    GuardDogTurret.station.cs
//    GuardDogTurret.turret.cs
//
// to your MiniMod/plugins directory.

RocketData Watch
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.06;
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

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 10;//1.8

   soundId = SoundJetHeavy;
};

// This is a MiniMod Plugin.
// This plugin is the Mine Launcher from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    MineLauncher.ArmorData.cs
//    MineLauncher.baseProjData.cs
//    MineLauncher.item.cs
//    MineLauncher.station.cs
//
// to your MiniMod/plugins directory.

GrenadeData MineShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MineDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function MineShell::onAdd(%this)
{
	schedule("DeployNukes(" @ %this @ " , 5);",1.0,%this);//5++++++
}

function DeployNukes(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Nuke1");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10.0,false);//0++++	
//		%obj = newObject("","Mine","Nuke2");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-15.0,false);
		%obj = newObject("","Mine","Nuke3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20.0,false);
		%count -= 1;
		schedule("DeployNukes(" @ %this @ " , " @ %count @ ");",1.0,%this);//0.5++++++++
	}
}

// This is a MiniMod Plugin.
// This plugin is the Particle Accelerator from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ParticleAccelerator.ArmorData.cs
//    ParticleAccelerator.baseProjData.cs
//    ParticleAccelerator.item.cs
//    ParticleAccelerator.station.cs
//
// to your MiniMod/plugins directory.

 BulletData ClusterBombShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = debrisExpSmall;
	 mass = 0.05;
	 bulletHoleIndex = 0;
  	collisionRadius    = 15.0;//++++++
	 damageClass = 1;
   	explosionRadius    = 8;//5;+++++++++++
   	kickBackStrength   = 100.0;//++++++++
	 damageValue = 0.038; //0.05;+++++++++++++++++++
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.01;//++++++++++
	 muzzleVelocity = 300.0;
	 totalTime = 1.0; //0.8;+++++++++++++++++
	 liveTime = 0.05;//++++++++++++++++++++++++++++++++++++++++++++
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
	
	triggerRadius = 5;//+++++++++++
	damageLevel = {1.0, 1.0};//++++
	maxDamage = 1.0;//0++++++++++++

   tracerPercentage   = 100.0; //1.0;++++++++++++++++++++++++++++++++++++++++++++++
	 tracerLength = 30;
   smokeName              = "plasmatrail.dts";
 };
function ClusterBombShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClusterBombShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

// This is a MiniMod Plugin.
// This plugin is the Plasma Cannon from the Redneck Slag Pack.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    PlasmaCannon.ArmorData.cs
//    PlasmaCannon.baseProjData.cs
//    PlasmaCannon.item.cs
//    PlasmaCannon.station.cs
//
// to your MiniMod/plugins directory.

//

BulletData PlasmaCannonBlast
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = PlasmaCannonExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.50;
   damageType         = $PlasmaCannonDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

// This is a MiniMod plugin
// This is the Rail Turret From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

LaserData railLaser
{
laserBitmapName = "paintPulse.bmp";
hitName = "laserhit.dts";
damageConversion = 0.008;
baseDamageType = $RailDamageType;
beamTime = 1.5;
lightRange = 5.0;
lightColor = { 0.25, 1.0, 0.25 };
detachFromShooter = true;
hitSoundId = SoundLaserHit;
};

// This is a MiniMod Plugin.
// This Plugin is the Repair Rifle.
// Requirements: MiniMod v.07 or later
//   and the Energizer Pack Plugin.

RepairEffectData RepairRifleBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 1000.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairRifleBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.006;
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

function RepairRifleBolt::onRelease(%this, %player)
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

function RepairRifleBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairRifle &&
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

//--------------------------------------

// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.
//
// To install this plugin just...
// Add:
//
//    SeekerTurret.ArmorData.cs
//    SeekerTurret.baseProjData.cs
//    SeekerTurret.item.cs
//    SeekerTurret.reinitData.cs
//    SeekerTurret.station.cs
//   SeekerTurret.turret.cs
//
// to your MiniMod/plugins directory.
//laserBitmapName   = "paintPulse.bmp"; 
//mortar.dts    shotgunbolt.dts
LaserData SeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";

   damageConversion  = 0.22; //0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;//0.70;

   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

// This is a MiniMod plugin
// This is the Shotgun From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.



// $HeatIncrease[$ShotgunDamageType] = 0; 

BulletData ShotgunBullet
{
bulletShapeName = "tracer.dts";
explosionTag = bulletExp0;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.024;
damageType = $ShotgunDamageType;
aimDeflection = 0.02;
muzzleVelocity = 2000.0;
totalTime = 0.5;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 30;
}; 

// MiniMod plugin
// Marlin ported By, Desertfox.



BulletData Marlinshot
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.03;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.61;
   damageType         = $MarlinDamageType;

   muzzleVelocity     = 800.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;

   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

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
	damageValue = 0.04;
	damageType = $EMPDamageType;
	explosionRadius = 150;
	kickBackStrength = -100.0;
	maxLevelFlightDist = 100;
	totalTime = 30.0;
	liveTime = 0.25;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "fusionbolt.dts";
	soundId = SoundELFFire;
};

GrenadeData EMPShock 
{ 
	bulletShapeName = "breath.dts";
 	explosionTag = nullExp;
 	collideWithOwner = false;
 	ownerGraceMS = 500;
 	collisionRadius = 0.0;
 	mass = 0.0;
 	elasticity = 0.1;
 	damageClass = 0;
 	damageValue = 0.01;
 	damageType = $NullDamageType;
 	explosionRadius = 1;
 	kickBackStrength = 0.0;
 	maxLevelFlightDist = 1;
 	totalTime = 0.05;
 	liveTime = 0.05;
 	projSpecialTime = 0.05;
 	inheritedVelocityScale = 1.0;
 	smokeName = "breath.dts";
 };


//BulletData BlasterBolt
//{
//   bulletShapeName    = "shotgunbolt.dts";
//   explosionTag       = blasterExp;
//
//   damageClass        = 0;
//   damageValue        = 0.1;
//   damageType         = $BlasterDamageType;
//
//   muzzleVelocity     = 325.0;
//   totalTime          = 2.0;
//   liveTime           = 1.125;
//
//   lightRange         = 3.0;
//   lightColor         = { 1.0, 0.25, 0.25 };
//   inheritedVelocityScale = 0.5;
//   isVisible          = True;
//
//   rotationPeriod = 1;
//};

SeekingMissileData BlasterTracker 
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag = blasterExp;
	collisionRadius = 3.5;
	mass = 0.1;
	damageClass = 1;
	damageValue = 0.05;
	damageType = $BlasterDamageType;
	explosionRadius = 10.0;
	//kickBackStrength = 250.0;
	muzzleVelocity = 125.0;	//375.00
	totalTime = 6.0;
	liveTime = 3;
	lightRange = 3.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 0.0;
	nonSeekingTurningRadius = 5.0;
	//proximityDist = 3.0;
	//trailType = 2;
	//trailString = "plasmatrail.dts";
	//smokeDist = 2.5;
	//inheritedVelocityScale = 0.5;
	//soundId = SoundJetHeavy;
	rotationPeriod = 1;
};


//HunterSeeker Stuff

RocketData HunterSeeker
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = FusionGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 1.0;
   kickBackStrength = 0;

   muzzleVelocity   = 0.0;
   terminalVelocity = 0.0;
   acceleration     = 5.0;

   totalTime        = 0.05;
   liveTime         = 0.5;

   lightRange       = 5.0;
   lightColor         = { 0.15, 0.15, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


RocketData Meteor
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 8;
   damageType       = $MeteorDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 110.0;
   terminalVelocity = 110.0;
   acceleration     = 1.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 4;

   soundId = SoundJetHeavy;
};


LaserData LightningBeam
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "laserhit.dts";
   //explosionTag     = LargeShockwave;

   //damageConversion  = 0.151;
   damageValue       = 10.0;
   damageclass=0;
   //explosionRadius = 50;
   baseDamageType    = $LightningDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;     //SoundLaserHit;
};

BulletData LightningBlast2
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = PlasmaCannonExp;

   damageClass        = 1;
   damageValue        = 10;
   damageType         = $LightningDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity     = 600.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};


BulletData LightningBlast
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = LightningExp;

   damageClass        = 1;
   damageValue        = 0.01;
   damageType         = $EMPLightningDamageType;
   explosionRadius    = 75.0;

   muzzleVelocity     = 600.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};


GrenadeData TeleportShock 
{ 
	bulletShapeName = "breath.dts";
 	explosionTag = TeleportExp;
 	collideWithOwner = false;
 	ownerGraceMS = 500;
 	collisionRadius = 0.0;
 	mass = 0.0;
 	elasticity = 0.1;
 	damageClass = 0;
 	damageValue = 0.01;
 	damageType = $NullDamageType;
 	explosionRadius = 10;
 	kickBackStrength = 0.0;
 	maxLevelFlightDist = 1;
 	totalTime = 0.05;
 	liveTime = 0.05;
 	projSpecialTime = 0.05;
 	inheritedVelocityScale = 1.0;
 	smokeName = "breath.dts";
 };
 
 
 