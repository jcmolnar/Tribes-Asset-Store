$InvList[RadiationGrenade] = 1;
$RemoteInvList[RadiationGrenade] = 1;
$AutoUse[RadiationGrenade] = 0;
$CoreType[RadiationGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = RadiationGrenade;

$SellAmmo[RadiationGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, RadiationGrenade] = 0;
$ItemMax[reconfemalearmor, RadiationGrenade] = 0;
$ItemMax[espionagearmor, RadiationGrenade] = 0;
$ItemMax[espionagefemalearmor, RadiationGrenade] = 0;
$ItemMax[engineerarmor, RadiationGrenade] = 0;
$ItemMax[engineerfemalearmor, RadiationGrenade] = 0;
$ItemMax[infantryarmor, RadiationGrenade] = 0;
$ItemMax[infantryfemalearmor, RadiationGrenade] = 0;
$ItemMax[falloutarmor, RadiationGrenade] = 6;
$ItemMax[falloutfemalearmor, RadiationGrenade] = 6;
$ItemMax[demolitionsarmor, RadiationGrenade] = 0;
$ItemMax[assaultarmor, RadiationGrenade] = 0;
$ItemMax[artilleryarmor, RadiationGrenade] = 0;
$ItemMax[commanderarmor, RadiationGrenade] = 0;

ItemData RadiationGrenade
{
	description = "- Radiation Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 15;
	className = "HandAmmo";
};

function RadiationGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mRadiationGrenade");
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

ExplosionData RadiationGrenadeExp
{
   shapeName = "enex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 8.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 1.0, 0.0 };
   colors[1]  = { 0.0, 1.0, 0.0 };
   colors[2]  = { 0.0, 1.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };
};

MineData mRadiationGrenade { 
 	mass = 0.3;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.15;
 	friction = 1.0;
 	className = "Handgrenade";
 	description = "Handgrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = RadiationGrenadeExp;
 	explosionRadius = 10.0;
 	damageValue = 0.0;
 	damageType = $RadiationDamageType;
 	kickBackStrength = 1.0;
 	triggerRadius = 0.5;
 	maxDamage = 0.3;
};

function mRadiationGrenade::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 3.0, %this);
}

function mRadiationGrenade::onDestroyed(%this) { 
	%success = mRadiationGrenade::deployShape(%this, 20, $RadiationDamageType, 3.0);

}

function mRadiationGrenade::deployShape(%object, %radius, %type, %dur) { 

	// Get the position of the grenade
	%canpos = getBoxCenter(%object);

	// %pos = GameBase::getPosition(%object);
	$RadiationPos[%object] = %canpos;

	$RadiationTTG[%object] = %dur;

	// And schedule radiation updates

	%damage = 0.05;
	%range = 20;
	%success = schedule("RadiationUpdate(" @ %object @ ", " @%damage@ ", " @%range@ ");", 0.5);

	return true;
}
