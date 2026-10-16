//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData RailTurretImage
{
	shapeFile = "hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
}; 

ItemData RailTurret
{
	description = "Rail Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = RailTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
}; 

function RailTurret::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function RailTurret::onDeploy(%player,%item,%pos)
{ if (RailTurret::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function RailTurret::deployShape(%player,%item)
{ deployable(%player,%item,"Turret","Rail Turret" ,false,false,false,true,false,false,false,4,true,100, true, "DeployableRail", "RailTurret"); }


TurretData DeployableRail
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = railLaser;
	maxDamage = 4.0;
	maxEnergy = 155;
	minGunEnergy = 100;
	maxGunEnergy = 150;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 5.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 250;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = flashExpMedium;
	description = "Rail Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRail::onAdd(%this)
{
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Rail Turret"); }
}

function DeployableRail::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function DeployableRail::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function DeployableRail::onPower(%this,%power,%generator)
{}

function DeployableRail::onEnabled(%this)
{ GameBase::setRechargeRate(%this, 8); GameBase::setActive(%this,true); }

function DeployableRail::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
//	Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--;
}