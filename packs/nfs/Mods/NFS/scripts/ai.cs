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
//modified by Werewolf
function createAI( %aiName, %markerGroup, %armorType, %name )
{
   %group = nameToID( %markerGroup );
   %voice = "male2";
   if( %group == -1 || Group::objectCount(%group) == 0 )
   {
      dbecho(1, %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
      return -1;
   }
   else
   {
      %spawnMarker = Group::getObject(%group, 0);

//      %spawnMarker = AI::pickRandomSpawn(%team); //Much more convenient

      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);

    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
      {
      $AI::defaultArmorType = "lfemale";
      %voice = "female2";
      }
      else
      {
      $AI::defaultArmorType = "larmor";
      %voice = "male2";
      }

    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "harmor";
      %voice = "female5";
      }
      else
      {
      $AI::defaultArmorType = "harmor";
      %voice = "male5";
      }
    }


    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "mfemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "marmor";
      %voice = "female2";
      }
    }


      if( AI::spawn( %aiName, $AI::defaultArmorType, %spawnPos, %spawnRot, %aiName, %voice ) != "false" )
      {

         $Spoonbot::NumBots = $Spoonbot::NumBots + 1;
         schedule("AI::RoamingBotsStartup(" @ %aiName @ ");", 2);    //If it's a roaming bot, select a new target to attack.
         // The order number is used for sorting waypoints, and other directives.
         // Set to two so it won't fuck up my precious chasing code :-P
         %orderNumber = 2;
         
         for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);

            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );
            
//            %orderNumber++;
         }
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
//modified by Werewolf
function AI::setupAI(%key, %team)
{


    %aiName = %key;

    if (%aiName == "")
     {
      return;
     }

    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
      {
      $AI::defaultArmorType = "lfemale";
      %voice = "female2";
      }
      else
      {
      $AI::defaultArmorType = "larmor";
      %voice = "male2";
      }


    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "harmor";
      %voice = "female5";
      }
      else
      {
      $AI::defaultArmorType = "harmor";
      %voice = "male5";
      }
    }


    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "mfemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "marmor";
      %voice = "female2";
      }
    }


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
      if( %aiFound == 0 )
         dbecho(1, "No drones exist in map...");
      else
         dbecho(1, %aiFound @ " drones installed..." );
   }
   else     //respawning dead AI with original name and path
   {
      %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %key);
      %num = Group::objectCount(%group);
      %aiId = AI::getId(%key);

      if( %aiId <= 0) // Is it a pre-defined AI, or a dynamically spawned? If it is the latter, then...
      {
         %teamnum = %team;
         %newName = %key;



// New method for finding spawn points:
//------------------------------------
   %spawnMarker = AI::pickRandomSpawn(%teamnum);
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



         %xPos = getWord(%spawnPos, 0);
         %yPos = getword(%spawnPos, 1);
         %zPos = getWord(%spawnPos, 2);
//         %rPos = GameBase::getRotation(%commandIssuer);
         %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;

//         dbecho(1, "Random Spawn Position is: " @ %xPos @ "  " @ %yPos @ "  " @ %zPos);


         Ai::spawn(%newName, $AI::defaultArmorType, %aiSpawnPos, %spawnRot, %newName, %voice );
         schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.

         $Spoonbot::NumBots = $Spoonbot::NumBots + 1;

         %aiId = AI::getId( %newName );
         GameBase::setTeam(%aiId, %teamnum);
         AI::setVar( %newName,  iq,  $Spoonbot::IQ );
         AI::setVar( %newName,  attackMode, 1);
         AI::setVar( %newName,  pathType, $AI::defaultPathType);
         AI::DirectiveWaypoint( %newName, %aiSpawnPos, 2, 2);
         schedule("AI::setWeapons(" @ %newName @ ");", 1);
         
      }
      //--------------------------------------------


      else  //else respawn like regular AIs
      {


      createAI(%key, %group, $AI::defaultArmorType, %key);
      %aiId = AI::getId(%key);


      GameBase::setTeam(%aiId, %team);
      AI::setVar(%key, pathType, $AI::defaultPathType);
      AI::setWeapons(%key);

   }
  }	
}

//------------------------------
// AI::setWeapons()
//------------------------------
//modified by Werewolf
function AI::setWeapons(%aiName)
{
	%aiId = AI::getId(%aiName);



//In case some moron ignorant mapmaker (just kidding ;-)) forgot to name the bots according to the readme,
//they'll spawn with the ugly-useless standard weapons.
//by Werewolf

   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, chaingun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, bulletAmmo, 50000);
   }
   Player::mountItem(%aiId, blaster, 0);


//Now comes the hard part: Check if the AI name contains various keywords
//(Guard, Sniper... Female... etc.) and set armor/weapons accordingly.
//by Werewolf

 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
   AI::setVar(%aiName, iq, $Spoonbot::IQ );
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
      Player::mountItem(%aiId, blaster, 0);
   }
   else
   {

//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, mortar, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 500);
   Player::mountItem(%aiId, mortar, 0);
   }
 }



 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
   Player::mountItem(%aiId, plasmaGun, 0);
   }
 }



 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   AI::setVar(%aiName, iq, $Spoonbot::IQ );
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Uses the default weapons, so don't remove anything
// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, targetinglaser, 1);
   Player::mountItem(%aiId, targetinglaser, 0);
   }
 }



 if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   AI::setVar(%aiName, iq, $Spoonbot::IQ );
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, laserrifle, 1);
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
   Player::mountItem(%aiId, laserrifle, 0);
   }
 }



 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   AI::setVar(%aiName, iq, $Spoonbot::IQ );
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Uses the default weapons, so don't remove anything
// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, repairkit, 1);
   Player::mountItem(%aiId, repairkit, 0);
   }
 }




 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   AI::setVar(%aiName, iq, $Spoonbot::IQ );
   if(Game::missionType == "DM")
   {	
//      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
//      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, mineammo, 10);
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
   Player::mountItem(%aiId, disclauncher, 0);
   }
 }



   AI::SetVar(%aiName, triggerPct, 0.03 );
   AI::setVar(%aiName, attackMode, 1);
   AI::setAutomaticTargets( %aiName );
   ai::callbackPeriodic(%aiName, $Spoonbot::ThinkingInterval, ai::periodicWeaponChange);



}


//-----------------------------------
// AI::periodicWeaponChange()
//-----------------------------------
//modified by Werewolf
function ai::periodicWeaponChange(%aiName)
{

   %aiId = AI::getId(%aiName);

   if(!String::findSubStr(%aiName, "Roam") >= 0)
	{
	   AI::checkForPaint(%aiName);
	}

   AI::checkObstacle(%aiId);  //Check if we're stuck somwhere

//   AI::RoamingBotsStartup(%aiName);    //If it's a roaming bot, select a new target to attack.

   //Check which weapon to use, according to bot class and situation (Jetting, not jetting, enemy near or far away)
   //modified by Werewolf

   %curTarget = ai::getTarget( %aiName );
   
   if(%curTarget == -1)
   {
   	return;
   }
      
   // Constantly Updating enemy position (if in sight)

//   dbecho(1, %aiName @ " target: " @ %curTarget);	
   
   %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %targetDist = Vector::getDistance(%aiLoc, %targLoc);
//   dbecho(2, "distance to target: " @ %targetDist @ " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);
                  


   if(%targetDist > 100)
   {
   	Player::mountItem(%aiId, blaster, 0);
      AI::SetVar(%aiName, triggerPct, 0.03 );
   }   
   else
   {
//      dbecho(2, "checking for target jet...");
//      dbecho(2, "jetting? " @ Player::isJetting(%curTarget));
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, Chaingun, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, disclauncher, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   
   }



 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
	 Player::mountItem(%aiId, mortar, 0);
	 AI::SetVar(%aiName, triggerPct, 100 );
 }




 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
   if(%targetDist > 100)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
	Player::mountItem(%aiId, plasmagun, 0);
	AI::SetVar(%aiName, triggerPct, 0.5 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, grenadelauncher, 0);  
         AI::SetVar(%aiName, triggerPct, 1 );
      }   
   }
  }



 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   if(%targetDist > 20)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, targetinglaser, 0);
         AI::SetVar(%aiName, triggerPct, 100 );
      }
      else
      {
	Player::mountItem(%aiId, targetinglaser, 0);
	AI::SetVar(%aiName, triggerPct, 100 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, chaingun, 0);
         AI::SetVar(%aiName, triggerPct, 0.3 );
      }
      else
      {
         Player::mountItem(%aiId, blaster, 0);  
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }   
   }
  }



 if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   Player::setDetectParameters(%aiId, 0.0001, 0.00001);
   if(%targetDist > 50)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, laserrifle, 0);
         AI::SetVar(%aiName, triggerPct, 0.005 );
      }
      else
      {
	Player::mountItem(%aiId, laserrifle, 0);
	AI::SetVar(%aiName, triggerPct, 0.005 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 1 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 1 );
      }   
   }
  }




 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   if(%targetDist > 100)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, blaster, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, mineammo, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   
   }
  }


 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   if(%targetDist > 20)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, blaster, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   

   }   
   else
   {
         Player::mountItem(%aiId, disclauncher, 0);
         Player::useItem(%aiId, repairkit, 0);
   }
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
         AI::setVar( %aiName,  iq,  $Spoonbot::IQ );
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
   %zPos = getWord(%spawnMarker, 2) + 5;
   %rPos = GameBase::getRotation(%commandIssuer);
   
   dbecho(2, "Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
   dbecho(2, "Current Issuer rotation: " @ %rPos);
      
   %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
   %newName = %aiName @ $numAI;
   $numAI++;
   Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos,  %newName, %voice );
   schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.

   $Spoonbot::NumBots = $Spoonbot::NumBots + 1;

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
	  AI::DirectiveWaypoint( %aiName, %newIssuedVec, 2, 2 );
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
//   dbecho(2, "Commanders Position: " @ %commPos);
   
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
//   dbecho(2, "AI moving to " @ %newPos);
   AI::DirectiveWaypoint(%aiName, %newPos, 2, 2);
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
//   dbecho(2, "checking drone information...." @ " number of nodes: " @ %nodeCount);
//   dbecho(2, "AI id: " @ %aiId @ " groupId: " @ %groupId);
   
 	   if( %command == 1 )  //Attack
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  
	      %worldLoc = WaypointToWorld ( %waypoint );

	      AI::DirectiveRemove( %name, 2 );   //Crude way to clear all directives. Needs to be done because else the bots won't
                                                 //respond to any new orders!

              Vehicle::passengerJump(0,%aiId,0);  //Crude way to make passengers hop off vehicles :-P
//              AI::Jump(%aiId,0);                    //Just jumps. Much more convenient


              %BotRot = GameBase::getRotation(%aiId);
              if(GameBase::getLOSInfo(Client::getOwnedObject(%aiId), 150, %BotRot))    //Test if AI is within firing range
                {
//	          AI::DirectiveTargetPoint( %name, %worldLoc, 2, 2);  //Fucks up AI::DirectiveList
                }
                else
                {
//	          AI::DirectiveWaypoint( %name, %worldLoc, 2, 2);
                }



	          AI::DirectiveWaypoint( %name, %worldLoc, 2, 2);  //Used this because TargetPoint fucked up the list

	   }





	   if( %command == 2 )  //Defend
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  
	      %worldLoc = WaypointToWorld ( %waypoint );

	      AI::DirectiveRemove( %name, 2 );   //Crude way to clear all directives. Needs to be done because else the bots won't
                                                 //respond to any new orders!



        if (getWord(%cmdText, 0) == "Deploy") //Deploy
         {
            if (getWord(%cmdText, 1) == "pulse") //Deploy Pulse Sensor
          {
              AI::DeployItem(%aiId, PulseSensorPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "sensor") //Deploy Sensor Jammer
          {
              AI::DeployItem(%aiId, DeployableSensorJammerPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "motion") //Deploy Motion Sensor
          {
              AI::DeployItem(%aiId, MotionSensorPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "camera") //Deploy Camera
          {
              AI::DeployItem(%aiId, CameraPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "Ammo") //Deploy Ammo Station
          {
              AI::DeployItem(%aiId, DeployableAmmoPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "Inventory") //Deploy Inventory Station
          {
              AI::DeployItem(%aiId, DeployableInvPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "Turret") //Deploy Turret
          {
              AI::DeployItem(%aiId, TurretPack);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }

            if (getWord(%cmdText, 1) == "beacon") //Deploy Beacon
          {
              AI::DeployItem(%aiId, Beacon);
              schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
          }
         }
          else
         {


//           %xPos = getWord(%worldLoc, 0);
//           %yPos = getword(%worldLoc, 1);
//           %zPos = getWord(%worldLoc, 2);

//           newObject("AI", SimGroup);
//           newObject(%name, SimGroup);
//           newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
//           addToSet(%name, "Marker1");
//           addToSet("AI", %name);
//           addToSet("MissionGroup\\Teams\\team" @ %T, AI);

             AI::DirectiveFollow( %name, %commander, 0,2);

//	     dbecho ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
         }

  	 if( %command == 3 )  //Repair
	 {
	     return;
	 }


      }


//	   dbecho( 1, "AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
//	   dbecho( 1, "Cmdr:        " @ %commander );
//	   dbecho( 1, "Command:     " @ %command );
//	   dbecho( 1, "Waypoint:    " @ %waypoint );
//	   dbecho( 1, "TargetId:    " @ %targetId );
//	   dbecho( 1, "cmdText:     " @ %cmdText );
//	   dbecho( 1, "cmdStatus:   " @ %cmdStatus );
//	   dbecho( 1, "cmdSequence: " @ %cmdSequence );

 
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, cheer3 );
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


function Ai::messageHelper(%targetId, %msg )
{
    Client::sendMessage( %targetId, 0, %msg );
}



// Default periodic callback.  [Note by default it isn't called unless a frequency 
//    is set up using AI::CallbackPeriodic().  Type in that command to see how 
//    it works].  
function AI::onPeriodic( %aiName )
{
//   dbecho(2, "onPeriodic() called with " @ %aiName );
}



//The following callbacks are responsible for the bot's chasing behaviour.
//modified by Werewolf

function AI::onDroneKilled(%aiName)
{
   if( ! $SinglePlayer )
   {

    %aiId = AI::getId(%aiName);
    %team = GameBase::getTeam(%aiId);

//	Client::sendMessage(%cl, $MsgTypeGame, %aiName @ ": Target acquired.~wtgtacq", %aiId);

    if ($Spoonbot::BotChat)
	{
	    schedule("AI::RandomSuckMsg(" @ %aiName @ ", " @ %team @ ");", 2 );
	}

    if (%aiId != $DoNotRespawnAI)
     {
      // Delay $RespawnDelay seconds before respawning
      if ($Spoonbot::RespawnDelay == 0)
        {
          $Spoonbot::RespawnDelay = 30;    //No respawn delay set in spoonbot.cs ?? Ok, then assume 30 seconds.
        }
      $Spoonbot::NumBots = $Spoonbot::NumBots - 1;
      schedule("AI::setupAI(" @ %aiName @ ", " @ %team @ ");", $Spoonbot::RespawnDelay );
      $DoNotRespawnAI = 0;
     }
   }
   else
   {
    // just in case:
    dbecho( 2, "Non training callback called from Training" );
   }




}

//these AI function callbacks can be very useful!

function AI::onTargetDied(%aiName, %idNum)
{


   %aiId = AI::getId(%aiName);
   %team = GameBase::getTeam(%aiId);
   %curTarget = %idNum;

    if ($Spoonbot::BotChat)
	{
	   AI::RandomCheerMsg(%aiName, %team);
	}

   AI::DirectiveRemove( %aiName, 125);

   if(String::findSubStr(%aiName, "Roam") >= 0)        //is it a roaming bot?
	{
          AI::DirectiveRemove( %aiName, 2);
        }

   if(%curTarget == -1)
   {
   	return;
   }
      
}                                 

function AI::onTargetLOSAcquired(%aiName, %idNum)
{
%aiId = AI::getId(%aiName);               //Sometimes, switching teams make your own bots chase you like an enemy. This is very
%aiTeam = Client::getTeam(%aiId);         //strange, since switching to Observer mode and THEN to an other team does NOT produce this error.
%targetTeam = Client::getTeam(%idNum);    //This is a quick hack so bots won't continue hunting you if you're in the same team
if (%targetTeam != %aiTeam)
  {
//   dbecho(1, %aiName @ " just spotted an enemy");
   AI::HuntTarget(%aiName, %idNum, 1);
  }
}

function AI::onTargetLOSLost(%aiName, %idNum)
{
%aiId = AI::getId(%aiName);
%aiTeam = Client::getTeam(%aiId);
%targetTeam = Client::getTeam(%idNum);
if (%targetTeam != %aiTeam)
  {
//   dbecho(1, %aiName @ " lost eye contact to enemy");
   AI::HuntTarget(%aiName, %idNum, 1);
   AI::Jump(%aiId,1);                    //Makes a high jet-jump. Sometimes this helps to regain LOS
  }
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
%aiId = AI::getId(%aiName);
%aiTeam = Client::getTeam(%aiId);
%targetTeam = Client::getTeam(%idNum);
if (%targetTeam != %aiTeam)
  {
//   dbecho(1, %aiName @ " found the enemy again");
   AI::HuntTarget(%aiName, %idNum, 1);
  }
}




function AI::HuntTarget(%aiName, %idNum, %Follow) //If %Follow is 0 then waypoint will be updated. If 1 then Bot will follow regardless of LOS.
{
   %aiId = AI::getId(%aiName);
   %curTarget = %idNum;

   if(%curTarget == -1)
   {
   	return;
   }
      
//   dbecho(1, %aiName @ " target: " @ %curTarget);	
   
   %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %targetDist = Vector::getDistance(%aiLoc, %targLoc);
//   dbecho(2, "distance to target: " @ %targetDist @ " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);


 if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 125);
           AI::SmartFollow (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 2);
	}
	else
	{
           AI::SmartStayAway (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 125);
	}
 }

 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 125);
           AI::SmartFollow (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 2);
	}
	else
	{
           AI::SmartStayAway (%aiName, %idNum, %targLoc, 0, %targetDist, 80, 125);
	}
 }

 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 80, 125);
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 80, 2);
	}
 }

 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 50, 125);
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 50, 2);
	}
 }

 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 60, 125);
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 60, 2);
	}
 }

 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 30, 125);
   if(String::findSubStr(%aiName, "Roam") >= 0)
	{
           AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 30, 2);
	}
 }


}




//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//If %Follow = 0 the AI will try to keep a minimum distance of %mintargetDist. If the distance is greater, it will come closer.
//If %Follow = 1 then the AI will follow the target %idNum to oblivion
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking

function AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
   if (%Follow == 0)
    {
      if(%targetDist > %minTargetDist)
        {
          AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
        }

    }
    else
    {
      if(%targetDist > %minTargetDist)
        {
	  AI::DirectiveFollow( %aiName, %idNum, 0, %order );

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
        }
    }
}


//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//The AI will evade slightly until distance to enemy is < %mintargetDist.
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking

function AI::SmartStayAway (%aiName, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
   if (%Follow == 0)
    {
      if(%targetDist < %minTargetDist)
        {
          AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
        }
    }
    else
    {
      if(%targetDist < %minTargetDist)
        {
	  AI::DirectiveFollow( %aiName, %idNum, 0, %order );     

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
        }
    }

}




function AI::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = floor(getRandom() * (%count - 0.1));
   %value = %count;
   for(%i = %spawnIdx; %i < %value; %i++) {
      %set = newObject("set",SimSet);
      %obj = Group::getObject(%group, %i);
      if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) 
         return %obj;
      if(%i == %count - 1) {
         dbecho(1, "pickRandomSpawn error: You forgot to set Random Drop points in your map!");
         %i = -1;
         %value = %spawnIdx;
      }
      deleteObject(%set);
   }
   return false;
}




function AI::checkObstacle(%aiId)  //This function checks for nearby obstacles and makes the AI evade them. By Werewolf.
{                                  //This is by no means perfect. The AI still hangs pretty often.
        %passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 10;
		%velocity = 70;
		%zVec = 40;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 15;
		%velocity = 100;
		%zVec = 80;
	}
	else if(%armor == "harmor") {
		%height = 20;
		%velocity = 140;
		%zVec = 100;
	}

	%pos = GameBase::getPosition(Client::getOwnedObject(%passenger));
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	%minObstacleDistance = 0.001;      //The minimum distance controls how close objects may get until the bot starts evading.
					   //This value still needs experimenting
	%evasionDistance = 0;

	%rotX = getWord(GameBase::getRotation(Client::getOwnedObject(%passenger)),0);
	%rotY = getWord(GameBase::getRotation(Client::getOwnedObject(%passenger)),1);
	%rotZ = getWord(GameBase::getRotation(%passenger),2);

	%jump = 0;



	//Checking for straight obstacles
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX + %minObstacleDistance) @ " " @ %posY @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX + 30) @ " " @ (%rotY - 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX - %evasionDistance) @ " " @ (%posY + %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in Instance 1");
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ %posY @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX - 30) @ " " @ (%rotY + 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX + %evasionDistance) @ " " @ (%posY - %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in Instance 2");
	}


	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),%posX @ " " @ (%posY + %minObstacleDistance) @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX + 30) @ " " @ (%rotY + 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX - %evasionDistance) @ " " @ (%posY + %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in Instance 3");
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),%posX @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX - 30) @ " " @ (%rotY - 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX + %evasionDistance) @ " " @ (%posY - %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in Instance 4");
	}






	//Checking for diagonal obstacles
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX + %minObstacleDistance) @ " " @ (%posY + %minObstacleDistance)@ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX + 30) @ " " @ (%rotY - 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX - %evasionDistance) @ " " @ (%posY + %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in diagonal instance 1");
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX - 30) @ " " @ (%rotY + 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX + %evasionDistance) @ " " @ (%posY - %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in diagonal instance 2");
	}


	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ (%posY + %minObstacleDistance) @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX + 30) @ " " @ (%rotY + 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX - %evasionDistance) @ " " @ (%posY + %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in diagonal instance 3");
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX + %minObstacleDistance) @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		GameBase::setRotation(%passenger, (%rotX - 30) @ " " @ (%rotY - 30) @ " " @ %rotZ);
		GameBase::setPosition(%passenger,(%posX + %evasionDistance) @ " " @ (%posY - %evasionDistance) @ " " @ (%posZ + %height));
		%jump = 1;
//		echo ("CheckObstacle found collision for " @ %passenger @ " in diagonal instance 4");
	}



	if (%jump == 1)
	{
		%jumpDir = Vector::getFromRot((GameBase::getRotation(Client::getOwnedObject(%passenger))),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		schedule("AI::Jump(" @ %aiId @ ",0);", 2);
	}

}	



//The following Callback isn't called - only God knows why..
//modified by Werewolf

function AI::onCollision (%aiId, %object)
{

   %targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 

   dbecho(1, "obstacle location" @ %targLoc);
   dbecho(1, "ai location" @ %aiLoc);
   dbecho(1, "ai rotation" @ %aiLoc);

   dbecho(1, "onCollision called in ai.cs");
   Vehicle::passengerJump(0,%aiId,0);  //Crude way to make players avoid obstacles
   Vehicle::passengerJump(0,%object,0);


//   %aiRotation = %aiRotation + 90
//
//   %Length = 50; %Zvalue = 0; 
//   %aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 
//
//   Player::applyImpulse(%aiId, %aiVect); 



//Maybe the "testPosition" call can be used to check for obstacles, hmmm...
//	if(GameBase::testPosition(Client::getOwnedObject(%aiId),%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
//		%client = Player::getClient(%aiId);
//		%this.Seat[%passenger.vehicleSlot-2] = "";
//		%passenger.vehicleSlot = "";
//	   %passenger.vehicle= "";
//		Player::setMountObject(%passenger, -1, 0);
//		%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);
//		GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
//		GameBase::setPosition(Client::getOwnedObject(%aiId),%posX @ " " @ %posY @ " " @ (%posZ + %height));
//		%jumpDir = Vector::getFromRot(GameBase::getRotation(Client::getOwnedObject(%aiId)),%velocity,%zVec);
//		Player::applyImpulse(%aiId,%jumpDir);
//	}
//	else
//		Client::sendMessage(Player::getClient(%aiId),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
//


}












//This will spawn an AI player in a map that does not yet contain a bot
//------------------------------------------------------------------------------------------------------------------------
//by Werewolf

function AI::SpawnAdditionalBot(%aiName, %teamnum, %spawnFromAdmin)
{

if (%aiName == "")
{
  return;
}

   $numAI = 0;


// Old method for finding spawn points: Uses player position.
//-----------------------------------------------------------
//   %spawnMarker = GameBase::getPosition(%commandIssuer);
//   %xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 15);
//   %yPos = getword(%spawnMarker, 1) + floor(getRandom() * 10);
//   %zPos = getWord(%spawnMarker, 2) + 5;
//   %rPos = GameBase::getRotation(%commandIssuer);


// New method for finding spawn points: Uses fixed respawn points
//---------------------------------------------------------------
   %spawnMarker = AI::pickRandomSpawn(%teamnum);
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

	 %rPos = %spawnRot;
         %xPos = getWord(%spawnPos, 0);
         %yPos = getword(%spawnPos, 1);
         %zPos = getWord(%spawnPos, 2);
         %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;

//         dbecho(1, "Random Spawn Position is: " @ %xPos @ "  " @ %yPos @ "  " @ %zPos);





    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
      {
      $AI::defaultArmorType = "lfemale";
      %voice = "female2";
      }
      else
      {
      $AI::defaultArmorType = "larmor";
      %voice = "male2";
      }


    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "harmor";
      %voice = "female5";
      }
      else
      {
      $AI::defaultArmorType = "harmor";
      %voice = "male5";
      }
    }


    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "mfemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "marmor";
      %voice = "female2";
      }
    }



//   if(GameBase::getLOSInfo(%playerObj, 100, %issuerRot))    //Used to spawn AI at LOS target. Doesn't work correctly.
//   { 
//     %aiSpawnPos = $LOS::position;
//   }
//   else
//   {   
//     %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
//   }



//   %newName = "STeam" @ %teamnum @ "_" @ %aiName;
//   %aiName = %newname;
//   newObject("AI", SimGroup);
//   newObject(%newName, SimGroup);
//   newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
//   addToSet(%newName, "Marker1");
//   addToSet("AI", %newName);
//   addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);


  if (%spawnFromAdmin == 1) //Are we spawning from the menu in admin.cs ?
  {                         //If yes, we have to insert a bot count number into the name
      %num = 1;
      %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
      %spawnSuccessfull = 0;
      if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
      {
        schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.
        $Spoonbot::NumBots = $Spoonbot::NumBots + 1;
        %spawnSuccessfull = 1;
      }
      else
      {
        %num++;
        %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
        if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
        {
          schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.
          $Spoonbot::NumBots = $Spoonbot::NumBots + 1;
          %spawnSuccessfull = 1;
        }
        else
        {
          %num++;
          %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
          if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
          {
            schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.
            $Spoonbot::NumBots = $Spoonbot::NumBots + 1;
            %spawnSuccessfull = 1;
          }
          else
          {
            dbecho( 1, "Cannot spawn " @ %aiName @ ", only 3 bots per class allowed for each team");
          }
        }
      }
  }
  else
  {                      //If not, we can just have it that way
      %newName = %aiName;
          if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
          {
            schedule("AI::RoamingBotsStartup(" @ %newName @ ");", 2);    //If it's a roaming bot, select a new target to attack.
            $Spoonbot::NumBots = $Spoonbot::NumBots + 1;
            %spawnSuccessfull = 1;
          }
	  else
          {
            dbecho("AutoSpawn error: Cannot spawn " @ %aiName );
          }
    
  }


        newObject("AI", SimGroup);
        newObject(%newName, SimGroup);
        newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
        addToSet(%newName, "Marker1");
        addToSet("AI", %newName);
        addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);




// Above method allows spawning of 3 bots per class and team. The old method below only allowed one.
// The problem was to try all names until a free name was found. That way you can control the number of bots the client can spawn...
// ... and we don't wanna have a player spawning huge armies of bots ;-)

//   Ai::spawn(%newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice );


         %aiId = AI::getId( %newName );
         GameBase::setTeam(%aiId, %teamnum);
         AI::setVar( %newName,  iq,  $Spoonbot::IQ );
         AI::setVar( %newName,  attackMode, 1);
         AI::setVar( %newName,  pathType, $AI::defaultPathType);
         AI::DirectiveWaypoint( %newName, %aiSpawnPos, 2, 2 );
         schedule("AI::setWeapons(" @ %newName @ ");", 1);

   return ( %newName );
}




function AI::DeployItem(%aiId,%desc)  //added by Werewolf. Yay I'm proud of this piece of code ;-)
{

// List of deployable Items:
//--------------------------
//  DeployableAmmoPack
//  DeployableInvPack
//  TurretPack
//  CameraPack
//  DeployableSensorJammerPack
//  PulseSensorPack
//  MotionSensorPack
//  Beacon
//??mineammo??


        %item = %desc;
	%player = %aiId;

//echo(1, "Item description: \"" @ %desc @ "\"");
//echo(1, "item \"" @ %item @ "\"");

	// --------------------------------------
	// This doesn't work, so we have to do it manually.
	// --------------------------------------
	// Player::setItemCount(%aiId, %item, 1);
	// Player::deployItem(%aiId,%item);
	// --------------------------------------

        if (%item == "DeployableInvPack")
            {
                %client = Player::getClient(%aiId);
                %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
                addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%aiId); 
		GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
		GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,%name);
		Client::sendMessage(%client,0,"Inventory Station deployed");
		playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
		echo("MSG: ",%client," deployed an Inventory Station");
            }


        if (%item == "DeployableAmmoPack")
            {
                %client = Player::getClient(%aiId);
                %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
                addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%aiId); 
		GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
		GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,%name);
		Client::sendMessage(%client,0,"Ammo Station deployed");
		playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
		echo("MSG: ",%client," deployed an Ammo Station");
            }

        if (%item == "MotionSensorPack")
            {
                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployableMotionSensor",true);
                addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%aiId); 
		GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
		GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,"Motion Sensor");
		Client::sendMessage(%client,0,"Motion Sensor deployed");
		playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%inv) @ "MotionSensorPack"]++;
		echo("MSG: ",%client," deployed a Motion Sensor");
            }

        if (%item == "PulseSensorPack")
            {
                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployablePulseSensor",true);
                addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%aiId); 
		GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
		GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,"Pulse Sensor");
		Client::sendMessage(%client,0,"Pulse Sensor deployed");
		playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%inv) @ "PulseSensorPack"]++;
		echo("MSG: ",%client," deployed a Pulse Sensor");
            }


        if (%item == "DeployableSensorJammerPack")
            {
                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployableSensorJammer",true);
                addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%aiId); 
		GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
		GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,"Sensor Jammer");
		Client::sendMessage(%client,0,"Sensor Jammer deployed");
		playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableSensorJammerPack"]++;
		echo("MSG: ",%client," deployed a Sensor Jammer");
            }


        if (%item == "CameraPack")
            {
                %client = Player::getClient(%aiId);
		%camera = newObject("Camera","Turret",CameraTurret,true);
	   	addToSet("MissionCleanup", %camera);
		GameBase::setTeam(%camera,GameBase::getTeam(%aiId));
		GameBase::setRotation(%camera,%rot);
		GameBase::setPosition(%camera,GameBase::getPosition(%aiId));
		Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Camera deployed");
		playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
		echo("MSG: ",%client," deployed a Camera");
            }


        if (%item == "TurretPack")
            {
                %client = Player::getClient(%aiId);




	if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						







                %rot = GameBase::getRotation(%aiId); 
		%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	        addToSet("MissionCleanup", %turret);
		GameBase::setTeam(%turret,GameBase::getTeam(%aiId));
		GameBase::setPosition(%turret,GameBase::getPosition(%aiId));
		GameBase::setRotation(%turret,%rot);
		Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Remote Turret deployed");
		playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
		$TeamItemCount[GameBase::getTeam(%aiId) @ "TurretPack"]++;
		echo("MSG: ",%client," deployed a Remote Turret");



					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;








            }


        if (%item == "Beacon")
            {
                %client = Player::getClient(%aiId);
                %beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
		addToSet("MissionCleanup", %beacon);
		GameBase::setTeam(%beacon,GameBase::getTeam(%aiId));
		GameBase::setRotation(%beacon,%rot);
		GameBase::setPosition(%beacon,GameBase::getPosition(%aiId));
		Gamebase::setMapName(%beacon,"Target Beacon");
		Beacon::onEnabled(%beacon);
		Client::sendMessage(%client,0,"Beacon deployed");
		$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
            }

}




function AI::RemoveBot(%aiName, %commandissuer)
{
  %aiId = AI::getId( %aiName );
  $DoNotRespawnAI = %aiId;
  Player::kill(%aiId);
  $Spoonbot::NumBots = $Spoonbot::NumBots - 1;
}


function AI::buildGraph()
{
	echo("building AI Graph...");
   %nodeGroup = nameToID("MissionGroup\\AIGraph");
   %numNodes  = Group::ObjectCount(%nodeGroup);
   
   echo("nodeGroup: " @ %nodeGroup @ " number of Nodes: " @ %numNodes); 
   
   for(%i = 0; %i < %numNodes; %i++)
   {
   	%node    = Group::getObject(%nodeGroup, %i);
      %nodePos = GameBase::getPosition(%node);
      %name = "Node " @ %i;
      //echo("name of node:" @ %name);
      //echo("adding node: " @ %node @ " at position: " @ %nodePos);
      if(name != "")
      	Graph::AddNode(%nodePos, %name);
      else 
         Graph::AddNode(%nodePos);
   }
   if(Graph::buildGraph() == -1)
    	echo("Can't create adjacent lists for graph nodes.");
   else
   	echo("Graph build complete.");
}


//Render lines to show AI Graph
function drawGraph()
{
	newObject("graphRender", GraphPathRender);
}









function AI::RandomCheerMsg(%aiName, %team)
{
%perChance = floor(getRandom() * (10 - 0.1));
if (%perChance >= 8)
 {
	%aiId = AI::getId( %aiName );
	%msgIdx = floor(getRandom() * (8 - 0.1));
	%enemyTeam = 1;
	if (%team == 1)
	{
	  %enemyTeam = 0;
	}
	
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	  {
	//	Client::sendMessage(%cl, $MsgTypeGame, %aiName @ ": " @ $cheerList[%msgIdx], %aiId);
		Ai::soundHelper( %aiId, %cl, $vcheerList[%msgIdx] );
	  }
	
	TeamMessages(0, %team, %aiName @ ": " @ $cheerList[%msgIdx]);
	TeamMessages(1, %enemyTeam, %aiName @ ": " @ $cheerList[%msgIdx]);
 }
}








function AI::RandomSuckMsg(%aiName, %team)
{
%perChance = floor(getRandom() * (10 - 0.1));
if (%perChance >= 8 )
 {
	%aiId = AI::getId( %aiName );
	%msgIdx = floor(getRandom() * (8 - 0.1));
	%enemyTeam = 1;
	if (%team == 1)
	{
	  %enemyTeam = 0;
	}
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	  {
	//	Client::sendMessage(%cl, $MsgTypeGame, %aiName @ ": " @ $suckList[%msgIdx], %aiId);
		Ai::soundHelper( %aiId, %cl, $vsuckList[%msgIdx] );
	  }
	
	TeamMessages(0, %team, %aiName @ ": " @ $suckList[%msgIdx]);
	TeamMessages(1, %enemyTeam, %aiName @ ": " @ $suckList[%msgIdx]);
 }
}








function AI::ProcessAutoSpawn()		// A *VERY* dirty way to process the spoonbot.cs file... I know ;-)
{

$vcheerList[0] = "cheer1";   	// YEAH			//This sets up a list of voice comments
$vcheerList[1] = "cheer2";   	// WOO-HOO
$vcheerList[2] = "cheer3";   	// ALL RIGHT
$vcheerList[3] = "taunt1";   	// Yooo-Hooo!
$vcheerList[4] = "taunt10";    // Howd that feel?
$vcheerList[5] = "tautn11";    // I've Had worse
$vcheerList[6] = "taunt2";   	// Missed me!
$vcheerList[7] = "taunt3";   	// Dance!
$vcheerList[8] = "taunt4";   	// Come Get some
$vcheerList[9] = "taunt4";   	// Come Get some

$cheerList[0] = "Yeah, that's the ticket!~wcheer1";   	// YEAH			//This sets up a list of voice comments
$cheerList[1] = "Woo-hoo!! That gotta hurt!~wcheer2";   	// WOO-HOO
$cheerList[2] = "All right!!~wcheer3";   	// ALL RIGHT
$cheerList[3] = "Yooo-Hooo!~wtaunt1";   	// Yooo-Hooo!
$cheerList[4] = "How did that feel?~wtaunt10";    // Howd that feel?
$cheerList[5] = "I've had worse~wtautn11";    // I've Had worse
$cheerList[6] = "Missed me, sucker!~wtaunt2";   	// Missed me!
$cheerList[7] = "Dance!~wtaunt3";   	// Dance!
$cheerList[8] = "Come get some.~wtaunt4";   	// Come Get some
$cheerList[9] = "Come get some.~wtaunt4";   	// Come Get some


$vsuckList[0] = "color3";   	// Hmmm
$vsuckList[1] = "color6";   	// Dammit!
$vsuckList[2] = "color7";   	// Ahhh Crap!
$vsuckList[3] = "dsgst1";   	// Duh!
$vsuckList[4] = "dsgst2";   	// You Idiot!
$vsuckList[5] = "dsgst4";   	// AWWWWWUUUUHHH!!
$vsuckList[6] = "dsgst5";   	// <SIGH resignation of>
$vsuckList[7] = "oops1";   	// DOH! 
$vsuckList[8] = "oops2";   	// Ooops!
$vsuckList[9] = "oops2";   	// Ooops!

$suckList[0] = "Hmmm.~wcolor3";   	// Hmmm
$suckList[1] = "Damnit!~wcolor6";   	// Dammit!
$suckList[2] = "Ahhh crap!~wcolor7";   	// Ahhh Crap!
$suckList[3] = "Duh!~wdsgst1";   	// Duh!
$suckList[4] = "You Idiot!~wdsgst2";   	// You Idiot!
$suckList[5] = "AWWWWUUUUHHH!!~wdsgst4";   	// AWWWWWUUUUHHH!!
$suckList[6] = "What should I say?~wdsgst5";   	// <SIGH resignation of>
$suckList[7] = "Doh!~woops1";   	// DOH! 
$suckList[8] = "Ooops!~woops2";   	// Ooops!
$suckList[9] = "Ooops!~woops2";   	// Ooops!

$friendlyFireList[0] = "Watch where you're shooting, pal!~wwshoot3";   // Watch where you're shooting


if ($Spoonbot::AutoSpawn)
 {
	AI::spawnAdditionalBot($Spoonbot::Bot1Name, $Spoonbot::Bot1Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot2Name, $Spoonbot::Bot2Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot3Name, $Spoonbot::Bot3Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot4Name, $Spoonbot::Bot4Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot5Name, $Spoonbot::Bot5Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot6Name, $Spoonbot::Bot6Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot7Name, $Spoonbot::Bot7Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot8Name, $Spoonbot::Bot8Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot9Name, $Spoonbot::Bot9Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot10Name, $Spoonbot::Bot10Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot11Name, $Spoonbot::Bot11Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot12Name, $Spoonbot::Bot12Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot13Name, $Spoonbot::Bot13Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot14Name, $Spoonbot::Bot14Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot15Name, $Spoonbot::Bot15Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot16Name, $Spoonbot::Bot16Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot17Name, $Spoonbot::Bot17Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot18Name, $Spoonbot::Bot18Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot19Name, $Spoonbot::Bot19Team, 0);
	AI::spawnAdditionalBot($Spoonbot::Bot20Name, $Spoonbot::Bot20Team, 0);
 }
}

function AI::Jump(%aiId,%jet)      //This function makes the AI jump. If %jet=1 then it simulates a high jet-jump.
{
      %passenger = %aiId;

if (!$Spoonbot::BotJetting)        //Disable Jetting if users wants it that way.
 {
   %jet = 0;
 }

      if (%jet==0)
      {
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
      }
      else
      {
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 15;
		%velocity = 70;
		%zVec = 40;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 19;
		%velocity = 100;
		%zVec = 60;
	}
	else if(%armor == "harmor") {
		%height = 22;
		%velocity = 140;
		%zVec = 90;
	}
      }


	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
//	else
//		echo(%passenger @ " can not jump - Obstacle in the way.");
}







function AI::checkForPaint(%aiName)						// savage
{										// savage

//---------------------This is the CheckForPaint stuff from savage, fit into SPOONBOT----------------------

  if(String::findSubStr(%aiName, "Guard") >= 0)
  {

	%aiId = AI::getId(%aiName);						// savage

	%T = GameBase::getTeam(%aiId);						// savage
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))	// savage
	{									// savage
		%team = Client::getTeam(%cl);					// savage
		if(%team == %T)							// savage
		{								// savage
			if (Player::getMountedItem(%cl,$WeaponSlot) == TargetingLaser)
			{
				if (Player::isTriggered(%cl,$WeaponSlot))
				{
					Player::mountItem(%aiId, mortar, 0);		// savage
					AI::SetVar(%aiName, triggerPct, 100 );		// savage

					AI::DirectiveTargetLaser( %aiName, %cl, 256 );
										// let's only harass the painting player
					Client::sendMessage(%cl, $MsgTypeGame, %aiName @ ": Target acquired.~wtgtacq", %aiId);
					Ai::soundHelper( %aiId, %cl, "tgtacq" );
					return;					// First found painter wins
				}
				else
				{
					AI::DirectiveRemove( %aiName, 256 );	// Werewolf
					return;
				}
			}							// savage
		}								// savage
	}									// savage

  }
//---------------------------------------------------------------------------------------------------------

}












function AI::AttackRandomEnemy(%aiName)		//This function is for "Roaming" Bots to choose targets at will. By Werewolf
{

   %aiId = AI::getId(%aiName);

   %player = Client::getOwnedObject(%aiId);
   if (Player::isDead(%player))
     {
	return;
     }


   %newName = Client::getName(%aiId);
   if (%newName != %aiName)
     {
	return;
     }

 schedule("AI::RoamingBotsStartup(" @ %aiName @ ");", $Spoonbot::ThinkingInterval);    //Do this over and over again, as long as bot lives.



%aiTeam = Client::getTeam(%aiId);
%player = Client::getOwnedObject(%aiId);
%hasFlag = Player::getItemCount(%player, Flag);

if (%hasFlag != 0)                                    //If bot has the enemy's flag, get it to our flag
 {
	%pos = ($teamFlag[%aiTeam]).originalPosition;
	%xPos = getWord(%pos, 0);
	%yPos = getword(%pos, 1);
	%zPos = getWord(%pos, 2);
	%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	AI::DirectiveWaypoint( %aiName, %flagPos, 2);
	AI::DirectiveWaypoint( %aiName, %flagPos, 125);
	echo(%aiName @ " tries to get the enemy's flag to our flag stand.");
	return;
 }






//---------------------This is the CheckForPaint stuff from savage, fit into SPOONBOT----------------------

  if(String::findSubStr(%aiName, "Guard") >= 0)
  {

	%aiId = AI::getId(%aiName);						// savage

	%T = GameBase::getTeam(%aiId);						// savage
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))	// savage
	{									// savage
		%team = Client::getTeam(%cl);					// savage
		if(%team == %T)							// savage
		{								// savage
			if (Player::getMountedItem(%cl,$WeaponSlot) == TargetingLaser)
			{
				if (Player::isTriggered(%cl,$WeaponSlot))
				{
					Player::mountItem(%aiId, mortar, 0);		// savage
					AI::SetVar(%aiName, triggerPct, 100 );		// savage

					AI::DirectiveTargetLaser( %aiName, %cl, 256 );
										// let's only harass the painting player
					Client::sendMessage(%cl, $MsgTypeGame, %aiName @ ": Target acquired.~wtgtacq", %aiId);
					Ai::soundHelper( %aiId, %cl, "tgtacq" );
					return;					// First found painter wins
				}
				else
				{
					AI::DirectiveRemove( %aiName, 256 );	// Werewolf
					return;
				}
			}							// savage
		}								// savage
	}									// savage

  }
//---------------------------------------------------------------------------------------------------------




if ($Spoonbot::BotsRetreat)
 {

   %player = Client::getOwnedObject(%aiId);
   %dlevel = GameBase::getDamageLevel(%player);
   if (%dlevel >= $Spoonbot::RetreatDamageLevel)      //If damage level exceeds maximum, let bot retreat.
	{
	   %spawnMarker = AI::pickRandomSpawn(%aiTeam);
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

	   %xPos = getWord(%spawnPos, 0);
	   %yPos = getword(%spawnPos, 1);
	   %zPos = getWord(%spawnPos, 2);
	   %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	   AI::DirectiveWaypoint( %aiName, %aiSpawnPos, 2);
	   AI::DirectiveWaypoint( %aiName, %aiSpawnPos, 125);
	   echo(%aiName @ " is retreating!");
	   return;
	}
 }



if ($Spoonbot::HuntFlagrunner != 0)                   //If an enemy has our flag, let ALL of our bots attack him.
 {
       %cl = $Spoonbot::HuntFlagrunner;
       %aiTeam = Client::getTeam(%aiId);
       %targetTeam = Client::getTeam(%cl);
       if (%targetTeam != %aiTeam)           //Is this an enemy?
       {
        %player = Client::getOwnedObject(%cl);
	if (!Player::isDead(%player))
	  {
	   %enemyName = Client::getName(%cl);
	   if (%enemyName != "")
		{
		   echo(%aiName @ " is attacking the enemy flagrunner " @ %enemyName);
		   AI::HuntTarget(%aiName, %cl, 1);
		   return;
		}
	  }
       }
       else				    //else this is a friendly, so let's escort him to safety.
       {
        %player = Client::getOwnedObject(%cl);
	if (!Player::isDead(%player))
	  {
	   %enemyName = Client::getName(%cl);
	   if (%enemyName != "")
		{
		   echo(%aiName @ " is escorting the friendly flagrunner " @ %enemyName);
		   AI::HuntTarget(%aiName, %cl, 1);  //The procedure is the same, except the friendly bot won't fire on the flagrunner
		   return;
		}
	  }
       }
   }





   %spawnIdx = floor(getRandom() * ($Spoonbot::NumBots - 0.1));  //Add a random variation to the target selection

//   %startCl = Client::getFirst() + %spawnIdx;  //This has caused the bots to not attack unless a player is present.

   %startCl = 2049 + %spawnIdx;                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!

   %endCl = %startCl + 90;
   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
   {
       %aiTeam = Client::getTeam(%aiId);
       %targetTeam = Client::getTeam(%cl);

       if (%targetTeam != %aiTeam)               //Is this an enemy?
       {
        %player = Client::getOwnedObject(%cl);
	if (!Player::isDead(%player))
	  {
	   %enemyName = Client::getName(%cl);
	   if (%enemyName != "")
		{
		   echo(%aiName @ " has decided to attack " @ %enemyName);
		   AI::HuntTarget(%aiName, %cl, 1);
		   return;
		}
		else                              //If somehow we can't find an enemy, try to capture the flag
		{

			%enemyTeam = 1;           //find out the enemy team's teamnumber
			if (%aiTeam == 1)
			{
			  %enemyTeam = 0;
			}

			%pos = ($teamFlag[%enemyTeam]).originalPosition;
			%xPos = getWord(%pos, 0);
			%yPos = getword(%pos, 1);
			%zPos = getWord(%pos, 2);
			%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
			AI::DirectiveWaypoint( %aiName, %flagPos, 2);         //Head for the flag. NOTE: The bot will still attack all
			AI::DirectiveWaypoint( %aiName, %flagPos, 125);       //enemies he encounters. I still need to make him concentrate
			echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
			return;
		}
	  }
       }
   }

 echo(%aiName @ " could not find any enemies!");


}



function AI::RoamingBotsStartup(%aiName)         //Checks if %aiName is a roaming bot, and handles it's target selection. By Werewolf
{

    if(String::findSubStr(%aiName, "Roam") >= 0)        //is it a roaming bot?
	{
	  AI::AttackRandomEnemy(%aiName);               //Yes, so choose an enemy to attack.
	}						//A "bot-brain" could be implemented here someday, so bots can decide if they're
							//healthy enough to attack, and such stuff.
}



