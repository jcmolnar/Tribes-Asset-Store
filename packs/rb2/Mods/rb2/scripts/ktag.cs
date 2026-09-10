exec("game.cs");

//KTag Scripts

//Initalize
$ITplayer = 0;
$MaxNumKills = 50;

//Ammount of Time to check
$TKtime = 120;
//Number of Kills
$TKkickkills = 3;

function Client::onKilled(%playerId, %killerId, %damageType)
{
	%ITchanged = 0;

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
	%killerName = Client::getName(%killerId);

	%disptype = 0;

   if ((!%killerId) || (%damageType == $DebrisDamageType) || (%damageType == $MissileDamageType))
   {
		%message1 = strcat(Client::getName(%playerId), " died.");
		%message2 = "You died.";

      if(%playerId == $ITplayer)
      {
			//Bottom Messages
			%bmessage1 = strcat("'It' is up for grabs! (", %message1, ")" ); //PrintBottom to everyone Else
         %bmessage2 = strcat("You are no longer 'it'. (", %message2, ")" ); //PrintBottom to youself

			%bmessage1r = "<f1>\n-Kill anyone, before someone else does, to become 'it'."; //Global PrintBottom
			%bmessage2r = "<f1>\n-Kill anyone, before someone else does, to become 'it'."; //Global PrintBottom

			//Append Sounds
			%message1 = strcat(%message1, "~wflagreturn.wav");
			%message2 = strcat(%message2, "~wflagreturn.wav");

 			$ITplayer = 0;
			%ITchanged = 1;
			Game::refreshClientScore(%playerId);
			%disptype = 1; //Important

			Player::unmountItem(%playerId, $FlagSlot);
      }

		%playerId.scoreDeaths++;

		messageAllExcept( %playerId, %distype, %message1);
		messageToPlayer(%playerId, %disptype, %message2);

		//PrintBottom Messages

		if (%bmessage1 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage1, %bmessage1r );
			bprintAllExcept(%playerId, %bmessage);
		}

		if (%bmessage2 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage2, %bmessage2r );
			bprintToPlayer( %playerId, %bmessage );
		}


   }
   else if(%playerId == %killerId)
   {
		%message1 = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      %message2 = "You killed yourself.";

		//IT Committed Suicide
      if(%playerId == $ITplayer)
      {
			%bmessage1 = strcat(" 'It' is up for grabs! (", %message1, ")");
			%bmessage2 = strcat(" You are too stupid to be 'it' (", %message2, ")");

			%bmessage1r = "<f1>\n-Kill anyone, before someone else does, to become 'it'."; //Global PrintBottom
			%bmessage2r = "<f1>\n-Kill anyone, before someone else does, to become 'it'."; //Global PrintBottom

			%message1 = strcat(%message1, "~wflagreturn.wav");
         %message2 = strcat(%message2, "~wflagreturn.wav");


			$ITplayer = 0;
			Game::refreshClientScore(%playerId);
			%ITchanged = 1;
			%disptype = 1; //Important
      }
      messageAllExcept(%playerId, %disptype, %message1);
      messageToPlayer(%playerId, %disptype, %message2);
		%playerId.scoreDeaths++;

		if (%bmessage1 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage1, %bmessage1r );
			bprintAllExcept(%playerId, %bmessage);
		}

		if (%bmessage2 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage2, %bmessage2r );
			bprintToPlayer( %playerId, %bmessage );
		}
		//Player::unmountItem(%playerId, $FlagSlot);
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

      %message1 = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);
      %message2 = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);

      if(!$ITplayer)  // You are now IT
      {

			if(!String::ICompare(Client::getGender($ITplayer), "Male"))
		   {
		      %playerGender = "him";
				%playerGender2 = "he";
		   }
			else
			{
				%playerGender = "her";
				%playerGender2 = "she";
			}

         %bmessage1 = strcat( Client::getName(%killerId), " is now 'it'! (", %message1, ")");
         %bmessage2 = strcat( "You are now 'it'! (", %message2, ")" );

			%bmessage1r = strcat("<f1>\n-Kill ", %playerGender, " to become 'it'!",
											 "\n-If you kill anyone other than ", Client::getName($ITplayer), " you will lose a point!",
								    		 "\n-If ", Client::getName($ITplayer), " kills you, then ", %playerGender2, " will score a point!");
			%bmessage2r = strcat("<f1>\n-Kill anyone to score a point!",
			                         "\n-If you die, you will cease to be 'it'!");

         %message1 = strcat(%message1, "~wCapturedTower.wav");
         %message2 = strcat(%message2, "~wflagcapture.wav");

         $ITplayer = %killerId;
			Game::refreshClientScore(%killerId);
			%ITchanged = 1;

			//%disptype = 1; //Important

			Player::mountItem(%killerId, Flag, $FlagSlot);
			GameBase::applyDamage(%killerId,$ImpactDamageType,100,GameBase::getPosition(%killerId),"0 0 0","0 0 0",%KillerId);
			Client::sendMessage(%ITPlayer,0,"Part 1 successful.");
			GameBase::setAutoRepairRate(%ITPlayer, 10000);

      }
      else if($ITplayer == %killerId)  //Score A Point
      {
      		Client::sendMessage(%ITplayer,0,"Part score successful.  You scored a point.  Addhealth.");
		GameBase::setAutoRepairRate(%ITplayer, 10000);

	 %message1 = strcat(%message1, " ", Client::getName(%killerId), " scores a point!~wshieldhit.wav");
         %message2 = strcat(%message2, " You score!~wshieldhit.wav");
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			%disptype = 1; //Important
			KTAG::waypointClosest( %killerId );
      }
      else if($ITplayer == %playerId) //You are Now IT (by killing the ITplayer)
      {
		Client::sendMessage(%playerId,0,"Part score successful.  You became it.  Addhealth.");
			if(!String::ICompare(Client::getGender($ITplayer), "Male"))
		   {
		      %playerGender = "him";
				%playerGender2 = "he";
		   }
			else
			{
				%playerGender = "her";
				%playerGender2 = "she";
			}

         %bmessage1 = strcat( Client::getName(%killerId), " is now 'it'! (", %message1, ")");
         %bmessage2 = strcat( "You are now 'it'! (", %message2, ")" );

			%bmessage1r = strcat("<f1>\n-Kill ", %playerGender, " to become 'it'!",
											 "\n-If you kill anyone other than ", Client::getName($ITplayer), " you will lose a point!",
								    		 "\n-If ", Client::getName($ITplayer), " kills you, then ", %playerGender2, " will score a point!");
			%bmessage2r = strcat("<f1>\n-Kill anyone to score a point!",
			                         "\n-If you die, you will cease to be 'it'!");

         %message1 = strcat(%message1, "~wCapturedTower.wav");
         %message2 = strcat(%message2, "~wflagcapture.wav");


         $ITplayer = %killerId;
			Game::refreshClientScore(%playerId);
			Game::refreshClientScore(%killerId);
			%ITchanged = 1;

			Player::mountItem(%killerId, Flag, $FlagSlot);
			GameBase::applyDamage(%KillerId,$ImpactDamageType,100,GameBase::getPosition(%killerId),"0 0 0","0 0 0",%KillerId);
			Client::sendMessage(%ITplayer,0,"Part 2 successful.");


//			Player::unmountItem(%playerId, $FlagSlot);

			//%disptype = 1; //Important
      }
		else if(($ITplayer != %killerId) && ($ITplayer != %playerId) && ($ITplayer != 0)) //Killing Someone who is NOT it.
		{
			if(!String::ICompare(Client::getGender(%killerId), "Male"))
		   {
		      %heshe = "he";
		   }
			else
			{
				%heshe = "she";
			}
         %message1 = strcat(%message1, " ", Client::getName(%killerId), " loses a point!~wteleport2.wav");
         %message2 = strcat(%message2, " You lose a point!~wteleport2.wav");

			%bmessage2 = strcat("Kill ",Client::getName($ITplayer), ", ", %heshe, " is 'it'!");

			//Hurt Player
			//KTAG::killdamage(%killerId);
			KTAG::trakTK(%killerId, 0);

			//playerScored(%killerId, 1);
			%killerId.score--;
			Game::refreshClientScore(%killerId);
		}

		if (%disptype)
		{
			messageAllExcept(%killerId, 3, %message1);
		} else {
			messageAllExcept(%killerId, 0, %message1);
		}
		if (%disptype)
		{
      	messageToPlayer(%killerId, 3, %message2);
		} else {
			messageToPlayer(%killerId, 0, %message2);
		}

		if (%bmessage1 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage1, %bmessage1r );
			bprintAllExcept(%killerId, %bmessage);
		}

		if (%bmessage2 != "")
		{
			//Test Rules
			%bmessage = strcat( "<jc>", %bmessage2, %bmessage2r );
			bprintToPlayer( %killerId, %bmessage );
		}


   }

	//test and change way points if nessicary
	if (%ITchanged == 1)  //It has changed, need to update waypoints
	{
		if ($ITplayer == 0)  //One one is IT clear way points.
		{
			echo( "TAG: Clearining Waypoints!");
		   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
        		//setCommandStatus(%cl, 0, "'It' is up for grabs! Auto-waypoint cleared."); //Clear everyones waypoint
				KTAG::waypointClosest( %cl );
			}
		} else {  //Some one is IT set the way points
			echo( "TAG: Setting Waypoints!");
			%it = $ITplayer - 2048;
		   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{

      		if (%cl != $ITplayer)
				{
				 	issueTargCommand(%cl, %cl, 1, Client::getName($ITplayer) @ " is 'it'. Auto-waypoint set.", %it); //Set everyones waypoint
				}
			}
			//setCommandStatus($ITplayer, 0, "You are 'it'! Auto-waypoint cleared."); //Clear the 'it' players waypoint
			KTAG::waypointClosest( $ITplayer );
		}
	}

	//Call clientKilled

	Game::clientKilled(%playerId, %killerId);
}

//Set the waypoint to the closest enemy
function KTAG::waypointClosest( %clientId )
{
	%mindist = 9999;
	%newtarget = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%dist = Vector::getDistance(GameBase::getPosition(%clientId), GameBase::getPosition(%cl));

  		if ((%dist < %mindist) && (%cl != %clientId) && (!Player::isDead(%cl)))
		{
			%mindist = %dist;
			%newtarget = %cl - 2048;
			%newname = Client::getName(%cl);
		}
	}
	if( %newtarget )
	{
		issueTargCommand(%clientId, %clientId, 1, %newname @ " is the closest target. Auto-waypoint set.", %newtarget); //Set everyones waypoint
	} else {
		echo( "No new Target found");
	}

}

function Client::leaveGame(%clientId)
{
	if ($ITplayer == %clientID)
	{
		$ITplayer = 0;
		%message1 = strcat("<jc><f2>No one is 'it'! (", Client::getName(%clientId)," left the game)",
		                   "<f1>\n-Kill anyone, before someone else does, to become 'it'.");

		bprintAllExcept(%clientId, %message1);

		echo( "TAG: Clearining Waypoints!");

		//messageAll(3, strcat( "The 'it' has left the game. 'It' is up for grabs!"));

	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			KTAG::waypointClosest( %cl );
     		//setCommandStatus(%cl, 0, "'It' is up for grabs! Auto-waypoint cleared."); //Clear everyones waypoint
		}
	}
}

function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
	$trakTK[%playerId] = 0;
   Game::refreshClientScore(%playerId);
	KTAG::cleanup( 0 );
}


//Player has a total of 10 seconds per life allowed outside designated mission area.
//After a player expends this 10 sec, the player is remotely killed.
//-lesson to be learned= stay in the mission area!
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
   %cl = Player::getClient(%player);
   messageToPlayer(%cl, 1, "You have returned the mission area.~wmine_act.wav");

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

function KTAG::killdamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if (%client.TDcount < 1)
		%client.TDcount = 1;

	Player::setDamageFlash(%client, 0.75);
	GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.07);
	if (%client.TDcount < 5) {
		%client.TDcount++;
		//echo(%client.TDcount);
		schedule("KTAG::killdamage(" @ %client @ ");", 0.4);
	} else {
		%client.TDcount=1;
	}

}

function KTAG::trakTK(%client, %mode)
{
	if (%mode == 0) {
		$trakTK[%client]++;

		if($trakTK[%client] >= $TKkickkills) {
			bprintAllExcept( %client, "<jc>", Client::getName(%client), " was kicked. He didnt pay attention to the rules.");
			Net::kick(%client, "Pay attention to the RULES!");
		}

		schedule("KTAG::trakTK(" @ %client @ ", 1);", $TKtime);
	} else {
		$trakTK[%client]--;
	}
	if ($trakTK[%client] < 0)
		$trakTK[%client] = 0;

	echo(%client @ " TKs = " @ $trakTK[%client]);
}

function KTAG::cleanUp( %mode )
{
	if ($ITplayer != 0)
	{
		%found = 0;
   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if( %cl == $ITplayer)
			{
				%found = 1;
			}
		}

		if(!%found)
		{
			$ITplayer = 0;
			%message1 = "Reset due to invalid IT player.";
			%bmessage1 = strcat("'It' is up for grabs! (", %message1, ")" ); //PrintBottom to everyone Else
			%bmessage1r = "<f1>\n-Kill anyone, before someone else does, to become 'it'."; //Global PrintBottom
			%bmessage = strcat( "<jc>", %bmessage1, %bmessage1r );
			bprintAllExcept(-1, %bmessage);

	   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				Game::refreshClientScore(%cl);
				KTAG::waypointClosest( %cl );
			}


		}
	}

	echo( "Cleaning Up" );

	if( %mode == 1)
		schedule("KTAG::cleanup(1);", 180);
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
   // use this client's skin preference
   Client::setSkin(%clientId, $Client::info[%clientId, 0]);

   //spawn with only blaster and health kit
   Player::setItemCount(%clientId,$ArmorName[%armor],1);
   Player::setItemCount(%clientId,blaster,1);
   Player::setItemCount(%clientId,RepairKit,1);
   Player::setItemCount(%clientId,eagleammo,100);
   Player::setItemCount(%clientId,Handgrenade,2);
   Player::setItemCount(%clientId,EnergyPack,1);
	Player::useItem(%pl,DiscLauncher);
   	Player::useItem(%pl,EnergyPack);


	if (!$ITplayer)
	{
		%message1 = strcat("<jc><f2>No one is 'it'!",
		                   "<f1>\n-Kill anyone, before someone else does, to become 'it'.");
		//messageToPlayer(%clientId, 3, %message1);
		KTAG::waypointClosest( %clientId );
	} else {
		if(!String::ICompare(Client::getGender($ITplayer), "Male"))
	   {
	      %playerGender = "him";
			%playerGender2 = "he";
	   }
		else
		{
			%playerGender = "her";
			%playerGender2 = "she";
		}
		%targmessage = strcat(Client::getName($ITplayer), " is 'it'!");
		issueTargCommand(%clientId, %clientId, 1, %targmessage , $ITplayer - 2048); //Target 'it' with autowaypointing

		%message1 = strcat("<jc><f2>", Client::getName($ITplayer), " is 'it'!",
		                   "<f1>\n-Kill ", %playerGender, " to become 'it'!",
								     "\n-If you kill anyone other than ", Client::getName($ITplayer), " you will lose a point!",
								     "\n-If ", Client::getName($ITplayer), " kills you, then ", %playerGender2, " will score a point!");

		//messageToPlayer(%clientId, 1, %message1);
	}
	KTAG::dispbinfo ( %clientId, %message1, 0 );
}




//---------------------------------------------------------------------------------------
//
// KTAG
//
//---------------------------------------------------------------------------------------
function KTAG::checkMissionObjectives(%playerId)
{
   if(KTAG::missionObjectives(%playerId))
      schedule("nextMission();", 0);
	if($TAGScoreLimit > 0)
		if((Player::getClient(%playerId)).score >= $TAGScoreLimit) {
	      $timeLimitReached = true;
   	   $timeReached = 1;
			KTAG::missionObjectives();
			Server::nextMission();
		}
}

function KTAG::missionObjectives()
{
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
	for(%l = -1; %l < 1 ; %l++) {
		%lineNum = 0;
 	  	Team::setObjective(%l, %lineNum, "<f5>Tribes TAG!");
		Team::setObjective(%l, %lineNum++, " ");
		Team::setObjective(%l, %lineNum++, "<f5>Mission Information:");
		Team::setObjective(%l, %lineNum++, "<f1>   - Mission Name: " @ $missionName);
	   Team::setObjective(%l, %lineNum++, %str);
	   Team::setObjective(%l, %lineNum++, " ");
		if( !$timeLimitReached ) {
		if( $ITPlayer )
		{
	 		Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives for " @ Client::getName($ITPlayer) @ ":");
			Team::setObjective(%l, %lineNum++, "<f1>   -Kill all other players to SCORE a point!");
		 	Team::setObjective(%l, %lineNum++, "<f1>   -Stay alive!");
		   Team::setObjective(%l, %lineNum++, " ");
		 	Team::setObjective(%l, %lineNum++, "<f5>Mission Objectives for all other player:");
			Team::setObjective(%l, %lineNum++, "<f1>   -Kill the 'it' player to become 'it'!");
		 	Team::setObjective(%l, %lineNum++, "<f1>   -Stay alive! Dont let the 'it' player kill you!");
			Team::setObjective(%l, %lineNum++, "<f1>   -If you kill someone who is not 'it' you will <f4>LOSE<f1> a point! (If you do this too often, you will be kicked from the game)");
		} else {
	 	  	Team::setObjective(%l, %lineNum++, "<f5>No one is 'it' yet! Kill someone as fast as you can to become 'it'!");
			Team::setObjective(%l, %lineNum++, "<f1>   -Once you become 'it', everytime you kill someone you will score!");
		}

		Team::setObjective(%l, %lineNum++, " ");
	 	Team::setObjective(%l, %lineNum++, "<f1>Remember to stay within the mission area, which is defined by the extents of your commander screen map."	@
 	                                 " If you go outside of the mission area you will have 3 seconds to get back into the mission area, or you'll start taking damage!");
		}

		//Clear out the buffer.
		for(%s = %lineNum+1; %s < 30 ;%s++)
			Team::setObjective(%l, %s, " ");
	}
	$timeReached="";
}


function Game::refreshClientScore(%clientId)
{
	%it = "";
	if (%clientId == $ITplayer)
		%it = "X";

	Client::setScore(%clientId, "%n\t " @ %it @
	                            "\t " @ %clientId.score @
										 "\t %p\t %l", %clientId.score);
	KTAG::missionObjectives();
}


function Mission::init()
{
   setClientScoreHeading("Player Name\t\x78IT\t\x98Score\t\xC4Ping\t\xF0PL");

   $numTeams = getNumTeams();
   for(%i = 0; %i < $numTeams; %i++)
      $teamScore[%i] = 0;

   $SensorNetworkEnabled = true;
   setTeamScoreHeading("");
   //setClientScoreHeading("Player Name\t\x55Kills\t\x75Efficiency\t\xE3Ping\t\xFFPL");

   $dieSeqCount = 0;
   //setup ai if any
   AI::setupAI();
	KTAG::cleanup(1);
	KTAG::missionObjectives();
}


function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
      if(%cl != %except)
		{
         Client::sendMessage(%cl, %mtype, %message);
		}
	}
}

function messageToPlayer(%cl, %mtype, %message)
{
   Client::sendMessage(%cl, %mtype, %message);
}

function KTAG::dispbinfo( %client, %message, %showscores ) {
	bottomprint(%client, %message, 8);
}

function bprintAllExcept(%except, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
      if(%cl != %except)
		{
         bottomprint(%cl, %message, 8);
		}
	}
}

function bprintToPlayer(%cl, %message)
{
   bottomprint(%cl, %message, 8);
}