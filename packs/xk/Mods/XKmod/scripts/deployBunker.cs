$TeamItemMax[BunkerPack] = 3;
$InvList[BunkerPack] = 1;
$RemoteInvList[BunkerPack] = 1;

$CanAlwaysTeamDestroy[Bunker] = 1;

//-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployBunker::Initialize()
{
	$TeamItemCount[0 @ BunkerPack] = 0; 
	$TeamItemCount[1 @ BunkerPack] = 0; 
	$TeamItemCount[2 @ BunkerPack] = 0; 
	$TeamItemCount[3 @ BunkerPack] = 0; 
	$TeamItemCount[4 @ BunkerPack] = 0; 
	$TeamItemCount[5 @ BunkerPack] = 0; 
	$TeamItemCount[6 @ BunkerPack] = 0; 
	$TeamItemCount[7 @ BunkerPack] = 0; 
}



// Bunker Pack
ItemImageData BunkerPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, 0 };
	mountRotation = { -3, 0, 0 };
	mass = 10.5;
	firstPerson = false;
};

ItemData BunkerPack
{
	description = "Deployable Bunker";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "$InvHead[ihDOb]";
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 2800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
};

function BunkerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BunkerPack::onDeploy(%player,%item,%pos)
{
	if (BunkerPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BunkerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < 3) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player);
						%bunker = newObject("bunker", "InteriorShape", "bunker.dis");
						addToSet("MissionCleanup", %bunker);
						GameBase::setTeam(%bunker,GameBase::getTeam(%player));
						GameBase::setPosition(%bunker,$los::position);
						GameBase::setRotation(%bunker,%rot);
						Gamebase::setMapName(%bunker,"Bunker");
						Client::sendMessage(%client,0,"Bunker Deployed");
						GameBase::startFadeIn(%bunker);
						playSound(SoundPickupBackpack,$los::position);
						playSound(SoundDoorClose,$los::position);
						playSound(shockExplosion,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
						echo("MSG: ",%client," deployed a bunker.");
						return true;
						}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
		Client::sendMessage(%client,0,"You can only have 3 bunkers!");

	return false;
}


