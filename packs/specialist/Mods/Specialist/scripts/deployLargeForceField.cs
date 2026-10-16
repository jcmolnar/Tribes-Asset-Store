$InvList[iForceField] = 1;
$RemoteInvList[iForceField] = 1;
$Object2Item[dForceField] = iForceField;
$DeployedObject[dForceField] = true;
$CanDeployOnto[ForceField] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iForceField] = 0;
$ItemMax[reconfemalearmor, iForceField] = 0;
$ItemMax[espionagearmor, iForceField] = 0;
$ItemMax[espionagefemalearmor, iForceField] = 0;
$ItemMax[engineerarmor, iForceField] = 1;
$ItemMax[engineerfemalearmor, iForceField] = 1;
$ItemMax[infantryarmor, iForceField] = 0;
$ItemMax[infantryfemalearmor, iForceField] = 0;
$ItemMax[falloutarmor, iForceField] = 0;
$ItemMax[falloutfemalearmor, iForceField] = 0;
$ItemMax[demolitionsarmor, iForceField] = 0;
$ItemMax[assaultarmor, iForceField] = 0;
$ItemMax[artilleryarmor, iForceField] = 0;
$ItemMax[commanderarmor, iForceField] = 0;

$TeamItemMax[iForceField] = 4;

ItemImageData ForceFieldImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iForceField 
{
  description = "Large Force Field";
  shapeFile = "forcefield";
  className = "Backpack";
  heading = "dDeployables";
  imageType = ForceFieldImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 1200;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iForceField::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iForceField::onDeploy(%player, %item, %pos) {
	if (iForceField::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iForceField::deployShape(%player,%item)
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
							// %rot = "0 0 0";
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
								%turret = newObject("ForceField", "StaticShape", dForceField, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Force Field - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Force Field deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iForceField"]++;
								echo("MSG: ",%client," deployed a Force Field");
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


StaticShapeData dForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.0;
	isTranslucent = true;
	description = "Force Field";
};

function dForceField::onAdd(%this) {
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Force Field");
}

function dForceField::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iForceField"]--;
}

