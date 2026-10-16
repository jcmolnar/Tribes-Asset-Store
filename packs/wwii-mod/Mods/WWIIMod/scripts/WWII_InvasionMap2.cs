function remoteToggleCommandMode(%clientId)
{
if($WWII::TeamPointsAxis > 14) return;
if($WWII::TraceClients) %clientId.remotecall++;
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		 remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function invasion::makebot()
{
%group = "MissionGroup\\Invasion";
%randomroute = "Route" @ floor(getrandom()*3) + 1;
%group = %group @ "\\" @ %randomroute;

%randomspawn = group::getobject(%group @ "\\spawn", floor(getrandom()*group::objectcount(%group @ "\\spawn")));
%aiName = "DeadMeat" @ nametoid(%group) @ floor(getrandom()*100);
%spawnPos = GameBase::getPosition(%randomspawn);
%spawnRot = GameBase::getRotation(%randomspawn);
AI::spawn( %AIName, soldier, %spawnPos, %spawnRot, $AIName[1, floor(getrandom()*35)], "male2" );
%aiId = ai::getid(%ainame);
%pl = client::getownedobject(%aiId);

Client::setinitialTeam(%aiId, 1);
GameBase::setTeam(%AiId, 1);
%route = %group @ "\\Route";
ai::setvar(%ainame, IQ, 1000);
ai::setvar(%ainame, attackmode, 1);
ai::setvar(%ainame, Triggerpct, 1);
ai::setvar(%ainame, SpotDist, 150);
%classlist = "scout assault assault2 antitank medic engineer";
%obj = ai::getobject(%ainame);
%class = getword(%classlist, floor(getrandom()*6));
%obj.spawnclass = %class;
%obj.pl = %pl;
%weapon = $Weapon[%class, German];
AI::callWithId(%AIname, Player::setItemCount, %weapon, 1);
AI::callWithId(%AIname, Player::setitemcount, $Clip[%weapon], 25);
AI::callWithId(%AIname, Player::mountitem, %weapon, $weaponslot);
for(%x = 0; %x < group::objectcount(%route); %x++) 
	{ 
	%marker = group::getobject(%route, %x); 	
	%pos = gamebase::getposition(%marker);
	ai::directivewaypoint(%aiName, %pos, %x*100+100);
	}
ai::setautomatictargets(%aiName);
schedule("invasion::makebot();", Invasion::gettime());
}

function invasion::gettime()
{
%graph = "999 18 17 16 15 14 13 12 11.5 11 10.5 10 9.75 9.5 9.25 9 8.75 8.5 8.25 8 7 6 6 6 6 6 6 6 6 6 6";
%x = getnumclients(); if(getword(%graph, %x) < 1) return 5.5;
return getword(%graph, %x);
}

function Invasion::BeginMissionScript()
{
Invasion::MakeBot();
}

function AI::onDroneKilled(%aiName)
{
%cl = ai::getId(%aiName);

%obj = ai::getobject(%ainame);
%pl = %obj.pl;
%pl.equipment = %obj.spawnclass;
%pl.shreds = 1;

schedule("ai::delete(\"" @ %ainame @ "\");", 20, %pl);
$WWII::TeamPoints[Axis]--;
if($WWII::TeamPoints[Axis] <= 18+getnumclients() && $Invasion::FinalStep != 1) 
	{
	
	eval("function invasion::makebot() { }");
	messageall(0,"A german base was located North-East of your position! Finish Them!");
	schedule("Invasion::Finalstep();", 1);
	
	}
if(getnumbots() < 1) $WWII::TeamPoints[Axis] = 0;
if($WWII::TeamPoints[Axis] <= 0) { $Invasion::Winnerteam = 0; conquest::missioncomplete(); ObjectiveMission::missionComplete(); }
ObjectiveMission::refreshTeamScores();
}

function Objective::SetObjectives()
{
for(%x = 0; %x < 2; %x++)
	{
	//objective::displayBitmap(%x, 1);
	Team::SetObjective(%x, 2, "<f5>Game status:");
	Team::SetObjective(%x, 3, "<f3>Map name: " @ $servermission);
	Team::SetObjective(%x, 4, "<f3>Allied points: " @ $WWII::TeamPoints[Allied]);
	Team::SetObjective(%x, 5, "<f3>Axis points: " @ $WWII::TeamPoints[Axis]);
	
	Team::SetObjective(%x, 8, "<f5>Objectives: ");
	Team::SetObjective(%x, 9, "<f2>Roma:<f3>\n\"I hope you enjoyed the Invasion coop map, because you are going\nto suffer this one! Looks like the invasion of german troops is going\nto continue and this time you can fight in ");
	Team::SetObjective(%x, 10, "<f3>very challenging conditions and against very challeging AI.\nYou have less than 5 seconds to get a gun and go kick some butt.\"");
	
	
	//WWII::ShowObjectiveStatus(%x);
	}
}

function Conquest::MissionComplete()
{
%winner = $Invasion::Winnerteam;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner == 0 || %winner == 1) 
	{
	if(%winner == 0) Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side tore the german army into pieces!");
	else if(%winner == 1) Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side took over the allied outpost! Or what's left of it..");
	}
else Team::SetObjective(%i,1, "<f5><jc>Mission Incomplete!");
exec(game);
exec(ai);
deletefunctions("invasion*");
deletevariables("invasion*");
}
$loop = false;

schedule("$Invasion::WinnerTeam = \"\";",1);
}

function Game::clientKilled(%playerId, %killerId)
{
%cl = Player::GetClient(%playerId);
%cl.choosingclass = true;
if(1)  //tweak here
{

$WWII::TeamPoints[getteamname(GameBase::getteam(%playerId))]--;
//Conquest::CheckOutposts();
}
if($WWII::TeamPoints[Allied] <= 0) { $Invasion::Winnerteam = 1; conquest::missioncomplete(); objectivemission::missioncomplete(); } // PORT FIX: was objetivemission
ObjectiveMission::refreshTeamScores();

}

function invasion::Finalstep()
{
$Invasion::FinalStep = 1;
schedule("Invasion::CrashFix();", 5);
Invasion::ClearJunk();
%group = "MissionGroup\\Ai";
for(%x = 0; %x < group::objectcount(%group); %x++)
	{
	
	%folder = %group @ "\\bot" @ %x+1;
	%ainame = "German" @ %x;	
	%spawn = group::getobject(%folder, 0);
	%pos =gamebase::getposition(%spawn);
	%rot = gamebase::getrotation(%spawn);
	
	AI::spawn( %AIName, soldier, %Pos, %Rot, $AIName[1, floor(getrandom()*35)], "male2" );
	%aiId = ai::getid(%ainame);
	Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%AiId, 1);
	
	//ai::setvar(%ainame, IQ, 1000);
	//ai::setvar(%ainame, attackmode, 1);
	//ai::setvar(%ainame, Triggerpct, 1);
	//ai::setvar(%ainame, SpotDist, 150);
	
	%classlist = "scout assault assault2 antitank medic engineer";
	%obj = ai::getobject(%ainame);
	
	%class = getword(%classlist, floor(getrandom()*6));
	
	%obj.spawnclass = %class;
	%weapon = $Weapon[%class, German];
	
	player::setitemcount(%aiId, %weapon, 1); //AI::callWithId(%AIname, Player::setItemCount, %weapon, 1);
	player::setitemcount(%aiId, $clip[%weapon], 25); //AI::callWithId(%AIname, Player::setitemcount, $Clip[%weapon], 25);
	player::mountitem(%aiId, %weapon, $weaponslot); //AI::callWithId(%AIname, Player::mountitem, %weapon, $weaponslot);
	
	for(%a = 1; %a < group::objectcount(%folder); %a++) 
		{ 
		
		%marker = group::getobject(%folder, %a); 	
		%pos = gamebase::getposition(%marker);
		
		schedule("ai::directivewaypoint(\"" @ %aiName @ "\",\"" @ %pos @ "\", " @ %a*100+100 @ ");", 5);
		
		}

	}
}

function Invasion::ClearJunk()
{
for(%a = 8000; %a < 10000; %a++)
	{
	if(%a.shreds == 1) deleteobject(%a);
	}
}

function Invasion::CrashFix()
{
ai::setvar("*", iq, 100);
ai::setvar("*", attackmode, 1);
ai::setvar("*", spotdist, 150);
ai::setautomatictargets("*");
}