# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$FlakDamageType      =  1;
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
$RifleDamageType       = 14;
$RailDamageType        = 15;
$SalvoDamageType       = 16;
$SentryDamageType      = 17;

$BulletDamageType      = 14;
$LiLRocketDamageType   = 18;
$EMPDamageType         = 19;
$LiLPOOmkiiDamageType  = 20;
$SmokeDamageType       = 21;
$MiniELFDamageType     = 22;
$BeamOfPainDamageType     = 23;
$FlashDamageType     = 24;

$BoostDamageType       = 50;

//--------------------------------------
BulletData VermBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = RifleExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.25;
   damageType         = $FlakDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 40;
};
//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = RifleExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 4000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = false;

   tracerPercentage   = 100;
   tracerLength       = 30;
};
//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.55;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 225;
   totalTime          = 4;
   liveTime           = 1;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 90;
   totalTime          = 2;
   liveTime           = 1;

   lightRange         = 2.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData MiniTurretBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $SentryDamageType;

   muzzleVelocity     = 150;
   totalTime          = 2;
   liveTime           = 1;

   lightRange         = 0.0;
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
   damageValue        = 1.3;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600;
   totalTime          = 1;
   liveTime           = 0.1;

   lightRange         = 1;
   lightColor         = { 1, 0, 0 };
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
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 155;
   totalTime          = 8;
   liveTime           = 1.5;
   lightRange         = 2;
   lightColor         = { 0, 1, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
//BulletData RifleBullet 
//{
// bulletShapeName = "smoke.dts";
// validateshape = true;
// explosionTag = rifleExp;
// mass = 0.1;
// collisionRadius = 0;
// bulletHoleIndex = 0;
// damageClass = 0;
// damageValue = 1.5;
// damageType = $RifleDamageType;
// muzzleVelocity = 6000;
// totalTime = 1;
// inheritedVelocityScale = 0;
// isVisible = True;
// tracerPercentage = 0;
// tracerLength = 0;
// detachFromShooter = false;
//}; 
//--------------------------------------
RocketData RifleBullet 
{
 bulletShapeName = "smoke.dts";
 explosionTag = rifleExp;
 mass = 0.1;
 collisionRadius = 0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1;
 damageType = $RifleDamageType;
 muzzleVelocity = 2250;
 terminalVelocity = 2250;
 totalTime = 1;
 inheritedVelocityScale = 0;
 isVisible = true;
 tracerPercentage = 0;
 tracerLength = 0;
 detachFromShooter = false;
};

//--------------------------------------
BulletData AssaultBullet 
{
 bulletShapeName = "bullet.dts";
 validateshape = true;
 explosionTag = rifleExp;
 mass = 0.1;
 collisionRadius = 0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1.5;
 damageType = $RifleDamageType;
 muzzleVelocity = 6000;
 totalTime = 1;
 inheritedVelocityScale = 0;
 isVisible = True;
 tracerPercentage = 0;
 tracerLength = 0;
 detachFromShooter = false;

   trailType   = 1;
   trailLength = 150;
   trailWidth  = 0.1;
}; 

//-----------------------------------------

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0;
   mass            = 2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150;

   muzzleVelocity   = 300;
   terminalVelocity = 350;
   acceleration     = 5;

   totalTime        = 5;
   liveTime         = 5;

   lightRange       = 3;
   lightColor       = { 0, 0, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 10;
   trailWidth  = 0.5;

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
   mass               = 1;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150;
   maxLevelFlightDist = 150;
   totalTime          = 8;    // special meaning for grenades...
   liveTime           = 1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------

RocketData RailRound { bulletShapeName = "bullet.dts"; explosionTag = rifleExp; collisionRadius = 0; mass = 0.1; damageClass = 0; damageValue = 1; damageType = $RailDamageType; explosionRadius = 0.1; kickBackStrength = 1; muzzleVelocity = 3000; terminalVelocity = 3000; acceleration = 5; totalTime = 1; liveTime = 1; lightRange = 0.5; lightColor = { 0, 0, 1 }; inheritedVelocityScale = 1.0; trailType = 1; trailLength = 300; trailWidth = 0.6; soundId = SoundJetLight; detachFromShooter = true; }; 

//--------------------------------------

RocketData Rocket 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = MrocketExp; 
   collisionRadius = 0; 
   mass = 2; 
   damageClass = 1; 
   damageValue = 5; 
   damageType = $SalvoDamageType; 
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
   damageValue        = 1;
   damageType         = $MortarDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 250;
   maxLevelFlightDist = 475;
   totalTime          = 9;
   liveTime           = 2;
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
   collisionRadius    = 1;
   mass               = 5;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $MortarDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 250;
   maxLevelFlightDist = 800;
   totalTime          = 8;
   liveTime           = 2;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------

GrenadeData FFBShell 
{
 bulletShapeName = "grenade.dts";
 explosionTag = FFBExp;
 collideWithOwner = True;
 ownerGraceMS = 250;
 collisionRadius = 0.2;
 mass = 9;
 elasticity = 0.01;
 damageClass = 1;
 damageValue = 280;
 damageType = $ShrapnelDamageType;
 explosionRadius = 15;
 kickBackStrength = 150;
 maxLevelFlightDist = 250; 
 totalTime = 8;
 liveTime = 1;
 projSpecialTime = 0.05;
 inheritedVelocityScale = 0.5;
 smokeName = "smoke.dts";
 soundId = SoundELFFire; };

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
   muzzleVelocity   = 150.0;
   terminalVelocity = 225.0;
   acceleration     = 20.0;
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
   collisionRadius = 0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 20;
   kickBackStrength = 145;

   muzzleVelocity    = 180;
   totalTime         = 5;
   liveTime          = 5;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 3;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

SeekingMissileData DTurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $MissileDamageType;
   explosionRadius  = 10;
   kickBackStrength = 75;

   muzzleVelocity    = 150;
   totalTime         = 5;
   liveTime          = 5;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 3;
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

   damageConversion  = 1;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

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
   boltLength       = 140;
   coneAngle        = 35.0;
   damagePerSec      = 0.6;
   energyDrainPerSec = 60;
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

LightningData VElightningCharge
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500.0;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData cloakingCharge
{
   bitmapName       = "paintPulse.bmp";

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



LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 100;
   coneAngle        = 35.0;
   damagePerSec      = 0.2;
   energyDrainPerSec = 90;
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
   boltLength       = 25.0;
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
			%armor = player::getArmor(%player);
			if($Server::Mod!=1)
				%player.repairRate = 2;
			else
			{
			if (%armor != "harmor")
			{
				%player.repairRate = 9.9;
			}
			else
			{
				%player.repairRate = 0.3;
			}
			}
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
		%armor = player::getArmor(%target);
		if($Server::Mod!=1)
			%player.repairRate  = 2;
		else
		{
		if (%armor != "harmor")
		{
			%player.repairRate   = 9.9;
		}
		else
		{
			%player.repairRate   = 0.3;
		}
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			if($Server::Mod==1)
				%player.repairRate   = 4.0;
			if($Server::Mod==2)
				%player.repairRate = 9;
			if($Server::Mod==3)
				%player.repairRate = 9;
			if($Server::Mod==4)
				%player.repairRate = 9;
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
		%target.lastrepairclient=%client;
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
        smokeName = "smoke.dts";
        soundId = SoundJetHeavy;
};

//--------------------------------------
GrenadeData ExSmScreen
{ 
        bulletShapeName = "fusionex.dts";
        explosionTag = ExSmScreenExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0;
        mass = 9;
        elasticity = 0.01;
        damageClass = 1;
        damageValue = 280;
        damageType = $ShrapnelDamageType;
        explosionRadius = 5;
        kickBackStrength = 0;
        maxLevelFlightDist = 250;
        totalTime = 10;
        liveTime = 6;
        projSpecialTime = 0.01;
        inheritedVelocityScale = 0.5;
        smokeName = "plasmatrail.dts";
        soundId = SoundELFFire;
};


//--------------------------------------
RocketData FireScreen
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = FireScreenExp;
   collisionRadius  = 0;
   mass             = 2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20;
   kickBackStrength = 15;
   muzzleVelocity   = 80;
   terminalVelocity = 160;
   acceleration     = 1;
   totalTime        = 3;
   liveTime         = 1;
   //lightRange       = 5;
   //lightColor       = { 1, 1, 1 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData SpellAbilityProj
{
   bulletShapeName    = "lfemale.dts";
//   validateShape      = true;
   explosionTag       = RifleExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 100;
   //tracerLength       = 30;
};

//--------------------------------------
BulletData LiLPOOmkiBullet
{
   bulletShapeName    = "smoke.dts";
//   validateShape      = true;
   explosionTag       = RifleExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $BulletDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 5000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

//--------------------------------------
BulletData LiLPOOmkiiBullet
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = RifleExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $LiLPOOmkiiDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

//---------------------------------------
GrenadeData LiLFFBShell 
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = LiLFFBExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 9;
        elasticity = 0.1;
        damageClass = 1;
        damageValue = 280;
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

SeekingMissileData LiLRocketEMP
{ 
   bulletShapeName = "fusionbolt.dts";
   explosionTag = LiLRocketEMPExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.3;
   damageType = $EMPDamageType;
   explosionRadius = 8;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 60.0;
   
   terminalVelocity = 100.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData LiLRocket
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 50.0;
   
   terminalVelocity = 100.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

//--------------------------------------
SeekingMissileData LiLRocketSubmission
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1;
   damageType = $LiLRocketDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 200.0;
   
   muzzleVelocity = 40.0;
   
   terminalVelocity = 60.0;
   acceleration = 3;
   
   totalTime = 30.0;
   liveTime = 31.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData LiLRocketalt
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "rsmoke.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
//--LiLEMPRocket 3 projectiles-
//--------------------------------------
//--------------------------------------
//--------------------------------------

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
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 200.0;
   acceleration = 5.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "smoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
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
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 200.0;
   acceleration = 4;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   //trailType = 2; 
   //trailString = "fusionbolt.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   //soundId = SoundJetHeavy;
}; 

RocketData LiLEMPRocketalt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LiLRocketEMPExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EMPDamageType;

   explosionRadius  = 3;
   kickBackStrength = 0;//250.0;
   muzzleVelocity   = 600;
   terminalVelocity = 800;
   acceleration     = 1;
   totalTime        = 2;
   liveTime         = 2;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "fusionbolt.dts";
   //smokeDist   = 1.8;

   //soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData MiniFlakproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniFlakExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
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
   //smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MiniSAMExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
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

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.76;

   //soundId = SoundJetHeavy;
};
//--------------------------------------
LaserData TaserRfLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 3;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.08;

   //lightRange        = 2;
   //lightColor        = { 0.4, 0, 0.6 };

   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
};

//--------------------------------------
LaserData TaserTrtBLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 2;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData TaserTrtCLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.0001;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

//--------------------------------------
LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

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
   beamWidth        = 0.2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
//minismoke is beam of pain turret

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
   beamWidth        = 2;//0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------
LightningData MiniELFTurretproj
{
   bitmapName       = "laserpulse.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;//0.8;
   energyDrainPerSec = 1000;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;

   //lightRange = 3.0;
   //lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%friendFire = $Server::TeamDamageScale;
	%playerId = %shooterId;
	//if (%playerId.GravBolt == "0")
	//{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -80;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
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
	 //%targetId = GameBase::getControlClient(%target);
	 //%targetName = Client::getName(%targetId);
   GameBase::applyDamage(%target, $MiniELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);
         //Client::sendMessage(%targetid,0,"DOH,you have dropped somethings!");
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}