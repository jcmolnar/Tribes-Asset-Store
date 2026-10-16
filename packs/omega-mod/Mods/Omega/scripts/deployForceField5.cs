$InvList[Forcefield5x5] = 1;
$RemoteInvList[Forcefield5x5] = 1;
$TeamItemMax[Forcefield5x5] = 60;
//----Armordata.cs - Then Item.cs 
$ItemMax[larmor, Forcefield5x5] = 0;
$ItemMax[lfemale, Forcefield5x5] = 0;
$ItemMax[marmor, Forcefield5x5] = 1;
$ItemMax[mfemale, Forcefield5x5] = 1;
$ItemMax[harmor, Forcefield5x5] = 0;

function deployFF5x5::Initialize()
{	
	$TeamItemCount[0 @ Forcefield5x5] = 0;
	$TeamItemCount[1 @ Forcefield5x5] = 0;
	$TeamItemCount[2 @ Forcefield5x5] = 0;
	$TeamItemCount[3 @ Forcefield5x5] = 0;
	$TeamItemCount[4 @ Forcefield5x5] = 0;
	$TeamItemCount[5 @ Forcefield5x5] = 0;
	$TeamItemCount[6 @ Forcefield5x5] = 0;
	$TeamItemCount[7 @ Forcefield5x5] = 0;
}

ItemImageData Forcefield5x5Image 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData Forcefield5x5 
{
	description = "Force Field [5x5]";
	shapeFile = "forcefield_5x5";
	className = "Backpack";
	heading = iBarrier;
	imageType = Forcefield5x5Image;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Forcefield5x5::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	Player::trigger(%player,$BackpackSlot,true);
	%clientId = Player::getclient(%player);
	bottomprint(%clientid, "<jc><f1>Deploys a forcefield that may cloak automatically");
}

function Forcefield5x5::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function Forcefield5x5::onDeploy(%player,%item,%pos) 
{
	if(Forcefield5x5::deployShape(%player,%item) && !$build) 
		Player::decItemCount(%player,%item);
}

function Forcefield5x5::deployShape(%player,%item) 
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]  && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}

	%obj = $los::object;
	//echo (GameBase::getTeam(%obj));
	if((GameBase::getTeam(%obj) != GameBase::getTeam(%player)) && (getObjectType(%obj) != "SimTerrain") && (GameBase::getTeam(%obj) != -1)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy on enemy base");
		return false;
	}

	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(!checkDeployArea(%client,$los::position)) 
		return false;

	%rot = GameBase::getRotation(%player);
	%objFF5x5 = newObject("","StaticShape",FF5x5,true);
	NukeList(%objFF5x5);
	addToSet("MissionCleanup", %objFF5x5);
	GameBase::setTeam(%objFF5x5,GameBase::getTeam(%player));
	GameBase::setPosition(%objFF5x5,$los::position);
	GameBase::setRotation(%objFF5x5,%rot);
	Gamebase::setMapName(%obj,"Force Field [5x5]");
	Client::sendMessage(%client,0,"Deployed a Force Field [5x5]");
	GameBase::startFadeIn(%objFF5x5);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "Forcefield5x5"]++;
	echo("MSG: ",%client," deployed a Force Field [5x5]");
	return true;
}

StaticShapeData FF5x5
{
	shapeFile = "forcefield_5x5";
	maxDamage = 20.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "Force Field [5x5]";
};

function FF5x5::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Forcefield5x5"]--;
}


function FF5x5::onCollision(%this,%object)
{
	if($debug) 
	  echo("debug- blastwall::oncollision "@GameBase::getDataName(%this)@", "@GameBase::getDataName(%object));
	if(getObjectType(%object) == "Flier") 
	{ 
		%data = GameBase::getDataName(%object);
		if($debug)	echo(%data@" hitting "@GameBase::getDataName(%this));
		%damage = GameBase::getDamageLevel(%object) + 0.01;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}

}
