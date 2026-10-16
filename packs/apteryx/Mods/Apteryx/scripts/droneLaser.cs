$CanAlwaysTeamDestroy[LaserDrone] = 1;

//this was the first drone I made.  It has some of the functions all drones use in it.

function DroneDeploy(%player) 
{
	Player::Trigger(%player, false);
	%client = Player::getclient(%player);
	%client.throwstrength = 0.5;
	%obj = newObject("","Mine","ThrowingDrone");
	Armor::ThrowGrenade(%player, %obj);
	%player.QuewedDrone = %obj;
}

TurretData LaserDrone
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = LightLaser;
	maxDamage = 1.0;
	maxEnergy = 60;
	minGunEnergy = 1;
	maxGunEnergy = 8;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
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
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Laser Drone";
	damageSkinData = "objectDamageSkins";
};

function LaserDrone::onAdd(%this)
{
	GameBase::setRechargeRate(%this,5);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Laser Drone");
}

function LaserDrone::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function LaserDrone::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function LaserDrone::onDestroyed(%this) 
{
	%this.OrgTeam = "";
}

function LaserDrone::onPower(%this,%power,%generator) 
{
}

function LaserDrone::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

MineData ThrowingDrone 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 4.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = blasterExp;
	explosionRadius = 0.1;
	damageValue = 0.1;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 0.5;
	maxDamage = 1000.0;
};

function ThrowingDrone::onAdd(%this) 
{
}
 
function ThrowingDrone::onRemove(%this)
{
}

function ThrowingDrone::Deploy(%player)
{
%this = %player.QuewedDrone;
%client = player::getclient(%player);
  if(gamebase::isatrest(%this) || %client.DroneMode == 2)
  {
	//Player::Trigger(%player, false);
	Player::decItemCount(%player, BabyNukeAmmo);

//Switch to the correct drone
	if(%client.DroneMode == 0)
		%obj = newObject("hellfiregun", "Turret", LaserDrone, true);
	else if(%client.DroneMode == 1)
		%obj = newObject("hellfiregun", "Turret", ChaingunDrone, true);
	else if(%client.DroneMode == 2)
		%obj = newObject("hellfiregun", "Turret", AirDrone, true);
	else if(%client.DroneMode == 3)
		%obj = newObject("hellfiregun", "Turret", GrenadeDrone, true);
	else if(%client.DroneMode == 4)
		%obj = newObject("hellfiregun", "Turret", AntiTurretDrone, true);
	else if(%client.DroneMode == 5)
		%obj = newObject("hellfiregun", "Turret", GuardianDrone, true);
	else if(%client.DroneMode == 6)
		%obj = newObject("hellfiregun", "Turret", HunterDrone, true);

	NukeList(%obj);
	addToSet("MissionCleanup", %obj);

	GameBase::setTeam(%obj, GameBase::getTeam(%player));
	GameBase::setPosition(%obj, GameBase::getposition(%this));
	GameBase::setRotation(%obj, GameBase::getrotation(%player));
	LaserDrone::Deploy(%obj);

//Guardians and Hunters don't get controlled.. and they get killed after 30 or 3 secs
//normal drones give you weak shields for 6 secs, if you don't already have a normal shield.
	if(%client.DroneMode != 5 && %client.DroneMode != 6)
	{
		Turret::onManualControl(%obj, %player);
		%player.shieldStrength = 0.0075;
		schedule("enddroneshields("@%player@");", 10);
	}
	else if(%client.DroneMode == 5) schedule("Gamebase::setdamagelevel("@%obj@", 10);", 30);
	else schedule("Gamebase::setdamagelevel("@%obj@", 10);", 3);

	deleteobject(%this);
	schedule(""@%player@".QuewedDrone = 0;", 0.1);
  }
  //else schedule("ThrowingDrone::Deploy("@%player@");", 0.25);
}

function enddroneshields(%player)
{
//errortrap for in case they activated a normal shield in the meanwhile
if(%player.shieldstrength < 0.0095) %player.shieldstrength = 0;
}

function LaserDrone::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
}

function LaserDrone::onDismount (%this, %object) 
{	 // When a player ceases to control the turret (either jump or die or whatever)
	%client = %object;
	Turret::checkOperator(%this);
	gamebase::setdamagelevel(%this, 10); //make it die
}

function LaserDrone::Jump(%this, %mom) 
{	%cl = GameBase::getControlClient(%this);
	LaserDrone::onDismount(%this, %cl);
}

function LaserDrone::onDisabled(%this)
{
	gamebase::setdamagelevel(%this, 10);
}

function isDrone(%name)
{
	if(%name == LaserDrone || %name == ChaingunDrone || %name == EMPDrone || %name == GrenadeDrone || %name == AntiTurretDrone || %name == GuardianDrone || %name == AirDrone || %name == HunterDrone || %name == DeployableLaserTurret)
		return true;
	return false;
}