$InvList[NuclearTurretPack] = 1;
$MobileInvList[NuclearTurretPack] = 1;
$RemoteInvList[NuclearTurretPack] = 1;
AddItem(NuclearTurretPack);

$CanAlwaysTeamDestroy[DeployableNuclearTurret] = 1;

function deployNuclearTurret::Initialize()
{
	$TeamItemCount[0 @ NuclearTurretPack] = 0;
	$TeamItemCount[1 @ NuclearTurretPack] = 0;
	$TeamItemCount[2 @ NuclearTurretPack] = 0;
	$TeamItemCount[3 @ NuclearTurretPack] = 0;
	$TeamItemCount[4 @ NuclearTurretPack] = 0;
	$TeamItemCount[5 @ NuclearTurretPack] = 0;
	$TeamItemCount[6 @ NuclearTurretPack] = 0;
	$TeamItemCount[7 @ NuclearTurretPack] = 0;
}
 
ItemImageData NuclearTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NuclearTurretPack
{
	description = "Nuclear Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = NuclearTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 2250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NuclearTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

// plasmatic
function NuclearTurretPack::onDeploy(%player,%item,%pos) 
{
	if(Turret::deployShape(%player, "Nuclear Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableNuclearTurret, %item, $TurretLocAnywhere)&& !$build)
		Player::decItemCount(%player,%item);
}

TurretData DeployableNuclearTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = NukeShell;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 5.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireMortar;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Nuclear Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableNuclearTurret::onAdd(%this)
{
	schedule("DeployableNuclearTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Nuclear Turret");	
}

function DeployableNuclearTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableNuclearTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableNuclearTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "NuclearTurretPack"]--;
}

function DeployableNuclearTurret::onPower(%this,%power,%generator) 
{
}

function DeployableNuclearTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


