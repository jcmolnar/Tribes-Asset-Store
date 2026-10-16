//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData TaserTrtCPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};

ItemData TaserTrtCPack
{
	description = "Tracking Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = TaserTrtCPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TaserTrtCPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function TaserTrtCPack::onDeploy(%player,%item,%pos)
{ if(TaserTrtCPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function TaserTrtCPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Tracking Turret",false,false,false,true,false,false,false,4,true,100, true, "DeployableTaserTrtC", "TaserTrtCPack"); }


TurretData DeployableTaserTrtC
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TaserTrtCLaser;
	maxDamage = 10;
	maxEnergy = 500;
	minGunEnergy = 2;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 2;
	speedModifier = 2;
	range = 600;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	shieldShapeName = "shield";
	fireSound = SoundTaserFire;
	activationSound = SoundTaserActivate;
	deactivateSound = SoundTaserdeActivate;
	explosionId = flashExpMedium;
	description = "Taser Tracker";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtC::onAdd(%this)
{
	schedule("DeployableTaserTrtC::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 20);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Taser Tracker"); }
}

function DeployableTaserTrtC::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function DeployableTaserTrtC::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function DeployableTaserTrtC::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TaserTrtCPack"]--; }

function DeployableTaserTrtC::onPower(%this,%power,%generator)
{}

function DeployableTaserTrtC::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 20); GameBase::setActive(%this, true); }