//===================================================================
// fusion turret
//===================================================================
$DamageScale[larmor, $TurretFusionDamageType] = 0.5;
$DamageScale[lfemale, $TurretFusionDamageType] = 0.5;
$DamageScale[marmor, $TurretFusionDamageType] = 0.5;
$DamageScale[mfemale, $TurretFusionDamageType] = 0.5;
$DamageScale[harmor, $TurretFusionDamageType] = 0.5;
//====================================================
SoundData SoundFusionTurretFire
{
   wavFileName = "tur_fusion.wav";
   profile = Profile3dMed;
};
SoundData TurFusionExplosion
{
   wavFileName = "exp_tur_fusion.wav";
   profile = Profile3dFar;
};
//====================================================
ExplosionData TurFusionExp
{
   shapeName = "fusionex.dts";
   soundId   = TurFusionExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25, 1.0 };
   radFactors = { 1.0, 1.0, 0.0 };
};
//===================================================================
BulletData TurretFusionproj
{
   bulletShapeName    = "proj_turfusion.dts";
   explosionTag       = TurFusionExp;

   damageClass        = 1;
   damageValue        = 2;
   damageType         = $TurretFusionDamageType;
   explosionRadius    = 5.0;

   muzzleVelocity     = 150.0;
   totalTime          = 7.0;
   liveTime           = 5.0;
   lightRange         = 3.0;
   lightColor         = { 3, 3, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundWhizFusion;
};
//===================================================================
TurretData PlasmaTurret
{
	maxDamage = 3.0;
	maxEnergy = 300;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadDelay = 0.65;
	fireSound = SoundFusionTurretFire;
	activationSound = SoundFusionTurretOn;
	deactivateSound = SoundFusionTurretOff;
	whirSound = SoundFusionTurretTurn;
	range = 200;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 3.0;
	speedModifier = 3.0;
	projectileType = TurretFusionproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Fusion Turret";
};