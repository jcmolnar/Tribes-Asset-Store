// This deployable will not allow any communications around it.

$InvList[CommSilencer] = 1;
$RemoteInvList[CommSilencer] = 1;
$AutoUse[CommSilencer] = 0;
$Object2Item[dCommSilencer] = CommSilencer;
$CoreType[CommSilencer] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = CommSilencer;

$DeployedObject[dCommSilencer] = true;

$SellAmmo[CommSilencer] = 1;

// This sets the range of the CommSilencer
$CommSilencer::Range = 40;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, CommSilencer] = 1;
$ItemMax[reconfemalearmor, CommSilencer] = 1;
$ItemMax[espionagearmor, CommSilencer] = 1;
$ItemMax[espionagefemalearmor, CommSilencer] = 1;
$ItemMax[engineerarmor, CommSilencer] = 1;
$ItemMax[engineerfemalearmor, CommSilencer] = 1;
$ItemMax[infantryarmor, CommSilencer] = 0;
$ItemMax[infantryfemalearmor, CommSilencer] = 0;
$ItemMax[falloutarmor, CommSilencer] = 0;
$ItemMax[falloutfemalearmor, CommSilencer] = 0;
$ItemMax[demolitionsarmor, CommSilencer] = 0;
$ItemMax[assaultarmor, CommSilencer] = 0;
$ItemMax[artilleryarmor, CommSilencer] = 0;
$ItemMax[commanderarmor, CommSilencer] = 0;

$TeamItemMax[CommSilencer] = 2;

ItemData CommSilencer
{
   description = "* Comm Silencer Core";
   shapeFile = "sensor_jammer";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 200;
   className = "HandAmmo";
};

function CommSilencer::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "CommSilencer"] < $TeamItemMax[%item]) {


			if (GameBase::getLOSInfo(%player, 3)) {
				// GetLOSInfo sets the following globals:
				// 	los::position
				// 	los::normal
				// 	los::object
				%obj = getObjectType($los::object);
				// echo("Object type: " @%obj);
				%name = GameBase::getDataName($los::object);

				if (%obj == "SimTerrain" || %obj == "InteriorShape") {

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
	
							%newobj = newObject("Comm Silencer","StaticShape","dCommSilencer", true);
					 	 	addToSet("MissionCleanup", %newobj);

							GameBase::setRotation(%newobj, %rot);
							GameBase::setPosition(%newobj, $los::position);
							Gamebase::setMapName(%newobj, "Comm Silencer");

							// Get Player's team
							%playerTeam = GameBase::getTeam(%player);

							// Set the team of this CommSilencer
							GameBase::setTeam(%newobj, %playerTeam);

							// Get next available index in CommSilencer table
							%index = dCommSilencer::getNextIndex(%playerTeam);

							// Add the targeted object to CommSilencer table
							$CommSilencer[%playerTeam @ %index] = %newobj;

							// Increment the count
							$TeamItemCount[%playerTeam @ "CommSilencer"]++;

							Client::sendMessage(GameBase::getOwnerClient(%player),0,"Comm Silencer deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",GameBase::getOwnerClient(%player)," deployed a Comm Silencer");
							return true;
						}
						else {
							Client::sendMessage(GameBase::getOwnerClient(%player),0,"Unable to deploy - Something is in the way");
						}
				}
				else {
					Client::sendMessage(GameBase::getOwnerClient(%player),0,"Can only deploy on terrain or buildings");
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

StaticShapeData dCommSilencer
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_jammer";
	maxDamage = 1.5;
	maxEnergy = 20;

	castLOS = false;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};


function dCommSilencer::onAdd(%this)
{
	schedule("dCommSilencer::deploy(" @ %this @ ");",1,%this);
}

function dCommSilencer::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
																						 
function dCommSilencer::onEnabled(%this)
{

}

function dCommSilencer::onDisabled(%this)
{

}

function dCommSilencer::onDestroyed(%this)
{

	// Get the index and team of this object in table
	%index = dCommSilencer::getIndex(%this);
	%team = GameBase::getTeam(%this);

	// Clear the tables
	$CommSilencer[%team @ %index] = "";

	StaticShape::onDestroyed(%this);

	// decrement count
	$TeamItemCount[GameBase::getTeam(%this) @ "CommSilencer"]--;
}

function dCommSilencer::initializeData() {
	// This function will clear all the data
	// for the Comm Silencer data arrays.  
	// By RCabrera for the Specialist mod, 2/23/00

	// For each team
	for (%team = 0; %team < 8; %team ++) {

		// Search through all indices
		for (%i = 0; %i < $TeamItemMax[CommSilencer]; %i ++) {

			// clear each slot
			$CommSilencer[%team @ %i] = "";
		}
	}
}

function dCommSilencer::getNextIndex(%team) {
	// This function will return the next available index
	// for the Comm Silencer data array.  If none are
	// available, it will return -1.
	// By RCabrera for the Specialist mod, 2/23/00

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[CommSilencer]; %i ++) {

		// if the this is an empty slot
		if ($CommSilencer[%team @ %i] == "") {
		
			// Then return that number
			return %i;
		}
	}
	// Otherwise, we could not find any empty slots, return -1
	return -1;
}

function dCommSilencer::getIndex(%object) {
	// This function will return the index for the given object
	// in the Comm Silencer data array.  If unfound 
	// it will return -1.
	// By RCabrera for the Specialist mod, 2/23/00

	// Get this object's team
	%team = GameBase::getTeam(%object);

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[CommSilencer]; %i ++) {

		// if the this is the object's slot
		if ($CommSilencer[%team @ %i] == %object) {
		
			// Then return this number
			return %i;
		}
	}
	// Otherwise, we could not find the requested object, return -1
	return -1;
}

function dCommSilencer::isPlayerSilenced(%clientId) {
	// This function will return true if the client's player
	// is within a comm silencer field.
	// By RCabrera for the Specialist mod, 2/25/00

	%playerPos = GameBase::getPosition(%clientId);

	// For each team
	for (%t = 0; %t < 8; %t ++) {

		// Search through all indices
		for (%i = 0; %i < $TeamItemMax[CommSilencer]; %i ++) {

			// If there is a comm silencer at this index
			if ($CommSilencer[%t @ %i] != "") {

				// Get the distance from the player to the silencer
				%thisPos = GameBase::getPosition($CommSilencer[%t @ %i]);
				%distance = Vector::getDistance(%playerPos, %thisPos);

				// if the silencer is within the range
				if (%distance < $CommSilencer::Range) {

					// and exit
					return true;
				}
			}
		}
	}

	return false;
}