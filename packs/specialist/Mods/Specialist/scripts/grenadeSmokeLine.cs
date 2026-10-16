$InvList[SmokeLineGrenade] = 1;
$RemoteInvList[SmokeLineGrenade] = 1;
$AutoUse[SmokeLineGrenade] = 0;
$CoreType[SmokeLineGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = SmokeLineGrenade;

$SellAmmo[SmokeLineGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, SmokeLineGrenade] = 5;
$ItemMax[reconfemalearmor, SmokeLineGrenade] = 5;
$ItemMax[espionagearmor, SmokeLineGrenade] = 5;
$ItemMax[espionagefemalearmor, SmokeLineGrenade] = 5;
$ItemMax[engineerarmor, SmokeLineGrenade] = 5;
$ItemMax[engineerfemalearmor, SmokeLineGrenade] = 5;
$ItemMax[infantryarmor, SmokeLineGrenade] = 6;
$ItemMax[infantryfemalearmor, SmokeLineGrenade] = 6;
$ItemMax[falloutarmor, SmokeLineGrenade] = 6;
$ItemMax[falloutfemalearmor, SmokeLineGrenade] = 6;
$ItemMax[demolitionsarmor, SmokeLineGrenade] = 12;
$ItemMax[assaultarmor, SmokeLineGrenade] = 8;
$ItemMax[artilleryarmor, SmokeLineGrenade] = 8;
$ItemMax[commanderarmor, SmokeLineGrenade] = 8;

ItemData SmokeLineGrenade
{
	description = "- Smokescreen Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function SmokeLineGrenade::onUse(%player, %item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {
				Player::decItemCount(%player, Grenade);
				Player::decItemCount(%player,%item);
				%client = Player::getClient(%player);

				// throw the smoke line
				// %velocity = %client.throwStrength * 10;
				// %velocity = "0 " @ %velocityY @ " 0";
				// SpecialistThrowSpread(%player, "Mine", "mSmokeLineGrenade", 5, %velocity, 4);

				for (%i = 1; %i < 10; %i += 2) {
					%obj = newObject("","Mine","mSmokeLineGrenade");
	 		 	 	addToSet("MissionCleanup", %obj);
					GameBase::throw(%obj, %player, (9 * %client.throwStrength) + %i, false);
				}
				%player.throwTime = getSimTime() + 0.5;
			}
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a grenade.");
			}
		}
	}
}

ExplosionData SmokeLineGrenadeExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 5.0;

   timeScale = 15.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

MineData mSmokeLineGrenade { 
 	mass = 0.3;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.15;
 	friction = 1.0;
 	className = "Handgrenade";
 	description = "Handgrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = SmokeLineGrenadeExp;
 	explosionRadius = 10;
 	damageValue = 0.001;
 	damageType = $BlindDamageType;
 	kickBackStrength = 0;
 	triggerRadius = 1.0;
 	maxDamage = 0.01;
};

function mSmokeLineGrenade::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 3.0, %this);
}

