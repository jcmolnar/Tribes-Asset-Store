//Special Thanks to Werewolf and all the Spoonbot Development Team for their permission to use their Spoonbot code!!


function BotMove::Move(%aiId)
{
	CheckHealth(%aiId);
	%aiName = Client::getName(%aiId);
//AI::callbackPeriodic(%aiName, 5, AI::periodicWeaponChange);
//Sanity check. Check if Bot is alive. If not then clear Vars and abort functiom
//----------------------------------------
//Werewolf

if ($Spoonbot::BotStatus[%aiId] == "Dead")
	return;

%player = Client::getOwnedObject(%aiId);

if (Player::isDead(%player))
	{
		BotFuncs::ClearVars(%aiId);
		return;
	}


//The following needs to be done in case
//IsDead doesn't work in this version

    %newId = BotFuncs::GetId(%aiName);
if (%newId==0)
	return;
    if (%newId != %aiId)
    {
		BotFuncs::ClearVars(%aiId);
		return;
    }


//if ($Spoonbot::RidingWith[%aiId] != 0)	//If bot rides in a vehicle, skip all of the bot's movement.
//	{
//	if (%requeue == True)
//		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
//	return;
//	}

// Generic variables

	%aiName = Client::getName(%aiId);
	%aiTeam = Client::getTeam(%aiId);
	%AiPos = GameBase::getPosition(%aiId);

	//if(%aiTeam == 0)
	//	%EnemyTeam = 1;
	//else
	//	%EnemyTeam = 0;

//
//
// Bot "stuck" check
//
//

// Now we're checking of the AI is stuck somewhere by comparing the actual position with the previous one.
// Then we either issue a RandomEvade to try to solve this problem, or use the nearest treepoint and go from there.

	%xPos = getWord(%AiPos, 0);
	%yPos = getWord(%AiPos, 1);
	%zPos = getWord(%AiPos, 2);
	%LastxPos = getWord($Spoonbot::lastPosition[%aiId], 0);
	%LastyPos = getWord($Spoonbot::lastPosition[%aiId], 1);
	%LastzPos = getWord($Spoonbot::lastPosition[%aiId], 2);
	%stuck = False;
	%MinPositionDelta = 1;
	%MaxGracePeriod = 4;

	if (BotFuncs::Delta(%xPos, %LastxPos) < %MinPositionDelta)
		if (BotFuncs::Delta(%yPos, %LastyPos) < %MinPositionDelta)
			if (BotFuncs::Delta(%zPos, %LastzPos) < %MinPositionDelta)  //If the bot hasn't moved recently, it may be stuck.
				%stuck = True;


	if (%stuck)
	{
		$Spoonbot::StuckGracePeriod[%aiId]++;
	    if ($Spoonbot::StuckGracePeriod[%aiId] >= %MaxGracePeriod)
	    {
			if($Spoonbot::MedicBusy[%aiId] == 0)
			{

		  %foundTarget=False;
			%set = newObject("set",SimSet);
			%mask = $StaticObjectType;
			%num = containerBoxFillSet(%set,%mask,%AiPos,150,150,150,0);

		  if ($Spoonbot::AlreadyLookedForTargets[%aiId] == False && %num > 0)	//If Demo bot is stuck, check for visible nearby targets and attack them.
		  {
			if ($Spoonbot::DebugMode)
			dbecho(1,"Searching for new targets in " @ $BotFuncs::AllCount);
			%foundTarget=False;
			for(%count = 0;%index != -1; %count++)
			{
				%index = Group::getObject(%set, %count);
				%potentialTarget = %index;
				%PTname = GameBase::getDataName(%potentialTarget);
				%PTteam = GameBase::getTeam(%potentialTarget);
				if ( (BotFuncs::CheckForItemLOS(%aiId, %potentialTarget) ) && ( Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) <= 150 ) && (%foundTarget==false))
				if ((%PTname.className == Generator || %PTname == VehicleStation || %PTname == VehiclePad || %PTname.className == Station || %PTname == DeployableStation || %PTname == DeployableSensor || %PTname.className == Turret || %PTname == MediumPulseSensor || %PTname ==PulseSensor ) && (%aiTeam != %PTteam))
				{
					if (GameBase::getDamageLevel(%potentialTarget) < 0.7)
					{
					  $Spoonbot::Target[%aiId] = %potentialTarget;
					  BotFuncs::AttackObjectFunction(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
					else if(%potentialTarget.TargetPower)
					{
					 %potentialTarget.TargetPower = fasle;
					 AI::DirectiveRemove(%aiName, 5000);
					}		
				}
			}

			if (%foundTarget == True)
			{
				$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
				$Spoonbot::StuckGracePeriod[%aiId] = 0;
			} else {
				$Spoonbot::AlreadyLookedForTargets[%aiId] = True;
				$Spoonbot::StuckGracePeriod[%aiId] = %MaxGracePeriod;
			}
		  }
		}
deleteObject(%set);

		if ($Spoonbot::AlreadyLookedForTargets[%aiId] == True)
		{
				$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
				if ($Spoonbot::DebugMode)
					echo("STUCK ID " @ %aiId @ " Name " @ %aiName @ " at " @ %AiPos);
				$BotThink::ForcedOfftrack[%aiId] = True;
				AI::RandomEvade(%aiId);
				$Spoonbot::StuckGracePeriod[%aiId] = 0;
		}

	      }
	}

	$Spoonbot::lastPosition[%aiId] = %AiPos;




// User Requested Move

	if (BotFuncs::NearestAttacker(%aiId, 500, 2) != 0)
	{

		if ($Spoonbot::DebugMode)
			echo ("STATUS BotThink::Think = User requested move");

		$BotThink::ForcedOfftrack[%aiId] = True;

		%UserRequest = BotFuncs::NearestAttacker(%aiId, 500, 2);

		if (%UserRequest == 0)

//Nearest request too far away... So delete it

		{
			%UserRequest = BotFuncs::NearestAttacker(%aiId, 99999, 2);
			BotFuncs::DelAttacker(%aiId,%UserRequest);
		}
		else

		// Go to User Requeued Location

			AI::HuntTarget(%aiName, %UserRequest, 1);
			$Spoonbot::BotStatus[%aiId] = "Moving";
	}


// AI Team Mate Requested Move

	else if (BotFuncs::NearestAttacker(%aiId, 500, 3) != 0)
	{

		if ($Spoonbot::DebugMode)
			echo ("STATUS BotThink::Think = AI Teammate requested move");

		$BotThink::ForcedOfftrack[%aiId] = false;

		%AIRequest = BotFuncs::NearestAttacker(%aiId, 500, 3);  //To Wicked69: You had a typo here ;-)
 
		if (%AIRequest == 0)

//Nearest request too far away... So delete it

		{
			%AIRequest = BotFuncs::NearestAttacker(%aiId, 99999, 3);
			BotFuncs::DelAttacker(%aiId,%AIRequest);
		}
		else
		{
// Go to AI Requeted Location

			$Spoonbot::BotStatus[%aiId] = "Helping AI";
			AI::HuntTarget(%aiName, %AIRequest, 1);
		}
	}

// Self Goal Move eg. defend base, go to base etc.

	else if (BotFuncs::NearestAttacker(%aiId, 99999, 4) != 0)
	{
		if ($Spoonbot::DebugMode)
			echo ("STATUS BotThink::Think = Self goal move");

		if($BotThink::ForcedOfftrack[%aiId])	// If forced off track by enemy intervention
							// Attacked, weak etc then we must recalculate
							// our destination.
		{

			// Clear current treepoint route entries. Were
			// Potentially lost and the current route could
			// be invalid!

//			BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
			if ($Spoonbot::DebugMode)
				echo ("Forced off track!");

			$BotThink::ForcedOfftrack[%aiId] = false;
			$BotThink::LastPoint[%aiId] = false;

		}
		else
		{
			if ($Spoonbot::DebugMode)
				echo ("Treefile Movement code running...");

			%AIRequest = BotFuncs::NearestAttacker(%aiId, 99999, 4);

			%Distance = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]));

			%Distance2 = Vector::getDistance(GameBase::getPosition(%aiId), %AIRequest);

			if ($Spoonbot::DebugMode)
			echo("SELF GOAL MOVE " @ %aiid @ " team = " @ %aiteam @ ", enemyteam = " @ %enemyteam @ ", attackpoint = " @ $BotThink::Definitive_Attackpoint[%aiId] @ ", attackpoint team = " @ GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]));
			if ($Spoonbot::DebugMode)
			dbecho(1,"Distance to tree point (" @ %AIRequest @ ") = " @ %Distance2 );
			if ($Spoonbot::DebugMode)
			dbecho(1,"Distance to target (" @ $BotThink::Definitive_Attackpoint[%aiId] @ ") = " @ %Distance );
			if ($Spoonbot::DebugMode)
			dbecho(1,"Is Last Point? " @ $BotThink::LastPoint[%aiId]);



		if (BotFuncs::CheckForItemLOS(%aiId, $BotThink::Definitive_Attackpoint[%aiId]))
		{
					if ($Spoonbot::DebugMode)
				dbecho(1,"LOS found, attacking... " @ $BotThink::Definitive_Attackpoint[%aiId]);

			//if((%Distance < 10) && ($BotThink::LastPoint[%aiId] == False) && (%enemyteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]))) // Attack Target!
			if (($BotThink::LastPoint[%aiId] == False) && (%aiTeam != GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId])))
			{
				BotFuncs::Attack(%aiId, $BotThink::Definitive_Attackpoint[%aiId]);
//				$BotThink::Definitive_Attackpoint[%aiId] = "";
//				$BotThink::ForcedOfftrack[%aiId] = True;
			}

			//if((%Distance < 10) && ($BotThink::LastPoint[%aiId] == False) && (%aiteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]))) // Attack Target!
			if (($BotThink::LastPoint[%aiId] == False) && (%aiteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId])))
			{
				AI::DirectiveWaypoint(%aiName, GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]), 1024);
//				$BotThink::Definitive_Attackpoint[%aiId] = "";
//				$BotThink::ForcedOfftrack[%aiId] = True;
			}
		}
		else 
		{
			if ($Spoonbot::DebugMode)
			dbecho(1,"No LOS found.");
			AI::DirectiveWaypoint(%aiName, GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]), 1024); // Was 1024 instead of 1
//			BotFuncs::Attack(%aiId, $BotThink::Definitive_Attackpoint[%aiId]);

		}


			if((%Distance < 2.5) && ($BotThink::LastPoint[%aiId] == True) && ($Spoonbot::MedicBusy[%aiId]==0)) // reached target, now look for next target
			{
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::ForcedOfftrack[%aiId] = True;
			}


			%DiffHeight = getWord(%AIRequest,2) - (getWord(GameBase::getPosition(%aiId),2));

// Get Bot to start jetting when/if target is a 45 degrees - crude interpretation

			if((%DiffHeight > (%Distance / 2)) && (Distance>5))
			{
	if ($Spoonbot::DebugMode)
				dbecho(1,%aiId @ " Jetting!!! ");

				AI::JetToHeight(%aiId, (getWord(%AIRequest,2) + 5));
			}

			//dbecho(1, %aiId @ " current waypoint = " @ %AIRequest @ ", distance = " @ %Distance );

			// Go to AI Requested Location
			//AI::DirectiveWaypoint( %aiName, %AIRequest, 1024 );
			//dbecho(1,"AI::DirectiveWaypoint(" @ %aiName @ "," @ %AIRequest @ ", 1 );");

		
	}

    }


		if($BotThink::ForcedOfftrack[%aiId])	// If forced off track by enemy intervention
							// Attacked, weak etc then we must recalculate
							// our destination.
		{

			// Clear current treepoint route entries. Were
			// Potentially lost and the current route could
			// be invalid!

//			BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
			if ($Spoonbot::DebugMode)
				echo ("Forced off track!");

			if ($BotThink::Definitive_Attackpos[%aiId]!=0)
			$BotThink::ForcedOfftrack[%aiId] = false;
			$BotThink::LastPoint[%aiId] = false;

		}



  schedule("BotMove::Move(" @ %aiId @ " );", 3);

}

