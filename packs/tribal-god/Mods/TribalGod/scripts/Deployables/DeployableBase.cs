//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

StaticShapeData TG::DeployableBase::BlastWallShape
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisLarge;
	maxDamage = 2000.0;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Blast Wall";
};

function TG::DeployableBase::BlastWallShape::onDestroyed(%this)
{}

StaticShapeData TG::DeployableBase:FFWallShape
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 20000;
	visibleToSensor = true;
	isTranslucent   = false;
	description = "DeployableBase: ForceField Wall";
};

function TG::DeployableBase:FFWallShape::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS = $Server::TeamDamageScale;
	%disable = GameBase::getDisabledDamage(%this);
	
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || %TDS == 1)
	{
		if(!$Server::TourneyMode && %dValue > %disable - 0.05)
		{
			if(%damageLevel > %disable - 0.05){ return; }
			else{ %dValue = %disable - 0.05; }
			%dValue = %damageLevel + %value * %TDS;
		}
	}
	GameBase::setDamageLevel(%this, %dValue);
}

function TG::DeployableBase:FFWallShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$DplBase::EnabledCnt--;
	DeployableBase::CheckCount($DplBase::EnabledCnt, %this.DeployerClient);
}

StaticShapeData TG::DeployableBase:DoorShape
{	
	className = "ForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "ForceField";
	maxDamage = 20000;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Portable Base Door";
};

function TG::DeployableBase:DoorShape::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS = $Server::TeamDamageScale;
	%disable = GameBase::getDisabledDamage(%this);
	
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || %TDS == 1)
	{
		if(!$Server::TourneyMode && %dValue > %disable - 0.05)
		{
			if(%damageLevel > %disable - 0.05){ return; }
			else{ %dValue = %disable - 0.05; }
			%dValue = %damageLevel + %value * %TDS;
		}
	}
	GameBase::setDamageLevel(%this, %dValue);
}

function TG::DeployableBase:DoorShape::onDestroyed(%this)
{	
	StaticShape::onDestroyed(%this);
	$DplBase::EnabledCnt--;
	DeployableBase::CheckCount($DplBase::EnabledCnt);
}

function TG::DeployableBase:DoorShape::onCollision(%this,%obj)
{	
	if(getObjectType(%obj) == "Flier") 
	{ 
		%data = GameBase::getDataName(%obj);
		if($debug)
		Echo(%data @" hitting "@ GameBase::getDataName(%this));
		%damage = GameBase::getDamageLevel(%obj) + 0.01;
		GameBase::setDamageLevel(%obj, %damage);
		PlaySound(SoundFlierCrash, GameBase::getPosition(%obj));
		return;
	}
	
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	return;
	
	TG::DeployableBase:DoorShape::openDoor(%this);
}

function TG::DeployableBase:DoorShape::openDoor(%this) 
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.15);
	schedule("TG::DeployableBase:DoorShape::closeDoor("@ %this @");", 2);
}

function TG::DeployableBase:DoorShape::closeDoor(%this) 
{	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 -6");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);", 0.15);
}

//==========================================================================================
//                    End StaticShapes,   Begin ItemData.
//==========================================================================================

ItemImageData DeployablebaseImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 5.0;
};

ItemData Deployablebase
{
	description = "Deployable Base";
	shapeFile = "forcefield";
	className = "Backpack";
	heading = $InvHeading[DeployableBases];
	imageType = DeployablebaseImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 6000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Deployablebase::onUse(%player,%item)
{ if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function Deployablebase::onDeploy(%player, %item, %pos)
{ if(Deployablebase::deployShape(%player, %item)){ Player::decItemCount(%player, %item); } }

function Deployablebase::deployshape(%player,%item)
{
	$DplBase::EnabledCnt = 5;
	GameBase::getLOSInfo(%player, 3);
	%client = Player::getClient(%player);
	%clientName = Client::getName(%client);
	
	if($TeamItemCount[GameBase::getTeam(%player) @"DeployableBase"] >= $TeamItemMax[Deployablebase])
	{ Client::sendMessage(%client, 0, "Can Not Deploy, You've passed your limit "); return false; }
	
	%playerPos = GameBase::getPosition(%player);
	%obj = getObjectType($los::object);
	%set = newObject("Deployablebase", SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, %playerPos, 175, 175, 175, 0);
	
	if(!TG::CheckFairPlay(%player, "DeployableBase", %set, %num))
	{ return false; }
	
    %objDevice =   newObject("Deployablebase"          , "Staticshape" , TG::DeployableBase::BlastWallShape, false);
	%objDevice.objSide1  = newObject("Deployablebase1" , "Staticshape" , TG::DeployableBase:FFWallShape, false);
	%objDevice.objSide2  = newObject("Deployablebase2" , "Staticshape" , TG::DeployableBase:FFWallShape, false);
	%objDevice.objSide3  = newObject("Deployablebase3" , "Staticshape" , TG::DeployableBase:FFWallShape, false);
	%objDevice.objSide4  = newObject("Deployablebase4" , "Staticshape" , TG::DeployableBase::BlastWallShape, false);
	%objDevice.objSide6  = newObject("Deployablebase6" , "InteriorShape", "BEMfloatingPad.dis");
	%objDevice.objSide8  = newObject("Deployablebase7" , "StaticShape" , InventoryStation, false);
	%objDevice.objSide10 = newObject("Deployablebase8" , "StaticShape" , InventoryStation, false);
	%objDevice.objSide11 = newObject("Deployablebase9" , "StaticShape" , Generator, false);
	%objDevice.objSide12 = newObject("Deployablebase10", "Turret"      , PlasmaTurret, false);
	%objDevice.objSide13 = newObject("Deployablebase11", "Turret"      , PlasmaTurret, false);
	%objDevice.objSide17 = newObject("Deployablebase12", "StaticShape" , TG::DeployableBase::BlastWallShape, false);
	%objDevice.objSide18 = newObject("Deployablebase13", "StaticShape" , TG::DeployableBase::BlastWallShape, false);
	%objDevice.objSide19 = newObject("Deployablebase14", "StaticShape" , TG::DeployableBase:DoorShape, false);
	%objDevice.objSide20 = newObject("Deployablebase15", "Staticshape" , TG::DeployableBase:FFWallShape, false);
	%objDevice.objSide21 = newObject("Deployablebase16", "Staticshape" , CommandStation, false);
	%objDevice.objSide22 = newObject("Deployablebase17", "Staticshape" , TG::DeployableBase:DoorShape, false);
	
	$BaseObj0 = %objDevice;
	$BaseObj1 = %objDevice.objSide1;
	$BaseObj2 = %objDevice.objSide2;
	$BaseObj3 = %objDevice.objSide3;
	$BaseObj4 = %objDevice.objSide4;
	$BaseObj5 = %objDevice.objSide6;
	$BaseObj6 = %objDevice.objSide8;
	$BaseObj7 = %objDevice.objSide10;
	$BaseObj8 = %objDevice.objSide11;
	$BaseObj9 = %objDevice.objSide12;
	$BaseObj10 = %objDevice.objSide13;
	$BaseObj11 = %objDevice.objSide17;
	$BaseObj12 = %objDevice.objSide18;
	$BaseObj13 = %objDevice.objSide19;
	$BaseObj14 = %objDevice.objSide20;
	$BaseObj15 = %objDevice.objSide21;
	$BaseObj16 = %objDevice.objSide22;
	
	
	%objDevice.objSide1.objParent = %objDevice;
	%objDevice.objSide2.objParent = %objDevice;
	%objDevice.objSide3.objParent = %objDevice;
	%objDevice.objSide4.objParent = %objDevice;
	%objDevice.objSide6.objParent = %objDevice;
	%objDevice.objSide8.objParent = %objDevice;
	%objDevice.objSide10.objParent = %objDevice;
	%objDevice.objSide11.objParent = %objDevice;
	%objDevice.objSide12.objParent = %objDevice;
	%objDevice.objSide13.objParent = %objDevice;
	%objDevice.objSide17.objParent = %objDevice;
	%objDevice.objSide18.objParent = %objDevice;
	%objDevice.objSide19.objParent = %objDevice;
	%objDevice.objSide20.objParent = %objDevice;
	%objDevice.objSide21.objParent = %objDevice;
	%objDevice.objSide22.objParent = %objDevice;
	
	
	addToSet(MissionCleanup, %objDevice);
	addToSet(MissionCleanup, %objDevice.objSide1);
	addToSet(MissionCleanup, %objDevice.objSide2);
	addToSet(MissionCleanup, %objDevice.objSide3);
	addToSet(MissionCleanup, %objDevice.objSide4);
	addToSet(MissionCleanup, %objDevice.objSide6);
	addToSet(MissionCleanup, %objDevice.objSide8);
	addToSet(MissionCleanup, %objDevice.objSide10);
	addToSet(MissionCleanup, %objDevice.objSide11);
	addToSet(MissionCleanup, %objDevice.objSide12);
	addToSet(MissionCleanup, %objDevice.objSide13);
	addToSet(MissionCleanup, %objDevice.objSide17);
	addToSet(MissionCleanup, %objDevice.objSide18);
	addToSet(MissionCleanup, %objDevice.objSide19);
	addToSet(MissionCleanup, %objDevice.objSide20);
	addToSet(MissionCleanup, %objDevice.objSide21);
	addToSet(MissionCleanup, %objDevice.objSide22);
	
	// Wall: Back Side: Right
	%pos = Vector::add(GameBase::getPosition(%player), "1.125 1 0");
	GameBase::setRotation(%objDevice.objSide1,"0 0 0");
	GameBase::setPosition(%objDevice.objSide1,%pos);
	GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide1, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide1);
	
	// Wall: Back Side: Left
	%pos = Vector::add(GameBase::getPosition(%player), "8.725 1 0");
	GameBase::setRotation(%objDevice.objSide20,"0 0 0");
	GameBase::setPosition(%objDevice.objSide20,%pos);
	GameBase::setTeam(%objDevice.objSide20,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide20, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide20);
	
	// Wall: Right Side
	%pos = Vector::add(GameBase::getPosition(%player), "-5.1 6.5 0");
	GameBase::setRotation(%objDevice.objSide2,"-0.15 0 4.71339");
	GameBase::setPosition(%objDevice.objSide2,%pos);
	GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide2, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide2);
	
	// Wall: Left Side
	%pos = Vector::add(GameBase::getPosition(%player), "15 6.5 0");
	GameBase::setRotation(%objDevice.objSide3,"0.15 0 4.71339");
	GameBase::setPosition(%objDevice.objSide3,%pos);
	GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide3, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide3);
	
	// Ceiling: Right Side: Front
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 6");
	GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
	GameBase::setPosition(%objDevice.objSide4,%pos);
	GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide4, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide4);
	
	// Ceiling: Right Side: Back
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 6");
	GameBase::setRotation(%objDevice,"4.71339 0 0");
	GameBase::setPosition(%objDevice,%pos);
	GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice);
	
	// Ceiling: Left Side: Front
	%pos = Vector::add(GameBase::getPosition(%player), "10 12.5 6");
	GameBase::setRotation(%objDevice.objSide17,"-4.71339 0 0");
	GameBase::setPosition(%objDevice.objSide17,%pos);
	GameBase::setTeam(%objDevice.objSide17,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide17, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide17);
	
	// Ceiling: Left Side: Back
	%pos = Vector::add(GameBase::getPosition(%player), "10 .5 6");
	GameBase::setRotation(%objDevice.objSide18,"4.71339 0 0");
	GameBase::setPosition(%objDevice.objSide18,%pos);
	GameBase::setTeam(%objDevice.objSide18,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide18, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide18);
	
	// Floor
	%pos = Vector::add(GameBase::getPosition(%player), "5 10 -15.725");
	GameBase::setRotation(%objDevice.objSide6,"0 0 0");
	GameBase::setPosition(%objDevice.objSide6,%pos);
	GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide6, %clientName @"'s Deployable Base");
	GameBase::startfadein(%objDevice.objSide6);
	
	// Inventory Station: Right Side
	%pos = Vector::add(GameBase::getPosition(%player), "-2.2 2 0.2");
	GameBase::setRotation(%objDevice.objSide8,"0 0 3.132");
	GameBase::setPosition(%objDevice.objSide8,%pos);
	GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide8, %clientName @"'s Base Inv # 1.");
	GameBase::startfadein(%objDevice.objSide8);
	
	// Inventory Station: Left Side
	%pos = Vector::add(GameBase::getPosition(%player), "11.999 2 0.2");
	GameBase::setRotation(%objDevice.objSide10,"0 0 -3.132");
	GameBase::setPosition(%objDevice.objSide10,%pos);
	GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide10, %clientName @"'s Base Inv # 2.");
	GameBase::startfadein(%objDevice.objSide10);
	
	// Generator
	%pos = Vector::add(GameBase::getPosition(%player), "0 6.8 -5109");
	GameBase::setRotation(%objDevice.objSide11, "0 0 0");
	GameBase::setPosition(%objDevice.objSide11, %pos);
	GameBase::setTeam(%objDevice.objSide11, GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide11, %clientName @"'s Deployable Base Gen");
	GameBase::startfadein(%objDevice.objSide11);
	
	// Turret: Left Side
	%pos = Vector::add(GameBase::getPosition(%player), "13.5 10 6.5");
	GameBase::setRotation(%objDevice.objSide12, "0 0 0");
	GameBase::setPosition(%objDevice.objSide12, %pos);
	GameBase::setTeam(%objDevice.objSide12,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide12, %clientName @"'s Deployable Base Turret # 1.");
	GameBase::startfadein(%objDevice.objSide12);
	
	// Turret: Right Side
	%pos = Vector::add(GameBase::getPosition(%player), "-3.5 10 6.5");
	GameBase::setRotation(%objDevice.objSide13,"0 0 0");
	GameBase::setPosition(%objDevice.objSide13,%pos);
	GameBase::setTeam(%objDevice.objSide13,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide13, %clientName @"'s Deployable Base Turret # 2.");
	GameBase::startfadein(%objDevice.objSide13);
	
	// Door: Left Side
	%pos = Vector::add(GameBase::getPosition(%player), "8.725 12 0");
	GameBase::setRotation(%objDevice.objSide19,"0 0 0");
	GameBase::setPosition(%objDevice.objSide19,%pos);
	GameBase::setTeam(%objDevice.objSide19,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide19, "Base Door");
	GameBase::startfadein(%objDevice.objSide19);
	
	// Command Station
	%pos = Vector::add(GameBase::getPosition(%player), "4.72 2 0.2");
	GameBase::setRotation(%objDevice.objSide21,"0 0 -3.132");
	GameBase::setPosition(%objDevice.objSide21,%pos);
	GameBase::setTeam(%objDevice.objSide21,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide21, %clientName @"'s Base CMD Station");
	GameBase::startfadein(%objDevice.objSide21);
	
	// Door: Right Side
	%pos = Vector::add(GameBase::getPosition(%player), "1.125 12 0");
	GameBase::setPosition(%objDevice.objSide22,%pos);
	GameBase::setRotation(%objDevice.objSide22,"0 0 0");
	GameBase::setTeam(%objDevice.objSide22,GameBase::getTeam(%player));
	GameBase::setMapName(%objDevice.objSide22, "Base Door");
	GameBase::startfadein(%objDevice.objSide22);
	
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%player) @"Deployablebase"]++;
	Echo("MSG: "@ %clientName @"("@ %client @") deployed a Base");
	Client::sendMessage(%client, 0, "Deployable Base deployed~wShell_Click.Wav");
	CenterPrint(%client, "<jc><f1>Deployable Base deployed.", 5);
	$DeployableBase::DeployerClient[%objDevice] = %client;
	return true;
}

function DeployableBase::CheckCount(%count)
{
	if(%count == 0)
	{
		Echo("0 count");
		Schedule("deleteObject("@ $BaseObj0 @");", 0, $BaseObj0);
		Schedule("deleteObject("@ $BaseObj1 @");", 0, $BaseObj1);
		Schedule("deleteObject("@ $BaseObj2 @");", 0, $BaseObj2);
		Schedule("deleteObject("@ $BaseObj3 @");", 0, $BaseObj3);
		Schedule("deleteObject("@ $BaseObj4 @");", 0, $BaseObj4);
		Schedule("deleteObject("@ $BaseObj5 @");", 0, $BaseObj5);
		Schedule("deleteObject("@ $BaseObj6 @");", 0, $BaseObj6);
		Schedule("deleteObject("@ $BaseObj7 @");", 0, $BaseObj7);
		Schedule("deleteObject("@ $BaseObj8 @");", 0, $BaseObj8);
		Schedule("deleteObject("@ $BaseObj9 @");", 0, $BaseObj9);
		Schedule("deleteObject("@ $BaseObj10 @");", 0, $BaseObj10);
		Schedule("deleteObject("@ $BaseObj11 @");", 0, $BaseObj11);
		Schedule("deleteObject("@ $BaseObj12 @");", 0, $BaseObj12);
		Schedule("deleteObject("@ $BaseObj13 @");", 0, $BaseObj13);
		Schedule("deleteObject("@ $BaseObj14 @");", 0, $BaseObj14);
		Schedule("deleteObject("@ $BaseObj15 @");", 0, $BaseObj15);
		Schedule("deleteObject("@ $BaseObj16 @");", 0, $BaseObj16);
		$TeamItemCount[GameBase::getTeam($BaseObj1) @"Deployablebase"]--;
	}
}