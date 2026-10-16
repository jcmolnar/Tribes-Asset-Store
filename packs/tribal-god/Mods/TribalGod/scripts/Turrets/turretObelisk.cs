//------------------------------------|
// Author: ???????
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
StaticShapeData ObeliskPower
{
	description = "Obelisk Power Source";
	shapeFile = "solar";
	className = "Generator";
	debrisId = flashDebrisLarge;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};

function ObeliskPower::onEnabled(%this)
{ GameBase::setActive(%this,true); }

function ObeliskPower::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20);
}

function ObeliskPower::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPowerPack"]--;
	Generator::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function ObeliskPower::onActivate(%this)
{ GameBase::playSequence(%this, 0, "power"); GameBase::generatePower(%this, true); }

function ObeliskPower::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); // Kill the turret when it goes down
}


StaticShapeData ObeliskOfLight
{
	description = "Obelisk of Light";
	shapeFile = "anten_med";
	className = "Decoration";
	debrisId = flashDebrisLarge;
	maxDamage = 5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
	sfxAmbient = SoundBuzz;
};

function ObeliskOfLight::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
	%realGun = %this.realGun;
	GameBase::setDamageLevel(%realGun, 10);
	%gen = %this.gen;
	%gen.obelisk = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPack"]--;
}
function ObeliskOfLight::onPower(%this,%power,%generator)
{ if(%power){ GameBase::playSequence(%this,0,"power"); }else{ GameBase::stopSequence(%this,0); } }

function ObeliskOfLight::onEnabled(%this)
{ if(GameBase::isPowered(%this))GameBase::playSequence(%this,0,"power"); }

function ObeliskOfLight::onDisabled(%this)
{ GameBase::stopSequence(%this,0); }


ItemImageData ObeliskPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};
ItemData ObeliskPack
{
	description = "Obelisk of Light";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = ObeliskPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ObeliskPack::onUse(%player,%item)
{ if (Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function ObeliskPack::onDeploy(%player,%item,%pos)
{ if (ObeliskPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function ObeliskPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
	
	if (!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	
	%Set = newObject("set", SimSet); 
	%Mask = $StaticObjectType; 
	%num = containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50, 0);
	
	for(%i; %i < %num; %i++)
	{
		%gen = Group::getObject(%Set, %i);
		if(%gen.obeliskpower && %gen.obelisk == "")
		{
			%powered = true;
			break;
		}
	}
	deleteObject(%Set);
	
	if(!%powered)
	{ Client::sendMessage(%client, 0, "Must be within range of an Obelisk Power Source"); return false; }
	
	%obj = getObjectType($los::object);
	
	if (%obj == "InteriorShape")
	{ Client::sendMessage(%client,0,"Cannot deploy in buildings"); return false; }
	
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }
	
	if(!checkDeployArea(%client,$los::position))
	{ return false; }
	
	%rot = GameBase::getRotation(%player); 
	
	%turret2 = newObject("ObeliskBarrel","Turret", RealObeliskOfLight, true);
	addToSet("MissionCleanup", %turret2);
	GameBase::setTeam(%turret2, GameBase::getTeam(%player));
	GameBase::setPosition(%turret2, Vector::add($los::position, "0 0 11.5"));
	GameBase::setRotation(%turret2, %rot);
	
	%turret = newObject("Obelisk", "StaticShape", ObeliskOfLight,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	
	//====Referencing Variables====|
	%turret.realGun = %turret2;
	%turret.gen = %gen;
	%gen.obelisk = %turret2;
	//=============================|
	
	Gamebase::setMapName(%turret, "Obelisk of Light " @ Client::getName(%client));
	Client::sendMessage(%client, 0, "Obelisk of Light deployed");
	playSound(SoundPickupBackpack, $los::position);
	echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed an Obelisk of Light.");
	Echo("Turret: "@ %turret @" | Turret2: "@ %turret2);
	
	//	Remote turrets - kill points to player that deploy them
	Client::setOwnedObject(%client, %turret); 
	Client::setOwnedObject(%client, %player);
	$TeamItemCount[GameBase::getTeam(%player) @"ObeliskPack"]++;
	return true;
}
//===========================================================================================


ItemImageData ObeliskPowerPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -1.0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};
ItemData ObeliskPowerPack
{
	description = "Obelisk Power Source";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ObeliskPowerPack::onUse(%player,%item)
{ if (Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function ObeliskPowerPack::onDeploy(%player, %item, %pos)
{ if (ObeliskPowerPack::deployShape(%player, %item)){ Player::decItemCount(%player,%item); } }

function ObeliskPowerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for "@ %item.description @"s"); return false; }
	
	if (!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	
	%obj = getObjectType($los::object);
	
	if (%obj == "InteriorShape")
	{ Client::sendMessage(%client,0,"Cannot deploy in buildings"); return false; }
	
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }
	
	if(!checkDeployArea(%client,$los::position))
	{ return false; }
	
	%rot = GameBase::getRotation(%player); 
	
	%generator = newObject("ObeliskPower","StaticShape",ObeliskPower,true);
	addToSet("MissionCleanup", %generator );
	GameBase::setTeam(%generator ,GameBase::getTeam(%player));
	GameBase::setPosition(%generator,$los::position);
	GameBase::setRotation(%generator,%rot);
	
	// reference variable
	%generator.obeliskpower = true;
	
	Gamebase::setMapName(%turret,"Obelisk Power Source "@ Client::getName(%client));
	Client::sendMessage(%client,0,"Obelisk Power Source deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @"ObeliskPowerPack"]++;
	echo("MSG: ",%client," deployed an Obelisk Power Source");
	return true;
}


TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 80;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 350;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function RealObeliskOfLight::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function RealObeliskOfLight::onDestroyed(%this)
{ Turret::onDestroyed(%this); }

function RealObeliskOfLight::onPower(%this,%power,%generator)
{}

function RealObeliskOfLight::onEnabled(%this)
{ GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }