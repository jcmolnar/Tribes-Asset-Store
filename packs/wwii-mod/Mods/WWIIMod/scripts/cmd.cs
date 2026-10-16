//WWII RTS IMPLEMENTATION PROJECT


function Vector::Rotate(%vec, %opt)
{
if(%opt == "right")
	{
	//%vec = vector::sub(%id.exit, %pos);
	%vx = getword(%vec,0);
	%vy = getword(%vec,1);
	%vz = getword(%vec,2);
	return %vy @ " " @ -%vx @ " " @ %vz;
	}
if(%opt == "left")
	{
	%vx = getword(%vec,0);
	%vy = getword(%vec,1);
	%vz = getword(%vec,2);
	return -%vy @ " " @ %vx @ " " @ %vz;
	}
}

function CMD::ScatterUnits(%list)
{

for(%x = 0; %x < getnumwords(%list); %x++) %position[%x] = gamebase::getposition(getword(%list, %x));

for(%x = 0; %x < getnumwords(%list); %x++)
	for(%y = 0; %y < getnumwords(%list); %y++)
		if(%x != %y)
			{
			%posx = gamebase::getposition(getword(%list, %x));
			%posy = gamebase::getposition(getword(%list, %y));
			%dist[%x,%y] = vector::getdistance(%posx,%posy);
			}

for(%i = 0; %i < getnumwords(%list); %i++)
	{
	%smallestdist = 999;
	for(%j = 0; %j < getnumwords(%list); %j++)
		if(%j != %i)
			{
			if(%dist[%i,%j] < %smallestdist) 
				{
				%smallestdist = %dist[%i,%j];
				%smallestdistid = getword(%list, %j);
				}
			}
	if(1)			//if(%smallestdist < 3)
		{
		%curid = getword(%list, %i); 
		%curpos = %position[%i];
		%hispos = gamebase::getposition(%smallestdistid);
		%vec = vector::multiply(vector::normalize(vector::sub(%curpos, %hispos)), "4 4 4");
		ai::directivewaypoint(client::getname(%curid), vector::add(%curpos, %vec), 1);
		} 
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14,%dest15, %dest16, %dest17, %dest18, %dest19,%dest20, %dest21, %dest22, %dest23, %dest24,%dest25)
{
if($WWII::TraceClients) %commander.remotecall++;	
security::checkmessage(%command);
if($SERVERISGONNABLOWUP == true)
	{
	Security::CrashDetected(%commander);
	return;
	}
	if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   

if(cs(%command, "Repair") && %dest2 != "") 
	{
	for(%i = 1; %dest[%i] != ""; %i++) %list = %list @ %dest[%i] @ " ";
	CMD::ScatterUnits(%list);
	return;
	}
if(cs(%command, "Repair") && %dest2 == "" && cs(client::getname(%dest1), "scout"))
	{
	CMD::BotStrike(%dest1, %wayX @ " " @ %wayY, %commander);
	return;
	}

for(%i = 1; %dest[%i] != ""; %i++)
	{
	%pl = client::getownedobject(%dest[%i]);
	if(Player::ISAIControlled(%pl))
	if(AI::GetObject(client::getname(%dest[%i])).cannotstrike && getsimtime()-ai::getobject(client::getname(%dest[%i])).laststriketime < 20) { }
	else AI::onCommand ( client::getname(%dest[%i]), %commander, 1, %wayX @ " " @ %wayY, "", %command );
	
	}

//for(%i = 1; %dest[%i] != ""; %i = %i + 1)
//      if(!%dest[%i].muted[%commander])
//         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);


}  

deletevariables("cmd*");

//$CMD::constdata[TEAM, BUILDING] = ""; //list of units in queue for this building of this team.


//-----------------cur. unit, percent,  
//$CMD::constbaseDATA[team, building] = "-1";


$CMD::Buildings[0] = "";
$CMD::Buildings[1] = "";

function CMD::Menu(%cl)
{
newmenu(%cl, "\xe4--------Battle Control--------\xe4", "RTS");
addoption(%cl, %x++, "Set Construction", "construct");
addoption(%cl, %x++, "Buildings", "buildings");
}

function M::RTS(%cl, %opt)
{
if(%opt == "construct") 
	{
	newmenu(%cl, "\xd6--------Builder Opts--------\xd6", "construct");
	addoption(%cl, %x++, "Barracks", "barracks");
	addoption(%cl, %x++, "Radar Tower", "radar");
	addoption(%cl, %x++, "Machinegun defense", "browning");
	return;
	}
if(%opt == "buildings") 
	{
	newmenu(%cl, "\xe6--------Buildings--------\xe6", "buildings");
	%team = gamebase::getteam(%cl);
	for(%i = 0; %i < getnumwords($CMD::Buildings[%team]); %i++)
		{
		%curword = getword($CMD::Buildings[%team], %i);
		if(cs(%curword, "barracks")) addoption(%cl, %x++, %curword, %curword);
		}
	return;
	}
}

function M::Buildings(%cl, %opt)
{
if(cs(%opt, "barracks"))
	{
	newmenu(%cl, "\xe1--------" @ %opt @ "--------\xe1", "barracks");
	addoption(%cl, %x++, "Add to queue", "add " @ %opt);
	addoption(%cl, %x++, "Remove from queue", "del " @ %opt);
	addoption(%cl, %x++, "Rotate left", "left " @ %opt);
	addoption(%cl, %x++, "Rotate right", "right " @ %opt);
	return;
	}
}

function M::Barracks(%cl, %opt)
{
%name = getword(%opt, 1);
%opt = getword(%opt, 0);
%team = gamebase::getteam(%cl);
if(%opt == "add")
	{
	newmenu(%cl, "\xe1--------Train--------\xe1", "train");

	if(getword($CMD::constbasedata[%team, %name], 0) == "scout") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Scout(" @ countwordsM($CMD::constdata[%team, %name], "scout")+%add @ ")", "scout " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "assault") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Assault(" @ countwordsM($CMD::constdata[%team, %name], "assault")+%add @ ")", "assault " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "assault2") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Assault2(" @ countwordsM($CMD::constdata[%team, %name], "assault2")+%add @ ")", "assault2 " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "antitank") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Anti-Tank(" @ countwordsM($CMD::constdata[%team, %name], "antitank")+%add @ ")", "antitank " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "antitank2") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Anti-Tank2(" @ countwordsM($CMD::constdata[%team, %name], "antitank2")+%add @ ")", "antitank2 " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "medic") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Medic(" @ countwordsM($CMD::constdata[%team, %name], "medic")+%add @ ")", "medic " @ %name);
	
	if(getword($CMD::constbasedata[%team, %name], 0) == "engineer") %add = 1; else %add = 0;
	addoption(%cl, %x++, "Engineer(" @ countwordsM($CMD::constdata[%team, %name], "engineer")+%add @ ")", "engineer " @ %name);
	return;
	}
else if(%opt == "left")
	{
	%id = getword($CMD::Buildings[%team], getwordnum($CMD::Buildings[%team], %name)+1);
	%rot = gamebase::getrotation(%id);
	%rot = vector::add(%rot, "0 0 1.57079");
	%pos = getboxcenter(%id);
	%vec = vector::sub(%id.exit, %pos);
	%vx = getword(%vec,0);
	%vy = getword(%vec,1);
	%vz = getword(%vec,2);
	%newexit = vector::add(%pos, -%vy @ " " @ %vx @ " " @ %vz);
	%id.exit = %newexit;
	gamebase::setrotation(%id, %rot);
	
	}
else if(%opt == "right")
	{
	%id = getword($CMD::Buildings[%team], getwordnum($CMD::Buildings[%team], %name)+1);
	%rot = gamebase::getrotation(%id);
	%rot = vector::add(%rot, "0 0 -1.57079");
	%pos = getboxcenter(%id);
	%vec = vector::sub(%id.exit, %pos);
	%vx = getword(%vec,0);
	%vy = getword(%vec,1);
	%vz = getword(%vec,2);
	%newexit = vector::add(%pos, %vy @ " " @ -%vx @ " " @ %vz);
	%id.exit = %newexit;
	gamebase::setrotation(%id, %rot);
	}
}

function M::Train(%cl, %opt)
{
%building = getword(%opt, 1);
%class = getword(%opt, 0);
%team = gamebase::getteam(%cl);
$CMD::constdata[%team, %building] = $CMD::constdata[%team, %building] @ %class @ " ";
if(!$CMD::constbaseOnline[%team, %building]) CMD::Updateconstbase(%team, %building);
M::Barracks(%cl, "add " @ %building);
}

function CMD::Updateconstbase(%team,%name)
{
$CMD::constbaseOnline[%team, %name] = 1;
%curunit = getword($CMD::constbaseDATA[%team, %name], 0);
if(%curunit == -1)
	{
	%nextunit = getword($CMD::constdata[%team, %name], 0);
	if(%nextunit != -1)
		{
		%curunit = %nextunit;
		%percent = 0;
		$CMD::constbasedata[%team, %name] = %curunit @ " " @ %percent;
		$CMD::constdata[%team, %name] = DeleteFromList($CMD::constdata[%team, %name], %curunit);
		}
	}
else 
	{
	%percent = getword($CMD::ConstbaseDATA[%team, %name], 1);
	if(%percent < 100) $CMD::ConstbaseDATA[%team, %name] = getword($CMD::ConstbaseDATA[%team, %name], 0) @ " " @ %percent+100/$CMD::BuildTime[%curunit];
	else 
		{
		%constbaseID = getword($CMD::Buildings[%team], getwordnum($CMD::Buildings[%team], %name)+1); //id comes after name
		%spawnpos = %constbaseID.exit;
		%spawnrot = gamebase::getrotation(%constbaseID);
		AI::spawn( %curunit @ %team @ floor(getsimtime()), getword($CMD::SpawnStuff[%curunit], 0), %spawnpos, %spawnrot, %curunit @ %team @ floor(getsimtime()), "male2" );
		%botid = ai::getid(%curunit @ %team @ floor(getsimtime()));
		gamebase::setteam(%botid, %team);
		CMD::SpawnBot(%curunit, %botid, %curunit @ %team @ floor(getsimtime()));
		%rallypoint = vector::add(%spawnpos, vector::neg(vector::multiply(vector::getfromrot(%spawnrot), "16 16 16")));
		AI::DirectiveWaypoint(%curunit @ %team @ floor(getsimtime()), %rallypoint, 1);
		$CMD::ConstbaseDATA[%team,%name] = -1;
		}
	}
schedule("CMD::Updateconstbase(" @ %team @ "," @ %name @ ");", 1);
}

function M::Construct(%cl, %opt)
{
%cl.construct = %opt;
}

function DeleteFromList(%list, %word) //a basic string function:D - Roma
{
%g = 0;
for(%x = 0; %x < getnumwords(%list); %x++)
	{
	%curword = getword(%list, %x);
	if((%curword == %word) && (%g == 0)) { %g = 1; continue; }
	%newlist = %newlist @ %curword @ " ";
	
	}
return %newlist;
}

function CMD::BuilderSpawn()
{
if(NameToID("Missiongroup\\BuilderSpawn0") == -1) return;
exec(cmd);
for(%team = 0; %team <= 1; %team++)
	{
	%group = "Missiongroup\\BuilderSpawn" @ %team;
	for(%i = 0; %i < group::objectcount(%group); %i++)
		{
		%pos = gamebase::getposition(group::getobject(%group, %i));
		AI::spawn( "Builder" @ %team @ %i, general, %pos, "0 0 0", "Builder" @ %team @ %i, "male2" );
		ai::setvar("Builder" @ %team @ %i, iq, 80);
		//ai::setautomatictargets("Builder" @ %team @ %i);
		%AIid = AI::GetId("Builder" @ %team @ %i);
		ai::setvar("Builder" @ %team @ %i, spotdist, 200);
		gamebase::setteam(%aiid, %team);
		} 
	}

}

function cs(%str, %substr) //CheckString
{
if(string::findsubstr(%str, %substr) != -1) return 1;
return 0;
}

function CMD::SimBox(%pos, %dim)
{
%Set = newObject("set",SimSet);
%num = containerBoxFillSet(%Set, $SimInteriorObjectType | $Simplayerobjecttype, %Pos, getword(%dim,0), getword(%dim,1), getword(%dim,2),0); 
deleteobject(%set);
echo("-----------------------");
echo("FOUND ",%num," objects.");
if(%num > 0) return false;
return true;
}

function AI::onDroneKilled(%name)
{
%id = ai::getid(%name);
%obj = ai::getobject(%name);
%team = gamebase::getteam(%id);
if(%obj.group  == "") return;
$CMD::TeamGroup[%team, %obj.group] = DeleteFromList($CMD::TeamGroup[%team, %obj.group], %name);
echo("BOT DEAD: ", $CMD::TeamGroup[%team, %obj.group]);
}

function CMD::SignToGroup(%name, %i, %team)
{
CMD::KickFromGroup(%name, %team);
if(cs($CMD::TeamGroup[%team, %i], %name)) return;
%id = ai::getid(%name);
%obj = AI::getObject(%name);
%obj.group = %i;
if(getnumwords($CMD::TeamGroup[%team, %i]) == 0) %obj.relpos = "0 0 0";
else %obj.relpos = vector::add(vector::sub(gamebase::getposition(ai::getid(getword($CMD::TeamGroup[%team, %i], 0))), gamebase::getposition(%id)), ai::getobject(getword($CMD::TeamGroup[%team, %i], 0)).relpos);

$CMD::TeamGroup[%team, %i] = $CMD::TeamGroup[%team, %i] @ %name @ " ";
}

function CMD::KickFromGroup(%name, %team)
{
%obj = AI::getobject(%name);
%group = %obj.group;
if(%group == "") return;
%obj.group = "";
$CMD::TeamGroup[%team, %group] = DeleteFromList($CMD::TeamGroup[%team, %group], %name);
}

function getnumwords(%str) { for(%x = 0; 1; %x++) if(getword(%str, %x) == -1 && getword(%str, %x+1) == -1) return %x; }

function CMD::BuilderLoop(%ainame, %poscheck)
{
%id = ai::getid(%ainame);
%obj = ai::getobject(%ainame);
%targetpos = %obj.deploypos;
if(vector::getdistance(%poscheck, %targetpos) > 0) return;
%object = %obj.deployobj;
if(%object == "" || %targetpos == "") return;
%curpos = vector::multiply(gamebase::getposition(%id), "1 1 0");
%dist = vector::getdistance(%targetpos, %curpos);
%fulltargetpos = vector::add(vector::multiply(gamebase::getposition(%id), "0 0 1"), %targetpos);
if(%dist < 31)
	{
	if((%obj.percent == "" || %obj.percent == 0) && !CMD::SimBox(%fulltargetpos, $CMD::Dimensions[%object]))
		{
		ai::directivewaypoint(%ainame, %curpos, 1);
		%obj.percent = 0;
		%obj.deployobj = "";
		%obj.deploypos = "";
		Client::sendMessage(%obj.lastcommander, 2, client::getname(%id) @ ": Obstacle in the way! ~wmale1.wobjxcmp.wav");
		return;
		}
	AI::DirectiveWaypoint(%ainame, %curpos, 1);
	%obj.percent += 100/($CMD::BuildTime[%object]/0.2); //for 60 sec total add  
	if(%obj.percent >= 100) 
		{ 
		if(!CMD::SimBox(%fulltargetpos, $CMD::Dimensions[%object]))
			{
			ai::directivewaypoint(%ainame, %curpos, 1);
			%obj.percent = 0;
			%obj.deployobj = "";
			%obj.deploypos = "";
			Client::sendMessage(%obj.lastcommander, 2, client::getname(%id) @ ": Obstacle in the way! ~wmale1.wobjxcmp.wav");
			return;
			}
		Client::sendMessage(%obj.lastcommander, 1, %ainame @ ": Objective completed! ~wmale1.wobjcomp.wav"); 
		%obj.percent = 0; 
		CMD::BuildObject(%object, %fulltargetpos, gamebase::getteam(%id), %id); 
		echo("CONSTRUCTION COMPLETED."); 
		return; 
		}
	//echo("CONSTRUCTING " @ %object @ " " @ %obj.percent);
	}
schedule("CMD::BuilderLoop(" @ %ainame @ ",\"" @ %poscheck @ "\");", 0.2);
}


function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{

echo(%name);
echo(%commander);
echo(%command);
echo(%waypoint);
echo(%cmdtext);
%aiId = AI::getId( %name );
%obj = aI::getobject(%name);
%obj.lastcommander = %commander;
%T = GameBase::getTeam( %aiId );
%worldLoc = WaypointToWorld ( %waypoint );
if(cs(%cmdtext, "Attack") || cs(%cmdtext, "Defend"))  
	{
	if(%obj.group == "") AI::DirectiveWaypoint( %name, %worldLoc, 1 );
	else
		{
		for(%i = 0; %i < getnumwords($CMD::TeamGroup[%T, %obj.group]); %i++)
			{
			%curname = getword($CMD::TeamGroup[%T, %obj.group], %i);
			%curobj = ai::getobject(%curname);
			if(cs(%cmdText, "Defend")) AI::Setvar(%curname, attackmode, 1);
			else AI::Setvar(%curname, attackmode, -1);
			AI::DirectiveWaypoint(%curname, vector::sub(vector::add(%worldloc, %obj.relpos), %curobj.relpos), 1); 
			}
		}
	}
if(cs(%name, "Builder"))
	{
	if((cs(%cmdtext, "Attack") || cs(%cmdtext, "Deploy")) && %obj.percent > 0)
		{
		Client::sendMessage(%commander, 2, %name @ ": I'm busy constructing! ~wmale1.wobjxcmp.wav");
		return;
		}
	if(cs(%cmdtext, "Attack") || cs(%cmdtext, "Deploy") && %obj.deployobj != "")
		{
		%obj.deploypos = "";
		%obj.deployobj = "";
		%obj.percent = "";
		return;
		}
	if(cs(%cmdtext, "Repair")) //Construct
		{
		%object = %commander.construct;
		if(%object == "") return;
		%obj.deployobj = %object;
		%obj.deploypos = %worldloc;
		AI::DirectiveWaypoint(%name, %worldLOC, 1);
		CMD::BuilderLoop(%name, %obj.deploypos); //Builder on duty
		Client::sendMessage(%commander, 2, %name @ ": Roger that! ~wmale1.wacknow.wav");
		
		return;
		}
	%obj.deploypos = "";
	%obj.deployobj = "";
	%obj.percent = "";
	}
if(cs(%cmdtext, "APC")) CMD::KickFromGroup(%name,%t);
if(cs(%cmdtext, "Deploy"))
	{
	if(cs(%cmdtext, "pulse")) CMD::SignToGroup(%name, 1,%t);
	else if(cs(%cmdtext, "jammer")) CMD::SignToGroup(%name, 2,%t);
	else if(cs(%cmdtext, "motion")) CMD::SignToGroup(%name, 3,%t);
	else if(cs(%cmdtext, "camera")) CMD::SignToGroup(%name, 4,%t);
	
	}


//echo ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
	   
//echo( 2, "AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
//echo( 3, "Cmdr:        " @ %commander );
//echo( 3, "Command:     " @ %command );
//echo( 3, "Waypoint:    " @ %waypoint );
//echo( 3, "TargetId:    " @ %targetId );
//echo( 3, "cmdText:     " @ %cmdText );
//echo( 3, "cmdStatus:   " @ %cmdStatus );
//echo( 3, "cmdSequence: " @ %cmdSequence );
    
}

function CMD::barracks(%cl)
{
         Client::buildMenu(%cl, "Barracks:", "barracks", true);
         Client::addMenuItem(%cl, "1Add to queue", "add");
         Client::addMenuItem(%cl, "2Remove from queue", "remove");
         
}

function countwords(%str, %word)
{
%j = 0;
for(%i = 0; %i < getnumwords(%str); %i++) if(cs(getword(%str, %i), %word)) %j++;
return %j;
}
function countwordsM(%str, %word)
{
%j = 0;
for(%i = 0; %i < getnumwords(%str); %i++) if(getword(%str, %i) == %word) %j++;
return %j;
}


function CMD::BuildObject(%name, %pos, %team, %cl)
{
//$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %name @ " ";
if(%name == "barracks")
	{
	%objname = %name @ CountWords($CMD::Buildings[%team], %name);	
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %objname @ " ";
	%obj = newObject(%objname,InteriorShape,"bunker2.dis");
	Addtoset("MissionCleanup", %obj);
	Gamebase::setposition(%obj, %pos);
	getLOSInfo(vector::add(%pos, "0 -20 1000"), vector::add(%pos, "0 -20 -1000"), 1);
	%exit = $los::position;
	%obj.exit = vector::add(%exit, "0 4 2.5"); 
	%deltaZ = getword(%pos, 2) - getword(%exit, 2);
	gamebase::setposition(%obj, vector::sub(%pos, "0 0 " @ %deltaZ + 3));
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	$CMD::ConstBaseDATA[%team, %objname] = "-1";
	}
else if(%name == "radar")
	{
	%objname = %name @ "tower" @ CountWords($CMD::Buildings[%team], %name);	
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %name @ CountWords($CMD::Buildings[%team], %name);	
	%obj = newObject(%objname,InteriorShape,"iobservation.dis");
	Addtoset("MissionCleanup", %obj);
	getLOSInfo(vector::add(%pos, "0 0 1000"), vector::add(%pos, "0 0 -1000"), 1);
	%pos = $los::position;
	Gamebase::setposition(%obj, vector::sub(%pos, "0 0 1"));
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	
	%objname = %name @ "object" @ CountWords($CMD::Buildings[%team], %name);	
	%dataname = getteamname(%team) @ "radar";
	%obj = newObject(%objname,sensor,%dataname);
	Addtoset("MissionCleanup", %obj);
	Gamebase::setposition(%obj, vector::add(%pos, "0 0 24"));
	gamebase::setteam(%obj, %team);
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	}
else if(%name == "browning")
	{
	%objname = %name @ "def" @ CountWords($CMD::Buildings[%team], %name);	
	%obj = newObject(%objname,Turret,Browning);
	Addtoset("MissionCleanup", %obj);
	getLOSInfo(vector::add(%pos, "0 0 1000"), vector::add(%pos, "0 0 -1000"), 1);
	%pos = $los::position;
	%rot = gamebase::getrotation(%cl);
	Gamebase::setposition(%obj, vector::add(%pos, "0 0 1"));
	Gamebase::setrotation(%obj, %rot);
	gamebase::setteam(%obj, %team);
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	
	%front = vector::getfromrot(%rot);
	%right = vector::rotate(%front, right);
	%left = vector::neg(%right);
	%objname = %name @ "blockleft" @ CountWords($CMD::Buildings[%team], %name);
	%obj = newObject(%objname,InteriorShape,"BELcargo4.dis");
	Addtoset("MissionCleanup", %obj);
	%pos1 = vector::sub(vector::add(%pos, vector::multiply(%left, "2 2 2")), "0 0 0.5");
	%pos1 = vector::add(%pos1, vector::multiply(%front, "0.5 0.5 0.5"));
	gamebase::setposition(%obj, %pos1); 
	%rot = vector::sub(%rot, "0 0 1.57079");
	gamebase::setrotation(%obj, %rot);
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	
	%objname = %name @ "blockright" @ CountWords($CMD::Buildings[%team], %name);
	%obj = newObject(%objname,InteriorShape,"BELcargo4.dis");
	Addtoset("MissionCleanup", %obj);
	%pos2 = vector::sub(vector::add(%pos, vector::multiply(%right, "2 2 2")), "0 0 0.5");
	%pos2 = vector::add(%pos2, vector::multiply(%front, "0.5 0.5 0.5"));
	gamebase::setposition(%obj, %pos2); 
	gamebase::setrotation(%obj, %rot);
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %obj @ " ";
	
	%pl = SpawnPlayer(soldier, vector::sub(vector::add(%pos, "0 0 0.5"), vector::multiply(%front, "1 1 1")), gamebase::getrotation(%cl));
	gamebase::setteam(%pl, %team);
	$CMD::Buildings[%team] = $CMD::Buildings[%team] @ %pl @ " ";
	browning.projectiletype = TurretFireCheat;
	}
}

function CMD::SpawnBot(%unit, %id, %ainame)
{
%team = gamebase::getteam(%id);
%country = $country[%team];
%weapon = $weapon[%unit, %country];

player::setitemcount(%id, %weapon, 1);
player::setitemcount(%id, priweapclip, 9999);
Player::mountitem(%id, %weapon, $Weaponslot);
AI::SetAutomaticTargets(%ainame); 
Ai::setvar(%ainame, iq, 800);
Ai::setvar(%ainame, Triggerpct, 1);
AI::Setvar(%ainame, spotdist, $CMD::Unitrange[%unit]);
AI::SetVar(%ainame, attackmode, -1);
}

function CMD::BotStrike(%cl, %pos2d, %commander)
{
%pos = waypointtoworld(%pos2d);
%ainame = client::getname(%cl);
%obj = ai::getobject(%ainame);
if(%obj.cannotstrike) 
	{
	Client::sendMessage(%commander, 2, %ainame @ ": Cannot call yet! ~wmale1.wobjxcmp.wav");
	return;
	}
if(!GetLOSInfo(vector::Add(%pos, "0 0 1000"), vector::add(%pos,  "0 0 -1000"), 1)) return;
%pos = vector::add($los::position, "0 0 1");
AI::DirectiveWaypoint(%ainame, %pos, 1);
CMD::BotStrikeReachTarget(%cl, %pos, %commander);
}

function CMD::BotStrikeReachTarget(%cl, %pos, %commander)
{
echo(CALLYAY);
%ainame = client::getname(%cl);
%obj = ai::getobject(%ainame);
if(vector::getdistance(getboxcenter(%cl), %pos) < 180)
	{
	echo(DISTANCE_OK);
	echo(%pos);
	if(!getLOSInfo(getboxcenter(%cl), %pos, 1))
		{
		echo(LOS_OK);
		%obj.cannotstrike = 1;
		schedule(%obj @ ".cannotstrike = 0;", 90, %obj);
		%obj.laststriketime = getsimtime(); 
		ai::directivewaypoint(%ainame, gamebase::getposition(%cl), 1);

		%plane = newObject("AirStrike",InteriorShape,"gswdrop.dis");
		%planeSpawnPos = Vector::Add(%pos, "0 825 180");
		Gamebase::setposition(%plane, %planeSpawnPos);
		GameBase::startFadeIn(%plane);
		addToSet("MissionCleanup", %plane);
		%plane.plane = 800;
		schedule("Botstrike::PlaneFly(" @ %plane @ ");", 5, %obj);
		schedule("Botstrike::spawnbombs(\"" @ %pos @ "\", " @ client::getownedobject(%cl) @ ");", 20, %obj);
		
		return;
		}
	}
schedule("CMD::BotStrikeReachTarget(" @ %cl @ ",\"" @  %pos @ "\"," @  %commander @ ");", 1);

}

function Botstrike::PlaneFly(%plane)
{
%plane.plane --;
%planepos = gamebase::getposition(%plane);
%pos = vector::sub(%planepos, "0 5 0");
gamebase::setposition(%plane, %pos);
if(%plane.plane == 0) {
deleteobject(%plane);
return;
}
else schedule("botstrike::PlaneFly(" @ %plane @ ");", 0.1);
}

function botstrike::spawnBombs(%pos, %player)
{
		%pos1=1; //right 1
		%pos2=0; //right 2
		%pos3=0; //right 3
		%pos4=0; //front 1
		%pos5=0; //front 2
		%pos6=-1; //front 3
		%pos7=0; //up 1
		%pos8=1; //up 2
		%pos9=0; //up 3
		%pos10=getWord(%pos,0); 
		%pos11=getWord(%pos,1);
		%pos12=getWord(%pos,2);


%transA = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 150 @ " "@%pos12 + 200;
%transB = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 125 @ " "@%pos12 + 300;
%transC = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 100 @ " "@%pos12 + 400;
%transD = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 75 @ " "@%pos12 + 500;
%transE = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 50 @ " "@%pos12 + 600;
%transF = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 25 @ " "@%pos12 + 700;
%transG = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@ " "@%pos12 + 800;
%transH = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 25 @ " "@%pos12 + 900;
%transI = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 50 @ " "@%pos12 + 1000;
%transJ = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 75 @ " "@%pos12 + 1100;
%transK = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 100 @ " "@%pos12 + 1200;
%transL = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 125 @ " "@%pos12 + 1300;
%transM = %pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 150 @ " "@%pos12 + 1400;

%vel = "0 0 0";
Projectile::spawnProjectile("AB",%transA,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transB,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transC,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transD,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transE,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transF,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transG,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transH,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transI,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transJ,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transK,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transL,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transM,%player,%vel).explosive = 1;

}


$CMD::SpawnStuff["scout"] = "soldier";
$CMD::Unitrange["scout"] = 180;
$CMD::BuildTime["scout"] = 5;

$CMD::SpawnStuff["assault"] = "soldier";
$CMD::Unitrange["assault"] = 140;
$CMD::BuildTime["assault"] = 5;

$CMD::SpawnStuff["assault2"] = "soldier";
$CMD::Unitrange["assault2"] = 140;
$CMD::BuildTime["assault2"] = 5;

$CMD::SpawnStuff["antitank"] = "soldier";
$CMD::Unitrange["antitank"] = 150;
$CMD::BuildTime["antitank"] = 5;

$CMD::SpawnStuff["antitank2"] = "soldier";
$CMD::Unitrange["antitank2"] = 160;
$CMD::BuildTime["antitank2"] = 5;

$CMD::SpawnStuff["medic"] = "soldier";
$CMD::Unitrange["medic"] = 140;
$CMD::BuildTime["medic"] = 5;

$CMD::SpawnStuff["engineer"] = "soldier";
$CMD::Unitrange["engineer"] = 160;
$CMD::BuildTime["engineer"] = 5;


$CMD::BuildTime["barracks"] = 3;
$CMD::BuildTime["radar"] = 4;
$CMD::BuildTime["browning"] = 2;

$CMD::Dimensions["barracks"] = "40 40 40";
$CMD::Dimensions["radar"] = "4 4 50";
$CMD::Dimensions["browning"] = "6 6 4";
//x