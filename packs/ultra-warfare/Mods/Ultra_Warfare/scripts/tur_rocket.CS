//===================================================================
// rocket turret
//===================================================================
$DamageScale[larmor, $TurretRocketDamageType] = 1.0;
$DamageScale[lfemale, $TurretRocketDamageType] = 1.0;
$DamageScale[marmor, $TurretRocketDamageType] = 1.0;
$DamageScale[mfemale, $TurretRocketDamageType] = 1.0;
$DamageScale[harmor, $TurretRocketDamageType] = 1.0;
//===================================================================
//=================================================
//============================================================
SeekingMissileData TurretRocketproj
{
   bulletShapeName = "proj_rocket.dts";
   explosionTag    = SlayerExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $TurretRocketDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}


//===================================================================
TurretData RocketTurret
{
	maxDamage = 10.0;
	maxEnergy = 120;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	reloadDelay = 0.25;
	fireSound = SoundTurMortar;
	activationSound = SoundFusionTurretOn;
	deactivateSound = SoundFusionTurretOff;
	whirSound = SoundFusionTurretTurn;
	mountSound = SoundMount;
	dismountSound = SoundDismount;
	range = 300;
	gunRange = 200;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "turret_rocket";
	shieldShapeName = "shield_medium";
	speed = 3.0;
	speedModifier = 3.0;
	projectileType = TurretRocketproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}
