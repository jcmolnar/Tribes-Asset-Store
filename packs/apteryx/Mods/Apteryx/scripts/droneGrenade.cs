$CanAlwaysTeamDestroy[GrenadeDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData GrenadeDrone
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = DroneGrenade;
	maxDamage = 2.3;
	maxEnergy = 20;
	minGunEnergy = 10.0;
	maxGunEnergy = 10.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.0;
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
	fireSound = SoundFireGrenade;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Grenade Drone";
	damageSkinData = "objectDamageSkins";
};

function GrenadeDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Grenade Drone");
}

function GrenadeDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function GrenadeDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function GrenadeDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function GrenadeDrone::onPower(%this,%power,%generator) 
{
}

function GrenadeDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function GrenadeDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function GrenadeDrone::onDismount (%this, %object) 
{	 // When a player ceases to control the turret (either jump or die or whatever)
	%client = %object;
	Turret::checkOperator(%this);
	gamebase::setdamagelevel(%this, 10); //make it die
}

function GrenadeDrone::Jump(%this, %mom) 
{	%cl = GameBase::getControlClient(%this);
	GrenadeDrone::onDismount(%this, %cl);
}

function GrenadeDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}