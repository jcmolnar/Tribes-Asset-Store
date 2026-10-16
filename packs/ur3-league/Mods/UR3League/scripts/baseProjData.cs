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

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
	validateShape      = true;
   explosionTag       = bulletExp0;
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
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
	validateShape      = true;
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
	validateShape      = true;	
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

   muzzleVelocity     = 175;
   totalTime          = 2;
   liveTime           = 1;

   lightRange         = 0.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------
BulletData MiniHellBolt
{
   bulletShapeName    = "shotgunbolt.dts";
	
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $SentryDamageType;

   muzzleVelocity     = 225;
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
	validateShape      = true;	
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
	validateShape      = true;	
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 225;
   totalTime          = 8;
   liveTime           = 1.5;
   lightRange         = 2;
   lightColor         = { 0, 1, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData RifleBullet 
{
 bulletShapeName = "smoke.dts";
	validateShape      = true;	
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
	validateShape      = true;	
 explosionTag = rifleExp;
 mass = 0.1;
 collisionRadius = 0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1;
 damageType = $RifleDamageType;
 muzzleVelocity = 7000;
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
	validateShape      = true;	
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
   trailLength = 15;
   trailWidth  = 0.5;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
	validateShape      = true;	
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
	validateShape      = true;	
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
	validateShape      = True;
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
	validateShape      = true;	
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
	validateShape      = True;
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
	validateShape      = true;	
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
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 20;
   kickBackStrength = 175;

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
   boltLength       = 110;
   coneAngle        = 35.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 110;
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
			if (%armor != "harmor")
			{
				%player.repairRate = 9.9;
			}
			else
			{
				%player.repairRate = 0.3;
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
		if (%armor != "harmor")
		{
			%player.repairRate   = 9.9;
		}
		else
		{
			%player.repairRate   = 0.3;
		}
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
BulletData m16Bullet
{
   bulletShapeName    = "smoke.dts";
   validateShape      = true;
   explosionTag       = rifleExp;
   expRandCycle       = 0;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2;
   damageType         = $RifleDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 6000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};



BulletData LiLPOOmkiiBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = rifleExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $RifleDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 6000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};
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

