//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData NuclearTurretPackImage
{
	shapeFile = "mortar_turret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NuclearTurretPack
{
	description = "Nuclear Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = NuclearTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function NuclearTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function NuclearTurretPack::onDeploy(%player,%item,%pos)
{ if(NuclearTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function NuclearTurretPack::deployShape(%player,%item)
{ deployable(%player, %item, "Turret", "Nuclear Turret", false, false, false, true, false, false, false, 4, true, 100, true, "NuclearDeployableTurret", "NuclearTurretPack"); }


TurretData NuclearDeployableTurret
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = MortarShellNuke;// X-Ecutioner
	maxDamage = 5;
	maxEnergy = 500;
	minGunEnergy = 10;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 5.0;
	speed = 2;
	speedModifier = 2;
	range = 150;
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

function NuclearDeployableTurret::onAdd(%this)
{
	Schedule("NuclearDeployableTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.012;
	if(GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Nuclear Turret"); }
}

function NuclearDeployableTurret::deploy(%this)
{ GameBase::playSequence(%this, 1, "deploy"); }

function NuclearDeployableTurret::onEndSequence(%this,%thread)
{ GameBase::setActive(%this, true); }

function NuclearDeployableTurret::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "NuclearTurretPack"]--; }

function NuclearDeployableTurret::onPower(%this,%power,%generator)
{}

function NuclearDeployableTurret::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this, true); }	