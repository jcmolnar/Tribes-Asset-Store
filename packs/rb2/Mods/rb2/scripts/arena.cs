// Tribes Arena v 1.9.2
// Robert "Rasia" Hinkle
// This is a mission type taken from the idea of Clan Arena back in the good old Quake 1 days
// Its a Team DM game, in which everyone spawns, you rush for weapons, and try to kill each other
// When you die, you sit in observer mode until one team is all dead.  When that happens everyone respawns.
// I used a couple definations here:  a Match is a full compatition between two teams.  Each match is made
// up of a set of Games.  When one team fully dies, thats the end of a game.  Most matches are 3 out of 5 Games.
// I want to thank TheGriffin and Ninja for the help!

$Arena::NumberMatchLimit = 6;			// After this many matches the server cycles to next map (Defualt 3).  Set = "" if you don't want this feature (or if it keeps crashing the server)
$MaxPlayersAfter = $Server::MaxPlayers;  // change $Sever::MaxPlayers to how many players you want in non-Arena maps.  Make sure to put " " around the number.
$TimeAfter = $Server::TimeLimit;		// change $Server::TimeLimit to the timelimit you want in non-Arena maps.  Do NOT use " " on timelimit numbers
if ($Server::Maxplayers > 30)			// Delete this line
	$Server::MaxPlayers = "30";			// Change this to how many players you want in Arena Maps
$Server::TimeLimit = 0;
$TeamEnergyAfter = $TeamEnergy[0];		// Change this if you want a different energy then you came in with

//////////// Don't Modify below this line
///Setting the TeamScores to 0 when the map starts
$TeamMatchScore[0] = 0;
$TeamMatchScore[1] = 0;
$Server::TeamDamageScale = 1; // Team Damage Always On
$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$incTeamEnergy = 0;
$TeammateSpending = -800;
$ItemFavoritesKey = "RealityBites";  // Setup Arena Favs
$MatchStatus = 0;  // MatchStatus keeps track of where the match is.  0=PreMatch, 1=Battle, 2=Pre-Game, 3=Countdown

//Item Functions


// Objectives Functions

function ObjectiveMission::setObjectiveHeading()
{
   for(%i = -1; %i < getNumTeams(); %i++)
		Team::clearObjectives(%i);
   
   if($missionComplete)
   {
      %curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
		   echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
      {
		   if($teamScore[%i] == $teamScore[%curLeader]) { 
            %tieGame = true;
         	%tieTeams[%tie++] = %i;
			}
			else if($teamScore[%i] > $teamScore[%curLeader])
         {
            %curLeader = %i;	   
            %tieGame = false;
				%tie = 0;
				%tieTeams[%tie] = %curLeader; 
         }
      }
		if(%tieGame) {
			for(%g = 0; %g <= %tie; %g++) { 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
			 	%names = %names @ " all"; 
		}
		for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
			if(!%tieGame) {
	         if(%i == %curLeader) { 
					if($teamScore[%curLeader] == 1)
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else {
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
  					else
	          		Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}	
			else {
				if(getNumTeams() > 2) {
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
  	         }
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
		}
   }
   else {
      for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
		  	Team::setObjective(%i,1, "<f5>Mission Completion:");
		   Team::setObjective(%i, 2,"<f1>   - " @ $Arena::Scorelimit @ " points needed to win the match.");
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else if($missionComplete)
   {
      %time = getSimTime() - $missionStartTime;
      %minutes = Time::getMinutes(%time);
      %seconds = Time::getSeconds(%time);
      if(%minutes < 10)
         %minutes = "0" @ %minutes;
      if(%seconds < 10)
         %seconds = "0" @ %seconds;
      %str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
   }
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
      $ArenaObjectiveLine = 7 + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++) {
	  	Team::setObjective(%i, 3, " ");
  		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
      Team::setObjective(%i, 6, %str);
	  Team::setObjective(%i, $ArenaObjectiveLine, "<f5>Arena Rules:");
	  Team::setObjective(%i, $ArenaObjectiveLine + 1, "<f4>Before a match starts, everyone on a team must readyup.  When everyone is ready, a 10 second countdown beings, and then the match and first game start.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 3, "<f4>When one team is fully dead (you don't respawn when you die), then a GAME is over.  Everyone respawns on the same team, and another countdown beings.  You CAN NOT join a team between games, only matches (without Admin help at least)");
	  Team::setObjective(%i, $ArenaObjectiveLine + 5, "<f4>This repeats until one team has won the amount of games required to win a match (" @ $Arena::ScoreLimit @ ").  When one team hits this limit, they win the match, and the process starts again.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 10, "<f5>Other Arena Stuff");
	  Team::setObjective(%i, $ArenaObjectiveLine + 12, "<f4>The * beside a persons name means they are alive.  The team always reflects what team they are a member of, and the score IS kills, but you also get 5 points for every match you win.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 17, "<f6>Visit planetstarsiege.com/TheDen for clientside maps, new sounds, and other random stuff for Arena, as well as other mods and mission types.");
	}
}

// Now the Team Scores display the Varible TeamMatchScore, which is how many Games each team has won this match
function ObjectiveMission::refreshTeamScores()
{
  %nt = getNumTeams();
  Team::setScore(-1, "%t\t  0", 0);
  for(%i = -1; %i < %nt; %i++)
  {
      Team::setScore(%i, "%t\t  " @ $TeamMatchScore[%i], $TeamMatchScore[%i]);
      for(%j = 0; %j < %nt; %j++) 
         Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $TeamMatchScore[%j]);
  }
}

// Blanked so ScoreLimit won't change missions (like a cap limit)
function ObjectiveMission::checkScoreLimit()
{

}


//Blanked so a persons score doesn't go up becuase of holding an objective
function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{

}

function Player::leaveMissionArea(%player)
{
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

//called if player leaves mission area
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

function Mission::init()
{
   setClientScoreHeading("  Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEDPL\t\xFFAdmin");
   setTeamScoreHeading("Team Name\t\xD6Score");

    if ($Arena::Scorelimit == "")
		$Arena::Scorelimit = 3;  // Default ScoreLimit
	if ($Arena::ReadyTime != false)
		$Arena::ReadyTime = true;
	if ($Arena::AutoTeamjoin != false)
		$Arena::AutoTeamJoin = true;


		
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
   
   Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
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
   schedule("ObjectiveMission::checkPoints();", 5);

	$TestMissionType = "ARENA";

   AI::setupAI();

   if ($Arena::AutoTeamJoin)
		Arena::resetmatch();

}

function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -1) // observers go last.
      %team = 9;

	  %teamstr = getTeamName(%clientId.matchteam);
	  if (%teamstr == "0")
		%teamstr = "";

  
   if (%clientId.isSuperAdmin)
		%admin = "S";
	else if (%clientId.isAdmin)
		%admin = "A";
	else
		%admin = " ";
   
   // objective mission sorts by team first.
   Client::setScore(%clientId,  %clientId.onteam @ " %n\t" @ %teamstr @ "\t  " @ %clientId.score  @ "\t%p\t%l\t   " @ %admin, %clientId.score + (9 - %team) * 10000);
}

// Admin Functions


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
   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
   Client::addMenuItem(%clientId, %curItem++ @ "Tribes Arena Options", "arenaop");
   
}

// Called when a client FIRST connects to a map to Choose thier Team (-2 is Obs, -1 is Automatic)
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
	  {
		%clientId.notready = true;  // Sets the Client to not ready
	    if ($Arena::ReadyTime && %team != -2)
			schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);
	  }
    }
   	  Game::refreshClientScore(%clientId);
}

// Called to sort out what Menu selections do
function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   
   if(%opt == "fteamchange") //fteamchange is an Admin forcing a client to change teams
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	  return;
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
		 if (%clientId.lock)
			Client::addMenuItem(%clientId, "9Observer/UnLockMe", 9);
		 else
		    Client::addMenuItem(%clientId, "9Observer/LockMeOut", 9);

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
   else if (%opt == "cwinscore") // Changes $Arena::Scorelimit to whatever is selected
   {
      Client::buildMenu(%clientId, "Change Winning Score:", "cwscore", true);
	  Client::addMenuItem(%clientId, "12 out of 3", 2);
	  Client::addMenuItem(%clientId, "23 out of 5", 3);
      Client::addMenuItem(%clientId, "34 out of 7", 4);
      Client::addMenuItem(%clientId, "45 out of 9", 5);
      Client::addMenuItem(%clientId, "56 out of 11", 6);
      Client::addMenuItem(%clientId, "67 out of 13", 7);
      Client::addMenuItem(%clientId, "78 out of 15", 8);
      Client::addMenuItem(%clientId, "89 out of 17", 9);
      Client::addMenuItem(%clientId, "910 out of 19", 10);
      return;
   }	
   else if (%opt == "resetmatch") // Calls the Arena Reset function to reset the match
	{
		Arena::ResetMatch();
		messageall(0, Client::getName(%clientId) @ " has reset the match.");
		return;
	}
   else if (%opt == "forcematch") // Calls the Arena Reset function to reset the match
	{
		messageall(0, Client::getName(%clientId) @ " has forced the countdown to start");
		Arena::ForceMatchStart();
		return;
	}
   else if (%opt == "ereadytime")
   {
		$Arena::ReadyTime = true;
		messageAll(0, Client::getName(%clientId) @ " has enabled ReadyUp Time Limit.");
		return;
	}
   else if (%opt == "dreadytime")
   {
		$Arena::ReadyTime = false;
		messageAll(0, Client::getName(%clientId) @ " has disabled ReadyUp Time Limit.");
		return;
	}
	else if (%opt == "eautoteam")
	{
		$Arena::AutoTeamJoin = true;
		messageAll(0, Client::getName(%clientId) @ " has enabled AutoTeamJoin.");
		return;
	}
	else if (%opt == "dautoteam")
	{
		$Arena::AutoTeamJoin = false;
		messageAll(0, Client::getName(%clientId) @ " has disabled AutoTeamJoin.");
		return;	
	}
	else if (%opt == "cstrip")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	    {
   			if (%cl.isAdmin && !%cl.isSuperAdmin)
				%cl.isAdmin = false;
		}
		messageAll(0, Client::getName(%clientId) @ " has stripped admin rights from the public.");
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
   else if (%opt == "arenaop")
   {
    %curItem = 0;
    Client::buildMenu(%clientId, "Options", "options", true);
	if(%clientId.isAdmin)
    {
	  Client::addMenuItem(%clientId, %curItem++ @ "Change Winning Score", "cwinscore"); //Admins can Change MatchScoreLimit
	  Client::addMenuItem(%clientId, %curItem++ @ "Reset Match", "resetmatch");
	  Client::addMenuItem(%clientId, %curItem++ @ "Force Match/Game Start", "forcematch");
	  if(!$Arena::Readytime)	  
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable ReadyUp Timelimit", "ereadytime");
	  else
		  Client::addMenuItem(%clientId, %curItem++ @ "Disable ReadyUp Timelimit", "dreadytime");
      if(!$Arena::AutoTeamJoin)
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable AutoTeamJoining", "eautoteam");
	  else
		  Client::addMenuItem(%clientId, %curItem++ @ "Disable AutoTeamJoining", "dautoteam");
	  if (%clientId.isSuperAdmin)
	      Client::addMenuItem(%clientId, %curItem++ @ "Strip Public Admins", "cstrip");
	 }
	 return;
	}

   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuCWScore(%clientId, %opt) // This changes the ScoreLimit, called from the Menu
{
	messageAll(0, Client::getName(%clientId) @ " has changed the Winning Score to " @ %opt);
	$Arena::Scorelimit = %opt;
}

// Called when a Team Change is in effect
function processMenuPickTeam(%clientId, %team, %adminClient)
{

   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.lock && %adminClient != "")
   {
		Client::sendMessage(%adminClient,3, Client::getName(%clientId) @ " has locked himself out of play.  He will not be able to join a team until he selects a team or unlocks himself from the Tab Menu.");
		return;
	}
   
   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if (%team == 9 && %clientId.lock)
   	{	
		messageAll(0, Client::getname(%clientId) @ " has unlocked himself.");
		%clientId.lock = false;
		%team = -2;
	}
	else if(%team != 9)
		%clientId.lock = false;
	else
   {
		%clientId.lock = true;
		messageAll(0, Client::getname(%clientId) @ " has locked himself out of play.  He will be unable to join the game until he unlocks himself via the Player Menu.");
		%team = -2;
	}
   
   if(%team == -1)
   {
		if ((Arena::CountTeam(0) + Arena::CountTeam(0))  > (Arena::CountTeam(1) + Arena::CountTeam(1)))
		{
			%team = 1;
			%clientId.matchteam = 1;
		}
		else if ((Arena::CountTeam(0) + Arena::CountTeam(0))  < (Arena::CountTeam(1) + Arena::CountTeam(1)))
		{
			%team = 0;
			%clientId.matchteam = 0;
		}
		else if ($TeamMatchScore[0] > $TeamMatchscore[1])
		{
			%clientId.matchteam = 1;
			%team = 1;
		}
		else
		{
			%team = 0;
			%clientId.matchteam = 0;
		}
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
			if ((Arena::CountTeamPlayers(%clientId.matchteam) == 0) && (%clientId.matchteam != -2) && $MatchStatus != 0)  // If the observer was the last guy on the team, the other team wins
			{
				%temp = 1 - %clientId.matchteam;
				%clientId.matchteam = -2;
				centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 10);
				$MatchStatus = 2;
				Arena::GameOver(%temp);
			}
			%clientId.matchteam = -2;
			%clientId.onteam = " ";
			Game::refreshClientScore(%clientId);

		}
	   return;
   }
   else if($MatchStatus == 1)
   {
		messageAll(0, Client::getName(%clientId) @ " has joined the "  @ getTeamName(%team) @ " team, and will spawn after this game.");
		%clientId.matchteam = %team;
		Game::refreshClientScore(%clientId);
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
   Game::refreshClientScore(%clientId);
   if ($Arena::ReadyTime && %team != -2)
	schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);

}

// Mostly a copy of the above function, but this one doesn't reset your .matchteam varible
function Arena::PickTeam(%clientId, %team, %adminClient)
{
 
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if (%clientId.lock)
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
			%clientId.onteam = " ";
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
	Game::RefreshClientScore(%clientId);
    if ($Arena::ReadyTime && %team != -2)
		schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);
}

// Observer Functions
// triggerUp is the Fire Key, as far as I can tell, this controls "Fire when ready"
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
          bottomprint(%client, $PreGameMessage[%client.matchteam] @ "Waiting for match start (FIRE if not ready).", 0);
		  centerprint(%client, "", 0);
		  Arena::PreGameMode();
      }
      else // else unready him
      {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, $PreGameMessage[%client.matchteam] @ "Press FIRE when ready.", 0);
      }
	}  		
}


// Game Functions
// called right at the start of a new map
function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
   	Game::refreshClientScore(%cl);  // Originally it had you come out of Obs here, took it out
	}
   Game::checkTimeLimit();
}

// Called when a player Physically spawns
function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

   Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Tribes Arena Version 1.9.2\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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

$TeleSpot[Client::getTeam(%clientId)] = %spawnPos;

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
				centerprint(%clientId, "<f1><jc>You are playing Tribes Arena v 1.9.2\n" @ $PreGameMessage[%clientId.matchteam] @ "Press FIRE when ready.", 10);
			 }

	   %clientId.onteam = "*";

	   }
      return true;
	}
	else 
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}


// Called when someone first connects into the Mission
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
		 bottomprint(%clientId, "<jc><f1>Server is running Tribes Arena v1.9.2.  Match has started, Please wait until its finished.  Score limit is " @ $Arena::Scorelimit @ "\nAutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\nReadyUp Timer is " @ $Arena::ReadyTime, 5);
         Game::RefreshClientScore(%clientId);
		 return;
      }
      else // Else choose your team
      {
         bottomprint(%clientId, "<jc><f1>Server is running Tribes Arena v1.9.2.  Match has not yet started, Pick a Team.  Score limit is " @ $Arena::Scorelimit @ "\nAutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\nReadyUp Timer is " @ $Arena::ReadyTime, 5);
		 if ($Arena::AutoTeamJoin)
			processMenuPickTeam(%clientId, -1);
		 else
		    processMenuPickTeam(%clientId, -2);
      }
      %clientId.justConnected = "";
	  Game::RefreshClientScore(%clientId);
	  Client::sendMessage(%clientId, 1, "Hello " @ Client::getName(%clientId) @ ", and welcome to Tribes Arena.  Please hit O to review the rules and objects of Arena.  Also, you can visit planetstarsiege.com/TheDen to get client-side things, such as maps, sounds, and artwork for Tribes Arena.  THANKS FOR PLAYING!!");

}

// when a client connects, zero out that id's stats
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	%playerId.matchteam = -2;
	%playerId.streak = 0;
	$menuMode[%playerId] = "None";
	%playerId.onteam = " ";
	Game::refreshClientScore(%playerId);
}

// When someone is killed this is where it goes
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
	  %killerId.score--;
		if ($MatchStatus != 1)
		{
			schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
		}
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
	{
		schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
		schedule("Arena::CheckTeamDeath( " @ %playerId.matchteam @ ");", 3);
	}
	else
		Arena::PickTeam(%playerId, -2);


}	

// Someone bailing on the server
function Client::leaveGame(%clientId)
{

   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
	
	messageAll(0, strcat(Client::getName(%clientId), " has chickened OUT!"));


	if (Client::getTeam(%clientId) > -1)
	{
		Arena::PickTeam(%clientId, -2);

		if (Arena::CountTeamPlayers(%clientId.matchteam) == 0 && $MatchStatus != 0)
		{	
			$MatchStatus = 2;
			%otherteam = 1 - %clientId.matchteam;
			%clientId.matchteam = -2;
			Game::refreshClientScore(%clientId);
			centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 5);
			schedule("Arena::GameOver(%otherteam);", 4);
		}
	}


}

	
// Server Functions
		
//When a new level is loaded, reload the base files I overwrote functions from.  If its an arena map, I will re-overwrite them
function Server::loadMission(%missionName, %immed)
{
   if($loadingMission)
      return;

   exec(observer);
   exec(admin);
   exec(server);
   exec(station);
   exec(item);
   exec(staticshape);

   $Server::MaxPlayers = $MaxPlayersAfter;
   $Server::TimeLimit = $TimeAfter;
   $TeamEnergy[0] = $TeamEnergyAfter;
   $TeamEnergy[1] = $TeamEnergyAfter;

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



// Arena Functions
// Called when one team no longer has members in a game
function Arena::CheckTeamDeath(%team)
{
	%teamCount = Arena::CountTeamPlayers(%team);
	%otherteam = 1 - %team;
	if (%teamCount == 1)
		messageAll(0, getTeamName(%team) @ " has one member left.  FINISH HIM!~wfinishim.wav");
	if (%teamCount < 1 && $MatchStatus == 1) //Someone won a game woohoo!
	{
	    $MatchStatus = 2;
		centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 4);
		schedule("Arena::GameOver(" @ %otherteam @ ");", 6);  // Game is over, pass the winning team's index
	}
}

function Arena::GameOver(%winningTeam)
{

// Big Statement.  Each client is killed to prevent ghosting and then kicked to observer
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam != -2)
		{	
			%player = Client::getOwnedObject(%cl);
			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
			{
				playNextAnim(%cl);
				Player::kill(%cl);
			}
		

			Arena::PickTeam(%cl, -2);
		}
	}


	$TeamMatchScore[%winningTeam]++;
	ObjectiveMission::refreshTeamScores();
	if ($TeamMatchScore[0] > $TeamMatchScore[1])
	{
		$PreGameMessage[0] = "<f1><jc>You are winning by " @ $TeamMatchScore[0] - $TeamMatchScore[1] @ ".  You need " @  $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
		$PreGameMessage[1] = "<f1><jc>You are losing by " @ $TeamMatchScore[0] - $TeamMatchScore[1] @ ".  They need " @ $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
	}
	else if ($TeamMatchScore[0] < $TeamMatchScore[1])
	{
		$PreGameMessage[1] = "<f1><jc>You are winning by " @ $TeamMatchScore[1] - $TeamMatchScore[0] @ ".  You need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
		$PreGameMessage[0] = "<f1><jc>You are losing by " @ $TeamMatchScore[1] - $TeamMatchScore[0] @ ".  They need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
	}
	else
	{
		$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
		$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
	}
	if ($TeamMatchScore[%winningTeam] >= $Arena::Scorelimit || Arena::CountTeam(1 - %winningTeam) == 0) //If a team has hit the ScoreLimit or if a team is completely empty of players
	{
		Arena::MatchCompleted(%winningTeam); // Match Over
		if ($MatchStatus == 3)
			schedule("Arena::ResetMatch();", 11);
		return;
	}
	else // Else put all the clients back on the team they belong
	{		
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{	
			if (%cl.matchteam != -2)
			{
				Arena::PickTeam(%cl, %cl.matchteam);
				Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
				%cl.notready = false;
				bottomprint(%cl, $PreGameMessage[%cl.matchteam] @ "Game starting in 10 seconds", 0);
			}
		}

	Arena::PreGameMode(); // Back to Pre-Game Mode
	}		

}

//Called when a Team has won the Match
function Arena::MatchCompleted(%winningTeam)
{
	messageAll(0, "~wflagcapture.wav");
	centerPrintAll("<jc>" @ getTeamName(%winningTeam) @ " has won the match.  They all get 5 points!", 4);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam == %winningTeam)
			%cl.score = %cl.score + 5;
	}
	schedule("Arena::ResetMatch();", 4);
	$Arena::NumberMatchLimit--;
}

// Starts the whole process over
function Arena::ResetMatch()
{
	
	if ($Arena::NumberMatchLimit < 1 && $Arena::NumberMatchLimit != "")
	{
		Server::NextMission();
		return;
	}
	$MatchStatus = 0;
	$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
	$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
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
		if (!$Arena::AutoTeamJoin)
		{
			processMenuPickTeam(%cl, -2);
			bottomprint(%cl, "<jc><f1>Server is running Tribes Arena v1.9.2 and is in Pre-Match Mode. Pick a Team.  Score limit is " @ $Arena::Scorelimit, 5);
		}
		else
		{
			%cl.notready = true;
			if (!%cl.lock)
				processMenuPickTeam(%cl, -1);
		}

		Game::refreshClientScore(%cl);
	}


}	// NOTE: After this function the MatchStatus is now in Pre-Match mode, so people cna join teams via the menu


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
			if (%NotReadyCount < 4)
				messageAll(0, %NotReadyString);
			return false;
		}
		else
			return true;
}

// Pre-Game Mode Function
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
			if ($MatchStatus == 3)
				return;				
			else if ($MatchStatus == 0)
				messageAll(0, "Arena Battle Starts in 10 seconds~wrumble.wav");
			else
				messageAll(0, "Arena Battle Starts in 10 seconds");
			$MatchStatus = 3;
			schedule("messageAll(0, \"Arena Battle Starts in 5 seconds\");", 5);
			schedule("messageAll(0, \"Arena Battle Starts in 4 seconds\");", 6);
			schedule("messageAll(0, \"Arena Battle Starts in 3 seconds\");", 7);
			schedule("messageAll(0, \"Arena Battle Starts in 2 seconds\");", 8);
			schedule("messageAll(0, \"Arena Battle Starts in 1 seconds\");", 9);
			schedule("Arena::StartGame();", 10);

		}
	}
}

function Arena::ForceMatchStart()
{
	if ($MatchStatus == 3)
		return;
	else if ($MatchStatus == 0)
		messageAll(0, "Arena Battle Starts in 10 seconds~wrumble.wav");
	else
		messageAll(0, "Arena Battle Starts in 10 seconds");
	$MatchStatus = 3;
	schedule("messageAll(0, \"Arena Battle Starts in 5 seconds\");", 5);
	schedule("messageAll(0, \"Arena Battle Starts in 4 seconds\");", 6);
	schedule("messageAll(0, \"Arena Battle Starts in 3 seconds\");", 7);
	schedule("messageAll(0, \"Arena Battle Starts in 2 seconds\");", 8);
	schedule("messageAll(0, \"Arena Battle Starts in 1 seconds\");", 9);
	schedule("Arena::StartGame();", 10);
}
// Starts the Game
function Arena::StartGame()
{

	$MatchStatus = 1;
	messageAll(0, "FIGHT!!!!~wfight.wav");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{		
		if (Client::getTeam(%cl) != %cl.matchteam && %cl.matchteam != -2)
			Arena::PickTeam(%cl, %cl.matchteam);
		%cl.InvTrips = 0;
		%cl.EnergyWarning = 0;
		if (%cl.matchteam != -2)
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			bottomprint(%cl, "", 0);
		}
	}
}

// Counts the people physically alive on a team
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

// Counts the people on a team, even if they are in Observer mode currently
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

function Arena::CheckReadyState(%clientId)
{
	if (%clientId.notready && $Arena::ReadyTime && ($MatchStatus == 0 || $MatchStatus == 2))
	{	
		processMenuPickTeam(%clientId, -2);
		messageAll(0, Client::getName(%clientId) @ " didn't ready up in time and was placed in observer mode.");
	}
}

function ceiling(%number) // I just refuse to believe Dev didn't make one, but it was quick to make one than to look for it :)
{
	if (floor(%number) == %number)
		return %number;
	else
		return (1 + floor(%number));
}
