$InvList[AcidGrenade] = 1;
$RemoteInvList[AcidGrenade] = 1;
$AutoUse[AcidGrenade] = 0;
$CoreType[AcidGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = AcidGrenade;

$SellAmmo[AcidGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, AcidGrenade] = 0;
$ItemMax[reconfemalearmor, AcidGrenade] = 0;
$ItemMax[espionagearmor, AcidGrenade] = 0;
$ItemMax[espionagefemalearmor, AcidGrenade] = 0;
$ItemMax[engineerarmor, AcidGrenade] = 0;
$ItemMax[engineerfemalearmor, AcidGrenade] = 0;
$ItemMax[infantryarmor, AcidGrenade] = 0;
$ItemMax[infantryfemalearmor, AcidGrenade] = 0;
$ItemMax[falloutarmor, AcidGrenade] = 6;
$ItemMax[falloutfemalearmor, AcidGrenade] = 6;
$ItemMax[demolitionsarmor, AcidGrenade] = 0;
$ItemMax[assaultarmor, AcidGrenade] = 8;
$ItemMax[artilleryarmor, AcidGrenade] = 0;
$ItemMax[commanderarmor, AcidGrenade] = 0;

ItemData AcidGrenade
{
	description = "- Acid Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function AcidGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mAcidGrenade");
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

MineData mAcidGrenade
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
	explosionId = FlashExpLarge; // was grenadeExp
	explosionRadius = 10.0;
	damageValue = 0.05;
	damageType = $AcidDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function mAcidGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
