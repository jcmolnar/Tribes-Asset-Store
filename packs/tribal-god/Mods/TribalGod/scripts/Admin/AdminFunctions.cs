function Freeze(%clientId, %var){
	%player = Client::getOwnedObject(%clientId);
	%playername = Client::getName(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "on"){
		%clientId.isfrozen = 1;
		%clientId.nosuicide = 1;
		Client::sendMessage(%clientId, 0, "Freeze!~wmale1.wwshoot1.wav");
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		CenterPrint(%clientId, "<jc><f1>"@ $Server::HostName @"\n "@ %playername @", You have been frozen!\n Get comfy you have "@ $TG::FreezePadTime @" Seconds for you to unthaw", 10);
		Schedule("FreezeCheck("@ %clientId @", "@ %player @");", $TG::FreezePadTime);
		return;
	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "off"){ 
		Client::setControlObject(%clientId, %player);
		Client::sendMessage(%clientId, 0, "Ok There ya go "@ %playername @"~wmale1.wsorry.wav");
		%clientId.isfrozen = 0;
		%clientId.nosuicide = 0;
		return;
	}
}
function FreezeCheck(%clientId, %player){ 
	if(%clientId.isfrozen){
		Client::setControlObject(%clientId, %player);
		%clientId.isfrozen = 0;
		%clientId.nosuicide = 0;
	}
}

// w00t! -Dustin B.
function Posses(%clientId, %cl, %opt){
	if($Debug) Echo("****** Possess ******");
	%posseeId = %cl;
	%posseeName = Client::getName(%cl);
	%posseePlayer = Client::getOwnedObject(%cl);
	%posseeStatus = Client::getStatus(%posseeId);
	%posserId = %clientId;
	%posserName = Client::getName(%clientId);
	%posserPlayer = Client::getOwnedObject(%clientId);
	%posserStatus = Client::getStatus(%posserId);
	
	if(%opt == "Poss"){
		if(%posserId == %posseeId) Client::sendMessage(%posserId, 1, "ERROR: Cannot Possess Yourself.~wAccess_Denied.Wav");
		else if(%posseeId.isFrozen == true) Client::sendMessage(%posserId, 1, "ERROR: Client is Frozen.~wAccess_Denied.Wav");
		else if(%posseeId.isPossessing == true) Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessing Someone.~wAccess_Denied.Wav");
		else if(%posseeId.isPossessed == true) Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessed.~wAccess_Denied.Wav");
		else if(%posseeStatus == "(Dead)") Client::sendMessage(%posserId, 1, "ERROR: Client is Dead.~wAccess_Denied.Wav");
		else if(%posseeStatus == "(Observing)") Client::sendMessage(%posserId, 1, "ERROR: Client is Observing.~wAccess_Denied.Wav");
		else{
			%posseeId.isPossessed = true;
			%posseePlayer.shieldStrength = 500.0;
			%posseeId.Possby = %posserId;
			%posseeId.noSuicide = 1;
			%posseeId.guiLock = true;
			%posseePlayer.guiLock = true;
			
			%posserPlayer.shieldStrength = 500.0;
			%posserId.isPossessing = true;
			%posserId.hasPossPlayer = %posseePlayer;
			%posserId.hasPossClient = %posseeId;
			
			Client::setControlObject(%posseeId, Client::getObserverCamera(%posseeId));
			
			Observer::setOrbitObject(%posseeId, %posseePlayer, 3, 3, 3);
			CenterPrint(%posseeId, "<jl><BSkull_Big.Bmp><jc><f1>You have been possessed by <f2>"@ %posserName @", <f1>enjoy the ride..<jr><BSkull_Big.Bmp>", 10);
			
			Client::setControlObject(%posserId, %posseePlayer);
			
			if($Debug){
				Echo("Possesser: "@ %posserName @"("@ %posserId @")");
				Echo("Possesser Status: "@ Client::getStatus(%clientId));
				Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
				Echo("Possessee Status: "@ Client::getStatus(%cl));
				Echo("*********************");
			}
		}
		return;
	}
	else if(%opt == "UNPoss"){
		if(!%posseeId.isPossessed) Client::sendMessage(%posserId, 0, "Selected Client Is Not Possessed.~wAccess_Denied.Wav");
		if(%posserId != %posseeId.Possby){
			%posserId = %posseeId.Possby;
			%posserName = Client::getName(%posserId);
			%posserPlayer = Client::getOwnedObject(%posserId);
		}
		%posseeId.isPossessed = false;
		%posseePlayer.shieldStrength = 0.0;
		%posseeId.Possby = "";
		%posseeId.noSuicide = 0;
		%posseeId.guiLock = false;
		%posseePlayer.guiLock = false;
		%posserPlayer.shieldStrength = 0.0;
		%posserId.isPossessing  = false;
		%posserId.hasPossPlayer = "";
		%posserId.hasPossClient = "";
		CenterPrint(%posseeId, "<jc><f1>"@ %posserName @" says 'I can't take the smell anymore. Take A Shower Boy! Damn You Stink!'", 5);
		Client::setControlObject(%posserId, %posserPlayer);
		Client::setControlObject(%posseeId, %posseePlayer);
		if($Debug){
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
}

function Admin::startVote(%clientId, %topic, %action, %option){
	if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
	// we want an absolute time here.
	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;
	if(%diff > 0){
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if($curVoteTopic == ""){
		if(%clientId.numFailedVotes) %time += %clientId.numFailedVotes * $Server::VoteFailTime;
		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		if(%action == "kick") $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		$curVoteCount++;
		bottomprintall("<jc><f1>"@ Client::getName(%clientId) @" <f0>initiated a vote to <f1>"@ $curVoteTopic, 30);
		Echo(Client::getName(%clientId) @" initiated a vote to"@ $curVoteTopic);
		messageAll(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic@".~wCapturedTower.wav");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) %cl.vote = "";
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl.menuMode == "options") Game::menuRequest(%clientId);
		Schedule("Admin::countVotes("@ $curVoteCount @", true);", $Server::VotingTime, 35);
	}else Client::sendMessage(%clientId, 0, "Voting already in progress.");
}
function Admin::changeMissionMenu(%clientId, %voteit){
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++){
		if($MLIST::Type[%type] != "Training"){
			if(%index == 8 && $MLIST::TypeCount > 8){
				Client::addMenuItem(%clientId, %index @"More Types...", "more 8 "@ %voteit);
				break;
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @" 0 "@ %voteit);
			%index++; 
		}
	}
}

function Admin::fun(%admin, %clientId, %word)
{
	if(%admin == -1)
	{
		Centerprintall("<jc><f1>"@ Client::getName(%clientId) @ " was "@ %word @" by consensus.", 3);		
		messageAll(0, Client::getName(%clientId) @" was "@ %word @ " by consensus.~wCapturedTower.wav");
	}
	else
	{
		MessageAll(0, Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin)@".~wCapturedTower.wav");
		Centerprintall("<jc><f1>"@Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin)@".", 3);
	}
	if(%word == "frozen")
	{
		Freeze(%clientId, "on");
  		MessageAll(0, Client::getName(%clientId) @" was "@ %word @" for 2 minutes by consensus.");
  	}
	if(%word=="poisoned")
	{ poison(%clientId); }
	else if(%word=="De-Tongued")
	{ %clientId.silenced = true; }
	else if(%word=="Un-Muted")
	{ %clientId.silenced = ""; }
	else if(%word=="Admined")
	{ %clientId.isAdmin = true; }
	else if(%word=="De -admined")
	{ %clientId.isAdmin = false; %clientId.isSuperAdmin = false; } // PORT: a stripped Super Admin kept isSuperAdmin
	else if(%word=="Kicked")
	{ Admin::kick(%admin, %clientId); }
	else if(%word=="Banned")
	{ Admin::kick(%admin, %clientId, true); }
}

function TG::AdminGive(%Adminer, %c, %lvl)
{
	if(%lvl == "God"){
		if(%Adminer.isGodAdmin == true){
			%word = "God Admin";
			%c.isAdmin = true;
			%c.isSuperAdmin = true;
			%c.isGodAdmin = true;
		}else{
			Client::sendMessage(%Adminer, 0, "Don't Give Out Jobs Higher Than Your Pay Grade Punk!");
			return;
		}
	}else if(%lvl == "Super"){
		if(%Adminer.isSuperAdmin == true){
			%word = "Super Admin";
			%c.isAdmin = true;
			%c.isSuperAdmin = true;
		}else{
			Client::sendMessage(%Adminer, 0, "Don't Give Out Jobs Higher Than Your Pay Grade Punk!");
			return;
		}
	}else{
		if(%Adminer.isAdmin == true){
			%word = "Public Admin";
			%c.isAdmin = true;
		}else{
			Net::Kick(%Adminer, "No Hacks Allowed On This Server!");
			return;
		}
	}
	MessageAllExcept(%c, 0, Client::getName(%c) @" was givin "@ %word @" by "@ Client::getName(%Adminer) @"~wCapturedTower.wav");
	Client::sendMessage(%c, 0, Client::getName(%c) @", you have been givin "@ %word @" by "@ Client::getName(%Adminer) @".~wCapturedTower.Wav");
	BottomPrint(%c, "<jc><f1>"@ Client::getName(%c) @", you have been givin <f2>"@ %word @" <f1>by <f2>"@ Client::getName(%Adminer) @"<f1>.", 5);
}

function Admin::voteFailed(){
	$curVoteInitiator.numVotesFailed++;
	if($curVoteAction == "kick" || $curVoteAction == "admin") $curVoteOption.voteTarget = "";
}

function Admin::voteSucceded(){
	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick"){
		if($curVoteOption.voteTarget)
		Admin::kick(-1, $curVoteOption);
	}
	if($curVoteAction == "poison"){
		if($curVoteOption.voteTarget){
			KillRatDead($curVoteOption);
			Centerprint($curVoteOption, "<jc><f1>you were poisoned by everyone.", 15);
			MessageAll(0, Client::getName($curVoteOption) @" had some acid with their Wheaties.");
		}
	}
	if($curVoteAction == "unsilence"){
		if($curVoteOption.voteTarget)
		Admin::fun(-1, $curVoteOption, "Un-Muted");
	}
	if($curVoteAction == "silence"){
		if($curVoteOption.voteTarget)
		Admin::fun(-1, $curVoteOption, "De-Tongued");
	}
	if($curVoteAction == "freeze"){
		if($curVoteOption.voteTarget){
			Freeze($curVoteOption, "on");
			centerprint($curVoteOption, "<jc><f1>you were frozen by everyone.", 15);
			MessageAll(0, Client::getName($curVoteOption) @ " gets the cold shoulder for 2 minutes.");
		}
	}
	else if($curVoteAction == "admin"){
		if($curVoteOption.voteTarget){
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.~wCapturedTower.wav");
			
			if($curVoteOption.menuMode == "options")
			Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission"){
		MessageAll(0, "Changing to mission "@ $curVoteOption @".~wCapturedTower.wav");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "tourney") Admin::setModeTourney(-1);
	else if($curVoteAction == "ffa") Admin::setModeFFA(-1);
	else if($curVoteAction == "etd") Admin::setTeamDamageEnable(-1, true);
	else if($curVoteAction == "dtd") Admin::setTeamDamageEnable(-1, false);
	else if($curVoteOption == "smatch") Admin::startMatch(-1);
	else if($curVoteAction == "NextMap") nextmap();
	else if($curVoteAction == "RandomMap") randommap();
	else if($curVoteAction == "ReplayMap") replaymap();
	else if($curVoteAction == "VTime") remoteSetTimeLimit(0, $curVoteOption);
	else if($curVoteAction == "eBaseD") Admin::setBaseDamageEnable(-1, true);
	else if($curVoteAction == "dBaseD") Admin::setBaseDamageEnable(-1, false);
	else if($curVoteAction == "eBaseH") Admin::setBaseHealingEnable(-1, true);
	else if($curVoteAction == "dBaseH") Admin::setBaseHealingEnable(-1, false);
	else if($curVoteAction == "eOutAreaD") Admin::setAreaDamageEnable(-1, true);
	else if($curVoteAction == "dOutAreaD") Admin::setAreaDamageEnable(-1, false);
	else if($curVoteAction == "ePlayerD") Admin::setPlayerDamageEnable(-1, true);
	else if($curVoteAction == "dPlayerD") Admin::setPlayerDamageEnable(-1, false);
}
function Admin::countVotes(%curVote){
	if(%curVote != $curVoteCount) return;
	%votesFor = 0;
	%votesAgainst = 0;
	%votesAbstain = 0;
	%totalClients = 0;
	%totalVotes = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		%totalClients++;
		if(%cl.vote == "yes"){
			%votesFor++;
			%totalVotes++;
		}
		else if(%cl.vote == "no"){
			%votesAgainst++;
			%totalVotes++;
		}
		else %votesAbstain++;
	}
	%minVotes = floor($Server::MinVotesPct * %totalClients);
	if(%minVotes < $Server::MinVotes) %minVotes = $Server::MinVotes;
	if(%totalVotes < %minVotes){
		%votesAgainst += %minVotes - %totalVotes;
		%totalVotes = %minVotes;
	}
	%margin = $Server::VoteWinMargin;
	if($curVoteAction == "admin"){
		if(%minVotes < $Server::AdminMinVotes) 
		%minVotes = $Server::AdminMinVotes; 
		%margin = $Server::VoteAdminWinMargin;
		%totalVotes = %votesFor + %votesAgainst + %votesAbstain;
		if(%totalVotes < %minVotes) 
		%totalVotes = %minVotes;
	}
	if((%votesFor / %totalVotes >= %margin || $curVoteForce == "YES") && $curVoteForce != "NO"){
		messageAll(0, "Vote to "@ $curVoteTopic @" passed: "@ %votesFor @" to "@ %votesAgainst @" with "@ %totalClients - (%votesFor + %votesAgainst) @" abstentions.");
		Admin::voteSucceded();
	}else{
		if($curVoteAction == "kick"){
			%votesFor = 0; 
			%totalVotes = 0; 
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
				if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam){
					%totalVotes++;
					if(%cl.vote == "yes")
					%votesFor++;
				}
			}
			if((%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin || $curVoteForce == "YES") && $curVoteForce != "NO"){
				messageAll(0, "Vote to " @ $curVoteTopic @" passed: "@ %votesFor @" to "@ %totalVotes - %votesFor @".");
				Admin::voteSucceded();
				$curVoteTopic = "";
				$curVoteForce = "";
				return;
			}
		}
		if(%totalClients - (%votesFor + %votesAgainst) < 0 || %votesFor > %votesAgainst) messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ ", not enough votes to " @ $curVoteTopic);
		else messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions."); Admin::voteFailed();
	}
	$curVoteTopic = "";$curVoteForce = "";
}

function Admin::kick(%admin, %client, %ban){
	%adminName = Client::getName(%admin);
	%baneeName = Client::getName(%client);
	%client = floor(%client); // PORT: comes from a menu code; spliced into schedule() below
	if(%admin != %client && (%admin == -1 || %admin.isAdmin)){
		if(%ban && !%admin.isSuperAdmin) return;
		if(%ban){
			%word = "Banned";
			%cmd = "BAN: ";
		}else{
			%word = "Kicked";
			%cmd = "KICK: ";
		}
		if(%client.isSuperAdmin){
			if(%admin == -1) messageAll(0, "Super Admins Cannot Be "@ %word @".");
			else Client::sendMessage(%admin, 0, "A Super Admin Cannot Be "@ %word @" DipShit.");
			return;
		}
		%ip = Client::getTransportAddress(%client);
		if(%ip == "") return;
		if(%ban){
			BanList::add(%ip, $TribalGod::BanTime);
			BanList::export("config\\banlist.cs");
		}else{
			BanList::add(%ip, $TribalGod::KickTime);
			BanList::export("config\\banlist.cs");
		}
		%name = Client::getName(%client);
		if(%admin == -1){
			MessageAll(0, %name @" was "@ %word @" from vote.~wCapturedTower.wav");
			echo(%cmd @ %name @"("@ %ip @") was "@ %word @" from vote.");
			Net::kick(%client, "You were "@ %word @" by  consensus.");
		}else{
			CenterPrint(%client, "<jc><f0>"@ $TG::KickMessage, 5);
			MessageAll(0, %baneeName @" Was "@ %word @" By "@ %adminName @" For Being A AssHole.~wCapturedTower.wav");
			Schedule("Net::kick("@ %client @", \"You were "@ %word @" by " @ escapeString(%adminName) @". Go Away, And Stay Away.\");", 10);
		}
	}
}

function Admin::startMatch(%admin){
	if(%admin == -1 || %admin.isAdmin){
		if(!$CountdownStarted && !$matchStarted){
			if(%admin == -1) messageAll(0, "Match start countdown forced by vote.");
			else messageAll(0, "Match start countdown forced by "@ Client::getName(%admin));
			Game::ForceTourneyMatchStart();
		}
	}
}

function Admin::strip(%client){
	%client.isAdmin      = "";
	%client.isSuperAdmin = "";
	%client.isGodAdmin   = "";
	Client::sendMessage(%client, 0, "Your admin status has been stripped.~wCapturedTower.wav");
	BottomPrint(%client, "<f1><jc>Your admin has been stripped.", 20);
}

function Admin::give(%client){
	%client.isAdmin      = true;
	%client.isSuperAdmin = true;
	Client::sendMessage(%client, 0, "You have been granted admin.~wCapturedTower.wav");
	BottomPrint(%client, "<f1><jc>You have been granted admin.", 20);
}

function player::status(%client){%player=Client::getOwnedObject(%client);%team=Client::getTeam(%client);if(%player==-1 && %team!=-1){%status="(Dead)";}else if(%player!=-1 && %team!=-1){%status="(Live)";}else if(%team==-1){%status="(Observing)";}return%status;}
function XNotify(){MessageAll(0, "Gotta Restart, It'll only take a second.~wForceOpen.wav");CenterPrintAll("<jc><f1>Gotta Restart, It'll only take a second.", 10);Schedule("MessageAll(0, \"Sorry...~wForceOpen.wav\");", 3);}
function XSay(%m){MessageAll(0, "SERVER MESSAGE: "@ %m @"~wForceOpen.wav");}
function XCP(%m){CenterPrintAll("<jc><f1>SERVER MESSAGE: <f2>"@ %m, 10);}
function XBP(%m){BottomPrintAll("<jc><f1>SERVER MESSAGE: <f2>"@ %m, 10);}

// Get Flag, X-Ecutioner
function getflag(%clientId, %team){
	if(getNumTeams() == 2){
		%t1Flagpos = ($teamFlag[0]).originalPosition;
		%t2Flagpos = ($teamFlag[1]).originalPosition;
		%pteam     = GameBase::getTeam(%clientId);
		if(%team == "Friendly"){
			if(%t1Flagpos == $teamFlag[GameBase::getTeam(%clientId)]) %enemypos = %t2Flagpos;
			else if(%t1Flagpos != $teamFlag[GameBase::getTeam(%clientId)]) %enemypos = %t1Flagpos;
			GameBase::setPosition(%clientId, %enemypos);
		}
		else if(%team == "Enemy"){
			if(%t1Flagpos == $teamFlag[GameBase::getTeam(%clientId)]) %friendlypos = %t1Flagpos;
			else if(%t1Flagpos != $teamFlag[GameBase::getTeam(%clientId)]) %friendlypos = %t2Flagpos;
			GameBase::setPosition(%clientId, %friendlypos);
		}
	}
	else Echo("getflag("@ %clientId @", "@ %team @"); |  Too many flags to consider");
}

function Admin::crash(%clientId){
	Echo("crash function");
	%ip = Client::getTransportAddress(%clientId);
	Echo("damageflash");
	Player::setDamageFlash(%clientId,0.75);
	Echo("centerprint");
	CenterPrint(%clientId, "<jc><f1>"@ $TG::KickMessage, 10);
	Echo("schedule kick");
	%message = "Bitch!";
	Net::kick(%clientId,%message);
}

function fixable(%player, %target){
	%client = Player::getClient(%player);
	%tname = GameBase::getMapName(%target);
	%name = (GameBase::getDataName(%player.repairTarget)).description;
	%data = GameBase::getDataName(%player.repairTarget);
	if($NoMapTurrets && (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret")){
		Client::sendMessage(%client,0,%name @" is not fixable, Turrets have been disabled by admin.");
		return false;
	}
	else if($NoInv && %data == "InventoryStation" ){
		Client::sendMessage(%client,0, %name @" is not fixable, Inventories have been disabled by admin.");
		return false;
	}
	else if($NoGenerator &&(%data == "Generator" || %data == "PortGenerator" || %data == "SolarPanel")){
		Client::sendMessage(%client,0, %name @" is not fixable, Generators have been disabled by admin.");
		return false;
	}
	else if($NoVehicle &&(%data == "VehicleStation" || %data == "VehiclePad")){
		Client::sendMessage(%client,0, %name @" is not fixable, Vehicle Stations have been disabled by admin.");
		return false;
	}
	else return true;
}

function AutoRepair(%fixRate){
	for(%i = 8200; %i < 9300; %i++){
		%data = GameBase::getDataName(%i);
		if(%data != "") 
		%object = getObjectType(%i);
		if(%data.className == Generator || %data.className == Station){
			%rate = GameBase::getAutoRepairRate(%i) + %fixrate;
			GameBase::setAutoRepairRate(%i, %rate);
		}
	}			
}

function whoison(){
	Echo("*****| Who Is On |*****"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		%name = Client::getName(%pl); 
		%ip = Client::getTransportAddress(%pl);
		Echo("Client #: "@ %i +1);
		Echo("ClientId: "@ %pl);
		Echo("Name: "@ %name);
		Echo("Ip: "@ %ip);
		Echo("*******************"); 
	}
	Echo("***********************");
}

$PlasmaticNoKill = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Trigger GroupTrigger towerswitch towerSwitch flagstand MapMarker";
function NoPurge(%data){ 
	for(%i = 0; !getWord($PlasmaticNoKill, %i); %i++){
		if(%data == getWord($PlasmaticNoKill, %i)){
			return true;
		}
	}
	return false;
}

$PlasmaticNoKillmap = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Generator GroupTrigger InventoryStation IndoorTurret MortarTurret rocketTurret RocketTurret Elfturret PlasmaTurret SolarPanel CommandStation AmmoStation VehicleStation VehiclePad PulseSensor MediumPulseSensor Trigger towerswitch towerSwitch flagstand ObserverCamera MapMarker";
function NoPurgeMap(%data){
	for(%i = 0; !getWord($PlasmaticNoKillmap, %i); %i++){
		//echo(getWord($PlasmaticNoKill, %i));
		if (%data == getWord($PlasmaticNoKillmap, %i)) return true;
	}
	return false;
}

function KillClass(%clientId,%kill,%classname){
	for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
		if (%data != "") %object = getObjectType(%i);
		if (%data.className == %classname)
		{
			echo(%data, %count);
			if(%kill)
			GameBase::setDamageLevel(%i, %data.maxDamage);
			else 
			GameBase::setDamageLevel(%i, 0);
		}
	}
	
	if(%kill){
		messageAll(0, Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s.", 3);
	}else{
		messageAll(0, Client::getName(%clientId) @ " Fixed ALL "@ %classname @"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL "@%classname@"s.", 3);		
	}	
}

function KillDepGen(%clientId){
	for(%i = 8200; %i< $maxdepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
		if(%data != ""){
			%object = getObjectType(%i);
		}
		if(%data == "PortableGenerator"){
			echo(%data,%count);
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
	}		
	MessageAll(0, Client::getName(%clientId) @" Destroyed all deployable generators.~wCapturedTower.wav");
	BottomPrintAll("<jc><f1>"@ Client::getName(%clientId) @" Destroyed all deployable generators.", 3);
}

function KillMapInv(%clientId, %base, %kill){
	if(%base){
		for(%i = 8200; %i< 9300; %i++){
			%data = GameBase::getDataName(%i);
			if(%data != ""){
				%object = getObjectType(%i);
			}
			if(%data == "InventoryStation" ){
				echo(%data,%count);
				if (%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
		
		if(%kill){
			messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base Inventories.", 3);
		}else{
			messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Inventories.", 3);
		}
	}
	if(!%base){
		for(%i = 8200; %i< $maxDepObj; %i++)
		{
			//1100 objects should be enough for now. -Plasmatic
			%data = GameBase::getDataName(%i);
			if (%data != "") 
			%object = getObjectType(%i);
			if (%data == "MobileInventory" || %data == "DeployableInvStation")
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
		MessageAll(0, Client::getName(%clientId) @" Destroyed ALL deployable Inventories.~wCapturedTower.wav");
		CenterPrintAll("<jc><f1>"@ Client::getName(%clientId) @" Destroyed ALL deployable Inventories.", 3);
	}
}

function KillMapTurrets(%clientId,%base,%kill){
	if(%base){
		for(%i = 8200; %i< 9300; %i++){			
			%data = GameBase::getDataName(%i);
			if(%data != "" && $debug){
				%count++;
				%object = getObjectType(%i);
				echo(%data, %count);
				$object = %object@" "@%data@" "@%count@" "@%i; 
				export("object","config\\object.log",true);
			}
			if(%data != ""){
				%object = getObjectType(%i);
			}
			if(%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret"){
				echo(%data,%count);
				if(%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
		if (%kill){
			messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base turrets.", 3);
		}else{
			messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base turrets.", 3);
		}
	}
	
	if(!%base){
		for(%i = 8200; %i< $maxDepObj; %i++){
			%data = GameBase::getDataName(%i);
			if (%data != "" && $debug){
				%count++;
				%object = getObjectType(%i);
				echo(%data,%count);
				$object = %object@" "@%data@" "@%count@" "@%i;
				export("object","config\\object.log",true);
			}
			if (%data != "") 
			%object = getObjectType(%i);						
			if (%data == "rocketTurret" || %data != "RocketTurret" && %data != "IndoorTurret" &&  %data != "Elfturret" &&  %data != "MortarTurret" && %data != "PlasmaTurret" && %object == "Turret")
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
		messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable turrets.~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable turrets.", 3);
	}
}


function KillPurge(%clientId,%kill){
	if($maxdepObj > 9300) 
	%maxpurge = $maxdepObj;
	else 
	%maxpurge = 9300;
	
	for(%i = 8200; %i < %maxpurge; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data!="") 
		%object = getObjectType(%i);
		if(!NoPurge(%data)){
			if(%data.maxDamage < 500 && !NoPurge(%object)){
				if ($debug){
					%count++;
					$object = "OB "@%object@" DA "@%data@" "@%count@" "@%i; 
					echo($object);
					export("object","config\\object.log",true);
				}
				if(%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage + 1);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
	}
	
	if(%kill){
		KillDeploy(%clientId);
		messageAll(0, Client::getName(%clientId) @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a NEUTRON BOMB.", 3);
	}else{
		fixDeploy(%clientId);
		messageAll(0, Client::getName(%clientId) @ " Fixed ALL equipment. ~wCapturedTower.wav");
		schedule("Client::sendMessage("@%clientId@", 1,\"[TG]-X-Ecutioner: Thank's.\");", 2);
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL equipment.", 3);
	}
}

$maxMapObj = 9300;
$maxDepObj = "";

function NukeBaselist(%obj){
	if(%obj < 8200) return;		
	if(%obj < $maxMapObj)$maxMapObj = %obj;		
}

function NukeList(%obj){
	if(%obj < 8200) return;
	if(%obj > $maxDepObj)$maxDepObj = %obj;		
	%obj.nuetron = true;	
}

function AdminKillDeploy(%clientId){
	KillDeploy(%clientId);			
	messageAll(0, Client::getName(%clientId) @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a NEUTRON BOMB.", 3);		
}

function KillDeploy(%clientId){
	echo($maxMapObj,$maxDepObj);
	for(%i = 8200; %i < ($maxDepObj + 1); %i++)
	{	
		if(%i.nuetron)GameBase::setDamageLevel(%i, GameBase::getDataName(%i).maxDamage + 1);
	}				
} 

function FixDeploy(%clientId){
	if($debug) echo($maxMapObj,$maxDepObj);
	for(%i = 8200; %i < ($maxDepObj + 1); %i++){	
		if(%i.nuetron)GameBase::setDamageLevel(%i, 0);
	}				
}
function KillMapVehicle(%clientId,%base,%kill){
	if(%base){
		for(%i = 8200; %i< 9300; %i++){
			//1100 objects should be enough for now. -Plasmatic
			%data = GameBase::getDataName(%i);		
			if(%data != ""){
				%object = getObjectType(%i);
			}
			if(%data == "VehicleStation" || %data == "VehiclePad"){					
				echo(%data,%count);
				if(%kill){
					GameBase::setDamageLevel(%i, %data.maxDamage);
				}else{
					GameBase::setDamageLevel(%i, 0);
				}
			}
		}
		if(%kill){				
			messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Vehicle Stations. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Vehicle Stations.", 3);
		}else{
			messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations.", 3);
		}
	}		
	if(!%base){
		for(%i = 8200; %i< $maxDepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "MobileInventory" || %data == "DeployableInvStation") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
		messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.", 3);	
	}		
}

function BurnUp(%clientId){
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)){ 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		%xpos = getWord(%Pos,0);
		%ypos = getWord(%Pos,1);
		%zpos = getWord(%Pos,2)+ 0.1;
		%npos = %xpos @" "@ %ypos @" "@ %zpos;
		%trans =  "0 0 0 0 0 0.1 0 0 0 "@ %npos; 
		
		%obj = Projectile::spawnProjectile("FireScreen", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		schedule("BurnUp("@ %clientId @");", 0.2);
	}
}

function KillRatDead(%clientId){
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)){
		//%Pos = GameBase::getPosition(%player); 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		%xpos = getWord(%Pos,0);
		%ypos = getWord(%Pos,1);
		%zpos = getWord(%Pos,2)+0.5;
		%npos = %xpos @" "@ %ypos @" "@ %zpos;
		%trans =  "0 0 1 0 0 0 0 0 1 " @ %npos; 
		%obj = Projectile::spawnProjectile("RatPoison", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		Item::setVelocity(%obj, %vel);
		schedule("KillRatDead("@%clientId@");", 1.0);
	}
}

function PlayerFlagCurse(%Client){
	if(!%Client.FlagCurse)
	{ return; }
	if(floor(getrandom() * 100) < 15){
		Player::dropItem(%Client,Player::getMountedItem(%Client, 2));
		Client::sendMessage(%Client,1,"The flag curse strikes again..~wError_Message.wav");	
	}else{
		schedule("PlayerFlagCurse("@ %Client @");", 2);
	}
}

function ServerSwitches(%clientId, %option, %action){
	if(%action){
		messageAll(0, Client::getName(%clientId) @ " ENABLED " @ %option @"~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " ENABLED " @ %option, 3);
	}else{
		messageAll(0, Client::getName(%clientId) @ " DISABLED " @ %option @"~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " DISABLED " @ %option, 3);	
	}
	
	if(%option == "Fair Teams"){
		if(%action)
		$TG::FairTeams = 1;
		else
		$TG::FairTeams = 0;
	}
	else if(%option == "turret points"){
		if(%action)
		$TurretPoints = 1;
		else 
		$TurretPoints = 0;
	}
	else if(%option == "deployable turrets"){
		if(%action)
		$NoDeployableTurret = 0;
		else 
		$NoDeployableTurret = 1;
	}
	else if(%option == "map turrets"){
		if(%action)
		$NoMapTurrets = 0;
		else
		$NoMapTurrets = 1;
	}
	else if(%option == "Inventories"){
		if(%action)
		$NoInv = 0;
		else
		$NoInv = 1;
	}
	else if (%option == "Vehicle Stations")
	{
		if(%action)
		$NoVehicle = 0;
		else
		$NoVehicle = 1;
	}
	else if (%option == "Generators")
	{
		if(%action)
		$NoGenerator = 0;
		else
		$NoGenerator = 1;
	}
	else if (%option == "Flag captures")
	{
		if(%action)
		$NoFlagCaps = 0;
		else
		$NoFlagCaps = 1;
	}
	else if (%option == "Voting")
	{
		if(%action)
		$NoVote = 0;
		else
		$NoVote = 1;
	}
	else if (%option == "Voting Admin")
	{
		if(%action)
		$TG::VoteAdmin = 1;
		else
		$TG::VoteAdmin = 0;
	}
	else if (%option == "Observer Alert")
	{
		if(%action)
		$TG::obsAlert = 1;
		else
		$TG::obsAlert = 0;
	}
	else if (%option == "personal skins")
	{
		if(%action)
		$TG::UsePersonalSkin = 1;
		else
		$TG::UsePersonalSkin = 0;
	}
}

function Admin::setTeamDamageEnable(%admin, %enabled){
	if(%admin == -1 || %admin.isAdmin){
		if(%enabled){
			$Server::TeamDamageScale = 1;
			if(%admin == -1){
				messageAll(0, "Team damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage ENABLED by consensus.");
			}else{	
				messageAll(0, Client::getName(%admin) @ " ENABLED team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED team damage.", 3);
				logAdminAction(%admin, "Team damage ENABLED.");
			}
		}else{
			$Server::TeamDamageScale = 0;
			if(%admin == -1){
				messageAll(0, "Team damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage DISABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " DISABLED Team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Team damage.", 3);
				logAdminAction(%admin, "Team damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseDamageEnable(%admin, %enabled){
	if(%admin == -1 || %admin.isAdmin){
		if(%enabled){
			$TG::SafeBase = 0;
			if(%admin == -1){
				messageAll(0, "BASE damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>BASE damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " ENABLED BASE damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED BASE damage.", 3);
				logAdminAction(%admin, "BASE damage ENABLED.");
			}
		}else{
			$TG::SafeBase = 1;
			if(%admin == -1){
				messageAll(0, "Base damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base damage DISABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " DISABLED Base damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Base damage.", 3);
				logAdminAction(%admin, "Base damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseHealingEnable(%admin, %enabled){
	if(%admin == -1 || %admin.isAdmin){
		if(%enabled){
			$TG::BaseHeal = 1;
			AutoRepair(0.01);
			if(%admin == -1){
				messageAll(0, "Base healing ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing ENABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing ENABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " ENABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED base healing.", 3);
				logAdminAction(%admin, "base healing ENABLED.");
			}
		}else{
			$TG::BaseHeal = 0;
			AutoRepair(-0.01);
			if(%admin == -1){
				messageAll(0, "Base healing DISNABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing DISABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " DISABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED base healing.", 3);
				logAdminAction(%admin, "Base healing DISABLED.");
			}
		}
	}
}

function Admin::setPlayerDamageEnable(%admin, %enabled){
	if(%admin == -1 || %admin.isAdmin){
		if(%enabled){
			$NoPlayerDamage = 0;
			if(%admin == -1){
				messageAll(0, "Player damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Player damage ENABLED by consensus.", 3);
			}else{
				messageAll(0, Client::getName(%admin) @ " ENABLED Player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED Player damage.", 3);
			}
		}else{
			$NoPlayerDamage = 1;
			if(%admin == -1){
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
			}else{
				messageAll(0, Client::getName(%admin) @ " DISABLED player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED player damage.", 3);
			}

		}
	}
}

function Admin::setAreaDamageEnable(%admin, %enabled){
	if(%admin == -1 || %admin.isAdmin){
		if(%enabled){
			$TG::OutOfArea = "";
			if(%admin == -1){
				messageAll(0, "Out of area damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @ " ENABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED.");
			}				
		}else{
			$TG::OutOfArea = 1;
			if(%admin == -1){
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}else{
				messageAll(0, Client::getName(%admin) @" DISABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@ Client::getName(%admin) @" DISABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage DISABLED.");
			}
		}
	}
}

function Admin::setModeFFA(%clientId){
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)){
		$Server::TeamDamageScale = 0;
		if(%clientId == -1) messageAll(0, "Server switched to Free-For-All Mode.~wCapturedTower.wav");
		else{
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " switched to free for all mode.", 3);
			logAdminAction(%clientId, "switched to free for all mode.");
		}
		$Server::TourneyMode = false;
		centerprintall();
		if(!$matchStarted && !$countdownStarted){
			if($Server::warmupTime) Server::Countdown($Server::warmupTime);
			else Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId){
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)){
		$Server::TeamDamageScale = 1;
		if(%clientId == -1) messageAll(0, "Server switched to Tournament Mode.~wCapturedTower.wav");
		else{
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " Server switched to Tournament Mode.", 3);
			logAdminAction(%clientId, "Server switched to Tournament Mode.");
		}
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function randommap(%clientId){
	if(%clientId) messageAll(0,Client::getName(%clientId)@ " picked a random mission.~wCapturedTower.wav");
	else messageAll(0, "Starting a random mission");
	// Echo("GAME: Starting A Random Mission.");
	$timeLimitReached = true;
	Server::nextMission(false, true);
}

function nextmap(%clientId){
	if(%clientId) messageAll(0,Client::getName(%clientId)@ " started the next mission.~wCapturedTower.wav");
	else messageAll(0, "Starting next Mission");
	Echo("GAME: Starting Next Map.");
	$timeLimitReached = true;
	Server::nextMission();
}

function replaymap(%clientId){
	if(%clientId) messageAll(0,Client::getName(%clientId) @" restarted the mission.~wCapturedTower.wav");
	else messageAll(0, "Restarting Mission");
	// Echo("GAME: Restarting Map.");
	$timeLimitReached = true;
	Server::nextMission(true);
}