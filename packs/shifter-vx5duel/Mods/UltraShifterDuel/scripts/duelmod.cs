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
$DuelSpotTaken[13] = false;
$DuelSpotTaken[14] = false;
$DuelSpotTaken[15] = false;
$DuelSpotTaken[16] = false;
$DuelSpotTaken[17] = false;
$DuelSpotTaken[18] = false;
$DuelSpotTaken[19] = false;
$DuelSpotTaken[20] = false;
                       
$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;
                            
$DuelWeapon[1] = "Rocket Launcher";		$DuelRealWeapon[1] = RocketLauncher;		$DuelWeaponAmmo[1] = RocketAmmo;
$DuelWeapon[2] = "Mortar";					$DuelRealWeapon[2] = Mortar;					$DuelWeaponAmmo[2] = MortarAmmo;
$DuelWeapon[3] = "Plasma Gun";			$DuelRealWeapon[3] = PlasmaGun;				$DuelWeaponAmmo[3] = PlasmaAmmo;
$DuelWeapon[4] = "Shockwave Cannon";	$DuelRealWeapon[4] = ConCun;
$DuelWeapon[5] = "Disc Launcher";		$DuelRealWeapon[5] = DiscLauncher;			$DuelWeaponAmmo[5] = DiscAmmo;
$DuelWeapon[6] = "Grenade Launcher";	$DuelRealWeapon[6] = GrenadeLauncher;		$DuelWeaponAmmo[6] = GrenadeAmmo;
$DuelWeapon[7] = "Vulcan";					$DuelRealWeapon[7] = Vulcan;					$DuelWeaponAmmo[7] = VulcanAmmo;
$DuelWeapon[8] = "Equalizer";				$DuelRealWeapon[8] = Chaingun;				$DuelWeaponAmmo[8] = BulletAmmo;
$DuelWeapon[9] = "ELF Gun";				$DuelRealWeapon[9] = EnergyRifle;
$DuelWeapon[10] = "Rail Gun";				$DuelRealWeapon[10] = Railgun;			$DuelWeaponAmmo[10] = RailAmmo;
$DuelWeapon[11] = "Silencer";				$DuelRealWeapon[11] = Silencer;			$DuelWeaponAmmo[11] = SilencerAmmo;
$DuelWeapon[12] = "Boom Stick";				$DuelRealWeapon[12] = BoomStick;		$DuelWeaponAmmo[12] = BoomAmmo;
$DuelWeapon[13] = "Grav Gun";				$DuelRealWeapon[13] = GravGun;			
$DuelWeapon[14] = "Sniper Rifle";				$DuelRealWeapon[14] = SniperRifle;		$DuelWeaponAmmo[14] = SniperAmmo;

$DuelWeaponMax = 14;

$DuelPack[1] = "Rocket Pack";	$DuelRealPack[1] = SMRPack;
$DuelPack[2] = "Energy Pack";	$DuelRealPack[2] = EnergyPack;
$DuelPack[3] = "Shield Pack";	$DuelRealPack[3] = ShieldPack;
$DuelPack[4] = "Ammo Pack";	$DuelRealPack[4] = AmmoPack;
$DuelPack[5] = "Repair Pack";	$DuelRealPack[5] = RepairPack;
$DuelPack[6] = "Flight Pack";	$DuelRealPack[5] = FlightPack;
$DuelPackMax = 6;

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
	$DuelCanHurt[%clientId] = true;
	$DuelCanHurt[%foeId] = true;
  	Player::SetItemCount(%clientId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%foeId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%clientId, RocketAmmo, 0);
  	Player::SetItemCount(%foeId, RocketAmmo, 0);
	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	Client::sendMessage(%clientId, 0, "~wduelfight.wav");
	Client::sendMessage(%foeId, 0, "~wduelfight.wav");
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

	$DuelStartTime[$DuelSpotIndex[%clientId]] = getSimTime();

}

function PlayersOutOfAmmo(%clientId, %foeId) {
	if ($Dueling[%clientId] == %foeId && $Dueling[%foeId] == %clientId) {
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
	%clientId.dead = "";
	%foeId.dead = "";
	%clientId.lastmdm = "";
	%foeId.firemortar = "";
	%clientId.firemortar = "";
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
        %armor = "harmor";
	else
       	%armor = "harmor";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);
	Client::setSkin(%clientId, $Client::info[%clientId, 0]); 

	//edit
    if (!$DuelWeaponSetup[%clientId, 0])
		$DuelWeaponSetup[%clientId, 0] = 4;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 7;
    if (!$DuelWeaponSetup[%clientId, 3])
		$DuelWeaponSetup[%clientId, 3] = 1;
	%packNo = $DuelPackSetup[%clientId];
	if (%packNo == "") %packNo = 1;
	%pack = $DuelRealPack[%packNo];
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < 4; %i++) { //edit gunnum
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
	Player::SetItemCount(%clientId,RepairKit,1);
	Player::UseItem(%clientId, $DuelRealWeapon[$DuelWeaponSetup[%clientId, 0]]);
	return %pl;
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "Shifter Duel MOD", "options", true); 
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true); 

   if(%clientId.selClient) {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

		if(%sel != %clientId && $DuelLineup[%clientId] != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Request Duel", "duel " @ %sel);
		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin) {
         if($Shifter::VoteAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "c5vadmin " @ %sel);
         if($Shifter::VoteKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "c5vkick " @ %sel);
      }
      if(%clientId.isAdmin) {
	         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	        if(%clientId.isSuperAdmin) {
    	        Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
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
	   //Client::addMenuItem(%clientId, %curItem++ @ "Miscellany", "misc"); 
   
   	if($curVoteTopic != "" && %clientId.vote == "") {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   	  return;
	}
	  
	//if (!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId])
		Client::addMenuItem(%clientId, %curItem++ @ "Request Last Duel", "rerequest " @ $DuelLastEnemy[%clientId]);

	Client::addMenuItem(%clientId, %curItem++ @ "Weapons Setup", "weaponsetup");
	Client::addMenuItem(%clientId, %curItem++ @ "Weapons Options", "weaponoptions");	
	Client::addMenuItem(%clientId, %curItem++ @ "Pack Setup", "packsetup");

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
	if(%num == 4) { //edit gunnum
		if ($DuelPackSetup[%cl] == "") $DuelPackSetup[%cl] = 1;
		bottomprint(%cl, "<jc><f1>Your weapon setup is <f2>" @ 
		$DuelWeapon[$DuelWeaponSetup[%cl, 0]] @ "<f1>, <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 1]] @ "<f1>, <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 2]] @ "<f1>, and <f2>" @
		$DuelWeapon[$DuelWeaponSetup[%cl, 3]] @ "<f1>.\nYour pack setup is a <f2>" @ 
		$DuelPack[$DuelPackSetup[%cl]] @ "<f1>.", 10);
		return;
	}
	WeaponSetup(%cl, %num, 0);
}

function WeaponSetup(%clientId, %num, %i) {
	%w1 = $DuelWeaponSetup[%clientId, 0];
	%w2 = $DuelWeaponSetup[%clientId, 1];
	%w3 = $DuelWeaponSetup[%clientId, 2];
	Client::buildMenu(%clientId, "Select your weapons (" @ (3 - %num) @ " left):", "chooseweapon", true);
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

function processMenuchoosepack(%clientID, %option) {
	$DuelPackSetup[%clientID] = %option;

    if (!$DuelWeaponSetup[%clientId, 0])
		$DuelWeaponSetup[%clientId, 0] = 4;
    if (!$DuelWeaponSetup[%clientId, 1])
		$DuelWeaponSetup[%clientId, 1] = 2;
    if (!$DuelWeaponSetup[%clientId, 2])
		$DuelWeaponSetup[%clientId, 2] = 7;
    if (!$DuelWeaponSetup[%clientId, 3])
		$DuelWeaponSetup[%clientId, 3] = 1;

	bottomprint(%clientID,"<jc><f1>Your weapon setup is <f2>" @ 
	$DuelWeapon[$DuelWeaponSetup[%clientID, 0]] @ "<f1>, <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%clientID, 1]] @ "<f1>, <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%clientID, 2]] @ "<f1>, and <f2>" @
	$DuelWeapon[$DuelWeaponSetup[%clientID, 3]] @ "<f1>.\nYour pack setup is a <f2>" @
	$DuelPack[$DuelPackSetup[%clientID]] @ "<f1>.", 10);
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

function processMenuOptions(%clientId, %option) {
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
	if(!DuelPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; }	// PORT: see the end of this file

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
	//if(%opt == "misc") {
	//	%i = 0;
	//	Client::buildMenu(%clientId, "Miscellany:", "mmisc", true); 
	//	Client::addMenuItem(%clientId, %i++ @ "Observer Mode", "obsm"); 
	//	if ($DuelModeOff[%clientId])
	//		Client::addMenuItem(%clientId, %i++ @ "Enable Duels", "toggled");
	//	else
	//		Client::addMenuItem(%clientId, %i++ @ "Disable Duels", "toggled");			
	//	return;
	//} 
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
	  		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Stinger Seeker", "weapon_rocket3");
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
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_disc_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Multi-Disc Shell", "weapon_disc_rapid");
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
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma Stinger Initiated.\", 3);", 0.01);
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
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Disc Shell Selected.\", 3);", 0.01);
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
		%armor = "harmor";
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
		$DuelWeaponSetup[%clientId, 3] = 0;
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
   else if(%opt == "c5vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "c5vadmin")
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


function DuelMOD::oldMissionChangeNotify(%serverManagerId, %nextMission) {
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
   remoteEval(%clientId, MODInfo, "<f0>modded by (TKO)Arkangel\n<f1>DREAD DUEL TOURNEY for SHIFTER_SG1 servers Only!!\n<f1>http://TKO.8k.com");
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

	%clientId.observerMode = "";
   Game::onPlayerConnected(%clientId);
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

		if (!Player::isDead(%this)) {
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


echo("********************Ultra-Shifter_SG1_Duel*********************");
echo("Duel Mod for SHIFTER_SG1 servers, modded by {TKO}Arkangel");
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
