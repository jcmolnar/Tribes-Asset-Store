exec(objectives);
exec("DuelRecord.cs");
if(!$Duel::RecordTime) $Duel::RecordTime = 9999;
$DuelBestTime = 9999;

$DuelSpotTaken[1] = false;
$DuelSpotTaken[2] = false;
$DuelSpotTaken[3] = false;
$DuelSpotTaken[4] = false;
$DuelSpotTaken[5] = false;
$DuelSpotTaken[6] = false;
$DuelSpotTaken[7] = false;
$DuelSpotTaken[8] = false;
$DuelSpotTaken[9] = false;
$DuelSpotTaken[10] = false;
$DuelSpotTaken[11] = false;
$DuelSpotTaken[12] = false;

$DuelDelayTime = 4;
$DuelHurtDelay = 1.9;

$DuelWeaponMax = 15;
$DuelPackMax = 4;

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
			CenterPrint(%clientId,"<jc><f2>READY!",2);
			CenterPrint(%foeId,"<jc><f2>READY!",2);
		} else {
			BottomPrint(%clientId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
			BottomPrint(%foeId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
		}
	}         
	schedule("DuelCountdown(" @ %clientId @ "," @ %foeId @ "," @ (%timeLeft - 1) @ "," @ %clientPl @ "," @ %foePl @ ");", 1);
}                                     

function DuelResetClient(%clientId) {
	$Dueling[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
	$DuelWeaponSetup[%clientId, 0] = 0;
	$DuelWeaponSetup[%clientId, 1] = 0;
	$DuelWeaponSetup[%clientId, 2] = 0;
    //$DuelWeaponSetup[%clientId, 3] = 0; //
	//$DuelWeaponSetup[%clientId, 4] = 0; //
	//$DuelWeaponSetup[%clientId, 5] = 0; // new
    $DuelPack[%clientId] = "";
   	$HighStreak[%clientId] = 0;
   	setHigh(%clientId);
   	$DuelStreak[%clientId] = 0;
	$DuelModeOff[%clientId] = false;
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
	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	Client::sendMessage(%clientId, 0, "~wduelfight.wav");
	Client::sendMessage(%foeId, 0, "~wduelfight.wav");
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

	$DuelStartTime[$DuelSpotIndex[%clientId]] = getSimTime();

}

function PlayersOutOfAmmo(%clientId, %foeId) {
	if ($Dueling[%clientId] == %foeId && $Dueling[%foeId] == %clientId) {
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

function Player::leaveMissionArea(%player) { }

function FinalizeDuel(%clientId, %foeId) {
	$Dueling[%clientId] = false;
	$Dueling[%foeId] = false;

	ClearMines(%clientId);
	ClearMines(%foeId); 

	%clientId.guiLock = false;
	%foeId.guiLock = false;

	$DuelSpawnMarker[%clientId] = "";
	$DuelSpawnMarker[%foeId] = "";

	$DuelSpotTaken[$DuelSpotIndex[%clientId]] = false;
	$DuelSpotIndex[%clientId] = "";
	$DuelSpotIndex[%foeId] = "";

	Observer::enterObserverMode(%clientId);
	Observer::enterObserverMode(%foeId);

	Game::refreshClientScore(%clientId);
	Game::refreshClientScore(%foeId);
}                                                 

function formattedbest(%secs) {
	if(%secs == 9999)
		return escapestring("00:00");
	%mins = floor(%secs / 60);
	if(%mins < 0)
		%mins = -%mins;
	%secs = floor(%secs - (%mins * 60));
	if(%secs < 0)
		%secs = -%secs;
	if(%mins < 10)
		%str = "0" @ %mins @ ":";
	else
		%str = %mins @ ":";
	if(%secs < 10)
		%str = %str @ "0" @ %secs;
	else
		%str = %str @ %secs;
	return escapestring(%str);
}

function setT(%clientId, %foeId, %t) {
	if(%t > 0 && getNumClients() > 4 && Client::getName(%clientId) != "" && Client::getName(%foeId) != "") {
		if(%t < $Duel::RecordTime) {
			schedule("messageall(0, \"" @ escapeString(Client::getName(%foeId)) @ " set a new fastest win record!~wCapturedTower.wav\");", 1.5);
	        $Duel::RecordTimeHolder = Client::getName(%foeId);
	        $Duel::RecordTimeLoser = Client::getName(%clientId);
			$Duel::RecordTime = %t;
	        export("$Duel::Record*", "config\\DuelRecord.cs", False);
		}
		if(%t < $DuelBestTime) {
	        $DuelBestTimeHolder = Client::getName(%foeId);
	        $DuelBestTimeLoser = Client::getName(%clientId);
			$DuelBestTime = %t;
		}
	}
}

function EndDuel(%clientId, %damageType) {
	%foeId = $Dueling[%clientId];
	if ($Dueling[%clientId] && $DuelCanHurt[%clientId]) {   
		%t = getSimTime() - $DuelStartTime[$DuelSpotIndex[%clientId]];
		setT(%clientId, %foeId, %t);
		if(%t > 0 && %t < $DuelBest[%foeId]) {
			$DuelBest[%foeId] = %t;
			$DuelBestDisplay[%foeId] = formattedbest(%t);
		}
		%t = formattedbest(%t);

		$DuelCanHurt[%clientId] = false;
		$DuelCanHurt[%foeId] = false;

		%foeId.score++;
		$DuelStreak[%foeId]++;

		%clientId.scoreDeaths++;

		if(%damageType != -2) playASound(%clientId, %foeId);

		setHigh(%clientId);
		$DuelStreak[%clientId] = 0;

		MessageAll(1,Client::GetName(%foeId) @ " has triumphed over " @ Client::GetName(%clientId) @ "! (" @ %t @ ")");
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

	} else if ($Dueling[%clientId] && !$DuelCanHurt[%clientId]) {
		Client::sendMessage(%clientId, 1, Client::GetName(%clientId) @ " has ended the duel prior to start.~werror_message.wav"); 
		Client::sendMessage(%foeId, 1, Client::GetName(%clientId) @ " has ended the duel prior to start.~werror_message.wav"); 
		FinalizeDuel(%clientId, %foeId);
	}
	
}        

function Vote::changeMission() {
   $timeLimitReached = true;
   $timeReached = true;
   DuelMOD::missionObjectives();
}

function CheckDuelTime(%clientId,%foeId, %timeLeft) {                       
	if ($DuelLineup[%clientId] != %foeId) return;
	if (%timeLeft == 0) {
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " did not accept the duel in time.~waccess_denied.wav");
		return;
	} 
	if ($Dueling[%foeId] && $Dueling[%foeId] != %clientId) {
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " has accepted a duel with somebody else.~waccess_denied.wav");
		return;
	} 
	if (Client::GetName(%foeId) == "") {
		$DuelLineup[%clientId] = "";      
		return;
	} 
	if (Client::GetName(%clientId) == "") {
		$DuelLineup[%clientId] = "";
		return;
	}
	schedule("CheckDuelTime(" @ %clientId @ ", " @ %foeId @ ", " @ (%timeLeft - 3) @ ");",3);
}
                                                                              
function DuelPropose(%clientId,%foeId,%again) {                                     
	if (%foeId == %clientId) {
		client::sendmessage(%clientId,0,"You can't duel yourself!~werror_message.wav");
		return;
	}
	if ($Dueling[%clientId]) {
		client::sendmessage(%clientId,0,"Hello!? You're already in a duel!~werror_message.wav");
		return;
	}
	if (!%foeId || %foeId == 0 || Client::GetName(%foeId) == "") {
		Client::SendMessage(%clientId,0,"That person is not in the game.~waccess_denied.wav");
		return;
	}
	if ($Dueling[%foeId]) {
		client::sendmessage(%clientId,0, Client::GetName(%foeId) @ " is currently in a duel. Try again later.~waccess_denied.wav");
		return;
	}
	if($DuelModeOff[%foeId]) {
		Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " currently has duels disabled.~waccess_denied.wav");
		return;
	}
	if ($DuelLineup[%foeId] == %clientId) {
		DuelInit(%clientId, %foeId);
		return;
	}
	$DuelLineup[%clientId] = %foeId;
	Client::sendMessage(%clientId,0,Client::GetName(%foeId) @ " has 30 seconds to accept the duel.");
	CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a duel.", 8);
	Client::sendMessage(%foeId,0,"You have 30 seconds to accept a duel from " @ Client::GetName(%clientId) @ ".");
	CheckDuelTime(%clientId, %foeId, 30);
	if(%again && $DuelStreak[%foeId] > 5) {
		client::sendMessage(%clientId, 0, "~wduelagain.wav");
		client::sendMessage(%foeId, 0, "~wduelagain.wav");
	}
	return;
}                


function DuelInit(%clientId, %foeId) {
	MessageAll(0, Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " are about to duel!");
	%spotTaken = true;
	%ii = 0;   
	while (%spotTaken) {
		%ii++;
		if (%ii > 60) {
			Client::SendMessage(%clientId,0,"No duel spawn spots are vacant. Try again when a duel finishes.~waccess_denied.wav");
			Client::SendMessage(%foeId,0,"No duel spawn spots are vacant. Try again when a duel finishes.~waccess_denied.wav");
			$DuelLineup[%clientId] = "";
			$DuelLineup[%foeId] = "";
			$Dueling[%clientId] = "";
			$Dueling[%foeId] = "";
			return;
		}
		%i = floor(getRandom() * 12) + 1;
		if (!$DuelSpotTaken[%i]) {                                                  
			$DuelSpotIndex[%clientId] = %i;
			$DuelSpotIndex[%foeId] = %i;
			%group = nameToID("MissionGroup/Duel" @ %i);
		   	%count = Group::objectCount(%group);
			$DuelSpawnMarker[%clientId] = Group::getObject(%group, 0);
			$DuelSpawnMarker[%foeId] = Group::getObject(%group, 1);
			$DuelSpotTaken[%i] = true;
			%spotTaken = false;
		}
	}         
	%clientId.observerMode = "";
	%foeId.observerMode = "";
	%foeId.observerTarget = "";
	%clientId.observerTarget = "";
	%clientId.guiLock = true;
	%foeId.guiLock = true;
	Client::setGuiMode(%clientId, $GuiModePlay);
	Client::setGuiMode(%foeId, $GuiModePlay);

	$DuelLineup[%clientId] = "";
	$DuelLineup[%foeId] = "";
	$Dueling[%clientId] = %foeId;
	$Dueling[%foeId] = %clientId;
	$DuelLastEnemy[%clientId] = %foeId;
	$DuelLastEnemy[%foeId] = %clientId;

	Game::refreshClientScore(%clientId);	
	Game::refreshClientScore(%foeId);	
		
	%clientPl = DuelSpawn(%clientId);
	%foePl = DuelSpawn(%foeId);                                  
	LockPlayers(%clientId, %foeId, %clientPl, %foePl);

	if($DuelSpotIndex[%clientId] <= 8) {
		GameBase::SetTeam(%clientId, $DuelSpotIndex[%clientId] - 1);
		GameBase::SetTeam(%clientPl, $DuelSpotIndex[%clientId] - 1);
		GameBase::SetTeam(%foeId, $DuelSpotIndex[%foeId] - 1);
		GameBase::SetTeam(%foePl, $DuelSpotIndex[%foeId] - 1);
	} else {
		GameBase::SetTeam(%clientId, $DuelSpotIndex[%clientId] - 9);
		GameBase::SetTeam(%clientPl, $DuelSpotIndex[%clientId] - 9);
		GameBase::SetTeam(%foeId, $DuelSpotIndex[%foeId] - 9);
		GameBase::SetTeam(%foePl, $DuelSpotIndex[%foeId] - 9);
	}
	Player::setDetectParameters(%clientPl, 0, 300);
	Player::setDetectParameters(%foePl, 0, 300);

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
		if (Client::GetTeam(%cl) == -1) {
			if (%cl.observerTarget == %clientId)
				Observer::setTargetClient(%cl, %clientId);
			else if (%cl.observerTarget == %foeId)                 
				Observer::setTargetClient(%cl, %foeId);
		}
	}		

	$DuelCanHurt[%clientId] = false;
	$DuelCanHurt[%foeId] = false;               
	DuelCountdown(%clientId, %foeId, 7, %clientPl, %foePl);
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

		if(%sel != %clientId && $DuelLineup[%clientId] != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Request Duel", "duel " @ %sel);
		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin) {
         //==========================================
         // Vote to admin Removed by defender
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         //
         //==========================================
         // Removed by defender this was becomeing a problem
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
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
					Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Status", "removeadmin " @ %sel);
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
	  
	if (!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId])
		Client::addMenuItem(%clientId, %curItem++ @ "Request Last Duel", "rerequest " @ $DuelLastEnemy[%clientId]);
    Client::addMenuItem(%clientId, %curItem++ @ "Buy Your Duel Weapons", "weaponsetup");
	Client::addMenuItem(%clientId, %curItem++ @ "Buy Your Packs", "packsetup");

	if (!$Dueling[%clientId]) {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
			if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
				%num++;
		}
		if(%num == 1) {
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
				if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
					Client::addMenuItem(%clientId, %curItem++ @ "Accept duel: " @ Client::GetName(%cl), "acceptduel " @ %cl);
			}
		} else if(%num > 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Accept a duel...", "viewduels");
	}

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
		return;
	}
	WeaponSetup(%cl, %num, 0);
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
	return;
}

function hvcAdminMsg(%msg) { 
	echo("SERVER: " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) { 
		%pl = getClientByIndex(%i); 
		if(%pl.isSuperAdmin) { 
			Client::sendMessage(%pl, 0, %msg); 
		} 
	} 
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
		Client::addMenuItem(%clientId, %i++ @ "Observer Mode", "obsm"); 
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
	if (%opt == "viewduels") {
		Client::buildMenu(%clientId, "Select a player to duel:", "Options", true);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
				Client::addMenuItem(%clientId, %curItem++ @ Client::GetName(%cl), "acceptduel " @ %cl);
		return;
	}
	if (%opt == "rerequest") {
		DuelPropose(%clientId, %cl, true);
		return;
	}
	if (%opt == "acceptduel") {
		if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId) {
			DuelPropose(%clientId, %cl, false);
			return;
		} else {
			Client::SendMessage(%clientId, 0, Client::GetName(%cl) @ " is no longer requesting a duel.~waccess_denied.wav");
			return;
		}
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
	if(%opt == "duel") { 
		DuelPropose(%clientId, %cl, false);
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
      %doIt = "";
      for(%i= 0 ; %i < %numClients; %i++) {
         if($HighStreak[%clientList[%i]] < $HighStreak[%clientList[%i+1]]) {
            %hold = %clientList[%i];
            %clientList[%i] = %clientList[%i+1];
            %clientList[%i+1]= %hold;
            %doIt=1;
         }
      }
   }      

	%topstreak = $HighStreak[%clientList[0]];
	if(%topstreak > 2) {
		if($HighStreak[%clientList[1]] == $HighStreak[%clientList[0]]) {
			if($HighStreak[%clientList[1]] == $HighStreak[%clientList[2]]) {
				if($HighStreak[%clientList[2]] == $HighStreak[%clientList[3]]) {
					%msg = "tied";
				} else {
					%msg = Client::getName(%clientList[0]) @ ", " @ Client::getName(%clientList[1]) @ ", and " @ Client::getName(%clientList[2]);
				}
			} else {
				%msg = Client::getName(%clientList[0]) @ " and " @ Client::getName(%clientList[1]);
			}
			%tied = true;
		} else
			%msg = Client::getName(%clientList[0]);
	}

   for(%i = 0 ; %i < %numClients ; %i++) 
      %clientList[%i] = getClientByIndex(%i);
   %doIt = 1;
   while(%doIt == 1)
   {
      %doIt = "";
      for(%i= 0 ; %i < %numClients; %i++)
      {
         if((%clientList[%i]).score < (%clientList[%i+1]).score)
         {
            %hold = %clientList[%i];
            %clientList[%i] = %clientList[%i+1];
            %clientList[%i+1]= %hold;
            %doIt=1;
         }
      }
   }      
	%topscore = %clientList[0].score;
	if(%topscore > 1) {
		if(%clientList[1].score == %clientList[0].score) {
			if(%clientList[1].score == %clientList[2].score) {
				if(%clientList[2].score == %clientList[3].score) {
					%mmsg = "tied";
				} else {
					%mmsg = Client::getName(%clientList[0]) @ ", " @ Client::getName(%clientList[1]) @ ", and " @ Client::getName(%clientList[2]);
				}
			} else {
				%mmsg = Client::getName(%clientList[0]) @ " and " @ Client::getName(%clientList[1]);
			}
			%ttied = true;
		} else
			%mmsg = Client::getName(%clientList[0]);
	}

	if($timeReached) {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			setHigh(%cl);
			$DuelStreak[%cl] = 0;
			GameBase::setTeam(%cl, -1);
		}
	 	for (%x = -1; %x < 8; %x++) {
			//messageall(0, "final " @ %x);
	 	   	%lineNum = 0;
	 		Team::setObjective(%x, %lineNum++, "<jc><f5>Final Duel Statistics");
	  	  	Team::setObjective(%x, %lineNum++, " ");
	    		Team::setObjective(%x, %lineNum++, "<f1>Most wins:");
	 	   	if(%topscore > 1) {
	 			if(%ttied) {
	 				if(%mmsg == "tied")
	 					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>It ended in a tie at " @ %topscore @ " wins!");
	 				else
	 					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>" @ %mmsg @ " tied with " @ %topscore @ " wins!");
	 			} else
	 				Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>" @ %mmsg @ " with " @ %topscore @ " wins!");
	 	   	} else
	 	   		Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>None");
	 		Team::setObjective(%x, %lineNum++, "<f1>Longest Winning Streak:");
	 		if(%topstreak > 2) {
	 			if(%tied) {
	 				if(%msg == "tied")
	 					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>It ended in a tie at " @ %topstreak @ " wins in a row!");
	 				else
	 					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>It ended with " @ %msg @ " tied at " @ %topstreak @ " wins in a row!");
	 			} else
	 				Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>" @ %msg @ " with " @ %topstreak @ " wins in a row!");
	 		} else
	 			Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>None");
			if($DuelBestTime != 9999) {
				Team::setObjective(%x, %lineNum++, "<f1>Fastest Win:");
	 			Team::setObjective(%x, %lineNum++, "<L14><f5><Bflag_enemycaptured.bmp>" @ $DuelBestTimeHolder @ " beat " @ $DuelBestTimeLoser @ " in " @ formattedbest($DuelBestTime));
			}
	 		if($Duel::RecordNum > 0) {
				Team::setObjective(%x, %lineNum++, "<f1>Winning Streak Record: <Bskull_small.bmp><f0>" @ $Duel::RecordHolder @ " with " @ $Duel::RecordNum @ " wins in a row!");
	 		}
	 		if($Duel::RecordTime != 9999) {
				Team::setObjective(%x, %lineNum++, "<f1>Fastest Win Record: <Bskull_small.bmp><f0>" @ $Duel::RecordTimeHolder @ " beat " @ $Duel::RecordTimeLoser @ " in " @ formattedbest($Duel::RecordTime));
	 		}
	 	   	Team::setObjective(%x, %lineNum++, " ");
			Team::setObjective(%x, %lineNum++, "<L36>Kills\t\tDeaths\t\tRatio\t\tStreak\t\tFastest Win");					 
			%c = 0;
			while(%c < %numClients) {
				(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);
	 			Team::setObjective(%x, %lineNum++, "<L2><f2>"@(%c + 1) @ ". " @ Client::getName(%clientList[%c]) @ "<L36><f0>" @ (%clientList[%c]).score @ "\t\t\t" @ (%clientList[%c]).ScoreDeaths @ "\t\t\t\t" @ (%clientList[%c]).ratio @ "%\t\t\t" @ $HighStreak[%clientList[%c]] @ "\t\t\t\t" @ $DuelBestDisplay[%clientList[%c]]);
				%c++;
			}  
	 	   	for(%s = %lineNum + 1; %s < 30 ; %s++)
	 	 		Team::setObjective(%x, %s, " ");
	 	}
	} else {
		for (%x = -1; %x < 2; %x++) {
			//messageall(0, "normal " @ %x);
		   	%lineNum = 0;
			Team::setObjective(%x, %lineNum++, "<jc><f5>Duel Statistics");
			Team::setObjective(%x, %lineNum++, "<f1>Mission Name: " @ $missionName); 
	 	  	Team::setObjective(%x, %lineNum++, "<f1>Mission Objectives:");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   -Duel other players!");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   -Try to get the most wins, the longest winning streak, or the fastest win!");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   -You cannot damage your opponent for the first second of the battle. No cheap shots!");
			Team::setObjective(%x, %lineNum++, " ");
			Team::setObjective(%x, %lineNum++, "<f1>Use the TAB menu to select your weapons and pack loadout, then select a player on the TAB menu and request a duel. Fight to the death.");
	 	  	Team::setObjective(%x, %lineNum++, " ");
	   		Team::setObjective(%x, %lineNum++, "<f1>Most wins:");
		   	if(%topscore > 1) {
				if(%ttied) {
					if(%mmsg == "tied")
						Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>It is tied at " @ %topscore @ " wins!");
					else
						Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>" @ %mmsg @ " are tied with " @ %topscore @ " wins!");
				} else
					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>" @ %mmsg @ " with " @ %topscore @ " wins!");
		   	} else
		   		Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>None");
	 		Team::setObjective(%x, %lineNum++, "<f1>Longest Winning Streak:");
			if(%topstreak > 2) {
				if(%tied) {
					if(%msg == "tied")
						Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>\nIt is tied at " @ %topstreak @ " wins in a row!");
					else
						Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ %msg @ " are tied at " @ %topstreak @ " wins in a row!");
				} else
					Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ %msg @ " with " @ %topstreak @ " wins in a row!");
			} else
				Team::setObjective(%x, %lineNum++, "<L14><f5><Bskull_big.bmp>\nNone");
			if($DuelBestTime != 9999) {
				Team::setObjective(%x, %lineNum++, "<f1>Fastest Win:");
	 			Team::setObjective(%x, %lineNum++, "<L14><f5><Bflag_enemycaptured.bmp>" @ $DuelBestTimeHolder @ " beat " @ $DuelBestTimeLoser @ " in " @ formattedbest($DuelBestTime));
			}
	 		if($Duel::RecordNum > 0) {
				Team::setObjective(%x, %lineNum++, "<f1>Winning Streak Record: <Bskull_small.bmp><f0>" @ $Duel::RecordHolder @ " with " @ $Duel::RecordNum @ " wins in a row!");
	 		}
	 		if($Duel::RecordTime != 9999) {
				Team::setObjective(%x, %lineNum++, "<f1>Fastest Win Record: <Bskull_small.bmp><f0>" @ $Duel::RecordTimeHolder @ " beat " @ $Duel::RecordTimeLoser @ " in " @ formattedbest($Duel::RecordTime));
	 		}
		   	Team::setObjective(%x, %lineNum++, " ");
			Team::setObjective(%x, %lineNum++, "<L36>Kills\t\tDeaths\t\tRatio\t\tStreak\t\tFastest Win");					 
			%c = 0;
			while(%c < %numClients) {
				(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);
	 			Team::setObjective(%x, %lineNum++, "<L2><f2>"@(%c + 1) @ ". " @ Client::getName(%clientList[%c]) @ "<L36><f0>" @ (%clientList[%c]).score @ "\t\t\t" @ (%clientList[%c]).ScoreDeaths @ "\t\t\t\t" @ (%clientList[%c]).ratio @ "%\t\t\t" @ $DuelStreak[%clientList[%c]] @ "\t\t\t\t" @ $DuelBestDisplay[%clientList[%c]]);
				%c++;
			}  
		   	for(%s = %lineNum+1; %s < 30 ;%s++)
		 		Team::setObjective(%x, %s, " ");
		}
	}
   $timeReached = false;
}

function Game::refreshClientScore(%clientId) {
	%team = 3;
	if($Dueling[%clientId]) {
		%flag = "Yes"; 
		%team = 2;
	} else {
		if($DuelModeOff[%clientId]) {
			%flag = "Off";
			%team = 1;
		} else
			%flag = "No";
	}
   Client::setScore(%clientId, "%n\t" @ %flag @ "\t" @ %clientId.score  @ "\t%p\t%l", %team);
   DuelMOD::missionObjectives();
}

function Game::initialMissionDrop(%clientId) {  

	%clientId.observerMode = "";
   	Client::setGuiMode(%clientId, $GuiModePlay);

	$Dueling[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
   	$HighStreak[%clientId] = 0;
   	setHigh(%clientId);
   	$DuelStreak[%clientId] = 0;
	$DuelBest[%clientId] = 9999;
	$DuelBestDisplay[%clientId] = "00:00";

	Observer::enterObserverMode(%clientId);
    Game::refreshClientScore(%clientId);

   	%clientId.justConnected = "";
	centerprint(%clientId, "<jc><f2>Press tab and select a player to duel!!!\n\n<f1>" @ $Server::JoinMOTD @ "\n\n<jc><f2>Press tab and select a player to duel!!!", 12);

	%clientId.guiLock = false;

}

function Game::startMatch() {       
   	$matchStarted = true;
   	$missionStartTime = getSimTime();
   	messageAll(0, "Match started.");
   	Game::resetScores();	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
   		$Dueling[%cl] = "";
		$DuelLineup[%cl] = "";
		$DuelLastEnemy[%cl] = "";
		$HighStreak[%cl] = 0;
		$DuelStreak[%cl] = 0;
		%cl.score = 0;
   	  	Game::refreshClientScore(%cl);
   	}
   Game::checkTimeLimit();
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

function remoteMissionChangeNotify(%serverManagerId, %nextMission) {
   if(%serverManagerId == 2048) {
      //cls();
      echo("Server mission complete - changing to mission: ", %nextMission);
      //echo("Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
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

function setHigh(%clientId) {
	if($DuelStreak[%clientId] > 2 && $DuelStreak[%clientId] > $Duel::RecordNum && (getNumClients() > 4) && Client::getName(%clientId) != "") {
		schedule("messageall(0, \"" @ escapeString(Client::getName(%clientId)) @ "'s record breaking winning streak of " @ $DuelStreak[%clientId] @ " wins has come to an end!~wCapturedTower.wav\");", 1.5);
        $Duel::RecordHolder = Client::getName(%clientId);
		$Duel::RecordNum = $DuelStreak[%clientId];
        export("$Duel::Record*", "config\\DuelRecord.cs", False);
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
	if ($Dueling[%clientId]) {
   		Client::sendMessage($Dueling[%clientId], 1, Client::GetName(%clientId) @ " has left the game.  Aborting Duel.~werror_message.wav");
   		FinalizeDuel(%clientId, $Dueling[%clientId]);
   	}                         
	
	DuelResetClient(%clientId); 

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
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
   $timeReached = false;

   	if(!$Server::timeLimit)  {
		DuelMOD::missionObjectives();
      	schedule("Game::checkTimeLimit();", 60);
      	return;
   	}

   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: timelimit");
      $timeReached = true;
      DuelMOD::missionObjectives();
      %set = nameToID("MissionCleanup/ObjectiveSet");
      for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
         GameBase::virtual(%obj, "timeLimitReached", %clientId);
      Server::nextMission();
   } else {
      DuelMOD::missionObjectives();
      if(%curTimeLeft >= 20)
         schedule("Game::checkTimeLimit();", 20);
      else
         schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Mission::init() {                     
   	setClientScoreHeading("Player Name\t\x6FDueling\t\xA6Kills\t\xCFPing\t\xEFPL");
   	setTeamScoreHeading("");

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	  	%cl.scoreDeaths = 0;
      	%cl.score = 0;
		Observer::enterObserverMode(%cl);
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
   	DuelMOD::missionObjectives();
	$SensorNetworkEnabled = true;
}

function Game::playerSpawn(%clientId, %respawn) {
}
          
function Client::onKilled(%playerId, %killerId, %damageType) {
   	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
   	%playerId.guiLock = true;
   	Client::setGuiMode(%playerId, $GuiModePlay);
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
	return;
}

function playASound(%clientId, %foeId) {
	if (Gamebase::GetDamageLevel(Client::GetOwnedObject(%foeId)) == 0) {
		%s[0, 0] = "flawless";
		%s[1, 0] = "flawless";
		if($DuelStreak[%foeId] > 1) {
			%s[0, 1] = "fatality";
			%s[1, 1] = "fatality";
			%sid = 2;
		} else 
			%sid = 1;
		if(floor(getRandom() * 10) > 5) {
			if(floor(getRandom() * 10) > 5) {
				%s[0, %sid] = "welldone";
				%s[1, %sid] = "welldone";
			} else {
				%s[0, %sid] = "superb";
				%s[1, %sid] = "superb";
			}
		} else {
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, %sid] = "outstanding";
					%s[1, %sid] = "outstanding";
				} else {
					%s[0, %sid] = "toasty";
					%s[1, %sid] = "toasty";
				}
			} else {
				%s[0, %sid] = "excellent";
				%s[1, %sid] = "excellent";
			}
		}
	} else if ($DuelStreak[%foeId] > 4 || $DuelStreak[%clientId] > 8) {
		if(floor(getRandom() * $DuelStreak[%foeId]) > 2 || $DuelStreak[%clientId] > 8) { 
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, 0] = "welldone";
					%s[1, 0] = "welldone";
				} else {
					%s[0, 0] = "outstanding";
					%s[1, 0] = "outstanding";
				}
			} else {
				if(floor(getRandom() * 10) > 5) { 
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "superb";
						%s[1, 0] = "superb";
					} else {
						%s[0, 0] = "toasty";
						%s[1, 0] = "toasty";
					}
				} else {
					%s[0, 0] = "excellent";
					%s[1, 0] = "excellent";
				}
			}
			if(floor(getRandom() * 10) > 4) { 
				%s[0, 1] = "fatality";
				%s[1, 1] = "fatality";
			}
		}
	} else {
		if(floor(getRandom() * 15) == 10) { 
			if(floor(getRandom() * 10) > 5) { 
				if(floor(getRandom() * 10) > 5) { 
					%s[0, 0] = "outstanding";
					%s[1, 0] = "outstanding";
				} else {
					%s[0, 0] = "superb";
					%s[1, 0] = "superb";
				}
			} else {							
				if(floor(getRandom() * 10) > 5) { 
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "welldone";
						%s[1, 0] = "welldone";
					} else {
						%s[0, 0] = "excellent";
						%s[1, 0] = "excellent";
					}
				} else {
					if(floor(getRandom() * 10) > 5) { 
						%s[0, 0] = "fatality";
						%s[1, 0] = "fatality";
					} else {
						%s[0, 0] = "toasty";
						%s[1, 0] = "toasty";
					}
				}
			}
		}
	}
	for(%ii = 0; %ii <= 2; %ii++)
		if(%s[0, %ii] != "")
			schedule("Client::sendMessage("@%foeId@",0,\"~wduel" @ %s[0, %ii] @ ".wav\");", ((1.4*%ii)+1));
	for(%ii = 0; %ii <= 2; %ii++)
		if(%s[1, %ii] != "")
			schedule("Client::sendMessage("@%clientId@",0,\"~wduel" @ %s[1, %ii] @ ".wav\");", ((1.4*%ii)+1));
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
echo("Duel MOD for BASE servers, by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("*****************************************");
