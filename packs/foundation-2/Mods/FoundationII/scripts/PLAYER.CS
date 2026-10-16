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
//ICE'S LASER RECOGNITION MODULE, DAMAGE TO PERFECTION
//----------------------------------------------------------------------------
//$DamageToLaser[(Weapon ImageType Here)]	   = (DamageType Goes here);
$DamageToLaser[LaserRifle]	  = $LaserDamageType;
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
	if(%type == $LaserDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		%type = $DamageToLaser[%weap];
		if(%type == "")
			 %type = $LaserDamageType;
	}

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

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && $HeadVal[%type] != "") {
				if(%armor == "harmor") {
					echo("Heavy Head Val[Amp: " @ $HeadVal[Heavy,%type] @ ", Value: " @ %value @ ", Amped Value: " @ %value * $HeadVal[Heavy,%type] @ "]");
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						%value *= $HeadVal[Heavy,%type];
				}
				else {
					echo("Head Val[Amp: " @ $HeadVal[%type] @ ", Value: " @ %value @ ", Amped Value: " @ %value * $HeadVal[%type] @ "]");
					%value *= $HeadVal[%type];
				}
				echo("Value: "@%value);
			}

			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength && %friendFire > 0) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				else if(%type == $LaserDamageType)
					%strength *= 0.5;
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


			if(%type == $FlashDamageType && SeeFlash(%quadrant))
				Blind(%this,20);
			%baseval = %value;
			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound & add status effects
				if(!Player::isDead(%this)) {
					if(%type == $EMPDamageType && %value != 0)
						EMPsystem(%this, %object, 50, %type);
					else if (%type == $PoisonDamageType && %value != 0)
						Infect(%this, %object, 50, %type);
					else if (%type == $FireDamageType && %value != 0)
						SetOnFire(%this, %object, 50, %type);
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
							if(%quadrant == "front_left" || %quadrant == "front_right"	)
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
							if(%quadrant == "front_left" || %quadrant == "back_left")
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
	else if(!Player::isDead(%object)) {
		if(getObjectType(%object) == "Player") {
			%armor = $ArmorName[Player::getArmor(%this)];
			eval(%armor@"::onContact("@%this@","@%object@");");
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
	if(%name != CameraTurret && %name != DeployableTurret && !$PlayCtrl[%name])
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

//BURNING from Devastator Mod by Ice with some changes by ProtoManX
//EMP & POISON functions are a variation of the BURNING function
//EMP
function EMPsystem(%this,%object,%time,%type)
{
	if(%this.shorted <= 0){
		Client::sendMessage(Player::getClient(%this),1,"Energy systems offline...");
		%this.shorted = %time;
		EMPon(%this,%object,%type);
	}
	else
		%this.shorted = %time;
}

function EMPon(%this,%object,%type)
{
	if(Player::isDead(%this))
		return;
	if(%this.shorted > 0) {
		GameBase::setRechargeRate(%this,0);
		GameBase::setEnergy(%this,0);
		%value = 0.0004;
		if(GameBase::getDamageLevel(%this)+%value < Player::getArmor(%this).maxDamage) {
//			  Player::setDamageFlash(%this,%this.shorted/10);
			%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%this),"0 0 0.5");
			%vel = Item::getVelocity(%this);
//			  if(%this.shorted > 2.5)
				Projectile::spawnProjectile("EmpEffectBomb", %trans, %this, %vel);
//			  else
//				  Projectile::spawnProjectile("SmokeEffectBomb", %trans, %this, %vel);
			GameBase::setDamageLevel(%this,GameBase::getDamageLevel(%this) + %value);
			%this.shorted--;
			schedule("EMPon("@%this@","@%object@","@%type@");",0.1,%this);
		}
		else {
			playNextAnim(%this);
			Client::onKilled(Player::getClient(%this),Player::getClient(%object),%type);
			Player::kill(%this);
			return;
		}
	}
	else {
		%client = Player::getClient(%this);
		GameBase::setRechargeRate(%this,8);
		Client::sendMessage(%client,0,"Energy systems online...");
	}
}

//Burning
function SetOnFire(%this,%object,%time,%type)
{
	if(%this.burning <= 0){
		Client::sendMessage(Player::getClient(%this),1,"Your on fire!");
		%this.burning = %time;
		Burn(%this,%object,%type);
	}
	else
		%this.burning = %time;
}

function Burn(%this,%object,%type)
{
	if(Player::isDead(%this))
		return;
	if(%this.burning > 0) {
		%value = 0.0045;
		if(GameBase::getDamageLevel(%this)+%value < Player::getArmor(%this).maxDamage) {
//			  Player::setDamageFlash(%this,%this.burning/10);
			%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%this),"0 0 0.5");
			%vel = Item::getVelocity(%this);
//			  if(%this.burning > 2.5)
				Projectile::spawnProjectile("FireEffectBomb", %trans, %this, %vel);
//			  else
//				  Projectile::spawnProjectile("SmokeEffectBomb", %trans, %this, %vel);
			GameBase::setDamageLevel(%this,GameBase::getDamageLevel(%this) + %value);
			if(Player::isCrouching(%this) && %this.burning >= 1)
				%this.burning--; // crouching makes the fire go out in 1/2x secs if you move around and x if you only crouch.
			if(GameBase::isAtRest(%this))
				%this.burning -= 0.5; // takes 2x secs if you don't move or crouch.
			else
				%this.burning--; // the fire will go out in x secs as long as you don't stop moving.
			schedule("Burn("@%this@","@%object@","@%type@");",0.1,%this);
		}
		else {
			playNextAnim(%this);
			Client::onKilled(Player::getClient(%this),Player::getClient(%object),%type);
			Player::kill(%this);
			return;
		}
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"The fire went out!");
}

//Poisoning
function Infect(%this,%object,%time,%type)
{
	if(%this.poisoned <= 0){
		Client::sendMessage(Player::getClient(%this),1, "You have been poisoned.");
		%this.poisoned = %time;
		Poison(%this,%object,%type);
	}
	else
		%this.poisoned = %time;
}

function Poison(%this,%object,%type)
{
	if(Player::isDead(%this))
		return;
	if(%this.poisoned > 0) {
		%value = 0.0045;
		if(GameBase::getDamageLevel(%this)+%value < Player::getArmor(%this).maxDamage) {
//			  Player::setDamageFlash(%this,%this.poisoned/10);
			GameBase::setDamageLevel(%this,GameBase::getDamageLevel(%this) + %value);
			if(GameBase::isAtRest(%this))
				%this.poisoned--; // takes x secs for poison to subside if you don't move
			else
				%this.poisoned -= 0.5; // the poison will subside in 2x secs if you don't stop moving.
			schedule("Poison("@%this@","@%object@","@%type@");",0.1,%this);
		}
		else {
			playNextAnim(%this);
			Client::onKilled(Player::getClient(%this),Player::getClient(%object),%type);
			Player::kill(%this);
			return;
		}
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"The poison subsides.");
}

//Blinding
function Blind(%this,%time)
{
	if(%this.blinded <= 0){
		Client::sendMessage(Player::getClient(%this),0, "You have been blinded.");
		%this.blinded = %time;
		FlashEyes(%this);
	}
	else
		%this.blinded = %time;
}

function FlashEyes(%this)
{
	if(Player::isDead(%this))
		return;
	if(%this.blinded > 0) {
		Player::setDamageFlash(%this,1);
		%this.blinded--;
		schedule("FlashEyes("@%this@");",0.5,%this);
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"You can see agian.");
}

//===========================
//Check functions
//===========================
function SeeFlash(%quadrant)
{
	if(%quadrant == "front_left" || %quadrant == "front_right" || %quadrant == "middle_front" || %quadrant == "middle_middle")
		return true;
	else
		return false;
}
