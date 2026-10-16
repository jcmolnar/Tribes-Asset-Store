// Tribes Arena v 1.3.1
// Robert "Rasia" Hinkle
// This is a mission type taken from the idea of Clan Arena back in the good old Quake 1 days
// Its a Team DM game, in which everyone spawns, you rush for weapons, and try to kill each other
// When you die, you sit in observer mode until one team is all dead.  When that happens everyone respawns.
// I used a couple definations here:  a Match is a full compatition between two teams.  Each match is made
// up of a set of Games.  When one team fully dies, thats the end of a game.  Most matches are 3 out of 5 Games.
// I want to thank TheGriffin and Ninja for the help!

$ScoreLimit = 3;				//=== Default ScoreLimit To Win
$ARENA::FairTeams = "True";		//=== Fair Teams

//////////// Don't Modify below this line


//=========================================================================================================================================
// Setting the TeamScores to 0 when the map starts
//=========================================================================================================================================
$TeamMatchScore[0] = 0;
$TeamMatchScore[1] = 0;
$TeamMatchScore[2] = 0;
$TeamMatchScore[3] = 0;
$TeamMatchScore[4] = 0;
$TeamMatchScore[5] = 0;

//=========================================================================================================================================
// MatchStatus keeps track of where the match is.  0=PreMatch, 1=Battle, 2=Pre-Game, 3=Countdown
//=========================================================================================================================================

$MatchStatus = 0;

//=========================================================================================================================================
// Turns off Turrets
//=========================================================================================================================================

$InvList[TurretPack] = 0;
$RemoteInvList[TurretPack] = 0;

	//============ Added These Functions So That Shifter Mod Will Work - Removes Turrets From Shifter Invo's

		$InvList[CameraPack] = 0;							//=== Deployable Camera
		$InvList[TurretPack] = 0;							//=== Deployable Turret
		$InvList[DeployableInvPack] = 0;					//=== Invo
		$InvList[DeployableAmmoPack] = 0;					//=== Ammo
		$InvList[MotionSensorPack] = 0;						//=== Montion Sensor
		$InvList[PulseSensorPack] = 0;						//=== Pulse Sensor
		$InvList[DeployableSensorJammerPack] = 0;			//=== Sensor Jammer
		$InvList[DeployableComPack] = 0;					//=== Command Stations
		$InvList[LaserTurret] = 0;							//=== Laser Turret
		//$InvList[ForceFieldPack] = 0;						//=== Force Field
		//$InvList[LargeForceFieldPack] = 0;				//=== Force Field Large
		$InvList[DeployableElf] = 0;						//=== Deployable Elf
		$InvList[TeleportPack] = 0;							//=== Deployable Teleporter
		$InvList[PlatformPack] = 0;							//=== Deployable Platform
		$InvList[TreePack] = 0;								//=== Deployable Tree
		$InvList[HoloPack] = 0;								//=== Hologram
		$InvList[PlantPack] = 0;							//=== Healing Plant
		$InvList[LaunchPack] = 0;							//=== Launch Pad
	
		$RemoteInvList[CameraPack] = 0;						//=== Deployable Camera
		$RemoteInvList[TurretPack] = 0;						//=== Deployable Turret
		$RemoteInvList[DeployableInvPack] = 0;				//=== Invo
		$RemoteInvList[DeployableAmmoPack] = 0;				//=== Ammo
		$RemoteInvList[MotionSensorPack] = 0;				//=== Montion Sensor
		$RemoteInvList[PulseSensorPack] = 0;				//=== Pulse Sensor
		$RemoteInvList[DeployableSensorJammerPack] = 0;		//=== Sensor Jammer
		$RemoteInvList[DeployableComPack] = 0;				//=== Command Stations
		$RemoteInvList[LaserTurret] = 0;					//=== Laser Turret
		//$RemoteInvList[ForceFieldPack] = 0;				//=== Force Field
		//$RemoteInvList[LargeForceFieldPack] = 0;			//=== Force Field Large
		$RemoteInvList[DeployableElf] = 0;					//=== Deployable Elf
		$RemoteInvList[TeleportPack] = 0;					//=== Deployable Teleporter
		$RemoteInvList[PlatformPack] = 0;					//=== Deployable Platform
		$RemoteInvList[TreePack] = 0;						//=== Deployable Tree
		$RemoteInvList[HoloPack] = 0;						//=== Hologram
		$RemoteInvList[PlantPack] = 0;						//=== Healing Plant
		$RemoteInvList[LaunchPack] = 0;						//=== Launch Pad
	






//=========================================================================================================================================
// Makes InvStations REAL hard to kill
//=========================================================================================================================================

StaticShapeData InventoryStation
{
   description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 10000.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

//========================================================================================================================================
// Objective Functions
// Now the Team Scores display the Varible TeamMatchScore, which is how many Games each team has won this match
//========================================================================================================================================

function ObjectiveMission::refreshTeamScores()
{
  %nt = getNumTeams();

  Team::setScore(-1, "%t\t  0", 0);
  for(%i = -1; %i < %nt; %i++)
  {
      Team::setScore(%i, "%t\t  " @ $TeamMatchScore[%i], $TeamScore[%i]);
      for(%j = 0; %j < %nt; %j++) 
         Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $TeamMatchScore[%j]);
  }
}

//========================================================================== Blanked so ScoreLimit won't change missions (like a cap limit)

function ObjectiveMission::checkScoreLimit()
{
}


//=========================================================================================================================================
// Admin Functions
//=========================================================================================================================================
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
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);  //Voted Admins can Admin others
  	if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
         }
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
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
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
	  	  Client::addMenuItem(%clientId, %curItem++ @ "Change Winning Score", "cwinscore"); //Admins can Change MatchScoreLimit
		  Client::addMenuItem(%clientId, %curItem++ @ "Reset Match", "resetmatch");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
}


//========================================================================================================================================
// Called when a client FIRST connects to a map to Choose thier Team (-2 is Obs, -1 is Automatic)
//========================================================================================================================================

function processMenuInitialPickTeam(%clientId, %team)
{
   
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
	  %clientId.matchteam = -2;
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
	  %clientId.matchteam = %team; // Puts the selected team into the Structure
	  if ($MatchStatus == 0 || $MatchStatus == 2)
		%clientId.notready = true;  // Sets the Client to not ready
   }
}

//=========================================================================================================================================
// Called to sort out what Menu selections do :: Admin Menus
//=========================================================================================================================================

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT: client-supplied menu codes with no admin check.
   if(!%clientId.isAdmin && (%opt == "cwinscore" || %opt == "resetmatch")) return;

   if(%opt == "fteamchange") //fteamchange is an Admin forcing a client to change teams
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
	  
	  if ($ARENA::FairTeams)
	  {
	  	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	  	return;
	  }
	  
   }      
   else if(%opt == "changeteams") //Client changing his own team.  Note, if the matchstatus is anything but 0, you can only goto Observer
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         if ($MatchStatus == 0)
		 {
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		 }

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
    else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
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
   else if (%opt == "cwinscore") // Changes $ScoreLimit to whatever is selected
   {
      Client::buildMenu(%clientId, "Change Winning Score:", "cwscore", true);
      Client::addMenuItem(%clientId, "13 out of 5", 3);
      Client::addMenuItem(%clientId, "24 out of 7", 4);
      Client::addMenuItem(%clientId, "35 out of 9", 5);
      Client::addMenuItem(%clientId, "46 out of 11", 6);
      Client::addMenuItem(%clientId, "57 out of 13", 7);
      Client::addMenuItem(%clientId, "68 out of 15", 8);
      Client::addMenuItem(%clientId, "79 out of 17", 9);
      Client::addMenuItem(%clientId, "810 out of 19", 10);
      return;
   }	
   else if (%opt == "resetmatch") // Calls the Arena Reset function to reset the match
	{
		Arena::ResetMatch();
		messageall(0, Client::getName(%clientId) @ " has reset the match.");
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

function processMenuCWScore(%clientId, %opt) // This changes the ScoreLimit, called from the Menu
{
	if(!%clientId.isAdmin) return;	// PORT: was unchecked
	%opt = floor(%opt);
	messageAll(0, Client::getName(%clientId) @ " has changed the Winning Score to " @ %opt);
	$ScoreLimit = %opt;
}

//=========================================================================================================================================
// Called when a Team Change is in effect
//=========================================================================================================================================
function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   
   if(%team == -2)
   {
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			else
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
		    Game::refreshClientScore(%clientId);
			if ((Arena::CountTeamPlayers(%clientId.matchteam) == 0) && (%clientId.matchteam != -2) && $MatchStatus == 1)  // If the observer was the last guy on the team, the other team wins
			{
				%temp = 1 - %clientId.matchteam;
				%clientId.matchteam = -2;
				centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 10);
				$MatchStatus = 2;
				Arena::GameOver(%temp);
			}
			%clientId.matchteam = -2;

		}
	   return;
   }
   else if ($MatchStatus == 1 && %team != -2)
   {
		Client::sendMessage(%clientId,0,"Game in Progress, as soon as one team dies, you will spawn");
		%clientId.matchteam = %team;
		return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");


   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
   %clientId.matchteam = %team; // Sets the clients.matchteam to whatever team he joined

}

//=========================================================================================================================================
// Mostly a copy of the above function, but this one doesn't reset your .matchteam varible
//=========================================================================================================================================
function Arena::PickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
 
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;


   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if(%team == -2)
   {
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
		    Game::refreshClientScore(%clientId);
		

		}
        return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);
	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
}

//=========================================================================================================================================
// Observer Functions
// triggerUp is the Fire Key, as far as I can tell, this controls "Fire when ready"
//=========================================================================================================================================
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
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly")
   {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
   else if(%client.observerMode == "justJoined")
   {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   }
   else if(%client.observerMode == "pregame" && ($MatchStatus == 0 || $MatchStatus == 2)) // if client is in pregame, and the match is at a point where he can ready or unready
   {
	 if(%client.notready) // If he is not ready, ready him
      {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
          bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
		  centerprint(%client, "", 0);
		  Arena::PreGameMode();
      }
      else // else unready him
      {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
			Arena::PreGameMode();
      }
	}  		
}


//=========================================================================================================================================
// Game Functions
// called right at the start of a new map
//=========================================================================================================================================
function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {

   	Game::refreshClientScore(%cl);  // Originally it had you come out of Obs here, took it out
	}
   Game::checkTimeLimit();
}

//=========================================================================================================================================
// Called when a player Physically spawns
//=========================================================================================================================================

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

   Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Tribes Arena Version 1.3.1\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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
	      
		// This section of code forces them to ALWAYS enter pregame on spawn

	         if ($MatchStatus != 1)  // If Spawning, and a battle isn't raging then Ready up Boys
			 {
				%clientId.observerMode = "pregame";
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
				%clientId.notready = true;
				centerprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
			 }

	   }
      return true;
	}
	else 
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}


//=========================================================================================================================================
// Called when someone first connects into the Mission
//=========================================================================================================================================
function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   GameBase::setTeam(%clientId, -1);

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);


      %clientId.observerMode = "pickingTeam";

      if($MatchStatus != 0) // If a match is in progress, wait in observer until its done
      {
         %clientId.observerMode = "observerFly";
		 bottomprint(%clientId, "<jc><f1>Server is running Tribes Arena v1.3.1.  Match has started, Please wait until its finished.  Score limit is " @ $ScoreLimit, 5);
         return;
      }
      else // Else choose your team
      {
         bottomprint(%clientId, "<jc><f1>Server is running Tribes Arena v1.3.1.  Match has not yet started, Pick a Team.  Score limit is " @ $ScoreLimit, 5);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";

}


//=========================================================================================================================================
// when a client connects, zero out that id's stats
//=========================================================================================================================================
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	%playerId.matchteam = -2;
	%playerId.streak = 0;
	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
}

//=========================================================================================================================================
// When someone is killed this is where it goes
//=========================================================================================================================================
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
      %killerId.scoreKills++;
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
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
	 %killerId.scoreKills++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }

	if ($MatchStatus == 1) // This test keeps from one team winning, and then getting their last member killed and screwing up the whole thing :)
		Arena::clientKilled(%playerId, %killerId);

}	

//=========================================================================================================================================
// Handles all the team counting, making sure teams are still full
//=========================================================================================================================================
function Arena::clientKilled(%playerId, %killerId)
{
	%teamCount = Arena::CountTeamPlayers(%playerId.matchteam);
	%otherteam = 1 - %playerId.matchteam;
	schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 3); // the " @ @ " puts the value in when the schedule starts, instead of waiting until it gets set off to evaluate it
	%teamCount--; // I subtract one manually, because the PickTeam won't go off until after this, so the dead client will still be on the team
	if (%teamCount == 0 && $MatchStatus == 1) //Someone won a game woohoo!
	{
	        $MatchStatus = 2;
		centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 10);
		schedule("Arena::GameOver(" @ %otherteam @ ");", 5);  // Game is over, pass the winning team's index
	}
}

//=========================================================================================================================================
// Someone bailing on the server
//=========================================================================================================================================
function Client::leaveGame(%clientId)
{

   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
	
	messageAll(0, strcat(Client::getName(%clientId), " has chickened OUT!"));


	if (Client::getTeam(%clientId) > -1)
	{
		Arena::PickTeam(%clientId, -2);

		if (Arena::CountTeamPlayers(%clientId.matchteam) == 0 && $MatchStatus == 1)
		{	
			$MatchStatus = 2;
			%otherteam = 1 - %clientId.matchteam;
			%clientId.matchteam = -2;
			Arena::GameOver(%otherteam);
			centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 10);
		}
	}


}

		
//=========================================================================================================================================
// Arena Functions
// Called when one team no longer has members in a game
//=========================================================================================================================================
function Arena::GameOver(%winningTeam)
{
	

//=========================================================================================================================================
// Big Statement.  Each client is killed to prevent ghosting and then kicked to observer
//=========================================================================================================================================
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		%player = Client::getOwnedObject(%cl);
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
		{
			playNextAnim(%cl);
			Player::kill(%cl);
		}
		

		Arena::PickTeam(%cl, -2);
	}


	$TeamMatchScore[%winningTeam]++;
	ObjectiveMission::refreshTeamScores();
	if ($TeamMatchScore[%winningTeam] == $ScoreLimit || Arena::CountTeam(1 - %winningTeam) == 0) //If a team has hit the ScoreLimit or if a team is completely empty of players
	{
		Arena::MatchCompleted(%winningTeam); // Match Over
	}
	else // Else put all the clients back on the team they belong
	{		
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{	

			Arena::PickTeam(%cl, %cl.matchteam);
			Client::setSkin(%cl, $Client::info[%cl, 0]);
			%cl.notready = true;
			bottomprint(%cl, "<f1><jc>Press FIRE when ready.", 0);
		}

	Arena::PreGameMode(); // Back to Pre-Game Mode
	}		

}

//=========================================================================================================================================
//Called when a Team has won the Match
//=========================================================================================================================================

function Arena::MatchCompleted(%winningTeam)
{
	messageAll(0, getTeamName(%winningTeam) @ " has won the match.");
	Arena::ResetMatch();
}

//=========================================================================================================================================
// Starts the whole process over
//=========================================================================================================================================

function Arena::ResetMatch()
{
	$MatchStatus = 0;
	for (%i = 0; %i < getNumTeams(); %i++) // Clears the team score
		$TeamMatchScore[%i] = 0;

	ObjectiveMission::refreshTeamScores();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))  // Sets all players to Observer Mode
	{	
		%player = Client::getOwnedObject(%cl);
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
		{
			playNextAnim(%cl);
			Player::kill(%cl);
		}
	processMenuPickTeam(%cl, -2);
	%cl.matchteam = -2;
        bottomprint(%cl, "<jc><f1>Server is running Tribes Arena v1.3.1 and is in Pre-Match Mode. Pick a Team.  Score limit is " @ $ScoreLimit, 5);
	}


}	// NOTE: After this function the MatchStatus is now in Pre-Match mode, so people can join teams via the menu


//=========================================================================================================================================
function Arena::CheckReadyStatus()
{
		%NotReadyString = "Clients not ready:";
		%NotReadyCount = 0;

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) // Check the Ready Status of each Client
		{
			if(%cl.observerMode == "pregame" && %cl.notready)
			{
				    %NotReadyCount++;
					%NotReadyString = %NotReadyString @ " " @ Client::getName(%cl);
			 }
		}

		if (%NotReadyCount > 0)
		{
			%NotReadyString = %NotReadyString @ ".";
			messageAll(0, %NotReadyString);
			return false;
		}
		else
			return true;
}

//=========================================================================================================================================
// Pre-Game Mode Function
//=========================================================================================================================================

function Arena::PreGameMode()
{

	if (Arena::CountTeamPlayers(0) < 1 || Arena::CountTeamPlayers(1) < 1) // If teams are empty, say so
	{
		messageAll(0, "Teams not full, waiting for more players");
	}
	else
	{

   		
		if (Arena::CheckReadyStatus()) // If everyone is ready, lets rumble!!
		{
			$MatchStatus = 3;
			messageAll(0, "Arena Battle Starts in 5 seconds");
			schedule("messageAll(0, \"Arena Battle Starts in 4 seconds\");", 1);
			schedule("messageAll(0, \"Arena Battle Starts in 3 seconds\");", 2);
			schedule("messageAll(0, \"Arena Battle Starts in 2 seconds\");", 3);
			schedule("messageAll(0, \"Arena Battle Starts in 1 seconds\");", 4);
			schedule("Arena::StartGame();", 5);

		}

	}
}

//=========================================================================================================================================
// Starts the Game
//=========================================================================================================================================

function Arena::StartGame()
{
	$MatchStatus = 1;
	messageAll(0, "FIGHT!!!!");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{		
		%cl.observerMode = "";
		Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		bottomprint(%cl, "", 0);
	}
}

//=========================================================================================================================================
// Counts the people physically alive on a team
//=========================================================================================================================================

function Arena::CountTeamPlayers(%team)
{
	%teamCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if (Client::getTeam(%cl) == %team)
			%teamCount++;
	}

	return %teamCount;
}

//=========================================================================================================================================
// Counts the people on a team, even if they are in Observer mode currently
//=========================================================================================================================================

function Arena::CountTeam(%team)
{
	%teamCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if (%cl.matchteam == %team)
			%teamCount++;
	}

	return %teamCount;
}

//=========================================================================================================================================
//When a new level is loaded, reload the base files I overwrote functions from.  If its an arena map, I will re-overwrite them
//=========================================================================================================================================

function Server::loadMission(%missionName, %immed)
{
   if($loadingMission)
      return;

   exec(observer);
   exec(admin);
   exec(server);
   exec(station);

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

//=========================================================================================================================================

