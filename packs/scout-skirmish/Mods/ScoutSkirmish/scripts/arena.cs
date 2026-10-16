// Tribes Arena v 2.2
// Robert "Rasia" Hinkle
// This is a mission type taken from the idea of Clan Arena back in the good old Quake 1 days
// Its a Team DM game, in which everyone spawns, you rush for weapons, and try to kill each other
// When you die, you sit in observer mode until one team is all dead.  When that happens everyone respawns.
// I used a couple definations here:  a Match is a full compatition between two teams.  Each match is made
// up of a set of Games.  When one team fully dies, thats the end of a game.  Most matches are 3 out of 5 Games.
// I want to thank TheGriffin and Ninja for the help!

// Special Thanks goes to Figy, for being the closest to guess the Number of lines of Code Arena.cs is late at night when I was bored!!
// Honorable mention goes to DVCxPanda who got within 2 lines for his second guess

// Special Thanks to [PEN]Spiffy and [PEN]Venom for helping me test out the latest build (2.2)
// HUGE Thanks to Nookie, for being my little test dummy on, trying to fix the OpenGl crash bug!!


$Arena::GameTimeLimit = 240;  // In Seconds
$Arena::NumberMatchLimit = 3;			// After this many matches the server cycles to next map (Defualt 3).  Set = "" if you don't want this feature (or if it keeps crashing the server)
$Server::TimeLimit = 0;
$Arena::Scorelimit = 3;  // Default ScoreLimit
$Arena::ReadyTime = true;  
$Arena::AutoTeamJoin = true;


//////////// Don't Modify below this line

$Arena::Loaded = 1;
///Setting the TeamScores to 0 when the map starts
$TeamMatchScore[0] = 0;
$TeamMatchScore[1] = 0;
$Server::TeamDamageScale = 1; // Team Damage Always On
$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$ItemFavoritesKey = "Arena";  // Setup Arena Favs
$Arena::MatchStatus = 0;  // MatchStatus keeps track of where the match is.  0=PreMatch, 1=Battle, 2=Pre-Game, 3=Countdown
$Arena::MatchMode = 0;
$TestMissionType = "Scout";
$Arena::ReadyUpMessage = "Press your fire button to ready up";


// Server Functions etc.
function Station::onEndSequence(%this,%thread)
{
 	if (%thread == 1 && GameBase::isActive(%this)) 
	{
		GameBase::playSequence(%this,2,"use");
		return true;
	}
	%client = %this.target;
	if(%client == "") 
	{
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}

	if(%client != "") 
	{
		if(Client::getGuiMode(%client) != 1)
			Client::setGuiMode(%client,1);

	%team = Client::getTeam(%client);


 		if(%team == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) 
		{
			if (GameBase::getDamageState(%this) == "Enabled") 
			{
				if (GameBase::isPowered(%this)) 
				{
					%client.InvTrips++;
				}
			}
		}
	
		if($TeamEnergy[%team] != "Infinite") 
		{
			if(%this.clTeamEnergy != %client.TeamEnergy) 
			{
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat) 
			{
				TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}
	if(%this.target != "") 
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	%this.clTeamEnergy = "";
	return false;
}

function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	if($TestCheats == 0 && %client.spawn == "") {
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") 
		{
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price;
			if(%delta < 1 ) 
			{
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}  			
	if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
	
	}
	else if($TeamItemMax[%item] != "" && !$TestCheats) 
	{
			if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) {
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	else if(%item.className == Weapon) {
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}

   }
	if(%item.className != Armor && %item.className != Vehicle) {
	   %count = Player::getItemCount(%client,%item);
	  	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					if ($TeamItemMax[%item] != "")
						$TeamItemCount[GameBase::getTeam(%client),%item]++; 
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) {
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItem(%client,22);						
					}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				if ($TeamItemMax[%item] != "")
						$TeamItemCount[GameBase::getTeam(%client), %item]++; 
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) 
		{
			if(checkResources(%player,%item,1)) 
			{
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) 
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") 
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) 
					{
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				if ($TeamItemMax[%item] != "")
					$TeamItemCount[GameBase::getTeam(%client),%item]++; 
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) 
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor) 
		{
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) 
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") 
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
				else
					$TeamItemCount[(Client::getTeam(%client)),%item]--;
			}
			if(%item == EnergyPack) 
			{ 
				if(Player::getItemCount(%client,"LaserRifle") > 0) 
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}



function Station::onCollision(%this, %object)
{
	dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player") {
  	 	%client = Player::getClient(%object);
 		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) {
			if (GameBase::getDamageState(%this) == "Enabled") {
				if (GameBase::isPowered(%this)) {
					if (%client.InvTrips < 2) {
					    if(%this.enterTime == "")
						   %this.enterTime = getSimTime();
					    GameBase::setActive(%this,true);
					}
					else
						Client::sendMessage(%client,0,"You have already accessed Stations 2 times~waccess_denied.wav");
				}
				else 
					Client::sendMessage(%client,0,"Unit is not powered");
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
		else if(Station::getTarget(%this) == %object)
      {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				Client::clearItemShopping(%client);
				Station::onDeactivate(%this);
				Station::onEndSequence(%this,1);
				if(Client::getGuiMode(%client) != 1)
					Client::setGuiMode(%client,1);
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

// Makes InvStations REAL hard to kill
StaticShapeData InventoryStation
{
   description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1000.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};
StaticShapeData VehiclePad
{
   description = "www.haLoMaTriX.com";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	maxDamage = 1000.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

StaticShapeData Generator
{
   description = "Generator";
   shapeFile = "generator";
	className = "Generator";
   sfxAmbient = SoundGeneratorPower;
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
   maxDamage = 1000.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

StaticShapeData SolarPanel
{
   description = "Solar Panel";
	shapeFile = "solar_med";
	className = "Generator";
	debrisId = flashDebrisMedium;
	maxDamage = 1000.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};

StaticShapeData PortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
   sfxAmbient = SoundGeneratorPower;
   maxDamage = 1000.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};



// Objectives Functions

function ObjectiveMission::setObjectiveHeading()
{
   for(%i = -1; %i < getNumTeams(); %i++)
		Team::clearObjectives(%i);
   
   if($missionComplete)
   {
      %curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
		   echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
      {
		   if($teamScore[%i] == $teamScore[%curLeader]) { 
            %tieGame = true;
         	%tieTeams[%tie++] = %i;
			}
			else if($teamScore[%i] > $teamScore[%curLeader])
         {
            %curLeader = %i;	   
            %tieGame = false;
				%tie = 0;
				%tieTeams[%tie] = %curLeader; 
         }
      }
		if(%tieGame) {
			for(%g = 0; %g <= %tie; %g++) { 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
			 	%names = %names @ " all"; 
		}
		for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
			if(!%tieGame) {
	         if(%i == %curLeader) { 
					if($teamScore[%curLeader] == 1)
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else {
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
  					else
	          		Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}	
			else {
				if(getNumTeams() > 2) {
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
  	         }
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
		}
   }
   else {
      for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
		  	Team::setObjective(%i,1, "<f5>Mission Completion:");
		   Team::setObjective(%i, 2,"<f1>   - " @ $Arena::Scorelimit @ " points needed to win the match.");
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else if($missionComplete)
   {
      %time = getSimTime() - $missionStartTime;
      %minutes = Time::getMinutes(%time);
      %seconds = Time::getSeconds(%time);
      if(%minutes < 10)
         %minutes = "0" @ %minutes;
      if(%seconds < 10)
         %seconds = "0" @ %seconds;
      %str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
   }
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
      $ArenaObjectiveLine = 7 + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++) {
	  	Team::setObjective(%i, 3, " ");
  		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
      Team::setObjective(%i, 6, %str);
	  Team::setObjective(%i, $ArenaObjectiveLine, "<f5>Arena v2.2 Rules:    ");
	  Team::setObjective(%i, $ArenaObjectiveLine + 1, "<f4>Before a match starts, everyone on a team must readyup.  When everyone is ready, a 10 second countdown beings, and then the match and first game start.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 3, "<f4>When one team is fully dead (you don't respawn when you die), then a GAME is over.  Everyone respawns on the same team, and another countdown beings.  You CAN NOT join a team between games, only matches (without Admin help at least)");
	  Team::setObjective(%i, $ArenaObjectiveLine + 5, "<f4>This repeats until one team has won the amount of games required to win a match (" @ $Arena::ScoreLimit @ ").  When one team hits this limit, they win the match, and the process starts again.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 10, "<f5>Other Arena Stuff");
	  Team::setObjective(%i, $ArenaObjectiveLine + 12, "<f4>The * beside a persons name means they are alive.  The team always reflects what team they are a member of, and the score IS kills, but you also get 5 points for every match you win.");
	  Team::setObjective(%i, $ArenaObjectiveLine + 17, "<f6>Visit planetstarsiege.com/TheDen for clientside maps, new sounds, and other random stuff for Arena, as well as other mods and mission types.");
	}
}

// Now the Team Scores display the Varible TeamMatchScore, which is how many Games each team has won this match
function ObjectiveMission::refreshTeamScores()
{
  %nt = getNumTeams();
  Team::setScore(-1, "%t\t  0", 0);
  for(%i = -1; %i < %nt; %i++)
  {
      Team::setScore(%i, "%t\t  " @ $TeamMatchScore[%i], $TeamMatchScore[%i]);
      for(%j = 0; %j < %nt; %j++) 
         Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $TeamMatchScore[%j]);
  }
}

// Blanked so ScoreLimit won't change missions (like a cap limit)
function ObjectiveMission::checkScoreLimit()
{

}


//Blanked so a persons score doesn't go up becuase of holding an objective
function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{

}

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

function Mission::init()
{
	setClientScoreHeading("  Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEDPL\t\xFFAdmin");
	setTeamScoreHeading("Team Name\t\xD6Score");

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++)
   {
      $teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
      Team::setObjective(%i, $firstTeamLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      $firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
      $teamScore[%i] = 0;
      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   $numObjectives = 0;
   newObject(ObjectivesSet, SimSet);
   addToSet(MissionCleanup, ObjectivesSet);
   
   Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
   %group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %i + $firstObjectiveLine;
      ObjectiveMission::objectiveChanged(%obj);
   }
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }
   $TestMissionType = "ARENA";		
   AI::setupAI();
}



function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -1) // observers go last.
      %team = 9;

	  %teamstr = getTeamName(%clientId.matchteam);
	  if (%teamstr == "0")
		%teamstr = "";

	%admin = "";

  
   if (%clientId.isSuperAdmin)
		%admin = "S";
	else if (%clientId.isAdmin)
		%admin = "A";
	else
		%admin = " ";

	if (%clientId.isTeamCaptain)
		%admin = %admin @ "T";
   
   // objective mission sorts by team first.
   Client::setScore(%clientId,  %clientId.onteam @ " %n\t" @ %teamstr @ "\t  " @ %clientId.score  @ "\t%p\t%l\t   " @ %admin, %clientId.score + (9 - %team) * 10000);
}

// Admin Functions


function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

	if($curVoteTopic == "" && !%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
        	Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
	}
	if(%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);  //Voted Admins can Admin others
  		if(%clientId.isSuperAdmin)
	        {
 			        Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
	        }
		Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
	}
	else if (%clientId.isTeamCaptain)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "tfteamchange " @ %sel);
	}
    		if(%clientId.muted[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else
		        Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      		if(%clientId.observerMode == "observerOrbit")
		        Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   Client::addMenuItem(%clientId, %curItem++ @ "Tribes Arena Options", "arenaop");   
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
   
}


// Called when a client FIRST connects to a map to Choose thier Team (-2 is Obs, -1 is Automatic)
function processMenuInitialPickTeam(%clientId, %team)
{
   
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
	  %clientId.matchteam = -2;
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
	  %clientId.matchteam = %team; // Puts the selected team into the Structure
	  if ($Arena::MatchStatus == 0 || $Arena::MatchStatus == 2)
	  {
		%clientId.notready = true;  // Sets the Client to not ready
	    if ($Arena::ReadyTime && %team != -2)
			schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);
	  }
    }
   	  Game::refreshClientScore(%clientId);
}

function processMenuTFPickTeam(%clientId, %team)
{
   if(%clientId.isTeamCaptain)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

// Called to sort out what Menu selections do
function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   
   if(%opt == "fteamchange") //fteamchange is an Admin forcing a client to change teams
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	 if (!%cl.lock)
		Client::addMenuItem(%clientId, "9Observer/LockOut", 9);
	  return;
   }
   if(%opt == "tfteamchange") //tfteamchange is an Team Captain forcing a client to change to his team or off his team
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "TFPickTeam", true);
	if (%cl.matchteam == -2)
		Client::addMenuItem(%clientId, "0Your Team", %clientId.matchteam);
	else if (%cl.matchteam == %clientId.matchteam)
	      Client::addMenuItem(%clientId, "0Observer", -2);
        return;
   }        
   else if(%opt == "changeteams") //Client changing his own team.  Note, if the matchstatus is anything but 0, you can only goto Observer
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         if ($Arena::MatchStatus == 0)
	 {
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	 }
	 if (%clientId.lock)
		Client::addMenuItem(%clientId, "9Observer/UnLockMe", 9);
	 else
	    Client::addMenuItem(%clientId, "9Observer/LockMeOut", 9);

         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
    else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if (%opt == "cwinscore" && %clientId.isAdmin) // Changes $Arena::Scorelimit to whatever is selected
   {
      	Client::buildMenu(%clientId, "Change Winning Score:", "cwscore", true);
	Client::addMenuItem(%clientId, "12 out of 3", 2);
	Client::addMenuItem(%clientId, "23 out of 5", 3);
	Client::addMenuItem(%clientId, "34 out of 7", 4);
      	Client::addMenuItem(%clientId, "45 out of 9", 5);
      	Client::addMenuItem(%clientId, "56 out of 11", 6);
      	Client::addMenuItem(%clientId, "67 out of 13", 7);
      	Client::addMenuItem(%clientId, "78 out of 15", 8);
      	Client::addMenuItem(%clientId, "89 out of 17", 9);
      	Client::addMenuItem(%clientId, "910 out of 19", 10);
      	return;
   }	
   else if (%opt == "resetmatch" && %clientId.isAdmin) // Calls the Arena Reset function to reset the match
   {
	Arena::ResetMatch();
	messageall(0, Client::getName(%clientId) @ " has reset the match.");
	return;
   }
   else if (%opt == "forcematch" && %clientId.isAdmin) // Calls the Arena Reset function to reset the match
   {
	messageall(0, Client::getName(%clientId) @ " has forced the countdown to start");
	Arena::ForceMatchStart();
	return;
   }
   else if (%opt == "ereadytime" && %clientId.isAdmin)
   {
	$Arena::ReadyTime = true;
	messageAll(0, Client::getName(%clientId) @ " has enabled ReadyUp Time Limit.");
	return;
   }
   else if (%opt == "dreadytime" && %clientId.isAdmin)
   {
		$Arena::ReadyTime = false;
		messageAll(0, Client::getName(%clientId) @ " has disabled ReadyUp Time Limit.");
		return;
   }
   else if (%opt == "eautoteam" && %clientId.isAdmin)
   {
	$Arena::AutoTeamJoin = true;
	messageAll(0, Client::getName(%clientId) @ " has enabled AutoTeamJoin.");
	return;
   }
   else if (%opt == "dautoteam" && %clientId.isAdmin)
   {
	$Arena::AutoTeamJoin = false;
	messageAll(0, Client::getName(%clientId) @ " has disabled AutoTeamJoin.");
	return;	
   }
   else if (%opt == "cstrip" && %clientId.isSuperAdmin)
   {
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
   		if (%cl.isAdmin && !%cl.isSuperAdmin)
			%cl.isAdmin = false;

			Game::refreshClientScore(%cl);

			
	}
	messageAll(0, Client::getName(%clientId) @ " has stripped admin rights from the public.");
	return;
   }
   else if (%opt == "givecaptain")
   {
	if (%clientId.isTeamCaptain && %clientId.matchteam == %cl.matchteam)
	{
		%clientId.isTeamCaptain = false;
		%cl.isTeamCaptain = true;
		messageAll(0, Client::getName(%clientId) @ " has handed over the Team Captain rights to " @ Client::getName(%cl));
		Game::refreshClientScore(%cl);
		Game::refreshClientScore(%clientId);
	}
	return;
   }
   else if (%opt == "ematchmode" && %clientId.isAdmin)
   {
		messageAll(0, Client::getName(%clientId) @ " has put the server into Match Mode.");
		Arena::EnterMatchMode();
		return;
   }
   else if (%opt == "epubmode" && %clientId.isAdmin)
   {
	messageAll(0, Client::getName(%clientId) @ " has put the server into Public Play Mode.");
	Arena::EnterPubMode();
	return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if (%opt == "arenaop")
   {
    %curItem = 0;
    Client::buildMenu(%clientId, "Options", "options", true);
	 if(%clientId.isAdmin)
   	 {
	  	  Client::addMenuItem(%clientId, %curItem++ @ "Change Winning Score", "cwinscore"); //Admins can Change MatchScoreLimit
		  Client::addMenuItem(%clientId, %curItem++ @ "Reset Match", "resetmatch");
		  Client::addMenuItem(%clientId, %curItem++ @ "Force Match/Game Start", "forcematch");
		  if(!$Arena::Readytime)	  
			  Client::addMenuItem(%clientId, %curItem++ @ "Enable ReadyUp Timelimit", "ereadytime");
		  else
			  Client::addMenuItem(%clientId, %curItem++ @ "Disable ReadyUp Timelimit", "dreadytime");
		  if(!$Arena::AutoTeamJoin)
			  Client::addMenuItem(%clientId, %curItem++ @ "Enable AutoTeamJoining", "eautoteam");
		  else
			  Client::addMenuItem(%clientId, %curItem++ @ "Disable AutoTeamJoining", "dautoteam");
		  if(!$Arena::MatchMode)
			Client::addMenuItem(%clientId, %curItem++ @ "Enter Match Mode", "ematchmode");
		  else
			Client::addMenuItem(%clientId, %curItem++ @ "Enter Public Mode", "epubmode");
		  if (%clientId.isSuperAdmin)
		      Client::addMenuItem(%clientId, %curItem++ @ "Strip Public Admins", "cstrip");
	 }
	 if(%clientId.isTeamCaptain && %clientId.selClient)
	 {
		 %sel = %clientId.selClient;
		 %name = Client::getName(%sel);
		 Client::addMenuItem(%clientId, %curItem++ @ "Make " @ %name @ " the Captain", "givecaptain " @ %sel);
	 }
	 return;
   }

   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
  		 Game::refreshClientScore(%cl);

      }
   }
   Game::menuRequest(%clientId);
}

function processMenuCWScore(%clientId, %opt) // This changes the ScoreLimit, called from the Menu
{
	if (!%clientId.isAdmin)
		return;
	messageAll(0, Client::getName(%clientId) @ " has changed the Winning Score to " @ %opt);
	$Arena::Scorelimit = %opt;
}


// Called when a Team Change is in effect
function processMenuPickTeam(%clientId, %team, %adminClient)
{

   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.lock && %adminClient != "")
   {
		Client::sendMessage(%adminClient,3, Client::getName(%clientId) @ " has locked himself out of play.  He will not be able to join a team until he selects a team or unlocks himself from the Tab Menu.");
		return;
   }
   
   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if (%team == 9 && %clientId.lock)
   {	
		messageAll(0, Client::getname(%clientId) @ " has unlocked himself.");
		%clientId.lock = false;
		%team = -2;
	}
	else if(%team != 9)
		%clientId.lock = false;
	else
   {
		%clientId.lock = true;
		messageAll(0, Client::getname(%clientId) @ " has locked himself out of play.  He will be unable to join the game until he unlocks himself via the Player Menu.");
		%team = -2;
	}
   
   if(%team == -1)
   {
		if (Arena::CountTeam(0)  > Arena::CountTeam(1))
		{
			%team = 1;
			%clientId.matchteam = 1;
		}
		else if (Arena::CountTeam(0)  < Arena::CountTeam(1))
		{
			%team = 0;
			%clientId.matchteam = 0;
		}
		else if ($TeamMatchScore[0] > $TeamMatchscore[1])
		{
			%clientId.matchteam = 1;
			%team = 1;
		}
		else
		{
			%team = 0;
			%clientId.matchteam = 0;
		}
   }
   
   if(%team == -2)
   {
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			if(%adminClient == "") 
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			else
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			if ((Arena::CountTeamPlayers(%clientId.matchteam) == 0) && (%clientId.matchteam != -2) && $Arena::MatchStatus != 0)  // If the observer was the last guy on the team, the other team wins
			{
				%temp = 1 - %clientId.matchteam;
				%clientId.matchteam = -2;
				centerPrintAll("<jc>" @ getTeamName(%temp) @ " has won the game", 10);
				$Arena::MatchStatus = 2;
				Arena::GameOver(%temp);
			}
			else if ($Arena::MatchMode == 1 && %clientId.isTeamCaptain)
			{
				%clientId.isTeamCaptain = false;
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
				{
					if (%cl.matchteam == %clientId.matchteam && %cl != %clientId)
					{
						%cl.isTeamCaptain = true;
						messageAll(0, Client::getName(%cl) @ " has become the Team Captain of " @ getTeamName(%cl.matchteam));
						Game::refreshClientScore(%cl);
					}
				}
				
			}
			%clientId.matchteam = -2;
			%clientId.onteam = " ";
			Game::refreshClientScore(%clientId);
		}
	   return;
   }
   else if($Arena::MatchStatus == 1)
   {
		%clientId.matchteam = %team;
		Game::refreshClientScore(%clientId);
		if(%adminClient == "")
			messageAll(0, Client::getName(%clientId) @ " has joined the "  @ getTeamName(%team) @ " team, and will spawn after this game.");
		else
		      messageAll(0, Client::getName(%clientId) @ " has joined the "  @ getTeamName(%team) @ " team, and will spawn after this game, this done by " @ Client::getName(%adminClient) @ ".");

		return;
  }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
   {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");


   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
   %clientId.matchteam = %team; // Sets the clients.matchteam to whatever team he joined
   if ($Arena::MatchMode == 1 && Arena::CountTeamPlayers(%team) == 1)
   {
		%clientId.isTeamCaptain = true;
		messageAll(0, Client::getName(%clientId) @ " has become the Team Captain of " @ getTeamName(%team));
   }
   Game::refreshClientScore(%clientId);
   if ($Arena::ReadyTime && %team != -2)
	schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);

}



// Mostly a copy of the above function, but this one doesn't reset your .matchteam varible
function Arena::PickTeam(%clientId, %team, %adminClient)
{
 
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if (%clientId.lock)
		return;


   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if(%team == -2)
   {
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			%clientId.onteam = " ";
		    Game::refreshClientScore(%clientId);
		}
        return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);
	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	Game::RefreshClientScore(%clientId);
    if ($Arena::ReadyTime && %team != -2)
		schedule("Arena::CheckReadyState(" @ %clientId @ ");", 30);
}

// Observer Functions
// triggerUp is the Fire Key, as far as I can tell, this controls "Fire when ready"
function Observer::triggerUp(%client)
{
   if(%client.observerMode == "dead")
   {
      if(%client.dieTime + $Server::respawnTime < getSimTime())
      {
		 if(Game::playerSpawn(%client, true))
         {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      }
   }
   else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly")
   {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
   else if(%client.observerMode == "justJoined")
   {
      %client.observerMode = "";
      Game::playerSpawn(%client, false);
   }
   else if(%client.observerMode == "pregame" && ($Arena::MatchStatus == 0 || ($Arena::MatchStatus == 2 && $Arena::MatchMode == 1 && %client.isTeamCaptain))) // if client is in pregame, and the match is at a point where he can ready or unready
   {
	 if(%client.notready) // If he is not ready, ready him
      {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
          bottomprint(%client, $PreGameMessage[%client.matchteam] @ "Waiting for match start (FIRE if not ready).", 0);
		  Arena::PreGameMode();
      }
      else // else unready him
      {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, $PreGameMessage[%client.matchteam] @ "Press FIRE when ready.", 0);
      }
	}  		
}


// Game Functions
// called right at the start of a new map
function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
   	Game::refreshClientScore(%cl);  // Originally it had you come out of Obs here, took it out
	}
   Game::checkTimeLimit();
}

// Called when a player Physically spawns
function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

   Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      bottomprint(%clientId, "<jc><f0>Tribes Arena Version 2.2\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
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

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
	   else
	      %armor = "lfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
		// This section of code forces them to ALWAYS enter pregame on spawn

	         if ($Arena::MatchStatus != 1)  // If Spawning, and a battle isn't raging then Ready up Boys
			 {
				%clientId.observerMode = "pregame";
				Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
				%clientId.notready = true;
				centerprint(%clientId, $Server::joinMOTD @ "\n\n<f1><jc>" @ $PreGameMessage[%clientId.matchteam] @ "\n" @ $Arena::ReadyUpMessage, 10);
			 }

	   %clientId.onteam = "*";

	   }
      return true;
	}
	else 
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}


// Called when someone first connects into the Mission
function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   GameBase::setTeam(%clientId, -1);

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);


      %clientId.observerMode = "pickingTeam";

      if($Arena::MatchStatus != 0) // If a match is in progress, wait in observer until its done
      {
         %clientId.observerMode = "observerFly";
		 if($Arena::MatchMode)
			bottomprint(%clientId, $Server::JoinMOTD @ "\n\n<jc><f1>Server is running Tribes Arena v2.2 and is in match mode. Please wait until its finished.  Score limit is " @ $Arena::Scorelimit @ "\nAutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\nReadyUp Timer is " @ $Arena::ReadyTime, 5);
		else
		{
			bottomprint(%clientId, $Server::JoinMOTD @ "\n\n<jc><f1>Server is running Tribes Arena v2.2 and is in open play mode. You will spawn as soon as this game is over.  Score limit is " @ $Arena::Scorelimit @ "\nAutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\nReadyUp Timer is " @ $Arena::ReadyTime, 5);
			processMenuPickTeam(%clientId, -1);
		}
         Game::RefreshClientScore(%clientId);
		 return;
      }
      else // Else choose your team
      {
         bottomprint(%clientId, "<jc><f1>Server is running a modified version of Tribes Arena v2.2.  Match has not yet started, Pick a Team.  Score limit is " @ $Arena::Scorelimit @ "\nAutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\nReadyUp Timer is " @ $Arena::ReadyTime, 5);
		 if ($Arena::AutoTeamJoin)
			processMenuPickTeam(%clientId, -1);
		 else
		    processMenuPickTeam(%clientId, -2);
      }
      %clientId.justConnected = "";
	  Game::RefreshClientScore(%clientId);
	  Client::sendMessage(%clientId, 1, "Scout Scirmish Mod www.haLoMaTriX.com ");

}

// when a client connects, zero out that id's stats
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	%playerId.matchteam = -2;
	$menuMode[%playerId] = "None";
	%playerId.onteam = " ";
	Game::refreshClientScore(%playerId);
}

// When someone is killed this is where it goes
function Client::onKilled(%playerId, %killerId, %damageType)
{
	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
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


	if(!%killerId)
	{
		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;
	}
	else if(%killerId == %playerId)
	{
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %killerId.scoreKills++;
      %playerId.scoreDeaths++;
	  %killerId.score--;
		if ($Arena::MatchStatus != 1)
		{
			schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
		}
	  Game::refreshClientScore(%playerId);
	
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
      if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
		if(%damageType != $MineDamageType) 
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(0, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %killerId.scoreDeaths++;
		 %killerId.score--;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %playerId.scoreDeaths++;  // test play mode
 		%killerId.score++;
		%killerId.scoreKills++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }


	if ($Arena::MatchStatus == 1) // This test keeps from one team winning, and then getting their last member killed and screwing up the whole thing :)
	{
		schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
		schedule("Arena::CheckTeamDeath( " @ %playerId.matchteam @ ");", 3);
	}
	else
		Arena::PickTeam(%playerId, -2);


}	

// Someone bailing on the server
function Client::leaveGame(%clientId)
{

   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);

	if (%clientId.isTeamCaptain == true)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if (%cl != %clientId && %cl.matchteam == %clientId.matchteam && %clientId.isTeamCaptain == true)
			{
				%clientId.isTeamCaptain = false;
				%cl.isTeamCaptain = true;
				messageAll(0, Client::getName(%cl) @ " has become the new Team Captain of " @ getTeamName(%cl.matchteam));
				break;
			}
		}
	}

	%clientId.isTeamCaptain = false;

	
	if (Client::getTeam(%clientId) > -1)
	{
		Arena::PickTeam(%clientId, -2);

		if (Arena::CountTeamPlayers(%clientId.matchteam) == 0 && $Arena::MatchStatus != 0)
		{	
			$Arena::MatchStatus = 2;
			%otherteam = 1 - %clientId.matchteam;
			%clientId.matchteam = -2;
			Game::refreshClientScore(%clientId);
			centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 5);
			schedule("Arena::GameOver(" @ %otherteam @ ");", 4);
		}
	}
	



}

	
// Server Functions
		
//When a new level is loaded, reload the base files I overwrote functions from.  If its an arena map, I will re-overwrite them

function Server::loadMission(%missionName, %immed)
{
  
      if($loadingMission)
      return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
   }

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   $TeamItemMax[HeavyArmor] = "";
   $TeamItemMax[LaserRifle] = "";
   
   exec(observer);
   exec(admin);
   exec(server);
   exec(station);
   exec(item);
   exec(staticshape);

   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); // deal with time imprecision

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();      

}




// Arena Functions
// Called when one team no longer has members in a game
function Arena::CheckTeamDeath(%team)
{
	%teamCount = Arena::CountTeamPlayers(%team);
	%otherteam = 1 - %team;
	if (%teamCount == 1)
		messageAll(0, getTeamName(%team) @ " has one member left.  FINISH HIM!~wfinishim.wav");
	if (%teamCount < 1 && $Arena::MatchStatus == 1) //Someone won a game woohoo!
	{
	    $Arena::MatchStatus = 2;
		centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 3);
		schedule("Arena::GameOver(" @ %otherteam @ ");", 4);  // Game is over, pass the winning team's index
	}
}

function Arena::GameOver(%winningTeam)
{

// Big Statement.  Each client is killed to prevent ghosting and then kicked to observer
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam != -2)
		{	
			%player = Client::getOwnedObject(%cl);
			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
			{
				playNextAnim(%cl);
				Player::kill(%cl);
				if ($Arena::MatchMode == 1 && %cl.isTeamCaptain)
					%cl.notready = true;
			}
		

			Arena::PickTeam(%cl, -2);
		}
	}

	$TeamMatchScore[%winningTeam]++;
	ObjectiveMission::refreshTeamScores();
	if ($TeamMatchScore[0] > $TeamMatchScore[1])
	{
		$PreGameMessage[0] = "<f1><jc>You are winning by " @ $TeamMatchScore[0] - $TeamMatchScore[1] @ ".  You need " @  $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
		$PreGameMessage[1] = "<f1><jc>You are losing by " @ $TeamMatchScore[0] - $TeamMatchScore[1] @ ".  They need " @ $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
	}
	else if ($TeamMatchScore[0] < $TeamMatchScore[1])
	{
		$PreGameMessage[1] = "<f1><jc>You are winning by " @ $TeamMatchScore[1] - $TeamMatchScore[0] @ ".  You need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
		$PreGameMessage[0] = "<f1><jc>You are losing by " @ $TeamMatchScore[1] - $TeamMatchScore[0] @ ".  They need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
	}
	else
	{
		$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit - $TeamMatchScore[0] @ " games to win! \n ";
		$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit - $TeamMatchScore[1] @ " games to win! \n ";
	}		
	if ($TeamMatchScore[%winningTeam] >= $Arena::Scorelimit || Arena::CountTeam(1 - %winningTeam) == 0) //If a team has hit the ScoreLimit or if a team is completely empty of players
	{
		$Arena::ReadyUpMessage = "Smack your fire button when you are ready";
		Arena::MatchCompleted(%winningTeam); // Match Over
		if ($Arena::MatchStatus == 3)
			schedule("Arena::ResetMatch();", 11);
		return;
	}
	else // Else put all the clients back on the team they belong
	{		
		if ($Arena::MatchMode == 1)
			$Arena::ReadyUpMessage = "Only your Captain needs to ready";
		else
			$Arena::ReadyUpMessage = "";

		schedule("Arena::PutClientsBackOnTeams();", 6);
		schedule("Arena::PreGameMode();", 7); // Back to Pre-Game Mode
	}		

}

function Arena::PutClientsBackOnTeams()
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam != -2)
		{
			Arena::PickTeam(%cl, %cl.matchteam);
			Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
			%cl.notready = true;
		}
	}
}

//Called when a Team has won the Match
function Arena::MatchCompleted(%winningTeam)
{
	messageAll(0, "~wflagcapture.wav");
	centerPrintAll("<jc>" @ getTeamName(%winningTeam) @ " has won the match.  They all get 5 points!", 4);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam == %winningTeam)
			%cl.score = %cl.score + 5;
	}
	schedule("Arena::ResetMatch();", 4);
	$Arena::NumberMatchLimit--;
}

// Starts the whole process over
function Arena::ResetMatch()
{
	
	if ($Arena::NumberMatchLimit < 1 && $Arena::NumberMatchLimit != "")
	{
		Server::NextMission();
		return;
	}
	$Arena::MatchStatus = 0;
	$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
	$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
	for (%i = 0; %i < getNumTeams(); %i++) // Clears the team score
		$TeamMatchScore[%i] = 0;

	ObjectiveMission::refreshTeamScores();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))  // Sets all players to Observer Mode
	{	
		%player = Client::getOwnedObject(%cl);
		%cl.matchteam = -2;
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
		{
			playNextAnim(%cl);
			Player::kill(%cl);
			%cl.isTeamCaptain = false;
		}
		if (!$Arena::AutoTeamJoin)
		{
			processMenuPickTeam(%cl, -2);
			bottomprint(%cl, "<jc><f1>Server is running Tribes Arena v2.2 and is in Pre-Match Mode. Pick a Team.  Score limit is " @ $Arena::Scorelimit, 5);
		}

		Game::refreshClientScore(%cl);
	}
	if ($Arena::AutoTeamJoin)
	{
		while(true)
		{
			%currenthighscore = -50000;	
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				%cl.notready = true;
				if (%cl.matchteam == -2 && %cl.lock == false)
				{
					%currentscore = %cl.score;
					if (!%currentscore)
						%currentscore = 0;

					if (%currentscore > %currenthighscore || %currenthighscore == -50000)
					{
						%currenthighscore = %currentscore;
						%currenthighclient = %cl;
					}
				}		
			}
			if (%currenthighscore != -50000)
			{
				processMenuPickTeam(%currenthighclient, -1);
				Game::refreshClientScore(%currenthighclient);
			}		
			else
			{
				break;
			}
		}
	}
}	// NOTE: After this function the MatchStatus is now in Pre-Match mode, so people can join teams via the menu


function Arena::CheckReadyStatus()
{
		if ($Arena::MatchMode == 0)
		{
			if ($Arena::MatchStatus != 0)
				return true;

			%NotReadyString = "Clients not ready:";
			%NotReadyCount = 0;

			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) // Check the Ready Status of each Client
			{
				if(%cl.observerMode == "pregame" && %cl.notready)
				{
					%NotReadyCount++;
					%NotReadyString = %NotReadyString @ " " @ Client::getName(%cl);
				 }
			}
	
			if (%NotReadyCount > 0)
			{
				%NotReadyString = %NotReadyString @ ".";
				if (%NotReadyCount < 4)
					messageAll(0, %NotReadyString);
				return false;
			}
			else
				return true;
		}
		else
		{
			%NotReadyString = "Teams not ready:";
			%NotReadyCount = 0;

			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) // Check the Ready Status of each Client
			{
				if(%cl.isTeamCaptain && %cl.notready)
				{
					%NotReadyCount++;
					%NotReadyString = %NotReadyString @ " " @ getTeamName(Client::getTeam(%cl));
				 }
			}
	
			if (%NotReadyCount > 0)
			{
				%NotReadyString = %NotReadyString @ ".";
				if (%NotReadyCount < 4)
					messageAll(0, %NotReadyString);
				return false;
			}
			else
				return true;
		}


}

// Pre-Game Mode Function
function Arena::PreGameMode()
{

	if (Arena::CountTeamPlayers(0) < 1 || Arena::CountTeamPlayers(1) < 1) // If teams are empty, say so
	{
		messageAll(0, "Teams not full, waiting for more players");
	}
	else
	{ 		
		if (Arena::CheckReadyStatus()) // If everyone is ready, lets rumble!!
		{
			if ($Arena::MatchStatus == 3)
				return;				
			else if ($Arena::MatchStatus == 0)
				messageAll(0, "Battle Starts in 10 seconds~wrumble.wav");
			else
				messageAll(0, "Arena Battle Starts in 10 seconds");
			$Arena::MatchStatus = 3;
			schedule("messageAll(0, \"Battle begins in 5 seconds\");", 5);
			schedule("messageAll(0, \"Battle begins in 4 seconds\");", 6);
			schedule("messageAll(0, \"Battle begins in 3 seconds\");", 7);
			schedule("messageAll(0, \"Battle begins in 2 seconds\");", 8);
			schedule("messageAll(0, \"Battle begins in 1 seconds\");", 9);
			schedule("Arena::StartGame();", 10);

		}
	}
}

function Arena::ForceMatchStart()
{
	if ($Arena::MatchStatus == 3)
		return;
	else if ($Arena::MatchStatus == 0)
		messageAll(0, "Battle begins in 10 seconds~wrumble.wav");
	else
		messageAll(0, "Battle begins in 10 seconds");
	$Arena::MatchStatus = 3;
	schedule("messageAll(0, \"Battle begins in 5 seconds\");", 5);
	schedule("messageAll(0, \"Battle begins in 4 seconds\");", 6);
	schedule("messageAll(0, \"Battle begins in 3 seconds\");", 7);
	schedule("messageAll(0, \"Battle begins in 2 seconds\");", 8);
	schedule("messageAll(0, \"Battle begins in 1 seconds\");", 9);
	schedule("Arena::StartGame();", 10);
}
// Starts the Game
function Arena::StartGame()
{

	$Arena::MatchStatus = 1;
	$Arena::GameStartTime = getSimTime();
	Arena::CheckGameTimeLimit();
	Arena::ResetItemCounts();
	messageAll(0, "It has begun...~wfight.wav");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{		
		if (Client::getTeam(%cl) != %cl.matchteam && %cl.matchteam != -2)
			Arena::PickTeam(%cl, %cl.matchteam);
		%cl.InvTrips = 0;
		%cl.EnergyWarning = 0;
		if (%cl.matchteam != -2)
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			bottomprint(%cl, "", 0);
		}
	}
}

// Counts the people physically alive on a team
function Arena::CountTeamPlayers(%team)
{
	%teamCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if (Client::getTeam(%cl) == %team)
			%teamCount++;
	}

	return %teamCount;
}

// Counts the people on a team, even if they are in Observer mode currently
function Arena::CountTeam(%team)
{
	%teamCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if (%cl.matchteam == %team)
			%teamCount++;
	}

	return %teamCount;
}

function Arena::CheckReadyState(%clientId)
{
	if (%clientId.notready && $Arena::ReadyTime && ($Arena::MatchStatus == 0 || $Arena::MatchStatus == 2))
	{	
		processMenuPickTeam(%clientId, -2);
		messageAll(0, Client::getName(%clientId) @ " didn't ready up in time and was placed in observer mode.");
	}
}

function ceiling(%number) // I just refuse to believe Dev didn't make one, but it was quicker to make one than to look for it :)
{
	if (floor(%number) == %number)
		return %number;
	else
		return (1 + floor(%number));
}

function Arena::EnterMatchMode()
{
	if ($Arena::MatchMode == 1)
		return;

	$Arena::AutoTeamJoin = false;
	$Arena::ReadyTime = false;
	
	$Arena::MatchMode = 1;
	$TeamItemMax[LaserRifle] = 2;

	Arena::ResetMatch();

}


function Arena::EnterPubMode()
{
	if ($Arena::MatchMode == 0)
		return;

	$Arena::MatchMode = 0;
	$Arena::AutoTeamJoin = true;
	$Arena::ReadyTime = true;
	$TeamItemMax[LaserRifle] = "";


	Arena::ResetMatch();
}

function Arena::CheckGameTimeLimit()
{
	if ($Arena::GameTimeLimit == 0 || $Arena::MatchStatus != 1)
		return;

//	if (Arena::CountTeamPlayers(0) == 0)
//	{
//		return;
//	}
//	else if (Arena::CountTeamPlayers(1) == 0)
//	{
//		return;
//	}

	%currentTime = getSimTime();

	%currentTime = floor(%currentTime);
	$Arena::GameStartTime = floor($Arena::GameStartTime);

	echo($Arena::GameTimeLimit @ " " @ $Arena::GameStartTime @ " " @ %currentTime);

	if (($Arena::GameStartTime + $Arena::GameTimeLimit) <= %currentTime)
	{
		Arena::GameTimeLimitHit();
	}
	else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 5) == %currentTime)
	{
		messageAll(0, "5 seconds remaining");
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
	else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 10) == %currentTime)
	{
		messageAll(0, "10 seconds remaining ");
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
	else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 30) == %currentTime)
	{
		messageAll(0, "30 seconds remaining ");
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
	else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 60) == %currentTime)
	{
		messageAll(0, "1 minute remaining");
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
	else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 120) == %currentTime)
	{
		messageAll(0, "2 minutes remaining");
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
	else
	{
		schedule("Arena::CheckGameTimeLimit();", 5);
	}
}

function Arena::GameTimeLimitHit()
{
	if (Arena::CountTeamPlayers(0) > Arena::CountTeamPlayers(1))
	{
		messageAll(0, getTeamName(0) @ " is victorius");
		Arena::GameOver(0);
	}
	else if (Arena::CountTeamPlayers(0) < Arena::CountTeamPlayers(1))
	{
		messageAll(0, getTeamName(1) @ " is victorius");
		Arena::GameOver(1);
	}
	else
	{
		Arena::TieGame();
	}
}

function Arena::TieGame()
{
	messageAll(0, "The Timelimit has run out, and both teams have the same amount of units left.  The game will be replayed.");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		if (%cl.matchteam != -2)
		{	
			%player = Client::getOwnedObject(%cl);
			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
			{
				playNextAnim(%cl);
				Player::kill(%cl);
			}
		

			Arena::PickTeam(%cl, -2);
		}
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
			if (%cl.matchteam != -2)
			{
				Arena::PickTeam(%cl, %cl.matchteam);
				Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
				%cl.notready = false;
				bottomprint(%cl, $PreGameMessage[%cl.matchteam] @ "Game starting in 10 seconds", 0);
			}
	}

	Arena::PreGameMode(); // Back to Pre-Game Mode
}

function Arena::ResetItemCounts()
{
	$TeamItemCount[0,LaserRifle] = 0;
	$TeamItemCount[1,LaserRifle] = 0;
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client))
		return;

   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" ) 
	{
		%stationName = GameBase::getDataName(%station); 
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0) 
		{
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) 
			{ 
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) 
				{
					%count = Player::getItemCount(%client,%item);
					if(%count) 
					{
						if(%item.className != Armor) 
						{
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
							if ($TeamItemMax[%item] != "")
								$TeamItemCount[GameBase::getTeam(%client), %item]--;
						}
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 20; %i++) 
			{ 
				if(%favItem[%i] != "") 
				{
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) 
					{
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
			if(%bought) 
			{
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}

