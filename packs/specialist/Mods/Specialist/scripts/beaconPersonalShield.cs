// When this ability beacon is used, it is as if the player
// is wearing a shield pack.

$InvList[PersonalShield] = 1;
$RemoteInvList[PersonalShield] = 1;
$AutoUse[PersonalShield] = 0;
$CoreType[PersonalShield] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = PersonalShield;

$SellAmmo[PersonalShield] = 1;

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, PersonalShield] = 0;
$ItemMax[reconfemalearmor, PersonalShield] = 0;
$ItemMax[espionagearmor, PersonalShield] = 0;
$ItemMax[espionagefemalearmor, PersonalShield] = 0;
$ItemMax[engineerarmor, PersonalShield] = 2;
$ItemMax[engineerfemalearmor, PersonalShield] = 2;
$ItemMax[infantryarmor, PersonalShield] = 2;
$ItemMax[infantryfemalearmor, PersonalShield] = 2;
$ItemMax[falloutarmor, PersonalShield] = 0;
$ItemMax[falloutfemalearmor, PersonalShield] = 0;
$ItemMax[demolitionsarmor, PersonalShield] = 0;
$ItemMax[assaultarmor, PersonalShield] = 3;
$ItemMax[artilleryarmor, PersonalShield] = 3;
$ItemMax[commanderarmor, PersonalShield] = 3;

ItemData PersonalShield
{
   description = "* Personal Shield Core";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 60;
   className = "HandAmmo";
};

function PersonalShield::onUse(%player, %item) {

	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		if (!%player.personalShieldActivated) {
			Player::decItemCount(%player, Beacon);
			Player::decItemCount(%player,%item);
		
			ActivatePersonalShield(%player);
		}
		else {
			Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Personal Shield already activated.");
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

