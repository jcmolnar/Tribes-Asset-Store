$InvList[IncendiaryGrenade] = 1;
$RemoteInvList[IncendiaryGrenade] = 1;
$AutoUse[IncendiaryGrenade] = 0;
$CoreType[IncendiaryGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = IncendiaryGrenade;

$SellAmmo[IncendiaryGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, IncendiaryGrenade] = 0;
$ItemMax[reconfemalearmor, IncendiaryGrenade] = 0;
$ItemMax[espionagearmor, IncendiaryGrenade] = 0;
$ItemMax[espionagefemalearmor, IncendiaryGrenade] = 0;
$ItemMax[engineerarmor, IncendiaryGrenade] = 5;
$ItemMax[engineerfemalearmor, IncendiaryGrenade] = 5;
$ItemMax[infantryarmor, IncendiaryGrenade] = 6;
$ItemMax[infantryfemalearmor, IncendiaryGrenade] = 6;
$ItemMax[falloutarmor, IncendiaryGrenade] = 0;
$ItemMax[falloutfemalearmor, IncendiaryGrenade] = 0;
$ItemMax[demolitionsarmor, IncendiaryGrenade] = 12;
$ItemMax[assaultarmor, IncendiaryGrenade] = 8;
$ItemMax[artilleryarmor, IncendiaryGrenade] = 8;
$ItemMax[commanderarmor, IncendiaryGrenade] = 8;

ItemData IncendiaryGrenade
{
	description = "- Napalm Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

ExplosionData IncendiaryExp
{
   shapeName = "tumult_small.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};



function IncendiaryGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mIncendiaryGrenade");
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

MineData mIncendiaryGrenade
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
	explosionId = IncendiaryExp; // was grenadeExp
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $FireDamageType;
	kickBackStrength = 10.0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function mIncendiaryGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
