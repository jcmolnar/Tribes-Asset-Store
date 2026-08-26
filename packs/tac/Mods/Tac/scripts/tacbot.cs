//====================================================================================
//
//									Server Loading Script       			Wizard_TPG
//
//
//	This script is designed to simulate cpu usage on TAC tribes servers for the
//		testing of mods.  It creates bots that spawn and run around until they fall
//		off the base and die....and repeat.
//
//	USAGE:
//			Run this script from your server console  	-	exec("tacbot.cs");
//			Add One Bot to BE							-	AI::AddBot();
//			Add Two Bots to BE							-	AI::AddBot(2);
//			Add Two Bots to DS							-	AI::AddBot(2,1);
//			Remove last added bot						-	AI::RemoveBot();
//			Get Bot Status								-	AI::BotStatus();
//
//====================================================================================

function AI::AddBot(%num, %team)
{
	if(%num<=0 || %num == "")
		%num = 1;

	if(%team == "" || %team >= 2)
		%team = 0;

	%botcount = $AI::BotNumber;
	for(%i=1;%i<=%num;%i++)
	{
		%botcount++;
		%ainame = "Bot_" @ %botcount;
		createAI(%ainame, "MissionGroup/Teams/team" @ %team @ "/DropPoints/Random", larmor );

   		%aiId = BotFuncs::GetId(%ainame);
   		$DoNotRespawnAI[%aiId] = false;
   		$AI::BotTeam[%aiId] = %team;

   		AI::DirectiveWaypoint( %ainame, "0 0 0", 1 );
   		echo("--- ",%ainame," created ---");
	}
	$AI::BotNumber = %botcount;
	echo("*** ",%num," bots added giving a total of ",%botcount," bots ***");
}

function AI::BotStatus()
{
	%botcount = $AI::BotNumber;
	echo("*** There is currently ",%botcount," bot/s active ***");
}


function AI::RemoveBot(%attempt)
{
	%botcount = $AI::BotNumber;
	if(%botcount <= 0)
	{
		echo("*** There are no active bots ***");
		return;
	}

	if(%attempt >= 5)
	{
		echo("*** Error: Bot not removed after 10 attempts ***");
		return;
	}

	%botcount = $AI::BotNumber;

	%botname = "Bot_" @ %botcount;
	%aiId = BotFuncs::GetId(%botname);
	if (%aiId==0 || %aiId==false || %aiId=="")
	{
		%attempt++;
		schedule("AI::RemoveBot("@%attempt@");",1);
	}
	else
	{
  		$DoNotRespawnAI[%aiId] = true;
  		Player::kill(%aiId);
  		echo("*** ",%botname," removed ***");
		%botcount--;
		$AI::BotNumber = %botcount;
		echo("*** 1 bot removed leaving a total of ",%botcount," bots ***");
	}
}


function AI::onDroneKilled(%aiName)
{
  	if( ! $SinglePlayer )
   	{

    	%aiId = BotFuncs::GetId(%aiName);
    	%team = $AI::BotTeam[%aiId];
		if (!$DoNotRespawnAI[%aiId])
		{
			//createAI(%ainame, "MissionGroup/Teams/team" @ %team @ "/DropPoints/Random", larmor );

		   	%spawnMarker = AI::pickRandomSpawn(%team);
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
			%voice = "male1";

			schedule("AI:SecondSpawnAttempt("@%ainame@", \""@%aiSpawnPos@"\", \""@%rPos@"\");",7);

		}
		$DoNotRespawnAI[%aiId] = false;
   	}
   	else
   	{
    	// just in case:
    	dbecho( 2, "Non training callback called from Training" );
   	}

}

function AI:SecondSpawnAttempt(%ainame,%aiSpawnPos,%rPos)
{
	if(Ai::spawn(%ainame, larmor, %aiSpawnPos, %rPos) == "false")
		schedule("AI:SecondSpawnAttempt("@%ainame@", \""@%aiSpawnPos@"\", \""@%rPos@"\");",5);
	else
	{
		AI::DirectiveWaypoint( %ainame, "0 0 0", 1 );
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

function BotFuncs::GetId(%aiName)
{
	if (%aiName == "")
	{
		return 0;
	}
	return ai::GetId(%aiName);
}

echo("*************************************");
echo("*** TACBot.cs Loaded Successfully ***");
echo("*** Type AI::AddBot(); to add bot ***");
echo("*************************************");
