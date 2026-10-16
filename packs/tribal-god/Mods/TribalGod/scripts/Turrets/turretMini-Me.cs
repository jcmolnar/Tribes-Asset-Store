//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData DissectionImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DissectionPack
{
	description = "Mini-Me Turret";
	shapeFile = "camera";
	className = "Backpack";
    heading = $InvHeading[Turrets];
	imageType = DissectionImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DissectionPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function DissectionPack::onDeploy(%player,%item,%pos)
{ if(DissectionPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function DissectionPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Mini-Me Turret",false,false,false,true,false,false,false,4,true,100, true, "DeployableDissection", "DissectionPack"); }


TurretData DeployableDissection
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = LiLPOOmkiBullet;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 225;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundDryFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-Me";
	damageSkinData = "objectDamageSkins";
};

function DeployableDissection::onAdd(%this)
{
	schedule("DeployableDissection::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Dissection Turret"); }
}

function DeployableDissection::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function DeployableDissection::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function DeployableDissection::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "DissectionPack"]--; }

function DeployableDissection::onPower(%this,%power,%generator)
{}

function DeployableDissection::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this,true); }