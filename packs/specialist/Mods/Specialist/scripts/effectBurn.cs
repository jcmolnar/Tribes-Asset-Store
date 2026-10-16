// Burn effect

SoundData SoundFlame
{
   wavFileName = "heavy_thrust.wav";
   profile = Profile3dMedium;
};

ExplosionData flameExp
{
   shapeName = "tumult_small.dts";
   soundId   = SoundFlame;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0.0, 0.0,  1.0 };
   colors[1]  = { 0.75, 0.75, 1.0 };
   colors[2]  = { 0.75, 0.75, 1.0 };
   radFactors = { 0.375, 0.9, 1.0 };
};

BulletData BurningFlame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = flameExp;

   damageClass        = 0;
   damageValue        = 0.01;
   damageType         = $FireDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 1.0;
   totalTime          = 0.5;
   liveTime           = 0.5;
   lightRange         = 6.0;
   lightColor         = { 1, 0.5, 0 };
   inheritedVelocityScale = 0.6;
   isVisible          = True;

   // soundId = SoundJetLight;
};


// Functions for burning players

function startBurn(%clientId, %player) { 
	if($burnTime[%clientId] < 1) { 
		Client::sendMessage(%clientId,1,"You've caught on fire!");
		Player::setDamageFlash(%player,0.75);
		$burnTime[%clientId] = 9;
		checkPlayerBurn(%clientId, %player);
	}
	else $burnTime[%clientId] = 7;
}

function checkPlayerBurn(%clientId, %player) { 
	if($burnTime[%clientId] > 0) { 
		$burnTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.06;

		// let's display a little flame effect too:
		%vel = "0 0 8";

		// Create a transform based on player's position
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);

		// Create the flame projectile
		Projectile::spawnProjectile("BurningFlame",%trans,%player,%vel,%player);

		if (!Player::isDead(%player)) { 
			GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.65);
			if (Player::isDead(%player)) { 
				messageall(0, Client::getName(%clientId) @ " was incinerated.");
				%clientId.scoreDeaths++;
				Game::refreshClientScore(%clientId);
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie);
				$burnTime[%clientId] = 0;
			}
		}
		else { 
			$burnTime[%clientId] = 0;
		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else { 
		Client::sendMessage(%clientId,1,"You stop burning.");
	}
}

// Functions for burning objects

function startObjectBurn(%object) { 
//	echo("Starting burn for object: " @%object);
	if($burnTime[%object] < 1) { 
		$burnTime[%object] = 9;
		checkObjectBurn(%object);
	}
	else $burnTime[%object] = 7;
}

function checkObjectBurn(%object) { 
	// echo("Checking burn for object: "@%object);
	if($burnTime[%object] > 0) { 
		$burnTime[%object] -= 2;
		%curdam = GameBase::getDamageLevel(%object);
//		echo("Current damage: " @%curdam);
		%drrate = %curdam + 0.05;

		// let's display a little flame effect too:
		%vel = "0 0 8";

		// Create a transform based on object's position
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%object);

		// Create the burn projectile
		%success = Projectile::spawnProjectile("BurningFlame",%trans, %object, %vel, %object);
		
		if (GameBase::getDamageState(%object) != "Destroyed") { 

			GameBase::setDamageLevel(%object, %drrate);

			if (GameBase::getDamageState(%object) == "Destroyed") { 
				$burnTime[%object] = 0;
			}
		}
		else { 
			$burnTime[%object] = 0;
		}
		%success = schedule("checkObjectBurn(" @ %object @ ");", 2, %object);
	}
}
