exec(deploybase2);
//powerplant
$TeamItemMax[BunkerPack] = 3;
$InvList[BunkerPack] = 1;
$RemoteInvList[BunkerPack] = 1;


function deployBunkerPack::Initialize()
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

//-=-=-=-=-=-=-=- Bunker Pack =-=-=-=-=-=-=-

ItemImageData BunkerPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BunkerPack
{
	description = "Powerplant";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = $InvHead[ihBul];
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 2;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"wall",%num);
				deleteObject(%set);
				//if(0 == %num) {
				//	if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						//if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%wall = newObject("wall", "InteriorShape", "powerp.dis");
						//	%obj2 = getObjectType{%wall);
					//		Client::sendMessage(%client,0,"The Deployable Wall is a" @ %obj2  @ " !");

							addToSet("MissionCleanup", %wall);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%wall,$los::position);
							GameBase::setRotation(%wall,%rot);
							Gamebase::setMapName(%wall,"Deployable Bunker");
							Client::sendMessage(%client,0,"Bunker Deployed");
							GameBase::startFadeIn(%wall);
							playSound(SoundPickupBackpack,$los::position);
						//	playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
							return true;
						//}
				//	}
				//	else 
				//		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			//	} 
			//	else
			//		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Force Fields");
		//	}
		//	else 
		//		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
	}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


