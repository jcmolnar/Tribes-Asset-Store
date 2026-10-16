exec(objectives);

function getchaseclient()
{
	%numTeams = getNumTeams();
	%num = 0;
	for(%team = 0; %team < %numTeams; %team = %team + 1)
		{	
			if($teamVIP[%team] != -1)
				%num = %num +1;
			if($teamDecoy[%team] != -1)
				%num = %num +1;
		}
	
	//echo(%num);
	if(%num == 0)
		return("");
	
	%chasenum = (floor(getRandom() * (%num)))+1;
	
	%num = 0;
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
		{	
			if($teamVIP[%team] != -1)
				%num = %num +1;
			
			if(%num == %chasenum)
				
				return($teamVIP[%team]);
			
			if($teamDecoy[%team] != -1)
				%num = %num +1;
			
			if(%num == %chasenum)
				
				return($teamDecoy[%team]);
				
		}
	
	return("");
}

function remoteKill(%client)
{
   if(!$matchStarted)
      return;

	%team = client::getteam(%client);
   if(%client == $teamVIP[client::getteam(%client)])
   	{
   		%teamname = getteamname(%team);
   		messageAll(0, "The " @ %teamname @ " " @ $VIPname @ " tried to commit suicide, but his teammates restrained him long enough to give him his Prozac!");
   		return;
   	}
   else if(%client == $teamDecoy[client::getteam(%client)])
   	{
   		%teamname = getteamname(%team);
   		messageAll(0, "The " @ %teamname @ " " @ $Decoyname @ " tried to commit suicide, but his teammates restrained him long enough to give him his Prozac!");
   		return;
   	}	
   

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
   }
}


function Tutorial(%clientId)
{
	%state = $tutorialstate[%clientId];
	
	if(%state == 1)
	{
		observer::enterobservermode(%clientId);	
		centerprint(%clientId, "<jc><f0>VIP is a new Tribes game type, somewhat akin to D&D except instead of generators you are trying to kill an enemy player, the VIP.\nPress Fire To Continue", 15);
	}
	else if(%state == 2)
	{
		%numTeams = getNumTeams();
		%vip = getchaseclient();
		echo(%vip);
		if(%vip != "")
		{
			
			%clientId.observerMode = "observerOrbit";
      			Observer::setTargetClient(%clientId, %vip);
      			
			centerprint(%clientId, "<jc><f0>This is a VIP.  VIPs can be recognized by the flag they are carrying on their back.  Both teams have VIPs and it is your job to kill the enemy VIP while defending your own.  When either VIP is killed, the game is OVER!", 15);
		}
		else
			centerprint(%clientId, "<jc><f0>Your target is the VIP.  VIPs can be recognized by the flag they are carrying on their back.  Both teams have VIPs.  It is your job to kill the enemy VIP while defending your own.  When either VIP is killed, the game is OVER!", 15);	
	}
	else if(%state == 3)
	{
		centerprint(%clientId, "<jc><f0>VIPs are special in several ways.  First of all, when they are killed the match is over.  Secondly, VIPs spawn in medium armor and are unable to change armor types.", 15);
	}
	else if(%state == 4)
	{
		centerprint(%clientId, "<jc><f0>VIPs also slowly regenerate health, and cause those around them to regenerate too!  Above all, keep in mind that you must protect your VIP at all costs!", 15);
	}
		
	else if(%state == 5)
	{
		%numTeams = getNumTeams();
		%decoy = getchaseclient();
		echo(%decoy);
		if(%decoy != "")
		{
			%clientId.observerMode = "observerOrbit";
      			Observer::setTargetClient(%clientId, %decoy);
      			
			centerprint(%clientId, "<jc><f0>In addition to a VIP, both teams also have a Decoy.  This is a Decoy here.  Like the VIP, Decoys carry flags on their back and cannot change armor types.  Unlike the VIP, however, killing the Decoy will not cause the match to end.", 120);
		}
		else
			centerprint(%clientId, "<jc><f0>In addition to a VIP, both teams also have a Decoy.  Like the VIP, Decoys carry flags on their back and cannot change armor types.  Unlike the VIP, however, killing the Decoy will not cause the match to end.", 120);
	}
	else if(%state == 6)
	{
		centerprint(%clientId, "<jc><f0>The purpose of the Decoy is to mislead the enemy.  And even though they aren't as important as the VIP you don't just want to let them get killed.", 120);
	}
	else if(%state == 7)
	{
		centerprint(%clientId, "<jc><f0>Decoys are worth a single point when killed, and points from Decoy deaths can decide a match in which neither VIP is killed.  When your Decoy dies, it will also reveal their identity to the enemy.", 120);
	}
	else if(%state == 8)
	{
		centerprint(%clientId, "<jc><f0>After a Decoy has been killed five times he will be exposed and your team will no longer have a Decoy.", 120);
	}	
	else if(%state == 9)
	{
		centerprint(%clientId, "<jc><f0>Besides having enemy players as objectives, VIP is also unique in the fact that there are no set bases.  At the beginning of the game, your team will spawn in the wilderness and you must claim several bases to defend.", 120);
	}
	else if(%state == 10)
	{
		centerprint(%clientId, "<jc><f0>Only VIPs and Decoys may claim bases, and they do so by hitting the objective switch.  VIPs and Decoys may also relinquish bases by hitting the switch a second time.  Once you have taken a base, it will remain yours.", 120);
	}
	else if(%state == 11)
	{
		centerprint(%clientId, "<jc><f0>Enemy VIPs/Decoys cannot run in and steal your base from you.  However, shooting an enemy switch enough will cause it to revert to neutral, forcing them to reclaim it or abandon it!", 120);
	}
	else if(%state == 12)
	{
		centerprint(%clientId, "<jc><f0>This completes the VIP tutorial.  For more information see the VIP website at http://www.planetstarsiege.com/vip/.  Thank you and enjoy the game!", 120);
	}
	else if(%state == 13)
	{
		centerprint(%clientId, "<jc><f0>This completes the VIP tutorial.  For more information see the VIP website at http://www.planetstarsiege.com/vip/.  Thank you and enjoy the game!", 120);
		
	}
	else if(%state == 14)
	{
		Game::assignClientTeam(%clientId);
      		%team = Client::getTeam(%clientId);
      		GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
      		
		%clientId.observerMode = "";
		$tutorialstate[%clientId] = "";
    
      	}
	
}

function WhoIs(%clientId, %what)
{
	%team = client::getteam(%clientId);
	
	if(%what == "VIP")
	{
		if($teamVIP[%team] == -1)
		{
			Client::sendMessage(%clientId, 0, "Your team currently has no " @ $VIPname @ " (VIP).");
			return;
		}
		else
		{
			Client::sendMessage(%clientId, 0, "Your team's " @ $VIPname @ " (VIP) is " @ $nameVIP[%team] @ ".");
		}
	}
	else if(%what == "Decoy")
	{
		if($teamDecoy[%team] == -1 && $alivedecoy[%team] < 5)
		{
			Client::sendMessage(%clientId, 0, "Your team currently has no " @ $Decoyname @ " (Decoy).");
			return;
		}
		else if($teamDecoy[%team] == -1 && $alivedecoy[%team] == 5)
		{
			Client::sendMessage(%clientId, 0, "Your team's " @ $Decoyname @ " (Decoy) has been exposed!");
			return;
		}
		else
		{
			Client::sendMessage(%clientId, 0, "Your team's " @ $Decoyname @ " (Decoy) is " @ $nameDecoy[%team] @ ".");
		}
	}
	else if(%what == "Commander")
	{
		if($teamCom[%team] == "")
		{
			Client::sendMessage(%clientId, 0, "There is currently no one in command of your team.");
			return;
		}
		else
		{
			%com = client::Getname($teamCom[%team]);
			Client::sendMessage(%clientId, 0, %com @ " is currently in command of your team.");
			return;
		}
	}
	else if(%what == "Score")
	{
		%numTeams = getNumTeams();
		Client::sendMessage(%clientId, 0, " ");
		Client::sendMessage(%clientId, 0, "Team Scores");
		
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{	
			Client::sendMessage(%clientId, 0, getteamname(%team) @ ": " @ $teamScore[%team]);
		}
	}
	else if(%what == "Player Score")
	{
		%numPlayers = getNumClients();
		Client::sendMessage(%clientId, 0, " ");
		Client::sendMessage(%clientId, 0, "Player Scores");
		
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{	
			%pl = getclientbyindex(%i);
			Client::sendMessage(%clientId, 0, client::getname(%pl) @ ": " @ %pl.score);
		}
	}
	else if(%what == "What is VIP")
	{
		Client::sendMessage(%clientId, 0, "VIP is a new Tribes game type created by Nagorak (nagorak@home.com).  For help on how to play type 'viphelp' in a chat message, or visit the official VIP website at http://www.planetstarsiege.com/vip/.");
	}
	else if(%what == "Version")
	{
		Client::sendMessage(%clientId, 0, "VIP Version is 1.3 cappa, VIP Escort Version 1.0 alpha");
	}
	else if(%what == "Commands")
	{
		Client::sendMessage(%clientId, 0, "All commands start with the tilde symbol and are entered as chat messages.  Place the tilde character directly in front of the command with no space separating them.  Commands may be included in messages!");
		Client::sendMessage(%clientId, 0, "targetVIP: Assigns a way point to your VIP.");
		Client::sendMessage(%clientId, 0, "targetDecoy: Assigns a way point to your Decoy.");
		Client::sendMessage(%clientId, 0, "whoisVIP: Tells you who your current VIP is.");
		Client::sendMessage(%clientId, 0, "whoisDecoy: Tells you who your current Decoy is.");
		Client::sendMessage(%clientId, 0, "teamscore: Displays a list of current team scores.");
		Client::sendMessage(%clientId, 0, "playerscore: Displays a list of current player scores.");
		Client::sendMessage(%clientId, 0, "requested: Displays a list of teammates currently requesting VIP or Decoy status.");
		Client::sendMessage(%clientId, 0, "version: Displays the current VIP revision number.");
	}
	else if(%what == "Requested")
	{
		%team = client::getteam(%clientId);
		%numPlayers = getNumClients();
		Client::sendMessage(%clientId, 0, " ");
		Client::sendMessage(%clientId, 0, "Team Status Requests");
		%num = 0;
		%numvip = 0;
		%numdecoy = 0;
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{	
			%request = "";
			%pl = getclientbyindex(%i);
			%plteam = client::getteam(%pl);
			if(%plteam != %team)
				continue;
			if($wantVIP[%pl] == true)
			{
				%request = client::getname(%pl) @ " (VIP";
				%numvip = %numvip + 1;
			}
			if($wantDecoy[%pl] == true)
			{
				%numdecoy = %numdecoy + 1;
				if(%request != "")
					{
						%request = %request @ ", Decoy";
						%num = %num +1;
					}
				else
					%request = client::getname(%pl) @ " (Decoy";
			}
			if(%request != "")
			{
				%request = %request @ ")";
				Client::sendMessage(%clientId, 0, %request);
			}
		}
		
		if(%num == 0 && %vipnum == 0 && %decoynum == 0)
			Client::sendMessage(%clientId, 0, "No teammates have requested status.");
		else
		{
			Client::sendMessage(%clientId, 0, %numvip @ " teammates have requested VIP.");
			Client::sendMessage(%clientId, 0, %numdecoy @ " teammates have requested Decoy.");
			Client::sendMessage(%clientId, 0, %num @ " teammates have requested both VIP and Decoy.");
		}
	
	}
}
	
	
function TargetVIP(%clientId)
{
	%team = client::getteam(%clientId);
	
	if($teamVIP[%team] == %clientId)
		return;
	
	if($teamVIP[%team] == -1)
	{
		Client::sendMessage(%clientId, 0, "Your team currently has no " @ $VIPname @ " (VIP).");
		return;
	}
	
	%targ = $teamVIP[%team] - 2048;
	issueTargCommand($teamVIP[%team], %clientId, 0, "Defend " @ $VIPname @ " " @ $nameVIP[%team], %targ);
}

function TargetDecoy(%clientId)
{
	%team = client::getteam(%clientId);
	
	if($teamDecoy[%team] == %clientId)
		return;
	
	if($teamDecoy[%team] == -1)
	{
		Client::sendMessage(%clientId, 0, "Your team currently has no " @ $Decoyname @ " (Decoy).");
		return;
	}
	
	%targ = $teamDecoy[%team] - 2048;
	issueTargCommand($teamDecoy[%team], %clientId, 0, "Defend " @ $Decoyname @ " " @ $nameDecoy[%team], %targ);
}

//function BonusScore()
//{
//	%numTeams = getNumTeams();
//	for(%team = 0; %team < %numTeams; %team = %team + 1)
//	{
//		if($teamVIP[%team] != -1)
//		{
//			$teamVIP[%team].score = $teamVIP[%team].score + 1;
//			Game::refreshClientScore($teamVIP[%team]);
//			Client::sendMessage($teamVIP[%team], 0, "You receive a bonus for surviving this long!");
//		}
//		if($teamDecoy[%team] != -1 && $diedDecoy[%team] == false)
//		{
//			$teamDecoy[%team].score = $teamDecoy[%team].score + 1;
//			Game::refreshClientScore($teamDecoy[%team]);
//			Client::sendMessage($teamDecoy[%team], 0, "You receive a bonus for staying alive and avoiding detection by the enemy!");
//		}
//		$diedDecoy[%team] = false;
//	}
//	schedule("BonusScore();", 120);
//}
	
function AssignWayPoint(%team)
{
	%numPlayers = getNumClients();
	%targ = $teamVIP[%team] - 2048;
	
	
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%playerId = getClientByIndex(%i);
	 		%teamId = Client::getTeam(%playerId);
	 		
	 		 if($teamVIP[%team] == %playerId)
	 			continue;
			
			if(%team == %teamId)
				issueTargCommand($teamVIP[%team], %playerId, 0, "Defend " @ $VIPname @ " " @ $nameVIP[%team], %targ);		
		}	
}
	

function UpdateStatus()
{
	%numTeams = getNumTeams();
	
	if($game::missiontype != "VIPe")
	{
	for(%i = -1; %i < %numTeams; %i = %i + 1)
	{
	  %l = 2;
	   if(%i != -1)
	   {
	   	if($teamVIP[%i] == -1)
			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team currently has no " @ $VIPname @ ".");
	   	else
		  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nProtect your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
		%l++;
		if($teamDecoy[%i] == -1 && $aliveDecoy[%i] < 5)
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team currently has no " @ $Decoyname @ ".");
	   	else if($aliveDecoy[%i] == 0)
	  		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nHelp your " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoid enemy detection.");
	   	else if($aliveDecoy[%i] < 5)
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") has been detected " @ $aliveDecoy[%i] @ " times.");
	   	else
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") has been exposed.");	   
	   	%l++;
	   }
	   
      	   
           
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
		if(%team == %i)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team currently has no " @ $VIPname @ ".");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nAssassinate the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team currently has no " @ $Decoyname @ ".");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\nFind and expose the " @ getteamname(%team) @ " " @ $Decoyname @ ".");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team has detected the " @ getteamname(%team) @ " " @ $Decoyname @ " " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	
		}
	}
	}
	else
	{
	for(%i = -1; %i < %numTeams; %i = %i + 1)
	{
	  %l = 2;
	   if(%i == $escortteam)
	   {
	   	if($teamVIP[%i] == -1)
			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team currently has no " @ $VIPname @ ".");
	   	else
		  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nProtect your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
		%l++;
		if($teamDecoy[%i] == -1 && $aliveDecoy[%i] < 5)
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team currently has no " @ $Decoyname @ ".");
	   	else if($aliveDecoy[%i] == 0)
	  		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nHelp your " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoid enemy detection.");
	   	else if($aliveDecoy[%i] < 5)
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") has been detected " @ $aliveDecoy[%i] @ " times.");
	   	else
	   		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") has been exposed.");	   
	   	%l++;
	   }
	   
      	   
           
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
		if(%team == %i || %team != $escortteam)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team currently has no " @ $VIPname @ ".");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nAssassinate the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team currently has no " @ $Decoyname @ ".");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\nFind and expose the " @ getteamname(%team) @ " " @ $Decoyname @ ".");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team has detected the " @ getteamname(%team) @ " " @ $Decoyname @ " " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	
		}
	}
	}
}
	
	

function refreshbaseinfo()
{
	%numTeams = getNumTeams();
	
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			Team::setObjective(%i, $basestatusline + %team, "<f1>   - " @ getTeamName(%team) @ " Bases: " @ $owned[%team]);
		}
	}
}

function CheckForVIP()
{	
	%numTeams = getNumTeams();
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
	  	if(Client::getteam($teamVIP[%team]) != %team && $teamVIP[%team] != -1 && $aliveVIP[%team] == 1)
	  		StripVIP($teamVIP[%team], %team, "changed to the other team");
	  	if(Client::getteam($teamDecoy[%team]) != %team && $teamDecoy[%team] != -1)
	  		StripDecoy($teamDecoy[%team], %team, "changed to the other team");
	  	if(Client::getteam($teamCom[%team]) != %team && $teamCom[%team] != "")
	  		$teamCom[%team] = "";
	 	if(Client::getteam($nextVIP[%team]) != %team && $nextVIP[%team] != -1)
	  		$nextVIP[%team] = -1;
	  	if(Client::getteam($nextDecoy[%team]) != %team && $nextDecoy[%team] != -1)
	  		$nextDecoy[%team] = -1;
	  	if($teamVIP[%team] == -1 && $aliveVIP[%team] != 0 && !$server::tourneymode)
			GetNewVIP(%team);
		else if(client::getOwnedObject($teamVIP[%team]) == -1 && $aliveVIP[%team] == 1)
			Game::playerSpawn($teamVIP[%team], true);
		if($teamDecoy[%team] == -1 && $aliveDecoy[%team] < 5 && !$server::tourneymode)
			GetNewDecoy(%team);
		else if(client::getOwnedObject($teamDecoy[%team]) == -1 && $teamDecoy[%team] != -1)
			Game::playerSpawn($teamDecoy[%team], true);

	}
	
	schedule("CheckForVIP();", 1);
}

function VIPregeneration()
{
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%pl == $teamVIP[%plteam])
		// If he is the VIP have him regenerate
		{
			Player::setItemCount(%pl,Repairpatch,1);
			Player::useitem(%pl,Repairpatch);			
		}
		else if(%pl == $teamDecoy[%plteam])
		// If he is the Decoy have him regenerate
		{
			Player::setItemCount(%pl,Repairpatch,1);
			Player::useitem(%pl,Repairpatch);
		}
		else
		// He's not either the VIP or the Decoy, see if he might be standing close enough to them to 
		// enjoy their regenerating aura.
		{
			
			
			%playerPos = GameBase::getPosition(%pl);
   			%VIPPos = GameBase::getPosition($teamVIP[%plteam]);
   			%DecoyPos = GameBase::getPosition($teamDecoy[%plteam]);
			%vipdist = Vector::getDistance(%playerPos, %VIPPos);
      			%decoydist = Vector::getDistance(%playerPos, %DecoyPos);
      			
      			if(%vipdist <= 10 && %plteam != -1 && $teamVIP[%plteam] != -1)
      			{
         		//echo("distance to VIP: " @ %vipdist);
         		       Player::setItemCount(%pl,Repairpatch,1);
			       Player::useitem(%pl,Repairpatch);
			       RemotePlayAnim(%pl, 4);
			       playVoice(%pl, "yes"); 
            		}
            		else if(%decoydist <= 10 && %plteam != -1 && $teamDecoy[%plteam] != -1)
      			{
         		//echo("distance to Decoy: " @ %decoydist);
         		       Player::setItemCount(%pl,Repairpatch,1);
			       Player::useitem(%pl,Repairpatch); 
			       RemotePlayAnim(%pl, 4);
			       playVoice(%pl, "yes"); 
            		}
            	}
            	// guess he's just out of luck for regenerating.
		
		
		
	}
	
	schedule("VIPregeneration();", 10);
}

function StripVIP(%client, %team, %reason)
	{
		if(!String::ICompare(Client::getGender($teamVIP[%team]), "Male"))
	      		%pronoun = "he";
	   		else
	      		%pronoun = "she";
		
		%teamname = getTeamName(%team);
		
		
		if(!$server::tourneymode)
		{
			teamMessages(1, %team, $nameVIP[%team] @ " is no longer your " @ $VIPname @ " (VIP) because " @ %pronoun @ " " @ %reason @ ".");
		
			Client::sendMessage(%client, 0, "You are no longer the " @ %teamname @ " " @ $VIPname @ " (VIP) because you " @ %reason @ ".");
		
			$teamVIP[%team] = -1;
			$aliveVIP[%team] = -1;
			UpdateStatus();
		}
		else if($matchstarted)
		{
			
			for(%i = 0; %i < getNumTeams(); %i++)
		   	{
				if(%i == %team)
					continue;
				$teamScore[%i] += 10;
			}

			messageAll(0, "The " @ %teamname @ " team lost their " @ $VIPname @ " (VIP) because " @ %pronoun @ " " @ %reason @ ".");	
			$aliveVIP[%team] = 0;

		}
		else
		{
			
      			Player::setItemCount(%client,LightArmor,1);									
			Player::setItemCount(%client,MediumArmor,0);									
			Player::setItemCount(%client,PlasmaGun,0);
			Player::setItemCount(%client,PlasmaAmmo,0);
			Player::setItemCount(%client,TargetingLaser,0);
			Player::setItemCount(%client,Beacon,0);
			Player::useItem(%client,DiscLauncher);

			Player::unmountItem(%client,$FlagSlot);
			
			if(!String::ICompare(Client::getGender(%client), "Male"))	
				Player::SetArmor(%client,"lArmor");
			else
				Player::SetArmor(%client,"lFemale");
			
			$teamVIP[%team] = -1;
			$aliveVIP[%team] = -1;
			UpdateStatus();
		}
			
	}
				
function StripDecoy(%client, %team, %reason)
	{
		if(!String::ICompare(Client::getGender($teamDecoy[%team]), "Male"))
	      		%pronoun = "he";
	   		else
	      		%pronoun = "she";
		
		%teamname = getTeamName(%team);
		
		
		if(!$server::tourneymode)
		{
			teamMessages(1, %team, $nameDecoy[%team] @ " is no longer your " @ $Decoyname @ " (Decoy) because " @ %pronoun @ " " @ %reason @ ".");
			
			Client::sendMessage(%client, 0, "You are no longer the " @ %teamname @ " " @ $Decoyname @ " (Decoy) because you " @ %reason @ ".");
		
			$teamDecoy[%team] = -1;
		
			UpdateStatus();
		}
		else if($matchstarted)
		{
			for(%i = 0; %i < getNumTeams(); %i++)
		   	{
				if(%i == %team)
					continue;
				$teamScore[%i] += (5 - $aliveDecoy[%team]);
			}

			messageAll(0, "The " @ %teamname @ " team's " @ $Decoyname @ " (Decoy) was exposed because " @ %pronoun @ " " @ %reason @ ".");	
			$aliveDecoy[%team] = 5;
			$teamDecoy[%team] = -1;
			
		}
		else
		{
			
      			Player::setItemCount(%client,LightArmor,1);									
			Player::setItemCount(%client,MediumArmor,0);									
			Player::setItemCount(%client,PlasmaGun,0);
			Player::setItemCount(%client,PlasmaAmmo,0);
			Player::setItemCount(%client,TargetingLaser,0);
			Player::setItemCount(%client,Beacon,0);
			Player::useItem(%client,DiscLauncher);

			Player::UnmountItem(%client, $FlagSlot);
			
			if(!String::ICompare(Client::getGender(%client), "Male"))	
				Player::SetArmor(%client,"lArmor");
			else
				Player::SetArmor(%client,"lFemale");
				
			$teamDecoy[%team] = -1;
		
			UpdateStatus();
		}
			
	}
	
function GetNewVIP(%team)
{
	
	
	// see if someone is assigned to be next VIP
	if($nextVIP[%team] != -1)
	{
		if(%team == client::getteam($nextVIP[%team]))
		{
			makeVIP($nextVIP[%team], %team);
			$nextVIP[%team] = -1;
			return;
		}
		else
			$nextVIP[%team] = -1;
	}
	
	%numPlayers = getNumClients();
	
	%numTeamPlayers = 0;
        %numTeamWantVIP = 0;
        
        
        
        for(%i = 0; %i < %numPlayers; %i = %i + 1)
         {
        	%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%plteam != %team)
			continue;
		
		if($wantVIP[%pl] == true)
		        %numTeamWantVIP = %numTeamWantVIP + 1;
		
		%numTeamPlayers = %numTeamPlayers + 1;
	}
		
	
	if(%numTeamPlayers == 0)
		return;
	
   	if(%numTeamWantVIP >> 0)
   	 {
   		
   			
   			%teamVIPselect = (floor(getRandom() * (%numTeamWantVIP)))+1;
   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
		
			if($wantVIP[%pl] == true)
		        	%num = %num +1;
		        	
		        if(%teamVIPselect == %num)
   			{
   				MakeVIP(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	 }
   	 else
   	 {
   		
   		
   		%teamVIPselect = (floor(getRandom() * (%numTeamPlayers)))+1;
   		
   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
		
			%num = %num + 1;
		        	
		        if(%TeamVIPselect == %num)
   			{
   				MakeVIP(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	 }
}
 
function MakeVIP(%client, %team)
{  	
	
	if(%client == $teamDecoy[%team])
		StripDecoy(%client, %team, "got promoted to " @ $VIPname);
		
	
	$teamVIP[%team] = %client;
	$nameVIP[%team] = client::getName(%client);
	$aliveVIP[%team] = 1;
	
	if($matchstarted == false)
	 {
		if(!String::ICompare(Client::getGender(%client), "Male"))	
			Player::SetArmor(%client,"MArmor");
		else
			Player::SetArmor(%client,"MFemale");

		Player::setItemCount(%client,LightArmor,0);									
		Player::setItemCount(%client,MediumArmor,1);									
		Player::setItemCount(%client,PlasmaGun,1);
		Player::setItemCount(%client,PlasmaAmmo,40);
		Player::setItemCount(%client,TargetingLaser,1);
		Player::setItemCount(%client,Beacon,3);
		Player::useItem(%client,PlasmaGun);

		Player::mountItem(%client, Flag, $FlagSlot, %team);
				      
	 }
	else
	{
		player::kill(%client);
		game::playerspawn(%client, true);
	}
	
	
	if(!$server::tourneymode)
	{
		if(!String::ICompare(Client::getGender(%client), "Male"))
	      			%pronoun = "him";
	   			else
	      			%pronoun = "her";


        	teamMessages(1, %team, $nameVIP[%team] @ " is your " @ $VIPname @ " (VIP)!" @  "  Protect " @ %pronoun @ " at all costs!");
      		
		bottomprint($teamVIP[%team], "<jc><f0>You are your team's " @ $VIPname @ " (VIP).  Don't get killed!", 5);
		
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%playerId = getClientByIndex(%i);
	 		%teamId = Client::getTeam(%playerId);
	        	if($teamVIP[%team] == %playerId)
	        	continue;
			if(%team == %teamId)
			bottomprint(%playerId, "<jc><f0>" @ $nameVIP[%team] @ " is your " @ $VIPname @ " (VIP)!" @  "  Protect " @ %pronoun @ " from the enemy team!", 5);
		}
	}	
	else
		Game::checktourneymatchstart();
		
		AssignWayPoint(%team);
		UpdateStatus();
	

	
}
	
function GetNewDecoy(%team)
{

	
	if($nextDecoy[%team] != -1)
	{
		if(%team == client::getteam($nextDecoy[%team]) && $nextDecoy[%team] != $teamVIP[%team])
		{
			makeDecoy($nextDecoy[%team], %team);
			$nextDecoy[%team] = -1;
			return;
		}
		else
			$nextDecoy[%team] = -1;
	}
	
	%numPlayers = getNumClients();
	
	%numTeamPlayers = 0;
        %numTeamWantDecoy = 0;
        
        
        
        for(%i = 0; %i < %numPlayers; %i = %i + 1)
        {
        	%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%plteam != %team)
			continue;
		
		if(%pl == $teamVIP[%team])
			continue;
		
		if($wantDecoy[%pl] == true)
		        %numTeamWantDecoy = %numTeamWantDecoy + 1;
		
		%numTeamPlayers = %numTeamPlayers + 1;
	}
		
	
	if(%numTeamPlayers == 0)
		return;
	
   	if(%numTeamWantDecoy >> 0)
   	{
   		
   		
   		%teamDecoyselect = (floor(getRandom() * (%numTeamWantDecoy)))+1;
   		   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
				
			if(%pl == $teamVIP[%team])
				continue;
		
			if($wantDecoy[%pl] == true)
		        	%num = %num + 1;
		        	
		        if(%teamDecoyselect == %num)
   			{
   				MakeDecoy(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	}
   	else
   	{
 		
 			
 		%teamDecoyselect = (floor(getRandom() * (%numTeamPlayers)))+1;
   		   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
				
			if(%pl == $teamVIP[%team])
				continue;
		
			%num = %num + 1;
		        	
		        if(%teamDecoyselect == %num)
   			{
   				MakeDecoy(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	}
}
 
function MakeDecoy(%client, %team)
{  	
	// this shouldn't happen, but just in case...
	if(%client == $teamVIP[%team] && $server::tourneymode && !$matchstarted)
		StripVIP(%client, %team, "");
	else if(%client == $teamVIP[%team])
		return;
		
	$teamDecoy[%team] = %client;
	$nameDecoy[%team] = client::getName(%client);	
	
	 if($matchstarted == false)
	 {

		Player::setItemCount(%client,LightArmor,0);									
		Player::setItemCount(%client,MediumArmor,1);
		Player::setItemCount(%client,PlasmaGun,1);
		Player::setItemCount(%client,PlasmaAmmo,40);
		Player::setItemCount(%client,TargetingLaser,1);
		Player::setItemCount(%client,Beacon,3);
		Player::useItem(%client,PlasmaGun);
		


		if(!String::ICompare(Client::getGender(%client), "Male"))	
			Player::SetArmor(%client,"MArmor");
		else
			Player::SetArmor(%client,"MFemale");
		Player::mountItem(%client, Flag, $FlagSlot, %team);
									
	 }
	 else
	{
	 player::kill(%client);
	 game::playerspawn(%client, true);
	}
	
	if(!$server::tourneymode)
	{
		
		if(!String::ICompare(Client::getGender(%client), "Male"))
	      			%pronoun = "him";
	   			else
	      			%pronoun = "her";
      
        	bottomprint($teamDecoy[%team], "<jc><f0>You are your team's " @ $Decoyname @ ".  Distract the enemy and keep them away from your " @ $VIPname @ "!", 5);
        
      		teamMessages(1, %team, $nameDecoy[%team] @ " is your " @ $Decoyname @ " (Decoy)!  Use " @ %pronoun @ " to distract the enemy!");	
      	}
      	else
      		Game::checktourneymatchstart();
      		
      		UpdateStatus();
      		
      		
}


function Client::onKilled(%playerId, %killerId, %damageType, %damagedPos)
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

   %team = client::getteam(%playerId);
   %kteam = client::getteam(%killerId);
  
 if(%playerId != $teamVIP[%team] && %playerId != $teamDecoy[%team])
 {

   if(%killerId == $teamVIP[%kteam] || %killerId == $teamDecoy[%kteam])
   {
   	if(%kteam == %team)
   	{
   		messageAll(0, "The " @ getteamname(%kteam) @ " " @ $VIPname @" mows down his teammate " @ client::getname(%playerId) @ "!");
   		%killerId.score--;
   	}
   	else
   	{
   		messageAll(0, "The would-be assassin, " @ client::getname(%playerId) @ ", was killed by the " @ getteamname(%kteam) @ " " @ $VIPname @"!");
   		%killerId.score++;
   	}
   }
  
   else if(!%killerId)
   {

      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      
      %playerId.scoreDeaths++;
   }
   
   else if(%killerId == %playerId)
   {
      %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
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
       %killerId.score--;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   }
   
   Game::clientKilled(%playerId, %killerId, %damagedPos);
}

function Game::clientKilled(%playerId, %killerId, %damagedPos)
{
	%team = client::getteam(%playerId);
      	if(%playerID == $teamVIP[%team])
			{
			
				%killernum = Client::getTeam(%killerId);
				%killername = Client::getName(%killerId);
				%killerteam = getTeamName(%killernum);
				%losername = getTeamName(%team);
				
				if(%playerId == %killerId)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " committed suicide!");
						Client::sendMessage(%killerId, 0, "You killed yourself!");
						$assassin[%team] = %killerId;
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
					   	           %killerId.score = %killerId.score - 10;
         						   Game::refreshClientScore(%killerId);
					}
				else if(getObjectType(Client::getOwnedObject(%killerId)) != "Player")
      					{
      					  	messageAll(0, "The " @ %losername @ " " @ $VIPname @ " came to an untimely end.");
      						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
					   	  $assassin[%team] = -1;
      					}
				else if(%losername == %killerteam)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by his OWN teammate " @ %killername @ "!");
						Client::sendMessage(%killerId, 0, "You killed your OWN " @ $VIPname @ "!");
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
					   	  
			   	 			   %killerId.score = %killerId.score - 10;
         						   Game::refreshClientScore(%killerId);
         						   $assassin[%team] = %killerId;
					}
      				else
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by the " @ %killerteam @ " assassin, " @ %killername @ "!");
						Client::sendMessage(%killerId, 0, "You killed the enemy " @ $VIPname @ "!");
						$teamScore[%killernum] += 10;
						
     			   	           	%killerId.score = %killerId.score +10;
         					Game::refreshClientScore(%killerId);
         					$assassin[%team] = %killerId;

					}

				$aliveVIP[%team] = 0;
			 	

			}
		else if(%playerID == $teamDecoy[%team])
			{
			
			//	$diedDecoy[%team] = true;	
				%killernum = Client::getTeam(%killerId);
				%killername = Client::getName(%killerId);
				%killerteam = getTeamName(%killernum);
				%losername = getTeamName(%team);
				if(%playerId == %killerId)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " committed suicide!  Luckily it was only their DECOY!");
						Client::sendMessage(%killerId, 0, "You killed yourself!");
						%killerId.score = %killerId.score - 3;
						Game::refreshClientScore(%killerId);
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 1;					   	  
					   	  }

					}
				else if(getObjectType(Client::getOwnedObject(%killerId)) != "Player")
      					{
      					  	messageAll(0, "The " @ %losername @ " " @ $VIPname @ " came to an untimely end.  Luckily it was only the DECOY!");
      					  	for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 1;		   			   	  
					   	  }
      						
      					}
				else if(%losername == %killerteam)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by his OWN teammate " @ %killername @ "!  Luckily it was only their DECOY!");
						Client::sendMessage(%killerId, 0, "You killed your OWN " @ $Decoyname @ "!");
						%killerId.score = %killerId.score - 3;
						Game::refreshClientScore(%killerId);
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 1;					   	  
					   	  }
					}
				else
					{
						messageAllExcept(%killerId, 0, %killername @ " thought he killed the " @ %losername @ " " @ $VIPname @ ", but it was only a DECOY!");
						Client::sendMessage(%killerId, 0, "You killed the enemy " @ $VIPname @ "!  NOT!  You were fooled by a DECOY!");
						%killerId.score = %killerId.score + 3;
						Game::refreshClientScore(%killerId);
						$teamScore[%killernum] += 1;
					}
			 	
			 	$aliveDecoy[%team] = $aliveDecoy[%team] +1;
			 	if($aliveDecoy[%team] == 5)
			 		{
			 			$teamDecoy[%team] = -1;
			 			teamMessages(1, %team, "Your " @ $Decoyname @ " has been exposed!  Your " @ $VIPname @ "'s identity has now been compromised!");			
			 		}
			 			
			 
			 	UpdateStatus();
			 	

			}
			else
			{
				%killerTeam = Client::getTeam(%killerId);
   				%playerTeam = Client::getTeam(%playerId);
   				
   				%killerVIPPos = GameBase::getPosition($teamVIP[%killerTeam]);
   				%killerDecoyPos = GameBase::getPosition($teamDecoy[%killerTeam]);
      
   				if(%killerId && (%playerTeam != %killerTeam) && %killerId != $teamVIP[%killerteam] && %killerId != $teamDecoy[%killerteam])
   				{   
      					%vipdist = Vector::getDistance(%damagedPos, %killerVIPPos);
      					%decoydist = Vector::getDistance(%damagedPos, %killerDecoyPos);
      					// echo(%damagedPos);
      					// echo(%killerVIPPos);
      					// echo(%vipdist);
      					if(%vipdist <= 20 && $teamVIP[%killerteam] != -1)
      					{
         					if(%VIPdist <= 10)
      						{
         					// echo("distance to VIP: " @ %VIPdist);
	         				        %killerId.score = %killerId.score + 2;
            						Game::refreshClientScore(%killerId);
            						Client::sendMessage(%killerId, 0, "You received a bonus for your heroism in saving your " @ $VIPname @ "'s life!");
            					}
         					else
         					{
         					//	echo("distance to VIP: " @ %vipdist);	
         				        	%killerId.score = %killerId.score + 1;
            						Game::refreshClientScore(%killerId);
            						Client::sendMessage(%killerId, 0, "You received a bonus for defending your " @ $VIPname @ "!");	
            					}
            				}
            				else if(%decoydist <= 20 && $teamDecoy[%killerteam] != -1)
      					{
         				 	if(%decoydist <= 10)
      						{
         					// echo("distance to Decoy: " @ %decoydist);
	         				        %killerId.score = %killerId.score + 2;
            						Game::refreshClientScore(%killerId);
            						Client::sendMessage(%killerId, 0, "You received a bonus for your heroism in saving your " @ $Decoyname @ "'s life!");
            					}
         					else
         					{
         					//	echo("distance to Decoy: " @ %decoydist);	
         				        	%killerId.score = %killerId.score + 1;
            						Game::refreshClientScore(%killerId);
            						Client::sendMessage(%killerId, 0, "You received a bonus for defending your " @ $Decoyname @ "!");	
            					}
         				
            				}
            			}
            		}
         
      
}


function Game::startMatch()
{
   
      %numPlayers = getNumClients();
      %numTeams = getNumTeams();

   if($server::tourneymode)
   {
   
   	for(%team = 0; %team < %numTeams; %team = %team + 1)
      		{
			
			if(client::getteam($teamVIP[%team]) != %team && $teamVIP[%team] != -1)
   				stripVIP($teamVIP[%team], %team, "");
   		
   			if(client::getteam($teamDecoy[%team]) != %team && $teamDecoy[%team] != -1)
   				stripDecoy($teamDecoy[%team], %team, "");
   		
			
			if($teamDecoy[%team] == -1 || $teamVIP[%team] == -1)
			{
				messageAll(0, "Match cannot start until both teams select a VIP and a Decoy!");
				
				$countdownstarted = false;
				
				return;
			}
		}
   }		

   
      
      $missionStartTime = getSimTime();
      messageAll(0, "Match started.");
      Game::resetScores();	


      
        if(!$server::tourneymode)
        {
      		for(%team = 0; %team < %numTeams; %team = %team + 1)
      		{
			if($game::missiontype == "VIPe" && %team != $escortteam)
			{
				$alivevip[%team] = 0;
				$alivedecoy[%team] = 5;
				continue;
			}
				
				
			GetNewVIP(%team);
      			GetNewDecoy(%team);
		}		
	}
   
   
      $matchStarted = true;
      updatestatus();
//    schedule("BonusScore();", 120);
      schedule("CheckForVIP();", 1);
      schedule("VIPregeneration();", 10);
      
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Player::leaveMissionArea(%player)
{
   %client = Player::getClient(%player);
   %team = client::getteam(%client);
   Client::sendMessage(%client,1,"You have left the mission area.~wLeftMissionArea.wav");
   %player.outArea=1;
   
   if(%client == $teamVIP[%team])
   {
   	if($VIPoob[%team] < 3)
   		$VIPoob[%team] = 3;
   	Client::sendMessage(%client,1,"You have " @ $VIPoob[%team] @ " seconds to return to the mission area or you will be killed.~wLeftMissionArea.wav");
   	schedule("OutOfArea(" @ %client @ "," @ %player @ "," @ %team @ ",1 );", 1);
   }
   else if(%client == $teamDecoy[%team])
   {
   	if($Decoyoob[%team] < 3)
           	$Decoyoob[%team] = 3;
        Client::sendMessage(%client,1,"You have " @ $Decoyoob[%team] @ " seconds to return to the mission area or you will be killed.~wLeftMissionArea.wav");
        schedule("OutOfArea(" @ %client @ "," @ %player @ "," @ %team @ ",2 );", 1);
   }
   
   
   
}

function OutOfArea(%client, %player, %team, %type)
{
	
	if(%player.outArea == 1 && !Player::isDead(%player))
	{
		if(%type == 1)
		{
			$VIPoob[%team] = $VIPoob[%team] - 1;
			%oob = $VIPoob[%team];
		}
		else if(%type == 2)
		{
			$Decoyoob[%team] = $Decoyoob[%team] - 1;
			%oob = $Decoyoob[%team];
		}
		
		
		if(%oob == 25 || %oob == 20 || %oob == 15 || %oob == 10 || %oob <= 5 && %oob >> 0)
			Client::sendMessage(%client,1,"You have " @ %oob @ " seconds to return to the mission area or you will be killed.~wLeftMissionArea.wav");
		else if(%oob <= 0)
		{
			Player::kill(%client);
			Client::onKilled(%client,%client);	
		}
		
		schedule("OutOfArea(" @ %client @ "," @ %player @ "," @ %team @ "," @ %type @ ");", 1);	
	}
}	

function Player::enterMissionArea(%player)
{
   %cl = Player::getClient(%player);
   Client::sendMessage(%cl,1,"You have returned to the mission area.");
   %player.outArea="";
   
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
      
        bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives or type 'viphelp' for an in-game tutorial.", 5);
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
	
	   
	   if(%clientId == $teamVIP[client::getTeam(%clientId)] || %clientId == $teamDecoy[client::getTeam(%clientId)])
	    {
	   	
	   	
	   	
	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	     		%armor = "marmor";
	   	else
	      		%armor = "mfemale";
	      		
	      	$spawnBuyList[0] = MediumArmor;
	      	$spawnBuyList[1] = Blaster;
		$spawnBuyList[2] = Chaingun;
		$spawnBuyList[3] = Disclauncher;
		$spawnBuyList[4] = Plasmagun;
		$spawnBuyList[5] = RepairKit;
		$spawnBuyList[6] = TargetingLaser;
		$spawnBuyList[7] = Beacon;
		
	   }
	   else
	   {
	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      		%armor = "larmor";
	   	else
	      		%armor = "lfemale";
	      	
	      	$spawnBuyList[0] = LightArmor;
	      	$spawnBuyList[1] = Blaster;
		$spawnBuyList[2] = Chaingun;
		$spawnBuyList[3] = Disclauncher;
		$spawnBuyList[4] = RepairKit;
		$spawnBuyList[5] = "";
	      	
	    }

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

	if(%clientId == $teamVIP[client::getTeam(%clientId)] || %clientId == $teamDecoy[client::getTeam(%clientId)])
	   Player::mountItem(%clientId, Flag, $FlagSlot, client::getTeam(%clientId));
		
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}


function TowerSwitch::onCollision(%this, %object)
{

   %clicked = 0;
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

%playerClient = Player::getClient(%object);	


   
	
if($game::missiontype == "VIP")
{
	if(%playerClient == $teamVIP[client::getteam(%playerclient)] || %playerClient == $teamDecoy[client::getteam(%playerclient)])
		{
			   

			   %group = GetGroup(%this);			   
			   %playerTeam = GameBase::getTeam(%object);
			   %oldTeam = GameBase::getTeam(%this);

		
			   %dropPoints = nameToID(%group @ "/DropPoints");
			   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
			   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);
		
			   if(%oldTeam == %playerTeam)
				{
				  Group::iterateRecursive(%group, GameBase::setTeam, -1);
				  MessageAllExcept(%playerClient, 0, "The " @ getTeamName(%playerTeam) @ " " @ $VIPname @ " relinquished " @ getTeamName(%playerTeam) @ " control of " @ %this.objectiveName @ "!~wCapturedTower.wav");
				  Client::sendMessage(%playerClient, 0, "You relinquished " @ getTeamName(%playerTeam) @ " control of " @ %this.objectiveName @ "!~wCapturedTower.wav");
				  $owned[%playerteam] = $owned[%playerteam] -1;
				  refreshbaseinfo();   
				  ObjectiveMission::ObjectiveChanged(%this);
					 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					            removeFromSet(%oldDropSet, %dropPoint);
					      }
					   }
				  


				}
			   else			
			   	{
				if(%oldTeam != -1)
					{
				        Client::sendMessage(%playerClient, 0, "This base is already owned by another team!  You may only claim NEUTRAL bases!~waccess_denied.wav");
					return;
					}
 
				   if($maxowned == $owned[%playerteam])
					{
					Client::sendMessage(%playerClient, 0, "Your team already owns the maximum number of bases for this mission!~waccess_denied.wav");
					return;
					}

				   %this.damage = 0;
				   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);
			            MessageAllExcept(%playerClient, 0, "The " @ getTeamName(%playerTeam) @ " " @ $VIPname @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!~wCapturedTower.wav");
				    Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!~wCapturedTower.wav");
				    
				    
				    $owned[%playerteam] = $owned[%playerteam] +1;
				    refreshbaseinfo();   
				    ObjectiveMission::ObjectiveChanged(%this);
 				 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					         addToSet(%newDropSet, %dropPoint);
					      }
					   }
				      

				}

			
			   

			
			   
			
	
	}
	else
		{
			Client::sendMessage(%playerClient, 0, "Only VIPs and Decoys may claim or relinquish control of bases!~waccess_denied.wav");
		}
}
else if ($game::missiontype == "VIPe")
{
	if(%playerClient == $teamVIP[$escortteam])
		{
			   

			   if($owned[$escortteam] + 1 < %this.sequence)
			   {
			   	Client::sendMessage(%playerClient, 0, "You cannot claim this objective out of sequence!  You must capture " @ %this.sequence - 1 @ " other objectives first!~waccess_denied.wav");
			   	return;
			   }
			   
			   %group = GetGroup(%this);			   
			   %playerTeam = GameBase::getTeam(%object);
			   %oldTeam = GameBase::getTeam(%this);

		
			   %dropPoints = nameToID(%group @ "/DropPoints");
			   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
			   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);
		
			   if(%oldTeam == %playerTeam)
			   {
			   	%this.damage = 0;	
			   	return;
			   }
			
			   else			
			   	{

				   echo(%this.result, %this.immediateresult, %this.lost, %this.controlled);
				   
				   %this.damage = 0;
				   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);
			            
				    
				       	MessageAllExcept(%playerClient, 0, "The " @ getTeamName(%playerTeam) @ " " @ $VIPname @ " captured " @ %this.objectiveName @ " for the " @ getteamname($escortteam) @ " team!~wCapturedTower.wav");
				    	Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ "!~wCapturedTower.wav");		    			    
				    	
				    	if(%this.immediateresult > "")
				    		MessageAll(0, %this.immediateresult);	
				    	
				    	if(%this.result > "")
				    		MessageAll(0, %this.result @ " " @ %this.controltime  @  " minutes!~waccess_denied.wav");	
				    	
				    		
				    	
				    	
				    ObjectiveMission::ObjectiveChanged(%this);
 				 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					         addToSet(%newDropSet, %dropPoint);
					      }
					   }
				      

				}

			schedule("timeremaining("@ %this @");",5);
			   

			
			   
			
	
	}
	else
		{
			
			%controlTeam = GameBase::getTeam(%this);
			if(%controlTeam == -1)
				Client::sendMessage(%playerClient, 0, "Only the " @ getteamname($escortteam) @" "@ $VIPname @ " can capture objectives!~waccess_denied.wav");
		}
	
}


}

function TimeRemaining(%this)
{

%team = gamebase::getteam(%this);

if(%team != $escortteam)
	return;

if(%this.controltime == 0)
	return;

%this.increment = %this.increment + 1;

if(%this.increment == 12)
{
	%this.controltime = %this.controltime - 1;
	if(%this.controltime > 0 && %this.result > "")
		MessageAll(0, %this.result @ " " @ %this.controltime  @  " minutes!~waccess_denied.wav");	
	%this.increment = 0;
	ObjectiveMission::ObjectiveChanged(%this);
}

if(%this.controltime == 0)
{
	$teamscore[$escortteam] += %this.scorevalue;
	$owned[$escortteam] = $owned[$escortteam] +1;
	if(%this.controlled > "")
		messageAll(0, %this.controlled);
	messageAll(0, "The " @ getteamname($escortteam) @ " successfully controlled " @ %this.objectiveName @ " and gained " @ %this.scorevalue @ " points!~wflagcapture.wav");
	return;
}


echo(%this, %this.increment, %this.controltime);

schedule("timeremaining("@ %this @");",5);

}

function DeployableStation::onCollision(%this, %object)
{
	//echo("Collision (" @ %this @ ",	" @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  	 	%client = Player::getClient(%object);
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) {
			if (GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
      else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

function Station::onCollision(%this, %object)
{
	if(%this.target == ""){
		//echo(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
		%obj = getObjectType(%object);
		if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  		 	%client = Player::getClient(%object);
 			if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) {
				if (GameBase::getDamageState(%this) == "Enabled") {
					if (GameBase::isPowered(%this)) { 
						if(%this.enterTime == "")
							%this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
					}
					else 
						Client::sendMessage(%client,0,"Unit is not powered");
				}
				else 
					Client::sendMessage(%client,0,"Unit is disabled");
			}
			else if(Station::getTarget(%this) == %object)
   	   {
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
					Client::clearItemShopping(%client);
					Station::onDeactivate(%this);
					Station::onEndSequence(%this,1);
					if(Client::getGuiMode(%client) != 1)
						Client::setGuiMode(%client,1);
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
		}
	}
}

	
function setupShoppingList(%client,%station,%ListType)
{
	%max = getNumItems();
	if(%ListType == "InvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				{

				

        			
        			%team = client::getteam(%client);
        			if(%client != $teamVIP[%team] && %client != $teamDecoy[%team])
					Client::setItemShopping(%client, %item);
				}
				
		}
	}
	else if(%ListType == "RemoteInvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
	   }
	}
	else {
		for (%i = 0; %i < %max; %i = %i + 1) {						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
}
	

function Server::onClientDisconnect(%clientId)
{
		
		$wantVIP[%clientId] = false;
		$wantDecoy[%clientId] = false;
		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%clientId == $teamVIP[%team])
				StripVIP(%clientId, %team, "dropped");
			else if(%clientId == $teamDecoy[%team])
				StripDecoy(%clientId, %team, "dropped");
			
			if(%clientId == $teamCom[%team])
	  			$teamCom[%team] = "";
	 		if(%clientId == $nextVIP[%team])
	  			$nextVIP[%team] = -1;
		  	if(%clientId == $nextDecoy[%team])
		  		$nextDecoy[%team] = -1;
		}
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1 && !$EditingMission && !$Server::HoldMission) // this is the last client. PORT: the two 1.50 gates of base server.cs
      Server::refreshData();
}


function Observer::enterObserverMode(%clientId)
{
   		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%clientId == $teamVIP[%team])
				StripVIP(%clientId, %team, "entered observer mode");		
			else if(%clientId == $teamDecoy[%team])
				StripDecoy(%clientId, %team, "entered observer mode");
				
			if(%clientId == $teamCom[%team])
	  			$teamCom[%team] = "";
	 		if(%clientId == $nextVIP[%team])
	  			$nextVIP[%team] = -1;
		  	if(%clientId == $nextDecoy[%team])
		  		$nextDecoy[%team] = -1;
			
		}
   
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
      return false;
   Client::clearItemShopping(%clientId);
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   Client::setOwnedObject(%clientId, -1);
   Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %clientId.observerMode = "observerOrbit";
   GameBase::setTeam(%clientId, -1);
   Observer::jump(%clientId);
   remotePlayMode(%clientId);
   return true;
}

function ObjectiveMission::missionComplete()
{
   %missiontime = getsimtime() - $missionstarttime;
   $missionComplete = true;
   
  
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
      for(%i = -1; %i < getNumTeams(); %i++) { 
   	%l = 2;
   	
   	
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	
	if($game::missiontype != "VIPe")
	{
	if(%i != -1)
	{   

	   if($teamVIP[%i] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully protected your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
	   else
	   	{
	   		if($assassin[%i] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") came to an untimely end.");
	   		else if($assassin[%i] == $teamVIP[%i])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%i]) == %i)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was killed by his teammate " @ client::getname($assassin[%i]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was assassinated by " @ client::getname($assassin[%i]) @ ".");
	   	}
	   	
	   %l++;
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%i] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $Decoyname @ " at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoided detection and fooled the enemy.");
	   else if($aliveDecoy[%i] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was detected " @ $aliveDecoy[%i] @ " times.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was exposed.");
	   %l++;
	 }
	   

           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ").");
	   	else
	   	{
	   		if($assassin[%team] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") came to an untimely end.");
	   		else if($assassin[%team] == $teamVIP[%team])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%team]) == %team)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was killed by his teammate " @ client::getname($assassin[%team]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was assassinated by " @ client::getname($assassin[%team]) @ ".");
	   	}
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $Decoyname @ " at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to expose the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team detected the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ") " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	}
	
	}
	
	else
	{
	if(%i == $escortteam)
	{   

	   if($teamVIP[%i] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully protected your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
	   else
	   	{
	   		if($assassin[%i] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") came to an untimely end.");
	   		else if($assassin[%i] == $teamVIP[%i])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%i]) == %i)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was killed by his teammate " @ client::getname($assassin[%i]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was assassinated by " @ client::getname($assassin[%i]) @ ".");
	   	}
	   	
	   %l++;
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%i] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $Decoyname @ " at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoided detection and fooled the enemy.");
	   else if($aliveDecoy[%i] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was detected " @ $aliveDecoy[%i] @ " times.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was exposed.");
	   %l++;
	 }
	   

           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i || %team != $escortteam)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ").");
	   	else
	   	{
	   		if($assassin[%team] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") came to an untimely end.");
	   		else if($assassin[%team] == $teamVIP[%team])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%team]) == %team)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was killed by his teammate " @ client::getname($assassin[%team]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was assassinated by " @ client::getname($assassin[%team]) @ ".");
	   	}
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $Decoyname @ " at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to expose the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team detected the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ") " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	}
	
	}
	}
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
	   $VIPname = "VIP";
	   $Decoyname = "Decoy";
	   
			
   $missionComplete = false;
   
   schedule("Server::nextMission();", 0);
}


function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

   		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%damagedClient == $teamVIP[%team] && %type && %type != $LandingDamageType)
			{
				
				if($helpsayVIP[%team] != false)
				{
					schedule("$helpsayVIP[" @ %team @ "]= true;", 1);
					if(%damagedClient == %shooterClient)
					{
						playVoice(%damagedClient, "oops1"); 
						RemotePlayAnim(%damagedClient, 9);
					}
					else if(client::getteam(%damagedClient) == client::getteam(%shooterClient))
					{
						playVoice(%damagedClient, "cease"); 
						RemotePlayAnim(%damagedClient, 0);
					}
					else
					{
						RemotePlayAnim(%damagedClient, 0);
						playVoice(%damagedClient, "help"); 
					}
				
					$helpsayVIP[%team] = false;
				}
				if($Server::TeamDamageScale >> 0 && $Server::VIPDamageScale >> 0 || %damagedClient == %shooterClient)
				{
					%numPlayers = getNumClients();
	   				for(%i = 0; %i < %numPlayers; %i = %i + 1)
	       				{
	        				%playerId = getClientByIndex(%i);
	 					%teamId = Client::getTeam(%playerId);
	 					if(%damagedClient == %playerId)
	        					continue;
		        			if(%team == %teamId)
		        			bottomprint(%playerId, "<jc><f0>Your " @ $VIPname @ " is under attack!", 5);
	        			}
	        		}
	        	}
	        	else if(%damagedClient == $teamDecoy[%team]  && %type != $LandingDamageType)
			{
				if($helpsayDecoy[%team] != false)
				{
				schedule("$helpsayDecoy[" @ %team @ "]= true;", 1);
				if(%damagedClient == %shooterClient)
				{
					playVoice(%damagedClient, "oops1"); 
					RemotePlayAnim(%damagedClient, 9);
				}
				else if(client::getteam(%damagedClient) == client::getteam(%shooterClient))
				{
					playVoice(%damagedClient, "cease"); 
					RemotePlayAnim(%damagedClient, 0);
				}
				else
				{
					RemotePlayAnim(%damagedClient, 0);
					playVoice(%damagedClient, "help"); 
				}
				
				$helpsayDecoy[%team]=false;
				}
			}
		}

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])	
					{
						if($Server::VIPDamageScale > 0)
						{
						if(%type != $MineDamageType) {
							Client::sendMessage(%shooterClient,0,"You just harmed your " @ $VIPname @ ", " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else {
							Client::sendMessage(%shooterClient,0,"You just harmed your " @ $VIPname @ ", " @ Client::getName(%damagedClient) @ ", with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
						}
					}
					else
					{
						if(%type != $MineDamageType) {
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else {
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;

			if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])
				%VIPFriendFire = $Server::VIPDamageScale;
			else
				%VIPFriendFire = 1.0;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
		{
			%friendFire = $Server::TeamDamageScale;
			
			if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])
				%VIPFriendFire = $Server::VIPDamageScale;
			else
				%VIPFriendFire = 1.0;
		}
		else  
		{
			%friendFire = 1.0;
			%VIPfriendFire = 1.0;
		}
		

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
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
				%value = $DamageScale[%armor, %type] * %value * %friendFire * %VIPFriendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				%damagedPos = GameBase::getPosition(%damagedclient);
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
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type, %damagedpos);
				}
			}
		}
	}
}

function Mission::init()
{
	
	//echo($firstobjectiveline);
	%numTeams = getNumTeams();

	
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		$helpsayVIP[%team] = true;
		$helpsayDecoy[%team] = true;
		$teamVIP[%team] = "-1";
		$nameVIP[%team] = "-1";
		$aliveVIP[%team] = "-1";
		$teamDecoy[%team] = "-1";
		$nameDecoy[%team] = "-1";
		$aliveDecoy[%team] = "0";
		$owned[%team] = "0";
		$deltaTeamScore[%team] = 0;
        	$teamScore[%team] = 0;
        	if($server::oobtime)
        	{
        		$VIPoob[%team] = $server::oobtime;
        		$Decoyoob[%team] = $server::oobtime;
        	}
        	else
        	{
        		$VIPoob[%team] = 20;
        		$Decoyoob[%team] = 20;
        	}
        }
        	
        
        %numPlayers = getNumClients();
        
      	if($VIPname == "")
		$VIPname = "VIP";
	if($Decoyname == "")
		$Decoyname = "Decoy";
	if($game::missiontype == "VIPe" && $escortteam == "")
		$escortteam = 0;
	
	
	

   setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
//   setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");
   setTeamScoreHeading("Team Name\t\xD6Score");

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   
   for(%i = -1; %i < getNumTeams(); %i++)
   
   {
   	%l = 2;
      $teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
      Team::setObjective(%i, $firstTeamLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      
    if($game::missiontype != "VIPe")
    {
      if(%i != -1)
      {
      	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\n Hide and protect your " @ $VIPname @ ".");
      	%l++;
      	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n Use your " @ $Decoyname @ " to distract the enemy.");
      	%l++;
      }
      
      %numTeams = getNumTeams();
   	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\n Find and kill the " @ getTeamName(%team) @ " " @ $VIPname @ ".");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\n Expose the " @ getTeamName(%team) @ " " @ $Decoyname @ " in order to find their " @ $VIPname @ ".");
		%l++;
	}   
	
   	
	Team::setObjective(%i, $firstObjectiveLine + %l, " ");
	 %l++;
	Team::setObjective(%i, $firstObjectiveLine + %l, "<f5>Base Status: ");
	 %l++;
	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1>   - Max Owned Bases: " @ $maxowned);
	 %l++;
	 $basestatusline = $firstObjectiveLine + %l;
	 for(%team = 0; %team < %numTeams; %team = %team + 1)
	 {
	 	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1>   - " @ getTeamName(%team) @ " Bases: " @ $owned[%team]);
	 	%l++;
	 }
	 Team::setObjective(%i, $firstObjectiveLine + %l, " ");
	 %l++;
	 Team::setObjective(%i, $firstObjectiveLine + %l, "<f1>   - This mission has no bases.");
	
      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   else
   {
     if(%i == $escortteam)
      {
      	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\n Hide and protect your " @ $VIPname @ ".");
      	%l++;
      	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n Use your " @ $Decoyname @ " to distract the enemy.");
      	%l++;
      }
      
      %numTeams = getNumTeams();
   	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i || %team != $escortteam)
			continue;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\n Find and kill the " @ getTeamName(%team) @ " " @ $VIPname @ ".");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\n Expose the " @ getTeamName(%team) @ " " @ $Decoyname @ " in order to find their " @ $VIPname @ ".");
		%l++;
		
	}   
	
	Team::setObjective(%i, $firstObjectiveLine + %l, " ");
	 %l++;
	Team::setObjective(%i, $firstObjectiveLine + %l, "<f5>Escort Sequence: ");
	 %l++;
   	
		
      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   }
   $numObjectives = 0;
   newObject(ObjectivesSet, SimSet);
   addToSet(MissionCleanup, ObjectivesSet);
   
   Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
   %group = nameToID("MissionCleanup/ObjectivesSet");

	//echo("line:" @ %l);
	ObjectiveMission::setObjectiveHeading();
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %l + $firstObjectiveLine;
      %l = %l +1;
      ObjectiveMission::objectiveChanged(%obj);
   }
   

   	
   	
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }
   
   schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
   AI::setupAI();
}

function Vote::changeMission()
{
   $timeLimitReached = true;
   $timeReached = true;
   $missionComplete = true;
   
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = -1; %i < getNumTeams(); %i++) { 
   	%l = 2;
   	
   	
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	
	if($game::missiontype != "VIPe")
	{
	if(%i != -1)
	{   

	   if($teamVIP[%i] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully protected your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
	   else
	   	{
	   		if($assassin[%i] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") came to an untimely end.");
	   		else if($assassin[%i] == $teamVIP[%i])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%i]) == %i)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was killed by his teammate " @ client::getname($assassin[%i]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was assassinated by " @ client::getname($assassin[%i]) @ ".");
	   	}
	   	
	   %l++;
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%i] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $Decoyname @ " at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoided detection and fooled the enemy.");
	   else if($aliveDecoy[%i] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was detected " @ $aliveDecoy[%i] @ " times.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was exposed.");
	   %l++;
	 }
	   

           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ").");
	   	else
	   	{
	   		if($assassin[%team] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") came to an untimely end.");
	   		else if($assassin[%team] == $teamVIP[%team])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%team]) == %team)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was killed by his teammate " @ client::getname($assassin[%team]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was assassinated by " @ client::getname($assassin[%team]) @ ".");
	   	}
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $Decoyname @ " at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to expose the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team detected the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ") " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	}
	
	}
	
	else
	{
	if(%i == $escortteam)
	{   

	   if($teamVIP[%i] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully protected your " @ $VIPname @ " (" @ $nameVIP[%i] @ ").");
	   else
	   	{
	   		if($assassin[%i] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") came to an untimely end.");
	   		else if($assassin[%i] == $teamVIP[%i])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%i]) == %i)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was killed by his teammate " @ client::getname($assassin[%i]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $VIPname @ " (" @ $nameVIP[%i] @ ") was assassinated by " @ client::getname($assassin[%i]) @ ".");
	   	}
	   	
	   %l++;
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%i] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team didn't have a " @ $Decoyname @ " at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") avoided detection and fooled the enemy.");
	   else if($aliveDecoy[%i] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was detected " @ $aliveDecoy[%i] @ " times.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour " @ $Decoyname @ " (" @ $nameDecoy[%i] @ ") was exposed.");
	   %l++;
	 }
	   

           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i || %team != $escortteam)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ").");
	   	else
	   	{
	   		if($assassin[%team] == -1)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") came to an untimely end.");
	   		else if($assassin[%team] == $teamVIP[%team])	
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") committed suicide.");
	   		else if(client::getteam($assassin[%team]) == %team)
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was killed by his teammate " @ client::getname($assassin[%team]) @ ".");
	   		else
	   			Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nThe " @ getteamname(%team) @ " " @ $VIPname @ " (" @ $nameVIP[%team] @ ") was assassinated by " @ client::getname($assassin[%team]) @ ".");
	   	}
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nThe " @ getteamname(%team) @ " team didn't have a " @ $Decoyname @ " at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\nYour team failed to expose the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
	   	else if($aliveDecoy[%team] < 5)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\nYour team detected the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ") " @ $aliveDecoy[%team] @ " times.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\nYour team successfully exposed the " @ getteamname(%team) @ " " @ $Decoyname @ " (" @ $nameDecoy[%team] @ ").");
		%l++;
	}
	
	}
	}
	
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
	   $VIPname = "VIP";
	   $Decoyname = "Decoy";
	
	
   $missionComplete = false;
     
}

function Admin::voteSucceded()
{
   $curVoteInitiator.numVotesFailed = "";
   if($curVoteAction == "kick")
   {
      if($curVoteOption.voteTarget)
         Admin::kick(-1, $curVoteOption);
   }
   else if($curVoteAction == "admin")
   {
      if($curVoteOption.voteTarget)
      {
         $curVoteOption.isAdmin = true;
         messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
         if($curVoteOption.menuMode == "options")
            Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "com")
   {
      if($curVoteOption.voteTarget)
      {
         Commander($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "tutor")
   {
      if($curVoteOption.voteTarget)
      {
         if($tutorialstate[$curVoteOption] == "")
         {
         	$tutorialstate[$curVoteOption] = 1;
         	tutorial($curVoteOption);
         }
         
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "uncom")
   {
      if($curVoteOption.voteTarget)
      {
         Uncommander($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "remvip")
   {
      if($curVoteOption.voteTarget)
      {
         RemoveVIP($curVoteOption, "vote");
      }
      $curVoteOption.voteTarget = false;
   }
   
   else if($curVoteAction == "remdecoy")
   {
      if($curVoteOption.voteTarget)
      {
         RemoveDecoy($curVoteOption, "vote");
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
      Server::loadMission($curVoteOption);
   }
   else if($curVoteAction == "tourney")
      Admin::setModeTourney(-1);
   else if($curVoteAction == "ffa")
      Admin::setModeFFA(-1);
   else if($curVoteAction == "etd")
      Admin::setTeamDamageEnable(-1, true);
   else if($curVoteAction == "dtd")
      Admin::setTeamDamageEnable(-1, false);
   else if($curVoteAction == "evd")
      Admin::setVIPDamageEnable(-1, true);
   else if($curVoteAction == "dvd")
      Admin::setVIPDamageEnable(-1, false);
   else if($curVoteOption == "smatch")
      Admin::startMatch(-1);
}

function Admin::setVIPDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::VIPDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "VIP damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED VIP damage.");
      }
      else
      {
         $Server::VIPDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "VIP damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED VIP damage.");
      }
   }
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
  
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
         if(client::getteam(%sel) == client::getteam(%clientId) && client::getteam(%sel) != -1)
         {
         	if($teamCom[client::getteam(%sel)] == %sel)
         		Client::addMenuItem(%clientId, %curItem++ @ "Vote to remove " @ %name @ " from command", "vuncom " @ %sel);
         	else
         		Client::addMenuItem(%clientId, %curItem++ @ "Vote to place " @ %name @ " in command", "vcom " @ %sel);
         	
         	if(!$server::tourneymode)
         		Client::addMenuItem(%clientId, %curItem++ @ "Vote to make " @ %name @ " read the tutorial", "vtutor " @ %sel);
         	
         }
         	
      }
      
      if(!$server::tourneymode || !$matchStarted)
      {
      if(%clientId == $teamCom[client::getteam(%clientId)] || $server::tourneymode)
      {
      	if(client::getteam(%sel) == client::getteam(%clientId) && client::getteam(%clientId) != -1)
      	{	
      		Client::addMenuItem(%clientId, %curItem++ @ "VIP " @ %name, "vip " @ %sel);
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy " @ %name, "decoy " @ %sel);
      		
      		if($teamVIP[client::getteam(%sel)] == %sel)
         	 	Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ " from VIP", "remvip " @ %sel);
         	else if($teamDecoy[client::getteam(%sel)] == %sel)
         		Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ " from Decoy", "remdecoy " @ %sel);
         	
         	
         }
       
        
      }
      else
      {
      		if(client::getteam(%sel) == client::getteam(%clientId) && $teamVIP[client::getteam(%sel)] == %sel && client::getteam(%clientId) != -1 )
      			Client::addMenuItem(%clientId, %curItem++ @ "Vote to remove " @ %name @ " from VIP", "vremvip " @ %sel);     
      		else if(client::getteam(%sel) == client::getteam(%clientId) && $teamDecoy[client::getteam(%sel)] == %sel && client::getteam(%clientId) != -1)
      			Client::addMenuItem(%clientId, %curItem++ @ "Vote to remove " @ %name @ " from Decoy", "vremdecoy " @ %sel);	
      }
      }
      
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
         
         if($teamCom[client::getteam(%sel)] == %sel)
         	Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ " from command", "uncom " @ %sel);
         else if (client::getteam(%sel) != -1)
         	Client::addMenuItem(%clientId, %curItem++ @ "Place " @ %name @ " in command", "com " @ %sel);
         
         if(!$server::tourneymode && client::getteam(%sel) != -1)
         	Client::addMenuItem(%clientId, %curItem++ @ "Make " @ %name @ " read the tutorial", "tutor " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      if($curVoteAction == "com" || $curVoteAction == "uncom" || $curVoteAction == "remvip" || $curVoteAction == "remdecoy" || $curVoteAction == "tutor")
      {
      	if($curVoteOption.voteTarget)
      	{
      	 	%sel = $curVoteOption;
      	 	if(client::getteam(%sel) == client::getteam(%clientId))
      	 	{
      	 		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      			Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
      		}
      	}
      }
     
      else
      {
      	echo ($curVoteAction);
      	Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
      }
   
   }  
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      if($Server::VIPDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable VIP damage", "vdvd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable VIP damage", "vevd");               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
      if($Server::VIPDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable VIP damage", "dvd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable VIP damage", "evd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      if($Server::TourneyMode)
      	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
   
   
   if(!$server::tourneymode)
   {
   	if($wantVIP[%clientId] == true)
      		Client::addMenuItem(%clientId, %curItem++ @ "VIP Status- Requested", "wantviptoggle");
     	else
        	Client::addMenuItem(%clientId, %curItem++ @ "VIP Status- Normal", "wantviptoggle");
   	if($wantDecoy[%clientId] == true)
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy Status- Requested", "wantdecoytoggle");
      	else
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy Status- Normal", "wantdecoytoggle");
   }
}

// PORT: the Tab-menu codes arrive from the client, so each one is checked here the way
// Game::menuRequest lists it (admin entries for admins, VIP / Decoy picks for the team's
// commander, or for a teammate before a tournament match starts).
function VIPPort::optAllowed(%clientId, %opt, %cl)
{
   if(%opt == "tutor" || %opt == "com" || %opt == "uncom" || %opt == "kick" || %opt == "fteamchange" || %opt == "cmission" || %opt == "etd" || %opt == "dtd" || %opt == "evd" || %opt == "dvd" || %opt == "cffa" || %opt == "ctourney" || %opt == "smatch" || %opt == "ctimelimit" || %opt == "reset")
      return %clientId.isAdmin;
   if(%opt == "ban" || %opt == "admin")
      return %clientId.isSuperAdmin;
   if(%opt == "vip" || %opt == "decoy" || %opt == "remvip" || %opt == "remdecoy")
   {
      %t = Client::getTeam(%clientId);
      if(%t == -1 || Client::getTeam(%cl) != %t)
         return false;
      if($Server::TourneyMode)
         return !$matchStarted;
      return (%clientId == $teamCom[%t]);
   }
   return true;
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(!VIPPort::optAllowed(%clientId, %opt, %cl)) { Game::menuRequest(%clientId); return; }
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
      if($server::tourneymode && !$matchstarted && $countdownstarted && %clientID == $teamVIP[client::getteam(%clientId)] )
      	return;
      else if($server::tourneymode && !$matchstarted && $countdownstarted && %clientID == $teamDecoy[client::getteam(%clientId)])
      	return;
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
   else if(%opt == "wantviptoggle")
   {
      if($wantVIP[%clientId] == true)
      	$wantVIP[%clientId] = false;
      else
      	$wantVIP[%clientId] = true;
      	
      
   }      
   else if(%opt == "wantdecoytoggle")
   {
      if($wantDecoy[%clientId] == true)
      	$wantDecoy[%clientId] = false;
      else
      	$wantDecoy[%clientId] = true;
      	
      
   }         
      
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vtutor")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "make " @ Client::getName(%cl) @ " read the tutorial", "tutor", %cl);
   }
   else if(%opt == "vcom")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "place " @ Client::getName(%cl) @ " in command of the " @ %teamname @ " team", "com", %cl);
   }
   else if(%opt == "vuncom")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "remove " @ Client::getName(%cl) @ " from command of the " @ %teamname @ " team", "uncom", %cl);
   }
   else if(%opt == "vremvip")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "remove the " @ %teamname @ " VIP", "remvip", %cl);
   }
   else if(%opt == "vremdecoy")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "remove the " @ %teamname @ " Decoy", "remdecoy", %cl);
   }
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
   else if(%opt == "vip")
   {
      if(!$server::tourneymode)
      {
      		$nextVIP[client::getteam(%cl)] = %cl;
      		teamMessages(1, client::getteam(%cl), client::getname(%cl) @ " has been set to be the next " @ $VIPname @ ".");	
      		Client::sendMessage(%clientId, 0, "You have set " @ client::getname(%cl) @ " to be the next " @ $VIPname @ ".");
      		Client::sendMessage(%cl, 0, "You have been set to be the next " @ $VIPname @ ".");
      }
      else if(!$matchstarted)
      {
      		if($teamVIP[client::getteam(%cl)] != -1)
      			stripVIP($teamVIP[client::getteam(%cl)],client::getteam(%cl),"");
		
		makeVIP(%cl,client::getteam(%cl));
	}
      		
      		
   }
   else if(%opt == "decoy")
   {
      if(!$server::tourneymode)
      {
      		$nextDecoy[client::getteam(%cl)] = %cl;
      		teamMessages(1, client::getteam(%cl), client::getname(%cl) @ " has been set to be the next " @ $Decoyname @ ".");	
      		Client::sendMessage(%clientId, 0, "You have set " @ client::getname(%cl) @ " to be the next " @ $Decoyname @ ".");
      		Client::sendMessage(%cl, 0, "You have been set to be the next " @ $Decoyname @ ".");
      }
      else if(!$matchstarted)
      {
      		if($teamDecoy[client::getteam(%cl)] != -1)
      			stripDecoy($teamDecoy[client::getteam(%cl)],client::getteam(%cl),"");
		makeDecoy(%cl,client::getteam(%cl));
	}
   }
      
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "vevd")
      Admin::startVote(%clientId, "enable VIP damage", "evd", 0);
   else if(%opt == "vdvd")
      Admin::startVote(%clientId, "disable VIP damage", "dvd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "evd")
      Admin::setVIPDamageEnable(%clientId, true);
   else if(%opt == "dvd")
      Admin::setVIPDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "tutor")
   {
   	if($tutorialstate[%cl] == "")
   	{
        	$tutorialstate[%cl] = 1;
        	tutorial(%cl);
        }
   }
   else if(%opt == "uncom")
   	Uncommander(%cl);
   else if(%opt == "com")
   	Commander(%cl);
   else if(%opt == "remvip")
   	RemoveVIP(%cl, "");
   else if(%opt == "remdecoy")
   	RemoveDecoy(%cl, "");
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}

function Server::onClientConnect(%clientId)
{
   $wantVIP[%clientId] = false;
   $wantDecoy[%clientId] = false;
   
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));


   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
}

function Commander(%clientId)
{
	%team = client::getteam(%clientId);
	$teamCom[%team] = %clientId;
	
	teamMessages(1, %team, client::getname(%clientId) @ " has been placed in command.");	
	Client::sendMessage(%clientId, 0, "You have been placed in command.");
}

function Uncommander(%clientId)
{
	%team = client::getteam(%clientId);
	if($teamCom[%team] != %clientId)
	// in case the admin has already removed or replaced him
		return;
	
	$teamCom[%team] = "";
	
	teamMessages(1, %team, client::getname(%clientId) @ " has been removed from command.");	
	Client::sendMessage(%clientId, 0, "You have been stripped of command.");
}

function RemoveVIP(%clientId, %how)
{
	%team = client::getteam(%clientId);
	if($teamVIP[%team] != %clientId)
	// in case the commander has already removed or replaced him
		return;
	
	if($server::tourneymode && !$matchstarted)
		stripVIP(%clientId,%team,"");
	else
	{
	%teamname = getteamname(%team);
	if(%how == "vote")
	{
		
		messageAll(0, "The " @ %teamname @ " " @ $VIPname @ " (VIP) was removed by a vote of no confidence from his teammates.");
		StripVIP($teamVIP[%team], %team, "received a vote of no confidence");
	}
	else
	{
		messageAll(0, "The " @ %teamname @ " " @ $VIPname @ " (VIP) was removed by Commander " @ client::getname($teamCom[%team]) @ ".");
		StripVIP($teamVIP[%team], %team, "got removed by Commander " @ client::getname($teamCom[%team]));
	}
	player::kill(%clientId);
	}
}

function RemoveDecoy(%clientId, %how)
{
	%team = client::getteam(%clientId);
	if($teamDecoy[%team] != %clientId)
	// in case the commander has already removed or replaced him
		return;
	
	if($server::tourneymode && !$matchstarted)
		stripDecoy(%clientId,%team,"");
	else
	{
	%teamname = getteamname(%team);
	if(%how == "vote")
	{
		
		messageAll(0, "The " @ %teamname @ " " @ $Decoyname @ " (Decoy) was removed by a vote of no confidence from his teammates.");
		StripDecoy($teamDecoy[%team], %team, "received a vote of no confidence");
	}
	else
	{
		messageAll(0, "The " @ %teamname @ " " @ $Decoyname @ " (Decoy) was removed by Commander " @ client::getname($teamCom[%team]) @ ".");
		StripDecoy($teamDecoy[%team], %team, "got removed by Commander " @ client::getname($teamCom[%team]));
	}
	player::kill(%clientId);
	}
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      
      
      if($curVoteAction == "com" || $curVoteAction == "uncom" ||  $curVoteAction == "remvip" ||  $curVoteAction == "remdecoy" || $curVoteAction == "tutor")
   	{
   	
   		if($curVoteOption.voteTarget)
      		{
        		%sel = $curVoteOption;
        	
        		%team = Client::getteam(%sel);
        		
        		if(client::Getteam(%cl) != %team)
        		{
        			continue;
        		}
        	}
        }
        		
        	
      %totalClients++;      

      if(%cl.vote == "yes")
      {
         %votesFor++;
         %totalVotes++;
      }
      else if(%cl.vote == "no")
      {
         %votesAgainst++;
         %totalVotes++;
      }
      else
       	 %votesAbstain++;
      
   }
   
   	%minVotes = floor($Server::MinVotesPct * %totalClients);
   	if(%minVotes < $Server::MinVotes)
   	%minVotes = $Server::MinVotes;
   
   if(%totalVotes < %minVotes)
   {
      %votesAgainst += %minVotes - %totalVotes;
      %totalVotes = %minVotes;
   }
   %margin = $Server::VoteWinMargin;
   if($curVoteAction == "admin")
   {
      %margin = $Server::VoteAdminWinMargin;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < %minVotes)
         %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesabstain @ " abstentions.");
      Admin::voteSucceded();
   }
   else  // special team kick option:
   {
      if($curVoteAction == "kick") // check if the team did a majority number on him:
      {
         %votesFor = 0;
         %totalVotes = 0;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotes++;
               if(%cl.vote == "yes")
                  %votesFor++;
            }
         }
         if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesabstain @ " abstentions.");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesabstain @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function TowerSwitch::onDamage(%this,%type,%value,%pos,%vec,%mom,%client)
{
   
 %team = GameBase::getTeam(%this);  
 	//   echo(%team@","@ client::getTeam(%client));
  
 
 if(%team == -1)
 	return;
 	
 	
 if(%team == client::getTeam(%client))
 	return;
 	
 if($game::missiontype == "VIPe" && %this.controltime <= 0)
 	return;
 	
 
   
   %this.damage = %this.damage + %value;
   
   
   if(%this.damage > 4)
   {
 	%group = GetGroup(%this);			   
 	%dropPoints = nameToID(%group @ "/DropPoints");
	%oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %team);
			   
 	Group::iterateRecursive(%group, GameBase::setTeam, -1);
        
        MessageAll(0, "Because the switch was damaged, " @ %this.objectiveName @ " reverted to neutral!~wCapturedTower.wav");
        	
        if($game::missiontype != "VIPe")
        {
        	$owned[%team] = $owned[%team] -1;
		refreshbaseinfo();
	}
	else
	{
		if(%this.lost > "")
			MessageAll(0, %this.lost @"~waccess_denied.wav");
	}

	ObjectiveMission::ObjectiveChanged(%this);
	if(%dropPoints != -1)
	   {
	      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
	      {
	            removeFromSet(%oldDropSet, %dropPoint);
	      }
	   }
	%this.damage = 0;
   }

}

function Server::finishMissionLoad()
{
      	
   
   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   
   if($game::missiontype != "VIP" && $game::missiontype != "VIPe")
   	{
   	exec(station);
   	exec(admin);
   	exec(observer);
   	exec(player);
   	exec(server);
   	exec(comchat);   // PORT: remoteSay is overridden above too and was never put back

   	}
   
   Mission::init();
	Mission::reinitData();
   if($prevNumTeams != getNumTeams())
   {
      // loop thru clients and setTeam to -1;
      messageAll(0, "New teamcount - resetting teams.");
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         GameBase::setTeam(%cl, -1);
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


function TowerSwitch::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   
   
   if($game::missiontype == "VIPe")
   {
   
   if(%this.sequence == 1)
   	%seq = "1st";
   else if(%this.sequence == 2)
   	%seq = "2nd";
   else if(%this.sequence == 3)
   	%seq = "3rd";
   else if(%this.sequence >= 4 && %this.sequence <= 20)
   	%seq = %this.sequence @ "th";
   else
   	%seq = "Any";

   
   
   if(%this.controltime == "")
   	%this.controltime = 5;
   	
   
   if($missionComplete)
   {
	if(%forteam == $escortteam)
	{
		if(%thisTeam == $escortteam)
		{
			if(%this.controltime > 0)
				return "<Btower_enemycontrol.bmp>\n" @ %seq @ ": Your team failed to control " @ %this.objectiveName @ ".";
			else
   				return "<Btower_teamcontrol.bmp>\n" @ %seq @ ": Your team successfully controlled " @ %this.objectiveName @ " (" @ %this.scorevalue @ " points).";
   		}
		else
		{
			return "<Btower_enemycontrol.bmp>\n" @ %seq @ ": Your team failed to capture " @ %this.objectiveName @ ".";
   		}
   	}
  	else
	{
		if(%thisTeam == $escortteam)
		{
			if(%this.controltime > 0)
				return "<Btower_teamcontrol.bmp>\nThe " @ getteamname($escortteam) @ " team failed to control " @ %this.objectiveName @".";
			else
   				return "<Btower_enemycontrol.bmp>\nThe " @ getteamname($escortteam) @ " team successfully controlled " @ %this.objectiveName @ ".";
   		}
		else
		{
			return "<Btower_teamcontrol.bmp>\nThe " @ getteamname($escortteam) @ " team failed to capture " @ %this.objectiveName @".";
   		}
   	}
   	
   }
   else
   {
   	if(%forteam == $escortteam)
	{
		if(%thisTeam == $escortteam)
		{
			if(%this.controltime > 0)
				return "<Btowers_neutral.bmp>\n" @ %seq @ ": Control " @ %this.objectiveName @ " for " @ %this.controltime @ " minutes to gain " @ %this.scorevalue @ " points.";
			else
				return "<Btower_teamcontrol.bmp>\n" @ %seq @ ": Your team successfully controlled " @ %this.objectiveName @ " (" @ %this.scorevalue @ " points).";
   		}
		else
		{
			
			return "<Btower_enemycontrol.bmp>\n" @ %seq @ ": Capture and hold " @ %this.objectiveName @ " for " @ %this.controltime @ " minutes to gain " @ %this.scorevalue @ " points.";
   		}
   	}
  	else
	{
		if(%thisTeam == $escortteam)
		{
			if(%this.controltime > 0)
				return "<Btowers_neutral.bmp>\nPrevent the " @ getteamname($escortteam) @ " from holding " @ %this.objectiveName @ " for " @ %this.controltime @ " more minutes.";
			else
				return "<Btower_enemycapture.bmp>\nThe " @ getteamname($escortteam) @ " successfully controlled " @ %this.objectiveName @ ".";
   		}
		else
		{
			
				return "<Btower_teamcontrol.bmp>\nPrevent the " @ getteamname($escortteam) @ " team from capturing " @ %this.objectiveName @ " and holding it for " @ %this.controltime @ " minutes.";
   		}
   	}
   }
   }
   else
   {
   if($missionComplete)
   {
      if(%thisTeam == -1)
         return "<Btowers_neutral.bmp>\nNo team owned " @ %this.objectiveName @ " at the end of the mission.";
      else if(%thisTeam == %forTeam)
         return "<Btower_teamcontrol.bmp>\nYour team owned " @ %this.objectiveName @ " at the end of the mission.";
      else {
       	if(%forTeam != -1)
		   	return "<Btower_enemycontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team owned " @ %this.objectiveName @ " at the end of the mission.";
   		else
		   	return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team owned " @ %this.objectiveName @ " at the end of the mission.";
		}
	}
   else
   {
		if(%forTeam != -1) {
     		  if(%thisTeam == -1)
     		      return "<Btowers_neutral.bmp>\nNo team currently owns " @ %this.objectiveName @ ".";
     		   else if(%thisTeam == %forTeam)
     		      return "<Btower_teamcontrol.bmp>\nYour team owns " @ %this.objectiveName @ ".";
     		   else
     		      return "<Btower_enemycontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team owns " @ %this.objectiveName @ ".";
     		 
		}
		else {
 			if(%thisTeam == -1)
 			  	return "<Btowers_neutral.bmp>\nNo team currently owns " @ %this.objectiveName @ ".";
 			else
 			   return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team owns " @ %this.objectiveName @ ".";
	  	}
   }
   }
}


function remoteSay(%clientId, %team, %message)
{
   %message = String::getSubStr(%message, 0, 240);
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodMute)
      {
         %delta = %clientId.muteDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
            return;
         }
         %clientId.floodMute = "";
         %clientId.muteDoneTime = "";
      }
      %clientId.floodMessageCount++;
      // funky use of schedule here:
      schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
      if(%clientId.floodMessageCount > 4)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }

   if(Match::String(%message, "*~requested*") || Match::String(%message, "*requested*"))
   	{
   		
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			SayMessage(%clientId, %team, %message);
   		 }
   		
   		whois(%clientId,"Requested");
   		return;
   	}
   else if(Match::String(%message, "*~targetVIP*") || Match::String(%message, "*Where*VIP*"))
   	{
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			SayMessage(%clientId, %team, %message);
   		  	%a = Match::result(1);
   		  	if(Match::String(%a, "*enemy*") || Match::String(%a, "*their*") || Match::String(%a, "*there*"))
   		  		return;
   		 }
   		targetVIP(%clientId);
   		return;
   		
   	}
   else if(Match::String(%message, "*~targetDecoy*") || Match::String(%message, "*Where*Decoy*"))
   	{
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			SayMessage(%clientId, %team, %message);
   		  	%a = Match::result(1);
   		  	if(Match::String(%a, "*enemy*") || Match::String(%a, "*their*") || Match::String(%a, "*there*"))
   		  		return;
   		 }
   		targetDecoy(%clientId);
   		return;
   		
   	}
   else if(Match::String(%message, "*~whoisVIP*") || Match::String(%message, "*Who*VIP*"))
   	{
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			SayMessage(%clientId, %team, %message);
   		  	%a = Match::result(1);
   		  	if(Match::String(%a, "*enemy*") || Match::String(%a, "*their*") || Match::String(%a, "*there*"))
   		  		return;
   		 	}
   		
   		whois(%clientId,"VIP");
   		return;
   	}
      else if(Match::String(%message, "*~whoisCom*") || Match::String(%message, "*Who*Command*"))
   	{
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			SayMessage(%clientId, %team, %message);
   		  	%a = Match::result(1);
   		  	if(Match::String(%a, "*enemy*") || Match::String(%a, "*their*") || Match::String(%a, "*there*"))
   		  		return;
   		 }
   		
   		whois(%clientId,"Commander");
   		return;
   	}
   else if(Match::String(%message, "*~whoisDecoy*") || Match::String(%message, "*Who*Decoy*"))
   	{
   		
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			%a = Match::result(1);
   			SayMessage(%clientId, %team, %message);
   		  	if(Match::String(%a, "*enemy*") || Match::String(%a, "*their*") || Match::String(%a, "*there*"))
   		  	return;
   		 }
   		
   		whois(%clientId,"Decoy");
   		return;
   	}
    else if(Match::String(%message, "*~teamscore*") || Match::String(%message, "*What*Score*"))
   	{
   		
   		if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   		{
   			%a = Match::result(1);
   			SayMessage(%clientId, %team, %message);
   		  	if(Match::String(%a, "*player*") || Match::String(%a, "*my*"))
			{
   		  		whois(%clientId,"Player Score");
   		  		return;
   		  	}
   		 }
   		
   		whois(%clientId,"Score");
   		return;
   	}
   else if(Match::String(%message, "*~playerscore*"))
      	{
   		  
   		if(Match::Result(0) != "" || Match::Result(1) != "")
   		{
   		
   			SayMessage(%clientId, %team, %message);
   		 }
   		
   		whois(%clientId,"Player Score");
   		return;
   	}
      else if(Match::String(%message, "*~comhelp*") || Match::String(%message, "*comhelp*"))
      	{
   		
   		if(Match::Result(0) != "" || Match::Result(1) != "")
   		{
   		
   			SayMessage(%clientId, %team, %message);
   		 }
   		
   		whois(%clientId,"Commands");
   		return;
   	}
      else if(Match::String(%message, "~version"))
      	{
   		
   		whois(%clientId,"Version");
   		return;
   	}
    
    if(!$server::tourneymode)
    {
    	if(Match::String(%message, "*what*vip*") || Match::String(%message, "*how*play*"))
      		{
   		
   			if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   			{
   				SayMessage(%clientId, %team, %message);
   			}
   		
   			whois(%clientId,"What is VIP");
   			return;
   		}
   	else if(Match::String(%message, "viphelp"))
		{
   			if(Match::Result(0) != "" || Match::Result(1) != "" || Match::Result(2) != "")
   			{
   				SayMessage(%clientId, %team, %message);
   				return;
   			}		
   			$tutorialstate[%clientId] = 1;
   			tutorial(%clientId);
   			return;
   		}
   		
   }
	
   SayMessage(%clientId, %team, %message, %msg);

}

function SayMessage(%clientId, %team, %message)
{
   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %message);
      %team = Client::getTeam(%clientId);
      
      if(%clientId == $teamVIP[%team])
      {
      	if($VIPname == "VIP")
      		%message = "(" @ $VIPname @ ") " @ %message;
      	else
      		%message = "(" @ $VIPname @ "-VIP) " @ %message;
      }
      else if(%clientid == $teamDecoy[%team])
      {
      	if($Decoyname == "Decoy")
      		%message = "(" @ $Decoyname @ ") " @ %message;
      	else
      		%message = "(" @ $Decoyname @ "-Decoy) " @ %message;
      }
      
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
         echo("SAY: " @ %message);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   }
}

function Match::strLen(%str) {
	for (%i = 0; String::GetSubStr(%str, %i, 1) != ""; %i++)
		{}
	return %i;
	}

// Internal function, don't call this directly!
function Match::AddResult() {
	%num = $Match::params[$Match::results];
	$Match::params[$Match::results + 1] = %num;
	for (%i = 0; %i < %num; %i++) {
		$Match::param[$Match::results + 1, %i] = $Match::param[$Match::results, %i];
		}
	$Match::results++;
	}

function Match::Clear() {
	// Clear old results.
	%params = $Match::params[$Match::results];

	%i = 0;
	%param = String::GetSubStr(%params, %i,1);
	%first = %param;
	while (%param != "") {
		$Match::param[$Match::results, %param] = "";

		%i++;
		%param = String::GetSubStr(%params, %i,1);
		if (%param == %first)
			%param = %i;
		}

	$Match::params[$Match::results] = "";
	}
function Match::Success(%params) {
	// Set up for cleanup
	$Match::params[$Match::results] = %params;
	$Match::results++;
	Match::Clear($Match::results);

	%i = 0;
	%param = String::GetSubStr(%params, %i,1);
	%first = %param;
	while (%param != "") {
		$Match::param[$Match::results, %param] = $Match::param[$Match::results - 1, %param];

		%i++;
		%param = String::GetSubStr(%params, %i,1);
		if (%param == %first)
			%param = %i;
		}
	}
function Match::Add(%param, %str, %exists) {
	if (%exists) {
		if ($Match::param[$Match::results, %param] != %str)
			return false;
		}
	else	$Match::param[$Match::results, %param] = %str;
	return true;
	}
function Match::Remove(%param) {
	$Match::param[$Match::results, %param] = "";
	}

// Internal function, don't call this directly!
function Match::_ParamString(%str, %pat, %wc,%lenWc, %params, %numeric) {
	// Look for a wildcard in the pattern
	%lenText = String::FindSubStr(%pat, %wc);
	if (%lenText == -1) {
		// Match entire string
		if (%str == %pat)
			Match::Success(%params);
		return;
		}

	if (%lenText != 0) {
		// Match pattern text up to %lenText
		if (String::GetSubStr(%pat, 0, %lenText) != String::GetSubStr(%str, 0, %lenText))
			return; // no match.

		%str = String::GetSubStr(%str, %lenText, 10000);
		}

	if (%numeric != "") {
		%param = %numeric;
		%exists = false;
		%numeric++;
		%params = %params @ "0";	// trick ... 0000 = 4 numeric params.
		}
	else	{
		%param = String::GetSubStr(%pat, %lenText+%lenWC - 1, 1);
		if (%param == "")	// just in case they forgot.
			%param = 0;
		%exists = String::FindSubStr(%params, %param) != -1;
		if (!%exists)
			%params = %params @ %param;
		}

	// Chop off the wildcard
	%pat = String::GetSubStr(%pat, %lenText+%lenWc, 10000);
	if (%pat == "") {
		// No more pattern left after the wildcard, wildcard matches to end
		if (Match::Add(%param, %str, %exists)) {
			Match::Success(%params);
			Match::Remove(%param);
			}
		return;
		}

	// Look for the next wildcard in the pattern
	%lenText = String::FindSubStr(%pat, %wc);
	if (%lenText == 0)
		return;	// It's illegal to have two wildcards in a row.
	if (%lenText == -1) {
		// Special case:  match "*string".
		%idx = String::FindSubStr(%str@%wc, %pat@%wc);	// @%wc guarantees last match.
		if (%idx != -1 && String::GetSubStr(%str, %idx, 10000)==%pat) {
			if (Match::Add(%param, String::GetSubStr(%str, 0, %idx), %exists)) {
				Match::Success(%params);
				Match::Remove(%param);
				}
			return;
			}
		return;
		}

	// Chop off the text from the pattern
	%textPat = String::GetSubStr(%pat, 0, %lenText);
	%pat = String::GetSubStr(%pat, %lenText, 10000);

	%idx = String::FindSubStr(%str, %textPat);
	while (%idx != -1) {
		// Got one wildcard match

		// Make sure this is a valid match
		if (Match::Add(%param, String::GetSubStr(%str, 0, %idx), %exists)) {
			// Try a match given this wildcard match
			Match::_ParamString(String::GetSubStr(%str, %idx + %lenText, 10000),
						  %pat, %wc,%lenWc, %params, %numeric);
			Match::Remove(%param);
			}

		%newIdx = String::FindSubStr(String::GetSubStr(%str, %idx+1, 10000), %textPat);
		if (%newIdx == -1)
			%idx = -1;
		else	%idx = %newIdx + %idx + 1;
		}
	return;
	}

function Match::ParamString(%string, %pattern, %wildcard) {
	while ($Match::Results >= 0) {
		Match::Clear();
		$Match::Results--;
		}
	$Match::results = 0;

	if (%wildcard == "") {
		%wildcard = "%";
		%lenWC = 2;	// includes the next letter
		}
	else	%lenWC = Match::strLen(%wildcard) + 1;	// includes the next letter
	Match::_ParamString(%string, %pattern, %wildcard,%lenWC, "");
	return $Match::results;
	}
function Match::String(%string, %pattern, %wildcard) {
	while ($Match::Results >= 0) {
		Match::Clear();
		$Match::Results--;
		}
	$Match::results = 0;

	if (%wildcard == "") {
		%wildcard = "*";
		%lenWC = 1;
		}
	else	%lenWC = Match::strLen(%wildcard);
	Match::_ParamString(%string, %pattern, %wildcard,%lenWC,"",0);
	return $Match::results;
	}

function Match::Count(%num) {
	return $Match::results;
	}
function Match::Result(%num, %numWild) {
	if (%numWild == "") {
		%numWild = %num;
		%num = 0;
		}
	return $Match::param[%num, %numwild];
	}


function Observer::triggerUp(%client)
{
   if(%client.observerMode == "dead")
   {
      if(%client.dieTime + $Server::respawnTime < getSimTime())
      {
         if(Game::playerSpawn(%client, true))
         {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      }
   }  	
   
   else if(%client.observerMode == "observerOrbit")
   {
   	if($tutorialstate[%client] > 0)
   	{
     		$tutorialstate[%client] = $tutorialstate[%client] +1;
      		tutorial(%client);
   	}
   	else
      		Observer::nextObservable(%client);
   }
   else if(%client.observerMode == "observerFly")
   {
      if($tutorialstate[%client] > 0)
   	{
     		$tutorialstate[%client] = $tutorialstate[%client] +1;
      		tutorial(%client);
   	}
      else
      {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
	}
   }
   else if(%client.observerMode == "justJoined")
   {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   }
   else if(%client.observerMode == "pregame" && $Server::TourneyMode)
   {
      if($CountdownStarted)
         return;

      if(%client.notready)
      {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
         if(%client.notreadyCount < 3)
            bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
         else 
            bottomprint(%client, "<f1><jc>Waiting for match start.", 0);
      }
      else
      {
         %client.notreadyCount++;
         if(%client.notreadyCount < 4)
         {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
         }
         return;
      }
      Game::CheckTourneyMatchStart();
   }
}

function Observer::jump(%client)
{
   echo(test);
   
  if(%client.observerMode == "observerFly")
   {
   	if($tutorialstate[%client] > 1)
   	{
     		$tutorialstate[%client] = $tutorialstate[%client] +1;
      		tutorial(%client);
   	}
      else
      {
      %client.observerMode = "observerOrbit";
      %client.observerTarget = %client;
      Observer::nextObservable(%client);
      }
   }
   else if(%client.observerMode == "observerOrbit")
   {
      if($tutorialstate[%client] > 1)
   	{
     		$tutorialstate[%client] = $tutorialstate[%client] +1;
      		tutorial(%client);
   	}
      else
      	{
      %client.observerTarget = "";
      %client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
	}
   }
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   for(%team = 0; %team < getNumTeams(); %team = %team + 1)
   {	
	if(client::getteam($teamVIP[%team]) != %team && $teamVIP[%team] != -1)
   		stripVIP($teamVIP[%team], %team, "");
   		
   	if(client::getteam($teamDecoy[%team]) != %team && $teamDecoy[%team] != -1)
   		stripDecoy($teamDecoy[%team], %team, "");
   		
   		
   	if($teamVIP[%team] == -1 || $teamDecoy[%team] == -1)
   	{
   		MessageAll(0, "The countdown cannot commence until both teams have selected a VIP and Decoy.");
   		return;
   	}
   }
   
   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}

function FlagStand::onCollision(%this, %object)
{
   if($game::missiontype != "VIPe")
   	return;
   
   echo("FlagStand collision ", %object);
   
   %client = player::getclient(%object);
   
   echo(%client);
   
   if(%client != $teamVIP[$escortteam])
   	return;

  
			   if($owned[$escortteam] + 1 < %this.sequence)
			   {
			   	Client::sendMessage(%client, 0, "You cannot claim this objective out of sequence!  You must capture " @ %this.sequence - 1 @ " other objectives first!~waccess_denied.wav");
			   	return;
			   }
			   
			   %group = GetGroup(%this);			   
			   %playerTeam = GameBase::getTeam(%object);
			   %oldTeam = GameBase::getTeam(%this);

		
			   %dropPoints = nameToID(%group @ "/DropPoints");
			   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
			   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);
		
			   if(%oldTeam == %playerTeam)
			   {
			      	return;
			   }
			
			   else			
			   	{

				   
				   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);
			            
				    %obj = newObject("","Item",Flag,1,false,false,false);
				    echo(%obj);
				    addToSet("MissionCleanup", %obj);
				    GameBase::setPosition(%obj,GameBase::getPosition(%this));
			            GameBase::setRotation(%obj,GameBase::getRotation(%this));
				    GameBase::setTeam(%obj,$escortteam);
				    $owned[$escortteam] = $owned[$escortteam]+1;
				    
				    $teamScore[$escortteam] += %this.scorevalue;
				       	MessageAllExcept(%client, 0, "The " @ getTeamName(%playerTeam) @ " " @ $VIPname @ " successfully reached " @ %this.objectiveName @ "!~wflagcapture.wav");
				    	Client::sendMessage(%client, 0, "Congratulations!  You made it to " @ %this.objectiveName @ " in one piece!~wflagcapture.wav");		    			    
				    	
				    	
				    ObjectiveMission::ObjectiveChanged(%this);
 				 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					         addToSet(%newDropSet, %dropPoint);
					      }
					   }
				      

				}


			   

			
			   
			
	
	
}

function FlagStand::objectiveInit(%this)
{
   return %this.scoreValue || %this.deltaTeamScore;
}

function FlagStand::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   
   if(%this.sequence == 1)
   	%seq = "1st";
   else if(%this.sequence == 2)
   	%seq = "2nd";
   else if(%this.sequence == 3)
   	%seq = "3rd";
   else if(%this.sequence >= 4 && %this.sequence <= 20)
   	%seq = %this.sequence @ "th";
   else
   	%seq = "Any";

   if($game::missiontype != "VIPe")
   	return;
   	   
   if($missionComplete)
   {
	if(%forteam == $escortteam)
	{
		if(%thisTeam == $escortteam)
		{
			return "<Bflag_atbase.bmp>\n" @ %seq @ ": Your " @ $VIPname @ " was successfully escorted to " @ %this.objectiveName @ " (" @%this.scorevalue @ " points).";
   		}
		else
		{
			return "<Bflag_enemycaptured.bmp>\n" @ %seq @ ": Your " @ $VIPname @ " failed to reached " @ %this.objectiveName @ ".";
   		}
   	}
  	else
	{
		if(%thisTeam == $escortteam)
		{
			return "<Bflag_enemycaptured.bmp>\nThe " @ getteamname($escortteam) @ " " @ $VIPname @ " successfully reached " @ %this.objectiveName @ ".";
   		}
		else
		{
			return "<Bflag_atbase.bmp>\nThe " @ getteamname($escortteam) @ " " @ $VIPname @ " failed to reach " @ %this.objectiveName @ ".";
   		}
   	}
   	
   }
   else
   {
	if(%forteam == $escortteam)
	{
		if(%thisTeam == $escortteam)
		{
			return "<Bflag_atbase.bmp>\n" @ %seq @ ": Your " @ $VIPname @ " was successfully escorted to " @ %this.objectiveName @ " (" @%this.scorevalue @ " points).";
   		}
		else
		{
			return "<Bflag_neutral.bmp>\n" @ %seq @ ": Escort your " @ $VIPname @ " to " @ %this.objectiveName @ " to gain " @ %this.scorevalue @ " points.";
   		}
   	}
  	else
	{
		if(%thisTeam == $escortteam)
		{
			return "<Bflag_enemycaptured.bmp>\nThe " @ getteamname($escortteam) @ " " @ $VIPname @ " was successfully escorted to " @ %this.objectiveName @ ".";
   		}
		else
		{
			return "<Bflag_neutral.bmp>\nIntercept the " @ getteamname($escortteam) @ " " @ $VIPname @ " enroute to " @ %this.objectiveName @ ".";
   		}
   	}
   	
   }
 }