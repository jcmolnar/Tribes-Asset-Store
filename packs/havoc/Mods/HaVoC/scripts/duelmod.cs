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
$DuelHurtDelay = 1.7;

$DuelSpecial[1] = "RealTargetingLaser";
$DuelSpecial[2] = "Smoker";
$DuelSpecial[3] = "TractorBeam";
$DuelSpecial[4] = "Grapple";
$DuelSpecial[5] = "PSmoker";
$DuelSpecial[6] = "Anti";
$DuelSpecial[7] = "EMPMine";
$DuelSpecial[8] = "GASMine";
$DuelSpecial[9] = "Flare";
$DuelSpecialMax = 9;

$DuelWeapon[1] = "Shotgun";
$DuelWeapon[2] = "Chaingun";
$DuelWeapon[3] = "PlasmaGun";
$DuelWeapon[4] = "DiscLauncher";
$DuelWeapon[5] = "HDiscLauncher";
$DuelWeapon[6] = "GrenadeLauncher";
$DuelWeapon[7] = "RocketLauncher";
$DuelWeapon[8] = "IXRocketLauncher";
$DuelWeapon[9] = "EMPGrenadeLauncher";
$DuelWeapon[10] = "Mortar";
$DuelWeapon[11] = "Silencer";
$DuelWeapon[12] = "TranqGun";
$DuelWeapon[13] = "Railgun";
$DuelWeapon[14] = "SniperRifle";
$DuelWeapon[15] = "Blaster";
$DuelWeapon[16] = "EnergyRifle";
$DuelWeapon[17] = "WaveGun";
$DuelWeapon[18] = "Flamer";
$DuelWeapon[19] = "LaserRifle";
$DuelWeaponMax = 19;

$DuelPack[1] = "AmmoPack";
$DuelPack[2] = "EnergyPack";
$DuelPack[3] = "RepairPack";
$DuelPack[4] = "ShieldPack";
$DuelPack[5] = "Heatsink";
$DuelPack[6] = "SMRPack";
$DuelPack[7] = "TPack";
$DuelPack[8] = "OpticPack";
$DuelPack[9] = "SuicidePack";
$DuelPackMax = 9;

$ItemMax[dmarmor, IXRocketLauncher] = 0;
$ItemMax[dmfemale, IXRocketLauncher] = 0;
$MaxWeapons[dmarmor] = 3;
$MaxWeapons[dmfemale] = 3;

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
	$DuelPack[%clientId] = "";
   	$HighStreak[%clientId] = 0;
   	setHigh(%clientId);
   	$DuelStreak[%clientId] = 0;
	$DuelModeOff[%clientId] = false;
	%clientId.guiLock = false;
}

function ClearMines(%client) {
	for(%i=0; %i < $DuelMinesCount[%client]; %i++) {
		if (getObjectType($DuelMines[%client, %i]) == "Mine") {
			GameBase::setDamageLevel($DuelMines[%client, %i], 10);
		}
	}
	$DuelMinesCount[%client] = 0;
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
		if($WeaponAmmo[$DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < 3; %i++) {
		if($WeaponAmmo[$DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i]] == "") {
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
		echo( "---" );
		if (Client::getGender(%clientId) == "Female")
	        %armor = $ArmorType[Female, $DuelArmor[%clientId]];
		else
	        %armor = $ArmorType[Male, $DuelArmor[%clientId]];
		for (%i = 0; %i < $MaxWeapons[%armor]; %i++) {
			echo( %clientId );
			echo( %armor );
			echo( $DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i] );
			echo( $WeaponAmmo[$DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i]] );
			echo( Player::getItemCount(%clientId, $WeaponAmmo[$DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i]]) );
			echo( "---" );
			if(Player::getItemCount(%clientId, $DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i]) && Player::getItemCount(%clientId, $WeaponAmmo[$DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i]])) {
				schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ");", 15);
				return;
			}
		}
		echo( "---" );
		if (Client::getGender(%foeId) == "Female")
	        %armor = $ArmorType[Female, $DuelArmor[%foeId]];
		else
	        %armor = $ArmorType[Male, $DuelArmor[%foeId]];
		for (%i = 0; %i < $MaxWeapons[%armor]; %i++) {
			echo( %foeId );
			echo( %armor );
			echo( $DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i] );
			echo( $WeaponAmmo[$DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i]] );
			echo( Player::getItemCount(%foeId, $WeaponAmmo[$DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i]]) );
			echo( "---" );
			if(Player::getItemCount(%foeId, $DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i]) && Player::getItemCount(%foeId, $WeaponAmmo[$DuelWeaponSetup[%foeId, $DuelArmor[%foeId], %i]])) {
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

	%clientId.poisonTime = 0;
	%foeId.poisonTime = 0;

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
		$DuelArmor[%clientId] = $DuelArmor[%foeId];
		DuelInit(%clientId, %foeId);
		return;
	}
	if(%again) {
		processMenuarmorSel(%clientId, $DuelArmor[%clientId] @ " " @ %foeId @ " " @ %again);
		return;
	}
	Client::buildMenu(%clientId, "Select an armor to duel in:", "armorSel", true);
	Client::addMenuItem(%clientId, "1 Deathmatch", "CArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "2 Scout", "ScoutArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "3 Spy", "SpArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "4 Sniper", "LightArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "5 Mercenary", "MediumArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "6 Burster", "BursterArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "7 Engineer", "EngArmor " @ %foeId @ " " @ %again);
	Client::addMenuItem(%clientId, "8 Additional Armors...", "morearm " @ %foeId @ " " @ %again);
}

function processMenuarmorSel(%clientId, %option) { 
	%armor = getWord(%option, 0);
	%foeId = getWord(%option, 1);
	%again = getWord(%option, 2);

	if(%armor == "morearm") {
		Client::buildMenu(%clientId, "Select an armor to duel in:", "armorSel", true);
		Client::addMenuItem(%clientId, "1 Infiltrator", "InfArmor " @ %foeId @ " " @ %again);
		Client::addMenuItem(%clientId, "2 Cyborg", "DragArmor " @ %foeId @ " " @ %again);
		Client::addMenuItem(%clientId, "3 Behemoth", "BehArmor " @ %foeId @ " " @ %again);
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

	$DuelLineup[%clientId] = %foeId;
	$DuelArmor[%clientId] = %armor;
	Client::sendMessage(%clientId,0,Client::GetName(%foeId) @ " has 30 seconds to accept the " @ %armor.description @ " duel.");
	CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a " @ %armor.description @ " duel.", 8);
	Client::sendMessage(%foeId,0,"You have 30 seconds to accept a " @ %armor.description @ " duel from " @ Client::GetName(%clientId) @ ".");
	CheckDuelTime(%clientId, %foeId, 30);
	if(%again && $DuelStreak[%foeId] > 5) {
		client::sendMessage(%clientId, 0, "~wduelagain.wav");
		client::sendMessage(%foeId, 0, "~wduelagain.wav");
	}
	return;
}                


function DuelInit(%clientId, %foeId) {
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
	MessageAll(0, Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " are about to duel!");
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
        %armor = $ArmorType[Female, $DuelArmor[%clientId]];
	else
        %armor = $ArmorType[Male, $DuelArmor[%clientId]];
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);
	Client::setSkin(%clientId, $Client::info[%clientId, 0]); 

	Player::SetItemCount(%clientId, TargetingLaser, 1);
	%special = $DuelSpecialSetup[%clientId, $DuelArmor[%clientId]];
	if (%special == "")
		%special = RealTargetingLaser;
	Player::SetItemCount(%clientId, %special, $ItemMax[%armor, %special]);

	if(%armor == "harmor") {
		Player::setItemCount(%clientId, SMR2Pack,1);
		Player::mountItem(%clientId, SMR2Pack, 4);
		Player::setItemCount(%clientId, SMR3Pack,1);
		Player::mountItem(%clientId, SMR3Pack, 5);
	}
		
    if ($DuelWeaponSetup[%clientId, $DuelArmor[%clientId], 0] == "")
		$DuelWeaponSetup[%clientId, $DuelArmor[%clientId], 0] = DiscLauncher;
	%pack = $DuelPackSetup[%clientId, $DuelArmor[%clientId]];
	if (%pack == "")
		%pack = EnergyPack;
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < $MaxWeapons[%armor]; %i++) {
    	%weapon = $DuelWeaponSetup[%clientId, $DuelArmor[%clientId], %i];
       	%weaponAmmo = $WeaponAmmo[%weapon];
       	if(%weapon != "")
				Player::SetItemCount(%clientId,%weapon,1);
			echo( %weapon @ " ammo = " @ %weaponAmmo );
       	if (%weaponAmmo != "") {
				echo( %armor @ " max = " @ $ItemMax[%armor, %weaponAmmo] );
       		if (%pack == AmmoPack && $AmmoPackMax[%armor, %weaponAmmo] != "")
       			Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo] + $AmmoPackMax[%armor, %weaponAmmo]);
       		else
       			Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo]);
       	}
    }
    if (%pack == "AmmoPack") {
	    Player::SetItemCount(%clientId, Beacon, $ItemMax[%armor, Beacon] + $AmmoPackMax[%armor, Beacon]);
		Player::SetItemCount(%clientId, MineAmmo, $ItemMax[%armor, MineAmmo] + $AmmoPackMax[%armor, MineAmmo]);
	   	Player::SetItemCount(%clientId, Grenade, $ItemMax[%armor, Grenade] + $AmmoPackMax[%armor, Grenade]);  
	} else {
	    Player::SetItemCount(%clientId, Beacon, $ItemMax[%armor, Beacon]);
		Player::SetItemCount(%clientId, MineAmmo, $ItemMax[%armor, MineAmmo]);
	   	Player::SetItemCount(%clientId, Grenade, $ItemMax[%armor, Grenade]);  
	}
	if($DuelArmor[%clientId] == "EngArmor")
		Player::SetItemCount(%clientId,FixIt,1);
	if (%pack == AmmoPack || $DuelArmor[%clientId] == "EngArmor")
       	Player::SetItemCount(%clientId,RepairKit,2);
	else
       	Player::SetItemCount(%clientId,RepairKit,1);
	Player::UseItem(%clientId, $DuelWeaponSetup[%clientId, $DuelArmor[%clientId], 0]);
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
		if(%sel != %clientId && $DuelLineup[%clientId] != %sel && $matchStarted)
			Client::addMenuItem(%clientId, %curItem++ @ "Request Duel", "duel " @ %sel);
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

	if (!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId])
		Client::addMenuItem(%clientId, %curItem++ @ "Request Last Duel", "rerequest " @ $DuelLastEnemy[%clientId]);

	Client::addMenuItem(%clientId, %curItem++ @ "Armor Setup", "weaponsetup");

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

function processMenuchooseweapon(%cl, %opt) {
	%weap = getword(%opt, 0);
	%num = getword(%opt, 1);
	if(%weap == "more") {
		%i = getword(%opt, 2);
		%armorName = getword(%opt, 3);
		WeaponSetup(%cl, %num, %i, %armorName);
		return;
	}
	%armorName = getword(%opt, 2);
	$DuelWeaponSetup[%cl, %armorName, %num] = $DuelWeapon[%weap];
	%num++;
	if(%num == $MaxWeapons[$ArmorType[Male, %armorName]]) {
		%str = "<jc><f1>Your " @ %armorName.description @ " weapon setup is <f2>";
		for(%i = 0; %i < %num - 1; %i = %i + 1)
			%str = %str @ $DuelWeaponSetup[%cl, %armorName, %i].description @ "<f1>, <f2>";
		%str = %str @ "<f1>and <f2>" @ $DuelWeaponSetup[%cl, %armorName, %num-1].description @ "<f1>.";
    	bottomprint(%cl, %str, 10);
		PackSetup(%cl, %armorName);
		return;
	}
	WeaponSetup(%cl, %num, 0, %armorName);
}

function processMenuWeapArmor(%clientId, %armor) {
	if(%armor == "morearm") {
		Client::buildMenu(%clientId, "Select an armor to setup:", "WeapArmor", true);
		Client::addMenuItem(%clientId, "1 Infiltrator", "InfArmor");
		Client::addMenuItem(%clientId, "2 Cyborg", "DragArmor");
		Client::addMenuItem(%clientId, "3 Behemoth", "BehArmor");
		return;
	}
	WeaponSetup(%clientId, 0, 0, %armor);
	return;
}

function WeaponSetup(%clientId, %num, %i, %armorName) {
	%armor = $ArmorType[Male, %armorName];
   Client::buildMenu(%clientId, %armorName.description @ " weapons (" @ ($MaxWeapons[%armor] - %num) @ " left):", "chooseweapon", true);
	while(true) {
		%i++;
		if($ItemMax[%armor, $DuelWeapon[%i]]) {
         %found = false;
			for(%ii = 0; %ii < %num; %ii = %ii + 1) {
				if($DuelWeaponSetup[%clientId, %armorName, %ii] == $DuelWeapon[%i]) {
					%found = true;
					break;
				}
			}
			if(!%found) {
				%t++;
				Client::addMenuItem(%clientId, %t @ $DuelWeapon[%i].description, %i @ " " @ %num @ " " @ %armorName);
			}
		}
		if(%i == $DuelWeaponMax) break;
		if(%t == 7) {
			%numFound = 0;
			for(%ii = %i+1; %ii <= $DuelWeaponMax; %ii = %ii + 1) {
		      if($ItemMax[%armor, $DuelWeapon[%ii]]) {
				   %found = false;
					for(%iii = 0; %iii < %num; %iii = %iii + 1) {
						if($DuelWeaponSetup[%clientId, %armorName, %iii] == $DuelWeapon[%ii]) {
							%found = true;
							break;
						}
					}
					if(!%found) %numFound++;
					if(%numFound > 1) {
						Client::addMenuItem(%clientId, "8More...", "more " @ %num @ " " @ %i @ " " @ %armorName);
						return;
					}
				}
			}
		}
	}
}
                                    
function SpecialSetup(%clientId, %armorName) {
	if(%armorName == "CArmor") return;
	Client::buildMenu(%clientId, %armorName.description @ " special:", "choosespecial", true);
	%armor = $ArmorType[Male, %armorName];
	%t = 0;
	for (%i = 1; %i <= $DuelSpecialMax; %i++) {
		if($ItemMax[%armor, $DuelSpecial[%i]]) {
			%t++;
			Client::addMenuItem(%clientId, %t @ $DuelSpecial[%i].description, $DuelSpecial[%i] @ " " @ %armorName);
		}
	}
}

function PackSetup(%clientId, %armorName) {
	Client::buildMenu(%clientId, %armorName.description @ " pack:", "choosepack", true);
	%armor = $ArmorType[Male, %armorName];
	%t = 0;
	for (%i = 1; %i <= $DuelPackMax; %i++) {
		if($ItemMax[%armor, $DuelPack[%i]]) {
			%t++;
			Client::addMenuItem(%clientId, %t @ $DuelPack[%i].description, $DuelPack[%i] @ " " @ %armorName);
		}
	}
}

function getEfficiencyRatio(%clientId) {
	%ratio = floor((%clientId.score/(%clientId.score + %clientId.scoreDeaths))*100);
	if (%ratio > 0)
		return %ratio;
	else 
		return "0";
}

function processMenuchoosespecial(%cl, %option) {
	%armorName = getWord(%option, 1);
	$DuelSpecialSetup[%cl, %armorName] = getWord(%option, 0);
	bottomprint(%cl,"<jc><f1>Your " @ %armorName.description @ " special is a <f2>" @
	$DuelSpecialSetup[%cl, %armorName].description @ "<f1>.", 10);
	return;
}

function processMenuchoosepack(%cl, %option) {
	%armorName = getWord(%option, 1);
	$DuelPackSetup[%cl, %armorName] = getWord(%option, 0);
	bottomprint(%cl,"<jc><f1>Your " @ %armorName.description @ " pack is a <f2>" @
	$DuelPackSetup[%cl, %armorName].description @ "<f1>.", 10);
	SpecialSetup(%cl, %armorName);
}

function processMenuOptions(%clientId, %option) { 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(!HaVoCPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; } // PORT: menu codes come from the client
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
		Client::buildMenu(%clientId, "Select an armor to setup:", "WeapArmor", true);
		Client::addMenuItem(%clientId, "1 Deathmatch", "CArmor");
		Client::addMenuItem(%clientId, "2 Scout", "ScoutArmor");
		Client::addMenuItem(%clientId, "3 Spy", "SpArmor");
		Client::addMenuItem(%clientId, "4 Sniper", "LightArmor");
		Client::addMenuItem(%clientId, "5 Mercenary", "MediumArmor");
		Client::addMenuItem(%clientId, "6 Burster", "BursterArmor");
		Client::addMenuItem(%clientId, "7 Engineer", "EngArmor");
		Client::addMenuItem(%clientId, "8 Additional Armors...", "morearm");
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
	if(%opt == "votemenu") {
		votemenu(%clientId);
		return;
	}
	if(%opt == "adminmenu") {
      if ( badMan( %clientId, 115 ) ) return;
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
      if ( badMan( %clientId, 116 ) ) return;
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
      if ( badMan( %clientId, 117 ) ) return;
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
		if ($DuelModeOff[%clientId])
			Client::addMenuItem(%clientId, %i++ @ "Enable Duels", "toggled");
		else
			Client::addMenuItem(%clientId, %i++ @ "Disable Duels", "toggled");			
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
      if ( badMan( %clientId, 118 ) ) return;
		%cl.gag = true; 
		echo(Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId));
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
		Client::sendMessage(%cl, 1,"You've been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
	} else if(%opt == "ungag") {
      if ( badMan( %clientId, 119 ) ) return;
		%cl.gag = false; 
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ "'s gag has been removed by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"Your gag has been removed by " @ Client::getName(%clientId)@"."); 	
	} else if(%opt == "strip") {
      if ( badMan( %clientId, 120 ) ) return;
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
      if ( badMan( %clientId, 121 ) ) return;
		$listen[%cl] = %clientId;
		Client::sendMessage(%clientId, 0,"You are now listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "unlis") {
      if ( badMan( %clientId, 122 ) ) return;
		$listen[%cl] = "";
		Client::sendMessage(%clientId, 0,"You are no longer listening to " @ Client::getName(%cl) @ "."); 
	} else if(%opt == "jus") {
      if ( badMan( %clientId, 123 ) ) return;
		%cl.just = true;
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has forced Eye for an Eye on " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has forced Eye for an Eye on you."); 	
	} else if(%opt == "unjus") {
      if ( badMan( %clientId, 124 ) ) return;
		%cl.just = "";
		MessageAllExcept(%cl , 0, Client::getName(%clientId) @ " has removed Eye for an Eye from " @ Client::getName(%cl) @ "."); 
		Client::sendMessage(%cl ,1, Client::getName(%clientId) @ " has removed Eye for an Eye from you."); 	

	} else if(%opt == "poss") {
      if ( badMan( %clientId, 125 ) ) return;
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
      if ( badMan( %clientId, 126 ) ) return;
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
      if ( badMan( %clientId, 127 ) ) return;
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
      if ( badMan( %clientId, 128 ) ) return;
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
      if ( badMan( %clientId, 129 ) ) return;
		Admin::setTeamDamageEnable(%clientId, true); 
    }
	else if(%opt == "dtd") {
      if ( badMan( %clientId, 130 ) ) return;
		Admin::setTeamDamageEnable(%clientId, false); 
     }
	else if(%opt == "eft") {
   if ( badMan( %clientId, 131 ) ) return;
		Admin::setFairTeams(%clientId, true); 
      }
	else if(%opt == "dft") {
      if ( badMan( %clientId, 132 ) ) return;
		Admin::setFairTeams(%clientId, false); 
      }

   if(%opt == "balan")
      Admin::startVote(%clientId, "balance the teams on the next mission change", "balan", 0);
	else if(%opt == "forbalan") {
      if ( badMan( %clientId, 133 ) ) return;
		messageall(0, Client::getName(%clientId) @ " has forced the teams to be balanced on the next mission change.");
		$HaVoC::BalanceTeams = true;
	} else if(%opt == "canbalan") {
      if ( badMan( %clientId, 134 ) ) return;
		messageall(0, Client::getName(%clientId) @  " has cancelled balancing the teams on the next mission change.");
		$HaVoC::BalanceTeams = false;
   } else if(%opt == "vegm")
      Admin::startVote(%clientId, "enable GREED mode", "egm", 0);
   else if(%opt == "vdgm")
      Admin::startVote(%clientId, "disable GREED mode", "dgm", 0);
   else if(%opt == "egm")
      Admin::setGreedMode(%clientId, true);
   else if(%opt == "dgm")
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
	} else if(%opt == "cffa") {
      if ( badMan( %clientId, 135 ) ) return;
		Admin::setModeFFA(%clientId); 
	} else if(%opt == "ctourney") {
      if ( badMan( %clientId, 136 ) ) return;
		Admin::setModeTourney(%clientId); 
   }
		
		
	if(%opt == "makeitso" && %cl == $curVoteCount) { 
      if ( badMan( %clientId, 137 ) ) return;
		echo("*** " @ Client::getName(%clientId) @ " has forced the current vote to PASS!");
		hvcAdminMsg(Client::getName(%clientId) @ " has forced the current vote to PASS!");
		$curVoteCheat = "YES";
		%clientId.hv = 0;
	} else if(%opt == "makeitno" && %cl == $curVoteCount) { 
      if ( badMan( %clientId, 138 ) ) return;
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
      if ( badMan( %clientId, 139 ) ) return;
		Client::buildMenu(%clientId, "Confirm Kick:", "kaffirm", true); 
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kick " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "execute") { 
      if ( badMan( %clientId, 140 ) ) return;
		Client::buildMenu(%clientId, "Confirm Execution:", "maffirm", true); 
		Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Kill 'em ", "no " @ %cl); 
		return; 
	} else if(%opt == "poison") { 
      if ( badMan( %clientId, 141 ) ) return;
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
      if ( badMan( %clientId, 142 ) ) return;
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
      if ( badMan( %clientId, 143 ) ) return;
		Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true); 
		Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
		return; 
	} else if(%opt == "ban") { 
      if ( badMan( %clientId, 144 ) ) return;
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true); 
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Ban " @ Client::getName(%cl), "no " @ %cl); 
		return; 
	} else if(%opt == "smatch") {
      if ( badMan( %clientId, 145 ) ) return;
		Admin::startMatch(%clientId); 
	} else if(%opt == "vcmission" || %opt == "cmission") { 
      if ( %opt == "cmission" && badMan( %clientId ) ) return;
		Admin::changeMissionMenu(%clientId, %opt); 
		return; 
	} 
	if(%opt == "cctimelimit") { 
      if ( badMan( %clientId, 146 ) ) return;
		$Server::timeLimit += $HaVoC::PVTime;
		messageAll(0, Client::getName(%clientId) @ " has increased the time limit by " @ $HaVoC::PVTime @ " minutes."); 
		return;
	} else if(%opt == "ctimelimit") { 
      if ( badMan( %clientId, 147 ) ) return;
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
      if ( badMan( %clientId, 148 ) ) return;
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

	doneposs(%clientId);

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
			%armor = Player::getArmor( %player );
			if ( %armor == barmor || %armor == bfemale )
				%obj = newObject("","Mine","FireMine");
			else
				%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			$DuelMines[%client, $DuelMinesCount[%client]] = %obj;
			$DuelMinesCount[%client]++;
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
                                
function setHigh(%clientId) {
	if($DuelStreak[%clientId] > 2 && $DuelStreak[%clientId] > $Duel::RecordNum && (getNumClients() > 4) && Client::getName(%clientId) != "") {
		schedule("messageall(0, \"" @ escapeString(Client::getName(%clientId)) @ "'s record breaking winning streak of " @ $DuelStreak[%clientId] @ " wins has come to an end!~wCapturedTower.wav\");", 1.5);
        $Duel::RecordHolder = Client::getName(%clientId);
		$Duel::RecordNum = $DuelStreak[%clientId];
        export("$Duel::Record*", "config\\DuelRecord.cs", False);
	}
}

function Server::onClientDisconnect(%clientId) {
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
	
	doneposs(%clientId);
	if(%clientId.hasDeployed) $hasDropped = true;
	%clientId.adminNum = "";
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if ($Game::missionType != "Duel")
		if(getNumClients() == 1) Server::refreshData();
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
	$dflag = true;
   
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
      	Client::setGuiMode(%cl, $GuiModeVictory);
      	%cl.guiLock = true;
      	%cl.nospawn = true;
      	remoteEval(%cl, missionChangeNotify, %missionName);
	  	%cl.empTime = 0;
	  	%cl.poisonTime = 0;
	  	%cl.blindTime = 0;
	  	%cl.basekills = 0;
		remoteEval(%cl, SetControls);
	}

   $timeReached = true;
   DuelMOD::missionObjectives();
   $timeReached = false;

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
		if( !%this.shieldStrength )
			HaVoC_startBlind(%damagedClient, %this, 8);
	} else if (%type == $SuperEnergyDamageType) {
  		if( !%this.shieldStrength )
   		HaVoC_startBlind(%damagedClient, %this, 8);
      else
   		HaVoC_startBlind(%damagedClient, %this, 4);
	} else if (%type == $SmallEnergyDamageType) {
  		if( !%this.shieldStrength )
   		HaVoC_startBlind(%damagedClient, %this, 8);
      else
   		HaVoC_startBlind(%damagedClient, %this, 4);
   }

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
		if(%damagedClient.lastDamage < getSimTime()) {
			%sound = radnomItems(3,injure1,injure2,injure3);
			playVoice(%damagedClient,%sound);
			%damagedClient.lastdamage = getSimTime() + 1.5;
		}
		if(%dlevel >= (%armor.maxDamage * 0.85)) {                                                         
			%foeId = $Dueling[%damagedClient];
			if(%foeId.lastsound < getSimTime()) {
				%foeId.lastsound = getSimTime() + 8;
				if (Client::GetGender(%damagedClient) == "Female")
					Client::sendMessage(%foeId, 0, "~wduelfinisher.wav");
				else
					Client::sendMessage(%foeId, 0, "~wduelfinishim.wav");
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
	return;
}

function Server::nextMission(%replay)
{
if(%replay || $Server::TourneyMode){
	%nextMission = $missionName;
} else {
	if(getNumClients() < 2 || $HaVoC::RandomMissionTypes["Duel"]) {
		doNextRand();
		return;
	}
	echo("Selecting a mission...");
	%l = 0; %goodmtype = 0;
	while(%goodmtype != "Duel" && %l < 5000) {
		%rnd = floor(getRandom() * $TotalMissions);
		if ($MissionName != $TotalMissionList[%rnd]) {
			%nextMission = $TotalMissionList[%rnd];
			$pref::LastMission = $TotalMissionList[%rnd];
		}			  
		%goodmtype = $HaVoC::MType[%nextMission];
		%l = %l + 1;
	}
	if(%l < 5000) {
		echo("A random Duel mission has been selected.");
		messageall(0, "A random Duel mission is being selected...");
		messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
	} else {
		echo("No other Duel missions found!");
		echo("Using default next mission.");
		%nextMission = $nextMission[$missionName];
	}
}

   echo("Changing to mission ", %nextMission, ".");
   
   Server::loadMission(%nextMission);
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
echo("Duel MOD for HaVoC v" @ $HV @ ", by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("*****************************************");