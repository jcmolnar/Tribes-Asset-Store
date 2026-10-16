$CanAlwaysTeamDestroy[ChaingunDrone] = 1;

//some general functions that this uses are in the droneLaser file.

TurretData ChaingunDrone
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = DroneBullet;
	maxDamage = 2.0;
	maxEnergy = 60;
	minGunEnergy = 3.0;
	maxGunEnergy = 2.2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.035;
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
	description = "Chaingun Drone";
	damageSkinData = "objectDamageSkins";
};

function ChaingunDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,1);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Chaingun Drone");
}

function ChaingunDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function ChaingunDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function ChaingunDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function ChaingunDrone::onPower(%this,%power,%generator) 
{
}

function ChaingunDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function ChaingunDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function ChaingunDrone::onDismount (%this, %object) 
{	 // When a player ceases to control the turret (either jump or die or whatever)
	%client = %object;
	Turret::checkOperator(%this);
	gamebase::setdamagelevel(%this, 10); //make it die
}

function ChaingunDrone::Jump(%this, %mom) 
{	%cl = GameBase::getControlClient(%this);
	ChaingunDrone::onDismount(%this, %cl);
}

function ChaingunDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}