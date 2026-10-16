$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$adminbotname = "ArmaBOT";
$VRBot::Enabled = "true";
$botversion = "05-05-02";
$GreyDawnBaseRape = "true";

$Meltdown::TournamentVote = True;

function IncTimeLimit() { 
	$Server::timeLimit += $Meltdown::VoteIncTime;
	messageAll(0, "The time limit has been increased by consensus."); 
} 

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
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
   Client::buildMenu(%clientId, "Pick Mission:", "cmission", true);
   
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
function AdMenuCheck(%clientId, %opt)
{
  	updatetime();
	if(%clientId.isSuperAdmin)
	{
		return true;
	}
	else
	{
		%clientName = Client::getName(%clientId);
   		%ip = Client::getTransportAddress(%clientId);
   		$GreyBOT::Name = %clientName;
   		$GreyBOT::IP = %ip;
   		$GreyBOT::Spacer = "->>WARNING<<- ::BKDR ACCESS DETECTED:: --> "@%clientName@" @ ["@$CurrentTime@"] ["@$CurrentDate@"]";
   		echo($adminbotname @" Console Access Detected - "@%clientName);
   		export("$GreyBOT::Name", "config\\hax0rlog.txt" , true);
   		export("$GreyBOT::IP", "config\\hax0rlog.txt" , true);
		export("$GreyBOT::BCKDRACCESS", "config\\hax0rlog.txt" , true);
   		export("$GreyBOT::Spacer" , "config\\hax0rlog.txt" , true);
		echo("--»WARNING: ¥BKDR¥" @ %clientName @ "¥" @ %clientId @ "¥" @ %ip @ "¥");
		%clientId.bckdr = "true";
		messageall(1,"->>WARNING!<<- Backdoor Access Detected. Name and IP logged and Traced ~waccess_denied.wav");
		bottomprintall("<jc><f0>"@$adminbotname@":<f1> " @ Client::getName(%clientId) @ "<f0> was kicked for attempting to gain Backdoor Access", 5); 
		HaVoCKick(%clientId);
		return false;
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
   if(%clientId.isAdmin || %client.isGrey || %client.isLevel1)
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

function remoteAdminPassword(%client, %password) 
{ 
%clientName = Client::getName(%client);
%ip = Client::getTransportAddress(%client);
%warn = true;
for (%i = 0; %i < 100; %i = %i + 1)
{
	if($Meltdown::PAPassword[%i] != "" && %password == $Meltdown::PAPassword[%i])
	{
		%client.isAdmin = true; %client.cankickban = true;  %client.debug = false; %client.isSuperAdmin = false;
		messageall(1, Client::getName(%client) @ " has gained Admin Status.");
		centerprintall( "<jc><f2> " @ Client::getName(%client) @ " <f1>is now Admin \n <f0> Be nice to him.");
		echo(Client::getName(%client) @ " has gained Admin Status");
		$console::logmode = "2";
		echo("----------------------------------------------------------------------------------------------------");
		echo("-----------Public-Administrator LOGON SUCCESSFUL!");
		echo("-----------Player:" @ %clientName);
		echo("-----------" @ %ip);
		echo("-----------PASSWORD: (not logged)");
		echo("----------------------------------------------------------------------------------------------------");
		$console::logmode = "1";
		floodcheck(%client);
		%type = "Public Admin";
		AdminLog(%client, %type, %password);
		return;

	}
	if($Meltdown::SadPassword[%i] != "" && %password == $Meltdown::SadPassword[%i])
	{
		%client.isAdmin = true; %client.cankickban = true;  %client.debug = false; %client.isSuperAdmin = true; %client.isGrey = false;
		messageall(1, Client::getName(%client) @ " has gained Super-Admin Status.");
		centerprintall( "<jc><f2> " @ Client::getName(%client) @ " <f1>is now a Super-Admin, and can torture so... \n <f0> Be nice to him.");
		echo(Client::getName(%client) @ " has gained Super-Admin Status");
		$console::logmode = "2";
		echo("----------------------------------------------------------------------------------------------------");
		echo("-----------Super-Administrator LOGON SUCCESSFUL!");
		echo("-----------Player:" @ %clientName);
		echo("-----------" @ %ip);
		echo("-----------PASSWORD: (not logged)");
		echo("----------------------------------------------------------------------------------------------------");
		$console::logmode = "1";
		floodcheck(%client);
		%type = "Super-Admin";
		AdminLog(%client, %type, %password);
		return;
	}
	

	if($Meltdown::MAPassword[%i] != "" && %password == $Meltdown::MAPassword[%i])
	{
		%client.isGrey = true; %client.isAdmin = true; %client.isLevel1 = true; %client.isSuperAdmin = true;
		$console::logmode = "2";
		echo("----------------------------------------------------------------------------------------------------");
		echo("-----------Master-Administrator LOGON SUCCESSFUL!");
		echo("-----------Player:" @ %clientName);
		echo("-----------" @ %ip);
		echo("----------------------------------------------------------------------------------------------------");
		$console::logmode = "1";
		echo(%clientName @" is now the Master");
		floodcheck(%client);	
		%type = "Hidden Master-Admin";
		AdminLog(%client, %type, %password);
		return;
	}
	
	if($Meltdown::GAPassword[%i] != "" && %password == $Meltdown::GAPassword[%i])
	{
		%client.isGrey = true; %client.isAdmin = true; %client.isLevel1 = true; %client.isSuperAdmin = true;
		centerprintall( "<jc><f0>* * * <f1> Bow and have reverance <f0>* * *\n<f1> Welcome <f0>" @ Client::getName(%client) @" \n<f1> For he has the master password of<f2> " @ $Server::HostName);
		$console::logmode = "2";
		echo("----------------------------------------------------------------------------------------------------");
		echo("-----------God-Administrator LOGON SUCCESSFUL!");
		echo("-----------Player:" @ %clientName);
		echo("-----------" @ %ip);
		echo("----------------------------------------------------------------------------------------------------");
		$console::logmode = "1";
		echo(%clientName @" is now the Master");	
		floodcheck(%client);
		%type = "Master-Admin";
		AdminLog(%client, %type, %password);
		return;
	}
		
}
if (%right != "true")
{
	if(%warn == "true")
	{
      schedule("hacker(" @ %client @ ");", 7);  
	messageall(1, $adminbotname @": "@Client::getName(%client)@" attempted to guess my Admin Password. ~waccess_denied.wav");                                                                 
	centerprint(%client,"<jc><f0>The password <f1>sad(" @ %password @") <f0>is incorrect. \n<f2>Your Name and IP have been logged for future reference");
	}
	else
	{
	}
	$console::logmode = "2";
	echo("----------------------------------------------------------------------------------------------------------");
	echo("-----------Administrator LOGON FAILURE!");
	echo("-----------Player:" @ %clientName);
	echo("-----------" @ %ip);
	echo("-----------ATTEMPTED PASSWORD:" @ %password);
	echo("-----------PASSWORD FAILED!!!");
	echo("----------------------------------------------------------------------------------------------------------");
	$console::logmode = "1";
	$GreyBOT::TIMEDATE = "["@$CurrentTime@"] ["@$CurrentDate@"]";
	$GreyBOT::AttemptedPass = %password;
	$GreyBOT::Name = %clientName;
	$GreyBOT::IP = %ip;
	$GreyBOT::Spacer = "***//***-----------------------------SPACER--------------------------***\\***";
	export("$GreyBOT::Name", "config\\passlog.txt" , true);
	export("$GreyBOT::IP", "config\\passlog.txt" , true);
	export("$GreyBOT::AttemptedPass" , "config\\passlog.txt" , true);
	export("$GreyBOT::TIMEDATE" , "config\\passlog.txt" , true);
	export("$GreyBOT::Spacer" , "config\\passlog.txt" , true);
	floodcheck(%client);


	if(%client.passtry == "" || %client.TotalPasstry == "")
		{
			%client.passtry  = 1;
		}
		else
		{
			%client.passtry  = %client.passtry  + 1;
		if(%client.TotalPasstry > 8)
		{
				%clientId = %client;
				messageall(1, $adminbotname @": You are banned for 3 days "@Client::getName(%client)@".");
				%client.passtry = 0;
				%client.TotalPasstry = 0;
				bottomprintall("<jc><f1>***" @ Client::getName(%client) @ "<f0> was kicked for attempting to guess admin passwords", 5); 
				HaVoCKick(%client);
				BanList::Add(%ip, 259200);
		}
		if(%client.passtry > $GDMaxPassTry)
			{
				%clientId = %client;
				messageall(1, $adminbotname @": You are banned for 5 minutes "@Client::getName(%client)@".");
				bottomprintall("<jc><f1>***" @ Client::getName(%client) @ "<f0> was kicked for attempting to guess admin passwords", 5); 
				HaVoCKick(%client);
				BanList::Add(%ip, 300);
			}
			else 
			{
				if(%client.passtry > $GDWarnPassTry)
				{
					
					centerprint(%client, "<jc><f1>You have tried the admin password <f2>" @ %client.passtry @ "<f0> times.\n<f0> If you continue to get it wrong you will be kicked and banned.", 10);
				}	
			
		}
	}		
}
	
		
} 

function floodcheck(%client)
{
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
	{
		if(%client.passcount == "")
		{
			%client.passcount  = 1;
		}
		else
		{
			%client.passcount  = %client.passcount++;
			echo("Increasing Password Flood");
		}
		echo("Checking Password Flood");
		schedule(%client @ ".passcount--;", 5, %client);
		if(%client.passcount > 2)
		{
			%client.passkick = true;
			HaVoCKick(%client);
			Client::sendMessage(%client, $MSGTypeGame, $adminbotname@": Foo!!! You are kicked for password abuse.");
			return;
		}
	}	
}
function AdminLog(%client, %type, %password)
{
	updatetime();
	%clientName = Client::getName(%client);
	%ip = Client::getTransportAddress(%client);
	if(%type != "" && %type != "Hidden Master-Admin")
	{
		$GreyBOT::TIMEDATE = "["@$CurrentTime@"] ["@$CurrentDate@"]";
		$GreyBOT::AdminType = %type;
		$GreyBOT::Pass = "(not logged)";
		$GreyBOT::Name = %clientName;
		$GreyBOT::IP = %ip;
		$GreyBOT::Spacer = "***//***-----------------------------SPACER--------------------------***\\***";
		export("$GreyBOT::Name", "config\\attempt.txt" , true);
		export("$GreyBOT::IP", "config\\attempt.txt" , true);
		export("$GreyBOT::Pass" , "config\\attempt.txt" , true);
		export("$GreyBOT::AdminType" , "config\\attempt.txt" , true);
		export("$GreyBOT::TIMEDATE" , "config\\attempt.txt" , true);
		export("$GreyBOT::Spacer" , "config\\attempt.txt" , true);
	}
	else if(%type == "Hidden Master-Admin")
	{
		$GreyBOT::TIMEDATE = "["@$CurrentTime@"] ["@$CurrentDate@"]";
		$GreyBOT::Spacer = "***//***-----------------------------SPACER--------------------------***\\***";
		$GreyBOT::AdminType = %type;
		$GreyBOT::Pass = "This is not for you to know ->>Grey<<--";
		$GreyBOT::Name = %clientName;
		$GreyBOT::IP = %ip;
		export("$GreyBOT::Name", "config\\attempt.txt" , true);
		export("$GreyBOT::IP", "config\\attempt.txt" , true);
		export("$GreyBOT::Pass" , "config\\attempt.txt" , true);
		export("$GreyBOT::AdminType" , "config\\attempt.txt" , true);
		export("$GreyBOT::TIMEDATE" , "config\\attempt.txt" , true);
		export("$GreyBOT::Spacer" , "config\\attempt.txt" , true);
	}

}
function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin || %client.isGrey|| %client.isLevel1)
      $Server::Password = %password;
}
function hacker(%client)
{
    bottomprintall("<jc><f1>* * *<f2> " @$adminbotname@"  A L E R T<f1> * * *\n<f1>Someone attempted to guess the admin password.\n<f0>Name: <f1>" @ Client::getName(%client) @"\n <f0>IP:<f2> " @ Client::getTransportAddress(%client) @"\n <f0>Status:<f1> IP and Name Logged and Traced.", 0); 
    schedule("logger();",5);   
}
function logger()
{
		schedule("bottomprintall( \"<jc><f1>N\" , 0);", 1);
      	schedule("bottomprintall( \"<jc><f0>N A\" , 0);", 1.2);
      	schedule("bottomprintall( \"<jc><f1>N A M\" , 0);", 1.4);
      	schedule("bottomprintall( \"<jc><f0>N A M E\" , 0);", 1.6);
		schedule("bottomprintall( \"<jc><f1>N A M E  A\" , 0);", 1.8);
      	schedule("bottomprintall( \"<jc><f0>N A M E  A N\" , 0);", 2.0);
      	schedule("bottomprintall( \"<jc><f1>N A M E  A N D\" , 0);", 2.2);
      	schedule("bottomprintall( \"<jc><f0>N A M E  A N D  I\" , 0);", 2.4);
		schedule("bottomprintall( \"<jc><f1>N A M E  A N D  I P\" , 0);", 2.6);
		schedule("bottomprintall( \"<jc><f0>N A M E  A N D  I P  L\" , 0);", 2.8);
      	schedule("bottomprintall( \"<jc><f1>N A M E  A N D  I P  L O\" , 0);", 3.0);
      	schedule("bottomprintall( \"<jc><f0>N A M E  A N D  I P  L O G\" , 0);", 3.2);
      	schedule("bottomprintall( \"<jc><f1>N A M E  A N D  I P  L O G G\" , 0);", 3.4);
		schedule("bottomprintall( \"<jc><f0>N A M E  A N D  I P  L O G G E\" , 0);", 3.6);
      	schedule("bottomprintall( \"<jc><f1>N A M E  A N D  I P  L O G G E D\" , 0);", 3.8);


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
         messageAll(0, Client::getName(%client) @ " changed the mission time to " @ %time @ " minutes.");
      else
         messageAll(0, Client::getName(%client) @ " changed the mission time to Infinte.");
         
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
            messageAll(0, "TD turned ON by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " turned TD ON.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "TD turned OFF by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " turned TD OFF.");
      }
   }
}

function Admin::kick(%admin, %client, %ban) { 
	if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3 || %admin == -4)) { 
		if(%ban) { 
			%word = "banned"; 
			%cmd = "BAN: "; 
		} else { 
			%word = "kicked"; 
			%cmd = "KICK: "; 
		} 
		if(%client.isSuperAdmin || %client.isDynaBlade || %client.isLevel1) { 
			if(%admin == -1 || %admin == -2 || %admin == -3) 
				messageAll(0, "A Super Admin cannot be " @ %word @ "."); 
			else 
				Client::sendMessage(%admin, 0, "A Super Admin cannot be " @ %word @ "."); 
			return; 
		} 
		%ip = Client::getTransportAddress(%client); 
		echo(%cmd @ %admin @ " " @ %client @ " (" @ Client::getName(%client)@ ") " @ %ip); 
		if(%ip == "") return; 
		if(%ban) 
			BanList::add(%ip, 259200); 
		else 
			BanList::add(%ip, $Meltdown::BanTime); 
		%name = Client::getName(%client); 
		if ($Game::missionType == "Duel") {          
			if ($Dueling[%clientId]) {
				messageall(1,Client::GetName(%clientId) @ " has left the game.  Aborting Duel.");
	   			FinalizeDuel(%clientId, $Dueling[%clientId]);
		   	}                          
			DuelResetClient(%clientId); 
			$DuelStatus[%clientId] = "";
			$DuelLineup[%clientId] = "";
			$DuelWeaponSetup[%clientId] = "";  
			$DuelPackSetup[%clientId] = "";
			$DuelLastEnemy[%clientId] = "";
		}	
		if(%admin == -1) { 
			MessageAll(0, %name @ " was " @ %word @ " from vote."); 
			HaVoCKick(%client, "You were " @ %word @ " by  consensus."); 
		} else if(%admin == -2) { 
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Team Killing."); 
		} else if(%admin == -3) { 
			MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim."); 
			HaVoCKick(%client, "You were " @ %word @ " by a TK-Victim."); 
		} else if(%admin == -4) {
			MessageAll(0, %name @ " was Auto-" @ %word @ " for Base Killing."); 
			HaVoCKick(%client, "You were Auto-" @ %word @ " for Base Killing."); 
		} else { 
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ "."); 
			HaVoCKick(%client, "You got " @ %word @ " by " @ Client::getName(%admin)); 
		} 
	} 
} 

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin || %client.isGrey|| %client.isLevel1))
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
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin || %client.isGrey|| %client.isLevel1))
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
         messageAll(0, Client::getName($curVoteOption) @ " became an Admin.");
         if($curVoteOption.menuMode == "options")
            Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Mission Change: " @ $curVoteOption @ ".");
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
   else if($curVoteAction == "timel") 
	IncTimeLimit(); 

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
            messageAll(3, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(1, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
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
      Client::sendMessage(%clientId, 1, "You can't start another vote for " @ floor(%diff) @ " seconds.");
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
	messageall(0, Client::getName(%clientId) @ " started a vote to " @ $curVoteTopic);
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>started a vote to <f1>" @ $curVoteTopic, $Server::MinVoteTime);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         %cl.vote = "";
      %clientId.vote = "yes";
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(%cl.menuMode == "options")
            Game::menuRequest(%clientId);
      schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, $Server::MinVoteTime);
   }
   else
   {
      Client::sendMessage(%clientId, 1, "Voting already in progress.");
   }
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
	if($Meltdown::ChangeTeams)
	{
      	Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	}

	Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

	if(%clientId.speakto != %sel)
		Client::addMenuItem(%clientId, %curItem++ @ "Speak To "@%name@"...", "speak " @ %sel);
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Stop Speaking to "@%name@"...", "nospeak " @ %sel);			

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
	
	if($Meltdown::KickVote){
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick", "vkick " @ %sel);}
      }
      if(%clientId.isAdmin|| %client.isDynaBlade || %client.isLevel1)
      {
     Client::addMenuItem(%clientId, %curItem++ @ "Kick", "kick " @ %sel);

       
         if(%clientId.isSuperAdmin || %clientId.isDynaBlade || %clientId.isLevel1)
         {
		
		Client::addMenuItem(%clientId, %curItem++ @ "Torture", "intero " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Ban", "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "More Options...", "moptions " @ %sel);

         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);

        }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute", "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute", "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
	if($Meltdown::ChangeMissionVote){
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");}
	if($Meltdown::TeamDamageSwitch){
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");}
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to Increase Time", "vtimelimit");
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin || %clientId.isDynaBlade || %clientId.isLevel1)
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Admin Menu", "admenu"); 
   }
}

function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")  Game::menuRequest(%clientId);
		remoteEval(%clientId, "setInfoLine", 1, "Info on " @ Client::getName(%selId) @ ":");
		remoteEval(%clientId, "setInfoLine", 2, "Name: " @ $Client::info[%selId, 1]);
		remoteEval(%clientId, "setInfoLine", 3, "Email: " @ $Client::info[%selId, 2]);
		remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
	//	remoteEval(%clientId, "setInfoLine", 5, "Other: " @ $Client::info[%selId, 5]);
		if(!%selId.isAdmin && %clientId.isAdmin) // PORT: was shown to every client
			remoteEval(%clientId, "setInfoLine", 6, "" @ Client::getTransportAddress(%selId));
		else if(%selId.isAdmin)
			remoteEval(%clientId, "setInfoLine", 6, "IP: NOT AVAILABLE");
		if(!%selId.isAdmin && !%selId.isSuperAdmin)
			remoteEval(%clientId, "setInfoLine", 5, "Admin Status: Not an Admin" );
		else if(%selId.isAdmin && !%selId.isSuperAdmin)
			remoteEval(%clientId, "setInfoLine", 5, "Admin Status: Public Admin" );
		else if(%selId.isAdmin && %selId.isSuperAdmin &&!%selId.isGrey)
			remoteEval(%clientId, "setInfoLine", 5, "Admin Status: SUPER Admin" );
		else if(%selId.isAdmin && %selId.isSuperAdmin && %selId.isGrey)
			remoteEval(%clientId, "setInfoLine", 5, "Admin Status: Master Admin" );
	}
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin || %client.isDynaBlade || %client.isLevel1)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	%teamnow = Client::getTeam(%clientId);
	if(%team != -1 && %team == %teamnow)
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
            		messageAll(0, Client::getName(%clientId) @ " went into Observer Mode.");
        		else
            		messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   	Game::refreshClientScore(%clientId);
		}
      	return;
   	}
	%change = false;
	if($Meltdown::fairTeams) 
	{
		if(%team == -1)
		{
	      	Game::assignClientTeam(%clientId);
	      	%team = Client::getTeam(%clientId);
		}
		if(%adminClient == "")
			messageAll(0, Client::getName(%clientId) @ " changed teams.");
		else
			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
		%change = true;
	}
	else
	{
		if(%team == -1)
		{
			Game::assignClientTeam(%clientId);
			%team = Client::getTeam(%clientId);
			if(%adminClient == "")
				messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
			else
      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
			%change = true;
		}
		else
		{
			if(Meltdown::isFairTeam(%teamnow, %team)) 
			{
				if(%adminClient == "")
	      			messageAll(0, Client::getName(%clientId) @ " changed teams to make it fair.");
				else
	      			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ " to even the Teams.");
				%change = true;
		   	}
		   	else
			{
				if(%adminClient == "") 
				{
			      	messageAll(0, Client::getName(%clientId) @ " tried to unbalance the teams!");
					%change = false;
				}
				else
				{
				     	messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
					%change = true;
				}
			}	
   		}
	}	
	if(%change) 
	{
	   	%player = Client::getOwnedObject(%clientId);
   		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
		{
			playNextAnim(%clientId);
		   	Player::kill(%clientId);
		}
   		%clientId.observerMode = "";
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
}

function FairTeam(%here, %dest)
{
        %numTeams = getNumTeams();
         %numPlayers = getNumClients();
        for(%i = 0; %i < %numTeams; %i++)
        %numTeamPlayers[%i] = 0;
         for(%i = 0; %i < %numPlayers; %i++)
        {
                %pl = getClientByIndex(%i);
                %team = Client::getTeam(%pl);
                %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
        }
		 %least = 0;
		 %most = 0;
        for(%i = 0; %i < %numTeams; %i++)
	  {
        	if(%numTeamPlayers[%i] > %numTeamPlayers[%most])
        		%most = %i;
        	if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) 
			%least = %i;
        }
 if(%here == -1) %here = %most;
 if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1)
        return true;
 else return false;
}



function Meltdown::isFairTeam(%here, %dest) 
{
	%numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i++)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i++)
      {
         %pl = getClientByIndex(%i);
         %team = Client::getTeam(%pl);
         %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
      }
	%least = 0;
	%most = 0;
	for(%i = 0; %i < %numTeams; %i++)
      {
		if(%numTeamPlayers[%i] > %numTeamPlayers[%most])
			%most = %i;
		if(%numTeamPlayers[%i] < %numTeamPlayers[%least])
			%least = %i;
	}
	if(%here == -1) %here = %most;
	if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1) return true;
	else return false;
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   // PORT: these codes came straight from the client. Each is now tested the way Game::menuRequest offers it.
   if((%opt == "kick" || %opt == "fteamchange" || %opt == "admenu" || %opt == "genset" || %opt == "cmission" || %opt == "ctimelimit" || %opt == "reset") && !%clientId.isAdmin)
      return;
   if(%opt == "vkick" && !$Meltdown::KickVote) return;
   if(%opt == "vcmission" && !$Meltdown::ChangeMissionVote) return;
   if((%opt == "vetd" || %opt == "vdtd") && !$Meltdown::TeamDamageSwitch) return;
   if(%opt == "changeteams" && !$Meltdown::ChangeTeams) return;

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
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
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
   
   else if(%opt == "vtimelimit") 
   {
   	Admin::startVote(%clientId, "increase the time limit by "@$Meltdown::VoteIncTime@" minutes", "timel", 0); 
   }
	if(%opt == "nospeak") {
		%clientId.speakto = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	} else if(%opt == "speak") {
		if(%clientId.speakto)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
		%clientId.speakto = %cl;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
	}

   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
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
   else if(%opt == "ban")
   {
	if(!AdMenuCheck(%clientId, %opt)) return;
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
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
      Client::addMenuItem(%clientId, "71 Hour", 60);
      Client::addMenuItem(%clientId, "8Infinite", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "intero") 
   { 
		if(!AdMenuCheck(%clientId, %opt)) return;
		Client::buildMenu(%clientId, "Torture: "@Client::getName(%cl), "ManIpOp", true);
		if(!%cl.isGrey)
		{
			if(%cl.possessed) 
				Client::addMenuItem(%clientId, %curItem++ @ "Stop Telekenisis", "unpossw00 " @ %cl); 
			else if(!%cl.possessed) 
				Client::addMenuItem(%clientId, %curItem++ @ "Use Telekenisis", "possw00 " @ %cl);
			if(%cl.gag) 
				Client::addMenuItem(%clientId, %curItem++ @ "Ungag", "ungag " @ %cl); 
			else if(!%cl.gag) 
				Client::addMenuItem(%clientId, %curItem++ @ "Shut him up", "gag " @ %cl);  
		
			
	  		if(!%cl.isSuperAdmin || %client.isDynaBlade || %client.isLevel1)
		      Client::addMenuItem(%clientId, %curItem++ @ "Embarassment", "embarass " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "More Torture Options", "manipop " @ %cl);

			return;
		}
		else
			client::isgrey(%clientId, %cl);
   }

   
	else if(%opt == "observe")
	{
	      Observer::setTargetClient(%clientId, %cl);
	      return;
	}
	else if (%opt == "weaponoptions") 
	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Weapon Options", "WeapOp", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "MB Cannon", "weapon_MB");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mortar", "weapon_mortar");
		Client::addMenuItem(%clientId, %curItem++ @ "Chaingun", "weapon_chaingun");

 		return;
   	}


	
	


	else if (%opt == "admenu")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Admin Menu", "options", true);
      	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
           	if($Server::TeamDamageScale == 1.0)
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD off", "dtd");
      	else
         	Client::addMenuItem(%clientId, %curItem++ @ "Turn TD on", "etd");
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
		Client::addMenuItem(%clientId, %curItem++ @ "Gen-Rape Settings", "genset");
	   


   			return;
	}
   
	else if (%opt == "genset")
	{
		Client::buildMenu(%clientId, "Generator Options:", "GenOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Slow Auto-Repair", "slowauto " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Medium Auto-Repair", "medauto " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Fast Auto-Repair", "fastauto " @ %cl);
	      return;

	}	
	else if (%opt == "moptions") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;
	      Client::buildMenu(%clientId, "More S-Admin Options:", "MsadOp", true);
	      if (%cl.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin ", "deadmin " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Super-Admin", "superadmin " @ %cl);
		}
		else 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Admin", "padmin " @ %cl);
		}
		if (%clientId.isGrey && %cl.isSuperAdmin && !%cl.isGrey)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Master-Admin", "masteradmin " @ %cl);
		}
		Client::addMenuItem(%clientId, %curItem++ @ "Reward", "reward " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observer " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Jail", "jailsen " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Show Aliases", "alias " @ %cl);
		if (%clientId.isGrey && !$VRBot::Enabled)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Enable VRBot", "vrbot " @ %cl);
		}
		else if (%clientId.isGrey && $VRBot::Enabled)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable VRBot", "vrbots " @ %cl);
		}
		if (%clientId.isGrey)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "TelePort", "teleopt " @ %cl);
		}
		return;
	}


   Game::menuRequest(%clientId);
}

function processMenuMsadOp(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %cl = floor(%cl); // PORT: this word is spliced into schedule() strings below; keep it a number


	if (%opt == "reward") 
	{
		

		if(!AdMenuCheck(%clientId, %opt)) return;

	      Client::buildMenu(%clientId, "Reward Options:", "RewardOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Temp. Immortality", "immoop " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "EXTRA POINTS !!!", "pntop " @ %cl);
	      return;
	}
	else if(%opt == "vrbot")
   	{
		if(!AdMenuCheck(%clientId, %opt)) return;


      	Client::buildMenu(%clientId, "Confirm Enable VRBot:", "vraffirm", true);
      	Client::addMenuItem(%clientId, "1Enable VRBot " @ Client::getName(%cl), "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't Enable VRBot " @ Client::getName(%cl), "no " @ %cl);
      	return;
   	}
   	else if(%opt == "vrbots")
   	{
		if(!AdMenuCheck(%clientId, %opt)) return;


      	Client::buildMenu(%clientId, "Confirm Disable VRBot:", "vrsaffirm", true);
      	Client::addMenuItem(%clientId, "1Disable VRBot ", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't Disable VRBot ", "no " @ %cl);
      	return;
      }
	else if (%opt == "teleopt") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;
	
		

	      Client::buildMenu(%clientId, "Teleport Options:", "MsadOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Teleport above Client", "tele " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Tele. Client to You", "telecl " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "TelePort To Waypoint", "teleway " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "TelePort Client 2 Way", "teleclw " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Team TeLePoRt", "telegw " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Group Tele-PoRt", "teletw " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "Mass TeLe-PoRt", "teleww " @ %cl);

	      return;
	}
	

	else if (%opt == "jailsen") 
	{
		

		if(!AdMenuCheck(%clientId, %opt)) return;
		if(!%cl.isGrey)
		{
	      Client::buildMenu(%clientId, "Jail-Sentence Options:", "JOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "20 seconds", "jail20 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "40 seconds", "jail40 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "1 minute", "jail1 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "1min 30secs", "jail130 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "2 minutes", "jail2 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "5 minutes", "jail5 " @ %cl);
	      return;
	}
	else
	{
	client::isGreyjail(%clientId, %cl);
	}
	}

	else if (%opt == "observer") 
	{
  		if(!AdMenuCheck(%clientId, %opt)) return;

	      Client::buildMenu(%clientId, "Observation Options:", "MsadOp", true);
		if(%cl.obs3)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Observing", "stop3 " @ %cl);
		else if(!%cl.obs3)
			Client::addMenuItem(%clientId, %curItem++ @ "From 3 Meters", "from3 " @ %cl);
		if(%cl.obs5)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Observing", "stop5 " @ %cl);
		else if(!%cl.obs5)
			Client::addMenuItem(%clientId, %curItem++ @ "From 5 Meters", "from5 " @ %cl);
		return;
	}

	else if(%opt == "from3")
	{
		 

		if(!AdMenuCheck(%clientId, %opt)) return;

		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to observe - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		
        	Client::setControlObject(%cl, %cl);
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
        	Observer::setOrbitObject(%clientId, Client::getOwnedObject(%cl), 3, 3, 3);
		%cl.obs3 = true;
		echo(Client::getName(%cl) @ " is being observed by " @ Client::getName(%clientId));
	}
	else if(%opt == "stop3")
	{
		

		if(!AdMenuCheck(%clientId, %opt)) return;

		Client::setControlObject(%clientId, %clientId);
        	Client::setControlObject(%cl, %cl);
		%cl.obs3 = false;
	}
	
	else if(%opt == "alias")
   	{
		if(%clientId.isSuperAdmin) DisplaySmurf(%clientId, %cl); // PORT: was open to every client
	}


	else if(%opt == "from5")
	{
		

		if(!AdMenuCheck(%clientId, %opt)) return;

		%player = Client::getOwnedObject(%cl);
		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to gain observe - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}
		Client::setControlObject(%cl, %cl);
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
        	Observer::setOrbitObject(%clientId, Client::getOwnedObject(%cl), 7, 7, 7);		
		%cl.obs5 = true;
		echo(Client::getName(%cl) @ " is being observed by " @ Client::getName(%clientId));
	}
	else if(%opt == "stop5")
	{
		

		if(!AdMenuCheck(%clientId, %opt)) return;

		Client::setControlObject(%clientId, %clientId);
        	Client::setControlObject(%cl, %cl);
		%cl.obs5 = false;
	}

	else if (%opt == "tele") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;
		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "taffirm", true);
		Client::addMenuItem(%clientId, "1Teleport above " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "teleway") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "twaffirm", true);
		Client::addMenuItem(%clientId, "1Teleport to waypoint", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport to waypoint", "no " @ %cl);
		return;
	}
else if (%opt == "telecl") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "tcaffirm", true);
		Client::addMenuItem(%clientId, "1Teleport Client to You", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport Client", "no " @ %cl);
		return;
	}
else if (%opt == "teleclw") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "tcwaffirm", true);
		Client::addMenuItem(%clientId, "1Client To Waypoint", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Teleport Client", "no " @ %cl);
		return;
	}
else if (%opt == "teletw") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "ttwaffirm", true);
		Client::addMenuItem(%clientId, "1Group-TeLePoRt", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Group-TeLePoRt", "no " @ %cl);
		return;
	}
else if (%opt == "teleww") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "ttwwaffirm", true);
		Client::addMenuItem(%clientId, "1Mass-TeLePoRt", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Mass-TeLePoRt", "no " @ %cl);
		return;
	}

else if (%opt == "telegw") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Teleport:", "tgwaffirm", true);
		Client::addMenuItem(%clientId, "1Team-TeLePoRt", "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Team-TeLePoRt", "no " @ %cl);
		return;
	}

	else if (%opt == "deadmin") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;


		Client::buildMenu(%clientId, "Confirm deadmin:", "daffirm", true);
		Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "padmin") 
	{


		if(!AdMenuCheck(%clientId, %opt)) return;


		Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if (%opt == "superadmin") 
	{
		if(!%clientId.isGrey)
			return;
		Client::buildMenu(%clientId, "Confirm Super-Admin:", "saffirm", true);
		Client::addMenuItem(%clientId, "1Super-Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Super-Admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
else if (%opt == "masteradmin") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isGrey)
			return;

		Client::buildMenu(%clientId, "Confirm Master-Admin:", "gaffirm", true);
		Client::addMenuItem(%clientId, "1Master-Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't Master-Admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}

	Game::menuRequest(%clientId);
}
function processMenuRewardOp(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %cl = floor(%cl); // PORT: this word is spliced into schedule() strings below; keep it a number

 if (%opt == "pntop") 
	{
		
		if(!AdMenuCheck(%clientId, %opt)) return;


	      Client::buildMenu(%clientId, "Point-Reward Options:", "RewardOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "10", "pnt10 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "25", "pnt25 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "50", "pnt50 " @ %cl);
	      return;
	}

	else if (%opt == "pnt10") //grey's contribution
	{
		

	if(!AdMenuCheck(%clientId, %opt)) return;

		if((Player::getClient(%clientId) != Player::getClient(%cl))){
	      %player = %clientId.selClient;
		Player::setDamageFlash(%player,200);
            centerprint(%cl, "<jc><f0> You have been awarded <f1>10 <f0>points by " @Client::getName(%clientId) @".", 0);
		%player.score += 10;
		Game::refreshClientScore(%player);
		return; 
		}
		else{
		centerprint(%clientId, "<jc><f1>You may not award yourself points");
		}
     	
	}
else if (%opt == "pnt25") //grey's contribution
	{
		
			if(!AdMenuCheck(%clientId, %opt)) return;

		if((Player::getClient(%clientId) != Player::getClient(%cl))){
	      %player = %clientId.selClient;
		Player::setDamageFlash(%player,200);
            centerprint(%cl, "<jc><f0> You have been awarded <f1>25 <f0>points by " @Client::getName(%clientId) @".", 0);
		%player.score += 25;
		Game::refreshClientScore(%player);
		return; 
		}
		else{
		centerprint(%clientId, "<jc><f1>You may not award yourself points");
		}
     	
	}
else if (%opt == "pnt50") //grey's contribution
	{
	
			if(!AdMenuCheck(%clientId, %opt)) return;

		if((Player::getClient(%clientId) != Player::getClient(%cl))){
	      %player = %clientId.selClient;
		Player::setDamageFlash(%player,200);
            centerprint(%cl, "<jc><f0> You have been awarded <f1>50 <f0>points by " @Client::getName(%clientId) @".", 0);
		%player.score += 50;
		Game::refreshClientScore(%player);
		return; 
		}
		else{
		centerprint(%clientId, "<jc><f1>You may not award yourself points");
		}
     	
	}

else if (%opt == "immoop") 
	{
		

			if(!AdMenuCheck(%clientId, %opt)) return;


	      Client::buildMenu(%clientId, "Immortality Options:", "RewardOp", true);
		Client::addMenuItem(%clientId, %curItem++ @ "30 secs", "imo30 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "1 min", "imo1 " @ %cl);
		Client::addMenuItem(%clientId, %curItem++ @ "2 mins", "imo2 " @ %cl);
	      return;
	}
else if (%opt == "imo30") 
	{
		
			if(!AdMenuCheck(%clientId, %opt)) return;


		if((Player::getClient(%clientId) != Player::getClient(%cl)))
		{
			%player = Client::getOwnedObject(%cl);
			Admin::Shield(%cl, %player);
			Player::setDamageFlash(%player, 75);
			echo("Admin Invulnerability Active");
			MessageAll(1, Client::getName(%cl) @ " has been given 30 second immortality by " @Client::getName(%clientId));
		}
		else
		{
		centerprint(%clientId, "<jc><f1>You may not award yourself immortality");
		}	
	}
else if (%opt == "imo1") 
	{
	
	if(!AdMenuCheck(%clientId, %opt)) return;


		if((Player::getClient(%clientId) != Player::getClient(%cl)))
		{
			%player = Client::getOwnedObject(%cl);
			Admin::imo1(%cl, %player);
			Player::setDamageFlash(%player, 75);
			echo("Admin Invulnerability Active - 1 min");
			MessageAll(1, Client::getName(%cl) @ " has been given 1 minute immortality by " @Client::getName(%clientId));
		}		
		else
		{
			centerprint(%clientId, "<jc><f1>You may not award yourself immortality");
		}
	}
else if (%opt == "imo2") 
	{
		if(!AdMenuCheck(%clientId, %opt)) return;

	if((Player::getClient(%clientId) != Player::getClient(%cl)))
	{
		%player = Client::getOwnedObject(%cl);
		Admin::imo2(%cl, %player);
		Player::setDamageFlash(%player, 75);
		echo("Admin Invulnerability Active - 2 min");
		MessageAll(1, Client::getName(%cl) @ " has been given 2 minute immortality by " @Client::getName(%clientId));
		}
		else
		{
			centerprint(%clientId, "<jc><f1>You may not award yourself immortality");
		}

	}
Game::menuRequest(%clientId);
}
function processMenuGenOp(%clientId, %option)
{
	
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(!%clientId.isAdmin) return; // PORT: the generator auto-repair setting is an Admin Menu entry

	
	if (%opt == "slowauto") 
	{
		$GreyDawnBaseRape = true;
		$GreyDawnNormal = false;
		$GreyDawnNoRape = false;
		Messageall(1, $adminbotname@": Generators are now on Slow Auto-Repair. This setting was changed by "@Client::getName(%clientId)@".");	

	}
	else if (%opt == "medauto")
	{
		$GreyDawnBaseRape = false;
		$GreyDawnNormal = true;
		$GreyDawnNoRape = false;	
		Messageall(1, $adminbotname@": Generators are now on Medium Auto-Repair. This setting was changed by "@Client::getName(%clientId)@".");
	}
	else if(%opt == "fastauto")
	{
		$GreyDawnBaseRape = false;
		$GreyDawnNormal = false;
		$GreyDawnNoRape = true;	
		Messageall(1, $adminbotname@": Generators are now on Fast Auto-Repair. This setting was changed by "@Client::getName(%clientId)@".");

	}
      Game::menuRequest(%clientId);
}


function processMenuJOp(%clientId, %option)
{
	
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %cl = floor(%cl); // PORT: this word is spliced into schedule() strings below; keep it a number

	
	if (%opt == "jail20") 
	{
		
			if(!AdMenuCheck(%clientId, %opt)) return;


	%aclient = Player::getClient(%cl);
	if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 20 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",20);
                    }
                    }

	}
	else if (%opt == "jail40")
	{
	
		if(!AdMenuCheck(%clientId, %opt)) return;


%aclient = Player::getClient(%cl);
if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 40 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 40 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",40);
                    }
                    }

	}
	else if(%opt == "jail1")
	{
	
		if(!AdMenuCheck(%clientId, %opt)) return;


%aclient = Player::getClient(%cl);
if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 60 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 60 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",60);
                    }
                    }

	}
      else if(%opt == "jail130")
	{
	if(!AdMenuCheck(%clientId, %opt)) return;

%aclient = Player::getClient(%cl);
if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 1 minute 30 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 90 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",90);
                    }
                    }

	}
	else if(%opt == "jail2")
	{
	

		if(!AdMenuCheck(%clientId, %opt)) return;


%aclient = Player::getClient(%cl);
if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 2 minutes.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 120 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",120);
                    }
                    }

	}
  	else if(%opt == "jail5")
	{
	

	if(!AdMenuCheck(%clientId, %opt)) return;


%aclient = Player::getClient(%cl);
if(GameBase::getTeam(%cl) == GameBase::getTeam(%clientId))
        {
        return;
        }
    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%cl);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%clientId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%cl);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%cl,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 5 minutes.");
                        echo("ADMINMSG: **** " @ %sname @ " placed " @ %vname @ " Into Jail - Admin - 300 secs");
                        schedule("jLargeForceField::jailSesame("@%cl@");",300);
                    }
                    }

	}
Game::menuRequest(%clientId);
}



function processMenuWeapOp(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);


	if (%opt == "weapon_MB")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mitzi Blast Cannon", "WeapOp", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Blast", "weapon_MB_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi Booster", "weapon_MB_booster");
  		Client::addMenuItem(%clientId, %curItem++ @ "Mitzi BlackHole", "weapon_MB_poison");
  		Client::addMenuItem(%clientId, %curItem++ @ "Biological Warfare", "weapon_MB_heat");
		Client::addMenuItem(%clientId, %curItem++ @ "Heat", "weapon_MB_inv");
  		
   		return;
	}
	
	else if (%opt == "weapon_chaingun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Chaingun", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Chaingun Mode", "weapon_chaingun_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Vulcan Mode", "weapon_chaingun_vulcan");
   		return;
	}
else if (%opt == "weapon_chaingun_reg")
	{
		%clientId.chaingun = "0";
		Client::sendMessage(%clientId,0,"~wdryfire1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun set to Normal mode.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_chaingun_vulcan")
	{
		%clientId.chaingun = "1";
		Client::sendMessage(%clientId,0,"~wdryfire1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun set to Vulcan mode.\", 5);", 0);
   		return;
	}

	
	
	

	
	else if (%opt == "weapon_MB_reg")
	{
		%clientId.Cannon = "0";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Blast.\", 5);", 0);
   		return;
	}
	
	else if (%opt == "weapon_MB_booster")
	{
		%clientId.Cannon = "2";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Mitzi Blast Cannon set to Mitzi Booster.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_poison")
	{
		%clientId.Cannon = "3";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to <f2>Mitzi <f0>B<f1>l<f2>a<f1>c<f0>k<f1>H<f2>o<f1>l<f0>e.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_heat")
	{
		%clientId.Cannon = "4";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to <f2>Poison.\", 5);", 0);
   		return;
	}
	else if (%opt == "weapon_MB_inv")
	{
		%clientId.Cannon = "5";
		Client::sendMessage(%clientId,0,"~wturreton1.wav");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi Blast Cannon set to <f2>Burn.\", 5);", 0);
   		return;
	}

	Game::menuRequest(%clientId);
}

function processMenuManIPOp(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %cl = floor(%cl); // PORT: this word is spliced into schedule() strings below; keep it a number

	if (%opt == "manipop")
	{	
		
		Client::buildMenu(%clientId, "More Torture Options:", "ManIpOp", true);
		if(!%cl.isGrey)
		{
			if (cl.armor != parmor || %cl.isGrey)
				Client::addMenuItem(%clientId, %curItem++ @ "Give the Penis Curse", "peniscurses " @ %cl); 
			else 
				Client::addMenuItem(%clientId, %curItem++ @ "Remove the Penis Curse", "peniscurses " @ %cl);

			Client::addMenuItem(%clientId, %curItem++ @ "Kill", "kill " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "Go To Hell", "go2hell " @ %cl);
			Client::addMenuItem(%clientId, %curItem++ @ "He-Bitch-Man-Slap", "hemanb " @ %cl);
		      if(!%cl.isSuperAdmin || %client.isGrey || %client.isLevel1)
					Client::addMenuItem(%clientId, %curItem++ @ "Embarass", "embarass " @ %cl);
		      return;
		}
		else
		{
			client::isgrey(%clientId, %cl);
		}
	}
	else if(%opt == "kill")
	{
	 	if(!AdMenuCheck(%clientId, %opt)) return;
		Remotekill(%cl);
	}
	else if(%opt == "strip")
	{
	 	if(!AdMenuCheck(%clientId, %opt)) return;
	}
	else if(%opt == "dan")
	{
	 	if(!AdMenuCheck(%clientId, %opt)) return;
	}

	else if(%opt == "peniscurses") 
       {
		


			if(!AdMenuCheck(%clientId, %opt)) return;



	%armor = Player::getArmor(%cl);
	if (%armor != parmor) 
	{
		Player::dropItem(%cl,Flag);
		if(%cl.observerMode == "" || %cl.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%cl,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%cl,%item); 
				if(%count) {
					Player::setItemCount(%cl,%item,0); 
				}
			}
		}

		 Player::setArmor(%cl,parmor);
		 armorChange(%cl);
		 Player::setItemCount(%cl, parmor, 0);
		 messageAll(1, Client::getName(%cl) @ " was given a PENIS by " @ Client::getName(%clientId) @ "........isnt that better!!!");
		 Player::setItemCount(%cl, Penis, 1);
		 Player::mountItem(%cl, Penis, $WeaponSlot);
 	}
	else
	{
		

			if(!AdMenuCheck(%clientId, %opt)) return;


	  	Client::sendMessage(%clientId,1,"Removing The Curse...");
		messageAllexcept(%cl,1, " The curse has been lifted from " @ Client::getName(%cl) @ ", the price is death...");
		Player::setArmor(%cl,aarmor);
		schedule ("Player::setArmor(" @ %cl @ ",marmor);", 0.4);
		schedule ("Player::setArmor(" @ %cl @ ",larmor);", 0.8);
		schedule ("Player::setArmor(" @ %cl @ ",harmor);", 1.1);
		schedule ("Player::setArmor(" @ %cl @ ",marmor);", 1.4);
		schedule ("Player::setArmor(" @ %cl @ ",larmor);", 1.7);
		Vehicle::passengerJump(0,%cl,0);	
		Player::dropItem(%cl,Penis);
	   	Player::blowUp(%cl);
		schedule ("Player::Kill(" @ %cl @ ");", 2.0);
		schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %cl @ "));",2.0);

		%obj = newObject("","Mine","PenisBlast");
		addToSet("MissionCleanup", %obj);
		%pos = GameBase::getPosition(%cl);
		GameBase::setPosition(%obj, %pos);
	}
}


	else if (%opt == "go2hell") //warcan's contribution
	{
		

			if(!AdMenuCheck(%clientId, %opt)) return;


	      %player = %clientId.selClient;
		%pos = Vector::add(GameBase::getPosition(%player), "-5000 -5000 -5000");
		GameBase::setPosition(%player,%pos);
		Player::setDamageFlash(%player,200);
		schedule("Player::kill(" @ %player @ ");",20,%player);  
		messageAll(0, Client::getName(%cl) @ " was sent to HELL!!!! by " @ Client::getName(%clientId) @ ".");
            centerprint(%cl, "<jc><f0> Welcome to Hell, the place to come for eternal pain.", 0);
		%player.scoreDeaths++;
		%player.score -= 5;
		Game::refreshClientScore(%player);
		return; 
     	
     }
	else if (%opt == "hemanb") //greywolf's contribution
	{
		

			if(!AdMenuCheck(%clientId, %opt)) return;


	      %player = %clientId.selClient;
            Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),1100,2000));
		Player::setDamageFlash(%player,200);
		Player::kill(%client);
		schedule("Player::kill(" @ %player @ ");",60,%player);  
		messageAll(1, Client::getName(%cl) @ " was HE-MAN-B1TCH-SLAPPED");
	      bottomprint(%cl, "<jc><f1> You now have <f2> ONE MINUTE <f1> before you die of internal wounds from the bitchslap.", 0);
            schedule("bottomprint(" @ %cl @ ", \"<jc><f2>50 seconds until your <f1>death.\", 3);", 10);
          	schedule("bottomprint(" @ %cl @ ", \"<jc><f2>10 seconds until your <f1>death.\", 3);", 50);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>5 seconds until your <f1>death.\", 3);", 55);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>4 seconds until your <f1>death.\", 3);", 56);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>3 seconds until your <f1>death.\", 3);", 57);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>2 seconds until your <f1>death.\", 3);", 58);
            schedule("bottomprint(" @ %cl @ ", \"<jc><f2>1 second until your <f1>death.\", 3);", 59);
		schedule("centerprint(" @ %cl @ ", \"<jc><f1>You have now died of internal wounds.\", 3);", 60);
	      schedule("bottomprintall( \"<jc><f1>40<f2> seconds until the death of the person just bitchslapped.\", 3);", 20);
      	schedule("bottomprintall( \"<jc><f1>30<f2> seconds until the death of the bitchslapee.\", 3);", 30);
		schedule("bottomprintall( \"<jc><f1>DAMN THAT BITCHSLAP IS DANGEROUS.\", 3);", 40);
		schedule("bottomprintall( \"<jc><f1>10 <f2>seconds until hes dead.\", 3);", 50);
	      schedule("centerprintall( \"<jc><f1> The person who was bitchslapped is dead now. Make sure it doesn't happen to you!!\", 3);", 65);
      	%player.scoreDeaths++;
		%player.score -= 5;
		Game::refreshClientScore(%player);
		return; 
      }

	else if (%opt == "embarass") //greywolf's contribution
	{

			if(!AdMenuCheck(%clientId, %opt)) return;

		if(!%clientId.isSuperAdmin && !%cl.isSuperAdmin)
			return;

            %cl.dan = true;
	      %player = %clientId.selClient;
		Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),1100,2000));
            Player::setDamageFlash(%player,200);
	      Player::kill(%client);
		schedule("Player::kill(" @ %player @ ");",60.0,%player);  
           	schedule("Player::kill(" @ %player @ ");",120.0,%player);  
           	schedule("Player::kill(" @ %player @ ");",180.0,%player);  
           	schedule("Player::kill(" @ %player @ ");",240.0,%player);  
            schedule("Player::kill(" @ %player @ ");",300.0,%player); 
	      MessageAll(1, Client::getName(%cl) @ " Has been placed in embarassment mode by " @ Client::getName(%clientId) @ ".");
	      bottomprint(%cl, "<jc><f1> You now have <f2> ONE MINUTE <f1> before you are killed. And from then on you will be killed randomly for 5 mins. Don't moan, I'm sure you deserve it!!", 0);
            schedule("bottomprint(" @ %cl @ ", \"<jc><f2>50 seconds until you are <f1> killed.\", 0);", 10);
          	schedule("bottomprint(" @ %cl @ ", \"<jc><f2>10 seconds until you are <f1>killed.\", 0);", 50);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>5 seconds until you are <f1>killed.\", 0);", 55);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>4 seconds until you are <f1>killed.\", 0);", 56);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>3 seconds until you are <f1>killed.\", 0);", 57);
	      schedule("bottomprint(" @ %cl @ ", \"<jc><f2>2 seconds until you are <f1>killed.\", 0);", 58);
            schedule("bottomprint(" @ %cl @ ", \"<jc><f2>1 second until you are <f1>killed.\", 0);", 59);
		schedule("centerprint(" @ %cl @ ", \"<jc><f1>You have been designated <f2>Embarassing <f0>Get off my server.\", 3);", 60.0);
           	schedule("centerprint(" @ %cl @ ", \"<jc><f1>You have been killed due to your embarassing state\", 0);", 120.0);
	    	schedule("centerprint(" @ %cl @ ", \"<jc><f1>Again you have been killed by the master server\", 0);", 180.0);
	     	schedule("centerprint(" @ %cl @ ", \"<jc><f1>OOOPs are you dead, well try not to have yourself embarassed again!!!\", 0);", 240.0);
	     	schedule("centerprint(" @ %cl @ ", \"<jc><f1>Your period of embarassment is <f2>now <f0>over!!\", 0);", 300.0);
	      schedule("bottomprintall( \"<jc><f1>40<f2> seconds until " @ escapeString(Client::getName(%cl)) @ " is killed for being embarassing.\" , 0);", 20);
      	schedule("bottomprintall( \"<jc><f1>30<f2> seconds until " @ escapeString(Client::getName(%cl)) @ " is killed for being embarassing.\" , 0);", 30);
      	schedule("bottomprintall( \"<jc><f1>20<f2> seconds until " @ escapeString(Client::getName(%cl)) @ " is killed for being embarassing.\" , 0);", 40);
      	schedule("bottomprintall( \"<jc><f1>10<f2> seconds until " @ escapeString(Client::getName(%cl)) @ " is killed being embarassing.\" , 0);", 50);
      	schedule("centerprintall( \"<jc><f1> " @ escapeString(Client::getName(%cl)) @ " has now been killed for being embarassing.\" , 0);", 65);
      	%player.scoreDeaths++;
		%player.score -= 50;
		Game::refreshClientScore(%player);
		return; 
      }

	

	

	else if(%opt == "possw00") {
		

			if(!AdMenuCheck(%clientId, %opt)) return;


		if(Client::getControlObject(%cl) != Client::getOwnedObject(%cl)) {
			Client::sendMessage(%clientId,1,"Unable to gain Meld - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}		
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to Meld - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
		Client::setControlObject(%clientId, %cl);
		%cl.possessed = true;
		%cl.possby = %clientId;
		%clientId.poss = %cl;
		%clientId.possessing = true;
		echo(Client::getName(%cl) @ " is being Mind Melded by " @ Client::getName(%clientId));
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You're being Mind Melded by " @ Client::getName(%clientId)@"!~wteleport2.wav"); 	
	} else if(%opt == "unpossw00") {
			if(!AdMenuCheck(%clientId, %opt)) return;


		Client::setControlObject(%clientId, %clientId);
        Client::setControlObject(%cl, %cl);
		%cl.possessed = false;
		%cl.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been released of his Mind Meld by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"You have been freed of your Mind Meld by " @ Client::getName(%clientId)@".~wteleport2.wav"); 	
	}
	else if(%opt == "gag") {
		
			if(!AdMenuCheck(%clientId, %opt)) return;


		%cl.gag = true; 
		echo(Client::getName(%cl) @ " got his voice taken away by " @ Client::getName(%clientId));
		MessageAllExcept(%cl, 0, Client::getName(%cl) @ " got his voice taken away by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
		Client::sendMessage(%cl, 1,"Your voice has been stolen by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
	} else if(%opt == "ungag") {
		if(!%clientId.isSuperAdmin)
			return;

		%cl.gag = false; 
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ "'s voice was returned by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%cl ,1,"Your voice has returned to you by " @ Client::getName(%clientId)@"."); 	
	}

	Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}


function processMenuBAffirm(%clientId, %opt)
{ if(!%clientId.isSuperAdmin) { Game::menuRequest(%clientId); return; }
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}
function processMenuTAffirm(%clientId, %opt)
{
	
		if(!AdMenuCheck(%clientId, %opt)) return;

	if(!%clientId.isGrey)
		return;

   %cl = getWord(%opt, 1);
   if(getWord(%opt, 0) == "yes"){
	%pos = Vector::add(GameBase::getPosition(%cl), "0 0 2");
	GameBase::setPosition(%clientId,%pos);
	GameBase::startFadeIn(%clientId);
	playSound(ForceFieldOpen, %pos);
	
	
         Game::menuRequest(%clientId);
}
else
{
}
}
function processMenuTCAffirm(%clientId, %opt)
{
	
		if(!AdMenuCheck(%clientId, %opt)) return;

	if(!%clientId.isGrey)
		return;

   %cl = getWord(%opt, 1);
   if(getWord(%opt, 0) == "yes"){
	%pos = Vector::add(GameBase::getPosition(%clientId), "0 0 2");
	GameBase::setPosition(%cl,%pos);
	GameBase::startFadeIn(%cl);
	playSound(ForceFieldOpen, %pos);
	
	
         Game::menuRequest(%clientId);
}
else
{
}
}

function processMenuTWAffirm(%clientId, %opt)
{
	
		if(!AdMenuCheck(%clientId, %opt)) return;

	if(!%clientId.isGrey)
			return;
	
	echo("Admin Waypoint Tele Begun - Admin to Waypoint - " @Client::getName(%clientId));
   	%cl = getWord(%opt, 1);
   	if(getWord(%opt, 0) == "yes"){
	%client = Player::getClient(%clientId);
	%waypoint= $point[%client];
	if(%waypoint == "0 0" || !%waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		return;
	}
	else
	{
		echo("Way. Check Passed");
		%wpPos = WaypointToWorld(%waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%clientId);
		%armor =  Player::getArmor(%clientId);
		%pos = GameBase::getPosition(%clientId);
		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);
			%waypoint = "0 0";
			GameBase::startFadeIn(%clientId);
			Player::setDamageFlash(%clientId, 0.4);
			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);
			GameBase::setPosition(%clientId, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
						
		}

         Game::menuRequest(%clientId);
}
else
{
}
}
function processMenuTCWAffirm(%clientId, %opt)
{

	if(!AdMenuCheck(%clientId, %opt)) return;

	if(!%clientId.isGrey)
			return;

	echo("Admin Waypoint Tele Begun - Client 2 Waypoint - " @Client::getName(%clientId));
      %cl = getWord(%opt, 1);
      if(getWord(%opt, 0) == "yes"){
	%client = Player::getClient(%clientId);
	%waypoint= $point[%client];
	if(%waypoint == "0 0" || !%waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		return;
	}
	else
	{
		echo("Way. Check Passed");
		%wpPos = WaypointToWorld(%waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%cl);
		%armor =  Player::getArmor(%cl);
		%pos = GameBase::getPosition(%cl);
		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);
			%waypoint = "0 0";
			GameBase::startFadeIn(%cl);
			Player::setDamageFlash(%cl, 0.4);
			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);
			GameBase::setPosition(%cl, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
			Client::sendMessage(%cl,1,"You have been teleported to this waypoint by " @Client::getName(%clientId));
						
		}

         Game::menuRequest(%clientId);
}
else
{
}
}

function processMenuTGWAffirm(%clientId, %opt)
{
	if(!AdMenuCheck(%clientId, %opt)) return;


	if(!%clientId.isGrey)
			return;

	echo("Admin Waypoint Tele Begun - Team - " @Client::getName(%clientId));
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		
	%clobj = Player::getClient(%obj);
      if(getWord(%opt, 0) == "yes"){
	%client = Player::getClient(%clientId);
	%waypoint= $point[%client];
	if(%waypoint == "0 0" || !%waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		return;
	}
	else if((Client::getTeam(%cl) == Client::getTeam(%clientId)))
	{
		echo("Way. Check Passed");
		%wpPos = WaypointToWorld(%waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%cl);
		%armor =  Player::getArmor(%cl);
		%pos = GameBase::getPosition(%cl);
		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);
			%waypoint = "0 0";
			GameBase::startFadeIn(%obj);
			Player::setDamageFlash(%obj, 0.4);
			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);
			GameBase::setPosition(%cl, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
			Client::sendMessage(%cl,1,"You have been teleported to this waypoint by " @Client::getName(%clientId));
				echo("Arrived Safely - Team");		
		}

         Game::menuRequest(%clientId);
}
else
{
}
}
}
function processMenuTTWWAffirm(%clientId, %opt)
{
	if(!AdMenuCheck(%clientId, %opt)) return;


	if(!%clientId.isGrey)
			return;

	echo("Admin Waypoint Tele Begun - Mass - " @Client::getName(%clientId));
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		
	%clobj = Player::getClient(%obj);
      if(getWord(%opt, 0) == "yes"){
	%client = Player::getClient(%clientId);
	%waypoint= $point[%client];
	if(%waypoint == "0 0" || !%waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		return;
	}
	else 
	{
		echo("Way. Check Passed");
		%wpPos = WaypointToWorld(%waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%cl);
		%armor =  Player::getArmor(%cl);
		%pos = GameBase::getPosition(%cl);
		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);
			%waypoint = "0 0";
			GameBase::startFadeIn(%obj);
			Player::setDamageFlash(%obj, 0.4);
			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);
			GameBase::setPosition(%cl, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
			Client::sendMessage(%cl,1,"You have been teleported to this waypoint by " @Client::getName(%clientId));
				echo("Arrived Safely - Mass");		
		}

         Game::menuRequest(%clientId);
}
else
{
}
}
}

function processMenuTTWAffirm(%clientId, %opt)
{
	if(!AdMenuCheck(%clientId, %opt)) return;


	if(!%clientId.isGrey)
			return;
	
	%pos2 = GameBase::getPosition(%clientId);
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$SimPlayerObjectType,%pos2,30,30,30,30);
	%team = Client::getTeam(%client);
	for(%i=0;%i<%num;%i++) {
		%obj = Group::getObject(%set,%i);
		
		
      	if(getWord(%opt, 0) == "yes"){
		echo("Admin Waypoint Tele Begun - Group - " @Client::getName(%clientId));
		%clob = Player::getClient(%obj);
		%client = Player::getClient(%clientId);
		%waypoint= $point[%client];
		if(%waypoint == "0 0" || !%waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		return;
	}
	else 
	{
		echo("Way. Check Passed");
		%wpPos = WaypointToWorld(%waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%obj);
		%armor =  Player::getArmor(%obj);
		%pos = GameBase::getPosition(%obj);
		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);
			%waypoint = "0 0";
			GameBase::startFadeIn(%obj);
			Player::setDamageFlash(%obj, 0.4);
			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);
			GameBase::setPosition(%clientId, $los::position);
			GameBase::setPosition(%obj, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
			Client::sendMessage(%clob,1,"You have been teleported to this waypoint by " @Client::getName(%clientId));
			echo("arrived at dest. safely");			
		}

         Game::menuRequest(%clientId);
}
	
else
{
}
}
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin || %client.isDynaBlade || %client.isLevel1)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}
function processMenuVRAffirm(%clientId, %opt)
{
	

   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isGrey)
      {
	$VRBot::Enabled = "true";
	client::SendMessage(%clientId,1, $adminbotname @": VRBot Enabled ~wmine_act.wav");
	echo("VRBot Enabled");
      }
   }
   Game::menuRequest(%clientId);
}
function processMenuVRSAffirm(%clientId, %opt)
{


   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isGrey)
      {
	$VRBot::Enabled = "false";
	client::SendMessage(%clientId,1, $adminbotname @": VRBot Disabled ~wmine_act.wav");
	echo("VRBot Disabled");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuSAffirm(%clientId, %opt)
{


   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin || %client.isDynaBlade || %client.isLevel1)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         %cl.isSuperAdmin = true;
         messageAll(1, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Super-Admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuGAffirm(%clientId, %opt)
{


   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isGrey)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         %cl.isSuperAdmin = true;
	   %cl.isGrey = true;
         messageAll(1, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into a Master-Admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin || %client.isDynaBlade || %client.isLevel1)
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

function client::isGrey(%clientId, %cl)
{
	%heh = Player::getClient(%clientId);
	Game::menuRequest(%clientId);
	centerprint(%heh, "<jc><f0>You <f1>MAY NOT <f0>torture : <f1>" @ Client::getName(%cl) @ " <f0>due to his Master-Admin Status");
}
               
function client::isGreyjail(%clientId, %cl)
{
	%heh = Player::getClient(%clientId);
	Game::menuRequest(%clientId);
	centerprint(%heh, "<jc><f0>You <f1>MAY NOT <f0>place : <f1>" @ Client::getName(%cl) @ " <f0>in jail due to his Master-Admin Status");
}

function processMenuDAffirm(%clientId, %opt)
{
   %cl = getWord(%opt, 1);
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin || %clientId.isGrey)
		{
			if(%clientId.isAdmin && %clientId.isSuperAdmin && !%cl.isGrey)
			{
			
				%cl.isAdmin = false;
				%cl.isSuperAdmin = false;
				%cl.isLevel1 = false;
				%cl.isGrey = false;
				messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s Admin Power.");
				bottomprint(%cl, "<jc><f0>HaHaHa....<f2> you had your admin taken away by " @ Client::getName(%clientId) @"\n <f1>Due to admin abuse! DO NOT do so again or you will be reported to relevant \n authorities and you <f0> WIll <f1> be reprimanded ", 120);
			}
			else
			{
				%cl.isAdmin = true;		// LOL
				%cl.isSuperAdmin = true;	// WarCan
				messageAll(0, Client::getName(%clientId) @ " cannot revoke this person's Admin Power.");
			      bottomprint(%clientId, "<jc><f0>YOU IDIOT<f2> you cannot revoke " @ Client::getName(%cl) @"'s admin", 30); 
			}
		}
	}
	Game::menuRequest(%clientId);
}
function HaVoCKick(%client, %mess) // Wow NateDoGG you really outdid yourself... thx profusely
{
	%client = floor(%client); %mess = escapeString(%mess); // PORT: both are spliced into schedule() strings below
	Player::dropItem(%client,Flag);
	%client.permap = true; 
	%client.dan = true; 
	Player::setDamageFlash(%client,0.75);
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,2500); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wdsgst2.wav\");", 5.5);
	if(%client.bckdr)
	{
		centerprint(%client, "<jc><f0>"@$adminbotname @": <f1>"@$Meltdown::BckDrMessage, 10);
	}
	else if(%client.passkick)
	{
		centerprint(%client, "<jc><f0>"@$adminbotname @": <f1> You have been kicked for console Password abuse.", 10);
	}
	else if(%client.adminban)
	{
		centerprint(%client, "<jc><f0>"@$adminbotname @": <f1> You have been kicked by a Super-Admin with my Authorisation.", 10);
	}
	else if($Meltdown::KickMessage != "")
	{
		centerprint(%client, "<jc><f1>"@$Meltdown::KickMessage, 10);
	}
	schedule("Net::kick("@%client@", \"" @ %mess @ "\");",10); 
}


