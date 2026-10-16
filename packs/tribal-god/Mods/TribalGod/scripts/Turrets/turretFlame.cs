//------------------------------------|
// Author: ??????
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData FlameTurretPackImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};
ItemData FlameTurretPack {
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = $InvHeading[Turrets];
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function FlameTurretPack::onUse(%player,%item){ if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot); else Player::deployItem(%player,%item); }
function FlameTurretPack::onDeploy(%player,%item,%pos){ if(FlameTurretPack::deployShape(%player,%item)) Player::decItemCount(%player,%item); }
function FlameTurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Flame Turret",false,false,false,true,false,false,false,4,true,100, true, "FlameTurret", "FlameTurretPack"); }


TurretData FlameTurret {
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = FlameLarge;
	maxDamage = 2.0;
	maxEnergy = 30;
	minGunEnergy = 3;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 4.0;
	speedModifier = 1.5;
	range = 45;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_Radar";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFlameTurret;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Flame Turret";
	damageSkinData = "objectDamageSkins";
};
function FlameTurret::onAdd(%this){
	Schedule("FlameTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	if(GameBase::getMapName(%this) == "") GameBase::setMapName(%this, "Flame Turret");
}
function FlameTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function FlameTurret::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function FlameTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "FlameTurretPack"]--; GameBase::setDamageLevel(%this.cyl, 0.6); }
function FlameTurret::onPower(%this,%power,%generator){}
function FlameTurret::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }