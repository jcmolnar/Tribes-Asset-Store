//
// AI support functions.
//

//
// This function creates an AI player using the supplied group of markers 
//    for locations.  The first marker in the group gives the starting location 
//    of the the AI, and the remaining markers specify the path to follow.  
//
// Example call:  
// 
//    createAI( guardNumberOne, "MissionGroup\\Teams\\team0\\guardPath", larmor );
//

//globals
//--------
// path type
// 0 = circular
// 1 = oneWay
// 2 = twoWay
$AI::defaultPathType = 2; //run twoWay paths

//armor types
//light = larmor
//medium = marmor
//heavy = harmor
$AI::defaultArmorType = "larmor";



//---------------------------------
//createAI()
//---------------------------------
function createAI( %aiName, %markerGroup, %armorType, %name, %targetc)
{
   %group =nameToID( %markerGroup );
  	
   if( %group == -1 || Group::objectCount(%group) == 0 )
   {
      dbecho(1, %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
      return -1;
   }
   else
   {
%sp = floor(getrandom() * (10-%num));
 %spawnMarker = Group::getObject(%group, %sp);
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);

      if( AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" ) != "false" )
      {
 // The order number is used for sorting waypoints, and other directives.  
        // %orderNumber = 100;
         
        // for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         //{
            %group2=nameToID( %targetc ); 
            %spawnMarker = Group::getObject(%group2, 1);
            %spawnPos = GameBase::getPosition(%spawnMarker);
           echo(%spawnPos);
            AI::DirectiveWaypoint( %aiName, %spawnPos, 1 ); //%spawnPos, %orderNumber
        
         //   %orderNumber += 100;
         //}
      
      }
      else{
         dbecho( 1, "Failure spawning: " @ %aiName );
      }
   }
}

//----------------------------------
// AI::setupAI()
//
// Called from Mission::init() which is defined in Objectives.cs (or Dm.cs for
//    deathmatch missions).  
//----------------------------------   
function AI::setupAI(%key, %team)
{
   //if there is no key then they don't exist yet
   if(%key == "")
   {
      %aiFound = 0;
      for( %T = 0; %T < 8; %T++ )
      {
         %groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI" );
         if( %groupId != -1 )
         {
            %teamItemCount = Group::objectCount(%groupId);
            if( %teamItemCount > 0 )
            {
               AI::initDrones(%T, %teamItemCount);
               %aiFound += %teamItemCount;
            }
         }
      }
      //check for Graph information
      if(nameToId("MissionGroup\\AIGraph") != -1)
      	AI::buildGraph();
      else
         echo("No Graph info to build AI Graph!");
      
      if( %aiFound == 0 )
         dbecho(1, "No drones exist...");
      else
         dbecho(1, %aiFound @ " drones installed..." );
   }
   else     //respawning dead AI with original name and path
   {
      %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %key);
      %num = Group::objectCount(%group);
      createAI(%key, %group, $AI::defaultArmorType, %key);
      %aiId = AI::getId(%key);
      GameBase::setTeam(%aiId, %team);
      AI::setVar(%key, pathType, $AI::defaultPathType);
      AI::setWeapons(%key);
      
   }		
}

//------------------------------
// AI::setWeapons()
//------------------------------
function AI::setWeapons(%aiName,%armor, %spawnPos)
{
	%aiId = AI::getId(%aiName);
	
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
    		 if(%armor==1){
			player::setItemCount(%aiId,RocketLauncher2sky,1);
			player::setItemCount(%aiId,EnergyRifle2,1);
			player::setItemCount(%aiId,StrikeAmmo,640);
			player::setItemCount(%aiId,money,230);
			player::mountItem(%aiId,RocketLauncher2sky,0);
		
			}
		if(%armor==2){
			player::setItemCount(%aiId,XLChaingun,1);
			player::setItemCount(%aiId,Bulletammo,999);
			player::setItemCount(%aiId,SM,1);
			player::setItemCount(%aiId,EnergyPack2,1);
			player::setItemCount(%aiId,money,230);
			player::mountItem(%aiId,EnergyPack2,1);
			player::mountItem(%aiId,XLChaingun,0);
		
			}
		if(%armor==3){
			player::setItemCount(%aiId,BlasterD,1);
			player::setItemCount(%aiId,SniperGun,1);
			player::setItemCount(%aiId,FlashPack,1);
			player::setItemCount(%aiId,money,230);
			player::mountItem(%aiId,FlashPack,1);
			player::mountItem(%aiId,BlasterD,0);
			
			}		
		if(%armor==4){
			player::setItemCount(%aiId,BlasterD,1);
			player::setItemCount(%aiId,SniperGun,1);
			player::setItemCount(%aiId,FlashPack,1);
			player::setItemCount(%aiId,money,230);
			player::mountItem(%aiId,PoisonPack,1);
			player::mountItem(%aiId,BlasterD,0);
			}
		if(%armor>4) {
			player::setItemCount(%aiId,LF,1);
			player::setItemCount(%aiId,EnergyRifle2,1);
			player::setItemCount(%aiId,MortarAmmo,640);
			player::setItemCount(%aiId,money,230);
			player::mountItem(%aiId,LF,0);
			}
   }
   

   AI::SetVar(%aiName, triggerPct, 0.93 );
   AI::setVar(%aiName, iq, 70 );
   AI::setVar(%aiName, attackMode, 1);
  AI::setAutomaticTargets( %aiName );
%seen=1;
 schedule("MoveBots(%AiID, %spawnPos);", 1);
   ai::callbackPeriodic(%aiName,2, ai::periodicWeaponChange);
}



//-----------------------------------
// AI::periodicWeaponChange()
//-----------------------------------
function ai::periodicWeaponChange(%aiName)
{
%xb=10;
%yb=5;

 %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
%xp=getWord(%ailoc, 0);
%yp=getWord(%ailoc, 1);
%zp=getWord(%ailoc, 2);

	dbecho(2, %aiName @ " thinking....");
   %aiId = AI::getId(%aiName);
   %curTarget = ai::getTarget( %aiName );
  
%armor = Player::getArmor(%aiID);

   if(%curTarget == -1)
   {
   	return;
   }
      

   %targetDist = Vector::getDistance(%aiLoc, %PPos);
   dbecho(2, "distance to target: " @ %targetDist @ " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);
   

 if(%targetDist < 30)
   {

%armor = Player::getArmor(%aiID);
if (%armor == "Tarmor")Player::mountItem(%aiId, "EnergyRifle2", 1);
if(%armor=="Sarmor")Player::mountItem(%aiId, "SM", 1);
if(%armor=="Warmor")Player::mountItem(%aiId, "SniperGun", 1);
if(%armor=="Warmor")Player::mountItem(%aiId, "BlasterD", 1);
if(%armor=="Aarmor")Player::mountItem(%aiId, "EnergyRifle2", 1);
%xb=10;
%yb=5;
AI::SetVar(%aiName, triggerPct, 0.8 );	
}   

if(%targetDist > 29)
   {
%armor = Player::getArmor(%aiID);
     %xb=20;
      %yb=15;
      if (%armor == "Tarmor")Player::mountItem(%AiID, "RocketLauncher2sky", 0);
if(%armor=="Sarmor")Player::mountItem(%aiId, "XLChaingun", 0);
if(%armor=="Warmor")Player::mountItem(%aiId, "BlasterD", 0);
if(%armor=="Warmor")Player::mountItem(%aiId, "SniperGun", 0);
if(%armor=="Aarmor")Player::mountItem(%aiId, "LF", 0);
      AI::SetVar(%aiName, triggerPct, 0.50 );
    }        
}

function MoveBots(%AiID,%spawnPos)
{
if(%idNum==0)
{
AI::DirectiveWaypoint( "HaCkBot",  %spawnPos,1);
AI::DirectiveWaypoint( "Pondering",  %spawnPos,1);
AI::DirectiveWaypoint( "Scott",  %spawnPos,1);
AI::DirectiveWaypoint( "HaCkEr",  %spawnPos,1);
AI::DirectiveWaypoint( "(>'.')>",  %spawnPos,1);
AI::DirectiveWaypoint( "DDR Freak",  %spawnPos,1);
AI::DirectiveWaypoint( "PingBurst", %spawnPos,1);
}
%PPos = GameBase::getPosition(%targetp);
   %xPosP = getWord(%PPos, 0) + floor(getRandom() * %xb);
   %yPosP = getword(%PPos, 1) + floor(getRandom() * %yb);
   %zPosP = getWord(%PPos, 2) + 2;
  %aiGOTO = %xPosP @ "  " @ %yPosP @ "  " @ %zPosP;

 %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
if(getWord( %aiLoc, 2)<-10)remoteKill(%aiId);
//I had two choices here...I could handle this with one line by switching out those names and doing %ainame...so each bot would be under different control......
//but....I liked the idea that if one bot sees you :) the others shall soon follow :)

AI::DirectiveWaypoint( "HaCkBot",  %AIGoto,1);
AI::DirectiveWaypoint( "Pondering",  %AIGoto,1);
AI::DirectiveWaypoint( "Scott",  %AIGoto,1);
AI::DirectiveWaypoint( "HaCkEr",  %AIGoto,1);
AI::DirectiveWaypoint( "(>'.')>",  %AIGoto,1);
AI::DirectiveWaypoint( "DDR Freak",  %AIGoto,1);
AI::DirectiveWaypoint( "PingBurst",  %AIGoto,1);
if (%seen==0)schedule("MoveBots();", 8);
if (%seen==1)schedule("MoveBots();", 1);
}


//these AI function callbacks can be very useful!
function AI::onTargetLOSAcquired(%aiName, %idNum)
{
$AI_Acq[0] = "I see you!!!";
$AI_Acq[1] = "Look who's on my radar....";
$AI_Acq[2] = "heheh here I come :)";
$AI_Acq[3] = "Guess who!!!";
$AI_Acq[4] = "Peek a boo!!!";
$AI_Acq[5] = "I spy with my little eye....";
$AI_Acq[6] = "-=Target Acquired=-";
$AI_Acq[7] = "Look who's on my radar....";
%which=Floor(getRandom()*6);
%ARandomNumber=floor(getRandom() * 6);
if(%ARandomNumber<3)messageall(2,%aiName @": "@ $AI_Acq[%which]);
AI::SetVar(%aiName, triggerPct, 0.8 );
echo(%idnum);
%targetp=%idNum;
if(%seen==0)
{  
  %seen=1;
schedule("MoveBots();", 1);
}
}



function AI::onTargetDied(%aiName, %idNum)
{
echo(%idnum);
$AI_Dead[0] = "Mission Complete";
$AI_Dead[1] = "That was too easy";
$AI_Dead[2] = "Worm food :)";
$AI_Dead[3] = "awww did that hurt :)";
$AI_Dead[4] = "I got dibs on his weapons :)";
$AI_Dead[5] = "I got dibs on his money";
$AI_Dead[6] = "-=Seeking new Target=-";
$AI_Dead[7] = "I got dibs on his weapons :)";
%which1=floor(getRandom() * 6);
%ARandomNumber=floor(getRandom() * 6);
if(%ARandomNumber<3)messageall(2,%aiName @": "@ $AI_Dead[%which1]);

AI::SetVar(%aiName, triggerPct, 0.0 );
if(%seen==1)
{  
  %seen=0;
schedule("MoveBots();", 1);
}
}                                 

function AI::onTargetLOSLost(%aiName, %idNum)
{
echo(%idnum);
$AI_Lost[0] = "Holy shit, he disappeared!!!!";
$AI_Lost[1] = "Shit my radar just went blank....";
$AI_Lost[2] = "Where did he go?";
$AI_Lost[3] ="He's gone!!!!";
$AI_Lost[4] = "You can run, and i guess you can probably hide...but....ergh";
$AI_Lost[5] = "Hiding makes the baby Jesus cry....";
$AI_Lost[6] = "-=Seeking Target=-";
$AI_Lost[7] = "You can run, and i guess you can probably hide...but....ergh";
%which2=floor(getRandom() * 6);
%ARandomNumber=floor(getRandom() * 6);
if(%ARandomNumber<4)messageall(2,%aiName @": "@ $AI_Lost[%which2]);
AI::SetVar(%aiName, triggerPct, 0.01 );
  if(%seen==1)
{  
  %seen=0;
schedule("MoveBots();", 1);
}
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
echo(%idnum);
$AI_Found[0] = "Thought you could hide :)";
$AI_Found[1] = "Don't run....I'm faster....";
$AI_Found[2] = "My radar always prevails...";
$AI_Found[3] ="There you are...";
$AI_Found[4] = "Welcome back...Friend :)";
$AI_Found[5] = "Time to kill....";
$AI_Found[6] = "-=Target Locked=-";
$AI_Found[7] = "Don't run....I'm faster....";
%which3=floor(getRandom() * 6);
%ARandomNumber=floor(getRandom() * 6);
if(%ARandomNumber<3)messageall(2,%aiName @": "@ $AI_Found[%which3]);
AI::SetVar(%aiName, triggerPct, 0.5 );
%targetp=%idNum;
  if(%seen==0)
{  
  %seen=1;
schedule("MoveBots();", 1);
}
}
//-----------------------------------
// AI::initDrones()
//-----------------------------------
function AI::initDrones(%team, %numAi)
{
	dbecho(1, "spawning team " @ %team @ " ai...");
   for(%guard = 0; %guard < %numAi; %guard++)
   {
      //check for internal data
      %tempSet = 	nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
      %tempItem = Group::getObject(%tempSet, %guard);
      %aiName = Object::getName(%tempItem);
      
      %set = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %aiName);
      %numPts = Group::objectCount(%set);
      
      if(%numPts > 0)
      {
         createAI(%aiName, %set, $AI::defaultArmorType, %aiName);
         %aiId = AI::getId( %aiName );
         GameBase::setTeam(%aiId, %team);
         AI::setVar( %aiName,  iq,  60 );
         AI::setVar( %aiName,  attackMode, 1);
         AI::setVar( %aiName,  pathType, $AI::defaultPathType);
      	schedule("AI::setWeapons(" @ %aiName @ ");", 1);
      }
      else
         dbecho(1, "no info to spawn ai...");
   }
}


//------------------------------------------------------------------
//functions to test and move AI players.
//
//------------------------------------------------------------------

//
//This function will spawn an AI player about 5 units away from the 
//player that is passed to the function(%commandIssuer).
//
//
$numAI = 0;
function AI::helper(%aiName, %armorType, %commandIssuer)
{
   %spawnMarker = GameBase::getPosition(%commandIssuer);
   %xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 15);
   %yPos = getword(%spawnMarker, 1) + floor(getRandom() * 10);
   %zPos = getWord(%spawnMarker, 2) + 2;
   %rPos = GameBase::getRotation(%commandIssuer);
   
   dbecho(2, "Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
   dbecho(2, "Current Issuer rotation: " @ %rPos);
      
   %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
   %newName = %aiName @ $numAI;
   $numAI++;
   Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos);
   return ( %newName );
}

//
//This function will move an AI player to the position of an object
//that the players LOS is hitting(terrain included). Must be `	within 50 units.
//
//
function AI::moveToLOS(%aiName, %commandIssuer) 
{
   %issuerRot = GameBase::getRotation(%commandIssuer);
   %playerObj = Client::getOwnedObject(%commandIssuer);
   %playerPos = GameBase::getPosition(%commandIssuer);
      
   //check within max dist
   if(GameBase::getLOSInfo(%playerObj, 100, %issuerRot))
   { 
      %newIssuedVec = $LOS::position;
	  %distance = Vector::getDistance(%playerPos, %newIssuedVec);
	  dbecho(2, "Command accepted, AI player(s) moving....");
	  dbecho(2, "distance to LOS: " @ %distance);
	  AI::DirectiveWaypoint( %aiName, %newIssuedVec, 1 );
   }
   else
      dbecho(2, "Distance to far.");
      
   dbecho(2, "LOS point: " @ $LOS::position);
}

//This function will move an AI player to a position directly in front of
//the player passed, at a distance that is specified.
function  AI::moveAhead(%aiName, %commandIssuer, %distance) 
{
   
   %issuerRot = GameBase::getRotation(%commandIssuer);
   %commPos  = GameBase::getPosition(%commandIssuer);
   dbecho(2, "Commanders Position: " @ %commPos);
   
   //get commanders x and y positions
   %comm_x = getWord(%commPos, 0);
   %comm_y = getWord(%commPos, 1);
   
   //get offset x and y positions
   %offSetPos = Vector::getFromRot(%issuerRot, %distance);
   %off_x = getWord(%offSetPos, 0);
   %off_y = getWord(%offSetPos, 1);
   
   //calc new position
   %new_x = %comm_x + %off_x;
   %new_y = %comm_y + %off_y;
   %newPos = %new_x  @ " " @ %new_y @ " 0";
  
   //move AI player
   dbecho(2, "AI moving to " @ %newPos);
   AI::DirectiveWaypoint(%aiName, %newPos, 1);
}  

//
// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//
function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{
   %aiId = AI::getId( %name );
   %T = GameBase::getTeam( %aiId );
   %groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI\\" @ %name ); 
  	%nodeCount = Group::objectCount( %groupId );
   dbecho(2, "checking drone information...." @ " number of nodes: " @ %nodeCount);
   dbecho(2, "AI id: " @ %aiId @ " groupId: " @ %groupId);
   
   if($SinglePlayer || %nodeCount == 1)
   {
	   if( %command == 2 || %command == 1 )
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  
	      %worldLoc = WaypointToWorld ( %waypoint );
	      AI::DirectiveWaypoint( %name, %worldLoc, 125 );
	      dbecho ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
	   }
	   dbecho( 2, "AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
	   dbecho( 3, "Cmdr:        " @ %commander );
	   dbecho( 3, "Command:     " @ %command );
	   dbecho( 3, "Waypoint:    " @ %waypoint );
	   dbecho( 3, "TargetId:    " @ %targetId );
	   dbecho( 3, "cmdText:     " @ %cmdText );
	   dbecho( 3, "cmdStatus:   " @ %cmdStatus );
	   dbecho( 3, "cmdSequence: " @ %cmdSequence );
   }
   else
   	return;   
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, 2049, cheer3 );
//
function Ai::soundHelper( %sourceId, %destId, %waveFileName )
{
   %wName = strcat( "~w", Client::getVoiceBase( %sourceId ) );
   %wName = strcat( %wName, ".w" );
   %wName = strcat( %wName, %waveFileName );
   %wName = strcat( %wName, ".wav" );
   
   dbecho( 2, "Trying to play " @ %wName );
   
   Client::sendMessage( %destId, 0, %wName );
}


// Default periodic callback.  [Note by default it isn't called unless a frequency 
//    is set up using AI::CallbackPeriodic().  Type in that command to see how 
//    it works].  
function AI::onPeriodic( %aiName )
{
   dbecho(2, "onPeriodic() called with " @ %aiName );
}


function AI::onDroneKilled(%aiName)
{
   if( ! $SinglePlayer )
   {
      %aiId = AI::getId(%aiName);
      %team = GameBase::getTeam(%aiId);
      dbecho(2, "AI Id: " @ %aiId);
      
      // Trying a little longer delay -
      schedule("AI::setupAI(" @ %aiName @ ", " @ %team @ ");", 8 );
   }
   else
   {
      // just in case:
      dbecho( 2, "Non training callback called from Training" );
   }
}


function AI::buildGraph(%argv)
{
	
   if(!%argv)
   {
	   echo("building AI Graph...");
	   $nodeGroup = nameToID("MissionGroup\\AIGraph");
	   %numNodes  = Group::ObjectCount($nodeGroup);
	   echo("nodeGroup: " @ %nodeGroup @ " number of Nodes: " @ %numNodes); 
   }
   else
   {
	   echo("rebuilding AI Graph...");
	   %numNodes  = Group::ObjectCount($nodeGroup);
   }
   
   for(%i = 0; %i < %numNodes; %i++)
   {
   	%node = Group::getObject($nodeGroup, %i);
      %nodePos = GameBase::getPosition(%node);
      %type = GameBase::getDataName(%node);
      %name = "Node " @ %i;
      Graph::AddNode(%nodePos, %name);
   }
   if(%numNodes > 0)	
   {   
      Graph::buildGraph();
      echo("Graph build complete.");
   }
   else
   	echo("No nodes to build graph.");
}


function AI::rebuildGraph()
{
	Graph::reset();
   AI::graphOff();
   focusServer();
   AI::buildGraph("true");
   focusClient();
   AI::GraphOn();
}


//Render lines to show AI Graph
$AI::testGraph = 0;
function AI::GraphOn(){
   if( $AI::testGraph == 0 ){
   	$AI::testGraph = newObject( "graphRender", AI::GraphPathRender );
      echo("Graph render on");
   }
   else{
      echo("Graph render ALREADY on");
   }
}
function AI::GraphOff(){
   if( $AI::testGraph != 0 ){
   	deleteObject( $AI::testGraph );
      $AI::testGraph = 0;
   	echo("Graph render off");
   }
   else{
      echo("Graph render ALREADY off");
   }
}


function AI::testingCommander()
{
   %clientId = "2049";
   AI::helper("ServerGod", Harmor, %clientId);
   %aiId = "2050";
   GameBase::setTeam(%aiId, 0);
   AI::callWithId(%aiId, Player::setItemCount, Mortar, 1);
	AI::callWithId(%aiId, Player::setItemCount, MortarAmmo, 10000);
   AI::callWithId(%aiId, Player::mountItem, mortar, 0);
   AI::DirectiveTargetLaser( %aiId, %clientId );
}