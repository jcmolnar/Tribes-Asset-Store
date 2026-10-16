
// IP logger copyright 2002 by  Steve Madden, aka Plasmatic 
// ziptiezmail@netscape.net

// notes -Plasmatic
// String::findSubStr(%a,%b); returns the position of %b in %a, if none, returns -1
// string::ICompare(%a,%b); returns FALSE if %a and %b are the same, otherwise true
// as always ! negates values

// pushing an ip based variable with all connecting names into AnnInfo.cs -plasmatic
function server::ConnectInfo(%client)
{
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = client::getName(%client);
	%nameString = $annInfo::[%address];	
	if(!string::ICompare($annInfo::[%address],"") == 1)
	{
		//echo("no existing name, adding new name");
		$annInfo::[%address] = %clname;
		%export = "$annInfo::"@%address;
		export(%export, "config\\AnnInfo.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";	
	}	
	else
	{			
		//echo("found an existing name");		
		if(!string::ICompare($annInfo::[%address],%clname) == 1)
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
					$annInfo::[%address] = %clname@"~"@$annInfo::[%address];	
					%export = "$annInfo::"@%address;
					export(%export, "config\\AnnInfo.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}				
			}
			else
			{
		//		echo("adding 2nd name to list");
				$annInfo::[%address] = %clname@"~"@$annInfo::[%address];
				%export = "$annInfo::"@%address;
				export(%export, "config\\AnnInfo.cs", true);
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
	// This will clean up IP log, and sort by address. -Plasmatic

	exec(AnnInfo);
	export("$annInfo::*", "config\\AnnInfo.cs", false);
}


function Server::BPAdminMessage(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);
		if(%cl.isSuperAdmin || %cl.isAdmin)
		{	
			bottomprint(%cl, "<jc><f1>"@%message, 20);
			if(%cl.weaponHelp)
			{
				%cl.weaponHelp = false;
				schedule(%cl @ ".weaponHelp = true;" ,5);	
			}			
		}
	}
}

