// __________________________________________________________________________
// LizStats v1.2 for Starsiege Tribes                              2002-06-15
// by Lizard (irc.dynamix.com on #lizrena, or belgarion@tribes2universe.com)
// __________________________________________________________________________
// STATISTICS MODULE
// __________________________________________________________________________
// INTERESTING COMMAND LINE FUNCTIONS:
//
//    function LizStats::ResetTopScores(%dateReset)
//       Will reset the top scores 
//    function LizStats::DisplayPlayedMaps()
//       Will display the most recent played maps
//    function LizStats::ShowMapStatsMapHighestScore()
//       Will display the map's highest score
// __________________________________________________________________________


if ($LizStatsLoaded == 1)
{
echo("LIZSTATS: Warning. Stats module already loaded. That means you have an exec(lizStats.cs) in two or more places.");
}
$LizStatsLoaded = 1;
$LizStatsVersion = "1.2";
$LizStatsURL = "www.tribes2universe.com";
$LizStatsMapsMapHighestScore = 5;
$LizStatsMapsMapHighestKills = 5;
$LizStatsMapsMapHighestKDRatio = 5;
$LizStatsMapsMapWorstScore = 5;
$LizStats::CleanMissionName = "undefined_mission_name";
$LizStats::CleanMissionType = "undefined_mission_type";
$LizStats::debugEnabled = 1;
$LizStats::LastPlayedMapsCount = 10;
echo("LIZSTATS: Loading Statistics module...");
$LizStatsScoresNull = -99999;
function LizStats::StartUp()
{
LizStats::ResetAll();
LizStats::LoadAll();
LizStats::InitializeLastPlayedMaps();
}
function LizStats::FormatStat(%stat, %totalchars)
{
%bigstr = %stat @ "                                   ";
%result = String::GetSubStr(%bigstr, 0, %totalchars);
return %result;
}
function LizStats::FloatToInteger(%stat)
{
%idx = String::FindSubStr(%stat, ".");
if (%idx == -1)
return %result;
%result = String::GetSubStr(%stat, 0, %idx);
return %result;
}
function LizStats::ReplaceChar(%str, %chartoreplace, %replacementchar)
{
%result = %str;
while (1)
{
%idx = String::FindSubStr(%result, %chartoreplace);
if (%idx == -1)
break;
%pre = String::GetSubStr(%result, 0, %idx);
%post = String::GetSubStr(%result, %idx+1, 10000);
%result = %pre @ %replacementchar @ %post;
}
return %result;
}
function LizStats::ArrangeMultispace(%str)
{
%result = %str;
while (1)
{
%idx = String::FindSubStr(%result, "  ");
if (%idx == -1)
break;
%pre = String::GetSubStr(%result, 0, %idx);
%post = String::GetSubStr(%result, %idx+2, 10000);
%result = %pre @ " " @ %post;
}
return %result;
}
function LizStats::RemoveQuotes(%str)
{
%result = LizStats::ReplaceChar(%str, "\"", "");
return %result;
}
function LizStats::ParseName(%str)
{
%result = String::convertSpaces(%str);
%result = LizStats::ReplaceChar(%result, "-", "_");
%result = LizStats::ReplaceChar(%result, "/", "_");
%result = LizStats::ReplaceChar(%result, "\\", "_");
%result = LizStats::ReplaceChar(%result, "~", "_");
%result = LizStats::ReplaceChar(%result, "%", "_");
%result = LizStats::ReplaceChar(%result, "$", "_");
return %result;
}
function LizStats::CleanUpAll()
{
if ($LizStatsServer == 1)
LizStats::CleanUpServer();
if ($LizStatsMap == 1)
LizStats::CleanUpMaps();
}
function LizStats::CleanUpMaps()
{
deleteVariables("$LizStats::MapStats*");
}
function LizStats::CleanUpServer()
{
deleteVariables("$LizStats::ServerStats*");
}
function LizStats::ResetAll()
{
if ($LizStatsServer == 1)
LizStats::ResetServer();
if ($LizStatsMap == 1)
LizStats::ResetMaps();
}
function LizStats::ResetServer()
{
echo("LIZSTATS: Resetting server statistics.");
for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
{
%mistype = LizStats::ParseName($MLIST::Type[%type]);
if(%mistype != "Training")
{
for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%type], %i)) != -1; %i++)
{
%misname = LizStats::ParseName($MLIST::EName[%misIndex]);
$LizStats::ServerStatsTotalGamesPlayed[%mistype, %misname] = 0;
$LizStats::ServerStatsTotalMatchesPlayed[%mistype, %misname] = 0;
$LizStats::ServerStatsTotalMapsPlayed[%mistype, %misname] = 0;
}
}
}
$LizStats::ServerStatsTotalAllMapsPlayed = 0;
$LizStats::ServerStatsTotalAllMatchesPlayed = 0;
$LizStats::ServerStatsTotalAllGamesPlayed = 0;
$LizStats::ServerStatsTotalConnects = 0;
$LizStats::ServerStatsTotalKicks = 0;
$LizStats::ServerStatsTotalBans = 0;
$LizStats::ServerStatsTotalKills = 0;
$LizStats::ServerStatsTotalDeaths = 0;
$LizStats::ServerStatsTotalTKs = 0;
$LizStats::ServerStatsTotalSuicides = 0;
}
function LizStats::ResetMaps()
{
echo("LIZSTATS: Resetting map statistics.");
if ($MList::TypeCount < 2)
$TypeStart = 0;
else
$TypeStart = 1;
for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
{
%mistype = LizStats::ParseName($MLIST::Type[%type]);
if(%mistype != "Training")
{
for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%type], %i)) != -1; %i++)
{
%misname = LizStats::ParseName($MLIST::EName[%misIndex]);
$LizStats::MapStatsGamesWonTeam1[%mistype, %misname] = 0;
$LizStats::MapStatsGamesWonTeam2[%mistype, %misname] = 0;
$LizStats::MapStatsMatchesWonTeam1[%mistype, %misname] = 0;
$LizStats::MapStatsMatchesWonTeam2[%mistype, %misname] = 0;
for(%highscore = 0; %highscore < $LizStatsMapsMapHighestScore; %highscore++)
$LizStats::MapStatsMapHighestScore[%mistype, %misname, %highscore] = $LizStatsScoresNull;
}
}
}
}
function LizStats::LoadAll()
{
if ($LizStatsServer == 1)
LizStats::LoadServer();
if ($LizStatsMap == 1)
LizStats::LoadMaps();
}
function LizStats::LoadServer()
{
echo("LIZSTATS: Reloading server statistics, please be patient..");
if ($Server::HostFileExtension == "") {
exec("lizStatisticsServer.cs");
}
else {
exec("lizStatistics" @ $Server::HostFileExtension @ "Server.cs");
}
}
function LizStats::LoadMaps()
{
echo("LIZSTATS: Reloading maps statistics, please be patient..");
if ($Server::HostFileExtension == "") {
exec("lizStatisticsMap.cs");
}
else {
exec("lizStatistics" @ $Server::HostFileExtension @ "Map.cs");
}
}
function LizStats::SaveAll()
{
if ($LizStatsServer == 1)
LizStats::SaveServer();
if ($LizStatsMap == 1)
LizStats::SaveMaps();
}
function LizStats::SaveServer()
{
echo("LIZSTATS: Saving server statistics.");
if ($Server::HostFileExtension == "") {
export("LizStats::ServerStats*", "config\\lizStatisticsServer.cs", false);
}
else {
export("LizStats::ServerStats*", "config\\lizStatistics" @ $Server::HostFileExtension @ "Server.cs", false);
}
}
function LizStats::SaveMaps()
{
echo("LIZSTATS: Saving maps statistics.");
if ($Server::HostFileExtension == "") {
export("LizStats::MapStats*", "config\\lizStatisticsMap.cs", false);
}
else {
export("LizStats::MapStats*", "config\\lizStatistics" @ $Server::HostFileExtension @ "Map.cs", false);
}
}
function LizStats::UpdateServerStatsTotalMapsPlayed(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalMapsPlayed[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
$LizStats::ServerStatsTotalAllMapsPlayed += %count;
}
}
function LizStats::UpdateServerStatsTotalMatchesPlayed(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalMatchesPlayed[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
$LizStats::ServerStatsTotalAllMatchesPlayed += %count;
}
}
function LizStats::UpdateServerStatsTotalGamesPlayed(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalGamesPlayed[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
$LizStats::ServerStatsTotalAllGamesPlayed += %count;
}
}
function LizStats::UpdateServerStatsTotalConnects(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalConnects += %count;
}
}
function LizStats::UpdateServerStatsTotalKicks(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalKicks += %count;
}
}
function LizStats::UpdateServerStatsTotalBans(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalBans += %count;
}
}
function LizStats::UpdateServerStatsTotalKills(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalKills += %count;
}
}
function LizStats::UpdateServerStatsTotalDeaths(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalDeaths += %count;
}
}
function LizStats::UpdateServerStatsTotalTKs(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalTKs += %count;
}
}
function LizStats::UpdateServerStatsTotalSuicides(%count)
{
if ($LizStatsServer == 1)
{
$LizStats::ServerStatsTotalSuicides += %count;
}
}
function LizStats::UpdateMapStatsGamesWonTeam1(%count)
{
if ($LizStatsMap == 1)
{
$LizStats::MapStatsGamesWonTeam1[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
}
}
function LizStats::UpdateMapStatsGamesWonTeam2(%count)
{
if ($LizStatsMap == 1)
{
$LizStats::MapStatsGamesWonTeam2[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
}
}
function LizStats::UpdateMapStatsMatchesWonTeam1(%count)
{
if ($LizStatsMap == 1)
{
$LizStats::MapStatsMatchesWonTeam1[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
}
}
function LizStats::UpdateMapStatsMatchesWonTeam2(%count)
{
if ($LizStatsMap == 1)
{
$LizStats::MapStatsMatchesWonTeam2[$LizStats::CleanMissionType, $LizStats::CleanMissionName] += %count;
}
}
function LizStats::ShowMapStatsMapHighestScore()
{
for (%currow = 0; %currow < $LizStatsMapsMapHighestScore; %currow++)
{
echo("LIZSTATS: (DEBUG) HighScore Row " @ %currow @ " is " @ $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow]);
}
}
function LizStats::DeleteTableRowMapStatsMapHighestScore(%row)
{
%firstrow = %row;
%lastrow = $LizStatsMapsMapHighestScore - 2;
for (%currow = %firstrow; %currow <= %lastrow; %currow++)
{
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow] =
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow+1];
}
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, $LizStatsMapsMapHighestScore - 1] = $LizStatsScoresNull;
}
function LizStats::InsertTableRowMapStatsMapHighestScore(%row, %cscore, %ckills, %cname)
{
%lastrow = %row; // + 1 - 1;
%firstrow = $LizStatsMapsMapHighestScore - 1;
for (%currow = %firstrow; %currow >= %lastrow; %currow--)
{
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow] =
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow-1];
}
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %row] =
%cscore @ " " @ %ckills @ " " @ %cname;
}
function LizStats::InsertTableRowMapStatsMapHighestRank(%row, %crank, %ckills, %cdeaths, %cscore, %cname)
{
%lastrow = %row; // + 1 - 1;
%firstrow = $LizStatsMapsMapHighestScore - 1;
for (%currow = %firstrow; %currow >= %lastrow; %currow--)
{
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow] =
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %currow-1];
}
$LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %row] =
%crank @ " " @ %ckills @ " " @ %cdeaths @ " " @ %cscore @ " " @ %cname;
}
function LizStats::ExtractClientNameScoreMethod(%row)
{
%completestr = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %row];
%playername = "";
%paramidx = 2;
while (1)
{
%newstr = getWord(%completestr, %paramidx);
if (%newstr != -1)
{
if (%playername == "")
%playername = %newstr;
else
%playername = %playername @ " " @ %newstr;
}
else
{
break;
}
%paramidx++;
}
return %playername;
}
function LizStats::ExtractClientNameRankMethod(%row)
{
%completestr = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %row];
%playername = "";
%paramidx = 4;
while (1)
{
%newstr = getWord(%completestr, %paramidx);
if (%newstr != -1)
{
if (%playername == "")
%playername = %newstr;
else
%playername = %playername @ " " @ %newstr;
}
else
{
break;
}
%paramidx++;
}
return %playername;
}
function LizStats::UpdateMapStatsCheckClientScore(%client)
{
if ($LizStatsMap == 1)
{
if (%client.score < 0) {
return;
}
%newhighscore = -1;
for (%highscore = $LizStatsMapsMapHighestScore - 1; %highscore >= 0; %highscore--)
{
%sstr   = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %highscore];
%sscore = getWord(%sstr, 0);
if ((%client.score > %sscore) || ((%sscore == $LizStatsScoresNull) && (%client.score >= %sscore))){
%newhighscore = %highscore;
}
}
if (%newhighscore == -1) {
return;
}
%cname = Client::getName(%client);
%cname = LizStats::ArrangeMultispace(%cname);
for (%highscore = 0; %highscore < $LizStatsMapsMapHighestScore; %highscore++)
{
%sstr  = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %highscore];
%sname = LizStats::ExtractClientNameScoreMethod(%highscore);
if (%sname == %cname) {
%sscore = getWord(%sstr, 0);
if (%client.score <= %sscore) {
return;
}
LizStats::DeleteTableRowMapStatsMapHighestScore(%highscore);
break;
}
}
LizStats::InsertTableRowMapStatsMapHighestScore(%newhighscore, %client.score, %client.scoreKills, %cname);
}
}
function LizStats::UpdateMapStatsCheckClientRank(%client)
{
if ($LizStatsMap == 1)
{
%newhighscore = -1;
for (%highscore = $LizStatsMapsMapHighestScore - 1; %highscore >= 0; %highscore--)
{
%sstr  = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %highscore];
%srank = getWord(%sstr, 0);
if ((%client.scoreKillDeathRank > %srank) || ((%srank == $LizStatsScoresNull) && (%client.scoreKillDeathRank >= %srank))) {
%newhighscore = %highscore;
}
}
if (%newhighscore == -1) {
return;
}
%cname = Client::getName(%client);
%cname = LizStats::ArrangeMultispace(%cname);
for (%highscore = 0; %highscore < $LizStatsMapsMapHighestScore; %highscore++)
{
%sstr  = $LizStats::MapStatsMapHighestScore[$LizStats::CleanMissionType, $LizStats::CleanMissionName, %highscore];
%sname = LizStats::ExtractClientNameRankMethod(%highscore);
if (%sname == %cname) {
%srank = getWord(%sstr, 0);
if (%client.scoreKillDeathRank <= %srank) {
return;
}
LizStats::DeleteTableRowMapStatsMapHighestScore(%highscore);
break;
}
}
LizStats::InsertTableRowMapStatsMapHighestRank(%newhighscore, %client.scoreKillDeathRank, %client.scoreKills, %client.scoreDeaths, %client.score, %cname);
}
}
function LizStats::ResetTopScores(%dateReset)
{
echo("LIZSTATS: Resetting top scores.");
if ($MList::TypeCount < 2)
$TypeStart = 0;
else
$TypeStart = 1;
for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
{
%mistype = LizStats::ParseName($MLIST::Type[%type]);
if(%mistype != "Training")
{
for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%type], %i)) != -1; %i++)
{
%misname = LizStats::ParseName($MLIST::EName[%misIndex]);
for(%highscore = 0; %highscore < $LizStatsMapsMapHighestScore; %highscore++)
$LizStats::MapStatsMapHighestScore[%mistype, %misname, %highscore] = $LizStatsScoresNull;
}
}
}
$LizStats::MapStatsMapHighestScoreResetDate = %dateReset;
ObjectiveMission::setObjectiveHeading();
}
function LizStats::InitializeLastPlayedMaps()
{
for (%i = 1; %i <= $LizStats::LastPlayedMapsCount; %i++)
{
$LizStats::LastPlayedMaps[%i] = "";
}
}
function LizStats::CheckLastPlayedMaps(%mapname)
{
for (%i = 1; %i <= $LizStats::LastPlayedMapsCount; %i++)
{
if ((%mapname == $LizStats::LastPlayedMaps[%i]) && ($LizStats::LastPlayedMaps[%i] != ""))
return %i;
}
return 0;
}
function LizStats::CheckIfCurrentMap(%mapname)
{
if (%mapname == $missionName)
return true;
else
return false;
}
function LizStats::DisplayPlayedMaps()
{
echo("LIZSTATS: Recently played maps:");
for (%i = 1; %i <= $LizStats::LastPlayedMapsCount; %i++)
{
echo("LIZSTATS: " @ %i @ ") " @ $LizStats::LastPlayedMaps[%i]);
}
}
function LizStats::GetRecentMapList()
{
%recentmaps = "";
for (%i = 1; %i <= $LizStats::LastPlayedMapsCount; %i++)
{
if ($LizStats::LastPlayedMaps[%i] != "") {
if (%recentmaps != "") {
%recentmaps = %recentmaps @ ", ";
}
%recentmaps = %recentmaps @ $LizStats::LastPlayedMaps[%i];
}
}
return %recentmaps;
}
function LizStats::UpdatePlayedMaps(%mapname)
{
if (%mapname == "") {
return;
}
%mapindex = 0;
for (%i = 1; %i <= $LizStats::LastPlayedMapsCount; %i++) {
if ((%mapname == $LizStats::LastPlayedMaps[%i]) && ($LizStats::LastPlayedMaps[%i] != "")) {
%mapindex = %i;
break;
}
}
if (%mapindex > 0) {
for (%i = %mapindex; %i <= $LizStats::LastPlayedMapsCount-1; %i++) {
$LizStats::LastPlayedMaps[%i] = $LizStats::LastPlayedMaps[%i+1];
}
}
for (%i = $LizStats::LastPlayedMapsCount; %i > 1; %i--) {
$LizStats::LastPlayedMaps[%i] = $LizStats::LastPlayedMaps[%i-1];
}
$LizStats::LastPlayedMaps[1] = %mapname;
}
$lizstats_cs_version = "$Revision: 48 $ on $Date: 7/12/02 3:35p $";
echo("VERSION: lizstats.cs version " @ $lizstats_cs_version);
