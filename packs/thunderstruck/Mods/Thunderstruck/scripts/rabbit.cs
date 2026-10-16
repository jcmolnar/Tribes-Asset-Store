
exec("game.cs");

//_______________________________________________________
//Initialize vars here - don't modify these
$Rabbit::LongestFlagHeld = 0;  //used to hold longest time flag held consecutively
$Rabbit::PlayerHoldingLongest ="";  //player who held flag longest consecutive time
$Rabbit::carrier = "";  //used to hold ID of current flag carrier
$Rabbit::lastToPassThrough = "";  //used to see who got last point for holding flag

function Rabbit::setJoinMOTD(){
   $Rabbit::JoinMOTD = "<Jc><f1>Kill the Rabbit!  <f1>by <f0>Eric Lanz<f1> & edited by <f0>[HvC]NaTeDoGG\n" @
   "<Jc><f1>Press '<f2>O<f1>' for game objectives & rules.\n\n"
   @ $Server::JoinMOTD;
}

function Game::checkTimeLimit(){
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;
   if(!$Server::timeLimit){
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0){
      $timeLimitReached = true;
      Rabbit::objectivesScreen();
      Server::nextMission();
   }
   else{
   // wierdness here, usually overruns timelimit before ending
//      echo("DEBUG : checking time limit every  20 seconds " @ getSimtime());
      schedule("Game::checkTimeLimit();", 1);
      UpdateClientTimes(%curTimeLeft);
   }
}


function Rabbit::displayFinalScores(){
   Rabbit::FlagHeldCheck(); //see if a player still holding flag
   Rabbit::getAvgHolds();	 //get players' avg times
   Rabbit::getLongestFlag();	//get name and time of longest holder
   
   %numClients = getNumClients();                                  
   for(%i = 0 ; %i < %numClients ; %i++)                           
      %clientList[%i] = getClientByIndex(%i);                      
   %doIt = 1;                                                      
   while(%doIt == 1){                                              
      %doIt = "";                                                  
      for(%i= 0 ; %i < %numClients; %i++) {                        
         if((%clientList[%i]).score < (%clientList[%i+1]).score) { 
            %hold = %clientList[%i];                               
            %clientList[%i] = %clientList[%i+1];                   
            %clientList[%i+1]= %hold;                              
            %doIt=1;                                               
         }                                                         
      }                                                            
   }
   for(%l = -1; %l < 2 ; %l++) {
      %lineNum = 0;
      Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
	  Team::setObjective(%l, %lineNum++, "<f5>Mission Summary:");
      Team::setObjective(%l, %lineNum++, " " );
      Team::setObjective(%l, %lineNum++, "<f1>     - Longest Flag held by : " );
      if ($Rabbit::LongestFlagHeld == 0)
         Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\nHmmmm.  You'd better read the objectives again!");
      else
         Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName($Rabbit::PlayerHoldingLongest) @ "<f5> with a time of " @ $Rabbit::LongestFlagHeld @ " seconds!");
      Team::setObjective(%l, %lineNum++, "<f1>     - Highest Score : " );
      Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ " with a score of " @ (%clientList[0].score) @ "!");
      Team::setObjective(%l, %lineNum++, " " );
      Team::setObjective(%l, %lineNum++, "Player Name<L30>Kills<L40>Deaths<L55>Flag Grabs<L73>Avg Flag Held<L96>Score");
  
      for(%i = 0; %i < %numClients; %i++){
         %plyr = %clientList[%i];
         Team::setObjective(%l, %lineNum++, "<f1> - <f2>" @ Client::getName(%plyr) @ "<L32>" @ %plyr.scoreKills @ "<L43>" @ %plyr.scoreDeaths @ "<L61>" @ $Rabbit::PlyrFlagGrabs[%plyr] @ "<L78>" @ $Rabbit::PlyrAvgFlagHeld[%plyr] @ "<L98>" @ %plyr.score);
      }

      for(%s = %lineNum+1; %s < 30 ;%s++)	 //clear any previous remaining text
         Team::setObjective(%l, %s, " ");
   }
   $timeLimitReached = "";
}

function Rabbit::displayGameRules(){
   for(%l = -1; %l < 2 ; %l++) {		
      %lineNum = 0;
         Team::setObjective(%l, %lineNum, "<jc><B0,0:deathmatch1.bmp><B0,0:deathmatch2.bmp>");
         Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
         Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName); 
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives:");
         Team::setObjective(%l, %lineNum++, "<f1>  Grab the flag and run!  Make rabbit noises!");
         Team::setObjective(%l, %lineNum++, "<f1>   - Score 2 points for each flag grab.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Score 1 additional point for each " @ $Rabbit::scoretimer @ " seconds you retain the flag.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Score 1 Point for eliminating a flag carrier.");
         Team::setObjective(%l, %lineNum++, "<f1>   - Score 1 point for each pursuer you eliminate, when you are the flag carrier.");
         Team::setObjective(%l, %lineNum++, "<f1>  Do not attack your fellow hunters.");
         Team::setObjective(%l, %lineNum++, "<f1>  If you leave the mission area, you will take damage!");
         Team::setObjective(%l, %lineNum++, " ");
      for(%s = %lineNum+1; %s < 30 ;%s++)	
         Team::setObjective(%l, %s, " ");
   }
}


function Rabbit::objectivesScreen(){                                                           
   if ($timeLimitReached)
      Rabbit::displayFinalScores();
   else
      Rabbit::displayGameRules();
}


function Mission::init(){
   //  echo("DEBUG : MissionInit called");
   setClientScoreHeading ("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++)
   {
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
 
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %i + $firstObjectiveLine;
   }
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
	  %cl.trakTK = 0;
      Game::refreshClientScore(%cl);
   }

   AI::setupAI();
   Rabbit::setJoinMOTD();
   Rabbit::objectivesScreen();   
}

function Flag::onDrop(%player, %type){
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);
   %currentTime = getSimTime();

   $Rabbit::Carrier = "";
   %flagHeld = %currentTime - $Rabbit::FlagGrabTimeStamp[%playerClient];
   $Rabbit::PlyrTtlFlagHeld[%playerClient] += %flagHeld;
   if (%flagHeld > $Rabbit::PlyrLongestFlagHeld[%playerClient])
      $Rabbit::PlyrLongestFlagHeld[%playerclient] = %flagHeld;
   
   $Rabbit::FlagDropper = %playerClient;
   schedule("Rabbit::changeTeam($Rabbit::FlagDropper, 0);", 0.2);  //switch player to team 0 - delay it .2 secs so not counted as team kill
   $Rabbit::FlagLastTouched[%playerClient] = %currentTime;

   MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped the flag!");
   
   
   
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   %flag.dropFade = 1;

   if (%player.outArea != ""){
      Flag::checkReturn(%flag, %flag.pickupSequence);
      $Rabbit::FlagOutOfArea = 1;
   }
   else
      schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $Rabbit::flagReturnTime);
 
   Rabbit::clearWaypoint();
}



function Flag::checkReturn(%flag, %sequenceNum){
   if(%flag.pickupSequence == %sequenceNum){
      if(%flag.dropFade){ 
         GameBase::startFadeOut(%flag);
         %flag.dropFade= "";
         %flag.fadeOut= 1;
         schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
      }
      else {
         %flagTeam = 0;	//we want team 0 to receive the message
		 if ($Rabbit::FlagOutOfArea){
            TeamMessages(1, %flagteam, "The flag was dropped outside the mission area", -2, "", "The flag was dropped outside the mission area");
            TeamMessages(1, %flagteam, "and was returned to base.~wflagreturn.wav", -2, "", "and was returned to base.~wflagreturn.wav");
            $Rabbit::FlagOutOfArea = "";   
         }
		 else
            TeamMessages(1, %flagteam, "The flag was returned to base.~wflagreturn.wav", -2, "", "The flag was returned to base.~wflagreturn.wav");
         GameBase::setPosition(%flag, %flag.originalPosition);
         Item::setVelocity(%flag, "0 0 0");
         %flag.atHome = true;
         GameBase::startFadeIn(%flag);
         %flag.fadeOut= "";
      }
   }
}


function Flag::onCollision(%this, %object){
   if(getObjectType(%object) != "Player")
      return;
   if(%this.carrier != -1)
      return; // spurious collision
   if(Player::isAIControlled(%object))
   	return;   
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
   
   %currentTime = getSimTime();
   // 11 seconds before player can grab flag again after dropping it
   if ((%currentTime - $Rabbit::FlagLastTouched[%playerClient]) < 11){ 
      echo ("diff : " @ %currentTime - $Rabbit::FlagLastTouched[%playerClient]);
      return;
   }

      if(%object.carryFlag == ""){
         if(%object.outArea == "") {
            if(%this.holdingTeam == %playerTeam)
               return;
            
            // make sure that flag is not already held when the flag is touched by a player
            // remember, if flag isn't held, rabbitcarrier should be ""
            if ($Rabbit::carrier != ""){
               echo("DEBUG : Held flag touched by another player");
               return;
            }
     
            $Rabbit::FlagGrabTimeStamp[%playerClient] = %currentTime;
            $Rabbit::carrier = %playerClient;
            schedule("Rabbit::flagPointTimer();", $Rabbit::scoreTimer + 0.05);
            echo($Rabbit::carrier @ " grabbed the flag at - simtime : " @ getsimtime());
            Rabbit::WaypointToCarrier($Rabbit::carrier);
 
            %playerClient.score += 2; 
            $Rabbit::PlyrFlagGrabs[%playerClient] +=1;    
            Game::refreshClientScore(%playerClient);
            Rabbit::changeTeam(%playerClient, 1);  //switch player to team 1

            Player::setItemCount(%object, Flag, 1);
            Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
            Item::hide(%this, true);
            $flagAtHome[1] = false;
            %this.atHome = false;
            %this.carrier = %object;
            %this.pickupSequence++;
            %object.carryFlag = %this;
            if(%this.fadeOut) {
               GameBase::startFadeIn(%this);
               %this.fadeOut= "";
            }
            MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
            Client::sendMessage(%playerClient, 0, "~wmine_act.wav");
            Client::sendMessage(%playerClient, 1, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
         }
         else
            Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
     }
}


// modified this so the TAB score menu lists all players based
// on score rather than team then score.  Observers still last, but
// current flag holder stays in proper sort, regardless of fact that
// he is actually on another team.
function Game::refreshClientScore(%clientId){
   %team = Client::getTeam(%clientId);

   if(%team == -1) // observers go last.
      %team = 9;
   else
      %team = 0; //put all players on equal footing

   // objective mission sorts by team first.
   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
}


// switches player's team to whichever team is passed to it.  Also
// maintains player's custom skin.
function Rabbit::changeTeam(%playerId, %team)
{
   GameBase::setTeam(%playerId, %team); //switch team 
   Client::setSkin(%playerId, $Client::info[%playerId, 0]);  //use custom skin
}


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
   echo("DEBUG : checking player timeout " @ %player @ " " @ %seqCount);
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

// modified to spawn/respawn player on team0, with custom skin.
function Game::playerSpawned(%pl, %clientId, %armor){	
   Rabbit::changeTeam(%clientId, 0);  //switch player to team 0
      
   %clientId.spawn= 1;

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
	if($Rabbit::Inventories) {
		Player::setItemCount(%clientId,DeployableInvPack,1); 
		Player::mountItem(%pl,DeployableInvPack,$BackpackSlot); 
	}
	Player::useItem(%pl,Chaingun); 

	doneposs(%clientId);
	if(%clientId.dan == true) {			
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, Client::getOwnedObject(%clientId), 3, 3, 3);
	}

   %clientId.spawn= "";
	%clientId.safet = false;

   $Rabbit::FlagLastTouched[%clientID] = -30;  // set reset timestamp to allow player to grab flag
   Rabbit::resetWaypoint(%clientId);	
}


function Rabbit::flagPointTimer(){
   if ($Rabbit::lastToPassThrough == ""){
      Rabbit::InitNewFlagCarrier();
      return;
   }
   if ($Rabbit::Carrier != $Rabbit::lastToPassThrough){
      echo(Client::getName($Rabbit::LastToPassThrough) @ " is no longer Flag Carrier, no points awarded - simtime : " @ getsimTime());  
      $Rabbit::lastToPassThrough = "";
      return; //flag carrier changed, kill thread
   }
      
   $Rabbit::Carrier.score++;
   Game::refreshClientScore($Rabbit::Carrier);
   echo("DEBUG : Awarding Point to " @ Client::getName($Rabbit::Carrier) @ "simtime : " @ getsimtime());
   schedule ("Rabbit::flagPointTimer();", $Rabbit::scoreTimer);
}

function Rabbit::initNewFlagCarrier(){
    if ($Rabbit::Carrier ==""){
       echo("DEBUG : Oops!  Dropped it before function was called!  Killing thread.");
       return;
    }
    $Rabbit::lastToPassThrough = $Rabbit::Carrier;
    echo(Client::getName($Rabbit::carrier) @ " is the new flag carrier");
    Rabbit::FlagPointTimer();
}


// called when player joins a game, to reset any
// scores that are present.  This in case the player
// joining takes over the Client ID of a player who
// dropped during the curretn mission.
function Rabbit::JoinInit(%clientId){
   // init flagheldtime[clientId], flaggrabs[clientId]
//   echo("DEBUG : Rabbit::joinInit called");
   $Rabbit::PlyrFlagGrabs[%clientId] = 0;
   $Rabbit::PlyrLongestFlagHeld[%clientId] = 0;
   $Rabbit::PlyrAvgFlagHeld[%clientId] = 0;
   $Rabbit::PlyrTtlFlagHeld[%clientId] = 0;
   %clientId.trakTK = 0;
   Game::refreshClientScore(%clientId);
}


function Rabbit::resetWaypoint(%client){
   
   if (($Rabbit::Carrier != "") && (%client != $Rabbit::carrier)){      
      %carrier = $Rabbit::Carrier;
      %name = Client::getName(%carrier);
      issueTargCommand(%client, %client, 0,"Get the flag!  [" @ %name @ "]", %carrier);
      echo("DEBUG : Waypoint reset");
   }
   else
      echo("DEBUG : No Waypoint set");
}
   

function Rabbit::WaypointToCarrier(%carrier){
   %numclients = getNumClients();
   %name = Client::getName(%carrier);
   for (%i = 0; %i < %numclients; %i++){ 
      %client = getClientByIndex(%i);
      if (%client == $Rabbit::carrier)
         IssueTargCommand(%client, %client, 0, "Run! Silly rabbit!", %carrier - 2048);
      else       
         IssueTargCommand(%client, %client, 0, "Get the flag! " @ %name @ " has it!", %carrier - 2048);
   }
echo("DEBUG : Waypoint to carrier set " @ %client @ "  " @ %name @ "  " @ %carrier);
}


function Rabbit::clearWaypoint(){
   %numclients = getNumClients();
   %name = Client::getName(%carrier);
   for (%i = 0; %i < %numclients; %i++){ 
      %client = getClientByIndex(%i);  
      setCommandStatus(%client, 0, "The flag was dropped!");   
   }
   echo("DEBUG : Waypoint cleared");
}


// called when mission cycles to 
// see if a player is still holding flag 
// to capture time held & quit awarding points
function Rabbit::FlagHeldCheck(){
   if ($Rabbit::Carrier !=""){
         %plyr = $Rabbit::carrier;
         $Rabbit::Carrier = "";  
         %flagHeld = getSimTime() - $Rabbit::FlagGrabTimeStamp[%plyr];
         $Rabbit::PlyrTtlFlagHeld[%plyr] += %flagHeld;
         if (%flagHeld > $Rabbit::PlyrLongestFlagHeld[%plyr])
            $Rabbit::PlyrLongestFlagHeld[%plyr] = %flagHeld;      
   } 
}


// assign average time held for all players
// based on their (total time held / flag grabs)
function Rabbit::getAvgHolds(){
   %numClients = getNumClients();
   for (%z = 0; %z < %numClients; %z++){
      %plyr = getClientByIndex(%z);
      if ($Rabbit::PlyrTtlFlagHeld[%plyr] > 0) 
         $Rabbit::PlyrAvgFlagHeld[%plyr] = $Rabbit::PlyrTtlFlagHeld[%plyr] / $Rabbit::PlyrFlagGrabs[%plyr];
      else
         $Rabbit::PlyrAvgFlagHeld[%plyr] = 0;
   }
}
 

// check all clients, to see who held flag longest
function Rabbit::getLongestFlag(){
   %numClients = getNumClients();
   for (%z = 0; %z < %numClients; %z++){
     %plyr = getClientByIndex(%z);
      if ($Rabbit::PlyrLongestFlagHeld[%plyr] > $Rabbit::LongestFlagHeld){
         $Rabbit::PlayerHoldingLongest = %plyr;
         $Rabbit::LongestFlagHeld = $Rabbit::PlyrLongestFlagHeld[%plyr]; 
      }
   }
}

function Rabbit::restoreServerDefaults(){
   Rabbit::restoreTeamInfo();
}

function Rabbit::restoreTeamInfo(){  
}

function ObjectiveMission::initCheck(%object){
//   echo("DEBUG : ObjectiveMission::init called");
   if(GameBase::virtual(%object, objectiveInit))
      addToSet("MissionCleanup/ObjectivesSet", %object);
}


function Flag::objectiveInit(%this){
//   echo("DEBUG : Flag::ObjectiveInit called");
   %this.originalPosition = GameBase::getPosition(%this);
   %this.atHome = true;
   %this.pickupSequence = 0;
   %this.carrier = -1;
   %this.holdingTeam = -1;
   %this.holder = "";
   %this.enemyCaps = 0;
   %this.caps[0] = 0;
   %this.caps[1] = 0;
   %this.caps[2] = 0;
   %this.caps[3] = 0;
   %this.caps[4] = 0;
   %this.caps[5] = 0;
   %this.caps[6] = 0;
   %this.caps[7] = 0;
   $teamFlag[GameBase::getTeam(%this)] = %this;
   return true;
}



////////////////////////////////////////////////////////
// Altered Game functions used in other mission types //
////////////////////////////////////////////////////////
function remoteMissionChangeNotify(%serverManagerId, %nextMission)
{
   if(%serverManagerId == 2048)
   {
      //cls();
      echo("DEBUG : Server mission complete - changing to mission: ", %nextMission);
      // echo("DEBUG : Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
}

// modified this to disable the ability to switch to any team
// other than team 0, assign custom skin rather than team default,
// and added a call to my Rabbit::JoinInit function to reset residual scores
function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(Observer::isObserver(%clientId)) {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         GameBase::setTeam(%clientId, 0);
   }    
	doneposs(%clientId);
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1" @ getTeamName(0), 0);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Client::info[%ClientId, 0]);  //use custom skin
      
      if(%clientId.justConnected)
      {
         centerprint(%clientId, $Rabbit::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
		 ThunderStruck_joinGame(%clientId); 
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
      Rabbit::JoinInit(%clientId);
}


function Vote::changeMission(){
   $timeLimitReached = true;
   Rabbit::objectivesScreen();
   Rabbit::restoreServerDefaults();
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
   echo("GAME: " @ %killerId @ " \""@Client::getName(%killerId)@"\" killed " @ %playerId @ " \""@Client::getName(%playerId)@"\" " @ %damageType);
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

if (isTurret(%damageType)) {
	%t = "true";
	if(!$ThunderStruck::TurretKillMessages && !$ThunderStruck::TurretPoints) %killerId = 0;
} else {
	%t = "false";
}

%playerId.scoreDeaths++; 

if(!%killerId) { 
	if (%t) {
		if(%damageType == $MExplosionDamageType || %damageType == $AAExplosionDamageType) {
			messageAll(0, strcat(%victimName, " is killed by a rocket turret.")); 
		} else if(%damageType == $PDamageType) {
			messageAll(0, strcat(%victimName, " is killed by a plasma turret.")); 		
		} else if(%damageType == 30) {
			messageAll(0, strcat(%victimName, " is killed by an indoor turret.")); 		
		} else if(%damageType == $ElectricityTEDamageType) {
			messageAll(0, strcat(%victimName, " is killed by an elf turret.")); 		
		} else {
			messageAll(0, strcat(%victimName, " is killed by a turret.")); 
		}
	} else {
		if(%damageType == 6)
			messageAll(0, sprintf($deathMsg[27, %ridx], %playerGender, %victimName)); 
		else
			messageAll(0, %victimName@" dies."); 
	}
} else if(%killerId == %playerId) { 
	if(!%t) {
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender); 
	} else {
		%oopsMsg = %victimName @ " dies.";
	}
	messageAll(0, %oopsMsg); 
	%playerId.score--; 
} else { 
	if(!String::ICompare(Client::getGender(%killerId), "Male")) { 
		%killerGender = "his"; 
	} else { 
		%killerGender = "her"; 
	} 
	if(Client::getTeam(%killerId) == Client::getTeam(%playerId) && !%playerId.JustSpawned) { 
		messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " fellow hunter, ", %victimName), $DeathMessageMask); 
		Client::sendMessage(%client, 1, "You lose a point.~waccess_denied.wav");
		KTAG::trakTK(%killerId, 0);
		%killerId.score--; 
		Game::refreshClientScore(%killerId); 
	} else { 
		if((%t && $ThunderStruck::TurretKillMessages) || !%t) {
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender); 
		} else {
			if(%damageType == $MExplosionDamageType || %damageType == $AAExplosionDamageType) {
				%obitMsg = strcat(%victimName, " is killed by a rocket turret."); 
			} else if(%damageType == $PDamageType) {
				%obitMsg = strcat(%victimName, " is killed by a plasma turret."); 		
			} else if(%damageType == 30) {
				%obitMsg = strcat(%victimName, " is killed by an indoor turret."); 		
			} else if(%damageType == $ElectricityTEDamageType) {
				%obitMsg = strcat(%victimName, " is killed by an elf turret."); 		
			} else {
				%obitMsg = strcat(%victimName, " is killed by a turret."); 
			}
		}
		messageAll(0, %obitMsg); 

		if(!%t && !%playerId.JustSpawned) {
			%killerId.score++; 
			%killerId.scoreKills++;
			Game::refreshClientScore(%killerId); 
		}
	} 
} 

}

function KTAG::trakTK(%client, %mode)
{
	if (%mode == 0) {
		%client.trakTK++;
		echo(%client @ " TKs = " @ %client.trakTK);
		schedule("KTAG::trakTK(" @ %client @ ", 1);", 60);
	} else {
		%client.trakTK--;
	}
	if (%client.trakTK < 0) %client.trakTK = 0;
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

	Rabbit::restoreTeamInfo();

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

   exec(objectives);
   exec(player);
   exec(server);

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


function Server::nextMission(%replay)
{
if(%replay || $Server::TourneyMode){
	%nextMission = $missionName;
} else {
	if(getNumClients() < 2 || $ThunderStruck::RandomMissionTypes["Kill the Rabbit"]) {
		doNextRand();
		return;
	}
	echo("Selecting a mission...");
	%l = 0; %goodmtype = 0;
	while(%goodmtype != "Kill the Rabbit" && %l < 5000) {
		%rnd = floor(getRandom() * $TotalMissions);
		if ($MissionName != $TotalMissionList[%rnd]) {
			%nextMission = $TotalMissionList[%rnd];
			$pref::LastMission = $TotalMissionList[%rnd];
		}			  
		%goodmtype = $ThunderStruck::MType[%nextMission];
		%l = %l + 1;
	}
	if(%l < 5000) {
		echo("A random Rabbit mission has been selected.");
		messageall(0, "A random Rabbit mission is being selected...");
		messageall(0, "Changing to mission "@%nextMission@" ("@$ThunderStruck::MType[%nextMission]@").");
	} else {
		echo("No other Rabbit missions found!");
		echo("Using default next mission.");
		%nextMission = $nextMission[$missionName];
	}
}

   echo("Changing to mission ", %nextMission, ".");
   
   Server::loadMission(%nextMission);
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object) { 
	%damagedClient = Player::getClient(%this); 
	%damName = Client::getName(%damagedClient);

//	messageall(0, "%vertPos="@%vertPos@"  %quadrant="@%quadrant);

	if($Hologram[%damName] != "") {
		%t = isTurret(%type) || (%type == 6 && !%shooterClient);
		if(%t) %value *= 3;
		%dlevel = GameBase::getDamageLevel(%this) + %value;
		if(%dlevel >= Player::getArmor(%this).maxDamage) playNextAnim(%this); 
		GameBase::setDamageLevel(%this,%dlevel);
		return;
	}

	if(%damagedClient.dumbass) %value *= 2;

	if (!Player::isExposed(%this)) return; 

	%damagedTeam = Client::getTeam(%damagedClient);
	%shooterClient = %object; 
	%shooterTeam = Client::getTeam(%shooterClient);
	%shootName = Client::getName(%shooterClient);

	if (%damagedTeam == %shooterTeam && %type == $TracDamageType)
		%mom = "0 0 0";

	if (%damagedClient == %shooterClient) {
		if (Player::getMountedItem(%shooterClient,$WeaponSlot) == WaveGun) {
			%x = getword(%mom, 0) * 0.3;
			%y = getword(%mom, 1) * 0.3;
			%z = getword(%mom, 2) * 0.3;
			%mom = %x @ " " @ %y @ " " @ %z;
		} else if (%type == $ExplosionDamageType) {
			%x = getword(%mom, 0) * 0.45;
			%y = getword(%mom, 1) * 0.45;
			%z = getword(%mom, 2) * 0.45;
			%mom = %x @ " " @ %y @ " " @ %z;
		}
	} else if (%type == $TracDamageType && Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") {
		%x = getword(%mom, 0) * 0.15;
		%y = getword(%mom, 1) * 0.15;
		%z = getword(%mom, 2) * 0.15;
		%mom = %x @ " " @ %y @ " " @ %z;
	}

	if(%type == 91) {
		%shooterTeam = GameBase::getTeam(%object);
		if(%shooterTeam == %damagedTeam) return;		
		teamMessages(0, %shooterTeam, "The Base Alarm has detected "@%damName@".~wmine_act.wav", "", "", "");
		return;
	}

	if(%type == 999) {
		if(GameBase::getTeam(%object) != %damagedTeam) return;
		%dlevel = GameBase::getDamageLevel(%this) - %value;
		if(%dlevel < 0) %dlevel = 0;
		GameBase::setDamageLevel(%this, %dlevel);
		return;
	}

	%name = GameBase::getDataName(%shooterClient);
	if(getObjectType(%object) == "Flier") { 
		if(%name.shapefile == "rocket" && $Server::TeamDamageScale == 0) {
			GameBase::setDamageLevel(%object, 1000); 
			%shooterTeam = GameBase::getTeam(%object);
			if(%damagedTeam == %shooterTeam) return;
		} else if(%name.shapefile == "discb" || %name.shapefile == "remoteturret") return;
	}		

	%t = (isTurret(%type) || (%type == 6 && !%shooterClient));

	if($teamplay && %damagedClient != %shooterClient && %shooterClient != -1 && %damagedTeam == %shooterTeam){
		if(%this.inStation && %mom != 0 && %this == Station::getTarget(%this.inStation) && ((%t && Client::getOwnedObject(%shooterClient).CommandTag == 1) || !%t)) {
			Client::sendMessage(%shooterClient,0,"Shooting teammates from stations is not allowed.~waccess_denied.wav");
		} else {
			Player::applyImpulse(%this,%mom); 
		}
		%curTime = getSimTime(); 
		if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && $Server::TeamDamageScale > 0) {
			if((%t && Client::getOwnedObject(%shooterClient).CommandTag == 1) || !%t) {
				if(%type == $ElectricityDamageType || %type == $ElectricityTEDamageType || %type == $ElectricityEDamageType || %type == $ElectricityLEDamageType) {
					if(!%shooterClient.ELFhit) {
						%shooterClient.ELFhit = true;
						schedule(%shooterClient @ ".ELFhit = false;",10);
						Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ "!");
						Client::sendMessage(%damagedClient,0,"You took friendly fire from " @ %shootName @ "!");
					}
				} else if (%type == $MineDamageType) {
					Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ " with your mine!");
					Client::sendMessage(%damagedClient,0,"You stepped on " @ %shootName @ "'s mine!");
				} else {
					Client::sendMessage(%shooterClient,0,"You just harmed teammate " @ %damName @ "!");
					Client::sendMessage(%damagedClient,0,"You took friendly fire from " @ %shootName @ "!");
				}
				%this.LastHarm = %shooterClient;
				%this.DamageStamp = %curTime;
			} 
		}
		%friendFire = $Server::TeamDamageScale;
	} else {
		Player::applyImpulse(%this,%mom); 
		if((%type == $ImpactDamageType || %type == $MissileRamDamageType) && Client::getTeam(%object.clLastMount) == %damagedTeam) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	
	}

	if (Player::isDead(%this)) return;

	%armor = Player::getArmor(%this);

	if (%type != -1 && %this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		if (%type == $RailDamageType) {
			%energy = 0;
			GameBase::getEnergy(%this, 0);
			%value *= 2.8;
		}
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
		} else {
			GameBase::setEnergy(%this,0);
			%value = %value - %absorb;
		}
	}
	if(%type == $ShotgunDamageType && !%this.inStation)
		Player::applyImpulse(%this,ixDotProd(%vec,0.075)); 
	else if(%type == $BlindDamageType) {
		ThunderStruckBlind(%damagedClient, %this);
		%value = 0;
	} else if(%type == $BurnDamageType || %type == $BurnEDamageType)
		ThunderStruck_startBurn(%damagedClient, %this, 12);
	else if (%type == $EMPDamageType) 
		ixStartEMP(%damagedClient, %this, %shooterClient, %type); 
	else if (%type == $EngineerEMPDamageType && %armor != "earmor" && %armor != "efemale")
		ixStartEMP(%damagedClient, %this, %shooterClient, %type); 
	else if(%type == $FlashDamageType) 
		Shock_Damage(%damagedClient, %this); 
	else if (%type == $PlasmaDamageType && %damagedTeam != %shooterTeam) { 
		if(floor(getRandom() * 10) > 5) { 
			if (%armor != "barmor" && %armor != "bfemale" && %armor != "darmor" && %armor != "harmor") 
				ThunderStruck_startBurn(%damagedClient, %this, 6); 
		} 
	} else if (%type == $EnergyDamageType) {
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1)
			if(!%this.shieldStrength || Player::getMountedItem(%player,$BackpackSlot) == "StealthShieldPack")
				ThunderStruck_startBlind(%damagedClient, %this, 10);
	} else if (%type == $SuperEnergyDamageType) {
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1)
			ThunderStruck_startBlind(%damagedClient, %this, 60);
	} else if (%type == $SmallEnergyDamageType)
		if(%damagedTeam != %shooterTeam || %shooterClient == %damagedClient || $Server::TeamDamageScale == 1)
			ThunderStruck_startBlind(%damagedClient, %this, 10);

	if (!%value) return;

	if((%type == $LaserDamageType || %type == $SniperDamageType)) { 
		if (%vertPos == "head") { 
			if (%type != $SniperDamageType) 
				%value *= 0.9;
			else
				%value *= 1.11;
		} else {
			if (%type != $SniperDamageType) 
				%value *= 0.6; 
			else
				%value *= 0.53; 
		}
	}
	
	%weaponType = Player::getMountedItem(%this,$WeaponSlot); 
	%dis = 0;
	if (%type == $LaserDamageType)
		%dis = 18;
	else if (%type == $SniperDamageType)
		%dis = 14;
	else if (%type == $RailDamageType)
		%dis = 20;
	if(%dis > 0 && %damagedTeam != %shooterTeam) {
		if (%value > 0.25) {
			if (%vertPos == "torso" && %quadrant == "front_right" && %weaponType != -1 && %weaponType != "RepairGun" && %weaponType != "PowerGun") { 
				%obj = newObject("","Item",%weaponType,1,false);
			  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			 	addToSet("MissionCleanup", %obj);
				if(%t)
					%msg = "A laser turret";
				else {
					%msg = %shootName;
					Client::sendMessage(%shooterClient, 0, "You shot the " @ %weaponType.description @ " out of "  @ %damName @ "'s hand!");
				}
				Client::sendMessage(%damagedClient, 0, %msg @ " shot the " @ %weaponType.description @ " out of your hand!");
				GameBase::throw(%obj, %damagedClient, %dis, true);
				Player::decItemCount(%damagedClient,%weaponType,1);
				%dlevel = GameBase::getDamageLevel(%this) + 0.065; 
			}
		}
	}

	if(!%dlevel) {
		%value = $DamageScale[%armor, %type] * %value * %friendFire;
		%dlevel = GameBase::getDamageLevel(%this) + %value; 
	}

	%spillOver = %dlevel - %armor.maxDamage; 

	GameBase::setDamageLevel(%this,%dlevel);
	%flash = Player::getDamageFlash(%this) + %value * 2;
	if (%flash > 0.75) %flash = 0.75;
	Player::setDamageFlash(%this,%flash);

	if($Server::TeamDamageScale > 0 && %damagedClient != %shooterClient) {
		if(%shooterClient.trakTK > 0 && %damagedClient != $Rabbit::carrier) {
			%f = Client::getOwnedObject(%object);
			if(%shooterClient.trakTK == 1)
				%eyedlevel = GameBase::getDamageLevel(%f) + (%value*0.5);
			else if(%shooterClient.trakTK > 2)
				%eyedlevel = GameBase::getDamageLevel(%f) + (%value*2);
			else
				%eyedlevel = GameBase::getDamageLevel(%f) + %value;							
			if(%eyedlevel >= (Player::getArmor(%f)).maxDamage) {
				MessageAllExcept(%shooterClient, 1, %shootName @ " has been killed for not following the rules.");
				Client::sendMessage(%shooterClient,1,"You may only attack the player with the flag!~wError_Message.wav"); 
				centerprint(%shooterClient,"<jc><f2>You may only attack the player with the flag!",8); 
				playNextAnim(%shooterClient); 
				Player::kill(%shooterClient); 
				Client::onKilled(%shooterClient, %shooterClient);
			} else {
				GameBase::setDamageLevel(%f, %eyedlevel);
				Client::sendMessage(%shooterClient,1,"You may only attack the player with the flag!"); 
			}
			%flash = Player::getDamageFlash(%object) + %value * 2;
			if (%flash > 0.75) 
				%flash = 0.75;
			Player::setDamageFlash(%object,%flash);
		}
	}
	if(!Player::isDead(%this)) { 
		if(%damagedClient.lastDamage < getSimTime()) {
			%sound = radnomItems(3,injure1,injure2,injure3);
			playVoice(%damagedClient,%sound);
			%damagedClient.lastdamage = getSimTime() + 1.5;
		}
	} else {
       	if((%spillOver > 0.5 && (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MExplosionDamageType)) || %type == $ElectricityDamageType || %type == $ElectricityEDamageType || %type == $ElectricityTEDamageType || %type == $ElectricityLEDamageType) {
 			Player::trigger(%this, $WeaponSlot, false);
			%weaponType = Player::getMountedItem(%this,$WeaponSlot);
			if(%weaponType != -1)
				Player::dropItem(%this,%weaponType);
			playSound(debrisLargeExp1osion,GameBase::getPosition(%this));
			Player::blowUp(%this);
		} else {
			if ((%value > 0.4 && (%type == $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
		  		if(%quadrant == "front_left" || %quadrant == "front_right") 
					%curDie = $PlayerAnim::DieBlownBack;
				else
					%curDie = $PlayerAnim::DieForward;
			} else if(Player::isCrouching(%this)) 
				%curDie = $PlayerAnim::Crouching;							
			else if(%vertPos == "head") {
				if(%quadrant == "front_left" ||	%quadrant == "front_right") 
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
			  	else 
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
			} else if (%vertPos == "torso") {
				if(%quadrant == "front_left" ) 
					%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "front_right") 
					%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
				else if(%quadrant == "back_left" ) 
					%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "back_right") 
					%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
			} else if (%vertPos == "legs") {
				if(%quadrant == "front_left" ||	%quadrant == "back_left") 
					%curDie = $PlayerAnim::DieLegLeft;
				else if(%quadrant == "front_right" || %quadrant == "back_right") 
					%curDie = $PlayerAnim::DieLegRight;
			}
			Player::setAnimation(%this, %curDie);
		}
		if((%type == $ImpactDamageType || %type == $MissileRamDamageType) && %object.clLastMount != "")  
			%shooterClient = %object.clLastMount;
		Client::onKilled(%damagedClient, %shooterClient, %type);
	}
}

function remoteKill(%client) {
   if(!$matchStarted || %client.permap || %client.dan)
      return;

	if(%client.possessing) {
		(%client.poss).free = true;
		remoteKill(%client.poss);
		return;
	}
	if(%client.possessed && !%client.free) {
		Client::sendMessage(%client, 0, "You cannot kill yourself while possessed.~waccess_denied.wav");
		return;
	}
	%cl.free = false;
   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) {
			Player::unmountItem(%player,$BackpackSlot); 
			%obj = newObject("","Mine","Suicidebomb"); 
			addToSet("MissionCleanup", %obj); 
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false); 
		}
		playNextAnim(%client);
		Player::kill(%client);
		Client::onKilled(%client,%client);
	}
}

echo("******* Rabbit.cs loaded successfully ********");