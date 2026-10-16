//--------------------------------------

SeekingMissileData TurretMissile
{
   bulletShapeName = "Shield_Large.dts";
   explosionTag    = MortarExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
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

//--------------------------------------

TurretData RocketTurret
{
	maxDamage = 10.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "MissileTurret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Kameha Turret";
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

//--------------------------------------

//--------------------------------------

SeekingMissileData TurretMissile2
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = RocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 62.0;
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
SeekingMissileData TurretMissile2i
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = AcidExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $PlasmaDamageType;
   explosionRadius  = 2.5;
   kickBackStrength = 0;

   muzzleVelocity    = 62.0;
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
//--------------------------------------

TurretData RocketTurret3
{
	maxDamage = 10.75;
	maxEnergy = 1000;
	minGunEnergy = 0;
	maxGunEnergy = 1;
	range = 650;
	gunRange = 600;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = False;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "cube8";
	shieldShapeName = "shield_medium";
	speed = 4.0;
	speedModifier = 1.5;
	projectileType = Grapple;
	reloadDelay = 0;
	fireSound = SoundElfIdle;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 10.5;
	explosionId = LargeShockwave;
	description = "G. Object";
};

function RocketTurret3::onAdd(%this)
{
	schedule("RocketTurret2::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "G. ObJect");
	}
}

function RocketTurret3::deploy(%this)
{
	schedule("RemoveMissile2(" @ %this @ ", " @ data.maxDamage @ ");",50,%this);
        GameBase::playSequence(%this,1,"deploy");
}

function RemoveMissile2(%this, %damage)
{

	 echo("Good Bye G.Object :)");
	GameBase::setDamageLevel(%this, 50.0);

}

function RocketTurret3::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RocketTurret3::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RocketTurret3::onPower(%this,%power,%generator) {}
function RocketTurret3::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
function RocketTurret3::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//--------------------------------------

TurretData RocketTurret2
{
	maxDamage = 10.75;
	maxEnergy = 1000;
	minGunEnergy = 0;
	maxGunEnergy = 1;
	range = 650;
	gunRange = 600;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield_medium";
	speed = 4.0;
	speedModifier = 1.5;
	projectileType = TurretMissile2;
	reloadDelay = 0.8;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Sentinel";
};

function RocketTurret2::onAdd(%this)
{
	schedule("RocketTurret2::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Sentinel");
	}
}

function RocketTurret2::deploy(%this)
{
	schedule("RemoveMissile2(" @ %this @ ", " @ data.maxDamage @ ");",5,%this);
        GameBase::playSequence(%this,1,"deploy");
}

function RemoveMissile2(%this, %damage)
{

	if ($Debug) echo("Good Bye Sentinel :)");
		GameBase::setDamageLevel(%this, 20.0);

}

function RocketTurret2::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RocketTurret2::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RocketTurret2::onPower(%this,%power,%generator) {}
function RocketTurret2::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
function RocketTurret2::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}


//--------------------------------------

TurretData RocketTurret2i
{
	maxDamage = 10.75;
	maxEnergy = 1000;
	minGunEnergy = 0;
	maxGunEnergy = 1;
	range = 650;
	gunRange = 600;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebris;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield_medium";
	speed = 4.0;
	speedModifier = 1.5;
	projectileType = TurretMissile2i;
	reloadDelay = 0.1;
	fireSound = SoundDryFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = defaultDebris;
	description = "Mini Sentinel";
};

function RocketTurret2i::onAdd(%this)
{
	schedule("RocketTurret2i::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.1;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini Sentinel");
	}
}

function RocketTurret2i::deploy(%this)
{
	schedule("RemoveMissile2i(" @ %this @ ", " @ data.maxDamage @ ");",5,%this);
        GameBase::playSequence(%this,1,"deploy");
}

function RemoveMissile2i(%this, %damage, %player)
{

	if ($Debug) echo("Good Bye thingy :)");
	GameBase::setDamageLevel(%this, 20.0);
	

}

function RocketTurret2i::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RocketTurret2i::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RocketTurret2i::onPower(%this,%power,%generator) {}
function RocketTurret2i::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
function RocketTurret2i::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}