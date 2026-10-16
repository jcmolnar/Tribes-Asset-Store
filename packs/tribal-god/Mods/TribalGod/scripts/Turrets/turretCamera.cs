//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData CameraPackImage {
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData CameraPack {
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};
function CameraPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}
function CameraPack::onDeploy(%player, %item, %pos){ if(CameraPack::deployShape(%player, %item)) Player::decItemCount(%player, %item); }
function CameraPack::deployShape(%player, %item){ deployable(%player,%item,"Turret","Camera",false,false,false,true,false,false,false,4,true,100, true, "CameraTurret", "CameraPack"); }


TurretData CameraTurret {
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};
function CameraTurret::onAdd(%this){ Schedule("CameraTurret::deploy("@ %this @");", 1, %this); if(GameBase::getMapName(%this) == "") GameBase::setMapName(%this, "Camera"); }
function CameraTurret::deploy(%this){ GameBase::playSequence(%this, 1, "deploy"); }
function CameraTurret::onEndSequence(%this, %thread){ GameBase::setActive(%this, true); }
function CameraTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @"CameraPack"]--; }