


$FlagHunter::NexusPos[Arena_Madness] = "-3.04705 -2.24603 29.5399";



$FlagHunter::NexusPos["AreciboArena"] = "1.58996 -0.5 127.409";
$FlagHunter::NexusPos["ArenaInTheSky"] = "8.66998 1.51977 161.399";
$FlagHunter::NexusPos["ArenaUnderTheHill"] = "-34.263 2.68994 -20.94";
$FlagHunter::NexusPos["Arena_Madness"] = "-3.04705 -2.24603 29.5399";
$FlagHunter::NexusPos["Batty"] = "762.819 787.159 2553.75";
$FlagHunter::NexusPos["BF-DeadCity"] = "0 0 50.3398";
$FlagHunter::NexusPos["BF-Neighbor"] = "-136.67 -270.354 306.619";
$FlagHunter::NexusPos["bm"] = "1002.19 2108.71 529.75";
$FlagHunter::NexusPos["Caves"] = "895.409 658.599 185.049";
$FlagHunter::NexusPos["Complex"] = "5.25 507.5 397.559";
$FlagHunter::NexusPos["Egyptian"] = "38.6799 327.429 272.319";
$FlagHunter::NexusPos["G5"] = "-6.58703 0.0598144 272.289";
$FlagHunter::NexusPos["Grid"] = "2.01989 231.419 239.029";
$FlagHunter::NexusPos["Library"] = "95.9699 415.699 168.569";
$FlagHunter::NexusPos["Milks_Shaft"] = "2504.77 592.099 543.709";
$FlagHunter::NexusPos["Morena"] = "6.60998 -3.42004 46.0499";
$FlagHunter::NexusPos["Ravine"] = "536.339 -633.51 305.569";
$FlagHunter::NexusPos["Temple"] = "48.5198 16.6596 248.529";
$FlagHunter::NexusPos["Walledin"] = "379.413 81.3263 159.438";
$FlagHunter::NexusPos["woot"] = "1170.81 895.389 502.759";

function test123()
{
	%true = 0;
	%false = 0;

	for(%x = 0; %x < 100; %x++)
	{
		if(fifty())
			%true++;
		else
			%false++;

	}
	//echo("True "@ (%true/100)*100);
	//echo("True\False = "@ %true@"\\"@%false);
}






//$FlagHunter::Master = false;
$FlagHunter::YardSaleNumber = 15;


   $FlagHunter::MostFlagsReturned = "";
   $FlagHunter::MostFlagsReturnCount = 0;
   $FlagHunter::MostFlagsDropped = 0;
   $FlagHunter::MostFlagsDroppedName = "";
   $FlagHunter::NexusCampingTimer = 10;
   $FlagHunter::FlagFadeTime = 150;
   $FlagHunter::CarryingNumber = 15;
   $FlagHunter::YardSaleNumber = 15;
   $FlagHunter::YardSaleTime = 30;
   $FlagHunter::GreedAmount = 15;
   $FlagHunter::HoardStartTime = 5;
   $FlagHunter::HoardEndTime = 2;
   $FlagHunter::TeamModeOn = false;
$FlagHunter::HoardMode = false;


function FlagHunter::updateTrackers(%client, %numFlags, %event)
{
   if (%event == "dropped")
   {
      %eventString = " dropped ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags;
   }
   else if (%event == "capped")
   {
      %eventString = " CAPPED ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags;
   }
   else
   {
      %eventString = " has ";
      %teamFlagNum = %numFlags;
      %enemyFlagNum = %numFlags + 1;
   }

   //Set the team prefix
   if ($FlagHunter::TeamModeOn)
   {
      %teamPrefix = "T- ";
      %enemyPrefix = "E- ";
   }
   else
   {
      %teamPrefix = "";
      %enemyPrefix = "";
   }

   //update anyone who is tracking this player
   %name = Client::getName(%client);
   %numClients = getNumClients();
   for (%i = 0; %i < %numclients; %i++)
   {
      %tracker = getClientByIndex(%i);
      if (%tracker != %client && %tracker.target == %client)
      {
         %targetPos = GameBase::getPosition(%client);
         %posX = getWord(%targetPos, 0);
         %posY = getWord(%targetPos, 1);

         //issue command to teammate trackers
         if (Client::getTeam(%tracker) == Client::getTeam(%client))
         {
            if (%teamFlagNum <= 0)
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ "no flags.", %posX, %posY);
            else if (%teamFlagNum == 1)
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ "1 flag.", %posX, %posY);
            else
               issueCommand(%tracker, %tracker, 0, %teamPrefix @ %name @ %eventString @ %teamFlagNum @ " flags!", %posX, %posY);
         }
         //issue command to enemy trackers
         else
         {
            if (%enemyFlagNum <= 0)
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ "no flags.", %posX, %posY);
            else if (%enemyFlagNum == 1)
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ "1 flag.", %posX, %posY);
            else
               issueCommand(%tracker, %tracker, 0, %enemyPrefix @ %name @ %eventString @ %enemyFlagNum @ " flags!", %posX, %posY);
         }
      }
   }
}
function fadeOutObject(%object)
{
   GameBase::startFadeOut(%object);
   schedule("deleteObject(" @ %object @ ");", 2.5, %object);
}
function remoteklye(%client, %word)
{
	%client.flagcount = %word;
	%player = client::getownedobject(%client);
	FlagHunter::onDrop(%player, %type);
}
function FlagHunter::onDrop(%player, %type)
{
   %client = Player::getClient(%player);
   //echo(client::getname(%client)@" has died, flags: "@%client.flagCount);
   if(%client.flagCount < 1)
   {
   		%client.flagCount = 1;
	}
      %numFlagsDropped = %client.flagCount;

   if (%numFlagsDropped <= 0)
      return;

   if (%numFlagsDropped > $FlagHunter::YardSaleNumber)
   {
      %numberSinglePointFlags = $FlagHunter::YardSaleNumber;
      %excess = %numFlagsDropped - $FlagHunter::YardSaleNumber;
      if (%excess % 2 == 1)
      {
         %numberSinglePointFlags++;
         %excess--;
      }
      %numberToSpawn = %numberSinglePointFlags + floor(%excess / 2);
   }
   else
   {
      %numberToSpawn = %numFlagsDropped;
      %numberSinglePointFlags = %numFlagsDropped;
   }

   for (%i = 0; %i < %numberToSpawn; %i++)
   {
      // create a flag
      %flag = newObject("", Item, FlagHunter, 1, false, false, true);
 	 	addToSet("MissionCleanup", %flag);

      if (%i < %numberSinglePointFlags)
         %flag.value = 1;
      else
         %flag.value = 2;

      %flag.carrier = -1;

      GameBase::setTeam(%flag, -1);
      GameBase::throw(%flag, %player, 10, false);

      //if the flag hasn't been picked up in 2 minutes or so, fade it out
      schedule("fadeOutObject(" @ %flag @ ");", $FlagHunter::FlagFadeTime, %flag);

      //randomize the direction a bit so the flags don't all bunch up



      %curVelocity = Item::getVelocity(%flag);
      %velX = getWord(%curVelocity, 0) + floor(getRandom() * 20) - 10;
      %velY = getWord(%curVelocity, 1) + floor(getRandom() * 20) - 10;
      %velZ = getWord(%curVelocity, 2) + floor(getRandom() * 20) - 10;
      Item::setVelocity(%flag, %velX @ " " @ %velY @ " " @ %velZ);
   }

   //remove the flag from the player
   Player::setItemCount(%client, "Flag", 0);
   %client.carryFlag = "";
   if (%client.dead)
      %client.flagCount = 0;
   else
      %client.flagCount = 1;
   Game::refreshClientScore(%client);

   //update anyone who is tracking this player
   FlagHunter::updateTrackers(%client, %numFlagsDropped, "dropped");

   //find the location and advertise a "yard sale" if enough flags were dropped
   if (%numFlagsDropped >= $FlagHunter::YardSaleNumber)
   {
	   //DeathMatch::Message($White, client::getname(%client)@" initiated a vote to: "@$curVoteTopic);
      DeathMatch::Message(1, "YARD SALE!!!~wfemale5.wtaunt4.wav");
      %beacon = newObject("", Item, Beacon, 1, false, false, true);
 	 	addToSet("MissionCleanup", %beacon);
      GameBase::setTeam(%beacon, Client::getTeam(%client));
      GameBase::throw(%beacon, %player, 10, false);
      schedule("StartYardSaleBeacon(" @ %beacon @ ");", 0.5, %beacon);
   }

   if (%numFlagsDropped - 1 > $FlagHunter::MostFlagsDropped)
   {
      $FlagHunter::MostFlagsDropped = %numFlagsDropped - 1;
      $FlagHunter::MostFlagsDroppedName = Client::getName(%client);
   }
}

function StartYardSaleBeacon(%beacon)
{
	if (! GameBase::isAtRest(%beacon))
      schedule("StartYardSaleBeacon(" @ %beacon @ ");", 0.5, %beacon);
   else
   {
      //sink the beacon 1 meter below the surface...
      %pos = GameBase::getPosition(%beacon);
      %posX = getWord(%pos, 0);
      %posY = getWord(%pos, 1);
      %posZ = getWord(%pos, 2) - 1.0;
      %newPos = %posX @ " " @ %posY @ " " @ %posZ;

      //delete the thrown beacon object
      deleteObject(%beacon);

      //create a deployed targetting one
      %targBeacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
      addToSet("MissionCleanup", %targBeacon);
   	GameBase::setTeam(%targBeacon, Client::getTeam(%client));
   	GameBase::setPosition(%targBeacon, %newPos);
   	Gamebase::setMapName(%targBeacon,"Yard Sale!");
      Beacon::onEnabled(%targBeacon);

      //schedule the beacon to fade in 30 seconds
      schedule("fadeOutObject(" @ %targBeacon @ ");", $FlagHunter::YardSaleTime, %targBeacon);
   }
}

function FlagHunter::onCollision(%this, %object)
{
   if (getObjectType(%object) != "Player")
      return;

 //  if (%this.carrier != -1)
    //  return; // spurious collision

   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %client = Player::getClient(%object);
   %clientName = Client::getName(%client);

   //delete the object and add 1 to the players flagCount
   %client.flagCount += %this.value;

   //set the state, and turn it invisble - the scheduled callback for this flag will delete it
   deleteObject(%this);

   %numFlags = %client.flagCount - 1;

   //only send messages to everyone if the number is odd - to cut down on spam...
   %currentTime = getSimTime();
   if ((%currentTime - %client.lastMessageTime < 16.0) && ( floor(%numFlags / 2.0) == (%numFlags / 2.0)))
   {
      %sendMsg = false;
   }
   else
   {
      %sendMsg = true;
      %client.lastMessageTime = %currentTime;
   }


   //send the message to the player
   if (%numFlags == 1)
      Client::sendMessage(%client, 0, "You now have 1 flag.~wflag1.wav");
   else
      Client::sendMessage(%client, 0, "You now have " @ %numFlags @ " flags.~wflag1.wav");

   if ($FlagHunter::TeamModeOn)
   {
      if (%sendMsg)
      {
         %numClients = getNumClients();
         for (%i = 0; %i < %numClients; %i++)
         {
            %msgClient = getClientByIndex(%i);
            if (%msgClient != %client)
            {
               //send msg to teammates
               if (Client::getTeam(%msgClient) == Client::getTeam(%client))
               {
                  if (%numFlags == 1)
                     Client::sendMessage(%msgClient, 0, "Teammate " @ %clientName @ " now has 1 flag.~wflag1.wav");
                  else
                     Client::sendMessage(%msgClient, 0, "Teammate " @ %clientName @ " now has " @ %numFlags @ " flags.~wflag1.wav");
               }

               //send msg to enemies
               else
               {
                  Client::sendMessage(%msgClient, 0, "Enemy " @ %clientName @ " now has " @ %numFlags + 1 @ " flags.~wflag1.wav");
               }
            }
         }
      }
   }
   else if (%sendMsg)
   {
      if (%numFlags == 1)
        DeathMatch::MessageExcept(%client, 0, %clientName @ " now has 1 flag.~wflag1.wav");
        // DeathMatch::MessageExcept(%client, $White, client::getname(%client)@" initiated a vote to: "@$curVoteTopic);
      else
         DeathMatch::MessageExcept(%client, 0, %clientName @ " now has " @ %numFlags @ " flags!~wflag1.wav");
   }

   //see if a record is about to be broken
   if (! $FlagHunter::TeamModeOn && (getNumClients() >= 4) && $impossible = "possible")
   {
      if ((%numFlags > $FlagHunter::MostFlagsEverCount[$missionName]) && (%currentTime - %client.recordMessageTime > 2.0))
      {
         %client.recordMessageTime = %currentTime;
         Client::sendMessage(%client, 1, "You have enough flags to set a new record!~wmine_act.wav");
         if (%sendMsg)
            DeathMatch::MessageExcept(%client, 1, %clientName @ " has enough flags to set a new record!~wmine_act.wav");
      }
   }

   //make sure he's still carrying a flag
   if (%client.flagCount >= $FlagHunter::CarryingNumber && Player::getItemCount(%client, Flag) < 2)
   {
      Player::setItemCount(%client, Flag, 1);
      Player::mountItem(%client, Flag, $FlagSlot, 1);
   }
   Game::refreshClientScore(%client);

   //update anyone who is tracking this player
   FlagHunter::updateTrackers(%client, %client.flagCount - 1, "has");
}




function NexusTrigger::onEnter(%this, %object)
{
	//echo(%this@" "@%object);
	if (getObjectType(%object) != "Player")
		return;

	%client = Player::getClient(%object);


   if (%this.nexus)
   {
	   //echo("NexusTrigger "@%client @" "@client::getname(%client));
	   %client.In = true;
      %totalFlags = %client.flagCount - 1;
      if (%totalFlags <= 0)
         return;

      //if "greed mode" is on, can't cap less than greed amount...
      if ($FlagHunter::GreedMode && (%totalFlags < $FlagHunter::GreedAmount))
      {
         Client::sendMessage(%client, 1, "Greed mode is ON!  You must have " @ $FlagHunter::GreedAmount @ " flags before you can return them.~wmine_act.wav");
         return;
      }

      //if "greed mode" is on, can't cap less than greed amount...
      %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();

 if ($FlagHunter::HoardMode)
      {
		  %maptl = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();


		  %tl = 300-(getSimTime() - $FlagHunter::simtime);

		  if(%tl > %maptl)
		  	%tl = %maptl-59;

		  %mins = time::getminutes(%tl);
		  %secs = time::getseconds(%tl);
		  if(%secs < 0)
		  	%secs = 0;
		  if(%mins > 0)
		  	%mystring = "Hoard mode is in effect!  You must wait "@%mins@" minutes and "@%secs@" seconds before you can return your flags.~wmine_act.wav";
		  else
		  	%mystring = "Hoard mode is in effect!  You must wait "@%secs@" seconds before you can return your flags.~wmine_act.wav";

		  Client::sendMessage(%client, 1, %mystring);

		 // echo("FH TIME: "@$FlagHunter::simtime@" Current time: "@getSimTime());
		 // %mytimestring = 300 - time::getseconds((getSimTime() - $FlagHunter::simtime));
		 // echo("metime"@%mytimestring);

         return;
      }
      //return the flags he's captured, and score them (note, he's always carrying his own - don't score it)
      %clientName = Client::getName(%client);
      %totalScore = 0;
      for (%i = 1; %i < %client.flagCount; %i++)
      {
         %totalScore += %i;
      }
     // echo("totalscore "@%totalScore);

      //in team hunters, the score goes to the team
      if ($FlagHunter::TeamModeOn)
         $teamScore[Client::getTeam(%client)] += %totalScore;
      else
         %client.score += %totalScore;

      %client.flagCount = 1;
      //take the flag off the players back
      Player::setItemCount(%client, Flag, 0);

      if (! $FlagHunter::TeamModeOn)
      {
         if (%totalFlags > $FlagHunter::MostFlagsReturnCount)
         {
            $FlagHunter::MostFlagsReturnCount = %totalFlags;
            $FlagHunter::MostFlagsReturned = %clientName;
         }

         %newRecord = false;
         if ((%totalFlags > $FlagHunter::MostFlagsEverCount[$missionName]) && (getNumClients() >= 4) && $IMPOSSIBLE == "POSSIBLE")
         {
            $FlagHunter::MostFlagsEverCount[$missionName] = %totalFlags;
            $FlagHunter::MostFlagsEver[$missionName] = %clientName;
            %newRecord = true;

            //save it to a file
            export("$FlagHunter::MostFlagsEver*", "config\\HunterRecords.cs", False);
         }
      }

      Game::refreshClientScore(%client);

      //send the message
      if (%totalFlags >= 5 && (! %newRecord))
      {
         %color = 1;
         %sound = "!~wflagreturn.wav";
      }
      else
      {
         %color = 0;
         %sound = "!";
      }

      //send the message to the client
      Client::sendMessage(%client, %color, "You returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);

      if ($FlagHunter::TeamModeOn)
      {
         for (%i = 0; %i < getNumClients(); %i++)
         {
            %msgClient = getClientByIndex(%i);
            if (%msgClient != %client)
            {
               //send msg to teammates
               if (Client::getTeam(%msgClient) == Client::getTeam(%client))
               {
                  if (%totalFlags == 1)
                     Client::sendMessage(%msgClient, %color, "Teammate " @ %clientName @ " has returned 1 flag for a score of 1" @ %sound);
                  else
                     Client::sendMessage(%msgClient, %color, "Teammate " @ %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
               }

               //send msg to enemies
               else
               {
                  if (%totalFlags == 1)
                     Client::sendMessage(%msgClient, %color, "Enemy " @ %clientName @ " has returned 1 flag for a score of 1" @ %sound);
                  else
                     Client::sendMessage(%msgClient, %color, "Enemy " @ %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);
               }
            }
         }
      }
      else
      {
         DeathMatch::MessageExcept(%client, %color, %clientName @ " has returned " @ %totalFlags @ " flags for a score of " @ %totalScore @ %sound);

        // if (%newRecord)
           // MessageAll(1, "New record of " @ $FlagHunter::MostFlagsEverCount[$missionName] @ " set by " @ $FlagHunter::MostFlagsEver[$missionName] @ "!~wflagcapture.wav");
      }

      //update anyone who is tracking this player
      FlagHunter::updateTrackers(%client, %totalFlags, "capped");
   }
   else
   {
      //set the flag
      //%client.inNexusAreaTime = floor(getSimTime() * 100);

      //schedule the call to see if he's still there
     // schedule("NexusCampingDamage(" @ %object @ ", " @ %client.inNexusAreaTime @ ", true);", $FlagHunter::NexusCampingTimer);
   }
}
function DeathMatch::MessageExcept(%client, %color, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(%cl.DM && %cl != %client)
	   {
		   client::sendmessage(%cl, %color, %message);
	   }
   }
}
// client cannot camp near the flag
function NexusTrigger::onLeave(%this, %object)
{
	return;

echo("leaving "@%this @" "@%object @" "@ %this.nexus);
	if (getObjectType(%object) != "Player" )
		return;

   if (%object.nexus)
      return;

	%distance = Vector::getDistance(gamebase::getposition(%object), gamebase::getposition(%this));
	echo("dist "@%distance);
	if(%distance < 5)
	{
		schedule("NexusTrigger::onLeave("@%this@", "@%object@");", 1.0);
		return;
	}
	%client = Player::getClient(%object);

   //reset
  // echo(left);
   %client.IsIn = false;
   %client.inNexusAreaTime = -1;
}

function NexusCampingDamage(%player, %timeStamp, %giveWarning)
{
	//echo(nexuscamp);
	if (getObjectType(%player) != "Player")
		return;

	%client = Player::getClient(%player);
   if (%client <= 0 || Player::isDead(%client))
      return;

   //make sure this schedule callback matches the original
   if (%client.inNexusAreaTime != %timeStamp)
      return;

   //give damage if the person is still camping, and has been there for 8 seconds or more
   if (%giveWarning)
   {
      Client::sendMessage(%client, 1, "No camping near the Nexus! ~wLeftMissionArea.wav");
      schedule("NexusCampingDamage(" @ %player @ ", " @ %timeStamp @ ", false);", $FlagHunter::NexusCampingTimer / 2);
   }
   else
   {
      Player::setDamageFlash(%client, 0.1);
      GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) + 0.05);
      schedule("NexusCampingDamage(" @ %player @ ", " @ %timeStamp @ ", false);", 1);
   }
}