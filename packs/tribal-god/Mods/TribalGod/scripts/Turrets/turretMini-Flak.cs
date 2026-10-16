//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData MiniFlakTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniFlakTurretPack
{
	description = "Mini-Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = MiniFlakTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniFlakTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else{ Player::deployItem(%player,%item); }
}

function MiniFlakTurretPack::onDeploy(%player,%item,%pos)
{ if(MiniFlakTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function MiniFlakTurretPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Mini-Flak Turret",false,false,false,true,false,false,false,4,true,100, true, "MiniFlakTurret", "MiniFlakTurretPack"); }


TurretData MiniFlakTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFlakproj;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
    range = 150;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.5;
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
	description = "Mini-Flak Turret";
	damageSkinData = "objectDamageSkins";
};

function MiniFlakTurret::onAdd(%this)
{
	schedule("MiniFlakTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Mini-Flak Turret"); }
}

function MiniFlakTurret::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function MiniFlakTurret::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function MiniFlakTurret::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "MiniFlakTurretPack"]--; }

function MiniFlakTurret::onPower(%this,%power,%generator)
{}

function MiniFlakTurret::onEnabled(%this)
{ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }