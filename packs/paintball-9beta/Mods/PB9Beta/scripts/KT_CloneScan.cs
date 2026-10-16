// ------------------------------------------------------------------------------------------------
//           ___  _     ___  __   _  ___     ___   ___   _   __   _  __   _  ___  ___
//          /  _|| |   /   \|  \ | ||  _|   / __| /  _| / \ |  \ | ||  \ | ||  _|| _ |
//          | /  | |   | | ||   \| || |_    \_  \ | /  | - ||   \| ||   \| || |_ |  _|
//          | \_ | |__ | | || |\   || |_    __\  || \_ |   || |\   || |\   || |_ |  \
//          \___||____|\___/|_| \__||___|   \___/ \___||_|_||_| \__||_| \__||___||_|_|
//                                            -v1.0-
// By: KingTomato
// ------------------------------------------------------------------------------------------------

// Clone Prefs
$Clones::WatchEnabled	= True;
$Clones::CloneFile	= "ClonesList.cs";

// Logging To File
$Clones::LoggingEnabled	= True;
$Cloned::LoggingFile	= "ServerLog.cs";

///////////////////////////////////////////////////////////////////////////////////////////////////
// Connection Events

function Clones::Init() {
	$Clones::WasFile = isFile("config\\" @ $Clones::CloneFile);
	if ($Clones::WasFile)
		exec($Clones::CloneFile);
}

function Clones::OnConnect(%client) {

	// Logging Name, Ip, and Connection Time
	Logging::OnConnect(%client);

	// Get the name and ip
	%name    = Client::GetName(%client);
	%ip      = Clones::IpOnly(Client::GetTransportAddress(%client));
	%address = Clones::RepIp(%ip);

	%cloneList = $Clones::List[%address];

	%adminMsg = "<jc><f2>Clone Scanner v1.0\n\n<f0>Client:<f1> " @ %name @ "\n<f0>Clones:<f1> ";

	if (%cloneList == "") {
		$Clones::List[%address] = %name;
		%clones   = %name;
		%adminMsg = %adminmsg @ "(First Recorded Join)";
		export("$Clones::List*", "config\\" @ $Clones::CloneFile, false);
	}
	else {
		if (String::findSubStr($Clones::List[%address], %name) != -1) {
			%clones   = $Clones::List[%address];
			%adminmsg = %adminmsg @ %clones;
		}
		else {
			for (%len = 0; String::getSubStr(%name, %len, 1) != ""; %len++)
			{}

			if (String::FindSubStr(%name, ".1") == (%len - 2))
				%name = String::getSubStr(%name, 0, %len - 2); // PORT: the string argument was missing

			if (String::findSubStr($Clones::List[%address], %name) != -1) {
				%clones   = $Clones::List[%address];
				%adminmsg = %adminmsg @ %clones;
			}
			else {
				$Clones::List[%address] = $Clones::List[%address] @ ", " @ %name;
				%clones   = $Clones::List[%address];
				%adminmsg = %adminmsg @ %clones;
				export("$Clones::List*", "config\\" @ $Clones::CloneFile, false);
			}
		}
	}

	for (%cl = Client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
		if (%cl.isSuperAdmin) {
			bottomPrint(%cl, %adminmsg, 10);
			Client::sendMessage(%cl, 0, "Other known aliases: " @ %clones);
		}
	}
}

function Clones::OnDisconnect(%client) {

	// Logging Name, Ip, Connection Duration
	Logging::OnDisconnect(%client);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Logging

function Logging::OnConnect(%client) {
	if (!$Clones::LoggingEnabled)
		return;

	%logName = String::getSubStr(Client::getName(%client) @ "                ", 0, 16);
	%logIp   = String::getSUbStr(Client::getTransportAddress(%clientId) @ "            ", 0, 24);

	// Set the time they connected (For a duration timer on disconnect)
	%clientId.cTime = getIntegerTime(True) >> 5;

	// Log the connections to a file
	$ip = "Name: " @ %logName @ " - " @ %logIp @ " - Session Time: " @ %clientId.connectTime;

	// Logging To File
	export("$ip", "config\\" @ $Cloned::LoggingFile, true); // PORT: was $Clones::LoggingFile, which is never set
	
}

function Logging::OnDisconnect(%client) {
	if (!$Clones::LoggingEnabled)
		return;

	%logName = String::getSubStr(Client::getName(%client) @ "                ", 0, 16);
	%logIp   = String::getSUbStr(Client::getTransportAddress(%clientId) @ "            ", 0, 24);

	%ctime		= getIntegerTime(True) >> 5;
	%connectTime	= %ctime - %clientId.cTime;

	$ip = "Name: " @ %logName @ " - " @ %logIp @ " - Session Time: " @ Clones::Duration(%connectTime);
	export("$ip", "config\\" @ $Cloned::LoggingFile, true);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Functions

// Turns IP:255.255.255.255:2555 into 255.255.255.255
function Clones::IpOnly(%ip) {
	%ip = String::getSubStr(%ip, 3, 15) @ ":";
	return String::getSubStr(%ip, 0, String::findSubStr(%ip, ":"));
}

// turns 12.345.6.78 into 12_345_6_78
function Clones::RepIp(%ip) {
	%loc  = String::findSubStr(%ip, ".");
	while (%loc != -1) {
		%pre  = String::getSubStr(%ip, 0, %loc);
		%post = String::getSubStr(%ip, %loc + 1, 99);

		%ip = %pre @ "_" @ %post;

		%loc  = String::findSubStr(%ip, ".");
	}
	return %ip;
}

// Turns seconds into hh:mm:ss format
function Clones::Duration(%time) {
	// Durations
	%hours	= 0;
	%mins	= 0;
	%secs	= 0;

	// Actual Numbers
	%min	= 60;
	%hour	= %min * 60;

	if (%time >= %hour) {
		%hours	= floor(%time / %hour);
		%time	-= %hours * %hour;
	}

	if (%time >= %min) {
		%mins	= floor(%time / %min);
		%time	-= %mins * %min;
	}

	%secs	= %time;

	if (%houra < 10)
		%hours	= "0" @ %hours;
	if (%mins < 10)
		%mins	= "0" @ %mins;
	if (%secs < 10)
		%secs	= "0" @ %secs;	

	return %hours @ ":" @ %mins @ ":" @ %secs;
}

Clones::Init();