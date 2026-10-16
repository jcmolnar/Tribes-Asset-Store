// List of all items available to buy from Bot station

//----------------------------------------------------------------------------

$DataBlockName[GuardBot] = Guard_NRS;
$DataBlockName[MortarBot] = Mortar_CMD;
$DataBlockName[DemoBot] = Demo_CMD;
$DataBlockName[MedicBot] = Medic_NRS;
$DataBlockName[MinerBot] = Miner_CMD;
$DataBlockName[SniperBot] = Sniper_CMD;
$DataBlockName[PainterBot] = Painter_NRS;

$VehicleToItem[Guard_NRS] = GuardBot;
$VehicleToItem[Mortar_CMD] = MortarBot;
$VehicleToItem[Demo_CMD] = DemoBot;
$VehicleToItem[Medic_NRS] = MedicBot;
$VehicleToItem[Miner_CMD] = MinerBot;
$VehicleToItem[Sniper_CMD] = SniperBot;
$VehicleToItem[Painter_NRS] = PainterBot;

$TeamItemMax[GuardBot] = 5;
$TeamItemMax[MortarBot] = 5;
$TeamItemMax[DemoBot] = 5;
$TeamItemMax[MedicBot] = 5;
$TeamItemMax[MinerBot] = 5;
$TeamItemMax[SniperBot] = 5;
$TeamItemMax[PainterBot] = 5;
$TeamItemMax[BotStationPack] = 3;

ItemData GuardBot
{
	description = "Guard Bot";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 800;
};

ItemData MortarBot
{
	description = "Mortar Bot";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 600;
};

ItemData DemoBot
{
	description = "Demolitions Bot";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 500;
};

ItemData MedicBot
{
	description = "Medic Bot";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 500;
};

ItemData MinerBot
{
	description = "Minelayer Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 400;
};

ItemData SniperBot
{
	description = "Sniper Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 300;
};

ItemData PainterBot
{
	description = "Target Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 200;
};

function BotStationPack::Initialize()
{
  $TeamItemCount[0 @ BotStationPack] = 0;
  $TeamItemCount[1 @ BotStationPack] = 0;
  $TeamItemCount[2 @ BotStationPack] = 0;
  $TeamItemCount[3 @ BotStationPack] = 0;
  $TeamItemCount[4 @ BotStationPack] = 0;
  $TeamItemCount[5 @ BotStationPack] = 0;
  $TeamItemCount[6 @ BotStationPack] = 0;
  $TeamItemCount[7 @ BotStationPack] = 0;
}


//------------------------------------------------

ItemImageData BotStationPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BotStationPack
{
	description = "Troop Purchase Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "jOther Deployables";
	shadowDetailMask = 4	;
	imageType = BotStationPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 6000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function BotStationPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function BotStationPack::onDeploy(%player,%item,%pos)
{
	if (BotStationPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function BotStationPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","BotStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Bot Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "BotStationPack"]++;
						echo("MSG: ",%client," deployed a Bot Purchase Station");
						return true;
					}
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//			}
//			else
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

