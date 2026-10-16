// This is not original code.  Taken from some other mod.

ExplosionData nullExp { 
	shapeName = "fusionex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeScale = 0.1;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};


ExplosionData EMPPulseExp { 
	shapeName = "shockwave_large.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 30.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData EMPPulseExpSmall { 
	shapeName = "shockwave.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 10.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};


GrenadeData EMPGrenadeShell { 
	bulletShapeName = "mortar.dts";
	explosionTag = EMPPulseExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 1.0;
	elasticity = 0.45;
	damageClass = 1;
	damageValue = 0.04;
	damageType = $EMPDamageType;
	explosionRadius = 30;
	kickBackStrength = 0;
	maxLevelFlightDist = 275;
	totalTime = 30.0;
	liveTime = 0.5;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "fusionbolt.dts";
	soundId = SoundELFFire;
};


GrenadeData EMPShock { 
	bulletShapeName = "breath.dts";
	explosionTag = nullExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.1;
	damageClass = 0;
	damageValue = 0.01;
	damageType = $NullDamageType;
	explosionRadius = 1;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 0.05;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "breath.dts";
};


function ixStartEMP(%clientId, %player, %shooter, %type) { 

	// If player is wearing a shield pack and the shield is active
	if(Player::getMountedItem(%player,$BackpackSlot) != "StealthShieldPack" && %player.shieldStrength > 0) {

		// do nothing
		return;
	}

	// Get the player's weapon
	%weapon = Player::getMountedItem(%player,$WeaponSlot);

	// If weapon uses energy for ammo
	if(($WeaponAmmo[%weapon] == "")) {

		// They lose their grip on it, and it happens to fall in their weapon pack or wherever weapons are kept
		Player::unmountItem(%player,$WeaponSlot);
	}

	// If player was hit by someone else's EMP
	if(%clientId != %shooter) {
		
		// Tell them they've been EMPd
		Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " hit you with an EMP!");
	}
	else {
		// Tell them they hit themselves (idiots)
		Client::sendMessage(%clientId,1,"You hit yourself with an EMP!");
	}

	// Play the appropriate sound
	playSound(SoundEMPDrain,GameBase::getPosition(%player));

	// If their TTG is 0
	if($empTime[%clientId] == 0) { 

		// Set their recharge rate to 0
		GameBase::setRechargeRate(%player,0);

		// Set their energy level to 0
		GameBase::setEnergy(%player,0);

		// Get the player's armor
		%armor = Player::getArmor(%clientId);

		// If the player is wearing certain armors
		if (%armor == "darmor" || %armor == "harmor" ) { 

			// Set their TTG to 7 seconds
			$empTime[%clientId] = 7;
		}

		// If they're wearing certain other armors
		else if (%armor == "dmarmor" || %armor == "dmfemale") { 

			// If a certain option is set
			if($HaVoC::DMFullWeapons == FALSE) { 

				// Set their TTG to 4.5 seconds
				$empTime[%clientId] = 4.5;
			}
			else { 

				// Set their TTG to 7 seconds
				$empTime[%clientId] = 7;
			}
		}
		else {  

			// Set their TTG to 9 seconds
			$empTime[%clientId] = 9;
		}

		// Check their current EMP status
		checkPlayerEMP(%clientId, %player);
	}
	// Otherwise, we set the TTG to 9 seconds
	else $empTime[%clientId] = 9;
}


function checkPlayerEMP(%clientId, %player) { 

	// If player still has TTG
	if($empTime[%clientId] > 0) { 

		// Get the player's velocity
		%vel = Item::getVelocity(%player);

		// Create a transform based on player's position
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);

		// Create the EMPShock projectile
		Projectile::spawnProjectile("EMPShock",%trans,%player,%vel,%player);

		// Decrement their TTG
		$empTime[%clientId] -= 1;

		// Schedule this function again in 1 second
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",1,%player);
	}
	// If TTG is up
	else { 
		// Tell them what's happening
		Client::sendMessage(%clientId,1,"EMP Effects have dissipated.");

		// Restore their recharge rate to 8
		GameBase::setRechargeRate(%player,8);
	}
}
