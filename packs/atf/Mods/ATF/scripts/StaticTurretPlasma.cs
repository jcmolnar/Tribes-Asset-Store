//--------------------------------------

BulletData FusionBolt
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = PlasmaExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.55;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 100.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 10.5;
};

//--------------------------------------

TurretData PlasmaTurret
{
	maxDamage = 6.0;
	maxEnergy = 200; //200
	minGunEnergy = 75; //75
	maxGunEnergy = 6;
	reloadDelay = 0.1;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 100;
	dopplerVelocity = 1;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0; //2
	speedModifier = 2.0; //2
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};

//--------------------------------------