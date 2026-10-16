//--------------------------------------

$InvList[TripwirePack] = 1;
$RemoteInvList[TripWirePack] = 1;

//--------------------------------------
$TeamItemMax[TripWirePack] = 25;
//__________________________

StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 30.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Metal Wall";

};
function BlastWall::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--;
	
}
StaticShapeData BlastWall2
{
	shapeFile = "newdoor5";
	maxDamage = 30.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Metal Wall";

};
function BlastWall2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--;
	
}


ItemImageData TripwirePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TripwirePack
{
	description = "Metal Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
    heading = "uDeployables";
	imageType = TripwirePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TripwirePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TripwirePack::onDeploy(%player,%item,%pos)
{
	if (TripwirePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TripwirePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain") {
		    	%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"BlastWall",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
   						    %fField = newObject("","StaticShape",BlastWall,true);
							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Blast Wall");
							Client::sendMessage(%client,0,"Blast Wall Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		//	}
		//	else 
		//		Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

