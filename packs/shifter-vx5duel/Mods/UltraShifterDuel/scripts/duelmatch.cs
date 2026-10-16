exec(objectives);
exec("obs.cs");

$DuelCountdownSeconds = 9;

$DuelSpotTaken[1] = false;
                        
$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;
         
$DuelTempWinner = 0;
$DuelLastWinner = 0;

$DuelWeapon[1] = "Rocket Launcher";		$DuelRealWeapon[1] = RocketLauncher;		$DuelWeaponAmmo[1] = RocketAmmo;
$DuelWeapon[2] = "Mortar";					$DuelRealWeapon[2] = Mortar;					$DuelWeaponAmmo[2] = MortarAmmo;
$DuelWeapon[3] = "Plasma Gun";			$DuelRealWeapon[3] = PlasmaGun;				$DuelWeaponAmmo[3] = PlasmaAmmo;
$DuelWeapon[4] = "Shockwave Cannon";	$DuelRealWeapon[4] = ConCun;
$DuelWeapon[5] = "Disc Launcher";		$DuelRealWeapon[5] = DiscLauncher;			$DuelWeaponAmmo[5] = DiscAmmo;
$DuelWeapon[6] = "Grenade Launcher";	$DuelRealWeapon[6] = GrenadeLauncher;		$DuelWeaponAmmo[6] = GrenadeAmmo;
$DuelWeapon[7] = "Vulcan";					$DuelRealWeapon[7] = Vulcan;					$DuelWeaponAmmo[7] = VulcanAmmo;
$DuelWeapon[8] = "Equalizer";				$DuelRealWeapon[8] = Chaingun;				$DuelWeaponAmmo[8] = BulletAmmo;
$DuelWeapon[9] = "ELF Gun";				$DuelRealWeapon[9] = EnergyRifle;
$DuelWeapon[10] = "Blaster";				$DuelRealWeapon[10] = Blaster;
$DuelWeaponMax = 10;

$DuelPack[1] = "Rocket Pack";	$DuelRealPack[1] = SMRPack;
$DuelPack[2] = "Energy Pack";	$DuelRealPack[2] = EnergyPack;
$DuelPack[3] = "Shield Pack";	$DuelRealPack[3] = ShieldPack;
$DuelPack[4] = "Ammo Pack";	$DuelRealPack[4] = AmmoPack;
$DuelPack[5] = "Repair Pack";	$DuelRealPack[5] = RepairPack;
$DuelPackMax = 5;


	                  
function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
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

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

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
	$DuelWeaponSetup[%clientId, 4] = 0;
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
	if ($DuelMine4[%clientId] != "") {
		if (getObjectType($DuelMine4[%clientId]) == "Mine")
			GameBase::setDamageLevel($DuelMine4[%clientId], 2);
		$DuelMine4[%clientId] = "";
	}  
	if ($DuelMine5[%clientId] != "") {
		if (getObjectType($DuelMine5[%clientId]) == "Mine")
			GameBase::setDamageLevel($DuelMine5[%clientId], 2);
		$DuelMine5[%clientId] = "";
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
   	Player::SetItemCount(%clientId, AutoRocketAmmo, 15);
   	Player::SetItemCount(%foeId, AutoRocketAmmo, 15);
   	Player::SetItemCount(%clientId, RocketAmmo, 10);
   	Player::SetItemCount(%foeId, RocketAmmo, 10);
}

function BeginDuel(%clientId, %foeId, %clientPl, %foePl) {                                
	if(!$Dueling[%clientId] || !$Dueling[%foeId]) return;
  	Player::SetItemCount(%clientId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%foeId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%clientId, RocketAmmo, 0);
  	Player::SetItemCount(%foeId, RocketAmmo, 0);
	$DuelCanHurt[%clientId] = true;
	$DuelCanHurt[%foeId] = true;
	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	messageall(0, "~wduelfight.wav");
	messageall(0, "FIGHT!");
	BottomPrint(%clientId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);
	BottomPrint(%foeId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);

	for (%i = 0; %i < 4; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < 4; %i++) {
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
		for (%i = 0; %i < 4; %i++) {
			if(Player::getItemCount(%clientId, $DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]])) {
				schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ");", 15);
				return;
			}
		}
		for (%i = 0; %i < 4; %i++) {
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
	%clientId.dead = 0;
	%foeID.dead = 0;
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
        %armor = "darmor";
	else
       	%armor = "darmor";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);
	Client::setSkin(%clientId, $Client::info[%clientId, 0]); 

    if (!$DuelWeaponSetup[%clientId, 0])
		$DuelWeaponSetup[%clientId, 0] = 1;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 7;
    if (!$DuelWeaponSetup[%clientId, 3])
		$DuelWeaponSetup[%clientId, 3] = 4;
	%packNo = $DuelPackSetup[%clientId];
	if (%packNo == "") %packNo = 1;
	%pack = $DuelRealPack[%packNo];
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < 4; %i++) {
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
		Player::SetItemCount(%clientId,Beacon,3);
		Player::SetItemCount(%clientId, MineAmmo, 5);
   	Player::SetItemCount(%clientId, Grenade, 3);
   	Player::SetItemCount(%clientId, AutoRocketAmmo, 15);
   	Player::SetItemCount(%clientId, TargetingLaser, 1);
	if (%pack == AmmoPack)
		Player::SetItemCount(%clientId,RepairKit,2);
	else
       	Player::SetItemCount(%clientId,RepairKit,1);
	Player::UseItem(%clientId, $DuelRealWeapon[$DuelWeaponSetup[%clientId, 0]]);
	return %pl;
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "Ultra-Shifter_SG1_Duel MOD", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 

   if(%clientId.selClient) {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe...", "observe " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin) {
         if($Shifter::VoteAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         if($Shifter::VoteKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin) {
	         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	        if(%clientId.isSuperAdmin) {
    	        Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
        		if(!%sel.isAdmin) 
					Client::addMenuItem(%clientId, %curItem++ @ "Admin", "admin " @ %sel);
				else if(%clientId == %sel || !%sel.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Status...", "removeadmin " @ %sel);
			}
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
   } else
	   //Client::addMenuItem(%clientId, %curItem++ @ "Miscellany", "misc"); 
   
   	if($curVoteTopic != "" && %clientId.vote == "") {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   	  return;
	}
	  
	Client::addMenuItem(%clientId, %curItem++ @ "Weapons Setup", "weaponsetup");
	Client::addMenuItem(%clientId, %curItem++ @ "Pack Setup", "packsetup");

	if(!$DuelStart && %clientId.isAdmin && $matchStarted)
		Client::addMenuItem(%clientId, %curItem++ @ "Force Tourney Start", "forcedt");

	if($curVoteTopic == "" && !%clientId.isAdmin) {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
   } else if(%clientId.isAdmin) {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
}

function processMenuuseCustom(%clientId, %skin)
{
	if(%skin == 0){%clientId.custom = True;}
	if(%skin == 1){%clientId.custom = False;}
	%clientId.notready = true;
}

function DuelCheckStart() {
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
      	if(%notReadyCount == 1)
         	MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4) {
        	for(%i = 0; %i < (%notReadyCount - 2); %i++)
            	%str = Client::getName(%notReady[%i]) @ ", " @ %str;
			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
         	MessageAll(0, %str);
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
	if(%num == 4) {
		if ($DuelPackSetup[%cl] == "") $DuelPackSetup[%cl] = 1;
		bottomprint(%cl, "<jc><f1>Your weapon setup is <f2>" @ 
		$DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>, and <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 3]] @ "<f1>.\nYour pack setup is a <f2>" @ 
		$DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
		schedule("CPmsg(" @ %cl @ ");", 10);
		return;
	}
	WeaponSetup(%cl, %num, 0);
}

function CPmsg(%cl) {
	if(!$DuelStart) {
		if(%cl.notready)
			centerprint(%cl, "<jc><f0>Welcome to Dread Tournament\n<f2> modded by {TKO}Arkangel - http://TKO.8k.com/\n\n<f1>Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0);
		else
			bottomprint(%cl, "<f1><jc>Waiting for the tournament to start.", 0);
	}
}

function WeaponSetup(%clientId, %num, %i) {
	%w1 = $DuelWeaponSetup[%clientId, 0];
	%w2 = $DuelWeaponSetup[%clientId, 1];
	%w3 = $DuelWeaponSetup[%clientId, 2];
	Client::buildMenu(%clientId, "Select your weapons (" @ (4 - %num) @ " left):", "chooseweapon", true);
	while(true) {
		%i++;
		if(%i != %w1 && %i != %w2 && %i != %w3) {
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
		$DuelWeaponSetup[%clientId, 0] = 1;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 7;
    if (!$DuelWeaponSetup[%clientId, 3])
		$DuelWeaponSetup[%clientId, 3] = 4;

	bottomprint(%cl,"<jc><f1>Your weapon setup is <f2>" @ 
	$DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>, and <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%cl, 3]] @ "<f1>.\nYour pack setup is a <f2>" @
	$DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
	schedule("CPmsg(" @ %cl @ ");", 10);
	return;
}

function processMenuOptions(%clientId, %option) {
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
	if(!DuelPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; }	// PORT: see the end of this file

	if(%opt == "forcedt") {
		messageall(0, Client::getName(%clientId) @ " has forced the tournament to start!");
		messageall(0, "Tournament begins in 20 seconds.");
		$DuelStart = true;
		InitPartners();
		centerprintall("", 0);
		$DuelCountDown = true;
		schedule("$DuelCountDown = false;", 22);
		schedule("messageall(0, \"Lets get it on!\");", 20);
		schedule("DuelCheck();", 21);
		return;
	}
	if(%opt == "removeadmin") { 
		%cl.isAdmin = "";
		%cl.isSuperAdmin = "";
		if(%cl == %clientId)
			Client::sendMessage(%cl,1,"You have revoked your Admin Status."); 
		else {
			Client::sendMessage(%cl,1,"Your Admin Status has been revoked."); 
			hvcAdminMsg("Admin Status stripped from: " @ Client::getName(%cl) @ ".");
		}
	}
	if(%opt == "saveinfo")
	{
		SaveCharacter(%clientId);
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%clientID.telepoint = "False";
		if(%clientID.telebeacon)
		{
			deleteobject(%clientID.telebeacon);
			%clientID.telebeacon = "False";
		}
		if(%clientID.teledisk)
		{
			deleteobject(%clientID.teledisk);
			%clientID.teledisk = "False";
		}		
		return;
	}
	else if (%opt == "weapon_laptop")
	{
 		%curItem = 0;
  		Client::buildMenu(%clientId, "Laptop Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Turret Control", "laptop_control");
  		Client::addMenuItem(%clientId, %curItem++ @ "Turret Hack", "laptop_hack");
  		return;	
	}
	else if (%opt == "laptop_control")
	{
		%ClientId.HackPack = True;
      bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);
		return;
	}
	else if (%opt == "laptop_hack")
	{
      bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
		%ClientId.HackPack = False;
		return;
	}	

	else if (%opt == "spawn_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Spawn Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
  		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
  		return;
	}
	else if (%opt == "spawn_standard")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Standard.",5);
		%clientId.spawntype = "standard";
		return;
	}
	else if (%opt == "spawn_random")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Random.",5);
		%clientId.spawntype = "random";
		return;
	}
	else if (%opt == "spawn_favs")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Favs.",5);
		%clientId.spawntype = "favs";
		return;
	}
	else if (%opt == "booster_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Booster Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Normal Booster", "booster_norm");
  		Client::addMenuItem(%clientId, %curItem++ @ "Advanced Booster", "booster_adv");
  		return;
	}
	else if (%opt == "weapon_mortar")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Mortar Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_emp");
  		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
  		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
  		return;
	}
	else if (%opt == "weapon_rocket")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Stinger Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
		if ($Shifter::LockOn)
	  		Client::addMenuItem(%clientId, %curItem++ @ "Heat Seeker", "weapon_rocket3");
  		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
  		return;
	}
	else if (%opt == "weapon_plasma")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Plasma Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_plasma_rapid");
  		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
  		return;
	}
	else if (%opt == "weapon_disc")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Disc Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_disc_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_disc_rapid");
  		return;
	}
	else if (%opt == "weapon_dmines")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Mine Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "DLM (Laser Mines)", "weapon_dmines1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_dmines2");
  		return;
	}
	else if (%opt == "weapon_abeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Poison Throwing Stars", "weapon_abeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Shock Charges", "weapon_abeacon2");
 		return;
	}
	else if (%opt == "weapon_cbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Satchel", "weapon_cbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_cbeacon2");
 		return;
	}
	else if (%opt == "weaponorder")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Weapon Order Option", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Old style", "weaponorder_0");
  		Client::addMenuItem(%clientId, %curItem++ @ "Hud-Follow", "weaponorder_1");
 		return;
	}
	else if (%opt == "weapon_gbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "FireBomb", "weapon_gbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_gbeacon2");
 		return;
	}
	else if (%opt == "weapon_gravgun")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "GravGun Options", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_tract");
   	Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repulse");
   	Client::addMenuItem(%clientId, %curItem++ @ "Grapler Effect", "weapon_gravgun_pull");
   	return;
	}
	else if (%opt == "weapon_plastic")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Plastique Options", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "1 Sec. Delay", "weapon_plastic_plas1");
   	Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   	Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   	Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   	Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   	return;
	}
	//========================================================= Engineer Opts
	else if (%opt == "engineer_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Engineer Options", "options", true);
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Gun", "weapon_eng");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");
		return;
	}	
	else if (%opt == "weapon_engmine")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Mine Type", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Proximity Warning", "weapon_engmine_proxy");
   	Client::addMenuItem(%clientId, %curItem++ @ "Cloaking Mine", "weapon_engmine_cloak");
   	Client::addMenuItem(%clientId, %curItem++ @ "Laser Mine", "weapon_engmine_laser");
   	Client::addMenuItem(%clientId, %curItem++ @ "Anti-Personel", "weapon_engmine_stand");
   	Client::addMenuItem(%clientId, %curItem++ @ "Replicator", "weapon_engmine_replica");
   	return;
	}
	else if (%opt == "weapon_engbeacon")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Mine Type", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Standard Beacon", "weapon_engbeacon_standard");
   	Client::addMenuItem(%clientId, %curItem++ @ "Cloaked Camera", "weapon_engbeacon_camera");
   	Client::addMenuItem(%clientId, %curItem++ @ "Medi-Pack Patch", "weapon_engbeacon_medikit");
   	return;
	}
	else if (%opt == "weapon_eng")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Engineer Gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Repair", "weapon_eng_repair");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hack", "weapon_eng_hack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Disassymbler", "weapon_eng_disa");
   		return;
	}	
	//========================================================= Merc Booster
	else if (%opt == "booster_norm")
	{
		%clientId.booster = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Normal Mode.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "booster_adv")
	{
		%clientId.booster = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Advanced Mode.\", 3);", 0.01);
   		return;
	}
	//========================================================= Engineer Mines
	else if(%opt == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0.01);
  		return;
	}
	else if(%opt == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0.01);
  		return;
	}
	else if(%opt == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0.01);
  		return;
	}
	else if(%opt == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0.01);
  		return;
	}
	else if(%opt == "weapon_engmine_replica")
	{
		%clientId.EngMine = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0.01);
  		return;
	}
	//================================================================= Engineer Beacons
	else if(%opt == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0.01);
  		return;
	}
	else if (%opt == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0.01);
   		return;
	}		
	//=================================================================== Eng-Gun Options
	else if (%opt == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, FixIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}
   		return;
	}
	else if (%opt == "weapon_eng_hack")
	{
		if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::setItemCount(%clientId, Hackit, 1);
			Player::mountItem(%clientId, HackIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}
   		return;
	}
	else if (%opt == "weapon_eng_disa")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, FixIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 1);
			Player::mountItem(%clientId, DisIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0.01);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0.01);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
		}
   	return;
	}

	//========================================================= Plastique
	else if(%opt == "weapon_plastic_plas1")
	{
		%clientId.Plastic = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 1 Sec.\", 3);", 0.01);
   	return;
	}
	else if(%opt == "weapon_plastic_plas2")
	{
		%clientId.Plastic = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_plastic_plas5")
	{
		%clientId.Plastic = 5;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_plastic_plas10")
	{
		%clientId.Plastic = 10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_plastic_plas15")
	{
		%clientId.Plastic = 15;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0.01);
   	return;
	}

	//===================================================== Mortar Options
	//
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0.01);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
		return;
	}
	else if (%opt == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0.01);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%opt == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0.01);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%opt == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0.01);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	//===================================================== Rocket Options
	else if (%opt == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heat Seeking Initiated.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Wire Guided System Initiated.\", 3);", 0.01);
  		return;
	}

	//====================================================== Dread Mine Options
	else if (%opt == "weapon_dmines1")
	{
		%clientId.dmines = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To DLM.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_dmines2")
	{
		%clientId.dmines = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Standard.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_dmines3")
	{
		%clientId.dmines = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Light-AP.\", 3);", 0.01);
   		return;
	}

	//===============================Assassin Beacon
	else if (%opt == "weapon_abeacon1")
	{
		%clientId.AssBcn = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Poison Throwing Stars.", 3);
   	return;
	}
	else if (%opt == "weapon_abeacon2")
	{
		%clientId.AssBcn = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Shock Charge.", 3);
  		return;
	}

	else if (%opt == "weaponorder_0")
	{
		%clientId.WeaponOrder = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Old style WeaponOrder.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weaponorder_1")
	{
		%clientId.WeaponOrder = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hud-Follow style WeaponOrder.\", 3);", 0.01);
  		return;
	}

	else if (%opt == "weapon_cbeacon1")
	{
		%clientId.ChemBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Satchel.", 3);
   	return;
	}
	else if (%opt == "weapon_cbeacon2")
	{
		%clientId.ChemBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	else if (%opt == "weapon_gbeacon1")
	{
		%clientId.GolBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To FireBomb.", 3);
   	return;
	}
	else if (%opt == "weapon_gbeacon2")
	{
		%clientId.GolBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	//====================================================== Plasma Options
	else if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_disc_regular")
	{
		%clientId.disc = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Disc Shell Selected.\", 3);", 0.01);
   	return;
	}
	else if (%opt == "weapon_disc_rapid")
	{
		%clientId.disc = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid Disc Shell Selected.\", 3);", 0.01);
   		return;
	}
	//==================================================== Grav Gun Options
	else if (%opt == "weapon_gravgun_tract")
	{
		%clientId.gravbolt = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_gravgun_repulse")
	{
		%clientId.gravbolt = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0.01);
   		return;
	}
	else if (%opt == "weapon_gravgun_pull")
	{
		%clientId.gravbolt = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Grapler Selected.\", 3);", 0.01);
   		return;
	}

	if (%opt == "weaponoptions") 
  	{ 	
  		%curItem = 0;
		%armor = "darmor";
  		Client::buildMenu(%clientId, "Weapon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");

		if (%armor == "larmor" || %armor == "lfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_abeacon");

		if (%armor == "spyarmor" || %armor == "spyfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_cbeacon");

		if (%armor == "harmor" || %armor == "darmor" || %armor == "jarmor" || %armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");
   		
		if (%armor == "harmor" || %armor == "darmor")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mine Options", "weapon_dmines");

   		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");

		if (%armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");

		if (%armor == "marmor" || %armor == "mfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Booster Options", "booster_options");

		if (%armor == "earmor" || %armor == "efemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Options", "engineer_options");

		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");
		
		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Command LapTop Options", "weapon_laptop");

		if (%armor != "aarmor" && %armor != "afemale" && %armor != "jarmor")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Disc Options", "weapon_disc");
		
		if (%armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_gbeacon");

		if (%armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
   		
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawn_options");
   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Order", "weaponorder");			
   		Client::addMenuItem(%clientId, %curItem++ @ "SaveInfo", "saveinfo");	
  		return;
  	}		
	if(%opt == "misc") {
		%i = 0;
		Client::buildMenu(%clientId, "Miscellany:", "mmisc", true); 
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode...", "obsm"); 
		if ($DuelModeOff[%clientId])
			Client::addMenuItem(%clientId, %i++ @ "Enable Duels", "toggled");
		else
			Client::addMenuItem(%clientId, %i++ @ "Disable Duels", "toggled");			
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
		$DuelWeaponSetup[%clientId, 3] = 0;
		WeaponSetup(%clientId, 0, 0);
        return;
	}
    if (%opt == "packsetup") {
		PackSetup(%clientId);
        return;
	}
   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
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

   	%clientId.justConnected = "";

	if($DuelTModeOff[%clientId]) {
		centerprint(%clientId, "<jc><f0>Welcome to Dread Tournament\n<f2>modded by {TKO}Arkangel - http://TKO.8k.com/\n\n<f2>You currently have Duel Tournament Mode disabled.\n\nPress tab, click Miscellany... then click Enable Duel Mode.", 60); 
		$DuelAlive[%clientId] = false;
		return;
	} else {
		if($DuelStart) {
			$DuelAlive[%clientId] = false;
			centerprint(%clientId, "<jc><f0>Welcome to Dread Tournament\n<f2>modded by {TKO}Arkangel - http://TKO>8k.com/\n\n<f2>A tournament is currently in progress.\n\n<f1>Please wait for the tournament to be completed, then you will be able to join in.\n\nPress 'O' to learn how to play.", 60); 
		} else {
			$DuelAlive[%clientId] = true;
			if($matchStarted)
				centerprint(%clientId, "<jc><f0>Welcome to Dread Tournament\n<f2>modded by {TKO}Arkangel - http://TKO.8k.com/\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
			else
				centerprint(%clientId, "<jc><f0>Welcome to Dread Tournament\n<f2>modded by {TKO}Arkangel - http://TKO.8k.com/\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.", 0); 
		}
	}
	%clientId.guiLock = false;
}

function Player::enterMissionArea(%player) {
	if($DuelCanHurt[%cl]) Client::sendMessage(Player::getClient(%player),0,"You have entered the mission area.");
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

	centerprintall("<jc><f0>Welcome to Dread Tournament\n<f2>modded by {TKO}Arkangel - http://TKO.8k.com/\n\n<f1>Choose your weapons from the TAB menu.\n\nPress 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
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
function MineAmmo::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime())
	{
		%client = Player::getClient(%player);
		%clTeam = GameBase::getTeam (%client);
		%armor = Player::getArmor(%player);
		%plTeam = GameBase::getTeam(%player);
		%proxmax = $TeamItemCount[%plTeam @ "ProxMine"];
		if($server::deathmatch)
			%obj = newObject("","Mine", "DmMine");
		else if (%armor == "larmor" || %armor == "lfemale")
			%obj = newObject("","Mine", "Hologram");
		else if (%armor == "aarmor" || %armor == "afemale")
			%obj = newObject("","Mine", "ShockMine");
		else if (%armor == "spyarmor" || %armor == "spyfemale")
			%obj = newObject("","Mine", "SubspaceMine");
		else if(%armor == "earmor" || %armor == "efemale")
		{
			if (%client.EngMine == "0" && %proxmax < 9)
			{
				%obj = newObject("","Mine", "ProxMine");
				$TeamItemCount[%plTeam @ "ProxMine"]++;
			}
			else if (%client.EngMine == "1")
				%obj = newObject("","Mine", "SubspaceMine");
			else if (%client.EngMine == "2")
					LaserMine(%client, %player, %item, 15);
			else if (%client.EngMine == "3")
				%obj = newObject("","Mine", "antipersonelMine");
			else if (%client.EngMine == "4")
				%obj = newObject("","Mine", "ReplicatorMine");
		}
		else if (%armor == "darmor" || %armor == "harmor")
		{
			if (%client.dmines == 0 || !%client.dmines)
				LaserMine(%client, %player, %item, 15);
			else if (%client.dmines == 1)
				%obj = newObject("","Mine", "antipersonelMine"); 
		}
		else if (%armor == "sarmor" || %armor == "sfemale" || %armor == "marmor" || %armor == "mfemale" || %armor == "barmor" || %armor == "bfemale")
			%obj = newObject("","Mine", "antipersonelMine"); 
		if(%obj)
		{
			Player::decItemCount(%player,%item);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%client,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,%clTeam);
		}
	}
}
	exec(baseprojdata);
   exec(admin);
   exec(player);
   exec(objectives);
   exec(observer);
//PORT-OFF:    exec(client);
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
			else if ($DuelMine4[%client] == "")
				$DuelMine4[%client] = %obj;
			else if ($DuelMine5[%client] == "")
				$DuelMine5[%client] = %obj;
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   	DuelResetClient(%clientId);

//PORT-OFF:    if(Client::getName(%clientId) == "{TKO}Arkange1")
//PORT-OFF:       schedule("KickArkange1(" @ %clientId @ ");", 20, %clientId);

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>modded by {TKO}Arkangel\n<f1>DREAD DUEL TOURNEY For **Ultra-Shifter_SG1_Duel** Servers Only!\n<f2>T H E  O N L Y  D U E L  M O D I F I C A T I O N **Ultra-Shifter_SG1_Duel**!!!\n<f1>http://TKO.8k.com");
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

	%clientId.observerMode = "";
   Game::onPlayerConnected(%clientId);
}

function Server::onClientDisconnect(%clientId)
{
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
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

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
	DuelCheckStart();
}

function DuelMOD::oldMissionChangeNotify(%serverManagerId, %nextMission) {
   if(%serverManagerId == 2048) {
      //cls();
      echo("Server mission complete - changing to mission: ", %nextMission);
      //echo("Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
}

function Server::loadMission(%missionName, %immed)
{

	DuelMOD::restoreServerDefaults();

   if($loadingMission)
      return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
   }

   $timeReached = true;
   DuelMOD::missionObjectives();
   $timeReached = false;

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

   resetSimTime(); // deal with time imprecision

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
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	Player::setDamageFlash(%this,0.75);

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
	  schedule("GameBase::startFadeOut(" @ %this @ ");", 0.1, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);                
	  schedule("deleteObject(" @ %this @ ");", 0.2, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (getObjectType(%this) == "Player")
	{                          
		%clientId = Player::getClient(%this);
		if (!$Dueling[%clientId] || !$Dueling[%object]) return;                               
		if (!$DuelCanHurt[%clientId]) return;
		if ($Dueling[%object] != %clientId && %clientId != %object)
		{
			Bottomprint(%foeId, "<jc><f2>Wrong Target!");
			return;                                         
		}
		%damagedClient = Player::getClient(%this);
    	%shooterClient = %object;
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
		 	if (%cl.observerTarget == %shooterClient && %damagedClient != %shooterClient)
	 			Client::SendMessage(%cl,0, Client::GetName(%shooterClient) @ " just harmed " @ Client::GetName(%damagedClient));
		}       
	}   

	if (Player::isExposed(%this))
	{
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		%damagedClient = Player::getClient(%this);
		%damTeam = Client::getTeam(%damagedClient);
		%armor = Player::getArmor(%this);
		%objArmor = Player::getArmor(%object);
		%clientId = %damagedClient;
		if((%type == $BulletDamageType || %type == $LaserDamageType || %type == $SniperDamageType) && (%objarmor == "larmor" || %objarmor == "lfemale" || %objarmor == "earmor" || %objarmor == "efemale" || %objarmor == "spyarmor" || %objarmor == "spyfemale" || %objarmor == "jarmor"))
			%snipeType = 1; else %snipeType = 0;
		if(%armor == "harmor" || %armor == "darmor" || %armor == "jarmor")
			%heavyArmor = 1; else %heavyArmor = 0;
		if(%vertPos == "head")
			%head = 1;
		else if(%vertPos == "torso")
			%torso = 1;
		else if(%vertPos == "legs")
			%legs = 1;
		Player::applyImpulse(%this,%mom);
		%friendFire = 1.0;	

		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType)
			{
				if(%armor == "harmor")
				{ 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						%value += (%value * 0.3);
				}
				else
					%value += (%value * 0.3);
			}
			//If Shield Pack is on
		if(%torso)
			{
				%packType = Player::getMountedItem(%damagedClient,$BackpackSlot);
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient,%kick, (%kick/2));
				}
				else if(%snipetype && %packType == SuicidePack && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") && !%td)
				{						
					MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!");
					Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!");
					Player::unmountItem(%this,$BackpackSlot);	
					%obj = newObject("","Mine","Suicidebomb");
					%obj.deployer = %shooterClient;
					addToSet("MissionCleanup", %obj);
					GameBase::throw(%obj,%shooterClient,9 * %damagedClient.throwStrength,false);
					Gamebase::setposition(%obj, gamebase::getposition(%this));
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient, -%kick, (%kick/2));
					if (%kick > 45)
					{
						Player::dropItem(%damagedClient,%packtype);
					}
				}
				if(%snipeType)
				{
					if(%heavyArmor)
					{	if(%quadrant == "middle_back"  || %quadrant == "middle_front" || %quadrant == "middle_middle")
							%value = (%value * 0.85);
						else
							%value = (%value * 0.65);
					}
					else
						%value = (%value * 0.85);
				}
			}
			else if (%legs)
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 200);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
				if(%snipeType)
				{
					if(%heavyArmor)
					{	if(%quadrant == "middle_back"  || %quadrant == "middle_front" || %quadrant == "middle_middle")
							%value = (%value * 0.85);
						else
							%value = (%value * 0.65);
					}
					else
						%value = (%value * 0.85);
				}
			}
			else if (%head)
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 50);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
	   			if (%snipeType)
					{	if(%heavyArmor)
						{
						if(%quadrant == "middle_front") //- Direct Head Shot
							%value *= 2.55;
						else if(%quadrant == "middle_back" || %quadrant == "middle_middle") //- Back Of Head Shit
							%value *= 4.75;
						else if(%quadrant == "back_left" || %quadrant == "back_right") //- Back
							%value *= 0.65;
	     			}
					else %value += (%value * 0.8);
				}
			}
			//=============================================== Shield Pack On
			if (%type != -1 && %this.shieldStrength && %type != $HBlasterDamageType && %type != $EnergyDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
	
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $ExplosionDamageType || %type == $MineDamageType)
					%strength *= 0.75;
				else if (%type == $ElectricityDamageType)
					%strength = 0.0;
				else if (%snipeType)
					%strength *= 0.75;
	
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
					%value -= %absorb;
				}
			}

		if (%armor == "jarmor" && !%this.shieldStrength)
			Renegades_startShield(%damagedClient, %this);
		//==================================== Flash Damage Does EMP Effect
		//if(%type == $FlashDamageType || %type == $nukedamagetype)
		//	Insomniax_startEMP(%damagedClient, %this, 14);
		//else if(%type == $MDMDamageType && %value > 0.3)
		//	Insomniax_startEMP(%damagedClient, %this, 14);
		else //============================================ Cloaking Blast
		if(%type == $CloakDamageType)
		{	GameBase::startFadeOut(%this);
			schedule("GameBase::startFadeIn(" @ %this @ ");", 90);
		}
		else //======================================= Life Drain - Poison
		if (%type == $EnergyDamageType && !%td && (%armor != "aarmor" && %armor != "afemale"))
			Renegades_startBlind(%damagedClient, %this);
		else //======================= Plasma Damage Catches Player On Fire
		if ((%type == $PlasmaDamageType || %type == $NukeDamageType || %type == $MDMDamageType) && !%td && %armor != "barmor" && %armor != "bfemale")
		{	%rnd = floor(getRandom() * 10);
			if(%rnd > 5)
				Renegades_startBurn(%damagedClient, %this);
		}


  			if (%value)
			{
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this))
				{ 
					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
					if(%dlevel >= 0.57)
					{                                                         
						%foeId = $Dueling[%damagedClient];
						if(%foeId.lastsound < getSimTime())
						{
							%foeId.lastsound = getSimTime() + 8;
							if (Client::GetGender(%damagedClient) == "Female")
								Client::sendMessage(%foeId, 0, "~wduelfinisher.wav");
							else
								Client::sendMessage(%foeId, 0, "~wduelfinishim.wav");
						}
					}
				}
				else
				{
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					if(%weaponType != -1)
						Player::unmountItem(%this,$WeaponSlot);
					Player::blowUp(%this);
					%max = getNumItems(); 
					for (%i = 0; %i < %max; %i = %i + 1)
					{ 
						%item = getItemData(%i);
						%count = Player::getItemCount(%this, %item); 
						if(%count)
							Player::setItemCount(%this, %item, 0); 
					}
					playSound(debrisLargeExplosion,GameBase::getPosition(%this));
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient, %shooterClient, %type);
				}
			}
		}
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

function Server::finishMissionLoad()
{

   exec(server);

   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();

	$teamplay = (getNumTeams() != 1);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		Game::assignClientTeam(%cl);
		%cl.observerMode = "";
		%cl.obsmode = "Free";
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
   if($SinglePlayer)
      Game::startMatch();
   else if($Server::warmupTime && !$Server::TourneyMode)
      Server::Countdown($Server::warmupTime);
   else if(!$Server::TourneyMode)
      Game::startMatch();

   $teamplay = (getNumTeams() != 1);
   purgeResources(true);

   // make sure the match happens within 5-10 hours.
   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   
   return "True";
}

echo("**********************Ultra-Shifter_SG1_Duel!!************************");
echo("Duel Tournament for Ultra-Shifter_SG1 servers, modded by {TKO}Arkangel");
echo("Initialization succeeded.");
echo("*****************************************");

//====================================================================================================
// PORT (Modern Tribes 1.50). Menu codes are sent by the client; this handler ran whatever arrived.
// "removeadmin" had no test at all: any player could strip Admin + Super Admin from anyone.
// Same guard as the HaVoC / Renegades Duel ports, with this mod's own vote settings.
//====================================================================================================
function DuelPort::optAllowed(%clientId, %opt, %cl)
{
	if(%opt == "removeadmin")
	{
		if(!%clientId.isSuperAdmin)
			return 0;
		if(%cl == %clientId)
			return 1;
		if(%cl.isSuperAdmin)
			return 0;
		return 1;
	}
	if(%opt == "admin" || %opt == "ban")
	{
		if(%clientId.isSuperAdmin)
			return 1;
		return 0;
	}
	if(%opt == "kick" || %opt == "fteamchange" || %opt == "cmission" || %opt == "ctimelimit" || %opt == "reset")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "smatch" || %opt == "etd" || %opt == "dtd" || %opt == "cffa" || %opt == "ctourney")
	{
		if(%clientId.isAdmin)
			return 1;
		return 0;
	}
	if(%opt == "forcedt")
	{
		if(%clientId.isAdmin && !$DuelStart && $matchStarted)
			return 1;
		return 0;
	}
	// never listed on a duel map (everyone is an observer until a duel starts)
	if(%opt == "changeteams")
		return 0;
	if(%opt == "c5vkick" || %opt == "vkick")
	{
		if(!%clientId.isAdmin && $curVoteTopic == "" && $Shifter::VoteKick)
			return 1;
		return 0;
	}
	if(%opt == "c5vadmin" || %opt == "vadmin")
	{
		if(!%clientId.isAdmin && $curVoteTopic == "" && $Shifter::VoteAdmin)
			return 1;
		return 0;
	}
	return 1;
}
