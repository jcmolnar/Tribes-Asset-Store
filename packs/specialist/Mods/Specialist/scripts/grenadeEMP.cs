$InvList[EMPGrenade] = 1;
$RemoteInvList[EMPGrenade] = 1;
$AutoUse[EMPGrenade] = 0;
$CoreType[EMPGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = EMPGrenade;

$SellAmmo[EMPGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, EMPGrenade] = 5;
$ItemMax[reconfemalearmor, EMPGrenade] = 5;
$ItemMax[espionagearmor, EMPGrenade] = 5;
$ItemMax[espionagefemalearmor, EMPGrenade] = 5;
$ItemMax[engineerarmor, EMPGrenade] = 5;
$ItemMax[engineerfemalearmor, EMPGrenade] = 5;
$ItemMax[infantryarmor, EMPGrenade] = 6;
$ItemMax[infantryfemalearmor, EMPGrenade] = 6;
$ItemMax[falloutarmor, EMPGrenade] = 6;
$ItemMax[falloutfemalearmor, EMPGrenade] = 6;
$ItemMax[demolitionsarmor, EMPGrenade] = 12;
$ItemMax[assaultarmor, EMPGrenade] = 8;
$ItemMax[artilleryarmor, EMPGrenade] = 8;
$ItemMax[commanderarmor, EMPGrenade] = 8;

ItemData EMPGrenade
{
	description = "- EMP Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function EMPGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				%newtotal = Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mEMPGrenade");
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

MineData mEMPGrenade
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
	explosionId = EMPPulseExpSmall; // was grenadeExp
	explosionRadius = 10.0;
	damageValue = 0.02;
	damageType = $EMPDamageType;
	kickBackStrength = -100.0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function mEMPGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
