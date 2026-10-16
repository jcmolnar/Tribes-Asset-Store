//===================================================================
// Mortar turret
//===================================================================
$DamageScale[larmor, $TurretMortarDamageType] = 1.0;
$DamageScale[lfemale, $TurretMortarDamageType] = 1.0;
$DamageScale[marmor, $TurretMortarDamageType] = 1.0;
$DamageScale[mfemale, $TurretMortarDamageType] = 1.0;
$DamageScale[harmor, $TurretMortarDamageType] = 1.0;
//===================================================================
SoundData SoundTurMortar
{
   wavFileName = "turret_Mortar.wav";
   profile = Profile3dMed;
};

SoundData mortarturExplosion
{
   wavFileName = "exp_mortar_tur.wav";
   profile = Profile3dLudicrouslyFar;
};
//=================================================
ExplosionData MortarturExp
{
   shapeName = "mortarex.dts";
   soundId   = mortarturExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0.0, 0.0, 3.0 };
   colors[1]  = { 0.0, 0.0, 3.0 };
   colors[2]  = { 0.0, 0.0, 3.0 };
   radFactors = { 1.0, 1.0, 1.0 };


};

//============================================================
GrenadeData TurretMortarproj
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarturExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $TurretMortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
		soundId = SoundWhizMortar;
};


//===================================================================
TurretData mortarTurret
{
	maxDamage = 10.0;
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	reloadDelay = 0.75;
	fireSound = SoundTurMortar;
	activationSound = SoundFusionTurretOn;
	deactivateSound = SoundFusionTurretOff;
	whirSound = SoundFusionTurretTurn;
	//mountSound = SoundMount;
	//dismountSound = SoundDismount;
	range = 350;
	gunRange = 200;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 3.0;
	speedModifier = 3.0;
	projectileType = TurretMortarproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
