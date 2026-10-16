$CanAlwaysTeamDestroy[GuardianDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData GuardianDrone
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = DroneGuardianShot;
	maxDamage = 1.75;
	maxEnergy = 30;
	minGunEnergy = 4.5;
	maxGunEnergy = 10.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.41;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireBlaster;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Guardian Drone";
	damageSkinData = "objectDamageSkins";
};

function GuardianDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Guardian Drone");
}

function GuardianDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function GuardianDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function GuardianDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function GuardianDrone::onPower(%this,%power,%generator) 
{
}

function GuardianDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function GuardianDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function GuardianDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}

//the autokilling as per normal drones does not apply to this drone; it simply dies after 45 secs or when it is disabled by damage.