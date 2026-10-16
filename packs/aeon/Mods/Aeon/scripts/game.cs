exec("comchat.cs");
$SensorNetworkEnabled = true;

$Console::LogMode = 2;
$Server::FileURL = "<jc>\n<f3>No download yet, but keep waiting!";
$MODInfo = "<jc><f2>Aeon Monopolistic RPG Mod!\n"@$Aeon::servInfo;
$DModVersion = "Construction Stage";
$Mod::Current = "Aeon";
//PORT-OFF: $ModList = "Aeon";

$Server::teamName[0] = "Players";
$Server::teamSkin[0] = "base";
$Server::teamName[1] = "Bots";
$Server::teamSkin[1] = "base";
$Server::teamName[2] = "";
$Server::teamSkin[2] = "base";

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType	= 1 << 1;
$SimInteriorObjectType	= 1 << 2;
$SimCameraObjectType	= 1 << 3;
$SimMissionObjectType	= 1 << 4;
$SimUnsureObjectType	= 1 << 6;
$SimPlayerObjectType	= 1 << 7;
$SimProjectileObject	= 1 << 8;

$AIObjectType		= 1 << 19;
$MarkerObjectType	= 1 << 20;
$ItemObjectType		= 1 << 21;
$MoveableObjectType	= 1 << 22;
$StaticObjectType	= 1 << 23;
$MineObjectType		= 1 << 26;
$StationObjectType	= 1 << 27;
$CorpseObjectType2	= 1 << 28;
$VehicleObjectType	= 1 << 29;
$CorpseObjectType	= 1 << 30;
$FearItemObjectType	= 1 << 31;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]	= "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]	= "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]	= "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]	= "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]		= "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]		= "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]		= "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]		= "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]		= "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]		= "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]		= "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]		= "%1 guns down %2.";
$deathMsg[$ShrapnelDamageType, 0]	= "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]	= "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]	= "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]	= "%2 never saw it coming from %1.";
$deathMsg[$CrushDamageType, 0]		= "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		= "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		= "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		= "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		= "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		= "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		= "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		= "%2 got too close to the exploding stuff.";
// suicide messages
// %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]	= "%1 ends it all.";
$deathMsg[-2,1]	= "%1 takes %2 own life.";
$deathMsg[-2,2]	= "%1 kills %2 own dumb self.";
$deathMsg[-2,3]	= "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

function remotePlayMode(%clientId)
{
	if(!%clientId.guiLock) {
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCommandMode(%clientId)
{
	if(!%clientId.guiLock) {
		remoteSCOM(%clientId,-1);
		if(%clientId.observerMode != "pregame")
			checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId,$GuiModeCommand);
	}
}

function remoteInventoryMode(%clientId)
{
	if(!%clientId.guiLock && !Observer::isObserver(%clientId)) {
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeInventory);
	}
}

function remoteObjectivesMode(%clientId)
{
	if(!%clientId.guiLock) {
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeObjectives);
	}
}

function remoteToggleCommandMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	Client::setInventoryText(%clientId,"<jc><f1>Cash: "@String::cashComma($Aeon::ClientInfo[Aeon::getAeonID(%clientId),cash]));
	if(Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeObjectives)
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
	%group = nameToID("MissionGroup/Teams/team0/DropPoints/Random");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;
	%spawnIdx = floor(getRandom()*(%count-0.1));
	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group,%i);
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
	%group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Start");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;
	%spawnIdx = $lastTeamSpawn[%team] + 1;
	if(%spawnIdx >= %count)
		%spawnIdx = 0;
	$lastTeamSpawn[%team] = %spawnIdx;
	return Group::getObject(%group,%spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
	if(%respawn)
		return Game::pickRandomSpawn(%team);
	else {
		%spawn = Game::pickStartSpawn(%team);
		if(%spawn == -1)
			return Game::pickRandomSpawn(%team);
		return %spawn;
	}
}

function UpdateClientTimes(%time)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		remoteEval(%cl,"setTime",-%time);
}

function Game::notifyMatchStart(%time)
{
	messageAll(0, "Match starts in "@%time@" seconds.");
	UpdateClientTimes(%time);
}

function Game::startMatch()
{
	echo("start match");
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(%cl.observerMode == "pregame") {
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		}
		Game::refreshClientScore(%cl);
	}
}

function Game::pickTeamSpawn(%team, %respawn)
{
	if(%respawn)
		return Game::pickRandomSpawn(%team);
	else {
		%spawn = Game::pickStartSpawn(%team);
		if(%spawn == -1)
			return Game::pickRandomSpawn(%team);
		return %spawn;
	}
}
function Game::pickPlayerSpawn(%clientId, %respawn)
{
	return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
	if(!$ghosting)
		return false;
	%id = Aeon::getAeonID(%clientId);
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn) {
		%clientId.observerMode = "";
		%clientId.menuLock = "";
		%clientId.guiLock = "";
		Game::refreshClientScore(%clientId);
		Aeon::joinMessage(%clientId);
	}
	%clientId.guiLock = "";
	%clientId.dead = "";
	if(%spawnMarker == -1) {
		%spawnPos = "0 0 110";
		%spawnRot = "0 0 0";
	}
	else {
		%SpwnTp = $Aeon::ClientInfo[%id,pref,SpwnTp];
		if(%SpwnTp == "random") {
			%spawnPos = GameBase::getPosition(%spawnMarker);
			%spawnRot = GameBase::getRotation(%spawnMarker);
		}
		else {
			%spawnPos = $Aeon::ClientInfo[%id,sPos];
			%spawnRot = $Aeon::ClientInfo[%id,sRot];
			if(%SpwnTp == "myProp" && %spawnPos == "0 0 0")
				%spawnPos = GameBase::getPosition(%spawnMarker);
		}
	}
	if((%z = getWord(%spawnPos,2)) < 95)
		%spawnPos = Vector::add(%spawnPos,"0 0 "@95-%z);
	%armor = "larmor";
	if(String::ICompare(Client::getGender(%clientId),"Male"))
		%armor = "lfemale";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	if(%pl != -1) {
		GameBase::setTeam(%pl,0);
		Client::setOwnedObject(%clientId,%pl);
		Game::playerSpawned(%pl,%clientId,%armor,%respawn);
		if($matchStarted)
			Client::setControlObject(%clientId,%pl);
		else {
			%clientId.observerMode = "pregame";
			Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
			Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
		}
	}
	return true;
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
	Aeon::loadClient(%clientId);
	%id = Aeon::getAeonID(%clientId);
	Client::setGuiMode(%clientId, $GuiModePlay);
	if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit") {
		%clientId.observerMode = "observerOrbit";
		%clientId.guiLock = "";
		Observer::jump(%clientId);
		return;
	}
	GameBase::setTeam(%clientId,0);
	Client::setControlObject(%clientId,Client::getObserverCamera(%clientId));
	%obsPos = "0";
	while(Aeon::onMap(%obsPos) != true) {
		%ObsX = -420+(ranDim(3070));
		%ObsY = -650+(ranDim(3070));
		%ObsZ = Property::terrainHeight(%ObsX@" "@%ObsY)+1+(10*getRandom());
		%obsPos = %ObsX@" "@%ObsY@" "@%ObsZ;
		%obsRot = Vector::getRotAim(%obsPos,"0 0 "@%ObsZ);
	}
	Observer::setFlyMode(%clientId,%obsPos,%obsRot,true,true);
	Client::setSkin(%clientId,$Client::info[%clientId,0]);
	if(%clientId.justConnected) {
		%clientId.guiLock = true;
		%clientId.menuLock = true;
		if($Aeon::JoinMOTD != "")
			centerprint(%clientId,$Aeon::JoinMOTD,0);
		%clientId.observerMode = "justJoined";
		%clientId.justConnected = "";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Game::refreshClientScore(%cl);
		if($Aeon::ClientInfo[%id,jCnt] == 1 || $Aeon::ClientInfo[%id,pass] == "") {
			%dur = 45.0;
			bottomPrint(%clientId,"<jc><f1>Please input your desired profile password, <f2>NOTE:<f1> remember or write this password down, you will need to enter it each time you connect, you have "@%dur@" seconds before you are kicked.",10);
			%clientId.nextMsg = "getPW new";
		}
		else {
			%dur = 30.0;
			bottomPrint(%clientId,"<jc><f2>Please enter your profile password, you have "@%dur@" seconds before you are kicked.",5);
			%clientId.nextMsg = "getPW";
		}
		schedule("Aeon::joinKickCheck("@%clientId@");",%dur,%clientId);
	}
	else if(%clientId.observerMode == "justJoined") {
		centerprint(%clientId,"");
		Game::playerSpawn(%clientId,false);
	}
	else
		Game::playerSpawn(%clientId,false);
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
	if($ServerCheats) {
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
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		Game::refreshClientScore(%cl);
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
	echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
	SayCMD::drop(%playerId,"");
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
		%playerGender = "his";
	else
		%playerGender = "her";
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);
	if(!%killerId) {
		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;
		Aeon::ExportInfo(%playerId);
	}
	else if(%killerId == %playerId) {
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0,%oopsMsg,$DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Aeon::ExportInfo(%playerId);
		Game::refreshClientScore(%playerId);
	}
	else {
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
			%killerGender = "his";
		else
			%killerGender = "her";
		%obitMsg = sprintf($deathMsg[%damageType,%ridx],Client::getName(%killerId),%victimName,%killerGender, %playerGender);
		if(%damageType != "$SniperDamageType")
			messageAll(0,%obitMsg, $DeathMessageMask);
		%killerId.scoreKills++;
		%playerId.scoreDeaths++;  // test play mode
		%killerId.score++;
		%idKiller = Aeon::getAeonID(%killerId);
		Karma::result(%idKiller,"kill Player");
		Aeon::ExportInfo(%playerId);
		Aeon::ExportInfo(%killerId);
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);
	}
	Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function GameBase::getHeatFactor(%this)
{
	return 0.0;
}