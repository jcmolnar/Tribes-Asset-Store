$InvList[iBlastWall] = 1;
$RemoteInvList[iBlastWall] = 1;
$Object2Item[BlastWall] = iBlastWall;
$DeployedObject[BlastWall] = true;
$CanDeployOnto[BlastWall] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iBlastWall] = 0;
$ItemMax[reconfemalearmor, iBlastWall] = 0;
$ItemMax[espionagearmor, iBlastWall] = 0;
$ItemMax[espionagefemalearmor, iBlastWall] = 0;
$ItemMax[engineerarmor, iBlastWall] = 1;
$ItemMax[engineerfemalearmor, iBlastWall] = 1;
$ItemMax[infantryarmor, iBlastWall] = 0;
$ItemMax[infantryfemalearmor, iBlastWall] = 0;
$ItemMax[falloutarmor, iBlastWall] = 0;
$ItemMax[falloutfemalearmor, iBlastWall] = 0;
$ItemMax[demolitionsarmor, iBlastWall] = 0;
$ItemMax[assaultarmor, iBlastWall] = 0;
$ItemMax[artilleryarmor, iBlastWall] = 0;
$ItemMax[commanderarmor, iBlastWall] = 0;

$TeamItemMax[iBlastWall] = 10;

ItemImageData BlastWallImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iBlastWall 
{
  description = "Blast Wall";
  shapeFile = "newdoor5";
  className = "Backpack";
  heading = "dDeployables";
  imageType = BlastWallImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 1200;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iBlastWall::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iBlastWall::onDeploy(%player, %item, %pos) {
	if (iBlastWall::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iBlastWall::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurfaceOutsideOnly($los::object)) {

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
								%turret = newObject("BlastWall", "StaticShape", BlastWall, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Blast Wall - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Blast Wall deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iBlastWall"]++;
								echo("MSG: ",%client," deployed a Blast Wall");
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


StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	debrisId = flashDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Blast Wall";
};

function BlastWall::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Blast Wall");
}

function BlastWall::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iBlastWall"]--;
}

