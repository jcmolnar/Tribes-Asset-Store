if($BaseMode){
$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";
}

if(!$BaseMode){
//$spawnBuyList[0] = ScoutArmor;
//$spawnBuyList[0] = SpyArmor;
//$spawnBuyList[0] = SniperArmor;
$spawnBuyList[0] = MercenaryArmor;
//$spawnBuyList[0] = EngineerArmor;
//$spawnBuyList[0] = FlagMoverArmor;
//$spawnBuyList[0] = BursterArmor;
//$spawnBuyList[0] = DragArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Beacon;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = TargetingLaser;
$spawnBuyList[8] = EnergyPack;
//$spawnBuyList[8] = DeployableInvPack;
$spawnBuyList[9] = "";
$spawnBuyList[10] = "";
}



function Nappy::getName(%clientId)
{
	return %clientId.NameTagBefore @ Client::getName(%clientId) @ %clientId.NameTagAfter;
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
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5); 
	if(%spawnMarker || (%clientId.observerMode == "" &&  Client::getTeam(%clientId) == "-1")) {   

		if(%clientId.NappyDuel != "duel"){
			%clientId.game = "CTF";
			Game::refreshClientScore(%clientId);
		}

		%clientId.guiLock = "";
		%clientId.dead = "";
		if(%spawnMarker == -1){
			%spawnPos = "0 0 300";
			%spawnRot = "0 0 0";
		}
		else{
			%spawnPos = GameBase::getPosition(%spawnMarker);
			%spawnRot = GameBase::getRotation(%spawnMarker);
		}
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "mercarmor";
		else
			%armor = "mercfemale";

//""""""""""""""""""""""""""""""DUEL"TEAM"SPAWN"""""""""""""""""""""""""""""""""""""
	if((%clientId.observerMode == "" || %clientId.observerMode == "dead") &&  Client::getTeam(%clientId) == "-1"){
		if(%clientId.NappyDuel != "duel"){
			Nappy::DuelPit::onEnter(%clientId);
			Nappy::DuelPit::Messages(%clientId, enter);
		}
		%spawnPos = Nappy::Duel::PickSpawnPoint(%clientId, pos);
		%spawnRot = Nappy::Duel::PickSpawnPoint(%clientId, rot);
	}
	else if((Client::getTeam(%clientId) == "0" || Client::getTeam(%clientId) == "1") && %clientId.NappyDuel == "duel"){
		%spawnPos = Nappy::Duel::PickSpawnPoint(%clientId, pos);
		%spawnRot = Nappy::Duel::PickSpawnPoint(%clientId, rot);
		if(%clientId.DuelType = "1on1")
			Nappy::Duel::SpawnReset(%clientId);
	}
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
		if(%clientId.game == "Duel")
			%clientId.canSuicide = 0;
		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		//echo("SPAWN:" @ Nappy::getName(%clientId) @ "|| cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		if(%pl != -1){
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
			if(%clientId.NappyDuel == "duel"){
				%clientId.observerMode = "";
				%pl.dueling = true;
				schedule("Nappy::Pit::Boundary(" @ %clientId @ ");", 5);
			}
			if($Nappy::respawnInvulnerableTime && %respawn){
				GameBase::setEnergy(%pl, 90);
				GameBase::setAutoRepairRate(%pl, 2);
				%pl.shieldStrength = 0.99;
				%pl.invulnerable = true;
				schedule("incInvulnerable(" @ %pl @ ", 0);", 0, %pl);
			}
			if($matchStarted){
				if(%clientId.froze != 0) {			
					Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
					Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
				}
				else 
					Client::setControlObject(%clientId, %pl);
			}
			else{
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
	else{
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




function Game::playerSpawned(%pl, %clientId, %armor)
{

//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	if($Nappy::PersonalSkins)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]); //personal skin
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
	%player = Client::getOwnedObject(%clientId);
	%client = Player::getClient(%player);
	$Client[%client, Nappy:stopLag] = 0;
	%clientId.spawn = 1;
	%max = getNumItems();
	%team = Client::getTeam(%client);
	if(%client.NappyDuel != "duel"){
		for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++){
			buyItem(%clientId,%item);	
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
		}
	}
	else{
		Nappy::Duel::SpawnSupply(%clientId);
	}
	%clientId.spawn = "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon = "";
	}
} 





function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}





function incInvulnerable(%player, %time)
{
	if(%time > $Nappy::respawnInvulnerableTime){
		%player.invulnerable = "";
		GameBase::setAutoRepairRate(%player, 0);
		%player.shieldStrength = 0.0;
	}
	else{
		%t2 = %time * 2;
		if(%t2 & 2){
			if((%t2) & 1)
				%vec = "0 -1 0";
			else
				%vec = "0 1 0";
		}
		else{
			if((%t2) & 1)
				%vec = "1 0 0";
			else
				%vec = "-1 0 0";
		}
		GameBase::activateShield(%player,%vec, 0);
		schedule("incInvulnerable(" @ %player @ ", "@ %time + 0.5 @ ");", 0.5, %player);
	}
}




function onServerGhostAlwaysDone()
{

}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
	if($Server::TourneyMode)
		GameBase::setTeam(%clientId, -1);
	else{
		if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit"){
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
	if(Client::getTeam(%clientId) == -1){
		%clientId.observerMode = "pickingTeam";
		if($Server::TourneyMode && ($matchStarted || $matchStarting)){
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode){
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		%clientId.justConnected = "";
	}
	else{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
		if(%clientId.justConnected){
			if(getWord(%clientId.tag, 0) == "rejected"){
				%tag = getWord(%clientId.tag, 1);
				centerprint(%clientId,"<f2>" @ %tag @ "<f0> is password protected.\nTake the tag off your name and come back.\nYour tag will be added to your name when you use your password.", 0);
			}
			else
				centerprint(%clientId, $Server::JoinMOTD, 0);
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined"){
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







function Game::assignClientTeam(%playerId)
{
	if($teamplay){
		%name = Nappy::getName(%playerId);
		%numTeams = getNumTeams();
		if($teamPreset[%name] != ""){
			if($teamPreset[%name] < %numTeams){
				GameBase::setTeam(%playerId, $teamPreset[%name]);
				//echo(Nappy::getName(%playerId), " was preset to team ", $teamPreset[%name]);
				return;
			}
		}
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;

		for(%i = 0; %i < %numPlayers; %i = %i + 1){
			%pl = getClientByIndex(%i);
			if(%pl != %playerId){
				%team = Client::getTeam(%pl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}
		%leastPlayers = %numTeamPlayers[0];
		%leastTeam = 0;
		for(%i = 1; %i < %numTeams; %i = %i + 1){
			if((%numTeamPlayers[%i] < %leastPlayers) || ((%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam]))){
				%leastTeam = %i;
				%leastPlayers = %numTeamPlayers;
			}
		}



		%leastTeam = Nappy::Team::LowPlayerCount();

		GameBase::setTeam(%playerId, %leastTeam);
		//echo(Nappy::getName(%playerId), " was automatically assigned to team ", %leastTeam);
	}
	else{
		GameBase::setTeam(%playerId, 0);
	}
}






function Game::startMatch()
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();	
	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.observerMode == "pregame"){
			if(%cl.froze != 0) {			
				Client::setControlObject(%cl, Client::getObserverCamera(%cl));
				Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
			} 
			else{
				%cl.observerMode = "";
				Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			}
		}
		Game::refreshClientScore(%cl);
	}
	Game::checkTimeLimit();
}






function Client::onKilled(%playerId, %killerId, %damageType)
{
	$Client[%playerId, Nappy:stopLag] = 1;

	//echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male")){
		%playerGender = "his";
	}
	else{
		%playerGender = "her";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Nappy::getName(%playerId);

	if(%playerId.usingThis){
		%playerId.usingThis.beingUsed--;
		%playerId.usingThis = "";
	}

	if(!%killerId){

		//messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		Nappy::Chat::CTFMessageAll(0, strcat(%victimName, " dies."));
		%playerId.scoreDeaths++;
	}
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	else if(%killerId.game == "Duel"){
		Nappy::Duel::Death(%playerId, %killerId, %damageType);
	}
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	else if(%killerId == %playerId){
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);

		//messageAll(0, %oopsMsg, $DeathMessageMask);
		Nappy::Chat::CTFMessageAll(0, %oopsMsg);

		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else{
		if(!String::ICompare(Client::getGender(%killerId), "Male")){
			%killerGender = "his";
		}
		else{
			%killerGender = "her";
		}
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId))){
			if(%damageType != $MineDamageType){
				Nappy::Chat::CTFMessageAll(0, strcat(Nappy::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName));
				//messageAll(0, strcat(Nappy::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			}
			else{
				Nappy::Chat::CTFMessageAll(0, strcat(Nappy::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."));
				//messageAll(0, strcat(Nappy::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			}
			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);
		}
		else{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Nappy::getName(%killerId), %victimName, %killerGender, %playerGender);

			Nappy::Chat::CTFMessageAll(0, %obitMsg);
			//messageAll(0, %obitMsg, $DeathMessageMask);

			%killerId.scoreKills++;
			%playerId.scoreDeaths++;  // test play mode
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
		}
	}
	Game::clientKilled(%playerId, %killerId);
}













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

$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";

$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";

$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";

$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";

$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";

$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";

$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";

$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";

$deathMsg[$ElectricityDamageType, 0]	= "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1]	= "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] 	= "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] 	= "%1 short-circuits %2's systems.";

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

$deathMsg[$MineDamageType, 0]		= "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]		= "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]		= "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]		= "%2 never saw it coming from %1.";

$deathMsg[$PoisonDamageType, 0]		= "%2 dies of poisoning."; 
$deathMsg[$PoisonDamageType, 1]		= "%2 gets a lethal injection."; 
$deathMsg[$PoisonDamageType, 2] 	= "%2 falls victim to a deadly virus."; 
$deathMsg[$PoisonDamageType, 3] 	= "%2 could not find the vaccine in time."; 

$deathMsg[$FireDamageType, 0] 		= "%2 bursts into flames thanks to %1."; 
$deathMsg[$FireDamageType, 1] 		= "%1 gives %2 a white-hot plasma injection."; 
$deathMsg[$FireDamageType, 2] 		= "%1 asks %2, 'Need a light?'"; 
$deathMsg[$FireDamageType, 3] 		= "%1 lights %2 on fire."; 

$deathMsg[$FlashDamageType, 0] 		= "%1 blows %2 up real good."; 
$deathMsg[$FlashDamageType, 1] 		= "%2 gets a taste of %1's explosive temper."; 
$deathMsg[$FlashDamageType, 2] 		= "%1 gives %2 a fatal concussion."; 
$deathMsg[$FlashDamageType, 3] 		= "%1 shocks the hell out of %2."; 

$deathMsg[$SniperDamageType, 0] 	= "%1 picks off %2."; 
$deathMsg[$SniperDamageType, 1] 	= "%1 fells %2 with a sniper shot."; 
$deathMsg[$SniperDamageType, 2] 	= "%2 was assassinated by %1."; 
$deathMsg[$SniperDamageType, 3] 	= "%2 stayed in %1's crosshairs for too long."; 

$deathMsg[$ShockDamageType, 0] 		= "%1 blows %2 up real good."; 
$deathMsg[$ShockDamageType, 1] 		= "%2 gets a taste of %1's explosive temper."; 
$deathMsg[$ShockDamageType, 2] 		= "%1 gives %2 a fatal concussion."; 
$deathMsg[$ShockDamageType, 3] 		= "%1 shocks the hell out of %2."; 

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4; 









function Client::leaveGame(%clientId)
{
	if (%clientId.possessed){
		%cl = %clientId.possby;
		Client::setControlObject(%cl, %cl);
		%clientId.possby = "";
		%clientId.possessed = "false";
		%cl.poss = "";
		%cl.possessing = "false";
	}
}



function remoteToggleInventoryMode(%clientId)
{
	if(Nappy::remoteCheck(%clientId, "ToggleInventoryMode", 1))
		return;
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else{
		remotePlayMode(%clientId);
		%clientId.usingBuilderStation = 0;
	}
}


function remoteInventoryMode(%clientId)
{
	if(Nappy::remoteCheck(%clientId, "InventoryMode", 1))
		return;
	if(!%clientId.guiLock && !Observer::isObserver(%clientId)){
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeInventory);

		if($BuilderMode){
			%clientId.usingBuilderStation = 1;
			Nappy::Builder::Station(%clientId);
		}
	}
}








function remoteCommandMode(%clientId)
{
	if(Nappy::remoteCheck(%clientId, "CommandMode", 1))
		return;
	// can't switch to command mode while a server menu is up
	if(!%clientId.guiLock && !%clientId.possessed && !%clientId.possessing && !%clientId.froze){
		remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
			checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
	}
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
         MessageAll(0, Nappy::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Nappy::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Nappy::getName(%notReady[%i]) @ " and " @ Nappy::getName(%notReady[%i+1]) 
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







