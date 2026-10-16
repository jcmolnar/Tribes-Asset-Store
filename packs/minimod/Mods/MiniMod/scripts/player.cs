MiniMod::MonitorFile(start, "objectives.cs", "SpoonBot's enhanced player.cs file");

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
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
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

// Whole function modified - Wicked69
			
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	
		%damagedClient = Player::getClient(%this);

// Make sure that bots dont attack a dead client AI or otherwise !

 	//if (Player::isExposed(%this)) {
	

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

		%shooterObj = Client::getControlObject(%shooterClient);

		if ((Player::isAIControlled(%damagedClient) == True)	&&			//===== Determines if player is A.I. (by EMO1313, added by Werewolf)
			(%damagedClient != %shooterClient))	
		{

//			schedule("AI::RandomEvade(" @ %aiId @ ");", 1);
//			schedule("AI::RandomEvade(" @ %aiId @ ");", 3);
//			schedule("AI::RandomEvade(" @ %aiId @ ");", 4);



if ($Spoonbot::DebugMode)
 echo ("DAMAGE Damaged bot " @ %damagedClient);
if ($Spoonbot::DebugMode)
 echo ("DAMAGE shooting object " @ %object);
if ($Spoonbot::DebugMode)
 echo ("DAMAGE shooting object is a " @ GameBase::getDataName(%object));
if ($Spoonbot::DebugMode)
 echo ("DAMAGE bot jetting is " @ $Spoonbot::BotJetting[%damagedClient]);



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

  					BotFuncs::AddAttacker(%aiId,%nearestid,150,1);
					//BotThink::Think(%aiId, False);
				}
//				return 0;        //This caused the AI players to NOT take any damage!!
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
			if(%vertPos == "head" && %type == $LaserDamageType) {
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
	//}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{

if ($Spoonbot::DebugMode)
 echo ("ONCOLLISION: Collision between a " @ GameBase::getDataName(%this) @ " and a "@ GameBase::getDataName(%object));

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
//
//		Player::setItemCount(%aiId,RepairKit,1);        //The old stuff by Wicked69 caused the bots to drop medikits when they
//	    Player::dropItem(%aiId, "repairkit");		//collided with a human teammate or turret.
//		Player::setItemCount(%aiId,RepairKit,1);
//
//
//								//New medi stuff by Werewolf. Causes object to be repaired.
//								//Note that this leads to an interesting effect:
//								//When a bot's repairing a turret, only the repair code in BotFuncs.cs is
//								//being executed. But if the bot collides with the turret, this code will
//								//be called ADDITIONALLY, thus speeding up the repair.
		%repairRate = 0.1;
		%damage = GameBase::getDamageLevel(%object);

if ($Spoonbot::DebugMode)
echo ("ONCOLLISION REPAIRING = Object Damage = " @ %damage);

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

		
//=============================================================== Class Specific - Medic
		
		if(BotTypes::IsMedic(%aiName) == 1)
		{
			if (%aiTeam == %objTeam)
			{
//				BotFuncs::GiveRepairKit(%Player1, %Player2);


			}
		}

		%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
		%aiLoc = GameBase::getPosition(Client::getOwnedObject(%this));
		%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%this)); 

//		Vehicle::passengerJump(0,%this,0);  //Crude way to make bots avoid obstacles, or as in this case: other players.

//============================================================================================================== Attempt Object Move Around

		if(  (GameBase::testPosition(%aiId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
		{	
			// echo("BOT: Colide With Object");
			//&& (getObjectType(%object) != "Player")
//========================================================================================================= Try to move AI outta the way...


// All previous stuff obsolete (i hope), since RandomEvade can do the evading for us.

AI::RandomEvade(%aiId);

		}
		else
        {
			echo ( %aiId @ " Can not avoid...");
		}
//================================================================================================================== End AI Collision





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

function Player::getHeatFactor(%this)
{
	%client = Player::getClient(%this);
//	if (Client::getControlObject(%client) != %this)

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

MiniMod::MonitorFile(stop, "objectives.cs", "SpoonBot's enhanced player.cs file");
