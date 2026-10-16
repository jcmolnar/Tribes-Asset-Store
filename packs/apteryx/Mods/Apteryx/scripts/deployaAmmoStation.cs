$InvList[DeployableAmmoPack] = 1;
$MobileInvList[DeployableAmmoPack] = 1;
$RemoteInvList[DeployableAmmoPack] = 0;
AddItem(DeployableAmmoPack);

$CanAlwaysTeamDestroy[DeployableAmmoStation] = 1;

function deployAmmoStation::Initialize()
{
	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
}
 
ItemImageData DeployableAmmoPackImage 
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack 
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = $InvHead[ihDOb];
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player,%item) 
{	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos) 
{	if(DeployableAmmoPack::deployShape(%player,%item) && !$build) 
		Player::decItemCount(%player,%item);
}

function DeployableAmmoPack::deployShape(%player,%item)
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
	
	
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform" && !$build)
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkInvDeployArea(%client,$los::position))
	{
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}
	%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	NukeList(%inv);
	%inv.cloakable = true;	//for base cloaker
	addToSet("MissionCleanup", %inv);
	%rot = GameBase::getRotation(%player);
	GameBase::setTeam(%inv,GameBase::getTeam(%player));
	GameBase::setPosition(%inv,$los::position);
	GameBase::setRotation(%inv,%rot);
	Gamebase::setMapName(%inv,%name);
	Client::sendMessage(%client,0,"Ammo Station deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
	echo("MSG: ",%client," deployed an Ammo Station");
	return true;
}

StaticShapeData DeployableAmmoStation
{
	description = "Remote Ammo Unit";
	shapeFile = "ammounit_remote";
	validateShape = true;
	validateMaterials = true;
	className = "DeployableStation";
	maxDamage = 1.0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundAmmoStationPower };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisSmall;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
};

function DeployableAmmoStation::onAdd(%this) 
{
	$StaticShape::count += 1;
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Ammo Station");
	%this.Energy = $RemoteAmmoEnergy;
}

function DeployableAmmoStation::onActivate(%this) 
{
	if(%this.deployed == 1) 
	{	
		GameBase::playSequence(%this,1,"use");
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
		%this.lastPlayer = Station::getTarget(%this);
		%player = %this.lastPlayer;
		%player.Station = %this;
		%this.target = Player::getClient(Station::getTarget(%this));
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
		if(%weapon != -1) 
		{
			%player.lastWeapon = %weapon;
			Player::unMountItem(%player,$WeaponSlot);
		}
	}
	else 
		GameBase::setActive(%this,false);
}
