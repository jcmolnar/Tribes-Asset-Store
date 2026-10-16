$InvList[ParticleBeamTurretPack] = 1;
$MobileInvList[ParticleBeamTurretPack] = 1;
$RemoteInvList[ParticleBeamTurretPack] = 0;

$CanControl[ParticleBeamTurret] = 1;
$EmbedController[ParticleBeamTurret] = 1;
$CanAlwaysTeamDestroy[ParticleBeamTurret] = 1;

function deployParticleBeamTurret::Initialize()
{	$TeamItemCount[0 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[1 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[2 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[3 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[4 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[5 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[6 @ ParticleBeamTurretPack] = 0;
	$TeamItemCount[7 @ ParticleBeamTurretPack] = 0;
}

ItemImageData ParticleBeamTurretPackImage
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ParticleBeamTurretPack
{	description = "Particle Beam Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = ParticleBeamTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ParticleBeamTurretPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function ParticleBeamTurretPack::onDeploy(%player,%item,%pos)
{	if (Turret::deployShape(%player, "Particle Beam (" @ Client::getName(Player::getClient(%player)) @ ")", ParticleBeamTurret, %item, $TurretLocGroundOnly))
		Player::decItemCount(%player,%item);
}

function ParticleBeamTurretPack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "The Particle Beam Turret has no auto-sensor and must be controlled manually to fire.");
}

TurretData ParticleBeamTurret
{	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = ParticleBeam;
	accuFire = false;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 200;
	maxGunEnergy = 100;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 2.0;
	speedModifier = 2.0;
	range = 0;	
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundParticleBeamFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = LargeShockwave;
	description = "Particle Beam Turret";
	damageSkinData = "objectDamageSkins";
};

function ParticleBeamTurret::onAdd(%this)
{	schedule("ParticleBeamTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") 
	{	GameBase::setMapName (%this, "Particle Beam Turret");
	}
}

function ParticleBeamTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function ParticleBeamTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function ParticleBeamTurret::onDestroyed(%this)
{	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ParticleBeamTurretPack"]--;
}

function ParticleBeamTurret::onPower(%this,%power,%generator) 
{
}

function ParticleBeamTurret::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}

