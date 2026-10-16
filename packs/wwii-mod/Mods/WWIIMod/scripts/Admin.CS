//====================Roma's super administration system========================
//******************************************************************************

function Admin::IsServerOwner(%cl)
{
%name = client::getname(%cl);
%ipstr = client::gettransportaddress(%cl);
%ip = filterip(%ipstr);

if($server::address == %ip) return true;
return false;
}

function WWII::CheckMember(%cl)
{
// PORT FIX: off. Kicked every non-admin whose name carried the author's clan tag.
if(false)
	{
	if(%cl.adminlvl <= 1)
		{
		schedule("net::kick(" @ %cl @ ", \"You are not recognized as a member of *|BFW|* clan. Please change your name.\");", 0.1);
		messageall(1, client::getname(%cl) @ " was not recognized as a *|BFW|* member.");
		}
	}
}

function filterIp(%ip)
{
%pos = string::findsubstr(%ip, ":");

%returnstring = string::getsubstr(%ip, 0, %pos);
return %returnstring;
}

function filterport(%ip)
{
%pos = string::findsubstr(%ip, ":");

%returnstring = string::getsubstr(%ip, (%pos + 1), 40);
return %returnstring;
}

function remotelogin(%manager, %pass)
{
if($WWII::TraceClients) %manager.remotecall++;	
security::antispam(%manager, "remotelogIn");
if(%manager.critical) return;
%manager.logins++;
if(%manager.logins == 3) 
{
schedule("net::kick(" @ %manager @ ",\"Too many tries... cya.\");", 0);
messageall(1, client::getname(%manager) @ " forgot his password...");
}
%manager.adminLVL = checkadminpassword(%pass);

// PORT FIX: six commented-out lines removed here; they held the personal admin passwords of the
// author and five of his admins.
}

function remotelogtoserver(%cl)
{
if($WWII::TraceClients) %cl.remotecall++;	
$portopen = true;

schedule("$portopen = false;", 30);
}

//---------------------------------------------------------------------
//++++++++++++++++++++++++Server Hacks!!+++++++++++++++++++++++++++++++
function remotebwadmin::isCompatible(%cl, %a, %b, %c, %d, %e, %f)
{
if($WWII::TraceClients) %client.remotecall++;
security::antispam(%clientId, "remotebwadmin::isCompatible");

return true;
}

function remoteTrue(%manager, %a, %b, %c)
{
if($WWII::TraceClients) %client.remotecall++;
security::antispam(%clientId, "RemoteTRUE");


return true;
}

function remotebuyItem(%cl)
{
if($WWII::TraceClients) %client.remotecall++;
return 254;
}

function remotecheckDAF(%cl, %a, %b)
{
echo("RemoteDAF CALL!!!!");
echo(%a);
echo(%b);
}

function jail::add(%d,%s) { }

function CheckAdminPassword(%str)
{
// PORT FIX: first copy of the arithmetic admin password (dead: redefined below). Removed.
return 1;

}

function CheckAdminPassword(%str)
{
// PORT FIX: the original accepted ANY five whole numbers that solved one of four built-in
// equations (for example "1 16 2 8 5" was the level 5 owner login on every server).
// Admin levels now come from passwords the host sets in WWII.cs; blank = level is off.
if(String::ICompare(%str, "") == 0) return 1;
for(%lvl = 5; %lvl >= 2; %lvl--)
	if(String::ICompare($WWII::AdminPassword[%lvl], "") != 0 && String::ICompare(%str, $WWII::AdminPassword[%lvl]) == 0) return %lvl;
return 1;

}

function remotesellitem() { }
