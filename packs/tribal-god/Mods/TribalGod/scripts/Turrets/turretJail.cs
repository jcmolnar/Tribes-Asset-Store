//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData JailTurretImage {
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData JailTurretPack {
	description = "Jail Turret";
	shapeFile = "camera";
	className = "Backpack";
    heading = $InvHeading[JailingItems];
	imageType = JailTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JailTurretPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player, %item);
}
function JailTurretPack::onDeploy(%player,%item,%pos){ if(JailTurretPack::deployShape(%player,%item)) Player::decItemCount(%player,%item); }
function JailTurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Jail Turret",false,false,false,true,false,false,false,4,true,100, true, "JailTurret", "JailTurretPack"); }


TurretData JailTurret{
	className = "Turret";
	shapeFile = "camera";
	projectileType = JailDart;
	maxDamage = 10;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.01;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 45;
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
	description = "Jail Turret";
	damageSkinData = "objectDamageSkins";
};
function JailTurret::onAdd(%this){
	schedule("JailTurret::deploy("@ %this @");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Jail Turret");
}
function JailTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function JailTurret::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function JailTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "JailTurretPack"]--; }
function JailTurret::onPower(%this,%power,%generator){}
function JailTurret::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }	