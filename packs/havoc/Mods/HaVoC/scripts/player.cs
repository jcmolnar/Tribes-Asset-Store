
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

$CorpseTimeoutValue = 30; 

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			
			%item = newObject("","Item",%type,1,false);
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType) { } 

function Player::onKilled(%this)
{
	this.prevA = "";

	%name = Client::getName(Player::getClient(%this));
	if($Hologram[%name] != "") {
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		return;
	}
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	doneposs(%cl);

	if(%this.tfield)
      deleteObject(%this.tfieldlight);

	if($HaVoC::AutoRespawn > 0) 
		schedule("Game::autoRespawn(" @ %cl @ ");",$HaVoC::AutoRespawn,%cl);
	Player::setDamageFlash(%this,0.85);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || (getRandom() > "0.2" && %type != Mortar)) 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1) {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			} else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
	    }
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
	   Client::setOwnedObject(%cl, -1);
       Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	  %cl.safet = false;
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime() + 1;
   }
}

function ixStartEMP(%clientId, %player, %shooter, %type) { 
	if( %player.shieldStrength > 0 )
		return; 
	%weapon = Player::getMountedItem(%player,$WeaponSlot); 
	if(($WeaponAmmo[%weapon] == "")) 
		Player::unmountItem(%player,$WeaponSlot); 
	if(Player::getMountedItem(%player,$BackpackSlot) == "HeatSink") 
		return; 
	if(%clientId != %shooter) 
		Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " hit you with an EMP!"); 
	else 
		Client::sendMessage(%clientId,1,"You hit yourself with an EMP!");
	playSound(SoundEMPDrain,GameBase::getPosition(%player)); 
	%armor = whatArm(Player::getArmor(%clientId)); 
	if (%armor == 4) {
		%delay = 1; 
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)*0.33); 
	} else if (%armor == 3) {
		%delay = 1; 
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)*0.5); 
	} else if (%armor == 2) {
		%delay = 5; 
		GameBase::setEnergy(%player,0); 
	} else {
		%delay = 9;
		GameBase::setEnergy(%player,0); 
	}
	if(%clientId.empTime == 0) { 
		GameBase::setRechargeRate(%player,0); 
		%clientId.empTime = %delay;
		checkPlayerEMP(%clientId, %player); 
	} else
		%clientId.empTime = %delay;
} 

function checkPlayerEMP(%clientId, %player) { 
	if(%clientId.empTime > 0) { 
		%vel = Item::getVelocity(%player); 
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
		Projectile::spawnProjectile("EMPShock",%trans,%player,%vel,%player); 
		%clientId.empTime--; 
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",1,%player); 
	} else { 
		if(!Player::isDead(%clientId)) 
			Client::sendMessage(%clientId,1,"EMP Effects have dissipated.");
		if(%player.rejuv != 1)
			GameBase::setRechargeRate(%player,8);
	} 
} 

function isTurret(%type) {
	if(%type == $MExplosionDamageType || %type == $AAExplosionDamageType || %type == $PDamageType || %type == $ElectricityTEDamageType || %type == $ElectricityEDamageType || %type == $ElectricityLEDamageType || %type == $BurnEDamageType || %type == $MiniDamageType || %type == $FlashDamageType || %type == $TracDamageType)
		return true;
	else
		return false;
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object) { 
	%damagedClient = Player::getClient(%this); 
	%damName = Client::getName(%damagedClient);

//	messageall(0, "%vertPos="@%vertPos@"  %quadrant="@%quadrant);

	if($Hologram[%damName] != "") {
		%t = isTurret(%type) || (%type == 6 && !%shooterClient);
		if(%t) %value *= 3;
		%dlevel = GameBase::getDamageLevel(%this) + %value;
		if(%dlevel >= Player::getArmor(%this).maxDamage) playNextAnim(%this); 
		GameBase::setDamageLevel(%this,%dlevel);
		return;
	}

	if (!Player::isExposed(%this)) return; 

	%damagedTeam = Client::getTeam(%damagedClient);
	%shooterClient = %object; 
	%shooterTeam = Client::getTeam(%shooterClient);
	%shootName = Client::getName(%shooterClient);

	if(%damagedClient.dumbass) %value *= 2;

	if (%damagedTeam == %shooterTeam && %type == $TracDamageType)
		%mom = "0 0 0";

	if (%damagedClient == %shooterClient) {
		%weapItem = Player::getMountedItem(%shooterClient, $WeaponSlot);
		if (%weapItem == WaveGun) {
			%x = getword(%mom, 0) * 0.31;
			%y = getword(%mom, 1) * 0.31;
			%z = getword(%mom, 2) * 0.31;
			%mom = %x @ " " @ %y @ " " @ %z;
		} else if (%type == $ExplosionDamageType) {	
         if ( %weapItem == IXRocketLauncher || %weapItem == RocketLauncher )  {
   			%x = getword(%mom, 0) * 0.4;
   			%y = getword(%mom, 1) * 0.4;
   			%z = getword(%mom, 2) * 0.4;
         } else {
   			%x = getword(%mom, 0) * 0.62;
   			%y = getword(%mom, 1) * 0.62;
   			%z = getword(%mom, 2) * 0.62;
         }
			%mom = %x @ " " @ %y @ " " @ %z;
		}
	} else if (%type == $TracDamageType && Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") {
		%x = getword(%mom, 0) * 0.1;
		%y = getword(%mom, 1) * 0.1;
		%z = getword(%mom, 2) * 0.1;
		%mom = %x @ " " @ %y @ " " @ %z;
	}

	if(%type == 91) {
		%shooterTeam = GameBase::getTeam(%object);
		if(%shooterTeam == %damagedTeam) return;
		teamMessages(0, %shooterTeam, "The Base Alarm has detected "@%damName@".~wmine_act.wav", "", "", "");
		return;
	}

	if(%type == 999) {
		if(GameBase::getTeam(%object) != %damagedTeam) return;
		%dlevel = GameBase::getDamageLevel(%this) - %value;
		if(%dlevel < 0) %dlevel = 0;
		GameBase::setDamageLevel(%this, %dlevel);
		return;
	}

	%name = GameBase::getDataName(%shooterClient);
	if(getObjectType(%object) == "Flier") { 
		if(%name.shapefile == "rocket" && $Server::TeamDamageScale == 0) {
			GameBase::setDamageLevel(%object, 1000); 
			%shooterTeam = GameBase::getTeam(%object);
			if(%damagedTeam == %shooterTeam) return;
		} else if(%name.shapefile == "discb" || %name.shapefile == "remoteturret") return;
	}		

	%t = (isTurret(%type) || (%type == 6 && !%shooterClient));

	if($teamplay && %damagedClient != %shooterClient && %shooterClient != -1 && %damagedTeam == %shooterTeam){
		if(%this.inStation && %mom != 0 && %this == Station::getTarget(%this.inStation) && ((%t && Client::getOwnedObject(%shooterClient).CommandTag == 1) || !%t)) {
			Client::sendMessage(%shooterClient,0,"Shooting teammates from stations is not allowed.~waccess_denied.wav");
		} else {
			Player::applyImpulse(%this,%mom); 
		}
		%curTime = getSimTime(); 
		if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && $Server::TeamDamageScale > 0) {
			if((%t && Client::getOwnedObject(%shooterClient).CommandTag == 1) || !%t) {
				if(%type == $ElectricityDamageType || %type == $ElectricityTEDamageType || %type == $ElectricityEDamageType || %type == $ElectricityLEDamageType) {
					if(!%shooterClient.ELFhit) {
						%shooterClient.ELFhit = true;
						schedule(%shooterClient @ ".ELFhit = false;",10);
						Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ "!");
						Client::sendMessage(%damagedClient,0,"You took friendly fire from " @ %shootName @ "!");
					}
				} else if (%type == $MineDamageType) {
					Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ " with your mine!");
					Client::sendMessage(%damagedClient,0,"You stepped on " @ %shootName @ "'s mine!");
				} else {
					Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ "!");
					Client::sendMessage(%damagedClient,0,"You took friendly fire from " @ %shootName @ "!");
				}
				%this.LastHarm = %shooterClient;
				%this.DamageStamp = %curTime;
			} 
		}
		%friendFire = $Server::TeamDamageScale;
	} else {
		Player::applyImpulse(%this,%mom); 
		if((%type == $ImpactDamageType || %type == $MissileRamDamageType) && Client::getTeam(%object.clLastMount) == %damagedTeam) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	
	}

	if (Player::isDead(%this)) return;

	%armor = Player::getArmor(%this);

	if (%type != -1 && %this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		if (%type == $RailDamageType) {
			%energy = 0;
			GameBase::getEnergy(%this, 0);
			%value *= 2.8;
			Projectile::spawnProjectile("RailEffect", "0 0 1 0 0 0 0 0 1 " @ %pos, 2048, "0 0 0");
		}
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
		} else {
			GameBase::setEnergy(%this,0);
			%value = %value - %absorb;
		}
	}
	if(%type == $ShotgunDamageType && !%this.inStation)
		Player::applyImpulse(%this,ixDotProd(%vec,0.074)); 
	else if(%type == $BlindDamageType) {
		HavocBlind(%damagedClient, %this);
		%value = 0;
	} else if(%type == $BurnDamageType || %type == $BurnEDamageType)
		HaVoC_startBurn(%damagedClient, %this, 12);
	else if (%type == $EMPDamageType) 
		ixStartEMP(%damagedClient, %this, %shooterClient, %type); 
	else if (%type == $EngineerEMPDamageType && %armor != "earmor" && %armor != "efemale")
		ixStartEMP(%damagedClient, %this, %shooterClient, %type); 
	else if(%type == $FlashDamageType) 
		Shock_Damage(%damagedClient, %this); 
	else if (%type == $PlasmaDamageType && %damagedTeam != %shooterTeam) { 
		if(floor(getRandom() * 10) > 6) { 
			if (%armor != "barmor" && %armor != "bfemale" && %armor != "darmor" && %armor != "harmor") 
				HaVoC_startBurn(%damagedClient, %this, 6); 
		} 
	} else if (%type == $EnergyDamageType) {
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1) {
			if( !%this.shieldStrength )
				HaVoC_startBlind(%damagedClient, %this, 13);
			else
				HaVoC_startBlind(%damagedClient, %this, 7);
		}
	} else if (%type == $SuperEnergyDamageType) {
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1) {
     		if( !%this.shieldStrength )
      		HaVoC_startBlind(%damagedClient, %this, 31);
         else
      		HaVoC_startBlind(%damagedClient, %this, 16);
      }
	} else if (%type == $SmallEnergyDamageType) {
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1) {
     		if( !%this.shieldStrength )
      		HaVoC_startBlind(%damagedClient, %this, 10);
         else
      		HaVoC_startBlind(%damagedClient, %this, 4);
      }
   }

	if (!%value) return;

	if(%type == $LaserDamageType || %type == $SniperDamageType) { 
		%a = whatarm(%armor);
		if (%vertPos == "head") { 
			if(%a == 3) { 
				if(%quadrant == "middle_front") {
					if (%type == $SniperDamageType) %value += (%value * 0.45); 
					if (%type == $LaserDamageType) %value += (%value * 0.062); 
					%value += (%value * 0.11); 
				} else 
					%value -= (%value * 0.16); 
			} else if (%a == 2) { 
				if(%quadrant == "middle_front") {
					if (%type == $SniperDamageType)
						%value += (%value * 0.13); 
					%value += (%value * 0.05); 
				} else {
					if (%type == $SniperDamageType) 
						%value += (%value * 0.37); 
					else
						%value -= (%value * 0.09); 
					%value -= (%value * 0.186); 
				}
			} else if (%a == 4) {
				if (%type != $SniperDamageType) 
					%value *= 0.9;
				else
					%value *= 1.11;
			} else {
				if(%quadrant == "middle_front") {
					if (%type == $SniperDamageType) %value += (%value * 0.45); 
					%value += (%value * 0.133); 
				} else if (%type == $SniperDamageType)
					%value += (%value * 0.14);
			} 
		} else {
			if(%a == 4) {
				if (%type != $SniperDamageType) 
					%value *= 0.58; 
				else
					%value *= 0.5; 
			} else {
				%value -= (%value * 0.31); 
				if(%a == 3)
					%value -= (%value * 0.11); 
				else if (%a == 2)
					%value -= (%value * 0.11); 
				else
					%value -= (%value * 0.21); 
			}
		} 
	}

	%weaponType = Player::getMountedItem(%this,$WeaponSlot); 
	%dis = 0;
	if (%type == $LaserDamageType)
		%dis = 16;
	else if (%type == $SniperDamageType)
		%dis = 13;
	else if (%type == $RailDamageType)
		%dis = 19;
	if(%dis > 0 && %damagedTeam != %shooterTeam) {
		if(Player::getMountedItem(%this,$BackpackSlot) == SuicidePack && (%quadrant == "middle_back" || %quadrant == "middle_middle")) { 
			if(%t)
				%msg = "A laser turret";
			else
				%msg = %shootName;
			MessageAllExcept(Player::getClient(%damagedClient), 0, %msg @ " shot the huge bomb on " @ %damName @ "'s back!"); 
			Client::sendMessage(Player::getClient(%damagedClient), 0, %msg @ " shot your Demolition Pack!");
			Player::unmountItem(%this,$BackpackSlot); 
			%obj = newObject("","Mine","Suicidebomb"); 
			addToSet("MissionCleanup", %obj); 
			GameBase::throw(%obj,%this,9 * %client.throwStrength,true); 
		} else if (%value > 0.3) {
			if (%vertPos == "torso" && %quadrant == "front_right" && %weaponType != -1 && %weaponType != "RepairGun" && %weaponType != "PowerGun") { 
				%obj = newObject("","Item",%weaponType,1,false);
			  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			 	addToSet("MissionCleanup", %obj);
				if(%t)
					%msg = "A laser turret";
				else {
					%msg = %shootName;
					Client::sendMessage(%shooterClient, 0, "You shot the " @ %weaponType.description @ " out of "  @ %damName @ "'s hand!");
				}
				Client::sendMessage(%damagedClient, 0, %msg @ " shot the " @ %weaponType.description @ " out of your hand!");
				GameBase::throw(%obj, %damagedClient, %dis, true);
				Player::decItemCount(%damagedClient,%weaponType,1);
				%dlevel = GameBase::getDamageLevel(%this) + 0.06; 
			} else {
				if (%quadrant == "middle_back" || %quadrant == "middle_middle" || %quadrant == "back_left" || %quadrant == "back_right") {
					if (%vertpos == "head" || %vertpos == "torso") {
						if(Player::getMountedItem(%this,$FlagSlot) == "flag" && %shooterClient && $Game::missionType == "CTF") {
							if(!%t) {
								ixFlagDrop(%this, %shooterClient);
								%dlevel = GameBase::getDamageLevel(%this) + 0.005;
							}
						}
					}
				}			
			}
		}
	}

	if(!%dlevel) {
		%value = $DamageScale[%armor, %type] * %value * %friendFire;
		%dlevel = GameBase::getDamageLevel(%this) + %value; 
	}

	%spillOver = %dlevel - %armor.maxDamage; 

	if(%dlevel >= %armor.maxDamage && %shooterClient && !Player::isDead(%shooterClient) && %shootName != "") { 
		if(Player::getMountedItem(%this,$FlagSlot) == "flag" && $Game::missionType != "Hunter" && %damagedClient != %shooterClient) { 
			if(%damagedTeam != %shooterTeam) { 
				%shooterClient.score++; 
				Game::refreshClientScore(%shooterClient); 
				if(%t)				
					schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You get a bonus for your turret killing the enemy flag carrier!\");",1); 
				else
					schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You get a bonus for killing the enemy flag carrier!\");",1); 
			} else if (!%t) { 
				%shooterClient.score--; 
				Game::refreshClientScore(%shooterClient); 
				schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You lose 2 points for killing your own flag carrier!\");",1); 
				if(!String::ICompare(Client::getGender(%shooterClient), "Male"))
					%playerGender = "his"; 
				else 
					%playerGender = "her"; 
				schedule("messageAllExcept(" @ %shooterClient @ ", 0, \"" @ escapeString(%shootName) @ " has killed "@%playerGender@" own team's flag carrier!\");", 1);
			} 
		}
		if(%damagedTeam != %shooterTeam && !%t && $Game::missionType == "CTF") {
			if(Player::getMountedItem(%object,$FlagSlot) != "flag") {
				%f = $playerHas[%shooterTeam];
				if(%f.carrier != -1 && GameBase::getTeam(%f.carrier) == %shooterTeam) {
				    if((%f.carrier).lastHit == %damagedClient && (%f.carrier).lastStamp > getSimTime()) {
				   		%shooterClient.score++;
				        Game::refreshClientScore(%shooterClient);
						schedule("messageAllExcept(" @ %shooterClient @ ", 0, \"" @ escapeString(%shootName) @ " gets a bonus for defending the flag carrier!\");", 1);
				        schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You get a bonus for defending the flag carrier!\");", 1);
					}
				}
			}
		}
	}

	if(%damagedTeam != %shooterTeam && !%t && $Game::missionType == "CTF") {
		if(Player::getMountedItem(%this,$FlagSlot) == "flag" && %type != $MineDamageType) {
			%this.lastHit = %shooterClient;
			%this.lastStamp = getSimTime() + 20;
		}
	}

	GameBase::setDamageLevel(%this, %dlevel);
	%flash = Player::getDamageFlash(%this) + %value * 2;
	if (%flash > 0.75) %flash = 0.75;
	Player::setDamageFlash(%this,%flash);

	if($Server::TeamDamageScale > 0 && %damagedClient != %shooterClient) {
		if ((!%t || Client::getOwnedObject(%shooterClient).CommandTag == 1) && ($HaVoC::Eye4anEye == TRUE || %shooterClient.just)) {
			if(%damagedTeam == %shooterTeam && $Game::missionType != "DMTEAM" && $Game::missionType != "DM" && $Game::missionType != "Hunter") {
				%f = Client::getOwnedObject(%object);
				if((%object.tkKills >= $HaVoC::tkLimit || %shooterClient.just) && getObjectType(%f) == "Player") {
					if(%object.tkKills >= $HaVoC::tkLimit * 2 || %shooterClient.just)
						%eyedlevel = GameBase::getDamageLevel(%f) + (%value*3);
					else
						%eyedlevel = GameBase::getDamageLevel(%f) + (%value*2);
					if(%eyedlevel >= (Player::getArmor(%f)).maxDamage) {
						Client::sendMessage(%shooterClient,1,"You have been killed for attacking teammates.~wError_Message.wav"); 
						MessageAllExcept(%shooterClient, 1, %shootName @ " has been killed for attacking teammates.");
						playNextAnim(%shooterClient); 
						Player::kill(%shooterClient); 
						Client::onKilled(%shooterClient, %shooterClient);
					} else
						GameBase::setDamageLevel(%f, %eyedlevel);
					%flash = Player::getDamageFlash(%object) + %value * 2;
					if (%flash > 0.8) 
						%flash = 0.8;
					Player::setDamageFlash(%object,%flash);
				}
			}
		}
	}
	if(Player::isDead(%this)) { 
       	if((%spillOver > 0.4 && (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MExplosionDamageType)) || %type == $ElectricityDamageType || %type == $ElectricityEDamageType || %type == $ElectricityTEDamageType || %type == $ElectricityLEDamageType) {
 			Player::trigger(%this, $WeaponSlot, false);
			%weaponType = Player::getMountedItem(%this,$WeaponSlot);
			if(%weaponType != -1)
				Player::dropItem(%this,%weaponType);
			playSound(debrisLargeExp1osion,GameBase::getPosition(%this));
			Player::blowUp(%this);
		} else {
			if ((%value > 0.4 && (%type == $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
		  		if(%quadrant == "front_left" || %quadrant == "front_right") 
					%curDie = $PlayerAnim::DieBlownBack;
				else
					%curDie = $PlayerAnim::DieForward;
			} else if(Player::isCrouching(%this)) 
				%curDie = $PlayerAnim::Crouching;							
			else if(%vertPos == "head") {
				if(%quadrant == "front_left" ||	%quadrant == "front_right") 
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
			  	else 
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
			} else if (%vertPos == "torso") {
				if(%quadrant == "front_left" ) 
					%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "front_right") 
					%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
				else if(%quadrant == "back_left" ) 
					%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "back_right") 
					%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
			} else if (%vertPos == "legs") {
				if(%quadrant == "front_left" ||	%quadrant == "back_left") 
					%curDie = $PlayerAnim::DieLegLeft;
				else if(%quadrant == "front_right" || %quadrant == "back_right") 
					%curDie = $PlayerAnim::DieLegRight;
			}
			Player::setAnimation(%this, %curDie);
		}
		if((%type == $ImpactDamageType || %type == $MissileRamDamageType) && %object.clLastMount != "")  
			%shooterClient = %object.clLastMount;
		Client::onKilled(%damagedClient, %shooterClient, %type);
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{

	if (getObjectType(%object) != "Player") return; 
	
	if (Player::isDead(%this)) {
		
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
			
			playSound(SoundPickupItem,GameBase::getPosition(%this));
		}
		return;

	} else if(!Player::isDead(%object)) {

		%armor = Player::getArmor(%object); 
		if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { 
			if (%armor == "sarmor" || %armor == "sfemale")
				HavocBlind(Player::getClient(%this), %this); 
		} else if (%armor == "earmor" || %armor == "efemale") { 
			if(GameBase::getDamageLevel(%this)) { 
				GameBase::repairDamage(%this,0.016); 
				GameBase::playSound(%this,SoundPickupHealth,0); 
			} 
		} 
	}
} 

function Player::getHeatFactor(%this) { 

   if(Player::isAIControlled(%this))
   	return 0.0;   

	%client = Player::getClient(%this);
	%co = Client::getControlObject(%client);
	if(GameBase::getDataName(%co) == "Wraith") {
		if(Player::getMountedItem(%this,$FlagSlot) == "flag") 
			return 1.0;
		else
			return 0.0;
	}
	if (%co != %this && !%client.safet && !%client.possessing && !%client.wat)
		return 1.0;
	if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") 
		return 0.0; 
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

function Player::getHeat(%this) { 

   if(Player::isAIControlled(%this))
   	return false;   

	%client = Player::getClient(%this);
	%co = Client::getControlObject(%client);
	if (%co != %this && !%client.safet && !%client.possessing && !%client.wat)
		return true;

	return false;
}

function Player::jump(%this,%mom) {
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
      %vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}

function remoteKill(%client) {
   if(!$matchStarted || %client.permap || %client.dan)
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
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		if($Game::missionType != "DMTEAM" && $Game::missionType != "DM") {
			Client::sendMessage(%client, 0, "You lost 2 points for choosing to kill yourself."); 
			%client.score--; 
			Game::refreshClientScore(%client); 
		}
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) {
			Player::unmountItem(%player,$BackpackSlot); 
			%obj = newObject("","Mine","Suicidebomb"); 
			addToSet("MissionCleanup", %obj); 
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false); 
		}
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

function Client::takeControl(%clientId, %objectId) { 
   
   if(%objectId == -1)
   {
      
      return;
   }

	if(%clientId.possessed) return;

	%pl = Client::getOwnedObject(%clientId);
	
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      return;
   }

	%name = GameBase::getDataName(%objectId);
	%player = Client::getOwnedObject(%clientId); 
   if ( %player.outArea == 1 ) {
      Client::SendMessage(%clientId, 0, "Cannot control turrets from out of bounds.~waccess_denied.wav");
      return; 
   }

	if(Player::getMountedItem(%player,$BackpackSlot) != Laptop) { 
		if ((Client::getOwnedObject(%clientId)).CommandTag != 1 && %name != CameraTurret && %name != DeployableHolo && %name != DeployableHolo2 && %name != Dr && %name != DeployableHolo3 && %name != DeployableSatchel && !%clientId.atcom) {
			Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets.~waccess_denied.wav"); return; 
		} 
	} 
	if(%pl.CommandTag == 1 && %pl.noCom && !%clientId.atcom) {
		Client::SendMessage(%clientId,0,"Internal command systems recharging...");
		return;
	}
	if(GameBase::getDamageState(%objectId) == "Enabled") { 
		if (%name == DeployableAA) {
			Client::SendMessage(%clientId,0,"Cannot manually control AA Turrets.~waccess_denied.wav");
			return;
		}
		if (%name == DeployableSatchel) bottomprint(%clientId, "<jc>Press jump to detonate.", 2);
		doneposs(%clientId);
		%pl = Client::getOwnedObject(%clientId);
		%pl.CommandTag = 1;
		%clientId.safet = true;
		Client::setControlObject(%clientId, %objectId); Client::setGuiMode(%clientId, $GuiModePlay); 
 	    return true;
	} 
} 

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{

	if(%clientId.possessed) return;
	doneposs(%clientId);
	
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
	%data = GameBase::getDataName(%ctrlObject);
	if(%data.description == "Repair Drone" || %data.description == "Spy Drone")
		GameBase::setDamageLevel(%ctrlObject, 10);
		%clientId.safet = false;
      Client::setControlObject(%clientId, %ownedObject);
	  LaptopDrain(%clientId, %ownedObject);
   }
}

function Shock_Damage(%clientId, %player) { Client::sendMessage(%clientId,1,"You've been hit with an EMP!"); playSound(SoundEMPDrain,GameBase::getPosition(%player)); Player::unmountItem(%player,$WeaponSlot); GameBase::setEnergy(%player,0); if(Player::getMountedItem(%player,$BackpackSlot) == "HeatSink") return; if(%clientId.shockTime == 0) { GameBase::setRechargeRate(%player,0); %clientId.shockTime = 10; checkPlayerShock(%clientId, %player); } else %clientId.shockTime = 10; } 

function checkPlayerShock(%clientId, %player) { if(%clientId.shockTime > 0) { 
%vel = Item::getVelocity(%player); %trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); Projectile::spawnProjectile("EMPShock",%trans,%player,%vel,%player);
%clientId.shockTime--; schedule("checkPlayerShock(" @ %clientId @ ", " @ %player @ ");",1,%player); } else { Client::sendMessage(%clientId,1,"EMP Effects have dissipated."); if(%player.rejuv != 1) GameBase::setRechargeRate(%player,8); } } 

function HaVoC_startBlind(%clientId, %player, %tme) {
	if(%clientId.poisonTime == -10) return; 
	Player::setDamageFlash(%player, 0.2); 
	if(%clientId.poisonTime == 0) {
		Client::clearItemShopping(%clientId);
		Client::sendMessage(%clientId,1,"You've been poisoned!");
		havocP(%clientId, %player); 
		%clientId.poisonTime = %tme - 1; 
		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",1,%player); 
	} else 
		%clientId.poisonTime = %tme; 
} 


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

function havocP(%client, %player) {
	%armor = Player::getArmor(%player); 
	if (%armor == "harmor" || %armor == "darmor") {
		Player::setArmor(%player,pharmor);
	} else if (%armor == "marmor" || %armor == "barmor" || %armor == "earmor" || %armor == "iarmor" || %armor == "dmarmor") {
		Player::setArmor(%player,pmarmor);
	} else if (%armor == "mfemale" || %armor == "bfemale" || %armor == "efemale" || %armor == "ifarmor" || %armor == "dmfemale") {
		Player::setArmor(%player,pmfemale);
	} else if (%armor == "larmor" || %armor == "sarmor" || %armor == "spyarmor") {
		Player::setArmor(%player,plarmor);
	} else if (%armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale") {
		Player::setArmor(%player,plfemale);
	} else {
		%player.prevA = "";
		return;
	}
	%player.prevA = %armor;
}


function checkPlayerBlind(%clientId, %player) { 
	if(%clientId.poisonTime > 0) { 
		%clientId.poisonTime -= 3; 
		%drrate = GameBase::getDamageLevel(%player) + 0.056; 
		%vel = Item::getVelocity(%player); 
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
		Projectile::spawnProjectile("PoisonEffect",%trans,%player,%vel,%player); 
		if (!Player::isDead(%player)) { 
			if(%drrate >= Player::getArmor(%player).maxDamage) {
				%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
				messageall(0, sprintf($deathMsg[$EnergyDamageType, %ridx], "", Client::getName(%clientId), "", "")); 
				%clientId.scoreDeaths++; 
				Game::refreshClientScore(%clientId);
				%clientId.poisonTime = 0; 
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie); 
				if($Game::missionType == "Duel" || $Game::missionType == "DuelTournament") EndDuel(%clientId, $EnergyDamageType);
			} else {
				schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",3,%player); 
			}
			GameBase::setDamageLevel(%player, %drrate); 
			Player::setDamageFlash(%player,0.55); 
		} else {
			%clientId.poisonTime = 0; 
		}
	} else { 
		%clientId.poisonTime = 0;
		%armor = Player::getArmor( Client::getOwnedObject(%clientId) ); 
		if( (%armor == pharmor || %armor == pmarmor || %armor == pmfemale || %armor == plarmor || %armor == plfemale) && !Player::isDead(%clientId)) {
			Client::sendMessage(%clientId,1,"The effects of the poison wear off."); 
			if(%player.prevA != "") {
				Player::setArmor(%clientId, %player.prevA);
				Player::setItemCount(%player, %player.prevA, 1);
			}
			checkMax(%clientId, Player::getArmor(%player));
			if(%player.inStation) updateBuyingList(%clientId);
		}
	} 
} 

function HavocBlind(%clientId, %player) {
	if(%clientId.blindTime == 0) {
		Client::sendMessage(%clientId,1,"You've been blinded!"); 
		Player::setDamageFlash(%player, 0.4); 
		Player::setDetectParameters(%player, 0, 300);
		%clientId.blindTime = 8; 
		schedule("pokeEm(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else %clientId.blindTime = 10; 
} 

function pokeEm(%clientId, %player) { 
	if(%clientId.blindTime > 0) { 
		%clientId.blindTime -= 2; 
		Player::setDamageFlash(%player,0.5); 
		schedule("pokeEm(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else { 
		%clientId.blindTime = 0; 
		Player::setDetectParameters(%player, 0, 0);
	} 
} 

function HaVoC_startBurn(%clientId, %player, %a) { 
	if(Player::getMountedItem(%player,$BackpackSlot) == "HeatSink") return;
	if(%clientId.burnTime < 2) { 
		Client::sendMessage(%clientId,1,"You've caught on fire!"); 
		Player::setDamageFlash(%player,0.7); 
		%clientId.burnTime = %a; 
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");", 2, %player);
	} else
		%clientId.burnTime += 6; 
	if(%clientId.burnTime > 22) %clientId.burnTime = 22;
} 

function checkPlayerBurn(%clientId, %player) { 
	if(%clientId.burnTime > 1) { 
		%clientId.burnTime -= 2; 
		%drrate = GameBase::getDamageLevel(%player) + 0.04; 
		%vel = Item::getVelocity(%player); 
		%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
		Projectile::spawnProjectile("BurnEffect",%trans,%player,%vel,%player); 
		if (!Player::isDead(%player)) { 
			GameBase::setDamageLevel(%player, %drrate); 
			Player::setDamageFlash(%player,0.6); 
			if (Player::isDead(%player)) { 
				%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
				messageall(0, sprintf($deathMsg[$BurnDamageType, %ridx], "", Client::getName(%clientId), "", "")); 
				%clientId.scoreDeaths++; 
				Game::refreshClientScore(%clientId); 
				%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				Player::setAnimation(%player, %curDie); 
				%clientId.burnTime = 0; 
				if($Game::missionType == "Duel" || $Game::missionType == "DuelTournament") EndDuel(%clientId, $BurnDamageType);
			} else {
				schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",2,%player); }
		} else { 
			%clientId.burnTime = 0; 
		} 
	} else { 
		if(!Player::isDead(%clientId)) Client::sendMessage(%clientId,1,"You stop burning."); 
	} 
}


function ixFlagDrop(%player, %shooterId) {

	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	%shooterName = Client::getName(%shooterId);

	if (%flag.Dropper != %playerClient) {
		%flag.DroppedB4 = %flag.Dropper;
		%flag.Dropper = %playerClient;
	}

	if(%flagTeam == -1) {
		MessageAllExcept(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %dropClientName @ "'s back!");
		Client::sendMessage(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!");
	} else {
		MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
      	Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
		MessageAllExcept(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %dropClientName @ "'s back!");
		Client::sendMessage(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!");
		TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
	}

	GameBase::throw(%flag, %player, -12, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	$playerHas[%playerTeam] = "";
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $HaVoC::FlagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

