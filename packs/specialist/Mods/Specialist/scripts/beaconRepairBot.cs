// This deployable deploys on any powered static shape or turret.
// It will repair the device when it gets damaged.
$RepairBotRepairRate = 0.1;

$InvList[RepairBot] = 1;
$RemoteInvList[RepairBot] = 1;
$AutoUse[RepairBot] = 0;
$Object2Item[dRepairBot] = RepairBot;
$CoreType[RepairBot] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = RepairBot;
$DeployedObject[dRepairBot] = true;

$SellAmmo[RepairBot] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, RepairBot] = 0;
$ItemMax[reconfemalearmor, RepairBot] = 0;
$ItemMax[espionagearmor, RepairBot] = 0;
$ItemMax[espionagefemalearmor, RepairBot] = 0;
$ItemMax[engineerarmor, RepairBot] = 3;
$ItemMax[engineerfemalearmor, RepairBot] = 3;
$ItemMax[infantryarmor, RepairBot] = 0;
$ItemMax[infantryfemalearmor, RepairBot] = 0;
$ItemMax[falloutarmor, RepairBot] = 0;
$ItemMax[falloutfemalearmor, RepairBot] = 0;
$ItemMax[demolitionsarmor, RepairBot] = 0;
$ItemMax[assaultarmor, RepairBot] = 0;
$ItemMax[artilleryarmor, RepairBot] = 0;
$ItemMax[commanderarmor, RepairBot] = 3;

$TeamItemMax[RepairBot] = 4;

ItemData RepairBot
{
   description = "* RepairBot Core";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 125;
   className = "HandAmmo";
};

function RepairBot::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "RepairBot"] < $TeamItemMax[%item]) {


			if (GameBase::getLOSInfo(%player, 3)) {
				// GetLOSInfo sets the following globals:
				// 	los::position
				// 	los::normal
				// 	los::object
				%obj = getObjectType($los::object);
				// echo("Object type: " @%obj);
				%name = GameBase::getDataName($los::object);

				if (%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor") {

					// If there is no RepairBot on this object
					if ($RepairBotTarget[$los::object] == "") {

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
	
							%newobj = newObject("RepairBot","StaticShape","dRepairBot", true);
					 	 	addToSet("MissionCleanup", %newobj);

							GameBase::setRotation(%newobj, %rot);
							GameBase::setPosition(%newobj, $los::position);
							Gamebase::setMapName(%newobj, "Repair Bot");

							// Get Player's team
							%playerTeam = GameBase::getTeam(%player);

							// Set the team of this RepairBot
							GameBase::setTeam(%newobj, %playerTeam);


							// Add the targeted object to RepairBot tables
							$RepairBotTarget[$los::object] = %newobj;
							$RepairBotSource[%newobj] = $los::object;

							// Increment the count
							$TeamItemCount[%playerTeam @ "RepairBot"]++;

							Client::sendMessage(GameBase::getOwnerClient(%player),0,"RepairBot deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",GameBase::getOwnerClient(%player)," deployed a RepairBot");
							return true;
						}
						else {
							Client::sendMessage(GameBase::getOwnerClient(%player),0,"Unable to deploy - Something is in the way");
						}
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

StaticShapeData dRepairBot
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
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
																						 
function dRepairBot::onEnabled(%this)
{

}

function dRepairBot::onDisabled(%this)
{

}

function dRepairBot::onDestroyed(%this)
{
	// Get the object we are attached to
	%object = $RepairBotSource[%this];

	// If RepairBot is activated
	if ($RepairBotActive[%this]) {

		// Reset it's auto repair rate
		%repairRate = GameBase::getAutoRepairRate(%object);

		// echo("RepairBot destroyed for object: " @%object@ " with repair rate: " @%repairRate);

		GameBase::setAutoRepairRate(%object, %repairRate - $RepairBotRepairRate);

		$RepairBotActive[%this] = "";
	}

	// Clear the tables
	$RepairBotTarget[$RepairBotSource[%this]] = "";
	$RepairBotSource[%this] = "";

	StaticShape::onDestroyed(%this);

	// decrement count
	$TeamItemCount[GameBase::getTeam(%this) @ "RepairBot"]--;
}

function dRepairBot::initiateRepairs(%object, %destroyed) {
	// This function is called when the object's damage state changes.
	// It checks for a resident repair bot, and initiates repairs, if any.
	// If the object is a deployable and was destroyed, 
	// then we should destroy the repairbot.
	// By RCabrera, 2/23/00

	// If this has a RepairBot
	if ($RepairBotTarget[%object] != "") {

		// If the object was a deployable
		%name = GameBase::getDataName(%object);

		if (%name == dChainTurret || %name == dELFTurret || %name == dEMPTurret || %name == dFlakTurret
			|| %name == dFlameTurret || %name == dIndoorTurret || %name == dIonTurret
			|| %name == dLaserTurret || %name == dMortarTurret || %name == dPlasmaTurret
			|| %name == dRocketTurret || %name == dSmokeTurret || %name == dTargetingTurret
			|| %name == CameraTurret || %name == SpyCameraTurret || %name == dCommSilencer
			|| %name == dEavesdropper || %name == dForceShield || %name == dRepairBot
			|| %name == DeployableSensorJammer || %name == BackupGenerator 
			|| %name == Barricade || %name == BlastCover || %name == BlastWall 
			|| %name == dFlagStand || %name == HoverPad || %name == dForceField
			|| %name == ShieldGenerator || %name == SmallForceField || %name == dTeleporter
			|| %name.className == DeployableStation || %name.className == DeployableSensor
			|| %name == mAlarm || %name == mLoudmouth) {
 			
			// And if the object was destroyed
			if (%destroyed) {

				// Destroy the repair bot
				// Get max damage of object
				%objectName = GameBase::getDataName($RepairBotTarget[%object]);

				// Set it's damage level to that
				GameBase::setDamageLevel($RepairBotTarget[%object], %objectName.maxDamage);
				
			}
		}

		// If this RepairBot is not already activated
		if ($RepairBotActive[$RepairBotTarget[%object]] == "") {
			
			// Set RepairBot to activated status
			$RepairBotActive[$RepairBotTarget[%object]] = "True";

			// Set AutoRepairRate to a higher rate
			%repairRate = GameBase::getAutoRepairRate(%object);
			GameBase::setAutoRepairRate(%object, %repairRate + $RepairBotRepairRate);
			schedule("dRepairBot::checkDamage(" @$RepairBotTarget[%object]@ ");", 3.0, $RepairBotTarget[%object]);
		}
	}

}

function dRepairBot::checkDamage(%this) {
	// This function will check the damage level of the object
	// attached to this Repair Bot, and will either
	// reschedule this function, or cancel the autorepair.
	// By RCabrera, 2/23/00

	// Get the object attached to
	%object = $RepairBotSource[%this];

	// Get current damage level of this object
	%damageLevel = GameBase::getDamageLevel(%object);

	// If fully repaired
	if (%damageLevel == 0) {

		// echo("Damage fully repaired on object: " @%object);

		// Set RepairBot to inactive Status
		$RepairBotActive[%this] = "";

		// Set AutoRepairRate back to what it was
		%repairRate = GameBase::getAutoRepairRate(%object);
		GameBase::setAutoRepairRate(%object, %repairRate - $RepairBotRepairRate);

	}
	// If not fully repaired
	else {

		// reschedule this function
		schedule("dRepairBot::checkDamage(" @%this@ ");", 3.0, %this);
	}
}
