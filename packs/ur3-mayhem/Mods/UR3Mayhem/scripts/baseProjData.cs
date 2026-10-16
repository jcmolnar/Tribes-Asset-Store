# Damage Types
#
$ImpactDamageType                  = -1;
$LandingDamageType          =  0;
$BulletDamageType         =  1;
$EnergyDamageType         =  2;
$PlasmaDamageType         =  3;
$ExplosionDamageType      =  4;
$ShrapnelDamageType       =  5;
$LaserDamageType          =  6;
$MortarDamageType         =  7;
$BlasterDamageType        =  8;
$ElectricityDamageType    =  9;
$CrushDamageType          = 10;
$DebrisDamageType         = 11;
$MissileDamageType        = 12;
$MineDamageType           = 13;
$RifleDamageType          = 14;
$TranqDamageType          = 15;
$RailDamageType           = 16;
$EMPDamageType            = 17;
$ShotgunDamageType        = 18;
$AssassinDamageType       = 19;
$FlameDamageType          = 20;
$AssaultRifleDamageType   = 21;
$FFBDamageType            = 22;
$EMPMineDamageType        = 23;

//--------------------------------------

 BulletData FlamerBolt
 {
 bulletShapeName = "plasmabolt.dts";
 explosionTag = grenadeExp;
 damageClass = 1;
 damageValue = 0.6;
 damageType = $FlameDamageType;
 explosionRadius = 10.0;
 muzzleVelocity = 60.0;
 totalTime = 0.75;
 liveTime = 0.75;
 lightRange = 3.0;
 lightColor = { 1, 1, 0 };
 inheritedVelocityScale = 0.3;
 isVisible = True;
 soundId = SoundJetLight;
 };

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 155.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
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

   muzzleVelocity     = 350.0;
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
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 180.0;
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
   damageValue        = 0.5;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 600.0;
   totalTime          = 10.5;
   liveTime           = 9.5;

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

   muzzleVelocity     = 155.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
BulletData RifleBullet
 {
 bulletShapeName = "bullet.dts";
 explosionTag = riflebulletExp;
 mass = 0.5;
 collisionRadius = 0.0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1.5;
 damageType = $RifleDamageType;
 aimDeflection = 0.0;
 muzzleVelocity = 4500.0;
 totalTime = 2.0;
 inheritedVelocityScale = 0.0;
 isVisible = true;
 tracerPercentage = 0.0;
 tracerLength = 30;
 detachFromShooter = false;
 };
//--------------------------------------

BulletData AssaultRifleBullet
 {
 bulletShapeName = "bullet.dts";
 explosionTag = riflebulletExp;
 mass = 0.5;
 collisionRadius = 0.0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1.5;
 damageType = $AssaultRifleDamageType;
 aimDeflection = 0.0;
 muzzleVelocity = 4500.0;
 totalTime = 2.0;
 inheritedVelocityScale = 0.0;
 isVisible = true;
 tracerPercentage = 0.0;
 tracerLength = 30;
 detachFromShooter = false;
 };

//--------------------------------------
BulletData AssassinBullet
 {
 bulletShapeName = "smoke.dts";
 explosionTag = riflebulletExp;
 mass = 0.5;
 collisionRadius = 0.0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 1.5;
 damageType = $AssassinDamageType;
 aimDeflection = 0.0;
 muzzleVelocity = 4500.0;
 totalTime = 2.0;
 inheritedVelocityScale = 0.0;
 isVisible = true;
 tracerPercentage = 0.0;
 tracerLength = 30;
 detachFromShooter = false;
 };

//--------------------------------------
BulletData TranqDart
 {
 bulletShapeName = "bullet.dts";
 explosionTag = bulletExp0;
 expRandCycle = 3;
 mass = 0.05;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.99;
 damageType = $TranqDamageType;
 muzzleVelocity = 4500.0;
 totalTime = 1.5;
 inheritedVelocityScale = 1.0;
 isVisible = True;
 tracerPercentage = 100.0;
 tracerLength = 30;
 };

//--------------------------------------

BulletData ShotgunBullet
{
bulletShapeName = "tracer.dts";
explosionTag = ShotExp;
 mass = 0.05;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.8;
 damageType = $ShotgunDamageType;
 aimDeflection = 0.02;
 muzzleVelocity = 2400.0;
 totalTime = 0.5;
 inheritedVelocityScale = 1.0;
 isVisible = False;
 tracerPercentage = 1.0;
tracerLength = 30;
 };


//--------------------------------------

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 600.0;
   terminalVelocity = 800.0;
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

RocketData RailRound
 {
 bulletShapeName = "bullet.dts";
 explosionTag = bulletExp0;
 collisionRadius = 0.0;
 mass = 2.0;
 damageClass = 0;
 damageValue = 0.85;
 damageType = $RailDamageType;
 explosionRadius = 0.1;
 kickBackStrength = 600.0;
 muzzleVelocity = 4000.0;
 terminalVelocity = 4000.0;
 acceleration = 5.0;
 totalTime = 10.0;
 liveTime = 11.0;
 lightRange = 10.0;
 lightColor = { 0.25, 0.25, 1 };
 inheritedVelocityScale = 1.0;
 trailType = 1;
 trailLength = 3000;
 trailWidth = 0.6;
 soundId = SoundJetHeavy;
 };

//--------------------------------------

RocketData EMPRocket
 {
 bulletShapeName = "rocket.dts";
 explosionTag = EMPPulseExp;
 collisionRadius = 0.0;
 mass = 2.0;
 damageClass = 1;
 damageValue = 0.5;
 damageType = $EMPDamageType;
 explosionRadius = 40.5;
 kickBackStrength = -450.0;
 muzzleVelocity = 1500.0;
 terminalVelocity = 2000.0;
 acceleration = 200.0;
 totalTime = 8.5;
 liveTime = 18.0;
 lightRange = 5.0;
 lightColor = { 0.25, 1.0, 0.25 };
 inheritedVelocityScale = 0.5;
 trailType = 2;
 trailString = "fusionbolt.dts";
 smokeDist = 1.8;
 soundId = SoundJetHeavy;
 };

//--------------------------------------

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

//--------------------------------------

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
   damageValue        = 0.8;
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
//------------------------------------------------------------------

GrenadeData ForceFieldBusterShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 9.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 250.8;
   damageType         = $FFBDamageType;

   explosionRadius    = 15;
   kickBackStrength   = -150.0;
   maxLevelFlightDist = 250;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

//------------------------------------------------------------------
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
   maxLevelFlightDist = 475;
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
   maxLevelFlightDist = 800;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
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
 damageValue = 0.5;
 damageType = $EMPDamageType;
 explosionRadius = 40;
 kickBackStrength = -450.0;
 maxLevelFlightDist = 375;
 totalTime = 30.0;
 liveTime = 0.25;
 projSpecialTime = 0.05;
 inheritedVelocityScale = 0.5;
 smokeName = "fusionbolt.dts";
 soundId = SoundELFFire;
 };

//--------------------------------------

 GrenadeData EMPBomb
 {
 bulletShapeName = "mortar.dts";
 explosionTag = EMPPulseExp;
 collideWithOwner = True;
 ownerGraceMS = 250;
 collisionRadius = 0.3;
 mass = 1.0;
 elasticity = 0.45;
 damageClass = 1;
 damageValue = 0.5;
 damageType = $EMPDamageType;
 explosionRadius = 40;
 kickBackStrength = -100.0;
 maxLevelFlightDist = 275;
 totalTime = 30.0;
 liveTime = 0.25;
 projSpecialTime = 0.05;
 inheritedVelocityScale = 0.5;
 smokeName = "fusionbolt.dts";
 soundId = SoundELFFire;
 };

//--------------------------------------

 GrenadeData EMPShock
 {
 bulletShapeName = "breath.dts";
 explosionTag = EMPPulseExp;
 collideWithOwner = false;
 ownerGraceMS = 500;
 collisionRadius = 0.0;
 mass = 0.0;
 elasticity = 0.1;
 damageClass = 0;
 damageValue = 0.1;
 damageType = $EMPDamageType;
 explosionRadius = 1;
 kickBackStrength = -450.0;
 maxLevelFlightDist = 1;
 totalTime = 0.05;
 liveTime = 0.05;
 projSpecialTime = 0.05;
 inheritedVelocityScale = 1.0;
 smokeName = "breath.dts";
 };


//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = -250.0;
   muzzleVelocity   = 600.0;
   terminalVelocity = 800.0;
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
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   muzzleVelocity    = 1072.0;
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

   damageConversion  = 0.9;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.05;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//-------------------------------------------------------

LaserData railLaser
 {
 laserBitmapName = "paintPulse.bmp";
 hitName = "laserhit.dts";
 damageConversion = 0.9;
 baseDamageType = $SniperDamageType;
 beamTime = 1.5;
 lightRange = 5.0;
 lightColor = { 0.25, 1.0, 0.25 };
 detachFromShooter = true;
 hitSoundId = SoundLaserHit;
 };

//-------------------------------------------------------

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = 0;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};
//-------------------------DELETE THIS-----------------------
LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 15.0;
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
//--------------------DELETE ABOVE----------------------------
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
        schedule("GameBase::startFadeIn(" @ %target @ ");", 120);
}



LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 400.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.5;
   energyDrainPerSec = 9.0;
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

//---------------------------DELETE BELOW---------------------
LightningData gravityCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $EMPDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 5.0;
   lightColor = { 1.0, 1.0, 0.25 };

   soundId = SoundELFFire;

};
//---------------------------DELETE ABOVE----------------------

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
                        %player.repairRate = 9.9;
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
                %player.repairRate   = 9.9;
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