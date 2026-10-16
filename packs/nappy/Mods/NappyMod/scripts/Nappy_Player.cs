


function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
//messageall(1,%type);
	%duelmessage = 0;
	if(Player::isExposed(%this)) {
		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;
		%damagedClientTeam = Client::getTeam(%damagedClient);
		%shooterClientTeam = Client::getTeam(%shooterClient);
//==============[  TEAM DAMAGE  ]
		if($teamplay && %damagedClient != %shooterClient && %damagedClientTeam == %shooterClientTeam && %shooterClientTeam != -1 && %shooterClient.NappyDuel != "duel") {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   	if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					Player::applyImpulse(%this,%mom);
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Nappy::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Nappy::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Nappy::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Nappy::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
//==============[  DUEL PIT GLOBAL TEAM DAMAGE  ]
		else if(%shooterClientTeam == -1 && %type != $CrushDamageType && %type != $LandingDamageType){
			if(%shooterClientTeam == %damagedClientTeam && (Player::getArmor(%shooterClient) == "duelarmor" || Player::getArmor(%shooterClient) == "duelfemale")){
				Player::applyImpulse(%this,%mom);
				if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Nappy::DuelDamageScale > 0) {
					%duelmessage = 1;
				}
				%friendFire = $Nappy::DuelDamageScale;
			}
			else if(Player::getArmor(%shooterClient) != "duelarmor" && Player::getArmor(%shooterClient) != "duelfemale"){
				if(%damagedClientTeam == -1){
					if(%shooterClient == %damagedClient && %shooterClient.NappyDuel == "duel"){
						Player::applyImpulse(%this,%mom);
						%friendFire = $Nappy::DuelDamageScale;
					}
					else
						%friendFire = 0;
				}
				else {
					Player::applyImpulse(%this,%mom);
					%friendFire = 1;
				}
			}
			else{
				%friendFire = 0;
			}
		}
//==============[  DUEL PIT TEAM DAMAGE  ]
//"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//_____________________________________________________________________________________________
		else if(%shooterClient.NappyDuel == "duel" && %type != $CrushDamageType && %type != $LandingDamageType && %shooterClientTeam != -1){
			if(%damagedClient.NappyDuel == "duel" && %damagedClient.pit == %shooterClient.pit && %shooterClientTeam == %damagedClientTeam){
				Player::applyImpulse(%this,%mom);
				if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && %shooterClient.DamageScale > 0) {
					%duelmessage = 1;
					if(%shooterClient.DuelType = "1on1"){
						if(!%shooterClient.Dueling && !%damagedClient.Dueling){
							%shooterClient.Dueling = 1;
							%shooterClient.Opponent = %damagedClient;
							%damagedClient.Dueling = 1;
							%damagedClient.Opponent = %shooterClient;
						}
						if(%damagedClient.Opponent == %shooterClient){
							%shooterClient.HitOpponent++;
							%damagedClient.GotHit++;
						}
						else{
							%friendFire = 0;
							%duelmessage = 0;
						}
					}
				}
				else if(%damagedClient == %shooterClient && %type != $BoostDamageType && %shooterClient.DuelType = "1on1"){
					%damagedClient.HitSelf++;
				}
				%friendFire = Nappy::DuelTeam::DamageScales(%damagedClient, %type);
			}
			else{
				%friendFire = 0;
			}
		}
//"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//_____________________________________________________________________________________________
//==============[  CTF TEAM DAMAGE  ]
		else if(%shooterClient.NappyDuel != "duel" && %type != $ImpactDamageType && %type != $LandingDamageType){
			if(%damagedClient.NappyDuel == "duel"){
				%friendFire = 0;
			}
			else{
				Player::applyImpulse(%this,%mom);
				%friendFire = 1;
			}
		}
//==============[  IMPACT DAMAGE  ]
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == %damagedClientTeam) {
			Player::applyImpulse(%this,%mom);
			%friendFire = $Server::TeamDamageScale;
		}
//==============[ EVERY THING ELSE  ]
		else{
			if(%type == $LandingDamageType){
				if(%damagedClient.NappyDuel == "duel"){
					Player::applyImpulse(%this,%mom);
					%friendFire = %damagedClient.LandingDamage * %damagedClient.DamageScale;
				}
				else{
					Player::applyImpulse(%this,%mom);
					%friendFire = 1.0;
				}
			}
			else{
				Player::applyImpulse(%this,%mom);
				%friendFire = 1.0;
			}
		}
//==============[  ADDED DAMAGE AND EFFECT  ]	
		if(!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if((%vertPos == "head") && (%type == $LaserDamageType || %type == $SniperDamageType)) {
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
			if(%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if(%value < %absorb) {
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
			if(%type == $ShockDamageType && %damagedClientTeam != %shooterClientTeam && %friendFire != 0){ 
 				Shock_Damage(%damagedClient, %this);
			}
			if(%type == $AntiAirDamageType && %damagedClientTeam != %shooterClientTeam && %friendFire != 0){ 
 				AntiAir_Damage(%damagedClient, %this);
			}
			if(%type == $PoisonDamageType && %damagedClientTeam != %shooterClientTeam && %friendFire != 0){ 
				%armor = Player::getArmor(%this); 
				if((%armor != "flagarmor") && (%armor != "flagfemale")) 
					Renegades_startBlind(%damagedClient, %this); 
			} 
			if(%type == $FireDamageType && %damagedClientTeam != %shooterClientTeam && %friendFire != 0){ 
				%rnd = floor(getRandom() * 10); 
				if(%rnd > 5){ 
					%armor = Player::getArmor(%this); 
					if((%armor != "barmor") && (%armor != "bfemale")) 
						Renegades_startBurn(%damagedClient, %this); 
				} 
			} 
			%armor = Player::getArmor(%this); 
			if((%type == $PoisonDamageType) && ((%armor == "dmarmor")||(%armor == "dmfemale")) && %friendFire != 0) 
				Renegades_startBlind(%damagedClient, %this); 
			if ((%type == $ShockDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale")) && %friendFire != 0) 
				Shock_Damage(%damagedClient, %this); 
			if ((%type == $FireDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale")) && %friendFire != 0) 
				Renegades_startBurn(%damagedClient, %this); 
  			if (%value && %friendFire) {
				%armor = Player::getArmor(%this); 
				%hitdamageval = 0.05; 
				if(%armor == "harmor") 
					%hittolerance = 0.25; 
				else 
					%hittolerance = 0.25; 
				%weaponType = Player::getMountedItem(%this,$WeaponSlot); 
				if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack)){
					if(((%type == $LaserDamageType) || (%type == $SniperDamageType)) && (%quadrant == "back_right" || %quadrant == "back_left") && (%damagedClientTeam != %shooterClientTeam)){ 
						MessageAllExcept(Player::getClient(%damagedClient), 0, Nappy::getName(%shooterClient) @ " sniped the huge bomb on " @ Nappy::getName(%damagedClient) @ "'s back!"); 
						Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!"); 
						Player::unmountItem(%this,$BackpackSlot); 
						%obj = newObject("","Mine","Suicidebomb2"); 
						addToSet("MissionCleanup", %obj); 
						GameBase::throw(%obj,%this,9 * %client.throwStrength,false);
						schedule("Mine::Detonate(" @ %obj @ ");",0,%obj); 
					} 
				} 
				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType || %type == $SniperDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun")){ 
					if(%friendFire != 0){
						Player::dropItem(%this,%weaponType); 
						%dlevel = GameBase::getDamageLevel(%this) + 0.05; 
						Client::sendMessage(Player::getClient(%shooterClient),0, "You shot the " @ %weaponType @ " out of " @ Nappy::getName(%damagedClient) @ "'s hand!"); 
					}
					else {
						%dlevel = GameBase::getDamageLevel(%this);
					}
				} 
				else{ 
					%value = $DamageScale[%armor, %type] * %value * %friendFire; 
					%dlevel = GameBase::getDamageLevel(%this) + %value; 
				} 
            			%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				%DuelFlash = (Player::getDamageFlash(%this) + %value * 2) / %damagedClient.DamageScale;
				if(%DuelFlash > 0.75) 
					%DuelFlash = 0.75;
				if(%damagedClient.NappyDuel != "duel")
					Player::setDamageFlash(%this,%flash);
				else
					Player::setDamageFlash(%this,%DuelFlash);

				if(%duelmessage){
					%duelmessage = 0;
					Nappy::DuelPit::Messages(%shooterClient, damage, %damagedClient, %armor, %spillOver, %value);
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
               				if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                				Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
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









function Player::onCollision(%this,%object)
{
%objectTeam = GameBase::getTeam(%object);
%thisTeam = GameBase::getTeam(%this);
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
	} //this is the end of base function
	if (getObjectType(%object) == "Player" && !Player::isDead(%this)) { 
		if (Player::isDead(%object)) { 
			return; 
		}
		if(%objectTeam == -1 || %thisTeam == -1)
			return;
		%cliendId = Player::getClient(%object); 
		%thisId = Player::getClient(%this); 
		%armor = Player::getArmor(%object); 
		if(%objectTeam != %thisTeam) { 
			if (%armor == "sparmor" || %armor == "spfemale") { 
				Player::setDamageFlash(%this,1.95); 
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
					return; //attempt 1 to fix Nappy lag if no good remove this line
				} 
			} 
			else if (%armor == "barmor" || %armor == "bfemale") {
			}
			else if ((%armor == "flagarmor") || (%armor == "flagfemale")) { 
				GameBase::applyDamage(%this,$EnergyDamageType,0.20,GameBase::getPosition(%this),"0 0 0","0 0 0",%object); 
				if(GameBase::getDamageLevel(%object)) { 
					GameBase::repairDamage(%object,0.20); 
				} 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				Client::sendMessage(Player::getClient(%object),1, "You drain " @ Nappy::getName(%thisId) @ "'s life"); 
				return; //attempt 1 to fix Nappy lag if no good remove this line
			} 
		} 
		else if(%objectTeam == %thisTeam) { 
			if (%armor == "engarmor" || %armor == "engfemale") { 
				if(GameBase::getDamageLevel(%this)) { 
					GameBase::repairDamage(%this,0.10); 
					GameBase::playSound(%this,ForceFieldOpen,0);
					return; //attempt 1 to fix Nappy lag if no good remove this line
				} 
			} 
		} 
	}

}







function remoteKill(%client) 
{
	if(Nappy::remoteCheck(%client, "Kill", 1))
		return;
	if(%client.possessing || %client.possessed || %client.froze){
		Client::sendMessage(%client, 0, "You cannot kill yourself at this time.~waccess_denied.wav");  
		return;
	}
	%player = Client::getOwnedObject(%client); 
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) { 
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) { 
			Player::unmountItem(%player,$BackpackSlot); 
			%obj = newObject("","Mine","Suicidebomb"); 
			addToSet("MissionCleanup", %obj); 
			%client = Player::getClient(%player); 
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false); 
		} 
		else { 
			if(%client.game != "Duel"){
				playNextAnim(%client); 
				Player::kill(%client); 
				Client::onKilled(%client,%client); 
			}
			else if(%client.canSuicide != 0){
				if(%client.game == "Duel"){
					Nappy::Duel::TakeAwayItems(%client);
					%client.canSuicide = 0;
				}
				if(%client.game == "Duel" && %client.DuelType != "1on1"){
					playNextAnim(%client); 
					Player::kill(%client); 
					deleteObject(%player);
					schedule("Game::playerSpawn(" @ %client @ ");", 1);
				}
				else
					Client::onKilled(%client,%client); 
			}
		} 
	}
} 

function reactivateSuicide(%client)
{
	%client.canSuicide = 1;
}



function Client::takeControl(%clientId, %objectId)
{
	// remote control
	if(%objectId == -1){
		//echo("objectId = " @ %objectId);
		return;
	}
	if(%clientId.possessed || %clientId.froze) 
		return; 
	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;
	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)){
		//echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1){
		//echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != IonTurret && %name != DeployableSatchel && %name != DeployableRocket && %name != DeployableLaser && %name != DeployableIndoor && %name != DeployableShock && %name != AntiAirTurret && %name != DeployableElf && %name != DeployableMortar && %name != DeployablePlasma && %name != DeployableRail && %name != DeployableVulcan ){ 
		if(!GameBase::isPowered(%objectId)){
			// echo("Turret " @ %objectId @ " not powered.");
			return;
		}
	}
	%player = Client::getOwnedObject(%clientId);
	if(Player::getMountedItem(%player,$BackpackSlot) != "Laptop" && !(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats) {
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
	if(Nappy::remoteCheck(%clientId, "CmdrMountObject", 1, %objectIdx))
		return;
	if(%clientId.possessed || %clientId.froze)
		return;
	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}



function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject){
		if(%ownedObject == -1 || %ctrlObject == -1)
			return;
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
			return;
		Client::setControlObject(%clientId, %ownedObject);
	}
	%object = Client::getOwnedObject(%clientId);
	if($TurretActive[%clientId] == false){
		Turret::onDismount(%ctrlObject, %object);
		schedule("TurretActivate(" @ %ctrlObject @ ", " @ %object @ ");", $Nappy::Turret::controllReactivationTime,%object);
	}
	if(Client::getOwnedObject(%clientId).CommandTag == 1){ 
		schedule("ClientControlDisable(" @ %ctrlObject @ ", " @ %object @ ");", 0.5,%object);
	}
	$ControllingTurret[%clientId] = false;
}












//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
function Shock_Damage(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"You got shocked!"); 
	Player::unmountItem(%player,$WeaponSlot);
	if($ShockTime[%clientId] == 0){ 
		if(GameBase::getRechargeRate(%player) > 1)
			$Shock::RechargeRate[%clientId] = GameBase::getRechargeRate(%player);
		GameBase::setEnergy(%player,0); 
		GameBase::setRechargeRate(%player,0); 
		$ShockTime[%clientId] = 14;
		if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack){ 
			Client::sendMessage(%clientId,1,"Switching to energy pack for main power."); 
			GameBase::setRechargeRate(%player,1);
		}
		checkPlayerShock(%clientId, %player); 
	} 
	else 
		$ShockTime[%clientId] = 14;
	if(!$checkingPlayerShock[%clientId]){ 
		GameBase::setEnergy(%player,0); 
		GameBase::setRechargeRate(%player,0); 
		$ShockTime[%clientId] = 14;
		if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) 
			Client::sendMessage(%clientId,1,"Switching to energy pack for main power."); 
		checkPlayerShock(%clientId, %player); 
	}  
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
function checkPlayerShock(%clientId, %player) 
{ 
	if($ShockTime[%clientId] > 0){ 
		$ShockTime[%clientId] --; 
		$checkingPlayerShock[%clientId] = 1;
		schedule("checkPlayerShock(" @ %clientId @ ", " @ %player @ ");",1,%player); 
	} 
	else { 
		$checkingPlayerShock[%clientId] = 0;
		Client::sendMessage(%clientId,1,"Your energy systems are back to normal."); 
		GameBase::setRechargeRate(%player,$Shock::RechargeRate[%clientId]); 
	} 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================



function AntiAir_Damage(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"Your energy systems short-circuted!"); 
	if($AntiAirTime[%clientId] == 0){ 
		if(GameBase::getRechargeRate(%player) != 0)
			$AntiAir::RechargeRate[%clientId] = GameBase::getRechargeRate(%player);
		GameBase::setEnergy(%player,0); 
		GameBase::setRechargeRate(%player,0); 
		$AntiAirTime[%clientId] = 5;
		if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) 
			Client::sendMessage(%clientId,1,"Switching to energy pack for main power."); 
		checkPlayerAntiAir(%clientId, %player); 
	} 
	else 
		$AntiAirTime[%clientId] = 5;
	if(!$checkingPlayerAntiAir[%clientId]){ 
		GameBase::setEnergy(%player,0); 
		GameBase::setRechargeRate(%player,0); 
		$AntiAirTime[%clientId] = 5;
		if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) 
			Client::sendMessage(%clientId,1,"Switching to energy pack for main power."); 
		checkPlayerAntiAir(%clientId, %player); 
	}  
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function checkPlayerAntiAir(%clientId, %player) 
{ 
	if($AntiAirTime[%clientId] > 0){ 
		$AntiAirTime[%clientId] --; 
		$checkingPlayerAntiAir[%clientId] = 1;
		schedule("checkPlayerAntiAir(" @ %clientId @ ", " @ %player @ ");",1,%player); 
	} 
	else { 
		$checkingPlayerAntiAir[%clientId] = 0;
		Client::sendMessage(%clientId,1,"Your energy systems are back to normal."); 
		GameBase::setRechargeRate(%player,$AntiAir::RechargeRate[%clientId]); 
	} 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function Renegades_startBlind(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"You are poisoned!"); 
	if($poisonTime[%clientId] == 0) { 
		Player::setDamageFlash(%player,0.75); 
		$poisonTime[%clientId] = 30; 
		checkPlayerBlind(%clientId, %player); 
	} 
	else 
		$poisonTime[%clientId] = 30; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function checkPlayerBlind(%clientId, %player) 
{ 
	if($poisonTime[%clientId] > 0) { 
		$poisonTime[%clientId] -= 2; 
		%drrate = GameBase::getDamageLevel(%player) + 0.05; 
		if(!Player::isDead(%player)) { 
			GameBase::setDamageLevel(%player, %drrate); 
			Player::setDamageFlash(%player,0.75); 
			if(Player::isDead(%player)) { 
				messageall(0, Nappy::getName(%clientId) @ " died from a strange disease."); 
				%clientId.scoreDeaths++; 
				%clientId.score--; 
				Game::refreshClientScore(%clientId); 
				$poisonTime[%clientId] = 0; 
			} 
		} 
		else { 
			$poisonTime[%clientId] = 0; 
		} 
		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player); 
	} 
	else { 
		Client::sendMessage(%clientId,1,"The effects of the poison wear off."); 
	} 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function Renegades_startBurn(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"You caught on fire!"); 
	if($burnTime[%clientId] == 0) { 
		Player::setDamageFlash(%player,0.75); 
		$burnTime[%clientId] = 10; 
		checkPlayerBurn(%clientId, %player); 
	} 
	else 
		$burnTime[%clientId] = 10; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function checkPlayerBurn(%clientId, %player) 
{ 
	if($burnTime[%clientId] > 0) { 
		$burnTime[%clientId] -= 2; 
		%drrate = GameBase::getDamageLevel(%player) + 0.05; 
		if(!Player::isDead(%player)) { 
			GameBase::setDamageLevel(%player, %drrate); 
			Player::setDamageFlash(%player,0.75); 
			if(Player::isDead(%player)) { 
				messageall(0, Nappy::getName(%clientId) @ " was incinerated."); 
				%clientId.scoreDeaths++; 
				%clientId.score--; 
				Game::refreshClientScore(%clientId); 
				$burnTime[%clientId] = 0; 
			} 
		} 
		else { 
			$burnTime[%clientId] = 0; 
		} 
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	else { 
		Client::sendMessage(%clientId,1,"You stop burning."); 
	} 
} 




















