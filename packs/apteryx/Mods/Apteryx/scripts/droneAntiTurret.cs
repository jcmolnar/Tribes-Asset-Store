$CanAlwaysTeamDestroy[AntiTurretDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData AntiTurretDrone
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = DroneTurretEliminator;
	maxDamage = 2.0;
	maxEnergy = 20;
	minGunEnergy = 20.0;
	maxGunEnergy = 20.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 4.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 1;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "AntiTurret Drone";
	damageSkinData = "objectDamageSkins";
};

function AntiTurretDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "AntiTurret Drone");
	gamebase::setenergy(%this, 19);
}

function AntiTurretDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function AntiTurretDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function AntiTurretDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function AntiTurretDrone::onPower(%this,%power,%generator) 
{
}

function AntiTurretDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function AntiTurretDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function AntiTurretDrone::onDismount (%this, %object) 
{	 // When a player ceases to control the turret (either jump or die or whatever)
	%client = %object;
	Turret::checkOperator(%this);
	gamebase::setdamagelevel(%this, 10); //make it die
}

function AntiTurretDrone::Jump(%this, %mom) 
{	%cl = GameBase::getControlClient(%this);
	AntiTurretDrone::onDismount(%this, %cl);
}

function AntiTurretDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}