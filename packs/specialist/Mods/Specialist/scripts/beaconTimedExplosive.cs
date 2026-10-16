$InvList[TimedExplosiveGrenade] = 1;
$RemoteInvList[TimedExplosiveGrenade] = 1;
$AutoUse[TimedExplosiveGrenade] = 0;
$CoreType[TimedExplosiveGrenade] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = TimedExplosiveGrenade;

$SellAmmo[TimedExplosiveGrenade] = 8;

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, TimedExplosiveGrenade] = 0;
$ItemMax[reconfemalearmor, TimedExplosiveGrenade] = 0;
$ItemMax[espionagearmor, TimedExplosiveGrenade] = 0;
$ItemMax[espionagefemalearmor, TimedExplosiveGrenade] = 0;
$ItemMax[engineerarmor, TimedExplosiveGrenade] = 0;
$ItemMax[engineerfemalearmor, TimedExplosiveGrenade] = 0;
$ItemMax[infantryarmor, TimedExplosiveGrenade] = 0;
$ItemMax[infantryfemalearmor, TimedExplosiveGrenade] = 0;
$ItemMax[falloutarmor, TimedExplosiveGrenade] = 0;
$ItemMax[falloutfemalearmor, TimedExplosiveGrenade] = 0;
$ItemMax[demolitionsarmor, TimedExplosiveGrenade] = 8;
$ItemMax[assaultarmor, TimedExplosiveGrenade] = 0;
$ItemMax[artilleryarmor, TimedExplosiveGrenade] = 0;
$ItemMax[commanderarmor, TimedExplosiveGrenade] = 0;

SoundData SoundExplosiveSet
{
   wavFileName = "Mine_act.wav";
   profile = Profile3dNear;
};

ItemData TimedExplosiveGrenade
{
	description = "* Timed Explosive Core";
	shapeFile = "sensor_small";
	heading = "iBeacons";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function TimedExplosiveGrenade::onUse(%player, %item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a beacon to put this core into
			if (Player::incItemCount(%player, beacon, 0) > 0) {
				Player::decItemCount(%player, Beacon);
				Player::decItemCount(%player,%item);
				%client = Player::getClient(%player);

				%obj = newObject("","Mine","mTimedExplosiveGrenade");
 		 	 	addToSet("MissionCleanup", %obj);
				GameBase::throw(%obj, %player, 3, false);

				// Set timer to ten seconds
				%time = 10;

				// %time = 10 * %client.throwStrength;
				// if (%time < 2) %time = 2;
				// else if (%time < 4) %time = 5;
				// else if (%time < 6) %time = 10;
				// else if (%time < 8) %time = 15;
				// else %time = 30;

				mTimedExplosiveGrenade::setTimer(%obj, %time);
				Client::sendMessage(%client, 1, "Explosive set for " @%time@ " seconds.");

				// play sound
				GameBase::playSound(%obj, SoundExplosiveSet, 3);

				%player.throwTime = getSimTime() + 0.5;
			}
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
			}
		}
	}
}


MineData mTimedExplosiveGrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "TimedExplosive";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 3.0;
	damageValue = 2.5;
	damageType = $TimedExplosiveDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function mTimedExplosiveGrenade::onAdd(%this) {
}

function mTimedExplosiveGrenade::setTimer(%this, %time) {
	schedule("Mine::Detonate(" @ %this @ ");", %time, %this);
}

function mTimedExplosiveGrenade::onCollision(%this, %obj) {

	if(getObjectType(%obj) != "Player") {
		return;
	}

	if(Player::isDead(%obj)) {
		return;
	}

	%client = Player::getClient(%obj);
//	%playerTeam = GameBase::getTeam(%obj);
//	%thisTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);

	// if the object is flying through the air, let's not allow defuses or detonations
	if (!GameBase::isAtRest(%this)) return;

	// If an engineer touches the explosive
	if (%armor == "engineerarmor" || %armor == "engineerfemalearmor" || %armor == "demolitionsarmor"  || %armor == "commanderarmor") {
		// set success rate
		if (%armor == "demolitionsarmor") {
			%successrate = 9.5;
		}
		else {
			%successrate = 7.5;
		}

		// attempt to disarm the explosive
		%rnd = floor(getRandom() * 10);
		if(%rnd < %successrate) {
			playSound(SoundPickupItem,GameBase::getPosition(%this));

			// Success will remove the explosive
			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");

			// If a demolitions specialist
			if (%armor == "demolitionsarmor") {

				// Give the player another explosive and beacon
				Item::giveItem(%obj, TimedExplosiveGrenade, 1);
				Item::giveItem(%obj, Beacon, 1);
			}
		}
		else {
			// Failure will detonate the explosive
			Client::sendMessage(%client, 1, "Disarm attempt failed!");
			Mine::Detonate(%this);
			return;
		}
	}

	// other armors may detonate the explosive
	else {
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) {
			// detonate the explosive
			Mine::Detonate(%this);
			return;
		}
	}
}
