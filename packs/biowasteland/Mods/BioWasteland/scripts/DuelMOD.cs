exec(objectives);                                                  

function DuelCountdown(%clientId, %foeId, %timeLeft, %clientPl, %foePl)
{                                               
	if ($DuelStatus[%clientId] != "InCountdown" || $DuelStatus[%foeId] != "InCountdown")
	{
		Client::SendMessage(%clientId,1,"Countdown Aborted");
		Client::SendMessage(%foeId,1,"Countdown Aborted");
		return;
	}
	if (%timeLeft == 0)
	{
		StartDuel(%clientId, %foeId, %clientPl, %foePl);
		return;
	}                                                                             
	if (%timeLeft == 1)
	{
		BottomPrint(%clientId,"<jc><f0>Duel starts in <f1>1<f0> second.",1);
		BottomPrint(%foeId,"<jc><f0>Duel starts in <f1>1<f0> second.",1);
		schedule("DuelCountdown(" @ %clientId @ ", " @ %foeId @ ", 0," @ %clientPl @ ", " @ %foePl @ ");",1);
	}
	else
	{         
		BottomPrint(%clientId,"<jc><f0>Duel starts in <f1>" @ %timeLeft @ "<f0> seconds.",1);
		BottomPrint(%foeId,"<jc><f0>Duel starts in <f1>" @ %timeLeft @ "<f0> seconds.",1);
		schedule("DuelCountdown(" @ %clientId @ ", " @ %foeId @ ", " @ %timeLeft - 1 @ ", " @ %clientPl @ ", " @ %foePl @ ");",1);
	}         
}                                     

function DuelResetClient(%clientId)
{
	$DuelStatus[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelWeaponSetup[%clientId] = "";  
	$DuelPack[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
}

function LockPlayers(%clientId, %foeId, %clientPl, %foePl)
{                          
	%clientId.observerMode = "pregame";
     	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
      Observer::setOrbitObject(%clientId, %clientPl, 5, 5, 5);                
      GameBase::SetRotation(%clientId, GameBase::GetRotation(%clientPl));
      %foeId.observerMode = "pregame";
      Client::setControlObject(%foeId, Client::getObserverCamera(%foeId));
      Observer::setOrbitObject(%foeId, %foePl, 5, 5, 5);
      GameBase::SetRotation(%foeId, GameBase::GetRotation(%foePl));
}                                                

function DuelStartHurt(%clientId, %foeId)
{
	$DuelHurt[%clientId] = true;
	$DuelHurt[%foeId] = true;
}

function StartDuel(%clientId, %foeId, %clientPl, %foePl)
{                                
	// This is just to prevent those first cheap shots.
	$DuelHurt[%clientId] = false;
	$DuelHurt[%foeId] = false;               
	%startTime = getSimTime();
	$DuelStartTime[%clientId] = %startTime;
	$DuelStartTime[%clientId] = %startTime;
	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");",$DuelHurtDelay);
	$DuelStatus[%clientId] = "InDuel";
	$DuelStatus[%foeId] = "InDuel";
	$DuelStarted[%clientId] = true;
	$DuelStarted[%foeId] = true;
	GameBase::SetDamageLevel(%clientPl,0);
	GameBase::SetDamageLevel(%clientPl,0);
	GameBase::PlaySound(%clientPl, DuelFight, 0);
	GameBase::PlaySound(%foePl, DuelFight, 0);
	BottomPrint(%clientId,"<jc><f2>Fight!",1);
	BottomPrint(%foeId,"<jc><f2>Fight!",1);                                                                              
	if ($DuelHurtDelay > 1) {
		%tmpMsgTime = $DuelHurtDelay - 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Invulnerability On Until This Goes Away\", " @ %tmpMsgTime @ ");", 1);
		schedule("bottomprint(" @ %foeId @ ", \"<jc><f1>Invulnerability On Until This Goes Away\", " @ %tmpMsgTime @ ");", 1);
	}
	Client::setControlObject(%clientId, %clientPl);
	Client::setControlObject(%foeId, %foePl);	
}
           
function FinalizeDuel(%clientId, %foeId, %damageType)
{              
	ClearMines(%clientId, %foeId); 
	if (%damageType == -2)
		%damageType = $SuicideDamageType;
	if (%damageType != -1)
	{	
		$DuelStatsLine0 = "Open";	
		$DuelStatsLine1 = $DuelEndTime[%clientId] - $DuelStartTime[%clientId];
        	$DuelStatsLine2 = Client::GetName(%foeId);
        	$DuelStatsLine3 = Client::GetName(%clientId);
        	
        	if (%damageType == $BulletDamageType)
			$DuelStatsLine4 = "Bullet";
		else if (%damageType == $PlasmaDamageType)
			$DuelStatsLine4 = "Plasma";
		else if (%damageType == $ExplosionDamageType)
			$DuelStatsLine4 = "Disc";
		else if (%damageType == $ShrapnelDamageType)
			$DuelStatsLine4 = "Grenade";
		else if (%damageType == $LaserDamageType)
			$DuelStatsLine4 = "Laser";
		else if (%damageType == $MortarDamageType)
			$DuelStatsLine4 = "Mortar";
		else if (%damageType == $BlasterDamageType)
			$DuelStatsLine4 = "Blaster";
		else if (%damageType == $ElectricityDamageType)
			$DuelStatsLine4 = "ELF";
		else if (%damageType == $MineDamageType)
			$DuelStatsLine4 = "Mine";
                else if (%damageType == $SuicideDamageType)
                	$DuelStatsLine4 = "Suicide";
	}
                
	%clientId.guiLock = false;
	%foeId.guiLock = false;
	
	%foeNotHere = false;
	%clientNotHere = false;
	
	$DuelStatus[%clientId] = "Available";
	$DuelStatus[%foeId] = "Available";     
	
	if (Client::GetName(%foeId) == "")
		%foeNotHere = true;
	if (Client::GetName(%clientId) == "")
		%clientNotHere = true;
		  
	if (%clientNotHere)
		echo("Client not here");
	if (%foeNotHere)
		echo("Foe not here");
		
	$DuelStarted[%clientId] = false;
	$DuelStarted[%foeId] = false;
	if (!%foeNotHere)
	{
		%foePl = Client::GetOwnedObject(%foeId);
		GameBase::SetDamageLevel(%foePl,1);
		Player::blowUp(%foePl);
	}
	if (!%clientNotHere)
		%clientId.observerMode = "observerFly";
	if (!%foeNotHere)
		%foeId.observerMode = "observerFly";
	$DuelSpotTaken[$DuelSpot[%clientId]] = false;
	$DuelSpot[%clientId] = "";
	$DuelSpot[%foeId] = "";
	if (!%clientNotHere)
		GameBase::SetTeam(%clientId, -1);
	if (!%foeNotHere)
		GameBase::SetTeam(%foeId, -1);
	$DuelLineup[%clientId] = "";
	$DuelLineup[%foeId] = "";
	   
}                                                 

function EndDuel(%clientId, %damageType)
{                           
	if (%damageType == -2)
		%damageType = "";
	%foeId = $DuelLineup[%clientId];
	GameBase::SetTeam(%clientId,-1);
	GameBase::SetTeam(%foeId,-1);
	if ($DuelStatus[%clientId] == "InDuel" && $DuelStarted[%clientId])
	{   
		%endTime = getSimTime();
		$DuelEndTime[%clientId] = %endTime;
		$DuelStreak[%clientId] = 0;
		$DuelStreak[%foeId]++;
		if (Gamebase::GetDamageLevel(Client::GetOwnedObject(%foeId)) == 0)
		{
			schedule("Gamebase::PlaySound(" @ %foeId @ ", DuelFlawless,3);",3);
			schedule("Gamebase::PlaySound(" @ %clientId @ ", DuelFlawless,3);",3);
		}
		if ($DuelStreak[%foeId] > 4 && $DuelStreak[%foeId] < 10)
		{
			schedule("Gamebase::PlaySound(" @ %foeId @ ", DuelExcellent,2);",1.5);
			schedule("Gamebase::PlaySound(" @ %clientId @ ", DuelExcellent,2);",1.5);
		}
		else if($DuelStreak[%foeId] > 9)
		{
			schedule("Gamebase::PlaySound(" @ %foeId @ ", DuelOutstanding,2);",1.5);
			schedule("Gamebase::PlaySound(" @ %clientId @ ", DuelOutstanding,2);",1.5);
		}
		$DuelHurt[%foeId] = false;
		MessageAll(1,"" @ Client::GetName(%foeId) @ " has triumphed over " @ Client::GetName(%clientId) @ "!");
		centerprint(%clientId,"<jc><f1>You <f2>lost<f1>!",4);
		centerprint(%foeId,"<jc><f1>You <f2>won<f1>!  -- Streak Now Up To <f2>" @ $DuelStreak[%foeId],4);
		$DuelOver[%clientId] = true;
		$DuelOver[%foeId] = true;
		if (%damageType == "")
			schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ ",-2);", $DuelDelayTime);
		else
			schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ "," @ %damageType @ ");", $DuelDelayTime);
	}
	else if ($DuelStatus[%clientId] == "InCountdown" && !$DuelStarted[%clientId])
	{
		$DuelSpotTaken[$DuelSpot[%clientId]] = false;
		MessageAll(1,"" @ Client::GetName(%clientId) @ " has ended the duel prior to start."); 
		$DuelStatus[%clientId] = "Available";
		$DuelStatus[%foeId] = "Available";
		FinalizeDuel(%clientId,%foeId,-1);
	}
	
}        

function CheckDuelTime(%clientId,%foeId, %timeLeft)
{                       
	if ($DuelLineup[%foeId] == "" && $DuelLineup[%clientId] == %foeId && %timeLeft == 0)
	{
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " did not accept the duel in time.");
		Client::SendMessage(%foeId,0,"You can no longer accept the duel from " @ Client::GetName(%clientId) @ ".");
		return;
	}
	else if ($DuelLineup[%foeId] != "" && $DuelLineup[%foeId] != %clientId && $DuelStatus[%clientId] == "Available" && $DuelStatus[%foeId] == "Available")
	{
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " has just asked somebody else to duel. Try again soon.");
		return;
	}	                         
	else if ($DuelLineup[%foeId] != "" && $DuelLineup[%foeId] != %clientId && ($DuelStatus[%foeId] == "InDuel" || $DuelStatus[%foeId] == "InCountdown") && $DuelStatus[%clientId] == "Available")
	{
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " has accepted a duel with somebody else.");
		return;
	}
	else if (Client::GetName(%foeId) == "")
	{
		// enemy has left the game during this countdown, let's shut it off and notify client
		Client::SendMessage(%clientId,0,"The person you challenged has left the game.");
		$DuelLineup[%foeId] = "";
		$DuelStatus[%foeId] = "";
		$DuelLineup[%clientId] = "";      
		return;
	}
	else if (Client::GetName(%clientId) == "")
	{
		// challenger left the game, notify the person he/she challenged.
		Client::SendMessage(%foeId,0,"The person that challenged you has left the game, cancelling countdown.");
		$DuelLineup[%clientId] = "";
		$DuelStatus[%clientId] = ""; 
		return;
	}
	else if ($DuelLineup[%foeId] == %clientId && $DuelLineup[%clientId] == %foeId && $DuelStatus[%clientId] == "InCountdown" && $DuelStatus[%foeId] == "InCountdown")
	{              
		// Duel started, cancel this accept timer
		return;
	}
	schedule("CheckDuelTime(" @ %clientId @ ", " @ %foeId @ ", " @ %timeLeft-- @ ");",1);
}
                                                                              
function DuelCheckPlayers()
{                      
	// No need to continue calling if server switched to CTF mode                    
	if ($Game::missionType != "Duel") 
	{
		$DuelsStarted = "";
		return;             
	}         
	$DuelsStarted = 1;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if ($DuelStatus[%cl] == "")			
			$DuelStatus[%cl] = "Available";
		if ($DuelMode[%cl] == "")
			$DuelMode[%cl] = "On";
	}		
	schedule("DuelCheckPlayers();",1);
}                                                                             

function DuelInit(%clientId,%foeId)
{                                     
	
	if (%foeId != -1 && %foeId != 0)
	{                               
		if (Client::GetName(%foeId) == "")
		{
			Client::SendMessage(%clientId,0,"That person is not in the game.");
			return;
		}
		if (%foeId == %clientId)
		{
			client::sendmessage(%clientId,1,"You can't duel yourself!");
			if (!%clientId.isGod) return;
			client::sendmessage(%clientId,1,"Server God, you may test the spawn points however.");
		}                       
		if ($DuelMode[%foeId] == "Off")
		{
			Client::SendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " has duels off.");
			return;
		}			
		if ($DuelLineup[%foeId] == "" && $DuelStatus[%foeId] == "Available" && $DuelStatus[%clientId] == "Available")
		{               
			$DuelLineup[%clientId] = %foeId;
			client::sendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " has 30 seconds to accept the duel.");
			CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a duel.",5);
			client::sendMessage(%foeId,0,"You have 30 seconds to accept the duel.");
			CheckDuelTime(%clientId, %foeId, 30);
			return;
		}                                                 
		else if ($DuelLineup[%clientId] == "" && $DuelLineup[%foeId] != "" && $DuelStatus[%foeId] == "Available" && $DuelLineup[%foeId] != %clientId)
		{
			$DuelLineup[%clientId] = %foeId;             
			client::sendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " is requesting a duel from somebody else, but can still accept yours.");
			client::sendMessage(%clientId,0,"" @ Client::GetName(%foeId) @ " has 30 seconds to accept the duel.");
			CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a duel.",5);
			client::sendMessage(%foeId,0,"You have 30 seconds to accept the duel.");
			CheckDuelTime(%clientId, %foeId, 30);
			return;
		}			
		else if ($DuelLineup[%clientId] == "" && $DuelLineup[%foeId] != "" && ($DuelStatus[%foeId] == "InDuel" || $DuelStatus[%foeId] == "InCountdown"))
		{
			client::sendmessage(%clientId,0,"" @ Client::GetName(%foeId) @ " is currently in a duel.  Try again later.");
			return;
		}        
		else if ($DuelStatus[%clientId] == "InDuel")
		{
			client::sendmessage(%clientId,0,"Hello!? You're already in a duel!");
			return;
		}        
		else if ($DuelLineup[%foeId] == %clientId && $DuelStatus[%clientId] == "Available" && $DuelStatus[%foeId] == "Available") // || ($DuelLineup[%clientId] != "" && $DuelStatus[%clientId] == "Available"))
		{
			// Prepare to start duel
			%spotTaken = true;
			%i = -1;   
			while (%spotTaken) {
				%i++;
				if (%i > 7)
				{
					Client::SendMessage(%clientId,0,"No spawn spots are empty. Try again when someone finishes.");
					Client::SendMessage(%foeId,0,"No spawn spots are empty. Try again when someone finishes.");
					$DuelLineup[%clientId] = "";
					$DuelLineup[%foeId] = "";
					$DuelStatus[%clientId] = "Available";
					$DuelStatus[%foeId] = "Available";
					return;
				}
				if (!$DuelSpotTaken[%i])
				{
					%team = %i;
					$DuelSpot[%clientId] = %i;
					$DuelSpot[%foeId] = %i;
					$DuelSpotTaken[%i] = true;
					%spotTaken = false;
				}
			}         
			GameBase::SetTeam(%clientId,%team);
			GameBase::SetTeam(%foeId,%team);
			%clientId.guiLock = true;
			%foeId.guiLock = true;
			$DuelLineup[%clientId] = %foeId;
   			%clientId.observerMode = "";
   			%foeId.observerMode = "";
   			$DuelCanSpawn[%clientId] = true;
   			$DuelCanSpawn[%foeId] = true;
			%clientId.duelDeaths = 0;
			%foeId.duelDeaths = 0;
			Game::playerSpawn(%clientId, false);
			%clientPl = Client::GetOwnedObject(%clientId);
			Game::playerSpawn(%foeId, false);
			%foePl = Client::GetOwnedObject(%foeId);                              
			MessageAll(0, Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " are about to duel in area "@ (%team+1)@".");
   			LockPlayers(%clientId, %foeId, %clientPl, %foePl);
   			%foeId.observerTarget = "";
   			%clientId.observerTarget = "";
   			$DuelStatus[%foeId] = "InCountdown";
			$DuelStatus[%clientId] = "InCountdown";
			$DuelOver[%clientId] = false;
			$DuelOver[%clientId] = false;
			$DuelLastEnemy[%clientId] = %foeId;
			$DuelLastEnemy[%foeId] = %clientId;   
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
				if (Client::GetTeam(%cl) == -1)
				{
					if (%cl.observerTarget == %clientId)
						Observer::setTargetClient(%cl, %clientId);
					else if (%cl.observerTarget == %foeId)                 
						Observer::setTargetClient(%cl, %foeId);
				}
			}		
			DuelCountdown(%clientId,%foeId,5,%clientPl, %foePl);
		}
	}
	else                                                                 
	{
		Client::SendMessage(%clientId,0,"Nobody here by that name.");
	}
}                
                                   
function DuelEmptyPlayer(%player)
{       
	return;        
	if (%player == -1)
		return;
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++) { 
		%item = getItemData(%i); 
		
		%count = Player::getItemCount(%player,%item);
		if(%count > 0) {
			if(%item.className != Armor) 
				Player::setItemCount(%player, %item, 0);  
		}
	}                       
}

function ObjectiveMission::setObjectiveHeading()
{
	if($help)
	{
		HelpRequest();
		return;
	}
	%numClients = getNumClients();
	if (%numClients > 1)
	{
		for(%i = 0 ; %i < %numClients ; %i++) %clientList[%i] = getClientByIndex(%i);
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
	}
	else
	{
		%clientList[0] = getClientByIndex(0);
	}                   
	for (%x = -1; %x < 2; %x++)
	{
		%lineNum = 0;
		if($missionComplete == "True") Team::setObjective(%x, %lineNum++, "<jc><f5>Final Duel Statistics");
		else Team::setObjective(%x, %lineNum++, "<jc><f5>Duel Statistics");
		Team::setObjective(%x, %lineNum++, "");
		Team::setObjective(%x, %lineNum++, "");
		%curLeader = %clientList[0];
		if (%curLeader.score == 0) Team::setObjective(%x, %lineNum++, "<jc><f4>Leader:  <f1>None");
		else Team::setObjective(%x, %lineNum++, "<jc><f4>Leader:  <f1>" @ Client::GetName(%curLeader));
		Team::setObjective(%x, %lineNum++, "");    
		Team::setObjective(%x, %lineNum++, "<f2>Score     Player");
		for (%i = 0; %i < %numClients; %i++)
		{
			if (%clientList[%i].score == 0) Team::setObjective(%x, %lineNum++, "<f1>0          " @ Client::GetName(%clientList[%i]));
			else                                       
			{                            
				if (%clientList[%i].score < 10) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "          " @ Client::GetName(%clientList[%i]));
	  				else if (%clientList[%i].score < 100) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "         " @ Client::GetName(%clientList[%i]));
				else if (%clientList[%i].score < 1000) Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "        " @ Client::GetName(%clientList[%i]));
				else Team::setObjective(%x, %lineNum++, "<f1>" @ %clientList[%i].score @ "       " @ Client::GetName(%clientList[%i]));
			}
		}       
		for(%s = %lineNum++; %s < 30 ;%s++)
		Team::setObjective(%x, %s, " ");
	}	
}


function Mission::init()
{
   setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL\t\xFFTotalScore");
   setTeamScoreHeading("");
	for(%i = -1; %i < getNumTeams(); %i++)
	{
		$deltaTeamScore[%i] = 0;
		$teamScore[%i] = 0;
		newObject("TeamDrops" @ %i, SimSet);
		addToSet(MissionCleanup, "TeamDrops" @ %i);
		%dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
		for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
			addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
	}
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
	%cl.elim = "";
	%cl.race = "";
	%cl.laps = "";
	%cl.leg = "";
      Game::refreshClientScore(%cl);
   }
}

function ObjectiveMission::refreshTeamScores() {}

//============= Handles all scoring based on distance to Towers
function Client::leaveGame(%clientId)
{    
   	if ($DuelStatus[%clientId] == "InDuel" || $DuelStatus[%clientId] == "InCountdown")
   	{
   		messageall(1,"" @ Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
   		FinalizeDuel(%clientId, $DuelLineup[%clientId]);
   	}                          
   	DuelResetClient(%clientId);

   echo("GAME: clientdrop " @ %clientId);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
}

schedule("$TestMissionType = \"DUEL\";", 10);