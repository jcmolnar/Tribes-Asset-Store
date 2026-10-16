// Bot Think Function by Wicked69 (Paul@Lathope.demon.co.uk) Started 6/11/1999.

//All CTF/FG Code loops originally by [CoD]Homicide!

//Main Bot think function calls itself recursively each second

function BotThink::Think(%aiId,%requeue)
{
	if ($Spoonbot::DebugMode)
		echo ("CALL BotThink::Think("@ %aiId @ ", " @ %requeue @ ");");


//Sanity check. Check if Bot is alive. If not then clear Vars and abort functiom
//----------------------------------------
//Werewolf

if (String::findSubStr($Spoonbot::BotStatus[%aiId], "Dead") >= 0)
    {
		BotFuncs::ClearVars(%aiId);
		return;
    }

%player = Client::getOwnedObject(%aiId);

if (Player::isDead(%player))
    {
		BotFuncs::ClearVars(%aiId);
		return;
    }

    %aiName = Client::getName(%aiId);

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

// Generic variables

//	%aiName = Client::getName(%aiId);		//done above...
	%AiPos = GameBase::getPosition(%aiId);
	%aiTeam = Client::getTeam(%aiId);
	if(%aiTeam == 0)
		%EnemyTeam = 1;
	else
		%EnemyTeam = 0;

// Tidy Attacker List

	BotFuncs::TidyAttackerList(%aiId);

	if ($Spoonbot::DebugMode)
		echo("STATUS BotThink::Think = Bot alive check passed for ID " @ %aiId @ " Name " @ %aiName);

if($Spoonbot::NormalRoam[%aiId]==0)
{
%startCl = 2049;		                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!
%numHumans = $Server::MaxPlayers;
if (%numhumans < 1)
	%numHumans = 32;
%endCl = %startCl +%numHumans + $Spoonbot::NumBots + 1;
for(%cl = %startCl; %cl < %endCl; %cl++)
	{
	 %targetTeam = Client::getTeam(%cl);
	if (%targetTeam == %EnemyTeam)           //Is this an enemy?
		{
			%enemyName = Client::getName(%cl);
			if (%enemyName != "")
				{
				BotFuncs::AddAttacker(%aiId,%cl,999,6);
				BotFuncs::AddAttacker(%cl,%aiId,999,6);
				}
		}
	}
$Spoonbot::NormalRoam[%aiId] = 1;
}

if (($Spoonbot::DemoTarget[%aiId]!=0) && (BotFuncs::CheckForLOS(%aiId, $Spoonbot::DemoTarget[%aiId])) && (BotTypes::IsMedic(%aiName) == 0) && (Player::getMountedItem(%aiId, $FlagSlot) == -1))
{
	BotThink::DemoLOS(%aiId,%aiName,%AiPos,%aiTeam);
	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
	return;
}

if ($Spoonbot::RidingWith[%aiId] != 0)	//If bot rides in a vehicle, skip all of the bot's thinking.
{
	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
	return;
}

if ((BotTypes::isCMD(%aiName) == 1) && (BotFuncs::NearestAttacker(%aiId, 999, 2) == 0) && (Player::getMountedItem(%aiId, $FlagSlot) == -1))
	{
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
	return;
	}

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

	if ($Spoonbot::DebugMode)
		echo("PREVIOUS POSITION of ID " @ %aiId @ " Name " @ %aiName @ " is " @ $Spoonbot::lastPosition[%aiId]);
	if ($Spoonbot::DebugMode)
		echo("ACTUAL POSITION of ID " @ %aiId @ " Name " @ %aiName @ " is " @ %AiPos);


	%stuck = False;
	%MinPositionDelta = 1;
	%MaxGracePeriod = 1;

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

		  if ($Spoonbot::AlreadyLookedForTargets[%aiId] == False)	//If Demo bot is stuck, check for visible nearby targets and attack them.
		  {

			if ($Spoonbot::DebugMode)
			dbecho(1,"Searching for new targets in " @ $BotFuncs::AllCount);

			%foundTarget=False;
			for(%object = 0; (%object <= $BotFuncs::AllCount); %object++)
			{
				%potentialTarget = $BotFuncs::AllList[%object];
				%PTname = GameBase::getDataName(%potentialTarget);
				%PTteam = GameBase::getTeam(%potentialTarget);
			if ($Spoonbot::DebugMode)
			dbecho(1,"potentialTarget= "@ %potentialTarget);
			if ($Spoonbot::DebugMode)
			dbecho(1,"PTname= "@ %PTname);
			if ($Spoonbot::DebugMode)
			dbecho(1,"PTteam= "@ %PTteam);
			if ($Spoonbot::DebugMode)
			dbecho(1,"LOS is "@ BotFuncs::CheckForItemLOS(%aiId, %potentialTarget));
			if ($Spoonbot::DebugMode)
			dbecho(1,"Distance= "@ Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)));

				if ( (BotFuncs::CheckForItemLOS(%aiId, %potentialTarget) ) && ( Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) <= 40 ) && (%foundTarget==false))
				if ((%PTname == Generator) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: GENERATOR!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == VehicleStation) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: VEHICLE STATION!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == VehiclePad) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: VEHICLE PAD!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == InventoryStation) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: INVENTORY STATION!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == CommandStation) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: COMMAND STATION!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == AmmoStation) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: AMMO STATION!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
				else if ((%PTname == DeployableTurret) && (%enemyteam == %PTteam))
				{
					if (%potentialTarget!=0)
					{
					if ($Spoonbot::DebugMode)
						dbecho(1,"Found new target: DEPLOYABLE TURRET!");
					  $Spoonbot::Target[%aiId]=%potentialTarget;
					  BotFuncs::AttackObject(%aiName, %potentialTarget);
					  %objectpos = GameBase::getPosition(%potentialTarget);
//					  BotTree::Getmetopos(%aiid,%objectpos, false);
					  $BotThink::Definitive_Attackpoint[%aiId] = %potentialTarget;
					  $BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					  $BotThink::ForcedOfftrack[%aiId] = false;
					  %foundTarget=true;
					}
				}
			}

			if (%foundTarget == True)
			{
				$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
				$Spoonbot::StuckGracePeriod[%aiId] = -10;
			} else {
				$Spoonbot::AlreadyLookedForTargets[%aiId] = True;
				$Spoonbot::StuckGracePeriod[%aiId] = %MaxGracePeriod;
			}
		  }
		}


		if ($Spoonbot::AlreadyLookedForTargets[%aiId] == True)
		{
			$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
			if ($Spoonbot::DebugMode)
				echo("STUCK ID " @ %aiId @ " Name " @ %aiName @ " at " @ %AiPos);
			$BotThink::ForcedOfftrack[%aiId] = True;
			if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] != 1) && ($Spoonbot::MedicBusy[%aiId] == 0))
				AI::RandomEvade(%aiId);
			else
			{
				if ($Spoonbot::JetToPos[%aiId] != "")
					AI::RandomEvade(%aiId);
				schedule("AI::SetUpEvade(" @ %aiId @ ");", 2);
				$Spoonbot::JetToPos[%aiId] = "";
			}
			$Spoonbot::StuckGracePeriod[%aiId] = 0;
		}

	      }
	}

	$Spoonbot::lastPosition[%aiId] = %AiPos;

//
//
// Start if main AI action 'IF' sequence
//
//


//if we have a flag do something with it
//WILL cap if its not inside and they can access it
//if dont cap within 60 seconds, die to let humans have it
if ((Player::getMountedItem(%aiId, $FlagSlot) != -1)  && ($Spoonbot::justGotFlag[%aiId] >= 0))
{
	if($Spoonbot::justGotFlag[%aiId] == 1)
	{
		$Spoonbot::JetToPos[%aiId] = "";
		$Spoonbot::justGotFlag[%aiId] = 0;
	}
	$Spoonbot::DemoTarget[%aiId] = 0;
	$increaseflag[%aiId] = $increaseflag[%aiId] + 1;
	if (!BotFuncs::CheckAlive(%aiId))
	{
		$ThinkingNow[%aiId] = 0;
		return;
	}
	if ($increaseflag[%aiId] == 80)
	{
		$increaseflag[%aiId] = 0;
		Player::kill(%aiId);
	}
	//Jump up and forward every now and then just in case
	%flyaway = floor(getRandom() * 10/$Spoonbot::ThinkingInterval);
	if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == ""))
	{
		if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
		{
			AI::EvadeUp(%aiId);
			schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
		}
	}
	%aiName = Client::getName(%aiId);
	%team = GameBase::getTeam(%aiId);
	%flaghere = BotFuncs::GetFlagId(%team);
	%newbugs = GameBase::GetPosition(%flaghere);

	%AiPos = GameBase::getPosition(%aiId);
	%xPos = getWord(%AiPos, 0);
	%yPos = getWord(%AiPos, 1);
	%zPos = 0;
	%FlagzPos = getWord(%newbugs, 2);
	%FLATaiPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	%FlagHeightPos = %xPos @ "  " @ %yPos @ "  " @ %FlagzPos;

	%FxPos = getWord(%newbugs, 0);
	%FyPos = getWord(%newbugs, 1);
	%FzPos = 0;
	%FLATflagpos = %FxPos @ "  " @ %FyPos @ "  " @ %FzPos;
	%flag = %FxPos @ "  " @ %FyPos @ "  " @ %FlagzPos;

	%DistanceToFlag = Vector::getDistance(%FLATaiPos, %FLATflagpos);
	if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag >= 50))
	{
		if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
		{
			AI::EvadeUp(%aiId);
			schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
		}
	}
	if (($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag <= 50) && (%DistanceToFlag >=10))
	{
		%xPos = getWord(%newbugs, 0);
		%yPos = getWord(%newbugs, 1);
		%zPosTemp = getWord(%newbugs, 2);
		%zPos = %zPosTemp + 3;
		%flagplus = %xPos @ "  " @ %yPos @ "  " @ %zPos;
		AI::JetToPos(%aiId,%flagplus);		//Up 3 feet - (flag stands, etc.)
	}
	AI::DirectiveWaypoint(%aiName, %newbugs,  255);
	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
	return;
}
else
	$Spoonbot::justGotFlag[%aiId] = -1;

if (BotTypes::isCMD(%aiName) == 1)
{
	schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
	return;
}

// Check to see if AI is healthy. If not get help.

	if (BotFuncs::IsHealthy(%aiId) == False) // Not Healthy. Return to Base (Or Find a Medic?)
	{

		if ($Spoonbot::DebugMode)
			dbecho (1,"STATUS BotThink::Think = IsHealthy returned False");


// Lets see if we've got a repair kit. If so use it.

		%kitcount = Player::GetItemCount(%aiId,RepairKit);

		if(%kitcount > 0)
		{
			Player::useItem(%aiId,RepairKit); // Not sure about this one - Wicked69

			if ($Spoonbot::DebugMode)
				dbecho (1, "STATUS BotThink::Think = Using Repairkit");

		}
		else
		{

// Lets find a medic!

			%Medic = BotFuncs::FindNearestTeamAI(%aiId, 0, 500, 0, "Medic");
	
			if (%Medic == 0) // Not Found
			{


				if ($Spoonbot::DebugMode)
					echo ("STATUS BotThink::Think = No Medic found, returning to base.");

//Return to Base, no medic available - needs work to use tree points- Wicked69

				AI::DirectiveWaypoint( %aiName, $BotThink::BotHome[%aiId], 2, 0 );
				if(BotFuncs::CheckAlive(%aiId) == "true")
					$Spoonbot::BotStatus[%aiId] = "Retreating";
				else
					$Spoonbot::BotStatus[%aiId] = "Dead";

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
				if(BotFuncs::CheckAlive(%aiId) == "true")
					$Spoonbot::BotStatus[%aiId] = "Visit Medic";
				else
					$Spoonbot::BotStatus[%aiId] = "Dead";
			}
		}

		if ($Spoonbot::DebugMode)
			 echo ("STATUS BotThink::Think = End Medic stuff ");
		if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}

// User Requested Move

	else if (BotFuncs::NearestAttacker(%aiId, 500, 2) != 0)
	{
		$BotThink::ForcedOfftrack[%aiId] = True;
		%UserRequest = BotFuncs::NearestAttacker(%aiId, 999, 2);
		if (%UserRequest == 0)

//Nearest request too far away... So delete it

		{
			%UserRequest = BotFuncs::NearestAttacker(%aiId, 9999, 2);
			BotFuncs::DelAttacker(%aiId,%UserRequest);
		}
		else

		// Go to User Requeued Location

		{
			%xPos = getWord(%AiPos, 0);
			%yPos = getWord(%AiPos, 1);
			%zPos = 0;
			%FLATaiPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
			%targetDist = Vector::getDistance(%FLATaiPos,%UserRequest);
			if (%targetDist >= 10)
			{
//				AI::HuntTarget(%aiName, %UserRequest, 1);
				AI::DirectiveWaypoint(%aiName, %UserRequest, 255);
				schedule ("AI::DirectiveRemove(" @ %aiName @ ", 255);", $Spoonbot::ThinkingInterval);
				$Spoonbot::BotStatus[%aiId] = "Moving";
				// Requeue Think
				if (%requeue == True)
				schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
				return;
			}
			else
			{
				BotFuncs::DelAttacker(%aiId,%UserRequest);
			}
		}
	}

	else if(BotTypes::IsFG(%aiName) == 1)							// If FG bot, then use FG code - Mr. X
	{
		BotThink::GuardFlag(%aiName,%aiId,%aiTeam);
		// Requeue Think
		if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}
	else if(BotTypes::IsCTF(%aiName) == 1) 							// If CTF bot, then use CTF code - Mr. X
	{
		BotThink::GetFlag(%aiName,%aiId,%aiTeam);
		// Requeue Think
		if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}
	else if(BotTypes::IsMedic(%aiName) == 1)							// If medic then try to find item to repair.
	{
		BotThink::Medic(%aiName,%aiId,%aiTeam);
		// Requeue Think
		if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}
	else if(BotTypes::IsDemo(%aiName) == 1)							// If Demo then spank enemy installations.
	{
		BotThink::Demo(%aiName,%aiId,%aiTeam);
		// Requeue Think
		if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}

//---------------------------------------------------------------------------------------------------------------------


//	else if(BotTypes::IsSniper(%aiName) == 1) // If sniper then try to find a sniper point.
//	{
//
//		AI::SetVar(%aiName, triggerPct, 0.01 );
//	 	if ($Spoonbot::DebugMode)
//			dbecho(1,"Sniper attack for " @ %ainame);
//	 	if ($Spoonbot::DebugMode)
//			dbecho(1,%ainame @ " attack due to sniper");
//		if(($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]))
//			BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);
//		BotThink::NormalBotBehaviour(%aiName, %aiId);
//	}

//Deleted an "elseif" here because the actual move code wasn't called!!!

// AI Team Mate Requested Move

	if (BotFuncs::NearestAttacker(%aiId, 500, 3) != 0)
	{

		if ($Spoonbot::DebugMode)
			echo ("STATUS BotThink::Think = AI Teammate requested move");

		$BotThink::ForcedOfftrack[%aiId] = True;

		%AIRequest = BotFuncs::NearestAttacker(%aiId, 150, 3);  //To Wicked69: You had a typo here ;-)
 
		if (%AIRequest == 0)

//Nearest request too far away... So delete it

		{
			%AIRequest = BotFuncs::NearestAttacker(%aiId, 999, 3);
			BotFuncs::DelAttacker(%aiId,%AIRequest);
		}
		else
		{
// Go to AI Requeted Location

			%friendlyName = Client::getName(%AIRequest);

			if(($Spoonbot::MedicBusy[%aiId] == 0) && ($Spoonbot::DemoTarget[%aiId] == 0))
			{
				$Spoonbot::BotStatus[%aiId] = "Helping "  @ %FriendlyName;
				AI::HuntTarget(%aiName, %AIRequest, 1);
			}
			else if(($Spoonbot::DemoTarget[%aiId]!=0) && (!BotFuncs::CheckForLOS(%aiId, $Spoonbot::DemoTarget[%aiId])))
			{
				$Spoonbot::BotStatus[%aiId] = "Helping "  @ %FriendlyName;
				AI::HuntTarget(%aiName, %AIRequest, 0);
			}

			// Requeue Think
			if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
			return;
		}
	}

	else if(($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]))
		BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);
	else
		BotThink::NormalBotBehaviour(%aiName, %aiId);

// Self Goal Move eg. defend base, go to base etc.

	if (BotFuncs::NearestAttacker(%aiId, 999, 4) != 0)
	{

		if($BotThink::ForcedOfftrack[%aiId]) // If forced off track by enemy intervention
											 // Attacked, weak etc then we mut recalculate
											 // our destination.
		{

			// Clear current treepoint route entries. Were
			// Potentially lost and the current route could
			// be invalid!

			BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);

		}
		else
		{
			if ($Spoonbot::DebugMode)
				echo ("STATUS BotThink::Think = Self goal move");

			%AIRequest = BotFuncs::NearestAttacker(%aiId, 999, 4);

			%Distance = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]));

			%Distance2 = Vector::getDistance(GameBase::getPosition(%aiId), %AIRequest);

			//dbecho(1,"Distance to tree point (" @ %AIRequest @ ") = " @ %Distance );

			//echo("SELF GOAL MOVE " @ %aiid @ " team = " @ %aiteam @ ", enemyteam = " @ %enemyteam @ ", attackpoint = " @ $BotThink::Definitive_Attackpoint[%aiId] @ ", attackpoint team = " @ GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]));

//			AI::DirectiveRemove(%aiName, 2048);

//			if ((BotFuncs::CheckForLOS(%aiId, $BotThink::Definitive_Attackpoint[%aiId])) && ($BotThink::LastPoint[%aiId] == False) && (%enemyteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId])))
			if((%Distance < 10) && ($BotThink::LastPoint[%aiId] == False) && (%enemyteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]))) // Attack Target!
			{
				BotFuncs::Attack(%aiId, $BotThink::Definitive_Attackpoint[%aiId]);
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::ForcedOfftrack[%aiId] = True;
			}

//			if ((BotFuncs::CheckForLOS(%aiId, $BotThink::Definitive_Attackpoint[%aiId])) && ($BotThink::LastPoint[%aiId] == False) && (%aiteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId])))
			if((%Distance < 10) && ($BotThink::LastPoint[%aiId] == False) && (%aiteam == GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]))) // Attack Target!
			{
				AI::DirectiveWaypoint(%aiName, GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]), 1024); //was 2048 was 1024 - mr. x
				schedule("AI::DirectiveRemove(%aiName, 1024);",$Spoonbot::ThinkingInterval);
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::ForcedOfftrack[%aiId] = True;
			}

	
			if((%Distance < 2.5) && ($BotThink::LastPoint[%aiId] == True)) // Reached target, now look for next!
			{
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::ForcedOfftrack[%aiId] = True;
			}


			%DiffHeight = getWord(%AIRequest,2) - (getWord(GameBase::getPosition(%aiId),2));

// Get Bot to start jetting when/if target is a 45 degrees - crude interpretation

			if(%DiffHeight > (%Distance/ 2))
			{
	if ($Spoonbot::DebugMode)
				dbecho(1,%aiId @ " Jetting!!! ");

				$Spoonbot::BotJettingHeat[%aiId] = 1;
				AI::JetToHeight(%aiId, (getWord(%AIRequest,2) + 3));
				$Spoonbot::BotJettingHeat[%aiId] = 0;
			}

			//dbecho(1, %aiId @ " current waypoint = " @ %AIRequest @ ", distance = " @ %Distance );

// Go to AI Requested Location

			AI::DirectiveWaypoint( %aiName, %AIRequest, 125 );
			schedule("AI::DirectiveRemove(%aiName, 125);",$Spoonbot::ThinkingInterval);

			//dbecho(1,"AI::DirectiveWaypoint(" @ %aiName @ "," @ %AIRequest @ ", 125 );");
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




function BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam)
{

	if (!BotFuncs::CheckAlive(%aiId))
	{
		return;
	}

	if(%aiTeam == 0)
		%EnemyTeam = 1;
	else
		%EnemyTeam = 0;

if($Spoonbot::NormalRoam[%aiId]==0)
{
	$Spoonbot::NormalRoam[%aiId] = 1;
	$Spoonbot::BotStatus[%aiId] = "Determining Objective";
	$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
}

	$Spoonbot::MedicTask[%aiId] = -1;

// First decide if attacking enemy or defending or if we've got an existing destination

		if ((1 == 1) ||		// Fix to always attack a present!
			($BotThink::Definitive_Attackpoint[%aiId] != ""))
		{

			if($BotThink::Definitive_Attackpoint[%aiId] == "")
			{
				//dbecho(1,"no definitive");

				%Target = -1;
				%LastPoint = False;

				%loopcount = 0;

				while((%Target == -1) && (%loopcount < 10))
				{
					%loopcount = %loopcount + 1;

					//dbecho(1,"Target Loop");

					%AttackDefend = floor(getRandom() * 10); // heavily weighted towards attacking.

					if (%AttackDefend > 1) // Selects team eg if enemy team attack else defend.
						%AttackDefend = %enemyTeam;

					%mod = floor(getRandom() * 8); // 7 Groups + 1 for Extra Flag Selection

					%flagDist = BotFuncs::GetDistanceToFlag(%aiId, BotFuncs::GetFlagId(%AttackDefend));  //By Werewolf, makes the bot go for the flag if it's near it.

					if (%flagDist < 5)
						%mod = 7;

					//dbecho(1,"%mod = " @ %mod);

					if (%mod == 1) // Vehicle type Targets
					{
						%Target = BotFuncs::GetVehId(%AttackDefend);
						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));
						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;

						%TargetType = "Vehicle Pads";
					}
					else if (%mod == 2) // Sensor Type Targets
					{
						%Target = BotFuncs::GetSensorId(%AttackDefend);

						//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
//						if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
//							%Target = -1;

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));
						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;

						%TargetType = "Sensors";
					}
					else if (%mod == 3) // Gun Type Targets
					{
						%Targetmode = floor(getRandom() * 2);
						if(%Targetmode == 0)
							%Target = BotFuncs::GetClosestGunID(%aiId,%AttackDefend);
						else
							%Target = BotFuncs::GetGunId(%AttackDefend);

						//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
//						if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
//							%Target = -1;

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;

						%TargetType = "Guns";
					}
					else if (%mod == 4) // Gen Type Targets
					{
						%Target = BotFuncs::GetGenId(%AttackDefend);

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;
					
						%TargetType = "Generators";
					}
					else if (%mod == 5) // Com Type Targets
					{
						%Target = BotFuncs::GetComId(%AttackDefend);

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;
						
						%TargetType = "Command Stations";
					}
					else if (%mod == 6) // Inv Type Targets
					{
						%Target = BotFuncs::GetInvId(%AttackDefend);

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;
						
						%TargetType = "Inventory Points";
					}
					else // Flags etc.
					{
						%Target = BotFuncs::GetFlagId(%AttackDefend);
						%LastPoint = True;
						
						%TargetType = "Flags";
					}
		
					%Distance = Vector::getDistance($BotTree::Treepoint_Location[BotTree::FindNearestTreebyId(%Target)],GameBase::getPosition(%Target));

					if(%Target == "")
						%Target = -1;
				}

					$Spoonbot::TargetType[%aiId] = "";
					$Spoonbot::TargetStyle[%aiId] = "";

				//dbecho(1,%aiid @ " Target = " @ %Target );				

				if(%Target != -1)
				{
					%AttackPos = GameBase::getPosition(%Target);
					%AttackPoint = %Target;
					$Spoonbot::TargetType[%aiId] = %TargetType;
					$BotThink::LastPoint[%aiId] = %LastPoint;

					if(%AttackDefend == %enemyteam)
					{
						%Style = "Attacking Enemy";
						$Spoonbot::TargetStyle[%aiId] = %Style;
						$Spoonbot::BotStatus[%aiId] = "Attacking enemy " @ $Spoonbot::TargetType[%aiId]; // This is for the BotHud
//						$BotThink::Demo_Attackpos[%aiId] = %AttackPos;
					}
					else
					{
						%Style = "Defending team";
						$Spoonbot::TargetStyle[%aiId] = %Style;
						$Spoonbot::BotStatus[%aiId] = "Defending team " @ $Spoonbot::TargetType[%aiId]; // This is for the BotHud
					}

					%aiTeam = Client::getTeam(%aiId);

					if ($Spoonbot::AnnounceBotChat == True)
						BotFuncs::TeamMessage(%aiteam,%AiName @ ": " @ %Style @ " " @ %TargetType );

					$Spoonbot::SaveBotStatus[%aiId] = $Spoonbot::BotStatus[%aiId];

					//dbecho(1,%AiName @ ": " @ %Style @ " " @ %TargetType @ ", id = " @ %Target );
				}
			}
			else
			{
				%AttackPoint = $BotThink::Definitive_Attackpoint[%aiId];
				%AttackPos = $BotThink::Definitive_Attackpos[%aiId];
				%LastPoint = $BotThink::LastPoint[%aiId];
			}

// Determine Nearest TreePoint to attack Point.

			if(%Attackpoint != -1)
			{
// - Mr. X				BotTree::GetMeToPos(%aiId, %AttackPos, %LastPoint);
				$BotThink::Definitive_Attackpoint[%aiId] = %AttackPoint;
				$BotThink::Definitive_Attackpos[%aiId] = %AttackPos;
				$BotThink::ForcedOfftrack[%aiId] = false;
				$BotThink::LastPoint[%aiId] = %LastPoint;

				$Spoonbot::BotStatus[%aiId] = $Spoonbot::SaveBotStatus[%aiId];

				if($Spoonbot::TargetType[%aiId] == "Flags")
				{
					$Spoonbot::DemoTarget[%aiId]=0;
					$Spoonbot::Target[%aiId]=0;
					if($Spoonbot::TargetStyle[%aiId] == "Attacking Enemy")
						BotThink::GetFlag(%aiName);
					else
						BotThink::GuardFlag(%aiName);				
				}
				else
				{
					if(GameBase::getTeam($BotThink::Definitive_Attackpoint[%aiId]) == %EnemyTeam)
					{
						$Spoonbot::DemoTarget[%aiId]=$BotThink::Definitive_Attackpoint[%aiId];
//						$Spoonbot::Target[%aiId]=$BotThink::Definitive_Attackpoint[%aiId];
						BotFuncs::PaintTarget(%aiName, $Spoonbot::DemoTarget[%aiId]);
					}
					else
					{
						AI::DirectiveWaypoint(%aiName, $BotThink::Definitive_Attackpos[%aiId], 255);
						$Spoonbot::DemoTarget[%aiId]=0;
						schedule ("AI::DirectiveRemove(" @ %aiName @ ", 255);", $Spoonbot::ThinkingInterval);
					}
				}
				if (GameBase::getDamageLevel($BotThink::Definitive_Attackpoint[%aiId]) >= 0.99)
				{
					$BotThink::Definitive_Attackpoint[%aiId] = "";
					$BotThink::Definitive_Attackpos[%aiId] = -1;
				}
			}
		}

}

function BotThink::NormalBotBehaviour(%aiName, %aiId)
{
%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;
if (!BotFuncs::CheckAlive(%aiId))
	return;
%aiTeam = Client::getTeam(%aiId);
if ($Spoonbot::DemoTarget[%aiId]!=0)
{
	if (BotFuncs::CheckForLOS(%aiId, $Spoonbot::DemoTarget[%aiId]))
	{
		$Spoonbot::Target[%aiId] = 0;
		BotFuncs::PaintTarget(%aiName, $Spoonbot::DemoTarget[%aiId]);
		return;
	}
}
if ($Spoonbot::Target[%aiId]!=0)
{
	if (!BotFuncs::CheckForLOS(%aiId, $Spoonbot::Target[%aiId])) 
		AI::HuntTarget(%aiName, $Spoonbot::Target[%aiId], 1);
}
if ($Spoonbot::Target[%aiId]!=0)
	if (BotFuncs::CheckAlive($Spoonbot::Target[%aiId]))
		return;

	%attacking = False;
	if ($Spoonbot::HuntFlagrunner == 0)      //Check if in Normal mode or if bots are chasing a flagrunner
	{
		%mode = floor(getRandom() * 3);      //There are two modes of operation: 1) Attack random enemy and 2) attack/defend objects
		  if (%mode == 0)
		  {

			$Spoonbot::NormalRoam[%aiId] = 1;
			$Spoonbot::MedicTask[%aiId] = -1;
			$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
			%clN = BotFuncs::NearestAttacker(%aiId, 300, 6);
			if (%clN > 0)
			{
//				BotFuncs::AddAttacker(%clN,%aiId,999,4);
				BotFuncs::AddAttacker(%aiId,%clN,999,4);
				$Spoonbot::Target[%aiId]=%clN;
				%enemyName = Client::getName(%clN);
				%Attackerteam = Client::getTeam(%clN);
				if (%aiTeam == %Attackerteam)
					$Spoonbot::BotStatus[%aiId] = "Helping " @ %enemyName;
				else
					$Spoonbot::BotStatus[%aiId] = "Attacking " @ %enemyName;
				%attacking = True;
				if ((!Player::isDead(%clN))&&(BotFuncs::CheckAlive(%clN)))
					AI::HuntTarget(%aiName, $Spoonbot::Target[%aiId], 1);
				else
				{
					$Spoonbot::Target[%aiId]=0;
					%mode = floor(getRandom() * 2);
					%mode = %mode+1;
				}
			}
			else
				BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);
		  }
		  else 							//mode 1 and 2 mean attack/defend base equipment
			BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);
									 //End of mode 1 and 2
	}
			//end of roaming part, now comes the flagrunner-chasing part.
			//----------All this stuff is now inside BotFuncs.cs------------
	else
	{
		%cl = $Spoonbot::HuntFlagrunner;
		%targetTeam = Client::getTeam(%cl);
		if (%targetTeam != %aiTeam)           //Is this an enemy?
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				BotThink::GuardFlag(%aiName,%aiId,%aiTeam);
			}
		}
		else				    //else this is a friendly, so let's escort him to safety.
		{
		          %player = Client::getOwnedObject(%cl);
		 	  if (!Player::isDead(%player))
			  {
				BotThink::GetFlag(%aiName,%aiId,%aiTeam);
		 	  }
		}
	}
// End of Original Roam Code
}

function BotThink::GuardFlag(%aiName,%aiId,%aiTeam)
 // If FG bot, then use FG code - Mr. X								
//Defend and Chase-Return the flag
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;
	if (!BotFuncs::CheckAlive(%aiId))
		return;
	//now sticks to flag and hunts it down if flag is gone
	$Spoonbot::BotStatus[%aiId] = "Defending/Chasing Team Flag";
	$Spoonbot::DemoTarget[%aiId] = 0;
	$Spoonbot::MedicBusy[%aiId] = 0;
	%imtheone = 0;
	%flaghere = BotFuncs::GetFlagId(%aiTeam);
	%newbugs = GameBase::GetPosition(%flaghere);
	//Jump up and forward every now and then just in case
	%flyaway = floor(getRandom() * 10/$Spoonbot::ThinkingInterval);
	//Enumerate all clients and see if an enemy has flag
	%startCl = 2049;		                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!
	%numHumans = $Server::MaxPlayers;
	if (%numhumans < 1)
		%numHumans = 32;
	%endCl = %startCl +%numHumans + $Spoonbot::NumBots + 1;
//	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	for(%cl = %startCl; %cl < %endCl; %cl++)
	{
		%clteam = Client::getTeam(%cl);
		//Client is not same team as bot
		if(%clteam != %aiTeam)
		{
		   %player = Client::getOwnedObject(%cl);
		   if (!Player::isDead(%player))
			   {
				//And enemy has a flag
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)
				{
					%imtheone = %cl;
					$Spoonbot::HuntFlagrunner = %cl;
				}
			   }
		}
	}
	//If so then follow that enemy
	if (%imtheone != 0)
	{
		if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == ""))
		{
			if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
			{
				AI::EvadeUp(%aiId);
				schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
			}
		}
		//get position of the one with flag
		%newguy = GameBase::GetPosition(%imtheone);
		AI::DirectiveWaypoint(%aiName, %newguy,  255);
		$Spoonbot::Target[%aiId] = %imtheone;
		$BotThink::ForcedOffTrack[%aiId] = False;
		return;		
	}
	//If not then go right to the flag
	else
	{
		%AiPos = GameBase::getPosition(%aiId);
		%xPos = getWord(%AiPos, 0);
		%yPos = getWord(%AiPos, 1);
		%zPos = 0;
		%FlagzPos = getWord(%newbugs, 2);
		%FLATaiPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
		%FlagHeightPos = %xPos @ "  " @ %yPos @ "  " @ %FlagzPos;

		%FxPos = getWord(%newbugs, 0);
		%FyPos = getWord(%newbugs, 1);
		%FzPos = 0;
		%FLATflagpos = %FxPos @ "  " @ %FyPos @ "  " @ %FzPos;
		%flag = %FxPos @ "  " @ %FyPos @ "  " @ %FlagzPos;

		%DistanceToFlag = Vector::getDistance(%FLATaiPos, %FLATflagpos);
		if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag >= 50))
		{
			if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
			{
				AI::EvadeUp(%aiId);
				schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
			}
		}
		if (($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag <= 50) && (%DistanceToFlag >=10))
		{
//			AI::DirectiveRemove( %aiName, 255);
			%xPos = getWord(%newbugs, 0);
			%yPos = getWord(%newbugs, 1);
			%zPosTemp = getWord(%newbugs, 2);
			%zPos = %zPosTemp + 3;
			%flagplus = %xPos @ "  " @ %yPos @ "  " @ %zPos;
			AI::JetToPos(%aiId,%flagplus);		//Up 3 feet - (flag stands, etc.)
		}
		%DistanceToFlag = Vector::getDistance(%aiPos, %flag);
		if(%DistanceToFlag <= 1)
			$Spoonbot::JetToPos[%aiId] = "";
		AI::DirectiveWaypoint(%aiName, %newbugs,  255);

		if((BotTypes::IsFG(%aiName) == 1) && ($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]) && ($Spoonbot::JetToPos[%aiId] == ""))
			BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);

		AI::DirectiveWaypoint(%aiName, %newbugs,  255);
		return;
	}
}								//End FG code - Mr. X

function BotThink::GetFlag(%aiName,%aiId,%aiTeam)
//Only go for enemy flag or escort anyone who has it
{
	%aiId = BotFuncs::GetId(%aiName);
	    if (%aiId==0)
		    return;
	if (!BotFuncs::CheckAlive(%aiId))
		    return;
	$Spoonbot::DemoTarget[%aiId] = 0;
	$Spoonbot::MedicBusy[%aiId] = 0;
	$Spoonbot::BotStatus[%aiId] = "Attacking/Escorting Enemy Flag";
	%imtheone = 0;
	if (%aiTeam == 1)
		  %enemyTeam = 0;
	else
		  %enemyTeam = 1;
	%flaghere = BotFuncs::GetFlagId(%enemyTeam);
	%newbugs = GameBase::GetPosition(%flaghere);
	%flyaway = floor(getRandom() * 10/$Spoonbot::ThinkingInterval);
	%startCl = 2049;		                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!
	%numHumans = $Server::MaxPlayers;
	if (%numhumans < 1)
		%numHumans = 32;
	%endCl = %startCl +%numHumans + $Spoonbot::NumBots + 1;
//	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	for(%cl = %startCl; %cl < %endCl; %cl++)
	{
		%clteam = Client::getTeam(%cl);
		if(%clteam == %aiTeam)
		{
			   %player = Client::getOwnedObject(%cl);
			   if (!Player::isDead(%player))
			   {
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)
				{
					%imtheone = %cl;
					$Spoonbot::HuntFlagrunner = %cl;
					if(%aiId == %cl)
					{
						$Spoonbot::justGotFlag[%aiId] = 1;
						BotThink::Think(%aiId,False);
					}
				}
			}
		}
	}
	if (%imtheone != 0)
	{
		if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == ""))
		{
			if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
			{
				AI::EvadeUp(%aiId);
				schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
			}
		}
		%newguy = GameBase::GetPosition(%imtheone);
		AI::DirectiveWaypoint(%aiName, %newguy,  255);
		$Spoonbot::Target[%aiId] = %imtheone;
		$BotThink::ForcedOffTrack[%aiId] = False;
		return;		
	}
	else
	{
		%AiPos = GameBase::getPosition(%aiId);
		%xPos = getWord(%AiPos, 0);
		%yPos = getWord(%AiPos, 1);
		%zPos = 0;
		%FlagzPos = getWord(%newbugs, 2);
		%FLATaiPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
		%FlagHeightPos = %xPos @ "  " @ %yPos @ "  " @ %FlagzPos;

		%FxPos = getWord(%newbugs, 0);
		%FyPos = getWord(%newbugs, 1);
		%FzPos = 0;
		%FLATflagpos = %FxPos @ "  " @ %FyPos @ "  " @ %FzPos;
		%flag = %FxPos @ "  " @ %FyPos @ "  " @ %FlagzPos;

		%DistanceToFlag = Vector::getDistance(%FLATaiPos, %FLATflagpos);
		if ((%flyaway == 0) && ($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag >= 50))
		{
			if (($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] == 0))
			{
				AI::EvadeUp(%aiId);
				schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
			}
		}
		if (($Spoonbot::JetToPos[%aiId] == "") && (%DistanceToFlag <= 50) && (%DistanceToFlag >=10))
		{
//			AI::DirectiveRemove( %aiName, 255);
			%xPos = getWord(%newbugs, 0);
			%yPos = getWord(%newbugs, 1);
			%zPosTemp = getWord(%newbugs, 2);
			%zPos = %zPosTemp + 3;
			%flagplus = %xPos @ "  " @ %yPos @ "  " @ %zPos;
			AI::JetToPos(%aiId,%flagplus);		//Up 3 feet - (flag stands, etc.)
		}
		AI::DirectiveWaypoint(%aiName, %newbugs,  255);

		if((BotTypes::IsCTF(%aiName) == 1) && ($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]) && ($Spoonbot::JetToPos[%aiId] == ""))
			BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);

		AI::DirectiveWaypoint(%aiName, %newbugs,  255);
		return;
	}
}										//End Mr. X CTF/FG/STD Code

function BotThink::Medic(%aiName,%aiId,%aiTeam)
//Medic/Sniper stuff
{		
if (%aiId==0)
	return;
if (!BotFuncs::CheckAlive(%aiId))
	return;
	if (($Spoonbot::MedicTask[%aiId] == -1) || ($BotThink::Definitive_Attackpoint[%aiId] == ""))  // no target to repair, get one!
	{
		if (!$SPOONBOT::RepairObject[%aiId] == 0)
		{
			%Task = $SPOONBOT::RepairObject[%aiId];
			$Spoonbot::MedicTask[%aiId] = %Task;
		}
		else
		{
			%Task = BotFuncs::GetRepairTask(%aiName);
			if(%Task != -1)
			{
				BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 1);
				BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 3);
				BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
			}
		}
		if(%Task != -1)
		{
			$Spoonbot::DemoTarget[%aiId]=0;
			%object = %Task;
			// %object = $Spoonbot::RepairTaskObject[%task];
			%objectpos = GameBase::getPosition(%object);
			BotTree::Getmetopos(%aiid,%objectpos, false);
			$Spoonbot::MedicTask[%aiId] = %task;
			$SPOONBOT::RepairObject[%aiId] = %task;
			$Spoonbot::Target[%aiId] = %object;
			$BotThink::Definitive_Attackpoint[%aiId] = %object;
			$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
			$BotThink::ForcedOfftrack[%aiId] = True;
			$BotThink::LastPoint[%aiId] = False;
			$Spoonbot::BotStatus[%aiId] = "Performing Repairs";
		}
	}
	if($Spoonbot::MedicTask[%aiId] != -1) // Have a target ? Close enough to repair ? repaired ?
	{
		$Spoonbot::DemoTarget[%aiId]=0;
		$Spoonbot::Target[%aiId] = 0;
		%object = $Spoonbot::MedicTask[%aiId];
		%objectpos = GameBase::getPosition(%object);
		%aiPos = GameBase::getPosition(%aiId);
		%curDistance = Vector::getDistance(GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]),%aipos);  //Check if AI is in range for repairs
		if (%curDistance < 20)
		{
			if (GameBase::getDamageLevel(%object) <= 0.0)
			{
				AI::DirectiveRemove(%aiName, 2048);
				%rate = 0;
				GameBase::setAutoRepairRate(%object,%rate);
				$Spoonbot::MedicTask[%aiId] = -1;
				$Spoonbot::MedicBusy[%aiId] = 0;
				$Spoonbot::Target[%aiId] = 0;
//				BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::Definitive_Attackpos[%aiId] = -1;
				$BotThink::ForcedOfftrack[%aiId] = True;
				$SPOONBOT::RepairObject[%aiId] = 0;
				%Task = BotFuncs::GetRepairTask(%aiName);
				
				if(%Task != -1)
				{
					$Spoonbot::DemoTarget[%aiId]=0;
					%object = %Task;
					%objectpos = GameBase::getPosition(%object);
//					BotTree::Getmetopos(%aiid,%objectpos, false);
					$Spoonbot::MedicTask[%aiId] = %task;
					$BotThink::Definitive_Attackpoint[%aiId] = %object;
					$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					$BotThink::ForcedOfftrack[%aiId] = True;
					$BotThink::LastPoint[%aiId] = False;
					$SPOONBOT::RepairObject[%aiId] = %object;
				}
				else
				{
				$Spoonbot::MedicBusy[%aiId] = 0;
				$Spoonbot::Target[%aiId] = 0;
				$Spoonbot::BotStatus[%aiId] = "Idle";
				$Spoonbot::MedicTask[%aiId] = -1;
				$Spoonbot::Target[%aiId]=0;
				$Spoonbot::AlreadyLookedForTargets[%aiId] = False;
				$SPOONBOT::RepairObject[%aiId] = 0;
				$BotThink::Definitive_Attackpoint[%aiId] = "";
				$BotThink::Definitive_Attackpos[%aiId] = -1;
				$BotThink::ForcedOfftrack[%aiId] = True;
				}
			}
			else
			{
				//BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 3);
				if (($BotThink::LastPoint[%aiId] == False)&&($Spoonbot::MedicBusy[%aiId] == 0))
					AI::DirectiveWaypoint(%aiName, GameBase::GetPosition(%object), 2048);
				%repairRate = 0.1;
				%damage = GameBase::getDamageLevel(%object);
				$Spoonbot::MedicBusy[%aiId] = 1;
				%difference = 0;
				%difference = %damage - %repairRate;
				if ((%damage >= 0.0) && (%difference < 0.0))	//If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
				{
					%repairRate = %damage;
					AI::DirectiveRemove(%aiName, 2048);
					$Spoonbot::MedicTask[%aiId] = -1;
					$BotThink::Definitive_Attackpoint[%aiId] = "";
					$BotThink::Definitive_Attackpos[%aiId] = -1;
					$Spoonbot::MedicBusy[%aiId] = 0;
					$Spoonbot::Target[%aiId] = 0;
					$SPOONBOT::RepairObject[%aiId] = 0;
					$BotThink::ForcedOfftrack[%aiId] = True;
//					BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
				}
				else
					$SPOONBOT::RepairObject[%aiId] = %object;
				%newDamage = 0;
				%newDamage = %damage - %repairRate;
				GameBase::setDamageLevel(%object, %newDamage);
				return;
			}
		}
		else
		{
			%object = $Spoonbot::MedicTask[%aiId];
			AI::DirectiveWaypoint(%aiName, GameBase::GetPosition(%object), 2048);
			$Spoonbot::MedicBusy[%aiId] = 0;
			$SPOONBOT::RepairObject[%aiId] = %object;
			return;
		}
	}
	if(($Spoonbot::MedicTask[%aiId] == -1) || ($BotThink::Definitive_Attackpoint[%aiId] == "")) 
	{			// no repair task, do normal attack/defend - on your bike for now!
		if(($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]))
			BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);
		BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);
//		BotThink::NormalBotBehaviour(%aiName, %aiId);
	}
}

function BotThink::Demo(%aiName,%aiId,%aiTeam)			// If Demo then spank enemy installations.
{
	if (%aiId==0)
		return;
	if (!BotFuncs::CheckAlive(%aiId))
		return;
 	if ($Spoonbot::DebugMode)
		dbecho(1, "Demo code running");
//		%aiTeam = Client::getTeam(%aiId);
		if(%aiTeam == 0)
		  %EnemyTeam = 1;
		else
		  %EnemyTeam = 0;
		%Target = -1;
		%AttackDefend=%EnemyTeam;

	if ($Spoonbot::DemoTarget[%aiId] <= 0)
	{
			%Targetmode = floor(getRandom() * 2);
			if(%Targetmode == 0)
				%Target = BotFuncs::GetClosestGunID(%aiId,%AttackDefend);
			else
				%Target = BotFuncs::GetGunId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.99) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Guns";

		if (%Target==-1)
		{
			%Target = BotFuncs::GetVehId(%AttackDefend);
 			if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.95) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Vehicle Pads";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetSensorId(%AttackDefend);
 			if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.95) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Sensors";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetInvId(%AttackDefend);
 			if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.95) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Inventory Stations";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetComId(%AttackDefend);
 			if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.95) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Command Stations";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetGenId(%AttackDefend);
 			if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.95) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Generators";
		}
		if (%Target==-1)
			%Target=0;
		if (%Target!=0)
		{
			$Spoonbot::DemoTarget[%aiId] = %Target;
			$Spoonbot::TargetType[%aiId] = %TargetType;
//			$BotThink::Demo_Attackpos[%aiId] = GameBase::getPosition(%Target);
			BotFuncs::PaintTarget(%aiName, %Target);	
			return;
		}
		else
			$Spoonbot::DemoTarget[%aiId]=0;
	}

	if ($Spoonbot::DemoTarget[%aiId]!=0)
	{
		$Spoonbot::BotStatus[%aiId] = "Acquiring lock: enemy " @ $Spoonbot::TargetType[%aiId]; // This is for the BotHud

		$BotThink::ForcedOfftrack[%aiId] = False;
		BotFuncs::PaintTarget(%aiName, $Spoonbot::DemoTarget[%aiId]);
		return;
	}
	else
	{
		$Spoonbot::TargetType[%aiId] = "";
		if(($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]))
			BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);
		BotThink::NormalBotBehaviour(%aiName, %aiId);
	}
}

function BotThink::UnderAttack(%aiId,%aiName,%aiTeam,%Attacker)
// Check to see if bot is under attack & react...
{
		if (%aiId==0)
			return;
		if (!BotFuncs::CheckAlive(%aiId))
			return;
		if (%Attacker==0)
			return;
		if (!BotFuncs::CheckAlive(%Attacker))
			return;

//		%Attacker = BotFuncs::NearestAttacker(%aiId, 100, 6);
// Attacker Found if ID > 0, Set It as Target
    	if (%Attacker > 0)
	{
		$BotThink::ForcedOfftrack[%aiId] = True;
		%NewAttacker = BotFuncs::AddAttacker(%aiId,%Attacker,100,1);
		%enemyName = Client::getName(%Attacker);
		%Attackerteam = Client::getTeam(%Attacker);
		%tempstatus = $Spoonbot::BotStatus[%aiId];
		if (%aiTeam != %Attackerteam)
			$Spoonbot::BotStatus[%aiId] = "Under Attack by "  @ %enemyName;
		else
			$Spoonbot::BotStatus[%aiId] = "Helping "  @ %enemyName;
		if(($Spoonbot::MedicBusy[%aiId] == 0) && ($Spoonbot::DemoTarget[%aiId] == 0))
			AI::HuntTarget(%aiName, %Attacker, 1);
		else if(($Spoonbot::DemoTarget[%aiId]!=0) && (!BotFuncs::CheckForLOS(%aiId, $Spoonbot::DemoTarget[%aiId])))
			AI::HuntTarget(%aiName, %Attacker, 0);
	}
	else
//Nearest attacker too far away... So delete the whole list - will be rebuilt when in range.
	{
		BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 1);
		return;
	}
	if (BotFuncs::IsUnderAttack(%aiId) > 1) 
// More than one attacker, lets drum up support
	{
		if ((%NewAttacker == True) && ($Spoonbot::HelpBotChat == True))
			BotFuncs::TeamMessage(%aiTeam, %aiName @ ": Somebody help...");
		if((String::findSubStr(%tempstatus, "Help") > 0) || (String::findSubStr(%tempstatus, "Idle") > 0))
			$Spoonbot::BotStatus[%aiId] = %tempstatus;
		else
			$Spoonbot::BotStatus[%aiId] = "Need Help: " @ %tempstatus;
		%animation = $PlayerAnim::OverHere;
		BotFuncs::Animation(%aiId, %animation);
		%TeamMateId = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, 0, "");
		if (%TeamMateId != 0)
		{
			if(BotFuncs::AddAttacker(%TeamMateId,%Attacker,50,3))
			{
				if ($Spoonbot::HelpBotChat == True)
					BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMateId) @ ": Coming");
				%Attackerteam = Client::getTeam(%TeamMateId);
				if (Client::getTeam(%TeamMateId) == %Attackerteam)
					$Spoonbot::BotStatus[%TeamMateId] = "Helping " @ %aiName;
				else
					$Spoonbot::BotStatus[%TeamMateId] = "Engaging " @ %aiName;
				%animation = $PlayerAnim::Salute;
				BotFuncs::Animation(%TeamMateId, %animation);
			}
		}
		if (BotFuncs::IsUnderAttack(%aiId) > 2)
// More than two attackers, lets drum up more support !
		{
			if((%NewAttacker == True)  && ($Spoonbot::HelpBotChat == True))
				BotFuncs::TeamMessage(%aiTeam, %aiName @ ": I need more help ...");
			%animation = $PlayerAnim::OverHere;
			BotFuncs::Animation(%aiId, %animation);
			%TeamMate2Id = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, %TeamMateId, "Roam");
			if (%TeamMate2Id != 0)
			{
				if(BotFuncs::AddAttacker(%TeamMate2Id,%Attacker,50,3))
				{
					if ($Spoonbot::HelpBotChat == True)
						BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMate2Id) @ ": Im on my way ...");
					%Attackerteam = Client::getTeam(%TeamMate2Id);
					if (%aiTeam == %Attackerteam)
						$Spoonbot::BotStatus[%TeamMate2Id] = "Also Helping " @ %aiName;
					else
						$Spoonbot::BotStatus[%TeamMate2Id] = "Engaging " @ %aiName;
					%animation = $PlayerAnim::Wave;
					BotFuncs::Animation(%TeamMateId, %animation);
				}
			}
		}
	}
}

function BotThink::DemoLOS(%aiId,%aiName,%AiPos,%aiTeam)
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;
	if (!BotFuncs::CheckAlive(%aiId))
		return;
	if (Player::getMountedItem(%aiId, $FlagSlot) != -1)   						//Cap flag if someone gives it to us...
	{
		$Spoonbot::DemoTarget[%aiId] = 0;
		$Spoonbot::MedicBusy[%aiId] = 0;
		return;
	}

	if ((BotTypes::IsDemo(%aiName) == 0) && (!$Spoonbot::HuntFlagrunner == 0))			//Roamers abort to chase flag!
	{
		$Spoonbot::DemoTarget[%aiId]=0;
		BotThink::NormalBotBehaviour(%aiName, %aiId);
		return;
	}

	if ($Spoonbot::MedicBusy[%aiId] == 0)							//If we just got here, save Location.
		$BotThink::Definitive_Attackpos[%aiId] = %AiPos;

	if(($Spoonbot::AttackerId[%aiId] >= 0) && ($Spoonbot::LastAttackerId[%aiId] != $Spoonbot::AttackerId[%aiId]))
		BotThink::UnderAttack(%aiId,%aiName,%aiTeam,$Spoonbot::AttackerId[%aiId]);

	if ($Spoonbot::MedicBusy[%aiId] == 0)							//If we just got here & are under attack, cancel chasing attacker.
	{
		AI::DirectiveRemove( %aiName, 255);						//Stop bot NOW.
		AI::DirectiveWaypoint(%aiName, $BotThink::Definitive_Attackpos[%aiId], 255);		//Waypoint to Current Location.
	}


	%xPos = getWord(%AiPos, 0);								//Make sure we ARE stuck!!!
	%yPos = getWord(%AiPos, 1);
	%zPos = getWord(%AiPos, 2);
	%LastxPos = getWord($Spoonbot::lastPosition[%aiId], 0);
	%LastyPos = getWord($Spoonbot::lastPosition[%aiId], 1);
	%LastzPos = getWord($Spoonbot::lastPosition[%aiId], 2);
	%stuck = False;
	%MinPositionDelta = 1;
	if (BotFuncs::Delta(%xPos, %LastxPos) < %MinPositionDelta)
		if (BotFuncs::Delta(%yPos, %LastyPos) < %MinPositionDelta)
			if (BotFuncs::Delta(%zPos, %LastzPos) < %MinPositionDelta)  //If the bot hasn't moved recently, it may be stuck.
				%stuck = True;
	if (%stuck == False)					// && ($Spoonbot::BotEvadeUp[%aiId] != 1) && ($Spoonbot::BotJettingHeat[%aiId] != 1))
	{
		AI::DirectiveRemove(%aiName, 255);						//Stop bot NOW.
		AI::DirectiveWaypoint(%aiName, $BotThink::Definitive_Attackpos[%aiId], 255);		//Waypoint to Original LOS Location.
		if(($Spoonbot::BotEvadeUp[%aiId] == 1) || ($Spoonbot::BotJettingHeat[%aiId] == 1))
			schedule("AI::SetUpEvade(" @ %aiId @ ");", 3);
	}

	$Spoonbot::lastPosition[%aiId] = %AiPos;							//Save current location for next Think.

	BotFuncs::PaintTarget(%aiName, $Spoonbot::DemoTarget[%aiId]);
}
