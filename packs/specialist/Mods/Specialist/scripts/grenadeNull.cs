$CoreType[NullGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = NullGrenade;

ExplosionData nullGrenadeExp
{
   shapeName = "breath.dts";
   soundId   = SoundLFootLSoft;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.001;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ItemData NullGrenade
{
	description = "Null Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function NullGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mNullGrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
			}
		}
	}
}

MineData mNullGrenade
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
	explosionId = nullGrenadeExp; 
	explosionRadius = 0.001;
	damageValue = 0.001;
	damageType = $NullDamageType;
	kickBackStrength = 0.001;
	triggerRadius = 0.001;
	maxDamage = 2;
};

function mNull::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("deleteObject(" @%this@ ");",2.0,%this);
}
