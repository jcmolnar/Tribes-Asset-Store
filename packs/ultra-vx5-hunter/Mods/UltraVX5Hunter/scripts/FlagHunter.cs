//------------------------------------//
// FlagHunter.cs                      //
// created by Tinman (Kidney Thief)   //
// -----------------------------------//

exec("game.cs");
exec("HunterRecords.cs");

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

function FlagHunter::setGlobalDefaults()
{
   //save some server variables
   if ($FlagHunter::OrigSaved == "")
   {
      $FlagHunter::OrigSaved = true;
      $FlagHunter::origJoinMOTD = $Server::JoinMOTD;
      for (%i = 0; %i < 8; %i++)
      {
         $FlagHunter::origTeamName[%i] = $Server::teamName[%i];
         $FlagHunter::origTeamSkin[%i] = $Server::teamSkin[%i];
      }
   }
   
   
   if ($FlagHunter::TeamModeOn)
   {
      %line1 = "<l44>Ultra Renegades:<f1> FLAG HUNTER v1.4<f0><l0>\n";
      %line2 = "<l47>Modified by: -[PWA]-100%<l0>\n";
      %line3 = "\n";
      %line4 = "<l30><Bflag_atbase.bmp><f1>   TEAM MODE IS ON!    <f0><Bflag_enemycaptured.bmp><n>";
      %line5 = "<l28>http://members.verizon.net/~cmckee1/hunter.zip<l0>\n\n";
      %line6 = "<l36>Press 'O' for the game objectives";
   }
   else
   {
      //don't screw with this - trust me!
      %line1 = "<l44>Ultra Renegades:<f1> FLAG HUNTER v1.4<f0><l0>\n";
      %line2 = "<l47>Modified by: -[PWA]-100%<l0>\n";
      %line3 = "\n";
      %line4 = "<l28>http://members.verizon.net/~cmckee1/hunter.zip<l0>\n\n";
      %line5 = "<l36>Press 'O' for the game objectives";
   }
   
   $FlagHunter::origJoinMOTD = $Server::JoinMOTD;
   $Server::JoinMOTD = "";
   for (%i = 1; %i <= 7; %i++)
   {
      $Server::JoinMOTD = $Server::JoinMOTD @ %line[%i];
   }
   
   //set the Team names
   if ($FlagHunter::TeamModeOn)
   {
      $Server::teamName0 = "Blood Eagle";
      $Server::teamSkin0 = "beagle";
      $Server::teamName1 = "Diamond Sword";
      $Server::teamSkin1 = "dsword";
   }
   else
   {
      $Server::teamName0 = "Hunters";
      $Server::teamSkin0 = "beagle";
   }
   
   //  GAME PREFERENCES 
   $Server::TeamDamageScale = 1; //team damage must stay on

   //default ban list
   //$FlagHunter::banList[0, type] = "Mortar";
   //$FlagHunter::banList[0, name] = "Mortar";
   //$FlagHunter::banList[1, type] = "MineAmmo";
   //$FlagHunter::banList[1, name] = "Mines";
   //$FlagHunter::banList[2, type] = "TurretPack";
   //$FlagHunter::banList[2, name] = "Turrets";
   //$FlagHunter::banList[3, type] = "";

   //default spawn list
   $FlagHunter::spawnWeapon = "RaptorRifle";
   $FlagHunter::spawnList[0] = "HunterArmor";
   $FlagHunter::spawnList[1] = "Torque";
   $FlagHunter::spawnList[2] = "Chaingun";
   $FlagHunter::spawnList[3] = "RocketLauncher";
   $FlagHunter::spawnList[4] = "HBeamOfPain";
   $FlagHunter::spawnList[5] = "RaptorRifle";
   $FlagHunter::spawnList[6] = "RepairKit";
   $FlagHunter::spawnList[7] = "Grenade";
   $FlagHunter::spawnList[8] = "MineAmmo";
   $FlagHunter::spawnList[9] = "Beacon";
   $FlagHunter::spawnList[10] = "";

   //Game globals
   $FlagHunter::MostFlagsReturned = "";
   $FlagHunter::MostFlagsReturnCount = 0;
   $FlagHunter::MostFlagsDropped = 0;
   $FlagHunter::MostFlagsDroppedName = "";
   $FlagHunter::NexusCampingTimer = 10;
   $FlagHunter::FlagFadeTime = 120;
   $FlagHunter::CarryingNumber = 7;
   $FlagHunter::YardSaleNumber = 10;
   $FlagHunter::YardSaleTime = 30;
   $FlagHunter::GreedAmount = 8;
   $FlagHunter::HoardStartTime = 20;
   $FlagHunter::HoardEndTime = 15;
}

//call it initially
FlagHunter::setGlobalDefaults();

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

//overwritten to add the one line to drop flags before the %player object gets deleted
function Player::onKilled(%this)
{
   //set the dead flag
	%client = GameBase::getOwnerClient(%this);
	%client.dead = 1;
   
   //first toss all the flags
   Flag::onDrop(%this, unused);
   
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %client @ ");",$AutoRespawn,%client);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%client);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
				Player::dropItem(%this,%type);
		}
	}

   if(%client != -1)
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
      Client::setOwnedObject(%client, -1);
      Client::setControlObject(%client, Client::getObserverCamera(%client));
      Observer::setOrbitObject(%client, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %client.observerMode = "dead";
      %client.dieTime = getSimTime();
   }
}

function Game::clientKilled(%playerId, %killerId)
{
   Game::refreshClientScore(%playerId);
   DM::checkMissionObjectives(%killerId);   
}

function Game::pickRandomSpawn(%team)
{
   //in Hunters, always use the spawn points for team 0
   %team = 0;
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   //in Hunters, always use the spawn points for team 0
   %team = 0;
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

// modified to spawn/respawn player on team0, with custom skin.
function Game::playerSpawned(%pl, %clientId, %armor)
{	
   // use this client's skin preference
   if ($FlagHunter::TeamModeOn)
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
   else
      Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   
   //outfit the player with default equipment
   %clientId.spawn = 1;
   for(%i = 0; (%item = $FlagHunter::spawnList[%i]) != ""; %i++)
      buyItem(%clientId,%item);	
   %clientId.spawn= "";
   Player::useItem(%pl, $FlagHunter::spawnWeapon);
   
   %clientId.flagCount = 1;
   %clientId.inNexusAreaTime = -1;
   Game::refreshClientScore(%clientId);
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
// VOTING CODE

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

      //add an option to track the selected player
      Client::addMenuItem(%clientId, %curItem++ @ "Track player " @ %name, "track " @ %sel);
         
      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
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
   else if(!%clientId.selClient && $curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
         
      if($FlagHunter::GreedMode)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable GREED", "vdgm");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable GREED", "vegm");
      if($FlagHunter::HoardMode)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable HOARD", "vdhm");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable HOARD", "vehm");
      if ($FlagHunter::TeamModeOn)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to play FFA Hunters", "vdth");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to play TEAM Hunters", "veth");

   }
   else if(!%clientId.selClient && %clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");

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
      if ($FlagHunter::GreedMode)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED mode", "dgm");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED mode", "egm");
      if ($FlagHunter::HoardMode)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD mode", "dhm");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD mode", "ehm");
      if ($FlagHunter::TeamModeOn)
         Client::addMenuItem(%clientId, %curItem++ @ "Play FFA Hunters", "dth");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Play TEAM Hunters", "eth");
   }
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   
   if ($FlagHunter::TeamModeOn)
      %numTeams = getNumTeams();
   else
      %numTeams = 1;

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      if ($FlagHunter::TeamModeOn)
      {
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < %numTeams; %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      }
      else
      {
         for(%i = 0; %i < %numTeams; %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
      }
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         if ($FlagHunter::TeamModeOn)
         {
            Client::addMenuItem(%clientId, "1Automatic", -1);
            for(%i = 0; %i < %numTeams; %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         }
         else
         {
            for(%i = 0; %i < %numTeams; %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
         }
         return;
      }
   }
   else if (%opt == "track")
      remoteHuntersSetTarget(%clientId, %cl);
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
   else if(%opt == "vegm")
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
   else if(%opt == "veth")
      Admin::startVote(%clientId, "play TEAM Hunters", "eth", 0);
   else if(%opt == "vdth")
      Admin::startVote(%clientId, "play FFA Hunters", "dth", 0);
   else if(%opt == "eth")
      Admin::setTeamHunters(%clientId, true);
   else if(%opt == "dth")
      Admin::setTeamHunters(%clientId, false);
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
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
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
      %saveMissionName = $curVoteOption;
		Vote::changeMission();
      Server::loadMission(%saveMissionName);
   }
   else if($curVoteAction == "tourney")
      Admin::setModeTourney(-1);
   else if($curVoteAction == "ffa")
      Admin::setModeFFA(-1);
   else if($curVoteAction == "etd")
      Admin::setTeamDamageEnable(-1, true);
   else if($curVoteAction == "dtd")
      Admin::setTeamDamageEnable(-1, false);
   else if($curVoteAction == "egm")
      Admin::setGreedMode(-1, true);
   else if($curVoteAction == "dgm")
      Admin::setGreedMode(-1, false);
   else if($curVoteAction == "ehm")
      Admin::setHoardMode(-1, true);
   else if($curVoteAction == "dhm")
      Admin::setHoardMode(-1, false);
   else if($curVoteAction == "eth")
      Admin::setTeamHunters(-1, true);
   else if($curVoteAction == "dth")
      Admin::setTeamHunters(-1, false);
   else if($curVoteOption == "smatch")
      Admin::startMatch(-1);
}

function Vote::changeMission()
{
   $timeLimitReached = true;
   $timeReached = true;
   DM::missionObjectives();
}

function Admin::setGreedMode(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $FlagHunter::GreedMode = true;
         if(%admin == -1)
            messageAll(1, "GREED mode is ON by consensus!");
         else
            messageAll(1, Client::getName(%admin) @ " has turned GREED mode ON!");
      }
      else
      {
         $FlagHunter::GreedMode = false;
         if(%admin == -1)
            messageAll(1, "GREED mode is OFF by consensus.");
         else
            messageAll(1, Client::getName(%admin) @ " has turned GREED mode Off.");
      }
      
      //update the objectives page
      DM::missionObjectives();
   }
}

function Admin::setHoardMode(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         if(%admin == -1)
         {
            $FlagHunter::HoardMode = true;
            messageAll(1, "HOARD mode is ON by consensus!");
         }
         else
         {
            //make sure an admin isn't screwing with the hoard for his own ends...
            if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
               Client::sendMessage(%admin, 0, "You cannot alter the HOARD mode during the HOARD period.");
            else
            {
               $FlagHunter::HoardMode = true;
               messageAll(1, Client::getName(%admin) @ " has turned HOARD mode ON!");
            }
         }
      }
      else
      {
         if(%admin == -1)
         {
            $FlagHunter::HoardMode = false;
            messageAll(1, "HOARD mode is OFF by consensus.");
         }
         else
         {
            //make sure an admin isn't screwing with the hoard for his own ends...
            %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
            if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
               Client::sendMessage(%admin, 0, "You cannot alter the HOARD mode during the HOARD period.");
            else
            {
               $FlagHunter::HoardMode = false;
               messageAll(1, Client::getName(%admin) @ " has turned HOARD mode OFF.");
            }
         }
      }
      
      //update the objectives page
      DM::missionObjectives();
   }
}

function Admin::setTeamHunters(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         if(%admin == -1)
            messageAll(1, "The consensus wants to play TEAM Hunters!");
         else
            messageAll(1, Client::getName(%admin) @ " has started TEAM Hunters!");
      }
      else
      {
         if(%admin == -1)
            messageAll(1, "The consensus wants to play FFA Hunters!");
         else
            messageAll(1, Client::getName(%admin) @ " has started FFA Hunters!");
      }
      
      //restart the mission
		Vote::changeMission();
      Server::nextMission(true);
      $FlagHunter::TeamModeOn = %enabled;
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;
   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if (%curTimeLeft <= 0)
   {
      $timeLimitReached = true;
      $timeReached = true;
      DM::missionObjectives();
      FlagHunter::restoreServerDefaults();
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 1);
      UpdateClientTimes(%curTimeLeft);
      DM::missionObjectives();
      
      
      if ($FlagHunter::HoardMode)
      {
         if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
         {
            %hoardSecondsLeft = floor(%curTimeLeft - ($FlagHunter::HoardEndTime * 60));
            %hoardMinutesLeft = floor(%hoardSecondsLeft / 60);
            if (((%hoardSecondsLeft / 60) == %hoardMinutesLeft) && (%hoardMinutesLeft > 1))
               MessageAll(1, %hoardMinutesLeft @ " minutes left until the HOARD period is over.~wmine_act.wav");
            else if (%hoardSecondsLeft == 60)
               MessageAll(1, "1 minute left until the HOARD period is over.~wmine_act.wav");
            else if (%hoardSecondsLeft == 30)
               MessageAll(1, "30 seconds left until the HOARD period is over.~wmine_act.wav");
            else if (%hoardSecondsLeft == 10)
               MessageAll(1, "10 seconds left until the HOARD period is over.~wmine_act.wav");
            else if (%hoardSecondsLeft == 5)
               MessageAll(1, "5 seconds left until the HOARD period is over.~wmine_act.wav");
            else if (%hoardSecondsLeft == 0)
               MessageAll(1, "The HOARD period is over - return your flags now!~wmine_act.wav");
         }
         else
         {
            %timeUntilHoard = %curTimeLeft - ($FlagHunter::HoardStartTime * 60);
            if (%timeUntilHoard >= 0)
            {
               if (%timeUntilHoard == 60)
                  MessageAll(1, "The HOARD period begins in 1 minute.~wmine_act.wav");
               else if (%timeUntilHoard == 30)
                  MessageAll(1, "The HOARD period begins in 30 seconds.~wmine_act.wav");
               else if (%timeUntilHoard == 10)
                  MessageAll(1, "The HOARD period begins in 10 seconds.~wmine_act.wav");
               else if (%timeUntilHoard == 5)
                  MessageAll(1, "The HOARD period begins in 5 seconds.~wmine_act.wav");
               else if (%timeUntilHoard == 0)
                  MessageAll(1, "Let the HOARDING begin!~wmine_act.wav");
            }
         }
      }
   }
}

function DM::checkMissionObjectives()
{
   if(DM::missionObjectives()) 
      schedule("nextMission();", 0);
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
         if((%clientList[%i]).score < (%clientList[%i+1]).score)
         {
            %hold = %clientList[%i];
            %clientList[%i] = %clientList[%i+1];
            %clientList[%i+1]= %hold;
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
   for(%l = -1; %l < 2 ; %l++)
   {		
      %lineNum = 0;
      if(! $timeReached)
      {
         Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
         Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
         Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName);
         Team::setObjective(%l, %lineNum++, %str);
         
         //greed mode
         if ($FlagHunter::GreedMode && ($FlagHunter::GreedAmount >= 2))
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - GREED mode is ON!  You must have at least " @ $FlagHunter::GreedAmount @ " flags");
            Team::setObjective(%l, %lineNum++, "<f1>     before you can return them to the Nexus.");
         }
         else
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - GREED mode is Off.");
         }
         
         //hoard mode
         if ($FlagHunter::HoardMode)
         {
            %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
            if ((%curTimeLeft <= ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft > ($FlagHunter::HoardEndTime * 60)))
            {
               %hoardTimeLeft = %curTimeLeft - ($FlagHunter::HoardEndTime * 60);
               %hoardMinutesLeft = floor(%hoardTimeLeft / 60);
               %hoardSecondsLeft = floor(%hoardTimeLeft - (%hoardMinutesLeft * 60));
               if (%hoardMinutesLeft == 0)
               {
                  if (%hoardSecondsLeft == 1)
                     %timeString = "1 second";
                  else
                     %timeString = %hoardSecondsLeft @ " seconds";
               }
               else
               {
                  if (%hoardMinutesLeft == 1)
                     %timeString = "1 minute";
                  else
                     %timeString = %hoardMinutesLeft @ " minutes";
                  if (%hoardSecondsLeft > 0)
                  {
                     if (%hoardSecondsLeft == 1)
                        %timeString = %timeString @ " and 1 second";
                     else
                        %timeString = %timeString @ " and " @ %hoardSecondsLeft @ " seconds";
                  }
               }
               Team::setObjective(%l, %lineNum++, "<f1>   - HOARD mode is ON!  You will not be able to return");
               Team::setObjective(%l, %lineNum++, "<f1>     any flags to the nexus for " @ %timeString @ ".");
            }
            else
            {
               %timeUntilHoard = %curTimeLeft - ($FlagHunter::HoardStartTime * 60);
               if (%timeUntilHoard > 0)
               {
                  %hoardMinutesLeft = floor(%timeUntilHoard / 60);
                  if (%hoardMinutesLeft == 0)
                  {
                     %hoardSecondsLeft = floor(%timeUntilHoard);
                     if (%hoardSecondsLeft == 1)
                        %timeString = "1 second";
                     else
                        %timeString = %hoardSecondsLeft @ " seconds";
                  }
                  else
                  {
                     if (%hoardMinutesLeft == 1)
                        %timeString = "approximately 1 minute";
                     else
                        %timeString = "approximately " @ %hoardMinutesLeft @ " minutes";
                  }
                  Team::setObjective(%l, %lineNum++, "<f1>   - HOARD mode is ON!  In " @ %timeString @ " you will");
                  Team::setObjective(%l, %lineNum++, "<f1>     not be able to return any flags to the nexus.");
               }
            }
         }
         else
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - HOARD mode is Off.");
         }
         
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
         if ($FlagHunter::TeamModeOn)
         {
            Team::setObjective(%l, %lineNum++, "<f3>  TEAM mode is ON!  <f1>Don't kill your teammates!");
            Team::setObjective(%l, %lineNum++, "<f1>  Kill the opposing team.  Each person you kill, grab the flag(s) they drop.");
         }
         else
            Team::setObjective(%l, %lineNum++, "<f1>  Kill everyone!  Each person you kill, grab the flag(s) they drop.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Return the flags you've captured to the Nexus.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Scoring is progressive:  1 flag  = 1 point,");
         Team::setObjective(%l, %lineNum++, "<f1>                              2 flags = 1 + 2 = 3 points,");
         Team::setObjective(%l, %lineNum++, "<f1>                              3 flags = 1 + 2 + 3 = 6 points, etc...");
         Team::setObjective(%l, %lineNum++, "<f1>   - If you camp near the Nexus, you will take damage!");
         Team::setObjective(%l, %lineNum++, "<f1>   - If GREED mode is on, you will need " @ $FlagHunter::GreedAmount @ " flags before you can");
         Team::setObjective(%l, %lineNum++, "<f1>     return them to the Nexus.");
         if ($FlagHunter::HoardEndTime == 1)
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - If HOARD mode is on, you will not be able to return any flags");
            Team::setObjective(%l, %lineNum++, "<f1>     from " @ $FlagHunter::HoardStartTime @ " minutes until 1 minute left in the game.");
         }
         else
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - If HOARD mode is on, you will not be able to return any flags");
            Team::setObjective(%l, %lineNum++, "<f1>     from " @ $FlagHunter::HoardStartTime @ " minutes until " @ $FlagHunter::HoardEndTime @ " minutes left in the game.");
         }
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Weapons not available at inventory station are: " );
         
         for (%j = 0; $FlagHunter::banList[%j, type] != ""; %j++)
         {
            Team::setObjective(%l, %lineNum++, "<f1>   - " @ $FlagHunter::banList[%j, name]);
         }
         
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Additional info:" );
         Team::setObjective(%l, %lineNum++, "<f1>   - The Nexus is marked on your commander screen.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Flags fade out after " @ $FlagHunter::FlagFadeTime @ " seconds.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Only players carrying 5 or more flags have a flag on their back.");
         Team::setObjective(%l, %lineNum++, "<f1>   - The TAB menu lists how many flags each player is carrying.");
         Team::setObjective(%l, %lineNum++, "<f1>   - You can find and track an opponent by selecting the player");
         Team::setObjective(%l, %lineNum++, "<f1>     from the TAB menu, and choosing the \"Track player\" option.");
      }
      else if (! $FlagHunter::TeamModeOn)
      {
         Team::setObjective(%l, %lineNum++, "<f1>     Highest Flag return count held by: " );
         if ($FlagHunter::MostFlagsReturnCount == 0)
            Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ "<f5> with a return count of " @ $FlagHunter::MostFlagsReturnCount @ "!");
         else
            Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ $FlagHunter::MostFlagsReturned @ "<f5> with a return count of " @ $FlagHunter::MostFlagsReturnCount @ "!");
         Team::setObjective(%l, %lineNum++, "<f1>     Highest Score: " );
         Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ " with a score of " @ (%clientList[0].score) @ "!");
         if (($FlagHunter::MostFlagsEverCount[$missionName] > 0) && ($FlagHunter::MostFlagsEver[$missionName] != ""))
         {
            Team::setObjective(%l, %lineNum++, "<f4>     Record Holder for this mission: " );
            Team::setObjective(%l, %lineNum++, "<L14><f5><Bflag_enemycaptured.bmp>\n" @ $FlagHunter::MostFlagsEver[$missionName] @ "<f5> with a return count of " @ $FlagHunter::MostFlagsEverCount[$missionName] @ "!");
         }
         if (($FlagHunter::MostFlagsDropped > 0) && ($FlagHunter::MostFlagsDroppedName != ""))
         {
            Team::setObjective(%l, %lineNum++, "<f1>     Honorary Greed award for this mission: " );
            Team::setObjective(%l, %lineNum++, "<f1>                     " @ $FlagHunter::MostFlagsDroppedName @ " who dropped " @ $FlagHunter::MostFlagsDropped @ "!");
         }
         Team::setObjective(%l, %lineNum++, " " );
         Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Score");
         %i=0;
         while(%i < %numClients)
         {
            %plyr = %clientList[%i];
            Team::setObjective(%l, %lineNum++, "<f1> - " @ Client::getName(%plyr) @ "<L32>" @ %plyr.score);
            echo(Client::getName(%plyr) @ "  " @ %plyr.score);
            %i++;
         }
         
         //this is really hacky, but it's seems to be the only guaranteed place to restore the server defaults
         FlagHunter::restoreServerDefaults();
      }
      else
      {
         if ($TeamScore[0] == $TeamScore[1])
         {
            Team::setObjective(%l, %lineNum++, "<f5>     The game ended in a tie where each team had a score of " @ $TeamScore[0]);
            %winner = -1;
         }
         else if ($TeamScore[0] > $TeamScore[1])
            %winner = 0;
         else
            %winner = 1;
         
         if (%l == %winner)
            Team::setObjective(%l, %lineNum++, "<f5>     Your team won with a score of " @ $TeamScore[%winner]);
         else if (%winner != -1)
            Team::setObjective(%l, %lineNum++, "<f5>     The " @ getTeamName(%winner) @ " team won with a score of " @ $TeamScore[%winner]);
            
         Team::setObjective(%l, %lineNum++, " ");
         
         if (%l == 0)
            %enemyTeam = 1;
         else
            %enemyTeam = 0;
            
         Team::setObjective(%l, %lineNum++, "<f1><Bflag_atbase.bmp>\n Your team had a score of " @ $TeamScore[%l]);
         Team::setObjective(%l, %lineNum++, "<f1><Bflag_enemycaptured.bmp>\n The " @ getTeamName(%enemyTeam) @ " team had a score of " @ $TeamScore[%enemyTeam]);
         Team::setObjective(%l, %lineNum++, " " );
         Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Score");
         
         %i=0;
         while(%i < %numClients)
         {
            %plyr = %clientList[%i];
            Team::setObjective(%l, %lineNum++, "<f1> - " @ Client::getName(%plyr) @ "<L32>" @ %plyr.score);
            echo(Client::getName(%plyr) @ "  " @ %plyr.score);
            %i++;
         }
         
         //this is really hacky, but it's seems to be the only guaranteed place to restore the server defaults
         FlagHunter::restoreServerDefaults();
      }
   
      for(%s = %lineNum+1; %s < 50 ;%s++)
         Team::setObjective(%l, %s, " ");
   }
   $timeReached = false;
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

 //set the client score line in the TAB menu
function Game::refreshClientScore(%clientId)
{
   if ($FlagHunter::TeamModeOn)
   {
      if ($Server::teamName[0] == "Blood Eagle" && $Server::teamName[1] == "Diamond Sword")
      {
         if (Client::getTeam(%clientId) == 0)
            Client::setScore(%clientId, "%n\tB Eagle\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p", %clientId.score + (9 - %team) * 10000);
         else if (Client::getTeam(%clientId) == 1)
            Client::setScore(%clientId, "%n\tD Sword\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p", %clientId.score + (9 - %team) * 10000);
         else
            Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p", %clientId.score + (9 - %team) * 10000);
      }
      else
         Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p", %clientId.score + (9 - %team) * 10000);
   }
   else
      Client::setScore(%clientId, "%n\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
   
   //also set the team scores
   %nt = getNumTeams();
   for(%i = -1; %i < %nt; %i++)
      Team::setScore(%i, "%t\t  " @ $teamScore[%i], $teamScore[%i]);
}

function Mission::init()
{
   //see if team hunters is an option
   if (getNumTeams() < 2)
      $FlagHunter::TeamModeOn = false;
      
   //set the TAB menu format
   
   if ($FlagHunter::TeamModeOn)
   {
      setClientScoreHeading("Player Name\t\x62Team\t\x9CScore\t\xC5Flags\t\xE8Ping");
      setTeamScoreHeading("Team Name\t\xC0Score");
   }
   else
   {
      setClientScoreHeading("Player Name\t\x75Score\t\xA5Flags\t\xCFPing\t\xEFPL");
      setTeamScoreHeading("");
   }

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++)
   {
      $teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
      Team::setObjective(%i, $firstTeamLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      $firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
      $teamScore[%i] = 0;
      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   $numObjectives = 0;
   newObject(ObjectivesSet, SimSet);
   addToSet(MissionCleanup, ObjectivesSet);
   
   // Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
   %group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %i + $firstObjectiveLine;
      ObjectiveMission::objectiveChanged(%obj);
   }
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
   
   DM::missionObjectives();
   
   //Hunter specific stuff...
   FlagHunter::invalidateItems();
   
   //validate the hoard time vars
   if ($FlagHunter::HoardEndTime < 1)
      $FlagHunter::HoardEndTime = 1;
   if ($FlagHunter::HoardStartTime - $FlagHunter::HoardEndTime < 1)
   {
      //reset the start and end times
      $FlagHunter::HoardStartTime = 5;
      $FlagHunter::HoardEndTime = 2;
      $FlagHunter::HoardMode = false;
   }
   
   %numClients = getNumClients();
   for (%i = 0; %i < %numclients; %i++)
   { 
      %client = getClientByIndex(%i);
      setCommandStatus(%client, 0, "");
      %client.target = -1;
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
//FLAG functions

function FlagHunter::updateTrackers(%client, %numFlags, %event)
{
   if (%event == "dropped")
   {
      %eventString = " dropped ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags;
   }
   else if (%event == "capped")
   {
      %eventString = " CAPPED ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags;
   }
   else
   {
      %eventString = " has ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags + 1;
   }
   
   //Set the team prefix
   if ($FlagHunter::TeamModeOn)
   {
      %teamPrefix = "T- ";
      %enemyPrefix = "E- ";
   }
   else
   {
      %teamPrefix = "";
      %enemyPrefix = "";
   }
      
   //update anyone who is tracking this player
   %name = Client::getName(%client);
   %numClients = getNumClients();
   for (%i = 0; %i < %numclients; %i++)
   { 
      %tracker = getClientByIndex(%i);  
      if (%tracker != %client && %tracker.target == %client)
      {
         %targetPos = GameBase::getPosition(%client); 
         %posX = getWord(%targetPos, 0);
         %posY = getWord(%targetPos, 1);
         
         //issue command to teammate trackers
         if (Client::getTeam(%tracker) == Client::getTeam(%client))
         {
            if (%teamFlagNum <= 0)
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ "no flags.", %posX, %posY);
            else if (%teamFlagNum == 1)
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ "1 flag.", %posX, %posY);
            else
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ %teamFlagNum @ " flags!", %posX, %posY);
         }
         //issue command to enemy trackers
         else
         {
            if (%enemyFlagNum <= 0)
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ "no flags.", %posX, %posY);
            else if (%enemyFlagNum == 1)
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ "1 flag.", %posX, %posY);
            else
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ %enemyFlagNum @ " flags!", %posX, %posY);
         }
      }
   }
}

function fadeOutObject(%object)
{
   GameBase::startFadeOut(%object);
   schedule("deleteObject(" @ %object @ ");", 2.5, %object);
}

//executed every time a player dies, drops, becomes observer, whatever...
function Flag::onDrop(%player, %type)
{
   %client = Player::getClient(%player);
   if (%client.dead)
      %numFlagsDropped = %client.flagCount;
   else
      %numFlagsDropped = %client.flagCount - 1;
      
   if (%numFlagsDropped <= 0)
      return;
   
   if (%numFlagsDropped > $FlagHunter::YardSaleNumber)
   {
      %numberSinglePointFlags = $FlagHunter::YardSaleNumber;
      %excess = %numFlagsDropped - $FlagHunter::YardSaleNumber;
      if (%excess % 2 == 1)
      {
         %numberSinglePointFlags++;
         %excess--;
      }
      %numberToSpawn = %numberSinglePointFlags + floor(%excess / 2);
   }
   else
   {
      %numberToSpawn = %numFlagsDropped;
      %numberSinglePointFlags = %numFlagsDropped;
   }
   
   for (%i = 0; %i < %numberToSpawn; %i++)
   {
      // create a flag
      %flag = newObject("", Item, Flag, 1, false, false, true);
 	 	addToSet("MissionCleanup", %flag);
      
      if (%i < %numberSinglePointFlags)
         %flag.value = 1;
      else
         %flag.value = 2;
          
      %flag.carrier = -1;
      
      GameBase::setTeam(%flag, -1);
      GameBase::throw(%flag, %player, 10, false);
      
      //if the flag hasn't been picked up in 2 minutes or so, fade it out
      schedule("fadeOutObject(" @ %flag @ ");", $FlagHunter::FlagFadeTime, %flag);
      
      //randomize the direction a bit so the flags don't all bunch up
      %curVelocity = Item::getVelocity(%flag);
      %velX = getWord(%curVelocity, 0) + floor(getRandom() * 20) - 10;
      %velY = getWord(%curVelocity, 1) + floor(getRandom() * 20) - 10;
      %velZ = getWord(%curVelocity, 2) + floor(getRandom() * 20) - 10;
      Item::setVelocity(%flag, %velX @ " " @ %velY @ " " @ %velZ);
   }
      
   //remove the flag from the player   
   Player::setItemCount(%client, "Flag", 0);
   %client.carryFlag = "";
   if (%client.dead)
      %client.flagCount = 0;
   else
      %client.flagCount = 1;
   Game::refreshClientScore(%client);
   
   //update anyone who is tracking this player
   FlagHunter::updateTrackers(%client, %numFlagsDropped, "dropped");
   
   //find the location and advertise a "yard sale" if enough flags were dropped
   if (%numFlagsDropped >= $FlagHunter::YardSaleNumber)
   {
      MessageAll(1, "YARD SALE!!!~wfemale5.wtaunt4.wav");
      %beacon = newObject("", Item, Beacon, 1, false, false, true);
 	 	addToSet("MissionCleanup", %beacon);
      GameBase::setTeam(%beacon, Client::getTeam(%client));
      GameBase::throw(%beacon, %player, 10, false);
      schedule("StartYardSaleBeacon(" @ %beacon @ ");", 0.5, %beacon);
   }
   
   if (%numFlagsDropped - 1 > $FlagHunter::MostFlagsDropped)
   {
      $FlagHunter::MostFlagsDropped = %numFlagsDropped - 1;
      $FlagHunter::MostFlagsDroppedName = Client::getName(%client);
   }
}

function StartYardSaleBeacon(%beacon)
{
	if (! GameBase::isAtRest(%beacon))
      schedule("StartYardSaleBeacon(" @ %beacon @ ");", 30.0, %beacon);
   else
   {
      //sink the beacon 1 meter below the surface...
      %pos = GameBase::getPosition(%beacon); 
      %posX = getWord(%pos, 0);
      %posY = getWord(%pos, 1);
      %posZ = getWord(%pos, 2) - 1.0;
      %newPos = %posX @ " " @ %posY @ " " @ %posZ;
         
      //delete the thrown beacon object
      deleteObject(%beacon);
      
      //create a deployed targetting one
      %targBeacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
      addToSet("MissionCleanup", %targBeacon);
   	GameBase::setTeam(%targBeacon, Client::getTeam(%client));
   	GameBase::setPosition(%targBeacon, %newPos);
   	Gamebase::setMapName(%targBeacon,"Yard Sale!");
      Beacon::onEnabled(%targBeacon);
      
      //schedule the beacon to fade in 30 seconds
      schedule("fadeOutObject(" @ %targBeacon @ ");", $FlagHunter::YardSaleTime, %targBeacon);
   }
}

function Flag::onCollision(%this, %object)
{
   if (getObjectType(%object) != "Player")
      return;

   if (%this.carrier != -1)
      return; // spurious collision
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %client = Player::getClient(%object);
   %clientName = Client::getName(%client);
   
   //delete the object and add 1 to the players flagCount
   %client.flagCount += %this.value;
   
   //set the state, and turn it invisble - the scheduled callback for this flag will delete it
   deleteObject(%this);
   
   %numFlags = %client.flagCount - 1;
   
   //only send messages to everyone if the number is odd - to cut down on spam...
   %currentTime = getSimTime();
   if ((%currentTime - %client.lastMessageTime < 1.0) && ( floor(%numFlags / 2.0) == (%numFlags / 2.0)))
   {
      %sendMsg = false;
   }
   else
   {
      %sendMsg = true;
      %client.lastMessageTime = %currentTime;
   }
   
   
   //send the message to the player
   if (%numFlags == 1)
      Client::sendMessage(%client, 0, "You now have 1 flag.~wflag1.wav");
   else
      Client::sendMessage(%client, 0, "You now have " @ %numFlags @ " flags.~wflag1.wav");
         
   if ($FlagHunter::TeamModeOn)
   {
      if (%sendMsg)
      {
         %numClients = getNumClients();
         for (%i = 0; %i < %numClients; %i++)
         { 
            %msgClient = getClientByIndex(%i);  
            if (%msgClient != %client)
            {
               //send msg to teammates
               if (Client::getTeam(%msgClient) == Client::getTeam(%client))
               {
                  if (%numFlags == 1)
                     Client::sendMessage(%msgClient, 0, "Teammate " @ %clientName @ " now has 1 flag.~wflag1.wav");
                  else
                     Client::sendMessage(%msgClient, 0, "Teammate " @ %clientName @ " now has " @ %numFlags @ " flags.~wflag1.wav");
               }
               
               //send msg to enemies
               else
               {
                  Client::sendMessage(%msgClient, 0, "Enemy " @ %clientName @ " now has " @ %numFlags + 1 @ " flags.~wflag1.wav");
               }
            }
         }
      }
   }
   else if (%sendMsg)
   {
      if (%numFlags == 1)
         MessageAllExcept(%client, 0, %clientName @ " now has 1 flag.~wflag1.wav");
      else
         MessageAllExcept(%client, 0, %clientName @ " now has " @ %numFlags @ " flags!~wflag1.wav");
   }
   
   //see if a record is about to be broken
   if (! $FlagHunter::TeamModeOn && (getNumClients() >= 4))
   {
      if ((%numFlags > $FlagHunter::MostFlagsEverCount[$missionName]) && (%currentTime - %client.recordMessageTime > 2.0))
      {
         %client.recordMessageTime = %currentTime;
         Client::sendMessage(%client, 1, "You have enough flags to set a new record!~wmine_act.wav");
         if (%sendMsg)
            MessageAllExcept(%client, 1, %clientName @ " has enough flags to set a new record!~wmine_act.wav");
      }
   }
       
   //make sure he's still carrying a flag
   if (%client.flagCount >= $FlagHunter::CarryingNumber && Player::getItemCount(%client, Flag) < 1)
   {
      Player::setItemCount(%client, Flag, 1);
      Player::mountItem(%client, Flag, $FlagSlot, 1);
   }
   Game::refreshClientScore(%client);
   
   //update anyone who is tracking this player
   FlagHunter::updateTrackers(%client, %client.flagCount - 1, "has");
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
//Player has a total of 10 seconds per life allowed outside designated mission area.
//After a player expends this 10 sec, the player is remotely killed.
function Player::leaveMissionArea(%player){
   %cl = Player::getClient(%player);
   Client::sendMessage(%cl,1,"You have left the mission area.");
   %player.outArea=1;
   alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}


function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}

  
function alertPlayer(%player, %count){
   if(%player.outArea == 1){
      %clientId = Player::getClient(%player);
      Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");

      if(%count > 1)
         schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
      else 
         schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
   }
}

function leaveMissionAreaDamage(%client){
   %player = Client::getOwnedObject(%client);

   if(%player.outArea == 1){
      if(!Player::isDead(%player)){
         Player::setDamageFlash(%client,0.1);
         GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
	  schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
      }
      else { 
         playNextAnim(%client);	
         Client::onKilled(%client, %client);
      }
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
// client cannot camp near the flag
function GroupTrigger::onEnter(%this, %object)
{
	if (getObjectType(%object) != "Player")
		return;
      
	%client = Player::getClient(%object);
   
   if (%this.nexus)
   {
      %totalFlags = %client.flagCount - 1;
      if (%totalFlags <= 0)
         return;
      
      //if "greed mode" is on, can't cap less than greed amount...
      if ($FlagHunter::GreedMode && (%totalFlags < $FlagHunter::GreedAmount))
      {
         Client::sendMessage(%client, 1, "Greed mode is ON!  You must have " @ $FlagHunter::GreedAmount @ " flags before you can return them.~wmine_act.wav");
         return;
      }
         
      //if "greed mode" is on, can't cap less than greed amount...
      %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
      if ($FlagHunter::HoardMode && (%curTimeLeft <= ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft > ($FlagHunter::HoardEndTime * 60)))
      {
         %hoardTimeLeft = %curTimeLeft - ($FlagHunter::HoardEndTime * 60);
         %hoardMinutesLeft = floor(%hoardTimeLeft / 60);
         %hoardSecondsLeft = floor(%hoardTimeLeft - (%hoardMinutesLeft * 60));
         if (%hoardMinutesLeft == 0)
         {
            if (%hoardSecondsLeft == 1)
               %timeString = "1 second";
            else
               %timeString = %hoardSecondsLeft @ " seconds";
         }
         else
         {
            if (%hoardMinutesLeft == 1)
               %timeString = "1 minute";
            else
               %timeString = %hoardMinutesLeft @ " minutes";
            if (%hoardSecondsLeft > 0)
            {
               if (%hoardSecondsLeft == 1)
                  %timeString = %timeString @ " and 1 second";
               else
                  %timeString = %timeString @ " and " @ %hoardSecondsLeft @ " seconds";
            }
         }
         
         Client::sendMessage(%client, 1, "Hoard mode is in effect!  You must wait " @ %timeString @ " before you can return your flags.~wmine_act.wav");
         return;
      }
      
      //return the flags he's captured, and score them (note, he's always carrying his own - don't score it)
      %clientName = Client::getName(%client);
      %totalScore = 0;
      for (%i = 1; %i < %client.flagCount; %i++)
      {
         %totalScore += %i;
      }
      
      //in team hunters, the score goes to the team
      if ($FlagHunter::TeamModeOn)
         $teamScore[Client::getTeam(%client)] += %totalScore;
      else
         %client.score += %totalScore;
      
      %client.flagCount = 1;
      //take the flag off the players back
      Player::setItemCount(%client, Flag, 0);
      
      if (! $FlagHunter::TeamModeOn)
      {
         if (%totalFlags > $FlagHunter::MostFlagsReturnCount)
         {
            $FlagHunter::MostFlagsReturnCount = %totalFlags;
            $FlagHunter::MostFlagsReturned = %clientName;
         }
      
         %newRecord = false;
         if ((%totalFlags > $FlagHunter::MostFlagsEverCount[$missionName]) && (getNumClients() >= 4))
         {
            $FlagHunter::MostFlagsEverCount[$missionName] = %totalFlags;
            $FlagHunter::MostFlagsEver[$missionName] = %clientName;
            %newRecord = true;
         
            //save it to a file
            export("$FlagHunter::MostFlagsEver*", "config\\HunterRecords.cs", False);
         }
      }
      
      Game::refreshClientScore(%client);
         
      //send the message
      if (%totalFlags >= 5 && (! %newRecord))
      {
         %color = 1;
         %sound = "!~wflagreturn.wav";
      }
      else
      {
         %color = 0;
         %sound = "!";
      }
      
      //send the message to the client
      Client::sendMessage(%client, %color, "You returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
      
      if ($FlagHunter::TeamModeOn)
      {
         for (%i = 0; %i < getNumClients(); %i++)
         {
            %msgClient = getClientByIndex(%i);  
            if (%msgClient != %client)
            {
               //send msg to teammates
               if (Client::getTeam(%msgClient) == Client::getTeam(%client))
               {
                  if (%totalFlags == 1)
                     Client::sendMessage(%msgClient, %color, "Teammate " @ %clientName @ " has returned 1 flag for a score of 1" @ %sound);
                  else
                     Client::sendMessage(%msgClient, %color, "Teammate " @ %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
               }
               
               //send msg to enemies
               else
               {
                  if (%totalFlags == 1)
                     Client::sendMessage(%msgClient, %color, "Enemy " @ %clientName @ " has returned 1 flag for a score of 1" @ %sound);
                  else
                     Client::sendMessage(%msgClient, %color, "Enemy " @ %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
               }
            }
         }
      }
      else
      {
         MessageAllExcept(%client, %color, %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
         
         if (%newRecord)
            MessageAll(1, "New record of " @ $FlagHunter::MostFlagsEverCount[$missionName] @ " set by " @ $FlagHunter::MostFlagsEver[$missionName] @ "!~wflagcapture.wav");
      }
      
      //update anyone who is tracking this player
      FlagHunter::updateTrackers(%client, %totalFlags, "capped");
   }
   else
   {   
      //set the flag
      %client.inNexusAreaTime = floor(getSimTime() * 100);
      
      //schedule the call to see if he's still there
      schedule("NexusCampingDamage(" @ %object @ ", " @ %client.inNexusAreaTime @ ", true);", $FlagHunter::NexusCampingTimer);
   }
}	

// client cannot camp near the flag
function GroupTrigger::onLeave(%this, %object)
{
	if (getObjectType(%object) != "Player")
		return;
      
   if (%this.nexus)
      return;
      
	%client = Player::getClient(%object);
   
   //reset
   %client.inNexusAreaTime = -1;
}

function NexusCampingDamage(%player, %timeStamp, %giveWarning)
{
	if (getObjectType(%player) != "Player")
		return;
      
	%client = Player::getClient(%player);
   if (%client <= 0 || Player::isDead(%client))
      return;
      
   //make sure this schedule callback matches the original
   if (%client.inNexusAreaTime != %timeStamp)
      return;
   
   //give damage if the person is still camping, and has been there for 8 seconds or more
   if (%giveWarning)
   {
      Client::sendMessage(%client, 1, "No camping near the Nexus! ~wLeftMissionArea.wav");
      schedule("NexusCampingDamage(" @ %player @ ", " @ %timeStamp @ ", false);", $FlagHunter::NexusCampingTimer / 2);
   }
   else
   {   
      Player::setDamageFlash(%client, 0.1);
      GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) + 0.05);
      schedule("NexusCampingDamage(" @ %player @ ", " @ %timeStamp @ ", false);", 1);
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
function remoteHuntersFindTarget(%sender)
{
   %numClients = getNumClients();
   %maxFlags = 0;
   %maxFlagCarrier = -1;
   for (%i = 0; %i < %numclients; %i++)
   { 
      %client = getClientByIndex(%i);  
      if (%client != %sender && %client.flagCount - 1 > %maxFlags)
      {
         %maxFlags = %client.flagCount - 1;
         %maxFlagCarrier = %client;
      }
   }
   
   if (%maxFlags > 0)
   {
      %sender.target = %maxFlagCarrier;
      FlagHunter::updateTrackers(%maxFlagCarrier, %maxFlags, "has");
   }
   else
   {
      if (%sender.target >= 0)
         setCommandStatus(%sender, 0, "Auto-tracking cancelled");
      %sender.target = -1;
      Client::sendMessage(%sender, 0, "No one has any flags.");
   }
}

function remoteHuntersCancelTarget(%sender)
{
   setCommandStatus(%sender, 0, "Auto-tracking cancelled");
   %sender.target = -1;
}

function remoteHuntersSetTarget(%client, %target)
{
   if (%client == %target)
   {
      if (%client.target >= 0)
         setCommandStatus(%client, 0, "Auto-tracking cancelled");
      %client.target = -1;
   }
   else
   {
      %client.target = %target;
      FlagHunter::updateTrackers(%target, %target.flagCount - 1, "has");
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
function FlagHunter::restoreServerDefaults()
{
   FlagHunter::validateItems();
   
   //restore some server variables
   $Server::JoinMOTD = $FlagHunter::origJoinMOTD;
   for (%i = 0; %i < 8; %i++)
   {
      $Server::teamName[%i] = $FlagHunter::origTeamName[%i];
      $Server::teamSkin[%i] = $FlagHunter::origTeamSkin[%i];
   }

   //reset the admin functions
   exec("admin.cs");
   
   //reset the player functions
   exec("player.cs");
   
   //reset the objectives functions
   exec("objectives.cs");
}

function FlagHunter::unusedOnExit() // PORT: was "function onExit()" -- it replaced the 1.50 client's quit handler on a listen host
{
   if ($Game::missionType == "Hunter")
      FlagHunter::restoreServerDefaults();
         
   if(isObject(playGui))
      storeObject(playGui, "config\\play.gui");

   saveActionMap("config\\config.cs", "actionMap.sae", "playMap.sae", "pdaMap.sae");

	//update the video mode - since it can be changed with alt-enter
	$pref::VideoFullScreen = isFullScreenMode(MainWindow);

   checkMasterTranslation();
	echo("exporting pref::* to prefs.cs");
   export("pref::*", "config\\ClientPrefs.cs", False);
   export("Server::*", "config\\ServerPrefs.cs", False);
   export("pref::lastMission", "config\\ServerPrefs.cs", True);
   BanList::export("config\\banlist.cs");
}


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

echo("******* loaded successfully ********");
