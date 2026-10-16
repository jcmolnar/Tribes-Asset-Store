//--------------------------------------

$InvList[TreePack] = 1;
$RemoteInvList[TreePack] = 1;

//--------------------------------------
$TeamItemMax[TreePack] = 50;
//__________________________
StaticShapeData DeployableTree
{
	shapeFile = "tree1";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
};

function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

StaticShapeData DeployableTree2
{
	shapeFile = "tree2";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Tree";
};

function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}


ItemImageData TreePackImage
{
	//shapeFile = "AmmoPack";
	shapeFile = "tree1";
	mountPoint = 2;
   mountOffset = { 0, 0.15, -1 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Camo-Tree";
	//shapeFile = "AmmoPack";
	shapeFile = "tree1";
	className = "Backpack";
   heading = "h:(Snipers Gear:(";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
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

function TreePack::onDeploy(%player,%item)
{
	if (TreePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TreePack::deployShape(%player,%item)
{
%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableTree",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.0) //0.7
					{
							%rot = GameBase::getRotation(%player);
							 %fField = newObject("","StaticShape",DeployableTree,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"A Tree");
							Client::sendMessage(%client,0,"Tree Planted");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
							return true;
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
