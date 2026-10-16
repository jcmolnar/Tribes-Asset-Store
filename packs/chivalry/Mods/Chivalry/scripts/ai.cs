//
// AI support functions.
//
exec ("BotMove");
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
$AI::defaultPathType = 0; //run oneWay paths. Changed from TwoWayPath by Werewolf

//armor types
//light = larmor
//medium = marmor
//heavy = harmor
$AI::defaultArmorType = "scarmor";




//------------------------------------------------------------------
//functions to test and move AI players.
//
//------------------------------------------------------------------

//
//This function will spawn an AI player about 5 units away from the 
//player that is passed to the function(%commandIssuer).
//
//
$numAI[0] = 0;
$numAI[1] = 0;
$numAI[2] = 0;
$numAI[3] = 0;
$numAI[4] = 0;
$numAI[5] = 0;
$numAI[6] = 0;
$numAI[7] = 0;

//
//This function will move an AI player to the position of an object
//that the players LOS is hitting(terrain included). Must be `	within 50 units.
//
//

//
// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//
function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{
   %aiId = BotFuncs::GetId( %name );
if (%aiId==0)
	return;
	
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
             AI::Jump(%aiId);                    //Just jumps. Much more convenient


              %BotRot = GameBase::getRotation(%aiId);
              if(GameBase::getLOSInfo(Client::getOwnedObject(%aiId), 150, %BotRot))    //Test if AI is within firing range
                {
//	          AI::DirectiveTargetPoint( %name, %worldLoc, 2);  //Fucks up AI::DirectiveList
                }
                else
                {
//	          AI::DirectiveWaypoint( %name, %worldLoc, 2);
                }



	          AI::DirectiveWaypoint( %name, %worldLoc, 3000);
	          schedule ("AI::DirectiveRemove(\"" @ escapeString(%name) @ "\", 3000);",10); // PORT: the name was spliced in unquoted

	   }
	   if( %command == 2 )  //Defend
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  
	      %worldLoc = WaypointToWorld ( %waypoint );

	      AI::DirectiveRemove( %name, 2 );   //Crude way to clear all directives. Needs to be done because else the bots won't
                                                 //respond to any new orders!
		AI::DirectiveFollow( %name, %commander, 0,3000);
             schedule ("AI::DirectiveRemove(\"" @ escapeString(%name) @ "\", 3000);",10); // PORT: the name was spliced in unquoted
		
         }

  	 if( %command == 3 )  //Repair
	 {
	     return;
	 }
 
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, cheer3 );
//


// Default periodic callback.  [Note by default it isn't called unless a frequency 
//    is set up using AI::CallbackPeriodic().  Type in that command to see how 
//    it works].  
function AI::onPeriodic( %aiName )
{
	   //dbecho(2, "onPeriodic() called with " @ %aiName );
}



//The following callbacks are responsible for the bot's chasing behaviour.
//modified by Werewolf

function AI::onDroneKilled(%aiName)
{
   if( ! $SinglePlayer )
   {

    %aiId = BotFuncs::GetId(%aiName);
    %team = GameBase::getTeam(%aiId);
    $Spoonbot::BotStatus[%aiId] = "Dead";
    %curTarget = ai::getTarget( %aiName );
    %targetName = Client::getName(%curTarget);

    $BotThink::Definitive_Attackpoint[%aiId] = "";  // ERROR: I think there's no player ID for a dead bot.
    $BotThink::ForcedOfftrack[%aiId] = true;

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
//messageall(0,"Drone Died");
   %aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
   %curTarget = %idNum;

   %team=Client::getTeam(%aiId);
	CheckHealth(%aiId);
   BotFuncs::DelAttackerFromAll(%aiId);	// Wicked69
   $BotThink::Definitive_Attackpoint[%aiId] = "";
   $BotThink::ForcedOfftrack[%aiId] = True;

   if(%curTarget == -1)
   {
   	return;
   }
      
   $Spoonbot::BotStatus[%aiId] = "Idle";
}                                 

function AI::onTargetLOSAcquired(%aiName, %idNum)
{
//messageall(0,"Got LOS");
CheckHealth(%aiId);
%aiId = BotFuncs::GetId(%aiName);               //Sometimes, switching teams make your own bots chase you like an enemy. This is very
if (%aiId==0)
	return;
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
//messageall(0,"LOS Lost");
%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
%aiTeam = Client::getTeam(%aiId);
%targetTeam = Client::getTeam(%idNum);
CheckHealth(%aiId);
if (%targetTeam != %aiTeam)
  {
//   dbecho(1, %aiName @ " lost eye contact to enemy");
   AI::HuntTarget(%aiName, %idNum, 1);

if ($Spoonbot::BotJetting[%aiId] != 1)
  AI::JetSimulation(%aiId, 0);


  }
}

function  CheckHealth(%aiId)
{
%aiObj = Client::getOwnedObject(%aiId);
if(GameBase::getDamageLevel(%aiObj) >= 0.5 && Player::getItemCount(%aiId, RepairKit) != 0)
{
Player::useItem(%aiId, RepairKit);
//messageall(0,"Used Repair Kit");
}
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
//messageall(0,"LOS Regained");
%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
%aiTeam = Client::getTeam(%aiId);
%targetTeam = Client::getTeam(%idNum);
CheckHealth(%aiId);
if (%targetTeam != %aiTeam)
  {
//   dbecho(1, %aiName @ " found the enemy again");
   AI::HuntTarget(%aiName, %idNum, 1);
   $SPOONBOT::AbortAIJet = %aiId;
  }
}




function AI::HuntTarget(%aiName, %idNum, %Follow) //If %Follow is 0 then waypoint will be updated. If 1 then Bot will follow regardless of LOS.
{
	//messageall(0,"AI::HuntTarget");
   %aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
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

    AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 30, 1);


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
//          AI::DirectiveRemove( %aiName, %order);
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
//          AI::DirectiveRemove( %aiName, %order);
        }
    }
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

function AI::Jet(%aiId)
{
	%passenger = %aiId;
	%armor = Player::getArmor(%passenger);

	if(%armor == "scarmor" || %armor == "scfemale" || %armor == "magarmor" || %armor == "magfemale") {
		%height = 15;
		%velocity = 70;
		%zVec = 40;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "worarmor" || %armor == "worfemale") {
		%height = 19;
		%velocity = 100;
		%zVec = 60;
	}
	else if(%armor == "palarmor" || %armor == "lavarmor") {
		%height = 22;
		%velocity = 140;
		%zVec = 90;
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

}

function AI::Jump(%aiId)      //This function makes the AI jump. If %jet=1 then it Calls the Jetpack Routine
{
    %passenger = %aiId;
	%armor = Player::getArmor(%passenger);
	if(%armor == "scarmor" || %armor == "scfemale" || %armor == "magarmor" || %armor == "magfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "worarmor" || %armor == "worfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "lavarmor" || %armor == "palarmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
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
}




function AI::shove(%aiId, %velocity, %zVec, %rotX, %rotY, %rotZ)
{
		%passenger = %aiId;
		%OldrotX = getWord(GameBase::getRotation(%passenger),0);
		%OldrotY = getWord(GameBase::getRotation(%passenger),1);
		%OldrotZ = getWord(GameBase::getRotation(%passenger),2);
		%rotation = (%OldrotX + %rotX) @ " " @ (%OldrotY + %rotY) @ " " @ (%OldrotZ + %rotZ);
		GameBase::setRotation(%passenger, %rotation);
		%jumpDir = Vector::getFromRot(%rotation, %velocity, %zVec);
		Player::applyImpulse(%passenger,%jumpDir);
}

function AI::EvadeUp(%aiId)         //For climbing towers, one powerful jump back, and one forward after 1 second
{
%velocity = -100;
%zVec = 200;
AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
%velocity = 120;
%zVec = 200;
//AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 0);", 1);
}


function AI::EvadeBackLeft(%aiId)   //Turn back, then left and try again.
{
%velocity = -100;
%zVec = 100;
AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
%velocity = 150;
%zVec = 100;
schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, -1.6);", 1);
}

function AI::EvadeBackRight(%aiId)  //Turn back, then right and try again.
{
%velocity = -100;
%zVec = 100;
AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
%velocity = 150;
%zVec = 100;
schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 1.6);", 1);
}

function AI::EvadeLeft(%aiId)       //Jump left
{
%velocity = 150;
%zVec = 100;
AI::shove(%aiId, %velocity, %zVec, 0, 0, -1.6);
}

function AI::EvadeRight(%aiId)      //Jump left
{
%velocity = 150;
%zVec = 100;
AI::shove(%aiId, %velocity, %zVec, 0, 0, 1.6);
}


function AI::RandomEvade(%aiId)      //Do anything of the above, randomly.
{
%evadeIdx = floor(getRandom() * (5 - 0.1));  // five possibilities
if (%evadeIdx == 0)
 {
AI::EvadeBackLeft(%aiId);
 }
else if (%evadeIdx == 1)
 {
AI::EvadeBackRight(%aiId);
 }
else if (%evadeIdx == 2)
 {
AI::EvadeUp(%aiId);
 }
else if (%evadeIdx == 3)
 {
AI::EvadeLeft(%aiId);
 }
else if (%evadeIdx == 4)
 {
AI::EvadeRight(%aiId);
 }
else if (%evadeIdx == 5)
 {
AI::EvadeBackLeft(%aiId);
 }
else if (%evadeIdx == 6)
 {
AI::EvadeBackRight(%aiId);
 }

return;
}

//The following function comes very close to human players jetting physics. This function calls itself over and over,
//each time applying a small amount of upward thrust to the AI. The variable "phase" is being increased with each call.
//The jetting time is limited, just like for human players.
//To make an AI start jetting, issue this function with "phase" set to 0. Then, this procedure will call itself every 0.5 seconds,
//each time increasing the "phase" variable.
//The AI will jet until "phase" = 6. Then, the AI will begin descending, while the descend speed is kept nominal by short thrusts 
//every 1 second. This prevents injuries.


//Note that once the jetting has started, the whole sequence is being executed. To STOP a jetting maneuver, set the 
//variable $SPOONBOT::StopAIJet to the aiId of the bot you want to stop jetting. If the jetting is being aborted, this function will
//set the "phase" variable to 6, thus starting to descend.


//What's the magic with AbortJet? Or better yet: What's the difference between STOPPING and ABORTING a jet maneuver?
//Well, let's assume you  want to issue a jet command, and don't know if the AI is already in the process of jetting. 
//You need to ABORT the first jetting, and schedule the NEW jetting command 1 or 2 seconds afterwards.
//This keeps the bots from climbing into the stratosphere.


function AI::JetSimulation(%aiId, %phase)         // Makes an AI jet like a real player.
{

if ($SPOONBOT::StopAIJet == %aiId)  //To stop a jet, set $SPOONBOT::StopAIJet to the aiId you want to stop jetting
 {
 if (%phase < 6 )
   %phase = 6;			     //Just skip the climb phases, and start to descend
 $SPOONBOT::StopAIJet = 0;
 }

if ($SPOONBOT::AbortAIJet == %aiId)  //AbortJet is similar to StopJet, only there will be no controlled descend afterwards
 {
 $SPOONBOT::AbortAIJet = 0;
 return;			     //When Aborting, the function will kill itself immediately.
 }

$Spoonbot::BotJetting[%aiId] = 1;

%velocity = 20;
%zVec = 100;
AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
%phase = %phase + 1;

if (%phase < 6)
 {
 $Spoonbot::BotJettingHeat[%aiId] = 1;
 schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 0.5);  //First 6 phases: climb
 return;
 }

$Spoonbot::BotJettingHeat[%aiId] = 0;  //The BotJettingHeat is only 1 if we're in climbing phase. This is for rocket turrets.

if (%phase < 10)
 {
 schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 1);    //After climbing, do a controlled descend.
 return;
 }

$Spoonbot::BotJetting[%aiId] = -1;

// if "phase" exceeds 10, then this function will simply stop keeping itself alive.
return;
}

function AI::JetToHeight(%aiId, %height, %phase)         // Makes an AI jet to a specified height. Here the phase variable is only for INTERNAL use!
{

	$Spoonbot::BotJetting[%aiId] = -1;
	$Spoonbot::BotJettingHeat[%aiId] = 0;

	%AiPos = GameBase::getPosition(%aiId);
	%zPos = getWord(%AiPos, 2);


					//If we reached our height, stop jetting and abort this function.
					//I tried a new trick here: I stop the jetting sooner if the bot already has a great upward speed.

	if (%phase >=8)
		{
		if ((%zPos+6) >= %height)
			{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
			}
		}

	if (%phase >=6)
		{
		if ((%zPos+5) >= %height)
			{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
			}
		}

	if (%phase >=4)
		{
		if ((%zPos+4) >= %height)
			{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
			}
		}


	$Spoonbot::BotJetting[%aiId] = 1;
	$Spoonbot::BotJettingHeat[%aiId] = 1;  //These vars make turrets track the jetting bots, and avoid "double-jetting"

	%velocity = 0;  //This is the forward velocity.

	%zVec = 150;

	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	%phase = %phase + 1;

	schedule("AI::JetToHeight(" @ %aiId @ ", " @ %height @ ", " @ %phase @ ");", 0.3); 
	
	//Reschedule this until bot reaches %height.

	return;
}

function Summon::SpawnBot(%player, %teamnum)
{	
		%playteam = GameBase::getTeam(%player);
		if($numAI[%playteam] >= 3)
		{
		%client = Player::getClient(%player);
		Client::sendMessage(%client,0,"Maximum number of Minions Summoned!");
		return -1;
		}
	   	%spawnPos = GameBase::getPosition(%player);  //+++Set to position of casting player	  
		%spawnRot = GameBase::getRotation(%player);
		  %rPos = %spawnRot;
	         %xPos = getWord(%spawnPos, 0);
	         %yPos = getword(%spawnPos, 1);
	         %zPos = getWord(%spawnPos, 2);
			%xPos += 3;
	         %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	
	         dbecho(1, "Random Spawn Position is: " @ %xPos @ "  " @ %yPos @ "  " @ %zPos);
	//messageall(0, "AI pos : "@%aiSpawnPos@"   Player pos: "@%spawnPos);
	
	//======================================================================================================================= Setup Bot Armors
$BotArmor[0] = "scarmor";
$BotArmor[1] = "scfemale";
$BotArmor[2] = "magarmor";
$BotArmor[3] = "magfemale";
$BotArmor[4] = "worarmor";
$BotArmor[5] = "worfemale";
$BotArmor[6] = "palarmor";
$BotArmor[7] = "lavarmor";

%ridx = floor(getRandom() * (8 - 0.01));
$BotArmorType = $BotArmor[%ridx];
	if($BotArmorType == "scarmor")
	%voice = "male3";
	else if($BotArmorType == "scfemale")
	%voice = "female3";
	else if($BotArmorType == "magarmor")
	%voice = "male2";
	else if($BotArmorType == "magfemale")
	%voice = "female2";
	else if($BotArmorType == "worarmor")
	%voice = "male4";
	else if($BotArmorType == "worfemale")
	%voice = "female4";
	else if($BotArmorType == "palarmor")
	%voice = "male1";
	else if($BotArmorType == "lavarmor")
	%voice = "male5";
	else %voice = "male1";
	    //================================================================================================================== Done Setting Up Armors
               $numAI[%playteam]++;  
		%teamname = getTeamName(%playteam);     
	      %newName = %teamname@" Minion "@$numAI[%playteam];
	      if( AI::spawn( %newName, $BotArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
	      {
		         %spawnSuccessfull = 1;
			 %aiId = BotFuncs::GetId(%newName);
	
			 //$BotThink::BotHome[%aiId] = %spawnPos; // Set AI homepoint as spawnpoint. Wicked69
	
		     //dbecho( 1, "AutoSpawn successfull for " @ %aiName );
	      }
		  else
	      {
	         dbecho( 1, "AutoSpawn error: Cannot spawn " @ %aiName );
			$numAI[%playteam]--;
			return -1;
	      }
	
	  //newObject("AI", SimGroup);
	  //newObject(%newName, SimGroup);
	  //newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
	 // addToSet(%newName, "Marker1");
	  //addToSet("AI", %newName);
	  //addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);	
	
	  %aiId = BotFuncs::GetId( %newName );
	  GameBase::setTeam(%aiId, %teamnum);
	  AI::setVar( %newName,  iq,  60 );
	  AI::setVar( %newName,  attackMode, 1);
	  AI::setVar( %newName,  pathType, $AI::defaultPathType);
	  

	  AI::setWeapons(%newName);
	
	// Add Bot think function to schedule - Wicked69
	
	  BotFuncs::InitVars( %aiId );      // Wicked69
	
	  Client::setSkin(%aiId, $Server::teamSkin[Client::getTeam(%aiId)]);  // Werewolf
	
    $BotThink::Definitive_Attackpoint[%aiId] = "";
    $BotThink::ForcedOfftrack[%aiId] = false; //was true - lesse what happens!

	  //BotThink::NormalBotBehaviour(%newName, %aiId);     // Wicked69
		//Player::setAnimation(%aiId, animData[42]);
	  schedule("BotMove::Move(" @ %aiId @ " );", 2);      // Werewolf

	  return ( %aiId );
}

function BotFuncs::GetId(%aiName)
{
//messageall(0,"BotFuncs::GetId");
	if (%aiName == "")
	{
		return 0;
	}
	return AI::GetId(%aiName);
}

function BotFuncs::InitVars(%aiId)
{
	//messageall(0,"BotFuncs::InitVars");
	%AiPos = GameBase::getPosition(%aiId);
	$Spoonbot::lastPosition[%aiId] = %AiPos;
	$Spoonbot::BotStatus[%aiId] = "Idle";
	$Spoonbot::Team0MedicTask = -1;
	$Spoonbot::Team1MedicTask = -1;
	$Spoonbot::BotJetting[%aiId] = -1;
	$Spoonbot::BotJettingHeat[%aiId] = 0;
	$BotFuncs::AttackerCount[%aiId] = 0;
	$BotFuncs::AttackerIndex[%aiId] = 0;
	$Spoonbot::RidingWith[%cl] = 0;
	BotFuncs::AddAttackerIndex(%aiId);
	$Spoonbot::MedicTask[%aiId] = -1;
	$Spoonbot::PainterTarget[%aiId]=0;
	$Spoonbot::Target[%aiId]=0;
	$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
}

function BotFuncs::AddAttackerIndex(%aiId)
{
//messageall(0,"BotFuncs::AddAttackerIndex");
// Find out of entry exits already

	%found = False;

	for(%x = 0; ((%x < $AttackerIndexCount) && (%found == False)); %x++)
		if($AttackerIndexIds[%x] == %aiId)
			%found = True;
	if(%found == False)
	{
		$AttackerIndexIds[$AttackerIndexCount] = %aiId;
		$AttackerIndexCount = $AttackerIndexCount + 1;
	}
}

function BotFuncs::NearestAttacker(%aiId, %MaxDistance, %SearchPrio)
{
	%BotPosistion = GameBase::getPosition(%aiId);

	%AttackerDistance = 999999; //  Very Large Number !
	%AttackerId = %aiId;
	%AttackerPrio = 999999;

	for(%i = 0; %i < $BotFuncs::AttackerIndex[%aiId]; %i++)
	{
		if($BotFuncs::Attackers[%aiId,%i] != 0)
		{
			%AttackerNominatePosition =	GameBase::getPosition($BotFuncs::Attackers[%aiId,%i]);
			%AttackerNominateDistance = Vector::getDistance(%BotPosistion,%AttackerNominatePosition) ;

			if (($BotFuncs::Priority[%aiId,%i] <= %AttackerPrio) &&
				(($BotFuncs::Priority[%aiId,%i] == %SearchPrio ) || (%SearchPrio == 0)) &&
				(%AttackerDistance > %AttackerNominateDistance) && // This one is nearer, if so use it!
				(!Player::isDead($BotFuncs::Attackers[%aiId,%i])))	//Bot Still Alive!
					{
						%AttackerDistance = %AttackerNominateDistance;
						%AttackerId = $BotFuncs::Attackers[%aiId,%i];
						%AttackerPrio = $BotFuncs::Priority[%aiId,%i];
					}
		}
	}
	
	if (%AttackerDistance > %MaxDistance)
		return 0;

	return %AttackerId;
}

function BotFuncs::CheckForLOS(%aiId, %object)
{
//messageall(0,"BotFuncs::CheckForLOS");
return BotTree::CheckLOS(GameBase::getPosition(Client::getOwnedObject(%aiId)), GameBase::getPosition(%object), 2000);
}

function BotTree::CheckLOS(%pos1,%pos2,%MaxDist)
{
	%Result = False;

	if(Vector::getDistance(%pos1,%pos2) < %MaxDist)
		if(GetLosInfo(%pos1, %pos2, 1) == 0)
			%Result = True;
	return %Result;
}

// AddAttacker Function
// Params Description
//
// 1. %aiId = Id if Bot Being Attacked
//
// 2. %attackerid = id of attacking object
//
// 3. %DeleteDistance = Distance for checks against which this entry is made for deletion
//
// 4. %Priority = Priority for future searches. Should follow following protocol.
//
//    1 - Used for defence Purposes
//
//    2 - Manual Entry via Command. e.g. User Request
//
//    3 - Help requests from other bots.
//
//    4 - AI own thoughts. e.g. guard decides to defend flag !
//
//    5 - Used for bot Tree Routing
//
// Returns True is added, False if entry already exits.
//

function BotFuncs::AddAttacker(%aiId, %attackerId, %DeleteDistance, %Priority)
{
	if (%aiId != %attackerId)
	{
		%found = False;

		for(%i = 0; ((%i < $BotFuncs::AttackerIndex[%aiId]) && (%found == False)); %i++) // Stop attacker being added to
		{																				// Attack List Twice (Or More !)
			if ($BotFuncs::Attackers[%aiId,%i] == %attackerId)
				%found = True;
		}

// If Attacker in list already

		if (%found == True)
			return False;

// Otherwise Add
		else
		{
		
// If AttackerCount = Index then there are no free slots so do a simple append
			if($BotFuncs::AttackerIndex[%aiId] == $BotFuncs::AttackerIndex[%aiId])
			{
				$BotFuncs::Attackers[%aiId,$BotFuncs::AttackerCount[%aiId]] = %attackerId;
				$BotFuncs::DeleteDistance[%aiId,$BotFuncs::AttackerCount[%aiId]] = %DeleteDistance;
				$BotFuncs::Priority[%aiId,$BotFuncs::AttackerCount[%aiId]] = %Priority;

				$BotFuncs::AttackerCount[%aiId] = $BotFuncs::AttackerCount[%aiId] + 1;
				$BotFuncs::AttackerIndex[%aiId] = $BotFuncs::AttackerIndex[%aiId] + 1;
			}
			else
			{

// Find gap and replace

				%found = False;

				for(%i = 0; ((%i < $BotFuncs::AttackerIndex[%aiId]) && (%found == False)); %i++)
				{
					if($BotFuncs::Attackers[%aiId,%i] == 0)
					{
						%found = True;

						$BotFuncs::Attackers[%aiId,%i] = %attackerId;
						$BotFuncs::DeleteDistance[%aiId,%i] = %DeleteDistance;
						$BotFuncs::Priority[%aiId,%i] = %Priority;
						$BotFuncs::AttackerCount[%aiId] = $BotFuncs::AttackerCount[%aiId] + 1;
					}
				}
			}
		}
	}

	return True;
}

function BotFuncs::DelAttackerFromAll(%attackerId)
{
	for(%x = 0; %x < $AttackerIndexCount; %x++)
	{
		// Remove Entries from Bot Lists. Returns True if Actually Deleted.

		if(BotFuncs::DelAttacker($AttackerIndexIds[%x], %attackerId) == True)
			BotThink::Think($AttackerIndexIds[%x],False);
		
	}
}

function BotFuncs::DelAttacker(%aiId,%attackerId)
{
	%found = False;

	for(%i = 0; ((%i < $BotFuncs::AttackerIndex[%aiId]) && (%found == False)); %i++)
	{
		if($BotFuncs::Attackers[%aiId,%i] == %attackerId)
		{
			$BotFuncs::Attackers[%aiId,%i] = 0;
			$BotFuncs::AttackerCount[%aiId] = $BotFuncs::AttackerCount[%aiId] - 1;

			%found = True;
		}
	}

	return %found;
}

function BotFuncs::CheckAlive(%aiId)
{
if (%aiId==0)
	return false;
if (%aiId==-1)
	return false;

if ($Spoonbot::BotStatus[%aiId] == "Dead")
	return false;

%player = Client::getOwnedObject(%aiId);

if (Player::isDead(%player))
    {
		return false;
    }

    %aiName = Client::getName(%aiId);

//The following needs to be done in case
//IsDead doesn't work in this version

    %newId = BotFuncs::GetId(%aiName);
    if (%newId != %aiId)
    {
		return false;
    }
    if (%newId == 0)
    {
		return false;
    }

return true;
}

function AI::setWeapons(%aiName)
{
//messageall(0,"AI::setWeapons");
	%aiId = AI::getId(%aiName);
	
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
	%armor = Player::getArmor(%aiId);
	if(%armor == "magarmor" || %armor == "magfemale")
	{
		Player::setItemCount(%aiId, Stasis, 1);
		Player::setItemCount(%aiId, Inferno, 1);
		Player::setItemCount(%aiId, Fingers, 1);
		Player::setItemCount(%aiId, EmpSpell, 1);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::setItemCount(%aiId, ShieldPack, 1);
		Player::mountItem(%aiId, ShieldPack, 1);
		Player::mountItem(%aiId, Inferno, 0);
	}
	else if(%armor == "scarmor" || %armor == "scfemale")
		{
		Player::setItemCount(%aiId, Shredder, 1);
		Player::setItemCount(%aiId, ShredderAmmo, 40);
		Player::setItemCount(%aiId, Scattergun, 1);
		Player::setItemCount(%aiId, ScattergunAmmo, 8);
		Player::setItemCount(%aiId, Blaster, 1);
		Player::setItemCount(%aiId, EnergyPack, 1);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::mountItem(%aiId, EnergyPack, 1);
		Player::mountItem(%aiId, Shredder, 0);
		}
	else if(%armor == "worarmor" || %armor == "worfemale")
		{
		Player::setItemCount(%aiId, Chaingun, 1);
		Player::setItemCount(%aiId, BulletAmmo, 150);
		Player::setItemCount(%aiId, Disclauncher, 1);
		Player::setItemCount(%aiId, DiscAmmo, 15);
		Player::setItemCount(%aiId, Predator, 1);
		Player::setItemCount(%aiId, PredatorAmmo, 50);
		Player::setItemCount(%aiId, PlasmaGun, 1);
		Player::setItemCount(%aiId, PlasmaAmmo, 40);
		Player::setItemCount(%aiId, RepairPack, 1);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::mountItem(%aiId, RepairPack, 1);
		Player::mountItem(%aiId, Disclauncher, 0);
		}
	else if(%armor == "palarmor") // Line 1513
		{
		Player::setItemCount(%aiId, Slingshot, 1);
		Player::setItemCount(%aiId, SlingshotAmmo, 8);
		Player::setItemCount(%aiId, GrenadeLauncher, 1);
		Player::setItemCount(%aiId, GrenadeAmmo, 15);
		Player::setItemCount(%aiId, Mortar, 1);
		Player::setItemCount(%aiId, MortarAmmo, 10);
		Player::setItemCount(%aiId, StormLauncher, 1);
		Player::setItemCount(%aiId, StormLauncherAmmo, 100);
		Player::setItemCount(%aiId, EnergyPack, 1);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::mountItem(%aiId, StormLauncher, 0);
		Player::mountItem(%aiId, EnergyPack, 1);
		}
	else if(%armor == "lavarmor")
		{
		Player::setItemCount(%aiId, Stubber, 1);
		Player::setItemCount(%aiId, StubberAmmo, 100);
		Player::setItemCount(%aiId, Mortar, 1);
		Player::setItemCount(%aiId, MortarAmmo, 10);
		Player::setItemCount(%aiId, DaHammer, 1);
		Player::setItemCount(%aiId, DaHammerAmmo, 10);
		Player::setItemCount(%aiId, HvyPlasma, 1);
		Player::setItemCount(%aiId, HvyPlasmaAmmo, 60);
		Player::setItemCount(%aiId, Predator, 1);
		Player::setItemCount(%aiId, PredatorAmmo, 50);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::setItemCount(%aiId, AmmoPack, 1);
		Player::mountItem(%aiId, AmmoPack, 1);
		Player::mountItem(%aiId, DaHammer, 0);
		}
	else
		{
		Player::setItemCount(%aiId, Chaingun, 1);
		Player::setItemCount(%aiId, BulletAmmo, 150);
		Player::setItemCount(%aiId, Disclauncher, 1);
		Player::setItemCount(%aiId, DiscAmmo, 15);
		Player::setItemCount(%aiId, Predator, 1);
		Player::setItemCount(%aiId, PredatorAmmo, 50);
		Player::setItemCount(%aiId, PlasmaGun, 1);
		Player::setItemCount(%aiId, PlasmaAmmo, 40);
		Player::setItemCount(%aiId, RepairPack, 1);
		Player::setItemCount(%aiId, RepairKit, 2);
		Player::mountItem(%aiId, RepairPack, 1);
		Player::mountItem(%aiId, Disclauncher, 0);
		}

		
       }
   
    AI::SetVar(%aiName, triggerPct, 0.5 );
   AI::setVar(%aiName, iq, 60 );
   AI::setVar(%aiName, attackMode, 1);
   AI::setAutomaticTargets( %aiName );
   AI::callbackPeriodic(%aiName, 5, AI::periodicWeaponChange);
}

function AI::periodicWeaponChange(%aiName)
{
	//dbecho(2, %aiName @ " thinking....");
   %aiId = AI::getId(%aiName);
   %curTarget = ai::getTarget( %aiName );
   
   if(%curTarget == -1)
   {
   	//return;
   }
      
   //dbecho(1, %aiName @ " target: " @ %curTarget);	
   
   %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %targetDist = Vector::getDistance(%aiLoc, %targLoc);
   //dbecho(2, "distance to target: " @ %targetDist @ 
          //        " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);
                  
	%armor = Player::getArmor(%aiId);
	%rand = floor(getRandom() * (3 - 0.01));

   if(%targetDist > 100)
   {
	if(%armor == "magarmor" || %armor == "magfemale")
	{
	$Weapon[0] = "Stasis";
	$Weapon[1] = "Inferno";
	$Weapon[2] = "EmpSpell";
	}
	else if(%armor == "scarmor" || %armor == "scfemale")
	{
	$Weapon[0] = "Shredder";
	$Weapon[1] = "Blaster";
	$Weapon[2] = "Blaster";
	}
	else if(%armor == "worarmor" || %armor == "worfemale")
	{
	$Weapon[0] = "Disclauncher";
	$Weapon[1] = "Chaingun";
	$Weapon[2] = "Chaingun";
	}
	else if(%armor == "palarmor")
	{
	$Weapon[0] = "Mortar";
	$Weapon[1] = "Slingshot";
	$Weapon[2] = "StormLauncher";
	}
	else if(%armor == "lavarmor")
	{
	$Weapon[0] = "DaHammer";
	$Weapon[1] = "Mortar";
	$Weapon[2] = "Stubber";
	}
   	Player::mountItem(%aiId, $Weapon[%rand], 0);
      AI::SetVar(%aiName, triggerPct, 0.5 );
   }   
   else
   {
      //dbecho(2, "checking for target jet...");
     // dbecho(2, "jetting? " @ Player::isJetting(%curTarget));
      if(Player::isJetting(%curTarget))
      {	
		if(%armor == "scarmor" || %armor == "scfemale")
		{
		$Weapon[0] = "Shredder";
		$Weapon[1] = "Blaster";
		$Weapon[2] = "Blaster";
		}
		else if(%armor == "magarmor" || %armor == "magfemale")
		{
		$Weapon[0] = "Stasis";
		$Weapon[1] = "Inferno";
		$Weapon[2] = "EmpSpell";
		}
		else if(%armor == "worarmor" || %armor == "worfemale")
		{
		$Weapon[0] = "Disclauncher";
		$Weapon[1] = "Chaingun";
		$Weapon[2] = "Chaingun";
		}
		else if(%armor == "palarmor")
		{
		$Weapon[0] = "GrenadeLauncher";
		$Weapon[1] = "Slingshot";
		$Weapon[2] = "StormLauncher";
		}
		else if(%armor == "lavarmor")
		{
		$Weapon[0] = "HvyPlasma";
		$Weapon[1] = "DaHammer";
		$Weapon[2] = "Stubber";
		}
         Player::mountItem(%aiId, $Weapon[%rand], 0);
         AI::SetVar(%aiName, triggerPct, 0.8 );
      }
      else
      {
		if(%armor == "magarmor" || "magfemale")
		{
		$Weapon[0] = "Stasis";
		$Weapon[1] = "Inferno";
		$Weapon[2] = "Fingers";
		}
		else if(%armor == "scarmor" || %armor == "scfemale")
		{
		$Weapon[0] = "Shredder";
		$Weapon[1] = "Scattergun";
		$Weapon[2] = "Blaster";
		}
		else if(%armor == "worarmor" || %armor == "worfemale")
		{
		$Weapon[0] = "Chaingun";
		$Weapon[1] = "Predator";
		$Weapon[2] = "PlasmaGun";
		}
		else if(%armor == "palarmor")
		{
		$Weapon[0] = "Slingshot";
		$Weapon[1] = "StormLauncher";
		$Weapon[2] = "GrenadeLauncher";
		}
		else if(%armor == "lavarmor")
		{
		$Weapon[0] = "HvyPlasma";
		$Weapon[1] = "Predator";
		$Weapon[2] = "Stubber";
		}
         Player::mountItem(%aiId, $Weapon[%rand], 0);  
         AI::SetVar(%aiName, triggerPct, 0.8 );
      }   
   }
}


function BotFuncs::Delta(%a, %b)	//Returns the difference between two numbers, regardless if positive or negative
{
if (%a<0)	//Make both variables positive
 %a = 0 - %a;
if (%b<0)
 %b = 0 - %b;

if (%a >= %b)
 %diff = %a - %b;
if (%b > %a)
 %diff = %b - %a;

return %diff;
}

function BotFuncs::CheckForItemLOS(%aiId, %object)
{
return BotTree::CheckItemLOS(GameBase::getPosition(Client::getOwnedObject(%aiId)), GameBase::getPosition(%object), 200);
}

function BotTree::CheckItemLOS(%pos1,%pos2,%MaxDist)
{
	%Result = False;

	%xPos = getWord(%pos1, 0);                   //Now add some height to coordinates to make sure we get a correct LOS
	%yPos = getword(%pos1, 1);
	%zPos = getWord(%pos1, 2) + 1.5;
	%pos1 = %xPos @ "  " @ %yPos @ "  " @ %zPos;

	%xPos = getWord(%pos2, 0);
	%yPos = getword(%pos2, 1);
	%zPos = getWord(%pos2, 2) + 0.5;
	%pos2 = %xPos @ "  " @ %yPos @ "  " @ %zPos;


	if(Vector::getDistance(%pos1,%pos2) < %MaxDist)
		if(GetLosInfo(%pos1, %pos2, 1) == 0)
			%Result = True;
	return %Result;
}

function BotFuncs::Attack(%aiId, %object)  //The same as AttackObject, but it expects an ID
{
	//messageall(0,"On Attack.");
	%aiName = Client::GetName(%aiId);
	BotFuncs::AttackObject(%aiName, %object);
}

function BotFuncs::AttackObject(%aiName, %object)   // %object=Obj. ID of the structure (turret, station, etc) to fire at.
{
	%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;

	if (!BotFuncs::CheckForLOS(%aiId, %object)) //No LOS, so move towards target
	{
	$Spoonbot::BotStatus[%aiId] = "Repositioning";
	//AI::DirectiveWaypoint(%aiName, GameBase::GetPosition(%object), 255); //DISABLE ONCE TREECODE FULLY FUNCTIONAL

	$BotThink::Definitive_Attackpoint[%aiId] = %object;
	$BotThink::Definitive_Attackpos[%aiId] = GameBase::GetPosition(%object);
	$BotThink::ForcedOfftrack[%aiId] = true;
	$BotThink::LastPoint[%aiId] = false;


//	schedule ("AI::DirectiveRemove(" @ %aiName @ ", 5000);", 5);
	}
	if (BotFuncs::CheckForLOS(%aiId, %object)) //We have LOS, so delete previous move command
	{
	$Spoonbot::BotStatus[%aiId] = "Firing";
	//AI::DirectiveRemove(%aiName, 5000);				//DISABLE ONCE TREECODE FULLY FUNCTIONAL
	BotFuncs::AttackObjectFunction(%aiName, %object);		//Attack Target
	//BotFuncs::CheckIfTargetDestroyed(%aiName, %object);	//Cease Fire if destroyed
	}


}

function BotFuncs::AttackObjectFunction(%aiName, %object)   // %object=Obj. ID of the structure (turret, station, etc) to fire at.
{
	//messageall(0,"Attacking Object");
	%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
		%object.TargetPower = true;
		$Spoonbot::BotStatus[%aiId] = "Firing";
		%target = GameBase::getPosition(%object);
		%damage = GameBase::getDamageLevel(%object);
		%team = GameBase::getTeam(%object);
		%name = GameBase::getDataName(%object);

	AI::DirectiveTargetPoint(%aiName, %target, 5000); //was 255
	//schedule ("AI::DirectiveRemove(" @ %aiName @ ",5000,%aiId);", 5);  //changed from 5
	//BotFuncs::CheckIfTargetDestroyed(%aiName, %object);		
}

function BotFuncs::CheckIfTargetDestroyed(%aiName, %object)
{
	//messageall(0,"Checking if Object "@%object@" destroyed");
	%damage = GameBase::getDamageLevel(%object);
	if (%damage >= 0.7)		//Rocket Turrets have 7.5 if destroyed, having a 1.0 here resulted in the bots not stopping to attack a destroyed rocket Turret.
	{
		BotFuncs::AttackObjectCeaseFire(%aiName);
		return;
	}
	%aiId = BotFuncs::getId(%aiName);
	if(%aiId == 0)
	return;

	//schedule("BotFuncs::CheckIfTargetDestroyed("@%aiName@","@ %object@");",4);

}

function BotFuncs::AttackObjectCeaseFire(%aiName)
{
	//messageall(0,"Cease Fire.");
	%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
	AI::DirectiveRemove(%aiName, 5000);
	//$Spoonbot::PainterTarget[%aiId]=0;
}

function BotFuncs::DeleteAllAttackPointsByPrio(%Id, %Prio)
{
	for(%i = 0; (%i < $BotFuncs::AttackerIndex[%aiId]); %i++)
		if	(($BotFuncs::Attackers[%aiId,%i] != 0 )  &&
			($BotFuncs::Priority[%Id,i] == %Prio))
			$BotFuncs::Attackers[%aiId,%i] = 0;
}


function BotFuncs::ClearVars(%aiId)
{
	$Spoonbot::BotStatus[%aiId] = "Idle";
	$BotFuncs::AttackerCount[%aiId] = 0;
	$BotFuncs::AttackerIndex[%aiId] = 0;
	$Spoonbot::MedicTask[%aiId] = -1;
	$Spoonbot::Target[%aiId]=0;
	$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
}

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