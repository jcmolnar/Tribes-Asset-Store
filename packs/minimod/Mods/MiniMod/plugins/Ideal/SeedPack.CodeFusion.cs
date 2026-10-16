// This is a MiniMod Plugin.
// This plugin is the Seed Pack from the Ideal mod. Ported by Dewy.

MiniMod::MonitorFile(start, "SeedPack.CodeFusion.cs", "Seed Pack Plugin");
MiniMod::Turbo::Class(TreePack, 18);

$TeamItemMax[TreePack] = 40;

ItemImageData TreePackImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Seed Pack";
	shapeFile = "jetpack";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item))
	{
		//Player::decItemCount(%player,%item); //thus infinite trees to plant
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%rand = floor(getRandom() * 6);
						if(%rand == 0) %type = "TreeShapeTwo";
						else if(%rand == 1) %type = "TreeShape"; 
						//else if(%rand == 3) %type = "PlantOne"; 
						else if(%rand == 2) %type = "PlantTwo";
						else if(%rand == 3) %type = "Cactus1"; 
						else if(%rand == 4) %type = "Cactus2"; 
						else %type = "Cactus3"; 

						%tree = newObject("A Tree","StaticShape",%type,true);
                 				addToSet("MissionCleanup", %tree);
						GameBase::setTeam(%tree,GameBase::getTeam(%player));
						GameBase::setPosition(%tree,$los::position);
						GameBase::setRotation(%tree,%rot);
						Gamebase::setMapName(%tree,"Tree " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Seed Planted");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
						echo("MSG: ",%client," planted a seed");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %tree); 
						// Client::setOwnedObject(%client, %player);
						return true;
					}
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description);

	return false;
}

$InvList[TreePack] = 1;
$RemoteInvList[TreePack] = 1;

MiniMod::MonitorFile(stop, "SeedPack.CodeFusion.cs", "Seed Pack Plugin");
