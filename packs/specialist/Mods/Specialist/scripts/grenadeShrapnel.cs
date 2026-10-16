$InvList[ShrapnelGrenade] = 1;
$RemoteInvList[ShrapnelGrenade] = 1;
$AutoUse[ShrapnelGrenade] = 0;
$CoreType[ShrapnelGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = ShrapnelGrenade;

$SellAmmo[ShrapnelGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, ShrapnelGrenade] = 5;
$ItemMax[reconfemalearmor, ShrapnelGrenade] = 5;
$ItemMax[espionagearmor, ShrapnelGrenade] = 5;
$ItemMax[espionagefemalearmor, ShrapnelGrenade] = 5;
$ItemMax[engineerarmor, ShrapnelGrenade] = 5;
$ItemMax[engineerfemalearmor, ShrapnelGrenade] = 5;
$ItemMax[infantryarmor, ShrapnelGrenade] = 6;
$ItemMax[infantryfemalearmor, ShrapnelGrenade] = 6;
$ItemMax[falloutarmor, ShrapnelGrenade] = 6;
$ItemMax[falloutfemalearmor, ShrapnelGrenade] = 6;
$ItemMax[demolitionsarmor, ShrapnelGrenade] = 12;
$ItemMax[assaultarmor, ShrapnelGrenade] = 8;
$ItemMax[artilleryarmor, ShrapnelGrenade] = 8;
$ItemMax[commanderarmor, ShrapnelGrenade] = 8;

ItemData ShrapnelGrenade
{
	description = "- Shrapnel Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function ShrapnelGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","Handgrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
			}
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a grenade.");
			}
		}
	}
}

