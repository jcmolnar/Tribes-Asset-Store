exec(objectives);

$DuelCountdownSeconds = 9;

$DuelSpotTaken[1] = false;
                        
$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;
                            
$DuelWeaponMax = 15;
$DuelPackMax = 4;

$DuelTempWinner = 0;
$DuelLastWinner = 0;

$DuelWeapon[1] = "Chaingun";   // ammo= BulletAmmo            // Meltdown_v216
$DuelWeapon[2] = "Plasma Gun";   // ammo=  PlasmaAmmo         // Meltdown_v216
$DuelWeapon[3] = "Disc Launcher";    // ammo= DiscAmmo        // Meltdown_v216
$DuelWeapon[4] = "TwinFusor";      // ammo= TwinFusorAmmo     // Meltdown_v216
$DuelWeapon[5] = "Grenade Launcher";  // ammo= GrenadeAmmo    // Meltdown_v216
$DuelWeapon[6] = "RailGun";             // ammo= RailGunAmmo      // Meltdown_v216
$DuelWeapon[7] = "Mortar";    // ammo= MortarAmmo            // Meltdown_v216
$DuelWeapon[8] = "Mass Driver";     // ammo= Bolts          // Meltdown_v216                     // Meltdown_v216
$DuelWeapon[9] = "HP Sniper Rifle"; // ammo= SXAmmo         // Meltdown_v216
$DuelWeapon[10] = "Mitzi Blast Cannon";                      // Meltdown_v216
$DuelWeapon[11] = "Shotgun"; // ammo=  ShotgunAmmo       // Meltdown_v216
$DuelWeapon[12] = "MD-1024";          // ammo=  Shells       // Meltdown_v216
//energy weapons
$DuelWeapon[13] = "Laser Rifle";                             // Meltdown_v216
$DuelWeapon[14] = "Laser Pistol";
//$DuelWeapon[15] = "Particle Beam (PBW)";                     // Meltdown_v216
$DuelWeapon[15] = "ELF Gun";                                 // Meltdown_v216

$DuelPack[1] = "Energy Pack";
$DuelPack[2] = "Repair Pack";
$DuelPack[3] = "Shield Pack";
$DuelPack[4] = "Ammo Pack";

$DuelRealPack[1] = EnergyPack;
$DuelRealPack[2] = RepairPack;
$DuelRealPack[3] = ShieldPack;
$DuelRealPack[4] = AmmoPack;

$DuelRealWeapon[1] = Chaingun;           //  Chaingun
$DuelRealWeapon[2] = PlasmaGun;          //  PlasmaGun
$DuelRealWeapon[3] = DiscLauncher;       // DiscLauncher
$DuelRealWeapon[4] = TwinFusor;          // TwinFusor
$DuelRealWeapon[5] = GrenadeLauncher;      // Grenade Launcher
$DuelRealWeapon[6] = RailGun;        // RailGun
$DuelRealWeapon[7] = Mortar;       // Mortar
$DuelRealWeapon[8] = MassDriver;    // Mass Driver
$DuelRealWeapon[9] = aaodsniperx;  // HP Sniper Rifle
$DuelRealWeapon[10] = MBCannon;   // Mitzi Blast Cannon
$DuelRealWeapon[11] = Shotgun;      // Shotgun
$DuelRealWeapon[12] = rifle;         // MD-1024
//ENERGY WEAPONS
$DuelRealWeapon[13] = LaserRifle;       //  Laser Rifle
$DuelRealWeapon[14] = LaserPistol;    // Laser Pistol
//$DuelRealWeapon[15] = PBW;          // Particle Beam (PBW)
$DuelRealWeapon[15] = ELFGun;   // ELF Gun

$DuelWeaponAmmo[1] = BulletAmmo;
$DuelWeaponAmmo[2] = PlasmaAmmo;
$DuelWeaponAmmo[3] = DiscAmmo;
$DuelWeaponAmmo[4] = TwinFusorAmmo;
$DuelWeaponAmmo[5] = GrenadeAmmo;
$DuelWeaponAmmo[6] = RailGunAmmo;
$DuelWeaponAmmo[7] = MortarAmmo;
$DuelWeaponAmmo[8] = Bolts;
$DuelWeaponAmmo[9] = SXAmmo;
$DuelWeaponAmmo[10] = MitziCore;
$DuelWeaponAmmo[11] = ShotgunAmmo;
$DuelWeaponAmmo[12] = Shells;

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
        %armor = "lfemale";
	else
       	%armor = "larmor";
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
    Player::SetItemCount(%clientId,Beacon,4);
    Player::SetItemCount(%clientId, MineAmmo, 3);
   	Player::SetItemCount(%clientId, Grenade, 5);  
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
		Client::buildMenu(%clientId, "Duel MOD - havoc.sirris.com", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 
        // Defender
        //Client::addMenuItem(%clientId, %curItem++ @ "Weapon Fire Mode Options", "weaponoptions");

   if(%clientId.selClient) {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe...", "observe " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin) {
         //==========================================
         // Vote to admin Removed by defender
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         //
         //==========================================
         // Removed by defender this was becomeing a problem
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);%sel);Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin) {
	         Client::addMenuItem(%clientId, %curItem++ @ ".....Kick " @ %name, ".....Kick " @ %sel);
	        if(%clientId.isSuperAdmin) {
                // Defender
              Client::addMenuItem(%clientId, %curItem++ @ ".....Torture", "manip " @ %sel);
                Client::addMenuItem(%clientId, %curItem++ @ ".....Ban " @ %name, ".....Ban " @ %sel);
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
	   Client::addMenuItem(%clientId, %curItem++ @ "Miscellany", "misc"); 
   
   	if($curVoteTopic != "" && %clientId.vote == "") {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   	  return;
	}
	//Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
	Client::addMenuItem(%clientId, %curItem++ @ "Buy Your Duel Weapons", "weaponsetup");
	Client::addMenuItem(%clientId, %curItem++ @ "Buy Your Packs", "packsetup");

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
			centerprint(%cl, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0);
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

// added from shifter
function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	if($MLIST::Type[%type] != "Training")
	{
		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
		%index++;
	}
}

function processMenuCMType(%clientId, %options)
{
	echo ("Missions Change Menu");

	if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
		%index = 0;

		for(%i = %first; %i < $MLIST::TypeCount; %i++)
		{
			if ($MLIST::Type[%i] != "Training")
			{
				%index++;
				if (%index <= 7)
				{
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
				} else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %index);
					break;
				}
			}
		}
		return;
	}

	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "SELECT MISSION", "cmission", true);

	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
	}
}

function processMenuCMission(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuCMType(%clientId, %type @ " " @ %first);
		return;
	}
	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);

	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];

	if(%misType == "" || %misType == "Training")
		return;

	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
			break;
		if(%misIndex == -1)
			return;
	}

	if(%clientId.isAdmin && %clientId.vote != "1")
	{
		%clientId.vote = 0;
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}

//END

function processMenuOptions(%clientId, %option) {
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT: the menu code is sent by the client, so the admin-only entries are checked here.
   if(%opt == "kill" || %opt == "manip" || %opt == "dan" || %opt == "undan" || %opt == "strip" || %opt == "poss" || %opt == "unposs" || %opt == "gag" || %opt == "ungag" || %opt == "deadmin")
   {
      if(!%clientId.isSuperAdmin) return;
   }
   if(%opt == "removeadmin" && %cl != %clientId && !%clientId.isSuperAdmin) return;
   if(%opt == "admenu" || %opt == "botmenu" || %opt == "forcedt")
   {
      if(!%clientId.isAdmin) return;
   }

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
   // Defender
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
      Client::addMenuItem(%clientId, "71 Hour", 60);
      Client::addMenuItem(%clientId, "8Infinite", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "manip")
   {
		Client::buildMenu(%clientId, "Torture: "@Client::getName(%cl), "Options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Kill", "kill " @ %cl);
		if(%cl.dan)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Accessing PDA", "undan " @ %cl);
		else if(!%cl.dan)
			Client::addMenuItem(%clientId, %curItem++ @ "Mindlessly Access PDA", "dan " @ %cl);
		//if(!%cl.isSuperAdmin || %client.isNO || %client.isLevel1)
        if(%clientId.isSuperAdmin)
            Client::addMenuItem(%clientId, %curItem++ @ "Strip", "strip " @ %cl);
		return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if (%opt == "weaponoptions")
   {
   		%curItem = 0;

   		//Client::buildMenu(%clientId, "Weapon Options", "options", true);
        Client::addMenuItem(%clientId, %curItem++ @ "Plasma", "weapon_plasma");
        Client::addMenuItem(%clientId, %curItem++ @ "MB Cannon", "weapon_MB");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mortar", "weapon_mortar");
   		Client::addMenuItem(%clientId, %curItem++ @ "Chaingun", "weapon_chaingun");
        Client::addMenuItem(%clientId, %curItem++ @ "Disc Launcher", "weapon_DiscLauncher");
        Client::addMenuItem(%clientId, %curItem++ @ "GrenadeLauncher", "weapon_GrenadeLauncher");
        //Client::addMenuItem(%clientId, %curItem++ @ "RailGun", "weapon_RailGun");
        return;
   	}
	else if (%opt == "weapon_MB")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mitzi Blast Cannon", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Blast", "weapon_MB_reg");
   		//if($Meltdown::EMP) Client::addMenuItem(%clientId, %curItem++ @ "EMP", "weapon_MB_haywire");
   		if($Meltdown::Booster) Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Booster", "weapon_MB_booster");
  		//if($Meltdown::Poisoning) Client::addMenuItem(%clientId, %curItem++ @ "Poisoning", "weapon_MB_poison");
  		//if($Meltdown::Heat) Client::addMenuItem(%clientId, %curItem++ @ "Heat", "weapon_MB_heat");
  		//if($Meltdown::Annihilator) Client::addMenuItem(%clientId, %curItem++ @ "Annihilator", "weapon_MB_ANIH");
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
    else if (%opt == "weapon_chaingun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Chaingun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_chaingun_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Gauss", "weapon_chaingun_Gauss");
        return;
	}
    else if (%opt == "weapon_mortar")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Impact Mortar", "weapon_mortar_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Bouncing Betty HE", "weapon_mortar_betty");
   		Client::addMenuItem(%clientId, %curItem++ @ "Vertigo Bomb AB", "weapon_mortar_vertigo");
        //Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_EMPShell");
        Client::addMenuItem(%clientId, %curItem++ @ "Standard HE", "weapon_mortar_ImpactMortar");
        Client::addMenuItem(%clientId, %curItem++ @ "Smoke Bomb Shell", "weapon_mortar_smokebomb");
        return;
	}                                                //  Standard HE
    /////////////////////////////////////////
    //  Disc Launcher
    /////////////////////////////////////////
    else if (%opt == "weapon_DiscLauncher")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Disc Launcher", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_DiscLauncher_regular");
   		if($Meltdown::PowerDisc) Client::addMenuItem(%clientId, %curItem++ @ "Power Disc", "weapon_DiscLauncher_PowerDisc");
        if($Meltdown::PowerDisc2) Client::addMenuItem(%clientId, %curItem++ @ "Power Disc Output 2x", "weapon_DiscLauncher_PowerDisc2x");
        if($Meltdown::DiscShellMulti) Client::addMenuItem(%clientId, %curItem++ @ "Disc Shell Multi", "weapon_DiscLauncher_DiscShellMulti");
        //Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
   		return;
	}
    /////////////////////////////////////////
    //  Grenade Launcher
    /////////////////////////////////////////
    if (%opt == "weapon_GrenadeLauncher")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Grenade Launcher", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_GrenadeLauncher_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "RPG", "weapon_GrenadeLauncher_RPG");
        Client::addMenuItem(%clientId, %curItem++ @ "Implosion Shell", "weapon_GrenadeLauncher_ImplosionShell");
   		return;
	}
    /////////////////////////////////////////
    //  RailGun
    /////////////////////////////////////////
    if (%opt == "weapon_RailGun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "RailGun", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_RailGun_regular");
   		//Client::addMenuItem(%clientId, %curItem++ @ "XPower", "weapon_RailGun_XPower");
        if($Meltdown::RailGunEMP) Client::addMenuItem(%clientId, %curItem++ @ "EMP", "weapon_RailGun_EMP");
        //Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
   		return;
	}
    //========================================================================= Plasma Options
	if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
        Client::sendMessage(%clientId,0,"~wDryfire1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma set to Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
        Client::sendMessage(%clientId,0,"~wDryfire1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma set to Rapid-Bold.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
        Client::sendMessage(%clientId,0,"~wDryfire1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma set to Multi-Bold.\", 3);", 0);
   		return;
	}
    //========================================================================= Plasma Options
	if (%opt == "weapon_chaingun_regular")
	{
		%clientId.chaingun = 0;
        Client::sendMessage(%clientId,0,"~wDryfire1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun set to Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_chaingun_Gauss")
	{
		%clientId.chaingun = 1;
        Client::sendMessage(%clientId,0,"~wDryfire1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun set to Gauss.\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_MB_reg")
	{
		%clientId.Cannon = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Blast.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_haywire")
	{
		%clientId.Cannon = "1";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to EMP.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_booster")
	{
		%clientId.Cannon = "2";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Booster.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_poison")
	{
		%clientId.Cannon = "3";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Poisoning effects.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_heat")
	{
		%clientId.Cannon = "4";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Internal Flaming.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_ANIH")
	{
		%clientId.Cannon = "5";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Annihilation.\", 5);", 0);
   		return;
	}
    else if (%opt == "weapon_mortar_reg")
	{
		%clientId.mortar = "0";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to Standard Mortar Shell.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_betty")
	{
		%clientId.mortar = "1";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to Bouncing Betty.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_vertigo")
	{
		%clientId.mortar = "2";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to Vertigo Bomb.\", 5);", 0);
   		return;
	}
    else if (%opt == "weapon_mortar_EMPShell")
	{
		%clientId.mortar = "3";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to EMP Shell.\", 5);", 0);
   		return;
	}
    else if (%opt == "weapon_mortar_ImpactMortar")
	{
		%clientId.mortar = "4";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to Mortar HE.\", 5);", 0);
   		return;
	}
    if (%opt == "weapon_mortar_smokebomb")
	{
		%clientId.mortar = "5";
		Client::sendMessage(%clientId,0,"~wmortar_reload.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mortar set to (Smoke Bomb Shell) .\", 5);", 0);
   		return;
	}
    //====================== Disc Launcher  //======================
	if (%opt == "weapon_DiscLauncher_regular")
	{
		%clientId.DiscLauncher = 0;
        Client::sendMessage(%clientId,0,"~wdiscreload.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc Launcher set to (Standerd).\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_DiscLauncher_PowerDisc")
	{
		%clientId.DiscLauncher = 1;
        Client::sendMessage(%clientId,0,"~wdiscreload.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc Launcher set to (Power Disc) -AmmoUse = Two.\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_DiscLauncher_PowerDisc2x")
	{
		%clientId.DiscLauncher = 2;
        Client::sendMessage(%clientId,0,"~wdiscreload.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc Launcher set to (Power Disc TwoX) -AmmoUse = Five.\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_DiscLauncher_DiscShellMulti")
	{
		%clientId.DiscLauncher = 3;
        Client::sendMessage(%clientId,0,"~wdiscreload.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc Launcher set to (Disc Shell Multi) less damage per disc.\", 3);", 0);
   		return;
	}
    //====================== Grenade Launcher //======================
	if (%opt == "weapon_GrenadeLauncher_regular")
	{
		%clientId.GrenadeLauncher = 0;
        Client::sendMessage(%clientId,0,"~wturreton1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to (Standerd).\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_GrenadeLauncher_RPG")
	{
		%clientId.GrenadeLauncher = 1;
        Client::sendMessage(%clientId,0,"~wturreton1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to (RPG)\", 3);", 0);
   		return;
	}
    else if (%opt == "weapon_GrenadeLauncher_ImplosionShell")
	{
		%clientId.GrenadeLauncher = 2;
        Client::sendMessage(%clientId,0,"~wturreton1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to (Implosion Shell) -AmmoUse = Five.\", 3);", 0);
   		return;
	}
    //====================== RailGun  //======================
	else if (%opt == "weapon_RailGun_regular")
	{
		%clientId.RailGun = 0;
        Client::sendMessage(%clientId,0,"~wturreton1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>RailGun set to (Standerd).\", 5);", 0);
   		return;
	}
    if (%opt == "weapon_RailGun_EMP")
	{
		%clientId.RailGun = 1;
        Client::sendMessage(%clientId,0,"~wturreton1.wav");
        schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>RailGun set to (EMP) -AmmoUse = Two.\", 5);", 0);
   		return;
	}
    else if (%opt == "admenu")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Admin Menu", "options", true);
      	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      	Client::addMenuItem(%clientId, %curItem++ @ "Bioderm Options", "botmenu");
      	if($Server::TeamDamageScale == 1.0)
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD off", "dtd");
      	else
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD on", "etd");
	      if($Server::TourneyMode)
      	{
	         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
	         if(!$CountdownStarted && !$matchStarted)
      	      Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
	      }
	      else
	         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
	      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
	      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");

   			return;
	}
   else if(%opt == "botmenu")
   {
      Client::buildMenu(%clientId, "Choose Bioderm option:", "selbotaction", true);
      Client::addMenuItem(%clientId, "1Fabricate", "spawnbot");
      Client::addMenuItem(%clientId, "2Delete", "removebot");
     return;
   }
	else if (%opt == "deadmin")
	{
		Client::buildMenu(%clientId, "Confirm deadmin:", "daffirm", true);
		Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "kill")
	{
		cl.dan = false;
		Player::setArmor(%cl,larmor);
		armorChange(%cl);
		Player::blowUp(%cl);
		remoteKill(%cl);
		messageAll(0, Client::getName(%cl) @ " was being very naughty....");
		return;
	}
	else if(%opt == "dan") {
		%cl.dan = true;
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to mindlessly access his PDA by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav");
			Client::sendMessage(%cl, 1,"You've been forced to mindlessly access your PDA by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav");
		} else {
			MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been forced to mindlessly access her PDA by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav");
			Client::sendMessage(%cl, 1,"You've been forced to mindlessly access your PDA by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav");
		}
		echo(Client::getName(%cl) @ " has been forced to mindlessly access their PDA by " @ Client::getName(%clientId));
		doneposs(%cl);
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
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
   		dodance(%cl);

	%cl.safet = true;
	} else if(%opt == "undan") {
		%cl.dan = false;
		MessageAllExcept(%cl, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%cl) @ " to stop mindlessly access their PDA.");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to stop mindlessly access your PDA.");
		doneposs(%cl);
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		%cl.safet = false;
	}
	else if(%opt == "strip") {
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
	}
	else if(%opt == "poss") {
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to gain Meld - Player currently is not in control of themselves~waccess_denied.wav");
			Game::menuRequest(%clientId);
			return;
		}
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to Meld - You are currently not controlling your player~waccess_denied.wav");
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
		echo(Client::getName(%cl) @ " is being Mind Melded by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav");
		Client::sendMessage(%cl ,1,"You're being Mind Melded by " @ Client::getName(%clientId)@"!~wteleport2.wav");
	} else if(%opt == "unposs") {
		Client::setControlObject(%clientId, %clientId);
        Client::setControlObject(%cl, %cl);
		%cl.possessed = false;
		%cl.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been released of his Mind Meld by " @ Client::getName(%clientId) @ ".~wteleport2.wav");
		Client::sendMessage(%cl ,1,"You have been freed of your Mind Meld by " @ Client::getName(%clientId)@".~wteleport2.wav");
	}
	else if(%opt == "gag") {
		%cl.gag = true;
		echo(Client::getName(%cl) @ " got his voice taken away by " @ Client::getName(%clientId));
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " got his voice taken away by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
		Client::sendMessage(%cl, 1,"Your voice has been stolen by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
	} else if(%opt == "ungag") {
		%cl.gag = false;
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ "'s voice was returned by " @ Client::getName(%clientId) @ ".");
		Client::sendMessage(%cl ,1,"Your voice has returned to you by " @ Client::getName(%clientId)@".");
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
		centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f2>You currently have Duel Tournament Mode disabled.\n\nPress tab, click Miscellany... then click Enable Duel Mode.", 60); 
		$DuelAlive[%clientId] = false;
		return;
	} else {
		if($DuelStart) {
			$DuelAlive[%clientId] = false;
			centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f2>A tournament is currently in progress.\n\n<f1>Please wait for the tournament to be completed, then you will be able to join in.\n\nPress 'O' to learn how to play.", 60); 
		} else {
			$DuelAlive[%clientId] = true;
			if($matchStarted)
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
			else
				centerprint(%clientId, "<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu. Press 'O' to learn how to play.", 0); 
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

	centerprintall("<jc><f0>Welcome to Duel Tournament\n<f2>by [HvC]NaTeDoGG - http://havoc.sirris.com\n\n<f1>Choose your weapons from the TAB menu.\n\nPress 'O' to learn how to play.\n\n<f2>PRESS FIRE WHEN READY!", 0); 
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

function Server::onClientConnect(%clientId)
{
   %addr = Client::getTransportAddress(%clientId);

	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && ($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0)
		{
		   echo("AutoAdmining: " @ %clientId @ " \"" @
		      escapeString(Client::getName(%clientId)) @
		      "\" " @ Client::getTransportAddress(%clientId));
		      schedule("SHSayAutoAdmin(" @ %clientId @ ");", 20, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;
   }
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   DuelResetClient(%clientId);

   //if(Client::getName(%clientId) == "DaJackal")
      //schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>by [HvC]NaTeDoGG aka Nathan Sweet\n<f1>DUEL for Meltdown\n<f2>T H E  U L T I M A T E  M O D I F I C A T I O N\n<f1>http://havoc.sirris.com");
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

	%clientId.observerMode = "";
   Game::onPlayerConnected(%clientId);
      }
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

function remoteMissionChangeNotify(%serverManagerId, %nextMission) {
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

function MDHeadShot() // Defender
{
messageAll(0,"Head Shot!~wheadshot.wav");
//schedule("messageAll,\"Head Shot!~wheadshot.wav\");",0);
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{

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
      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	 		if (%cl.observerTarget == %shooterClient && %damagedClient != %shooterClient) {
	 			Client::SendMessage(%cl,0, Client::GetName(%shooterClient) @ " just harmed " @ Client::GetName(%damagedClient));
			}
		}       
	}   

	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

		Player::applyImpulse(%this,%mom);
		%friendFire = 1.0;	
//============================================================================= More Damage To Head Shots
       if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType || %type == $MethaneDamageType || %type == $SniperDamageType || %type == $RailgunDamageType || %type == $MaserDamageType) {
				if(%armor == "harmor") {
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.6);
					}
				}
				else {
					%value += (%value * 0.3);
                     MDHeadShot();
                  }
			}
//===================================Shield Pack On
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
					if(%dlevel >= 0.57) {                                                         
						%foeId = $Dueling[%damagedClient];
						if(%foeId.lastsound < getSimTime()) {
							%foeId.lastsound = getSimTime() + 8;
							if (Client::GetGender(%damagedClient) == "Female")
								Client::sendMessage(%foeId, 0, "~wduelfinisher.wav");
							else
								Client::sendMessage(%foeId, 0, "~wduelfinishim.wav");
						}
					}
				}
				else {
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

function SHSayAutoAdmin(%clientid)
{
	BottomPrint(%clientid,"<F1><jc>You have been chosen by <f0>" @ $CurAdminName @ "<f1> to be Auto-Admined.",5);
}

function SHCheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);

	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && ($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0)
		{
		   echo("AutoAdmining: " @ %clientId @ " \"" @
		      escapeString(Client::getName(%clientId)) @
		      "\" " @ Client::getTransportAddress(%clientId));
		      schedule("SHSayAutoAdmin(" @ %clientId @ ");", 20, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;
		      //%clientId.isLevel1 = true;
		     // %clientId.isIsOldDynaBlade = true;
		}
	}
}


echo("*****************************************");
echo("Duel Tournament for BASE servers, by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("*****************************************");
