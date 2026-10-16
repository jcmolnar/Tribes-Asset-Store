$InvList[MortarTurretPack] = 1;
$MobileInvList[MortarTurretPack] = 1;
$RemoteInvList[MortarTurretPack] = 1;
AddItem(MortarTurretPack);

$CanControl[DeployableMortar] = 0;
$CanAlwaysTeamDestroy[DeployableMortar] = 1;

function deployMortarTurret::Initialize()
{
	$TeamItemCount[0 @ MortarTurretPack] = 0;
	$TeamItemCount[1 @ MortarTurretPack] = 0;
	$TeamItemCount[2 @ MortarTurretPack] = 0;
	$TeamItemCount[3 @ MortarTurretPack] = 0;
	$TeamItemCount[4 @ MortarTurretPack] = 0;
	$TeamItemCount[5 @ MortarTurretPack] = 0;
	$TeamItemCount[6 @ MortarTurretPack] = 0;
	$TeamItemCount[7 @ MortarTurretPack] = 0;
}

ItemImageData MortarTurretPackImage 
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData MortarTurretPack 
{
	description = "Anti-Matter Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = MortarTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.45;
	elasticity = 0.2;
	price = 550;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MortarTurretPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function MortarTurretPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Anti-Matter Turret:<f2> has no auto-sensor and must be controlled manually to fire.");
}

function MortarTurretPack::onDeploy(%player,%item,%pos) 
{
	if(Turret::deployShape(%player, "Anti-Matter Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableMortar, %item, $TurretLocGroundOnly)&& !$build)
		Player::decItemCount(%player,%item);
}

function MortarTurretPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

TurretData DeployableMortar 
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = MortarTurretShell;
	maxDamage = 1.5;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = LargeShockwave;
	description = "Anti Matter Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this) 
{
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,7);
	%this.shieldStrength = 0.010;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Anti-Matter Turret");
}

function DeployableMortar::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "MortarTurretPack"]--;
}

function DeployableMortar::onPower(%this,%power,%generator) 
{
}

function DeployableMortar::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
}
