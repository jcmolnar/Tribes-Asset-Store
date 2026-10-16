//--------------------------------------
//----------TNet-Networking-Functions---
//--------------------------------------
//woot.

//This is the database of all client details (IP,player names and more) -Roma

//exec(Net_Database)

function TNet::onClientConnected(%cl)
{

%ip = client::gettransportaddress(%cl);
%other = $Client::Info[%cl, 5];
if(TNet::GetclientId(%ip, %other) == -1)
	 { TNet::Registerclient(%ip, %other,%cl); return; }
%id = TNet::GetclientId(%ip, %other);
%name = client::getname(%cl);
exec(Net_DataBase);
if(string::findsubstr($TNet::NamesList[%id], %name) == -1) 
	{
	$TNet::NamesList[%id] = $TNet::NamesList[%id] @ " + " @ %name;
	export("TNet*", "Config\\Net_DataBase.cs", false);
	}
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
if(%cl.adminLVL > 2) Bottomprint(%cl, "<f2>TNet: " @ stats::stringfix(%name) @ " IP: " @ %ip @ " recognized. Names: " @ $TNet::NamesList[%id], 10, TNET);
deletevariables("tnet*");	
}

function TNet::DeleteAccount(%cl)
{
%id = TNet::getClientId(client::gettransportaddress(%cl), $Client::Info[%cl, 5]);
exec(Net_Database);
$TNet::IdList = DeleteFromList($TNet::IdList, %id); // PORT FIX: cfs() does not exist; the list was wiped
$TNet::NamesList[%id] = "";
$TNet::SignedIp[%id] = "";
$TNet::ListIPs[%id] = "";
%ip = client::Gettransportaddress(%cl);
for(%x = 0; %x < 20; %x++)
	{
	if(%x == 0) %dots = 0;
	if(string::getsubstr(%ip, %x, 1) == ".") %dots++;
	if(%dots == 3) { %ip = string::getsubstr(%ip, 0, %x); break; }
	}
%ip = stats::Stringfix(%ip);
if($TNet::IpToId[%ip] == %id) $TNet::IpToId[%ip] = "";
$TNet::UDPass[$TNet::UDPassR[%id]] = "";
$TNet::UDPassR[%id] = "";
$TNet::NameToId[stats::stringfix(client::getname(%cl))] = ""; 
File::delete("Temp\\Stats_" @ %id @ ".cs");
export("TNet*", "Config\\Net_DataBase.cs", false);
deletevariables("tnet*");	
kick(%cl, "Your account was removed from this server.");
}

function TNet::getClientId(%ip, %other)
{
exec(Net_Database);
%str = string::getsubstr(stats::stringfix(%other), 0, 30);
if($TNet::UDPass[%str] != "") return $TNet::UDPass[%str];
for(%x = 0; %x < 20; %x++)
	{
	if(%x == 0) %dots = 0;
	if(string::getsubstr(%ip, %x, 1) == ".") %dots++;
	if(%dots == 3) { %ip = string::getsubstr(%ip, 0, %x); break; }
	}
%ip = stats::Stringfix(%ip);
%id = $TNet::IpToId[%ip];

deletevariables("tnet*");
if(%id > 0) return %id;
return -1;
}

function TNet::Registerclient(%ip, %str,%cl)
{

exec(Net_Database);
for(%x = 0; %x < 20; %x++)
	{
	if(%x == 0) %dots = 0;
	if(string::getsubstr(%ip, %x, 1) == ".") %dots++;
	if(%dots == 3) { %ip = string::getsubstr(%ip, 0, %x); break; }
	}
%ip = stats::Stringfix(%ip);

%newID = ((getsimtime()>>5)+String::GetLenth(%str)+string::getlenth(client::getname(%cl))+string::getlenth(%ip))*%cl + floor(getrandom()*500);
if(string::findsubstr(%id, "e") != -1) %newID = TNet::ValidateId(%newID);
$TNet::IpToId[%ip] = %newId;
$TNet::NamesList[%newid] = client::getname(%cl);
$TNet::ListIPs[%newId] = client::gettransportaddress(%cl);
$TNet::SignedIP[%newid] = %ip;
$TNet::NameToId[stats::stringfix(client::getname(%cl))] = %newid;
$TNet::IdList = $TNet::IdList @ %newid @ " ";
export("TNet*", "Config\\Net_Database.cs", False);
deletevariables("tnet*");
}

function TNet::SetIDMode(%cl, %mode, %arg)
{
%id = TNet::GetClientId(Client::GetTransportAddress(%cl), $Client::Info[%cl, 5]);
exec(Net_Database);
if(%mode == "ip") 
	{
	$TNet::UDPass[$TNet::UDPassR[%id]] = "";
	$TNet::UDPassR[%id] = "";
	%ip = stats::stringfix(client::gettransportaddress(%cl));
	$TNet::IpToId[%ip] = %id;
	export("TNet*", "Config\\Net_Database.cs", False);
	deletevariables("tnet*");
	kick(%cl, "Changes saved. Please reconnect.");
	}
else if(%mode == "udpass")
	{
	client::Sendmessage(%cl, 2, "Please type your password in the syntax of: #pass %PASSWORD%  Max: 25 chars & digits!!!");
	%cl.givingudpass = 1;
	}
else if(%mode == "udpassfinal")
	{
	%pass = %arg;
	$TNet::UDPass[%pass] = %id;
	$TNet::UDPassR[%id] = %pass;
	%ip = stats::stringfix(client::gettransportaddress(%cl));
	$TNet::IpToId[%ip] = "";
	export("TNet*", "Config\\Net_Database.cs", False);
	deletevariables("tnet*");
	}

}

function TNet::ValidateId(%newID)
{
while(string::findsubstr(%newid, "e") != -1) %newID = %newID / 3;
return floor(%newID);
}



function remoteTNetDownload(%cl, %pass) //serverside
{
// PORT FIX: this streams the whole player database (every IP and every name used from it)
// to the caller and had no check at all. Server owner (admin level 5) only.
if(%cl.adminLVL != 5) return;
if(%pass != "") 
	{
	remoteeval(%cl, " FUCK YOU", %pass);
	return;
	}
remoteeval(%cl, TNetDownloadApprove);
schedule("TNet::StreamData(" @ %cl @ ");", 4);	
}


function TNet::StreamData(%cl)	//serverside
{
exec(Net_Database);
%size = 128;
%numCL = getnumwords($TNet::IdList);
%full = "$TNet::IdList=\\\""; //"
for(%x = 0; %x < %numCL; %x++)
	{
	%id[%x] = getword($TNet::IdList, %x);
	}
%full = %full @ $TNet::IdList @ "\\\";"; //"  complete id list
for(%x = 0; %x < %numCL; %x++)
	{
	%full = %full @ "$TNet::ListIPs" @ %id[%x] @ "=\\\""; //"         
	%full = %full @ $TNet::ListIPs[%id[%x]] @ "\\\";"; //"
	}
for(%x = 0; %x < %numCL; %x++)
	{
	%full = %full @ "$TNet::NamesList" @ %id[%x] @ "=\\\""; //"         
	%full = %full @ $TNet::NamesList[%id[%x]] @ "\\\";"; //"
	}
for(%x = 0; %x < %numCL; %x++)
	{
	%full = %full @ "$TNet::SignedIP" @ %id[%x] @ "=\\\""; //"         
	%full = %full @ $TNet::SignedIP[%id[%x]] @ "\\\";"; //"
	}
for(%x = 0; %x < %numCL; %x++)
	{
	%full = %full @ "$TNet::IpToId" @ $TNet::SignedIP[%id[%x]] @ "=\\\""; //"         
	%full = %full @ %id[%x] @ "\\\";"; //"
	}
%full = %full @ "$TNet::ServerLaunches=0;";

for(%x = 0; 1; %x++)
	{
	%chunk = string::getsubstr(%full, %x*%size, %size);
	if(%chunk == "") break;
	schedule("echo(putline);remoteeval(" @ %cl @ ",acceptdata," @ string::getlenth(%chunk) @ ",\"" @ %chunk @ "\");", 1+%x/2); //"
	}
schedule("remoteeval(" @ %cl @ ", endfile, \"TNetData\");", 2+%x/2); //"
schedule("TNet::StreamAccounts(" @ %cl @ ");", 3+(%x+1)/2);
deletevariables("tnet*");
}

function TNet::StreamAccounts(%cl)
{
exec(Net_Database);
%size = 128;
%y = 0;
%numCL = getnumwords($TNet::IdList);
for(%x = 0; %x < %numCL; %x++)
	{
	%full = "";
	%id[%x] = getword($TNet::IdList, %x);     						//if($Playerstats::BotKills[%numberoftourney] != "") 
	exec("stats_" @ %id[%x] @ ".cs");
	%full = %full @ "$PlayerStats::BotKills=\\\"" @ $PlayerStats::BotKills @ "\\\";"; 
	%full = %full @ "$PlayerStats::HumanKills=\\\"" @ $PlayerStats::HumanKills @ "\\\";"; 
	%full = %full @ "$PlayerStats::Captures=\\\"" @ $PlayerStats::Captures @ "\\\";"; 
	%full = %full @ "$PlayerStats::TeamKills=\\\"" @ $PlayerStats::TeamKills @ "\\\";"; 
	%full = %full @ "$PlayerStats::Medic=\\\"" @ $PlayerStats::Medic @ "\\\";"; 
	%full = %full @ "$PlayerStats::Suicides=\\\"" @ $PlayerStats::Suicides @ "\\\";";
	%full = %full @ "$PlayerStats::Deaths=\\\"" @ $PlayerStats::Deaths @ "\\\";";    //"
	for(%a = 0; 1; %a++)
		{
		%chunk = string::getsubstr(%full, %a*%size, %size);
		if(%chunk == "") break;
		schedule("remoteeval(" @ %cl @ ",acceptdata," @ string::getlenth(%chunk) @ ",\"" @ %chunk @ "\");", %y/2); //"
		%y++;
		}
	schedule("remoteeval(" @ %cl @ ",endfile, \"PlayerStats\"," @  %id[%x] @ ");", %y/2);
	%y++;
	}
}

function remoteAcceptData(%manager, %size, %data) //clientside
{
// PORT FIX: client-side receiver, but the server loads this file too, so any client could
// grow $accepted on the server without limit.
if(%manager != 2048) return;
$accepted = $accepted @ %data;
echo("Accepted ", %size, " bytes.");
}
