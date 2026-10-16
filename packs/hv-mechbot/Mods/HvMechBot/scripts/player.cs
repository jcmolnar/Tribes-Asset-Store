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
function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,10); //8 = Base value++++++++++++++++
}

function CheckClient (%client) 
{
	return !(%client.observerMode == "" || %client.observerMode == "pregame");
}

//-----------------------------------------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------------------------------------
function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

//-----------------------------------------------------------------------------------------------------------
function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	doneposs(%cl);//+++++++++++++++++++++++++
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		%dname = GameBase::getDataName(%this);
		if (%type != -1) {
			if (%i != $WeaponSlot || %dname != "Backpack" || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	doneposs(Player::getClient(%this));//+++++++++++++
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
      doneposs(%cl);//+++++++++++++++++++++++++++++
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

//-----------------------------------------------------------------------------------------------------------
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
						Client::sendMessage(%shooterClient,0,"You just harmed Lance-Mate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from Lance-Mate " @ Client::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Lance-Mate " @ Client::getName(%damagedClient) @ " with your Vibro-Mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Lance-Mate " @ Client::getName(%shooterClient) @ "'s Vibro-Mine!");
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

		if (!Player::isDead(%this))
		 {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && (%type == $SniperDamageType))
			 {
			%value += (%value * 1.0);//0.45++++++++++++++++
			 }
			else	if(%vertPos == "head" && (%type == $ACDamageType || %type == $GaussDamageType))
			 {
			%value += (%value * 0.45);//0.25++++++++++++++++
			 }//+++++++
			else	if(%vertPos == "head" && (%type == $GaussDamageType))
			 {
			%value += (%value * 0.60);//++++++++
			 }//+++++++
			else	if(%vertPos == "head" && (%type == $LaserDamageType))
			 {
			%value += (%value * 0.65);//++++++++
			if(%armor == "harmor" || %armor == "barmor")//+++++++
				 { 
				if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")	
					 {
						%value += (%value * 0.0); //0.3+++++++
					 }
				}
				else {
					%value += (%value * 0.3);//value for non-heavies?+++++++
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
//+++removed line for static number+++				%strength = %this.shieldStrength;
				%strength = 1.0;//++++added line for static number++++++
				if (%type == $ShrapnelDamageType)
					%strength *= 0.08; //+++++smaller number = less aborbtion+++++
				else if (%type == $GaussDamageType)//++++++++++++++++++++++++
					%strength *= 0.1;
				else if (%type == $ExplosionDamageType)//++++++++++++++++++++++++
					%strength *= 0.12;//good
				else if (%type == $PPCDamageType)//++++++++++++++++++++++++
					%strength *= 0.08;//good
				else if (%type == $FlamerDamageType)//++++++++++++++++++++++++
					%strength *= 0.0005;//good
				else if (%type == $MineDamageType)//++++++++++++++++++++++++
					%strength *= 0.22;//good
				else if (%type == $ACDamageType)//++++++++++++++++++++++++
					%strength *= 0.008;
				else if (%type == $LRMDamageType)//++++++++++++++++++++++++
					%strength *= 0.006;//good
				else if (%type == $BulletDamageType)//++++++++++++++++++++++
					%strength *= 0.004;
				else if (%type == $STRDamageType)//++++++++++++++++++++++++++++
					%strength *= 0.008;//good
				else if (%type == $MissileDamageType)//++++++++++++++++++++++++
					%strength *= 0.14;
				else if (%type == $InfernoDamageType)//++++++++++++++++++++++++
					%strength *= 0.006;//untested
				else if (%type == $SniperDamageType)//++++++++++++++++++++++++
					%strength *= 0.07;
				else if (%type == $LaserDamageType)//++++++++++++++++++++++++
					%strength *= 0.004;
				%absorb = 1.0 * %strength; //++++++++
				if (%value < %absorb) {
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					%value = %value - %absorb;
				}
			}
 if (%type == $InfernoDamageType) HV_InfernoHeat(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $FlamerDamageType) HV_FlamerHeat(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $PPCDamageType) HV_PPCStun(%damagedClient, %this, %shooterClient);//++++++++++++
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
				else 
				{
	               if(%spillOver > 0.25 && (%type== $PPCDamageType || %type == $MissileDamageType|| %type== $GaussDamageType))
					{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					//make explosion too, with "blow up"+++++++++++++++++++
					}
	               if(%spillOver > 0.01 && (%type== $ImpactDamageType))
					{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					//make explosion too, with "blow up"+++++++++++++++++++
					}
      	         if(%spillOver > 0.15 && (%type == $LaserDamageType || %type== $SniperDamageType))
				 	{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					//make explosion too, with "blow up"+++++++++++++++++++
					}
      	         if(%spillOver > 0.10 && (%type == $ShrapnelDamageType || %type == $PPCDamageType))
				 	{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					}
      	         if(%spillOver > 0.03 && (%type== $ExplosionDamageType || %type== $ACDamageType || %type== $LRMDamageType || %type== $STRDamageType))
				 	{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.10 && (%type== $ExplosionDamageType|| %type== $ACDamageType || %type == $ShrapnelDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
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

//-----------------------------------------------------------------------------------------------------------
function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

//-----------------------------------------------------------------------------------------------------------
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

		if ((%objTeam == %aiTeam) && ($Spoonbot::MedicTask[%aiId] == -1) && (%damage > 0))			//Only repair friendly stuff.
		{
			GameBase::setDamageLevel(%object, %newDamage);
			$SpoonBot::MedicBusy[%aiId] = 1;
			schedule("$SpoonBot::MedicBusy[%aiId] = 0;",2);
		}
	}
	if (Player::isAIControlled(%Player1) == "true"
			&& Player::isAIControlled(%Player2) == "true")
	{

		
//=============================================================== Class Specific - Medic
		
		if(BotTypes::IsMedic(%aiName) == 1)
		{
			if (%aiTeam == %objTeam)
			{
				BotFuncs::GiveRepairKit(%Player1, %Player2);
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

	if ((BotTypes::IsDemo(%aiName) == 1) && (BotFuncs::CheckForLOS(%aiId, $Spoonbot::DemoTarget[%aiId])))
	{
		AI::Evadeup(%aiId);
		schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
	}
	else
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
	if (Player::isDead(%this)) 
	{
		if (getObjectType(%object) == "Player")
		 {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) 
			{
				%count = Player::getItemCount(%this,%i);
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
			if (%sound)
			{
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	else
	%armor = Player::getArmor(%object);
	%velocity = Item::getVelocity(%player);
//	Vector::getDistance(%object, %this);//++++++
//	%velA = Item::getVelocity(%object);
//	%velB = Item::getVelocity(%this);
//	%veloA = Vector::normalize(%velA);
//	%veloB = Vector::normalize(%velB);
//	%velocity = %veloB - %veloA;
//	%velocity = %velB - %velA;
//	%velocity = %velB;
	   if (%velocity < 0)
		{
		%velocityB = %velocity * -1;
		}
	   else
		{
		%velocityB = %velocity * 1;
		}
	if (%armor == "larmor")
	{
		%impact = 0.020;
	}
	else if (%armor == "parmor")
	{
		%impact = 0.025;
	}
	else if (%armor == "carmor")
	{
		%impact = 0.030;
	}
	else if (%armor == "dmarmor")
	{
		%impact = 0.025;
	}
	else if (%armor == "marmor")
	{
		%impact = 0.035;
	}
	else if (%armor == "hbarmor")
	{
		%impact = 0.045;
	}
	else if (%armor == "aarmor")
	{
		%impact = 0.050;
	}
	else if (%armor == "barmor")
	{
		%impact = 0.060;
	}
	else if (%armor == "harmor")
	{
		%impact = 0.065;
	}
	if (getObjectType(%object) == "Player")
	{
	%mome = %velocityB; //  /8
	%impactB = %impact / 1;
//	%death = %impactB * %mome;
	%death = %mome;
//		GameBase::applyDamage(%this,$ImpactDamageType,%death,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);
//		GameBase::playSound(%this,debrisSmallExplosion,0);
	}
 }
}

//-----------------------------------------------------------------------------------------------------------
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
	else
	{
		return 0;
	}
}

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

//-----------------------------------------------------------------------------------------------------------
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
function remoteKill(%client, %player)
{
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::blowUp(%player);//++++
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
	   schedule("hvKamakazi(" @ %player @ ");",0);//++++++++++
   }
}

$animNumber = 25;	 
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}

//-----------------------------------------------------------------------------------------------------------
function Client::takeControl(%clientId, %objectId)
 {
	 if(%objectId == -1)
	 {
	 return;
	 }
	 if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
		 {
		 return;
		 }
	 if(GameBase::getControlClient(%objectId) != -1)
		 {
		 echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		 return;
		 }
	 %player = Client::getOwnedObject(%clientId);
	 %name = GameBase::getDataName(%objectId);
	 if(Player::getItemCount(%player, FCC) != 1)//++++++++++
//	 if(Player::getMountedItem(%player,$BackpackSlot) != FCCPod)
		 {
		 if (!(Client::getOwnedObject(%clientId)).CommandTag && %name != CameraTurret && !$TestCheats)
			{
			Client::SendMessage(%clientId,0,"Must be at a 'Command Station' or be equipped with a 'Fire-Control computer' to control Turrets");
			return;
		}
	}
	if(GameBase::getDamageState(%objectId) == "Enabled")
		 {
		 Client::setControlObject(%clientId, %objectId); 
		 Client::setGuiMode(%clientId, $GuiModePlay);
		 }
	 }

//-----------------------------------------------------------------------------------------------------------
function remoteCmdrMountObject(%clientId, %objectIdx)
{
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

//-----------------------------------------------------------------------------------------------------------
function Player::5(%this)
{
	Client::sendMessage(Player::getClient(%this), 1,"Recharge On~wMine_Act.wav");
	GameBase::setRechargeRate(%this,200);
}
function Player::6(%this)
{
	Client::sendMessage(Player::getClient(%this), 1,"Recharge Off~wMine_Act.wav");
	GameBase::setRechargeRate(%this,10);
}
function Player::3(%this)
{
	Client::sendMessage(Player::getClient(%this),1,"'Fire-Control Computer' activated ~wmine_act.wav");
	Player::setItemCount(%this, FCC,1);
}
function Player::4(%this)
{
	Client::sendMessage(Player::getClient(%this),1,"'Fire-Control Computer' deactivated ~wmine_act.wav");
	Player::setItemCount(%this, FCC,0);
}
function Player::1(%this)
{
	Client::sendMessage(Player::getClient(%this),1,"Auto-Heal activated ~wmine_act.wav");
	GameBase::setAutoRepairRate(%this,50);
}
function Player::2(%this)
{
	Client::sendMessage(Player::getClient(%this),1,"Auto-Heal deactivated ~wmine_act.wav");
	GameBase::setAutoRepairRate(%this,0);
}

function checkControlUnmount(%clientId)
{
	if(%clientId.possessed) return;//++++++++++++
	doneposs(%clientId);//+++++++++++++++
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

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function HV_PPCStun(%clientId, %player, %shooter, %value) 
{   
	%enVal  = 20.0;
	%energy = GameBase::getEnergy(%player);
  	%energy = %energy - %enVal;

		 if($blindTime[%clientId] == 0)
		 {
			 Player::setDamageFlash(%player,0.75);
			 $blindTime[%clientId] = 2;
			 checkHVBlind(%clientId, %player);
	   		 GameBase::setEnergy(%player,%energy);
		 }
		 else
			 $blindTime[%clientId] = 2;
 }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function hvBlowUp(%this)
{
	%obj = newObject("","Mine","Nuke1");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,0,false);
	%obj = newObject("","Mine","Nuke2");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,0,false);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function hvKamakazi(%this)
{
	%obj = newObject("","Mine","Nuke3");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,0,false);
	%obj = newObject("","Mine","Nuke4");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,0,false);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function HV_FlamerHeat(%clientId, %player, %shooter) 
{   
	%enVal  = 7.0; //2.0
	%energy = GameBase::getEnergy(%player);
  	%energy = %energy - %enVal;

		 if($blindTime[%clientId] == 0)
		 {
			 Player::setDamageFlash(%player,1.75);
			 $blindTime[%clientId] = 2;
			 checkHVBlind(%clientId, %player);
	   		 GameBase::setEnergy(%player,%energy);
		 }
		 else
			 $blindTime[%clientId] = 2;
 }
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function HV_InfernoHeat(%clientId, %player, %shooter) 
{   
	%enVal  = 35.0; //50.0;
	%energy = GameBase::getEnergy(%player);
  	%energy = %energy - %enVal;

		 if($blindTime[%clientId] == 0)
		 {
			 Player::setDamageFlash(%player,1.75);
			 $blindTime[%clientId] = 2;
			 checkHVBlind(%clientId, %player);
	   		 GameBase::setEnergy(%player,%energy);
		 }
		 else
			 $blindTime[%clientId] = 2;
 }
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkHVBlind(%clientId, %player)
	 {
		 if($blindTime[%clientId] > 0)
		 {
			 Player::setDamageFlash(%player,1.75);
			 $blindTime[%clientId] -= 2;
			 schedule("checkHVBlind(" @ %clientId @ ", " @ %player @ ");",2,%player);
		 }
	 }
//++++++++++++++++++++++++++++
function doneposs(%cl) {
	if(%cl.possessing) {
		Client::setControlObject(%cl, %cl);
	    Client::setControlObject(%cl.poss, %cl.poss);
		MessageAllExcept(%cl.poss, 0, Client::getName(%cl.poss) @ " is no longer possessed by " @ Client::getName(%cl) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl.poss,1,"Your soul has been freed of " @ Client::getName(%cl)@".~wteleport2.wav"); 	
		%cl.possessing = false;
		(%cl.poss).possessed = false;
		(%cl.poss).possby = "";
		%cl.poss = "";
	}
	if(%cl.possessed) {
		Client::setControlObject(%cl.possby, %cl.possby);
	    Client::setControlObject(%cl, %cl);
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%cl.possby) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"Your soul has been freed of " @ Client::getName(%cl.possby)@".~wteleport2.wav"); 	
		%cl.possessed = false;
		(%cl.possby).possessing = false;
		(%cl.possby).poss = "";
		%cl.possby = "";
	}
}