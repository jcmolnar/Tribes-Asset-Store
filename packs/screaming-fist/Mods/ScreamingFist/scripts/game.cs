echo("Loading Screaming Fist Version");
//  Global Variables
exec("comchat.cs");
$AttackGameType = FALSE;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

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
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

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
$MaxNumTurretsInBox = 5;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 25;    //Define Max Length of the area
$TurretBoxMaxWidth =  25;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 3;	  //Define Min Length from another turret
$TurretBoxMinWidth =  3;	  //Define Min Width from another turret
$TurretBoxMinHeight = 3;    //Define Min Height from another turret

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
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";

//*************************************************************************************************************
// SF Addition - Begin - 6/13/99 - 11:00PM
//*************************************************************************************************************
$deathMsg[$MinigunDamageType, 0]	       = "%1 gooifies %2.";
$deathMsg[$MinigunDamageType, 1]	       = "%2 is pureed to the fine texture of Baby Food by %1.";
$deathMsg[$MinigunDamageType, 2]	       = "%1 gives %2 a second helping of Lead.";
$deathMsg[$MinigunDamageType, 3]	       = "%2 is whipped to a creamy frappe by %1.";
$deathMsg[$AssRifleDamageType, 0]	       = "%1 shoots %2.";
$deathMsg[$AssRifleDamageType, 1]	       = "%2 Askes %1 for another!";
$deathMsg[$AssRifleDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$AssRifleDamageType, 3]	       = "%2 filled with holes by %1.";
$deathMsg[$SilencedAssRifleDamageType, 0]	       = "%1 shoots %2.";
$deathMsg[$SilencedAssRifleDamageType, 1]	       = "%2 Askes %1 for another!";
$deathMsg[$SilencedAssRifleDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$SilencedAssRifleDamageType, 3]	       = "%2 filled with holes by %1.";
$deathMsg[$FlamerDamageType, 0]            = "%2 fuels %1's fire.";
$deathMsg[$FlamerDamageType, 1]            = "%1 gives %2 a bad sunburn.";
$deathMsg[$FlamerDamageType, 2]            = "%1, the pyro, burns  %2 real good";
$deathMsg[$FlamerDamageType, 3]            = "%1 roasts %2's flesh.";
$deathMsg[$GlockDamageType, 0]            = "%1 caps %2.";
$deathMsg[$GlockDamageType, 1]            = "%1 shoots %2.";
$deathMsg[$GlockDamageType, 2]            = "%1 shoots %2 real good.";
$deathMsg[$GlockDamageType, 3]            = "%1 pokes several holes in %2's flesh.";
$deathMsg[$SilencedGlockDamageType, 0]            = "%1 caps %2.";
$deathMsg[$SilencedGlockDamageType, 1]            = "%1 shoots %2.";
$deathMsg[$SilencedGlockDamageType, 2]            = "%1 shoots %2 real good.";
$deathMsg[$SilencedGlockDamageType, 3]            = "%1 pokes several holes in %2's flesh.";
$deathMsg[$SniperRifleDamageType, 0]    = "%1 blows %2's head off.";
$deathMsg[$SniperRifleDamageType, 1]    = "%2 saw %1 a second too late.";
$deathMsg[$SniperRifleDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$SniperRifleDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$LightningDamageType, 0] = "%2 gets zapped by the lightning.";
$deathMsg[$LightningDamageType, 1] = "%2 sees the fire in the sky.";
$deathMsg[$LightningDamageType, 2] = "%2 doesnt get along with Zeus.";
$deathMsg[$LightningDamageType, 3] = "%2 meets Gods fury!";
$deathMsg[$MAWAssRifleDamageType, 0]	       = "%1 shoots %2.";
$deathMsg[$MAWAssRifleDamageType, 1]	       = "%2 Askes %1 for another!";
$deathMsg[$MAWAssRifleDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$MAWAssRifleDamageType, 3]	       = "%2 filled with holes by %1.";
$deathMsg[$MAWIncendiaryRifleDamageType, 0]	       = "%1 bursts %2 with his MAW.";
$deathMsg[$MAWIncendiaryRifleDamageType, 1]	       = "%2 gets 'sploded by %1's MAW!";
$deathMsg[$MAWIncendiaryRifleDamageType, 2]	       = "%1 burns %2 with his MAW";
$deathMsg[$MAWIncendiaryRifleDamageType, 3]	       = "%2 goes boom from %1's MAW.";
$deathMsg[$MAWGrenadeLauncherDamageType, 0]	       = "%1 'nades %2.";
$deathMsg[$MAWGrenadeLauncherDamageType, 1]	       = "%2 eats %1's pinapple!";
$deathMsg[$MAWGrenadeLauncherDamageType, 2]	       = "%1 hucks a 'nade at %2.";
$deathMsg[$MAWGrenadeLauncherDamageType, 3]	       = "%2 gets 'sploded by by %1's MAW.";
$deathMsg[$OspreyTurretDamageType, 0]	       = "%1 perforates %2 with lead.";
$deathMsg[$OspreyTurretDamageType, 1]	       = "%1 shoots %2.";
$deathMsg[$OspreyTurretDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$OspreyTurretDamageType, 3]	       = "%1 fills %2 with holes.";
$deathMsg[$ComancheBulletDamageType, 0]	       = "%1 perforates %2 with lead.";
$deathMsg[$ComancheBulletDamageType, 1]	       = "%1 shoots %2.";
$deathMsg[$ComancheBulletDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$ComancheBulletDamageType, 3]	       = "%1 fills %2 with holes.";
$deathMsg[$ComancheImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ComancheImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ComancheImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ComancheImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$ShotgunDamageType, 0]	       = "%1 perforates %2 with lead.";
$deathMsg[$ShotgunDamageType, 1]	       = "%1 shoots %2.";
$deathMsg[$ShotgunDamageType, 2]	       = "%1 gives %2 another dose of Lead.";
$deathMsg[$ShotgunDamageType, 3]	       = "%1 fills %2 with holes.";
$deathMsg[$BigCannonDamageType, 0]	       = "%1 splatters %2.";
$deathMsg[$BigCannonDamageType, 1]	       = "%1 kills %2.";
$deathMsg[$BigCannonDamageType, 2]	       = "%1 gives %2 a 30mm gift of hot love.";
$deathMsg[$BigCannonDamageType, 3]	       = "%1 fills %2 with one BIG hole.";
$deathMsg[$HomingFlareDamageType, 0]	       = "%1 destroys %2's rocket.";
$deathMsg[$HomingFlareDamageType, 1]	       = "%1 destroys %2's rocket.";
$deathMsg[$HomingFlareDamageType, 2]	       = "%1 destroys %2's rocket.";
$deathMsg[$HomingFlareDamageType, 3]	       = "%1 destroys %2's rocket.";
$deathMsg[$HowitzerDamageType, 0]	       = "%1 kills %2.";
$deathMsg[$HowitzerDamageType, 1]	       = "%1 kills %2.";
$deathMsg[$HowitzerDamageType, 2]	       = "%1 kills %2.";
$deathMsg[$HowitzerDamageType, 3]	       = "%1 kills %2.";
$deathMsg[$FBWMissleDamageType, 0]	       = "%1 flys a rocket up %2's keister.";
$deathMsg[$FBWMissleDamageType, 1]	       = "%1 flys a rocket up %2's keister.";
$deathMsg[$FBWMissleDamageType, 2]	       = "%1 flys a rocket up %2's keister.";
$deathMsg[$FBWMissleDamageType, 3]	       = "%1 flys a rocket up %2's keister.";
$deathMsg[$FlashDamageType, 0]	       = "%1 knocks %2 silly.";
$deathMsg[$FlashDamageType, 1]	       = "%1 knocks %2 silly.";
$deathMsg[$FlashDamageType, 2]	       = "%1 knocks %2 silly.";
$deathMsg[$FlashDamageType, 3]	       = "%1 knocks %2 silly.";

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

//*************************************************************************************************************
// SF Addition - Begin - 5/31/99 - 1:30AM
//*************************************************************************************************************

$spawnBuyList[0] = Infantry;
$spawnBuyList[1] = Glock;
$spawnBuyList[2] = AssRifle;
$spawnBuyList[3] = RepairKit;
$spawnBuyList[4] = "";
$spawnBuyList[5] = "";

//*************************************************************************************************************
// SF Additions - End
//*************************************************************************************************************

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
	if(!%clientId.menuMode)
		Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
	Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
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
	%spawnIdx = %client.lastObserverSpawn + 1;
	if(%spawnIdx >= %count)
		%spawnIdx = 0;
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
	messageAll(0, "Match starts in " @ %time @ " seconds.");
	UpdateClientTimes(%time);
}

function Game::startMatch()
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();
	
	if( $AttackGameType == true )
		DefensePoints();	
	
	//*****************************************************************
	//  SF ADDITION FOR BOTS 
	//*****************************************************************
	AI::ProcessAutoSpawn();
	//*****************************************************************
	//
	//*****************************************************************
	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}
	
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

function Game::playerSpawn(%clientId, %respawn)
{
	if(!$ghosting)
		return false;
	
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn)
	{
		// initial drop
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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
		//*************************************************************************************************************
		// SF Addition - Begin - 8/7/00 - 3:30PM
		//*************************************************************************************************************
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
		{
			if($Game::missionType == "Assassination")
			{
				if($Hunted == %clientId)
				{
					%armor = "imale";
				}
				else if (Client::getTeam(%clientId) == 0)
				{
					//Bodyguard
					%armor = "imale";
				}
				else 
				{
					//Assassin
					%armor = "somale";
				}
				
			}
			else
			{
				%armor = "imale";
			}
		}
		else
		{
			if($Game::missionType == "Assassination")
			{
				if($Hunted == %clientId)
				{
					%armor = "ifemale";
				}
				else if (Client::getTeam(%clientId) == 0)
				{
					//Bodyguard
					%armor = "ifemale";
				}
				else 
				{
					//Assassin
					%armor = "sofemale";
				}
				
			}
			else
			{
				%armor = "ifemale";
			}
		}
		
		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		$RemDet[%clientId] = FALSE;
		if($Game::missionType == "Assassination")
		{
			echo(Client::getTeam(%clientId));
			if($Hunted == %clientId)
			{
				Player::mountItem(%pl, Flag, 2);
			}
			else if (Client::getTeam(%clientId) == 0)
			{
				//Bodygaurd: Give Assault Rifle
				Player::incItemCount(%pl, AssRifle, 1);
				Player::incItemCount(%pl, AssRifleAmmo, 120);
			}
			else 
			{
				//Assassin: Give Sniper Rifle
				Player::incItemCount(%pl, SniperRifle, 1);
				Player::incItemCount(%pl, SniperRifleAmmo, 10);
			}
			
		}
		//*************************************************************************************************************
		// SF Additions - End
		//*************************************************************************************************************
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
				Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
			}
		}
		return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
		return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
	//Assassination code
	if($Game::missionType != "Assassination")
	{
		for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
		{
			buyItem(%clientId,%item);	
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
		}
	}
	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
		%clientId.spawnWeapon="";
	}
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
	
	if($Server::TourneyMode)
		GameBase::setTeam(%clientId, -1);
	else
	{
		if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
		{
			%clientId.observerMode = "observerOrbit";
			%clientId.guiLock = "";
			Observer::jump(%clientId);
			return;
		}
		%numTeams = getNumTeams();
		%curTeam = Client::getTeam(%clientId);
		
		if((%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams))) && $Game::missionType != "Assassination" ) // SF MODIFICATION
			Game::assignClientTeam(%clientId);
	}    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
		GameBase::getRotation(%camSpawn), true, true);
	
	if(Client::getTeam(%clientId) == -1)
	{
		%clientId.observerMode = "pickingTeam";
		
		if($Server::TourneyMode && ($matchStarted || $matchStarting))
		{
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode)
		{
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		// SF ADDITION
		if ($Game::missionType == "Assassination") {
			Client::addMenuItem(%clientId, "1Bodyguards", 0);
			Client::addMenuItem(%clientId, "2Assassins", 1);
			Client::addMenuItem(%clientId, "3VIP", 2);
		} else {
			// END SF ADDITION
			Client::addMenuItem(%clientId, "1Automatic", -1);
			for(%i = 0; %i < getNumTeams(); %i = %i + 1)
				Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		%clientId.justConnected = "";
	}
	else 
	{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		if(%clientId.justConnected)
		{
			centerprint(%clientId, $Server::JoinMOTD, 0);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
		}
		else
			Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
	if($Server::TourneyMode && $matchStarted)
		%team = -2;
	
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
		// SF ADDITION
		// -----by Enigma-----
		if ($Game::missionType == "Assassination") {
			if(%team == 0) {
				if ($Hunted == 0) { // No VIP yet...
					$Hunted = %clientId;
					remoteEval(%clientId, CP, "<jc><f0>You are the VIP!", 4);
				}
			} else if(%team == 1) {
				if ( getNumTeamPlayers(1) > (0.5*getNumTeamPlayers(0)) ) {
					remoteEval(%clientId, CP, "<jc><f0>Too many Assassins. You are now a Bodyguard.", 4);
					%team = 0;
				}
			} else if(%team == 2) {
				%team = 0;
				if ($HuntedQueue != 0) {
					$HuntedQueue++;
					$HuntedList[$HuntedQueue-1] = %clientId;
					remoteEval(%clientId, CP, "<jc><f0>You are #"@$HuntedQueue@" in line to be the VIP. You are now a Bodyguard.", 4);
				} else {
					$Hunted = %clientId;
					remoteEval(%clientId, CP, "<jc><f0>You are the VIP!", 4);
				}
			}		
		}
		// END SF ADDITION
		GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
		%clientId.teamEnergy = 0;
		Client::setControlObject(%clientId, -1);
		Game::playerSpawn(%clientId, false);
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
		if( $AttackGameType == TRUE )
		{
			$DefendersWin = true;
		}
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

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
		Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
		Player::setArmor(%player, %armorType);
	}
}

function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.justConnected = true;
	$menuMode[%playerId] = "None";
	$Sound[%playerId] = "ON";
	Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
	if($teamplay)
	{
		%name = Client::getName(%playerId);
		%numTeams = getNumTeams();
		if($teamPreset[%name] != "")
		{
			if($teamPreset[%name] < %numTeams)
			{
				GameBase::setTeam(%playerId, $teamPreset[%name]);
				echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
				return;
			}            
		}
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;
		
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);
			if(%pl != %playerId)
			{
				%team = Client::getTeam(%pl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}
		%leastPlayers = %numTeamPlayers[0];
		%leastTeam = 0;
		for(%i = 1; %i < %numTeams; %i = %i + 1)
		{
			if( (%numTeamPlayers[%i] < %leastPlayers) || 
				( (%numTeamPlayers[%i] == %leastPlayers) && 
				($teamScore[%i] < $teamScore[%leastTeam] ) ))
			{
				%leastTeam = %i;
				%leastPlayers = %numTeamPlayers;
			}
		}
		GameBase::setTeam(%playerId, %leastTeam);
		echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
	}
	else
	{
		GameBase::setTeam(%playerId, 0);
	}
}

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
		%playerId.scoreDeaths++;
		%playerId.score--;
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
			%killerId.scoreKills++;
			%playerId.scoreDeaths++;  // test play mode
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
		}
	}
	Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
	// SF ADDITION
	// -----by Enigma-----
	// Team 0 = Bodyguards/VIP
	// Team 1 = Assassins
	if($Game::missionType == "Assassination") {
		if(%playerId == $Hunted) {
			%killerName = Client::getName(%killerId);
			for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i)) {
				remoteEval(%i, CP, "<jc><f0>The VIP was assassinated by " @ %killerName, 4);
				//if (%i != $Hunted) {
				Player::kill(%i);
				//}
			}
			$teamScore[1] += 1;
		}
	}
	// END SF ADDITION
}

function Client::leaveGame(%clientId)
{
	// SF ADDITION
	// -----by Enigma-----
	if($Game::missionType == "Assassination") {
		if($Hunted == %clientId) {
			if ($HuntedQueue == 0) {
				%h = Client::getFirst();
				while((GameBase::getTeam(%h) != 0) || (%h != -1)) {
					%h = Client::getNext(%h);
				}
				if (%h == -1) {
					$Hunted = 0;
				} else {
					Player::kill(%h);
					$Hunted = %h;
					remoteEval(%h, CP, "<jc><f0>You are now the VIP!", 4);
				}
			} else {
				%h = $HuntedList[0];
				for (%i = 0; %i < $HuntedQueue-1; %i++) {
					$HuntedList[%i] = $HuntedList[%i+1];
				}
				$HuntedQueue--;
				Player::kill(%h);
				$Hunted = %h;
				remoteEval(%h, CP, "<jc><f0>You are now the VIP!", 4);
			}
		}
	}
	// END SF ADDITION
}

// SF ADDITION
function Player::enterMissionArea(%player)
{
	//echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
	//echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
	return 0.0;
}

function String::len(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;
	return %length;
}