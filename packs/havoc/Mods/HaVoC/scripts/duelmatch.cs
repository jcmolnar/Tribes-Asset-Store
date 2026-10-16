exec(objectives);

$DuelCountdownSeconds = 9;

$DuelSpotTaken[1] = false;

$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;

$DuelWeaponMax = 17;
$DuelPackMax = 4;

$DuelTempWinner = 0;
$DuelLastWinner = 0;

$DuelWeapon[1] = "Shotgun";
$DuelWeapon[2] = "Chaingun";
$DuelWeapon[3] = "Plasma Gun";
$DuelWeapon[4] = "Disc Launcher";
$DuelWeapon[5] = "Rocket Launcher";
$DuelWeapon[6] = "Grenade Launcher";
$DuelWeapon[7] = "EMP Grenade Launcher";
$DuelWeapon[8] = "Laser Rifle";
$DuelWeapon[9] = "Sniper Rifle";
$DuelWeapon[10] = "Railgun";
$DuelWeapon[11] = "Dart Rifle";
$DuelWeapon[12] = "Magnum";
$DuelWeapon[13] = "Flame Thrower";
$DuelWeapon[14] = "Shockwave Cannon";
$DuelWeapon[15] = "Hyper Spinfusor";
$DuelWeapon[16] = "ELF Gun";
$DuelWeapon[17] = "Blaster";

$DuelPack[1] = "Energy Pack";
$DuelPack[2] = "Repair Pack";
$DuelPack[3] = "Shield Pack";
$DuelPack[4] = "Ammo Pack";

$DuelRealPack[1] = EnergyPack;
$DuelRealPack[2] = RepairPack;
$DuelRealPack[3] = ShieldPack;
$DuelRealPack[4] = AmmoPack;

$DuelRealWeapon[1] = Shotgun;
$DuelRealWeapon[2] = Chaingun;
$DuelRealWeapon[3] = PlasmaGun;
$DuelRealWeapon[4] = DiscLauncher;
$DuelRealWeapon[5] = RocketLauncher;
$DuelRealWeapon[6] = GrenadeLauncher;
$DuelRealWeapon[7] = EMPGrenadeLauncher;
$DuelRealWeapon[8] = LaserRifle;
$DuelRealWeapon[9] = SniperRifle;
$DuelRealWeapon[10] = Railgun;
$DuelRealWeapon[11] = TranqGun;
$DuelRealWeapon[12] = Silencer;
$DuelRealWeapon[13] = Flamer;
$DuelRealWeapon[14] = WaveGun;
$DuelRealWeapon[15] = HDiscLauncher;
$DuelRealWeapon[16] = EnergyRifle;
$DuelRealWeapon[17] = Blaster;

$DuelWeaponAmmo[1] = ShotgunShells;
$DuelWeaponAmmo[2] = BulletAmmo;
$DuelWeaponAmmo[3] = PlasmaAmmo;
$DuelWeaponAmmo[4] = DiscAmmo;
$DuelWeaponAmmo[5] = RocketAmmo;
$DuelWeaponAmmo[6] = GrenadeAmmo;
$DuelWeaponAmmo[8] = EMPGrenadeAmmo;
$DuelWeaponAmmo[9] = SniperAmmo;
$DuelWeaponAmmo[10] = RailAmmo;
$DuelWeaponAmmo[11] = TranqAmmo;
$DuelWeaponAmmo[12] = SilencerAmmo;
$DuelWeaponAmmo[15] = HDiscAmmo;
	                  
function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) {                                                                                                              
   	%damVal = %timeSlice * %damPerSec;
   	%enVal  = %timeSlice * %enDrainPerSec;
                 
   	%clientId = GameBase::GetControlClient(%target);
   	if (!$Dueling[%clientId]) return;                               
   	if (!$DuelCanHurt[%clientId]) return;
   	if (!$Dueling[%shooterId]) return;
   	if ($Dueling[%shooterId] != %clientId && %clientId != %shooterId) {
		Bottomprint(%foeId, "<jc><f2>Wrong Target!");
		return;                                         
   	}
    
	if (%damPerSec == 0.119997 || %damPerSec == 0.0449997 || %damPerSec == 0.0999997)
		GameBase::applyDamage(%target, $ElectricityTEDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
	else if(%damPerSec == 0.125 || %damPerSec == 0.176997)
		GameBase::applyDamage(%target, $Lit2DamageType, %damVal, %pos, %vec, %mom, %shooterId); 
	else if(%damPerSec == 0.109997)
		GameBase::applyDamage(%target, $LitDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
	else
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); 

	%ot = getObjectType(%target);
	if (%ot == "Turret" || %ot == "Sensor") %enVal *= 0.22;

   	%energy = GameBase::getEnergy(%target);
   	%energy = %energy - %enVal;
   	if (%energy < 0) {
      	%energy = 0;
   	}
   	GameBase::setEnergy(%target, %energy);
}

function DuelCountdown(%clientId, %foeId, %timeLeft, %clientPl, %foePl) {
	if(!$Dueling[%clientId] || !$Dueling[%foeId]) return;
	if (%timeLeft == 0) {
		BeginDuel(%clientId, %foeId, %clientPl, %foePl);
		return;
	}
	if (%timeLeft == 1) {
		BottomPrint(%clientId,"<jc><f1>Duel starts in <f2>1<f1> second.",2);
		BottomPrint(%foeId,"<jc><f1>Duel starts in <f2>1<f1> second.",2);
	} else {
		if (%timeLeft > 5) {
			CenterPrint(%clientId,"<jc><f2>GET READY!",2);
			CenterPrint(%foeId,"<jc><f2>GET READY!",2);
		} else {
			BottomPrint(%clientId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
			BottomPrint(%foeId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
		}
	}         
	schedule("DuelCountdown(" @ %clientId @ "," @ %foeId @ "," @ (%timeLeft - 1) @ "," @ %clientPl @ "," @ %foePl @ ");", 1);
}

function DuelResetClient(%clientId) {
	$DuelPartner[$DuelPartner[%clientId]] = 0;
	$DuelPartner[%clientId] = 0;
	$Dueling[%clientId] = "";
	$DuelWeaponSetup[%clientId, 0] = 0;
	$DuelWeaponSetup[%clientId, 1] = 0;
	$DuelWeaponSetup[%clientId, 2] = 0;
	$DuelPack[%clientId] = "";
   	$HighStreak[%clientId] = 0;
	$DuelAlive[%clientId] = false;
   	$DuelStreak[%clientId] = 0;
	$DuelTModeOff[%clientId] = false;
	%clientId.guiLock = false;
}

function ClearMines(%clientId) {
	if ($DuelMine1[%clientId] != "") {                                                            
		if (getObjectType($DuelMine1[%clientId]) == "Mine")
			GameBase::setDamageLevel($DuelMine1[%clientId], 2);
		$DuelMine1[%clientId] = "";
	}
	if ($DuelMine2[%clientId] != "") {
		if (getObjectType($DuelMine2[%clientId]) == "Mine")
			GameBase::setDamageLevel($DuelMine2[%clientId], 2);
		$DuelMine2[%clientId] = "";
	}
	if ($DuelMine3[%clientId] != "") {
		if (getObjectType($DuelMine3[%clientId]) == "Mine")
			GameBase::setDamageLevel($DuelMine3[%clientId], 2);
		$DuelMine3[%clientId] = "";
	}                      
}
                        
function LockPlayers(%clientId, %foeId, %clientPl, %foePl) {                          
	%clientId.observerMode = "pregame";
 	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
 	Observer::setOrbitObject(%clientId, %clientPl, -9, -9, -9);                
 	%foeId.observerMode = "pregame";
 	Client::setControlObject(%foeId, Client::getObserverCamera(%foeId));
 	Observer::setOrbitObject(%foeId, %foePl, -9, -9, -9);
}

function DuelStartHurt(%clientId, %foeId) {
	$DuelCanHurt[%clientId] = true;
	$DuelCanHurt[%foeId] = true;
}

function BeginDuel(%clientId, %foeId, %clientPl, %foePl) {                                
	if(!$Dueling[%clientId] || !$Dueling[%foeId]) return;

	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	messageall(0, "~wduelfight.wav");
	messageall(0, "FIGHT!");
	BottomPrint(%clientId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);
	BottomPrint(%foeId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);

	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%foeId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	if(!%hasenergy) schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ");", 30);

	Client::setControlObject(%clientId, %clientPl);
	Client::setControlObject(%foeId, %foePl);	
}

function PlayersOutOfAmmo(%clientId, %foeId) {
	if ($Dueling[%clientId] == %foeId && $Dueling[%foeId] == %clientId && $DuelCanHurt[%clientId] && $DuelCanHurt[%foeId]) {
		for (%i = 0; %i < 3; %i++) {
			if(Player::getItemCount(%clientId, $DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]])) {
				schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ");", 15);
				return;
			}
		}
		for (%i = 0; %i < 3; %i++) {
			if(Player::getItemCount(%foeId, $DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]])) {
				schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ");", 15);
				return;
			}
		}
		MessageAll(1,Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " have both run out of ammo. Its a draw.");
		FinalizeDuel(%clientId, %foeId);
	}
}
           
function FinalizeDuel(%clientId, %foeId) {
	$Dueling[%clientId] = false;
	$Dueling[%foeId] = false;

	$DuelFought[%clientId] = true;
	$DuelFought[%foeId] = true;

	ClearMines(%clientId);
	ClearMines(%foeId); 

	%clientId.guiLock = false;
	%foeId.guiLock = false;

	%clientId.poisonTime = 0;
	%foeId.poisonTime = 0;
	
	$DuelSpawnMarker[%clientId] = "";
	$DuelSpawnMarker[%foeId] = "";

	$DuelSpotTaken[$DuelSpotIndex[%clientId]] = false;
	$DuelSpotIndex[%clientId] = "";
	$DuelSpotIndex[%foeId] = "";

	$DuelPartner[%clientId] = 0;
	$DuelPartner[%foeId] = 0;

	Observer::enterObserverMode(%clientId);
	Observer::enterObserverMode(%foeId);

	Game::refreshClientScore(%clientId);
	Game::refreshClientScore(%foeId);

	DuelCheck();
}                                                 

function EndDuel(%clientId, %damageType) {
	%foeId = $Dueling[%clientId];
	if ($Dueling[%clientId] && $DuelCanHurt[%clientId]) {   
		$DuelTempWinner = %foeId;
		
		$DuelCanHurt[%clientId] = false;
		$DuelCanHurt[%foeId] = false;

		%foeId.score++;		
		$DuelStreak[%foeId]++;

		%clientId.scoreDeaths++;

		if(%damageType != -2) playASound(%clientId, %foeId);

		$DuelStreak[%clientId] = 0;

		$DuelAlive[%clientId] = false;
		$DuelAlive[%foeId] = true;

		MessageAll(1,Client::GetName(%foeId) @ " has triumphed over " @ Client::GetName(%clientId) @ "!");
		centerprint(%clientId,"<jc><f2>You lose!", 6);
		%msg = "<jc><f2>You win!";
		if($DuelStreak[%foeId] > 1) {
			if($DuelStreak[%foeId] > $HighStreak[%foeId]) $HighStreak[%foeId] = $DuelStreak[%foeId];	
			%msg = %msg @ "\n\n<f1>You have <f2>" @ $DuelStreak[%foeId] @ "<f1> wins in a row";
			if($DuelStreak[%foeId] > 3) {
				%msg = %msg @ "!";
				if($DuelStreak[%foeId] > 7)
					%msg = %msg @ "!!!";
				if($DuelStreak[%foeId] > 12)
					%msg = %msg @ "!!!!";
			} else 
				%msg = %msg @ ".";
		}
		centerprint(%foeId, %msg, 8);

		schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ ");", $DuelDelayTime);

		return;
	}
	FinalizeDuel(%clientId, %foeId);
}        

function Vote::changeMission() {
   $timeLimitReached = true;
   $timeReached = true;
   DuelMOD::missionObjectives();
}

function DuelInit(%clientId, %foeId) {
	if (!$DuelSpotTaken[1]) {                                                  
		$DuelSpotIndex[%clientId] = 1;
		$DuelSpotIndex[%foeId] = 1;
		%group = nameToID("MissionGroup/Duel1");
	   	%count = Group::objectCount(%group);
		$DuelSpawnMarker[%clientId] = Group::getObject(%group, 0);
		$DuelSpawnMarker[%foeId] = Group::getObject(%group, 1);
		$DuelSpotTaken[1] = true;
	} else {
		//TODO: take care of this case here
		return;
	}

	%clientId.observerMode = "";
	%foeId.observerMode = "";
	%foeId.observerTarget = "";
	%clientId.observerTarget = "";
	%clientId.guiLock = true;
	%foeId.guiLock = true;
	Client::setGuiMode(%clientId, $GuiModePlay);
	Client::setGuiMode(%foeId, $GuiModePlay);

	$Dueling[%clientId] = %foeId;
	$Dueling[%foeId] = %clientId;

	Game::refreshClientScore(%clientId);	
	Game::refreshClientScore(%foeId);	
	
	%clientPl = DuelSpawn(%clientId);
	%foePl = DuelSpawn(%foeId);                                  
	LockPlayers(%clientId, %foeId, %clientPl, %foePl);

	GameBase::SetTeam(%clientId, 0);
	GameBase::SetTeam(%clientPl, 0);
	GameBase::SetTeam(%foeId, 0);
	GameBase::SetTeam(%foePl, 0);

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
		if (%cl != %foeId && %cl != %clientId) {
			if(floor(getRandom() * 10) > 5)
				Observer::setTargetClient(%cl, %clientId);
			else
				Observer::setTargetClient(%cl, %foeId);
		}
	}		

	$DuelCanHurt[%clientId] = false;
	$DuelCanHurt[%foeId] = false;               
	DuelCountdown(%clientId, %foeId, $DuelCountdownSeconds, %clientPl, %foePl);
}

function Observer::setTargetClient(%client, %target) {
   	%owned = Client::getOwnedObject(%target);
   	if(%owned == -1) return false;
   	%client.observerMode = "observerOrbit";
	setObsOrbit(%client, %target, 5, 5, 5);
   	bottomprint(%client, "<jc><f2>Observing " @ Client::getName(%target) @ ".", 0);
   	%client.observerTarget = %target;
   	return true;
}

function DuelSpawn(%clientId) {                                                                  
	if($DuelSpawnMarker[%clientId] == -1) {
		%spawnPos = "0 0 300";
	    %spawnRot = "0 0 0";
	} else {
		%spawnPos = GameBase::getPosition($DuelSpawnMarker[%clientId]);
	    %spawnRot = GameBase::getRotation($DuelSpawnMarker[%clientId]);
	}
	if (Client::getGender(%clientId) == "Female")
        %armor = "dmfemale";
	else
       	%armor = "dmarmor";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);
	Client::setSkin(%clientId, $Client::info[%clientId, 0]); 

    if (!$DuelWeaponSetup[%clientId, 0])
		$DuelWeaponSetup[%clientId, 0] = 3;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 4;
	%packNo = $DuelPackSetup[%clientId];
	if (%packNo == "") %packNo = 1;
	%pack = $DuelRealPack[%packNo];
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < 3; %i++) {
    	%weapon = $DuelWeaponSetup[%clientId, %i];
       	%weaponAmmo = $DuelWeaponAmmo[%weapon];
       	%realweapon = $DuelRealWeapon[%weapon];
       	%armor = Player::GetArmor(%clientId);
       	Player::SetItemCount(%clientId,%realweapon,1);
       	if (%weaponAmmo != "") {
       		if (%pack == AmmoPack && $AmmoPackMax[%armor, %weaponAmmo] != "")
       			Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo] + $AmmoPackMax[%armor, %weaponAmmo]);
       		else
       			Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo]);
       	}
    }
    Player::SetItemCount(%clientId,Beacon,1);
    Player::SetItemCount(%clientId, MineAmmo, 3);
   	Player::SetItemCount(%clientId, Grenade, 5);  
	if (%pack == AmmoPack)
       	Player::SetItemCount(%clientId,RepairKit,2);
	else
       	Player::SetItemCount(%clientId,RepairKit,1);
	Player::UseItem(%clientId, $DuelRealWeapon[$DuelWeaponSetup[%clientId, 0]]);
	return %pl;
}

function Game::menuRequest(%clientId) { 
	if(!%clientId.isSuperAdmin && (%clientId.dan || %clientId.permap || %clientId.possessed)) return;

	%curItem = 0;
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "HaVoC " @ $HV @ " planettribes.com/havoc", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 
		
	if(%clientId.wat)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Watching", "unwat " @ %clientId.wat); 
	if(%clientId.possessing)
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession", "unposs " @ %clientId.poss); 
	
	if(!%clientId.selClient)
		Client::addMenuItem(%clientId, %curItem++ @ "Miscellany...", "misc"); 
	
	if(%clientId.selClient) { 
		%sel = %clientId.selClient; 
		if(%clientId.speakto != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Speak To...", "speak " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Cancel Speak To...", "nospeak " @ %sel);			
		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel) && !%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Observe...", "observe " @ %sel);
		else {
			if (!%clientId.isSuperAdmin && %clientId != %sel)
				if(Client::getTeam(%sel) == Client::getTeam(%clientId) || %clientId.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Watch...", "wat " @ %sel); 
		}
		if(!%clientId.isAdmin) {
			if($HaVoC::PVAdmin && !%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
			if($HaVoC::PVKick) 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
		} else if (%clientId.isAdmin && !%clientId.isSuperAdmin) {
			if($HaVoC::PASpecial[%clientId.adminNum]) {
				if($Special::PATorture[%clientId.adminNum])
					Client::addMenuItem(%clientId, %curItem++ @ "Torture...", "manip " @ %sel);
				if($HaVoC::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);
				if($Special::PAKick[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($HaVoC::PVKick) 
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
				if($Special::PABan[%clientId.adminNum]) 
					Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
				if($Special::PAGag[%clientId.adminNum]) 
					if(%sel.gag) 
						Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag...", "ungag " @ %sel); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Gag...", "gag " @ %sel); 
			} else {
				if($HaVoC::PVAdmin && !%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to Admin...", "vadmin " @ %sel);						
				if($HaVoC::PAKick) 
					Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				else 
					if($HaVoC::PVKick) 
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick...", "vkick " @ %sel);
				if($HaVoC::PABan) 
					Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
				if($HaVoC::PAGag) 
					if(%sel.gag) 
						Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag...", "ungag " @ %sel); 
					else 
						Client::addMenuItem(%clientId, %curItem++ @ "Gag...", "gag " @ %sel); 

			}
		} else if (%clientId.isSuperAdmin) {
			Client::addMenuItem(%clientId, %curItem++ @ "Torture...", "manip " @ %sel);
			if(!%sel.isAdmin) 
				Client::addMenuItem(%clientId, %curItem++ @ "Admin...", "admin " @ %sel);
			else
				if(%clientId == %sel || !%sel.isSuperAdmin || (%clientId.canRemove && !%sel.canRemove))
					Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Status...", "removeadmin " @ %sel);
			if(!%sel.isSuperAdmin) {
				Client::addMenuItem(%clientId, %curItem++ @ "Kick...", "kick " @ %sel); 
				Client::addMenuItem(%clientId, %curItem++ @ "Ban...", "ban " @ %sel);
			}
		}
		%IXKiller = HaVoC_getKiller(%clientId); 
		if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $HaVoC::tkLimit) { 
			if($HaVoC::tkClientLvl == 1) 
				Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Vote: Kick " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
		} 
		if(%clientId.muted[%sel]) 
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute...", "unmute " @ %sel); 
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Mute...", "mute " @ %sel); 
		return;
	} 
	
	if($curVoteTopic != "" && %clientId.vote == "") { 
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount); 
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount); 
		if(%clientId.isSuperAdmin && %clientId.canRemove) {
			Client::addMenuItem(%clientId, %curItem++ @ "Force vote to PASS", "makeitso " @ $curVoteCount); 
			Client::addMenuItem(%clientId, %curItem++ @ "Force vote to FAIL", "makeitno " @ $curVoteCount); 
		}
		return;
	} 

	Client::addMenuItem(%clientId, %curItem++ @ "Voting...", "votemenu"); 
	if(%clientId.isAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Features...", "adminmenu"); 

	Client::addMenuItem(%clientId, %curItem++ @ "Weapons Setup", "weaponsetup");
	Client::addMenuItem(%clientId, %curItem++ @ "Pack Setup", "packsetup");

	if(!$DuelStart && %clientId.isAdmin && $matchStarted)
		Client::addMenuItem(%clientId, %curItem++ @ "Force Tourney Start", "forcedt");

	if(%clientId.isAdmin && !%clientId.isSuperAdmin) {
		if($HaVoC::PASpecial[%clientId.adminNum]) {
			if($Special::PAServerOptions[%clientId.adminNum])
				Client::addMenuItem(%clientId, %curItem++ @ "HaVoC Server Options...", "HaVoC"); 
		} else if($HaVoC::PAServerOptions) 
			Client::addMenuItem(%clientId, %curItem++ @ "HaVoC Server Options...", "HaVoC"); 
	} else if(%clientId.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @ "HaVoC Server Options...", "HaVoC"); 		

	%IXKiller = HaVoC_getKiller(%clientId); 
	if(%IXKiller && %IXKiller != %clientId && %IXKiller.tkKills >= $HaVoC::tkLimit) { 
		if($HaVoC::tkClientLvl == 1) 
			Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 		
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick " @ Client::getName(HaVoC_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%IXKiller))); 
	} 
} 

function DuelCheckStart(%force) {
	if ($DuelStart) return;

	%notReadyCount = 0;
	%playerCount = 0;
   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
        if(%cl.notready) {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
		} else
        	%playerCount++;
   	}
   
   	if(%notReadyCount) {
         if ( %notReadyCount < (getNumClients() / 2) ) {
      		messageall(0, "Atleast half the players are ready!");
      		messageall(0, "Tournament begins in 15 seconds.");
      		$DuelStart = true;
      		InitPartners();
      		centerprintall("", 0);
      		$DuelCountDown = true;
      		schedule("$DuelCountDown = false;", 17);
      		schedule("messageall(0, \"Lets get it on!\");", 15);
      		schedule("DuelCheck();", 16);
         } else {
         	if(%notReadyCount == 1)
            	MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
   	   	else if(%notReadyCount < 4) {
              	for(%i = 0; %i < (%notReadyCount - 2); %i++)
               	%str = Client::getName(%notReady[%i]) @ ", " @ %str;
   		   	%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
            	MessageAll(0, %str);
      		}
         }
       	return;
   	}

   	if(%playerCount != 0) {
      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
         	%cl.notready = "";
         	%cl.notreadyCount = "";
         	bottomprint(%cl, "", 0);
      	}
		if(InitPartners()) {
			$DuelStart = true;
			messageall(0, "Tournament begins in 10 seconds.");
			centerprintall("", 0);
			$DuelCountDown = true;
			schedule("$DuelCountDown = false;", 12);
			schedule("messageall(0, \"Lets get it on!\");", 10);
			schedule("DuelCheck();", 11);
		} 
   	}
}

function Observer::triggerUp(%client) {
	if(!$DuelStart && $matchStarted) {
      	if(%client.notready) {
         	%client.notready = "";
         	MessageAll(0, Client::getName(%client) @ " is READY.");
		 	bottomprint(%client, "<f1><jc>Waiting for the tournament to start.", 0);
			DuelCheckStart();
      	}
		return;
	}
   if(%client.observerMode == "dead") {
      if(%client.dieTime + $Server::respawnTime < getSimTime()) {
         if(Game::playerSpawn(%client, true)) {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      }
   } else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly") {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   } else if(%client.observerMode == "justJoined") {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   } else if(%client.booyah && %client.safeout == "") {
      Client::setControlObject(%client, Client::getOwnedObject(%client));
	  doneposs(%client);
	  return;
   }
}

function processMenuchooseweapon(%cl, %opt) {
	%weap = getword(%opt, 0);
	%num = getword(%opt, 1);
	if(%weap == "more") {
		%i = getword(%opt, 2);
		WeaponSetup(%cl, %num, %i);
		return;
	}
	$DuelWeaponSetup[%cl, %num] = %weap;
	%num++;
	if(%num == 3) {
		if ($DuelPackSetup[%cl] == "") $DuelPackSetup[%cl] = 1;
		bottomprint(%cl, "<jc><f1>Your weapon setup is <f2>" @ 
		$DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, and <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>.\nYour pack setup is a <f2>" @ 
		$DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
		schedule("CPmsg(" @ %cl @ ");", 10);
		return;
	}
	WeaponSetup(%cl, %num, 0);
}

function CPmsg(%cl) {
	if(!$DuelStart) {
		if(%cl.notready)
			centerprint(%cl, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f1>Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0);
		else
			bottomprint(%cl, "<f1><jc>Waiting for the tournament to start.", 0);
	}
}

function WeaponSetup(%clientId, %num, %i) {
	%w1 = $DuelWeaponSetup[%clientId, 0];
	%w2 = $DuelWeaponSetup[%clientId, 1];
	Client::buildMenu(%clientId, "Select your weapons (" @ (3 - %num) @ " left):", "chooseweapon", true);
	while(true) {
		%i++;
		if(%i != %w1 && %i != %w2) {
			%t++;
			Client::addMenuItem(%clientId, %t @ $DuelWeapon[%i], %i @ " " @ %num);
		}
		if(%t == 7 || %i == $DuelWeaponMax) break;
	}
	if(%i < $DuelWeaponMax)
		Client::addMenuItem(%clientId, "8More...", "more " @ %num @ " " @ %i);
}
                                    
function PackSetup(%clientId) {
	Client::buildMenu(%clientId, "Select your pack:", "choosepack", true);
	for (%i = 1;%i <= $DuelPackMax;%i++)
		Client::addMenuItem(%clientId, %i @ $DuelPack[%i], %i);
}

function getEfficiencyRatio(%clientId) {
	%ratio = floor((%clientId.score/(%clientId.score + %clientId.scoreDeaths))*100);
	if (%ratio > 0)
		return %ratio;
	else 
		return "0";
}

function processMenuchoosepack(%cl, %option) {
	$DuelPackSetup[%cl] = %option;

    if (!$DuelWeaponSetup[%clientId, 0])
		$DuelWeaponSetup[%clientId, 0] = 3;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 4;

	bottomprint(%cl,"<jc><f1>Your weapon setup is <f2>" @ 
	$DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, and <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>.\nYour pack setup is a <f2>" @
	$DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
	schedule("CPmsg(" @ %cl @ ");", 10);
	return;
}

function processMenuOptions(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!HaVoCPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
	if(%opt == "forcedt") {
      if ( badMan( %clientId, 79 ) ) return;
		if ( $DuelStart ) return;
      messageall(0, Client::getName(%clientId) @ " has forced the tournament to start!");
		messageall(0, "Tournament begins in 15 seconds.");
		$DuelStart = true;
		InitPartners();
		centerprintall("", 0);
		$DuelCountDown = true;
		schedule("$DuelCountDown = false;", 17);
		schedule("messageall(0, \"Lets get it on!\");", 15);
		schedule("DuelCheck();", 16);
		return;
	}
	if(%opt == "observe") {               
		%clientId.observerMode = "observerOrbit";
		Observer::setTargetClient(%clientId, %cl);
  		return;
	}
	if (%opt == "weaponsetup") {
		$DuelWeaponSetup[%clientId, 0] = 0;
		$DuelWeaponSetup[%clientId, 1] = 0;
		$DuelWeaponSetup[%clientId, 2] = 0;
		WeaponSetup(%clientId, 0, 0);
        return;
	}
    if (%opt == "packsetup") {
		PackSetup(%clientId);
        return;
	}
	if(%opt == "votemenu") {
		votemenu(%clientId);
		return;
	}
	if(%opt == "adminmenu") {
      if ( badMan( %clientId, 80 ) ) return;
		adminmenu(%clientId);
		return;
	}
	if(%opt == "nospeak") {
		%clientId.speakto = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "speak") {
		if(%clientId.speakto)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
		%clientId.speakto = %cl;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "manip") { 
      if ( badMan( %clientId, 81 ) ) return;
		Client::buildMenu(%clientId, "Torture: "@Client::getName(%cl), "Options", true); 		
		if(%clientId.wat)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Watching " @ Client::getname(%clientId.wat), "unwat " @ %clientId.wat); 
		else if(%clientId != %cl) {
			if(Observer::isObserver(%clientId) && !Observer::isObserver(%cl))
				Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Watch", "wat " @ %cl); 
		} 
		if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Kill...", "execute " @ %cl);
		if((%cl).permap)
			Client::addMenuItem(%clientId, %curItem++ @ "Un-Cripple", "poison " @ %cl);
		else
			if(!%cl.isSuperAdmin)
				Client::addMenuItem(%clientId, %curItem++ @ "Cripple...", "poison " @ %cl); 
		if(%cl.gag) 
			Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag", "ungag " @ %cl); 
		else if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Gag", "gag " @ %cl); 
		if(%cl.dan) 
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Dancing", "undan " @ %cl); 
		else if(!%cl.isSuperAdmin) 
			Client::addMenuItem(%clientId, %curItem++ @ "Dance", "dan " @ %cl); 
		if(!%cl.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Strip", "strip " @ %cl); 
		if(%clientId.poss == %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Possession", "unposs " @ %cl); 
		else if(!%cl.possessed && !%cl.isSuperAdmin && %clientId != %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Possess", "poss " @ %cl); 
		if(%cl.just)
			Client::addMenuItem(%clientId, %curItem++ @ "Remove Eye for an Eye", "unjus " @ %cl); 
		else if(!%cl.just && !%cl.isSuperAdmin && %clientId != %cl)
			Client::addMenuItem(%clientId, %curItem++ @ "Force Eye for an Eye", "jus " @ %cl); 
		return;
	} else if(%opt == "fteamchange") { 
      if ( badMan( %clientId, 82 ) ) return;
		%clientId.ptc = %cl; 
		Client::buildMenu(%clientId, "Select A Team:", "FPickTeam", true); 
		Client::addMenuItem(%clientId, "0Observer", -2); 
		return; 
	} else if(%opt == "misc") {
		%i = 0;
		Client::buildMenu(%clientId, "Miscellany:", "mmisc", true); 
		if ($HaVoC::PersonalSkin) { 
			if(%clientId.custom == False) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Personal Skin", "pSkin"); 
			} else if(%clientId.custom == True) { 
				Client::addMenuItem(%clientId, %i++ @ "Use Team Skin", "pSkin"); 
			} 
		} 
		Client::addMenuItem(%clientId, %i++ @ "View Server Settings", "view"); 
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode...", "obsm"); 
		if ($DuelTModeOff[%clientId])
			Client::addMenuItem(%clientId, %i++ @ "Enable Duel Mode", "toggledt");
		else
			Client::addMenuItem(%clientId, %i++ @ "Disable Duel Mode", "toggledt");			
		return;
	} 
	if(%opt == "changeteams") { 
		if(!$matchStarted || !$Server::TourneyMode) { 
			Client::buildMenu(%clientId, "Select A Team:", "PickTeam", true); 
			Client::addMenuItem(%clientId, "0Observer", -2); 
			return; 
		} 
	} else if(%opt == "mute") {
		%clientId.muted[%cl] = true; 
	} else if(%opt == "unmute") {
		%clientId.muted[%cl] = ""; 
   	} else if(%opt == "selectskin") {
		if(%clientId.vskin == "") %clientId.vskin = 0;
      	Client::buildMenu(%clientId, "Current Skin: " @ $SkinNames[%clientId.vskin], "pickSkin", true);
	  	for(%i = 0 ; %i < 8 ; %i++)
	      	Client::addMenuItem(%clientId, %i + 1 @ $SkinNames[%i], %i);
      	return;
	} else if(%opt == "gag") {
      if ( badMan( %clientId, 83 ) ) return;
		%cl.gag = true; 
		echo(Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId));
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
		Client::sendMessage(%cl, 1,"You've been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
	} else if(%opt == "ungag") {
      if ( badMan( %clientId, 84 ) ) return;
		%cl.gag = false; 
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ "'s gag has been removed by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"Your gag has been removed by " @ Client::getName(%clientId)@"."); 	
	} else if(%opt == "strip") {
      if ( badMan( %clientId, 85 ) ) return;
		Player::dropItem(%cl,Flag);
		if(%cl.observerMode == "" || %cl.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%cl,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%cl,%item); 
				if(%count) {
					Player::setItemCount(%cl,%item,0); 
				}
			}
		}
		Player::setDamageFlash(%cl,1); 
		echo(Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"You've been stripped by " @ Client::getName(%clientId)@"!"); 	
	} else if(%opt == "lis") {
      if ( badMan( %clientId, 86 ) ) return;
		$listen[%cl] = %clientId;
		Client::sendMessage(%clientId, 0,"You are now listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "unlis") {
      if ( badMan( %clientId, 87 ) ) return;
		$listen[%cl] = "";
		Client::sendMessage(%clientId, 0,"You are no longer listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "jus") {
      if ( badMan( %clientId, 88 ) ) return;
		%cl.just = true;
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has forced Eye for an Eye on " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has forced Eye for an Eye on you."); 	
	} else if(%opt == "unjus") {
      if ( badMan( %clientId, 89 ) ) return;
		%cl.just = "";
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has removed Eye for an Eye from " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has removed Eye for an Eye from you."); 	

	} else if(%opt == "poss") {
      if ( badMan( %clientId, 90 ) ) return;
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to possess - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to possess - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
		Client::setControlObject(%clientId, %cl);
		%cl.possessed = true;
		%cl.possby = %clientId;
		%clientId.poss = %cl;
		%clientId.possessing = true;
		echo(Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You've been possessed by " @ Client::getName(%clientId)@"!~wteleport2.wav"); 	
	} else if(%opt == "unposs") {
      if ( badMan( %clientId, 91 ) ) return;
		Client::setControlObject(%clientId, %clientId);
        Client::setControlObject(%cl, %cl);
		%cl.possessed = false;
		%cl.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You have been freed by " @ Client::getName(%clientId)@".~wteleport2.wav"); 	
	} else if(%opt == "wat") {
		if( Client::getTeam(%cl) != Client::getTeam(%clientId) && !%clientId.isAdmin)
			return;
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl) || e(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to watch - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to watch - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
		doneposs(%clientId);
        Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		setObsOrbit(%clientId, Client::getControlObject(%cl), 5, 5, 5);
		%name = Client::getName(%cl);
		bottomprint(%clientId, "<jc><f2>Observing " @ %name @ ".", 0);
		Client::sendMessage(%clientId, 0,"You are watching " @ %name @ "."); 
		if(!%clientId.isAdmin || %cl.isSuperAdmin)
			Client::sendMessage(%cl, 0,"You are being watched by " @ Client::getName(%clientId) @ "."); 
		%clientId.booyah = true;
		%clientId.wat = %cl;
		%cl.wated = %clientId;
	} 
	if(%opt == "unwat") {
		doneposs(%clientId);
	} else if(%opt == "dan") {
      if ( badMan( %clientId, 92 ) ) return;
		%cl.dan = true; 
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav"); 
		} else { 
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav"); 
			Client::sendMessage(%cl, 1,"You've been forced to dance by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav"); 
		}
		echo(Client::getName(%cl) @ " has been forced to dance by " @ Client::getName(%clientId));
		doneposs(%cl);
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
   		dodance(%cl);
		%cl.safet = true;
	} else if(%opt == "undan") {
      if ( badMan( %clientId, 93 ) ) return;
		%cl.dan = false; 
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to stop dancing."); 
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to stop dancing."); 	
		doneposs(%cl);
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		%cl.safet = false;
	} else if(%opt == "vkick") { 
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl); 
	} else if(%opt == "vadmin") { 
		%cl.voteTarget = true; 
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl); 
	} else if(%opt == "vsmatch") 
		Admin::startVote(%clientId, "start the match", "smatch", 0); 
	else if(%opt == "vetd") 
		Admin::startVote(%clientId, "enable Team Damage", "etd", 0); 
	else if(%opt == "vdtd") 
		Admin::startVote(%clientId, "disable Team Damage", "dtd", 0); 
	else if(%opt == "veft") 
		Admin::startVote(%clientId, "enable Fair Teams", "eft", 0); 
	else if(%opt == "vdft") 
		Admin::startVote(%clientId, "disable Fair Teams", "dft", 0); 
	else if(%opt == "etd") {
      if ( badMan( %clientId, 94 ) ) return;
		Admin::setTeamDamageEnable(%clientId, true); 
	} else if(%opt == "dtd") {
      if ( badMan( %clientId, 95 ) ) return;
		Admin::setTeamDamageEnable(%clientId, false); 
	} else if(%opt == "eft")  {
      if ( badMan( %clientId, 96 ) ) return;
		Admin::setFairTeams(%clientId, true); 
	} else if(%opt == "dft") {
      if ( badMan( %clientId, 97 ) ) return;
		Admin::setFairTeams(%clientId, false); 
      }
      
   if(%opt == "balan")
      Admin::startVote(%clientId, "balance the teams on the next mission change", "balan", 0);
	else if(%opt == "forbalan") {
      if ( badMan( %clientId, 98 ) ) return;
		messageall(0, Client::getName(%clientId) @ " has forced the teams to be balanced on the next mission change.");
		$HaVoC::BalanceTeams = true;
	} else if(%opt == "canbalan") {
      if ( badMan( %clientId, 99 ) ) return;
		messageall(0, Client::getName(%clientId) @  " has cancelled balancing the teams on the next mission change.");
		$HaVoC::BalanceTeams = false;
   } else if(%opt == "vegm")
      Admin::startVote(%clientId, "enable GREED mode", "egm", 0);
   else if(%opt == "vdgm")
      Admin::startVote(%clientId, "disable GREED mode", "dgm", 0);
   else if(%opt == "egm") {
      if ( badMan( %clientId, 100 ) ) return;
      Admin::setGreedMode(%clientId, true);
     }    else if(%opt == "dgm")
      Admin::setGreedMode(%clientId, false);
   else if(%opt == "vehm")
      Admin::startVote(%clientId, "enable HOARD mode", "ehm", 0);
   else if(%opt == "vdhm")
      Admin::startVote(%clientId, "disable HOARD mode", "dhm", 0);
   else if(%opt == "ehm")
      Admin::setHoardMode(%clientId, true);
   else if(%opt == "dhm")
      Admin::setHoardMode(%clientId, false);

	else if(%opt == "vcffa") 
		Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0); 
	else if(%opt == "vctourney") 
		Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0); 
	else if(%opt == "vtimelimit") {
		%numTeams = getNumTeams(); 
		if(%numTeams == 2) {
			%numPlayers = getNumClients(); 
			for(%i = 0; %i < %numTeams; %i++) 
				%numTeamPlayers[%i] = 0; 
			for(%i = 0; %i < %numPlayers; %i++) { 
				%pl = getClientByIndex(%i); 
				%team = Client::getTeam(%pl); 
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1; 
			} 
			%diff = %numTeamPlayers[0] - %numTeamPlayers[1];
			if(%diff < 0) %diff = -%diff;
			if(%numTeamPlayers[0] > %numTeamPlayers[1])
				%big = 0;
			else
				%big = 1;
			if(%diff >= 3 && Client::getTeam(%clientId) == %big) {
				Client::sendMessage(%clientId, 1, "Teams unfair - Cannot vote to increase time");
			} else
				Admin::startVote(%clientId, "increase the time limit by "@$HaVoC::PVTime@" minutes", "timel", 0); 
		} else
			Admin::startVote(%clientId, "increase the time limit by "@$HaVoC::PVTime@" minutes", "timel", 0); 
	} else if(%opt == "cffa")  {
      if ( badMan( %clientId, 101 ) ) return;
		Admin::setModeFFA(%clientId); 
   }
	else if(%opt == "ctourney") {
		if ( badMan( %clientId, 102 ) ) return;
      Admin::setModeTourney(%clientId); 
   }
		
		
	if(%opt == "makeitso" && %cl == $curVoteCount) { 
      if ( badMan( %clientId, 103 ) ) return;
		echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to PASS!");
		hvcAdminMsg(Client::getName(%clientId) @ " has forced the current vote to PASS!");
		$curVoteCheat = "YES";
		%clientId.hv = 0;
	} else if(%opt == "makeitno" && %cl == $curVoteCount) { 
      if ( badMan( %clientId, 104 ) ) return;
		echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to FAIL!");
		hvcAdminMsg(Client::getName(%clientId) @ " has forced the current vote to FAIL!");
		$curVoteCheat = "NO";
		%clientId.hv = 0;
	} else if(%opt == "voteYes" && %cl == $curVoteCount) { 
		%clientId.vote = "yes"; centerprint(%clientId, "", 0); 
		%clientId.hv = 0;
	} else if(%opt == "voteNo" && %cl == $curVoteCount) { 
		%clientId.vote = "no"; centerprint(%clientId, "", 0); 
		%clientId.hv = 0;
	} else if(%opt == "kick") { 
      if ( badMan( %clientId, 105 ) ) return;
		Client::buildMenu(%clientId, "Confirm Kick:", "kaffirm", true); 
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kick " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "execute") { 
      if ( badMan( %clientId, 106 ) ) return;
		Client::buildMenu(%clientId, "Confirm Execution:", "maffirm", true); 
		Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kill 'em ", "no " @ %cl); 
		return; 
	} else if(%opt == "poison") { 
      if ( badMan( %clientId, 107 ) ) return;
		if(%cl.permap != true) {
			Client::buildMenu(%clientId, "Confirm Crippling:", "paffirm", true); 
			Client::addMenuItem(%clientId, "1Cripple " @ Client::getName(%cl), "yes " @ %cl);
			Client::addMenuItem(%clientId, "2Don't Cripple 'em ", "no " @ %cl); 
			return; 
		} else {
			%cl.permap = false;
			MessageAllExcept(%cl , 1, Client::getName(%cl) @ "'s curse has been lifted by " @ Client::getName(%clientId) @ "."); Client::sendMessage(%cl ,1,"Your curse has been lifted by " @ Client::getName(%clientId) @ ".~waccess_denied.wav");
			playNextAnim(%cl); 
			Player::kill(%cl); 
			Client::onKilled(%cl, %cl);
		}
	} else if(%opt == "removeadmin") { 
      if ( badMan( %clientId, 108 ) ) return;
		if(%cl.isnotaTker) %cl = %clientId;
		%cl.isAdmin = "";
		%cl.isSuperAdmin = "";
		if(%cl == %clientId)
			Client::sendMessage(%cl,1,"You have revoked your Admin Status."); 
		else {
			Client::sendMessage(%cl,1,"Your Admin Status has been revoked."); 
			hvcAdminMsg("Admin Status stripped from: " @ Client::getName(%cl) @ ".");
		}
	} else if(%opt == "admin") { 
      if ( badMan( %clientId, 109 ) ) return;
		Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true); 
		Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
		return; 
	} else if(%opt == "ban") { 
      if ( badMan( %clientId, 110 ) ) return;
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true); 
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Ban " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "smatch") {
      if ( badMan( %clientId, 111 ) ) return;
		Admin::startMatch(%clientId); 
	} else if(%opt == "vcmission" || %opt == "cmission") { 
      if ( %opt == "cmission" && badMan( %clientId ) ) return;
		Admin::changeMissionMenu(%clientId, %opt); 
		return; 
	} 
	if(%opt == "cctimelimit") { 
      if ( badMan( %clientId, 112 ) ) return;
		$Server::timeLimit += $HaVoC::PVTime;
		messageAll(0, Client::getName(%clientId) @ " has increased the time limit by " @ $HaVoC::PVTime @ " minutes."); 
		return;
	} else if(%opt == "ctimelimit") { 
      if ( badMan( %clientId, 113 ) ) return;
		Client::buildMenu(%clientId, "Current Time Limit: "@$Server::timeLimit, "ctlimit", true); 
		Client::addMenuItem(%clientId, "1No Time Limit", 0); 
		Client::addMenuItem(%clientId, "210 Minutes", 10); 
		Client::addMenuItem(%clientId, "315 Minutes", 15);
		Client::addMenuItem(%clientId, "420 Minutes", 20);
		Client::addMenuItem(%clientId, "525 Minutes", 25);
		Client::addMenuItem(%clientId, "630 Minutes", 30);
		Client::addMenuItem(%clientId, "745 Minutes", 45); 
		Client::addMenuItem(%clientId, "860 Minutes", 60); 
		return; 
	} else if(%opt == "HaVoC") { 
      if ( badMan( %clientId, 114 ) ) return;
		Client::buildMenu(%clientId, "HaVoC Server Options:", "ixsettings", true); 
		Client::addMenuItem(%clientId, "1Server Anti-TK Level", "tkserv " @ $HaVoC::tkServerLvl);
		Client::addMenuItem(%clientId, "2Client Anti-TK Level", "tkclient " @ $HaVoC::tkClientLvl);
		if(%clientId.isSuperAdmin) {
			Client::addMenuItem(%clientId, "3Public Voting Lockouts", "pvlockout");
			Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout"); 
			Client::addMenuItem(%clientId, "5Purge Public Admins", "purge " @ %clientId); 
			Client::addMenuItem(%clientId, "6Kick Ban Time", "kicktime");
			Client::addMenuItem(%clientId, "7Station Boot Time", "action");			
			Client::addMenuItem(%clientId, "8Additional Options...", "moreop");
		}
		return; 
	} else if(%opt == "tkopt") { 
		if($HaVoC::tkClientLvl == 1) 
			Admin::Kick(-3, HaVoC_getKiller(%clientId)); 
		else { 
			%cl.voteTarget = true; 
			%clientId.selClient = HaVoC_getKiller(%clientId); 
			Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl); 
		} 
	} 
	Game::menuRequest(%clientId); 
} 

function ObjectiveMission::setObjectiveHeading() {
}

function DuelMOD::missionObjectives() {              
   	%numClients = getNumClients();
   	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
   	%doIt = 1;
   	while(%doIt == 1) {
      	%doIt = 0;
      	for(%i = 0; %i < %numClients; %i++) {
         	if((%clientList[%i]).score < (%clientList[%i+1]).score) {
            	%hold = %clientList[%i];
            	%clientList[%i] = %clientList[%i + 1];
            	%clientList[%i + 1] = %hold;
           	 	%doIt = 1;
         	}
      	}
   	}      
	if($timeReached) {
	 	for (%x = -1; %x <= 1; %x++) {
	 	   	%lineNum = 0;
	 		Team::setObjective(%x, %lineNum++, "<f8>Duel Tournament Results");
			Team::setObjective(%x, %lineNum++, "<f1>Mission Name: <f1>" @ $missionName); 
	  	  	Team::setObjective(%x, %lineNum++, " ");
		 	if($DuelLevel <= 1) {
				Team::setObjective(%x, %lineNum++, "<jc><f9>It is a tie!");	 	 
			} else {
				for(%i = $DuelLevel; %i > 1; %i--) {
					if(%i == $DuelLevel && $DuelLastWinner.score > 0)
			 	 		Team::setObjective(%x, %lineNum++, "<jc><f9>" @ $DuelDisplay[%i]);	 	 
					else
						Team::setObjective(%x, %lineNum++, "<jc><f2>" @ $DuelDisplay[%i]);	 	 
				}
			}
		   	for(%s = %lineNum + 1; %s < 30 ; %s++)
	 	 		Team::setObjective(%x, %s, " ");
	 	}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%cl.guiLock = true;
	      	Client::setGuiMode(%cl, $GuiModeVictory);
			$DuelStreak[%cl] = 0;
		}
	} else {
		for (%x = -1; %x <= 1; %x++) {
		   	%lineNum = 0;
			Team::setObjective(%x, %lineNum++, "<f8>Duel Tournament");
			Team::setObjective(%x, %lineNum++, "<f1>Mission Name: <f1>" @ $missionName); 
	 	  	Team::setObjective(%x, %lineNum++, "<f1>Mission Objectives:");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   - You cannot damage your opponent for the first second of the battle. No cheap shots!");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   - >Stay in the mission area or die. Don't be a coward!");
			Team::setObjective(%x, %lineNum++, "<f1>Use the TAB menu to select your weapons and pack loadout, then press fire to READY yourself. Wait for your turn to duel, then fight to the death. The loser is out of the tournament and the winner moves on. The last man standing wins!");
	 	  	Team::setObjective(%x, %lineNum++, " ");
			if($DuelStart && !$DuelCountDown && $DuelLevel > 1) {
		 	  	Team::setObjective(%x, %lineNum++, "<jc><f5>Current Tournament Standings:");
		  	  	Team::setObjective(%x, %lineNum++, " ");
			 	for(%i = $DuelLevel; %i > 1; %i--)
		 	 		Team::setObjective(%x, %lineNum++, "<jc><f2>" @ $DuelDisplay[%i]);	 	 
			}
		   	for(%s = %lineNum+1; %s < 30 ;%s++)
		 		Team::setObjective(%x, %s, " ");
		}
	}
}

function Game::refreshClientScore(%clientId) {
	if($Dueling[%clientId]) 
		%team = 1;
	else
		%team = 2;
   	Client::setScore(%clientId, "%n\t" @ %clientId.score  @ "\t%p\t%l", %team);
   	DuelMOD::missionObjectives();
}

function Observer::enterObserverMode(%clientId) {
   	if(Observer::isObserver(%clientId)) {
		Observer::nextObservable(%client);
		return false;
	}
   	Client::clearItemShopping(%clientId);
   	%player = Client::getOwnedObject(%clientId);
   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   	Player::kill(%clientId);
	}
   	doneposs(%clientId);
   	Client::setOwnedObject(%clientId, -1);
   	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   	GameBase::setTeam(%clientId, -1);
	%clientId.observerMode = "observerOrbit";
    %clientId.observerTarget = %clientId;
    Observer::nextObservable(%clientId);
   	remotePlayMode(%clientId);
   	return true;
}

function Game::initialMissionDrop(%clientId) {  
	%clientId.observerMode = "";
	%clientId.notready = true;
   	Client::setGuiMode(%clientId, $GuiModePlay);

	$Dueling[%clientId] = "";
   	$HighStreak[%clientId] = 0;

   	$DuelStreak[%clientId] = 0;

	Observer::enterObserverMode(%clientId);
    Game::refreshClientScore(%clientId);

	doneposs(%clientId);
	
   	%clientId.justConnected = "";

	if($DuelTModeOff[%clientId]) {
		centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f2>You currently have Duel Tournament Mode disabled.\n\nPress tab, click Miscellany... then click Enable Duel Mode.", 60); 
		$DuelAlive[%clientId] = false;
		return;
	} else {
		if($DuelStart) {
			$DuelAlive[%clientId] = false;
			centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f2>A tournament is currently in progress.\n\n<f1>Please wait for the tournament to be completed, then you will be able to join in.\n\nPress 'O' to learn how to play.", 60); 
		} else {
			$DuelAlive[%clientId] = true;
			if($matchStarted)
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
			else
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.", 0); 
		}
	}
	%clientId.guiLock = false;
}

function Player::enterMissionArea(%player) {
   	Client::sendMessage(Player::getClient(%player),0,"You have entered the mission area.");
   %player.outArea = "";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}

function Game::startMatch() {       
   	$matchStarted = true;
   	$missionStartTime = getSimTime();
   	messageAll(0, "Match started.");
   	Game::resetScores();	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
   		if($DuelTModeOff[%cl])
			%cl.notready = false;		
		else
			%cl.notready = true;
		$Dueling[%cl] = "";
		$HighStreak[%cl] = 0;
		$DuelStreak[%cl] = 0;
		%cl.score = 0;
   	  	Game::refreshClientScore(%cl);
   	}
	$DuelLevel = 1;
	$DuelStart = false;
	for(%i = 1; %i <= 7; %i++)
		$DuelDisplay[%i] = "";

	centerprintall("<jc><f0>Welcome to Duel Tournament\nby [HvC]NaTeDoGG - http://PlanetTribes.com/Havoc\n\n<f1>Choose your weapons from the TAB menu.\n\nPress 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
   	Game::checkTimeLimit();
}

function CheckPartners() {
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if($DuelAlive[%cl] && $DuelPartner[%cl]) {
			if(!$DuelAlive[$DuelPartner[%cl]] || Client::getName($DuelPartner[%cl]) == "" || $DuelTModeOff[$DuelPartner[%cl]]) {
				$DuelAlive[$DuelPartner[%cl]] = false;
				$DuelPartner[$DuelPartner[%cl]] = 0;
				$DuelPartner[%cl] = 0;
			} else if($DuelFought[%cl] || $DuelFought[$DuelPartner[%cl]]) {
				$DuelPartner[$DuelPartner[%cl]] = 0;
				$DuelPartner[%cl] = 0;
			}
		}
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if($DuelAlive[%cl] && $DuelPartner[%cl]) {
			%found = false;
			for(%cll = Client::getFirst(); %cll != -1; %cll = Client::getNext(%cll)) {
				if($DuelPartner[%cll] == %cl && $DuelPartner[%cl] != %cll || %found) {
						$DuelPartner[%cll] = 0;
				}
				if($DuelPartner[%cll] == %cl && $DuelPartner[%cl] == %cll)
					%found = true;
			}
			if(!%found) $DuelPartner[%cl] = 0;
		}	
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if($DuelAlive[%cl] && !$DuelPartner[%cl] && !$DuelFought[%cl]) AssignPartner(%cl);
	DuelMOD::missionObjectives();
}

function AssignPartner(%client) {
	%num = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if($DuelAlive[%cl] && !$DuelPartner[%cl] && %cl != %client && !$DuelFought[%cl]) {
			%goodclients[%num] = %cl;
			%num++;
		}
	}
	if(%num == 0) {
		$DuelPartner[%client] = 0;
		return false;
	}
	%foe = %goodclients[floor(getRandom() * %num)];
	$DuelPartner[%client] = %foe;
	$DuelPartner[%foe] = %client;
	return true;
}

function InitPartners() {
	%num = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		$DuelPartner[%cl] = 0;
		$DuelFought[%cl] = false;
		if($DuelAlive[%cl]) {
			%goodclients[%num] = %cl;
			%num++;
			if(%num > 1) $DuelDisplay[$DuelLevel] = $DuelDisplay[$DuelLevel] @ ", ";
			$DuelDisplay[$DuelLevel] = $DuelDisplay[$DuelLevel] @ Client::getName(%cl);
		}
	}
	if($DuelDisplay[$DuelLevel] == $DuelDisplay[$DuelLevel - 1]) {
		%repeat = true;
		$DuelLevel--;
	} else 
		%repeat = false;
	if(%num < 2) {
		if(!$DuelStart) {
			messageall(0, "Not enough players! Waiting for more to join...");
			return false;
		} else {
			$DuelLastWinner = $DuelTempWinner;
			$timeReached = true;
			DuelMOD::missionObjectives();
			schedule("Server::nextMission();", 5);
			return false;
		}
	}
	for(%i = 0; %i < %num; %i++)
		AssignPartner(%goodclients[%i]);
	if(%repeat) {
		DuelCheck();
		return false;
	}
	return true;
}

function DuelCheck() {
	CheckPartners();
	%client = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if($DuelAlive[%cl] && $DuelPartner[%cl] && !$DuelFought[%cl]) {
			%client = %cl;
			break;
		}
	}
	if(%client != 0) {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if($DuelAlive[%cl]) %num++;
		}
		if(%num > 2) {
			MessageAll(0, Client::GetName(%client) @ " and " @ Client::GetName($DuelPartner[%client]) @ " are about to duel!");
		} else {
			MessageAll(0, Client::GetName(%client) @ " and " @ Client::GetName($DuelPartner[%client]) @ " are about to duel for first place!");
		}
		schedule("DuelInit(" @ %client @ "," @ $DuelPartner[%client] @ ");", 5);
		return;
	}
	$DuelLevel++;
	if(!InitPartners()) return;
	messageall(1, "Round " @ ($DuelLevel - 1) @ " complete.");
	messageall(1, "Beginning round " @ $DuelLevel @ "!");
	DuelCheck();
}
                
function DuelMOD::restoreServerDefaults() {
   exec(resetduel);
   exec(admin);
   exec(player);
   exec(objectives);
   exec(observer);
   //PORT-OFF: exec(client);  the mod's 1999 client.cs is not shipped; base's 1.50 client.cs must not be re-run by a server
   exec(game);
}

function MineAmmo::onUse(%player,%item) {
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			if ($DuelMine1[%client] == "")
				$DuelMine1[%client] = %obj;
			else if ($DuelMine2[%client] == "")
				$DuelMine2[%client] = %obj;
			else if ($DuelMine3[%client] == "")
				$DuelMine3[%client] = %obj;
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

function Server::onClientConnect(%clientId) {
   %ip = Client::getTransportAddress(%clientId);
   if(!String::NCompare(%ip, "LOOPBACK", 8)) {
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
   } else
		IxAdmin_Authenticate(%clientId, ixPrepIp(%ip));

   	DuelResetClient(%clientId);

	if($hasDropped)
		%clientId.goodT = "";
	else
		%clientId.goodT = "good";
	%clientId.hasDeployed = false;
   
	%username = Client::getName(%clientId);
   	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(%username) @ "\" " @ %ip);

	%clientId.dumbass = false;
   %clientId.noghost = true;
   %clientId.messageFilter = -1; 
	//PORT-OFF: $modList = "HaVoC v" @ $HV;  $modList is the search path input on 1.50 (guide 6.6)
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>by [HvC]NaTeDoGG aka Nathan Sweet\n<f1>HaVoC version " @ $HV @ "\n<f2>T H E  O N L Y  T R I B E S  M O D I F I C A T I O N\n<f1>http://PlanetTribes.com/Havoc");
   remoteEval(%clientId, FileURL, $Server::FileURL);

   for(%i = 0; %i < 10; %i++) {
      $Client::info[%clientId, %i] = "";
   }
	%clientId.observerMode = "";
	%clientId.permap = false; 
	%clientId.dan = false; 
   $warning[%clientId] = 0;
   %clientId.poisonTime = 0;
   %clientId.basekills = 0;
   %clientId.custom = False;
   initLoadouts(%clientId);
   Game::onPlayerConnected(%clientId);
}
                                
function Server::onClientDisconnect(%clientId) {
   	%player = Client::getOwnedObject(%clientId);
   	if (%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   	Player::kill(%player);
	}

	%foe = $Dueling[%clientId];

	DuelResetClient(%clientId); 
	CheckPartners();

	if (%foe) {
   		messageall(1, Client::GetName(%clientId) @ " has left the game. Aborting Duel.~werror_message.wav");
   		FinalizeDuel(%clientId, %foe);
   	} else if($DuelAlive[%clientId]) {
		messageall(1, Client::GetName(%clientId) @ " has left the game. Updating tourney information.");
	}

	doneposs(%clientId);
	if(%clientId.hasDeployed) $hasDropped = true;
	%clientId.adminNum = "";
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	DuelCheckStart();
}

function remoteMissionChangeNotify(%serverManagerId, %nextMission) {
   if(%serverManagerId == 2048) {
      //cls();
      echo("Server mission complete - changing to mission: ", %nextMission);
      //echo("Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
}

function Server::loadMission(%missionName, %immed) {

	if($HaVoC::FairSpawn > 10 || $HaVoC::FairSpawn < 0) {
		$HaVoC::FairSpawn = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::FairSpawn is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::BaseKillLimit < 2 && $HaVoC::BaseKillLimit != 0) {
		$HaVoC::BaseKillLimit = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::BaseKillLimit is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::tkLimit <= 0) {
		$HaVoC::tkLimit = 5;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::tkLimit is invalid, option has been set to 5");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningFrequency != 0 && $HaVoC::LightningFrequency < 90) {
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength != "normal" && $HaVoC::LightningStrength != "random" && $HaVoC::LightningStrength != "weak" && $HaVoC::LightningStrength != "zero") {
		$HaVoC::LightningStrength = "normal";
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningStrength is invalid, option has been set to normal");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	if($HaVoC::LightningStrength == "normal" && $HaVoC::LightningFrequency < 200) {
		$HaVoC::LightningStrength = "weak";
		$HaVoC::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  Lightning Strength cannot be set to normal if Lightning Frequency is less than 200.");
		echo("$HaVoC::LightningStrength is invalid, option has been set to weak");
		echo("$HaVoC::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");

	}

	if($HaVoC::AutoAssignLength == 0) {
		$HaVoC::AutoAssignLength = 4;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::AutoAssignLength is invalid, option has been set to 4");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}
	
	if($HaVoC::LightningHandicap < 3 && $HaVoC::LightningHandicap != 0) {
		$HaVoC::LightningHandicap = 0;
		echo("**************");
		echo("YOU MESSED UP!  $HaVoC::LightningHandicap is invalid, option has been disabled");
		echo("Please verify HaVoC.cs is using the correct settings.");
		echo("**************");
	}

	DuelMOD::restoreServerDefaults();

   	if($loadingMission)
		return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "") {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "") {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		$warning[%cl] = 0;
      	%cl.guiLock = true;
		Client::setGuiMode(%cl, $GuiModeVictory);
      	%cl.nospawn = true;
      	remoteEval(%cl, missionChangeNotify, %missionName);
	  	%cl.empTime = 0;
	  	%cl.poisonTime = 0;
	  	%cl.blindTime = 0;
	  	%cl.basekills = 0;
		remoteEval(%cl, SetControls);
	}

	if($HaVoC::startTime)
		$Server::timeLimit = $HaVoC::startTime;
	else
		$HaVoC::startTime = $Server::timeLimit;

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); 

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();      
}

function Game::checkTimeLimit() {
   	$timeLimitReached = false;
	DuelMOD::missionObjectives();
    schedule("Game::checkTimeLimit();", 60);
	return;
}

function Mission::init() {                     
	$DuelStart = false;
	$DuelCountDown = false;
	$DuelLevel = 1;
	for(%i = 1; %i <= 7; %i++)
		$DuelDisplay[%i] = "";
	
   	setClientScoreHeading("Player Name\t\xA6Kills\t\xCFPing\t\xEFPL");
   	setTeamScoreHeading("");

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	  	%cl.scoreDeaths = 0;
      	%cl.score = 0;
		Observer::enterObserverMode(%cl);
	    Observer::jump(%cl);
		Game::refreshClientScore(%cl);
   	}
	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
   	AI::setupAI();
	$timeReached = false;
   	DuelMOD::missionObjectives();
	$SensorNetworkEnabled = true;
}

function Game::playerSpawn(%clientId, %respawn) {
}
          
function Client::onKilled(%playerId, %killerId, %damageType) {

   	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
   	%playerId.guiLock = true;
   	Client::setGuiMode(%playerId, $GuiModePlay);
	remoteEval(%playerId, SetControls);
   	if(!%killerId)
   		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
   	Game::clientKilled(%playerId, %killerId);
	if(%damageType == $LandingDamageType)
		%damageType = 0;
  	if($DuelCanHurt[%playerId]) EndDuel(%playerId, %damageType);
}

function remoteKill(%client) { }

function Player::onKilled(%this) {
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
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	  %cl.safet = false;
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);                
	  schedule("deleteObject(" @ %this @ ");", 0.2, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object) { 
	%damagedClient = Player::getClient(%this); 
	%damName = Client::getName(%damagedClient);

	if($Hologram[%damName] != "") {
		%t = isTurret(%type) || (%type == 6 && !%shooterClient);
		if(%t) %value *= 3;
		%dlevel = GameBase::getDamageLevel(%this) + %value;
		if(%dlevel >= Player::getArmor(%this).maxDamage) playNextAnim(%this); 
		GameBase::setDamageLevel(%this,%dlevel);
		return;
	}

	if(%damagedClient.dumbass) %value *= 2;

	if (getObjectType(%this) == "Player") {                          
		%clientId = Player::getClient(%this);
		if (!$Dueling[%clientId] || !$Dueling[%object]) return;                               
		if (!$DuelCanHurt[%clientId]) return;
		if ($Dueling[%object] != %clientId && %clientId != %object) {
			Bottomprint(%foeId, "<jc><f2>Wrong Target!");
			return;                                         
		}
		%damagedClient = Player::getClient(%this);
    	%shooterClient = %object;
      if(%type != $ElectricityDamageType || (%type == $ElectricityDamageType && !%shooterClient.ELFhit)) {
      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
   	 		if (%cl.observerTarget == %shooterClient && %damagedClient != %shooterClient) {
   	 			Client::SendMessage(%cl,0, Client::GetName(%shooterClient) @ " just harmed " @ Client::GetName(%damagedClient));
   			}
   		}       
      }
      if(%type == $ElectricityDamageType) {
		   if(!%shooterClient.ELFhit) {
				%shooterClient.ELFhit = true;
				schedule(%shooterClient @ ".ELFhit = false;",0.5);
         }
      }
	}   

	if (!Player::isExposed(%this)) return; 

	%damagedTeam = Client::getTeam(%damagedClient);
	%shooterClient = %object; 
	%shooterTeam = Client::getTeam(%shooterClient);
	%shootName = Client::getName(%shooterClient);

	if (%damagedTeam == %shooterTeam && %type == $TracDamageType)
		%mom = "0 0 0";

	if (%damagedClient == %shooterClient) {
		if (Player::getMountedItem(%shooterClient,$WeaponSlot) == WaveGun) {
			%x = getword(%mom, 0) * 0.3;
			%y = getword(%mom, 1) * 0.3;
			%z = getword(%mom, 2) * 0.3;
			%mom = %x @ " " @ %y @ " " @ %z;
		} else if (%type == $ExplosionDamageType) {
			%x = getword(%mom, 0) * 0.45;
			%y = getword(%mom, 1) * 0.45;
			%z = getword(%mom, 2) * 0.45;
			%mom = %x @ " " @ %y @ " " @ %z;
		}
	} else if (%type == $TracDamageType) {
		%x = getword(%mom, 0) * 0.6;
		%y = getword(%mom, 1) * 0.6;
		%z = getword(%mom, 2) * 0.6;
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

	%t = isTurret(%type) || (%type == 6 && !%shooterClient);

	Player::applyImpulse(%this,%mom); 
	%friendFire = 1.0;	

	if (Player::isDead(%this)) return;

	%armor = Player::getArmor(%this);

	if (%type != -1 && %this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		if (%type == $RailDamageType) {
			%energy = 0;
			GameBase::getEnergy(%this, 0);
			%value *= 2.2;
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
		Player::applyImpulse(%this,ixDotProd(%vec,0.075)); 
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
	else if (%type == $PlasmaDamageType) { 
		if(floor(getRandom() * 10) > 5) { 
			if (%armor != "barmor" && %armor != "bfemale" && %armor != "darmor" && %armor != "harmor") 
				HaVoC_startBurn(%damagedClient, %this, 6); 
		} 
	} else if (%type == $EnergyDamageType) {
		if ( !%this.shieldStrength )
			HaVoC_startBlind(%damagedClient, %this, 8);
	} else if (%type == $SuperEnergyDamageType) {
		HaVoC_startBlind(%damagedClient, %this, 8);
	} else if (%type == $SmallEnergyDamageType)
		HaVoC_startBlind(%damagedClient, %this, 8);

	if (!%value) return;

	if((%type == $LaserDamageType || %type == $SniperDamageType)) { 
		if (%vertPos == "head") { 
			if (%type != $SniperDamageType) 
				%value *= 0.9;
			else
				%value *= 1.11;
		} else {
			if (%type != $SniperDamageType) 
				%value *= 0.6; 
			else
				%value *= 0.53; 
		}
	}
	
	%weaponType = Player::getMountedItem(%this,$WeaponSlot); 
	%dis = 0;
	if (%type == $LaserDamageType)
		%dis = 18;
	else if (%type == $SniperDamageType)
		%dis = 14;
	else if (%type == $RailDamageType)
		%dis = 20;
	if(%dis > 0 && %value > 0.25) {
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
			%dlevel = GameBase::getDamageLevel(%this) + 0.065; 
		}
	}

	if(!%dlevel) {
		%value = $DamageScale[%armor, %type] * %value * %friendFire;
		%dlevel = GameBase::getDamageLevel(%this) + %value; 
	}

	%spillOver = %dlevel - %armor.maxDamage; 

	GameBase::setDamageLevel(%this,%dlevel);
	%flash = Player::getDamageFlash(%this) + %value * 2;
	if (%flash > 0.75) %flash = 0.75;
	Player::setDamageFlash(%this,%flash);

	if(!Player::isDead(%this)) { 
		if(%dlevel >= 0.57) {                                                         
			%foeId = $Dueling[%damagedClient];
			if(%foeId.lastsound < getSimTime()) {
				%foeId.lastsound = getSimTime() + 8;
				if (Client::GetGender(%damagedClient) == "Female")
					messageAllExcept(%damagedClient, 0, "~wduelfinisher.wav");
				else
					messageAllExcept(%damagedClient, 0, "~wduelfinishim.wav");
			}
		}
	} else {
		Player::trigger(%this, $WeaponSlot, false);
		%weaponType = Player::getMountedItem(%this,$WeaponSlot);
		if(%weaponType != -1)
			Player::unmountItem(%this,$WeaponSlot);
		Player::blowUp(%this);
		%max = getNumItems(); 
		for (%i = 0; %i < %max; %i = %i + 1) { 
			%item = getItemData(%i);
			%count = Player::getItemCount(%this, %item); 
			if(%count)
				Player::setItemCount(%this, %item, 0); 
		}
		playSound(debrisLargeExp1osion,GameBase::getPosition(%this));
		if((%type == $ImpactDamageType || %type == $MissileRamDamageType) && %object.clLastMount != "")  
			%shooterClient = %object.clLastMount;
		Client::onKilled(%damagedClient, %shooterClient, %type);
	}
}

function Player::onCollision(%this,%object) {
}

function Player::leaveMissionArea(%player) {
   	%cl = Player::getClient(%player);
   	if(!$DuelCanHurt[%cl]) return;
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%player.outArea = 1;
	alertPlayer(%player, 3);
}

function alertPlayer(%player, %count) {
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   	schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		else 
	   		schedule("leaveMissionAreaDamage(" @ %clientId @ ");", 1.5, %clientId);
	}
}

function leaveMissionAreaDamage(%client) { 
	%player = Client::getOwnedObject(%client); 
	if(%player.outArea == 1) {
		if(!Player::isDead(%player) && $DuelCanHurt[%client]) { 
			Player::setDamageFlash(%client,0.6); 
			if((GameBase::getDamageLevel(%player) + 0.05) >= (Player::getArmor(%player)).maxdamage) {
				Client::sendMessage(%client,1,"You have been killed for leaving the mission area.~wLeftMissionArea.wav"); MessageAllExcept(%client, 1, Client::getName(%client) @ " has been killed for leaving the mission area.");
				playNextAnim(%client); 
				Player::kill(%client); 
				Client::onKilled(%client, %client, -2);
			} else {
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05); 
				schedule("leaveMissionAreaDamage(" @ %client @ ");",1); 
			}
		} 
	} 
} 

function Server::nextMission(%replay) {
	echo("A Duel Tournament mission has been selected.");
	messageall(0, "A Duel Tournament mission is being selected...");
	%nextMission = $nextMission[$missionName];
	messageall(0, "Changing to mission " @ %nextMission @ " (" @ $HaVoC::MType[%nextMission] @ ").");
   	Server::loadMission(%nextMission);
}

function playASound(%clientId, %foeId) {
	if (Gamebase::GetDamageLevel(Client::GetOwnedObject(%foeId)) == 0) {
		%s[0, 0] = "flawless";
		if($DuelStreak[%foeId] > 1) {
			%s[0, 1] = "fatality";
			%sid = 2;
		} else 
			%sid = 1;
		if(floor(getRandom() * 10) > 5) {
			if(floor(getRandom() * 10) > 5) {
				%s[0, %sid] = "welldone";
			} else {
				%s[0, %sid] = "superb";
			}
		} else {
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, %sid] = "outstanding";
				} else {
					%s[0, %sid] = "toasty";
				}
			} else {
				%s[0, %sid] = "excellent";
			}
		}
	} else if ($DuelStreak[%foeId] > 4 || $DuelStreak[%clientId] > 8) {
		if(floor(getRandom() * $DuelStreak[%foeId]) > 2 || $DuelStreak[%clientId] > 8) { 
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, 0] = "welldone";
				} else {
					%s[0, 0] = "outstanding";
				}
			} else {
				if(floor(getRandom() * 10) > 5) { 
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "superb";
					} else {
						%s[0, 0] = "toasty";
					}
				} else {
					%s[0, 0] = "excellent";
				}
			}
			if(floor(getRandom() * 10) > 4) { 
				%s[0, 1] = "fatality";
			}
		}
	} else {
		if(floor(getRandom() * 15) == 10) { 
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, 0] = "outstanding";
				} else {
					%s[0, 0] = "superb";
				}
			} else {							
				if(floor(getRandom() * 10) > 5) { 
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "welldone";
					} else {
						%s[0, 0] = "excellent";
					}
				} else {
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "fatality";
					} else {
						%s[0, 0] = "toasty";
					}
				}
			}
		}
	}
	for(%ii = 0; %ii <= 2; %ii++)
		if(%s[0, %ii] != "")
			schedule("messageall(0,\"~wduel" @ %s[0, %ii] @ ".wav\");", ((1.4*%ii)+1));
}

function Server::finishMissionLoad() {

   exec(server);

   $loadingMission = false;
	$TestMissionType = "";
   
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   	exec($missionFile);
   	Mission::init();
	Mission::reinitdata();

	$teamplay = (getNumTeams() != 1);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		Game::assignClientTeam(%cl);
		%cl.observerMode = "";
	}
	
   if($HaVoC::EnTs) {
      $HaVoC::EnTs = false;
      $HaVoC::TurretsDisabled = false;
      normalm();
   }
   if($HaVoC::DisTs) {
      $HaVoC::DisTs = false;
      $HaVoC::TurretsDisabled = true;
      normalm();
   }
   
	if($HaVoC::AutoAssign) {
		%good = false;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%name = Client::getName(%cl);
			if(string::getsubstr(%name, 0, $HaVoC::AutoAssignLength) == $HaVoC::AutoAssignTribe) %good = true;
		}
		if(!%good) {
			messageall(0, "SERVER: Tribal team assignment is now OFF. No tribe members are on the server.");
		} else {
			messageall(0, "SERVER: Tribal team assignment: Sorting teams...");
			if(getNumTeams() != 1) 
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					Game::assignClientTeam(%cl);
		}
	}

   $ghosting = true;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(!%cl.svNoGhost)
      {
         %cl.ghostDoneFlag = true;
         startGhosting(%cl);
      }
   }

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.dan) dodance(%cl);
		%cl.hasDeployed = false;
		%cl.goodT = "good";
	}
	$hasDropped = false;

   if($SinglePlayer)
      Game::startMatch();
   else if($Server::warmupTime && !$Server::TourneyMode)
      Server::Countdown($Server::warmupTime);
   else if(!$Server::TourneyMode)
      Game::startMatch();

   $teamplay = (getNumTeams() != 1);
   purgeResources(true);

   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   return "True";
}

echo("*****************************************");
echo("Duel Tournament for HaVoC v" @ $HV @ ", by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("*****************************************");