$InvList[iPulseSensor] = 1;
$RemoteInvList[iPulseSensor] = 1;
$AutoUse[iPulseSensor] = 0;
$Object2Item[DeployablePulseSensor] = iPulseSensor;
$CoreType[iPulseSensor] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = iPulseSensor;
$DeployedObject[DeployablePulseSensor] = true;

$SellAmmo[iPulseSensor] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, iPulseSensor] = 2;
$ItemMax[reconfemalearmor, iPulseSensor] = 2;
$ItemMax[espionagearmor, iPulseSensor] = 2;
$ItemMax[espionagefemalearmor, iPulseSensor] = 2;
$ItemMax[engineerarmor, iPulseSensor] = 3;
$ItemMax[engineerfemalearmor, iPulseSensor] = 3;
$ItemMax[infantryarmor, iPulseSensor] = 3;
$ItemMax[infantryfemalearmor, iPulseSensor] = 3;
$ItemMax[falloutarmor, iPulseSensor] = 0;
$ItemMax[falloutfemalearmor, iPulseSensor] = 0;
$ItemMax[demolitionsarmor, iPulseSensor] = 0;
$ItemMax[assaultarmor, iPulseSensor] = 0;
$ItemMax[artilleryarmor, iPulseSensor] = 3;
$ItemMax[commanderarmor, iPulseSensor] = 3;

$TeamItemMax[iPulseSensor] = 15;

ItemData iPulseSensor
{
   description = "* Pulse Sensor Core";
   shapeFile = "radar_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 125;
   className = "HandAmmo";
};

function iPulseSensor::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
			$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensor"]++;
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}


