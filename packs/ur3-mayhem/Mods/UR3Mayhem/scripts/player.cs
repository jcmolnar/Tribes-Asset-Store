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

 $CorpseTimeoutValue = 22;
 function Player::onAdd(%this) { GameBase::setRechargeRate(%this,8); }

 function Player::onRemove(%this) { for (%i = 0; %i < 8; %i = %i + 1) { %type = Player::getMountedItem(%this,%i); if (%type != -1) { %item = newObject("","Item",%type,1,false); schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item); addToSet("MissionCleanup", %item); GameBase::setPosition(%item,GameBase::getPosition(%this)); } } }

 function Player::onNoAmmo(%player,%imageSlot,%itemType) { }

 function Player::onKilled(%this) { %cl = GameBase::getOwnerClient(%this); %cl.dead = 1; if($AutoRespawn > 0) schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl); if(%this.outArea==1) leaveMissionAreaDamage(%cl); Player::setDamageFlash(%this,0.75); for (%i = 0; %i < 8; %i = %i + 1) { %type = Player::getMountedItem(%this,%i); if (%type != -1) { if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") Player::dropItem(%this,%type); } } if(%cl != -1) { if(%this.vehicle != "") { if(%this.driver != "") { %this.driver = ""; Client::setControlObject(Player::getClient(%this), %this); Player::setMountObject(%this, -1, 0); } else { %this.vehicle.Seat[%this.vehicleSlot-2] = ""; %this.vehicleSlot = ""; } %this.vehicle = ""; } schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this); Client::setOwnedObject(%cl, -1); Client::setControlObject(%cl, Client::getObserverCamera(%cl)); Observer::setOrbitObject(%cl, %this, 5, 5, 5); schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this); %cl.observerMode = "dead"; %cl.dieTime = getSimTime(); } }
 
 function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
 {
 if (Player::isExposed(%this)) { %damagedClient = Player::getClient(%this);
 %shooterClient = %object;
 %damagedTeam = Client::getTeam(%damagedClient);
 %shooterTeam = Client::getTeam(%shooterClient);
 if($teamplay && %damagedClient != %shooterClient && %damagedTeam == %shooterTeam && %this.inStation && %shooterClient != -1 && $insomniax::SafeStation) %value = 0;
 else
 if(%type == $FEBDamageType) Player::applyImpulse(%this,DotProd(Vector::neg(%vec),10));
 else
 if(%type == $ShotgunDamageType) Player::applyImpulse(%this,DotProd(%vec,0.05));
 else
 if(%type == $RifleDamageType) Player::applyImpulse(%this,DotProd(%vec,0.025));
 else
 if(%type == $AssaultRifleDamageType) Player::applyImpulse(%this,DotProd(%vec,0.05));
 else
 Player::applyImpulse(%this,%mom);
 if($teamplay && %damagedClient != %shooterClient && %damagedTeam == %shooterTeam && %type != $BoosterDamageType ) { if (%shooterClient != -1) { %curTime = getSimTime();
 if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0)
 {
 if(%type != $MineDamageType)
 {
 Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
 Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
 } else {
 Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
 Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
 }
 %this.LastHarm = %shooterClient; %this.DamageStamp = %curTime;
 }
 }
 %friendFire = $Server::TeamDamageScale;
 }
 else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == %damagedTeam) %friendFire = $Server::TeamDamageScale;
 else %friendFire = 1.0;
 if (!Player::isDead(%this)) { %armor = Player::getArmor(%this);
 if(Player::getMountedItem(%this,$BackpackSlot) == RocketBooster) { if((%friendfire) || (%damagedTeam != %shooterTeam) || %type == $LandingDamageType) { %heat = Heat(%damagedClient, %this, %type);
 if((%heat > 12) || (%type == $LandingDamageType && %value >= 0.1)) { Player::trigger(%this, $WeaponSlot, false);
 Player::trigger(%this, $BackpackSlot, false); %chargeCount = Player::getItemCount(%this,BoosterCharge);
 Player::decItemCount(%this,BoosterCharge,%chargeCount);
 Player::decItemCount(%this,RocketBooster,1); %damagedClient.heat = 0;
 %damagedClient.cool = "false";
 %armor = Player::getArmor(%this);
 %flag = Player::getMountedItem(%this,$FlagSlot);
 if(%flag == "flag") { if(%damagedClient != %shooterClient) {
 if(%damagedTeam != %shooterTeam) { %shooterClient.score+=1;
 Game::refreshClientScore(%shooterClient);
 schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Recieve 2 Points for Killing the Enemy Flag Carrier!\");",1); }
 else { %shooterClient.score-=1;
 Game::refreshClientScore(%shooterClient);
 schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Lose 2 Points for Killing your own Flag Carrier!\");",1);
 } } }
 GameBase::setDamageLevel(%this,%armor.maxDamage * 2);
 if(%type == $FlameDamageType) %type = $FlamerOverHeatType;
 else
 if(%type == $LandingDamageType) %type = $ImpactDeathType;
 Client::onKilled(%damagedClient,%shooterClient, %type);
 Detonate(%this); return; } } }
 if(%vertPos == "head" && (%type == $LaserDamageType || %type == $RifleDamageType)) {
 if(%armor == "harmor" || %armor == "hbarmor") { if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
 if(%type == $LaserDamageType) %value += (%value * 0.3); else %value += (%value * 1.2); } }
 else {
 if(%type == $LaserDamageType) %value += (%value * 0.3); else %value += (%value * 1.2); } }
 if (%type != -1 && %this.shieldStrength) { %energy = GameBase::getEnergy(%this);
 %strength = %this.shieldStrength;
 if (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $ImpactDamageType) %strength *= 0.75;
 if (%type == $FEBDamageType) %value = 0.005;
 %absorb = %energy * %strength;
 if (%value < %absorb) { GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
 %thisPos = getBoxCenter(%this);
 %offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
 %data = GameBase::getDataName(%this);
 %data.shieldShape = "fusionex";
 GameBase::activateShield(%this,%vec,%offsetZ); %value = 0;
 } else {
 GameBase::setEnergy(%this,0); %value = %value - %absorb; } }

 if (%type == $EMPDamageType) StartEMP(%damagedClient, %this, %shooterClient, %type);
 if (%value) { %armor = Player::getArmor(%this); %hitdamageval = 0.05;
 if(%armor == "harmor" || %armor == "hbarmor") %hittolerance = 0.25;
 else %hittolerance = 0.41;
 %weaponType = Player::getMountedItem(%this,$WeaponSlot);
 if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun" && %weaponType != "HvyThruster" && %weaponType != "MedThruster") && (%damagedTeam != %shooterTeam)) { Player::trigger(%this,$WeaponSlot,false);
 if(String::findSubStr(%weaponType, "LockingLaser") > 0) { Player::unmountItem(%this,$WeaponSlot); messageall(0, Client::getName(%shooterClient) @ " sniped the Vengeance Locking Laser out of " @ Client::getName(%damagedClient) @ "'s Hand!"); } else if(%weaponType == MissileLauncher) { Player::unmountItem(%this,$WeaponSlot); messageall(0, Client::getName(%shooterClient) @ " stopped " @ Client::getName(%damagedClient) @ "'s Vengeance From Firing with a sniper Shot!"); } else { WeaponDrop(%this,%weapontype); messageall(0, Client::getName(%shooterClient) @ " sniped the " @ %weaponType @ " out of " @ Client::getName(%damagedClient) @ "'s Hand!"); } %dlevel = GameBase::getDamageLevel(%this) + %hitdamageval; } else { %tempval = %value; %value = $DamageScale[%armor, %type] * %value * %friendFire; %dlevel = GameBase::getDamageLevel(%this) + %value; } %spillOver = %dlevel - %armor.maxDamage; if(%dlevel >= %armor.maxDamage) { %flag = Player::getMountedItem(%this,$FlagSlot); if(%flag == "flag") { if(%damagedClient != %shooterClient) { if(%damagedTeam != %shooterTeam) { %shooterClient.score+=1; Game::refreshClientScore(%shooterClient); schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Recieve 2 Points for Killing the Enemy Flag Carrier!\");",1); } else { %shooterClient.score-=1; Game::refreshClientScore(%shooterClient); schedule("Client::sendMessage(" @ %shooterClient @ ", 0, \"You Lose 2 Points for Killing your own Flag Carrier!\");",1); } } } } GameBase::setDamageLevel(%this,%dlevel); %flash = Player::getDamageFlash(%this) + %value * 2; if (%flash > 0.75) %flash = 0.75; Player::setDamageFlash(%this,%flash); if(!Player::isDead(%this)) { %flag = Player::getMountedItem(%this,$FlagSlot); if((%tempval > %hittolerance) && (%type == $LaserDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle" || %quadrant == "back_left" || %quadrant == "back_right") && (%vertpos == "head" || %vertpos == "torso") && (%flag == "flag") && (%damagedTeam != %shooterTeam)) FlagDrop(%damagedClient, %this, %shooterClient); if(%damagedClient.lastDamage < getSimTime()) { %sound = radnomItems(3,injure1,injure2,injure3); playVoice(%damagedClient,%sound); %damagedClient.lastdamage = getSimTime() + 1.5; } } else { if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $BomberDamageType)) || %type == $MagneticDamageType) { Player::trigger(%this, $WeaponSlot, false); %weaponType = Player::getMountedItem(%this,$WeaponSlot); if(%weaponType != -1) Player::dropItem(%this,%weaponType); if (%type == $MagneticDamageType) playSound(ShockExplosion,GameBase::getPosition(%this)); Player::blowUp(%this); } else { if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) { if(%quadrant == "front_left" || %quadrant == "front_right") %curDie = $PlayerAnim::DieBlownBack; else %curDie = $PlayerAnim::DieForward; } else if( Player::isCrouching(%this) ) %curDie = $PlayerAnim::Crouching; else if(%vertPos=="head") { if(%quadrant == "front_left" || %quadrant == "front_right" ) %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack); else %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward); } else if (%vertPos == "torso") { if(%quadrant == "front_left" ) %curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel); else if(%quadrant == "front_right") %curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin); else if(%quadrant == "back_left" ) %curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); else if(%quadrant == "back_right") %curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); } else if (%vertPos == "legs") { if(%quadrant == "front_left" || %quadrant == "back_left") %curDie = $PlayerAnim::DieLegLeft; if(%quadrant == "front_right" || %quadrant == "back_right") %curDie = $PlayerAnim::DieLegRight; } Player::setAnimation(%this, %curDie); } if(%type == $ImpactDamageType && %object.clLastMount != "") %shooterClient = %object.clLastMount; Client::onKilled(%damagedClient,%shooterClient, %type); } } } } } function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6) { return %an[floor(getRandom() * (%num - 0.01))]; }

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
      if (%count) { %delta = Item::giveItem(%object,getItemData(%i),%count);
      if (%delta > 0) { Player::decItemCount(%this,%i,%delta); %sound = true; } } }
      if (%sound) { playSound(SoundPickupItem,GameBase::getPosition(%this)); } } } }

 function Player::getHeatFactor(%this) { %client = Player::getClient(%this); if (Client::getControlObject(%client) != %this) return 1.0; if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") return 0.0; if((Player::getMountedItem(%this,$WeaponSlot) == "Inferno") && (Player::isTriggered(%this,$WeaponSlot))) return 1.0; if((Player::getMountedItem(%this,$BackpackSlot) == "RocketBooster") && ($MyHeat[%client])) return ($MyHeat[%client]); %time = getIntegerTime(true) >> 5; %lastTime = Player::lastJetTime(%this) >> 10; if ((%lastTime + 1.5) < %time) { return 0.0; } else { %diff = %time - %lastTime; %heat = 1.0 - (%diff / 1.5); return %heat; } }

 function Player::jump(%this,%mom) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %vehicle = Player::getMountObject (%this); %this.lastMount = %vehicle; %this.newMountTime = getSimTime() + 3.0; Player::setMountObject(%this, %vehicle, 0); Player::setMountObject(%this, -1, 0); Player::applyImpulse(%pl,%mom); playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this)); } }

 function remoteKill(%client) { if(!$matchStarted) return; %player = Client::getOwnedObject(%client); if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) { %client.score-=1; Game::refreshClientScore(%client); Client::sendMessage(%client, 0, "You Lost 2 Points for Choosing to Kill Yourself."); playNextAnim(%client); Player::kill(%client); Client::onKilled(%client,%client); } } $animNumber = 25; function playNextAnim(%client) { if($animNumber > 36) $animNumber = 25; Player::setAnimation(%client,$animNumber++); }

 function Client::takeControl(%clientId, %objectId) { if(%objectId == -1) { return; } %pl = Client::getOwnedObject(%clientId); if(%pl.driver != "" || %pl.vehicleSlot != "") return; if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)) { return; } if(GameBase::getControlClient(%objectId) != -1) { echo("Ctrl Client = " @ GameBase::getControlClient(%objectId)); return; } %name = GameBase::getDataName(%objectId); if((%name != CameraTurret && %name != DeployableTurret) && (%name != DeployableSentry && %name != DeployableAvenger)) { if(!GameBase::isPowered(%objectId)) { return; } } if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats) { Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets"); return; } if(GameBase::getDamageState(%objectId) == "Enabled") { Client::setControlObject(%clientId, %objectId); Client::setGuiMode(%clientId, $GuiModePlay); } }

 function remoteCmdrMountObject(%clientId, %objectIdx) { Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx)); }

 function checkControlUnmount(%clientId) { %ownedObject = Client::getOwnedObject(%clientId); %ctrlObject = Client::getControlObject(%clientId); if(%ownedObject != %ctrlObject) { if(%ownedObject == -1 || %ctrlObject == -1) return; if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject) return; Client::setControlObject(%clientId, %ownedObject); } }


 function StartEMP(%clientId, %player, %shooter, %type) { %weapon = Player::getMountedItem(%player,$WeaponSlot); if($FloodRockets[%clientId]) FloodShutdown(%clientId, %player, "EMP"); if(($WeaponAmmo[%weapon] == "") && (%weapon != "Thruster")) Player::unmountItem(%player,$WeaponSlot); if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " hit you with an EMP!"); else Client::sendMessage(%clientId,1,"You hit yourself with an EMP!"); playSound(SoundEMPDrain,GameBase::getPosition(%player)); if($empTime[%clientId] == 0) { GameBase::setEnergy(%player,0); GameBase::setRechargeRate(%player,0); $empTime[%clientId] = 10; checkPlayerEMP(%clientId, %player); } else $empTime[%clientId] = 10; } function checkPlayerEMP(%clientId, %player) { if($empTime[%clientId] > 0) { %vel = Item::getVelocity(%player); %trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); $empTime[%clientId] -= 1; schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",1,%player); } else { Client::sendMessage(%clientId,1,"EMP Effects have dissipated."); GameBase::setRechargeRate(%player,8); } }

 function FlagDrop(%clientId, %player, %shooterId) { %playerTeam = GameBase::getTeam(%player); %flag = %player.carryFlag; %flagTeam = GameBase::getTeam(%flag); %playerName = Client::getName(%clientId); %shooterName = Client::getName(%shooterId); if(%flagTeam == -1) { MessageAllExcept(%clientId, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %playerName @ "'s back!"); Client::sendMessage(%clientId, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!"); } else { MessageAllExcept(%clientId, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %playerName @ "'s back!"); Client::sendMessage(%clientId, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!"); TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field."); } GameBase::throw(%flag, %player, -15, false); Item::hide(%flag, false); Player::setItemCount(%player, "Flag", 0); %flag.carrier = -1; %player.carryFlag = ""; Flag::clearWaypoint(%clientId, false); schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime); %flag.dropFade = 1; ObjectiveMission::ObjectiveChanged(%flag); }

 function WeaponDrop(%this, %weapon) { Player::unmountItem(%this,$WeaponSlot); if(%weapon == Phalanxx) { Player::setItemCount(%this,"Phalanxx",0); Player::setItemCount(%this,"Phalanxx2",0); } else Player::setItemCount(%this,%weapon,0); %obj = newObject("","Item",%weapon,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%this,10,true); }

 function Heat(%clientId, %player, %type) { %clientId.heat += $HeatIncrease[%type]; if(!%clientId.cool) { %clientId.cool = "true"; schedule("Cool(" @ %clientId @ ");", 0.1); } %flash = (%clientId.heat - 2) * 0.075; if (%flash < 0) %flash = 0; Player::setDamageFlash(%player,%flash); return %clientId.heat; }

 function Cool(%clientId) { if(%clientId.heat && %clientId.cool) { %clientId.heat -= 0.25; if(%clientId.heat < 0) %clientId.heat = 0; schedule("Cool(" @ %clientId @ ");", 0.1); } else %clientId.cool = "false"; }

 function Detonate(%player) { Player::blowUp(%player); %obj = newObject("","Mine","Detonate"); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,-0.1,false); }

 function DotProd(%vec, %scalar) { %return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar); return %return; }

 function CheckStationKick(%player, %victimId, %shooterId) { if(%player.inStation) { if(%shooterId.redFlag) { messageAll(2,%object @ " Would have been Kicked for Shooting " @ %victim @ " out of the station"); %object.redFlag = flase; } else { centerPrint(%object,"<jc><F2>***** WARNING *****<f2>\n\nSHOOTING PLAYERS OUT OF INVENTORY STATIONS WILL NOT BE TOLERATED\nTRY IT AGAIN AND YOU WILL BE KICKED."); %object.redFlag = true; Player::unMountItem(GameBase::getOwnedObject(%shooterId),$WeaponSlot); } } }

