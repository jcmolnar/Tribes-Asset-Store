//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData WatchdogImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData WatchdogPack
{
	description = "Watchdog";
	shapeFile = "camera";
	className = "Backpack";
    heading = $InvHeading[Turrets];
	imageType = WatchdogImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "TurretsTG";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function WatchdogPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function WatchdogPack::onDeploy(%player,%item,%pos)
{ if(WatchdogPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function WatchdogPack::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Watchdog",false,false,false,true,false,false,false,4,true,100, true, "DeployableWatchdog", "WatchdogPack"); }

TurretData DeployableWatchdog
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = WatchdogLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;
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
	description = "Watchdog";
	damageSkinData = "objectDamageSkins";
};

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if(GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Watchdog"); }
}

function DeployableWatchdog::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function DeployableWatchdog::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function DeployableWatchdog::onDestroyed(%this)
{ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "WatchdogPack"]--; }
function DeployableWatchdog::onPower(%this,%power,%generator)
{}

function DeployableWatchdog::onEnabled(%this)
{ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }	