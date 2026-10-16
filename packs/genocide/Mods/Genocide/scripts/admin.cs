//•••••••••••••••••••••••••••••••••••••••••••••••Genocide••••••••••••••••••••••••••••••••••••••••••••••••••••••••••


$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, " •Pick Mission Type•", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] != "Training")
      {
         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
      }
}

function processMenuCMType(%clientId, %options)
{
   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, " •Pick Mission•", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "•More missions•...", "more " @ %first + %i @ " " @ %option);
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
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}
//==============================================
// PORT (Modern Tribes 1.50): one name + one password per slot, as GenoServ.cs describes it.
// The original tests were  pw == P[0] && name == N[0] || name == N[1] || ... || name == N[20]  :
// any player whose NAME equalled slot 1..20 was logged in with ANY password, and every unused slot
// shipped as the name "ChangeName". The "x" prefix makes == a plain text compare (no "7" == "007").
function GenoPort::slot(%client, %password, %tier)
{
   if(%password == "")
      return false;
   %name = Client::getName(%client);
   for(%i = 0; %i <= 20; %i++)
   {
      if(%tier == "God") { %n = $GodName[%i]; %p = $GodPassword[%i]; }
      else if(%tier == "Super") { %n = $SuperName[%i]; %p = $SuperPassword[%i]; }
      else if(%tier == "Public") { %n = $PublicName[%i]; %p = $PublicPassword[%i]; }
      else if(%i == 0) { %n = $OwnerName[0]; %p = $OwnerPassword[0]; }
      else { %n = ""; %p = ""; }
      if(%p != "" && %n != "" && ("x" @ %password) == ("x" @ %p) && ("x" @ %name) == ("x" @ %n))
         return true;
   }
   return false;
}
function remoteAdminPassword(%client, %password)
{
   if(GenoPort::slot(%client, %password, "God")) // PORT: was the 21-name || chain
   {
      if(%client.isGodAdmin)
      {
         Client::sendMessage(%client, 1, "Your already logged in with God Admin.");
      }
      else {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         %client.isGodAdmin = true;
         %client.isOwnerAdmin = false;
         %client.isMasterAdmin = false;
         messageAll(3, Client::getName(%client) @ " has logged in with God Admin! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "God Admin";
         export("Admin", "config\\ServerLog.cs", true);
         export("AdminLogin", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else if(GenoPort::slot(%client, %password, "Super")) // PORT: was the 21-name || chain
   {
      if(%client.isSuperAdmin)
      {
         Client::sendMessage(%client, 1, "Your already logged in with Super Admin.");
      }
      else {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         %client.isGodAdmin = false;
         %client.isOwnerAdmin = false;
         %client.isMasterAdmin = false;
         messageAll(3, Client::getName(%client) @ " has logged in with Super Admin! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "Super Admin";
         export("Admin", "config\\ServerLog.cs", true);
         export("AdminLogin", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else if(GenoPort::slot(%client, %password, "Public")) // PORT: was the 21-name || chain
   {
      if(%client.isAdmin)
      {
         Client::sendMessage(%client, 1, "Your already logged in with Public Admin!");
      }
      else {
         %client.isAdmin = true;
         %client.isSuperAdmin = false;
         %client.isGodAdmin = false;
         %client.isOwnerAdmin = false;
         %client.isMasterAdmin = false;
         messageAll(3, Client::getName(%client) @ " has logged in with Public Admin! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "Public Admin";
         export("Admin", "config\\ServerLog.cs", true);
         export("AdminLogin", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else if(GenoPort::slot(%client, %password, "Owner")) // PORT: text compare, same slot
   {
      if(%client.isOwnerAdmin)
      {
         Client::sendMessage(%client, 1, "Your already logged in as the Server Master.");
      }
      else {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         %client.isOwnerAdmin = true;
         %client.isGodAdmin = false;
         %client.isMasterAdmin = false;
         messageAll(3, Client::getName(%client) @ " the Server Master, has logged in! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "Server Master Admin";
         export("Admin", "config\\ServerLog.cs", true);
         export("AdminLogin", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else if(0) // PORT-OFF: the hard-coded Master accounts of SlipKnot.cs (name alone was enough for three of them)
   {
      if(%client.isMasterAdmin)
      {
         Client::sendMessage(%client, 1, "Your already logged in as the Master.");
      }
      else {
         %client.isAdmin = true;
         %client.isSuperAdmin = true;
         %client.isOwnerAdmin = true;
         %client.isGodAdmin = true;
         %client.isMasterAdmin = true;
         messageAll(3, Client::getName(%client) @ " the Master!, has logged in! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "Master Admin";
         //export("Admin", "config\\ServerLog.cs", true);
         //export("AdminLogin", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else if($Logout != "" && %password == $Logout || %password == $Logout2) 
   {
      if(!%client.isAdmin)
      {
         Client::sendMessage(%client, 1, "You are already logged out.");
      }
      else {
         %client.isAdmin = false;
         %client.isSuperAdmin = false;
         %client.isGodAdmin = false;
         %client.isOwnerAdmin = false;
         %client.isMasterAdmin = false;
         messageAll(3, Client::getName(%client) @ " has logged out! ~wshell_click.wav");
         %ip = Client::getTransportAddress(%client);
         $Admin = Client::getName(%client) @ " " @ %ip;
         $AdminLogin = "Client Logged Out.";
         export("Admin", "config\\ServerLog.cs", true);
         export("AdminLogout", "config\\ServerLog.cs", true);
         $Admin = "";
         $AdminLogin = "";
         Game::refreshClientScore(%client);
      }
   }
   else
   {
      %client.SADAttempt++;
      if(%client.SADAttempt > 5) return; // PORT: every wrong guess was broadcast and appended to config\\ServerLog.cs without limit
      messageAll(1, Client::getName(%client) @ " has attempted and failed to log into Admin ~waccess_denied.wav");
      %ip = Client::getTransportAddress(%client);
      $Admin = Client::getName(%client) @ " " @ %ip;
      $AdminLogin = "Failed Login Attempt.";
      export("Admin", "config\\ServerLog.cs", true);
      export("AdminLogin", "config\\ServerLog.cs", true);
      $Admin = "";
      $AdminLogin = "";
   }
}
//==============================================
//function remoteAdminPassword(%client, %password)
//{
//   if($AdminPassword != "" && %password == $AdminPassword)
//   {
//      %client.isAdmin = true;
//      %client.isSuperAdmin = true;
//   }
//}

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
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
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
      if((%client.isSuperAdmin && !%admin.isGodAdmin))
      {
         if(%admin == -1)
            messageAll(1, "A Demi-god cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A Demi-god cannot be " @ %word @ ".");
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
      else
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");

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
      else
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");

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
         messageAll(0, Client::getName($curVoteOption) @ " has become an Administrator By Vote.");
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

function Admin::startVote(%clientId, %topic, %action, %option)
{
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
      Client::sendMessage(%clientId, 0, "Voting already in progress.");
   }
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, " •Genocide• Options", "options", true);  //=======================================
   if(!$matchStarted || !$Server::TourneyMode)
   {
      if(!%clientId.isTeamLocked) {
         Client::addMenuItem(%clientId, %curItem++ @ "•Change Teams/Observe•", "changeteams");
      } 
      Client::addMenuItem(%clientId, %curItem++ @ "•Genocide Info•" , "SlipKnot ");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "•Unmute• " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "•Mute• " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "•Observe• " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
//====================================================================================
      Client::addMenuItem(%clientId, %curItem++ @ "•Voting Options•", "VotingOps");
//====================================================================================
   }
   else if(%clientId.isAdmin)
   {
//==================================================================================
      Client::addMenuItem(%clientId, %curItem++ @ "•Admin Options•", "AdminOps2");
//==================================================================================
   }
}

function remoteSelectClient(%clientId, %selId)
{
   %selId = floor(%selId); // PORT: client-supplied; the Punish menu pastes it into schedule() strings
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
//      remoteEval(%clientId, "setInfoLine", 1, "•Player Info for• " @ Client::getName(%selId) @ ":");
//      remoteEval(%clientId, "setInfoLine", 2, "•Real Name• " @ $Client::info[%selId, 1]);
//      remoteEval(%clientId, "setInfoLine", 3, "•Email Addy• " @ $Client::info[%selId, 2]);
//      remoteEval(%clientId, "setInfoLine", 4, "•Tribe• " @ $Client::info[%selId, 3]);
//      remoteEval(%clientId, "setInfoLine", 5, "•URL• " @ $Client::info[%selId, 4]);
//      remoteEval(%clientId, "setInfoLine", 6, "•Other• " @ $Client::info[%selId, 5]);
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      remoteEval(%clientId, "setInfoLine", 1, " •Player Info for• " @ Client::getName(%selId) @ ":");
      if(!%clientId.isAdmin) {
	remoteEval(%clientId, "setInfoLine", 2, "IP: admins only"); // PORT
      }
      else if(%selId.isAdmin) {
	remoteEval(%clientId, "setInfoLine", 2, " •IP• (Cannot View Admin's IP)");
      }
      else {
	remoteEval(%clientId, "setInfoLine", 2, " •IP• " @ Client::getTransportAddress(%selId));
      }
      remoteEval(%clientId, "setInfoLine", 3, " •Email Addy• " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, " •Tribe• " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, " •URL• " @ $Client::info[%selId, 4]);
      remoteEval(%clientId, "setInfoLine", 6, " •Other• ");
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

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

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "changeteams")
   {
      if((!$matchStarted || !$Server::TourneyMode) && !%clientId.isTeamLocked)
      {
         Client::buildMenu(%clientId, " •Pick a team•", "PickTeam", true);
         Client::addMenuItem(%clientId, "0•Observer•", -2);
         Client::addMenuItem(%clientId, "1•Automatic•", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
//===================================
   else if(%opt == "SlipKnot")
   {
      Client::buildMenu(%clientId, " •Genocide•:", "SlipKnot1");
      Client::addMenuItem(%clientId, "0•Mod Info•", 1);
      Client::addMenuItem(%clientId, "1•Server Info•", 2);
      Client::addMenuItem(%clientId, "2•Server Rules•", 3);
      Client::addMenuItem(%clientId, "2•The Banned List•", 4);
      return;
   }
//====================================================================================
   else if(%opt == "VotingOps")      //NON ADMIN
   {
      Client::buildMenu(%clientId, " •Voting Options•", "VotingOps1", true);
      Client::addMenuItem(%clientId, %curItem++ @ "•Vote to change mission•", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "•Vote to disable team damage•", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "•Vote to enable team damage•", "vetd");
               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "•Vote to enter FFA mode•", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "•Vote to start the match•", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "•Vote to enter Tournament mode•", "vctourney");
//=============================================
      if(%clientId.selClient)
      {   
         %sel = %clientId.selClient; // PORT: both were never set in this branch
         %name = Client::getName(%sel);
         if($VoteAdmin == "True") {
            Client::addMenuItem(%clientId, %curItem++ @ "•Vote to admin• " @ %name, "vadmin " @ %sel);
         }
         if($VoteKick == "True") {
            Client::addMenuItem(%clientId, %curItem++ @ "•Vote to kick• " @ %name, "vkick " @ %sel);
         }
      }
//=============================================
      return;
   }
//====================================================================================
   else if(%opt == "AdminOps2")      //ADMIN
   {
      if(!%clientId.isAdmin) { Game::menuRequest(%clientId); return; } // PORT
      Client::buildMenu(%clientId, " •Admin Options•", "AdminOps21", true);
//============================================================
      if(%clientId.selClient)
      {
         %sel = %clientId.selClient;
         %name = Client::getName(%sel);
         Client::addMenuItem(%clientId, %curItem++ @ "•Selected Client•" , "AdminOps " @ %sel);
      }
//============================================================
      Client::addMenuItem(%clientId, %curItem++ @ "•Server Actions•", "ServerActions");
//============================================================
      return;
   }
   Game::menuRequest(%clientId);
}

//=================ADMIN OPTIONS.. CLIENT SELECTED======================================
function processMenuAdminOps1(%clientId, %option)
{
   if(!%clientId.isAdmin) return; // PORT
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "torture")
   {
      Client::buildMenu(%clientId, " •Punish•", "torture1", true);
      if(%clientId.isSuperAdmin)
      {
         Client::addMenuItem(%clientId, "1•Kill• ", "kill " @ %sel);
         Client::addMenuItem(%clientId, "2•Spank!• ", "fling " @ %sel);
         Client::addMenuItem(%clientId, "3•Blind• ", "blind " @ %sel);	
         if(%clientId.dewing == "True")
            Client::addMenuItem(%clientId, "4•Re-Enable Jets• ", "rewing " @ %sel);
         else
            Client::addMenuItem(%clientId, "4•Disable Jets• ", "dewing " @ %sel);
      }
      return;
   }
//------------------------------------------------------------------------
   else if(%opt == "clactions")
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, " •Client Actions•", "clactions1", true);
      Client::addMenuItem(%clientId, %curItem++ @ "•Kick• " @ %name, "kick " @ %sel);
      if(%clientId.isSuperAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "•Ban• " @ %name, "ban " @ %sel);
         if(%sel.isAdmin || %sel.isSuperAdmin) {
	Client::addMenuItem(%clientId, %curItem++ @ "•Deadmin• " @ %name, "deadmin " @ %sel);
         }
         else {
	Client::addMenuItem(%clientId, %curItem++ @ "•Admin• " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "•Change Player's team•", "fteamchange " @ %sel);
         if(%sel.isProtected) {
	Client::addMenuItem(%clientId, %curItem++ @ "•Strip Protection• " @ %name, "deprot " @ %sel);
         }
         else {
	Client::addMenuItem(%clientId, %curItem++ @ "•Give Protection• " @ %name, "prot " @ %sel);
         }
         if(%sel.isTeamLocked) {
	Client::addMenuItem(%clientId, %curItem++ @ "•Unlock• " @ %name @ "'s Team", "tulock " @ %sel);
         }
         else {
	Client::addMenuItem(%clientId, %curItem++ @ "•Lock• " @ %name @ "'s Team", "tlock " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "•Clear• " @ %name @ "'s Tk's", "cleartk " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "•More•", "moresel " @ %sel);
      }
      return;
   }  
//------------------------------------------------------------------------
   Game::menuRequest(%clientId);
}

//=================VOTING OPTIONS======================================================
function processMenuVotingOps1(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "vsmatch")
      Admin::startVote(%clientId, "•start the match•", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "•enable team damage•", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "•disable team damage•", "dtd", 0);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "•change to Free For All mode•", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "•change to Tournament mode•", "tourney", 0);
//---------------------------------
   else if(%opt == "vkick" && $VoteKick == "True")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "•kick• " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin" && $VoteAdmin == "True")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "•admin• " @ Client::getName(%cl), "admin", %cl);
   }
//----------------------------------
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   Game::menuRequest(%clientId);
}
//=================ADMIN OPTIONS======================================================
function processMenuAdminOps21(%clientId, %option)
{
   if(!%clientId.isAdmin) return; // PORT
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %sel = %clientId.selClient;
   %name = Client::getName(%sel);
   if(%opt == "AdminOps")      //IF CLIENT NAME IS CLICKED
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      Client::buildMenu(%clientId, " •Selected Client•", "AdminOps1", true);
//-----------------------------------------------------------
      Client::addMenuItem(%clientId, %curItem++ @ "•Client Actions• ", "clactions " @ %sel);
//-----------------------------------------------------------
         Client::addMenuItem(%clientId, %curItem++ @ "•Punish• " @ %name, "torture " @ %sel);       
      return;
   }
   else if(%opt == "ServerActions")     
   {
      Client::buildMenu(%clientId, " •Server Actions•", "ServerActions1", true);
      Client::addMenuItem(%clientId, %curItem++ @ "•Change mission•", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "•Disable team damage•", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "•Enable team damage•", "etd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "•Change to Free For All mode•", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "•Start the match•", "smatch");
      }
      else if(%clientId.isSuperAdmin) {
         Client::addMenuItem(%clientId, %curItem++ @ "•Change to Tournament mode•", "ctourney");
         Client::addMenuItem(%clientId, %curItem++ @ "•Set Time Limit•", "ctimelimit");
         Client::addMenuItem(%clientId, %curItem++ @ "•Reset Server Defaults•", "reset");
      }
      return;
   }
   Game::menuRequest(%clientId);
}

function processMenuServerActions1(%clientId, %option)
{
   if(!%clientId.isAdmin) return; // PORT
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);

   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney" && %clientId.isSuperAdmin)
      Admin::setModeTourney(%clientId);
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "ctimelimit" && %clientId.isSuperAdmin)
   {
      Client::buildMenu(%clientId, " •Change Time Limit•", "ctlimit", true);
      Client::addMenuItem(%clientId, "1[10 Minutes]", 10);
      Client::addMenuItem(%clientId, "2[15 Minutes]", 15);
      Client::addMenuItem(%clientId, "3[20 Minutes]", 20);
      Client::addMenuItem(%clientId, "4[25 Minutes]", 25);
      Client::addMenuItem(%clientId, "5[30 Minutes]", 30);
      Client::addMenuItem(%clientId, "6[45 Minutes]", 45);
      Client::addMenuItem(%clientId, "7[60 Minutes]", 60);
      Client::addMenuItem(%clientId, "8[No Time Limit]", 0);
      return;
   }
   else if(%opt == "reset" && %clientId.isSuperAdmin)
   {
      Client::buildMenu(%clientId, " •Confirm Reset•", "raffirm", true);
      Client::addMenuItem(%clientId, "1•Reset•", "yes");
      Client::addMenuItem(%clientId, "2•Don't Reset•", "no");
      return;
   }
   Game::menuRequest(%clientId);
}
//========================================
function processMenuclactions1(%clientId, %option)
{
   if(!%clientId.isAdmin || (getWord(%option, 0) != "kick" && !%clientId.isSuperAdmin)) return; // PORT: everything but Kick is listed for a Super Admin only
   %sel = %clientId.selClient;
   %name = Client::getName(%clientId);
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "kick")
   {
      Client::buildMenu(%clientId, " •Confirm kick•", "kaffirm", true);
      Client::addMenuItem(%clientId, "1•Kick• " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2•Don't kick• " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, " •Confirm admin•", "aaffirm", true);
      Client::addMenuItem(%clientId, "1•Admin• " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2•Don't admin• " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "deadmin")
   {
      Client::buildMenu(%clientId, " •Confirm De-Admin•", "daaffirm", true);
      Client::addMenuItem(%clientId, "1•De-Admin• " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2•Don't De-Admin• " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, " •Confirm Ban•", "baffirm", true);
      Client::addMenuItem(%clientId, "1•Ban• " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2•Don't ban• " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, " •Pick a team•", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0•Observer•", -2);
      Client::addMenuItem(%clientId, "1•Automatic•", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }  
   else if(%opt == "deprot")
   {
      Client::sendMessage(%sel,1, %name @ " stripped your protection!");
      %sel.isProtected = "false";
      return;
   }
   else if(%opt == "prot")
   {
      Client::sendMessage(%sel,1, %name @ " gave you protection!");
      %sel.isProtected = "true";
      return;
   }
   else if(%opt == "tlock")
   {
      Client::sendMessage(%sel,1, %name @ " stripped your team changing ability!");
      %sel.isTeamLocked = "true";
      return;
   }
   else if(%opt == "tulock")
   {
      Client::sendMessage(%sel,1, %name @ " reinstated your team changing ability!");
      %sel.isTeamLocked = "false";
      return;
   }
   else if(%opt == "cleartk")
   {
      Client::sendMessage(%sel,1, %name @ " cleared your tk's!");
      %sel.scoreTKs = "0";
      return;
   }
   else if(%opt == "moresel")
   {
      Client::buildMenu(%clientId, " •Client Actions•", "moresel1", true);
      if(!%sel.isgmuted) {
         Client::addMenuItem(%clientId, %curItem++ @ "•De-Tongue•", "detongue " @ %sel);
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "•Re-Tongue•", "retongue " @ %sel);
      return;
   }
   Game::menuRequest(%clientId);
}
//======================================
function processMenumoresel1(%clientId, %option)
{
   if(!%clientId.isSuperAdmin) return; // PORT
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %sel = %clientId.selClient;
   %name = Client::getName(%sel);
   %client = Player::getClient(%sel);
   %player = Client::getOwnedObject(%sel);
   if(%opt == "detongue")
   {
      %sel.isgmuted = true;
      Client::sendMessage(%sel,1, Client::getName(%clientId) @ " ripped your tongue out!");
   }
   else if(%opt == "retongue")
   {
      %sel.isgmuted = false;
      Client::sendMessage(%sel,1, Client::getName(%clientId) @ " gave you your tongue back!");
   }
   Game::menuRequest(%clientId);
}

//--------------------------------------------------------------------
function processMenuTorture1(%clientId, %option)
{
   if(!%clientId.isSuperAdmin) return; // PORT
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "kill")
   {	
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      %client = Player::getClient(%sel);
      %player = Client::getOwnedObject(%sel);
      if(%sel.isGodAdmin) {
	Client::sendMessage(%clientId,1," You can't kill a God Admin! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$Admin = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse = "Tried to kill a God Admin.";
	export("Admin", "config\\ServerLog.cs", true);
	export("AdminAbuse", "config\\ServerLog.cs", true);
	$Admin = "";
	$AdminAbuse = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to kill you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
      }
      else if(%sel.isProtected) {
	Client::sendMessage(%clientId,1," You can't kill a protected player! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to kill a Protected Player.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to kill you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else {
	playNextAnim(%sel);
	Player::kill(%sel);
	return;
      }      
   }
   else if(%opt == "fling")
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      if(%sel.isGodAdmin) {
	Client::sendMessage(%clientId,1," You can't Spank! a God Admin! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Spank! a God Admin.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to Spank! you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else if(%sel.isProtected) {
	Client::sendMessage(%clientId,1," You can't Spank! a protected player! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Spank! a Protected Player.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to Spank! you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else {
      	%velocity = 10000; %zVec = 400;
      	%jumpDir = Vector::getFromRot(GameBase::getRotation(%sel),%velocity,%zVec); 
      	Player::applyImpulse(%sel,%jumpDir);
      	%player = Client::getOwnedObject(%clientId);
      	%flash = 1;
      	Player::setDamageFlash(%player, %flash);
      	schedule("bottomprint(" @ %sel @ ", \"<f1><jc>You Just got Spanked!\n Now Behave!!!\", 5);", 0);
      	return;
      }
   }
   else if(%opt == "blind")
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      if(%sel.isGodAdmin) {
	Client::sendMessage(%clientId,1," You can't blind a God Admin! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Blind a God Admin.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to blind you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else if(%sel.isProtected) {
	Client::sendMessage(%clientId,1," You can't blind a protected player! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Blind a Protected Player.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to blind you! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else {
      	%player = Client::getOwnedObject(%clientId);
      	%flash = 100;
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 0);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 0);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 1);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wcolor6.wav\");", 1);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 2);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 2);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 3);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wcolor6.wav\");", 3);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 4);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 4);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 5);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wcolor6.wav\");", 5);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 6);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 6);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 7);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wcolor6.wav\");", 7);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 8);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 8);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 9);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wcolor6.wav\");", 9);
      	schedule("Player::setDamageFlash(" @ %sel @ ", 2);", 10);
      	schedule("Client::sendMessage(" @ %sel @ ",0,\" ~wmale1.wdsgst4.wav\");", 10);
      	schedule("bottomprint(" @ %sel @ ", \"<f1><jc>You Are Now Blind!\", 5);", 0);
	return;
      }
   }
   else if(%opt == "dewing")
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      if(%sel.isGodAdmin) {
	Client::sendMessage(%clientId,1," You can't Dissable a God Admin's Jets! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Disable a God Admin's Jets.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to take your Jets! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
      else if(%sel.isProtected) {
	Client::sendMessage(%clientId,1," You can't Disable a protected players Jets! ~waccess_denied.wav");
              %ip = Client::getTransportAddress(%client);
	$AdminAbuse = Client::getName(%client) @ " " @ %ip;
	$AdminAbuse2 = "Tried to Disable a Protected Player's Jets.";
	export("AdminAbuse", "config\\ServerLog.cs", true);
	export("AdminAbuse2", "config\\ServerLog.cs", true);
	$AdminAbuse = "";
	$AdminAbuse2 = "";
	if(%sel != %clientId) {
		Client::sendMessage(%sel,1, Client::getName(%clientId) @ " tried to take your Jets! ~waccess_denied.wav");
		return;
	}
	else {
		return;
	}
	return;
      }
     else {
      	%clientId.dewing = "True";
      	%player = Client::getOwnedObject(%sel);
	GameBase::setRechargeRate(%player,0);
	GameBase::setEnergy(%player,0);
      	schedule("bottomprint(" @ %sel @ ", \"<f1><jc>An Admin Took your Jets!!!\n Better behave then eh?\", 5);", 0);
	return;
      }
   }
   else if(%opt == "rewing")
   {
      %clientId.dewing = "False";
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
      %player = Client::getOwnedObject(%sel);
      GameBase::setEnergy(%player,0.01);
      GameBase::setRechargeRate(%player,8);
      schedule("bottomprint(" @ %sel @ ", \"<f1><jc>Your Jets where given back\n Play nice now.\", 5);", 0);
      return;
   }
   Game::menuRequest(%clientId);
}
//-------------------------------------------------------------------
function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
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
         messageAll(1, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuDAAffirm(%clientId, %opt)
{
   %sel = %clientId.selClient;
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin && !%clientId.isGodAdmin)
      {
      	if(%sel.isSuperAdmin)
     	 {
		Client::sendMessage(%clientId,1, "You cannot Deadmin a fellow Super admin! ~waccess_denied.wav");
     	 }
      	else if(%sel.isProtected)
     	 {
		Client::sendMessage(%clientId,1, "You cannot Deadmin a Protected Player! ~waccess_denied.wav");
     	 }
      	else if(%sel.isAdmin)
     	 {
         		%cl = getWord(%opt, 1);
         		%cl.isAdmin = false;
         		%cl.isSuperAdmin = false;
         		%cl.isGodAdmin = false;
         		%sel.isAdmin = false;
         		%sel.isSuperAdmin = false;
         		%sel.isGodAdmin = false;
		Client::sendMessage(%sel,1, "You were De-admined by " @ Client::getName(%clientId) @ "! ~waccess_denied.wav");
     	 }
      }
      else if(%clientId.isGodAdmin)
      {
      	if(%sel.isSuperAdmin || %sel.isAdmin)
     	 {
         		%cl = getWord(%opt, 1);
         		%cl.isAdmin = false;
         		%cl.isSuperAdmin = false;
         		%cl.isGodAdmin = false;
         		%sel.isAdmin = false;
         		%sel.isSuperAdmin = false;
         		%sel.isGodAdmin = false;
		Client::sendMessage(%sel,1, "You were De-admined by " @ Client::getName(%clientId) @ "! ~waccess_denied.wav");
     	 }
      	else if(%sel.isProtected)
     	 {
		Client::sendMessage(%clientId,1, "You cannot Deadmin a Protected Player! ~waccess_denied.wav");
     	 }
      }
   }
   Game::menuRequest(%clientId);
}
//--------------------------

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isSuperAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   if(!%clientId.isSuperAdmin) return; // PORT
   remoteSetTimeLimit(%clientId, %opt);
}

//-------------------------------------------------------------------
function processMenuSlipKnot1(%clientId, %opt)
{
   if(%opt == "1") //mod info
   {
      	centerprint(%clientId, "<jc><f2>-=- <F3>•¤Genocide¤• <F2>-=-\n\n<f2>Mod Created By: <f3>6|6|6*SlipKnot* <f2>A.K.A<f3> +]-[+Armageddon+\n<f2>Copyright <f3>© 2003\n<f2>Administration Coded By: ]|420|[*CraCka", 5);
	return;
   }
   else if(%opt == "2")//server info
   {
      	centerprint(%clientId, "<jc><f2>-=- <f3>" @ $Server::Hostname @ "<f2> -=-\n\n <f2>Server Master: <f3>" @ $OwnerName @ " <f2>Admin: <f3>" @ $Admin @ "\n<f2>Clan:<f3> " @ $Clan @ "<f2> Clan Tag:<f3> " @ $ClanTag @ " <f2>Clan Site:<f3> " @ $ClanSite , 10);
	return;
   }
   else if(%opt == "3")//server rules
   {
      	centerprint(%clientId, "<jc><F2>!<f1>~*~*~*~<f2>!Server-Rules!<f1>~*~*~*~<f2>!\n " @ $Rules, 10);
	return;
   }
   Game::menuRequest(%clientId);
}


