// __________________________________________________________________________
// Tribes Arena v3.0 for Starsiege Tribes                          2002-06-15
// by Lizard (irc.dynamix.com on #lizrena, or belgarion@tribes2universe.com)
// __________________________________________________________________________
// MAIN MODULE
// __________________________________________________________________________
// Original Tribes Arena v 2.3 and prior versions
// by Robert "Rasia" Hinkle
// __________________________________________________________________________
// INTERESTING COMMAND LINE FUNCTIONS:
//
//    Arena::ListPlayers();
//       Will display all connected players, and their score
//    Arena::DisplayVersion();
//       Will display all arena files revisions and ensure everything is 
//       properly installed. See the Arena_Readme.txt for more information 
//       on that command.
// __________________________________________________________________________
//
// Rasia's comments:
//
// This is a mission type taken from the idea of Clan Arena back in the good 
// old Quake 1 days. Its a Team DM game, in which everyone spawns, you rush 
// for weapons, and try to kill each other. When you die, you sit in observer 
// mode until one team is all dead.  When that happens everyone respawns.
// I used a couple definations here:  a Match is a full compatition between 
// two teams.  Each match is made up of a set of Games.  When one team fully 
// dies, thats the end of a game.  Most matches are 3 out of 5 Games.
// I want to thank TheGriffin and Ninja for the help!
//
// Special Thanks goes to Figy, for being the closest to guess the Number of 
// lines of Code Arena.cs is late at night when I was bored!!
// Honorable mention goes to DVCxPanda who got within 2 lines for his second 
// guess
//
// Special Thanks to [PEN]Spiffy and [PEN]Venom for helping me test out the 
// latest build (2.3) 
// HUGE Thanks to Nookie, for being my little test dummy on, trying to fix 
// the OpenGl crash bug!!
// __________________________________________________________________________
//

$Arena::Version = "3.0";                                    // Current Arena version
$Arena::WebSiteURL = "www.tribes2universe.com";             // Arena Web Site URL
$Arena::GameTimeLimit = 240;                                // Game Limit in seconds
$Arena::NumberMatchLimit = 3;                               // After this many matches the server 
$Arena::NumberMatchLimitBackup = $Arena::NumberMatchLimit;  // cycles to next map (Defualt 3).  Set = "" 
                                                            // if you don't want this feature (or if it 
                                                            // keeps crashing the server)
$Server::TimeLimit = 0;                                     // Server object time limit (overridden)
$Arena::Scorelimit = 4;                                     // Default ScoreLimit
$Arena::ScorelimitPubMode = 4;                              // Default ScoreLimit for Public Mode
$Arena::ScorelimitMatchMode = 5;                            // Default ScoreLimit for Match Mode
$Arena::ScorelimitMax = 5;                                  // Maximum ScoreLimit that can be set by an admin (physical max is 10 and min is 5)
$Arena::ReadyTime = true;                                   // Ready Up
$Arena::AutoTeamJoin = true;                                // Auto join teams on connect


//////////// Don't Modify below this line

exec("arenaAdmin.cs");
exec("arenaComchat.cs");
//PORT-OFF: exec("arenaGUI.cs");
// PORT: settings come from the entry script (TribesArena.cs execs ArenaConfig.cs); this is the fallback if it did not run.
if($ArenaAutoEvenTeams == "") exec("ArenaConfig.cs");
// PORT: the stats module was started from the host's autoexec (ServerConfig.cs); the pack starts it here, once.
if($LizStatsEnable == 1 && $LizStatsLoaded != 1) { exec("lizStats.cs"); LizStats::StartUp(); }
$Arena::Loaded = 1;
$ArenaScoreListLetter_SuperAdmin   = "S";
$ArenaScoreListLetter_TrustedAdmin = "M";
$ArenaScoreListLetter_Admin        = "A";
$Arena::AFKDetectTimeFirstCheck = 32;
$Arena::AFKDetectTimeNextChecks = 32;
$Arena::TeamCompareRatio = 0.5;
$Arena::AutoEvenLastScore = 0;
$TeamMatchScore[0] = 0;
$TeamMatchScore[1] = 0;
$Server::TeamDamageScale = 1;
$PreGameMessage[0] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$PreGameMessage[1] = "<f1><jc>You are tied.  You need " @ $Arena::Scorelimit @ " games to win \n ";
$ItemFavoritesKey = "Arena";
$Arena::MatchStatus = 0;
$Arena::MatchMode = 0;
$Arena::OOBDamageIncrements = 0.07;
$OOBDamageType = 320;
$InvList[TurretPack] = 0;
$RemoteInvList[TurretPack] = 0;
$InvList[MineAmmo] = 0;
$RemoteInvList[MineAmmo] = 0;
$AmmoPackMax[MineAmmo] = 0;
$AmmoPackItems[6] = Beacon;
$InvList[DeployableInvPack] = 0;
$InvList[DeployableAmmoPack] = 0;
$InvList[Mortar] = 0;
$InvList[MortarAmmo] = 0;
$RemoteInvList[Mortar] = 0;
$RemoteInvList[MortarAmmo] = 0;
$TeamItemCount[0,HeavyArmor] = 0;
$TeamItemCount[1,HeavyArmor] = 0;
$TeamItemCount[0,LaserRifle] = 0;
$TeamItemCount[1,LaserRifle] = 0;
$TeamItemMax[HeavyArmor] = 0;
$TeamItemMax[LaserRifle] = "";
$Arena::MissionType = "Tribes Arena";
$Arena::GameMissionType = "Arena";
$TestMissionType = "ARENA";
$Arena::ReadyUpMessageBackup = "Hit the FIRE button to ready up!";
$Arena::ReadyUpMessage = $Arena::ReadyUpMessageBackup;
$ArenaCheckReadyStateDuration = 20;
$ArenaCheckReadyStateDurationReadyUpDisabled = 3;
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
if (%client.FreeInvTimer == false)
{
if ($Arena::MatchStatus == 1)
{
%client.FreeInvTimer = true;
schedule("Arena::SetFreeTimer(" @ %client @");", 5);
%client.InvTrips++;
if ($FixInventorySpamExploit == 1)
{
%client.InvBuyCount = 0;
}
}
}
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
{
%delta = %max - %count;
}
}
return %delta;
}
function buyItem(%client,%item,%fromfavs)
{
if ($FixInventorySpamExploit == 1)
{
if (%client.InvBuyCount > $FixInventorySpamExploitMaxBuyCountPerInvenVisit)
{
return 0;
}
else if (%client.InvBuyCount >= $FixInventorySpamExploitMaxBuyCountPerInvenVisit)
{
echo("LIZADMIN: " @ %client @ " \"" @
escapeString(Client::getName(%client)) @
"\" on " @ Client::getTransportAddress(%client) @
" has reached the maximum number of purchases per inventory visit.");
Client::sendMessage(%client,0,"You have reached the maximum number of purchases per inventory visit.");
%client.InvBuyCount = $FixInventorySpamExploitMaxBuyCountPerInvenVisit + 1;
return 0;
}
}
%player = Client::getOwnedObject(%client);
%armor = Player::getArmor(%client);
if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) &&
($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats))
{
if (%item.className == Armor)
{
%buyarmor = $ArmorType[Client::getGender(%client), %item];
if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
{
teamEnergyBuySell(%player,$ArmorName[%armor].price);
if(checkResources(%player,%item,1))
{
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
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
return 1;
}
teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
}
}
else if (%item.className == Backpack)
{
if($TeamItemMax[%item] != "")
{
if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
return 0;
}
%pack = Player::getMountedItem(%client,$BackpackSlot);
if (%pack != -1)
{
if(%pack == ammopack)
checkMax(%client,%armor);
else if(%pack == EnergyPack)
{
if(Player::getItemCount(%client,"LaserRifle") > 0)
{
Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
remoteSellItem(%client,22);
}
}
teamEnergyBuySell(%player,%pack.price);
Player::decItemCount(%client,%pack);
}
if (checkResources(%player,%item,1) || $TestCheats)
{
teamEnergyBuySell(%player,%item.price * -1);
Player::incItemCount(%client,%item);
Player::useItem(%client,%item);
if(%item == ammopack)
fillAmmoPack(%client);
if ($TeamItemMax[%item] != "")
$TeamItemCount[GameBase::getTeam(%client), %item]++;
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
return 1;
}
else if(%pack != -1)
{
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
buyItem(%client,"EnergyPack", 0);
Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
}
Player::incItemCount(%client,%item);
teamEnergyBuySell(%player,(%item.price * -1));
%ammoItem =  %item.imageType.ammoType;
if(%ammoItem != "")
{
%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
if(%delta || $TestCheats)
{
teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
Player::incItemCount(%client,%ammoitem,%delta);
}
}
if ($TeamItemMax[%item] != "")
$TeamItemCount[GameBase::getTeam(%client),%item]++;
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
return 1;
}
}
else if(%item.className == Vehicle)
{
if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
{
%shouldBuy = VehicleStation::checkBuying(%client,%item);
if(%shouldBuy == 1)
{
teamEnergyBuySell(%player,(%item.price * -1));
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
return 1;
}
else if(%shouldBuy == 2)
{
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
return 1;
}
}
}
else {
if($TeamItemMax[%item] != "")
{
if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
return 0;
}
%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
if(%delta || $TestCheats)
{
teamEnergyBuySell(%player,(%item.price * -1 * %delta));
Player::incItemCount(%client,%item,%delta);
if ($FixInventorySpamExploit == 1)
%client.InvBuyCount++;
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
if (%obj == "Player")
{
%client = Player::getClient(%object);
if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1)
{
if (GameBase::getDamageState(%this) == "Enabled")
{
if (GameBase::isPowered(%this))
{
if (%client.InvTrips < 2 || %client.FreeInvTimer == true)
{
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
if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
{
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
function ObjectiveMission::setObjectiveHeading()
{
for(%i = -1; %i < getNumTeams(); %i++) {
for(%s = %lineNb+1; %s < 30 ;%s++)
Team::setObjective(%i, %s, " ");
Team::clearObjectives(%i);
}
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
if(%tieGame)
{
for(%g = 0; %g <= %tie; %g++)
{
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
if(%i == %curLeader)
{
if($teamScore[%curLeader] == 1)
Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
else
Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
}
else
{
if($teamScore[%curLeader] == 1)
Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
else
Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
}
}
else
{
if(getNumTeams() > 2)
{
Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
}
else
Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
}
Team::setObjective(%i, 2, " ");
}
}
else
{
for(%i = -1; %i < getNumTeams(); %i++)
{
objective::displayBitmap(%i,0);
Team::setObjective(%i,1, "<f5>Mission Completion:");
Team::setObjective(%i,2,"<f1>   - " @ $Arena::Scorelimit @ " points needed to win the match.");
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
%maxgamestotal = $Arena::ScoreLimit * 2 - 1;
for(%i = -1; %i < getNumTeams(); %i++)
{
%lineNb = 3;
Team::setObjective(%i, %lineNb  , " ");
Team::setObjective(%i, %lineNb++, "<f5>Mission Information:");
Team::setObjective(%i, %lineNb++, "<f1>   - Mission Name: " @ $missionName);
if (%str != "") {
Team::setObjective(%i, %lineNb++, %str);
}
Team::setObjective(%i, %lineNb++, " ");
Team::setObjective(%i, %lineNb++, "<f5>Arena v" @ $Arena::Version @ " Rules:");
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
}
else {
Team::setObjective(%i, %lineNb++, "<f1>   - Hit FIRE to Ready Up for each match");
}
Team::setObjective(%i, %lineNb++, "<f1>   - Match is won when a team wins " @ $Arena::ScoreLimit @ " out of " @ %maxgamestotal @ " games");
Team::setObjective(%i, %lineNb++, "<f1>   - Kill all players in ennemy team to win the game");
Team::setObjective(%i, %lineNb++, "<f1>   - In the TAB score list, a * indicates a player is still alive");
Team::setObjective(%i, %lineNb++, " ");
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if ($LizStatsMap == 1)
{
if ($LizStats::MapStatsMapHighestScoreResetDate != "")
Team::setObjective(%i, %lineNb++, "<f5>Top " @ $LizStatsMapsMapHighestScore @ " Scores on " @ $missionName @ " since " @ $LizStats::MapStatsMapHighestScoreResetDate);
else
Team::setObjective(%i, %lineNb++, "<f5>Top " @ $LizStatsMapsMapHighestScore @ " Scores on " @ $missionName);
%scorecount = 0;
%lasttopscorename = "";
for(%highscore = 0; %highscore < $LizStatsMapsMapHighestScore; %highscore++)
{
%statstr = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %highscore];
if ($UseNewScoringSystem == 1)
{
%rank = getWord(%statstr, 0);
if ((%rank != "") && (%rank != $LizStatsScoresNull)) {
%nbkills = getWord(%statstr, 1);
%nbdeaths = getWord(%statstr, 2);
%score = getWord(%statstr, 3);
%name = LizStats::ExtractClientNameRankMethod(%highscore);
if ((%name != %lasttopscorename)  && (%name != ""))
{
Team::setObjective(%i, %lineNb++, "<f3>   " @ %highscore+1 @ ")\t " @
%name @ " with " @ %nbkills @ " kills, " @ %nbdeaths @ " deaths (" @ %score @ " points)");
%lasttopscorename = %name;
%scorecount++;
}
}
}
else
{
%score = getWord(%statstr, 0);
if (%score != $LizStatsScoresNull) {
%nbkills = getWord(%statstr, 1);
%name = LizStats::ExtractClientNameScoreMethod(%highscore);
if (%name != %lasttopscorename)
{
if (%score >= 0)
{
Team::setObjective(%i, %lineNb++, "<f3>   " @ %highscore+1 @ ")\t " @
%name @ " with " @ %score @ " points and " @ %nbkills @ " kills");
%lasttopscorename = %name;
%scorecount++;
}
}
}
}
}
if (%scorecount == 0)
Team::setObjective(%i, %lineNb++, "<f3>   No high scores yet");
Team::setObjective(%i, %lineNb++, " ");
}
if ($LizStatsServer == 1)
{
Team::setObjective(%i, %lineNb++, "<f5>" @ $missionName @ " Statistics");
%mapplayed = $LizStats::ServerStatsTotalMapsPlayed[$LizStats::CleanMissionType,$LizStats::CleanMissionName];
if ((%mapplayed == "") || (%mapplayed == 0))
%mapplayed = 1;
if (($LizStats::ServerStatsTotalAllMapsPlayed > 0) && ($LizStats::ServerStatsTotalAllMapsPlayed != "")) {
%mappercent = (%mapplayed * 100) / $LizStats::ServerStatsTotalAllMapsPlayed;
%mappercent = floor(%mappercent);
}
else
%mappercent = "100";
if (%mappercent != "")
%mappercent = "(" @ %mappercent @ "% of total maps played)";
Team::setObjective(%i, %lineNb++, "<f3>   - " @ $missionName @ " was played " @ %mapplayed @ " times " @ %mappercent);
%mapplayed = $LizStats::ServerStatsTotalGamesPlayed[$LizStats::CleanMissionType,$LizStats::CleanMissionName];
if ((%mapplayed == "") || (%mapplayed == 0))
%mapplayed = 1;
if (($LizStats::ServerStatsTotalAllGamesPlayed > 0) && ($LizStats::ServerStatsTotalAllGamesPlayed != "")) {
%mappercent = (%mapplayed * 100) / $LizStats::ServerStatsTotalAllGamesPlayed;
%mappercent = floor(%mappercent);
}
else
%mappercent = "100";
if (%mappercent != "")
%mappercent = "(" @ %mappercent @ "% of total games played)";
Team::setObjective(%i, %lineNb++, "<f3>   - " @ %mapplayed @ " games were played on " @ $missionName @ " " @ %mappercent);
%mapplayed = $LizStats::ServerStatsTotalGamesPlayed[$LizStats::CleanMissionType,$LizStats::CleanMissionName];
if ((%mapplayed != "") && (%mapplayed != 0))
{
%mappercent1 = ((($LizStats::MapStatsGamesWonTeam1[$LizStats::CleanMissionType, $LizStats::CleanMissionName]) * 100) / %mapplayed);
%mappercent1 = floor(%mappercent1);
%mappercent2 = ((($LizStats::MapStatsGamesWonTeam2[$LizStats::CleanMissionType, $LizStats::CleanMissionName]) * 100) / %mapplayed);
%mappercent2 = floor(%mappercent2);
Team::setObjective(%i, %lineNb++, "<f3>   - " @
getTeamName(0) @ " won " @
%mappercent1 @ "% of total games on this map.");
Team::setObjective(%i, %lineNb++, "<f3>   - " @
getTeamName(1) @ " won " @
%mappercent2 @ "% of total games on this map.");
}
Team::setObjective(%i, %lineNb++, " ");
}
if ($LizStatsServer == 1)
{
Team::setObjective(%i, %lineNb++, "<f5>\"" @ $Server::HostName @ "\" Server Statistics");
Team::setObjective(%i, %lineNb++, "<f3>   - " @
$LizStats::ServerStatsTotalAllGamesPlayed @
" games were played (" @
$LizStats::ServerStatsTotalAllMapsPlayed @
" maps)");
Team::setObjective(%i, %lineNb++, "<f3>   - " @
$LizStats::ServerStatsTotalConnects @ " players connected for a total of " @
$LizStats::ServerStatsTotalKills @ " kills, " @
$LizStats::ServerStatsTotalDeaths @ " deaths, " @
$LizStats::ServerStatsTotalSuicides @ " suicides, " @
$LizStats::ServerStatsTotalTKs @ " TKs");
Team::setObjective(%i, %lineNb++, " ");
}
}
Team::setObjective(%i, %lineNb++, "<f6>Visit " @ $Arena::WebSiteURL @ " for the latest version of Tribes Arena.");
for(%s = %lineNb+1; %s < 30 ;%s++)
Team::setObjective(%i, %s, " ");
}
}
function ObjectiveMission::refreshTeamScores()
{
%nt = getNumTeams();
setTeamScoreHeading("Team Name\t\x88Score\t\xC0Kills\t\xE4Deaths");
for(%i = -1; %i < %nt; %i++)
{
Team::setScore(%i, "%t\t" @ $TeamMatchScore[%i] @ "\t" @ $TeamNbKills[%i] @ "\t"
@ $TeamNbDeaths[%i], $TeamMatchScore[%i]);
for(%j = 0; %j < %nt; %j++)
Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @
" score = " @ $TeamMatchScore[%j]);
}
}
function ObjectiveMission::checkScoreLimit()
{
}
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
function Player::checkLMATimeout(%player, %seqCount)
{
echo("MISC: Checking player timeout " @ %player @ " " @ %seqCount);
if(%player.dieSeqCount == %seqCount)
remoteKill(Player::getClient(%player));
}
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
if(%player.outArea == 1)
{
if(!Player::isDead(%player))
{
Player::setDamageFlash(%client,0.1);
GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + $Arena::OOBDamageIncrements);
schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
}
else
{
playNextAnim(%client);
schedule("Client::onKilled(" @ %client @ "," @ %client @ "," @ $OOBDamageType @ ");",2);
}
}
}
function Mission::init()
{
if ($LizStatsLoaded == 1)
{
$LizStats::CleanMissionName = LizStats::ParseName($missionName);
$LizStats::CleanMissionType = LizStats::ParseName($Arena::MissionType);
}
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
LizStats::UpdateServerStatsTotalMapsPlayed(1);
}
if (($LizStatsLoaded == 1) && ($Arena::MatchMode == 0))
{
LizStats::UpdatePlayedMaps($missionName);
}
setTeamScoreHeading("Team Name\t\x88Score\t\xC0Kills\t\xE4Deaths");
if ($UseNewScoringSystem == 1) {
setClientScoreHeading("  Player Name\t\x6DTeam\t\xA4 Score\t\xD3Ping\t\xEFPL\t\xFFAdmin");
}
else {
setClientScoreHeading("  Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEDPL\t\xFFAdmin");
}
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
Arena::ResetTeamMapScore();
ObjectiveMission::refreshTeamScores();
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
Arena::ResetPlayerMapScore(%cl);
Arena::ComputePlayerRatios(%cl);
Game::refreshClientScore(%cl);
%cl.VoteIncrementalDelay = 0;
}
$TestMissionType = "ARENA";
AI::setupAI();
}
function Game::refreshClientScore(%clientId)
{
%team = Client::getTeam(%clientId);
if(%team == -1)
%team = 9;
%teamstr = getTeamName(%clientId.matchteam);
if (%teamstr == "0")
%teamstr = "";
%admin = "";
if (%clientId.isSuperAdmin)
%admin = $ArenaScoreListLetter_SuperAdmin;
else if (%clientId.isTrustedAdmin)
%admin = $ArenaScoreListLetter_TrustedAdmin;
else if (%clientId.isAdmin)
%admin = $ArenaScoreListLetter_Admin;
else
%admin = " ";
if (%clientId.isTeamCaptain)
%admin = %admin @ "T";
if ($UseNewScoringSystem == 1) {
%sortindicator = %clientId.scoreKillDeathRank + (9 - %team) * 30000;
%scorekill = %clientId.scoreKills - %clientId.scoreTKs;
%scoredeath = %clientId.scoreDeaths - %clientId.scoreTKed;
Client::setScore(%clientId,  %clientId.onteam @ " %n\t" @ %teamstr @ "\t " @ %scorekill @ "/" @ %scoredeath @ "\t%p\t%l\t" @ %admin, %sortindicator);
}
else {
%sortindicator = %clientId.score + %team * 200000;
Client::setScore(%clientId,  %clientId.onteam @ " %n\t" @ %teamstr @ "\t  " @ %clientId.score  @ "\t%p\t%l\t" @ %admin, %sortindicator);
}
}
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
if (%clientId.isServerSuperAdmin) {
if (%sel.isServerSuperAdmin) {
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
else if (%sel.isAdmin)
{
Client::addMenuItem(%clientId, %curItem++ @ "Unadmin " @ %name, "unadmin " @ %sel);
}
else
{
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
}
else if (%clientId.isSuperAdmin)
{
if (%sel.isServerSuperAdmin || %sel.isSuperAdmin) {
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
else if (%sel.isAdmin)
{
Client::addMenuItem(%clientId, %curItem++ @ "Unadmin " @ %name, "unadmin " @ %sel);
}
else
{
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
}
else if (%clientId.isTrustedAdmin)
{
if (%sel.isServerSuperAdmin || %sel.isSuperAdmin || %sel.isTrustedAdmin) {
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
else if (%sel.isAdmin)
{
Client::addMenuItem(%clientId, %curItem++ @ "Unadmin " @ %name, "unadmin " @ %sel);
}
else
{
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
}
else
{
Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
}
if (%clientId.isSuperAdmin)
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
if(%clientId.selClient && %clientId.isServerSuperAdmin)
{
%sel = %clientId.selClient;
%name = Client::getName(%sel);
Client::addMenuItem(%clientId, %curItem++ @ "Player options", "playerdetails");
}
else
{
Client::addMenuItem(%clientId, %curItem++ @ "Tribes Arena Options", "arenaop");
}
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
if($curVoteTopic == "" && %clientId.isAdmin && $AllAdminsCanVoteMaps == 1)
{
Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
}
Client::addMenuItem(%clientId, %curItem++ @ "Force mission change", "cmission");
if((%clientId.isSuperAdmin && $OnlySuperAdminCanResetServer == 1) || ($OnlySuperAdminCanResetServer != 1))
{
Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
}
}
}
function processMenuInitialPickTeam(%clientId, %team)
{
if (%team == "") {
Arena::TabMenuExploit(%clientId);
return;
}
if ((%team != "-2") && (%team != "-1") && (%team != "0") && (%team != "1") && (%team != "9"))
{
Arena::TabMenuExploit(%clientId);
return;
}
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
%clientId.matchteam = %team;
if ($Arena::MatchStatus == 0 || $Arena::MatchStatus == 2)
{
%clientId.notready = true;
if ($Arena::ReadyTime && %team != -2)
{
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDurationReadyUpDisabled);
}
else {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDuration);
}
}
}
}
Game::refreshClientScore(%clientId);
}
function processMenuTFPickTeam(%clientId, %team)
{
if(%clientId.isTeamCaptain) {
processMenuPickTeam(%clientId.ptc, %team, %clientId);
}
%clientId.ptc = "";
}
function processMenuOptions(%clientId, %option)
{
%opt = getWord(%option, 0);
%cl = floor(getWord(%option, 1)); // PORT: a client id is a number (it went into a schedule() string below)
if (%opt == "fteamchange" && %clientId.isAdmin) // PORT
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
else if(%opt == "tfteamchange" && %clientId.isTeamCaptain) // PORT
{
%clientId.ptc = %cl;
Client::buildMenu(%clientId, "Pick a team:", "TFPickTeam", true);
if (%cl.matchteam == -2)
Client::addMenuItem(%clientId, "0Your Team", %clientId.matchteam);
else if (%cl.matchteam == %clientId.matchteam)
Client::addMenuItem(%clientId, "0Observer", -2);
return;
}
else if(%opt == "changeteams")
{
if(!$matchStarted || !$Server::TourneyMode)
{
Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
if (%clientId.lock) {
Client::addMenuItem(%clientId, "9Observer/UnLockMe", 9);
}
else {
Client::addMenuItem(%clientId, "0Observer", -2);
if (($Arena::MatchStatus == 0) || (%clientId.matchTeam == -2))
{
Client::addMenuItem(%clientId, "1Automatic", -1);
if (%clientId.isServerSuperAdmin) {
for(%i = 0; %i < getNumTeams(); %i = %i + 1)
Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
}
}
Client::addMenuItem(%clientId, "9Observer/LockMeOut", 9);
}
return;
}
}
else if(%opt == "mute")
{
%clientId.muted[%cl] = true;
%clientId.mutedName[%cl] = Client::getName(%cl);
}
else if(%opt == "unmute")
{
%clientId.muted[%cl] = "";
%clientId.mutedName[%cl] = "";
}
else if(%opt == "globalmute" && %clientId.isServerSuperAdmin) // PORT
{
%cl.mutedGlobal = true;
%cl.mutedGlobalWarned = false;
%cl.mutedGlobalName = Client::getName(%cl);
if ($GlobalMuteDuration != 0)
{
%mutemin = floor($GlobalMuteDuration / 60);
%mutesec = $GlobalMuteDuration - %mutemin*60;
%muteduration = "";
if (%mutemin > 0) {
%muteduration = %mutemin @ " minute";
if (%mutemin > 1) {
%muteduration = %muteduration @ "s";
}
}
if (%mutesec > 0) {
if (%muteduration != "") {
%muteduration = %muteduration @ " ";
}
%muteduration = %muteduration @ %mutesec @ " second";
if (%mutesec > 1) {
%muteduration = %muteduration @ "s";
}
}
Client::sendMessage(%cl,1,"You have been globally muted for " @ %muteduration @ ".");
schedule("Arena::RemoveGlobalUnmute(" @ %cl @");", $GlobalMuteDuration);
}
else
{
Client::sendMessage(%cl,1,"You have been globally muted.");
}
}
else if(%opt == "globalunmute" && %clientId.isServerSuperAdmin) // PORT
{
Arena::RemoveGlobalUnmute(%cl);
}
else if(%opt == "vkick")
{
%cl.voteTarget = true;
Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
}
else if(%opt == "vadmin")
{
if (%cl.isAdmin) {
Client::sendMessage(%clientId, 1, "Can't vote to admin " @ Client::getName(%cl) @ " : he/she is already an admin.");
}
else {
if ($ArenaMaxNumberOfAdmins == 0) {
Client::sendMessage(%clientId, 1, "Server is configured to prevent admin votes. Vote cancelled.");
}
else if ($ArenaMaxNumberOfAdmins < 0) {
%cl.voteTarget = true;
Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
}
else {
%admCnt = Arena::CountNumberOfAdmins(-1);
if (%admCnt < $ArenaMaxNumberOfAdmins) {
%cl.voteTarget = true;
Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
}
else {
Client::sendMessage(%clientId, 1, "There are enough admins at this time. Vote cancelled.");
}
}
}
}
else if(%opt == "vetd")
{
Admin::startVote(%clientId, "enable team damage", "etd", 0);
}
else if(%opt == "vdtd")
{
Admin::startVote(%clientId, "disable team damage", "dtd", 0);
}
else if(%opt == "etd")
{
Admin::setTeamDamageEnable(%clientId, true);
}
else if(%opt == "dtd")
{
Admin::setTeamDamageEnable(%clientId, false);
}
else if (%opt == "voteYes" && %cl == $curVoteCount)
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
Client::addMenuItem(%clientId, "8Kick " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "9Don't kick " @ Client::getName(%cl), "no " @ %cl);
return;
}
else if(%opt == "ban")
{
Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
Client::addMenuItem(%clientId, "8Ban " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "9Don't ban " @ Client::getName(%cl), "no " @ %cl);
return;
}
else if(%opt == "permaban")
{
Client::buildMenu(%clientId, "Confirm Perma-Ban:", "pbaffirm", true);
Client::addMenuItem(%clientId, "8Perma-Ban " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "9Don't Perma-Ban " @ Client::getName(%cl), "no " @ %cl);
return;
}
else if(%opt == "admin")
{
Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
if (%clientId.isSuperAdmin) {
Client::addMenuItem(%clientId, "1A-Admin " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "2M-Admin " @ Client::getName(%cl), "yesM " @ %cl);
Client::addMenuItem(%clientId, "3S-Admin " @ Client::getName(%cl), "yesS " @ %cl);
Client::addMenuItem(%clientId, "4Don't admin " @ Client::getName(%cl), "no " @ %cl);
}
else {
Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
}
return;
}
else if(%opt == "unadmin")
{
Client::buildMenu(%clientId, "Confirm unadmim:", "uaaffirm", true);
Client::addMenuItem(%clientId, "1Unadmin " @ Client::getName(%cl), "yes " @ %cl);
Client::addMenuItem(%clientId, "2Don't unadmin " @ Client::getName(%cl), "no " @ %cl);
return;
}
else if(%opt == "smatch")
{
Admin::startMatch(%clientId);
}
else if(%opt == "vcmission")
{
Admin::changeMissionMenu(%clientId, %opt);
return;
}
else if(%opt == "cmission")
{
Admin::changeMissionMenu(%clientId, %opt);
return;
}
else if (%opt == "cwinscore" && %clientId.isAdmin) // PORT
{
if ((%clientId.isServerSuperAdmin) || ($ArenaFixedWinningScore != 1) || ($Arena::MatchMode == 1)) {
Client::buildMenu(%clientId, "Change Winning Score:", "cwscore", true);
if (%clientId.isSuperAdmin) {
Client::addMenuItem(%clientId, "01 out of 1", 1);
Client::addMenuItem(%clientId, "12 out of 3", 2);
}
Client::addMenuItem(%clientId, "23 out of 5", 3);
Client::addMenuItem(%clientId, "34 out of 7", 4);
Client::addMenuItem(%clientId, "45 out of 9", 5);
if ($Arena::ScorelimitMax >= 6)
Client::addMenuItem(%clientId, "56 out of 11", 6);
if ($Arena::ScorelimitMax >= 7)
Client::addMenuItem(%clientId, "67 out of 13", 7);
if ($Arena::ScorelimitMax >= 8)
Client::addMenuItem(%clientId, "78 out of 15", 8);
if ($Arena::ScorelimitMax >= 9)
Client::addMenuItem(%clientId, "89 out of 17", 9);
if ($Arena::ScorelimitMax >= 10)
Client::addMenuItem(%clientId, "910 out of 19", 10);
}
return;
}
else if (%opt == "resetmatch" && %clientId.isAdmin) // PORT
{
Arena::ResetMatch();
messageall(0, Client::getName(%clientId) @ " has reset the match.");
return;
}
else if (%opt == "rerandomteams" && %clientId.isAdmin && $Arena::MatchMode == 0) // PORT
{
Client::buildMenu(%clientId, "Team:", "rrndteams", true);
Client::addMenuItem(%clientId, "1Only teamed players", "teamed " @ %clientId);
Client::addMenuItem(%clientId, "2All connected players", "all " @ %clientId);
return;
}
else if (%opt == "forcematch" && %clientId.isAdmin) // PORT
{
if (($Arena::MatchMode == 1) || ($Arena::MatchStatus == 0) || ($Arena::ForceMatchAcceptOverride == 1))
{
messageall(0, Client::getName(%clientId) @ " has forced the countdown to start");
Arena::ForceMatchStart();
}
return;
}
else if (%opt == "ereadytime" && %clientId.isAdmin && (%clientId.isSuperAdmin || $OnlySuperAdminCanChangeReadyUp != 1)) // PORT
{
$Arena::ReadyTime = true;
messageAll(0, Client::getName(%clientId) @ " has enabled ReadyUp Time Limit.");
return;
}
else if (%opt == "dreadytime" && %clientId.isAdmin && (%clientId.isSuperAdmin || $OnlySuperAdminCanChangeReadyUp != 1)) // PORT
{
$Arena::ReadyTime = false;
messageAll(0, Client::getName(%clientId) @ " has disabled ReadyUp Time Limit.");
return;
}
else if (%opt == "eautoteam" && %clientId.isAdmin && (%clientId.isSuperAdmin || $OnlySuperAdminCanChangeAutoJoin != 1)) // PORT
{
$Arena::AutoTeamJoin = true;
messageAll(0, Client::getName(%clientId) @ " has enabled AutoTeamJoin.");
return;
}
else if (%opt == "dautoteam" && %clientId.isAdmin && (%clientId.isSuperAdmin || $OnlySuperAdminCanChangeAutoJoin != 1)) // PORT
{
$Arena::AutoTeamJoin = false;
messageAll(0, Client::getName(%clientId) @ " has disabled AutoTeamJoin.");
return;
}
else if (%opt == "cstrip" && (%clientId.isSuperAdmin || ($TrustedAdminCanStripRegularAdmin == 1 && %clientId.isTrustedAdmin))) // PORT
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (%cl.isSuperAdmin)
{
if (%clientId.isServerSuperAdmin)
{
if (! %cl.isServerSuperAdmin)
{
%cl.isAdmin = false;
%cl.isTrustedAdmin = false;
%cl.isSuperAdmin = false;
Game::refreshClientScore(%cl);
}
}
}
else if (%cl.isTrustedAdmin)
{
if (%clientId.isSuperAdmin)
{
%cl.isAdmin = false;
%cl.isTrustedAdmin = false;
Game::refreshClientScore(%cl);
}
}
else if (%cl.isAdmin)
{
%cl.isAdmin = false;
Game::refreshClientScore(%cl);
}
}
messageAll(0, Client::getName(%clientId) @ " has stripped admin rights from the public.");
return;
}
else if (%opt == "givecaptain" && %clientId.isTeamCaptain) // PORT
{
if (%clientId.matchteam == %cl.matchteam)
{
%clientId.isTeamCaptain = false;
%cl.isTeamCaptain = true;
messageAll(0, Client::getName(%clientId) @ " has handed over the Team Captain rights to " @ Client::getName(%cl));
Game::refreshClientScore(%cl);
Game::refreshClientScore(%clientId);
}
return;
}
else if (%opt == "ematchmode" && %clientId.isAdmin) // PORT
{
if ($PubAdminsMayNotChangePubMatchMode == 1) {
if (%clientId.isSuperAdmin) {
}
else if (%clientId.isTrustedAdmin) {
}
else if (%clientId.isAdmin) {
return;
}
}
messageAll(0, Client::getName(%clientId) @ " has put the server into Match Mode.");
Arena::EnterMatchMode();
return;
}
else if (%opt == "epubmode" && %clientId.isAdmin) // PORT
{
if ($PubAdminsMayNotChangePubMatchMode == 1) {
if (%clientId.isSuperAdmin) {
}
else if (%clientId.isTrustedAdmin) {
}
else if (%clientId.isAdmin) {
return;
}
}
messageAll(0, Client::getName(%clientId) @ " has put the server into Public Play Mode.");
Arena::EnterPubMode();
return;
}
else if(%opt == "ctimelimit")
{
if((%clientId.isSuperAdmin && $OnlySuperAdminCanChangeTimeLimit == 1) || ($OnlySuperAdminCanChangeTimeLimit != 1))
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
}
else if(%opt == "reset")
{
if((%clientId.isSuperAdmin && $OnlySuperAdminCanResetServer == 1) || ($OnlySuperAdminCanResetServer != 1))
{
Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
Client::addMenuItem(%clientId, "1Reset", "yes");
Client::addMenuItem(%clientId, "2Don't Reset", "no");
return;
}
}
else if(%opt == "observe")
{
Observer::setTargetClient(%clientId, %cl);
return;
}
else if (%opt == "playerdetails")
{
%curItem = 0;
Client::buildMenu(%clientId, "Player Details", "options", true);
if(%clientId.isServerSuperAdmin)
{
%sel = %clientId.selClient;
%name = Client::getName(%sel);
%ip = Client::getTransportAddress(%sel);
Client::addMenuItem(%clientId, %curItem++ @ "Perma-Ban " @ %name, "permaban " @ %sel);
if(%sel.mutedGlobal)
Client::addMenuItem(%clientId, %curItem++ @ "Global Unmute " @ %name, "globalunmute " @ %sel);
else
Client::addMenuItem(%clientId, %curItem++ @ "Global Mute " @ %name, "globalmute " @ %sel);
Client::addMenuItem(%clientId, %curItem++ @ %ip @ " ", "");
}
return;
}
else if (%opt == "arenaop")
{
%curItem = 0;
Client::buildMenu(%clientId, "Options", "options", true);
if(%clientId.isAdmin)
{
if ((%clientId.isServerSuperAdmin) || ($ArenaFixedWinningScore != 1) || ($Arena::MatchMode == 1)) {
Client::addMenuItem(%clientId, %curItem++ @ "Change Winning Score", "cwinscore");
}
Client::addMenuItem(%clientId, %curItem++ @ "Reset Match", "resetmatch");
Client::addMenuItem(%clientId, %curItem++ @ "Force Match/Game Start", "forcematch");
if((%clientId.isSuperAdmin && $OnlySuperAdminCanChangeReadyUp == 1) || ($OnlySuperAdminCanChangeReadyUp != 1))
{
if ($DisableReadyUpTimer != 1)
{
if(!$Arena::Readytime)
Client::addMenuItem(%clientId, %curItem++ @ "Enable ReadyUp Timelimit", "ereadytime");
else
Client::addMenuItem(%clientId, %curItem++ @ "Disable ReadyUp Timelimit", "dreadytime");
}
}
if((%clientId.isSuperAdmin && $OnlySuperAdminCanChangeAutoJoin == 1) || ($OnlySuperAdminCanChangeAutoJoin != 1))
{
if(!$Arena::AutoTeamJoin)
Client::addMenuItem(%clientId, %curItem++ @ "Enable AutoTeamJoining", "eautoteam");
else
Client::addMenuItem(%clientId, %curItem++ @ "Disable AutoTeamJoining", "dautoteam");
}
if ($PubAdminsMayNotChangePubMatchMode == 1) {
if ((%clientId.isSuperAdmin) || (%clientId.isTrustedAdmin)) {
if(!$Arena::MatchMode) {
Client::addMenuItem(%clientId, %curItem++ @ "Enter Match Mode", "ematchmode");
}
else {
Client::addMenuItem(%clientId, %curItem++ @ "Enter Public Mode", "epubmode");
}
}
}
else {
if(!$Arena::MatchMode) {
Client::addMenuItem(%clientId, %curItem++ @ "Enter Match Mode", "ematchmode");
}
else {
Client::addMenuItem(%clientId, %curItem++ @ "Enter Public Mode", "epubmode");
}
}
if (%clientId.isSuperAdmin || (($TrustedAdminCanStripRegularAdmin == 1) && %clientId.isTrustedAdmin)) {
Client::addMenuItem(%clientId, %curItem++ @ "Strip Public Admins", "cstrip");
}
if($Arena::MatchMode == 0) {
Client::addMenuItem(%clientId, %curItem++ @ "Re-Randomize teams", "rerandomteams");
}
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
if(%clientId.isAdmin)
{
%atype = getWord(%opt, 0);
if ((%atype == "yes") || (%atype == "yesM") || (%atype == "yesS"))
{
%cl = getWord(%opt, 1);
%isProhibited = Admin::LizCheckNoAdminIPList(%cl);
if (%isProhibited == 1)
{
Client::sendMessage(%clientId, 0, "You can not make " @ Client::getName(%cl) @ " into an admin.");
}
else
{
if ($ArenaMaxNumberOfAdmins == 0) {
Client::sendMessage(%clientId, 0, "The server administrator has disabled this feature.");
}
else if ($ArenaMaxNumberOfAdmins < 0) {
if ((%atype == "yesS") && (%clientId.isSuperAdmin)) {
%cl.isSuperAdmin = true;
%cl.isTrustedAdmin = true;
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Super admin.");
}
else if ((%atype == "yesM") && (%clientId.isTrustedAdmin)) {
%cl.isTrustedAdmin = true;
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Moderator admin.");
}
else {
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
}
Game::refreshClientScore(%cl);
}
else {
%admCnt = Arena::CountNumberOfAdmins(-1);
if (%admCnt < $ArenaMaxNumberOfAdmins) {
if ((%atype == "yesS") && (%clientId.isSuperAdmin)) {
%cl.isSuperAdmin = true;
%cl.isTrustedAdmin = true;
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Super admin.");
}
else if ((%atype == "yesM") && (%clientId.isTrustedAdmin)) {
%cl.isTrustedAdmin = true;
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Moderator admin.");
}
else {
%cl.isAdmin = true;
messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
}
Game::refreshClientScore(%cl);
}
else {
Client::sendMessage(%clientId, 0, "Your request to admin " @ Client::getName(%cl) @ " was denied because the number of admins limit (" @ $ArenaMaxNumberOfAdmins @ ") has been reached.");
}
}
}
}
}
Game::menuRequest(%clientId);
}
function processMenuUAAffirm(%clientId, %opt)
{
if(getWord(%opt, 0) == "yes")
{
%cl = getWord(%opt, 1);
if (%clientId.isServerSuperAdmin)
{
if (%cl.isServerSuperAdmin) {
Client::sendMessage(%clientId, 0, "Impossible to remove admin from " @ Client::getName(%cl));
}
else if (%cl.isAdmin)
{
%cl.isSuperAdmin = false;
%cl.isTrustedAdmin = false;
%cl.isAdmin = false;
messageAll(0, Client::getName(%clientId) @ " has removed admin from " @ Client::getName(%cl));
Game::refreshClientScore(%cl);
}
}
else if (%clientId.isSuperAdmin)
{
if (%cl.isServerSuperAdmin || %cl.isSuperAdmin) {
Client::sendMessage(%clientId, 0, "Impossible to remove admin from " @ Client::getName(%cl));
}
else if (%cl.isAdmin)
{
%cl.isSuperAdmin = false;
%cl.isTrustedAdmin = false;
%cl.isAdmin = false;
messageAll(0, Client::getName(%clientId) @ " has removed admin from " @ Client::getName(%cl));
Game::refreshClientScore(%cl);
}
}
else if (%clientId.isTrustedAdmin)
{
if (%cl.isServerSuperAdmin || %cl.isSuperAdmin || %cl.isTrustedAdmin) {
Client::sendMessage(%clientId, 0, "Impossible to remove admin from " @ Client::getName(%cl));
}
else if (%cl.isAdmin)
{
%cl.isSuperAdmin = false;
%cl.isTrustedAdmin = false;
%cl.isAdmin = false;
messageAll(0, Client::getName(%clientId) @ " has removed admin from " @ Client::getName(%cl));
Game::refreshClientScore(%cl);
}
}
else
{
Client::sendMessage(%clientId, 0, "You can not remove admin from " @ Client::getName(%cl));
}
}
Game::menuRequest(%clientId);
}
function processMenuPBAffirm(%clientId, %opt)
{
if(getWord(%opt, 0) == "yes") {
if(%clientId.isServerSuperAdmin) {
Admin::kick(%clientId, getWord(%opt, 1), "pban");
}
}
Game::menuRequest(%clientId);
}
function processMenuCWScore(%clientId, %opt)
{
if(!%clientId.isAdmin) return; // PORT
if(!(%clientId.isServerSuperAdmin || $ArenaFixedWinningScore != 1 || $Arena::MatchMode == 1)) return; // PORT: same rule as the menu
%opt = floor(%opt); // PORT
if ((%opt <= 0) || (%opt > $Arena::ScorelimitMax))
{
Arena::TabMenuExploit(%clientId);
return;
}
messageAll(0, Client::getName(%clientId) @ " has changed the Winning Score to " @ %opt);
$Arena::Scorelimit = %opt;
}
function processMenuPickTeam(%clientId, %team, %adminClient)
{
if (%team == "") {
Arena::TabMenuExploit(%clientId);
return;
}
if ((%team != "-2") && (%team != "-1") && (%team != "0") && (%team != "1") && (%team != "9"))
{
Arena::TabMenuExploit(%clientId);
return;
}
if(%team != -1 && %team == Client::getTeam(%clientId))
return;
if(%clientId.lock && %adminClient != "")
{
if ($AllAdminsCanChangeLockedPlayerTeam == 1)
{
messageAll(0, Client::getname(%clientId) @ " has been unlocked by " @ Client::getname(%adminClient) @ ".");
%clientId.lock = false;
}
else
{
Client::sendMessage(%adminClient,3, Client::getName(%clientId) @ " has locked himself out of play.  He will not be able to join a team until he selects a team or unlocks himself from the Tab Menu.");
return;
}
}
if(%clientId.observerMode == "justJoined")
{
%clientId.observerMode = "";
centerprint(%clientId, "");
}
if (%team == 9 && %clientId.lock)
{
messageAll(0, Client::getname(%clientId) @ " has unlocked himself.");
Client::sendMessage(%clientId,3, "You can join the game by selecting a team using the Tab Menu.");
%clientId.lock = false;
%team = -2;
}
else if(%team != 9)
{
%clientId.lock = false;
}
else
{
%clientId.lock = true;
messageAll(0, Client::getname(%clientId) @ " has locked himself out of play.  He will be unable to join the game until he unlocks himself via the Player Menu.");
Client::sendMessage(%clientId,3, "You can join the game again by selecting a team using the Tab Menu.");
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
centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 10);
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
{
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDurationReadyUpDisabled);
}
else {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDuration);
}
}
}
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
{
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDurationReadyUpDisabled);
}
else {
schedule("Arena::CheckReadyState(" @ %clientId @ ");", $ArenaCheckReadyStateDuration);
}
}
}
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
{
Observer::nextObservable(%client);
}
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
else if(%client.observerMode == "pregame" && ($Arena::MatchStatus == 0 || ($Arena::MatchStatus == 2 && $Arena::MatchMode == 1 && %client.isTeamCaptain)))
{
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
%client.notready = "";
}
else {
if(%client.notready)
{
%client.notready = "";
MessageAll(0, Client::getName(%client) @ " is READY.");
if ($Arena::MatchMode == 1) {
centerprint(%client, $PreGameMessage[%client.matchteam] @ "\nWaiting for teams to be ready (FIRE if not ready).", 0);
}
else {
centerprint(%client, $PreGameMessage[%client.matchteam] @ "\nWaiting for teams to be ready.", 0);
}
Arena::PreGameMode();
}
else
{
if ($Arena::MatchMode == 1)
{
%client.notready = true;
MessageAll(0, Client::getName(%client) @ " is NOT READY.");
bottomprint(%client, $PreGameMessage[%client.matchteam] @ "Press FIRE when ready.", 0);
}
}
}
}
}
function Game::startMatch()
{
$matchStarted = true;
$missionStartTime = getSimTime();
messageAll(0, "Match started.");
Game::resetScores();
%numTeams = getNumTeams();
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
Game::refreshClientScore(%cl);
}
Game::checkTimeLimit();
}
function Game::playerSpawn(%clientId, %respawn)
{
if(!$ghosting)
return false;
Client::clearItemShopping(%clientId);
%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
if(!%respawn)
{
bottomprint(%clientId, "<jc><f0>Tribes Arena Version " @ $Arena::Version @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
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
if ($Arena::MatchStatus != 1)
{
%clientId.observerMode = "pregame";
Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
%clientId.notready = "";
centerprint(%clientId, $Server::joinMOTD @ "\n\n<f1><jc>" @ $PreGameMessage[%clientId.matchteam] @ "\n", 0);
}
else {
%clientId.notready = true;
centerprint(%clientId, $Server::joinMOTD @ "\n\n<f1><jc>" @ $PreGameMessage[%clientId.matchteam] @ "\n" @ $Arena::ReadyUpMessage, 0);
}
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
function Game::initialMissionDrop(%clientId)
{
Client::setGuiMode(%clientId, $GuiModePlay);
GameBase::setTeam(%clientId, -1);
Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
%camSpawn = Game::pickObserverSpawn(%clientId);
Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn),
GameBase::getRotation(%camSpawn), true, true);
%clientId.observerMode = "pickingTeam";
if($Arena::MatchStatus != 0)
{
%clientId.observerMode = "observerFly";
if($Arena::MatchMode)
{
bottomprint(%clientId, $Server::JoinMOTD @
"\n\n<jc><f1>Server is running Tribes Arena v" @ $Arena::Version @
" and is in match mode. Please wait until its finished. " @
"Score limit is " @ $Arena::Scorelimit @ "\n" @
"AutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\n" @
"ReadyUp Timer is " @ $Arena::ReadyTime, 5);
}
else
{
bottomprint(%clientId, $Server::JoinMOTD @
"\n\n<jc><f1>Server is running Tribes Arena v" @ $Arena::Version @ " and is in open play mode. " @
"You will spawn as soon as this game is over. " @
"Score limit is " @ $Arena::Scorelimit @ "\n" @
"AutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\n" @
"ReadyUp Timer is " @ $Arena::ReadyTime, 5);
processMenuPickTeam(%clientId, -1);
}
Game::RefreshClientScore(%clientId);
return;
}
else
{
bottomprint(%clientId, "<jc><f1>Server is running Tribes Arena v" @ $Arena::Version @ "." @
"Match has not yet started, Pick a Team. " @
"Score limit is " @ $Arena::Scorelimit @ "\n" @
"AutoTeamJoin is " @ $Arena::AutoTeamJoin @ "\n" @
"ReadyUp Timer is " @ $Arena::ReadyTime, 5);
if ($Arena::AutoTeamJoin)
processMenuPickTeam(%clientId, -1);
else
processMenuPickTeam(%clientId, -2);
}
%clientId.justConnected = "";
Game::RefreshClientScore(%clientId);
Client::sendMessage(%clientId, 1, "Hello " @ Client::getName(%clientId) @ ", and welcome to Tribes Arena " @ $Arena::Version @ ".  Please hit 'O' to review the rules and objects of Arena.  Also, you can visit " @ $Arena::WebSiteURL @ " for Tribes Arena downloads. Have fun!");
}
function Game::onPlayerConnected(%playerId)
{
Arena::ResetPlayerMapScore(%playerId);
Arena::ResetPlayerTotalScore(%playerId);
Arena::ComputePlayerRatios(%playerId);
%playerId.justConnected = true;
%playerId.matchteam = -2;
%playerId.FreeInvTimer = false;
$menuMode[%playerId] = "None";
%playerId.onteam = " ";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
%playerId.muted[%cl] = "";
%playerId.mutedName[%cl] = "";
%playerId.muteGlobal = "";
%playerId.muteGlobalName = "";
}
Game::refreshClientScore(%playerId);
%playerId.VoteIncrementalDelay = 0;
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
LizStats::UpdateServerStatsTotalConnects(1);
ObjectiveMission::setObjectiveHeading();
}
}
function Client::onKilled(%playerId, %killerId, %damageType)
{
echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
%playerId.guiLock = true;
Client::setGuiMode(%playerId, $GuiModePlay);
if(%playerId.IsDeadNow == 1) {
return;
}
%playerId.IsDeadNow = 1;
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
Client::sendMessage(%playerId,0,"~warenafatality.wav");
if(!%killerId)
{
messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
%playerId.scoreDeaths++;
%playerId.totalDeaths++;
Arena::ComputePlayerRatios(%playerId);
%clientteam = Client::getTeam(%client);
$TeamNbDeaths[%clientteam]++;
ObjectiveMission::refreshTeamScores();
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1)) {
LizStats::UpdateServerStatsTotalDeaths(1);
}
}
else if(%killerId == %playerId)
{
if (%damageType == $OOBDamageType) {
%oopsMsg = %victimName @ " dies out of mission area.";
}
else {
%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
}
messageAll(0, %oopsMsg, $DeathMessageMask);
%playerId.score--;
%playerId.scoreSuicide++;
%playerId.totalSuicide++;
%playerId.scoreDeaths++;
%playerId.totalDeaths++;
Arena::ComputePlayerRatios(%playerId);
Arena::ComputePlayerRatios(%killerId);
%playerteam = Client::getTeam(%playerId);
$TeamNbDeaths[%playerteam]++;
ObjectiveMission::refreshTeamScores();
if ($Arena::MatchStatus != 1)
{
schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
}
Game::refreshClientScore(%playerId);
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1)) {
LizStats::UpdateServerStatsTotalSuicides(1);
LizStats::UpdateServerStatsTotalDeaths(1);
}
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
%playerId.scoreDeaths++;
%playerId.totalDeaths++;
%playerId.scoreTKed++;
%playerId.totalTKed++;
%killerId.scoreTKs++;
%killerId.totalTKs++;
%killerId.score--;
Arena::ComputePlayerRatios(%playerId);
Arena::ComputePlayerRatios(%killerId);
Game::refreshClientScore(%playerId);
Game::refreshClientScore(%killerId);
%playerteam = Client::getTeam(%playerId);
$TeamNbDeaths[%playerteam]++;
ObjectiveMission::refreshTeamScores();
if (%killerId.scoreTKs == 1)
%scoTKth = %killerId.scoreTKs @ "st";
else if (%killerId.scoreTKs == 2)
%scoTKth = %killerId.scoreTKs @ "nd";
else
%scoTKth = %killerId.scoreTKs @ "th";
if (($WarnTKersWithTheirTotalTKCount == 1) && ($Arena::MatchMode != 1))
{
if ($UseNewScoringSystem == 1) {
Client::sendMessage(%killerId,1,"You have TK'd " @ %victimName @ ". You have lost one kill.");
Client::sendMessage(%playerId,0,"You have been TK'd by " @ Client::getName(%killerId) @ ".");
}
else {
Client::sendMessage(%killerId,1,"You have TK'd " @ %victimName);
Client::sendMessage(%playerId,0,"You have been TK'd by " @ Client::getName(%killerId));
}
Client::sendMessage(%killerId,1,"This is your " @ %scoTKth @ " TK on this map (TK:K ratio of " @ %killerId.scoreTKKillRatio @ ")");
Client::sendMessage(%playerId,0,"This was his " @ %scoTKth @ " TK on this map (TK:K ratio of " @ %killerId.scoreTKKillRatio @ ")");
}
if ($WarnAdminsWhenTKer == 1)
{
if ((%killerId.scoreTKKillRatio > 1) || (%killerId.score <= -2))
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%cl.isAdmin) || (%cl.isTrustedAdmin) || (%cl.isSuperAdmin))
{
Client::sendMessage(%cl, 1, %victimName @ " has been TK'd by " @ Client::getName(%killerId));
Client::sendMessage(%cl, 1, "This was " @ Client::getName(%killerId) @ "'s " @ %scoTKth @ " TK on this map (TK:K ratio of " @ %killerId.scoreTKKillRatio @ ")");
}
}
}
}
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1)) {
LizStats::UpdateServerStatsTotalTKs(1);
LizStats::UpdateServerStatsTotalDeaths(1);
}
}
else
{
%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
%victimName, %killerGender, %playerGender);
messageAll(0, %obitMsg, $DeathMessageMask);
%playerId.scoreDeaths++;
%killerId.score++;
%killerId.scoreKills++;
%playerId.totalDeaths++;
%killerId.totalKills++;
Arena::ComputePlayerRatios(%playerId);
Arena::ComputePlayerRatios(%killerId);
Game::refreshClientScore(%killerId);
Game::refreshClientScore(%playerId);
%killerteam = Client::getTeam(%killerId);
$TeamNbKills[%killerteam]++;
%playerteam = Client::getTeam(%playerId);
$TeamNbDeaths[%playerteam]++;
ObjectiveMission::refreshTeamScores();
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1)) {
LizStats::UpdateServerStatsTotalKills(1);
LizStats::UpdateServerStatsTotalDeaths(1);
ObjectiveMission::setObjectiveHeading();
}
}
}
if ($Arena::MatchStatus == 1)
{
schedule("Arena::PickTeam(" @ %playerId @ ", -2);", 2);
schedule("Arena::CheckTeamDeath( " @ %playerId.matchteam @ ");", 3);
schedule("Arena::CheckAllTeamDeaths();", 4);
}
else
{
Arena::PickTeam(%playerId, -2);
}
}
function Client::leaveGame(%clientId)
{
%set = nameToID("MissionCleanup/ObjectivesSet");
for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++) {
GameBase::virtual(%obj, "clientDropped", %clientId);
}
if ((%clientId.isTeamCaptain == true) && ($Arena::MatchMode == 1))
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
schedule("Arena::GameOver(" @ %otherteam @ ");", 4); // PORT
}
}
if ($Arena::MatchMode == 0) {
Arena::CheckIfTeamsAreEven();
}
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if ($UseNewScoringSystem == 1) {
LizStats::UpdateMapStatsCheckClientRank(%clientId);
}
else {
LizStats::UpdateMapStatsCheckClientScore(%clientId);
}
}
}
function Server::loadMission(%missionName, %immed)
{
if($loadingMission) {
return;
}
%missionFile = "missions\\" $+ %missionName $+ ".mis";
if(File::FindFirst(%missionFile) == "")
{
%missionName = $firstMission;
%missionFile = "missions\\" $+ %missionName $+ ".mis";
if(File::FindFirst(%missionFile) == "")
{
echo("MISC: invalid nextMission and firstMission...");
echo("MISC: aborting mission load.");
return;
}
}
echo("MISC: Notifying players of mission change: ", getNumClients(), " in game");
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
exec(comchat);
//PORT-OFF: exec(gui);
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
resetSimTime();
if (($LizStatsEnable == 1) && ($LizStatsLoaded == 1) && ($LizStatsSaveAfterMap == 1))
{
LizStats::SaveAll();
}
newObject(ConsoleScheduler, SimConsoleScheduler);
if(!%immed)
schedule("Server::finishMissionLoad();", 18);
else
Server::finishMissionLoad();
}
function Arena::CheckTeamDeath(%team)
{
%teamCount = Arena::CountTeamPlayers(%team);
%otherteam = 1 - %team;
if (%teamCount == 1) {
%gender = Arena::LastAlivePlayerGender(%team);
if (%gender == 0)
messageAll(0, getTeamName(%team) @ " has one member left.  FINISH HER!~warenafinisher.wav");
else
messageAll(0, getTeamName(%team) @ " has one member left.  FINISH HIM!~warenafinishim.wav");
}
if (%teamCount < 1 && $Arena::MatchStatus == 1)
{
$Arena::MatchStatus = 2;
centerPrintAll("<jc>" @ getTeamName(%otherTeam) @ " has won the game", 3);
schedule("Arena::GameOver(" @ %otherteam @ ");", 4);
}
}
function Arena::CheckAllTeamDeaths()
{
if ($Arena::MatchStatus == 1)
{
%teamCount[0] = Arena::CountGameStartTeamPlayers(0);
%teamCount[1] = Arena::CountGameStartTeamPlayers(1);
if ((%teamCount[0] == 0) && (%teamCount[1] > 0))
{
$Arena::MatchStatus = 2;
centerPrintAll("<jc>" @ getTeamName(1) @ " has won the game", 3);
schedule("Arena::GameOver(1);", 4);
}
else if ((%teamCount[0] > 0) && (%teamCount[1] == 0))
{
$Arena::MatchStatus = 2;
centerPrintAll("<jc>" @ getTeamName(0) @ " has won the game", 3);
schedule("Arena::GameOver(0);", 4);
}
else if ((%teamCount[0] == 0) && (%teamCount[1] == 0))
{
$Arena::MatchStatus = 2;
centerPrintAll("<jc>Both teams have no more alive players... Tie game.", 3);
schedule("Arena::TieGame(0);", 4);
}
}
}
function Arena::GameOver(%winningTeam)
{
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if ($UseNewScoringSystem == 1) {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
LizStats::UpdateMapStatsCheckClientRank(%cl);
}
}
else {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
LizStats::UpdateMapStatsCheckClientScore(%cl);
}
}
}
if (%winningTeam == 0) {
LizStats::UpdateMapStatsGamesWonTeam1(1);
}
else if (%winningTeam == 1) {
LizStats::UpdateMapStatsGamesWonTeam2(1);
}
}
ObjectiveMission::setObjectiveHeading();
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (%cl.matchteam != -2)
{
%player = Client::getOwnedObject(%cl);
if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
{
playNextAnim(%cl);
Player::kill(%cl);
if ($Arena::MatchMode == 1 && %cl.isTeamCaptain) {
%cl.notready = true;
}
}
Arena::PickTeam(%cl, -2);
}
}
$Arena::ForceMatchAcceptOverride = 0;
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
if ($TeamMatchScore[%winningTeam] >= $Arena::Scorelimit || Arena::CountTeam(1 - %winningTeam) == 0)
{
$Arena::ReadyUpMessage = $Arena::ReadyUpMessageBackup;
Arena::MatchCompleted(%winningTeam);
if ($Arena::MatchStatus == 3)
{
schedule("Arena::ResetMatch();", 11);
}
return;
}
else
{
if ($Arena::MatchMode == 1)
$Arena::ReadyUpMessage = "Only your Captain needs to ready";
else
$Arena::ReadyUpMessage = "";
schedule("Arena::PutClientsBackOnTeams();", 6);
schedule("Arena::PreGameMode();", 7);
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
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
%cl.notready = "";
}
else {
%cl.notready = true;
}
}
}
}
function Arena::MatchCompleted(%winningTeam)
{
centerPrintAll("<jc>" @ getTeamName(%winningTeam) @
" has won the match.  They all get 5 points!", 4);
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (%cl.matchteam == %winningTeam)
{
%cl.score = %cl.score + 5;
%cl.scoreMatchWon++;
%cl.totalMatchWon++;
Arena::ComputePlayerRatios(%cl);
Game::refreshClientScore(%cl);
Client::sendMessage(%cl,0,"~warenaoutstanding.wav");
}
else
{
%cl.scoreMatchLost++;
%cl.totalMatchLost++;
Client::sendMessage(%cl,0,"~wflagcapture.wav");
}
}
$Arena::AutoEvenLastScore = -2;
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if (%winningTeam == 0)
LizStats::UpdateMapStatsMatchesWonTeam1(1);
else if (%winningTeam == 1)
LizStats::UpdateMapStatsMatchesWonTeam2(1);
}
schedule("Arena::ResetMatch();", 4);
$Arena::NumberMatchLimit--;
}
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
for (%i = 0; %i < getNumTeams(); %i++)
$TeamMatchScore[%i] = 0;
ObjectiveMission::refreshTeamScores();
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
%player = Client::getOwnedObject(%cl);
%cl.matchteam = -2;
%cl.isTeamCaptain = false;
%cl.FreeInvTimer = false;
if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
{
playNextAnim(%cl);
Player::kill(%cl);
}
if (!$Arena::AutoTeamJoin)
{
processMenuPickTeam(%cl, -2);
bottomprint(%cl, "<jc><f1>Server is running Tribes Arena v" @ $Arena::Version @ " and is in Pre-Match Mode. Pick a Team.  Score limit is " @ $Arena::Scorelimit, 5);
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
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
%cl.notready = "";
}
else {
%cl.notready = true;
}
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
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
LizStats::UpdateServerStatsTotalMatchesPlayed(1);
}
}
function Arena::CheckReadyStatus()
{
if ($Arena::MatchMode == 0)
{
if ($Arena::MatchStatus != 0)
return true;
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
return true;
}
%NotReadyString = "Clients not ready:";
%NotReadyCount = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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
function Arena::PreGameMode()
{
if (Arena::CountTeamPlayers(0) < 1 || Arena::CountTeamPlayers(1) < 1)
{
messageAll(0, "Teams not full, waiting for more players");
$Arena::ForceMatchAcceptOverride = 1;
}
else
{
if (Arena::CheckReadyStatus())
{
if ($Arena::MatchStatus == 3)
return;
if ($Arena::MatchMode == 0) {
Arena::CheckIfTeamsAreEven();
}
ObjectiveMission::setObjectiveHeading();
if ($Arena::MatchStatus == 0)
messageAll(0, "Arena Battle Starts in 10 seconds~wrumble.wav");
else
messageAll(0, "Arena Battle Starts in 10 seconds");
$Arena::MatchStatus = 3;
if ($Arena::MatchMode == 0) {
Arena::CheckIfTeamsAreEven();
}
schedule("messageAll(0, \"Arena Battle Starts in 5 seconds\");", 5);
schedule("messageAll(0, \"Arena Battle Starts in 4 seconds\");", 6);
schedule("messageAll(0, \"Arena Battle Starts in 3 seconds\");", 7);
schedule("messageAll(0, \"Arena Battle Starts in 2 seconds\");", 8);
schedule("messageAll(0, \"Arena Battle Starts in 1 seconds\");", 9);
schedule("Arena::StartGame();", 10);
}
}
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if ($UseNewScoringSystem == 1) {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
LizStats::UpdateMapStatsCheckClientRank(%cl);
}
}
else {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
LizStats::UpdateMapStatsCheckClientScore(%cl);
}
}
}
}
function Arena::ForceMatchStart()
{
if (($Arena::MatchMode == 1) || ($Arena::MatchStatus == 0) || ($Arena::ForceMatchAcceptOverride == 1))
{
$Arena::ForceMatchAcceptOverride = 0;
}
else
{
return;
}
if ($Arena::MatchMode == 0) {
Arena::CheckIfTeamsAreEven();
}
ObjectiveMission::setObjectiveHeading();
if ($Arena::MatchStatus == 0)
messageAll(0, "Arena Battle Starts in 10 seconds~wrumble.wav");
else
messageAll(0, "Arena Battle Starts in 10 seconds");
$Arena::MatchStatus = 3;
if ($Arena::MatchMode == 0)
{
Arena::CheckIfTeamsAreEven();
}
schedule("messageAll(0, \"Arena Battle Starts in 5 seconds\");", 5);
schedule("messageAll(0, \"Arena Battle Starts in 4 seconds\");", 6);
schedule("messageAll(0, \"Arena Battle Starts in 3 seconds\");", 7);
schedule("messageAll(0, \"Arena Battle Starts in 2 seconds\");", 8);
schedule("messageAll(0, \"Arena Battle Starts in 1 seconds\");", 9);
schedule("Arena::StartGame();", 10);
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
if ($UseNewScoringSystem == 1) {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
LizStats::UpdateMapStatsCheckClientRank(%cl);
}
}
else {
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
LizStats::UpdateMapStatsCheckClientScore(%cl);
}
}
}
}
function Arena::StartGame()
{
$Arena::ForceMatchAcceptOverride = 0;
$Arena::MatchStatus = 1;
$Arena::GameStartTime = getSimTime();
Arena::CheckGameTimeLimit();
Arena::ResetItemCounts();
messageAll(0, "FIGHT!!!!~wfight.wav");
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (Client::getTeam(%cl) != %cl.matchteam && %cl.matchteam != -2) {
Arena::PickTeam(%cl, %cl.matchteam);
}
%cl.InvTrips = 0;
%cl.IsDeadNow = 0;
%cl.InvLastBuyTime = -1;
%cl.InvBuyCount = 0;
%cl.EnergyWarning = 0;
if (%cl.matchteam != -2)
{
%cl.observerMode = "";
Client::setControlObject(%cl, Client::getOwnedObject(%cl));
bottomprint(%cl, "", 0);
}
%cl.gameStartTeam = %cl.matchteam;
}
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
LizStats::UpdateServerStatsTotalGamesPlayed(1);
}
if ($AutoObsAFKers == 1)
{
Arena::GetAllPlayersPosition(0);
if ($Arena::MatchMode == 0) {
schedule("Arena::CheckAllPlayersForAFK(" @ $Arena::GameStartTime @ ");", $Arena::AFKDetectTimeFirstCheck);
}
}
}
function Arena::LastAlivePlayerGender(%team)
{
%teamCount = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (Client::getTeam(%cl) == %team)
{
if(!String::ICompare(Client::getGender(%cl), "Male"))
{
return 1;
}
else
{
return 0;
}
}
}
echo("MISC: Returning default stuff");
return 1;
}
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
function Arena::CountAliveTeamPlayers(%team)
{
%teamCount = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((Client::getTeam(%cl) == %team) && (%cl.onteam == "*"))
%teamCount++;
}
return %teamCount;
}
function Arena::CountGameStartTeamPlayers(%team)
{
%teamCount = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%cl.gameStartTeam == %team) && (%cl.onteam == "*"))
%teamCount++;
}
return %teamCount;
}
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
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
}
else {
if (%clientId.notready && $Arena::ReadyTime && ($Arena::MatchStatus == 0 || $Arena::MatchStatus == 2))
{
processMenuPickTeam(%clientId, -2);
messageAll(0, Client::getName(%clientId) @ " didn't ready up in time and was placed in observer mode.");
}
}
if ($Arena::MatchStatus == 0 || $Arena::MatchStatus == 2)
{
Arena::PreGameMode();
}
}
function ceiling(%number)
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
$Arena::Scorelimit = $Arena::ScorelimitMatchMode;
messageAll(0, "Server has changed the Winning Score to " @ $Arena::Scorelimit);
$Arena::MatchMode = 1;
$TeamItemMax[LaserRifle] = 2;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
Arena::ResetPlayerMapScore(%cl);
Arena::ComputePlayerRatios(%cl);
Game::refreshClientScore(%cl);
}
Arena::ResetMatch();
}
function Arena::EnterPubMode()
{
if ($Arena::MatchMode == 0)
return;
$Arena::AutoTeamJoin = true;
$Arena::ReadyTime = true;
$Arena::Scorelimit = $Arena::ScorelimitPubMode;
messageAll(0, "Server has changed the Winning Score to " @ $Arena::Scorelimit);
$Arena::MatchMode = 0;
if ($SniperRifleLimitInPubMode >= 0) {
$TeamItemMax[LaserRifle] = $SniperRifleLimitInPubMode;
}
else {
$TeamItemMax[LaserRifle] = "";
}
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
Arena::ResetPlayerMapScore(%cl);
Arena::ComputePlayerRatios(%cl);
Game::refreshClientScore(%cl);
}
Arena::ResetMatch();
}
function Arena::CheckGameTimeLimit()
{
if ($Arena::GameTimeLimit == 0 || $Arena::MatchStatus != 1)
return;
%currentTime = getSimTime();
%currentTime = floor(%currentTime);
$Arena::GameStartTime = floor($Arena::GameStartTime);
if (($Arena::GameStartTime + $Arena::GameTimeLimit) <= %currentTime)
{
Arena::GameTimeLimitHit();
}
else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 5) == %currentTime)
{
messageAll(0, "5 SECONDS LEFT IN THE GAME!!!");
schedule("Arena::CheckGameTimeLimit();", 5);
}
else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 10) == %currentTime)
{
messageAll(0, "10 SECONDS LEFT IN THE GAME!!!");
schedule("Arena::CheckGameTimeLimit();", 5);
}
else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 30) == %currentTime)
{
messageAll(0, "30 seconds left, better hurry!!!");
schedule("Arena::CheckGameTimeLimit();", 5);
}
else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 60) == %currentTime)
{
messageAll(0, "1 Minute left in the Game");
schedule("Arena::CheckGameTimeLimit();", 5);
}
else if (($Arena::GameStartTime + $Arena::GameTimeLimit - 120) == %currentTime)
{
messageAll(0, "2 Minutes left in the Game");
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
messageAll(0, getTeamName(0) @ " has WON!");
Arena::GameOver(0);
}
else if (Arena::CountTeamPlayers(0) < Arena::CountTeamPlayers(1))
{
messageAll(0, getTeamName(1) @ " has WON!");
Arena::GameOver(1);
}
else
{
Arena::TieGame(1);
}
}
function Arena::TieGame(%gamelimitexpired)
{
if (%gamelimitexpired == 1) {
messageAll(0, "The timelimit has run out, and both teams have the same amount of units left.  The game will be replayed.");
}
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
if (($DisableReadyUpTimer == 1) && ($Arena::MatchMode == 0)) {
%cl.notready = "";
}
else {
%cl.notready = false;
}
bottomprint(%cl, $PreGameMessage[%cl.matchteam] @ "Game starting in 10 seconds", 0);
}
}
Arena::PreGameMode();
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
if(!buyItem(%client,%item, 1))
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
function Arena::SetFreeTimer(%clientId)
{
%clientId.FreeInvTimer = false;
Client::sendMessage(%clientId, 0, "Your shopping trip has now been recorded, you have " @ 2 - %clientId.InvTrips @ " left");
}
function remoteSelectClient(%clientId, %selId)
{
%selId = floor(%selId); // PORT: client-supplied; it is pasted into every menu code
if(%clientId.selClient != %selId)
{
%clientId.selClient = %selId;
if(%clientId.menuMode == "options") {
Game::menuRequest(%clientId);
}
remoteEval(%clientId, "setInfoLine", 1,
"Player Info for " @ Client::getName(%selId) @ ":");
if (($ReplaceTabMenuPlayerInfoByStats == 1) && ($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
{
remoteEval(%clientId, "setInfoLine", 2, "Map Score: " @ %selId.score);
remoteEval(%clientId, "setInfoLine", 3, %selId.scoreKills @ " kills, " @
%selId.scoreDeaths @ " deaths " @
"(K:D " @ %selId.scoreKillDeathRatio @ ")"
);
remoteEval(%clientId, "setInfoLine", 4, %selId.scoreTKs @ " TKs " @
"(TK:K " @ %selId.scoreTKKillRatio @ ")"
);
remoteEval(%clientId, "setInfoLine", 5, %selId.scoreSuicide @ " suicides " @
"(S:D " @ %selId.scoreSuicideDeathRatio @ "%), " @
"TKed " @ %selId.scoreTKed @ " times"
);
remoteEval(%clientId, "setInfoLine", 6, "Won " @ %selId.scoreMatchWon @
" of " @ (%selId.scoreMatchWon+%selId.scoreMatchLost) @ " matches " @
"(W:L " @ %selId.scoreTeamVictoryRatio @ "%)"
);
}
else
{
remoteEval(%clientId, "setInfoLine", 2,
"Real Name: " @ $Client::info[%selId, 1] @ ", " @
"Email: " @ $Client::info[%selId, 2]);
remoteEval(%clientId, "setInfoLine", 3,
"Tribe: " @ $Client::info[%selId, 3]);
remoteEval(%clientId, "setInfoLine", 4,
"URL: " @ $Client::info[%selId, 4]);
remoteEval(%clientId, "setInfoLine", 5,
""); // PORT: info field 5 is not shown
remoteEval(%clientId, "setInfoLine", 6, "Stats: " @
%selId.scoreKills @ " kills, " @
%selId.scoreDeaths @ " deaths, " @
%selId.scoreTKs @ " TKs, " @
%selId.scoreSuicide @ " suicides.");
}
}
}
function AutoKickBlanks(%clientId)
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" was kicked for having a blank name.");
Net::kick(%clientId, "Get a real name.");
}
function AutoKickPlayer(%clientId)
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" was kicked by Auto-Kick.");
Net::kick(%clientId, "Critical error #1.");
}
function Server::onClientConnect(%clientId)
{
if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
{
%clientId.isAdmin = true;
%clientId.isSuperAdmin = true;
}
echo("CONNECT: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" " @ Client::getTransportAddress(%clientId));
%clip = Client::getTransportAddress(%clientId);
for (%akidx = 1; %akidx <= $AutoKickIPListCount; %akidx++)
{
if ($AutoKickIPList[%akidx] != "")
{
%result = String::FindSubStr(%clip, $AutoKickIPList[%akidx]);
if ((%result != -1) && (%result != ""))
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" will be kicked by Auto-Kick.");
BanList::add(%clip, $AutoKickIPListDuration);
schedule("AutoKickPlayer(" @ %clientId @ ");", 1, %clientId);
}
}
}
if ($KickBlankPlayers == 1)
{
%nonblankcount = 0;
%blankcount = 0;
%clname = Client::getName(%clientId);
%chridx = 0;
while (1) {
%res = String::GetSubStr(%clname, %chridx, 1);
if ((%res == -1) || (%res == ""))
break;
if (%res == " ")
%blankcount++;
else
%nonblankcount++;
%chridx++;
}
if (%nonblankcount == 0)
{
Client::sendMessage(%clientId,0,"Checking for invalid player names...");
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" will be kicked for blanks. (" @ %blankcount @ " blanks and " @ %nonblankcount @ " non blanks)");
Client::sendMessage(%clientId,0,"Get a valid name and come back later.");
BanList::add(%clip, $KickBlankPlayersDuration);
schedule("AutoKickBlanks(" @ %clientId @ ");", 1, %clientId);
}
}
for (%akidx = 1; %akidx <= $AutoAdminIPListCount; %akidx++)
{
if ($AutoAdminIPList[%akidx] != "")
{
%result = String::FindSubStr(%clip, $AutoAdminIPList[%akidx]);
if ((%result != -1) && (%result != ""))
{
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(Client::getName(%clientId)) @
"\" on " @ Client::getTransportAddress(%clientId) @
" is being auto-adminned.");
%clientId.isAdmin = true;
Client::sendMessage(%clientId,0,"You have been made an admin by the server.");
Game::refreshClientScore(%clientId);
}
}
}
%clientId.noghost = true;
%clientId.messageFilter = -1; // all messages
remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%clientId, MODInfo, $MODInfo);
remoteEval(%clientId, FileURL, $Server::FileURL);
for(%i = 0; %i < 10; %i++)
$Client::info[%clientId, %i] = "";
Game::onPlayerConnected(%clientId);
}
function Arena::CheckIfTeamsAreEven()
{
if ($Arena::MatchMode == 1) {
return;
}
if ($ArenaAutoEvenTeams != 1) {
return;
}
%teamcnt[0] = Arena::CountTeam(0);
%teamcnt[1] = Arena::CountTeam(1);
if (%teamcnt[0] == %teamcnt[1]) {
%teamdelta = 0;
}
else if (%teamcnt[0] > %teamcnt[1]) {
%srcteam = 0;
%dstteam = 1;
%teamdelta = %teamcnt[0] - %teamcnt[1];
}
else if (%teamcnt[0] < %teamcnt[1]) {
%srcteam = 1;
%dstteam = 0;
%teamdelta = %teamcnt[0] - %teamcnt[1];
}
else {
%teamdelta = 0;
}
if (%teamdelta > 1)
{
messageall(0, "Teams are uneven in number of players per team. Transferring player(s)..");
for (%xfercnt = 0; %xfercnt < (%teamdelta / 2); %xfercnt++)
{
%ridx = floor(getRandom() * (%teamcnt[%srcteam] - 0.01));
if (%ridx < 1) %ridx = 1;
if (%ridx > %teamcnt[%srcteam]) %ridx = %teamcnt[%srcteam];
%tidx = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
%team = %cl.matchteam;
if (%team == %srcteam)
{
%tidx++;
if (%tidx == %ridx) {
Client::sendMessage(%cl, 1, "You are being switched teams to even teams out.");
processMenuPickTeam(%cl, %dstteam);
Game::refreshClientScore(%cl);
break;
}
}
}
}
}
}
function Arena::DisplayVersion()
{
echo("VERSION: Tribes Arena v" @ $Arena::Version);
if (($Arena::Loaded == 1) && ($arena_cs_version != ""))
echo("VERSION: File arena.cs version " @ $arena_cs_version);
else if ($Arena::Loaded == 1)
echo("VERSION: File arena.cs is not the updated version");
else
echo("VERSION: File arena.cs not loaded");
if ($arenaadmin_cs_version != "")
echo("VERSION: File arenaAdmin.cs version " @ $arenaadmin_cs_version);
else
echo("VERSION: File arenaAdmin.cs is not the updated version");
if ($arenacomchat_cs_version != "")
echo("VERSION: File arenaComchat.cs version " @ $arenacomchat_cs_version);
else
echo("VERSION: File arenaComchat.cs is not the updated version");
if ($arenagui_cs_version != "")
echo("VERSION: File arenaGUI.cs version " @ $arenagui_cs_version);
else
echo("VERSION: File arenaGUI.cs is not the updated version");
if (($LizStatsLoaded == 1) && ($lizstats_cs_version != ""))
echo("VERSION: File lizstats.cs version " @ $lizstats_cs_version);
else if ($LizStatsLoaded == 1)
echo("VERSION: File lizstats.cs is not the updated version");
else
echo("VERSION: File lizstats.cs not loaded");
}
function Arena::RemoveGlobalUnmute(%clientId)
{
%clientId.mutedGlobal = "";
%clientId.mutedGlobalWarned = "";
%clientId.mutedGlobalName = "";
Client::sendMessage(%clientId,1,"You have been unmuted.");
}
function Arena::ResetTeamMapScore()
{
%nt = getNumTeams();
for(%i = -1; %i < %nt; %i++)
{
$TeamNbKills[%i] = 0;
$TeamNbDeaths[%i] = 0;
}
}
function Arena::ResetPlayerMapScore(%clientId)
{
%clientId.score = 0;
%clientId.scoreKills = 0;
%clientId.scoreTKs = 0;
%clientId.scoreDeaths = 0;
%clientId.scoreTKed = 0;
%clientId.scoreSuicide = 0;
%clientId.scoreMatchWon = 0;
%clientId.scoreMatchLost = 0;
Arena::ComputePlayerRatios(%clientId);
}
function Arena::ResetPlayerTotalScore(%clientId)
{
%clientId.totalKills = 0;
%clientId.totalTKs = 0;
%clientId.totalDeaths = 0;
%clientId.totalTKed = 0;
%clientId.totalSuicides = 0;
%clientId.totalMatchWon = 0;
%clientId.totalMatchLost = 0;
Arena::ComputePlayerRatios(%clientId);
}
function Arena::FormatFloat(%stat, %nbdecimals)
{
if (%stat == "") {
%stat = "0.000000000000000000000";
}
else {
%idx = String::FindSubStr(%stat, ".");
if (%idx == -1) {
%stat = %stat @ ".000000000000000000000";
}
}
%idx = String::FindSubStr(%stat, ".");
if (%idx == -1) {
return %result;
}
if (%nbdecimals > 0) {
%result = String::GetSubStr(%stat, 0, %idx+1+%nbdecimals);
}
else {
%result = String::GetSubStr(%stat, 0, %idx);
}
return %result;
}
function Arena::ComputePlayerRatios(%clientId)
{
%clientId.scoreKillDeathRank =   (%clientId.scoreKills - %clientId.scoreTKs) * 1000
+ %clientId.scoreKillDeathRatio * 100
+  99
- %clientId.scoreDeaths
+ %clientId.scoreTKed
+ %clientId.score;
if (%clientId.scoreDeaths > 0) {
%clientId.scoreKillDeathRatio = (%clientId.scoreKills / %clientId.scoreDeaths);
}
else {
%clientId.scoreKillDeathRatio = %clientId.scoreKills;
}
if (%clientId.totalDeaths > 0) {
%clientId.totalKillDeathRatio = (%clientId.totalKills / %clientId.totalDeaths);
}
else {
%clientId.totalKillDeathRatio = %clientId.totalKills;
}
%clientId.scoreKillDeathRatio = Arena::FormatFloat(%clientId.scoreKillDeathRatio, 2);
%clientId.totalKillDeathRatio = Arena::FormatFloat(%clientId.totalKillDeathRatio, 2);
if (%clientId.scoreKills > 0) {
%clientId.scoreTKKillRatio = (%clientId.scoreTKs / %clientId.scoreKills);
}
else {
%clientId.scoreTKKillRatio = %clientId.scoreTKs;
}
if (%clientId.totalKills > 0) {
%clientId.totalTKKillRatio = (%clientId.totalTKs / %clientId.totalKills);
}
else {
%clientId.totalTKKillRatio = %clientId.totalTKs;
}
%clientId.scoreTKKillRatio = Arena::FormatFloat(%clientId.scoreTKKillRatio, 2);
%clientId.totalTKKillRatio = Arena::FormatFloat(%clientId.totalTKKillRatio, 2);
if (%clientId.scoreDeaths > 0) {
%clientId.scoreSuicideDeathRatio = (100 * %clientId.scoreSuicide / %clientId.scoreDeaths);
}
else {
%clientId.scoreSuicideDeathRatio = 0;
}
if (%clientId.totalDeaths > 0) {
%clientId.totalSuicideDeathRatio = (100 * %clientId.totalSuicides / %clientId.totalDeaths);
}
else {
%clientId.totalSuicideDeathRatio = 0;
}
%clientId.scoreSuicideDeathRatio = Arena::FormatFloat(%clientId.scoreSuicideDeathRatio, 0);
%clientId.totalSuicideDeathRatio = Arena::FormatFloat(%clientId.totalSuicideDeathRatio, 0);
%totalmatches = %clientId.scoreMatchWon + %clientId.scoreMatchLost;
if (%totalmatches > 0) {
%clientId.scoreTeamVictoryRatio = (100 * %clientId.scoreMatchWon / %totalmatches);
}
else {
%clientId.scoreTeamVictoryRatio = 0;
}
if (%totalmatches > 0) {
%clientId.totalTeamVictoryRatio = (100 * %clientId.totalMatchWon / %totalmatches);
}
else {
%clientId.totalTeamVictoryRatio = 0;
}
%clientId.scoreTeamVictoryRatio = Arena::FormatFloat(%clientId.scoreTeamVictoryRatio, 0);
%clientId.totalTeamVictoryRatio = Arena::FormatFloat(%clientId.totalTeamVictoryRatio, 0);
}
function Arena::ListPlayers()
{
echo("ARENA: Connected players:");
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
%clname = Client::getName(%clientId);
%clip = Client::getTransportAddress(%cl);
%team = Client::getTeam(%cl);
echo("ARENA: Client " @ %cl @ " " @ %clname @ " on " @ %clip @
" on team " @ %team @
" has " @
%cl.scoreKills @ " kills, " @
%cl.scoreDeaths @ " deaths, " @
%cl.scoreTKs @ " TKs, " @
%cl.scoreTKed @ " TKed, " @
%cl.scoreSuicide @ " suicides, " @
%cl.score @ " points, " @
" for a rank of " @ %cl.scoreKillDeathRank);
}
}
function Arena::GetPlayerPosition(%clientId, %index)
{
$Arena::playerPos[%clientId,%index] = Gamebase::getPosition(%clientId);
$Arena::playerRot[%clientId,%index] = Gamebase::getRotation(%clientId);
}
function Arena::GetAllPlayersPosition(%index)
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
Arena::GetPlayerPosition(%cl, %index);
}
}
function Arena::CheckAllPlayersForAFK(%gamestarttime)
{
if (%gamestarttime != $Arena::GameStartTime) {
return;
}
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (%cl.onteam == "*")
{
Arena::GetPlayerPosition(%cl, 1);
if ($Arena::MatchMode == 0)
{
if ($Arena::playerPos[%cl,0] == $Arena::playerPos[%cl,1])
{
if ($Arena::playerRot[%cl,0] == $Arena::playerRot[%cl,1])
{
Client::sendMessage(%cl,3, "You have been placed in observer because you were AFK.");
processMenuPickTeam(%cl, 9);
}
}
}
$Arena::playerPos[%cl,0] = $Arena::playerPos[%cl,1];
$Arena::playerRot[%cl,0] = $Arena::playerRot[%cl,1];
}
}
%teamcnt[0] = Arena::CountAliveTeamPlayers(0);
%teamcnt[1] = Arena::CountAliveTeamPlayers(1);
if ((%teamcnt[0] > 0) || (%teamcnt[1] > 0)) {
if ($Arena::MatchMode == 0) {
if ($AutoObsAFKers == 1)
{
schedule("Arena::CheckAllPlayersForAFK(" @ %gamestarttime @ ");", $Arena::AFKDetectTimeNextChecks);
}
}
}
}
function processMenuRRndTeams(%clientId, %opt)
{
if(!%clientId.isAdmin || $Arena::MatchMode != 0) return; // PORT
%adminId = %clientId; // PORT: was a client-supplied id (any name could be blamed)
if(getWord(%opt, 0) == "all") {
Arena::ReRandomizeTeams(1, %adminId);
}
else if(getWord(%opt, 0) == "teamed") {
Arena::ReRandomizeTeams(0, %adminId);
}
else {
Arena::TabMenuExploit(%clientId);
return;
}
Game::menuRequest(%clientId);
}
function Arena::ReRandomizeTeams(%allplayers, %adminId)
{
if (%allplayers == 0) {
messageall(0, Client::getName(%adminId) @ " has re-randomized teams (all players).");
}
else {
messageall(0, Client::getName(%adminId) @ " has re-randomized teams.");
}
%numTeams = getNumTeams();
%numPlayers = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%allplayers == 1) || (%cl.matchTeam >= 0)) {
%numPlayers++;
}
}
%numPlayersOnTeam[0] = 0;
%numPlayersOnTeam[1] = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%allplayers == 1) || (%cl.matchTeam >= 0))
{
%nrnd = floor(getRandom() * 4.99) + 1;
for (%i = 0; %i < %nrnd; %i++) {
%rtm = floor(getRandom() * 999.9 + getRandom() * 99.9 + getRandom() * 9.99);
}
%rtm = (%rtm/2) - floor(%rtm/2);
if (%rtm > 0) %rtm = 1;
if (%numPlayersOnTeam[%rtm] > (%numPlayers / 2)) {
if (%rtm == 0) %rtm = 1;
else %rtm = 0;
}
processMenuPickTeam(%cl, %rtm);
%numPlayersOnTeam[%rtm]++;
}
}
}
function Arena::TabMenuExploit(%clientId)
{
%name = Client::getName(%clientId);
%ip = Client::getTransportAddress(%clientId);
messageall(1, %name @ " on " @ %ip @ " attempted to use the Tab Menu exploit. Player will be kicked.");
echo("LIZADMIN: " @ %clientId @ " \"" @
escapeString(%name) @ "\" on " @ %ip @ " was kicked for using the Tab Menu exploit.");
BanList::add(%ip, $TabMenuExploitKickTimeSeconds);
Net::kick(%clientId, "You stupid kid... Get lost.");
if (($LizStatsLoaded == 1) && ($LizStatsEnable == 1))
LizStats::UpdateServerStatsTotalKicks(1);
}
function Arena::CountNumberOfAdmins(%team)
{
%admCount = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%team < 0) || (Client::getTeam(%cl) == %team)) {
if (%cl.isAdmin || %cl.isTrustedAdmin || %cl.isSuperAdmin || %cl.isServerSuperAdmin) {
%admCount++;
}
}
}
return %admCount;
}
function Arena::GetBestPlayer(%team)
{
%bestId = 0;
%bestScore = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%team < 0) || (Client::getTeam(%cl) == %team)) {
if (%cl.scoreKillDeathRank > %bestScore) {
%bestId = %cl;
%bestScore = %cl.scoreKillDeathRank;
}
}
}
return %bestId;
}
function Arena::GetWorstPlayer(%team)
{
%worstId = 0;
%worstScore = 99999;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if ((%team < 0) || (Client::getTeam(%cl) == %team)) {
if ((%cl.scoreKills > 0) || (%cl.scoreDeaths > 0)) {
if (%cl.scoreKillDeathRank < %worstScore) {
%worstId = %cl;
%worstScore = %cl.scoreKillDeathRank;
}
}
}
}
return %worstId;
}
function Arena::GetTeamWorthinessRatio(%team)
{
if (%team < 0) {
return 0;
}
%totalScore = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (%cl.matchTeam == %team) {
%totalScore = %totalScore + (%cl.scoreKillDeathRank / 10);
}
}
return %totalScore;
}
function Arena::MessageTo(%playername, %message)
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
if (Client::getName(%cl) == %playername) {
Client::sendMessage(%cl, 1, %message);
}
}
}
$arena_cs_version = "$Revision: 50 $ on $Date: 7/02/02 6:41p $";
echo("VERSION: arena.cs v" @ $Arena::Version @ ", internal version " @ $arena_cs_version);
