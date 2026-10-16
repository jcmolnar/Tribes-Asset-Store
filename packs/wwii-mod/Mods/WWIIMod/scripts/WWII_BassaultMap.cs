function Bleed(%x)
{
if($Game::MissionType != "Objective") return;
if(getnumclients() > 0) $WWII::TeamPoints[getteamname(%x)]--;
ObjectiveMission::refreshTeamScores();
if($WWII::TeamPoints[getteamname(%x)] <= 0) { $BaseAssault::WinnerTeam = !%x; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }	
schedule("bleed(" @ %x @ ");", 2);
}

function Bassault::opengate()
{
	
	%group = "MissionGroup\\Obj";
	if(group::objectcount(%group) == 0) return;
	%id = NameToId(%group);
	deleteobject(group::getobject(%id, 0));
	messageall(1, "--The Germans have opened the underground emergency exit! ~wcapturedtower.wav");
	
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
if(%outposts[0] == 4) { $BaseAssault::winnerteam = 0; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }

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
	Team::SetObjective(%x, 9, "<f3>In this \"Server Coop\" map your objective is to invade the German base \nand capture all 4 outposts in it. The base is well-defended and has a big underground base.");
	Team::SetObjective(%x, 10, "<f3>Cooperate with your teammates to complete the mission objective before your team's points bleed out. Still reading? Move Out!!!\n");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

function Conquest::MissionComplete()
{
%winner = $BaseAssault::Winnerteam;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner != "") 
	{
	if(%winner == 0) Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side took over the German main base.");
	else Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side successfuly secured their base.");
	}
else Team::SetObjective(%i,1, "<f5><jc>Mission Incomplete!");

}
$loop = false;
schedule("$BaseAssault::WinnerTeam = \"\";", 1);
}

function WWII::PutOutpostFlag(%trig)
{
%group = getgroup(%trig);
%outpost = Group::GetObject(%group, 0);
%pos = gamebase::getposition(%outpost);
%team = gamebase::getteam(%outpost);
if(%team == 0) %obj = NewObject("AlliedFlag", "StaticShape", AlliedFlag, True);
else if(%team == 1) %obj = NewObject("AxisFlag", "StaticShape", AxisFlag, True);
//addToSet("MissionCleanup", %obj);
gamebase::setposition(%obj, %pos);
gamebase::setrotation(%obj, vector::add(gamebase::getrotation(%outpost), "0 0 1.57"));
%newpos = Vector::Add(%pos, vector::neg("-0.0226974 -1.89039 -12.6993"));
gamebase::setposition(%obj, %newpos);
%outpost.flag = %obj;
gamebase::setteam(%obj, %team);
}