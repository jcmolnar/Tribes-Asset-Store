$CanAlwaysTeamDestroy[AirDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData AirDrone
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = DroneAirBullet;
	maxDamage = 0.5;
	maxEnergy = 60;
	minGunEnergy = 0.4;
	maxGunEnergy = 0.8;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.0175;
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
	fireSound = SoundPickUpBackpack;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Air Drone";
	damageSkinData = "objectDamageSkins";
};

function AirDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Air Drone");
}

function AirDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function AirDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function AirDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function AirDrone::onPower(%this,%power,%generator) 
{
}

function AirDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function AirDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function AirDrone::onDismount (%this, %object) 
{	 // When a player ceases to control the turret (either jump or die or whatever)
	%client = %object;
	Turret::checkOperator(%this);
	gamebase::setdamagelevel(%this, 10); //make it die
}

function AirDrone::Jump(%this, %mom) 
{	%cl = GameBase::getControlClient(%this);
	AirDrone::onDismount(%this, %cl);
}

function AirDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}