$InvList[iBlastCover] = 1;
$RemoteInvList[iBlastCover] = 1;
$Object2Item[BlastCover] = iBlastCover;
$DeployedObject[BlastCover] = true;
$CanDeployOnto[BlastCover] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iBlastCover] = 0;
$ItemMax[reconfemalearmor, iBlastCover] = 0;
$ItemMax[espionagearmor, iBlastCover] = 0;
$ItemMax[espionagefemalearmor, iBlastCover] = 0;
$ItemMax[engineerarmor, iBlastCover] = 1;
$ItemMax[engineerfemalearmor, iBlastCover] = 1;
$ItemMax[infantryarmor, iBlastCover] = 0;
$ItemMax[infantryfemalearmor, iBlastCover] = 0;
$ItemMax[falloutarmor, iBlastCover] = 0;
$ItemMax[falloutfemalearmor, iBlastCover] = 0;
$ItemMax[demolitionsarmor, iBlastCover] = 0;
$ItemMax[assaultarmor, iBlastCover] = 0;
$ItemMax[artilleryarmor, iBlastCover] = 0;
$ItemMax[commanderarmor, iBlastCover] = 0;

$TeamItemMax[iBlastCover] = 10;

ItemImageData BlastCoverImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iBlastCover 
{
  description = "Blast Cover";
  shapeFile = "elevator6x6thin";
  className = "Backpack";
  heading = "dDeployables";
  imageType = BlastCoverImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iBlastCover::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iBlastCover::onDeploy(%player, %item, %pos) {
	if (iBlastCover::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iBlastCover::deployShape(%player,%item)
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
						 if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						 	%rot = GameBase::getRotation(%player); 
						}
						else {
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
								%rot = "3.14159 0 0";
							}
							else {
								%rot = Vector::getRotation($los::normal);
							}
						}
							// Make sure player is out of the way
							if(checkDeployArea(%client,$los::position)) {
								// %rot = GameBase::getRotation(%player); 
								%turret = newObject("BlastCover", "StaticShape", BlastCover, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Blast Cover - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Blast Cover deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iBlastCover"]++;
								echo("MSG: ",%client," deployed a Blast Cover");
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


StaticShapeData BlastCover
{
	shapeFile = "elevator6x6thin";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.0;
	isTranslucent = true;
	description = "Blast Cover";
};

function BlastCover::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Blast Cover");
}

function BlastCover::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iBlastCover"]--;
}

