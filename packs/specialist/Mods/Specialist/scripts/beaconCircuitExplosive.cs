// This deployable deploys on stations and turrets only.
// It is an explosive that detonates when the station or turret activates.

$InvList[CircuitExplosive] = 1;
$RemoteInvList[CircuitExplosive] = 1;
$AutoUse[CircuitExplosive] = 0;
$CoreType[CircuitExplosive] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = CircuitExplosive;

$SellAmmo[CircuitExplosive] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, CircuitExplosive] = 0;
$ItemMax[reconfemalearmor, CircuitExplosive] = 0;
$ItemMax[espionagearmor, CircuitExplosive] = 3;
$ItemMax[espionagefemalearmor, CircuitExplosive] = 3;
$ItemMax[engineerarmor, CircuitExplosive] = 3;
$ItemMax[engineerfemalearmor, CircuitExplosive] = 3;
$ItemMax[infantryarmor, CircuitExplosive] = 0;
$ItemMax[infantryfemalearmor, CircuitExplosive] = 0;
$ItemMax[falloutarmor, CircuitExplosive] = 0;
$ItemMax[falloutfemalearmor, CircuitExplosive] = 0;
$ItemMax[demolitionsarmor, CircuitExplosive] = 8;
$ItemMax[assaultarmor, CircuitExplosive] = 0;
$ItemMax[artilleryarmor, CircuitExplosive] = 0;
$ItemMax[commanderarmor, CircuitExplosive] = 0;

$TeamItemMax[CircuitExplosive] = 16;

ItemData CircuitExplosive
{
   description = "* Circuit Explosive Core";
   shapeFile = "force";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 50;
   className = "HandAmmo";
};

function CircuitExplosive::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// Then we check to see if there the maximum number is already deployed
		if ($TeamItemCount[GameBase::getTeam(%player) @ "CircuitExplosive"] < $TeamItemMax[%item]) {


			if (GameBase::getLOSInfo(%player, 3)) {
				// GetLOSInfo sets the following globals:
				// 	los::position
				// 	los::normal
				// 	los::object
				%obj = getObjectType($los::object);
				// echo("Object type: " @%obj);
				%name = GameBase::getDataName($los::object);

				if (%obj == "StaticShape" && %name.className == Station ) {

						// We try deploy it
						Player::decItemCount(%player, Beacon);
						Player::decItemCount(%player,%item);
	
						%newobj = newObject("","Mine","CircuitExplosiveMine");
				 	 	addToSet("MissionCleanup", %newobj);
						GameBase::throw(%newobj, %player, 3, false);

						// Get Player's team
						%playerTeam = GameBase::getTeam(%player);

						// Set the team of this explosive
						// GameBase::setTeam(%newobj, %playerTeam);

						// If there is already a circuit-sensing explosive on this object
						if ($CircuitExplosiveTarget[$los::object] != "") {

							// Detonate it
							Mine::detonate($CircuitExplosiveTarget[$los::object]);
						}

						// Add the targeted object to booby-trapped tables
						$CircuitExplosiveTarget[$los::object] = %newobj;
						$CircuitExplosiveSource[%newobj] = $los::object;

						// Increment the count
						$TeamItemCount[%playerTeam @ "CircuitExplosive"]++;

						Client::sendMessage(GameBase::getOwnerClient(%player),0,"Circuit-sensing explosive deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",GameBase::getOwnerClient(%player)," deployed a Circuit Explosive");
						return true;

				}
				else {
					Client::sendMessage(GameBase::getOwnerClient(%player),0,"Can only deploy on stations");
				}
			}

		}
		else {
			Client::sendMessage(GameBase::getOwnerClient(%player), 0, "Deployable Item limit reached for " @ %item.description @ "s");
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

MineData CircuitExplosiveMine
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Circuit Explosive";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 5.0;
	damageValue = 1.5;
	damageType = $RemoteBombDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.1;
	maxDamage = 0.25;
};
																						 
function CircuitExplosiveMine::onAdd(%this) {
}

function CircuitExplosiveMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "CircuitExplosive"]--;

	$CircuitExplosiveTarget[$CircuitExplosiveSource[%this]] = "";
	$CircuitExplosiveSource[%this] = "";
	
}

function CircuitExplosiveMine::onCollision(%this, %obj) {

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
			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");
		}
		else {
			// Failure will detonate the explosive
			Client::sendMessage(%client, 1, "Disarm attempt failed!");
			Mine::Detonate(%this);
			return;
		}
	}
	else {

		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) {
			// detonate the explosive
			Mine::Detonate(%this);
			return;
		}
	}

}
