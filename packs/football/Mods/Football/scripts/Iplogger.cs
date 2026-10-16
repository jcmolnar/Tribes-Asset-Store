function server::ConnectInfo(%client, %connecting)

{
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = client::getName(%client);
	%nameString = $thunderinfo::[%address];
    

	if(!string::ICompare($thunderinfo::[%address],"") == 1)
	{
		//echo("no existing name, adding new name");
		$thunderinfo::[%address] = %clname;
		%export = "$thunderinfo::"@%address;
		export(%export, "config\\thunderinfo.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";	
	}	
	else
	{			
		//echo("found an existing name");		
		if(!string::ICompare($thunderinfo::[%address],%clname) == 1)
		{
			%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
			%names = %namestring;
                  //merlin
                   echo("ADMINMSG: **** " @ Client::getName(%client) @ " Has connected before, only one name saved for this IP");	
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
					$thunderinfo::[%address] = %clname@"~"@$thunderinfo::[%address];	
					%export = "$thunderinfo::"@%address;
					export(%export, "config\\thunderinfo.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}				
			}
			else
			{
		//		echo("adding 2nd name to list");
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
	//merlin catches all admin messages from the smurf log for tricon
	echo("ADMINMSG: ****" @%adminmessage);
if(!%connecting)
	Server::BPAdminMessage(%adminmessage);
	%client.names = %names;
}

function compactIpLog()
{
	// 

	exec(thunderinfo);
	export("$thunderinfo::*", "config\\thunderinfo.cs", false);
}


function Server::BPAdminMessage(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);

		if(%cl.isAdmin)
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

