//===============WWII MOD DM/FFA GAME TYPE CODE=================

function Mission::Init()
{
$SensorNetworkEnabled = false;
setTeamScoreHeading("");
setClientScoreHeading("SC   Name\t\x78Kills\t\xA0Deaths\t\xCFPing");
}

function Game::refreshClientScore(%clientId)
{
Client::setScore(%clientId, GetSpawnClassCode(%clientId.spawnclass, player::isdead(client::getownedobject(%clientId))) @ " %n\t" @ %clientId.scoreKills @ "\t  " @ %clientId.scoreDeaths  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
}

function remoteToggleCommandMode(%clientId) { } 

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
	     %obitMsg = sprintf($deathMsg[%damageType], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      Deathmatch::SetObjectives();
   }
   Game::clientKilled(%playerId, %killerId);
	Stats::Kill(%playerId, %killerId, 1);
if(%playerId.targetbeacon > 0 && GameBase::GetDataName(%playerId.targetbeacon) == "ATB") { if(gamebase::getdataname(%playerid.targetbeacon) == "ATB") deleteobject(%playerId.targetbeacon); %playerid.targetbeacon = ""; }
}


function Deathmatch::SetObjectives()
{
for(%x = 0; %x < 2; %x++)
	{
	//objective::displayBitmap(%x, 1);
	Team::SetObjective(%x, 2, "<f5>Game status:");
	Team::SetObjective(%x, 3, "<f3>Map name: " @ $servermission);
	
	Team::SetObjective(%x, 5, "<f5>Objectives: ");
	Team::SetObjective(%x, 6, "<f3>This is the classic DM / Free For All game type in which there are no player teams.\nKill any player that you see to earn points and increase your player rating. ");
	Team::SetObjective(%x, 7, "<f3>The battle will end once a player gets 50 kills OR the time limit is reached.\nAt the end of the battle each player stats are displayed in the objectives menu.");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

function WWII::ShowObjectiveStatus(%y)
{
Team::SetObjective(%y, 9, "\n<f8>Objective Status:");
Team::SetObjective(%y, 10, "<f2>%\t\tName\t\t\t\t\t\t\tKills\t\tDeaths\t\tRating\n<f0>-------------------------------------------------------------------------------");
%count = 0;
for(%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
	{
	%kills = %cl.scorekills;
	%killslist[%count] = %kills;
	%killerslist[%count] = %cl;
	%count++;
	}
for(%i = 0; %i < getnumclients(); %i++)
	for(%x = 0; %x < getnumclients()-1; %x++)
		{
		%curkills = %killslist[%x];
		%curkiller = %killerslist[%x];
		
		%nextkills = %killslist[%x+1];
		%nextkiller = %killerslist[%x+1];
		
		if(%curkills < %nextkills)
			{
			%bufa = %curkills; 
			%bufb = %curkiller;
			
			%killslist[%x] = %nextkills;
			%killerslist[%x] = %nextkiller;
			%killslist[%x+1] = %bufa;
			%killerslist[%x+1] = %bufb;
			}
	
		}	
		
for(%x = 0; %x < getnumclients(); %x++)
	{
	%name = client::getname(%killerslist[%x]);
	%tabcount = ceiling((27-countspaces(%name))/3); %tabstr = "";
	for(%g = 0; %g < %tabcount; %g++) %tabstr = %tabstr @ "\t";
	%string = %string @ %x+1 @ "\t\t" @ %name @ %tabstr @ %killerslist[%x].scorekills @ "\t\t\t" @ %killerslist[%x].scoredeaths @ "\t\t\t\t" @ 2*tans(%killerslist[%x].scorekills/(2 * %killerslist[%x].scoredeaths), g) @ "%\n";
	if(%x % 3 == 0 && %x != 0)
		{
		Team::SetObjective(%y, 11+floor(%x/3), %string);
		%string = "";
		}
	}
	if(%string != "") Team::SetObjective(%y, 11+floor(%x/3), %string);
	%string = "";
}

function Deathmatch::AssignTeams()
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	client::setinitialteam(%cl, $DeathMatch::Team);
	gamebase::Setteam(%cl, $DeathMatch::Team);
	}
}

function m::ChooseClass(%clientId, %opt)
{
%x = getword(%opt, 0);
if((%x != "scout" && %x != "assault" && %x != "antitank" && %x != "antitank2" && %x != "medic" && %x != "engineer" && %x != "assault2") || (($country[1]!="German" && $country[1]!="Japan") && gamebase::getteam(%clientId) == 1)) schedule("net::kick(" @ %clientId @ ", \"Wrong menu item! reconnect..\"); messageall(2,\"Server: Menu Error!\");", 0);
%clientId.spawnclass = %x;
Schedule("DeathMatch::PlayerSpawn(" @ %clientId @ ");", 1.5, %clientId);
centerprint(%clientId, "<jc><f1>You are being spawned on the battlefield...", 1.5,CLASS);
}

function DeathMatch::PlayerSpawn(%cl)
{
%group = "MissionGroup\\DeathMatch";

%cl.guiLock = "";
%cl.dead = "";
game::refreshclientscore(%cl);
Client::clearItemShopping(%cl);

if(Group::objectCount(%group) < 1) 
	{
	messageall(0, "No DM spawn points are available.");
	return;
	}
%spawnmarker = group::getobject(%group, floor(getrandom() * group::objectcount(%group)));
%spawnpos = gamebase::getposition(%spawnmarker);
%spawnrot = gamebase::getrotation(%spawnmarker);

objectivemission::refreshteamscores();
%pl = spawnplayer(soldier, %spawnpos, %spawnrot);
schedule("WWII::CriminalCheck(" @ %pl @ ");", 1, %pl); 
echo("SPAWN: " @ client::getname(%cl) @ " cl:" @ %cl @ " pl:" @ %pl @ " markergroup: " @ object::getname(getgroup(%spawnMarker)) @ " class: " @ %cl.spawnclass);

if(%pl != -1)
	   {
	   GameBase::setTeam(%pl, Client::getTeam(%cl));
	   Client::setOwnedObject(%cl, %pl);
	   WWII::PlayerSetup(%cl, $country[$Deathmatch::Team]);
	      
	   if($matchStarted)
	   Client::setControlObject(%cl, %pl);
	   else
	      {
	         %cl.observerMode = "pregame";
	         Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	         Observer::setOrbitObject(%cl, %pl, 8, 1, 3);
	      }
	   }	  

Deathmatch::SetObjectives();
}