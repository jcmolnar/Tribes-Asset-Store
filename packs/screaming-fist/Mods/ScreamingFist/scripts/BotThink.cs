echo("Loading Screaming Fist Version");
// Bot Think Function by Wicked69 (Paul@Lathope.demon.co.uk) Started 6/11/1999.





//Main Bot think function calls itself recursively each second

function BotThink::Think(%aiId,%requeue)
{
if ($Spoonbot::DebugMode)
 echo ("CALL BotThink::Think("@ %aiId @ ", " @ %requeue @ ");");


//Sanity check. Check if Bot is alive. If not then clear Vars and abort functiom
//----------------------------------------
//Werewolf
   %player = Client::getOwnedObject(%aiId);
   if (Player::isDead(%player))
     {
	BotFuncs::ClearVars(%aiId);
	return;
     }

   %aiName = Client::getName(%aiId);

//	if(BotTypes::IsRecorder(%aiName) == 1)
//	{
//			BotTree::AddTreePoint(%aiId);
//	}

//The following needs to be done in case
//IsDead doesn't work in this version
   %newId = AI::getId(%aiName);
   if (%newId != %aiId)
     {
	BotFuncs::ClearVars(%aiId);
	return;
     }


// Tidy Attacker List

	BotFuncs::TidyAttackerList(%aiId);



//----------------------------------------
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Bot alive check passed for ID " @ %aiId @ " Name " @ %aiName);




// Generic variables

	%aiName = Client::getName(%aiId);
	%aiTeam = Client::getTeam(%aiId);
//
//
// Start if main AI action 'IF' sequence
//
//


if (BotFuncs::CheckIfBusyWithRepairs(%aiName) == 1)
 {

//if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Busy with Repairs, Requeue: " @ %aiId @ ", True");

	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);

   return;
 }



	if (Player::getMountedItem(%aiId, $FlagSlot) != -1)   //If bot has the enemy's flag, get it to our flag
	{
if ($Spoonbot::DebugMode)
 // echo ("STATUS BotThink::Think = Flagrunner " @ %aiName @ " has the enemy flag");
if ($Spoonbot::DebugMode)
// echo ("STATUS BotThink::Think = Flagrunner " @ %aiName @ " tries to bring the enemy flag to our flagstand");
	BotFuncs::ReturnTheFlag(%aiName);
	}


// Check to see if AI is healthy. If not get help.

        else if (BotFuncs::IsHealthy(%aiId) == False) // Not Healthy. Return to Base (Or Find a Medic?)
	{
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = IsHealthy returned False");


// Lets see if we've got a repair kit. If so use it.

		%kitcount = Player::GetItemCount(%aiId,RepairKit);

		if(%kitcount > 0)
		{
			Player::useItem(%aiId,RepairKit); // Not sure about this one - Wicked69
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Using Repairkit");

		}
		else
		{

// Lets find a medic!

			%Medic = BotFuncs::FindNearestTeamAI(%aiId, 0, 500, 0, "Medic");
	
			if (%Medic == 0) // Not Found
			{
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = No Medic found, returning to base.");

				//Return to Base, no medic available !
				AI::DirectiveWaypoint( %aiName, $BotThink::BotHome[%aiId], 2, 0 );
				$Spoonbot::BotStatus[%aiId] = "Retreating";

			}
			else
		 
// Goto Medic and get Medic to come to me. Could be interesting to see them pass each other!

			{
				%MedicName = Client::getName(%Medic);
	
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Meeting medic " @ %MedicName);

// Ask medic to come to me

				BotFuncs::AddAttacker(%Medic, %aiId, 30, 3);

// Go to Medic

				BotFuncs::AddAttacker(%aiId, %Medic, 30, 3);
				AI::HuntTarget(%aiName, %Medic, 1);
				$Spoonbot::BotStatus[%aiId] = "Visit Medic";
			}
		}
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = End Medic stuff ");
	}



// Else Check to see if bot is under attack

	else if(BotFuncs::IsUnderAttack(%aiId) > 0) // Under Attack. Respond (Or run!)
	{

if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Under Attack");

		%Attacker = BotFuncs::NearestAttacker(%aiId, 200, 1);

// Attacker Found if ID > 0, Set It as Target

    	if (%Attacker > 0)
		{
			$Spoonbot::BotStatus[%aiId] = "Attacking";
			AI::HuntTarget(%aiName, %Attacker, 1);
		}
		else
//Nearest attacker too far away... So delete him
		{
			$Spoonbot::BotStatus[%aiId] = "Lost Target";
			%Attacker = BotFuncs::NearestAttacker(%aiId, 99999, 1);
			BotFuncs::DelAttacker(%aiId,%Attacker);
		}

		if (BotFuncs::IsUnderAttack(%aiId) > 1) 
// More than one attacker, lets drum up support
		{
		    BotFuncs::TeamMessage(%aiTeam, %aiName @ ": Somebody help...");
			$Spoonbot::BotStatus[%aiId] = "Need Help";

			%animation = $PlayerAnim::OverHere;
			BotFuncs::Animation(%aiId, %animation);

			%TeamMateId = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, 0, "");

			if (%TeamMateId != 0)
			{
				if(BotFuncs::AddAttacker(%TeamMateId,%Attacker,50,3))
					BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMateId) @ ": Coming");
			%animation = $PlayerAnim::Salute;
			BotFuncs::Animation(%TeamMateId, %animation);
			}

			if (BotFuncs::IsUnderAttack(%aiId) > 2)

// More than two attackers, lets drum up more support !
			{
			    BotFuncs::TeamMessage(%aiTeam, %aiName @ ": I need more help ...");
			%animation = $PlayerAnim::OverHere;
			BotFuncs::Animation(%aiId, %animation);

				%TeamMate2Id = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, %TeamMateId, "");

				if (%TeamMate2Id != 0)
				{

					if(BotFuncs::AddAttacker(%TeamMate2Id,%Attacker,50,3))
						BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMate2Id) @ ": Im on my way ...");
						$Spoonbot::BotStatus[%aiId] = "Helping";
						%animation = $PlayerAnim::Wave;
						BotFuncs::Animation(%TeamMateId, %animation);

				}
			}
		}


// Now Select Most Appropriate Weapon - Code from original AI.CS ? Wicked69
// If Player is Jetting use laser Etc else use ground tool

// Use shields if Appropriate

//		if(BotTypes::IsGuard(%aiName) == 1)
//		{
//			Player::useItem(%aiId, "beacon") ;
//		}
//
//        // AI::Jump(%aiId);				//Do some jumping so we're not standing around like living targets.
//		// schedule("AI::Jump(" @ %aiId @ ");", 2);      //I mean if you were shot at, what would YOU do ?!?
//		// schedule("AI::Jump(" @ %aiId @ ");", 3);
//		// schedule("AI::Jump(" @ %aiId @ ");", 5);
//		// schedule("AI::Jump(" @ %aiId @ ");", 6);
//		// schedule("AI::Jet(" @ %aiId @ ");", 7);
//		// schedule("AI::Jump(" @ %aiId @ ");", 9);

	}




// User Requested Move
	else if (BotFuncs::NearestAttacker(%aiId, 500, 2) != 0)
	{
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = User requested move");

		%UserRequest = BotFuncs::NearestAttacker(%aiId, 500, 2);

		if (%UserRequest == 0)
//Nearest request too far away... So delete it
		{
			%UserRequest = BotFuncs::NearestAttacker(%aiId, 99999, 2);
			BotFuncs::DelAttacker(%aiId,%UserRequest);
		}
		else

		// Go to User Requeted Location

			AI::HuntTarget(%aiName, %UserRequest, 1);
			$Spoonbot::BotStatus[%aiId] = "Moving";
	}






// AI Team Mate Requested Move
	else if (BotFuncs::NearestAttacker(%aiId, 500, 3) != 0)
	{
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = AI Teammate requested move");

		%AIRequest = BotFuncs::NearestAttacker(%aiId, 500, 3);

		if (%AIRequest == 0)
//Nearest request too far away... So delete it
		{
			%AIRequest = BotFuncs::NearestAttacker(%aiId, 99999, 3);
			BotFuncs::DelAttacker(%aiId,%AIRequest);
		}
		else

// Go to AI Requeted Location
		$Spoonbot::BotStatus[%aiId] = "Helping AI";

		AI::HuntTarget(%aiName, %AIRequest, 1);
	}




// Self Goal Move eg. defend base, go to base etc.

	else if (BotFuncs::NearestAttacker(%aiId, 99999, 4) != 0)
	{
		if ($Spoonbot::DebugMode)
			echo ("STATUS BotThink::Think = Self goal move");

		%AIRequest = BotFuncs::NearestAttacker(%aiId, 99999, 4);

//		if(BotThink::getWordCount(%AIRequest) != 1)
//				%Attackerpos = $BotFuncs::Attackers[%aiId,%i];
//			else
//				%Attackerpos = GameBase::getPosition($BotFuncs::Attackers[%aiId,%i]);

		%Distance = Vector::getDistance(GameBase::getPosition(%aiId), %AIRequest);

		//dbecho(1,"Distance = " @ %Distance);

		%DiffHeight = getWord(%AIRequest,2) - (getWord(GameBase::getPosition(%aiId),2));

		//dbecho(1, "DiffHeight = " @ %DiffHeight);

// Get Bot to start jetting when/if target is a 45 degrees - crude interpretation

		if(%DiffHeight > (%Distance/ 2))
			AI::JetToHeight(%aiId, (getWord(%AIRequest,2) + 3));

		//dbecho(1, %aiId @ " current waypoint = " @ %AIRequest @ ", distance = " @ %Distance );

// Go to AI Requested Location

		AI::DirectiveWaypoint( %aiName, %AIRequest, 2, 2 );
		$Spoonbot::BotStatus[%aiId] = "Lost Target"; // What's shis for ? <Wicked69>
	}


// Roaming Bot. look for local enemy else go wandering

	else if (BotTypes::IsRoam(%aiName))
	{

if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Roaming code running...");

		%attacking = False;
		if ($Spoonbot::HuntFlagrunner == 0)      //Check if in Normal mode or if bots are chasing a flagrunner
		{

			%spawnIdx = floor(getRandom() * ($Spoonbot::NumBots - 0.1));  //Add a random variation to the target selection

			//   %startCl = Client::getFirst() + %spawnIdx;  //This has caused the bots to not attack unless a player is present.

			%startCl = 2048 + %spawnIdx;                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!

			%endCl = %startCl + 90;
   
			for(%cl = %startCl; ((%cl < %endCl) && (%attacking == False)); %cl++)
			{
		        %targetTeam = Client::getTeam(%cl);

				if (%targetTeam != %aiTeam)           //Is this an enemy?
				{


					%player = Client::getOwnedObject(%cl);
					if (!Player::isDead(%player))
				    {
						%enemyName = Client::getName(%cl);
						if (%enemyName != "")
						{
							AI::HuntTarget(%aiName, %cl, 1);
							$Spoonbot::BotStatus[%aiId] = "Attacking";
							if ($Spoonbot::DebugMode)
							  echo ("STATUS BotThink::Think = " @ %aiName @ " has decided to attack " @ %enemyName);
						    	%attacking = True;
						}
						else if (!BotTypes::IsMedic(%aiName))
						{
							$Spoonbot::BotStatus[%aiId] = "Getting Flag";
							BotFuncs::GetTheFlag(%aiName);
							if ($Spoonbot::DebugMode)
							  echo ("STATUS BotThink::Think = " @ %aiName @ " has decided to go for the enemy flag");
						    	%attacking = True;
						}
					}
				}
			}
		}
		else
		{


//----------All this stuff is now inside BotFuncs.cs------------

			%cl = $Spoonbot::HuntFlagrunner;
			%aiTeam = Client::getTeam(%aiId);
			%targetTeam = Client::getTeam(%cl);
			if (%targetTeam != %aiTeam)           //Is this an enemy?
			{
				%player = Client::getOwnedObject(%cl);
				if (!Player::isDead(%player))
				{
					%enemyName = Client::getName(%cl);
					AI::HuntTarget(%aiName, %cl, 1);
					if ($Spoonbot::DebugMode)
					  echo (%aiName @ " has decided to attack enemy flagrunner" @ %enemyName);
					$Spoonbot::BotStatus[%aiId] = "Attacking Flagrunner";

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
				   	AI::HuntTarget(%aiName, %cl, 1);  //The procedure is the same, except the friendly bot won't fire on the flagrunner
					if ($Spoonbot::DebugMode)
				   	  echo(%aiName @ " is escorting the friendly flagrunner " @ %enemyName);
					$Spoonbot::BotStatus[%aiId] = "Escorting Flagrunner";

				}
		 	   }
		        }
//--------------------------------------------------------------
		}

// End of Original Roam Code

	}
	else // Non Roaming. give AI a job to do eg defend base, based on AI type eg Guard.
		 // Note code is not used until AI has reached previous goal via code above.
	{
// Main role for Non Roaming Bots is to defend base

// Frig to stop code running  for Tree Point Testing

		if(1 == 0)
		{
	    //%group = nameToID("MissionGroup/Teams/team" @ %AIteam @ "/Buildings");
		%group = nameToID("MissionGroup/Teams/team" @ %AIteam @ "/Powered");
		%count = Group::objectCount(%group); // + 1 for flag defending !
		//%mod = %aiId - (floor(%aiId / %count) * %count); // Creates Semi Dispersed Method For Selecting Defent Points. Wicked69
		//Didn't like this, wasnt random enough !
		//Therfor...

		%mod = floor(getRandom() * (%count+1+(%count/3)));  // one in three chance of defending flag ! - I think !

		if(%mod >= %count)
			%defendpoint = nameToID("MissionGroup/Teams/team" @ %AIteam @ "/flag");
		else
			for(%i = 0 ; %i < %mod ; %i++)
				%defendpoint = Group::getObject(%group, %i);

		while (String::findSubStr(GameBase::getPosition(%defendpoint), "0 0 0") != -1)
			%defendpoint++;

		$Spoonbot::BotStatus[%aiId] = "Defending Base";
		BotFuncs::AddAttacker( %aiId, %defendpoint,2,4); // Very close goal !
		}

// ***************************************************************************
//
// Test Case, The following code after the else upto the end else is designed
// to test the Bot movement in / out of a building.
//
// ***************************************************************************

		else // Run this code !
		{

			if ($botthink::TestModulus[%aiId] == 1) // Not likely on startup so will be second pass
			{ // Exit building

				%Nearest = BotTree::FindNearestTreebyId(%aiId);

				//dbecho(1, %aiId @ " Exiting building, nearest treepoint = " @ %nearest );

				%NearestExit = BotTree::FindNearestTreeExitbyTreePoint(%Nearest);

				if(%NearestExit != -1)
				{

				%location = $BotTree::Treepoint_Location[%Nearest]; // Forgot about this one a first !

				BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !

				%treecount = BotThink::getWordCount($BotTree::Treepoint_Route[%Nearest,%NearestExit]);

				//dbecho(1, %aiId @ ". Nearest Tree = " @ %Nearest @ ", " @ (%treecount + 1) @ " hops to dest" );

				for(%x = 0; %x < %treecount; %x++)
				{
					%point = getWord($BotTree::Treepoint_Route[%Nearest,%NearestExit], %x);

					%location = $BotTree::Treepoint_Location[%point];

					//dbecho(1, "Adding Route Point " @ %point @ ", location " @ %location);

					BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !
				}
				// Add last point

				%location = $BotTree::Treepoint_Location[%NearestExit];

				BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !

				$botthink::TestModulus[%aiId] = 0;

				}
				else
					dbecho(1, "Cant find exit from " @ %Nearest);
			}
			else
			{ // To Flag

				%Nearest = BotTree::FindNearestTreebyId(%aiId);

				%Flagpos = ($teamFlag[%aiTeam]).originalPosition;

				%NearestFlag = BotTree::FindNearestTreebyPos(%FlagPos);

				//dbecho(1, %aiId @ " going to flag, nearest treepoint = " @ %nearest );

				%location = $BotTree::Treepoint_Location[%Nearest]; // Forgot about this one a first !

				BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !

				%treecount = BotThink::getWordCount($BotTree::Treepoint_Route[%Nearest,%NearestFlag]);

				//dbecho(1, %aiId @ ". Nearest Tree = " @ %Nearest @ ", " @ (%treecount + 1) @ " hops to dest" );

				for(%x = 0; %x < %treecount; %x++)
				{
					%point = getWord($BotTree::Treepoint_Route[%Nearest,%NearestFlag], %x);

					%location = $BotTree::Treepoint_Location[%point];

					//dbecho(1, "Adding Route Point " @ %point @ ", location " @ %location);

					BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !
				}
				// Add last point

				%location = $BotTree::Treepoint_Location[%NearestFlag];

				BotFuncs::AddAttacker( %aiId, %location,5,4); // Very close goal !

				$botthink::TestModulus[%aiId] = 1;

			}

			schedule("BotThink::Think(" @ %aiId @ ", false);", 1);
		}
	}

// Tidy Attacker List Again !

	BotFuncs::TidyAttackerList(%aiId);


// Requeue Think

if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Requeue: " @ %aiId @ ", True");

	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);

}

function BotThink::getWordCount(%string)
{
    for(%num = 0; getWord(%string, %num) != -1; %num++)
    {} // it's all done above!
    return %num;
}
