$InvList[ForceFieldPack] = 1;
$MobileInvList[ForceFieldPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
AddItem(ForceFieldPack);

$CanAlwaysTeamDestroy[ForceField] = 1;

function deployForceField::Initialize()
{	
	$TeamItemCount[0 @ ForceFieldPack] = 0;
	$TeamItemCount[1 @ ForceFieldPack] = 0;
	$TeamItemCount[2 @ ForceFieldPack] = 0;
	$TeamItemCount[3 @ ForceFieldPack] = 0;
	$TeamItemCount[4 @ ForceFieldPack] = 0;
	$TeamItemCount[5 @ ForceFieldPack] = 0;
	$TeamItemCount[6 @ ForceFieldPack] = 0;
	$TeamItemCount[7 @ ForceFieldPack] = 0;
}

ItemImageData ForceFieldPackImage 
{ 
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack 
{ 
	description = "Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function ForceFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if(ForceFieldPack::deployShape(%player,%item)&& !$build) 
		Player::decItemCount(%player,%item);
}

function ForceFieldPack::deployShape(%player,%item) 
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

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	
	%rot = GameBase::getRotation(%player);
	%objForceField = newObject("","StaticShape",DeployableForceField,true);
	NukeList(%objForceField);
	addToSet("MissionCleanup", %objForceField);
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player));
	GameBase::setPosition(%objForceField,$los::position);
	GameBase::setRotation(%objForceField,%rot);
	Gamebase::setMapName(%objForceField,"Force Field "@Client::getName(%client));
	Client::sendMessage(%client,0,"Force Field Deployed");
	GameBase::startFadeIn(%objForceField);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
	echo("MSG: ",%client," deployed a Force Field");
	return true;
}

StaticShapeData DeployableForceField 
{ 
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
maxDamage = 250;
maxEnergy = 200;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Force Field";
};

function DeployableForceField::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
}
function DeployableForceField::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);
		
	if(getObjectType(%object) == "Flier") 
	{ 
		%data = GameBase::getDataName(%object);
		if($debug)
			echo(%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.01;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}

}