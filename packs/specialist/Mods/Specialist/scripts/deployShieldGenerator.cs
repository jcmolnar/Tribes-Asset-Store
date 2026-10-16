// The way this is set up, each team can only have ONE shield generator.
$ShieldGenerator::ShieldStrength = 0.2;

$InvList[iShieldGenerator] = 1;
$RemoteInvList[iShieldGenerator] = 1;
$Object2Item[ShieldGenerator] = iShieldGenerator;
$DeployedObject[ShieldGenerator] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iShieldGenerator] = 0;
$ItemMax[reconfemalearmor, iShieldGenerator] = 0;
$ItemMax[espionagearmor, iShieldGenerator] = 0;
$ItemMax[espionagefemalearmor, iShieldGenerator] = 0;
$ItemMax[engineerarmor, iShieldGenerator] = 1;
$ItemMax[engineerfemalearmor, iShieldGenerator] = 1;
$ItemMax[infantryarmor, iShieldGenerator] = 0;
$ItemMax[infantryfemalearmor, iShieldGenerator] = 0;
$ItemMax[falloutarmor, iShieldGenerator] = 0;
$ItemMax[falloutfemalearmor, iShieldGenerator] = 0;
$ItemMax[demolitionsarmor, iShieldGenerator] = 0;
$ItemMax[assaultarmor, iShieldGenerator] = 0;
$ItemMax[artilleryarmor, iShieldGenerator] = 0;
$ItemMax[commanderarmor, iShieldGenerator] = 0;

$TeamItemMax[iShieldGenerator] = 1;

ItemImageData ShieldGeneratorImage
{
  shapeFile = "generator_p";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData iShieldGenerator 
{
  description = "Shield Generator";
  shapeFile = "generator_p";
  className = "Backpack";
  heading = "dDeployables";
  imageType = ShieldGeneratorImage;
  shadowDetailMask = 4;
  mass = 20.0;
  elasticity = 0.2;
  price = 1800;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iShieldGenerator::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iShieldGenerator::onDeploy(%player, %item, %pos) {
	if (iShieldGenerator::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iShieldGenerator::deployShape(%player,%item)
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

								%rot = GameBase::getRotation(%player); 
								%turret = newObject("ShieldGenerator", "StaticShape", ShieldGenerator, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Shield Generator - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Shield Generator deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iShieldGenerator"]++;
								echo("MSG: ",%client," deployed a Shield Generator");
								
								$ShieldGenerator[GameBase::getTeam(%player)] = %turret;

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

StaticShapeData ShieldGenerator
{
	description = "Shield Generator";
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

function ShieldGenerator::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Shield Generator");
}

function ShieldGenerator::onDestroyed(%this) 
{
	$ShieldGenerator[GameBase::getTeam(%this)] = "";
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iShieldGenerator"]--;
}


function ShieldGenerator::Activate (%this, %value, %pos, %vec, %object) {
	// This function is called when this object is damaged.
	// It checks to see if there is a shield generator in range,
	// and if so, activates the shield.
	// Returns: modified damage value
	// By RCabrera, 3/8/00

	// If there is a Shield Generator for this team
	%team = GameBase::getTeam(%this);

	if ($ShieldGenerator[%team] != "") {

		// If this object is in range of a Shield Generator
		%objPos = GameBase::getPosition(%this);
		%shieldGenPos = GameBase::getPosition($ShieldGenerator[%team]);

		%distance = Vector::getDistance(%objPos, %shieldGenPos);


		if (%distance <= 40) {

			// Absorb some of the damage
			%value -= $ShieldGenerator::ShieldStrength;

			// Calculate a position around the object where the projectile hit
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);

			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;

			// Tweak for the pulse sensor
			%thisName = GameBase::getDataName(%this);
			if(%thisName == PulseSensor)
				%zOffset = (%pointZ-%centerPosZ) * 0.5;

			// Display the shield effect in the proper position
			GameBase::activateShield(%this, %sphereVec, %zOffset);

		}

	}

	return %value;
}
