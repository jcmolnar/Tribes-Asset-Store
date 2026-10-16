function IpLogger::Check(%clientId, %ip){
	%Name = Client::getName(%clientId);
	%NewIp = X::HackIp(%ip);
	
	// Bring In All Variables From IpLoggs.cs File.
	if(isFile("config\\IpLoggs.cs")) exec(IpLoggs);
	// Save Ip And Name, If Neccecary
	if($IpLogger::New[%NewIp] == ""){
		$IpLogger::New["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::New[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] == "" && %Name != $IpLogger::New[%NewIp]){
		$IpLogger::Alias["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::Alias[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] != "" && $IpLogger::AliasAlt[%NewIp] == "" && %Name != $IpLogger::New[%NewIp] && %Name != $IpLogger::Alias[%NewIp]){
		$IpLogger::AliasAlt["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::AliasAlt[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] != "" && $IpLogger::AliasAlt[%NewIp] != "" && %Name != $IpLogger::New[%NewIp] && %Name != $IpLogger::Alias[%NewIp] && %Name != $IpLogger::AliasAlt[%NewIp])
	{ Schedule("TG::Kick(-1, "@ %clientId @");", 20, %clientId); }
	
	// Check For Name Change, For Announcing To Anyone In Game.
	if(%Name != $IpLogger::New[%NewIp] && $IpLogger::New[%NewIp] != ""){
		messageAllAdmins(0, "User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".");
		XBottomPrintAll("<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".", 15);
		Schedule("XBottomPrintAll(\"<jc><f1>User: "@ escapeString(%Name) @" Has Changed Their Name From "@ escapeString($IpLogger::New[%NewIp]) @".\", 14);", 1);
		Schedule("XBottomPrintAll(\"<jc><f1>User: "@ escapeString(%Name) @" Has Changed Their Name From "@ escapeString($IpLogger::New[%NewIp]) @".\", 13);", 2);
		Schedule("XBottomPrintAll(\"<jc><f1>User: "@ escapeString(%Name) @" Has Changed Their Name From "@ escapeString($IpLogger::New[%NewIp]) @".\", 12);", 3);
		Schedule("XBottomPrintAll(\"<jc><f1>User: "@ escapeString(%Name) @" Has Changed Their Name From "@ escapeString($IpLogger::New[%NewIp]) @".\", 11);", 4);
		Schedule("XBottomPrintAll(\"<jc><f1>User: "@ escapeString(%Name) @" Has Changed Their Name From "@ escapeString($IpLogger::New[%NewIp]) @".\", 10);", 5);
	}
}

function IpLogger::DisplayAlias(%admin, %clientId){
	%ip = Client::getTransportAddress(%clientId);
	%ip = X::HackIp(%ip);
	XBottomPrint(%admin, "<jc><f1>Current Name: "@ Client::getName(%clientId) @"\nOriginal Name: "@ $IpLogger::New[%ip] @"\nAlias: "@ $IpLogger::Alias[%ip] @"\nAliasAlt: "@ $IpLogger::AliasAlt[%ip], 2);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 1);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 2);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 3);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 4);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 5);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ escapeString(Client::getName(%clientId)) @"\\nOriginal Name: "@ escapeString($IpLogger::New[%ip]) @"\\nAlias: "@ escapeString($IpLogger::Alias[%ip]) @"\\nAliasAlt: "@ escapeString($IpLogger::AliasAlt[%ip]) @"\", 2);", 6);
}

// special function to 'hack' off the port that shows up at the end up client's ips..
// had to make this since i think the port changes, don't wanna take any chances.
function X::HackIp(%ip){
	for(%i=3;%i<22;%i++){
		if(string::getsubStr(%ip,%i,1)==":"){
			%hackedIp=string::getsubStr(%ip,0,%i);
			return %hackedIp;
		}
	}
}