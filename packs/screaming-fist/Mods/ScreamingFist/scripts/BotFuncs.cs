echo("Loading Screaming Fist Version");
// Bot Generic Functions by Wicked69 (Paul@Lathope.demon.co.uk) Started 7/11/1999.

// Global Vars used by following functions.

$AttackerIndexCount = 0;



// Creates vars for AI and enters AI into master list. Wicked69

function BotFuncs::InitVars(%aiId)
{
	$Spoonbot::BotStatus[%aiId] = "Idle";
	$Spoonbot::Team0MedicTask = -1;
	$Spoonbot::Team1MedicTask = -1;
	$Spoonbot::BotJetting[%aiId] = -1;
	$Spoonbot::BotJettingHeat[%aiId] = 0;
	$BotFuncs::AttackerCount[%aiId] = 0;
	$BotFuncs::AttackerIndex[%aiId] = 0;

	BotFuncs::AddAttackerIndex(%aiId);
}



// Resets variables for AI. Should be used on respawn etc. Wicked69

function BotFuncs::ClearVars(%aiId)
{
	$Spoonbot::BotStatus[%aiId] = "Idle";
	$BotFuncs::AttackerCount[%aiId] = 0;
	$BotFuncs::AttackerIndex[%aiId] = 0;
}



// Uses Attacker List to determine if AI is under attack.
// Under attack has prio of 1 e.g. defence entry. Also
// ignores attacker if dead.


function BotFuncs::IsUnderattack(%aiId)
{
	%count = 0;

	for(%i = 0; (%i < $BotFuncs::AttackerIndex[%aiId]); %i++)
		if (($BotFuncs::Attackers[%aiId,%i] != 0) &&
			($BotFuncs::Priority[%aiId,%i] == 1) &&
			(Player::isDead($BotFuncs::Attackers[%aiId,%i]) == False))
			%count++;
		
	return %count;
}



// Finds nearest attacker or entry to AI. Wicked69

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



// Deletes an attacker from an attack list. Wicked69

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



// Deletes an attacker from all AI attacker lists (Normally used on Player/AI Death). Wicked69

function BotFuncs::DelAttackerFromAll(%attackerId)
{
	for(%x = 0; %x < $AttackerIndexCount; %x++)
	{
		// Remove Entries from Bot Lists. Returns True if Actually Deleted.

		if(BotFuncs::DelAttacker($AttackerIndexIds[%x], %attackerId) == True)
			BotThink::Think($AttackerIndexIds[%x],False);
		
	}
}



// Adds an entry to the Master Attacker Index (Used for Mass Adds, Delete's etc. ). Wicked69

function BotFuncs::AddAttackerIndex(%aiId)
{
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


// finds nearest team AI member and returns ID. Uses AI master attack index for list.
// if nearest is father than max distance or AI not found (?) then 0 returned. Wicked69
// Optional parameters
//
// %excludeId = ID of AI not to be found (other than %aiId and alternate team members);
// can be used to find a second team member or to exclude an unhealthy one!
//
// %includeAIType = AI type to be found eg "Medic" or "Guard". Need Work.
//

function BotFuncs::FindNearestTeamAI(%aiId, %mindist, %maxdist, %excludeId, %includeAIType)
{
	%nearestdist = 999999;
	%nearestid = 0;
	%myTeam = Client::getTeam(%aiId);

	%BotPosistion = GameBase::getPosition(%aiId);

	for(%x = 0; %x < $AttackerIndexCount; %x++)
	{

		%nearestnominateid = $AttackerIndexIds[%x];
		%nearestnominatepos = GameBase::getPosition($AttackerIndexIds[%x]);
		%nearestnominatedist = Vector::getDistance(%BotPosistion,%nearestnominatepos);
		%nearestnominateteam = Client::getTeam(%nearestnominateid);
		%nearestnominatename = Client::getName(%nearestnominateid);

		// Note: following if statement breaks AI type standard - direct coding!

		if	((%aiId != %nearestnominateid) &&
			 (%excludeId != %nearestnominateid) &&
			 ( %nearestnominatedist >= %mindist) &&
			 ( %nearestnominatedist < %nearestdist) &&
			 (%nearestnominateteam == %myTeam) &&
			 ((%includeAIType == "") || (String::findSubStr(%nearestnominatename, %includeAIType) >= 0)))
		{

			%nearestid = %nearestnominateid;
			%nearestdist = %nearestnominatedist;
		}
	}

	if(%nearestdist > %maxdist)
		return 0;

	return %nearestid;
}


// Deletes any targets closer than min distance or dead.


function BotFuncs::TidyAttackerList(%aiId)
{
	%aipos = GameBase::getPosition(%aiId);

	for(%i = 0; (%i < $BotFuncs::AttackerIndex[%aiId]); %i++)
	{
		%PleaseDelete = False;

		if ($BotFuncs::Attackers[%aiId,%i] != 0)
		{
			if(Player::isDead($BotFuncs::Attackers[%aiId,%i]) == True) // Dead, So delete
				%PleaseDelete = True;

			%WordCount = BotThink::getWordCount(%Attackerpos);

			%Attackerpos = $BotFuncs::Attackers[%aiId,%i];

			//dbecho(1, "Tidy:: Vector::dot(" @ %aipos @ "," @ %Attackerpos @ ") = " @ Vector::dot(%aipos,%Attackerpos));
			//dbecho(1, "Tidy:: Vector::add(" @ %aipos @ "," @ %Attackerpos @ ") = " @ Vector::add(%aipos,%Attackerpos));
			//dbecho(1, "Tidy:: Vector::sub(" @ %aipos @ "," @ %Attackerpos @ ") = " @ Vector::sub(%aipos,%Attackerpos));
			//dbecho(1, "Tidy:: Vector::getDistance(" @ %aipos @ "," @ %Attackerpos @ ") = " @ Vector::getDistance(%aipos,%Attackerpos));
			//dbecho(1, "Tidy:: Vector::neg(" @ %aipos @ ") = " @ Vector::neg(%aipos));
			//dbecho(1, "Tidy:: Vector::normalize(" @ %aipos @ ") = " @ Vector::normalize(%aipos));
			//dbecho(1, "Tidy:: Vector::getrotation(" @ %aipos @ ") = " @ Vector::getrotation(%aipos));
			//dbecho(1, "Tidy:: Vector::getrotation(2)(" @ Vector::normalize(%aipos) @ ") = " @ Vector::getrotation(Vector::normalize(%aipos)));


			//dbecho(1, "Wordcount for '" @ %Attackerpos @ "' = " @ %Wordcount );

// if waypoint supplied then dont convert to waypoint
			//if(%Wordcount == 1)
			//	%Attackerpos = GameBase::getPosition($BotFuncs::Attackers[%aiId,%i]);

			%Attackerdist = Vector::getDistance(%aipos,%attackerpos);

			if(%Attackerdist <=	$BotFuncs::DeleteDistance[%aiId,%i])
				%PleaseDelete = True;

			if(%PleaseDelete == True)
			{
				$BotFuncs::Attackers[%aiId,%i] = 0;
				$BotFuncs::AttackerCount[%aiId] = $BotFuncs::AttackerCount[%aiId] - 1;
			}
		}
	}
}



// Code to give one AI a repairkit from another. Wicked69
// I like this one!


function BotFuncs::GiveRepairKit(%source,%dest)
{
	%sourcecount = Player::GetItemCount(%source,RepairKit);
	%destcount = Player::GetItemCount(%dest,RepairKit);

// Cheat, Frig or whatever you want to call it. Wicked69

	%sourcecount = 1;

	%destcount = 1;

	Player::SetItemCount(%source,RepairKit, %sourcecount);
	Player::SetItemCount(%dest,RepairKit, %destcount);

	%Team = GameBase::getTeam(%source);
    BotFuncs::TeamMessage(%Team, Client::GetName(%source) @ " gave " @ Client::GetName(%dest) @ " a Health Kit");
}




// IsHealthy - Checks health of Bot!
// Returns boolean based on whether AI is healthy.

function BotFuncs::IsHealthy(%aiId)
{
	%player = Client::getOwnedObject(%aiId);
	%damage = GameBase::getDamageLevel(%player);

	if (%damage >= $Spoonbot::RetreatDamageLevel)
		return False;

	return True;
}


function BotFuncs::TeamMessage(%team, %message)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i++)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team)
      {
         Client::sendMessage(%id, 1, %message);
      }
   }
}


function BotFuncs::checkObstacle(%aiId)  //This function checks for nearby obstacles and makes the AI evade them. By Werewolf.
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
		AI::RandomEvade(%passenger);
		return;
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ %posY @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}


	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),%posX @ " " @ (%posY + %minObstacleDistance) @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),%posX @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}






	//Checking for diagonal obstacles
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX + %minObstacleDistance) @ " " @ (%posY + %minObstacleDistance)@ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}


	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX - %minObstacleDistance) @ " " @ (%posY + %minObstacleDistance) @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}
	if(!GameBase::testPosition(Client::getOwnedObject(%passenger),(%posX + %minObstacleDistance) @ " " @ (%posY - %minObstacleDistance) @ " " @ %posZ)) {	
		AI::RandomEvade(%passenger);
		return;
	}

}	


function BotFuncs::GetTheFlag(%aiName)   //by EMO1313. Makes %aiName to head for the flag and ignore all enemies.
{

if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::GetTheFlag("@ %aiName @");");

			%aiId = AI::getId( %name );
			%aiTeam = GameBase::getTeam( %aiId );

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

			AI::DirectiveWaypoint( %aiName, %flagPos, 125);         //Head for the flag.
			AI::DirectiveWaypoint( %aiName, %flagPos, 2);         //Head for the flag.
			AI::SetVar(%aiName, spotDist, 100);
			AI::SetVar(%aiName, seekOff , 1);
			schedule("AI::SetVar(" @ %aiName @ "," @ spotDist @ ", 150);",60);
			schedule("AI::SetVar(" @ %aiName @ "," @ seekOff @ " , 0);",60);
			schedule("AI::DirectiveRemove(" @ %aiName @ ", 125);",60);

			$Spoonbot::BotStatus[%aiId] = "Getting Flag";
			if ($Spoonbot::DebugMode)
			  echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
			return;
}

function BotFuncs::ReturnTheFlag(%aiName)   //by Werewolf. Makes %aiName to head for the OWN flag and ignore all enemies.
{

if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::ReturnTheFlag("@ %aiName @");");

			%aiId = AI::getId( %aiName );
			%aiTeam = GameBase::getTeam( %aiId );

			%pos = ($teamFlag[%aiTeam]).originalPosition;
			%xPos = getWord(%pos, 0);
			%yPos = getword(%pos, 1);
			%zPos = getWord(%pos, 2);
			%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;

			AI::DirectiveWaypoint( %aiName, %flagPos, 125);         //Head for the flag.
			AI::DirectiveWaypoint( %aiName, %flagPos, 2);         //Head for the flag.
			AI::SetVar(%aiName, spotDist, 100);
			AI::SetVar(%aiName, seekOff , 1);
			schedule("AI::SetVar(" @ %aiName @ "," @ spotDist @ ", 150);",$Spoonbot::ThinkingInterval);
			schedule("AI::SetVar(" @ %aiName @ "," @ seekOff @ " , 0);",$Spoonbot::ThinkingInterval);
			schedule("AI::DirectiveRemove(" @ %aiName @ ", 125);",$Spoonbot::ThinkingInterval);
			schedule("AI::DirectiveRemove(" @ %aiName @ ", 2);",$Spoonbot::ThinkingInterval);

			$Spoonbot::BotStatus[%aiId] = "Returning Flag";
			if ($Spoonbot::DebugMode)
			  echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
			return;
}


function BotFuncs::checkForFlagrunner(%aiName)
{
if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::CheckForFlagrunner("@ %aiName @");");

	%aiId = AI::getId(%aiName);

	if (Player::getMountedItem(%aiId, $FlagSlot) != -1)  //if the ai carries a flag, make him run home!!
	{
		if ($Spoonbot::DebugMode)
		  echo ("STATUS BotFuncs::CheckForFlagrunner = Flagrunner " @ %flagrunnerName @ "has the flag");
//		BotFuncs::ReturnTheFlag(%aiName);
		return;
	}


	%T = GameBase::getTeam(%aiId);
	%startCl = 2049;
	%endCl = %startCl + 90;

	for(%cl = %startCl; (%cl < %endCl); %cl++)
	{
		%team = Client::getTeam(%cl);
		%flagrunnerName = Client::getName(%cl);

		if (Player::getMountedItem(%cl, $FlagSlot) != -1)
		{
		  if (%cl != %aiId)
		  {
			  if(%team != %T)	
			  {
				%player = Client::getOwnedObject(%cl);
				if (!Player::isDead(%player))
				{
				        if (%flagrunnerName != "")
					{
					AI::HuntTarget(%aiName, %cl, 1);
					if ($Spoonbot::DebugMode)
					  echo (%aiName @ " has decided to attack enemy flagrunner " @ %flagrunnerName);
					$Spoonbot::BotStatus[%aiId] = "Attacking Flagrunner";
					}

				}
			  }
		          else				    //else this is a friendly, so let's escort him to safety.
		          {
				%player = Client::getOwnedObject(%cl);
		 		if (!Player::isDead(%player))
				{
				        if (%flagrunnerName != "")
					{
				   	AI::HuntTarget(%aiName, %cl, 1);  //The procedure is the same, except the friendly bot won't fire on the flagrunner
					if ($Spoonbot::DebugMode)
				   	  echo(%aiName @ " is escorting the friendly flagrunner " @ %flagrunnerName);
					$Spoonbot::BotStatus[%aiId] = "Escorting Flagrunner";
				        }
		 	        }
		          }
		  }
		}
	}
}


function BotFuncs::checkForPaint(%aiName)					// savage
{										// savage
if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::CheckForPaint("@ %aiName @");");

  if(String::findSubStr(%aiName, "Guard") >= 0)
  {
	%aiId = AI::getId(%aiName);						// savage
	%T = GameBase::getTeam(%aiId);						// savage
	%startCl = 2049;
	%endCl = %startCl + 90;
//	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))	// old loop made mortars fire on human lasers only
	for(%cl = %startCl; (%cl < %endCl); %cl++)				// new loop also reacts on AI targeting lasers.
	{
		%team = Client::getTeam(%cl);					// savage
		if(%team == %T)							// savage
		{								// savage
			if (Player::getMountedItem(%cl,$WeaponSlot) == TargetingLaser)
			{
				if (Player::isTriggered(%cl,$WeaponSlot))
				{
					$Spoonbot::BotStatus[%aiId] = "Mortaring";
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
}



function BotFuncs::AddRepairTask(%object)  //by Werewolf. Adds a destroyed object (turret, generator, etc) to the repair queue
{
if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::AddRepairTask("@ %object @");");

$Spoonbot::NumRepairTasks = $Spoonbot::NumRepairTasks + 1;

for(%task = 0; (%task < 99); %task++)
  {
	if ($Spoonbot::RepairTaskObject[%task] == 0)
	  {
		$Spoonbot::RepairTaskObject[%task] = %object;
		return;
	  }
  }
}




function BotFuncs::CheckIfBusyWithRepairs(%aiName)  //by Werewolf. Only updates a storage variable.
{

%aiId = AI::getId( %aiName );

if ((%aiId != $Spoonbot::Team0Medic) && (%aiId != $Spoonbot::Team1Medic))  //As of yet only 1 medic per team is supported.
  return;

%task = -1;
if (%aiId == $Spoonbot::Team0Medic)
  %task = $Spoonbot::Team0MedicTask;
if (%aiId == $Spoonbot::Team1Medic)
  %task = $Spoonbot::Team1MedicTask;

 if (%task == -1)
 {
	return 0;
 }
 else 
 {
	return 1;
 }


}




function BotFuncs::SetCurrentRepairTask(%aiName, %task)  //by Werewolf. Only updates a storage variable.
{

if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::SetCurrentRepairTask(" @ %aiName @ ", " @ %task @ ");");


%aiId = AI::getId( %aiName );

if ((%aiId != $Spoonbot::Team0Medic) && (%aiId != $Spoonbot::Team1Medic))  //As of yet only 1 medic per team is supported.
  return;

if (%aiId == $Spoonbot::Team0Medic)
  $Spoonbot::Team0MedicTask = %task;
if (%aiId == $Spoonbot::Team1Medic)
  $Spoonbot::Team1MedicTask = %task;

}






function BotFuncs::RepairTask(%aiName)  //by Werewolf. Makes a Medic search for damaged structures and repair them.
{

if (!BotTypes::IsMedic(%aiName))   //This routine is only for medics
	return;

if ($Spoonbot::DebugMode)
 echo ("CALL BotFuncs::RepairTask("@ %aiName @");");

%aiId = AI::getId( %aiName );
%aiTeam = GameBase::getTeam( %aiId );


if ((%aiId != $Spoonbot::Team0Medic) && (%aiId != $Spoonbot::Team1Medic))  //As of yet only 1 medic per team is supported.
  return;

if (%aiId == $Spoonbot::Team0Medic)
  %currentAiTask = $Spoonbot::Team0MedicTask;
if (%aiId == $Spoonbot::Team1Medic)
  %currentAiTask = $Spoonbot::Team1MedicTask;


if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = NumRepairTasks="@ $Spoonbot::NumRepairTasks @");");

if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask Current Task for "@ %aiName @" is " @ %currentAiTask);

if ($Spoonbot::NumRepairTasks == 0)  //If there aren't any repair tasks, reset AI task thingy, then quit.
{
  BotFuncs::SetCurrentRepairTask(%aiName, -1);
  return;
}

 if (%currentAiTask == -1)      //Is the AI busy with repairs? if not, then...
  {
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Idle Medic gets new task now");
	%taskFound = 0;

	for(%task = 0; ((%task < $Spoonbot::NumRepairTasks + 3) && (%taskFound == 0)); %task++) //the "NumRepairTasks + 3" thingy is just a hack to make sure no Repair Task is left out.
	  {
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask %task = " @ %task);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask $Spoonbot::RepairTaskObject[%task] = " @ $Spoonbot::RepairTaskObject[%task]);
		if ($Spoonbot::RepairTaskObject[%task] != 0)
		  {
			%object = $Spoonbot::RepairTaskObject[%task];
			%objectTeam = GameBase::getTeam(%object);
			%objectLocation = GameBase::getPosition(%object);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask %objectTeam = " @ %objectTeam);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask %objectLocation = " @ %objectLocation);
			if (%objectTeam == %aiTeam)                     //Since the Repair Task list is global, we need to check the team ;-)
			{
				%taskFound = 1;
				%objectLocation = GameBase::getPosition(%object);
				%xPos = getWord(%objectLocation, 0);
				%yPos = getword(%objectLocation, 1);
				%zPos = getWord(%objectLocation, 2);
				%objectLocation = %xPos @ "  " @ %yPos @ "  " @ %zPos;
				AI::DirectiveWaypoint( %aiName, %objectLocation, 125);         //Head for the damaged object.
				AI::DirectiveWaypoint( %aiName, %objectLocation, 2);         //Head for the damaged object.
				AI::SetVar(%aiName, spotDist, 0);
				AI::SetVar(%aiName, seekOff , 1);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Assigning task: Repair a " @ GameBase::getDataName(%object) @ ", %objectLocation = "@ %objectLocation @", TaskID = " @ %task @ ", NumTasks = " @ $Spoonbot::NumRepairTasks);

				BotFuncs::SetCurrentRepairTask(%aiName, %task);

			}
		  }
	  }
  }
  else   //Hoho, the AI already works on a repair task 
  {
	%task = %currentAiTask;
	%object = $Spoonbot::RepairTaskObject[%task];
	%objectTeam = GameBase::getTeam(%object);
	%objectLocation = GameBase::getPosition(%object);
	%xPos = getWord(%objectLocation, 0);
	%yPos = getword(%objectLocation, 1);
	%zPos = getWord(%objectLocation, 2);
	%objectLocation = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	AI::DirectiveWaypoint( %aiName, %objectLocation, 125);         //Continue to head for the damaged object.
	AI::DirectiveWaypoint( %aiName, %objectLocation, 2);         //Continue to head for the damaged object.
	AI::SetVar(%aiName, spotDist, 0);
	AI::SetVar(%aiName, seekOff , 1);

if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Already working on task: %object = " @ GameBase::getDataName(%object) @ " - " @ %object @ ", %objectLocation = "@ %objectLocation @", TaskID = " @ %task @ ", NumTasks = " @ $Spoonbot::NumRepairTasks);


	if (%objectTeam == %aiTeam)
	{

	  if (GameBase::getPosition(%object) == "0  0  0")		//Checks if the damaged object is a valid object, and aborts repair if not.
	    {
	      $Spoonbot::NumRepairTasks = $Spoonbot::NumRepairTasks - 1;
	      $Spoonbot::RepairTaskObject[%task] = 0;
	      BotFuncs::SetCurrentRepairTask(%aiName, -1);
	      AI::DirectiveRemove(%aiName, 125);
	      AI::SetVar(%aiName, spotDist, 150);
	      AI::SetVar(%aiName, seekOff , 0);
	      AI::RandomEvade(%aiId);
	    }

		$Spoonbot::BotStatus[%aiId] = "Repairing Structure";
		%curDistance = Vector::getDistance(GameBase::getPosition(%object), GameBase::getPosition(Client::getOwnedObject(%aiId)));  //Check if AI is in range for repairs
		if (%curDistance < 20)
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				%rate = 0;
				GameBase::setAutoRepairRate(%object,%rate);
				$Spoonbot::NumRepairTasks = $Spoonbot::NumRepairTasks - 1;
				$Spoonbot::RepairTaskObject[%task] = 0;
				BotFuncs::SetCurrentRepairTask(%aiName, -1);
				AI::DirectiveRemove(%aiName, 125);
				AI::SetVar(%aiName, spotDist, 150);
				AI::SetVar(%aiName, seekOff , 0);
				AI::RandomEvade(%aiId);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Repair Done");
			}
			else
			{
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Repairing...");
				AI::DirectiveRemove(%aiName, 125);
				%repairRate = 0.1;
				%damage = GameBase::getDamageLevel(%object);
if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = Object Damage = " @ %damage);

				%difference = %damage - %repairRate;

				if (%difference < 0.0)	//If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
				{
					%repairRate = %damage;
				}

				%newDamage = %damage - %repairRate;

				GameBase::setDamageLevel(%object, %newDamage);
			}
		}
	}
  }

if ($Spoonbot::DebugMode)
 echo ("STATUS BotFuncs::RepairTask = End of RepairTask");

}


function BotFuncs::Animation(%aiId, %animation)  //by Werewolf. Makes a bot wave or salute or anything.
{

// Example usage for animation:
//	%animation = radnomItems(8, $PlayerAnim::Celebration1, $PlayerAnim::Celebration2, $PlayerAnim::Celebration3, $PlayerAnim::Taunt1, $PlayerAnim::Taunt2, $PlayerAnim::Wave, $PlayerAnim::OverHere, $PlayerAnim::Salute);
// See PlayerAnim definitions in Player.cs and ArmorData.cs

//	%player = Client::getControlObject(%aiId);
	%player = %aiId;
	Player::setAnimation(%player, %animation);
}

