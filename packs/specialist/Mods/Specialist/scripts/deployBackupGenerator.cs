$InvList[iBackupGenerator] = 1;
$RemoteInvList[iBackupGenerator] = 1;
$Object2Item[BackupGenerator] = iBackupGenerator;
$DeployedObject[BackupGenerator] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iBackupGenerator] = 0;
$ItemMax[reconfemalearmor, iBackupGenerator] = 0;
$ItemMax[espionagearmor, iBackupGenerator] = 0;
$ItemMax[espionagefemalearmor, iBackupGenerator] = 0;
$ItemMax[engineerarmor, iBackupGenerator] = 1;
$ItemMax[engineerfemalearmor, iBackupGenerator] = 1;
$ItemMax[infantryarmor, iBackupGenerator] = 0;
$ItemMax[infantryfemalearmor, iBackupGenerator] = 0;
$ItemMax[falloutarmor, iBackupGenerator] = 0;
$ItemMax[falloutfemalearmor, iBackupGenerator] = 0;
$ItemMax[demolitionsarmor, iBackupGenerator] = 0;
$ItemMax[assaultarmor, iBackupGenerator] = 0;
$ItemMax[artilleryarmor, iBackupGenerator] = 0;
$ItemMax[commanderarmor, iBackupGenerator] = 0;

$TeamItemMax[iBackupGenerator] = 1;

ItemImageData BackupGeneratorImage
{
  shapeFile = "generator_p";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iBackupGenerator 
{
  description = "Backup Generator";
  shapeFile = "generator_p";
  className = "Backpack";
  heading = "dDeployables";
  imageType = BackupGeneratorImage;
  shadowDetailMask = 4;
  mass = 20.0;
  elasticity = 0.2;
  price = 1200;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iBackupGenerator::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iBackupGenerator::onDeploy(%player, %item, %pos) {
	if (iBackupGenerator::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iBackupGenerator::deployShape(%player,%item)
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

								// Find closest generator
								// by getting all the objects in range,
								%set = newObject("searchSet", SimSet);
								%mask = $StaticObjectType;
								%pos = $los::position;
								%size = 40;
								%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);

								// going through them and looking for generators,
								// and finding the closest generator to our deploy point.
								%closestSoFar = -1;

								for (%index = 0; %index < %num; %index++) {
									%currObj = Group::getObject(%set, %index);
									
									%name = GameBase::getDataName(%currObj);
									// echo("Name: " @%name);

									if (%name.ClassName == Generator) {
									
										if (%closestSoFar == -1) %closestSoFar = %currObj;
										else {
											%distance = Vector::getDistance(GameBase::getPosition(%currObj), %pos);
											if (%distance < %closestSoFar && GameBase::getTeam(%player) == GameBase::getTeam(%currObj))
												%closestSoFar = %currObj;
										}
									}
								}

								deleteObject(%set);

								// If a generator was found, 
								if (%closestSoFar > -1) {

									%rot = GameBase::getRotation(%player); 
									%turret = newObject("BackupGenerator", "StaticShape", BackupGenerator, true);
									// addToSet("MissionCleanup", %turret);
									GameBase::setTeam(%turret,GameBase::getTeam(%player));
									GameBase::setPosition(%turret,$los::position);
									GameBase::setRotation(%turret,%rot);
									Gamebase::setMapName(%turret,"Backup Generator - " @ Client::getName(%client));
									Client::sendMessage(%client,0,"Backup Generator deployed");
									playSound(SoundPickupBackpack,$los::position);
									$TeamItemCount[GameBase::getTeam(%player) @ "iBackupGenerator"]++;
									echo("MSG: ",%client," deployed a Backup Generator");
									return true;

									// get the set of the closest generator,
									%genSet = getGroup(%closestSoFar);

									// add this generator to it.
									addToSet(%genSet, %turret);

									// Add to our Cleanup table
									for (%index = 0; $SpecialistCleanup[%index] != ""; %index++) {
									}
									// echo("index: " @%index);
									$SpecialistCleanup[%index] = %turret;

									// echo("Object: " @%turret);
								} else Client::sendMessage(%client,0,"No generator in range.");


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

StaticShapeData BackupGenerator
{
	description = "Backup Generator";
	shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.6;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

function BackupGenerator::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Backup Generator");

	GameBase::generatePower(%this, true);
}

function BackupGenerator::onDestroyed(%this) 
{
	Generator::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iBackupGenerator"]--;
}

