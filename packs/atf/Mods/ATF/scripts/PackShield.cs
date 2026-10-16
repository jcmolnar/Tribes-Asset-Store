//--------------------------------------

$InvList[ShieldPack] = 1;
$RemoteInvList[ShieldPack] = 1;

//--------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 1;
	maxEnergy = 2;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}

// These next scripts are altered Eradictaion Scripts....which as they say are altered from some other mod...so...i dunno who the rights of this goto...i got it from erad so i thank them....:)


$TeamItemMax[EnergyVortexPack] = 1;
$TeamItemMax[EnergyFieldGeneratorPack] = 2;
	
ItemImageData EnergyVortexPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.8, -1.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 5.0;
};

ItemData EnergyVortexPack
{
	description = "Energy Sucker";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = "uDeployables";
	imageType = EnergyVortexPackImage;
	shadowDetailMask = 16;
	mass = 5.0;
	elasticity = 0.2;
	price = 599;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyVortexPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function EnergyVortexPack::onDeploy(%player,%item,%pos)
{
	if (EnergyVortexPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function EnergyVortexPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	for(%team = 0; %team < getNumTeams(); %team++) { 
		if(%team != GameBase::getTeam(%player)) {
			%group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
			%count = Group::objectCount(%group);
			%spawnIdx = 0;
			while(%spawnIdx <= %count) {
				%spawnPoint = Group::getObject(%group, %spawnIdx);
				%separation = Vector::getDistance(GameBase::getPosition(%spawnPoint), $los::position);
				if(%separation <= 75) {
					Client::sendMessage(%client,0,"Too close to enemy spawn position");
					return false;
				}
				%spawnIdx++;
			}
		}
	}


	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","StaticShape",EnergyVortex,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Client::sendMessage(%client,0,"Energy Vortex deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "EnergyVortexPack"]++;
	echo("MSG: ",%client," deployed an Energy Sucker");
	return true;
}

StaticShapeData EnergyVortex
{
	description = "Evergy Sucker";
	shapeFile = "generator_p";
	debrisId = defaultDebrisSmall;
	maxDamage = 9.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Rod Antenna";
};

function EnergyVortex::onDestroyed(%this)
{
	EnergyVortex::onDisabled(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EnergyVortexPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
//  	if($Eradication::showDestructionMessages)
//		MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" energy vortex was destroyed.");

}


function EnergyVortex::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}


function EnergyVortex::onDisabled(%this)
{
	GameBase::setActive(%this,false);
}

function EnergyVortex::onActivate(%this)
{
	schedule("EnergyVortex::decEnergy("@ %this @");", 1.0, %this);
}

function EnergyVortex::onDeactivate(%this)
{
	GameBase::setActive(%this,false);
}

function EnergyVortex::decEnergy(%this)
{
	if (GameBase::isActive(%this)) {
		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$SimPlayerObjectType,getBoxCenter(%this),30,30,30,0);
		for (%count = 0; %count <= %num; %count++) {
			%target=Group::getObject(%set, %count);
			if(GameBase::getTeam(%this) != GameBase::getTeam(%target)) {
				if (GameBase::getEnergy(%target) >= 20)
					GameBase::setEnergy(%target, GameBase::getEnergy(%target) - 20);
				else
					GameBase::setEnergy(%target, 0);
				if (Player::getDamageFlash(%target) < 0.5 )
					Player::setDamageFlash(%target, Player::getDamageFlash(%target) + 0.3);
				else
					Player::setDamageFlash(%target, 0.8);
			}
		}
		deleteObject(%set);
		schedule("EnergyVortex::decEnergy("@ %this @");", 1.0, %this);
	}	
}


//----------------------------------------------
	
ItemImageData EnergyFieldGeneratorPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.8, -1.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 5.0;
};

ItemData EnergyFieldGeneratorPack
{
	description = "Energy Field Generator";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = "uDeployables";
	imageType = EnergyFieldGeneratorPackImage;
	shadowDetailMask = 16;
	mass = 5.0;
	elasticity = 0.2;
	price = 599;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyFieldGeneratorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function EnergyFieldGeneratorPack::onDeploy(%player,%item,%pos)
{
	if (EnergyFieldGeneratorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function EnergyFieldGeneratorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%shape = newObject("","StaticShape",EnergyFieldGenerator,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Energy Field Generator deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "EnergyFieldGeneratorPack"]++;
	echo("MSG: ",%client," deployed an Energy Field Generator");
	return true;
}

StaticShapeData EnergyFieldGenerator
{
   description = "Energy Field Generator";
   shapeFile = "generator_p";
	debrisId = flashDebrisSmall;
   sfxAmbient = SoundGeneratorPower;
   maxDamage = 6.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

function EnergyFieldGenerator::onDestroyed(%this)
{
	EnergyFieldGenerator::onDisabled(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EnergyFieldGeneratorPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
	//if($Eradication::showDestructionMessages)
	//  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" energy field generator was destroyed.");
}


function EnergyFieldGenerator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}


function EnergyFieldGenerator::onDisabled(%this)
{
	GameBase::setActive(%this,false);
}

function EnergyFieldGenerator::onActivate(%this)
{
	schedule("EnergyFieldGenerator::incEnergy("@ %this @");", 1.0, %this);
}

function EnergyFieldGenerator::onDeactivate(%this)
{
	GameBase::setActive(%this,false);
}

function EnergyFieldGenerator::incEnergy(%this)
{
	if (GameBase::isActive(%this)) {
		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$SimPlayerObjectType,getBoxCenter(%this),40,40,40,0);
		for (%count = 0; %count <= %num; %count++) {
			%target=Group::getObject(%set, %count);
			if(GameBase::getTeam(%this) == GameBase::getTeam(%target))
				GameBase::setEnergy(%target, GameBase::getEnergy(%target) + 5);
		}
		deleteObject(%set);
		schedule("EnergyFieldGenerator::incEnergy("@ %this @");", 1.0, %this);
	}	
}

//--------------------------------------

$InvList[EnergyVortexPack] = 1;
$RemoteInvList[EnergyVortexPack] = 1;

//--------------------------------------

//--------------------------------------

$InvList[EnergyFieldGeneratorPack] = 1;
$RemoteInvList[EnergyFieldGeneratorPack] = 1;

//--------------------------------------
