# Damage Types
#
$ImpactDamageType                  = -1;
$LandingDamageType          =  0;
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
//============================ Added for NDG Reneg
$SniperDamageType      = 14;
$FlashDamageType       = 15;
$ShellDamageType       = 16;

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
   damageValue        = 0.125;
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
   damageValue        = 1.32;
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

//--------------------------------------
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";
//**** Damage Conversion was 0.007
   damageConversion  = 0.012;
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
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
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

//================================= NDG Renegades Projectiles added ==============================
SeekingMissileData PointMissile
{
        bulletShapeName = "rocket.dts";
           explosionTag    = rocketExp;
           collisionRadius = 0.0;
          mass            = 2.0;
           damageClass      = 1;       // 0 impact, 1, radius
           damageValue      = 0.37;
           damageType       = $MissileDamageType;
           explosionRadius  = 4.5;
           kickBackStrength = 75.0;
          muzzleVelocity    = 100.0;
           totalTime         = 10;
           liveTime          = 10;
           seekingTurningRadius    = 15;
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

//---------------------------------------- Laser Turret Laser --------------------------------
LaserData TurretLaser
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

//---------------------------------------- C.I.W.S. Bullet -----------------------------------------
BulletData TurretBullet
{
          bulletShapeName    = "bullet.dts";
           explosionTag       = bulletExp0;
           expRandCycle       = 3;
           mass               = 0.05;
           bulletHoleIndex    = 0;
           damageClass        = 0;       // 0 impact, 1, radius
           damageValue        = 0.11;
           damageType         = $BulletDamageType;
           aimDeflection      = 0.004;
           muzzleVelocity     = 425.0;
           totalTime          = 1.5;
           inheritedVelocityScale = 1.0;
           isVisible          = False;
           tracerPercentage   = 1.0;
           tracerLength       = 30;
};

//------------------------Holo Plasma Bolt for Holo Plasma Turret ----------------------
BulletData HoloFusionBolt
{
           bulletShapeName    = "fusionbolt.dts";
           explosionTag       = turretExp;
           mass               = 0.05;
           damageClass        = 0;       // 0 impact, 1, radius
//           damageValue        = 0.25;
//           damageType         = $EnergyDamageType;
           muzzleVelocity     = 50.0;
           totalTime          = 6.0;
          liveTime           = 4.0;
           isVisible          = True;
           rotationPeriod = 1.5;
};

//--------------------------------------
SeekingMissileData TurretHoloMissile
{
           bulletShapeName = "rocket.dts";
           explosionTag    = rocketExp;
           collisionRadius = 0.0;
           mass            = 2.0;
           damageClass      = 1;       // 0 impact, 1, radius
//           damageValue      = 0.5;
//           damageType       = $MissileDamageType;
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

//---------------------------------------------- Rail Laser for Rail Turret ----------------------------------------
LaserData railLaser
{
           laserBitmapName   = "laserPulse.bmp";
           hitName           = "laserhit.dts";
          damageConversion  = 0.009;
           baseDamageType    = $SniperDamageType;
           beamTime          = 1.5;
           lightRange        = 5.0;
           lightColor        = { 0.25, 1.0, 0.25 };
           detachFromShooter = true;
           hitSoundId        = SoundLaserHit;
};

//================================== Shotgun Blast ========
BulletData ShotGunBlast
{
           bulletShapeName    = "bullet.dts";
           explosionTag       = bulletExp0;
           expRandCycle       = 3;
           mass               = 0.05;
           bulletHoleIndex    = 0;
           damageClass        = 0;       // 0 impact, 1, radius
           damageValue        = 0.05;
           damageType         = $ShellDamageType;
           aimDeflection      = 0.029;
           muzzleVelocity     = 200.0;
           totalTime          = 1;
           liveTime           = 1;
           inheritedVelocityScale = 1.0;
           isVisible          = False;
           tracerPercentage   = 2.0;
           tracerLength       = 30;
           soundId = SoundJetLight;

};

//================================== Sniper Round ===========
BulletData SniperBullet
{
           BulletShapeName    = "bullet.dts";
           explosionTag       = bulletExp0;
           Mass               = 0.05;
           collisionRadius    = 0.0;
           bulletHoleIndex    = 0;
           damageClass        = 0;
           damageValue        = 0.80;
           damageType         = $SniperDamageType;
           muzzleVelocity     = 3000.0;
           totalTime          = 1;
           inheritedVelocityScale = 0.0;
           tracerPercentage   = 100.0;
           tracerLength       = 50;
};

//================================== Flame Thrower ============
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
        lightColor = { 1, 1, 0 };
        inheritedVelocityScale = 0.3;
        isVisible = True;
        soundId = SoundJetLight;
};

//=================================== Rail Round ===============
RocketData RailRound
{
           bulletShapeName    = "bullet.dts";
           explosionTag       = bulletExp0;
           collisionRadius    = 0.0;
           mass               = 2.0;
           damageClass        = 0;
           damageValue        = 0.60;
           damageType         = $SniperDamageType;
           explosionRadius    = 0.1;
           kickBackStrength   = 600.0;
           muzzleVelocity     = 2000.00;
           terminalVelocity   = 2000.00;
           acceleration       = 5.0;
           totalTime          = 11.0;
           liveTime           = 11.0;
           lightRange         = 10.0;
           LightColor         = { 0.25, 0.25, 1 };
           inheritedVelocityScale = 1.0;
           trailType          = 1;
           trailLength        = 3000;
           TrailWidth         = 0.6;
           soundId            = SoundJetHeavy;
};

//=================================== Shock Mortar Round ===========
GrenadeData ShockMortarShell
{
           bulletShapeName    = "mortar.dts";
           explosionTag       = mortarExp;
           collideWithOwner   = True;
           ownerGraceMS       = 250;
           collisionRadius    = 0.3;
           mass               = 5.0;
           elasticity         = 0.1;
           damageClass        = 1;       // 0 impact, 1, radius
           damageValue        = 0.03;
           damageType         = $FlashDamageType;
           explosionRadius    = 20.0;
           kickBackStrength   = 250.0;
           maxLevelFlightDist = 275;
           totalTime          = 30.0;
           liveTime           = 2.0;
           projSpecialTime    = 0.01;
           inheritedVelocityScale = 0.5;
           smokeName              = "mortartrail.dts";
};

//===================================== Ion Bolt =======================
RocketData IonBolt
{
           bulletShapeName      = "enbolt.dts";
           explosionTag         = turretExp;
           collisonRadius       = 0.0;
           mass                 = 2.0;
           damageClass          = 1;
           damageValue          = 0.15;
           damageType           = $ElectricityDamageType;
           explosionRadius      = 4;
           kickBackStrength     = 0.0;
           muzzleVelocity       = 200.0;
           terminalVelocity     = 200.0;
           acceleration         = 5.0;
           totalTime            = 10.0;
           liveTime             = 11.0;
           lightRange           = 5.0;
           lightColor           = { 1.0, 0.7, 0.5 };
           inheritedVelocityScale = 0.5;
           trailType            = 1;
           trailLength          = 50;
           trailWidth           = 0.3;
           soundId              = SoundJetHeavy;
};

//================================ ThunderBolt Lightning =================
LightningData boltCharge
{
        bitmapName = "lightningNew.bmp";
        damageType = $ElectricityDamageType;
        boltLength = 50.0;
        coneAngle = 35.0;
        damagePerSec = 0.20;
        energyDrainPerSec = 70.0;
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

//================================== Cloaking Gun ==========================
LightningData cloakingCharge
{
           bitmapName       = "paintPulse.bmp";
           damageType       = $ElectricityDamageType;
           boltLength       = 40.0;
           coneAngle        = 35.0;
           damagePerSec      = 0;
           energyDrainPerSec = 0;
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

//================================== Wave Gun ==============================
RocketData Shock
{
        bulletShapeName = "fusionbolt.dts";
        explosionTag = LargeShockwave;
        collisionRadius = 0.0;
        mass = 2.0;
        damageClass = 1;
        damageValue = 0.15;
        damageType = $MissileDamageType;
        explosionRadius = 45.0;
        kickBackStrength = 450.0;
        muzzleVelocity = 100.0;
        terminalVelocity = 150.0;
        acceleration = 15.0;
        totalTime = 6.0;
        liveTime = 4.0;
        lightRange = 5.0;
        lightColor = { 1.0, 0.7, 0.5 };
        inheritedVelocityScale = 0.5;
        soundId = SoundJetHeavy;
};

//=================================== Rocket Launcher's Stinger Missile ========
RocketData StingerMissile
{
        bulletShapeName = "rocket.dts";
        explosionTag = rocketExp;
        collisionRadius = 0.0;
        mass = 2.0;
        damageClass = 1;
        damageValue = 0.5;
        damageType = $ExplosionDamageType;
        explosionRadius = 20.5;
        kickBackStrength = 450.0;
        muzzleVelocity = 65.0;
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

//============================= Deployable Shock Turret ======================
GrenadeData ShockShell
{
   bulletShapeFile    = "mortar.dts";
   explosionTag       =  LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 995.0;
   elasticity         = 0.01;
   damageClass        = 1;
   damageValue        = 0.10;
   damageType         = $FlashDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0.01;
   smokeName          = "mortartrail.dts";
};

//======================== Ion Turret Bolt =============================
RocketData IonBolt
{
   bulletShapeName      = "enbolt.dts";
   explosionTag         = turretExp;
   collisonRadius       = 0.0;
   mass                 = 2.0;
   damageClass          = 1;
   damageValue          = 0.15;
   damageType           = $ElectricityDamageType;
   explosionRadius      = 4;
   kickBackStrength     = 0.0;
   muzzleVelocity       = 200.0;
   terminalVelocity     = 200.0;
   acceleration         = 5.0;
   totalTime            = 10.0;
   liveTime             = 11.0;
   lightRange           = 5.0;
   lightColor           = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType            = 1;
   trailLength          = 50;
   trailWidth           = 0.3;
   soundId              = SoundJetHeavy;
};

//============================== Interceptors Bullets ========================
BulletData JetBullet
{
        bulletShapeName      = "bullet.dts";
        explosionTag         = bulletExp0;
        expRandCycle         = 3;
        mass                 = 0.05;
        bulletHoleIndex      = 0;
        damageClass          = 0;
        damageType           = $BulletDamageType;
        damageValue          = 0.40;
        aimDeflection        = 0.008;
        muzzleVelocity       = 750.0;
        totalTime            = 1.5;
        inheritedVelocityScale = 1.0;
        isVisible            = True;
        tracerPercentage     = 100;
        tracerLength         = 50;
};

//========================= HPC ShockWave =============================
RocketData FlyerShock
{
        bulletShapeName = "fusionbolt.dts";
        explosionTag = LargeShockwave;
        collisionRadius = 0.0;
        mass = 2.0;
        damageClass = 1;
        damageValue = 0.15;
        damageType = $MissileDamageType;
        explosionRadius = 45.0;
        kickBackStrength = 750.0;
        muzzleVelocity = 80.0;
        terminalVelocity = 120.0;
        acceleration = 5.0;
        totalTime = 6.0;
        liveTime = 4.0;
        lightRange = 5.0;
        lightColor = { 1.0, 0.7, 0.5 };
        inheritedVelocityScale = 0.5;
        soundId = SoundJetHeavy;
};

//============================ LPC Mortar =============================
GrenadeData FlierMortar
{
        bulletShapeName    = "mortar.dts";
        explosionTag       = mortarExp;
        collideWithOwner   = True;
        ownerGraceMS       = 250;
        collisionRadius    = 0.3;
        mass               = 5.0;
        elasticity         = 0.1;
        damageClass        = 1;       // 0 impact, 1, radius
        damageValue        = 0.75;
        damageType         = $MortarDamageType;
        explosionRadius    = 15.0;
        kickBackStrength   = 150.0;
        maxLevelFlightDist = 275;
        totalTime          = 30.0;
        liveTime           = 2.0;
        projSpecialTime    = 0.01;
        inheritedVelocityScale = 0.5;
        smokeName              = "mortartrail.dts";
};

//===================== Scout and SPC Rocket ==========================
RocketData FlierRocket
{
        bulletShapeName  = "rocket.dts";
        explosionTag     = rocketExp;
        collisionRadius  = 0.0;
        mass             = 2.0;
        damageClass      = 1;       // 0 impact, 1, radius
        damageValue      = 0.2;
        damageType       = $MissileDamageType;
        explosionRadius  = 9.5;
        kickBackStrength = 250.0;
        muzzleVelocity   = 85.0;
        terminalVelocity = 100.0;
        acceleration     = 5.0;
        totalTime        = 10.0;
        liveTime         = 11.0;
        lightRange       = 5.0;
        lightColor       = { 1.0, 0.7, 0.5 };
        inheritedVelocityScale = 0.5;
   // rocket specific
        trailType   = 2;                // smoke trail
        trailString = "rsmoke.dts";
        smokeDist   = 2.8;
        soundId = SoundJetHeavy;
};

//================================= Repair bolt for Eng Repair Gun ======================
RepairEffectData RepairBolt2
{
   bitmapName       = "paintPulse.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };
};

function RepairBolt2::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.01;
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
                
                if (getObjectType(%player.repairTarget) == "Player") {
                       Centerprint(%client,"You cannot heal people with the Engineers Repair Gun",2);
			   %player.repairRate   = 0.00;
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
				%player.repairRate   = 0.5;
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

function RepairBolt2::onRelease(%this, %player)
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

function RepairBolt2::checkDone(%this, %player)
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
//============================== satchel Charge ============================
GrenadeData SatchelShell 
{
	bulletShapeName = "grenade.dts"; 
	explosionTag = rocketExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.2; 
	mass = 1.0; 
	elasticity = 0.45; 
	damageClass = 1; 
	damageValue = 2.5; 
	damageType = $MortarDamageType; 
	explosionRadius = 30; 
	kickBackStrength = 350.0; 
	maxLevelFlightDist = 1; 
	totalTime = 0.1; 
	liveTime = 0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5; 
	smokeName = "smoke.dts"; 
}; 

//*********************  Medics Gun **************************************
RepairEffectData RepairBolt3
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.15, 0.15, 0.85 };
};

function RepairBolt3::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.5;
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
                
                if (getObjectType(%player.repairTarget) == "Player") {
//                       Centerprint(%client,"You cannot repair objects with the Medics Healing Gun",2);
				%player.repairRate   = 0.5;
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
				Centerprint(%client,"You cannot repair items with the Medics Healing Gun",2);

				%player.repairRate   = 0.00;
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

function RepairBolt3::onRelease(%this, %player)
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

function RepairBolt3::checkDone(%this, %player)
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
