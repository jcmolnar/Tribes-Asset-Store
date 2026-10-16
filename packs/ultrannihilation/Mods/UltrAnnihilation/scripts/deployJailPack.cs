$InvList[JailPack] = 1;
$MobileInvList[JailPack] = 1;
$RemoteInvList[JailPack] = 0;

function deployJailPack::Initialize()
{	
	$TeamItemCount[0 @ jailPack] = 0;
	$TeamItemCount[1 @ jailPack] = 0;
	$TeamItemCount[2 @ jailPack] = 0;
	$TeamItemCount[3 @ jailPack] = 0;
	$TeamItemCount[4 @ jailPack] = 0;
	$TeamItemCount[5 @ jailPack] = 0;
	$TeamItemCount[6 @ jailPack] = 0;
	$TeamItemCount[7 @ jailPack] = 0;
}

ItemImageData JailPackImage
{	
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JailPack
{	
	description = "Jail Cell";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHead[ihDob];
	imageType = jailPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData JailDoor
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "ForceField";
	maxDamage = 50;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Jail Cell Door";
};

StaticShapeData JailSide
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50;
	visibleToSensor = true;
	isTranslucent = true;
	//description = "Jail Cell";
};

StaticShapeData JailStand
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	description = "Jail Stand";
};

StaticShapeData JailReleasePad
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	description = "Jail Release Pad";
};

StaticShapeData JailSwitchOpen
{
	description = "The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 50;
};

StaticShapeData JailSwitchClose
{
	description = " The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 50;
};

function JailPack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JailPack::onDeploy(%player,%item,%pos)
{	if(jailPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateJailSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/JailCell" @ %team);
	if(%teleset == -1)
	{	newObject("JailCell" @ %team,SimSet);
		addToSet("MissionCleanup","JailCell" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailPorts" @ %team);
	if(%teleset == -1)
	{
		newObject("Jailports" @ %team,SimSet);
		addToSet("MissionCleanup","JailPorts" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailRelease" @ %team);
	if(%teleset == -1)
	{
		newObject("JailRelease" @ %team,SimSet);
		addToSet("MissionCleanup","JailRelease" @ %team);
	}
}

function JailPack::deployshape(%player,%item)
{
	%name = "Jail Cell";
	%team = GameBase::getTeam(%player);
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
		return false;
	}
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);

	if(Vector::getDistance(%flagpos, %playerpos) < 100)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}

	CreateJailSimSet(%team);

	%obj = newObject("Jail Back Wall","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .6 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 4.71339");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 4.71339");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail Roof","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);
	
	%obj = newObject("Jail Roof","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSwitchOpen,true);
	%pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSwitchClose,true);
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	// Door
	%obj = newObject("Jail Door","StaticShape",JailDoor,true);
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,"0 0 0");

	// Teleport System
	%obj = newObject("Teleport Pad","StaticShape","JailStand",true);
	addToSet("MissionCleanup/JailPorts" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"Entry Pad");

	%obj = newObject("","StaticShape",ElectricalBeamBig,true);
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("Jail Release Pad","StaticShape","JailReleasePad",true);
	addToSet("MissionCleanup/JailRelease" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"Release Pad");

	$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " summoned 250' Up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
}

function JailSide::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	
	%set1 = nameToID("MissionCleanup/JailCell" @ %team);
	%set2 = nameToID("MissionCleanup/JailPorts" @ %team);
	%set3 = nameToID("MissionCleanup/JailRelease" @ %team);
	
	if(%set1 != -1 && %set2 != -1 && %set3 != -1)
	{
		if(%this == Group::getObject(%set1,0)) 
		{	
			%objs = group::objectcount(%set1);
			for(%x=0; %x<%objs; %x++) 
			{	
				%obj = Group::getObject(%set1,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set1);
			%objs=group::objectcount(%set2);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set2,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set2);
			%objs=group::objectcount(%set3);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set3,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set3);
		} 
		else 
		{	
			GameBase::setDamageLevel(Group::getObject(%set1,0),100);
		}
	}
	$TeamItemCount[GameBase::getTeam(%this) @ "JailPack"]=0;
}

function JailSwitchOpen::onCollision(%this,%obj)
{
}

function JailSwitchClose::onCollision(%this,%obj)
{
}

function JailDoor::onDestroyed(%this)
{
	JailSide::onDestroyed(%this);
}

function JailDoor::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
		return;

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
		return;

	JailDoor::openSesame(%this);
	return;
}

function JailDoor::openSesame(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("JailDoor::closeSesame("@%this@");",2);
}

function JailDoor::closeSesame(%this) 
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function JailBreak(%this, %team)
{
	%clientId = Player::getClient(%this);
	%teleset = nameToID("MissionCleanup/JailRelease" @ %team);
	for(%i = 0; (%obj = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(%team != GameBase::getTeam(%this))
		{
			%this.jaildamage=false;
			GameBase::SetPosition(%this,GameBase::GetPosition(%obj));
			Client::SendMessage(%clientId, 0, "You Have Been Released. Run Forrest Run!!!!");
		}
	}
}