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
   
   $FlagHunter::origJoinMOTD = $Server::JoinMOTD;
   $Server::JoinMOTD = "<Jc><f1>HUNTERS v1.2  <f1>by <f0>Kidney Thief<f1> & edited by <f0>[HvC]NaTeDoGG\n" @
   "<Jc><f1>Press '<f2>O<f1>' for game objectives & rules.\n\n"
   @ $Server::JoinMOTD;
   
   //  GAME PREFERENCES 
   $Server::TeamDamageScale = 1; //team damage must stay on

   //Game globals
   $FlagHunter::MostFlagsReturned = "";
   $FlagHunter::MostFlagsReturnCount = 0;
   $FlagHunter::MostFlagsDropped = 0;
   $FlagHunter::MostFlagsDroppedName = "";

}

//call it initially
FlagHunter::setGlobalDefaults();

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

//overwritten to add the one line to drop flags before the %player object gets deleted
function Player::onKilled(%this)
{

	%name = Client::getName(Player::getClient(%this));
	if($Hologram[%name] != "") return;


   	//first toss all the flags
    Flag::onDrop(%this, unused);
   
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	doneposs(%cl);
	
	if($ThunderStruck::AutoRespawn > 0) 
		schedule("Game::autoRespawn(" @ %cl @ ");",$ThunderStruck::AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
				Player::dropItem(%this,%type);
		}
	}

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
      doneposs(%cl);
	  Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Game::clientKilled(%playerId, %killerId)
{
   Game::refreshClientScore(%playerId);
   DM::checkMissionObjectives(%killerId);   
}

// modified to spawn/respawn player on team0, with custom skin.
function Game::playerSpawned(%pl, %clientId, %armor)
{	
   // use this client's skin preference
   Client::setSkin(%clientId, $Client::info[%clientId, 0]);
   
   //outfit the player with default equipment
   %clientId.spawn = 1;

	if(%clientId.permap == true) {
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "ppmarmor";
		else
			%armor = "ppmfemale";
		Player::setArmor(%clientId,%armor);
		return;
	}


	Player::setArmor(%clientId,$ArmorType[Client::getGender(%clientId), CArmor]);
	Player::setItemCount(%clientId,Blaster,1); Player::setItemCount(%clientId,Beacon,1); 	
	Player::setItemCount(%clientId,BulletAmmo,100); Player::setItemCount(%clientId,Chaingun,1); 	
	Player::setItemCount(%clientId,DiscAmmo,10); Player::setItemCount(%clientId,DiscLauncher,1); 
	Player::setItemCount(%clientId,Grenade,4); Player::setItemCount(%clientId,RepairKit,1); 
	if($FlagHunter::Inventories) {
		Player::setItemCount(%clientId,DeployableInvPack,1); 
		Player::mountItem(%pl,DeployableInvPack,$BackpackSlot); 
	}
	Player::useItem(%pl,Chaingun); 

	doneposs(%clientId);
	if(%clientId.dan == true) {			
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, Client::getOwnedObject(%clientId), 3, 3, 3);
	}
   %clientId.safet = false;
   //start the players with flag attached
   //Player::setItemCount(%clientId, Flag, 1);
   //Player::mountItem(%clientId, Flag, $FlagSlot, 1);
   %clientId.flagCount = 1;
   %clientId.inAltarArea = false;
   Game::refreshClientScore(%clientId);
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
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
      DM::missionObjectives();
      
      
      if ($FlagHunter::HoardMode)
      {
         if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
         {
            %hoardSecondsLeft = floor(%curTimeLeft - ($FlagHunter::HoardEndTime * 60));
            %hoardMinutesLeft = floor(%hoardSecondsLeft / 60);
            if (((%hoardSecondsLeft / 60) == %hoardMinutesLeft) && (%hoardMinutesLeft > 1))
               MessageAll(1, %hoardMinutesLeft @ " minutes left until the HOARD period is over.");
            else if (%hoardSecondsLeft == 60)
               MessageAll(1, "1 minute left until the HOARD period is over.");
            else if (%hoardSecondsLeft == 30)
               MessageAll(1, "30 seconds left until the HOARD period is over.");
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
                  MessageAll(1, "The HOARD period begins in 1 minute.");
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
        
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Additional info:" );
         Team::setObjective(%l, %lineNum++, "<f1>   - The Nexus is marked on your commander screen.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Flags fade out after " @ $FlagHunter::FlagFadeTime @ " seconds.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Only players carrying 5 or more flags have a flag on their back.");
         Team::setObjective(%l, %lineNum++, "<f1>   - The TAB menu lists how many flags each player is carrying.");
         Team::setObjective(%l, %lineNum++, "<f1>   - You can find and track the person currently carrying the most flags:");
         Team::setObjective(%l, %lineNum++, "<f1>     bind a key in the ActionMap to: \"remoteEval(2048, HuntersFindTarget);\"");
      }
      else
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
	 Team::setObjective(%i, %lineNum++, "<L14>\t\tScore\t\tKills\t\tDeaths\t\tRatio");
         %i=0;
         while(%i < %numClients){
            %plyr = %clientList[%i];
  	    Team::setObjective(%i, %lineNum++, "<L14><f1>"@(%i + 1) @ ". <f2>" @ Client::getName(%plyr));
	    Team::setObjective(%i, %lineNum++, "<L14>\t\t" @ %plyr.score @ "\t\t\t\t" @ %plyr.ScoreKills @ "\t\t\t" @ %plyr.ScoreDeaths @ "\t\t\t\t" @ %plyr.ratio);
            echo(Client::getName(%plyr) @ "  " @ %plyr.score);
            %i++;
         }
         
         //this is really hacky, but it's seems to be the only guaranteed place to restore the server defaults
         FlagHunter::restoreServerDefaults();
      }
   
     
      for(%s = %lineNum+1; %s < 30 ;%s++)
         Team::setObjective(%l, %s, " ");
   }
   $timeReached = false;
}

function Game::refreshClientScore(%clientId)
{	
   DM::missionObjectives();
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //

 //set the client score line in the TAB menu
function Game::refreshClientScore(%clientId)
{
   Client::setScore(%clientId, "%n\t  " @ %clientId.score  @ "\t  " @ %clientId.flagCount - 1 @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
}

function Mission::init()
{
   //set the TAB menu format
   setClientScoreHeading("Player Name\t\x65Score\t\x90Carrying\t\xCFPing\t\xEFPL");

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

function fadeOutObject(%object)
{
   GameBase::startFadeOut(%object);
   schedule("deleteObject(" @ %object @ ");", 2.5, %object);
}

//executed every time a player dies, drops, becomes observer, whatever...
function Flag::onDrop(%player, %type)
{
   %client = Player::getClient(%player);
   %numFlagsDropped = %client.flagCount;
   
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
      
      GameBase::setTeam(%flag, 0);
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
   %client.flagCount = 0;
   Game::refreshClientScore(%client);
   
   //update anyone who is tracking this player
   %name = Client::getName(%client);
   %numClients = getNumClients();
   for (%i = 0; %i < %numclients; %i++)
   { 
      %tracker = getClientByIndex(%i);  
      if (%tracker != %client && %tracker.target == %client)
      {
         IssueTargCommand(%tracker, %tracker, 0, %name @ " dropped " @ %numFlagsDropped @ " flags!", %client - 2048);
      }
   }
   
   //find the location and advertise a "yard sale" if enough flags were dropped
   if (%numFlagsDropped >= $FlagHunter::YardSaleNumber)
   {
      MessageAll(1, "YARD SALE!!!~wfemale5.wtaunt4.wav");
      %beacon = newObject("", Item, Beacon, 1, false, false, true);
 	 	addToSet("MissionCleanup", %beacon);
      GameBase::setTeam(%beacon, 0);
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
      schedule("StartYardSaleBeacon(" @ %beacon @ ");", 0.5, %beacon);
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
   	GameBase::setTeam(%targBeacon, 0);
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
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
   
   //delete the object and add 1 to the players flagCount
   %playerClient.flagCount += %this.value;
   
   //set the state, and turn it invisble - the scheduled callback for this flag will delete it
   deleteObject(%this);
   
   %numFlags = %playerClient.flagCount - 1;
   
   //only send messages to everyone if the number is odd - to cut down on spam...
   %currentTime = getSimTime();
   if ((%currentTime - %playerClient.lastMessageTime < 1.0) && ( floor(%numFlags / 2.0) == (%numFlags / 2.0)))
   {
      %sendMsg = false;
   }
   else
   {
		if(%numFlags > 4) {
	      %sendMsg = true;
	      %playerClient.lastMessageTime = %currentTime;
		} else
		      %sendMsg = false;
   }
   
   if (%numFlags == 1)
   {
      Client::sendMessage(%playerClient, 0, "You now have " @ %numFlags @ " flag.~wflag1.wav");
      if (%sendMsg)
         MessageAllExcept(%playerClient, 0, %touchClientName @ " now has " @ %numFlags @ " flag.~wflag1.wav");
   }
   else if (%numFlags >= 2)
   {
      Client::sendMessage(%playerClient, 0, "You now have " @ %numFlags @ " flags!~wflag1.wav");
      if (%sendMsg)
         MessageAllExcept(%playerClient, 0, %touchClientName @ " now has " @ %numFlags @ " flags!  Kill him!~wflag1.wav");
   }

   //make sure he's still carrying a flag
   if (%playerClient.flagCount >= $FlagHunter::CarryingNumber && Player::getItemCount(%playerClient, Flag) < 1)
   {
      Player::setItemCount(%playerClient, Flag, 1);
      Player::mountItem(%playerClient, Flag, $FlagSlot, 1);
   }
   Game::refreshClientScore(%playerClient);
   
   //update anyone who is tracking this player
   %name = Client::getName(%playerClient);
   %numClients = getNumClients();
   for (%i = 0; %i < %numclients; %i++)
   { 
      %client = getClientByIndex(%i);  
      if (%client != %playerClient && %client.target == %playerClient)
      {
         IssueTargCommand(%client, %client, 0, "Kill " @ %name @ " and grab " @ %playerClient.flagCount @ " flags!", %playerClient - 2048);
      }
   }
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
//brought the flags to the Nexus

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
	Client::sendMessage(Player::getClient(%player),0,"You have entered the mission area."); 
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
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) { 
			Player::setDamageFlash(%client,0.6); 
			if((GameBase::getDamageLevel(%player) + 0.05) >= (Player::getArmor(%player)).maxdamage) {
				Client::sendMessage(%client,1,"You have been killed for leaving the mission area.~wLeftMissionArea.wav");
				MessageAllExcept(%client, 1, Client::getName(%client) @ " has been killed for leaving the mission area.");
				playNextAnim(%client); 
				Player::kill(%client); 
				Client::onKilled(%client, %client);
			} else {
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05); 
				schedule("leaveMissionAreaDamage(" @ %client @ ");",1); 
			}
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
      %touchClientName = Client::getName(%client);
      %totalScore = 0;
      for (%i = 1; %i < %client.flagCount; %i++)
      {
         %totalScore += %i;
      }
      %client.score += %totalScore;
      %client.flagCount = 1;
      //take the flag off the players back
      Player::setItemCount(%client, Flag, 0);
      
      if (%totalFlags > $FlagHunter::MostFlagsReturnCount)
      {
         $FlagHunter::MostFlagsReturnCount = %totalFlags;
         $FlagHunter::MostFlagsReturned = %touchClientName;
      }
      
      %newRecord = false;
      if ((%totalFlags > $FlagHunter::MostFlagsEverCount[$missionName]) && (getNumClients() >= 4))
      {
         $FlagHunter::MostFlagsEverCount[$missionName] = %totalFlags;
         $FlagHunter::MostFlagsEver[$missionName] = %touchClientName;
         %newRecord = true;
         
         //save it to a file
         export("$FlagHunter::MostFlagsEver*", "config\\HunterRecords.cs", False);
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
      MessageAllExcept(%client, %color, %touchClientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
      Client::sendMessage(%client, %color, "You returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
      
      if (%newRecord)
      {
         MessageAll(1, "New record of " @ $FlagHunter::MostFlagsEverCount[$missionName] @ " set by " @ $FlagHunter::MostFlagsEver[$missionName] @ "!~wflagcapture.wav");
      }
      
      //update anyone who is tracking this player
      %name = Client::getName(%client);
      %numClients = getNumClients();
      for (%i = 0; %i < %numclients; %i++)
      { 
         %tracker = getClientByIndex(%i);  
         if (%tracker != %client && %tracker.target == %client)
         {
            IssueTargCommand(%tracker, %tracker, 0, "Too late! " @ %name @ " capped!", %client - 2048);
         }
      }
   }
   else
   {   
      //set the flag
      %client.inAltarArea = true;
      %client.inAltarAreaTime = getSimTime();
      
      //schedule the call to see if he's still there
      schedule("altarCampingDamage(" @ %object @ ", true);", $FlagHunter::AltarCampingTimer);
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
   %client.inAltarArea = false;
}

function altarCampingDamage(%player, %giveWarning)
{
	if (getObjectType(%player) != "Player")
		return;
      
	%client = Player::getClient(%player);
   if (%client <= 0)
      return;
   
   //give damage if the person is still camping, and has been there for 8 seconds or more
   if ((! Player::isDead(%client)) && %client.inAltarArea && ((getSimTime() - %client.inAltarTime) >= $FlagHunter::AltarCampingTimer))
   {
      if (%giveWarning)
      {
         Client::sendMessage(%client, 1, "No camping near the Nexus! ~wLeftMissionArea.wav");
         schedule("altarCampingDamage(" @ %player @ ", false);", $FlagHunter::AltarCampingTimer / 2);
      }
      else
      {   
         Player::setDamageFlash(%client,0.1);
         GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) + 0.05);
         schedule("altarCampingDamage(" @ %player @ ", false);", 1);
      }
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
      if (%client != %sender && %client.flagCount > %maxFlags)
      {
         %maxFlags = %client.flagCount;
         %maxFlagCarrier = %client;
      }
   }
   
   if (%maxFlags > 0)
   {
      %name = Client::getName(%maxFlagCarrier);
      %sender.target = %maxFlagCarrier;
      if (%maxFlags > 1)
         %temp = " flags!";
      else
         %temp = " flag";
      IssueTargCommand(%sender, %sender, 0, "Kill " @ %name @ " and grab " @ %maxFlags @ %temp, %maxFlagCarrier - 2048);
   }
   else
   {
      Client::sendMessage(%sender, 0, "No one has any flags.");
   }
}

function Server::nextMission(%replay)
{
if(%replay || $Server::TourneyMode){
	%nextMission = $missionName;
} else {
	if(getNumClients() < 2 || $ThunderStruck::RandomMissionTypes["Flag Hunter"]) {
		doNextRand();
		return;
	}
	echo("Selecting a mission...");
	%l = 0; %goodmtype = 0;
	while(%goodmtype != "Flag Hunter" && %l < 5000) {
		%rnd = floor(getRandom() * $TotalMissions);
		if ($MissionName != $TotalMissionList[%rnd]) {
			%nextMission = $TotalMissionList[%rnd];
			$pref::LastMission = $TotalMissionList[%rnd];
		}			  
		%goodmtype = $ThunderStruck::MType[%nextMission];
		%l = %l + 1;
	}
	if(%l < 5000) {
		echo("A random Flag Hunter mission has been selected.");
		messageall(0, "A random Flag Hunter mission is being selected...");
		messageall(0, "Changing to mission "@%nextMission@" ("@$ThunderStruck::MType[%nextMission]@").");
	} else {
		echo("No other Flag Hunter missions found!");
		echo("Using default next mission.");
		%nextMission = $nextMission[$missionName];
	}
}

   echo("Changing to mission ", %nextMission, ".");
   
   Server::loadMission(%nextMission);
}

function Server::loadMission(%missionName, %immed)
{

	if($ThunderStruck::FairSpawn > 10 || $ThunderStruck::FairSpawn < 0) {
		$ThunderStruck::FairSpawn = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::FairSpawn is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::BaseKillLimit < 2 && $ThunderStruck::BaseKillLimit != 0) {
		$ThunderStruck::BaseKillLimit = 0; 
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::BaseKillLimit is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::tkLimit <= 0) {
		$ThunderStruck::tkLimit = 5;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::tkLimit is invalid, option has been set to 5");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningFrequency != 0 && $ThunderStruck::LightningFrequency < 90) {
		$ThunderStruck::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningStrength != "normal" && $ThunderStruck::LightningStrength != "random" && $ThunderStruck::LightningStrength != "weak" && $ThunderStruck::LightningStrength != "zero") {
		$ThunderStruck::LightningStrength = "normal";
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningStrength is invalid, option has been set to normal");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

	if($ThunderStruck::LightningStrength == "normal" && $ThunderStruck::LightningFrequency < 200) {
		$ThunderStruck::LightningStrength = "weak";
		$ThunderStruck::LightningFrequency = 500;
		echo("**************");
		echo("YOU MESSED UP!  Lightning Strength cannot be set to normal if Lightning Frequency is less than 200.");
		echo("$ThunderStruck::LightningStrength is invalid, option has been set to weak");
		echo("$ThunderStruck::LightningFrequency is invalid, option has been set to 500");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");

	}

	if($ThunderStruck::LightningHandicap < 3 && $ThunderStruck::LightningHandicap != 0) {
		$ThunderStruck::LightningHandicap = 0;
		echo("**************");
		echo("YOU MESSED UP!  $ThunderStruck::LightningHandicap is invalid, option has been disabled");
		echo("Please verify ThunderStruck.cs is using the correct settings.");
		echo("**************");
	}

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

	if($ThunderStruck::startTime)
		$Server::timeLimit = $ThunderStruck::startTime;
	else
		$ThunderStruck::startTime = $Server::timeLimit;

	if($ThunderStruck::MType[%missionName] == "Deathmatch" || $ThunderStruck::MType[%missionName] == "Team Deathmatch" || $ThunderStruck::MType[%missionName] == "Flag Hunter" || $ThunderStruck::MType[%missionName] == "Kill the Rabbit") { 
		%newfav = $MasterKey @ "DM";
		dmm();
	} else {
		%newfav = $MasterKey;
		normalm();
	}
	
	if ($ItemFavoritesKey != %newfav) {
		if($ItemFavoritesKey != $MasterKey @ "Arena") {
			if(%newfav == $MasterKey @ "DM") {
				echo("Switching favorites to ThunderStruck Deathmatch settings.");
				messageall(0, "Switching favorites to ThunderStruck Deathmatch settings.");
			} else {
				echo("Switching favorites to normal ThunderStruck settings.");
				messageall(0, "Switching favorites to normal ThunderStruck settings.");		
			}
		}
		$ItemFavoritesKey = %newfav;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
		   remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	   }
	}

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

	FlagHunter::restoreServerDefaults();

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

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- //
function FlagHunter::restoreServerDefaults()
{
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

   //reset the objectives functions
   exec("server.cs");

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

echo("******* FlagHunter.cs loaded successfully ********");
