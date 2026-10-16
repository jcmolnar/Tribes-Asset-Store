//---Armordata.cs Stuff
$ItemMax[larmor, LargeForceFieldPack] = 0;
$ItemMax[lfemale, LargeForceFieldPack] = 0;
$ItemMax[marmor, LargeForceFieldPack] = 1;
$ItemMax[mfemale, LargeForceFieldPack] = 1;
$ItemMax[harmor, LargeForceFieldPack] = 0;
//----Things that make it work :) 
$InvList[LargeForceFieldPack] = 1;
$RemoteInvList[LargeForceFieldPack] = 1;

$TeamItemMax[LargeForceFieldPack] = 60;

function deployLargeForceField::Initialize()
{	
	$TeamItemCount[0 @ LargeForceFieldPack] = 0;
	$TeamItemCount[1 @ LargeForceFieldPack] = 0;
	$TeamItemCount[2 @ LargeForceFieldPack] = 0;
	$TeamItemCount[3 @ LargeForceFieldPack] = 0;
	$TeamItemCount[4 @ LargeForceFieldPack] = 0;
	$TeamItemCount[5 @ LargeForceFieldPack] = 0;
	$TeamItemCount[6 @ LargeForceFieldPack] = 0;
	$TeamItemCount[7 @ LargeForceFieldPack] = 0;
}

ItemImageData LargeForceFieldPackImage 
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack 
{	
	description = "Large Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = iBarrier;
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
} 

function LargeForceFieldPack::onDeploy(%player,%item,%pos) 
{	
	if(LargeForceFieldPack::deployShape(%player,%item)&& !$build) 
		Player::decItemCount(%player,%item);
}

function LargeForceFieldPack::deployShape(%player,%item) 
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%objForceField = newObject("","StaticShape",LargeForceField,true);
	NukeList(%objForceField);
	addToSet("MissionCleanup", %objForceField);
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player));
	GameBase::setPosition(%objForceField,$los::position);
	GameBase::setRotation(%objForceField,%rot);
	Gamebase::setMapName(%objForceField,"Force Field");
	Client::sendMessage(%client,0,"Force Field Deployed");
	GameBase::startFadeIn(%objForceField);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
	echo("MSG: ",%client," deployed a Large Force Field");
	return true;
}

StaticShapeData LargeForceField 
{ 
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 5.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Force Field";
};

function LargeForceField::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;
}
function LargeForceField::onCollision(%this,%object)
{
	
	if(getObjectType(%object) == "Flier") 
	{ 
		%data = GameBase::getDataName(%object);
		if($debug)	echo(%data@" hitting "@GameBase::getDataName(%this));
		%damage = GameBase::getDamageLevel(%object) + 0.01;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}

}