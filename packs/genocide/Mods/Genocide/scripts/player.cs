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
$CorpseTimeoutValue = 10;
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
	//echo("No ammo for ",%itemType.description," slot(",%imageSlot,")");
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

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;
      Player::applyImpulse(%this,%mom);

                        if (%type == $Kickback)
			return; 
			%armor = Player::getArmor(%this); 		
			if(%shooterTeam != %targetTeam || $Server::TeamDamageScale || Player::getClient(%this) == %object)
			{	
				if(%type == $BioShrapnelDamageType)
					eval(%armor @ "::OnBio(" @ %damagedClient @ ", " @ %this @ ");");
				else if(%type == $EMPDamageType)
					eval(%armor @ "::onShock(" @ %damagedClient @ ", " @ %this @ ");");
                                else if(%type == $SludgeDamageType)
					eval(%armor @ "::onSludge(" @ %damagedClient @ ", " @ %this @ ");");
}


  if(%this.invulnerable || $NoDamage)
      {     
         // no damage, just play a shield.
		   %thisPos = getBoxCenter(%this);
		   %offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
		   GameBase::activateShield(%this,%vec,%offsetZ);
         return;
      }

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

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LazerexDamageType) {
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $BioShrapnelDamageType || %type == $SplitMortarDamageType)
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
                          if (%value) 
			{
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
	        	   	%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				if(%dlevel >= %armor.maxDamage)
				{
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if(%flag == "flag") 
					{
						if(%damagedClient != %shooterClient)
						{
							if(%damagedTeam != %shooterTeam)
							{
								%shooterClient.score+=1;
								Game::refreshClientScore(%shooterClient);
								schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Recieve 2 Points for Killing the Enemy Flag Carrier!\");",1);
							}
							else
							{
								%shooterClient.score-=1;
								Game::refreshClientScore(%shooterClient);
								schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Lose 2 Points for Killing your own Flag Carrier!\");",1);
							}
						}
					}
				}




if ( %type == $BioShrapnelDamageType && %friendFire){
					//echo("friendFire "@%friendFire);
					startPoison(%damagedClient, %this);
					return;}



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
               if(%spillOver > 0.5 && (%type== $StormHammerDamageType || %type == $BioShrapnelDamageType || %type== $SplitMortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $StormHammerDamageType || %type == $BioShrapnelDamageType || %type== $SplitMortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieBlownBack;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack, $PlayerAnim::DieBlownBack);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieBlownBack;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieBlownBack;
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
   %client = Player::getClient(%this);
   if (Client::getControlObject(%client) != %this) return 1.0;
   if(Player::getMountedItem(%this,$BackpackSlot) == "StealthShieldPack") return 0.0;
 %time = getIntegerTime(true) >> 5;
 %lastTime = Player::lastJetTime(%this) >> 10;
   if ((%lastTime + 1.5) < %time) {
   return 0.0;
 }
   else
 {
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

function startPoison(%clientId, %player) { 
	Client::sendMessage(%clientId,1,"You Got Hit With a Bio/Chem CockTail!!!"); 
	%drrate = GameBase::getDamageLevel(%player) + 0.05; 
	GameBase::setDamageLevel(%player, %drrate);
	Player::setDamageFlash(%player,0.5);
			if (Player::isDead(%player)) {
			messageall(0, Client::getName(%clientId) @ " Died from a Toxic CockTail."); 
			%clientId.scoreDeaths++;

 		playNextAnim(%player); 
		Player::blowUp(%player); 
		Player::kill(%player); 
 
			%clientId.score--; 
			Game::refreshClientScore(%clientId); 
			$poisonTime[%clientId] = 0; } 

		if($poisonTime[%clientId] == 0) { 
		Player::setDamageFlash(%player,0.75); 
		$poisonTime[%clientId] = 30; 
		checkPoison(%clientId, %player); 
		} 
	else $poisonTime[%clientId] = 30; 
	} 

function checkPoison(%clientId, %player) { 
	if($poisonTime[%clientId] > 0) { $poisonTime[%clientId] -= 2; 
	%drrate = GameBase::getDamageLevel(%player) + 0.05; 
		if (!Player::isDead(%player)) { GameBase::setDamageLevel(%player, %drrate); 
		Player::setDamageFlash(%player,0.25); 
			if (Player::isDead(%player)) {
			messageall(0, Client::getName(%clientId) @ " Died from a Toxic CockTail."); 
			%clientId.scoreDeaths++;

 		playNextAnim(%player); 
		Player::blowUp(%player); 
		Player::kill(%player); 
 
			%clientId.score--; 
			Game::refreshClientScore(%clientId); 
			$poisonTime[%clientId] = 0; } 
			} 
		else { $poisonTime[%clientId] = 0; 
		} 
		schedule("checkPoison(" @ %clientId @ ", " @ %player @ ");",1,%player); } 
	else { Client::sendMessage(%clientId,3,"The effects of the Bio/Chem CockTail wear off."); 
	} 
} 

function Arms_AntiGrav(%clientId, %player)
{
	if ($antigrav[%clientId])
	{
		%velocity = 0.5;
		%zVec = 1.80;
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%player),%velocity,%zVec);
		Player::applyImpulse(%player,%jumpDir);
		schedule("Arms_AntiGrav(" @ %clientId @ ", " @ %player @");",0.01,%player);
	}
    }
}