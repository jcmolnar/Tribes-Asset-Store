# Damage Types
#
$ImpactDamageType			= -1;
$LandingDamageType		=  0;
$BulletDamageType			=  1;
$EnergyDamageType			=  2;
$PlasmaDamageType			=  3;
$ExplosionDamageType		=  4;
$ShrapnelDamageType		=  5;
$LaserDamageType			=  6;
$MortarDamageType			=  7;
$BlasterDamageType		=  8;
$ElectricityDamageType		=  9;
$CrushDamageType			= 10;
$DebrisDamageType			= 11;
$MissileDamageType		= 12;
$MineDamageType			= 13;

//-------------------------------------------------------------
//Talon damage types -

// Ballistic Projectile Weapons
$APShellDamageType		= 14; // AR-900
$SniperDamageType			= 15; // SR-100
$ReasonDamageType			= 16; // Reason
$GaussDamageType			= 17; // Gauss Rifle

// Energy Projectile Weapons
$ShotgunDamageType		= 18; // Blast Rifle
$IonDamageType			= 19; // Thunderbolt
$GargoyleDamageType		= 20; // Gargoyle Miniplane
$EnGunDamageType			= 21; // Energon Cannon
$FireDamageType			= 22; // Support Mortar (Napalm), Devestator, Incendiary Grenades

// Missile Projectile Weapons
$PMissileDamageType		= 23; // RPG (Basic,Guided), Swarmer, Scout

// Vehicular Types
$KamikazeDamageType		= 24; // Suicide damage
	$KamKillDamageType	= 25; // SUBTYPE - Kamikaze - Damage done to others
$AADamageType			= 26; // Interceptor

// Special Weapons
// Effect-causing types
$EMPDamageType			= 27;
$PoisonDamageType			= 28; // Initiating dmg from poison
	$ChemDamageType		= 29; // SUBTYPE - Poison - Damage done over time
$DisarmDamageType			= 30;
$BoreDamageType			= 31;
$PaintDamageType			= 32;
//Other special
$NukeDamageType			= 33;
$SmiteDamageType			= 34;
$FusionDamageType			= 35;
$PheonixDamageType		= 36;
//Grenade-borne
$DisruptionDamageType		= 37;

// Non-weapon types
$PassiveDamageType		= 38;
$ExhaustDamageType		= 39;
$BoreDmgDamageType		= 40;
$SetDestructDamageType		= 41;
$RadiationDamageType		= 42;
$BlindDamageType			= 43;

//-------------------------------------------------------------
//Turret Damage Types -
$TurPlasmaDamageType		= 44;
$TurELFDamageType			= 45;
$FlakkerDamageType		= 46;
$TurMissileDamageType		= 47;
$TurLaserDamageType		= 48;
$HangingDamageType		= 49;
$TurChainDamageType		= 50;
$StingerDamageType		= 51;
$RPGTurretDamageType		= 52;
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
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $TurPlasmaDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   lightRange         = 7.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData HangingBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $HangingDamageType;

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

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.13;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 80.0;		//damn i forgot what this was
   totalTime          = 2000.0;	// same here
   liveTime           = 1000.125; // Added 3 0's

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData QuadBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.11;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 120.0;
   totalTime          = 1.0;
   liveTime           = 0.2;

   aimDeflection      = 0.005;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 2;
};
//--------------------------------------
RocketData PlasmaBolt
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 8.0;

   kickBackStrength = 0;
   muzzleVelocity     = 100.0;
   terminalVelocity = 110.0;
   acceleration     = 50.0;
   totalTime          = 6.0;
   liveTime           = 7.5;
   lightRange         = 8.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetLight;
};

RocketData AutoPlasmaBolt
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass        = 1;
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 8.0;

   kickBackStrength = 0;
   muzzleVelocity     = 70.0;
   terminalVelocity = 80.0;
   acceleration     = 50.0;
   totalTime          = 6.0;
   liveTime           = 7.5;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

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

   muzzleVelocity   = 75.0;
   terminalVelocity = 90.0;
   acceleration     = 15.0;

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
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType;

   aimDeflection      = 0.005;
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
   damageValue        = 1.18;		//Raised by .18
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

function MortarShell::onAdd(%this)
{
	schedule("MortarTrailMaster(" @ %this @ ");",0.1,%this);
}

// Trail effects function
function MortarTrailMaster(%this) 
{
	if(%this)
	{
		%type = TFunc::Rand(2);

		if(%type == 1)
			%itemtype = "LongSmoke";
		if(%type == 2)
			%itemtype = "SmokeBurst";

		%pos = TFunc::GetRandomOffset(GameBase::getPosition(%this),3,3,3);
		TFunc::SpawnFX(%pos,Gamebase::GetTeam(%player),%itemtype);

		schedule("MortarTrailMaster(" @ %this @ ");",0.1,%this);
	}
}

echo("TALON:MortarMaster checks ok");

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
   damageValue        = 1.22;
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
   damageValue      = 0.7;		//Raised by 0.2
   damageType       = $PMissileDamageType;

   explosionRadius  = 20.5;
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
   damageValue      = 0.7;	//Raised by 0.2
   damageType       = $TurMissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 85.0;
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

   damageConversion  = 0.008;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;

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

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 3;
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

   damageType       = $TurELFDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.1;
   energyDrainPerSec = 80.0;
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

function turretCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

		GameBase::applyDamage(%target, $TurELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);

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
   segmentDivisions = 6;
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
			%player.repairRate = 0.3;
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
		%player.repairRate   = 0.2;
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

//------------------------------------/\-->
// Talon Rules stuff : -=TalonHawk=-  |>
//------------------------------------\/-->
RocketData PlasmaSniper
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = plasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.125;
   damageType       = $BlasterDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 250.0;
   terminalVelocity = 275.0;
   acceleration     = 100.0;
   totalTime        = 10.0;
   liveTime         = 900.0;
   lightRange       = 20.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 2;

   soundId = SoundJetLight;
};

GrenadeData PlasmaBullet
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BlasterDamageType;

   explosionRadius    = 6.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 50;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//Seeking missile for the RPG
SeekingMissileData RPGSeeker
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $PMissileDamageType;
   explosionRadius  = 6.5;
   kickBackStrength = 190.0;

   muzzleVelocity    = 80.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 8;
   nonSeekingTurningRadius = 2;
   proximityDist     = 1;
   smokeDist         = 2.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//Smoke release used by various guns (Reason)
GrenadeData SmokeRelease
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = smokeExp;
   expRandCycle       = 3;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = -1.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PassiveDamageType;

   explosionRadius    = 0.01;
   kickBackStrength   = 0.01;
   maxLevelFlightDist = 100;
   totalTime          = 0.3;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};

GrenadeData SmokeRelease2
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = smokeExp;
   expRandCycle       = 3;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PassiveDamageType;

   explosionRadius    = 0.01;
   kickBackStrength   = 0.01;
   maxLevelFlightDist = 999;
   totalTime          = 0.3;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//Gatling Bullet
BulletData GatlingBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = gatExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $TurChainDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//Reason Railgun Dart
BulletData RailDart
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = gatExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $ReasonDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};
//--------------------------------------
SeekingMissileData SwarmRocketSeeking
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $PMissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 25.0;

   muzzleVelocity    = 85.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 30;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};
//--------------------------------------
RocketData EMPMissile
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = EMPExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $EMPDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 75.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 180.0;
   acceleration     = 9.0;
   totalTime        = 10.0;
   liveTime         = 900.0;
   lightRange       = 20.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.8;

   soundId = SoundJetHeavy;
};

// Goes through objects because of collisionRadius - possible uses?
RocketData EMPRocketM
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = EMPExp;
   collisionRadius  = 0.1;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $EMPDamageType;

   explosionRadius  = 45.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 800.0;
   acceleration     = 90.0;
   totalTime        = 10.0;
   liveTime         = 900.0;
   lightRange       = 30.0;
   lightColor       = { 0.2, 0.2, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData GasShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ChemDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";
};

RocketData ShockMissile
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $PassiveDamageType;

   explosionRadius  = 100.0;
   kickBackStrength = 750.0;
   muzzleVelocity   = 145.0;
   terminalVelocity = 800.0;
   acceleration     = 9.0;
   totalTime        = 10.0;
   liveTime         = 900.0;
   lightRange       = 20.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 2.8;

   soundId = shockExplosion;
};

GrenadeData EMPMortar
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = NukeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $EMPDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

// Disarmer shot
GrenadeData DsrmMortar
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = NukeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $DisarmDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 75.0;
   maxLevelFlightDist = 275;

   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

GrenadeData FlameMortarShell
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = incendiaryExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.28;
   damageType         = $FireDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 300;
   totalTime          = 30.0;
   liveTime           = 1.2;
   projSpecialTime    = 0.01;

   lightRange       = 10.0;
   lightColor         = { 1, 1, 0 };

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

function FlameMortarShell::onAdd(%this)
{
	schedule("NapalmLeakFlame(" @ %this @ ");",1.0,%this);
}

function NapalmLeakFlame(%this) 
{
	if(%this)
	{
		%obj = newObject("","Mine","NapalmP");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-40,false);
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		%obj = newObject("","Mine","NapalmP");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-30,false);
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		%obj = newObject("","Mine","NapalmP");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,false);
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		schedule("NapalmLeakFlame(" @ %this @ ");",0.3,%this);
	}
}

//Energon Gun
RocketData EnGunBlast
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = EnGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $EngunDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 4.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 3.5;
   liveTime         = 2.5;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 85;
   trailWidth  = 0.1;
};

// Thunderbolt beam
RocketData thunderZap
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = ThunderExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $IonDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 4.0;

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
   trailLength = 35;
   trailWidth  = 0.5;
};

// SR-100 Sniper bullet
RocketData SniperShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.56;
   damageType       = $SniperDamageType;

   muzzleVelocity   = 1100.0;
   terminalVelocity = 19000.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 0.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;
   trailLength = 3;
   trailWidth  = 0.01;
};

// Poison SR-100 bullet
RocketData PoisonSniper
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $ChemDamageType;

   muzzleVelocity   = 950.0;
   terminalVelocity = 19000.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 0.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;
   trailLength = 3;
   trailWidth  = 0.01;
};

// Electro-magnetic Pulse bullet
RocketData EMPSniper
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $EMPDamageType;

   muzzleVelocity   = 1500.0;
   terminalVelocity = 19000.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 0.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;
   trailLength = 3;
   trailWidth  = 0.01;
};

// DUHEAP Shells AR-900
BulletData AssaultShellLevel0
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 2.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $APShellDamageType;

   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AssaultShellLevel1
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 2.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $APShellDamageType;

   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   aimDeflection      = 0.0025;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AssaultShellLevel2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 2.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $APShellDamageType;

   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   aimDeflection      = 0.005;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AssaultShellLevel3
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   mass               = 2.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $APShellDamageType;

   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   aimDeflection      = 0.0075;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

// Single energy charge from Blast Rifle
BulletData BlastShell
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = debrisExpSmall;
   mass               = 2.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};

// Cannon for the Interceptor
BulletData AAGun
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlakExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $AADamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 925.0;
   totalTime          = 100.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 70;
};

// Plasma for the Plasma Bomber
BulletData FlierPlasma
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = debrisExpMedium;

   damageClass        = 1;
   damageValue        = 0.35;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 8.0;

   aimDeflection      = 0.003;
   muzzleVelocity     = 81.0;
   totalTime          = 3.0;
   liveTime           = 4.2;
   lightRange         = 4.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

// Honing Heavy Stinger AA Missile
SeekingMissileData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = StingerExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $StingerDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 85.0;
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

// Tank Shell fired by the RPG turret
RocketData TankShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = StingerExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.48;
   damageType       = $RPGTurretDamageType;
   explosionRadius  = 15.0;

   kickBackStrength = 100.0;
   muzzleVelocity   = 775.0;
   terminalVelocity = 700.0;
   acceleration     = 92.0;
   totalTime        = 4.5;
   liveTime         = 6.0;
   lightRange       = 9.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 3.8;

   soundId = soundJetHeavy;
};

// Fireball form Flamethrower
GrenadeData FireBall
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = fireballExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $FireDamageType;

   explosionRadius    = 10.5;
   kickBackStrength   = 0;
   maxLevelFlightDist = 75;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};

// Doomsdary NML exp on firing
RocketData NukeShock
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = mineExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $PassiveDamageType;

   explosionRadius  = 80.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 95.0;
   terminalVelocity = 91.0;
   acceleration     = 99.0;
   totalTime        = 0.03;
   liveTime         = 0.03;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 20.8;

   soundId = soundjetHeavy;
};

// RPG
RocketData RPGMissile
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.85;
   damageType       = $PMissileDamageType;

   explosionRadius  = 14.5;
   kickBackStrength = 150.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 5.8;

   soundId = soundjetHeavy;
};

RocketData TurboLaser
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $PassiveDamageType;

   explosionRadius  = 80.5;
   kickBackStrength = -500.0;
   muzzleVelocity   = 395.0;
   terminalVelocity = 400.0;
   acceleration     = 9.0;
   totalTime        = 10.0;
   liveTime         = 2.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rocket.dts";
   smokeDist   = 0.8;
};

//Gargoyle Laser
BulletData GargyBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.08;
   damageType         = $GargoyleDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 2.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//Cerebral Bore
RocketData BoreUngd
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = turretExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $BoreDamageType;

   muzzleVelocity   = 100.0;
   terminalVelocity = 900.0;
   acceleration     = 9.0;
   totalTime        = 10.0;
   liveTime         = 10.0;
   lightRange       = 10.0;
   lightColor       = {1,0,0};
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 0.8;

   soundId = SoundShieldOn;
};

//The mine deployer
GrenadeData MineDeployer
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 90.0;
   elasticity         = 0.15;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PassiveDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.1;

   smokeName              = "rsmoke.dts";
};

function MineDeployer::onAdd(%this)
{
	echo(GameBase::getTeam(%this));
	schedule("DeployMiniMines(" @ %this @ ");",1.9,%this);
}

function DeployMiniMines(%this) 
{
	if(%this)
	{
		%obj = newObject("","Mine","MiniMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,false);
	}
}

LaserData miniLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.001;
   baseDamageType    = $TurLaserDamageType;

   beamTime          = 0.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

RepairEffectData HealLaser
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
   segmentDivisions = 1;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function HealLaser::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
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
	%target.lastrepairer = %client;
}

function HealLaser::onRelease(%this, %player)
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

function HealLaser::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == HealRifle && %player.repairTarget != -1)
	{
		%object = %player.repairTarget;
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

LaserData TurretLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.004;
   baseDamageType    = $TurLaserDamageType;

   beamTime          = 1.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//Object fired when using remote beacon
RocketData BeaconBolt
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = EnGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $PassiveDamageType;

   explosionRadius  = 2.5;
   kickBackStrength = 60.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 1000.0;
   acceleration     = 500.0;

   totalTime        = 3.5;
   liveTime         = 2.5;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
};

//Object fired when using remote beacon
GrenadeData FNXMissile
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 4.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $PheonixDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.10;
   maxLevelFlightDist = 100;
   totalTime          = 10.0;    // special meaning for grenades...
   liveTime           = 10.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function FNXMissile::onAdd(%this)
{
	$FNXowner[%this] = $LastPheonix;
	$LastPheonix = "";
	schedule("DeployPheonixCharge(" @ %this @ ");",9.9,%this);
}

function DeployPheonixCharge(%this)
{
	%client = $FNXowner[%this];
	if(%client)
		echo(%client);
	else
		echo("TALON:No client detected");
	$FNXCharges[%client]++;
	%beacon = newObject("", "StaticShape", "FNXCharge", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%client));
	GameBase::setPosition(%beacon,GameBase::getPosition(%this));
	Gamebase::setMapName(%beacon,"Fnx Bomb - "@ Client::getName(%client));
	// Quick check to manage the groups the bombs go in
	%checkset = nameToID("MissionCleanup/FNX "@%client);
	if(%checkset == -1)
	{
		newObject("FNX "@%client,SimSet);
		addToSet("MissionCleanup","FNX "@%client);
	}
	addToSet("MissionCleanup/FNX "@%client, %beacon);
	addToSet("MissionCleanup", %beacon);
}

LaserData ShoulderLaser
{
   laserBitmapName   = "laserPulse.bmp";
//   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $TgtLasDamageType;

   beamTime          = 0.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData DeathRay
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $SmiteDamageType;
   boltLength       = 900.0;
   coneAngle        = 35.0;
   damagePerSec      = 60;
   energyDrainPerSec = 60;
   segmentDivisions = 4;
   numSegments      = 4;
   beamWidth        = 0.325;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

BulletData NovaBurst
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = plasmaExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 3.1459;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};

SeekingMissileData ArtemisRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MortarDamageType;
   explosionRadius  = 10;
   kickBackStrength = 250;

   muzzleVelocity    = 120.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 500;
   nonSeekingTurningRadius = 600.0;
   proximityDist     = 1.5;
   smokeDist         = 3;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

GrenadeData Flare
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = flashExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.95;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PassiveDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 100;
   totalTime          = 10.0;    // special meaning for grenades...
   liveTime           = 10.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function FlareDrop::onAdd(%this)
{
	$FlareOwner[%this] = $LastFlare;
	%LastFlare = "";
	%owner = $FlareOwner[%this];

	%owner.hasFlare = yes;
	%owner.flareID = %this;
}

function FlareDrop::onRemove(%this)
{
	%owner = $FlareOwner[%this];
	$FlareOwner[%this].hasFlare = no;
}


//PHEONIX projectile
RocketData FNXDistortion
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $PheonixDamageType;

   explosionRadius  = 50;
   kickBackStrength = 250.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 1000.0;
   acceleration     = 500.0;

   totalTime        = 3.5;
   liveTime         = 2.5;

   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 3.8;

//   soundId = SoundFNXDisNoise;
};

function FNXDistortion::onAdd(%this)
{
	%this.ptime = 0.5;
	%this.pspread = 1;
	schedule("FNXTrailMaster(" @ %this @ ");",0.4,%this);
	%this.FNXLauncher = $FNXLauncher;
	$FNXLauncher = "";
}

// Trail effects function
function FNXTrailMaster(%this) 
{
	if(%this)
	{
		%type = TFunc::Rand(3);

		if(%type == 1)
			%itemtype = "FNXWaveParticle";
		if(%type == 2)
			%itemtype = "FNXFireParticle";
		if(%type == 3)
			%itemtype = "FNXBlueParticle";


		%pos = TFunc::GetRandomOffset(GameBase::getPosition(%this),%this.pspread,%this.pspread,%this.pspread);
		TFunc::SpawnFX(%pos,Gamebase::GetTeam(%player),%itemtype);

		TFunc::SpawnFX(%pos,Gamebase::GetTeam(%player),"FNXFireParticle");

		if(%this.ptime > 0.1)
			%this.ptime -= 0.09;
		%this.pspread++;
		schedule("FNXTrailMaster(" @ %this @ ");",%this.ptime,%this);
	}
}

echo("TALON:FNXMaster checks ok");

function DeathRay::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	GameBase::applyDamage(%target, $SmiteDamageType, %damVal, %pos, %vec, %mom, %shooterId);	
}

LaserData PheonixPreFireLine
{
   laserBitmapName   = "ylite03.bmp";
//   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
//   hitSoundId        = SoundLaserHit;
};

LaserData PheonixLine
{
   laserBitmapName   = "lightningNew.bmp";
//   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 10.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
//   hitSoundId        = SoundLaserHit;
};

BulletData AFIDRepairBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.0;
   damageType         = $PassiveDamageType;

   muzzleVelocity     = 900.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData GaussSniperShot
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $GaussDamageType;

   muzzleVelocity   = 900.0;
   terminalVelocity = 1000.0;
   acceleration     = 900.0;
   totalTime        = 10.0;
   liveTime         = 20.0;
   lightRange       = 20.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 5;
};

RepairEffectData PaintLaser
{
   bitmapName       = "paintPulse.bmp";
   boltLength       = 600.0;
   segmentDivisions = 1;
   beamWidth        = 0.1;
   coneAngle = 80;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 8.0;
   lightColor = { 0.25, 0.85, 0.25 };
};

function PaintLaser::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%object = getObjectType(%target);

	if (%target == %player)
		Client::sendMessage(%client, 0, "No target detected...");
	else if(%object == "Player" || %object == "Flier" || %object == "Turret")
		FireLockOn(%client,%target);
	else
		Client::sendMessage(%client, 0, "Invalid target...");
}

function PaintLaser::onRelease(%this, %player)
{
}

function PaintLaser::checkDone(%this, %player)
{
}
