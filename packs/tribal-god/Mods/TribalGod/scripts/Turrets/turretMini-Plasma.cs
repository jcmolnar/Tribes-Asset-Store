//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData LaserTurretBPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretBPack
{
	description = "Mini-Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = LaserTurretBPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretBPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else{ Player::deployItem(%player, %item); }
}

function LaserTurretBPack::onDeploy(%player, %item, %pos)
{ if(LaserTurretBPack::deployShape(%player, %item)){ Player::decItemCount(%player, %item); } }

function LaserTurretBPack::deployShape(%player,%item)
{ deployable(%player, %item, "Turret", "Mini-Plasma Turret", false, false, false, true, false, false, false, 4, true, 100, true, "LaserTurretB", "LaserTurretBPack"); }


TurretData LaserTurretB
{
	className = "Turret";
	shapeFile = "remoteturret";
	validateShape = false;
	validateMaterials = false;
	projectileType = PlasmaBolt;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.5;
	speed = 2;
	speedModifier = 2;
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "Mini-Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function LaserTurretB::onAdd(%this)
{
	schedule("LaserTurretB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Mini-Plasma Turret"); }
}

function LaserTurretB::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function LaserTurretB::onEndSequence(%this,%thread)
{ GameBase::setActive(%this, true); }

function LaserTurretB::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretBPack"]--; }

function LaserTurretB::onPower(%this, %power, %generator)
{}

function LaserTurretB::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this, true); }