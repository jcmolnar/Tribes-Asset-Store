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

function Player::onAdd(%this)
{
	initSFXShow(%this);
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
	%this.cloaked = false;
	if($AutoRespawn > 0 && (%cl.observerMode != "observerOrbit" || %cl.observerMode != "observerFly"))
//	if($AutoRespawn > 0)
	{
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	}
	else if(%cl.observerMode != "observerOrbit" || %cl.observerMode != "observerFly")
	{
		PlayerRespawnDelayed(%cl, $Server::respawnTime);
	}
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
function Player::onJetpack(%this, %JetpackActive)
{
	if(%this.isafk){
		%this.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%this)@" is now back and may be hurt");
		
	}

	if(!$MatchStarted || !%cl.dead = 1) // Won't make any sense to make smoke while we're dead.
		return;

	%client = Player::getClient(%this);
	%vel = Item::getVelocity(%this);
	%JetVel = getWord(%vel, 2);
	%armor = Player::getArmor(%client);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
	CheckJetpackActive(%this);

	if(%JetVel > 4 || %JetVel < -4)
	{
		if(%JetpackActive = true) // So we don't smoke while jumping. oops! hehe
		{
			if(%armor != "harmor" || %armor != "MECH" || %armor != "mearmor")
			{
				echo("firing smoke");
				Projectile::spawnProjectile(SFXSmoke, %trans, %this, %vel, %this);
                        }
			else return; // Jetpack not supported for Heavy armor models.
		}	
	}

	schedule("Player::onJetpack(\"" @ %this @ "\");", 0.1);
}

function CheckJetpackActive(%this, %target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.9) // Are we hot enough to make smoke?
		%JetpackActive = true;
	else
		%JetpackActive = false;

	return %JetpackActive; // Ok are we on?
}
		
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object,%item)
{
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;
	%sname = Client::getName(%object);
	%obj = getObjectType(%object);

		if(%damagedClient.isafk && %obj != "Turret" && %shooterclient != %damagedclient){
		echo("A.F.K Killer");
		messageallexcept(%object,1, $adminbotname @": "@%sname@" has been warned for shooting a player who is A.F.K");
		client::sendmessage(%shooterclient, 1 , $adminbotname @": This Player is A.F.K you cannot hurt him, he is under my protection.");
		return false;
		}
		Player::applyImpulse(%this,%mom);
		if(%this.isafk && %obj != "Player"){
		%this.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%this)@" is now back and may be hurt");
		
	}

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

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType || %type == $MethaneDamageType || %type == $SniperDamageType) {
			    centerprint(%shooterclient, "<jc><f1>"@$adminbotname @": <f0>HEAD SHOT");
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 1.0);
					}
				}
				else {
					%value += (%value * 1.0);
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

			if(%type == $EMPDamageType)
			{ 
				EMPStart(%damagedClient, %this); 
			}
			else if ((%type == $PlasmaDamageType) || (%type == $HeatDamageType)) 
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7.5)
				{
					%armor = Player::getArmor(%this);
						BurnTheFlesh(%damagedClient, %this);
				}
			}

			else if (%type == $MethaneDamageType) 
			{
                       %rnd = floor(getRandom() * 10);
                       if(%rnd > 4)
				{
				%armor = Player::getArmor(%this);
				if(%armor != "marmor" && %armor != "mfemale")
					Poisoned(%damagedClient, %this);
			}
}
                  else if (%type == $DisarmDamageType) 
			{
                              %armor = Player::getArmor(%this);
                              %weaponType = Player::getMountedItem(%this,$WeaponSlot);
                              Player::dropItem(%this,Flag);
                              Player::dropItem(%this,%weaponType);
					messageall(3, Client::getName(%damagedclient) @" Has been disarmed by "@ Client::getName(%shooterClient));
                              Player::setDamageFlash(%this, 200);
			
								
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
				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType || %type == $SniperDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun" || %weaponType != "AODStinger" || %weaponType != "Charger"))
				{
					%dlevel = GameBase::getDamageLevel(%this) + %hitdamageval;
					Player::dropItem(%this,%weaponType);
                              messageall(0, Client::getName(%shooterClient) @ " sniped the " @ %weaponType.description @ " out of " @ Client::getName(%damagedClient) @ "'s Hand!");

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
           				if((%spillOver > 0.24999999999999999 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $PBWDamageType || %type == $ElectricityDamageType || %type == $PulseDamageType || %type == $TractorDamageType || %type == $ShotgunDamageType || %type == $LaserDamageType) 
				{
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
		                                 if ((%value > 0.25 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6))	
				{
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


function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if(%this.isafk){
		%this.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%this)@" is now back and may be hurt");
		
	}

	%rnd = floor(getRandom() * 10);
	%objectt = getObjectType(%object);
	%cl = Player::getClient(%this);
	%player2 = Player::getClient(%object);
	%targetId = GameBase::getOwnerClient(%object);
	%name = Client::getName(%targetId);
      if (%this.poisoned == "true" && (GameBase::getTeam(%this) != GameBase::getTeam(%object)) && %objectt == "Player") 
	{
      Client::sendMessage(%cl, 3, "You have infected " @ %name @".");
	Poisoned(%Player2, %object);
	}
      else 
      {
	}
      if(%this.burn == "true" && (GameBase::getTeam(%this) != GameBase::getTeam(%object)) && %objectt == "Player" && %rnd > 7) 
	{
	Client::sendMessage(%cl, 3, "You have set " @ %name @" on fire.");
	BurnTheFlesh(%Player2, %object);
}
      else 
      {
	}

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
	if ((Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this)))
	{
		 return 1.0;
	}

 	%client = Player::getClient(%this);
	%co = Client::getControlObject(%client);

	if(GameBase::getDataName(%co) == "Explorer") 
	{
		if(Player::getMountedItem(%this,$FlagSlot) == "flag") 
			return 1.0;
		else
			return 0.0;
	}

	if(%client.burnTime > 0) 
		return 1.0;

	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if ((%lastTime + 1.5) < %time) 
  	{
		return 0.0;
	} 
	else 
	{
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
   	}
}
function PlayerRespawnDelayed(%client, %time)
{
	if (%time > 0)
	{
		%time--;
		schedule("PlayerRespawnDelayed(" @ %client @", " @ %time @ ");",1.0);
		centerPrint (%client, "<jc><f1>** <f2>" @ %time + 1 @ "<f1> seconds before you can respawn ** ", 1);
		return;
	}

	else
	{
		centerPrint (%client, "<jc><f1>Press your trigger to respawn", 3);
		return;
	}
}


function Player::jump(%this,%mom)
{
 	%cl = GameBase::getControlClient(%this);
	if(%this.isafk){
		%this.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%this)@" is now back and may be hurt");
		
	}

	if(%cl != -1)
   	{
		if(%this.isafk){
		%this.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%this)@" is now back and may be hurt");
		
	}
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
	if(%client.isafk){
		%clientId.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%clientId)@" is now back and may be hurt");
		
	}

   %player = Client::getOwnedObject(%client);
   %armor = Player::getArmor(%player);
   if(!$matchStarted || %client.permap || %client.spkill || %client.dan)
      return;
	if(%client.possessing) {
		(%client.poss).free = true;
		remoteKill(%client.poss);
		return;
	}
	if(%client.possessed && !%client.free || %armor =="parmor") {
		Client::sendMessage(%client, 1, "You cannot kill yourself while possessed or cursed.~waccess_denied.wav");
		return;
	}
	%cl.free = false;
   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
	   playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
	   PlayerRespawnDelayed(%client, $Meltdown::SpawnDelay);
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
		{	Client::SendMessage(%clientId,1,"Go get a Turret Control Pack!");			
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

	%pack = Player::getMountedItem(%player,$BackpackSlot);
	%playerId = Player::getClient(%player);
	if(%pack == "TargPack" || %pack == "AODCmdPack")
	{ 
	}
	else
	{
		if (%player.EMPEffect != "true") 
		{
			Client::sendMessage(%clientId,1,"You hit yourself with an EMP!~werror_message");
			Client::sendMessage(%clientId,1,"Electrical malfunction detected.. Running suit Auto-Repair~waaodsfx53.wav"); 
			GameBase::setRechargeRate(%player,0);
			%player.EMPEffect = "true";
			$empTime[%clientId] = 100;
			if(Player::getMountedItem(%player, $BackPackSlot) == "GravFieldPack") 
			{
				$empTime[%clientId] += 100;
			}
		} 
		else
		{
			$empTime[%clientId] += 50;
		}
		DrainZAP(%clientId, %player); 
	}	
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
	if(%player.poisoned != "true")
	{
	%player.poisoned = true;
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	%playerId = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	if(%pack == "TargPack" || %armor == "larmor" || %armor == "lfemale")

	{}
	else
	{
		Client::sendMessage(%clientId,1,"You're Infected with the Ebola Virus!");
		if($poisonTime[%clientId] == 0)
		{
		
			Player::setDamageFlash(%player,0.25);
			$poisonTime[%clientId] = 250;
			checkPlayerBurn2(%clientId, %player);
		}
		else
			$poison[%clientId] += 35;
	}
}
}

function checkPlayerBurn2(%clientId, %player)
{
	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 1;  
		%drrate = GameBase::getDamageLevel(%player) + 0.0075;
			%vel = Item::getVelocity(%player); 
			%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			Projectile::spawnProjectile("Onpoison",%trans,%player,%vel,%player);
		
		if(!Player::isDead(%player)) 
		{
		GameBase::setDamageLevel(%player, %drrate);  
		Player::setDamageFlash(%player,0.25);  
			if(Player::isDead(%player))
			{
				%player.poisoned = true;
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
		schedule("checkPlayerBurn2(" @ %clientId @ ", " @ %player @ ");",0.1,%player);
      }
	else
	{
		%player.poisoned = false;
		Client::sendMessage(%clientId,3,"You have been cured but be careful of monkeys in future!. ~wfemale1.wtautn11.wav");
	}			
}

function BurnTheFlesh(%clientId, %player)
{
      if(%player.burn != "true")
	{
      %player.burn = true;
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	%playerId = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	if(%pack == "TargPack" || %armor == "larmor" || %armor == "lfemale")

	{}
	else
	{
		Client::sendMessage(%clientId,1,"You're on fire!");
		if($burnTime[%clientId] == 0)
		{
	
			Player::setDamageFlash(%player,0.25);
			$burnTime[%clientId] = 60;
			checkPlayerBurn(%clientId, %player);
		}
		else
			$burnTime[%clientId] += 15;
	}
}

}
function checkPlayerBurn(%clientId, %player)
{
	if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 1;  
		%drrate = GameBase::getDamageLevel(%player) + 0.005;
			%vel = Item::getVelocity(%player); 
			%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			Projectile::spawnProjectile("OnFire",%trans,%player,%vel,%player);
            %item = Player::getMountedItem(%player,$WeaponSlot); 
		%itemB = Player::getMountedItem(%player,$ExtraWeaponSlotB); 
		%rnd = floor(getRandom() * 1000);
		if(%rnd > 995)
		{
			if(%item != -1)
			{
				Player::decItemCount(%player,%item);
		  		Client::sendMessage(%clientId,3,"Your "@ %item.description @" has been melted by super-hot molten plasma! ~wfloat_target.wav");
				if(%itemB != -1)
				{
					Player::unmountItem(%player,$ExtraWeaponSlotB); 
				}
			}
		}

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
		%player.burn = false;
		Client::sendMessage(%clientId,3,"Your internal extinguishers put out the fire. ~wfemale1.wtaunt1.wav");
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
function Gundam::Health(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

		gameBase::setAutoRepairRate(%player, 1.10);
		Client::sendMessage(Player::getClient(%player),3,"Gundam AutoRepair Activated");

	if($healthTime[%clientId] == 0)
	{
		$healthTime[%clientId] = 20;
		checkPlayerHealth(%clientId, %player);
	}
	else
	{
		$healthTime[%clientId] = 20;
	}
}


function checkPlayerHealth(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if(%armor == "marmor" || %armor == "mfemale")
	{
		if($healthTime[%clientId] > 0)
		{
			$healthTime[%clientId] -= 2;  
			schedule("checkPlayerHealth(" @ %clientId @ ", " @ %player @ ");",2,%player);
	    	}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Gundam AutoRepair OFF");
			gameBase::setAutoRepairRate(%player, 0.01);
			GameBase::playSound(%player,ForceFieldClose,0);	
		}			
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),1,"Gundam AutoRepair OFF");
		gameBase::setAutoRepairRate(%player, 0);
		GameBase::playSound(%player,ForceFieldClose,0);	
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
	%rate = Player::getSensorSupression(%player) + 300;
	Player::setSensorSupression(%player,%rate);
		Client::sendMessage(Player::getClient(%player),3,"Gundam Cloaking Activated");
	
	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else
	{
		$cloakTime[%clientId] = 40;
	}
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if (%armor == "BlastechM" || %armor == "BlastechF")
	{
		if($cloakTime[%clientId] > 0)
		{
			$cloakTime[%clientId] -= 2;  
			schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
	    	}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Gundam Cloak OFF");
			%clientid.beaconCloak = false;
			GameBase::playSound(%player,ForceFieldClose,0);
			GameBase::startFadein(%player);
			%rate = Player::getSensorSupression(%player) - 300;
			Player::setSensorSupression(%player,0);
		 	$cloaked[%player] = 0;
 			Cloaker(%player);
		}
	}
	else
	{
			Client::sendMessage(Player::getClient(%player),1,"Gundam Cloak OFF");
			%clientid.beaconCloak = false;
			GameBase::playSound(%player,ForceFieldClose,0);
			GameBase::startFadein(%player);
			%rate = Player::getSensorSupression(%player) - 1;
			Player::setSensorSupression(%player,0);
		 	$cloaked[%player] = 0;
 			Cloaker(%player);
	}		
}
function Admin::Cloak(%clientId, %player, %time)
{
	%clientid.beaconCloak = true;
	%armor = Player::getArmor(%player);
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
 	$cloaked[%player] = 1;
 	Cloaker(%player);
	%rate = Player::getSensorSupression(%player) + 300;
	Player::setSensorSupression(%player,%rate);
	client::sendmessage(%clientId,3,"You are now cloaked. Please Dont Abuse");
	
	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = %time;
		checkAdminCloak(%clientId, %player);
	}
	else
	{
		$cloakTime[%clientId] = %time;
	}
}


function checkAdminCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	
		if($cloakTime[%clientId] > 0)
		{
			$cloakTime[%clientId] -= 2;  
			schedule("checkAdminCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
	    	}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"You are now Visible");
			%clientid.beaconCloak = false;
			GameBase::playSound(%player,ForceFieldClose,0);
			GameBase::startFadein(%player);
			%rate = Player::getSensorSupression(%player) - 300;
			Player::setSensorSupression(%player,0);
		 	$cloaked[%player] = 0;
 			Cloaker(%player);
		}
	
	
}

function Gundam::Shield(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

                %player.shieldStrength = 0.3;
		Client::sendMessage(Player::getClient(%player),3,"Gundam Shield Activated");

	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
	{
		$shieldTime[%clientId] = 20;
	}
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if (%armor == "larmor" || %armor == "lfemale")
	{
		if($shieldTime[%clientId] > 0)
		{
			$shieldTime[%clientId] -= 2;  
			schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Gundam Shield OFF");
			%player.shieldStrength = 0;
			GameBase::playSound(%player,ForceFieldClose,0);	
		}			
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),1,"Gundam Shield OFF");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldClose,0);	
	}
}

function Admin::Shield(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
      %player.shieldStrength = 999.3;
	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin.");
	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 30;
		checkPlayerShieldadmin(%clientId, %player);
	}
	else
	{
		$shieldTime[%clientId] = 30;
	}
}
function Admin::imo1(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
      %player.shieldStrength = 999.3;
	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin.");
	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 60;
		checkPlayerShieldadmin(%clientId, %player);
	}
	else
	{
		$shieldTime[%clientId] = 60;
	}
}
function Admin::imo2(%clientId, %player)
{
	GameBase::playSound(%player,ForceFieldOpen,0);
      %player.shieldStrength = 999.3;
	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin.");
	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 120;
		checkPlayerShieldadmin(%clientId, %player);
	}
	else
	{
		$shieldTime[%clientId] = 120;
	}
}


function checkPlayerShieldadmin(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	
		if($shieldTime[%clientId] > 0)
		{
			echo("REDUCING SHIELD TIME");
			$shieldTime[%clientId] -= 2;  
			schedule("checkPlayerShieldadmin(" @ %clientId @ ", " @ %player @ ");",2,%player);
    		}
		else
		{
			bottomprint(Player::getClient(%player),"<jc><f0>Y O U  A R E  M O R T A L  A G A I N");
			messageall(1, Client::getName(%clientId) @ " is now mortal again!");
			%player.shieldStrength = 0;
			echo("Shield Inactive");
			GameBase::playSound(%player,ForceFieldClose,0);	
		}			
	}
	


	

function initSFXShow(%this)
{
	GameBase::setRechargeRate(%this,10);
	%armor = Player::getArmor(%this);
//	%damage = %armor.maxDamage - 0.001;
//	GameBase::setDamageLevel(%this, %damage);
	GameBase::setAutoRepairRate(%this, 0.15);
//	GameBase::setAutoRepairRate(%this, %damage / 8);
	%this.respawning = true;
	sfxShow(%this, $Meltdown::RespawnEffectTime);
// 	%client = Player::getClient(%this);
//	%client.isPrisoner = false;
}

function sfxShow(%player, %setTime, %time)
{
   if(%time > %setTime || %time < 0)
   {
	%setTime = 0;
	GameBase::setRechargeRate(%player,10);
//	GameBase::setRechargeRate(%player,8);
	%player.respawning = false;
	GameBase::setAutoRepairRate(%player, 0.001);
//	GameBase::setAutoRepairRate(%player, 0);
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
