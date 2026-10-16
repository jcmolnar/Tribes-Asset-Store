StaticShapeData HugeWallShape
{
	shapeFile = "newdoor5";
	debrisId = defaultDebrisLarge;
	maxDamage = 20000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Huge Wall";
};

function HugeWallShape::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
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
function HugeWallShape::onDestroyed(%this){}

ItemImageData hugewallImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 0.1;
};

ItemData hugewall
{
	description = "Huge Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = $InvHeading[Walls];
	imageType = hugewallImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function hugewall::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }
	else{ Player::deployItem(%player, %item); }
}

function hugewall::onDeploy(%player,%item,%pos)
{ if(hugewall::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function hugewall::deployshape(%player, %item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	%playerTeam = GameBase::getTeam(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ "hugewall"] >= $TeamItemMax[hugewall])
	{ Client::sendMessage(%client, 0, "Can Not Deploy, You've passed your limit "); return false; }
	
	%distance = Vector::getDistance(%flagpos, %playerpos);
	if(%distance <= 5)
	{ Client::sendMessage(%client, 0, "You are too close to your flag, Must be further from flag to deploy."); return false; }
	
	%obj = getObjectType($los::object);
	%set = newObject("hugewall",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 150, 150, 150, 0);
	
	for(%i; %i < %num; %i++)
	{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
			%inbase = true;
			break;
		}
	}
	deleteObject(%set);
	
	if(!%inbase)
	{ Client::sendMessage(%client, 0, "Too far away from your base.~wAccess_Denied.wav"); return false; }
	
	
	%objDevice =   newObject("hugewall", "Staticshape", HugeWallShape, true);
	%objDevice.objSide1 = newObject("hugewall1", "Staticshape", HugeWallShape, true);
	%objDevice.objSide2 = newObject("hugewall2", "Staticshape", HugeWallShape, true);
	%objDevice.objSide3 = newObject("hugewall3", "Staticshape", HugeWallShape, true);
	%objDevice.objSide4 = newObject("hugewall4", "Staticshape", HugeWallShape, true);
	%objDevice.objSide5 = newObject("hugewall5", "Staticshape", HugeWallShape, true);
	%objDevice.objSide6 = newObject("hugewall6", "StaticShape", HugeWallShape, true);
	%objDevice.objSide7 = newObject("hugewall7", "StaticShape", HugeWallShape, true);
	%objDevice.objSide8 = newObject("hugewall8", "StaticShape", HugeWallShape, true);
	%objDevice.objSide9 = newObject("hugewall9", "StaticShape", HugeWallShape, true);
	%objDevice.objSide10 = newObject("hugewall10", "StaticShape", HugeWallShape, true);
	%objDevice.objSide11 = newObject("hugewall11", "StaticShape", HugeWallShape, true);
	%objDevice.objSide12 = newObject("hugewall12", "StaticShape", HugeWallShape, true);

	%objDevice.objSide1.objParent = %objDevice;
	%objDevice.objSide2.objParent = %objDevice;
	%objDevice.objSide3.objParent = %objDevice;
	%objDevice.objSide4.objParent = %objDevice;
	%objDevice.objSide5.objParent = %objDevice;
	%objDevice.objSide6.objParent = %objDevice;
	%objDevice.objSide7.objParent = %objDevice;
	%objDevice.objSide8.objParent = %objDevice;
	%objDevice.objSide9.objParent = %objDevice;
	%objDevice.objSide10.objParent = %objDevice;
	%objDevice.objSide11.objParent = %objDevice;
	%objDevice.objSide12.objParent = %objDevice;

	
	addToSet(MissionCleanup, %objDevice);
	addToSet(MissionCleanup, %objDevice.objSide1);
	addToSet(MissionCleanup, %objDevice.objSide2);
	addToSet(MissionCleanup, %objDevice.objSide3);
	addToSet(MissionCleanup, %objDevice.objSide4);
	addToSet(MissionCleanup, %objDevice.objSide5);
	addToSet(MissionCleanup, %objDevice.objSide6);
	addToSet(MissionCleanup, %objDevice.objSide7);
	addToSet(MissionCleanup, %objDevice.objSide8);
	addToSet(MissionCleanup, %objDevice.objSide9);
	addToSet(MissionCleanup, %objDevice.objSide10);
	addToSet(MissionCleanup, %objDevice.objSide11);
	addToSet(MissionCleanup, %objDevice.objSide12);

	%rot = gamebase::getrotation(%player);
    %playerpos = GameBase::getPosition(%player);
    
    %pos = Vector::add(%playerpos, EmplacementPack::rotVector( "14.9 2.5 0", %rot));
	GameBase::setRotation(%objDevice,%rot);
	GameBase::setPosition(%objDevice,%pos);
	GameBase::setTeam(%objDevice, %playerTeam);
	Gamebase::setMapName(%objDevice,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-14.7 2.5 7.9",%rot));
	GameBase::setRotation(%objDevice.objSide1,%rot);
	GameBase::setPosition(%objDevice.objSide1,%pos);
	GameBase::setTeam(%objDevice.objSide1, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide1,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide1);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-14.7 2.5 15.8", %rot));
	GameBase::setRotation(%objDevice.objSide2,%rot);
	GameBase::setPosition(%objDevice.objSide2,%pos);
	GameBase::setTeam(%objDevice.objSide2, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide2,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide2);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "14.9 2.5 15.8", %rot));
	GameBase::setRotation(%objDevice.objSide3,%rot);
	GameBase::setPosition(%objDevice.objSide3,%pos);
	GameBase::setTeam(%objDevice.objSide3, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide3,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide3);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "14.9 2.5 7.9", %rot));
	GameBase::setRotation(%objDevice.objSide4,%rot);
	GameBase::setPosition(%objDevice.objSide4,%pos);
	GameBase::setTeam(%objDevice.objSide4, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide4,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide4);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "5 2.5 0", %rot));
	GameBase::setRotation(%objDevice.objSide6,%rot);
	GameBase::setPosition(%objDevice.objSide6,%pos);
	GameBase::setTeam(%objDevice.objSide6, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide6,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide6);

	
	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.9 2.5 0", %rot));
	GameBase::setRotation(%objDevice.objSide7,%rot);
	GameBase::setPosition(%objDevice.objSide7,%pos);
	GameBase::setTeam(%objDevice.objSide7, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide7,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide7);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.9 2.5 15.8", %rot));
	GameBase::setRotation(%objDevice.objSide8,%rot);
	GameBase::setPosition(%objDevice.objSide8,%pos);
	GameBase::setTeam(%objDevice.objSide8, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide8,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide8);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.9 2.5 7.9", %rot));
	GameBase::setRotation(%objDevice.objSide9,%rot);
	GameBase::setPosition(%objDevice.objSide9,%pos);
	GameBase::setTeam(%objDevice.objSide9, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide9, "Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide9);

	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "5 2.5 15.8", %rot));
	GameBase::setRotation(%objDevice.objSide10,%rot);
	GameBase::setPosition(%objDevice.objSide10,%pos);
	GameBase::setTeam(%objDevice.objSide10, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide10,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide10);
	
	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-14.7 2.5 0", %rot));
	GameBase::setRotation(%objDevice.objSide11,%rot);
	GameBase::setPosition(%objDevice.objSide11,%pos);
	GameBase::setTeam(%objDevice.objSide11, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide11,"Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide11);
	
	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "5 2.5 7.9", %rot));
	GameBase::setPosition(%objDevice.objSide12, %pos);
	GameBase::setRotation(%objDevice.objSide12, %rot);
	GameBase::setTeam(%objDevice.objSide12, %playerTeam);
	Gamebase::setMapName(%objDevice.objSide12, "Huge Wall Built By "@  Client::getName(%client));
	GameBase::startFadeIn(%objDevice.objSide12);

	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[%playerTeam @"hugewall"]++;
	Client::sendMessage(%client, 0, "Huge Wall deployed");
	return true;
}