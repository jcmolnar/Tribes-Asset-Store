//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData FireBallTurretPackImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData FireBallTurretPack {
	description = "Fireball Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = FireBallTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function FireBallTurretPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}
function FireBallTurretPack::onDeploy(%player, %item, %pos){ if(FireBallTurretPack::deployShape(%player, %item)) Player::decItemCount(%player, %item); }
function FireBallTurretPack::onUnmount(%player, %item){ Player::unmountItem(%player, $BackPackSlot); }
function FireBallTurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Fireball Turret",false,false,false,true,false,false,false,4,true,100, true, "DeployableFireBall", "FireBallTurretPack"); }


TurretData DeployableFireBall {
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = Fireball;
	maxDamage = 1;
	maxEnergy = 350;
	minGunEnergy = 1;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 3.0;
	speedModifier = 1.5;
	range = 125;
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
	description = "Fireball Turret";
	damageSkinData = "objectDamageSkins";
};
function DeployableFireBall::onAdd(%this){
	Schedule("DeployableFireBall::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Fireball Turret");
}
function DeployableFireBall::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function DeployableFireBall::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function DeployableFireBall::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @"FireBallTurretPack"]--; }
function DeployableFireBall::onPower(%this,%power,%generator){}
function DeployableFireBall::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }