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
$PoisonDamageType = 16;
$FireDamageType = 17;
$ShockDamageType = 18;
$AntiAirDamageType = 19;
$BoostDamageType = 20;
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Chaingun Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData ChaingunBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.105 * $Nappy::ProjectileDamage; 
   damageType = $BulletDamageType; 
   aimDeflection = 0.0002; 
   muzzleVelocity = 425.0; 
   totalTime = 1.5; 
   inheritedVelocityScale = 1.0; 
   isVisible = False; 
   tracerPercentage = 1.0; 
   tracerLength = 35; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Silencer Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData SilencerBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.6 * $Nappy::ProjectileDamage; 
   damageType = $LaserDamageType;
   aimDeflection = 0.0013; 
   muzzleVelocity = 625.0; 
   totalTime = 1.5; 
   inheritedVelocityScale = 1.0; 
   isVisible = True; 
   tracerPercentage = 100.0; 
   tracerLength = 30; 
}; 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Shotgun Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData ShotgunBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.025 * $Nappy::ProjectileDamage; 
   damageType = $BulletDamageType;
   aimDeflection = 0.05; 
   muzzleVelocity = 325.0; 
   totalTime = 1; 
   inheritedVelocityScale = 1.0; 
   isVisible = True; 
   tracerPercentage = 100.0; 
   tracerLength = 10; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Tranq Dart
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData TranqDart 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.21 * $Nappy::ProjectileDamage; 
   damageType = $PoisonDamageType; 
   muzzleVelocity = 625.0; 
   totalTime = 1.5; 
   inheritedVelocityScale = 1.0; 
   isVisible = True; 
   tracerPercentage = 100.0; 
   tracerLength = 30; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vulcan Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData VulcanBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.1 * $Nappy::ProjectileDamage; 
   damageType = $BulletDamageType; 
   aimDeflection = 0.0012; 
   muzzleVelocity = 900.0; 
   totalTime = 2; 
   inheritedVelocityScale = 1.0; 
   isVisible = False; 
   tracerPercentage = 2.0; 
   tracerLength = 60; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vulcan Turret Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData TurretBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.2 * $Nappy::ProjectileDamage; 
   damageType = $BulletDamageType; 
   aimDeflection = 0.028; 
   muzzleVelocity = 900.0; 
   totalTime = 4; 
   inheritedVelocityScale = 1.0; 
   isVisible = False; 
   tracerPercentage = 2.0; 
   tracerLength = 60; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Interceptor Jet Bullet
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData JetBullet 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   expRandCycle = 3; 
   mass = 0.05; 
   bulletHoleIndex = 0; 
   damageClass = 0; 
   damageValue = 0.3 * $Nappy::ProjectileDamage; 
   damageType = $BulletDamageType; 
   aimDeflection = 0.005; 
   muzzleVelocity = 425.0; 
   totalTime = 1.5; 
   inheritedVelocityScale = 1.0; 
   isVisible = True; 
   tracerPercentage = 100.0; 
   tracerLength = 30; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Plasma Turret Fusion Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData FusionBolt 
{ 
   bulletShapeName = "fusionbolt.dts"; 
   explosionTag = turretExp; 
   mass = 0.05; 
   damageClass = 0; 
   damageValue = 0.25 * $Nappy::ProjectileDamage; 
   damageType = $EnergyDamageType;
   muzzleVelocity = 50.0; 
   totalTime = 6.0; 
   liveTime = 4.0; 
   isVisible = True; 
   rotationPeriod = 1.5; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Indoor Turret Mini Fusion Bolt 
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData MiniFusionBolt 
{ 
   bulletShapeName = "enbolt.dts"; 
   explosionTag = energyExp; 
   damageClass = 0; 
   damageValue = 0.1 * $Nappy::ProjectileDamage; 
   damageType = $EnergyDamageType; 
   muzzleVelocity = 80.0; 
   totalTime = 4.0; 
   liveTime = 2.0; 
   lightRange = 3.0; 
   lightColor = { 0.25, 0.25, 1.0 }; 
   inheritedVelocityScale = 0.5; 
   isVisible = True; 
   rotationPeriod = 1; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Blaster Bolt 
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData BlasterBolt 
{ 
   bulletShapeName = "shotgunbolt.dts"; 
   explosionTag = blasterExp; 
   damageClass = 0; 
   damageValue = 0.125 * $Nappy::ProjectileDamage; 
   damageType = $BlasterDamageType; 
   muzzleVelocity = 200.0; 
   totalTime = 2.0; 
   liveTime = 1.125; 
   lightRange = 3.0; 
   lightColor = { 1.0, 0.25, 0.25 }; 
   inheritedVelocityScale = 0.5; 
   isVisible = True; 
   rotationPeriod = 1; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Plasma Bolt 
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData PlasmaBolt 
{ 
   bulletShapeName = "plasmabolt.dts"; 
   explosionTag = plasmaExp; 
   damageClass = 1; 
   damageValue = 0.45 * $Nappy::ProjectileDamage; 
   //damageType = $ExplosionDamageType; 
   damageType = $FireDamageType; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Flamer Bolt 
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData FlamerBolt 
{ 
   bulletShapeName = "plasmabolt.dts"; 
   explosionTag = plasmaExp; 
   damageClass = 1; 
   damageValue = 0.08 * $Nappy::ProjectileDamage; 
   damageType = $FireDamageType; 
   explosionRadius = 10.0; 
   muzzleVelocity = 60.0; 
   totalTime = 5.0; 
   liveTime = 3.5; 
   lightRange = 4.0; 
   lightColor = { 1, 1, 0 }; 
   inheritedVelocityScale = 0.3; 
   isVisible = True; 
   soundId = SoundJetLight; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Omega Bolt 
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

BulletData OmegaBolt 
{ 
   bulletShapeName = "fusionbolt.dts"; 
   explosionTag = energyExp; 
   damageClass = 0; 
   damageValue = 0.05 * $Nappy::ProjectileDamage; 
   damageType = $ElectricityDamageType; 
   aimDeflection = 0.0175; 
   muzzleVelocity = 30.0; 
   totalTime = 1.25; 
   liveTime = 1.25; 
   lightRange = 3.0; 
   lightColor = { 1, 1, 0 }; 
   inheritedVelocityScale = 0.3; 
   isVisible = True; 
   soundId = SoundJetLight; 
}; 




///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Grenade Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 0.4 * $Nappy::ProjectileDamage; 
   damageType = $ShrapnelDamageType; 
   explosionRadius = 15; 
   kickBackStrength = 150.0;
   maxLevelFlightDist = 150; 
   totalTime = 30.0; 
   liveTime = 1.0; 
   projSpecialTime = 0.05; 
   inheritedVelocityScale = 0.5; 
   smokeName = "smoke.dts"; 
   smokeDist = 3.0; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Mortar Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 1.0 * $Nappy::ProjectileDamage; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Napalm Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

GrenadeData NapalmShell 
{ 
   bulletShapeName = "mortar.dts"; 
   explosionTag = napalmExp; 
   collideWithOwner = True; 
   ownerGraceMS = 250; 
   collisionRadius = 0.1; 
   mass = 5.0; 
   elasticity = 0.2; 
   damageClass = 1; 
   damageValue = 0.55 * $Nappy::ProjectileDamage; 
   damageType = $FireDamageType; 
   explosionRadius = 12.5; 
   kickBackStrength = 150.0; 
   maxLevelFlightDist = 275; 
   totalTime = 30.0; 
   liveTime = 0.15;
   lightRange = 5.0;
   lightColor = { 1.0, 0.3, 0.2 };
   projSpecialTime = 0.01; 
   inheritedVelocityScale = 0.5; 
   smokeName = "plasmatrail.dts";
   smokeDist = 100.0; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Mortar Turret Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


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
   damageValue = 1.5 * $Nappy::ProjectileDamage; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Shock Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 0.10 * $Nappy::ProjectileDamage; 
   damageType = $ShockDamageType; 
   explosionRadius = 30.0; 
   kickBackStrength = 0.0; 
   maxLevelFlightDist = 1; 
   totalTime = 30.0; 
   liveTime = 0.01; 
   projSpecialTime = 0.01; 
   inheritedVelocityScale = 0.01; 
    smokeName = "mortartrail.dts"; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Satchel Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 2.5 * $Nappy::ProjectileDamage; 
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









///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Disc Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
 
RocketData DiscShell 
{ 
   bulletShapeName = "discb.dts"; 
   explosionTag = rocketExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.5 * $Nappy::ProjectileDamage; 
   damageType = $ExplosionDamageType; 
   explosionRadius = 7.5; 
   kickBackStrength = 150.0; 
   muzzleVelocity = 65.0; 
   terminalVelocity = 80.0; 
   acceleration = 5.0; 
   totalTime = 6.5; 
   liveTime = 8.0; 
   lightRange = 5.0; 
   lightColor = { 0.4, 0.4, 1.0 }; 
   inheritedVelocityScale = 0.5; 
   trailType = 1; 
   trailLength = 15; 
   trailWidth = 0.3; 
   soundId = SoundDiscSpin; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Stinger Missile
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RocketData StingerMissile 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = rocketExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.5 * $Nappy::ProjectileDamage; 
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




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Shockwave Cannon Shell
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RocketData Shock 
{ 
   bulletShapeName = "fusionbolt.dts"; 
   explosionTag = LargeShockwave; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.15 * $Nappy::ProjectileDamage; 
   damageType = $MissileDamageType; 
   explosionRadius = 30.0; 
   kickBackStrength = 350.0; 
   muzzleVelocity = 50.0; 
   terminalVelocity = 80.0; 
   acceleration = 5.0; 
   totalTime = 6.0; 
   liveTime = 4.0; 
   lightRange = 5.0; 
   lightColor = { 1.0, 0.7, 0.5 }; 
   inheritedVelocityScale = 0.5; 
   soundId = SoundJetHeavy; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Sniper Round
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RocketData SniperRound 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 0; 
   damageValue = 0.6 * $Nappy::ProjectileDamage; 
   damageType = $SniperDamageType; 
   explosionRadius = 0.1; 
   kickBackStrength = 600.0; 
   muzzleVelocity = 8000.0; 
   terminalVelocity = 8000.0; 
   acceleration = 5.0; 
   totalTime = 10.0; 
   liveTime = 11.0; 
   lightRange = 10.0; 
   lightColor = { 0.25, 0.25, 1 }; 
   inheritedVelocityScale = 1.0; 
   trailType = 1; 
   trailLength = 369; 
   trailWidth = 0.2; 
   soundId = SoundJetHeavy; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Rail Round
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RocketData RailRound 
{ 
   bulletShapeName = "bullet.dts"; 
   explosionTag = bulletExp0; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 0; 
   damageValue = 0.85 * $Nappy::ProjectileDamage; 
   damageType = $SniperDamageType; 
   explosionRadius = 0.1; 
   kickBackStrength = 600.0; 
   muzzleVelocity = 2000.0; 
   terminalVelocity = 2000.0; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Ion Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RocketData IonBolt 
{ 
   bulletShapeName = "enbolt.dts"; 
   explosionTag = turretExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.125 * $Nappy::ProjectileDamage; 
   damageType = $ElectricityDamageType; 
   explosionRadius = 4; 
   kickBackStrength = 0.0; 
   muzzleVelocity = 200.0; 
   terminalVelocity = 200.0; 
   acceleration = 5.0; 
   totalTime = 10.0; 
   liveTime = 11.0; 
   lightRange = 5.0; 
   lightColor = { 1.0, 0.7, 0.5 }; 
   inheritedVelocityScale = 0.5; 
   trailType = 1; 
   trailLength = 50; 
   trailWidth = 0.3; 
   soundId = SoundJetHeavy; 
}; 












///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Turret Missile
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

SeekingMissileData TurretMissile 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = rocketExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.5 * $Nappy::ProjectileDamage; 
   damageType = $MissileDamageType; 
   explosionRadius = 9.5; 
   kickBackStrength = 170.0; 
   muzzleVelocity = 72.0; 
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


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Anti Air Missile
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


SeekingMissileData AntiAirMissile 
{ 
   bulletShapeName = "mortar.dts"; 
   explosionTag = rocketExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0 * $Nappy::ProjectileDamage; 
   damageType = $AntiAirDamageType; 
   explosionRadius = 20.5; 
   kickBackStrength = 20; 
   muzzleVelocity = 525.0; 
   totalTime = 10; 
   liveTime = 10; 
   seekingTurningRadius = 9; 
   nonSeekingTurningRadius = 75.0; 
   proximityDist = 1.5; 
   smokeDist = 0.3; 
   lightRange = 5.0; 
   lightColor = { 0.4, 0.4, 1.0 }; 
   inheritedVelocityScale = 0.5; 
   soundId = SoundJetHeavy; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Flier Missile
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


SeekingMissileData FlierMissile 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = rocketExp; 
   collisionRadius = 0.0; 
   mass = 2.0; 
   damageClass = 1; 
   damageValue = 0.5 * $Nappy::ProjectileDamage; 
   damageType = $MissileDamageType; 
   explosionRadius = 20.5; 
   kickBackStrength = 500.0; 
   muzzleVelocity = 72.0; 
   totalTime = 10; 
   liveTime = 10; 
   seekingTurningRadius = 9; 
   nonSeekingTurningRadius = 75.0; 
   proximityDist = 1.5; 
   smokeDist = 3.75; 
   lightRange = 10.0; 
   lightColor = { 0.4, 0.8, 1.0 }; 
   inheritedVelocityScale = 0.5; 
   soundId = SoundJetHeavy; 
}; 

function SeekingMissile::updateTargetPercentage(%target) 
{ 
	return GameBase::virtual(%target, "getHeatFactor"); 
} 











///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\









//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              sniper Laser
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

LaserData sniperLaser 
{ 
   laserBitmapName = "laserPulse.bmp"; 
   hitName = "laserhit.dts"; 
   damageConversion = 0.0167 * $Nappy::LaserDamageConversion; 
   baseDamageType = $LaserDamageType; 
   beamTime = 0.5; 
   lightRange = 2.0; 
   lightColor = { 0, 1.0, 1.0 }; 
   detachFromShooter = false; 
   hitSoundId = SoundLaserHit; 
}; 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              rail Laser
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

LaserData railLaser 
{ 
   laserBitmapName = "paintPulse.bmp"; 
   hitName = "laserhit.dts"; 
   damageConversion = 0.008 * $Nappy::LaserDamageConversion; 
   baseDamageType = $SniperDamageType; 
   beamTime = 1.5; 
   lightRange = 5.0; 
   lightColor = { 0.25, 1.0, 0.25 }; 
   detachFromShooter = true; 
   hitSoundId = SoundLaserHit; 
};

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              target Laser
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

TargetLaserData targetLaser 
{ 	
   laserBitmapName = "paintPulse.bmp"; 
   damageConversion = 0.0; 
   baseDamageType = 0; 
   lightRange = 2.0; 
   lightColor = { 0.25, 1.0, 0.25 }; 
   detachFromShooter = false; 
}; 










///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\









//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              turret Charge
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

LightningData turretCharge 
{ 
   bitmapName = "lightningNew.bmp"; 
   damageType = $ElectricityDamageType; 
   boltLength = 40.0; 
   coneAngle = 35.0; 
   damagePerSec = 0.06; 
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




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              bolt Charge
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

LightningData boltCharge 
{ 
   bitmapName = "lightningNew.bmp"; 
   damageType = $ElectricityDamageType; 
   boltLength = 40.0; 
   coneAngle = 35.0; 
   damagePerSec = 0.20; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Lightning::damageTarget
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{ 
%cl = Player::getClient(%target);
	if(Client::getTeam(%cl) != -1){
		%damVal = %timeSlice * %damPerSec; 
		%enVal = %timeSlice * %enDrainPerSec; 
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
		%energy = GameBase::getEnergy(%target); 
		%energy = %energy - %enVal; 
		if (%energy < 0) { 
			%energy = 0; 
		} 
		GameBase::setEnergy(%target, %energy); 
	} 
}













//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              hacking
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Hack Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
	if ($debug) 
		echo ("STOPPED " @ %client);
}

function HackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);	
	if($Shifter::AllowHacking){
		if (%target != %player){
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player);
			%pName = Nappy::getName(%client);
			%tName = getTeamName(%team);
			if(%name == ""){
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
			if(%team == %pTeam){
				if (%target.infected == "true"){
					Client::sendMessage(%client,0," Your team's " @ %name @ " is already protected from hacking.");	
					return;
				}
				else if(!checkHackable(%name, %shape) || getObjectType(%player.repairTarget) != "Player"){
					$hacking[%client] = "true";
					if($origTeam[%target] == ""){
						$origTeam[%target] = %team;
					}
					Client::sendMessage(%client,0,"Infecting " @ %name @ ". Please wait...");
					hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
					return;
				}
				return;
			}
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player"){
				if(getObjectType(%player.repairTarget) == "Player"){
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				else{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else{
				if(%name == "False" && %shape == "magcargo"){
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}
				$hacking[%client] = "true";
				if ($debug) 
					echo ("Orgin Team = " @ $origTeam[%target]);
				if($origTeam[%target] == ""){
					if ($debug) 
						echo ("No original team set. Marking.");
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
			}
		}	
	}
	else{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              jail bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
	if(getObjectType(%target) != "Player"){
		return;
	}
	if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId)){
		return;
	}
	%teleset = nameToID("MissionCleanup/jailports");
	%playerTeam = GameBase::getTeam(%target);
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){
		%oteam=GameBase::getTeam(%o);
		if(%oteam != %playerTeam){
			%sclient = Player::getClient(%shooterId);
			%sname = Nappy::getName(%sclient);
			%client = Player::getClient(%target);
			%vname = Nappy::getName(%client);
			GameBase::SetPosition(%target,GameBase::GetPosition(%o));
			Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
			Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
			echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
			schedule("jLargeForceField::jailSesame("@%target@");",20);
		}
	}
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Repair Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RepairEffectData RepairBolt 
{ 
   bitmapName = "repairadd.bmp"; 
   boltLength = 20.0; 
   segmentDivisions = 4; 
   beamWidth = 0.125; 
   updateTime = 450; 
   skipPercent = 0.6; 
   displaceBias = 0.15; 
   lightRange = 3.0; 
   lightColor = { 0.85, 0.25, 0.25 }; 
};

 
function RepairBolt::onAcquire(%this, %player, %target) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) == RegenerationPack){ 
		if(Player::isTriggered(%player,$BackpackSlot)){
			Player::trigger(%player,$BackpackSlot,false); 
			GameBase::setAutoRepairRate(%player.repairTarget,0);
		}
	}

	%client = Player::getClient(%player);
	$ClientRepairing[%client] = 1;
	%targetTeam = GameBase::getTeam(%target);
	%clientTeam = GameBase::getTeam(%client);

	if(%targetTeam != %clientTeam && getObjectType(%target) == "Turret"){
		Client::sendMessage(%client,0,"You idiot!");
		Player::trigger(%player, $WeaponSlot, false);
		%player.repairTarget = -1; 
		return;
	}
	else{
		if(%target == %player){ 
			%player.repairTarget = -1; 
			if(GameBase::getDamageLevel(%player) != 0){

				%armor = Player::getArmor(%client);

				if(%armor == "sarmor" || %armor == "sfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Scout];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Scout];
				}
				else if(%armor == "sparmor" || %armor == "spfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Spy];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Spy];
				}
				else if(%armor == "sniparmor" || %armor == "snipfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Sniper];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Sniper];
				}
				else if(%armor == "mercarmor" || %armor == "mercfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Mercenary];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Mercenary];
				}
				else if(%armor == "engarmor" || %armor == "engfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Engineer];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Engineer];
				}
				else if(%armor == "flagarmor" || %armor == "flagfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, FlagMover];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, FlagMover];
				}
				else if(%armor == "barmor" || %armor == "bfemale"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Burster];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Burster];
				}
				else if(%armor == "darmor"){
					%player.repairRate = $Nappy::Projectile[RepairBolt, autoRepairRate, Cyborg];
					%player.repairDrain = $Nappy::Projectile[RepairBolt, autoRepairEnergyDrain, Cyborg];
				}

				%player.repairTarget = %player; 
				Client::sendMessage(%client, 0, "AutoRepair On");
			} 
			else{ 
				Client::sendMessage(%client,0,"Nothing in range");
				Player::trigger(%player, $WeaponSlot, false);
				return;
			} 
		} 
		else{ 
			%player.repairTarget = %target; 
			%player.repairRate = $Nappy::Projectile[RepairBolt, ObjectRepairRate]; 
			%player.repairDrain = $Nappy::Projectile[RepairBolt, ObjectEnergyDrain];
			if(getObjectType(%player.repairTarget) == "Player"){
				%player.repairRate = $Nappy::Projectile[RepairBolt, OtherPlayerRepairRate]; 
				%player.repairDrain = $Nappy::Projectile[RepairBolt, OtherPlayerEnergyDrain];
				%rclient = Player::getClient(%player.repairTarget); 
				%name = Nappy::getName(%rclient); 
			} 
			else { 
				%name = GameBase::getMapName(%target); 
				if(%name == ""){ 
					%name = (GameBase::getDataName(%player.repairTarget)).description; 
				} 
			} 
			if(GameBase::getDamageLevel(%player.repairTarget) == 0){ 
				Client::sendMessage(%client,0,%name @ " is not damaged"); 
				Player::trigger(%player,$WeaponSlot,false); 
				%player.repairTarget = -1; 
				return; 
			} 
			if(getObjectType(%player.repairTarget) == "Player"){ 
				Client::sendMessage(%rclient,0,"Being repaired by " @ Nappy::getName(%client)); 
			} 
			Client::sendMessage(%client,0,"Repairing " @ %name); 
		} 
		Repair::repair(%this, %player, %target);
	}
}
 
function RepairBolt::onRelease(%this, %player) 
{ 
	%client = Player::getClient(%player);
	$ClientRepairing[%client] = 0;
	%object = %player.repairTarget; 
	if (%object != -1) { 
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
		GameBase::setAutoRepairRate(%object,0); 
	} 
} 



function Repair::repair(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if($ClientRepairing[%client] == 1 && GameBase::getDamageLevel(%player.repairTarget) != 0){
		%rate = %player.repairRate;
		GameBase::setAutoRepairRate(%player.repairTarget,%rate);
		%energy = GameBase::getEnergy(%player);
		%energy = %energy - %player.repairDrain;
		if(%energy < 0){
			%energy = 0;
			GameBase::setEnergy(%player, %energy);
			return;
		}
		GameBase::setEnergy(%player, %energy);
		schedule("Repair::checkDone(" @ %this @ "," @ %player @ "," @ %target @ ");", 0.2); 
	}
	else{
		GameBase::setAutoRepairRate(%player.repairTarget,0);
	}	
}

function Repair::checkDone(%this, %player, %target) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == Fixit) && %player.repairTarget != -1) { 
		%object = %player.repairTarget; 
		if(%object == %player) { 
			if(GameBase::getDamageLevel(%player) == 0){ 
				Player::trigger(%player,$WeaponSlot,false);
				GameBase::setAutoRepairRate(%player.repairTarget,0); 
				return; 
			} 
		} 
		else{ 
			if(GameBase::getDamageLevel(%object) == 0){ 
				Player::trigger(%player,$WeaponSlot,false);
				GameBase::setAutoRepairRate(%player.repairTarget,0);
				return; 
			} 
		} 
		Repair::repair(%this, %player, %target);
	} 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Auto Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RepairEffectData AutoBolt 
{ 
   bitmapName = "repairadd.bmp"; 
   boltLength = 5.0; 
   segmentDivisions = 4; 
   beamWidth = 0.125; 
   updateTime = 450; 
   skipPercent = 0.6; 
   displaceBias = 0.15; 
   lightRange = 3.0; 
   lightColor = { 0.85, 0.25, 0.25 }; 
}; 

function AutoBolt::onAcquire(%this, %player, %target) 
{ 
		//auto repair cheat fix
	if(Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == Fixit){ 
		if(Player::isTriggered(%player,$WeaponSlot)){
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setAutoRepairRate(%player.repairTarget,0); 
		}
	}
	%client = Player::getClient(%player); 
	if (%target == %player) { 
		%player.repairTarget = -1; 
		if(GameBase::getDamageLevel(%player) != 0) { 
			%player.repairRate = 0.075; 
			%player.repairTarget = %player; 
			Client::sendMessage(%client, 0, "AutoRepair On"); 
		} 
		else { 
			Client::sendMessage(%client,0,"Full Health"); 
			Player::trigger(%player, $BackpackSlot, false); 
			return; 
		} 
	} 
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; 
	GameBase::setAutoRepairRate(%player.repairTarget,%rate); 
} 

function AutoBolt::onRelease(%this, %player) 
{ 
	%object = %player.repairTarget; 
	if (%object != -1) { 
		%client = Player::getClient(%player); 
		if (%object == %player) { 
			Client::sendMessage(%client,0,"AutoRepair Off"); 
		} 
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; 
		if (%rate < 0) 
			%rate = 0; 
		GameBase::setAutoRepairRate(%object,%rate); 
	} 
} 

function AutoBolt::checkDone(%this, %player) 
{ 
	if (%player.repairTarget != -1) { 
		%object = %player.repairTarget; 
		if (%object == %player) { 
			if (GameBase::getDamageLevel(%player) == 0) { 
				Player::trigger(%player,$BackpackSlot,false); 
				return; 
			} 
		} 
	} 
}








//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Pack Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RepairEffectData PackBolt
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

function PackBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	$ClientPacking[%client] = 0;
}

function PackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%client,$BackpackSlot) == -1){
		%name = GameBase::getDataName(%target);
		if(%name == "BlastDoorShape")
			%item = BlastDoor;
		else if(%name == "DeployableInvStation")
			%item = DeployableInvPack;
		else if(%name == "doorthreebyfourForceFieldShape")
			%item = doorthreebyfourForceField;
		else if(%name == "doorfourbyeightForceFieldShape")
			%item = doorfourbyeightForceField;
		else if(%name == "doorfourbyfourteenForceFieldShape")
			%item = doorfourbyfourteenForceField;
		else if(%name == "doorfourbyseventeenForceFieldShape")
			%item = doorfourbyseventeenForceField;
		else if(%name == "doorfivebyfiveForceFieldShape")
			%item = doorfivebyfiveForceField;
		else if(%name == "LargePlatformDoorShape")
			%item = LargePlatformDoor;
		else if(%name == "BlastWall")
			%item = BlastWallPack;
		else if(%name == "newdooroneRShape")
			%item = newdooroneR;
		else if(%name == "newdoortwoRShape")
			%item = newdoortwoR;
		else if(%name == "newdoorthreeRShape")
			%item = newdoorthreeR;
		else if(%name == "newdoorfourRShape")
			%item = newdoorfourR;
		else if(%name == "newdooroneLShape")
			%item = newdooroneL;
		else if(%name == "newdoortwoLShape")
			%item = newdoortwoL;
		else if(%name == "newdoorthreeLShape")
			%item = newdoorthreeL;
		else if(%name == "newdoorfourLShape")
			%item = newdoorfourL;
		else if(%name == "DeployableForceFieldShape")
			%item = DeployableForceField;
		else if(%name == "LargeForceFieldShape")
			%item = LargeForceField;
		else if(%name == "DeployablePlatformShape")
			%item = DeployablePlatform;
		else if(%name == "MediumPlatformShape")
			%item = MediumPlatform;
		else if(%name == "LargePlatformShape")
			%item = LargePlatform;
		else if(%name == "DeployableFlagStand")
			%item = FlagstandPack;
		else if(%name == "DeployableSpring")
			%item = SpringPack;
		else if(%name == "BuilderPoleShape")
			%item = BuilderPole;
		else if(%name == "jailpad")
			%item = JailCapPack;
		else if(%name == "DeployableTree")
			%item = TreePack;
		else if(%name == "DeployableTree2")
			%item = TreePack;
		else if(%name == "Hologram1")
			%item = HoloPack;
		else if(%name == "Hologram2")
			%item = HoloPack;
		else if(%name == "Hologram3")
			%item = HoloPack;
		else if(%name == "DeployableAmmoStation")
			%item = DeployableAmmoPack;
		else if(%name == "DeployableComStation")
			%item = DeployableComPack;
		else if(%name == "IonTurret")
			%item = IonTurretPack;
		else if(%name == "ArbitorBox")
			%item = ArbitorPack;
		else if(%name == "DeployableLaser")
			%item = LaserTurretPack;
		else if(%name == "DeployableIndoor")
			%item = IndoorTurretPack;
		else if(%name == "DeployableShock")
			%item = ShockTurretPack;
		else if(%name == "AntiAirTurret")
			%item = AntiAirTurretPack;
		else if(%name == "DeployableElf")
			%item = ElfTurretPack;
 		else if(%name == "DeployableMortar")
			%item = MortarTurretPack;
		else if(%name == "DeployablePlasma")
			%item = PlasmaTurretPack;
		else if(%name == "DeployableRail")
			%item = RailTurretPack;
		else if(%name == "DeployableRocket")
			%item = RocketTurretPack;
		else if(%name == "DeployableVulcan")
			%item = VulcanTurretPack;
		else if(%name == "DeployableMotionSensor")
			%item = MotionSensorPack;
		else if(%name == "DeployablePulseSensor")
			%item = PulseSensorPack;
		else if(%name == "DeployableSensorJammer")
			%item = DeployableSensorJammerPack;
		else if(%name == "AlarmKit")
			%item = BaseAlarm;
		else{
			if(%name.description != "Shape")
				Client::sendMessage(%client, 0, "You can't pack " @ %name.description @ ".");
			else
				Client::sendMessage(%client, 0, "You can't pack this object.");
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		if(%target.beingUsed){
			Client::sendMessage(%client, 0,%name.description @ " is being used.");
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		Client::sendMessage(%client, 0, "Packing " @ %name.description @ ".");
		%count = 0;
		$ClientPacking[%client] = 1;
		PackBolt::checkPackingTime(%player, %item, %target, %count);
	}
	else{
		Client::sendMessage(%client, 0, "You have to remove your backpack before you can repack anything.");
		Player::trigger(%player,$WeaponSlot,false);
	}
}




function PackBolt::checkPackingTime(%player, %item, %target, %count)
{
	%client = Player::getClient(%player);
	%playerTeam = GameBase::getTeam(%player);
	%objectTeam = GameBase::getTeam(%target);
	if(Player::getMountedItem(%client,$BackpackSlot) == -1){
		if(%playerTeam == %objectTeam && (%playerTeam == $origTeam[%target] || $origTeam[%target] == "")){
			if($ClientPacking[%client] == 1){
				%count++;
				if(%count == $Nappy::PackTime){
					if(%item == "ArbitorPack")
						ArbitorBox::UnCloak($ArbitorId);
					deleteObject(%target);
					Player::mountItem(%player,%item,$BackpackSlot);
					Player::incItemCount(%player,%item,1);
					$TeamItemCount[GameBase::getTeam(%player) @ %item]--;
					return;
				}
				else
					schedule("PackBolt::checkPackingTime(" @ %player @ "," @ %item @ "," @ %target @ "," @ %count @ ");", 1, %player);
			}
			else{
				Client::sendMessage(%client, 0, "Packing stopped.");
				Player::trigger(%player,$WeaponSlot,false);
			}
		}
		else{
			Client::sendMessage(%client, 0, "Can't pack objects from the other team.");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else{
		Client::sendMessage(%client, 0, "You have to remove your backpack before you can repack anything.");
		Player::trigger(%player,$WeaponSlot,false);
	}
}





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vehicle Repair Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RepairEffectData VehicleRepairBolt 
{ 
   bitmapName = "repairadd.bmp"; 
   boltLength = 20.0; 
   segmentDivisions = 4; 
   beamWidth = 0.125; 
   updateTime = 450; 
   skipPercent = 0.6; 
   displaceBias = 0.15; 
   lightRange = 3.0; 
   lightColor = { 0.85, 0.25, 0.25 }; 
};

function VehicleRepairBolt::onAcquire(%this, %player, %target) 
{ 
	VehicleRepair::start(%this, %player, %target);
}

function VehicleRepairBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	$ClientRepairing[%client] = 0;
}
 
function VehicleRepair::start(%this, %player, %target)
{
	%client = Player::getClient(%player);
	$ClientRepairing[%client] = 1;
	%name = GameBase::getDataName(%target);
	if(%name == Scout || %name == Jet || %name == Wraith || %name == LAPC || %name == HAPC){
		%name = GameBase::getMapName(%target); 
		%player.repairTarget = %target;
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) { 
			Client::sendMessage(%client,0,%name @ " is not damaged"); 
			Player::trigger(%player,$WeaponSlot,false); 
			GameBase::setAutoRepairRate(%player.repairTarget,0);
			%player.repairTarget = -1; 
			$ClientRepairing[%client] = 0;
			return; 
		}  
		Client::sendMessage(%client,0,"Repairing " @ %name);
		VehicleRepair::repair(%this, %player, %target); 
	}
	else
		Client::sendMessage(%client, 0, "You can only repair vehicles.");
}

function VehicleRepair::check(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if($ClientRepairing[%client] == 1){
		%rate = 0;
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) { 
			Client::sendMessage(%client,0,%name @ " is repaired"); 
			Player::trigger(%player,$WeaponSlot,false); 
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);
			%player.repairTarget = -1; 
			$ClientRepairing[%client] = 0;
			return; 
		} 
		else 
			VehicleRepair::repair(%this, %player, %target);
	}
	else{
		Client::sendMessage(%client,0,"You stopped repairing " @ %name);
		GameBase::setAutoRepairRate(%player.repairTarget,%rate);
	}
}

function VehicleRepair::repair(%this, %player, %target)
{
		schedule("VehicleRepair::check(" @ %this @ "," @ %player @ "," @ %target @ ");", 0.2);
		%targetTeam = GameBase::getTeam(%target);
		%clientTeam = GameBase::getTeam(%client);
		%player.repairTarget = %target; 
		%player.repairRate = 0.2;
		%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; 
		GameBase::setAutoRepairRate(%player.repairTarget,%rate);
 
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vehicle Pack Bolt
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

RepairEffectData VehiclePackBolt
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

function VehiclePackBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	$ClientPacking[%client] = 0;
}

function VehiclePackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%client,$BackpackSlot) == -1){
		%name = GameBase::getDataName(%target);
		if(%name == "Scout")
			%item = ScoutVehiclePack;
		else if(%name == "Wraith")
			%item = WraithVehiclePack;
		else if(%name == "Jet")
			%item = JetVehiclePack;
		else if(%name == "LAPC")
			%item = LAPCVehiclePack;
		else if(%name == "HAPC")
			%item = HAPCVehiclePack;
		else{
			if(%name.description != "Shape")
				Client::sendMessage(%client, 0, "You can't pack " @ %name.description @ ".");
			else
				Client::sendMessage(%client, 0, "You can't pack this object.");
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		if(%target.beingUsed){
			Client::sendMessage(%client, 0,%name.description @ " is being used.");
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		Client::sendMessage(%client, 0, "Packing " @ %name.description @ ".");
		%count = 0;
		$ClientPacking[%client] = 1;
		VehiclePackBolt::checkPackingTime(%player, %item, %target, %count);
	}
	else{
		Client::sendMessage(%client, 0, "You have to remove your backpack before you can repack anything.");
		Player::trigger(%player,$WeaponSlot,false);
	}
}




function VehiclePackBolt::checkPackingTime(%player, %item, %target, %count)
{
	%client = Player::getClient(%player);
	%playerTeam = GameBase::getTeam(%player);
	%objectTeam = GameBase::getTeam(%target);
	if(Player::getMountedItem(%client,$BackpackSlot) == -1){
		if(%playerTeam == %objectTeam && (%playerTeam == $origTeam[%target] || $origTeam[%target] == "")){
			if($ClientPacking[%client] == 1){
				%count++;
				if(%count == $Nappy::VehiclePackTime){
					deleteObject(%target);
					Player::mountItem(%player,%item,$BackpackSlot);
					Player::incItemCount(%player,%item,1);
					if(%item == ScoutVehiclePack)
						%name = ScoutVehicle;
					if(%item == WraithVehiclePack)
						%name = WraithVehicle;
					if(%item == JetVehiclePack)
						%name = JetVehicle;
					if(%item == LAPCVehiclePack)
						%name = LAPCVehicle;
					if(%item == HAPCVehiclePack)
						%name = HAPCVehicle;
					$TeamItemCount[GameBase::getTeam(%player) @ %name]--;
					return;
				}
				else
					schedule("VehiclePackBolt::checkPackingTime(" @ %player @ "," @ %item @ "," @ %target @ "," @ %count @ ");", 1, %player);
			}
			else{
				Client::sendMessage(%client, 0, "Packing stopped.");
				Player::trigger(%player,$WeaponSlot,false);
			}
		}
		else{
			Client::sendMessage(%client, 0, "Can't pack objects from the other team.");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else{
		Client::sendMessage(%client, 0, "You have to remove your backpack before you can repack anything.");
		Player::trigger(%player,$WeaponSlot,false);
	}
}
























