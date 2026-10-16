$CanAlwaysTeamDestroy[HunterDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData HunterDrone
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = DroneHunter;
	maxDamage = 1.75;
	maxEnergy = 30;
	minGunEnergy = 4.5;
	maxGunEnergy = 10.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 5.0; //this makes sure it only shoots once
	speed = 4.0;
	speedModifier = 1.5;
	range = 45;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireGrenade;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Hunter Drone";
	damageSkinData = "objectDamageSkins";
};

function HunterDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Hunter Drone");
}

function HunterDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function HunterDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function HunterDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function HunterDrone::onPower(%this,%power,%generator) 
{
}

function HunterDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function HunterDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function HunterDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}

//the autokilling as per normal drones does not apply to this drone; it simply dies after 3 secs or when it is disabled by damage.

function DroneHunter::updateTargetPercentage(%target)
{
	return 1;
}