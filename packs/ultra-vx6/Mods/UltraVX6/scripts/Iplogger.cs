// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

function server::ConnectInfo(%client)

{
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = client::getName(%client);
	%nameString = $thunderinfo::[%address];
     
     if(%clname == "+]-[+Armageddon+")
     %adminmessage = "+]-[+Armageddon+ Has connected before, only one name saved for this IP 'P.S. Im Your GOD!'.";
else
      if(%clname == "+]-[+Messiah+")
	%adminmessage = "+]-[+Messiah+ Has connected before, only one name saved for this IP.";

      else
	
	if(!string::ICompare($thunderinfo::[%address],"") == 1)
	{
		$thunderinfo::[%address] = %clname;
		%export = "$thunderinfo::"@%address;
		export(%export, "config\\thunderinfo.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";	
	}	
	else
	{					
		if(!string::ICompare($thunderinfo::[%address],%clname) == 1)
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
					$thunderinfo::[%address] = %clname@"~"@$thunderinfo::[%address];	
					%export = "$thunderinfo::"@%address;
					export(%export, "config\\thunderinfo.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}				
			}
			else
			{
				$thunderinfo::[%address] = %clname@"~"@$thunderinfo::[%address];
				%export = "$thunderinfo::"@%address;
				export(%export, "config\\thunderinfo.cs", true);
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
	exec(thunderinfo);
	export("$thunderinfo::*", "config\\thunderinfo.cs", false);
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