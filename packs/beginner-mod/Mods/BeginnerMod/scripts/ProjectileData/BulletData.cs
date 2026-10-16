//=====================================
BulletData ChaingunBullet {
   bulletShapeName = "bullet.dts";
   validateShape = true;
   explosionTag = bulletExp0;
   expRandCycle = 3;
   mass = 0.05;
   bulletHoleIndex = 0;
   damageClass = 0;
   damageValue = 0.11;
   damageType = $BulletDamageType;
   aimDeflection = 0.005;
   muzzleVelocity = 425.0;
   totalTime = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible = False;
   tracerPercentage = 1.0;
   tracerLength = 30;
};

//=====================================
BulletData FusionBolt {
   bulletShapeName = "fusionbolt.dts";
   explosionTag = turretExp;
   mass = 0.05;
   damageClass = 0;
   damageValue = 0.25;
   damageType = $EnergyDamageType;
   muzzleVelocity = 50.0;
   totalTime = 6.0;
   liveTime = 4.0;
   isVisible = True;
   rotationPeriod = 1.5;
};

//=====================================
BulletData MiniFusionBolt {
   bulletShapeName = "enbolt.dts";
   explosionTag = energyExp;
   damageClass = 0;
   damageValue = 0.1;
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

//=====================================
BulletData BlasterBolt {
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

//=====================================
BulletData PlasmaBolt {
   bulletShapeName = "plasmabolt.dts";
   explosionTag = plasmaExp;
   damageClass = 1;
   damageValue = 0.45;
   damageType = $PlasmaDamageType;
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

//=====================================
