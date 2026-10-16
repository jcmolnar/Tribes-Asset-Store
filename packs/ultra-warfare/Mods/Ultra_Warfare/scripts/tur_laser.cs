//===================================================================
//Laser turret
//===================================================================
$DamageScale[larmor, $TurretLaserDamageType] = 1.0;
$DamageScale[lfemale, $TurretLaserDamageType] = 1.0;
$DamageScale[marmor, $TurretLaserDamageType] = 1.0;
$DamageScale[mfemale, $TurretLaserDamageType] = 1.0;
$DamageScale[harmor, $TurretLaserDamageType] = 1.0;
//===================================================================
SoundData SoundTurLaser
{
   wavFileName = "turret_laser.wav";
   profile = Profile3dMed;
};
//============================================================
ExplosionData MedLaserBlast
{
   shapeName = "flash_medium.dts";
   soundId   = laserExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;

   timeZero = 0.250;
   timeOne  = 0.650;
	
//                red, grn, blu
   colors[0]  = { 3.0, 0.0, 0.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
 };
//============================================================
RocketData TurretLaserproj
{
   bulletShapeName = "proj_laser_red.dts";
   explosionTag    = MedLaserBlast;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1;
   damageType       = $TurretLaserDamageType;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;

   totalTime        = 5.0;
   liveTime         = 4.0;

  lightRange        = 5.0;
   lightColor        = { 3.0, 0.25, 0.25 };

   isVisible          = True;
   inheritedVelocityScale = 1.0;
   //soundId = SoundWhizLaser;
 };
//===================================================================
TurretData LaserTurret
{
	maxDamage = 10.0;
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	reloadDelay = 0.5;
	fireSound = SoundTurLaser;
	activationSound = SoundFusionTurretOn;
	deactivateSound = SoundFusionTurretOff;
	whirSound = SoundFusionTurretTurn;
	mountSound = SoundMount;
	dismountSound = SoundDismount;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "turret_laser";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretLaserproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Laser Turret";
};

function PlasmaticTurret::onAdd(%this)
{
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
}

function PlasmaticTurret::onPower(%this,%power,%generator)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
}

function PlasmaticTurret::onPower(%this,%power,%generator) {}
function PlasmaticTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}