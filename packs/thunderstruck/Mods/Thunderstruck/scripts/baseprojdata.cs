
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
$MeteorDamageType      = 45;
$TeleFragDamageType = 66;

BulletData ChaingunBullet 
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;
   damageValue        = 0.07;
   damageType         = $BulletDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData MiniGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData GaussBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp3;
   expRandCycle       = 2;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.22;
   damageType         = $BulletDamageType;

   explosionRadius    = 7.5;
   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData Laker 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = fakeExp; 
mass = 0.05; 
collisionRadius = 0.0; 
bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.01; 
damageType = 91; 
aimDeflection = 0.0; 
muzzleVelocity = 2000.0; 
totalTime = 1; 
inheritedVelocityScale = 0.1; 
isVisible = false; 
lightRange = 0.75; 
lightColor = { 0.4, 0.4, 0.4 }; 
tracerPercentage = 1.0; tracerLength = 1; 
};

//============meteor showers & random events ported by spec=======================================

RocketData Meteor
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1;
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
   baseDamageType    = $LaserDamageType;

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
   damageType         = $PlasmaDamageType;
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
   damageType         = $SolarFlareDamageType;
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


//===================end random stuff==========================

RocketData PlasmaDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $BurnDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 1000.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 25.0;

   soundId = SoundDiscSpin;
};

RocketData AAODRocket
{	
	bulletShapeName  = "rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 1;
	damageValue      = 0.6;
	damageType       = $MissileDamageType;
	explosionRadius  = 14.5;
	kickBackStrength = 175.0;
	muzzleVelocity   = 75.0;
	terminalVelocity = 80.0;
	acceleration     = 5.0;
	totalTime        = 6.0;
	liveTime         = 7.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType   = 2;                
	trailString = "rsmoke.dts";
	smokeDist   = 20;
	soundId = SoundJetHeavy;
};

RocketData SuperBlaster
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = boltexp1;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $BlasterDamageType;

   explosionRadius  = 4;
   kickBackStrength = 50.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 300.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 15.7;

   soundId = SoundJetHeavy;
};

RocketData F1aker 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = fakeExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0; 
damageType = $ExplosionDamageType; 
explosionRadius = 0; 
kickBackStrength = 0.0; 
muzzleVelocity = 65.0; 
terminalVelocity = 80.0; 
acceleration = 5.0; 
totalTime = 0.1; 
liveTime = 0.1; 
lightRange = 0.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
}; 

function F1aker::onAdd(%this) {
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

RocketData IonShock3
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $MortarDamageType;

   explosionRadius  = 8;
   kickBackStrength = 512.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionbolt.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock4
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_3;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EMPDamageType;

   explosionRadius  = 16;
   kickBackStrength = 64.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock5
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $NullDamageType;

   explosionRadius  = 16;
   kickBackStrength = 350.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock6
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_4;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EnergyDamageType;

   explosionRadius  = 16;
   kickBackStrength = 0.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock7
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $BurnEDamageType;

   explosionRadius  = 16;
   kickBackStrength = 32.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 115.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock8
{
   bulletShapeName  = "shockwave.dts";
   explosionTag     = AnnihExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10;
   damageType       = $MortarDamageType;

   explosionRadius  = 10;
   kickBackStrength = 1024;
   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 20.0;

   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shockwave.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData snike 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = fakeExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.01; 
damageType = $FireDamageType; 
explosionRadius = 20; 
kickBackStrength = 0.0;
muzzleVelocity = 1.0; 
terminalVelocity = 1.0; 
acceleration = 0.5; 
totalTime = 0.01; 
liveTime = 0.01; 
lightRange = 0.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
}; 

RocketData Faker 
{ 
bulletShapeName = "breath.dts";
explosionTag = fakeExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0; 
damageType = $ExplosionDamageType; 
explosionRadius = 0; 
kickBackStrength = 0.0; 
muzzleVelocity = 1.0; 
terminalVelocity = 800.0; 
acceleration = 5.0; 
totalTime = 0.1; 
liveTime = 0.1; 
lightRange = 0.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
}; 

function Faker::onAdd(%this) {
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

RocketData Fa1ker 
{ 
bulletShapeName = "tracer.dts"; 
explosionTag = kakeExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0; 
damageType = $ExplosionDamageType; 
explosionRadius = 0; 
kickBackStrength = 0.0; 
muzzleVelocity = 0.1; 
terminalVelocity = 0.1; 
acceleration = 1.0; 
totalTime = 0.1; 
liveTime = 0.1; 
lightRange = 0.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.0; 
}; 

function Fa1ker::onAdd(%this) {
	%t = $Fa1ky;
	%trans = GameBase::getTransform(%this);
	%x = getWord(%trans, 3);
	%rot = %x @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	if(%x > 1.13 || %x < -1.13) %v = 3.5; else %v = 1.5;
	%f = Vector::getFromRot(%rot, %v);		
	%pos = GameBase::getPosition(%t);
	%pos = Vector::add(%pos, %f);
	%client = GameBase::getControlClient(%t);	
	if(GameBase::testPosition(%client,%pos)) {
		bottomprint(%client, "", 0);
		playSound (teleported, GameBase::getPosition(%client));	
		playSound (teleported, %pos);
		GameBase::setPosition(%client, %pos);	
		doneposs(%client);
		Client::setControlObject(%client, %client); 
	} else {
		Client::sendMessage(%client,0,"Unable to teleport - Object in the way~wC_BuySell.wav");		
	}
}


BulletData SilencerBullet 
{ 
bulletShapeName = "bullet.dts"; 
explosionTag = bulletExp0; 
expRandCycle = 3; 
mass = 0.05; 
bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.175; 
damageType = $BulletDamageType; 
muzzleVelocity = 500.0; 
totalTime = 0.32; 
inheritedVelocityScale = 1.0; 
isVisible = True; 
tracerPercentage = 1.0; 
tracerLength = 130; 
}; 

BulletData ShotgunBullet 
{ 
bulletShapeName = "tracer.dts";
 explosionTag = ShotExp;
 mass = 0.05;
 bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.05;
 damageType = $ShotgunDamageType; 
aimDeflection = 0.025; 
muzzleVelocity = 400.0;
 totalTime = 0.6; 
inheritedVelocityScale = 1.0;
 isVisible = true; 
tracerPercentage = 1.0; 
tracerLength = 40; 
}; 

BulletData TranqDart 
{ 
bulletShapeName = "bullet.dts";
 explosionTag = bulletExp0; 
expRandCycle = 3; 
mass = 0.05; 
bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.16; 
damageType = $EnergyDamageType;
 muzzleVelocity = 875.0;
 totalTime = 3.5; 
inheritedVelocityScale = 0.5; 
isVisible = True; 
tracerPercentage = 1.0;
 tracerLength = 130; 
}; 

BulletData TurretBullet 
{
 bulletShapeName = "bullet.dts";
 explosionTag = bulletExp0; 
expRandCycle = 3; 
mass = 0.05; 
bulletHoleIndex = 0; 
damageClass = 0;
damageValue = 0.06;
damageType = $BulletDamageType; 
aimDeflection = 0.002;
 muzzleVelocity = 500.0;
 totalTime = 2; 
inheritedVelocityScale = 1.0;
 isVisible = False;
 tracerPercentage = 1.0;
 tracerLength = 60; 
}; 

BulletData CoolMissile 
{
 bulletShapeName = "bullet.dts"; 
explosionTag = bulletExp0; 
expRandCycle = 3; 
mass = 0.05;
 bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.06; 
damageType = $BulletDamageType; 
aimDeflection = 0.002; 
muzzleVelocity = 3000.0; 
totalTime = 2; 
inheritedVelocityScale = 1.0; 
isVisible = False; 
tracerPercentage = 1.0; 
tracerLength = 60; 
}; 

BulletData FusionBolt 
{ 
bulletShapeName = "fusionbolt.dts"; 
explosionTag = turretExp;
 mass = 0.05; 
damageClass = 0; 
damageValue = 0.165; 
damageType = $PDamageType;
 muzzleVelocity = 40.0; 
totalTime = 6.0; 
liveTime = 4.0; 
isVisible = True; 
rotationPeriod = 1.5; 
}; 

BulletData MiniFusionBolt 
{ 
bulletShapeName = "enbolt.dts"; 
explosionTag = energyExp; 
damageClass = 0; 
damageValue = 0.1; 
damageType = $MiniDamageType; 
muzzleVelocity = 80.0; 
totalTime = 4.0; 
liveTime = 2.0; 
lightRange = 3.0; 
lightColor = { 0.25, 0.25, 1.0 }; 
inheritedVelocityScale = 0.5; 
isVisible = True; 
rotationPeriod = 1; 
}; 

BulletData BlasterBolt 
{ 
bulletShapeName = "shotgunbolt.dts"; 
explosionTag = blasterExp; 
damageClass = 0; 
damageValue = 0.125; 
damageType = $BlasterDamageType; 
muzzleVelocity = 270.0; 
totalTime = 5; 
liveTime = 5.5; 
lightRange = 5.0; 
lightColor = { 1.0, 0.1, 0.1 }; 
inheritedVelocityScale = 0.25; 
isVisible = True; 
rotationPeriod = 1; 
}; 

BulletData PlasmaBolt 
{ 
bulletShapeName = "plasmabolt.dts"; 
explosionTag = plasmaExp; 
damageClass = 1; 
damageValue = 0.40; 
damageType = $PlasmaDamageType; 
explosionRadius = 3.8; 
muzzleVelocity = 50.0; 
totalTime = 3.0; 
liveTime = 2.0; 
lightRange = 3.0; 
lightColor = { 1, 1, 0 }; 
inheritedVelocityScale = 0.3; 
isVisible = True; 
soundId = SoundJetLight; 
};

GrenadeData FlamerBolt 
{ 
bulletShapeName = "plasmatrail.dts"; 
explosionTag = plasmafExp; 
collideWithOwner = True; 
ownerGraceMS = 250; 
collisionRadius = 1.0; 
mass = 1.0; 
elasticity = 0.01; 
damageClass = 1; 
damageValue = 0.075;
 damageType = $PlasmaDamageType;
 explosionRadius = 13; 
kickBackStrength = 25.0;
 maxLevelFlightDist = 60;
 totalTime = 23; 
liveTime = 0.1; 
projSpecialTime = 0.08;
 inheritedVelocityScale = 0.75;
 smokeName = "plastrail.dts"; 
soundId = SoundJetLight; 
}; 

RocketData DiscShell 
{ 
bulletShapeName = "discb.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.7; 
damageType = $ExplosionDamageType; 
explosionRadius = 7.5; 
kickBackStrength = 150.0; 
muzzleVelocity = 200.0; 
terminalVelocity = 1200.0; 
acceleration = 10.0; 
totalTime = 6.5; 
liveTime = 8.0; 
lightRange = 6.0; 
lightColor = { 0.1, 0.1, 1.0 }; 
inheritedVelocityScale = 0.5;
trailType = 2; 
trailString = "shield.dts";
smokeDist   = 25.0; 
soundId = SoundDiscSpin; 
}; 

RocketData RepairBo1t 
{ 
bulletShapeName = "paint.dts";
explosionTag = nu1lExp;
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1;
damageValue = 0.15;
damageType = 999; 
explosionRadius = 2.5;
kickBackStrength = 0.0;
muzzleVelocity = 46.0; 
terminalVelocity = 46.0;
acceleration = 2.0; 
totalTime = 0.2; 
liveTime = 0.2; 
lightRange = 5.0;
lightColor = { 0.0, 1.0, 0.0 }; 
inheritedVelocityScale = 0.5;
 soundId = SoundRepairBolt; 
}; 

RocketData JeterShell 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = flashExpSmall;
 collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.32; 
damageType = $ExplosionDamageType; 
explosionRadius = 3; 
kickBackStrength = 70.0; 
muzzleVelocity = 320.0;
 terminalVelocity = 340.0; 
acceleration = 5.0; 
totalTime = 8; 
liveTime = 9.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.6; 
soundId = SoundJetHeavy; 
};

GrenadeData ImpactMortarShell
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

   explosionRadius    = 15.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData ClusterBomb
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 500;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3;
   damageType         = $MissileDamageType;

   explosionRadius    = 010.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shield.dts";
};

function ClusterBomb::onAdd(%this)
{
	schedule("BombSpread(" @ %this @ ");",5.0,%this);
}

function bombspread(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

} 

RocketData HDiscShell 
{ 
bulletShapeName = "discb.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.7;
 damageType = $ExplosionDamageType;
 explosionRadius = 7.5; 
kickBackStrength = 110.0; 
muzzleVelocity = 200.0; 
terminalVelocity = 1200.0; 
acceleration = 10.0; 
totalTime = 6.5; 
liveTime = 8.0; 
lightRange = 5.0; 
lightColor = { 0.1, 1.0, 0.1 }; 
inheritedVelocityScale = 0.5; 
trailType = 2; 
trailString = "shield.dts"; 
smokeDist   = 25.0;
soundId = SoundSpinIdle; 
};

RocketData RPGshell
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $MissileDamageType;

   explosionRadius  = 15;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   smokeDist         = 3.14;
   soundId = SoundJetHeavy;
};

RocketData RPMshell
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $MissileDamageType;

   explosionRadius  = 25;
   kickBackStrength = 250.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   smokeDist         = 3.14;
   soundId = SoundJetHeavy;
};  

RocketData StingerEMissile 
{ 
bulletShapeName = "rocket.dts";
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0;
damageClass = 1; 
damageValue = 0.35;
damageType = $ExplosionDamageType; 
explosionRadius = 16; 
kickBackStrength = 200.0;
muzzleVelocity = 50.0; 
terminalVelocity = 80.0;
acceleration = 5.0; 
totalTime = 10; 
liveTime = 12.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.8; 
trailType = 2; 
trailString = "rsmoke.dts"; 
smokeDist = 1.8; 
soundId = SoundJetHeavy; 
}; 

RocketData PimpinMissile 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = nappyExp;
 collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1;
 damageValue = 0.4;
 damageType = $ExplosionDamageType;
 explosionRadius = 20; 
kickBackStrength = 200.0;
 muzzleVelocity = 60.0; 
terminalVelocity = 85.0;
 acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.0, 0.0 }; 
inheritedVelocityScale = 0.5; 
trailType = 2; 
trailString = "plasmatrail.dts"; 
smokeDist = 1.8; 
soundId = SoundJetHeavy; 
}; 

SeekingMissileData AvengerMissile 
{ 
bulletShapeName = "rocket.dts";
 explosionTag = sockExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.42; 
damageType = $ExplosionDamageType; 
explosionRadius = 9.5; 
kickBackStrength = 200.0; 
muzzleVelocity = 60.0; 
terminalVelocity = 100.0; 
acceleration = 5.0; 
totalTime = 20.0; 
liveTime = 21.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.76; 
seekingTurningRadius = 0.0; 
nonSeekingTurningRadius = 5.0; 
proximityDist = 1.5; 
trailType = 2; 
trailString = "smoke.dts";
 smokeDist = 1.5; 
soundId = SoundJetHeavy; 
}; 

RocketData HandRocket 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = rocketExp;
 collisionRadius = 0.0;
 mass = 2.0; 
damageClass = 1; 
damageValue = 0.36; 
damageType = $ExplosionDamageType; 
explosionRadius = 15; 
kickBackStrength = 225.0; 
muzzleVelocity = 52.0; 
terminalVelocity = 85.0;
 acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.65; 
trailType = 2; 
trailString = "rsmoke.dts"; 
smokeDist = 1.8; 
soundId = SoundJetHeavy; 
}; 

RocketData StingerMissile 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0;
 mass = 2.0; 
damageClass = 1; 
damageValue = 0.39; 
damageType = $ExplosionDamageType; 
explosionRadius = 15; 
kickBackStrength = 225.0; 
muzzleVelocity = 52.0; 
terminalVelocity = 90.0; 
acceleration = 5.0; 
totalTime = 10; 
liveTime = 12.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.8; 
trailType = 2; 
trailString = "rsmoke.dts"; 
smokeDist = 1.8; 
soundId = SoundJetHeavy; 
}; 

GrenadeData GrenadeShell 
{ 
bulletShapeName = "grenade.dts"; 
explosionTag = grenadeExp; 
collideWithOwner = True; 
ownerGraceMS = 250; 
collisionRadius = 0.2; 
mass = 1.0; 
elasticity = 0.45;
 damageClass = 1; 
damageValue = 0.4; 
damageType = $ShrapnelDamageType; 
explosionRadius = 15; 
kickBackStrength = 150.0; 
maxLevelFlightDist = 150; 
totalTime = 30.0; 
liveTime = 1.0; 
projSpecialTime = 0.05; 
inheritedVelocityScale = 0.5; 
smokeName = "smoke.dts";
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

GrenadeData Telee 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = bullExp; 
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

GrenadeData EMPSme11 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = nul11Exp; 
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

GrenadeData EMPShe11 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = nu11Exp; 
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

GrenadeData ArmChan 
{ 
bulletShapeName = "rsmoke.dts"; 
explosionTag = armChanExp; 
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
maxLevelFlightDist = 4; 
totalTime = 0.55; 
liveTime = 0.55; 
projSpecialTime = 0.05; 
inheritedVelocityScale = 1.0;
 smokeName = "rsmoke.dts"; 
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
kickBackStrength = 265.0; 
maxLevelFlightDist = 275; 
totalTime = 30.0; 
liveTime = 2.0; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.5; 
smokeName = "mortartrail.dts"; 
}; 

GrenadeData MortarTurretShell 
{ 
bulletShapeName = "mortar.dts"; 
explosionTag = mortarExp; 
collideWithOwner = True; 
ownerGraceMS = 400; 
collisionRadius = 1.0; 
mass = 5.0; 
elasticity = 0.1; 
damageClass = 1; 
damageValue = 1.32; 
damageType = $MortarDamageType; 
explosionRadius = 30.0; 
kickBackStrength = 250.0;
 maxLevelFlightDist = 400;
 totalTime = 1000.0; 
liveTime = 2.0; 
projSpecialTime = 0.05; 
inheritedVelocityScale = 0.5; 
smokeName = "mortartrail.dts"; 
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
explosionRadius = 26; 
kickBackStrength = -100.0; 
maxLevelFlightDist = 275; 
totalTime = 30.0; 
liveTime = 0.25; 
projSpecialTime = 0.05; 
inheritedVelocityScale = 0.5; 
smokeName = "fusionbolt.dts"; 
soundId = SoundELFFire; 
}; 

SeekingMissileData SeekingRPEMP
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = PulseExp;
   collisionRadius  = 0.0;

  mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $EMPDamageType;

   explosionRadius  = 10;
   kickBackStrength = 0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   seekingTurningRadius    = 75;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 10;
   smokeDist         = 3.14;

   soundId = SoundJetHeavy;
};

GrenadeData ShockShell 
{ 
bulletShapeName = "mortar.dts"; 
explosionTag = Shockwave; 
collideWithOwner = True; 
ownerGraceMS = 250; 
collisionRadius = 0.3; 
mass = 995.0; 
elasticity = 0.01; 
damageClass = 1; 
damageValue = 0.10; 
damageType = $FlashDamageType; 
explosionRadius = 30.0; 
kickBackStrength = 0.0; 
maxLevelFlightDist = 1; 
totalTime = 30.0; 
liveTime = 0.01; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.01; 
smokeName = "fusionbolt.dts"; 
}; 

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
totalTime = 30.0; 
liveTime = 0.01; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.5; 
smokeName = "smoke.dts"; 
}; 

RocketData FlierRocket 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 1.5; 
damageType = $ExplosionDamageType; 
explosionRadius = 10; 
kickBackStrength = 300.0; 
muzzleVelocity = 500.0; 
terminalVelocity = 500.0; 
acceleration = 7.0; 
totalTime = 9.0; 
liveTime = 10.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.5, 1.0 }; 
inheritedVelocityScale = 0.5; 
trailType = 2;
trailString = "rsmoke.dts"; 
smokeDist = 1.8;
 soundId = SoundJetHeavy; 
}; 

BulletData MiniFlierRocket {
   bulletShapeName    = "rocket.dts";
   explosionTag       = debrisExpMedium;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 1;
   damageValue        = 0.80;
   damageType         = $ExplosionDamageType;
   explosionRadius = 3;
   kickBackStrength = 90.0;
   aimDeflection      = 0.025;
   muzzleVelocity     = 700.0;
   totalTime          = 2.75;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
   tracerPercentage   = 0.0;
   tracerLength       = 0;
};

RocketData ChargedFusionBolt
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $PDamageType;

   explosionRadius  = 12.5;
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
   trailString = "hflame.dts";
   smokeDist   = 3.141592654;

   soundId = SoundJetHeavy;
};

RocketData TurretDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $AAExplosionDamageType;

   explosionRadius  = 6.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 100;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

SeekingMissileData LilTurretMissi1e 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = ggrocketExp; 
collisionRadius = 0.0;
 mass = 2.0; 
damageClass = 1;
 damageValue = 0.2;
 damageType = $AAExplosionDamageType;
 explosionRadius = 7;
 kickBackStrength = 80.0; 
muzzleVelocity = 115.0; 
totalTime = 10; 
liveTime = 10; 
seekingTurningRadius = 0.5; 
nonSeekingTurningRadius = 1.0; 
proximityDist = 1.0; 
trailType = 2;
 trailString = "rsmoke.dts"; 
smokeDist = 1.0; 
lightRange = 5.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
soundId = SoundJetHeavy; 
}; 

SeekingMissileData TurretMissile 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = SockExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1;
 damageValue = 0.22;
 damageType = $MExplosionDamageType; 
explosionRadius = 10; 
kickBackStrength = 200.0;
 muzzleVelocity = 72.0; 
totalTime = 10; 
liveTime = 10; 
seekingTurningRadius = 4; 
nonSeekingTurningRadius = 50.0; 
proximityDist = 1.5; 
trailType = 2; 
trailString = "smoke.dts"; 
smokeDist = 1.75; 
lightRange = 5.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
soundId = SoundJetHeavy; 
}; 

SeekingMissileData FlierRocketLock 
{ 
bulletShapeName = "rocket.dts";
 explosionTag = SockExp; 
collisionRadius = 0.0;
 mass = 2.0; 
damageClass = 1; 
damageValue = 1.55; 
damageType = $ExplosionDamageType; 
explosionRadius = 9; 
kickBackStrength = 250.0;
 muzzleVelocity = 500.0; 
totalTime = 10; 
liveTime = 10; 
seekingTurningRadius = 6; 
nonSeekingTurningRadius = 50.0; 
proximityDist = 1.0; 
trailType = 2; 
trailString = "rsmoke.dts"; 
smokeDist = 1.8; 
lightRange = 5.0; 
lightColor = { 1.0, 0.5, 1.0 }; 
inheritedVelocityScale = 0.8;
 soundId = SoundJetHeavy; 
}; 

function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 

RocketData Shock 
{ 
bulletShapeName = "fusionbolt.dts"; 
explosionTag = LargeShockwave; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.02; 
damageType = $ExplosionDamageType; 
explosionRadius = 30.0; 
kickBackStrength = 520.0; 
muzzleVelocity = 200.0; 
terminalVelocity = 200.0; 
acceleration = 5.5; 
totalTime = 6.0; 
liveTime = 4.0; 
lightRange = 10.0; 
lightColor = { 0.0, 0.0, 1.0 }; 
inheritedVelocityScale = 0.5;
trailType   = 2;
trailString = "shield.dts";
smokeDist   = 1.8; 
soundId = SoundJetHeavy; 
}; 

RocketData SniperRound40 
{ 
bulletShapeName = "bullet.dts"; 
explosionTag = boltexp1; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 0; 
damageValue = 0.46; 
damageType = $SniperDamageType; 
explosionRadius = 0.1; 
kickBackStrength = 700.0; 
muzzleVelocity = 2300.0; 
terminalVelocity = 2300.0; 
acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 0.25, 0.25, 1 }; 
inheritedVelocityScale = 1.0; 
soundId = SoundJetHeavy;
tracerPercentage = 100.0; 
tracerLength = 10;
}; 



RocketData SniperRound 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = sniperbulletExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 0; 
damageValue = 0.66; 
damageType = $SniperDamageType; 
explosionRadius = 0.1; 
kickBackStrength = 700.0; 
muzzleVelocity = 3500.0; 
terminalVelocity = 3500.0; 
acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 0.25, 0.25, 1 }; 
inheritedVelocityScale = 1.0; 
soundId = SoundJetHeavy;
trailType   = 2;                // smoke trail
trailString = "rsmoke.dts";
smokeDist   = 15;
 
}; 

RocketData RailRound 
{ 
bulletShapeName = "bullet.dts"; 
explosionTag = RailExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 0;
 damageValue = 0.6;
 damageType = $RailDamageType;
 explosionRadius = 0.1; 
kickBackStrength = 900.0;
 muzzleVelocity = 3000.0; 
terminalVelocity = 3000.0; 
acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 10.0; 
lightColor = { 0.25, 0.25, 1 };
inheritedVelocityScale = 1.0; 
trailType = 1; 
trailLength = 1000; 
trailWidth = 1; 
soundId = SoundJetHeavy; 
}; 

RocketData IonBolt 
{ 
bulletShapeName = "enbolt.dts"; 
explosionTag = l1ll1Exp;
 collisionRadius = 0.0;
 mass = 2.0; 
damageClass = 1; 
damageValue = 0.2;
 damageType = $ElectricityDamageType; 
explosionRadius = 2; 
kickBackStrength = 95.0;
 muzzleVelocity = 170.0; 
terminalVelocity = 170.0;
 acceleration = 2.5; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 0.0, 0.0, 1.0 }; 
inheritedVelocityScale = 0.5;
 trailType = 1; 
trailLength = 5; 
trailWidth = 0.5; 
soundId = SoundJetHeavy; 
};

LaserData ParticleBeam
{
   laserBitmapName   = "laserPulse.bmp"; // warp
   hitName           = "laserhit.dts";

   damageConversion  = 0.030;
   baseDamageType    = $SniperDamageType;

   beamTime          = 0.7;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = Ssssoo;
};

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

LaserData turretElaser 
{ 
laserBitmapName = "repairadd.bmp"; 
hitName = "laserhit.dts"; 
damageConversion = 0.0180;
 baseDamageType = $LaserEDamageType;
 beamTime = 2.2; 
lightRange = 2.0; 
lightColor = { 1.0, 0.25, 0.25 }; 
detachFromShooter = false; 
hitSoundId = SoundLaserHit; 
};

LaserData turretlaser 
{ 
laserBitmapName = "laserPulse.bmp";
 hitName = "laserhit.dts"; 
damageConversion = 0.008;
 baseDamageType = $LaserDamageType;
 beamTime = 1.75;
 lightRange = 2.0; 
lightColor = { 1.0, 0.25, 0.25 }; 
detachFromShooter = false;
 hitSoundId = SoundLaserHit; 
};

LaserData wiperLaser 
{
laserBitmapName = "laserPulse.bmp"; 
hitName = "laserhit.dts";
 damageConversion = 0.008; 
baseDamageType = $LaserDamageType; 
beamTime = 1.0; 
lightRange = 6.0; 
lightColor = { 1.0, 0.25, 0.25 }; 
detachFromShooter = true;
 hitSoundId = SoundTaserHit; 
}; 

LaserData sniperLaser 
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.030;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;
   beamWidth = 0.015;
   lightRange        = 5.0;
   lightColor        = { 0.15, 1.0, 0.15 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;

};

LaserData railLaser 
{ 
laserBitmapName = "lightningNew.bmp";
 hitName = "laserhit.dts"; 
damageConversion = 0.0085; 
baseDamageType = $SniperDamageType; 
beamTime = 2.7; 
lightRange = 25.0; 
lightColor = { 0.15, 0.15, 1 }; 
detachFromShooter = true; 
hitSoundId = SoundLaserHit; 
};

TargetLaserData targetLaser 
{ 
aserBitmapName = "grn_blink1.bmp"; 
damageConversion = 0.0; 
baseDamageType = 0; 
lightRange = 2.0; 
lightColor = { 0.25, 1.0, 0.25 }; 
detachFromShooter = false; 
}; 

LightningData lightningCharge 
{ 
bitmapName = "lightningNew.bmp"; 
damageType = $ElectricityDamageType; 
boltLength = 40.0; 
coneAngle = 35.0; 
damagePerSec = 0.045; 
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

SeekingMissileData TurretMissi1e 
{ 
bulletShapeName = "rocket.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.5; 
damageType = $MExplosionDamageType; 
explosionRadius = 9.5; 
kickBackStrength = 175.0; 
muzzleVelocity = 68.0; 
totalTime = 10; 
liveTime = 10; 
seekingTurningRadius = 9; 
nonSeekingTurningRadius = 75.0; 
proximityDist = 1.5; 
smokeDist = 1.75; 
lightRange = 5.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
soundId = SoundJetHeavy; 
}; 

BulletData FusionBo1t 
{ 
bulletShapeName = "fusionbolt.dts"; 
explosionTag = turretExp; 
mass = 0.05; 
damageClass = 0; 
damageValue = 0.1465; 
damageType = $PDamageType; 
muzzleVelocity = 40.0; 
totalTime = 6.0; 
liveTime = 4.0; 
isVisible = True; 
rotationPeriod = 1.5; 
}; 

RocketData IonEBolt 
{ 
bulletShapeName = "enbolt.dts"; 
explosionTag = turretExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.15; 
damageType = $ElectricityEDamageType;
 explosionRadius = 4; 
kickBackStrength = 20.0; 
muzzleVelocity = 200.0;
 terminalVelocity = 200.0;
 acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 1.0, 0.7, 0.5 }; 
inheritedVelocityScale = 0.5;
 trailType = 1; 
trailLength = 130; 
trailWidth = 0.3; 
soundId = SoundJetHeavy; 
}; 

RocketData IonEEBolt 
{ 
bulletShapeName = "breath.dts"; 
explosionTag = turret1Exp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0.07; 
damageType = $TracDamageType; 
explosionRadius = 4; 
kickBackStrength = -300.0; 
muzzleVelocity = 200.0; 
terminalVelocity = 200.0; 
acceleration = 5.0; 
totalTime = 10.0; 
liveTime = 11.0; 
lightRange = 5.0; 
lightColor = { 0.2, 1.0, 0.2 }; 
inheritedVelocityScale = 0.5; 
trailType = 1; 
trailLength = 130; 
trailWidth = 0.5; 
soundId = SoundJetHeavy; 
}; 

BulletData P1asmaBolt 
{ 
bulletShapeName = "plasmabolt.dts"; 
explosionTag = plasmaExp; 
damageClass = 1; 
damageValue = 0.4; 
damageType = $BurnEDamageType; 
explosionRadius = 4.0; 
muzzleVelocity = 55.0; 
totalTime = 3.0; 
liveTime = 2.0; 
lightRange = 3.0; 
lightColor = { 1, 1, 0 }; 
inheritedVelocityScale = 0.3; 
isVisible = True; 
soundId = SoundJetLight; 
};

//============================================================================================================================ 

LightningData lightningECharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityLEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.045; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData turretECharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.12; energyDrainPerSec = 65.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData ThunderStruckStrike0 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 330.0; coneAngle = 35.0; damagePerSec = 0.005; energyDrainPerSec = 0.0001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.08; lightRange = 40.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData ThunderStruckStrike { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 310.0; coneAngle = 35.0; damagePerSec = 0.125; energyDrainPerSec = 0.001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.08; lightRange = 40.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData ThunderStruckStrike1 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 320.0; coneAngle = 35.0; damagePerSec = 0.11; energyDrainPerSec = 0.001; segmentDivisions = 4; numSegments = 1; beamWidth = 2.0; updateTime = 20; skipPercent = 0.5; displaceBias = 0.05; lightRange = 30.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData ThunderStruckStrike2 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 320.0; coneAngle = 35.0; damagePerSec = 0.177; energyDrainPerSec = 0.001; segmentDivisions = 5; numSegments = 1; beamWidth = 2.5; updateTime = 30; skipPercent = 0.5; displaceBias = 0.07; lightRange = 50.0; lightColor = { 0.25, 0.25, 1.0 }; soundId = Ssssoo; }; 

LightningData lightningCharge2 { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 50.0; coneAngle = 35.0; damagePerSec = 0.045; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData turretCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityTEDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 70.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData boltCharge { bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 20.0; coneAngle = 35.0; damagePerSec = 0.06; energyDrainPerSec = 30.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125; updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 5.0; lightColor = { 0.25, 0.25, 1 }; soundId = SoundELFFire; }; 

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
		%dmod = 9;
		%hmod = 11;
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

LightningData ttargetpull { bitmapName = "lightningNewSub.bmp"; damageType = 0; boltLength = 80.0; coneAngle = 32.0; damagePerSec = 0.0; energyDrainPerSec = 0.0; segmentDivisions = 5; numSegments = 1; beamWidth = 0.25; updateTime = 300; skipPercent = 0.5; displaceBias = 0.0; lightRange = 5.0; lightColor = { 1, 0.25, 0.25 }; }; 

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
	%force = ((%dist / 75) * 20) + 5.3;
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
   	coneAngle        = 12.0;
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
   	damageValue        = 0.055;
   	damageType         = $BulletDamageType;
   	aimDeflection      = 0.005;
   	muzzleVelocity     = 600.0;
   	totalTime          = 1.5;
   	inheritedVelocityScale = 1.0;
   	isVisible          = false;
   	tracerPercentage   = 1.0;
   	tracerLength       = 30;
};

RepairEffectData reassemblerBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 50.0;
   segmentDivisions = 4;
   beamWidth        = 0.025;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function reassemblerBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;

                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.1;
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
                %player.repairRate   = 0.45;
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
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
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

function reassemblerBolt::onRelease(%this, %player)
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

function reassemblerBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == reassembler &&
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

function SuperRBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        if (%target == %player) {
           %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.6;
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
                %player.repairRate   = 0.4;
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
                        Client::sendMessage(%client,0,%name @ " isn't damaged");
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

function SuperRBolt::onRelease(%this, %player)
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

function SuperRBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun &&
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

RepairEffectData RepairBolt { bitmapName = "repairadd.bmp"; boltLength = 6.5; segmentDivisions = 4; beamWidth = 0.125; updateTime = 350; skipPercent = 0.6; displaceBias = 0.12; lightRange = 5; lightColor = { 1.0, 0.25, 0.25 }; }; 

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
		%target.shieldStrength = 0.013;
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
			GameBase::setRechargeRate(%player.powerTarget, 8);
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
