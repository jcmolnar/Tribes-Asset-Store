$InvList[vortexTurretPack] = 1;
$MobileInvList[vortexTurretPack] = 1;
$RemoteInvList[vortexTurretPack] = 1;
AddItem(vortexTurretPack);

$CanAlwaysTeamDestroy[deployableVortexTurret] = 1;

function deployVortexTurret::Initialize()
{
	$TeamItemCount[0 @ vortexTurretPack] = 0;
	$TeamItemCount[1 @ vortexTurretPack] = 0;
	$TeamItemCount[2 @ vortexTurretPack] = 0;
	$TeamItemCount[3 @ vortexTurretPack] = 0;
	$TeamItemCount[4 @ vortexTurretPack] = 0;
	$TeamItemCount[5 @ vortexTurretPack] = 0;
	$TeamItemCount[6 @ vortexTurretPack] = 0;
	$TeamItemCount[7 @ vortexTurretPack] = 0;
}

ItemImageData vortexTurretPackImage 
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData vortexTurretPack 
{
	description = "Vortex Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = vortexTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function vortexTurretPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function vortexTurretPack::onDeploy(%player,%item,%pos) 
{
	if(Turret::deployShape(%player, "Vortex Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployablevortexTurret, %item, $TurretLocAnywhere)&& !$build)
		Player::decItemCount(%player,%item);
}

TurretData deployableVortexTurret 
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = vortexBolt;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 3.0;
	speedModifier = 1.5;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Vortex Turret";
	damageSkinData = "objectDamageSkins";
};

function deployableVortexTurret::onAdd(%this)
{	
	schedule("deployableVortexTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Vortex Turret");
}

function deployablevortexTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function deployablevortexTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function deployablevortexTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "vortexTurretPack"]--;
}

function deployablevortexTurret::onPower(%this,%power,%generator) 
{
}

function deployablevortexTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
