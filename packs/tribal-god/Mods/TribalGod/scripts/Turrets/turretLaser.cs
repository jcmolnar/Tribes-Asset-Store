//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData LaserTurretPackImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData LaserTurretPack {
	description = "Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function LaserTurretPack::onUse(%player,%item){ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }
function LaserTurretPack::onDeploy(%player,%item,%pos){ if(LaserTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }
function LaserTurretPack::onUnmount(%player,%item){ Player::unmountItem(%player,%BackPackSlot); }
function LaserTurretPack::deployShape(%player,%item){ deployable(%player, %item, "Turret", "Laser Turret", false, false, false, true, false, false, false, 4, true, 100, true, "LaserTurret", "LaserTurretPack"); }


TurretData LaserTurret {
	className = "Turret";
	shapeFile = "remoteturret";
	validateShape = false;
	validateMaterials = false;
	projectileType = LaserTrtLaser;
	maxDamage = 1;
	maxEnergy = 250;
	minGunEnergy = 10;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.25;
	speed = 2;
	speedModifier = 2;
	range = 125;
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
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};
function LaserTurret::onAdd(%this){
	Schedule("LaserTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName(%this, "Laser Turret");
}
function LaserTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function LaserTurret::onEndSequence(%this, %thread){ GameBase::setActive(%this, true); }
function LaserTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--; }
function LaserTurret::onPower(%this,%power,%generator){}
function LaserTurret::onEnabled(%this){ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this, true); }	