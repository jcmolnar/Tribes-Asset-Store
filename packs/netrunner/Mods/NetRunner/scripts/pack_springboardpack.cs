$InvList[SpringPack] = 1;
$RemoteInvList[SpringPack] = 1;

addDeployable(SpringPack, 3);

ItemImageData SpringPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SpringPack
{
	description = "Data Jump";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[iDefe];
	imageType = SpringPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpringPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function SpringPack::onDeploy(%player,%item,%pos)
{
	if (SpringPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function SpringPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"] >= $TeamItemMax[SpringPack])
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if (!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objSpringboard = newObject("Data Jump", "StaticShape", Springboard, true);
	addToSet("MissionCleanup", %objSpringboard);
	GameBase::setTeam(%objSpringboard, GameBase::getTeam(%player));
	GameBase::setPosition(%objSpringboard, $los::position);
	GameBase::setRotation(%objSpringboard, %rot);
	Gamebase::setMapName(%objSpringboard, "Data Jump");
	Client::sendMessage(%client,0,"Data Jump Deployed");
	GameBase::startFadeIn(%objSpringboard);
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
	echo("MSG: ",%client," deployed a Data Jump");
	return true;
}

StaticShapeData Springboard
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.00;
	isTranslucent = true;
	description = "Deployable Spring";
	visibleToSensor = true;
};

function Springboard::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "SpringPack"]--;
}

function Springboard::onCollision(%this,%obj)
{
	%c = Player::getClient(%obj);
	%vecVelocity = Item::getVelocity(%obj);
	%rnd = floor(getRandom() * 55);
	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%HMult = 2;
	%ZMax = 45;
	%vecNewVelocity = GetWord(%vecVelocity, 0) * %HMult @ " " @ GetWord(%vecVelocity, 1) * %HMult @ " " @ %ZMax;
	Item::setVelocity(%obj, %vecNewVelocity);
}