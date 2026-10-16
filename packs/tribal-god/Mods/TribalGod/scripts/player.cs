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
$CorpseTimeoutValue = 3;

function Player::onAdd(%this){ GameBase::setRechargeRate(%this, 8); }
function Player::onNoAmmo(%player, %imageSlot, %itemType){}

function Player::onKilled(%this){
	if((GameBase::getOwnerClient(%this)).droid == true || (GameBase::getOwnerClient(%this)).isPossessed == true) return;
	
	Player::setDamageFlash(%this, 1.75);
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0) Schedule("Game::autoRespawn("@ %cl @");", $AutoRespawn, %cl);
	
	// Suicide detpack will do it's job now,
	// It's rigged to your heart beat, if it stops the timer starts. [TG]-X-Ecutioner :)
	if(Player::getMountedItem(%this, $BackpackSlot) == "SuicidePack"){
		%obj = newObject("", "Mine", "Suicidebomb2");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 10, false);
		Client::sendMessage(%cl, 1, "Det Pack will Self-Destruct in 20 seconds");
		Schedule("BottomPrint("@ %cl @", \"<jc><f1>Det Self Desctructs in: 3\", 1);", 17.00, %cl);
		Schedule("BottomPrint("@ %cl @", \"<jc><f1>Det Self Desctructs in: 2\", 1);", 18.00, %cl);
		Schedule("BottomPrint("@ %cl @", \"<jc><f1>Det Self Desctructs in: 1\", 1);", 19.00, %cl);
		Schedule("BottomPrint("@ %cl @", \"<jc><f1>Det Self Desctructs in: <f2>DETONATING\", 5);", 20.00, %cl);
	}
	for(%i = 0; %i < 8; %i = %i + 1){
		%type = Player::getMountedItem(%this, %i);
		if(%type != -1){
			if(%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
			Player::dropItem(%this, %type);
		}
	}
	
	if(%cl != -1){
		if(%this.vehicle != ""){
			if(%this.driver != ""){
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
			}else{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}
		
		Schedule("GameBase::startFadeOut("@ %this @");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		Schedule("deleteObject("@ %this @");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
	}
}

function Player::onRemove(%this){
	// Drop anything left at the players pos
	for(%i = 0; %i < 8; %i = %i + 1){
		%type = Player::getMountedItem(%this, %i);
		if (%type != -1){
			// Note: Player::dropItem is not called here.
			%item = newObject("", "Item", %type, 1, false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item, GameBase::getPosition(%this));
		}
	}
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object){
	%dataname = GameBase::getDataName(%this);
	%maxDamage = %dataname.maxDamage;
	%damagelvl = GameBase::getDamagelevel(%this);
	
	// Don't think this worked, but i'll leave it in here anyway.. -Dustin B.
	// if the damage your about to get + however much damage you have allready is
	// greater than or equal to the max damage of %this we trigger the weapon slot FALSE
	if(%value + %damagelvl >= %maxDamage) Player::trigger(%this, $WeaponSlot, false);
	
	if($NoPlayerDamage == 1 && %type != $MineDamageType){
		if(%object.msgSpam != true){
			BottomPrint(%object, "<jc><f1>Player Damage Is Disabled!");
			Client::sendMessage(%object, 0, "~wError_Message.wav");
			%object.msgSpam = true;
			Schedule(%object @".msgSpam = false;",5);
		}
		return;
	}
	
	if(!Player::isExposed(%this)) return;
	%d = Player::getClient(%this);
	%dTeam = Client::getTeam(%d);
	%s = %object;
	%sTeam = Client::getTeam(%s);
	
	Player::applyImpulse(%this,%mom);
	if($teamplay && %d != %s && %dTeam == %sTeam){
		if(%s != -1){
			%curTime = getSimTime();
			if($Server::TeamDamageScale > 0 && (%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %s)){
				if(%type != $MineDamageType){
					Client::sendMessage(%s,0,"You just harmed Teammate "@ Client::getName(%d) @"!");
					Client::sendMessage(%d,0,"You took Friendly Fire from "@ Client::getName(%s) @"!");
				}else{
					Client::sendMessage(%s,0,"You just harmed Teammate "@ Client::getName(%d) @" with your mine!");
					Client::sendMessage(%d,0,"You just stepped on Teamate "@ Client::getName(%s) @"'s mine!");
				}
				%this.LastHarm = %s;
				%this.DamageStamp = %curTime;
			}
		}
		%friendFire = $Server::TeamDamageScale;
	}else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == %dTeam) %friendFire = $Server::TeamDamageScale;
	else %friendFire = 1.0;
	
	if(Player::isDead(%this)) return;
	
	%armor = Player::getArmor(%this);
	if(%vertPos == "head" && %type == $LaserDamageType){// Headshot takes more.
		if(%armor == "harmor"){
			if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle"){
				%value += (%value * 0.3);
			}
		}else{
			%value += (%value * 0.3);
		}
	}
	
	if(%type != -1 && %this.shieldStrength){// If Shielded.
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
		{ %strength *= 0.75; }
		%absorb = %energy * %strength;
		if(%value < %absorb){
			GameBase::setEnergy(%this, %energy - ((%value / %strength) * %friendFire));
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos, 2)) - (getWord(%thisPos, 2)));
			GameBase::activateShield(%this, %vec, %offsetZ);
			%value = 0;
		}else{
			GameBase::setEnergy(%this, 0);
			%value = %value - %absorb;
		}
	}
	
	if(%type == $EMPDamageType){
		if(%dTeam != %sTeam) return;
		
		%poolockName = Client::getName(%s);
		%pooGetweaponItem = Player::getMountedItem(%this,0);
		%pooGetpackItem = Player::getMountedItem(%this,1);
		%pooGetflagItem = Player::getMountedItem(%this,2);
		
		GameBase::setEnergy(%this, 0);
		GameBase::setRechargeRate(%this, 10);
		Player::setdamageflash(%this, 0.2);
		Client::sendMessage(%d, 1, %poolockName @" hit you with an EMP!");
		Client::sendMessage(%d, 1, "Energy systems malfunctioning.");
		player::dropitem(%this,%pooGetpackItem);
		player::dropitem(%this,%pooGetweaponItem);
		player::dropitem(%this,%pooGetflagItem);
	}
	
	if(%type == $ClaymorDamageType){
		if(%sTeam == %dTeam) return;
		%shooterName = Client::getName(%s);
		%damagedWeapon = Player::getMountedItem(%d, 0);
		%damagedPack = Player::getMountedItem(%d, 1);
		%damagedFlag = Player::getMountedItem(%d, 2);
		
		GameBase::setEnergy(%this, GameBase::getEnergy(%this) -0.5);
		GameBase::setRechargeRate(%this, 10);
		Player::setDamageFlash(%this, 0.5);
		Client::sendMessage(%d, 1, %shooterName @"'s Cloymor Blew A Hole In Your Leg!~wLeftMissionArea.wav");
		Client::sendMessage(%s, 1, Client::getName(%d) @" just ate one of your claymor mines!~wmale5.wcheer1.wav");
		
		Player::dropItem(%this, %damagedPack);
		Player::dropItem(%this, %damagedWeapon);
		Player::dropItem(%this, %damagedFlag);
	}
	
	if(%type == $MiniELFDamageType){
		%pooGetweaponItem = Player::getMountedItem(%d,0);
		%pooGetpackItem = Player::getMountedItem(%d,1);
		Player::setdamageflash(%this, 0.2);
		Player::dropitem(%this, %pooGetpackItem);
		Player::dropitem(%this, %pooGetweaponItem);
	}
	
	if(%type == $JailDamageType){
		Jailbolt::damageTarget(%this, 0, 0, 0, %pos, %vec, %mom, %object);
	}
	
	if(%type == $BulletDamageType){
		if(%dTeam != %sTeam){
			if(%vertPos == "head"){
				player::blowup(%this);
				%value += (%value * 2);
				XBottomprint(%s,"<f1><jc>Damn You Gotta Head Shot On <f2> "@ Client::getName(%d) @"<f1>!",5);
				XBottomprint(%d,"<jc><f2>"@ Client::getName(%s) @" <f1>Just Sniped Yer Punk Ass, HeadShot<f2>!",5);
			}
		}
	}
	
	if(%type == $LiLPOOmkiiDamageType)	{
		if(%dTeam != %sTeam){
			if(%vertPos == "head") {
				player::blowup(%this);
				%value += (%value * 2);
				XBottomprint(%s,"<f1><jc>Damn You Gotta Head Shot On <f2> "@ Client::getName(%d) @"<f1>!",5);
				XBottomprint(%d,"<jc><f2>"@ Client::getName(%s) @" <f1>Just Sniped Yer Punk Ass, HeadShot<f2>!",5);
			}
		}
	}
	
	if(%type == $SmokeDamageType){
		Client::sendMessage(%d,1,"WARNING - Toxic Gas Detected!~werror_message.wav");
		GameBase::setDamageLevel(%this, GameBase::getDamageLevel(%this) + 0.25);
	}
	
	if(%type == $FlashDamageType){
		Player::setdamageflash(%this, 7);
		Gamebase::setenergy(%this, 0);
		Gamebase::setrechargerate(%this, 8);
		Client::sendMessage(%d, 1, "Energy systems malfunctioning.");
	}
	
	if(%type == $TrapDam1){
		Client::sendMessage(%d,1,"Phasing Thru Portal!~wdiscspin.wav");
		%portrot = GameBase::getRotation(%object);
		%vec_x = getWord(%portrot,0);
		%vec_y = getWord(%portrot,1);
		%vec_z = getWord(%portrot,2);
		%fixx = ((%vec_x) + 1.57);
		%newrot = %fixx @" "@ %vec_y @" "@ %vec_z;
		
		if(%vec_x == 0){
			%chanpos = "0 0 -4";
			%npos = Vector::add(GameBase::getPosition(%this), %chanpos);
			GameBase::setPosition(%this, %npos);
		}
		else if(%vec_y != 0){
			%chanpos = "0 0 4";
			%npos = Vector::add(GameBase::getPosition(%this), %chanpos);
			GameBase::setPosition(%this, %npos);
		}else{
			%basevec = "0 -4 0";
			%npos = Vector::add(GameBase::getPosition(%this), EmplacementPack::rotVector(%basevec, %newrot));
			GameBase::setPosition(%this, %npos);
		}
	}
	
	if(%type == $BeamOfPainDamageType){
		if(%dTeam != %sTeam){
			%pooGetweaponItem = Player::getMountedItem(%d, 0);
			%pooGetpackItem = Player::getMountedItem(%d, 1);
			%pooGetflagItem = Player::getMountedItem(%d, 2);
			player::setdamageflash(%this, 0.7);
			player::dropitem(%this, %pooGetpackItem);
			player::dropitem(%this, %pooGetweaponItem);
			player::dropitem(%this, %pooGetflagItem);
		}
	}
	
	if(%type == $MiscDamageType){
		if(GameBase::getTeam(%this) != Client::getTeam(%object)) return;
	}
	
	if(%type == $NukerDamageType){
		%status = Client::getStatus(%d);
		if(%this.isUnNukable == true || %d == %s){
			Client::sendMessage(%d, 0, "Nuke Shield Enabled.~wturret_whir.wav");
			return;
		}
		
		if(%dTeam == %sTeam){
			GameBase::setDamageLevel(%this, 0);
			Client::sendMessage(%d, 0, "Nuke Shield Enabled.~wturret_whir.wav");
			return;
		}
		%weaponMounted = Player::getMountedItem(%d, 0);
		%packMounted = Player::getMountedItem(%d, 1);
		%flagMounted = Player::getMountedItem(%d, 2);
		Player::setDamageFlash(%this, 0.75);
		Player::dropItem(%this, %packMounted);
		Player::dropItem(%this, %weaponMounted);
		Player::dropItem(%this, %flagMounted);
		
		%energy = GameBase::getEnergy(%this);
		%energy = %energy - %energy;
		if(%energy < 0){
			%energy = 0;
		}
		GameBase::setEnergy(%this, %energy);
		GameBase::setRechargeRate(%this, 0);
		Schedule("GameBase::setRechargeRate("@ %this @", 45);", 10, %this);
		Schedule("GameBase::setRechargeRate("@ %this @", 10);", 20, %this);
		// Set life
		%dudesLife = GameBase::getDamageLevel(%this);
		%damage = %dudesLife + (%this.maxDamage / 2);
		GameBase::setDamageLevel(%this, %damage);
		%shooterName = Client::getName(%s);
		if(Client::getControlObject(%s) == -1)
		{ %shooterName = GameBase::getMapName(Client::getControlObject(%s)); }
		// If client is dead or observing don't use any messages..
		if(%status != "(Observing)" && %status != "(Dead)"){
			Client::sendMessage(%d, 1, "Nuclear Detected.~wshieldhit.wav"); 
			XBottomPrint(%d, "<jc><f0>EMP Disables Armor For 10 Seconds.", 10); 
			Schedule("Client::sendMessage("@ %d @",0,\"Armor Is Back Online~wbuysellsound.WAV\");", 10, %d); 
			Schedule("XBottomPrint("@ %d @",\"<jc><f1>Armor Online.\", 5);", 10, %d);
		}
	}
		
	if(%value){
		%value = $DamageScale[%armor, %type] * %value * %friendFire;
		%dlevel = GameBase::getDamageLevel(%this) + %value;
		%spillOver = %dlevel - %armor.maxDamage;
		GameBase::setDamageLevel(%this,%dlevel);
		%flash = Player::getDamageFlash(%this) + %value * 2;
		
		if(%flash > 0.75)
		{ %flash = 0.75; }
		Player::setDamageFlash(%this,%flash);
		
		// If player not dead then play a random hurt sound
		if(!Player::isDead(%this)){
			if(%d.lastDamage < getSimTime()){
				%sound = radnomItems(3,injure1,injure2,injure3);
				playVoice(%d,%sound);
				%d.lastdamage = getSimTime() + 1.5;
			}
		}else{
			if(%spillOver > 0.5 && (%type == $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $LiLRocketDamageType)) 
			{
				Player::trigger(%this, $WeaponSlot, false);
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				if(%weaponType != -1)
				{ Player::dropItem(%this, %weaponType); }
				Player::blowUp(%this);
			}else{
				if((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $LiLRocketDamageType)) || (Player::getLastContactCount(%this) > 6)){
					if(%quadrant == "front_left" || %quadrant == "front_right"){ %curDie = $PlayerAnim::DieBlownBack; }
					else{ %curDie = $PlayerAnim::DieForward; }
				}
				else if(Player::isCrouching(%this)){
					%curDie = $PlayerAnim::Crouching;
				}
				else if(%vertPos=="head"){
					if(%quadrant == "front_left" ||	%quadrant == "front_right"	){ %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack); }
					else{ %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward); }
				}
				else if(%vertPos == "torso"){
					if(%quadrant == "front_left" ) %curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
					else if(%quadrant == "front_right") %curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
					else if(%quadrant == "back_left" ) %curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
					else if(%quadrant == "back_right") %curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
				}
				else if(%vertPos == "legs"){
					if(%quadrant == "front_left" ||	%quadrant == "back_left"){ %curDie = $PlayerAnim::DieLegLeft; }
					if(%quadrant == "front_right" ||	%quadrant == "back_right"){ %curDie = $PlayerAnim::DieLegRight; }
				}
				Player::setAnimation(%this, %curDie);
			}
			if(%type == $ImpactDamageType && %object.clLastMount != "")
			{ %s = %object.clLastMount; }
			Client::onKilled(%d, %s, %type);
		}
	}
}
               

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this, %object)
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
				playSound(SoundPickupItem, GameBase::getPosition(%this));
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
	if(Client::getControlObject(%client) != %this)
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

function Player::jump(%this, %mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
	   %vehicle = Player::getMountObject(%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}

function remoteKill(%client)
{
	if(!$matchStarted)
	{ return; }
	
	if(%client.droid == true)
	{
		if(%client.inTransition == true)
		{ Client::sendMessage(%client, 1, "Wait Untill Your Controlling The Droid.~wAccess_Denied.Wav"); return; }
		eval(%client.DroidType @"::onDestroyed("@ %client @".newPlayer);");
		return;
	}
	else
	{
		if(%client.noSuicide == 1 || %client.noSuicide == true)
		{ Client::sendMessage(%client, 0, "You have lost your ability to comit Suicide.~wAccess_Denied.Wav"); return; }
	}
	
	%player = Client::getOwnedObject(%client);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%client);
		Player::kill(%client);
		Client::onKilled(%client, %client);
	}
}

$animNumber = 25;	 
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client, $animNumber++);
}

function Client::takeControl(%clientId, %objectId){
	%pl = Client::getOwnedObject(%clientId);
	%name = GameBase::getDataName(%objectId);
	
	if(%objectId == -1 || %pl.driver != "" || %pl.vehicleSlot != "" || GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{ return; }
	
	if(GameBase::getControlClient(%objectId) != -1)
	{ Echo("Ctrl Client = "@ GameBase::getControlClient(%objectId)); return; }
	
	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableTaserTrtB && %name != DeployableTaserTrtC && %name != LaserTurret && %name != LaserTurretB && %name != MiniFlakTurret && %name != MiniSAMTurret && %name != MiniELFTurret && %name != MiniSmokeTurret){
		if(!GameBase::isPowered(%objectId)){ return; }
	}
	
	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats)
	{ Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets"); return; }
	if(GameBase::getDamageState(%objectId) == "Enabled")
	{ Client::setControlObject(%clientId, %objectId); Client::setGuiMode(%clientId, $GuiModePlay); }
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{ Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx)); }

function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject)
	{
		if(%ownedObject == -1 || %ctrlObject == -1)
		{ return; }
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
		{ return; }
		Client::setControlObject(%clientId, %ownedObject);
	}
}