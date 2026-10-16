// Acid effect

ExplosionData AcidBurnExp { 
	shapeName = "mortartrail.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.0;
	timeScale = 0.1;
	colors[0] = { 0.0, 0.5, 0.0 };
	colors[1] = { 0.0, 0.9, 0.0 };
	colors[2] = { 0.0, 1.0, 0.0 };
	radFactors = { 0.0, 1.0, 0.0 };
};

SoundData SoundAcidBurn
{
   wavFileName = "thrust.wav";
   profile = Profile3dMedium;
};


BulletData AcidBurn
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = AcidBurnExp;

   damageClass        = 0;
   damageValue        = 0.01;
   damageType         = $AcidDamageType;
   explosionRadius    = 0.1;

   muzzleVelocity     = 5.0;
   totalTime          = 0.5;
   liveTime           = 0.5;
   lightRange         = 2.0;
   lightColor         = { 0, 1.0, 0 };
   inheritedVelocityScale = 0.6;
   isVisible          = True;

   soundId = SoundAcidBurn;
};


// Functions for acid burning players

function startAcidBurn(%clientId, %player) { 
	if($acidBurnTime[%clientId] < 1) { 
		Client::sendMessage(%clientId,1,"Acid is burning into your armor!");
		Player::setDamageFlash(%player,0.5);
		$acidBurnTime[%clientId] = 9;
		checkPlayerAcidBurn(%clientId, %player);
	}
	else $acidBurnTime[%clientId] = 7;
}

function checkPlayerAcidBurn(%clientId, %player) { 
	if($acidBurnTime[%clientId] > 0) { 
		$acidBurnTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.07;

		// let's display a little acid effect too:
		// Get the player's velocity
		%vel = Item::getVelocity(%player);

		// Create a transform based on player's position
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);

		// Create the acid burn projectile
		Projectile::spawnProjectile("AcidBurn", %trans, %player, %vel, %player);

		if (!Player::isDead(%player)) { 
			GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player, 0.4);
			if (Player::isDead(%player)) { 

				// print death message
				if(!String::ICompare(Client::getGender(%clientId), "Male")) {
					%playerGender = "him";
				}
				else {
					%playerGender = "her";
				}
				%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
				%victimName = Client::getName(%clientId);
				%obitMsg = sprintf($deathMsg[$AcidDamageType, %ridx], %victimName, %playerGender);
				messageAll(0, %obitMsg, $DeathMessageMask);
				// messageall(0, Client::getName(%clientId) @ " melted into a puddle.");

				%clientId.scoreDeaths++;
				Game::refreshClientScore(%clientId);
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie);
				$acidBurnTime[%clientId] = 0;
			}
		}
		else { 
			$acidBurnTime[%clientId] = 0;
		}
		schedule("checkPlayerAcidBurn(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else { 
		Client::sendMessage(%clientId,1,"The acid wears off.");
	}
}

// Functions for acid burning objects

function startObjectAcidBurn(%object) { 
	if($acidBurnTime[%object] < 1) { 
		$acidBurnTime[%object] = 15;
		checkObjectAcidBurn(%object);
	}
	else $acidBurnTime[%object] = 13;
}

function checkObjectAcidBurn(%object) { 
	if($acidBurnTime[%object] > 0) { 
		$acidBurnTime[%object] -= 2;
		%curdam = GameBase::getDamageLevel(%object);

		%drrate = %curdam + 0.08;

		// let's display a little acid effect too:
		// Get the object's velocity
		%vel = Item::getVelocity(%object);

		// Create a transform based on object's position
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%object);

		// Create the acid projectile
		%success = Projectile::spawnProjectile("AcidBurn",%trans, %object, %vel, %object);

		
		if (GameBase::getDamageState(%object) != "Destroyed") { 


			GameBase::setDamageLevel(%object, %drrate);

			if (GameBase::getDamageState(%object) == "Destroyed") { 

				$acidBurnTime[%object] = 0;
			}
		}
		else { 

			$acidBurnTime[%object] = 0;
		}
		%success = schedule("checkObjectAcidBurn(" @ %object @ ");", 2, %object);

	}
}
