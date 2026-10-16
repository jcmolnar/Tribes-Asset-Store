$InvList[iBarricade] = 1;
$RemoteInvList[iBarricade] = 1;
$Object2Item[Barricade] = iBarricade;
$DeployedObject[Barricade] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iBarricade] = 0;
$ItemMax[reconfemalearmor, iBarricade] = 0;
$ItemMax[espionagearmor, iBarricade] = 0;
$ItemMax[espionagefemalearmor, iBarricade] = 0;
$ItemMax[engineerarmor, iBarricade] = 1;
$ItemMax[engineerfemalearmor, iBarricade] = 1;
$ItemMax[infantryarmor, iBarricade] = 0;
$ItemMax[infantryfemalearmor, iBarricade] = 0;
$ItemMax[falloutarmor, iBarricade] = 0;
$ItemMax[falloutfemalearmor, iBarricade] = 0;
$ItemMax[demolitionsarmor, iBarricade] = 0;
$ItemMax[assaultarmor, iBarricade] = 0;
$ItemMax[artilleryarmor, iBarricade] = 0;
$ItemMax[commanderarmor, iBarricade] = 1;

$TeamItemMax[iBarricade] = 30;

ItemImageData BarricadeImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iBarricade 
{
  description = "Barricade";
  shapeFile = "magcargo";
  className = "Backpack";
  heading = "dDeployables";
  imageType = BarricadeImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 100;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iBarricade::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iBarricade::onDeploy(%player, %item, %pos) {
	if (iBarricade::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iBarricade::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 4.5)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurfaceStack($los::object, "Barricade")) {

						// Make sure it's on a flat surface
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
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
								%turret = newObject("Barricade", "StaticShape", Barricade, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Barricade - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Barricade deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iBarricade"]++;
								echo("MSG: ",%client," deployed a Barricade");
								return true;
							}
						 }
						 else
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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


StaticShapeData Barricade
{
	shapeFile = "magcargo";
	debrisId = flashDebrisSmall;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Barricade";
};

function Barricade::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Barricade");
}

function Barricade::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iBarricade"]--;
}

