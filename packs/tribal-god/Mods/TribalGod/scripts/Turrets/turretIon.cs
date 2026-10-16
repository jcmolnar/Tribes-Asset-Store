ItemImageData TurretPackImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData TurretPack {
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function TurretPack::onUnmount(%player, %item){ Player::unmountItem(%player, $BackPackSlot); }
function TurretPack::onUse(%player, %item){ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }
function TurretPack::onDeploy(%player, %item, %pos){ if(TurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }
function TurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Ion Turret",false,false,false,true,false,false,false,4,true,100, true, "DeployableTurret", "TurretPack"); }


TurretData DeployableTurret {
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 1;
	maxEnergy = 60;
	minGunEnergy = 1;
	maxGunEnergy = 3;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.25;
	speed = 3.0;
	speedModifier = 1.5;
	range = 135;
	visibleToSensor = true;
	shadowDetailMask = 4;
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
	description = "Ion Turret";
	damageSkinData = "objectDamageSkins";
};
function DeployableTurret::onAdd(%this){
	schedule("DeployableTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	if(GameBase::getMapName(%this) == "") GameBase::setMapName(%this, "Ion Turret");
}
function DeployableTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function DeployableTurret::onEndSequence(%this, %thread){ GameBase::setActive(%this,true); }
function DeployableTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--; }
function DeployableTurret::onPower(%this, %power, %generator){}
function DeployableTurret::onEnabled(%this){ GameBase::setRechargeRate(%this, 5); GameBase::setActive(%this,true); }