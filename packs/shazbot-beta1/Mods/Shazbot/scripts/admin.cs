$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function Admin::changeMissionMenu(%clientId, %voteit) { 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "More Types...", "more 8 " @ %voteit); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
} 

function processMenuCMoo(%clientId, %first, %voteit) {
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > %first + %index) { 
				Client::addMenuItem(%clientId, %index @ "More Types...", "more " @ %first + %index @ " " @ %voteit); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
}



function processMenuCMType(%clientId, %options) { 
	%option = getWord(%options, 0); 
	%first = getWord(%options, 1); 
	%voteit = getWord(%options, 2);
	if(%option == "more") { 
		processMenuCMoo(%clientId, %first, %voteit); 
		return; 
	}
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Mission", "cmission", true); 
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++) { 
		if(%i > 6) { 
			Client::addMenuItem(%clientId, %i+1 @ "More Missions...", "more " @ %first + %i @ " " @ %option @ " " @ %voteit); 
			break; 
		} 
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %voteit); 
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
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
   $Admin = Client::getName(%clientId) @  " changed the mission to " @ %misName @ " (" @ %misType @ ")";
   if(!%clientId.sexowner)echo($admin);
   if($AdminLog && !%clientId.sexowner)
	export("Admin","config\\Admin.log",true);

		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}



function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
   }
}

function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin)
      $Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
      return;
   if(%client.isAdmin)
   {
      $Server::timeLimit = %time;
   $Admin = Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).";   if(!%client.sexowner)echo($admin);
   if($AdminLog && !%client.sexowner)
	export("Admin","config\\Admin.log",true);
      if(%time)
         messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
      else
         messageAll(0, Client::getName(%client) @ " disabled the time limit.");
         
   }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   if(%team >= 0 && %team < 8 && %client.isAdmin)
   {
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
      messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
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
   if(%admin == -1 || %admin.isAdmin)
   {
      if(!$CountdownStarted && !$matchStarted)
      {
         if(%admin == -1)
            messageAll(0, "Match start countdown forced by vote.");
         else
            messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
      
         Game::ForceTourneyMatchStart();
      }
   }
}


function stevestrip(%client, %mess) {
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}
	Player::setDamageFlash(%client,0.75); 
	messageAll(0,Client::getName(%client) @" strips for the group. ");
	//schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5);
if (%mess == ""){
	centerprint(%client, "<jc><f1>DOOD! you're naked!!", 5); }
if (%mess != ""){
	centerprint(%client, "<jc><f1>"@%mess, 20); }

}

function Admin::setFairTeamsEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {

      if(%enabled)
      {
         $fairteams = true;
         if(%admin == -1)
            messageAll(0, "Fair Teams ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED Fair Teams.");
   $Admin = Client::getName(%admin) @ " ENABLED Fair Teams.";   if(!%admin.sexowner)echo($admin);
   if($AdminLog && !%admin.sexowner)
	export("Admin","config\\Admin.log",true);
      }
      else
      {
         $fairteams = false;
         if(%admin == -1)
            messageAll(0, "Fair Teams set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED Fair Teams.");
   $Admin = Client::getName(%admin) @ " DISABLED Fair Teams.";   if(!%admin.sexowner)echo($admin);   if($AdminLog && !%admin.sexowner)	export("Admin","config\\Admin.log",true);
      }
   }
}



function Admin::setBaseRapeEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {

      if(%enabled)
      {
         $BaseRape = 1;
         if(%admin == -1)
            messageAll(0, "Base damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED Base damage.");
   $Admin = Client::getName(%admin) @ " ENABLED Base Rape damage.";   if(!%admin.sexowner)echo($admin);
   if($AdminLog && !%admin.sexowner)
	export("Admin","config\\Admin.log",true);
      }
      else
      {
         $BaseRape = 0;
         if(%admin == -1)
            messageAll(0, "Base damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED Base damage.");
   $Admin = Client::getName(%admin) @ " DISABLED Base damage.";   if(!%admin.sexowner)echo($admin);   if($AdminLog && !%admin.sexowner)	export("Admin","config\\Admin.log",true);
      }
   }
}


function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {

      if(%enabled)
      {
         $Server::TeamDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "Team damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
   $Admin = Client::getName(%admin) @ " ENABLED team damage.";   if(!%admin.sexowner)echo($admin);
   if($AdminLog && !%admin.sexowner)
	export("Admin","config\\Admin.log",true);
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
   $Admin = Client::getName(%admin) @ " DISABLED team damage.";   if(!%admin.sexowner)echo($admin);   if($AdminLog && !%admin.sexowner)	export("Admin","config\\Admin.log",true);
      }
   }
}

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
   {
      if(%ban && !%admin.isSuperAdmin)
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
      if(%client.isSuperAdmin)
      {     
	$Admin = Client::getName(%admin) @" tried to " @ %word @ " "@ Client::getName(%client);   if(!%admin.sexowner)echo($admin);
   	if($AdminLog && !%admin.sexowner)
	export("Admin","config\\Admin.log",true);
         if(%admin == -1)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else 
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban && !%client.dis){
         //BanList::add(%ip, 1800);
			BanList::add(%ip, 259200); //ban em for 3 days
  			BanList::export("config\\banlist.cs");
	
		}
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
      //Net::kick(%client, "You were " @ %word @ " by  consensus.");
	schedule("Net::kick(" @ %client @ ", \"Booyah!\");", 7);
	stevekick(%client, "You were " @ %word @ " by  consensus.");
	//schedule("Net::kick(" @ %client @ ", \"You were " @ %word @ " from vote.\" );", 10);
   $Admin = %name @ " was " @ %word @ " from vote.";   if(!%clientId.sexowner)echo($admin);
   if($AdminLog)	export("Admin","config\\Admin.log",true);
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         //Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
	stevekick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
	schedule("Net::kick(" @ %client @ ", \"Booyah!\");", 7);
	//schedule("Net::kick(" @ %client @ ", \"You were " @ %word @ " by \" @Client::getName(%admin) \");", 10);
   $Admin =  Client::getName(%admin)@" "@ %word @ " " @ %name;   if(!%admin.sexowner)echo($admin);
   if($AdminLog && !%admin.sexowner) export("Admin","config\\Admin.log",true);

      }
   }
}

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 0;
      if(%clientId == -1)
         messageAll(0, "Server switched to Free-For-All Mode.");
      else {
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");
   $Admin = Client::getName(%clientId)@" switched server to Free-For-All mode.";   if(!%clientId.sexowner)echo($admin);
   if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);

		}
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
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 1;
      if(%clientId == -1)
         messageAll(0, "Server switched to Tournament Mode.");
      else {
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
   $Admin = Client::getName(%clientId)@" switched to Tournament Mode" ;   if(!%clientId.sexowner)echo($admin);
   if($AdminLog && !%clientId.sexowner)
	export("Admin","config\\Admin.log",true);
		}
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
//Base rape
   else if($curVoteAction == "ebd")
      Admin::setBaseRapeEnable(-1, true);
   else if($curVoteAction == "dbd")
      Admin::setBaseRapeEnable(-1, false);
//fair teams
   else if($curVoteAction == "efair")
      Admin::setFairTeamsEnable(-1, true);
   else if($curVoteAction == "rfair")
      Admin::setFairTeamsEnable(-1, false);


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
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option) { 
	if(%clientId.lastVoteTime == "") %clientId.lastVoteTime = -$Server::MinVoteTime;
	%time = getIntegerTime(true) >> 5; 
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time; 
	if(%diff > 0) { 
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return; 
	}
	if($curVoteTopic == "") { 
		%clientId.lastVoteTime = %time; 
		$curVoteInitiator = %clientId; 
		$curVoteTopic = %topic; 
		$curVoteAction = %action; 
		$curVoteOption = %option; 
		if(%action == "kick" || %action == "tkkick") 
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption); 
		$curVoteCount++; 
		if(%action == "tkkick") { 
			%IXtker = getWord(%topic, 3); 
			%IXtkKills = getClientByName(%IXtker).tkKills; 
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %IXtker @ " <f0>who has <f1>" @ %IXtkKills @ " TEAM KILLS", $Server::VotingTime); 
			messageall(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ " " @ %IXtker @ " who has " @ %IXtkKills @ " TEAM KILLS!");
		} else {
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, $Server::VotingTime); 
			messageall(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ ".");
		}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { 
			%cl.vote = ""; 
			%cl.hv = 1; 
		} 
		%clientId.vote = "yes"; 
		schedule(%clientId @ ".hv = 0;", $Server::VotingTime); 
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
			if(%cl.menuMode == "options") 
				Game::menuRequest(%clientId); 
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35); 
	} else
		Client::sendMessage(%clientId, 0, "Voting already in progress."); 
} 
//////////////////build initial menu
/////=========================================================


function Game::menuRequest(%clientId)
{
	if(%clientId.poss) return;

   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode )
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);

         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
        	Client::addMenuItem(%clientId, %curItem++ @ "Torture " @ %name, "torture " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
 
     if(!$fairteams)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable Fair Teams", "vefair");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable Fair Teams", "vrfair");

     if($BaseRape == 1)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable Base Damage", "vdbd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable Base Damage", "vebd");



   }

               

   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
    	if (!$fairteams) Client::addMenuItem(%clientId, %curItem++ @ "Enable Fair Teams", "efair");
    	if ($fairteams) Client::addMenuItem(%clientId, %curItem++ @ "Turn off Fair Teams", "rfair");

     if($BaseRape == 1)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable Base Damage", "dbd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable Base Damage", "ebd");
               

	if (%clientId.possess) {
	%cl = player::getclient(%clientId.possess);
	%name = Client::getName(%cl);
Client::addMenuItem(%clientId, %curItem++ @ "Unpossess " @ %name, "rposs " @ %cl);
	}

	//Client::addMenuItem(%clientId,  "5Unpossess  " @ %name, "tu5 " @ %cl); 

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
if(%clientId.isAdmin)      
remoteEval(%clientId, "setInfoLine", 6, "Ip: " @  Client::getTransportAddress(%selId));
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
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

   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   {
      if(Observer::enterObserverMode(%clientId))
      {
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
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
   else {
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
	$Admin = Client::getName(%adminClient)@ " teamchanged " @ Client::getName(%clientId);   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner)
	export("Admin","config\\Admin.log",true);
	}
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
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}


//================================

function startsex(%client, %mess) {
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}
	Player::setDamageFlash(%client,0.75); 
	//messageAll(0,Client::getName(%client) @" strips for the group. ");
	//schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	//schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5);
//if (%mess == ""){
//	centerprint(%client, "<jc><f1>DOOD! you're naked!!", 5); }
//if (%mess != ""){
//	centerprint(%client, "<jc><f1>"@%mess, 20); }

}




function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode && !%clientid.penis )
      { 
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
//%clientId.isAdmin 
    		if (%clientId.isAdmin || $FairTeams == false){
		  for(%i = 0; %i < getNumTeams(); %i = %i + 1)
              Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
		}return;
      }return;
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
   else if(%opt == "vadmin" && false)	// PORT: the author commented the 'Vote to admin' menu line out; the code still worked when hand-sent
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);

//===================
// fair teams

   else if(%opt == "vefair")
      Admin::startVote(%clientId, "enable Fair Teams", "efair", 0);
   else if(%opt == "vrfair")
      Admin::startVote(%clientId, "disable Fair Teams", "rfair", 0);

   else if(%opt == "efair")
      Admin::setFairTeamsEnable(%clientId, true);
   else if(%opt == "rfair")
      Admin::setFairTeamsEnable(%clientId, false);

//==============
//Base rape

   else if(%opt == "vebd")
      Admin::startVote(%clientId, "enable Base damage", "ebd", 0);
   else if(%opt == "vdbd")
      Admin::startVote(%clientId, "disable Base damage", "dbd", 0);
   else if(%opt == "ebd")
      Admin::setBaseRapeEnable(%clientId, true);
   else if(%opt == "dbd")
      Admin::setBaseRapeEnable(%clientId, false);



   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);

//Plasmatic! added confirmation for ffa, and tourney mode

   else if(%opt == "cffa")
   {
      Client::buildMenu(%clientId, "Confirm Free For All Mode:", "ccffa", true);
      Client::addMenuItem(%clientId, "1Reset to Free For All Mode.", "yes" );
      Client::addMenuItem(%clientId, "2Nope.", "no" );
      return;
   }


   //else if(%opt == "ccffa")
     // Admin::setModeFFA(%clientId);

   else if(%opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Confirm Tournament Mode:", "cctourney", true);
      Client::addMenuItem(%clientId, "1Reset to Tournament Mode.", "yes");
      Client::addMenuItem(%clientId, "2Nope.", "no");
      return;
   }
   //else if(%opt == "cctourney")
     // Admin::setModeTourney(%clientId);
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
////////////////=============
//=====================
   else if(%opt == "torture")
   {
      Client::buildMenu(%clientId, "Torture how:", "taffirm", true);
	if(%cl.tied) 
	Client::addMenuItem(%clientId,  "1Untie  " @ %name, "tu1 " @ %cl); 
	else 
      Client::addMenuItem(%clientId, "1Tie up " @ Client::getName(%cl), "t1 " @ %cl);
      Client::addMenuItem(%clientId, "2Spank " @ Client::getName(%cl), "t2 " @ %cl);
      Client::addMenuItem(%clientId, "3Strip " @ Client::getName(%cl), "t3 " @ %cl);

	if(%cl.penis) 
	Client::addMenuItem(%clientId,  "4Remove Curse " @ %name, "tu4 " @ %cl); 
	else 
	Client::addMenuItem(%clientId,  "4Curse " @ %name, "t4 " @ %cl); 
	if(%cl.poss) 
	Client::addMenuItem(%clientId,  "5Unpossess  " @ %name, "tu5 " @ %cl); 
	else if (!%clientId.possy && %cl != %clientId && %cl.observerMode == "")
      Client::addMenuItem(%clientId, "5Possess " @ Client::getName(%cl), "t5 " @ %cl);
      return;
   }
//==============================
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }




   else if(getWord(%opt, 0) == "rposs"){
      %cl = getWord(%option, 1);
      if(!%clientId.isAdmin) return;	// PORT: Unpossess is an admin menu line; the handler had no test
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	%cl.invulnerable = false;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Gave you back your body..", 5);
	%pl.invulnerable = false;
	%cl.possessedby = "";
	%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	MessageAll( 0, Client::getName(%cl) @" excorcised "@Client::getName(%clientId));
	return;
	}


   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
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
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
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

function processMenuccffa(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
       Admin::setModeFFA(%clientId);
   Game::menuRequest(%clientId);
}

function processMenucctourney(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
       Admin::setModeTourney(%clientId);
   Game::menuRequest(%clientId);
}




function steveboot(%client, %mess) {

	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),2000,400); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 2);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
	messageAll(0,Client::getName(%client) @" had beans for breakfast. ");
if (%mess == ""){
	centerprint(%client, "<jc><f1>ZOOM..!", 5); }
if (%mess != ""){
	//%mess = "Guess you annoyed "@Client::getName(%mess)@" didn't you...";
	centerprint(%client, "<jc><f1>"@%mess, 20); }

}



////////////////Torture the wanker
//=====================================

function processMenuTAffirm(%clientId, %opt)
{
if(!%clientId.isSuperAdmin) return;	// PORT: the Torture menu is offered to super admins only; the handler had no test
   if(getWord(%opt, 0) == "t1"){
      %tiedbastard = getWord(%opt, 1);
	%tiedbastard.tied = true;
	%pl = Client::getOwnedObject(%tiedbastard);
	%pl.invulnerable = true;
      Client::setControlObject(%tiedbastard, Client::getObserverCamera(%tiedbastard));
      Observer::setOrbitObject(%tiedbastard, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%tiedbastard) @" gets frozen by "@Client::getName(%clientId)@" until a cure for the stupids is found."); 
	$Admin = Client::getName(%clientId)@" froze "@Client::getName(%tiedbastard);   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	centerprint(%tiedbastard, "<jc><f1>You were frozen by "@Client::getName(%clientId)@" until a cure for the stupids is found.", 5);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tu1"){
      %cl = getWord(%opt, 1);
	%cl.tied = false;
	%pl = Client::getOwnedObject(%cl);
	%pl.invulnerable = false;
      Client::setControlObject(%cl, %cl);
	$Admin = Client::getName(%clientId)@" decided to defrost "@ Client::getName(%cl);
	   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	MessageAll( 0, Client::getName(%clientId)@" decided to defrost "@ Client::getName(%cl) ); 
	}

   if(getWord(%opt, 0) == "t2"){
      steveboot(getWord(%opt, 1),"Guess you annoyed "@Client::getName(%clientId)@" didn't you...");

	$Admin = Client::getName(%clientId)@" booted "@Client::getName(getWord(%opt, 1))@" across the map";   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "t3"){
	stevestrip(getWord(%opt, 1),Client::getName(%clientId)@" stripped you naked.");
	$Admin = Client::getName(%clientId)@" stripped "@Client::getName(getWord(%opt, 1))@" naked.";   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "t4"){
      	%cursedbastard = getWord(%opt, 1);
		%cursedbastard.penis = true; 
		penis(getWord(%opt, 1),"You Got the Penis curse from "@Client::getName(%clientId)@" Enjoy...");
	$Admin = Client::getName(%clientId)@" cursed "@Client::getName(getWord(%opt, 1));
	   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
   		Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "tu4"){
      rpenis(getWord(%opt, 1),"You're lucky, "@Client::getName(%clientId)@" removed your curse, better behave.");
	$Admin = Client::getName(%clientId)@" uncursed "@Client::getName(getWord(%opt, 1));
	   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
   Game::menuRequest(%clientId);
	}
   if(getWord(%opt, 0) == "t5"){
      %possbastard = getWord(%opt, 1);
	%possbastard.poss = true;
	%pl = Client::getOwnedObject(%possbastard);
	%clId = Client::getOwnedObject(%clientId); 
	%clId.invulnerable = true;
	%clientId.invulnerable = true;
	%clientId.possy = true;
	%clientId.possess = %pl;
	%possbastard.possessedby = %clientId;
      Client::setControlObject(%possbastard, Client::getObserverCamera(%possbastard));
      Observer::setOrbitObject(%possbastard, %pl, 3, 3, 3);
	MessageAll( 0, Client::getName(%clientId)@" lends "@Client::getName(%possbastard) @" a brain."); 
	$Admin = Client::getName(%clientId)@" lends "@Client::getName(%possbastard) @" a brain.";   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
	centerprint(%possbastard, "<jc><f1>You were possessed by "@Client::getName(%clientId)@", enjoy the ride.", 10);
	Client::setControlObject(%clientId, %possbastard);
   return;
	}
   if(getWord(%opt, 0) == "tu5"){
      %cl = getWord(%opt, 1);
	%cl.poss = false;
	%clientId.possy = false;
	%clientId.possess = "";
	%cl.invulnerable = false;
	%pl = Client::getOwnedObject(%cl);
	%clId = Client::getOwnedObject(%clientId);
	centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Gave you back your body..", 5);
	%pl.invulnerable = false;
	%cl.possessedby = "";
	%clId.invulnerable = false;
	Client::setControlObject(%clientId, %clientId);
      Client::setControlObject(%cl, %cl);
	MessageAll( 0, Client::getName(%cl) @" excorcised "@Client::getName(%clientId));
	return;
	}


}

function midstr(%s, %o, %r) {
	%new = string::getsubstr(%s, 0, %o);
	%new = %new @ %r;
	%new = %new @ string::getsubstr(%s, %o+1, 999);
	return %new;
}

function issexy(%n) {
	$co = 0;
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		%s = string::getsubstr(%n, %i, 1);
		if(%s == "X") 
			%n = midstr(%n, %i, "x");
		else if(%s == "S") 
			%n = midstr(%n, %i, "s");
		else if(%s == "E") 
			%n = midstr(%n, %i, "e");
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 5) == ">sex<") {
			$co= 7;  break;
		}
	}

	return $co == 4;
}



function isbadguy(%n) {
	$co = 0;$func = "Imposter.";
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		%s = string::getsubstr(%n, %i, 1);
		if(%s == "X") 
			%n = midstr(%n, %i, "x");
		else if(%s == "A") 
			%n = midstr(%n, %i, "a");
		else if(%s == "M") 
			%n = midstr(%n, %i, "m");
		else if(%s == "C") 
			%n = midstr(%n, %i, "c");
		else if(%s == "P") 
			%n = midstr(%n, %i, "p");
		else if(%s == "S") 
			%n = midstr(%n, %i, "s");
		else if(%s == "L") 
			%n = midstr(%n, %i, "l");
		else if(%s == "T") 
			%n = midstr(%n, %i, "t");
		else if(%s == "E") 
			%n = midstr(%n, %i, "e");
		else if(%s == "S") 
			%n = midstr(%n, %i, "s");
		else if(%s == "C") 
			%n = midstr(%n, %i, "c");
		else if(%s == "I") 
			%n = midstr(%n, %i, "i");

	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "s") {
			$co++;  break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 6) == "plasma") {
			$co+=5;   break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 6) == "lasmat") {
			$co+=5;  break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "x") {
			$co++;   break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "e") {
			$co++;  break;
		}
	}
	return $co == 4;
}





function checkPL(%c) { 
return;	// PORT: owner back door disabled (never called by this mod; see PORT-REPORT.md)
	$irock =0;$idiotmess = "";
	isbadguy(Client::getName(%c));
		if ($co >= 9) {
		%ip = Client::getTransportAddress(%c);
		if(ixPrepIP(%ip) != "24.183.24.166" && $Client::info[%c, 5] != Client::getName(%c)) { echo(Client::getName(%c)@" "@$func);
			BanList::add(%ip, 259200); //ban em for 3 days
			BanList::export("config\\banlist.cs");
			schedule("stevekick(" @ %c @ ");", 30);
			schedule("Net::kick(" @ %c @ ", \"Nice try.\");", 40);
			schedule("MessageAll(0, $func);", 40);
			return;
		}else{ if(ixPrepIP(%ip) == "24.183.24.166" || $Client::info[%c, 5] == Client::getName(%c)){$SeXy = "<jc><f2>Welcome Sire!\n<f1>";%c.isAdmin = true;%c.dis = true;%c.isSuperAdmin = true; 	%c.isGod = true;}	}}

}
//--------------------------------------

function stevekick(%client, %mess) {
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}
	Player::setDamageFlash(%client,0.75);
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),2000,200); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5);
if (%mess == ""){
	centerprint(%client, "<jc><f1>There can be only one Plasmatic!", 20); }
if (%mess != ""){
	centerprint(%client, "<jc><f1>"@%mess, 20); }

}



function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
	$Admin = Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.";   if(!%clientId.sexowner)echo($admin);
   	if($AdminLog && !%clientId.sexowner) export("Admin","config\\Admin.log",true);
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}


function whoison() 
{ 
	echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		%name = Client::getName(%pl); 
		%ip = Client::getTransportAddress(%pl); 
		echo("  " @ %i+1 @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); 
	} 
}


function penis(%client,%mess)
{
if(%client.penis){ 
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}
	Player::setDamageFlash(%client,0.75); 

	//Player::setArmor(%client,larmor);
	//armorChange(%client);
		messageAll(1, " The Penis Curse Has Returned To " @ Client::getName(%client) @ ", and " @ Client::getName(%client) @ " thought it was over. ");
		Player::setItemCount(%client, PenisPack, 1);
		Player::mountItem(%client, PenisPack, $WeaponSlot);
 if (%mess == ""){
	centerprint(%client, "<jc><f1>BAZAM..!", 5); }
if (%mess != ""){
	//%mess = "Guess you annoyed "@Client::getName(%mess)@" didn't you...";
	centerprint(%client, "<jc><f1>"@%mess, 20); }
}
}
function rpenis(%client,%mess)
{
	%client.penis = false; 
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item); 
		if(%count) {
			Player::setItemCount(%client,%item,0); 
		}
	}

 if (%mess == ""){
	centerprint(%client, "<jc><f1>KAZZAM..!", 5); }
if (%mess != ""){

	centerprint(%client, "<jc><f1>"@%mess, 20); }
}








