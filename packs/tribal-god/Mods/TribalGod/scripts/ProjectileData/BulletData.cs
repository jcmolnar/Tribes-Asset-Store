//----------------------------------------------| - Begin Bullet Data
BulletData Fireball
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = fireballExp;
   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;
   muzzleVelocity     = 600;
   totalTime          = 6;
   liveTime           = 1;
   inheritedVelocityScale = 0.3;
   isVisible              = true;
};
//----------------------------------------------|

BulletData SpellAbilityProj
{
   bulletShapeName    = "lfemale.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
   damageValue        = 1;
   damageType         = $BulletDamageType;
   aimDeflection      = 0.25;
   muzzleVelocity     = 30;
   totalTime          = 4;
   isVisible          = true;
};
//----------------------------------------------|

BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
   damageValue        = 1;
   damageType         = $ChainGunDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 4000;
   totalTime          = 1;
   isVisible          = false;
   tracerPercentage   = 100;
   tracerLength       = 30;
};
//----------------------------------------------|

BulletData LiLPOOmkiBullet
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;
   damageValue        = 2;
   damageType         = $BulletDamageType;
   muzzleVelocity     = 9500;
   totalTime          = 1;
   isVisible          = true;
};
//----------------------------------------------|

BulletData LiLPOOmkiiBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
   damageValue        = 2;
   damageType         = $LiLPOOmkiiDamageType;
   muzzleVelocity     = 10000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;
   tracerPercentage   = 0;
   tracerLength       = 0;
};
//----------------------------------------------|

BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;
   damageClass        = 0;       
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;
   muzzleVelocity     = 500.0;
   totalTime          = 2;
   liveTime           = 1;
   isVisible          = true;
   rotationPeriod = 1.5;
};
//----------------------------------------------|

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;
   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;
   muzzleVelocity     = 600.0;
   totalTime          = 2;
   liveTime           = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
   rotationPeriod = 1;
};
//----------------------------------------------|

BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;
   damageClass        = 0;
   damageValue        = 1;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
   rotationPeriod = 1;
};
//----------------------------------------------|

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   damageClass        = 1;
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;
   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   inheritedVelocityScale = 0;
   isVisible              = true;
   soundId                = SoundJetLight;
};

BulletData PlasmaBolt2
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag = plasmaExp;
   damageClass = 1;
   damageValue = 2;
   damageType = $PlasmaDamageType;
   explosionRadius = 5;
   muzzleVelocity = 100;
   totalTime = 2;
   liveTime = 2;
   isVisible = true;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0;
};
//----------------------------------------------|

BulletData ChaingunTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
   damageClass        = 0;       
   damageValue        = 0.1;
   damageType         = $CTurretDamageType;
   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible              = false;
   tracerPercentage       = 1.0;
   tracerLength           = 30;
};
//----------------------------------------------|

BulletData ShredderBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 4.55;// 0.055;
	damageType = $ChainGunDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData Spredder {
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;
   expRandCycle       = 0.02;
   aimDeflection      = 0.02;
   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 600.0;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};