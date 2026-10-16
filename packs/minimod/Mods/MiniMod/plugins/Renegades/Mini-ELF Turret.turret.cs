//This is a MiniMod Plugin...
//This is the ELF turret from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

TurretData DeployableShock
{
	maxDamage = 2.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = lightningCharge;
	reloadDelay = 0.3;
	explosionId = flashExpMedium;
	description = "Deployable Mini-ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;

};

function DeployableShock::onAdd(%this)
{
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	//%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Mini-ELF Turret");
	}
}

function DeployableShock::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableShock::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableShock::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}

// Override base class just in case.
function DeployableShock::onPower(%this,%power,%generator) {}
function DeployableShock::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

