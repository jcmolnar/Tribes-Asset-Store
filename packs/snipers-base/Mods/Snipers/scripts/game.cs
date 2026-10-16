exec("comchat.cs");
exec("deathmsg.cs");
exec("spawn.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;


//  Global Variables

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0] = $DefaultTeamEnergy; 
$TeamEnergy[1] = $DefaultTeamEnergy; 
$TeamEnergy[2] = $DefaultTeamEnergy; 
$TeamEnergy[3] = $DefaultTeamEnergy; 
$TeamEnergy[4] = $DefaultTeamEnergy; 
$TeamEnergy[5] = $DefaultTeamEnergy; 
$TeamEnergy[6] = $DefaultTeamEnergy; 				
$TeamEnergy[7] = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 1000000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 1000000; 
$RemoteInvEnergy = 1000000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth = 50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth = 10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType = 1 << 1;
$SimInteriorObjectType = 1 << 2;
$SimPlayerObjectType = 1 << 7;
$MineObjectType = 1 << 26;	
$MoveableObjectType = 1 << 22;
$VehicleObjectType = 1 << 29;  
$StaticObjectType = 1 << 23;	   
$ItemObjectType = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
// END

function remotePlayMode(%clientId) 
{
  if(!%clientId.guiLock) 
  {
    remoteSCOM(%clientId, -1);
    Client::setGuiMode(%clientId, $GuiModePlay);
  }
}

function remoteCommandMode(%clientId) 
{
  if(!%clientId.guiLock) 
  {
    remoteSCOM(%clientId, -1);
    if(%clientId.observerMode != "pregame") checkControlUnmount(%clientId);
    Client::setGuiMode(%clientId, $GuiModeCommand);
  }
}

function remoteInventoryMode(%clientId) 
{
	if(!%clientId.guiLock && !Observer::isObserver(%clientId)) 
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeInventory);
	}
}

function remoteObjectivesMode(%clientId) 
{
  if(!%clientId.guiLock) 
  {
    remoteSCOM(%clientId, -1);
    Client::setGuiMode(%clientId, $GuiModeObjectives);
  }
}

function remoteScoresOn(%clientId) 
{
  if(!%clientId.menuMode) Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId) 
{
  Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId) 
{
  if (Client::getGuiMode(%clientId) != $GuiModeCommand) remoteCommandMode(%clientId);
  else remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId) 
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory) remoteInventoryMode(%clientId);
	else remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId) 
{
  if (Client::getGuiMode(%clientId) != $GuiModeObjectives) remoteObjectivesMode(%clientId);
  else remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime) 
{
  return floor(%simTime / 60);
}

function Time::getSeconds(%simTime) 
{
  return %simTime % 60;
}

function Client::onKilled(%playerId, %killerId, %damageType) 
{
  %victimName = Client::getName(%playerId);
  reportKill(%killerId, %playerId, %damageType);
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
  if(!%killerId) 
  {
    messageAll(0, strcat(%victimName, " dies."));
    %playerId.scoreDeaths++;
  }
  else if(%killerId == %playerId) 
  {
if(%damageType == $LandingDamageType)
		{
			if (%killedflag)
			{
				%playerId.score = (%playerId.score - $Score::FlagDef);
				if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide.",3);  
			}
			%oopsMsg = sprintf($deathMsg[%damageType, %ridx], 0, %victimName, 0, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
			echo("AC:DEATH: " @ %oopsMsg);
			echo("*** Falling Death");
			return;
			}
		else if (%killedflag)
		{
			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
			echo("AC:DEATH: " @ %oopsMsg);
			echo("*** Suicide Death");
			%playerId.score = (%playerId.score - $Score::FlagDef);
			if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide.",3);  
		}
		else
		{
			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
			messageAll(0, %oopsMsg, $DeathMessageMask);
			echo("AC:DEATH: " @ %oopsMsg);
			echo("*** Suicide Death");
			%playerId.score--;
			if ($ScoreOn) bottomprint(%playerId,"Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);
		}

		Game::refreshClientScore(%playerId);
		return;
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
      bottomprint(%playerId, "<jc><f1>You have just been\n<f2>TEAM KILLED <f1>by<f2> " @ Client::getName(%killerId), 10);
      if(%killerId != %playerId) bottomprint(%killerId, "<jc><f2>YOU<f1> have just <f2>TEAM KILLED\n " @ Client::getName(%playerId), 10);
      Insomniax_setTeamKill(%playerId, %killerId);
      messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
      %killerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%killerId);
    }
    else 
    {
      %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender);
      messageAll(0, %obitMsg);
      %killerId.scoreKills++;
      %playerId.scoreDeaths++;
      %killerId.score++;
      Game::refreshClientScore(%killerId);
      Game::refreshClientScore(%playerId);
    }
  }
  Game::clientKilled(%playerId, %killerId);
}

function CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant)
{
	if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType)
	{
		%ppos = %playerid.TKDeathPos;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
			{
				if(%cl != %playerId && %cl != %killerId)
				{
					%pppos = GameBase::getPosition(%cl);
					%dist = Vector::getDistance(%ppos,%pppos);
					if ($debug) echo("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId) @ " Prox = " @ $SHAntiTeamKillProximity);

					if(%dist < $SHAntiTeamKillProximity)
					{
						if ($debug) echo("***Player "@ Client::getName(%playerId) @" was close, kill is accidental.");
						Client::sendMessage(%killerId, 0, "You team killed...");
						return;
					}
				}
			}
		}

	        messageAll(0, "***" @ Client::getName(%killerId) @ " TeamKilled***");

  		$killedflagcarry = "False";		 //== Reset
		%playerId.lastkillpos = -1;		 //== Reset
		$killedarmor = -1;			 //== Reset		   		
	   		
		%score = (Scoring::killpoints(%playerId, %killerId, %vertPos,%quadrant));

		if ($Shifter::JustSpawned[%playerId] == "false")
		{
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Player Team Killed - Deducting Points");
		}
		else
		{
			%score = floor(%score / 2);
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Team Kill - But Killed Player Just Spawned - Possible Accident - Points Deducted Halved");
		}
	
		//====================================== Refresh Scores
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);

		if (%killedflag)
		{
			if ($ScoreOn) centerprint(%killerId, "You Team Killed The Flag Runner! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
			messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
		}
		else
		{
			if ($ScoreOn) bottomprint(%killerId, " You Team Killed! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
		}

		$Shifter::LastTker = (Client::getName(%killerId));
		$Shifter::LastTKed = (Client::getName(%playerId));
		$Shifter::LastTKno = (%killerid.TKCount + 1);

		if(%killerid.TKCount == "")
		{
			%killerid.TKCount = 1;
		}
		else
		{
			%killerid.TKCount = %killerid.TKCount + 1;

			//============================================================================== Server Terminates Team Killer

			if (%killerid.TKCount > $Shifter::KillTerm)
			{
				if ($Shifter::KillTerm > "1")
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than " @ $Shifter::KillTerm @ " Times.",5);
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
				else
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than 1 Time.", 5); 
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
			}

			if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
			{
				%clientId = %killerId;
				%addr = Client::getTransportAddress(%killerId);
				%name = Client::getName(%clientId);
				
				if ($Server::Admin["noban", %name] && %clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}		
				else if (%clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}

				bottomprintall("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling", 5); 

				%ip = Client::getTransportAddress(%killerId);
				BanList::add(%ip, $SHAntiTeamKillBanTime);      //=== Add Player To BanList
				shban(%ip);
				%killer = Client::getOwnedObject(%killerId);
				messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
				KickPlayer(%killerId,"***" @ $Shifter::TeamKillMsg @ "***");
			}
			else
			{
				if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
				{
					centerprint(%killerId, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kicked and banned.", 10);
				}	
			}
		}		
    	}
}

function Game::clientKilled(%playerId, %killerId) 
{
}

function Client::leaveGame(%clientId) 
{
}

function Player::enterMissionArea(%player) 
{
  // Useless waste of CPU
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Entered the mission area.");
}

function Player::leaveMissionArea(%player) 
{
  // Useless waste of CPU
  //report(Player::getClient(%player), $CatPlayerData, "AREA", "Left the mission area.");
}

function GameBase::getHeatFactor(%this) 
{
  return 0.0;
}
