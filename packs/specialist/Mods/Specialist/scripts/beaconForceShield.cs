// This deployable deploys on any powered static shape or turret.
// It will shield the device when it gets damaged.
$ForceShieldStrength = 0.15;	// strength of shield

$InvList[ForceShield] = 1;
$RemoteInvList[ForceShield] = 1;
$AutoUse[ForceShield] = 0;
$CoreType[ForceShield] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = ForceShield;
$DeployedObject[dForceShield] = true;

$SellAmmo[ForceShield] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, ForceShield] = 0;
$ItemMax[reconfemalearmor, ForceShield] = 0;
$ItemMax[espionagearmor, ForceShield] = 0;
$ItemMax[espionagefemalearmor, ForceShield] = 0;
$ItemMax[engineerarmor, ForceShield] = 3;
$ItemMax[engineerfemalearmor, ForceShield] = 3;
$ItemMax[infantryarmor, ForceShield] = 0;
$ItemMax[infantryfemalearmor, ForceShield] = 0;
$ItemMax[falloutarmor, ForceShield] = 0;
$ItemMax[falloutfemalearmor, ForceShield] = 0;
$ItemMax[demolitionsarmor, ForceShield] = 0;
$ItemMax[assaultarmor, ForceShield] = 0;
$ItemMax[artilleryarmor, ForceShield] = 0;
$ItemMax[commanderarmor, ForceShield] = 0;

$TeamItemMax[ForceShield] = 6;

ItemData ForceShield
{
   description = "* Force Shield Core";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 175;
   className = "HandAmmo";
};

function ForceShield::onUse(%player, %item) {

	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "ForceShield"] < $TeamItemMax[%item]) {

			if (GameBase::getLOSInfo(%player, 3)) {
				// GetLOSInfo sets the following globals:
				// 	los::position
				// 	los::normal
				// 	los::object
				%obj = getObjectType($los::object);
				// echo("Object type: " @%obj);
				%name = GameBase::getDataName($los::object);

				if (%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor") {

					// If there is no ForceShieldon this object
					if ($ForceShieldTarget[$los::object] == "") {

						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
							%rot = "0 0 0";
						}
						else {
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
								%rot = "3.14159 0 0";
							}
							else {
								%rot = Vector::getRotation($los::normal);
							}
						}

						// See if there's someone in the way
					  	%set=newObject("set",SimSet);
						%num=containerBoxFillSet(%set, $ItemObjectType | $SimPlayerObjectType, $los::position, 0.3, 0.3, 0.3, 1);
						deleteObject(%set);

						// If no one is in the way
						if(!%num) {

							// We try deploy it
							Player::decItemCount(%player, Beacon);
							Player::decItemCount(%player,%item);
	
							%newobj = newObject("ForceShield","StaticShape","dForceShield", true);
					 	 	addToSet("MissionCleanup", %newobj);

							GameBase::setRotation(%newobj, %rot);
							GameBase::setPosition(%newobj, $los::position);
							Gamebase::setMapName(%newobj, "Force Shield");

							// Get Player's team
							%playerTeam = GameBase::getTeam(%player);

							// Set the team of this ForceShield
							GameBase::setTeam(%newobj, %playerTeam);


							// Add the targeted object to ForceShield tables
							$ForceShieldTarget[$los::object] = %newobj;
							$ForceShieldSource[%newobj] = $los::object;

							// Increment the count
							$TeamItemCount[%playerTeam @ "ForceShield"]++;

							Client::sendMessage(GameBase::getOwnerClient(%player),0,"ForceShield deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",GameBase::getOwnerClient(%player)," deployed a ForceShield");
							return true;
						}
						else {
							Client::sendMessage(GameBase::getOwnerClient(%player),0,"Unable to deploy - Something is in the way");
						}
					}
					else {
						Client::sendMessage(GameBase::getOwnerClient(%player),0,"This object already has a ForceShield");
					}
				}
				else {
					Client::sendMessage(GameBase::getOwnerClient(%player),0,"Can only deploy on powered objects");
				}
			}

		}
		else {
			Client::sendMessage(GameBase::getOwnerClient(%player), 0, "Deployable Item limit reached for " @ %item.description @ "s");
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

StaticShapeData dForceShield
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 1.0;
	maxEnergy = 20;

	castLOS = false;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function dForceShield::onEnabled(%this)
{

}

function dForceShield::onDisabled(%this)
{

}

function dForceShield::onDestroyed(%this)
{
	// Clear the tables
	$ForceShieldTarget[$ForceShieldSource[%this]] = "";
	$ForceShieldSource[%this] = "";

	StaticShape::onDestroyed(%this);

	// decrement count
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceShield"]--;
}

// ==== Utility functions ===

function ForceShield::Activate (%this, %value, %pos, %vec, %object) {
	// This function is called when this object is damaged.
	// It checks to see if there is a force shield on the object,
	// and if so, activates the shield.
	// Returns: modified damage value
	// By RCabrera, 2/23/00

	// If this object has a ForceShield object attached to it
	if ($ForceShieldTarget[%this] != "") {

		// Absorb some of the damage
		%value -= $ForceShieldStrength;

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

	return %value;
}

function ForceShield::targetObjectDestroyed(%targetobject) {
	// This function is called from other onDestroyed()s.
	// It checks to see if there is a ForceShield on the passed object,
	// if so, it destroys them.

	// If this has a ForceShield, destroy it
	if ($ForceShieldTarget[%targetobject] != "") {
		
		// Get max damage of object
		%objectName = GameBase::getDataName($ForceShieldTarget[%targetobject]);

		// Set it's damage level to that
		GameBase::setDamageLevel($ForceShieldTarget[%targetobject], %objectName.maxDamage);
	}
}