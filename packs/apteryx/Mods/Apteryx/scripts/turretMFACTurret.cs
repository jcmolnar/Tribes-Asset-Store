$InvList[FusionTurretPack] = 1;
$MobileInvList[FusionTurretPack] = 1;
$RemoteInvList[FusionTurretPack] = 1;
AddItem(FusionTurretPack);

$CanControl[DeployableFusionTurret] = 1;
$EmbedController[DeployableFusionTurret] = 1;
$CanAlwaysTeamDestroy[DeployableFusionTurret] = 1;

function deployFusionTurret::Initialize()
{
	$TeamItemCount[0 @ FusionTurretPack] = 0;
	$TeamItemCount[1 @ FusionTurretPack] = 0;
	$TeamItemCount[2 @ FusionTurretPack] = 0;
	$TeamItemCount[3 @ FusionTurretPack] = 0;
	$TeamItemCount[4 @ FusionTurretPack] = 0;
	$TeamItemCount[5 @ FusionTurretPack] = 0;
	$TeamItemCount[6 @ FusionTurretPack] = 0;
	$TeamItemCount[7 @ FusionTurretPack] = 0;
}

ItemImageData FusionTurretPackImage 
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData FusionTurretPack 
{
	description = "MFAC Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = FusionTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 575;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FusionTurretPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function FusionTurretPack::onDeploy(%player,%item,%pos) 
{
	if(Turret::deployShape(%player, "MFAC Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableFusionTurret, %item, $TurretLocGroundOnly)&& !$build)
		Player::decItemCount(%player,%item);
}

TurretData DeployableFusionTurret
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = MFAC;
	maxDamage = 1.15;
	maxEnergy = 225;
	minGunEnergy = 75;
	maxGunEnergy = 10;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 3.0;
	speedModifier = 1.5;
	range = 120;
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
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "MFAC Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFusionTurret::onAdd(%this) 
{		
	schedule("DeployableFusionTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.020;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "MFAC Turret");
}

function DeployableFusionTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFusionTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function DeployableFusionTurret::onDestroyed(%this) 
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	%this.cloakable = "";
	%this.nuetron = "";
	%this.OrgTeam = "";
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "FusionTurretPack"]--;
}

function DeployableFusionTurret::onPower(%this,%power,%generator) 
{
}

function DeployableFusionTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

