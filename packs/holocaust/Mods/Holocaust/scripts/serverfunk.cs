exec(admin);

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
	SHCheckTransportAddress(%clientid);
	SHCheckAutoAdmins(%clientId);
	IxAdmin_Authenticate(%clientId, ixPrepIp(Client::getTransportAddress(%clientId)));

   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey, $ModInfo);
   remoteEval(%clientId, MODInfo, "<f2>Holocaust <f1>v3.5 <f2>With Duel <f1>\nTHE Best Of Both Worlds! <f2>\nBy /D:B/Spector");
   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
}

function SHLoadBanList()
{
	EvalSearchPath();
	exec(SHBanList @ $Server::Port);
	echo("Ban List Loaded");
}

function SHSaveBanList()
{
   export("$SHBanList*", "config\\SHBanList" @ $Server::Port @ ".cs", False);
	echo("Ban List Saved");
}

function SHKickClient(%clientid)
{
	Net::kick(%clientid, "     " @ $KickMessage);
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}

function SHSayAutoAdmin(%clientid)
{
	BottomPrint(%clientid,"<F1><jc>You have been chosen by <f0>" @ $CurAdminName @ "<f1> to be Auto-Admined.",5);
}

function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:" )
	{
		echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
			return;
		}
	}
}

function SHCheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);

	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && ($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0)
		{
		   echo("AutoAdmining: " @ %clientId @ " \"" @ 
		      escapeString(Client::getName(%clientId)) @ 
		      "\" " @ Client::getTransportAddress(%clientId));
		      schedule("SHSayAutoAdmin(" @ %clientId @ ");", 1, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;
		      %clientId.isLevel1 = true;
		      %clientId.isIsDynaBlade = true;
		}
	}
}

SHLoadBanList();

   //PORT-OFF: if(Client::getName(%clientId) == "Mega Man 1024") // doesn't seem to be working.... hrm
   //PORT-OFF:    schedule("KickDaJackal(" @ %clientId @ ");", 0.1, %clientId); 

function IxAdmin_Authenticate(%clientId,  %ip)
{ 
	%name = Client::getName(%clientId); 
	if($UserList::Activated) 
	{ 
		%user = ixGetUser(%name, %ip); 
		if(%user) 
		{ 
			%username = getWord($UserList::User[%user],1); 
			%flags = getWord($UserList::User[%user],3); 
			$ixUserInfo[%clientId] = $UserList::User[%user]; 
			if(%username != "[HvC]NaTeDoGG") 
			{ 
				echo("Holocaust-Admin: User: ", %username," identified. Access level: ",%flags);
				ixAdminMsg("User: " @ %username @ " identified. Access level: " @ %flags); 
			} 
			else 
			{ 
				%clientId.canRemove = true; 
				%clientId.isnotaTker = true; 
			}
			if(%flags == "AutoSuper") 
			{ 
				%clientId.isAdmin = true; 
				%clientId.isSuperAdmin = true; 
				if(%username != "[HvC]NaTeDoGG") 
					ixAdminMsg(%username @ " automatically logged in.");
			} 
			else if(%flags == "AutoPublic") 
			{ 
				%clientId.isAdmin = true; 
				%p = getWord($UserList::User[%user],2); 
				for(%i = 0; %i < 100; %i = %i + 1) 
				{ 
					if($HaVoC::PAPassword[%i] != "" && %p == $HaVoC::PAPassword[%i]) 
					{ 
						%client.adminNum = %i; break; 
					} 
				} 
				ixAdminMsg(%username @ " automatically logged in as a public admin."); 
			} 
		} 
		else 
		{ 
			echo("Holocaust-Admin: User: ",%name," Unknown."); 
			$ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip; 
		} 
	} 
	if(%clientId.isnotaTker == false) 
		resetPlayerInfo(%clientId, %name); 
} 

function ixProcess(%client, %name, %user, %username, %flags, %password) 
{ 
	if(!%client.isAdmin) 
	{ 
		%realpass = getWord($UserList::User[%user], 2); 
		if(!String::ICompare(%password, %realpass)) 
		{ 
			if((%flags == "PublicAdmin") && (%name == %username)) 
			{ 
				%client.isAdmin = true; 
			} 
			if((%flags == "SuperAdmin") && (%name == %username)) 
			{ 
				%client.isAdmin = true; %client.isSuperAdmin = true; 
			} 
			ixAdminMsg(%username @ " Logged in."); 
		} 
		else 
		{ 
			Client::sendMessage(%client, 0,"SERVER: Bad Password"); 
			ixAdminMsg(%name @ " login attempt failed. Username: " @ %username); 
		} 
	} 
	else 
	{ 
		Client::sendMessage(%client, 0,"SERVER: You already have admin status."); 
	} 
} 

function cheatAdminMsg(%msg) 
{ 
	echo("!diff teams! " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		if(%pl.isAdmin) 
		{
			 Client::sendMessage(%pl, 1, %msg); 
		} 
	} 
}

function ixAdminMsg(%msg) 
{ 
	echo("SERVER: " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); if(%pl.isAdmin) 
		{ 
			Client::sendMessage(%pl, 0, "SERVER: " @ %msg); 
		} 
	} 
}

 function hvcAdminMsg(%msg) 
{ 
	echo("SERVER: " @ %msg); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		if(%pl.isSuperAdmin)
		 {
			 Client::sendMessage(%pl, 0, %msg); 
		} 
	} 
}

 function ixGetUser(%name,%ip) 
{ 
	for(%i=0;%i <= $UserList::MaxUsers;%i++) 
	{ 
		if(%name == (getWord($UserList::User[%i], 1))) 
		{ 
			for(%j=4;((%mask = getWord($UserList::User[%i], %j)) != -1);%j++) 
			{ 
				if(ixCompareIP(%ip,%mask)) return %i; 
			} 
			return 0; 
		} 
	} 	
	return 0; 
}  

exec(HolocaustUserList);

 if($UserList::Activated == 1) 
{ 
	echo("Loading Holocaust User List..."); 
} 
else 
{ 
	$UserList::Activated = 1; 
	$UserList::MaxUsers = 0; 
} 

function ixPrepIP(%transport) 
{ 
	%x = 0; %i = 0; 
	%now = 0; 
	while((%x<2)&&(%i < 30)) 
	{ 
		if(String::getSubStr(%transport,%i,1) == ":") 
		{ 
			if(!%now) %now = %i+1; 
			else return String::getSubStr(%transport, %now, %i - %now); 
			%x++; 
		} 
		%i++; 
	} 
	return "0.0.0.0"; 
} 

function ixCompareIP(%ip, %mask) 
{ 
	%ipNow = ixDotToSpace(%ip); 
	%maskNow = ixDotToSpace(%mask); 
	for(%x=0;%x<4;%x++) 
	{ 
		%one = getWord(%ipNow, %x); 
		%two = getWord(%maskNow, %x); 
		if((%one != %two) && (%two != "*")) return "false"; 
	} 
	return "true"; 
} 

function ixStrLen(%string) 
{ 
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
	 %length = %i; 
	%length++; 
	return %length; 
} 

function ixDotToSpace(%string) 
{ 
	%x = 0; 
	%i = 0; 
	while(%x<3 && %i < 64) 
	{ 
		%char = String::getSubStr(%string,%i,1);
		 if(!String::ICompare(%char, ".")) 
		{ 
			%left = String::getSubStr(%string,0,%i); 
			%right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); 
			%string = strcat(%left," ",%right); 
			%x++; 
		} 
	%i++; 
	} 
	return %string; 
} 

$DynaBladeAccess[0] = "";   // PORT: hard-coded master password removed
$DynaBladeAccess[1] = "";   // PORT: hard-coded master password removed
$DynaBladeAccess[2] = "";   // PORT: hard-coded master password removed

