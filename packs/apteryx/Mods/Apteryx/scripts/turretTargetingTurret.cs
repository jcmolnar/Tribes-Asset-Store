$InvList[LaserTurretPack] = 1;
$MobileInvList[LaserTurretPack] = 1;
$RemoteInvList[LaserTurretPack] = 1;
AddItem(LaserTurretPack);

$CanAlwaysTeamDestroy[DeployableLaserTurret] = 1;

function deployLaserTurret::Initialize()
{
	$TeamItemCount[0 @ LaserTurretPack] = 0;
	$TeamItemCount[1 @ LaserTurretPack] = 0;
	$TeamItemCount[2 @ LaserTurretPack] = 0;
	$TeamItemCount[3 @ LaserTurretPack] = 0;
	$TeamItemCount[4 @ LaserTurretPack] = 0;
	$TeamItemCount[5 @ LaserTurretPack] = 0;
	$TeamItemCount[6 @ LaserTurretPack] = 0;
	$TeamItemCount[7 @ LaserTurretPack] = 0;
}

ItemImageData LaserTurretPackImage 
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserTurretPack 
{
	description = "Targeting Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.2;
	elasticity = 0.2;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function LaserTurretPack::onDeploy(%player,%item,%pos) 
{
	if(Turret::deployShape(%player, "Targeting Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableLaserTurret, %item, $TurretLocAnywhere)&& !$build)
		Player::decItemCount(%player,%item);
}

TurretData DeployableLaserTurret 
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TrackingLaser;
	maxDamage = 0.75;
	maxEnergy = 200;
	minGunEnergy = 10;
	maxGunEnergy = 7.5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.3;
	speed = 4.0;
	speedModifier = 1.5;
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireTargetingLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Targeting Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaserTurret::onAdd(%this) 
{	
	schedule("DeployableLaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Targeting Turret");
}

function DeployableLaserTurret::deploy(%this) 
{	
		GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaserTurret::onEndSequence(%this,%thread) 
{	
	GameBase::setActive(%this,true);
}

function DeployableLaserTurret::onDestroyed(%this) 
{	
//	Turret::onDestroyed(%this);
//I don't want all of that to happen, so here's most of it
		%this.shieldStrength = 0;
		%this.cloakable = "";
		%this.nuetron = "";
		$turret::count--;	
		GameBase::setRechargeRate(%this,0);
		Turret::onDeactivate(%this);

	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

function DeployableLaserTurret::onPower(%this,%power,%generator) 
{
}

function DeployableLaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

