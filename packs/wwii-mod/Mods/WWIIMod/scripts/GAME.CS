exec("comchat.cs");
exec("WWII_SpawnInterface.cs");

$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;


//  Global Variables

$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType]      = "%2 crashed to %3 death.";
$deathMsg[$ImpactDamageType]      = "%2 was squished to death.";
$deathMsg[$MineDamageType]	       = "%1 blows %2 up real good.";
$deathMsg[$mp40]	       = "%1[MP40] %2";
$deathMsg[$bren]	       = "%1[Bren-LMG] %2";
$deathMsg[$bazooka]	       = "%1[M9A1Bazooka] %2";
$deathMsg[$k98]	       = "%1[K98Rifle] %2";
$deathMsg[$MP18]	       = "%1[MP18] %2";
$deathMsg[$panzershreck]	       = "%1[Panzershreck] %2";
$deathMsg[$Fallschirmj]	       = "%1[FG42] %2";
$deathMsg[$STG]	       = "%1[STG44] %2";
$deathMsg[$springfield]	       = "%1[SpringField-M1903] %2";
$deathMsg[$ppsh]	       = "%1[PPSH41] %2";
$deathMsg[$bar]	       = "%1[B.A.R] %2";
$deathMsg[$thompson]	       = "%1[M1A1-Thompson] %2";
$deathMsg[$grenade]	       = "%1[Grenade] %2";
$deathMsg[$m1carbine]	       = "%1[M1-Carbine] %2";
$deathMsg[$mosinnagant]	       = "%1[Mosin-Nagant] %2";
$deathMsg[$sten]	       = "%1[Sten] %2";
$deathMsg[$garand]	       = "%1[M1-Garand] %2";
$deathMsg[$P38]	       = "%1[P38Pistol] %2";
$deathMsg[$M1911]	       = "%1[M1911Pistol] %2";
$deathMsg[$Airstrike]	       = "%1[Airstrike] %2";
$deathMsg[$exppack]	       = "%1[Exppack] %2";
$deathMsg[$MG42]	       = "%1[MG42] %2";
$deathMsg[$Browning]	       = "%1[Browning] %2";
$deathMsg[$Howitzer]	       = "%1[Howitzer MK-II] %2";
$deathMsg[$Pak]	       = "%1[Pak-40] %2";
$deathMsg[$AlliedFighterBomb]	       = "%1[AlliedFighter] %2";
$deathMsg[$AlliedBomberBomb]	       = "%1[AlliedBomber] %2";
$deathMsg[$AxisFighterBomb]	       = "%1[AxisFighter] %2";
$deathMsg[$AxisBomberBomb]             = "%1[AxisBomber] %2";
$deathMsg[$AlliedFighterGun]	       = "%1[AlliedFighter] %2";
$deathMsg[$AxisFighterGun]	       = "%1[AxisFighter] %2";
$deathMsg[$AlliedBomberGun]	       = "%1[AlliedBomber] %2";
$deathMsg[$AxisBomberGun]	       = "%1[AxisBomber] %2";
$deathMsg[$AiMine]	       = "%1[Infantry-Mine] %2";
$deathMsg[$DP]	       = "%1[DP-28] %2";
$deathMsg[$M3]	       = "%1[M3-GreaseGun] %2";
$deathMsg[$Lanchester]	       = "%1[Lanchester-SMG] %2";
$deathMsg[$TreeDamageType]	       = "%1[Tree] %2";
$deathMsg[$PTRD]	       = "%1[PTRD] %2";
$deathMsg[$PIAT]	       = "%1[PIAT] %2";
$deathMsg[$Flak]	       = "%1[Flak] %2";
$deathMsg[$Flakx]	       = "%1[Flak] %2";
$deathMsg[$Bofors]	       = "%1[Bofors] %2";
$deathMsg[$Boforsx]	       = "%1[Bofors] %2";
$deathMsg[$type99]             = "%1[Type99] %2";
$deathMsg[$type100]             = "%1[Type100] %2";
$deathMsg[$type98]             = "%1[Type98] %2";
$deathMsg[$type38]             = "%1[Type38] %2";
$deathmsg[$nambu]              = "%1[Nambu] %2";
$deathmsg[$Shotgun]              = "%1[Shotgun] %2";
$deathMsg[$type4]             = "%1[Type4] %2";
$deathMsg[$type97]             = "%1[Type97] %2";
$deathMsg[$type96]             = "%1[Type96] %2";
$Deathmsg[$ShermanTank]             = "%1[Sherman] %2";
$Deathmsg[$PanzerTank]             = "%1[PanzerIV] %2";
$Deathmsg[$Cactus]             = "%1[Cactus] %2";
$Deathmsg[$TankCrush]             = "%1[Tank-Bumper] %2";
// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2]						 = "%1 killed himself.";


$numDeathMsgs = 4;
//---------------------------------------------------------------------------------



function remotePlayMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   	if(gamebase::getteam(%clientId) < 0) client::setcontrolobject(%clientId, client::getobservercamera(%clientId));
	}
}

function remoteCommandMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
   if(!%clientId.guiLock && !Observer::isObserver(%clientId))
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}

function remoteObjectivesMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}

function remoteScoresOn(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
%mm = %clientId.menumode;
   Client::cancelMenu(%clientId);
%pl = client::getownedobject(%clientId);
if(!(%pl > 8000) || %pl == "" || (%pl > 8000) && player::isdead(%pl)) if(%mm != "chooseclass" && !$loadingMission) { %clientId.choosingclass = 1; game::Spawninterface(%clientId);  }
}

function remoteToggleCommandMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
	if($loadingmission) return;
	Ikey::onUse(%clientId);
	//if (Client::getGuiMode(%clientId) != $GuiModeInventory)
	//	remoteInventoryMode(%clientId);
	//else
	//	remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
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
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = floor(getrandom() * 2);
  // if(%spawnIdx >= %count)
   //   %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Battle starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Battle begin!");
	Game::resetScores();	

   %numTeams = getNumTeams();
   

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn, %location)
{
if($loadingmission) { echo("Console: Late-spawn cancelled."); return false; }
Game::refreshClientScore(%clientId);
 // centerprint(%clientid, "", 1, CLASS);
	 if(!$ghosting)
      return false;
game::refreshclientscore(%clientId);
	Client::clearItemShopping(%clientId);
   %spawnMarker = WWII::PickDropPoint(%clientId, %respawn, %location);
   if(!%respawn)
   {
      // initial drop
      //bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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

		%armor = soldier;
	objectivemission::refreshteamscores();
	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   schedule("WWII::CriminalCheck(" @ %pl @ ");", 1, %pl);   
	echo("SPAWN: " @ client::getname(%clientId) @ " cl:" @ %clientId @ " pl:" @ %pl @ " markergroup: " @ object::getname(getgroup(%spawnMarker)) @ " class: " @ %clientId.spawnclass);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 8, 1, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function WWII::PickDropPoint(%cl, %r, %post)
{
if(string::findsubstr(%post, "Outpost") == -1 && string::findsubstr(%post, "outpost") == -1 && string::findsubstr(%post, "base") == -1) { schedule("net::kick(" @ %cl @ ");", 0); return; } 
if(%post != "base") {
%drops = 0;
%group = NameToID("MissionGroup/" @ %post);
for(%x = 0; Group::GetObject(%group, %x) != -1; %x++)
	{
	%curobj = Group::GetObject(%group, %x);
	if(getword(Object::GetName(%curobj), 0) == "Drop") 
		{
		%drop[%drops] = %curobj;
		%drops++;
		}
	
	}
if(%drops == 0) return Game::pickPlayerSpawn(%cl, %r);
//for(%i = 0; %i < %drops; %i++)
//	{
//	if(%drop[%i].isTaken != 1) 
//		{
//		%drop[%i].isTaken = 1;
//		schedule(%drop[%i] @ ".isTaken = \"\";", 2.5);
//		return %drop[%i];
//		}
//	}
	
for(%i = 0; %i < %drops; %i++)
	{
	%rand = floor(getrandom() * %drops);
	if(%drop[%rand].isbusy != 1) 
		{ 
		%returnid = %drop[%rand];
		%drop[%rand].isbusy = 1;
		schedule(%drop[%rand] @ ".isbusy = 0;", 4);
		break;
		}
	}
return %returnId;
}

else return Game::pickPlayerSpawn(%cl, %r);
}

		



function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	
	
  	WWII::PlayerSetup(%clientID);
	
	
   	%clientId.spawnWeapon="";
	
} 


function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
WWII::CheckMember(%clientId);
%clientId.observermode = "choosingclass";
%clientId.choosingclass = true;	
//Observer::enterObserverMode(%clientId);
	Client::setGuiMode(%clientId, $GuiModePlay);

   %clientId.isreloading = false;
   %clientId.canchangeweapon = true;
   if(True)
   {
	%clientId.airstrikewaittime = 0;
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   
   
   
      Client::setSkin(%clientId, Game::getcustomskin(%clientId));
      if(%clientId.justConnected)
      {
         
	centerprint(%clientId, $welcome, 30, WELCOME);
        if(%clientId.hasTST == 1) schedule("remoteeval(" @ %clientId @ ", makescores);", 4); 
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
        
      }
      else
        {
	
	}
	
	
}

function processMenuInitialPickTeam(%clientId, %team)
{
   

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
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
      //Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}


function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: Timelimit reached.");
      $timeLimitReached = true;
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Game::resetScores(%client)
{
	if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;
		}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
}



function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
   //KOTAROS CODE OVER HERE :-D TY
       if($Game::MissionType == "Conquest") 
    {
    %alliedPeople=0;
    %axisPeople=0;
    for(%cl = client::getfirst(); %cl != -1; %cl = client::getnext(%cl))
    {
      if(gamebase::getteam(%cl) == 0)
      {
       %alliedPeople++;
       if(getword(client::getname(%cl), 0) == "*|BFW|*")
        %alliedPeople+=0.5;
      }
      else if(gamebase::getteam(%cl) == 1)
      {
       %axisPeople++;
       if(getword(client::getname(%cl), 0) == "*|BFW|*")
        %axisPeople+=0.5;
      }
    }
    if(%alliedPeople > %axisPeople)
      gamebase::setteam(%playerId, 1);
    else if(%alliedPeople < %axisPeople)
      gamebase::setteam(%playerId, 0);
    else if($WWII::TeamPoints[Allied] < $WWII::TeamPoints[Axis])
      gamebase::setteam(%playerId, 0);
    else if($WWII::TeamPoints[Allied] > $WWII::TeamPoints[Axis])
      gamebase::setteam(%playerId, 1);
    else gamebase::setteam(%playerId, floor(getrandom()*2));
    }
    else if($Game::MissionType == "Deathmatch") gamebase::setteam(%playerId, $Deathmatch::team);
	else gamebase::setteam(%playerId, 0);
}

function Client::onKilled(%playerId, %killerId, %damageType)
{


	if(%killerId == 0 && %playerid.lastai > 0) { Client::onKilled(%playerId, %playerId.lastai, %damageType); return; }
	else if(%damagetype == $AiMine && !%killerId && client::getname(%killerId) == "") { messageall(3, client::getName(%playerId) @ " exploded on a mine."); $WWII::TeamPoints[getteamname(GameBase::getTeam(%playerId))]--; }
	else if(%damagetype == $TreeDamageType && %killerid > 3000) { client::onKilled(%playerid, %killerid.destroyer, %damagetype); return; }
	else if(%damagetype == $Cactus && %killerid < 2048) { messageall(3, client::getName(%playerId) @ " was stabbed by mother nature."); $WWII::TeamPoints[getteamname(GameBase::getTeam(%playerId))]--; }
	else if(%damagetype == $Electricity && %killerid == 2048) { messageall(3, client::getname(%playerid) @ " was struck by lightning."); return; }
	else if(%killerId == 0 || %type == $Explosion) { messageall(3, client::getName(%playerId) @ " was killed in action."); $WWII::TeamPoints[getteamname(GameBase::getTeam(%playerId))]--; }
	if(%playerId < 2048) return; //EXTREME BUG FIX HERE :D  
	if(%killerId < 2048) return; 
	echo("GAME: kill " @ client::getname(%killerId) @ "(" @ %killerId @ ") " @ client::getname(%playerId) @ "(" @ %playerId @ ")");
   %playerId.guiLock = true;
   Client::setGuiMode(%playerId, $GuiModePlay);
	
      %playerGender = "his";
   
	
	//%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);


	

   if(!%killerId)
   {
      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      %playerId.scoreDeaths++;
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
   }
   else
   {
		
			%killerGender = "his";
		
      if((Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
		
	    	messageAll(0, strcat(Client::getName(%killerId), " killed his teammate, ", %victimName), $DeathMessageMask);
		
		 
       %killerId.score -= 2;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
	Stats::Kill(%playerId, %killerId);
if(%playerId.targetbeacon > 0 && GameBase::GetDataName(%playerId.targetbeacon) == "ATB") { if(gamebase::getdataname(%playerid.targetbeacon) == "ATB") deleteobject(%playerId.targetbeacon); %playerid.targetbeacon = ""; }
}



function Client::leaveGame(%clientId)
{
if($Vote::CurVoteStatus == "voting" && $Vote::CurvoteClient == %clientId)
	{
	$Vote::CurVoteStatus = "failed"; 
	votesystem::votefailed();
	messageall(1, client::Getname(%clientId) @ "'s vote was cancelled due to his departure from the game.");
	}
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

function Game::CheckTeams()
{
if(!Game::TeamsEven()) Game::ReassignTeams();
}

function Game::TeamsEven()
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	if(GameBase::GetTeam(%cl) == 0) %team0++;
	else %team1++;
if($Game::MissionType == "Deathmatch" && %team[$Deathmatch::Team] != getnumclients()) Deathmatch::Assignteams();
%diff = %team1 - %team0;
if(%diff*%diff == 1) return true;
return false;
}

function Game::ReassignTeams()
{
%curteam = floor(getrandom()*2);
%teamscore1 = 0;
%teamscore0 = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	gamebase::setteam(%cl, %curteam);
	%name = client::getname(%cl);
	%teamscore[%curteam]++;
	if(getword(%name, 0) == "*|BFW|*") %teamscore[%curteam] += 0.5;
	if(%teamsccore[%curteam] > %teamscore[!%curteam])
		%curteam = !%curteam;
	}
MessageAll(1, "Teams were reset due to non-fair teams set.");
} 

function Game::GetCustomSkin(%cl)
{
%t = gamebase::getteam(%cl);
%c = $country[%t];
if(%c == "Russia") return beagle;
else if(%c == "German") return dsword;
else if(%c == "US") return green;
else if(%c == "British") return swolf;
else if(%c == "Japan") return cphoenix;
}

function WWII::CriminalCheck(%player)
{
%cl = player::getclient(%player);
if(%cl.jailed) jail(%cl, 2048, 1);
if(%cl.frozen) freeze(%cl, 2048, 1);

}