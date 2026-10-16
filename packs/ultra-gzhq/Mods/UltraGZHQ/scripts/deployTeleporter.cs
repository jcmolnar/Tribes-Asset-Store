$InvList[TeleportPack] = 1;
$MobileInvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 0;
AddItem(TeleportPack);

$CanAlwaysTeamDestroy[DeployableTeleport] = 1;

function deployTeleporter::Initialize()
{
	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;
}

ItemImageData TeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "enerpad";	//flagstand";
	className = "Backpack";
	heading = $InvHead[ihDOb];
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NeedTeleportSimSet()
{
	%teleset = nameToID("MissionCleanup/Teleports");
	if(%teleset == -1)
	{
		newObject(Teleports, SimSet);
		addToSet(MissionCleanup, Teleports);
	}
}

function TeleportPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if(teleportPack::deployShape(%player, "Teleport Pad", DeployableTeleport, %item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
	}
}

// reworked this function to tele on beam contact, and set into floor a little 
function TeleportPack::deployShape(%player, %name, %shape, %item)
{
	%client = Player::getClient(%player);
	 // Verify item limit
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] >= $TeamItemMax[DeployableTeleport]) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
		return false;
	}
	// Verify proximity to player
	// GetLOSInfo sets the following globals:
	// 	los::position
	// 	los::normal
	// 	los::object
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	// Verify type of deploy location
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	// Verify slope of deploy location
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	// Make sure nothing is in the way of the deploy
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		return false;
	}
	//
	// Passed validation, create the object
	//
	NeedTeleportSimSet();
	// Set the starting posistion a bit off the ground (for whatever reason) 
	//-dropped a bit for new shape
	%pos = Vector::add($los::position,"0 0 -0.286");	//Vector::add($los::position,"0 0 1");
	
	// Create teleporter pad
	%objTeleport = newObject("Teleport Pad", "StaticShape", %shape, true);
	NukeList(%objteleport);
	GameBase::setPosition(%objTeleport,%pos);
	%prot =GameBase::getRotation(%player);
	GameBase::setRotation(%objTeleport,Vector::add(%prot,"0 0 -1.57"));
	GameBase::setTeam(%objTeleport,GameBase::getTeam(%player));
	Gamebase::setMapName(%objTeleport,%name);
	addToSet("MissionCleanup/Teleports", %objTeleport);
	addToSet("MissionCleanup", %objTeleport);
	
	// Create teleporter beam
	%beam = newObject("", "StaticShape", TeleportBeam, true);
	NukeList(%beam);
	GameBase::setPosition(%beam,%pos);
	GameBase::setRotation(%beam,Vector::add(%prot,"0 0 3.14"));
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	addToSet("MissionCleanup/Teleports", %beam);
	addToSet("MissionCleanup", %beam);
	%objTeleport.beam1 = %beam;
	
	// Wrap things up
	%beam.disabled = false;
	%beam.Functional = true;
	playSound(SoundPickupBackpack, $los::position);
	Client::sendMessage(%client, 0, %item.description @ " deployed");
	echo("MSG: ",%client," deployed a Teleport Pad");
	return true;
}

StaticShapeData DeployableTeleport
{
	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";
	shapeFile = "enerpad";
	maxDamage = 200;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};

//
StaticShapeData TeleportBeam 	
{ 
	className = "TeleportBeam";
	shapeFile = "zap";		//_5"; 
	maxDamage = 10000.0; 
	isTranslucent = true; 
	description = "Electrical Beam";  
};

function RemoveBeam(%b)
{
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}

function DeployableTeleport::Destruct(%this)
{
	//CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}

// reworked this function to tele on beam contact, and destroy properly 
function DeployableTeleport::onDestroyed(%this)
{
	echo("DeployableTeleport::onDestroyed");
	schedule("RemoveBeam("@%this.beam1@");",0.01);
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		// Applying damage to all teleporters on this team
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		}
	}
}



// reworked this function to tele on beam contact 
// added player rotation and push out of tele also.
function TeleportBeam::onCollision(%this, %obj)
{	
	if($debug) 
		event::collision(%this,%obj);

	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		return;
	%c = Player::getClient(%obj);
	if(!%this.Functional)
	{
		if(Laptop::IsAvailable(%obj))
			Laptop::Error(%c, "Teleporter fatally malfunctioned and is permanently disabled.");
		else
			Client::SendMessage(%c, 0, "Teleporter malfunction");
		return;
	}
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	if(%this.disabled)
	{
		if(Laptop::IsAvailable(%obj))
			Laptop::Error(%c, "Teleporter is recharging.");
		else
			Client::SendMessage(%c,0,"Teleporter is recharging");
		return;
	}
	%phased = false;
	if(%teleTeam != %playerTeam)
	{
		if(Laptop::IsAvailable(%obj))
			%phased = true;
		else
		{
			Client::SendMessage(%c,0,"--ACCESS DENIED-- Wrong Team~waccess_denied.wav");
			return;
		}
	}

//	if(Player::getArmor(%obj).shapeFile == "harmor")
//	{ 
//		if(Laptop::IsAvailable(%obj))
//			Laptop::Error(%c, "Current armor class is too large to teleport.");
//		else
//			Client::SendMessage(%c,0,"Cannot teleport this armor class");
//		return;
//	}	

	//
	// Teleport operation passed initial validation.
	//

	// Find the other pad
	%teleset = nameToID("MissionCleanup/Teleports");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == %teleTeam && %o != %this && GameBase::getDataName(%o) == TeleportBeam)
		{
			if(!%phased)
				Client::SendMessage(%c, 0, "Teleport successful");
			else
				Laptop::Output(%c, "Enemy teleport override successful");
			GameBase::playSound(%o, ForceFieldOpen, 0);
			GameBase::playSound(%this, ForceFieldOpen, 0);
			GameBase::SetPosition(%obj, Vector::add(GameBase::GetPosition(%o),"0 0 1"));
			%Trot = GameBase::getRotation(%o); 
			GameBase::setRotation(%obj,%Trot);
			
	Item::setVelocity(%obj,"0 0 0");
	%forceDir = Vector::getFromRot(GameBase::getRotation(%obj),70,10); 
	Player::applyImpulse(%obj,%forceDir); 
		
			%o.Disabled = true;
			%this.Disabled = true;
			// GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 55) == 0)
			{
				if(Laptop::IsAvailable(%obj))
					Laptop::Error(%c,"Teleporter permanently disabled due to malfunction.");
				else
					Client::SendMessage(%c,0,"Teleport malfunction");
				GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
	//			%this.Functional = false;
			}
			else
			{	schedule("DeployableTeleport::Reenable("@%o@");",5,%o);
				schedule("DeployableTeleport::Reenable("@%this@");",5,%this);
			}
			return;
		}
	}
	if(Laptop::IsAvailable(%obj))
		Laptop::Error(%c, "No receiving teleport pad has been deployed.");
	else
		Client::SendMessage(%c,0,"No other teleport pad");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

