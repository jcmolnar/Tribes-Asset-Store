// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

function server::ConnectInfo(%client)

{
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = client::getName(%client);
	%nameString = $SMuRFinfo::[%address];
     
     if(%clname == "Armageddon")
     %adminmessage = "Armageddon Has connected before, only one name saved for this IP 'P.S. Im Your GOD!'.";
else
      if(%clname == "[VX]LeGeND")
	%adminmessage = "[VX]LeGeND Has connected before, only one name saved for this IP.";

      else
	
	if(!string::ICompare($SMuRFinfo::[%address],"") == 1)
	{
		$SMuRFinfo::[%address] = %clname;
		%export = "$SMuRFinfo::"@%address;
		export(%export, "config\\SMuRF-INFO.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";	
	}	
	else
	{					
		if(!string::ICompare($SMuRFinfo::[%address],%clname) == 1)
		{
			%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
			%names = %namestring;
                   echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Has connected before, only one name saved for this IP");	
		}
		else
		{
			if(String::findSubStr(%nameString, "~") > 0)
			{		
				//check other names here.. code gnomes, do your work..
				%names = String::ReplaceStr(%namestring, "~", ", ");
				if(string::findSubStr(%nameString, %clname) != -1)
				{
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;	
				}
				else
				{
					$SMuRFinfo::[%address] = %clname@"~"@$SMuRFinfo::[%address];	
					%export = "$SMuRFinfo::"@%address;
					export(%export, "config\\SMuRF-INFO.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}				
			}
			else
			{
				$SMuRFinfo::[%address] = %clname@"~"@$SMuRFinfo::[%address];
				%export = "$SMuRFinfo::"@%address;
				export(%export, "config\\SMuRF-INFO.cs", true);
				%adminmessage = %clname@"'s IP Has connected before as: "@%namestring;	
				%names = %namestring;
			}			
		}	
	}	
	%adminmessage = %ip@" "@%adminmessage;
	echo(%adminmessage);
	echo("ADMINMSG: ****" @%adminmessage);
	Server::BPAdminMessage(%adminmessage);
	%client.names = %names;
}

function compactIpLog()
{
	exec(SMuRFinfo);
	export("$SMuRFinfo::*", "config\\SMuRF-INFO.cs", false);
}


function Server::BPAdminMessage(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);
		if(%cl.isSuperAdmin)
		{	
			bottomprint(%cl, "<jc><f1>"@%message, 8);
			if(%cl.weaponHelp)
			{
				%cl.weaponHelp = false;
				schedule(%cl @ ".weaponHelp = true;" ,5);	
			}			
		}
	}
}