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

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		
		
//==================================================================================================== Determin Team Damage

		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();

			   if ((%curTime - %this.DamageTime > 1.5 || %this.LastHarm != %shooterClient) && (%type != $GravDamageType) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");

			            %shooterClient.score = (%shooterClient.score -1);
						if ($ScoreOn) bottomprint(%killerId, "You harmed your team mate... Score -1 = " @ %shooterClient.score @ " Total Score");
						
//================================================================= This makes the AIs switch teams when shot by team mates.

						if ($Shifter::AntiTKBots)
						{						
							if (Player::isAIControlled(%damagedClient) == "true" && Player::isAiControlled(%shooterClient) == "False")	 //==== Determin If Bot gets pissed.
							{
								%rnd = floor(getRandom() * 10);
	
								%aiTeam = Client::GetTeam(%damagedClient);
								%aiName = Client::GetName(%damagedClient);
								Client::sendMessage(%shooterClient,0," " @ Client::getName(%damagedClient) @ " has gone postal and is attacking every one!");
								
								if (%rnd <= 3)
								{
									if 	(%aiTeam == 0)
									{
										Client::setInitialTeam(%damagedClient, 1);
										//echo("AI Damaged Is - " @ %aiName @ " " @ %damagedClient @ " switched teams.");
										schedule("Client::setInitialTeam(" @ %damagedClient @ ", 0);",15);
	
									}
									else
									{
										Client::setInitialTeam(%damagedClient, 0);
										//echo("AI Damaged Is - " @ %aiName @ " " @ %damagedClient @ " switched teams.");
										schedule("Client::setInitialTeam(" @ %damagedClient @ ", 1);",15);
										
									}
									AI::HuntTarget(%aiName, %shooterClient, 1);
								}	
							}
						}
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

//============================================================================= A.I. Action To Damage
	
		if (Player::isAIControlled(%damagedClient) == "true")				//===== Determins if player is A.I.
		{
			%shooterpos = GameBase::getPosition(%shooterClient);			//===== Gets Shooters Location & Other Varibles
			%worldLoc = WaypointToWorld ( %shooterpos );
			%aiTeam = Client::GetTeam(%damagedClient);
			%aiName = Client::GetName(%damagedClient);
			%aiId = %damagedclient;
			
			//echo (%damagedClient @ " Is Damaged - Heading For " @ %shooterpos @ " - " @ %woldloc);
			
				if(String::findSubStr(%aiName, "Guard") >= 0)				//===== Guard Bot Uses Shields
				{
					Player::useItem(%aiId, "beacon") ;
					//echo ("Guard Bot Uses Shields");
				}

			AI::HuntTarget(%aiName, %shooterClient, 1);						//===== Send Bot On Its Way
		}

//============================================================================= More Damage To Head Shots

		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType)
			{
				if(%armor == "harmor")
				{ 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
					{
						%value += (%value * 0.3);
					}
				}
				else
				{
					%value += (%value * 0.3);
				}
			}
			
//============================================================================= Shield Pack On

			if (%type != -1 && %this.shieldStrength)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				     if (%type == $ElectricityDamageType)
					 {
					     %strength *= 0.0;
					 }

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

//============================================================================= Flash Damage Does EMP Effect

			if( ((%type == $FlashDamageType) || (%type == $NukeDamageType)) && ( Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) )
				Insomniax_startEMP(%damagedClient, %this);

//============================================================================= Juggernaught Shield
			%armor = Player::getArmor(%this);
			if ((%armor == "jarmor") && (!%this.shieldStrength))
				Renegades_startShield(%damagedClient, %this);

//============================================================================= Cloaking Blast

			if (%type == $CloakDamageType)
			{
				echo("Cloaking" @ %this);
		        GameBase::startFadeOut(%this);
		        schedule("GameBase::startFadeIn(" @ %this @ ");", 90);
			}
			
//============================================================================= Life Drain - Poison

			if ((%type == $EnergyDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) )
			{
				%armor = Player::getArmor(%this);
				if ((%armor != "aarmor") && (%armor != "afemale"))
					Renegades_startBlind(%damagedClient, %this);
			}


//============================================================================= Grav Damage 
			if (%type == $GravDamageType)
			{
			}
//============================================================================= Plasma Damage Catches Player On Fire

			if (((%type == $PlasmaDamageType) || (%type == $NukeDamageType)) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7)
				{
					%armor = Player::getArmor(%this);
					if ( (%armor != "barmor") && (%armor != "bfemale"))
						Renegades_startBurn(%damagedClient, %this);
				}
			}

//============================================================================= Body Area Damage Effects

  			if (%value) 
			{
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				if(%armor == "harmor" || %armor == "darmor" || %armor == "jarmor")
					%hittolerance = 0.25;
				else
					%hittolerance = 0.25;

				%weaponType = Player::getMountedItem(%this,$WeaponSlot);

//============================================================================= Suicide Pack Explodes

				if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack))
				{						
					if( ((%type == $LaserDamageType) || (%type == $SniperDamageType) ) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")  && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
					{
						MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!");

						Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!");
						Player::unmountItem(%this,$BackpackSlot);	
		
						%obj = newObject("","Mine","Suicidebomb");
		 				addToSet("MissionCleanup", %obj);
						%client = Player::getClient(%this);
						GameBase::throw(%obj,%this,9 * %client.throwStrength,false);
					}
				}

//============================================================================= Weapons Drop On Sniper Shot

				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun"))
				{
					Player::dropItem(%this,%weaponType);
	       		   	%dlevel = GameBase::getDamageLevel(%this) + 0.05;
				//	messageall(0, Client::getName(%shooterClient) @ " sniped the " @ %weaponType @ " out of " @ Client::getName(%damagedClient) @ "'s Hand!");
				Client::sendMessage(Player::getClient(%shooterClient),0,
				"You shot the " @ %weaponType @ " out of "  @ Client::getName(%damagedClient) @ "'s hand!");


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

				if(!Player::isDead(%this))
				{ 
//============================================================================= Check for flag kick on sniper shot - *IX*Savage1
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $LaserDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
						DoTheFlagDrop(%this, %shooterClient);

					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else 
				{

	           	if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $ElectricityDamageType)
				{
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
					if (%type == $ElectricityDamageType) 
						playSound(ShockExplosion,GameBase::getPosition(%this));
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

//========================================================================================================================================
//==================================================== Collisions With Players ===========================================================
//========================================================================================================================================

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this))
	{
		if (getObjectType(%object) == "Player")
		{
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
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	
//=========================================================================================================================================
// 															Werewolfs Bot stuff
//															 Dealing with Bots
//															   Bot Collision	                                          Edited By Emo1313
//=========================================================================================================================================

	if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "false" && (%object != "Flier") && (!Player::isDead(%this) || !Player::isDead(%object)))
	{
		echo("BOT: Collision <" @ %aiName @ " - " @ %aiId @ ">");
											
		%Player1 = Player::getClient(%this);
		%Player2 = Player::getClient(%object);

		%aiId = Player::getClient(%this);
		%aiName = Client::GetName(%aiId);
		%aiTeam = Client::GetTeam(%this);	 
		%objTeam = Client::GetTeam(%object);
		
//========================================================================================================================== Class Specific

		if (%aiTeam == %objTeam)                          //================================= Make Sure Bot Doesnt Repair Other Teams Stuff
		{
			if (BotTypes::IsMedic(%aiName) == 1)          //============================================================== Medic Bots Stuff
			{				
				if (%aiTeam == %objTeam)
				{
					echo("BOT: " @ %aiName @ "Drops Repair Kit");			
				    Player::dropItem(%aiId, "repairkit");
					return;
				}
			}

			if (BotTypes::IsMedic(%aiName) == 1)
			{
				
				if ($Shifter::Shielded[%PlayerId] != "True")
				{
					Renegades_startShield(%Player1, %this);
					$Shifter::Shielded[%PlayerId] = "True";
					schedule ("$Shifter::Shielded[" @ %PlayerId @ "] = False",21);
				}
				
				%repairRate = 0.1;
				%damage = GameBase::getDamageLevel(%object);
				%difference = %damage - %repairRate;
				if (%difference < 0.0)	//== If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
				{
						%repairRate = %damage;
				}
				%newDamage = %damage - %repairRate;
				GameBase::setDamageLevel(%object, %newDamage);
			}
		}

//============================================================================================================== Attempt Object Move Around

		if((GameBase::testPosition(%aiId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
		{	
			%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));		
			%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));		
			%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 
		
		    %aiRotation = (%aiRotation + 60);
			%Length = 225;
			%Zvalue = $aiRotation;
		
			%aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 			
			%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);			
			%rotZ = (%rotZ + 90);
		
			%velocity = 75;
			
			GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
		
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%aiId),%velocity,%Zvalue);
			Vehicle::passengerJump(0,%aiId,0);		 								 		//Crude way to make players avoid obstacles
			Player::applyImpulse(%aiId, %jumpDir);
		}
		else
        {
			echo ( %aiId @ " Can not avoid...");
		}

	}

//======================================================================================================================== End AI Collision

//======================================================================================================================= Scout Steal Items

	if (getObjectType(%object) == "Player") 
	{
		if (Player::isDead(%object))
		{
			return;
		}
		
		if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
		{
			%armor = Player::getArmor(%object);
			if (%armor == "sarmor" || %armor == "sfemale")
			{
				// Transfer all our items to the player nad drop players pack...
				%DropPack = (Player::getMountedItem(%this, $BackPackSlot));
				Player::dropItem(%this, %DropPack) ;

				%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
				Player::dropItem(%this, %FlagDrop) ;
				
				Player::setDamageFlash(%this,0.95);
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
							Player::unmountItem(%this,$WeaponSlot);
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
	}

//============================================================================= Eng. Medic Touch
	
		if (getObjectType(%object) == "Player") 
		{
			if (Player::isDead(%object))
			{
				return;
			}
				if (Player::isDead(%this))
				{
					return;
				}

				if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if (%armor == "earmor" || %armor == "efemale")
			      	{
						if(GameBase::getDamageLevel(%this)) 
						{
							GameBase::repairDamage(%this,0.10);
							GameBase::playSound(%this,ForceFieldOpen,0);
				      	}
					}		
				}	
			}

//============================================================================= Arbitor Death Touch
	
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);
	
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					%tarmor = Player::getArmor(%this);
					if ( (%armor == "aarmor" || %armor == "afemale") && (%tarmor != "aarmor" || %tarmor != "afemale") )
		    	  	{
						GameBase::applyDamage(%this,$FlashDamageType,0.10,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
						if(GameBase::getDamageLevel(%object)) 
						{
							GameBase::repairDamage(%object,0.30);
						}
						GameBase::playSound(%this,ForceFieldOpen,0);
						Client::sendMessage(Player::getClient(%object),1,
						"You drain "  @ Client::getName(%thisId) @ "'s energy...");
					}		
				}	
			}
	
//============================================================================= Assassin Death Touch
	
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
			
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);

				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
		
					if ((%armor == "larmor") || (%armor == "lfemale"))
		    	  	{
						GameBase::applyDamage(%this,$EnergyDamageType,0.25,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
						GameBase::playSound(%this,ForceFieldOpen,0);
								
						Client::sendMessage(Player::getClient(%object),1,
						"You death touch "  @ Client::getName(%thisId) @ ".");
				
					}		
				}	
			}

//============================================================================= Spy Disguise - Skin Snatch

			if (getObjectType(%object) == "Player") 
			{		
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);

				if (Player::isDead(%object))
				{
					return;
				}
		
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if (%armor == "spyarmor" || %armor == "spyfemale")
			      	{
						%grabskin = Client::getSkinBase(%thisId);
						
						if ($Shifter::SkinDiff)
							%origskin = Client::getSkinBase(%cliendId);
						
						$Shifter::SkinDiff = "True";
						Client::setSkin(%cliendId,(%grabskin));

						GameBase::playSound(%this,ForceFieldOpen,0);
						Client::sendMessage(%cliendId,0,"You went undercover disguised as " @ Client::getName(%thisId) @ " !");
						Client::sendMessage(Player::getClient(%object),1,"You go undercover disguised as "  @ Client::getName(%thisId) @ "!" );

	        			schedule("Client::setSkin(" @ %cliendId @ ",(" @(%origskin)@ "));", 120);
						schedule("$Shifter::SkinDiff = False;",120);
					}	
				}		
			}
}

//============================================================================= Get Heat Factor

function Player::getHeatFactor(%this)
{
	//=== Hack to avoid turret turret not tracking vehicles.
	//=== Assumes that if we are not in the player we are
	//=== controlling a vechicle, which is not always correct
	//=== but should be OK for now.
	
	%client = Player::getClient(%this);
	

	
	if ( (Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this)) )
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

//============================================================================= Jump To Mount Point

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


//========================================================================================================================== On Kill Self
function remoteKill(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);


//============================================================================================================= Penis Curse

	 if(%armor == parmor)
	 {
	 	Client::sendMessage(%client,0,"Removing the curse of the penis will not be that easy!");
		
		%rnd = floor(getRandom() * 30);	
		%random = (%rnd + 10);
		
		schedule("penisCurse(" @ %client @ ");", %random);
	 }

//============================================================================================================ Suicide Pack

   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack)
		{
			Player::unmountItem(%player,$BackpackSlot);	
			
				%obj = newObject("","Mine","Suicidebomb");
			 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			    playNextAnim(%client);
 			    Player::kill(%client);
			    Client::onKilled(%client,%client);	
		}
		else
		{
			   playNextAnim(%client);
			   Player::kill(%client);
			   Client::onKilled(%client,%client);
		}
   }
 		playNextAnim(%client);
 		Player::kill(%client);
		Client::onKilled(%client,%client);

   
$animNumber = 25;

}

function penisCurse(%cl)
{
	 %armor = Player::getArmor(%cl);

	 if (%armor != parmor) 
	 {
		 Player::setArmor(%cl,parmor);
		 checkMaxDrop(%cl,parmor);
		 armorChange(%cl);
		 Player::setItemCount(%cl, $ArmorName[%armor], 0);
		 messageAll(0, " The Penis Curse Has Returned To " @ Client::getName(%cl) @ ", and you thought it was over. " @ Client::getName(%cl) @ " should have played nicer...");
		 Player::setItemCount(%cl, Penis, 1);
		 Player::mountItem(%cl, Penis, $BackPackSlot);
 
	  	 if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 	Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
	 }
}

//=========================================================================================================================================

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
   
   %player = Client::getOwnedObject(%clientId);
if(Player::getMountedItem(%player,$BackpackSlot) != Laptop)
{

if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo
&& GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableHolo3  && GameBase::getDataName(%objectId) != DeployableSatchel 
&& !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
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

//============================================================================= EMP Effects

function Insomniax_startEMP(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You were hit by an EMP!");
	Player::unmountItem(%player,$WeaponSlot);

	if($empTime[%clientId] == 0)
	{
		GameBase::setEnergy(%player,0);
		GameBase::setRechargeRate(%player,0);
		$empTime[%clientId] = 14;
		checkPlayerEMP(%clientId, %player);
	}
	else
		$empTime[%clientId] = 14;
}

// This checks the current Status of EMP Effect on the player - *IX*Savage1

function checkPlayerEMP(%clientId, %player)
{
	if($empTime[%clientId] > 0)
	{
		$empTime[%clientId] -= 2;  
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		GameBase::setRechargeRate(%player,8);
	}			
}

//============================================================================= Poisoning

function Renegades_startBlind(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are poisoned!");
	if($poisonTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 15;
		checkPlayerBlind(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 15;
}


function checkPlayerBlind(%clientId, %player)
{
	
	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 2;  
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
			if  (!Player::isDead(%player)) 
			{
				GameBase::setDamageLevel(%player, %drrate);  
				Player::setDamageFlash(%player,0.75);  
				if  (Player::isDead(%player))
				{
					messageall(0, Client::getName(%clientId) @ " died from a strange disease.");
					%clientId.scoreDeaths++;
		      		%clientId.score--;
					Game::refreshClientScore(%clientId);
					$poisonTime[%clientId] = 0;
				}

		}
		else
		{
		
		$poisonTime[%clientId] = 0;
		}
		

		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"The effects of the poison wear off.");		
	}			

		
}

//============================================================================= Flamer Burn

function Renegades_startBurn(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are on fire!");
	if($burnTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.50);
		$burnTime[%clientId] = 5;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 5;
}


function checkPlayerBurn(%clientId, %player)
{
	
if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 5;  
		%drrate = GameBase::getDamageLevel(%player) + 0.02;
		if  (!Player::isDead(%player)) 
		{
		GameBase::setDamageLevel(%player, %drrate);  
		Player::setDamageFlash(%player,0.50);  
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " was incinerated.");
				%clientId.scoreDeaths++;
      			%clientId.score--;
				Game::refreshClientScore(%clientId);
				$burnTime[%clientId] = 0;
			}

		}
		else
		{
			$burnTime[%clientId] = 0;
		}
		

		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",1,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"You stop burning.");
		
	}			

		
}

//============================================================================= Flag Shot Off

function DoTheFlagDrop(%player, %shooterId) 
{
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);
   %shooterName = Client::getName(%shooterId);

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
