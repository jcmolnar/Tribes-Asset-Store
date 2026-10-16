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

$PlayerAnim::Celebration1 = 43;
$PlayerAnim::Celebration2 = 44;
$PlayerAnim::Celebration3 = 45;
$PlayerAnim::Taunt1 = 46;
$PlayerAnim::Taunt1 = 47;
$PlayerAnim::Taunt1 = 47;
$PlayerAnim::Stand = 49;
$PlayerAnim::Wave = 50;
$PlayerAnim::OverHere = 38;
$PlayerAnim::Salute = 42;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this) // new design
{
	initPlayer(%this);
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
	%cl.dan = false;
	%cl.poss = false;
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
	if(%this.respawning)
		break;

      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You hurt " @ Client::getName(%damagedClient) @ " (teammate)");
						Client::sendMessage(%damagedClient,0,"You were shot by " @ Client::getName(%shooterClient) @ " (teammate)");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You hurt " @ Client::getName(%damagedClient) @ " (teammate) with your mine!");
						Client::sendMessage(%damagedClient,0,"You stepped on " @ Client::getName(%shooterClient) @ "'s mine");
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

		%shooterObj = Client::getControlObject(%shooterClient);

		if ((Player::isAIControlled(%damagedClient) == True)	&&			//===== Determines if player is A.I. (by EMO1313, added by Werewolf)
			(%damagedClient != %shooterClient))	
		{

if ($Spoonbot::BotJetting[%damagedClient] != 1)
  AI::JetSimulation(%damagedClient, 0);

			$BotThink::ForcedOfftrack[%damagedClient] = true;


			%objecttype = getObjectType(%shooterObj);
			
			if(%object == 0) // Fix. Find nearest enemy AI within range of 150
			{
				%aiId = %damagedClient;
				%maxdist = 500;

				%nearestdist = 999999;
				%nearestid = 0;
				%myTeam = Client::getTeam(%aiId);
				%BotPosistion = GameBase::getPosition(%aiId);

				for(%x = 0; %x < $AttackerIndexCount; %x++)
				{

					%nearestnominateid = $AttackerIndexIds[%x];
					%nearestnominatepos = GameBase::getPosition($AttackerIndexIds[%x]);
					%nearestnominatedist = Vector::getDistance(%BotPosistion,%nearestnominatepos);
					%nearestnominateteam = Client::getTeam(%nearestnominateid);
					%nearestnominatename = Client::getName(%nearestnominateid);

					// Note: following if statement breaks AI type standard - direct coding!

					if	((%aiId != %nearestnominateid) &&
						 ( %nearestnominatedist < %nearestdist) &&
						 (%nearestnominateteam != %myTeam))
					{

						%nearestid = %nearestnominateid;
						%nearestdist = %nearestnominatedist;
					}
				}

				if(%nearestdist <= %maxdist)
				{

  					BotFuncs::AddAttacker(%aiId,%nearestid,1024,1);
					//BotThink::Think(%aiId, False);
				}
			}
			else if (getObjectType(%shooterObj) == "Player")				// Is the shooting client a player?
			{

				 %shooterpos = GameBase::getPosition(%shooterClient);			//===== Gets Shooters Location & Other Varibles
				 %worldLoc = WaypointToWorld ( %shooterpos );
				 %aiTeam = Client::GetTeam(%damagedClient);
				 %aiName = Client::GetName(%damagedClient);
				 %aiId = %damagedclient;
			 
				 %shooterTeam = Client::GetTeam(%shooterClient);
	
				 if(%aiTeam != %shooterTeam)
				 {

  					BotFuncs::AddAttacker(%aiId,%shooterClient,150,1);

					//BotThink::Think(%aiId, False);

				 }

			 }
		}

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType || %type == $MethaneDamageType || %type == $SniperDamageType) {
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.6);
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
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if (%type == $PBWDamageType || %type == $HeatDamageType || %type == $LaserDamageType || %type == $MBDamageType)
					%value = 0.0128;
				if (%type == $MineDamageType || %type == $ImpactDamageType || %type == $LandingDamageType)
					%value = 0.0001;
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

			if(%type == $EMPDamageType)
			{ 
				EMPStart(%damagedClient, %this); 
			}
			if(%type == $BlasterDamageType)
			{ 
				%energy = GameBase::getEnergy(%player);
			 	%energy -= 2.5;
				GameBase::setEnergy(%player,%energy); 
			}
			if(%type == $ShotgunDamageType)
			{ 
				%energy = GameBase::getEnergy(%player);
			 	%energy -= 5;
				GameBase::setEnergy(%player,%energy); 
			}
			else if (%type == $MethaneDamageType) 
			{
				%armor = Player::getArmor(%this);
					Poisoned(%damagedClient, %this);
			}
			else if ((%type == $PlasmaDamageType) || (%type == $HeatDamageType)) 
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7)
				{
					%armor = Player::getArmor(%this);
						BurnTheFlesh(%damagedClient, %this);
				}
			}
			else if (%type == $MBHeatDamageType) 
			{
					%armor = Player::getArmor(%this);
						BurnTheFlesh(%damagedClient, %this);
			}
  			if (%value) {
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				if(%armor == "harmor")
					%hittolerance = 0.25;
				else
					%hittolerance = 0.41;

				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType || %type == $SniperDamageType || %type == $MethaneDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun" || %weaponType != "AODStinger" || %weaponType != "Minigun" || %weaponType != "MMinigun" || %weaponType != "MechRocketLauncher" || %weaponType != "MRPGLauncher" || %weaponType != "TwinFusor" || %weaponType != "Charger" || %weaponType != "IonCannon"))
				{
					%dlevel = GameBase::getDamageLevel(%this) + %hitdamageval;
					Player::dropItem(%this,%weaponType);
					messageall(0, Client::getName(%shooterClient) @ " sniped the " @ %weaponType @ " out of " @ Client::getName(%damagedClient) @ "'s Hand!");
				}
				else
				{
					%value = $DamageScale[%armor, %type] * %value * %friendFire;
		        	   	%dlevel = GameBase::getDamageLevel(%this) + %value;
				}
            		%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $LaserDamageType || %type == $SniperXDamageType || %type == $SniperDamageType || %type == $MethaneDamageType || %type == $MassDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
						DoTheFlagDrop(%this, %shooterClient);
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else 
				{
           	if((%spillOver > 0.25 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $PBWDamageType || %type == $LaserDamageType || %type == $ElectricityDamageType || %type == $PulseDamageType || %type == $TractorDamageType) {
						Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
					   	Player::blowUp(%this);
						%armor = Player::getArmor(%player);
						%clientId = Player::getClient(%player);
					}
					else
					{
                                    if ((%value > 0.25 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6))	{
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

function initPlayer(%this)
{
	initSFXShow(%this);
	initCapacitorValues(%this);

	if($Meltdown::OBCheck)
		obCheck(%this);
}

function initCapacitorValues(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	if(%cl.dead != 1)
	{
		$countcapacitor = 0;
		%armor = Player::getArmor(%this);
		%energy = Player::getItemCount(%this, GigaWatt); 
		Player::setItemCount(%this, GigaWatt, %armor.maxEnergy / 2);
		TSR::Capacitor(%this, %energy);
	}
	else return;
}

function TSR::Capacitor(%this, %energy)
{
	%nrg = GameBase::getEnergy(%this);
	%charge = Player::getItemCount(%this, GigaWatt);
	%armor = Player::getArmor(%this);	
	%pack = player::getMountedItem(%this, $BackPackSlot);

	if(%charge >= 150)
	{
		%charge = 150;
		Player::setItemCount(%this, GigaWatt, %charge);
		$countcapacitor = 0;
	}

	if(%pack == "Capacitor")
	{
		$countCapacitor += 1;

		if(%nrg != %armor.maxEnergy) // Stop charging loop
			$countcapacitor = 0;

            if($countCapacitor >= 100)
		{
			Player::incItemCount(%this, GigaWatt, 1);
			$countcapacitor -= 100;
		}

		if(%nrg < 10)
		{
			%charge = Player::getItemCount(%this, GigaWatt);
			if(%charge) 
			{
				Player::decItemCount(%this, GigaWatt, 1); // ammo charge converted to usable energy
				%enrg = %nrg + 1;
				GameBase::setEnergy(%this, %enrg);
			}
		}
	}
	schedule("TSR::Capacitor("@%this@","@%energy@");", 0.01, %this);
}

function obCheck(%this) // universal OB script that kills!!
{
	if(%this.outArea == 1)
		GameBase::applyDamage(%this,$DebrisDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);

	schedule("obCheck(" @ %this @ ");", 5, %this); // 5 seconds... plenty of time to get back in the mission area
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	%Player1 = Player::getClient(%this);
	%Player2 = Player::getClient(%object);
	%aiId = Player::getClient(%this);
	%aiName = Client::GetName(%aiId);
	%aiTeam = Client::GetTeam(%this);	 
	%objTeam = Client::GetTeam(%object);

	if ((Player::isAIControlled(%Player1) == "true") &&
		(Player::isAIControlled(%Player2) != "true") &&
		 (BotTypes::IsMedic(%aiName) == 1))
	{
		%repairRate = 0.1;
		%damage = GameBase::getDamageLevel(%object);
		%difference = %damage - %repairRate;
		if (%difference < 0.0)	//If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
			{
				%repairRate = %damage;
			}
		%newDamage = %damage - %repairRate;

		if (%objTeam == %aiTeam)			//Only repair friendly stuff.
			GameBase::setDamageLevel(%object, %newDamage);
	}
	if (Player::isAIControlled(%Player1) == "true"
			&& Player::isAIControlled(%Player2) == "true")
	{
		if(BotTypes::IsMedic(%aiName) == 1)
		{
			if (%aiTeam == %objTeam)
			{
			}
		}

		%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
		%aiLoc = GameBase::getPosition(Client::getOwnedObject(%this));
		%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%this)); 
}
else
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
}
function Player::getHeatFactor(%this) { 

	%client = Player::getClient(%this);
  if (Player::isAIControlled(%this))		//If it's a bot and it's jetting, then by all means DESTROY HIM!!! ;-) Werewolf
  {
        if ($Spoonbot::BotJettingHeat[%client] == 1)
	{
		return 1.0;
	}
  }


  if ((Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this))) //Werewolf
	{
	 return 1.0;
	}

 	%client = Player::getClient(%this);
	%co = Client::getControlObject(%client);
	if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") 
		return 0.0; 
	if(GameBase::getDataName(%co) == "Explorer") {
		if(Player::getMountedItem(%this,$FlagSlot) == "flag") 
			return 1.0;
		else
			return 0.0;
	}
	if (%co != %this && !%client.safet && !%client.possessing && !%client.wat)
		return 1.0;
	if(%client.burnTime > 0) 
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
   if(!$matchStarted || %client.permap || %client.spkill || %client.dan)
      return;
	if(%client.possessing) {
		(%client.poss).free = true;
		remoteKill(%client.poss);
		return;
	}
	if(%client.possessed && !%client.free) {
		Client::sendMessage(%client, 0, "You cannot kill yourself while possessed.~waccess_denied.wav");
		return;
	}
	%cl.free = false;
   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);
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

      if(%name != CameraTurret && %name != DeployableTurret && %name != Gunboy && %name != SniperTurret &&  %name != DeployableTurret && %name != AntiTurret && %name != ArtilleryTurret &&%name != VELCROTurret &&  %name != GROGTurret && %name != MiniPBW && %name != FusionTurret && %name != IonTurret && %name != Turret2 && %name != Turret3 && %name != DisruptorTurret && %name != ELFTurret && %name != RocketInTheSky && %name != ElectroTurret && %name != PulseTurret && %name != CannonTurret &&%name != DiscTurret &&       %name != ArtilleryTurret &&     %name != RealObeliskOfLight &&     %name != LaserTurret &&
      %name != DeployableELF && %name != DeployableRocket && %name != DeployableSentry && %name != MortarTurret && %name != AATurret && %name != EscapePod && %name != FluxTurret){

	   if(!GameBase::isPowered(%objectId)) 
		{
			return;
		}
   }

	if (Player::getMountedItem(%clientId,$BackpackSlot) != AODCmdPack) 
	{	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats) 
		{	Client::SendMessage(%clientId,0,"Go get a Turret Control Pack!");			
			return;
		}
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

//----------------------------------------------------------------------------
// New EMP Effect for Player - INH*DynaBlade
//----------------------------------------------------------------------------
function EMPStart(%clientId, %player, %shooter, %type) 
{ 
	%weapon = Player::getMountedItem(%player,$WeaponSlot); 
	if(($WeaponAmmo[%weapon] == "")) Player::unmountItem(%player,$WeaponSlot); 

	if (%player.EMPEffect != "true") 
		{
			Client::sendMessage(%clientId,1,"You hit yourself with an EMP!~werror_message");
			Client::sendMessage(%clientId,1,"Electrical malfunction detected.. Running suit Auto-Repair~waaodsfx53.wav"); 
			GameBase::setRechargeRate(%player,0);
			%player.EMPEffect = "true";
			$empTime[%clientId] = 100;
		} else
		{
			$empTime[%clientId] += 50;
		}
	DrainZAP(%clientId, %player); 
} 

function BlasterDrain(%clientId, %player)
{
}

function DrainZAP(%clientId, %player) 
{
	if($empTime[%clientId] > 0) 
		{ 
			%energy = GameBase::getEnergy(%player);
		 	%energy -= 2;
			%vel = Item::getVelocity(%player); 
			%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			Projectile::spawnProjectile("Electricity",%trans,%player,%vel,%player);
			if (%energy <= 10) {
		      	%energy = 0;
				%damlevel = GameBase::getDamageLevel(%player);
				%damlevel += 0.003;
				Player::setDamageFlash(%player,0.75);  
				GameBase::setDamageLevel(%player,%damlevel);
			if(Player::isDead(%player))
			{
				%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
				messageall(0, sprintf($deathMsg[$EMPDamageType, %ridx], "", Client::getName(%clientId), "", "")); 
				%clientId.scoreDeaths++; 
				Game::refreshClientScore(%clientId); 
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie); 
				$empTime[%clientId] = 0;
			}
			   }
		      GameBase::setEnergy(%player, %energy);
			$empTime[%clientId] -= 1; 
			schedule("DrainZAP(" @ %clientId @ ", " @ %player @ ");",0.1,%player); } 
		else 
		{ 
			if (%player.EMPEffect == "true") 
			{
				GameBase::setRechargeRate(%player,8);
				if(!Player::isDead(%clientId)) Client::sendMessage(%clientId,1,"Electrical system now functioning properly.~waaodsfx52.wav"); 
				%player.EMPEffect = "false";
				$empTime[%clientId] = 0;
			}
		}
} 


function Poisoned(%clientId, %player)
{
	Client::sendMessage(%clientId,1, "You are infected.");
	if($poisonTime[%clientId] == 0)
	{
		
                Player::setDamageFlash(%player,2);
		$poisonTime[%clientId] = 15;
		WatchInfection(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 15;
}


function WatchInfection(%clientId, %player)
{
	
	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 5;  
		%drrate = GameBase::getDamageLevel(%player) + 0.215;
			if  (!Player::isDead(%player)) 
			{
				GameBase::setDamageLevel(%player, %drrate);  
				Player::setDamageFlash(%player,1);  
				if  (Player::isDead(%player))
				{
					%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
					messageall(0, sprintf($deathMsg[$MethaneDamageType, %ridx], "", Client::getName(%clientId), "", "")); 
					%clientId.scoreDeaths++; 
					Game::refreshClientScore(%clientId); 
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
					Player::setAnimation(%player, %curDie); 
					$poisonTime[%clientId] = 0;
				}

		}
		else
		{
		
		$poisonTime[%clientId] = 0;
		}
		schedule("WatchInfection(" @ %clientId @ ", " @ %player @ ");",3,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"The poison subsides.");		
	}			

		
}

function BurnTheFlesh(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You're on fire!");
	if($burnTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.25);
		$burnTime[%clientId] = 64;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 64;
}


function checkPlayerBurn(%clientId, %player)
{
	if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 2;  
		%drrate = GameBase::getDamageLevel(%player) + 0.01;
		if(!Player::isDead(%player)) 
		{
		GameBase::setDamageLevel(%player, %drrate);  
		Player::setDamageFlash(%player,0.25);  
			if(Player::isDead(%player))
			{
				%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
				messageall(0, sprintf($deathMsg[$PlasmaDamageType, %ridx], "", Client::getName(%clientId), "", "")); 
				%clientId.scoreDeaths++; 
				Game::refreshClientScore(%clientId); 
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie); 
				$burnTime[%clientId] = 0;
			}

		}
		else
		{
			$burnTime[%clientId] = 0;
		}
		

		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",0.1,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"Your internal extinguishers put out the fire.");
		
	}			

		
}

// =================== scripts from other mods :)
function doneposs(%cl) 
{
	if(%cl.possessing) {
		Client::setControlObject(%cl, %cl);
	    Client::setControlObject(%cl.poss, %cl.poss);
		MessageAllExcept(%cl.poss, 0, Client::getName(%cl.poss) @ " has been removed from the Mind Meld by " @ Client::getName(%cl) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl.poss,1,"Your mind has been freed by " @ Client::getName(%cl)@".~wteleport2.wav"); 	
		%cl.possessing = false;
		(%cl.poss).possessed = false;
		(%cl.poss).possby = "";
		%cl.poss = "";
	}
	if(%cl.possessed) {
		Client::setControlObject(%cl.possby, %cl.possby);
	    Client::setControlObject(%cl, %cl);
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been removed from the Mind Meld by " @ Client::getName(%cl.possby) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"Your mind has been freed by " @ Client::getName(%cl.possby)@".~wteleport2.wav"); 	
		%cl.possessed = false;
		(%cl.possby).possessing = false;
		(%cl.possby).poss = "";
		%cl.possby = "";
	}
	if(%cl.wat) {
		Client::sendMessage(%cl,0,"You are no longer watching " @ Client::getName(%cl.wat)@"."); 	
		bottomprint(%cl, "", 0);
		if(Observer::isObserver(%cl)) {
			(%cl.wat).wated = "";
			%cl.wat = "";
			%cl.booyah = "";
			Client::setControlObject(%cl, Client::getObserverCamera(%cl));
			%cl.observerMode = "observerFly";
			Observer::triggerUp(%cl);
			return;
		}
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		if(!%cl.isAdmin || (%cl.wat).isSuperAdmin)
			Client::sendMessage(%cl.wat,0,"You are no longer being watched by " @ Client::getName(%cl)@"."); 	
		(%cl.wat).wated = "";
		%cl.wat = "";
		%cl.booyah = "";
	}
	if(%cl.wated) {
		for(%cc = Client::getFirst(); %cc != -1; %cc = Client::getNext(%cc)) {
			if(%cc.wat == %cl) schedule("changewat("@%cc@", "@%cl@");", 1);
		}
	}
}

function changewat(%clw, %cl) {
	if(e(%cl)) return;
    Client::setControlObject(%clw, Client::getObserverCamera(%clw));
  	setObsOrbit(%clw, Client::getControlObject(%cl), 5, 5, 5);
}

function DoTheFlagDrop(%player, %shooterId) 
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	%shooterName = Client::getName(%shooterId);

	if (%shooterid)
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!");
			TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
		}
	}	
	else
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %dropClientName @ " has butter fingers and dropped the flag.");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %dropClientName @ " has butter fingers and dropped the flag.");
		}
	}
	GameBase::throw(%flag, %player, -15, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

function Cloaker(%player)
{
	%cl = Player::getclient(%player);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%TargetPlayer = Client::getOwnedObject(%clientId);
		if(GameBase::GetTeam(%clientId) != GameBase::GetTeam(%player))
		{
			%UserPos=gamebase::getPosition(%player);
			%TargetPos=gamebase::getPosition(%TargetPlayer);
			%dist = Vector::getDistance(%UserPos, %TargetPos);
			%matrix = %clientId @ %player;
			if(%dist < 140 && $cloaked[%player] == 1)
			{

				if($cloakEffected[%matrix] != 1)
				{
					Player::setDetectParameters(%Targetplayer, 50, 150);
					$TotalCloaks[%ClientId]++;
					$cloakEffected[%matrix] = 1;
				}
			}
			else
			{
				if($cloakEffected[%matrix] == 1) $TotalCloaks[%ClientId]--;
				if($TotalCloaks[%ClientId] < 1)
				{
					Player::setDetectParameters(%Targetplayer, 0.027, 0);
					$cloakEffected[%matrix] = 0;
				}
			}
		}
	}
	if(Player::isTriggered(%player, $BackPackSlot) && Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice" || %cl.beaconCloak) 
	{
		schedule("Cloaker(" @ %player @ ");", 0.5, %player);
	}

}

function Gundam::Cloak(%clientId, %player)
{
	%clientid.beaconCloak = true;
	%armor = Player::getArmor(%player);
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
 	$cloaked[%player] = 1;
 	Cloaker(%player);
	%rate = Player::getSensorSupression(%player) + 1;
	Player::setSensorSupression(%player,%rate);
	
	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else
		$cloakTime[%clientId] = 20;
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;  
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		%clientid.beaconCloak = false;
		GameBase::playSound(%player,ForceFieldClose,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 1;
		Player::setSensorSupression(%player,0);
	 	$cloaked[%player] = 0;
 		Cloaker(%player);
	}
}

function Gundam::Shield(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

                %player.shieldStrength = 0.025;

	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($shieldTime[%clientId] > 0)
	{
		$shieldTime[%clientId] -= 2;  
		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldClose,0);	
	}			
}

function initSFXShow(%this)
{
	GameBase::setRechargeRate(%this,10);
	%armor = Player::getArmor(%this);
	%damage = %armor.maxDamage - 0.001;
	GameBase::setDamageLevel(%this, %damage);
	GameBase::setAutoRepairRate(%this, %damage / 8);
	%this.respawning = true;
	sfxShow(%this, $Meltdown::RespawnEffectTime);
}

function sfxShow(%player, %setTime, %time)
{
   if(%time > %setTime || %time < 0)
   {
	%setTime = 0;
	GameBase::setRechargeRate(%player,8);
	%player.respawning = false;
	GameBase::setAutoRepairRate(%player, 0);
	break;
   }
   else
   {
      %t2 = %time * 2;
      if(%t2 & 2)
      {
         if((%t2) & 1)
            %vec = "0 -1 0";
         else
            %vec = "0 1 0";
      }
      else
      {
         if((%t2) & 1)
            %vec = "1 0 0";
         else
            %vec = "-1 0 0";
      }
      GameBase::activateShield(%player,%vec, 0);

      schedule("sfxShow(" @ %player @ ", "@ %setTime @ ", "@ %time + 0.5 @ ");", 0.5, %player);
   }
}

function killit() // from the old Duke Nukem 3D mod making days....
{
	noReturn();
	break;	
}

function noReturn()
{
}
