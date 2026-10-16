$InvList[JumpPadPack] = 1;
$MobileInvList[JumpPadPack] = 1;
$RemoteInvList[JumpPadPack] = 1;
AddItem(JumpPadPack);

$CanAlwaysTeamDestroy[JumpPad] = 1;

function deployJumpPad::Initialize()
{	
	$TeamItemCount[0 @ JumpPadPack] = 0;
	$TeamItemCount[1 @ JumpPadPack] = 0;
	$TeamItemCount[2 @ JumpPadPack] = 0;
	$TeamItemCount[3 @ JumpPadPack] = 0;
	$TeamItemCount[4 @ JumpPadPack] = 0;
	$TeamItemCount[5 @ JumpPadPack] = 0;
	$TeamItemCount[6 @ JumpPadPack] = 0;
	$TeamItemCount[7 @ JumpPadPack] = 0;
}

ItemImageData JumpPadPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData JumpPadPack
{
	description = "FireWall";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = JumpPadPackImage;
	shadowDetailMask = 4;
	mass = 1.2;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JumpPadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JumpPadPack::onDeploy(%player,%item,%pos)
{
	if (JumpPadPack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}

function JumpPadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);

	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 -1") > 0.6)
	{
		Client::sendMessage(%client,0,"Canot deploy on ceiling.");
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%xrot = getword(%rot, 0);
	%xrot = %xrot + 0.06254;
	%yrot = getword(%rot, 1);
	%zrot = getword(%rot, 2);
	%zrot = %zrot + 1.57079;
	%rot = %xrot@" "@%yrot@" "@%zrot;
	%backward = Vector::neg(Vector::getFromRot(%rot, 1.6));
	%xrot = %xrot - 0.12508;
	%rot = %xrot@" "@%yrot@" "@%zrot;	
	%forward = Vector::getFromRot(%rot, 1.6);
		
	%obj = newObject("JumpPad","StaticShape",JumpPad,true);
	NukeList(%obj);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,%team);
	%pos = Vector::add($los::position,"0 0 -0.1");
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"FireWall");
	Client::sendMessage(%client,0,%item.description @ " deployed");
	echo("MSG: ",%client," deployed a FireWall");
	$TeamItemCount[GameBase::getTeam(%obj) @ "JumpPadPack"]++;
	GameBase::startFadeIn(%obj);
	playSound(SoundPickupBackpack,$los::position);

	%obj = newObject("JumpPad","StaticShape",JumpPad,true);
	NukeList(%obj);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,%team);
	%pos = Vector::add($los::position,%forward);
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"FireWall");
	$TeamItemCount[GameBase::getTeam(%obj) @ "JumpPadPack"]++;
	GameBase::startFadeIn(%obj);

	%obj = newObject("JumpPad","StaticShape",JumpPad,true);
	NukeList(%obj);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,%team);
	%pos = Vector::add($los::position,%backward);
	GameBase::setPosition(%obj,%pos);
	$TeamItemCount[GameBase::getTeam(%obj) @ "JumpPadPack"]++;
	GameBase::startFadeIn(%obj);
	playSound(SoundPickupBackpack,$los::position);

	return true;
}

StaticShapeData JumpPad 
{
	shapeFile = "sensor_small";
	maxDamage = 4.00;
	debrisId = defaultDebrisMedium;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "Fire Wall";
};

function JumpPadPack::Destruct(%this)
{
	JumpPadPack::doDamage(%this);
}

function JumpPadPack::doDamage(%this) 
{
}

function JumpPad::onDestroyed(%this)
{
	JumpPadPack::doDamage(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "JumpPadPack"]--;
}

function JumpPad::onCollision(%this,%obj)
{	
	if($debug) 
		event::collision(%this,%obj);

	if(getObjectType(%obj) != "Player")
		return;
	if(Player::isDead(%obj))
		return;
	if(%this.cloaked > 0 && getObjectType(%obj) == "Player")
	{
		//pop this visible for a second -plasmatic
		%this.cloaked = "";
		GameBase::startFadein(%this);
	}	
	%clientId = Player::getClient(%obj);
	%pteam = GameBase::getTeam(%obj);
	%oteam = GameBase::getTeam(%this);
	if(%pteam != %oteam)
	{
		%this.FiringFlames = 5;
		FlameSpout(%this);
	}
}

function FlameSpout(%shooter)
{
	%pos = gamebase::getposition(%shooter);
	%xpos = getword(%pos, 0);
	%ypos = getword(%pos, 1);
	%zpos = getword(%pos, 2);
	%zpos = %zpos + 3;
	%pos = %xpos @ " " @ %ypos @ " " @ %zpos;

	%obj = newObject("","Mine","PlasmaGeyser");
	Gamebase::setposition(%obj, %pos);
	gamebase::setteam(%obj, gamebase::getteam(%shooter));

	%this.FiringFlames--;
	if(%this.FiringFlames > 0)
		schedule("FlameSpout("@%shooter@");", 0.2);
}