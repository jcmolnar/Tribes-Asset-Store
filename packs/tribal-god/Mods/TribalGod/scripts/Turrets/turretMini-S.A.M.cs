//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData MiniSAMTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniSAMTurretPack
{
	description = "Mini-S.A.M Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = MiniSAMTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniSAMTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}
function MiniSAMTurretPack::onDeploy(%player,%item,%pos)
{ if(MiniSAMTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function MiniSAMTurretPack::onUnmount(%player,%item)
{ Player::unmountItem(%player, $BackPackSlot); }

function MiniSAMTurretPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Mini-S.a.m Turret",false,false,false,true,false,false,false,4,true,100, true, "MiniSAMTurret", "MiniSAMTurretPack"); }


TurretData MiniSAMTurret
{
	className = "Turret";
	shapeFile = "missileturret";
    validateShape = false;
    validateMaterials = false;
	projectileType = MiniSAMproj;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
    range = 350;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 4;
	speed = 2;
	speedModifier = 2;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-S.A.M Turret";
	damageSkinData = "objectDamageSkins";
};

function MiniSAMTurret::onAdd(%this)
{
	schedule("MiniSAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Mini-S.A.M Turret"); }
}

function MiniSAMTurret::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function MiniSAMTurret::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function MiniSAMTurret::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "MiniSAMTurretPack"]--; }

function MiniSAMTurret::onPower(%this,%power,%generator)
{}

function MiniSAMTurret::onEnabled(%this)
{ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }