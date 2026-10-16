function Bleed(%x)
{
if($Game::MissionType != "Objective") return;
if(getnumclients() > 0) $WWII::TeamPoints[getteamname(%x)]--;
ObjectiveMission::refreshTeamScores();
if($WWII::TeamPoints[getteamname(%x)] <= 0) { $Berlin::WinnerTeam = !%x; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }
schedule("bleed(" @ %x @ ");", 2);
}

function WWII::CaptureOutpost(%pl, %trig)
{
%outpostgroup = getGroup(%trig);
%plteam = gamebase::getteam(%pl);
if(Player::isAiControlled(%pl)) { %pl.outpost = 0; return; }
for(%x = 0; Group::GetObject(%outpostgroup, %x) != -1; %x++)
	{
	%curobj = Group::GetObject(%outpostgroup, %x);
	Gamebase::SetTeam(%curobj, %plteam);
	}
messageall(1, client::getname(player::getclient(%pl)) @ " took over the " @ GameBase::GetMapName(Group::GetObject(%outpostgroup, 0)) @ " for the " @ getteamname(%plteam) @ " side. ~wcapturedtower.wav");  //OMFG!!
%pl.outpost = 0;
%cl = player::getclient(%pl);
%cl.score += 3;
Game::refreshClientScore(%cl);
bottomprint(player::getclient(%pl), "<jc><f2>Captured Outpost!", 1);
Conquest::SetObjectives();
Conquest::CheckOutposts();
WWII::PutOutpostFlag(%trig);
Stats::OutPostCapture(%pl);
} 

function Conquest::CheckOutposts()
{
%team = 0; %outposts[%team] = 0;
for(%x = 1; NameToID("MissionGroup/Outpost" @ %x) != -1; %x++)
	{
	%curgroup = NameToID("missionGroup/Outpost" @ %x);
	%obj = Group::GetObject(%curgroup, 0);
	%team = GameBase::GetTeam(%obj);
	if(%team != -1) %outposts[%team]++;
	}
if(%outposts[0] == 5) { $Berlin::winnerteam = 0; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }

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
	Team::SetObjective(%x, 9, "<f3>In this \"Server Coop\" map your objective is to take over Berlin before your team loses all its points.\nCapturing all 5 outposts alone is almost impossible, you need to plan the game with your teammates, ");
	Team::SetObjective(%x, 10, "<f3>stay together/split and support each other. This is the main idea of \"Server Coop\".\nThe city is defended by the German army, armed forces that guard the outposts. There is no time to lose..\n");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

function Conquest::MissionComplete()
{
%winner = $Berlin::Winnerteam;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner != "") Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side won the battle of Berlin.");
else Team::SetObjective(%i,1, "<f5><jc>Mission Incomplete!");

}
$loop = false;
schedule("$Berlin::WinnerTeam = \"\";", 1);
}
