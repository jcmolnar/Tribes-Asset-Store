//Gaurd Tower
$TeamItemMax[BunkerPack2] = 3;
$InvList[BunkerPack2] = 1;
$RemoteInvList[BunkerPack2] = 1;


function deployBunkerPack2::Initialize()
{
  $TeamItemCount[0 @ BunkerPack2] = 0;
  $TeamItemCount[1 @ BunkerPack2] = 0;
  $TeamItemCount[2 @ BunkerPack2] = 0;
  $TeamItemCount[3 @ BunkerPack2] = 0;
  $TeamItemCount[4 @ BunkerPack2] = 0;
  $TeamItemCount[5 @ BunkerPack2] = 0;
  $TeamItemCount[6 @ BunkerPack2] = 0;
  $TeamItemCount[7 @ BunkerPack2] = 0;
}

//-=-=-=-=-=-=-=- Bunker Pack =-=-=-=-=-=-=-

ItemImageData BunkerPack2Image
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BunkerPack2
{
	description = "Constructionyard";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = $InvHead[ihBul];
	imageType = BunkerPack2Image;
	shadowDetailMask = 4;
	mass = 2;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BunkerPack2::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BunkerPack2::onDeploy(%player,%item,%pos)
{
	if (BunkerPack2::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function BunkerPack2::deployShape(%player,%item)
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
							%wall = newObject("wall", "InteriorShape", "const.dis");
						//	%obj2 = getObjectType{%wall);
					//		Client::sendMessage(%client,0,"The Deployable Wall is a" @ %obj2  @ " !");

							addToSet("MissionCleanup", %wall);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%wall,$los::position);
							GameBase::setRotation(%wall,%rot);
							Gamebase::setMapName(%wall,"construction yard");
							Client::sendMessage(%client,0,"construction yard avalible");
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


