/////////////////////////////////////////////
//
//    MY LOG CODE STARTS HERE -WorstAim-
//

function Log::Admin(%clientId, %password, %type)
{
	%ip = client::getTransportAddress(%clientId);
	%name = client::getName(%clientId);
	
	$Name = %name;
	$IP = %ip;
	$Password = %password;
	if(%type != "Failed") $Password = "(not logged)"; // PORT: do not keep working passwords in a log file
	$Status = %type;
	$AdminType = %type@" Admin";	
	$Space = "-----------------------------------------------------------------------";

	if(%type == "Failed")
	{
		newExport("Log::Admin Failed");
	}
	else if(%type == "Master" || %type == "Super" || %type == "Public" || %type == "Owner")
	{
		newExport("Log::Admin Success");
	}
}

function Log::Connection(%clientId)
{
	%ip = client::trimIP(%clientId);
	%ipexists = false;
	%add = false;
	%name = client::getName(%clientId);
	%regip = client::getTransportAddress(%clientId);
	$IP = %regip;
	$Name = %name;
	$Space = "------------------------------------------------------------------------";
	newExport("Log::Connection IPLog");
	for(%i = 0; $Connection[%i, IP] != ""; %i++)
	{
		if($Connection[%i, IP] == %ip)
		{
			%ipexists = true;
			for(%k = 0; $Connection[%i, Name, %k] != ""; %k++)
			{
				if($Connection[%i, Name, %k] == %name && !%add)
				{
					return;
				}
				if($Connection[%i, Name, %k] != %name && $Connection[%i, Name, %k+1] == "")
				{
					echo("Adding A New Alias");
					$Connection[%i, Name, %k+1] = %name;
					%add = true;
				}
			}
		}
	}
	if(%add)
	{
		export("$Connection*", "config\\VX6_PlayerDataBase.cs", false); // Re-Export Entire List, Quicker Search
		return;
	}
	if(%ipexists)
	{		
		return; // IP Exists In DataBase, No New Name Is Being Added
	}
	%k = 0;
	$Connection[%i, IP] = %ip;
	$Connection[%i, Name, %k] = %name;
	export("$Connection*", "config\\VX6_PlayerDataBase.cs", false);
}

function Log::Message(%clientId, %msg)
{
	%name = client::getName(%clientId);
	$Chat = %name@": "@%msg;
	export("$Chat", "config\\VX6_Chat.log", true);
}

function Log::Exploit(%clientId, %type, %function, %var)
{
	%name = client::getName(%clientId);
	%ip = client::getTransportAddress(%clientId);
	
	$player = %name@" - "@%ip;
	$exploit = %type;
	$function = %function;
	if(%var != -1)
	{
		$var = %var;
	}
	$s = "---------------------------------------------------------------------";
	export("$s", "config\\VX6_Exploits.log", true);
	export("$player", "config\\VX6_Exploits.log", true);
	export("$exploit", "config\\VX6_Exploits.log", true);
	export("$function", "config\\VX6_Exploits.log", true);
	export("$var", "config\\VX6_Exploits.log", true);
}
	
function newExport(%function)
{
	%cmd = getWord(%function, 0);
	%arg = getWord(%function, 1);
	if(%cmd == "Log::Admin")
	{
		if(%arg == "Success")
		{
			export("$Space", "config\\VX6_AdminLog.log", true);
			export("$Name", "config\\VX6_AdminLog.log", true);
			export("$IP", "config\\VX6_AdminLog.log", true);
			export("$Password", "config\\VX6_AdminLog.log", true);
			export("$AdminType", "config\\VX6_AdminLog.log", true);
		}
		else if(%arg == "Failed")
		{
			export("$Space", "config\\VX6_AdminAttempts.log", true);
			export("$Name", "config\\VX6_AdminAttempts.log", true);
			export("$IP", "config\\VX6_AdminAttempts.log", true);
			export("$Password", "config\\VX6_AdminAttempts.log", true);
			export("$Status", "config\\VX6_AdminAttempts.log", true);
		}
	}
	else if(%cmd == "Log::Connection")
	{
		if(%arg == "IPLog")
		{
			export("$Name", "config\\VX6_Connections.log", true);
			export("$IP", "config\\VX6_Connections.log", true);
			export("$Space", "config\\VX6_Connections.log", true);
		}
	}
}