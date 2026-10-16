$InvList[TransportPack] = 1;
$MobileInvList[TransportPack] = 1;
$RemoteInvList[TransportPack] = 1;
AddItem(TransportPack);

function deployTransport::Initialize()
{
	$TeamItemCount[0 @ TransportPack] = 0; 
	$TeamItemCount[1 @ TransportPack] = 0; 
	$TeamItemCount[2 @ TransportPack] = 0;
	$TeamItemCount[3 @ TransportPack] = 0;
	$TeamItemCount[4 @ TransportPack] = 0;
	$TeamItemCount[5 @ TransportPack] = 0;
	$TeamItemCount[6 @ TransportPack] = 0;
	$TeamItemCount[7 @ TransportPack] = 0;
}

ItemImageData TransportPackImage 
{
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TransportPack 
{
	description = "Hell Fire Transport Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = TransportPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 1600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function TransportPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else
		Player::deployItem(%player,%item); 
}

function TransportPack::onDeploy(%player,%item,%pos) 
{
	if(TransportPack::deployShape(%player,%item)&& !$build) 
		Player::decItemCount(%player,%item);
}


function TransportPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] >= $TeamItemMax[HAPCVehicle] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object); 
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!Vehicle::DeployArea(%player,"HAPC",$los::position)) 
		return false;
	

	%rot = GameBase::getRotation(%player); 
	%objVehicle = newObject("",flier,HAPC,true); 
	NukeList(%objVehicle);
	addToSet("MissionCleanup", %objVehicle); 
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Gamebase::setMapName(%objVehicle,"HPC Pack"); 
	Client::sendMessage(%client,0,"Deployed HPC"); 
	GameBase::startFadeIn(%objVehicle); 
	Vehicle::TerrainCheck(%objVehicle);
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++; 
	echo("MSG: ",%client," deployed a Transport Vehicle Pack");
	return true; 
}
