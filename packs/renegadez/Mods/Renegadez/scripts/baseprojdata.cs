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
$AlarmDamageType = 16;
//Weather Stuff
$MeteorDamageType      = 24;
$EMPLightningDamageType= 25;
$SolarFlareDamageType  = 26;
$LightningDamageType   = 28;

BulletData BaseAlarmProj 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = fakeExp; 
mass = 0.05; 
collisionRadius = 0.0; 
bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.01; 
damageType = $AlarmDamageType; 
aimDeflection = 0.0; 
muzzleVelocity = 2000.0; 
totalTime = 1; 
inheritedVelocityScale = 0.1; 
isVisible = true; 
lightRange = 0.75; 
lightColor = { 0.4, 0.4, 0.4 }; 
tracerPercentage = 1.0; 
tracerLength = 1; 
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
   explosionTag     = LargeShockwave;

   //damageConversion  = 0.151;
   damageValue       = 10.0;
   damageclass=0;
   //explosionRadius = 50;
   baseDamageType    = $LightningDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.0 };

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
   lightColor         = { 0, 1, 0 };
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
   lightColor         = { 0, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData HDiscShell 
{ 
	bulletShapeName = "discb.dts"; 
	explosionTag = rocketExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.33; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 9; 
	kickBackStrength = 110.0; 
	muzzleVelocity = 75.0; 
	terminalVelocity = 90.0; 
	acceleration = 5.0; 
	totalTime = 6.5; 
	liveTime = 8.0; 
	lightRange = 5.0; 
	lightColor = { 0.1, 1.0, 0.1 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailString = "repairadd.bmp"; 
	trailLength = 28; 
	trailWidth = 0.3; 
	soundId = SoundSpinIdle; 
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

LightningData JailBolt
{	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 10.0;
	coneAngle = 1.0;
	damagePerSec = 0.01;
	energyDrainPerSec = 60.0;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target.jaildamage)
		return;
	else
		%target.jaildamage = true;
	%team = GameBase::getTeam(%shooterId);
	%aclient = Player::getClient(%target);
	if(getObjectType(%target) != "Player")
		return;
	if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
		return;
	%teleset = nameToID("MissionCleanup/JailPorts" @ %team);
	%playerTeam = GameBase::getTeam(%target);
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{	
		%oteam=GameBase::getTeam(%o);
		if(%oteam != %playerTeam)
		{	
			%sclient = Player::getClient(%shooterId);
			%sname = Client::getName(%sclient);
			%client = Player::getClient(%target);
			%vname = Client::getName(%client);
			GameBase::SetPosition(%target,GameBase::GetPosition(%o));
			bottomprint(%client,"Your have been placed under arrest by " @ %sname @ ", your sentence will last for 30 seconds", 30);
			//Client::SendMessage(%client,0,"Your jail sentence will last 30 seconds.");
			echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
			//schedule("JailDoor::JailSesame("@%target@", " @ %team @ ");",45);
			schedule("JailBreak(" @ %target @ ", " @ %team @ ");",30);
			return;
		}
	}
}

LaserData GatlingBullet
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "laserhit.dts";
   explosionTag     = LargeShockwave;

   //damageConversion  = 0.151;
   damageValue       = 0.15;
   damageclass		 =	1;
   explosionRadius = 50;
   baseDamageType    = $LightningDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 1.0, 1, 1 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;     //SoundLaserHit;
};

//LaserData GatlingBullet
//{ 
//	laserBitmapName   = "repairadd.bmp";
//	//explosionTag = enbolt.dts;
//	hitName           = "laserhit.dts";
//	collisionRadius = 0.0; 
//	explosionTag     = LargeShockwave;
//	mass = 0.05; 
//	damageClass = 1; 
//	damageValue = 0.15; 
//	damageType = $ElectricityDamageType; 
//	explosionRadius = 4; 
//	kickBackStrength = 0.0; 
//	muzzleVelocity = 425.0; 
//	terminalVelocity = 200.0; 
//	acceleration = 5.0; 
//	totalTime = 2.5; 
//	liveTime = 3.0; 
//	lightRange = 5.0; 
//	lightColor = { 1.0, 0.7, 0.5 }; 
//	inheritedVelocityScale = 1.0; 
//	trailType = 0; 
//	trailLength = 00; 
//	trailWidth = 0.0; 
//	soundId = SoundJetHeavy; 
//};

BulletData ChaingunBullet 
{ 
	bulletShapeName = "bullet.dts"; 
	validateShape = true; 
	explosionTag = bulletExp0; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.11; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.0045; 
	muzzleVelocity = 425.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = False; 
	tracerPercentage = 1.0; 
	tracerLength = 30; 
}; 
BulletData SilencerBullet { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.36; damageType = $LaserDamageType; muzzleVelocity = 625.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 100.0; tracerLength = 30; }; 
BulletData TranqDart { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.30; damageType = $EnergyDamageType; muzzleVelocity = 925.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 100.0; tracerLength = 30; }; 
BulletData VulcanBullet { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.1; damageType = $BulletDamageType; aimDeflection = 0.0025; muzzleVelocity = 700.0; totalTime = 0.4; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 2.0; tracerLength = 60; }; 
BulletData VulcanBullet2 { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.08; damageType = $BulletDamageType; aimDeflection = 0.0025; muzzleVelocity = 900.0; totalTime = 0.44; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 2.0; tracerLength = 60; }; 
BulletData FusionBolt 
{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = turretExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.25; 
	damageType = $LandingDamageType; 
	muzzleVelocity = 50.0; 
	totalTime = 6.0; 
	liveTime = 4.0; 
	isVisible = True; 
	rotationPeriod = 1.5; 
}; 
RocketData Shock1 
{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.25; 
	damageType = $MissileDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 350.0; 
	muzzleVelocity = 70.0; 
	terminalVelocity = 100.0; 
	acceleration = 5.0; 
	totalTime = 6.0; 
	liveTime = 4.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy; 
};BulletData MiniFusionBolt { bulletShapeName = "enbolt.dts"; explosionTag = energyExp; damageClass = 0; damageValue = 0.1; damageType = $LandingDamageType; muzzleVelocity = 80.0; totalTime = 4.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 0.25, 0.25, 1.0 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 
BulletData BlasterBolt { bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.16; damageType = $BlasterDamageType; muzzleVelocity = 250.0; totalTime = 1.7; liveTime = 0.9; lightRange = 3.0; lightColor = { 1.0, 0.25, 0.25 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 
BulletData HyperBolt { bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.1; damageType = $BlasterDamageType; muzzleVelocity = 200.0; totalTime = 1.0; liveTime = 0.13; lightRange = 3.0; lightColor = { 1.0, 0.25, 0.25 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 
BulletData PlasmaBolt { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.45; damageType = $PlasmaDamageType; explosionRadius = 4.0; muzzleVelocity = 55.0; totalTime = 3.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 
BulletData FlamerBolt { bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.06; damageType = $PlasmaDamageType; explosionRadius = 4.0; muzzleVelocity = 30.0; totalTime = 0.75; liveTime = 0.75; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 
BulletData OmegaBolt { bulletShapeName = "fusionbolt.dts"; explosionTag = energyExp; damageClass = 0; damageValue = 0.08; damageType = $ElectricityDamageType; aimDeflection = 0.015; muzzleVelocity = 100; totalTime = 0.7; liveTime = 0.5; lightRange = 0.5; lightColor = { 1, 1, 0 }; 
inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

RocketData DiscShell { bulletShapeName = "discb.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 7.5; kickBackStrength = 150.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 6.5; liveTime = 8.0; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 15; trailWidth = 0.3; soundId = SoundDiscSpin; }; 
RocketData StingerMissile { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 20.5; kickBackStrength = 450.0; muzzleVelocity = 65.0; terminalVelocity = 2000.0; acceleration = 200.0; totalTime = 8.5; liveTime = 18.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; GrenadeData GrenadeShell { bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 0.4; damageType = $ShrapnelDamageType; explosionRadius = 15; kickBackStrength = 150.0; maxLevelFlightDist = 150; totalTime = 30.0; liveTime = 1.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; }; 
RocketData BomberShell { bulletShapeName = "rocket.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.40; damageType = $ShrapnelDamageType; explosionRadius = 60.5; kickBackStrength = 800.0; muzzleVelocity = 100.0; terminalVelocity = 200.0; acceleration = 200.0; totalTime = 4.5; liveTime = 4.5; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; 
}; 
GrenadeData MortarShell 
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = mortarExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 1.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 20.0; 
	kickBackStrength = 250.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 2.0; 
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.5; 
	smokeName = "mortartrail.dts"; 
}; 

GrenadeData MeteorShell 
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = LargeShockwave; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 5.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 250.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 2.0; 
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.5; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 };
	smokeName = "mortartrail.dts"; 
};

GrenadeData MortarTurretShell { bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 400; collisionRadius = 1.0; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 1.32; damageType = $MortarDamageType; explosionRadius = 30.0; kickBackStrength = 250.0; maxLevelFlightDist = 400; totalTime = 1000.0; liveTime = 2.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "mortartrail.dts"; }; GrenadeData ShockShell { bulletShapeName = "mortar.dts"; explosionTag = Shockwave; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 995.0; elasticity = 0.01; damageClass = 1; damageValue = 0.10; damageType = $FlashDamageType; explosionRadius = 30.0; kickBackStrength = 0.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.01; smokeName = "mortartrail.dts"; }; GrenadeData SatchelShell { bulletShapeName = "grenade.dts"; explosionTag = rocketExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 3.5; damageType = $MortarDamageType; explosionRadius = 30; kickBackStrength = 350.0; maxLevelFlightDist = 1.2; totalTime = 1.5; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; }; 
RocketData FlierRocket { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 250.0; muzzleVelocity = 65.0; 
terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; SeekingMissileData TurretMissile { bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 175.0; muzzleVelocity = 72.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 9; nonSeekingTurningRadius = 75.0; proximityDist = 1.5; smokeDist = 1.75; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 
RocketData Nuke { bulletShapeName = "rocket.dts"; explosionTag = grenadeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.70; damageType = $ShrapnelDamageType; explosionRadius = 20.5; kickBackStrength = 300.0; muzzleVelocity = 60.0; terminalVelocity = 2000.0; acceleration = 200.0; totalTime = 8.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; SeekingMissileData BazookaBolt { bulletShapeName = "rocket.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 50.0; kickBackStrength = 500.0; muzzleVelocity = 90.0; totalTime = 7; liveTime = 7; seekingTurningRadius = 9; nonSeekingTurningRadius = 75.0; proximityDist = 1.5; smokeDist = 1.75; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData Shock 
{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.15; 
	damageType = $MissileDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 350.0; 
	muzzleVelocity = 70.0; 
	terminalVelocity = 100.0; 
	acceleration = 5.0; 
	totalTime = 6.0; 
	liveTime = 4.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy; 
};

RocketData TurretShock { bulletShapeName = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.0; damageType = $MissileDamageType; explosionRadius = 30.0; kickBackStrength = 450.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 
RocketData SniperRound { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.77; damageType = $SniperDamageType; explosionRadius = 0.1; kickBackStrength = 600.0; muzzleVelocity = 2000.0; terminalVelocity = 2000.0; acceleration = 5.0; totalTime = 1.0; liveTime = 1.5; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 1; trailLength = 3000; trailWidth = 0.3; soundId = SoundJetHeavy; }; SeekingMissileData StingerMissile2{ bulletShapeName = "rocket.dts"; explosionTag  = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 1.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 175.0; muzzleVelocity = 72.0; totalTime = 3; liveTime = 3; seekingTurningRadius = 6; nonSeekingTurningRadius = 75.0; proximityDist = 1.5; smokeDist = 1.75; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; SeekingMissileData Trackingproj { bulletShapeName = "rocket.dts"; explosionTag = TrackingExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 175.0; muzzleVelocity = 54.0; 
terminalvelocity = 130; acceleration = 5; totalTime = 20; liveTime = 20; seekingTurningRadius = 1; nonSeekingTurningRadius = 1; proximityDist = 1.5; smokeDist = 1.75; inheritedVelocityScale = 0.76; }; SeekingMissileData BarrageBolt { bulletShapeName = "tracer.dts"; explosionTag = flashExpMedium; collisionRadius = 0.0; mass = 1.5; damageClass = 1; damageValue = 0.25; damageType = $MissileDamageType; explosionRadius = 4.0; kickBackStrength = 10.0; muzzleVelocity = 50.0; terminalVelocity = 210.0; acceleration  = 400.0; totalTime = 20.0; liveTime = 21.0; seekingTurningRadius = 1; nonSeekingTurningRadius = 1.1; proximityDist = 1.9; smokeDist = 0.5; lightRange = 1.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; function BarrageBolt::verifyTarget(%target, %this) { return "True"; } 
RocketData RailRound { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.85; damageType = $SniperDamageType; explosionRadius = 0.1; kickBackStrength = 600.0; muzzleVelocity = 2000.0; terminalVelocity = 2000.0; acceleration = 5.0; totalTime = 1.7; liveTime = 2.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 1; trailLength = 3000; trailWidth = 1.0; soundId = SoundJetHeavy; }; 
RocketData IonBolt 
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.15; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 4; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 200.0; 
	terminalVelocity = 200.0; 
	acceleration = 5.0; 
	totalTime = 4.0; 
	liveTime = 3.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 50; 
	trailWidth = 0.3; 
	soundId = SoundJetHeavy; 
}; 
LaserData SeekerLaser { bulletShapeName = "mortar.dts";  hitName = "laserhit.dts"; damageConversion = 0.22; baseDamageType = $LaserDamageType; beamTime = 0.6; lightRange = 5.0; lightColor = { 0.25, 0.25, 0.85 }; 
detachFromShooter = false;hitSoundId = SoundLaserHit; }; 
LaserData sniperLaser { laserBitmapName = "shotgunbolt.bmp"; hitName = "laserhit.dts"; damageConversion = 0.007; baseDamageType = $LaserDamageType; beamTime = 1.0; lightRange = 2.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = false; hitSoundId = SoundLaserHit; }; 

LaserData sniperLaser2 
{ 
	laserBitmapName = "warp.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.011; 
	baseDamageType = $LaserDamageType; 
	beamTime = 0.5; 
	lightRange = 2.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	detachFromShooter = false; 
	hitSoundId = 
	SoundLaserHit; 
}; 

LaserData sniperLaser3 
{ 
	laserBitmapName = "warp.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.0050; 
	baseDamageType = $LaserDamageType; 
	beamTime = 0.5; 
	lightRange = 2.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	detachFromShooter = false; 
	hitSoundId = 
	SoundLaserHit; 
};

LaserData railLaser 
{ 
	laserBitmapName = "paintPulse.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.0095; 
	baseDamageType = $SniperDamageType; 
	beamTime = 1.0; 
	lightRange = 5.0; 
	lightColor = { 0.25, 1.0, 0.25 }; 
	detachFromShooter = true; 
	hitSoundId = SoundLaserHit; 
};
TargetLaserData targetLaser 
{ 
	laserBitmapName = "paintPulse.bmp"; 
	damageConversion = 0.0; 
	baseDamageType = 0; 
	lightRange = 2.0; 
	lightColor = { 0.25, 1.0, 0.25 }; 
	detachFromShooter = false; 
}; 
	
LightningData lightningCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 
	
	LightningData lightningCharge2 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 50.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; LightningData turretCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.06; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; 
skipPercent =
 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; LightningData boltCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.20; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) { %damVal = %timeSlice * %damPerSec; %enVal = %timeSlice * %enDrainPerSec; GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); %energy = GameBase::getEnergy(%target); %energy = %energy - %enVal; if (%energy < 0) { %energy = 0; } GameBase::setEnergy(%target, %energy); } RepairEffectData RepairBolt { bitmapName = "repairadd.bmp"; boltLength = 7.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 450; skipPercent = 0.6; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.85, 0.25, 0.25 }; }; function RepairBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (%target == %player) { %player.repairTarget = -1; if (GameBase::getDamageLevel(%player) != 0) { %player.repairRate = 0.07; %player.repairTarget = %player; Client::sendMessage(%client, 0, "AutoRepair On"); } else { Client::sendMessage(%client,0,"Nothing in range"); Player::trigger(%player, $WeaponSlot, false); return; } } else { %player.repairTarget = %target; if(Player::getArmor(%client) == earmor || Player::getArmor(%client) == efemale) %player.repairRate = 0.2; else %player.repairRate = 0.1; if (getObjectType(%player.repairTarget) == "Player") { %rclient = Player::getClient(%player.repairTarget); %name = Client::getName(%rclient); } else { %name = GameBase::getMapName(%target); if(%name == "") { %name = (GameBase::getDataName(%player.repairTarget)).description; } } 
 if (GameBase::getDamageLevel(%player.repairTarget) == 0) { Client::sendMessage(%client,0,%name @ " is not damaged"); Player::trigger(%player,$WeaponSlot,false); %player.repairTarget = -1; return; } if (getObjectType(%player.repairTarget) == "Player") { Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client)); } Client::sendMessage(%client,0,"Repairing " @ %name); } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget,%rate); } function RepairBolt::onRelease(%this, %player) { %object = %player.repairTarget; if (%object != -1) { %client = Player::getClient(%player); if (%object == %player) { Client::sendMessage(%client,0,"AutoRepair Off"); } else { if (GameBase::getDamageLevel(%object) == 0) { Client::sendMessage(%client,0,"Repair Done"); } else { Client::sendMessage(%client,0,"Repair Stopped"); } } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object,%rate); } } function RepairBolt::checkDone(%this, %player) { %gun = Player::getMountedItem(%player, $WeaponSlot); if (Player::isTriggered(%player,$WeaponSlot) && (%gun == RepairGun || %gun == Fixit) && %player.repairTarget != -1) { %object = %player.repairTarget; if (%object == %player) { if (GameBase::getDamageLevel(%player) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } else { if (GameBase::getDamageLevel(%object) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } } } RepairEffectData AutoBolt { bitmapName = "repairadd.bmp"; boltLength = 5.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 450; skipPercent = 0.6; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.85, 0.25, 0.25 }; }; function AutoBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (%target == %player) { %player.repairTarget = -1; if (GameBase::getDamageLevel(%player) != 0) { %player.repairRate = 0.05; %player.repairTarget = %player; 
Client::sendMessage(%client, 0, "AutoRepair On"); } else { Client::sendMessage(%client,0,"Full Health"); Player::trigger(%player, $BackpackSlot, false); return; } } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget,%rate); } function AutoBolt::onRelease(%this, %player) { %object = %player.repairTarget; if (%object != -1) { %client = Player::getClient(%player); if (%object == %player) { Client::sendMessage(%client,0,"AutoRepair Off"); } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object,%rate); } } function AutoBolt::checkDone(%this, %player) { if (%player.repairTarget != -1) { %object = %player.repairTarget; if (%object == %player) { if (GameBase::getDamageLevel(%player) == 0) { Player::trigger(%player,$BackpackSlot,false); return; } } } } RepairEffectData VehRepairBolt { bitmapName = "shotgunbolt.bmp"; boltLength = 5.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 450; skipPercent = 0.6; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.85, 0.25, 0.25 }; }; function VehRepairBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (getObjectType(%target) == "Flier" || GameBase::getDataName(%target) == "vehiclePad" || GameBase::getDataName(%target) == "VehicleStation") { %player.repairTarget = %target; %player.repairRate = 0.1; if (GameBase::getDamageLevel(%player.repairTarget) == 0) { Client::sendMessage(%client, 0, "Item is not damaged"); Player::trigger(%player, $WeaponSlot, false); %player.repairTarget = -1; return; }  Client::sendMessage(%client, 0, "Repairing " @ GameBase::getDataName(%target)); } else { Client::sendMessage(%client, 0, "Nothing in range"); Player::trigger(%player, $WeaponSlot, false); %player.repairTarget = -1; return; } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget, %rate); } 
function VehRepairBolt::onRelease(%this, %player) 
{ %object = %player.repairTarget; %client = Player::getClient(%player); if (%object != -1) { if (GameBase::getDamageLevel(%object) == 0) { Client::sendMessage(%client, 0, "Repair Done"); } else { Client::sendMessage(%client, 0, "Repair Stopped"); } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object, %rate); } } function VehRepairBolt::checkDone(%this, %player) { if (Player::isTriggered(%player, $WeaponSlot) && Player::getMountedItem(%player, $WeaponSlot) == VehFixit && %player.repairTarget != -1) { %object = %player.repairTarget; if (GameBase::getDamageLevel(%object) == 0) { Player::trigger(%player, $WeaponSlot, false); return; } } }      


// Disasymbler - Alternate To Engineer Repair Gun.
//------------------------------------------------------------------------------------------------------------------------
RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added
		
		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
		
		if(getObjectType(%player.repairTarget) == "Player")
		{
			Client::sendMessage(%client,0,"You can not disassymble another player.");
		}
		else
		{
			Client::sendMessage(%client,0,"Disassymbling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %name, %shape, %disatime);
			if ($Debug) echo ("Done.");
		}
	}	
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
}


function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	if ($ScoreOn) bottomprint(%Client, "Score - " @ $Score::FlagDef @ " = " @ %client.score @ " Total Score, for removing flag defencive." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %name, %shape, %disatime)
{	
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%description = %name;
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassymble the " @ %description @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %name @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	
	if ($Debug) echo ("Attempting To Dismantle " @ %name);
		
	//================================================================================================= AccelPad
	if (String::findSubStr(%name, "Regeneration Generator") >= 0)
	{
		%item = "RegenGen";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Launch Pad
	if (String::findSubStr(%name, "Springboard") >= 0)
	{
		%item = "SpringPack";
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}

	//================================================================================================= Teleport Pad
	if (String::findSubStr(%name, "Teleport Pad") >= 0)
	{
		%item = "TeleportPack";
		RemoveBeam(%this.beam1);		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	
	//================================================================================================= Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//================================================================================================= AATurret
	if (String::findSubStr(%name, "Anti-AirCraft Turret") >= 0)
	{
		%item = "BarragePack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}

	//======================================================================================== Command Station
	if (String::findSubStr(%name, "Remote Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//========================================================================================== Sensor Jammer
	if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Pulse Sensor
	if (String::findSubStr(%name, "Remote Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Motion Sensor
	if (String::findSubStr(%name, "Motion Sensor") >= 0)
	{
		%item = "MotionSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Camera 
	if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Blast Wall
	if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Blast Floor
	if (String::findSubStr(%name, "Blast Floor") >= 0)
	{
		%item = "BlastFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Small Force Field
	if (String::findSubStr(%name, "Small Force Field") >= 0)
	{
		%item = "ForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Force Field
	if (String::findSubStr(%name, "Large Force Field") >= 0)
	{
		%item = "LargeForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Shock Force Field
	if (String::findSubStr(%name, "Shock Floor") >= 0)
	{
		%item = "ShockFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Shock Force Field
	if (String::findSubStr(%name, "Large Shock Force Field") >= 0)
	{
		%item = "LargeShockForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//========================================================================================= Deployable Platform
	if (String::findSubStr(%name, "DeployablePlatform") >= 0)
	{
		%item = "PlatformPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//==================================================================================== Healing Plant
	if (String::findSubStr(%name, "Healing Plant") >= 0)
	{
		%item = "PlantPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Rocket Turret
	if (String::findSubStr(%name, "RMT Rocket Turret") >= 0)
	{
		%item = "RocketPack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Plasma Turret
	if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Elf Turret
	if (String::findSubStr(%name, "Deployable Elf Turret") >= 0)
	{
		%item = "DeployableElf";		
		objectTearup (%this, %item, %client, %player, 1, 20, %flagdist, %description);
		return 1;
	}
	//================================================================================================= EMP Turret
	if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		objectTearup (%this, %item, %client, %player, 1, 10, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Remote Mortar
	if (String::findSubStr(%name, "Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Laser Turret
	if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Arbitor Beacon
	if (String::findSubStr(%name, "ArbitorBeacon") >= 0)
	{
		%item = "ArbitorBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= EMPBeacon
	if (String::findSubStr(%name, "EMPBeacon") >= 0)
	{
		%item = "EMPBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= JammerBeacon
	if (String::findSubStr(%name, "JammerBeacon") >= 0)
	{
		%item = "JammerBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= ShieldBeacon
	if (String::findSubStr(%name, "Shield Device") >= 0)
	{
		%item = "ShieldBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Flamer Turret
	if (String::findSubStr(%name, "Flamer Turret") >= 0)
	{
		%item = "FlamerTurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Port Gen
	if (String::findSubStr(%name, "PortGenerator") >= 0)
	{
		%item = "PowerGeneratorPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}

	Client::sendMessage(%client,0,"Disassymbling " @ %name @ " failed...");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

// objectTearup (%this, %item, %client, %player, 1, 1, %flagdist, %description);

function objectTearup (%this, %item, %client, %player, %turret, %flag, %flagdist, %description)
{
	Client::sendMessage(%client,0,"Disassembling " @ %name);	  		
	$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
	
	if (%turret) $totalNumTurrets = $totalNumTurrets - 1;

	Player::setItemcount (%client, %item, 1);
	Player::mountItem(%client,%item,$BackpackSlot);
	bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);

	if (%flag > 0 && %flagdist < %flag) removeflagdefpoints(%player);
	//Item::playPickupSound(%this);
	if(%this)deleteObject(%this);
	$disassymble[%player] = false;
}