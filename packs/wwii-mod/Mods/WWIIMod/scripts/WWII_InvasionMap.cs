function Invasion::AISetup()
{
Invasion::spawnAlliedSnipers();
Invasion::SpawnAlliedArtillery();
Invasion::SpawnGermanSpy();
}

function Invasion::spawnAlliedSnipers()
{
%group = "MissionGroup\\Sniper_AI";
%itemCount = Group::objectCount(%group);

for(%x = 0; %x < %itemcount; %x++)
	{
	%AIname = "Sniper" @ %x;
        %name = $AiName[3, %x];
	%spawnMarker = Group::getObject(%group, %x);
        %spawnPos = GameBase::getPosition(%spawnMarker);
        %spawnRot = GameBase::getRotation(%spawnMarker);
	AI::spawn( %AIName, General, %spawnPos, %spawnRot, %name, "male2" );
	%britishweaponlist = "ybar ysniperrifle ybren ysniperrifle ysten ysniperrifle";
	%randomweapon = randomitems(%britishweaponlist, 6);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  110 );
        AI::setVar( %AIname,  SpotDist,  250 );
	if(%x > 9) AI::setVar( %AIname,  SpotDist,  400 );
	AI::setVar( %AIname,  attackMode, -1);
	AI::SetVar( %AIname, triggerPct, 0.9 );
	GameBase::setTeam(AI::getId(%AiName), 0);
	AI::SetAutomaticTargets(%ainame);
	}
}



function Invasion::SpawnAlliedArtillery()
{
%AIname = "Scout";
%name = $AiName[3, 18];
%group = "MissionGroup\\Artillery_AI";
%spawnMarker = Group::getObject(%group, 0);
%spawnPos = GameBase::getPosition(%spawnMarker);
%spawnRot = GameBase::getRotation(%spawnMarker);
AI::spawn( %AIName, General, %spawnPos, %spawnRot, %name, "male2" );
AI::callWithId(%AIname, Player::setItemCount, ySniperRifle, 1);
AI::callWithId(%AIname, Player::setItemCount, ysnclip, 60);
AI::callWithId(%AIname, Player::mountitem, ySniperRifle, $weaponslot);
AI::setVar( %AIname,  iq,  110 );
AI::setVar( %AIname,  SpotDist,  380 );
AI::setVar( %AIname,  attackMode, -1);
AI::SetVar( %AIname, triggerPct, 0.9 );
GameBase::setTeam(AI::getId(%AiName), 0);
AI::SetAutomaticTargets(%ainame);
}

function Invasion::SpawnGermanSpy()
{
%group = "Missiongroup\\SpyBot";
%AiName = "SpyBot";
%spawnMarker = Group::getObject(%group, 0);
%spawnPos = GameBase::getPosition(%spawnMarker);
%spawnRot = GameBase::getRotation(%spawnMarker);
AI::spawn( %AIName, General, %spawnPos, %spawnRot, "Amir Goldstein", "male4" );
AI::callWithId(%AIname, Player::setItemCount, xstg, 1);
AI::callWithId(%AIname, Player::setItemCount, $Clip[xstg], 20);
AI::callWithId(%AIname, Player::mountitem, xstg, $weaponslot);
AI::setVar( %AIname,  iq,  100 );
AI::setVar( %AIname,  attackMode, -1);
AI::SetVar( %AIname, triggerPct, 1 );
GameBase::setTeam(AI::getId(%AiName), 1);
AI::SetAutomaticTargets(%ainame);
}

function Invasion::SpawnSupportSquad()
{
MessageAll(1, "+++++++Reinforcements have arrived!+++++++~wCapturedTower.wav");
schedule("Messageall(2, \"This map has a part of a 2-mission campaign. Win this one to move on.\");", 5);
%group = "MissionGroup\\Reinforcements";
   %itemCount = Group::objectCount(%group);
    

   if( %group == -1 || %itemCount == 0 )
      dbecho(2, "No AI exists...");  
   	//what the hell?
   else 
   {  
      for(%guard = 1; %guard <= %itemCount; %guard++)
      {
         %AIname = "Bot" @ %guard;
        %name = $AiName[3, $AiNames[3]-5+%guard-1]; 
	//$aiPathNum[%guard] = %AIname;
         createAI(%AIname, %group @ "\\Bot" @ %guard, General, %name);
         %aiId = AI::getId( %AIname );
         Client::setinitialTeam(%aiId, 0);
	GameBase::setTeam(%aiId, 0);
	//Client::setinitialTeam(%clientId, 1);
         AI::setVar( %AIname,  iq,  100 );
         AI::setVar( %AIname,  attackMode, -1);
   
      %aiId.spawnclass = assault;
	%britishweaponlist = "ybar ysten ybren";
	%randomweapon = randomitems(%britishweaponlist, 3);
	AI::SetAutomaticTargets(%ainame);
      AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
      AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 25);
      AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
	AI::SetVar( "*", triggerPct, 1 );
  schedule("Invasion::routechange(" @ %AIName @ ");",50);
	 }}

}

function Invasion::routechange(%aiName)
{
AI::DirectiveRemove(%AiName, 100);
AI::DirectiveRemove(%AiName, 200);
AI::DirectiveRemove(%AiName, 300);
}

function Invasion::AirBorne(%group)
{
%itemcount = group::objectcount(%group);
%planeslist = "";
%add[0] = "0 800 220"; %vel[0] = "0 -5 0";
%add[1] = "980 0 190"; %vel[1] = "-5 0 0";
%add[2] = "400 400 150"; %vel[2] = "-3.5355 -3.5355 0";
 
for(%x = 0; %x < %itemcount; %x++)
	{
	%beacon = Group::getObject(%group, %x);
	%targetpos = GameBase::GetPosition(%beacon);
	%plane = newObject("Paradrop",InteriorShape,"gswdrop.dis");
	%planespawnpos = vector::add(%targetpos, %add[%x]);
	GameBase::setPosition(%plane, %planespawnpos);
	GameBase::setrotation(%plane, vector::add(vector::getrotation(%vel[%x]), "1.57079 0 3.14159"));
	GameBase::startFadeIn(%plane);
	addToSet("MissionCleanup", %plane);
	%plane.fuel = 320;
	%plane.vector = %vel[%x];
	%plane.targetpos = %targetpos;
	%planeslist = %planeslist @ %plane @ " ";
	}
Invasion::ParadropProgress(%planeslist, %itemcount);
}

function Invasion::ParadropProgress(%list, %num)
{
for(%x = 0; %x < %num; %x++) 
	{
	%planeId[%x] = getword(%list, %x);
	GameBase::setposition(%planeId[%x], vector::add(GameBase::getPosition(%planeId[%x]), %planeId[%x].vector));
	%planepos = GameBase::GetPosition(%planeId[%x]);
	%targetpos = %planeId[%x].targetpos;
	%planeposXY = getword(%planepos, 0) @ " " @ getword(%planepos, 1) @ " 0";
	%targetposXY = getword(%targetpos, 0) @ " " @ getword(%targetpos, 1) @ " 0";
	%dist = vector::getDistance(%targetposXY, %planeposXY);
	if(nf(%dist, 140)) Invasion::SpawnChuteBot(%planeId[%x]);
	if(nf(%dist, 105)) Invasion::SpawnChuteBot(%planeId[%x]);
	if(nf(%dist, 70)) Invasion::SpawnChuteBot(%planeId[%x]);
	if(nf(%dist, 35)) Invasion::SpawnChuteBot(%planeId[%x]);
	if(nf(%dist, 0)) Invasion::SpawnChuteBot(%planeId[%x]);
	%planeId[%x].fuel--;
	if(%planeId[%x].fuel == 0) { deleteObject(%planeId[%x]); %RouteDone = 1; }
	}
if(%routedone != 1) schedule("Invasion::ParadropProgress(\"" @ %list @ "\"," @ %num @ ");", 0.1);
}	
	
function Invasion::SpawnChuteBot(%plane)
{
%Spawnpos = vector::add(GameBase::GetPosition(%plane), "0 0 -6");
%Spawnrot = "0 0 " @ getRandom()*3.14159;
%name = $AiName[1, floor(getRandom()*$Ainames[1])];
%AIName = "seal" @ floor(getrandom()*9999);
AI::spawn( %AIName, Soldier, %spawnPos, %spawnRot, %name, "male1" );
AI::setVar( %AIname,  iq,  120 );
AI::setVar( %AIname,  attackMode, -1);
AI::SetVar( %Ainame, triggerPct, 1 );
%germanweaponlist = "xrifle xmp40 ysubmgun xstg xar xstg";
%randomweapon = randomitems(%germanweaponlist, 6);
AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 25);
%aiId = AI::getId( %AIname );
Client::setinitialTeam(%aiId, 1);
GameBase::setTeam(%aiId, 1);
AI::SetAutomaticTargets(%ainame);
schedule("parachute(" @ %aiId @ ");", 1.2);
}

function nf(%num, %val)
{
if(%num+2.1 >= %val && %num-2.1 <= %val) return true;
return false;
} 

function Parachute::Off(%pl)
{
if(Player::isAIControlled(%pl)) WWII::WeaponChange(player::getclient(%pl));
}

function Invasion::MajorAttack(%dir)
{
%group = "MissionGroup\\Major_Attack\\" @ %dir;
%waypoint1 = group::getobject(%group, 0);
%waypoint2 = group::getobject(%group, 1);
%objectcount = Group::objectCount(%group);

for(%x = 2; %x < %objectcount; %x++)
	{
	%AIname = "DeadMeat" @ %dir @ %x;
        %name = $AiName[1, %x-2];
	%spawnMarker = Group::getObject(%group, %x);
        %spawnPos = GameBase::getPosition(%spawnMarker);
        %spawnRot = GameBase::getRotation(%spawnMarker);
	AI::spawn( %AIName, Soldier, %spawnPos, %spawnRot, %name, "male1" );
	%aiId = AI::getId( %AIname );
	%germanweaponlist = "xrifle xmp40 ysubmgun xstg xar xstg";
	%randomweapon = randomitems(%germanweaponlist, 6);
	AI::callWithId(%AIname, Player::setItemCount, %randomweapon, 1);
        AI::callWithId(%AIname, Player::setitemcount, $Clip[%randomweapon], 50);
        AI::callWithId(%AIname, Player::mountitem, %randomweapon, $weaponslot);
        AI::setVar( %AIname,  iq,  100 );
	AI::setVar( %AIname,  attackMode, -1);
	AI::SetVar( %AIname, triggerPct, 1 );
	Client::setinitialTeam(%aiId, 1);
	GameBase::setTeam(%AiId, 1);
	AI::SetAutomaticTargets(%ainame);
	AI::DirectiveWaypoint(%AiName, gamebase::getposition(%waypoint1), 100);	
	AI::DirectiveWaypoint(%AiName, gamebase::getposition(%waypoint2), 200);	
	}
}


function bleed()
{
if($Game::MissionType != "Objective") return;
%group = "MissionGroup\\Outpost1";
%outpost = Group::GetObject(%group, 0);
%team = GameBase::GetTeam(%outpost);
$WWII::TeamPoints[getTeamname(!%team)]--;
ObjectiveMission::refreshTeamScores();
if($WWII::TeamPoints[Allied] <= 0) { $Invasion::WinnerTeam = 1; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }
else if($WWII::TeamPoints[Axis] <= 0) { $Invasion::WinnerTeam = 0; Conquest::MissionComplete(); ObjectiveMission::missionComplete(); }
schedule("bleed();", 2);
}

function Invasion::BeginMissionScript()
{
bleed();
MessageAll(1, "++++Your base is invaded by a German spy! Immediate intruder liquidation required!++++~wcapturedTower.wav"); 
schedule("MessageAll(0, \"++++Your base is invaded by a German spy! Immediate intruder liquidation required!++++~wcapturedTower.wav\"); messageall(0, \"~wLeftMissionArea.wav\");", 30);
schedule("MessageAll(0, \"+++++++2 Minutes left untill German invasion!+++++++~wcapturedTower.wav\"); messageall(0, \"~wLeftMissionArea.wav\");", 100);
schedule("Invasion::SpawnSupportSquad();", 125);
schedule("MessageAll(0, \"+++++++1 Minute left untill German invasion!+++++++~wcapturedTower.wav\"); messageall(0, \"~wLeftMissionArea.wav\");", 160);
schedule("MessageAll(3, \"Allied Aircraft Headquarters Report: Heavy aircraft spotted moving to your position! Prepare all AA guns!\"); messageall(0, \"~wwind1.wav\");", 165);
schedule("MessageAll(0, \"+++++Base Alarm Activated!+++++\"); alarm();", 220);
schedule("Invasion::AirBorne(\"missiongroup\\\\airborne\");", 220.5);
schedule("Alarm();", 221);schedule("Alarm();", 222);schedule("Alarm();", 223);schedule("Alarm();", 224);schedule("Alarm();", 225);schedule("Alarm();", 226);
schedule("Alarm();", 227);schedule("Alarm();", 228);schedule("Alarm();", 229);schedule("Alarm();", 230);schedule("Alarm();", 231);schedule("Alarm();", 232);schedule("Alarm();", 233);
schedule("Invasion::MajorAttack(\"North\");", 280);
schedule("messageall(0, \"++++Incoming infantry from the North!++++\");", 280);
schedule("Invasion::Cleanup();", 285); schedule("Invasion::Cleanup();", 315);
schedule("Invasion::MajorAttack(\"South\");", 340);
schedule("messageall(0, \"++++Incoming infantry from the South!++++\");", 340);
schedule("Invasion::Cleanup();", 345); schedule("Invasion::Cleanup();", 375);
schedule("Invasion::MajorAttack(\"East\");", 400);
schedule("messageall(0, \"++++Incoming infantry from the East!++++\");", 400);
schedule("Invasion::Cleanup();", 405); schedule("Invasion::Cleanup();", 435);
schedule("Invasion::MajorAttack(\"West\");", 460);
schedule("messageall(0, \"++++Incoming infantry from the West!++++\");", 460);

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
	Team::SetObjective(%x, 9, "<f3>In this \"Server Coop\" map your objective is to defend your outpost no matter what happens.\nI suggest to read everything the server sends to you by chat, it is very important. ");
	Team::SetObjective(%x, 10, "<f3>You have some highly-skilled general guards to help you defend. Keep them alive, they are very useful! \nDefend your position from all attacks untill enemy runs out of points. There is no time to lose..\n");
	
	
	WWII::ShowObjectiveStatus(%x);
	}
}

function Conquest::MissionComplete()
{
%winner = $Invasion::Winnerteam;
for(%i = 0; %i < getnumteams(); %i++) {
if(%winner == 0 || %winner == 1) 
	{
	if(%winner == 0) Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side held the control of its position!");
	else if(%winner == 1) Team::SetObjective(%i,1, "<f5><jc>The " @ GetteamName(%winner) @ " side took over the allied outpost!");
	}
else Team::SetObjective(%i,1, "<f5><jc>Mission Incomplete!");

}
$loop = false;

schedule("$Invasion::WinnerTeam = \"\";",1);
}

function Invasion::CleanUp()
{
for(%x = 8000; %x < 10000; %x++)
	{
	if(player::isDead(%x))
		{
		gamebase::startfadeout(%x);
		schedule("deleteobject(" @ %x @ ");", 5);
		}
	}
} 

function ObjectiveMission::missionComplete()
{
   $missionComplete = true;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
   $missionComplete = false;

   // back out of all the functions...
   if($Invasion::WinnerTeam == 0) schedule("Server::loadMission(WWII_Invasion_day2);", 0);
	else Server::NextMission();
exec(objectives);
}
