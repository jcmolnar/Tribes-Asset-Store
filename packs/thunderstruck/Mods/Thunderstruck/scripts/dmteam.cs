exec("game.cs");
$MaxNumKills = 15;

function Game::clientKilled(%playerId, %killerId)
{
	if(%killerId == -1 || %playerId == -1) return;

	%kteam = Client::getTeam(%killerId);
	%pteam = Client::getTeam(%playerId);

	if(%kteam == %pteam) {
		if(%playerId != %killerId) { 
			$teamScore[%kteam]--;
		} 
	} else {
		$teamScore[%kteam]++;
	}
	Team::setScore(%kteam, "%t\t"@$teamScore[%kteam], $teamScore[%kteam]);
      
	DMTEAM::MissionObjectives();
   
}

function Game::playerSpawned(%pl, %clientId, %armor)
{	  
	
	Client::setSkin(%clientId, $Client::info[%clientId, 0]);

	if(%clientId.permap == true) {
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "larmor";
		else
			%armor = "lfemale";
		Player::setArmor(%clientId,%armor);
		return;
	}

	Player::setArmor(%clientId,$ArmorType[Client::getGender(%clientId), CArmor]);
	Player::setItemCount(%clientId,Blaster,1); Player::setItemCount(%clientId,Beacon,1); 	
	Player::setItemCount(%clientId,BulletAmmo,100); Player::setItemCount(%clientId,Chaingun,1); 	
	Player::setItemCount(%clientId,DiscAmmo,10); Player::setItemCount(%clientId,DiscLauncher,1); 
	Player::setItemCount(%clientId,Grenade,4); Player::setItemCount(%clientId,RepairKit,1); 
	if($ThunderStruck::DMInventories) {
		Player::setItemCount(%clientId,DeployableInvPack,1); 
		Player::mountItem(%pl,DeployableInvPack,$BackpackSlot); 
	}
	Player::useItem(%pl,Chaingun); 

	doneposs(%clientId);
	if(%clientId.dan == true) {			
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, Client::getOwnedObject(%clientId), 3, 3, 3);
	}
   
	DMTEAM::MissionObjectives();
}


function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%player.outArea=1;
	alertPlayer(%player, 3);
}


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

function leaveMissionAreaDamage(%client) { 
	%player = Client::getOwnedObject(%client); 
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) { 
			Player::setDamageFlash(%client,0.6); 
			if((GameBase::getDamageLevel(%player) + 0.05) >= (Player::getArmor(%player)).maxdamage) {
				Client::sendMessage(%client,1,"You have been killed for leaving the mission area.~wLeftMissionArea.wav"); MessageAllExcept(%client, 1, Client::getName(%client) @ " has been killed for leaving the mission area.");
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

function Game::checkTimeLimit()
{
   
   
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0) {
		$timeLimitReached = true;
		$timeReached = 1;
		DMTEAM::FinalObjectives();
		$timeLimitReached = false;
		$timeReached = "";
		Server::nextMission();	
	}  else  {
		DMTEAM::MissionObjectives();
		schedule("Game::checkTimeLimit();", 20);
		UpdateClientTimes(%curTimeLeft);
	}
}

function Vote::changeMission()
{
	$timeLimitReached = true;
	$timeReached = 1;
	DMTEAM::FinalObjectives();
}
 
function DMTEAM::echoScores()
{   
	%tr = floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60);
	if(%tr > 2 && %tr <= 5)      
		schedule("DMTEAM::echoScores();", 55);
	else if(%tr <= 2)      
		schedule("DMTEAM::echoScores();", 25);
	else {
		schedule("DMTEAM::echoScores();", 120);		
		return;
	}

   %highScore = 0;
	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] > %highScore)
			%highScore = $teamScore[%t];

	%numHighs = 0;
	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] == %highScore)
			%numHighs = %numHighs + 1;

	for(%i = 0; %i < $numTeams; %i = %i + 1) {

		%sechigh = 1000;
		if($teamScore[%i] == %highscore) 
			for(%t = 0; %t < $numTeams; %t = %t + 1)				
				if($teamScore[%t] != %highscore && (%highscore-$teamScore[%t]) < %sechigh)
					%sechigh = $teamScore[%t];
					
		if(($teamScore[%i] == %highScore) && (%highScore == 0))
			%str = "All teams tied at zero.";
		else if(($teamScore[%i] == %highScore) && (%numHighs > 1)) 
			%str = "Your team is tied for the lead!";
		else if(($teamScore[%i] == %highScore) && (%numHighs == 1)) {
			%str = "Your team is winning by "@(%highScore-%sechigh)@".";
 		} else {
			%str = "Your team is losing by "@(%highScore-$teamScore[%i])@".~waccess_denied.wav";
		}

		teamMessages(0, %i, %str, "", "", "");
	}
}

function DMTEAM::MissionObjectives()
{
   for(%p = 0; %p < $numTeams; %p = %p + 1) {
		if(DMTEAM::teamMissionObjectives(%p)) {
			$timeLimitReached = true;
			$timeReached = 1;
			DMTEAM::FinalObjectives();
			$timeLimitReached = false;
			$timeReached = "";
			Server::nextMission();
   		}
	}
}

function DMTEAM::teamMissionObjectives(%teamId)
{
   %numHighs = 0;
   %teamName = getTeamName(%teamId);
   %teamScore = $teamScore[%teamId];
   %highScore = 0;
   %lineNum = 0;
	%sechigh = 1000;
  
	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] > %highScore)
			%highScore = $teamScore[%t];

	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] == %highScore)
			%numHighs = %numHighs + 1;

	if(%teamScore == %highscore) 
		for(%t = 0; %t < $numTeams; %t = %t + 1)				
			if($teamScore[%t] != %highscore && (%highscore-$teamScore[%t]) < %sechigh)
				%sechigh = $teamScore[%t];

	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1) {
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++) {
			if((%clientList[%i]).ratio < (%clientList[%i+1]).ratio) {
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
	
	if($timeReached == "") {
		%l = %teamId;
 	  	Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
  		Team::setObjective(%l, %lineNum++, "<f5>Mission Status:");
		if((%teamScore == %highScore) && (%highScore == 0))
			Team::setObjective(%teamId, %lineNum++, "<f1>   - All teams tied at zero.");
		else if((%teamScore == %highScore) && (%numHighs > 1)) 
			Team::setObjective(%teamId, %lineNum++, "<f1>   - Your team is tied for the lead!");
		else if((%teamScore == %highScore) && (%numHighs == 1))
			Team::setObjective(%teamId, %lineNum++, "<f1>   - Your team is winning by "@(%highScore-%sechigh)@".");
		else
			Team::setObjective(%teamId, %lineNum++, "<f1>   - Your team is losing by "@(%highScore-%teamScore)@".");
		Team::setObjective(%l, %lineNum++, " ");

  		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
		Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
		Team::setObjective(%l, %lineNum++, %str);
		Team::setObjective(%l, %lineNum++, " ");
 	  	Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
 	  	Team::setObjective(%l, %lineNum++, "<f1>   - Kill all players on all other teams!");
 	  	Team::setObjective(%l, %lineNum++, "<f1>   - Stay alive!");
 	  	Team::setObjective(%l, %lineNum++, " ");
 	  	Team::setObjective(%l, %lineNum++, "<f1>Remember to stay within the mission area, which is defined by the extents of your commander screen map."	@ 
 	                                 " If you go outside of the mission area you will have 3 seconds to get back into the mission area, or you'll start taking damage!");
 	  	Team::setObjective(%l, %lineNum++, " ");
 	  	Team::setObjective(%l, %lineNum++, " ");
	  	Team::setObjective(%l, %lineNum++, "<f5>Top Players Are: " );
 	  	Team::setObjective(%l, %lineNum++, " ");
 	  	Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Kills<L50>Deaths<L70>Efficiency");
	} else {
		return true;
	}
	%index = 0; %lastRatio = 0;
	while(%index < %numClients && %clientList[%index].ratio != 0 && (%index < 5 || (%clientList[%index].ratio == %lastRatio && %lastRatio != 0))) {
		%client = getClientByIndex(%index);
		Team::setObjective(%l, %lineNum++,"<Bskull_small.bmp>" @ Client::getName(%clientList[%index]) @ " <L31>" @ (%clientList[%index]).scoreKills @ "<L53>" @ (%clientList[%index]).scoreDeaths @ "<L72>" @ (%clientList[%index]).ratio @ ".0%");
		%lastRatio = (%clientList[%index]).ratio;
		%index++;
	}  
	for(%s = %lineNum+1; %s < 30 ;%s++)
		Team::setObjective(%l, %s, " ");

  	$timeReached="";
	return "False";
}												

function DMTEAM::FinalObjectives() {


	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++) 
		%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1) {
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++) {
			if((%clientList[%i]).ratio < (%clientList[%i+1]).ratio) {
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1]	= %hold;
				%doIt=1;
			}
		}
	}
 
	%numHighs = 0;
	%highScore = 0;
	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] > %highScore)
			%highScore = $teamScore[%t];

	for(%t = 0; %t < $numTeams; %t = %t + 1)
		if($teamScore[%t] == %highScore)
			%numHighs = %numHighs + 1;

	for(%l = -1; %l < $numTeams; %l++) {		

		%lineNum = 0;
		
 	  	Team::setObjective(%l, %lineNum++, " " );
 	  	
		  if($teamScore[%l] == %highScore && (%numHighs == 1))
             Team::setObjective(%l, %lineNum++, "<F5>   Your team is victorious!");
          else if(($teamScore[%l] == %highScore) && (%numHighs > 1)) 
             Team::setObjective(%l, %lineNum++, "<F5>   Your team has tied for the lead!");
          else
             Team::setObjective(%l, %lineNum++, "<F5>   Your team lost!"); 

 	  	Team::setObjective(%l, %lineNum++, " " );	   
       
		for(%q = 0; %q < $numTeams; %q = %q + 1) 
			Team::setObjective(%l, %lineNum++, "<f1> " @ getTeamName(%q) @ ": " @ $teamScore[%q]);

 	  	Team::setObjective(%l, %lineNum++, " " );
       
		Team::setObjective(%l, %lineNum++, "<f1>     - The Best Player(s): " );
		%i=0;
		%TopRatio="";
		while(%i < %numClients && %clientList[%i].ratio != 0 && (%TopRatio == "" || (%TopRatio ==  (%clientList[%i+1]).ratio && %TopRatio != 0) )) {
 	  		Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[%i]) @ "<f1> with a ratio of <f5>" @ (%clientList[%i]).ratio @ ".0%");
			%TopRatio = (%clientList[%i]).ratio;
			%i++;
		}
		if(%i == 0) {
 	  		Team::setObjective(%l, %lineNum++, "<L14><f1>NONE with a ratio greater than 0.0%");
		}
		Team::setObjective(%l, %lineNum++, " ");
 	  	Team::setObjective(%l, %lineNum++, " ");
		Team::setObjective(%l, %lineNum++, "<f5>Top Players Are: " );
 	  	Team::setObjective(%l, %lineNum++, " ");
		Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Kills<L50>Deaths<L70>Efficiency");

		%index = 0; %lastRatio = 0;
		while(%index < %numClients && %clientList[%index].ratio != 0 && (%index < 5 || (%clientList[%index].ratio == %lastRatio && %lastRatio != 0))) {
	  		%client = getClientByIndex(%index);
	  	   Team::setObjective(%l, %lineNum++,"<Bskull_small.bmp>" @ Client::getName(%clientList[%index]) @ " <L31>" @ (%clientList[%index]).scoreKills @ "<L53>" @ (%clientList[%index]).scoreDeaths @ "<L72>" @ (%clientList[%index]).ratio @ ".0%");
			%lastRatio = (%clientList[%index]).ratio;
			%index++;
		}  
		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}

}

function getEfficiencyRatio(%clientId)
{
	if((%clientId.scoreKills + %clientId.scoreDeaths) > 4) {
		%ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100);		
		return %ratio;
	}
	return "0";
}

function Game::refreshClientScore(%clientId)
{
	%clientId.ratio = getEfficiencyRatio(%clientId);
	%team = Client::getTeam(%clientId);
   if(%team == -1) 
      %team = 9;

	Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.scoreKills @ "\t%p\t %l", %clientId.scoreKills + (9 - %team) * 10000);

	DMTEAM::missionObjectives();
}


function Mission::init()
{

	$timeLimitReached = "";
	$timereached = "";
	setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Kills\t\xCFPing\t\xEFPL");

	setTeamScoreHeading("Team Name\t\xC8Score");
	$numTeams = getNumTeams();
	for(%i = 0; %i < $numTeams; %i++) {
		$teamScore[%i] = 0;
		Team::setScore(%i, "%t\t0", %i);
	}

	DMTEAM::echoScores();
	$dieSeqCount = 0;
	AI::setupAI();
	DMTEAM::MissionObjectives();
	
}

