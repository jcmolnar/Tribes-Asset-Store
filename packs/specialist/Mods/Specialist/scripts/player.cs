$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	// remove cannon, if any
	Player::setItemCount(%this, TankArtilleryShell, 0);
	Player::setItemCount(%this, TankCannon, 0);

	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem is not called here.
			%item = newObject("","Item",%type,1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled(%this) {

	// remove vehicle cannons, if any
	Player::setItemCount(%this, TankArtilleryShell, 0);
	Player::setItemCount(%this, TankCannon, 0);
	
	// We must clear any effects that remain on the player
	%clientId = Player::getClient(%this);
	SpecialistInitClient(%clientId);

	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
		}
	}
	
	if(%cl != -1) {	
		if(%this.vehicle != "") {
			if(%this.driver != "") {
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
	}
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	// if in a shielded tank vehicle
	if ((GameBase::getDataName(%this.vehicle) == Tank || GameBase::getDataName(%this.vehicle) == APC || GameBase::getDataName(%this.vehicle) == Outrider)&& $TankShieldActivated[%this.vehicle] == true) {

		// Absorb some of the damage
		%value = GameBase::virtual(%this.vehicle, "onPassengerDamage", %this.vehicle, %value);

		// Calculate a position around the object where the projectile hit
		%centerPos = getBoxCenter(%this);
		%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
		%centerPosX = getWord(%centerPos,0);
		%centerPosY = getWord(%centerPos,1);
		%centerPosZ = getWord(%centerPos,2);

		%pointX = getWord(%pos,0);
		%pointY = getWord(%pos,1);
		%pointZ = getWord(%pos,2);

		%newVecX = %centerPosX - %pointX;
		%newVecY = %centerPosY - %pointY;
		%newVecZ = %centerPosZ - %pointZ;
		%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
		%zOffset = 0;

		// Display the shield effect in the proper position
		GameBase::activateShield(%this, %sphereVec, %zOffset);
	}

	if (Player::isExposed(%this)) {
		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;

		// echo("Shooter: " @%shooterclient);

		Player::applyImpulse(%this,%mom);

		// === Added by Base version 1.11 ===
      		if(%this.invulnerable)  {
			// no damage, just play a shield.
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			return;
		}
		// ================================

		// Check for Friendly Fire and set damage multiplier (documentation by RCabrera)
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
				if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	

		// Only proceed if the player is alive (documentation by RCabrera)
		if (!Player::isDead(%this)) {

			%armor = Player::getArmor(%this);

			// If damage hits the head
			if(%vertPos == "head") {

				// If damage is from a Laser
				if (%type == $LaserDamageType) {

					// For Heavy armors, only upper head shots do more damage (documentation by RCabrera)
					if(%armor == "demolitionsarmor" || %armor == "assaultarmor" || %armor == "artilleryarmor" || %armor == "commanderarmor") { 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
							%value *= 1.5;
						}
					}
					// For other armors, any head shots do more damage
					else {
						%value *= 1.5;
					}
				}

				// If damage is from a Sniper Rifle
				else if (%type == $SniperRifleDamageType) {
					// first we increase the damage (so snipers don't take down equipment)
					%value *= 2;

					// For Heavy armors, only upper head shots do more damage and face shots do even more
					if(%armor == "demolitionsarmor" || %armor == "assaultarmor" || %armor == "artilleryarmor" || %armor == "commanderarmor") { 
						if(%quadrant == "middle_back" || %quadrant == "middle_middle") {
							%value *= 1.5;
						}
						else if (%quadrant == "middle_front") {
							// face shot
							%value *= 1.8;
						}
					}
					// For other armors
					else {
						if (%quadrant == "middle_front") {
							// face shot
							%value *= 2.0;
						}
						else {
							%value *= 1.8;
						}
					}
				}

				// For all other damage
				else {
					// For Heavy armors, only upper head shots do more damage (documentation by RCabrera)
					if(%armor == "demolitionsarmor" || %armor == "assaultarmor" || %armor == "artilleryarmor" || %armor == "commanderarmor") { 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
							%value *= 1.25;
						}
					}
					// For other armors, any head shots do more damage
					else {
						%value *= 1.25;
					}
				}

			}

			// If damage hits the torso
			if(%vertPos == "torso") {
				// If damage is from a Sniper Rifle or Laser
				if (%type == $SniperRifleDamageType || %type == $LaserDamageType) {
					// If the back is hit
					if (%quadrant == "back_right" || %quadrant == "back_left") {
						// Get a random number
						%ran = getRandom();

						// Perhaps the flag is dropped
						if (%ran < 0.3)
							SpecialistDropFlag(%this);
						// Perhaps the pack is removed
						else if (%ran < 0.6)
							SpecialistDropPack(%this);
						// Perhaps the pack is triggered or deployed
						else if (%ran < 0.9) 
							SpecialistTriggerPack(%this);
					}
					// If the front_right is hit
					else if (%quadrant == "front_right") {
						// Get a random number
						%ran = getRandom();

						// Perhaps the weapon is removed
						if (%ran < 0.3)
							SpecialistDropWeapon(%this);
						// Perhaps the weapon is triggered
						else if (%ran < 0.6)
							SpecialistTriggerWeapon(%this);
					}
					// If the front_left is hit
					else if (%quadrant == "front_left") {
						// Get a random number
						%ran = getRandom();

						// Perhaps the beacon is removed
						if (%ran < 0.3)
							SpecialistDropBeacon(%this);
						// Perhaps the beacon is deployed
						else if (%ran < 0.6)
							SpecialistDeployBeacon(%this);
					}
				}
			}

			//If Shield Pack is on AND the damage is not from poison gas or radiation or acid or blinding light
			if (%type != -1 && %this.shieldStrength && %type != $PoisonGasDamageType && %type != $RadiationDamageType && %type != $AcidDamageType && %type != $BlindDamageType) {

				// shields fully nullify flame damage
				if (%type == $FireDamageType) {
					// play shield effect
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}

				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;

				// For Shrapnel or Mortars, the shield is 25% less effective (documentation by RCabrera)
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;

				// If the shield fully absorbs the damage (documentation by RCabrera)
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}

				// If the shield doesn't fully absorb the damage (documentation by RCabrera)
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}

			// If there's any leftover damage to apply to the player (documentation by RCabrera)
  			if (%value) {

				// Scale the damage according to armor protection and friendly fire factor (documentation by RCabrera)
				%value = $DamageScale[%armor, %type] * %value * %friendFire;

				// If it's of the Poison Gas variety we apply the proper effect (documentation by RCabrera)
				if (%type == $PoisonGasDamageType && %value != 0) {

					// Check to see if player is wearing Fallout pack
					if (Player::getMountedItem(%this,$BackpackSlot) != FalloutPack) {
						applyPoisonGasEffect( %damagedClient, %this, %object, %value);
					}
					%value = 0.00;
				}

				// If it's of the Radiation variety, we apply radiation effects
				if (%type == $RadiationDamageType && %value != 0) {

					if (Player::getMountedItem(%this,$BackpackSlot) != FalloutPack) {
						applyRadiationEffect( %damagedClient, %this, %object, %value);
						Client::sendMessage(%damagedClient, 1,"Warning! High radiation levels!");
					}
				}

				// If EMP Damage
				if (%type == $EMPDamageType && %value != 0) {
					// We start the EMP effect
					ixStartEMP(%damagedClient, %this, %shooterClient, %type);
				}

				// If Fire damage, then apply burn effect
				if (%type == $FireDamageType && %value != 0) {
					// A Flame pack is fire retardant
					if (Player::getMountedItem(%this,$BackpackSlot) != FlamePack) {
						startBurn(%damagedClient, %this);
					}
				}

				// If Acid damage, then apply acid effect
				if (%type == $AcidDamageType && %value != 0) {
					startAcidBurn(%damagedClient, %this);
				}

				// If it's of the Blind variety we apply the proper effect (documentation by RCabrera)
				if (%type == $BlindDamageType && %value != 0) {
					applyBlindEffect( %damagedClient, %this, %object, %value);
					%value = 0.00;
				}
				
				// Calculate what player's damage level will be when damage is applied (documentation by RCabrera)
				%dlevel = GameBase::getDamageLevel(%this) + %value;

				// See if there's more damage than can be taken (documentation by RCabrera)
				%spillOver = %dlevel - %armor.maxDamage;

				// Apply the damage (documentation by RCabrera)
				GameBase::setDamageLevel(%this,%dlevel);

				// Flash the player's screen with red (documentation by RCabrera)
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);

				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}

				// If the player IS dead (documentation by RCabrera)
				else {

					// If the player took ALOT of damage from an Explosion or Shrapnel (documentation by RCabrera)
					if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {

						// Player fires the weapon as they die? (documentation by RCabrera)
			 			Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);

						// And they drop the weapon if they are holding one (documentation by RCabrera)
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);

						// And they blow up! (documentation by RCabrera)
						Player::blowUp(%this);
					}

					// For other damage types or for a small amount of killing damage (documentation by RCabrera)
					else {

						// We'll play the appropriate death animation (documentation by RCabrera)

						if (%type == $PoisonGasDamageType)
							%curDie = $PlayerAnim::DieForwardKneel;
						else if (%type == $RadiationDamageType)
							%curDie = $PlayerAnim::DieForwardKneel;
						else if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
							if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;

					Client::onKilled(%damagedClient, %shooterClient, %type);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object) {

	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this, %i);
				if (%count) {
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0) {
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if (%sound) {
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	else {
		// if the player is an infantry specialist and the player is enemy, damage the player
		if ((Player::getArmor(%object) == infantryarmor || Player::getArmor(%object) == infantryfemalearmor) && GameBase::getTeam(%object) != GameBase::getTeam(%this)) {
			HandCombat(%object, %this);
			return;
		}
		// if the player is an engineer specialist and the player is friendly, repair the player
		if ((Player::getArmor(%object) == engineerarmor || Player::getArmor(%object) == engineerfemalearmor) && GameBase::getTeam(%object) == GameBase::getTeam(%this)) {
			EffectRepairs(%object, %this);
			return;
		}
	}

}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vehicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	if (Client::getControlObject(%client) != %this)
		return 1.0;

   %time = getIntegerTime(true) >> 5;
   %lastTime = Player::lastJetTime(%this) >> 10;

   if ((%lastTime + 1.5) < %time) {
      return 0.0;
   } else {
      %diff = %time - %lastTime;
      %heat = 1.0 - (%diff / 1.5);
      return %heat;
   }
}

function Player::jump(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
   }
}

$animNumber = 25;	 
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}

function Client::takeControl(%clientId, %objectId)
{
	// remote control

	// If invalid object, then exit (documentation by RJC)
	if(%objectId == -1) {
      		return;
	}

	// Get player ID (documentation by RJC)
	%pl = Client::getOwnedObject(%clientId);

	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

	// Make sure that the player and the object are on the same team (documentation by RJC)
	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)) {
//		echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
		return;
	}

	// Make sure the client ID is valid or not already controlling something else? (documentation by RJC)
	if(GameBase::getControlClient(%objectId) != -1) {
//		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}

	// Get the object's name (documentation by RJC)
	%name = GameBase::getDataName(%objectId);

	// If the object is not a camera or turret (documentation by RJC)
	if(%name != CameraTurret && %name != DeployableTurret && %name != SpyCameraTurret && %name != ELFTurret && 
		%name != dFlakTurret && %name != dFlameTurret && %name != MortarTurret && %name != PlasmaTurret && 
		%name != RocketTurret && %name != dSmokeTurret && %name != IndoorTurret && %name != dLaserTurret && 
		%name != dTargetingTurret && %name != dChainTurret && %name != dIndoorTurret && %name != dMortarTurret 
		&& %name != dPlasmaTurret && %name != dRocketTurret && %name != dELFTurret) {

		// And if the object is not powered then we exit (documentation by RJC)
		if(!GameBase::isPowered(%objectId)) {
//			echo("Turret " @ %objectId @ " not powered.");
			return;
		}
   	}

	// If player is not at a command station AND the object is not a camera turret or spy camera turret AND we are not using TestCheats AND the player is not an engineer OR a commander(documentation by RJC)
   	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != SpyCameraTurret && !$TestCheats
		&& Player::getArmor(%pl) != engineerarmor && Player::getArmor(%pl) != engineerfemalearmor && Player::getArmor(%pl) != commanderarmor) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
   		return;
	}

	// If the object's damage state is "enabled" (documentation by RJC)
	if(GameBase::getDamageState(%objectId) == "Enabled") {

//		echo("Transferring control");
		// transfer control to the object
   		Client::setControlObject(%clientId, %objectId);
	   	Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}


function applyRadiationEffect(%clientId, %player, %source, %rate) {
	%value = 0.1;

	// Scale the damage according to armor protection (documentation by RCabrera)
	%armor = Player::getArmor(%player);
	%dvalue = $DamageScale[%armor, %type] * %value;

	%dlevel = GameBase::getDamageLevel(%player) + %dvalue;
	GameBase::setDamageLevel(%player, %dlevel);

//	if (Player::isDead(%player)) {

		// Server console message
//		echo("GAME: kill " @ %clientId @ " " @ %damageType);

		// Make sure the player is in the game screen
//		%playerId.guiLock = true;
//		Client::setGuiMode(%clientId, $GuiModePlay);

		// play death animation
//		%curDie = $PlayerAnim::DieForwardKneel;
//		Player::setAnimation(%player, %curDie);

		// update scores
//		%clientId.scoreDeaths++;
//		Game::refreshClientScore(%clientId);

		// print death message
//		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
//			%playerGender = "him";
//		}
//		else {
//			%playerGender = "her";
//		}

//		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
//		%victimName = Client::getName(%clientId);
//		%obitMsg = sprintf($deathMsg[$RadiationDamageType, %ridx], %victimName, %playerGender);
//		messageAll(0, %obitMsg, $DeathMessageMask);
//	}

}

function updatePoisonGasStatus(%clientId, %player, %source) {
	// This function is periodically called to check on a player's poison status 
	// and apply the poison effect.
	// By <rcabrera@atlanticuc.edu> 1/20/00

	// First, we see if the player is still poisoned
	if ($poisonGasTTG[%clientId] > 0.0) {

		// ** Damage for each burst of poison **
		%dvalue = 0.05;

		// Scale the damage according to armor protection (documentation by RCabrera)
		%armor = Player::getArmor(%player);
		%dvalue = $DamageScale[%armor, $PoisonGasDamageType] * %dvalue;

		// Apply damage
		GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) + %dvalue);

		// Flash the player's screen with red (documentation by RCabrera)
		%flash = Player::getDamageFlash(%player) + %dvalue * 2;
		if (%flash > 0.75) 
			%flash = 0.75;
		Player::setDamageFlash(%player,%flash);

		// Check to see if the player is dead
		if (Player::isDead(%player)) {

			// Server console message
			echo("GAME: kill " @ %clientId @ " " @ %damageType);

			// Make sure the player is in the game screen
			%playerId.guiLock = true;
			Client::setGuiMode(%clientId, $GuiModePlay);

			// play death animation
			%curDie = $PlayerAnim::DieForwardKneel;
			Player::setAnimation(%player, %curDie);

			// update scores
			%clientId.scoreDeaths++;
			Game::refreshClientScore(%clientId);

			// print death message
			if(!String::ICompare(Client::getGender(%clientId), "Male")) {
				%playerGender = "him";
			}
			else {
				%playerGender = "her";
			}

			%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
			%victimName = Client::getName(%clientId);

			%obitMsg = sprintf($deathMsg[$PoisonGasDamageType, %ridx], %victimName, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);
		}

		// Decrement the time to go
		$poisonGasTTG[%clientId] -= 1;

		// Schedule our next appointment
		if ($poisonGasTTG[%clientId] > 0)
			schedule("updatePoisonGasStatus(" @ %clientId @ ", " @ %player @ ", " @ %source @ ");", 1, %player);
	}
}

function applyPoisonGasEffect(%clientId, %player, %source, %rate) {
	// This function will perform the PoisonGas effect.
	// It applies a certain amount of poison into the target's system depending on how 
	// close they were to the center of the gas cloud.  This poison will take a few 
	// moments to wear off, depending on how close they were to the center of the cloud.
	// They will also be blinded for a shorter amount of time.
	// By <rcabrera@atlanticuc.edu> 1/20/00

	// If the player is not already poisoned
	if ($poisonGasTTG[%clientId] == "" || $poisonGasTTG[%clientId] < 1) {

		// We tell the player what is happening
		Client::sendMessage(%clientId, 1, "You're breathing poison gas!");

		// We schedule pending damage and blind effects
		schedule("updatePoisonGasStatus(" @ %clientId @ ", " @ %player @ ", " @ %source @ ");", 1, %player);
		schedule("updateBlindStatus(" @ %clientId @ ", " @ %player @ ", " @ %source @ ");", 1, %player);
	}

	// We poison the player and set it's time to go
	$poisonGasTTG[%clientId] += 1;

	// We blind the player and set it's time to go
	$blindTTG[%clientId] += 1;
}

function applyBlindEffect(%clientId, %player, %source, %rate) {
	Client::sendMessage(%clientId, 1, "You're blinded!");
	$blindTTG[%clientId] = 6;
	
	// actually blind the player
	Player::setDetectParameters(%player, 50, 150);

	schedule("updateBlindStatus(" @%clientId@ ", " @%player@ ", " @%source@ ");", 0.2, %player);
}

function updateBlindStatus(%clientId, %player, %source) {

	// If there is time remaining on the blind effect
	if ($blindTTG[%clientId] > 0.0) {

		// Flash the player's screen with red (documentation by RCabrera)
		Player::setDamageFlash(%player, 1.0);

		// Decrement the time to go
		$blindTTG[%clientId] -= 1;

		// Schedule our next appointment
		if ($blindTTG[%clientId] > 0)
			schedule("updateBlindStatus(" @ %clientId @ ", " @ %player @ ", " @ %source @ ");", 1, %player);
	}
	else {
		// clear the blind effect
		Player::setDetectParameters(%player, 0.27, 0);
	}
}

