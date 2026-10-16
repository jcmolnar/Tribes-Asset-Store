// - = - = - = - = - = - = - = - = - = - = - = - \\
//      U l t r a  R e n e g a d e s  V X E      \\
// - = - = - = - = - = - = - = - = - = - = - = - \\
//Iplogger.cs

function IPTracker::prepClName(%clname) {
	//This function replaces "~" with "-" in the clients name (if it exists).
	%currname = String::ReplaceStr(%clname, "~", "-");
	return %currname;
}

function IPTracker::Check(%client) {
	%address = Client::getTransportAddress(%client);
	%address = ixPrepIp(%address);
	%ip = %address;
	%address = String::ReplaceStr(%address, ".", ":");
	%clname = IPTracker::prepClName(client::getName(%client));
	%nameString = $IPT::[%address];
	if(!string::ICompare($IPT::[%address],"")) {
		//No records for this IP, so save it to file
		$IPT::[%address] = %clname; %nameString = $IPT::[%address];
		export("$IPT::"@ %address, $IPTracker::File, true);
		%message = %clname@"'s IP has not connected before.";
		%client.names = %nameString;
	} else {
		//IP Found
		if(!string::ICompare($IPT::[%address],%clname)) {
			//This IP has only used 1 name
			%message = %clname@" has connected before, only one name saved for this IP.";
			%client.names = %nameString;
		} else {
			%client.names = String::ReplaceStr(%nameString, "~", ", ");
			%message = %clname@"'s IP has connected before as "@ %client.names;
			//The client is a smurf!! Records show this ip has used other names!
			if (String::getSubStr(%nameString, 0, String::len(%clname)) != %clname && String::findSubStr(%nameString, "~"@%clname) == -1) {
				//This ip has NOT used this name before, so save it in the list!
				$IPT::[%address] = %nameString @ "~" @ %clname;
				%nameString = $IPT::[%address];
				export("$IPT::"@ %address, $IPTracker::File, true);
				echo("this ip has NOT used this name before");
			}
		}
	}
	%adminmessage = %ip @" "@ %message;
	if($IPTracker::EConsole) echo(%message);
	if($IPTracker::ETricon) echo("ADMINMSG: ****"@ %message);
	if($IPTracker::ESuperAdmin) Server::BPAdminMessage("IP Tracker: " @ %message);
	%client.IPTmessage = %message;
}


function compactIpLog() {
	exec($IPTracker::Exec);
	export("$IPT::*", $IPTracker::File, false);
}

function ScompactIpLog() {
	compactIpLog();
	schedule("ScompactIpLog();", 600); //600 seconds = 10 minutes... this will cause a loop.
}

function Server::BPAdminMessage(%message){
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++){		
		%cl = getClientByIndex(%i);
		if(%cl.isSuperAdmin){	
			bottomprint(%cl, "<jc><f1>"@ %message, 8);
		}
	}
}

function String::len(%string){
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++){
		%length++;
	}
	return %length;
}

function String::ReplaceStr(%string, %search, %replace)
{
  %len = String::len(%search);
  for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++) {
    if (%char @ "s" == %search @ "s") 
      %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
  }
  return %string;
}

function ixPrepIP(%transport)
{
	%x = 0;
	%i = 0;
	%now = 0;
	while((%x<2)&&(%i < 30))
	{
		if(String::getSubStr(%transport,%i,1) == ":")
		{	
			if(!%now)
				%now = %i+1;
			else
				return String::getSubStr(%transport, %now, %i - %now);
			%x++;
		}
		%i++;
	}
	return "172.16.0.0";
}
