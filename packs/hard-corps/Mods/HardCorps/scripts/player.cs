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
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem ius not called here.
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

function Player::onKilled(%this)
{
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

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
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

function StartEMPulseEffects(%clientId,%player,%object)
{ 
	%weapon = Player::getMountedItem(%player,$WeaponSlot); 
	if(($WeaponAmmo[%weapon] == "")) Player::unmountItem(%player,$WeaponSlot); 

	if (%player.empeffect == 0) 
		{
			Client::sendMessage(%clientId,1,"Electrical Systems Offline..."); 
			%player.empeffect = 10;
			%player.sayempstuff = "true";
		} else
		{
			%player.empeffect += 5;
		}
	EMPulseEffects(%clientId,%player,%object);
} 

function EMPulseEffects(%clientId,%player,%object)
{
	if(%player.empeffect > 0) 
		{ 
			%energy = GameBase::getEnergy(%player);
		 	%energy -= 5;
			if (%energy <= 10) {
		      	%energy = 0;
				%damlevel = GameBase::getDamageLevel(%player);
				%damlevel += 0.001;
				if (%damlevel <= 0) Client::onKilled(%client, %object, $EMPulseDamageType);
				GameBase::setDamageLevel(%player,%damlevel);
				if(%player.sayempstuff == "true")
					{
						Client::sendMessage(%clientId,1,"Electrical Feedback Induced By EMP!"); 
						%player.sayempstuff = "false";
					}
				playSound(SoundEMPulseEffect,GameBase::getPosition(%player));
			   }
		      GameBase::setEnergy(%player, %energy);
			%player.empeffect--;
			schedule("EMPulseEffects(" @ %clientId @ ", " @ %player @ ", " @ %object @ ");",0.5,%player);  
		} else 
		{ 
			if (%player.empeffect > 0) 
			{
				if(!Player::isDead(%clientId)) Client::sendMessage(%clientId,1,"Electrical Systems Online..."); 
				%player.empeffect = 0;
			}
		}
} 

function ScaleLaserDamage(%target, %player, %value)
{
	if (%value != 0 && %typeoftarget = getObjectType(%player) == "Player")
		{
			// Set up basics of energypack + laser rifle combination.
			%lasmod = 1.0;
			if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) %lasmod = 1.4;

			// Scale damage by Armour energy maximum.
			%armor = Player::getArmor(%player);
			if (%armor == "marmor" || %armor == "mfemale") %value = %value * 0.705;
			if (%armor == "harmor") %value = %value * 0.545;

			// Add distance effects.
			%dist = Vector::getDistance(Gamebase::getPosition(%player), Gamebase::getPosition(%target));

			if (%dist > 500) %value = %value * ((0.9 * %lasmod) + (((500 * %lasmod) / %dist) * 0.1)); 
				else %value = %value * %lasmod;
		}
	return %value;
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%player = %this;

	if ($Game::MissionType == "Stairway")
		{
			if(%type == $LandingDamageType || %type == $BlasterDamageType) %value = 0.0;
		}

	if (%type == $LaserDamageType) %value = ScaleLaserDamage(%this,%object,%value);

	if (Player::isExposed(%this) && Player::getClient(%this).spawnimmunity <= 0) {
      %damagedClient = Player::getClient(%this);
	%damagedClient.damQuad = %quadrant;
	%damagedClient.damVert = %vertPos;
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) && %type != $TurretDamageType) {
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
					if ($UseAdjustedScoring == "true")
						{
							if (%object != %this.lastDamageObject)
								{
									%shooterClient.TeamDamaged++;
									if ($ShowScoreBonuses == "true") Client::sendMessage(%shooterClient, 0, "You lose one point for damaging your teammate.");
									%shooterClient.score--;
									Game::refreshClientScore(%shooterClient);
								}
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

		if (!Player::isDead(%this)) {
			if ($SuddenDeathActive == "true" && %this == $FlagName[GameBase::getTeam(%this)].carrier && GameBase::getTeam(%this) != GameBase::getTeam(%object))
				{
					if(GameBase::getTeam(%this) == 0)
						{
							%enemyflagteam = 1;
						} else
						{
							%enemyflagteam = 0;
						}
					$SuddenDeathCounter[%enemyflagteam] = $SuddenDeathTimeLimit;
					$FlagName[%enemyflagteam].carrier.suddendeathactive = "false";
				}
			if (%type == $EMPulseDamageType)
			{
				if(GameBase::getTeam(%this) != GameBase::getTeam(%object) || %damagedClient == %shooterClient || (GameBase::getTeam(%this) != GameBase::getTeam(%object) && $teamplay)) 
					{
						if (%type != -1 && %this.shieldStrength) 
						{
							playSound(SoundEMPulseEffect,GameBase::getPosition(%this));
						} else
							{
								StartEMPulseEffects(%damagedClient,%this,%object);
							}
					}
			}
			%armor = Player::getArmor(%this);
	if ($UseAdjustedDamageScale == "true")
		{
			%value = (%value * $AdjustedDamageScale);
			if (%vertPos == "head")
				{
					if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back")
						{
							if (%armor == "harmor") %value += (%value * 0.1); else %value +=(%value * 0.3);
						} else
						{
							%value += (%value * 0.1);
						}
					if (%type == $LaserDamageType) %value += (%value * 0.25);
				}
			if (%vertPos == "torso")
				{
					if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back") %value += (%value * 0.2);
				}
			if (%vertPos == "legs")
				{
					if (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back") %value += (%value * 0.1);
				}

		} else
		{
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) 
			{
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 					{
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
		}
		if (%armor == "harmor") %dv = 0.30;
		if (%armor == "marmor" || %armor == "mfemale") %dv = 0.325;
		if (%armor == "larmor" || %armor == "lfemale") %dv = 0.35;

		if (%type == $LaserDamageType && %value >= %dv) 
			{
				if (%vertPos == "torso" && %quadrant == "front_right")
					{
						%wpn = Player::getMountedItem(%this,$WeaponSlot);
						if (%wpn != -1 && %wpn != RepairGun && %wpn != PowerPackGun)
							{
								Player::unmountItem(%this,$WeaponSlot);
								Player::dropItem(%this,%wpn);
								Client::sendMessage(%shooterClient,0,"You sniped the " @ %wpn @ " from " @ Client::getName(%damagedClient) @ "'s hands.");
								Client::sendMessage(%damagedClient,0,"" @ Client::getName(%shooterClient) @ " sniped the " @ %wpn @ " from your hands.");
								%object.snipes++;
							   if ($UseAdjustedScoring == "true")
								{
									if ($ShowScoreBonuses == "true")
									{
										if (%object.snipes == 1) Client::sendMessage(%shooterClient, 0, "You receive one point for sniping.");
											else Client::sendMessage(%shooterClient, 0, "You receive " @ %object.snipes @ " points for sniping.");
									}
									%object.score+=%object.snipes;
									%object.offencebonus++;
								      Game::refreshClientScore(%shooterClient);
								}
							}
					}
				if ((%vertPos == "head" || %vertPos == "torso") && (%quadrant == "middle_back" || %quadrant == "middle_middle" || %quadrant == "back_left" || %quadrant == "back_right"))
					{
						%ourteam = GameBase::getTeam(%player);
						if (%ourteam == 0) 
							{
								%theirteam = 1;
							} else %theirteam = 0;
						if ($FlagName[%theirteam].carrier == %player)
							{
								%player = %this;
								%playerTeam = GameBase::getTeam(%player);
								%flag = %player.carryFlag;
								%flagTeam = GameBase::getTeam(%flag);
								%playerName = Client::getName(%clientId);
								%shooterName = Client::getName(%shooterId);
								if(%flagTeam == -1) 
									{ 
										Client::sendMessage(%shooterClient,0,"You sniped the " @ %flag.objectiveName @ " from " @ Client::getName(%damagedClient) @ "'s back.");
										Client::sendMessage(%damagedClient,0,"" @ Client::getName(%shooterClient) @ " sniped the " @ %flag.objectiveName @ " from your back.");
									} else 
									{ 
										Client::sendMessage(%shooterClient,0,"You sniped the " @ getTeamName(%flagTeam) @ " flag from " @ Client::getName(%damagedClient) @ "'s back.");
										Client::sendMessage(%damagedClient,0,"" @ Client::getName(%shooterClient) @ " sniped the " @ getTeamName(%flagTeam) @ " from your back.");
										TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
									} 

								%object.snipes++;
								%object.flagknocks++;
								%bonuspoints = %object.snipes + (%object.flagknocks * 5);
								if (%bonuspoints <= 0) %bonuspoints = 0;
								   if ($UseAdjustedScoring == "true")
								{
									if ($ShowScoreBonuses == "true") Client::sendMessage(%shooterClient, 0, "You receive " @ %bonuspoints @ " points for sniping the flag from the enemy flag carrier's back.");
									%shooterClient.score += %bonuspoints;
									%shooterClient.defencebonus+=2;
								      Game::refreshClientScore(%shooterClient);
								}

								GameBase::throw(%flag, %player, -15, false);
								Item::hide(%flag, false);
								Player::setItemCount(%player, "Flag", 0);
								%flag.carrier = -1;
								%player.carryFlag = "";
								Flag::clearWaypoint(%clientId, false);
								schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
								%flag.dropFade = 1;
								ObjectiveMission::ObjectiveChanged(%flag);
							}
					}


			}

			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;

				if ($AllowLaserHeadKills != "true")
					{
						if (%value >= 1.0) %value = 0.99;
					}


            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;

				GameBase::setDamageLevel(%this,%dlevel);
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
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
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
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}


function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
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
}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
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
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
   		return;
   }
   if(GameBase::getDamageState(%objectId) == "Enabled") {
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

