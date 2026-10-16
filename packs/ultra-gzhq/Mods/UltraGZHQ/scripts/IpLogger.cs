
// String::findSubStr(%a,%b); returns the position of %b in %a, if none, returns -1
// string::ICompare(%a,%b); returns FALSE if %a and %b are the same, otherwise true
// as always ! negates values

// pushing an ip based variable with all connecting names into GZHQInfo.cs 
function server::ConnectInfo(%client)
{
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = client::getName(%client);
	%nameString = $GZHQInfo::[%address];	
	if(!string::ICompare($GZHQInfo::[%address],"") == 1)
	{
		//echo("no existing name, adding new name");
		$GZHQInfo::[%address] = %clname;
		%export = "$GZHQInfo::"@%address;
		export(%export, "config\\GZHQInfo.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";	
	}	
	else
	{			
		//echo("found an existing name");		
		if(!string::ICompare($GZHQInfo::[%address],%clname) == 1)
		{
			%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
			%names = %namestring;	
		}
		else
		{
			if(String::findSubStr(%nameString, "~") > 0)
			{		
				//check other names here.. code gnomes, do your work..
				%names = String::ReplaceStr(%namestring, "~", ", ");
				if(string::findSubStr(%nameString, %clname) != -1)
				{
			//		echo("found clients name");
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;	
				}
				else
				{
			//		echo("adding new name to list");
					$GZHQInfo::[%address] = %clname@"~"@$GZHQInfo::[%address];	
					%export = "$GZHQInfo::"@%address;
					export(%export, "config\\GZHQInfo.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}				
			}
			else
			{
		//		echo("adding 2nd name to list");
				$GZHQInfo::[%address] = %clname@"~"@$GZHQInfo::[%address];
				%export = "$GZHQInfo::"@%address;
				export(%export, "config\\GZHQInfo.cs", true);
				%adminmessage = %clname@"'s IP Has connected before as: "@%namestring;	
				%names = %namestring;
			}			
		}	
	}	
	%adminmessage = %ip@" "@%adminmessage;
	echo(%adminmessage);
	Server::BPAdminMessage(%adminmessage);
	%client.names = %names;
}

function compactIpLog()
{
	// This will clean up IP log, and sort by address. 

	exec(GZHQInfo);
	export("$GZHQInfo::*", "config\\GZHQInfo.cs", false);
}


function Server::BPAdminMessage(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);
		if(%cl.isSuperAdmin || %cl.isAdmin)
		{	
			bottomprint(%cl, "<jc><f1>"@%message, 5);
			if(%cl.weaponHelp)
			{
				%cl.weaponHelp = false;
				schedule(%cl @ ".weaponHelp = true;" ,5);	
			}			
		}
	}
}

