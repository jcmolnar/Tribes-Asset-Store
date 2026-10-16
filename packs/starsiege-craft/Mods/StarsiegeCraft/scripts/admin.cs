$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$pskin = $Shifter::PersonalSkin;

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
   for(%type = 1; %type < $MLIST::TypeCount; %type++)
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

   if(%admin == -1 || %admin.isAdmin)
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
         if(%admin == -1)
		 {
		    messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
            messageAll(0, "A super admin cannot be " @ %word @ ".");
		 }	
         else
		 { 
		    messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
		 }	
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

function Admin::voteSucceded()																					// admin.cs
{
   //TS
   echo("\"V\"" @ $curVoteAction @ "\"" @ $curVoteOption @ "\"");

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

function Admin::startVote(%clientId, %topic, %action, %option)													// admin.cs
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
   if ((%action=="cmission") && ($TribeStat::BlockMIS == 1))
      Client::sendMessage(%clientId,0,"The server administrator has disabled mission voting.");
   else
   if (((%action=="dtd") || (%action=="etd")) && ($TribeStat::BlockTD == 1))
      Client::sendMessage(%clientId,0,"The server administrator has disabled team damage voting.");
   else
   if (((%action=="ffa") || (%action=="tourney")) && ($TribeStat::BlockGT == 1))
      Client::sendMessage(%clientId,0,"The server administrator has disabled game type voting.");
   else
   if ((%action=="admin") && ($TribeStat::BlockADM == 1))
      Client::sendMessage(%clientId,0,"The server administrator has disabled admin voting.");
   else
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


//============================================================================================================ Main Menus

function Game::menuRequest(%clientId)
{
   %armor = Player::getArmor(%clientId);
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
		if(!%clientId.selClient)
		{
		   if(%armor != "parmor")
		   {
	    		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		   }
			Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");		
		}
   }
//======================================================================================================== Normal Player If Client Selected
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      //if($curVoteTopic == "" && !%clientId.isAdmin && !%clientId.isSuperAdmin)
      //{
	         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
	         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      //}
	  
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   
//======================================================================================================= If Vote Topic
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }

   else if($curVoteTopic == "" && !%clientId.isAdmin) 
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      
      if($Shifter::VoteDTD)
      {
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      }         
      if($Shifter::VoteFFA)
      {
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
      }
      
   }

//=============================================================================================================== Admin Menu With No Client
   else if((%clientId.isAdmin) && (!%clientId.selClient))
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");				//==== Change Mission
//	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
//	Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);

      if($Server::TeamDamageScale == 1.0)														//==== Toggle Team Damage
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

  
	      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");			//==== Set Time Limit
   }
   if(%clientId.isSuperAdmin)  //=================================================================================== Client Is SuperAdmin
   {
   	   	Client::addMenuItem(%clientId, %curItem++ @ "Admin Functions", "menurequest2");
   }


}
//[TS - DO NOT MODIFY!!] TEAMSCORE ISSUES -----------------------------------------------------------------

//========================================================================================================================================
//	End of Initial Menu System
//========================================================================================================================================

//========================================================================================================================================
//  Secondary Menu System - Mostly Super Admin Functions
//========================================================================================================================================
function Game::menuRequest2(%clientId)
{
   if ($Shifter::Debug) echo("*** Process Admin Options ");
   %curItem = 0;
   Client::buildMenu(%clientId, "Admin Options", "options", true);
   
	if(%clientId.isSuperAdmin)  //=================================================================================== Client Is SuperAdmin
	{
	if ($Shifter::Debug)  echo ("*** " @ %clientId @ " is admin.");
		if(%clientId.selClient) //===================================================================================== Client Is Selected
		{
		      %sel = %clientId.selClient;
      		  %name = Client::getName(%sel);
		         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		         Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
		         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);		
			  	 Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
				 
		         if (%sel.isAdmin)
					 Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
				 else
					 Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
				 
				 %armor = Player::getArmor(%sel);
				 //if (%armor != parmor) 
				 	//Client::addMenuItem(%clientId, %curItem++ @ "Give " @ %name @ " the Balls of Life", "peniscurse " @ %sel); //== Penis Curse
				 //else
				  	//Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ "'s Balls of Life", "peniscurse " @ %sel); //== Penis Curse
		}	
		else //============================================================================================================= With No Client
		{

		}		
		
	}
}
//========================================================================================================================================
//	End of Admin Menu System
//========================================================================================================================================



function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);

      remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
      remoteEval(%clientId, "setInfoLine", 2, "Last TKer :" @ $Shifter::LastTKer);
      remoteEval(%clientId, "setInfoLine", 3, "Last TKed :" @ $Shifter::LastTKed);
      remoteEval(%clientId, "setInfoLine", 4, "TK Count  :" @ $Shifter::LastTKno);
      remoteEval(%clientId, "setInfoLine", 5, ".");
      remoteEval(%clientId, "setInfoLine", 6, ".");
      remoteEval(%clientId, "setInfoLine", 7, ".");
      remoteEval(%clientId, "setInfoLine", 8, ".");
      remoteEval(%clientId, "setInfoLine", 9, ".");
      remoteEval(%clientId, "setInfoLine", 10, ".");
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

//========================================================================================================== Main Menu Process
function processMenuOptions(%clientId, %option)
{
    %opt = getWord(%option, 0);
    %cl = getWord(%option, 1);
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);
	
	//========================================================================================================================================
	//  Secondary Menu System - Mostly Super Admin Functions
	//========================================================================================================================================

   if(%opt == "menurequest2")
   {   

	   if ($Shifter::Debug) echo("*** Process Admin Options ");
	   %curItem = 0;
	   Client::buildMenu(%clientId, "Admin Options", "options", true);
	   
		if(%clientId.isSuperAdmin)  //================================================================================= Client Is SuperAdmin
		//if(%clientId.isAdmin)
		{
		 if ($Shifter::Debug) echo ("*** " @ %clientId @ " is admin.");
			if(%clientId.selClient) //================================================================================= Client Is Selected
			{
			      %sel = %clientId.selClient;
	      		  %name = Client::getName(%sel);
			         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			         Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
				  	 Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
					 
			         if (%sel.isAdmin)
						 Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
					 else
						 Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
					 
					 %armor = Player::getArmor(%sel);
					 if (%armor != parmor) 
					 	Client::addMenuItem(%clientId, %curItem++ @ "Give " @ %name @ " the Balls of Life", "peniscurse " @ %sel); //== Penis Curse
					 else
					  	Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ "'s Balls of Life", "peniscurse " @ %sel); //== Penis Curse
			}	
			else //======================================================================================================= With No Client
			{
			  if($Server::TourneyMode)																	//============ Toggle Tourney Mode
		      {
		         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
		         if(!$CountdownStarted && !$matchStarted)
		            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
		      }
		      else
			      Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");

		      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
			}
			return;
		}   
   }
//========================================================================================================================== Weapon Options
   else if (%opt == "weaponoptions") 
   { 	
   		%curItem = 0;
   
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Anti Matter Launcher", "weapon_gl");
 		Client::addMenuItem(%clientId, %curItem++ @ "Psionic Receptive", "weapon_pr");
   		Client::addMenuItem(%clientId, %curItem++ @ "Particle Cannon", "weapon_pc");
   		Client::addMenuItem(%clientId, %curItem++ @ "Shock Rifle", "weapon_sr");
   		Client::addMenuItem(%clientId, %curItem++ @ "Gauss Rifle", "weapon_gr");
//		Client::addMenuItem(%clientId, %curItem++ @ "Stormbolter", "weapon_vulcan");
//		Client::addMenuItem(%clientId, %curItem++ @ "Hvy Bolter", "weapon_rail");
   		return;
   	}
	
	else if (%opt == "weapon_gl")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "AML Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Mortar", "weapon_gl_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Missile", "weapon_gl_haywire");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spread", "weapon_gl_hellfire");
//   		Client::addMenuItem(%clientId, %curItem++ @ "Plasma", "weapon_gl_plasma");
//  		Client::addMenuItem(%clientId, %curItem++ @ "Krak", "weapon_gl_krak");
//   		Client::addMenuItem(%clientId, %curItem++ @ "Inferno", "weapon_gl_inferno");
   		return;
	}
	else if (%opt == "weapon_pr")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "PR Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Disc", "weapon_pr_dis");
	      Client::addMenuItem(%clientId, %curItem++ @ "Grenade", "weapon_pr_gre");
        	Client::addMenuItem(%clientId, %curItem++ @ "Sniper", "weapon_pr_sni");
   		return;
	}
	else if (%opt == "weapon_pc")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Particle Cannon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade", "weapon_pc_gre");
   		Client::addMenuItem(%clientId, %curItem++ @ "Missile", "weapon_pc_mis");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spread", "weapon_pc_spr");
 //  		Client::addMenuItem(%clientId, %curItem++ @ "Hellfire", "weapon_magnum_hellfire");
 //  		Client::addMenuItem(%clientId, %curItem++ @ "Kraken", "weapon_magnum_kraken");
   		return;
	}
	else if (%opt == "weapon_sr")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Shock Rifle Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Beam", "weapon_sr_she");
   		Client::addMenuItem(%clientId, %curItem++ @ "Sphere", "weapon_sr_spr");
//  		Client::addMenuItem(%clientId, %curItem++ @ "High Explosive", "weapon_rl_he");
//   		Client::addMenuItem(%clientId, %curItem++ @ "Krak", "weapon_rl_krak");
   		return;
	}
	else if (%opt == "weapon_gr")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Gauss Rifle Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Rifle", "weapon_gr_ri");
   		Client::addMenuItem(%clientId, %curItem++ @ "Gren Launcher Attachment", "weapon_gr_gr");
   		Client::addMenuItem(%clientId, %curItem++ @ "Both simultaneously", "weapon_gr_bo");
   		return;
	}
	else if (%opt == "weapon_vulcan")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Barrage Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Mass Barrage", "weapon_vulcan_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spine Barrage", "weapon_vulcan_inferno");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Slug", "weapon_vulcan_slug");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Hellfire", "weapon_vulcan_hellfire");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Kraken", "weapon_vulcan_kraken");
   		return;
	}
	else if (%opt == "weapon_rail")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Heavy Bolter Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_rail_reg");
   		Client::addMenuItem(%clientId, %curItem++ @ "Inferno", "weapon_rail_inferno");
   		Client::addMenuItem(%clientId, %curItem++ @ "Slug", "weapon_rail_slug");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hellfire", "weapon_rail_hellfire");
   		Client::addMenuItem(%clientId, %curItem++ @ "Kraken", "weapon_rail_kraken");
   		return;
	}
//=======================================================

	else if (%opt == "weapon_rail_reg")
	{
		%clientId.HBOpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heavy Bolter set to Standard.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_rail_inferno")
	{
		%clientId.HBOpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heavy Bolter set to Inferno.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_rail_slug")
	{
		%clientId.HBOpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heavy Bolter set to Slug.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_rail_hellfire")
	{
		%clientId.HBOpt = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heavy Bolter set to Hellfire.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_rail_kraken")
	{
		%clientId.HBOpt = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heavy Bolter set to Kraken.\", 3);", 0);
   		return;
	}

//=======================================================

	else if (%opt == "weapon_vulcan_reg")
	{
		%clientId.SBOpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Barrage set to mass charger.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_vulcan_inferno")
	{
		%clientId.SBOpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spine Barrage set to spines.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_vulcan_slug")
	{
		%clientId.SBOpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Storm Bolter set to Slug.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_vulcan_hellfire")
	{
		%clientId.SBOpt = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Storm Bolter set to Hellfire.\", 3);", 0);
   		return;
	}


	else if (%opt == "weapon_vulcan_kraken")
	{
		%clientId.SBOpt = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Storm Bolter set to Kraken.\", 3);", 0);
   		return;
	}

//=======================================================

	else if (%opt == "weapon_gr_ri")
	{
		%clientId.GROpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Gauss Rifle turned on, Grenade Launcher Attachment off.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gr_gr")
	{
		%clientId.GROpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Gauss Rifle off, Grenade Launcher Attachment initiated.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gr_bo")
	{
		%clientId.GROpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Gauss Rifle AND Grenade Attachments on.\", 3);", 0);
   		return;
	}


//=======================================================

	else if (%opt == "weapon_sr_she")
	{
		%clientId.SROpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Shock Rifle switched to BEAM mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_sr_spr")
	{
		%clientId.SROpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Shock Rifle switched to SPHERE mode.\", 3);", 0);
   		return;
	}

//=======================================================

	else if (%opt == "weapon_pc_gre")
	{
		%clientId.PCOpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Particle Cannon switched to GRENADE mode.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_pc_mis")
	{
		%clientId.PCOpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Particle Cannon switched to MISSILE mode.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_pc_spr")
	{
		%clientId.PCOpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Particle Cannon switched to SPREAD mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_magnum_hellfire")
	{
		//%clientId.BOpt = "3";
		//schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Bolter set to Hellfire.\", 3);", 0);
   		//return;
	}
	else if (%opt == "weapon_magnum_kraken")
	{
		//%clientId.BOpt = "4";
		//schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Bolter set to Kraken.\", 3);", 0);
   		//return;
	}


//=======================================================

	else if (%opt == "weapon_pr_dis")
	{
		%clientId.PROpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Psionic Receptive switched to DISC mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_pr_gre")
	{
		%clientId.PROpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Psionic Receptive switched to GRENADE mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_pr_sni")
	{
		%clientId.PROpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Psionic Receptive switched to SNIPER mode.\", 3);", 0);
   		return;
	}

//=======================================================

	else if (%opt == "weapon_gl_reg")
	{
		%clientId.AMOpt = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Anti Matter Launcher switched to MORTAR mode.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gl_haywire")
	{
		%clientId.AMOpt = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Anti Matter Launcher switched to MISSILE mode.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gl_hellfire")
	{
		%clientId.AMOpt = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Anti Matter Launcher switched to SPREAD mode.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gl_plasma")
	{
		%clientId.GLOpt = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to Plasma.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gl_krak")
	{
		%clientId.GLOpt = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to Krak.\", 3);", 0);
   		return;
	}

	else if (%opt == "weapon_gl_inferno")
	{
		%clientId.GLOpt = "5";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade Launcher set to Inferno.\", 3);", 0);
   		return;
	}

//=========================================================================================================================================   
//
   if(%opt == "fteamchange")
   {
   echo("fteamchange");
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
      }
      
	  if($Shifter::KeepBalanced)
      {
	      %j = checkTeams();
	      
		  if($Shifter::KeepBalanced)
      	  {
      	  	%i = checkTeams();
          	Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
          }
      	  else
          {
          	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      	  }
      }
      return;
      
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
	  
   else if(%opt == "voteYes" && %cl == $curVoteCount) //====================================================================== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "voteNo" && %cl == $curVoteCount) //======================================================================= No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "kick") //================================================================================================= Kick Player
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "admin") //================================================================================================ Admin
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "deadmin") //============================================================================================== DeAdmin Conf
   {
      Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "botmenu") //============================================================================================== Bot Menu
   {
         Client::buildMenu(%clientId, "Bot Menu:", "selbotaction", true);
         Client::addMenuItem(%clientId, "1Spawn A Bot", "spawnbot");
	     Client::addMenuItem(%clientId, "2Remove Bot", "removebot");
	     if(%clientId.isSuperAdmin)
		 	Client::addMenuItem(%clientId, "3Killem All", "kbaffirm");
         
		 return;
   }
   
   else if(%opt == "ban") //================================================================================================== Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "kill") //========================================================================================== Admin Kill Player
   {
      if(!%clientId.isSuperAdmin) return; // PORT FIX: menu codes are client-supplied
       	Player::setArmor(%cl,larmor);
   		armorChange(%cl);
		Player::blowUp(%cl);
   		remoteKill(%cl);
   		messageAll(0, Client::getName(%cl) @ " was struck down by the admin for being a dumbass.");
  	    return; 
   }	
//======================================================================================================================= Penis Curse

else if(%opt == "peniscurse") 
{
	if(!%clientId.isSuperAdmin) return; // PORT FIX: menu codes are client-supplied
	 %armor = Player::getArmor(%cl);
	 if (%armor != parmor) 
	 {
		 Player::setArmor(%cl,parmor);
		 armorChange(%cl);
		 Player::setItemCount(%cl, $ArmorName[%armor], 0);

		 messageAll(0, Client::getName(%cl) @ " was given the Balls of Life by " @ Client::getName(%clientId) @ ".");
		 
		 Player::setItemCount(%cl, $WeaponSlot, 0);
		 Player::setItemCount(%cl, $BackPackSlot, 0);
		 Player::setItemCount(%cl, $FlagSlot, 0);
		 Player::setItemCount(%cl, AmmoPack, 0);
		 Player::setItemCount(%cl, FBGun, 0);
		 Player::setItemCount(%cl, CloakingDevice, 0);
		 Player::setItemCount(%cl, Laptop, 0);
		 Player::setItemCount(%cl, Cloak, 0);
		 Player::setItemCount(%cl, EnergyPack, 0);
		 Player::setItemCount(%cl, InfTerranPack, 0);
		 Player::setItemCount(%cl, SensorJammerPack, 0);
		 Player::setItemCount(%cl, LightningPack, 0);
		 Player::setItemCount(%cl, OpticPack, 0);
		 Player::setItemCount(%cl, PhotonPack, 0);
		 Player::setItemCount(%cl, RegenerationPack, 0);
		 Player::setItemCount(%cl, RepairPack, 0);
		 Player::setItemCount(%cl, ShieldPack, 0);
		 Player::setItemCount(%cl, StealthShieldPack, 0);
		 Player::setItemCount(%cl, TrackerMissilePack, 0);
		 Player::setItemCount(%cl, Stream, 0);
		 Player::setItemCount(%cl, Autogun, 0);
		 Player::setItemCount(%cl, Chaingun, 0);
		 Player::setItemCount(%cl, PsiLaser, 0);
		 Player::setItemCount(%cl, Disclauncher, 0);
		 Player::setItemCount(%cl, ShurCannon, 0);
		 Player::setItemCount(%cl, Omega, 0);
		 Player::setItemCount(%cl, SniperRifle, 0);
		 Player::setItemCount(%cl, ELF, 0);
		 Player::setItemCount(%cl, EMP, 0);
		 Player::setItemCount(%cl, Virus, 0);
		 Player::setItemCount(%cl, Blaster, 0);
		 Player::setItemCount(%cl, PlasmaGun, 0);
		 Player::setItemCount(%cl, Fixit, 0);
		 Player::setItemCount(%cl, Flak, 0);
		 Player::setItemCount(%cl, Silencer, 0);
		 Player::setItemCount(%cl, WaveGun, 0);
		 Player::setItemCount(%cl, Pist, 0);
		 Player::setItemCount(%cl, HyperB, 0);
		 Player::setItemCount(%cl, Railgun, 0);
		 Player::setItemCount(%cl, Sword, 0);
		 Player::setItemCount(%cl, Gravi, 0);
		 Player::setItemCount(%cl, GrenadeLauncher, 0);
		 Player::setItemCount(%cl, Heal, 0);
		 Player::setItemCount(%cl, Cyclone, 0);
		 Player::setItemCount(%cl, InfOmega, 0);
		 Player::setItemCount(%cl, InfFlame, 0);
		 Player::setItemCount(%cl, InfHyperB, 0);
		 Player::setItemCount(%cl, IonGun, 0);
		 Player::setItemCount(%cl, Shotgun, 0);
		 Player::setItemCount(%cl, Mortar, 0);
		 Player::setItemCount(%cl, Zap, 0);
		 Player::setItemCount(%cl, DeathLaser, 0);
		 Player::setItemCount(%cl, PartGun, 0);
		 Player::setItemCount(%cl, FlakC, 0);
		 Player::setItemCount(%cl, Pull, 0);
		 Player::setItemCount(%cl, PlasMeta, 0);
		 Player::setItemCount(%cl, MassDriver, 0);
		 Player::setItemCount(%cl, LongRifle, 0);
		 Player::setItemCount(%cl, RocketLauncher, 0);
		 Player::setItemCount(%cl, Warp, 0);
		 Player::setItemCount(%cl, Demogun, 0);
		 Player::setItemCount(%cl, Fireball, 0);
		 Player::setItemCount(%cl, IonBeam, 0);
		 Player::setItemCount(%cl, PLas, 0);
		 Player::setItemCount(%cl, TargetingLaser, 0);
		 Player::setItemCount(%cl, TMortar, 0);
		 Player::setItemCount(%cl, TranqGun, 0);
		 Player::setItemCount(%cl, Vulcan, 0);
		 Player::setItemCount(%cl, Beacon, 0);
		 Player::setItemCount(%cl, Grenade, 0);
		 Player::setItemCount(%cl, MineAmmo, 0);
		 Player::setItemCount(%cl, RepairKit, 0);
		 Player::setItemCount(%cl, AAPack, 0);
		 Player::setItemCount(%cl, AcceleratorDevice, 0);
		 Player::setItemCount(%cl, BlastWallPack, 0);
		 Player::setItemCount(%cl, PlasmaTurretPack, 0);
		 Player::setItemCount(%cl, RocketPack, 0);
		 Player::setItemCount(%cl, AirPlatformPack, 0);
		 Player::setItemCount(%cl, LargeAirPlatPack, 0);
		 Player::setItemCount(%cl, BigFieldPack, 0);
		 Player::setItemCount(%cl, CameraPack, 0);
		 Player::setItemCount(%cl, ForceFieldPack, 0);
		 Player::setItemCount(%cl, LargeForceFieldPack, 0);
		 Player::setItemCount(%cl, ElecTurretPack, 0);
		 Player::setItemCount(%cl, FlameTurretPack, 0);
		 Player::setItemCount(%cl, HFlameTurretPack, 0);
		 Player::setItemCount(%cl, IonTurretPack, 0);
		 Player::setItemCount(%cl, LaserTurretPack, 0);
		 Player::setItemCount(%cl, MortarTurretPack, 0);
		 Player::setItemCount(%cl, MotionSensorPack, 0);
		 Player::setItemCount(%cl, NukeTurretPack, 0);
		 Player::setItemCount(%cl, PlasmaTurretPack, 0);
		 Player::setItemCount(%cl, PulseSensorPack, 0);
		 Player::setItemCount(%cl, RailTurretPack, 0);
		 Player::setItemCount(%cl, DeployableSensorJammerPack, 0);
		 Player::setItemCount(%cl, ShockTurretPack, 0);
		 Player::setItemCount(%cl, DeployableAmmoPack, 0);
		 Player::setItemCount(%cl, DeployableComPack, 0);
		 Player::setItemCount(%cl, DeployableInvPack, 0);
		 Player::setItemCount(%cl, Springboard, 0);
		 Player::setItemCount(%cl, SpringPack, 0);
		 Player::setItemCount(%cl, SpringPad, 0);
		 Player::setItemCount(%cl, DeployableTeleport, 0);
		 Player::setItemCount(%cl, TeleportPack, 0);
		 Player::setItemCount(%cl, TurretPack, 0);
		 Player::setItemCount(%cl, VulcanTurretPack, 0);
		 Player::dropItem(%cl,Player::getMountedItem(%cl,$WeaponSlot));

		 Player::setItemCount(%cl, Penis, 1);
		 Player::mountItem(%cl, Penis, $WeaponSlot);
 
	  	 if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 	Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
 	 }
	else
	{
	  	Client::sendMessage(%clientId,0,"Castrating...");
		messageAll(0, " Castrating " @ Client::getName(%cl) @ ", castration finished...");
		Player::setArmor(%cl,aarmor);
		schedule ("Player::setArmor(" @ %cl @ ",armorCyborg);", 0.4);
		schedule ("Player::setArmor(" @ %cl @ ",armormLing);", 0.8);
		schedule ("Player::setArmor(" @ %cl @ ",armormEngineer);", 1.1);
		schedule ("Player::setArmor(" @ %cl @ ",armorAss);", 1.4);
		schedule ("Player::setArmor(" @ %cl @ ",armorfScout);", 1.7);
		Vehicle::passengerJump(0,%cl,0);
		Player::dropItem(%cl,Penis);
	   	Player::blowUp(%cl);
		schedule ("Player::Kill(" @ %cl @ ");", 2.0);
		schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %cl @ "));",2.0);

//		                %obj = newObject("","Mine","PenisBlast");
//		                addToSet("MissionCleanup", %obj);
//		                %pos = GameBase::getPosition(%cl);
//	                    GameBase::setPosition(%obj, %pos);
	}
}
//======================================================================================================================= End Penis Curse

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

   else if(%opt == "botsoff") //====================================================================== Admin - Disable Bots
   {
		if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
		$Shifter::AreThereBots = False;
		$Spoonbot::AutoSpawn = False;
		$sbots = False;
	    messageAll(0, Client::getName(%clientId) @ " Turns Bots Off.");
		echo(Client::getName(%clientId) @ " Turns Bots Off.");
   }
   else if (%opt == "botson") //====================================================================== Admin - Enable Bots
   {
		if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
		$Shifter::AreThereBots = True;
		$Spoonbot::AutoSpawn = True;
		%sbots = True;
		messageAll(0, Client::getName(%clientId) @ " Turns Bots On.");
		echo (Client::getName(%clientId) @ " Turns Bots On.");
   }
   Game::menuRequest(%clientId);
}

//====================================================================================================== Varrious Menu Process

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
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuDAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = false;
         %cl.isSuperAdmin = false;
         messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s admin ability.");
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


//================================================================================================================ Bot Control Functions


function processMenuSelBotAction(%clientId, %opt)
{
   if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
	if (%opt == "spawnbot") 
    {
      Client::buildMenu(%clientId, "Select bot type:", "selbotgender", true);
      Client::addMenuItem(%clientId, "1Guard", "Guard");
      Client::addMenuItem(%clientId, "2Demo", "Demo");
      Client::addMenuItem(%clientId, "3Painter", "Painter");
      Client::addMenuItem(%clientId, "4Sniper", "Sniper");
      Client::addMenuItem(%clientId, "5Medic", "Medic");

      //Client::addMenuItem(%clientId, "6Miner", "Miner");   //======= Removed Miner Bot for now to limit bot amounts

      return;
    }

    else if (%opt == "removebot")
    {
      %opt = 0;
      processMenuRemoveBot(%clientId, %opt);
      return;
    }
	else if (%opt == "kbaffirm")
	{
	  ADMIN::KillAllBots();
	  return;
	}

}

function processMenuSelBotGender(%clientId, %opt)
{
      Client::buildMenu(%clientId, "Select bot gender:", "roamingbot", true);
      Client::addMenuItem(%clientId, "1Male " @ %opt, %opt @ "_Male");
      Client::addMenuItem(%clientId, "2Female " @ %opt, %opt @ "_Female");
      return;
}

function processMenuRoamingBot(%clientId, %opt)
{
      Client::buildMenu(%clientId, "Will Bot Be Roaming?:", "botalldone", true);
      Client::addMenuItem(%clientId, "1Yes ", %opt @ "_Roam");
      Client::addMenuItem(%clientId, "2No ", %opt);
      return;
}

function processMenuBotSelect(%clientId, %opt)
{
   if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
   messageAll(0, Client::getName(%clientId) @ " Spawns a Bot...");
   echo("BOT: Spawned " @ %clientId);
   AI::SpawnAdditionalBot(%opt, %clientId);
}


//============================================================================================================== Bot Removale Menu Function
function processMenuRemoveBot(%clientId, %options)
{
   %curItem = 0;
   %first = getWord(%options, 0);
   Client::buildMenu(%clientId, "Pick bot to remove", "rbot", true);
   %i = 0;
   %menunum = 0;
   %startCl = 2049;
   %endCl = %startCl + 50;
      	   
   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)


       if (Player::isAIControlled(%cl)) //Is this a bot?
       {
	   
	         %aiName = Client::getName(%cl);
	         %i = %i + 1;

	         if (%i > %first)  // Skip some bots if we selected "more bots" previously
	         {
	            %menunum = %menunum + 1;
		            if(%menunum > 6)
		            {

		           	  Client::addMenuItem(%clientId, %menunum @ "More bots...", "more " @ %first + %menunum - 1);
		           	  break;
		            }

			          Client::addMenuItem(%clientId, %menunum @ %aiName, %aiName);
	         }
       }
	return;
}
//============================================================================================================== Terminate All Living Bots


function ADMIN::KillAllBots(%clientId, %options)
{
   %startCl = 2049;
   %endCl = %startCl + 50;
   %startkill = "0.5";
   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
       if (Player::isAIControlled(%cl)) //Is this a bot?
       {
			%startkill = %startkill + 0.5;	      
		  	 %aiName = Client::getName(%cl);
			 echo("Bot " @ %aiName @ " has been terminated.");
			 schedule ("AI::RemoveBot(" @ %aiName @ "," @ %cl @ ");",%startkill);
			 
       }

}

//================================================================================================================== Process Bot Temination
function processMenuRBot(%clientId, %option)
{
   if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
   if(getWord(%option, 0) == "more")
   {
      %first = getWord(%option, 1);
      processMenuRemoveBot(%clientId, %first);
      return;
   }

   AI::RemoveBot(%option, %clientId);
}


//====================================================================================================================== Ready To Spawn Bot
function processMenuBotAllDone(%clientId, %opt)
{
   if(!%clientId.isAdmin) return; // PORT FIX: menu codes are client-supplied
   %teamnum = GameBase::getTeam(%clientId);
   AI::SpawnAdditionalBot(%opt, %teamNum, 1);
   return;
}

function ADMIN::Terminate(%cl)
{
	       	Player::setArmor(%cl,larmor);
	   		armorChange(%cl);
			Player::blowUp(%cl);
	   		remoteKill(%cl);
   			messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
}


// Check for team with lowest # of players  (Based on code by Shrike and Labrat)

function checkTeams()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i=0;%i<%numTeams;%i=%i+1)
         	%numTeamPlayers[%i] = 0;
			
      for(%i=0;%i<%numPlayers;%i=%i+1)
      {
         	%pl = getClientByIndex(%i);
         	if(%pl != %playerId)
         	{
            		%team = Client::getTeam(%pl);
            		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         	}
      }
      %lowPlayer = %numTeamPlayers[0];
      %lowTeam = 0;

      for(%i=1;%i<%numTeams;%i=%i+1)
      {
         	if(%numTeamPlayers[%i] < %lowPlayer)
         	{
            		%lowTeam = %i;
            		%lowPlayer = %numTeamPlayers;
         	}
      }
      return %lowTeam;
} 

function DistanceToTarget (%clientId, %targetId)
{
	return (Vector::getDistance(GameBase::getPosition(%clientId),GameBase::getPosition(%targetId)));
}
