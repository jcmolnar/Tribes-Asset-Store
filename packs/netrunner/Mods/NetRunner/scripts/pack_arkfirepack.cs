$InvList[ArkFieldPack] = 1;
$RemoteInvList[ArkFieldPack] = 1;

addDeployable(ArkFieldPack, 10);

ItemImageData ArkFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ArkFieldPack
{
	description = "Arkfire Defense Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[iDefe];
	imageType = ArkFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ArkFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function ArkFieldPack::onDeploy(%player,%item,%pos)
{
	ArkFieldPack::deployShape(%player, 0, 20);
	if(%player.arkfire == "") %player.arkfire = 0;
	%player.arkfire++;
	if(%player.arkfire > 2)
	{
		Player::decItemCount(%player, %item);
		%player.arkfire = "";
	}
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Arkfire Enabled");
	echo("MSG: ",%client," deployed an ArkFire Field");
}

function ArkFieldPack::deployShape(%player, %damage, %time, %damager)
{
	%damageclient = Player::getClient(%damager);
	%client = Player::getClient(%player);
	%position = GameBase::getPosition(%player);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "-2.4 0 0");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"0 0 1.57");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "2.4 0 0");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"0 0 1.57");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	Client::setOwnedObject(%client, %objArkField); 
	Client::setOwnedObject(%client, %player);
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "0 -2.4 0");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"0 0 0");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	Client::setOwnedObject(%client, %objArkField); 
	Client::setOwnedObject(%client, %player);
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "0 2.4 0");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"0 0 0");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	Client::setOwnedObject(%client, %objArkField); 
	Client::setOwnedObject(%client, %player);
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "0 2.4 4.8");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"1.57 0 0");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	Client::setOwnedObject(%client, %objArkField); 
	Client::setOwnedObject(%client, %player);
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	if(%damage) %objArkField = newObject("ArkField","StaticShape",ArkDamageField,true);
	else %objArkField = newObject("ArkField","StaticShape",ArkField,true);
	%pos = Vector::add(%position, "0 2.4 0");
	GameBase::setTeam(%objArkField,GameBase::getTeam(%player));
	GameBase::setPosition(%objArkField,%pos);
	GameBase::setRotation(%objArkField,"1.57 0 0");
	Gamebase::setMapName(%objArkField,"Arkfire Locker");
	Client::setOwnedObject(%client, %objArkField); 
	Client::setOwnedObject(%client, %player);
	%objArkField.client = %damageclient;
	GameBase::startFadeIn(%objArkField);
	addToSet("MissionCleanup", %objArkField);
	schedule("GameBase::setDamageLevel(" @ %objArkField @ ", 10.00);", %time, %objArkField);

	playSound(SoundPickupBackpack,%position);
	playSound(ArkFieldOpen,%position);
	return true;
}

StaticShapeData ArkField
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Ark Field";
};

function ArkField::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
}

StaticShapeData ArkDamageField
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Ark Field";
	explosionId = flashExpLarge;
};

function ArkDamageField::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $ArkDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100); 
}