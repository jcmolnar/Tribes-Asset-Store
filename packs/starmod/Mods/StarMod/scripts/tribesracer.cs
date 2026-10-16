// Tribes Racer
// (c) 1999 Josef Jahn (author of SPOONBOT for Tribes)
// http://www.playspoon.com
// ---------------------------------------------------


function Game::initialMissionDrop(%clientId)
{
	$CompletedRounds[%clientId]=0;
	$currentLeg[%clientId]=0;
	GameBase::setTeam(%clientId, 0);
	Client::setGuiMode(%clientId, $GuiModePlay);
	Game::playerSpawn(%clientId, false);

	schedule("vehicle::leg1(" @ %clientId @ ");", 15);
	schedule("vehicle::setWayPoint(" @ %clientId @ ");", 15);
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Get a Flier and complete the most rounds!\", 5);", 0);
	schedule("messageAll(0, \"~wshell_click.wav\");", 0);
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>If you get killed, your rounds will be reset to zero!\", 5);", 5);
	schedule("messageAll(0, \"~wshell_click.wav\");", 5);

	//limit vehicle inventory

	$VehicleInvList[ScoutVehicle] = 1;
	$VehicleInvList[WraithVehicle] = 1;
	$VehicleInvList[JetVehicle] = 1;
	$VehicleInvList[LAPCVehicle] = 1;
	$VehicleInvList[HAPCVehicle] = 1;
}


function Game::clientKilled(%playerId, %killerId)
{
	if($teamplay)
	{
		if(%killerId == -1 || %playerId == -1)
		{
			return;
		}

		%kteam = Client::getTeam(%killerId);
		%pteam = Client::getTeam(%playerId);

		if(%kteam == %pteam)
		{
			$teamScore[%kteam] = $teamScore[%kteam] - 1;
		}
		else
		{
			$teamScore[%kteam] = $teamScore[%kteam] - 1;
		}

		DMTEAM::checkMissionObjectives();
	}
	else
	DM::checkMissionObjectives(%killerId);

	if ($CompletedRounds[%playerId] > 0)
	{
		$CompletedRounds[%playerId]--;
	}
	
	$currentLeg[%playerId]=0;
	schedule("vehicle::leg1(" @ %playerId @ ");", 1);
	schedule("vehicle::setWayPoint(" @ %playerId @ ");", 1);

	%TopScore=0;
	%numClients = getNumClients();
	for(%i = 0; %i < %numClients ; %i++)
	{
		%cl = %i + 2049;
		dbecho(1, %cl);
		if (%TopScore <= $CompletedRounds[%cl])
		{
			%TopScore=$CompletedRounds[%cl];
			%leader=%cl;
		}
	}

	if (%leader != 0)
		schedule("messageAll(0, \"LEADER: " @ Client::getName(%leader) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);
}




//---------------------------
//vehicle::leg1()
//---------------------------
function vehicle::leg1(%clientId)
{

	schedule("messageAll(0, \"~wshell_click.wav\");", 0);
	DM::missionObjectives();
	DM::checkMissionObjectives(%clientId);

     if ($CompletedRounds[%clientId] >= 1)
     {
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>New Round!\", 1);", 0);
	schedule("messageAll(0, \"" @ Client::getName(%clientId) @ " has finished " @ $CompletedRounds[%clientId] @ " Rounds\");", 0);
	%TopScore=0;
	%numClients = getNumClients();
	for(%i = 0; %i < %numClients ; %i++)
	{
		%cl = %i + 2049;
		dbecho(1, %cl);
		if (%TopScore <= $CompletedRounds[%cl])
			{
				%TopScore=$CompletedRounds[%cl];
				%leader=%cl;
			}
	}
	if (%leader != 0)
		schedule("messageAll(0, \"LEADER: " @ Client::getName(%leader) @" with " @ $CompletedRounds[%leader] @ " Rounds\");", 1);

     }
     else
     {
	schedule("bottomprint(" @ %clientId @ ", \"<f2><jc>Let the race begin!\", 3);", 0);
     }

}

//-----------------------------
//vehicle::leg2()
//-----------------------------
function vehicle::leg2(%clientId)
{
	schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Lap 1\", 1);", 0);
	schedule("messageAll(0, \"~wshell_click.wav\");", 0);
}

//--------------------------------
//vehicle::leg3()
//--------------------------------
function vehicle::leg3(%clientId)
{
  schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Lap 2\", 1);", 0);
  schedule("messageAll(0, \"~wshell_click.wav\");", 0);
}

//-------------------------------------
//vehicle::setWayPoint()
//-------------------------------------
function vehicle::setWayPoint(%clientid)
{
	dbecho(2,"setting up waypoints...");
	
	%group = nameToId("MissionGroup\\destinations");

	//flow controlled by triggers
	
	if($currentLeg[%clientId] == 0)
	{
		%obj = Group::getObject(%group, 0);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 1)
	{
		%obj = Group::getObject(%group, 1);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 2)
	{
		%obj = Group::getObject(%group, 2);
		$currentLeg[%clientId]++;
	}
	else if($currentLeg[%clientId] == 3)
	{
		%obj = Group::getObject(%group, 0);
		$currentLeg[%clientId]=1;
	}
	

	//find the position of the next station
	
	%position = GameBase::getPosition(%obj);
	%x = getWord(%position, 0);
	%y = getWord(%position, 1);
	
	//setway point
	
	issueCommand(%clientId, %clientId, 0, "Waypoint set to next Lap station", %x, %y);
}       

//-----------------------------------------
//GroupTrigger::onEnter()
//-----------------------------------------
function GroupTrigger::onEnter(%this, %object)
{

		%cl = GameBase::getControlClient(%object);

		if(%this.num == "Trigger1" && $currentLeg[%cl] == 1)
		{
			Vehicle::setWayPoint(%cl);
			vehicle::leg2(%cl);
		}
		else if(%this.num == "Trigger2" && $currentLeg[%cl] == 2)
		{
			Vehicle::setWayPoint(%cl);
			vehicle::leg3(%cl);
		}
		else if(%this.num == "Trigger3" && $currentLeg[%cl] == 3)
		{  
			%cl.scoreKills++;
			$CompletedRounds[%cl]++;
			Vehicle::setWayPoint(%cl);
			vehicle::leg1(%cl);
		}
}	



function DM::checkMissionObjectives(%playerId) 
{
   if(DM::missionObjectives(%playerId)) 
      schedule("nextMission();", 0);
	if($DMScoreLimit > 0)
		if($CompletedRounds[%playerId] >= $DMScoreLimit)
		{
	      		$timeLimitReached = true;
   	   		$timeReached = 1;
			DM::missionObjectives();
			Server::nextMission();
		}
}


function DM::missionObjectives()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++)
		{
			if((%clientList[%i]).ratio < (%clientList[%i+1]).ratio)
			{
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1]	= %hold;
				%doIt=1;
			}
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
	for(%l = -1; %l < 1 ; %l++) {		
		%lineNum = 0;
		if($timeReached == "")
		{
	 	  	Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
	  		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
			Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
	   		Team::setObjective(%l, %lineNum++, %str);
	   		Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Complete as many rounds as possible!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Kill the other players!");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>   -Stay Alive!");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, "<f1>Remember to stay within the mission area, which is defined by the extents of your commander screen map."	@ 
	 	                                 " If you go outside of the mission area you will have 3 seconds to get back into the mission area, or you'll start taking damage!");
	 	  	Team::setObjective(%l, %lineNum++, " ");
	 	  	Team::setObjective(%l, %lineNum++, " ");
		  	Team::setObjective(%l, %lineNum++, "<f5>TOP PLAYERS ARE: " );
	 	  	Team::setObjective(%l, %lineNum++, " ");
	   	}
	   	else
	   	{
			Team::setObjective(%l, %lineNum++, "<f5>Mission Summary:");
	 	  	Team::setObjective(%l, %lineNum++, " " );
	 	  	Team::setObjective(%l, %lineNum++, "<f1>     - The Best Player(s): " );
		}

		%i=0;
		%TopRatio="";
		while(%i < %numClients)
		{
			Team::setObjective(%l, %lineNum++, "<L10><f1><Bskull_big.bmp>\n" @ Client::getName(%clientList[%i]) @ " finished " @ $CompletedRounds[%clientList[%i]] @ " Rounds.");
			%TopRatio = (%clientList[%i]).ratio;
			%i++;
		}

		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}
	$timeReached="";
}






