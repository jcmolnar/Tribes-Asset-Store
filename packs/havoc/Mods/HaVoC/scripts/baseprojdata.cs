
# Damage Types
#
$ImpactDamageType = -1; 
$LandingDamageType = 0; 
$BulletDamageType = 1; 
$EnergyDamageType = 2; 
$PlasmaDamageType = 3; 
$ExplosionDamageType = 4; 
$ShrapnelDamageType = 5; 
$LaserDamageType = 6; 
$MortarDamageType = 7; 
$BlasterDamageType = 8; 
$ElectricityDamageType = 9; 
$CrushDamageType = 10; 
$DebrisDamageType = 11; 
$MissileDamageType = 12; 
$MineDamageType = 13; 
$SniperDamageType = 14; 
$FlashDamageType = 15; 
$EMPDamageType = 16; 
$RailDamageType = 17; 
$EngineerEMPDamageType = 18; 
$ShotgunDamageType = 19; 
$BurnDamageType = 20; 
$BlindDamageType = 21; 
$BurnEDamageType = 22; 
$ElectricityEDamageType = 23; 
$ElectricityLEDamageType = 24; 
$ElectricityTEDamageType = 25; 
$PDamageType = 26; 
$LaserEDamageType = 27; 
$MExplosionDamageType = 28; 
$SmallEnergyDamageType = 29;
$MiniDamageType = 30;
$FireDamageType = 31;
$OMineDamageType = 32;
$TracDamageType = 33;
$DDamageType = 34;
$AAExplosionDamageType = 35; 
$SuperEnergyDamageType = 36;
$LitDamageType = 37;
$Lit2DamageType = 38;
$MissileRamDamageType = 44;
$TeleFragDamageType = 66;

BulletData ChaingunBullet {
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;
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

BulletData BaseAlarmProj { bulletShapeName = "breath.dts"; explosionTag = fakeExp; mass = 0.05; collisionRadius = 0.0; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.01; damageType = 91; aimDeflection = 0.0; muzzleVelocity = 2000.0; totalTime = 1; inheritedVelocityScale = 0.1; isVisible = false; lightRange = 0.75; lightColor = { 0.4, 0.4, 0.4 }; tracerPercentage = 1.0; tracerLength = 1; }; 

RocketData SpawnArmageddon { bulletShapeName = "breath.dts"; explosionTag = fakeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0; damageType = $ExplosionDamageType; explosionRadius = 0; kickBackStrength = 0.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 0.1; liveTime = 0.1; lightRange = 0.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; }; 

function SpawnArmageddon::onAdd(%this) {
	%t = $F1aky;
	%markerPos = $F1aky2;
	$F1aky = ""; 
	$F1aky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " 0 " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);		
	%vehicle = newObject("",flier,ShortCoolProj,true);
	Gamebase::setMapName(%vehicle,"Missile");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	%vehicle.clLastMount = %client;
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	%client.safet = true;
	GameBase::playSound(%vehicle,bigExplosion1,0);
	doneposs(%client);
	remoteEval(%client, SetControls, true);
	Client::setControlObject(%client, %vehicle); 
}

RocketData SpawnMCSMissile { bulletShapeName = "breath.dts"; explosionTag = fakeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0; damageType = $ExplosionDamageType; explosionRadius = 0; kickBackStrength = 0.0; muzzleVelocity = 1.0; terminalVelocity = 800.0; acceleration = 5.0; totalTime = 0.1; liveTime = 0.1; lightRange = 0.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; }; 

function SpawnMCSMissile::onAdd(%this) {
	%t = $Faky;
	%markerPos = $Faky2;
	$Faky = ""; 
	$Faky2 = ""; 
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%client = GameBase::getControlClient(%t);
	if (GameBase::getLOSInfo(%t, 5, %rot)) {
		Client::sendMessage(%client,0,"Unable to fire - Object in the way~wC_BuySell.wav");
		return;
	}
	%f = Vector::getFromRot(%rot, 5, 2.5);		
	%vehicle = newObject("",flier,%t.load,true);
	%client.safet = true;
	Gamebase::setMapName(%vehicle,"Missile");
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	%vehicle.clLastMount = %client;
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	%t.load = "";
	GameBase::playSound(%vehicle,bigExplosion1,0);
	(Client::getOwnedObject(%client)).CommandTag = "";
	remoteEval(%client, SetControls, true);
	Client::setControlObject(%client, %vehicle); 
	doneposs(%client);
}

BulletData SilencerBullet { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.175; damageType = $BulletDamageType; muzzleVelocity = 500.0; totalTime = 0.32; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 1.0; tracerLength = 130; }; 

BulletData ShotgunBullet { bulletShapeName = "tracer.dts"; explosionTag = ShotExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.05; damageType = $ShotgunDamageType; aimDeflection = 0.025; muzzleVelocity = 400.0; totalTime = 0.3; inheritedVelocityScale = 1.0; isVisible = true; tracerPercentage = 1.0; tracerLength = 40; }; 

BulletData TranqDart { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.16; damageType = $EnergyDamageType; muzzleVelocity = 875.0; totalTime = 3.5; inheritedVelocityScale = 0.5; isVisible = True; tracerPercentage = 1.0; tracerLength = 130; }; 

BulletData TurretBullet { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.06; damageType = $BulletDamageType; aimDeflection = 0.002; muzzleVelocity = 500.0; totalTime = 2; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 1.0; tracerLength = 60; }; 

BulletData CoolMissile { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.06; damageType = $BulletDamageType; aimDeflection = 0.002; muzzleVelocity = 3000.0; totalTime = 2; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 1.0; tracerLength = 60; }; 

BulletData FusionBolt { bulletShapeName = "fusionbolt.dts"; explosionTag = turretExp; mass = 0.05; damageClass = 0; damageValue = 0.165; damageType = $PDamageType; muzzleVelocity = 40.0; totalTime = 6.0; liveTime = 4.0; isVisible = True; rotationPeriod = 1.5; }; 

BulletData FusionBolt55 { bulletShapeName = "fusionbolt.dts"; explosionTag = turretExp; mass = 0.05; damageClass = 0; damageValue = 0.18; damageType = $PDamageType; muzzleVelocity = 52.0; totalTime = 6.0; liveTime = 4.0; isVisible = True; rotationPeriod = 1.0; }; 

BulletData MiniFusionBolt { bulletShapeName = "enbolt.dts"; explosionTag = energyExp; damageClass = 0; damageValue = 0.1; damageType = $MiniDamageType; muzzleVelocity = 80.0; totalTime = 4.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 0.25, 0.25, 1.0 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 

BulletData BlasterBolt { bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.125; damageType = $BlasterDamageType; muzzleVelocity = 300.0; totalTime = 6; liveTime = 6.5; lightRange = 5.0; lightColor = { 1.0, 0.1, 0.1 }; inheritedVelocityScale = 0.25; isVisible = True; rotationPeriod = 1; }; 

GrenadeData PlasticExp1 { bulletShapeName = "grenade.dts"; explosionTag = plasmatdfExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.3; damageClass = 1; damageValue = 0.4; damageType = $PlasmaDamageType; explosionRadius = 15.0; kickBackStrength = 50.0; maxLevelFlightDist = 40; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 0, 0 }; };

GrenadeData PuffGren1 { bulletShapeName = "grenade.dts"; explosionTag = puffExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.15; damageClass = 1; damageValue = 0.1; damageType = $BlindDamageType; explosionRadius = 60.0; kickBackStrength = 50.0; maxLevelFlightDist = 40; totalTime = 1.7; liveTime = 1.6; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 2; lightColor = { 1, 1, 0 }; };

function PuffGren1::onAdd(%this) { 
	schedule("Aoe::deployShape(" @ %this @ ", 25, $BlindDamageType, 18);", 1.5, %this);
}

GrenadeData PuffGren2 { bulletShapeName = "grenade.dts"; explosionTag = puffExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.32; damageClass = 1; damageValue = 0.1; damageType = $BlindDamageType; explosionRadius = 60.0; kickBackStrength = 50.0; maxLevelFlightDist = 90; totalTime = 1.7; liveTime = 1.6; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 2; lightColor = { 1, 1, 0 }; };

function PuffGren2::onAdd(%this) { PuffGren1::onAdd(%this); }

GrenadeData PuffGren3 { bulletShapeName = "grenade.dts"; explosionTag = puffExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.38; damageClass = 1; damageValue = 0.1; damageType = $BlindDamageType; explosionRadius = 60.0; kickBackStrength = 50.0; maxLevelFlightDist = 160; totalTime = 1.7; liveTime = 1.6; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 2; lightColor = { 1, 1, 0 }; };

function PuffGren3::onAdd(%this) { PuffGren1::onAdd(%this); }

GrenadeData ConcussionGren1 { bulletShapeName = "grenade.dts"; explosionTag = sockExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.15; damageClass = 1; damageValue = 0.14; damageType = $ElectricityDamageType; explosionRadius = 27.0; kickBackStrength = 400.0; maxLevelFlightDist = 40; totalTime = 2.3; liveTime = 2.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 1, 1 }; };

GrenadeData ConcussionGren2 { bulletShapeName = "grenade.dts"; explosionTag = sockExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.35; damageClass = 1; damageValue = 0.14; damageType = $ElectricityDamageType; explosionRadius = 27.0; kickBackStrength = 400.0; maxLevelFlightDist = 90; totalTime = 2.3; liveTime = 2.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 1, 1 }; };

GrenadeData ConcussionGren3 { bulletShapeName = "grenade.dts"; explosionTag = sockExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.42; damageClass = 1; damageValue = 0.14; damageType = $ElectricityDamageType; explosionRadius = 27.0; kickBackStrength = 400.0; maxLevelFlightDist = 160; totalTime = 2.3; liveTime = 2.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 1, 1 }; };

RocketData FlameTurretProj { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; collisionRadius = 0.0; mass = 1.0; damageClass = 1; damageValue = 0.4; damageType = $BurnEDamageType; explosionRadius = 4.2; kickBackStrength = 0.01; muzzleVelocity = 55.0; terminalVelocity = 55.0; acceleration = 4.0; totalTime = 3.2; liveTime = 3.2; lightRange = 5.0; lightColor = { 1.0, 0.3, 0.0 }; inheritedVelocityScale = 0.3; trailType = 2; trailString = "plasmabolt.dts"; smokeDist = 1.8; soundId = SoundJetLight; }; 

RocketData FlameTurretProjSmoke { bulletShapeName = "plasmatrail.dts"; explosionTag = boostSmokeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 10.0; terminalVelocity = 12.0; acceleration = 2.5; totalTime = 0.5; liveTime = 0.5; lightRange = 0.0; lightColor = { 1.0, 1.0, 1.0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "plastrail.dts"; smokeDist = 1.5; }; 

function FlameTurretProj::onAdd(%this) {
	spawnDupProj(%this, "FlameTurretProjSmoke");
}

RocketData FireGrenProj { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaGrenExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 54.0; terminalVelocity = 54.0; acceleration = 4.0; totalTime = 0.28; liveTime = 0.28; lightRange = 1.0; lightColor = { 1.0, 0.0, 0.0 }; inheritedVelocityScale = 1.0; trailType = 2; trailString = "plasmabolt.dts"; smokeDist = 1.8; }; 

GrenadeData BursterB1 { bulletShapeName = "mortar.dts"; explosionTag = plasmatdfExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.35; elasticity = 0.12; damageClass = 1; damageValue = 0.41; damageType = $PlasmaDamageType; explosionRadius = 25.0; kickBackStrength = 50.0; maxLevelFlightDist = 38; totalTime = 4.5; liveTime = 4.5; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 5; lightColor = { 1, 0, 0 }; };

function BursterB1::onAdd(%this) {
   schedule("BursterB1::boom(" @ %this @ ");",3.2,%this);
}

function BursterB1::boom(%this) {
	schedule("throwNothing(" @ %this @ ");", 1.2, %this);
	%c = Aoe::deployShape(%this, 29, $BurnDamageType, 5);
	if(%c && !$SNap) {
		$SNap = %this.client;
		dropFire(%c, 5);
	}
}

GrenadeData FireGren1 { bulletShapeName = "grenade.dts"; explosionTag = plasmatdfExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.15; damageClass = 1; damageValue = 0.4; damageType = $PlasmaDamageType; explosionRadius = 15.0; kickBackStrength = 50.0; maxLevelFlightDist = 40; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 0, 0 }; };

function FireGren1::onAdd(%this) {
   schedule("throwNothing(" @ %this @ ");",1.9,%this);
}

GrenadeData FireGren2 { bulletShapeName = "grenade.dts"; explosionTag = plasmatdfExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.34; damageClass = 1; damageValue = 0.4; damageType = $PlasmaDamageType; explosionRadius = 15.0; kickBackStrength = 50.0; maxLevelFlightDist = 90; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 0, 0 }; };

function FireGren2::onAdd(%this) { FireGren1::onAdd(%this); }

GrenadeData FireGren3 { bulletShapeName = "grenade.dts"; explosionTag = plasmatdfExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.4; damageClass = 1; damageValue = 0.4; damageType = $PlasmaDamageType; explosionRadius = 15.0; kickBackStrength = 50.0; maxLevelFlightDist = 160; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 4; lightColor = { 1, 0, 0 }; };

function FireGren3::onAdd(%this) { FireGren1::onAdd(%this); }

GrenadeData EMPgren1 { bulletShapeName = "mortar.dts"; explosionTag = EMPPulseExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.18; damageClass = 1; damageValue = 0.22; damageType = $EngineerEMPDamageType; explosionRadius = 21.0; kickBackStrength = -67.0; maxLevelFlightDist = 40; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 5; lightColor = { 0, 0, 1 }; };

GrenadeData EMPgren2 { bulletShapeName = "mortar.dts"; explosionTag = EMPPulseExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.33; damageClass = 1; damageValue = 0.22; damageType = $EngineerEMPDamageType; explosionRadius = 21.0; kickBackStrength = -67.0; maxLevelFlightDist = 80; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 5; lightColor = { 0, 0, 1 }; };

GrenadeData EMPgren3 { bulletShapeName = "mortar.dts"; explosionTag = EMPPulseExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.38; damageClass = 1; damageValue = 0.22; damageType = $EngineerEMPDamageType; explosionRadius = 21.0; kickBackStrength = -67.0; maxLevelFlightDist = 150; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 5; lightColor = { 0, 0, 1 }; };

BulletData PlasmaBolt { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.40; damageType = $PlasmaDamageType; explosionRadius = 3.8; muzzleVelocity = 50.0; totalTime = 3.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

GrenadeData FlamerBolt { bulletShapeName = "plasmatrail.dts"; explosionTag = plasmafExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 1.0; mass = 1.0; elasticity = 0.01; damageClass = 1; damageValue = 0.075; damageType = $PlasmaDamageType; explosionRadius = 13; kickBackStrength = 25.0; maxLevelFlightDist = 60; totalTime = 23; liveTime = 0.1; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "plastrail.dts"; soundId = SoundJetLight; }; 

RocketData DiscShell { bulletShapeName = "discb.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 7.5; kickBackStrength = 150.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 6.5; liveTime = 8.0; lightRange = 6.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 18; trailWidth = 0.3; soundId = SoundDiscSpin; }; 

RocketData RepairBo1t { bulletShapeName = "paint.dts"; explosionTag = nu1lExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.15; damageType = 999; explosionRadius = 2.5; kickBackStrength = 0.0; muzzleVelocity = 46.0; terminalVelocity = 46.0; acceleration = 2.0; totalTime = 0.2; liveTime = 0.2; lightRange = 5.0; lightColor = { 0.0, 1.0, 0.0 }; inheritedVelocityScale = 0.5; soundId = SoundRepairBolt; }; 

RocketData JeterShell { bulletShapeName = "rocket.dts"; explosionTag = flashExpSmall; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.32; damageType = $ExplosionDamageType; explosionRadius = 3; kickBackStrength = 70.0; muzzleVelocity = 320.0; terminalVelocity = 340.0; acceleration = 5.0; totalTime = 8; liveTime = 9.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.6; soundId = SoundJetHeavy; }; 

RocketData HDiscShell { bulletShapeName = "discb.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.33; damageType = $ExplosionDamageType; explosionRadius = 9; kickBackStrength = 110.0; muzzleVelocity = 75.0; terminalVelocity = 90.0; acceleration = 5.0; totalTime = 6.5; liveTime = 8.0; lightRange = 5.0; lightColor = { 0.1, 1.0, 0.1 }; inheritedVelocityScale = 0.5; trailType = 1; trailString = "repairadd.bmp"; trailLength = 28; trailWidth = 0.3; soundId = SoundSpinIdle; }; 

RocketData BoostSmoke1 { bulletShapeName = "rsmoke.dts"; explosionTag = boostSmokeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 27.0; terminalVelocity = 32.0; acceleration = 2.5; totalTime = 1.1; liveTime = 1.1; lightRange = 0.0; lightColor = { 1.0, 1.0, 1.0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "smoke.dts"; smokeDist = 3; }; 

RocketData BoostSmoke2 { bulletShapeName = "rsmoke.dts"; explosionTag = boostSmokeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 18.0; terminalVelocity = 23.0; acceleration = 2.5; totalTime = 0.8; liveTime = 0.8; lightRange = 0.0; lightColor = { 1.0, 1.0, 1.0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "smoke.dts"; smokeDist = 3; }; 

RocketData NullGuy { bulletShapeName = "breath.dts"; explosionTag = boostSmokeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 1.0; terminalVelocity = 1.0; acceleration = 2.0; totalTime = 1; liveTime = 1; lightRange = 0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 1; }; 

RocketData PimpinMissile { bulletShapeName = "rocket.dts"; explosionTag = nappyExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.45; damageType = $ExplosionDamageType; explosionRadius = 24; kickBackStrength = 200.0; muzzleVelocity = 70.0; terminalVelocity = 88.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.0, 0.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "plasmatrail.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

function PimpinMissile::onAdd(%this) {
	spawnDupProj(%this, "PimpinMissileBoom");
}

RocketData PimpinMissileBoom { bulletShapeName = "breath.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 60.0; terminalVelocity = 85.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 0.0; lightColor = { 1.0, 0.0, 0.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "breath.dts"; smokeDist = 1.8; }; 

SeekingMissileData AvengerMissile { bulletShapeName = "rocket.dts"; explosionTag = sockExp; collisionRadius = 1.0; mass = 2.0; damageClass = 1; damageValue = 0.45; damageType = $ExplosionDamageType; explosionRadius = 9.5; kickBackStrength = 210.0; muzzleVelocity = 70.0; terminalVelocity = 100.0; acceleration = 5.0; totalTime = 20.0; liveTime = 21.0; lightRange = 4.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.76; seekingTurningRadius = 0.0; nonSeekingTurningRadius = 5.0; proximityDist = 1.75; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.5; soundId = SoundJetHeavy; }; 

RocketData AvengerMissileSmoke { bulletShapeName = "breath.dts"; explosionTag = flashExpSmall; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 60.0; terminalVelocity = 100.0; acceleration = 5.0; totalTime = 0.2; liveTime = 0.2; lightRange = 6.0; lightColor = { 1.0, 0.3, 0.2 }; inheritedVelocityScale = 0.76; seekingTurningRadius = 0.0; nonSeekingTurningRadius = 5.0; proximityDist = 1.5; trailType = 2; trailString = "smoke.dts"; smokeDist = 1.8; };

RocketData HandRocket { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.36; damageType = $ExplosionDamageType; explosionRadius = 15; kickBackStrength = 225.0; muzzleVelocity = 52.0; terminalVelocity = 85.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.65; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

RocketData HandRocketSmoke { bulletShapeName = "breath.dts"; explosionTag = flashExpMedium; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 52.0; terminalVelocity = 85.0; acceleration = 5.0; totalTime = 0.2; liveTime = 0.2; lightRange = 6.0; lightColor = { 1.0, 0.3, 0.2 }; inheritedVelocityScale = 0.65; trailType = 2; trailString = "smoke.dts"; smokeDist = 1.8; };

GrenadeData NewPGren1 { bulletShapeName = "grenade.dts"; explosionTag = puffQExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.3; damageClass = 1; damageValue = 0.01; damageType = $SmallEnergyDamageType; explosionRadius = 20.0; kickBackStrength = 50.0; maxLevelFlightDist = 90; totalTime = 2.1; liveTime = 2.1; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 6; lightColor = { 1, 1, 0 }; };

function NewPGren1::onAdd(%this) {
	schedule("Aoe::deployShape(" @ %this @ ", 25, $SmallEnergyDamageType, 8);", 2, %this);
}

GrenadeData NewGren1 { bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.14; damageClass = 1; damageValue = 0.5; damageType = $ShrapnelDamageType; explosionRadius = 11.0; kickBackStrength = 200.0; maxLevelFlightDist = 40; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 1; smokeName = "breath.dts"; lightRange = 1.4; lightColor = { 1, 1, 1 }; };

GrenadeData NewGren2 { bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.34; damageClass = 1; damageValue = 0.5; damageType = $ShrapnelDamageType; explosionRadius = 11.0; kickBackStrength = 200.0; maxLevelFlightDist = 90; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 1; smokeName = "breath.dts"; lightRange = 1.4; lightColor = { 1, 1, 1 }; };

GrenadeData NewGren3 { bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.3; elasticity = 0.4; damageClass = 1; damageValue = 0.5; damageType = $ShrapnelDamageType; explosionRadius = 11.0; kickBackStrength = 200.0; maxLevelFlightDist = 160; totalTime = 2.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 1; smokeName = "breath.dts"; lightRange = 1.4; lightColor = { 1, 1, 1 }; };

RocketData StingerMissile { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.39; damageType = $ExplosionDamageType; explosionRadius = 15; kickBackStrength = 225.0; muzzleVelocity = 52.0; terminalVelocity = 90.0; acceleration = 5.0; totalTime = 10; liveTime = 12.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.8; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

GrenadeData GrenadeShell { bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 0.38; damageType = $ShrapnelDamageType; explosionRadius = 14; kickBackStrength = 150.0; maxLevelFlightDist = 150; totalTime = 30.0; liveTime = 1.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; }; 

GrenadeData EMPShock { bulletShapeName = "breath.dts"; explosionTag = nullExp; collideWithOwner = false; ownerGraceMS = 500; collisionRadius = 0.0; mass = 0.0; elasticity = 0.1; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 1; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 0.05; liveTime = 0.05; projSpecialTime = 0.05; inheritedVelocityScale = 1.0; smokeName = "breath.dts"; }; 

GrenadeData TeleEffect { bulletShapeName = "breath.dts"; explosionTag = bullExp; collideWithOwner = false; ownerGraceMS = 500; collisionRadius = 0.0; mass = 0.0; elasticity = 0.1; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 1; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 0.05; liveTime = 0.05; projSpecialTime = 0.05; inheritedVelocityScale = 1.0; smokeName = "breath.dts"; }; 

GrenadeData BurnEffect { bulletShapeName = "breath.dts"; explosionTag = nul11Exp; collideWithOwner = false; ownerGraceMS = 500; collisionRadius = 0.0; mass = 0.0; elasticity = 0.1; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 1; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 0.05; liveTime = 0.05; projSpecialTime = 0.05; inheritedVelocityScale = 1.0; smokeName = "breath.dts"; }; 

GrenadeData PoisonEffect { bulletShapeName = "breath.dts"; explosionTag = nu11Exp; collideWithOwner = false; ownerGraceMS = 500; collisionRadius = 0.0; mass = 0.0; elasticity = 0.1; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 1; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 0.05; liveTime = 0.05; projSpecialTime = 0.05; inheritedVelocityScale = 1.0; smokeName = "breath.dts"; }; 

GrenadeData ArmChan { bulletShapeName = "rsmoke.dts"; explosionTag = armChanExp; collideWithOwner = false; ownerGraceMS = 500; collisionRadius = 0.0; mass = 0.0; elasticity = 0.1; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 1; kickBackStrength = 0.0; maxLevelFlightDist = 4; totalTime = 0.55; liveTime = 0.55; projSpecialTime = 0.05; inheritedVelocityScale = 1.0; smokeName = "rsmoke.dts"; }; 

GrenadeData MortarBomb1 { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.4; elasticity = 0.14; damageClass = 1; damageValue = 0.886; damageType = $MortarDamageType; explosionRadius = 17.0; kickBackStrength = 275.0; maxLevelFlightDist = 40; totalTime = 3.2; liveTime = 3.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 1.8; lightColor = { 1, 0, 0 }; };

GrenadeData MortarBomb2 { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.4; elasticity = 0.30; damageClass = 1; damageValue = 0.886; damageType = $MortarDamageType; explosionRadius = 17.0; kickBackStrength = 275.0; maxLevelFlightDist = 80; totalTime = 3.2; liveTime = 3.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 1.8; lightColor = { 1, 0, 0 }; };

GrenadeData MortarBomb3 { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.1; mass = 0.4; elasticity = 0.35; damageClass = 1; damageValue = 0.886; damageType = $MortarDamageType; explosionRadius = 17.0; kickBackStrength = 275.0; maxLevelFlightDist = 140; totalTime = 3.2; liveTime = 3.2; projSpecialTime = 0.01; inheritedVelocityScale = 0.9; smokeName = "breath.dts"; lightRange = 1.8; lightColor = { 1, 0, 0 }; };

GrenadeData MortarShell { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 1.0; damageType = $MortarDamageType; explosionRadius = 20.0; kickBackStrength = 265.0; maxLevelFlightDist = 275; totalTime = 30.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.5; smokeName = "mortartrail.dts"; }; 

GrenadeData MortarTurretShell { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 400; collisionRadius = 1.0; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 1.32; damageType = $MortarDamageType; explosionRadius = 30.0; kickBackStrength = 250.0; maxLevelFlightDist = 400; totalTime = 1000.0; liveTime = 2.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "mortartrail.dts"; }; 

GrenadeData EMPGrenadeShell { bulletShapeName = "mortar.dts"; explosionTag = EMPPulseExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 0.04; damageType = $EMPDamageType; explosionRadius = 26; kickBackStrength = -100.0; maxLevelFlightDist = 275; totalTime = 30.0; liveTime = 0.25; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "fusionbolt.dts"; soundId = SoundELFFire; }; 

function EMPGrenadeShell::onAdd(%this) {
   spawnDupProj(%this, "EMPEffect");
}

function spawnDupProj(%this, %type) {
   spawnProj(%type, GameBase::getRotation(%this), GameBase::getPosition(%this), Item::getVelocity(getPlayer(%this)), 2048);
}

function getPlayer(%this) {
  	%set = newObject("set",SimSet);
	%backward = Vector::neg(Vector::getFromRot(GameBase::getRotation(%this), 1));  
	%num = containerBoxFillSet(%set, $SimPlayerObjectType, Vector::add(GameBase::getPosition(%this), %backward), 0.1, 0.1, 0.1, 0);
   if (%num != 1) {
	   deleteObject(%set);
		return false;
	}
	%p = Group::getObject(%set, 0);
   deleteObject(%set);
	return %p;
}

GrenadeData EMPEffect { bulletShapeName = "breath.dts"; explosionTag = empExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.0; maxLevelFlightDist = 275; totalTime = 30.0; liveTime = 0.25; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "breath.dts"; }; 

GrenadeData RailEffect { bulletShapeName = "breath.dts"; explosionTag = empExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 100.0; elasticity = 0.01; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 0.01; liveTime = 0.01; projSpecialTime = 0.05; inheritedVelocityScale = 1; smokeName = "breath.dts"; }; 

GrenadeData EMPTurretShell { bulletShapeName = "mortar.dts"; explosionTag = Shockwave; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 995.0; elasticity = 0.01; damageClass = 1; damageValue = 0.10; damageType = $FlashDamageType; explosionRadius = 30.0; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.01; smokeName = "fusionbolt.dts"; }; 

GrenadeData EMPTurretShellEffect { bulletShapeName = "breath.dts"; explosionTag = empExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 995.0; elasticity = 0.01; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 1; smokeName = "breath.dts"; }; 

function EMPTurretShell::onAdd(%this) {
   spawnDupProj(%this, "EMPEffect");
}

GrenadeData SatchelShell { bulletShapeName = "grenade.dts"; explosionTag = rocketExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 2.5; damageType = $MortarDamageType; explosionRadius = 30; kickBackStrength = 350.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; }; 

RocketData FlierRocket { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.45; damageType = $ExplosionDamageType; explosionRadius = 9; kickBackStrength = 300.0; muzzleVelocity = 85.0; terminalVelocity = 90.0; acceleration = 5.0; totalTime = 9.0; liveTime = 10.0; lightRange = 5.0; lightColor = { 1.0, 0.5, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

BulletData MiniFlierRocket {
   bulletShapeName    = "rocket.dts";
   explosionTag       = debrisExpMedium;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 1;
   damageValue        = 0.13;
   damageType         = $ExplosionDamageType;
   explosionRadius = 3;
   kickBackStrength = 90.0;
   aimDeflection      = 0.025;
   muzzleVelocity     = 95.0;
   totalTime          = 2.75;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
   tracerPercentage   = 0.0;
   tracerLength       = 0;
};

SeekingMissileData LilTurretMissi1e { bulletShapeName = "rocket.dts"; explosionTag = ggrocketExp; collisionRadius = 1.0; mass = 2.0; damageClass = 1; damageValue = 0.2; damageType = $AAExplosionDamageType; explosionRadius = 7; kickBackStrength = 80.0; muzzleVelocity = 115.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 0.5; nonSeekingTurningRadius = 1.0; proximityDist = 1.0; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.0; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData LilTurretMissi1eSmoke { bulletShapeName = "breath.dts"; explosionTag = flashExpMedium; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 115.0; totalTime = 0.2; liveTime = 0.2; seekingTurningRadius = 0.5; nonSeekingTurningRadius = 1.0; proximityDist = 1.0; lightRange = 6.0; lightColor = { 1.0, 0.3, 0.2 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "smoke.dts"; smokeDist = 1.0; };

SeekingMissileData TurretMissile { bulletShapeName = "rocket.dts"; explosionTag = SockExp; collisionRadius = 1.0; mass = 2.0; damageClass = 1; damageValue = 0.52; damageType = $MExplosionDamageType; explosionRadius = 16; kickBackStrength = 220.0; muzzleVelocity = 78.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 1.8; nonSeekingTurningRadius = 30.0; proximityDist = 1.75; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.75; lightRange = 4.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

SeekingMissileData TurretMissileSmoke { bulletShapeName = "breath.dts"; explosionTag = flashExpMedium; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 70.0; totalTime = 0.2; liveTime = 0.2; seekingTurningRadius = 1.8; nonSeekingTurningRadius = 5.0; proximityDist = 1.75; trailType = 2; trailString = "smoke.dts"; smokeDist = 1.75; lightRange = 5.0; lightColor = { 1, 1, 1 }; inheritedVelocityScale = 0.5; }; 

function TurretMissile::onAdd(%this) {
   saveLock(%this, "TurretMissile");
}

function saveLock(%this, %data) {
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, GameBase::getPosition(%this), 3, 3, 3, 1);
   %rt = false;
   for(%i=0; %i<%num; %i++) {
      %obj = Group::getObject(%set,%i);
      %name = GameBase::getDataName(%obj);
      if ( %name == "RocketTurret" || %name == "DeployableRocket" || %name == "RockT" ) {
         %rt = %obj;
         break;
      }
   }
   deleteObject(%set);
   if (%rt == false) return;
 
   %this.lockTrans = GameBase::getMuzzleTransform(%rt);
   %this.shooterObject = %rt;
   %this.lockDataName = %data;

   %target = %rt.lockedTarget;
   %target.locks = %target.locks @ %this @ " ";

   %vel = Item::getVelocity(%rt);
   Projectile::spawnProjectile(%data @ "Smoke", %this.lockTrans, %rt, %vel, %target);

   if (%target.lastThrownFlare != "")
      schedule("transferMissileLocks(" @ %target @ ", " @ %target.lastThrownFlare @ ");", 0.3, %target.lastThrownFlare);
}

SeekingMissileData FlierRocketLock { bulletShapeName = "rocket.dts"; explosionTag = SockExp; collisionRadius = 1.0; mass = 2.0; damageClass = 1; damageValue = 0.46; damageType = $ExplosionDamageType; explosionRadius = 7; kickBackStrength = 250.0; muzzleVelocity = 125.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 6; nonSeekingTurningRadius = 50.0; proximityDist = 1.0; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; lightRange = 5.0; lightColor = { 1.0, 0.5, 1.0 }; inheritedVelocityScale = 0.8; soundId = SoundJetHeavy; }; 

function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 

RocketData Shock { bulletShapeName = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.02; damageType = $ExplosionDamageType; explosionRadius = 30.0; kickBackStrength = 550.0; muzzleVelocity = 50.0; terminalVelocity = 80.0; acceleration = 4.5; totalTime = 6.0; liveTime = 4.0; lightRange = 10.0; lightColor = { 0.0, 0.0, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData SniperRound { bulletShapeName = "breath.dts"; explosionTag = sniperbulletExp; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.56; damageType = $SniperDamageType; explosionRadius = 0.1; kickBackStrength = 700.0; muzzleVelocity = 2500.0; terminalVelocity = 2500.0; acceleration = 3.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; soundId = SoundJetHeavy; }; 

RocketData RailRound { bulletShapeName = "bullet.dts"; explosionTag = RailExp; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.4; damageType = $RailDamageType; explosionRadius = 0.1; kickBackStrength = 900.0; muzzleVelocity = 1000.0; terminalVelocity = 2000.0; acceleration = 3.0; totalTime = 10.0; liveTime = 11.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 1; trailLength = 1000; trailWidth = 1; soundId = SoundJetHeavy; }; 

RocketData IonBolt { bulletShapeName = "enbolt.dts"; explosionTag = l1ll1Exp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.2; damageType = $ElectricityDamageType; explosionRadius = 2; kickBackStrength = 95.0; muzzleVelocity = 170.0; terminalVelocity = 170.0; acceleration = 2.5; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.0, 0.0, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 5; trailWidth = 0.5; soundId = SoundJetHeavy; }; 

LaserData WatchdogLaser {  
	laserBitmapName   = "paintPulse.bmp";
  	hitName           = "laserhit.dts";
  	damageConversion  = 0.0;
  	baseDamageType    = $LaserDamageType;
  	beamTime          = 1.3;
	lightRange        = 5.0;
  	lightColor        = { 0.15, 1.0, 0.15 };
  	detachFromShooter = false;
	hitSoundId        = SoundTaserHit;
};

LaserData turretElaser { laserBitmapName = "repairadd.bmp"; hitName = "laserhit.dts"; damageConversion = 0.0075; baseDamageType = $LaserEDamageType; beamTime = 2.2; lightRange = 2.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = false; hitSoundId = SoundLaserHit; };

LaserData turretlaser { laserBitmapName = "laserPulse.bmp"; hitName = "laserhit.dts"; damageConversion = 0.008; baseDamageType = $LaserDamageType; beamTime = 1.75; lightRange = 2.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = false; hitSoundId = SoundLaserHit; };

LaserData wiperLaser { laserBitmapName = "laserPulse.bmp"; hitName = "laserhit.dts"; damageConversion = 0.008; baseDamageType = $LaserDamageType; beamTime = 1.0; lightRange = 6.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = true; hitSoundId = SoundTaserHit; }; 

LaserData sniperLaser { laserBitmapName = "repairadd.bmp"; hitName = "laserhit.dts"; damageConversion = 0.016; baseDamageType = $LaserDamageType; beamTime = 1.2; lightRange = 12.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = true; hitSoundId = SoundLaserHit; }; 

LaserData railLaser { laserBitmapName = "lightningNew.bmp"; hitName = "laserhit.dts"; damageConversion = 0.0085; baseDamageType = $SniperDamageType; beamTime = 2.7; lightRange = 25.0; lightColor = { 0.15, 0.15, 1 }; detachFromShooter = true; hitSoundId = SoundLaserHit; };

TargetLaserData targetLaser { laserBitmapName = "grn_blink1.bmp"; damageConversion = 0.0; baseDamageType = 0; lightRange = 2.0; lightColor = { 0.25, 1.0, 0.25 }; detachFromShooter = false; }; 

LightningData lightningCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.045; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

SeekingMissileData TurretMissi1e { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 1.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MExplosionDamageType; explosionRadius = 11; kickBackStrength = 187.0; muzzleVelocity = 75.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 2.5; nonSeekingTurningRadius = 45.0; proximityDist = 1.75; smokeDist = 1.75; lightRange = 4.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

SeekingMissileData TurretMissi1eSmoke { bulletShapeName = "breath.dts"; explosionTag = flashExpMedium; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 68.0; totalTime = 0.2; liveTime = 0.2; seekingTurningRadius = 2.5; nonSeekingTurningRadius = 10.0; proximityDist = 1.75; smokeDist = 1.75; lightRange = 5.0; lightColor = { 1, 1, 1 }; inheritedVelocityScale = 0.5; }; 

function TurretMissi1e::onAdd(%this) {
   saveLock(%this, "TurretMissi1e");
}

BulletData FusionBo1t { bulletShapeName = "fusionbolt.dts"; explosionTag = turretExp; mass = 0.05; damageClass = 0; damageValue = 0.1465; damageType = $PDamageType; muzzleVelocity = 40.0; totalTime = 6.0; liveTime = 4.0; isVisible = True; rotationPeriod = 1.5; }; 

RocketData IonEBolt { bulletShapeName = "enbolt.dts"; explosionTag = turretExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.12; damageType = $ElectricityEDamageType; explosionRadius = 4.2; kickBackStrength = 20.0; muzzleVelocity = 140.0; terminalVelocity = 170.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.2, 0.2 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 30; trailWidth = 0.3; soundId = SoundJetHeavy; }; 

RocketData IonEEBolt { bulletShapeName = "breath.dts"; explosionTag = turret1Exp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.07; damageType = $TracDamageType; explosionRadius = 4.2; kickBackStrength = -355.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.2, 1.0, 0.2 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 130; trailWidth = 0.5; soundId = SoundJetHeavy; }; 

LightningData lightningECharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityLEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.045; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData turretECharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.12; energyDrainPerSec = 65.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData HavocStrike0 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 330.0; coneAngle = 35.0; damagePerSec = 0.005; energyDrainPerSec = 0.0001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.08; lightRange = 40.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData HavocStrike { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 310.0; coneAngle = 35.0; damagePerSec = 0.125; energyDrainPerSec = 0.001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.08; lightRange = 40.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData HavocStrike1 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 320.0; coneAngle = 35.0; damagePerSec = 0.11; energyDrainPerSec = 0.001; segmentDivisions = 4; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.05; lightRange = 30.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData HavocStrike2 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 320.0; coneAngle = 35.0; damagePerSec = 0.177; energyDrainPerSec = 0.001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.5; updateTime = 30; skipPercent = 0.5; displaceBias = 0.07; lightRange = 50.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData lightningCharge2 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 50.0; coneAngle = 35.0; damagePerSec = 0.045; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData turretCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData boltCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 60.0; coneAngle = 35.0; damagePerSec = 0.06; energyDrainPerSec = 80.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.25, 0.25, 1 }; soundId = SoundELFFire; }; 

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) { 

%damVal = %timeSlice * %damPerSec; %enVal = %timeSlice * %enDrainPerSec; 

if (%damPerSec == 0.119997 || %damPerSec == 0.0449997 || %damPerSec == 0.0999997)
	GameBase::applyDamage(%target, $ElectricityTEDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else if(%damPerSec == 0.125 || %damPerSec == 0.176997)
	GameBase::applyDamage(%target, $Lit2DamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else if(%damPerSec == 0.109997)
	GameBase::applyDamage(%target, $LitDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); 

%ot = getObjectType(%target);
if (%ot == "Turret" || %ot == "Sensor") %enVal *= 0.22;

%energy = GameBase::getEnergy(%target); %energy = %energy - %enVal; if (%energy < 0) { %energy = 0; } GameBase::setEnergy(%target, %energy); 

}

LightningData targetpull { bitmapName = "trailadd.bmp"; damageType = 0; boltLength = 100.0; coneAngle = 25.0; damagePerSec = 0.0; energyDrainPerSec = 0.0; segmentDivisions = 5; numSegments = 1; beamWidth = 0.3; updateTime = 300; skipPercent = 0.5; displaceBias = 0.0; lightRange = 5.0; lightColor = { 0.25, 1, 0.25 }; }; 

function targetpull::damageTarget(%obj, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %client) {	
	%type = getObjectType(%obj);
	if(%type == "Mine") return;
	%pos = GameBase::getPosition(%client);
	%oPos = GameBase::getPosition(%obj);
	%hdist = getWord(%oPos, 2) - getWord(%pos, 2);
	%rot = GameBase::getRotation(%client);
	if(%type == "Player") {
		if(Client::getTeam(%client) == Client::getTeam(%obj)) return;
		%rot = getWord(%rot, 0) @ " " @ getWord(%rot, 1) @ " " @ 3.14 + getWord(%rot, 2);
		%hdist = -%hdist;
		%dmod = 10;
		%hmod = 12;
	} else {
		%dmod = 26;
		%hmod = 26;
	}
	%flatPos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " 0";
	%oFlatPos = getWord(%oPos, 0) @ " " @ getWord(%oPos, 1) @ " 0";
	%dist = Vector::getDistance(%flatPos, %oFlatPos); 
	%force = (%dist / 100) * %dmod; 
	%height = (%hdist / 100) * %hmod;
	%diffVector = Vector::getFromRot(%rot, %force, %height);
	if(%type == "Player") 
		Player::applyImpulse(%obj, %diffVector);
	else
		Item::setVelocity(%client, %diffVector);
}		

LightningData ttargetpull { bitmapName = "lightningNewSub.bmp"; damageType = 0; boltLength = 80.0; coneAngle = 32.0; damagePerSec = 0.0; energyDrainPerSec = 0.0; segmentDivisions = 5; numSegments = 1; beamWidth = 0.25; updateTime = 350; skipPercent = 0.5; displaceBias = 0.0; lightRange = 5.0; lightColor = { 1, 0.25, 0.25 }; }; 

function abs(%val) {
	if(%val < 0)
		return -%val;
	else
		return %val;
}

function ttargetpull::damageTarget(%obj, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %client) {	
	%type = getObjectType(%obj);
	if(%type == "Mine" || %type == "Player") return;
	%pos = GameBase::getPosition(%client);
	%oPos = GameBase::getPosition(%obj);
	%hdist = getWord(%oPos, 2) - getWord(%pos, 2);
	%rot = GameBase::getRotation(%client);
	%flatPos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " 0";
	%oFlatPos = getWord(%oPos, 0) @ " " @ getWord(%oPos, 1) @ " 0";
	%dist = Vector::getDistance(%flatPos, %oFlatPos); 
	%curVel = Item::getVelocity(%client);
	%force = ((%dist / 75) * 20) + 4.8;
	if ( %force < 15 && %force > 11 ) %force = 11;
	if(%hdist > 0) %height = ((%hdist / 75) * 22) + 5;
	%addVel = Vector::getFromRot(%rot, %force, %height);
	%newXvel = getword(%addVel, 0) + getword(%curVel, 0);
	if(abs(%newXvel) > 28)
		%addVel = getword(%addVel, 0) - getword(%curVel, 0) @ " " @ getword(%addVel, 1) @ " " @ getword(%addVel, 2);
	%newYvel = getword(%addVel, 1) + getword(%curVel, 1);
	if(abs(%newYvel > 28))
		%addVel = getword(%addVel, 0) @ " " @ getword(%addVel, 1) - getword(%curVel, 1) @ " " @ getword(%addVel, 2);
	%newZvel = getword(%addVel, 2) + getword(%curVel, 2);
	if(%newZvel > 50)
		%addVel = getword(%addVel, 0) @ " " @ getword(%addVel, 1) @ " " @ getword(%addVel, 2) - getword(%curVel, 2);
	Player::applyImpulse(%client, %addVel);
}		

LightningData missilePrep {
	bitmapName       = "lightningNew.bmp";
   	boltLength       = 500.0;
   	coneAngle        = 13.0;
   	damagePerSec = 0;
   	energyDrainPerSec = 0;
   	segmentDivisions = 0;
   	numSegments = 1;
   	beamWidth = 0.25;
   	updateTime   = 300;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   	lightRange = 0.0;
   	lightColor = { 0.0, 0.0, 0.0 };
   	isVisible = false;
};
function missilePrep::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) {
	%player = Client::getControlObject(%shooterId);
	%data = getObjectType(%target);
	if(%data == "Player" || %data == "Flier") {
		if(!%player.vehicle || (%target.vehicle != %player.vehicle && %target != %player.vehicle))
			%shooterId.targetLock = %target;
		else
			%shooterId.targetLock = 0;
	} else
		%shooterId.targetLock = 0;
}


LightningData missileSearch {
	bitmapName       = "lightningNew.bmp";
   	boltLength       = 500.0;
   	coneAngle        = 15.0;
   	damagePerSec = 0;
   	energyDrainPerSec = 0;
   	segmentDivisions = 0;
   	numSegments = 1;
   	beamWidth = 0.25;
   	updateTime   = 30;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   	lightRange = 0.0;
   	lightColor = { 0.0, 0.0, 0.0 };
   	isVisible = false;
};
function missileSearch::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) {
	if(getObjectType(%target) == "Flier" && GameBase::getDataName(%target).shapeFile == "rocket") {
		%shooterId.targetLock = %target;
	}
}


BulletData FlierChaingunBullet {
	bulletShapeName    = "bullet.dts";
   	explosionTag       = bulletExp0;
   	expRandCycle       = 3;
   	mass               = 0.05;
   	bulletHoleIndex    = 0;
   	damageClass        = 0;
   	damageValue        = 0.06;
   	damageType         = $BulletDamageType;
   	aimDeflection      = 0.005;
   	muzzleVelocity     = 600.0;
   	totalTime          = 1.5;
   	inheritedVelocityScale = 1.0;
   	isVisible          = false;
   	tracerPercentage   = 1.0;
   	tracerLength       = 30;
};

RepairEffectData RepairBolt { bitmapName = "repairadd.bmp"; boltLength = 6.5; segmentDivisions = 4; beamWidth = 0.125; updateTime = 350; skipPercent = 0.6; displaceBias = 0.12; lightRange = 0.75; lightColor = { 1.0, 0.25, 0.25 }; }; 

function RepairBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (%target == %player) { %player.repairTarget = -1; if (GameBase::getDamageLevel(%player) != 0) { %player.repairRate = 0.05; %player.repairTarget = %player; Client::sendMessage(%client, 0, "AutoRepair On"); } else { Client::sendMessage(%client,0,"Nothing in range"); Player::trigger(%player, $WeaponSlot, false); return; } } else { %player.repairTarget = %target; %player.repairRate = 0.1; if (getObjectType(%player.repairTarget) == "Player") { %rclient = Player::getClient(%player.repairTarget); %name = Client::getName(%rclient); } else { %name = GameBase::getMapName(%target); if(%name == "") { %name = (GameBase::getDataName(%player.repairTarget)).description; } } if (GameBase::getDamageLevel(%player.repairTarget) == 0) { Client::sendMessage(%client,0,%name @ " is not damaged"); Player::trigger(%player,$WeaponSlot,false); %player.repairTarget = -1; return; } if (getObjectType(%player.repairTarget) == "Player") { Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client)); } Client::sendMessage(%client,0,"Repairing " @ %name); } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget,%rate); } $VehicleToItem[Dr] = Plas; function RepairBolt::onRelease(%this, %player) { %object = %player.repairTarget; if (%object != -1) { %client = Player::getClient(%player); if (%object == %player) { Client::sendMessage(%client,0,"AutoRepair Off"); } else { if (GameBase::getDamageLevel(%object) == 0) { Client::sendMessage(%client,0,"Repair Done"); } else { Client::sendMessage(%client,0,"Repair Stopped"); } } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object,%rate); } }

function RepairBolt::checkDone(%this, %player) { if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) { %object = %player.repairTarget; if (%object == %player) { if (GameBase::getDamageLevel(%player) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } else { if (GameBase::getDamageLevel(%object) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } } } 

RepairEffectData RepairItemBolt { bitmapName = "blue_blink0.bmp"; boltLength = 5.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 450; skipPercent = 0.6; displaceBias = 0.15; lightRange = 15.0; lightColor = { 1, 0.25, 0.25 }; }; 

function RepairItemBolt::onAcquire(%this, %player, %target) { 
	%client = Player::getClient(%player); 

	if (GameBase::getDamageLevel(%target) == 0) { 
		GameBase::repairDamage(%player,0.20); 
		if(%client.poisonTime > 0) {
			%client.poisonTime = -10; 
		}
		if(%client.empTime > 2) %client.empTime = 2;
		Player::decItemCount(%player,"RepairKit");
		return; 
	} 

	%name = GameBase::getMapName(%target); 
	if(%name == "") { 
		%name = (GameBase::getDataName(%target)).description; 
	} 

	Player::decItemCount(%player,"RepairKit");
	
	Client::sendMessage(%client,0,"Repair Kit used on " @ %name); 

	GameBase::repairDamage(%target,0.27); 
	return; 
} 

RepairEffectData PowerItemBolt { bitmapName = "lightningNew.bmp"; boltLength = 9.0; segmentDivisions = 2; beamWidth = 0.27; updateTime = 100; skipPercent = 0.5; displaceBias = 0.03; lightRange = 6.0; lightColor = { 0.25, 0.25, 1.0 }; }; 

function PowerItemBolt::onAcquire(%this, %player, %target) { 
	%client = Player::getClient(%player); 
	%player.powerTarget = "";
	%objType = getObjectType(%target);
	if(%objType == "Player") {
		if(%target == %player) {
			Client::sendMessage(%client,0,"Nothing to power in range"); 
			Player::trigger(%player, $WeaponSlot, false); 
			return;
		}
		%tc = Player::getClient(%target);
		if(%tc.isPowered) {
			Player::trigger(%player, $WeaponSlot, false); 
			return;
		}
		Client::sendMessage(%client,0, "Enhancing energy systems of " @ Client::getName(%tc)); 
		Client::sendMessage(%tc,0, "Energy systems being enhanced by " @ Client::getName(%client)); 
		%tc.isPowered = true;
		%player.powerTarget = %target;
		GameBase::setRechargeRate(%target, 20);		
		return;
	} else if(%objType == "Flier") {
		%player.powerTarget = %target; 
		%target.shieldStrength = 0.019;
		Client::sendMessage(%client,0, "Shielding " @ $VehicleToItem[GameBase::getDataName(%target)].description); 
		return;
	}
	%obj = GameBase::getDataName(%target);
	if (GameBase::getDamageState(%target) != "Enabled") { 
		Client::sendMessage(%client,0, %obj.description @ " is damaged"); 
		Player::trigger(%player, $WeaponSlot, false); 
		return;
	}
	if(GameBase::isPowered(%target)) {
		Client::sendMessage(%client,0, %obj.description @ " is already powered"); 
		Player::trigger(%player, $WeaponSlot, false); 
		return;
	}
	if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") {
		%player.powerTarget = %target; 
		Client::sendMessage(%client,0, "Powering " @ %obj.description); 
		GameBase::playSequence(%target,0,"power");
		GameBase::playSequence(%target,1);
		%target.freeP = true;
	} else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
		%player.powerTarget = %target; 
		Client::sendMessage(%client,0, "Powering " @ %obj.description); 
		%target.shieldStrength = 0.03;
		GameBase::setRechargeRate(%target,10); 
		GameBase::setActive(%target, true);
		GameBase::playSequence(%target,0,"power");
	} else if(%obj == "DeployableTeleport") {
		%player.powerTarget = %target; 
		%target.freeP = true;
		Client::sendMessage(%client,0, "Enhancing teleporter energy systems"); 
	} else {
		Client::sendMessage(%client,0,"Nothing to power in range"); 
		Player::trigger(%player, $WeaponSlot, false); 
	}
} 

function PowerItemBolt::onRelease(%this, %player) { 
	if (%player.powerTarget != "") { 
		%objType = getObjectType(%player.powerTarget);
		if(%objType == "Flier") {
			%player.powerTarget.shieldStrength = 0.0;		
			%player.powerTarget = "";
			return;
		} else if(%objType == "Player") {
			Player::getClient(%player.powerTarget).isPowered = false;
   		if(%player.powerTarget.rejuv != 1)
            GameBase::setRechargeRate(%player.powerTarget, 8);
         else
            GameBase::setRechargeRate(%player.powerTarget, 0);
			%player.powerTarget = "";
			return;
		}
		if(!GameBase::isPowered(%player.powerTarget)) {
			%obj = GameBase::getDataName(%player.powerTarget);
			if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") {
				(%player.powerTarget).freeP = false;
				Station::weaponCheck(%player.powerTarget);
				GameBase::stopSequence(%player.powerTarget,0);
				GameBase::setSequenceDirection(%player.powerTarget,1,0);
				GameBase::pauseSequence(%player.powerTarget,1);
				GameBase::stopSequence(%player.powerTarget,2);
				Station::checkTarget(%player.powerTarget);			
				%obj = (%player.powerTarget).lastPlayer; 
				if(%player.powerTarget == %obj.inStation) %obj.inStation = false;
			} else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor") {
				GameBase::setActive(%player.powerTarget, false);
				(%player.powerTarget).shieldStrength = 0; 
				GameBase::setRechargeRate(%player.powerTarget,0); 
				GameBase::pauseSequence(%player.powerTarget,0); 
				Turret::checkOperator(%player.powerTarget);
			} else if(%obj == "DeployableTeleport") {
				(%player.powerTarget).freeP = false;				
			}
		}		
		%player.powerTarget = "";
	} 
}

RocketData Napalm1 { bulletShapeName = "plasmatrail.dts"; explosionTag = boostSmokeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 0.01; muzzleVelocity = 20.0; terminalVelocity = 20.0; acceleration = 4.0; totalTime = 0.33; liveTime = 0.33; lightRange = 1.0; lightColor = { 1.0, 0.0, 0.0 }; inheritedVelocityScale = 1.0; trailType = 2; trailString = "plastrail.dts"; smokeDist = 1.8; soundId = SoundJetLight; };

GrenadeData Napalm2 { bulletShapeName = "plasmatrail.dts"; explosionTag = plasmafExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 1.0; mass = 1.0; elasticity = 0.01; damageClass = 1; damageValue = 0.01; damageType = $NullDamageType; explosionRadius = 0.01; kickBackStrength = 25.0; maxLevelFlightDist = 40; totalTime = 3; liveTime = 0.1; projSpecialTime = 0.08; inheritedVelocityScale = 0.75; smokeName = "plastrail.dts"; soundId = SoundJetLight; };

RocketData StingerEMissile { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.35; damageType = $ExplosionDamageType; explosionRadius = 16; kickBackStrength = 200.0; muzzleVelocity = 50.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10; liveTime = 12.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.8; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

