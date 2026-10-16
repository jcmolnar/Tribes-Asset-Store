function BA2::MainRush()
{
if(getnumbots() > 60) return;
BA2::TeamFix();
%route = "MissionGroup\\AiScript\\Route1";
%spawngroup = "MissionGroup\\Teams\\Team1\\Droppoints\\Start";
%marker = group::getobject(%spawngroup, 1);
%name = "bitchbot" @ floor(getrandom()*1000);
AI::spawn( %name, soldier, gamebase::getposition(%marker), "0 0 0", "Nazi No." @ floor(getrandom()*5555), "male2" );
%id = ai::getid(%name);
%pl = client::getownedobject(%id);
%pl.ainame = %name;
client::getownedobject(%id).specialbot = 1;
Client::setinitialTeam(%Id, 1);
gamebase::setteam(%id, 1);
ai::setvar("*", iq, 1000);
ai::setvar("*", attackmode, 1);
ai::setautomatictargets(%name);
for(%x = 0; %x < group::objectcount(%route); %x++)
	AI::DirectiveWaypoint(%name, gamebase::getposition(group::getobject(%route, %x)), %x*100+100);
%germanclasslist = "scout assault assault2 antitank medic engineer";
%randomclass = randomitems(%germanclasslist, 6);
%obj.spawnclass = %randomclass;
%obj.playerid = client::getownedobject(%Id);	
%weapon = $Weapon[%randomclass, German];
AI::callWithId(%name, Player::setItemCount, %weapon, 1);
AI::callWithId(%name, Player::setitemcount, $Clip[%weapon], 25);
AI::callWithId(%name, Player::mountitem, %weapon, $weaponslot);
AI::SetVar( %Name, triggerPct, 1 );
schedule("BA2::MainRush();", 20);
}

function WWII::StayInOutpost(%trig, %pl)
{
%group = getgroup(%trig);
if(GameBase::getTeam(%pl) == gameBase::GetTeam(%trig)) { %pl.outpost = 0;  return; }
if(%pl.outpost == 4) { WWII::CaptureOutpost(%pl, %trig); return; }
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

function WWII::CaptureOutpost(%pl, %trig)
{
%outpostgroup = getGroup(%trig);
%plteam = gamebase::getteam(%pl);
//if(Player::isAiControlled(%pl)) { %pl.outpost = 0; return; }
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
if(gamebase::getteam(%trig) == 1) 
	{
	%route = "MissionGroup/" @ object::getname(%outpostgroup) @ "/Route";
	BA2::outpostrush(%route, %outpostgroup);
	}
} 

function BA2::OutpostRush(%route, %outpostgroup)
{
if(getnumbots() > 60) return;
BA2::TeamFix();
%name = "forkbot" @ floor(getrandom()*1000);
%stand = group::getobject(%outpostgroup, 0);
if(gamebase::getteam(%stand) != 1) return;
for(%x = floor(getrandom()*group::objectcount(%outpostgroup)); 1; %x = floor(getrandom()*group::objectcount(%outpostgroup))) if(getobjecttype(group::getobject(%outpostgroup, %x)) == "Marker") { %marker = group::getobject(%outpostgroup, %x); break; }
AI::spawn( %name, soldier, gamebase::getposition(%marker), "0 0 0", "Nazi No." @ floor(getrandom()*5555), "male2" );
%id = ai::getid(%name);
%pl = client::getownedobject(%id);
%pl.ainame = %name;
client::getownedobject(%id).specialbot = 1;
Client::setinitialTeam(%Id, 1);
gamebase::setteam(%id, 1);
ai::setvar("*", iq, 1000);
ai::setvar("*", attackmode, 1);
ai::setautomatictargets(%name);
for(%x = 0; %x < group::objectcount(%route); %x++)
	AI::DirectiveWaypoint(%name, gamebase::getposition(group::getobject(%route, %x)), %x*100+100);
%germanclasslist = "scout assault assault2 antitank medic engineer";
%randomclass = randomitems(%germanclasslist, 6);
%obj.spawnclass = %randomclass;
%obj.playerid = client::getownedobject(%Id);	
%weapon = $Weapon[%randomclass, German];
AI::callWithId(%name, Player::setItemCount, %weapon, 1);
AI::callWithId(%name, Player::setitemcount, $Clip[%weapon], 25);
AI::callWithId(%name, Player::mountitem, %weapon, $weaponslot);
AI::SetVar( %Name, triggerPct, 1 );
schedule("BA2::OutpostRush(\"" @ %route @ "\", " @ %outpostgroup @ ");", 20);
}

function BA2::Init()
{
BA2::MainRush();
}

function getnumbots()
{
%clients = 0;
for(%x = 2049; %x < 2222; %x++)
	if(client::getname(%x) != "") %clients++;
%bots = %clients - getnumclients();
return %bots;
}

function BA2::KillBot(%trig, %obj)
{
if(Player::isAIControlled(%obj))
	if(%obj.ainame != "") AI::Delete(%obj.AIName);
}

function BA2::TeamFix()
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext())
	if(gamebase::getteam(%cl) == 1) { player::kill(client::getownedobject(%cl)); gamebase::setteam(%cl, 0); }
}