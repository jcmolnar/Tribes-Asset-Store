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
	GameBase::setRechargeRate(%this,12); //10 = hvMechWarrior-v1.0 value++++++++++++++++
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
	%cl = GameBase::getOwnerClient(%this);//++++returns client Id, 2049++++
//%this returns 8365++++
//	%thingy = Client::getControlObject(%this);//++++returns -1++++
//	%dn2 = GameBase::getDataName(%this);//++++returns "driver"++++
//	%dataname = GameBase::getDataName(%thingy);//++++returns blank++++
	%jet = Player::getMountObject(%this);//++++returns 8375++++
	%dataname = GameBase::getDataName(%jet);//++++returns PH++++
//	Client::sendMessage(Player::getClient(%this), 1,"dataname:"@%dataname@" dn2:" @ %dn2@ " jet:" @ %jet @ " thingy:" @%thingy@"");
	if(%dataname == "PH")
		{
		GameBase::setPosition(%jet, "-1000 -1000 -1000");
		GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %jet);
		}//++++
	%cl.dead = 1;
	doneposs(%cl);//+++++++++++++++++++++++++
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 10; %i = %i + 1) {//++++ 8 +++++++++++++++
		%type = Player::getMountedItem(%this,%i);
		%dname = GameBase::getDataName(%this);
		if (%type != -1) {
//			if (%i != $WeaponSlot || %dname != "Backpack" || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
			if (%i != $WeaponSlot || %dname != "Backpack" || %dname != "InfernoMine" || %dname != "VibroMine" || %dname != "NukeGrenade" || %dname != "SmokeHandGrenade" || %dname != "InfernoGrenade" || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
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
	%hvPosition = GameBase::getPosition(%this);
	%this.TKDeathPos = %hvPosition;
	$hvKillPosition = %hvPosition;
	$hvDeadMech = Player::getArmor(%this);
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
	%shooterClient.score = %shooterClient.score - $hvScore::TDamage;//++++++++
	$hvBad[%shooterClient] = $hvBad[%shooterClient] + $hvScore::TDamage;//++++++++ 
	%hvRatio = floor(($hvGood[%shooterClient]/($hvGood[%shooterClient] + $hvBad[%shooterClient]))*100);//++++++++
	bottomprint(%shooterClient,"<jc><f0>You lose <f1>" @ $hvScore::TDamage @ "<f0> points for shooting your teamate.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);//++++++++
     	Game::refreshClientScore(%shooterClient);//++++++++
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
			%value += (%value * 1.0);
			 }
			else	if(%vertPos == "head" && (%type == $ACDamageType || %type == $GaussDamageType))
			 {
			%value += (%value * 0.45);
			 }
			else	if(%vertPos == "head" && (%type == $ImpactDamageType))
			 {
			%value += (%value * 1.0);//++++++++++
			 }
			else	if(%vertPos == "head" && (%type == $GaussDamageType))
			 {
			%value += (%value * 0.60);
			 }
			else	if(%vertPos == "head" && (%type == $LaserDamageType))
			 {
			%value += (%value * 0.65);
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
				else if (%type == $FlashDamageType)//++++++++++++++++++++++++
					%strength *= 0.0007;//+++++++++++++++++++++++++++++++++++
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
// if (%type == $ExplosionDamageType) HV_SensorJam(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $InfernoDamageType) HV_InfernoHeat(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $Inferno2DamageType) HV_InfernoHeat2(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $FlamerDamageType) HV_FlamerHeat(%damagedClient, %this, %shooterClient);//++++++++++++
 if (%type == $FlashDamageType) HV_FlashBlind(%damagedClient, %this, %shooterClient);//++++++++++++
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
	               if(%spillOver > 0.25 && (%type== $PPCDamageType || %type == $MissileDamageType || %type== $GaussDamageType || %type== $FlashDamageType))
					{
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
						schedule("hvBlowUp(" @ %this @ ");",0);//++++
         			       	Player::blowUp(%this);
					//make explosion too, with "blow up"+++++++++++++++++++
					}
	               if(%spillOver > 0.4 && (%type== $ImpactDamageType)) //0.01++++
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
if (Player::isDead(%this)) 
	{
	if (getObjectType(%object) == "Player")	
		{

//	%HowMany = Player::getItemCount(%this,$GTD)
//	if(Player::getItemCount(%this,%HowMany);

		// Transfer all our items to the player
		%sound = false;
		%max = getNumItems();
			%client = Player::getClient(%object);//++++
			// %object = 8377++++
			// %this = 8365++++
			// %i = item numbers++++
			// %max = 150, # of items of %this???++++
		for (%i = 0; %i < %max; %i = %i + 1) 
			{
			%count = Player::getItemCount(%this,%i);//++++returns ++++
			if (%count)
				 {
				%dname = GameBase::getDataName(%this);//++++parmor, thing being run over++++
//				%dname = GameBase::getDataName(%i);//++++parmor, thing being run over++++
				%Gcount = Player::getItemClassCount(%client,"Grenade");//++++ 1 ++++
//				if (%dname != "InfernoMine" || %dname != "VibroMine" || %dname != "NukeGrenade" || %dname != "SmokeHandGrenade" || %dname != "InfernoGrenade")
//				if(%this.className != "Grenade") 
//					{
				%delta = Item::giveItem(%object,getItemData(%i),%count);//++++returns 0++++
//	Client::sendMessage(Player::getClient(%client), 1,"delta:"@%delta@" count:" @ %count@ " Gcount:" @ %Gcount @ " i:" @ %i @"");
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
	%armor = Player::getArmor(%this);
	%rot = GameBase::getRotation(%this); 
	%velocity = Item::getVelocity(%object);
	if (%armor == "larmor")
	{
		%impact = 0.020;
	}
	else if (%armor == "xarmor")
	{
		%impact = 0.018;
	}
	else if (%armor == "parmor")
	{
		%impact = 0.025;
	}
	else if (%armor == "dmarmor")
	{
		%impact = 0.025;
	}
	else if (%armor == "driver")
	{
		%impact = 0.030;
	}
	else if (%armor == "carmor")
	{
		%impact = 0.032; //0.035
	}
	else if (%armor == "marmor")
	{
		%impact = 0.036; //0.040;
	}
	else if (%armor == "hbarmor")
	{
		%impact = 0.038; //0.045;
	}
	else if (%armor == "aarmor")
	{
		%impact = 0.042; //0.050;
	}
	else if (%armor == "warmor")
	{
		%impact = 0.045; //0.055;
	}
	else if (%armor == "rarmor")
	{
		%impact = 0.050; //0.065;
	}
	else if (%armor == "barmor")
	{
		%impact = 0.047; //0.060;
	}
	else if (%armor == "yarmor")
	{
		%impact = 0.045; //0.060;
	}
	else if (%armor == "harmor")
	{
		%impact = 0.050; //0.065;
	}
	%momentum = %velocity;
	%vector = %rot;
	if (getObjectType(%object) == "Player")
		{
		if(Player::getMountedItem(%this,$BackpackSlot) == FerroFibrousArmor)
			{
			%impact = %impact / 2;
			}
		else
			{
			%impact = %impact;
			}
		if ((!Player::isDead(%this) && !Player::isDead(%object)) && (GameBase::getTeam(%this)!= GameBase::getTeam(%object)))
			{
			Player::setAnimation(%this,38);
			%death = 10 * %impact; //++++use this line if velocity math does not work++++
			GameBase::applyDamage(%object,$ImpactDamageType,%death,GameBase::getPosition(%this),%vector,%momentum,%this);
			GameBase::playSound(%this,debrisSmallExplosion,0);
			}
		else
			{
			return;
			}
		}
		%tName = GameBase::getDataName(%object);
		%target = getObjectType(%object); 
//%object == "Flier"++++++++add later???++++++ 
		if((%target == "StaticShape" || %target == "Turret" || %target == "Sensor" || %target == "Station") && (%tName != "FlagStand") && (GameBase::getTeam(%this)!= GameBase::getTeam(%object)))
			{
			if(GameBase::getDamageState(%object) == "Destroyed")
				{
				return;
				}
			else
				{
				%death = 5 * %impact;
				Player::setAnimation(%this,38);
				GameBase::applyDamage(%object,$ImpactDamageType,%death,GameBase::getPosition(%this),%vector,%momentum,%this);
				GameBase::playSound(%this,debrisSmallExplosion,0);
//TeamMessages(1, 0, "this= "@%this@", death= "@%death@",target= "@%target@", object= "@%object@", passed~waccess_denied.wav");
				}
			}
	else
		{
		return;
		}
}

//-----------------------------------------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------------------------------------
function Player::jump(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
//   playSound(SoundPackUse,GameBase::getPosition(%cl));//+++++++++++
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
	if(Player::getArmor(%clientID) == driver)
	{
	Client::SendMessage(%clientId,0,"-Phoenix Hawk LAM cannot control Turrets-");
	return;
	}
	else
	{//++++
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
	 if(Player::getItemCount(%player, FCC) < 1)//++++++++++
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
}//++++

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
%rad = getRandom(100);
if(%rad < 0.5)
	{
	%obj1 = newObject("","Mine","Nuke1");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj1,%this,0,false);
	%obj2 = newObject("","Mine","Nuke2");
 	addToSet("MissionCleanup", %obj2);
	GameBase::throw(%obj2,%this,0,false);
	}
else
	{
	return;
	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function hvKamakazi(%this)
{
//	%cl = GameBase::getOwnerClient(%this);//++++
//	%rad = getRandom(100);
//	Client::sendMessage(%cl, 1,"rad:"@%rad@" cl:"@%cl@" this:"@%this@"");
//	MessageAll(0,"rad:"@%rad@" cl:"@%cl@" this:"@%this@"");

	%obj1 = newObject("","Mine","Nuke3");
	addToSet("MissionCleanup", %obj1);
	GameBase::throw(%obj1,%this,0,false);
	%obj2 = newObject("","Mine","Nuke4");
 	addToSet("MissionCleanup", %obj2);
	GameBase::throw(%obj2,%this,0,false);
	%obj3 = newObject("","Mine","SmokeDeath");//++++
 	addToSet("MissionCleanup", %obj3);
	GameBase::throw(%obj3,%this,0,false);
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
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function HV_FlashBlind(%clientId, %player, %shooter) 
{   
	%enVal  = 10.0; //7.0;++++++
	%energy = GameBase::getEnergy(%player);
  	%energy = %energy - %enVal;

		 if($blindTime[%clientId] == 0)
		 {
			Item::setVelocity(%player, "0 0 0");//thanks to Ideal mod for this idea++++
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
	%enVal  = 25.0; //15.0; //35.0;++++++++++
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
  function HV_InfernoHeat2(%clientId, %player, %shooter) 
{   
	%enVal  = 60.0;
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
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function HV_SensorJam(%this, %player)
{   
if($blindTime2[%this] == 0)
	{
	Player::setDamageFlash(%player,1.75);
	$blindTime2[%this] = 10;
	checkHVBlind2(%clientId, %player);
	%rate = Player::getSensorSupression(%this) + 25;
	Player::setSensorSupression(%this,%rate);
	}
else
	{
//	$blindTime2[%this] = 2;
	%rate = Player::getSensorSupression(%this) - 25;
	Player::setSensorSupression(%this,%rate);
	}
}
function checkHVBlind2(%this, %player)
{
if($blindTime2[%this] > 0)
	 {
	 Player::setDamageFlash(%player,1.75);
	 $blindTime2[%this] -= 2;
	 schedule("checkHVBlind2(" @ %this @ ", " @ %player @ ");",2,%player);
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