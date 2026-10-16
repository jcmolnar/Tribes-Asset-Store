//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[TeleportPack] = 1;

//$TeamItemMax[TeleportPack] = 4;
$TeamItemMax[DeployableTeleport] = 4;


$ItemMax[larmor, TeleportPack] = 0;	//Seraph
$ItemMax[lfemale, TeleportPack] = 0;	//Seraph
$ItemMax[earmor, TeleportPack] = 1;	//Slave
$ItemMax[efemale, TeleportPack] = 1;	//Slave
$ItemMax[marmor, TeleportPack] = 0;	//Pawn
$ItemMax[aarmor, TeleportPack] = 0;	//Navigator
$ItemMax[darmor, TeleportPack] = 0;	//Atomizer
$ItemMax[barmor, TeleportPack] = 0;	//Paladin


function deployTeleportPack::Initialize()
{
	$TeamItemCount[0 @ TeleportPack] = 0;
	$TeamItemCount[1 @ TeleportPack] = 0;
	$TeamItemCount[2 @ TeleportPack] = 0;
	$TeamItemCount[3 @ TeleportPack] = 0;
	$TeamItemCount[4 @ TeleportPack] = 0;
	$TeamItemCount[5 @ TeleportPack] = 0;
	$TeamItemCount[6 @ TeleportPack] = 0;
	$TeamItemCount[7 @ TeleportPack] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++



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
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "jTransportation";
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
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && %obj == "DeployablePlatform") 
	{
		lient::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	// Verify slope of deploy location
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	// Make sure nothing is in the way of the deploy
	if(!checkDeployArea(%client,$los::position)) 
	{
		return false;
	}
	//
	// Passed validation, create the object
	//
	NeedTeleportSimSet();
	// Set the starting posistion a bit off the ground (for whatever reason)
	%pos = Vector::add($los::position,"0 0 1");
	// Create teleporter pad
	%objTeleport = newObject("Teleport Pad", "StaticShape", %shape, true);
	%objTeleport.Functional = true;
	GameBase::setPosition(%objTeleport,%pos);
	GameBase::setTeam(%objTeleport,GameBase::getTeam(%player));
	Gamebase::setMapName(%objTeleport,%name);
	addToSet("MissionCleanup/Teleports", %objTeleport);
	addToSet("MissionCleanup", %objTeleport);
	// Create teleporter beam
	%beam = newObject("", "StaticShape", ElectricalBeamBig, true);
	GameBase::setPosition(%beam,%pos);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	addToSet("MissionCleanup", %beam);
	%objTeleport.beam1 = %beam;
	// Wrap things up
	%objTeleport.disabled = false;
	playSound(SoundPickupBackpack, $los::position);
	Client::sendMessage(%client, 0, %item.description @ " deployed");
	echo("MSG: ",%client," deployed a Teleport Pad");
	return true;
}

StaticShapeData DeployableTeleport
{
	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";
	shapeFile = "flagstand"; //enerpad
	maxDamage = 0.75;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
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

function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);
	// CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
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

function DeployableTeleport::onCollision(%this, %obj)
{
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
		if(GameBase::getTeam(%o) == %teleTeam && %o != %this)
		{
			if(!%phased)
				Client::SendMessage(%c, 0, "Teleport successful");
			else
				Laptop::Output(%c, "Enemy teleport override successful");
			GameBase::playSound(%o, ForceFieldOpen, 0);
			GameBase::playSound(%this, ForceFieldOpen, 0);
			GameBase::SetPosition(%obj, GameBase::GetPosition(%o));
			%o.Disabled = true;
			%this.Disabled = true;
			// GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 55) == 0)
			{
				if(Laptop::IsAvailable(%obj))
					Laptop::Error(%c,"Teleporter permanently disabled to to malfunction.");
				else
					Client::SendMessage(%c,0,"Teleport malfunction");
				GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
				%this.Functional = false;
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


//ItemImageData TeleportPackImage 
//{ shapeFile = "flagstand"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData TeleportPack { description = "Teleport Pad"; shapeFile = "flagstand"; className = "Backpack"; heading = "jTransportation"; imageType = TeleportPackImage; shadowDetailMask = 4; mass = 5.0; elasticity = 0.2; price = 1000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TeleportPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TeleportPack::onDeploy(%player,%item,%pos) { if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; } } function CreateteleportSimSet() { %teleset = nameToID("MissionCleanup/Teleports"); if(%teleset == -1) { newObject("Teleports",SimSet); addToSet("MissionCleanup","Teleports"); } } function TeleportPack::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %sensor = newObject("Teleport Pad","StaticShape",%shape,true); CreateteleportSimSet(); addToSet("MissionCleanup/Teleports", %sensor); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); %pos = Vector::add($los::position,"0 0 1"); echo("LOS pos " @ $los::position @ " " @ %pos); GameBase::setPosition(%sensor,%pos); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); %sensor.disabled = false; playSound(SoundPickupBackpack,$los::position); %beam = newObject("","StaticShape",ElectricalBeamBig,true); addToSet("MissionCleanup", %beam); GameBase::setTeam(%beam,GameBase::getTeam(%player)); GameBase::setPosition(%beam,%pos); %sensor.beam1 = %beam; return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; }
