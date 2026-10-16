//===============WWII MOD CONQUEST GAME TYPE CODE=================

function Conquest::SetObjectives()
{
for(%x = 0; %x < 2; %x++)
	{
	//objective::displayBitmap(%x, 1);
	Team::SetObjective(%x, 2, "<f5>Game status:");
	Team::SetObjective(%x, 3, "<f3>Map name: " @ $servermission);
	Team::SetObjective(%x, 4, "<f3>Allied points: " @ $WWII::TeamPoints[Allied]);
	Team::SetObjective(%x, 5, "<f3>Axis points: " @ $WWII::TeamPoints[Axis]);
	
	Team::SetObjective(%x, 8, "<f5>Objectives: ");
	Team::SetObjective(%x, 9, "<f3>The objectives of the new \"Conquest\" game type are simple: capture as many outposts as you and your teammates can. \nStand in the outpost territory to capture it. Each team starts with a specified number of points. ");
	Team::SetObjective(%x, 10, "<f3>Ownage of more outposts than the enemy makes the enemy points *bleed*. The side that first runs\nout of points LOSES. Every player spawn life costs his side 1 point (death takes it away).");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

StaticShapeData WWII_Outpost
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Outpost Flag Stand";
};

StaticShapeData WWII_BasePost
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 99999.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Main Base Outpost";
};



TriggerData Outpost
{
	className = "Trigger";
	rate = 2.0;
};

function Outpost::onEnter(%this,%object)
{
WWII::TouchOutpost(%this, %object);
}	

function Outpost::onLeave(%this,%object)
{
WWII::LeaveOutpost(%this, %object);
	
}

function Outpost::onContact(%this,%object)
{
WWII::StayInOutpost(%this, %object);	
}

function Outpost::onActivate(%this)
{

}

function Outpost::onDeactivate(%this)
{
}

function WWII::TouchOutpost(%trig, %pl)
{
%group = getgroup(%trig);
//if(gamebase::getteam(Group::GetObject(%group, 0)) == gamebase::getteam(%pl)) return;
%cl = Player::GetClient(%pl);
%cl.trigger = %trig;
bottomprint(%cl, "<jc><f2>Entered outpost territory...", 1,OUTPOST);
}

function WWII::StayInOutpost(%trig, %pl)
{
%group = getgroup(%trig);
if(Player::IsAIControlled(%pl))
	{
	if(%pl.ainame != "")
		{
		if(gamebase::getteam(%pl) != gamebase::getteam(%trig)) $AI::Int[%pl.ainame] = "Capturing outpost " @ %trig;
		else $AI::Int[%pl.ainame] = "Contacting outpost " @ %trig;
		}
	}
if(GameBase::getTeam(%pl) == gameBase::GetTeam(%trig)) { %pl.outpost = 0;  return; }
if(%pl.outpost == 35) { WWII::CaptureOutpost(%pl, %trig); return; }
%cl = player::getClient(%pl);
if(gamebase::getteam(Group::GetObject(%group, 0)) != gamebase::getteam(%pl)) bottomprint(%cl, "<jc><f2>Capturing...", 1.3,OUTPOST);
%alliedplayers = 0; %axisplayers = 0;
for(%x = 2049; %x < 2200; %x++) 
	{
	if(%x.trigger == %trig) 
		{
		if(gamebase::getteam(%pl) == 0) %alliedplayers++; 
		else %axisplayers++;
		}
	}
if(%alliedplayers > 0 && %axisplayers > 0) 
	{ 
	for(%x = 2049; %x < 2200; %x++) if(%x.trigger == %trig) { %f = client::getownedobject(%x); %f.outpost = 9; }
	if(%pl.outpost > 10) %pl.outpost = 9; %pl.outpost++; 
	}
else if(gamebase::getteam(Group::GetObject(%group, 0)) != gamebase::getteam(%pl)) %pl.outpost++;
if(%pl.outpost == 10) WWII::InvadeOutpost(%pl, %trig); 
}

function WWII::LeaveOutpost(%trig, %pl)
{
%cl = player::getclient(%pl);
%cl.trigger = 0;
%pl.outpost = 0;
}

function WWII::ShowObjectiveStatus(%y)
{
Team::SetObjective(%y, 12, "\n<f8>Objective Status:");
%a = 23;
for(%x = 1; NameToID("MissionGroup/Outpost" @ %x) != -1; %x++)
	{
	%curgroup = NametoID("MissionGroup/Outpost" @ %x);
	%outpost = Group::GetObject(%curgroup, 0);
	%outpostname = GameBase::GetMapName(%outpost);
	%outpostowner = GameBase::GetTeam(%outpost);
	if(%y == %outpostowner) %start = "<f1>\xa4Your side has control of the ";
	else if(%outpostowner == -1) %start = "<f0>\xa4Take control of the ";
	else %start = "<f4>\xa4The " @ GetTeamName(%outpostowner) @ " side has control of the ";
	%string = "\n\n\n" @ %start @ %outpostname;
	Team::SetObjective(%y, 13+%x, "<f3>" @ %string);
	
	
	}

}

function WWII::InvadeOutpost(%pl, %trig)
{
%outpostgroup = getGroup(%trig);
%outpost = Group::GetObject(%outpostgroup, 0);

if(gamebase::getteam(%outpost) == -1) return;
if(%outpost.flag > 0 && getobjecttype(%outpost.flag) == "StaticShape")  
	{
	DeleteObject(%outpost.flag);
	%outpost.flag = false;
	}
for(%x = 0; Group::GetObject(%outpostgroup, %x) != -1; %x++)
	{
	%curobj = Group::GetObject(%outpostgroup, %x);
	Gamebase::SetTeam(%curobj, -1);
	}
Conquest::SetObjectives();
Conquest::CheckOutposts();
WWII::CheckPlayerSpawnPoints(%trig);
}


function WWII::CaptureOutpost(%pl, %trig)
{
%outpostgroup = getGroup(%trig);
%plteam = gamebase::getteam(%pl);

//if(%plteam == gamebase::getTeam(%trig)) return;
for(%x = 0; Group::GetObject(%outpostgroup, %x) != -1; %x++)
	{
	%curobj = Group::GetObject(%outpostgroup, %x);
	Gamebase::SetTeam(%curobj, %plteam);
	}
messageall(1, client::getname(player::getclient(%pl)) @ " took over the " @ GameBase::GetMapName(Group::GetObject(%outpostgroup, 0)) @ " for the " @ getteamname(%plteam) @ " side. ~wcapturedtower.wav");  //OMFG!!
%pl.outpost = 0;
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
{
if(%cl.trigger == %trig) %cl.score += 3;
Game::refreshClientScore(%cl);
bottomprint(player::getclient(%pl), "<jc><f2>Captured Outpost!", 1,OUTPOST);
}
Conquest::SetObjectives();
Conquest::CheckOutposts();
WWII::PutOutpostFlag(%trig);
if($loop != true) { $loop = true; Conquest::startloop(); }
Stats::OutPostCapture(%pl);
WWII::CheckPlayerSpawnPoints(%trig);
}

function Conquest::CheckOutposts()
{

for(%x = 1; NameToID("MissionGroup/Outpost" @ %x) != -1; %x++)
	{
	%curgroup = NameToID("missionGroup/Outpost" @ %x);
	%obj = Group::GetObject(%curgroup, 0);
	%team = GameBase::GetTeam(%obj);
	if(%team != -1) %outposts[%team]++;
	}
if(%outposts[0] < %outposts[1]) $WWII::TeamPoints[getteamname(0)]--;
else if(%outposts[1] < %outposts[0]) $WWII::TeamPoints[getteamname(1)]--;	
ObjectiveMission::refreshTeamScores();
for(%i = 0; %i < getnumteams(); %i++)
if($Game::MissionType == "Conquest" && $WWII::TeamPoints[getteamname(%i)] <= 0) { ObjectiveMission::missionComplete(); Conquest::setObjectives(); Conquest::MissionComplete();  }
conquest::setobjectives();
}

function Conquest::MissionComplete()
{
if($WWII::TeamPoints[Allied] < $WWII::TeamPoints[Axis]) %winner = Axis;
else if($WWII::TeamPoints[Axis] < $WWII::TeamPoints[Allied]) %winner = Allied;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner != "") Team::SetObjective(%x,1, "<f5><jc>The " @ %winner @ " side won the battle.");
else Team::SetObjective(%x,1, "<f5><jc>Its a tie!");
}
$loop = false;
}

function WWII::PutOutpostFlag(%trig)
{
%group = getgroup(%trig);
%outpost = Group::GetObject(%group, 0);
if(%outpost.flag > 0 && getobjecttype(%outpost.flag) == "StaticShape") 
	{
	DeleteObject(%outpost.flag);
	%outpost.flag = false;
	}
%pos = gamebase::getposition(%outpost);
%team = gamebase::getteam(%outpost);
if(%team == 0) %obj = NewObject("AlliedFlag", "StaticShape", AlliedFlag, True);
else if(%team == 1) %obj = NewObject("AxisFlag", "StaticShape", AxisFlag, True);
addToSet("MissionCleanup", %obj);
gamebase::setposition(%obj, %pos);
gamebase::setrotation(%obj, vector::add(gamebase::getrotation(%outpost), "0 0 1.57"));
%newpos = Vector::Add(%pos, vector::neg("-0.0226974 -1.89039 -12.6993"));
gamebase::setposition(%obj, %newpos);
%outpost.flag = %obj;
gamebase::setteam(%obj, %team);
}

function Conquest::StartLoop()
{
if(!$loop || $Game::MissionType != "Conquest") { $loop = false; return; }
Conquest::CheckOutposts();
schedule("Conquest::StartLoop();", 5);
}

function WWII::ForceCaptureOutpost(%group, %team)
{
%outpostgroup = %group;
for(%x = 0; Group::GetObject(%outpostgroup, %x) != -1; %x++)
	{
	%curobj = Group::GetObject(%outpostgroup, %x);
	Gamebase::SetTeam(%curobj, %team);
	}

Conquest::SetObjectives();
Conquest::CheckOutposts();
WWII::PutOutpostFlag(group::getobject(%group, 1));
if($loop != true) { $loop = true; Conquest::startloop(); }

}


function WWII::CheckPlayerSpawnPoints(%trig)
{
for(%cl = client::getfirst(); %cl != -1; %cl = Client::getnext(%cl))
	{
	%team = gamebase::getteam(%cl);
	if(%cl.menumode == "choosespawn")
		{
		%cl.menumode = "";
		Game::SpawnInterface(%cl);
		%cl.menumode = "";
		m::chooseclass(%cl,%cl.spawnclass);
		} 
	}
}