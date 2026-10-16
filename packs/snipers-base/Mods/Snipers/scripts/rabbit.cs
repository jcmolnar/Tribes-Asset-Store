exec("game.cs");
exec("admin.cs");
exec("serverPrefs.cs");

//  GAME PREFERENCES - adjust as desired
$Server::TeamDamageScale = 0; //team damage off unless voted on (Tourney Mode too)
function Rabbit::setJoinMOTD(){
   $Rabbit::JoinMOTD = "<Jc><f1>Kill the Rabbit!  <f1>by <f0>Eric Lanz<f1> & edited by <f0>King Shit{|XK|}\n" @
   "<Jc><f1>Press '<f2>O<f1>' for game objectives & rules.\n\n"
   @ $Server::JoinMOTD;
}

$Rabbit::oldTeamName0 = $Server::teamName0; //save old team info otherwise
$Rabbit::oldTeamName1 = $Server::teamName1; //not just Rabbit missions 
$Rabbit::oldTeamName2 = $Server::teamName2; //will use these
$Server::teamName0 = "Hunters";             //These get restored after 
$Server::teamName1 = "Plump Lil Bunny";     //Rabbit mission over
$Server::teamName2 = "Carrot";

$Rabbit::oldTeamSkin0 = $Server::teamSkin0;
$Rabbit::oldTeamSkin1 = $Server::teamSkin1;
$Rabbit::oldTeamSkin2 = $Server::teamSkin2;
$Server::teamSkin0 = "green";  //player team emblem
$Server::teamSkin1 = "orange";  //flag carrier team emblem
$Server::teamSkin2 = "orange";  //flag color/emblem

$spawnWeapon = "Disclauncher";  //equipment to spawn with & weapon to start with
$spawnBuyList[0] = DMArmor;
$spawnBuyList[1] = AmmoPack;
$spawnBuyList[2] = RepairKit;
$spawnBuyList[3] = LaserRifle;
$spawnBuyList[4] = SniperRifle;
$spawnBuyList[5] = Shotgun;
$spawnBuyList[6] = beacon;
$spawnBuyList[7] = beacon;
$spawnBuyList[8] = beacon;
$spawnBuyList[9] = MineAmmo;
$spawnBuyList[10] = MineAmmo;
$spawnBuyList[11] = MineAmmo;
$spawnBuyList[12] = Grenade;
$spawnBuyList[13] = Grenade;
$spawnBuyList[14] = Grenade;
$spawnBuyList[15] = "";

//Note - An existing game bug - Auto reload feature at stations
//gives player grenades regardless of whether allowed.  May also give player
//beacons and/or ammo, haven't tested.  In short, can't 
//keep players from getting grenades without further modification.
//Also, armor types only disallowable by rewriting function setupShoppingList
//since they are specifically added to the available items list.  May rewrite
//later...
$Rabbit::Item[0, ItemType] = Shotgun;  //items allowed, not allowed
$Rabbit::Item[0, allowed] = true;      //just adjust true/false field
$Rabbit::Item[0, displayName] = "Shotgun";

$Rabbit::Item[1, ItemType] = Railgun;
$Rabbit::Item[1, allowed] = true;
$Rabbit::Item[1, displayName] = "Railgun";

$Rabbit::Item[2, ItemType] = SniperRifle;
$Rabbit::Item[2, allowed] = true;
$Rabbit::Item[2, displayName] = "Sniper Rifle";

$Rabbit::Item[3, ItemType] = LaserRifle;
$Rabbit::Item[3, allowed] = true;
$Rabbit::Item[3, displayName] = "Laser Rifle";

$Rabbit::Item[4, ItemType] = AlienLaser;
$Rabbit::Item[4, allowed] = true;
$Rabbit::Item[4, displayName] = "Alien Laser";

$Rabbit::Item[5, ItemType] = HCRifle;
$Rabbit::Item[5, allowed] = true;
$Rabbit::Item[5, displayName] = "HCRifle";

$Rabbit::Item[6, ItemType] = TranqGun;
$Rabbit::Item[6, allowed] = true;
$Rabbit::Item[6, displayName] = "Tranq Gun";

$Rabbit::Item[7, ItemType] = HyperLaser;
$Rabbit::Item[7, allowed] = false;
$Rabbit::Item[7, displayName] = "Hyper Laser";

$Rabbit::Item[8, ItemType] = ELF;
$Rabbit::Item[8, allowed] = true;
$Rabbit::Item[8, displayName] = "ELF gun";

$Rabbit::Item[9, ItemType] = FlameRifle;  //see note above
 $Rabbit::Item[9, allowed] = false;
$Rabbit::Item[9, displayName] = "Flame Rifle";

$Rabbit::Item[10, ItemType] = ShockRifle;  //see note above
$Rabbit::Item[10, allowed] = true;
$Rabbit::Item[10, displayName] = "Shock Rifle";

$Rabbit::Item[11, ItemType] = TargetingLaser; 
$Rabbit::Item[11, allowed] = true;
$Rabbit::Item[11, displayName] = "TargetingLaser";

$Rabbit::Item[12, ItemType] = RepairRifle;
$Rabbit::Item[12, allowed] = false;
$Rabbit::Item[12, displayName] = "Repair Rifle";

$Rabbit::Item[13, ItemType] = CloakGun;
$Rabbit::Item[13, allowed] = true;
$Rabbit::Item[13, displayName] = "Cloak Gun";

$Rabbit::Item[14, ItemType] = AntiGrav;
$Rabbit::Item[14, allowed] = true;
$Rabbit::Item[14, displayName] = "Anti-Grav Gun";

$Rabbit::Item[15, ItemType] = SensorJammerPack;
$Rabbit::Item[15, allowed] = true;
$Rabbit::Item[15, displayName] = "Sensor Jammer Packs";

$Rabbit::Item[16, ItemType] = MineAmmo;
$Rabbit::Item[16, allowed] = true;
$Rabbit::Item[16, displayName] = "Mine";

$Rabbit::Item[17, ItemType] = Grenade;
$Rabbit::Item[17, allowed] = true;
$Rabbit::Item[17, displayName] = "Grenade";

$Rabbit::Item[18, ItemType] = Beacon;
$Rabbit::Item[18, allowed] = true;
$Rabbit::Item[18, displayName] = "Beacon";

$Rabbit::Item[19, ItemType] = RepairKit;
$Rabbit::Item[19, allowed] = true;
$Rabbit::Item[19, displayName] = "RepairKit";

$Rabbit::Item[20, ItemType] = Smoker;
$Rabbit::Item[20, allowed] = true;
$Rabbit::Item[20, displayName] = "Smoke bomb";

$Rabbit::Item[21, ItemType] = TreePack;
$Rabbit::Item[21, allowed] = true;
$Rabbit::Item[21, displayName] = "Seed Pack";

$Rabbit::Item[22, ItemType] = EnergyPack;
$Rabbit::Item[22, allowed] = true;
$Rabbit::Item[22, displayName] = "Energy Pack";

$Rabbit::Item[23, ItemType] = RepairPack;
$Rabbit::Item[23, allowed] = true;
$Rabbit::Item[23, displayName] = "Repair Pack";

$Rabbit::Item[24, ItemType] = ShieldPack;
$Rabbit::Item[24, allowed] = true;
$Rabbit::Item[24, displayName] = "Shield Pack";

$Rabbit::Item[25, ItemType] = SensorJammerPack;  //these here for kicks.  Armor types not disallowable this way.  They hardcoded into function.  Need to rewrite function setupShoppingList to specifically disallow
$Rabbit::Item[25, allowed] = true;
$Rabbit::Item[25, displayName] = "Sensor Jammer Pack";

$Rabbit::Item[26, ItemType] = AmmoPack;  //these here for kicks.  Armor types not disallowable this way.  They hardcoded into function.  Need to rewrite function setupShoppingList to specifically disallow
$Rabbit::Item[26, allowed] = true;
$Rabbit::Item[26, displayName] = "Ammo Pack";

$Rabbit::Item[27, ItemType] = LaserPack;  //these here for kicks.  Armor types not disallowable this way.  They hardcoded into function.  Need to rewrite function setupShoppingList to specifically disallow
$Rabbit::Item[27, allowed] = true;
$Rabbit::Item[27, displayName] = "Laser Pack";

$Rabbit::Item[28, ItemType] = MotionSensorPack;  //these here for kicks.  Armor types not disallowable this way.  They hardcoded into function.  Need to rewrite function setupShoppingList to specifically disallow
$Rabbit::Item[28, allowed] = true;
$Rabbit::Item[28, displayName] = "Motion Sensor Pack";

$Rabbit::Item[29, ItemType] = PulseSensorPack;
$Rabbit::Item[29, allowed] = true;
$Rabbit::Item[29, displayName] = "Pulse Sensor Pack";

$Rabbit::Item[30, ItemType] = DeployableSensorJammerPack;
$Rabbit::Item[30, allowed] = true;
$Rabbit::Item[30, displayName] = "Deployable Sensor JammerPack";

$Rabbit::Item[31, ItemType] = TurretPack;
$Rabbit::Item[31, allowed] = true;
$Rabbit::Item[31, displayName] = "Ion Turret Pack";

$Rabbit::Item[32, ItemType] = DeployableInvPack;
$Rabbit::Item[32, allowed] = true;
$Rabbit::Item[32, displayName] = "Deployable Inv Pack";

$Rabbit::Item[33, ItemType] = DeployableAmmoPack;
$Rabbit::Item[33, allowed] = true;
$Rabbit::Item[33, displayName] = "Deployable Ammo Pack";

$Rabbit::Item[34, ItemType] = BaseAlarm;
$Rabbit::Item[34, allowed] = true;
$Rabbit::Item[34, displayName] = "Base Alarm";

$Rabbit::Item[35, ItemType] = WatchdogPack;
$Rabbit::Item[35, allowed] = true;
$Rabbit::Item[35, displayName] = "Watchdog Pack";

$Rabbit::Item[36, ItemType] = MiniELF;
$Rabbit::Item[36, allowed] = true;
$Rabbit::Item[36, displayName] = "Mini ELF Turret";

$Rabbit::Item[37, ItemType] = RailTurret;
$Rabbit::Item[37, allowed] = true;
$Rabbit::Item[37, displayName] = "Rail Turret";

$Rabbit::Item[38, ItemType] = HoloPack;
$Rabbit::Item[38, allowed] = true;
$Rabbit::Item[38, displayName] = "HoloGram Pack";

$Rabbit::Item[39, ItemType] = DMarmor;
$Rabbit::Item[39, allowed] = false;
$Rabbit::Item[39, displayName] = "DMarmor";

$Rabbit::Item[40, ItemType] = EngineerArmor;
$Rabbit::Item[40, allowed] = true;
$Rabbit::Item[40, displayName] = "Engineer";

$Rabbit::Item[41, ItemType] = FlightArmor;
$Rabbit::Item[41, allowed] = false;
$Rabbit::Item[41, displayName] = "Flight Sniper";

$Rabbit::Item[42, ItemType] = LightArmor;
$Rabbit::Item[42, allowed] = true;
$Rabbit::Item[42, displayName] = "Light Sniper";

$Rabbit::Item[43, ItemType] = MediumArmor;
$Rabbit::Item[43, allowed] = true;
$Rabbit::Item[43, displayName] = "Medium Sniper";

$Rabbit::scoretimer = 5;  //how many seconds need to hold flag to score point (in seconds)
$flagReturnTime = 8;  //how long before dropped flag gets returned (in seconds)

//_______________________________________________________
//Initialize vars here - don't modify these
$Rabbit::banListCount = 0;  //used to create list of disallowed items
$Rabbit::LongestFlagHeld = 0;  //used to hold longest time flag held consecutively
$Rabbit::PlayerHoldingLongest ="";  //player who held flag longest consecutive time
$Rabbit::carrier = "";  //used to hold ID of current flag carrier
$Rabbit::lastToPassThrough = "";  //used to see who got last point for holding flag

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
         Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName($Rabbit::PlayerHoldingLongest) @ " with a time of " @ $Rabbit::LongestFlagHeld @ " seconds!");
      Team::setObjective(%l, %lineNum++, "<f1>     - Highest Score : " );
      Team::setObjective(%l, %lineNum++, "<L14><f5><Bskull_big.bmp>\n" @ Client::getName(%clientList[0]) @ " with a score of " @ (%clientList[0].score) @ "!");
      Team::setObjective(%l, %lineNum++, " " );
      Team::setObjective(%l, %lineNum++, "<f1>Player Name<L30>Kills<L40>Deaths<L55>Flag Grabs<L73>Avg Flag Held<L96>Score");
  
      for(%i = 0; %i < %numClients; %i++){
         %plyr = %clientList[%i];
         Team::setObjective(%l, %lineNum++, "<f1> - " @ Client::getName(%plyr) @ "<L32>" @ %plyr.scoreKills @ "<L43>" @ %plyr.scoreDeaths @ "<L61>" @ $Rabbit::PlyrFlagGrabs[%plyr] @ "<L78>" @ $Rabbit::PlyrAvgFlagHeld[%plyr] @ "<L98>" @ %plyr.score);
      }
      for(%s = %lineNum+1; %s < 30 ;%s++)	 //clear any previous remaining text
         Team::setObjective(%l, %s, " ");
   }
   $timeLimitReached = "";
   Rabbit::restoreServerDefaults();
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
         Team::setObjective(%l, %lineNum++, "<f1>  If you leave the mission area, you will take damage!");
         Team::setObjective(%l, %lineNum++, " ");
         Team::setObjective(%l, %lineNum++, "<f5>Weapons not allowed are : " );
         for (%x = 0; $Rabbit::banlist[%x] != ""; %x++){
               Team::setObjective(%l, %lineNum++, "<f1>   - " @ $Rabbit::banList[%x]);
         }
      for(%s = %lineNum+1; %s < 30 ;%s++)	 //clear any previous remaining text
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
      Game::refreshClientScore(%cl);
   }

   AI::setupAI();
   Rabbit::setJoinMOTD();
   Rabbit::invalidateItems();
   Rabbit::objectivesScreen();   
}

function Flag::onDrop(%player, %type){
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);
   %currentTime = getSimTime();

   if (%playerClient != $Rabbit::Carrier) 
      return;  //not sure why this function is called on every player death, but this to prevent erroneous flag drops

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
      schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
 
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


// modified to spawn/respawn player on team0, with custom skin.
function Game::playerSpawned(%pl, %clientId, %armor){	
   Rabbit::changeTeam(%clientId, 0);  //switch player to team 0
      
   %clientId.spawn= 1;
   for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
      buyItem(%clientId,%item);	
   %clientId.spawn= "";

   Player::useItem(%pl,$spawnWeapon);
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
      
   $Rabbit::Carrier.score += 1;
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
   Rabbit::validateItems();
   Rabbit::restoreTeamInfo();
}

function Rabbit::restoreTeamInfo(){  //Unfortunately I haven't figured out how to tell if the next mission will be a Rabbit mission or not, so this not used yet.
   $Server::teamName0 = $Rabbit::oldTeamName0;
   $Server::teamName1 = $Rabbit::oldTeamName1;
   $Server::teamName2 = $Rabbit::oldTeamName2;
   $Server::teamSkin0 = $Rabbit::oldTeamSkin0;
   $Server::teamSkin1 = $Rabbit::oldTeamSkin1;
   $Server::teamSkin2 = $Rabbit::oldTeamSkin2;
   $Server::JoinMOTD = $Rabbit::origJoinMOTD ; //replace old message of the day
}

function Rabbit::invalidateItems(){
   %count =0;
   for (%i = 0; $Rabbit::Item[%i, ItemType] != ""; %i++){
      if ($Rabbit::Item[%i, Allowed] != true){
         $invList[$Rabbit::Item[%i, ItemType]] = 0;
         $remoteInvList[$Rabbit::Item[%i, ItemType]] = 0;
         $ammoPackMax[$Rabbit::Item[%i, ItemType]] = 0;  //to stop players from getting these items via ammopack (circumvent game bug)  
         $Rabbit::banList[%count] = $Rabbit::Item[%i, DisplayName];
//         echo("DEBUG : Removing " @ $Rabbit::banList[%count]);
         %count++;
      }
   } 
   $Rabbit::banList[%count] = "";  //place blank entry at end of list to end        
}


function Rabbit::validateItems(){
   for (%i = 0; $Rabbit::Item[%i, ItemType] != ""; %i++){
      if ($Rabbit::Item[%i, Allowed] != true){
         $invList[$Rabbit::Item[%i, ItemType]] = 1;
         $remoteinvList[$Rabbit::Item[%i, ItemType]] = 1;
         // echo("DEBUG : Restoring " @ $Rabbit::Item[%i, displayName]);
      }
   } 
   $AmmoPackMax[BulletAmmo] = 150; //reset any $ammoPackMax values we might have changed in Rabbit::invalidateItems
   $AmmoPackMax[PlasmaAmmo] = 30;
   $AmmoPackMax[DiscAmmo] = 15;
   $AmmoPackMax[GrenadeAmmo] = 15;
   $AmmoPackMax[MortarAmmo] = 10;
   $AmmoPackMax[MineAmmo] = 5;
   $AmmoPackMax[Grenade] = 10;
   $AmmoPackMax[Beacon] = 10;
   exec("Objectives.cs");  //redefine Flag:: functions (and several others) in case next mission isn't Rabbit
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
      //cls();  remmed this so I could see the console
      echo("DEBUG : Server mission complete - changing to mission: ", %nextMission);
      // echo("DEBUG : Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
}


// modified this to remove the option for players to
// switch to any other team than team 0
function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(!SnipersPort::optAllowed(%clientId, %opt)) { Game::menuRequest(%clientId); return; }

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      if ($Game::MissionType == "Rabbit")
         Client::addMenuItem(%clientId, "1" @ getTeamName(0), 0);
      else{
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      }
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         if ($Game::MissionType == "Rabbit")
            Client::addMenuItem(%clientId, "1" @ getTeamName(0), 0);
         else{
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
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
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
         centerprint(%clientId, $Server::JoinMOTD, 0);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
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
}


echo("******* Rabbit.cs loaded successfully ********");

function Server::loadMission(%missionName, %immed)
{
	Rabbit::restoreServerDefaults();
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

function Rabbit::restoreServerDefaults()
{
    
   //restore some server variables
   //$Server::JoinMOTD = $Rabbit::origJoinMOTD;
   //$Server::teamName0 = $Rabbit::origTeamName0;
              
	exec(admin);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(ArmorData);
	exec(Item);
	exec(Player);
	exec(Vehicle);
	exec(Turret);
	exec(objectives);
	exec(server);
	exec(Station);
}