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

// Font <f0> = IDFNT_FONTIS_3      normal green   
// Font <f1> = IDFNT_FONTIS_2      pale yellow
// Font <f2> = IDFNT_FONTIS_1      bright yellow
// Font <f3> = IDFNT_FONTIS_4      bright green
// Font <f4> = IDFNT_FONTIS_5      gray
// Font <f5> = IDFNT_FONTIS_6      red
// Font <f6> = IDFNT_FONTIS_3I     normal italic

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
	// DELTAFORCE
	%team = GameBase::getTeam(%cl);
	//echo("Hostage freed!");
	if($Game::missionType == "Hostage" || $hostageGame == 1) {
		for(%x = 0; %x < 3; %x++) {
			if($Hostages[%cl, %x] != 0) {
				//echo("I'm called! Yay!");
				GameBase::setTeam($Hostages[%cl, %x], getNumTeams() - 1);
				$hostageTeam[$Hostages[%cl, %x]] = getNumTeams() - 1;
				AI::DirectiveFollow(Client::getName($Hostages[%cl, %x]), getNearestAITeammate($Hostages[%cl, %x]), 0, 1024);
				messageAll(1, Client::getName(%cl) @ " lost " @ Client::getName($Hostages[%cl, %x]) @ "!");
				//AI::DirectiveWaypoint(Client::getName($Hostages[%cl, %x]), $AISpawn[$Hostages[%cl, %x]] , 0);
				$HostageOwner[$Hostages[%cl, %x]] = -1;
				$Hostages[%cl, %x] = 0;
				if($deltaTeamScore[%team] >= 5)
					$deltaTeamScore[%team] -= 5;
				$TakenHostages[%cl]--;
			}
		}
	}

	// Sniper limitation code
	if(Player::getArmor(%this) == "sarmor" || Player::getArmor(%this) == "sfemale")
		$SniperCount[%team]--;

	if(Player::getItemCount(%this, FuelPack) == 1) {
		%trans = GameBase::getMuzzleTransform(%cl);
		Projectile::spawnProjectile("FlameExplosion", %trans, %cl, Item::getVelocity(%cl));
	}
	$PlayerBurning[%cl] = 0;

	if($Game::missionType == "Assassination") {
		if(%cl == $Hunted) {
			if($HuntedEscaped != 1) {
				//%killerName = Client::getName(%killerId);
				for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i)) {
					remoteEval(%i, CP, "<jc><f0>The VIP was assassinated!", 4);
					Player::kill(%i);
				}
				$teamScore[1] += 1;
			}
		}
	}
	// END DELTAFORCE

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

// DELTAFORCE
function BurnTick(%this, %object) {
	if($PlayerBurning[Player::getClient(%this)] == 1) {
		GameBase::applyDamage(%this, $PlasmaDamageType, 0.1, GameBase::getPosition(%this), "0 0 0", "0 0 0", %object);
		schedule("BurnTick("@%this@", "@%object@");", 1, %this);
	}
}
// END DELTAFORCE

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
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

		// DELTAFORCE
		if(%type == $PlasmaDamageType) {
			if($PlayerBurning[%damagedClient] == 0) {
				$PlayerBurning[%damagedClient] = 1;
				Client::sendMessage(%damagedClient,1,"You are on fire!");
				BurnTick(%this, %object);
				schedule("$PlayerBurning["@%damagedClient@"] = 0;", 5);
				schedule("Client::sendMessage("@%damagedClient@",1,\"You stop burning.\");", 5);
			}
		}
		// END DELTAFORCE

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			// DELTAFORCE
			if(%vertPos == "head" && %type == $LaserDamageType) {
				remoteEval(%shooterClient, BP, "<f5><jc>Head Shot!", 3);
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						//%value += (%value * 0.3);
						// A head shot with either sniper rifle kills instantly
						%value *= 2;
					}
				}
				else {
					%value += (%value * 0.5);
				}
			} else if((%vertPos == "torso") && (Player::getItemCount(%this, FuelPack) > 0))
			{
				if((%quadrant == "back_left") || (%quadrant == "back_right") || (%quadrant == "back_middle"))
				{
					// BOOM
					Player::blowUp(%this);
					GameBase::playSound(%this, shockExplosion, 3);
					Player::setItemCount(%this, FuelPack, 0);
					%value *= 10;
					%pos = GameBase::getPosition(%this);
					schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
				}
			}
			// END DELTAFORCE
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
	// DELTAFORCE
	else if($Game::missionType == "Hostage" || $hostageGame == 1)
	{
		if(Player::isAiControlled(%this) && !Player::isAiControlled(%object)) {
		//echo("Debug: One of us is an AI and the other isn't...");
		if(getObjectType(%object) == "Player") {
			//echo("Debug: Hey! You're a player!");
			if(!Player::isDead(%object) && !Player::isDead(%this)) {
				//echo("Debug: Neither of us are dead...");
				%cl = GameBase::getOwnerClient(%object);
				%aiClient = Player::getClient(%this);
				if($TakenHostages[%cl] < 3) {
					//echo("You haven't reached the hostage limit yet...");
					// Capture the hostage for the player's teams
					%oldTeam = $hostageTeam[%aiClient];
					%playerTeam = GameBase::getTeam(%object);
					if (%oldTeam == %playerTeam) {
						return;
					}			
			
					if (%oldTeam != -1 && %oldTeam != getNumTeams() - 1) {
						$deltaTeamScore[%oldTeam] -= 5;
					}
   					$deltaTeamScore[%playerTeam] += 5;
					$hostageTeam[%aiClient] = %playerTeam;
			
					GameBase::setTeam(%this, %playerTeam);

					for (%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c)) {
						Client::SendMessage(%c, 1, Client::getName(%aiClient) @ " has been taken by " @ Client::getName(%cl) @ "!");
					}
			
					%aiName = Client::getName(%aiClient);	
					AI::DirectiveFollow(%aiName, %cl, 0, 1024);
					$TakenHostages[%cl] += 1;
					$HostageOwner[%aiClient] = %cl;
					%c = 0;
					%q = 0;
					while(%q < 1 && %c < 3) {
						if($Hostages[%cl, %c] == 0) {
							$Hostages[%cl, %c] = %aiClient;
							%q = 1;
						}
						%c++;
					}
				} else if($HostageOwner[%aiClient] != %cl) {
					Client::SendMessage(%cl, 0, "You cannot take any more hostages!");
				}
			}
		}
	}
	}
	// END DELTAFORCE
}

// Delta Force players and ground vehicles can't be tracked by SAMs...only Apaches and Blackhawks can
function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	%vehicle = Client::getControlObject(%client);
	if (%vehicle != %this) {
		if (Gamebase::getDataName(%vehicle) == Hornet || Gamebase::getDataName(%vehicle) == Tomcat || Gamebase::getDataName(%vehicle) == Falcon || Gamebase::getDataName(%vehicle) == Eagle || Gamebase::getDataName(%vehicle) == Bomber || Gamebase::getDataName(%vehicle) == Hercules || Gamebase::getDataName(%vehicle) == Warthog || Gamebase::getDataName(%vehicle) == MoveWarthog)
			return 1.0;
	}
   // %time = getIntegerTime(true) >> 5;
   // %lastTime = Player::lastJetTime(%this) >> 10;

   // if ((%lastTime + 1.5) < %time) {
      return 0.0;
   // } else {
   //    %diff = %time - %lastTime;
   //   %heat = 1.0 - (%diff / 1.5);
   //   return %heat;
  // }
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
	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployablePlasma && %name != DeployableMortar && name != DeployableSAM && %name != DeployableAA)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      echo("Turret " @ %objectId @ " not powered.");
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
	startGracePeriod(%clientId, %ownedObject);
	if (Gamebase::getDataName(%ctrlObject) == MortarTurret || Gamebase::getDataName(%ctrlObject) == DeployableMortar) Gamebase::startFadeIn(%ownedObject); 
   }
}

