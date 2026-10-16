$InvList[FlashGrenade] = 1;
$RemoteInvList[FlashGrenade] = 1;
$AutoUse[FlashGrenade] = 0;
$CoreType[FlashGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = FlashGrenade;

$SellAmmo[FlashGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, FlashGrenade] = 5;
$ItemMax[reconfemalearmor, FlashGrenade] = 5;
$ItemMax[espionagearmor, FlashGrenade] = 5;
$ItemMax[espionagefemalearmor, FlashGrenade] = 5;
$ItemMax[engineerarmor, FlashGrenade] = 5;
$ItemMax[engineerfemalearmor, FlashGrenade] = 5;
$ItemMax[infantryarmor, FlashGrenade] = 6;
$ItemMax[infantryfemalearmor, FlashGrenade] = 6;
$ItemMax[falloutarmor, FlashGrenade] = 6;
$ItemMax[falloutfemalearmor, FlashGrenade] = 6;
$ItemMax[demolitionsarmor, FlashGrenade] = 12;
$ItemMax[assaultarmor, FlashGrenade] = 8;
$ItemMax[artilleryarmor, FlashGrenade] = 8;
$ItemMax[commanderarmor, FlashGrenade] = 8;

ItemData FlashGrenade
{
	description = "- Flash Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function FlashGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mFlashGrenade");
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

MineData mFlashGrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = energyExp;
	explosionRadius = 30.0;
	damageValue = 0.001;
	damageType = $BlindDamageType;
	kickBackStrength = 0.001;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function mFlashGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
