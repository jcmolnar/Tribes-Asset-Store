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

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		if(%damagedClient.isTk || %damagedClient.Litch) //<--Apply friendfire if Litch or TK'er
				%friendFire = 1.0;
		else if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == -1)
				%friendFire = 1.0;
		else if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) && (!%shooterClient.Undead || !%damagedClient.Undead)) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0 && !%damagedClient.Litch && !%damagedClient.isTk) {
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
	else if (%damagedClient.Undead || %shooterClient.Undead || %damagedClient.Litch || %damagedClient.isTk)  //<--Additional Friendfire if Litch, Undead or TK'er
			%friendFire = 1.0;
	else if((%type == $ImpactDamageType) && (Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient))) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	

		if (!Player::isDead(%this)) {
			if(%shooterClient.charged && %type != $ImpactDamageType && %type != $LandingDamageType) //<--Extra Damage IF
			{
			//messageall(0,"Extra Damage");
			%value += 0.3;
			}
			//messageall(0,"Damage Value == "@%value);
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {   //<--Extra Damage for Laser head shots
				if(%armor == "palarmor" || %armor == "lavarmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.4);
					}
				}
				else {
					%value += (%value * 0.4);
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
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				
				//If DamageType is Reincarnate - Calls Reincarnate Function
				if (%type == $ReincarnateDamageType)
				{
					%shooterClient.scoreKills--;
					//Client::SendMessage(%shooterClient,0,"Hit with Reincarnate.");
					Player::Reincarnate(%damagedClient, %shooterCilent, %type);
					Game::reincarnateKillPoints(%damagedClient, %shooterClient);
				}
				//If Hit with Stasis - Change to StasisArmor
				if (%type == $StasisDamageType)
				{
					%armor = Player::getArmor(%damagedClient);
					if(%armor == harmor)
					return;
						
						Player::setArmor(%damagedClient, "harmor");
						//Client::SendMessage(%shooterClient,0,"Function Passed Okay");
						Client::SendMessage(%damagedClient,0,"You've been hit with Stasis!");
						schedule("Player::setArmor("@ %damagedClient @", "@ %armor @");",4);
						schedule("UnstasisMsg("@ %damagedClient @");",4);
					
				}
				//If hit with Tagger <--Not used at 2.0
				if(%type == $TaggerDamageType)
				{
					%target = Client::getOwnedObject(%damagedClient);
					GameBase::setIsTarget(%target,True);
					//schedule("Player::unmountItem("@%damagedClient@",2);",%damagedClient,45);
				}

				if(%type == $HealDamageType)  //<--Heal shot from Cleric Armor
				{
					HealSpell(%damagedClient, %shooterClient);
				}

				if(%type == $ShieldDamageType) //<--Shield Spell from Mage
				{
					SetShield(%damagedClient,%shooterClient,%this);
					//messageall(0,"Shield Damage type.");
				}
				
				if(%type == $EmpDamageType)  //<--EMP damage
				{
					HitEmp(%damagedClient,%shooterClient,%this);
				}
				if(%type == $GiveDamageType) //<--Bless from Cleric
					Bless(%damagedClient,%shooterClient);
				if(%type == $EvilDamageType) //<--If hit with Undead Curse from Litch
					Undead(%damagedClient, %shooterClient);
				if(%type == $DisarmDamageType) //<--Disarmer Damage
					{
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
					}
	
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
					
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type == $AnnDamageType || %type == $HammerDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $AnnDamageType || %type == $HammerDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
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
	   Client::onKilled(%client,%client,$SuicideDamageType); //<--Suicide Damage play Suicide Damage death messages
		%client.scoreCtrlK++;
	if(%client.scoreCtrlK == 5)
	{
Client::sendMessage(%client,1,"Your obsession with death has caused you to become a Ghost!");  //<--If CTRL-K's are being counted
	%client.isGhost = true;
	%client.score -= 4;
	}

   }
Game::refreshClientScore(%client);
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
	//%clientId.Satcom = false;
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }
	%sat = newObject("sat", SimSet);
	%pos = GameBase::getPosition(%clientId);
	%num = containerBoxFillSet(%sat,$StaticObjectType,%pos,10,10,5,0);
	%clteam = GameBase::getTeam(%clientId);
	if(%num > 0)
		{
		for(%count = 0; %index != -1; %count++)  //<--Satcom Control Functions
			{
			%index = Group::getObject(%sat, %count);
			if(%index != -1)
		 		{
				%name = GameBase::getDataName(%index);
				//messageall(0,"Object number "@%count@" is a "@%name);
				%team = GameBase::getTeam(%index);
				if(%name == "DeployableSatCom" && %team == %clteam)   //397
					%clientId.CommandTag = 1;
					else
					%clientId.CommandTag = "";
				}
			}
		}
	else
		%clientId.CommandTag = "";
	deleteObject(%sat);
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
	if(%name != CameraTurret && %name != DeployableTurret && %name != DepPlasmaTurret && %name != DeployableVulcTurret && %name != DeployableTurret && %name != DepStutterTurret && %name != DaHammerTurret && %name == RocketTurret) //<--List of controllable Turret types 
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats && !%clientId.CommandTag) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station or SatCom Unit to control turrets");
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
	%clientId.CommandTag = "";
   }
}

function Player::Reincarnate(%damagedClient, %shooterClient, %type)
{
	%pl = Player::getClient(%damagedClient);  //<--Blow up Player and drop held weapon
Player::trigger(%pl, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%pl,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%pl,%weaponType);
                	Player::blowUp(%pl);

	%killer = Player::getClient(%shooterClient);
	//Client::SendMessage(%pl,0,"Function is passed okay."); 
	//remoteKill(%pl);
	Player::kill(%pl);
}

function UnstasisMsg(%damagedClient)
{
	//Player::setArmor(%damagedClient, %armor);
	Client::SendMessage(%damagedClient,0,"You are free from Stasis.");
}

function SetShield(%damagedClient,%shooterClient,%player)
{
	//messageall(0,"Hit with Shield passed okay");
if(Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
	return;
if(%damagedClient == %shooterClient)
	return;
else if((Player::getArmor(%damagedClient) == magarmor || Player::getArmor(%damagedClient) == magfemale) && (%damagedClient != %shooterClient))
	{
	Client::sendMessage(%shooterClient,0,"Cannot effect other Mages with Shield Spell.");
	return;
	}
else
	%player.shieldStrength = 0.012;
		Client::sendMessage(%damagedClient,0,Client::getName(%shooterClient) @" has shielded you!");
		schedule("EndShield("@%damagedClient@","@%shooterClient@","@%player@");",30,%damagedClient);
	}

function EndShield(%damagedClient,%shooterClient,%player)
{
	%player.shieldStrength = 0;
	Client::sendMessage(%damagedClient,0,"You are no longer shielded.");
	Client::sendMessage(%shooterClient,0,"Shield for "@Client::getName(%damagedClient)@" has dissipated.");
}	


function HitEmp(%damagedClient,%shooterClient,%player)
{
	if(!%shooterClient)
		Client::sendMessage(%damagedClient,0,"Your energy has been discharged!");
	else if(%damagedClient != %shooterClient)
		Client::sendMessage(%damagedClient,0,Client::getName(%shooterClient) @ " has discharged your energy!");
	else
		Client::sendMessage(%damagedClient,0,"You've discharged your own energy!");
	%Srate = GameBase::getRechargeRate(%player);
					%energy = GameBase::getEnergy(%player);
					%time = 6;
//messageall(0,"Recharge rate is "@%Srate@". Energy is "@%energy@".");
					if(%energy <= -120)
					GameBase::setEnergy(%player,-120);
					else if(%energy == 0)
					GameBase::setEnergy(%player, %energy - 40);
					else
					GameBase::setEnergy(%player,0);
					GameBase::setRechargeRate(%player,0);
					Player::unmountItem(%player,$WeaponSlot);
//messageall(0,"Now energy is "@GameBase::getEnergy(%player)@".");
					//schedule("GameBase::setEnergy("@ %player @","@ %energy @");",6,%player);
					schedule("GameBase::setRechargeRate("@ %player @",8);",%time,%player);
	}

function Undead(%victim, %shooter)
{
	//messageall(0,"Undead Function");
	if(%victim.Undead)
	{
	Client::sendMessage(%shooter,0,"Player is already Undead");
	return;
	}
else if(Player::getArmor(%victim) == palarmor)
	{
	Client::sendMessage(%shooter,0,"Cannot affect Paladin Armor!");
	Client::sendMessage(%victim,0,"A Litch has tried to turn you into the Undead!");
	return;
	}
else if(Client::getName(%victim) == $Chivalry::Paladin || Client::getName(%victim) == $Chivalry::Warlord)
	{
	Client::sendMessage(%shooter,0,"Cannot affect the Warlord or Paladin with Undead!");
	Client::sendMessage(%victim,0,"A Litch has tried to turn you into the Undead!");
	return;
	}
else if(Player::getArmor(%victim) == clrarmor || Player::getArmor(%victim) == clrfemale)
	{
	Client::sendMessage(%shooter,0,"Cannot affect Cleric Armor!");
	Client::sendMessage(%victim,0,"A Litch has tried to turn you into the Undead!");
	return;
	}
else
	%sname = Client::getName(%shooter);
	Client::sendMessage(%victim,0,"The Litch King has slain you and turned you into one of the Undead!");
	%victim.Undead = true;
	%name = Client::getName(%victim);
	echo("PLAYER:  "@%sname@" has made "@%name@" Undead");
	//messageall(0,%name@" has been slain and turned Undead!");
	%pl = Player::getClient(%victim);
	%cl = Client::getOwnedObject(%victim);
	%vel = Item::getVelocity(%cl);
	%trans = GameBase::getMuzzleTransform(%cl);
	Projectile::spawnProjectile("ShockwvShell",%trans,%cl,%vel);
Player::trigger(%pl, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%pl,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%pl,%weaponType);
                	Player::blowUp(%pl);

	Player::kill(%pl);

}

function HealSpell(%victim, %shooter)
{
	%obj = Client::getOwnedObject(%victim);
	if(!%victim.Undead && !%victim.Litch)
	{
		Client::sendMessage(%victim,0,"You have been healed by "@ Client::getName(%shooter));
		GameBase::repairDamage(%obj,0.4);
	}
	else if(%victim.Litch || %victim.Undead)
	{
		//messageall(0,"The Litch has been hurt by the powers of Healing");
		Player::setDamageFlash(%victim,0.4);
		GameBase::setDamageLevel(%obj,GameBase::getDamageLevel(%obj) + 0.2);
		if(%victim.Undead)
		GameBase::setAutoRepairRate(%obj,0);
	}
}

function TurnUndead(%victim, %shooter, %this)
{
	if(%victim.Undead || %victim.Litch)
	{
		%obj = Client::getOwnedObject(%victim);
		Player::setDamageFlash(%victim, 1);
		GameBase::setDamageLevel(%obj,GameBase::getDamageLevel(%obj) + 1);
		//messageall(0,"Undead or Litch was damaged with Turn");
		if(Player::isDead(%this))
		Player::blowUp(%this);
	}
	//else
	//messageall(0,"No Litch or Undead within Radius");
}

function Bless(%victim, %shooter)
{
	if(GameBase::getTeam(%victim) == GameBase::getTeam(%shooter))
	{
		if(Player::getArmor(%victim) != clrarmor && Player::getArmor(%victim) != clrfemale)
		{
		%cl = Player::getClient(%victim);
		Client::SendMessage(%cl,0,Client::getName(%shooter)@" has Blessed you.");
		Player::setItemCount(%cl,HolyWeapon,1);
		}
		else
		Client::sendMessage(Player::getClient(%shooter),0,"Cannot bless other Clerics.");
	}
	else
	Client::sendMessage(Player::getClient(%shooter),0,"Cannot bless enemies!");
}