$InvList[iTeleporter] = 1;
$RemoteInvList[iTeleporter] = 1;
$Object2Item[dTeleporter] = iTeleporter;
$DeployedObject[dTeleporter] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iTeleporter] = 0;
$ItemMax[reconfemalearmor, iTeleporter] = 0;
$ItemMax[espionagearmor, iTeleporter] = 0;
$ItemMax[espionagefemalearmor, iTeleporter] = 0;
$ItemMax[engineerarmor, iTeleporter] = 1;
$ItemMax[engineerfemalearmor, iTeleporter] = 1;
$ItemMax[infantryarmor, iTeleporter] = 0;
$ItemMax[infantryfemalearmor, iTeleporter] = 0;
$ItemMax[falloutarmor, iTeleporter] = 0;
$ItemMax[falloutfemalearmor, iTeleporter] = 0;
$ItemMax[demolitionsarmor, iTeleporter] = 0;
$ItemMax[assaultarmor, iTeleporter] = 0;
$ItemMax[artilleryarmor, iTeleporter] = 0;
$ItemMax[commanderarmor, iTeleporter] = 0;

$TeamItemMax[iTeleporter] = 3;

$TeleporterRange = 2000;
$TeleporterRechargeTime = 3;

SoundData SoundTeleporterActivate
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

ItemImageData TeleporterImage
{
  shapeFile = "enerpad";
  mountPoint = 2;
  mountOffset = { 0, -0.9, -0.5 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
	mass = 2.5;
};

ItemData iTeleporter 
{
  description = "Teleporter";
  shapeFile = "enerpad";
  className = "Backpack";
  heading = "dDeployables";
  imageType = TeleporterImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3200;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iTeleporter::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iTeleporter::onDeploy(%player, %item, %pos) {
	if (iTeleporter::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iTeleporter::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

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

								// Find closest Teleporter
								// by getting all the objects in range,
								%set = newObject("searchSet", SimSet);
								%mask = $StaticObjectType;
								%pos = $los::position;
								%size = $TeleporterRange;
								%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);

								// going through them and looking for Teleporters,
								// and finding the closest Teleporter to our deploy point.
								%closestSoFar = -1;

								for (%index = 0; %index < %num; %index++) {
									%currObj = Group::getObject(%set, %index);
									
									%name = GameBase::getDataName(%currObj);
									// echo("Name: " @%name);

									if (%name == dTeleporter) {
									
										if (%closestSoFar == -1) %closestSoFar = %currObj;
										else {
											%distance = Vector::getDistance(GameBase::getPosition(%currObj), %pos);
											if (%distance < %closestSoFar && GameBase::getTeam(%player) == GameBase::getTeam(%currObj))
												%closestSoFar = %currObj;
										}
									}
								}

								deleteObject(%set);

								// If a Teleporter was found, or this is the first teleporter
								if (%closestSoFar > -1 || $TeamItemCount[GameBase::getTeam(%player) @ "iTeleporter"] < 1) {

									%rot = GameBase::getRotation(%player); 
									%turret = newObject("Teleporter", "StaticShape", dTeleporter, true);
									addToSet("MissionCleanup", %turret);
									GameBase::setTeam(%turret,GameBase::getTeam(%player));
									GameBase::setPosition(%turret,$los::position);
									GameBase::setRotation(%turret,%rot);
									Gamebase::setMapName(%turret,"Teleporter - " @ Client::getName(%client));
									Client::sendMessage(%client,0,"Teleporter deployed");
									playSound(SoundPickupBackpack,$los::position);
									$TeamItemCount[GameBase::getTeam(%player) @ "iTeleporter"]++;
									echo("MSG: ",%client," deployed a Teleporter");
									$lock[%turret] = true;
									schedule("dTeleporter::unlock("@%turret@");", $TeleporterRechargeTime);
									return true;

								} else Client::sendMessage(%client,0,"No Teleporter in range.");


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

StaticShapeData dTeleporter
{
	shapeFile = "enerpad";
	debrisId = defaultDebrisSmall;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	maxDamage = 3.0;
	explosionId = flashExpMedium;
	description = "Teleporter";
};

function dTeleporter::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iTeleporter"]--;

}


function dTeleporter::onCollision(%this, %object) {
	// This function will teleport the player when they 
	// collide with the teleporter.

	// echo("Teleporter collision");

	// Check to see if it's a player
	%type = getObjectType(%object);
	// echo("Type: " @%type);
	if (%type != "Player") return;

	// Check to see if the team is the same
	if (GameBase::getTeam(%this) != GameBase::getTeam(%object)) {
		// we should print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"ACCESS DENIED -- Wrong team");
		return;
	}

	// Check to see if the teleporter is locked
	if ($lock[%this]) {
		// print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"Please wait while teleporter recharges");
		return;
	}

	// Check to see if armor restrictions are correct
	%pArmor = Player::getArmor(%object);
	if ( %pArmor == artilleryarmor || %pArmor == commanderarmor) {
		// print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"ACCESS DENIED -- This armor type cannot be teleported");
		return;
	}

	// Check to see if there is another teleporter in range
	%set = newObject("searchSet", SimSet);
	%mask = $StaticObjectType;
	%pos = GameBase::getPosition(%this);
	%size = $TeleporterRange;
	%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);

	%closestSoFar = -1;
	for (%index = 0; %index < %num; %index++) {
		%currObj = Group::getObject(%set, %index);
			
		%name = GameBase::getDataName(%currObj);
		// echo("Name: " @%name);

		if (%name == dTeleporter && %this != %currObj) {
									
			if (%closestSoFar == -1) {
				%closestSoFar = %currObj;
				%smallestDistance = Vector::getDistance(GameBase::getPosition(%currObj), %pos);
			}
			else {
				%objPos = GameBase::getPosition(%currObj);
				%distance = Vector::getDistance(%objPos, %pos);
				if (%distance < %smallestDistance && GameBase::getTeam(%player) == GameBase::getTeam(%currObj)) {
					%closestSoFar = %currObj;
					%smallestDistance = %distance;
				}
			}
		}
	}
	deleteObject(%set);

	if (%closestSoFar == -1) {
		// print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"No destination teleporter in range");
		return;
	}


	// lock the teleporters
	dTeleporter::lock(%this);
	dTeleporter::lock(%closestSoFar);

	// play the sound at both teleporters
	GameBase::playSound(%this, SoundTeleporterActivate, 3);
	GameBase::playSound(%closestSoFar, SoundTeleporterActivate, 3);

	// Teleport the player
	// echo("Teleporting");
	GameBase::setPosition(%object, GameBase::getPosition(%closestSoFar));

	// schedule the unlocks
	schedule("dTeleporter::unlock("@%this@");", $TeleporterRechargeTime);
	schedule("dTeleporter::unlock("@%closestSoFar@");", $TeleporterRechargeTime);

}

function dTeleporter::lock(%this) {
	// This function locks the teleporter so that it cannot be used.
	$lock[%this] = true;
}

function dTeleporter::unlock(%this) {
	// This function unlocks the teleporter so that it can be used.
	$lock[%this] = "";
}

