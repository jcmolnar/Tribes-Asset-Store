//----------------------------------------------
//+++++++The+Re-Made+Stats+System+2008++++++++++
//----------------------------------------------

function refreshFiles() //a leet fix
{
$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
}


function Stats::ClientConnect(%cl)
{
refreshfiles();
if(client::Getname(%cl) == "") return;
%id = TNet::getClientId(client::gettransportaddress(%cl), "");

if(!isFile("Temp\\Stats_" @ %id @ ".cs"))
	{
	$PlayerStats::HumanKills = 0;
	$PlayerStats::BotKills = 0;		
	$PlayerStats::Deaths = 0;
	$PlayerStats::Suicides = 0;
	$PlayerStats::Captures = 0;
	$PlayerStats::Teamkills = 0;
	$PlayerStats::Medic = 0;
	export("playerstats*", "temp\\Stats_" @ %id @ ".cs", false);
	}
deletevariables("playerstats*");
}

function Stats::RegisterPlayer(%name,%cl)
{
//empty for now...
}

function Stats::Heal(%medic)
{
%medicid = TNet::getClientId(client::gettransportaddress(%medic), ""); 
exec(net_database);
Stats::WriteData(%medicid, medic, 0.1);
Stats::WriteData(%medicid, medic @ $TNet::ServerLaunches, 0.1);
deletevariables("tnet*");
}		

function Stats::Kill(%victim, %killer, %FFA)
{
%victimid = TNet::getClientId(client::gettransportaddress(%victim), "");
%killerid = TNet::getClientId(client::gettransportaddress(%killer), "");
%vpl = client::getownedobject(%victim);
%kpl = client::getownedobject(%killer);

exec(net_database);	
if(%killer == %victim)
	{
	if(%victimid != -1) 
		{
		Stats::WriteData(%victimid, suicides, 1);
		Stats::WriteData(%victimid, suicides @ $TNet::ServerLaunches, 1);
		}
	}
else if(Client::GetTeam(%killer) == Client::GetTeam(%victim) && %FFA != 1)
	{
	if(%killerid != -1) 
		{
		Stats::WriteData(%killerid, teamkills, 1);
		Stats::WriteData(%killerid, teamkills @ $TNet::ServerLaunches, 1); 
		}
	}
else {
	if(%killerid != -1) 
		{
		if(player::isaicontrolled(%vpl)) 
			{ Stats::WriteData(%killerid, botkills, 1); Stats::WriteData(%killerid, botkills @ $TNet::ServerLaunches, 1); }
		else { Stats::WriteData(%killerid, humankills, 1); Stats::WriteData(%killerid, humankills @ $TNet::ServerLaunches, 1); }
		}
		
	
	if(%victimid != -1) { Stats::WriteData(%victimid, deaths, 1); Stats::WriteData(%victimid, deaths @ $TNet::ServerLaunches, 1); }
	}
deletevariables("tnet*");
Stats::ExportStats();
}

function Stats::OutpostCapture(%pl)
{
if(Player::isAIControlled(%pl)) return;
%cl = Player::getClient(%pl);
%id = TNet::getClientId(client::gettransportaddress(%cl), "");
exec(net_database);
Stats::WriteData(%id, captures, 1); 
Stats::WriteData(%id, captures @ $TNet::ServerLaunches, 1);
Stats::ExportStats();
deletevariables("tnet*");
}

function Stats::StringFix(%string)
{
%clean = "";
%ABC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
for(%x = 0; %x < 20; %x++)
	{
	if(string::getsubstr(%string, %x, 1) == "") break;
	%c = string::getSubstr(%string, %x, 1);
	if(String::findSubStr(%ABC, %c) != -1) %clean = %clean @ %c;
	else %clean = %clean @ " ";
	}
%clean = String::convertspaces(%clean);
return %clean;
}

function Stats::ExportStats()
{
//export("Stats*", "Temp\\WWII_Stats.cs", false);
}

function length(%string)
{
for(%x = 0; true; %x++)
	{
	if(string::getsubstr(%string, %x, (%x + 40)) == "")
		{
		%length = %x;
		break;
		}
	}
return %length;
}

//------------------------------------

function Stats::WriteData(%id, %datavar, %add)
{
refreshfiles();
exec("Stats_" @ %id @ ".cs");		
eval("$PlayerStats::" @ %datavar @ " += " @ %add @ ";");
export("playerstats*", "Temp\\Stats_" @ %id @ ".cs", false);
deletevariables("playerstats*");
	
}