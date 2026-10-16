exec(objectives);
exec("1vs1Record.cs");
if(!$Duel::RecordTime) $Duel::RecordTime = 9999;
$DuelBestTime = 9999;
$matchStep = 0;
RecursiveWorld(0.1);
$DuelSpotTaken[1] = false;
$DuelSpotTaken[2] = false;
$DuelSpotTaken[3] = false;
$DuelSpotTaken[4] = false;
$CurrentFootball1 = "";
$CurrentFootball2 = "";
$CurrentFootball3 = "";
$CurrentFootball4 = "";
for(%i = 1; %i > 26; %i++)
$LineSpot[%i] = "";
$teamScore[0] = 0;	
$teamScore[1] = 0;
$teamScore[2] = 0;
$teamScore[3] = 0;
$teamScore[4] = 0;
$teamScore[5] = 0;
$teamScore[6] = 0;
$teamScore[7] = 0;                        
$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;
$Sensornetworkenabled = true;
                            

//$DuelWeaponMax[darmor] = 0;
$DuelWeaponMax[spyarmor] = 0;

function addgun(%armor, %name, %real, %ammo)
{
	%num = $DuelWeaponMax[%armor] + 1;
	$DuelWeaponMax[%armor]++;
	$DuelWeapon[%armor, %num] = %name;
	$DuelRealWeapon[%armor, %num] = %real;
	$DuelWeaponAmmo[%armor, %num] = %ammo;
}


$DuelPackMax[spyarmor] = 0;
function addpack(%armor, %name, %real)
{
	%num = $DuelPackMax[%armor] + 1;
	$DuelPackMax[%armor]++;
	$DuelPack[%armor, %num] = %name;
	$DuelRealPack[%armor, %num] = %real;
}

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
		BottomPrint(%clientId,"<jc><f1>1vs1 starts in <f2>1<f1> second.",2);
		BottomPrint(%foeId,"<jc><f1>1vs1 starts in <f2>1<f1> second.",2);
	} else {         
		if (%timeLeft > 5) {		
			CenterPrint(%clientId,"<jc><f2>READY!",2);
			CenterPrint(%foeId,"<jc><f2>READY!",2);
		} else {
			BottomPrint(%clientId,"<jc><f1>1vs1 starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
			BottomPrint(%foeId,"<jc><f1>1vs1 starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
		}
	}        
	schedule("DuelCountdown(" @ %clientId @ "," @ %foeId @ "," @ (%timeLeft - 1) @ "," @ %clientPl @ "," @ %foePl @ ");", 1);
}                                     

function DuelResetClient(%clientId) {
	//%clientId.achoice = "darmor";
	$Dueling[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
	$TackleFree[%clientId] = false;
	if($Dueling[%clientId])
	$TackleFree[$Dueling[%clientId]] = false;
   $HighStreak[%clientId] = 0;
   setHigh(%clientId);
   $DuelStreak[%clientId] = 0;
	$DuelModeOff[%clientId] = false;
	%clientId.guiLock = false;
	$DuelsDisabled[%clientId] = false;
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%clientId.blocked[%id] = false;
		%id.blocked[%clientId] = false;
	}
	$clientScore[%clientId] = 0;
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
   	Player::SetItemCount(%clientId, SilencerAmmo, 25);
   	Player::SetItemCount(%foeId, SilencerAmmo, 25);

}

function BeginDuel(%clientId, %foeId, %clientPl, %foePl) {                                
	%clArmor = %clientId.achoice;
	%foArmor = %foeId.achoice;
	$DuelCanHurt[%clientId] = true;
	$DuelCanHurt[%foeId] = true;
  	Player::SetItemCount(%clientId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%foeId, AutoRocketAmmo, 0);
  	Player::SetItemCount(%clientId, RocketAmmo, 0);
  	Player::SetItemCount(%foeId, RocketAmmo, 0);
  	Player::SetItemCount(%clientId, SilencerAmmo, 0);
  	Player::SetItemCount(%foeId, SilencerAmmo, 0);
	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	Client::sendMessage(%clientId, 0, "~wduelfight.wav");
	Client::sendMessage(%foeId, 0, "~wduelfight.wav");
	BottomPrint(%clientId, "<jc><f1>----- <f2>GO! <f1>-----", 3);
	BottomPrint(%foeId, "<jc><f1>----- <f2>GO! <f1>-----", 3);


	for (%i = 0; %i < $MaxWeapons[%clarmor]; %i++) {
		if($DuelWeaponAmmo[%clArmor, $DuelWeaponSetup[%clientId, %clArmor, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < $MaxWeapons[%foarmor]; %i++) {
		if($DuelWeaponAmmo[%foArmor, $DuelWeaponSetup[%foeId, %foArmor, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	

	Client::setControlObject(%clientId, %clientPl);
	Client::setControlObject(%foeId, %foePl);	

	$DuelStartTime[$DuelSpotIndex[%clientId]] = getSimTime();

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
	
	moveLineDown();
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
	        export("$Duel::Record*", "config\\1vs1Record.cs", False);
		}
		if(%t < $DuelBestTime) {
	        $DuelBestTimeHolder = Client::getName(%foeId);
	        $DuelBestTimeLoser = Client::getName(%clientId);
			$DuelBestTime = %t;
		}
	}
}

function EndDuel(%clientId) {
	%foeId = $Dueling[%clientId];
	%player = Client::getOwnedObject(%clientId);
	%fplayer = Client::getOwnedObject(%foeId);
		LoseFootball(%foeId);
		LoseFootball(%clientId);
	if($DuelSpotIndex[%clientId]==1)
{			
deleteObject($CurrentFootball1);
			$CurrentFootball1= "";
}
	else if($DuelSpotIndex[%clientId]==2)
{			
deleteObject($CurrentFootball2);
			$CurrentFootball2= "";
}
	else if($DuelSpotIndex[%clientId]==3)
{			
deleteObject($CurrentFootball3);
			$CurrentFootball3= "";
}
	else if($DuelSpotIndex[%clientId]==4)
{			
deleteObject($CurrentFootball4);
			$CurrentFootball4= "";
}

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

		$clientScore[%foeId] ++;
		$DuelStreak[%foeId]++;

		%clientId.scoreDeaths++;

		
		setHigh(%clientId);
		$DuelStreak[%clientId] = 0;
		
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			if(%id != %clientId && %id != %foeId)
			Client::sendMessage(%id, $MsgRed, Client::GetName(%foeId) @ ": " @ $TeamScore[GameBase::getTeam(%foeId)] @ " --- " @ Client::GetName(%clientId) @ ": " @ $TeamScore[GameBase::getTeam(%clientId)]);		
		}
		MessageAll(1,Client::GetName(%foeId) @ " claims victory over " @ Client::GetName(%clientId) @ "! (" @ %t @ ")");
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
		Client::sendMessage(%clientId, 1, Client::GetName(%clientId) @ " has ended the 1vs1 prior to start.~werror_message.wav"); 
		Client::sendMessage(%foeId, 1, Client::GetName(%clientId) @ " has ended the 1vs1 prior to start.~werror_message.wav"); 
		$clientScore[%foeId] ++;
		FinalizeDuel(%clientId, %foeId);
	}

}        


function Vote::changeMission() {
   $timeLimitReached = true;
   $timeReached = true;
   DuelMOD::missionObjectives();
}

function CheckDuelTime(%clientId,%foeId, %timeLeft) {                       
	//function not available
}
                                                                              
function DuelPropose(%clientId,%foeId,%again) {                                     
	if (%foeId == %clientId) {
		client::sendmessage(%clientId,0,"You can't 1vs1 yourself!~werror_message.wav");
		return;
	}
	else if ($Dueling[%clientId]) {
		client::sendmessage(%clientId,0,"Hello!? You're already in a 1vs1!~werror_message.wav");
		return;
	}
	else if (!%foeId || %foeId == 0 || Client::GetName(%foeId) == "") {
		Client::SendMessage(%clientId,0,"That person is not in the game.~waccess_denied.wav");
		return;
	}
	else if (!$matchStarted && $countdownStarted) {
		Client::SendMessage(%clientId,0,"The match is about to start. Ask again in a few seconds.~waccess_denied.wav");
		return;
	}
	else if ($Dueling[%foeId]) {
		client::sendmessage(%clientId,0, Client::GetName(%foeId) @ " is currently in a 1vs1. Try again later.~waccess_denied.wav");
		return;
	}
	else if ($DuelsDisabled[%foeId]) {
		client::sendmessage(%clientId,0, Client::GetName(%foeId) @ " currently has 1vs1s disabled.~waccess_denied.wav");
		return;
	}
	else if (%foeId.blocked[%clientId]) {
		client::sendmessage(%clientId,0, Client::GetName(%foeId) @ " is not accepting 1vs1 requests from you at this time.~waccess_denied.wav");
		return;
	}
	else if ($DuelLineup[%foeId] == %clientId) {
		DuelInit(%foeId, %clientId);
		return;
	}
	$DuelLineup[%clientId] = %foeId;
	Client::sendMessage(%clientId,0,Client::GetName(%foeId) @ " has 30 seconds to accept the 1vs1.");
	CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a 1vs1.", 8);
	Client::sendMessage(%foeId,0,"You have 30 seconds to accept a 1vs1 from " @ Client::GetName(%clientId) @ ".");
	CheckDuelTime(%clientId, %foeId, 30);
	if(%again && $DuelStreak[%foeId] > 5) {
		client::sendMessage(%clientId, 0, "~wduelagain.wav");
		client::sendMessage(%foeId, 0, "~wduelagain.wav");
	}
	return;
}                


function DuelInit(%clientId, %foeId) {

	if (!$DuelSpotTaken[1])
	%i = 1;	
	else if (!$DuelSpotTaken[2])
	%i = 2;
	else if (!$DuelSpotTaken[3])
	%i = 3;
	else if (!$DuelSpotTaken[4])
	%i = 4;
	else {
	Client::sendMessage(%clientId, 0, "All four 1vs1 slots are in use. Ask again when one ends.~waccess_denied.wav");
	Client::sendMessage(%foeId, 0, "All four 1vs1 slots are in use. Ask again when one ends.~waccess_denied.wav");
	return;
	}

	MessageAll(0, Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " are about to 1vs1!");

                                                
			$DuelSpotIndex[%clientId] = %i;
			$DuelSpotIndex[%foeId] = %i;
			$DuelSpotTaken[%i] = true;


      
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
	$TackleFree[%clientId] = false;
	$TackleFree[%foeId] = false;
		if (%i==4)
		{
		GameBase::SetTeam(%clientId, 6);
		GameBase::SetTeam(%clientPl, 6);
		GameBase::SetTeam(%foeId, 7);
		GameBase::SetTeam(%foePl, 7);
		}
		else if(%i==3) {
		GameBase::SetTeam(%clientId, 4);
		GameBase::SetTeam(%clientPl, 4);
		GameBase::SetTeam(%foeId, 5);
		GameBase::SetTeam(%foePl, 5);
		}
		else if(%i==2) {
		GameBase::SetTeam(%clientId, 2);
		GameBase::SetTeam(%clientPl, 2);
		GameBase::SetTeam(%foeId, 3);
		GameBase::SetTeam(%foePl, 3);
		}
		else if(%i==1) {
		GameBase::SetTeam(%clientId, 0);
		GameBase::SetTeam(%clientPl, 0);
		GameBase::SetTeam(%foeId, 1);
		GameBase::SetTeam(%foePl, 1);
		}

		
	$DuelSpawnMarker[%clientId] = Game::pickRandomSpawn(GameBase::getTeam(%clientId));
	$DuelSpawnMarker[%foeId] = Game::pickRandomSpawn(GameBase::getTeam(%foeId));
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
	DoSpawnFootball(GameBase::getTeam(%foeId));       
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
	%achoice = %clientId.achoice;
	//if(!%achoice)
	//{
	//	%achoice = "darmor";
	//	%clientId.achoice = "darmor"; 
	//}
	if(%achoice == "darmor")
	{
		if (Client::getGender(%clientId) == "Female")
			%armor = "darmor";
		else
			%armor = "darmor";
		if(!$DuelWeaponSetup[%clientId, %achoice, 0])
			$DuelWeaponSetup[%clientId, %achoice, 0] = 4;
		if(!$DuelWeaponSetup[%clientId, %achoice, 1])
			$DuelWeaponSetup[%clientId, %achoice, 1] = 2;
		if(!$DuelWeaponSetup[%clientId, %achoice, 2])
			$DuelWeaponSetup[%clientId, %achoice, 2] = 7;
		if(!$DuelWeaponSetup[%clientId, %achoice, 3])
			$DuelWeaponSetup[%clientId, %achoice, 3] = 1;
	}
	else if(%achoice == "spyarmor")
	{
		if (Client::getGender(%clientId) == "Female")
			%armor = "spyfemale";
		else
			%armor = "spyarmor";
		if(!$DuelWeaponSetup[%clientId, %achoice, 0])
			$DuelWeaponSetup[%clientId, %achoice, 0] = 1;
		if(!$DuelWeaponSetup[%clientId, %achoice, 1])
			$DuelWeaponSetup[%clientId, %achoice, 1] = 2;
		if(!$DuelWeaponSetup[%clientId, %achoice, 2])
			$DuelWeaponSetup[%clientId, %achoice, 2] = 3;

		$DuelWeaponSetup[%clientId, %achoice, 3] = 0;
	}

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl); 

   //spawn with only blaster and health kit
   Player::setItemCount(%clientId,$ArmorName[%armor],1);
   Player::setItemCount(%clientId,FootballThrower,1);
   Player::setItemCount(%clientId,RepairKit,1);
	Player::useItem(%pl,FootballThrower);
	GameBase::setRechargeRate(%pl, $rechargeRate[Player::getArmor(%clientId)]);

	//edit
	%packNo = $DuelPackSetup[%clientId, %achoice];
	if (%packNo == "") %packNo = 1;
	%pack = $DuelRealPack[%achoice, %packNo];
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < $MaxWeapons[%achoice]; %i++) { //edit gunnum
    	%weapon = $DuelWeaponSetup[%clientId,%achoice, %i];
      %weaponAmmo = $DuelWeaponAmmo[%achoice, %weapon];
      %realweapon = $DuelRealWeapon[%achoice, %weapon];
      %armor = Player::GetArmor(%clientId);
      Player::SetItemCount(%clientId,%realweapon,1);
    }
	Player::SetItemCount(%clientId,RepairKit,1);
	Player::UseItem(%clientId, $DuelRealWeapon[%armor, $DuelWeaponSetup[%clientId, %armor, 0]]);
	return %pl;
}
function Game::menuRequest(%clientId)
{

   %curItem = 0;
	if(!%clientId.selClient)
	{
		Client::buildMenu(%clientId, "Football 1vs1 MOD", "options", true); 
		Client::addMenuItem(%clientId, %curItem++ @ "Request Last 1vs1", "rerequest " @ $DuelLastEnemy[%clientId]);
		if($DuelsDisabled[%clientId])
		Client::addMenuItem(%clientId, %curItem++ @ "Enable 1vs1s", "enable");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Disable 1vs1s", "disable");		
		Client::addMenuItem(%clientId, %curItem++ @ "Mute All", "muteall");
		Client::addMenuItem(%clientId, %curItem++ @ "Unmute All", "unmuteall");
		if($Dueling[%clientId])
		Client::addMenuItem(%clientId, %curItem++ @ "Abort 1vs1", "abort");
	}
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true);
	if(%clientId.selClient)
	{

      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Request 1vs1", "duel " @ %sel);
		if(!$Dueling[%clientId] && %clientId != %sel && $Dueling[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
		if(%clientId.blocked[%sel])
		Client::addMenuItem(%clientId, %curItem++ @ "Allow 1vs1 Requests", "allowrequests " @ %sel);	
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Block 1vs1 Requests", "blockrequests " @ %sel);
      if(%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			if(%clientId.isSuperAdmin)
			{
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
   }
	else if($curVoteTopic != "" && %clientId.vote == "")
	{
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   	  return;
	}

	if (!$Dueling[%clientId])
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{ 
			if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
				%num++;
		}
		if(%num == 1)
		{
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
 				if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
					Client::addMenuItem(%clientId, %curItem++ @ "Accept 1vs1: " @ Client::GetName(%cl), "acceptduel " @ %cl);
			}
		}
		else if(%num > 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Accept a duel...", "viewduels");
	}

	if($curVoteTopic == "" && !%clientId.isAdmin)
	{
		if(%clientId.selClient)
	      Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
   }
	else if(%clientId.isAdmin)
	{
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
}

function processMenuchooseweapon(%cl, %opt) {
	%weap = getword(%opt, 0);
	%num = getword(%opt, 1);
	%armor = %cl.achoice;
	if(%weap == "more") {
		%i = getword(%opt, 2);
		WeaponSetup(%cl, %num, %i);
		return;
	}
	$DuelWeaponSetup[%cl, %armor, %num] = %weap;
	%num++;
	if(%num == $MaxWeapons[%armor])
	{
		if ($DuelPackSetup[%cl] == "") $DuelPackSetup[%cl, %armor] = 1;
		if(%armor == darmor)
		{
			bottomprint(%cl,"<jc><f1>Your weapon setup is <f2>" @ 
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 0]] @ "<f1>, <f2>" @
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 1]] @ "<f1>, <f2>" @
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 2]] @ "<f1>, and <f2>" @
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 3]] @ "<f1>.\nYour pack setup is a <f2>" @
			$DuelPack[%armor, $DuelPackSetup[%cl, %armor]] @ "<f1>.", 10);
		}
		else if(%armor == spyarmor)
		{
			bottomprint(%cl,"<jc><f1>Your weapon setup is <f2>" @ 
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 0]] @ "<f1>, <f2>" @
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 1]] @ "<f1>, and <f2>" @
			$DuelWeapon[%armor, $DuelWeaponSetup[%cl, %armor, 2]] @ "<f1>.\nYour pack setup is a <f2>" @
			$DuelPack[%armor, $DuelPackSetup[%cl, %armor]] @ "<f1>.", 10);
		}
		return;
	}
	WeaponSetup(%cl, %num, 0);
}

function WeaponSetup(%clientId, %num, %i) {
	%armor = %clientId.achoice;
	%w1 = $DuelWeaponSetup[%clientId, %armor, 0];
	%w2 = $DuelWeaponSetup[%clientId, %armor, 1];
	%w3 = $DuelWeaponSetup[%clientId, %armor, 2];
	Client::buildMenu(%clientId, "Select your weapons (" @ ($MaxWeapons[%armor] - %num) @ " left):", "chooseweapon", true);
	while(true) {
		%i++;
		if(%i != %w1 && %i != %w2 && %i != %w3) {
			%t++;
			Client::addMenuItem(%clientId, %t @ $DuelWeapon[%armor, %i], %i @ " " @ %num);
		}
		if(%t == 7 || %i == $DuelWeaponMax[%armor]) break;
	}
	if(%i < $DuelWeaponMax[%armor])
		Client::addMenuItem(%clientId, "8More...", "more " @ %num @ " " @ %i);
}
                                    
function PackSetup(%clientId) {
	%armor = %clientId.achoice;
	Client::buildMenu(%clientId, "Select your pack:", "choosepack", true);
	for (%i = 1;%i <= $DuelPackMax[%armor];%i++)
		Client::addMenuItem(%clientId, %i @ $DuelPack[%armor, %i], %i);
}

function getEfficiencyRatio(%clientId) {
	%ratio = floor(($clientScore[%clientId]/($clientScore[%clientId] + %clientId.scoreDeaths))*100);
	if (%ratio > 0)
		return %ratio;
	else 
		return "0";
}

function processMenuchoosepack(%clientID, %option) {
	%armor = %clientId.achoice;
	$DuelPackSetup[%clientID, %armor ] = %option;
	if(%armor == darmor)
	{
		if (!$DuelWeaponSetup[%clientId, %armor, 0])
			$DuelWeaponSetup[%clientId, %armor, 0] = 4;
		if (!$DuelWeaponSetup[%clientId, %armor, 1])
			$DuelWeaponSetup[%clientId, %armor, 1] = 2;
		if (!$DuelWeaponSetup[%clientId, %armor, 2])
			$DuelWeaponSetup[%clientId, %armor, 2] = 7;
		if (!$DuelWeaponSetup[%clientId, %armor, 3])
			$DuelWeaponSetup[%clientId, %armor, 3] = 1;
		bottomprint(%clientID,"<jc><f1>Your weapon setup is <f2>" @ 
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 0]] @ "<f1>, <f2>" @
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 1]] @ "<f1>, <f2>" @
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 2]] @ "<f1>, and <f2>" @
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 3]] @ "<f1>.\nYour pack setup is a <f2>" @
		$DuelPack[%armor, $DuelPackSetup[%clientID, %armor]] @ "<f1>.", 10);
	}
	else if(%armor == spyarmor)
	{
		if (!$DuelWeaponSetup[%clientId, %armor, 0])
			$DuelWeaponSetup[%clientId, %armor, 0] = 1;
		if (!$DuelWeaponSetup[%clientId, %armor, 1])
			$DuelWeaponSetup[%clientId, %armor, 1] = 2;
		if (!$DuelWeaponSetup[%clientId, %armor, 2])
			$DuelWeaponSetup[%clientId, %armor, 2] = 3;

		$DuelWeaponSetup[%clientId, %armor, 3] = 0;
		bottomprint(%clientID,"<jc><f1>Your weapon setup is <f2>" @ 
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 0]] @ "<f1>, <f2>" @
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 1]] @ "<f1>, <f2>" @
		$DuelWeapon[%armor, $DuelWeaponSetup[%clientID, %armor, 2]] @ "<f1>.\nYour pack setup is a <f2>" @
		$DuelPack[%armor, $DuelPackSetup[%clientID, %armor]] @ "<f1>.", 10);
	}
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
	%armor = %clientId.achoice;

	if(%opt == "removeadmin") { 
		if(!%clientId.isSuperAdmin || (%cl != %clientId && %cl.isSuperAdmin) || Client::getName(%cl) == "")
			return;
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
	if(%opt == "observe") {               
		if($Dueling[%clientId] || Client::getOwnedObject(%clientId) != -1)
			return;
		%clientId.observerMode = "observerOrbit";
		Observer::setTargetClient(%clientId, %cl);
  		return;
	}
	if (%opt == "blockrequests") {
		%clientId.blocked[%cl] = true;
		return;
	}
	if (%opt == "allowrequests") {
		%clientId.blocked[%cl] = false;
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
	if (%opt == "muteall") {
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%clientId.muted[%id] = true;
		}
		return;
	}
	if (%opt == "abort") {
		if(!$Dueling[%clientId])
			return;
		EndDuel(%clientId);
		$teamScore[Client::getTeam(%clientId)] = 0;
		$teamScore[Client::getTeam($Dueling[%clientId])] = 0;
		return;
	}
	if (%opt == "unmuteall") {
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%clientId.muted[%id] = false;
		}
		return;
	}
	if (%opt == "disable") {
		$DuelsDisabled[%clientId] = true;
		return;
	}
	if (%opt == "enable") {
		$DuelsDisabled[%clientId] = false;
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
	if(%opt == "duel") { 
		DuelPropose(%clientId, %cl, false);
		return;
	}

   if(%opt == "fteamchange" && %clientId.isAdmin)
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
      if(%clientId.isAdmin && (!$matchStarted || !$Server::TourneyMode))
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
      if(!$VoteAdminAllowed)
         Client::sendMessage(%clientId, 1, "Try again smarty pants.");
      else
      {
         %cl.voteTarget = true;
         Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
      }
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
         if($clientScore[%clientList[%i]] < $clientScore[%clientList[%i + 1]])
         {
            %hold = %clientList[%i];
            %clientList[%i] = %clientList[%i+1];
            %clientList[%i+1]= %hold;
            %doIt=1;
         }
      }
   }      
	%topscore = $clientScore[%clientList[0]];
	if(%topscore > 1) {
		if($clientScore[%clientList[1]] == $clientScore[%clientList[0]]) {
			if($clientScore[%clientList[1]] == $clientScore[%clientList[2]]) {
				if($clientScore[%clientList[2]] == $clientScore[%clientList[3]]) {
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
	 		Team::setObjective(%x, %lineNum++, "<jc><f5>Final 1vs1 Statistics");
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
			Team::setObjective(%x, %lineNum++, "<L36>Wins\t\tLoses\t\tRatio\t\tStreak\t\tFastest Win");					 
			%c = 0;
			while(%c < %numClients) {
				(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);
	 			Team::setObjective(%x, %lineNum++, "<L2><f2>"@(%c + 1) @ ". " @ Client::getName(%clientList[%c]) @ "<L36><f0>" @ $clientScore[%clientList[%c]] @ "\t\t\t" @ (%clientList[%c]).ScoreDeaths @ "\t\t\t\t" @ (%clientList[%c]).ratio @ "%\t\t\t" @ $HighStreak[%clientList[%c]] @ "\t\t\t\t" @ $DuelBestDisplay[%clientList[%c]]);
				%c++;
			}  
	 	   	for(%s = %lineNum + 1; %s < 30 ; %s++)
	 	 		Team::setObjective(%x, %s, " ");
	 	}
	} else {
		for (%x = -1; %x < 2; %x++) {
			//messageall(0, "normal " @ %x);
		   	%lineNum = 0;
			Team::setObjective(%x, %lineNum++, "<jc><f5>1vs1 Statistics");
			Team::setObjective(%x, %lineNum++, "<f1>Mission Name: " @ $missionName); 
	 	  	Team::setObjective(%x, %lineNum++, "<f1>Mission Objectives:");
	 	  	Team::setObjective(%x, %lineNum++, "<f1>   -1vs1 other players!");
			Team::setObjective(%x, %lineNum++, " ");
			Team::setObjective(%x, %lineNum++, "<f1>Use the TAB menu to select a player and request a 1vs1.");
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
			Team::setObjective(%x, %lineNum++, "<L36>Wins\t\tLoses\t\tRatio\t\tStreak\t\tFastest Win");					 
			%c = 0;
			while(%c < %numClients) {
				(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);
	 			Team::setObjective(%x, %lineNum++, "<L2><f2>"@(%c + 1) @ ". " @ Client::getName(%clientList[%c]) @ "<L36><f0>" @ $clientScore[%clientList[%c]] @ "\t\t\t" @ (%clientList[%c]).ScoreDeaths @ "\t\t\t\t" @ (%clientList[%c]).ratio @ "%\t\t\t" @ $DuelStreak[%clientList[%c]] @ "\t\t\t\t" @ $DuelBestDisplay[%clientList[%c]]);
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
   Client::setScore(%clientId, "%n\t" @ %flag @ "\t" @ $clientScore[%clientId]  @ "\t%p\t%l", %team);
   DuelMOD::missionObjectives();
}

function Game::initialMissionDrop(%clientId) {  

	%clientId.menuMode = "";
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
	centerprint(%clientId, "<jc><f2>Press tab and select a player to 1vs1!!!\n\n<f1>" @ $Server::JoinMOTD @ "\n\n<jc><f2>Press tab and select a player to 1vs1!!!", 12);

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
		$clientScore[%cl] = 0;
   	  	Game::refreshClientScore(%cl);
   	}
   Game::checkTimeLimit();
}
                
function DuelMOD::restoreServerDefaults() {
	exec(baseprojdata);
   exec(admin);
   exec(player);
   exec(objectives);
   exec(observer);
   exec(game);
	exec("fb1vs1reset");
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
   $TCSuspect[%clientId] = false;
   $GlobalMute[%clientId] = false;

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f0>modded by Taserman\n<f1>Football 1vs1 Mod\n<f2>Orginal Props go to NateDog @ \n<f1>http://havoc.sirris.com");
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
        export("$Duel::Record*", "config\\1vs1Record.cs", False);
	}
}

function Server::onClientDisconnect(%clientId)
{
	if($InLineWith[%clientId] != "")
	dropOutOfLine(%clientId);
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}
	%foeId = $Dueling[%clientId];
		LoseFootball(%foeId);
		LoseFootball(%clientId);
	if($DuelSpotIndex[%clientId]==1)
{			
deleteObject($CurrentFootball1);
			$CurrentFootball1= "";
}
	else if($DuelSpotIndex[%clientId]==2)
{			
deleteObject($CurrentFootball2);
			$CurrentFootball2= "";
}
	else if($DuelSpotIndex[%clientId]==3)
{			
deleteObject($CurrentFootball3);
			$CurrentFootball3= "";
}
	else if($DuelSpotIndex[%clientId]==4)
{			
deleteObject($CurrentFootball4);
			$CurrentFootball4= "";
}
	if ($Dueling[%clientId]) {
		MessageAll(1, Client::GetName(%clientId) @ ": " @ $teamScore[GameBase::getTeam(%clientId)] @ " --- " @ Client::GetName(%foeId) @ ": " @ $teamScore[GameBase::getTeam(%foeId)]);
		MessageAll(1,Client::GetName($Dueling[%clientId]) @ " claims victory over " @ Client::GetName(%clientId) @ " due to opponent disconnect.");
		$clientScore[$Dueling[%clientId]]++;
		$teamScore[GameBase::getTeam(%clientId)] = 0;
		$teamScore[GameBase::getTeam($Dueling[%clientId])] = 0;
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
   	setClientScoreHeading("Player Name\t\x6FDueling\t\xA6Won\t\xCFPing\t\xEFPL");
   	setTeamScoreHeading("");

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	  	%cl.scoreDeaths = 0;
      	$clientScore[%cl] = 0;
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

function Client::onKilled(%playerId, %killerId, %damageType)
{
   echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
   %playerId.guiLock = true;
   Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
   {
      %playerGender = "his";
   }
	else
	{
		%playerGender = "her";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);


   if(!%killerId)
   {
      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      %playerId.scoreDeaths++;
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      Game::refreshClientScore(%playerId);
   }
   else
   {
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
      if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
		if(%damageType != $MineDamageType) 
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(0, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %killerId.scoreDeaths++;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);

	LoseFootball(%cl, drop);

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
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

//fb stuff
function ThrowFootball(%clientId, %vel)
{
	%rot = GameBase::getRotation(%clientId);
	%playervel = Item::getVelocity(%clientId);

	%zoffset = 0.25;

	%football = newObject("", "Item", Football, 1, false);
	%football.owner = %clientId;
	%football.rot = %rot;

	if($DuelSpotIndex[%clientId]==1)
	$CurrentFootball1 = %football;
	else if($DuelSpotIndex[%clientId]==2)
	$CurrentFootball2 = %football;
	else if($DuelSpotIndex[%clientId]==3)
	$CurrentFootball3 = %football;
	else if($DuelSpotIndex[%clientId]==4)
	$CurrentFootball4 = %football;

	%newrot = GetWord(%rot, 0) - %zoffset @ " " @ GetWord(%rot, 1) @ " " @ GetWord(%rot, 2);
	GameBase::setRotation(%clientId, %newrot);

	Item::setVelocity(%clientId, "0 0 0");
	GameBase::throw(%football, Client::getOwnedObject(%clientId), %vel, false);
	Item::setVelocity(%clientId, %playervel);

	GameBase::setRotation(%football, %rot);
	GameBase::setRotation(%clientId, %rot);
}

function FootballThrowerImage::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);
	%foeId = $Dueling[%clientId];

	if(Player::getItemCount(%clientId, "Football"))
	{
		%clientpos = GameBase::getPosition(%clientId);

		$los::object = 0;
		GameBase::getLOSinfo(%player, 8000, "0 0 0");
		if(getObjectType($los::object) == "Player")
		{
			%closestId = Player::getClient($los::object);
			%tpos = GameBase::getPosition(%closestId);
			%closest = Vector::getDistance(%tpos, %clientpos);

			%factor = sqrt(%closest) / 6.454;
			%vel = %closest / %factor;
		}
		else
		{
			%FOVpan = 0.15;
			%clientrot = GetWord(GameBase::getRotation(%clientId), 2);
			%id = %foeId;
				if(%id != %clientId && GameBase::getPosition(%id) != "0 0 0")
				{
					%vec = Vector::sub(GameBase::getPosition(%id), %clientpos);
					%vecRot = GetWord(Vector::getRotation(%vec), 2);
			
					if(%vecRot >= %clientrot - %FOVpan && %vecRot <= %clientrot + %FOVpan)
						%idList[%c++] = %id;
				}
			if(%idList[1] != "")
			{
				%closest = 500000;
				for(%i = 1; %idList[%i] != ""; %i++)
				{
					if(%foeId == %idList[%i]) {
					%dist = Vector::getDistance(%clientpos, GameBase::getPosition(%idList[%i]));
					if(%dist < %closest)
					{
						%closest = %dist;
						%closestId = %idList[%i];
					}
					}
				}
				%factor = sqrt(%closest) / 6.454;
				%vel = %closest / %factor;
			}
			else
				%vel = 35;
		}

		ThrowFootball(%clientId, %vel);
		LoseFootball(%clientId);

		%name = Client::getName(%clientId);
		if(%closestId)
		{
			%tname = Client::getName(%closestId);
			Client::sendMessage(%closestId, $MsgWhite, %name @ " passes the football in your direction.");
			Client::sendMessage(%clientId, $MsgWhite, "You pass the football in " @ %tname @ "'s direction.");
			Client::sendMessage(%closestId, $MsgWhite, "~wflag1.wav");
		}
		else {
			Client::sendMessage(%clientId, $MsgWhite, "You throw the football.");
			Client::sendMessage($Dueling[%clientId], $MsgWhite, %name @ " throws the football.");
		}
	}
}

function Boost(%clientId)
{
	%mom = Vector::getFromRot(GameBase::getRotation(%clientId), 70, 35);
	Player::applyImpulse(%clientId, %mom);
}

function getVelocity(%clientId)
{
	%v = Item::getVelocity(%clientId);
	%cv = round(getWord(%v, 0)) @ " " @ round(getWord(%v, 1)) @ " " @ round(getWord(%v, 2));
	if(%cv == "0 0 0")
		%v = %clientId.velocity;

	return %v;
}

function GroupTrigger::onTrigger(%object, %this)
{
	%clientId = Player::getClient(%this);
	%foeId = $Dueling[%clientId];
	%fteam = GameBase::getTeam(%foeId);
	%pteam = GameBase::getTeam(%clientId);
	%gteam = AppropriateSide(GameBase::getTeam(%object));

	if(%pteam != %gteam && Player::getItemCount(%clientId, Football))
	{
		$TackleFree[%clientId] = true;
		$TackleFree[%foeId] = true;
		%name = Client::getName(%clientId);
		%fname = Client::getName(%foeId);
		$teamScore[%pteam] += 1;
		Client::sendMessage(%foeId, $MsgWhite, %name @ " scored a touchdown!~wflagcapture.wav");
                echo("ADMINMSG: **** " @ %name @ " scored a touchdown.");//for TRICON compatibility
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
      		if(%id.observerTarget == %clientId || %id.observerTarget == %foeId) {
		//if(%id.observerMode = "observerOrbit") {
		Client::sendMessage(%id, $MsgRed, %name @ ": " @ $teamScore[%pteam] @ " --- " @ %fname @ ": " @ $teamScore[%fteam]);
		Client::sendMessage(%id, $MsgWhite, "~wflagcapture.wav");
		//}
		}
		}
		Client::sendMessage(%clientId, $MsgWhite, "~wflagcapture.wav");
		Client::sendMessage(%clientId, $MsgWhite, "You scored a touchdown!~wtouchdowncheer.wav");
		Client::sendMessage(%clientId, $MsgRed, %name @ ": " @ $teamScore[%pteam] @ " --- " @ %fname @ ": " @ $teamScore[%fteam]);
		Client::sendMessage(%foeId, $MsgRed, %fname @ ": " @ $teamScore[%fteam] @ " --- " @ %name @ ": " @ $teamScore[%pteam]);
		LoseFootball(%clientId);

		Game::refreshClientScore(%clientId);
		if($teamScore[%pteam] >= 10 && (($teamScore[%pteam] - 1) > $teamScore[%fteam])) {
		EndDuel(%foeId);
		$teamScore[%pteam] = 0;
		$teamScore[%fteam] = 0;	
		$TackleFree[%clientId] = false;	
		$TackleFree[%foeId] = false;
		}
		else {
		schedule("DoSpawnFootball(" @ %gteam @ ");", 10);
		schedule("SendPlayerToStart(" @ %foeId @ ");", 6);
		schedule("SendPlayerToStart(" @ %clientId @ ");", 6);
		schedule("$TackleFree[" @ %foeId @ "] = false;", 6);
		schedule("$TackleFree[" @ %clientId @ "] = false;", 6);
		}	
	}
   	setTeamScoreHeading("");
}

function GroupTrigger::onTrigLeave(%object, %this)
{
	%clientId = Player::getClient(%this);

	%pteam = GameBase::getTeam(%clientId);
	%gteam = GameBase::getTeam(%object);
}

function SpawnFootball(%team)
{
	if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 0;
		else
			%team = 1;
	}

	%football = newObject("", "Item", Football, 1, false);
	%football.owner = -1;
	%football.rot = "0 0 0";

	if(%team==0 || %team==1)	
	$CurrentFootball1 = %football;
	else if(%team==2 || %team==3)	
	$CurrentFootball2 = %football;
	else if(%team==4 || %team==5)	
	$CurrentFootball3 = %football;
	else if(%team==6 || %team==7)	
	$CurrentFootball4 = %football;



	%marker = nameToId("MissionGroup/Teams/team" @ AppropriateSide(%team) @ "/FootballSpawn");
	GameBase::setPosition(%football, GameBase::getPosition(%marker));

	RefreshObserveFootball();
}
function Item::onCollision(%this,%object)
{
	%clientId = Player::getClient(%object);

	if(getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);

            if(%item == Football)
            {
			if(!%clientId.tackled)
			{
				%armor = GameBase::getDataName(%object);
				%vel = Vector::getDistance(Item::getVelocity(%this), "0 0 0") * 2.0;
				%mom = Vector::getFromRot( %this.rot, %vel * (6.5 / %armor.mass), 1 );
				Player::applyImpulse(%clientId, %mom);
	
				GainFootball(%clientId);
				Item::playPickupSound(%this);
	
				%fteam = GameBase::getTeam(%this.owner);
				%pteam = GameBase::getTeam(%clientId);
				%name = Client::getName(%clientId);
	
				if(%fteam == -1 || floor(%vel / 2.2) == 0)
					TeamMessages($MsgWhite, %pteam, %name @ " picks up the football.", %fteam, %name @ " picked up the football.");
				else if(%fteam != %pteam)
					TeamMessages($MsgRed, %pteam, %name @ " intercepts the football!~wflagreturn.wav", %fteam, %name @ " intercepted the ball.");
				else
					TeamMessages($MsgWhite, %pteam, %name @ " catches the ball.", %fteam, %name @ " caught the football.");
	
				deleteObject(%this);
			}
		}
		else
		{
			if(Item::giveItem(%object,%item,Item::getCount(%this)))
			{
				Item::playPickupSound(%this);
				Item::respawn(%this);
			}
		}
	}
}

function DropFootball(%clientId, %random)
{
	//This function should only be invoked by LoseFootball.

	if(Player::getItemCount(%clientId, Football))
	{
		%oldrot = GameBase::getRotation(%clientId);

		if(%random)
			%rot = "0 -0 " @ (getRandom() * 6.28) - 3.14;
		else
			%rot = GameBase::getRotation(%clientId);
	
		%football = newObject("", "Item", Football, 1, false);
		%football.owner = %clientId;
		%football.rot = %rot;
	
	if($DuelSpotIndex[%clientId]==1)
	$CurrentFootball1 = %football;
	else if($DuelSpotIndex[%clientId]==2)
	$CurrentFootball2 = %football;
	else if($DuelSpotIndex[%clientId]==3)
	$CurrentFootball3 = %football;
	else if($DuelSpotIndex[%clientId]==4)
	$CurrentFootball4 = %football;
	


		GameBase::setRotation(%clientId, %rot);	
		GameBase::throw(%football, Client::getOwnedObject(%clientId), 10, false);
		Player::decItemCount(%clientId, Football);
		Item::playPickupSound(%football);
		GameBase::setRotation(%clientId, %oldrot);
	}
}

function GainFootball(%clientId)
{
	Player::incItemCount(%clientId, Football);
	if($DuelSpotIndex[%clientId]==1)
	$CurrentFootball1 = "";
	else if($DuelSpotIndex[%clientId]==2)
	$CurrentFootball2 = "";
	else if($DuelSpotIndex[%clientId]==3)
	$CurrentFootball3 = "";
	else if($DuelSpotIndex[%clientId]==4)
	$CurrentFootball4 = "";

	if(Player::getItemCount(%clientId, Football))
	{
		%player = Client::getOwnedObject(%clientId);

		Player::mountItem(%player, Flag, $FlagSlot, 0);

		%e = GameBase::getEnergy(%player);
		if(Client::getGender(%clientId) == "Male")
			Player::setArmor(%clientId, clarmor);
		else if(Client::getGender(%clientId) == "Female")
			Player::setArmor(%clientId, clfemale);
		GameBase::setEnergy(%player, %e);
	}

	RefreshObserveFootball();
}

function LoseFootball(%clientId, %action)
{
	if(Player::getItemCount(%clientId, Football))
	{
		if(%action == drop)
			DropFootball(%clientId, False);
		else if(%action == fumble)
			DropFootball(%clientId, True);
		else
			Player::decItemCount(%clientId, Football);

		if(Player::getItemCount(%clientId, Football) == 0)
		{
			%player = Client::getOwnedObject(%clientId);

			Player::unMountItem(%player, $FlagSlot);

			%e = GameBase::getEnergy(%player);
			if(Client::getGender(%clientId) == "Male")
				Player::setArmor(%clientId, larmor);
			else if(Client::getGender(%clientId) == "Female")
				Player::setArmor(%clientId, lfemale);
			GameBase::setEnergy(%player, %e);

			//Getting weird ghosting, maybe this could be a solution...
			Player::mountItem(%player, Flag, $FlagSlot, 0);
			Player::unMountItem(%player, $FlagSlot);
		}
	}

	RefreshObserveFootball();
}

function DoSpawnFootball(%team)
{
	%clientId = "";
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		if(Client::getTeam(%id) == %team)
		%clientId = %id;
	}
	if(Client::getTeam(%clientId) != "" && Client::getTeam(%clientId) != -1) {
	if(%team == 0) {
	%fbexist = $CurrentFootball1;
	%fteam = 1;
	}
	else if(%team == 1) {
	%fbexist = $CurrentFootball1;
	%fteam = 0;
	}
	else if(%team == 2) {
	%fbexist = $CurrentFootball2;
	%fteam = 3;
	}
	else if(%team == 3) {
	%fbexist = $CurrentFootball2;
	%fteam = 2;
	}
	else if(%team == 4) {
	%fbexist = $CurrentFootball3;
	%fteam = 5;
	}
	else if(%team == 5) {
	%fbexist = $CurrentFootball3;
	%fteam = 4;
	}
	else if(%team == 6) {
	%fbexist = $CurrentFootball4;
	%fteam = 7;
	}
	else if(%team == 7) {
	%fbexist = $CurrentFootball4;
	%fteam = 6;
	}

	if(%fbexist == "")
	{
		SpawnFootball(%team);
		TeamMessages($MsgWhite, %team, "A new ball spawns.~wshortwhistle.wav", %fteam, "A new ball spawns.~wshortwhistle.wav");

		return True;
	}
	else
		return False;
	}
}

function SendPlayerToStart(%id)
{
	%team = GameBase::getTeam(%id);
	%dp = Game::pickRandomSpawn(%team);
	%player = Client::getOwnedObject(%id);
	if(GameBase::getPosition(%dp) != GameBase::getPosition(%clientId) && %player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {

		Item::setVelocity(%id, "0 0 0");
		GameBase::setPosition(%id, GameBase::getPosition(%dp));
		GameBase::startFadeIn(%id);
		Player::setDamageFlash(%id, 0.35);

		%armor = GameBase::getDataName(%id);
		GameBase::setEnergy(%player, %armor.maxEnergy);
		GameBase::setDamageLevel(%player, 0);
	}	
}


function SendPlayersToStart()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		%dp = Game::pickRandomSpawn(%team);

		Item::setVelocity(%id, "0 0 0");
		GameBase::setPosition(%id, GameBase::getPosition(%dp));
		GameBase::startFadeIn(%id);
		Player::setDamageFlash(%id, 0.35);

		%armor = GameBase::getDataName(%id);
		%pl = Client::getOwnedObject(%id);
		GameBase::setEnergy(%pl, %armor.maxEnergy);
		GameBase::setDamageLevel(%pl, 0);
	}
}

function Player::onCollision(%this, %object)
{
	if (Player::isDead(%this)) {
		if(getObjectType(%object) == "Player") {
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
	}
	else
	{
		if(getObjectType(%object) == "Player")
		{
			%id1 = Player::getClient(%this);
			%id2 = Player::getClient(%object);

			if(GameBase::getTeam(%id1) != GameBase::getTeam(%id2))
			{
				//The .SecondEventCall is a little workaround so only the second event
				//of onCollision between two players gets called.
				if( %id1.SecondEventCall == %id2 && %id2.SecondEventCall == %id1 )
				{
					if( !(%id1.tackled || %id2.tackled) )
					{
						%vel[%id1] = getVelocity(%id1);
						%vel[%id2] = getVelocity(%id2);

						%totalVel = round(Vector::getDistance("0 0 0", Vector::sub(%vel[%id1], %vel[%id2])));

						//exchange vectors
						if($elasticity == "")
							%e = 1.0;
						else
							%e = $elasticity;
						%newvel1 = GetWord(%vel[%id2], 0) * %e @ " " @ GetWord(%vel[%id2], 1) * %e @ " " @ GetWord(%vel[%id2], 2) * %e;
						%newvel2 = GetWord(%vel[%id1], 0) * %e @ " " @ GetWord(%vel[%id1], 1) * %e @ " " @ GetWord(%vel[%id1], 2) * %e;
						Item::setVelocity(%id1, %newvel1);
						Item::setVelocity(%id2, %newvel2);

						//determine who hit hardest
						%absvel[%id1] = round(Vector::getDistance("0 0 0", %vel[%id1]));
						%absvel[%id2] = round(Vector::getDistance("0 0 0", %vel[%id2]));

						if(%absvel[%id1] > %absvel[%id2])
						{
							%status[%id1] = "tackle";
							%status[%id2] = "q0wned";
						}
						else if(%absvel[%id1] < %absvel[%id2])
						{
							%status[%id1] = "q0wned";
							%status[%id2] = "tackle";
						}
						else if(%absvel[%id1] == %absvel[%id2])
						{
							%status[%id1] = "q0wned";
							%status[%id2] = "q0wned";
						}
						
						%involved[1] = %id1;
						%involved[2] = %id2;
						%otherId[%id1] = %id2;
						%otherId[%id2] = %id1;

						for(%i = 1; %i <= 2; %i++)
						{
							%id = %involved[%i];
							%oid = %otherId[%id];
							//messageAll($MsgGreen, "Abs Vel for " @ Client::getName(%id) @ ": " @ %absvel[%id]);
							//messageAll($MsgGreen, "Abs Vel for " @ Client::getName(%oid) @ ": " @ %absvel[%oid]);
							//messageAll($MsgGreen, "Status for " @ Client::getName(%id) @ ": " @ %status[%id]);
							//messageAll($MsgGreen, "Status for " @ Client::getName(%oid) @ ": " @ %status[%oid]);
							//messageAll($MsgGreen, "Total Vel: " @ %totalVel);

							if(%status[%id] == "q0wned")
							{
								if(Player::getItemCount(%id, Football))
								{
									//-----------------
									//  FUMBLE
									//-----------------
									if(%totalVel >= 2 && %totalVel < 15)
									{
										LoseFootball(%id, fumble);
			
										Client::sendMessage(%id, $MsgRed, Client::getName(%oid) @ " made you fumble!~wgrunt.wav");
										Client::sendMessage(%oid, $MsgWhite, "You made " @ Client::getName(%id) @ " fumble!");
									}
								}
								if(%totalVel >= 15 && !$TackleFree[%id])
								{
									//-----------------
									//  TACKLE
									//-----------------
									if(Player::getItemCount(%id, Football))
									{
										LoseFootball(%id, fumble);
										Game::refreshClientScore(%oid);
									}
		
									%pid = Client::getOwnedObject(%id);
			
									Player::setAnimation(%id, 33);

									//cause damage
							            %dlevel = GameBase::getDamageLevel(%pid) + 0.2;
									GameBase::setDamageLevel(%pid, %dlevel);
									%flash = Player::getDamageFlash(%pid) + %value * 2;
									Player::setDamageFlash(%pid, %flash);
									if(!Player::isDead(%pid))
									{
										%id.tackled = True;
										Client::setControlObject(%id, Client::getObserverCamera(%id));
										Observer::setOrbitObject(%id, %pid, -8, -8, -8);

										schedule("Client::setControlObject(" @ %id @ ", " @ %id @ ");", 2);
										schedule(%id @ ".tackled = \"\";", 2);
										schedule("GameBase::setEnergy(" @ %pid @ ", 0);", 2);
									}
			
									Client::sendMessage(%id, $MsgRed, Client::getName(%oid) @ " tackled you!");
									Client::sendMessage(%oid, $MsgWhite, "You tackled " @ Client::getName(%id) @ "!");
								}
							}
						}
					}
				}
				else
				{
					%id1.SecondEventCall = %id2;
					%id2.SecondEventCall = %id1;
					schedule(%id1 @ ".SecondEventCall = \"\";", 0.1);
					schedule(%id2 @ ".SecondEventCall = \"\";", 0.1);
				}
			}
		}
	}
}

function GetNESW(%pos1, %pos2)
{
	%v1 = Vector::sub(%pos1, %pos2);
	%v2 = Vector::getRotation(%v1);
	%a = GetWord(%v2, 2);

	if(%a >= 2.7475 && %a <= 3.15 || %a >= -3.15 && %a <= -2.7475)
		%d = "North";
	else if(%a >= 1.9625 && %a <= 2.7475)
		%d = "North East";
	else if(%a >= 1.1775 && %a <= 1.9625)
		%d = "East";
	else if(%a >= 0.3925 && %a <= 1.1775)
		%d = "South East";
	else if(%a >= -0.3925 && %a <= 0.3925)
		%d = "South";
	else if(%a >= -1.1775 && %a <= -0.3925)
		%d = "South West";
	else if(%a >= -1.9625 && %a <= -1.1775)
		%d = "West";
	else if(%a >= -2.7475 && %a <= -1.9625)
		%d = "North West";

	return %d;
}

function WhereIsFootball(%clientId)
{
	if($DuelSpotIndex[%clientId]==1)
	%ball = $CurrentFootball1;
	else if($DuelSpotIndex[%clientId]==2)
	%ball = $CurrentFootball2;
	else if($DuelSpotIndex[%clientId]==3)
	%ball = $CurrentFootball3;
	else if($DuelSpotIndex[%clientId]==4)
	%ball = $CurrentFootball4;
	
	if(%ball)
	{
		%pos1 = GameBase::getPosition(%clientId);
		%pos2 = GameBase::getPosition(%ball);
		%dist = Vector::getDistance(%pos1, %pos2);
		%d = GetNESW(%pos1, %pos2);
		Client::sendMessage(%clientId, 0, "The football is " @ %dist @ " yards " @ %d @ " of you.");
	}
	else
		Client::sendMessage(%clientId, 0, "The ball is not missing.");
}

function RecursiveWorld(%seconds)
{
//football4
	$ticker[1] = floor($ticker[1]+1);
	$ticker[2] = floor($ticker[2]+1);
	$ticker[3] = floor($ticker[3]+1);
	$ticker[4] = floor($ticker[4]+1);

	if($ticker[1] >= 1)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			%id.velocity = Item::getVelocity(%id);

		$ticker[1] = 0;
	}
	if($ticker[2] >= 150)
	{
		if(GetWord(Item::getVelocity($CurrentFootball4), 2) < -500)
		{
			%team = OppositeTeam(GameBase::getTeam($CurrentFootball4.owner));
			deleteObject($CurrentFootball4);
			$CurrentFootball4= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 6;
		else
			%team = 7;
	}


			DoSpawnFootball(%team);
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 6 || %team == 7)
		SendPlayerToStart(%id);

	}

		}
		$ticker[2] = 0;
	}
	if($ticker[3] >= 10)
	{
		if($CurrentFootball4)
		{
			if(GameBase::getPosition($CurrentFootball4) == $footballLastPos)
			{
				$internalTicker[3]++;
				
				%delay = 20;
				if($internalTicker[3] >= %delay)
				{
					TeamMessages($MsgWhite, 6, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav", 7, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav");
					if($CurrentFootball4.owner=="")
					%team = OppositeTeam(GameBase::getTeam($CurrentFootball4.owner));
					deleteObject($CurrentFootball4);
					$CurrentFootball4= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 6;
		else
			%team = 7;
	}
					DoSpawnFootball(%team);
					for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
					{
						%rteam = GameBase::getTeam(%id);
						if(%rteam == 6 || %rteam == 7)
						SendPlayerToStart(%id);

					}


					$internalTicker[3] = 0;
				}
			}
			else
			{
				$footballLastPos = GameBase::getPosition($CurrentFootball4);
				$internalTicker[3] = 0;
			}
		}
		$ticker[3] = 0;
	}
	if($ticker[4] >= 10)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%player = Client::getOwnedObject(%id);
			if(%player.outArea == 1)
			{
				Client::sendMessage(%id, $MsgRed, "You're out of bounds!~woob.wav");
				%value = 0.065;

		            %dlevel = GameBase::getDamageLevel(%player) + %value;
				GameBase::setDamageLevel(%player, %dlevel);
				%flash = Player::getDamageFlash(%player) + %value * 2;
				Player::setDamageFlash(%player, %flash);

				if(Player::isDead(%player))
					Player::blowUp(%player);
			}
		}

		$ticker[4] = 0;
	}
//football3
$ticker[5] = floor($ticker[5]+1);
	$ticker[6] = floor($ticker[6]+1);
	$ticker[7] = floor($ticker[7]+1);
	$ticker[8] = floor($ticker[8]+1);

	if($ticker[5] >= 1)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			%id.velocity = Item::getVelocity(%id);

		$ticker[5] = 0;
	}
	if($ticker[6] >= 150)
	{
		if(GetWord(Item::getVelocity($CurrentFootball3), 2) < -500)
		{
			%team = OppositeTeam(GameBase::getTeam($CurrentFootball3.owner));
			deleteObject($CurrentFootball3);
			$CurrentFootball3= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 4;
		else
			%team = 5;
	}

			DoSpawnFootball(%team);
				for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 4 || %team == 5)
		SendPlayerToStart(%id);

	}
		}
		$ticker[6] = 0;
	}
	if($ticker[7] >= 10)
	{
		if($CurrentFootball3)
		{
			if(GameBase::getPosition($CurrentFootball3) == $footballLastPos)
			{
				$internalTicker[7]++;
				
				%delay = 20;
				if($internalTicker[7] >= %delay)
				{
					TeamMessages($MsgWhite, 4, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav", 5, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav");
					%team = OppositeTeam(GameBase::getTeam($CurrentFootball3.owner));
					deleteObject($CurrentFootball3);
					$CurrentFootball3= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 4;
		else
			%team = 5;
	}

					DoSpawnFootball(%team);
						for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 4 || %team == 5)
		SendPlayerToStart(%id);

	}

					$internalTicker[7] = 0;
				}
			}
			else
			{
				$footballLastPos = GameBase::getPosition($CurrentFootball3);
				$internalTicker[7] = 0;
			}
		}
		$ticker[7] = 0;
	}
	if($ticker[8] >= 10)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%player = Client::getOwnedObject(%id);
			if(%player.outArea == 1)
			{
				Client::sendMessage(%id, $MsgRed, "You're out of bounds!~woob.wav");
				%value = 0.065;

		            %dlevel = GameBase::getDamageLevel(%player) + %value;
				GameBase::setDamageLevel(%player, %dlevel);
				%flash = Player::getDamageFlash(%player) + %value * 2;
				Player::setDamageFlash(%player, %flash);

				if(Player::isDead(%player))
					Player::blowUp(%player);
			}
		}

		$ticker[8] = 0;
	}
//fooball2
$ticker[9] = floor($ticker[9]+1);
	$ticker[10] = floor($ticker[10]+1);
	$ticker[11] = floor($ticker[11]+1);
	$ticker[12] = floor($ticker[12]+1);

	if($ticker[9] >= 1)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			%id.velocity = Item::getVelocity(%id);

		$ticker[9] = 0;
	}
	if($ticker[10] >= 150)
	{
		if(GetWord(Item::getVelocity($CurrentFootball2), 2) < -500)
		{
			%team = OppositeTeam(GameBase::getTeam($CurrentFootball2.owner));
			deleteObject($CurrentFootball2);
			$CurrentFootball2= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 2;
		else
			%team = 3;
	}

			DoSpawnFootball(%team);
				for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 2 || %team == 3)
		SendPlayerToStart(%id);

	}
		}
		$ticker[10] = 0;
	}
	if($ticker[11] >= 10)
	{
		if($CurrentFootball2)
		{
			if(GameBase::getPosition($CurrentFootball2) == $footballLastPos)
			{
				$internalTicker[11]++;
				
				%delay = 20;
				if($internalTicker[11] >= %delay)
				{
					TeamMessages($MsgWhite, 2, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav", 3, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav");
					%team = OppositeTeam(GameBase::getTeam($CurrentFootball2.owner));
					deleteObject($CurrentFootball2);
					$CurrentFootball2= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 2;
		else
			%team = 3;
	}

					DoSpawnFootball(%team);
						for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 2 || %team == 3)
		SendPlayerToStart(%id);

	}

					$internalTicker[11] = 0;
				}
			}
			else
			{
				$footballLastPos = GameBase::getPosition($CurrentFootball2);
				$internalTicker[11] = 0;
			}
		}
		$ticker[11] = 0;
	}
	if($ticker[12] >= 10)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%player = Client::getOwnedObject(%id);
			if(%player.outArea == 1)
			{
				Client::sendMessage(%id, $MsgRed, "You're out of bounds!~woob.wav");
				%value = 0.065;

		            %dlevel = GameBase::getDamageLevel(%player) + %value;
				GameBase::setDamageLevel(%player, %dlevel);
				%flash = Player::getDamageFlash(%player) + %value * 2;
				Player::setDamageFlash(%player, %flash);

				if(Player::isDead(%player))
					Player::blowUp(%player);
			}
		}

		$ticker[12] = 0;
	}
//football1
$ticker[13] = floor($ticker[13]+1);
	$ticker[14] = floor($ticker[14]+1);
	$ticker[15] = floor($ticker[15]+1);
	$ticker[16] = floor($ticker[16]+1);

	if($ticker[13] >= 1)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
			%id.velocity = Item::getVelocity(%id);

		$ticker[13] = 0;
	}
	if($ticker[14] >= 150)
	{
		if(GetWord(Item::getVelocity($CurrentFootball1), 2) < -500)
		{
			%team = OppositeTeam(GameBase::getTeam($CurrentFootball1.owner));
			deleteObject($CurrentFootball1);
			$CurrentFootball1= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 0;
		else
			%team = 1;
	}

			DoSpawnFootball(%team);
				for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 0 || %team == 1)
		SendPlayerToStart(%id);

	}
		}
		$ticker[14] = 0;
	}
	if($ticker[15] >= 10)
	{
		if($CurrentFootball1)
		{
			if(GameBase::getPosition($CurrentFootball1) == $footballLastPos)
			{
				$internalTicker[15]++;
				
				%delay = 20;
				if($internalTicker[15] >= %delay)
				{
					TeamMessages($MsgWhite, 0, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav", 1, "The football respawned after " @ %delay @ " seconds of inactivity.~wfoghorn.wav");
					%team = OppositeTeam(GameBase::getTeam($CurrentFootball1.owner));
					deleteObject($CurrentFootball1);
					$CurrentFootball1= "";

if(%team == "" || %team == -1)
	{
		%x = floor(getRandom() * 100);
		if(%x < 50)
			%team = 0;
		else
			%team = 1;
	}

					DoSpawnFootball(%team);
						for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		%team = GameBase::getTeam(%id);
		if(%team == 0 || %team == 1)
		SendPlayerToStart(%id);

	}

					$internalTicker[15] = 0;
				}
			}
			else
			{
				$footballLastPos = GameBase::getPosition($CurrentFootball1);
				$internalTicker[15] = 0;
			}
		}
		$ticker[15] = 0;
	}
	if($ticker[16] >= 10)
	{
		for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		{
			%player = Client::getOwnedObject(%id);
			if(%player.outArea == 1)
			{
				Client::sendMessage(%id, $MsgRed, "You're out of bounds!~woob.wav");
				%value = 0.065;

		            %dlevel = GameBase::getDamageLevel(%player) + %value;
				GameBase::setDamageLevel(%player, %dlevel);
				%flash = Player::getDamageFlash(%player) + %value * 2;
				Player::setDamageFlash(%player, %flash);

				if(Player::isDead(%player))
					Player::blowUp(%player);
			}
		}

		$ticker[16] = 0;
	}
	schedule("RecursiveWorld(" @ %seconds @ ");", %seconds);
}
	
function WhoHasFootball()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		if(Player::getItemCount(%id, Football))
			return %id;
	}
	return -1;
}

function ObserveFootball(%clientId)
{
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));

	if($DuelSpotIndex[%clientId]==1)
	{
	if($CurrentFootball1)
		Observer::setOrbitObject(%clientId, $CurrentFootball1, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);
	}
	else if($DuelSpotIndex[%clientId]==2)
	{
	if($CurrentFootball2)
		Observer::setOrbitObject(%clientId, $CurrentFootball2, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);
	}
	else if($DuelSpotIndex[%clientId]==3)
	{
	if($CurrentFootball3)
		Observer::setOrbitObject(%clientId, $CurrentFootball3, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);
	}	
	else if($DuelSpotIndex[%clientId]==4)
	{
		if($CurrentFootball4)
		Observer::setOrbitObject(%clientId, $CurrentFootball4, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);
	}
	else
	{
	if($CurrentFootball)
		Observer::setOrbitObject(%clientId, $CurrentFootball, 10, 10, 10);
	else
		Observer::setOrbitObject(%clientId, WhoHasFootball(), 10, 10, 10);
	}
}

function RefreshObserveFootball()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
	{
		if(%id.observerMode == "observerFootball")
			ObserveFootball(%id);
	}
}
function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if((%item.className != Armor) && (%item.className != Football)) {
			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else {
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the stadium area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the stadium area.");
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Stadium: <f1>" @ $missionName @ "   <f0>Stadium Class: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives and mod rules.", 5);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   {
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}

	GameBase::setRechargeRate(%pl, $rechargeRate[Player::getArmor(%clientId)]);

	bottomprint(%clientId, "To locate a football on the loose, type #where. Hit the 'o' key for full game instructions.", 10);
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}
function processMenuInitialPickTeam(%clientId, %team)
{
   if($Dueling[%clientId])
      return;
   %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>Left-click when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function remoteKill(%client)
{
	if(!$matchStarted)
		return;

	%player = Client::getOwnedObject(%client);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && !%client.blockCtrlK)
	{
		%delay = 15;
		Client::sendMessage(%client, $MsgRed, "You will die " @ %delay @ " seconds.");
		schedule("playNextAnim(" @ %client @ ");Player::kill(" @ %client @ ");Client::onKilled(" @ %client @ "," @ %client @ ");", %delay, %player);
		schedule(%client @ ".blockCtrlK = \"\";", %delay);
		%client.blockCtrlK = True;
	}
}
function getInLine(%clientId, %foeId) {
	$InLineWith[%clientId] = %foeId;
	$InLineWith[%foeId] = %clientId;
	%i = 1;
	while($LineSpot[%i] != "")
		%i++;
	$LineSpot[%i] = %clientId;
	$LineSpot[%i + 1] = %foeId;
	getLinePosition(%clientId);
	getLinePosition(%foeId);
}
function moveLineDown() {
	if($LineSpot[1] != "") {
		DuelInit($LineSpot[2], $LineSpot[1]);
		$InLineWith[$LineSpot[1]] = "";
		$InLineWith[$LineSpot[2]] = "";
		$LineSpot[1] = "";
		$LineSpot[2] = "";
		for(%i = 1; $LineSpot[%i] == ""; %i++) {
		$LineSpot[%i] = $LineSpot[%i + 2];
		getLinePosition($LineSpot[%i]);
		}
	}
}
function dropOutOfLine(%clientId) {
	%foeId = $InLineWith[%clientId];
	for(%i = 1; $LineSpot[%i] == ""; %i++) {
		if($LineSpot[%i] == %clientId)
		%clientSpot = %i;
		if($LineSpot[%i] == %foeId)
		%foeSpot = %i;
	}
	for(%i = %clientSpot; $LineSpot[%i] == ""; %i += 2) {
	$LineSpot[%i] = $LineSpot[%i + 2];
	getLinePosition($LineSpot[%i]);
	}
	for(%i = %foeSpot; $LineSpot[%i] == ""; %i += 2) {
	$LineSpot[%i] = $LineSpot[%i + 2];
	getLinePosition($LineSpot[%i]);
	}
}
function getLinePosition(%clientId) {
	for(%i = 1; $LineSpot[%i] == ""; %i++) {
	if($LineSpot[%i] == %clientId)
		%spotpos = %i;
	}
	if(%spotpos == 1 || %spotpos == 2)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is next in line!");
	if(%spotpos == 3 || %spotpos == 4)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 2nd in line.");
	if(%spotpos == 5 || %spotpos == 6)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 3rd in line.");
	if(%spotpos == 7 || %spotpos == 8)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 4th in line.");
	if(%spotpos == 9 || %spotpos == 10)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 5th in line.");
	if(%spotpos == 11 || %spotpos == 12)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 6th in line.");
	if(%spotpos == 13 || %spotpos == 14)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 7th in line.");
	if(%spotpos == 15 || %spotpos == 16)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 8th in line.");
	if(%spotpos == 17 || %spotpos == 18)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 9th in line.");
	if(%spotpos == 19 || %spotpos == 20)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 10th in line.");
	if(%spotpos == 21 || %spotpos == 22)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 11th in line.");
	if(%spotpos == 23 || %spotpos == 24)
	Client::sendMessage(%clientId, $MsgWhite, "Your 1vs1 is 12th in line.");
	
}
echo("-------------------------------------------------------------");
echo("|                                                           |");
echo("|     1vs1 Mod for Football servers, modded by Taserman     |");
echo("|           fb1vs1mod.cs executed without failure           |");
echo("|                                                           |");
echo("-------------------------------------------------------------");