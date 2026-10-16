// Bot Think Function by Wicked69 (Paul@Lathope.demon.co.uk) Started 6/11/1999.





//Main Bot think function calls itself recursively each second

function BotThink::Think(%aiId,%requeue)
{
	if ($Spoonbot::DebugMode)
		echo ("CALL BotThink::Think("@ %aiId @ ", " @ %requeue @ ");");


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


//if ($Spoonbot::RidingWith[%aiId] != 0)	//If bot rides in a vehicle, skip all of the bot's thinking.
//	{
//	if (%requeue == True)
//		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
//	return;
//	}

if (BotTypes::isCMD(%aiName) == 1)
	return;


// Tidy Attacker List

	BotFuncs::TidyAttackerList(%aiId);


	if ($Spoonbot::DebugMode)
		echo("STATUS BotThink::Think = Bot alive check passed for ID " @ %aiId @ " Name " @ %aiName);

// Generic variables

	%aiName = Client::getName(%aiId);
	%aiTeam = Client::getTeam(%aiId);
	%AiPos = GameBase::getPosition(%aiId);

	if(%aiTeam == 0)
		%EnemyTeam = 1;
	else
		%EnemyTeam = 0;




if ($Spoonbot::MortarBusy[%aiId] == 1 )
{
  schedule("BotThink::Think(" @ %aiId @ ", True);", 5);
  return;
}




//
//
// Start if main AI action 'IF' sequence
//
//


	//if we have a flag do something with it
	//WILL cap if its not inside and they can access it
	//if dont cap within 60 seconds, die to let humans have it
	if (Player::getMountedItem(%aiId, $FlagSlot) != -1)   
	{
	$increaseflag[%aiId] = $increaseflag[%aiId] + 1;
	if ($increaseflag[%aiId] == 80)
	{
	$increaseflag[%aiId] = 0;
	Player::kill(%aiId);
	}
	if (!BotFuncs::CheckAlive(%aiId))
	{
	$ThinkingNow[%aiId] = 0;
	return;
	}
	%aiName = Client::getName(%aiId);
	%team = GameBase::getTeam(%aiId);
	%flaghere = BotFuncs::GetFlagId(%team);
	%newbugs = GameBase::GetPosition(%flaghere);

//	AI::DirectiveWaypoint(%aiName, %newbugs,  255);  // Replaced with Tree functions. WORKS!!!

//	BotTree::Getmetopos(%aiid,%newbugs, false);
	$BotThink::Definitive_Attackpoint[%aiId] = %flaghere;
	$BotThink::Definitive_Attackpos[%aiId] = %newbugs;
	$BotThink::ForcedOfftrack[%aiId] = True;
	$BotThink::LastPoint[%aiId] = false;

	$ThinkingNow[%aiId] = 0;
	// Requeue Think
//	if (%requeue == True)
//	schedule("BotThink::Think(" @ %aiId @ ", True);", 	$Spoonbot::ThinkingInterval);
//	return;
	} 






	// Check to see if AI is healthy. If not get help.

	else if (BotFuncs::IsHealthy(%aiId) == False) // Not Healthy. Return to Base (Or Find a Medic?)
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

//				AI::DirectiveWaypoint( %aiName, $BotThink::BotHome[%aiId], 2, 0 );

//	BotTree::Getmetopos(%aiid,$BotThink::BotHome[%aiId], false);
	$BotThink::Definitive_Attackpos[%aiId] = $BotThink::BotHome[%aiId];
	$BotThink::ForcedOfftrack[%aiId] = True;
	$BotThink::LastPoint[%aiId] = false;

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

		$BotThink::ForcedOfftrack[%aiId] = True;

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
	}






//Medic/Sniper stuff

	else if(BotTypes::IsMedic(%aiName) == 1) // If medic then try to find item to repair.
	{

	if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ "," @ %aiId @ " is medic");
	if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " task = " @ $Spoonbot::MedicTask[%aiId]);

			if($Spoonbot::MedicTask[%aiId] == -1)  // no target to repair, get one!
			{

 	if ($Spoonbot::DebugMode)
				dbecho(1,%ainame @ " finding task " @ %Task);

				%Task = BotFuncs::GetRepairTask(%aiName);

				if(%Task != -1)
				{
					%object = %Task;

					// %object = $Spoonbot::RepairTaskObject[%task];
					%objectpos = GameBase::getPosition(%object);

 	if ($Spoonbot::DebugMode)
					dbecho(1,"Target pos = " @ %objectpos);

//					BotTree::Getmetopos(%aiid,%objectpos, false);

					$Spoonbot::MedicTask[%aiId] = %task;

					$BotThink::Definitive_Attackpoint[%aiId] = %object;
					$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
					$BotThink::ForcedOfftrack[%aiId] = True;
					$BotThink::LastPoint[%aiId] = False;
				}
			}
			
 	if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " task = " @ $Spoonbot::MedicTask[%aiId]);

			
			if($Spoonbot::MedicTask[%aiId] != -1) // Have a target ? Close enough to repair ? repaired ?
			{

 	if ($Spoonbot::DebugMode)
				dbecho(1,%ainame @ " found target");

				%object = $Spoonbot::MedicTask[%aiId];
				%objectpos = GameBase::getPosition(%object);

				%aiPos = GameBase::getPosition(%aiId);

				%curDistance = Vector::getDistance(GameBase::getPosition($BotThink::Definitive_Attackpoint[%aiId]),%aipos);  //Check if AI is in range for repairs
		
 	if ($Spoonbot::DebugMode)
				dbecho(1,"distance = " @ %curdistance);
			
				if (%curDistance < 100)
				{
					if (GameBase::getDamageLevel(%object) == 0.0)
					{
						AI::DirectiveRemove(%aiName, 2048);
						%rate = 0;
						GameBase::setAutoRepairRate(%object,%rate);
						$Spoonbot::MedicTask[%aiId] = -1;
						$Spoonbot::MedicBusy[%aiId] = 0;

						BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);

						$BotThink::Definitive_Attackpoint[%aiId] = "";
						$BotThink::Definitive_Attackpos[%aiId] = "";
						$BotThink::ForcedOfftrack[%aiId] = True;

						if ($Spoonbot::DebugMode)
							echo ("STATUS BotFuncs::RepairTask = Repair Done");
						%Task = BotFuncs::GetRepairTask(%aiName);
		 	if ($Spoonbot::DebugMode)
						dbecho(1,%ainame @ " finding another task " @ %Task);

						if(%Task != -1)
						{
							%object = %Task;

							// %object = $Spoonbot::RepairTaskObject[%task];
							%objectpos = GameBase::getPosition(%object);

		 	if ($Spoonbot::DebugMode)
							dbecho(1,"Target pos = " @ %objectpos);

//							BotTree::Getmetopos(%aiid,%objectpos, false);

							$Spoonbot::MedicTask[%aiId] = %task;
		
							$BotThink::Definitive_Attackpoint[%aiId] = %object;
							$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
							$BotThink::ForcedOfftrack[%aiId] = True;
							$BotThink::LastPoint[%aiId] = False;
						}








						
					}
					else
					{
						if ($Spoonbot::DebugMode)
							dbecho (1, "STATUS BotFuncs::RepairTask = Repairing...");
						if ($BotThink::LastPoint[%aiId] == False)
							AI::DirectiveWaypoint(%aiName, GameBase::GetPosition(%object), 2048);
						%repairRate = 0.1;
						%damage = GameBase::getDamageLevel(%object);
						$Spoonbot::MedicBusy[%aiId] = 1;
						
						if ($Spoonbot::DebugMode)
							dbecho(1, "STATUS BotFuncs::RepairTask = Object Damage = " @ %damage);

						%difference = %damage - %repairRate;

						if (%difference < 0.0)	//If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
						{
							%repairRate = %damage;
							AI::DirectiveRemove(%aiName, 2048);
						}

						%newDamage = %damage - %repairRate;

						GameBase::setDamageLevel(%object, %newDamage);
					}
				}
			}

			if(($Spoonbot::MedicTask[%aiId] == -1) || ($BotThink::Definitive_Attackpoint[%aiId])) 
			{					// no repair task, do normal attack/defend - on your bike for now!
 	if ($Spoonbot::DebugMode)
				dbecho(1,%ainame @ " no repair target");
 	if ($Spoonbot::DebugMode)
				dbecho(1,%ainame @ " attack due to no repair target");

				BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);
			}

	}

	//Defend and Chase-Return the flag
	else if(BotTypes::IsGuard(%aiName) == 1)
	{
		%aiId = BotFuncs::GetId(%aiName);
		if (%aiId==0)
			return;
		if (!BotFuncs::CheckAlive(%aiId))
			return;
		//now sticks to flag and hunts it down if flag is gone
		%imtheone = 0;
		%aiName = Client::getName(%aiId);
		%team = GameBase::getTeam(%aiId);
		%flaghere = BotFuncs::GetFlagId(%team);
		%newbugs = GameBase::GetPosition(%flaghere);
		//Jump up and forward every now and then just in case
		%flyaway = floor(getRandom() * 10); 
		if (%flyaway == 0)
		{
			if ($Spoonbot::BotEvadeUp[%aiId] != 1)
		 	AI::EvadeUp(%aiId);
		}
		//Enumerate all clients and see if an enemy has flag
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%clteam = Client::getTeam(%cl);
			//Client is not same team as bot
			if(%clteam != %team)
			{
			   %player = Client::getOwnedObject(%cl);
			   if (!Player::isDead(%player))
			   {
				//And enemy has a flag
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)
				%imtheone = %cl;
			   }
			}
		}
		//If so then follow that enemy
		if (%imtheone != 0)
		{
			//get position of the one with flag
			%newguy = GameBase::GetPosition(%imtheone);
			AI::DirectiveWaypoint(%aiName, %newguy,  255);
			// Requeue Think
		//	if (%requeue == True)
		//	schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		//	return;		
		}
		//If not then go right to the flag
		else
		{
		//	AI::DirectiveWaypoint(%aiName, %newbugs,  255); 
//			BotTree::Getmetopos(%aiid,%newbugs, false);
			$BotThink::Definitive_Attackpoint[%aiId] = %flaghere;
			$BotThink::Definitive_Attackpos[%aiId] = %newbugs;
			$BotThink::ForcedOfftrack[%aiId] = True;
			$BotThink::LastPoint[%aiId] = false;
			// Requeue Think
			//	if (%requeue == True)
			//	schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
			//	return;
		}
	}



	//Only go for enemy flag or escort anyone who has it
	else if(BotTypes::IsMiner(%aiName) == 1)
	{
		%aiId = BotFuncs::GetId(%aiName);
		    if (%aiId==0)
		    return;
		if (!BotFuncs::CheckAlive(%aiId))
		    return;
		%imtheone = 0;
		%aiName = Client::getName(%aiId);
		%team = GameBase::getTeam(%aiId);
		if (%team == 1)
		  %enemyTeam = 0;
		else
		  %enemyTeam = 1;
		%flaghere = BotFuncs::GetFlagId(%enemyTeam);
		%newbugs = GameBase::GetPosition(%flaghere);
		%flyaway = floor(getRandom() * 10); 
		if (%flyaway == 0)
		{
			if ($Spoonbot::BotEvadeUp[%aiId] != 1)
		 		AI::EvadeUp(%aiId);
		}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%clteam = Client::getTeam(%cl);
			if(%clteam == %team)
			{
			   %player = Client::getOwnedObject(%cl);
			   if (!Player::isDead(%player))
			   {
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)
				{
					%imtheone = %cl;
				}
			   }
			}
		}
		if (%imtheone != 0)
		{
			%newguy = GameBase::GetPosition(%imtheone);
			AI::DirectiveWaypoint(%aiName, %newguy,  255); 
		//	if (%requeue == True)
		//	schedule("BotThink::Think(" @ %aiId @ ", True);", 	$Spoonbot::ThinkingInterval);
		//	return;		
		}
		else
		{
		//	AI::DirectiveWaypoint(%aiName, %newbugs,  255); 
//			BotTree::Getmetopos(%aiId,%newbugs, false);
			$BotThink::Definitive_Attackpoint[%aiId] = %flaghere;
			$BotThink::Definitive_Attackpos[%aiId] = %newbugs;
			$BotThink::ForcedOfftrack[%aiId] = True;
			$BotThink::LastPoint[%aiId] = false;

		//	if (%requeue == True)
		//	schedule("BotThink::Think(" @ %aiId @ ", True);", 	$Spoonbot::ThinkingInterval);
		//	return;
		}
	}



	else if(BotTypes::IsPainter(%aiName) == 1) // If painter then paint enemy installations.
	{
 	if ($Spoonbot::DebugMode)
		dbecho(1, "Painter code running");
		%aiTeam = Client::getTeam(%aiId);
		if(%aiTeam == 0)
		  %EnemyTeam = 1;
		else
		  %EnemyTeam = 0;
		%Target = -1;
		%AttackDefend=%EnemyTeam;

	if ($Spoonbot::PainterTarget[%aiId]==0)
	{
			%Target = BotFuncs::GetGunId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Guns";

		if (%Target==-1)
		{
			%Target = BotFuncs::GetVehId(%AttackDefend);
 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Sensors";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetSensorId(%AttackDefend);
 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Sensors";
		}
		if (%Target==-1)
			%Target=0;

		$Spoonbot::PainterTarget[%aiId]=%Target;
		if (%Target!=0)
			BotFuncs::PaintTarget(%aiName, %Target);
	}

		if ($Spoonbot::PainterTarget[%aiId]!=0)
		{
			AI::SetVar(%aiName, triggerPct, 1000 );
			BotFuncs::PaintTarget(%aiName, $Spoonbot::PainterTarget[%aiId]);
			// Requeue Think
//			if ($Spoonbot::DebugMode)
//			 echo ("STATUS BotThink::Think = Requeue: " @ %aiId @ ", True");
//			if (%requeue == True)
//			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
//			return;
		}
	}






	else if(BotTypes::IsDemo(%aiName) == 1) // DemoBot uses same stuff as Painter bot
	{
 	if ($Spoonbot::DebugMode)
		dbecho(1, "Demo code running");
 	if ($Spoonbot::DebugMode)
		dbecho(1, "Demo ForcedOffTrack is " @ $BotThink::ForcedOfftrack[%aiId]);


		%aiTeam = Client::getTeam(%aiId);
		if(%aiTeam == 0)
		  %E = 1;
		else
		  %E = 0;
		%enemyteam=%E;
		%Target = -1;
		%AttackDefend=%EnemyTeam;

	if ($Spoonbot::Target[%aiId]!=0)
	{
		%targetTeam=GameBase::getTeam($Spoonbot::Target[%aiId]);
		if (%targetTeam==%aiTeam)
			$Spoonbot::Target[%aiId]=0;



	}


	if ($Spoonbot::Target[%aiId]==0)
	{

			%Target = BotFuncs::GetGenId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Generators";

		if (%Target==-1)
		{
			%Target = BotFuncs::GetComId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Command Stations";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetInvId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Inventory Points";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetGunId(%AttackDefend);
		 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Guns";
		}

		if (%Target==-1)
		{
			%Target = BotFuncs::GetVehId(%AttackDefend);
 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Sensors";
		}
		if (%Target==-1)
		{
			%Target = BotFuncs::GetSensorId(%AttackDefend);
 	if ($Spoonbot::DebugMode)
			dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
			if (GameBase::getDamageLevel(%Target) >= 0.7) //Is it already destroyed?
				%Target = -1;
			%TargetType = "Sensors";
		}
		if (%Target==-1)
			%Target=0;

		$Spoonbot::Target[%aiId]=%Target;
		if (%Target!=0)
			BotFuncs::AttackObject(%aiName, %Target);

			%objectpos = GameBase::getPosition(%Target);       //ENABLE ONCE TREECODE FULLY FUNCTIONAL
//			BotTree::Getmetopos(%aiid,%objectpos, false);
			$BotThink::Definitive_Attackpoint[%aiId] = %Target;
			$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
			$BotThink::ForcedOfftrack[%aiId] = true;
			$BotThink::LastPoint[%aiId] = False;
	
	}

//		if ($Spoonbot::Target[%aiId]!=0)
//		{
//			BotFuncs::AttackObject(%aiName, $Spoonbot::Target[%aiId]);
//			// Requeue Think
//			if ($Spoonbot::DebugMode)
//			 echo ("STATUS BotThink::Think = Requeue: " @ %aiId @ ", True");
//			if (%requeue == True)
//			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
//			return;
//		}
}

	else if(BotTypes::IsSniper(%aiName) == 1) // If sniper then try to find a sniper point.
	{

		AI::SetVar(%aiName, triggerPct, 0.005 );
	 	if ($Spoonbot::DebugMode)
			dbecho(1,"Sniper attack for " @ %ainame);
	 	if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " attack due to sniper");
//		BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);
		BotThink::NormalBotBehaviour(%aiName, %aiId);

	}
	else
	{
		BotThink::NormalBotBehaviour(%aiName, %aiId);
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
							{
							%Target = BotFuncs::GetFlagId(%AttackDefend); //If so, go for the flag.
							%LastPoint = True;
							%TargetType = "Flags";
							}

						%TargetType = "Vehicle Pads";
					}
					else if (%mod == 2) // Sensor Type Targets
					{
						%Target = BotFuncs::GetSensorId(%AttackDefend);

						//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
						if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
							%Target = -1;

						//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));
						if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
							%Target = -1;

						%TargetType = "Sensors";
					}
					else if (%mod == 3) // Gun Type Targets
					{
						%Target = BotFuncs::GetGunId(%AttackDefend);

						//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
						if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
							%Target = -1;

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
		
					%Distance = Vector::getDistance(
								$BotTree::Treepoint_Location[BotTree::FindNearestTreebyId(%Target)],
								GameBase::getPosition(%Target));

				//	if ((%Distance > 10) || (%Distance == 0)) // Too far away, needs tuning. - Wicked69
				//	{
				//		%Target = -1;
				//		%TargetType = "Error, Object Deselected";
				//	}

					if(%Target == "")
						%Target = -1;
				}

				//dbecho(1,%aiid @ " Target = " @ %Target );				

				if(%Target != -1)
				{
					%AttackPos = GameBase::getPosition(%Target);
					%AttackPoint = %Target;

					if(%AttackDefend == %enemyteam)
					{
						%Style = "Attacking Enemy";
						$Spoonbot::BotStatus[%aiId] = "Attacking enemy " @ %TargetType; // This is for the ButHud
					}
					else
					{
						%Style = "Defending team";
						$Spoonbot::BotStatus[%aiId] = "Defending team " @ %TargetType; // This is for the ButHud
					}
				
					//BotFuncs::TeamMessage(%aiteam,%AiName @ ": " @ %Style @ " " @ %TargetType );
					//This annoyed me.

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
//				BotTree::GetMeToPos(%aiId, %AttackPos, %LastPoint);

				$BotThink::Definitive_Attackpoint[%aiId] = %AttackPoint;
				$BotThink::Definitive_Attackpos[%aiId] = %AttackPos;
				$BotThink::ForcedOfftrack[%aiId] = true;
				$BotThink::LastPoint[%aiId] = %LastPoint;
			}
		}

}




function BotThink::NormalBotBehaviour(%aiName, %aiId)
{

if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think = Roaming code running...");


if ($Spoonbot::Target[%aiId]!=0)
{
	if (!BotFuncs::CheckForLOS(%aiId, $Spoonbot::Target)) 
	{
		AI::DirectiveFollow(%aiId, $Spoonbot::Target, 255);
		schedule("AI::DirectiveRemove(" @ %aiId @ ", 255);", 3);

	}
}



if ($Spoonbot::Target[%aiId]!=0)
	if (BotFuncs::CheckAlive($Spoonbot::Target))
		return;

		%attacking = False;
		if ($Spoonbot::HuntFlagrunner == 0)      //Check if in Normal mode or if bots are chasing a flagrunner
		{

		%mode = floor(getRandom() * 3);      //There are two modes of operation: 1) Attack random enemy and 2) attack/defend objects
if ($Spoonbot::DebugMode)
 echo ("STATUS BotThink::Think MODE = " @ %mode);

		  if (%mode == 0)
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
							BotFuncs::AddAttacker(%cl,%aiName,10,4);
							BotFuncs::AddAttacker(%aiName,%cl,10,4);
							$Spoonbot::Target[%aiId]=%cl;
							$Spoonbot::BotStatus[%aiId] = "Attacking";
							if ($Spoonbot::DebugMode)
							  echo ("STATUS BotThink::Think = " @ %aiName @ " has decided to attack " @ %enemyName);
						    	%attacking = True;
						}
					}
				}
			}
		  }
		  else if (%mode >= 1) //mode 1 and 2 mean attack/defend base equipment
		  {

	if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " attack due to roaming atackdefend");

			BotThink::NormalAttackDefend(%aiId, %aiName, %aiTeam);

		  }  //End of mode 1 and 2



		}
			//end of roaming part, now comes the flagrunner-chasing part.
			//----------All this stuff is now inside BotFuncs.cs------------
		else
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
					BotFuncs::AddAttacker(%cl,%aiName,10,4);
					BotFuncs::AddAttacker(%aiName,%cl,10,4);
					$Spoonbot::Target[%aiId]=%cl;
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
					BotFuncs::AddAttacker(%cl,%aiName,10,4);
					BotFuncs::AddAttacker(%aiName,%cl,10,4);   //The procedure is the same, except the friendly bot won't fire on the flagrunner
					$Spoonbot::Target[%aiId]=%cl;
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