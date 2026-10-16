exec(combatAdmin);
exec(bwadmin);

// - BW Admin Mod -
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;


function Admin::changeMissionMenu(%clientId, %first, %leaguenext)
{
   	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   	%index = 1;
   	%listfull = false;
   	if(%clientId.AdminReferee || %clientId.AdminServerSettings)
   		%listfull = true;
   	if($bwadmin::FullPublicMapList == "true")
   		%listfull = true;
   	if($bwadmin::MRenabled != "true")
   		%listfull = true;

   	if(%listfull)
   	{
		if ($MList::TypeCount < 2)
			$TypeStart = 0;
		if (%first)
			$TypeStart = %first;
		else
			$TypeStart = 1;
	   	for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++) {
		  	if($MLIST::Type[%type] != "Training") {
			 	if(%index > 7) {
					Client::addMenuItem(%clientId, %index @ "More mission types..", "more " @ %index + %first -1 @ " " @ %leaguenext);
					return;
			 	}
			 	Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %leaguenext);
			 	%index++;
		  	}
	   	}
	} else {
		if ($MR::TypeCount < 2)
			$TypeStart = 0;
		if (%first)
			$TypeStart = %first;
		else
			$TypeStart = 1;
		for(%type = $TypeStart; %type < $MR::TypeCount+1; %type++) {
		  	if($MR::Type[%type] != "Training") {
			 	if(%index > 7) {
					Client::addMenuItem(%clientId, %index @ "More mission types..", "more " @ %index + %first -1 @ " " @ %leaguenext);
					return;
			 	}
			 	Client::addMenuItem(%clientId, %index @ $MR::Type[%type], %type @ " 0 " @ %leaguenext);
			 	%index++;
		  	}
	   	}
	}
}

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more")
   {
	  %first = getWord(%options, 1);
	  %leaguenext = getword(%options,2);
	  Admin::changeMissionMenu(%clientId, %first, %leaguenext);
	  return;
   }


// - BW Admin Mod - Allow for more mission types than standard limit - End.

   	%curItem = 0;
   	%option = getWord(%options, 0);
   	%first = getWord(%options, 1);
	%leaguenext = getword(%options,2);
   	Client::buildMenu(%clientId, "Pick Mission", "cmission", true);

	%listfull = false;
	if(%clientId.AdminReferee || %clientId.AdminServerSettings)
		%listfull = true;
   	if($bwadmin::FullPublicMapList == "true")
   		%listfull = true;
   	if($bwadmin::MRenabled == "false")
   		%listfull = true;

   if(%listfull)
   {
	   	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	   	{
		  	if(%i > 6)
		  	{
			 	Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option @ " " @ %leaguenext);
			 	break;
		  	}
		  	Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %leaguenext);
	   	}
   }
   else
   {
	   for(%i = 0; (%misIndex = getWord($MR::MLIST[%option], %first + %i)) != -1; %i++)
	   {
		  	if(%i > 6)
		  	{
			 	Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option @ " " @ %leaguenext);
			 	break;
		  	}
		 	Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %leaguenext);
	   }
   }
}

function processMenuCMission(%clientId, %option)
{

	%listfull = false;
	if(%clientId.AdminReferee || %clientId.AdminServerSettings)
		%listfull = true;
   	if($bwadmin::FullPublicMapList == "true")
   		%listfull = true;
   	if($bwadmin::MRenabled == "false")
   		%listfull = true;

   if(getWord(%option, 0) == "more")
   {
	  %first = getWord(%option, 1);
	  %type = getWord(%option, 2);
	  %leaguenext = getWord(%option, 3);
	  processMenuCMType(%clientId, %type @ " " @ %first @ " " @ %leaguenext);
	  return;
   }
   %mi = getWord(%option, 0);
   %mt = getWord(%option, 1);
   %leaguenext = getWord(%option, 2);
   if(%leaguenext == -1 || %leaguenext == "")
   	   %leaguenext = "false";
	if(%listfull)
	{
   		%misName = $MLIST::EName[%mi];
   		%misType = $MLIST::Type[%mt];

	   	// verify that this is a valid mission:
	   	if(%misType == "" || %misType == "Training")
		  	return;
	   	for(%i = 0; true; %i++)
	   	{
		  	%misIndex = getWord($MLIST::MissionList[%mt], %i);
		  	if(%misIndex == %mi)
			 	break;
		  	if(%misIndex == -1)
			 	return;
	   	}
	}
	else
	{
   		%misName = $MLIST::EName[%mi];
		%misType = $MR::Type[%mt];

	   	// verify that this is a valid mission:
	   	if(%misType == "" || %misType == "Training")
		  	return;
	   	for(%i = 0; true; %i++)
	   	{
		  	%misIndex = getWord($MR::MLIST[%mt], %i);
		  	if(%misIndex == %mi)
			 	break;
		  	if(%misIndex == -1)
			 	return;
	   	}
	}

	if(%leaguenext == "true" && (%clientId.AdminReferee || %clientId.AdminServerSettings)) // PORT: referee test
	{
		$NextLeagueMap = %misName;
		bottomprint(%clientId, "<jc><f1>BWAdmin League Setting Information:\n\n<f0>Next league map set to " @ %misName @ " (" @ %misType @ ")", 3);
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") changed the next league mission to " @ %misName @ " (" @ %misType @ ")",%clientId);
	}
	else
	{
	   if(%clientId.missionVote || !%clientId.AdminGeneral) // PORT: was the global $MissionVote, no admin test
	   {
		  Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		  Game::menuRequest(%clientId);
	   }
	   else
	   {
		  messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") changed the mission to " @ %misName @ " (" @ %misType @ ")",%clientId);
			Vote::changeMission();
		  Server::loadMission(%misName);
	   }
   }
}

//-- BWAdmin -- Enhanced User List -- Wizard_TPG
function remoteAdminPassword(%client, %password)
{
	if(%client.SADAttempt == "")
		%client.SADAttempt = 0;

	%ip = Client::getTransportAddress(%client);
	%currentName = Client::getName(%client);
	%client.SADAttempt = %client.SADAttempt + 1;

	if(%client.SADAttempt < 11)
	{
		for(%i = 1; %i < $UserList::MaxGroups+1; %i++)
		{
			if(%password != "" && $UserList::GroupPass[%i] == %password) // PORT: an empty password matched every unset group
			{
				%isgrouppass = true;
			}
		}
		if($AdminPassword != "" && %password == $AdminPassword)
		{
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			%client.AdminIsImmune = true;
			%client.AdminGeneral = true;
			%client.AdminServerSettings = true;
			%client.AdminCanAdminPlayer = true;
			%client.AdminReferee = true;
			%client.AdminVerified = true;
			Client::sendMessage(%client, 1, "BWAdmin: Superadmin logged in");
		}
		else if (%password == "deadmin")
		{
			%client.isAdmin = false;
			%client.isSuperAdmin = false;
			%client.AdminIsImmune = false;
			%client.AdminGeneral = false;
			%client.AdminServerSettings = false;
			%client.AdminCanAdminPlayer = false;
			%client.AdminReferee = false;
			%client.AdminVerified = false;
			Client::sendMessage(%client, 1, "BWAdmin: Admin Status Removed.");
		}
		else if (%password == "mystats")
		{
			BWAdmin_ListAdminRights(%client, %client);
		}
		else if (%password == "addtk" && %client.isSuperAdmin) // PORT: BWAdmin test hook, was open to all
		{
			BWAdmin_setTeamKill(%client, %client);
			Client::sendMessage(%client, 1,"BWAdmin Test Mode - TK Added");
		}
		else if (%isgrouppass)
		{
			BWAdminGroupAdmin(%password,%client);
		}
		else if (!%client.usernumber)
			Client::sendMessage(%client, 1,"BWAdmin: Your user/ip does not have admin rights.");
		else if (!%client.AdminVerified)
		{
			if(!String::ICompare(%password, $UserList::UserPass[%client.usernumber]))
			{
				BWAdminSetClientAdmin(%client);
				Client::sendMessage(%client, 1,"BWAdmin: You have logged in successfully.");
				BWAdminMsg(%currentName @ " Logged in.",%client);
			}
			else
			{
				Client::sendMessage(%client, 1,"BWAdmin: Bad Password");
				BWAdminMsg("Login attempt Failed. Username: " @ %currentName,%client);
			}
		}
		else
		{
			Client::sendMessage(%client, 1,"BWAdmin: You Already have Admin Status.");
		}
	}
	else if(%client.SADAttempt == 11)
	{
		bottomprint(%client, "<jc><f1>You have attempted to log in more than 10 times. \n\nYou now may not log in for 15 minutes", 5);
		AdminAction(%currentName @ " (" @ %client @ ") had 10 failed SAD log in attempts",%client);
		schedule(%client @".SADAttempt = 0;",900,%client);
	}
}


function BWAdmin_ListAdminRights(%QueriedClientId, %DisplayClientId)
{
	%currentName = Client::getName(%QueriedClientId);
	%clientId = %QueriedClientId;
	if(%clientId.check1) %clientId.SmurfKey = true;
	for(%i = 0; %i < 12; %i++)
	{
		if(%i==0)
		{
			%message = "Name = " @ %currentname;
			%fullmessage = %currentName @ " - Name = " @ %currentname;
		}
		else if(%i==1)
		{
			%message = "IsAdmin = " @ %QueriedClientId.isAdmin;
			%fullmessage = %currentName @ " - IsAdmin = " @ %QueriedClientId.isAdmin;
		}
		else if(%i==2)
		{
			%message = "IsSuperAdmin = " @ %QueriedClientId.isSuperAdmin;
			%fullmessage = %currentName @ " - IsSuperAdmin = " @ %QueriedClientId.isSuperAdmin;
		}
		else if(%i==3)
		{
			%message = "ServerSettings = " @ %QueriedClientId.AdminServerSettings;
			%fullmessage = %currentName @ " - ServerSettings = " @ %QueriedClientId.AdminServerSettings;
		}
		else if(%i==4)
		{
			%message = "IsImmune = " @ %QueriedClientId.AdminIsImmune;
			%fullmessage = %currentName @ " - IsImmune = " @ %QueriedClientId.AdminIsImmune;
		}
		else if(%i==5)
		{
			%message = "AdminGeneral = " @ %QueriedClientId.AdminGeneral;
			%fullmessage = %currentName @ " - AdminGeneral = " @ %QueriedClientId.AdminGeneral;
		}
		else if(%i==6)
		{
			%message = "AdminCanAdminPlayer = " @ %QueriedClientId.AdminCanAdminPlayer;
			%fullmessage = %currentName @ " - AdminCanAdminPlayer = " @ %QueriedClientId.AdminCanAdminPlayer;
		}
		else if(%i==7)
		{
			%message = "AdminReferee = " @ %QueriedClientId.AdminReferee;
			%fullmessage = %currentName @ " - AdminReferee = " @ %QueriedClientId.AdminReferee;
		}
		else if(%i==8)
		{
			%message = "AdminVerified = " @ %QueriedClientId.AdminVerified;
			%fullmessage = %currentName @ " - AdminVerified = " @ %QueriedClientId.AdminVerified;
		}
		else if(%i==9)
		{
			%message = "Admin Level = " @ %QueriedClientId.UserLevel;
			%fullmessage = %currentName @ " - Admin Level = " @ %QueriedClientId.UserLevel;
		}
		else if(%i==10)
		{
			%message = "Current IP = " @ %QueriedClientId.ip;
			%fullmessage = %currentName @ " - Current IP = " @ %QueriedClientId.ip;
		}
		else if(%i==11)
		{
			%message = "Authorized Ip's = " @ %QueriedClientId.UserIP1 @ ", " @ %QueriedClientId.UserIP2 @ ", " @ %QueriedClientId.UserIP3;
			%fullmessage = %currentName @ " - Authorized Ip's = " @ %QueriedClientId.UserIP1 @ ", " @ %QueriedClientId.UserIP2 @ ", " @ %QueriedClientId.UserIP3;
		}

		Client::sendMessage(%DisplayClientId, 2, %message);
		if(!%clientId.HiddenSmurf)
			echo("BWAdmin: ",%fullmessage);
	}
}


function remoteSetPassword(%client, %password)
{
   	if((%client.AdminServerSettings) || (%client.isSuperAdmin))
   	{
   		$Server::Password = %password;
   		if(%password != "")
   		{
   			Client::sendMessage(%client, 1, "BWAdmin: Server Password " @ %password @ " set.");
			AdminAction(Client::getName(%client) @ " (" @ %client @ ") set the server password as " @ %password,%client);
		}
   		else
   		{
   			Client::sendMessage(%client, 1, "BWAdmin: Server Password Disabled.");
   			AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the server password",%client);
		}
	}
	else
		Client::sendMessage(%client, 1, "BWAdmin: You do not have access to password this server.");
}
//-- BWAdmin -- Enhanced User List -- Wizard_TPG -- END


// - BW Admin Mod -

function remoteSetScoreLimit(%client, %score)
{
   if(%score == "" && %client.AdminGeneral)
   {
	  if($bwadmin::teamScoreLimit == "")
		 return;
	  $bwadmin::teamScoreLimit = "";
	  messageAll(0, Client::getName(%client) @ " disabled automatic score setting.");
	  AdminAction(Client::getName(%client) @ " (" @ %client @ ") set score limit to map default",%client);
	  return;
   }
   if(%score == "false" && %client.AdminGeneral)
   {
	  if($teamScoreLimit == "false")
		return;
	  messageAll(0, Client::getName(%client) @ " disabled the score limit.");
	  AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the score limit",%client);
	  $teamScoreLimit = %score;
	  return;
   }
   %score = floor(%score);
   if(%score == $teamScoreLimit || %score < 1)
	  return;
   if(!%client.isAdmin) return; // PORT: the message below was sent for anybody
   if(%client.isAdmin)
	  $teamScoreLimit = %score;
   if(%score)
	  messageAll(0, Client::getName(%client) @ " changed the score limit to " @ %score @ " points.");
	  AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the score limit to " @ %score @ " points.",%client);
}

function remoteSetTeamEnergy(%client, %opt)
{
   if($bwadmin::DefaultTeamEnergy != %opt && %client.AdminServerSettings)
   {
	 $bwadmin::DefaultTeamEnergy = %opt;
	 bottomprint(%client, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Team Energy set to " @ $bwadmin::DefaultTeamEnergy @ " on mission change.", 5);
	 AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed team energy to " @ $bwadmin::DefaultTeamEnergy,%client);
   }
}

// - BW Admin Mod - End

function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
	  return;
   if(%client.AdminGeneral)
   {
	  $Server::timeLimit = %time;
	  if(%time)
	  {
		 messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
		 AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the time limit to " @ %time @ " minute(s).",%client);
	  }
	  else
	  {
		 messageAll(0, Client::getName(%client) @ " disabled the time limit.");
		 AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the time limit.",%client);
	  }

   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   	if(%team >= 0 && %team < 8 && ((%client.AdminServerSettings) || (%client.isSuperAdmin) || (%client.AdminReferee)))
   	{
	  	$Server::teamName[%team] = %teamName;
	  	$Server::teamSkin[%team] = %skinBase;
	  	messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: "
		 @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
		 AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the " @ %team @ " team to " @ %teamName @ " with skin " @ %skinBase,%client);
	}
	else
	{
		Client::sendMessage(%clientId, 1, "Access to ADSetTeamInfo DENIED");
	}
}

function remoteVoteYes(%clientId)
{
   %clientId.vote = "yes";
   centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   %clientId.vote = "no";
   centerprint(%clientId, "", 0);
}

function Admin::startMatch(%admin)
{
   if(%admin == -1 || %admin.AdminReferee)
   {
	  if(!$CountdownStarted && !$matchStarted)
	  {
		// - BW Admin Mod - checking and reporting match settings
		if(%admin == -1)
		   messageAll(0, "Match start countdown forced by vote.");
		else
			AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") forced the match to start",%admin);

		Game::ForceTourneyMatchStart();
		if($bwadmin::controlledTourneyMode)
		{
			if(%admin != -1)
				messageAll(0, $bwadmin::league @ " Match started by " @ Client::getName(%admin));
			messageAll(0, "~wflagflap.wav");
			schedule("messageAll(0, \"~wshell_click.wav\");", 27);
			schedule("messageAll(0, \"~wshell_click.wav\");", 28);
			schedule("messageAll(0, \"~wshell_click.wav\");", 29);
			schedule("messageAll(0, \"~wforceopen.wav\");", 30);
			if($bwadmin::teamScoreLimit != "")
			   $teamScoreLimit = $bwadmin::teamScoreLimit;
			if($bwadmin::teamDamageScale != "")
			   $Server::TeamDamageScale = $bwadmin::teamDamageScale;
			if($bwadmin::matchTimeLimit != "")
			$Server::timeLimit = $bwadmin::matchTimeLimit;
			if(%admin != -1)
			{
				%sl = $teamScoreLimit;
				if(%sl == "false")
				   %sl = "OFF";
				if($Server::TeamDamageScale)
					   %td = "ON";
					else
					   %td = "OFF";
					if($bwadmin::walk)
					   %walk = "ON";
					else
					   %walk = "OFF";
					if($bwadmin::noRape)
					   %warn="\n<f0>Warnings: <f1>No Base Rape is ON!";
					else
					   %warn="None";
				bottomprint(%admin, "<jc><f1>BWAdmin Match Setting Information:\n\n<f0>Team Damage: <f1>" @ %td @ ".\n<f0>Score Limit: <f1>" @ %sl @ ".\n<f0>Match Length: <f1>" @ $Server::timeLimit @ " Minutes.\n<f0>Long Walk Home: <f1>" @ %walk @ ".\n<f0>Team Energy: <f1>" @ $DefaultTeamEnergy @ "." @ %warn, 8);
			}
		else
		   messageAll(0, "Match started by " @ Client::getName(%admin));
		}
		// - BW Admin Mod - End
	  }
   }
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.AdminGeneral)
   {
	  if(%enabled)
	  {
		 $Server::TeamDamageScale = 1;
		 if(%admin == -1)
			messageAll(0, "Team damage set to ENABLED by consensus.");
		 else
		 {
			messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
			AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") enabled team damage",%admin);
		 }
	  }
	  else
	  {
		 $Server::TeamDamageScale = 0;
		 if(%admin == -1)
			messageAll(0, "Team damage set to DISABLED by consensus.");
		 else
		 {
			messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
			AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") disabled team damage",%admin);
		 }
	  }
   }
}

function Admin::setReverseDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.AdminGeneral)
   {
	  if(%enabled)
	  {
		 $bwadmin::GlobalReverseDamageMode = "true";
		 $Server::TeamDamageScale = 1;
		 if(%admin == -1)
			messageAll(0, "Reverse damage set to ENABLED by consensus.");
		 else
		 {
			messageAll(0, Client::getName(%admin) @ " ENABLED reverse damage.");
			AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") enabled reverse damage",%admin);
		 }
	  }
	  else
	  {
		 $bwadmin::GlobalReverseDamageMode = "false";
		 if(%admin == -1)
			messageAll(0, "Reverse damage set to DISABLED by consensus.");
		 else
		 {
			messageAll(0, Client::getName(%admin) @ " DISABLED reverse damage.");
			AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") disabled reverse damage",%admin);
		 }
	  }
   }
}

function Admin::kick(%admin, %client, %ban)
{
	%name = Client::getname(%client);

   	//ban client even if they dropped mid vote.
   	if (%name == "")
   	{
	   	if(%ban)
	   		BanList::add($CurrentVoteObjectIP, $bwadmin::FullBanTime);
	   	else
		 	BanList::add($CurrentVoteObjectIP, $bwadmin::KickBanTime);
		$CurrentVoteObjectIP = "";
	}


   if(%admin != %client && (%admin == -1 || %admin == -2 || %admin == -3 || %admin.AdminGeneral))
   {

	  if(%ban && !%admin.AdminIsImmune)
		 return;

	  if(%ban)
	  {
		 %word = "banned";
		 %cmd = "BAN: ";
	  }
	  else
	  {
		 %word = "kicked";
		 %cmd = "KICK: ";
	  }
	  if(%client.AdminIsImmune)
	  {
		 if(%admin == -1)
			messageAll(0, "An immune admin cannot be " @ %word @ ".");
		 else
			Client::sendMessage(%admin, 0, "An immune admin cannot be " @ %word @ ".");
		 return;
	  }
	  %ip = Client::getTransportAddress(%client);

	  echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

	  if(%ip == "")
		 return;

	  if(%ban)
		 BanList::add(%ip, $bwadmin::FullBanTime);
	  else
		 BanList::add(%ip, $bwadmin::KickBanTime);

	  if(%admin == -1)
	  {
		 MessageAll(0, %name @ " was " @ %word @ " from vote.");
		 Net::kick(%client, "You were " @ %word @ " by  consensus.");
	  }
	  if(%admin == -2)
	  {
		 MessageAll(0, %name @ " was " @ %word @ " by server for TeamKilling.");
		 Net::kick(%client, "You were " @ %word @ " by server for TeamKilling.");
	  }
	  if(%admin == -3)
	  {
		 MessageAll(0, %name @ " was " @ %word @ " by server for having a consistant ping below " @ $bwadmin::PingAbove);
		 Net::kick(%client, "You were " @ %word @ " by server for having a consistant ping below " @ $bwadmin::PingAbove);
	  }
	  else
	  {
		 AdminAction(%name @ " (" @ %client @ ") was " @ %word @ " by " @ Client::getName(%admin) @ " (" @ %admin @ ")",%admin,%client);
		 MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
		 Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
	  }
   }
}

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.AdminReferee))
   {

	  if(%clientId == -1)
		 messageAll(0, "Server switched to Free-For-All Mode.");
	  else
	  {
		 messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
		 AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to FFA mode",%clientId);
	  }

	  $bwadmin::controlledTourneyMode = false;
	  $Server::TourneyMode = false;
	  centerprintall(); // clear the messages
	  if(!$matchStarted && !$countdownStarted)
	  {
		 if($Server::warmupTime)
			Server::Countdown($Server::warmupTime);
		 else
			Game::startMatch();
	  }
   }
}

function Admin::setModeTourney(%clientId)
{
   if((!$Server::TourneyMode || $bwadmin::controlledTourneyMode) && (%clientId == -1 || %clientId.AdminReferee))
   {
	  	//Reset Client Skins to server skins.
   		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   		{
			%cl.customSkin = false;
	   	}

	  	$Server::TeamDamageScale = 1;
	  	if(%clientId == -1)
		// - BW Admin Mod - to make it clear mod is running
		 	messageAll(0, "Server switched to Tournament Mode.");
	  	else
	  	{
		 	messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
		 	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to Tournament Mode",%clientId);
	  	}

	  	$bwadmin::controlledTourneyMode = false;
	  	$Server::TourneyMode = true;
	  	Server::nextMission();
   	}
}

function Admin::setModeLeagueNoRef(%clientId)
{
   if(%clientId != -1 && !%clientId.AdminReferee && !%clientId.AdminServerSettings) return; // PORT: -1 = by vote
   if(!$bwadmin::controlledTourneyMode && !$bwadmin::ReflessTourneyMode)
   {
	  	//Reset Client Skins to server skins.
   		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   		{
			%cl.customSkin = false;
	   	}

	  	$Server::TeamDamageScale = 1;
	  	%clientId.customSkin = false;
	  	if(%clientId == -1)
		 	messageAll(0, "Server switched to League Mode (No Admin).");
	  	else
	  	{
		 	messageAll(0, "Server switched to League Mode (No Admin) by " @ Client::getName(%clientId) @ ".");
		 	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to League Mode (No Admin)",%clientId);
	  	}
	  	$bwadmin::controlledTourneyMode = true;
	  	$bwadmin::ReflessTourneyMode = true;
	  	$Server::TourneyMode = true;
	  	Server::nextMission();
   	}
}

function Admin::setModeLeague(%clientId)
{
   if(!$bwadmin::controlledTourneyMode && %clientId.AdminReferee)
   {
	  	//Reset Client Skins to server skins.
   		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   		{
			%cl.customSkin = false;
	   	}

	  	$Server::TeamDamageScale = 1;
	  	%clientId.customSkin = false;
	  	if(%clientId == -1)
		 	messageAll(0, "Server switched to League Mode.");
	  	else
	  	{
		 	messageAll(0, "Server switched to League Mode by " @ Client::getName(%clientId) @ ".");
		 	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to League Mode",%clientId);
	  	}

	  	$bwadmin::controlledTourneyMode = true;
	  	$Server::TourneyMode = true;
	  	Server::nextMission();
   	}
}

function Admin::voteFailed()
{
   $curVoteInitiator.numVotesFailed++;

   if($curVoteAction == "kick" || $curVoteAction == "admin")
	  $curVoteOption.voteTarget = "";
   $CurrentVoteObjectIP = "";
}

function Admin::voteSucceded()
{
	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
	  	if($curVoteOption.voteTarget)
		 	Admin::kick(-1, $curVoteOption);
	}
	else if($curVoteAction == "purg")
	{
		if($curVoteOption.voteTarget)
		{
			%ip = Client::getTransportAddress($curVoteOption);
			Admin::PurgMode($curVoteOption,true,%ip,%clientId);
		}
	}
	else if($curVoteAction == "unpurg")
	{
		if($curVoteOption.voteTarget)
		{
			%ip = Client::getTransportAddress($curVoteOption);
			Admin::PurgMode($curVoteOption,false,%ip,%clientId);
		}
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			$curVoteOption.AdminGeneral = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
			if($curVoteOption.menuMode == "options")
				Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
	  	messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
	  	Server::loadMission($curVoteOption);
   	}
   	else if($curVoteAction == "skipmission")
   	{
	  	messageAll(0, "Changing to next mission.");
	  	Server::nextMission();
   	}
   	else if($curVoteAction == "tourney")
	  	Admin::setModeTourney(-1);
   	else if($curVoteAction == "lna")
	  	Admin::setModeLeagueNoRef(-1);
   	else if($curVoteAction == "ffa")
	  	Admin::setModeFFA(-1);
   	else if($curVoteAction == "etd")
	  	Admin::setTeamDamageEnable(-1, true);
   	else if($curVoteAction == "dtd")
	  	Admin::setTeamDamageEnable(-1, false);
   	else if($curVoteAction == "norape")
   	{
	  	$bwadmin::noRape = true;
	  	messageAll(0, "'No Base Rape' Mode ENABLED.");
	}
   	else if($curVoteAction == "rape")
   	{
	  	$bwadmin::noRape = false;
	  	messageAll(0, "'No Base Rape' Mode DISABLED.");
	}
   	else if($curVoteAction == "nowalk")
   	{
	  	$bwadmin::walk = false;
	  	messageAll(0, "'Long Walk Home' DISABLED.");
	}
   	else if($curVoteAction == "walk")
   	{
	  	$bwadmin::walk = true;
	  	messageAll(0, "'Long Walk Home' ENABLED.");
	}
   	else if($curVoteAction == "smatch")
   	{
	  	Admin::startMatch(-1);
	}
   	else if($curVoteOption == "smatch")
   	{
	  	Admin::startMatch(-1);
	}
   	else if($curVoteAction == "rdmode")
   	{
	  	$bwadmin::GlobalReverseDamageMode = "true";
	}
   	else if($curVoteAction == "nordmode")
   	{
	  	$bwadmin::GlobalReverseDamageMode = "false";
	}

}


function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
	  return;

   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	  %totalClients++;
	  if(%cl.vote == "yes")
	  {
		 %votesFor++;
		 %totalVotes++;
	  }
	  else if(%cl.vote == "no")
	  {
		 %votesAgainst++;
		 %totalVotes++;
	  }
	  else
		 %votesAbstain++;
   }
   %minVotes = floor($Server::MinVotesPct * %totalClients);
   if(%minVotes < $Server::MinVotes)
	  %minVotes = $Server::MinVotes;

   if(%totalVotes < %minVotes)
   {
	  %votesAgainst += %minVotes - %totalVotes;
	  %totalVotes = %minVotes;
   }
   %margin = $Server::VoteWinMargin;
   if($curVoteAction == "admin")
   {
	  %margin = $Server::VoteAdminWinMargin;
	  %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
	  if(%totalVotes < %minVotes)
		 %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= %margin)
   {
	  messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
	  Admin::voteSucceded();
   }
   else  // special team kick option:
   {
	  if($curVoteAction == "kick") // check if the team did a majority number on him:
	  {
		 %votesFor = 0;
		 %totalVotes = 0;
		 for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		 {
			if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
			{
			   %totalVotes++;
			   if(%cl.vote == "yes")
				  %votesFor++;
			}
		 }
		 if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
		 {
			messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
			Admin::voteSucceded();
			$curVoteTopic = "";
			return;
		 }

// - BW Admin Mod - anti-TK code

		 else if($bwadmin::intelliKick != "" && ($curVoteOption.tk > $bwadmin::intelliKick))
		 {
			%votesFor = 0;
			%totalVotes = 0;
			%votesAbstain = 0;

			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
			   if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
			   {
				  if(%cl.vote == "")
					 %votesAbstain++;
				  if(%cl.vote == "yes")
					 %votesFor++;
				  %totalVotes++;
			   }
			}

			%penalty = $curVoteOption.tk + $curVoteOption.bk - $bwadmin::intelliKick;
			if(%penalty > 0)
			{
			   for(%i=0; %i < %votesAbstain; %i = %i + 1)
			   {
				  if(%penalty != 0)
				  {
					 %votesFor++;
					 %penalty--;
				  }
			   }
			}
			if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
			{
			   messageAll(0, "BWAdmin IntelliKick. Vote to " @ $curVoteTopic @ " passed!");
			   Admin::voteSucceded();
			   $curVoteTopic = "";
			   return;
			}
		 }

// - BW Admin Mod - End

	  }
	  messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
	  Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
   // PORT: the menus only LIST the votes a server allows ($bwadmin::voteDisable[]); the handlers
   // started any vote a client asked for. One test here covers every vote a non-admin starts.
   %vkey = %action;
   if(%action == "unpurg") %vkey = "purg";
   else if(%action == "lna") %vkey = "lnam";
   else if(%action == "rdmode") %vkey = "rd";
   else if(%action == "nordmode") %vkey = "nord";
   if(!%clientId.AdminGeneral && $bwadmin::voteDisable[%vkey] == "true")
   {
      Client::sendMessage(%clientId, 0, "That vote is disabled on this server.");
      return;
   }
   if(%clientId.lastVoteTime == "")
	  %clientId.lastVoteTime = -$Server::MinVoteTime;

   // we want an absolute time here.
   %time = getIntegerTime(true) >> 5;
   %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

   if(%diff > 0)
   {
	  Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
	  return;
   }
   if($curVoteTopic == "")
   {
	  	if(%clientId.numFailedVotes)
		 	%time += %clientId.numFailedVotes * $Server::VoteFailTime;
		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;

		if(%option != -1 && %option != 0)
			$CurrentVoteObjectIP = Client::getTransportAddress(%option);
		else
			$CurrentVoteObjectIP = "";

		if(%action == "kick")
		{
	  		if(%action == "kick")
		 		$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
	  		$curVoteCount++;
	  		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
	  		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	  	   		%cl.vote = "";
	  		%clientId.vote = "yes";
	  		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		 		if(%cl.menuMode == "options")
					Game::menuRequest(%clientId);
	  		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
		}
		else if(%action == "purg")
		{
	  		$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
	  		$curVoteCount++;
	  		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
	  		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	  	   		%cl.vote = "";
	  		%clientId.vote = "yes";
	  		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		 		if(%cl.menuMode == "options")
					Game::menuRequest(%clientId);
	  		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
		}
   		else
   		{
   		  	$curVoteCount++;
   		  	%name=Client::getName(%clientId);
	  		if(%name=="")
	  		   %name="The server";
   		  	bottomprintall("<jc><f1>" @ %name @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
   			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		 	   	%cl.vote = "";
   			%clientId.vote = "yes";
   			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   			if(%cl.menuMode == "options")
   				Game::menuRequest(%clientId);
   			schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
		}
   }
   else
   {
	  Client::sendMessage(%clientId, 0, "Voting already in progress.");
   }
}


function Game::menuRequest(%clientId)
{
   	%curItem = 0;
   	BWAdmin_CheckPenaltyStatus(%clientId);
	//Set player properties if admin given through remote utility like tricon
	if(%clientId.AdminGeneral) {
		%clientId.isAdmin = true;
		%clientId.AdminVerified = true;
	}
	if(%clientId.isSuperAdmin) {
		%clientId.isAdmin = true;
		%clientId.AdminIsImmune = true;
		%clientId.AdminGeneral = true;
		%clientId.AdminServerSettings = true;
		%clientId.AdminCanAdminPlayer = true;
		%clientId.AdminReferee = true;
		%clientId.AdminVerified = true;
	}
	if(%clientId.isAdmin && !%clientId.AdminVerified) {
		if($Userlist::PublicAdminLevel == "")
			$Userlist::PublicAdminLevel = "PublicAdmin";
		%clientId.UserLevel = $Userlist::PublicAdminLevel;
		BWAdminSetClientAdmin(%clientId);
	}

	//Menus
	if(%clientId.purgatory) {
		//-----Purgatory Tab Menu--------
		Client::buildMenu(%clientId, "Purgatory Options", "purgmenu", true);
		Client::addMenuItem(%clientId, %curItem++ @ "You are in Purgatory Mode.", "nopurg1");
		%purgtimeleft = floor(%clientId.purgtime - GetSimTime());
		Client::addMenuItem(%clientId, %curItem++ @ %purgtimeleft @ " seconds remaining.", "nopurg2");
		Client::addMenuItem(%clientId, %curItem++ @ "If you drop you will be", "nopurg2");
		Client::addMenuItem(%clientId, %curItem++ @ "banned for your remaining", "nopurg2");
		Client::addMenuItem(%clientId, %curItem++ @ "penalty time.", "nopurg2");
		if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Camera Options", "bcopurg");
		return;
	}
	
	Client::buildMenu(%clientId, "Options", "options", true);
	%team = Client::getTeam(%clientId);

	%canChangeTeams = 0;
	%canChangeSkin = 1;

	if ((%clientId.AdminGeneral && %clientId.AdminReferee) || %clientId.AdminServerSettings) {
		%canChangeTeams = 1;
	} else if ($Server::TourneyMode && $bwadmin::controlledTourneyMode) {
		if ($matchStarted || $CountdownStarted) {
			if ($bwadmin::ReflessTourneyMode || %team < 0)
				%canChangeTeams = 1;
		}
		%canChangeSkin = 0;
	} else {
		%canChangeTeams = 1;
	}

	if ($matchStarted) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change weapon mode", "crwmode");
		if ($Combat::AllowRespawnGear) 
			Client::addMenuItem(%clientId, %curItem++ @ "Change respawn gear", "crgear");
	}

	if (%canChangeTeams) {
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	}
	
	//Tab menu player highlight menu
	if(%clientId.selClient) {
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

  		if($curVoteTopic == "") {
			if($Server::TourneyMode && $bwadmin::controlledTourneyMode && !$bwadmin::ReflessTourneyMode) {
				//league mode
				if((%clientId.AdminGeneral && %clientId.AdminReferee) || (%clientId.AdminServerSettings)) {
					Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
					Client::addMenuItem(%clientId, %curItem++ @ "Admin Control " @ %name, "bwaa " @ %sel);
					if(($bwadmin::KeepSmurfLog == "true") && (!%sel.AdminIsImmune) && ((%clientId.AdminServerSettings) || (($bwadmin::AdminSmurfApp == "true") && (%clientId.AdminReferee))))
						Client::addMenuItem(%clientId, %curItem++ @ "Show Possible Aliases", "bwspa " @ %sel);
				}
			} else {
				//FFA & tourney && No Admin League modes
				if(%clientId.AdminGeneral) {
					if(((!$bwadmin::AdminDisable[cteam]) || (%clientId.AdminServerSettings)) && %sel.justConnected == "")
						Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
					if((!%sel.AdminIsImmune) || (%clientId.AdminServerSettings))
						Client::addMenuItem(%clientId, %curItem++ @ "Admin Control " @ %name, "bwaa " @ %sel);
					if(($bwadmin::KeepSmurfLog == "true") && (!%sel.AdminIsImmune) && ((%clientId.AdminServerSettings) || (($bwadmin::AdminSmurfApp == "true") && (%clientId.AdminReferee))))
						Client::addMenuItem(%clientId, %curItem++ @ "Show Possible Aliases", "bwspa " @ %sel);
				} else {
					if(($bwadmin::voteDisable[admin] != "true") && (!%sel.AdminGeneral))
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
					if($bwadmin::voteDisable[purg] != "true")
						if(%sel.purgatory)
							Client::addMenuItem(%clientId, %curItem++ @ "Vote to depurgatise " @ %name, "vunpurg " @ %sel);
						else
							Client::addMenuItem(%clientId, %curItem++ @ "Vote to purgatise " @ %name, "vpurg " @ %sel);
					if($bwadmin::voteDisable[kick] != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
				}
			}
		}

		if(%clientId.muted[%sel])		Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
		else							Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);

		return;
	}

	//vote menu
	if($curVoteTopic != "" && %clientId.vote == "") {
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
	  	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
		return;
	}

	//General Tab Menu
	//League Mode
	if($Server::TourneyMode && $bwadmin::controlledTourneyMode && !$bwadmin::ReflessTourneyMode) {
		if((%clientId.AdminGeneral && %clientId.AdminReferee) || (%clientId.AdminServerSettings)) {
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			Client::addMenuItem(%clientId, %curItem++ @ "Change server mode", "cmode");
			if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Start the League Match", "smatch");
			if(%clientId.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Server Settings", "bwaf");
		}
		else {
			if(!$matchStarted && !$CountdownStarted) {
				if($bwadmin::voteDisable[ffa] != "true")
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
			}

		}
	}

	//League (No Admin) Mode
	else if($Server::TourneyMode && $bwadmin::controlledTourneyMode && $bwadmin::ReflessTourneyMode) {
		if(%clientId.AdminGeneral) {
			if($bwadmin::AdminDisable[cmission] != "true" || %clientId.AdminReferee || %clientId.AdminServerSettings)
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			Client::addMenuItem(%clientId, %curItem++ @ "Change server mode", "cmode");
			if($Server::TourneyMode && (!$CountdownStarted && !$matchStarted)) {
				if(%clientId.AdminReferee || %clientId.AdminServerSettings)
					Client::addMenuItem(%clientId, %curItem++ @ "Start the league match", "smatch");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the league match", "vsmatch");
			}
			if(%clientId.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Server Settings", "bwaf");
		} else {
			if($bwadmin::voteDisable[cmission] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			%checkGamePlay = false;
			if(($Server::TeamDamageScale == 1.0) && ($bwadmin::voteDisable[dtd] != "true"))
				%checkGamePlay = true;
			else if(($Server::TeamDamageScale != 1.0) && ($bwadmin::voteDisable[etd] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::noRape == "true") && ($bwadmin::voteDisable[norape] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::noRape != "true") && ($bwadmin::voteDisable[rape] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::walk == "true") && ($bwadmin::voteDisable[nowalk] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::walk != "true") && ($bwadmin::voteDisable[walk] != "true"))
				%checkGamePlay = true;
			if(%checkGamePlay == "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			if($bwadmin::voteDisable[ffa] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Vote for FFA mode", "vcffa");
			if($bwadmin::voteDisable[tourney] != "true" && $bwadmin::DisableTourneyMode != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Vote for Tournament mode", "vctourney");
			if(!$CountdownStarted && !$matchStarted)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");

			if ($bwadmin::allowCustomSkinsLeague != "true") {
				%canChangeSkin = 0;
			}
		}
	}

	//Tourney & FFA Mode
	else {
		if(%clientId.AdminGeneral) {
			if($bwadmin::AdminDisable[cmission] != "true" || %clientId.AdminReferee || %clientId.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");

			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");

			if($Server::TourneyMode) {
				if(%clientId.AdminReferee || %clientId.AdminServerSettings)
					Client::addMenuItem(%clientId, %curItem++ @ "Change server mode", "cmode");
				else {
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for FFA mode", "vcffa");
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for League(NoAdmin) mode", "vclna");
				}

				if(!$CountdownStarted && !$matchStarted) {
					if(%clientId.AdminReferee || %clientId.AdminServerSettings)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
			} else {
				if(%clientId.AdminReferee || %clientId.AdminServerSettings)
					Client::addMenuItem(%clientId, %curItem++ @ "Change server mode", "cmode");
				else {
					if($bwadmin::DisableTourneyMode != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote for Tournament mode", "vctourney");
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for League(NoAdmin) mode", "vclna");
				}
			}
			if(%clientId.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Server Settings", "bwaf");
		} else {
			if($bwadmin::voteDisable[cmission] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			%checkGamePlay = false;
			if(($Server::TeamDamageScale == 1.0) && ($bwadmin::voteDisable[dtd] != "true"))
				%checkGamePlay = true;
			else if(($Server::TeamDamageScale != 1.0) && ($bwadmin::voteDisable[etd] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::noRape == "true") && ($bwadmin::voteDisable[norape] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::noRape != "true") && ($bwadmin::voteDisable[rape] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::walk == "true") && ($bwadmin::voteDisable[nowalk] != "true"))
				%checkGamePlay = true;
			else if(($bwadmin::walk != "true") && ($bwadmin::voteDisable[walk] != "true"))
				%checkGamePlay = true;
			if(%checkGamePlay == "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			if($Server::TourneyMode) {
				if($bwadmin::voteDisable[ffa] != "true")
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for FFA mode", "vcffa");
				if($bwadmin::voteDisable[lnam] != "true")
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for League(NoAdmin) mode", "vclna");
				if(!$CountdownStarted && !$matchStarted && !$bwadmin::controlledTourneyMode)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
			else {
				if($bwadmin::voteDisable[tourney] != "true" && $bwadmin::DisableTourneyMode != "true")
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for Tournament mode", "vctourney");
				if($bwadmin::voteDisable[lnam] != "true")
					Client::addMenuItem(%clientId, %curItem++ @ "Vote for League(NoAdmin) mode", "vclna");
			}
		}
	}

	if (%canChangeSkin) {
		if(%clientId.customSkin)	Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskinoff");
		else						Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskinon");
	}

	if (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
		Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Camera Options", "bco");

}


function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
	  %clientId.selClient = %selId;
	  if(%clientId.menuMode == "options")
		 Game::menuRequest(%clientId);
	  remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
	  remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
	  remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
	  remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
	  remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
// - BW Admin Mod - to show IP
	  if(%clientId.AdminServerSettings)
		 remoteEval(%clientId, "setInfoLine", 6, Client::getTransportAddress(%selId));
	  else
// - BW Admin Mod - End
	  remoteEval(%clientId, "setInfoLine", 6, "Other: "); // PORT: field 5 is the 1.50 client's RPG password box
   }
   else if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit" || %clientId.observerMode == "observerOrbit")
   {
	  %clientId.observerMode = "observerOrbit";
	  Observer::setTargetClient(%clientId, %selId);
	  Client::setMenuScoreVis(%clientId, false);
	  %clientId.menuMode = "";
	  %clientId.selClient = "";

   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin || %clientId.isPolice)
	  processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuFPPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin || %clientId.isPolice)
	  processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %cl = %clientId.ptc;
   if(%clientId.isAdmin || %clientId.isPolice) %cl.purgatory = false; // PORT: was outside the admin test
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
	  return;

   if(%clientId.observerMode == "justJoined")
   {
	  %clientId.observerMode = "";
	  centerprint(%clientId, "");
   }
// - BW Admin Mod - To allow admins into spec mode
// if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   if(%team == -2)
   {
	  if(Observer::enterObserverMode(%clientId))
	  {
		 %clientId.notready = "";
		 if(%adminClient == "")
			messageAll(0, Client::getName(%clientId) @ " became an observer.");
		 else
		 {
			messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			AdminAction(Client::getName(%adminClient) @ " (" @ %adminClient @ ") forced " @ Client::getName(%clientId) @ " (" @ %clientId @ ") into observer",%adminClient,%clientId);
		 }
			Game::resetScores(%clientId);
		   Game::refreshClientScore(%clientId);
	  }
	  bwadmin::checkRape();
	  return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
	  messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
   {
	  messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
	  AdminAction(Client::getName(%adminClient) @ " (" @ %adminClient @ ") team changed " @ Client::getName(%clientId) @ " (" @ %clientId @ ")",%adminClient,%clientId);
   }

// - BW Admin Mod - Advanced console logging for stats tracking programs
   if($dedicated && $matchStarted && $bwadmin::controlledTourneyMode && $Server::TourneyMode && $bwadmin::messageLog)
	  {
		 %time = floor(getSimTime() - $missionStartTime);
		 %name = Client::getName(%clientId);
		 %teamName = getTeamName(%team);
		 echo("BWADMINMSG (" @ %time @ "): " @ %name @ " joined " @ %teamName);
	  }
// - BW Admin Mod - End

   if(%team == -1)
   {
	  Game::assignClientTeam(%clientId);
	  %team = Client::getTeam(%clientId);
   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);
	Client::setControlObject(%clientId, -1);

   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted && !$bwadmin::controlledTourneyMode)
   {
	  bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
	  %clientId.notready = true;
   }
   bwadmin::checkRape();
}


function processMenupurgmenu(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if (%opt == "bcopurg")
   {
	  	%curItem = 0;
	  	if(%clientId.zoom == "")
			%clientId.zoom = 5;
	 	Client::buildMenu(%clientId, "Pick a Camera Range: ", "POMode", true);
	 	if(%clientId.observerTarget != "")
	 	{
	 		if(%clientId.zoom != "5" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Inner Orbit", "specmode 5");
   			if(%clientId.zoom != "10" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Outer Orbit", "specmode 10");
	 		if(%clientId.zoom != "20" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Extreme Orbit", "specmode 20");
	 		if(%clientId.zoom != "-1" && %clientId.observerMode == "observerOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Eyes", "specmode -1");
	 		if(%clientId.zoom != "-3" && %clientId.observerMode == "observerOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Chase", "specmode -3");
	 		if(%clientId.observerMode == "observerObjectiveOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Observe Players", "specmode player");
			Client::addMenuItem(%clientId, %curItem++ @ "Free Flight", "specmode fly");
	 	}
	 	else
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Players", "specmode player");
	 	%obj = getNextObject(nameToID("MissionCleanup/ObjectivesSet"), 0);
	 	if(%obj && %clientId.observerMode != "observerObjectiveOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Objectives", "specmode objective");
		Client::addMenuItem(%clientId, %curItem++ @ "ReDisplay Target's Name", "objname");
	 	return;
   	}
   	else if (%opt == "nopurg1")
   	{

	}
	else if (%opt == "nopurg2")
	{

	}
	Game::menuRequest(%clientId);
}


function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange")
   {
		if(!%cl.purgatory)
		{
	  		%clientId.ptc = %cl;
	  		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
	  		Client::addMenuItem(%clientId, "0Observer", -2);
	  		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		 		Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
	  		return;
		}
		else
		{
	  		%clientId.ptc = %cl;
	  		Client::buildMenu(%clientId, "Client is purgatised. Free and change team?:", "FPPickTeam", true);
	  		Client::addMenuItem(%clientId, "0Observer", -2);
	  		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		 		Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
	  		return;
		}
   }
   else if(%opt == "changeteams")
   {
	Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
	Client::addMenuItem(%clientId, "0Observer", -2);
	if($Server::TourneyMode && !$bwadmin::controlledTourneyMode)
	{
	 if(!$matchStarted)
	  	 {
		  Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
		  Client::addMenuItem(%clientId, "0Observer", -2);
		  Client::addMenuItem(%clientId, "1Automatic", -1);
		  for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		   Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		  return;
	  	 }
	  	 else
	  	  return;
	}
	if($Server::TourneyMode)
	{
		 for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
		 return;
	}
	else if($bwadmin::noLlamaSwap)
	{

	   %numTeams = getNumTeams();
	   %numPlayers = getNumClients();
	   for(%i = 0; %i < %numTeams; %i = %i + 1)
		  %numTeamPlayers[%i] = 0;

	   for(%i = 0; %i < %numPlayers; %i = %i + 1)
	   {
		  %pl = getClientByIndex(%i);
		  %team = Client::getTeam(%pl);
		  %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
	   }
	   for(%i = 0; %i < %numTeams; %i = %i + 1)
	   {
		  if(%numTeamPlayers[%i] != %numTeamPlayers[0])
			 %oddPlayers=true;
	   }
	   if(Client::getTeam(%clientId) == -1 || %oddPlayers)
	   {
		  Client::addMenuItem(%clientId, "1Automatic", -1);
	  		  %i = bwadmin::getLowTeam();
	  		  Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
	  		  return;
	  	   }
	  	   else
		  Client::addMenuItem(%clientId, "1Teams are balanced!", Client::getTeam(%clientId));
	   return;

	   }

// - BW Admin Mod - End
	  else
	{
		 Client::addMenuItem(%clientId, "1Automatic", -1);
		 for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		 return;
	}
   }
   	else if(%opt == "bwspa")
   	{
		DisplaySmurf(%clientId, %cl);
	}
   else if(%opt == "mute")
	  %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
	  %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
	  %cl.voteTarget = true;
	  Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
	  %cl.voteTarget = true;
	  Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "bwaa")
   {
		if(!%clientId.AdminGeneral) // PORT: the menu only lists this for that right; the menu code is client-supplied
		{
			Game::menuRequest(%clientId);
			return;
		}
		%name = Client::getName(%cl); // PORT: was undefined, the items had no name
		%sel = %cl;

   		%curItem = 0;
   		Client::buildMenu(%clientId, "Choose Admin Action:", "cbwaa", true);
		if((%clientId.AdminCanAdminPlayer) && (!%cl.AdminServerSettings))
			Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "bwadmin " @ %sel);
		else if(($bwadmin::voteDisable[admin] != "true") && (!%sel.AdminGeneral))
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
		if($bwadmin::AdminDisable[warn] != "true")
			Client::addMenuItem(%clientId, %curItem++ @ "Warn " @ %name, "warn " @ %sel);
		if(%cl.purgatory)
		{
			if($bwadmin::AdminDisable[depurg] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "DePurgatise " @ %name, "cunpurg " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to depurgatise " @ %name, "vaunpurg " @ %sel);
		}
		else
		{
			if($bwadmin::AdminDisable[purg] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Purgatise " @ %name, "cpurg " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to purgatise " @ %name, "vapurg " @ %sel);
		}
		if($bwadmin::AdminDisable[kick] != "true")
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "ckick " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vakick " @ %sel);
		if(%clientId.AdminServerSettings)
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %cl);
		if(%cl.gagged)
		{
			if($bwadmin::AdminDisable[ungag] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %cl);
		}
		else
		{
			if($bwadmin::AdminDisable[gag] != "true")
				Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %cl);
		}
   		return;
   }
   else if(%opt == "bwgp")
   {
   		%curItem = 0;
		Client::buildMenu(%clientId, "Choose Game Play Option:", "cbwgp", true);
		if($Server::TourneyMode && $bwadmin::controlledTourneyMode && ($matchStarted || $CountdownStarted))
		{
			if(%clientId.AdminReferee)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
				if($bwadmin::GlobalReverseDamageMode == "true")
	  	   				Client::addMenuItem(%clientId, %curItem++ @ "Enable Reverse Damage", "rdmode");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Reverse Damage", "nordmode");
				if($bwadmin::noRape)
			   		Client::addMenuItem(%clientId, %curItem++ @ "Disable 'No Base Rape'", "rape");
				else
	  	   				Client::addMenuItem(%clientId, %curItem++ @ "Enable 'No Base Rape'", "norape");
					if($bwadmin::walk)
			   		Client::addMenuItem(%clientId, %curItem++ @ "Disable 'Long Walk Home'", "nowalk");
				else
				   	Client::addMenuItem(%clientId, %curItem++ @ "Enable 'Long Walk Home'", "walk");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Score Limit", "cscorelimit");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
				if(%clientId.AdminReferee)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Set Team Info", "cteamnames");
					Client::addMenuItem(%clientId, %curItem++ @ "League Match settings", "lmset");
				}
			}
		}
		else
		{
			if($Server::TeamDamageScale == 1.0)
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[dtd] == "false")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Damage", "dtd");
				else
					if($bwadmin::voteDisable[dtd] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			}
			else
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[etd] != "true")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Damage", "etd");
				else
					if($bwadmin::voteDisable[etd] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}
			if($bwadmin::GlobalReverseDamageMode == "true")
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[nord] != "true")) || (%clientId.AdminReferee))
	  	   			Client::addMenuItem(%clientId, %curItem++ @ "Disable Reverse Damage", "nordmode");
				else
					if($bwadmin::voteDisable[nord] != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable Rev. Damage", "vnordmode");
			}
			else
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[rd] != "true")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Reverse Damage", "rdmode");
				else
					if($bwadmin::voteDisable[rd] != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable Rev. Damage", "vrdmode");
			}
			if($bwadmin::noRape)
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[norape] != "true")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Disable 'No Base Rape'", "rape");
				else
					if($bwadmin::voteDisable[rape] != "true")
			   			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable 'No Base Rape'", "vrape");
			}
			else
			{
				if(((%clientId.AdminGeneral) && ($bwadmin::AdminDisable[rape] != "true")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Enable 'No Base Rape'", "norape");
				else
					if($bwadmin::voteDisable[norape] != "true")
	  	   				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable 'No Base Rape'", "vnorape");
			}
			if(%clientId.AdminReferee)
			{
				if($bwadmin::walk)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable 'Long Walk Home'", "nowalk");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable 'Long Walk Home'", "walk");
			}
			else
			{
				if($bwadmin::walk)
				{
					if($bwadmin::voteDisable[nowalk] != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable 'Long Walk Home'", "vnowalk");
				}
				else
				{
					if($bwadmin::voteDisable[walk] != "true")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable 'Long Walk Home'", "vwalk");
				}
			}
			if((!$bwadmin::AdminDisable[score] && %clientId.AdminGeneral) || (%clientId.AdminReferee))
				Client::addMenuItem(%clientId, %curItem++ @ "Set Score Limit", "cscorelimit");
			if((!$bwadmin::AdminDisable[time] && %clientId.AdminGeneral) || (%clientId.AdminReferee))
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
			if(%clientId.AdminReferee)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Set Team Info", "cteamnames");
				Client::addMenuItem(%clientId, %curItem++ @ "League Match settings", "lmset");
			}
		}
	  	return;
   }
   else if(%opt == "vsmatch")
	  Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vcffa")
	  Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vclna")
	  Admin::startVote(%clientId, "change to League(NoAdmin) mode", "lna", 0);
   else if(%opt == "vctourney")
	  Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cmode")
   {
	  if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	  {
	  	Game::menuRequest(%clientId);
	  	return;
	  }
	  %curItem = 0;
	  Client::buildMenu(%clientId, "Choose Server Mode:", "cbwcsm", true);
	  if($Server::TourneyMode || $bwadmin::controlledTourneyMode)
		 Client::addMenuItem(%clientId, %curItem++ @ "FFA", cfmode);
	  if((!$Server::TourneyMode || $bwadmin::controlledTourneyMode) && ($bwadmin::DisableTourneyMode != "true"))
		 Client::addMenuItem(%clientId, %curItem++ @ "Tournament", ctmode);
	  if(!$bwadmin::ReflessTourneyMode)
		 Client::addMenuItem(%clientId, %curItem++ @ "League(NoAdmin)", clnamode);
	  if(!$Server::TourneyMode || !$bwadmin::controlledTourneyMode)
		 Client::addMenuItem(%clientId, %curItem++ @ "League", clmode);
	  return;
   }
// - BW Admin Mod - End
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
	  %clientId.vote = "yes";
	  centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
	  %clientId.vote = "no";
	  centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
	  Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
	  Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
	  Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
	  return;
   }
   	else if(%opt == "purg")
   	{
	  	Client::buildMenu(%clientId, "Confirm Purgatise:", "paffirm", true);
		Client::addMenuItem(%clientId, "1Purgatise " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't purgatise " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "unpurg")
   	{
		if(!%clientId.AdminGeneral) // PORT: the menu only lists this for that right; the menu code is client-supplied
		{
			Game::menuRequest(%clientId);
			return;
		}
   		%ip = Client::getTransportAddress(%cl);
   		Admin::PurgMode(%cl,false,%ip,%clientId);
   		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") depurgatised " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
   		return;
	}
   	else if(%opt == "vpurg")
   	{
   		%cl.voteTarget = true;
   		Admin::startVote(%clientId, "purgatise " @ Client::getName(%cl), "purg", %cl);
   	}
   	else if(%opt == "vunpurg")
   	{
   		%cl.voteTarget = true;
   		Admin::startVote(%clientId, "depurgatise " @ Client::getName(%cl), "unpurg", %cl);
	}
   else if(%opt == "admin")
   {
	  Client::buildMenu(%clientId, "Confirm admin:", "aaffirm", true);
	  Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
	  Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
	  return;
   }
   else if(%opt == "smatch")
   {
	  Admin::startMatch(%clientId);
	  return;
   }
   else if(%opt == "vcmission")
   {
	  %clientId.missionVote = true; // PORT: was the global $MissionVote
	  Admin::changeMissionMenu(%clientId, %opt == "cmission");
	  return;
   }
   else if(%opt == "cmission")
   {
	  if(!%clientId.AdminGeneral || ($bwadmin::AdminDisable[cmission] == "true" && !%clientId.AdminReferee && !%clientId.AdminServerSettings)) // PORT: the test of the menu
	  {
		 Game::menuRequest(%clientId);
		 return;
	  }
	  %clientId.missionVote = false; // PORT: was the global $MissionVote
	  Admin::changeMissionMenu(%clientId, %opt == "cmission");
	  return;
   }
   	else if(%opt == "pskinon")
   	{
		Client::buildMenu(%clientId, "Confirm Enable Custom Skins:", "CSkinAffirm", true);
		Client::addMenuItem(%clientId, "1Enable Custom Skins", "yes");
   		Client::addMenuItem(%clientId, "2Don't Enable Custom Skins", "no");
		return;
	}
	else if(%opt == "pskinoff")
	{
		Client::buildMenu(%clientId, "Confirm Enable Server Skins:", "SSkinAffirm", true);
		Client::addMenuItem(%clientId, "1Enable Server Skins", "yes");
		Client::addMenuItem(%clientId, "2Don't Enable Server Skins", "no");
		return;
	}
   else if (%opt == "bco")
   {
	  	%curItem = 0;
	  	if(%clientId.zoom == "")
			%clientId.zoom = 5;
	 	Client::buildMenu(%clientId, "Pick a Camera Range: ", "POMode", true);
	 	if(%clientId.observerTarget != "")
	 	{
	 		if(%clientId.zoom != "5" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Inner Orbit", "specmode 5");
   			if(%clientId.zoom != "10" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Outer Orbit", "specmode 10");
	 		if(%clientId.zoom != "20" && (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerObjectiveOrbit"))
		   		Client::addMenuItem(%clientId, %curItem++ @ "Extreme Orbit", "specmode 20");
	 		if(%clientId.zoom != "-1" && %clientId.observerMode == "observerOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Eyes", "specmode -1");
	 		if(%clientId.zoom != "-3" && %clientId.observerMode == "observerOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Chase", "specmode -3");
	 		if(%clientId.observerMode == "observerObjectiveOrbit")
		   		Client::addMenuItem(%clientId, %curItem++ @ "Observe Players", "specmode player");
			Client::addMenuItem(%clientId, %curItem++ @ "Free Flight", "specmode fly");
	 	}
	 	else
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Players", "specmode player");
	 	%obj = getNextObject(nameToID("MissionCleanup/ObjectivesSet"), 0);
	 	if(%obj && %clientId.observerMode != "observerObjectiveOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Objectives", "specmode objective");
		Client::addMenuItem(%clientId, %curItem++ @ "ReDisplay Target's Name", "objname");
	 	return;
   }
   else if(%opt == "observe")
   {
	  if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
		 %clientId.observerMode = "observerOrbit";
	  Observer::setTargetClient(%clientId, %cl);
	  return;
   }
   else if(%opt == "crgear")
   {
	  Client::buildMenu(%clientId, "Select Role:", "ChangeRGear", true);
	  Client::addMenuItem(%clientId, "1Attack", "attack");
	  Client::addMenuItem(%clientId, "2Defense", "defense");
	  Client::addMenuItem(%clientId, "3Repair", "repair");
	  if(!$Combat::NoSniperGear) Client::addMenuItem(%clientId, "4Sniper", "sniper");
	  return;
   }
   else if(%opt == "crwmode")
   {
	remoteWeaponModeNext(%clientId);
	return;
   }
	// - BW Admin Mod - bwadmin menu
   else if(%opt == "bwaf")
   {
   		if($bwadmin::PingAbove)
   			%display = $bwadmin::PingAbove @ " ms";
   		else
   			%display = "Disabled";
   		%curItem = 0;
	  	Client::buildMenu(%clientId, "Choose BWAdmin Server Setting:", "cbwaf", true);
	  	Client::addMenuItem(%clientId, %curItem++ @ "Bad Play Control", "bpc");
   		Client::addMenuItem(%clientId, %curItem++ @ "Set Team Energy", "ste");
   		if($bwadmin::autoMissionSkipVote == "true")
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Disable AutoVote", "noautovote");
   		else
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Enable AutoVote", "autovote");
	  	Client::addMenuItem(%clientId, %curItem++ @ "Set Server Password", "p+ 1");
	  	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	  	Client::addMenuItem(%clientId, %curItem++ @ "Clear all admin rights", "clearadmin");
	  	Client::addMenuItem(%clientId, %curItem++ @ "Min Ping Allowed (" @ %display @ ")", "pingmin");
		Client::addMenuItem(%clientId, %curItem++ @ "BWAdmin Version Info", "bwavers");
	  	return;
   }
	// - BW Admin Mod - End
   Game::menuRequest(%clientId);
}


function processMenucbwadmin(%clientId, %option)
{
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
	// PORT: no rights test at all here. Options 'bwaa <own id>', 'bwadmin <own id>', 'gagr <own id>'
	// made any player an admin. Tests = the ones the cbwaa menu uses to list each item.
	if(!%clientId.AdminCanAdminPlayer || %cl.AdminServerSettings
	   || ((%opt == "garr" || %opt == "rarr") && !%clientId.AdminReferee)
	   || ((%opt == "gaiir" || %opt == "raiir") && !%clientId.AdminIsImmune))
	{
		Game::menuRequest(%clientId);
		return;
	}
	if (%opt == "lar")
	{
		BWAdmin_ListAdminRights(%cl, %clientId);
		return;
	}
	else if (%opt == "gagr")
	{
		%cl.AdminGeneral = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminGeneral rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminGeneral rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminGeneral rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "raar")
	{
		%cl.isAdmin = false;
		%cl.isSuperAdmin = false;
		%cl.AdminIsImmune = false;
		%cl.AdminGeneral = false;
		%cl.AdminServerSettings = false;
		%cl.AdminCanAdminPlayer = false;
		%cl.AdminReferee = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed all admin rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "All your admin rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed all admin rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "garr")
	{
		%cl.AdminReferee = true;
		%cl.AdminGeneral = true;
		%cl.isAdmin = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminReferee rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminReferee rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminReferee rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "rarr")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminReferee = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminReferee rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminReferee rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminReferee rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "gaiir")
	{
		%cl.AdminIsImmune = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminIsImmune rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminIsImmune rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminIsImmune rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "raiir")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminIsImmune = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminIsImmune rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminIsImmune rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminIsImmune rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "gacapr")
	{
		%cl.AdminCanAdminPlayer = true;
		%cl.AdminGeneral = true;
		%cl.isAdmin = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminCanAdminPlayer rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminCanAdminPlayer rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminCanAdminPlayer rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
	else if (%opt == "racapr")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminCanAdminPlayer = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminCanAdminPlayer rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminCanAdminPlayer rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminCanAdminPlayer rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
		return;
	}
  	Game::menuRequest(%clientId);
}


function processMenucbwaa(%clientId, %option)
{
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
	if(!%clientId.AdminGeneral || (%opt == "bwadmin" && (!%clientId.AdminCanAdminPlayer || %cl.AdminServerSettings))
	   || (%opt == "ban" && !%clientId.AdminServerSettings)) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	if(%opt == "bwadmin")
	{
			%curItem = 0;
			Client::buildMenu(%clientId, "Choose Admin Option:", "cbwadmin", true);
			Client::addMenuItem(%clientId, %curItem++ @ "List Admin Rights", "lar " @ %cl);
			if(!%cl.AdminGeneral)
				Client::addMenuItem(%clientId, %curItem++ @ "Give AdminGeneral Rights", "gagr " @ %cl);
			else if(!%cl.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "Remove All Admin Rights ", "raar " @ %cl);
			if((!%cl.AdminReferee) && (%clientId.AdminReferee))
				Client::addMenuItem(%clientId, %curItem++ @ "Give AdminReferee Rights", "garr " @ %cl);
			else if((!%cl.AdminServerSettings) && (%clientId.AdminReferee))
				Client::addMenuItem(%clientId, %curItem++ @ "Remove AdminReferee Rights", "rarr " @ %cl);
			if((!%cl.AdminIsImmune) && (%clientId.AdminIsImmune))
				Client::addMenuItem(%clientId, %curItem++ @ "Give AdminIsImmune Rights", "gaiir " @ %cl);
			else if((!%cl.AdminServerSettings) && (%clientId.AdminIsImmune))
				Client::addMenuItem(%clientId, %curItem++ @ "Remove AdminIsImmune Rights", "raiir " @ %cl);
			if((!%cl.AdminCanAdminPlayer) && (%clientId.AdminCanAdminPlayer))
				Client::addMenuItem(%clientId, %curItem++ @ "Give AdminCanAdminPlayer Rights", "gacapr " @ %cl);
			else if((!%cl.AdminServerSettings) && (%clientId.AdminCanAdminPlayer))
				Client::addMenuItem(%clientId, %curItem++ @ "Remove AdminCanAdminPlayer Rights", "racapr " @ %cl);
			return;
   	}
   	else if(%opt == "vadmin")
	{
		  %cl.voteTarget = true;
		  Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
		  return;
   	}
   	else if(%opt == "ckick")
   	{
	  	Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
	  	Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "vakick")
   	{
	  	%cl.voteTarget = true;
	  	Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   	}
   	else if(%opt == "cpurg")
   	{
	  	Client::buildMenu(%clientId, "Confirm Purgatise:", "paffirm", true);
		Client::addMenuItem(%clientId, "1Purgatise " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't purgatise " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "cunpurg")
   	{
   		%ip = Client::getTransportAddress(%cl);
   		Admin::PurgMode(%cl,false,%ip,%clientId);
   		return;
	}
   	else if(%opt == "vapurg")
   	{
   		%cl.voteTarget = true;
   		Admin::startVote(%clientId, "purgatise " @ Client::getName(%cl), "purg", %cl);
   	}
   	else if(%opt == "vaunpurg")
   	{
   		%cl.voteTarget = true;
   		Admin::startVote(%clientId, "depurgatise " @ Client::getName(%cl), "unpurg", %cl);
	}
   	else if(%opt == "warn")
   	{
	  	Client::buildMenu(%clientId, "Confirm warn:", "waffirm", true);
	  	Client::addMenuItem(%clientId, "1Warn " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't warn " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "ban")
   	{
	  	Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
	  	Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "gag")
   	{
	  	Client::buildMenu(%clientId, "Confirm Gag:", "gaffirm", true);
	  	Client::addMenuItem(%clientId, "1Gag " @ Client::getName(%cl), "yes " @ %cl);
	  	Client::addMenuItem(%clientId, "2Don't gag " @ Client::getName(%cl), "no " @ %cl);
	  	return;
   	}
   	else if(%opt == "ungag")
   	{
		%cl.gagged = false;
		Client::sendMessage(%clientId, 1, "You UnGagged " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "You have been ungagged and may now speak");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") ungagged " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
	  	return;
   	}


  	Game::menuRequest(%clientId);
}


function processMenucbwcsm(%clientId, %opt)
{
  if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
  {
  	Game::menuRequest(%clientId);
  	return;
  }
  if (%opt == "clmode")
  {
	Client::buildMenu(%clientId, "Confirm League Mode:", "modeaffirm", true);
	Client::addMenuItem(%clientId, "1Change", "yes league");
	Client::addMenuItem(%clientId, "2Don't change", "no league");
	return;
  }
  else if (%opt == "clnamode")
  {
	Client::buildMenu(%clientId, "Confirm League(NoAdmin) Mode:", "modeaffirm", true);
	Client::addMenuItem(%clientId, "1Change", "yes leaguena" );
	Client::addMenuItem(%clientId, "2Don't change", "no leaguena");
	return;
  }
  else if (%opt == "ctmode")
  {
	Client::buildMenu(%clientId, "Confirm Tournament Mode:", "modeaffirm", true);
	Client::addMenuItem(%clientId, "1Change", "yes tournament" );
	Client::addMenuItem(%clientId, "2Don't change", "no tournament");
	return;
  }
  else if (%opt == "cfmode")
  {
	Client::buildMenu(%clientId, "Confirm FFA Mode:", "modeaffirm", true);
	Client::addMenuItem(%clientId, "1Change", "yes ffa" );
	Client::addMenuItem(%clientId, "2Don't change", "no ffa");
	return;
  }
  Game::menuRequest(%clientId);
}




// - BW Admin Server Settings menu choices
function processMenucbwaf(%clientId, %opt)
{
   if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   if(%opt == "autovote")
   {
	  $bwadmin::autoMissionSkipVote = "true";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Auto Voting ENABLED.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled automatic voting",%clientId);
	  return;
   }
   if(%opt == "noautovote")
   {
	  $bwadmin::autoMissionSkipVote = "";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Auto Voting DISABLED.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled automatic voting",%clientId);
	  return;
   }
   if(%opt == "bpc")
   {
		%curItem = 0;
   	Client::buildMenu(%clientId, "Bad Play Control", "bpc", true);
  	if($bwadmin::noLlamaSwap)
	  		Client::addMenuItem(%clientId, %curItem++ @ "Allow Llama Team Swaps", "als");
   	else
	  		Client::addMenuItem(%clientId, %curItem++ @ "No Llama Team Swaps", "dls");
   	if($bwadmin::AutoAntiTK == "true")
	  		Client::addMenuItem(%clientId, %curItem++ @ "Disable Auto Anti-TK", "daatk");
   	else
	  		Client::addMenuItem(%clientId, %curItem++ @ "Enable Auto Anti-TK", "eaatk");
   	Client::addMenuItem(%clientId, %curItem++ @ "Reverse Damage Setup", "rdsetup");
   	Client::addMenuItem(%clientId, %curItem++ @ "Set Station Eject Time", "ejecttime");
   	if($bwadmin::randomTeams == "true")
	  		Client::addMenuItem(%clientId, %curItem++ @ "Disable Random Teams", "drt");
   	else
	  		Client::addMenuItem(%clientId, %curItem++ @ "Enable Random Teams", "ert");
	Client::addMenuItem(%clientId, %curItem++ @ "Set OOB Kill Time", "oobkill");
	return;
   }
   if (%opt == "ste")
   {
	  Client::buildMenu(%clientId, "Change Team Energy(" @ $bwadmin::DefaultTeamEnergy @ ")", "cteamenergy", true);
	  Client::addMenuItem(%clientId, "15000 Points", 5000);
	  Client::addMenuItem(%clientId, "215000 Points", 15000);
	  Client::addMenuItem(%clientId, "325000 Points", 25000);
	  Client::addMenuItem(%clientId, "435000 Points", 35000);
	  Client::addMenuItem(%clientId, "545000 Points", 45000);
	  Client::addMenuItem(%clientId, "655000 Points", 55000);
	  Client::addMenuItem(%clientId, "775000 Points", 75000);
	  if($DefaultTeamEnergy != "Infinite" || $bwadmin::DefaultTeamEnergy != "Infinite")
		Client::addMenuItem(%clientId, "8Disabled", Infinite);
	  return;
   }
   else if (%opt == "bwavers")
   {
		bottomprint(%clientID, "<jc><f1>BarrysWorld Admin mod " @ $bwadmin::version @ " for Tribes " @ $bwadmin::tribesVersion @ " by Poker", 10);
		return;
   }
   else if (getWord(%opt, 0) == "p+")
   {
		%first = getWord(%opt, 1);
		%curItem = 0;
		Client::buildMenu(%clientId, "Choose Password:", "selectpass", true);
		if(%first == "1" && $server::password != "")
		   Client::addMenuItem(%clientId, "0None (Remove Password)", "p+ 0");
		for(%p = %first; %p < ($bwadmin::numberOfPass+1); %p++)
		{
			if(%curItem > 5)
			{
				   Client::addMenuItem(%clientId, %curItem ++ @ "More passwords...", "p+ " @ %p);
				   break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::Pass[%p], "p+ " @ %p);
		}
		return;
   }
   else if(%opt == "reset")
   {
	   Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
	   Client::addMenuItem(%clientId, "1Reset", "yes");
	   Client::addMenuItem(%clientId, "2Don't Reset", "no");
	   return;
   }
   else if(%opt == "clearadmin")
   {
	   Client::buildMenu(%clientId, "Confirm Clear Admin Rights:", "caaffirm", true);
	   Client::addMenuItem(%clientId, "1Clear Admins", "yes");
	   Client::addMenuItem(%clientId, "2Don't Clear Admins", "no");
	   return;
   }
   else if(%opt == "pingmin")
   {
	   	Client::buildMenu(%clientId, "Select Min Ping Allowed:", "cpingmin", true);
	  	Client::addMenuItem(%clientId, "1100 ms", 100);
	  	Client::addMenuItem(%clientId, "2120 ms", 120);
	  	Client::addMenuItem(%clientId, "3150 ms", 150);
	  	Client::addMenuItem(%clientId, "4170 ms", 170);
	  	Client::addMenuItem(%clientId, "5200 ms", 200);
	  	Client::addMenuItem(%clientId, "6220 ms", 220);
	  	Client::addMenuItem(%clientId, "7250 ms", 250);
	  	if($bwadmin::PingAbove)
			Client::addMenuItem(%clientId, "8Disable", 0);
	  	return;
   }
   Game::menuRequest(%clientId);
}

function processMenubpc(%clientId, %opt)
{
  if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
  {
  	Game::menuRequest(%clientId);
  	return;
  }
  if (%opt == "als")
  {
	  $bwadmin::noLlamaSwap = "false";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Swapping to larger team ENABLED.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled swapping to larger team",%clientId);
	  return;
  }

  else if (%opt == "dls")
  {
	$bwadmin::noLlamaSwap = "true";
	bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Swapping to larger team DISABLED.", 3);
	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled swapping to larger team",%clientId);
	return;
  }
  else if (%opt == "daatk")
  {
	  $bwadmin::AutoAntiTK = "false";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Auto Anti-TK Disabled.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled auto anti-tk",%clientId);
	  return;
  }
  else if (%opt == "eaatk")
  {
	  $bwadmin::AutoAntiTK = "true";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Auto Anti-TK Enabled.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled auto anti-tk",%clientId);
	  return;
  }
  else if (%opt == "rdsetup")
  {
	  	%curItem = 0;
	  	Client::buildMenu(%clientId, "Reverse Damage Setup", "crdsetup", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Set Player Attacker Factor", "rdpaf");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Player Victim Factor", "rdpvf");
		if($bwadmin::VehicleRD == "true")
   			Client::addMenuItem(%clientId, %curItem++ @ "Disable Vehicle RD", "dvrd");
		else
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Enable Vehicle RD", "evrd");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Vehicle Attacker Factor", "rdvaf");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Vehicle Victim Factor", "rdvvf");
		if($bwadmin::DeployableRD == "true")
   			Client::addMenuItem(%clientId, %curItem++ @ "Disable Deployable RD", "ddrd");
		else
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Enable Deployable RD", "edrd");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Deployable Attacker Factor", "rddaf");
		Client::addMenuItem(%clientId, %curItem++ @ "Set Deployable Victim Factor", "rddvf");
	  	return;
  }
  else if (%opt == "ejecttime")
  {
	  if($bwadmin::StationTime)
	  	%display = $bwadmin::StationTime;
	  else
	  	%display = "Disabled";
	  Client::buildMenu(%clientId, "Change Station Eject Time(" @ %display @ ")", "cejecttime", true);
	  Client::addMenuItem(%clientId, "110 Seconds", 10);
	  Client::addMenuItem(%clientId, "215 Seconds", 15);
	  Client::addMenuItem(%clientId, "320 Seconds", 20);
	  Client::addMenuItem(%clientId, "425 Seconds", 25);
	  Client::addMenuItem(%clientId, "530 Seconds", 30);
	  Client::addMenuItem(%clientId, "635 Seconds", 35);
	  Client::addMenuItem(%clientId, "740 Seconds", 40);
	  if(!$bwadmin::StationTime)
		Client::addMenuItem(%clientId, "8Disable", 0);
	  return;
  }
  else if (%opt == "oobkill")
  {
		if($bwadmin::OutOfBoundsTime == 0)
			%display = "Disabled";
		else
			%display = $bwadmin::OutOfBoundsTime @ " sec";
	  Client::buildMenu(%clientId, "Change OOB Kill Time(" @ %display @ ")", "coobkill", true);
	  Client::addMenuItem(%clientId, "120 Seconds", 20);
	  Client::addMenuItem(%clientId, "240 Seconds", 40);
	  Client::addMenuItem(%clientId, "360 Seconds", 60);
	  Client::addMenuItem(%clientId, "480 Seconds", 80);
	  Client::addMenuItem(%clientId, "5120 Seconds", 120);
	  Client::addMenuItem(%clientId, "6160 Seconds", 160);
	  Client::addMenuItem(%clientId, "7200 Seconds", 200);
	  Client::addMenuItem(%clientId, "8Disable", 0);
	  return;
  }
  if (%opt == "drt")
  {
	  $bwadmin::randomTeams = "";
	  bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Random Teams DISABLED.", 3);
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled random teams",%clientId);
	  return;
  }

  else if (%opt == "ert")
  {
	$bwadmin::randomTeams = "true";
	bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Random Teams ENABLED.", 3);
	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled random teams",%clientId);
	return;
  }
  Game::menuRequest(%clientId);
}




function processMenucrdsetup(%clientId, %opt)
{
  	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
  	{
  		Game::menuRequest(%clientId);
  		return;
  	}
  	if (%opt == "rdpaf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Attacker Factor(" @ $bwadmin::PlayerAttackerRevFactor @ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 pa");
	  	Client::addMenuItem(%clientId, "250%", "0.50 pa");
	  	Client::addMenuItem(%clientId, "3100%", "1.00 pa");
	  	Client::addMenuItem(%clientId, "4150%", "1.50 pa");
	  	Client::addMenuItem(%clientId, "5200%", "2.00 pa");
	  	return;
  	}
  	else if (%opt == "rdpvf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Victim Factor(" @ $bwadmin::PlayerVictimRevFactor @ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 pv");
	  	Client::addMenuItem(%clientId, "225%", "0.25 pv");
	  	Client::addMenuItem(%clientId, "350%", "0.50 pv");
	  	Client::addMenuItem(%clientId, "475%", "0.75 pv");
	  	Client::addMenuItem(%clientId, "5100%", "1.00 pv");
	  	return;
  	}
  	else if (%opt == "dvrd")
  	{
		$bwadmin::VehicleRD = "false";
		Client::sendMessage(%clientId, 1, "You have disabled vehicle reverse damage.");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled vehicle reverse damage",%clientId);
	  	return;
  	}
  	else if (%opt == "evrd")
  	{
		$bwadmin::VehicleRD = "true";
		Client::sendMessage(%clientId, 1, "You have enabled vehicle reverse damage.");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled vehicle reverse damage",%clientId);
	  	return;
  	}
  	else if (%opt == "rdvaf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Attacker Factor(" @ $bwadmin::VehicleAttackerRevFactor @ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 va");
	  	Client::addMenuItem(%clientId, "250%", "0.50 va");
	  	Client::addMenuItem(%clientId, "3100%", "1.00 va");
	  	Client::addMenuItem(%clientId, "4150%", "1.50 va");
	  	Client::addMenuItem(%clientId, "5200%", "2.00 va");
	  	return;
  	}
  	else if (%opt == "rdvvf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Victim Factor(" @ $bwadmin::VehicleVictimRevFactor @ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 vv");
	  	Client::addMenuItem(%clientId, "225%", "0.25 vv");
	  	Client::addMenuItem(%clientId, "350%", "0.50 vv");
	  	Client::addMenuItem(%clientId, "475%", "0.75 vv");
	  	Client::addMenuItem(%clientId, "5100%", "1.00 vv");
	  	return;
  	}
  	else if (%opt == "ddrd")
  	{
		$bwadmin::DeployableRD = "false";
		Client::sendMessage(%clientId, 1, "You have disabled deployable reverse damage.");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled deployable reverse damage",%clientId);
	  	return;
  	}
  	else if (%opt == "edrd")
  	{
		$bwadmin::DeployableRD = "true";
		Client::sendMessage(%clientId, 1, "You have enabled deployable reverse damage.");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled deployable reverse damage",%clientId);
	  	return;
  	}
  	else if (%opt == "rddaf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Attacker Factor(" @ $bwadmin::DeployableAttackerRevFactor@ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 da");
	  	Client::addMenuItem(%clientId, "250%", "0.50 da");
	  	Client::addMenuItem(%clientId, "3100%", "1.00 da");
	  	Client::addMenuItem(%clientId, "4150%", "1.50 da");
	  	Client::addMenuItem(%clientId, "5200%", "2.00 da");
	  	return;
  	}
  	else if (%opt == "rddvf")
  	{
	  	Client::buildMenu(%clientId, "Change Player Victim Factor(" @ $bwadmin::DeployableVictimRevFactor @ ")", "crdfactor", true);
	  	Client::addMenuItem(%clientId, "10%", "0 dv");
	  	Client::addMenuItem(%clientId, "225%", "0.25 dv");
	  	Client::addMenuItem(%clientId, "350%", "0.50 dv");
	  	Client::addMenuItem(%clientId, "475%", "0.75 dv");
	  	Client::addMenuItem(%clientId, "5100%", "1.00 dv");
	  	return;
  	}
	Game::menuRequest(%clientId);
}


function processMenucbwgp(%clientId, %opt)
{
	if(%opt == "vetd")
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);
	else if(%opt == "etd")
		Admin::setTeamDamageEnable(%clientId, true);
	else if(%opt == "dtd")
		Admin::setTeamDamageEnable(%clientId, false);
	if(%opt == "vrdmode")
		Admin::startVote(%clientId, "enable reverse damage", "rdmode", 0);
	else if(%opt == "vnordmode")
		Admin::startVote(%clientId, "disable reverse damage", "nordmode", 0);
	else if(%opt == "rdmode")
		Admin::setReverseDamageEnable(%clientId, true);
	else if(%opt == "nordmode")
		Admin::setReverseDamageEnable(%clientId, false);
	else if(%opt == "vrape")
		Admin::startVote(%clientId, "disable 'No Base Rape'", "rape", 0);
	else if(%opt == "vnorape")
		Admin::startVote(%clientId, "enable 'No Base Rape'", "norape", 0);
  	else if (%opt == "rape")
  	{
		Client::buildMenu(%clientId, "Confirm Disable 'No Base Rape'", "modeaffirm", true);
		Client::addMenuItem(%clientId, "1Disable", "yes rape");
		Client::addMenuItem(%clientId, "2Don't disable", "no rape");
		return;
  	}
  	else if (%opt == "norape")
  	{
		Client::buildMenu(%clientId, "Confirm Enable 'No Base Rape':", "modeaffirm", true);
		Client::addMenuItem(%clientId, "1Enable", "yes norape");
		Client::addMenuItem(%clientId, "2Don't enable", "no norape");
		return;
  	}
	else if(%opt == "vnowalk")
		Admin::startVote(%clientId, "disable Long Walk", "nowalk", 0);
	else if(%opt == "vwalk")
		Admin::startVote(%clientId, "enable Long Walk", "walk", 0);
  	else if (%opt == "nowalk")
  	{
		Client::buildMenu(%clientId, "Confirm Disable Long Walk:", "modeaffirm", true);
		Client::addMenuItem(%clientId, "1Disable", "yes nowalk");
		Client::addMenuItem(%clientId, "2Don't disable", "no nowalk");
		return;
  	}
  	else if (%opt == "walk")
  	{
		Client::buildMenu(%clientId, "Confirm Enable Long Walk:", "modeaffirm", true);
		Client::addMenuItem(%clientId, "1Enable", "yes walk");
		Client::addMenuItem(%clientId, "2Don't enable", "no walk");
		return;
  	}
	else if(%opt == "cscorelimit")
	{
		Client::buildMenu(%clientId, "Change Score Limit:", "cslimit", true);
		Client::addMenuItem(%clientId, "0Default for Mission", "");
		Client::addMenuItem(%clientId, "15 Points", 5);
		Client::addMenuItem(%clientId, "28 Points", 8);
		Client::addMenuItem(%clientId, "310 Points", 10);
		Client::addMenuItem(%clientId, "415 Points", 15);
		Client::addMenuItem(%clientId, "51000 Points", 1000);
		Client::addMenuItem(%clientId, "62000 Points", 2000);
		Client::addMenuItem(%clientId, "7No Score Limit", False);
		return;
	}
   	else if(%opt == "ctimelimit")
   	{
	  	Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
	  	Client::addMenuItem(%clientId, "110 Minutes", 10);
	  	Client::addMenuItem(%clientId, "215 Minutes", 15);
	  	Client::addMenuItem(%clientId, "320 Minutes", 20);
	  	Client::addMenuItem(%clientId, "425 Minutes", 25);
	  	Client::addMenuItem(%clientId, "530 Minutes", 30);
	  	Client::addMenuItem(%clientId, "645 Minutes", 45);
	  	Client::addMenuItem(%clientId, "760 Minutes", 60);
	  	Client::addMenuItem(%clientId, "8No Time Limit", 0);
	  	return;
   	}
	else if(%opt == "cteamnames")
	{
		Client::buildMenu(%clientId, "Choose team:", "selectdivision", true);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
	   	return;
   	}
	else if (%opt == "lmset")
  	{
		if($NextLeagueMap == "")
			$NextLeagueMap = $missionName;
		Client::buildMenu(%clientId, "League Match Settings", "matchset", true);
		Client::addMenuItem(%clientId, "0Score Limit", score);
		Client::addMenuItem(%clientId, "1Time Limit", time);
		if(!$bwadmin::teamSwap)
	   		Client::addMenuItem(%clientId, "2Swap teams next mission", "swap");
		else
	   		Client::addMenuItem(%clientId, "2Cancel Team Swap", "swap");
	   	Client::addMenuItem(%clientId, "3Next Map ("@$NextLeagueMap@")", "leaguemission");
		if($bwadmin::allowCustomSkinsLeague != "true")
	   		Client::addMenuItem(%clientId, "4Enable Custom Skins", "ecskin");
		else
	   		Client::addMenuItem(%clientId, "4Disable Custom Skins", "dcskin");
		Client::addMenuItem(%clientId, "5League Name", name);
		return;
  	}
	Game::menuRequest(%clientId);
}


function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
	  Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuGAffirm(%clientId, %option)
{
	if(!%clientId.AdminGeneral) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
   	if(%opt == "yes")
   	{
   		%cl.gagged = true;
   		Client::sendMessage(%clientId, 1, "You have gagged " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "You have been gagged and may now not speak to anyone");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gagged " @ Client::getName(%cl) @ " (" @ %cl @ ")",%clientId,%cl);
	}
	Game::menuRequest(%clientId);
}

function processMenuCSkinAffirm(%clientId, %opt)
{
   	if(%opt == "yes")
   	{
		//Check if team is using players skin
		%enable = true;
		for(%i = 0; %i < getNumTeams()+1; %i++)
		{
			if($Client::info[%clientId, 0] == $Server::teamSkin[%i])
				%enable = false;
		}
		if(%enable)
		{
			%clientId.customSkin = true;
			bottomprint(%clientId,"<jc><f2>Custom Skins Enabled.\n<f1>Changes Take Place on Next Respawn", 5);
		}
		else
		{
			%clientId.customSkin = false;
			bottomprint(%clientId,"<jc><f2>Custom Skins May Not Be Enabled/n/nThe skin you have selected is in use as a server team skin.", 5);
		}
	}
	Game::menuRequest(%clientId);
}

function processMenuSSkinAffirm(%clientId, %opt)
{
   	if(%opt == "yes")
   	{
		%clientId.customSkin = false;
		bottomprint(%clientId,"<jc><f2>Custom Skins Disabled.\n<f1>Changes Take Place on Next Respawn", 5);
	}
	Game::menuRequest(%clientId);
}



function processMenuPAffirm(%clientId, %opt)
{
   	if(!%clientId.AdminGeneral) // PORT: the menu only lists this for that right; the menu code is client-supplied
   	{
   		Game::menuRequest(%clientId);
   		return;
   	}
   	%cl = getWord(%opt, 1); // PORT: was undefined, the ban below got no address
   	if(getWord(%opt, 0) == "yes")
   	{
   		%ip = Client::getTransportAddress(%cl);
   		Admin::PurgMode(getWord(%opt, 1),true,%ip,%clientId);
	}
   	Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
	  Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

// - BWAdmin mod - Warn
function processMenuWAffirm(%clientId, %opt)
{
   if(!%clientId.AdminGeneral) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   %cl = getWord(%opt, 1); // PORT: was undefined in the log line
   if(getWord(%opt, 0) == "yes")
   {
	  %warned = getWord(%opt, 1);
	%name = Client::getName(%warned);
	  centerprint(%warned, "<jc>Server Admin: <f1>Warning, you will be kicked if you continue your inappropriate behaviour!", 10);
	  messageAll(1, Client::getName(%warned) @ " has been warned by an admin for inappropriate behaviour.");
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") warned " @ %name @ " (" @ %cl @ ")",%clientId,%cl);
   }
   Game::menuRequest(%clientId);
}
// - BWAdmin mod - Warn

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
	  if(%clientId.isSuperAdmin)
	  {
		 %cl = getWord(%opt, 1);
		 %cl.isAdmin = true;
		 messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
	  }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	  messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
	  AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") reset the server to default settings",%clientId);
	  MR::enableRotationReset();
	  exec("bwuserlist.cs");
	  Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCAAffirm(%clientId, %opt)
{
   if(%opt != "yes" || !%clientId.AdminServerSettings) // PORT: the 'cleared' message and log line below ran for anybody
   {
      Game::menuRequest(%clientId);
      return;
   }
   if(%opt == "yes" && %clientId.AdminServerSettings)
   {
 	  %count = 2;
 	  for(%i=1;%i < %count; %i = %i + 1)
 	  {
		  %count++;
		  if(%i == 1)
		  	%cl = Client::getFirst();
		  else
		  	%cl = Client::getNext(%cl);
		  if(%cl != -1)
		  {
			  if((%cl != %clientId) && (!%cl.AdminIsImmune))
			  {
					%cl.isAdmin = false;
					%cl.isSuperAdmin = false;
					%cl.AdminIsImmune = false;
					%cl.AdminGeneral = false;
					%cl.AdminServerSettings = false;
					%cl.AdminCanAdminPlayer = false;
					%cl.AdminReferee = false;
					%cl.AdminVerified = false;
			  }
		  }
		  else
		  	%i = %count + 1;
	  }
   }
   Client::sendMessage(%clientId, 1, "You have cleared all current users admin rights.");
   AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") cleared all users admin rights.",%clientId);
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuPOMode(%clientId, %opt)
{
  if(getWord(%opt, 0) == "specmode")
  {
	%zoom = getWord(%opt, 1);
	if(%zoom == "player")
	{
	   %clientId.observerMode = "observerOrbit";
	   Observer::nextObservable(%clientId);
	}
	else if(%zoom == "fly")
	{
	   %clientId.observerTarget = "";
	   %clientId.observerMode = "observerFly";
	   %cam = Client::getObserverCamera(%clientId);
	   Observer::setFlyMode(%clientId, GameBase::getPosition(%cam), GameBase::getRotation(%cam), true, true);
	   bwadmin::setObserved(%clientId);
	}
	else if(%zoom == "objective")
	   bwadmin::nextObsObj(%clientId);
	else
	   remotebwadmin::zoom(%clientId, %zoom);
	return;
  }
  else if(getWord(%opt, 0) == "objname")
  {
	 bwadmin::setObserved(%clientId, true);
	 return;
  }
  Game::menuRequest(%clientId);
}


function processMenuModeAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
	  // PORT: walk / nowalk / rape / norape had no rights test (the four modes above test in Admin::setMode*)
	  %mode = getWord(%opt, 1);
	  if((%mode == "walk" || %mode == "nowalk" || %mode == "rape" || %mode == "norape") && !%clientId.AdminGeneral)
	  {
		 Game::menuRequest(%clientId);
		 return;
	  }
	  if(getWord(%opt, 1) == "tournament")
		 Admin::setModeTourney(%clientId);
	  if(getWord(%opt, 1) == "ffa")
		 Admin::setModeFFA(%clientId);
	  if(getWord(%opt, 1) == "league")
		 Admin::setModeLeague(%clientId);
	  if(getWord(%opt, 1) == "leaguena")
		 Admin::setModeLeagueNoRef(%clientId);
	  if(getWord(%opt, 1) == "walk")
	  {
		 $bwadmin::walk = true;
		 messageAll(0, "'Long Walk Home' ENABLED by " @ Client::getName(%clientId) @ ".");
		 AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled long walk home mode",%clientId);
	  }
	  if(getWord(%opt, 1) == "nowalk")
	  {
		 $bwadmin::walk = "";
		 messageAll(0, "'Long Walk Home' DISABLED by " @ Client::getName(%clientId) @ ".");
		 AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled long walk home mode",%clientId);
	  }
	  if(getWord(%opt, 1) == "rape")
	  {
		 $bwadmin::noRape = "";
		 messageAll(0, "'No Base Rape' DISABLED by " @ Client::getName(%clientId) @ ".");
		 AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled no base rape mode",%clientId);
	  }
	  if(getWord(%opt, 1) == "norape")
	  {
		 $bwadmin::noRape = true;
		 messageAll(0, "'No Base Rape' ENABLED by " @ Client::getName(%clientId) @ ".");
		 AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled no base rape mode",%clientId);
	  }
	  return;
   }
   Game::menuRequest(%clientId);
}


function processMenuselectPass(%clientId, %opt)
{
	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	%word = getWord(%opt, 1);
	if(%word == "0")
	{
		$server::password = "";
		bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Player Password Removed", 5);
		return;
	}
	else
	{
		$server::password = $bwadmin::Pass[%word];
		bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Password set to: " @ $server::password, 5);
		return;
	}
	Game::menuRequest(%clientId);
}

function processMenuMatchSet(%clientId, %opt)
{
   if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   if(%opt == score)
   {
	  %limit = $bwadmin::teamScoreLimit;
	  if(%limit == "")
		 %limit = "default";
	  if(%limit == "false")
		 %limit = "none";
	  Client::buildMenu(%clientId, "Choose Match Score Limit(" @ %limit @ ")", "cmsl", true);
	  Client::addMenuItem(%clientId, "0Default for Mission", "");
	  Client::addMenuItem(%clientId, "15 Points", 5);
	  Client::addMenuItem(%clientId, "28 Points", 8);
	  Client::addMenuItem(%clientId, "310 Points", 10);
	  Client::addMenuItem(%clientId, "415 Points", 15);
	  Client::addMenuItem(%clientId, "51000 Points", 1000);
	  Client::addMenuItem(%clientId, "62000 Points", 2000);
	  Client::addMenuItem(%clientId, "7No Score Limit", False);
	  return;
   }
   if(%opt == time)
   {
	  Client::buildMenu(%clientId, "Choose Match Time Limit(" @ $bwadmin::matchTimeLimit @ ")", "cmtl", true);
	  Client::addMenuItem(%clientId, "110 Minutes", 10);
	  Client::addMenuItem(%clientId, "215 Minutes", 15);
	  Client::addMenuItem(%clientId, "320 Minutes", 20);
	  Client::addMenuItem(%clientId, "425 Minutes", 25);
	  Client::addMenuItem(%clientId, "530 Minutes", 30);
	  Client::addMenuItem(%clientId, "645 Minutes", 45);
	  Client::addMenuItem(%clientId, "760 Minutes", 60);
	  Client::addMenuItem(%clientId, "8No Time Limit", 0);
	  return;
   }
   if(%opt == swap)
   {
	  if(!$bwadmin::teamSwap)
	  {
		 $bwadmin::teamSwap = true;
		 messageAll(0, Client::getName(%clientId) @ " set Team Swap to ON.");
		 return;
	  }
	  else
	  {
		 $bwadmin::teamSwap = "";
		 messageAll(0, Client::getName(%clientId) @ " set Team Swap to OFF.");
		 return;
	  }
   }
   if(%opt == leaguemission)
   {
		Admin::changeMissionMenu(%clientId, "league", "true");
   }
   if(%opt == ecskin)
   {
		$bwadmin::allowCustomSkinsLeague = "true";
	   	Client::sendMessage(%clientId, 1, "Custom Skins in League Match ENABLED");
	   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") ENABLED custom skins in league match");
	   	return;
   }
   if(%opt == dcskin)
   {
		$bwadmin::allowCustomSkinsLeague = "false";
	   	Client::sendMessage(%clientId, 1, "Custom Skins in League Match DISABLED");
	   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") DISABLED custom skins in league match");
	   	return;
   }
   if(%opt == name)
   {
	  Client::buildMenu(%clientId, "Choose League Name", "cln", true);
	  Client::addMenuItem(%clientId, "1BarrysWorld Tribes League", "BarrysWorld Tribes League");
	  Client::addMenuItem(%clientId, "2European Tribes League", "European Tribes League");
	  Client::addMenuItem(%clientId, "3Multiplay Tribes League", "Multiplay Tribes League");
	  Client::addMenuItem(%clientId, "4AGL Tribes League", "Anzac Gamers League");
	  Client::addMenuItem(%clientId, "5Tribes League", "Tribes League");
	  Client::addMenuItem(%clientId, "6Tribes Ladder", "Tribes Ladder");
	  return;
   }
}

function processMenucrdfactor(%clientId, %option)
{
	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	%value = getWord(%option, 0);
	%opt = getWord(%option, 1);

	if (%opt == "pa")
	{
		%type = "player attacker";
		$bwadmin::PlayerAttackerRevFactor = %value;
	}
	else if (%opt == "pv")
	{
		%type = "player victim";
		$bwadmin::PlayerVictimRevFactor = %value;
	}
	else if (%opt == "va")
	{
		%type = "vehicle attacker";
		$bwadmin::VehicleAttackerRevFactor = %value;
	}
	else if (%opt == "vv")
	{
		%type = "vehicle victim";
		$bwadmin::VehicleVictimRevFactor = %value;
	}
	else if (%opt == "da")
	{
		%type = "deployable attacker";
		$bwadmin::DeployableAttackerRevFactor = %value;
	}
	else if (%opt == "dv")
	{
		%type = "deployable victim";
		$bwadmin::DeployableVictimRevFactor = %value;
	}
   	Client::sendMessage(%clientId, 1, "Reverse damage " @ %type @ " factor set to " @ %value);
   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") set reverse damage " @ %type @ " factor to " @ %value,%clientId);
   	Game::menuRequest(%clientId);
}


function processMenuCln(%clientId, %opt)
{
   if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   $bwadmin::league = %opt;
   bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>League Name set to: <f1>" @ %opt, 5);
}


function processMenuCSLimit(%clientId, %opt)
{
	  remoteSetScoreLimit(%clientId, %opt);
}

function processMenuCmsl(%clientId, %opt)
{
   if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   if($bwadmin::teamScoreLimit == %opt)
	  return;
   $bwadmin::teamScoreLimit = %opt;
   %limit = $bwadmin::teamScoreLimit;
   if(%limit == "")
	  %limit = "Mission Default";
   if(%limit == "false")
	  %limit = "No Score Limit";
   bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Default Match Score Limit set to: " @ %limit, 5);
}

function processMenuCmtl(%clientId, %opt)
{
   if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   if($bwadmin::matchTimeLimit == %opt)
	  return;
   $bwadmin::matchTimeLimit = %opt;
   %limit = $bwadmin::matchTimeLimit;
   bottomprint(%clientID, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Default Match Time Limit set to: " @ $bwadmin::matchTimeLimit, 5);
}

function processMenucpingmin(%clientId, %opt)
{
	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	$bwadmin::PingAbove = %opt;
	if($bwadmin::PingAbove)
		%display = $bwadmin::PingAbove;
	else
		%display = "Disabled";
	bottomprint(%clientId, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Server Minium allowable ping set to: " @ %display, 5);
   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") set minimum allowable ping to " @ %display,%clientId);
}

function processMenucejecttime(%clientId, %opt)
{
	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	$bwadmin::StationTime = %opt;
	if($bwadmin::StationTime)
		%display = $bwadmin::StationTime;
	else
		%display = "Disabled";
	bottomprint(%clientId, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Station Eject Time set to: " @ %display, 5);
   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") set station eject time to " @ %display,%clientId);
}

function processMenucoobkill(%clientId, %opt)
{
	if(!%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
	{
		Game::menuRequest(%clientId);
		return;
	}
	$bwadmin::OutOfBoundsTime = %opt;
	if($bwadmin::OutOfBoundsTime)
		%display = $bwadmin::OutOfBoundsTime;
	else
		%display = "Disabled";
	bottomprint(%clientId, "<jc><f1>BWAdmin Server Setting Information:\n\n<f0>Out of Bounds Kill Time set to: " @ %display, 5);
   	AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") set out of bounds kill time to " @ %display,%clientId);
}

function processMenuCTeamEnergy(%clientId, %opt)
{
   remoteSetTeamEnergy(%clientId, %opt);
}

function processMenuselectdivision(%clientId, %opt)
{
   if(!%clientId.AdminReferee && !%clientId.AdminServerSettings) // PORT: the menu only lists this for that right; the menu code is client-supplied
   {
   	Game::menuRequest(%clientId);
   	return;
   }
   $bwadmin::teamNumber = %opt;
   %curItem = 0;
   if(%opt != "")
   {
	  Client::BuildMenu(%clientId, "Choose Category:", "selecttribe", true);
	  if($bwadmin::numberOfD1Tribes > 0)
	  	Client::addMenuItem(%clientId, %curItem++ @ "Base Tribes", "d1 1");
	  if($bwadmin::numberOfD2Tribes > 0)
	  	Client::addMenuItem(%clientId, %curItem++ @ "Tribes A-D", "d2 1");
	  if($bwadmin::numberOfD3Tribes > 0)
	  	Client::addMenuItem(%clientId, %curItem++ @ "Tribes E-L", "d3 1");
	  if($bwadmin::numberOfD4Tribes > 0)
	  	Client::addMenuItem(%clientId, %curItem++ @ "Tribes M-S", "d4 1");
	  if($bwadmin::numberOfD5Tribes > 0)
	  	Client::addMenuItem(%clientId, %curItem++ @ "Tribes T-Z", "d5 1");
	  return;
   }
   Game::menuRequest(%clientId);
}

function processMenuselecttribe(%clientId, %opt)
{
	%first = getWord(%opt, 1);
	if(getWord(%opt, 0) == "d1")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($bwadmin::numberOfD1Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
				 Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d1 " @ %p);
				 break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::d1Tribe[%p], "1 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d2")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($bwadmin::numberOfD2Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
				 Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d2 " @ %p);
				 break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::d2Tribe[%p], "2 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d3")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($bwadmin::numberOfD3Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
				 Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d3 " @ %p);
				 break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::d3Tribe[%p], "3 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d4")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($bwadmin::numberOfD4Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
				 Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d4 " @ %p);
				 break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::d4Tribe[%p], "4 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d5")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($bwadmin::numberOfD5Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
				 Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d5 " @ %p);
				 break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $bwadmin::d5Tribe[%p], "5 " @ %p);
		}
	return;
	}
	Game::menuRequest(%clientId);
}

function processMenuchangetribe(%clientId, %opt)
{
	%word = getWord(%opt, 1);
	if(getWord(%opt, 0) == "d1")
	{
		processMenuselecttribe(%clientId, "d1 " @ %word);
		return;
	}
	if(getWord(%opt, 0) == "d2")
	{
		processMenuselecttribe(%clientId, "d2 " @ %word);
		return;
	}
	if(getWord(%opt, 0) == "d3")
	{
		processMenuselecttribe(%clientId, "d3 " @ %word);
		return;
	}
	if(getWord(%opt, 0) == "d4")
	{
		processMenuselecttribe(%clientId, "d4 " @ %word);
		return;
	}
	if(getWord(%opt, 0) == "d5")
	{
		processMenuselecttribe(%clientId, "d5 " @ %word);
		return;
	}
	if(getWord(%opt, 0) == "1")
	{
		if($bwadmin::allowCustomSkins && ($bwadmin::d1TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d1Tribe[%word], $bwadmin::d1TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d1Tribe[%word], $bwadmin::defaultTribeSkin[$bwadmin::teamNumber]);
	}
	else if(getWord(%opt, 0) == "2")
	{
		if($bwadmin::allowCustomSkins && ($bwadmin::d2TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d2Tribe[%word], $bwadmin::d2TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d2Tribe[%word], $bwadmin::defaultTribeSkin[$bwadmin::teamNumber]);
	}
	else if(getWord(%opt, 0) == "3")
	{
		if($bwadmin::allowCustomSkins && ($bwadmin::d3TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d3Tribe[%word], $bwadmin::d3TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d3Tribe[%word], $bwadmin::defaultTribeSkin[$bwadmin::teamNumber]);
	}
	else if(getWord(%opt, 0) == "4")
	{
		if($bwadmin::allowCustomSkins && ($bwadmin::d4TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d4Tribe[%word], $bwadmin::d4TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d4Tribe[%word], $bwadmin::defaultTribeSkin[$bwadmin::teamNumber]);
	}
	else if(getWord(%opt, 0) == "5")
	{
		if($bwadmin::allowCustomSkins && ($bwadmin::d5TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d5Tribe[%word], $bwadmin::d5TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $bwadmin::teamNumber, $bwadmin::d5Tribe[%word], $bwadmin::defaultTribeSkin[$bwadmin::teamNumber]);
	}
	Game::menuRequest(%clientId);

}


// - BW Admin Mod - End


//---BW Anti TK Code -- Wizard_TPG
function BWAdmin_setTeamKill(%victimclientId, %killerclientId)
{
	echo("BWAdmin - ",Client::getName(%killerclientId)," (",%killerclientId,") team killed ",Client::getName(%victimclientId)," (",%victimclientId,")");
	%currentmissiontime = getSimTime();
	%tktoallocate = true;
	if(($bwadmin::TKFrequency == "") || ($bwadmin::TKFrequency == 0))
		$bwadmin::TKFrequency = 180;

	for(%i = 1; %i < $bwadmin::PurgatoryTK+1; %i++)
		if((%currentmissiontime - %killerclientId.tktime[%i]) > $bwadmin::TKFrequency)
			%killerclientId.tktime[%i] = 0;
	for(%i = 1; %i < $bwadmin::PurgatoryTK+1; %i++)
	{
		if(%killerclientId.tktime[%i])
			%tknumber++;
		if((!%killerclientId.tktime[%i]) && (%tktoallocate))
		{
			%killerclientId.tktime[%i] = %currentmissiontime;
			%tknumber++;
			%tktoallocate = false;
		}
	}
	if(($bwadmin::PunishmentTime == "") || ($bwadmin::PunishmentTime <= 0))
		$bwadmin::PunishmentTime = 300;
	if($bwadmin::ReverseDamageTK != "" && $bwadmin::ReverseDamageTK != 0)
	{
		if(%tknumber >= $bwadmin::ReverseDamageTK)
		{
				if(%killerclientId.rd)
					Client::sendMessage(%killerclientId, 0,"Reverse Damage Mode is reset and active for another " @ $bwadmin::PunishmentTime @ " seconds.");
				else
					Client::sendMessage(%killerclientId, 0,"You are now on Reverse Damage Mode for Team Killing for " @ $bwadmin::PunishmentTime @ " seconds.");
				%killerclientId.rd = true;
				%killerclientId.rdtime = %currentmissiontime + $bwadmin::PunishmentTime;
		}
	}
	if($bwadmin::PurgatoryTK != "" && $bwadmin::PurgatoryTK != 0)
	{
		if(%tknumber >= $bwadmin::PurgatoryTK)
		{
			%killerclientId.rd = false;
			%killerclientId.rdtime = 0;
			%ip = Client::getTransportAddress(%killerclientId);
			Admin::PurgMode(%killerclientId,true,%ip,0);
		}
	}
	if($bwadmin::KickTK != "" && $bwadmin::KickTK != 0)
	{
		if(%tknumber >= $bwadmin::KickTK)
		{
			%killerclientId.rd = false;
			%killerclientId.rdtime = 0;
			%ip = Client::getTransportAddress(%killerclientId);
			Admin::kick(-2, %killerclientId);
		}
	}
}


function BWAdmin_ResetTKCount(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	%clientId.rd = false;
	%clientId.rdtime = 0;
	for(%i = 1; %i <= $bwadmin::PurgatoryTK; %i++)
		%clientId.tktime[%i] = 0;
	%clientId.purgatory = false;
	BanList::remove(%ip);
}

function BWAdmin_CheckPenaltyStatus(%cl)
{
	%rdtimeleft = %cl.rdtime - GetSimTime();
	if((%cl.rd) && (%rdtimeleft < 0))
	{
		%cl.rd = false;
		%cl.rdtime = 0;
		Client::sendMessage(%cl, 0,"Reverse Damage Mode has been disabled");
	}
	%purgtimeleft = %cl.purgtime - GetSimTime();
	if((%cl.purgatory) && (%purgtimeleft < 0))
	{
		%ip = Client::getTransportAddress(%cl);
		Admin::PurgMode(%cl,false,%ip, 0);
	}
}

function Admin::ReverseDamage(%this,%type,%reversevalue,%pos,%vec,%mom,%vertPos,%quadrant)
{
	%playerId = Client::getOwnedObject(%this);
	%dlevel = GameBase::getDamageLevel(%playerId) + %reversevalue;
	%armor = Player::getArmor(%playerId);
	%spillOver = %dlevel - %armor.maxDamage;
	GameBase::setDamageLevel(%playerId,%dlevel);
	%flash = Player::getDamageFlash(%this) + %reversevalue * 2;
	if (%flash > 0.75)
		%flash = 0.75;
	Player::setDamageFlash(%this,%flash);
	//If player not dead then play a random hurt sound
	if(!Player::isDead(%playerId))
	{
		if(%damagedClient.lastDamage < getSimTime())
		{
			%sound = radnomItems(3,injure1,injure2,injure3);
			playVoice(%damagedClient,%sound);
			%damagedClient.lastdamage = getSimTime() + 1.5;
		}
	}
	else
	{
		if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType)))
		{
			Player::trigger(%playerId, $WeaponSlot, false);
			%weaponType = Player::getMountedItem(%playerId,$WeaponSlot);
			if(%weaponType != -1)
				Player::dropItem(%playerId,%weaponType);
			if (%type == $MagneticDamageType)
				playSound(ShockExplosion,GameBase::getPosition(%playerId));
				Player::blowUp(%playerId);
		}
		else
		{
			if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%playerId) > 6) )
			{
				if(%quadrant == "front_left" || %quadrant == "front_right")
					%curDie = $PlayerAnim::DieBlownBack;
				else
					%curDie = $PlayerAnim::DieForward;
			}
			else if( Player::isCrouching(%playerId) )
				%curDie = $PlayerAnim::Crouching;
			else if(%vertPos=="head")
			{
				if(%quadrant == "front_left" || %quadrant == "front_right"	)
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
				else
					%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
			}
			else if (%vertPos == "torso")
			{
				if(%quadrant == "front_left" )
					%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "front_right")
					%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
				else if(%quadrant == "back_left" )
					%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
				else if(%quadrant == "back_right")
					%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
			}
			else if (%vertPos == "legs")
			{
				if(%quadrant == "front_left" ||	%quadrant == "back_left")
					%curDie = $PlayerAnim::DieLegLeft;
				if(%quadrant == "front_right" ||	%quadrant == "back_right")
						%curDie = $PlayerAnim::DieLegRight;
			}
			Player::setAnimation(%playerId, %curDie);
		}
		%type = -2;
		%damagedClient = Player::getClient(%playerId);
		%shooterClient = Player::getClient(%playerId);
		Client::onKilled(%damagedClient,%shooterClient, %type);
	}
}


function Admin::PurgMode(%clientId,%enable,%ip,%adminCl)
{
	//ban client even if they dropped mid vote.
	if(Client::getName(%clientId) == "")
	{
		BanList::add($CurrentVoteObjectIP, $bwadmin::KickBanTime);
		$CurrentVoteObjectIP = "";
	}

	if((!%clientId.AdminIsImmune) && (%clientId != %adminCl))
	{
		if(($bwadmin::PunishmentTime == "") || ($bwadmin::PunishmentTime <= 0))
			$bwadmin::PunishmentTime = 300;
		if(%enable)
		{
			//put client in purgatory
			if(%clientId.purgatory != true)
			{
				%clientId.purgatory = true;
				%clientId.purgtime = GetSimTime() + $bwadmin::PunishmentTime;
				BanList::add(%ip, $bwadmin::PunishmentTime);
				processMenuPickTeam(%clientId, -2, %adminCl);
				schedule("Admin::PurgMode(" @ %clientId @ ",false,\"" @ %ip @ "\", 0);",$bwadmin::PunishmentTime);
				if(%adminCl == 0)
				{
					Messageall(0, Client::getName(%clientId) @ " has been sent to Purgatory for " @ $bwadmin::PunishmentTime @ " seconds.");
					echo("BWAdmin - ",Client::getName(%clientId)," (",%clientId,") has been sent to Purgatory");
				}
				else
				{
					Messageall(0, Client::getName(%clientId) @ " has been sent to Purgatory by " @ Client::getName(%adminCl) @ " for " @ $bwadmin::PunishmentTime @ " seconds.");
					AdminAction(Client::getName(%adminCl) @ " (" @ %adminCl @ ") sent " @ Client::getName(%clientId) @ " (",%clientId,") to purgatory",%adminCl,%clientId);
				}
			}
		}
		else
		{
			%clientId.purgatory = false;
			BanList::remove(%ip);
			centerprint(%clientId,"<f1><jc>Your time in purgatory is over. You may now rejoin the game.", 10);
			Client::sendMessage(%clientId, 0, "~wshell_click.wav");
			Messageall(0, Client::getName(%clientId) @ " is now free to leave Purgatory.");
			if(%adminCl == 0)
			{
				Messageall(0, Client::getName(%clientId) @ " has completed the Purgatory time.");
				echo("BWAdmin - ",Client::getName(%clientId)," (",%clientId,") has been released from Purgatory");
			}
			else
			{
				Messageall(0, Client::getName(%clientId) @ " has been returned from Purgatory by " @ Client::getName(%adminCl) @ ".");
				echo("BWAdmin - ",Client::getName(%clientId)," (",%clientId,") has been released from Purgatory by", Client::getName(%adminCl),"(",%adminCl,")");
			}
		}
	}
}




//=============================================================
//-------- BWAdmin Userlist --  Wizard_TPG

exec(BWUserList);

// Used on Client Connect.
function BWAdmin_Authenticate(%clientId, %ip)
{
	if($UserList::Activated)
	{
		%clientId.ip = %ip;
		%name = Client::getName(%clientId);
		%clientId.usernumber = 0;
		for(%i=1;%i < $UserList::MaxUsers+1;%i++)
		{
			if((%name == $UserList::UserName[%i]) || (%name == $UserList::UserName[%i] @ ".1"))
			{
				if((%clientId.usernumber==0) && ($UserList::UserIP1[%i] != ""))
					if(BWAdminCompareIP($UserList::UserIP1[%i],%ip))
						%clientId.usernumber = %i;
				if((%clientId.usernumber==0) && ($UserList::UserIP2[%i] != ""))
					if(BWAdminCompareIP($UserList::UserIP2[%i],%ip))
						%clientId.usernumber = %i;
				if((%clientId.usernumber==0) && ($UserList::UserIP3[%i] != ""))
					if(BWAdminCompareIP($UserList::UserIP3[%i],%ip))
						%clientId.usernumber = %i;
			}
		}
		if(%clientId.usernumber)
		{
			%clientId.UserLevel = $UserList::UserLevel[%clientId.usernumber];
			%clientId.UserIP1 = $UserList::UserIP1[%clientId.usernumber];
			%clientId.UserIP2 = $UserList::UserIP2[%clientId.usernumber];
			%clientId.UserIP3 = $UserList::UserIP3[%clientId.usernumber];
			echo("BWAdmin: User: ",%name," Identified. Access Level: ",$UserList::UserLevel[%clientId.usernumber]);
			BWAdminMsg("User: " @ %name @ " Identified. Access Level: " @ $UserList::UserLevel[%clientId.usernumber]);

			for(%i = 1; %i < $UserList::MaxClasses+1; %i++)
				if($UserList::AdminName[%i] == %clientId.UserLevel)
					if($Userlist::AdminAutoLogin[%i] == true)
					{
						BWAdminSetClientAdmin(%clientId);
						BWAdminMsg(%name @ " Automatically Logged in.");
					}
		}
		else
		{
			%clientId.UserLevel = 0;
			echo("BWAdmin: User: ",%name," Unknown.");
		}
	}
	else
		%clientId.usernumber = 0;
}

function BWAdminTruncateIP(%ip)
{
	%currentstring = String::getSubStr(%ip,3,16);
	for(%i = 7; %i < BWStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = BWStrLen(%currentstring)+1;
		}
	}
	return %currentipstring;
}

function BWAdminCompareIP(%userlistip,%currentip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%currentip,3,16);
	for(%i = 7; %i < BWStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = BWStrLen(%currentstring)+1;
		}
	}
	//convert currentip into 4 variables
	%currentipspace = BWDotToSpace(%currentipstring);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	//convert userlistip into 4 variables
	%userlistipspace = BWDotToSpace(%userlistip);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%userip[%argnum] = getWord(%userlistipspace, %argnum-1);
	}
	//Compare variables
	%result = true;
	for(%i = 1; %i < 5; %i++)
	{
		if(%userip[%i] != "*")
			if(%currip[%i] != %userip[%i])
				%result = false;
	}
	return %result;
}

function BWDotToSpace(%string)
{
	%x = 0;
	%i = 0;
	while(%x<3)
	{
		%char = String::getSubStr(%string,%i,1);
		if(!String::ICompare(%char, "."))		{
			%left = String::getSubStr(%string,0,%i);
			%right = String::getSubStr(%string,%i+1,(BWStrLen(%string)-%i));
			%string = strcat(%left," ",%right);
			%x++;
		}
		%i++;
	}
	return %string;
}

function BWStrLen(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
		%length = %i;
	%length++;
	return %length;
}

function BWAdminSetClientAdmin(%clientId)
{
	for(%i = 1; %i < $UserList::MaxClasses+1; %i++)
		if($UserList::AdminName[%i] == %clientId.UserLevel)
			%adminlevel = %i;
	if($UserList::AdminIsImmune[%adminlevel] == true)
	{
		%clientId.AdminIsImmune = true;
		%clientId.purgatory = false;
	}
	if($UserList::AdminGeneral[%adminlevel] == true)
		%clientId.AdminGeneral = true;
	if($UserList::AdminServerSettings[%adminlevel] == true)
		%clientId.AdminServerSettings = true;
	if($UserList::AdminCanAdminPlayer[%adminlevel] == true)
		%clientId.AdminCanAdminPlayer = true;
	if($UserList::AdminReferee[%adminlevel] == true)
		%clientId.AdminReferee = true;
	%clientId.AdminVerified = true;
}

function BWAdminGroupAdmin(%password,%clientId)
{
	for(%i = 1; %i < $UserList::MaxGroups+1; %i++)
	{
		if(%password != "" && $UserList::GroupPass[%i] == %password) // PORT: as in remoteAdminPassword
		{
			for(%j = 1; %j < $UserList::MaxClasses+1; %j++)
				if($UserList::AdminName[%j] == $UserList::GroupLevel[%i])
					%adminlevel = %j;
			if($UserList::AdminIsImmune[%adminlevel] == true)
			{
				%clientId.AdminIsImmune = true;
				%clientId.purgatory = false;
			}
			if($UserList::AdminGeneral[%adminlevel] == true)
				%clientId.AdminGeneral = true;
			if($UserList::AdminServerSettings[%adminlevel] == true)
				%clientId.AdminServerSettings = true;
			if($UserList::AdminCanAdminPlayer[%adminlevel] == true)
				%clientId.AdminCanAdminPlayer = true;
			if($UserList::AdminReferee[%adminlevel] == true)
				%clientId.AdminReferee = true;
			%clientId.AdminVerified = false;
			Client::sendMessage(%clientId, 1,"BWAdmin: You have logged in successfully as a group level " @ $UserList::GroupLevel[%i]);
			BWAdminMsg(Client::getName(%clientId) @ " Logged in as a group level " @ $UserList::GroupLevel[%i]);
		}
	}
}

function BWAdmin_QuickDisconnect(%clientId, %fullip)
{
	%ip = BWAdminTruncateIP(%fullip);
	if($DisconnectAdminData[%ip,AdminGeneral])
	{
		%clientId.AdminGeneral = true;
		if($DisconnectAdminData[%ip,AdminIsImmune])
			%clientId.AdminIsImmune = true;
		if($DisconnectAdminData[%ip,AdminServerSettings])
			%clientId.AdminServerSettings = true;
		if($DisconnectAdminData[%ip,AdminCanAdminPlayer])
			%clientId.AdminCanAdminPlayer = true;
		if($DisconnectAdminData[%ip,AdminReferee])
			%clientId.AdminReferee = true;
		if($DisconnectAdminData[%ip,AdminVerified])
			%clientId.AdminVerified = true;
		%name = Client::getName(%clientId);
		echo("BWAdmin: User: ",%name," identified as reconnecting admin.");
		BWAdminMsg("User: " @ %name @ " identified as reconnecting admin.");
	}
}

function BWAdminResetDisconnectData(%ip)
{
	$DisconnectAdminData[%ip,AdminGeneral] = false;
	$DisconnectAdminData[%ip,AdminIsImmune] = false;
	$DisconnectAdminData[%ip,AdminServerSettings] = false;
	$DisconnectAdminData[%ip,AdminCanAdminPlayer] = false;
	$DisconnectAdminData[%ip,AdminReferee] = false;
	$DisconnectAdminData[%ip,AdminVerified] = false;
}


// Msg All Admins on Server.
function BWAdminMsg(%msg,%client)
{
	if(!%client.HiddenSmurf)
	{
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
			%pl = getClientByIndex(%i);
			if(%pl.isAdmin)
					Client::sendMessage(%pl, 0, "BWAdmin: " @ %msg);
		}
	}
}


//==================== NAME BAN ======================== Wizard_TPG

if($bwadmin::EnableNameBan == "true")
{
	exec(BWNameBan);
}

function BWAdmin_NameBanCheck(%clientId, %ip)
{
	%name = Client::getName(%clientId);
	%match = false;
	for(%i=1;%i<$bwadmin::MaxBanStrings+1;%i++)
	{
		if(String::FindSubStr(%name,$bwadmin::NameBanString[%i,string]) != -1)
		{
			%match = true;
			%matchnum = %i;
			%i = $bwadmin::MaxBanStrings+1;
		}
	}
	if(%match)
	{
		%message = $bwadmin::NameBanString[%matchnum,message];
		%bantime = $bwadmin::NameBanString[%matchnum,bantime];
		schedule("centerprint(" @ %clientId @ ", " @ %message @ ", 5," @ %clientId @ ");",0.1);
		schedule("centerprint(" @ %clientId @ ", " @ %message @ ", 5," @ %clientId @ ");",5);
		schedule("centerprint(" @ %clientId @ ", " @ %message @ ", 5," @ %clientId @ ");",10);
		schedule("centerprint(" @ %clientId @ ", " @ %message @ ", 5," @ %clientId @ ");",15);
		schedule("BWAdmin_BanPlayer("@%clientid@",\""@%message@"\","@%bantime@");",20);
	}
}

function BWAdmin_BanPlayer(%clientid, %message, %bantime)
{
		%ip = Client::getTransportAddress(%clientId);
		Net::kick(%clientId, %message);
		BanList::add(%ip, %bantime);
}


//==================== IP BAN ======================== Wizard_TPG

function BWAdmin::AddIPBan(%ip)
{
	$bwadmin::IPBanMax++;
	$bwadmin::banlistip[$bwadmin::IPBanMax] = %ip;
}

function BWAdmin_IPBanCheck(%clientId, %clientip)
{
	if($bwadmin::IPBanMax > 0)
	{
		for(%i=1;%i<=$bwadmin::IPBanMax;%i++)
		{
			%result = BWAdminCompareIP($bwadmin::banlistip[%i],%clientip);
			if(%result)
			{
				BWAdmin_IPBanPlayer(%clientId);
				%i = $bwadmin::IPBanMax + 1;
			}
		}
	}
}

function BWAdmin_IPBanPlayer(%clientid)
{
	%ip = Client::getTransportAddress(%clientId);
	Net::kick(%clientId, "Your IP has been banned from this server.");
	BanList::add(%ip, 30000000);
}

if($bwadmin::EnableIPBan == "true")
{
	exec(BWIPBan);
}


//==================== ADMIN LOG ======================= Wizard_TPG

function AdminAction(%message,%admin,%cl)
{
	if(%client != -1)
	{
		if($bwadmin::adminlogip == "true")
		{
			if(%admin != -1)
			{
				%fulladminip = Client::getTransportAddress(%admin);
				%adminip = BWAdminTruncateIP(%fulladminip);
				%message = %message @ " |Admin IP = " @  %adminip @ "|";
				if(%cl != -1)
				{
					%fullclip = Client::getTransportAddress(%cl);
					%clip = BWAdminTruncateIP(%fullclip);
					%message = %message @ " |Client IP = " @  %clip @ "|";
				}
			}
		}
		if($bwadmin::adminlog == 2)
		{
			$DataFile = "config\\BWAdminLog" @ $Server::Port @ ".cs";
			$bwadmin::adminmsg = %message;
			export("bwadmin::adminmsg", $DataFile, True);
		}
		else if($bwadmin::adminlog == 1)
		{
			echo("BWADMIN: ",%message);
		}
		else if($bwadmin::adminlog == 3)
		{
			$DataFile = "config\\BWAdminLog" @ $Server::Port @ ".cs";
			$bwadmin::adminmsg = %message;
			export("bwadmin::adminmsg", $DataFile, True);
			echo("BWADMIN: ",%message);
		}
	}
}


//==================== SMURF HUNTER ======================= Wizard_TPG
function LoadSmurfRecord()
{
	%SmurfLogFile = "SmurfLog" @ $Server::Port @ ".cs";
	exec(%SmurfLogFile);
	%smurfcount = 2;
	for(%i=1;%i < %smurfcount;%i++)
	{
		if($SmurfRecord[%i,0] != "")
		{
			%smurfcount++;
		}
	}
	$SmurfCount = %smurfcount - 2;
}

function AddSmurfRecord(%name,%ip)
{
	BWAdminSmurfTimer(false);
	if(!String::NCompare(%ip, "LOOPBACK", 8))
	{
		//Ignore Loopback dude
	}
	else
	{
		%rawip = BWAdminConvertIP(%ip);

		//If Current User already exists replace & update data
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] == %name)
			{
				%currentid = %i;
				%i = %counter + 1;
			}
			else if($CurrentSmurfRecord[%i,0] == "")
			{
				%currentid = %i;
				%i = %counter + 1;
			}
		}
		$CurrentSmurfRecord[%currentid,0] = %name;
		$CurrentSmurfRecord[%currentid,1] = %rawip;
		$CurrentSmurfRecord[%currentid,2] = $Gametimersixth+6;

		//Compare Other Current Smurfs and add to record if match
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] != "")
			{
				if(CompareSmurfRecords(%currentid, %ip, %i))
				{
					AddNewSmurfMatch(%currentid, %i);
					%i = %counter + 1;
				}
			}
			else
			{
				%i = %counter + 1;
			}
		}
	}
}

function AddNewSmurfMatch(%currentid, %match)
{
	//If Smurf User does not exist then add them
	%name = $CurrentSmurfRecord[%currentid,0];
	%foundname = false;
	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%foundname = true;
			%userid = %i;
			%i = $SmurfCount + 1;
		}
	}
	if(!%foundname)
	{
		$SmurfCount = $SmurfCount + 1;
		%userid = $SmurfCount;
		$SmurfRecord[%userid,0] = %name;
	}

	//If Smurf Match does not exist then add them
	%name = $CurrentSmurfRecord[%match,0];
	%foundname = false;
	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%foundname = true;
			%usermatchid = %i;
			%i = $SmurfCount + 1;
		}
	}
	if(!%foundname)
	{
		$SmurfCount = $SmurfCount + 1;
		%usermatchid = $SmurfCount;
		$SmurfRecord[%usermatchid,0] = %name;
	}

	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%usermatchid = %i;
			if(!CompareKnownSmurfs(%userid, %usermatchid))
			{
				//Add all smurf ids to userid
				if($SmurfRecord[%userid,1] == "" && $SmurfRecord[%usermatchid,1] == "")
					$SmurfRecord[%userid,1] = %usermatchid;
				else if($SmurfRecord[%userid,1] == "" && $SmurfRecord[%usermatchid,1] != "")
					$SmurfRecord[%userid,1] = $SmurfRecord[%usermatchid,1] @ " " @ %usermatchid;
				else
					$SmurfRecord[%userid,1] = $SmurfRecord[%userid,1] @ " " @ %usermatchid;

				//Add userid to matched user
				if($SmurfRecord[%usermatchid,1] == "" && $SmurfRecord[%userid,1] == "")
				{
					%adduserid = %userid;
					$SmurfRecord[%usermatchid,1] = %userid;
				}
				else if($SmurfRecord[%usermatchid,1] != "" && $SmurfRecord[%userid,1] != "")
				{
					$SmurfRecord[%usermatchid,1] = $SmurfRecord[%usermatchid,1] @ " " @ %userid;
					%adduserid = %userid;
				}
				else
				{
					%adduserid = %usermatchid;
					$SmurfRecord[%usermatchid,1] = %userid;
					%count = 1;
					for(%j=0;%j < %count;%j++)
					{
						%count++;
						if((getWord($SmurfRecord[%userid,1],%j) != "") && (getWord($SmurfRecord[%userid,1],%j) != -1))
						{
							if(getWord($SmurfRecord[%userid,1],%j) != %usermatchid)
								$SmurfRecord[%usermatchid,1] = $SmurfRecord[%usermatchid,1] @ " " @ getWord($SmurfRecord[%userid,1],%j);
						}
						else
							%j = %count+1;
					}

				}


				//Add userid to all other smurf records
				%count = 1;
				for(%j=0;%j < %count;%j++)
				{
					%count++;
					if((getWord($SmurfRecord[%usermatchid,1],%j) != "") && (getWord($SmurfRecord[%usermatchid,1],%j) != -1))
					{
						if(getWord($SmurfRecord[%usermatchid,1],%j) != %userid)
							$SmurfRecord[getWord($SmurfRecord[%usermatchid,1],%j),1] = $SmurfRecord[getWord($SmurfRecord[%usermatchid,1],%j),1] @ " " @ %adduserid;
					}
					else
						%j = %count+1;
				}
			}
			%i = $SmurfCount + 1;
		}
	}
}

function CompareSmurfRecords(%Smurf1ID, %ip, %Smurf2ID)
{
	//This function returns the following data
	//	false = no match or same ID
	//	true = Exact IP Match

	%data = false;
	if(%Smurf1ID != %Smurf2ID)
	{
		%exactmatch = false;
		%count = 1;
		for(%i=0;%i < %count;%i++)
		{
			%count++;
			if((getWord($CurrentSmurfRecord[%Smurf2ID,1],%i) != "") && (getWord($CurrentSmurfRecord[%Smurf2ID,1],%i) != -1))
			{
				if(BWAdminCompareIP(getWord($CurrentSmurfRecord[%Smurf2ID,1],%i),%ip))
				{
					%exactmatch = true;
					%data = true;
					%i = %count+1;
				}
			}
			else
				%i = %count+1;
		}
	}
	return %data;
}

function CompareKnownSmurfs(%Smurf1ID, %Smurf2ID)
{
	//This function returns true if this is an existing known smurf
	%existing = false;
	%count = 1;
	for(%i=0;%i < %count;%i++)
	{
		%count++;
		if((getWord($SmurfRecord[%Smurf2ID,1],%i) != "") && (getWord($SmurfRecord[%Smurf2ID,1],%i) != -1))
		{
			if(getWord($SmurfRecord[%Smurf2ID,1],%i) == %Smurf1ID)
			{
				%existing = true;
				%i = %count+1;
			}
		}
		else
			%i = %count+1;
	}
	return %existing;
}

function RotateSmurfLog(%time)
{
	if($bwadmin::KeepSmurfLog == "true") // PORT: was =
	{
		//get number of smurfs in current list
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] == "")
			{
				%maxcurrent = %i-1;
				%i = %counter + 1;
			}
		}
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] != "")
			{
				if($CurrentSmurfRecord[%i,2] < %time)
				{
					if(%i != %maxcurrent)
					{
						$CurrentSmurfRecord[%i,2] = $CurrentSmurfRecord[%maxcurrent,2];
						$CurrentSmurfRecord[%i,1] = $CurrentSmurfRecord[%maxcurrent,1];
						$CurrentSmurfRecord[%i,0] = $CurrentSmurfRecord[%maxcurrent,0];
						$CurrentSmurfRecord[%maxcurrent,2] = "";
						$CurrentSmurfRecord[%maxcurrent,1] = "";
						$CurrentSmurfRecord[%maxcurrent,0] = "";
						%maxcurrent = %maxcurrent - 1;
					}
					else
					{
						$CurrentSmurfRecord[%i,2] = "";
						$CurrentSmurfRecord[%i,1] = "";
						$CurrentSmurfRecord[%i,0] = "";
					}
				}
			}
			else
				%i = %counter + 1;
		}
	}
}

function BackupSmurfRecord()
{
	if($SmurfRecord[1,0] != "")
	{
		$SmurfDataFile = "config\\SmurfLog" @ $Server::Port @ ".cs";
		export("SmurfRecord*", $SmurfDataFile, False);
		echo("BWAdmin: Smurf Record Log Saved");
	}
}

function DisplaySmurf(%adminId, %selectId)
{
	if($bwadmin::KeepSmurfLog == "true") // PORT: was =
	{
		if(((%adminId.AdminReferee) && ($bwadmin::AdminSmurfApp)) || (%adminId.AdminServerSettings) || (%adminId.SmurfKey))
		{
			//Find smurf userid
			%name = Client::getName(%selectId);
			for(%i=1;%i < $SmurfCount+1;%i++)
			{
				if($SmurfRecord[%i,0] == %name)
				{
					%userid = %i;
					%i = $SmurfCount+2;
				}
			}

			//Get known aliases
			if($SmurfRecord[%userid,1] == "")
			{
				%exactmatch = "  No Matches Found";
			}
			else
			{
				%count = 1;
				for(%i=0;%i < %count;%i++)
				{
					%count++;
					if((getWord($SmurfRecord[%userid,1],%i) != "") && (getWord($SmurfRecord[%userid,1],%i) != -1))
						if(%exactmatch == "")
							%exactmatch = $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
						else
							%exactmatch = %exactmatch @ " | " @ $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
					else
						%i = %count + 1;
				}
			}
			Client::sendMessage(%adminId, 1,Client::getName(%selectId) @ "'s possible aliases are:");
			Client::sendMessage(%adminId, 1,%exactmatch);
			echo(Client::getName(%selectId),"(",%selectId,") possible aliases are: ", %exactmatch);
		}
	}
}

function BWAdminConvertIP(%ip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%ip,3,16);
	for(%i = 7; %i < BWStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = BWStrLen(%currentstring)+1;
		}
	}
	%ip = %currentipstring;
	return %ip;
}

function TruncateIP(%rawip)
{
	%currentipspace = BWDotToSpace(%rawip);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	%rawip = %currip[1] @ "." @ %currip[2] @ "." @ %currip[3] @ ".*";
	return %rawip;
}

function BWAdminSmurfTimer(%repeat)
{
	if(($StartSmurfTimerRunning) || (%repeat))
	{
		$StartSmurfTimerRunning = false;
		$Gametimer = $Gametimer + 60;
		if($Gametimer >= 600)
		{
			$Gametimer = 0;
			$Gametimersixth++;
			RotateSmurfLog($Gametimersixth);
		}
		schedule("BWAdminSmurfTimer(true);",60);
	}
}

if($bwadmin::KeepSmurfLog == "true")
{
	$StartSmurfTimerRunning = true;
	LoadSmurfRecord();
	$SmurfInitialCheck = false;
}


function SCVMenu::menuRequest(%clientID)
{
	Client::buildMenu(%clientId, "Build:", "SCVBuild", true);

	Client::addMenuItem(%clientId, "1Heavy Turrets", "SCVTurret");
	Client::addMenuItem(%clientId, "2Turrets", "SCVSTurret");
	Client::addMenuItem(%clientId, "3Structures", "SCVStructure");
	Client::addMenuItem(%clientId, "4Sensors", "SCVSensor");
}


$SCVTurretList[1] = RemoteAutoCannon;
$SCVTurretList[2] = RemoteAACannon;
$SCVTurretList[3] = RemotePlasmaTurret;
$SCVTurretList[4] = MissileTurret;
$SCVTurretList[5] = MRL;
$SCVTurretList[6] = LongTom;
$SCVTurretList[7] = "";

$SCVSTurretList[1] = TurretPack;
$SCVSTurretList[2] = ChaingunTurret;
$SCVSTurretList[3] = LaserTurretPack;
$SCVSTurretList[4] = RemoteELF;
$SCVSTurretList[5] = "";

$SCVSensorList[1] = PulseSensorPack;
$SCVSensorList[2] = MotionSensorPack;
$SCVSensorList[3] = DeployableSensorJammerPack;
$SCVSensorList[4] = "";

$SCVStructureList[1] = Barricade;
$SCVStructureList[2] = FloatingPad;
$SCVStructureList[3] = VehicleBasePad;
$SCVStructureList[4] = VehicleBaseControl;
// $SCVStructureList[5] = PortInvPack;
$SCVStructureList[5] = "";


function processMenuSCVBuild(%clientId, %opt)
{
	%j = 0;

	if (%opt == "SCVTurret") {
		Client::buildMenu(%clientId, "Heavy Turrets:", "SCVTurrets", true);
		for (%i = 1; (%item = $SCVTurretList[%i]) != ""; %i++) {
			Client::addMenuItem(%clientId, %i @ %item.description, %i);
		}
	} else if (%opt == "SCVSTurret") {
		Client::buildMenu(%clientId, "Turrets:", "SCVSTurrets", true);
		for (%i = 1; (%item = $SCVSTurretList[%i]) != ""; %i++) {
			Client::addMenuItem(%clientId, %i @ %item.description, %i);
		}
	} else if (%opt == "SCVSensor") {
		Client::buildMenu(%clientId, "Turrets:", "SCVSensors", true);
		for (%i = 1; (%item = $SCVSensorList[%i]) != ""; %i++) {
			Client::addMenuItem(%clientId, %i @ %item.description, %i);
		}
	} else if (%opt == "SCVStructure") {
		Client::buildMenu(%clientId, "Structures:", "SCVStructures", true);
		for (%i = 1; (%item = $SCVStructureList[%i]) != ""; %i++) {
			Client::addMenuItem(%clientId, %i @ %item.description, %i);
		}
	}
}


function processMenuSCVTurrets(%client, %opt)
{
	%item = $SCVTurretList[%opt];
	%player = Client::getOwnedObject(%client);

	if($TeamItemMax[%item] != "") {						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) {
			centerprint(%client, "<jc>Maximum number of " @ %item.description @ "s deployed.");
			return 0;
		}
	}

	%pack = Player::getMountedItem(%client,$BackpackSlot);

	if(%pack != -1) {
		teamEnergyBuySell(%player,%pack.price);
		if(!Player::isDead(%player)) Player::decItemCount(%client,%pack);
	}			   

	if(checkResources(%player,%item,1) || $testCheats) {
		teamEnergyBuySell(%player,%item.price * -1);
		Player::incItemCount(%client,%item);
		Player::useItem(%client,%item);
		return 1;
	}

	if(%pack != -1) {
		// Buy the pack back
		teamEnergyBuySell(%player,%pack.price * -1);
		Player::incItemCount(%client,%pack);
		Player::useItem(%client,%pack);									 
		centerprint(%client, "<jc>Insufficient team energy to build object.");
		return 0;
	}				 

}


function processMenuSCVSTurrets(%client, %opt)
{
	%item = $SCVSTurretList[%opt];
	%player = Client::getOwnedObject(%client);

	if($TeamItemMax[%item] != "") {						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) {
			centerprint(%client, "<jc>Maximum number of " @ %item.description @ "s deployed.");
			return 0;
		}
	}

	%pack = Player::getMountedItem(%client,$BackpackSlot);

	if(%pack != -1) {
		teamEnergyBuySell(%player,%pack.price);
		if(!Player::isDead(%player)) Player::decItemCount(%client,%pack);
	}			   

	if(checkResources(%player,%item,1) || $testCheats) {
		teamEnergyBuySell(%player,%item.price * -1);
		Player::incItemCount(%client,%item);
		Player::useItem(%client,%item);
		return 1;
	}

	if(%pack != -1) {
		// Buy the pack back
		teamEnergyBuySell(%player,%pack.price * -1);
		Player::incItemCount(%client,%pack);
		Player::useItem(%client,%pack);									 
		centerprint(%client, "<jc>Insufficient team energy to build object.");
		return 0;
	}				 

}


function processMenuSCVSensors(%client, %opt)
{
	%item = $SCVSensorList[%opt];
	%player = Client::getOwnedObject(%client);

	if($TeamItemMax[%item] != "") {						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) {
			centerprint(%client, "<jc>Maximum number of " @ %item.description @ "s deployed.");
			return 0;
		}
	}

	%pack = Player::getMountedItem(%client,$BackpackSlot);

	if(%pack != -1) {
		teamEnergyBuySell(%player,%pack.price);
		if(!Player::isDead(%player)) Player::decItemCount(%client,%pack);
	}			   

	if(checkResources(%player,%item,1) || $testCheats) {
		teamEnergyBuySell(%player,%item.price * -1);
		Player::incItemCount(%client,%item);
		Player::useItem(%client,%item);
		return 1;
	}

	if(%pack != -1) {
		// Buy the pack back
		teamEnergyBuySell(%player,%pack.price * -1);
		Player::incItemCount(%client,%pack);
		Player::useItem(%client,%pack);									 
		centerprint(%client, "<jc>Insufficient team energy to build object.");
		return 0;
	}				 

}


function processMenuSCVStructures(%client, %opt)
{
	%item = $SCVStructureList[%opt];
	%player = Client::getOwnedObject(%client);

	if($TeamItemMax[%item] != "") {						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) {
			centerprint(%client, "<jc>Maximum number of " @ %item.description @ "s deployed.");
			return 0;
		}
	}

	%pack = Player::getMountedItem(%client,$BackpackSlot);

	if(%pack != -1) {
		teamEnergyBuySell(%player,%pack.price);
		if(!Player::isDead(%player)) Player::decItemCount(%client,%pack);
	}			   

	if(checkResources(%player,%item,1) || $testCheats) {
		teamEnergyBuySell(%player,%item.price * -1);
		Player::incItemCount(%client,%item);
		Player::useItem(%client,%item);
		return 1;
	} else if(%pack != -1) {
		teamEnergyBuySell(%player,%pack.price * -1);
		Player::incItemCount(%client,%pack);
		Player::useItem(%client,%pack);									 
		centerprint(%client, "<jc>Insufficient team energy to build object.");
	}				 
}


