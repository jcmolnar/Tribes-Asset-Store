//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData 	MiniELFTurretPackImage {
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};
ItemData MiniELFTurretPack {
	description = "Mini-ELF Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = MiniELFTurretPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function MiniELFTurretPack::onUse(%player,%item){ if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot); else Player::deployItem(%player,%item); }
function MiniELFTurretPack::onDeploy(%player,%item,%pos){ if(MiniELFTurretPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }
function MiniELFTurretPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Mini-ELF Turret",false,false,false,true,false,false,false,4,true,100, true, "MiniELFTurret", "MiniELFTurretPack"); }


TurretData MiniELFTurret {
	maxDamage = 1.0;
	maxEnergy = 350;
	minGunEnergy = 15;
	maxGunEnergy = 25;
	range = 50;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = MiniELFTurretproj;
	reloadDelay = 0.78;
	explosionId = debrisExpMedium;
	description = "Mini-ELF Turret";
	fireSound        = SoundELFIdle;
	activationSound  = Soundspecialdeploy;
	deactivateSound  = SoundTaserdeActivate;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained     = true;
	firingTimeMS    = 1000;
	energyRate      = 30.0;
};
function MiniELFTurret::onAdd(%this){
	schedule("MiniELFTurret::deploy("@ %this @");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Mini-ELF Turret");
}
function MiniELFTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function MiniELFTurret::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function MiniELFTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "MiniELFTurretPack"]--; }
function MiniELFTurret::onPower(%this,%power,%generator){}
function MiniELFTurret::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }