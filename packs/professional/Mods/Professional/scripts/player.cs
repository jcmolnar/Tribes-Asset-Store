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
	//$died[%cl]=1;
	$TeleUsed[%this] = false;
   	$empTime[%cl] = 0;
	%cl.dead = 1;
	//Client::sendMessage(Player::getClient(%this),1,"You Are Dead");
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
      
      if ($match = "True") 
      {
      	schedule("MakeBlind(" @ %this @ " ," @ %cl @ ");",2);
      }
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) 
	{
      		%objTeam=gamebase::getteam(%object);
		%playerteam=Gamebase::getteam(%this);
      		if(Player::getArmor(%this)=="botarmor" && %objTeam != %playerteam)
      		{
      			if(%type != $MeteorDamageType && %type != $SolarFlareDamageType && %type != $LightningDamageType && %type != $EMPLightningDamageType && %type != $NullDamageType)
      			{
      				%botname = Client::getName(%this);
      				%aggressor = Client::getOwnedObject(%object);
      				%targettype = "player";
      				echo("This bot (" @ %this @ ") has been shot. " @ %botname @ " by " @ %aggressor);
      				echo("$aiName[] = " @ $ai[%this]);
      				echo("Damage Type: " @ %type);
      				AI::leech(%aggressor,$ai[%this],%targettype);
      			}
      		}
      		%damagedClient = Player::getClient(%this);
      		%shooterClient = %object;
      		%oldpack = Player::getMountedItem(%damagedclient,$BackpackSlot);
		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient)) 
		{
			if (%shooterClient != -1) 
			{
				%curTime = getSimTime();
			   	if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
			   	{
					if(!$aiTrue[%damagedclient])
					{
						if(%type != $MineDamageType  && %type != $NullDamageType) 
						{
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else if(%type != $NullDamageType) 
						{
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
						%this.LastHarm = %shooterClient;
						%this.DamageStamp = %curTime;
					}
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	

		if (!Player::isDead(%this)) 
		{
			%armor = Player::getArmor(%this);
			
			//More damage applyed to head shots
			if(%vertPos == "head" ) 
			{
				if(%armor == "harmor") 
				{ 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 
					{
						if (%type == $LaserDamageType || %type == $MarlinDamageType) %value += (%value * 0.5);
						%value += (%value * 0.3);
					}
				}
				else 
				{
					if (%type == $LaserDamageType || %type == $MarlinDamageType) %value += (%value * 0.4);
					%value += (%value * 0.2);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) 
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) 
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else 
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
			if (%type == $EMPDamageType) ixStartEMP(%damagedClient, %this, %shooterClient, %type); // EMP stuff from Havoc
  			if (%type == $EMPLightningDamageType) LightningEMP(%damagedClient, %this, %shooterClient, %type);
  			if (%value) 
  			{
				%armor = Player::getArmor(%this);
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            			%dlevel = GameBase::getDamageLevel(%this) + %value;
            			%spillOver = %dlevel - %armor.maxDamage;
            			
            			if (%spillOver >= 0)
            			{
            				//$died[%damagedclient]=1;
            				%player = Client::getOwnedObject(%damagedclient);
            				if (%armor = "hlarmor" || %armor ="hlfemale") GameBase::setAutoRepairRate(%player, 0);
            				%pack = Player::getMountedItem(%damagedclient,$BackpackSlot);
            				if (%pack == "TeleportPack")
            				{
            					$TeleUsed[%player] = false;
            				}
            				if(%pack == "KamikazePack")
					{
						Client::sendMessage(%damagedclient,1,"Kamikaze Pack Initialized!!!");
						$KamikazeIsActive[%damagedclient] = "true";
						KamikazePackCount(%damagedclient);
						Player::trigger(%damagedclient,$BackpackSlot,false);
					}
            			}
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) 
				{ 
					if(%damagedClient.lastDamage < getSimTime()) 
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
			
				else 
				{
               				if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) 
               				{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
								Player::dropItem(%this,%weaponType);
                				Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) 
						{
						  	if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") 
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") 
						{
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") 
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					//Client::sendMessage(Player::getClient(%this),1,"You Are Dead - before call to ClientOnKilled");
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
		//Client::sendMessage(Player::getClient(%this),1,"You Are Dead - after call to ClientOnKilled");
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this)) 
	{
		if (getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) 
			{
				%count = Player::getItemCount(%this,%i);
				%name = getItemData(%i);
				if (%name.className != Grenade)
				{
					if (%count) 
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);
						if (%delta > 0) 
						{
							Player::decItemCount(%this,%i,%delta);
							%sound = true;
						}
					}
				}
				else 
				{
					%ObjGrenadeCount = Player::getItemClassCount(%object,Grenade);
					%ObjCount = Player::getItemCount(%object,%name);
					if(%ObjCount > 0 || %ObjGrenadeCount == 0)
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);
						Player::setItemCount(%object,Grenade, Player::getItemCount(%object, %name));
						if (%delta > 0) 
						{
							Player::decItemCount(%this,%i,%delta);
							%sound = true;
						}
					}
				}
			}
			if (%sound) 
			{
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	else
	{
		//%name = Item::getItemData(%object);
		//Client::sendMessage(Player::getClient(%this),1,"You collided with " @ getObjectType(%object) @ " called " @ %name);
		if (getObjectType(%object) == "Player")
		{
			%objTeam=gamebase::getteam(%object);
			%playerteam=Gamebase::getteam(%this);
			if(Player::getArmor(%object)=="botarmor" && %objTeam != %playerteam)
			{
				%client=Player::getClient(%this);
				%bot=Player::getClient(%object);
				//remotekill(%client);
				$KamikazeIsActive[%bot] = "true";
				KamikazePackCount(%bot);
				Player::trigger(%bot,$BackpackSlot,false);
				//remotekill(%bot);
			}
		}
	}
}

function Player::getHeatFactor(%this)
{
      if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") 
		return 0.0;
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
   //$died[%client]=1;
   $TeleUsed[%player] = false;
   $empTime[%client] = 0;
   $PenaltyTime[%client] = getSimTime() + $SuicideSpawnPenaltyTime;
   $Suicided[%client] = 1;
      if ($match == "True") schedule ("Client::sendMessage(" @ %client @ ",0,\"Suicide Penalty has expired\");",$SuicideSpawnPenaltyTime);	// PORT: was %clientId (not set here)
   if ($match == "True") bottomprint(%client, "<jc>Suicide Penalty of " @ $SuicideSpawnPenaltyTime @ " seconds initiated.", $SuicideSpawnPenaltyTime);
   //Client::sendMessage(%client,0,"Suicide Penalty of " @ $SuicideSpawnPenaltyTime @ " seconds initiated.");
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
	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableRocket && %name != DeployableELFTurret && %name != DeployableFlak && %name != DeployableDoB && %name != DeployableConTurret)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
%player = Client::getOwnedObject(%clientId);
if(Player::getMountedItem(%player,$BackpackSlot) != Laptop)
{
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station or Laptop to control turrets");
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

//EMP Stuff from Havoc

function ixStartEMP(%clientId, %player, %shooter, %type) 
{ 
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(($WeaponAmmo[%weapon] == "")) Player::unmountItem(%player,$WeaponSlot);
	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " has short-circuited your energy system");
	else Client::sendMessage(%clientId,1,"Your energy system has shut down");
 	playSound(SoundEMPDrain,GameBase::getPosition(%player));
 	if($empTime[%clientId] == 0) 
	{
		%recharge = GameBase::getRechargeRate(%player)-60;
		echo("Recharge rate client " @ %clientId @ " is " @ %recharge);
		GameBase::setRechargeRate(%player,%recharge);
 		GameBase::setEnergy(%player,0);
 		%armor = Player::getArmor(%clientId);
 		if (%armor == "darmor" || %armor == "harmor" ) 
		{ 
			$empTime[%clientId] = 7;
 		}
 		else if (%armor == "dmarmor" || %armor == "dmfemale") 
		{
			$empTime[%clientId] = 7;
 		}
 		else 
		{
			$empTime[%clientId] = 9;
 		}
 		checkPlayerEMP(%clientId, %player);
 	}
 	else $empTime[%clientId] = 9;
 }

 function checkPlayerEMP(%clientId, %player) 
{ 
	if($empTime[%clientId] > 0) 
	{
		%vel = Item::getVelocity(%player);
 		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 		Projectile::spawnProjectile("EMPShock",%trans,%player,%vel,%player);
 		$empTime[%clientId] -= 1;
 		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",1,%player);
 	}
 	else 
	{
	Client::sendMessage(%clientId,1,"Energy system has restabilized");
	%recharge = GameBase::getRechargeRate(%player)+60;
	GameBase::setRechargeRate(%player,%recharge);
	echo("Rcharge rate client " @ %clientId @ " is " @ %recharge);
	//if ($shieldEnhanced[%clientId]==1) GameBase::setRechargeRate(%player,23);
	//else GameBase::setRechargeRate(%player,8);
	
 	}
 }

function LightningEMP(%clientId, %player, %shooter, %type) 
{ 
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(($WeaponAmmo[%weapon] == "")) Player::unmountItem(%player,$WeaponSlot);
	if(%clientId != %shooter) Client::sendMessage(%clientId,1,"Lightning has short-circuited your energy system");
	else Client::sendMessage(%clientId,1,"Lightning has short-circuited your energy system");
 	playSound(SoundEMPDrain,GameBase::getPosition(%player));
 	if($empTime[%clientId] == 0) 
	{
		%recharge = GameBase::getRechargeRate(%player)-60;
		GameBase::setRechargeRate(%player,%recharge);
 		GameBase::setEnergy(%player,0);
 		%armor = Player::getArmor(%clientId);
 		if (%armor == "darmor" || %armor == "harmor" ) 
		{ 
			$empTime[%clientId] = 7;
 		}
 		else if (%armor == "dmarmor" || %armor == "dmfemale") 
		{
			$empTime[%clientId] = 7;
 		}
 		else 
		{
			$empTime[%clientId] = 9;
 		}
 		checkPlayerEMP(%clientId, %player);
 	}
 	else $empTime[%clientId] = 9;
 }
 
 function MakeBlind(%this, %cl)
 {
 	%pos = Gamebase::GetPosition(%this);
	%offset = "0 0 1000";
	%posnew = vector::add(%pos,%offset);
	%camera = newObject("Camera","Turret",DeployableLaser,true);
	GameBase::setPosition(%camera, %posnew);
	Observer::setOrbitObject(%cl, %camera, 5, 5, 5);
      	deleteObject(%camera);
 }
