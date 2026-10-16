//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData 	TaserTrtBPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};

ItemData TaserTrtBPack
{
	description = "Taser Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = TaserTrtBPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TaserTrtBPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function TaserTrtBPack::onDeploy(%player, %item, %pos)
{ if(TaserTrtBPack::deployShape(%player, %item)){ Player::decItemCount(%player, %item); } }

function TaserTrtBPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Taser Turret",false,false,false,true,false,false,false,4,true,100, true, "DeployableTaserTrtB", "TaserTrtBPack"); }


TurretData DeployableTaserTrtB
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TaserTrtBLaser;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 2;
	range = 100;
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
	deactivateSound = SoundTaserDeactivate;
	explosionId = flashExpMedium;
	description = "Taser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTaserTrtB::onAdd(%this)
{
	schedule("DeployableTaserTrtB::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Taser Turret"); }
}

function DeployableTaserTrtB::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function DeployableTaserTrtB::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function DeployableTaserTrtB::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TaserTrtBPack"]--; }

function DeployableTaserTrtB::onPower(%this, %power, %generator)
{}

function DeployableTaserTrtB::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this, true); }