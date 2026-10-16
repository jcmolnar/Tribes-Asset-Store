																										# Damage Types
#
$ImpactDamageType = -1; $LandingDamageType = 0; $BulletDamageType = 1; $EnergyDamageType = 2; $PlasmaDamageType = 3; $ExplosionDamageType = 4; $ShrapnelDamageType = 5; $LaserDamageType = 6; $MortarDamageType = 7; $BlasterDamageType = 8; $ElectricityDamageType = 9; $CrushDamageType = 10; $DebrisDamageType = 11; $MissileDamageType = 12; $MineDamageType = 13; $SniperDamageType = 14; $FlashDamageType = 15; 












$hacking[%client] = "false";
$Viral = "false";
$isInfected[0] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";
$minInfected = "-1";
$minInfected = "-1";

if ($Shifter::HackTime == "")
	$Shifter::HackTime = "5";

if ($Shifter::HackedTime == "")
	$Shifter::HackedTime = "90";

if ($Shifter::HackLock == "")
	$Shifter::HackedLock = "0";

if ($Shifter::AllowHacking == "")
	$Shifter::AllowHacking = True;












// BulletData ChaingunBullet 
// { bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.11; damageType = $BulletDamageType; aimDeflection = 0.0002; muzzleVelocity = 425.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 1.0; tracerLength = 30; }; 







RocketData ChaingunBullet 
{ bulletShapeName = "rocket.dts"; explosionTag = HyperBulletExp0; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 3.85; damageType = $BulletDamageType; explosionRadius = 0.1; kickBackStrength = 600.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

BulletData SniperBullet 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; mass = 0.05; collisionRadius = 0.0; bulletHoleIndex = 0; damageClass = 0; damageValue = 1.5; damageType = $LaserDamageType; aimDeflection = 0.0; muzzleVelocity = 2000.0; totalTime = 1; inheritedVelocityScale = 0.0; isVisible = false; tracerPercentage = 100.0; tracerLength = 25; }; 

BulletData SilencerBullet 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.65; damageType = $LaserDamageType; muzzleVelocity = 625.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 100.0; tracerLength = 30; }; 

BulletData TranqDart 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.16; damageType = $EnergyDamageType; muzzleVelocity = 625.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 100.0; tracerLength = 30; }; 

BulletData VulcanBullet 
{ 
bulletShapeName = "bullet.dts"; 
explosionTag = bulletExp0; 
expRandCycle = 3; 
mass = 0.05; 
bulletHoleIndex = 0; 
damageClass = 0; 
damageValue = 0.1; 
damageType = $BulletDamageType; 
aimDeflection = 0.0008; 
muzzleVelocity = 900.0; 
totalTime = 2; 
inheritedVelocityScale = 1.0; 
isVisible = False; 
tracerPercentage = 2.0; 
tracerLength = 60; 
}; 

BulletData TurretBullet 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.1; damageType = $BulletDamageType; aimDeflection = 0.015; muzzleVelocity = 900.0; totalTime = 4; inheritedVelocityScale = 1.0; isVisible = False; tracerPercentage = 2.0; tracerLength = 60; }; 

BulletData JetBullet 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; expRandCycle = 3; mass = 0.05; bulletHoleIndex = 0; damageClass = 0; damageValue = 0.3; damageType = $BulletDamageType; aimDeflection = 0.005; muzzleVelocity = 425.0; totalTime = 1.5; inheritedVelocityScale = 1.0; isVisible = True; tracerPercentage = 100.0; tracerLength = 30; }; 

BulletData FusionBolt 
{ bulletShapeName = "fusionbolt.dts"; explosionTag = turretExp; mass = 0.05; damageClass = 0; damageValue = 0.25; damageType = $LandingDamageType; muzzleVelocity = 50.0; totalTime = 6.0; liveTime = 4.0; isVisible = True; rotationPeriod = 1.5; }; 

BulletData MiniFusionBolt 
{ bulletShapeName = "enbolt.dts"; explosionTag = energyExp; damageClass = 0; damageValue = 0.1; damageType = $LandingDamageType; muzzleVelocity = 80.0; totalTime = 4.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 0.25, 0.25, 1.0 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 

BulletData BlasterBolt 
{ bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.125; damageType = $BlasterDamageType; muzzleVelocity = 200.0; totalTime = 2.0; liveTime = 1.125; lightRange = 3.0; lightColor = { 1.0, 0.25, 0.25 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 

BulletData HyperBolt 
{ bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.04; damageType = $BlasterDamageType; muzzleVelocity = 200.0; totalTime = 1.0; liveTime = 0.13; lightRange = 3.0; lightColor = { 1.0, 0.25, 0.25 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 

BulletData JetBolt 
{ bulletShapeName = "shotgunbolt.dts"; explosionTag = blasterExp; damageClass = 0; damageValue = 0.125; damageType = $ImpactDamageType; muzzleVelocity = 300.0; totalTime = 2.0; liveTime = 1.125; lightRange = 3.0; lightColor = { 1.0, 0.25, 0.25 }; inheritedVelocityScale = 0.5; isVisible = True; rotationPeriod = 1; }; 

BulletData PlasmaBolt 
{ bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.45; damageType = $PlasmaDamageType; explosionRadius = 4.0; muzzleVelocity = 55.0; totalTime = 3.0; liveTime = 2.0; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

BulletData FlamerBolt 
{ bulletShapeName = "plasmabolt.dts"; explosionTag = plasmaExp; damageClass = 1; damageValue = 0.08; damageType = $PlasmaDamageType; explosionRadius = 10.0; muzzleVelocity = 60.0; totalTime = 5.0; liveTime = 3.5; lightRange = 8.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

BulletData OmegaBolt 
{ bulletShapeName = "fusionbolt.dts"; explosionTag = energyExp; damageClass = 0; damageValue = 0.05; damageType = $ElectricityDamageType; aimDeflection = 0.015; muzzleVelocity = 30.0; totalTime = 1.0; liveTime = 1.0; lightRange = 3.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.3; isVisible = True; soundId = SoundJetLight; }; 

GrenadeData GrenadeShell 
{ bulletShapeName = "grenade.dts"; explosionTag = grenadeExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 0.4; damageType = $ShrapnelDamageType; explosionRadius = 15; kickBackStrength = 150.0; maxLevelFlightDist = 150; totalTime = 30.0; liveTime = 1.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; }; 

GrenadeData MortarShell 
{ bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.3; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 1.0; damageType = $MortarDamageType; explosionRadius = 20.0; kickBackStrength = 250.0; maxLevelFlightDist = 275; totalTime = 30.0; liveTime = 2.0; projSpecialTime = 0.01; inheritedVelocityScale = 0.5; smokeName = "mortartrail.dts"; }; 

GrenadeData MortarTurretShell 
{ bulletShapeName = "mortar.dts"; explosionTag = mortarExp; collideWithOwner = True; ownerGraceMS = 400; collisionRadius = 1.0; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 1.32; damageType = $MortarDamageType; explosionRadius = 30.0; kickBackStrength = 250.0; maxLevelFlightDist = 400; totalTime = 1000.0; liveTime = 2.0; projSpecialTime = 0.05; inheritedVelocityScale = 0.5; smokeName = "mortartrail.dts"; }; 

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
smokeName = "mortartrail.dts"; 
}; 




GrenadeData antiairShell 
{ 
bulletShapeName = "mortar.dts"; 
explosionTag = Shockwave; 
collideWithOwner = True; 
ownerGraceMS = 10; 
collisionRadius = 0.3; 
mass = 5.0; 
elasticity = 0.01; 
damageClass = 1; 
damageValue = 0; 
damageType = $FlashDamageType; 
explosionRadius = 2.0; 
kickBackStrength = 0.0; 
maxLevelFlightDist = 2000; 
totalTime = 2.0; 
liveTime = 0; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.01; 
smokeName = "smoke.dts"; 
smokeDist = 100.75; 
}; 



GrenadeData B17Payload 
{ 
bulletShapeName = "arrow50.dts"; 
explosionTag = B17Bomb; 
collideWithOwner = True; 
ownerGraceMS = 250; 
collisionRadius = 9999.0; 
mass = 995.0; 
elasticity = 0.01; 
damageClass = 1; 
damageValue = 9999.0; 
damageType = $MortarDamageType; 
explosionRadius = 9999.0; 
kickBackStrength = 600.0; 
maxLevelFlightDist = 1; 
totalTime = 20.0; 
liveTime = 0.01; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.01; 
smokeName = "mortartrail.dts"; 
smokeDist = 400; 
}; 



GrenadeData MiniNukeShell 
{ 
bulletShapeName = "arrow25.dts"; 
explosionTag = MiniNukeBomb; 
collideWithOwner = True; 
ownerGraceMS = 250; 
collisionRadius = 3.0; 
mass = 5.0; 
elasticity = 0.1; 
damageClass = 1; 
damageValue = 1.5; 
damageType = $MortarDamageType; 
explosionRadius = 700.0; 
kickBackStrength = 200.0; 
maxLevelFlightDist = 1; 
totalTime = 10; 
liveTime = 10; 
projSpecialTime = 0.01; 
inheritedVelocityScale = 0.01; 
smokeName = "mortartrail.dts"; 
smokeDist = 400; 
}; 






GrenadeData SatchelShell 
{ bulletShapeName = "grenade.dts"; explosionTag = rocketExp; collideWithOwner = True; ownerGraceMS = 250; collisionRadius = 0.2; mass = 1.0; elasticity = 0.45; damageClass = 1; damageValue = 2.5; damageType = $MortarDamageType; explosionRadius = 30; kickBackStrength = 350.0; maxLevelFlightDist = 1; totalTime = 30.0; liveTime = 0.01; projSpecialTime = 0.01; inheritedVelocityScale = 0.5; smokeName = "smoke.dts"; };
 
RocketData DiscShell 
{ bulletShapeName = "discb.dts"; explosionTag = discrocketExp; collisionRadius = 0.0; mass = 1.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 7.5; kickBackStrength = 150.0; muzzleVelocity = 500.0; terminalVelocity = 500.0; acceleration = 500.0; totalTime = 6.5; liveTime = 8.0; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 15; trailWidth = 0.3; soundId = SoundDiscSpin; }; 

RocketData StingerMissile 
{ bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 20.5; kickBackStrength = 450.0; muzzleVelocity = 65.0; terminalVelocity = 2000.0; acceleration = 200.0; totalTime = 8.5; liveTime = 18.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

RocketData EspressoMissile 
{ bulletShapeName = "cube2.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 999.0; kickBackStrength = 450.0; muzzleVelocity = 0.1; terminalVelocity = 0.1; acceleration = 0.1; totalTime = 999.0; liveTime = 30.0; lightRange = 30.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 500; trailWidth = 5.0; trailString = "rsmoke.dts"; smokeDist = 15.0; soundId = SoundEspressoTravel; }; 

RocketData FlierRocket 
{ bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 250.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

SeekingMissileData TurretMissile 
{ bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 170.0; muzzleVelocity = 72.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 9; nonSeekingTurningRadius = 75.0; proximityDist = 1.5; smokeDist = 1.75; lightRange = 5.0; lightColor = { 0.4, 0.4, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 

RocketData WhoreRocket 
{ bulletShapeName = "bullet.dts"; explosionTag = whorerocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 25.0; damageType = $MissileDamageType; explosionRadius = 9.5; kickBackStrength = 600.0; muzzleVelocity = 80.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 





SeekingMissileData AntiAirMissile 
{ 
bulletShapeName = "mortar.dts"; 
explosionTag = rocketExp; 
collisionRadius = 0.0; 
mass = 2.0; 
damageClass = 1; 
damageValue = 0; 
damageType = $FlashDamageType; 
explosionRadius = 20.5; 
kickBackStrength = 20; 
muzzleVelocity = 520.0; 
totalTime = 10; 
liveTime = 10; 
seekingTurningRadius = 9; 
nonSeekingTurningRadius = 75.0; 
proximityDist = 1.5; 
smokeDist = 0.3; 
lightRange = 5.0; 
lightColor = { 0.4, 0.4, 1.0 }; 
inheritedVelocityScale = 0.5; 
soundId = SoundJetHeavy; }; 
function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 





SeekingMissileData FlierMissile 
{ bulletShapeName = "rocket.dts"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $MissileDamageType; explosionRadius = 20.5; kickBackStrength = 500.0; muzzleVelocity = 72.0; totalTime = 10; liveTime = 10; seekingTurningRadius = 9; nonSeekingTurningRadius = 75.0; proximityDist = 1.5; smokeDist = 3.75; lightRange = 10.0; lightColor = { 0.4, 0.8, 1.0 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; function SeekingMissile::updateTargetPercentage(%target) { return GameBase::virtual(%target, "getHeatFactor"); } 

RocketData Nuke 
{ bulletShapeName = "rocket.dts"; explosionTag = grenadeExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.70; damageType = $ShrapnelDamageType; explosionRadius = 20.5; kickBackStrength = 450.0; muzzleVelocity = 60.0; terminalVelocity = 2000.0; acceleration = 200.0; totalTime = 8.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 1.8; soundId = SoundJetHeavy; }; 

RocketData Shock 
{ bulletShapeName = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.15; damageType = $MissileDamageType; explosionRadius = 30.0; kickBackStrength = 350.0; muzzleVelocity = 50.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 6.0; liveTime = 4.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData TurretShock 
{ bulletShapeName = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.0; damageType = $MissileDamageType; explosionRadius = 30.0; kickBackStrength = 450.0; muzzleVelocity = 65.0; terminalVelocity = 80.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; soundId = SoundJetHeavy; }; 

RocketData SniperRound 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 0.59; damageType = $SniperDamageType; explosionRadius = 0.1; kickBackStrength = 600.0; muzzleVelocity = 2000.0; terminalVelocity = 2000.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; soundId = SoundJetHeavy; }; 

RocketData RailRound 
{ bulletShapeName = "bullet.dts"; explosionTag = bulletExp0; collisionRadius = 0.0; mass = 2.0; damageClass = 0; damageValue = 3.85; damageType = $SniperDamageType; explosionRadius = 0.1; kickBackStrength = 600.0; muzzleVelocity = 2000.0; terminalVelocity = 2000.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 10.0; lightColor = { 0.25, 0.25, 1 }; inheritedVelocityScale = 1.0; trailType = 1; trailLength = 3000; trailWidth = 0.6; soundId = SoundJetHeavy; }; 

RocketData IonBolt 
{ bulletShapeName = "enbolt.dts"; explosionTag = turretExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.15; damageType = $ElectricityDamageType; explosionRadius = 4; kickBackStrength = 0.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 1.0, 0.7, 0.5 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 50; trailWidth = 0.3; soundId = SoundJetHeavy; }; 

LaserData sniperLaser 
{ laserBitmapName = "laserPulse.bmp"; hitName = "laserhit.dts"; damageConversion = 0.017; baseDamageType = $LaserDamageType; beamTime = 0.5; lightRange = 2.0; lightColor = { 0, 1.0, 1.0 }; detachFromShooter = false; hitSoundId = SoundLaserHit; }; 

LaserData turretLazer 
{ laserBitmapName = "skull_big.bmp"; hitName = "laserhit.dts"; damageConversion = 0.017; baseDamageType = $LaserDamageType; beamTime = 10.0; lightRange = 4.0; lightColor = { 0, 0.0, 2.0 }; detachFromShooter = false; hitSoundId = hyperLazerhit; }; 




LaserData antiariLaser 
{ 
laserBitmapName = "laserPulse.bmp"; 
hitName = "laserhit.dts"; 
damageConversion = 0; 
baseDamageType = $FlashDamageType; 
beamTime = 0.5; 
lightRange = 2.0; 
lightColor = { 0, 1.0, 1.0 }; 
detachFromShooter = true; 
hitSoundId = SoundJetLight; 
}; 




LaserData WraithLaser 
{ laserBitmapName = "laserPulse.bmp"; hitName = "laserhit.dts"; damageConversion = 0.01; baseDamageType = $LaserDamageType; beamTime = 0.5; lightRange = 2.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = false; hitSoundId = SoundLaserHit; }; 

LaserData LaserTag 
{ laserBitmapName = "lightningNew.bmp"; hitName = "laserhit.dts"; damageConversion = 0.01; baseDamageType = $LaserDamageType; beamTime = 0.5; lightRange = 2.0; lightColor = { 1.0, 0.25, 0.25 }; detachFromShooter = false; hitSoundId = SoundLaserHit; }; 

LaserData railLaser 
{ laserBitmapName = "paintPulse.bmp"; hitName = "laserhit.dts"; damageConversion = 0.008; baseDamageType = $SniperDamageType; beamTime = 1.5; lightRange = 5.0; lightColor = { 0.25, 1.0, 0.25 }; detachFromShooter = true; hitSoundId = SoundLaserHit; };

LaserData tunaLaser 
{ laserBitmapName = "paintPulse.bmp"; hitName = "pyrm8.dts"; damageConversion = 0.0; baseDamageType = 0; beamTime = 60; lightRange = 5.0; lightColor = { 0.25, 1.0, 0.25 }; detachFromShooter = true; hitSoundId = SoundTunaHit; };

TargetLaserData targetLaser 
{ laserBitmapName = "paintPulse.bmp"; damageConversion = 0.0; baseDamageType = 0; lightRange = 2.0; lightColor = { 0.25, 1.0, 0.25 }; detachFromShooter = false; }; 

LightningData lightningCharge 
{ bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData lightningCharge2 
{ bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 50.0; coneAngle = 35.0; damagePerSec = 0.10; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 

LightningData turretCharge 
{ bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.06; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; 




LightningData flightDrain 
{ 
bitmapName = "lightningNew.bmp"; 
damageType = $ElectricityDamageType; 
boltLength = 40.0; 
coneAngle = 35.0; 
damagePerSec = 0; 
energyDrainPerSec = 60.0; 
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



LightningData flightDrain2 
{ 
bitmapName = "laserPulse.bmp"; 
damageType = $ElectricityDamageType; 
//boltLength = 340.0; 
//coneAngle = 35.0; 
damagePerSec = 0; 
energyDrainPerSec = 60.0; 
//segmentDivisions = 4; 
//numSegments = 5; 
//beamWidth = 0.125;
updateTime = 120; 
skipPercent = 0.5; 
displaceBias = 0.15; 
lightRange = 3.0; 
lightColor = { 0.25, 0.25, 0.85 }; 
soundId = SoundELFFire; 
}; 

LightningData boltCharge 
{ bitmapName = "lightningNew.bmp"; damageType = $ElectricityDamageType; boltLength = 40.0; coneAngle = 35.0; damagePerSec = 0.20; energyDrainPerSec = 60.0; segmentDivisions = 4; numSegments = 5; beamWidth = 0.125;updateTime = 120; skipPercent = 0.5; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.25, 0.25, 0.85 }; soundId = SoundELFFire; }; function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) { %damVal = %timeSlice * %damPerSec; %enVal = %timeSlice * %enDrainPerSec; GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); %energy = GameBase::getEnergy(%target); %energy = %energy - %enVal; if (%energy < 0) { %energy = 0; } GameBase::setEnergy(%target, %energy); } 





RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);	
	$hacking[%client] = "false";
	if ($debug) echo ("STOPPED " @ %client);
}

function HackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);	
	if($Shifter::AllowHacking)
	{
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player);
			%pName = Client::getName(%client);
			%tName = getTeamName(%team);
			
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
	
			if(%team == %pTeam)
			{
				//echo ("Infecting");
				if (%target.infected == "true")
				{
					Client::sendMessage(%client,0," Your team's " @ %name @ " is already protected from hacking.");	
					return;
				}
				else if(!checkHackable(%name, %shape) || getObjectType(%player.repairTarget) != "Player")
				{
					$hacking[%client] = "true";
					//echo ("Orgin Team = " @ $origTeam[%target]);
					if($origTeam[%target] == "")
					{
						//echo ("No original team set. Marking.");
						$origTeam[%target] = %team;
					}
					
					Client::sendMessage(%client,0,"Infecting " @ %name @ ". Please wait...");
					
					hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
					return;
				}
				return;
			}
				
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking[%client] = "true";
				
				$hacking[%client] = "true";
				
				if ($debug) echo ("Orgin Team = " @ $origTeam[%target]);
				if($origTeam[%target] == "")
				{
					if ($debug) echo ("No original team set. Marking.");
					$origTeam[%target] = %team;
				}
				
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}




// trailType = 1; trailLength = 15; trailWidth = 0.3;
// { bulletShapeName = "newdoor5"; explosionTag = rocketExp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.5; damageType = $ExplosionDamageType; explosionRadius = 999.0; kickBackStrength = 450.0; muzzleVelocity = 0.1; terminalVelocity = 0.1; acceleration = 0.1; totalTime = 999.0; liveTime = 30.0; lightRange = 30.0; lightColor = { 0.1, 0.1, 1.0 }; inheritedVelocityScale = 0.5; trailType = 2; trailString = "rsmoke.dts"; smokeDist = 5.0; soundId = SoundEspressoTravel; }; 




LightningData jailbolt
{
  bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 4.0;
   coneAngle        = 1.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 60.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%aclient = Player::getClient(%target);
if(getObjectType(%target) != "Player")
      {
       return;
      }


if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
        {
        return;
        }


    %teleset = nameToID("MissionCleanup/jailports");
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
                        Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
                        schedule("jLargeForceField::jailSesame("@%target@");",20);
                    }
                    }

}




RepairEffectData RepairBolt 
{ bitmapName = "repairadd.bmp"; boltLength = 20.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 10; skipPercent = 0.6; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.85, 0.25, 0.25 }; }; function RepairBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (%target == %player) { %player.repairTarget = -1; if (GameBase::getDamageLevel(%player) != 0) { %player.repairRate = 3.05; %player.repairTarget = %player; Client::sendMessage(%client, 0, "AutoRepair On"); } else { Client::sendMessage(%client,0,"Nothing in range"); Player::trigger(%player, $WeaponSlot, false); return; } } else { %player.repairTarget = %target; %player.repairRate = 3.1; if (getObjectType(%player.repairTarget) == "Player") { %rclient = Player::getClient(%player.repairTarget); %name = Client::getName(%rclient); } else { %name = GameBase::getMapName(%target); if(%name == "") { %name = (GameBase::getDataName(%player.repairTarget)).description; } } if (GameBase::getDamageLevel(%player.repairTarget) == 0) { Client::sendMessage(%client,0,%name @ " is not damaged"); Player::trigger(%player,$WeaponSlot,false); %player.repairTarget = -1; return; } if (getObjectType(%player.repairTarget) == "Player") { Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client)); } Client::sendMessage(%client,0,"Repairing " @ %name); } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget,%rate); } function RepairBolt::onRelease(%this, %player) { %object = %player.repairTarget; if (%object != -1) { %client = Player::getClient(%player); if (%object == %player) { Client::sendMessage(%client,0,"AutoRepair Off"); } else { if (GameBase::getDamageLevel(%object) == 0) { Client::sendMessage(%client,0,"Repair Done"); } else { Client::sendMessage(%client,0,"Repair Stopped"); } } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object,%rate); } } function RepairBolt::checkDone(%this, %player) { if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) { %object = %player.repairTarget; if (%object == %player) { if (GameBase::getDamageLevel(%player) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } else { if (GameBase::getDamageLevel(%object) == 0) { Player::trigger(%player,$WeaponSlot,false); return; } } } } 

RepairEffectData AutoBolt 
{ bitmapName = "repairadd.bmp"; boltLength = 5.0; segmentDivisions = 4; beamWidth = 0.125; updateTime = 10; skipPercent = 0.6; displaceBias = 0.15; lightRange = 3.0; lightColor = { 0.85, 0.25, 0.25 }; }; function AutoBolt::onAcquire(%this, %player, %target) { %client = Player::getClient(%player); if (%target == %player) { %player.repairTarget = -1; if (GameBase::getDamageLevel(%player) != 0) { %player.repairRate = 0.05; %player.repairTarget = %player; Client::sendMessage(%client, 0, "AutoRepair On"); } else { Client::sendMessage(%client,0,"Full Health"); Player::trigger(%player, $BackpackSlot, false); return; } } %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; GameBase::setAutoRepairRate(%player.repairTarget,%rate); } function AutoBolt::onRelease(%this, %player) { %object = %player.repairTarget; if (%object != -1) { %client = Player::getClient(%player); if (%object == %player) { Client::sendMessage(%client,0,"AutoRepair Off"); } %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; if (%rate < 0) %rate = 0; GameBase::setAutoRepairRate(%object,%rate); } } function AutoBolt::checkDone(%this, %player) { if (%player.repairTarget != -1) { %object = %player.repairTarget; if (%object == %player) { if (GameBase::getDamageLevel(%player) == 0) { Player::trigger(%player,$BackpackSlot,false); return; } } } } 