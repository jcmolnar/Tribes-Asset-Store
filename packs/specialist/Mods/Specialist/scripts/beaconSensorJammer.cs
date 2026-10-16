$InvList[SensorJammer] = 1;
$RemoteInvList[SensorJammer] = 1;
$AutoUse[SensorJammer] = 0;
$Object2Item[DeployableSensorJammer] = SensorJammer;
$CoreType[SensorJammer] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = SensorJammer;
$DeployedObject[DeployableSensorJammer] = true;

$SellAmmo[SensorJammer] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, SensorJammer] = 2;
$ItemMax[reconfemalearmor, SensorJammer] = 2;
$ItemMax[espionagearmor, SensorJammer] = 3;
$ItemMax[espionagefemalearmor, SensorJammer] = 3;
$ItemMax[engineerarmor, SensorJammer] = 3;
$ItemMax[engineerfemalearmor, SensorJammer] = 3;
$ItemMax[infantryarmor, SensorJammer] = 3;
$ItemMax[infantryfemalearmor, SensorJammer] = 3;
$ItemMax[falloutarmor, SensorJammer] = 3;
$ItemMax[falloutfemalearmor, SensorJammer] = 3;
$ItemMax[demolitionsarmor, SensorJammer] = 3;
$ItemMax[assaultarmor, SensorJammer] = 3;
$ItemMax[artilleryarmor, SensorJammer] = 3;
$ItemMax[commanderarmor, SensorJammer] = 3;

$TeamItemMax[SensorJammer] = 8;

ItemData SensorJammer
{
   description = "* Sensor Jammer Core";
   shapeFile = "Camera";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 200;
   className = "HandAmmo";
};

function SensorJammer::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
			$TeamItemCount[GameBase::getTeam(%player) @ "SensorJammer"]++;
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}


