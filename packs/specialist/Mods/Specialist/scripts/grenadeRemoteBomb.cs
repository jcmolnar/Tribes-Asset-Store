$InvList[RemoteBomb] = 1;
$RemoteInvList[RemoteBomb] = 1;
$AutoUse[RemoteBomb] = 0;
$CoreType[RemoteBomb] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = RemoteBomb;

$SellAmmo[RemoteBomb] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, RemoteBomb] = 0;
$ItemMax[reconfemalearmor, RemoteBomb] = 0;
$ItemMax[espionagearmor, RemoteBomb] = 0;
$ItemMax[espionagefemalearmor, RemoteBomb] = 0;
$ItemMax[engineerarmor, RemoteBomb] = 0;
$ItemMax[engineerfemalearmor, RemoteBomb] = 0;
$ItemMax[infantryarmor, RemoteBomb] = 0;
$ItemMax[infantryfemalearmor, RemoteBomb] = 0;
$ItemMax[falloutarmor, RemoteBomb] = 0;
$ItemMax[falloutfemalearmor, RemoteBomb] = 0;
$ItemMax[demolitionsarmor, RemoteBomb] = 12;
$ItemMax[assaultarmor, RemoteBomb] = 0;
$ItemMax[artilleryarmor, RemoteBomb] = 0;
$ItemMax[commanderarmor, RemoteBomb] = 0;

$TeamItemMax[RemoteBomb] = 16;

ItemData RemoteBomb
{
   description = "- Remote Bomb Core";
   shapeFile = "armorPatch";
   heading = "gGrenades";
   shadowDetailMask = 4;
   price = 50;
   className = "HandAmmo";
};

function RemoteBomb::onUse(%player, %item) {
	// First we should check to see if they have a grenade wrapper for this core
	if (Player::incItemCount(%player, Grenade, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "RemoteBomb"] < $TeamItemMax[%item]) {

			// We try deploy it
			Player::decItemCount(%player, Grenade);
			Player::decItemCount(%player,%item);
	
			%obj = newObject("","Mine","RemoteBombMine");
	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
			%player.throwTime = getSimTime() + 0.5;

			// Get Player's team
			%playerTeam = GameBase::getTeam(%player);

			// Set the team of this explosive
			GameBase::setTeam(%obj, %playerTeam);

			// Increment the count
			$TeamItemCount[%playerTeam @ "RemoteBomb"]++;
	
			// Find next available index in Detonation Frequency
			%nextindex = DetonationFrequency::getNextIndex(%playerTeam);
	
			// Add this bomb to this team's detonation frequency
			$DetonationFrequency [ %playerTeam @ %nextindex ] = %obj;

			// play sound
			GameBase::playSound(%obj, SoundExplosiveSet, 3);

		}
		else {
			Client::sendMessage(GameBase::getOwnerClient(%player), 0, "Deployable Item limit reached for " @ %item.description @ "s");
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a grenade.");
	}
}


MineData RemoteBombMine
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "RemoteBomb";
	shapeFile = "armorPatch";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 5.0;
	damageValue = 1.75;
	damageType = $RemoteBombDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};
																						 
function RemoteBombMine::onAdd(%this) {
}

function RemoteBombMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteBomb"]--;

	// Get object's detonation frequency index
	%objIndex = DetonationFrequency::getIndex(%this);

	// Remove this object from the detonation frequency
	if (%objIndex != -1)
		$DetonationFrequency[GameBase::getTeam(%this) @ %objIndex] = "";
	
}

function RemoteBombMine::onCollision(%this, %obj) {

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
	if (%armor == "engineerarmor" || %armor == "engineerfemalearmor" || %armor == "demolitionsarmor" || %armor == "commanderarmor") {
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
			// Success will remove the explosive
			playSound(SoundPickupItem,GameBase::getPosition(%this));

			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");

			// If a demolitions specialist
			if (%armor == "demolitionsarmor") {

				// Give the player another explosive
				Item::giveItem(%obj, RemoteBomb, 1);
				Item::giveItem(%obj, Grenade, 1);
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
