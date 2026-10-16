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
function createAI( %aiName, %markerGroup, %armorType, %name )
{
   %group = nameToID( %markerGroup );
   
   if( %group == -1 || Group::objectCount(%group) == 0 )
   {
      echo( %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
      return -1;
   }
   else
   {
      %spawnMarker = Group::getObject(%group, 0);
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);

      if( AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" ) != "false" )
      {
         // The order number is used for sorting waypoints, and other directives.  
         %orderNumber = 100;
         
         for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);
            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );
            
            %orderNumber += 100;
         }
      }
      else{
         echo( "Failure spawning: " @ %aiName );
      }
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
   
   
   echo("Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
   echo("Current Issuer rotation: " @ %rPos);
      
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
	  echo("Command accepted, AI player(s) moving....");
	  echo("distance to LOS: " @ %distance);
	  AI::DirectiveWaypoint( %aiName, %newIssuedVec, 1 );
   }
   else
      echo("Distance to far.");
	  echo("LOS point: " @ $LOS::position);
}

//This function will move an AI player to a position directly in front of
//the player passed, at a distance that is specified.
function  AI::moveAhead(%aiName, %commandIssuer, %distance) 
{
   
   %issuerRot = GameBase::getRotation(%commandIssuer);
   %commPos  = GameBase::getPosition(%commandIssuer);
   echo("Commanders Position: " @ %commPos);
   
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
   echo("AI moving to " @ %newPos);
   AI::DirectiveWaypoint(%aiName, %newPos, 1);
}  

//
// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//
function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{
   if( %command == 2 || %command == 1 )
   {
      // must convert waypoint location into world location.  waypoint location
      //    is given in range [0-1023, 0-1023].  
      %worldLoc = WaypointToWorld ( %waypoint );
      AI::DirectiveWaypoint( %name, %worldLoc, 125 );
      dbecho ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
   }
   dbecho ( 2, " AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
   dbecho ( 3, "    Cmdr:        " @ %commander );
   dbecho ( 3, "    Command:     " @ %command );
   dbecho ( 3, "    Waypoint:    " @ %waypoint );
   dbecho ( 3, "    TargetId:    " @ %targetId );
   dbecho ( 3, "    cmdText:     " @ %cmdText );
   dbecho ( 3, "    cmdStatus:   " @ %cmdStatus );
   dbecho ( 3, "    cmdSequence: " @ %cmdSequence );
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
//    name without voice base info (which it will grab for you from the source client Id).  
//
// Example:
//    Ai::soundHelp( 2051, 2049, cheer3 );
//
function Ai::soundHelper( %sourceId, %destId, %waveFileName )
{
   %wName = strcat( "~w", Client::getVoiceBase( %sourceId ) );
   %wName = strcat( %wName, ".w" );
   %wName = strcat( %wName, %waveFileName );
   %wName = strcat( %wName, ".wav" );
   
   dbecho( 1, "Trying to play " @ %wName );
   
   Client::sendMessage( %destId, 0, %wName );
}




//
//incomplete function that is only going to 
//be used for testing.
//
function AI::hunt(%commander) 
{
  %k = 0;
  
  
  %markerPos = GameBase::getPosition(%commander);
  
  %set = newObject("set",SimSet);
  %mask = $SimPlayerObjectType;
  %targets = containerBoxFillSet(%set,%mask,%markerPos,100,100,20,1);
  echo("Number of targets:" @ %targets);
  
  for(%i = 0; %i < %targets; %i++)
  {
    %lockedObj = Group::getObject(%set, %i);
    echo("Object locked:" @ %lockedObj);
    echo("checking for continuity...");
	
	if(Player::getClient(%lockedObj) == -1)
	  %lockedObj = Group::getObject(%set, %i++);
  }
  echo("finished with set so deleting...");
  deleteObject(%set);

  echo("Target = " @ %lockedObj);
  %target = Player::getClient(%lockedObj);
  AI::attack(%commander, %target);

}