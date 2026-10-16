//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData 	MiniSmokeTurretPackImage {
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};
ItemData MiniSmokeTurretPack {
	description = "Mini-Beam Of Pain";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = MiniSmokeTurretPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function MiniSmokeTurretPack::onUse(%player,%item){ if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot); else Player::deployItem(%player,%item); }
function MiniSmokeTurretPack::onDeploy(%player,%item,%pos){ if(MiniSmokeTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }
function MiniSmokeTurretPack::onUnmount(%player,%item){ Player::unmountItem(%player, $BackPackSlot); }
function MiniSmokeTurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Mini-Beam Of Pain",false,false,false,true,false,false,false,4,true,100, true, "MiniSmokeTurret", "MiniSmokeTurretPack"); }


TurretData MiniSmokeTurret {
	maxDamage = 1.5;
	maxEnergy = 350;
	minGunEnergy = 15;
	maxGunEnergy = 25;
	range = 55;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = MiniSmokeTurretproj;
	reloadDelay = 2.1;
	explosionId = debrisExpMedium;
	description = "Mini-Beam Of Pain";
	fireSound        = SoundELFIdle;
	activationSound  = SoundTaserActivate;
	deactivateSound  = SoundTaserdeActivate;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained     = true;
	firingTimeMS    = 2000;
	energyRate      = 30.0;
};
function MiniSmokeTurret::onAdd(%this){
	schedule("MiniSmokeTurret::deploy("@ %this @");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Mini-Beam Of Pain");
}
function MiniSmokeTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function MiniSmokeTurret::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function MiniSmokeTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "MiniSmokeTurretPack"]--; }
function MiniSmokeTurret::onPower(%this,%power,%generator){}
function MiniSmokeTurret::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }