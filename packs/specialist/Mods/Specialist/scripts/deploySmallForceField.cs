$InvList[iSmallForceField] = 1;
$RemoteInvList[iSmallForceField] = 1;
$Object2Item[SmallForceField] = iSmallForceField;
$DeployedObject[SmallForceField] = true;
$CanDeployOnto[SmallForceField] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iSmallForceField] = 0;
$ItemMax[reconfemalearmor, iSmallForceField] = 0;
$ItemMax[espionagearmor, iSmallForceField] = 0;
$ItemMax[espionagefemalearmor, iSmallForceField] = 0;
$ItemMax[engineerarmor, iSmallForceField] = 1;
$ItemMax[engineerfemalearmor, iSmallForceField] = 1;
$ItemMax[infantryarmor, iSmallForceField] = 0;
$ItemMax[infantryfemalearmor, iSmallForceField] = 0;
$ItemMax[falloutarmor, iSmallForceField] = 0;
$ItemMax[falloutfemalearmor, iSmallForceField] = 0;
$ItemMax[demolitionsarmor, iSmallForceField] = 0;
$ItemMax[assaultarmor, iSmallForceField] = 0;
$ItemMax[artilleryarmor, iSmallForceField] = 0;
$ItemMax[commanderarmor, iSmallForceField] = 0;

$TeamItemMax[iSmallForceField] = 12;

ItemImageData SmallForceFieldImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iSmallForceField 
{
  description = "Small Force Field";
  shapeFile = "forcefield_5x5";
  className = "Backpack";
  heading = "dDeployables";
  imageType = SmallForceFieldImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iSmallForceField::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iSmallForceField::onDeploy(%player, %item, %pos) {
	if (iSmallForceField::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iSmallForceField::deployShape(%player,%item)
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
								%turret = newObject("SmallForceField", "StaticShape", SmallForceField, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Small Force Field - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Small Force Field deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iSmallForceField"]++;
								echo("MSG: ",%client," deployed a Small Force Field");
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


StaticShapeData SmallForceField
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.0;
	isTranslucent = true;
	description = "Small Force Field";
};

function SmallForceField::onAdd(%this) {
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Small Force Field");
}

function SmallForceField::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iSmallForceField"]--;
}

