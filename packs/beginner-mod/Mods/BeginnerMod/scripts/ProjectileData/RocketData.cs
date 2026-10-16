//=====================================
RocketData DiscShell {
   bulletShapeName = "discb.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.5;
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
   trailWidth  = 0.3;
   soundId = SoundDiscSpin;
};

//=====================================
RocketData FlierRocket {
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.5;
   damageType = $MissileDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity = 65.0;
   terminalVelocity = 80.0;
   acceleration = 5.0;
   totalTime = 10.0;
   liveTime = 11.0;
   lightRange = 5.0;
   lightColor = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

//=====================================
SeekingMissileData TurretMissile {
   bulletShapeName = "rocket.dts";
   explosionTag = rocketExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 0.5;
   damageType = $MissileDamageType;
   explosionRadius = 9.5;
   kickBackStrength = 175.0;
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
function SeekingMissile::updateTargetPercentage(%target){
   return GameBase::virtual(%target, "getHeatFactor");
}