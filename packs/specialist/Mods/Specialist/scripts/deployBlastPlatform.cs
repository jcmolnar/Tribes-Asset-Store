$InvList[iBlastPlatform] = 1;
$RemoteInvList[iBlastPlatform] = 1;
$Object2Item[BlastPlatform] = iBlastPlatform;
$DeployedObject[BlastPlatform] = true;
$CanDeployOnto[BlastPlatform] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iBlastPlatform] = 0;
$ItemMax[reconfemalearmor, iBlastPlatform] = 0;
$ItemMax[espionagearmor, iBlastPlatform] = 0;
$ItemMax[espionagefemalearmor, iBlastPlatform] = 0;
$ItemMax[engineerarmor, iBlastPlatform] = 1;
$ItemMax[engineerfemalearmor, iBlastPlatform] = 1;
$ItemMax[infantryarmor, iBlastPlatform] = 0;
$ItemMax[infantryfemalearmor, iBlastPlatform] = 0;
$ItemMax[falloutarmor, iBlastPlatform] = 0;
$ItemMax[falloutfemalearmor, iBlastPlatform] = 0;
$ItemMax[demolitionsarmor, iBlastPlatform] = 0;
$ItemMax[assaultarmor, iBlastPlatform] = 0;
$ItemMax[artilleryarmor, iBlastPlatform] = 0;
$ItemMax[commanderarmor, iBlastPlatform] = 0;

$TeamItemMax[iBlastPlatform] = 12;

ItemImageData BlastPlatformImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iBlastPlatform 
{
  description = "Blast Platform";
  shapeFile = "elevator6x6thin";
  className = "Backpack";
  heading = "dDeployables";
  imageType = BlastPlatformImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iBlastPlatform::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iBlastPlatform::onDeploy(%player, %item, %pos) {
	if (iBlastPlatform::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iBlastPlatform::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

						// Make sure it's on a flat surface
						// if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						// if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						// 	%rot = GameBase::getRotation(%player); 
						//}
						//else {
						//	if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						//		%rot = "3.14159 0 0";
						//	}
						//	else {
						//		%rot = Vector::getRotation($los::normal);
						//	}
						//}
							// Make sure player is out of the way
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("BlastPlatform", "StaticShape", BlastPlatform, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Blast Platform - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Blast Platform deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iBlastPlatform"]++;
								echo("MSG: ",%client," deployed a Blast Platform");
								return true;
							}
						 // }
						 // else
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


StaticShapeData BlastPlatform
{
	shapeFile = "elevator6x6thin";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.0;
	isTranslucent = true;
	description = "Blast Cover";
};

function BlastPlatform::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Blast Platform");
}

function BlastPlatform::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iBlastPlatform"]--;
}

