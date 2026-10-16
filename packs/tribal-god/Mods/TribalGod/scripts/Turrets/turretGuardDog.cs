//------------------------------------|
// Author: ???????????
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData GuardDogImage {
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData ConPack {
	description = "Guard Dog";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = GuardDogImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "Deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function ConPack::onUse(%player,%item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item) Player::mountItem(%player, %item, $BackpackSlot);
	else Player::deployItem(%player, %item);
}
function ConPack::onDeploy(%player, %item, %pos){
	if(ConPack::deployShape(%player, %item)) Player::decItemCount(%player, %item);
}
function CountObjects(%set,%name,%num){
	%count = 0;
	for(%i = 0; %i < %num; %i++){
		%obj = Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set, %i)) == %name) %count++;
	}
	return %count;
}
function ConPack::deployShape(%player,%item){ deployable(%player,%item,"Turret","Guard Dog",false,false,false,true,false,false,false,4,true,100, true, "DeployableConTurret", "ConPack"); }


TurretData DeployableConTurret {
	className = "Turret";       //type classification
	shapeFile = "chainturret";  //"remoteturret";  shape, texture used
	projectileType = Watch;     //projectile fired
	maxDamage = 1;              //stamina of unshielded turret
	maxEnergy = 300;            //amount of turret energy
	minGunEnergy = 1;           //?
	maxGunEnergy = 3;           //?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 0.15;          //1.05,delay between shots (sec)
	speed = 2.0;                //4.0; traverse speed?
	speedModifier = 1.5;        //?
	range = 125;                //sensor range of turret
	visibleToSensor = true;     //shows up on command screen (y,n)
	shadowDetailMask = 4;       //?
	dopplerVelocity = 1;        //0=free attack, 2=motion sensitive?
	castLOS = true;             //tracks when target not visible?
	supression = false;         //acts as sensor jammer, true=yes
	suppressable = false;       //can be jammed, true=yes
	pinger = false;             //?
	mapFilter = 2;              //?
	mapIcon = "M_turret";       //icon as appears on command screen
	debrisId = flashDebrisLarge;//debris graphic
	shieldShapeName = "shield"; //shield type?
	fireSound = SoundPlasmaTurretFire;    //sound when firing
	activationSound = SoundChainTurretOn; //sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;         //explosion graphic
	description = "Guard Dog";            //description
	damageSkinData = "objectDamageSkins"; //damage graphic
};
function DeployableConTurret::onAdd(%this){
	schedule("DeployableConTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Guard Dog");
}
function DeployableConTurret::deploy(%this){ GameBase::playSequence(%this,1,"deploy"); }
function DeployableConTurret::onEndSequence(%this,%thread){ GameBase::setActive(%this,true); }
function DeployableConTurret::onDestroyed(%this){ Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ConPack"]--; }
function DeployableConTurret::onPower(%this,%power,%generator){}
function DeployableConTurret::onEnabled(%this){ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }