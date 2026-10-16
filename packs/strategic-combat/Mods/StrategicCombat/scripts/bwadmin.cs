// - BW Admin Mod -
$bwadmin::version = "v5.01";
$bwadmin:supportversion = "5.0";
$bwadmin::tribesVersion = "v1.11";

// ===================Default Settings===================

$bwadmin::league = "League";
$bwadmin::allowCustomSkins = "false";
$bwadmin::allowCustomSkinsLeague = "true";
$bwadmin::controlledTourneyMode = "false";
$bwadmin::DisableTourneyMode = "false";  		//Completely removes base tourney mode if enabled
$bwadmin::matchTimeLimit = 20;
$bwadmin::teamDamageScale = 1;
$bwadmin::teamScoreLimit = "";					//"" for default map score limit
$bwadmin::noLlamaSwap = "";						//"true" to stop swapping to bigger team
$bwadmin::reportScores = "";					//"true" to report scores to observers
$bwadmin::messageLog = "";						//"true" to enable advanced console logging for stats progs
$bwadmin::adminlog = 0;							//0 disabled, 1 console, 2 seperate log, 3 both
$bwadmin::adminlogip = "false";					//true to display ip address in logs (makes bigger logs)
$bwadmin::intelliKick = "";						//No of TKs to ignore...suggest value 2
$bwadmin::AutoAntiTK = "false";					//"true" to enable
$bwadmin::TKFrequency = 180;
$bwadmin::ReverseDamageTK = 3;
$bwadmin::PurgatoryTK = 4;
$bwadmin::KickTK = 0;
$bwadmin::PunishmentTime = 300;
$bwadmin::KickBanTime = 600;  					//10 minutes
$bwadmin::FullBanTime = 86400; 					//one day
$bwadmin::KeepSmurfLog = "false";				//"true" enable smurf hunter
$bwadmin::AdminSmurfApp = "false";				//"true enable ref admins to view aliases
$bwadmin::overflowPassword = "";
$bwadmin::overflowSlots = "";					//Number of overflows slots
$bwadmin::autoNBROn = 0;						//Number of players on server on which to auto enable "no base rape" mode
$bwadmin::autoNBROff = 0;						//Number of players on server on which to auto disable "no base rape" mode
$bwadmin::autoMissionSkipVote = "false";		//"true" to enable auto mission skip vote
$bwadmin::randomTeams = "false";				//"true" to enable team randomizer
$bwadmin::PingAbove = 0;						//value of min ping allowed on server, 0 to disable
$bwadmin::EnableNameBan = "false";				//true to enable name ban list.
$bwadmin::EnableIPBan = "false";				//true to enable ip ban list.
$bwadmin::OutOfBoundsTime = 0;					//disabled - seconds allowed to live OOB

$bwadmin::StationTime = 0;						//0 to disable, 15 for 15 second max station time
$bwadmin::GlobalReverseDamageMode = "false";
$bwadmin::PlayerAttackerRevFactor = 1.0;
$bwadmin::PlayerVictimRevFactor = 1.0;
$bwadmin::VehicleRD = "true";
$bwadmin::VehicleAttackerRevFactor = 1.0;
$bwadmin::VehicleVictimRevFactor = 1.0;
$bwadmin::DeployableRD = "true";
$bwadmin::DeployableAttackerRevFactor = 1.0;
$bwadmin::DeployableVictimRevFactor = 1.0;

$bwadmin::voteDisable[kick] = "false";
$bwadmin::voteDisable[purg] = "true";
$bwadmin::voteDisable[admin] = "false";
$bwadmin::voteDisable[cmission] = "false";
$bwadmin::voteDisable[tourney] = "false";
$bwadmin::voteDisable[ffa] = "false";
$bwadmin::voteDisable[lnam] = "false";
$bwadmin::voteDisable[etd] = "false";
$bwadmin::voteDisable[dtd] = "false";
$bwadmin::voteDisable[rd] = "true";
$bwadmin::voteDisable[nord] = "true";
$bwadmin::voteDisable[rape] = "true";
$bwadmin::voteDisable[norape] = "true";
$bwadmin::voteDisable[walk] = "true";
$bwadmin::voteDisable[nowalk] = "true";

// PORT: the two Combat settings of the settings file. Their only readers are the Tribal Combat
// menus in combatAdmin.cs, which 1.63 no longer builds (BWAdmin's menu replaced them), so
// $Combat::NoVoteAdmin = "true" (the release default, 'helps prevent hostile take overs') did nothing.
if($Combat::NoVoteAdmin == "true") $bwadmin::voteDisable[admin] = "true";
if($Combat::NoVoteKick == "true") $bwadmin::voteDisable[kick] = "true";

$bwadmin::AdminDisable[cteam] = "false";
$bwadmin::AdminDisable[cmission] = "false";
$bwadmin::AdminDisable[warn] = "true";
$bwadmin::AdminDisable[purg] = "true";
$bwadmin::AdminDisable[depurg] = "true";
$bwadmin::AdminDisable[kick] = "false";
$bwadmin::AdminDisable[gag] = "true";
$bwadmin::AdminDisable[ungag] = "true";
$bwadmin::AdminDisable[etd] = "false";
$bwadmin::AdminDisable[dtd] = "false";
$bwadmin::AdminDisable[rd] = "true";
$bwadmin::AdminDisable[nord] = "true";
$bwadmin::AdminDisable[rape] = "true";
$bwadmin::AdminDisable[norape] = "true";
$bwadmin::AdminDisable[score] = "true";
$bwadmin::AdminDisable[time] = "false";

$bwadmin::numberOfD1Tribes = 8;
$bwadmin::d1Tribe[1] = "Blood Eagle";
$bwadmin::d1TribeSkin[1] = "beagle";
$bwadmin::d1Tribe[2] = "Diamond Sword";
$bwadmin::d1TribeSkin[2] = "dsword";
$bwadmin::d1Tribe[3] = "Children of the Phoenix";
$bwadmin::d1TribeSkin[3] = "cphoenix";
$bwadmin::d1Tribe[4] = "Starwolf";
$bwadmin::d1TribeSkin[4] = "swolf";
$bwadmin::d1Tribe[5] = "Red";
$bwadmin::d1Tribe[6] = "Blue";
$bwadmin::d1Tribe[7] = "Gold";
$bwadmin::d1Tribe[8] = "Green";
$bwadmin::numberOfD2Tribes = 0;
$bwadmin::numberOfD3Tribes = 0;
$bwadmin::numberOfD4Tribes = 0;
$bwadmin::numberOfD5Tribes = 0;

$bwadmin::defaultTribeSkin[0] = "beagle";
$bwadmin::defaultTribeSkin[1] = "dsword";
$bwadmin::defaultTribeSkin[2] = "cphoenix";
$bwadmin::defaultTribeSkin[3] = "swolf";

$bwadmin::numberOfPass = 1;
$bwadmin::Pass[1] = password;

$bwadmin::MRenabled = "false";
$bwadmin::FullPublicMapList = "true";
$bwadmin::MRratioString="1 1 2 1 1 3 1 1 3 1 2 4 1 1 2";
$bwadmin::defaultRating="average";
$MR::noRepeatForNMaps=5;
$MR::exportMapList=false;



// =================== Script Support Evals ==============


	//Client side script can check for bwadmin support and returns
	//the support version in format "5.0"
function remotebwadmin::isCompatible(%client, %clientId)
{
	remoteEval(%client, bwadmin::Compatible, $bwadmin:supportversion);
}


	//This function allows the clientside script to enable eval support for
	//differing things.   eg.  ping times, objective info, etc
function remotebwadmin::EnableSupport(%client,%clientId,%type)
{
	if(%type == "StationType")
	{
		%client.StationTypeActive = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else if(%type == "ObjectiveInfo")
	{
		%client.reg = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else if(%type == "PilotingInfo")
	{
		%client.PilotInfoActive = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else if(%type == "KillInfo")
	{
		%client.KillInfoActive = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else if(%type == "WeaponChangeInfo")
	{
		%client.WeaponChangeInfoActive = true;
		remoteEval(%client, bwadmin::SupportVerify, %type, true);
	}
	else
		remoteEval(%client, bwadmin::SupportVerify, %type, false);
}



	//Returns true when player becomes pilot and false when he stops being a pilot
	//for whatever reason  ie. death, dismount, etc.
function bwadmin::isPilotInfoActive(%client, %active)
{
	if(%client.PilotInfoActive)
	{
		remoteEval(%client, bwadmin::PilotingInfo, %active);
	}
}


	//Returns the killer, the victim and the weapon used.  If player killed himslef weapon
	//will be returned as "Suicide".
function bwadmin::isKillInfoActive(%client, %killerid, %victimid, %weapontype)
{
	if(%client.KillInfoActive)
	{
		if(%weapontype == $LandingDamageType)
			%weapon = "Landing";
		else if(%weapontype == $ImpactDamageType)
			%weapon = "Impact"; //collisiion with vehicle
		else if(%weapontype == $BulletDamageType)
			%weapon = "Chaingun";
		else if(%weapontype == $EnergyDamageType)
			%weapon = "Turret";
		else if(%weapontype == $PlasmaDamageType)
			%weapon = "Plasma";
		else if(%weapontype == $ExplosionDamageType)
			%weapon = "Disc"; //Disc Launcher
		else if(%weapontype == $ShrapnelDamageType)
			%weapon = "Grenade";  //Grenade Launcher
		else if(%weapontype == $LaserDamageType)
			%weapon = "Laser";
		else if(%weapontype == $MortarDamageType)
			%weapon = "Mortar";
		else if(%weapontype == $BlasterDamageType)
			%weapon = "Blaster";
		else if(%weapontype == $ElectricityDamageType)
			%weapon = "ELF";  //Elf gun and elf turret
		else if(%weapontype == $CrushDamageType)
			%weapon = "Crush";  //Elevators, etc
		else if(%weapontype == $DebrisDamageType)
			%weapon = "Debris"; //Exploding vehicles, invs, etc
		else if(%weapontype == $MissileDamageType)
			%weapon = "Missle";  //Flyer and turret missles
		else if(%weapontype == $MineDamageType)
			%weapon = "Mine";  //Mines and Grenades
		remoteEval(%client, bwadmin::KillInfo, %killerid, %victimid, %weapon);
	}
}


	//Informs the client what weapon has been changed too OR when there is
	//no weapon mounted...ie inv   this is for use with reticle swapping
	//Will return "none" if no wepaon mounted
function bwadmin::isWeaponChangeInfoActive(%client, %weapon)
{
	if(%client.WeaponChangeInfoActive)
	{
		remoteEval(%client, bwadmin::WeaponChangeInfo, %weapon);
	}
}


	// Function tells client that has compatible script pack whether
	// they are at a normal or deployable station and, if deployable,
	// number of health kits that are needed to be bought to be full health
function bwadmin::isDeployableStationType(%client, %type)
{
	if(%client.StationTypeActive)
	{
		%playerId = Client::getOwnedObject(%client);
		%dlevel = GameBase::getDamageLevel(%playerId);
		if(Player::getItemClassCount(%client, "RepairKit") == 0)
			%repkits = 1;
		else
			%repkits = 0;
		if(%dlevel == 0)
			%noofkits = floor(%dlevel/0.2)+%repkits;
		else
			%noofkits = floor(%dlevel/0.2)+1+%repkits;
		remoteEval(%client, bwadmin::StationInfo, %type, %noofkits);
	}
}

	//Function returns status of objectives
function bwadmin::ObjList(%client)
{
   if(!%client.reg)
      return;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   %num = Group::objectCount(%group);
   for(%i = 0; %i < %num; %i++)
      {
         %obj = Group::getObject(%group, %i);
         %team = GameBase::getTeam(%obj);
         %teamName = getTeamName(%team);
         if(%obj.objectiveName != "")
            %objName = %obj.objectiveName;
         else
            %objName = %teamName @ " flag";

         if(%obj.holdingTeam != -1)
            %status = getTeamName(%obj.holdingTeam);
         else if(%obj.carrier != -1)
            %status = Client::getName(Player::getClient(%obj.carrier));
         else if(%obj.atHome)
            %status = "home";
         else
            %status = "dropped";
         if(getObjectType(%obj) != "Item")
            %status = %teamName;
         %type = gamebase::getdataname(%obj);
         remoteEval(%client, bwadmin::setObjList, %i, %num, %objName, %type, %status);
      }
}

	//Function returns players scores
function bwadmin::playerScoreList(%client)
{
   %num = getNumClients();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %team = Client::getTeam(%cl);
      remoteEval(%client, bwadmin::setPlayerScoreList, %num, %team, %cl, %cl.score);
   }
}



//============== Client Requestable Evals ====================================

	//returns the ave ping in last 10 seconds for clientId to client
function remotebwadmin::getPlayerPing(%client,%clientId)
{
	remoteEval(%client, bwadmin::PlayerPing, %clientId, $AvePing[%clientId]);
}

	//Returns the ave ping for team number %team in last 10 seconds....
	//A value of 999 means No Ping calculated or no players on team
function remotebwadmin::getTeamPing(%client,%team)
{
	remoteEval(%client, bwadmin::TeamPing, %team, $TeamPing[%team]);
}


	//Returns ave server ping in last 10 seconds
function remotebwadmin::getServerPing(%client)
{
	remoteEval(%client, bwadmin::ServerPing, $ServerAvPing);
}

function remotebwadmin::teamScoreList(%client)
{
   %num = getNumTeams();
   for(%i = 0; %i < %num ; %i++)
      remoteEval(%client, bwadmin::setTeamScoreList, %i, %num, getTeamName(%i), bwadmin::numTeamPlayers(%i), $teamScore[%i], $teamScoreLimit);
}



// ===================Legacy Reporting Functions==========

function remotebwadmin::reg(%client)
{
   if(%client.reg)
   {
      Client::sendMessage(%client,1,"You are already registered for BWAdmin server info.");
      return;
   }
   Client::sendMessage(%client,1,"BWAdmin server info registration accepted!");
   %client.reg = true;
   bwadmin::ObjList(%client);
   remotebwadmin::teamScoreList(%client);
   bwadmin::playerScoreList(%client);
}

function bwadmin()
{
	echo("BarrysWorld Admin Mod " @ $bwadmin::version @ " for Tribes " @ $bwadmin::tribesVersion @ " by Poker");
}

function bwadmin::reportScores()
{
	if($bwadmin::reportScores)
	{
	  for(%i = 0; %i < getNumTeams() ; %i++)
	   TeamMessages(0, -1, "Team " @ %i @ ": " @ getTeamName(%i) @ "   Score: " @ $teamScore[%i]);
	  TeamMessages(0, -1, "Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.");
	}
}

function remotebwadmin::getMatchInfo(%client)
{
	%time = floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60);
	for(%i = 0; %i < getNumTeams() ; %i++)
	   remoteEval(%client, "bwadmin::setMatchInfo", %time, %i, getTeamName(%i), bwadmin::numTeamPlayers(%i), $teamScore[%i]);
}

// =================Ping Time Functions====================================

function remotePingTime(%client, %start)
{
	if(%start > 0)
	{
		if($PingNo[%client] < 10)
		{
			$PingNo[%client]++;
			$PingTime[%client,$PingNo[%client]] = floor((getSimTime() - %start)*1000);
		}
		else
		{
			$StartPingCalc[%client] = true;
			$PingNo[%client] = 1;
			$PingTime[%client,$PingNo[%client]] = floor((getSimTime() - %start)*1000);
		}
		if($StartPingCalc[%client])
		{
			for(%i=1;%i<11;%i++)
			{
				%clientpingtotal = %clientpingtotal + $PingTime[%client,%i];
			}
			$AvePing[%client] = %clientpingtotal / 10;
		}
		else
		{
			for(%i=1;%i<=$PingNo[%client];%i++)
			{
				%clientpingtotal = %clientpingtotal + $PingTime[%client,%i];
			}
			$AvePing[%client] = %clientpingtotal / $PingNo[%client];
		}
	}
}


function CalculatePings()
{
	//Get Client Pings every second
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%start=getSimTime();
		remoteEval (%cl, eval, PingTime, %start);
	}
	//calculate team ping average
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl != -1)
		{
			%team = GameBase::getTeam(%cl);
			%TeamPingTotal[%team] = %TeamPingTotal[%team] + $AvePing[%cl];
			%TeamClients[%team]++;
			%ServerPingTotal = %ServerPingTotal + $PingTime[%cl];
			%ServerClients++;

			if($bwadmin::PingAbove > 0)
			{
				if($AvePing[%cl] < $bwadmin::PingAbove)
				{
					%cl.pingabovecheck++;
					if(%cl.pingabovecheck >= 16)
					{
						Admin::kick(-3, %cl);
					}
				}
				else
					%cl.pingabovecheck = 0;
			}
		}
	}
	for(%i = 0; %i < getNumTeams(); %i++)
	{
		if(%TeamClients[%i] > 0)
			$TeamPing[%i] = floor(%TeamPingTotal[%i] / %TeamClients[%i]);
		else
			$TeamPing[%i] = 999;
	}

	//Calc Server Ave Pings
	$ServerAvPing = floor(%ServerPingTotal / %ServerClients);
	schedule("CalculatePings();",1);
}


// ===================Admin Functions===================

function remotebwadmin::getPlayerList(%client)
{
	if(!%client.isSuperAdmin)
		return;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%ip = Client::getTransportAddress(%cl);
		remoteEval(%client, bwadmin::setPlayerList, %cl, %ip, $Client::info[%cl, 1], $Client::info[%cl, 2], $Client::info[%cl, 3], $Client::info[%cl, 4], ""); // PORT: field 5 is the 1.50 client's RPG password box
	}
}

function remotebwadmin::teamSwap(%client, %swap)
{
   if(%client.isSuperAdmin)
   {
      if(%swap && $bwadmin::teamSwap)
         return;
      if(%swap && !$bwadmin::teamSwap)
      {
         $bwadmin::teamSwap = true;
         messageAll(0, Client::getName(%client) @ " set Team Swap to ON.");
         return;
      }
      if($bwadmin::teamSwap)
      {
         $bwadmin::teamSwap = "";
         messageAll(0, Client::getName(%client) @ " set Team Swap to OFF.");
      }
   }
}

function bwadmin::autoMissionSkipVote()
{
   if($server::tourneymode || !$bwadmin::autoMissionSkipVote == "true")
      return;
   Admin::startVote(2048, "skip this mission", "skipmission", 0);
}

function bwadmin::voteCheck()
{
   if($curVoteTopic == "")
      bwadmin::autoMissionSkipVote();
   else
      schedule("bwadmin::voteCheck();", 5);
}

// ===================Utility Functions===================

function bwadmin::numTeamPlayers(%team)
{
    %numPlayers = getNumClients();
    %numTeamPlayers[%team] = 0;
    for(%i = 0; %i < %numPlayers; %i = %i + 1)
    {
       %pl = getClientByIndex(%i);
       %team2 = Client::getTeam(%pl);
       %numTeamPlayers[%team2] = %numTeamPlayers[%team2] + 1;
    }
    return %numTeamPlayers[%team];
}

function bwadmin::getLowTeam()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         %team = Client::getTeam(%pl);
         %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if(%numTeamPlayers[%i] < %leastPlayers)
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      return %leastTeam;
}

function bwadmin::checkRape()
{
   if($Server::TourneyMode)
      return;
   if(!$bwadmin::autoNBROn && !$bwadmin::autoNBROff)
      return;


   	%numPlayers=0;
   	for(%i = 0; %i < getNumTeams() ; %i++)
      	%numPlayers = %numPlayers + bwadmin::numTeamPlayers(%i);

   	if($bwadmin::autoNBROn)
   	{
		if((%numPlayers <= $bwadmin::autoNBROn) && ($bwadmin::noRape == "" || $bwadmin::noRape == "false"))
		{
		  	$bwadmin::noRape = true;
		  	messageAll(0, "'No Base Rape' Mode auto-ENABLED due to number of players");
		}
	}

   	if($bwadmin::autoNBROff)
   	{
		if((%numPlayers > $bwadmin::autoNBROff) && $bwadmin::noRape == true)
		{
		  	$bwadmin::noRape = "";
		  	messageAll(0, "'No Base Rape' Mode auto-DISABLED due to number of players");
		}
	}
}


//======================  NICK SERVER ==============================

function bwadmin::nickServ(%clientId)
{
   %name = Client::getName(%clientId);

   for(%i=1;%i < $UserList::MaxUsers+1;%i++)
   {
      if(%name == $UserList::UserName[%i] && $UserList::NickServ[%i] == true)
      {
         centerprint(%clientId, "Your player name is reserved on this server.  You MUST log in within 60 seconds.", 5);
         schedule("bwadmin::nickWarn(" @ %clientId @ ");", 30, %clientId);
         schedule("bwadmin::nickKick(" @ %clientId @ ");", 60, %clientId);
      }
   }
}

function bwadmin::nickWarn(%clientId)
{
   	if(!%clientId.AdminVerified)
   	{
      	centerprint(%clientId, "Your player name is reserved on this server.  You MUST log in within 30 seconds.", 5);
	}
}

function bwadmin::nickKick(%clientId)
{
   if(!%clientId.AdminVerified)
      Net::kick(%clientId, "BWAdmin:: That player name is reserved on this server, please choose another.");
}

// ===================Long Walk Functions===================


function bwadmin::walk::energysuck(%carrier)
{
	if(%carrier.carryFlag)
	{
		GameBase::setEnergy(%carrier,0);
		schedule("bwadmin::walk::energysuck(" @ %carrier @ ");", 0.5);
		return;
	}
}

function bwadmin::walk::checkForBuddy(%this)
{
	%client = Player::getClient(%this);
	%clientTeam = Client::getTeam(%client);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%clTeam = Client::getTeam(%cl);
		if(%client != %cl && %clientTeam == %clTeam)
		{
			%player = Client::getOwnedObject(%cl);
   			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   			{

   				%carrierPos = GameBase::getPosition(%this);
         			%buddyPos = GameBase::getPosition(%player);
   				%dist = Vector::getDistance(%carrierPos, %buddyPos);
				if(%dist <= 40)
  				   return true;
			}

		}
	}
	return false;
}


// ===================Observer Functions===================

function bwadmin::checkObserved(%flag, %player)
{
   for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
   {
      if((%client.observerTarget == %flag || %client.observerTarget == %player) && %client.observerMode == "observerObjectiveOrbit")
      {
         %target = %flag.carrier;
         if(%target == "-1")
            Observer::setTargetClient(%client, %flag);
         else
            Observer::setTargetClient(%client, %player);
      }
   }
}

function bwadmin::obsObj(%client, %target)
{
   %group = nameToID("MissionCleanup/ObjectivesSet");
   if(%target == "")
      %target = getNextObject(%group, 0);
   %num = Group::objectCount(%group);

   for(%i = 0; %i < %num; %i++)
   {
      if(%target == Group::getObject(%group, %i))
      {
         %carrier = %target.carrier;
         if(%carrier != "" && %carrier != "-1")
            %target = %carrier;
         %client.observerMode = "observerObjectiveOrbit";
         Observer::setTargetClient(%client, %target);
      }
   }
}

function bwadmin::nextObsObj(%client)
{
   if(%client.observerMode == "observerObjectiveOrbit" && getObjectType(%client.observerTarget) == "Player")
   {
      %target = %client.observerTarget;
      %lastObserved = %target.carryFlag;
   }
   else
      %lastObserved = %client.observerTarget;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   %nextObserved = getNextObject(%group, %lastObserved);
   if(!%nextObserved)
      %nextObserved = Group::getObject(%group, 0);
   %client.observerMode = "observerObjectiveOrbit";
   %carrier = %nextObserved.carrier;
   if(%carrier != "-1" && %carrier != "")
      %nextObserved = %carrier;
   Observer::setTargetClient(%client, %nextObserved);
}


// ==============Remote Observer Functions===================


function remotebwadmin::zoom(%client, %zoom)
{
   if(Client::getTeam(%client) != -1 || %zoom == "")
      return;
   if(%client.observerMode == "observerObjectiveOrbit" && %zoom < 5)
      %zoom = 5;
   if(%zoom > 50)
      %zoom = 50;
   %client.zoom = %zoom;
   if(%client.observerTarget != "" && (%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit"))
      Observer::setTargetClient(%client, %client.observerTarget);
}

function remotebwadmin::observePlayer(%client, %target)
{
   if(Client::getTeam(%client) != -1)
      return;
   if(%target == "")
   {
      if(%client.observerMode == "observerFly")
      {
         Observer::jump(%client);
         return;
      }
      if(%client.observerMode == "observerObjectiveOrbit")
      {
         %client.observerTarget = %client;
         %client.observerMode = "observerOrbit";
         Observer::nextObservable(%client);
         return;
      }
      return false;
   }
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1)
      return false;
   %client.observerMode = "observerOrbit";
   Observer::setTargetClient(%client, %target);
}

function bwadmin::setObserved(%client, %menu)
{
   if(!%client.reg && !%menu)
      return;
   %target = %client.observerTarget;

   if(%client.observerMode == "observerObjectiveOrbit")
   {
      if(getObjectType(%target) != "Player")
      {
         %team = GameBase::getTeam(%target);
         %teamName = getTeamName(%team);
         if(%teamName == "unnamed")
            %observedName = %target.objectiveName;
         else if(getObjectType(%target) != "Item")
            %observedName = %target.objectiveName @ " (" @ %teamName @ ")";
         else
            %observedName = %teamName @ " " @ gamebase::getdataname(%target);
      }
      else
      {
         %flag = %target.carryFlag;
         %team = GameBase::getTeam(%flag);
         %teamName = getTeamName(%team);
         %cl = Player::getClient(%target);
         %name = Client::getName(%cl);
         if(%teamName == "unnamed")
            %observedName = %flag.objectiveName @ " (" @ %name @ ")";
         else
            %observedName = %teamName @ " " @ gamebase::getdataname(%flag) @ " (" @ %name @ ")";
      }
   }
   else
      %observedName = Client::getName(%target);
   if(%client.reg)
      remoteEval(%client, bwadmin::observed, %observedName, %client.zoom);
   if(%observedName != "")
      bottomprint(%client, "<jc>Observing " @ %observedName, 5);
}

// legacy support
function remotebwadmin::observeFlag(%client, %team)
{
   if(Client::getTeam(%client) != -1 || %team == "")
      return;
   %teamName = getTeamName(%team);
   %targetName = %teamName @ " flag";
   remotebwadmin::observeObjective(%client, %targetName);
}


function remotebwadmin::observeObjective(%client, %targetName)
{
   if(Client::getTeam(%client) != -1)
      return;

   %group = nameToID("MissionCleanup/ObjectivesSet");
   %num = Group::objectCount(%group);

   if(%targetName == "")
   {
      bwadmin::obsObj(%client);
      return;
   }
   for(%i = 0; %i < %num; %i++)
   {
      %obj = Group::getObject(%group, %i);
      %team = GameBase::getTeam(%obj);
      %teamName = getTeamName(%team);

      if((%targetName == %obj.objectiveName || %targetName == %teamName @ " flag") && %obj != %client.observerTarget)
      {
         bwadmin::obsObj(%client, %obj);
         return;
      }
   }
}

function remotebwadmin::observerFreeFly(%client)
{
   if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit")
   {
      %client.observerTarget = "";
      %client.observerMode = "observerFly";
      %cam = Client::getObserverCamera(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%cam), GameBase::getRotation(%cam), true, true);
      if(%client.reg)
         bwadmin::setObserved(%client);
   }
}

function bwadmin::getNearestPlayer(%clientId)
{

		%cam = Client::getObserverCamera(%clientId);
		%pos = GameBase::getPosition(%cam);
		%leastDist = 5000;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl != %clientId.observerTarget)
			{
				%player = Client::getOwnedObject(%cl);
	   			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %player != %clientId.observerTarget)
	   			{
					%playerPos = GameBase::getPosition(%player);
					%dist = Vector::getDistance(%pos, %playerPos);
					if(%dist < %leastDist)
					{
						%leastDist = %dist;
						%nearest = %cl;
					}
				}
			}
		}
		echo("DEBUG::" @ %nearest);
		return %nearest;

}

function remotebwadmin::observeNearestPlayer(%client)
{
	if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerObjectiveOrbit" || %client.observerMode == "observerFly")
	{
		%client.observerMode = "observerOrbit";
		%player = bwadmin::getNearestPlayer(%client);
		Observer::setTargetClient(%client, %player);
	}
}

// ============== Station Eject Functions ===================

function bwCheckStationEject(%player, %station, %stat, %count)
{
	if($bwadmin::StationTime && !$Server::TourneyMode)
	{
		if((%player.inStation) && (%player.inStation == %station) && (%stat == %player.stationAccess))
		{
			if(%count)
			{
				if(%count == 1)
					Client::sendMessage(GameBase::getOwnerClient(%player),1,"You will be ejected from the station in 5 Seconds.~waccess_denied.wav");
				schedule("bwCheckStationEject(" @ %player @ "," @ %station @ "," @ %stat @ "," @ %count - 1 @ ");",5,%player);
			}
			else
			{
				Client::sendMessage(GameBase::getOwnerClient(%player),1,"You have been ejected from the station to give others access to it.~waccess_denied.wav");
				bwStationEjectPlayer(%station, %player);
			}
		}
	}
}

function bwStationEjectPlayer(%station, %player)
{
	%rot = GameBase::getRotation(%station);
	%rad = getWord(%rot, 2);
	%x = (-1) * (bwSin(%rad));
	%y = bwCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = bwDotProd(Vector::neg(%dir),10);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%vel = %x @ " " @ %y @ " " @ 15;
	Item::setVelocity(%player,%vel);
}

function bwDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function bwSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function bwCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}


//---------- Map Rotation Mod Functions ------------------
// Map Rotation by Mental Trousers

$MR::numOfRatings=5;
$mapRating::["verypopular"]=1;
$mapRating::["popular"]=2;
$mapRating::["average"]=3;
$mapRating::["unpopular"]=4;
$mapRating::["neverplay"]=5;

$MR::numOfChoices=4;
$MR::counter=0;
$MR::currentPos=0;

function bwadmin::MRsetRating(%map, %rating)
{
	$MR::rating[%map]=$mapRating::[%rating];
	$MR::played[%map]=0;
	//this function is now redefined at the end of MR::missionList() to avoid rebuilding the list a large
	//amount of times at start up.
	//MR::initialiseMapRotation();
}

function MR::nextMission()
{
	if ($MR::totalMapsInRotation<=$MR::noRepeatForNMaps)
		$MR::noRepeatForNMaps=$MR::totalMapsInRotation-1;

	if ($MR::totalMapsInRotation<2)
		$MR::noRepeatForNMaps=0;

	if ($MR::counter==0)
		$MR::played[$pref::lastMission]=1;

	if ((%rating=getWord($bwadmin::MRratioString, $MR::currentPos))==-1)
		{
		%rating=getWord ($bwadmin::MRratioString, 0);
		$MR::currentPos=0;
		}
	else
		$MR::currentPos++;

	%map=$MR::current[%rating];
	for (%i=0; %i<$MR::totalMapsInRotation; %i++)
		{
		%played=$MR::counter-$MR::played[%map];
		if (%played>=0 && %played<$MR::noRepeatForNMaps)
			{
			%map=$MR::missionList[%map];
			continue;
			}
		else
			%i=$MR::totalMapsInRotation;
		}

	$MR::current[%rating]=$MR::missionList[$MR::current[%rating]];
	$MR::played[%map]=$MR::counter;
	$MR::counter++;
	return %map;
}

function MR::getMapRating (%map)
{
	return $MR::rating[%map];
}

function MR::setLastMap()
{
	for (%i=1;%i<$MR::numOfRatings; %i++)
		$MR::missionList[$MR::current[%i]]=$MR::firstMap[%i];
}

function MR::missionList()
{
	for(%i=0;%i<5;%i++)
		$MR::MLIST[%i]="";
	for(%i=0;%i<=$MR::TypeCount;%i++)
		$MR::Type[%i]="";
	$MR::TypeCount=0;

	//Create list of acceptable ratings
	%imax = 1;
	$MR::ListRatings[1] = false;
	$MR::ListRatings[2] = false;
	$MR::ListRatings[3] = false;
	$MR::ListRatings[4] = false;
	for(%i=0;%i<%imax;%i++)
	{
		%testval = getWord($bwadmin::MRratioString,%i);
		if(%testval != -1 && %testval != "" && %testval != 5)
		{
			$MR::ListRatings[%testval] = true;
			%imax++;
		}
	}
	$MR::ListRatings[0] = false;
	$MR::ListRatings[5] = false;


	%index=1;
	while ((%map=$MLIST::EName[%index])!="")
	{
	echo (%map);
		if ($MLIST::EType [%index]!="Training")
		{
			if ((%rating=MR::getMapRating(%map))=="")
				%rating=$mapRating::[$bwadmin::defaultRating];

			if ($MR::firstMap[%rating]=="")
				$MR::firstMap[%rating]=%map;

			$MR::missionList[$MR::current[%rating]]=%map;
			$MR::current[%rating]=%map;

			//get mission types in rotation
			if($MR::ListRatings[%rating])
			{
				if($MR::TypeCount == "")
					$MR::TypeCount = 0;
				%foundtype = "false";
				for(%i = 1; %i < $MR::TypeCount+1; %i++)
				{
					if($MR::Type[%i] == $MLIST::EType[%index])
					{
						%foundtype = "true";
						%currenttype = %i;
						%i = $MR::TypeCount+1;
					}
				}
				if(%foundtype == "false")
				{
					$MR::TypeCount++;
					$MR::Type[$MR::TypeCount] = $MLIST::EType [%index];
					%currenttype = $MR::TypeCount;
				}
				if($MR::MLIST[%currenttype] == "")
					$MR::MLIST[%currenttype] = %index;
				else
					$MR::MLIST[%currenttype] = $MR::MLIST[%currenttype] @ " " @ %index;
			}
		}
		%index++;
	}
	$MR::totalMapsInRotation=%index;
	MR::setLastMap();

	//redefinition of bwadmin::MRsetRating to enable rebuilding the missionList on the fly
	function bwadmin::MRsetRating(%map, %rating)
	{
		$MR::rating[%map]=$mapRating::[%rating];
		$MR::played[%map]=0;
		$MR::counter=0;
		MR::initialiseMapRotation();
	}
}

function bwadmin::MRtest(%noofmaps)
{
	if(%noofmaps == "")
		%noofmaps = 100;
	for (%i=1;%i<=%noofmaps;%i++)
		echo(MR::nextMission ());
}

//$pref::lastMission

function MR::initialiseMapRotation()
{
	if ($MLIST::Count<1)
		return false;

	%first=file::findFirst("missions\\*.dsc");
	if (%first!="")
		MR::missionList();
	else
		echo ("Invalid missions - unable to assemble missionList");

	if ($MR::exportMapList)
		export("$MR::missionList*", "config\\MRmaps.cs", false);
}

function MR::enableRotationReset()
{
	function bwadmin::MRsetRating(%map, %rating)
	{
	$MR::rating[%map]=$mapRating::[%rating];
	$MR::played[%map]=0;
	$MR::counter=0;
	}
}
