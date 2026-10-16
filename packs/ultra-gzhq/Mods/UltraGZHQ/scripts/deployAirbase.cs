

$InvList[AirBasePack] = 1;
$MobileInvList[AirBasePack] = 1;
$RemoteInvList[AirBasePack] = 0;
AddItem(AirBasePack);

function deployAirBase::Initialize()
{	
	$TeamItemCount[0 @ AirBasePack] = 0;
	$TeamItemCount[1 @ AirBasePack] = 0;
	$TeamItemCount[2 @ AirBasePack] = 0;
	$TeamItemCount[3 @ AirBasePack] = 0;
	$TeamItemCount[4 @ AirBasePack] = 0;
	$TeamItemCount[5 @ AirBasePack] = 0;
	$TeamItemCount[6 @ AirBasePack] = 0;
	$TeamItemCount[7 @ AirBasePack] = 0;
}

ItemImageData AirBasePackImage
{	
	shapeFile = "vehi_pur_pnl";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AirBasePack
{	
	description = "Air Base";
	shapeFile = "vehi_pur_pnl";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = AirBasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData AirBaseForceFieldLarge
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};

StaticShapeData AirBaseForceFieldSmall
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};

function AirBasePack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AirBasePack::onDeploy(%player,%item,%pos)
{	if(AirBasePack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateAirBaseSimSet(%team)
{
	%Baseset = nameToID("MissionCleanup/AirBase" @ %team);
	if(%Baseset == -1)
	{
		%group = newObject("AirBase" @ %team,SimGroup);
		addToSet("MissionCleanup",%group);
	}	
}

function AirBasePack::deployshape(%player,%item)
{
	%name = "Air Base";
	%team = GameBase::getTeam(%player);

	%client = Player::getClient(%player);

	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy, Air Base Already In Place");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%flag = $teamFlag[%team];
	%flagpos = gamebase::getPosition(%flag);

	if(getWord(%playerpos,2) < -150)
	{
		Client::sendMessage(%client,0,"Position unstable, too close to center of planet.");
		return false;
	}
	
	if(Vector::getDistance(%flagpos, %playerpos) < 50)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return false;
	}
		
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	
	CreateAirBaseSimSet(%team);
	
	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 150;
	%playerpos = %posX@" "@%posY@" "@%posZ;
	%pRot = vector::add(GameBase::getRotation(%player),"0 0 0.785");
	
	// Tower Floor
	%object = newObject("Air Base","InteriorShape", "BEMfloatingPad.dis");
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%rot = "0 0 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	%pos = rotateVector("-5 -5 0",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	GameBase::setPosition(%object,%pos);
	Gamebase::setMapName(%object,%name);

	// Tower Roof
	%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("0 0 38",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 3.14159 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));	
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("5.8746 0 14.5",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small1","StaticShape",AirBaseForceFieldSmall,false);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("-5.75 2.05 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("0 5.8746 14.5",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small2","StaticShape",AirBaseForceFieldSmall,false);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("2.03 -5.75 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	%object = newObject("Vehicle Station","StaticShape",VehicleStation,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("-3.60177 3.95522 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 0.7853981";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Vehicle Station");
	
	%object = newObject("Vehicle Pad","StaticShape",VehiclePad,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("-10.6862 -11.1697 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 -0 2.3561944";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Vehicle Pad");
	
	%object = newObject("Inventory Station","StaticShape",InventoryStation,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("3.69689 -3.64708 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 -2.3561944";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Inventory Station");
	
	%object = newObject("Command Station","StaticShape",CommandStation,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("4.25588 4.13451 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 -0.7853981";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Command Station");
	
	
	%object = newObject(MedPulse, Sensor, MediumPulseSensor,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("0 0 20.55",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Pulse Sensor");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("-7.49755 1.43987 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -1.5707963";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Solar Panel");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	NukeList(%object);
	addToSet("MissionCleanup/AirBase"@%team, %object);
	%pos = rotateVector("1.58014 -7.45512 16",%prot);
	%pos = Vector::add(%playerpos,%pos);	
	%rot = "0 0 0";
	GameBase::setRotation(%object,vector::add(%pRot,%rot));
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Air Base Solar Panel");

	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed an Air Base");
	Client::sendMessage(%client,0,%item.description @ " summoned 150 meters up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
}
