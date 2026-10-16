//===================================================================
// Sonic turret
//===================================================================
$DamageScale[larmor, $TurretSonicDamageType] = 1.0;
$DamageScale[lfemale, $TurretSonicDamageType] = 1.0;
$DamageScale[marmor, $TurretSonicDamageType] = 1.0;
$DamageScale[mfemale, $TurretSonicDamageType] = 1.0;
$DamageScale[harmor, $TurretSonicDamageType] = 1.0;
//===================================================================
SoundData SoundTurSonic
{
   wavFileName = "turret_sonic.wav";
   profile = Profile3dMed;
};
//============================================================
RocketData TurretSonicproj
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = WaveExp;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 1;
   damageValue      = 7;
   damageType       = $TurretSonicDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 300.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.5, 0.75 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;
   trailString = "shield_large.dts";
   smokeDist   = 2;
   //soundId = SoundWhizSonic;
};
//===================================================================
TurretData SonicTurret
{
	maxDamage = 10.0;
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	reloadDelay = 5.0;
	fireSound = SoundTurSonic;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 200;
	gunRange = 300;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "turret_sonic";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretSonicproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Sonic Turret";
};
