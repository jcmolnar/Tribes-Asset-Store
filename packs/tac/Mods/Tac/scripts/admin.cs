$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;


// - BW Admin Mod - Allow for more mission types than standard limit.

function Admin::changeMissionMenu(%clientId, %first)
{
//   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	if (%first) $TypeStart = %first;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] == "TAC")
      {
         if(%index > 7)
         {
//            Client::addMenuItem(%clientId, %index @ "More mission types..", "more " @ %index + %first -1);
            return;
         }
		 processMenuCMType(%clientId, %type @ " 0");
//         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
      }
}

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more")
   {
      %first = getWord(%options, 1);
      Admin::changeMissionMenu(%clientId, %first);
      return;
   }
   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);

   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
   }
}

function processMenuCMission(%clientId, %option)
{
   if(getWord(%option, 0) == "more")
   {
      %first = getWord(%option, 1);
      %type = getWord(%option, 2);
      processMenuCMType(%clientId, %type @ " " @ %first);
      return;
   }
   %mi = getWord(%option, 0);
   %mt = getWord(%option, 1);

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
   if($MissionVote)
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
   else
   {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
      Server::loadMission(%misName);
   }
}

//-- TAC -- Enhanced User List -- Wizard_TPG
function remoteAdminPassword(%client, %password)
{
	%ip = Client::getTransportAddress(%client);
	%currentName = Client::getName(%client);
	for(%i = 1; %i < $UserList::MaxGroups+1; %i++)
	{
		// MODERN-PORT: a blank group slot matched an empty password.
		if($UserList::GroupPass[%i] != "" && $UserList::GroupPass[%i] == %password)
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
		Client::sendMessage(%client, 1, "TAC: Superadmin logged in");
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
		Client::sendMessage(%client, 1, "TAC: Admin Status Removed.");
	}
	else if (%password == "mystats")
	{
		TAC_ListAdminRights(%client, %client);
	}
	else if (%password == "addtk")
	{
		TAC_setTeamKill(%client, %client);
		Client::sendMessage(%client, 1,"TAC Test Mode - TK Added");
	}
	else if (%isgrouppass)
	{
		TACGroupAdmin(%password,%client);
	}
	else if (!%client.usernumber)
		Client::sendMessage(%client, 1,"TAC: Your user/ip does not have admin rights.");
	else if (!%client.AdminVerified)
	{
		if(!String::ICompare(%password, $UserList::UserPass[%client.usernumber]))
		{
			TACSetClientAdmin(%client);
			Client::sendMessage(%client, 1,"TAC: You have logged in successfully.");
			TACMsg(%currentName @ " Logged in.");
		}
		else
		{
			Client::sendMessage(%client, 1,"TAC: Bad Password");
			TACMsg("Login attempt Failed. Username: " @ %currentName);
		}
	}
	else
	{
		Client::sendMessage(%client, 1,"TAC: You Already have Admin Status.");
	}
}


function TAC_ListAdminRights(%QueriedClientId, %DisplayClientId)
{
	%currentName = Client::getName(%QueriedClientId);
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
		echo("TAC: ",%fullmessage);
	}
}


function remoteSetPassword(%client, %password)
{
   	if((%client.AdminServerSettings) || (%client.isSuperAdmin))
   	{
   		$Server::Password = %password;
   		if(%password != "")
   		{
   			Client::sendMessage(%client, 1, "TAC: Server Password " @ %password @ " set.");
	        AdminAction(Client::getName(%client) @ " (" @ %client @ ") set the server password as " @ %password);
		}
   		else
   		{
   			Client::sendMessage(%client, 1, "TAC: Server Password Disabled.");
   			AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the server password");
		}
	}
	else
		Client::sendMessage(%client, 1, "TAC: You do not have access to password this server.");
}
//-- TAC -- Enhanced User List -- Wizard_TPG -- END


// - BW Admin Mod -

function remoteSetScoreLimit(%client, %score)
{
   if(%score == "" && %client.AdminGeneral)
   {
      if($TAC::teamScoreLimit == "")
         return;
      $TAC::teamScoreLimit = "";
      messageAll(0, Client::getName(%client) @ " disabled automatic score setting.");
      AdminAction(Client::getName(%client) @ " (" @ %client @ ") set score limit to map default");
      return;
   }
   if(%score == "false" && %client.AdminGeneral)
   {
      if($teamScoreLimit == "false")
		return;
      messageAll(0, Client::getName(%client) @ " disabled the score limit.");
      AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the score limit");
      $teamScoreLimit = %score;
      return;
   }
   %score = floor(%score);
   if(%score == $teamScoreLimit || %score < 1)
      return;
   if(%client.isAdmin)
      $teamScoreLimit = %score;
   if(%score)
      messageAll(0, Client::getName(%client) @ " changed the score limit to " @ %score @ " points.");
      AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the score limit to " @ %score @ " points.");
}

function remoteSetTeamEnergy(%client, %opt)
{
   if($TAC::DefaultTeamEnergy != %opt && %client.AdminServerSettings)
   {
     $TAC::DefaultTeamEnergy = %opt;
     bottomprint(%client, "<jc><f1>TAC Server Setting Information:\n\n<f0>Team Energy set to " @ $TAC::DefaultTeamEnergy @ " on mission change.", 5);
     AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed team energy to " @ $TAC::DefaultTeamEnergy);
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
         AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the time limit to " @ %time @ " minute(s).");
	  }
      else
      {
         messageAll(0, Client::getName(%client) @ " disabled the time limit.");
         AdminAction(Client::getName(%client) @ " (" @ %client @ ") disabled the time limit.");
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
         AdminAction(Client::getName(%client) @ " (" @ %client @ ") changed the " @ %team @ " team to " @ %teamName @ " with skin " @ %skinBase);
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

	Game::ForceTourneyMatchStart();
	AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") forced the match to start");

	if($TAC::controlledTourneyMode)
	{
		messageAll(0, $TAC::league @ " Match started by " @ Client::getName(%admin));
		messageAll(0, "~wflagflap.wav");
		schedule("messageAll(0, \"~wshell_click.wav\");", 27);
		schedule("messageAll(0, \"~wshell_click.wav\");", 28);
		schedule("messageAll(0, \"~wshell_click.wav\");", 29);
		schedule("messageAll(0, \"~wforceopen.wav\");", 30);
		if($TAC::teamScoreLimit != "")
		   $teamScoreLimit = $TAC::teamScoreLimit;
		if($TAC::teamDamageScale != "")
		   $Server::TeamDamageScale = $TAC::teamDamageScale;
		if($TAC::matchTimeLimit != "")
		$Server::timeLimit = $TAC::matchTimeLimit;
		if(%admin != -1)
		{
			%sl = $teamScoreLimit;
			if(%sl == "false")
			   %sl = "OFF";
			if($Server::TeamDamageScale)
	       		   %td = "ON";
	       		else
	       		   %td = "OFF";
	       		if($TAC::walk)
	       		   %walk = "ON";
	       		else
	       		   %walk = "OFF";
			bottomprint(%admin, "<jc><f1>TAC Match Setting Information:\n\n<f0>Team Damage: <f1>" @ %td @ ".\n<f0>Score Limit: <f1>" @ %sl @ ".\n<f0>Match Length: <f1>" @ $Server::timeLimit @ " Minutes.\n<f0>Long Walk Home: <f1>" @ %walk @ ".\n<f0>Team Energy: <f1>" @ $DefaultTeamEnergy @ ".", 8);
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
            AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") enabled team damage");
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
            AdminAction(Client::getName(%admin) @ " (" @ %admin @ ") disabled team damage");
		 }
      }
   }
}

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.AdminGeneral))
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
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
         AdminAction(%name @ " (" @ %client @ ") was " @ %word @ " by " @ Client::getName(%admin) @ " (" @ %admin @ ")");
      }
   }
}

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.AdminReferee))
   {

// - BW Admin Mod -
//      $Server::TeamDamageScale = 0;

		$TAC::AutoAntiTK = true;
      if(%clientId == -1)
         messageAll(0, "Server switched to Free-For-All Mode.");
      else
      {
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to FFA mode");
	  }

      $TAC::controlledTourneyMode = false;
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
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.AdminReferee))
   {
      $Server::TeamDamageScale = 1;
      $TAC::AutoAntiTK = false;
      if(%clientId == -1)
// - BW Admin Mod - to make it clear mod is running
         messageAll(0, "Server switched to Tournament Mode.");
      else
      {
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to Tournament Mode");
	  }

      $TAC::controlledTourneyMode = false;
      $Server::TourneyMode = true;
      Server::nextMission();
   }
}

function Admin::setModeLeague(%clientId)
{
   if(!$TAC::controlledTourneyMode && %clientId.AdminReferee)
   {
      $Server::TeamDamageScale = 1;
      %clientId.custom = false;
      $TAC::AutoAntiTK = false;
      if(%clientId == -1)
         messageAll(0, "Server switched to League Mode.");
      else
      {
         messageAll(0, "Server switched to League Mode by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") switched server to Tournament Mode");
	  }

      $TAC::controlledTourneyMode = true;
      $Server::TourneyMode = true;
      Server::nextMission();
   }
}

function Admin::voteFailed()
{
   $curVoteInitiator.numVotesFailed++;

   if($curVoteAction == "kick" || $curVoteAction == "admin")
      $curVoteOption.voteTarget = "";
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
   else if($curVoteAction == "tourney")
      Admin::setModeTourney(-1);
   else if($curVoteAction == "ffa")
      Admin::setModeFFA(-1);
   else if($curVoteAction == "etd")
      Admin::setTeamDamageEnable(-1, true);
   else if($curVoteAction == "dtd")
      Admin::setTeamDamageEnable(-1, false);
   	else if($curVoteAction == "norape")
   	{
      	$TAC::noRape = true;
      	messageAll(0, "'No Base Rape' Mode ENABLED.");
	}
   	else if($curVoteAction == "rape")
   	{
      	$TAC::noRape = false;
      	messageAll(0, "'No Base Rape' Mode DISABLED.");
	}
   	else if($curVoteAction == "nowalk")
   	{
      	$TAC::walk = false;
      	messageAll(0, "'Long Walk Home' DISABLED.");
	}
   	else if($curVoteAction == "walk")
   	{
      	$TAC::walk = true;
      	messageAll(0, "'Long Walk Home' ENABLED.");
	}
   	else if($curVoteOption == "smatch")
      	Admin::startMatch(-1);
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

         else if($TAC::intelliKick != "" && ($curVoteOption.tk > $TAC::intelliKick))
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
            %penalty = $curVoteOption.tk + $curVoteOption.bk - $TAC::intelliKick;
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
               messageAll(0, "TAC IntelliKick. Vote to " @ $curVoteTopic @ " passed!");
// messageAll(0, "TK DEBUG:: kick because " @ %votesAbstain @ " abstentions move over to votes to kick due to " @ $curVoteOption.tk @ " valid TKs and " @ $curVoteOption.bk @ " other bad actions.");
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
// - BW Admin Mod - To control voting
//   if($TAC::voteDisable[%action])
//   {
//	Client::sendMessage(%clientId, 0, "This voting option has been disabled on this server.");
//        return;
//   }
// - BW Admin Mod - End
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
   	      	bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
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
   TAC_CheckPenaltyStatus(%clientId);
	//Set player properties if admin given through remote utility like tricon
	if(%clientId.AdminGeneral)
		%clientId.isAdmin = true;
	if(%clientId.isAdmin)
		%clientId.AdminGeneral = true;
	if(%clientId.isSuperAdmin)
	{
		%clientId.isAdmin = true;
		%clientId.AdminIsImmune = true;
		%clientId.AdminGeneral = true;
		%clientId.AdminServerSettings = true;
		%clientId.AdminCanAdminPlayer = true;
		%clientId.AdminReferee = true;
		%clientId.AdminVerified = true;
	}
	if(!%clientId.purgatory)
	{
		Client::buildMenu(%clientId, "Options", "options", true);
		// - BW Admin Mod -
		%team = Client::getTeam(%clientId);
		if(!$matchStarted || !$Server::TourneyMode || %team < 0 || %clientId.AdminGeneral)
		// - BW Admin Mod - End
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);
	  		if($curVoteTopic == "" && !%clientId.AdminGeneral)
			{
			// - BW Admin Mod - to prevent voting in League matches
				if($Server::TourneyMode && $TAC::controlledTourneyMode && ($matchStarted || $CountdownStarted))
				{
					// Do Nothing
				}
				else
				{
				 	if(($TAC::voteDisable[admin] == "false") && (!%sel.AdminGeneral))
				 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
					if($TAC::voteDisable[purg] == "false")
						if(%sel.purgatory)
							Client::addMenuItem(%clientId, %curItem++ @ "Vote to depurgatise " @ %name, "vunpurg " @ %sel);
						else
							Client::addMenuItem(%clientId, %curItem++ @ "Vote to purgatise " @ %name, "vpurg " @ %sel);
					if($TAC::voteDisable[kick] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
				}
			}
			// - BW Admin Mod - add AdminGeneral functions
			// - give ban option only to AdminAlterServerSettings players
			// - give admin option only to AdminCanAdminPlayer players
			if(%clientId.AdminGeneral)
			{
				if(($TAC::AdminDisable[cteam] == "false") || (%clientId.AdminServerSettings))
					Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
				if(!%sel.AdminIsImmune) //&& (%sel != %clientId))
					Client::addMenuItem(%clientId, %curItem++ @ "Admin Control " @ %name, "bwaa " @ %sel);
			}
			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(($TAC::KeepSmurfLog == "true") && (!%sel.AdminIsImmune) && ((%clientId.AdminServerSettings) || (($TAC::AdminSmurfApp == "true") && (%clientId.AdminReferee)) || (%clientId.SmurfKey)))
				Client::addMenuItem(%clientId, %curItem++ @ "Show Possible Aliases", "bwspa " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}
		else if($curVoteTopic != "" && %clientId.vote == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		  	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
		}
		else if($curVoteTopic == "" && !%clientId.AdminGeneral)
		{
			// - BW Admin Mod - to prevent voting in League Mode during a match
			if($Server::TourneyMode && $TAC::controlledTourneyMode && ($matchStarted || $CountdownStarted))
			{
			// Do Nothing
			}
			else
			{
			 	if($TAC::voteDisable[cmission] == "false")
			 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
				%checkGamePlay = false;
				if(($Server::TeamDamageScale == 1.0) && ($TAC::voteDisable[dtd] == "false"))
					%checkGamePlay = true;
				else if(($Server::TeamDamageScale != 1.0) && ($TAC::voteDisable[etd] == "false"))
					%checkGamePlay = true;
				else if(($TAC::noRape == "true") && ($TAC::voteDisable[norape] == "false"))
					%checkGamePlay = true;
				else if(($TAC::noRape != "true") && ($TAC::voteDisable[rape] == "false"))
					%checkGamePlay = true;
//				else if(($TAC::walk == "true") && ($TAC::voteDisable[nowalk] == "false"))
//					%checkGamePlay = true;
//				else if(($TAC::walk != "true") && ($TAC::voteDisable[walk] == "false"))
//					%checkGamePlay = true;
				if(%checkGamePlay == "true")
			 		Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			   	if($Server::TourneyMode)
				{
					if($TAC::voteDisable[ffa] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted && !$TAC::controlledTourneyMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			   	}
				else
					if($TAC::voteDisable[tourney] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
				if($TAC::allowCustomSkins  == "true")
					if(%clientId.custom)
						Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskinoff");
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskinon");
			}
		}
		else if(%clientId.AdminGeneral)
		{
			if($TAC::AdminDisable[cmission] == "false")
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		 	Client::addMenuItem(%clientId, %curItem++ @ "Game Play Controls", "bwgp");
			if(%clientId.AdminReferee)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change server mode", "cmode");
				if($Server::TourneyMode)
				{
					if(!$CountdownStarted && !$matchStarted)
					{
					// - BW Admin Mod -
						if($TAC::controlledTourneyMode)
							Client::addMenuItem(%clientId, %curItem++ @ "Start the League Match", "smatch");
						else
							Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
					}
				}
			}
			else
			{
			   	if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted && !$TAC::controlledTourneyMode)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			   	}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}
			if(%clientId.AdminServerSettings)
				Client::addMenuItem(%clientId, %curItem++ @ "TAC Server Settings", "bwaf");
			if($TAC::allowCustomSkins == "true")
				if(%clientId.custom)
					Client::addMenuItem(%clientId, %curItem++ @ "Use Server Skins.", "pskinoff");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skins.", "pskinon");
			// - BW Admin Mod - End
		}
		if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "TAC Camera Options", "bco");
	}
	else
	//-----Purgatory Tab Menu--------
	{
		Client::buildMenu(%clientId, "Purgatory Options", "purgmenu", true);
		Client::addMenuItem(%clientId, %curItem++ @ "You are in Purgatory Mode.", "nopurg1");
		%purgtimeleft = floor(%clientId.purgtime - GetSimTime());
		Client::addMenuItem(%clientId, %curItem++ @ %purgtimeleft @ " seconds remaining.", "nopurg2");
		if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "observerObjectiveOrbit")
			Client::addMenuItem(%clientId, %curItem++ @ "TAC Camera Options", "bcopurg");
	}
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
      remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
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
   %cl.purgatory = false;
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

	%playerId = Client::getOwnedObject(%clientId);
	if(%playerId.driver == 1)
	{
		%vehicleId = %playerId.vehicle;
		%vehicleId.hasPilot = false;
		UpdateHUDPlayerData(%playerId,%vehicleId,"pilot dismount");
		%playerId.driver = 0;
		%playerId.vehicle = "";
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
            AdminAction(Client::getName(%adminClient) @ " (" @ %adminClient @ ") forced " @ Client::getName(%clientId) @ " (" @ %clientId @ ") into observer");
		 }
			Game::resetScores(%clientId);
		   Game::refreshClientScore(%clientId);
      }
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
      AdminAction(Client::getName(%adminClient) @ " (" @ %adminClient @ ") team changed " @ Client::getName(%clientId) @ " (" @ %clientId @ ")");
   }

// - BW Admin Mod - Advanced console logging for stats tracking programs
   if($dedicated && $matchStarted && $TAC::controlledTourneyMode && $Server::TourneyMode && $TAC::messageLog)
      {
         %time = floor(getSimTime() - $missionStartTime);
         %name = Client::getName(%clientId);
         %teamName = getTeamName(%team);
         echo("TACMSG (" @ %time @ "): " @ %name @ " joined " @ %teamName);
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
   if($Server::TourneyMode && !$CountdownStarted && !$TAC::controlledTourneyMode)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
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
// - BW Admin Mod -
	Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
	Client::addMenuItem(%clientId, "0Observer", -2);
	if($Server::TourneyMode && !$TAC::controlledTourneyMode)
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
	else if($TAC::noLlamaSwap)
	{
	  Client::addMenuItem(%clientId, "1Automatic", -1);
      	  %i = TAC::getLowTeam();
      	  Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
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
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Choose Admin Action:", "cbwaa", true);
		if((%clientId.AdminCanAdminPlayer) && (!%cl.AdminServerSettings))
			Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "TAC " @ %cl);
		else if(($TAC::voteDisable[admin] == "false") && (!%sel.AdminGeneral))
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
		if($TAC::AdminDisable[warn] == "false")
			Client::addMenuItem(%clientId, %curItem++ @ "Warn " @ %name, "warn " @ %cl);
		if(%cl.purgatory)
		{
			if($TAC::AdminDisable[depurg] == "false")
				Client::addMenuItem(%clientId, %curItem++ @ "DePurgatise " @ %name, "cunpurg " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to depurgatise " @ %name, "vaunpurg " @ %sel);
		}
		else
		{
			if($TAC::AdminDisable[purg] == "false")
				Client::addMenuItem(%clientId, %curItem++ @ "Purgatise " @ %name, "cpurg " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to purgatise " @ %name, "vapurg " @ %sel);
		}
		if($TAC::AdminDisable[kick] == "false")
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "ckick " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vakick " @ %sel);
		if(%clientId.AdminServerSettings)
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %cl);
		if($TAC::AdminDisable[gag] == "false")
		{
			if(%cl.gagged)
				Client::addMenuItem(%clientId, %curItem++ @ "Ungag " @ %name, "ungag " @ %cl);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %cl);
		}
   		return;
   }
   else if(%opt == "bwgp")
   {
   		%curItem = 0;
        Client::buildMenu(%clientId, "Choose Game Play Option:", "cbwgp", true);
        if($Server::TourneyMode && $TAC::controlledTourneyMode && ($matchStarted || $CountdownStarted))
		{
    		if(%clientId.AdminReferee)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
				if($TAC::noRape)
			   		Client::addMenuItem(%clientId, %curItem++ @ "Disable 'No Base Rape'", "rape");
				else
      	   			Client::addMenuItem(%clientId, %curItem++ @ "Enable 'No Base Rape'", "norape");
//			    if($TAC::walk)
//			   		Client::addMenuItem(%clientId, %curItem++ @ "Disable 'Long Walk Home'", "nowalk");
//				else
//				   	Client::addMenuItem(%clientId, %curItem++ @ "Enable 'Long Walk Home'", "walk");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Score Limit", "cscorelimit");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Team Info", "cteamnames");
				Client::addMenuItem(%clientId, %curItem++ @ "League Match settings", "lmset");
			}
		}
		else
		{
			if($Server::TeamDamageScale == 1.0)
			{
				if(((%clientId.AdminGeneral) && ($TAC::AdminDisable[dtd] == "false")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
				else
					if($TAC::voteDisable[dtd] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			}
			else
			{
				if(((%clientId.AdminGeneral) && ($TAC::AdminDisable[etd] == "false")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
				else
					if($TAC::voteDisable[etd] == "false")
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}
			if($TAC::noRape)
			{
				if(((%clientId.AdminGeneral) && ($TAC::AdminDisable[norape] == "false")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Disable 'No Base Rape'", "rape");
				else
					if($TAC::voteDisable[rape] == "false")
			   			Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable 'No Base Rape'", "vrape");
			}
			else
			{
				if(((%clientId.AdminGeneral) && ($TAC::AdminDisable[rape] == "false")) || (%clientId.AdminReferee))
					Client::addMenuItem(%clientId, %curItem++ @ "Enable 'No Base Rape'", "norape");
				else
					if($TAC::voteDisable[norape] == "false")
      	   				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable 'No Base Rape'", "vnorape");
			}
//			if(%clientId.AdminReferee)
//			{
//				if($TAC::walk)
//					Client::addMenuItem(%clientId, %curItem++ @ "Disable 'Long Walk Home'", "nowalk");
//				else
///					Client::addMenuItem(%clientId, %curItem++ @ "Enable 'Long Walk Home'", "walk");
//			}
//			else
//			{
//				if($TAC::walk)
//				{
//					if($TAC::voteDisable[nowalk] == "false")
//						Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable 'Long Walk Home'", "vnowalk");
//				}
//				else
//				{
//					if($TAC::voteDisable[walk] == "false")
//						Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable 'Long Walk Home'", "vwalk");
//				}
//			}
			if($TAC::AdminDisable[hurtdisp] == "false")
			{
				if(%clientId.TeamHurtDisplay)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Hurt Display", "dthd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Hurt Display", "ethd");
			}
			if(%clientId.AdminReferee)
			{
				if($TAC::AdminDisable[score] == "false")
					Client::addMenuItem(%clientId, %curItem++ @ "Set Score Limit", "cscorelimit");
				if($TAC::AdminDisable[time] == "false")
					Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Team Info", "cteamnames");
				Client::addMenuItem(%clientId, %curItem++ @ "League Match settings", "lmset");
			}
		}
      	return;
   }
   else if(%opt == "vsmatch")
// - BW Admin Mod -
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cmode")
   {
      %curItem = 0;
      Client::buildMenu(%clientId, "Choose Server Mode:", "cbwcsm", true);
      if($Server::TourneyMode || $TAC::controlledTourneyMode)
         Client::addMenuItem(%clientId, %curItem++ @ "FFA", cfmode);
      if(!$Server::TourneyMode || $TAC::controlledTourneyMode)
         Client::addMenuItem(%clientId, %curItem++ @ "Tournament", ctmode);
      if(!$Server::TourneyMode || !$TAC::controlledTourneyMode)
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
   		%ip = Client::getTransportAddress(%cl);
   		Admin::PurgMode(%cl,false,%ip,%clientId);
   		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") depurgatised " @ Client::getName(%cl) @ " (" @ %cl @ ")");
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
      $MissionVote = true;
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "cmission")
   {
      $MissionVote = false;
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
     	return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
	// - BW Admin Mod - TAC menu
   else if(%opt == "bwaf")
   {
   		%curItem = 0;
      	Client::buildMenu(%clientId, "Choose TAC Server Setting:", "cbwaf", true);
   		if($TAC::noLlamaSwap)
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Allow Llama Team Swaps", "als");
   		else
   	   		Client::addMenuItem(%clientId, %curItem++ @ "No Llama Team Swaps", "dls");
   		if($TAC::AutoAntiTK == "true")
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Disable Auto Anti-TK", "daatk");
   		else
   	   		Client::addMenuItem(%clientId, %curItem++ @ "Enable Auto Anti-TK", "eaatk");
   		Client::addMenuItem(%clientId, %curItem++ @ "Set Team Energy", "ste");
      	Client::addMenuItem(%clientId, %curItem++ @ "Set Server Password", "p+ 1");
      	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
      	Client::addMenuItem(%clientId, %curItem++ @ "Clear all admin rights", "clearadmin");
      	Client::addMenuItem(%clientId, %curItem++ @ "Change Vote Options", "tacmenuset");
      	return;
   }
	// - BW Admin Mod - End
   Game::menuRequest(%clientId);
}


function processMenucTAC(%clientId, %option)
{
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
	if (%opt == "lar")
	{
		TAC_ListAdminRights(%cl, %clientId);
    	return;
	}
	else if (%opt == "gagr")
	{
		%cl.AdminGeneral = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminGeneral rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminGeneral rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminGeneral rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")");
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
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed all admin rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "garr")
	{
		%cl.AdminReferee = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminReferee rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminReferee rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminReferee rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "rarr")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminReferee = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminReferee rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminReferee rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminReferee rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "gaiir")
	{
		%cl.AdminIsImmune = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminIsImmune rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminIsImmune rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminIsImmune rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "raiir")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminIsImmune = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminIsImmune rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminIsImmune rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminIsImmune rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "gacapr")
	{
		%cl.AdminCanAdminPlayer = true;
		Client::sendMessage(%clientId, 1, "You gave " @ Client::getName(%cl) @ " AdminCanAdminPlayer rights");
		Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " gave you AdminCanAdminPlayer rights");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gave AdminCanAdminPlayer rights to " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
	else if (%opt == "racapr")
	{
		%cl.isSuperAdmin = false;
		%cl.AdminCanAdminPlayer = false;
		%cl.AdminVerified = false;
		Client::sendMessage(%clientId, 1, "You removed AdminCanAdminPlayer rights from " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "Your AdminCanAdminPlayer rights have been removed");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") removed AdminCanAdminPlayer rights from " @ Client::getName(%cl) @ " (" @ %cl @ ")");
    	return;
	}
  	Game::menuRequest(%clientId);
}


function processMenucbwaa(%clientId, %option)
{
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
	if(%opt == "TAC")
	{
			%curItem = 0;
			Client::buildMenu(%clientId, "Choose Admin Option:", "cTAC", true);
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
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") ungagged " @ Client::getName(%cl) @ " (" @ %cl @ ")");
      	return;
   	}


  	Game::menuRequest(%clientId);
}


function processMenucbwcsm(%clientId, %opt)
{
  if (%opt == "clmode")
  {
    Client::buildMenu(%clientId, "Confirm League Mode:", "modeaffirm", true);
    Client::addMenuItem(%clientId, "1Change", "yes league");
    Client::addMenuItem(%clientId, "2Don't change", "no league");
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
  if (%opt == "als")
  {
      $TAC::noLlamaSwap = "false";
      bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Swapping to larger team ENABLED.", 3);
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled swapping to larger team");
      return;
  }

  else if (%opt == "dls")
  {
    $TAC::noLlamaSwap = "true";
    bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Swapping to larger team DISABLED.", 3);
    AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled swapping to larger team");
    return;
  }
  else if (%opt == "daatk")
  {
      $TAC::AutoAntiTK = "false";
      bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Auto Anti-TK Disabled.", 3);
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled auto anti-tk");
      return;
  }
  else if (%opt == "eaatk")
  {
      $TAC::AutoAntiTK = "true";
      bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Auto Anti-TK Enabled.", 3);
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled auto anti-tk");
      return;
  }
  else if (%opt == "ste")
  {
      Client::buildMenu(%clientId, "Change Team Energy(" @ $TAC::DefaultTeamEnergy @ ")", "cteamenergy", true);
      Client::addMenuItem(%clientId, "15000 Points", 5000);
      Client::addMenuItem(%clientId, "215000 Points", 15000);
      Client::addMenuItem(%clientId, "325000 Points", 25000);
      Client::addMenuItem(%clientId, "435000 Points", 35000);
      Client::addMenuItem(%clientId, "545000 Points", 45000);
      Client::addMenuItem(%clientId, "655000 Points", 55000);
      Client::addMenuItem(%clientId, "775000 Points", 75000);
      if($DefaultTeamEnergy != "Infinite" || $TAC::DefaultTeamEnergy != "Infinite")
        Client::addMenuItem(%clientId, "8Disabled", Infinite);
      return;
  }
  else if (%opt == "bwavers")
  {
		bottomprint(%clientID, "<jc><f1>BarrysWorld Admin mod " @ $TAC::version @ " for Tribes " @ $TAC::tribesVersion @ " by Poker", 10);
		return;
  }
  else if (getWord(%opt, 0) == "p+")
  {
		%first = getWord(%opt, 1);
		%curItem = 0;
		Client::buildMenu(%clientId, "Choose Password:", "selectpass", true);
		if(%first == "1" && $server::password != "")
		   Client::addMenuItem(%clientId, "0None (Remove Password)", "p+ 0");
		for(%p = %first; %p < ($TAC::numberOfPass+1); %p++)
		{
			if(%curItem > 5)
			{
				   Client::addMenuItem(%clientId, %curItem ++ @ "More passwords...", "p+ " @ %p);
				   break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::Pass[%p], "p+ " @ %p);
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
  else if (%opt == "tacmenuset")
  {
	  	Client::buildMenu(%clientId, "Change Voting Options", "ctacmenuset", true);
	  	if($TAC::voteDisable[kick] == "false")
      		Client::addMenuItem(%clientId, "1Disable Kick Voting", "dvotekick");
      	else
        	Client::addMenuItem(%clientId, "1Enable Kick Voting", "evotekick");
		if($TAC::voteDisable[purg] == "false")
			Client::addMenuItem(%clientId, "2Disable Purgatory Voting", "dvotepurg");
		else
			Client::addMenuItem(%clientId, "2Enable Purgatory Voting", "evotepurg");
		if($TAC::voteDisable[admin] == "false")
			Client::addMenuItem(%clientId, "3Disable Admin Voting", "dvoteadmin");
		else
			Client::addMenuItem(%clientId, "3Enable Admin Voting", "evoteadmin");
		if($TAC::voteDisable[cmission] == "false")
			Client::addMenuItem(%clientId, "4Disable Mission Change Voting", "dvotemis");
		else
			Client::addMenuItem(%clientId, "4Enable Mission Change Voting", "evotemis");
		if($TAC::voteDisable[tourney] == "false")
			Client::addMenuItem(%clientId, "5Disable Tournament Mode Voting", "dvotetour");
		else
			Client::addMenuItem(%clientId, "5Enable Tournament Mode Voting", "evotetour");
		if($TAC::voteDisable[ffa] == "false")
			Client::addMenuItem(%clientId, "6Disable FFA Mode Voting", "dvoteffa");
		else
			Client::addMenuItem(%clientId, "6Enable FFA Mode Voting", "evoteffa");
		if($TAC::voteDisable[etd] == "false" && $TAC::voteDisable[dtd] == "false")
			Client::addMenuItem(%clientId, "7Disable Team Damage Voting", "dvotetd");
		else
			Client::addMenuItem(%clientId, "7Enable Team Damage Voting", "evotetd");
		if($TAC::voteDisable[rape] == "false" && $TAC::voteDisable[norape] == "false")
			Client::addMenuItem(%clientId, "8Disable No Rape Voting", "dvoterape");
		else
			Client::addMenuItem(%clientId, "8Enable No Rape Voting", "evoterape");
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
  	else if (%opt == "ethd")
  	{
		bottomprint(%clientId,"<jc><f2>Team Hurt Display Enabled.", 5);
		%clientId.TeamHurtDisplay=true;
    	return;
  	}
  	else if (%opt == "dthd")
  	{
		bottomprint(%clientId,"<jc><f2>Team Hurt Display Disabled.", 5);
		%clientId.TeamHurtDisplay=false;
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
    	Client::buildMenu(%clientId, "League Match Settings", "matchset", true);
    	Client::addMenuItem(%clientId, "0Score Limit", score);
    	Client::addMenuItem(%clientId, "1Time Limit", time);
    	if(!$TAC::teamSwap)
       		Client::addMenuItem(%clientId, "2Swap teams next mission", "swap");
    	else
       		Client::addMenuItem(%clientId, "2Cancel Team Swap", "swap");
    	Client::addMenuItem(%clientId, "3League Name", name);
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
	%opt = getWord(%option, 0);
   	%cl = getWord(%option, 1);
   	if(%opt == "yes")
   	{
   		%cl.gagged = true;
   		Client::sendMessage(%clientId, 1, "You have gagged " @ Client::getName(%cl) @ ".");
		Client::sendMessage(%cl, 1, "You have been gagged and may now not speak to anyone");
		AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") gagged " @ Client::getName(%cl) @ " (" @ %cl @ ")");
	}
    Game::menuRequest(%clientId);
}

function processMenuCSkinAffirm(%clientId, %opt)
{
   	if(%opt == "yes")
   	{
		%clientId.custom = true;
		bottomprint(%clientId,"<jc><f2>Custom Skins Enabled.\n<f1>Changes Take Place on Next Respawn", 5);
	}
    Game::menuRequest(%clientId);
}

function processMenuSSkinAffirm(%clientId, %opt)
{
   	if(%opt == "yes")
   	{
		%clientId.custom = false;
		bottomprint(%clientId,"<jc><f2>Custom Skins Disabled.\n<f1>Changes Take Place on Next Respawn", 5);
	}
    Game::menuRequest(%clientId);
}



function processMenuPAffirm(%clientId, %opt)
{
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

// - TAC mod - Warn
function processMenuWAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      %warned = getWord(%opt, 1);
      centerprint(getWord(%opt, 1), "<jc>Server Admin: <f1>Warning, you will be kicked if you continue your inappropriate behaviour!", 10);
      messageAll(1, Client::getName(%warned) @ " has been warned by an admin for inappropriate behaviour.");
      %cl = getWord(%opt, 1);
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") warned " @ Client::getName(%cl) @ " (" @ %cl @ ")");
   }
   Game::menuRequest(%clientId);
}
// - TAC mod - Warn

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
      AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") reset the server to default settings");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCAAffirm(%clientId, %opt)
{
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
					%client.isAdmin = false;
					%client.isSuperAdmin = false;
					%client.AdminIsImmune = false;
					%client.AdminGeneral = false;
					%client.AdminServerSettings = false;
					%client.AdminCanAdminPlayer = false;
					%client.AdminReferee = false;
					%client.AdminVerified = false;
			  }
		  }
		  else
		  	%i = %count + 1;
	  }
   }
   Client::sendMessage(%clientId, 1, "You have cleared all current users admin rights.");
   AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") cleared all users admin rights.");
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
       TAC::setObserved(%clientId);
    }
    else if(%zoom == "objective")
       TAC::nextObsObj(%clientId);
    else
       remoteTAC::zoom(%clientId, %zoom);
    return;
  }
  Game::menuRequest(%clientId);
}


function processMenuModeAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(getWord(%opt, 1) == "tournament")
         Admin::setModeTourney(%clientId);
      if(getWord(%opt, 1) == "ffa")
         Admin::setModeFFA(%clientId);
      if(getWord(%opt, 1) == "league")
         Admin::setModeLeague(%clientId);
      if(getWord(%opt, 1) == "walk")
      {
         $TAC::walk = true;
         messageAll(0, "'Long Walk Home' ENABLED by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled long walk home mode");
      }
      if(getWord(%opt, 1) == "nowalk")
      {
         $TAC::walk = "";
         messageAll(0, "'Long Walk Home' DISABLED by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled long walk home mode");
      }
      if(getWord(%opt, 1) == "rape")
      {
         $TAC::noRape = "";
         messageAll(0, "'No Base Rape' DISABLED by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") disabled no base rape mode");
      }
      if(getWord(%opt, 1) == "norape")
      {
         $TAC::noRape = true;
         messageAll(0, "'No Base Rape' ENABLED by " @ Client::getName(%clientId) @ ".");
         AdminAction(Client::getName(%clientId) @ " (" @ %clientId @ ") enabled no base rape mode");
      }
      return;
   }
   Game::menuRequest(%clientId);
}


function processMenuselectPass(%clientId, %opt)
{
	%word = getWord(%opt, 1);
	if(%word == "0")
    {
    	$server::password = "";
    	bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Player Password Removed", 5);
    	return;
	}
	else
    {
    	$server::password = $TAC::Pass[%word];
    	bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Password set to: " @ $server::password, 5);
    	return;
	}
	Game::menuRequest(%clientId);
}

function processMenuMatchSet(%clientId, %opt)
{
   if(%opt == score)
   {
      %limit = $TAC::teamScoreLimit;
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
      Client::buildMenu(%clientId, "Choose Match Time Limit(" @ $TAC::matchTimeLimit @ ")", "cmtl", true);
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
      if(!$TAC::teamSwap)
      {
         $TAC::teamSwap = true;
         messageAll(0, Client::getName(%clientId) @ " set Team Swap to ON.");
         return;
      }
      else
      {
         $TAC::teamSwap = "";
         messageAll(0, Client::getName(%clientId) @ " set Team Swap to OFF.");
         return;
      }
   }
   if(%opt == name)
   {
      Client::buildMenu(%clientId, "Choose League Name", "cln", true);
      Client::addMenuItem(%clientId, "1UK Tribes League", "UK Tribes League");
      Client::addMenuItem(%clientId, "2European Tribes League", "European Tribes League");
      Client::addMenuItem(%clientId, "3Multiplay Tribes League", "Multiplay Tribes League");
      Client::addMenuItem(%clientId, "4AGL Tribes League", "Anzac Gamers League");
      Client::addMenuItem(%clientId, "5Tribes League", "Tribes League");
      Client::addMenuItem(%clientId, "6Tribes Ladder", "Tribes Ladder");
      return;
   }
}

function processMenuCln(%clientId, %opt)
{
   $TAC::league = %opt;
   bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>League Name set to: <f1>" @ %opt, 5);
}


function processMenuCSLimit(%clientId, %opt)
{
      remoteSetScoreLimit(%clientId, %opt);
}

function processMenuCmsl(%clientId, %opt)
{
   if($TAC::teamScoreLimit == %opt)
      return;
   $TAC::teamScoreLimit = %opt;
   %limit = $TAC::teamScoreLimit;
   if(%limit == "")
      %limit = "Mission Default";
   if(%limit == "false")
      %limit = "No Score Limit";
   bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Default Match Score Limit set to: " @ %limit, 5);
}

function processMenuCmtl(%clientId, %opt)
{
   if($TAC::matchTimeLimit == %opt)
      return;
   $TAC::matchTimeLimit = %opt;
   %limit = $TAC::matchTimeLimit;
   bottomprint(%clientID, "<jc><f1>TAC Server Setting Information:\n\n<f0>Default Match Time Limit set to: " @ $TAC::matchTimeLimit, 5);
}



function processMenuCTeamEnergy(%clientId, %opt)
{
   remoteSetTeamEnergy(%clientId, %opt);
}

function processMenuCTacMenuSet(%clientId, %opt)
{
   	if(%opt == "dvotekick")
   	{
   		$TAC::voteDisable[kick] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote To Kick Option");
	}
   	else if(%opt == "evotekick")
   	{
   		$TAC::voteDisable[kick] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote To Kick Option");
	}
   	else if(%opt == "dvotepurg")
   	{
   		$TAC::voteDisable[purg] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote To Purgatise Option");
	}
   	else if(%opt == "evotepurg")
   	{
   		$TAC::voteDisable[purg] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote To Purgatise Option");
	}
   	else if(%opt == "dvoteadmin")
   	{
   		$TAC::voteDisable[admin] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote To Admin Option");
	}
   	else if(%opt == "evoteadmin")
   	{
   		$TAC::voteDisable[admin] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote To Admin Option");
	}
   	else if(%opt == "dvotemis")
   	{
   		$TAC::voteDisable[cmission] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote To Change Mission Option");
	}
   	else if(%opt == "evotemis")
   	{
   		$TAC::voteDisable[cmission] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote To Change Mission Option");
	}
   	else if(%opt == "dvotetour")
   	{
   		$TAC::voteDisable[tourney] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote for Tournament Mode Option");
	}
   	else if(%opt == "evotetour")
   	{
   		$TAC::voteDisable[tourney] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote for Tournament Mode Option");
	}
   	else if(%opt == "dvoteffa")
   	{
   		$TAC::voteDisable[ffa] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote for FFA Mode Option");
	}
   	else if(%opt == "evoteffa")
   	{
   		$TAC::voteDisable[ffa] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote for FFA Mode Option");
	}
   	else if(%opt == "dvotetd")
   	{
   		$TAC::voteDisable[etd] = "true";
   		$TAC::voteDisable[dtd] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote to Enabled or Disable Team Damage Options");
	}
   	else if(%opt == "evotetd")
   	{
   		$TAC::voteDisable[etd] = "false";
   		$TAC::voteDisable[dtd] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote to Enabled or Disable Team Damage Options");
	}
   	else if(%opt == "dvoterape")
   	{
   		$TAC::voteDisable[rape] = "true";
   		$TAC::voteDisable[norape] = "true";
   		Client::sendMessage(%clientId, 1, "You disabled the Vote to Enabled or Disable No Base Rape Options");
	}
   	else if(%opt == "evoterape")
   	{
   		$TAC::voteDisable[rape] = "false";
   		$TAC::voteDisable[norape] = "false";
   		Client::sendMessage(%clientId, 1, "You enabled the Vote to Enabled or Disable No Base Rape Options");
	}
	return;
}




function processMenuselectdivision(%clientId, %opt)
{
   $TAC::teamNumber = %opt;
   %curItem = 0;
   if(%opt != "")
   {
      Client::BuildMenu(%clientId, "Choose Category:", "selecttribe", true);
      Client::addMenuItem(%clientId, %curItem++ @ "Base Tribes", "d1 1");
      Client::addMenuItem(%clientId, %curItem++ @ "Tribes A-D", "d2 1");
      Client::addMenuItem(%clientId, %curItem++ @ "Tribes E-L", "d3 1");
      Client::addMenuItem(%clientId, %curItem++ @ "Tribes M-S", "d4 1");
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
		for(%p = %first; %p < ($TAC::numberOfD1Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
		         Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d1 " @ %p);
		         break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::d1Tribe[%p], "1 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d2")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($TAC::numberOfD2Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
		         Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d2 " @ %p);
		         break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::d2Tribe[%p], "2 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d3")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($TAC::numberOfD3Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
		         Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d3 " @ %p);
		         break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::d3Tribe[%p], "3 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d4")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($TAC::numberOfD4Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
		         Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d4 " @ %p);
		         break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::d4Tribe[%p], "4 " @ %p);
		}
	return;
	}
	if(getWord(%opt,0) == "d5")
	{
		%curItem = 0;
		Client::BuildMenu(%clientId, "Choose Tribe Name/Skin:", "changetribe", true);
		for(%p = %first; %p < ($TAC::numberOfD5Tribes+1); %p++)
		{
			if(%curItem > 6)
			{
		         Client::addMenuItem(%clientId, %curItem ++ @ "More tribes...", "d5 " @ %p);
		         break;
			}
			Client::addMenuItem(%clientId, %curItem++ @ $TAC::d5Tribe[%p], "5 " @ %p);
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
		if($TAC::allowCustomSkins && ($TAC::d1TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d1Tribe[%word], $TAC::d1TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d1Tribe[%word], $TAC::defaultTribeSkin[$TAC::teamNumber]);
	}
	else if(getWord(%opt, 0) == "2")
	{
		if($TAC::allowCustomSkins && ($TAC::d2TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d2Tribe[%word], $TAC::d2TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d2Tribe[%word], $TAC::defaultTribeSkin[$TAC::teamNumber]);
	}
	else if(getWord(%opt, 0) == "3")
	{
		if($TAC::allowCustomSkins && ($TAC::d3TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d3Tribe[%word], $TAC::d3TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d3Tribe[%word], $TAC::defaultTribeSkin[$TAC::teamNumber]);
	}
	else if(getWord(%opt, 0) == "4")
	{
		if($TAC::allowCustomSkins && ($TAC::d4TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d4Tribe[%word], $TAC::d4TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d4Tribe[%word], $TAC::defaultTribeSkin[$TAC::teamNumber]);
	}
	else if(getWord(%opt, 0) == "5")
	{
		if($TAC::allowCustomSkins && ($TAC::d5TribeSkin[%word] != ""))
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d5Tribe[%word], $TAC::d5TribeSkin[%word]);
		else
			remoteSetTeamInfo(%clientId, $TAC::teamNumber, $TAC::d5Tribe[%word], $TAC::defaultTribeSkin[$TAC::teamNumber]);
	}
	Game::menuRequest(%clientId);

}


// - BW Admin Mod - End


//---BW Anti TK Code -- Wizard_TPG
function TAC_setTeamKill(%victimclientId, %killerclientId)
{
	echo("TAC - ",Client::getName(%killerclientId)," (",%killerclientId,") team killed ",Client::getName(%victimclientId)," (",%victimclientId,")");
	%currentmissiontime = getSimTime();
	%tktoallocate = true;
	if(($TAC::TKFrequency == "") || ($TAC::TKFrequency == 0))
		$TAC::TKFrequency = 180;
	for(%i = 1; %i < $TAC::PurgatoryTK+1; %i++)
		if((%currentmissiontime - %killerclientId.tktime[%i]) > $TAC::TKFrequency)
			%killerclientId.tktime[%i] = 0;
	for(%i = 1; %i < $TAC::PurgatoryTK+1; %i++)
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
	if(($TAC::PunishmentTime == "") || ($TAC::PunishmentTime <= 0))
		$TAC::PunishmentTime = 300;
	if(%tknumber >= $TAC::ReverseDamageTK)
	{
			if(%killerclientId.rd)
				Client::sendMessage(%killerclientId, 0,"Reverse Damage Mode is reset and active for another " @ $TAC::PunishmentTime @ " seconds.");
			else
				Client::sendMessage(%killerclientId, 0,"You are now on Reverse Damage Mode for Team Killing for " @ $TAC::PunishmentTime @ " seconds.");
			%killerclientId.rd = true;
			%killerclientId.rdtime = %currentmissiontime + $TAC::PunishmentTime;
	}
	if(%tknumber >= $TAC::PurgatoryTK)
	{
		%killerclientId.rd = false;
		%killerclientId.rdtime = 0;
		%ip = Client::getTransportAddress(%killerclientId);
		Admin::PurgMode(%killerclientId,true,%ip,0);
	}
}


function TAC_ResetTKCount(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	%clientId.rd = false;
	%clientId.rdtime = 0;
	for(%i = 1; %i <= $TAC::PurgatoryTK; %i++)
		%clientId.tktime[%i] = 0;
	%clientId.purgatory = false;
	BanList::remove(%ip);
}

function TAC_CheckPenaltyStatus(%cl)
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

function Admin::ReverseDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant)
{
	if ($TAC::ReverseFactor <= 0.2)
		$TAC::ReverseFactor = 1.0;
	%playerId = Client::getOwnedObject(%this);
	%reversevalue = %value * $TAC::ReverseFactor;
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
	if((!%clientId.AdminIsImmune) && (%clientId != %adminCl))
	{
		if(($TAC::PunishmentTime == "") || ($TAC::PunishmentTime <= 0))
			$TAC::PunishmentTime = 300;
		if(%enable)
		{
			//put client in purgatory
			if(%clientId.purgatory != true)
			{
				%clientId.purgatory = true;
				%clientId.purgtime = GetSimTime() + $TAC::PunishmentTime;
				BanList::add(%ip, $TAC::PunishmentTime);
				processMenuPickTeam(%clientId, -2, %adminCl);
				schedule("Admin::PurgMode(" @ %clientId @ ",false," @ %ip @ ", 0);",$TAC::PunishmentTime);
				if(%adminCl == 0)
				{
					Messageall(0, Client::getName(%clientId) @ " has been sent to Purgatory for " @ $TAC::PunishmentTime @ " seconds.");
					echo("TAC - ",Client::getName(%clientId)," (",%clientId,") has been sent to Purgatory");
				}
				else
				{
					Messageall(0, Client::getName(%clientId) @ " has been sent to Purgatory by " @ Client::getName(%adminCl) @ " for " @ $TAC::PunishmentTime @ " seconds.");
					AdminAction(Client::getName(%adminCl) @ " (" @ %adminCl @ ") sent " @ Client::getName(%clientId) @ " (",%clientId,") to purgatory");
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
				echo("TAC - ",Client::getName(%clientId)," (",%clientId,") has been released from Purgatory");
			}
			else
			{
				Messageall(0, Client::getName(%clientId) @ " has been returned from Purgatory by " @ Client::getName(%adminCl) @ ".");
				echo("TAC - ",Client::getName(%clientId)," (",%clientId,") has been released from Purgatory by", Client::getName(%adminCl),"(",%adminCl,")");
			}
		}
	}
}





//-------- TAC Userlist --  Wizard_TPG

exec(TACUserList);

// Used on Client Connect.
function TAC_Authenticate(%clientId, %ip)
{
	if($UserList::Activated)
	{
		%clientId.ip = %ip;
		%name = Client::getName(%clientId);
		%clientId.usernumber = 0;
		for(%i=1;%i < $UserList::MaxUsers+1;%i++)
		{
			if(%name == $UserList::UserName[%i])
			{
				if((%clientId.usernumber==0) && ($UserList::UserIP1[%i] != ""))
					if(TACCompareIP($UserList::UserIP1[%i],%ip))
						%clientId.usernumber = %i;
				if((%clientId.usernumber==0) && ($UserList::UserIP2[%i] != ""))
					if(TACCompareIP($UserList::UserIP2[%i],%ip))
						%clientId.usernumber = %i;
				if((%clientId.usernumber==0) && ($UserList::UserIP3[%i] != ""))
					if(TACCompareIP($UserList::UserIP3[%i],%ip))
						%clientId.usernumber = %i;
			}
		}
		if(%clientId.usernumber)
		{
			%clientId.UserLevel = $UserList::UserLevel[%clientId.usernumber];
			%clientId.UserIP1 = $UserList::UserIP1[%clientId.usernumber];
			%clientId.UserIP2 = $UserList::UserIP2[%clientId.usernumber];
			%clientId.UserIP3 = $UserList::UserIP3[%clientId.usernumber];
			echo("TAC: User: ",%name," Identified. Access Level: ",$UserList::UserLevel[%clientId.usernumber]);
			TACMsg("User: " @ %name @ " Identified. Access Level: " @ $UserList::UserLevel[%clientId.usernumber]);

			for(%i = 1; %i < $UserList::MaxClasses+1; %i++)
				if($UserList::AdminName[%i] == %clientId.UserLevel)
					if($Userlist::AdminAutoLogin[%i] == true)
					{
						TACSetClientAdmin(%clientId);
						TACMsg(%name @ " Automatically Logged in.");
					}
		}
		else
		{
			%clientId.UserLevel = 0;
			echo("TAC: User: ",%name," Unknown.");
		}
	}
	else
		%clientId.usernumber = 0;
}


function TACCompareIP(%userlistip,%currentip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%currentip,3,16);
	for(%i = 7; %i < TACStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = TACStrLen(%currentstring)+1;
		}
	}
	//convert currentip into 4 variables
	%currentipspace = TACDotToSpace(%currentipstring);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	//convert userlistip into 4 variables
	%userlistipspace = TACDotToSpace(%userlistip);
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

function TACDotToSpace(%string)
{
	%x = 0;
	%i = 0;
	// MODERN-PORT: bounded -- an address with fewer than three dots (a LOOPBACK
	// listen host whose name is in the user list) never left this loop.
	while(%x<3 && %i < 64)
	{
		%char = String::getSubStr(%string,%i,1);
		if(!String::ICompare(%char, "."))		{
			%left = String::getSubStr(%string,0,%i);
			%right = String::getSubStr(%string,%i+1,(TACStrLen(%string)-%i));
			%string = strcat(%left," ",%right);
			%x++;
		}
		%i++;
	}
	return %string;
}

function TACStrLen(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
		%length = %i;
	%length++;
	return %length;
}

function TACSetClientAdmin(%clientId)
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

function TACGroupAdmin(%password,%clientId)
{
	for(%i = 1; %i < $UserList::MaxGroups+1; %i++)
	{
		if($UserList::GroupPass[%i] != "" && $UserList::GroupPass[%i] == %password)
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
			Client::sendMessage(%clientId, 1,"TAC: You have logged in successfully as a group level " @ $UserList::GroupLevel[%i]);
			TACMsg(Client::getName(%clientId) @ " Logged in as a group level " @ $UserList::GroupLevel[%i]);
		}
	}
}


// Msg All Admins on Server.
function TACMsg(%msg)
{
	%numPlayers = getNumClients();
    for(%i = 0; %i < %numPlayers; %i++)
    {
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
	            Client::sendMessage(%pl, 0, "TAC: " @ %msg);
	}
}

// Output server admin log.
function AdminAction(%message)
{
	if($TAC::adminlog == "true")
	{
		echo("TAC: ",%message);
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
	TACSmurfTimer(false);
	if(!String::NCompare(%ip, "LOOPBACK", 8))
	{
		//Ignore Loopback dude
	}
	else
	{
		%rawip = TACConvertIP(%ip);

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

function remoteAbility(%client,%clientId,%smurfkey)
{
	if(%smurfkey)
		%clientId.SmurfKey = true;
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
				if(TACCompareIP(getWord($CurrentSmurfRecord[%Smurf2ID,1],%i),%ip))
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
	if($TAC::KeepSmurfLog = "true")
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
		echo("TAC: Smurf Record Log Saved");
	}
}

function DisplaySmurf(%adminId, %selectId)
{
	if($TAC::KeepSmurfLog = "true")
	{
		if(((%adminId.AdminReferee) && ($TAC::AdminSmurfApp)) || (%adminId.AdminServerSettings) || (%adminId.SmurfKey))
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

function TACConvertIP(%ip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%ip,3,16);
	for(%i = 7; %i < TACStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = TACStrLen(%currentstring)+1;
		}
	}
	%ip = %currentipstring;
	return %ip;
}

function TruncateIP(%rawip)
{
	%currentipspace = TACDotToSpace(%rawip);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	%rawip = %currip[1] @ "." @ %currip[2] @ "." @ %currip[3] @ ".*";
	return %rawip;
}

function TACSmurfTimer(%repeat)
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
		schedule("TACSmurfTimer(true);",60);
	}
}

if($TAC::KeepSmurfLog == "true")
{
	$StartSmurfTimerRunning = true;
	LoadSmurfRecord();
	$SmurfInitialCheck = false;
}
