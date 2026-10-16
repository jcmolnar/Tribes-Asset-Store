exec(markerlist);
//Behind Enemy Lines. By:Roma

//paradrop spawn

function M::ChooseSpawn(%clientId, %opt)
{
if(%opt == "!back") { %clientId.choosingclass = true; Game::SpawnInterface(%clientId); return; }
%client.observermode = "";
%y = getnumclients() / 1.5;
centerprint(%clientId, "<jc><f1>You are being spawned on the battlefield...", %y);
if(%opt == "base") schedule("BEL::paradropSpawn(" @ %clientId @ ");", 1+getrandom()*3);
else schedule("Game::playerSpawn(" @ %clientId @ ", false, " @ getword(%opt, 0) @ ");", %y);
}

$BEL::PlanesCount = 0;

function BEL::paradropspawn(%cl)
{
//look for room in plane :-)
if($BEL::PlanesCount == 0) { BEL::SpawnPlane(); BEL::paradropspawn(%cl); return; }
for(%x = 0; %x < $BEL::PlanesCount; %x++)
	{
	for(%y = 0; %y < 4; %y++) if($BEL::PlaneRoom[%x, %y] != 1) 
		{ 
		%room = 1; 
		%plane = $BEL::Plane[%x];
		%planeseat = %y;
		$BEL::PlaneRoom[%x,%y] = 1;
		break;		
		}
	if(%room == 1) break;
	}
if(%room != 1)  //if no room, spawn a plane
	{
	BEL::SpawnPlane(); 
	BEL::paradropspawn(%cl); 
	return;
	} 
%pl = spawnPlayer(soldier, "0 0 -1500", "0 0 0"); // regular player spawn
GameBase::setTeam(%pl, Client::getTeam(%cl));
Client::setOwnedObject(%cl, %pl);
Game::playerSpawned(%pl, %cl);
Client::setControlObject(%cl, %pl);
player::setmountobject(%pl, %plane, %planeseat+2);
%plane.playerlist = %plane.playerlist @ %pl @ " ";
%cl.guilock = ""; 
%cl.dead = "";
echo("SPAWN: " @ client::getname(%clientId) @ " cl:" @ %clientId @ " pl:" @ %pl @ " markergroup: " @ object::getname(getgroup(%spawnMarker)) @ " class: " @ %clientId.spawnclass);
game::refreshclientscore(%cl);	   
}

function BEL::SpawnPlane()
{
%obj = newObject(AutoFlier,"Flier", AutoFlier );
addToSet("MissionCleanup", %obj);
%startpos = vector::add("84 -2000 285", $BEL::PlanesCount*31 @ " " @ 15*sin($BEL::PlanesCount, r) @ " " @ getrandom()*10);
GameBase::setPosition(%obj, %startpos);
GameBase::SetRotation(%obj, "0 0 0");
gamebase::setteam(%obj, 0);
$Bel::Plane[$Bel::PlanesCount] = %obj;
$Bel::PlanesCount++;
schedule("BEL::ParaDrop(" @ %obj @ ");", 31);
schedule("BEL::KillPlane(" @ %obj @ ");", 45);
//plane::loop(%obj);
}

function BEL::Paradrop(%plane)
{
for(%x = 0; %x < 4; %x++) 
	{
	%pl = getWord(%plane.playerlist, %x);
	if(%pl != -1)
		{
		player::setmountobject(%pl, -1, 0);
		gamebase::setposition(%pl, vector::add(gamebase::getposition(%pl), "0 0 -7"));
		schedule("parachute(" @ player::getclient(%pl) @ ");", 1.1);
		}
	}
for(%x = 0; %x < $BEL::PlanesCount; %x++)
	{
	if($BEL::Plane[%x] == %plane)
		for(%i = %x; %i < $BEL::PlanesCount; %i++) 
			{
			$BEL::Plane[%i] = $Bel::Plane[%i+1];
		 	for(%a = 0; %a < 4; %a++) $BEL::PlaneRoom[%i, %a] = $BEL::PlaneRoom[%i+1, %a];
			}
	}
$BEL::PlanesCount--;
}

function BEL::KillPlane(%obj)
{
if(!isObject(%obj)) return;
deleteobject(%obj);
}

function Player::leaveMissionArea(%this)
{
	%this.outArea=1;
	if(player::getmountobject(%this) > 0) return;
	Client::sendMessage(Player::getClient(%this),1,"WARNING!! You are leaving the battle, Deserters will be shot! ~wLeftMissionArea.wav");
	schedule("beep(" @ %this @ ");", 1);
}

//-----------------------------------------------------------------------
//-----------------------------------------------------------------------
//-----------------------------------------------------------------------

function BEL::InitMissionObjectives()
{
schedule("BEL::SpawnAIObj1();",1);
}

function BEL::SpawnAIObj1()
{
%group = "Spawn1";
%groupid = nametoId(%group);
for(%x = 0; %x < 3; %x++)
	{
	%marker = getword($MarkerList[%group], %x);
	%aiName = "objA_bot" @ %x;
	AI::spawn(%aiName, General, $Marker::Position[%marker], $Marker::Rotation[%marker], $AiName[3, floor(getrandom()*20)], "male2" );
	%britishweaponlist = "ybar ylanchester ysniperrifle ybren ysniperrifle ysten ysniperrifle";
	%randomweapon = randomitems(%britishweaponlist, 7);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  %x*45 );
        AI::setVar( %AIname,  SpotDist,  90 );
	AI::setVar( %AIname,  attackMode, 1);
	AI::SetVar( %AIname, triggerPct, 1 );
	AI::SetAutomaticTargets(%ainame);
	%aiId = ai::getId(%aiName);
	Client::setinitialTeam(%aiId, 0);
	GameBase::setTeam(%AiId, 0);
	}
}



function BEL::MeetPoint1(%trig, %obj)
{
if(Player::isAiControlled(%obj)) return;
if($BEL::objStatus >= 1) return;
messageall(0, "----Objective 1 complete!----~wcapturedtower.wav");
$BEL::objStatus = 1;
%group = "AIRoute1";
%groupId = nameToId(%group);
for(%x = 0; %x < 3; %x++)
	for(%i = 0; %i < 10; %i++)
		{
		//%marker0 = group::getObject(%groupId, 0);
		ai::directivewaypoint("objA_bot" @ %x, $Marker::Position[getword($Markerlist[%group], %i)], %i*100+100); 
		}
BEL::SpawnGermanResistance();
}

function BEL::Entrance(%trig, %obj)
{
if($bel::entrance == 1) return;
if(player::isaicontrolled(%obj)) return;
messageall(1, "----Incoming Enemies!---~wLeftMissionArea.wav");
%group = "Barracs2";
for(%x = 0; getword($markerlist[%group], %x) != -1; %x++)
	{
	schedule("BEL::spawnDefenseNoob($Marker::Position[getword($markerlist[" @ %group @ "], " @ %x @ ")],$Marker::Rotation[getword($markerlist[" @ %group @ "], " @ %x @ ")], " @ %x @ ");",%x/3); 
	}
$bel::entrance = 1;

}

function BEL::Spawndefensenoob(%pos, %rot,%num)
{
%ainame = "dumbmeat" @ %num;
ai::spawn(%ainame, soldier, %pos, %rot, $AiName[1, floor(getrandom()*30)], "male2" );
for(%i = 0; getword($MarkerlistAIroute3, %i) != -1; %i++) AI::Directivewaypoint(%AiName, $Marker::Position[getword($MarkerlistAiRoute3, %i)], %i*100);
%Germanweaponlist = "xar xrifle ysubmgun xSTG xmp40";
	%randomweapon = randomitems(%germanweaponlist, 5);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  60 );
        AI::setVar( %AIname,  SpotDist,  90 );
	AI::setVar( %AIname,  attackMode, -1);
	AI::SetVar( %AIname, triggerPct, 0.8 );
	AI::SetAutomaticTargets(%ainame);
	%aiId = ai::getId(%aiName);
	Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%AiId, 1);	
	
}


function BEL::SpawnGermanResistance()
{
%group = "AiDefenceRoute";
for(%x = 0; %x < 4; %x++)
	{
	%thegroup = %group @ %x+1;
	%id = NameToId(%thegroup);
	%marker = getword($Markerlist[%thegroup], 0);
	%aiName = "Resistor" @ %x;
	AI::spawn(%aiName, soldier, $Marker::Position[%marker], $Marker::Rotation[%marker], $AiName[1, floor(getrandom()*30)], "male2" );
	for(%i = 1; getword($Markerlist[%thegroup], %i) != -1; %i++) AI::Directivewaypoint(%AiName, $Marker::Position[getword($Markerlist[%thegroup], %i)], %i*100);
	%Germanweaponlist = "xar xrifle ysubmgun xSTG xmp40";
	%randomweapon = randomitems(%germanweaponlist, 5);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  60 );
        AI::setVar( %AIname,  SpotDist,  90 );
	AI::setVar( %AIname,  attackMode, 1);
	AI::SetVar( %AIname, triggerPct, 0.8 );
	AI::SetAutomaticTargets(%ainame);
	%aiId = ai::getId(%aiName);
	Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%AiId, 1);	
	}
schedule("messageall(0, \"--Germans have spotted your paradrop plane and sent a squad to check the territory!!!---~wLeftMissionArea.wav\");", 6);
}

function BEL::SpawnGermanSnipers()
{
%group = "Sniper";
%id = NameToId(%group);

for(%x = 1; %x <= 9; %x++)
	{
	%cur = group::getobject(%id, %x);
	%marker = getword($Markerlist[%group @ %x],0);
	%aiName = "Sniper" @ %x;
	AI::spawn(%aiName, soldier, $Marker::Position[%marker], $Marker::Rotation[%marker], $AiName[1, floor(getrandom()*30)], "male2" );
	for(%i = 1; getword($Markerlist[%group @ %x], %i) != -1; %i++) AI::Directivewaypoint(%AiName, $Marker::Position[getword($Markerlist[%group @ %x], %i)], %i*100);
	%Germanweaponlist = "xrifle xrifle xrifle xrifle xar";
	%randomweapon = randomitems(%germanweaponlist, 5);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  100 );
        AI::setVar( %AIname,  SpotDist,  105 );
	AI::setVar( %AIname,  attackMode, -1);
	AI::SetVar( %AIname, triggerPct, 0.9 );
	AI::SetAutomaticTargets(%ainame);
	%aiId = ai::getId(%aiName);
	Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%AiId, 1);	
	}
}

function BEL::CleanMemory() { deletevariables("bel*"); deletefunctions("bel*"); exec(objectives); exec(WWII_menu);}


function Bleed(%x)
{
if($Game::MissionType != "Objective") return;
$WWII::TeamPoints[getteamname(%x)]--;
ObjectiveMission::refreshTeamScores();
if($WWII::TeamPoints[getteamname(%x)] <= 0) { $BEL::WinnerTeam = !%x; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }
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
if(%outposts[0] == 5) { $BEL::winnerteam = 0; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }

}

function Conquest::SetObjectives()
{
for(%x = 0; %x < 2; %x++)
	{
	//objective::displayBitmap(%x, 1);
	Team::SetObjective(%x, 2, "<f5>Game status:");
	Team::SetObjective(%x, 3, "<f3>Map name: Behind Enemy Lines" @ $servermission);
	Team::SetObjective(%x, 4, "<f3>Allied points: " @ $WWII::TeamPoints[Allied]);
	Team::SetObjective(%x, 5, "<f3>Axis points: " @ $WWII::TeamPoints[Axis]);
	
	Team::SetObjective(%x, 8, "<f5>Objectives: ");
	Team::SetObjective(%x, 9, "<f3>1.Meet at the meeting point #1\n2.Be escorted to the german bunker and capture. ");
	Team::SetObjective(%x, 10, "<f3>3.Take over the sniper defences.\n4.Make your way and regroup at meeting point #2\n4.Take over the german base.");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

function Conquest::MissionComplete()
{
%winner = $BEL::Winnerteam;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner != "") Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side won the game.");
else Team::SetObjective(%i,1, "<f5><jc>Mission Incomplete!");

}
$loop = false;
schedule("$BEL::WinnerTeam = \"\";", 1);
bel::cleanmemory();
}
