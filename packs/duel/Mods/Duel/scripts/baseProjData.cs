# Damage Types
#
//disc grenade plasma blaster chaingun laser elf mortar handnade mine
//%weaponOrder = "4 5 3 8 1 6 9 7 11 13";
$ImpactDamageType		  = -1;
$LandingDamageType	   =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;//disc
$ShrapnelDamageType    =  5;//grenade
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       =  10;
$DebrisDamageType      =  11;
$MissileDamageType     =  12;
$MineDamageType        =  13;
$HandGrenadeDamageType =  14;

RocketData BlueShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = {  0, 0, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData GreenShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = {  0, 1, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData YellowShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = {  1, 1, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData PinkShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = {  1, 0.411765, 0.705882 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData BlackShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = { 0.580392, 0, 0.827451 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData PurpleShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;

   lightColor       = { 1.0, 0.0, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData KingShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collideWithOwner   = True;

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

   lightRange       = 10.0;
   lightColor       = {  1, 0, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;


   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};
//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
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
BulletData ChaingunBullet2
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
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
   kickBackStrength = 10.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 20.0;
   liveTime         = 21.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.05;//0.5

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 2.8;

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
//
//
//Custom
//FireWorks
RocketData GFFireFlames
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = GFireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 50.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 35.0;
	lightColor = { 1.0, 0, 0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "bluex.DTS";
	smokeDist = 8.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};

RocketData GFFireFlames2
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = GFireExp2;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 50.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 20.0;
	lightColor = { 0, 1.0, 0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "PlasmaEX.DTS";
	smokeDist = 7.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};

RocketData GFFireFlamesBlank
{
	bulletShapeName = "";
	explosionTag = GFireExp3;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 48.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 50.0;
	lightColor = { 0, 0, 1 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "FusionEX.DTS";
	smokeDist = 7.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};

RocketData GFFireFlamesBlank2
{
	bulletShapeName = "";
	explosionTag = GFireExp4;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 48.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 1.0;
	lightColor = { 1.0, 1.0, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "PlasmanEX.DTS";
	smokeDist = 7.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};

RocketData GFireFlamesBlank
{
	bulletShapeName = "";
	explosionTag = GFireExp3;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 48.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 50.0;
	lightColor = { 0, 0, 1 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "FusionEX.DTS";
	smokeDist = 7.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};


RocketData GFireFlamesBlank2
{
	bulletShapeName = "";
	explosionTag = GFireExp4;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.001;
	baseDamageType = $BulletDamageType;
	explosionRadius = 35.0;
	kickBackStrength = 400.5;
	muzzleVelocity = 50.0;
	terminalVelocity = 48.0;
	acceleration     = 10.0;
	totalTime = 3.0;
	liveTime = 3.0;
	lightRange = 1.0;
	lightColor = { 1.0, 1.0, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "PlasmanEX.DTS";
	smokeDist = 7.0;
	soundId = Explode3FW;
	rotationPeriod = 0.5;
};
//other
SeekingMissileData ScoutSeek
{
   bulletShapeName = "flyer.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $CrushDamageType;
   explosionRadius  = 10.0;
   kickBackStrength = 0.0;

   muzzleVelocity   = 30.0;
   terminalVelocity = 45.0;
   acceleration     = 0.0;
   totalTime        = 60.5;
   liveTime         = 60.0;



   soundId = SoundDiscSpin;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 3;                // smoke trail
   trailString = "flyer.dts";
   smokeDist   = 1.8;
};
RocketData blastshot
{
//bulletShapeName = "Shockwave_Large.dts";
bulletShapeName = "shield_medium.dts";
explosionTag = debrisExpSmall;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1; //radius
damageValue = 0.001;
baseDamageType = $BulletDamageType;
explosionRadius = 16.0;
kickBackStrength = 100.0;
muzzleVelocity   = 40.0;
terminalVelocity = 50.0;
acceleration     = 10.0;
totalTime = 3.0;
liveTime = 3.0;
lightRange = 10.0;
colors[0] = { 1.0, 0.75, 0.75 };
colors[1] = { 1.0, 0.25, 0.25 };
inheritedVelocityScale = 0.5;
//trailType = 2;
//trailString = "shield_medium.dts";
smokeDist   = 25.8;
soundId = SoundJetHeavy;
rotationPeriod = 1.5;
   trailType   = 1;
   trailLength = 500;
   trailWidth  = 5.5;
};
SeekingMissileData PlasSeek
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.45;
   damageType       = $MortarDamageType;
   explosionRadius  = 4.0;
  // kickBackStrength = 175.0;

   muzzleVelocity     = 55.0;
   totalTime          = 30.0;
   liveTime           = 20.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.03;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   soundId = SoundJetLight;
};
SeekingMissileData DiscSeek
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MortarDamageType;
   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 60.5;
   liveTime         = 60.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.1;
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;
   soundId = SoundDiscSpin;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   soundId = SoundJetLight;
};
RocketData blastshot2
{
//bulletShapeName = "Shockwave_Large.dts";
bulletShapeName = "shield_large.dts";
explosionTag = debrisExpSmall;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1; //radius
damageValue = 0.001;
baseDamageType = $BulletDamageType;
explosionRadius = 16.0;
kickBackStrength = 100.0;
muzzleVelocity   = 39.6;
terminalVelocity = 49.6;
acceleration     = 10.0;
totalTime = 2.8;
liveTime = 2.8;
lightRange = 10.0;
colors[0] = { 1.0, 0.75, 0.75 };
colors[1] = { 1.0, 0.25, 0.25 };
inheritedVelocityScale = 0.5;
trailType = 2;
trailString = "shield_large.dts";
smokeDist   = 1.5;
soundId = SoundJetHeavy;
rotationPeriod = 1.5;
trailLength = 500;
smokeName              = "shield_large.dts";
};
LaserData sniperLaser2
{
	laserBitmapName   = "paintPulse.bmp";
	hitName           = "laserhit.dts";

	damageConversion  = 0.0;
	baseDamageType    = $BulletDamageType;

 	beamTime          = 1.1;

	lightRange        = 10.0;
	lightColor        = { 1.0, 0.0, 0.0 };

	detachFromShooter = false;
	hitSoundId        = NoSound;
};

LaserData sniperLaser3
{
	laserBitmapName   = "paintPulse.bmp";
	hitName           = "laserhit.dts";

	damageConversion  = 0.2;
	baseDamageType    = $BulletDamageType;

 	beamTime          = 5.0;

	lightRange        = 10.0;
	lightColor        = { 0.2, 0.2, 1.0 };

	detachFromShooter = true;
	hitSoundId        = NoSound;
};

LaserData PinkLaser
{
	laserBitmapName   = "paintPulse.bmp";
	hitName           = "laserhit.dts";

	damageConversion  = 0.2;
	baseDamageType    = $BulletDamageType;

 	beamTime          = 50.0;

	lightRange        = 10.0;
	lightColor        = { 0.2, 0.2, 0.2 };

	detachFromShooter = true;
	hitSoundId        = NoSound;
};


BulletData Sparklye
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.0;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 0.5;
   liveTime           = 0.5;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------
GrenadeData PlasmaShell
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = GFireExp4;
   collideWithOwner   = True;
   ownerGraceMS       = 250;//250
   collisionRadius    = 0.2;
   mass               = 0.1;
   elasticity         = 0.7;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 55;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 950;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 30.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.3;//0.5

   //smokeName              = "smoke.dts";
};
GrenadeData FastShell
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = GFireExp4;
   collideWithOwner   = True;
   ownerGraceMS       = 250;//250
   collisionRadius    = 0.2;
   mass               = 0.1;
   elasticity         = 0.7;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 55;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 1;
   totalTime          = 0.1;    // special meaning for grenades...
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.1;//0.5

   //smokeName              = "smoke.dts";
};

GrenadeData SlowShell
{
   bulletShapeName    = "flyer.dts";
   explosionTag       = GFireExp4;
   collideWithOwner   = True;
   ownerGraceMS       = 250;//250
   collisionRadius    = 0.2;
   mass               = 0.1;
   elasticity         = 0.7;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 55;
   kickBackStrength   = 450.0;
   maxLevelFlightDist = 1100;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 30.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.4;//0.5

   //smokeName              = "smoke.dts";
};




SeekingMissileData MotherOfGodSeek
{
   bulletShapeName = "dustplume.dts";//"mrtwig.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MortarDamageType;
   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 5.0;
   terminalVelocity = 5.0;
   acceleration     = 20.0;
   totalTime        = 20.5;
   liveTime         = 20.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.1;
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;
   soundId = debrisLargeExplosion;
   seekingTurningRadius    = 0.01;
   nonSeekingTurningRadius = 0.01;
   proximityDist     = 1.5;
   soundId = SoundJetLight;
};
SeekingMissileData MotherOfGodSeekStop
{
   bulletShapeName = "mrtwig.dts";//"dustplume.dts";//
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MortarDamageType;
   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 5.0;
   terminalVelocity = 5.0;
   acceleration     = 20.0;
   totalTime        = 20.5;
   liveTime         = 20.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.01;
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;
   soundId = debrisLargeExplosion;
   seekingTurningRadius    = 0.01;
   nonSeekingTurningRadius = 0.01;
   proximityDist     = 1.5;
   soundId = SoundJetLight;
};
RocketData LestatShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = LestatrocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = -1.01;
   damageType       = $CrushDamageType;

   explosionRadius  = 5700.5;
   kickBackStrength = -500.0;

   muzzleVelocity   = 0.5;
   terminalVelocity = 0.5;
   acceleration     = 0.1;

   totalTime        = 90.5;
   liveTime         = 90.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.1;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData LestatShell2
{
   bulletShapeName = "discb.dts";
   explosionTag    = LestatrocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = -1.01;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5700.5;
   kickBackStrength = -500.0;

   muzzleVelocity   = 0.5;
   terminalVelocity = 0.5;
   acceleration     = 0.1;

   totalTime        = 90.5;
   liveTime         = 90.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.1;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};



GrenadeData RoleyPoley
{
   bulletShapeName    = "ammo2.dts";//"flyer.dts";//"microex";
   explosionTag       = GFireExp4;
   collideWithOwner   = True;
   ownerGraceMS       = 1250;//250
   collisionRadius    = 0.2;
   mass               = 300.01;
   elasticity         = 0.9;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   //acceleration     = 50.0;

   explosionRadius    = 55;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 1100;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 30.0;
   projSpecialTime    = 30.0;

   inheritedVelocityScale = -10.0;//0.5

   //smokeName              = "smoke.dts";
};


RocketData DiscShell2
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

   	trailString = "fiery.dts";//"FusionEX.DTS";

   soundId = SoundDiscSpin;
};

BulletData LestatBullet
{
   bulletShapeName    = "FusionEX.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 25.0;
   totalTime          = 4.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   //tracerPercentage   = 1.0;
   //tracerLength       = 30;
};


RocketData ArrowOne
{
   bulletShapeName = "arrow5_b.dts";
   explosionTag    = ArrowrocketExp;

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

   soundId = SoundDeploySensor;
};
RocketData ArrowTwo
{
   bulletShapeName = "arrow5_g.dts";
   explosionTag    = ArrowrocketExp;

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

   soundId = SoundDeploySensor;
};
RocketData ArrowThree
{
   bulletShapeName = "arrow5_r.dts";
   explosionTag    = ArrowrocketExp;

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

   soundId = SoundDeploySensor;
};
RocketData ArrowFour
{
   bulletShapeName = "arrow5_y.dts";
   explosionTag    = ArrowrocketExp;

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

   soundId = SoundDeploySensor;
};

BulletData PyrmOne
{
   bulletShapeName    = "pyrm2.dts";
   explosionTag       = ArrowrocketExp;

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

RepairEffectData ProjectileBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 200.0;
   segmentDivisions = 8;//80
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

LightningData Projectilelightning
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 200.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.00;
   energyDrainPerSec = 0.0;
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