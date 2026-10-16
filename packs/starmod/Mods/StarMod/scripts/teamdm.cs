//_______________________________________________________________________________________
//
//  Team Deathmatch v1.6
//  Developed by Steven Melton aka [PEN]Arson - November 1999
//
//  Original by Dynamix, re-written by [PEN]Arson
//
//  *-* Game Objectives *-*
//
//    - Frag the hell out of the enemy! :) Each frag is 1 point.
//    
//    - Team kills, suicides, and LMA deaths deduct from team scores.
//
//    - Turret kills do NOT count for points.
//
//    - A degree of strategy has been added. Spawning with only a 
//      disclauncher, 15 discs, and a repair kit, one could
//      appreciate the inventory stations throughout the maps.
//
//    - Leaving the mission area (LMA): Players have 10 seconds to 
//      return to the mission area before they are remotely killed.
//
//_______________________________________________________________________________________

exec("game.cs");

$DMTEAM::FragLimit = 30;  //frags need to win the mission
$DMTEAM::equipDamage = True;  //equipment damage is on my default

//============================ spawn data

   $DMTEAM::spawnWeapon = "Disclauncher";
   $DMTEAM::spawnList[0] = "LightArmor";
   $DMTEAM::spawnList[1] = "Disclauncher";
   $DMTEAM::spawnList[2] = "RepairKit";
   $DMTEAM::spawnList[3] = "";

//============================ !!! DO NOT MODIFY BELOW THIS LINE !!!

//calculate scores upon fraging
function Game::clientKilled(%playerId, %killerId)
{
      
      if(%killerId == -1 || %playerId == -1)
      {
        return;
      }
      %kteam = Client::getTeam(%killerId);
      %pteam = Client::getTeam(%playerId);

      if(%kteam == %pteam)  //If frag was TK, Suicide, or LMA death, deduct from team score
         if($teamScore[%kteam] == 0)  //If team score is 0 then leave it
           $teamScore[%kteam] = 0;    //at 0 to prevent negative scores
         else
           $teamScore[%kteam] = $teamScore[%kteam] - 1;  //If its not 0, deduct from team score
      else
         $teamScore[%kteam] = $teamScore[%kteam] + 1;  //Otherwise, add point to teams score

      ObjectiveMission::refreshTeamScores();
      DMTEAM::echoScores();
      DMTEAM::checkMissionObjectives();

}

function Game::playerSpawned(%pl, %clientId, %armor)
{	  

   //spawn with Disclauncher and RepairKit

   %clientId.spawn = 1;
   for(%i = 0; (%item = $DMTEAM::spawnList[%i]) != ""; %i++)
      buyItem(%clientId,%item);
   %clientId.spawn= "";
   Player::useItem(%pl, $DMTEAM::spawnWeapon);

   DMTEAM::checkMissionObjectives();

}

//============================ Player has a total of 10 seconds of life allowed outside designated mission area.
//============================ After a player expends this 10 sec, the player is remotely killed.

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%player.outArea=1;
	alertPlayer(%player, 3);
}

//============================ checking for timeout of dieSeqCount

function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

//============================ called if player leaves mission area
function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}
  
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) {
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

function Game::checkTimeLimit()
{
   //============================  if no timeLimit set or timeLimit set to 0,
   //============================  just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0)
   {
      $timeLimitReached = true;
      $timeReached = 1;
		DMTEAM::checkMissionObjectives();
		Server::nextMission();
	}
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Vote::changeMission()
{
   $timeLimitReached = true;
   $timeReached = 1;
   DMTEAM::checkMissionObjectives();
}


//============================ Team Deathmatch Function Definitions

function DMTEAM::echoScores()
{   
     %score = getTeamName(0) @ ": " @ $teamScore[0];

     for(%i = 1; %i < $numTeams; %i = %i + 1)
        %score = %score @ ", " @ getTeamName(%i) @ ": " @ $teamScore[%i];
     
     %score = %score @ ", Frag Limit: " @ $DMTEAM::FragLimit;

     MessageAll(1, %score);

}

function DMTEAM::checkMissionObjectives()
{
   for(%p = 0; %p < $numTeams; %p = %p + 1) 
   {
	  if(DMTEAM::teamMissionObjectives(%p))
	     schedule("Server::nextMission();", 0);
   }
}

function DMTEAM::teamMissionObjectives(%teamId)
{

   %teamName = getTeamName(%teamId);
   %teamScore = $teamScore[%teamId];
   %highScore = 0;
   %tieGame = False;
  
   for(%t = 0; %t < $numTeams; %t = %t + 1)
   {
     %testTeamName = getTeamName(%t);
     if(%teamName != %testTeamName)
     {
       if(%teamScore > $teamScore[%t])
         %highScore = %teamScore;
       else if($teamScore[%t] > %teamScore)
         %highScore = $teamScore[%t];
       else if(%teamScore == $teamScore[%t])
       {
         %highScore = %teamScore;
         %tieGame = True;
       }
     }
   }

   if((%highScore >= $DMTEAM::FragLimit) || ($timeLimitReached == true))
   {
       for(%r = 0; %r < $numTeams; %r = %r + 1)
       {
          if((%tieGame == True) && (%teamScore == %highScore))
             Team::setObjective(%teamId, 2, "<f5>Your team tied with " @ %teamScore @ " frags!");
          else if(%teamScore == %highScore) 
             Team::setObjective(%teamId, 2, "<f5>Your team won with " @ %teamScore @ " frags!");
          else
             Team::setObjective(%teamId, 2, "<f5>Your team lost!"); 
       }

       Team::setObjective(%teamId, 3, "\n");
       //============================ print out all team scores
	   %lnum = 4;
	   for(%q = 0; %q < $numTeams; %q = %q + 1) 
	   {
       	     Team::setObjective(%teamId, %lnum, "<f1>- " @ getTeamName(%q) @ ": " @ $teamScore[%q]);
	     %lnum = %lnum + 1;
           }

       %line = 6;

       Team::setObjective(%teamId, %line++, "\n");
       Team::setObjective(%teamId, %line++, "<f5>Mission Completion:");
       Team::setObjective(%teamId, %line++, "<f1>-<f0> " @ $DMTEAM::FragLimit @ "<f1> frags needed to win the mission!");
       Team::setObjective(%teamId, %line++, "\n");
       Team::setObjective(%teamId, %line++, "<f5>Team Deathmatch Objectives:");
       Team::setObjective(%teamId, %line++, "<f1>- Frag the hell out of the enemy :)");
       Team::setObjective(%teamId, %line++, "<f1>- Each frag is worth 1 point.");
       Team::setObjective(%teamId, %line++, "\n");
       Team::setObjective(%teamId, %line++, "<f5>Additional Information:");
       Team::setObjective(%teamId, %line++, "<f1>- Team kills, suicides, and LMA deaths deduct from your teams scores. Beware!");
       Team::setObjective(%teamId, %line++, "\n");
       Team::setObjective(%teamId, %line++, "<f1>- Turret kills do NOT count for points.");
       Team::setObjective(%teamId, %line++, "\n");
       Team::setObjective(%teamId, %line++, "<f1>- Remember to stay within the mission area, which is defined by the extents");
       Team::setObjective(%teamId, %line++, "<f1>  of your commander screen map.  If you go outside of the mission area you will");
       Team::setObjective(%teamId, %line++, "<f1>  have 10 seconds to get back into the mission area, or you will be killed!");

       return "True"; //change mission
   }
   else
   {
     Team::setObjective(%teamId, 3, "\n");
     Team::setObjective(%teamId, 4, "<f5>Team Deathmatch Mission Status:"); 													    
   
   
     if((%tieGame == True) && (%teamScore == %highScore) && (%highScore == 0))
        Team::setObjective(%teamId, 5, "<f1>- All teams tied at 0.");
     else if((%tieGame == True) && (%teamScore == %highScore))
        Team::setObjective(%teamId, 5, "<f1>- Your team is tied for the lead!");
     else if((%teamScore == %highScore) && (%tieGame == False))
        Team::setObjective(%teamId, 5, "<f1>- Your team is winning.");
     else
        Team::setObjective(%teamId, 5, "<f4>- Your team is losing.");

     %line = 6;

     Team::setObjective(%teamId, %line++, "\n");
     Team::setObjective(%teamId, %line++, "<f5>Mission Completion:");
     Team::setObjective(%teamId, %line++, "<f1>-<f0> " @ $DMTEAM::FragLimit @ "<f1> frags needed to win the mission!");
     Team::setObjective(%teamId, %line++, "\n");
     Team::setObjective(%teamId, %line++, "<f5>Team Deathmatch Objectives:");
     Team::setObjective(%teamId, %line++, "<f1>- Frag the hell out of the enemy :)");
     Team::setObjective(%teamId, %line++, "<f1>- Each frag is worth 1 point.");
     Team::setObjective(%teamId, %line++, "\n");
     Team::setObjective(%teamId, %line++, "<f5>Additional Information:");
     Team::setObjective(%teamId, %line++, "<f1>- Team kills, suicides, and LMA deaths deduct from your teams scores. Beware!");
     Team::setObjective(%teamId, %line++, "\n");
     Team::setObjective(%teamId, %line++, "<f1>- Turret kills do NOT count for points.");
     Team::setObjective(%teamId, %line++, "\n");
     Team::setObjective(%teamId, %line++, "<f1>- Remember to stay within the mission area, which is defined by the extents");
     Team::setObjective(%teamId, %line++, "<f1>  of your commander screen map.  If you go outside of the mission area you will");
     Team::setObjective(%teamId, %line++, "<f1>  have 10 seconds to get back into the mission area, or you will be killed!");

     return "False";
   }

}												

function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -1) // observers go last.
      %team = 9;
   // objective mission sorts by team first.
   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
}

function ObjectiveMission::refreshTeamScores()
{
   %nt = getNumTeams();
   Team::setScore(-1, "%t\t  0", 0);
   for(%i = -1; %i < %nt; %i++)
      Team::setScore(%i, "%t\t  " @ $teamScore[%i], $teamScore[%i]);
}

function Mission::init()
{

   setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
   setTeamScoreHeading("Team Name\t\xD6Score");

   $numTeams = getNumTeams();
   for(%i = 0; %i < $numTeams; %i++)
      $teamScore[%i] = 0;

   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }

   $timeLimitReached = false;
   $dieSeqCount = 0;
   DMTEAM::echoScores();
   DMTEAM::checkMissionObjectives();

   echo("*-*-* Team Deathmatch v1.6 Loaded Successfully! *-*-*");

}

//============================ Menu Functions

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

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
   else if(%opt == "cfraglimit")
   {
      Client::buildMenu(%clientId, "Change Fime Limit:", "cflimit", true);
      Client::addMenuItem(%clientId, "110 Frags", 10);
      Client::addMenuItem(%clientId, "220 Frags", 20);
      Client::addMenuItem(%clientId, "330 Frags", 30);
      Client::addMenuItem(%clientId, "440 Frags", 40);
      Client::addMenuItem(%clientId, "550 Frags", 50);
      Client::addMenuItem(%clientId, "660 Frags", 60);
      Client::addMenuItem(%clientId, "780 Frags", 80);
      Client::addMenuItem(%clientId, "8100 Frags", 100);
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
   else if(%opt == "ded")
   {
      $DMTEAM::equipDamage = False;
      messageAll(0, Client::getName(%clientId) @ " disabled equipment damage.");
   }
   else if(%opt == "eed")
   {
      $DMTEAM::equipDamage = True;
      messageAll(0, Client::getName(%clientId) @ " enabled equipment damage.");
   }
   Game::menuRequest(%clientId);
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
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
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
      Client::addMenuItem(%clientId, %curItem++ @ "Change Frag Limit", "cfraglimit");  //add option to change the frag limit
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
      if($DMTEAM::equipDamage == True)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable equipment damage", "ded");  //disable damage to equipment
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable equipment damage", "eed");  //enable damage to equipment
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
   }
}

function processMenuCFLimit(%clientId, %opt)
{
   $DMTEAM::FragLimit = %opt;
   messageAll(0, Client::getName(%clientId) @ " changed the Frag Limit to " @ $DMTEAM::FragLimit @ ".");
}

//============================  equipDamage Functions

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if($DMTEAM::equipDamage == True)
   {
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
     	%this.lastDamageObject = %object;
     	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station)
		{
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05)
			{
		            if(%damageLevel > %disable - 0.05)
		               return;
		            else
		               %dValue = %disable - 0.05;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
    }
    else
      return;
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
  if($DMTEAM::equipDamage == True)	// PORT: was 'If'
  {
     if(%this.objectiveLine)
	%this.lastDamageTeam = GameBase::getTeam(%object);

	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
  }
  else
    return;
}

function Sensor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
  if($DMTEAM::equipDamage == True)
  {
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);
		if(%name != DeployableMotionSensor && %name != DeployablePulseSensor && %name != DeployableSensorJammer )				
	  		%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
  }
  else
    return;

}