//------------------------------------|
// Author: ?????
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData ArbitorBoxPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData ArbitorBoxPack
{
	description = "Arbitor Device";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ArbitorBoxPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
{ if (ArbitorBoxPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function ArbitorBoxPack::deployShape(%player,%item){
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for "@ %item.description @"es"); return false; }
	
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	
	%obj = getObjectType($los::object);
	
	if(CheckDeployTerrain($los::object, %client, "Most"))
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }
	
	if(Vector::dot($los::normal,"0 0 1") != 1)
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }
	
	if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
	{
		%rot = GameBase::getRotation(%player); 
		%turret = newObject("Arbitor Device","Turret",ArbitorBox,true);
		addToSet("MissionCleanup", %turret);
		GameBase::setTeam(%turret,GameBase::getTeam(%player));
		GameBase::setPosition(%turret,$los::position);
		GameBase::setRotation(%turret,%rot);
		Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Arbitor Device deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
		echo("MSG: ",%client," deployed an Arbitor Device");
		return true;
	}
	else{ return false; }
}
//==========================================================================================

TurretData ArbitorBox
{
	className = "Turret";
	shapeFile = "magcargo";
	maxDamage = 2;
	maxEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Box";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBox::onAdd(%this)
{
	schedule("ArbitorBox::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Arbitor Box"); }
}

function ArbitorBox::deploy(%this)
{ GameBase::playSequence(%this,1,"deploy"); }

function ArbitorBox::onEndSequence(%this,%thread)
{ GameBase::setActive(%this,true); }

function ArbitorBox::onDisabled(%this)
{
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	
	for(%i = %num -1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		%cl = GameBase::getOwnerClient(%obj);
		if(%obj.cloakPack == 0 && %obj.cloakBoost == 0 && %obj.cloakGun == 0 && %obj.cloakplane == 0 && %obj.cloakdevice == 0 && %obj.cloaked >= 1)
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}

function ArbitorBox::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
	if(%this.set)
	{
		%num = Group::objectCount(%this.set);
		for(%i = %num -1; %i >= 0; %i--)
		{
			%obj = Group::getObject(%this.set, %i);
			%cl = GameBase::getOwnerClient(%obj);
			GameBase::startFadeIn(%obj);
			%obj.cloaked = 0;
		}
		deleteObject(%this.set);
	}
}

function ArbitorBox::onPower(%this, %power, %generator)
{}

function ArbitorBox::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this, 5);
	GameBase::setActive(%this, true);
	%Set = newObject("set", SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType | $StaticObjectType | $VehicleObjectType | $MineObjectType | $SimInteriorObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 150, 150, 150, 0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			// don't cloak enemies or the box itself
		}
		else{ GameBase::startFadeOut(%obj); %obj.cloaked = 1; }
	}
	%this.set = %Set;
	Schedule("ArbitorBox::checkArbitorBox("@ %this @");", 0.1, %this);
}	

function ArbitorBox::checkArbitorBox(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled"){ return; }
	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			//don't cloak enemies or the box itself
		}
		else
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}
	%num = Group::objectCount(%this.set);
	
	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			// don't bother checking the other team or the box itself they're not cloaked
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%cl = GameBase::getOwnerClient(%obj);
			if(%obj.cloakPack == 0 && %obj.cloakBoost == 0 && %obj.cloakGun == 0 && %obj.cloakplane == 0 && %obj.cloakdevice == 0 && %obj.cloaked >= 1)
			GameBase::startFadeIn(%obj); //then decloak it
			%obj.cloaked = 0;
		}
	}
	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set
	Schedule("ArbitorBox::checkArbitorBox("@ %this @");", 6.0, %this); // then recheck in 10 seconds
}