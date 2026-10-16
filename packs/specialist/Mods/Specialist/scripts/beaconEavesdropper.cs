// This device will intercept enemy communications if they are in range.

$InvList[Eavesdropper] = 1;
$RemoteInvList[Eavesdropper] = 1;
$AutoUse[Eavesdropper] = 0;
$Object2Item[dEavesdropper] = Eavesdropper;
$CoreType[Eavesdropper] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = Eavesdropper;
$DeployedObject[dEavesdropper] = true;

$SellAmmo[Eavesdropper] = 1;

// This sets the range of the Eavesdropper
$Eavesdropper::Range = 40;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, Eavesdropper] = 1;
$ItemMax[reconfemalearmor, Eavesdropper] = 1;
$ItemMax[espionagearmor, Eavesdropper] = 1;
$ItemMax[espionagefemalearmor, Eavesdropper] = 1;
$ItemMax[engineerarmor, Eavesdropper] = 1;
$ItemMax[engineerfemalearmor, Eavesdropper] = 1;
$ItemMax[infantryarmor, Eavesdropper] = 0;
$ItemMax[infantryfemalearmor, Eavesdropper] = 0;
$ItemMax[falloutarmor, Eavesdropper] = 0;
$ItemMax[falloutfemalearmor, Eavesdropper] = 0;
$ItemMax[demolitionsarmor, Eavesdropper] = 0;
$ItemMax[assaultarmor, Eavesdropper] = 0;
$ItemMax[artilleryarmor, Eavesdropper] = 0;
$ItemMax[commanderarmor, Eavesdropper] = 0;

$TeamItemMax[Eavesdropper] = 2;

ItemData Eavesdropper
{
   description = "* Eavesdropper Core";
   shapeFile = "radar_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 125;
   className = "HandAmmo";
};

function Eavesdropper::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "Eavesdropper"] < $TeamItemMax[%item]) {


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
	
							%newobj = newObject("Eavesdropper","StaticShape","dEavesdropper", true);
					 	 	addToSet("MissionCleanup", %newobj);

							GameBase::setRotation(%newobj, %rot);
							GameBase::setPosition(%newobj, $los::position);
							Gamebase::setMapName(%newobj, "Eavesdropper");

							// Get Player's team
							%playerTeam = GameBase::getTeam(%player);

							// Set the team of this Eavesdropper
							GameBase::setTeam(%newobj, %playerTeam);

							// Get next available index in Eavesdropper table
							%index = dEavesdropper::getNextIndex(%playerTeam);

							// Add the targeted object to Eavesdropper table
							$Eavesdropper[%playerTeam @ %index] = %newobj;

							// Increment the count
							$TeamItemCount[%playerTeam @ "Eavesdropper"]++;

							Client::sendMessage(GameBase::getOwnerClient(%player),0,"Eavesdropper deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",GameBase::getOwnerClient(%player)," deployed an Eavesdropper");
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

StaticShapeData dEavesdropper
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "radar_small";
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

function dEavesdropper::onAdd(%this)
{
	schedule("dEavesdropper::deploy(" @ %this @ ");",1,%this);
}

function dEavesdropper::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
																						 
function dEavesdropper::onEnabled(%this)
{

}

function dEavesdropper::onDisabled(%this)
{

}

function dEavesdropper::onDestroyed(%this)
{

	// Get the index and team of this object in table
	%index = dEavesdropper::getIndex(%this);
	%team = GameBase::getTeam(%this);

	// Clear the tables
	$Eavesdropper[%team @ %index] = -1;

	StaticShape::onDestroyed(%this);

	// decrement count
	$TeamItemCount[GameBase::getTeam(%this) @ "Eavesdropper"]--;
}

function dEavesdropper::initializeData() {
	// This function will clear all the data
	// for the Eavesdropper data arrays.  
	// By RCabrera for the Specialist mod, 2/23/00

	// For each team
	for (%team = 0; %team < 8; %team ++) {

		// Search through all indices
		for (%i = 0; %i < $TeamItemMax[Eavesdropper]; %i ++) {

			// clear each slot
			$Eavesdropper[%team @ %i] = -1;
		}
	}
}

function dEavesdropper::getNextIndex(%team) {
	// This function will return the next available index
	// for the Eavesdropper data array.  If none are
	// available, it will return -1.
	// By RCabrera for the Specialist mod, 2/23/00

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[Eavesdropper]; %i ++) {

		// if the this is an empty slot
		if ($Eavesdropper[%team @ %i] == -1) {
		
			// Then return that number
			return %i;
		}
	}
	// Otherwise, we could not find any empty slots, return -1
	return -1;
}

function dEavesdropper::getIndex(%object) {
	// This function will return the index for the given object
	// in the Eavesdropper data array.  If unfound 
	// it will return -1.
	// By RCabrera for the Specialist mod, 2/23/00

	// Get this object's team
	%team = GameBase::getTeam(%object);

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[Eavesdropper]; %i ++) {

		// if the this is the object's slot
		if ($Eavesdropper[%team @ %i] == %object) {
		
			// Then return this number
			return %i;
		}
	}
	// Otherwise, we could not find the requested object, return -1
	return -1;
}

function dEavesdropper::isPlayerEavesdroppable(%clientId) {
	// This function will check to see if the player is 
	// within an eavesdropping field, and return 
	// the eavesdropping team if so.  If not, returns -99.
	// By RCabrera for the Specialist mod, 2/25/00
	
	// echo("Checking for eavesdroppers...");

	// For each team
	for (%t = 0; %t < 8; %t ++) {

		// If this is the player's team, we skip it
		if (GameBase::getTeam(%clientId) == %t) 
			%t++;

		// Search through all indices
		for (%i = 0; %i < $TeamItemMax[Eavesdropper]; %i ++) {

			// If there is an Eavesdropper at this index
			if ($Eavesdropper[%t @ %i] > -1) {

				// echo("Found eavesdropper!");
				// Get the distance from the player to the Eavesdropper

				%thisPos = GameBase::getPosition($Eavesdropper[%t @ %i]);
				%playerPos = GameBase::getPosition(%clientId);
				%distance = Vector::getDistance(%playerPos, %thisPos);

				// if the Eavesdropper is within the range
				if (%distance < $Eavesdropper::Range) {
					// echo("Eavesdropper in range!  Team " @%t);
					return %t;
				}
			}
		}
	}

	return -99;
}